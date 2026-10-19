Shader "Shader Graphs/sg_flames1" {
	Properties {
		_Displacement_Amount ("Displacement Amount", Float) = 0
		_Displacement_Speed ("Displacement Speed", Float) = 0
		[NoScaleOffset] _Flame_Texture ("Flame Texture", 2D) = "white" {}
		_Tiling ("Tiling", Vector) = (1,1,0,0)
		_Speed ("Speed", Vector) = (0,0,0,0)
		[Toggle(_ISMASK)] _ISMASK ("IsMask", Float) = 0
		[Toggle(_ISREVERSEMASK)] _ISREVERSEMASK ("IsReverseMask", Float) = 0
		[NoScaleOffset] _Mask_Texture ("Mask Texture", 2D) = "white" {}
		_Mask_Smoothness ("Mask Smoothness", Float) = 1
		_Mask_Offset ("Mask Offset", Vector) = (0,0,0,0)
		_Mask_Tiling ("Mask Tiling", Vector) = (1,1,0,0)
		[HDR] _Flame_Color ("Flame Color", Color) = (32,11.04314,1.756863,0)
		_Flame_Dark_Color ("Flame Dark Color", Color) = (1,0.4142864,0,0)
		_MasterTransparency ("MasterTransparency", Float) = 1
		[ToggleUI] _isColorReversed ("isColorReversed", Float) = 0
		_Cutoff_Smoothness ("Cutoff Smoothness", Float) = 3
		_Cutoff_Position ("Cutoff Position", Float) = 0
		_SmoothStep_Dark ("SmoothStep Dark", Float) = 0
		_SmoothStep ("SmoothStep", Float) = 0
		[ToggleUI] _isLocalCutoff ("isLocalCutoff", Float) = 0
		[KeywordEnum(X, Y, Z)] _LOCALCUTOFFAXIS ("LocalCutoffAxis", Float) = 0
		[ToggleUI] _isReverseCutoff ("isReverseCutoff", Float) = 0
		[ToggleUI] _isRotateUV ("isRotateUV", Float) = 0
		[ToggleUI] _IsRotateTexture ("IsRotateTexture", Float) = 0
		[ToggleUI] _isColorParticle ("isColorParticle", Float) = 0
		[ToggleUI] _isCutoffParticle ("isCutoffParticle", Float) = 0
		[ToggleUI] _isFresnel ("isFresnel", Float) = 0
		_FresnelSmoothness ("FresnelSmoothness", Float) = 100
		_FresnelAmount ("FresnelAmount", Float) = 10
		[Toggle(_ISDISPLACEMENT)] _ISDISPLACEMENT ("IsDisplacement", Float) = 0
		[HideInInspector] _CastShadows ("_CastShadows", Float) = 1
		[HideInInspector] _Surface ("_Surface", Float) = 1
		[HideInInspector] _Blend ("_Blend", Float) = 0
		[HideInInspector] _AlphaClip ("_AlphaClip", Float) = 0
		[HideInInspector] _SrcBlend ("_SrcBlend", Float) = 1
		[HideInInspector] _DstBlend ("_DstBlend", Float) = 0
		[HideInInspector] _SrcBlendAlpha ("_SrcBlendAlpha", Float) = 1
		[HideInInspector] _DstBlendAlpha ("_DstBlendAlpha", Float) = 0
		[ToggleUI] [HideInInspector] _ZWrite ("_ZWrite", Float) = 0
		[HideInInspector] _ZWriteControl ("_ZWriteControl", Float) = 0
		[HideInInspector] _ZTest ("_ZTest", Float) = 4
		[HideInInspector] _Cull ("_Cull", Float) = 0
		[HideInInspector] _AlphaToMask ("_AlphaToMask", Float) = 0
		[HideInInspector] _QueueOffset ("_QueueOffset", Float) = 0
		[HideInInspector] _QueueControl ("_QueueControl", Float) = -1
		[HideInInspector] [NoScaleOffset] unity_Lightmaps ("unity_Lightmaps", 2DArray) = "" {}
		[HideInInspector] [NoScaleOffset] unity_LightmapsInd ("unity_LightmapsInd", 2DArray) = "" {}
		[HideInInspector] [NoScaleOffset] unity_ShadowMasks ("unity_ShadowMasks", 2DArray) = "" {}
	}
	// AssetRipper: the structure below is the shader's own - subshaders, passes, tags
	// and render state are read from the asset. The program stages are NOT the
	// shader's; each carries a replacement and the backends its real programs were
	// compiled to.
	SubShader {
		Tags { "DisableBatching" = "False" "QUEUE" = "Transparent" "RenderPipeline" = "UniversalPipeline" "RenderType" = "Transparent" "ShaderGraphShader" = "true" "ShaderGraphTargetId" = "UniversalUnlitSubTarget" "UniversalMaterialType" = "Unlit" }
		Pass {
			Name "Universal Forward"
			Tags { "DisableBatching" = "False" "QUEUE" = "Transparent" "RenderPipeline" = "UniversalPipeline" "RenderType" = "Transparent" "ShaderGraphShader" = "true" "ShaderGraphTargetId" = "UniversalUnlitSubTarget" "UniversalMaterialType" = "Unlit" }
			Cull Off
			ZWrite Off
			ZTest Disabled
			Blend Zero Zero
			ColorMask All
			// real programs: Vertex 3 variant(s) [MetalVS] blobs 3,4,5, Fragment 6 variant(s) [MetalFS] blobs 12,13,14,15,16,17
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
			Tags { "DisableBatching" = "False" "LIGHTMODE" = "DepthOnly" "QUEUE" = "Transparent" "RenderPipeline" = "UniversalPipeline" "RenderType" = "Transparent" "ShaderGraphShader" = "true" "ShaderGraphTargetId" = "UniversalUnlitSubTarget" "UniversalMaterialType" = "Unlit" }
			Cull Off
			ColorMask Blue
			// real programs: Vertex 3 variant(s) [MetalVS] blobs 21,22,23, Fragment 3 variant(s) [MetalFS] blobs 25,26,27
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
			Name "MotionVectors"
			Tags { "DisableBatching" = "False" "LIGHTMODE" = "MOTIONVECTORS" "QUEUE" = "Transparent" "RenderPipeline" = "UniversalPipeline" "RenderType" = "Transparent" "ShaderGraphShader" = "true" "ShaderGraphTargetId" = "UniversalUnlitSubTarget" "UniversalMaterialType" = "Unlit" }
			Cull Off
			ColorMask Green, Blue
			// real programs: Vertex 3 variant(s) [MetalVS] blobs 31,32,33, Fragment 3 variant(s) [MetalFS] blobs 36,37,38
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
			Name "DepthNormalsOnly"
			Tags { "DisableBatching" = "False" "LIGHTMODE" = "DepthNormalsOnly" "QUEUE" = "Transparent" "RenderPipeline" = "UniversalPipeline" "RenderType" = "Transparent" "ShaderGraphShader" = "true" "ShaderGraphTargetId" = "UniversalUnlitSubTarget" "UniversalMaterialType" = "Unlit" }
			Cull Off
			ColorMask All
			// real programs: Vertex 3 variant(s) [MetalVS] blobs 3,39,5, Fragment 6 variant(s) [MetalFS] blobs 40,41,42,43,44,45
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
			Tags { "DisableBatching" = "False" "LIGHTMODE" = "SHADOWCASTER" "QUEUE" = "Transparent" "RenderPipeline" = "UniversalPipeline" "RenderType" = "Transparent" "ShaderGraphShader" = "true" "ShaderGraphTargetId" = "UniversalUnlitSubTarget" "UniversalMaterialType" = "Unlit" }
			Cull Off
			ColorMask None
			// real programs: Vertex 3 variant(s) [MetalVS] blobs 49,50,51, Fragment 3 variant(s) [MetalFS] blobs 52,53,54
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
	Fallback "Hidden/Shader Graph/FallbackError"
	//CustomEditor "UnityEditor.ShaderGraph.GenericShaderGraphMaterialGUI"
}