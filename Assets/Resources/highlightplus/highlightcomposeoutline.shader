Shader "HighlightPlus/Geometry/ComposeOutline" {
	Properties {
		_MainTex ("Texture", any) = "black" {}
		_Color ("Color", Color) = (1,1,1,1)
		_Cull ("Cull Mode", Float) = 2
		_ZTest ("ZTest Mode", Float) = 0
		_Flip ("Flip", Vector) = (0,1,0,1)
		_Debug ("Debug Color", Color) = (0,0,0,0)
		_OutlineStencilComp ("Stencil Comp", Float) = 6
		_OutlineSharpness ("Outline Sharpness", Float) = 1
		_PatternTex ("Pattern Texture", 2D) = "black" {}
		_PatternData ("Pattern Data", Vector) = (1,0.5,0.1,0)
		_DistortionTex ("Distortion Texture", 2D) = "white" {}
		_DashData ("Dash Data", Vector) = (0.1,0.1,1,0.1)
		_OutlineGradientTex ("Outline Gradient Texture", 2D) = "white" {}
		_OutlineGradientData ("Outline Gradient Data", Vector) = (0.5,1,0,0)
		_Padding ("Padding", Float) = 0
		_Pixelation ("Pixelation", Float) = 0
	}
	// AssetRipper: the structure below is the shader's own - subshaders, passes, tags
	// and render state are read from the asset. The program stages are NOT the
	// shader's; each carries a replacement and the backends its real programs were
	// compiled to.
	SubShader {
		Tags { "DisableBatching" = "true" "QUEUE" = "Transparent+120" "RenderType" = "Transparent" }
		Pass {
			Name "Composte Outline"
			Tags { "DisableBatching" = "true" "QUEUE" = "Transparent+120" "RenderType" = "Transparent" }
			Cull Off
			ZWrite Off
			ZTest Always
			Blend SrcAlpha OneMinusSrcAlpha
			ColorMask All
			Stencil {
				Ref 2
				ReadMask 2
				WriteMask 2
				Comp Disabled
				Pass Keep
				Fail Keep
				ZFail Keep
			}
			// real programs: Vertex 32 variant(s) [MetalVS] blobs 1,2,3,4,5,6,7,8, Fragment 32 variant(s) [MetalFS] blobs 49,50,51,52,53,54,55,56
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