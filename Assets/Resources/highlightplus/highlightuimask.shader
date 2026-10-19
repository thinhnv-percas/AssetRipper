Shader "HighlightPlus/UI/Mask" {
	Properties {
		_MainTex ("Texture", any) = "white" {}
		_Color ("Color", Color) = (1,1,1,1)
		_CutOff ("CutOff", Float) = 0.5
		_Stencil ("Stencil ID", Float) = 14
		_StencilWriteMask ("Stencil Write Mask", Float) = 14
		_StencilReadMask ("Stencil Read Mask", Float) = 14
	}
	// AssetRipper: the structure below is the shader's own - subshaders, passes, tags
	// and render state are read from the asset. The program stages are NOT the
	// shader's; each carries a replacement and the backends its real programs were
	// compiled to.
	SubShader {
		Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
		Pass {
			Name "Highlight Plus UI Mask"
			Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
			Cull Off
			ZWrite Off
			ColorMask None
			Stencil {
				Ref 0
				ReadMask 0
				WriteMask 0
				Comp Always
				Pass Replace
				Fail Keep
				ZFail Keep
			}
			// real programs: Vertex 1 variant(s) [MetalVS] blobs 1, Fragment 1 variant(s) [MetalFS] blobs 3
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