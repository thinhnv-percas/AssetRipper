Shader "Spine/Blend Modes/Skeleton PMA Screen" {
	Properties {
		_Color ("Tint Color", Color) = (1,1,1,1)
		[NoScaleOffset] _MainTex ("MainTex", 2D) = "black" {}
		[Toggle(_STRAIGHT_ALPHA_INPUT)] _StraightAlphaInput ("Straight Alpha Texture", Float) = 0
		_Cutoff ("Shadow alpha cutoff", Range(0, 1)) = 0.1
		[HideInInspector] _StencilRef ("Stencil Reference", Float) = 1
		[Enum(UnityEngine.Rendering.CompareFunction)] [HideInInspector] _StencilComp ("Stencil Comparison", Float) = 8
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
		Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
		LOD 100
		Pass {
			Name "Normal"
			Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
			Cull Off
			ZWrite Off
			Blend One OneMinusSrcColor
			ColorMask All
			Stencil {
				Ref 0
				Comp Disabled
				Pass Keep
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
		Pass {
			Name "Caster"
			Tags { "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "SHADOWCASTER" "QUEUE" = "Transparent" "RenderType" = "Transparent" "SHADOWSUPPORT" = "true" }
			Cull Off
			Blend One OneMinusSrcColor
			ColorMask All
			Offset 1, 1
			Stencil {
				Ref 0
				Comp Disabled
				Pass Keep
				Fail Keep
				ZFail Keep
			}
			// real programs: Vertex 2 variant(s) [MetalVS] blobs 5,6, Fragment 2 variant(s) [MetalFS] blobs 8,9
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