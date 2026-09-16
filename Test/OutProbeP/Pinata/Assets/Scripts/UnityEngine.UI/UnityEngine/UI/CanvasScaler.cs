using System;
using Cpp2ILInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x727318", Offset = "0x727318")]
	[ExecuteAlways]
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x727318", Offset = "0x727318")]
	[DisallowMultipleComponent]
	[Token(Token = "0x200001A")]
	public class CanvasScaler : UIBehaviour
	{
		[Token(Token = "0x2000092")]
		public enum ScaleMode
		{
			[Token(Token = "0x4000287")]
			ConstantPixelSize = 0,
			[Token(Token = "0x4000288")]
			ScaleWithScreenSize = 1,
			[Token(Token = "0x4000289")]
			ConstantPhysicalSize = 2
		}

		[Token(Token = "0x2000093")]
		public enum ScreenMatchMode
		{
			[Token(Token = "0x400028B")]
			MatchWidthOrHeight = 0,
			[Token(Token = "0x400028C")]
			Expand = 1,
			[Token(Token = "0x400028D")]
			Shrink = 2
		}

		[Token(Token = "0x2000094")]
		public enum Unit
		{
			[Token(Token = "0x400028F")]
			Centimeters = 0,
			[Token(Token = "0x4000290")]
			Millimeters = 1,
			[Token(Token = "0x4000291")]
			Inches = 2,
			[Token(Token = "0x4000292")]
			Points = 3,
			[Token(Token = "0x4000293")]
			Picas = 4
		}

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x728EB0", Offset = "0x728EB0")]
		[SerializeField]
		[Token(Token = "0x40000B5")]
		[FieldOffset(Offset = "0x18")]
		private ScaleMode m_UiScaleMode;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x728EFC", Offset = "0x728EFC")]
		[SerializeField]
		[Token(Token = "0x40000B6")]
		[FieldOffset(Offset = "0x1C")]
		protected float m_ReferencePixelsPerUnit;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x728F48", Offset = "0x728F48")]
		[SerializeField]
		[Token(Token = "0x40000B7")]
		[FieldOffset(Offset = "0x20")]
		protected float m_ScaleFactor;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x728F94", Offset = "0x728F94")]
		[SerializeField]
		[Token(Token = "0x40000B8")]
		[FieldOffset(Offset = "0x24")]
		protected Vector2 m_ReferenceResolution;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x728FE0", Offset = "0x728FE0")]
		[SerializeField]
		[Token(Token = "0x40000B9")]
		[FieldOffset(Offset = "0x2C")]
		protected ScreenMatchMode m_ScreenMatchMode;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x72902C", Offset = "0x72902C")]
		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x72902C", Offset = "0x72902C")]
		[SerializeField]
		[Token(Token = "0x40000BA")]
		[FieldOffset(Offset = "0x30")]
		protected float m_MatchWidthOrHeight;

		[Token(Token = "0x40000BB")]
		private const float kLogBase = 2f;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x729090", Offset = "0x729090")]
		[SerializeField]
		[Token(Token = "0x40000BC")]
		[FieldOffset(Offset = "0x34")]
		protected Unit m_PhysicalUnit;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7290DC", Offset = "0x7290DC")]
		[SerializeField]
		[Token(Token = "0x40000BD")]
		[FieldOffset(Offset = "0x38")]
		protected float m_FallbackScreenDPI;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x729128", Offset = "0x729128")]
		[SerializeField]
		[Token(Token = "0x40000BE")]
		[FieldOffset(Offset = "0x3C")]
		protected float m_DefaultSpriteDPI;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x729174", Offset = "0x729174")]
		[SerializeField]
		[Token(Token = "0x40000BF")]
		[FieldOffset(Offset = "0x40")]
		protected float m_DynamicPixelsPerUnit;

		[Token(Token = "0x40000C0")]
		[FieldOffset(Offset = "0x48")]
		private Canvas m_Canvas;

		[NonSerialized]
		[Token(Token = "0x40000C1")]
		[FieldOffset(Offset = "0x50")]
		private float m_PrevScaleFactor;

		[NonSerialized]
		[Token(Token = "0x40000C2")]
		[FieldOffset(Offset = "0x54")]
		private float m_PrevReferencePixelsPerUnit;

		[Token(Token = "0x1700008A")]
		public ScaleMode uiScaleMode
		{
			[Token(Token = "0x60001F8")]
			[Address(RVA = "0xC4CE4C", Offset = "0xC4CE4C", Length = "0x8")]
			get
			{
				return ScaleMode.ConstantPixelSize;
			}
			[Token(Token = "0x60001F9")]
			[Address(RVA = "0xC4CE54", Offset = "0xC4CE54", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700008B")]
		public float referencePixelsPerUnit
		{
			[Token(Token = "0x60001FA")]
			[Address(RVA = "0xC4CE5C", Offset = "0xC4CE5C", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60001FB")]
			[Address(RVA = "0xC4CE64", Offset = "0xC4CE64", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700008C")]
		public float scaleFactor
		{
			[Token(Token = "0x60001FC")]
			[Address(RVA = "0xC4CE6C", Offset = "0xC4CE6C", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60001FD")]
			[Address(RVA = "0xC4CE74", Offset = "0xC4CE74", Length = "0x84")]
			set
			{
			}
		}

		[Token(Token = "0x1700008D")]
		public Vector2 referenceResolution
		{
			[Token(Token = "0x60001FE")]
			[Address(RVA = "0xC4CEF8", Offset = "0xC4CEF8", Length = "0x8")]
			get
			{
				return default(Vector2);
			}
			[Token(Token = "0x60001FF")]
			[Address(RVA = "0xC4CF00", Offset = "0xC4CF00", Length = "0x100")]
			set
			{
			}
		}

		[Token(Token = "0x1700008E")]
		public ScreenMatchMode screenMatchMode
		{
			[Token(Token = "0x6000200")]
			[Address(RVA = "0xC4D000", Offset = "0xC4D000", Length = "0x8")]
			get
			{
				return ScreenMatchMode.MatchWidthOrHeight;
			}
			[Token(Token = "0x6000201")]
			[Address(RVA = "0xC4D008", Offset = "0xC4D008", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700008F")]
		public float matchWidthOrHeight
		{
			[Token(Token = "0x6000202")]
			[Address(RVA = "0xC4D010", Offset = "0xC4D010", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000203")]
			[Address(RVA = "0xC4D018", Offset = "0xC4D018", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000090")]
		public Unit physicalUnit
		{
			[Token(Token = "0x6000204")]
			[Address(RVA = "0xC4D020", Offset = "0xC4D020", Length = "0x8")]
			get
			{
				return Unit.Centimeters;
			}
			[Token(Token = "0x6000205")]
			[Address(RVA = "0xC4D028", Offset = "0xC4D028", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000091")]
		public float fallbackScreenDPI
		{
			[Token(Token = "0x6000206")]
			[Address(RVA = "0xC4D030", Offset = "0xC4D030", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000207")]
			[Address(RVA = "0xC4D038", Offset = "0xC4D038", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000092")]
		public float defaultSpriteDPI
		{
			[Token(Token = "0x6000208")]
			[Address(RVA = "0xC4D040", Offset = "0xC4D040", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000209")]
			[Address(RVA = "0xC4D048", Offset = "0xC4D048", Length = "0x80")]
			set
			{
			}
		}

		[Token(Token = "0x17000093")]
		public float dynamicPixelsPerUnit
		{
			[Token(Token = "0x600020A")]
			[Address(RVA = "0xC4D0C8", Offset = "0xC4D0C8", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600020B")]
			[Address(RVA = "0xC4D0D0", Offset = "0xC4D0D0", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x600020C")]
		[Address(RVA = "0xC4D0D8", Offset = "0xC4D0D8", Length = "0x84")]
		protected CanvasScaler()
		{
		}

		[Token(Token = "0x600020D")]
		[Address(RVA = "0xC4D15C", Offset = "0xC4D15C", Length = "0x68")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x600020E")]
		[Address(RVA = "0xC4D1C4", Offset = "0xC4D1C4", Length = "0x30")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x600020F")]
		[Address(RVA = "0xC4D294", Offset = "0xC4D294", Length = "0x10")]
		protected virtual void Update()
		{
		}

		[Token(Token = "0x6000210")]
		[Address(RVA = "0xC4D2A4", Offset = "0xC4D2A4", Length = "0x10C")]
		protected virtual void Handle()
		{
		}

		[Token(Token = "0x6000211")]
		[Address(RVA = "0xC4D3B0", Offset = "0xC4D3B0", Length = "0x2C")]
		protected virtual void HandleWorldCanvas()
		{
		}

		[Token(Token = "0x6000212")]
		[Address(RVA = "0xC4D3DC", Offset = "0xC4D3DC", Length = "0x2C")]
		protected virtual void HandleConstantPixelSize()
		{
		}

		[Token(Token = "0x6000213")]
		[Address(RVA = "0xC4D408", Offset = "0xC4D408", Length = "0x27C")]
		protected virtual void HandleScaleWithScreenSize()
		{
		}

		[Token(Token = "0x6000214")]
		[Address(RVA = "0xC4D684", Offset = "0xC4D684", Length = "0x78")]
		protected virtual void HandleConstantPhysicalSize()
		{
		}

		[Token(Token = "0x6000215")]
		[Address(RVA = "0xC4D1F4", Offset = "0xC4D1F4", Length = "0x50")]
		protected void SetScaleFactor(float scaleFactor)
		{
		}

		[Token(Token = "0x6000216")]
		[Address(RVA = "0xC4D244", Offset = "0xC4D244", Length = "0x50")]
		protected void SetReferencePixelsPerUnit(float referencePixelsPerUnit)
		{
		}
	}
}
