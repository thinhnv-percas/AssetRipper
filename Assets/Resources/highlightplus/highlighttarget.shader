Shader "HighlightPlus/Geometry/Target" {
	Properties {
		_MainTex ("Texture", 2D) = "white" {}
		_Color ("Color", Color) = (1,1,1,1)
		_ZTest ("ZTest", Float) = 0
		_TargetFXFrameData ("Frame Data (Width, Length, ShowCornersOnly)", Vector) = (0.1,0.3,0,0)
		_TargetFXRenderData ("Render Data (Normal, FadePower, CustomAltitude)", Vector) = (0,1,0,0)
	}
	// AssetRipper: the structure below is the shader's own - subshaders, passes, tags
	// and render state are read from the asset. The program stages are NOT the
	// shader's; each carries a replacement and the backends its real programs were
	// compiled to.
	SubShader {
		Tags { "DisableBatching" = "true" "QUEUE" = "Transparent-1" "RenderType" = "Transparent" }
		Pass {
			Name "Target FX Decal"
			Tags { "DisableBatching" = "true" "QUEUE" = "Transparent-1" "RenderType" = "Transparent" }
			Cull Off
			ZWrite Off
			ZTest Disabled
			Blend SrcAlpha OneMinusSrcAlpha
			ColorMask All
			// real programs: Vertex 4 variant(s) [MetalVS] blobs 1,2,3,4, Fragment 4 variant(s) [MetalFS] blobs 7,8,9,10
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
			Name "Target FX"
			Tags { "DisableBatching" = "true" "QUEUE" = "Transparent-1" "RenderType" = "Transparent" }
			Cull Off
			ZWrite Off
			ZTest Disabled
			Blend SrcAlpha OneMinusSrcAlpha
			ColorMask All
			// real programs: Vertex 4 variant(s) [MetalVS] blobs 12,13,14,15, Fragment 4 variant(s) [MetalFS] blobs 18,19,20,21
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