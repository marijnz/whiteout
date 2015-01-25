// Shader created with Shader Forge Beta 0.34 
// Shader Forge (c) Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:0.34;sub:START;pass:START;ps:flbk:,lico:1,lgpr:1,nrmq:1,limd:0,uamb:True,mssp:True,lmpd:False,lprd:False,enco:False,frtr:True,vitr:True,dbil:False,rmgx:True,rpth:0,hqsc:True,hqlp:True,blpr:1,bsrc:3,bdst:7,culm:0,dpts:2,wrdp:False,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,ofsf:0,ofsu:0,f2p0:False;n:type:ShaderForge.SFN_Final,id:1,x:32719,y:32712|emission-1116-OUT,alpha-1010-OUT;n:type:ShaderForge.SFN_Tex2d,id:952,x:33176,y:33166,ptlb:HitpointMap,ptin:_HitpointMap,tex:0d65d8eb89cdad744a64776c0c754535,ntxv:0,isnm:False;n:type:ShaderForge.SFN_OneMinus,id:1010,x:32987,y:33049|IN-952-G;n:type:ShaderForge.SFN_Tex2d,id:1016,x:33255,y:32551,ptlb:node_1016,ptin:_node_1016,tex:cb7b276b9fc4e514d8f40f7449039916,ntxv:0,isnm:False|UVIN-1086-OUT;n:type:ShaderForge.SFN_TexCoord,id:1038,x:34785,y:32840,uv:0;n:type:ShaderForge.SFN_Time,id:1082,x:34414,y:32347;n:type:ShaderForge.SFN_Append,id:1086,x:33458,y:32616|A-1100-OUT,B-1038-V;n:type:ShaderForge.SFN_Add,id:1100,x:34001,y:32530|A-1224-OUT,B-1184-OUT;n:type:ShaderForge.SFN_Blend,id:1116,x:32955,y:32695,blmd:10,clmp:True|SRC-1016-RGB,DST-1118-RGB;n:type:ShaderForge.SFN_Tex2d,id:1118,x:33587,y:32771,ptlb:node_1016_copy,ptin:_node_1016_copy,tex:cb7b276b9fc4e514d8f40f7449039916,ntxv:0,isnm:False|UVIN-1120-OUT;n:type:ShaderForge.SFN_Append,id:1120,x:33403,y:32972|A-1157-OUT,B-1369-OUT;n:type:ShaderForge.SFN_Time,id:1124,x:34575,y:33254;n:type:ShaderForge.SFN_Subtract,id:1136,x:34234,y:33192|A-1038-U,B-1191-OUT;n:type:ShaderForge.SFN_Multiply,id:1157,x:34030,y:33306|A-1136-OUT,B-1159-OUT;n:type:ShaderForge.SFN_Vector1,id:1159,x:34194,y:33389,v1:-1.77;n:type:ShaderForge.SFN_Divide,id:1184,x:34213,y:32438|A-1082-T,B-1185-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1185,x:34414,y:32460,ptlb:node_1185,ptin:_node_1185,glob:False,v1:30;n:type:ShaderForge.SFN_Divide,id:1191,x:34394,y:33244|A-1124-T,B-1193-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1193,x:34575,y:33367,ptlb:node_1185_copy,ptin:_node_1185_copy,glob:False,v1:50;n:type:ShaderForge.SFN_Multiply,id:1224,x:34228,y:32666|A-1038-U,B-1225-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1225,x:34426,y:32700,ptlb:node_1225,ptin:_node_1225,glob:False,v1:1.77;n:type:ShaderForge.SFN_ValueProperty,id:1283,x:34243,y:32885,ptlb:node_1225_copy,ptin:_node_1225_copy,glob:False,v1:0.25;n:type:ShaderForge.SFN_ValueProperty,id:1298,x:33899,y:32420,ptlb:node_1298,ptin:_node_1298,glob:False,v1:1;n:type:ShaderForge.SFN_Add,id:1335,x:34037,y:32830|A-1038-V,B-1283-OUT;n:type:ShaderForge.SFN_Fmod,id:1357,x:35807,y:33223;n:type:ShaderForge.SFN_Time,id:1359,x:34253,y:32975;n:type:ShaderForge.SFN_Fmod,id:1361,x:35115,y:33005;n:type:ShaderForge.SFN_Divide,id:1363,x:34037,y:32975|A-1359-T,B-1365-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1365,x:34253,y:33091,ptlb:node_1185_copy_copy,ptin:_node_1185_copy_copy,glob:False,v1:70;n:type:ShaderForge.SFN_Fmod,id:1367,x:34816,y:32810;n:type:ShaderForge.SFN_Add,id:1369,x:33834,y:32864|A-1335-OUT,B-1363-OUT;proporder:952-1016-1118-1185-1193-1225-1283-1298-1365;pass:END;sub:END;*/

Shader "Shader Forge/FogOfWar" {
    Properties {
        _HitpointMap ("HitpointMap", 2D) = "white" {}
        _node_1016 ("node_1016", 2D) = "white" {}
        _node_1016_copy ("node_1016_copy", 2D) = "white" {}
        _node_1185 ("node_1185", Float ) = 30
        _node_1185_copy ("node_1185_copy", Float ) = 50
        _node_1225 ("node_1225", Float ) = 1.77
        _node_1225_copy ("node_1225_copy", Float ) = 0.25
        _node_1298 ("node_1298", Float ) = 1
        _node_1185_copy_copy ("node_1185_copy_copy", Float ) = 70
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
            uniform float4 _TimeEditor;
            uniform sampler2D _HitpointMap; uniform float4 _HitpointMap_ST;
            uniform sampler2D _node_1016; uniform float4 _node_1016_ST;
            uniform sampler2D _node_1016_copy; uniform float4 _node_1016_copy_ST;
            uniform float _node_1185;
            uniform float _node_1185_copy;
            uniform float _node_1225;
            uniform float _node_1225_copy;
            uniform float _node_1185_copy_copy;
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
                float2 node_1038 = i.uv0;
                float4 node_1082 = _Time + _TimeEditor;
                float2 node_1086 = float2(((node_1038.r*_node_1225)+(node_1082.g/_node_1185)),node_1038.g);
                float4 node_1124 = _Time + _TimeEditor;
                float4 node_1359 = _Time + _TimeEditor;
                float2 node_1120 = float2(((node_1038.r-(node_1124.g/_node_1185_copy))*(-1.77)),((node_1038.g+_node_1225_copy)+(node_1359.g/_node_1185_copy_copy)));
                float3 emissive = saturate(( tex2D(_node_1016_copy,TRANSFORM_TEX(node_1120, _node_1016_copy)).rgb > 0.5 ? (1.0-(1.0-2.0*(tex2D(_node_1016_copy,TRANSFORM_TEX(node_1120, _node_1016_copy)).rgb-0.5))*(1.0-tex2D(_node_1016,TRANSFORM_TEX(node_1086, _node_1016)).rgb)) : (2.0*tex2D(_node_1016_copy,TRANSFORM_TEX(node_1120, _node_1016_copy)).rgb*tex2D(_node_1016,TRANSFORM_TEX(node_1086, _node_1016)).rgb) ));
                float3 finalColor = emissive;
                float2 node_1386 = i.uv0;
/// Final Color:
                return fixed4(finalColor,(1.0 - tex2D(_HitpointMap,TRANSFORM_TEX(node_1386.rg, _HitpointMap)).g));
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
