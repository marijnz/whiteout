// Shader created with Shader Forge Beta 0.34 
// Shader Forge (c) Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:0.34;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:1,uamb:True,mssp:True,lmpd:False,lprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:False,blpr:1,bsrc:3,bdst:7,culm:0,dpts:2,wrdp:False,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1,x:32719,y:32712|emission-5-OUT,alpha-37-OUT;n:type:ShaderForge.SFN_Tex2d,id:2,x:33167,y:32686,ptlb:node_2,ptin:_node_2,tex:cb7b276b9fc4e514d8f40f7449039916,ntxv:0,isnm:False|UVIN-27-OUT;n:type:ShaderForge.SFN_OneMinus,id:5,x:32962,y:32633|IN-2-RGB;n:type:ShaderForge.SFN_Time,id:23,x:33751,y:33081;n:type:ShaderForge.SFN_Divide,id:24,x:33510,y:33081|A-23-T,B-25-OUT;n:type:ShaderForge.SFN_ValueProperty,id:25,x:33751,y:33193,ptlb:node_25,ptin:_node_25,glob:False,v1:40;n:type:ShaderForge.SFN_TexCoord,id:26,x:33510,y:32896,uv:0;n:type:ShaderForge.SFN_Append,id:27,x:33116,y:32951|A-28-OUT,B-26-V;n:type:ShaderForge.SFN_Add,id:28,x:33308,y:32951|A-26-U,B-24-OUT;n:type:ShaderForge.SFN_Time,id:30,x:33326,y:33182;n:type:ShaderForge.SFN_Divide,id:32,x:33085,y:33182|A-30-T,B-34-OUT;n:type:ShaderForge.SFN_ValueProperty,id:34,x:33326,y:33294,ptlb:node_25_copy,ptin:_node_25_copy,glob:False,v1:1;n:type:ShaderForge.SFN_Cos,id:35,x:32895,y:33181|IN-32-OUT;n:type:ShaderForge.SFN_Divide,id:37,x:32444,y:33181|A-40-OUT,B-39-OUT;n:type:ShaderForge.SFN_ValueProperty,id:39,x:32444,y:33314,ptlb:node_25_copy_copy,ptin:_node_25_copy_copy,glob:False,v1:2;n:type:ShaderForge.SFN_Add,id:40,x:32675,y:33181|A-35-OUT,B-44-OUT;n:type:ShaderForge.SFN_ValueProperty,id:42,x:33454,y:33422,ptlb:node_25_copy_copy_copy,ptin:_node_25_copy_copy_copy,glob:False,v1:10;n:type:ShaderForge.SFN_ValueProperty,id:44,x:32675,y:33314,ptlb:node_25_copy_copy_copy,ptin:_node_25_copy_copy_copy,glob:False,v1:1;proporder:2-25-34-39-44;pass:END;sub:END;*/

Shader "Custom/Sea" {
    Properties {
        _node_2 ("node_2", 2D) = "white" {}
        _node_25 ("node_25", Float ) = 40
        _node_25_copy ("node_25_copy", Float ) = 1
        _node_25_copy_copy ("node_25_copy_copy", Float ) = 2
        _node_25_copy_copy_copy ("node_25_copy_copy_copy", Float ) = 1
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        LOD 200
        Pass {
            Name "ForwardBase"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform sampler2D _node_2; uniform float4 _node_2_ST;
            uniform float _node_25;
            uniform float _node_25_copy;
            uniform float _node_25_copy_copy;
            uniform float _node_25_copy_copy_copy;
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
                float2 node_26 = i.uv0;
                float4 node_23 = _Time + _TimeEditor;
                float2 node_27 = float2((node_26.r+(node_23.g/_node_25)),node_26.g);
                float3 emissive = (1.0 - tex2D(_node_2,TRANSFORM_TEX(node_27, _node_2)).rgb);
                float3 finalColor = emissive;
                float4 node_30 = _Time + _TimeEditor;
/// Final Color:
                return fixed4(finalColor,((cos((node_30.g/_node_25_copy))+_node_25_copy_copy_copy)/_node_25_copy_copy));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
