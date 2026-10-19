Shader "HighlightPlus/Geometry/ComposeGlow" {
	Properties {
		_MainTex ("Texture", any) = "black" {}
		_Color ("Color", Color) = (1,1,1,1)
		[HideInInspector] _Cull ("Cull Mode", Float) = 2
		[HideInInspector] _ZTest ("ZTest Mode", Float) = 0
		[HideInInspector] _Flip ("Flip", Vector) = (0,1,0,1)
		[HideInInspector] _BlendSrc ("Blend Src", Float) = 1
		[HideInInspector] _BlendDst ("Blend Dst", Float) = 1
		_Debug ("Debug Color", Color) = (0,0,0,0)
		[HideInInspector] _GlowStencilComp ("Stencil Comp", Float) = 6
		_Padding ("Padding", Float) = 0
		[HideInInspector] _Pixelation ("Pixelation", Float) = 0
	}
	// AssetRipper: the structure below is the shader's own - subshaders, passes, tags
	// and render state are read from the asset. The program stages are NOT the
	// shader's; each carries a replacement and the backends its real programs were
	// compiled to.
	SubShader {
		Tags { "DisableBatching" = "true" "QUEUE" = "Transparent+102" "RenderType" = "Transparent" }
		Pass {
			Name "Compose Glow"
			Tags { "DisableBatching" = "true" "QUEUE" = "Transparent+102" "RenderType" = "Transparent" }
			Cull Off
			ZWrite Off
			ZTest Always
			Blend Zero Zero
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
	}
}