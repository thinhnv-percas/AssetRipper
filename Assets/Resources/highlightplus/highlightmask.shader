Shader "HighlightPlus/Geometry/Mask" {
	Properties {
		_MainTex ("Texture", any) = "white" {}
		_Color ("Color", Color) = (1,1,1,1)
		_CutOff ("CutOff", Float) = 0.5
		_Cull ("Cull Mode", Float) = 2
		_ZTest ("ZTest", Float) = 4
		_Padding ("Padding", Float) = 0
	}
	// AssetRipper: the structure below is the shader's own - subshaders, passes, tags
	// and render state are read from the asset. The program stages are NOT the
	// shader's; each carries a replacement and the backends its real programs were
	// compiled to.
	SubShader {
		Tags { "DisableBatching" = "true" "QUEUE" = "Transparent+100" "RenderType" = "Transparent" }
		Pass {
			Name "Mask"
			Tags { "DisableBatching" = "true" "QUEUE" = "Transparent+100" "RenderType" = "Transparent" }
			Cull Off
			ZWrite Off
			ZTest Disabled
			ColorMask None
			Stencil {
				Ref 0
				ReadMask 2
				WriteMask 0
				Comp Always
				Pass Replace
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
		Pass {
			Name "See-through Mask"
			Tags { "DisableBatching" = "true" "QUEUE" = "Transparent+100" "RenderType" = "Transparent" }
			Cull Off
			ZWrite Off
			ColorMask None
			Stencil {
				Ref 0
				ReadMask 2
				WriteMask 0
				Comp Always
				Pass Replace
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