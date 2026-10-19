Shader "Spine/SkeletonGraphic Multiply" {
	Properties {
		[PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
		[Toggle(_STRAIGHT_ALPHA_INPUT)] _StraightAlphaInput ("Straight Alpha Texture", Float) = 0
		[Toggle(_CANVAS_GROUP_COMPATIBLE)] _CanvasGroupCompatible ("CanvasGroup Compatible", Float) = 1
		_Color ("Tint", Color) = (1,1,1,1)
		[Enum(UnityEngine.Rendering.CompareFunction)] [HideInInspector] _StencilComp ("Stencil Comparison", Float) = 8
		[HideInInspector] _Stencil ("Stencil ID", Float) = 0
		[Enum(UnityEngine.Rendering.StencilOp)] [HideInInspector] _StencilOp ("Stencil Operation", Float) = 0
		[HideInInspector] _StencilWriteMask ("Stencil Write Mask", Float) = 255
		[HideInInspector] _StencilReadMask ("Stencil Read Mask", Float) = 255
		[HideInInspector] _ColorMask ("Color Mask", Float) = 15
		[Toggle(UNITY_UI_ALPHACLIP)] _UseUIAlphaClip ("Use Alpha Clip", Float) = 0
		[HideInInspector] _OutlineWidth ("Outline Width", Range(0, 8)) = 3
		[MaterialToggle(_USE_SCREENSPACE_OUTLINE_WIDTH)] [HideInInspector] _UseScreenSpaceOutlineWidth ("Width in Screen Space", Float) = 0
		[HideInInspector] _OutlineColor ("Outline Color", Color) = (1,1,0,1)
		[MaterialToggle(_OUTLINE_FILL_INSIDE)] [HideInInspector] _Fill ("Fill", Float) = 0
		[HideInInspector] _OutlineReferenceTexWidth ("Reference Texture Width", Float) = 1024
		[HideInInspector] _ThresholdEnd ("Outline Threshold", Range(0, 1)) = 0.25
		[HideInInspector] _OutlineSmoothness ("Outline Smoothness", Range(0, 1)) = 1
		[MaterialToggle(_USE8NEIGHBOURHOOD_ON)] [HideInInspector] _Use8Neighbourhood ("Sample 8 Neighbours", Float) = 1
		[HideInInspector] _OutlineOpaqueAlpha ("Opaque Alpha", Range(0, 1)) = 1
		[HideInInspector] _OutlineMipLevel ("Outline Mip Level", Range(0, 3)) = 0
	}
	// AssetRipper: the structure below is the shader's own - subshaders, passes, tags
	// and render state are read from the asset. The program stages are NOT the
	// shader's; each carries a replacement and the backends its real programs were
	// compiled to.
	SubShader {
		Tags { "CanUseSpriteAtlas" = "true" "IGNOREPROJECTOR" = "true" "PreviewType" = "Plane" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
		Pass {
			Name "Normal"
			Tags { "CanUseSpriteAtlas" = "true" "IGNOREPROJECTOR" = "true" "PreviewType" = "Plane" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
			Cull Off
			ZWrite Off
			ZTest Disabled
			Blend DstColor OneMinusSrcAlpha
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
			// real programs: Vertex 2 variant(s) [MetalVS] blobs 1,2, Fragment 2 variant(s) [MetalFS] blobs 4,5
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
	//CustomEditor "SpineShaderWithOutlineGUI"
}