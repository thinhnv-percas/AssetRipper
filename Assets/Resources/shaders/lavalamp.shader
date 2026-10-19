Shader "UI/LavaLamp" {
	Properties {
		[PerRendererData] _MainTex ("Sprite (set by Image at runtime)", 2D) = "white" {}
		[KeywordEnum(Multiply, Color, Overlay, SoftLight)] _BlendMode ("Blob Blend Mode", Float) = 1
		[Toggle(_FORCE_TINT)] _ForceTint ("Force Tint at Full Strength", Float) = 1
		[Toggle(_USE_UNSCALED_TIME)] _UseUnscaledTime ("Use Unscaled Time", Float) = 0
		_Speed ("Speed", Range(0, 5)) = 1
		_BlobRadius ("Blob Radius", Range(0.05, 0.5)) = 0.18
		_Threshold ("Threshold", Range(0.2, 3)) = 0.8
		_Smoothness ("Edge Softness", Range(0, 0.5)) = 0.02
		[Toggle(_ASPECT_CORRECT)] _AspectCorrect ("Aspect Correct", Float) = 0
		_StencilComp ("Stencil Comparison", Float) = 8
		_Stencil ("Stencil ID", Float) = 0
		_StencilOp ("Stencil Operation", Float) = 0
		_StencilWriteMask ("Stencil Write Mask", Float) = 255
		_StencilReadMask ("Stencil Read Mask", Float) = 255
		_ColorMask ("Color Mask", Float) = 15
	}
	// AssetRipper: the structure below is the shader's own - subshaders, passes, tags
	// and render state are read from the asset. The program stages are NOT the
	// shader's; each carries a replacement and the backends its real programs were
	// compiled to.
	SubShader {
		Tags { "CanUseSpriteAtlas" = "true" "IGNOREPROJECTOR" = "true" "PreviewType" = "Plane" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
		Pass {
			Tags { "CanUseSpriteAtlas" = "true" "IGNOREPROJECTOR" = "true" "PreviewType" = "Plane" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
			Cull Off
			ZWrite Off
			ZTest Disabled
			Blend One OneMinusSrcAlpha
			ColorMask None
			Stencil {
				Ref 0
				ReadMask 0
				WriteMask 0
				Comp Disabled
				Pass Keep
				Fail Keep
				ZFail Keep
			}
			// real programs: Vertex 2 variant(s) [MetalVS] blobs 2,3, Fragment 2 variant(s) [MetalFS] blobs 5,6
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