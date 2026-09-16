using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine.Serialization;
using UnityEngine.U2D;

namespace UnityEngine.UI
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x7271A0", Offset = "0x7271A0")]
	[Token(Token = "0x2000015")]
	public class Image : MaskableGraphic, ISerializationCallbackReceiver, ILayoutElement, ICanvasRaycastFilter
	{
		[Token(Token = "0x2000080")]
		public enum Type
		{
			[Token(Token = "0x400023D")]
			Simple = 0,
			[Token(Token = "0x400023E")]
			Sliced = 1,
			[Token(Token = "0x400023F")]
			Tiled = 2,
			[Token(Token = "0x4000240")]
			Filled = 3
		}

		[Token(Token = "0x2000081")]
		public enum FillMethod
		{
			[Token(Token = "0x4000242")]
			Horizontal = 0,
			[Token(Token = "0x4000243")]
			Vertical = 1,
			[Token(Token = "0x4000244")]
			Radial90 = 2,
			[Token(Token = "0x4000245")]
			Radial180 = 3,
			[Token(Token = "0x4000246")]
			Radial360 = 4
		}

		[Token(Token = "0x2000082")]
		public enum OriginHorizontal
		{
			[Token(Token = "0x4000248")]
			Left = 0,
			[Token(Token = "0x4000249")]
			Right = 1
		}

		[Token(Token = "0x2000083")]
		public enum OriginVertical
		{
			[Token(Token = "0x400024B")]
			Bottom = 0,
			[Token(Token = "0x400024C")]
			Top = 1
		}

		[Token(Token = "0x2000084")]
		public enum Origin90
		{
			[Token(Token = "0x400024E")]
			BottomLeft = 0,
			[Token(Token = "0x400024F")]
			TopLeft = 1,
			[Token(Token = "0x4000250")]
			TopRight = 2,
			[Token(Token = "0x4000251")]
			BottomRight = 3
		}

		[Token(Token = "0x2000085")]
		public enum Origin180
		{
			[Token(Token = "0x4000253")]
			Bottom = 0,
			[Token(Token = "0x4000254")]
			Left = 1,
			[Token(Token = "0x4000255")]
			Top = 2,
			[Token(Token = "0x4000256")]
			Right = 3
		}

		[Token(Token = "0x2000086")]
		public enum Origin360
		{
			[Token(Token = "0x4000258")]
			Bottom = 0,
			[Token(Token = "0x4000259")]
			Right = 1,
			[Token(Token = "0x400025A")]
			Top = 2,
			[Token(Token = "0x400025B")]
			Left = 3
		}

		[Token(Token = "0x4000069")]
		protected static Material s_ETC1DefaultUI;

		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x7288A8", Offset = "0x7288A8")]
		[SerializeField]
		[Token(Token = "0x400006A")]
		[FieldOffset(Offset = "0xC0")]
		private Sprite m_Sprite;

		[NonSerialized]
		[Token(Token = "0x400006B")]
		[FieldOffset(Offset = "0xC8")]
		private Sprite m_OverrideSprite;

		[SerializeField]
		[Token(Token = "0x400006C")]
		[FieldOffset(Offset = "0xD0")]
		private Type m_Type;

		[SerializeField]
		[Token(Token = "0x400006D")]
		[FieldOffset(Offset = "0xD4")]
		private bool m_PreserveAspect;

		[SerializeField]
		[Token(Token = "0x400006E")]
		[FieldOffset(Offset = "0xD5")]
		private bool m_FillCenter;

		[SerializeField]
		[Token(Token = "0x400006F")]
		[FieldOffset(Offset = "0xD8")]
		private FillMethod m_FillMethod;

		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x728934", Offset = "0x728934")]
		[SerializeField]
		[Token(Token = "0x4000070")]
		[FieldOffset(Offset = "0xDC")]
		private float m_FillAmount;

		[SerializeField]
		[Token(Token = "0x4000071")]
		[FieldOffset(Offset = "0xE0")]
		private bool m_FillClockwise;

		[SerializeField]
		[Token(Token = "0x4000072")]
		[FieldOffset(Offset = "0xE4")]
		private int m_FillOrigin;

		[Token(Token = "0x4000073")]
		[FieldOffset(Offset = "0xE8")]
		private float m_AlphaHitTestMinimumThreshold;

		[Token(Token = "0x4000074")]
		[FieldOffset(Offset = "0xEC")]
		private bool m_Tracked;

		[SerializeField]
		[Token(Token = "0x4000075")]
		[FieldOffset(Offset = "0xED")]
		private bool m_UseSpriteMesh;

		[SerializeField]
		[Token(Token = "0x4000076")]
		[FieldOffset(Offset = "0xF0")]
		private float m_PixelsPerUnitMultiplier;

		[Token(Token = "0x4000077")]
		[FieldOffset(Offset = "0xF4")]
		private float m_CachedReferencePixelsPerUnit;

		[Token(Token = "0x4000078")]
		private static readonly Vector2[] s_VertScratch;

		[Token(Token = "0x4000079")]
		private static readonly Vector2[] s_UVScratch;

		[Token(Token = "0x400007A")]
		private static readonly Vector3[] s_Xy;

		[Token(Token = "0x400007B")]
		private static readonly Vector3[] s_Uv;

		[Token(Token = "0x400007C")]
		private static List<Image> m_TrackedTexturelessImages;

		[Token(Token = "0x400007D")]
		private static bool s_Initialized;

		[Token(Token = "0x1700003F")]
		public Sprite sprite
		{
			[Token(Token = "0x60000FF")]
			[Address(RVA = "0xF4C1F0", Offset = "0xF4C1F0", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000100")]
			[Address(RVA = "0xF4C1F8", Offset = "0xF4C1F8", Length = "0x318")]
			set
			{
			}
		}

		[Token(Token = "0x17000040")]
		public Sprite overrideSprite
		{
			[Token(Token = "0x6000102")]
			[Address(RVA = "0xF4C620", Offset = "0xF4C620", Length = "0x4")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000103")]
			[Address(RVA = "0xF4C6B4", Offset = "0xF4C6B4", Length = "0x90")]
			set
			{
			}
		}

		[Token(Token = "0x17000041")]
		private Sprite activeSprite
		{
			[Token(Token = "0x6000104")]
			[Address(RVA = "0xF4C624", Offset = "0xF4C624", Length = "0x90")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000042")]
		public Type type
		{
			[Token(Token = "0x6000105")]
			[Address(RVA = "0xF4C744", Offset = "0xF4C744", Length = "0x8")]
			get
			{
				return Type.Simple;
			}
			[Token(Token = "0x6000106")]
			[Address(RVA = "0xF4C74C", Offset = "0xF4C74C", Length = "0x88")]
			set
			{
			}
		}

		[Token(Token = "0x17000043")]
		public bool preserveAspect
		{
			[Token(Token = "0x6000107")]
			[Address(RVA = "0xF4C7D4", Offset = "0xF4C7D4", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000108")]
			[Address(RVA = "0xF4C7DC", Offset = "0xF4C7DC", Length = "0x88")]
			set
			{
			}
		}

		[Token(Token = "0x17000044")]
		public bool fillCenter
		{
			[Token(Token = "0x6000109")]
			[Address(RVA = "0xF4C864", Offset = "0xF4C864", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x600010A")]
			[Address(RVA = "0xF4C86C", Offset = "0xF4C86C", Length = "0x88")]
			set
			{
			}
		}

		[Token(Token = "0x17000045")]
		public FillMethod fillMethod
		{
			[Token(Token = "0x600010B")]
			[Address(RVA = "0xF4C8F4", Offset = "0xF4C8F4", Length = "0x8")]
			get
			{
				return FillMethod.Horizontal;
			}
			[Token(Token = "0x600010C")]
			[Address(RVA = "0xF4C8FC", Offset = "0xF4C8FC", Length = "0x80")]
			set
			{
			}
		}

		[Token(Token = "0x17000046")]
		public float fillAmount
		{
			[Token(Token = "0x600010D")]
			[Address(RVA = "0xF4C97C", Offset = "0xF4C97C", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600010E")]
			[Address(RVA = "0xF4C984", Offset = "0xF4C984", Length = "0xB4")]
			set
			{
			}
		}

		[Token(Token = "0x17000047")]
		public bool fillClockwise
		{
			[Token(Token = "0x600010F")]
			[Address(RVA = "0xF4CA38", Offset = "0xF4CA38", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000110")]
			[Address(RVA = "0xF4CA40", Offset = "0xF4CA40", Length = "0x88")]
			set
			{
			}
		}

		[Token(Token = "0x17000048")]
		public int fillOrigin
		{
			[Token(Token = "0x6000111")]
			[Address(RVA = "0xF4CAC8", Offset = "0xF4CAC8", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x6000112")]
			[Address(RVA = "0xF4CAD0", Offset = "0xF4CAD0", Length = "0x88")]
			set
			{
			}
		}

		[Obsolete]
		[Token(Token = "0x17000049")]
		public float eventAlphaThreshold
		{
			[Token(Token = "0x6000113")]
			[Address(RVA = "0xF4CB58", Offset = "0xF4CB58", Length = "0x10")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000114")]
			[Address(RVA = "0xF4CB68", Offset = "0xF4CB68", Length = "0x10")]
			set
			{
			}
		}

		[Token(Token = "0x1700004A")]
		public float alphaHitTestMinimumThreshold
		{
			[Token(Token = "0x6000115")]
			[Address(RVA = "0xF4CB78", Offset = "0xF4CB78", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000116")]
			[Address(RVA = "0xF4CB80", Offset = "0xF4CB80", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700004B")]
		public bool useSpriteMesh
		{
			[Token(Token = "0x6000117")]
			[Address(RVA = "0xF4CB88", Offset = "0xF4CB88", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000118")]
			[Address(RVA = "0xF4CB90", Offset = "0xF4CB90", Length = "0x88")]
			set
			{
			}
		}

		[Token(Token = "0x1700004C")]
		public static Material defaultETC1GraphicMaterial
		{
			[Token(Token = "0x600011A")]
			[Address(RVA = "0xF4CC64", Offset = "0xF4CC64", Length = "0xF8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700004D")]
		public override Texture mainTexture
		{
			[Token(Token = "0x600011B")]
			[Address(RVA = "0xF4CD5C", Offset = "0xF4CD5C", Length = "0x19C")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700004E")]
		public bool hasBorder
		{
			[Token(Token = "0x600011C")]
			[Address(RVA = "0xF4CEF8", Offset = "0xF4CEF8", Length = "0xCC")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x1700004F")]
		public float pixelsPerUnitMultiplier
		{
			[Token(Token = "0x600011D")]
			[Address(RVA = "0xF4CFC4", Offset = "0xF4CFC4", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600011E")]
			[Address(RVA = "0xF4CFCC", Offset = "0xF4CFCC", Length = "0x84")]
			set
			{
			}
		}

		[Token(Token = "0x17000050")]
		public float pixelsPerUnit
		{
			[Token(Token = "0x600011F")]
			[Address(RVA = "0xF4D050", Offset = "0xF4D050", Length = "0x114")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000051")]
		protected float multipliedPixelsPerUnit
		{
			[Token(Token = "0x6000120")]
			[Address(RVA = "0xF4D164", Offset = "0xF4D164", Length = "0x28")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000052")]
		public override Material material
		{
			[Token(Token = "0x6000121")]
			[Address(RVA = "0xF4D18C", Offset = "0xF4D18C", Length = "0x158")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000122")]
			[Address(RVA = "0xF4D2E4", Offset = "0xF4D2E4", Length = "0x4")]
			set
			{
			}
		}

		[Token(Token = "0x17000053")]
		public virtual float minWidth
		{
			[Token(Token = "0x600013C")]
			[Address(RVA = "0xF51EE8", Offset = "0xF51EE8", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000054")]
		public virtual float preferredWidth
		{
			[Token(Token = "0x600013D")]
			[Address(RVA = "0xF51EF0", Offset = "0xF51EF0", Length = "0xF4")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000055")]
		public virtual float flexibleWidth
		{
			[Token(Token = "0x600013E")]
			[Address(RVA = "0xF51FE4", Offset = "0xF51FE4", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000056")]
		public virtual float minHeight
		{
			[Token(Token = "0x600013F")]
			[Address(RVA = "0xF51FEC", Offset = "0xF51FEC", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000057")]
		public virtual float preferredHeight
		{
			[Token(Token = "0x6000140")]
			[Address(RVA = "0xF51FF4", Offset = "0xF51FF4", Length = "0xF4")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000058")]
		public virtual float flexibleHeight
		{
			[Token(Token = "0x6000141")]
			[Address(RVA = "0xF520E8", Offset = "0xF520E8", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000059")]
		public virtual int layoutPriority
		{
			[Token(Token = "0x6000142")]
			[Address(RVA = "0xF520F0", Offset = "0xF520F0", Length = "0x8")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x6000101")]
		[Address(RVA = "0xF4C618", Offset = "0xF4C618", Length = "0x8")]
		public void DisableSpriteOptimizations()
		{
		}

		[Token(Token = "0x6000119")]
		[Address(RVA = "0xF4CC18", Offset = "0xF4CC18", Length = "0x4C")]
		protected Image()
		{
		}

		[Token(Token = "0x6000123")]
		[Address(RVA = "0xF4D2E8", Offset = "0xF4D2E8", Length = "0x4")]
		public virtual void OnBeforeSerialize()
		{
		}

		[Token(Token = "0x6000124")]
		[Address(RVA = "0xF4D2EC", Offset = "0xF4D2EC", Length = "0xBC")]
		public virtual void OnAfterDeserialize()
		{
		}

		[Token(Token = "0x6000125")]
		[Address(RVA = "0xF4D3A8", Offset = "0xF4D3A8", Length = "0x15C")]
		private void PreserveSpriteAspectRatio(ref Rect rect, Vector2 spriteSize)
		{
		}

		[Token(Token = "0x6000126")]
		[Address(RVA = "0xF4D504", Offset = "0xF4D504", Length = "0x370")]
		private Vector4 GetDrawingDimensions(bool shouldPreserveAspect)
		{
			return default(Vector4);
		}

		[Token(Token = "0x6000127")]
		[Address(RVA = "0xF4D874", Offset = "0xF4D874", Length = "0x1A0")]
		public override void SetNativeSize()
		{
		}

		[Token(Token = "0x6000128")]
		[Address(RVA = "0xF4DA14", Offset = "0xF4DA14", Length = "0x24")]
		protected override void OnRectTransformDimensionsChange()
		{
		}

		[Token(Token = "0x6000129")]
		[Address(RVA = "0xF4DA38", Offset = "0xF4DA38", Length = "0x28")]
		protected override void OnTransformParentChanged()
		{
		}

		[Token(Token = "0x600012A")]
		[Address(RVA = "0xF4DA60", Offset = "0xF4DA60", Length = "0x150")]
		protected override void OnPopulateMesh(VertexHelper toFill)
		{
		}

		[Token(Token = "0x600012B")]
		[Address(RVA = "0xF4C510", Offset = "0xF4C510", Length = "0x108")]
		private void TrackSprite()
		{
		}

		[Token(Token = "0x600012C")]
		[Address(RVA = "0xF50EF8", Offset = "0xF50EF8", Length = "0x28")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x600012D")]
		[Address(RVA = "0xF50F20", Offset = "0xF50F20", Length = "0x84")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x600012E")]
		[Address(RVA = "0xF51028", Offset = "0xF51028", Length = "0x118")]
		protected override void UpdateMaterial()
		{
		}

		[Token(Token = "0x600012F")]
		[Address(RVA = "0xF51140", Offset = "0xF51140", Length = "0x118")]
		protected override void OnCanvasHierarchyChanged()
		{
		}

		[Token(Token = "0x6000130")]
		[Address(RVA = "0xF4DBB0", Offset = "0xF4DBB0", Length = "0x354")]
		private void GenerateSimpleSprite(VertexHelper vh, bool lPreserveAspect)
		{
		}

		[Token(Token = "0x6000131")]
		[Address(RVA = "0xF4DF04", Offset = "0xF4DF04", Length = "0x430")]
		private void GenerateSprite(VertexHelper vh, bool lPreserveAspect)
		{
		}

		[Token(Token = "0x6000132")]
		[Address(RVA = "0xF4E334", Offset = "0xF4E334", Length = "0x760")]
		private void GenerateSlicedSprite(VertexHelper toFill)
		{
		}

		[Token(Token = "0x6000133")]
		[Address(RVA = "0xF4EA94", Offset = "0xF4EA94", Length = "0x149C")]
		private void GenerateTiledSprite(VertexHelper toFill)
		{
		}

		[Token(Token = "0x6000134")]
		[Address(RVA = "0xF51664", Offset = "0xF51664", Length = "0x190")]
		private static void AddQuad(VertexHelper vertexHelper, Vector3[] quadPositions, Color32 color, Vector3[] quadUVs)
		{
		}

		[Token(Token = "0x6000135")]
		[Address(RVA = "0xF51454", Offset = "0xF51454", Length = "0x210")]
		private static void AddQuad(VertexHelper vertexHelper, Vector2 posMin, Vector2 posMax, Color32 color, Vector2 uvMin, Vector2 uvMax)
		{
		}

		[Token(Token = "0x6000136")]
		[Address(RVA = "0xF51258", Offset = "0xF51258", Length = "0x1FC")]
		private Vector4 GetAdjustedBorders(Vector4 border, Rect adjustedRect)
		{
			return default(Vector4);
		}

		[Token(Token = "0x6000137")]
		[Address(RVA = "0xF4FF30", Offset = "0xF4FF30", Length = "0xE90")]
		private void GenerateFilledSprite(VertexHelper toFill, bool preserveAspect)
		{
		}

		[Token(Token = "0x6000138")]
		[Address(RVA = "0xF517F4", Offset = "0xF517F4", Length = "0x16C")]
		private static bool RadialCut(Vector3[] xy, Vector3[] uv, float fill, bool invert, int corner)
		{
			return false;
		}

		[Token(Token = "0x6000139")]
		[Address(RVA = "0xF51960", Offset = "0xF51960", Length = "0x580")]
		private static void RadialCut(Vector3[] xy, float cos, float sin, bool invert, int corner)
		{
		}

		[Token(Token = "0x600013A")]
		[Address(RVA = "0xF51EE0", Offset = "0xF51EE0", Length = "0x4")]
		public virtual void CalculateLayoutInputHorizontal()
		{
		}

		[Token(Token = "0x600013B")]
		[Address(RVA = "0xF51EE4", Offset = "0xF51EE4", Length = "0x4")]
		public virtual void CalculateLayoutInputVertical()
		{
		}

		[Token(Token = "0x6000143")]
		[Address(RVA = "0xF520F8", Offset = "0xF520F8", Length = "0x39C")]
		public virtual bool IsRaycastLocationValid(Vector2 screenPoint, Camera eventCamera)
		{
			return false;
		}

		[Token(Token = "0x6000144")]
		[Address(RVA = "0xF52494", Offset = "0xF52494", Length = "0x4F0")]
		private Vector2 MapCoordinate(Vector2 local, Rect rect)
		{
			return default(Vector2);
		}

		[Token(Token = "0x6000145")]
		[Address(RVA = "0xF52984", Offset = "0xF52984", Length = "0x160")]
		private static void RebuildImage(SpriteAtlas spriteAtlas)
		{
		}

		[Token(Token = "0x6000146")]
		[Address(RVA = "0xF50DC0", Offset = "0xF50DC0", Length = "0x138")]
		private static void TrackImage(Image g)
		{
		}

		[Token(Token = "0x6000147")]
		[Address(RVA = "0xF50FA4", Offset = "0xF50FA4", Length = "0x84")]
		private static void UnTrackImage(Image g)
		{
		}
	}
}
