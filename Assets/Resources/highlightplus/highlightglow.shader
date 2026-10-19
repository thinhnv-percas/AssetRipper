Shader "HighlightPlus/Geometry/Glow" {
	Properties {
		_MainTex ("Texture", any) = "white" {}
		_Glow2 ("Glow2", Vector) = (0.01,1,0.5,0)
		_Color ("Color", Color) = (1,1,1,1)
		_Cull ("Cull Mode", Float) = 2
		_ConstantWidth ("Constant Width", Float) = 1
		_MinimumWidth ("Minimum Width", Float) = 0
		_GlowZTest ("ZTest", Float) = 4
		_GlowStencilOp ("Stencil Operation", Float) = 0
		_CutOff ("CutOff", Float) = 0.5
		_GlowStencilComp ("Stencil Comp", Float) = 6
		_NoiseTex ("Noise Tex", 2D) = "white" {}
	}
	// AssetRipper: the structure below is the shader's own - subshaders, passes, tags
	// and render state are read from the asset. The program stages are NOT the
	// shader's; each carries a replacement and the backends its real programs were
	// compiled to.
	SubShader {
		Tags { "DisableBatching" = "true" "QUEUE" = "Transparent+102" "RenderType" = "Transparent" }
		Pass {
			Tags { "DisableBatching" = "true" "QUEUE" = "Transparent+102" "RenderType" = "Transparent" }
			Cull Off
			ZWrite Off
			ZTest Disabled
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
			// real programs: Vertex 8 variant(s) [MetalVS] blobs 2,3,4,5,6,7,8,9, Fragment 8 variant(s) [MetalFS] blobs 16,17,18,19,20,21,22,23
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