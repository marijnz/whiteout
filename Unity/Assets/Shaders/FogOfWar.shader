// Shader created with Shader Forge Beta 0.34 
// Shader Forge (c) Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:0.34;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:1,uamb:True,mssp:True,lmpd:False,lprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:True,blpr:1,bsrc:3,bdst:7,culm:0,dpts:2,wrdp:False,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1,x:32719,y:32712|diff-768-RGB,alpha-422-OUT;n:type:ShaderForge.SFN_TexCoord,id:14,x:34304,y:32819,uv:0;n:type:ShaderForge.SFN_Distance,id:38,x:34087,y:32819|A-14-UVOUT,B-536-OUT;n:type:ShaderForge.SFN_If,id:39,x:33458,y:33309|A-1010-OUT,B-40-OUT,GT-42-OUT,EQ-42-OUT,LT-164-OUT;n:type:ShaderForge.SFN_ValueProperty,id:40,x:33784,y:33212,ptlb:HitDistance,ptin:_HitDistance,glob:False,v1:0.1;n:type:ShaderForge.SFN_ValueProperty,id:42,x:33784,y:33387,ptlb:hidden,ptin:_hidden,glob:False,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:164,x:33764,y:33482,ptlb:shown,ptin:_shown,glob:False,v1:0;n:type:ShaderForge.SFN_Add,id:422,x:33531,y:32690|A-1010-OUT,B-423-OUT;n:type:ShaderForge.SFN_ValueProperty,id:423,x:33725,y:32894,ptlb:node_423,ptin:_node_423,glob:False,v1:-0.1;n:type:ShaderForge.SFN_Append,id:536,x:34254,y:33065|A-539-OUT,B-541-OUT;n:type:ShaderForge.SFN_ValueProperty,id:539,x:34462,y:32930,ptlb:HitPointX,ptin:_HitPointX,glob:False,v1:0.2;n:type:ShaderForge.SFN_ValueProperty,id:541,x:34531,y:33027,ptlb:HitPointY,ptin:_HitPointY,glob:False,v1:0.2;n:type:ShaderForge.SFN_Tex2d,id:768,x:33034,y:32577,ptlb:FogTexture,ptin:_FogTexture,ntxv:2,isnm:False;n:type:ShaderForge.SFN_Multiply,id:827,x:33257,y:32862|A-422-OUT,B-39-OUT;n:type:ShaderForge.SFN_Tex2d,id:952,x:33988,y:32574,ptlb:HitpointMap,ptin:_HitpointMap,tex:0d65d8eb89cdad744a64776c0c754535,ntxv:0,isnm:False;n:type:ShaderForge.SFN_OneMinus,id:1010,x:33901,y:32740|IN-952-G;proporder:40-42-164-423-539-541-768-952;pass:END;sub:END;*/

Shader "Shader Forge/FogOfWar" {
    Properties {
        _HitDistance ("HitDistance", Float ) = 0.1
        _hidden ("hidden", Float ) = 1
        _shown ("shown", Float ) = 0
        _node_423 ("node_423", Float ) = -0.1
        _HitPointX ("HitPointX", Float ) = 0.2
        _HitPointY ("HitPointY", Float ) = 0.2
        _FogTexture ("FogTexture", 2D) = "black" {}
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
            uniform float4 _LightColor0;
            uniform float _node_423;
            uniform sampler2D _FogTexture; uniform float4 _FogTexture_ST;
            uniform sampler2D _HitpointMap; uniform float4 _HitpointMap_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(float4(v.normal,0), _World2Object).xyz;
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Normals:
                float3 normalDirection =  i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 diffuse = max( 0.0, NdotL) * attenColor + UNITY_LIGHTMODEL_AMBIENT.rgb;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                float2 node_1016 = i.uv0;
                finalColor += diffuseLight * tex2D(_FogTexture,TRANSFORM_TEX(node_1016.rg, _FogTexture)).rgb;
                float node_1010 = (1.0 - tex2D(_HitpointMap,TRANSFORM_TEX(node_1016.rg, _HitpointMap)).g);
                float node_422 = (node_1010+_node_423);
/// Final Color:
                return fixed4(finalColor,node_422);
            }
            ENDCG
        }
        Pass {
            Name "ForwardAdd"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZWrite Off
            
            Fog { Color (0,0,0,0) }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd
            #pragma exclude_renderers xbox360 ps3 flash d3d11_9x 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform float _node_423;
            uniform sampler2D _FogTexture; uniform float4 _FogTexture_ST;
            uniform sampler2D _HitpointMap; uniform float4 _HitpointMap_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o;
                o.uv0 = v.texcoord0;
                o.normalDir = mul(float4(v.normal,0), _World2Object).xyz;
                o.posWorld = mul(_Object2World, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            fixed4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
/////// Normals:
                float3 normalDirection =  i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = dot( normalDirection, lightDirection );
                float3 diffuse = max( 0.0, NdotL) * attenColor;
                float3 finalColor = 0;
                float3 diffuseLight = diffuse;
                float2 node_1017 = i.uv0;
                finalColor += diffuseLight * tex2D(_FogTexture,TRANSFORM_TEX(node_1017.rg, _FogTexture)).rgb;
                float node_1010 = (1.0 - tex2D(_HitpointMap,TRANSFORM_TEX(node_1017.rg, _HitpointMap)).g);
                float node_422 = (node_1010+_node_423);
/// Final Color:
                return fixed4(finalColor * node_422,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
