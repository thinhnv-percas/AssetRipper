using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Serialization;

namespace HighlightPlus
{
	[CreateAssetMenu(menuName = "Highlight Plus Profile", fileName = "Highlight Plus Profile", order = 100)]
	[HelpURL("https://kronnect.com/docs/highlight-plus/")]
	[Token(Token = "0x2000033")]
	public class HighlightProfile : ScriptableObject
	{
		[Tooltip("Different options to specify which objects are affected by this Highlight Effect component.")]
		[Token(Token = "0x4000252")]
		[FieldOffset(Offset = "0x18")]
		public TargetOptions effectGroup;

		[Tooltip("The layer that contains the affected objects by this effect when effectGroup is set to LayerMask.")]
		[Token(Token = "0x4000253")]
		[FieldOffset(Offset = "0x1C")]
		public LayerMask effectGroupLayer;

		[Tooltip("Only include objects whose names contains this text.")]
		[Token(Token = "0x4000254")]
		[FieldOffset(Offset = "0x20")]
		public string effectNameFilter;

		[Tooltip("Use RegEx to determine if an object name matches the effectNameFilter.")]
		[Token(Token = "0x4000255")]
		[FieldOffset(Offset = "0x28")]
		public bool effectNameUseRegEx;

		[Tooltip("Exclude objects that already have a Highlight Effect component when using Include options.")]
		[Token(Token = "0x4000256")]
		[FieldOffset(Offset = "0x29")]
		public bool excludeObjectsWithHighlightEffect;

		[Tooltip("Combine meshes of all objects in this group affected by Highlight Effect reducing draw calls.")]
		[Token(Token = "0x4000257")]
		[FieldOffset(Offset = "0x2A")]
		public bool combineMeshes;

		[Tooltip("The alpha threshold for transparent cutout objects. Pixels with alpha below this value will be discarded.")]
		[Range(0f, 1f)]
		[Token(Token = "0x4000258")]
		[FieldOffset(Offset = "0x2C")]
		public float alphaCutOff;

		[Tooltip("Optional custom texture property name used for alpha clipping; if not found, falls back to _BaseMap or _MainTex.")]
		[Token(Token = "0x4000259")]
		[FieldOffset(Offset = "0x30")]
		public string alphaCutOffTextureName;

		[Tooltip("If back facing triangles are ignored.Backfaces triangles are not visible but you may set this property to false to force highlight effects to act on those triangles as well.")]
		[Token(Token = "0x400025A")]
		[FieldOffset(Offset = "0x38")]
		public bool cullBackFaces;

		[Tooltip("Normals handling option:\nPreserve original: use original mesh normals.\nSmooth: average normals to produce a smoother outline/glow mesh based effect.\nReorient: recomputes normals based on vertex direction to centroid.")]
		[Token(Token = "0x400025B")]
		[FieldOffset(Offset = "0x3C")]
		public NormalsOption normalsOption;

		[Token(Token = "0x400025C")]
		[FieldOffset(Offset = "0x40")]
		public float fadeInDuration;

		[Token(Token = "0x400025D")]
		[FieldOffset(Offset = "0x44")]
		public float fadeOutDuration;

		[Tooltip("Fades out effects based on distance to camera")]
		[Token(Token = "0x400025E")]
		[FieldOffset(Offset = "0x48")]
		public bool cameraDistanceFade;

		[Tooltip("The closest distance particles can get to the camera before they fade from the camera's view.")]
		[Token(Token = "0x400025F")]
		[FieldOffset(Offset = "0x4C")]
		public float cameraDistanceFadeNear;

		[Tooltip("The farthest distance particles can get away from the camera before they fade from the camera's view.")]
		[Token(Token = "0x4000260")]
		[FieldOffset(Offset = "0x50")]
		public float cameraDistanceFadeFar;

		[Tooltip("Keeps the outline/glow size unaffected by object distance.")]
		[Token(Token = "0x4000261")]
		[FieldOffset(Offset = "0x54")]
		public bool constantWidth;

		[Tooltip("Increases the screen coverage for the outline/glow to avoid cuts when using cloth or vertex shader that transform mesh vertices")]
		[Token(Token = "0x4000262")]
		[FieldOffset(Offset = "0x58")]
		public int extraCoveragePixels;

		[Tooltip("Minimum width when the constant width option is not used")]
		[Range(0f, 1f)]
		[Token(Token = "0x4000263")]
		[FieldOffset(Offset = "0x5C")]
		public float minimumWidth;

		[Range(0f, 1f)]
		[Tooltip("Intensity of the overlay effect. A value of 0 disables the overlay completely.")]
		[Token(Token = "0x4000264")]
		[FieldOffset(Offset = "0x60")]
		public float overlay;

		[Token(Token = "0x4000265")]
		[FieldOffset(Offset = "0x64")]
		public OverlayMode overlayMode;

		[ColorUsage(false, true)]
		[Token(Token = "0x4000266")]
		[FieldOffset(Offset = "0x68")]
		public Color overlayColor;

		[Token(Token = "0x4000267")]
		[FieldOffset(Offset = "0x78")]
		public float overlayAnimationSpeed;

		[Range(0f, 1f)]
		[Token(Token = "0x4000268")]
		[FieldOffset(Offset = "0x7C")]
		public float overlayMinIntensity;

		[Range(0f, 1f)]
		[Tooltip("Controls the blending or mix of the overlay color with the natural colors of the object.")]
		[Token(Token = "0x4000269")]
		[FieldOffset(Offset = "0x80")]
		public float overlayBlending;

		[Tooltip("Optional overlay texture.")]
		[Token(Token = "0x400026A")]
		[FieldOffset(Offset = "0x88")]
		public Texture2D overlayTexture;

		[Token(Token = "0x400026B")]
		[FieldOffset(Offset = "0x90")]
		public TextureUVSpace overlayTextureUVSpace;

		[Token(Token = "0x400026C")]
		[FieldOffset(Offset = "0x94")]
		public float overlayTextureScale;

		[Token(Token = "0x400026D")]
		[FieldOffset(Offset = "0x98")]
		public Vector2 overlayTextureScrolling;

		[Token(Token = "0x400026E")]
		[FieldOffset(Offset = "0xA0")]
		public Visibility overlayVisibility;

		[Tooltip("Optional overlay pattern texture.")]
		[Token(Token = "0x400026F")]
		[FieldOffset(Offset = "0xA4")]
		public OverlayPattern overlayPattern;

		[Token(Token = "0x4000270")]
		[FieldOffset(Offset = "0xA8")]
		public Vector2 overlayPatternScrolling;

		[Tooltip("Scale of the overlay pattern")]
		[Range(1f, 100f)]
		[Token(Token = "0x4000271")]
		[FieldOffset(Offset = "0xB0")]
		public float overlayPatternScale;

		[Tooltip("Size/Thickness of the overlay pattern")]
		[Range(0.01f, 1f)]
		[Token(Token = "0x4000272")]
		[FieldOffset(Offset = "0xB4")]
		public float overlayPatternSize;

		[Tooltip("Softness of the overlay pattern")]
		[Range(0.01f, 0.5f)]
		[Token(Token = "0x4000273")]
		[FieldOffset(Offset = "0xB8")]
		public float overlayPatternSoftness;

		[Tooltip("Rotation angle for the overlay pattern in degrees")]
		[Range(-180f, 180f)]
		[Token(Token = "0x4000274")]
		[FieldOffset(Offset = "0xBC")]
		public float overlayPatternRotation;

		[Range(0f, 1f)]
		[Tooltip("Intensity of the outline. A value of 0 disables the outline completely.")]
		[Token(Token = "0x4000275")]
		[FieldOffset(Offset = "0xC0")]
		public float outline;

		[ColorUsage(true, true)]
		[Token(Token = "0x4000276")]
		[FieldOffset(Offset = "0xC4")]
		public Color outlineColor;

		[Token(Token = "0x4000277")]
		[FieldOffset(Offset = "0xD4")]
		public ColorStyle outlineColorStyle;

		[GradientUsage(true, ColorSpace.Linear)]
		[Token(Token = "0x4000278")]
		[FieldOffset(Offset = "0xD8")]
		public Gradient outlineGradient;

		[Token(Token = "0x4000279")]
		[FieldOffset(Offset = "0xE0")]
		public bool outlineGradientInLocalSpace;

		[Range(1f, 3f)]
		[Token(Token = "0x400027A")]
		[FieldOffset(Offset = "0xE4")]
		public int outlineBlurPasses;

		[Token(Token = "0x400027B")]
		[FieldOffset(Offset = "0xE8")]
		public float outlineWidth;

		[Token(Token = "0x400027C")]
		[FieldOffset(Offset = "0xEC")]
		public QualityLevel outlineQuality;

		[Token(Token = "0x400027D")]
		[FieldOffset(Offset = "0xF0")]
		public OutlineEdgeMode outlineEdgeMode;

		[Token(Token = "0x400027E")]
		[FieldOffset(Offset = "0xF4")]
		public float outlineEdgeThreshold;

		[Tooltip("Controls how quickly the outline effect scales down with distance when constant width is disabled. Lower values make the effect fade faster with distance.")]
		[Token(Token = "0x400027F")]
		[FieldOffset(Offset = "0xF8")]
		public float outlineDistanceScaleBias;

		[Token(Token = "0x4000280")]
		[FieldOffset(Offset = "0xFC")]
		public float outlineSharpness;

		[Range(1f, 8f)]
		[Tooltip("Reduces the quality of the outline but improves performance a bit.")]
		[Token(Token = "0x4000281")]
		[FieldOffset(Offset = "0x100")]
		public int outlineDownsampling;

		[Token(Token = "0x4000282")]
		[FieldOffset(Offset = "0x104")]
		public ContourStyle outlineContourStyle;

		[Token(Token = "0x4000283")]
		[FieldOffset(Offset = "0x108")]
		public float outlineGradientKnee;

		[Token(Token = "0x4000284")]
		[FieldOffset(Offset = "0x10C")]
		public float outlineGradientPower;

		[Tooltip("Enables stylized outline effect.")]
		[Token(Token = "0x4000285")]
		[FieldOffset(Offset = "0x110")]
		public bool outlineStylized;

		[Tooltip("Pattern texture used for the stylized outline effect.")]
		[Token(Token = "0x4000286")]
		[FieldOffset(Offset = "0x118")]
		public Texture2D outlinePattern;

		[Tooltip("Scale of the pattern texture.")]
		[Token(Token = "0x4000287")]
		[FieldOffset(Offset = "0x120")]
		public float outlinePatternScale;

		[Tooltip("Threshold for the pattern texture.")]
		[Range(0f, 1f)]
		[Token(Token = "0x4000288")]
		[FieldOffset(Offset = "0x124")]
		public float outlinePatternThreshold;

		[Tooltip("Distortion amount for the pattern texture.")]
		[Range(0f, 1.5f)]
		[Token(Token = "0x4000289")]
		[FieldOffset(Offset = "0x128")]
		public float outlinePatternDistortionAmount;

		[Tooltip("Stop motion scale for the distortion effect.")]
		[Token(Token = "0x400028A")]
		[FieldOffset(Offset = "0x12C")]
		public float outlinePatternStopMotionScale;

		[Tooltip("Distortion texture used for the stylized outline effect.")]
		[Token(Token = "0x400028B")]
		[FieldOffset(Offset = "0x130")]
		public Texture2D outlinePatternDistortionTexture;

		[Tooltip("Adds a empty margin between the outline mesh and the effects")]
		[Range(0f, 1f)]
		[Token(Token = "0x400028C")]
		[FieldOffset(Offset = "0x138")]
		public float padding;

		[Tooltip("Makes the outline pixelated. A value of 0 disables pixelation. Higher values produce bigger pixels.")]
		[Range(0f, 32f)]
		[Token(Token = "0x400028D")]
		[FieldOffset(Offset = "0x13C")]
		public int outlinePixelation;

		[Tooltip("Enables dashed outline effect.")]
		[Token(Token = "0x400028E")]
		[FieldOffset(Offset = "0x140")]
		public bool outlineDashed;

		[Tooltip("Width of the dashed outline.")]
		[Range(0f, 1f)]
		[Token(Token = "0x400028F")]
		[FieldOffset(Offset = "0x144")]
		public float outlineDashWidth;

		[Tooltip("Gap of the dashed outline.")]
		[Range(0f, 1f)]
		[Token(Token = "0x4000290")]
		[FieldOffset(Offset = "0x148")]
		public float outlineDashGap;

		[Tooltip("Speed of the dashed outline.")]
		[Token(Token = "0x4000291")]
		[FieldOffset(Offset = "0x14C")]
		public float outlineDashSpeed;

		[Token(Token = "0x4000292")]
		[FieldOffset(Offset = "0x150")]
		public Visibility outlineVisibility;

		[Tooltip("If enabled, this object won't combine the outline with other objects.")]
		[Token(Token = "0x4000293")]
		[FieldOffset(Offset = "0x154")]
		public bool outlineIndependent;

		[Tooltip("Select the mask mode used with this effect.")]
		[Token(Token = "0x4000294")]
		[FieldOffset(Offset = "0x158")]
		public MaskMode outlineMaskMode;

		[Range(0f, 5f)]
		[Tooltip("The intensity of the outer glow effect. A value of 0 disables the glow completely.")]
		[Token(Token = "0x4000295")]
		[FieldOffset(Offset = "0x15C")]
		public float glow;

		[Token(Token = "0x4000296")]
		[FieldOffset(Offset = "0x160")]
		public float glowWidth;

		[Token(Token = "0x4000297")]
		[FieldOffset(Offset = "0x164")]
		public QualityLevel glowQuality;

		[Token(Token = "0x4000298")]
		[FieldOffset(Offset = "0x168")]
		public BlurMethod glowBlurMethod;

		[Token(Token = "0x4000299")]
		[FieldOffset(Offset = "0x16C")]
		public bool glowHighPrecision;

		[Tooltip("Controls how quickly the glow effect scales down with distance when constant width is disabled. Lower values make the effect fade faster with distance.")]
		[Token(Token = "0x400029A")]
		[FieldOffset(Offset = "0x170")]
		public float glowDistanceScaleBias;

		[Range(1f, 8f)]
		[Tooltip("Reduces the quality of the glow but improves performance a bit.")]
		[Token(Token = "0x400029B")]
		[FieldOffset(Offset = "0x174")]
		public int glowDownsampling;

		[ColorUsage(true, true)]
		[Token(Token = "0x400029C")]
		[FieldOffset(Offset = "0x178")]
		public Color glowHQColor;

		[Tooltip("When enabled, outer glow renders with dithering. When disabled, glow appears as a solid color.")]
		[Range(0f, 1f)]
		[Token(Token = "0x400029D")]
		[FieldOffset(Offset = "0x188")]
		public float glowDithering;

		[Token(Token = "0x400029E")]
		[FieldOffset(Offset = "0x18C")]
		public GlowDitheringStyle glowDitheringStyle;

		[Tooltip("Seed for the dithering effect")]
		[Token(Token = "0x400029F")]
		[FieldOffset(Offset = "0x190")]
		public float glowMagicNumber1;

		[Tooltip("Another seed for the dithering effect that combines with first seed to create different patterns")]
		[Token(Token = "0x40002A0")]
		[FieldOffset(Offset = "0x194")]
		public float glowMagicNumber2;

		[Token(Token = "0x40002A1")]
		[FieldOffset(Offset = "0x198")]
		public float glowAnimationSpeed;

		[Token(Token = "0x40002A2")]
		[FieldOffset(Offset = "0x19C")]
		public Visibility glowVisibility;

		[Token(Token = "0x40002A3")]
		[FieldOffset(Offset = "0x1A0")]
		public GlowBlendMode glowBlendMode;

		[Tooltip("Blends glow passes one after another. If this option is disabled, glow passes won't overlap (in this case, make sure the glow pass 1 has a smaller offset than pass 2, etc.)")]
		[Token(Token = "0x40002A4")]
		[FieldOffset(Offset = "0x1A4")]
		public bool glowBlendPasses;

		[Token(Token = "0x40002A5")]
		[FieldOffset(Offset = "0x1A8")]
		public GlowPassData[] glowPasses;

		[Tooltip("Select the mask mode used with this effect.")]
		[Token(Token = "0x40002A6")]
		[FieldOffset(Offset = "0x1B0")]
		public MaskMode glowMaskMode;

		[Tooltip("Makes the glow pixelated. A value of 0 disables pixelation. Higher values produce bigger pixels.")]
		[Range(0f, 32f)]
		[Token(Token = "0x40002A7")]
		[FieldOffset(Offset = "0x1B4")]
		public int glowPixelation;

		[Range(0f, 5f)]
		[Tooltip("The intensity of the inner glow effect. A value of 0 disables the glow completely.")]
		[Token(Token = "0x40002A8")]
		[FieldOffset(Offset = "0x1B8")]
		public float innerGlow;

		[Range(0f, 2f)]
		[Token(Token = "0x40002A9")]
		[FieldOffset(Offset = "0x1BC")]
		public float innerGlowWidth;

		[Token(Token = "0x40002AA")]
		[FieldOffset(Offset = "0x1C0")]
		public float innerGlowPower;

		[Token(Token = "0x40002AB")]
		[FieldOffset(Offset = "0x1C4")]
		public InnerGlowBlendMode innerGlowBlendMode;

		[ColorUsage(true, true)]
		[Token(Token = "0x40002AC")]
		[FieldOffset(Offset = "0x1C8")]
		public Color innerGlowColor;

		[Token(Token = "0x40002AD")]
		[FieldOffset(Offset = "0x1D8")]
		public Visibility innerGlowVisibility;

		[Range(0f, 1f)]
		[Tooltip("Intensity of the focus effect. A value of 0 disables the focus effect completely.")]
		[Token(Token = "0x40002AE")]
		[FieldOffset(Offset = "0x1DC")]
		public float focus;

		[Tooltip("Color and transparency of the focus dim overlay.")]
		[Token(Token = "0x40002AF")]
		[FieldOffset(Offset = "0x1E0")]
		public Color focusColor;

		[Range(0f, 1f)]
		[Tooltip("Optional background blur intensity for the focus effect.")]
		[Token(Token = "0x40002B0")]
		[FieldOffset(Offset = "0x1F0")]
		public float focusBlur;

		[Range(1f, 8f)]
		[Tooltip("Downsampling factor for the focus blur. Higher values improve performance at the cost of quality.")]
		[Token(Token = "0x40002B1")]
		[FieldOffset(Offset = "0x1F4")]
		public int focusBlurDownsampling;

		[Range(0f, 1f)]
		[Tooltip("Desaturation intensity for the focus background. A value of 1 makes the background fully grayscale.")]
		[Token(Token = "0x40002B2")]
		[FieldOffset(Offset = "0x1F8")]
		public float focusDesaturation;

		[Tooltip("Enables the targetFX effect. This effect draws an animated sprite over the object.")]
		[Token(Token = "0x40002B3")]
		[FieldOffset(Offset = "0x1FC")]
		public bool targetFX;

		[Tooltip("Style of the target FX effect.")]
		[Token(Token = "0x40002B4")]
		[FieldOffset(Offset = "0x200")]
		public TargetFXStyle targetFXStyle;

		[Tooltip("Width of the frame when using Frame style.")]
		[Range(0.001f, 0.5f)]
		[Token(Token = "0x40002B5")]
		[FieldOffset(Offset = "0x204")]
		public float targetFXFrameWidth;

		[Tooltip("Length of the frame corners when using Frame style.")]
		[Range(0.1f, 1f)]
		[Token(Token = "0x40002B6")]
		[FieldOffset(Offset = "0x208")]
		public float targetFXCornerLength;

		[Tooltip("Minimum opacity of the frame when using Frame style.")]
		[Range(0f, 1f)]
		[Token(Token = "0x40002B7")]
		[FieldOffset(Offset = "0x20C")]
		public float targetFXFrameMinOpacity;

		[Token(Token = "0x40002B8")]
		[FieldOffset(Offset = "0x210")]
		public Texture2D targetFXTexture;

		[ColorUsage(true, true)]
		[Token(Token = "0x40002B9")]
		[FieldOffset(Offset = "0x218")]
		public Color targetFXColor;

		[Token(Token = "0x40002BA")]
		[FieldOffset(Offset = "0x228")]
		public float targetFXRotationSpeed;

		[Token(Token = "0x40002BB")]
		[FieldOffset(Offset = "0x22C")]
		public float targetFXRotationAngle;

		[Token(Token = "0x40002BC")]
		[FieldOffset(Offset = "0x230")]
		public float targetFXInitialScale;

		[Token(Token = "0x40002BD")]
		[FieldOffset(Offset = "0x234")]
		public float targetFXEndScale;

		[Tooltip("Makes target scale relative to object renderer bounds.")]
		[Token(Token = "0x40002BE")]
		[FieldOffset(Offset = "0x238")]
		public bool targetFXScaleToRenderBounds;

		[Tooltip("Makes target FX effect square")]
		[Token(Token = "0x40002BF")]
		[FieldOffset(Offset = "0x239")]
		public bool targetFXSquare;

		[Tooltip("Places target FX sprite at the bottom of the highlighted object.")]
		[Token(Token = "0x40002C0")]
		[FieldOffset(Offset = "0x23A")]
		public bool targetFXAlignToGround;

		[Tooltip("Max distance from the center of the highlighted object to the ground.")]
		[Token(Token = "0x40002C1")]
		[FieldOffset(Offset = "0x23C")]
		public float targetFXGroundMaxDistance;

		[Token(Token = "0x40002C2")]
		[FieldOffset(Offset = "0x240")]
		public LayerMask targetFXGroundLayerMask;

		[Tooltip("Fade out effect with altitude")]
		[Token(Token = "0x40002C3")]
		[FieldOffset(Offset = "0x244")]
		public float targetFXFadePower;

		[Tooltip("Enable to render a single target FX effect at the center of the enclosing bounds")]
		[Token(Token = "0x40002C4")]
		[FieldOffset(Offset = "0x248")]
		public bool targetFXUseEnclosingBounds;

		[Tooltip("Optional world space offset for the position of the targetFX effect")]
		[Token(Token = "0x40002C5")]
		[FieldOffset(Offset = "0x24C")]
		public Vector3 targetFXOffset;

		[Tooltip("If enabled, the target FX effect will be centered on the hit position")]
		[Token(Token = "0x40002C6")]
		[FieldOffset(Offset = "0x258")]
		public bool targetFxCenterOnHitPosition;

		[Tooltip("If enabled, the target FX effect will align to the hit normal")]
		[Token(Token = "0x40002C7")]
		[FieldOffset(Offset = "0x259")]
		public bool targetFxAlignToNormal;

		[Token(Token = "0x40002C8")]
		[FieldOffset(Offset = "0x25C")]
		public float targetFXTransitionDuration;

		[Tooltip("0 = stay forever")]
		[Token(Token = "0x40002C9")]
		[FieldOffset(Offset = "0x260")]
		public float targetFXStayDuration;

		[Token(Token = "0x40002CA")]
		[FieldOffset(Offset = "0x264")]
		public Visibility targetFXVisibility;

		[Tooltip("If the ground is transparent, the effect won't work. You can set this property to the altitude of the transparent ground to force the effect to render at this altitude.")]
		[Token(Token = "0x40002CB")]
		[FieldOffset(Offset = "0x268")]
		public float targetFXGroundMinAltitude;

		[Tooltip("Enables the iconFX effect. This effect draws an animated object over the object.")]
		[Token(Token = "0x40002CC")]
		[FieldOffset(Offset = "0x26C")]
		public bool iconFX;

		[Token(Token = "0x40002CD")]
		[FieldOffset(Offset = "0x270")]
		public IconAssetType iconFXAssetType;

		[Token(Token = "0x40002CE")]
		[FieldOffset(Offset = "0x278")]
		public GameObject iconFXPrefab;

		[Token(Token = "0x40002CF")]
		[FieldOffset(Offset = "0x280")]
		public Mesh iconFXMesh;

		[ColorUsage(true, true)]
		[Token(Token = "0x40002D0")]
		[FieldOffset(Offset = "0x288")]
		public Color iconFXLightColor;

		[ColorUsage(true, true)]
		[Token(Token = "0x40002D1")]
		[FieldOffset(Offset = "0x298")]
		public Color iconFXDarkColor;

		[Token(Token = "0x40002D2")]
		[FieldOffset(Offset = "0x2A8")]
		public float iconFXRotationSpeed;

		[Token(Token = "0x40002D3")]
		[FieldOffset(Offset = "0x2AC")]
		public IconAnimationOption iconFXAnimationOption;

		[Token(Token = "0x40002D4")]
		[FieldOffset(Offset = "0x2B0")]
		public float iconFXAnimationAmount;

		[Token(Token = "0x40002D5")]
		[FieldOffset(Offset = "0x2B4")]
		public float iconFXAnimationSpeed;

		[Token(Token = "0x40002D6")]
		[FieldOffset(Offset = "0x2B8")]
		public float iconFXScale;

		[Tooltip("Makes target scale relative to object renderer bounds.")]
		[Token(Token = "0x40002D7")]
		[FieldOffset(Offset = "0x2BC")]
		public bool iconFXScaleToRenderBounds;

		[Tooltip("Optional world space offset for the position of the iconFX effect")]
		[Token(Token = "0x40002D8")]
		[FieldOffset(Offset = "0x2C0")]
		public Vector3 iconFXOffset;

		[Token(Token = "0x40002D9")]
		[FieldOffset(Offset = "0x2CC")]
		public float iconFXTransitionDuration;

		[Tooltip("0 = stay forever")]
		[Token(Token = "0x40002DA")]
		[FieldOffset(Offset = "0x2D0")]
		public float iconFXStayDuration;

		[Tooltip("Enables the label effect. This effect shows a text label over the object.")]
		[Token(Token = "0x40002DB")]
		[FieldOffset(Offset = "0x2D4")]
		public bool labelEnabled;

		[Tooltip("The text to display in the label")]
		[Token(Token = "0x40002DC")]
		[FieldOffset(Offset = "0x2D8")]
		public string labelText;

		[Tooltip("The size of the label text")]
		[Token(Token = "0x40002DD")]
		[FieldOffset(Offset = "0x2E0")]
		public float labelTextSize;

		[ColorUsage(true, true)]
		[Token(Token = "0x40002DE")]
		[FieldOffset(Offset = "0x2E4")]
		public Color labelColor;

		[Tooltip("The prefab to use for the label. Must contain a Canvas and TextMeshProUGUI component.")]
		[Token(Token = "0x40002DF")]
		[FieldOffset(Offset = "0x2F8")]
		public GameObject labelPrefab;

		[Token(Token = "0x40002E0")]
		[FieldOffset(Offset = "0x300")]
		public float labelVerticalOffset;

		[Token(Token = "0x40002E1")]
		[FieldOffset(Offset = "0x304")]
		public Vector2 labelViewportOffset;

		[Tooltip("The horizontal offset of the label with respect to the object bounds")]
		[FormerlySerializedAs("lineLength")]
		[Token(Token = "0x40002E2")]
		[FieldOffset(Offset = "0x30C")]
		public float labelLineLength;

		[Tooltip("If enabled, the label will follow the cursor when hovering the object")]
		[Token(Token = "0x40002E3")]
		[FieldOffset(Offset = "0x310")]
		public bool labelFollowCursor;

		[Token(Token = "0x40002E4")]
		[FieldOffset(Offset = "0x314")]
		public LabelMode labelMode;

		[Tooltip("If enabled, the label will be shown in editor mode (non playing)")]
		[Token(Token = "0x40002E5")]
		[FieldOffset(Offset = "0x318")]
		public bool labelShowInEditorMode;

		[Tooltip("Controls the alignment of the label relative to the target object on screen.")]
		[Token(Token = "0x40002E6")]
		[FieldOffset(Offset = "0x31C")]
		public LabelAlignment labelAlignment;

		[Tooltip("Enables relative alignment based on the forward direction of the alignment transform.")]
		[Token(Token = "0x40002E7")]
		[FieldOffset(Offset = "0x320")]
		public bool labelRelativeAlignment;

		[Tooltip("The transform used for relative alignment direction.")]
		[Token(Token = "0x40002E8")]
		[FieldOffset(Offset = "0x328")]
		public Transform labelAlignmentTransform;

		[Tooltip("Maximum distance from camera where the label is visible (units). Default 250.")]
		[Token(Token = "0x40002E9")]
		[FieldOffset(Offset = "0x330")]
		public float labelMaxDistance;

		[Tooltip("Distance at which label starts fading out (units). 0 disables fading.")]
		[Token(Token = "0x40002EA")]
		[FieldOffset(Offset = "0x334")]
		public float labelFadeStartDistance;

		[Tooltip("Enable distance-based scaling of label Canvas.")]
		[Token(Token = "0x40002EB")]
		[FieldOffset(Offset = "0x338")]
		public bool labelScaleByDistance;

		[Tooltip("Minimum scale when at max distance (0..1 typically). Default 1.")]
		[Token(Token = "0x40002EC")]
		[FieldOffset(Offset = "0x33C")]
		public float labelScaleMin;

		[Tooltip("Maximum scale when near camera. Default 1.")]
		[Token(Token = "0x40002ED")]
		[FieldOffset(Offset = "0x340")]
		public float labelScaleMax;

		[Tooltip("See-through mode for this Highlight Effect component.")]
		[Token(Token = "0x40002EE")]
		[FieldOffset(Offset = "0x344")]
		public SeeThroughMode seeThrough;

		[Tooltip("This mask setting let you specify which objects will be considered as occluders and cause the see-through effect for this Highlight Effect component. For example, you assign your walls to a different layer and specify that layer here, so only walls and not other objects, like ground or ceiling, will trigger the see-through effect.")]
		[Token(Token = "0x40002EF")]
		[FieldOffset(Offset = "0x348")]
		public LayerMask seeThroughOccluderMask;

		[Tooltip("Uses stencil buffers to ensure pixel-accurate occlusion test. If this option is disabled, only physics raycasting is used to test for occlusion.")]
		[Token(Token = "0x40002F0")]
		[FieldOffset(Offset = "0x34C")]
		public bool seeThroughOccluderMaskAccurate;

		[Tooltip("A multiplier for the occluder volume size which can be used to reduce the actual size of occluders when Highlight Effect checks if they're occluding this object.")]
		[Range(0.01f, 0.9f)]
		[Token(Token = "0x40002F1")]
		[FieldOffset(Offset = "0x350")]
		public float seeThroughOccluderThreshold;

		[Tooltip("The interval of time between occlusion tests.")]
		[Token(Token = "0x40002F2")]
		[FieldOffset(Offset = "0x354")]
		public float seeThroughOccluderCheckInterval;

		[Tooltip("If enabled, occlusion test is performed for each children element. If disabled, the bounds of all children is combined and a single occlusion test is performed for the combined bounds.")]
		[Token(Token = "0x40002F3")]
		[FieldOffset(Offset = "0x358")]
		public bool seeThroughOccluderCheckIndividualObjects;

		[Tooltip("Shows the see-through effect only if the occluder if at this 'offset' distance from the object.")]
		[Token(Token = "0x40002F4")]
		[FieldOffset(Offset = "0x35C")]
		public float seeThroughDepthOffset;

		[Tooltip("Hides the see-through effect if the occluder is further than this distance from the object (0 = infinite)")]
		[Token(Token = "0x40002F5")]
		[FieldOffset(Offset = "0x360")]
		public float seeThroughMaxDepth;

		[Tooltip("Fade-out width near Max Depth (0 keeps hard clip)")]
		[Token(Token = "0x40002F6")]
		[FieldOffset(Offset = "0x364")]
		public float seeThroughFadeRange;

		[Range(0f, 5f)]
		[Token(Token = "0x40002F7")]
		[FieldOffset(Offset = "0x368")]
		public float seeThroughIntensity;

		[Range(0f, 1f)]
		[Token(Token = "0x40002F8")]
		[FieldOffset(Offset = "0x36C")]
		public float seeThroughTintAlpha;

		[Token(Token = "0x40002F9")]
		[FieldOffset(Offset = "0x370")]
		public Color seeThroughTintColor;

		[Range(0f, 1f)]
		[Token(Token = "0x40002FA")]
		[FieldOffset(Offset = "0x380")]
		public float seeThroughNoise;

		[Range(0f, 1f)]
		[Token(Token = "0x40002FB")]
		[FieldOffset(Offset = "0x384")]
		public float seeThroughBorder;

		[Token(Token = "0x40002FC")]
		[FieldOffset(Offset = "0x388")]
		public Color seeThroughBorderColor;

		[Token(Token = "0x40002FD")]
		[FieldOffset(Offset = "0x398")]
		public float seeThroughBorderWidth;

		[Tooltip("Only display the border instead of the full see-through effect.")]
		[Token(Token = "0x40002FE")]
		[FieldOffset(Offset = "0x39C")]
		public bool seeThroughBorderOnly;

		[Tooltip("This option clears the stencil buffer after rendering the see-through effect which results in correct rendering order and supports other stencil-based effects that render afterwards.")]
		[Token(Token = "0x40002FF")]
		[FieldOffset(Offset = "0x39D")]
		public bool seeThroughOrdered;

		[Tooltip("Optional see-through mask effect texture.")]
		[Token(Token = "0x4000300")]
		[FieldOffset(Offset = "0x3A0")]
		public Texture2D seeThroughTexture;

		[Token(Token = "0x4000301")]
		[FieldOffset(Offset = "0x3A8")]
		public TextureUVSpace seeThroughTextureUVSpace;

		[Token(Token = "0x4000302")]
		[FieldOffset(Offset = "0x3AC")]
		public float seeThroughTextureScale;

		[Tooltip("The order by which children objects are rendered by the see-through effect")]
		[Token(Token = "0x4000303")]
		[FieldOffset(Offset = "0x3B0")]
		public SeeThroughSortingMode seeThroughChildrenSortingMode;

		[Range(0f, 1f)]
		[Token(Token = "0x4000304")]
		[FieldOffset(Offset = "0x3B4")]
		public float hitFxInitialIntensity;

		[Token(Token = "0x4000305")]
		[FieldOffset(Offset = "0x3B8")]
		public HitFxMode hitFxMode;

		[Token(Token = "0x4000306")]
		[FieldOffset(Offset = "0x3BC")]
		public HitFXTriggerMode hitFXTriggerMode;

		[Token(Token = "0x4000307")]
		[FieldOffset(Offset = "0x3C0")]
		public float hitFxFadeOutDuration;

		[ColorUsage(true, true)]
		[Token(Token = "0x4000308")]
		[FieldOffset(Offset = "0x3C4")]
		public Color hitFxColor;

		[Token(Token = "0x4000309")]
		[FieldOffset(Offset = "0x3D4")]
		public float hitFxRadius;

		[Token(Token = "0x60000FA")]
		[Address(RVA = "0x772BDE4", Offset = "0x772BDE4", Length = "0x5F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\teffect.effectGroup = this.effectGroup;\n\teffect.effectGroupLayer = this.effectGroupLayer;\n\teffect.effectNameFilter = this.effectNameFilter;\n\teffect.effectNameUseRegEx = this.effectNameUseRegEx;\n\teffect.excludeObjectsWithHighlightEffect = this.excludeObjectsWithHighlightEffect;\n\teffect.alphaCutOff = this.alphaCutOff;\n\teffect.alphaCutOffTextureName = this.alphaCutOffTextureName;\n\teffect.padding = this.padding;\n\teffect.fadeInDuration = this.fadeInDuration;\n\teffect.cameraDistanceFadeNear = this.cameraDistanceFadeNear;\n\teffect.minimumWidth = this.minimumWidth;\n\teffect.cullBackFaces = this.cullBackFaces;\n\teffect.normalsOption = this.normalsOption;\n\teffect.cameraDistanceFade = this.cameraDistanceFade;\n\teffect.constantWidth = this.constantWidth;\n\teffect.extraCoveragePixels = this.extraCoveragePixels;\n\teffect.overlay = this.overlay;\n\teffect.overlayMode = this.overlayMode;\n\teffect.overlayColor = this.overlayColor;\n\teffect.overlayAnimationSpeed = this.overlayAnimationSpeed;\n\teffect.overlayBlending = this.overlayBlending;\n\teffect.overlayTexture = this.overlayTexture;\n\teffect.overlayTextureUVSpace = this.overlayTextureUVSpace;\n\teffect.overlayTextureScale = this.overlayTextureScale;\n\teffect.overlayTextureScrolling = this.overlayTextureScrolling;\n\teffect.overlayVisibility = this.overlayVisibility;\n\teffect.overlayPattern = this.overlayPattern;\n\teffect.overlayPatternScrolling = this.overlayPatternScrolling;\n\teffect.overlayPatternScale = this.overlayPatternScale;\n\teffect.outline = this.outline;\n\teffect.outlineColor = this.outlineColor;\n\teffect.outlineColorStyle = this.outlineColorStyle;\n\teffect.outlineGradient = this.outlineGradient;\n\teffect.outlineGradientInLocalSpace = this.outlineGradientInLocalSpace;\n\teffect.outlineWidth = this.outlineWidth;\n\teffect.outlineBlurPasses = this.outlineBlurPasses;\n\teffect.outlineQuality = this.outlineQuality;\n\teffect.outlineEdgeThreshold = this.outlineEdgeThreshold;\n\teffect.outlineSharpness = this.outlineSharpness;\n\teffect.outlineDownsampling = this.outlineDownsampling;\n\teffect.outlineVisibility = this.outlineVisibility;\n\teffect.outlineIndependent = this.outlineIndependent;\n\teffect.outlineContourStyle = this.outlineContourStyle;\n\teffect.outlineMaskMode = this.outlineMaskMode;\n\teffect.outlineStylized = this.outlineStylized;\n\teffect.outlinePattern = this.outlinePattern;\n\teffect.outlinePatternScale = this.outlinePatternScale;\n\teffect.outlinePatternDistortionTexture = this.outlinePatternDistortionTexture;\n\teffect.outlinePatternDistortionAmount = this.outlinePatternDistortionAmount;\n\teffect.outlinePatternStopMotionScale = this.outlinePatternStopMotionScale;\n\teffect.outlineDashed = this.outlineDashed;\n\teffect.outlineDashWidth = this.outlineDashWidth;\n\teffect.outlineDashSpeed = this.outlineDashSpeed;\n\teffect.outlineGradientKnee = this.outlineGradientKnee;\n\teffect.outlinePixelation = this.outlinePixelation;\n\teffect.glow = this.glow;\n\teffect.glowWidth = this.glowWidth;\n\teffect.glowQuality = this.glowQuality;\n\teffect.glowBlurMethod = this.glowBlurMethod;\n\teffect.glowHighPrecision = this.glowHighPrecision;\n\teffect.glowDistanceScaleBias = this.glowDistanceScaleBias;\n\teffect.glowDownsampling = this.glowDownsampling;\n\teffect.glowHQColor = this.glowHQColor;\n\teffect.glowDithering = this.glowDithering;\n\teffect.glowDitheringStyle = this.glowDitheringStyle;\n\teffect.glowMagicNumber1 = this.glowMagicNumber1;\n\teffect.glowAnimationSpeed = this.glowAnimationSpeed;\n\teffect.glowVisibility = this.glowVisibility;\n\teffect.glowBlendMode = this.glowBlendMode;\n\teffect.glowBlendPasses = this.glowBlendPasses;\n\tv156 = HighlightPlus.HighlightProfile::GetGlowPassesCopy(v130, this.glowPasses);\n\teffect.glowPasses = v156;\n\teffect.glowMaskMode = this.glowMaskMode;\n\teffect.innerGlow = this.innerGlow;\n\teffect.innerGlowPower = this.innerGlowPower;\n\teffect.innerGlowColor = this.innerGlowColor;\n\teffect.innerGlowBlendMode = this.innerGlowBlendMode;\n\teffect.innerGlowVisibility = this.innerGlowVisibility;\n\teffect.focus = this.focus;\n\teffect.focusColor = this.focusColor;\n\teffect.focusBlur = this.focusBlur;\n\teffect.focusBlurDownsampling = this.focusBlurDownsampling;\n\teffect.focusDesaturation = this.focusDesaturation;\n\teffect.targetFX = this.targetFX;\n\teffect.targetFXColor = this.targetFXColor;\n\teffect.targetFXScaleToRenderBounds = this.targetFXScaleToRenderBounds;\n\teffect.targetFXAlignToGround = this.targetFXAlignToGround;\n\teffect.targetFXGroundMaxDistance = this.targetFXGroundMaxDistance;\n\teffect.targetFXGroundLayerMask = this.targetFXGroundLayerMask;\n\teffect.targetFXFadePower = this.targetFXFadePower;\n\teffect.targetFXRotationSpeed = this.targetFXRotationSpeed;\n\teffect.targetFXStayDuration = this.targetFXStayDuration;\n\teffect.targetFXTexture = this.targetFXTexture;\n\teffect.targetFXTransitionDuration = this.targetFXTransitionDuration;\n\teffect.targetFXVisibility = this.targetFXVisibility;\n\teffect.targetFXUseEnclosingBounds = this.targetFXUseEnclosingBounds;\n\teffect.targetFXSquare = this.targetFXSquare;\n\teffect.targetFXOffset.z = this.targetFXOffset.z;\n\teffect.targetFXOffset = this.targetFXOffset;\n\teffect.targetFxCenterOnHitPosition = this.targetFxCenterOnHitPosition;\n\teffect.targetFXStyle = this.targetFXStyle;\n\teffect.targetFXFrameWidth = this.targetFXFrameWidth;\n\teffect.targetFXCornerLength = this.targetFXCornerLength;\n\teffect.targetFXGroundMinAltitude = this.targetFXGroundMinAltitude;\n\teffect.iconFX = this.iconFX;\n\teffect.iconFXAssetType = this.iconFXAssetType;\n\teffect.iconFXPrefab = this.iconFXPrefab;\n\teffect.iconFXMesh = this.iconFXMesh;\n\teffect.iconFXLightColor = this.iconFXLightColor;\n\teffect.iconFXDarkColor = this.iconFXDarkColor;\n\teffect.iconFXAnimationOption = this.iconFXAnimationOption;\n\teffect.iconFXAnimationAmount = this.iconFXAnimationAmount;\n\teffect.iconFXScale = this.iconFXScale;\n\teffect.iconFXScaleToRenderBounds = this.iconFXScaleToRenderBounds;\n\teffect.iconFXOffset.z = this.iconFXOffset.z;\n\teffect.iconFXOffset = this.iconFXOffset;\n\teffect.iconFXRotationSpeed = this.iconFXRotationSpeed;\n\teffect.iconFXStayDuration = this.iconFXStayDuration;\n\teffect.iconFXTransitionDuration = this.iconFXTransitionDuration;\n\teffect.seeThrough = this.seeThrough;\n\teffect.seeThroughOccluderMask = this.seeThroughOccluderMask;\n\teffect.seeThroughOccluderMaskAccurate = this.seeThroughOccluderMaskAccurate;\n\teffect.seeThroughOccluderThreshold = this.seeThroughOccluderThreshold;\n\teffect.seeThroughOccluderCheckInterval = this.seeThroughOccluderCheckInterval;\n\teffect.seeThroughOccluderCheckIndividualObjects = this.seeThroughOccluderCheckIndividualObjects;\n\teffect.seeThroughIntensity = this.seeThroughIntensity;\n\teffect.seeThroughTintColor = this.seeThroughTintColor;\n\teffect.seeThroughNoise = this.seeThroughNoise;\n\teffect.seeThroughBorderColor = this.seeThroughBorderColor;\n\teffect.seeThroughBorderWidth = this.seeThroughBorderWidth;\n\teffect.seeThroughBorderOnly = this.seeThroughBorderOnly;\n\teffect.seeThroughDepthOffset = this.seeThroughDepthOffset;\n\teffect.seeThroughMaxDepth = this.seeThroughMaxDepth;\n\teffect.seeThroughOrdered = this.seeThroughOrdered;\n\teffect.seeThroughTexture = this.seeThroughTexture;\n\teffect.seeThroughTextureScale = this.seeThroughTextureScale;\n\teffect.seeThroughTextureUVSpace = this.seeThroughTextureUVSpace;\n\teffect.seeThroughChildrenSortingMode = this.seeThroughChildrenSortingMode;\n\teffect.hitFxInitialIntensity = this.hitFxInitialIntensity;\n\teffect.hitFxMode = this.hitFxMode;\n\teffect.hitFxFadeOutDuration = this.hitFxFadeOutDuration;\n\teffect.hitFxColor = this.hitFxColor;\n\teffect.hitFxRadius = this.hitFxRadius;\n\teffect.labelEnabled = this.labelEnabled;\n\teffect.labelText = this.labelText;\n\teffect.labelTextSize = this.labelTextSize;\n\teffect.labelColor = this.labelColor;\n\teffect.labelPrefab = this.labelPrefab;\n\teffect.labelVerticalOffset = this.labelVerticalOffset;\n\teffect.labelViewportOffset = this.labelViewportOffset;\n\teffect.labelLineLength = this.labelLineLength;\n\teffect.labelMaxDistance = this.labelMaxDistance;\n\teffect.labelScaleByDistance = this.labelScaleByDistance;\n\teffect.labelScaleMin = this.labelScaleMin;\n\teffect.labelScaleMax = this.labelScaleMax;\n\teffect.labelFollowCursor = this.label\n// ... truncated")]
		public void Load(HighlightEffect effect)
		{
			effect.effectGroup = effectGroup;
			effect.effectGroupLayer = effectGroupLayer;
			effect.effectNameFilter = effectNameFilter;
			effect.effectNameUseRegEx = effectNameUseRegEx;
			effect.excludeObjectsWithHighlightEffect = ((excludeObjectsWithHighlightEffect ? 1u : 0u) & 0xFFu) != 0;
			effect.combineMeshes = (((excludeObjectsWithHighlightEffect ? 1u : 0u) >> 8) & 0xFF) != 0;
			effect.alphaCutOff = alphaCutOff;
			effect.alphaCutOffTextureName = alphaCutOffTextureName;
			effect.padding = padding;
			effect.fadeInDuration = fadeInDuration;
			effect.cameraDistanceFadeNear = cameraDistanceFadeNear;
			effect.minimumWidth = minimumWidth;
			effect.cullBackFaces = cullBackFaces;
			effect.normalsOption = normalsOption;
			effect.cameraDistanceFade = cameraDistanceFade;
			effect.constantWidth = constantWidth;
			effect.extraCoveragePixels = extraCoveragePixels;
			effect.overlay = overlay;
			effect.overlayMode = overlayMode;
			effect.overlayColor = overlayColor;
			effect.overlayAnimationSpeed = overlayAnimationSpeed;
			effect.overlayBlending = overlayBlending;
			effect.overlayTexture = overlayTexture;
			effect.overlayTextureUVSpace = overlayTextureUVSpace;
			effect.overlayTextureScale = overlayTextureScale;
			effect.overlayTextureScrolling = overlayTextureScrolling;
			effect.overlayVisibility = overlayVisibility;
			effect.overlayPattern = overlayPattern;
			effect.overlayPatternScrolling = overlayPatternScrolling;
			effect.overlayPatternScale = overlayPatternScale;
			effect.outline = outline;
			effect.outlineColor = outlineColor;
			effect.outlineColorStyle = outlineColorStyle;
			effect.outlineGradient = outlineGradient;
			effect.outlineGradientInLocalSpace = outlineGradientInLocalSpace;
			effect.outlineWidth = outlineWidth;
			effect.outlineBlurPasses = outlineBlurPasses;
			effect.outlineQuality = outlineQuality;
			effect.outlineEdgeThreshold = outlineEdgeThreshold;
			effect.outlineSharpness = outlineSharpness;
			effect.outlineDownsampling = outlineDownsampling;
			effect.outlineVisibility = outlineVisibility;
			effect.outlineIndependent = outlineIndependent;
			effect.outlineContourStyle = outlineContourStyle;
			effect.outlineMaskMode = outlineMaskMode;
			effect.outlineStylized = outlineStylized;
			effect.outlinePattern = outlinePattern;
			effect.outlinePatternScale = outlinePatternScale;
			effect.outlinePatternDistortionTexture = outlinePatternDistortionTexture;
			effect.outlinePatternDistortionAmount = outlinePatternDistortionAmount;
			effect.outlinePatternStopMotionScale = outlinePatternStopMotionScale;
			effect.outlineDashed = outlineDashed;
			effect.outlineDashWidth = outlineDashWidth;
			effect.outlineDashSpeed = outlineDashSpeed;
			effect.outlineGradientKnee = outlineGradientKnee;
			effect.outlinePixelation = outlinePixelation;
			effect.glow = glow;
			effect.glowWidth = glowWidth;
			effect.glowQuality = glowQuality;
			effect.glowBlurMethod = glowBlurMethod;
			effect.glowHighPrecision = glowHighPrecision;
			effect.glowDistanceScaleBias = glowDistanceScaleBias;
			effect.glowDownsampling = glowDownsampling;
			effect.glowHQColor = glowHQColor;
			effect.glowDithering = glowDithering;
			effect.glowDitheringStyle = glowDitheringStyle;
			effect.glowMagicNumber1 = glowMagicNumber1;
			effect.glowAnimationSpeed = glowAnimationSpeed;
			effect.glowVisibility = glowVisibility;
			effect.glowBlendMode = glowBlendMode;
			effect.glowBlendPasses = glowBlendPasses;
			HighlightProfile highlightProfile = default(HighlightProfile);
			GlowPassData[] glowPassesCopy = highlightProfile.GetGlowPassesCopy(glowPasses);
			effect.glowPasses = glowPassesCopy;
			effect.glowMaskMode = glowMaskMode;
			effect.innerGlow = innerGlow;
			effect.innerGlowPower = innerGlowPower;
			effect.innerGlowColor = innerGlowColor;
			effect.innerGlowBlendMode = innerGlowBlendMode;
			effect.innerGlowVisibility = innerGlowVisibility;
			effect.focus = focus;
			effect.focusColor = focusColor;
			effect.focusBlur = focusBlur;
			effect.focusBlurDownsampling = focusBlurDownsampling;
			effect.focusDesaturation = focusDesaturation;
			effect.targetFX = targetFX;
			effect.targetFXColor = targetFXColor;
			effect.targetFXScaleToRenderBounds = targetFXScaleToRenderBounds;
			effect.targetFXAlignToGround = targetFXAlignToGround;
			effect.targetFXGroundMaxDistance = targetFXGroundMaxDistance;
			effect.targetFXGroundLayerMask = targetFXGroundLayerMask;
			effect.targetFXFadePower = targetFXFadePower;
			effect.targetFXRotationSpeed = targetFXRotationSpeed;
			effect.targetFXStayDuration = targetFXStayDuration;
			effect.targetFXTexture = targetFXTexture;
			effect.targetFXTransitionDuration = targetFXTransitionDuration;
			effect.targetFXVisibility = targetFXVisibility;
			effect.targetFXUseEnclosingBounds = targetFXUseEnclosingBounds;
			effect.targetFXSquare = targetFXSquare;
			effect.targetFXOffset.z = targetFXOffset.z;
			effect.targetFXOffset = targetFXOffset;
			effect.targetFxCenterOnHitPosition = ((targetFxCenterOnHitPosition ? 1u : 0u) & 0xFFu) != 0;
			effect.targetFxAlignToNormal = (((targetFxCenterOnHitPosition ? 1u : 0u) >> 8) & 0xFF) != 0;
			effect.targetFXStyle = targetFXStyle;
			effect.targetFXFrameWidth = targetFXFrameWidth;
			effect.targetFXCornerLength = targetFXCornerLength;
			effect.targetFXGroundMinAltitude = targetFXGroundMinAltitude;
			effect.iconFX = iconFX;
			effect.iconFXAssetType = iconFXAssetType;
			effect.iconFXPrefab = iconFXPrefab;
			effect.iconFXMesh = iconFXMesh;
			effect.iconFXLightColor = iconFXLightColor;
			effect.iconFXDarkColor = iconFXDarkColor;
			effect.iconFXAnimationOption = iconFXAnimationOption;
			effect.iconFXAnimationAmount = iconFXAnimationAmount;
			effect.iconFXScale = iconFXScale;
			effect.iconFXScaleToRenderBounds = iconFXScaleToRenderBounds;
			effect.iconFXOffset.z = iconFXOffset.z;
			effect.iconFXOffset = iconFXOffset;
			effect.iconFXRotationSpeed = iconFXRotationSpeed;
			effect.iconFXStayDuration = iconFXStayDuration;
			effect.iconFXTransitionDuration = iconFXTransitionDuration;
			effect.seeThrough = seeThrough;
			effect.seeThroughOccluderMask = seeThroughOccluderMask;
			effect.seeThroughOccluderMaskAccurate = seeThroughOccluderMaskAccurate;
			effect.seeThroughOccluderThreshold = seeThroughOccluderThreshold;
			effect.seeThroughOccluderCheckInterval = seeThroughOccluderCheckInterval;
			effect.seeThroughOccluderCheckIndividualObjects = seeThroughOccluderCheckIndividualObjects;
			effect.seeThroughIntensity = seeThroughIntensity;
			effect.seeThroughTintColor = seeThroughTintColor;
			effect.seeThroughNoise = seeThroughNoise;
			effect.seeThroughBorderColor = seeThroughBorderColor;
			effect.seeThroughBorderWidth = seeThroughBorderWidth;
			effect.seeThroughBorderOnly = seeThroughBorderOnly;
			effect.seeThroughDepthOffset = seeThroughDepthOffset;
			effect.seeThroughMaxDepth = seeThroughMaxDepth;
			effect.seeThroughOrdered = seeThroughOrdered;
			effect.seeThroughTexture = seeThroughTexture;
			effect.seeThroughTextureScale = seeThroughTextureScale;
			effect.seeThroughTextureUVSpace = seeThroughTextureUVSpace;
			effect.seeThroughChildrenSortingMode = seeThroughChildrenSortingMode;
			effect.hitFxInitialIntensity = hitFxInitialIntensity;
			effect.hitFxMode = hitFxMode;
			effect.hitFxFadeOutDuration = hitFxFadeOutDuration;
			effect.hitFxColor = hitFxColor;
			effect.hitFxRadius = hitFxRadius;
			effect.labelEnabled = labelEnabled;
			effect.labelText = labelText;
			effect.labelTextSize = labelTextSize;
			effect.labelColor = labelColor;
			effect.labelPrefab = labelPrefab;
			effect.labelVerticalOffset = labelVerticalOffset;
			effect.labelViewportOffset = labelViewportOffset;
			effect.labelLineLength = labelLineLength;
			effect.labelMaxDistance = labelMaxDistance;
			effect.labelScaleByDistance = labelScaleByDistance;
			effect.labelScaleMin = labelScaleMin;
			effect.labelScaleMax = labelScaleMax;
			effect.labelFollowCursor = labelFollowCursor;
			effect.labelMode = labelMode;
			effect.labelAlignment = labelAlignment;
			effect.labelShowInEditorMode = labelShowInEditorMode;
			effect.labelRelativeAlignment = labelRelativeAlignment;
			effect.labelAlignmentTransform = labelAlignmentTransform;
			effect.UpdateMaterialProperties();
		}

		[Token(Token = "0x60000FB")]
		[Address(RVA = "0x772B82C", Offset = "0x772B82C", Length = "0x5B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.effectGroup = effect.effectGroup;\n\tthis.effectGroupLayer = effect.effectGroupLayer;\n\tthis.effectNameFilter = effect.effectNameFilter;\n\tthis.effectNameUseRegEx = effect.effectNameUseRegEx;\n\tthis.excludeObjectsWithHighlightEffect = effect.excludeObjectsWithHighlightEffect;\n\tthis.alphaCutOff = effect.alphaCutOff;\n\tthis.alphaCutOffTextureName = effect.alphaCutOffTextureName;\n\tthis.cullBackFaces = effect.cullBackFaces;\n\tthis.padding = effect.padding;\n\tthis.normalsOption = effect.normalsOption;\n\tthis.fadeInDuration = effect.fadeInDuration;\n\tthis.cameraDistanceFade = effect.cameraDistanceFade;\n\tthis.cameraDistanceFadeNear = effect.cameraDistanceFadeNear;\n\tthis.constantWidth = effect.constantWidth;\n\tthis.extraCoveragePixels = effect.extraCoveragePixels;\n\tthis.minimumWidth = effect.minimumWidth;\n\tthis.overlay = effect.overlay;\n\tthis.overlayMode = effect.overlayMode;\n\tthis.overlayColor = effect.overlayColor;\n\tthis.overlayAnimationSpeed = effect.overlayAnimationSpeed;\n\tthis.overlayBlending = effect.overlayBlending;\n\tthis.overlayTexture = effect.overlayTexture;\n\tthis.overlayTextureUVSpace = effect.overlayTextureUVSpace;\n\tthis.overlayTextureScale = effect.overlayTextureScale;\n\tthis.overlayTextureScrolling = effect.overlayTextureScrolling;\n\tthis.overlayVisibility = effect.overlayVisibility;\n\tthis.overlayPattern = effect.overlayPattern;\n\tthis.overlayPatternScrolling = effect.overlayPatternScrolling;\n\tthis.overlayPatternScale = effect.overlayPatternScale;\n\tthis.outline = effect.outline;\n\tthis.outlineColor = effect.outlineColor;\n\tthis.outlineGradient = effect.outlineGradient;\n\tthis.outlineColorStyle = effect.outlineColorStyle;\n\tthis.outlineWidth = effect.outlineWidth;\n\tthis.outlineBlurPasses = effect.outlineBlurPasses;\n\tthis.outlineQuality = effect.outlineQuality;\n\tthis.outlineGradientInLocalSpace = effect.outlineGradientInLocalSpace;\n\tthis.outlineEdgeThreshold = effect.outlineEdgeThreshold;\n\tthis.outlineSharpness = effect.outlineSharpness;\n\tthis.outlineVisibility = effect.outlineVisibility;\n\tthis.outlineIndependent = effect.outlineIndependent;\n\tthis.outlineDownsampling = effect.outlineDownsampling;\n\tthis.outlineContourStyle = effect.outlineContourStyle;\n\tthis.outlineMaskMode = effect.outlineMaskMode;\n\tthis.outlineStylized = effect.outlineStylized;\n\tthis.outlinePattern = effect.outlinePattern;\n\tthis.outlinePatternScale = effect.outlinePatternScale;\n\tthis.outlinePatternDistortionTexture = effect.outlinePatternDistortionTexture;\n\tthis.outlinePatternDistortionAmount = effect.outlinePatternDistortionAmount;\n\tthis.outlinePatternStopMotionScale = effect.outlinePatternStopMotionScale;\n\tthis.outlineDashed = effect.outlineDashed;\n\tthis.outlineDashWidth = effect.outlineDashWidth;\n\tthis.outlineDashSpeed = effect.outlineDashSpeed;\n\tthis.outlineGradientKnee = effect.outlineGradientKnee;\n\tthis.outlinePixelation = effect.outlinePixelation;\n\tthis.glow = effect.glow;\n\tthis.glowWidth = effect.glowWidth;\n\tthis.glowHighPrecision = effect.glowHighPrecision;\n\tthis.glowQuality = effect.glowQuality;\n\tthis.glowBlurMethod = effect.glowBlurMethod;\n\tthis.glowDistanceScaleBias = effect.glowDistanceScaleBias;\n\tthis.glowDownsampling = effect.glowDownsampling;\n\tthis.glowHQColor = effect.glowHQColor;\n\tthis.glowDithering = effect.glowDithering;\n\tthis.glowDitheringStyle = effect.glowDitheringStyle;\n\tthis.glowMagicNumber1 = effect.glowMagicNumber1;\n\tthis.glowAnimationSpeed = effect.glowAnimationSpeed;\n\tthis.glowVisibility = effect.glowVisibility;\n\tthis.glowBlendMode = effect.glowBlendMode;\n\tthis.glowBlendPasses = effect.glowBlendPasses;\n\tv153 = HighlightPlus.HighlightProfile::GetGlowPassesCopy(v128, effect.glowPasses);\n\tthis.glowPasses = v153;\n\tthis.glowMaskMode = effect.glowMaskMode;\n\tthis.innerGlow = effect.innerGlow;\n\tthis.innerGlowPower = effect.innerGlowPower;\n\tthis.innerGlowColor = effect.innerGlowColor;\n\tthis.innerGlowBlendMode = effect.innerGlowBlendMode;\n\tthis.innerGlowVisibility = effect.innerGlowVisibility;\n\tthis.focus = effect.focus;\n\tthis.focusColor = effect.focusColor;\n\tthis.focusBlur = effect.focusBlur;\n\tthis.focusBlurDownsampling = effect.focusBlurDownsampling;\n\tthis.focusDesaturation = effect.focusDesaturation;\n\tthis.targetFX = effect.targetFX;\n\tthis.targetFXColor = effect.targetFXColor;\n\tthis.targetFXScaleToRenderBounds = effect.targetFXScaleToRenderBounds;\n\tthis.targetFXAlignToGround = effect.targetFXAlignToGround;\n\tthis.targetFXGroundMaxDistance = effect.targetFXGroundMaxDistance;\n\tthis.targetFXGroundLayerMask = effect.targetFXGroundLayerMask;\n\tthis.targetFXFadePower = effect.targetFXFadePower;\n\tthis.targetFXRotationSpeed = effect.targetFXRotationSpeed;\n\tthis.targetFXStayDuration = effect.targetFXStayDuration;\n\tthis.targetFXTexture = effect.targetFXTexture;\n\tthis.targetFXTransitionDuration = effect.targetFXTransitionDuration;\n\tthis.targetFXVisibility = effect.targetFXVisibility;\n\tthis.targetFXUseEnclosingBounds = effect.targetFXUseEnclosingBounds;\n\tthis.targetFXSquare = effect.targetFXSquare;\n\tthis.targetFXOffset.z = effect.targetFXOffset.z;\n\tthis.targetFXOffset = effect.targetFXOffset;\n\tthis.targetFxCenterOnHitPosition = effect.targetFxCenterOnHitPosition;\n\tthis.targetFXStyle = effect.targetFXStyle;\n\tthis.targetFXFrameWidth = effect.targetFXFrameWidth;\n\tthis.targetFXCornerLength = effect.targetFXCornerLength;\n\tthis.targetFXGroundMinAltitude = effect.targetFXGroundMinAltitude;\n\tthis.iconFX = effect.iconFX;\n\tthis.iconFXAssetType = effect.iconFXAssetType;\n\tthis.iconFXPrefab = effect.iconFXPrefab;\n\tthis.iconFXMesh = effect.iconFXMesh;\n\tthis.iconFXLightColor = effect.iconFXLightColor;\n\tthis.iconFXDarkColor = effect.iconFXDarkColor;\n\tthis.iconFXAnimationOption = effect.iconFXAnimationOption;\n\tthis.iconFXAnimationAmount = effect.iconFXAnimationAmount;\n\tthis.iconFXScaleToRenderBounds = effect.iconFXScaleToRenderBounds;\n\tthis.iconFXScale = effect.iconFXScale;\n\tthis.iconFXOffset = effect.iconFXOffset;\n\tthis.iconFXOffset.z = effect.iconFXOffset.z;\n\tthis.iconFXRotationSpeed = effect.iconFXRotationSpeed;\n\tthis.iconFXStayDuration = effect.iconFXStayDuration;\n\tthis.iconFXTransitionDuration = effect.iconFXTransitionDuration;\n\tthis.seeThrough = effect.seeThrough;\n\tthis.seeThroughOccluderMask = effect.seeThroughOccluderMask;\n\tthis.seeThroughOccluderMaskAccurate = effect.seeThroughOccluderMaskAccurate;\n\tthis.seeThroughOccluderThreshold = effect.seeThroughOccluderThreshold;\n\tthis.seeThroughOccluderCheckInterval = effect.seeThroughOccluderCheckInterval;\n\tthis.seeThroughOccluderCheckIndividualObjects = effect.seeThroughOccluderCheckIndividualObjects;\n\tthis.seeThroughIntensity = effect.seeThroughIntensity;\n\tthis.seeThroughTintColor = effect.seeThroughTintColor;\n\tthis.seeThroughNoise = effect.seeThroughNoise;\n\tthis.seeThroughBorderColor = effect.seeThroughBorderColor;\n\tthis.seeThroughBorderWidth = effect.seeThroughBorderWidth;\n\tthis.seeThroughDepthOffset = effect.seeThroughDepthOffset;\n\tthis.seeThroughBorderOnly = effect.seeThroughBorderOnly;\n\tthis.seeThroughMaxDepth = effect.seeThroughMaxDepth;\n\tthis.seeThroughOrdered = effect.seeThroughOrdered;\n\tthis.seeThroughTexture = effect.seeThroughTexture;\n\tthis.seeThroughTextureScale = effect.seeThroughTextureScale;\n\tthis.seeThroughTextureUVSpace = effect.seeThroughTextureUVSpace;\n\tthis.seeThroughChildrenSortingMode = effect.seeThroughChildrenSortingMode;\n\tthis.hitFxInitialIntensity = effect.hitFxInitialIntensity;\n\tthis.hitFxMode = effect.hitFxMode;\n\tthis.hitFxFadeOutDuration = effect.hitFxFadeOutDuration;\n\tthis.hitFxColor = effect.hitFxColor;\n\tthis.hitFxRadius = effect.hitFxRadius;\n\tthis.labelEnabled = effect.labelEnabled;\n\tthis.labelText = effect.labelText;\n\tthis.labelTextSize = effect.labelTextSize;\n\tthis.labelColor = effect.labelColor;\n\tthis.labelPrefab = effect.labelPrefab;\n\tthis.labelVerticalOffset = effect.labelVerticalOffset;\n\tthis.labelViewportOffset = effect.labelViewportOffset;\n\tthis.labelLineLength = effect.labelLineLength;\n\tthis.labelMaxDistance = effect.labelMaxDistance;\n\tthis.labelScaleByDistance = effect.labelScaleByDistance;\n\tthis.labelScaleMin = effect.labelScaleMin;\n\tthis.labelScaleMax = effect.labelScaleMax;\n\tthis.labelFollowCursor = effect.label\n// ... truncated")]
		public void Save(HighlightEffect effect)
		{
			effectGroup = effect.effectGroup;
			effectGroupLayer = effect.effectGroupLayer;
			effectNameFilter = effect.effectNameFilter;
			effectNameUseRegEx = effect.effectNameUseRegEx;
			excludeObjectsWithHighlightEffect = ((effect.excludeObjectsWithHighlightEffect ? 1u : 0u) & 0xFFu) != 0;
			combineMeshes = (((effect.excludeObjectsWithHighlightEffect ? 1u : 0u) >> 8) & 0xFF) != 0;
			alphaCutOff = effect.alphaCutOff;
			alphaCutOffTextureName = effect.alphaCutOffTextureName;
			cullBackFaces = effect.cullBackFaces;
			padding = effect.padding;
			normalsOption = effect.normalsOption;
			fadeInDuration = effect.fadeInDuration;
			cameraDistanceFade = effect.cameraDistanceFade;
			cameraDistanceFadeNear = effect.cameraDistanceFadeNear;
			constantWidth = effect.constantWidth;
			extraCoveragePixels = effect.extraCoveragePixels;
			minimumWidth = effect.minimumWidth;
			overlay = effect.overlay;
			overlayMode = effect.overlayMode;
			overlayColor = effect.overlayColor;
			overlayAnimationSpeed = effect.overlayAnimationSpeed;
			overlayBlending = effect.overlayBlending;
			overlayTexture = effect.overlayTexture;
			overlayTextureUVSpace = effect.overlayTextureUVSpace;
			overlayTextureScale = effect.overlayTextureScale;
			overlayTextureScrolling = effect.overlayTextureScrolling;
			overlayVisibility = effect.overlayVisibility;
			overlayPattern = effect.overlayPattern;
			overlayPatternScrolling = effect.overlayPatternScrolling;
			overlayPatternScale = effect.overlayPatternScale;
			outline = effect.outline;
			outlineColor = effect.outlineColor;
			outlineGradient = effect.outlineGradient;
			outlineColorStyle = effect.outlineColorStyle;
			outlineWidth = effect.outlineWidth;
			outlineBlurPasses = effect.outlineBlurPasses;
			outlineQuality = effect.outlineQuality;
			outlineGradientInLocalSpace = effect.outlineGradientInLocalSpace;
			outlineEdgeThreshold = effect.outlineEdgeThreshold;
			outlineSharpness = effect.outlineSharpness;
			outlineVisibility = effect.outlineVisibility;
			outlineIndependent = effect.outlineIndependent;
			outlineDownsampling = effect.outlineDownsampling;
			outlineContourStyle = effect.outlineContourStyle;
			outlineMaskMode = effect.outlineMaskMode;
			outlineStylized = effect.outlineStylized;
			outlinePattern = effect.outlinePattern;
			outlinePatternScale = effect.outlinePatternScale;
			outlinePatternDistortionTexture = effect.outlinePatternDistortionTexture;
			outlinePatternDistortionAmount = effect.outlinePatternDistortionAmount;
			outlinePatternStopMotionScale = effect.outlinePatternStopMotionScale;
			outlineDashed = effect.outlineDashed;
			outlineDashWidth = effect.outlineDashWidth;
			outlineDashSpeed = effect.outlineDashSpeed;
			outlineGradientKnee = effect.outlineGradientKnee;
			outlinePixelation = effect.outlinePixelation;
			glow = effect.glow;
			glowWidth = effect.glowWidth;
			glowHighPrecision = effect.glowHighPrecision;
			glowQuality = effect.glowQuality;
			glowBlurMethod = effect.glowBlurMethod;
			glowDistanceScaleBias = effect.glowDistanceScaleBias;
			glowDownsampling = effect.glowDownsampling;
			glowHQColor = effect.glowHQColor;
			glowDithering = effect.glowDithering;
			glowDitheringStyle = effect.glowDitheringStyle;
			glowMagicNumber1 = effect.glowMagicNumber1;
			glowAnimationSpeed = effect.glowAnimationSpeed;
			glowVisibility = effect.glowVisibility;
			glowBlendMode = effect.glowBlendMode;
			glowBlendPasses = effect.glowBlendPasses;
			HighlightProfile highlightProfile = default(HighlightProfile);
			GlowPassData[] glowPassesCopy = highlightProfile.GetGlowPassesCopy(effect.glowPasses);
			glowPasses = glowPassesCopy;
			glowMaskMode = effect.glowMaskMode;
			innerGlow = effect.innerGlow;
			innerGlowPower = effect.innerGlowPower;
			innerGlowColor = effect.innerGlowColor;
			innerGlowBlendMode = effect.innerGlowBlendMode;
			innerGlowVisibility = effect.innerGlowVisibility;
			focus = effect.focus;
			focusColor = effect.focusColor;
			focusBlur = effect.focusBlur;
			focusBlurDownsampling = effect.focusBlurDownsampling;
			focusDesaturation = effect.focusDesaturation;
			targetFX = effect.targetFX;
			targetFXColor = effect.targetFXColor;
			targetFXScaleToRenderBounds = effect.targetFXScaleToRenderBounds;
			targetFXAlignToGround = effect.targetFXAlignToGround;
			targetFXGroundMaxDistance = effect.targetFXGroundMaxDistance;
			targetFXGroundLayerMask = effect.targetFXGroundLayerMask;
			targetFXFadePower = effect.targetFXFadePower;
			targetFXRotationSpeed = effect.targetFXRotationSpeed;
			targetFXStayDuration = effect.targetFXStayDuration;
			targetFXTexture = effect.targetFXTexture;
			targetFXTransitionDuration = effect.targetFXTransitionDuration;
			targetFXVisibility = effect.targetFXVisibility;
			targetFXUseEnclosingBounds = effect.targetFXUseEnclosingBounds;
			targetFXSquare = effect.targetFXSquare;
			targetFXOffset.z = effect.targetFXOffset.z;
			targetFXOffset = effect.targetFXOffset;
			targetFxCenterOnHitPosition = ((effect.targetFxCenterOnHitPosition ? 1u : 0u) & 0xFFu) != 0;
			targetFxAlignToNormal = (((effect.targetFxCenterOnHitPosition ? 1u : 0u) >> 8) & 0xFF) != 0;
			targetFXStyle = effect.targetFXStyle;
			targetFXFrameWidth = effect.targetFXFrameWidth;
			targetFXCornerLength = effect.targetFXCornerLength;
			targetFXGroundMinAltitude = effect.targetFXGroundMinAltitude;
			iconFX = effect.iconFX;
			iconFXAssetType = effect.iconFXAssetType;
			iconFXPrefab = effect.iconFXPrefab;
			iconFXMesh = effect.iconFXMesh;
			iconFXLightColor = effect.iconFXLightColor;
			iconFXDarkColor = effect.iconFXDarkColor;
			iconFXAnimationOption = effect.iconFXAnimationOption;
			iconFXAnimationAmount = effect.iconFXAnimationAmount;
			iconFXScaleToRenderBounds = effect.iconFXScaleToRenderBounds;
			iconFXScale = effect.iconFXScale;
			iconFXOffset = effect.iconFXOffset;
			iconFXOffset.z = effect.iconFXOffset.z;
			iconFXRotationSpeed = effect.iconFXRotationSpeed;
			iconFXStayDuration = effect.iconFXStayDuration;
			iconFXTransitionDuration = effect.iconFXTransitionDuration;
			seeThrough = effect.seeThrough;
			seeThroughOccluderMask = effect.seeThroughOccluderMask;
			seeThroughOccluderMaskAccurate = effect.seeThroughOccluderMaskAccurate;
			seeThroughOccluderThreshold = effect.seeThroughOccluderThreshold;
			seeThroughOccluderCheckInterval = effect.seeThroughOccluderCheckInterval;
			seeThroughOccluderCheckIndividualObjects = effect.seeThroughOccluderCheckIndividualObjects;
			seeThroughIntensity = effect.seeThroughIntensity;
			seeThroughTintColor = effect.seeThroughTintColor;
			seeThroughNoise = effect.seeThroughNoise;
			seeThroughBorderColor = effect.seeThroughBorderColor;
			seeThroughBorderWidth = effect.seeThroughBorderWidth;
			seeThroughDepthOffset = effect.seeThroughDepthOffset;
			seeThroughBorderOnly = effect.seeThroughBorderOnly;
			seeThroughMaxDepth = effect.seeThroughMaxDepth;
			seeThroughOrdered = effect.seeThroughOrdered;
			seeThroughTexture = effect.seeThroughTexture;
			seeThroughTextureScale = effect.seeThroughTextureScale;
			seeThroughTextureUVSpace = effect.seeThroughTextureUVSpace;
			seeThroughChildrenSortingMode = effect.seeThroughChildrenSortingMode;
			hitFxInitialIntensity = effect.hitFxInitialIntensity;
			hitFxMode = effect.hitFxMode;
			hitFxFadeOutDuration = effect.hitFxFadeOutDuration;
			hitFxColor = effect.hitFxColor;
			hitFxRadius = effect.hitFxRadius;
			labelEnabled = effect.labelEnabled;
			labelText = effect.labelText;
			labelTextSize = effect.labelTextSize;
			labelColor = effect.labelColor;
			labelPrefab = effect.labelPrefab;
			labelVerticalOffset = effect.labelVerticalOffset;
			labelViewportOffset = effect.labelViewportOffset;
			labelLineLength = effect.labelLineLength;
			labelMaxDistance = effect.labelMaxDistance;
			labelScaleByDistance = effect.labelScaleByDistance;
			labelScaleMin = effect.labelScaleMin;
			labelScaleMax = effect.labelScaleMax;
			labelFollowCursor = effect.labelFollowCursor;
			labelMode = effect.labelMode;
			labelAlignment = effect.labelAlignment;
			labelShowInEditorMode = effect.labelShowInEditorMode;
			labelRelativeAlignment = effect.labelRelativeAlignment;
			labelAlignmentTransform = effect.labelAlignmentTransform;
		}

		[Token(Token = "0x60000FC")]
		[Address(RVA = "0x772EEA4", Offset = "0x772EEA4", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\t// 26 NewArr returnVal2 @ X0_v4 (HighlightPlus.GlowPassData[]), typeof(HighlightPlus.GlowPassData[]), glowPasses.Length\n\tv67 = glowPasses.Length < 1;\n\tif (v67) goto L_006A;\n\tv166 = glowPasses + 0x28;\n\tv165 = returnVal2 + 0x28;\n\tv179 = 0;\nL_0039:\n\t*([v165 @ X10_v4-4]) = *([v166 @ X9_v4-4]);\n\t*([v165 @ X10_v4]) = *([v166 @ X9_v4]);\n\t*([v165 @ X10_v4-8]) = *([v166 @ X9_v4-8]);\n\tv179 = v179 + 1;\n\tv166 = v166 + 0x18;\n\tv165 = v165 + 0x18;\n\tv84 = v179 < glowPasses.Length;\n\tif (v84) goto L_0039;\nL_006A:\n\treturn returnVal2;\nL_0073:\n\t// 115 NewArr returnVal1 @ X0_v3 (HighlightPlus.GlowPassData[]), typeof(HighlightPlus.GlowPassData[]), 0\n\treturn returnVal1;\nL_0017:\n\tv45 = glowPasses == 0;\n\tif (v45) goto L_0073;\n")]
		private GlowPassData[] GetGlowPassesCopy(GlowPassData[] glowPasses)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightProfile::GetGlowPassesCopy");
			return default;
		}

		[Token(Token = "0x60000FD")]
		[Address(RVA = "0x772EF88", Offset = "0x772EF88", Length = "0x2CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\nL_FFFFFFFF:\n\tv71 = 0;\n\tgoto L_0038;\nL_FFFFFFFF:\n\tv82 = 0;\n\tgoto L_0046;\nL_FFFFFFFF:\n\tv95 = 1f;\n\tgoto L_0056;\nL_FFFFFFFF:\n\t;\n\tgoto L_006B;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv126 = 0;\n\tgoto L_007C;\nL_FFFFFFFF:\n\tv139 = 1f;\n\tgoto L_008C;\nL_FFFFFFFF:\n\tv154 = 0;\n\tgoto L_00A0;\nL_FFFFFFFF:\n\tv165 = 0;\n\tgoto L_00AE;\nL_FFFFFFFF:\n\tv176 = 0;\n\tgoto L_00BC;\nL_FFFFFFFF:\n\tv190 = 0;\n\tgoto L_00CF;\n\tv200 = v197.Length == 0;\n\tv201 = ~v200;\n\tif (v201) goto L_0127;\nL_00E6:\n\t// 230 NewArr v208 @ X0_v16 (HighlightPlus.GlowPassData[]), typeof(HighlightPlus.GlowPassData[]), 4\n\tthis.glowPasses = v208;\n\tv244 = this.glowPasses;\n\t*([v244 @ X8_v21 (HighlightPlus.GlowPassData[])+20]) = *([930A910]);\n\t*([v244 @ X8_v21 (HighlightPlus.GlowPassData[])+30]) = 0.0078125d;\n\t*([v244 @ X8_v21 (HighlightPlus.GlowPassData[])+38]) = *([930A920]);\n\t*([v244 @ X8_v21 (HighlightPlus.GlowPassData[])+48]) = 0.0078125d;\n\t*([v244 @ X8_v21 (HighlightPlus.GlowPassData[])+50]) = T;\n\t*([v244 @ X8_v21 (HighlightPlus.GlowPassData[])+60]) = 0.0078125d;\n\t*([v244 @ X8_v21 (HighlightPlus.GlowPassData[])+68]) = *([930A940]);\n\t*([v244 @ X8_v21 (HighlightPlus.GlowPassData[])+78]) = 0.0078125d;\nL_012A:\n\tv254 = UnityEngine.Object::op_Equality(this.labelPrefab, 0);\n\tv259 = ~v254;\n\tif (v259) goto L_0139;\n\tv305 = UnityEngine.Resources::Load(\"HighlightPlus/Label\");\n\tthis.labelPrefab = v305;\nL_0139:\n\tv373 = this.labelLineLength;\n\tv315 = this.labelLineLength < 0;\n\tv322 = ~v315;\n\tif (v322) goto L_0147;\nL_FFFFFFFF:\n\tv373 = 0;\n\tgoto L_0147;\nL_001E:\n\t// 30 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv44 = ~v32;\n\tv45 = this.outlineGradientKnee & v44;\n\tthis.outlineGradientKnee = v45;\n\tv48 = UnityEngine.Mathf::Max(this.outlineSharpness, 1f);\n\tthis.outlineSharpness = v48;\n\tv53 = ~this.extraCoveragePixels;\n\tv54 = this.extraCoveragePixels & v53;\n\tthis.extraCoveragePixels = v54;\n\tv71 = this.glowWidth;\n\tv56 = this.glowWidth < 0;\n\tv63 = ~v56;\n\tif (v63) goto L_0038;\nL_0038:\n\tthis.glowWidth = v71;\n\tv82 = this.glowAnimationSpeed;\n\tv73 = this.glowAnimationSpeed < 0;\n\tv79 = ~v73;\n\tif (v79) goto L_0046;\nL_0046:\n\tthis.glowAnimationSpeed = v82;\n\tv95 = this.glowDistanceScaleBias;\n\tv84 = this.glowDistanceScaleBias < 1f;\n\tv92 = ~v84;\n\tif (v92) goto L_0056;\nL_0056:\n\tthis.glowDistanceScaleBias = v95;\n\tv97 = this.outlineEdgeThreshold < 1f;\n\tv98 = this.outlineEdgeThreshold == 1f;\n\tv101 = this.outlineEdgeThreshold == this.outlineEdgeThreshold;\n\tv102 = 1f == 1f;\n\tv103 = v101 & v102;\n\tv104 = ~v103;\n\tv105 = v97 == v104;\n\tv106 = ~v98;\n\tv107 = v105 & v106;\n\tv108 = ~v107;\n\tif (v108) goto L_FFFFFFFF;\nL_006B:\n\t// 107 NotImplemented \"Instruction FCMGT not yet implemented.\"\n\t// 109 NotImplemented \"Instruction BIT not yet implemented.\"\n\tthis.outlineEdgeThreshold = this.outlineEdgeThreshold;\n\tv126 = this.overlayAnimationSpeed;\n\tv117 = this.overlayAnimationSpeed < 0;\n\tv123 = ~v117;\n\tif (v123) goto L_007C;\nL_007C:\n\tthis.overlayAnimationSpeed = v126;\n\tv139 = this.innerGlowPower;\n\tv128 = this.innerGlowPower < 1f;\n\tv136 = ~v128;\n\tif (v136) goto L_008C;\nL_008C:\n\tthis.innerGlowPower = v139;\n\t// 143 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv142 = ~1f;\n\tv143 = this.seeThroughDepthOffset & v142;\n\tthis.seeThroughDepthOffset = v143;\n\tv154 = this.seeThroughFadeRange;\n\tv145 = this.seeThroughFadeRange < 0;\n\tv151 = ~v145;\n\tif (v151) goto L_00A0;\nL_00A0:\n\tthis.seeThroughFadeRange = v154;\n\tv165 = this.seeThroughBorderWidth;\n\tv156 = this.seeThroughBorderWidth < 0;\n\tv162 = ~v156;\n\tif (v162) goto L_00AE;\nL_00AE:\n\tthis.seeThroughBorderWidth = v165;\n\tv176 = this.targetFXFadePower;\n\tv167 = this.targetFXFadePower < 0;\n\tv173 = ~v167;\n\tif (v173) goto L_00BC;\nL_00BC:\n\tthis.targetFXFadePower = v176;\n\t// 190 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv178 = ~1f;\n\tv179 = this.cameraDistanceFadeNear & v178;\n\tthis.cameraDistanceFadeNear = v179;\n\tv190 = this.iconFXScale;\n\tv181 = this.iconFXScale < 0;\n\tv187 = ~v181;\n\tif (v187) goto L_00CF;\nL_00CF:\n\tthis.iconFXScale = v190;\n\t// 209 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\tv192 = ~1f;\n\tv193 = this.iconFXAnimationAmount & v192;\n\tthis.iconFXAnimationAmount = v193;\n\t// 216 NotImplemented \"Instruction FCMGT not yet implemented.\"\n\t// 217 NotImplemented \"Instruction BIT not yet implemented.\"\n\tthis.outlinePatternScale = this.outlinePatternScale;\n\tv197 = this.glowPasses;\n\tv198 = this.glowPasses == 0;\n\tif (v198) goto L_00E6;\nL_0127:\n\tgoto L_012A;\nL_0147:\n\tthis.labelLineLength = v373;\n\treturn;\n")]
		public void OnValidate()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightProfile::OnValidate");
		}

		[Token(Token = "0x60000FE")]
		[Address(RVA = "0x772F254", Offset = "0x772F254", Length = "0x304")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tthis.labelTextSize = *([930A980]);\n\tthis.labelColor.a = 1f;\n\tthis.labelLineLength = 200f;\n\tthis.labelFollowCursor = 1;\n\tthis.labelShowInEditorMode = 1;\n\tthis.labelMaxDistance = 13510801146249216d;\n\tthis.labelScaleMin = 1f;\n\tthis.seeThrough = 2;\n\tv140 = UnityEngine.LayerMask::op_Implicit(-1);\n\tthis.seeThroughOccluderMask = v140;\n\tthis.seeThroughOccluderThreshold = 0.007812501827720553d;\n\tthis.seeThroughIntensity = *([930A990]);\n\tthis.seeThroughTintColor.b = 0.0078125d;\n\tthis.seeThroughNoise = 1f;\n\tthis.seeThroughBorderColor = *([9245650]);\n\tthis.seeThroughBorderWidth = 0.45f;\n\tthis.seeThroughTextureScale = 1f;\n\tthis.hitFxFadeOutDuration = *([930A9A0]);\n\tthis.hitFxColor.a = 3.0517585344114195E-05d;\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\nL_001F:\n\tv59 = UnityEngine.LayerMask::op_Implicit(-1);\n\tthis.effectGroupLayer = v59;\n\tthis.cullBackFaces = 1;\n\tthis.cameraDistanceFadeFar = 1000f;\n\tthis.constantWidth = 1;\n\tthis.overlayColor = *([930A950]);\n\tthis.overlayAnimationSpeed = 3.0517585344114195E-05d;\n\tthis.overlayBlending = 1f;\n\tthis.overlayTextureScale = 1f;\n\tthis.overlayPatternScale = 1.4901167006038663E-09d;\n\tthis.overlayPatternSoftness = 0.02f;\n\tthis.outline = *([92456C0]);\n\tthis.outlineColor.a = 1f;\n\tthis.outlineBlurPasses = 0x3EE6666600000002;\n\tthis.outlineQuality = 1;\n\tthis.outlineEdgeThreshold = 805306494.99d;\n\tthis.outlineSharpness = 1f;\n\tthis.outlineGradientKnee = 131072.0306640625d;\n\tthis.outlinePatternScale = *([930AA20]);\n\tthis.outlineDashWidth = 0.5f;\n\tthis.outlineDashGap = 2.0000004664063455d;\n\tthis.glowWidth = 0.4f;\n\tthis.glowHighPrecision = 1;\n\tthis.glowDistanceScaleBias = 25f;\n\tthis.glowHQColor = *([930A960]);\n\tthis.glowDithering = 1f;\n\tthis.glowMagicNumber1 = 3.0517585315692486E-05d;\n\tthis.glowAnimationSpeed = 1f;\n\tthis.glowBlendPasses = 1;\n\tthis.innerGlowWidth = 1f;\n\tthis.innerGlowColor = 0;\n\tthis.focusColor = *([930A970]);\n\tthis.focusBlurDownsampling = 2;\n\tthis.targetFXFrameWidth = 0.1f;\n\tthis.targetFXColor = 0;\n\tthis.targetFXRotationSpeed = 50f;\n\tthis.targetFXInitialScale = 0.12500003003515303d;\n\tthis.targetFXSquare = 1;\n\tthis.targetFXGroundMaxDistance = 15f;\n\tv113 = UnityEngine.LayerMask::op_Implicit(-1);\n\tthis.targetFXGroundLayerMask = v113;\n\tthis.targetFXFadePower = 32f;\n\tthis.targetFXTransitionDuration = 0.5f;\n\tthis.targetFXVisibility = 0xC47A000000000001;\n\tthis.iconFXLightColor = 0;\n\tthis.iconFXDarkColor = *([92A1430]);\n\tthis.iconFXRotationSpeed = 50f;\n\tthis.iconFXAnimationAmount = 32.000007367134096d;\n\tthis.iconFXScale = 1f;\n\tthis.iconFXOffset = *([92A4660]);\n\tthis.iconFXStayDuration = 1.5f;\n\tthis.labelText = \"Label\";\n")]
		public HighlightProfile()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HighlightProfile::.ctor");
		}
	}
}
