Shader "HighlightPlus/Geometry/SeeThroughBorder" {
	Properties {
		_MainTex ("Texture", any) = "white" {}
		_SeeThroughBorderColor ("Outline Color", Color) = (0,0,0,1)
		_Color ("Color", Color) = (1,1,1,1)
		_CutOff ("CutOff", Float) = 0.5
		_SeeThroughBorderWidth ("Outline Offset", Float) = 0.01
		_SeeThroughBorderConstantWidth ("Constant Width", Float) = 1
		_SeeThroughStencilRef ("Stencil Ref", Float) = 2
		_SeeThroughStencilComp ("Stencil Comp", Float) = 5
		_SeeThroughDepthOffset ("Depth Offset", Float) = 0
		_SeeThroughMaxDepth ("Max Depth", Float) = 0
		_SeeThroughFadeRange ("Fade Range", Float) = 0
		_SeeThroughStencilPassOp ("Stencil Pass Operation", Float) = 0
		_Cull ("Cull Mode", Float) = 2
	}
	// AssetRipper: the structure below is the shader's own - subshaders, passes, tags
	// and render state are read from the asset. The program stages are NOT the
	// shader's; each carries a replacement and the backends its real programs were
	// compiled to.
	SubShader {
		Tags { "DisableBatching" = "true" "QUEUE" = "Transparent+201" "RenderType" = "Transparent" }
		Pass {
			Name "See-through border"
			Tags { "DisableBatching" = "true" "QUEUE" = "Transparent+201" "RenderType" = "Transparent" }
			Cull Off
			ZWrite Off
			ZTest Greater
			Blend SrcAlpha OneMinusSrcAlpha
			ColorMask All
			Stencil {
				Ref 0
				ReadMask 3
				WriteMask 3
				Comp Disabled
				Pass Keep
				Fail Keep
				ZFail Keep
			}
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
	}
}