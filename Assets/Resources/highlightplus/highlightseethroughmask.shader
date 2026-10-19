Shader "HighlightPlus/Geometry/SeeThroughMask" {
	Properties {
		_MainTex ("Texture", any) = "white" {}
		_Color ("Color", Color) = (1,1,1,1)
	}
	// AssetRipper: the structure below is the shader's own - subshaders, passes, tags
	// and render state are read from the asset. The program stages are NOT the
	// shader's; each carries a replacement and the backends its real programs were
	// compiled to.
	SubShader {
		Tags { "DisableBatching" = "true" "QUEUE" = "Transparent+201" "RenderType" = "Transparent" }
		Pass {
			Name "See-through mask"
			Tags { "DisableBatching" = "true" "QUEUE" = "Transparent+201" "RenderType" = "Transparent" }
			ZTest Always
			ColorMask None
			Stencil {
				Ref 1
				WriteMask 3
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