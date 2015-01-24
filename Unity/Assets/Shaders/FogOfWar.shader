// Shader created with Shader Forge Beta 0.34 
// Shader Forge (c) Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:0.34;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:0,uamb:True,mssp:True,lmpd:False,lprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:True,blpr:1,bsrc:3,bdst:7,culm:0,dpts:2,wrdp:False,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1,x:32719,y:32712|diff-768-RGB,emission-768-RGB,alpha-1010-OUT;n:type:ShaderForge.SFN_TexCoord,id:14,x:34304,y:32819,uv:0;n:type:ShaderForge.SFN_Distance,id:38,x:34087,y:32819|A-14-UVOUT,B-536-OUT;n:type:ShaderForge.SFN_If,id:39,x:33458,y:33309|A-1010-OUT,B-40-OUT,GT-42-OUT,EQ-42-OUT,LT-164-OUT;n:type:ShaderForge.SFN_ValueProperty,id:40,x:33784,y:33212,ptlb:HitDistance,ptin:_HitDistance,glob:False,v1:0.1;n:type:ShaderForge.SFN_ValueProperty,id:42,x:33784,y:33387,ptlb:hidden,ptin:_hidden,glob:False,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:164,x:33764,y:33482,ptlb:shown,ptin:_shown,glob:False,v1:0;n:type:ShaderForge.SFN_Add,id:422,x:33531,y:32690|A-1010-OUT,B-423-OUT;n:type:ShaderForge.SFN_ValueProperty,id:423,x:33622,y:32916,ptlb:node_423,ptin:_node_423,glob:False,v1:-0.1;n:type:ShaderForge.SFN_Append,id:536,x:34254,y:33065|A-539-OUT,B-541-OUT;n:type:ShaderForge.SFN_ValueProperty,id:539,x:34462,y:32930,ptlb:HitPointX,ptin:_HitPointX,glob:False,v1:0.2;n:type:ShaderForge.SFN_ValueProperty,id:541,x:34531,y:33027,ptlb:HitPointY,ptin:_HitPointY,glob:False,v1:0.2;n:type:ShaderForge.SFN_Tex2d,id:768,x:33058,y:32639,ptlb:FogTexture,ptin:_FogTexture,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:827,x:33219,y:32888|A-422-OUT,B-39-OUT;n:type:ShaderForge.SFN_Tex2d,id:952,x:33988,y:32574,ptlb:HitpointMap,ptin:_HitpointMap,tex:0d65d8eb89cdad744a64776c0c754535,ntxv:0,isnm:False;n:type:ShaderForge.SFN_OneMinus,id:1010,x:33901,y:32740|IN-952-G;proporder:40-42-164-423-539-541-768-952;pass:END;sub:END;*/

Shader "Shader Forge/FogOfWar" {
    Properties {
        _HitDistance ("HitDistance", Float ) = 0.1
        _hidden ("hidden", Float ) = 1
        _shown ("shown", Float ) = 0
        _node_423 ("node_423", Float ) = -0.1
        _HitPointX ("HitPointX", Float ) = 0.2
        _HitPointY ("HitPointY", Float ) = 0.2
        _FogTexture ("FogTexture", 2D) = "white" {}
        _HitpointMap ("HitpointMap", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            Fog {Mode Off}
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform sampler2D _FogTexture; uniform float4 _FogTexture_ST;
            uniform sampler2D _HitpointMap; uniform float4 _HitpointMap_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float2 node_1076 = i.uv0;
                float4 node_768 = tex2D(_FogTexture,TRANSFORM_TEX(node_1076.rg, _FogTexture));
                float3 emissive = node_768.rgb;
                float3 finalColor = emissive;
                float node_1010 = (1.0 - tex2D(_HitpointMap,TRANSFORM_TEX(node_1076.rg, _HitpointMap)).g);
/// Final Color:
                return fixed4(finalColor,node_1010);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
