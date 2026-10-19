Shader "HighlightPlus/Geometry/InnerGlow" {
	Properties {
		_MainTex ("Texture", any) = "white" {}
		_Color ("Color", Color) = (1,1,1,1)
		_InnerGlowColor ("Inner Glow Color", Color) = (1,1,1,1)
		_InnerGlowData ("Data", Vector) = (1,1,1,0)
		_CutOff ("CutOff", Float) = 0.5
		_Cull ("Cull Mode", Float) = 2
		_InnerGlowZTest ("ZTest", Float) = 4
		_InnerGlowBlendMode ("Blend Mode", Float) = 1
	}
	// AssetRipper: the structure below is the shader's own - subshaders, passes, tags
	// and render state are read from the asset. The program stages are NOT the
	// shader's; each carries a replacement and the backends its real programs were
	// compiled to.
	SubShader {
		Tags { "QUEUE" = "Transparent+122" "RenderType" = "Transparent" }
		Pass {
			Tags { "QUEUE" = "Transparent+122" "RenderType" = "Transparent" }
			Cull Off
			ZWrite Off
			ZTest Disabled
			Blend SrcAlpha Zero
			ColorMask All
			Stencil {
				Ref 4
				ReadMask 4
				Comp NotEqual
				Pass Keep
				Fail Keep
				ZFail Keep
			}
			// real programs: Vertex 2 variant(s) [MetalVS] blobs 1,2, Fragment 2 variant(s) [MetalFS] blobs 5,6
			CGPROGRAM
			// AssetRipperReplacementProgram: this stage is NOT the shader's own.
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			struct appdata { float4 vertex : POSITION; float2 uv : TEXCOORD0; };
			struct v2f { float4 vertex : SV_POSITION; float2 uv : TEXCOORD0; };
			sampler2D _MainTex;
			v2f vert(appdata v) { v2f o; o.vertex = UnityObjectToClipPos(v.vertex); o.uv = v.uv; return o; }
			fixed4 frag(v2f i) : SV_Target { return tex2D(_MainTex, i.uv); }
			ENDCG
		}
	}
}