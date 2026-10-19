Shader "Sand/JellyDualColor" {
	Properties {
		_ColorA ("Color A  (Left)", Color) = (1,1,0,1)
		_ColorB ("Color B  (Right)", Color) = (1,0.5,0,1)
		_BlendWidth ("Blend Width", Range(0.001, 2)) = 0.3
		[Header(Shadow)] _ShadowColor ("Shadow Color", Color) = (0.1,0.1,0.15,1)
		_ShadowThreshold ("Shadow Threshold", Range(0, 1)) = 0.5
		_ShadowSmooth ("Shadow Smoothness", Range(0, 0.5)) = 0.05
		[Header(Specular)] _SpecColor2 ("Specular Color", Color) = (1,1,1,1)
		_SpecSize ("Specular Size", Range(0, 1)) = 0.25
		_SpecSmooth ("Specular Smoothness", Range(0, 0.5)) = 0.1
		_SpecStr ("Specular Strength", Range(0, 3)) = 1.5
		[Header(MatCap)] _MatCapTex ("MatCap Texture", 2D) = "black" {}
		_MatCapStr ("MatCap Strength", Range(0, 1)) = 0.4
	}
	// AssetRipper: the structure below is the shader's own - subshaders, passes, tags
	// and render state are read from the asset. The program stages are NOT the
	// shader's; each carries a replacement and the backends its real programs were
	// compiled to.
	SubShader {
		Tags { "QUEUE" = "Geometry" "RenderPipeline" = "UniversalPipeline" "RenderType" = "Opaque" }
		Pass {
			Name "ForwardLit"
			Tags { "LIGHTMODE" = "UniversalForward" "QUEUE" = "Geometry" "RenderPipeline" = "UniversalPipeline" "RenderType" = "Opaque" }
			ColorMask All
			// real programs: Vertex 4 variant(s) [MetalVS] blobs 2,3,4,5, Fragment 4 variant(s) [MetalFS] blobs 10,11,12,13
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
			Name "ShadowCaster"
			Tags { "LIGHTMODE" = "SHADOWCASTER" "QUEUE" = "Geometry" "RenderPipeline" = "UniversalPipeline" "RenderType" = "Opaque" }
			ColorMask None
			// real programs: Vertex 2 variant(s) [MetalVS] blobs 16,17, Fragment 2 variant(s) [MetalFS] blobs 19,20
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
			Name "DepthOnly"
			Tags { "LIGHTMODE" = "DepthOnly" "QUEUE" = "Geometry" "RenderPipeline" = "UniversalPipeline" "RenderType" = "Opaque" }
			ColorMask None
			// real programs: Vertex 2 variant(s) [MetalVS] blobs 23,24, Fragment 2 variant(s) [MetalFS] blobs 19,20
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
	Fallback "Hidden/Universal Render Pipeline/FallbackError"
}