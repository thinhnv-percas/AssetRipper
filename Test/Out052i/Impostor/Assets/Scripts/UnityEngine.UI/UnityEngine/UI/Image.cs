using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine.Serialization;
using UnityEngine.U2D;

namespace UnityEngine.UI
{
	[RequireComponent(typeof(CanvasRenderer))]
	[AddComponentMenu("UI/Image", 11)]
	[Token(Token = "0x2000024")]
	public class Image : MaskableGraphic, ISerializationCallbackReceiver, ILayoutElement, ICanvasRaycastFilter
	{
		[Token(Token = "0x2000025")]
		public enum Type
		{
			[Token(Token = "0x40000AC")]
			Simple = 0,
			[Token(Token = "0x40000AD")]
			Sliced = 1,
			[Token(Token = "0x40000AE")]
			Tiled = 2,
			[Token(Token = "0x40000AF")]
			Filled = 3
		}

		[Token(Token = "0x2000026")]
		public enum FillMethod
		{
			[Token(Token = "0x40000B1")]
			Horizontal = 0,
			[Token(Token = "0x40000B2")]
			Vertical = 1,
			[Token(Token = "0x40000B3")]
			Radial90 = 2,
			[Token(Token = "0x40000B4")]
			Radial180 = 3,
			[Token(Token = "0x40000B5")]
			Radial360 = 4
		}

		[Token(Token = "0x2000027")]
		public enum OriginHorizontal
		{
			[Token(Token = "0x40000B7")]
			Left = 0,
			[Token(Token = "0x40000B8")]
			Right = 1
		}

		[Token(Token = "0x2000028")]
		public enum OriginVertical
		{
			[Token(Token = "0x40000BA")]
			Bottom = 0,
			[Token(Token = "0x40000BB")]
			Top = 1
		}

		[Token(Token = "0x2000029")]
		public enum Origin90
		{
			[Token(Token = "0x40000BD")]
			BottomLeft = 0,
			[Token(Token = "0x40000BE")]
			TopLeft = 1,
			[Token(Token = "0x40000BF")]
			TopRight = 2,
			[Token(Token = "0x40000C0")]
			BottomRight = 3
		}

		[Token(Token = "0x200002A")]
		public enum Origin180
		{
			[Token(Token = "0x40000C2")]
			Bottom = 0,
			[Token(Token = "0x40000C3")]
			Left = 1,
			[Token(Token = "0x40000C4")]
			Top = 2,
			[Token(Token = "0x40000C5")]
			Right = 3
		}

		[Token(Token = "0x200002B")]
		public enum Origin360
		{
			[Token(Token = "0x40000C7")]
			Bottom = 0,
			[Token(Token = "0x40000C8")]
			Right = 1,
			[Token(Token = "0x40000C9")]
			Top = 2,
			[Token(Token = "0x40000CA")]
			Left = 3
		}

		[Token(Token = "0x4000096")]
		protected static Material s_ETC1DefaultUI;

		[SerializeField]
		[FormerlySerializedAs("m_Frame")]
		[Token(Token = "0x4000097")]
		[FieldOffset(Offset = "0xD8")]
		private Sprite m_Sprite;

		[NonSerialized]
		[Token(Token = "0x4000098")]
		[FieldOffset(Offset = "0xE0")]
		private Sprite m_OverrideSprite;

		[SerializeField]
		[Token(Token = "0x4000099")]
		[FieldOffset(Offset = "0xE8")]
		private Type m_Type;

		[SerializeField]
		[Token(Token = "0x400009A")]
		[FieldOffset(Offset = "0xEC")]
		private bool m_PreserveAspect;

		[SerializeField]
		[Token(Token = "0x400009B")]
		[FieldOffset(Offset = "0xED")]
		private bool m_FillCenter;

		[SerializeField]
		[Token(Token = "0x400009C")]
		[FieldOffset(Offset = "0xF0")]
		private FillMethod m_FillMethod;

		[Range(0f, 1f)]
		[SerializeField]
		[Token(Token = "0x400009D")]
		[FieldOffset(Offset = "0xF4")]
		private float m_FillAmount;

		[SerializeField]
		[Token(Token = "0x400009E")]
		[FieldOffset(Offset = "0xF8")]
		private bool m_FillClockwise;

		[SerializeField]
		[Token(Token = "0x400009F")]
		[FieldOffset(Offset = "0xFC")]
		private int m_FillOrigin;

		[Token(Token = "0x40000A0")]
		[FieldOffset(Offset = "0x100")]
		private float m_AlphaHitTestMinimumThreshold;

		[Token(Token = "0x40000A1")]
		[FieldOffset(Offset = "0x104")]
		private bool m_Tracked;

		[SerializeField]
		[Token(Token = "0x40000A2")]
		[FieldOffset(Offset = "0x105")]
		private bool m_UseSpriteMesh;

		[SerializeField]
		[Token(Token = "0x40000A3")]
		[FieldOffset(Offset = "0x108")]
		private float m_PixelsPerUnitMultiplier;

		[Token(Token = "0x40000A4")]
		[FieldOffset(Offset = "0x10C")]
		private float m_CachedReferencePixelsPerUnit;

		[Token(Token = "0x40000A5")]
		private static readonly Vector2[] s_VertScratch;

		[Token(Token = "0x40000A6")]
		private static readonly Vector2[] s_UVScratch;

		[Token(Token = "0x40000A7")]
		private static readonly Vector3[] s_Xy;

		[Token(Token = "0x40000A8")]
		private static readonly Vector3[] s_Uv;

		[Token(Token = "0x40000A9")]
		private static List<Image> m_TrackedTexturelessImages;

		[Token(Token = "0x40000AA")]
		private static bool s_Initialized;

		[Token(Token = "0x1700004B")]
		public Sprite sprite
		{
			[Token(Token = "0x600013D")]
			[Address(RVA = "0x16D0AA8", Offset = "0x16D0AA8", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600013E")]
			[Address(RVA = "0x16C4134", Offset = "0x16C4134", Length = "0x2B4")]
			set
			{
			}
		}

		[Token(Token = "0x1700004C")]
		public Sprite overrideSprite
		{
			[Token(Token = "0x6000140")]
			[Address(RVA = "0x16D0C34", Offset = "0x16D0C34", Length = "0x4")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000141")]
			[Address(RVA = "0x16D0CB0", Offset = "0x16D0CB0", Length = "0x88")]
			set
			{
			}
		}

		[Token(Token = "0x1700004D")]
		private Sprite activeSprite
		{
			[Token(Token = "0x6000142")]
			[Address(RVA = "0x16D0C38", Offset = "0x16D0C38", Length = "0x78")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700004E")]
		public Type type
		{
			[Token(Token = "0x6000143")]
			[Address(RVA = "0x16D0D38", Offset = "0x16D0D38", Length = "0x8")]
			get
			{
				return Type.Simple;
			}
			[Token(Token = "0x6000144")]
			[Address(RVA = "0x16C43E8", Offset = "0x16C43E8", Length = "0x80")]
			set
			{
			}
		}

		[Token(Token = "0x1700004F")]
		public bool preserveAspect
		{
			[Token(Token = "0x6000145")]
			[Address(RVA = "0x16D0D40", Offset = "0x16D0D40", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000146")]
			[Address(RVA = "0x16D0D48", Offset = "0x16D0D48", Length = "0x80")]
			set
			{
			}
		}

		[Token(Token = "0x17000050")]
		public bool fillCenter
		{
			[Token(Token = "0x6000147")]
			[Address(RVA = "0x16D0DC8", Offset = "0x16D0DC8", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000148")]
			[Address(RVA = "0x16D0DD0", Offset = "0x16D0DD0", Length = "0x80")]
			set
			{
			}
		}

		[Token(Token = "0x17000051")]
		public FillMethod fillMethod
		{
			[Token(Token = "0x6000149")]
			[Address(RVA = "0x16D0E50", Offset = "0x16D0E50", Length = "0x8")]
			get
			{
				return FillMethod.Horizontal;
			}
			[Token(Token = "0x600014A")]
			[Address(RVA = "0x16D0E58", Offset = "0x16D0E58", Length = "0x78")]
			set
			{
			}
		}

		[Token(Token = "0x17000052")]
		public float fillAmount
		{
			[Token(Token = "0x600014B")]
			[Address(RVA = "0x16D0ED0", Offset = "0x16D0ED0", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600014C")]
			[Address(RVA = "0x16D0ED8", Offset = "0x16D0ED8", Length = "0x90")]
			set
			{
			}
		}

		[Token(Token = "0x17000053")]
		public bool fillClockwise
		{
			[Token(Token = "0x600014D")]
			[Address(RVA = "0x16D0F68", Offset = "0x16D0F68", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x600014E")]
			[Address(RVA = "0x16D0F70", Offset = "0x16D0F70", Length = "0x80")]
			set
			{
			}
		}

		[Token(Token = "0x17000054")]
		public int fillOrigin
		{
			[Token(Token = "0x600014F")]
			[Address(RVA = "0x16D0FF0", Offset = "0x16D0FF0", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x6000150")]
			[Address(RVA = "0x16D0FF8", Offset = "0x16D0FF8", Length = "0x80")]
			set
			{
			}
		}

		[Obsolete("eventAlphaThreshold has been deprecated. Use eventMinimumAlphaThreshold instead (UnityUpgradable) -> alphaHitTestMinimumThreshold")]
		[Token(Token = "0x17000055")]
		public float eventAlphaThreshold
		{
			[Token(Token = "0x6000151")]
			[Address(RVA = "0x16D1078", Offset = "0x16D1078", Length = "0x10")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000152")]
			[Address(RVA = "0x16D1088", Offset = "0x16D1088", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x17000056")]
		public float alphaHitTestMinimumThreshold
		{
			[Token(Token = "0x6000153")]
			[Address(RVA = "0x16D11D4", Offset = "0x16D11D4", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000154")]
			[Address(RVA = "0x16D1094", Offset = "0x16D1094", Length = "0x140")]
			set
			{
			}
		}

		[Token(Token = "0x17000057")]
		public bool useSpriteMesh
		{
			[Token(Token = "0x6000155")]
			[Address(RVA = "0x16D11DC", Offset = "0x16D11DC", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000156")]
			[Address(RVA = "0x16D11E4", Offset = "0x16D11E4", Length = "0x80")]
			set
			{
			}
		}

		[Token(Token = "0x17000058")]
		public static Material defaultETC1GraphicMaterial
		{
			[Token(Token = "0x6000158")]
			[Address(RVA = "0x16D12A4", Offset = "0x16D12A4", Length = "0xDC")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000059")]
		public override Texture mainTexture
		{
			[Token(Token = "0x6000159")]
			[Address(RVA = "0x16D1380", Offset = "0x16D1380", Length = "0x178")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700005A")]
		public bool hasBorder
		{
			[Token(Token = "0x600015A")]
			[Address(RVA = "0x16D14F8", Offset = "0x16D14F8", Length = "0xB8")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x1700005B")]
		public float pixelsPerUnitMultiplier
		{
			[Token(Token = "0x600015B")]
			[Address(RVA = "0x16D15B0", Offset = "0x16D15B0", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600015C")]
			[Address(RVA = "0x16D15B8", Offset = "0x16D15B8", Length = "0x20")]
			set
			{
			}
		}

		[Token(Token = "0x1700005C")]
		public float pixelsPerUnit
		{
			[Token(Token = "0x600015D")]
			[Address(RVA = "0x16D15D8", Offset = "0x16D15D8", Length = "0xF4")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x1700005D")]
		protected float multipliedPixelsPerUnit
		{
			[Token(Token = "0x600015E")]
			[Address(RVA = "0x16D16CC", Offset = "0x16D16CC", Length = "0x1C")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x1700005E")]
		public override Material material
		{
			[Token(Token = "0x600015F")]
			[Address(RVA = "0x16D16E8", Offset = "0x16D16E8", Length = "0x12C")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000160")]
			[Address(RVA = "0x16D1814", Offset = "0x16D1814", Length = "0x4")]
			set
			{
			}
		}

		[Token(Token = "0x1700005F")]
		public virtual float minWidth
		{
			[Token(Token = "0x6000178")]
			[Address(RVA = "0x16D4D88", Offset = "0x16D4D88", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000060")]
		public virtual float preferredWidth
		{
			[Token(Token = "0x6000179")]
			[Address(RVA = "0x16D4D90", Offset = "0x16D4D90", Length = "0xC8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000061")]
		public virtual float flexibleWidth
		{
			[Token(Token = "0x600017A")]
			[Address(RVA = "0x16D4E58", Offset = "0x16D4E58", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000062")]
		public virtual float minHeight
		{
			[Token(Token = "0x600017B")]
			[Address(RVA = "0x16D4E60", Offset = "0x16D4E60", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000063")]
		public virtual float preferredHeight
		{
			[Token(Token = "0x600017C")]
			[Address(RVA = "0x16D4E68", Offset = "0x16D4E68", Length = "0xC8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000064")]
		public virtual float flexibleHeight
		{
			[Token(Token = "0x600017D")]
			[Address(RVA = "0x16D4F30", Offset = "0x16D4F30", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000065")]
		public virtual int layoutPriority
		{
			[Token(Token = "0x600017E")]
			[Address(RVA = "0x16D4F38", Offset = "0x16D4F38", Length = "0x8")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x600013F")]
		[Address(RVA = "0x16D0C2C", Offset = "0x16D0C2C", Length = "0x8")]
		public void DisableSpriteOptimizations()
		{
		}

		[Token(Token = "0x6000157")]
		[Address(RVA = "0x16D1264", Offset = "0x16D1264", Length = "0x40")]
		protected Image()
		{
		}

		[Token(Token = "0x6000161")]
		[Address(RVA = "0x16D1818", Offset = "0x16D1818", Length = "0x4")]
		public virtual void OnBeforeSerialize()
		{
		}

		[Token(Token = "0x6000162")]
		[Address(RVA = "0x16D181C", Offset = "0x16D181C", Length = "0x50")]
		public virtual void OnAfterDeserialize()
		{
		}

		[Token(Token = "0x6000163")]
		[Address(RVA = "0x16D186C", Offset = "0x16D186C", Length = "0x94")]
		private void PreserveSpriteAspectRatio(ref Rect rect, Vector2 spriteSize)
		{
		}

		[Token(Token = "0x6000164")]
		[Address(RVA = "0x16D1900", Offset = "0x16D1900", Length = "0x3B0")]
		private Vector4 GetDrawingDimensions(bool shouldPreserveAspect)
		{
			return default(Vector4);
		}

		[Token(Token = "0x6000165")]
		[Address(RVA = "0x16D1CB0", Offset = "0x16D1CB0", Length = "0x140")]
		public override void SetNativeSize()
		{
		}

		[Token(Token = "0x6000166")]
		[Address(RVA = "0x16D1DF0", Offset = "0x16D1DF0", Length = "0x144")]
		protected override void OnPopulateMesh(VertexHelper toFill)
		{
		}

		[Token(Token = "0x6000167")]
		[Address(RVA = "0x16D0B40", Offset = "0x16D0B40", Length = "0xEC")]
		private void TrackSprite()
		{
		}

		[Token(Token = "0x6000168")]
		[Address(RVA = "0x16D4230", Offset = "0x16D4230", Length = "0x1C")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x6000169")]
		[Address(RVA = "0x16D424C", Offset = "0x16D424C", Length = "0x74")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x600016A")]
		[Address(RVA = "0x16D4340", Offset = "0x16D4340", Length = "0xF4")]
		protected override void UpdateMaterial()
		{
		}

		[Token(Token = "0x600016B")]
		[Address(RVA = "0x16D4434", Offset = "0x16D4434", Length = "0x108")]
		protected override void OnCanvasHierarchyChanged()
		{
		}

		[Token(Token = "0x600016C")]
		[Address(RVA = "0x16D1F34", Offset = "0x16D1F34", Length = "0x2C4")]
		private void GenerateSimpleSprite(VertexHelper vh, bool lPreserveAspect)
		{
		}

		[Token(Token = "0x600016D")]
		[Address(RVA = "0x16D21F8", Offset = "0x16D21F8", Length = "0x2E0")]
		private void GenerateSprite(VertexHelper vh, bool lPreserveAspect)
		{
		}

		[Token(Token = "0x600016E")]
		[Address(RVA = "0x16D24D8", Offset = "0x16D24D8", Length = "0x5C0")]
		private void GenerateSlicedSprite(VertexHelper toFill)
		{
		}

		[Token(Token = "0x600016F")]
		[Address(RVA = "0x16D2A98", Offset = "0x16D2A98", Length = "0xD58")]
		private void GenerateTiledSprite(VertexHelper toFill)
		{
		}

		[Token(Token = "0x6000170")]
		[Address(RVA = "0x16D4750", Offset = "0x16D4750", Length = "0xE4")]
		private static void AddQuad(VertexHelper vertexHelper, Vector3[] quadPositions, Color32 color, Vector3[] quadUVs)
		{
		}

		[Token(Token = "0x6000171")]
		[Address(RVA = "0x16D45FC", Offset = "0x16D45FC", Length = "0x154")]
		private static void AddQuad(VertexHelper vertexHelper, Vector2 posMin, Vector2 posMax, Color32 color, Vector2 uvMin, Vector2 uvMax)
		{
		}

		[Token(Token = "0x6000172")]
		[Address(RVA = "0x16D453C", Offset = "0x16D453C", Length = "0xC0")]
		private Vector4 GetAdjustedBorders(Vector4 border, Rect adjustedRect)
		{
			return default(Vector4);
		}

		[Token(Token = "0x6000173")]
		[Address(RVA = "0x16D37F0", Offset = "0x16D37F0", Length = "0x8E8")]
		private void GenerateFilledSprite(VertexHelper toFill, bool preserveAspect)
		{
		}

		[Token(Token = "0x6000174")]
		[Address(RVA = "0x16D4834", Offset = "0x16D4834", Length = "0x120")]
		private static bool RadialCut(Vector3[] xy, Vector3[] uv, float fill, bool invert, int corner)
		{
			return false;
		}

		[Token(Token = "0x6000175")]
		[Address(RVA = "0x16D4954", Offset = "0x16D4954", Length = "0x42C")]
		private static void RadialCut(Vector3[] xy, float cos, float sin, bool invert, int corner)
		{
		}

		[Token(Token = "0x6000176")]
		[Address(RVA = "0x16D4D80", Offset = "0x16D4D80", Length = "0x4")]
		public virtual void CalculateLayoutInputHorizontal()
		{
		}

		[Token(Token = "0x6000177")]
		[Address(RVA = "0x16D4D84", Offset = "0x16D4D84", Length = "0x4")]
		public virtual void CalculateLayoutInputVertical()
		{
		}

		[Token(Token = "0x600017F")]
		[Address(RVA = "0x16D4F40", Offset = "0x16D4F40", Length = "0x38C")]
		public virtual bool IsRaycastLocationValid(Vector2 screenPoint, Camera eventCamera)
		{
			return false;
		}

		[Token(Token = "0x6000180")]
		[Address(RVA = "0x16D52CC", Offset = "0x16D52CC", Length = "0x258")]
		private Vector2 MapCoordinate(Vector2 local, Rect rect)
		{
			return default(Vector2);
		}

		[Token(Token = "0x6000181")]
		[Address(RVA = "0x16D5524", Offset = "0x16D5524", Length = "0x1A8")]
		private static void RebuildImage(SpriteAtlas spriteAtlas)
		{
		}

		[Token(Token = "0x6000182")]
		[Address(RVA = "0x16D40D8", Offset = "0x16D40D8", Length = "0x158")]
		private static void TrackImage(Image g)
		{
		}

		[Token(Token = "0x6000183")]
		[Address(RVA = "0x16D42C0", Offset = "0x16D42C0", Length = "0x80")]
		private static void UnTrackImage(Image g)
		{
		}

		[Token(Token = "0x6000184")]
		[Address(RVA = "0x16D56CC", Offset = "0x16D56CC", Length = "0x38")]
		protected override void OnDidApplyAnimationProperties()
		{
		}
	}
}
