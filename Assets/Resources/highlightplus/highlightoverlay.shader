Shader "HighlightPlus/Geometry/Overlay" {
	Properties {
		_MainTex ("Texture", any) = "white" {}
		_Color ("Color", Color) = (1,1,1,1)
		_OverlayColor ("Overlay Color", Color) = (1,1,1,1)
		_OverlayBackColor ("Overlay Back Color", Color) = (1,1,1,1)
		_OverlayData ("Overlay Data", Vector) = (1,0.5,1,1)
		_OverlayHitPosData ("Overlay Hit Pos Data", Vector) = (0,0,0,0)
		_OverlayHitStartTime ("Overlay Hit Start Time", Float) = 0
		_OverlayTexture ("Overlay Texture", 2D) = "white" {}
		_CutOff ("CutOff", Float) = 0.5
		_Cull ("Cull Mode", Float) = 2
		_OverlayZTest ("ZTest", Float) = 4
		_OverlayPatternScrolling ("Pattern Scrolling", Vector) = (0,0,0,0)
		_OverlayPatternData ("Pattern Data", Vector) = (0,0,0,0)
	}
	// AssetRipper: the structure below is the shader's own - subshaders, passes, tags
	// and render state are read from the asset. The program stages are NOT the
	// shader's; each carries a replacement and the backends its real programs were
	// compiled to.
	SubShader {
		Tags { "DisableBatching" = "true" "QUEUE" = "Transparent+121" "RenderType" = "Transparent" }
		Pass {
			Name "Overlay"
			Tags { "DisableBatching" = "true" "QUEUE" = "Transparent+121" "RenderType" = "Transparent" }
			Cull Off
			ZWrite Off
			ZTest Disabled
			Blend SrcAlpha OneMinusSrcAlpha
			ColorMask All
			Offset -1, -1
			Stencil {
				Ref 4
				ReadMask 4
				Comp NotEqual
				Pass Keep
				Fail Keep
				ZFail Keep
			}
			// real programs: Vertex 40 variant(s) [MetalVS] blobs 3,4,5,6,7,8,9,10, Fragment 40 variant(s) [MetalFS] blobs 49,50,51,52,53,54,55,56
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