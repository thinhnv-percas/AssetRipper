using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;

namespace HighlightPlus
{
	[ExecuteAlways]
	[HelpURL("https://kronnect.com/docs/highlight-plus/")]
	[Token(Token = "0x2000022")]
	public class HighlightEffect : MonoBehaviour
	{
		[Token(Token = "0x2000023")]
		private struct ModelMaterials
		{
			[Token(Token = "0x40001C1")]
			[FieldOffset(Offset = "0x0")]
			public bool render;

			[Token(Token = "0x40001C2")]
			[FieldOffset(Offset = "0x8")]
			public Transform transform;

			[Token(Token = "0x40001C3")]
			[FieldOffset(Offset = "0x10")]
			public bool renderWasVisibleDuringSetup;

			[Token(Token = "0x40001C4")]
			[FieldOffset(Offset = "0x18")]
			public Mesh mesh;

			[Token(Token = "0x40001C5")]
			[FieldOffset(Offset = "0x20")]
			public Mesh originalMesh;

			[Token(Token = "0x40001C6")]
			[FieldOffset(Offset = "0x28")]
			public Mesh bakedSkinnedMesh;

			[Token(Token = "0x40001C7")]
			[FieldOffset(Offset = "0x30")]
			public Renderer renderer;

			[Token(Token = "0x40001C8")]
			[FieldOffset(Offset = "0x38")]
			public bool isSkinnedMesh;

			[Token(Token = "0x40001C9")]
			[FieldOffset(Offset = "0x39")]
			public bool isParticleSystem;

			[Token(Token = "0x40001CA")]
			[FieldOffset(Offset = "0x3C")]
			public int subMeshCount;

			[Token(Token = "0x40001CB")]
			[FieldOffset(Offset = "0x40")]
			public NormalsOption normalsOption;

			[Token(Token = "0x40001CC")]
			[FieldOffset(Offset = "0x48")]
			public Material[] fxMatMask;

			[Token(Token = "0x40001CD")]
			[FieldOffset(Offset = "0x50")]
			public Material[] fxMatOutline;

			[Token(Token = "0x40001CE")]
			[FieldOffset(Offset = "0x58")]
			public Material[] fxMatGlow;

			[Token(Token = "0x40001CF")]
			[FieldOffset(Offset = "0x60")]
			public Material[] fxMatSolidColor;

			[Token(Token = "0x40001D0")]
			[FieldOffset(Offset = "0x68")]
			public Material[] fxMatSeeThroughInner;

			[Token(Token = "0x40001D1")]
			[FieldOffset(Offset = "0x70")]
			public Material[] fxMatSeeThroughBorder;

			[Token(Token = "0x40001D2")]
			[FieldOffset(Offset = "0x78")]
			public Material[] fxMatOverlay;

			[Token(Token = "0x40001D3")]
			[FieldOffset(Offset = "0x80")]
			public Material[] fxMatInnerGlow;

			[Token(Token = "0x40001D4")]
			[FieldOffset(Offset = "0x88")]
			public Matrix4x4 renderingMatrix;

			[Token(Token = "0x40001D5")]
			[FieldOffset(Offset = "0xC8")]
			public int[] customPassIds;

			[Token(Token = "0x40001D6")]
			[FieldOffset(Offset = "0xD0")]
			public bool isCombined;

			[Token(Token = "0x17000006")]
			public bool preserveOriginalMesh
			{
				[Token(Token = "0x6000093")]
				[Address(RVA = "0x772578C", Offset = "0x772578C", Length = "0x20")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = this.isCombined == 0;\n\tif (v3) goto L_0009;\n\treturn 0;\nL_0009:\n\tv8 = this.normalsOption - 1;\n\tv10 = v8 == 0;\n\treturn v10;\n")]
				get
				{
					if (isCombined)
					{
						return false;
					}
					int num = (int)(normalsOption - 1);
					return num == 0;
				}
			}

			[Token(Token = "0x6000094")]
			[Address(RVA = "0x77257AC", Offset = "0x77257AC", Length = "0x10C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tgoto L_002F;\nL_002F:\n\tv64 = UnityEngine.Object::op_Inequality(this.bakedSkinnedMesh, 0);\n\tv66 = ~v64;\n\tv67 = ~v66;\n\tif (v67) goto L_0040;\n\tgoto L_0047;\nL_0040:\n\tgoto L_0044;\nL_0044:\n\tUnityEngine.Object::DestroyImmediate(this.bakedSkinnedMesh);\nL_0047:\n\tthis.renderer = 0;\n\tthis.customPassIds = 0;\n\tthis.isSkinnedMesh = 0;\n\tthis.subMeshCount = 0;\n\tthis.isCombined = 0;\n\treturn;\nL_0016:\n\tthis.render = 0;\n\tthis.transform = 0;\n\tthis.originalMesh = 0;\n\tthis.mesh = 0;\n")]
			public void Init()
			{
				render = false;
				transform = null;
				originalMesh = null;
				mesh = null;
				if (bakedSkinnedMesh != null)
				{
					UnityEngine.Object.DestroyImmediate(bakedSkinnedMesh);
				}
				renderer = null;
				customPassIds = null;
				isSkinnedMesh = false;
				isParticleSystem = false;
				subMeshCount = 0;
				isCombined = false;
			}
		}

		[Token(Token = "0x2000024")]
		public enum FadingState
		{
			[Token(Token = "0x40001D8")]
			FadingOut = -1,
			[Token(Token = "0x40001D9")]
			NoFading = 0,
			[Token(Token = "0x40001DA")]
			FadingIn = 1
		}

		[Token(Token = "0x2000025")]
		private class PerCameraOcclusionData
		{
			[Token(Token = "0x40001DB")]
			[FieldOffset(Offset = "0x10")]
			public float checkLastTime = -10000f;

			[Token(Token = "0x40001DC")]
			[FieldOffset(Offset = "0x14")]
			public int occlusionRenderFrame;

			[Token(Token = "0x40001DD")]
			[FieldOffset(Offset = "0x18")]
			public bool lastOcclusionTestResult;

			[Token(Token = "0x40001DE")]
			[FieldOffset(Offset = "0x20")]
			public readonly List<Renderer> cachedOccluders;

			[Token(Token = "0x40001DF")]
			[FieldOffset(Offset = "0x28")]
			public Collider cachedOccluderCollider;

			[Token(Token = "0x6000095")]
			[Address(RVA = "0x77258B8", Offset = "0x77258B8", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001D:\n\tthis.checkLastTime = -10000f;\n\tv50 = new System.Collections.Generic.List`1<UnityEngine.Renderer>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Renderer>::.ctor(v50);\n\tthis.cachedOccluders = v50;\n")]
			public PerCameraOcclusionData()
			{
				List<Renderer> list = new List<Renderer>();
				cachedOccluders = list;
			}
		}

		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000026")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40001E0")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40001E1")]
			public static Predicate<HighlightEffect> _003C_003E9__347_0;

			[Token(Token = "0x6000096")]
			[Address(RVA = "0x7725950", Offset = "0x7725950", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new HighlightPlus.HighlightEffect+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000097")]
			[Address(RVA = "0x77259B4", Offset = "0x77259B4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal bool _003CDomainReloadDisabledSupport_003Eb__347_0(HighlightEffect i)
			{
				return i == null;
			}
		}

		[Tooltip("The current profile (optional). A profile let you store Highlight Plus settings and apply those settings easily to many objects. You can also load a profile and apply its settings at runtime, using the ProfileLoad() method of the Highlight Effect component.")]
		[Token(Token = "0x400005E")]
		[FieldOffset(Offset = "0x20")]
		public HighlightProfile profile;

		[Tooltip("If enabled, settings from the profile will be applied to this component automatically when game starts or when any profile setting is updated.")]
		[Token(Token = "0x400005F")]
		[FieldOffset(Offset = "0x28")]
		public bool profileSync;

		[Tooltip("Which cameras can render the effect.")]
		[Token(Token = "0x4000060")]
		[FieldOffset(Offset = "0x2C")]
		public LayerMask camerasLayerMask;

		[Tooltip("Different options to specify which objects are affected by this Highlight Effect component.")]
		[Token(Token = "0x4000061")]
		[FieldOffset(Offset = "0x30")]
		public TargetOptions effectGroup;

		[Tooltip("The target object to highlight.")]
		[Token(Token = "0x4000062")]
		[FieldOffset(Offset = "0x38")]
		public Transform effectTarget;

		[Tooltip("The layer that contains the affected objects by this effect when effectGroup is set to LayerMask.")]
		[Token(Token = "0x4000063")]
		[FieldOffset(Offset = "0x40")]
		public LayerMask effectGroupLayer;

		[Tooltip("Only include objects whose names contains this text.")]
		[Token(Token = "0x4000064")]
		[FieldOffset(Offset = "0x48")]
		public string effectNameFilter;

		[Tooltip("Use RegEx to determine if an object name matches the effectNameFilter.")]
		[Token(Token = "0x4000065")]
		[FieldOffset(Offset = "0x50")]
		public bool effectNameUseRegEx;

		[Tooltip("Exclude objects that already have a Highlight Effect component when using Include options.")]
		[Token(Token = "0x4000066")]
		[FieldOffset(Offset = "0x51")]
		public bool excludeObjectsWithHighlightEffect;

		[Tooltip("Combine meshes of all objects in this group affected by Highlight Effect reducing draw calls.")]
		[Token(Token = "0x4000067")]
		[FieldOffset(Offset = "0x52")]
		public bool combineMeshes;

		[Tooltip("The alpha threshold for transparent cutout objects. Pixels with alpha below this value will be discarded.")]
		[Range(0f, 1f)]
		[Token(Token = "0x4000068")]
		[FieldOffset(Offset = "0x54")]
		public float alphaCutOff;

		[Tooltip("Optional custom texture property name used for alpha clipping; if not found, falls back to _BaseMap or _MainTex.")]
		[Token(Token = "0x4000069")]
		[FieldOffset(Offset = "0x58")]
		public string alphaCutOffTextureName;

		[Tooltip("If back facing triangles are ignored.Backfaces triangles are not visible but you may set this property to false to force highlight effects to act on those triangles as well.")]
		[Token(Token = "0x400006A")]
		[FieldOffset(Offset = "0x60")]
		public bool cullBackFaces;

		[Tooltip("Show highlight effects even if the object is not visible. If this object or its children use GPU Instancing tools, the MeshRenderer can be disabled although the object is visible. In this case, this option is useful to enable highlighting.")]
		[Token(Token = "0x400006B")]
		[FieldOffset(Offset = "0x61")]
		public bool ignoreObjectVisibility;

		[Tooltip("Support reflection probes. Enable only if you want the effects to be visible in reflections.")]
		[Token(Token = "0x400006C")]
		[FieldOffset(Offset = "0x62")]
		public bool reflectionProbes;

		[Tooltip("Enables GPU instancing. Reduces draw calls in outline and outer glow effects on platforms that support GPU instancing. Should be enabled by default.")]
		[Token(Token = "0x400006D")]
		[FieldOffset(Offset = "0x63")]
		public bool GPUInstancing;

		[Tooltip("Custom sorting priority for the highlight effect (useful to control which effects render on top of others")]
		[Token(Token = "0x400006E")]
		[FieldOffset(Offset = "0x64")]
		public int sortingPriority;

		[Tooltip("Bakes skinned mesh to leverage GPU instancing when using outline/outer glow with mesh-based rendering. Reduces draw calls significantly on skinned meshes.")]
		[Token(Token = "0x400006F")]
		[FieldOffset(Offset = "0x68")]
		public bool optimizeSkinnedMesh;

		[Tooltip("Enables depth buffer clipping. Only applies to outline or outer glow in High Quality mode.")]
		[Token(Token = "0x4000070")]
		[FieldOffset(Offset = "0x69")]
		public bool depthClip;

		[Tooltip("Fades out effects based on distance to camera")]
		[Token(Token = "0x4000071")]
		[FieldOffset(Offset = "0x6A")]
		public bool cameraDistanceFade;

		[Tooltip("The closest distance particles can get to the camera before they fade from the camera's view.")]
		[Token(Token = "0x4000072")]
		[FieldOffset(Offset = "0x6C")]
		public float cameraDistanceFadeNear;

		[Tooltip("The farthest distance particles can get away from the camera before they fade from the camera's view.")]
		[Token(Token = "0x4000073")]
		[FieldOffset(Offset = "0x70")]
		public float cameraDistanceFadeFar;

		[Tooltip("If enabled, the highlight effect will use a pass from the original object's shader to render the silhouette.")]
		[Token(Token = "0x4000074")]
		[FieldOffset(Offset = "0x74")]
		public bool useOriginalShader;

		[Tooltip("The pass name from the original shader to use for rendering the silhouette.")]
		[Token(Token = "0x4000075")]
		[FieldOffset(Offset = "0x78")]
		public string customPassName;

		[Tooltip("Normals handling option:\nPreserve original: use original mesh normals.\nSmooth: average normals to produce a smoother outline/glow mesh based effect.\nReorient: recomputes normals based on vertex direction to centroid.")]
		[Token(Token = "0x4000076")]
		[FieldOffset(Offset = "0x80")]
		public NormalsOption normalsOption;

		[Tooltip("Ignore highlighting on this object.")]
		[Token(Token = "0x4000077")]
		[FieldOffset(Offset = "0x84")]
		public bool ignore;

		[SerializeField]
		[Token(Token = "0x4000078")]
		[FieldOffset(Offset = "0x85")]
		private bool _highlighted;

		[Token(Token = "0x4000079")]
		[FieldOffset(Offset = "0x88")]
		public float fadeInDuration;

		[Token(Token = "0x400007A")]
		[FieldOffset(Offset = "0x8C")]
		public float fadeOutDuration;

		[Token(Token = "0x400007B")]
		[FieldOffset(Offset = "0x90")]
		public bool flipY;

		[Tooltip("Keeps the outline/glow size unaffected by object distance.")]
		[Token(Token = "0x400007C")]
		[FieldOffset(Offset = "0x91")]
		public bool constantWidth;

		[Tooltip("Increases the screen coverage for the outline/glow to avoid cuts when using cloth or vertex shader that transform mesh vertices")]
		[Token(Token = "0x400007D")]
		[FieldOffset(Offset = "0x94")]
		public int extraCoveragePixels;

		[Tooltip("Minimum width when the constant width option is not used")]
		[Range(0f, 1f)]
		[Token(Token = "0x400007E")]
		[FieldOffset(Offset = "0x98")]
		public float minimumWidth;

		[Tooltip("Mask to include or exclude certain submeshes. By default, all submeshes are included.")]
		[Token(Token = "0x400007F")]
		[FieldOffset(Offset = "0x9C")]
		public int subMeshMask;

		[Tooltip("Selects which custom vertex transformation to use in CustomVertexTransform.cginc (0 = default).")]
		[Token(Token = "0x4000080")]
		[FieldOffset(Offset = "0xA0")]
		public int vertexTransformMode;

		[Range(0f, 1f)]
		[Tooltip("Intensity of the overlay effect. A value of 0 disables the overlay completely.")]
		[Token(Token = "0x4000081")]
		[FieldOffset(Offset = "0xA4")]
		public float overlay;

		[Token(Token = "0x4000082")]
		[FieldOffset(Offset = "0xA8")]
		public OverlayMode overlayMode;

		[Token(Token = "0x4000083")]
		[FieldOffset(Offset = "0xAC")]
		public OverlayPattern overlayPattern;

		[Token(Token = "0x4000084")]
		[FieldOffset(Offset = "0xB0")]
		public Vector2 overlayPatternScrolling;

		[ColorUsage(false, true)]
		[Token(Token = "0x4000085")]
		[FieldOffset(Offset = "0xB8")]
		public Color overlayColor;

		[Token(Token = "0x4000086")]
		[FieldOffset(Offset = "0xC8")]
		public float overlayAnimationSpeed;

		[Range(0f, 1f)]
		[Token(Token = "0x4000087")]
		[FieldOffset(Offset = "0xCC")]
		public float overlayMinIntensity;

		[Range(0f, 1f)]
		[Tooltip("Controls the blending or mix of the overlay color with the natural colors of the object.")]
		[Token(Token = "0x4000088")]
		[FieldOffset(Offset = "0xD0")]
		public float overlayBlending;

		[Tooltip("Optional overlay texture.")]
		[Token(Token = "0x4000089")]
		[FieldOffset(Offset = "0xD8")]
		public Texture2D overlayTexture;

		[Token(Token = "0x400008A")]
		[FieldOffset(Offset = "0xE0")]
		public TextureUVSpace overlayTextureUVSpace;

		[Token(Token = "0x400008B")]
		[FieldOffset(Offset = "0xE4")]
		public float overlayTextureScale;

		[Token(Token = "0x400008C")]
		[FieldOffset(Offset = "0xE8")]
		public Vector2 overlayTextureScrolling;

		[Token(Token = "0x400008D")]
		[FieldOffset(Offset = "0xF0")]
		public Visibility overlayVisibility;

		[Tooltip("Scale of the overlay pattern")]
		[Range(1f, 100f)]
		[Token(Token = "0x400008E")]
		[FieldOffset(Offset = "0xF4")]
		public float overlayPatternScale;

		[Tooltip("Size/Thickness of the overlay pattern")]
		[Range(0.01f, 1f)]
		[Token(Token = "0x400008F")]
		[FieldOffset(Offset = "0xF8")]
		public float overlayPatternSize;

		[Tooltip("Softness of the overlay pattern")]
		[Range(0.01f, 0.5f)]
		[Token(Token = "0x4000090")]
		[FieldOffset(Offset = "0xFC")]
		public float overlayPatternSoftness;

		[Tooltip("Rotation angle for the overlay pattern in degrees")]
		[Range(-180f, 180f)]
		[Token(Token = "0x4000091")]
		[FieldOffset(Offset = "0x100")]
		public float overlayPatternRotation;

		[Range(0f, 1f)]
		[Tooltip("Intensity of the outline. A value of 0 disables the outline completely.")]
		[Token(Token = "0x4000092")]
		[FieldOffset(Offset = "0x104")]
		public float outline;

		[ColorUsage(true, true)]
		[Token(Token = "0x4000093")]
		[FieldOffset(Offset = "0x108")]
		public Color outlineColor;

		[Token(Token = "0x4000094")]
		[FieldOffset(Offset = "0x118")]
		public ColorStyle outlineColorStyle;

		[GradientUsage(true, ColorSpace.Linear)]
		[Token(Token = "0x4000095")]
		[FieldOffset(Offset = "0x120")]
		public Gradient outlineGradient;

		[Token(Token = "0x4000096")]
		[FieldOffset(Offset = "0x128")]
		public bool outlineGradientInLocalSpace;

		[Token(Token = "0x4000097")]
		[FieldOffset(Offset = "0x12C")]
		public float outlineWidth;

		[Range(1f, 3f)]
		[Token(Token = "0x4000098")]
		[FieldOffset(Offset = "0x130")]
		public int outlineBlurPasses;

		[Token(Token = "0x4000099")]
		[FieldOffset(Offset = "0x134")]
		public QualityLevel outlineQuality;

		[Token(Token = "0x400009A")]
		[FieldOffset(Offset = "0x138")]
		public OutlineEdgeMode outlineEdgeMode;

		[Token(Token = "0x400009B")]
		[FieldOffset(Offset = "0x13C")]
		public float outlineEdgeThreshold;

		[Tooltip("Controls how quickly the outline effect scales down with distance when constant width is disabled. Lower values make the effect fade faster with distance.")]
		[Token(Token = "0x400009C")]
		[FieldOffset(Offset = "0x140")]
		public float outlineDistanceScaleBias;

		[Token(Token = "0x400009D")]
		[FieldOffset(Offset = "0x144")]
		public float outlineSharpness;

		[Range(1f, 8f)]
		[Tooltip("Reduces the quality of the outline but improves performance a bit.")]
		[Token(Token = "0x400009E")]
		[FieldOffset(Offset = "0x148")]
		public int outlineDownsampling;

		[Token(Token = "0x400009F")]
		[FieldOffset(Offset = "0x14C")]
		public Visibility outlineVisibility;

		[Token(Token = "0x40000A0")]
		[FieldOffset(Offset = "0x150")]
		public GlowBlendMode glowBlendMode;

		[Token(Token = "0x40000A1")]
		[FieldOffset(Offset = "0x154")]
		public bool outlineBlitDebug;

		[Tooltip("If enabled, this object won't combine the outline with other objects.")]
		[Token(Token = "0x40000A2")]
		[FieldOffset(Offset = "0x155")]
		public bool outlineIndependent;

		[Token(Token = "0x40000A3")]
		[FieldOffset(Offset = "0x158")]
		public ContourStyle outlineContourStyle;

		[Tooltip("Select the mask mode used with this effect.")]
		[Token(Token = "0x40000A4")]
		[FieldOffset(Offset = "0x15C")]
		public MaskMode outlineMaskMode;

		[Token(Token = "0x40000A5")]
		[FieldOffset(Offset = "0x160")]
		public float outlineGradientKnee;

		[Token(Token = "0x40000A6")]
		[FieldOffset(Offset = "0x164")]
		public float outlineGradientPower;

		[Tooltip("Adds a empty margin between the outline mesh and the effects")]
		[Range(0f, 1f)]
		[Token(Token = "0x40000A7")]
		[FieldOffset(Offset = "0x168")]
		public float padding;

		[Tooltip("Makes the outline pixelated. A value of 0 disables pixelation. Higher values produce bigger pixels.")]
		[Range(0f, 32f)]
		[Token(Token = "0x40000A8")]
		[FieldOffset(Offset = "0x16C")]
		public int outlinePixelation;

		[Tooltip("Enables stylized outline effect.")]
		[Token(Token = "0x40000A9")]
		[FieldOffset(Offset = "0x170")]
		public bool outlineStylized;

		[Tooltip("Pattern texture used for the stylized outline effect.")]
		[Token(Token = "0x40000AA")]
		[FieldOffset(Offset = "0x178")]
		public Texture2D outlinePattern;

		[Tooltip("Scale of the pattern texture.")]
		[Token(Token = "0x40000AB")]
		[FieldOffset(Offset = "0x180")]
		public float outlinePatternScale;

		[Tooltip("Threshold for the pattern texture.")]
		[Range(0f, 1f)]
		[Token(Token = "0x40000AC")]
		[FieldOffset(Offset = "0x184")]
		public float outlinePatternThreshold;

		[Tooltip("Distortion amount for the pattern texture.")]
		[Range(0f, 1.5f)]
		[Token(Token = "0x40000AD")]
		[FieldOffset(Offset = "0x188")]
		public float outlinePatternDistortionAmount;

		[Tooltip("Pattern texture used for the distortion effect.")]
		[Token(Token = "0x40000AE")]
		[FieldOffset(Offset = "0x190")]
		public Texture2D outlinePatternDistortionTexture;

		[Tooltip("Stop motion scale for the distortion effect.")]
		[Token(Token = "0x40000AF")]
		[FieldOffset(Offset = "0x198")]
		public float outlinePatternStopMotionScale;

		[Tooltip("Enables dashed outline effect.")]
		[Token(Token = "0x40000B0")]
		[FieldOffset(Offset = "0x19C")]
		public bool outlineDashed;

		[Tooltip("Width of the dashed outline.")]
		[Range(0f, 1f)]
		[Token(Token = "0x40000B1")]
		[FieldOffset(Offset = "0x1A0")]
		public float outlineDashWidth;

		[Tooltip("Gap of the dashed outline.")]
		[Range(0f, 1f)]
		[Token(Token = "0x40000B2")]
		[FieldOffset(Offset = "0x1A4")]
		public float outlineDashGap;

		[Tooltip("Speed of the dashed outline.")]
		[Token(Token = "0x40000B3")]
		[FieldOffset(Offset = "0x1A8")]
		public float outlineDashSpeed;

		[Range(0f, 5f)]
		[Tooltip("The intensity of the outer glow effect. A value of 0 disables the glow completely.")]
		[Token(Token = "0x40000B4")]
		[FieldOffset(Offset = "0x1AC")]
		public float glow;

		[Token(Token = "0x40000B5")]
		[FieldOffset(Offset = "0x1B0")]
		public float glowWidth;

		[Token(Token = "0x40000B6")]
		[FieldOffset(Offset = "0x1B4")]
		public QualityLevel glowQuality;

		[Token(Token = "0x40000B7")]
		[FieldOffset(Offset = "0x1B8")]
		public BlurMethod glowBlurMethod;

		[Token(Token = "0x40000B8")]
		[FieldOffset(Offset = "0x1BC")]
		public bool glowHighPrecision;

		[Tooltip("Controls how quickly the glow effect scales down with distance when constant width is disabled. Lower values make the effect fade faster with distance.")]
		[Token(Token = "0x40000B9")]
		[FieldOffset(Offset = "0x1C0")]
		public float glowDistanceScaleBias;

		[Range(1f, 8f)]
		[Tooltip("Reduces the quality of the glow but improves performance a bit.")]
		[Token(Token = "0x40000BA")]
		[FieldOffset(Offset = "0x1C4")]
		public int glowDownsampling;

		[ColorUsage(true, true)]
		[Token(Token = "0x40000BB")]
		[FieldOffset(Offset = "0x1C8")]
		public Color glowHQColor;

		[Tooltip("When enabled, outer glow renders with dithering. When disabled, glow appears as a solid color.")]
		[Range(0f, 1f)]
		[Token(Token = "0x40000BC")]
		[FieldOffset(Offset = "0x1D8")]
		public float glowDithering;

		[Token(Token = "0x40000BD")]
		[FieldOffset(Offset = "0x1DC")]
		public GlowDitheringStyle glowDitheringStyle;

		[Tooltip("Seed for the dithering effect")]
		[Token(Token = "0x40000BE")]
		[FieldOffset(Offset = "0x1E0")]
		public float glowMagicNumber1;

		[Tooltip("Another seed for the dithering effect that combines with first seed to create different patterns")]
		[Token(Token = "0x40000BF")]
		[FieldOffset(Offset = "0x1E4")]
		public float glowMagicNumber2;

		[Token(Token = "0x40000C0")]
		[FieldOffset(Offset = "0x1E8")]
		public float glowAnimationSpeed;

		[Token(Token = "0x40000C1")]
		[FieldOffset(Offset = "0x1EC")]
		public Visibility glowVisibility;

		[Token(Token = "0x40000C2")]
		[FieldOffset(Offset = "0x1F0")]
		public bool glowBlitDebug;

		[Tooltip("Blends glow passes one after another. If this option is disabled, glow passes won't overlap (in this case, make sure the glow pass 1 has a smaller offset than pass 2, etc.)")]
		[Token(Token = "0x40000C3")]
		[FieldOffset(Offset = "0x1F1")]
		public bool glowBlendPasses;

		[NonReorderable]
		[Token(Token = "0x40000C4")]
		[FieldOffset(Offset = "0x1F8")]
		public GlowPassData[] glowPasses;

		[Tooltip("Select the mask mode used with this effect.")]
		[Token(Token = "0x40000C5")]
		[FieldOffset(Offset = "0x200")]
		public MaskMode glowMaskMode;

		[Tooltip("Makes the glow pixelated. A value of 0 disables pixelation. Higher values produce bigger pixels.")]
		[Range(0f, 32f)]
		[Token(Token = "0x40000C6")]
		[FieldOffset(Offset = "0x204")]
		public int glowPixelation;

		[Range(0f, 5f)]
		[Tooltip("The intensity of the inner glow effect. A value of 0 disables the glow completely.")]
		[Token(Token = "0x40000C7")]
		[FieldOffset(Offset = "0x208")]
		public float innerGlow;

		[Range(0f, 2f)]
		[Token(Token = "0x40000C8")]
		[FieldOffset(Offset = "0x20C")]
		public float innerGlowWidth;

		[Token(Token = "0x40000C9")]
		[FieldOffset(Offset = "0x210")]
		public float innerGlowPower;

		[ColorUsage(true, true)]
		[Token(Token = "0x40000CA")]
		[FieldOffset(Offset = "0x214")]
		public Color innerGlowColor;

		[Token(Token = "0x40000CB")]
		[FieldOffset(Offset = "0x224")]
		public InnerGlowBlendMode innerGlowBlendMode;

		[Token(Token = "0x40000CC")]
		[FieldOffset(Offset = "0x228")]
		public Visibility innerGlowVisibility;

		[Range(0f, 1f)]
		[Tooltip("Intensity of the focus effect. A value of 0 disables the focus effect completely.")]
		[Token(Token = "0x40000CD")]
		[FieldOffset(Offset = "0x22C")]
		public float focus;

		[Tooltip("Color and transparency of the focus dim overlay.")]
		[Token(Token = "0x40000CE")]
		[FieldOffset(Offset = "0x230")]
		public Color focusColor;

		[Range(0f, 1f)]
		[Tooltip("Optional background blur intensity for the focus effect.")]
		[Token(Token = "0x40000CF")]
		[FieldOffset(Offset = "0x240")]
		public float focusBlur;

		[Range(1f, 8f)]
		[Tooltip("Downsampling factor for the focus blur. Higher values improve performance at the cost of quality.")]
		[Token(Token = "0x40000D0")]
		[FieldOffset(Offset = "0x244")]
		public int focusBlurDownsampling;

		[Range(0f, 1f)]
		[Tooltip("Desaturation intensity for the focus background. A value of 1 makes the background fully grayscale.")]
		[Token(Token = "0x40000D1")]
		[FieldOffset(Offset = "0x248")]
		public float focusDesaturation;

		[Tooltip("Enables the targetFX effect. This effect draws an animated sprite over the object.")]
		[Token(Token = "0x40000D2")]
		[FieldOffset(Offset = "0x24C")]
		public bool targetFX;

		[Tooltip("Style of the target FX effect.")]
		[Token(Token = "0x40000D3")]
		[FieldOffset(Offset = "0x250")]
		public TargetFXStyle targetFXStyle;

		[Tooltip("Width of the frame when using Frame style")]
		[Range(0.001f, 0.5f)]
		[Token(Token = "0x40000D4")]
		[FieldOffset(Offset = "0x254")]
		public float targetFXFrameWidth;

		[Tooltip("Length of the frame corners when using Frame style")]
		[Range(0f, 0.5f)]
		[Token(Token = "0x40000D5")]
		[FieldOffset(Offset = "0x258")]
		public float targetFXCornerLength;

		[Tooltip("Minimum opacity of the frame when using Frame style")]
		[Range(0f, 1f)]
		[Token(Token = "0x40000D6")]
		[FieldOffset(Offset = "0x25C")]
		public float targetFXFrameMinOpacity;

		[Tooltip("If the ground is transparent, the effect won't work. You can set this property to the altitude of the transparent ground to force the effect to render at this altitude.")]
		[Token(Token = "0x40000D7")]
		[FieldOffset(Offset = "0x260")]
		public float targetFXGroundMinAltitude;

		[Token(Token = "0x40000D8")]
		[FieldOffset(Offset = "0x268")]
		public Texture2D targetFXTexture;

		[ColorUsage(true, true)]
		[Token(Token = "0x40000D9")]
		[FieldOffset(Offset = "0x270")]
		public Color targetFXColor;

		[Token(Token = "0x40000DA")]
		[FieldOffset(Offset = "0x280")]
		public Transform targetFXCenter;

		[Token(Token = "0x40000DB")]
		[FieldOffset(Offset = "0x288")]
		public float targetFXRotationSpeed;

		[Tooltip("Initial rotation angle for the Target FX effect")]
		[Token(Token = "0x40000DC")]
		[FieldOffset(Offset = "0x28C")]
		public float targetFXRotationAngle;

		[Token(Token = "0x40000DD")]
		[FieldOffset(Offset = "0x290")]
		public float targetFXInitialScale;

		[Token(Token = "0x40000DE")]
		[FieldOffset(Offset = "0x294")]
		public float targetFXEndScale;

		[Tooltip("Makes target scale relative to object renderer bounds")]
		[Token(Token = "0x40000DF")]
		[FieldOffset(Offset = "0x298")]
		public bool targetFXScaleToRenderBounds;

		[Tooltip("Enable to render a single target FX effect at the center of the enclosing bounds")]
		[Token(Token = "0x40000E0")]
		[FieldOffset(Offset = "0x299")]
		public bool targetFXUseEnclosingBounds;

		[Tooltip("Makes target FX effect square")]
		[Token(Token = "0x40000E1")]
		[FieldOffset(Offset = "0x29A")]
		public bool targetFXSquare;

		[Tooltip("Places target FX sprite at the bottom of the highlighted object")]
		[Token(Token = "0x40000E2")]
		[FieldOffset(Offset = "0x29B")]
		public bool targetFXAlignToGround;

		[Tooltip("Optional worlds space offset for the position of the targetFX effect")]
		[Token(Token = "0x40000E3")]
		[FieldOffset(Offset = "0x29C")]
		public Vector3 targetFXOffset;

		[Tooltip("If enabled, the target FX effect will be centered on the hit position")]
		[Token(Token = "0x40000E4")]
		[FieldOffset(Offset = "0x2A8")]
		public bool targetFxCenterOnHitPosition;

		[Tooltip("If enabled, the target FX effect will align to the hit normal")]
		[Token(Token = "0x40000E5")]
		[FieldOffset(Offset = "0x2A9")]
		public bool targetFxAlignToNormal;

		[Tooltip("Fade out effect with altitude")]
		[Token(Token = "0x40000E6")]
		[FieldOffset(Offset = "0x2AC")]
		public float targetFXFadePower;

		[Token(Token = "0x40000E7")]
		[FieldOffset(Offset = "0x2B0")]
		public float targetFXGroundMaxDistance;

		[Token(Token = "0x40000E8")]
		[FieldOffset(Offset = "0x2B4")]
		public LayerMask targetFXGroundLayerMask;

		[Token(Token = "0x40000E9")]
		[FieldOffset(Offset = "0x2B8")]
		public float targetFXTransitionDuration;

		[Tooltip("The duration of the effect. A value of 0 will keep the target sprite on screen while object is highlighted.")]
		[Token(Token = "0x40000EA")]
		[FieldOffset(Offset = "0x2BC")]
		public float targetFXStayDuration;

		[Token(Token = "0x40000EB")]
		[FieldOffset(Offset = "0x2C0")]
		public Visibility targetFXVisibility;

		[Tooltip("Enables the iconFX effect. This effect draws an animated object over the object.")]
		[Token(Token = "0x40000EC")]
		[FieldOffset(Offset = "0x2C4")]
		public bool iconFX;

		[Token(Token = "0x40000ED")]
		[FieldOffset(Offset = "0x2C8")]
		public IconAssetType iconFXAssetType;

		[Token(Token = "0x40000EE")]
		[FieldOffset(Offset = "0x2D0")]
		public GameObject iconFXPrefab;

		[Token(Token = "0x40000EF")]
		[FieldOffset(Offset = "0x2D8")]
		public Mesh iconFXMesh;

		[ColorUsage(true, true)]
		[Token(Token = "0x40000F0")]
		[FieldOffset(Offset = "0x2E0")]
		public Color iconFXLightColor;

		[ColorUsage(true, true)]
		[Token(Token = "0x40000F1")]
		[FieldOffset(Offset = "0x2F0")]
		public Color iconFXDarkColor;

		[Token(Token = "0x40000F2")]
		[FieldOffset(Offset = "0x300")]
		public Transform iconFXCenter;

		[Token(Token = "0x40000F3")]
		[FieldOffset(Offset = "0x308")]
		public float iconFXRotationSpeed;

		[Token(Token = "0x40000F4")]
		[FieldOffset(Offset = "0x30C")]
		public IconAnimationOption iconFXAnimationOption;

		[Token(Token = "0x40000F5")]
		[FieldOffset(Offset = "0x310")]
		public float iconFXAnimationAmount;

		[Token(Token = "0x40000F6")]
		[FieldOffset(Offset = "0x314")]
		public float iconFXAnimationSpeed;

		[Token(Token = "0x40000F7")]
		[FieldOffset(Offset = "0x318")]
		public float iconFXScale;

		[Tooltip("Makes target scale relative to object renderer bounds.")]
		[Token(Token = "0x40000F8")]
		[FieldOffset(Offset = "0x31C")]
		public bool iconFXScaleToRenderBounds;

		[Tooltip("Optional world space offset for the position of the iconFX effect")]
		[Token(Token = "0x40000F9")]
		[FieldOffset(Offset = "0x320")]
		public Vector3 iconFXOffset;

		[Token(Token = "0x40000FA")]
		[FieldOffset(Offset = "0x32C")]
		public float iconFXTransitionDuration;

		[Token(Token = "0x40000FB")]
		[FieldOffset(Offset = "0x330")]
		public float iconFXStayDuration;

		[Tooltip("Enables the label effect. This effect shows a text label over the object.")]
		[Token(Token = "0x40000FC")]
		[FieldOffset(Offset = "0x334")]
		public bool labelEnabled;

		[Tooltip("The text to display in the label")]
		[Token(Token = "0x40000FD")]
		[FieldOffset(Offset = "0x338")]
		public string labelText;

		[Tooltip("The size of the label text")]
		[Token(Token = "0x40000FE")]
		[FieldOffset(Offset = "0x340")]
		public float labelTextSize;

		[ColorUsage(true, true)]
		[Token(Token = "0x40000FF")]
		[FieldOffset(Offset = "0x344")]
		public Color labelColor;

		[Tooltip("The prefab to use for the label. Must contain a Canvas and TextMeshProUGUI component.")]
		[Token(Token = "0x4000100")]
		[FieldOffset(Offset = "0x358")]
		public GameObject labelPrefab;

		[Token(Token = "0x4000101")]
		[FieldOffset(Offset = "0x360")]
		public Vector2 labelViewportOffset;

		[Token(Token = "0x4000102")]
		[FieldOffset(Offset = "0x368")]
		public float labelVerticalOffset;

		[Tooltip("The horizontal offset of the label with respect to the object center")]
		[FormerlySerializedAs("lineLength")]
		[Token(Token = "0x4000103")]
		[FieldOffset(Offset = "0x36C")]
		public float labelLineLength;

		[Tooltip("The target transform for the label")]
		[Token(Token = "0x4000104")]
		[FieldOffset(Offset = "0x370")]
		public Transform labelTarget;

		[Tooltip("If enabled, the label will follow the cursor when hovering the object")]
		[Token(Token = "0x4000105")]
		[FieldOffset(Offset = "0x378")]
		public bool labelFollowCursor;

		[Token(Token = "0x4000106")]
		[FieldOffset(Offset = "0x37C")]
		public LabelMode labelMode;

		[Tooltip("If enabled, the label will be shown in editor mode (non playing)")]
		[Token(Token = "0x4000107")]
		[FieldOffset(Offset = "0x380")]
		public bool labelShowInEditorMode;

		[Tooltip("Controls the alignment of the label relative to the target object on screen.")]
		[Token(Token = "0x4000108")]
		[FieldOffset(Offset = "0x384")]
		public LabelAlignment labelAlignment;

		[Tooltip("Enables relative alignment based on the forward direction of the alignment transform.")]
		[Token(Token = "0x4000109")]
		[FieldOffset(Offset = "0x388")]
		public bool labelRelativeAlignment;

		[Tooltip("The transform used for relative alignment direction.")]
		[Token(Token = "0x400010A")]
		[FieldOffset(Offset = "0x390")]
		public Transform labelAlignmentTransform;

		[Tooltip("Maximum distance from camera where the label is visible (units). Default 250.")]
		[Token(Token = "0x400010B")]
		[FieldOffset(Offset = "0x398")]
		public float labelMaxDistance;

		[Tooltip("Distance at which label starts fading out (units). 0 disables fading.")]
		[Token(Token = "0x400010C")]
		[FieldOffset(Offset = "0x39C")]
		public float labelFadeStartDistance;

		[Tooltip("Enable distance-based scaling of label Canvas.")]
		[Token(Token = "0x400010D")]
		[FieldOffset(Offset = "0x3A0")]
		public bool labelScaleByDistance;

		[Tooltip("Minimum scale when at max distance (0..1 typically). Default 1.")]
		[Token(Token = "0x400010E")]
		[FieldOffset(Offset = "0x3A4")]
		public float labelScaleMin;

		[Tooltip("Maximum scale when near camera. Default 1.")]
		[Token(Token = "0x400010F")]
		[FieldOffset(Offset = "0x3A8")]
		public float labelScaleMax;

		[Tooltip("See-through mode for this Highlight Effect component.")]
		[Token(Token = "0x4000110")]
		[FieldOffset(Offset = "0x3AC")]
		public SeeThroughMode seeThrough;

		[Tooltip("This mask setting let you specify which objects will be considered as occluders and cause the see-through effect for this Highlight Effect component. For example, you assign your walls to a different layer and specify that layer here, so only walls and not other objects, like ground or ceiling, will trigger the see-through effect.")]
		[Token(Token = "0x4000111")]
		[FieldOffset(Offset = "0x3B0")]
		public LayerMask seeThroughOccluderMask;

		[Tooltip("A multiplier for the occluder volume size which can be used to reduce the actual size of occluders when Highlight Effect checks if they're occluding this object.")]
		[Range(0.01f, 0.6f)]
		[Token(Token = "0x4000112")]
		[FieldOffset(Offset = "0x3B4")]
		public float seeThroughOccluderThreshold;

		[Tooltip("Uses stencil buffers to ensure pixel-accurate occlusion test. If this option is disabled, only physics raycasting is used to test for occlusion.")]
		[Token(Token = "0x4000113")]
		[FieldOffset(Offset = "0x3B8")]
		public bool seeThroughOccluderMaskAccurate;

		[Tooltip("The interval of time between occlusion tests.")]
		[Token(Token = "0x4000114")]
		[FieldOffset(Offset = "0x3BC")]
		public float seeThroughOccluderCheckInterval;

		[Tooltip("If enabled, occlusion test is performed for each children element. If disabled, the bounds of all children is combined and a single occlusion test is performed for the combined bounds.")]
		[Token(Token = "0x4000115")]
		[FieldOffset(Offset = "0x3C0")]
		public bool seeThroughOccluderCheckIndividualObjects;

		[Tooltip("Shows the see-through effect only if the occluder if at this 'offset' distance from the object.")]
		[Token(Token = "0x4000116")]
		[FieldOffset(Offset = "0x3C4")]
		public float seeThroughDepthOffset;

		[Tooltip("Hides the see-through effect if the occluder is further than this distance from the object (0 = infinite)")]
		[Token(Token = "0x4000117")]
		[FieldOffset(Offset = "0x3C8")]
		public float seeThroughMaxDepth;

		[Tooltip("Fade-out width near Max Depth (0 keeps hard clip)")]
		[Token(Token = "0x4000118")]
		[FieldOffset(Offset = "0x3CC")]
		public float seeThroughFadeRange;

		[Range(0f, 5f)]
		[Token(Token = "0x4000119")]
		[FieldOffset(Offset = "0x3D0")]
		public float seeThroughIntensity;

		[Range(0f, 1f)]
		[Token(Token = "0x400011A")]
		[FieldOffset(Offset = "0x3D4")]
		public float seeThroughTintAlpha;

		[ColorUsage(true, true)]
		[Token(Token = "0x400011B")]
		[FieldOffset(Offset = "0x3D8")]
		public Color seeThroughTintColor;

		[Range(0f, 1f)]
		[Token(Token = "0x400011C")]
		[FieldOffset(Offset = "0x3E8")]
		public float seeThroughNoise;

		[Range(0f, 1f)]
		[Token(Token = "0x400011D")]
		[FieldOffset(Offset = "0x3EC")]
		public float seeThroughBorder;

		[Token(Token = "0x400011E")]
		[FieldOffset(Offset = "0x3F0")]
		public Color seeThroughBorderColor;

		[Tooltip("Only display the border instead of the full see-through effect.")]
		[Token(Token = "0x400011F")]
		[FieldOffset(Offset = "0x400")]
		public bool seeThroughBorderOnly;

		[Token(Token = "0x4000120")]
		[FieldOffset(Offset = "0x404")]
		public float seeThroughBorderWidth;

		[Tooltip("This option clears the stencil buffer after rendering the see-through effect which results in correct rendering order and supports other stencil-based effects that render afterwards.")]
		[Token(Token = "0x4000121")]
		[FieldOffset(Offset = "0x408")]
		public bool seeThroughOrdered;

		[Tooltip("Optional see-through mask effect texture.")]
		[Token(Token = "0x4000122")]
		[FieldOffset(Offset = "0x410")]
		public Texture2D seeThroughTexture;

		[Token(Token = "0x4000123")]
		[FieldOffset(Offset = "0x418")]
		public TextureUVSpace seeThroughTextureUVSpace;

		[Token(Token = "0x4000124")]
		[FieldOffset(Offset = "0x41C")]
		public float seeThroughTextureScale;

		[Tooltip("The order by which children objects are rendered by the see-through effect")]
		[Token(Token = "0x4000125")]
		[FieldOffset(Offset = "0x420")]
		public SeeThroughSortingMode seeThroughChildrenSortingMode;

		[CompilerGenerated]
		[Token(Token = "0x4000126")]
		[FieldOffset(Offset = "0x428")]
		private OnObjectSelectionEvent OnObjectSelected;

		[CompilerGenerated]
		[Token(Token = "0x4000127")]
		[FieldOffset(Offset = "0x430")]
		private OnObjectSelectionEvent OnObjectUnSelected;

		[CompilerGenerated]
		[Token(Token = "0x4000128")]
		[FieldOffset(Offset = "0x438")]
		private OnObjectHighlightEvent OnObjectHighlightStart;

		[CompilerGenerated]
		[Token(Token = "0x4000129")]
		[FieldOffset(Offset = "0x440")]
		private OnObjectHighlightEvent OnObjectHighlightEnd;

		[CompilerGenerated]
		[Token(Token = "0x400012A")]
		[FieldOffset(Offset = "0x448")]
		private OnObjectHighlightStateEvent OnObjectHighlightStateChange;

		[CompilerGenerated]
		[Token(Token = "0x400012B")]
		[FieldOffset(Offset = "0x450")]
		private OnRendererHighlightEvent OnRendererHighlightStart;

		[CompilerGenerated]
		[Token(Token = "0x400012C")]
		[FieldOffset(Offset = "0x458")]
		private OnAnimateEvent OnTargetAnimates;

		[CompilerGenerated]
		[Token(Token = "0x400012D")]
		[FieldOffset(Offset = "0x460")]
		private OnAnimateEvent OnIconAnimates;

		[SerializeField]
		[HideInInspector]
		[Token(Token = "0x400012E")]
		[FieldOffset(Offset = "0x468")]
		private ModelMaterials[] rms;

		[SerializeField]
		[HideInInspector]
		[Token(Token = "0x400012F")]
		[FieldOffset(Offset = "0x470")]
		private int rmsCount;

		[NonSerialized]
		[Token(Token = "0x4000130")]
		[FieldOffset(Offset = "0x474")]
		public bool alignToGroundTried;

		[NonSerialized]
		[Token(Token = "0x4000131")]
		[FieldOffset(Offset = "0x475")]
		public bool alignToGroundHitGood;

		[NonSerialized]
		[Token(Token = "0x4000132")]
		[FieldOffset(Offset = "0x476")]
		public bool isVisible;

		[NonSerialized]
		[Token(Token = "0x4000133")]
		[FieldOffset(Offset = "0x478")]
		private Transform _target;

		[NonSerialized]
		[Token(Token = "0x4000134")]
		[FieldOffset(Offset = "0x480")]
		public float highlightStartTime;

		[NonSerialized]
		[Token(Token = "0x4000135")]
		[FieldOffset(Offset = "0x484")]
		public float targetFXStartTime;

		[NonSerialized]
		[Token(Token = "0x4000136")]
		[FieldOffset(Offset = "0x488")]
		public float iconFXStartTime;

		[Token(Token = "0x4000137")]
		[FieldOffset(Offset = "0x490")]
		private GameObject instantiatedIconPrefab;

		[Token(Token = "0x4000138")]
		[FieldOffset(Offset = "0x498")]
		private List<Material> instantiatedIconMaterials;

		[Token(Token = "0x4000139")]
		[FieldOffset(Offset = "0x4A0")]
		private bool _isSelected;

		[NonSerialized]
		[Token(Token = "0x400013A")]
		[FieldOffset(Offset = "0x4A1")]
		public bool spriteMode;

		[NonSerialized]
		[Token(Token = "0x400013B")]
		[FieldOffset(Offset = "0x4A2")]
		public bool particleMode;

		[NonSerialized]
		[Token(Token = "0x400013C")]
		[FieldOffset(Offset = "0x4A8")]
		public HighlightProfile previousSettings;

		[Token(Token = "0x400013D")]
		public static HighlightEffect lastHighlighted;

		[Token(Token = "0x400013E")]
		public static HighlightEffect lastSelected;

		[NonSerialized]
		[Token(Token = "0x400013F")]
		[FieldOffset(Offset = "0x4B0")]
		public string lastRegExError;

		[Token(Token = "0x4000140")]
		private const float TAU = 0.70711f;

		[Token(Token = "0x4000141")]
		private static Material fxMatMask;

		[Token(Token = "0x4000142")]
		private static Material fxMatSolidColor;

		[Token(Token = "0x4000143")]
		private static Material fxMatSeeThrough;

		[Token(Token = "0x4000144")]
		private static Material fxMatSeeThroughBorder;

		[Token(Token = "0x4000145")]
		private static Material fxMatOverlay;

		[Token(Token = "0x4000146")]
		private static Material fxMatClearStencil;

		[Token(Token = "0x4000147")]
		private static Material fxMatSeeThroughMask;

		[Token(Token = "0x4000148")]
		private static Material fxMatFocus;

		[Token(Token = "0x4000149")]
		private static Material fxMatFocusBlur;

		[Token(Token = "0x400014A")]
		private static Material fxMatGlowTemplate;

		[Token(Token = "0x400014B")]
		private static Material fxMatInnerGlow;

		[Token(Token = "0x400014C")]
		private static Material fxMatOutlineTemplate;

		[Token(Token = "0x400014D")]
		private static int sharedTemplateMaterialsRefCount;

		[Token(Token = "0x400014E")]
		private static Shader shaderMask;

		[Token(Token = "0x400014F")]
		private static Shader shaderGlow;

		[Token(Token = "0x4000150")]
		private static Shader shaderInnerGlow;

		[Token(Token = "0x4000151")]
		private static Shader shaderOutline;

		[Token(Token = "0x4000152")]
		private static Shader shaderOverlay;

		[Token(Token = "0x4000153")]
		private static Shader shaderSeeThrough;

		[Token(Token = "0x4000154")]
		private static Shader shaderSeeThroughBorder;

		[Token(Token = "0x4000155")]
		private static Shader shaderSeeThroughMask;

		[Token(Token = "0x4000156")]
		private static Shader shaderTarget;

		[Token(Token = "0x4000157")]
		private static Shader shaderComposeGlow;

		[Token(Token = "0x4000158")]
		private static Shader shaderComposeOutline;

		[Token(Token = "0x4000159")]
		private static Shader shaderSolidColor;

		[Token(Token = "0x400015A")]
		private static Shader shaderBlurGlow;

		[Token(Token = "0x400015B")]
		private static Shader shaderBlurOutline;

		[Token(Token = "0x400015C")]
		private static Shader shaderClearStencil;

		[Token(Token = "0x400015D")]
		private static Shader shaderSeeThroughOccluder;

		[Token(Token = "0x400015E")]
		private static Shader shaderDepthWrite;

		[Token(Token = "0x400015F")]
		private static Shader shaderFocus;

		[Token(Token = "0x4000160")]
		private static Texture2D cachedNoiseTex;

		[Token(Token = "0x4000161")]
		[FieldOffset(Offset = "0x4B8")]
		private Material fxMatTarget;

		[Token(Token = "0x4000162")]
		[FieldOffset(Offset = "0x4C0")]
		private Material fxMatComposeGlow;

		[Token(Token = "0x4000163")]
		[FieldOffset(Offset = "0x4C8")]
		private Material fxMatComposeOutline;

		[Token(Token = "0x4000164")]
		[FieldOffset(Offset = "0x4D0")]
		private Material fxMatBlurGlow;

		[Token(Token = "0x4000165")]
		[FieldOffset(Offset = "0x4D8")]
		private Material fxMatBlurOutline;

		[Token(Token = "0x4000166")]
		[FieldOffset(Offset = "0x4E0")]
		private Material fxMatIcon;

		[Token(Token = "0x4000167")]
		private static Vector4[] offsets;

		[Token(Token = "0x4000168")]
		[FieldOffset(Offset = "0x4E8")]
		private float fadeStartTime;

		[NonSerialized]
		[Token(Token = "0x4000169")]
		[FieldOffset(Offset = "0x4EC")]
		public FadingState fading;

		[Token(Token = "0x400016A")]
		[FieldOffset(Offset = "0x4F0")]
		private CommandBuffer cbHighlight;

		[Token(Token = "0x400016B")]
		[FieldOffset(Offset = "0x4F8")]
		private bool cbHighlightEmpty;

		[Token(Token = "0x400016C")]
		[FieldOffset(Offset = "0x500")]
		private int[] mipGlowBuffers;

		[Token(Token = "0x400016D")]
		[FieldOffset(Offset = "0x508")]
		private int[] mipOutlineBuffers;

		[Token(Token = "0x400016E")]
		private static Mesh quadMesh;

		[Token(Token = "0x400016F")]
		private static Mesh cubeMesh;

		[Token(Token = "0x4000170")]
		[FieldOffset(Offset = "0x510")]
		private int sourceRT;

		[Token(Token = "0x4000171")]
		[FieldOffset(Offset = "0x514")]
		private Matrix4x4 quadGlowMatrix;

		[Token(Token = "0x4000172")]
		[FieldOffset(Offset = "0x554")]
		private Matrix4x4 quadOutlineMatrix;

		[Token(Token = "0x4000173")]
		[FieldOffset(Offset = "0x598")]
		private Vector4[] corners;

		[Token(Token = "0x4000174")]
		[FieldOffset(Offset = "0x5A0")]
		private RenderTextureDescriptor sourceDesc;

		[Token(Token = "0x4000175")]
		[FieldOffset(Offset = "0x5D4")]
		private Color debugColor;

		[Token(Token = "0x4000176")]
		[FieldOffset(Offset = "0x5E4")]
		private Color blackColor;

		[Token(Token = "0x4000177")]
		[FieldOffset(Offset = "0x5F4")]
		private Visibility lastOutlineVisibility;

		[Token(Token = "0x4000178")]
		[FieldOffset(Offset = "0x5F8")]
		private bool requireUpdateMaterial;

		[Token(Token = "0x4000179")]
		[FieldOffset(Offset = "0x5FC")]
		private Bounds enclosingBounds;

		[NonSerialized]
		[Token(Token = "0x400017A")]
		public static List<HighlightEffect> effects;

		[Token(Token = "0x400017B")]
		public static bool customSorting;

		[Token(Token = "0x400017C")]
		public static bool focusRendered;

		[NonSerialized]
		[Token(Token = "0x400017D")]
		[FieldOffset(Offset = "0x614")]
		public float sortingOffset;

		[Token(Token = "0x400017E")]
		[FieldOffset(Offset = "0x618")]
		private bool useSmoothGlow;

		[Token(Token = "0x400017F")]
		[FieldOffset(Offset = "0x619")]
		private bool useSmoothOutline;

		[Token(Token = "0x4000180")]
		[FieldOffset(Offset = "0x61A")]
		private bool useSmoothBlend;

		[Token(Token = "0x4000181")]
		[FieldOffset(Offset = "0x61B")]
		private bool useGPUInstancing;

		[Token(Token = "0x4000182")]
		[FieldOffset(Offset = "0x61C")]
		private bool usesReversedZBuffer;

		[Token(Token = "0x4000183")]
		[FieldOffset(Offset = "0x61D")]
		private bool usesSeeThrough;

		[Token(Token = "0x4000184")]
		[FieldOffset(Offset = "0x61E")]
		private bool maskRequired;

		[Token(Token = "0x4000185")]
		[FieldOffset(Offset = "0x61F")]
		private bool shouldBakeSkinnedMesh;

		[Token(Token = "0x4000186")]
		[FieldOffset(Offset = "0x620")]
		private bool renderMaskOnTop;

		[Token(Token = "0x4000187")]
		[FieldOffset(Offset = "0x628")]
		private readonly Dictionary<Camera, PerCameraOcclusionData> perCameraOcclusionData;

		[Token(Token = "0x4000188")]
		[FieldOffset(Offset = "0x630")]
		private MaterialPropertyBlock glowPropertyBlock;

		[Token(Token = "0x4000189")]
		[FieldOffset(Offset = "0x638")]
		private MaterialPropertyBlock outlinePropertyBlock;

		[Token(Token = "0x400018A")]
		private static readonly List<Vector4> matDataDirection;

		[Token(Token = "0x400018B")]
		private static readonly List<Vector4> matDataGlow;

		[Token(Token = "0x400018C")]
		private static readonly List<Vector4> matDataColor;

		[Token(Token = "0x400018D")]
		private static Matrix4x4[] matrices;

		[Token(Token = "0x400018E")]
		[FieldOffset(Offset = "0x640")]
		private int outlineOffsetsMin;

		[Token(Token = "0x400018F")]
		[FieldOffset(Offset = "0x644")]
		private int outlineOffsetsMax;

		[Token(Token = "0x4000190")]
		[FieldOffset(Offset = "0x648")]
		private int glowOffsetsMin;

		[Token(Token = "0x4000191")]
		[FieldOffset(Offset = "0x64C")]
		private int glowOffsetsMax;

		[Token(Token = "0x4000192")]
		[FieldOffset(Offset = "0x650")]
		private Texture2D outlineGradientTex;

		[Token(Token = "0x4000193")]
		[FieldOffset(Offset = "0x658")]
		private Color[] outlineGradientColors;

		[Token(Token = "0x4000194")]
		[FieldOffset(Offset = "0x660")]
		private bool isInitialized;

		[Token(Token = "0x4000195")]
		[FieldOffset(Offset = "0x664")]
		private float realOutlineWidth;

		[NonSerialized]
		[Token(Token = "0x4000196")]
		[FieldOffset(Offset = "0x668")]
		private bool sharedTemplateMaterialsAcquired;

		[Token(Token = "0x4000197")]
		[FieldOffset(Offset = "0x670")]
		private RenderTargetIdentifier colorAttachmentBuffer;

		[Token(Token = "0x4000198")]
		[FieldOffset(Offset = "0x698")]
		private RenderTargetIdentifier depthAttachmentBuffer;

		[Token(Token = "0x4000199")]
		[FieldOffset(Offset = "0x6C0")]
		private float smoothEffectDistance;

		[Token(Token = "0x400019A")]
		[FieldOffset(Offset = "0x6C8")]
		private readonly List<Renderer> tempRR;

		[Token(Token = "0x400019B")]
		private static List<Vector3> vertices;

		[Token(Token = "0x400019C")]
		private static List<Vector3> normals;

		[Token(Token = "0x400019D")]
		private static Vector3[] newNormals;

		[Token(Token = "0x400019E")]
		private static int[] matches;

		[Token(Token = "0x400019F")]
		private static readonly Dictionary<Vector3, int> vv;

		[Token(Token = "0x40001A0")]
		private static readonly List<Material> rendererSharedMaterials;

		[Token(Token = "0x40001A1")]
		private static readonly Dictionary<int, Mesh> smoothMeshes;

		[Token(Token = "0x40001A2")]
		private static readonly Dictionary<int, Mesh> reorientedMeshes;

		[Token(Token = "0x40001A3")]
		private static readonly Dictionary<Mesh, HashSet<HighlightEffect>> sharedMeshUsage;

		[Token(Token = "0x40001A4")]
		private const int MAX_VERTEX_COUNT = 65535;

		[Token(Token = "0x40001A5")]
		private static CombineInstance[] combineInstances;

		[Token(Token = "0x40001A6")]
		private static readonly Dictionary<int, Mesh> combinedMeshes;

		[Token(Token = "0x40001A7")]
		[FieldOffset(Offset = "0x6D0")]
		private int combinedMeshesHashId;

		[Token(Token = "0x40001A8")]
		public static bool useUnscaledTime;

		[NonSerialized]
		[Token(Token = "0x40001A9")]
		[FieldOffset(Offset = "0x6D8")]
		public Transform currentHitTarget;

		[NonSerialized]
		[Token(Token = "0x40001AA")]
		[FieldOffset(Offset = "0x6E0")]
		public Vector3 currentHitLocalPosition;

		[NonSerialized]
		[Token(Token = "0x40001AB")]
		[FieldOffset(Offset = "0x6EC")]
		public Vector3 currentHitNormal;

		[Range(0f, 1f)]
		[Token(Token = "0x40001AC")]
		[FieldOffset(Offset = "0x6F8")]
		public float hitFxInitialIntensity;

		[Token(Token = "0x40001AD")]
		[FieldOffset(Offset = "0x6FC")]
		public HitFxMode hitFxMode;

		[Token(Token = "0x40001AE")]
		[FieldOffset(Offset = "0x700")]
		public HitFXTriggerMode hitFXTriggerMode;

		[Token(Token = "0x40001AF")]
		[FieldOffset(Offset = "0x704")]
		public float hitFxFadeOutDuration;

		[ColorUsage(true, true)]
		[Token(Token = "0x40001B0")]
		[FieldOffset(Offset = "0x708")]
		public Color hitFxColor;

		[Token(Token = "0x40001B1")]
		[FieldOffset(Offset = "0x718")]
		public float hitFxRadius;

		[Token(Token = "0x40001B2")]
		[FieldOffset(Offset = "0x71C")]
		private float hitInitialIntensity;

		[Token(Token = "0x40001B3")]
		[FieldOffset(Offset = "0x720")]
		private float hitStartTime;

		[Token(Token = "0x40001B4")]
		[FieldOffset(Offset = "0x724")]
		private float hitFadeOutDuration;

		[Token(Token = "0x40001B5")]
		[FieldOffset(Offset = "0x728")]
		private Color hitColor;

		[Token(Token = "0x40001B6")]
		[FieldOffset(Offset = "0x738")]
		private bool hitActive;

		[Token(Token = "0x40001B7")]
		[FieldOffset(Offset = "0x73C")]
		private Vector3 hitPosition;

		[Token(Token = "0x40001B8")]
		[FieldOffset(Offset = "0x748")]
		private float hitRadius;

		[NonSerialized]
		[Token(Token = "0x40001B9")]
		[FieldOffset(Offset = "0x750")]
		public HighlightLabel label;

		[Token(Token = "0x40001BA")]
		private static readonly List<HighlightSeeThroughOccluder> occluders;

		[Token(Token = "0x40001BB")]
		private static readonly Dictionary<Camera, int> occludersFrameCount;

		[Token(Token = "0x40001BC")]
		private static Material fxMatSeeThroughOccluder;

		[Token(Token = "0x40001BD")]
		private static Material fxMatDepthWrite;

		[Token(Token = "0x40001BE")]
		private static RaycastHit[] hits;

		[Token(Token = "0x40001BF")]
		private const int MAX_OCCLUDER_HITS = 50;

		[Token(Token = "0x40001C0")]
		private static RaycastHit[] occluderHits;

		[Token(Token = "0x17000001")]
		public bool highlighted
		{
			[Token(Token = "0x600001D")]
			[Address(RVA = "0x770B9C8", Offset = "0x770B9C8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.highlighted;\n")]
			get
			{
				return _highlighted;
			}
			[Token(Token = "0x600001E")]
			[Address(RVA = "0x770B9D0", Offset = "0x770B9D0", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHighlightPlus.HighlightEffect::SetHighlighted(this, value);\n\treturn;\n")]
			set
			{
				SetHighlighted(value);
			}
		}

		[Token(Token = "0x17000002")]
		public int includedObjectsCount
		{
			[Token(Token = "0x600002F")]
			[Address(RVA = "0x770C760", Offset = "0x770C760", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.includedObjectsCount;\n")]
			get
			{
				return rmsCount;
			}
		}

		[Token(Token = "0x17000003")]
		public Transform target
		{
			[Token(Token = "0x6000030")]
			[Address(RVA = "0x770C768", Offset = "0x770C768", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.target;\n")]
			get
			{
				return _target;
			}
			[Token(Token = "0x6000031")]
			[Address(RVA = "0x770C770", Offset = "0x770C770", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv53 = UnityEngine.Object::op_Equality(value, 0);\n\tv60 = ~v53;\n\tif (v60) goto L_0042;\n\tthis.target = 0;\n\treturn;\nL_0042:\n\tHighlightPlus.HighlightEffect::SetTarget(this, value);\n\treturn;\n")]
			set
			{
				if (value == null)
				{
					_target = null;
				}
				else
				{
					SetTarget(value);
				}
			}
		}

		[Token(Token = "0x17000004")]
		public Transform currentTarget
		{
			[Token(Token = "0x6000032")]
			[Address(RVA = "0x770C94C", Offset = "0x770C94C", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Inequality(this.effectTarget, 0);\n\tv64 = v55 == 0;\n\tif (v64) goto L_0042;\n\treturn this.effectTarget;\nL_0042:\n\treturnVal2 = UnityEngine.Component::get_transform(this);\n\treturn returnVal2;\n")]
			get
			{
				if (effectTarget != null)
				{
					return effectTarget;
				}
				return base.transform;
			}
		}

		[Token(Token = "0x17000005")]
		public bool isSelected
		{
			[Token(Token = "0x6000033")]
			[Address(RVA = "0x770CA00", Offset = "0x770CA00", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.isSelected;\n")]
			get
			{
				return _isSelected;
			}
			[Token(Token = "0x6000034")]
			[Address(RVA = "0x770CA08", Offset = "0x770CA08", Length = "0xF0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv53 = ~value;\n\tif (v53) goto L_0047;\n\tv83 = this.OnObjectSelected == 0;\n\tif (v83) goto L_0030;\n\tv109 = UnityEngine.Component::get_gameObject(this);\n\tv64 = HighlightPlus.OnObjectSelectionEvent::Invoke(this.OnObjectSelected, v109);\n\tv122 = v64 & 1;\n\tv68 = v122 == 0;\n\tif (v68) goto L_005C;\nL_0030:\n\tthis.isSelected = value;\n\tgoto L_003C;\nL_0047:\n\t;\n\tv84 = this.OnObjectUnSelected == 0;\n\tif (v84) goto L_0054;\n\tv120 = UnityEngine.Component::get_gameObject(this);\n\tv65 = HighlightPlus.OnObjectSelectionEvent::Invoke(this.OnObjectUnSelected, v120);\n\tv69 = v65 == 0;\n\tif (v69) goto L_005C;\nL_0054:\n\tthis.isSelected = value;\nL_001A:\n\tv48 = this.isSelected == value;\n\tif (v48) goto L_005C;\nL_005C:\n\treturn;\nL_003C:\n\tv126.lastSelected = this;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_00cb: Expected O, but got I4
				//IL_0057: Expected O, but got I4
				if (isSelected == value)
				{
					return;
				}
				if (value)
				{
					if (OnObjectSelected != null)
					{
						GameObject obj = base.gameObject;
						object obj2 = OnObjectSelected(obj);
						if ((int)((nint)obj2 & 1) == 0)
						{
							return;
						}
					}
					_isSelected = value;
					lastSelected = this;
					return;
				}
				if (OnObjectUnSelected != null)
				{
					GameObject obj3 = base.gameObject;
					object obj4 = OnObjectUnSelected(obj3);
					if (obj4 == null)
					{
						return;
					}
				}
				_isSelected = value;
			}
		}

		[Token(Token = "0x600001C")]
		[Address(RVA = "0x770B9B0", Offset = "0x770B9B0", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = UnityEngine.Object::GetInstanceID(obj);\n\treturn returnVal1;\n")]
		private static int GetObjectId(UnityEngine.Object obj)
		{
			return obj.GetInstanceID();
		}

		[CompilerGenerated]
		[Token(Token = "0x600001F")]
		[Address(RVA = "0x770BD20", Offset = "0x770BD20", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_0019:\n\t;\n\tv78 = System.Threading.Interlocked::CompareExchange(&this.OnObjectSelected (HighlightPlus.OnObjectSelectionEvent), v88, v83);\n\tv62 = v78 == v83;\nL_FFFFFFFF:\n\tv83 = v78;\n\tif (v62) goto L_0044;\nL_002B:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_0019;\n\tv95 = *([v88 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnObjectSelectionEvent;\n\tif (v95) goto L_0019;\n\tthrow System.InvalidCastException;\nL_0044:\n\treturn;\nL_FFFFFFFF:\n\tv83 = this.OnObjectSelected;\n\tgoto L_002B;\n")]
		public void add_OnObjectSelected(OnObjectSelectionEvent value)
		{
			OnObjectSelectionEvent onObjectSelectionEvent = OnObjectSelected;
			OnObjectSelectionEvent onObjectSelectionEvent2;
			do
			{
				onObjectSelectionEvent2 = onObjectSelectionEvent;
				OnObjectSelectionEvent value2 = (OnObjectSelectionEvent)Delegate.Combine(onObjectSelectionEvent2, value);
				onObjectSelectionEvent = Interlocked.CompareExchange(ref OnObjectSelected, value2, onObjectSelectionEvent2);
			}
			while ((object)onObjectSelectionEvent != onObjectSelectionEvent2);
		}

		[CompilerGenerated]
		[Token(Token = "0x6000020")]
		[Address(RVA = "0x770BDC4", Offset = "0x770BDC4", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_0019:\n\t;\n\tv78 = System.Threading.Interlocked::CompareExchange(&this.OnObjectSelected (HighlightPlus.OnObjectSelectionEvent), v88, v83);\n\tv62 = v78 == v83;\nL_FFFFFFFF:\n\tv83 = v78;\n\tif (v62) goto L_0044;\nL_002B:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_0019;\n\tv95 = *([v88 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnObjectSelectionEvent;\n\tif (v95) goto L_0019;\n\tthrow System.InvalidCastException;\nL_0044:\n\treturn;\nL_FFFFFFFF:\n\tv83 = this.OnObjectSelected;\n\tgoto L_002B;\n")]
		public void remove_OnObjectSelected(OnObjectSelectionEvent value)
		{
			OnObjectSelectionEvent onObjectSelectionEvent = OnObjectSelected;
			OnObjectSelectionEvent onObjectSelectionEvent2;
			do
			{
				onObjectSelectionEvent2 = onObjectSelectionEvent;
				OnObjectSelectionEvent value2 = (OnObjectSelectionEvent)Delegate.Remove(onObjectSelectionEvent2, value);
				onObjectSelectionEvent = Interlocked.CompareExchange(ref OnObjectSelected, value2, onObjectSelectionEvent2);
			}
			while ((object)onObjectSelectionEvent != onObjectSelectionEvent2);
		}

		[CompilerGenerated]
		[Token(Token = "0x6000021")]
		[Address(RVA = "0x770BE68", Offset = "0x770BE68", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_0019:\n\t;\n\tv78 = System.Threading.Interlocked::CompareExchange(&this.OnObjectUnSelected (HighlightPlus.OnObjectSelectionEvent), v88, v83);\n\tv62 = v78 == v83;\nL_FFFFFFFF:\n\tv83 = v78;\n\tif (v62) goto L_0044;\nL_002B:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_0019;\n\tv95 = *([v88 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnObjectSelectionEvent;\n\tif (v95) goto L_0019;\n\tthrow System.InvalidCastException;\nL_0044:\n\treturn;\nL_FFFFFFFF:\n\tv83 = this.OnObjectUnSelected;\n\tgoto L_002B;\n")]
		public void add_OnObjectUnSelected(OnObjectSelectionEvent value)
		{
			OnObjectSelectionEvent onObjectSelectionEvent = OnObjectUnSelected;
			OnObjectSelectionEvent onObjectSelectionEvent2;
			do
			{
				onObjectSelectionEvent2 = onObjectSelectionEvent;
				OnObjectSelectionEvent value2 = (OnObjectSelectionEvent)Delegate.Combine(onObjectSelectionEvent2, value);
				onObjectSelectionEvent = Interlocked.CompareExchange(ref OnObjectUnSelected, value2, onObjectSelectionEvent2);
			}
			while ((object)onObjectSelectionEvent != onObjectSelectionEvent2);
		}

		[CompilerGenerated]
		[Token(Token = "0x6000022")]
		[Address(RVA = "0x770BF0C", Offset = "0x770BF0C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_0019:\n\t;\n\tv78 = System.Threading.Interlocked::CompareExchange(&this.OnObjectUnSelected (HighlightPlus.OnObjectSelectionEvent), v88, v83);\n\tv62 = v78 == v83;\nL_FFFFFFFF:\n\tv83 = v78;\n\tif (v62) goto L_0044;\nL_002B:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_0019;\n\tv95 = *([v88 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnObjectSelectionEvent;\n\tif (v95) goto L_0019;\n\tthrow System.InvalidCastException;\nL_0044:\n\treturn;\nL_FFFFFFFF:\n\tv83 = this.OnObjectUnSelected;\n\tgoto L_002B;\n")]
		public void remove_OnObjectUnSelected(OnObjectSelectionEvent value)
		{
			OnObjectSelectionEvent onObjectSelectionEvent = OnObjectUnSelected;
			OnObjectSelectionEvent onObjectSelectionEvent2;
			do
			{
				onObjectSelectionEvent2 = onObjectSelectionEvent;
				OnObjectSelectionEvent value2 = (OnObjectSelectionEvent)Delegate.Remove(onObjectSelectionEvent2, value);
				onObjectSelectionEvent = Interlocked.CompareExchange(ref OnObjectUnSelected, value2, onObjectSelectionEvent2);
			}
			while ((object)onObjectSelectionEvent != onObjectSelectionEvent2);
		}

		[CompilerGenerated]
		[Token(Token = "0x6000023")]
		[Address(RVA = "0x770BFB0", Offset = "0x770BFB0", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_0019:\n\t;\n\tv78 = System.Threading.Interlocked::CompareExchange(&this.OnObjectHighlightStart (HighlightPlus.OnObjectHighlightEvent), v88, v83);\n\tv62 = v78 == v83;\nL_FFFFFFFF:\n\tv83 = v78;\n\tif (v62) goto L_0044;\nL_002B:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_0019;\n\tv95 = *([v88 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnObjectHighlightEvent;\n\tif (v95) goto L_0019;\n\tthrow System.InvalidCastException;\nL_0044:\n\treturn;\nL_FFFFFFFF:\n\tv83 = this.OnObjectHighlightStart;\n\tgoto L_002B;\n")]
		public void add_OnObjectHighlightStart(OnObjectHighlightEvent value)
		{
			OnObjectHighlightEvent onObjectHighlightEvent = OnObjectHighlightStart;
			OnObjectHighlightEvent onObjectHighlightEvent2;
			do
			{
				onObjectHighlightEvent2 = onObjectHighlightEvent;
				OnObjectHighlightEvent value2 = (OnObjectHighlightEvent)Delegate.Combine(onObjectHighlightEvent2, value);
				onObjectHighlightEvent = Interlocked.CompareExchange(ref OnObjectHighlightStart, value2, onObjectHighlightEvent2);
			}
			while ((object)onObjectHighlightEvent != onObjectHighlightEvent2);
		}

		[CompilerGenerated]
		[Token(Token = "0x6000024")]
		[Address(RVA = "0x770C054", Offset = "0x770C054", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_0019:\n\t;\n\tv78 = System.Threading.Interlocked::CompareExchange(&this.OnObjectHighlightStart (HighlightPlus.OnObjectHighlightEvent), v88, v83);\n\tv62 = v78 == v83;\nL_FFFFFFFF:\n\tv83 = v78;\n\tif (v62) goto L_0044;\nL_002B:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_0019;\n\tv95 = *([v88 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnObjectHighlightEvent;\n\tif (v95) goto L_0019;\n\tthrow System.InvalidCastException;\nL_0044:\n\treturn;\nL_FFFFFFFF:\n\tv83 = this.OnObjectHighlightStart;\n\tgoto L_002B;\n")]
		public void remove_OnObjectHighlightStart(OnObjectHighlightEvent value)
		{
			OnObjectHighlightEvent onObjectHighlightEvent = OnObjectHighlightStart;
			OnObjectHighlightEvent onObjectHighlightEvent2;
			do
			{
				onObjectHighlightEvent2 = onObjectHighlightEvent;
				OnObjectHighlightEvent value2 = (OnObjectHighlightEvent)Delegate.Remove(onObjectHighlightEvent2, value);
				onObjectHighlightEvent = Interlocked.CompareExchange(ref OnObjectHighlightStart, value2, onObjectHighlightEvent2);
			}
			while ((object)onObjectHighlightEvent != onObjectHighlightEvent2);
		}

		[CompilerGenerated]
		[Token(Token = "0x6000025")]
		[Address(RVA = "0x770C0F8", Offset = "0x770C0F8", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_0019:\n\t;\n\tv78 = System.Threading.Interlocked::CompareExchange(&this.OnObjectHighlightEnd (HighlightPlus.OnObjectHighlightEvent), v88, v83);\n\tv62 = v78 == v83;\nL_FFFFFFFF:\n\tv83 = v78;\n\tif (v62) goto L_0044;\nL_002B:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_0019;\n\tv95 = *([v88 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnObjectHighlightEvent;\n\tif (v95) goto L_0019;\n\tthrow System.InvalidCastException;\nL_0044:\n\treturn;\nL_FFFFFFFF:\n\tv83 = this.OnObjectHighlightEnd;\n\tgoto L_002B;\n")]
		public void add_OnObjectHighlightEnd(OnObjectHighlightEvent value)
		{
			OnObjectHighlightEvent onObjectHighlightEvent = OnObjectHighlightEnd;
			OnObjectHighlightEvent onObjectHighlightEvent2;
			do
			{
				onObjectHighlightEvent2 = onObjectHighlightEvent;
				OnObjectHighlightEvent value2 = (OnObjectHighlightEvent)Delegate.Combine(onObjectHighlightEvent2, value);
				onObjectHighlightEvent = Interlocked.CompareExchange(ref OnObjectHighlightEnd, value2, onObjectHighlightEvent2);
			}
			while ((object)onObjectHighlightEvent != onObjectHighlightEvent2);
		}

		[CompilerGenerated]
		[Token(Token = "0x6000026")]
		[Address(RVA = "0x770C19C", Offset = "0x770C19C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_0019:\n\t;\n\tv78 = System.Threading.Interlocked::CompareExchange(&this.OnObjectHighlightEnd (HighlightPlus.OnObjectHighlightEvent), v88, v83);\n\tv62 = v78 == v83;\nL_FFFFFFFF:\n\tv83 = v78;\n\tif (v62) goto L_0044;\nL_002B:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_0019;\n\tv95 = *([v88 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnObjectHighlightEvent;\n\tif (v95) goto L_0019;\n\tthrow System.InvalidCastException;\nL_0044:\n\treturn;\nL_FFFFFFFF:\n\tv83 = this.OnObjectHighlightEnd;\n\tgoto L_002B;\n")]
		public void remove_OnObjectHighlightEnd(OnObjectHighlightEvent value)
		{
			OnObjectHighlightEvent onObjectHighlightEvent = OnObjectHighlightEnd;
			OnObjectHighlightEvent onObjectHighlightEvent2;
			do
			{
				onObjectHighlightEvent2 = onObjectHighlightEvent;
				OnObjectHighlightEvent value2 = (OnObjectHighlightEvent)Delegate.Remove(onObjectHighlightEvent2, value);
				onObjectHighlightEvent = Interlocked.CompareExchange(ref OnObjectHighlightEnd, value2, onObjectHighlightEvent2);
			}
			while ((object)onObjectHighlightEvent != onObjectHighlightEvent2);
		}

		[CompilerGenerated]
		[Token(Token = "0x6000027")]
		[Address(RVA = "0x770C240", Offset = "0x770C240", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_0019:\n\t;\n\tv78 = System.Threading.Interlocked::CompareExchange(&this.OnObjectHighlightStateChange (HighlightPlus.OnObjectHighlightStateEvent), v88, v83);\n\tv62 = v78 == v83;\nL_FFFFFFFF:\n\tv83 = v78;\n\tif (v62) goto L_0044;\nL_002B:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_0019;\n\tv95 = *([v88 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnObjectHighlightStateEvent;\n\tif (v95) goto L_0019;\n\tthrow System.InvalidCastException;\nL_0044:\n\treturn;\nL_FFFFFFFF:\n\tv83 = this.OnObjectHighlightStateChange;\n\tgoto L_002B;\n")]
		public void add_OnObjectHighlightStateChange(OnObjectHighlightStateEvent value)
		{
			OnObjectHighlightStateEvent onObjectHighlightStateEvent = OnObjectHighlightStateChange;
			OnObjectHighlightStateEvent onObjectHighlightStateEvent2;
			do
			{
				onObjectHighlightStateEvent2 = onObjectHighlightStateEvent;
				OnObjectHighlightStateEvent value2 = (OnObjectHighlightStateEvent)Delegate.Combine(onObjectHighlightStateEvent2, value);
				onObjectHighlightStateEvent = Interlocked.CompareExchange(ref OnObjectHighlightStateChange, value2, onObjectHighlightStateEvent2);
			}
			while ((object)onObjectHighlightStateEvent != onObjectHighlightStateEvent2);
		}

		[CompilerGenerated]
		[Token(Token = "0x6000028")]
		[Address(RVA = "0x770C2E4", Offset = "0x770C2E4", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_0019:\n\t;\n\tv78 = System.Threading.Interlocked::CompareExchange(&this.OnObjectHighlightStateChange (HighlightPlus.OnObjectHighlightStateEvent), v88, v83);\n\tv62 = v78 == v83;\nL_FFFFFFFF:\n\tv83 = v78;\n\tif (v62) goto L_0044;\nL_002B:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_0019;\n\tv95 = *([v88 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnObjectHighlightStateEvent;\n\tif (v95) goto L_0019;\n\tthrow System.InvalidCastException;\nL_0044:\n\treturn;\nL_FFFFFFFF:\n\tv83 = this.OnObjectHighlightStateChange;\n\tgoto L_002B;\n")]
		public void remove_OnObjectHighlightStateChange(OnObjectHighlightStateEvent value)
		{
			OnObjectHighlightStateEvent onObjectHighlightStateEvent = OnObjectHighlightStateChange;
			OnObjectHighlightStateEvent onObjectHighlightStateEvent2;
			do
			{
				onObjectHighlightStateEvent2 = onObjectHighlightStateEvent;
				OnObjectHighlightStateEvent value2 = (OnObjectHighlightStateEvent)Delegate.Remove(onObjectHighlightStateEvent2, value);
				onObjectHighlightStateEvent = Interlocked.CompareExchange(ref OnObjectHighlightStateChange, value2, onObjectHighlightStateEvent2);
			}
			while ((object)onObjectHighlightStateEvent != onObjectHighlightStateEvent2);
		}

		[CompilerGenerated]
		[Token(Token = "0x6000029")]
		[Address(RVA = "0x770C388", Offset = "0x770C388", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_0019:\n\t;\n\tv78 = System.Threading.Interlocked::CompareExchange(&this.OnRendererHighlightStart (HighlightPlus.OnRendererHighlightEvent), v88, v83);\n\tv62 = v78 == v83;\nL_FFFFFFFF:\n\tv83 = v78;\n\tif (v62) goto L_0044;\nL_002B:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_0019;\n\tv95 = *([v88 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnRendererHighlightEvent;\n\tif (v95) goto L_0019;\n\tthrow System.InvalidCastException;\nL_0044:\n\treturn;\nL_FFFFFFFF:\n\tv83 = this.OnRendererHighlightStart;\n\tgoto L_002B;\n")]
		public void add_OnRendererHighlightStart(OnRendererHighlightEvent value)
		{
			OnRendererHighlightEvent onRendererHighlightEvent = OnRendererHighlightStart;
			OnRendererHighlightEvent onRendererHighlightEvent2;
			do
			{
				onRendererHighlightEvent2 = onRendererHighlightEvent;
				OnRendererHighlightEvent value2 = (OnRendererHighlightEvent)Delegate.Combine(onRendererHighlightEvent2, value);
				onRendererHighlightEvent = Interlocked.CompareExchange(ref OnRendererHighlightStart, value2, onRendererHighlightEvent2);
			}
			while ((object)onRendererHighlightEvent != onRendererHighlightEvent2);
		}

		[CompilerGenerated]
		[Token(Token = "0x600002A")]
		[Address(RVA = "0x770C42C", Offset = "0x770C42C", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_0019:\n\t;\n\tv78 = System.Threading.Interlocked::CompareExchange(&this.OnRendererHighlightStart (HighlightPlus.OnRendererHighlightEvent), v88, v83);\n\tv62 = v78 == v83;\nL_FFFFFFFF:\n\tv83 = v78;\n\tif (v62) goto L_0044;\nL_002B:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_0019;\n\tv95 = *([v88 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnRendererHighlightEvent;\n\tif (v95) goto L_0019;\n\tthrow System.InvalidCastException;\nL_0044:\n\treturn;\nL_FFFFFFFF:\n\tv83 = this.OnRendererHighlightStart;\n\tgoto L_002B;\n")]
		public void remove_OnRendererHighlightStart(OnRendererHighlightEvent value)
		{
			OnRendererHighlightEvent onRendererHighlightEvent = OnRendererHighlightStart;
			OnRendererHighlightEvent onRendererHighlightEvent2;
			do
			{
				onRendererHighlightEvent2 = onRendererHighlightEvent;
				OnRendererHighlightEvent value2 = (OnRendererHighlightEvent)Delegate.Remove(onRendererHighlightEvent2, value);
				onRendererHighlightEvent = Interlocked.CompareExchange(ref OnRendererHighlightStart, value2, onRendererHighlightEvent2);
			}
			while ((object)onRendererHighlightEvent != onRendererHighlightEvent2);
		}

		[CompilerGenerated]
		[Token(Token = "0x600002B")]
		[Address(RVA = "0x770C4D0", Offset = "0x770C4D0", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_0019:\n\t;\n\tv78 = System.Threading.Interlocked::CompareExchange(&this.OnTargetAnimates (HighlightPlus.OnAnimateEvent), v88, v83);\n\tv62 = v78 == v83;\nL_FFFFFFFF:\n\tv83 = v78;\n\tif (v62) goto L_0044;\nL_002B:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_0019;\n\tv95 = *([v88 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnAnimateEvent;\n\tif (v95) goto L_0019;\n\tthrow System.InvalidCastException;\nL_0044:\n\treturn;\nL_FFFFFFFF:\n\tv83 = this.OnTargetAnimates;\n\tgoto L_002B;\n")]
		public void add_OnTargetAnimates(OnAnimateEvent value)
		{
			OnAnimateEvent onAnimateEvent = OnTargetAnimates;
			OnAnimateEvent onAnimateEvent2;
			do
			{
				onAnimateEvent2 = onAnimateEvent;
				OnAnimateEvent value2 = (OnAnimateEvent)Delegate.Combine(onAnimateEvent2, value);
				onAnimateEvent = Interlocked.CompareExchange(ref OnTargetAnimates, value2, onAnimateEvent2);
			}
			while ((object)onAnimateEvent != onAnimateEvent2);
		}

		[CompilerGenerated]
		[Token(Token = "0x600002C")]
		[Address(RVA = "0x770C574", Offset = "0x770C574", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_0019:\n\t;\n\tv78 = System.Threading.Interlocked::CompareExchange(&this.OnTargetAnimates (HighlightPlus.OnAnimateEvent), v88, v83);\n\tv62 = v78 == v83;\nL_FFFFFFFF:\n\tv83 = v78;\n\tif (v62) goto L_0044;\nL_002B:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_0019;\n\tv95 = *([v88 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnAnimateEvent;\n\tif (v95) goto L_0019;\n\tthrow System.InvalidCastException;\nL_0044:\n\treturn;\nL_FFFFFFFF:\n\tv83 = this.OnTargetAnimates;\n\tgoto L_002B;\n")]
		public void remove_OnTargetAnimates(OnAnimateEvent value)
		{
			OnAnimateEvent onAnimateEvent = OnTargetAnimates;
			OnAnimateEvent onAnimateEvent2;
			do
			{
				onAnimateEvent2 = onAnimateEvent;
				OnAnimateEvent value2 = (OnAnimateEvent)Delegate.Remove(onAnimateEvent2, value);
				onAnimateEvent = Interlocked.CompareExchange(ref OnTargetAnimates, value2, onAnimateEvent2);
			}
			while ((object)onAnimateEvent != onAnimateEvent2);
		}

		[CompilerGenerated]
		[Token(Token = "0x600002D")]
		[Address(RVA = "0x770C618", Offset = "0x770C618", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_0019:\n\t;\n\tv78 = System.Threading.Interlocked::CompareExchange(&this.OnIconAnimates (HighlightPlus.OnAnimateEvent), v88, v83);\n\tv62 = v78 == v83;\nL_FFFFFFFF:\n\tv83 = v78;\n\tif (v62) goto L_0044;\nL_002B:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_0019;\n\tv95 = *([v88 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnAnimateEvent;\n\tif (v95) goto L_0019;\n\tthrow System.InvalidCastException;\nL_0044:\n\treturn;\nL_FFFFFFFF:\n\tv83 = this.OnIconAnimates;\n\tgoto L_002B;\n")]
		public void add_OnIconAnimates(OnAnimateEvent value)
		{
			OnAnimateEvent onAnimateEvent = OnIconAnimates;
			OnAnimateEvent onAnimateEvent2;
			do
			{
				onAnimateEvent2 = onAnimateEvent;
				OnAnimateEvent value2 = (OnAnimateEvent)Delegate.Combine(onAnimateEvent2, value);
				onAnimateEvent = Interlocked.CompareExchange(ref OnIconAnimates, value2, onAnimateEvent2);
			}
			while ((object)onAnimateEvent != onAnimateEvent2);
		}

		[CompilerGenerated]
		[Token(Token = "0x600002E")]
		[Address(RVA = "0x770C6BC", Offset = "0x770C6BC", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_0019:\n\t;\n\tv78 = System.Threading.Interlocked::CompareExchange(&this.OnIconAnimates (HighlightPlus.OnAnimateEvent), v88, v83);\n\tv62 = v78 == v83;\nL_FFFFFFFF:\n\tv83 = v78;\n\tif (v62) goto L_0044;\nL_002B:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_0019;\n\tv95 = *([v88 @ X0_v4 (System.Delegate)]) == HighlightPlus.OnAnimateEvent;\n\tif (v95) goto L_0019;\n\tthrow System.InvalidCastException;\nL_0044:\n\treturn;\nL_FFFFFFFF:\n\tv83 = this.OnIconAnimates;\n\tgoto L_002B;\n")]
		public void remove_OnIconAnimates(OnAnimateEvent value)
		{
			OnAnimateEvent onAnimateEvent = OnIconAnimates;
			OnAnimateEvent onAnimateEvent2;
			do
			{
				onAnimateEvent2 = onAnimateEvent;
				OnAnimateEvent value2 = (OnAnimateEvent)Delegate.Remove(onAnimateEvent2, value);
				onAnimateEvent = Interlocked.CompareExchange(ref OnIconAnimates, value2, onAnimateEvent2);
			}
			while ((object)onAnimateEvent != onAnimateEvent2);
		}

		[Token(Token = "0x6000035")]
		[Address(RVA = "0x770CAF8", Offset = "0x770CAF8", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Inequality(this.previousSettings, 0);\n\tv63 = ~v55;\n\tif (v63) goto L_0043;\n\tHighlightPlus.HighlightProfile::Load(this.previousSettings, this);\n\treturn;\nL_0043:\n\treturn;\n")]
		public void RestorePreviousHighlightEffectSettings()
		{
			if (previousSettings != null)
			{
				previousSettings.Load(this);
			}
		}

		[RuntimeInitializeOnLoadMethod]
		[Token(Token = "0x6000036")]
		[Address(RVA = "0x770CBB4", Offset = "0x770CBB4", Length = "0x190")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\nL_003F:\n\tv84 = v82.<>9__347_0 == 0;\n\tif (v84) goto L_0066;\n\tv111 = v82.<>9__347_0;\nL_0048:\n\tv126 = System.Collections.Generic.List`1<HighlightPlus.HighlightEffect>::RemoveAll(v75.effects, v111);\n\tgoto L_0051;\nL_0066:\n\tgoto L_006E;\n\tv182 = v75.effects == 0;\n\tv118 = ~v182;\n\tv111 = v144;\n\tif (v118) goto L_0048;\n\tthrow System.NullReferenceException;\nL_0029:\n\tgoto L_002E;\nL_0051:\n\tv156.sharedTemplateMaterialsRefCount = 0;\n\treturn;\nL_006E:\n\tv144 = new System.Predicate`1<HighlightPlus.HighlightEffect>();\n\tSystem.Predicate`1<HighlightPlus.HighlightEffect>::.ctor(v144, v139.<>9, Il2CppMethodInfo);\n\tv180.<>9__347_0 = v144;\nL_002E:\n\tv60.lastSelected = 0;\n\tv68.lastHighlighted = 0;\n\tgoto L_003F;\n")]
		private static void DomainReloadDisabledSupport()
		{
			lastSelected = null;
			lastHighlighted = null;
			Predicate<object> match;
			if (_003C_003Ec._003C_003E9__347_0 != null)
			{
				match = (Predicate<object>)_003C_003Ec._003C_003E9__347_0;
			}
			else
			{
				Predicate<HighlightEffect> predicate = (_003C_003Ec._003C_003E9__347_0 = (HighlightEffect i) => i == null);
				bool flag = effects == null;
				bool flag2 = !flag;
				match = (Predicate<object>)predicate;
				if (!flag2)
				{
					throw new NullReferenceException();
				}
			}
			int num = effects.RemoveAll(match);
			sharedTemplateMaterialsRefCount = 0;
		}

		[Token(Token = "0x6000037")]
		[Address(RVA = "0x770CD44", Offset = "0x770CD44", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHighlightPlus.HighlightEffect::InitIfNeeded(this);\n\tHighlightPlus.HighlightEffect::CheckLabel(this, 0);\n\treturn;\n")]
		private void OnEnable()
		{
			InitIfNeeded();
			CheckLabel(disabling: false);
		}

		[Token(Token = "0x6000038")]
		[Address(RVA = "0x770CD6C", Offset = "0x770CD6C", Length = "0x218")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv62 = this.isInitialized != 1;\n\tif (v62) goto L_0061;\n\tgoto L_0041;\nL_0045:\n\tv89 = UnityEngine.Object::op_Equality(v115.fxMatOutlineTemplate, 0);\n\tv205 = ~v89;\n\tv92 = ~v205;\n\tif (v92) goto L_0061;\n\tgoto L_004E;\nL_004E:\n\tv156.sortFrameCount = 0;\n\tgoto L_0055;\nL_0055:\n\tv187 = v185.effects == 0;\n\tv188 = ~v187;\n\tif (v188) goto L_007A;\n\tgoto L_00C0;\nL_0061:\n\tHighlightPlus.HighlightEffect::Init(this);\n\tgoto L_004E;\nL_007A:\n\tv229 = System.Collections.Generic.List`1<HighlightPlus.HighlightEffect>::Contains(v185.effects, this);\n\tv258 = v229 == 0;\n\tv259 = ~v258;\n\tif (v259) goto L_00AF;\n\tgoto L_0087;\n\tgoto L_00B5;\nL_00AF:\n\tHighlightPlus.HighlightEffect::UpdateVisibilityState(this);\n\treturn;\nL_00B5:\n\tSystem.Collections.Generic.List`1<HighlightPlus.HighlightEffect>::Add(v248, this);\n\tHighlightPlus.HighlightEffect::UpdateVisibilityState(this);\n\treturn;\nL_00C0:\n\tthrow System.NullReferenceException;\nL_0025:\n\tv48 = this.rms == 0;\n\tif (v48) goto L_0061;\nL_0041:\n\tgoto L_0045;\nL_0087:\n\tv248 = v254.effects;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void InitIfNeeded()
		{
			if (rms == null || !isInitialized || fxMatOutlineTemplate == null)
			{
				Init();
			}
			HighlightPlusRenderPassFeature.sortFrameCount = 0;
			if (effects != null)
			{
				if (effects.Contains(this))
				{
					UpdateVisibilityState();
					return;
				}
				List<HighlightEffect> list = effects;
				list.Add(this);
				UpdateVisibilityState();
				return;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000039")]
		[Address(RVA = "0x770D344", Offset = "0x770D344", Length = "0x6AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\nL_0035:\n\tv112 = 0xB28A000 + 0xB38;\n\tv124 = v63.offsets;\n\tv65 = v63.offsets == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_0047;\n\tgoto L_005B;\nL_0047:\n\tgoto L_0053;\nL_0053:\n\tv100 = v124.Length == 8;\nL_FFFFFFFF:\n\tv136 = 0;\nL_FFFFFFFF:\n\tv158 = v112;\n\tif (v100) goto L_00D2;\nL_005B:\n\tv121 = \"SzArrayNew\"(*([v112 @ X22_v7 (System.Int32)]), 8, v31, v32, v33, v34, v35, v36, 0, v38, v39, v40, v41, v42, v43, v44);\n\t*([v121 @ X0_v133 (UnityEngine.Vector4[])+20]) = *([92456E0]);\n\t*([v121 @ X0_v133 (UnityEngine.Vector4[])+30]) = *([92456C0]);\n\t*([v121 @ X0_v133 (UnityEngine.Vector4[])+40]) = *([9250820]);\n\t*([v121 @ X0_v133 (UnityEngine.Vector4[])+50]) = *([924F4D0]);\n\t*([v121 @ X0_v133 (UnityEngine.Vector4[])+60]) = *([930A8D0]);\n\t*([v121 @ X0_v133 (UnityEngine.Vector4[])+70]) = *([930A8E0]);\n\t*([v121 @ X0_v133 (UnityEngine.Vector4[])+80]) = *([930A8F0]);\n\tv136 = *([930A900]);\n\t*([v121 @ X0_v133 (UnityEngine.Vector4[])+90]) = *([930A900]);\n\tgoto L_00CE;\nL_00D2:\n\tv167 = this.corners;\n\tv168 = this.corners == 0;\n\tif (v168) goto L_00E3;\n\tv265 = v167.Length == 8;\n\tif (v265) goto L_00EB;\nL_00E3:\n\tv282 = \"SzArrayNew\"(*([v158 @ X22_v3 (System.Int32)]), 8, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v136, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tthis.corners = v282;\nL_FFFFFFFF:\n\t;\nL_00EB:\n\tHighlightPlus.HighlightEffect::InitCommandBuffer(this);\n\tgoto L_00F5;\nL_00F5:\n\tgoto L_00F8;\nL_00F8:\n\tv462 = UnityEngine.Object::op_Equality(v444.quadMesh, 0);\n\tv474 = ~v462;\n\tv475 = ~v474;\n\tif (v475) goto L_012E;\n\tgoto L_0105;\nL_0105:\n\tgoto L_0108;\nL_0108:\n\tv542 = UnityEngine.Object::op_Equality(v511.cubeMesh, 0);\n\tv560 = ~v542;\n\tv561 = ~v560;\n\tif (v561) goto L_014F;\nL_FFFFFFFF:\n\tv601 = this.target;\n\tgoto L_0113;\nL_0113:\n\tv611 = UnityEngine.Object::op_Equality(v601, 0);\n\tv634 = ~v611;\n\tv635 = ~v634;\n\tif (v635) goto L_017E;\n\tv698 = this.glowPasses;\n\tv658 = this.glowPasses == 0;\n\tv659 = ~v658;\n\tif (v659) goto L_01B6;\n\tgoto L_01BD;\nL_012E:\n\tHighlightPlus.HighlightEffect::BuildQuad(v462);\n\tgoto L_0105;\nL_014F:\n\tgoto L_015D;\nL_017E:\n\tgoto L_0183;\nL_0183:\n\tgoto L_0184;\nL_0184:\n\tv703 = this + 0x478;\n\tv757 = UnityEngine.Object::op_Inequality(this.effectTarget, 0);\n\tv780 = v757 == 0;\n\tif (v780) goto L_01AD;\n\t*([v703 @ X20_v22]) = this.effectTarget;\n\tv698 = this.glowPasses;\n\tv807 = this.glowPasses == 0;\n\tv697 = ~v807;\n\tif (v697) goto L_01B6;\n\tgoto L_01BD;\nL_01AD:\n\tv801 = UnityEngine.Component::get_transform(this);\n\t*([v703 @ X20_v22]) = v801;\n\tv698 = this.glowPasses;\n\tv696 = this.glowPasses == 0;\n\tif (v696) goto L_01BD;\nL_01B6:\n\tv705 = v698.Length == 0;\n\tv706 = ~v705;\n\tif (v706) goto L_01FE;\nL_01BD:\n\t// 445 NewArr v723 @ X0_v44 (HighlightPlus.GlowPassData[]), typeof(HighlightPlus.GlowPassData[]), 4\n\tthis.glowPasses = v723;\n\tv253 = this.glowPasses;\n\t*([v253 @ X8_v36 (HighlightPlus.GlowPassData[])+20]) = *([930A910]);\n\t*([v253 @ X8_v36 (HighlightPlus.GlowPassData[])+30]) = 0.0078125d;\n\t*([v253 @ X8_v36 (HighlightPlus.GlowPassData[])+38]) = *([930A920]);\n\t*([v253 @ X8_v36 (HighlightPlus.GlowPassData[])+48]) = 0.0078125d;\n\t*([v253 @ X8_v36 (HighlightPlus.GlowPassData[])+50]) = T;\n\t*([v253 @ X8_v36 (HighlightPlus.GlowPassData[])+60]) = 0.0078125d;\n\t*([v253 @ X8_v36 (HighlightPlus.GlowPassData[])+68]) = *([930A940]);\n\t*([v253 @ X8_v36 (HighlightPlus.GlowPassData[])+78]) = 0.0078125d;\n\tv804 = UnityEngine.SystemInfo::get_supportsInstancing();\n\tgoto L_0210;\nL_FFFFFFFF:\n\tv804 = 0;\n\tv826 = this.glowPropertyBlock == 0;\n\tif (v826) goto L_0245;\n\tv832 = this.outlinePropertyBlock == 0;\nL_FFFFFFFF:\n\t;\n\tif (v832) goto L_0255;\nL_0227:\n\tHighlightPlus.HighlightEffect::InitTemplateMaterials(this);\n\tv857 = this.profileSync != 1;\n\tif (v857) goto L_0279;\nL_0238:\n\tgoto L_023C;\nL_023C:\n\tv895 = UnityEngine.Object::op_Inequality(this.profile, 0);\n\tv909 = ~v895;\n\tv897 = ~v909;\n\tif (v897) goto L_0277;\n\tgoto L_0279;\nL_0245:\n\tv846 = new UnityEngine.MaterialPropertyBlock();\n\tUnityEngine.MaterialPropertyBlock::.ctor(v846);\n\tthis.glowPropertyBlock = v846;\n\tv908 = this.outlinePropertyBlock == 0;\n\tv833 = ~v908;\nL_FFFFFFFF:\n\t;\n\tif (v833) goto L_0227;\nL_0255:\n\tv868 = new UnityEngine.MaterialPropertyBlock();\n\tUnityEngine.MaterialPropertyBlock::.ctor(v868);\n\tthis.outlinePropertyBlock = v868;\n\tHighlightPlus.HighlightEffect::InitTemplateMaterials(this);\n\tv876 = this.profileSync == 1;\n\tif (v876) goto L_0238;\n\tgoto L_0279;\nL_0277:\n\tHighlightPlus.HighlightProfile::Load(this.profile, this);\nL_0279:\n\tthis.isInitialized = 1;\n\treturn;\nL_0028:\n\tthis.lastOutlineVisibility = this.outlineVisibility;\n\tthis.debugColor = *([930A8C0]);\n\tthis.blackColor = 0;\n\tgoto L_0035;\nL_00CE:\n\tv164.offsets = v121;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv158 = v112;\nL_015D:\n\tv633 = UnityEngine.Resources::GetBuiltinResource(\"Cube.fbx\");\n\tgoto L_0167;\nL_0167:\n\tv678.cubeMesh = v633;\nL_FFFFFFFF:\n\tv601 = this.target;\n\tgoto L_0113;\nL_01FE:\n\tv745 = UnityEngine.Shader::PropertyToID(\"_HPSourceRT\");\n\tthis.sourceRT = v745;\n\tv778 = this.GPUInstancing != 1;\n\tif (v778) goto L_FFFFFFFF;\nL_0210:\n\tthis.useGPUInstancing = v804;\n\tv806 = UnityEngine.SystemInfo::get_usesReversedZBuffer();\n\tthis.usesReversedZBuffer = v806;\n\tv822 = this.useGPUInstancing != 1;\nL_FFFFFFFF:\n\t;\n\tif (v822) goto L_0227;\n")]
		private void Init()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::Init");
		}

		[Token(Token = "0x600003A")]
		[Address(RVA = "0x770E678", Offset = "0x770E678", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHighlightPlus.HighlightEffect::SetupMaterial(this);\n\treturn;\n")]
		private void Start()
		{
			SetupMaterial();
		}

		[Token(Token = "0x600003B")]
		[Address(RVA = "0x770EA40", Offset = "0x770EA40", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHighlightPlus.HighlightEffect::UpdateMaterialProperties(this, 0);\n\treturn;\n")]
		public void OnDidApplyAnimationProperties()
		{
			UpdateMaterialProperties();
		}

		[Token(Token = "0x600003C")]
		[Address(RVA = "0x771263C", Offset = "0x771263C", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0021:\n\tv53 = UnityEngine.Object::op_Inequality(this.label, 0);\n\tv55 = ~v53;\n\tv56 = ~v55;\n\tif (v56) goto L_0043;\n\tv135 = 0xB28F000 + 0x80;\n\tv70 = *([B7951B2]) & 1;\n\tv71 = v70 == 0;\n\tv104 = v135;\n\tif (v71) goto L_0053;\nL_002C:\n\tv137 = *([v135 @ X20_v6 (System.Int32)]);\n\tv96 = *([v137 @ X0_v26+E4]) == 0;\n\tif (v96) goto L_005A;\nL_0030:\n\tv131 = *([v137 @ X0_v26+B8]);\n\tv154 = *([v131 @ X8_v16+128]);\n\tv143 = *([v131 @ X8_v16+128]) == 0;\n\tv125 = ~v143;\n\tif (v125) goto L_006A;\n\tgoto L_006C;\nL_0043:\n\tv85 = HighlightPlus.HighlightLabel::Hide(this.label);\n\tv135 = 0xB28F000 + 0x80;\n\tv110 = *([B7951B2]) & 1;\n\tv111 = v110 == 0;\n\tv87 = ~v111;\n\tv104 = v135;\n\tif (v87) goto L_002C;\nL_0053:\n\t*([B7951B2]) = 1;\n\tv137 = *([v104 @ X20_v7 (System.Int32)]);\n\tv172 = *([v137 @ X0_v26+E4]) == 0;\n\tv140 = ~v172;\n\tv135 = v104;\n\tif (v140) goto L_0030;\nL_005A:\n\tv170 = *([v135 @ X20_v6 (System.Int32)]);\n\tv132 = *([v170 @ X0_v10+B8]);\n\tv154 = *([v132 @ X8_v9+128]);\nL_006A:\n\tv169 = System.Collections.Generic.List`1<System.Object>::Remove(v154, this);\n\treturn;\nL_006C:\n\tthrow System.NullReferenceException;\nL_0018:\n\tHighlightPlus.HighlightEffect::UpdateMaterialProperties(this, 1);\n\tgoto L_0021;\n")]
		private void OnDisable()
		{
			//IL_008b: Expected O, but got I4
			//IL_01b3: Expected O, but got I4
			//IL_01c3: Expected O, but got I
			//IL_01d3: Expected O, but got I
			//IL_0173: Expected O, but got I4
			//IL_00c0: Expected O, but got I
			//IL_00d0: Expected O, but got I
			UpdateMaterialProperties(disabling: true);
			int num;
			int num3;
			if (!(label != null))
			{
				num = 187232256 + 128;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B7951B2]");
				int num2 = (int)((nint)0 & (nint)1);
				bool flag = num2 == 0;
				num3 = num;
				if (!flag)
				{
					goto IL_0083;
				}
			}
			else
			{
				label.Hide();
				num = 187232256 + 128;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B7951B2]");
				int num4 = (int)((nint)0 & (nint)1);
				bool flag2 = num4 == 0;
				bool flag3 = !flag2;
				num3 = num;
				if (flag3)
				{
					goto IL_0083;
				}
			}
			_ = 1;
			object obj = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ X0_v26+E4]");
			bool flag4 = (nint)0 == 0;
			bool flag5 = !flag4;
			num = num3;
			if (flag5)
			{
				goto IL_00b0;
			}
			goto IL_01ab;
			IL_01d8:
			object obj2;
			bool flag6 = ((List<object>)obj2).Remove((object)this);
			return;
			IL_00b0:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ X0_v26+B8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ X8_v16+128]");
			obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ X8_v16+128]");
			if ((nint)0 == 0)
			{
				throw new NullReferenceException();
			}
			goto IL_01d8;
			IL_01ab:
			object obj4 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ X0_v10+B8]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ X8_v9+128]");
			obj2 = 0;
			goto IL_01d8;
			IL_0083:
			obj = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ X0_v26+E4]");
			if ((nint)0 != 0)
			{
				goto IL_00b0;
			}
			goto IL_01ab;
		}

		[Token(Token = "0x600003D")]
		[Address(RVA = "0x7712824", Offset = "0x7712824", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHighlightPlus.HighlightEffect::SetupMaterial(this);\n\treturn;\n")]
		private void Reset()
		{
			SetupMaterial();
		}

		[Token(Token = "0x600003E")]
		[Address(RVA = "0x7712828", Offset = "0x7712828", Length = "0x344")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_FFFFFFFF:\n\tv69 = 0;\n\tgoto L_0037;\nL_FFFFFFFF:\n\tv82 = 0;\n\tgoto L_0045;\nL_FFFFFFFF:\n\tv93 = 0;\n\tgoto L_0053;\nL_FFFFFFFF:\n\tv107 = 1f;\n\tgoto L_0064;\nL_FFFFFFFF:\n\tv120 = 1f;\n\tgoto L_0074;\nL_FFFFFFFF:\n\tv131 = 0;\n\tgoto L_0082;\nL_FFFFFFFF:\n\tv145 = 0;\n\tgoto L_0096;\nL_FFFFFFFF:\n\tv160 = 0;\n\tgoto L_00AD;\nL_FFFFFFFF:\n\tv174 = 0;\n\tgoto L_00C0;\nL_FFFFFFFF:\n\tv187 = 0;\n\tgoto L_00D3;\nL_FFFFFFFF:\n\tv203 = 1f;\n\tgoto L_00E8;\nL_FFFFFFFF:\n\tv214 = 0;\n\tgoto L_00F6;\nL_FFFFFFFF:\n\tv225 = 0;\n\tgoto L_0104;\nL_FFFFFFFF:\n\tv225 = this.labelLineLength;\nL_010D:\n\tv233 = UnityEngine.Object::op_Equality(this.labelPrefab, 0);\n\tv235 = ~v233;\n\tv236 = ~v235;\n\tif (v236) goto L_0145;\nL_FFFFFFFF:\n\tv273 = this.label;\n\tgoto L_0119;\nL_0119:\n\tv278 = UnityEngine.Object::op_Inequality(v273, 0);\n\tv289 = ~v278;\n\tif (v289) goto L_015F;\n\tgoto L_0129;\nL_0129:\n\tv330 = UnityEngine.Object::op_Equality(this.labelTarget, 0);\n\tv377 = v330 == 0;\n\tif (v377) goto L_0160;\n\tv380 = UnityEngine.Component::get_transform(this);\nL_FFFFFFFF:\n\tv369 = v380;\n\tgoto L_FFFFFFFF;\nL_0145:\n\tv261 = UnityEngine.Resources::Load(\"HighlightPlus/Label\");\n\tthis.labelPrefab = v261;\nL_FFFFFFFF:\n\tv273 = this.label;\n\tgoto L_0119;\nL_015F:\n\treturn;\nL_0160:\n\tv369 = this.labelTarget;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 MakeStruct Vector3_arg @ V0_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v400.vector3Zero (UnityEngine.Vector3), v400.vector3Zero.y (System.Single), v400.vector3Zero.z (System.Single)\nL_FFFFFFFF:\n\t// -1 MakeStruct Vector3_arg @ V3_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, this.labelVerticalOffset (System.Single), 0\nL_FFFFFFFF:\n\t// -1 MakeStruct Vector2_arg @ V6_v1 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), this.labelViewportOffset (UnityEngine.Vector2), this.labelViewportOffset.y (System.Single)\n\tv358 = HighlightPlus.HighlightLabel::SetPosition(v358, v369, Vector3_arg, Vector3_arg, Vector2_arg);\n\treturn;\nL_0021:\n\t// 33 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv47 = ~v35;\n\tv48 = this.outlineGradientKnee & v47;\n\tthis.outlineGradientKnee = v48;\n\tv50 = ~this.extraCoveragePixels;\n\tv51 = this.extraCoveragePixels & v50;\n\tthis.extraCoveragePixels = v51;\n\tv69 = this.outlineWidth;\n\tv53 = this.outlineWidth < 0;\n\tv60 = ~v53;\n\tif (v60) goto L_0037;\nL_0037:\n\tthis.outlineWidth = v69;\n\tv82 = this.glowWidth;\n\tv71 = this.glowWidth < 0;\n\tv77 = ~v71;\n\tif (v77) goto L_0045;\nL_0045:\n\tthis.glowWidth = v82;\n\tv93 = this.glowAnimationSpeed;\n\tv84 = this.glowAnimationSpeed < 0;\n\tv90 = ~v84;\n\tif (v90) goto L_0053;\nL_0053:\n\tthis.glowAnimationSpeed = v93;\n\tv107 = this.glowDistanceScaleBias;\n\tv96 = this.glowDistanceScaleBias < 1f;\n\tv104 = ~v96;\n\tif (v104) goto L_0064;\nL_0064:\n\tthis.glowDistanceScaleBias = v107;\n\tv120 = this.innerGlowPower;\n\tv109 = this.innerGlowPower < 1f;\n\tv117 = ~v109;\n\tif (v117) goto L_0074;\nL_0074:\n\tthis.innerGlowPower = v120;\n\tv131 = this.overlayAnimationSpeed;\n\tv122 = this.overlayAnimationSpeed < 0;\n\tv128 = ~v122;\n\tif (v128) goto L_0082;\nL_0082:\n\tthis.overlayAnimationSpeed = v131;\n\t// 134 NotImplemented \"Instruction FCMGT not yet implemented.\"\n\t// 135 NotImplemented \"Instruction BIT not yet implemented.\"\n\tthis.targetFXTransitionDuration = this.targetFXTransitionDuration;\n\tv145 = this.targetFXFadePower;\n\tv136 = this.targetFXFadePower < 0;\n\tv142 = ~v136;\n\tif (v142) goto L_0096;\nL_0096:\n\tthis.targetFXFadePower = v145;\n\t// 152 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv147 = ~v38;\n\tv148 = this.iconFXAnimationAmount & v147;\n\tthis.iconFXAnimationAmount = v148;\n\t// 157 NotImplemented \"Instruction FCMGT not yet implemented.\"\n\t// 158 NotImplemented \"Instruction BIT not yet implemented.\"\n\tthis.iconFXTransitionDuration = this.iconFXTransitionDuration;\n\tv160 = this.iconFXScale;\n\tv151 = this.iconFXScale < 0;\n\tv157 = ~v151;\n\tif (v157) goto L_00AD;\nL_00AD:\n\tthis.iconFXScale = v160;\n\t// 175 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv162 = ~4.709769656E-315d;\n\tv163 = this.seeThroughDepthOffset & v162;\n\tthis.seeThroughDepthOffset = v163;\n\tv174 = this.seeThroughBorderWidth;\n\tv165 = this.seeThroughBorderWidth < 0;\n\tv171 = ~v165;\n\tif (v171) goto L_00C0;\nL_00C0:\n\tthis.seeThroughBorderWidth = v174;\n\t// 195 NotImplemented \"Instruction FCMGT not yet implemented.\"\n\t// 196 NotImplemented \"Instruction BIT not yet implemented.\"\n\tthis.outlineDistanceScaleBias = this.outlineDistanceScaleBias;\n\tv187 = this.outlinePatternDistortionAmount;\n\tv178 = this.outlinePatternDistortionAmount < 0;\n\tv184 = ~v178;\n\tif (v184) goto L_00D3;\nL_00D3:\n\tthis.outlinePatternDistortionAmount = v187;\n\t// 213 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv190 = this.outlinePatternScale & -1;\n\tthis.outlinePatternScale = v190;\n\tv203 = this.outlinePatternStopMotionScale;\n\tv192 = this.outlinePatternStopMotionScale < 1f;\n\tv200 = ~v192;\n\tif (v200) goto L_00E8;\nL_00E8:\n\tthis.outlinePatternStopMotionScale = v203;\n\tv214 = this.outlineDashSpeed;\n\tv205 = this.outlineDashSpeed < 0;\n\tv211 = ~v205;\n\tif (v211) goto L_00F6;\nL_00F6:\n\tthis.outlineDashSpeed = v214;\n\tv216 = this.labelLineLength < 0;\n\tv222 = ~v216;\n\tif (v222) goto L_FFFFFFFF;\nL_0104:\n\tthis.labelLineLength = v225;\n\tgoto L_010D;\n")]
		private void OnValidate()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::OnValidate");
		}

		[Token(Token = "0x600003F")]
		[Address(RVA = "0x7712B6C", Offset = "0x7712B6C", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0017;\nL_0017:\n\tv51 = UnityEngine.Object::op_Inequality(mat, 0);\n\tv58 = ~v51;\n\tif (v58) goto L_0042;\n\tgoto L_0027;\nL_0027:\n\tUnityEngine.Object::DestroyImmediate(mat);\n\treturn;\nL_0042:\n\treturn;\n")]
		private void DestroyMaterial(Material mat)
		{
			if (mat != null)
			{
				UnityEngine.Object.DestroyImmediate(mat);
			}
		}

		[Token(Token = "0x6000040")]
		[Address(RVA = "0x7712C3C", Offset = "0x7712C3C", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = mm == 0;\n\tif (v0) goto L_0064;\n\tv36 = mm.Length < 1;\n\tif (v36) goto L_0064;\n\tv149 = 0;\n\tgoto L_0037;\nL_0025:\n\tUnityEngine.Object::DestroyImmediate(mm[v149 @ X22_v5 (System.Int32)]);\nL_0026:\n\tv149 = v149 + 1;\n\tv134 = v149 >= mm.Length;\n\tif (v134) goto L_0064;\nL_0037:\n\tgoto L_003B;\nL_003B:\n\tgoto L_003F;\nL_003F:\n\tv191 = UnityEngine.Object::op_Inequality(mm[v149 @ X22_v5 (System.Int32)], 0);\n\tv197 = ~v191;\n\tif (v197) goto L_0026;\n\tgoto L_0056;\nL_0056:\n\tgoto L_0025;\nL_0064:\n\treturn;\n")]
		private void DestroyMaterialArray(Material[] mm)
		{
			if (mm == null || mm.Length < 1)
			{
				return;
			}
			int num = 0;
			do
			{
				if (mm[num] != null)
				{
					UnityEngine.Object.DestroyImmediate(mm[num]);
				}
				num++;
			}
			while (num < mm.Length);
		}

		[Token(Token = "0x6000041")]
		[Address(RVA = "0x7712D2C", Offset = "0x7712D2C", Length = "0x200")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv99 = 0x68;\n\tv103 = 0;\n\tv190 = v112 + v99;\n\tgoto L_0032;\nL_0032:\n\tv198 = UnityEngine.Object::op_Inequality(*([v190 @ X8_v6-20]), 0);\n\tv200 = ~v198;\n\tv201 = ~v200;\n\tif (v201) goto L_004C;\n\tv147 = v198;\n\tgoto L_0057;\nL_004C:\n\tv328 = this.rms + v99;\n\tgoto L_0056;\nL_0056:\n\tUnityEngine.Object::DestroyImmediate(*([v328 @ X8_v28-20]));\n\tv147 = *([v328 @ X8_v28-20]);\nL_0057:\n\tv239 = this.rms;\n\tHighlightPlus.HighlightEffect::DestroyMaterialArray(v147, *([v239 @ X8_v11 (ModelMaterials[])+v99 @ X23_v4 (System.Int32)]));\n\tv335 = this.rms + v99;\n\tHighlightPlus.HighlightEffect::DestroyMaterialArray(v147, *([v335 @ X8_v13+8]));\n\tv337 = this.rms + v99;\n\tHighlightPlus.HighlightEffect::DestroyMaterialArray(v147, *([v337 @ X8_v15+10]));\n\tv339 = this.rms + v99;\n\tHighlightPlus.HighlightEffect::DestroyMaterialArray(v147, *([v339 @ X8_v17+18]));\n\tv341 = this.rms + v99;\n\tHighlightPlus.HighlightEffect::DestroyMaterialArray(v147, *([v341 @ X8_v19+20]));\n\tv343 = this.rms + v99;\n\tHighlightPlus.HighlightEffect::DestroyMaterialArray(v147, *([v343 @ X8_v21+28]));\n\tv345 = this.rms + v99;\n\tHighlightPlus.HighlightEffect::DestroyMaterialArray(v147, *([v345 @ X8_v23+30]));\n\tv347 = this.rms + v99;\n\tHighlightPlus.HighlightEffect::DestroyMaterialArray(v147, *([v347 @ X8_v25+38]));\n\tv103 = v103 + 1;\n\tv112 = this.rms;\n\tv99 = v99 + 0xD8;\n\tv348 = this.rms == 0;\n\tv148 = ~v348;\n\tif (v148) goto L_0027;\n\tthrow System.NullReferenceException;\nL_00EE:\n\treturn;\nL_0016:\n\tv112 = this.rms;\n\tv47 = this.rms == 0;\n\tif (v47) goto L_00EE;\nL_0027:\n\tv53 = v103 >= v112.Length;\n\tif (v53) goto L_00EE;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DisposeModelMaterials()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::DisposeModelMaterials");
		}

		[Token(Token = "0x6000042")]
		[Address(RVA = "0x7712780", Offset = "0x7712780", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0023;\nL_0023:\n\tv75 = System.Collections.Generic.List`1<HighlightPlus.HighlightEffect>::Remove(v49.effects, this);\n\treturn;\n")]
		private void RemoveEffect()
		{
			bool flag = effects.Remove(this);
		}

		[Token(Token = "0x6000043")]
		[Address(RVA = "0x7712F2C", Offset = "0x7712F2C", Length = "0x7E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003D;\nL_0049:\n\tgoto L_004C;\nL_004C:\n\tv85 = v83.effects == 0;\n\tv86 = ~v85;\n\tif (v86) goto L_0067;\n\tgoto L_026B;\nL_0067:\n\tv107 = System.Collections.Generic.List`1<HighlightPlus.HighlightEffect>::Remove(v83.effects, this);\n\tHighlightPlus.HighlightEffect::ReleaseInstantiatedIconPrefab(this);\n\tv237 = this.label == 0;\n\tif (v237) goto L_0073;\n\tv276 = HighlightPlus.HighlightLabel::Release(this.label);\n\tgoto L_0084;\nL_0084:\n\tgoto L_0088;\nL_0088:\n\tv352 = UnityEngine.Object::op_Inequality(this.fxMatTarget, 0);\n\tv460 = ~v352;\n\tv461 = ~v460;\n\tif (v461) goto L_0107;\n\tv494 = this.fxMatComposeGlow;\n\tv474 = *([B7951B1]) & 1;\n\tv475 = v474 == 0;\nL_FFFFFFFF:\n\tv504 = this.fxMatComposeGlow;\n\tif (v475) goto L_0116;\nL_FFFFFFFF:\n\tv556 = v494;\n\tgoto L_0098;\nL_0098:\n\tv522 = UnityEngine.Object::op_Inequality(v556, 0);\n\tv534 = ~v522;\n\tv535 = ~v534;\n\tif (v535) goto L_0127;\n\tv570 = this.fxMatComposeOutline;\n\tv549 = *([B7951B1]) & 1;\n\tv550 = v549 == 0;\nL_FFFFFFFF:\n\tv580 = this.fxMatComposeOutline;\n\tif (v550) goto L_0136;\nL_FFFFFFFF:\n\tv632 = v570;\n\tgoto L_00A8;\nL_00A8:\n\tv598 = UnityEngine.Object::op_Inequality(v632, 0);\n\tv610 = ~v598;\n\tv611 = ~v610;\n\tif (v611) goto L_0147;\n\tv646 = this.fxMatBlurGlow;\n\tv625 = *([B7951B1]) & 1;\n\tv626 = v625 == 0;\nL_FFFFFFFF:\n\tv656 = this.fxMatBlurGlow;\n\tif (v626) goto L_0156;\nL_FFFFFFFF:\n\tv708 = v646;\n\tgoto L_00B8;\nL_00B8:\n\tv674 = UnityEngine.Object::op_Inequality(v708, 0);\n\tv686 = ~v674;\n\tv687 = ~v686;\n\tif (v687) goto L_0167;\n\tv722 = this.fxMatBlurOutline;\n\tv701 = *([B7951B1]) & 1;\n\tv702 = v701 == 0;\nL_FFFFFFFF:\n\tv732 = this.fxMatBlurOutline;\n\tif (v702) goto L_0176;\nL_FFFFFFFF:\n\tv784 = v722;\n\tgoto L_00C8;\nL_00C8:\n\tv750 = UnityEngine.Object::op_Inequality(v784, 0);\n\tv762 = ~v750;\n\tv763 = ~v762;\n\tif (v763) goto L_0187;\n\tv798 = this.fxMatIcon;\n\tv777 = *([B7951B1]) & 1;\n\tv778 = v777 == 0;\nL_FFFFFFFF:\n\tv808 = this.fxMatIcon;\n\tif (v778) goto L_0196;\nL_FFFFFFFF:\n\tv860 = v798;\n\tgoto L_00D8;\nL_00D8:\n\tv826 = UnityEngine.Object::op_Inequality(v860, 0);\n\tv838 = ~v826;\n\tv839 = ~v838;\n\tif (v839) goto L_01A7;\nL_FFFFFFFF:\n\tv874 = this.outlineGradientTex;\n\tgoto L_00E4;\nL_00E4:\n\tv879 = UnityEngine.Object::op_Inequality(v874, 0);\n\tv890 = ~v879;\n\tv891 = ~v890;\nL_FFFFFFFF:\n\tv162 = 0;\n\tif (v891) goto L_01BF;\n\tgoto L_00EE;\nL_00EE:\n\tv926 = v181.combinedMeshes == 0;\n\tv176 = ~v926;\n\tif (v176) goto L_01E1;\nL_FFFFFFFF:\n\tv262 = v162;\n\tgoto L_026B;\nL_0107:\n\tgoto L_010B;\nL_010B:\n\tUnityEngine.Object::DestroyImmediate(this.fxMatTarget);\n\tv494 = this.fxMatComposeGlow;\n\tv532 = *([B7951B1]) & 1;\n\tv533 = v532 == 0;\n\tv491 = ~v533;\nL_FFFFFFFF:\n\tv504 = this.fxMatComposeGlow;\n\tif (v491) goto L_FFFFFFFF;\nL_0116:\n\t*([B7951B1]) = 1;\nL_FFFFFFFF:\n\tv556 = v504;\n\tgoto L_0098;\nL_0127:\n\tgoto L_012B;\nL_012B:\n\tUnityEngine.Object::DestroyImmediate(v556);\n\tv570 = this.fxMatComposeOutline;\n\tv608 = *([B7951B1]) & 1;\n\tv609 = v608 == 0;\n\tv567 = ~v609;\nL_FFFFFFFF:\n\tv580 = this.fxMatComposeOutline;\n\tif (v567) goto L_FFFFFFFF;\nL_0136:\n\t*([B7951B1]) = 1;\nL_FFFFFFFF:\n\tv632 = v580;\n\tgoto L_00A8;\nL_0147:\n\tgoto L_014B;\nL_014B:\n\tUnityEngine.Object::DestroyImmediate(v632);\n\tv646 = this.fxMatBlurGlow;\n\tv684 = *([B7951B1]) & 1;\n\tv685 = v684 == 0;\n\tv643 = ~v685;\nL_FFFFFFFF:\n\tv656 = this.fxMatBlurGlow;\n\tif (v643) goto L_FFFFFFFF;\nL_0156:\n\t*([B7951B1]) = 1;\nL_FFFFFFFF:\n\tv708 = v656;\n\tgoto L_00B8;\nL_0167:\n\tgoto L_016B;\nL_016B:\n\tUnityEngine.Object::DestroyImmediate(v708);\n\tv722 = this.fxMatBlurOutline;\n\tv760 = *([B7951B1]) & 1;\n\tv761 = v760 == 0;\n\tv719 = ~v761;\nL_FFFFFFFF:\n\tv732 = this.fxMatBlurOutline;\n\tif (v719) goto L_FFFFFFFF;\nL_0176:\n\t*([B7951B1]) = 1;\nL_FFFFFFFF:\n\tv784 = v732;\n\tgoto L_00C8;\nL_0187:\n\tgoto L_018B;\nL_018B:\n\tUnityEngine.Object::DestroyImmediate(v784);\n\tv798 = this.fxMatIcon;\n\tv836 = *([B7951B1]) & 1;\n\tv837 = v836 == 0;\n\tv795 = ~v837;\nL_FFFFFFFF:\n\tv808 = this.fxMatIcon;\n\tif (v795) goto L_FFFFFFFF;\nL_0196:\n\t*([B7951B1]) = 1;\nL_FFFFFFFF:\n\tv860 = v808;\n\tgoto L_00D8;\nL_01A7:\n\tgoto L_01AB;\nL_01AB:\n\tUnityEngine.Object::DestroyImmediate(v860);\nL_FFFFFFFF:\n\tv874 = this.outlineGradientTex;\n\tgoto L_00E4;\nL_01BF:\n\tgoto L_01C3;\nL_01C3:\n\tUnityEngine.Object::DestroyImmediate(this.outlineGradientTex);\n\tthis.outlineGradientTex = 0;\nL_FFFFFFFF:\n\tv162 = 0;\n\tgoto L_00EE;\nL_01E1:\n\tv951 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Mesh>::Remove(v181.combinedMeshes, this.combinedMeshesHashId);\n\tgoto L_01EF;\nL_01EF:\n\tv173 = System.Collections.Generic.Dictionary`2<UnityEngine.Mesh, System.Collections.Generic.HashSet`1<HighlightPlus.HighlightEffect>>::get_Keys(v183.sharedMeshUsage);\n\tv989 = System.Collections.Generic.Dictionary`2<UnityEngine.Mesh, System.Collections.Generic.HashSet`1<HighlightPlus.HighlightEffect>>+KeyCollection<UnityEngine.Mesh, System.Collections.Generic.HashSet`1<HighlightPlus.HighlightEffect>>::GetEnumerator(v173);\n\tv201 = v989._dictionary;\n\tgoto L_0211;\nL_0211:\n\tv997 = UnityEngine.Object::op_Equality(v989._currentKey, 0);\n\tv1017 = v997 == 0;\n\tv1000 = ~v1017;\n\tif (v1000) goto L_0203;\n\tgoto L_021F;\n\tv1028 = System.Collections.Generic.Dictionary`2<UnityEngine.Mesh, System.Collections.Generic.HashSet`1<HighlightPlus.HighlightEffect>>::TryGetValue(v271.sharedMeshUsage, v989._currentKey, &v195 @ stack_-88_v8 (System.Collections.Generic.HashSet`1<HighlightPlus.HighlightEffect>));\n\tv1030 = v195 == 0;\n\tif (v1030) goto L_0236;\n\tv998 = System.Collections.Generic.HashSet`1<HighlightPlus.HighlightEffect>::Remove(v195, this);\n\tv1033 = v195 == 0;\n\tif (v1033) goto L_0236;\n\tv1043 = v195.Count == 0;\n\tv1001 = ~v1043;\n\tif (v1001) goto L_0203;\nL_0236:\n\tgoto L_0241;\nL_0241:\n\tv1047 = System.Collections.Generic.Dictionary`2<UnityEngine.Mesh, System.Collections.Generic.HashSet`1<HighlightPlus.HighlightEffect>>::Remove(v232.sharedMeshUsage, v989._currentKey);\n\tgoto L_024A;\nL_024A:\n\tUnityEngine.Object::DestroyImmediate(v989._currentKey);\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+KeyCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v201 @ stack_-80_v7 (System.Collections.Generic.Dictionary`2<UnityEngine.Mesh, System.Collections.Generic.HashSet`1<HighlightPlus.HighlightEffect>>));\nL_FFFFFFFF:\n\tv137 = &v201 @ stack_-80_v7 (System.Collections.Generic.Dictionary`2<UnityEngine.Mesh, System.Collections.Generic.HashSet`1<HighlightPlus.HighlightEffect>>);\nL_FFFFFFFF:\n\tv142 = 0;\nL_FFFFFFFF:\n\t;\n\tgoto L_01EF;\nL_025A:\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+KeyCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v201 @ stack_-80_v7 (System.Collections.Generic.Dictionary`2<UnityEngine.Mesh, System.Collections.Generic.HashSet`1<HighlightPlus.HighlightEffect>>));\nL_0268:\n\treturn;\nL_0269:\n\tv266 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv137 = &v201 @ stack_-80_v7 (System.Collections.Generic.Dictionary`2<UnityEngine.Mesh, System.Collections.Generic.HashSet`1<HighlightPlus.HighlightEffect>>);\nL_FFFFFFFF:\n\tv142 = 0;\nL_FFFFFFFF:\n\tv262 = 0;\n\tgoto L_026D;\nL_026B:\n\tv188 = new System.NullReferenceException();\n\tv266 = new System.NullReferenceException();\nL_026D:\n\t// 621 Interrupt\n\tgoto L_0281;\nL_0281:\n\tv296 = v262 != 1;\n\tif (v296) goto L_0292;\n\tv301 = 0x8BF5BC4(v266, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv321 = 0x8BF5BF4(v301, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+KeyCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(v137);\n\tv309 = *([v301 @ X0_v9]) == 0;\n\tif (v309) goto L_0268;\n\tv307 = new System.OutOfMemoryException();\nL_FFFFFFFF:\n\tv142 = *([v301 @ X0_v9]);\nL_FFFFFFFF:\n\tv266 = v307;\nL_0292:\n\tv316 = 0x359AAC0(&v142 @ stack_-A0 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, cl\n// ... truncated")]
		private unsafe void OnDestroy()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::OnDestroy");
		}

		[Token(Token = "0x6000044")]
		[Address(RVA = "0x7713CB0", Offset = "0x7713CB0", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.isVisible = 1;\n\treturn;\n")]
		private void OnBecameVisible()
		{
			isVisible = true;
		}

		[Token(Token = "0x6000045")]
		[Address(RVA = "0x7713CBC", Offset = "0x7713CBC", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv54 = v42.Length != 1;\n\tif (v54) goto L_003E;\n\tv85 = UnityEngine.Component::get_transform(this);\n\tgoto L_0033;\nL_0033:\n\tv107 = UnityEngine.Object::op_Inequality(*([v42 @ X8_v3 (ModelMaterials[])+28]), v85);\n\tthis.isVisible = v107;\n\treturn;\nL_003E:\n\tthis.isVisible = 1;\n\treturn;\nL_0014:\n\tv42 = this.rms;\n\tv43 = this.rms == 0;\n\tif (v43) goto L_003E;\n")]
		private void OnBecameInvisible()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::OnBecameInvisible");
		}

		[Token(Token = "0x6000046")]
		[Address(RVA = "0x7713D6C", Offset = "0x7713D6C", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv53 = UnityEngine.Object::op_Inequality(profile, 0);\n\tv60 = ~v53;\n\tif (v60) goto L_0047;\n\tthis.profile = profile;\n\tHighlightPlus.HighlightProfile::Load(profile, this);\n\treturn;\nL_0047:\n\treturn;\n")]
		public void ProfileLoad(HighlightProfile profile)
		{
			if (profile != null)
			{
				this.profile = profile;
				profile.Load(this);
			}
		}

		[Token(Token = "0x6000047")]
		[Address(RVA = "0x7713E34", Offset = "0x7713E34", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Inequality(this.profile, 0);\n\tv63 = ~v55;\n\tif (v63) goto L_0043;\n\tHighlightPlus.HighlightProfile::Load(this.profile, this);\n\treturn;\nL_0043:\n\treturn;\n")]
		public void ProfileReload()
		{
			if (profile != null)
			{
				profile.Load(this);
			}
		}

		[Token(Token = "0x6000048")]
		[Address(RVA = "0x7713EF0", Offset = "0x7713EF0", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv53 = UnityEngine.Object::op_Inequality(profile, 0);\n\tv60 = ~v53;\n\tif (v60) goto L_0042;\n\tHighlightPlus.HighlightProfile::Save(profile, this);\n\treturn;\nL_0042:\n\treturn;\n")]
		public void ProfileSaveChanges(HighlightProfile profile)
		{
			if (profile != null)
			{
				profile.Save(this);
			}
		}

		[Token(Token = "0x6000049")]
		[Address(RVA = "0x7713FA8", Offset = "0x7713FA8", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Inequality(this.profile, 0);\n\tv63 = ~v55;\n\tif (v63) goto L_0043;\n\tHighlightPlus.HighlightProfile::Save(this.profile, this);\n\treturn;\nL_0043:\n\treturn;\n")]
		public void ProfileSaveChanges()
		{
			if (profile != null)
			{
				profile.Save(this);
			}
		}

		[Token(Token = "0x600004A")]
		[Address(RVA = "0x7714064", Offset = "0x7714064", Length = "0x1A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\t;\n\tSystem.Collections.Generic.List`1<UnityEngine.Renderer>::Clear(results);\n\tv69 = results.Count < 1;\n\tif (v69) goto L_0037;\nL_0037:\n\tv167 = this.rms == 0;\n\tif (v167) goto L_00B6;\n\tv205 = this.includedObjectsCount < 1;\n\tif (v205) goto L_00B6;\n\tv89 = 0x50;\n\tv91 = 0;\n\tgoto L_0060;\nL_0051:\n\tSystem.Collections.Generic.List`1<UnityEngine.Renderer>::Add(results, *([v153 @ X8_v13 (ModelMaterials[])+v89 @ X23_v6 (System.Int32)]));\nL_0052:\n\tv91 = v91 + 1;\n\tv89 = v89 + 0xD8;\n\tv223 = v91 >= this.includedObjectsCount;\n\tif (v223) goto L_00B6;\nL_0060:\n\tv152 = this.rms;\n\tgoto L_0076;\nL_0076:\n\tv301 = UnityEngine.Object::op_Inequality(*([v152 @ X8_v11 (ModelMaterials[])+v89 @ X23_v6 (System.Int32)]), 0);\n\tv303 = ~v301;\n\tif (v303) goto L_0052;\n\tgoto L_0081;\nL_0081:\n\tv153 = this.rms;\n\tgoto L_0051;\nL_00B6:\n\treturn;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void GetRenderers(List<Renderer> results)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::GetRenderers");
		}

		[Token(Token = "0x600004B")]
		[Address(RVA = "0x7714208", Offset = "0x7714208", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = ~discardCachedMeshes;\n\tif (v12) goto L_000C;\n\tHighlightPlus.HighlightEffect::RefreshCachedMeshes(this);\nL_000C:\n\tHighlightPlus.HighlightEffect::InitIfNeeded(this);\n\tv19 = UnityEngine.Behaviour::get_enabled(this);\n\tv20 = ~v19;\n\tif (v20) goto L_001F;\n\tHighlightPlus.HighlightEffect::SetupMaterial(this);\n\treturn;\nL_001F:\n\treturn;\n")]
		public void Refresh(bool discardCachedMeshes = false)
		{
			if (discardCachedMeshes)
			{
				RefreshCachedMeshes();
			}
			InitIfNeeded();
			if (base.enabled)
			{
				SetupMaterial();
			}
		}

		[Token(Token = "0x600004C")]
		[Address(RVA = "0x77144D0", Offset = "0x77144D0", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0018;\nL_0018:\n\tgoto L_001C;\nL_001C:\n\tgoto L_0020;\nL_0020:\n\tv88 = v85.useUnscaledTime == 0;\n\tif (v88) goto L_0049;\n\tv114 = UnityEngine.Time::get_unscaledTime();\n\tgoto L_004A;\nL_0049:\n\tv114 = UnityEngine.Time::get_time();\nL_004A:\n\tthis.iconFXStartTime = v114;\n\tthis.targetFXStartTime = v114;\n\tthis.highlightStartTime = v114;\n\treturn;\n")]
		public void ResetHighlightStartTime()
		{
			highlightStartTime = (targetFXStartTime = (iconFXStartTime = ((!useUnscaledTime) ? Time.time : Time.unscaledTime)));
		}

		[Token(Token = "0x600004D")]
		[Address(RVA = "0x7714648", Offset = "0x7714648", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.cbHighlight = cmd;\n\tthis.cbHighlightEmpty = 0;\n\treturn;\n")]
		public void SetCommandBuffer(CommandBuffer cmd)
		{
			cbHighlight = cmd;
			cbHighlightEmpty = false;
		}

		[Token(Token = "0x600004E")]
		[Address(RVA = "0x7714674", Offset = "0x7714674", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.colorAttachmentBuffer.m_DepthSlice = colorAttachmentBuffer.m_DepthSlice;\n\tthis.colorAttachmentBuffer.m_BufferPointer = colorAttachmentBuffer.m_BufferPointer;\n\tthis.colorAttachmentBuffer = colorAttachmentBuffer.m_Type;\n\tthis.depthAttachmentBuffer.m_DepthSlice = depthAttachmentBuffer.m_DepthSlice;\n\tthis.depthAttachmentBuffer = depthAttachmentBuffer.m_Type;\n\tthis.depthAttachmentBuffer.m_BufferPointer = depthAttachmentBuffer.m_BufferPointer;\n\tthis.sourceDesc.memoryless = sourceDesc.memoryless;\n\tthis.sourceDesc.dimension = sourceDesc.dimension;\n\tthis.sourceDesc.mipCount = sourceDesc.mipCount;\n\tthis.sourceDesc = sourceDesc.width;\n\tHighlightPlus.HighlightEffect::BuildCommandBuffer(this, cam, clearStencil);\n\tv31 = this.cbHighlightEmpty == 0;\n\tif (v31) goto L_002F;\n\treturn 0;\nL_002F:\n\treturn this.cbHighlight;\n")]
		public CommandBuffer BuildCommandBuffer(Camera cam, RenderTargetIdentifier colorAttachmentBuffer, RenderTargetIdentifier depthAttachmentBuffer, bool clearStencil, ref RenderTextureDescriptor sourceDesc)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::BuildCommandBuffer");
			return default;
		}

		[Token(Token = "0x600004F")]
		[Address(RVA = "0x77146F8", Offset = "0x77146F8", Length = "0x56C8")]
		private unsafe void BuildCommandBuffer(Camera cam, bool clearStencil)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::BuildCommandBuffer");
		}

		[Token(Token = "0x6000050")]
		[Address(RVA = "0x771BC20", Offset = "0x771BC20", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = this.rms;\n\tv199 = v18[v108 @ X22_v5 (System.Int32)].subMeshCount < 1;\n\tif (v199) goto L_00AC;\n\tv102 = 0;\n\tgoto L_0044;\nL_0037:\n\tUnityEngine.Rendering.CommandBuffer::DrawRenderer(this.cbHighlight, v176[v108 @ X22_v5 (System.Int32)].renderer, v162[v102 @ X21_v6 (System.Int32)], v102, 0);\nL_0038:\n\tv102 = v102 + 1;\n\tv302 = v18[v108 @ X22_v5 (System.Int32)].subMeshCount == v102;\n\tif (v302) goto L_00AC;\nL_0044:\n\tv367 = this.subMeshMask >> v102;\n\tv368 = v367 & 1;\n\tv369 = v368 == 0;\n\tif (v369) goto L_0038;\n\tv176 = this.rms;\n\tv110 = v176[v108 @ X22_v5 (System.Int32)].isCombined != 1;\n\tif (v110) goto L_0091;\n\tv177 = v176[v108 @ X22_v5 (System.Int32)].fxMatMask;\n\tv374 = v176[v108 @ X22_v5 (System.Int32)].renderingMatrix;\n\tUnityEngine.Rendering.CommandBuffer::DrawMesh(this.cbHighlight, v176[v108 @ X22_v5 (System.Int32)].mesh, &v374 @ stack_-C0_v5 (UnityEngine.Matrix4x4), v177[v102 @ X21_v6 (System.Int32)], v102, 0);\n\tgoto L_0038;\nL_0091:\n\tv162 = v176[v108 @ X22_v5 (System.Int32)].fxMatMask;\n\tv407 = this.cbHighlight == 0;\n\tv169 = ~v407;\n\tif (v169) goto L_0037;\n\tthrow System.NullReferenceException;\nL_00AC:\n\treturn;\n")]
		private void RenderMask(int k, Mesh mesh)
		{
			ModelMaterials[] array = rms;
			int num = default(int);
			if (array[num].subMeshCount < 1)
			{
				return;
			}
			int num2 = 0;
			do
			{
				int num3 = subMeshMask >> num2;
				if ((num3 & 1) != 0)
				{
					ModelMaterials[] array2 = rms;
					if (array2[num].isCombined)
					{
						Material[] array3 = array2[num].fxMatMask;
						Matrix4x4 renderingMatrix = array2[num].renderingMatrix;
						cbHighlight.DrawMesh(array2[num].mesh, renderingMatrix, array3[num2], num2, 0);
					}
					else
					{
						Material[] array4 = array2[num].fxMatMask;
						if (cbHighlight == null)
						{
							throw new NullReferenceException();
						}
						cbHighlight.DrawRenderer(array2[num].renderer, array4[num2], num2, 0);
					}
				}
				num2++;
			}
			while (array[num].subMeshCount != num2);
		}

		[Token(Token = "0x6000051")]
		[Address(RVA = "0x771DD68", Offset = "0x771DD68", Length = "0x1E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv223 = v56[v135 @ X24_v3 (System.Int32)].isCombined == 0;\n\tif (v223) goto L_0096;\n\tv271 = v56[v135 @ X24_v3 (System.Int32)].subMeshCount < 1;\n\tif (v271) goto L_00E0;\n\tv212 = 0;\n\tgoto L_0052;\nL_0046:\n\tv212 = v212 + 1;\n\tv343 = v56[v135 @ X24_v3 (System.Int32)].subMeshCount == v212;\n\tif (v343) goto L_00E0;\nL_0052:\n\tv429 = this.subMeshMask >> v212;\n\tv430 = v429 & 1;\n\tv431 = v430 == 0;\n\tif (v431) goto L_0046;\n\tv207 = this.rms;\n\tgoto L_007E;\nL_007E:\n\tv446 = v207[v135 @ X24_v3 (System.Int32)].renderingMatrix;\n\tUnityEngine.Rendering.CommandBuffer::DrawMesh(this.cbHighlight, mesh, &v446 @ stack_-E0_v5 (UnityEngine.Matrix4x4), v459.fxMatClearStencil, v212, 1);\n\tgoto L_0046;\nL_0096:\n\tv282 = v56[v135 @ X24_v3 (System.Int32)].subMeshCount < 1;\n\tif (v282) goto L_00E0;\n\tv216 = 0;\n\tgoto L_00B4;\nL_00A7:\n\tUnityEngine.Rendering.CommandBuffer::DrawRenderer(this.cbHighlight, v210[v135 @ X24_v3 (System.Int32)].renderer, v475.fxMatClearStencil, v216, 1);\nL_00A8:\n\tv216 = v216 + 1;\n\tv344 = v56[v135 @ X24_v3 (System.Int32)].subMeshCount == v216;\n\tif (v344) goto L_00E0;\nL_00B4:\n\tv435 = this.subMeshMask >> v216;\n\tv436 = v435 & 1;\n\tv437 = v436 == 0;\n\tif (v437) goto L_00A8;\n\tv210 = this.rms;\n\tgoto L_00A7;\nL_00E0:\n\treturn;\nL_001C:\n\tv56 = this.rms;\n")]
		private void RenderSeeThroughClearStencil(int k, Mesh mesh)
		{
			ModelMaterials[] array = rms;
			int num = default(int);
			if (array[num].isCombined)
			{
				if (array[num].subMeshCount < 1)
				{
					return;
				}
				int num2 = 0;
				do
				{
					int num3 = subMeshMask >> num2;
					if ((num3 & 1) != 0)
					{
						ModelMaterials[] array2 = rms;
						Matrix4x4 renderingMatrix = array2[num].renderingMatrix;
						cbHighlight.DrawMesh(mesh, renderingMatrix, fxMatClearStencil, num2, 1);
					}
					num2++;
				}
				while (array[num].subMeshCount != num2);
			}
			else
			{
				if (array[num].subMeshCount < 1)
				{
					return;
				}
				int num4 = 0;
				do
				{
					int num5 = subMeshMask >> num4;
					if ((num5 & 1) != 0)
					{
						ModelMaterials[] array3 = rms;
						cbHighlight.DrawRenderer(array3[num].renderer, fxMatClearStencil, num4, 1);
					}
					num4++;
				}
				while (array[num].subMeshCount != num4);
			}
		}

		[Token(Token = "0x6000052")]
		[Address(RVA = "0x771DF50", Offset = "0x771DF50", Length = "0x1A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = this.rms;\n\tv227 = v22[v121 @ X23_v5 (System.Int32)].isCombined == 0;\n\tif (v227) goto L_008F;\n\tv321 = v22[v121 @ X23_v5 (System.Int32)].subMeshCount < 1;\n\tif (v321) goto L_00DC;\n\tv114 = 0;\n\tgoto L_0054;\nL_003C:\n\tv452 = v211[v121 @ X23_v5 (System.Int32)].renderingMatrix;\n\tUnityEngine.Rendering.CommandBuffer::DrawMesh(this.cbHighlight, mesh, &v452 @ stack_-D0_v5 (UnityEngine.Matrix4x4), v212[v114 @ X22_v7 (System.Int32)], v114, 1);\nL_0048:\n\tv114 = v114 + 1;\n\tv347 = v22[v121 @ X23_v5 (System.Int32)].subMeshCount == v114;\n\tif (v347) goto L_00DC;\nL_0054:\n\tv435 = this.subMeshMask >> v114;\n\tv436 = v435 & 1;\n\tv437 = v436 == 0;\n\tif (v437) goto L_0048;\n\tv211 = this.rms;\n\tv212 = v211[v121 @ X23_v5 (System.Int32)].fxMatMask;\n\tv494 = this.cbHighlight == 0;\n\tv206 = ~v494;\n\tif (v206) goto L_003C;\n\tgoto L_00D0;\nL_008F:\n\tv323 = v22[v121 @ X23_v5 (System.Int32)].subMeshCount < 1;\n\tif (v323) goto L_00DC;\n\tv116 = 0;\n\tgoto L_00A8;\nL_009B:\n\tUnityEngine.Rendering.CommandBuffer::DrawRenderer(this.cbHighlight, v213[v121 @ X23_v5 (System.Int32)].renderer, v210[v116 @ X21_v6 (System.Int32)], v116, 1);\nL_009C:\n\tv116 = v116 + 1;\n\tv349 = v22[v121 @ X23_v5 (System.Int32)].subMeshCount == v116;\n\tif (v349) goto L_00DC;\nL_00A8:\n\tv441 = this.subMeshMask >> v116;\n\tv442 = v441 & 1;\n\tv443 = v442 == 0;\n\tif (v443) goto L_009C;\n\tv213 = this.rms;\n\tv210 = v213[v121 @ X23_v5 (System.Int32)].fxMatMask;\n\tv495 = this.cbHighlight == 0;\n\tv203 = ~v495;\n\tif (v203) goto L_009B;\nL_00D0:\n\tthrow System.NullReferenceException;\nL_00DC:\n\treturn;\n")]
		private void RenderSeeThroughMask(int k, Mesh mesh)
		{
			ModelMaterials[] array = rms;
			int num = default(int);
			if (array[num].isCombined)
			{
				if (array[num].subMeshCount < 1)
				{
					return;
				}
				int num2 = 0;
				while (true)
				{
					int num3 = subMeshMask >> num2;
					if ((num3 & 1) != 0)
					{
						ModelMaterials[] array2 = rms;
						Material[] array3 = array2[num].fxMatMask;
						if (cbHighlight == null)
						{
							break;
						}
						Matrix4x4 renderingMatrix = array2[num].renderingMatrix;
						cbHighlight.DrawMesh(mesh, renderingMatrix, array3[num2], num2, 1);
					}
					num2++;
					if (array[num].subMeshCount != num2)
					{
						continue;
					}
					return;
				}
			}
			else
			{
				if (array[num].subMeshCount < 1)
				{
					return;
				}
				int num4 = 0;
				while (true)
				{
					int num5 = subMeshMask >> num4;
					if ((num5 & 1) != 0)
					{
						ModelMaterials[] array4 = rms;
						Material[] array5 = array4[num].fxMatMask;
						if (cbHighlight == null)
						{
							break;
						}
						cbHighlight.DrawRenderer(array4[num].renderer, array5[num4], num4, 1);
					}
					num4++;
					if (array[num].subMeshCount != num4)
					{
						continue;
					}
					return;
				}
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x6000053")]
		[Address(RVA = "0x771E0F0", Offset = "0x771E0F0", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv31 = m.m00;\n\t// 29 MakeStruct v43 @ AGG771E13C_1_v1 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), p.x (System.Single), p.y (System.Single), p.z (System.Single), p.w (System.Single)\n\tv44 = UnityEngine.Matrix4x4::op_Multiply(&v31 @ stack_-80_v1 (System.Single), v43);\n\tp.w = v44.w;\n\t// 36 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv50 = v44 / v44.y;\n\tv54 = v50 * 0x3F;\n\tp.x = v54;\n\tv55 = ~perspectiveProjection;\n\tif (v55) goto L_0035;\n\tv56 = v44.z / v44.w;\n\tv57 = v56 * zBufferParamsZ;\n\tv58 = v57 + zBufferParamsW;\n\tv99 = 1f / v58;\n\tgoto L_0049;\nL_0035:\n\tv111 = 1f - v44.z;\n\tv68 = this.usesReversedZBuffer == 0;\n\tv73 = ~v68;\n\tv74 = ~v73;\n\tif (v74) goto L_FFFFFFFF;\n\tgoto L_0046;\nL_FFFFFFFF:\n\tv111 = v44.z;\nL_0049:\n\tp.z = v99;\n\treturn;\nL_0046:\n\tv98 = zBufferParamsW - zBufferParamsZ;\n\tv112 = v98 * v111;\n\tv99 = v112 + zBufferParamsZ;\n")]
		private unsafe void WorldToViewportPoint(ref Matrix4x4 m, ref Vector4 p, bool perspectiveProjection, float zBufferParamsZ, float zBufferParamsW)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::WorldToViewportPoint");
		}

		[Token(Token = "0x6000054")]
		[Address(RVA = "0x771BD70", Offset = "0x771BD70", Length = "0x2F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv62 = this.rms == 0;\n\tif (v62) goto L_00F3;\n\tgoto L_002E;\n\tv209 = this.rms;\n\tv503 = *([v209 @ X8_v11 (ModelMaterials[])+20]) & 1;\n\tv504 = v503 == 0;\n\tv505 = ~v504;\n\tif (v505) goto L_0054;\n\tv510 = *([v209 @ X8_v11 (ModelMaterials[])+F0]) & 1;\n\tv511 = v510 == 0;\n\tv512 = ~v511;\n\tif (v512) goto L_0066;\nL_0054:\n\tgoto L_0057;\nL_0057:\n\tv524 = UnityEngine.Object::op_Equality(*([v209 @ X8_v11 (ModelMaterials[])+50]), 0);\n\tv526 = v524 == 0;\n\tif (v526) goto L_0107;\nL_0066:\n\tv241 = this.includedObjectsCount < 2;\nL_FFFFFFFF:\n\tv365 = v211;\nL_FFFFFFFF:\n\tv367 = v87.vector3Min;\nL_FFFFFFFF:\n\tv369 = v87.vector3Max;\nL_FFFFFFFF:\n\tv589 = v111;\nL_FFFFFFFF:\n\tv106 = v87.vector3Min;\nL_FFFFFFFF:\n\tv108 = v87.vector3Max;\n\tif (v241) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv400 = 0x1C8;\nL_FFFFFFFF:\n\tv402 = 1;\n\tgoto L_007D;\nL_FFFFFFFF:\n\tv482 = v365;\nL_007D:\n\tv461 = this.rms;\n\tv446 = this.rms + v400;\n\tv573 = *([v446 @ X9_v15-D0]) & 1;\n\tv574 = v573 == 0;\n\tv575 = ~v574;\n\tif (v575) goto L_009A;\n\tv577 = *([v461 @ X8_v16 (ModelMaterials[])+v400 @ X22_v7 (System.Int32)]) & 1;\n\tv578 = v577 == 0;\n\tv579 = ~v578;\n\tif (v579) goto L_FFFFFFFF;\nL_009A:\n\tgoto L_009E;\nL_009E:\n\tv635 = UnityEngine.Object::op_Equality(*([v446 @ X9_v15-A0]), 0);\n\tv660 = v635 == 0;\n\tv639 = ~v660;\n\tif (v639) goto L_FFFFFFFF;\n\tgoto L_00BB;\nL_00BB:\n\tv463 = this.rms + v400;\n\tv637 = UnityEngine.Renderer::get_bounds(*([v463 @ X8_v22-A0]));\n\tv482 = v637.m_Center.z + v637.m_Extents.z;\n\tv668 = v637.m_Center.z - v637.m_Extents.z;\n\tv669 = v668 < v589;\n\tv591 = ~v669;\n\tif (v591) goto L_00DE;\nL_FFFFFFFF:\n\tv589 = v668;\n\tgoto L_00DE;\n\tgoto L_006E;\nL_00F3:\n\tgoto L_00F7;\nL_0107:\n\tv464 = this.rms;\n\tv276 = UnityEngine.Renderer::get_bounds(*([v464 @ X8_v31 (ModelMaterials[])+50]));\n\tv369 = v276.center - v276.extents;\n\tv589 = v276.m_Center.z - v276.m_Extents.z;\n\tv367 = v276.center + v276.extents;\n\tv365 = v276.m_Center.z + v276.m_Extents.z;\n\tv240 = this.includedObjectsCount >= 2;\nL_FFFFFFFF:\n\tv211 = v365;\nL_FFFFFFFF:\n\tv106 = v367;\nL_FFFFFFFF:\n\tv108 = v369;\nL_FFFFFFFF:\n\tv111 = v589;\n\tif (v240) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv482 = v211;\nL_0020:\n\tv58 = this.includedObjectsCount == 0;\n\tif (v58) goto L_00F3;\nL_002E:\n\tv111 = v87.vector3Max.z;\n\tv211 = v87.vector3Min.z;\n\tv102 = this.includedObjectsCount < 1;\nL_FFFFFFFF:\n\tv106 = v87.vector3Min;\nL_FFFFFFFF:\n\tv108 = v87.vector3Max;\n\tif (v102) goto L_FFFFFFFF;\nL_012E:\n\tv118 = v106 - v108;\n\tv141 = v482 - v111;\nL_FFFFFFFF:\n\tv78 = v108;\nL_00DE:\n\t// 222 NotImplemented \"Instruction FCMGT not yet implemented.\"\n\t// 223 NotImplemented \"Instruction BIT not yet implemented.\"\n\t// 224 NotImplemented \"Instruction FCMGT not yet implemented.\"\n\t// 225 NotImplemented \"Instruction BIT not yet implemented.\"\n\tv621 = v482 < v365;\n\tv619 = v482 == v365;\n\tv681 = v482 == v482;\n\tv617 = v365 == v365;\n\tv623 = v681 & v617;\n\tv613 = ~v623;\n\tv682 = v621 == v613;\n\tv683 = ~v682;\n\tv611 = v683 | v619;\n\tif (v611) goto L_FFFFFFFF;\nL_006E:\n\tv402 = v402 + 1;\n\tv400 = v400 + 0xD8;\n\tv486 = v402 >= this.includedObjectsCount;\nL_FFFFFFFF:\n\tv365 = v482;\nL_FFFFFFFF:\n\tv106 = v367;\nL_FFFFFFFF:\n\tv108 = v369;\nL_FFFFFFFF:\n\tv111 = v589;\n\tif (v486) goto L_012E;\nL_00F7:\n\tv78 = v77.vector3Zero;\n\tv111 = v77.vector3Zero.z;\n\tv118 = v77.vector3Zero - v77.vector3Zero;\n\tv141 = v77.vector3Zero.z - v77.vector3Zero.z;\n\tgoto L_0132;\nL_0132:\n\tv192 = v118 * 0x3F;\n\tv194 = v141 * 0.5f;\n\tthis.enclosingBounds.extents = v192;\n\tthis.enclosingBounds.m_Extents.z = v194;\n\tv195 = v111 + v194;\n\tv196 = v78 + v192;\n\tthis.enclosingBounds = v196;\n\tthis.enclosingBounds.m_Center.z = v195;\n\treturn;\n")]
		private void ComputeEnclosingBounds()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::ComputeEnclosingBounds");
		}

		[Token(Token = "0x6000055")]
		[Address(RVA = "0x771C254", Offset = "0x771C254", Length = "0x1D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tgoto L_0025;\nL_0025:\n\tv70 = v59.isVrRunning != 1;\n\tif (v70) goto L_005C;\n\tgoto L_0037;\nL_005C:\n\tv141 = UnityEngine.Component::get_transform(cam);\n\tv219 = UnityEngine.Transform::get_position(v141);\n\tv132 = v219;\n\tv131.y = v219.y;\n\tv131.z = v219.z;\n\tgoto L_007E;\n\tUnityEngine.Transform::set_position(v141, v219);\nL_0037:\n\tv131 = v129.zero;\n\tv132 = v129.zero;\n\tv131.z = v129.zero.z;\n\treturnVal2 = HighlightPlus.HighlightEffect::ComputeSmoothQuadMatrixOriginShifted(this, cam, bounds, &v132 @ stack_-60_v3 (UnityEngine.Vector3));\n\tgoto L_00A5;\nL_00A5:\n\treturn returnVal2;\nL_007E:\n\t// 126 MakeStruct v148 @ AGG771C3AC_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v203.zero (UnityEngine.Vector3), v203.zero.y (System.Single), v203.zero.z (System.Single)\n\tUnityEngine.Transform::set_position(v141, v148);\n\tUnityEngine.Camera::ResetWorldToCameraMatrix(cam);\n\tv280 = bounds.m_Center.z - v219.z;\n\tv284 = bounds.center - v219;\n\tbounds.center = v284;\n\t*([bounds @ X2 (UnityEngine.Bounds)+8]) = v280;\n\treturnVal2 = HighlightPlus.HighlightEffect::ComputeSmoothQuadMatrixOriginShifted(this, cam, bounds, &v132 @ stack_-60_v3 (UnityEngine.Vector3));\n")]
		private unsafe bool ComputeSmoothQuadMatrix(Camera cam, Bounds bounds)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::ComputeSmoothQuadMatrix");
			return default;
		}

		[Token(Token = "0x6000056")]
		[Address(RVA = "0x771E1BC", Offset = "0x771E1BC", Length = "0x5B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\nL_0029:\n\tv74 = UnityEngine.Camera::get_worldToCameraMatrix(cam);\n\tv458 = &v399 @ stack_-190;\n\tv461 = UnityEngine.Camera::get_projectionMatrix(cam);\n\tv464 = *([v458 @ X8_v5]);\n\tv470 = &v337 @ stack_-1D0;\n\tv474 = UnityEngine.GL::GetGPUProjectionMatrix(&v464 @ stack_-150_v2, 0);\n\tv288 = v430;\n\tv464 = *([v470 @ X8_v6]);\n\tv434 = UnityEngine.Matrix4x4::op_Multiply(&v464 @ stack_-150_v2, &v288 @ stack_-250_v2);\n\tv444 = this.corners;\n\tv670 = bounds.center - bounds.extents;\n\tv203 = bounds.m_Center.y - bounds.m_Extents.y;\n\tv671 = bounds.m_Center.z - bounds.m_Extents.z;\n\t*([v444 @ X8_v8 (UnityEngine.Vector4[])+20]) = v670;\n\t*([v444 @ X8_v8 (UnityEngine.Vector4[])+24]) = v203;\n\t*([v444 @ X8_v8 (UnityEngine.Vector4[])+28]) = v671;\n\t*([v444 @ X8_v8 (UnityEngine.Vector4[])+2C]) = 0x3F800000;\n\tv750 = bounds.m_Center.z + bounds.m_Extents.z;\n\t*([v444 @ X8_v8 (UnityEngine.Vector4[])+30]) = v670;\n\t*([v444 @ X8_v8 (UnityEngine.Vector4[])+34]) = v203;\n\t*([v444 @ X8_v8 (UnityEngine.Vector4[])+38]) = v750;\n\t*([v444 @ X8_v8 (UnityEngine.Vector4[])+3C]) = 0x3F800000;\n\tv748 = bounds.center + bounds.extents;\n\t*([v444 @ X8_v8 (UnityEngine.Vector4[])+40]) = v748;\n\t*([v444 @ X8_v8 (UnityEngine.Vector4[])+44]) = v203;\n\t*([v444 @ X8_v8 (UnityEngine.Vector4[])+48]) = v671;\n\t*([v444 @ X8_v8 (UnityEngine.Vector4[])+4C]) = 0x3F800000;\n\t*([v444 @ X8_v8 (UnityEngine.Vector4[])+50]) = v748;\n\t*([v444 @ X8_v8 (UnityEngine.Vector4[])+54]) = v203;\n\t*([v444 @ X8_v8 (UnityEngine.Vector4[])+58]) = v750;\n\t*([v444 @ X8_v8 (UnityEngine.Vector4[])+5C]) = 0x3F800000;\n\tv220 = bounds.m_Center.y + bounds.m_Extents.y;\n\t*([v444 @ X8_v8 (UnityEngine.Vector4[])+60]) = v670;\n\t*([v444 @ X8_v8 (UnityEngine.Vector4[])+64]) = v220;\n\t*([v444 @ X8_v8 (UnityEngine.Vector4[])+68]) = v671;\n\t*([v444 @ X8_v8 (UnityEngine.Vector4[])+6C]) = 0x3F800000;\n\t*([v444 @ X8_v8 (UnityEngine.Vector4[])+70]) = v670;\n\t*([v444 @ X8_v8 (UnityEngine.Vector4[])+74]) = v220;\n\t*([v444 @ X8_v8 (UnityEngine.Vector4[])+78]) = v750;\n\t*([v444 @ X8_v8 (UnityEngine.Vector4[])+7C]) = 0x3F800000;\n\t*([v444 @ X8_v8 (UnityEngine.Vector4[])+80]) = v748;\n\t*([v444 @ X8_v8 (UnityEngine.Vector4[])+84]) = v220;\n\t*([v444 @ X8_v8 (UnityEngine.Vector4[])+88]) = v671;\n\t*([v444 @ X8_v8 (UnityEngine.Vector4[])+8C]) = 0x3F800000;\n\t*([v444 @ X8_v8 (UnityEngine.Vector4[])+90]) = v748;\n\t*([v444 @ X8_v8 (UnityEngine.Vector4[])+94]) = v220;\n\t*([v444 @ X8_v8 (UnityEngine.Vector4[])+98]) = v750;\n\t*([v444 @ X8_v8 (UnityEngine.Vector4[])+9C]) = 0x3F800000;\n\tv763 = UnityEngine.Camera::get_nearClipPlane(cam);\n\tv767 = UnityEngine.Camera::get_farClipPlane(cam);\n\tv771 = UnityEngine.Camera::get_orthographic(cam);\n\tv773 = v771 == 0;\n\tv774 = ~v773;\nL_FFFFFFFF:\n\tv787 = v767;\nL_FFFFFFFF:\n\tv151 = v763;\n\tif (v774) goto L_0137;\n\tv802 = v767 / v763;\n\tv786 = this.usesReversedZBuffer != 1;\n\tif (v786) goto L_0133;\n\tv817 = v802 + -1f;\n\tv151 = v817 / v767;\nL_FFFFFFFF:\n\tv802 = 1f;\n\tgoto L_0135;\nL_0133:\n\tv821 = 1f - v802;\n\tv151 = v821 / v767;\nL_0146:\n\tv971 = *([v841 @ X9_v9-4]) < v998;\n\tv972 = *([v841 @ X9_v9-4]) == v998;\n\tv975 = *([v841 @ X9_v9-4]) == *([v841 @ X9_v9-4]);\n\tv976 = v998 == v998;\n\tv977 = v975 & v976;\n\tv978 = ~v977;\n\tv979 = v971 == v978;\n\tv831 = ~v972;\n\tv832 = v979 & v831;\n\tv830 = ~v832;\n\tif (v830) goto L_0158;\nL_FFFFFFFF:\n\tv998 = *([v841 @ X9_v9-4]);\n\tgoto L_0158;\nL_0170:\n\tv129 = v445 + v77;\n\tv430 = v434.m00;\n\t// 383 MakeStruct v110 @ AGG771E478_1_v4 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), [v129 @ X25_v4-C], [v129 @ X25_v4-8], [v129 @ X25_v4-4], [v129 @ X25_v4]\n\tv855 = UnityEngine.Matrix4x4::op_Multiply(&v430 @ stack_-D0_v5 (System.Single), v110);\n\t*([v129 @ X25_v4]) = v855.w;\n\t// 390 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv858 = v855 / v855.y;\n\tv861 = v858 * 0x3F;\n\t*([v129 @ X25_v4-C]) = v861;\n\tv863 = v771 == 0;\n\tif (v863) goto L_01A6;\n\tv889 = 1f - v855.z;\n\tv871 = this.usesReversedZBuffer == 0;\n\tv876 = ~v871;\n\tv877 = ~v876;\n\tif (v877) goto L_FFFFFFFF;\n\tgoto L_01A3;\nL_FFFFFFFF:\n\tv889 = v855.z;\nL_01A6:\n\tv878 = v855.z / v855.w;\n\tv879 = v151 * v878;\n\tv881 = v787 + v879;\n\tv421 = 1f / v881;\n\tv841 = this.corners + v77;\n\tv894 = *([v841 @ X9_v9-C]) < v997;\n\tv902 = ~v894;\n\tif (v902) goto L_01CC;\nL_FFFFFFFF:\n\tv997 = *([v841 @ X9_v9-C]);\n\tgoto L_01CC;\nL_FFFFFFFF:\n\tv996 = *([v841 @ X9_v9-8]);\n\tgoto L_01DA;\nL_FFFFFFFF:\n\tv995 = *([v841 @ X9_v9-C]);\n\tgoto L_01EB;\nL_FFFFFFFF:\n\tv994 = *([v841 @ X9_v9-8]);\n\tgoto L_01FC;\n\tv954 = *([v841 @ X9_v9-4]) < v763;\n\tv963 = ~v954;\nL_FFFFFFFF:\n\tv993 = *([v841 @ X9_v9-4]);\n\tif (v963) goto L_0146;\n\tv993 = v763 + 0x3C23D70A;\nL_FFFFFFFF:\n\tv994 = 1f;\nL_FFFFFFFF:\n\tv995 = 1f;\nL_FFFFFFFF:\n\tv996 = 0;\nL_FFFFFFFF:\n\tv997 = 0;\nL_FFFFFFFF:\n\tv998 = v993;\nL_FFFFFFFF:\n\tv1177 = v763;\n\tgoto L_022A;\nL_021F:\n\tv1011 = v994 == v996;\nL_FFFFFFFF:\n\tv1177 = v763;\n\tif (v1011) goto L_FFFFFFFF;\nL_022A:\n\tv1024 = UnityEngine.Camera::get_pixelWidth(cam);\n\tv1029 = UnityEngine.Camera::get_pixelHeight(cam);\n\tv1158 = UnityEngine.Camera::get_pixelRect(cam);\n\tv1041 = v997 * v1024;\n\tv1042 = v995 * v1024;\n\tv1044 = v996 * v1029;\n\tv1045 = v994 * v1029;\n\tv1046 = v998 + v993;\n\tv1048 = v1046 * 0.5f;\n\tthis.smoothEffectDistance = v1048;\n\tv1051 = this.spriteMode == 0;\n\tv1052 = ~v1051;\n\tif (v1052) goto L_0251;\n\tv1110 = this.particleMode != 1;\n\tif (v1110) goto L_025B;\nL_0251:\n\tv1075 = v1177 + v1048;\n\tgoto L_027A;\nL_FFFFFFFF:\n\treturnVal2 = 0;\n\tgoto L_02FC;\nL_025B:\n\tgoto L_0269;\nL_FFFFFFFF:\n\tv1075 = v993;\n\tgoto L_027A;\nL_FFFFFFFF:\n\tv1075 = v1152;\n\tv1189 = this.realOutlineWidth * 20f;\n\tv1191 = v1189 + 10f;\n\tv1192 = this.outlineDownsampling << 2;\n\tv1193 = this.outlineDownsampling + v1192;\n\tv1195 = v1191 + v1193;\n\tv1200 = v1195 == 0x7F800000;\n\tv1208 = ~v1200;\n\tif (v1208) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv1233 = 0xFFFFFFFF80000000;\n\tgoto L_02A5;\nL_FFFFFFFF:\n\tv1233 = v1195;\nL_02B3:\n\tv1244 = this.glow < 0;\n\tv1245 = this.glow == 0;\n\tv1248 = this.glow == this.glow;\n\tv1249 = ~v1248;\n\tv1250 = v1244 == v1249;\n\tv1251 = ~v1250;\n\tv1076 = v1251 | v1245;\n\tif (v1076) goto L_FFFFFFFF;\n\tv1257 = this.glowWidth * 30f;\n\tv1259 = v1257 + 20f;\n\tv1260 = this.glowDownsampling << 2;\n\tv1261 = this.glowDownsampling + v1260;\n\tv1262 = v1261 << 1;\n\tv1264 = v1259 + v1262;\n\tv1269 = v1264 == 0x7F800000;\n\tv1277 = ~v1269;\n\tif (v1277) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv1286 = 0xFFFFFFFF80000000;\n\tgoto L_02DA;\nL_FFFFFFFF:\n\tv1286 = v1264;\nL_FFFFFFFF:\n\treturnVal2 = 1;\nL_0137:\n\tv805 = v787 - v151;\n\tv445 = this.corners;\nL_FFFFFFFF:\n\tv77 = 0x2C;\nL_FFFFFFFF:\n\tv993 = 0x7F7FFFFF;\nL_FFFFFFFF:\n\tv994 = 0xFFFFFFFFFF7FFFFF;\nL_FFFFFFFF:\n\tv995 = 0xFFFFFFFFFF7FFFFF;\nL_FFFFFFFF:\n\tv996 = 0x7F7FFFFF;\nL_FFFFFFFF:\n\tv997 = 0x7F7FFFFF;\nL_FFFFFFFF:\n\tv998 = 0xFFFFFFFFFF7FFFFF;\n\tgoto L_0170;\nL_0135:\n\tv787 = v802 / v767;\nL_0158:\n\tv77 = v77 + 0x10;\n\tv837 = v77 == 0xAC;\n\tif (v837) goto L_021F;\nL_01A3:\n\tv890 = v805 * v889;\n\tv421 = v151 + v890;\n\tgoto L_01AC;\nL_01CC:\n\tv905 = *([v841 @ X9_v9-8]) < v996;\n\tv913 = ~v905;\n\tif (v913) goto L_01DA;\nL_01DA:\n\tv916 = *([v841 @ X9_v9-C]) < v995;\n\tv917 = *([v841 @ X9_v9-C]) == v995;\n\tv920 = *([v841 @ X9_v9-C]) == *([v841 @ X9_v9-C]);\n\tv921 = v995 == v995;\n\tv922 = v920 & v921;\n\tv923 = ~v922;\n\tv924 = v916 == v923;\n\tv925 = ~v917;\n\tv926 = v924 & v925;\n\tv927 = ~v926;\n\tif (v927) goto L_01EB;\nL_01EB:\n\tv930 = *([v841 @ X9_v9-8]) < v994;\n\tv931 = *([v841 @ X9_v9-8]) == v994;\n\tv934 = *([v841 @ X9_v9-8]) == *([v841 @ X9_v9-8]);\n\tv935 = v994 == v994;\n\tv936 = v934 & v935;\n\tv937 = ~v936;\n\tv938 = v930 == v937;\n\tv939 = ~v931;\n\tv940 = v938 & v939;\n\tv941 = ~v940;\n\tif (v941) goto L_01FC;\nL_01FC:\n\t;\n\tv944 = *([v841 @ X9_v9-4]) < v993;\n\tv952 = ~v944;\n\tif (v952) goto L_0146;\nL_027A:\n\tv1070 = v1158 + v1041;\n\tv1073 = v1158 + v1042;\n\tv1066 = v1044 + v1158.y;\n\tv1062 = v1045 + v1158.y;\n\tv1164 = this.outline < 0;\n\tv1165 = this.outline == 0;\n\tv1168 = this.outline == this.outline;\n\tv1169 = ~v1168;\n\tv1170 = v1164 == v1169;\n\tv1171 = ~v1170;\n\tv1172 = v1171 | v1165;\n\tif (v1172) goto L_02B3;\nL_02FC:\n\treturn returnVal2;\nL_0269:\n\tv1152 = v1177 + 0x3D4CCCCD;\n\tv1144 = v1182.isVrRunning == 0;\n\tv1136 = ~v1144;\n\tv1132 = ~v1136;\n\tif (v1132) goto L_FFFFFFFF;\nL_02A5:\n\t;\n\t// 687 MakeStruct v1210 @ AGG771E6BC_2_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3),\n// ... truncated")]
		private unsafe bool ComputeSmoothQuadMatrixOriginShifted(Camera cam, ref Bounds bounds, ref Vector3 shift)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::ComputeSmoothQuadMatrixOriginShifted");
			return default;
		}

		[Token(Token = "0x6000057")]
		[Address(RVA = "0x771E770", Offset = "0x771E770", Length = "0x26C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv46 = this.extraCoveragePixels + border;\n\tv49 = scrMax.y + v46;\n\tv50 = scrMax + v46;\n\tv51 = scrMin.y - v46;\n\tv52 = scrMin - v46;\n\t// 37 MakeStruct v57 @ AGG771E7D4_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v52 @ V0_v2 (System.Single), v51 @ V11_v2 (System.Single), scrMin.z (System.Single)\n\tv58 = UnityEngine.Camera::ScreenToWorldPoint(cam, v57);\n\t// 49 MakeStruct v89 @ AGG771E7F4_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v50 @ V10_v2 (System.Single), v49 @ V9_v2 (System.Single), scrMax.z (System.Single)\n\tv149 = UnityEngine.Camera::ScreenToWorldPoint(cam, v89);\n\t// 61 MakeStruct v77 @ AGG771E818_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v50 @ V10_v2 (System.Single), v51 @ V11_v2 (System.Single), scrMin.z (System.Single)\n\tv110 = UnityEngine.Camera::ScreenToWorldPoint(cam, v77);\n\tgoto L_004E;\nL_004E:\n\tgoto L_0051;\nL_0051:\n\tgoto L_0055;\nL_0055:\n\tgoto L_005B;\nL_005B:\n\tv349 = UnityEngine.Component::get_transform(cam);\n\tv357 = v58.z + v149.z;\n\tv359 = v357 * 0.5f;\n\tv360 = v359 + shift.z;\n\tv363 = v58.y + v149.y;\n\tv364 = v363 * 0.5f;\n\tv365 = v364 + shift.y;\n\tv367 = v58 + v149;\n\tv368 = v367 * 0.5f;\n\t// 111 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv371 = v368 + shift.x;\n\t// 116 NotImplemented \"Instruction DUP not yet implemented.\"\n\t// 121 NotImplemented \"Instruction DUP not yet implemented.\"\n\t// 127 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv384 = UnityEngine.Transform::get_rotation(v349);\n\t// 149 MakeStruct v215 @ AGG771E938_0_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v371 @ V10_v5 (System.Single), v365 @ V9_v5 (System.Single), v360 @ V8_v5 (System.Single)\n\tv261 = UnityEngine.Matrix4x4::TRS(v215, v384, v51);\n\tquadMatrix.m00 = v261.m00;\n\tquadMatrix.m01 = v261.m01;\n\tquadMatrix.m02 = v261.m02;\n\tquadMatrix.m03 = v261.m03;\n\treturn;\n")]
		private void BuildMatrix(Camera cam, Vector3 scrMin, Vector3 scrMax, int border, ref Matrix4x4 quadMatrix, ref Vector3 shift)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::BuildMatrix");
		}

		[Token(Token = "0x6000058")]
		[Address(RVA = "0x771C42C", Offset = "0x771C42C", Length = "0xC38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv86 = v61.smoothEffectDistance / v61.glowDistanceScaleBias;\n\tv88 = v86 + 1f;\n\tv89 = 0x8BF68FC(v61, rtWidth, rtHeight, methodInfo, v49, v50, v51, v52, v88, v61.glowDistanceScaleBias, v55, v56, v57, v58, v59, v60);\n\tv119 = 1f - v88;\n\tv116 = v61.minimumWidth < v119;\n\tv113 = v61.minimumWidth == v119;\n\tv149 = v61.minimumWidth == v61.minimumWidth;\n\tv104 = v119 == v119;\n\tv107 = v149 & v104;\n\tv101 = ~v107;\n\tv150 = v116 == v101;\n\tv95 = ~v113;\n\tv98 = v150 & v95;\n\tv92 = ~v98;\n\tif (v92) goto L_005A;\nL_FFFFFFFF:\n\tv119 = v61.minimumWidth;\n\tgoto L_005A;\n\tv156 = 0xF + 1;\n\tgoto L_0070;\nL_FFFFFFFF:\n\tv156 = 0xF;\n\tv178 = v176 & 1;\n\tv179 = v178 == 0;\n\tif (v179) goto L_009F;\n\tv273 = v61.fxMatBlurGlow;\nL_FFFFFFFF:\n\tv216 = 1f;\nL_FFFFFFFF:\n\tv219 = 4;\n\tgoto L_0190;\nL_008F:\n\tv180 = v176 & 1;\n\tv181 = v180 == 0;\n\tif (v181) goto L_00C7;\n\tv352 = v61.fxMatBlurGlow;\nL_FFFFFFFF:\n\tv293 = 1f;\nL_FFFFFFFF:\n\tv296 = 8;\n\tgoto L_035B;\nL_009F:\n\tv193 = *([B193A91]) & 1;\n\tv194 = v193 == 0;\n\tif (v194) goto L_00EE;\n\tv1100 = v340 * 4f;\n\tgoto L_00AA;\nL_00AA:\n\tv1112 = 0x8BF6AF4(&v1354 @ stack_-100_v32 (System.Double), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v1100, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1303 = v1100 < 0;\n\tv1307 = v1100 == v1100;\n\tv1308 = ~v1307;\n\tv1309 = v1303 == v1308;\nL_FFFFFFFF:\n\tv216 = v1100;\nL_FFFFFFFF:\n\tv1369 = v1100;\nL_FFFFFFFF:\n\tv1383 = v1354;\nL_FFFFFFFF:\n\tv1384 = v1100;\nL_FFFFFFFF:\n\tv1392 = v1100;\n\tif (v1309) goto L_0105;\nL_00B5:\n\tv1375 = v1369 == -0.5d;\n\tv1382 = ~v1375;\n\tif (v1382) goto L_0154;\nL_FFFFFFFF:\n\tv1750 = -1d;\nL_FFFFFFFF:\n\tv1771 = v1354;\nL_FFFFFFFF:\n\tv1754 = v1354;\n\tgoto L_0111;\nL_00C7:\n\tgoto L_00C8;\nL_00C8:\n\tv1128 = v340 * 4f;\n\tgoto L_00D2;\nL_00D2:\n\tv1140 = 0x8BF6AF4(&v214 @ stack_-100 (System.Single), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v1128, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1317 = v1128 < 0;\n\tv1321 = v1128 == v1128;\n\tv1322 = ~v1321;\n\tv1323 = v1317 == v1322;\nL_FFFFFFFF:\n\tv293 = v1128;\n\tif (v1323) goto L_013B;\n\tv1453 = v1128 == -0.5d;\n\tv1460 = ~v1453;\n\tif (v1460) goto L_031E;\nL_FFFFFFFF:\n\tv1801 = -1d;\nL_FFFFFFFF:\n\tv1822 = v214;\nL_FFFFFFFF:\n\tv1805 = v214;\n\tgoto L_0147;\nL_00EE:\n\t*([B193A91]) = 1;\n\tv1100 = v340 * 4f;\n\tv1103 = *([B193000]);\n\tv1119 = *([v1103 @ X0_v144+E4]) == 0;\n\tv1105 = ~v1119;\n\tif (v1105) goto L_00AA;\n\tv1314 = 0x8BF6AF4(&v1354 @ stack_-100_v32 (System.Double), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v1100, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1367 = v1100 < 0;\n\tv1361 = v1100 == v1100;\n\tv1359 = ~v1361;\n\tv1407 = v1367 == v1359;\n\tv1357 = ~v1407;\nL_FFFFFFFF:\n\tv216 = v1100;\nL_FFFFFFFF:\n\tv1369 = v1100;\nL_FFFFFFFF:\n\tv1383 = v1354;\nL_FFFFFFFF:\n\tv1384 = v1100;\nL_FFFFFFFF:\n\tv1392 = v1100;\n\tif (v1357) goto L_00B5;\nL_0105:\n\tv1398 = v1392 == 0.5d;\n\tv1405 = ~v1398;\n\tif (v1405) goto L_0157;\nL_FFFFFFFF:\n\tv216 = v1384;\nL_FFFFFFFF:\n\tv1750 = 1d;\nL_FFFFFFFF:\n\tv1771 = v1383;\nL_FFFFFFFF:\n\tv1754 = v1383;\n\tgoto L_011D;\nL_FFFFFFFF:\n\tv1771 = v1755;\nL_013B:\n\tv1476 = v1128 == 0.5d;\n\tv1483 = ~v1476;\n\tif (v1483) goto L_0321;\nL_FFFFFFFF:\n\tv293 = v1128;\nL_FFFFFFFF:\n\tv1801 = 1d;\nL_FFFFFFFF:\n\tv1822 = v214;\nL_FFFFFFFF:\n\tv1805 = v214;\n\tgoto L_0153;\nL_FFFFFFFF:\n\tv1822 = v1806;\nL_0154:\n\tv1659 = v216 + -0.5d;\n\tv1771 = System.Math::Ceiling(v1659);\n\tgoto L_015C;\nL_0157:\n\tv1664 = v1384 + 0.5d;\n\tv1771 = System.Math::Floor(v1664);\nL_FFFFFFFF:\n\tv216 = v1384;\nL_015C:\n\tv1779 = v1771 - 1;\n\tv1780 = v1779 < 0;\n\tv1781 = v1779 == 0;\n\tv1782 = v1771 ^ 1;\n\tv211 = v1771 ^ v1779;\n\tv208 = v1782 & v211;\n\tv1783 = v208 < 0;\n\tv1784 = v1780 == v1783;\n\tv230 = ~v1781;\n\tv1785 = v1784 & v230;\n\tv1786 = ~v1785;\n\tif (v1786) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv1885 = v1771;\n\tgoto L_016F;\nL_FFFFFFFF:\n\tv1885 = 1;\nL_FFFFFFFF:\n\tv219 = v1885;\n\tgoto L_017F;\nL_FFFFFFFF:\n\tv219 = 1;\nL_0190:\n\tv373 = v340 / v61.glowDownsampling;\n\tUnityEngine.Material::SetFloat(v273, v369.BlurScale, v373);\n\tv1150 = v61.mipGlowBuffers;\n\tv1151 = v61.mipGlowBuffers == 0;\n\tif (v1151) goto L_01AA;\n\tv1334 = v219 == v1150.Length;\n\tif (v1334) goto L_0209;\nL_01AA:\n\t// 426 NewArr v1353 @ X0_v117 (System.Int32[]), typeof(System.Int32[]), v219 @ X20_v18 (System.Double)\n\tv61.mipGlowBuffers = v1353;\n\tv702 = v219 - 1;\n\tv1730 = v219 < 2;\n\tv1731 = ~v1730;\n\tv1739 = ~v1731;\n\tif (v1739) goto L_01E8;\nL_FFFFFFFF:\n\tv690 = 0;\n\tv769[v690 @ X28_v18 (System.Int32)] = v1008;\n\tv690 = v698 + 1;\n\tv1848 = v690 < v702;\n\tif (v1848) goto L_01BF;\nL_01E8:\n\tv780 = v61.mipGlowBuffers;\n\tgoto L_01F1;\n\tv780[v702 @ X27_v14 (System.Int32)] = v1969.GlowRT;\n\tv214 = v993;\n\tUnityEngine.Rendering.CommandBuffer::GetTemporaryRT(v61.cbHighlight, v1058[v703 @ X27_v12 (System.Int32)], &v214 @ stack_-100 (System.Single), 1);\n\tv703 = v703 + 1;\n\tv1713 = v219 != v703;\nL_FFFFFFFF:\n\tv985 = v61.sourceDesc.mipCount;\n\tif (v1713) goto L_020D;\n\tv849 = v61.useOriginalShader != 1;\n\tif (v849) goto L_025A;\n\tUnityEngine.Rendering.CommandBuffer::EnableShaderKeyword(v61.cbHighlight, *([v691 @ X28_v13 (System.Int32)]));\nL_025A:\n\tv1011 = UnityEngine.Rendering.RenderTargetIdentifier::op_Implicit(v61.sourceRT);\n\tv214 = v993.m_value;\n\tv1060 = v61.mipGlowBuffers;\n\tv2138 = &v540 @ stack_-128_v8 (UnityEngine.Rendering.BuiltinRenderTextureType);\n\tv2140 = UnityEngine.Rendering.RenderTargetIdentifier::op_Implicit(v1060[0]);\n\tv540 = *([v2138 @ X8_v113]);\n\tgoto L_0282;\nL_0282:\n\tv452 = v993.m_value;\n\tv423 = *([v2138 @ X8_v113]);\n\tHighlightPlus.RenderingUtils::FullScreenBlit(v61.cbHighlight, &v452 @ stack_-150_v6 (System.Single), &v423 @ stack_-180_v8 (UnityEngine.Rendering.BuiltinRenderTextureType), v61.fxMatBlurGlow, 3);\n\tUnityEngine.Rendering.CommandBuffer::DisableShaderKeyword(v61.cbHighlight, *([v691 @ X28_v13 (System.Int32)]));\n\tv850 = v219 < 2;\n\tif (v850) goto L_05C5;\n\tv766 = v219 - 1;\nL_FFFFFFFF:\n\tv1093 = 0;\n\tgoto L_02CC;\nL_02AB:\n\tv452 = *([v2223 @ X8_v123]);\n\tv423 = v2238.m_Type;\n\tHighlightPlus.RenderingUtils::FullScreenBlit(v61.cbHighlight, &v452 @ stack_-150_v6 (System.Single), &v423 @ stack_-180_v8 (UnityEngine.Rendering.BuiltinRenderTextureType), v61.fxMatBlurGlow, 3);\n\tv2087 = v766 == v1299;\nL_FFFFFFFF:\n\tv1093 = v1299;\n\tif (v2087) goto L_05C5;\nL_02CC:\n\tgoto L_02D4;\nL_02D4:\n\tv997 = v1093 + 0.5f;\n\tUnityEngine.Rendering.CommandBuffer::SetGlobalFloat(v61.cbHighlight, v2212.ResampleScale, v997);\n\tv1063 = v61.mipGlowBuffers;\n\tv2223 = &v214 @ stack_-100 (System.Single);\n\tv1015 = UnityEngine.Rendering.RenderTargetIdentifier::op_Implicit(v1063[v1093 @ X21_v15 (System.Int32)]);\n\tv214 = *([v2223 @ X8_v123]);\n\tv1299 = v1093 + 1;\n\tv2046 = v1093 << 2;\n\tv2234 = v61.mipGlowBuffers + v2046;\n\tv2238 = UnityEngine.Rendering.RenderTargetIdentifier::op_Implicit(*([v2234 @ X8_v125+24]));\n\tgoto L_02AB;\nL_031E:\n\tv1703 = v293 + -0.5d;\n\tv1822 = System.Math::Ceiling(v1703);\n\tgoto L_0326;\nL_0321:\n\tv1708 = v1128 + 0.5d;\n\tv1822 = System.Math::Floor(v1708);\nL_FFFFFFFF:\n\tv293 = v1128;\nL_0326:\n\tv1830 = v1822 - 1;\n\tv1831 = v1830 < 0;\n\tv1832 = v1830 == 0;\n\tv1833 = v1822 ^ 1;\n\tv289 = v1822 ^ v1830;\n\tv286 = v1833 & v289;\n\tv1834 = v286 < 0;\n\tv1835 = v1831 == v1834;\n\tv309 = ~v1832;\n\tv1836 = v1835 & v309;\n\tv1837 = ~v1836;\n\tif (v1837) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv2000 = v1822;\n\tgoto L_0339;\nL_FFFFFFFF:\n\tv2000 = 1;\n\tgoto L_0349;\nL_FFFFFFFF:\n\tv2000 = 1;\nL_035B:\n\tv998 = v340 / v61.glowDownsampling;\n\tUnityEngine.Material::SetFloat(v352, v1122.BlurScale, v998);\n\tv1315 = v61.mipGlowBuffers;\n\tv1316 = v61.mipGlowBuffers == 0;\n\tif (v1316) goto L_0372;\n\tv1413 = v296 == v1315.Length;\n\tif (v1413) goto L_03B0;\nL_0372:\n\t// 882 NewArr v1431 @ X0_v58 (System.Int32[]), typeof(System.Int32[]), v296 @ X23_v5 (System.Int32)\n\tv61.mipGlowBuffers = v1431;\n\tv1677 = v296 < 1;\n\tif (v1677) goto L_03B0;\nL_FFFFFFFF:\n\tv705 = 0;\n\tv774[v705 @ X27_v8 (System.Int32)] = v1016;\n\tv705 = v389 + 1;\n\tv1676 = v705 < v296;\n\tif (v1676) goto L_0387;\nL_03B0:\n\tv781 = v61.mipGlowBuffers;\n\tgoto L_03BB;\nL_03BB:\n\tv386 = v296 - 2;\n\tv781[v38\n// ... truncated")]
		private unsafe void SmoothGlow(int rtWidth, int rtHeight)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::SmoothGlow");
		}

		[Token(Token = "0x6000059")]
		[Address(RVA = "0x771D064", Offset = "0x771D064", Length = "0x76C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv89 = v61.outlineBlurPasses / 5f;\n\tv90 = v61.realOutlineWidth < v61.outlineBlurPasses;\n\tv91 = v61.realOutlineWidth == v61.outlineBlurPasses;\n\tv94 = v61.realOutlineWidth == v61.realOutlineWidth;\n\tv95 = v61.outlineBlurPasses == v61.outlineBlurPasses;\n\tv96 = v94 & v95;\n\tv97 = ~v96;\n\tv98 = v90 == v97;\n\tv99 = ~v91;\n\tv100 = v98 & v99;\n\tv101 = ~v100;\n\tif (v101) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv125 = v61.outlineBlurPasses;\n\tgoto L_0051;\nL_FFFFFFFF:\n\tv125 = v61.realOutlineWidth;\nL_FFFFFFFF:\n\tv268 = v89;\n\tgoto L_006B;\nL_FFFFFFFF:\n\tv268 = v125;\n\tv144 = v61.outlineBlurPasses;\n\tv284 = v61.fxMatBlurOutline;\n\tgoto L_009E;\nL_0075:\n\tv266 = v61.minimumWidth;\n\tv153 = v61.smoothEffectDistance / v61.outlineDistanceScaleBias;\n\tv155 = v153 + 1f;\n\tv156 = 0x8BF68FC(v61, rtWidth, rtHeight, methodInfo, v49, v50, v51, v52, v155, v61.outlineDistanceScaleBias, v55, v56, v57, v58, v59, v60);\n\tv211 = 1f - v155;\n\tv228 = v61.minimumWidth < v211;\n\tv229 = v61.minimumWidth == v211;\n\tv232 = v61.minimumWidth == v61.minimumWidth;\n\tv233 = v211 == v211;\n\tv234 = v232 & v233;\n\tv235 = ~v234;\n\tv236 = v228 == v235;\n\tv185 = ~v229;\n\tv188 = v236 & v185;\n\tv182 = ~v188;\n\tif (v182) goto L_008E;\nL_FFFFFFFF:\n\tv211 = v61.minimumWidth;\n\tgoto L_008E;\n\tv284 = v61.fxMatBlurOutline;\n\tgoto L_009E;\nL_009E:\n\tv225 = v284 == 0;\n\tv226 = ~v225;\n\tif (v226) goto L_013A;\n\tgoto L_03A6;\nL_00A9:\n\tgoto L_00AA;\nL_00AA:\n\tv1061 = v268 * v61.outlineBlurPasses;\n\tgoto L_00B2;\nL_00B2:\n\tv1073 = 0x8BF6AF4(&v169 @ stack_-100 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v1061, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1114 = v1061 < 0;\n\tv1118 = v1061 == v1061;\n\tv1119 = ~v1118;\n\tv1120 = v1114 == v1119;\nL_FFFFFFFF:\n\tv266 = v1061;\n\tif (v1120) goto L_00E5;\n\tv1151 = v1061 == -0.5d;\n\tv1158 = ~v1151;\n\tif (v1158) goto L_00FE;\nL_FFFFFFFF:\n\tv1228 = -1d;\nL_FFFFFFFF:\n\tv1249 = v169;\nL_FFFFFFFF:\n\tv1232 = v169;\n\tgoto L_00F1;\nL_00E5:\n\tv1174 = v1061 == 0.5d;\n\tv1181 = ~v1174;\n\tif (v1181) goto L_0101;\nL_FFFFFFFF:\n\tv266 = v1061;\nL_FFFFFFFF:\n\tv1228 = 1d;\nL_FFFFFFFF:\n\tv1249 = v169;\nL_FFFFFFFF:\n\tv1232 = v169;\n\tgoto L_00FD;\nL_FFFFFFFF:\n\tv1249 = v1233;\nL_00FE:\n\tv1190 = v266 + -0.5d;\n\tv1249 = System.Math::Ceiling(v1190);\n\tgoto L_0106;\nL_0101:\n\tv1195 = v1061 + 0.5d;\n\tv1249 = System.Math::Floor(v1195);\nL_FFFFFFFF:\n\tv266 = v1061;\nL_0106:\n\tv1257 = v1249 - 1;\n\tv1258 = v1257 < 0;\n\tv1259 = v1257 == 0;\n\tv1260 = v1249 ^ 1;\n\tv167 = v1249 ^ v1257;\n\tv165 = v1260 & v167;\n\tv1261 = v165 < 0;\n\tv1262 = v1258 == v1261;\n\tv186 = ~v1259;\n\tv1263 = v1262 & v186;\n\tv1264 = ~v1263;\n\tif (v1264) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv1343 = v1249;\n\tgoto L_0119;\nL_FFFFFFFF:\n\tv1343 = 1;\nL_FFFFFFFF:\n\tv177 = v1343;\n\tgoto L_012A;\nL_FFFFFFFF:\n\tv177 = 1;\nL_013A:\n\tv290 = v268 / v61.outlineDownsampling;\n\tUnityEngine.Material::SetFloat(v284, v286.BlurScale, v290);\n\tv698 = v268 + v268;\n\tUnityEngine.Material::SetFloat(v61.fxMatBlurOutline, v881.BlurScaleFirstHoriz, v698);\n\tv609 = v144 << 1;\n\tv891 = v61.mipOutlineBuffers;\n\tv892 = v61.mipOutlineBuffers == 0;\n\tif (v892) goto L_015B;\n\tv1042 = v609 == v891.Length;\n\tif (v1042) goto L_0199;\nL_015B:\n\t// 347 NewArr v1060 @ X0_v54 (System.Int32[]), typeof(System.Int32[]), v609 @ X23_v4 (System.Int32)\n\tv61.mipOutlineBuffers = v1060;\n\tv1092 = v609 < 1;\n\tif (v1092) goto L_0199;\nL_FFFFFFFF:\n\tv548 = 0;\n\tv296[v548 @ X25_v8 (System.Int32)] = v707;\n\tv548 = v552 + 1;\n\tv1091 = v548 < v609;\n\tif (v1091) goto L_0170;\nL_0199:\n\tv550 = v61.mipOutlineBuffers;\n\tgoto L_01A3;\nL_01A3:\n\tv530 = v609 - 2;\n\tv550[v530 @ X24_v5 (System.Int32)] = v1197.OutlineRT;\n\tv1203 = v61.sourceDesc;\n\tUnityEngine.RenderTextureDescriptor::set_depthBufferBits(&v1203 @ stack_-C0_v4 (UnityEngine.RenderTextureDescriptor), 0);\n\tv549 = v609 - 1;\n\tv1275 = v609 < 1;\n\tif (v1275) goto L_0217;\n\t// 464 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 466 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\nL_FFFFFFFF:\n\tv544 = 0;\n\tv169 = v699;\n\tUnityEngine.Rendering.CommandBuffer::GetTemporaryRT(v61.cbHighlight, v735[v544 @ X26_v10 (System.Int32)], &v169 @ stack_-100 (System.Int32), 1);\n\tv544 = v544 + 1;\n\tv1311 = v609 != v544;\nL_FFFFFFFF:\n\tv169 = v699;\n\tif (v1311) goto L_01D4;\nL_0217:\n\tv1342 = v549 < 1;\n\tif (v1342) goto L_03A5;\nL_FFFFFFFF:\n\tv610 = 0;\n\tgoto L_022A;\nL_021D:\n\tv610 = v610 + 2;\n\tv1391 = v610 >= v549;\n\tif (v1391) goto L_03A5;\nL_022A:\n\tv1420 = v610 == 0;\n\tif (v1420) goto L_028C;\n\tv736 = v61.mipOutlineBuffers;\n\tv711 = UnityEngine.Rendering.RenderTargetIdentifier::op_Implicit(v736[v610 @ X23_v8 (System.Int32)]);\n\tv169 = v169.m_value;\n\tv737 = v61.mipOutlineBuffers;\n\tv524 = v610 | 1;\n\tv1452 = UnityEngine.Rendering.RenderTargetIdentifier::op_Implicit(v737[v524 @ X9_v16 (System.Int32)]);\n\tv415 = v1452.m_Type;\n\tgoto L_0273;\nL_0273:\n\tv347 = v169.m_value;\n\tv324 = v1452.m_Type;\n\tHighlightPlus.RenderingUtils::FullScreenBlit(v61.cbHighlight, &v347 @ stack_-150_v6 (System.Int32), &v324 @ stack_-180_v8 (UnityEngine.Rendering.BuiltinRenderTextureType), v61.fxMatBlurOutline, 0);\n\tv875 = v61.mipOutlineBuffers;\n\tv1483 = v61.mipOutlineBuffers == 0;\n\tv726 = ~v1483;\n\tif (v726) goto L_02CE;\n\tgoto L_03A6;\nL_028C:\n\tv713 = UnityEngine.Rendering.RenderTargetIdentifier::op_Implicit(v61.sourceRT);\n\tv169 = v169.m_value;\n\tv739 = v61.mipOutlineBuffers;\n\tv1440 = UnityEngine.Rendering.RenderTargetIdentifier::op_Implicit(v739[1]);\n\tv415 = v1440.m_Type;\n\tgoto L_02BA;\nL_02CE:\n\tv526 = v610 | 1;\n\tv1486 = &v169 @ stack_-100 (System.Int32);\n\tv715 = UnityEngine.Rendering.RenderTargetIdentifier::op_Implicit(v875[v526 @ X9_v9 (System.Int32)]);\n\tv169 = *([v1486 @ X8_v24]);\n\tv741 = v61.mipOutlineBuffers;\n\tv1490 = &v415 @ stack_-128_v8 (UnityEngine.Rendering.BuiltinRenderTextureType);\n\tv1492 = UnityEngine.Rendering.RenderTargetIdentifier::op_Implicit(v741[v610 @ X23_v8 (System.Int32)]);\n\tv415 = *([v1490 @ X8_v27]);\n\tgoto L_0314;\n\tv742 = v61.mipOutlineBuffers;\n\tv717 = UnityEngine.Rendering.RenderTargetIdentifier::op_Implicit(v742[v610 @ X23_v8 (System.Int32)]);\n\tv169 = v169.m_value;\n\tv743 = v61.mipOutlineBuffers;\n\tv610 = v610 + 2;\n\tv1515 = UnityEngine.Rendering.RenderTargetIdentifier::op_Implicit(v743[v610 @ X23_v8 (System.Int32)]);\n\tv415 = v1515.m_Type;\n\tgoto L_0378;\nL_03A5:\n\treturn;\nL_03A6:\n\tv756 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\nL_002F:\n\tv268 = v61.realOutlineWidth;\n\tv82 = v61.outlineEdgeMode != 1;\n\tif (v82) goto L_006B;\nL_0051:\n\tv122 = v268 < v89;\n\tv107 = ~v122;\n\tif (v107) goto L_FFFFFFFF;\nL_008E:\n\tv268 = v268 * v211;\n\tv144 = v61.outlineBlurPasses;\n\tv206 = v268 < 1f;\n\tif (v206) goto L_00A9;\nL_00F1:\n\tv1233 = v1249 + v1228;\n\tv1234 = v1232 & 1;\n\tv1236 = v1234 == 0;\n\tv1239 = ~v1236;\n\tif (v1239) goto L_FFFFFFFF;\nL_00FD:\n\tgoto L_0106;\nL_0119:\n\tv204 = v1249 == 0x7FF0000000000000;\n\tv189 = ~v204;\n\tv183 = ~v189;\n\tif (v183) goto L_FFFFFFFF;\nL_012A:\n\tv212 = v61.outlineBlurPasses / v177;\n\tv268 = v268 * v212;\n\tv284 = v61.fxMatBlurOutline;\nL_FFFFFFFF:\n\tv144 = v177;\n\tgoto L_009E;\nL_0170:\n\tv296 = v61.mipOutlineBuffers;\n\tv1217 = System.Int32::ToString(&v552 @ stack_-C4_v7 (System.Int32));\n\tv1278 = System.String::Concat(\"_HPSmoothOutlineTemp\", v1217);\n\tv707 = UnityEngine.Shader::PropertyToID(v1278);\nL_01D4:\n\tv1351 = v544 >> 1;\n\tv1352 = v1351 & 0x7FFFFFFF;\n\tv1353 = v1352 + 2;\n\t// 472 NotImplemented \"Instruction DUP not yet implemented.\"\n\tv1355 = v266 / v1353;\n\t// 474 NotImplemented \"Instruction FCMEQ not yet implemented.\"\n\t// 475 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\t// 476 NotImplemented \"Instruction SMAX not yet implemented.\"\n\tv1356 = ~v61.sourceDesc.mipCount;\n\tv1357 = v1355 & v1356;\n\tv699 = v1357 - v61.sourceDesc.mipCount;\n\tv735 = v61.mipOutlineBuffers;\nL_02BA:\n\tv347 = v169.m_value;\n\tv324 = v1440.m_Type;\n\tHighlightPlus.RenderingUtils::FullScreenBlit(v61.cbHighlight, &v347 @ stack_-150_v6 (System.Int32), &v324 @ stack_-180_v8 (UnityEngine.Rendering.BuiltinRenderTextureType), v61.fxMatBlurOutline, 3);\n\tv875 = v61.mipOutlineBuffers;\nL_0314:\n\tv347 = *([v1486 @ X8_v24]);\n\tv324 = *([v1490 @ X8_v27]);\n\tHighlightPlus.RenderingUtils::FullScreenBlit(\n// ... truncated")]
		private unsafe void SmoothOutline(int rtWidth, int rtHeight)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::SmoothOutline");
		}

		[Token(Token = "0x600005A")]
		[Address(RVA = "0x771D7D0", Offset = "0x771D7D0", Length = "0x598")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv122 = UnityEngine.Rendering.RenderTargetIdentifier::op_Implicit(2);\n\tv131 = v122.m_Type;\n\tv94 = this.depthAttachmentBuffer;\n\tv149 = v122.m_Type;\n\tv156 = UnityEngine.Rendering.RenderTargetIdentifier::op_Equality(&v94 @ stack_-150_v1 (UnityEngine.Rendering.RenderTargetIdentifier), &v149 @ stack_-180_v4 (UnityEngine.Rendering.BuiltinRenderTextureType));\n\tv208 = this + 0x4F0;\n\tv233 = this.cbHighlight;\n\tv193 = v156 == 0;\nL_FFFFFFFF:\n\tv161 = this.colorAttachmentBuffer;\n\tif (v193) goto L_0091;\nL_FFFFFFFF:\n\tv235 = v237;\n\tgoto L_00A7;\nL_0087:\n\tv208 = this + 0x4F0;\n\tv233 = this.cbHighlight;\nL_FFFFFFFF:\n\tv161 = this.colorAttachmentBuffer;\nL_00A7:\n\tv161 = *([v235 @ X8_v7]);\n\tv131 = this.depthAttachmentBuffer;\n\tUnityEngine.Rendering.CommandBuffer::SetRenderTarget(v233, &v161 @ stack_-1C0_v12 (UnityEngine.Rendering.RenderTargetIdentifier), &v131 @ stack_-120_v7 (UnityEngine.Rendering.BuiltinRenderTextureType));\n\tv571 = this.glow < 0;\n\tv572 = this.glow == 0;\n\tv575 = this.glow == this.glow;\n\tv576 = ~v575;\n\tv577 = v571 == v576;\n\tv578 = ~v577;\n\tv579 = v578 | v572;\n\tif (v579) goto L_0114;\n\tv581 = this.glowWidth < 0;\n\tv582 = this.glowWidth == 0;\n\tv585 = this.glowWidth == this.glowWidth;\n\tv586 = ~v585;\n\tv587 = v581 == v586;\n\tv588 = ~v587;\n\tv589 = v588 | v582;\n\tif (v589) goto L_0114;\n\tv597 = this.glowQuality != 2;\n\tif (v597) goto L_0114;\n\tgoto L_00E8;\nL_00F4:\n\tv845 = v834.isVrRunning != 1;\n\tif (v845) goto L_FFFFFFFF;\n\tv893 = this.flipY == 0;\n\tv900 = ~v893;\n\tv901 = ~v900;\n\tif (v901) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv495 = -1f;\n\tgoto L_010A;\nL_FFFFFFFF:\n\tv495 = 1f;\nL_FFFFFFFF:\n\tv500 = 1f;\n\tgoto L_0111;\nL_FFFFFFFF:\n\tv500 = 0;\nL_0114:\n\tv613 = this.outline < 0;\n\tv614 = this.outline == 0;\n\tv617 = this.outline == this.outline;\n\tv618 = ~v617;\n\tv619 = v613 == v618;\n\tv620 = ~v619;\n\tv621 = v620 | v614;\nL_FFFFFFFF:\n\tv329 = 1;\nL_FFFFFFFF:\n\tv746 = 1;\n\tif (v621) goto L_01E3;\nL_011F:\n\tv728 = this.realOutlineWidth < 0;\n\tv729 = this.realOutlineWidth == 0;\n\tv732 = this.realOutlineWidth == this.realOutlineWidth;\n\tv733 = ~v732;\n\tv734 = v728 == v733;\n\tv735 = ~v734;\n\tv736 = v735 | v729;\nL_FFFFFFFF:\n\tv746 = v329;\n\tif (v736) goto L_01E3;\n\tv756 = this.outlineQuality != 2;\nL_FFFFFFFF:\n\tv746 = v329;\n\tif (v756) goto L_01E3;\n\tgoto L_0146;\nL_0152:\n\tv928 = v917.isVrRunning != 1;\n\tif (v928) goto L_FFFFFFFF;\n\tv974 = this.flipY == 0;\n\tv981 = ~v974;\n\tv982 = ~v981;\n\tif (v982) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv497 = -1f;\n\tgoto L_0168;\nL_FFFFFFFF:\n\tv497 = 1f;\nL_FFFFFFFF:\n\tv502 = 1f;\n\tgoto L_016F;\nL_FFFFFFFF:\n\tv502 = 0;\nL_FFFFFFFF:\n\tv495 = 1f;\nL_FFFFFFFF:\n\tv500 = 0;\nL_0187:\n\t// 391 MakeStruct v309 @ AGG771DB08_2_v6 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), v500 @ V0_v28 (System.Single), v495 @ V1_v22 (System.Single), 0, 0\n\tUnityEngine.Material::SetVector(this.fxMatComposeGlow, v819.Flip, v309);\n\tgoto L_019C;\nL_019C:\n\tv1032 = smoothGlowVisibility != 2;\n\tif (v1032) goto L_FFFFFFFF;\n\tv1047 = 4 + 1;\n\tgoto L_01AC;\nL_FFFFFFFF:\n\tv1047 = 4;\nL_FFFFFFFF:\n\tv478 = 8;\n\tgoto L_01B7;\nL_FFFFFFFF:\n\tv478 = v1047;\nL_01CA:\n\tv711 = this.quadGlowMatrix;\n\tUnityEngine.Rendering.CommandBuffer::DrawMesh(*([v208 @ X24_v1]), v713.quadMesh, &v711 @ stack_-1C0_v10 (UnityEngine.Matrix4x4), this.fxMatComposeGlow, 0, 0);\n\tv708 = this.outline < 0;\n\tv706 = this.outline == 0;\n\tv702 = this.outline == this.outline;\n\tv700 = ~v702;\n\tv1079 = v708 == v700;\n\tv685 = ~v706;\n\tv698 = v1079 & v685;\nL_FFFFFFFF:\n\tv329 = 0;\nL_FFFFFFFF:\n\tv746 = 0;\n\tif (v698) goto L_011F;\nL_01E3:\n\tv783 = v746 & 1;\n\tv784 = v783 == 0;\nL_FFFFFFFF:\n\tv565 = 1;\nL_FFFFFFFF:\n\tv563 = 1;\n\tif (v784) goto L_0286;\nL_01E6:\n\tv812 = v565 & 1;\n\tv813 = v812 == 0;\n\tif (v813) goto L_01FD;\nL_01EE:\n\tUnityEngine.Rendering.CommandBuffer::ReleaseTemporaryRT(*([v208 @ X24_v1]), this.sourceRT);\n\treturn;\nL_01FD:\n\tv538 = this.mipOutlineBuffers;\nL_FFFFFFFF:\n\tv566 = 0;\n\tUnityEngine.Rendering.CommandBuffer::ReleaseTemporaryRT(*([v208 @ X24_v1]), v538[v566 @ X20_v6 (System.Int32)]);\n\tv566 = v566 + 1;\n\tv538 = this.mipOutlineBuffers;\n\tv1015 = this.mipOutlineBuffers == 0;\n\tv525 = ~v1015;\n\tif (v525) goto L_0201;\n\tgoto L_02A3;\nL_FFFFFFFF:\n\tv497 = 1f;\nL_FFFFFFFF:\n\tv502 = 0;\nL_0232:\n\t// 562 MakeStruct v270 @ AGG771DC78_2_v4 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), v502 @ V0_v17 (System.Single), v497 @ V1_v14 (System.Single), 0, 0\n\tUnityEngine.Material::SetVector(this.fxMatComposeOutline, v850.Flip, v270);\n\tgoto L_0247;\nL_0247:\n\tv1046 = smoothOutlineVisibility != 2;\n\tif (v1046) goto L_FFFFFFFF;\n\tv1053 = 4 + 1;\n\tgoto L_0257;\nL_FFFFFFFF:\n\tv1053 = 4;\nL_FFFFFFFF:\n\tv479 = 8;\n\tgoto L_0262;\nL_FFFFFFFF:\n\tv479 = v1053;\nL_0275:\n\tv797 = this.quadOutlineMatrix;\n\tUnityEngine.Rendering.CommandBuffer::DrawMesh(*([v208 @ X24_v1]), v799.quadMesh, &v797 @ stack_-1C0_v9 (UnityEngine.Matrix4x4), this.fxMatComposeOutline, 0, 0);\n\tv1082 = v329 & 1;\n\tv1083 = v1082 == 0;\n\tv807 = ~v1083;\nL_FFFFFFFF:\n\tv565 = 0;\nL_FFFFFFFF:\n\tv563 = 0;\n\tif (v807) goto L_01E6;\nL_0286:\n\tv543 = this.mipGlowBuffers;\nL_FFFFFFFF:\n\tv559 = 0;\n\tUnityEngine.Rendering.CommandBuffer::ReleaseTemporaryRT(*([v208 @ X24_v1]), v543[v559 @ X21_v5 (System.Int32)]);\n\tv559 = v559 + 1;\n\tv543 = this.mipGlowBuffers;\n\tv1008 = this.mipGlowBuffers == 0;\n\tv519 = ~v1008;\n\tif (v519) goto L_028A;\nL_02A3:\n\tthrow System.NullReferenceException;\nL_002C:\n\tv237 = this + 0x670;\n\tv74 = &v131 @ stack_-120_v7 (UnityEngine.Rendering.BuiltinRenderTextureType);\n\tv78 = UnityEngine.Rendering.RenderTargetIdentifier::op_Implicit(2);\n\tv131 = *([v74 @ X8_v4]);\n\tv94 = this.colorAttachmentBuffer;\n\tv149 = *([v74 @ X8_v4]);\n\tv107 = UnityEngine.Rendering.RenderTargetIdentifier::op_Inequality(&v94 @ stack_-150_v1 (UnityEngine.Rendering.RenderTargetIdentifier), &v149 @ stack_-180_v4 (UnityEngine.Rendering.BuiltinRenderTextureType));\n\tv111 = v107 == 0;\n\tif (v111) goto L_0087;\nL_0091:\n\tv198 = v161;\n\tv237 = this + 0x698;\nL_FFFFFFFF:\n\tv235 = &v198 @ stack_-90_v3 (UnityEngine.Rendering.RenderTargetIdentifier);\nL_00E8:\n\tgoto L_00F4;\nL_010A:\n\tv945 = ~v893;\n\tv944 = ~v945;\n\tif (v944) goto L_FFFFFFFF;\nL_0111:\n\tgoto L_0187;\nL_0146:\n\tgoto L_0152;\nL_0168:\n\tv1004 = ~v974;\n\tv1003 = ~v1004;\n\tif (v1003) goto L_FFFFFFFF;\nL_016F:\n\tgoto L_0232;\nL_01AC:\n\tv336 = smoothGlowVisibility != 1;\n\tif (v336) goto L_FFFFFFFF;\nL_01B7:\n\tUnityEngine.Material::SetInt(this.fxMatComposeGlow, v1056.ZTest, v478);\n\tgoto L_01CA;\nL_0201:\n\t;\n\tv381 = v566 >= v538.Length;\n\tif (v381) goto L_01EE;\nL_0257:\n\tv337 = smoothOutlineVisibility != 1;\n\tif (v337) goto L_FFFFFFFF;\nL_0262:\n\tUnityEngine.Material::SetInt(this.fxMatComposeOutline, v1065.ZTest, v479);\n\tgoto L_0275;\nL_028A:\n\t;\n\tv377 = v559 >= v543.Length;\nL_FFFFFFFF:\n\tv565 = v563;\n\tif (v377) goto L_01E6;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void ComposeSmoothBlend(Visibility smoothGlowVisibility, Visibility smoothOutlineVisibility)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::ComposeSmoothBlend");
		}

		[Token(Token = "0x600005B")]
		[Address(RVA = "0x771E9F8", Offset = "0x771E9F8", Length = "0x22C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tgoto L_001C;\nL_001C:\n\tv60 = UnityEngine.Object::op_Inequality(*([material @ X1 (UnityEngine.Material&)]), 0);\n\tv70 = v60 == 0;\n\tif (v70) goto L_004E;\n\treturn;\nL_004E:\n\tgoto L_0052;\nL_0052:\n\tv165 = UnityEngine.Object::op_Equality(*([cachedShader @ X2 (UnityEngine.Shader&)]), 0);\n\tv170 = ~v165;\n\tv171 = ~v170;\n\tif (v171) goto L_0060;\n\tgoto L_0097;\nL_0060:\n\tv185 = UnityEngine.Shader::Find(shaderName);\n\t*([cachedShader @ X2 (UnityEngine.Shader&)]) = v185;\n\tgoto L_006D;\nL_006D:\n\tv194 = UnityEngine.Object::op_Equality(*([cachedShader @ X2 (UnityEngine.Shader&)]), 0);\n\tv196 = ~v194;\n\tif (v196) goto L_0097;\n\tv129 = System.String::Concat(\"Shader \", shaderName, \" not found.\");\n\tgoto L_0089;\nL_0089:\n\tUnityEngine.Debug::LogError(v129);\n\treturn;\nL_0097:\n\tv204 = new UnityEngine.Material();\n\tUnityEngine.Material::.ctor(v204, *([cachedShader @ X2 (UnityEngine.Shader&)]));\n\t*([material @ X1 (UnityEngine.Material&)]) = v204;\n\treturn;\n")]
		private void InitMaterial(ref Material material, ref Shader cachedShader, string shaderName)
		{
			if (material != null)
			{
				return;
			}
			if (cachedShader == null)
			{
				Shader shader = Shader.Find(shaderName);
				cachedShader = shader;
				if (cachedShader == null)
				{
					string message = "Shader " + shaderName + " not found.";
					Debug.LogError(message);
					return;
				}
			}
			Material material2 = new Material(cachedShader);
			material = material2;
		}

		[Token(Token = "0x600005C")]
		[Address(RVA = "0x771EC24", Offset = "0x771EC24", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv72 = v57.Length >= count;\n\tif (v72) goto L_0045;\nL_0033:\n\tHighlightPlus.HighlightEffect::DestroyMaterialArray(v52, *([array @ X2 (UnityEngine.Material[]&)]));\n\t// 54 NewArr v124 @ X0_v31 (UnityEngine.Material[]), typeof(UnityEngine.Material[]), count @ X3 (System.Int32)\n\t*([array @ X2 (UnityEngine.Material[]&)]) = v124;\nL_0045:\n\tv121 = count < 1;\n\tif (v121) goto L_00B1;\n\tv143 = 0x20;\n\tv184 = 0;\n\tgoto L_006A;\nL_005A:\n\t*([v133 @ X27_v6 (UnityEngine.Material[])+v143 @ X25_v4 (System.Int32)]) = v277;\nL_005E:\n\tv184 = v184 + 1;\n\tv143 = v143 + 8;\n\tv164 = count == v184;\n\tif (v164) goto L_00B1;\nL_006A:\n\tv218 = array->klass;\n\tgoto L_0080;\nL_0080:\n\tv304 = UnityEngine.Object::op_Equality(*([v218 @ X8_v6 (UnityEngine.Material[])+v143 @ X25_v4 (System.Int32)]), 0);\n\tv306 = ~v304;\n\tif (v306) goto L_005E;\n\tgoto L_008B;\nL_008B:\n\tv133 = array->klass;\n\tgoto L_0094;\nL_0094:\n\tv277 = UnityEngine.Object::Instantiate(material);\n\tv332 = v277 == 0;\n\tif (v332) goto L_005A;\n\tv335 = 0x21C11D0(v277, UnityEngine.Material, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv338 = v335 == 0;\n\tv178 = ~v338;\n\tif (v178) goto L_005A;\n\tv340 = new System.ArrayTypeMismatchException();\n\tthrow v340;\nL_00B1:\n\treturn;\nL_0022:\n\tv57 = array->klass;\n\tv58 = *([array @ X2 (UnityEngine.Material[]&)]) == 0;\n\tif (v58) goto L_0033;\n")]
		private void Fork(Material material, ref Material[] array, int count)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::Fork");
		}

		[Token(Token = "0x600005D")]
		[Address(RVA = "0x770C828", Offset = "0x770C828", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv53 = UnityEngine.Object::op_Equality(transform, 0);\n\tv61 = v53 == 0;\n\tif (v61) goto L_0038;\n\treturn;\nL_0038:\n\tHighlightPlus.HighlightEffect::InitIfNeeded(this);\n\tgoto L_0041;\nL_0041:\n\tv152 = UnityEngine.Object::op_Inequality(transform, this.target);\n\tv154 = ~v152;\n\tif (v154) goto L_0070;\n\tv88 = this.highlighted != 1;\n\tif (v88) goto L_0052;\n\tHighlightPlus.HighlightEffect::ImmediateFadeOut(this);\nL_0052:\n\tthis.target = transform;\n\tHighlightPlus.HighlightEffect::SetupMaterial(this);\n\treturn;\nL_0070:\n\tHighlightPlus.HighlightEffect::UpdateVisibilityState(this);\n\treturn;\n")]
		public void SetTarget(Transform transform)
		{
			if (transform == null)
			{
				return;
			}
			InitIfNeeded();
			if (transform != target)
			{
				if (highlighted)
				{
					ImmediateFadeOut();
				}
				_target = transform;
				SetupMaterial();
			}
			else
			{
				UpdateVisibilityState();
			}
		}

		[Token(Token = "0x600005E")]
		[Address(RVA = "0x771EF08", Offset = "0x771EF08", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tgoto L_001B;\nL_001B:\n\tv58 = UnityEngine.Object::op_Equality(transform, 0);\n\tv66 = v58 == 0;\n\tif (v66) goto L_003D;\n\treturn;\nL_003D:\n\tHighlightPlus.HighlightEffect::InitIfNeeded(this);\n\tv95 = this.highlighted != 1;\n\tif (v95) goto L_004D;\n\tHighlightPlus.HighlightEffect::ImmediateFadeOut(this);\nL_004D:\n\tthis.effectGroup = 5;\n\tthis.target = transform;\n\tHighlightPlus.HighlightEffect::SetupMaterial(this, renderers);\n\treturn;\n")]
		public void SetTargets(Transform transform, Renderer[] renderers)
		{
			if (!(transform == null))
			{
				InitIfNeeded();
				if (highlighted)
				{
					ImmediateFadeOut();
				}
				effectGroup = TargetOptions.Scripting;
				_target = transform;
				SetupMaterial(renderers);
			}
		}

		[Token(Token = "0x600005F")]
		[Address(RVA = "0x770B9D4", Offset = "0x770B9D4", Length = "0x34C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv62 = this.OnObjectHighlightStateChange == 0;\nL_FFFFFFFF:\n\t;\n\tif (v62) goto L_0038;\n\tv84 = UnityEngine.Component::get_gameObject(this);\n\tv70 = HighlightPlus.OnObjectHighlightStateEvent::Invoke(this.OnObjectHighlightStateChange, v84, state);\n\tv72 = v70 == 0;\nL_FFFFFFFF:\n\t;\n\tif (v72) goto L_0083;\nL_0038:\n\tv78 = ~state;\n\tv79 = ~v78;\n\tif (v79) goto L_0066;\n\tgoto L_0040;\nL_0040:\n\tv105 = UnityEngine.Application::get_isPlaying();\n\tv209 = v105 == 0;\n\tif (v209) goto L_0079;\n\tgoto L_004E;\nL_004E:\n\tgoto L_0052;\nL_0052:\n\tgoto L_0056;\nL_0056:\n\tv346 = v343.useUnscaledTime == 0;\n\tif (v346) goto L_009E;\n\tv161 = UnityEngine.Time::get_unscaledTime();\n\tv395 = this.fading;\n\tv374 = this.fading == 0;\n\tv375 = ~v374;\nL_FFFFFFFF:\n\tv158 = v161;\n\tif (v375) goto L_00A3;\nL_FFFFFFFF:\n\tv157 = v161;\nL_FFFFFFFF:\n\tv388 = v161;\nL_FFFFFFFF:\n\tv191 = this.fading;\n\tgoto L_00A7;\nL_0066:\n\tgoto L_006A;\nL_0079:\n\tthis.highlighted = state;\nL_009E:\n\tv161 = UnityEngine.Time::get_time();\n\tv395 = this.fading;\n\tv378 = this.fading == 0;\nL_FFFFFFFF:\n\tv158 = v161;\nL_FFFFFFFF:\n\tv157 = v161;\nL_FFFFFFFF:\n\tv388 = v161;\nL_FFFFFFFF:\n\tv191 = this.fading;\n\tif (v378) goto L_00A7;\nL_00A3:\n\tv385 = ~state;\n\tv386 = ~v385;\n\tif (v386) goto L_00AC;\nL_FFFFFFFF:\n\tv157 = v158;\nL_FFFFFFFF:\n\tv191 = v395;\n\tgoto L_00B8;\nL_00A7:\n\tthis.fadeStartTime = v157;\n\tv393 = ~state;\nL_FFFFFFFF:\n\tv158 = v157;\nL_FFFFFFFF:\n\tv161 = v388;\nL_FFFFFFFF:\n\tv395 = v191;\n\tif (v393) goto L_00B8;\nL_00AC:\n\tv397 = this.ignore == 0;\nL_FFFFFFFF:\n\tv157 = v158;\nL_FFFFFFFF:\n\tv191 = v395;\n\tif (v397) goto L_00F0;\nL_00B8:\n\tv126 = this.highlighted != 1;\n\tif (v126) goto L_0083;\n\tv255 = this.fadeOutDuration < 0;\n\tv252 = this.fadeOutDuration == 0;\n\tv258 = this.fadeOutDuration == this.fadeOutDuration;\n\tv243 = ~v258;\n\tv403 = v255 == v243;\n\tv404 = ~v403;\n\tv240 = v404 | v252;\n\tif (v240) goto L_013F;\n\tv239 = v191 != 1;\n\tif (v239) goto L_00E5;\n\tv428 = v157 - this.fadeStartTime;\n\tv430 = v157 + v428;\n\tv441 = v430 - this.fadeInDuration;\n\tv432 = v441 < v157;\n\tv440 = ~v432;\n\tif (v440) goto L_FFFFFFFF;\n\tgoto L_00E3;\nL_FFFFFFFF:\n\tv441 = v157;\nL_00F0:\n\tv400 = v395 == 0;\n\tv401 = ~v400;\n\tif (v401) goto L_00F8;\n\tv406 = this.highlighted == 0;\n\tv186 = ~v406;\n\tif (v186) goto L_0083;\nL_00F8:\n\t;\n\tv409 = this.OnObjectHighlightStart == 0;\n\tif (v409) goto L_010D;\n\tv419 = UnityEngine.Component::get_gameObject(this);\n\tv181 = HighlightPlus.OnObjectHighlightEvent::Invoke(this.OnObjectHighlightStart, v419);\n\tv187 = v181 == 0;\n\tif (v187) goto L_0083;\nL_010D:\n\tUnityEngine.Component::SendMessage(this, \"HighlightStart\", 0, 1);\n\tthis.iconFXStartTime = v158;\n\tthis.targetFXStartTime = v158;\n\tthis.highlightStartTime = v158;\n\tv444 = this.fadeInDuration < 0;\n\tv445 = this.fadeInDuration == 0;\n\tv448 = this.fadeInDuration == this.fadeInDuration;\n\tv449 = ~v448;\n\tv450 = v444 == v449;\n\tv451 = ~v450;\n\tv452 = v451 | v445;\n\tif (v452) goto L_FFFFFFFF;\n\tv466 = this.fading != -1;\n\tif (v466) goto L_FFFFFFFF;\n\tv470 = v158 - this.fadeStartTime;\n\tv471 = this.fadeOutDuration - v470;\n\tv491 = v158 - v471;\n\tv473 = v491 < v158;\n\tv481 = ~v473;\n\tif (v481) goto L_FFFFFFFF;\n\tgoto L_013C;\nL_FFFFFFFF:\n\tv491 = v158;\nL_013F:\n\tthis.fading = 0;\n\tHighlightPlus.HighlightEffect::ImmediateFadeOut(this);\n\tthis.requireUpdateMaterial = 1;\n\treturn;\nL_FFFFFFFF:\n\tv502 = 0;\n\t// 366 MakeStruct v215 @ AGG770BD1C_1_v1 (UnityEngine.Color), typeof(UnityEngine.Color), this.hitFxColor (UnityEngine.Color), this.hitFxColor.g (System.Single), this.hitFxColor.b (System.Single), this.hitFxColor.a (System.Single)\n\tHighlightPlus.HighlightEffect::HitFX(this, v215, this.hitFxFadeOutDuration, this.hitFxInitialIntensity);\n\treturn;\nL_0022:\n\tv53 = this.highlighted == state;\nL_FFFFFFFF:\n\t;\n\tif (v53) goto L_0038;\nL_0083:\n\treturn;\nL_006A:\n\tv115.lastHighlighted = this;\nL_FFFFFFFF:\n\t;\n\tgoto L_0040;\nL_00E5:\n\tthis.fading = -1;\n\treturn;\nL_00E3:\n\tthis.fadeStartTime = v441;\nL_FFFFFFFF:\n\tv502 = 1;\n\tgoto L_014F;\nL_013C:\n\tthis.fadeStartTime = v491;\nL_014F:\n\tthis.fading = v502;\n\tthis.highlighted = 1;\n\tthis.requireUpdateMaterial = 1;\n\tv127 = this.hitFXTriggerMode != 0xA;\n\tif (v127) goto L_0083;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetHighlighted(bool state)
		{
			//IL_0043: Expected O, but got I4
			//IL_03fe: Expected O, but got I4
			if (highlighted != state && OnObjectHighlightStateChange != null)
			{
				GameObject obj = base.gameObject;
				object obj2 = OnObjectHighlightStateChange(obj, state);
				if (obj2 == null)
				{
					return;
				}
			}
			if (state)
			{
				lastHighlighted = this;
			}
			FadingState fadingState;
			float num;
			float num2;
			FadingState fadingState2;
			if (Application.isPlaying)
			{
				float num3;
				float unscaledTime;
				if (useUnscaledTime)
				{
					unscaledTime = Time.unscaledTime;
					fadingState = fading;
					bool flag = fading == FadingState.NoFading;
					bool flag2 = !flag;
					num = unscaledTime;
					if (flag2)
					{
						goto IL_01a9;
					}
					num2 = unscaledTime;
					num3 = unscaledTime;
					fadingState2 = fading;
				}
				else
				{
					unscaledTime = Time.time;
					fadingState = fading;
					bool flag3 = fading == FadingState.NoFading;
					num = unscaledTime;
					num2 = unscaledTime;
					num3 = unscaledTime;
					fadingState2 = fading;
					if (!flag3)
					{
						goto IL_01a9;
					}
				}
				fadeStartTime = num2;
				bool flag4 = !state;
				num = num2;
				unscaledTime = num3;
				fadingState = fadingState2;
				if (!flag4)
				{
					goto IL_021d;
				}
				goto IL_024c;
			}
			_highlighted = state;
			return;
			IL_021d:
			bool flag5 = !ignore;
			num2 = num;
			fadingState2 = fadingState;
			if (!flag5)
			{
				goto IL_024c;
			}
			if (fadingState == FadingState.NoFading && highlighted)
			{
				return;
			}
			if (OnObjectHighlightStart != null)
			{
				GameObject obj3 = base.gameObject;
				object obj4 = OnObjectHighlightStart(obj3);
				if (obj4 == null)
				{
					return;
				}
			}
			SendMessage("HighlightStart", null, SendMessageOptions.DontRequireReceiver);
			iconFXStartTime = num;
			targetFXStartTime = num;
			highlightStartTime = num;
			bool flag6 = fadeInDuration < 0f;
			bool flag7 = fadeInDuration == 0f;
			bool flag8 = fadeInDuration == fadeInDuration;
			bool flag9 = !flag8;
			bool flag10 = flag6 == flag9;
			bool flag11 = !flag10;
			FadingState fadingState3;
			if (!(flag11 || flag7))
			{
				if (fading == FadingState.FadingOut)
				{
					float num4 = num - fadeStartTime;
					float num5 = fadeOutDuration - num4;
					float num6 = num - num5;
					if (!(num6 < num))
					{
						num6 = num;
					}
					fadeStartTime = num6;
				}
				fadingState3 = FadingState.FadingIn;
			}
			else
			{
				fadingState3 = default(FadingState);
			}
			fading = fadingState3;
			_highlighted = true;
			requireUpdateMaterial = true;
			if (hitFXTriggerMode == HitFXTriggerMode.WhenHighlighted)
			{
				Color color = default(Color);
				color.r = hitFxColor.r;
				color.g = hitFxColor.g;
				color.b = hitFxColor.b;
				color.a = hitFxColor.a;
				HitFX(color, hitFxFadeOutDuration, hitFxInitialIntensity);
			}
			return;
			IL_01a9:
			if (state)
			{
				goto IL_021d;
			}
			num2 = num;
			fadingState2 = fadingState;
			goto IL_024c;
			IL_024c:
			if (!highlighted)
			{
				return;
			}
			bool flag12 = fadeOutDuration < 0f;
			bool flag13 = fadeOutDuration == 0f;
			bool flag14 = fadeOutDuration == fadeOutDuration;
			bool flag15 = !flag14;
			bool flag16 = flag12 == flag15;
			bool flag17 = !flag16;
			if (!(flag17 || flag13))
			{
				if (fadingState2 == FadingState.FadingIn)
				{
					float num7 = num2 - fadeStartTime;
					float num8 = num2 + num7;
					float num9 = num8 - fadeInDuration;
					if (!(num9 < num2))
					{
						num9 = num2;
					}
					fadeStartTime = num9;
				}
				fading = FadingState.FadingOut;
			}
			else
			{
				fading = default(FadingState);
				ImmediateFadeOut();
				requireUpdateMaterial = true;
			}
		}

		[Token(Token = "0x6000060")]
		[Address(RVA = "0x771EDD8", Offset = "0x771EDD8", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0021:\n\tgoto L_0025;\nL_0025:\n\tv66 = UnityEngine.Object::op_Inequality(this.instantiatedIconPrefab, 0);\n\tv74 = ~v66;\n\tv75 = ~v74;\n\tif (v75) goto L_005B;\n\tv109 = 0xB2F4000 + 0x7C0;\n\tv99 = this.OnObjectHighlightEnd;\n\tv90 = this.OnObjectHighlightEnd == 0;\n\tv124 = v109;\n\tif (v90) goto L_0042;\nL_0030:\n\tv113 = UnityEngine.Component::get_gameObject(this);\n\tv120 = HighlightPlus.OnObjectHighlightEvent::Invoke(v99, v113);\n\tv124 = v109;\nL_005B:\n\tUnityEngine.GameObject::SetActive(this.instantiatedIconPrefab, 0);\n\tv109 = 0xB2F4000 + 0x7C0;\n\tv99 = this.OnObjectHighlightEnd;\n\tv139 = this.OnObjectHighlightEnd == 0;\n\tv107 = ~v139;\n\tif (v107) goto L_0030;\n\tv124 = v109;\n\tgoto L_0042;\nL_0014:\n\tthis.fading = 0;\n\tthis.highlighted = 0;\n\tgoto L_0021;\nL_0042:\n\tUnityEngine.Component::SendMessage(this, *([v124 @ X20_v3 (System.Int32)]), 0, 1);\n\treturn;\n")]
		private void ImmediateFadeOut()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::ImmediateFadeOut");
		}

		[Token(Token = "0x6000061")]
		[Address(RVA = "0x770E67C", Offset = "0x770E67C", Length = "0x3C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tgoto L_001B;\nL_001B:\n\tv64 = UnityEngine.Object::op_Equality(this.target, 0);\n\tv77 = v64 == 0;\n\tif (v77) goto L_004E;\n\tgoto L_0063;\nL_004E:\n\tgoto L_0054;\nL_0054:\n\tgoto L_0058;\nL_0058:\n\tv112 = UnityEngine.Object::op_Equality(v132.fxMatMask, 0);\n\tv118 = v112 == 0;\nL_FFFFFFFF:\n\t;\n\tif (v118) goto L_0083;\nL_0063:\n\treturn;\nL_0083:\n\tv274 = this.effectGroup > 2;\n\tif (v274) goto L_00BB;\n\tv279 = this.effectGroup == 0;\n\tif (v279) goto L_00E1;\n\tv293 = this.effectGroup == 1;\n\tif (v293) goto L_010E;\n\tv321 = this.effectGroup != 2;\nL_FFFFFFFF:\n\tv202 = 0;\n\tif (v321) goto L_0156;\n\tv454 = UnityEngine.Component::GetComponentInParent(this.target, 1);\n\tgoto L_00AE;\nL_00AE:\n\tv414 = UnityEngine.Object::op_Equality(v454, 0);\n\tv483 = ~v414;\n\tif (v483) goto L_0150;\n\tv338 = UnityEngine.Transform::get_root(this.target);\n\tgoto L_FFFFFFFF;\nL_00BB:\n\tv284 = this.effectGroup == 3;\n\tif (v284) goto L_00E6;\n\tv303 = this.effectGroup == 4;\n\tif (v303) goto L_0129;\n\tv146 = this.effectGroup != 5;\nL_FFFFFFFF:\n\tv202 = 0;\n\tif (v146) goto L_0156;\n\tHighlightPlus.HighlightEffect::UpdateMaterialProperties(this, 0);\n\treturn;\nL_00E1:\n\tv335 = this.target;\n\tgoto L_0153;\nL_00E6:\n\tv311 = UnityEngine.Component::get_transform(this);\n\tgoto L_00F1;\nL_00F1:\n\tv449 = UnityEngine.Object::op_Inequality(this.target, v311);\n\tv460 = ~v449;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv440 = this;\n\tif (v460) goto L_0105;\n\tv409 = UnityEngine.Component::TryGetComponent(this.target, &v416 @ stack_-40_v7 (HighlightPlus.HighlightEffect));\n\tv470 = ~v409;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv440 = this;\n\tif (v470) goto L_0105;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv440 = v416;\nL_0105:\n\tv377 = HighlightPlus.HighlightEffect::FindRenderersWithLayerInScene(this, v440.effectGroupLayer);\n\tgoto L_FFFFFFFF;\nL_010E:\n\tv393 = UnityEngine.Component::TryGetComponent(this.target, &v381 @ stack_-38_v5 (UnityEngine.Renderer));\n\tv455 = ~v393;\n\tif (v455) goto L_FFFFFFFF;\n\tv464 = HighlightPlus.HighlightEffect::ValidRenderer(v393, v381);\n\tv466 = ~v464;\n\tif (v466) goto L_FFFFFFFF;\n\tv487 = System.Collections.Generic.List`1<UnityEngine.Renderer>::Clear(this.tempRR);\n\tv378 = System.Collections.Generic.List`1<UnityEngine.Renderer>::Add(this.tempRR, v381);\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv202 = this.tempRR;\n\tgoto L_0156;\nL_0129:\n\tv351 = UnityEngine.Component::get_transform(this);\n\tgoto L_0134;\nL_0134:\n\tv459 = UnityEngine.Object::op_Inequality(this.target, v351);\n\tv467 = ~v459;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv441 = this;\n\tif (v467) goto L_0148;\n\tv413 = UnityEngine.Component::TryGetComponent(this.target, &v415 @ stack_-48_v7 (HighlightPlus.HighlightEffect));\n\tv478 = ~v413;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv441 = this;\n\tif (v478) goto L_0148;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv441 = v415;\nL_0148:\n\tv377 = HighlightPlus.HighlightEffect::FindRenderersWithLayerInChildren(this, v441.effectGroupLayer);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv202 = 0;\n\tgoto L_0156;\nL_0150:\n\tv338 = UnityEngine.Component::get_transform(v454);\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv335 = v338;\nL_FFFFFFFF:\n\tv202 = v377;\nL_0156:\n\tHighlightPlus.HighlightEffect::SetupMaterial(this, v202);\n\treturn;\nL_0153:\n\tv377 = HighlightPlus.HighlightEffect::FindRenderersInChildren(this, v335);\n")]
		private void SetupMaterial()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::SetupMaterial");
		}

		[Token(Token = "0x6000062")]
		[Address(RVA = "0x771EFF8", Offset = "0x771EFF8", Length = "0x1274")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv30 = 0xB795000;\n\tv32 = *([B795190]) & 1;\n\tv33 = v32 == 0;\n\tif (v33) goto L_005C;\n\tv37 = v172 == 0;\n\tif (v37) goto L_0068;\nL_001B:\n\tv1364 = 0xB284000 + 0xAB8;\n\tv1942 = this + 0x468;\n\tv89 = this.rms;\n\tv71 = this.rms == 0;\n\tv72 = ~v71;\nL_FFFFFFFF:\n\tv1612 = v172;\n\tif (v72) goto L_009E;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv179 = v1364;\nL_FFFFFFFF:\n\tv188 = v1942;\nL_FFFFFFFF:\n\tv189 = v172;\n\tgoto L_00E9;\nL_005C:\n\t*([v30 @ X21_v1+190]) = 1;\n\tv2193 = v172 == 0;\n\tv64 = ~v2193;\n\tif (v64) goto L_001B;\nL_0068:\n\tgoto L_0069;\nL_0069:\n\tv105 = Il2CppClass<System.EmptyArray`1<UnityEngine.Renderer>>;\n\tv108 = *([v105 @ X0_v296 (Il2CppClass<System.EmptyArray`1<UnityEngine.Renderer>>)+135]) & 1;\n\tv109 = v108 == 0;\n\tv110 = ~v109;\nL_FFFFFFFF:\n\tv821 = Il2CppClass<System.EmptyArray`1<UnityEngine.Renderer>>;\n\tif (v110) goto L_0089;\nL_0070:\n\tv827 = 0x220C238(v821, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv910 = *([v827 @ X0_v295+E4]) == 0;\n\tv911 = ~v910;\n\tif (v911) goto L_0091;\n\tgoto L_007D;\nL_007D:\n\tgoto L_0096;\n\tv112 = System.Array::Empty();\n\tv822 = Il2CppClass<System.EmptyArray`1<UnityEngine.Renderer>>;\n\tv835 = *([v822 @ X0_v290 (Il2CppClass<System.EmptyArray`1<UnityEngine.Renderer>>)+135]) & 1;\n\tv824 = v835 == 0;\nL_FFFFFFFF:\n\tv821 = Il2CppClass<System.EmptyArray`1<UnityEngine.Renderer>>;\n\tif (v824) goto L_0070;\nL_0089:\n\tgoto L_0091;\nL_0091:\n\tgoto L_0096;\nL_0096:\n\tv1364 = 0xB284000 + 0xAB8;\n\tv1942 = this + 0x468;\n\tv89 = this.rms;\n\tv97 = this.rms == 0;\nL_FFFFFFFF:\n\tv1612 = v99.Value;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv179 = v1364;\nL_FFFFFFFF:\n\tv188 = v1942;\nL_FFFFFFFF:\n\tv189 = v99.Value;\n\tif (v97) goto L_00E9;\nL_009E:\n\tv192 = *([v1612 @ X20_v7 (System.Collections.Generic.IList`1<UnityEngine.Renderer>)]);\n\tv945 = *([v192 @ X8_v223 (Il2CppClass<System.Collections.Generic.IList`1<UnityEngine.Renderer>>)+12E]);\n\tv184 = *([v192 @ X8_v223 (Il2CppClass<System.Collections.Generic.IList`1<UnityEngine.Renderer>>)+12E]) == 0;\n\tif (v184) goto L_00BE;\n\tv165 = *([v192 @ X8_v223 (Il2CppClass<System.Collections.Generic.IList`1<UnityEngine.Renderer>>)+B0]) + 8;\n\tv165 = v165 + 0x10;\n\tv860 = v945 - 1;\n\tv842 = v945 != 1;\nL_FFFFFFFF:\n\tv945 = v860;\n\tif (v842) goto L_00A9;\nL_00BE:\n\tv862 = 0x220C5E0(v1612, v1364.m_value, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv172 = *([v862 @ X0_v275+8]);\n\t*([v862 @ X0_v275])(v177, v1612, *([v862 @ X0_v275+8]), 0, v247, v43, v44, v45, v46, v47, v1338, v49, v50, v51, v52, v53, v54);\n\tv131 = v177 > v89.Length;\nL_FFFFFFFF:\n\tv179 = v1364;\nL_FFFFFFFF:\n\tv188 = v1942;\nL_FFFFFFFF:\n\tv189 = v1612;\n\tif (v131) goto L_00E9;\nL_FFFFFFFF:\n\tv327 = 0;\nL_FFFFFFFF:\n\t;\n\tgoto L_0121;\nL_00D3:\n\tv121 = *([v165 @ X10_v78]) << 4;\n\tv1010 = v192 + v121;\n\tv1011 = v1010 + 0x138;\n\tv172 = *([v1011 @ X0_v278+8]);\n\t*([v1011 @ X0_v278])(v176, v1612, *([v1011 @ X0_v278+8]), v126, v247, v43, v44, v45, v46, v47, v1338, v49, v50, v51, v52, v53, v54);\n\tv129 = v176 <= v89.Length;\nL_FFFFFFFF:\n\tv179 = v1364;\nL_FFFFFFFF:\n\tv188 = v1942;\nL_FFFFFFFF:\n\tv189 = v1612;\nL_FFFFFFFF:\n\tv327 = v126;\nL_FFFFFFFF:\n\t;\n\tif (v129) goto L_0121;\nL_00E9:\n\tHighlightPlus.HighlightEffect::DisposeModelMaterials(this);\n\tv932 = *([v189 @ X20_v21 (System.Collections.Generic.IList`1<UnityEngine.Renderer>)]);\n\tv1033 = *([v932 @ X8_v218 (Il2CppClass<System.Collections.Generic.IList`1<UnityEngine.Renderer>>)+12E]);\n\tv934 = *([v932 @ X8_v218 (Il2CppClass<System.Collections.Generic.IList`1<UnityEngine.Renderer>>)+12E]) == 0;\n\tif (v934) goto L_010F;\n\tv1032 = *([v932 @ X8_v218 (Il2CppClass<System.Collections.Generic.IList`1<UnityEngine.Renderer>>)+B0]) + 8;\n\tv1032 = v1032 + 0x10;\n\tv1005 = v1033 - 1;\n\tv985 = v1033 != 1;\nL_FFFFFFFF:\n\tv1033 = v1005;\n\tif (v985) goto L_00FA;\nL_010F:\n\tv1132 = 0x220C5E0(v189, v179.m_value, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv327 = 0;\n\tgoto L_0118;\nL_0112:\n\tv1129 = *([v1032 @ X10_v73]) << 4;\n\tv1130 = v932 + v1129;\n\tv1132 = v1130 + 0x138;\nL_FFFFFFFF:\n\tv327 = 0;\nL_0121:\n\tv1749 = 0xB292000 + 0x5A0;\n\tv1747 = 0xB28F000 + 0x80;\n\tHighlightPlus.HighlightEffect::InitCommandBuffer(this);\n\tthis.spriteMode = 0;\n\tthis.includedObjectsCount = 0;\n\tv499 = this.glow < 0;\n\tv473 = this.glow == 0;\n\tv525 = this.glow == this.glow;\n\tv369 = ~v525;\n\tv1142 = v499 == v369;\n\tv1143 = ~v1142;\n\tv352 = v1143 | v473;\n\tif (v352) goto L_0187;\n\tgoto L_013D;\nL_013D:\n\tgoto L_0140;\nL_0140:\n\tv1163 = UnityEngine.Object::op_Inequality(v1186.fxMatGlowTemplate, 0);\n\tv1168 = ~v1163;\nL_FFFFFFFF:\n\tv327 = 0;\n\tif (v1168) goto L_0187;\n\tgoto L_014C;\nL_014C:\n\tgoto L_0150;\nL_0150:\n\tv1540 = UnityEngine.Object::op_Equality(v1470.cachedNoiseTex, 0);\n\tv1630 = ~v1540;\n\tif (v1630) goto L_01CF;\n\tv1683 = UnityEngine.Resources::Load(\"HighlightPlus/blueNoiseVL\");\n\tgoto L_0163;\nL_0187:\n\tv1177 = this.effectGroup == 1;\nL_FFFFFFFF:\n\tv284 = v1612;\nL_FFFFFFFF:\n\tv2361 = v247;\nL_FFFFFFFF:\n\tv282 = v1612;\nL_FFFFFFFF:\n\tv1266 = v327;\n\tif (v1177) goto L_FFFFFFFF;\nL_0190:\n\tv1225 = System.String::IsNullOrEmpty(this.effectNameFilter);\n\tv1332 = v1225 == 0;\n\tv1228 = ~v1332;\nL_FFFFFFFF:\n\tv2361 = 0;\nL_FFFFFFFF:\n\tv282 = v284;\nL_FFFFFFFF:\n\tv1266 = v327;\n\tif (v1228) goto L_FFFFFFFF;\n\tv351 = this.effectNameUseRegEx != 1;\n\tif (v351) goto L_FFFFFFFF;\n\tv1429 = new System.Text.RegularExpressions.Regex();\n\tSystem.Text.RegularExpressions.Regex::.ctor(v1429, this.effectNameFilter);\n\tthis.lastRegExError = \"\";\nL_FFFFFFFF:\n\tv327 = 0;\nL_FFFFFFFF:\n\tv1920 = v1429;\n\tgoto L_01B7;\nL_FFFFFFFF:\n\tv1920 = 0;\n\tgoto L_0843;\nL_01CF:\n\tgoto L_01D8;\nL_01D8:\n\tgoto L_01E4;\nL_01E4:\n\tUnityEngine.Material::SetTexture(v1968.fxMatGlowTemplate, v2198.NoiseTex, v2196.cachedNoiseTex);\n\tv1198 = this.effectGroup != 1;\nL_FFFFFFFF:\n\tv284 = v1612;\nL_FFFFFFFF:\n\tv327 = v2196.cachedNoiseTex;\nL_FFFFFFFF:\n\tv2361 = 0;\nL_FFFFFFFF:\n\tv282 = v1612;\nL_FFFFFFFF:\n\tv1266 = v2196.cachedNoiseTex;\n\tif (v1198) goto L_0190;\nL_FFFFFFFF:\n\tv244 = 0;\nL_FFFFFFFF:\n\tv1344 = this.glow;\nL_FFFFFFFF:\n\tv1920 = 0;\nL_01F7:\n\tv1373 = *([v1612 @ X20_v7 (System.Collections.Generic.IList`1<UnityEngine.Renderer>)]);\n\tv1442 = *([v1373 @ X8_v9 (Il2CppClass<System.Collections.Generic.IList`1<UnityEngine.Renderer>>)+12E]);\n\tv1375 = *([v1373 @ X8_v9 (Il2CppClass<System.Collections.Generic.IList`1<UnityEngine.Renderer>>)+12E]) == 0;\n\tif (v1375) goto L_0217;\n\tv1441 = *([v1373 @ X8_v9 (Il2CppClass<System.Collections.Generic.IList`1<UnityEngine.Renderer>>)+B0]) + 8;\n\tv1441 = v1441 + 0x10;\n\tv1407 = v1442 - 1;\n\tv1387 = v1442 != 1;\nL_FFFFFFFF:\n\tv1442 = v1407;\n\tif (v1387) goto L_01FD;\nL_0217:\n\tv1410 = UnityEngine.Component::TryGetComponent(v1612, v1364.m_value);\n\tv1410.m_value(v1455, v1612, *([v1410 @ X0_v200 (System.Boolean)+8]), 0, v2361, v43, v44, v45, v46, v1344, v1338, v49, v50, v51, v52, v53, v54);\n\tv1466 = v1455 >= 1;\nL_FFFFFFFF:\n\tv237 = v1455;\n\tif (v1466) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv1266 = 0;\n\tgoto L_072B;\nL_0229:\n\t;\n\tv1488 = *([v1441 @ X10_v66]) << 4;\n\tv1489 = v1373 + v1488;\n\tv1490 = v1489 + 0x138;\n\t*([v1490 @ X0_v203])(v1494, v1612, *([v1490 @ X0_v203+8]), v1266, v2361, v43, v44, v45, v46, v1344, v1338, v49, v50, v51, v52, v53, v54);\n\tv1506 = v1494 < 1;\nL_FFFFFFFF:\n\tv237 = v1494;\n\tif (v1506) goto L_072B;\nL_FFFFFFFF:\n\tv1558 = 0xD8;\nL_FFFFFFFF:\n\tv1364 = 0;\nL_FFFFFFFF:\n\tv2426 = v1612;\n\tgoto L_0251;\nL_0241:\n\tHighlightPlus.HighlightEffect::AverageNormals(this, this.includedObjectsCount);\nL_FFFFFFFF:\n\tv2359 = 0xD8;\nL_FFFFFFFF:\n\t;\nL_0243:\n\tv2421 = this.includedObjectsCount + 1;\n\tthis.includedObjectsCount = v2421;\nL_FFFFFFFF:\n\tv1558 = v2359;\nL_FFFFFFFF:\n\tv1266 = v2369;\nL_0251:\n\t;\n\tv1727 = this.includedObjectsCount * v1558;\n\tv1728 = *([v1942 @ X21_v16 (System.Text.RegularExpressions.Regex)]) + v1727;\n\tv1729 = v1728 + 0x20;\n\tHighlightPlus.HighlightEffect+ModelMaterials::Init(v1729);\n\tgoto L_0292;\nL_029B:\n\tv2345 = UnityEngine.Object::op_Equali\n// ... truncated")]
		private unsafe void SetupMaterial(IList<Renderer> rr)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::SetupMaterial");
		}

		[Token(Token = "0x6000063")]
		[Address(RVA = "0x7720288", Offset = "0x7720288", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv45 = UnityEngine.MeshRenderer;\n\tv46 = r->klass;\n\tv49 = *([v46 @ X8_v5 (Il2CppClass<UnityEngine.Renderer>)+130]) < *([v45 @ X10_v1 (Il2CppClass<UnityEngine.MeshRenderer>)+130]);\n\tv50 = ~v49;\n\tif (v50) goto L_0044;\n\tv78 = v46 != UnityEngine.SpriteRenderer;\n\tif (v78) goto L_0074;\n\tgoto L_009C;\nL_0042:\n\treturn 0;\nL_0044:\n\tv80 = *([v45 @ X10_v1 (Il2CppClass<UnityEngine.MeshRenderer>)+130]) << 3;\n\tv81 = *([v46 @ X8_v5 (Il2CppClass<UnityEngine.Renderer>)+C8]) + v80;\n\tv88 = *([v81 @ X11_v5-8]) - UnityEngine.MeshRenderer;\n\tv90 = v88 == 0;\n\tv95 = ~v90;\n\tv96 = ~v95;\n\tif (v96) goto L_FFFFFFFF;\n\tv208 = v46 - UnityEngine.SpriteRenderer;\n\tv186 = v208 == 0;\n\tgoto L_0065;\nL_FFFFFFFF:\n\tv186 = 1;\nL_0074:\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 IsInst v224_asT @ Z_v7 (UnityEngine.SkinnedMeshRenderer), typeof(UnityEngine.SkinnedMeshRenderer), r @ X1 (UnityEngine.Renderer)\n\tv224 = v224_asT != 0;\n\tif (v224) goto L_009C;\n\tv142 = v46 - UnityEngine.ParticleSystemRenderer;\n\tv134 = v142 == 0;\n\treturn v134;\nL_009C:\n\treturn 1;\nL_001B:\n\tv39 = r == 0;\n\tif (v39) goto L_0042;\nL_0065:\n\tif (v186) goto L_009C;\n")]
		private bool ValidRenderer(Renderer r)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::ValidRenderer");
			return default;
		}

		[Token(Token = "0x6000064")]
		[Address(RVA = "0x772055C", Offset = "0x772055C", Length = "0x1FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tv64 = 0xB2CF000 + 0xF50;\n\tgoto L_001F;\nL_001F:\n\tv87 = HighlightPlus.Misc::FindObjectsOfType /* +1 sharing this address */(0, *([v64 @ X22_v12 (System.Int32)]));\n\tv90 = this.tempRR;\n\tv78 = this.tempRR == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_0042;\n\tgoto L_00CB;\nL_0042:\n\t;\n\tSystem.Collections.Generic.List`1<UnityEngine.Renderer>::Clear(v90);\n\tv107 = v90.Count < 1;\n\tif (v107) goto L_0064;\nL_0064:\n\tv135 = *([v87 @ X0_v5+18]) < 1;\n\tif (v135) goto L_00CA;\n\tv124 = v87 + 0x20;\n\tv128 = 0;\n\tgoto L_008C;\nL_0070:\n\tSystem.Collections.Generic.List`1<UnityEngine.Renderer>::Add(v175, *([v124 @ X27_v5+v128 @ X25_v6 (System.Int32)*8]));\nL_0071:\n\tv128 = v128 + 1;\n\tv260 = *([v87 @ X0_v5+18]) == v128;\n\tif (v260) goto L_00CA;\nL_008C:\n\tv174 = UnityEngine.Component::get_gameObject(*([v124 @ X27_v5+v128 @ X25_v6 (System.Int32)*8]));\n\tv337 = UnityEngine.GameObject::get_layer(v174);\n\tv340 = UnityEngine.LayerMask::op_Implicit(layer);\n\tv185 = v340 >> v337;\n\tv341 = v185 & 1;\n\tv342 = v341 == 0;\n\tif (v342) goto L_0071;\n\tv343 = HighlightPlus.HighlightEffect::ValidRenderer(v340, *([v124 @ X27_v5+v128 @ X25_v6 (System.Int32)*8]));\n\tv367 = ~v343;\n\tif (v367) goto L_0071;\n\tv175 = this.tempRR;\n\tgoto L_0070;\nL_00CA:\n\treturn this.tempRR;\nL_00CB:\n\tv191 = new System.NullReferenceException();\n\treturnVal1 = new System.IndexOutOfRangeException();\n\treturn returnVal1;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IList<Renderer> FindRenderersWithLayerInScene(LayerMask layer)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::FindRenderersWithLayerInScene");
			return default;
		}

		[Token(Token = "0x6000065")]
		[Address(RVA = "0x7720758", Offset = "0x7720758", Length = "0x1D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tSystem.Collections.Generic.List`1<UnityEngine.Renderer>::Clear(v56);\n\tv74 = v56.Count < 1;\n\tif (v74) goto L_004A;\nL_004A:\n\tUnityEngine.Component::GetComponentsInChildren(this.target, 1, this.tempRR);\n\tv162 = this.tempRR;\n\tv112 = v162.Count < 1;\n\tif (v112) goto L_00B1;\n\tv93 = 0;\n\tv176 = 0;\n\tgoto L_0079;\nL_0063:\n\tv335 = v176 + 1;\n\tSystem.Collections.Generic.List`1<UnityEngine.Renderer>::set_Item(this.tempRR, v176, v160);\n\tv176 = v335;\nL_0079:\n\tv160 = System.Collections.Generic.List`1<UnityEngine.Renderer>::get_Item(this.tempRR, v93);\n\tv161 = UnityEngine.Component::get_gameObject(v160);\n\tv328 = UnityEngine.GameObject::get_layer(v161);\n\tv331 = UnityEngine.LayerMask::op_Implicit(layer);\n\tv172 = v331 >> v328;\n\tv332 = v172 & 1;\n\tv333 = v332 == 0;\n\tif (v333) goto L_0069;\n\tv334 = HighlightPlus.HighlightEffect::ValidRenderer(v331, v160);\n\tv339 = ~v334;\n\tif (v339) goto L_0069;\n\tv342 = this.tempRR == 0;\n\tv164 = ~v342;\n\tif (v164) goto L_0063;\n\tthrow System.NullReferenceException;\nL_0094:\n\tv162 = this.tempRR;\n\tv154 = v162.Count - v176;\n\tv244 = v162.Count > v176;\n\tif (v244) goto L_00B9;\n\treturnVal1 = v162;\n\tgoto L_00C8;\nL_00B1:\n\tv249 = v162.Count <= 0;\n\tv154 = v162.Count;\n\tv178 = 0;\n\treturnVal1 = v162;\n\tif (v249) goto L_00C8;\nL_00B9:\n\tSystem.Collections.Generic.List`1<UnityEngine.Renderer>::RemoveRange(v162, v178, v154);\n\treturnVal1 = this.tempRR;\nL_002A:\n\tv56 = this.tempRR;\nL_0069:\n\tv93 = v93 + 1;\n\tv213 = v162.Count == v93;\n\tv178 = v176;\n\tif (v213) goto L_0094;\nL_00C8:\n\treturn returnVal1;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IList<Renderer> FindRenderersWithLayerInChildren(LayerMask layer)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::FindRenderersWithLayerInChildren");
			return default;
		}

		[Token(Token = "0x6000066")]
		[Address(RVA = "0x77203A8", Offset = "0x77203A8", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tSystem.Collections.Generic.List`1<UnityEngine.Renderer>::Clear(v52);\n\tv70 = v52.Count < 1;\n\tif (v70) goto L_0048;\nL_0048:\n\tUnityEngine.Component::GetComponentsInChildren(parent, 1, this.tempRR);\n\tv148 = this.tempRR;\n\tv101 = v148.Count < 1;\n\tif (v101) goto L_00A8;\n\tv158 = 0;\n\tv162 = 0;\n\tgoto L_0070;\nL_0060:\n\tv158 = v158 + 1;\n\tv281 = v148.Count == v158;\n\tif (v281) goto L_0080;\nL_0070:\n\tv312 = System.Collections.Generic.List`1<UnityEngine.Renderer>::get_Item(this.tempRR, v158);\n\tv314 = HighlightPlus.HighlightEffect::ValidRenderer(v312, v312);\n\tv315 = ~v314;\n\tif (v315) goto L_0060;\n\tv316 = v162 + 1;\n\tSystem.Collections.Generic.List`1<UnityEngine.Renderer>::set_Item(this.tempRR, v162, v312);\n\tv162 = v316;\n\tgoto L_0060;\nL_0080:\n\tv148 = this.tempRR;\n\tv142 = v148.Count - v162;\n\tv293 = v148.Count > v162;\n\treturnVal2 = v148;\n\tif (v293) goto L_00B0;\nL_009A:\n\treturn returnVal2;\nL_00A8:\n\tv273 = v148.Count <= 0;\n\treturnVal2 = v148;\n\tv142 = v148.Count;\n\tv162 = 0;\n\tif (v273) goto L_009A;\nL_00B0:\n\tSystem.Collections.Generic.List`1<UnityEngine.Renderer>::RemoveRange(v148, v162, v142);\n\treturn this.tempRR;\nL_0028:\n\tv52 = this.tempRR;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private IList<Renderer> FindRenderersInChildren(Transform parent)
		{
			List<Renderer> list = tempRR;
			list.Clear();
			if (list.Count >= 1)
			{
			}
			parent.GetComponentsInChildren(includeInactive: true, tempRR);
			List<Renderer> list2 = tempRR;
			int num2;
			int count;
			IList<Renderer> result;
			if (list2.Count >= 1)
			{
				int num = 0;
				num2 = 0;
				do
				{
					HighlightEffect highlightEffect = (HighlightEffect)(object)tempRR[num];
					if (highlightEffect.ValidRenderer((Renderer)(object)highlightEffect))
					{
						int num3 = num2 + 1;
						tempRR[num2] = (Renderer)(object)highlightEffect;
						num2 = num3;
					}
					num++;
				}
				while (list2.Count != num);
				list2 = tempRR;
				count = list2.Count - num2;
				bool flag = list2.Count > num2;
				result = list2;
				if (!flag)
				{
					goto IL_0178;
				}
			}
			else
			{
				bool flag2 = list2.Count <= 0;
				result = list2;
				count = list2.Count;
				num2 = 0;
				if (flag2)
				{
					goto IL_0178;
				}
			}
			list2.RemoveRange(num2, count);
			return tempRR;
			IL_0178:
			return result;
		}

		[Token(Token = "0x6000067")]
		[Address(RVA = "0x770E008", Offset = "0x770E008", Length = "0x670")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0055;\n\tthis.sharedTemplateMaterialsAcquired = 1;\nL_FFFFFFFF:\n\tv72 = HighlightPlus.HighlightEffect;\n\tgoto L_0062;\n\tHighlightPlus.HighlightEffect::InitMaterial(v72, &v128.fxMatSeeThroughBorder (UnityEngine.Material), &v128.shaderSeeThroughBorder (UnityEngine.Shader), \"HighlightPlus/Geometry/SeeThroughBorder\");\n\tHighlightPlus.HighlightEffect::InitMaterial(v72, &v136.fxMatSeeThroughMask (UnityEngine.Material), &v136.shaderSeeThroughMask (UnityEngine.Shader), \"HighlightPlus/Geometry/SeeThroughMask\");\n\tHighlightPlus.HighlightEffect::InitMaterial(v72, &v144.fxMatSolidColor (UnityEngine.Material), &v144.shaderSolidColor (UnityEngine.Shader), \"HighlightPlus/Geometry/SolidColor\");\n\tHighlightPlus.HighlightEffect::InitMaterial(v72, &v152.fxMatClearStencil (UnityEngine.Material), &v152.shaderClearStencil (UnityEngine.Shader), \"HighlightPlus/ClearStencil\");\n\tv161 = this.focus < 0;\n\tv162 = this.focus == 0;\n\tv165 = this.focus == this.focus;\n\tv166 = ~v165;\n\tv167 = v161 == v166;\n\tv168 = ~v167;\n\tv169 = v168 | v162;\n\tif (v169) goto L_00D3;\nL_FFFFFFFF:\n\tv209 = HighlightPlus.HighlightEffect;\n\tgoto L_00B9;\nL_00CE:\n\tv190 = UnityEngine.Object::op_Inequality(v267.fxMatFocusBlur, 0);\n\tv289 = ~v190;\n\tv193 = ~v289;\n\tif (v193) goto L_0213;\nL_00D3:\n\tv244 = 0xB2F4000 + 0x7F8;\nL_FFFFFFFF:\n\tv240 = HighlightPlus.HighlightEffect;\n\tgoto L_00DD;\nL_00EA:\n\tv273 = UnityEngine.Object::op_Inequality(v258.fxMatGlowTemplate, 0);\n\tv280 = ~v273;\n\tv281 = ~v280;\n\tif (v281) goto L_0100;\n\tgoto L_FFFFFFFF;\nL_0100:\n\tv306 = this.useGPUInstancing != 1;\n\tif (v306) goto L_FFFFFFFF;\n\tgoto L_010E;\nL_010E:\n\tv337 = UnityEngine.Material::get_enableInstancing(v343.fxMatGlowTemplate);\n\tv439 = v337 == 0;\n\tv340 = ~v439;\n\tif (v340) goto L_FFFFFFFF;\n\tgoto L_0120;\nL_0120:\n\tUnityEngine.Material::set_enableInstancing(v342.fxMatGlowTemplate, 1);\nL_FFFFFFFF:\n\tv370 = HighlightPlus.HighlightEffect;\n\tgoto L_012E;\nL_0141:\n\tv445 = UnityEngine.Object::op_Inequality(v434.fxMatOutlineTemplate, 0);\n\tv537 = ~v445;\n\tv538 = ~v537;\n\tif (v538) goto L_0157;\n\tgoto L_0182;\nL_0157:\n\tv400 = this.useGPUInstancing != 1;\n\tif (v400) goto L_0182;\n\tgoto L_0165;\nL_0165:\n\tv565 = UnityEngine.Material::get_enableInstancing(v425.fxMatOutlineTemplate);\n\tv660 = v565 == 0;\n\tv567 = ~v660;\n\tif (v567) goto L_0182;\n\tgoto L_0177;\nL_0177:\n\tUnityEngine.Material::set_enableInstancing(v426.fxMatOutlineTemplate, 1);\nL_0182:\n\tv579 = this.targetFX != 1;\n\tif (v579) goto L_0193;\nL_FFFFFFFF:\n\tv597 = HighlightPlus.HighlightEffect;\n\tgoto L_018F;\nL_0193:\n\tv602 = this.glow < 0;\n\tv603 = this.glow == 0;\n\tv606 = this.glow == this.glow;\n\tv607 = ~v606;\n\tv608 = v602 == v607;\n\tv609 = ~v608;\n\tv610 = v609 | v603;\n\tif (v610) goto L_01C0;\n\tv627 = this.glowQuality != 2;\n\tif (v627) goto L_01C0;\nL_FFFFFFFF:\n\tv641 = HighlightPlus.HighlightEffect;\n\tgoto L_01B4;\nL_01C0:\n\tv645 = this.outline < 0;\n\tv646 = this.outline == 0;\n\tv649 = this.outline == this.outline;\n\tv650 = ~v649;\n\tv651 = v645 == v650;\n\tv652 = ~v651;\n\tv653 = v652 | v646;\n\tif (v653) goto L_0207;\n\tv488 = this.outlineQuality != 2;\n\tif (v488) goto L_0207;\nL_FFFFFFFF:\n\tv517 = HighlightPlus.HighlightEffect;\n\tgoto L_01E1;\nL_0207:\n\treturn;\nL_0213:\n\tgoto L_021E;\nL_0228:\n\tUnityEngine.Material::SetFloat(v362.fxMatFocusBlur, v431.Speed, 0f);\n\tv244 = 0xB2F4000 + 0x7F8;\nL_FFFFFFFF:\n\tv240 = HighlightPlus.HighlightEffect;\n\tgoto L_00DD;\nL_0055:\n\tv60 = this.sharedTemplateMaterialsAcquired == 0;\n\tv61 = ~v60;\nL_FFFFFFFF:\n\tv72 = HighlightPlus.HighlightEffect;\n\tif (v61) goto L_0075;\nL_0062:\n\tv70 = v76.sharedTemplateMaterialsRefCount + 1;\n\tv76.sharedTemplateMaterialsRefCount = v70;\nL_00B9:\n\tv213 = v209.overlayColor + 0x48;\n\tv214 = v209.overlayColor + 0x100;\n\tHighlightPlus.HighlightEffect::InitMaterial(v209, v213, v214, \"HighlightPlus/Geometry/Focus\");\n\tHighlightPlus.HighlightEffect::InitMaterial(v209, &v252.fxMatFocusBlur (UnityEngine.Material), &v252.shaderBlurGlow (UnityEngine.Shader), \"HighlightPlus/Geometry/BlurGlow\");\n\tgoto L_00CE;\nL_00DD:\n\tv247 = v240.overlayColor + 0x58;\n\tv248 = v240.overlayColor + 0x80;\n\tHighlightPlus.HighlightEffect::InitMaterial(v240, v247, v248, *([v244 @ X20_v4 (System.Int32)]));\n\tgoto L_00EA;\nL_012E:\n\tv374 = v370.overlayColor + 0x60;\n\tv375 = v370.overlayColor + 0x88;\n\tHighlightPlus.HighlightEffect::InitMaterial(v370, v374, v375, \"HighlightPlus/Geometry/InnerGlow\");\n\tHighlightPlus.HighlightEffect::InitMaterial(v370, &v386.fxMatOutlineTemplate (UnityEngine.Material), &v386.shaderOutline (UnityEngine.Shader), \"HighlightPlus/Geometry/Outline\");\n\tgoto L_0141;\nL_018F:\n\t;\n\tv591 = v597.overlayColor + 0xB8;\n\tHighlightPlus.HighlightEffect::InitMaterial(v597, &this.fxMatTarget (UnityEngine.Material), v591, \"HighlightPlus/Geometry/Target\");\nL_01B4:\n\t;\n\tv668 = v641.overlayColor + 0xC0;\n\tHighlightPlus.HighlightEffect::InitMaterial(v641, &this.fxMatComposeGlow (UnityEngine.Material), v668, \"HighlightPlus/Geometry/ComposeGlow\");\n\tHighlightPlus.HighlightEffect::InitMaterial(v641, &this.fxMatBlurGlow (UnityEngine.Material), &v676.shaderBlurGlow (UnityEngine.Shader), \"HighlightPlus/Geometry/BlurGlow\");\nL_01E1:\n\t;\n\tv685 = v517.overlayColor + 0xC8;\n\tHighlightPlus.HighlightEffect::InitMaterial(v517, &this.fxMatComposeOutline (UnityEngine.Material), v685, \"HighlightPlus/Geometry/ComposeOutline\");\n\tHighlightPlus.HighlightEffect::InitMaterial(v517, &this.fxMatBlurOutline (UnityEngine.Material), &v689.shaderBlurOutline (UnityEngine.Shader), \"HighlightPlus/Geometry/BlurOutline\");\n\treturn;\nL_021E:\n\tgoto L_0228;\nL_0075:\n\tgoto L_007C;\nL_007C:\n\tv107 = v72.overlayColor + 0x10;\n\tv108 = v72.overlayColor + 0x78;\n\tHighlightPlus.HighlightEffect::InitMaterial(v72, v107, v108, \"HighlightPlus/Geometry/Mask\");\n\tHighlightPlus.HighlightEffect::InitMaterial(v72, &v112.fxMatOverlay (UnityEngine.Material), &v112.shaderOverlay (UnityEngine.Shader), \"HighlightPlus/Geometry/Overlay\");\n\tHighlightPlus.HighlightEffect::InitMaterial(v72, &v120.fxMatSeeThrough (UnityEngine.Material), &v120.shaderSeeThrough (UnityEngine.Shader), \"HighlightPlus/Geometry/SeeThrough\");\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void InitTemplateMaterials()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::InitTemplateMaterials");
		}

		[Token(Token = "0x6000068")]
		[Address(RVA = "0x77139A8", Offset = "0x77139A8", Length = "0x308")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tthis.sharedTemplateMaterialsAcquired = 0;\n\tgoto L_0032;\nL_0032:\n\tv66 = v123.sharedTemplateMaterialsRefCount >= 1;\n\tif (v66) goto L_0047;\n\tgoto L_005E;\nL_0047:\n\tgoto L_0048;\nL_0048:\n\tv110 = v123.sharedTemplateMaterialsRefCount - 1;\n\tv122.sharedTemplateMaterialsRefCount = v110;\n\tv65 = v110 <= 0;\n\tif (v65) goto L_0074;\nL_005E:\n\treturn;\nL_0074:\n\tgoto L_0079;\nL_0079:\n\tv389 = 0xB292000 + 0x5A0;\n\tv208 = *([B7951B1]) & 1;\n\tv209 = v208 == 0;\n\tv404 = v389;\n\tif (v209) goto L_00BD;\n\tv222 = *([v389 @ X21_v16 (System.Int32)]);\n\tv224 = *([v222 @ X0_v75+E4]) == 0;\n\tv289 = v198.fxMatGlowTemplate;\n\tv404 = v389;\n\tv257 = v198.fxMatGlowTemplate;\n\tif (v224) goto L_00C7;\nL_0084:\n\tv251 = UnityEngine.Object::op_Inequality(v289, 0);\n\tv261 = ~v251;\n\tv262 = ~v261;\n\tv404 = v389;\n\tif (v262) goto L_00CE;\nL_008A:\n\tv305 = v277.fxMatInnerGlow;\n\tv280 = *([B7951B1]) & 1;\n\tv281 = v280 == 0;\n\tv404 = v389;\n\tv317 = v277.fxMatInnerGlow;\n\tif (v281) goto L_00DF;\nL_008F:\n\tv307 = *([v389 @ X21_v16 (System.Int32)]);\n\tv309 = *([v307 @ X0_v69+E4]) == 0;\n\tv381 = v305;\n\tv404 = v389;\n\tv345 = v305;\n\tif (v309) goto L_00E9;\nL_0096:\n\tv337 = UnityEngine.Object::op_Inequality(v381, 0);\n\tv353 = ~v337;\n\tv354 = ~v353;\n\tv404 = v389;\n\tif (v354) goto L_00F0;\nL_009C:\n\tv397 = v369.fxMatOutlineTemplate;\n\tv372 = *([B7951B1]) & 1;\n\tv373 = v372 == 0;\n\tv404 = v389;\n\tv409 = v369.fxMatOutlineTemplate;\n\tif (v373) goto L_0101;\nL_00A1:\n\tv399 = *([v389 @ X21_v16 (System.Int32)]);\n\tv401 = *([v399 @ X0_v63+E4]) == 0;\n\tv459 = v397;\n\tv437 = v397;\n\tif (v401) goto L_010B;\nL_00A8:\n\tv429 = UnityEngine.Object::op_Inequality(v459, 0);\n\tv445 = ~v429;\n\tv446 = ~v445;\n\tif (v446) goto L_0112;\n\tgoto L_011A;\nL_00BD:\n\t*([B7951B1]) = 1;\n\tv242 = *([v389 @ X21_v16 (System.Int32)]);\n\tv260 = *([v242 @ X0_v57+E4]) == 0;\n\tv244 = ~v260;\n\tv389 = v389;\n\tv289 = v198.fxMatGlowTemplate;\n\tv257 = v198.fxMatGlowTemplate;\n\tif (v244) goto L_0084;\nL_00C7:\n\tv266 = UnityEngine.Object::op_Inequality(v257, 0);\n\tv273 = ~v266;\n\tv389 = v404;\n\tv289 = v257;\n\tif (v273) goto L_008A;\nL_00CE:\n\tgoto L_00D2;\nL_00D2:\n\tUnityEngine.Object::DestroyImmediate(v289);\n\tv305 = v350.fxMatInnerGlow;\n\tv351 = *([B7951B1]) & 1;\n\tv352 = v351 == 0;\n\tv302 = ~v352;\n\tv389 = v404;\n\tv317 = v350.fxMatInnerGlow;\n\tif (v302) goto L_008F;\nL_00DF:\n\t*([B7951B1]) = 1;\n\tv328 = *([v404 @ X21_v6 (System.Int32)]);\n\tv348 = *([v328 @ X0_v43+E4]) == 0;\n\tv330 = ~v348;\n\tv389 = v404;\n\tv381 = v317;\n\tv345 = v317;\n\tif (v330) goto L_0096;\nL_00E9:\n\tv358 = UnityEngine.Object::op_Inequality(v345, 0);\n\tv365 = ~v358;\n\tv389 = v404;\n\tv381 = v345;\n\tif (v365) goto L_009C;\nL_00F0:\n\tgoto L_00F4;\nL_00F4:\n\tUnityEngine.Object::DestroyImmediate(v381);\n\tv397 = v442.fxMatOutlineTemplate;\n\tv443 = *([B7951B1]) & 1;\n\tv444 = v443 == 0;\n\tv394 = ~v444;\n\tv389 = v404;\n\tv409 = v442.fxMatOutlineTemplate;\n\tif (v394) goto L_00A1;\nL_0101:\n\t*([B7951B1]) = 1;\n\tv420 = *([v404 @ X21_v6 (System.Int32)]);\n\tv440 = *([v420 @ X0_v29+E4]) == 0;\n\tv422 = ~v440;\n\tv459 = v409;\n\tv437 = v409;\n\tif (v422) goto L_00A8;\nL_010B:\n\tv450 = UnityEngine.Object::op_Inequality(v437, 0);\n\tv457 = ~v450;\n\tv459 = v437;\n\tif (v457) goto L_011A;\nL_0112:\n\tgoto L_0116;\nL_0116:\n\tUnityEngine.Object::DestroyImmediate(v459);\nL_011A:\n\tv473.fxMatGlowTemplate = 0;\n\tv480.fxMatInnerGlow = 0;\n\tv484.fxMatOutlineTemplate = 0;\n\treturn;\nL_001E:\n\tv52 = this.sharedTemplateMaterialsAcquired != 1;\n\tif (v52) goto L_005E;\n")]
		private void ReleaseSharedTemplateMaterials()
		{
			//IL_02e4: Expected O, but got I4
			//IL_00d0: Expected O, but got I4
			//IL_019e: Expected O, but got I4
			//IL_03de: Expected O, but got I4
			//IL_04d6: Expected O, but got I4
			//IL_026a: Expected O, but got I4
			if (!sharedTemplateMaterialsAcquired)
			{
				return;
			}
			sharedTemplateMaterialsAcquired = false;
			if (sharedTemplateMaterialsRefCount < 1 || --sharedTemplateMaterialsRefCount > 0)
			{
				return;
			}
			int num = 187244544 + 1440;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B7951B1]");
			int num2 = (int)((nint)0 & (nint)1);
			bool flag = num2 == 0;
			int num3 = num;
			UnityEngine.Object obj2;
			UnityEngine.Object obj3;
			if (!flag)
			{
				object obj = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v222 @ X0_v75+E4]");
				bool flag2 = (nint)0 == 0;
				obj2 = fxMatGlowTemplate;
				num3 = num;
				obj3 = fxMatGlowTemplate;
				if (!flag2)
				{
					goto IL_010f;
				}
			}
			else
			{
				_ = 1;
				object obj4 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ X0_v57+E4]");
				bool flag3 = (nint)0 == 0;
				bool flag4 = !flag3;
				num = num;
				obj2 = fxMatGlowTemplate;
				obj3 = fxMatGlowTemplate;
				if (flag4)
				{
					goto IL_010f;
				}
			}
			bool flag5 = obj3 != null;
			bool flag6 = !flag5;
			num = num3;
			obj2 = obj3;
			if (flag6)
			{
				goto IL_0149;
			}
			goto IL_036f;
			IL_04c8:
			_ = 1;
			object obj5 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v420 @ X0_v29+E4]");
			bool flag7 = (nint)0 == 0;
			bool flag8 = !flag7;
			Material material;
			UnityEngine.Object obj6 = material;
			UnityEngine.Object obj7 = material;
			if (flag8)
			{
				goto IL_029f;
			}
			goto IL_0516;
			IL_0262:
			object obj8 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v399 @ X0_v63+E4]");
			bool flag9 = (nint)0 == 0;
			Material material2;
			obj6 = material2;
			obj7 = material2;
			if (!flag9)
			{
				goto IL_029f;
			}
			goto IL_0516;
			IL_0516:
			bool flag10 = obj7 != null;
			bool flag11 = !flag10;
			obj6 = obj7;
			if (!flag11)
			{
				goto IL_054f;
			}
			goto IL_055d;
			IL_055d:
			fxMatGlowTemplate = null;
			fxMatInnerGlow = null;
			fxMatOutlineTemplate = null;
			return;
			IL_054f:
			UnityEngine.Object.DestroyImmediate(obj6);
			goto IL_055d;
			IL_029f:
			if (!(obj6 != null))
			{
				goto IL_055d;
			}
			goto IL_054f;
			IL_010f:
			bool flag12 = obj2 != null;
			bool flag13 = !flag12;
			bool flag14 = !flag13;
			num3 = num;
			if (!flag14)
			{
				goto IL_0149;
			}
			goto IL_036f;
			IL_036f:
			UnityEngine.Object.DestroyImmediate(obj2);
			Material material3 = fxMatInnerGlow;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B7951B1]");
			int num4 = (int)((nint)0 & (nint)1);
			bool flag15 = num4 == 0;
			bool flag16 = !flag15;
			num = num3;
			Material material4 = fxMatInnerGlow;
			if (flag16)
			{
				goto IL_0196;
			}
			goto IL_03d0;
			IL_0149:
			material3 = fxMatInnerGlow;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B7951B1]");
			int num5 = (int)((nint)0 & (nint)1);
			bool flag17 = num5 == 0;
			num3 = num;
			material4 = fxMatInnerGlow;
			if (!flag17)
			{
				goto IL_0196;
			}
			goto IL_03d0;
			IL_03d0:
			_ = 1;
			object obj9 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ X0_v43+E4]");
			bool flag18 = (nint)0 == 0;
			bool flag19 = !flag18;
			num = num3;
			UnityEngine.Object obj10 = material4;
			UnityEngine.Object obj11 = material4;
			if (flag19)
			{
				goto IL_01db;
			}
			goto IL_0426;
			IL_0196:
			object obj12 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v307 @ X0_v69+E4]");
			bool flag20 = (nint)0 == 0;
			obj10 = material3;
			num3 = num;
			obj11 = material3;
			if (!flag20)
			{
				goto IL_01db;
			}
			goto IL_0426;
			IL_0426:
			bool flag21 = obj11 != null;
			bool flag22 = !flag21;
			num = num3;
			obj10 = obj11;
			if (flag22)
			{
				goto IL_0215;
			}
			goto IL_0467;
			IL_01db:
			bool flag23 = obj10 != null;
			bool flag24 = !flag23;
			bool flag25 = !flag24;
			num3 = num;
			if (!flag25)
			{
				goto IL_0215;
			}
			goto IL_0467;
			IL_0467:
			UnityEngine.Object.DestroyImmediate(obj10);
			material2 = fxMatOutlineTemplate;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B7951B1]");
			int num6 = (int)((nint)0 & (nint)1);
			bool flag26 = num6 == 0;
			bool flag27 = !flag26;
			num = num3;
			material = fxMatOutlineTemplate;
			if (flag27)
			{
				goto IL_0262;
			}
			goto IL_04c8;
			IL_0215:
			material2 = fxMatOutlineTemplate;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [B7951B1]");
			int num7 = (int)((nint)0 & (nint)1);
			bool flag28 = num7 == 0;
			num3 = num;
			material = fxMatOutlineTemplate;
			if (!flag28)
			{
				goto IL_0262;
			}
			goto IL_04c8;
		}

		[Token(Token = "0x6000069")]
		[Address(RVA = "0x770DB60", Offset = "0x770DB60", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tthis.cbHighlightEmpty = 1;\n\treturn;\nL_0020:\n\tv48 = new UnityEngine.Rendering.CommandBuffer();\n\tUnityEngine.Rendering.CommandBuffer::.ctor(v48);\n\tthis.cbHighlight = v48;\n\tv76 = UnityEngine.Object::get_name(this);\n\tUnityEngine.Rendering.CommandBuffer::set_name(this.cbHighlight, v76);\n\tthis.cbHighlightEmpty = 1;\n\treturn;\nL_0013:\n\tv39 = this.cbHighlight == 0;\n\tif (v39) goto L_0020;\n")]
		private void InitCommandBuffer()
		{
			if (cbHighlight != null)
			{
				cbHighlightEmpty = true;
				return;
			}
			CommandBuffer commandBuffer = new CommandBuffer();
			cbHighlight = commandBuffer;
			string text = base.name;
			cbHighlight.name = text;
			cbHighlightEmpty = true;
		}

		[Token(Token = "0x600006A")]
		[Address(RVA = "0x7719DC0", Offset = "0x7719DC0", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = this.cbHighlightEmpty != 1;\n\tif (v25) goto L_0077;\n\tthis.cbHighlightEmpty = 0;\n\tv29 = this.colorAttachmentBuffer;\n\tUnityEngine.Rendering.RenderTargetIdentifier::.ctor(&v38 @ stack_-60_v3 (UnityEngine.Rendering.RenderTargetIdentifier), &v29 @ stack_-90_v2 (UnityEngine.Rendering.RenderTargetIdentifier), 0, -1, -1);\n\tthis.colorAttachmentBuffer = v38;\n\tthis.colorAttachmentBuffer.m_BufferPointer = 0;\n\tthis.colorAttachmentBuffer.m_DepthSlice = 0;\n\tv127 = this.depthAttachmentBuffer;\n\tUnityEngine.Rendering.RenderTargetIdentifier::.ctor(&v29 @ stack_-90_v2 (UnityEngine.Rendering.RenderTargetIdentifier), &v127 @ stack_-C0_v2 (UnityEngine.Rendering.RenderTargetIdentifier), 0, -1, -1);\n\tthis.depthAttachmentBuffer = this.colorAttachmentBuffer;\n\tthis.depthAttachmentBuffer.m_BufferPointer = 0;\n\tthis.depthAttachmentBuffer.m_DepthSlice = 0;\n\tv127 = this.colorAttachmentBuffer;\n\tv201 = this.colorAttachmentBuffer;\n\tUnityEngine.Rendering.CommandBuffer::SetRenderTarget(this.cbHighlight, &v127 @ stack_-C0_v2 (UnityEngine.Rendering.RenderTargetIdentifier), 0, 0, &v201 @ stack_-F0_v3 (UnityEngine.Rendering.RenderTargetIdentifier), 0, 0);\n\tv127 = this.colorAttachmentBuffer;\n\tv201 = this.depthAttachmentBuffer;\n\tUnityEngine.Rendering.CommandBuffer::SetRenderTarget(this.cbHighlight, &v127 @ stack_-C0_v2 (UnityEngine.Rendering.RenderTargetIdentifier), &v201 @ stack_-F0_v3 (UnityEngine.Rendering.RenderTargetIdentifier));\nL_0077:\n\treturn;\n")]
		private void ConfigureOutput()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::ConfigureOutput");
		}

		[Token(Token = "0x600006B")]
		[Address(RVA = "0x770D9F0", Offset = "0x770D9F0", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv54 = v42.Length != 1;\n\tif (v54) goto L_FFFFFFFF;\n\tv109 = UnityEngine.Component::get_transform(this);\n\tgoto L_0031;\nL_0031:\n\tv92 = UnityEngine.Object::op_Inequality(*([v42 @ X8_v3 (ModelMaterials[])+28]), v109);\n\tv97 = v92 == 0;\n\tif (v97) goto L_003F;\n\tgoto L_FFFFFFFF;\nL_003F:\n\tv203 = this.rms;\n\tgoto L_004D;\nL_004D:\n\tv91 = UnityEngine.Object::op_Equality(*([v203 @ X8_v8 (ModelMaterials[])+50]), 0);\n\tv96 = v91 == 0;\n\tif (v96) goto L_0064;\nL_FFFFFFFF:\n\tv127 = 1;\nL_0064:\n\tv220 = this.rms;\n\tgoto L_0076;\n\tv132 = this.rms;\n\tv127 = UnityEngine.Renderer::get_isVisible(*([v132 @ X8_v14 (ModelMaterials[])+50]));\n\tgoto L_0052;\nL_0014:\n\tv42 = this.rms;\n\tv43 = this.rms == 0;\n\tif (v43) goto L_FFFFFFFF;\nL_0076:\n\tv155 = UnityEngine.Object::op_Inequality(*([v220 @ X8_v12 (ModelMaterials[])+50]), 0);\n\tv157 = ~v155;\n\tif (v157) goto L_005A;\nL_005A:\n\treturn;\nL_0052:\n\tthis.isVisible = v127;\n")]
		public void UpdateVisibilityState()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::UpdateVisibilityState");
		}

		[Token(Token = "0x600006C")]
		[Address(RVA = "0x770EA48", Offset = "0x770EA48", Length = "0x3BF4")]
		public unsafe void UpdateMaterialProperties(bool disabling = false)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::UpdateMaterialProperties");
		}

		[Token(Token = "0x600006D")]
		[Address(RVA = "0x7722038", Offset = "0x7722038", Length = "0x1FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\nL_0016:\n\tgoto L_001A;\nL_001A:\n\tv58 = UnityEngine.Object::op_Inequality(m1.renderer, 0);\n\tv68 = ~v58;\n\tv69 = ~v68;\nL_FFFFFFFF:\n\tv172 = 0;\n\tif (v69) goto L_0061;\nL_FFFFFFFF:\n\tv108 = m2.renderer;\n\tgoto L_0027;\nL_0027:\n\tv113 = UnityEngine.Object::op_Inequality(v108, 0);\n\tv158 = ~v113;\n\tv159 = ~v158;\nL_FFFFFFFF:\n\tv246 = 0;\n\tif (v159) goto L_0075;\nL_FFFFFFFF:\n\tv151 = v172;\n\tgoto L_0033;\nL_0033:\n\tv240 = UnityEngine.Object::op_Inequality(v151, 0);\n\tv231 = ~v240;\n\tv232 = ~v231;\n\tif (v232) goto L_0087;\nL_FFFFFFFF:\n\tv257 = v240;\nL_FFFFFFFF:\n\tv153 = v246;\n\tgoto L_003F;\nL_003F:\n\tv268 = UnityEngine.Object::op_Inequality(v153, 0);\n\tv280 = ~v268;\n\tif (v280) goto L_FFFFFFFF;\n\tv300 = UnityEngine.Material::get_renderQueue(v153);\nL_FFFFFFFF:\n\tv185 = v300;\nL_FFFFFFFF:\n\tv189 = v257;\n\tgoto L_0099;\nL_0061:\n\tv123 = UnityEngine.Renderer::get_sharedMaterial(m1.renderer);\nL_FFFFFFFF:\n\tv172 = v123;\nL_FFFFFFFF:\n\tv108 = m2.renderer;\n\tgoto L_0027;\nL_0075:\n\tv230 = UnityEngine.Renderer::get_sharedMaterial(m2.renderer);\nL_FFFFFFFF:\n\tv151 = v172;\nL_FFFFFFFF:\n\tv246 = v230;\n\tgoto L_0033;\nL_0087:\n\tv279 = UnityEngine.Material::get_renderQueue(v151);\nL_FFFFFFFF:\n\tv257 = v279;\nL_FFFFFFFF:\n\tv153 = v246;\n\tgoto L_003F;\nL_FFFFFFFF:\n\tv185 = 0;\nL_FFFFFFFF:\n\tv189 = v257;\nL_0099:\n\treturnVal2 = System.Int32::CompareTo(&v189 @ stack_-34_v1 (System.Int32), v185);\n\treturn returnVal2;\n")]
		private int MaterialsRenderQueueComparer(ModelMaterials m1, ModelMaterials m2)
		{
			bool flag = m1.renderer != null;
			bool flag2 = !flag;
			bool flag3 = !flag2;
			Material material = null;
			UnityEngine.Object renderer;
			if (!flag3)
			{
				renderer = m2.renderer;
			}
			else
			{
				Material sharedMaterial = m1.renderer.sharedMaterial;
				material = sharedMaterial;
				renderer = m2.renderer;
			}
			bool flag4 = renderer != null;
			bool flag5 = !flag4;
			bool flag6 = !flag5;
			Material material2 = null;
			UnityEngine.Object obj;
			if (!flag6)
			{
				obj = material;
			}
			else
			{
				Material sharedMaterial2 = m2.renderer.sharedMaterial;
				obj = material;
				material2 = sharedMaterial2;
			}
			bool flag7 = obj != null;
			bool flag8;
			UnityEngine.Object obj2;
			if (!flag7)
			{
				flag8 = flag7;
				obj2 = material2;
			}
			else
			{
				int renderQueue = ((Material)obj).renderQueue;
				flag8 = (byte)renderQueue != 0;
				obj2 = material2;
			}
			int value;
			int num;
			if (obj2 != null)
			{
				int renderQueue2 = ((Material)obj2).renderQueue;
				value = renderQueue2;
				num = (flag8 ? 1 : 0);
			}
			else
			{
				value = 0;
				num = (flag8 ? 1 : 0);
			}
			return num.CompareTo(value);
		}

		[Token(Token = "0x600006E")]
		[Address(RVA = "0x7722234", Offset = "0x7722234", Length = "0x200")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\nL_0016:\n\tgoto L_001A;\nL_001A:\n\tv58 = UnityEngine.Object::op_Inequality(m1.renderer, 0);\n\tv68 = ~v58;\n\tv69 = ~v68;\nL_FFFFFFFF:\n\tv174 = 0;\n\tif (v69) goto L_005A;\nL_FFFFFFFF:\n\tv108 = m2.renderer;\n\tgoto L_0027;\nL_0027:\n\tv113 = UnityEngine.Object::op_Inequality(v108, 0);\n\tv160 = ~v113;\n\tv161 = ~v160;\nL_FFFFFFFF:\n\tv153 = 0;\n\tif (v161) goto L_006E;\nL_FFFFFFFF:\n\tv149 = v174;\n\tgoto L_0033;\nL_0033:\n\tv222 = UnityEngine.Object::op_Inequality(v149, 0);\n\tv233 = ~v222;\n\tif (v233) goto L_FFFFFFFF;\n\tv256 = UnityEngine.Material::get_renderQueue(v149);\nL_FFFFFFFF:\n\tv155 = v153;\nL_FFFFFFFF:\n\tv301 = v256;\n\tgoto L_0085;\nL_005A:\n\tv123 = UnityEngine.Renderer::get_sharedMaterial(m1.renderer);\nL_FFFFFFFF:\n\tv174 = v123;\nL_FFFFFFFF:\n\tv108 = m2.renderer;\n\tgoto L_0027;\nL_006E:\n\tv232 = UnityEngine.Renderer::get_sharedMaterial(m2.renderer);\nL_FFFFFFFF:\n\tv149 = v174;\nL_FFFFFFFF:\n\tv153 = v232;\n\tgoto L_0033;\nL_FFFFFFFF:\n\tv155 = v153;\nL_FFFFFFFF:\n\tv301 = 0;\n\tgoto L_0085;\nL_0085:\n\tv273 = UnityEngine.Object::op_Inequality(v155, 0);\n\tv285 = ~v273;\n\tv286 = ~v285;\n\tif (v286) goto L_0095;\nL_FFFFFFFF:\n\tv296 = v273;\n\tgoto L_0096;\nL_0095:\n\tv296 = UnityEngine.Material::get_renderQueue(v155);\nL_0096:\n\tv191 = v296;\n\treturnVal2 = System.Int32::CompareTo(&v191 @ stack_-34_v3 (System.Int32), v301);\n\treturn returnVal2;\n")]
		private int MaterialsRenderQueueInvertedComparer(ModelMaterials m1, ModelMaterials m2)
		{
			bool flag = m1.renderer != null;
			bool flag2 = !flag;
			bool flag3 = !flag2;
			Material material = null;
			UnityEngine.Object renderer;
			if (!flag3)
			{
				renderer = m2.renderer;
			}
			else
			{
				Material sharedMaterial = m1.renderer.sharedMaterial;
				material = sharedMaterial;
				renderer = m2.renderer;
			}
			bool flag4 = renderer != null;
			bool flag5 = !flag4;
			bool flag6 = !flag5;
			Material material2 = null;
			UnityEngine.Object obj;
			if (!flag6)
			{
				obj = material;
			}
			else
			{
				Material sharedMaterial2 = m2.renderer.sharedMaterial;
				obj = material;
				material2 = sharedMaterial2;
			}
			UnityEngine.Object obj2;
			int value;
			if (obj != null)
			{
				int renderQueue = ((Material)obj).renderQueue;
				obj2 = material2;
				value = renderQueue;
			}
			else
			{
				obj2 = material2;
				value = 0;
			}
			bool flag7 = obj2 != null;
			int num = (flag7 ? ((Material)obj2).renderQueue : (flag7 ? 1 : 0));
			int num2 = num;
			return num2.CompareTo(value);
		}

		[Token(Token = "0x600006F")]
		[Address(RVA = "0x771C064", Offset = "0x771C064", Length = "0x134")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = cameraTransform == 0;\n\tif (v21) goto L_005E;\n\tv31 = UnityEngine.Transform::get_position(cameraTransform);\n\tv46 = position - v31;\n\tv47 = position.y - v31.y;\n\tv48 = position.z - v31.z;\n\tv51 = UnityEngine.Transform::get_forward(cameraTransform);\n\tv85 = v46 * v51;\n\tv86 = v47 * v51.y;\n\tv87 = v85 + v86;\n\tv88 = v48 * v51.z;\n\tv89 = v88 + v87;\n\tv91 = v89 < this.cameraDistanceFadeNear;\n\tv99 = ~v91;\n\tif (v99) goto L_0034;\n\tv200 = this.cameraDistanceFadeNear - v89;\n\tgoto L_0042;\nL_0034:\n\tv163 = v89 < this.cameraDistanceFadeFar;\n\tv164 = v89 == this.cameraDistanceFadeFar;\n\tv167 = v89 == v89;\n\tv168 = this.cameraDistanceFadeFar == this.cameraDistanceFadeFar;\n\tv169 = v167 & v168;\n\tv170 = ~v169;\n\tv171 = v163 == v170;\n\tv172 = ~v171;\n\tv173 = v172 | v164;\n\treturnVal2 = 1f;\n\tif (v173) goto L_005D;\n\tv200 = v89 - this.cameraDistanceFadeFar;\n\tv200 = 1f;\n\tgoto L_0053;\nL_005E:\n\tthrow System.NullReferenceException;\nL_0042:\n\tv185 = v200 < 1f;\n\tv186 = v200 == 1f;\n\tv189 = v200 == v200;\n\tv190 = 1f == 1f;\n\tv191 = v189 & v190;\n\tv192 = ~v191;\n\tv193 = v185 == v192;\n\tv194 = ~v186;\n\tv195 = v193 & v194;\n\tv196 = ~v195;\n\tif (v196) goto L_0053;\nL_005D:\n\treturn returnVal2;\nL_0053:\n\treturnVal2 = 1f - v200;\n")]
		private float ComputeCameraDistanceFade(Vector3 position, Transform cameraTransform)
		{
			float result;
			if ((object)cameraTransform != null)
			{
				Vector3 position2 = cameraTransform.position;
				float num = position.x - position2.x;
				float num2 = position.y - position2.y;
				float num3 = position.z - position2.z;
				Vector3 forward = cameraTransform.forward;
				float num4 = num * forward.x;
				float num5 = num2 * forward.y;
				float num6 = num4 + num5;
				float num7 = num3 * forward.z;
				float num8 = num7 + num6;
				float num9;
				if (num8 < cameraDistanceFadeNear)
				{
					num9 = cameraDistanceFadeNear - num8;
				}
				else
				{
					bool flag = num8 < cameraDistanceFadeFar;
					bool flag2 = num8 == cameraDistanceFadeFar;
					bool flag3 = num8 == num8;
					bool flag4 = cameraDistanceFadeFar == cameraDistanceFadeFar;
					bool flag5 = flag3 && flag4;
					bool flag6 = !flag5;
					bool flag7 = flag == flag6;
					bool flag8 = !flag7;
					bool flag9 = flag8 || flag2;
					result = 1f;
					if (flag9)
					{
						goto IL_0280;
					}
					num9 = num8 - cameraDistanceFadeFar;
				}
				bool flag10 = num9 < 1f;
				bool flag11 = num9 == 1f;
				bool flag12 = num9 == num9;
				bool flag13 = 1f == 1f;
				bool flag14 = flag12 && flag13;
				bool flag15 = !flag14;
				bool flag16 = flag10 == flag15;
				bool flag17 = !flag11;
				if (flag16 && flag17)
				{
					num9 = 1f;
				}
				result = 1f - num9;
				goto IL_0280;
			}
			throw new NullReferenceException();
			IL_0280:
			return result;
		}

		[Token(Token = "0x6000070")]
		[Address(RVA = "0x771E9DC", Offset = "0x771E9DC", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = param != 2;\n\tif (v11) goto L_FFFFFFFF;\n\tv14 = 4 + 1;\n\tgoto L_001A;\nL_FFFFFFFF:\n\tv14 = 4;\nL_FFFFFFFF:\n\treturnVal1 = 8;\n\tgoto L_0020;\nL_FFFFFFFF:\n\treturnVal1 = v14;\nL_001A:\n\tv25 = param != 1;\n\tif (v25) goto L_FFFFFFFF;\nL_0020:\n\treturn returnVal1;\n")]
		private int GetZTestValue(Visibility param)
		{
			int result = ((param != Visibility.OnlyWhenOccluded) ? 4 : (4 + 1));
			if (param == Visibility.AlwaysOnTop)
			{
				return 8;
			}
			return result;
		}

		[Token(Token = "0x6000071")]
		[Address(RVA = "0x770DC14", Offset = "0x770DC14", Length = "0x350")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\t*([v85 @ X0_v9 (UnityEngine.Vector3[])+20]) = 0xBF;\n\t*([v85 @ X0_v9 (UnityEngine.Vector3[])+28]) = 0;\n\t*([v85 @ X0_v9 (UnityEngine.Vector3[])+2C]) = 0xFFFFFFFFFFFFFF41;\n\t*([v85 @ X0_v9 (UnityEngine.Vector3[])+34]) = 0;\n\t*([v85 @ X0_v9 (UnityEngine.Vector3[])+38]) = 0xFFFFFFFFFFFFFFC1;\n\t*([v85 @ X0_v9 (UnityEngine.Vector3[])+40]) = 0;\n\t*([v85 @ X0_v9 (UnityEngine.Vector3[])+44]) = 0x3F;\n\t*([v85 @ X0_v9 (UnityEngine.Vector3[])+4C]) = 0;\n\t// 117 NewArr v201 @ X0_v15 (UnityEngine.Vector2[]), typeof(UnityEngine.Vector2[]), v85.Length\n\t*([v201 @ X0_v15 (UnityEngine.Vector2[])+20]) = 0;\n\t*([v201 @ X0_v15 (UnityEngine.Vector2[])+28]) = 0.0078125d;\n\t*([v201 @ X0_v15 (UnityEngine.Vector2[])+30]) = 5.263544247E-315d;\n\t*([v201 @ X0_v15 (UnityEngine.Vector2[])+38]) = 0;\n\t// 171 NewArr v374 @ X0_v17 (System.Int32[]), typeof(System.Int32[]), 6\n\tSystem.Runtime.CompilerServices.RuntimeHelpers::InitializeArray(v374, Il2CppFieldInfo);\n\t// 178 NewArr v202 @ X0_v19 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), v85.Length\n\tv256 = v202.Length < 1;\n\tif (v256) goto L_012A;\n\tv380 = *([B193AF1]) & 1;\n\tv314 = v380 == 0;\n\tif (v314) goto L_00F0;\n\tv246 = v202.Length & 0x7FFFFFFF;\n\tv243 = v202 + 0x28;\n\tv317 = 0;\nL_00DB:\n\t*([v243 @ X11_v8-8]) = v382.forward;\n\t*([v243 @ X11_v8]) = v382.forward.z;\n\tv243 = v243 + 0xC;\n\tv317 = v317 + 1;\n\tv447 = v317 < v246;\n\tv415 = ~v447;\n\tv391 = ~v415;\n\tif (v391) goto L_00DB;\n\tgoto L_012A;\nL_00F0:\n\t*([B193AF1]) = 1;\n\t*([v202 @ X0_v19 (UnityEngine.Vector3[])+20]) = v386.forward;\n\t*([v202 @ X0_v19 (UnityEngine.Vector3[])+28]) = v386.forward.z;\n\tv392 = v202.Length < 2;\n\tif (v392) goto L_012A;\n\tv319 = v202.Length & 0x7FFFFFFF;\n\tv248 = v202 + 0x34;\n\tv244 = 1;\nL_0117:\n\t*([v248 @ X10_v6-8]) = v381.forward;\n\t*([v248 @ X10_v6]) = v381.forward.z;\n\tv248 = v248 + 0xC;\n\tv244 = v244 + 1;\n\tv464 = v244 < v319;\n\tv414 = ~v464;\n\tv390 = ~v414;\n\tif (v390) goto L_0117;\nL_012A:\n\tgoto L_0133;\nL_0133:\n\tUnityEngine.Mesh::set_vertices(v226.quadMesh, v85);\n\tUnityEngine.Mesh::set_uv(v222.quadMesh, v201);\n\tUnityEngine.Mesh::set_triangles(v223.quadMesh, v374);\n\tUnityEngine.Mesh::set_normals(v224.quadMesh, v202);\n\tUnityEngine.Mesh::RecalculateBounds(v225.quadMesh);\n\treturn;\nL_002D:\n\tv57 = new UnityEngine.Mesh();\n\tUnityEngine.Mesh::.ctor(v57);\n\tgoto L_0039;\nL_0039:\n\tv76.quadMesh = v57;\n\t// 63 NewArr v85 @ X0_v9 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), 4\n")]
		private void BuildQuad()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::BuildQuad");
		}

		[Token(Token = "0x6000072")]
		[Address(RVA = "0x770DF64", Offset = "0x770DF64", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\nL_0021:\n\tv50 = UnityEngine.Resources::GetBuiltinResource(\"Cube.fbx\");\n\tgoto L_002B;\nL_002B:\n\tv64.cubeMesh = v50;\n\treturn;\n")]
		private void BuildCube()
		{
			Mesh builtinResource = Resources.GetBuiltinResource<Mesh>("Cube.fbx");
			cubeMesh = builtinResource;
		}

		[Token(Token = "0x6000073")]
		[Address(RVA = "0x7713714", Offset = "0x7713714", Length = "0x254")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001B:\n\tgoto L_001F;\nL_001F:\n\tv72 = UnityEngine.Object::op_Inequality(this.instantiatedIconPrefab, 0);\n\tv84 = ~v72;\n\tv85 = ~v84;\n\tif (v85) goto L_004F;\n\tv128 = this.instantiatedIconMaterials;\n\tv104 = this.instantiatedIconMaterials == 0;\n\tv105 = ~v104;\n\tif (v105) goto L_0065;\n\tgoto L_00A8;\nL_004F:\n\tgoto L_0053;\nL_0053:\n\tUnityEngine.Object::DestroyImmediate(this.instantiatedIconPrefab);\n\tthis.instantiatedIconPrefab = 0;\n\tv128 = this.instantiatedIconMaterials;\n\tv134 = this.instantiatedIconMaterials == 0;\n\tif (v134) goto L_00A8;\nL_0065:\n\tv147 = System.Collections.Generic.List`1<UnityEngine.Material>::GetEnumerator(v128);\n\tv187 = v147._list;\n\tgoto L_007A;\nL_0074:\n\tgoto L_0077;\nL_0077:\n\tUnityEngine.Object::DestroyImmediate(v147.Current);\nL_007A:\n\tv224 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v187 @ stack_-68_v3 (System.Collections.Generic.List`1<UnityEngine.Material>));\n\tv189 = v224 == 0;\n\tif (v189) goto L_0098;\n\tgoto L_008B;\nL_0090:\n\tv215 = UnityEngine.Object::op_Inequality(v147.Current, 0);\n\tv218 = ~v215;\n\tif (v218) goto L_007A;\n\tgoto L_0074;\nL_0098:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v187 @ stack_-68_v3 (System.Collections.Generic.List`1<UnityEngine.Material>));\n\tthis.instantiatedIconMaterials = 0;\nL_00A8:\n\treturn;\nL_008B:\n\tgoto L_0090;\n")]
		private unsafe void ReleaseInstantiatedIconPrefab()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::ReleaseInstantiatedIconPrefab");
		}

		[Token(Token = "0x6000074")]
		[Address(RVA = "0x771C198", Offset = "0x771C198", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\nL_0014:\n\tgoto L_0018;\nL_0018:\n\tv55 = UnityEngine.Object::op_Inequality(this.instantiatedIconPrefab, 0);\n\tv63 = ~v55;\n\tif (v63) goto L_0043;\n\tUnityEngine.GameObject::SetActive(this.instantiatedIconPrefab, 0);\n\treturn;\nL_0043:\n\treturn;\n")]
		private void HideIconPrefab()
		{
			if (instantiatedIconPrefab != null)
			{
				instantiatedIconPrefab.SetActive(value: false);
			}
		}

		[Token(Token = "0x6000075")]
		[Address(RVA = "0x7722434", Offset = "0x7722434", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv97 = 0x28;\n\tv99 = 0;\n\tgoto L_0040;\nL_0040:\n\treturnVal3 = UnityEngine.Object::op_Equality(*([v109 @ X8_v5 (ModelMaterials[])+v97 @ X24_v3 (System.Int32)]), transform);\n\tv181 = returnVal3 == 0;\n\tv104 = ~v181;\n\tif (v104) goto L_005D;\n\tv99 = v99 + 1;\n\tv97 = v97 + 0xD8;\n\tv73 = v99 < this.includedObjectsCount;\n\tif (v73) goto L_0028;\nL_005D:\n\treturn returnVal3;\nL_0068:\n\treturn 0;\nL_0022:\n\tv58 = this.includedObjectsCount < 1;\n\tif (v58) goto L_0068;\nL_0028:\n\tv109 = this.rms;\n")]
		public bool Includes(Transform transform)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::Includes");
			return default;
		}

		[Token(Token = "0x6000076")]
		[Address(RVA = "0x7722510", Offset = "0x7722510", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this.glowPasses;\n\tv6 = this.glowPasses == 0;\n\tif (v6) goto L_007E;\n\tv18 = v4.Length < 1;\n\tif (v18) goto L_007E;\n\tv58 = v4.Length & 0x7FFFFFFF;\n\tv106 = v58 < 2;\n\tv107 = ~v106;\n\tv115 = ~v107;\n\tif (v115) goto L_FFFFFFFF;\n\tv116 = this.glowPasses + 0x30;\n\tv118 = v58 * 0x18;\n\tv119 = v118 - 0x18;\n\tv120 = v116 + v119;\n\tv42 = this.glowPasses + 0x34;\n\tv38 = v42 + v119;\n\tv34 = this.glowPasses + 0x2C;\n\tv30 = v34 + v119;\n\tv26 = this.glowPasses + 0x28;\n\tv121 = v26 + v119;\n\tv122 = v120 < v116;\n\tv123 = ~v122;\n\tv131 = ~v123;\n\tif (v131) goto L_FFFFFFFF;\n\tv158 = v38 < v42;\n\tv192 = ~v158;\n\tgoto L_0044;\nL_FFFFFFFF:\n\tv192 = 0;\n\tv207 = v30 < v34;\n\tv227 = ~v207;\n\tgoto L_0055;\nL_FFFFFFFF:\n\tv227 = 0;\n\tv228 = v121 < v26;\n\tv156 = ~v228;\n\tgoto L_0066;\nL_FFFFFFFF:\n\tv156 = 0;\nL_FFFFFFFF:\n\tv96 = 0;\nL_007E:\n\tthis.glowHQColor.r = color;\n\tthis.glowHQColor.g = color.g;\n\tthis.glowHQColor.b = color.b;\n\tthis.glowHQColor.a = color.a;\n\tHighlightPlus.HighlightEffect::UpdateMaterialProperties(this, 0);\n\treturn;\nL_0085:\n\tv54 = v4.Length & 1;\n\tv96 = v58 - v54;\n\tv244 = this.glowPasses + 0x4C;\nL_FFFFFFFF:\n\tv243 = v96;\nL_FFFFFFFF:\n\tv243 = v45;\nL_FFFFFFFF:\n\tv244 = v49;\n\tv101 = v54 == 0;\n\tif (v101) goto L_007E;\n\tgoto L_0068;\nL_0044:\n\tv193 = ~v192;\n\tif (v193) goto L_FFFFFFFF;\nL_0055:\n\tv22 = ~v227;\n\tif (v22) goto L_FFFFFFFF;\nL_0066:\n\tif (v156) goto L_0085;\nL_006D:\n\t*([v204 @ X8_v5-C]) = color;\n\t*([v204 @ X8_v5-8]) = color.g;\n\t*([v204 @ X8_v5-4]) = color.b;\n\t*([v204 @ X8_v5]) = color.a;\n\tv204 = v204 + 0x18;\n\tv56 = v194 - 1;\n\tv60 = v194 != 1;\nL_FFFFFFFF:\n\tv194 = v56;\n\tif (v60) goto L_006D;\nL_0089:\n\t*([v244 @ X12_v9-24]) = color;\n\t*([v244 @ X12_v9-20]) = color.g;\n\t*([v244 @ X12_v9-C]) = color;\n\t*([v244 @ X12_v9-8]) = color.g;\n\t*([v244 @ X12_v9-1C]) = color.b;\n\t*([v244 @ X12_v9-18]) = color.a;\n\t*([v244 @ X12_v9-4]) = color.b;\n\t*([v244 @ X12_v9]) = color.a;\n\tv244 = v244 + 0x30;\n\tv46 = v243 - 2;\n\tv62 = v243 != 2;\nL_FFFFFFFF:\n\tv243 = v46;\n\tif (v62) goto L_0089;\nL_0068:\n\tv194 = v58 - v96;\n\tv100 = v96 * 0x18;\n\tv183 = this.glowPasses + v100;\n\tv204 = v183 + 0x34;\nL_FFFFFFFF:\n\tv194 = v57;\nL_FFFFFFFF:\n\tv204 = v205;\n")]
		public void SetGlowColor(Color color)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::SetGlowColor");
		}

		[Token(Token = "0x6000077")]
		[Address(RVA = "0x7720F84", Offset = "0x7720F84", Length = "0xA50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_004E;\n\tv83 = v66.Length <= objIndex;\n\tif (v83) goto L_0324;\n\tv749 = UnityEngine.Object::GetHashCode(v66[v230 @ X27_v4 (System.Int32)].mesh);\n\tgoto L_008A;\nL_008A:\n\tv1006 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Mesh>::TryGetValue(v985.smoothMeshes, v749, &v208 @ stack_-88_v5 (UnityEngine.Object));\n\tv1010 = ~v1006;\n\tif (v1010) goto L_00A6;\n\tgoto L_0096;\nL_0096:\n\tv1027 = UnityEngine.Object::op_Equality(v208, 0);\n\tv1041 = ~v1027;\n\tv1030 = ~v1041;\n\tif (v1030) goto L_00A6;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv288 = this;\n\tgoto L_02FB;\nL_00A6:\n\tv274 = UnityEngine.Mesh::get_isReadable(v66[v230 @ X27_v4 (System.Int32)].mesh);\n\tv278 = ~v274;\n\tif (v278) goto L_0324;\n\tgoto L_00B1;\n\tgoto L_00BF;\nL_00BF:\n\t;\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::Clear(v1079);\n\tgoto L_00CC;\n\tv279 = v270.Count == 0;\n\tif (v279) goto L_0324;\n\tgoto L_00DC;\n\tgoto L_00EA;\nL_00EA:\n\t;\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::Clear(v1148);\n\tgoto L_00F7;\n\tv905 = v270.Count - v931.Count;\n\tv893 = v905 < 0;\n\tv869 = v270.Count ^ v931.Count;\n\tv858 = v270.Count ^ v905;\n\tv847 = v869 & v858;\n\tv835 = v847 < 0;\n\tv1190 = v893 == v835;\n\tv827 = ~v1190;\n\tv601 = ~v827;\n\tif (v601) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv598 = v270.Count;\n\tgoto L_0112;\nL_FFFFFFFF:\n\tv598 = v931.Count;\n\tgoto L_0130;\nL_0130:\n\tv1207 = v598 <= v1236.Length;\n\tif (v1207) goto L_035C;\nL_0136:\n\t// 310 NewArr v1235 @ X0_v108 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), v598 @ X23_v8 (System.Int32)\n\tgoto L_0140;\n\tgoto L_0165;\nL_0165:\n\tv1328 = v598 > v1366.Length;\n\tif (v1328) goto L_0178;\nL_FFFFFFFF:\n\tv586 = v749;\nL_FFFFFFFF:\n\tv590 = this;\n\tgoto L_0170;\nL_0170:\n\tv1417 = v980.vv == 0;\n\tv964 = ~v1417;\n\tif (v964) goto L_0198;\n\tgoto L_0416;\nL_0178:\n\t// 376 NewArr v1356 @ X0_v91 (System.Int32[]), typeof(System.Int32[]), v598 @ X23_v8 (System.Int32)\n\tgoto L_0182;\nL_0198:\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Vector3, System.Int32>::Clear(v980.vv);\n\tv1522 = v598 < 1;\n\tif (v1522) goto L_02D2;\nL_FFFFFFFF:\n\tv594 = 0;\nL_01B9:\n\tv788 = System.Collections.Generic.List`1<UnityEngine.Vector3>::get_Item(v986.vertices, v594);\n\tv1609 = System.Collections.Generic.Dictionary`2<UnityEngine.Vector3, System.Int32>::TryGetValue(v982.vv, v788, &v1608 @ stack_-8C_v8 (System.Int32));\n\tv1612 = v1609 == 0;\n\tv1613 = ~v1612;\n\tif (v1613) goto L_01E3;\n\tgoto L_01DE;\nL_01DE:\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Vector3, System.Int32>::set_Item(v987.vv, v788, v594);\nL_FFFFFFFF:\n\tv1608 = v594;\nL_01E3:\n\tgoto L_01E7;\n\tv726[v594 @ X24_v10 (System.Int32)] = v594;\n\tv594 = v594 + 1;\n\tv1573 = v598 != v594;\n\tif (v1573) goto L_01B0;\nL_FFFFFFFF:\n\tv595 = 0;\n\tv702 = v727.newNormals;\n\tv1662 = v539[v595 @ X24_v13 (System.Int32)] * 0xC;\n\tv1650 = v727.newNormals + v1662;\n\tv1673 = System.Collections.Generic.List`1<UnityEngine.Vector3>::get_Item(v727.normals, v595);\n\tv1646 = *([v1650 @ X20_v11+20]) + v1673;\n\tv1645 = v702[v540 @ X10_v10 (System.Int32)].z + v1673.z;\n\t*([v1650 @ X20_v11+20]) = v1646;\n\tv702[v540 @ X10_v10 (System.Int32)].z = v1645;\n\tv595 = v595 + 1;\n\tv1651 = v598 != v595;\n\tif (v1651) goto L_020B;\nL_FFFFFFFF:\n\tv596 = 0;\n\tv542 = v728.newNormals;\n\tv1694 = v703[v596 @ X24_v16 (System.Int32)] * 0xC;\n\tv1695 = v728.newNormals + v1694;\n\tgoto L_0290;\nL_0292:\n\tv1711 = *([v1695 @ X8_v65+20]) * *([v1695 @ X8_v65+20]);\n\tv1712 = v542[v704 @ X9_v31 (System.Int32)].y * v542[v704 @ X9_v31 (System.Int32)].y;\n\tv1713 = v1711 + v1712;\n\tv1714 = v542[v704 @ X9_v31 (System.Int32)].z * v542[v704 @ X9_v31 (System.Int32)].z;\n\tv1715 = v1714 + v1713;\n\tv1716 = UnityEngine.Mathf::Sqrt(v1715);\n\tgoto L_02A5;\nL_02A5:\n\tv791 = *([v1695 @ X8_v65+20]) / v1716;\n\tv786 = v542[v704 @ X9_v31 (System.Int32)].y / v1716;\n\tv781 = v542[v704 @ X9_v31 (System.Int32)].z / v1716;\n\tgoto L_02BE;\nL_02BE:\n\t// 702 MakeStruct v1541 @ AGG7721698_2_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v791 @ V0_v18 (System.Single), v786 @ V1_v16 (System.Single), v781 @ V2_v14 (System.Single)\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::set_Item(v728.normals, v596, v1541);\n\tv596 = v596 + 1;\n\tv1548 = v598 != v596;\n\tif (v1548) goto L_025A;\nL_02D2:\n\tgoto L_02D8;\nL_02D8:\n\tv957 = UnityEngine.Object::Instantiate(v66[v230 @ X27_v4 (System.Int32)].mesh);\n\tgoto L_02ED;\nL_02ED:\n\tUnityEngine.Mesh::SetNormals(v957, v1607.normals);\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Mesh>::set_Item(v983.smoothMeshes, v586, v957);\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv288 = v590;\nL_02FB:\n\tHighlightPlus.HighlightEffect::IncrementMeshUsage(v288, v957);\n\tv281 = v288.rms;\n\tv281[v229 @ X27_v6 (System.Int32)].mesh = v957;\nL_0324:\n\treturn;\nL_0328:\n\tv1072 = new System.Collections.Generic.List`1<UnityEngine.Vector3>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::.ctor(v1072);\n\tgoto L_0336;\nL_0343:\n\tv1144 = new System.Collections.Generic.List`1<UnityEngine.Vector3>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::.ctor(v1144);\n\tgoto L_0351;\nL_035C:\n\tv1248 = 0x3D15AE8(0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv833 = v598 < 1;\n\tif (v833) goto L_0148;\n\tgoto L_036E;\nL_036E:\n\tv984 = v1292.newNormals;\n\tv1374 = v598 - 1;\n\tv1303 = v1374 < v984.Length;\n\tv1304 = ~v1303;\n\tv1312 = ~v1304;\n\tv1313 = ~v1312;\n\tif (v1313) goto L_FFFFFFFF;\n\tgoto L_0383;\nL_FFFFFFFF:\n\tv1374 = v984.Length;\nL_FFFFFFFF:\n\tv543 = 0;\n\tgoto L_03FD;\nL_03BE:\n\tv1399 = v1374 + 1;\n\tv1491 = v1399 & 7;\n\tv1402 = v1491 == 0;\n\tv1406 = ~v1402;\n\tif (v1406) goto L_03CB;\nL_FFFFFFFF:\n\tv1491 = 8;\n\tgoto L_03CB;\nL_03FD:\n\tv536 = v598 - v543;\n\tv1466 = v543 * 0xC;\n\tv1467 = v984 + v1466;\n\tv730 = v1467 + 0x28;\nL_0404:\n\t*([v730 @ X8_v111-8]) = v52;\n\t*([v730 @ X8_v111-4]) = v53;\n\t*([v730 @ X8_v111]) = v54;\n\tv730 = v730 + 0xC;\n\tv1261 = v536 - 1;\n\tv1264 = v536 != 1;\nL_FFFFFFFF:\n\tv536 = v1261;\n\tif (v1264) goto L_0404;\n\tgoto L_0148;\nL_0416:\n\tv709 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\nL_004E:\n\tv66 = this.rms;\n\tv67 = this.rms == 0;\n\tif (v67) goto L_0324;\nL_00B1:\n\tv1079 = v1053.normals;\n\tv1055 = v1053.normals == 0;\n\tif (v1055) goto L_0328;\nL_00CC:\n\tUnityEngine.Mesh::GetNormals(v66[v230 @ X27_v4 (System.Int32)].mesh, v1112.normals);\n\tv270 = v283.normals;\nL_00DC:\n\tv1148 = v1135.vertices;\n\tv1138 = v1135.vertices == 0;\n\tif (v1138) goto L_0343;\nL_00F7:\n\tUnityEngine.Mesh::GetVertices(v66[v230 @ X27_v4 (System.Int32)].mesh, v1176.vertices);\n\tv931 = v977.vertices;\nL_0112:\n\tgoto L_0116;\nL_0140:\n\tv1252.newNormals = v1235;\nL_014C:\n\tv1366 = v1298.matches;\n\tv1300 = v1298.matches == 0;\n\tif (v1300) goto L_0178;\nL_0182:\n\tv1394.matches = v1356;\nL_FFFFFFFF:\n\tv586 = v749;\nL_FFFFFFFF:\n\tv590 = this;\n\tgoto L_0170;\nL_01E7:\n\tv726 = v1637.matches;\nL_01B0:\n\tgoto L_01B9;\nL_020F:\n\tv539 = v727.matches;\nL_020B:\n\tgoto L_020F;\nL_025E:\n\tv703 = v728.matches;\nL_0290:\n\tgoto L_0292;\nL_025A:\n\tgoto L_025E;\nL_0336:\n\tv1125.normals = v1072;\n\tgoto L_00CC;\nL_0351:\n\tv1185.vertices = v1144;\n\tgoto L_00F7;\nL_0148:\n\tgoto L_014C;\nL_0383:\n\tv1375 = v1374 < 8;\n\tv1376 = ~v1375;\n\tif (v1376) goto L_03BE;\nL_03CB:\n\tv543 = v1399 - v1491;\n\tv1525 = v984 + 0x50;\nL_FFFFFFFF:\n\tv1524 = v543;\nL_FFFFFFFF:\n\tv1524 = v138;\nL_FFFFFFFF:\n\tv1525 = v153;\nL_0116:\n\tv1236 = v1200.newNormals;\n\tv1203 = v1200.newNormals == 0;\n\tif (v1203) goto L_0136;\nL_03E9:\n\t*([v1525 @ X11_v18-30]) = v52;\n\t*([v1525 @ X11_v18-20]) = v53;\n\t*([v1525 @ X11_v18-10]) = v54;\n\t*([v1525 @ X11_v18]) = v52;\n\t*([v1525 @ X11_v18+10]) = v53;\n\t*([v1525 @ X11_v18+20]) = v54;\n\tv1525 = v1525 + 0x60;\n\tv1442 = v1524 - 8;\n\tv1447 = v1524 != 8;\nL_FFFFFFFF:\n\tv1524 = v1442;\n\tif (v1447) goto L_03E9;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void AverageNormals(int objIndex)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::AverageNormals");
		}

		[Token(Token = "0x6000078")]
		[Address(RVA = "0x7720930", Offset = "0x7720930", Length = "0x654")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0040;\n\tv86 = v69.Length <= objIndex;\n\tif (v86) goto L_0213;\n\tv397 = UnityEngine.Object::GetHashCode(v69[v162 @ X24_v4 (System.Int32)].mesh);\n\tgoto L_007C;\nL_007C:\n\tv571 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Mesh>::TryGetValue(v549.reorientedMeshes, v397, &v143 @ stack_-98_v5 (UnityEngine.Object));\n\tv575 = ~v571;\n\tif (v575) goto L_0097;\n\tgoto L_0089;\nL_0089:\n\tv592 = UnityEngine.Object::op_Equality(v143, 0);\n\tv604 = ~v592;\n\tv595 = ~v604;\n\tif (v595) goto L_0097;\n\tv142 = v143;\n\tv220 = this;\n\tgoto L_01E8;\nL_0097:\n\tv206 = UnityEngine.Mesh::get_isReadable(v69[v162 @ X24_v4 (System.Int32)].mesh);\n\tv210 = ~v206;\n\tif (v210) goto L_0213;\n\tgoto L_00A2;\n\tgoto L_00B0;\nL_00B0:\n\t;\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::Clear(v633);\n\tgoto L_00BA;\n\tgoto L_00C8;\nL_00C8:\n\t;\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::Clear(v686);\n\tgoto L_00D5;\n\tv211 = v215.Count == 0;\n\tif (v211) goto L_0213;\n\tgoto L_00F8;\n\tv448 = v755.zero.y;\n\tv444 = v755.zero.z;\n\tv758 = v755.zero;\n\tv474 = 0;\nL_0111:\n\tv803 = System.Collections.Generic.List`1<UnityEngine.Vector3>::get_Item(v550.vertices, v474);\n\tv804 = v758 + v803;\n\tv448 = v448 + v803.y;\n\tv444 = v444 + v803.z;\n\tv474 = v474 + 1;\n\tv810 = v215.Count != v474;\n\tv758 = v804;\n\tif (v810) goto L_0108;\n\tv422 = v804 / v215.Count;\n\tv420 = v448 / v215.Count;\n\tv418 = v444 / v215.Count;\n\tv472 = 0;\n\tgoto L_0145;\nL_0134:\n\t// 308 MakeStruct v762 @ AGG7720C8C_1_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v432 @ V0_v12 (System.Single), v428 @ V1_v11 (System.Single), v424 @ V2_v11 (System.Single)\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::Add(v413, v762);\n\tv472 = v472 + 1;\n\tv778 = v215.Count == v472;\n\tif (v778) goto L_01C0;\nL_0145:\n\tgoto L_014C;\nL_014C:\n\tv413 = v551.normals;\n\tv861 = System.Collections.Generic.List`1<UnityEngine.Vector3>::get_Item(v551.vertices, v472);\n\tgoto L_0162;\nL_0164:\n\tv879 = v861 - v422;\n\tv880 = v861.y - v420;\n\tv881 = v861.z - v418;\n\tv882 = v879 * v879;\n\tv883 = v880 * v880;\n\tv884 = v882 + v883;\n\tv885 = v881 * v881;\n\tv886 = v885 + v884;\n\tv410 = UnityEngine.Mathf::Sqrt(v886);\n\tgoto L_017A;\nL_017A:\n\tv432 = v879 / v410;\n\tv428 = v880 / v410;\n\tv424 = v881 / v410;\n\tgoto L_0195;\nL_0195:\n\t;\n\tgoto L_0134;\nL_01C0:\n\tgoto L_01C6;\nL_01C6:\n\tv534 = UnityEngine.Object::Instantiate(v69[v162 @ X24_v4 (System.Int32)].mesh);\n\tgoto L_01DA;\nL_01DA:\n\tUnityEngine.Mesh::SetNormals(v534, v843.normals);\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Mesh>::set_Item(v548.reorientedMeshes, v397, v534);\n\tv142 = v534;\n\tv220 = this;\nL_01E8:\n\tHighlightPlus.HighlightEffect::IncrementMeshUsage(v220, v142);\n\tv213 = v220.rms;\n\tv213[v161 @ X24_v6 (System.Int32)].mesh = v142;\nL_0213:\n\treturn;\nL_0217:\n\tv629 = new System.Collections.Generic.List`1<UnityEngine.Vector3>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::.ctor(v629);\n\tgoto L_0225;\nL_0232:\n\tv676 = new System.Collections.Generic.List`1<UnityEngine.Vector3>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::.ctor(v676);\n\tgoto L_0240;\nL_0040:\n\tv69 = this.rms;\n\tv70 = this.rms == 0;\n\tif (v70) goto L_0213;\nL_00A2:\n\tv633 = v613.normals;\n\tv615 = v613.normals == 0;\n\tif (v615) goto L_0217;\nL_00BA:\n\tv686 = v662.vertices;\n\tv664 = v662.vertices == 0;\n\tif (v664) goto L_0232;\nL_00D5:\n\tUnityEngine.Mesh::GetVertices(v69[v162 @ X24_v4 (System.Int32)].mesh, v714.vertices);\n\tv215 = v720.vertices;\nL_00F8:\n\tv750 = v215.Count < 1;\n\tif (v750) goto L_01C0;\nL_0108:\n\tgoto L_0111;\nL_0162:\n\tgoto L_0164;\nL_0225:\n\tv680.normals = v629;\n\tgoto L_00BA;\nL_0240:\n\tv724.vertices = v676;\n\tgoto L_00D5;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void ReorientNormals(int objIndex)
		{
			ModelMaterials[] array = rms;
			if (rms == null || array.Length <= objIndex)
			{
				return;
			}
			int num = default(int);
			int hashCode = array[num].mesh.GetHashCode();
			UnityEngine.Object value;
			Mesh mesh;
			HighlightEffect highlightEffect;
			if (reorientedMeshes.TryGetValue(hashCode, out *(Mesh*)(&value)) && !(value == null))
			{
				mesh = (Mesh)value;
				highlightEffect = this;
			}
			else
			{
				if (!array[num].mesh.isReadable)
				{
					return;
				}
				List<Vector3> list = normals;
				if (normals != null)
				{
					list.Clear();
				}
				else
				{
					List<Vector3> list2 = new List<Vector3>();
					normals = list2;
				}
				List<Vector3> list3 = vertices;
				if (vertices != null)
				{
					list3.Clear();
				}
				else
				{
					List<Vector3> list4 = new List<Vector3>();
					vertices = list4;
				}
				array[num].mesh.GetVertices(vertices);
				List<Vector3> list5 = vertices;
				if (list5.Count == 0)
				{
					return;
				}
				if (list5.Count >= 1)
				{
					float num2 = Vector3.zero.y;
					float num3 = Vector3.zero.z;
					Vector3 zero = Vector3.zero;
					int num4 = 0;
					float num5;
					bool flag;
					do
					{
						Vector3 vector = vertices[num4];
						num5 = zero.x + vector.x;
						num2 += vector.y;
						num3 += vector.z;
						num4++;
						flag = list5.Count != num4;
						zero.x = num5;
					}
					while (flag);
					float num6 = num5 / (float)list5.Count;
					float num7 = num2 / (float)list5.Count;
					float num8 = num3 / (float)list5.Count;
					int num9 = 0;
					Vector3 item = default(Vector3);
					do
					{
						List<Vector3> list6 = normals;
						Vector3 vector2 = vertices[num9];
						float num10 = vector2.x - num6;
						float num11 = vector2.y - num7;
						float num12 = vector2.z - num8;
						float num13 = num10 * num10;
						float num14 = num11 * num11;
						float num15 = num13 + num14;
						float num16 = num12 * num12;
						float f = num16 + num15;
						float num17 = Mathf.Sqrt(f);
						float x = num10 / num17;
						float y = num11 / num17;
						float z = num12 / num17;
						item.x = x;
						item.y = y;
						item.z = z;
						list6.Add(item);
						num9++;
					}
					while (list5.Count != num9);
				}
				Mesh mesh2 = UnityEngine.Object.Instantiate(array[num].mesh);
				mesh2.SetNormals(normals);
				reorientedMeshes[hashCode] = mesh2;
				mesh = mesh2;
				highlightEffect = this;
			}
			highlightEffect.IncrementMeshUsage(mesh);
			ModelMaterials[] array2 = highlightEffect.rms;
			int num18 = default(int);
			array2[num18].mesh = mesh;
		}

		[Token(Token = "0x6000079")]
		[Address(RVA = "0x77219D4", Offset = "0x77219D4", Length = "0x664")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003E;\n\tgoto L_0047;\nL_0047:\n\tv535 = v342.combineInstances;\n\tv344 = v342.combineInstances == 0;\n\tif (v344) goto L_0069;\n\tgoto L_0054;\nL_0054:\n\tv558 = this.includedObjectsCount;\n\tv548 = this.includedObjectsCount != v535.Length;\n\tif (v548) goto L_006D;\n\tgoto L_007C;\nL_0069:\n\tv558 = this.includedObjectsCount;\nL_007C:\n\tthis.combinedMeshesHashId = 0x11;\n\tgoto L_009F;\n\tv249 = 0xB292000 + 0x5A0;\n\tv674 = v1023.identity;\n\tv712 = 0x20;\n\tv715 = -1;\n\tv717 = 0;\n\tv258 = 0;\n\tv722 = 0;\n\tv325 = 0;\n\tgoto L_00D3;\nL_00AD:\n\tv1071 = v1183 + v258;\n\tv1090 = v325 * 0x68;\n\tv1096 = v685 + v1090;\n\tv1066 = v1015.m00;\n\tv1086 = v1096 + 0x20;\n\tUnityEngine.CombineInstance::set_transform(v1086, &v1066 @ stack_-1C0_v7 (System.Single));\n\tv325 = v325 + 1;\n\tv258 = v1071;\nL_00D3:\n\tgoto L_00E5;\nL_00E5:\n\tv858 = v1055.combineInstances + v712;\n\tUnityEngine.CombineInstance::set_mesh(v858, 0);\n\tv897 = this.rms + v722;\n\tv859 = UnityEngine.Component::get_gameObject(*([v897 @ X8_v26+28]));\n\tv860 = UnityEngine.GameObject::get_activeSelf(v859);\n\tv1059 = ~v860;\n\tif (v1059) goto L_00C0;\n\tv1097 = this.rms + v722;\n\tv1103 = *([v1097 @ X8_v56+58]) & 1;\n\tv1104 = v1103 == 0;\n\tv1091 = ~v1104;\n\tif (v1091) goto L_00C0;\n\tv1107 = *([v249 @ X26_v8 (System.Int32)]);\n\tv1108 = *([v1107 @ X0_v62+E4]) == 0;\n\tif (v1108) goto L_012A;\n\tv1087 = UnityEngine.Object::op_Equality(*([v1097 @ X8_v56+38]), 0);\n\tv1137 = v1087 == 0;\n\tv1092 = ~v1137;\n\tif (v1092) goto L_00C0;\n\tgoto L_0133;\nL_012A:\n\tv1088 = UnityEngine.Object::op_Equality(*([v1097 @ X8_v56+38]), 0);\n\tv1154 = v1088 == 0;\n\tv1093 = ~v1154;\n\tif (v1093) goto L_00C0;\nL_0133:\n\tv1089 = UnityEngine.Mesh::get_isReadable(*([v1097 @ X8_v56+38]));\n\tv1094 = ~v1089;\n\tif (v1094) goto L_00C0;\n\tv1183 = UnityEngine.Mesh::get_vertexCount(*([v1097 @ X8_v56+38]));\n\tgoto L_0154;\nL_0154:\n\tv1218 = v325 * 0x68;\n\tv1219 = v1208.combineInstances + v1218;\n\tv862 = v1219 + 0x20;\n\tUnityEngine.CombineInstance::set_mesh(v862, *([v1097 @ X8_v56+38]));\n\tv901 = this.rms + v722;\n\tv864 = UnityEngine.Component::get_gameObject(*([v901 @ X8_v63+50]));\n\tv865 = UnityEngine.Object::GetInstanceID(v864);\n\tv1225 = v715 & 0x80000000;\n\tv1226 = v1225 == 0;\n\tv1227 = ~v1226;\n\tif (v1227) goto L_018F;\n\tv1235 = this.rms + v722;\n\tv1236 = v1235 + 0x38;\n\t*([v1236 @ X0_v87]) = 0;\n\tgoto L_0192;\nL_018F:\n\tv1232 = UnityEngine.Transform::get_worldToLocalMatrix(*([v897 @ X8_v26+28]));\n\tv674 = v1229;\n\tv715 = v717;\n\tv1255 = &v203 @ stack_-140;\n\tv1258 = UnityEngine.Transform::get_localToWorldMatrix(*([v897 @ X8_v26+28]));\n\tv203 = *([v1255 @ X8_v70]);\n\tv988 = v674;\n\tv963 = *([v1255 @ X8_v70]);\n\tv1015 = UnityEngine.Matrix4x4::op_Multiply(&v988 @ stack_-1C0_v6 (UnityEngine.Matrix4x4), &v963 @ stack_-200_v6);\n\tv1267 = v325 < v685.Length;\n\tv1007 = ~v1267;\n\tv991 = ~v1007;\n\tif (v991) goto L_00AD;\n\tgoto L_02B3;\nL_01F9:\n\tv267 = v325 < 2;\n\tif (v267) goto L_02B1;\n\tv728 = v325 != this.includedObjectsCount;\n\tif (v728) goto L_0213;\n\tgoto L_020C;\nL_020C:\n\tv1125 = v904.combinedMeshes == 0;\n\tv886 = ~v1125;\n\tif (v886) goto L_022D;\n\tgoto L_02B2;\nL_0213:\n\tgoto L_021A;\nL_022D:\n\tv1150 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Mesh>::TryGetValue(v904.combinedMeshes, this.combinedMeshesHashId, &v1149 @ stack_-B8_v5 (UnityEngine.Mesh));\n\tv1155 = ~v1150;\n\tif (v1155) goto L_0242;\n\tgoto L_023C;\nL_0242:\n\tv869 = new UnityEngine.Mesh();\n\tUnityEngine.Mesh::.ctor(v869);\n\tv729 = v258 < 0x10000;\n\tv916 = v869;\n\tif (v729) goto L_025E;\n\tUnityEngine.Mesh::set_indexFormat(v869, 1);\n\tv916 = v869;\nL_026A:\n\tUnityEngine.Mesh::CombineMeshes(v916, v1211.combineInstances, 1, 1);\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Mesh>::set_Item(v908.combinedMeshes, this.combinedMeshesHashId, v869);\nL_0278:\n\tHighlightPlus.HighlightEffect::IncrementMeshUsage(this, v869);\n\tv909 = this.rms;\n\tv909[v324 @ X20_v13 (System.Int32)].mesh = v869;\n\tv910 = this.rms;\n\tv910[v324 @ X20_v13 (System.Int32)].isCombined = 1;\nL_02B2:\n\tv918 = new System.NullReferenceException();\nL_02B3:\n\tthrow System.IndexOutOfRangeException;\nL_003E:\n\tv72 = this.includedObjectsCount < 2;\n\tif (v72) goto L_02B1;\nL_006D:\n\t// 109 NewArr v566 @ X0_v6 (UnityEngine.CombineInstance[]), typeof(UnityEngine.CombineInstance[]), v558 @ X1_v2 (System.Int32)\n\tgoto L_0077;\nL_0077:\n\tv933.combineInstances = v566;\nL_009F:\n\tv268 = this.includedObjectsCount < 1;\n\tif (v268) goto L_02B1;\nL_00C0:\n\tv717 = v717 + 1;\n\tv712 = v712 + 0x68;\n\tv722 = v722 + 0xD8;\n\tv1037 = v717 >= this.includedObjectsCount;\n\tif (v1037) goto L_01F9;\nL_0192:\n\tv849 = v865 - this.combinedMeshesHashId;\n\tv581 = this.combinedMeshesHashId << 5;\n\tv1244 = v849 + v581;\n\tthis.combinedMeshesHashId = v1244;\n\tgoto L_019E;\nL_02B1:\n\treturn;\nL_021A:\n\t;\n\tSystem.Array::Resize(&v1131.combineInstances (UnityEngine.CombineInstance[]), v325);\n\tgoto L_020C;\nL_023C:\n\tv1166 = UnityEngine.Object::op_Equality(v1149, 0);\n\tv1168 = ~v1166;\n\tif (v1168) goto L_0278;\nL_025E:\n\tgoto L_026A;\nL_019E:\n\tv685 = v903.combineInstances;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void CombineMeshes()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::CombineMeshes");
		}

		[Token(Token = "0x600007A")]
		[Address(RVA = "0x7722788", Offset = "0x7722788", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv63 = v47.Length < 1;\n\tif (v63) goto L_0086;\n\tv147 = this.rms + 0x58;\n\tv150 = 0;\n\tgoto L_0043;\nL_0034:\n\tv147 = v147 + 0xD8;\n\tv150 = v150 + 1;\n\tv92 = v150 >= v47.Length;\n\tif (v92) goto L_0086;\nL_0043:\n\tv205 = *([v147 @ X23_v5]) & 1;\n\tv206 = v205 == 0;\n\tv207 = ~v206;\n\tif (v207) goto L_0034;\n\tgoto L_0050;\nL_0050:\n\tv215 = UnityEngine.Object::op_Inequality(*([v147 @ X23_v5-20]), 0);\n\tv218 = ~v215;\n\tif (v218) goto L_0034;\n\tgoto L_005F;\nL_005F:\n\tv217 = UnityEngine.Mesh::get_isReadable(*([v147 @ X23_v5-20]));\n\tv233 = v217 == 0;\n\tv220 = ~v233;\n\tif (v220) goto L_0034;\n\tv236 = UnityEngine.Object::get_name(*([v147 @ X23_v5-8]));\n\treturnVal4 = System.String::Concat(\"The mesh of object \", v236, \" is not readable and can't be combined (check mesh's import settings).\");\n\treturn returnVal4;\nL_0086:\n\treturn 0;\nL_0093:\n\treturn \"No objects to combine.\";\nL_001F:\n\tv47 = this.rms;\n\tv48 = this.rms == 0;\n\tif (v48) goto L_0093;\n")]
		public string ValidateCombineMeshes()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::ValidateCombineMeshes");
			return default;
		}

		[Token(Token = "0x600007B")]
		[Address(RVA = "0x77225E4", Offset = "0x77225E4", Length = "0x1A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\nL_0015:\n\tgoto L_0018;\nL_0018:\n\tv55 = v53.sharedMeshUsage == 0;\n\tv56 = ~v55;\n\tif (v56) goto L_0041;\n\tgoto L_007F;\nL_0041:\n\tv78 = System.Collections.Generic.Dictionary`2<UnityEngine.Mesh, System.Collections.Generic.HashSet`1<HighlightPlus.HighlightEffect>>::TryGetValue(v53.sharedMeshUsage, mesh, &v76 @ stack_-38_v3 (System.Collections.Generic.HashSet`1<HighlightPlus.HighlightEffect>));\n\tv105 = ~v78;\n\tif (v105) goto L_0057;\n\tv127 = System.Collections.Generic.HashSet`1<HighlightPlus.HighlightEffect>::Add(v76, this);\n\treturn;\nL_0057:\n\tv91 = new System.Collections.Generic.HashSet`1<HighlightPlus.HighlightEffect>();\n\tSystem.Collections.Generic.HashSet`1<HighlightPlus.HighlightEffect>::.ctor(v91);\n\tv158 = System.Collections.Generic.HashSet`1<HighlightPlus.HighlightEffect>::Add(v91, this);\n\tgoto L_0076;\nL_0076:\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Mesh, System.Collections.Generic.HashSet`1<HighlightPlus.HighlightEffect>>::set_Item(v101.sharedMeshUsage, mesh, v91);\n\treturn;\nL_007F:\n\tthrow System.NullReferenceException;\n")]
		private void IncrementMeshUsage(Mesh mesh)
		{
			if (sharedMeshUsage != null)
			{
				if (sharedMeshUsage.TryGetValue(mesh, out var value))
				{
					bool flag = value.Add(this);
					return;
				}
				HashSet<HighlightEffect> hashSet = new HashSet<HighlightEffect>();
				bool flag2 = hashSet.Add(this);
				sharedMeshUsage[mesh] = hashSet;
				return;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x600007C")]
		[Address(RVA = "0x7722900", Offset = "0x7722900", Length = "0x614")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0045;\n\tv81 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Mesh>::get_Values(v72.combinedMeshes);\n\tv226 = v81 == 0;\n\tv201 = Il2CppMethodInfo;\n\tif (v226) goto L_018E;\n\tv265 = &v175 @ stack_-B0 (System.Int32);\n\tv266 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Mesh>+ValueCollection<System.Int32, UnityEngine.Mesh>::GetEnumerator(v81);\n\tv175 = v175.m_value;\n\tv135 = v175.m_value;\n\tv175 = 0;\n\tgoto L_0081;\nL_007B:\n\tgoto L_007E;\nL_007E:\n\tUnityEngine.Object::DestroyImmediate(*([v265 @ X8_v14+10]));\nL_0081:\n\tv308 = System.Collections.Generic.Dictionary`2<System.Int32, System.Object>+ValueCollection<System.Int32, System.Object>+Enumerator<System.Int32, System.Object>::MoveNext(&v135 @ stack_-80_v4);\n\tv316 = v308 == 0;\n\tif (v316) goto L_0098;\n\tgoto L_008F;\nL_008F:\n\tv298 = UnityEngine.Object::op_Inequality(*([v265 @ X8_v14+10]), 0);\n\tv301 = v298 == 0;\n\tif (v301) goto L_0081;\n\tgoto L_007B;\nL_0098:\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Object>+ValueCollection<System.Int32, System.Object>+Enumerator<System.Int32, System.Object>::Dispose(&v135 @ stack_-80_v4);\n\tgoto L_00A2;\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Mesh>::Clear(v241.combinedMeshes);\n\tv227 = v238.smoothMeshes == 0;\n\tv167 = &v135 @ stack_-80_v4;\n\tv175 = 0;\n\tv201 = Il2CppMethodInfo;\n\tif (v227) goto L_018E;\n\tv216 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Mesh>::get_Values(v238.smoothMeshes);\n\tv228 = v216 == 0;\n\tv167 = &v135 @ stack_-80_v4;\n\tv175 = 0;\n\tv201 = Il2CppMethodInfo;\n\tif (v228) goto L_018E;\n\tv453 = &v175 @ stack_-B0 (System.Int32);\n\tv454 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Mesh>+ValueCollection<System.Int32, UnityEngine.Mesh>::GetEnumerator(v216);\n\tv175 = v175.m_value;\n\tv135 = v175.m_value;\n\tv175 = 0;\n\tgoto L_00C9;\nL_00C3:\n\tgoto L_00C6;\nL_00C6:\n\tUnityEngine.Object::DestroyImmediate(*([v453 @ X8_v22+10]));\nL_00C9:\n\tv475 = System.Collections.Generic.Dictionary`2<System.Int32, System.Object>+ValueCollection<System.Int32, System.Object>+Enumerator<System.Int32, System.Object>::MoveNext(&v135 @ stack_-80_v4);\n\tv477 = v475 == 0;\n\tif (v477) goto L_00E0;\n\tgoto L_00D7;\nL_00D7:\n\tv465 = UnityEngine.Object::op_Inequality(*([v453 @ X8_v22+10]), 0);\n\tv468 = v465 == 0;\n\tif (v468) goto L_00C9;\n\tgoto L_00C3;\nL_00E0:\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Object>+ValueCollection<System.Int32, System.Object>+Enumerator<System.Int32, System.Object>::Dispose(&v135 @ stack_-80_v4);\n\tgoto L_00EA;\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Mesh>::Clear(v242.smoothMeshes);\n\tv229 = v239.reorientedMeshes == 0;\n\tv167 = &v135 @ stack_-80_v4;\n\tv175 = 0;\n\tv201 = Il2CppMethodInfo;\n\tif (v229) goto L_018E;\n\tv218 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Mesh>::get_Values(v239.reorientedMeshes);\n\tv230 = v218 == 0;\n\tv167 = &v135 @ stack_-80_v4;\n\tv175 = 0;\n\tv201 = Il2CppMethodInfo;\n\tif (v230) goto L_018E;\n\tv498 = &v175 @ stack_-B0 (System.Int32);\n\tv499 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Mesh>+ValueCollection<System.Int32, UnityEngine.Mesh>::GetEnumerator(v218);\n\tv175 = v175.m_value;\n\tv135 = v175.m_value;\n\tgoto L_0111;\nL_010B:\n\tgoto L_010E;\nL_010E:\n\tUnityEngine.Object::DestroyImmediate(*([v498 @ X8_v30+10]));\nL_0111:\n\tv520 = System.Collections.Generic.Dictionary`2<System.Int32, System.Object>+ValueCollection<System.Int32, System.Object>+Enumerator<System.Int32, System.Object>::MoveNext(&v135 @ stack_-80_v4);\n\tv522 = v520 == 0;\n\tif (v522) goto L_0128;\n\tgoto L_011F;\nL_011F:\n\tv510 = UnityEngine.Object::op_Inequality(*([v498 @ X8_v30+10]), 0);\n\tv513 = v510 == 0;\n\tif (v513) goto L_0111;\n\tgoto L_010B;\nL_0128:\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Object>+ValueCollection<System.Int32, System.Object>+Enumerator<System.Int32, System.Object>::Dispose(&v135 @ stack_-80_v4);\n\tgoto L_0132;\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Mesh>::Clear(v243.reorientedMeshes);\n\tv231 = v240.sharedMeshUsage == 0;\n\tv167 = &v135 @ stack_-80_v4;\n\tv175 = 0;\n\tv201 = Il2CppMethodInfo;\n\tif (v231) goto L_018E;\n\tv220 = System.Collections.Generic.Dictionary`2<UnityEngine.Mesh, System.Collections.Generic.HashSet`1<HighlightPlus.HighlightEffect>>::get_Keys(v240.sharedMeshUsage);\n\tv232 = v220 == 0;\n\tv167 = &v135 @ stack_-80_v4;\n\tv175 = 0;\n\tv201 = Il2CppMethodInfo;\n\tif (v232) goto L_018E;\n\tv547 = System.Collections.Generic.Dictionary`2<UnityEngine.Mesh, System.Collections.Generic.HashSet`1<HighlightPlus.HighlightEffect>>+KeyCollection<UnityEngine.Mesh, System.Collections.Generic.HashSet`1<HighlightPlus.HighlightEffect>>::GetEnumerator(v220);\n\tv355 = v547._dictionary;\n\tgoto L_0157;\nL_0151:\n\tgoto L_0154;\nL_0154:\n\tUnityEngine.Object::DestroyImmediate(v547._currentKey);\nL_0157:\n\tv564 = System.Collections.Generic.Dictionary`2<System.Object, System.Object>+KeyCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::MoveNext(&v355 @ stack_-98_v4 (System.Collections.Generic.Dictionary`2<UnityEngine.Mesh, System.Collections.Generic.HashSet`1<HighlightPlus.HighlightEffect>>));\n\tv363 = v564 == 0;\n\tif (v363) goto L_0170;\n\tgoto L_0165;\nL_0165:\n\tv554 = UnityEngine.Object::op_Inequality(v547._currentKey, 0);\n\tv557 = v554 == 0;\n\tif (v557) goto L_0157;\n\tgoto L_0151;\nL_0170:\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+KeyCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(&v355 @ stack_-98_v4 (System.Collections.Generic.Dictionary`2<UnityEngine.Mesh, System.Collections.Generic.HashSet`1<HighlightPlus.HighlightEffect>>));\n\tv167 = &v355 @ stack_-98_v4 (System.Collections.Generic.Dictionary`2<UnityEngine.Mesh, System.Collections.Generic.HashSet`1<HighlightPlus.HighlightEffect>>);\n\tv175 = 0;\n\tv201 = Il2CppMethodInfo;\nL_0175:\n\tgoto L_017A;\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Mesh, System.Collections.Generic.HashSet`1<HighlightPlus.HighlightEffect>>::Clear(v244.sharedMeshUsage);\n\treturn;\nL_018E:\n\tv250 = new System.NullReferenceException();\n\tgoto L_01A5;\nL_01A5:\n\tv277 = v201 != 1;\n\tif (v277) goto L_01B6;\n\tv286 = 0x8BF5BC4(v250, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv175 = *([v286 @ X0_v14]);\n\tv311 = 0x8BF5BF4(v286, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Object>+KeyCollection<System.Object, System.Object>+Enumerator<System.Object, System.Object>::Dispose(v167);\n\tv326 = *([v286 @ X0_v14]) == 0;\n\tv175 = *([v286 @ X0_v14]);\n\tv201 = Il2CppMethodInfo;\n\tif (v326) goto L_0175;\n\tgoto L_0205;\nL_0205:\n\tv379 = new System.OutOfMemoryException();\nL_020A:\n\tv331 = 0x8BF0368(v328, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv339 = 0xA1B8(v331, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0045:\n\tv355 = 0;\n\tgoto L_0051;\nL_00A2:\n\tv233 = v241.combinedMeshes == 0;\n\tv167 = &v135 @ stack_-80_v4;\n\tv175 = 0;\n\tv201 = Il2CppMethodInfo;\n\tif (v233) goto L_018E;\nL_00EA:\n\tv234 = v242.smoothMeshes == 0;\n\tv167 = &v135 @ stack_-80_v4;\n\tv175 = 0;\n\tv201 = Il2CppMethodInfo;\n\tif (v234) goto L_018E;\nL_0132:\n\tv235 = v243.reorientedMeshes == 0;\n\tv167 = &v135 @ stack_-80_v4;\n\tv175 = 0;\n\tv201 = Il2CppMethodInfo;\n\tif (v235) goto L_018E;\nL_017A:\n\tv236 = v244.sharedMeshUsage == 0;\n\tif (v236) goto L_018E;\nL_01B6:\n\tv288 = 0x359AAC0(&v175 @ stack_-B0 (System.Int32), clobbered_X1, clobbered_X2, clobbe\n// ... truncated")]
		public unsafe static void ClearMeshCache()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::ClearMeshCache");
		}

		[Token(Token = "0x600007D")]
		[Address(RVA = "0x7714258", Offset = "0x7714258", Length = "0x278")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tgoto L_001B;\nL_001B:\n\tv62 = v60.combinedMeshes == 0;\n\tv63 = ~v62;\n\tif (v63) goto L_0043;\n\tgoto L_00D1;\nL_0043:\n\tv87 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Mesh>::TryGetValue(v60.combinedMeshes, this.combinedMeshesHashId, &v86 @ stack_-58_v3 (UnityEngine.Object));\n\tv164 = ~v87;\n\tif (v164) goto L_006C;\n\tgoto L_004D;\nL_004D:\n\tUnityEngine.Object::DestroyImmediate(v86);\n\tgoto L_0054;\nL_0054:\n\tv280 = v155.combinedMeshes == 0;\n\tv149 = ~v280;\n\tif (v149) goto L_006B;\n\tgoto L_00D1;\nL_006B:\n\tv176 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Mesh>::Remove(v155.combinedMeshes, this.combinedMeshesHashId);\nL_006C:\n\tv252 = this.rms;\n\tv183 = this.rms == 0;\n\tif (v183) goto L_00D0;\n\tv124 = 0x38;\n\tv272 = -1;\n\tgoto L_0080;\nL_0077:\n\tgoto L_007A;\nL_007A:\n\tUnityEngine.Object::DestroyImmediate(*([v252 @ X8_v9 (ModelMaterials[])+v124 @ X25_v5 (System.Int32)]));\nL_007B:\n\tv124 = v124 + 0xD8;\n\tv252 = this.rms;\nL_0080:\n\tv272 = v272 + 1;\n\tv94 = v272 >= v252.Length;\n\tif (v94) goto L_00D0;\n\tgoto L_0094;\nL_0094:\n\tv297 = UnityEngine.Object::op_Inequality(*([v252 @ X8_v9 (ModelMaterials[])+v124 @ X25_v5 (System.Int32)]), 0);\n\tv299 = ~v297;\n\tif (v299) goto L_007B;\n\tgoto L_00A3;\nL_00A3:\n\tgoto L_00AC;\nL_00AC:\n\tv325 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Mesh>::ContainsValue(v158.smoothMeshes, *([v252 @ X8_v9 (ModelMaterials[])+v124 @ X25_v5 (System.Int32)]));\n\tv327 = v325 == 0;\n\tv328 = ~v327;\n\tif (v328) goto L_0077;\n\tgoto L_00BE;\nL_00BE:\n\tv309 = System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Mesh>::ContainsValue(v159.reorientedMeshes, *([v252 @ X8_v9 (ModelMaterials[])+v124 @ X25_v5 (System.Int32)]));\n\tv343 = ~v309;\n\tv313 = ~v343;\n\tif (v313) goto L_0077;\n\tgoto L_007B;\nL_00D0:\n\treturn;\nL_00D1:\n\tthrow System.NullReferenceException;\n")]
		private unsafe void RefreshCachedMeshes()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::RefreshCachedMeshes");
		}

		[Token(Token = "0x600007E")]
		[Address(RVA = "0x77145BC", Offset = "0x77145BC", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0010;\nL_0010:\n\tgoto L_0014;\nL_0014:\n\tv46 = v43.useUnscaledTime == 0;\n\tif (v46) goto L_0036;\n\treturnVal1 = UnityEngine.Time::get_unscaledTime();\n\treturn returnVal1;\nL_0036:\n\treturnVal2 = UnityEngine.Time::get_time();\n\treturn returnVal2;\n")]
		public static float GetTime()
		{
			if (useUnscaledTime)
			{
				return Time.unscaledTime;
			}
			return Time.time;
		}

		[Token(Token = "0x600007F")]
		[Address(RVA = "0x772026C", Offset = "0x772026C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t// 6 MakeStruct v7 @ AGG7720284_1_v1 (UnityEngine.Color), typeof(UnityEngine.Color), this.hitFxColor (UnityEngine.Color), this.hitFxColor.g (System.Single), this.hitFxColor.b (System.Single), this.hitFxColor.a (System.Single)\n\tHighlightPlus.HighlightEffect::HitFX(this, v7, this.hitFxFadeOutDuration, this.hitFxInitialIntensity);\n\treturn;\n")]
		public void HitFX()
		{
			Color color = default(Color);
			color.r = hitFxColor.r;
			color.g = hitFxColor.g;
			color.b = hitFxColor.b;
			color.a = hitFxColor.a;
			HitFX(color, hitFxFadeOutDuration, hitFxInitialIntensity);
		}

		[Token(Token = "0x6000080")]
		[Address(RVA = "0x7723080", Offset = "0x7723080", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t// 20 MakeStruct v24 @ AGG77230BC_1_v1 (UnityEngine.Color), typeof(UnityEngine.Color), this.hitFxColor (UnityEngine.Color), this.hitFxColor.g (System.Single), this.hitFxColor.b (System.Single), this.hitFxColor.a (System.Single)\n\tHighlightPlus.HighlightEffect::HitFX(this, v24, this.hitFxFadeOutDuration, this.hitFxInitialIntensity, position, this.hitFxRadius);\n\treturn;\n")]
		public void HitFX(Vector3 position)
		{
			Color color = default(Color);
			color.r = hitFxColor.r;
			color.g = hitFxColor.g;
			color.b = hitFxColor.b;
			color.a = hitFxColor.a;
			HitFX(color, hitFxFadeOutDuration, hitFxInitialIntensity, position, hitFxRadius);
		}

		[Token(Token = "0x6000081")]
		[Address(RVA = "0x7722F14", Offset = "0x7722F14", Length = "0x16C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\nL_0033:\n\tgoto L_0037;\nL_0037:\n\tgoto L_003B;\nL_003B:\n\tv99 = v96.useUnscaledTime == 0;\n\tif (v99) goto L_0072;\n\tv115 = UnityEngine.Time::get_unscaledTime();\n\tthis.hitStartTime = v115;\n\tthis.hitActive = 1;\n\tv128 = this.overlay == 0;\n\tif (v128) goto L_008E;\nL_0057:\n\treturn;\nL_0072:\n\tv121 = UnityEngine.Time::get_time();\n\tthis.hitStartTime = v121;\n\tthis.hitActive = 1;\n\tv136 = this.overlay == 0;\n\tv141 = ~v136;\n\tif (v141) goto L_0057;\nL_008E:\n\tHighlightPlus.HighlightEffect::UpdateMaterialProperties(this, 0);\n\treturn;\nL_0025:\n\tthis.hitInitialIntensity = initialIntensity;\n\tthis.hitFadeOutDuration = fadeOutDuration;\n\tthis.hitColor.r = color;\n\tthis.hitColor.g = color.g;\n\tthis.hitColor.b = color.b;\n\tthis.hitColor.a = color.a;\n\tgoto L_0033;\n")]
		public void HitFX(Color color, float fadeOutDuration, float initialIntensity = 1f)
		{
			hitInitialIntensity = initialIntensity;
			hitFadeOutDuration = fadeOutDuration;
			hitColor.r = color.r;
			hitColor.g = color.g;
			hitColor.b = color.b;
			hitColor.a = color.a;
			if (useUnscaledTime)
			{
				float unscaledTime = Time.unscaledTime;
				hitStartTime = unscaledTime;
				hitActive = true;
				if (overlay != 0f)
				{
					return;
				}
			}
			else
			{
				float time = Time.time;
				hitStartTime = time;
				hitActive = true;
				if (overlay != 0f)
				{
					return;
				}
			}
			UpdateMaterialProperties();
		}

		[Token(Token = "0x6000082")]
		[Address(RVA = "0x77230CC", Offset = "0x77230CC", Length = "0x198")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\nL_003B:\n\tgoto L_003F;\nL_003F:\n\tgoto L_0043;\nL_0043:\n\tv113 = v110.useUnscaledTime == 0;\n\tif (v113) goto L_0062;\n\tv143 = UnityEngine.Time::get_unscaledTime();\n\tgoto L_0063;\nL_0062:\n\tv143 = UnityEngine.Time::get_time();\nL_0063:\n\tthis.hitStartTime = v143;\n\tthis.hitActive = 1;\n\tthis.hitPosition.x = position;\n\tthis.hitPosition.y = v47;\n\tthis.hitPosition.z = v53;\n\tthis.hitRadius = radius;\n\tv149 = this.overlay == 0;\n\tv154 = ~v149;\n\tif (v154) goto L_0097;\n\tHighlightPlus.HighlightEffect::UpdateMaterialProperties(this, 0);\n\treturn;\nL_0097:\n\treturn;\nL_002D:\n\tthis.hitInitialIntensity = initialIntensity;\n\tthis.hitFadeOutDuration = fadeOutDuration;\n\tthis.hitColor.r = color;\n\tthis.hitColor.g = color.g;\n\tthis.hitColor.b = color.b;\n\tthis.hitColor.a = color.a;\n\tgoto L_003B;\n")]
		public void HitFX(Color color, float fadeOutDuration, float initialIntensity, Vector3 position, float radius)
		{
			hitInitialIntensity = initialIntensity;
			hitFadeOutDuration = fadeOutDuration;
			hitColor.r = color.r;
			hitColor.g = color.g;
			hitColor.b = color.b;
			hitColor.a = color.a;
			float num = ((!useUnscaledTime) ? Time.time : Time.unscaledTime);
			hitStartTime = num;
			hitActive = true;
			hitPosition.x = position.x;
			float y = default(float);
			hitPosition.y = y;
			float z = default(float);
			hitPosition.z = z;
			hitRadius = radius;
			if (overlay == 0f)
			{
				UpdateMaterialProperties();
			}
		}

		[Token(Token = "0x6000083")]
		[Address(RVA = "0x7723264", Offset = "0x7723264", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0018;\nL_0018:\n\tgoto L_001C;\nL_001C:\n\tgoto L_0020;\nL_0020:\n\tv88 = v85.useUnscaledTime == 0;\n\tif (v88) goto L_004E;\n\tv104 = UnityEngine.Time::get_unscaledTime();\n\tthis.targetFXStartTime = v104;\n\tv116 = this.highlighted == 0;\n\tif (v116) goto L_0057;\n\tgoto L_005A;\nL_004E:\n\tv110 = UnityEngine.Time::get_time();\n\tthis.targetFXStartTime = v110;\n\tv119 = this.highlighted == 0;\n\tv120 = ~v119;\n\tif (v120) goto L_005A;\nL_0057:\n\tHighlightPlus.HighlightEffect::SetHighlighted(this, 1);\nL_005A:\n\tv136 = this.targetFX == 0;\n\tif (v136) goto L_0065;\n\treturn;\nL_0065:\n\tthis.targetFX = 1;\n\tHighlightPlus.HighlightEffect::UpdateMaterialProperties(this, 0);\n\treturn;\n")]
		public void TargetFX()
		{
			if (useUnscaledTime)
			{
				float unscaledTime = Time.unscaledTime;
				targetFXStartTime = unscaledTime;
				if (!highlighted)
				{
					goto IL_00a6;
				}
			}
			else
			{
				float time = Time.time;
				targetFXStartTime = time;
				if (!highlighted)
				{
					goto IL_00a6;
				}
			}
			goto IL_00b6;
			IL_00b6:
			if (!targetFX)
			{
				targetFX = true;
				UpdateMaterialProperties();
			}
			return;
			IL_00a6:
			SetHighlighted(state: true);
			goto IL_00b6;
		}

		[Token(Token = "0x6000084")]
		[Address(RVA = "0x7723390", Offset = "0x7723390", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0018;\nL_0018:\n\tgoto L_001C;\nL_001C:\n\tgoto L_0020;\nL_0020:\n\tv88 = v85.useUnscaledTime == 0;\n\tif (v88) goto L_004E;\n\tv104 = UnityEngine.Time::get_unscaledTime();\n\tthis.iconFXStartTime = v104;\n\tv116 = this.highlighted == 0;\n\tif (v116) goto L_0057;\n\tgoto L_005A;\nL_004E:\n\tv110 = UnityEngine.Time::get_time();\n\tthis.iconFXStartTime = v110;\n\tv119 = this.highlighted == 0;\n\tv120 = ~v119;\n\tif (v120) goto L_005A;\nL_0057:\n\tHighlightPlus.HighlightEffect::SetHighlighted(this, 1);\nL_005A:\n\tv136 = this.iconFX == 0;\n\tif (v136) goto L_0065;\n\treturn;\nL_0065:\n\tthis.iconFX = 1;\n\tHighlightPlus.HighlightEffect::UpdateMaterialProperties(this, 0);\n\treturn;\n")]
		public void IconFX()
		{
			if (useUnscaledTime)
			{
				float unscaledTime = Time.unscaledTime;
				iconFXStartTime = unscaledTime;
				if (!highlighted)
				{
					goto IL_00a6;
				}
			}
			else
			{
				float time = Time.time;
				iconFXStartTime = time;
				if (!highlighted)
				{
					goto IL_00a6;
				}
			}
			goto IL_00b6;
			IL_00b6:
			if (!iconFX)
			{
				iconFX = true;
				UpdateMaterialProperties();
			}
			return;
			IL_00a6:
			SetHighlighted(state: true);
			goto IL_00b6;
		}

		[Token(Token = "0x6000085")]
		[Address(RVA = "0x7713968", Offset = "0x7713968", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = this.label == 0;\n\tif (v13) goto L_000E;\n\tv17 = HighlightPlus.HighlightLabel::Release(this.label);\nL_000E:\n\tthis.label = 0;\n\treturn;\n")]
		private void ReleaseLabel()
		{
			if ((object)label != null)
			{
				label.Release();
			}
			label = null;
		}

		[Token(Token = "0x6000086")]
		[Address(RVA = "0x770CF84", Offset = "0x770CF84", Length = "0x3C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv57 = this.labelMode == 0;\n\tv58 = ~v57;\n\tif (v58) goto L_003B;\n\tv93 = this.highlighted == 0;\n\tv82 = ~v93;\n\tif (v82) goto L_004C;\nL_003B:\n\tv60 = this.labelShowInEditorMode != 1;\n\tif (v60) goto L_009A;\n\tgoto L_0046;\nL_0046:\n\tv79 = UnityEngine.Application::get_isPlaying();\n\tv176 = v79 == 0;\n\tv81 = ~v176;\n\tif (v81) goto L_009A;\nL_004C:\n\tv87 = disabling == 0;\n\tv88 = ~v87;\n\tif (v88) goto L_009A;\n\tv99 = this.includedObjectsCount == 0;\n\tif (v99) goto L_009A;\n\tv101 = this.labelEnabled != 1;\n\tif (v101) goto L_009A;\n\tgoto L_006B;\nL_006B:\n\tv183 = UnityEngine.Object::op_Equality(this.label, 0);\n\tv190 = ~v183;\n\tif (v190) goto L_008F;\n\tgoto L_0078;\nL_0078:\n\tv334 = UnityEngine.Object::op_Inequality(this.labelPrefab, 0);\n\tv337 = ~v334;\n\tif (v337) goto L_008F;\n\tgoto L_0086;\nL_0086:\n\tv420 = HighlightPlus.HighlightLabelPoolManager::GetLabelInstance(this.labelPrefab);\n\tthis.label = v420;\nL_008F:\n\tgoto L_0093;\nL_0093:\n\tv359 = UnityEngine.Object::op_Inequality(this.label, 0);\n\tv408 = ~v359;\n\tv362 = ~v408;\n\tif (v362) goto L_00E2;\n\tgoto L_011E;\nL_009A:\n\tv124 = this.label;\n\tv126 = this.labelEnabled == 0;\n\tif (v126) goto L_00AB;\n\tgoto L_00A6;\nL_00A6:\n\tv153 = UnityEngine.Object::op_Inequality(this.label, 0);\n\tv184 = ~v153;\n\tv185 = ~v184;\n\tif (v185) goto L_00D3;\n\tgoto L_011E;\nL_00AB:\n\tv140 = this.label == 0;\n\tif (v140) goto L_00B1;\n\tv157 = *([v124 @ X0_v6 (UnityEngine.Object)]);\n\t*([v157 @ X8_v9 (Il2CppClass<UnityEngine.Object>)+268])(v160, this.label, *([v157 @ X8_v9 (Il2CppClass<UnityEngine.Object>)+270]), methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00D3:\n\tv197 = HighlightPlus.HighlightLabel::Hide(v197);\nL_00D3:\n\treturn;\nL_00E2:\n\tv421 = HighlightPlus.HighlightLabel::set_textLabel(this.label, this.labelText);\nL_FFFFFFFF:\n\t// -1 MakeStruct Color_arg @ V0_v3 (UnityEngine.Color), typeof(UnityEngine.Color), this.labelColor (UnityEngine.Color), this.labelColor.g (System.Single), this.labelColor.b (System.Single), this.labelColor.a (System.Single)\n\tv423 = HighlightPlus.HighlightLabel::set_textColor(this.label, Color_arg);\n\tv424 = HighlightPlus.HighlightLabel::set_textSize(this.label, this.labelTextSize);\n\tv425 = HighlightPlus.HighlightLabel::set_width(this.label, this.labelLineLength);\n\tv389 = this.label;\n\tv389.labelAlignmentTransform = this.labelAlignmentTransform;\n\tv389.labelAlignment = this.labelAlignment;\n\tv389.labelRelativeAlignment = this.labelRelativeAlignment;\n\tv368 = this.label;\n\tv368.labelMaxDistance = this.labelMaxDistance;\n\tv368.labelScaleByDistance = this.labelScaleByDistance;\n\tv368.labelScaleMin = this.labelScaleMin;\n\tv361 = v368.isVisible == 0;\n\tif (v361) goto L_0124;\nL_011E:\n\treturn;\nL_0124:\n\tgoto L_0129;\nL_0129:\n\tv442 = UnityEngine.Object::op_Equality(this.labelTarget, 0);\n\tv276 = v442 == 0;\n\tv256 = ~v276;\n\tv213 = ~v256;\n\tif (v213) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv448 = 0x478;\n\tgoto L_0143;\nL_FFFFFFFF:\n\tv448 = 0x370;\n\tv292 = HighlightPlus.HighlightLabel::Show(v292);\n\treturn;\nL_0023:\n\tv49 = this.labelMode == 0xA;\n\tif (v49) goto L_004C;\nL_00B1:\n\tthis.label = 0;\n\treturn;\nL_0143:\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\t// -1 MakeStruct Vector3_arg @ V0_v8 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v457.vector3Zero (UnityEngine.Vector3), v457.vector3Zero.y (System.Single), v457.vector3Zero.z (System.Single)\nL_FFFFFFFF:\n\t// -1 MakeStruct Vector3_arg @ V3_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, this.labelVerticalOffset (System.Single), 0\nL_FFFFFFFF:\n\t// -1 MakeStruct Vector2_arg @ V6_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), this.labelViewportOffset (UnityEngine.Vector2), this.labelViewportOffset.y (System.Single)\n\tv459 = HighlightPlus.HighlightLabel::SetPosition(v368, *([this @ X0 (HighlightPlus.HighlightEffect)+v448 @ X8_v31 (System.Int32)]), Vector3_arg, Vector3_arg, Vector2_arg);\n")]
		private void CheckLabel(bool disabling)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::CheckLabel");
		}

		[Token(Token = "0x6000087")]
		[Address(RVA = "0x77234BC", Offset = "0x77234BC", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv82 = this.labelFollowCursor != 1;\n\tif (v82) goto L_0066;\n\tgoto L_0047;\nL_0047:\n\tv113 = UnityEngine.Object::op_Inequality(this.label, 0);\n\tv197 = ~v113;\n\tv117 = ~v197;\n\tif (v117) goto L_FFFFFFFF;\n\tgoto L_0066;\nL_FFFFFFFF:\n\t// -1 MakeStruct Vector2_arg @ V6_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), 0, 0\n\tv112 = HighlightPlus.HighlightLabel::SetPosition(this.label, target, Vector3_arg, Vector3_arg, Vector2_arg);\nL_002F:\n\tv71 = this.labelEnabled != 1;\n\tif (v71) goto L_0066;\nL_0066:\n\tthis.currentHitTarget = target;\n\tthis.currentHitLocalPosition.x = Vector3_arg;\n\tthis.currentHitLocalPosition.y = Vector3_arg.y;\n\tthis.currentHitLocalPosition.z = Vector3_arg.z;\n\tthis.currentHitNormal.x = normalWS;\n\tthis.currentHitNormal.y = v133;\n\tthis.currentHitNormal.z = v135;\n\treturn;\n")]
		public void SetHitPosition(Transform target, Vector3 localPosition, Vector3 offsetWS, Vector3 normalWS)
		{
			Vector3 localPosition2 = default(Vector3);
			if (labelEnabled && labelFollowCursor && label != null)
			{
				Vector2 viewportOffset = default(Vector2);
				viewportOffset.x = 0f;
				viewportOffset.y = 0f;
				Vector3 worldOffset = default(Vector3);
				label.SetPosition(target, localPosition2, worldOffset, viewportOffset);
			}
			currentHitTarget = target;
			currentHitLocalPosition.x = localPosition2.x;
			currentHitLocalPosition.y = localPosition2.y;
			currentHitLocalPosition.z = localPosition2.z;
			currentHitNormal.x = normalWS.x;
			float y = default(float);
			currentHitNormal.y = y;
			float z = default(float);
			currentHitNormal.z = z;
		}

		[Token(Token = "0x6000088")]
		[Address(RVA = "0x7723604", Offset = "0x7723604", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\nL_001D:\n\tHighlightPlus.HighlightLabelPoolManager::DestroySceneLabels();\n\tHighlightPlus.HighlightEffect::CheckLabel(this, 0);\n\treturn;\nL_001A:\n\tgoto L_001D;\n")]
		public void RefreshLabel()
		{
			HighlightLabelPoolManager.DestroySceneLabels();
			CheckLabel(disabling: false);
		}

		[Token(Token = "0x6000089")]
		[Address(RVA = "0x7723670", Offset = "0x7723670", Length = "0x6A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0032;\nL_FFFFFFFF:\n\tv167 = 0;\nL_FFFFFFFF:\n\tv171 = 0;\nL_FFFFFFFF:\n\tv172 = 0x50;\nL_FFFFFFFF:\n\tv175 = 0;\nL_FFFFFFFF:\n\tv177 = 0;\nL_FFFFFFFF:\n\tv178 = 0;\n\tgoto L_0054;\nL_0045:\n\tv178 = v178 + 1;\n\tv184 = this.rms;\n\tv172 = v172 + 0xD8;\nL_0054:\n\tv198 = v178 >= v184.Length;\n\tif (v198) goto L_0114;\n\tgoto L_005E;\nL_005E:\n\tv536 = UnityEngine.Object::op_Inequality(*([v184 @ X8_v5 (ModelMaterials[])+v172 @ X26_v4 (System.Int32)]), 0);\n\tv696 = ~v536;\n\tif (v696) goto L_0045;\n\tgoto L_0069;\nL_0069:\n\tv640 = v171 + v171;\n\tv677 = this.rms;\n\tv612 = v640 == 0;\n\tv593 = ~v612;\n\tif (v593) goto L_00A4;\n\tv741 = UnityEngine.Renderer::get_bounds(*([v677 @ X8_v72 (ModelMaterials[])+v172 @ X26_v4 (System.Int32)]));\nL_FFFFFFFF:\n\tv167 = v741.m_Center.y;\nL_FFFFFFFF:\n\tv171 = v741.extents;\nL_FFFFFFFF:\n\tv175 = v741.center;\nL_FFFFFFFF:\n\tv177 = v741.m_Extents.y;\n\tgoto L_0045;\nL_00A4:\n\tv742 = UnityEngine.Renderer::get_bounds(*([v677 @ X8_v72 (ModelMaterials[])+v172 @ X26_v4 (System.Int32)]));\n\tv899 = v742.center - v742.extents;\n\tv841 = v175 - v171;\n\tv806 = v167 - v177;\n\tv807 = v841 < v899;\n\tv815 = ~v807;\n\tif (v815) goto L_FFFFFFFF;\n\tgoto L_00BF;\nL_FFFFFFFF:\n\tv841 = v899;\nL_FFFFFFFF:\n\tv899 = v703;\n\tgoto L_00D2;\n\tgoto L_00E5;\nL_FFFFFFFF:\n\tv709 = v964;\nL_FFFFFFFF:\n\tv964 = v927;\n\tgoto L_00F7;\nL_0114:\n\tv540 = UnityEngine.Component::get_transform(cam);\n\tv641 = UnityEngine.Transform::get_position(v540);\n\tgoto L_0128;\nL_0128:\n\tgoto L_012C;\nL_012C:\n\tgoto L_012E;\nL_012E:\n\tv830 = v783.hits;\n\tv785 = v783.hits == 0;\n\tv786 = ~v785;\n\tif (v786) goto L_014E;\n\tgoto L_0165;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tgoto L_02A1;\nL_014E:\n\tgoto L_0156;\nL_0156:\n\tv820 = v830.Length == 0;\n\tif (v820) goto L_0165;\n\tgoto L_015C;\nL_015C:\n\tv878 = v866.occluders;\n\tv867 = v866.occluders == 0;\n\tv670 = ~v867;\n\tif (v670) goto L_0180;\n\tgoto L_02A2;\nL_0165:\n\t// 357 NewArr v827 @ X0_v58 (UnityEngine.RaycastHit[]), typeof(UnityEngine.RaycastHit[]), 64\n\tgoto L_016F;\nL_0180:\n\tv883 = v175 - v641;\n\tv1020 = v167 - v641.y;\n\tv885 = v882 - v641.z;\n\tv888 = v883 * v883;\n\tv889 = v1020 * v1020;\n\tv890 = v888 + v889;\n\tv891 = v885 * v885;\n\tv892 = v891 + v890;\n\tgoto L_0198;\nL_01AE:\n\tgoto L_01B1;\nL_01B1:\n\tv1049 = v883 / v237;\n\tgoto L_01C8;\n\tv284 = v878.Count < 1;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tif (v284) goto L_02A1;\nL_FFFFFFFF:\n\tv345 = 0;\nL_024C:\n\tv1101 = v345 * 0x2C;\n\tv681 = v1099.hits + v1101;\n\tv1102 = v681 + 0x20;\n\tv659 = UnityEngine.RaycastHit::get_collider(v1102);\n\tv1103 = UnityEngine.Component::get_transform(v659);\n\tv661 = System.Collections.Generic.List`1<HighlightPlus.HighlightSeeThroughOccluder>::get_Item(v682.occluders, v370);\n\tv1106 = UnityEngine.Component::get_transform(v661);\n\tgoto L_026C;\nL_026C:\n\tv1090 = UnityEngine.Object::op_Equality(v1103, v1106);\n\tv1114 = v1090 == 0;\n\tv358 = ~v1114;\n\tif (v358) goto L_FFFFFFFF;\n\tv370 = v370 + 1;\n\tv1080 = v878.Count != v370;\n\tif (v1080) goto L_023A;\n\tv345 = v345 + 1;\n\tv285 = v345 != v1054;\n\tif (v285) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tgoto L_02A1;\nL_FFFFFFFF:\n\treturnVal1 = 1;\nL_02A2:\n\tv693 = new System.NullReferenceException();\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\nL_0032:\n\tv184 = this.rms;\n\tv73 = this.rms == 0;\n\tif (v73) goto L_FFFFFFFF;\nL_00BF:\n\tv703 = v171 + v175;\n\tv842 = v703 < v899;\n\tv843 = v703 == v899;\n\tv846 = v703 == v703;\n\tv847 = v899 == v899;\n\tv848 = v846 & v847;\n\tv849 = ~v848;\n\tv850 = v842 == v849;\n\tv851 = ~v843;\n\tv852 = v850 & v851;\n\tv853 = ~v852;\n\tif (v853) goto L_00D2;\nL_00D2:\n\tv900 = v899 - v841;\n\tv901 = v900 * 0.5f;\n\tv902 = v841 + v901;\n\tv964 = v742.center + v742.extents;\n\tv709 = v902 - v901;\n\tv905 = v709 < v964;\n\tv913 = ~v905;\n\tif (v913) goto L_FFFFFFFF;\nL_00E5:\n\tv927 = v901 + v902;\n\tv728 = v927 < v964;\n\tv727 = v927 == v964;\n\tv929 = v927 == v927;\n\tv726 = v964 == v964;\n\tv729 = v929 & v726;\n\tv725 = ~v729;\n\tv930 = v728 == v725;\n\tv702 = ~v727;\n\tv724 = v930 & v702;\n\tv704 = ~v724;\n\tif (v704) goto L_00F7;\nL_00F7:\n\tv965 = v964 - v709;\n\tv736 = v965 * 0.5f;\n\tv968 = v742.m_Center.y - v742.m_Extents.y;\n\t// 252 NotImplemented \"Instruction FCMGT not yet implemented.\"\n\t// 253 NotImplemented \"Instruction BIF not yet implemented.\"\n\t// 254 NotImplemented \"Instruction FCMGT not yet implemented.\"\n\t// 255 NotImplemented \"Instruction BIT not yet implemented.\"\n\tv969 = v968 - v806;\n\tv970 = v969 * 0x3F;\n\tv705 = v806 + v970;\n\tv971 = v742.m_Center.y + v742.m_Extents.y;\n\tv708 = v705 - v970;\n\t// 261 NotImplemented \"Instruction FCMGT not yet implemented.\"\n\t// 262 NotImplemented \"Instruction BIF not yet implemented.\"\n\t// 264 NotImplemented \"Instruction FCMGT not yet implemented.\"\n\t// 265 NotImplemented \"Instruction BIT not yet implemented.\"\n\tv972 = v971 - v708;\n\tv177 = v972 * 0x3F;\n\tv738 = v709 + v736;\n\tv734 = v708 + v177;\nL_FFFFFFFF:\n\tv167 = v734;\nL_FFFFFFFF:\n\tv171 = v736;\nL_FFFFFFFF:\n\tv175 = v738;\n\tgoto L_0045;\nL_02A1:\n\treturn returnVal1;\nL_016F:\n\tv857.hits = v827;\n\tgoto L_015C;\nL_0198:\n\tv237 = UnityEngine.Mathf::Sqrt(v892);\n\tgoto L_01AE;\nL_01C8:\n\t// 456 NotImplemented \"Instruction DUP not yet implemented.\"\n\tgoto L_01E4;\nL_0213:\n\t// 531 MakeStruct v203 @ AGG7723BE4_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v263 @ V6_v6 (System.Single), v337 @ V9_v9 (System.Single), v258 @ V10_v7 (System.Single)\n\t// 532 MakeStruct v200 @ AGG7723BE4_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v335 @ V11_v7 (System.Int32), v261 @ V4_v6 (System.Single), v1052 @ V4.S1\n\tv1054 = UnityEngine.Physics::BoxCastNonAlloc(v203, v200, v1049, v990.hits, v1032.identity, v237);\n\tv283 = v1054 < 1;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tif (v283) goto L_02A1;\nL_023A:\n\tgoto L_024C;\nL_FFFFFFFF:\n\tv370 = 0;\nL_01E4:\n\tv263 = v175 - v883;\n\tv337 = v167 - v1020;\n\tv258 = v882 - v885;\n\tv335 = v171 * 0x3F666666;\n\tv261 = v177 * v892;\n\tgoto L_0213;\n")]
		public unsafe bool IsSeeThroughOccluded(Camera cam)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::IsSeeThroughOccluded");
			return default;
		}

		[Token(Token = "0x600008A")]
		[Address(RVA = "0x7723D10", Offset = "0x7723D10", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0016;\nL_0016:\n\tv51 = v49.occluders == 0;\n\tv52 = ~v51;\n\tif (v52) goto L_0034;\n\tgoto L_007D;\nL_0034:\n\tv70 = System.Collections.Generic.List`1<HighlightPlus.HighlightSeeThroughOccluder>::Contains(v49.occluders, occluder);\n\tv90 = v70 == 0;\n\tif (v90) goto L_0044;\n\treturn;\nL_0044:\n\tgoto L_0048;\n\tgoto L_007B;\nL_007B:\n\tSystem.Collections.Generic.List`1<HighlightPlus.HighlightSeeThroughOccluder>::Add(v81, occluder);\n\treturn;\nL_007D:\n\tthrow System.NullReferenceException;\nL_0048:\n\tv81 = v87.occluders;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void RegisterOccluder(HighlightSeeThroughOccluder occluder)
		{
			if (occluders != null)
			{
				if (!occluders.Contains(occluder))
				{
					List<HighlightSeeThroughOccluder> list = occluders;
					list.Add(occluder);
				}
				return;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x600008B")]
		[Address(RVA = "0x7723E60", Offset = "0x7723E60", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\nL_0013:\n\tgoto L_0016;\nL_0016:\n\tv51 = v49.occluders == 0;\n\tv52 = ~v51;\n\tif (v52) goto L_0034;\n\tgoto L_0057;\nL_0034:\n\tv70 = System.Collections.Generic.List`1<HighlightPlus.HighlightSeeThroughOccluder>::Contains(v49.occluders, occluder);\n\tv84 = ~v70;\n\tif (v84) goto L_0056;\n\tgoto L_004D;\nL_004D:\n\tv106 = System.Collections.Generic.List`1<HighlightPlus.HighlightSeeThroughOccluder>::Remove(v82.occluders, occluder);\n\treturn;\nL_0056:\n\treturn;\nL_0057:\n\tthrow System.NullReferenceException;\n")]
		public static void UnregisterOccluder(HighlightSeeThroughOccluder occluder)
		{
			if (occluders != null)
			{
				if (occluders.Contains(occluder))
				{
					bool flag = occluders.Remove(occluder);
				}
				return;
			}
			throw new NullReferenceException();
		}

		[Token(Token = "0x600008C")]
		[Address(RVA = "0x7719F20", Offset = "0x7719F20", Length = "0x644")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tgoto L_001E;\nL_001E:\n\tv83 = v66.occluders;\n\tv68 = v66.occluders == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_004A;\n\tgoto L_028D;\nL_004A:\n\tv86 = v83.Count == 0;\n\tif (v86) goto L_FFFFFFFF;\n\tv339 = this.includedObjectsCount == 0;\n\tif (v339) goto L_FFFFFFFF;\n\tv496 = v83.Count < 1;\n\tif (v496) goto L_00B4;\nL_FFFFFFFF:\n\tv326 = 0;\n\tgoto L_0070;\nL_0061:\n\tv326 = v326 + 1;\n\tv583 = v83.Count == v326;\n\tif (v583) goto L_00B4;\nL_0070:\n\tgoto L_0079;\nL_0079:\n\tv660 = System.Collections.Generic.List`1<HighlightPlus.HighlightSeeThroughOccluder>::get_Item(v320.occluders, v326);\n\tgoto L_0082;\nL_0082:\n\tv670 = UnityEngine.Object::op_Equality(v660, 0);\n\tv677 = v670 == 0;\n\tv678 = ~v677;\n\tif (v678) goto L_0061;\n\tgoto L_0095;\nL_0095:\n\tv695 = UnityEngine.Behaviour::get_isActiveAndEnabled(v660);\n\tv697 = ~v695;\n\tif (v697) goto L_0061;\n\tv730 = *([v660 @ X0_v100 (UnityEngine.Object)+20]) == 0;\n\tv698 = ~v730;\n\tif (v698) goto L_0061;\n\tv516 = *([v660 @ X0_v100 (UnityEngine.Object)+24]) != 1;\n\tif (v516) goto L_0061;\n\tv589 = HighlightPlus.HighlightEffect::IsSeeThroughOccluded(this, cam);\n\tv548 = v589 == 0;\n\tif (v548) goto L_00B4;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tgoto L_00DD;\nL_00B4:\n\tgoto L_00C0;\nL_00C0:\n\tv654 = System.Collections.Generic.Dictionary`2<UnityEngine.Camera, System.Int32>::TryGetValue(v321.occludersFrameCount, cam, &v293 @ stack_-64_v6 (System.Int32));\n\tv401 = UnityEngine.Time::get_frameCount();\n\tv176 = v401 != v293;\n\tif (v176) goto L_00E3;\nL_FFFFFFFF:\n\treturnVal1 = 1;\nL_00E3:\n\tgoto L_00EF;\nL_00EF:\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Camera, System.Int32>::set_Item(v322.occludersFrameCount, cam, v401);\n\tgoto L_00FB;\nL_00FB:\n\tv720 = UnityEngine.Object::op_Equality(v710.fxMatSeeThroughOccluder, 0);\n\tv724 = ~v720;\n\tv725 = ~v724;\n\tif (v725) goto L_FFFFFFFF;\n\tgoto L_012E;\nL_FFFFFFFF:\n\tv753 = HighlightPlus.HighlightEffect;\n\tgoto L_0114;\nL_0125:\n\tv402 = UnityEngine.Object::op_Equality(v769.fxMatSeeThroughOccluder, 0);\n\tv790 = v402 == 0;\n\tv407 = ~v790;\n\tif (v407) goto L_FFFFFFFF;\nL_012E:\n\tgoto L_0138;\nL_013C:\n\tv779 = UnityEngine.Object::op_Equality(v763.fxMatDepthWrite, 0);\n\tv784 = ~v779;\n\tif (v784) goto L_0182;\nL_FFFFFFFF:\n\tv804 = HighlightPlus.HighlightEffect;\n\tgoto L_014A;\n\tv550 = v848 == 0;\n\tif (v550) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal1 = 1;\n\tgoto L_00DD;\nL_0182:\n\tv372 = v83.Count < 1;\n\tif (v372) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv336 = 0;\n\tgoto L_0199;\nL_0189:\n\tv336 = v336 + 1;\n\tv388 = v336 == v83.Count;\n\tif (v388) goto L_FFFFFFFF;\nL_0199:\n\tgoto L_01A4;\nL_01A4:\n\tv858 = System.Collections.Generic.List`1<HighlightPlus.HighlightSeeThroughOccluder>::get_Item(v323.occluders, v336);\n\tgoto L_01AF;\nL_01AF:\n\tv867 = UnityEngine.Object::op_Equality(v858, 0);\n\tv870 = v867 == 0;\n\tv871 = ~v870;\n\tif (v871) goto L_0189;\n\tgoto L_01C2;\nL_01C2:\n\tv924 = UnityEngine.Behaviour::get_isActiveAndEnabled(v858);\n\tv927 = ~v924;\n\tif (v927) goto L_0189;\n\tv944 = *([v858 @ X0_v29 (UnityEngine.Object)+24]) == 0;\n\tv928 = ~v944;\n\tif (v928) goto L_0189;\n\tv934 = *([v858 @ X0_v29 (UnityEngine.Object)+28]);\n\tv929 = *([v858 @ X0_v29 (UnityEngine.Object)+28]) == 0;\n\tif (v929) goto L_0189;\n\tv888 = *([v934 @ X8_v39+18]) < 1;\n\tif (v888) goto L_0189;\n\tv947 = cb == 0;\n\tif (v947) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv161 = 0;\n\tgoto L_01EA;\nL_01DE:\n\tv161 = v161 + 1;\n\tv909 = v161 == *([v934 @ X8_v39+18]);\n\tif (v909) goto L_0189;\nL_01EA:\n\t;\n\tv104 = v161 << 4;\n\tv314 = *([v858 @ X0_v29 (UnityEngine.Object)+28]) + v104;\n\tv282 = UnityEngine.Renderer::get_isVisible(*([v314 @ X8_v52+20]));\n\tv958 = ~v282;\n\tif (v958) goto L_01DE;\n\tv481 = *([v858 @ X0_v29 (UnityEngine.Object)+28]);\nL_FFFFFFFF:\n\tv440 = 0;\n\tgoto L_021D;\nL_0207:\n\tv1020 = *([v1018 @ X0_v46 (Il2CppClass<HighlightPlus.HighlightEffect>)+B8]);\n\tUnityEngine.Rendering.CommandBuffer::DrawRenderer(cb, *([v314 @ X8_v52+20]), *([v1020 @ X8_v58 (Il2CppStaticFields<HighlightPlus.HighlightEffect>)+v276 @ X25_v10 (System.Int32)]), v440);\n\tv440 = v440 + 1;\n\tv481 = *([v858 @ X0_v29 (UnityEngine.Object)+28]);\nL_021D:\n\tv105 = v161 << 4;\n\tv1007 = v481 + v105;\n\tv173 = v440 >= *([v1007 @ X8_v55+28]);\n\tif (v173) goto L_01DE;\n\tv95 = *([v858 @ X0_v29 (UnityEngine.Object)+20]) != 0;\n\tif (v95) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv276 = 0x1C8;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv276 = 0x1D0;\nL_FFFFFFFF:\n\tv130 = 0;\nL_FFFFFFFF:\n\tv325 = 0;\n\tgoto L_0253;\nL_0246:\n\tv130 = v130 + 1;\n\tv325 = v325 + 0x10;\n\tv910 = *([v934 @ X8_v39+18]) == v130;\n\tif (v910) goto L_0189;\nL_0253:\n\t;\n\tv318 = *([v858 @ X0_v29 (UnityEngine.Object)+28]) + v325;\n\tv286 = UnityEngine.Renderer::get_isVisible(*([v318 @ X8_v43+20]));\n\tv960 = v286 == 0;\n\tif (v960) goto L_0246;\n\tv1003 = *([v858 @ X0_v29 (UnityEngine.Object)+28]) + v325;\n\tv168 = *([v1003 @ X8_v45+28]) <= 0;\n\tif (v168) goto L_0246;\n\tgoto L_028D;\nL_028D:\n\tv337 = new System.NullReferenceException();\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\nL_00DD:\n\treturn returnVal1;\nL_0114:\n\tv757 = v753.overlayColor + 0x1C8;\n\tv758 = v753.overlayColor + 0xF0;\n\tHighlightPlus.HighlightEffect::InitMaterial(v753, v757, v758, \"HighlightPlus/Geometry/SeeThroughOccluder\");\n\tgoto L_0125;\nL_0138:\n\tgoto L_013C;\nL_014A:\n\tv809 = v804.overlayColor + 0x1D0;\n\tv810 = v804.overlayColor + 0xF8;\n\tHighlightPlus.HighlightEffect::InitMaterial(v804, v809, v810, \"HighlightPlus/Geometry/JustDepth\");\n\tgoto L_015D;\nL_015D:\n\tv848 = UnityEngine.Object::op_Equality(v830.fxMatDepthWrite, 0);\n\tv517 = v83.Count < 1;\nL_FFFFFFFF:\n\treturnVal1 = 1;\n\tif (v517) goto L_00DD;\nL_FFFFFFFF:\n\tv1018 = HighlightPlus.HighlightEffect;\n\tgoto L_0207;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe bool RenderSeeThroughOccluders(CommandBuffer cb, Camera cam)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::RenderSeeThroughOccluders");
			return default;
		}

		[Token(Token = "0x600008D")]
		[Address(RVA = "0x771B1E4", Offset = "0x771B1E4", Length = "0xA3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003B;\n\tv91 = System.Collections.Generic.Dictionary`2<UnityEngine.Camera, HighlightPlus.HighlightEffect+PerCameraOcclusionData>::TryGetValue(this.perCameraOcclusionData, cam, &v89 @ stack_-B0_v5 (HighlightPlus.HighlightEffect+PerCameraOcclusionData));\n\tv663 = v91 == 0;\n\tv664 = ~v663;\n\tif (v664) goto L_0063;\n\tv735 = new HighlightPlus.HighlightEffect+PerCameraOcclusionData();\n\tHighlightPlus.HighlightEffect+PerCameraOcclusionData::.ctor(v735);\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Camera, HighlightPlus.HighlightEffect+PerCameraOcclusionData>::set_Item(this.perCameraOcclusionData, cam, v735);\nL_0063:\n\tgoto L_0068;\nL_0068:\n\tgoto L_006C;\nL_006C:\n\tgoto L_0070;\nL_0070:\n\tv839 = v836.useUnscaledTime == 0;\n\tif (v839) goto L_008F;\n\tv522 = UnityEngine.Time::get_unscaledTime();\n\tgoto L_0092;\nL_008F:\n\tv522 = UnityEngine.Time::get_time();\nL_0092:\n\tv891 = UnityEngine.Time::get_frameCount();\n\tv523 = v522 - v735.checkLastTime;\n\tv494 = v523 < this.seeThroughOccluderCheckInterval;\n\tv413 = ~v494;\nL_FFFFFFFF:\n\tv1001 = v735;\n\tif (v413) goto L_00C9;\n\tgoto L_00AB;\nL_00AB:\n\tv984 = UnityEngine.Application::get_isPlaying();\n\tv996 = ~v984;\nL_FFFFFFFF:\n\tv1001 = v735;\n\tif (v996) goto L_00C9;\n\tv974 = v735.occlusionRenderFrame == v891;\nL_FFFFFFFF:\n\tv1001 = v735;\n\tif (v974) goto L_00C9;\nL_FFFFFFFF:\n\tv1097 = v735.lastOcclusionTestResult;\n\tgoto L_00FE;\nL_00C9:\n\tv630 = v1001.cachedOccluders;\n\tSystem.Collections.Generic.List`1<UnityEngine.Renderer>::Clear(v630);\n\tv414 = v630.Count < 1;\n\tif (v414) goto L_00E5;\nL_FFFFFFFF:\n\tv1001 = v735;\nL_00E5:\n\tv1001.cachedOccluderCollider = 0;\n\tv1097 = this.rms;\n\tv1019 = this.rms == 0;\n\tif (v1019) goto L_00FE;\n\tv1022 = v1097.Length == 0;\n\tif (v1022) goto L_FFFFFFFF;\n\tgoto L_00F9;\nL_00F9:\n\tv1134 = UnityEngine.Object::op_Equality(*([v1097 @ X8_v3 (ModelMaterials[])+50]), 0);\n\tv1136 = v1134 == 0;\n\tif (v1136) goto L_0123;\nL_FFFFFFFF:\n\tv1097 = 0;\nL_0123:\n\tv735.checkLastTime = v522;\n\tv735.occlusionRenderFrame = v891;\n\tv584 = UnityEngine.Component::get_transform(cam);\n\tv524 = UnityEngine.Transform::get_position(v584);\n\tv636 = this.rms;\n\tv415 = this.seeThroughOccluderCheckIndividualObjects != 1;\n\tif (v415) goto L_0247;\nL_FFFFFFFF:\n\tv342 = 0x50;\nL_FFFFFFFF:\n\tv346 = 0;\n\tgoto L_017A;\nL_014D:\n\tv1592 = v1363.m_Center.z - v524.z;\n\tv1595 = v1363.m_Center.y - v524.y;\n\tv1596 = v1363.center - v524;\n\tv1597 = v1596 * v1596;\n\tv1598 = v1595 * v1595;\n\tv1599 = v1597 + v1598;\n\tv1600 = v1592 * v1592;\n\tv1601 = v1600 + v1599;\n\tv1602 = UnityEngine.Mathf::Sqrt(v1601);\n\tv332 = v1363.extents * v152;\n\tv325 = v1363.m_Extents.y * v152;\n\tv318 = v1363.m_Extents.z * v152;\n\t// 367 MakeStruct v264 @ AGG771B5DC_0_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v1363.center (UnityEngine.Vector3), v1363.m_Center.y (System.Single), v1363.m_Center.z (System.Single)\n\t// 368 MakeStruct v258 @ AGG771B5DC_1_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v332 @ V3_v23 (System.Single), v325 @ V4_v18 (System.Single), v318 @ V5_v10 (System.Single)\n\tv1334 = UnityEngine.Physics::BoxCast(v264, v258, v141, &v75 @ stack_-E0_v1 (UnityEngine.RaycastHit), v1563.identity, v1602, v1566);\n\tv1616 = ~v1334;\n\tv1336 = ~v1616;\n\tif (v1336) goto L_03D7;\nL_0175:\n\tv346 = v346 + 1;\n\tv636 = this.rms;\n\tv342 = v342 + 0xD8;\nL_017A:\n\t;\n\tv417 = v346 >= v636.Length;\n\tif (v417) goto L_0370;\n\tgoto L_018D;\nL_018D:\n\tv1317 = UnityEngine.Object::op_Inequality(*([v636 @ X8_v55 (ModelMaterials[])+v342 @ X26_v7 (System.Int32)]), 0);\n\tv1321 = ~v1317;\n\tif (v1321) goto L_0175;\n\tgoto L_019A;\nL_019A:\n\tv634 = this.rms;\n\tv1363 = UnityEngine.Renderer::get_bounds(*([v634 @ X8_v58 (ModelMaterials[])+v342 @ X26_v7 (System.Int32)]));\n\tgoto L_01C5;\nL_01C5:\n\tgoto L_01C6;\nL_01C6:\n\tv152 = this.seeThroughOccluderThreshold;\n\tv1422 = *([B193A86]) & 1;\n\tv1423 = v1422 == 0;\n\tif (v1423) goto L_0207;\n\tgoto L_01D1;\nL_01D1:\n\tv1462 = v524 - v1363.center;\n\tv1463 = v524.y - v1363.m_Center.y;\n\tv1465 = v524.z - v1363.m_Center.z;\n\tv1466 = v1462 * v1462;\n\tv1467 = v1463 * v1463;\n\tv1468 = v1466 + v1467;\n\tv1469 = v1465 * v1465;\n\tv1470 = v1469 + v1468;\n\tv1471 = UnityEngine.Mathf::Sqrt(v1470);\n\tv503 = v1471 < 0x3727C5AC;\n\tv489 = v1471 == 0x3727C5AC;\n\tv1478 = v1471 == v1471;\n\tv433 = ~v1478;\n\tv1479 = v503 == v433;\n\tv1480 = ~v1479;\n\tv419 = v1480 | v489;\n\tif (v419) goto L_0214;\n\tv1496 = v1462 / v1471;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv141 = v1496;\n\tgoto L_0234;\nL_0207:\n\t*([B193A86]) = 1;\nL_FFFFFFFF:\n\tv152 = v152;\n\tgoto L_01D1;\nL_0214:\n\tgoto L_FFFFFFFF;\nL_0247:\n\tv1314 = &v243 @ stack_-128_v5 (System.Single);\n\tv589 = UnityEngine.Renderer::get_bounds(*([v636 @ X8_v55 (ModelMaterials[])+50]));\n\tv718 = this.rms;\nL_FFFFFFFF:\n\tv117 = *([v1314 @ X8_v47+10]);\nL_FFFFFFFF:\n\tv172 = *([v1314 @ X8_v47+4]);\nL_FFFFFFFF:\n\tv173 = *([v1314 @ X8_v47+C]);\nL_FFFFFFFF:\n\tv192 = *([v1314 @ X8_v47]);\nL_FFFFFFFF:\n\tv531 = 0x128;\nL_FFFFFFFF:\n\tv642 = 1;\n\tgoto L_02CF;\nL_025F:\n\tv1403 = UnityEngine.Renderer::get_bounds(*([v625 @ X8_v53 (ModelMaterials[])+v531 @ X22_v17 (System.Int32)]));\n\tv1574 = v1403.center - v1403.extents;\n\tv1543 = v192 - v173;\n\tv1486 = v172 - v117;\n\tv1487 = v1543 < v1574;\n\tv1495 = ~v1487;\n\tif (v1495) goto L_FFFFFFFF;\n\tgoto L_027A;\nL_FFFFFFFF:\n\tv1543 = v1574;\nL_FFFFFFFF:\n\tv1574 = v1389;\n\tgoto L_028D;\n\tgoto L_02A0;\nL_FFFFFFFF:\n\tv1400 = v1620;\nL_FFFFFFFF:\n\tv1620 = v1612;\n\tgoto L_02B2;\nL_02CF:\n\t;\n\tv411 = v642 >= v718.Length;\nL_FFFFFFFF:\n\tv170 = v172;\nL_FFFFFFFF:\n\tv190 = v192;\nL_FFFFFFFF:\n\tv686 = v524.z;\nL_FFFFFFFF:\n\tv687 = v524;\nL_FFFFFFFF:\n\tv688 = v524.y;\nL_FFFFFFFF:\n\tv720 = this;\n\tif (v411) goto L_0312;\n\tgoto L_02ED;\nL_02ED:\n\tv1359 = UnityEngine.Object::op_Inequality(*([v718 @ X8_v49 (ModelMaterials[])+v531 @ X22_v17 (System.Int32)]), 0);\n\tv1364 = ~v1359;\n\tif (v1364) goto L_02CA;\n\tgoto L_02F8;\nL_02F8:\n\tv625 = this.rms;\n\tv1449 = *([v625 @ X8_v53 (ModelMaterials[])+v531 @ X22_v17 (System.Int32)]) == 0;\n\tv599 = ~v1449;\nL_FFFFFFFF:\n\tv170 = v172;\nL_FFFFFFFF:\n\tv190 = v192;\nL_FFFFFFFF:\n\tv686 = v524.z;\nL_FFFFFFFF:\n\tv687 = v524;\nL_FFFFFFFF:\n\tv688 = v524.y;\nL_FFFFFFFF:\n\tv720 = this;\n\tif (v599) goto L_025F;\n\tthrow System.NullReferenceException;\nL_0312:\n\tgoto L_031C;\nL_0323:\n\tv774 = v170 - v688;\n\tv775 = v190 - v687;\n\tgoto L_0335;\n\tv892 = v817 / v860;\n\tv951 = v854 + v853;\n\tv646 = 0xB293000 + 0x1E8;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv184 = v892;\n\tgoto L_0395;\nL_0370:\n\tv735.lastOcclusionTestResult = 0;\nL_FFFFFFFF:\n\tv1097 = 0;\n\tgoto L_00FE;\nL_0379:\n\tgoto L_0386;\nL_03BE:\n\t// 958 MakeStruct v102 @ AGG771BBA4_0_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v190 @ V11_v3 (UnityEngine.Vector3), v170 @ stack_-140_v2 (UnityEngine.Vector3), v771 @ V1.S1\n\t// 959 MakeStruct v99 @ AGG771BBA4_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v518 @ V8_v6 (System.Single), v960 @ V0_v14 (System.Single), v1008 @ V4.S1\n\tv592 = UnityEngine.Physics::BoxCast(v102, v99, v184, &v78 @ stack_-110_v1 (UnityEngine.RaycastHit), *([v979 @ X8_v15]), v151, v982);\n\tv735.lastOcclusionTestResult = v592;\n\tv593 = UnityEngine.RaycastHit::get_collider(&v78 @ stack_-110_v1 (UnityEngine.RaycastHit));\n\tv735.cachedOccluderCollider = v593;\nL_FFFFFFFF:\n\tv1097 = v735.lastOcclusionTestResult;\n\tgoto L_00FE;\nL_03D7:\n\tv595 = UnityEngine.RaycastHit::get_collider(&v75 @ stack_-E0_v1 (UnityEngine.RaycastHit));\n\tv735.cachedOccluderCollider = v595;\n\tv735.lastOcclusionTestResult = 1;\nL_FFFFFFFF:\n\tv1097 = 1;\n\tgoto L_00FE;\nL_003B:\n\tv75 = 0;\n\tv78 = 0;\nL_00FE:\n\treturnVal1 = v1097 & 1;\n\treturn returnVal1;\nL_0234:\n\tv1566 = UnityEngine.LayerMask::op_Implicit(this.seeThroughOccluderMask);\n\tgoto L_014D;\nL_FFFFFFFF:\n\tv141 = v1539.zero;\n\tgoto L_0234;\nL_027A:\n\tv1389 = v173 + v192;\n\tv1544 = v1389 < v1574;\n\tv1545 = v1389 == v1574;\n\tv1548 = v1389 == v1389;\n\tv1549 = v1574 == v1574;\n\tv1550 = v1548 & v1549;\n\tv1551 = ~v1550;\n\tv1552 = v1544 == v1551;\n\tv1553 = ~v1545;\n\tv1554 = v1552 & v1553;\n\tv1555 = ~v1554;\n\tif (v1555) goto L_028D;\nL_028D:\n\tv1575 = v1574 - v1543;\n\tv1576 = v1575 * 0.5f;\n\tv1577 = v1543 + v1576;\n\tv1620 = v1403.center + v1403.extents;\n\tv1400 = v1577 - v1576;\n\tv1580 = v1400 < v1620;\n\tv1588 = ~v1580;\n\tif (v1588) goto L_FFFFFFFF;\nL_02A0:\n\tv1612 = v1576 + v1577;\n\tv1399 = v1612 < v1620;\n\tv1398 = v1612 == v1620;\n\tv1614 = v1612 == v1612;\n\t\n// ... truncated")]
		private bool CheckOcclusion(Camera cam)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::CheckOcclusion");
			return default;
		}

		[Token(Token = "0x600008E")]
		[Address(RVA = "0x7723F5C", Offset = "0x7723F5C", Length = "0x23C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\nL_0035:\n\tv72 = source.Count < 1;\n\tif (v72) goto L_00D6;\n\tv169 = target == 0;\n\tif (v169) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv158 = 0;\n\tgoto L_0056;\nL_0047:\n\tSystem.Collections.Generic.List`1<UnityEngine.Renderer>::Add(target, v287);\nL_0048:\n\tv158 = v158 + 1;\n\tv204 = source.Count == v158;\n\tif (v204) goto L_00D6;\nL_0056:\n\tv287 = System.Collections.Generic.List`1<UnityEngine.Renderer>::get_Item(source, v158);\n\tgoto L_005F;\nL_005F:\n\tv306 = UnityEngine.Object::op_Inequality(v287, 0);\n\tv313 = ~v306;\n\tif (v313) goto L_0048;\n\tgoto L_006D;\nL_006D:\n\tv344 = System.Collections.Generic.List`1<UnityEngine.Renderer>::Contains(target, v287);\n\tv361 = v344 == 0;\n\tv347 = ~v361;\n\tif (v347) goto L_0048;\n\tv144 = HighlightPlus.HighlightEffect::ValidRenderer(v344, v287);\n\tv348 = ~v144;\n\tif (v348) goto L_0048;\n\tv145 = UnityEngine.Component::get_gameObject(v287);\n\tv364 = UnityEngine.GameObject::get_layer(v145);\n\tv146 = UnityEngine.LayerMask::op_Implicit(layerMask);\n\tv351 = v146 >> v364;\n\tv366 = v351 & 1;\n\tv349 = v366 == 0;\n\tif (v349) goto L_0048;\n\tgoto L_0047;\nL_FFFFFFFF:\n\tv161 = target;\n\tv223 = v161 + 1;\n\tv189 = source.Count != v223;\nL_FFFFFFFF:\n\tv161 = v223;\n\tif (v189) goto L_00AC;\nL_00D6:\n\treturn;\nL_00B8:\n\tv147 = UnityEngine.Object::op_Inequality(v298, 0);\nL_00AC:\n\tv298 = System.Collections.Generic.List`1<UnityEngine.Renderer>::get_Item(source, v161);\n\tgoto L_00B8;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void AddWithoutRepetition(List<Renderer> target, List<Renderer> source, LayerMask layerMask)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::AddWithoutRepetition");
		}

		[Token(Token = "0x600008F")]
		[Address(RVA = "0x771A564", Offset = "0x771A564", Length = "0xC80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_004E;\nL_004E:\n\tv85 = System.Collections.Generic.Dictionary`2<UnityEngine.Camera, HighlightPlus.HighlightEffect+PerCameraOcclusionData>::TryGetValue(this.perCameraOcclusionData, cam, &v83 @ stack_-B0_v7 (HighlightPlus.HighlightEffect+PerCameraOcclusionData));\n\tv809 = v85 == 0;\n\tv810 = ~v809;\n\tif (v810) goto L_0065;\n\tv881 = new HighlightPlus.HighlightEffect+PerCameraOcclusionData();\n\tHighlightPlus.HighlightEffect+PerCameraOcclusionData::.ctor(v881);\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Camera, HighlightPlus.HighlightEffect+PerCameraOcclusionData>::set_Item(this.perCameraOcclusionData, cam, v881);\nL_0065:\n\tv624 = 0xB28F000 + 0x80;\n\tgoto L_006E;\nL_006E:\n\tgoto L_0072;\nL_0072:\n\tgoto L_0076;\nL_0076:\n\tv984 = v981.useUnscaledTime == 0;\n\tif (v984) goto L_0095;\n\tv614 = UnityEngine.Time::get_unscaledTime();\n\tgoto L_0099;\nL_0095:\n\tv614 = UnityEngine.Time::get_time();\nL_0099:\n\tv1048 = UnityEngine.Time::get_frameCount();\n\tv615 = v614 - v881.checkLastTime;\n\tv574 = v615 < this.seeThroughOccluderCheckInterval;\n\tv471 = ~v574;\nL_FFFFFFFF:\n\tv1166 = v881;\n\tif (v471) goto L_00CF;\n\tgoto L_00B2;\nL_00B2:\n\tv1143 = UnityEngine.Application::get_isPlaying();\n\tv1161 = ~v1143;\nL_FFFFFFFF:\n\tv1166 = v881;\n\tif (v1161) goto L_00CF;\n\tv1130 = v881.occlusionRenderFrame == v1048;\nL_FFFFFFFF:\n\tv1166 = v881;\n\tif (v1130) goto L_00CF;\nL_FFFFFFFF:\n\tv604 = cbuf;\n\tgoto L_047C;\nL_00CF:\n\tv758 = v1166.cachedOccluders;\n\tSystem.Collections.Generic.List`1<UnityEngine.Renderer>::Clear(v758);\n\tv472 = v758.Count < 1;\n\tif (v472) goto L_00EB;\nL_FFFFFFFF:\n\tv1166 = v881;\nL_00EB:\n\tv1166.cachedOccluderCollider = 0;\n\tv1188 = this.rms;\n\tv1189 = this.rms == 0;\n\tif (v1189) goto L_04DF;\n\tv1218 = v1188.Length == 0;\n\tif (v1218) goto L_04DF;\n\tv401 = 0xB292000 + 0x5A0;\n\tgoto L_0100;\nL_0100:\n\tv1309 = UnityEngine.Object::op_Equality(*([v1188 @ X8_v52 (ModelMaterials[])+50]), 0);\n\tv1313 = v1309 == 0;\n\tif (v1313) goto L_0111;\n\tgoto L_04DF;\nL_0111:\n\tv881.checkLastTime = v614;\n\tv881.occlusionRenderFrame = v1048;\n\tgoto L_012E;\nL_012E:\n\tv693 = UnityEngine.Component::get_transform(cam);\n\tv617 = UnityEngine.Transform::get_position(v693);\n\tgoto L_013D;\nL_013D:\n\tv1618 = v1570.occluderHits;\n\tv1572 = v1570.occluderHits == 0;\n\tv1573 = ~v1572;\n\tif (v1573) goto L_014B;\n\tgoto L_0164;\nL_014B:\n\tgoto L_015E;\nL_015E:\n\tv1594 = v1618.Length > 0x31;\n\tif (v1594) goto L_0173;\nL_0164:\n\t// 356 NewArr v1617 @ X0_v151 (UnityEngine.RaycastHit[]), typeof(UnityEngine.RaycastHit[]), 50\n\tgoto L_016E;\nL_0173:\n\tv1213 = this.rms;\n\tv473 = this.seeThroughOccluderCheckIndividualObjects != 1;\n\tif (v473) goto L_02C9;\nL_FFFFFFFF:\n\tv344 = 0;\n\tgoto L_018D;\nL_0188:\n\tv344 = v344 + 1;\n\tv1213 = this.rms;\nL_018D:\n\t;\n\tv475 = v344 >= v1213.Length;\nL_FFFFFFFF:\n\tv604 = cbuf;\n\tif (v475) goto L_047C;\n\tv1665 = *([v401 @ X24_v12 (System.Int32)]);\n\tv1666 = *([v1665 @ X8_v74+E4]) == 0;\n\tif (v1666) goto L_01AD;\n\tv1670 = UnityEngine.Object::op_Inequality(v1213[v344 @ X27_v8 (System.Int32)].renderer, 0);\n\tv1674 = ~v1670;\n\tif (v1674) goto L_0188;\n\tgoto L_01B0;\nL_01AD:\n\tv1678 = UnityEngine.Object::op_Inequality(v1213[v344 @ X27_v8 (System.Int32)].renderer, 0);\n\tv1717 = ~v1678;\n\tif (v1717) goto L_0188;\nL_01B0:\n\tv764 = this.rms;\n\tv1746 = UnityEngine.Renderer::get_bounds(v764[v344 @ X27_v8 (System.Int32)].renderer);\n\tgoto L_01DC;\nL_01DC:\n\tgoto L_01DD;\nL_01DD:\n\tv229 = this.seeThroughOccluderThreshold;\n\tv1807 = *([B193A86]) & 1;\n\tv1808 = v1807 == 0;\n\tif (v1808) goto L_0221;\n\tgoto L_01E9;\nL_01E9:\n\tv1854 = v617 - v1746.center;\n\tv1855 = v617.y - v1746.m_Center.y;\n\tv1857 = v617.z - v1746.m_Center.z;\n\tv1858 = v1854 * v1854;\n\tv1859 = v1855 * v1855;\n\tv1860 = v1858 + v1859;\n\tv1861 = v1857 * v1857;\n\tv1862 = v1861 + v1860;\n\tv1863 = UnityEngine.Mathf::Sqrt(v1862);\n\tv1870 = v1863 < 0x3727C5AC;\n\tv1871 = v1863 == 0x3727C5AC;\n\tv1874 = v1863 == v1863;\n\tv1877 = ~v1874;\n\tv1878 = v1870 == v1877;\n\tv1879 = ~v1878;\n\tv1880 = v1879 | v1871;\n\tif (v1880) goto L_022E;\n\tv207 = v1854 / v1863;\n\tgoto L_0247;\nL_0221:\n\t*([B193A86]) = 1;\nL_FFFFFFFF:\n\tv229 = v229;\n\tgoto L_01E9;\nL_022E:\n\tgoto L_FFFFFFFF;\nL_0253:\n\tv1968 = v1746.m_Center.z - v617.z;\n\tv1969 = v1746.m_Center.y - v617.y;\n\tv1971 = v1746.center - v617;\n\tv1972 = v1971 * v1971;\n\tv1973 = v1969 * v1969;\n\tv1974 = v1972 + v1973;\n\tv1975 = v1968 * v1968;\n\tv1976 = v1975 + v1974;\n\tv192 = UnityEngine.Mathf::Sqrt(v1976);\n\tv222 = v1746.extents * v229;\n\tv214 = v1746.m_Extents.y * v229;\n\tv184 = v1746.m_Extents.z * v229;\n\t// 628 MakeStruct v121 @ AGG771AC20_0_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v1746.center (UnityEngine.Vector3), v1746.m_Center.y (System.Single), v1746.m_Center.z (System.Single)\n\t// 629 MakeStruct v114 @ AGG771AC20_1_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v222 @ V3_v25 (System.Single), v214 @ V4_v18 (System.Single), v184 @ V5_v11 (System.Single)\n\tv1715 = UnityEngine.Physics::BoxCastNonAlloc(v121, v114, v207, v1927.occluderHits, v760.identity, v192, v1930);\n\tv1696 = v1715 < 1;\n\tif (v1696) goto L_0188;\nL_FFFFFFFF:\n\tv107 = 0x20;\nL_FFFFFFFF:\n\tv411 = 0;\nL_029C:\n\tv2031 = v2029.occluderHits + v107;\n\tv699 = UnityEngine.RaycastHit::get_collider(v2031);\n\tv700 = UnityEngine.Component::get_transform(v699);\n\tv701 = UnityEngine.Transform::get_root(v700);\n\tUnityEngine.Component::GetComponentsInChildren(v701, this.tempRR);\n\tHighlightPlus.HighlightEffect::AddWithoutRepetition(v701, v881.cachedOccluders, this.tempRR, this.seeThroughOccluderMask);\n\tv411 = v411 + 1;\n\tv107 = v107 + 0x2C;\n\tv1697 = v1715 != v411;\n\tif (v1697) goto L_028A;\n\tgoto L_0188;\nL_02C9:\n\tv1667 = &v334 @ stack_-C8_v6 (System.Single);\n\tv703 = UnityEngine.Renderer::get_bounds(*([v1213 @ X8_v72 (ModelMaterials[])+50]));\n\tv865 = this.rms;\nL_FFFFFFFF:\n\tv196 = *([v1667 @ X8_v64+10]);\nL_FFFFFFFF:\n\tv254 = *([v1667 @ X8_v64+4]);\nL_FFFFFFFF:\n\tv255 = *([v1667 @ X8_v64+C]);\nL_FFFFFFFF:\n\tv277 = *([v1667 @ X8_v64]);\nL_FFFFFFFF:\n\tv407 = 0x128;\nL_FFFFFFFF:\n\tv778 = 1;\n\tgoto L_0351;\nL_02E1:\n\tv1785 = UnityEngine.Renderer::get_bounds(*([v753 @ X8_v70 (ModelMaterials[])+v407 @ X23_v13 (System.Int32)]));\n\tv1977 = v1785.center - v1785.extents;\n\tv1943 = v277 - v255;\n\tv1886 = v254 - v196;\n\tv1887 = v1943 < v1977;\n\tv1895 = ~v1887;\n\tif (v1895) goto L_FFFFFFFF;\n\tgoto L_02FC;\nL_FFFFFFFF:\n\tv1943 = v1977;\nL_FFFFFFFF:\n\tv1977 = v1759;\n\tgoto L_030F;\n\tgoto L_0322;\nL_FFFFFFFF:\n\tv1782 = v2018;\nL_FFFFFFFF:\n\tv2018 = v2003;\n\tgoto L_0334;\nL_0351:\n\t;\n\tv469 = v778 >= v865.Length;\nL_FFFFFFFF:\n\tv252 = v254;\nL_FFFFFFFF:\n\tv275 = v277;\nL_FFFFFFFF:\n\tv357 = v617.z;\nL_FFFFFFFF:\n\tv830 = v617;\nL_FFFFFFFF:\n\tv367 = v617.y;\nL_FFFFFFFF:\n\tv391 = v760.identity;\nL_FFFFFFFF:\n\tv604 = cbuf;\nL_FFFFFFFF:\n\tv788 = this;\n\tif (v469) goto L_0394;\n\tgoto L_036F;\nL_036F:\n\tv1742 = UnityEngine.Object::op_Inequality(*([v865 @ X8_v66 (ModelMaterials[])+v407 @ X23_v13 (System.Int32)]), 0);\n\tv1747 = ~v1742;\n\tif (v1747) goto L_034C;\n\tgoto L_037A;\nL_037A:\n\tv753 = this.rms;\n\tv1838 = *([v753 @ X8_v70 (ModelMaterials[])+v407 @ X23_v13 (System.Int32)]) == 0;\n\tv717 = ~v1838;\nL_FFFFFFFF:\n\tv252 = v254;\nL_FFFFFFFF:\n\tv275 = v277;\nL_FFFFFFFF:\n\tv357 = v617.z;\nL_FFFFFFFF:\n\tv830 = v617;\nL_FFFFFFFF:\n\tv367 = v617.y;\nL_FFFFFFFF:\n\tv391 = v760.identity;\nL_FFFFFFFF:\n\tv604 = cbuf;\nL_FFFFFFFF:\n\tv788 = this;\n\tif (v717) goto L_02E1;\n\tthrow System.NullReferenceException;\nL_0394:\n\tgoto L_039E;\nL_03A5:\n\tv919 = v252 - v367;\n\tv920 = v275 - v830;\n\tgoto L_03B6;\n\tv1049 = v962 / v1005;\n\tv1070 = v999 + v998;\n\tv1079 = *([v624 @ X25_v6 (System.Int32)]);\nL_FFFFFFFF:\n\tv268 = v1049;\n\tgoto L_0404;\nL_03F0:\n\tgoto L_03FB;\nL_042B:\n\t// 1067 MakeStruct v92 @ AGG771B034_0_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v275 @ V11_v5 (UnityEngine.Vector3), v252 @ stack_-E0_v4 (UnityEngine.Vector3), v916 @ V1.S1\n\t// 1068 MakeStruct v88 @ AGG771B034_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v610 @ V8_v8 (System.Single), v1093 @ V0_v14 (System.Single), v1150 @ V4.S1\n\tv1158 = UnityEngine.Physics::BoxCastNonAlloc(v92, v88, v268, *([v1095 @ X8_v25+1E0]), v391, v230, v1116);\n\tv1181 = v1158 < 1;\n\tif (v1181) goto L_047C;\nL_FFFFFFFF:\n\tv783 = 0x20;\nL_FFFFFFFF:\n\tv800 = 0;\n\tv1516 = *([v1502 @ X8_v31+1E0]) + v783;\n\tv705 = UnityEngine.RaycastHit::get_collider(v1516);\n\tv706 = UnityEngine\n// ... truncated")]
		private unsafe void CheckOcclusionAccurate(CommandBuffer cbuf, Camera cam)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::CheckOcclusionAccurate");
		}

		[Token(Token = "0x6000090")]
		[Address(RVA = "0x7724198", Offset = "0x7724198", Length = "0x374")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tSystem.Collections.Generic.List`1<UnityEngine.Transform>::Clear(occluders);\n\tv67 = occluders.Count < 1;\n\tv114 = camera;\n\tif (v67) goto L_0046;\n\tv114 = 0;\nL_0046:\n\tv163 = this.perCameraOcclusionData == 0;\n\tif (v163) goto L_0110;\n\tv155 = System.Collections.Generic.Dictionary`2<UnityEngine.Camera, HighlightPlus.HighlightEffect+PerCameraOcclusionData>::TryGetValue(this.perCameraOcclusionData, camera, &v110 @ stack_-48_v4 (HighlightPlus.HighlightEffect+PerCameraOcclusionData));\n\tv210 = ~v155;\n\tif (v210) goto L_008E;\n\tv164 = v110 == 0;\n\tv114 = camera;\n\tif (v164) goto L_0110;\n\tgoto L_005D;\nL_005D:\n\tv367 = UnityEngine.Object::op_Inequality(v110.cachedOccluderCollider, 0);\n\tv370 = ~v367;\n\tif (v370) goto L_0098;\n\tv165 = v110 == 0;\n\tv114 = 0;\n\tif (v165) goto L_0110;\n\tv166 = v110.cachedOccluderCollider == 0;\n\tv114 = 0;\n\tif (v166) goto L_0110;\n\tv158 = UnityEngine.Component::get_transform(v110.cachedOccluderCollider);\n\tv389 = occluders._version + 1;\n\toccluders._version = v389;\n\tv167 = occluders._items == 0;\n\tv114 = 0;\n\tif (v167) goto L_0110;\n\tgoto L_0101;\nL_008E:\n\treturn;\nL_0098:\n\tv168 = v110 == 0;\n\tv114 = 0;\n\tif (v168) goto L_0110;\n\tv169 = v110.cachedOccluders == 0;\n\tv114 = 0;\n\tif (v169) goto L_0110;\n\tv385 = System.Collections.Generic.List`1<UnityEngine.Renderer>::GetEnumerator(v110.cachedOccluders);\n\tv72 = v385._list;\n\tgoto L_00BB;\nL_00B8:\n\tSystem.Collections.Generic.List`1<UnityEngine.Transform>::Add(occluders, v443);\nL_00BB:\n\tv427 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v72 @ stack_-60_v3 (System.Collections.Generic.List`1<UnityEngine.Renderer>));\n\tv342 = v427 == 0;\n\tif (v342) goto L_00F2;\n\tgoto L_00C9;\nL_00C9:\n\tv415 = UnityEngine.Object::op_Inequality(v385.Current, 0);\n\tv419 = v415 == 0;\n\tif (v419) goto L_00BB;\n\tv440 = v385.Current == 0;\n\tif (v440) goto L_010C;\n\tv443 = UnityEngine.Component::get_transform(v385.Current);\n\tgoto L_00B8;\nL_00F2:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v72 @ stack_-60_v3 (System.Collections.Generic.List`1<UnityEngine.Renderer>));\n\treturn;\nL_0101:\n\tSystem.Collections.Generic.List`1<UnityEngine.Transform>::Add(occluders, v158);\n\treturn;\nL_010C:\n\tv444 = new System.NullReferenceException();\n\tv114 = v443;\n\tgoto L_010F;\nL_010F:\n\t// 271 Interrupt\n\tv93 = 0;\nL_0120:\n\tv206 = v114 != 1;\n\tv223 = v183;\n\tif (v206) goto L_0132;\n\tv212 = 0x8BF5BC4(v183, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv288 = 0x8BF5BF4(v212, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v72 @ stack_-60_v3 (System.Collections.Generic.List`1<UnityEngine.Renderer>));\n\tv220 = *([v212 @ X0_v11]) == 0;\n\tif (v220) goto L_008E;\n\tv218 = new System.OutOfMemoryException();\n\tv93 = *([v212 @ X0_v11]);\n\tv223 = v218;\n\treturn;\nL_002E:\n\tv50 = occluders == 0;\n\tv114 = camera;\n\tif (v50) goto L_0110;\nL_0110:\n\tv183 = new System.NullReferenceException();\n\tgoto L_0120;\nL_0132:\n\tv226 = 0x359AB80(&v93 @ stack_-78 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv290 = 0x8BF0368(v223, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv340 = 0xA1B8(v290, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void GetOccluders(Camera camera, List<Transform> occluders)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::GetOccluders");
		}

		[Token(Token = "0x6000091")]
		[Address(RVA = "0x772450C", Offset = "0x772450C", Length = "0x3E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tthis.targetFXGroundLayerMask = v134;\n\tthis.targetFXTransitionDuration = 0.1250000293366611d;\n\tthis.targetFXVisibility = 1;\n\tthis.iconFXLightColor = 0;\n\tthis.iconFXDarkColor = *([92A1430]);\n\tthis.iconFXRotationSpeed = 50f;\n\tthis.iconFXAnimationAmount = 32.000007367134096d;\n\tthis.iconFXScale = 1f;\n\tthis.iconFXOffset = *([92A4660]);\n\tthis.iconFXStayDuration = 1.5f;\n\tthis.labelText = \"Label\";\n\tthis.labelTextSize = *([930A980]);\n\tthis.labelColor.a = 1f;\n\tthis.labelLineLength = 200f;\n\tthis.labelFollowCursor = 1;\n\tthis.labelShowInEditorMode = 1;\n\tthis.labelMaxDistance = 13510801146249216d;\n\tthis.labelScaleMin = 1f;\n\tthis.seeThrough = 2;\n\tv161 = UnityEngine.LayerMask::op_Implicit(-1);\n\tthis.seeThroughOccluderMask = v161;\n\tthis.seeThroughOccluderThreshold = 0.3f;\n\tthis.seeThroughOccluderCheckInterval = 1f;\n\tthis.seeThroughIntensity = *([930A990]);\n\tthis.seeThroughTintColor.b = 0.0078125d;\n\tthis.seeThroughNoise = 1f;\n\tthis.seeThroughBorderColor = *([9245650]);\n\tthis.seeThroughBorderWidth = 0.45f;\n\tthis.seeThroughTextureScale = 1f;\n\tv171 = new System.Collections.Generic.Dictionary`2<UnityEngine.Camera, HighlightPlus.HighlightEffect+PerCameraOcclusionData>();\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Camera, HighlightPlus.HighlightEffect+PerCameraOcclusionData>::.ctor(v171);\n\tthis.perCameraOcclusionData = v171;\n\tv182 = new System.Collections.Generic.List`1<UnityEngine.Renderer>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Renderer>::.ctor(v182);\n\tthis.tempRR = v182;\n\tthis.hitFxFadeOutDuration = *([930A9A0]);\n\tthis.hitFxColor.a = 1f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\nL_002C:\n\tv61 = UnityEngine.LayerMask::op_Implicit(-1);\n\tthis.camerasLayerMask = v61;\n\tv67 = UnityEngine.LayerMask::op_Implicit(-1);\n\tthis.effectGroupLayer = v67;\n\tthis.cullBackFaces = 1;\n\tthis.GPUInstancing = 1;\n\tthis.optimizeSkinnedMesh = 1;\n\tthis.cameraDistanceFadeFar = 1000f;\n\tthis.constantWidth = 1;\n\tthis.subMeshMask = -1;\n\tthis.overlayColor = *([930A950]);\n\tthis.overlayAnimationSpeed = 3.0517585344114195E-05d;\n\tthis.overlayBlending = 1f;\n\tthis.overlayTextureUVSpace = 0x3F80000000000001;\n\tthis.overlayPatternScale = 1.4901167006038663E-09d;\n\tthis.overlayPatternSoftness = 0.02f;\n\tthis.outline = *([92456C0]);\n\tthis.outlineColor.a = 1f;\n\tthis.outlineWidth = 0.45f;\n\tthis.outlineBlurPasses = 6.365987374E-314d;\n\tthis.outlineEdgeThreshold = 0.995f;\n\tthis.outlineDistanceScaleBias = 0.007812501914486347d;\n\tthis.outlineDownsampling = 1;\n\tthis.outlineGradientKnee = 131072.0306640625d;\n\t// 97 NotImplemented \"Instruction DUP not yet implemented.\"\n\tthis.outlinePatternScale = 131072.0306640625d;\n\tthis.outlinePatternDistortionAmount = 0.5f;\n\tthis.outlinePatternStopMotionScale = 5f;\n\tthis.outlineDashWidth = 3.814698734672106E-07d;\n\tthis.outlineDashSpeed = 2f;\n\tthis.glowWidth = 0.4f;\n\tthis.glowHighPrecision = 1;\n\tthis.glowDistanceScaleBias = 25f;\n\tthis.glowHQColor = *([930A960]);\n\tthis.glowDithering = 1f;\n\tthis.glowMagicNumber1 = 3.0517585315692486E-05d;\n\tthis.glowAnimationSpeed = 1f;\n\tthis.glowBlendPasses = 1;\n\tthis.innerGlowWidth = 0f;\n\tthis.innerGlowColor.b = 1f;\n\tthis.focusColor = *([930A970]);\n\tthis.focusBlurDownsampling = 2;\n\tthis.targetFXFrameWidth = 0.1f;\n\tthis.targetFXGroundMinAltitude = -1000f;\n\tthis.targetFXColor = 0;\n\tthis.targetFXRotationSpeed = 50f;\n\tthis.targetFXInitialScale = 0.12500003003515303d;\n\tthis.targetFXScaleToRenderBounds = 1;\n\tthis.targetFXSquare = 1;\n\tthis.targetFXFadePower = 32f;\n\tv134 = UnityEngine.LayerMask::op_Implicit(-1);\n")]
		public HighlightEffect()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightEffect::.ctor");
		}

		[Token(Token = "0x6000092")]
		[Address(RVA = "0x77248F0", Offset = "0x77248F0", Length = "0x3AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_005C;\n\tv91 = new System.Collections.Generic.List`1<UnityEngine.Vector4>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector4>::.ctor(v91);\n\tv101.matDataDirection = v91;\n\tv109 = new System.Collections.Generic.List`1<UnityEngine.Vector4>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector4>::.ctor(v109);\n\tv119.matDataGlow = v109;\n\tv127 = new System.Collections.Generic.List`1<UnityEngine.Vector4>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector4>::.ctor(v127);\n\tv137.matDataColor = v127;\n\tv145 = new System.Collections.Generic.Dictionary`2<UnityEngine.Vector3, System.Int32>();\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Vector3, System.Int32>::.ctor(v145);\n\tv155.vv = v145;\n\tv165 = new System.Collections.Generic.List`1<UnityEngine.Material>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Material>::.ctor(v165);\n\tv173.rendererSharedMaterials = v165;\n\tv178 = new System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Mesh>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Mesh>::.ctor(v178);\n\tv182.smoothMeshes = v178;\n\tv187 = new System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Mesh>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Mesh>::.ctor(v187);\n\tv191.reorientedMeshes = v187;\n\tv198 = new System.Collections.Generic.Dictionary`2<UnityEngine.Mesh, System.Collections.Generic.HashSet`1<HighlightPlus.HighlightEffect>>();\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Mesh, System.Collections.Generic.HashSet`1<HighlightPlus.HighlightEffect>>::.ctor(v198);\n\tv204.sharedMeshUsage = v198;\n\tv209 = new System.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Mesh>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, UnityEngine.Mesh>::.ctor(v209);\n\tv213.combinedMeshes = v209;\n\tv220 = new System.Collections.Generic.List`1<HighlightPlus.HighlightSeeThroughOccluder>();\n\tSystem.Collections.Generic.List`1<HighlightPlus.HighlightSeeThroughOccluder>::.ctor(v220);\n\tv226.occluders = v220;\n\tv233 = new System.Collections.Generic.Dictionary`2<UnityEngine.Camera, System.Int32>();\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Camera, System.Int32>::.ctor(v233);\n\tv239.occludersFrameCount = v233;\n\treturn;\nL_005C:\n\tv73 = new System.Collections.Generic.List`1<HighlightPlus.HighlightEffect>();\n\tSystem.Collections.Generic.List`1<HighlightPlus.HighlightEffect>::.ctor(v73);\n\tv83.effects = v73;\n")]
		static HighlightEffect()
		{
			List<HighlightEffect> list = new List<HighlightEffect>();
			effects = list;
			List<Vector4> list2 = new List<Vector4>();
			matDataDirection = list2;
			List<Vector4> list3 = new List<Vector4>();
			matDataGlow = list3;
			List<Vector4> list4 = new List<Vector4>();
			matDataColor = list4;
			Dictionary<Vector3, int> dictionary = new Dictionary<Vector3, int>();
			vv = dictionary;
			List<Material> list5 = new List<Material>();
			rendererSharedMaterials = list5;
			Dictionary<int, Mesh> dictionary2 = new Dictionary<int, Mesh>();
			smoothMeshes = dictionary2;
			Dictionary<int, Mesh> dictionary3 = new Dictionary<int, Mesh>();
			reorientedMeshes = dictionary3;
			Dictionary<Mesh, HashSet<HighlightEffect>> dictionary4 = new Dictionary<Mesh, HashSet<HighlightEffect>>();
			sharedMeshUsage = dictionary4;
			Dictionary<int, Mesh> dictionary5 = new Dictionary<int, Mesh>();
			combinedMeshes = dictionary5;
			List<HighlightSeeThroughOccluder> list6 = new List<HighlightSeeThroughOccluder>();
			occluders = list6;
			Dictionary<Camera, int> dictionary6 = new Dictionary<Camera, int>();
			occludersFrameCount = dictionary6;
		}
	}
}
