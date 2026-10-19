Shader "SandOut/ConveyorFrame" {
	Properties {
		[Header(Colors)] [HDR] _CenterColor ("Center Color", Color) = (0.9,0.85,0.75,1)
		[HDR] _BandColor ("Band Color", Color) = (0.18,0.1,0.08,1)
		[HDR] _EdgeColor ("Edge Color", Color) = (0.02,0.01,0.01,1)
		[Header(Texture)] _BaseMap ("Base Texture", 2D) = "white" {}
		[Header(Gradient)] _GradientPower ("Power  (1=linear)", Range(0.1, 6)) = 1.5
		_GradientScale ("Scale", Range(0.1, 4)) = 1.2
		_GradientOffset ("Offset (- brighter)", Range(-1, 1)) = 0
		_BandPosition ("Band Position", Range(0.01, 0.99)) = 0.5
		_GradientSmooth ("Smooth  (0=linear  1=s-curve)", Range(0, 1)) = 0
		_ScreenCenter ("Screen Center", Vector) = (0.5,0.5,0,0)
		_AspectCorrect ("Aspect Correct", Range(0, 1)) = 1
		[Header(Rendering)] [Enum(UnityEngine.Rendering.CullMode)] _Cull ("Cull", Float) = 2
		[Toggle] _ZWrite ("ZWrite", Float) = 1
	}
	// AssetRipper: the structure below is the shader's own - subshaders, passes, tags
	// and render state are read from the asset. The program stages are NOT the
	// shader's; each carries a replacement and the backends its real programs were
	// compiled to.
	SubShader {
		Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Geometry" "RenderPipeline" = "UniversalPipeline" "RenderType" = "Opaque" }
		LOD 100
		Pass {
			Name "UniversalForward"
			Tags { "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "UniversalForward" "QUEUE" = "Geometry" "RenderPipeline" = "UniversalPipeline" "RenderType" = "Opaque" }
			Cull Off
			ZWrite Off
			ColorMask All
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
		Pass {
			Name "ShadowCaster"
			Tags { "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "SHADOWCASTER" "QUEUE" = "Geometry" "RenderPipeline" = "UniversalPipeline" "RenderType" = "Opaque" }
			Cull Off
			ColorMask None
			// real programs: Vertex 2 variant(s) [MetalVS] blobs 9,10, Fragment 2 variant(s) [MetalFS] blobs 12,13
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
			Tags { "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "DepthOnly" "QUEUE" = "Geometry" "RenderPipeline" = "UniversalPipeline" "RenderType" = "Opaque" }
			Cull Off
			ColorMask Blue
			// real programs: Vertex 2 variant(s) [MetalVS] blobs 16,17, Fragment 2 variant(s) [MetalFS] blobs 18,19
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
	Fallback "Universal Render Pipeline/Unlit"
}