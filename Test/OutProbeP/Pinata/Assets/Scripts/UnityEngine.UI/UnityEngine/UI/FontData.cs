using System;
using Cpp2ILInjected;
using UnityEngine.Serialization;

namespace UnityEngine.UI
{
	[Serializable]
	[Token(Token = "0x200000F")]
	public class FontData : ISerializationCallbackReceiver
	{
		[SerializeField]
		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x728598", Offset = "0x728598")]
		[Token(Token = "0x400003D")]
		[FieldOffset(Offset = "0x10")]
		private Font m_Font;

		[SerializeField]
		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x7285E4", Offset = "0x7285E4")]
		[Token(Token = "0x400003E")]
		[FieldOffset(Offset = "0x18")]
		private int m_FontSize;

		[SerializeField]
		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x728630", Offset = "0x728630")]
		[Token(Token = "0x400003F")]
		[FieldOffset(Offset = "0x1C")]
		private FontStyle m_FontStyle;

		[SerializeField]
		[Token(Token = "0x4000040")]
		[FieldOffset(Offset = "0x20")]
		private bool m_BestFit;

		[SerializeField]
		[Token(Token = "0x4000041")]
		[FieldOffset(Offset = "0x24")]
		private int m_MinSize;

		[SerializeField]
		[Token(Token = "0x4000042")]
		[FieldOffset(Offset = "0x28")]
		private int m_MaxSize;

		[SerializeField]
		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x7286AC", Offset = "0x7286AC")]
		[Token(Token = "0x4000043")]
		[FieldOffset(Offset = "0x2C")]
		private TextAnchor m_Alignment;

		[SerializeField]
		[Token(Token = "0x4000044")]
		[FieldOffset(Offset = "0x30")]
		private bool m_AlignByGeometry;

		[SerializeField]
		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x728708", Offset = "0x728708")]
		[Token(Token = "0x4000045")]
		[FieldOffset(Offset = "0x31")]
		private bool m_RichText;

		[SerializeField]
		[Token(Token = "0x4000046")]
		[FieldOffset(Offset = "0x34")]
		private HorizontalWrapMode m_HorizontalOverflow;

		[SerializeField]
		[Token(Token = "0x4000047")]
		[FieldOffset(Offset = "0x38")]
		private VerticalWrapMode m_VerticalOverflow;

		[SerializeField]
		[Token(Token = "0x4000048")]
		[FieldOffset(Offset = "0x3C")]
		private float m_LineSpacing;

		[Token(Token = "0x1700001E")]
		public static FontData defaultFontData
		{
			[Token(Token = "0x6000092")]
			[Address(RVA = "0xF44A08", Offset = "0xF44A08", Length = "0x98")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700001F")]
		public Font font
		{
			[Token(Token = "0x6000093")]
			[Address(RVA = "0xF44AA8", Offset = "0xF44AA8", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000094")]
			[Address(RVA = "0xF44AB0", Offset = "0xF44AB0", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000020")]
		public int fontSize
		{
			[Token(Token = "0x6000095")]
			[Address(RVA = "0xF44AB8", Offset = "0xF44AB8", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x6000096")]
			[Address(RVA = "0xF44AC0", Offset = "0xF44AC0", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000021")]
		public FontStyle fontStyle
		{
			[Token(Token = "0x6000097")]
			[Address(RVA = "0xF44AC8", Offset = "0xF44AC8", Length = "0x8")]
			get
			{
				return FontStyle.Normal;
			}
			[Token(Token = "0x6000098")]
			[Address(RVA = "0xF44AD0", Offset = "0xF44AD0", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000022")]
		public bool bestFit
		{
			[Token(Token = "0x6000099")]
			[Address(RVA = "0xF44AD8", Offset = "0xF44AD8", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x600009A")]
			[Address(RVA = "0xF44AE0", Offset = "0xF44AE0", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x17000023")]
		public int minSize
		{
			[Token(Token = "0x600009B")]
			[Address(RVA = "0xF44AEC", Offset = "0xF44AEC", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x600009C")]
			[Address(RVA = "0xF44AF4", Offset = "0xF44AF4", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000024")]
		public int maxSize
		{
			[Token(Token = "0x600009D")]
			[Address(RVA = "0xF44AFC", Offset = "0xF44AFC", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x600009E")]
			[Address(RVA = "0xF44B04", Offset = "0xF44B04", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000025")]
		public TextAnchor alignment
		{
			[Token(Token = "0x600009F")]
			[Address(RVA = "0xF44B0C", Offset = "0xF44B0C", Length = "0x8")]
			get
			{
				return TextAnchor.UpperLeft;
			}
			[Token(Token = "0x60000A0")]
			[Address(RVA = "0xF44B14", Offset = "0xF44B14", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000026")]
		public bool alignByGeometry
		{
			[Token(Token = "0x60000A1")]
			[Address(RVA = "0xF44B1C", Offset = "0xF44B1C", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60000A2")]
			[Address(RVA = "0xF44B24", Offset = "0xF44B24", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x17000027")]
		public bool richText
		{
			[Token(Token = "0x60000A3")]
			[Address(RVA = "0xF44B30", Offset = "0xF44B30", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60000A4")]
			[Address(RVA = "0xF44B38", Offset = "0xF44B38", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x17000028")]
		public HorizontalWrapMode horizontalOverflow
		{
			[Token(Token = "0x60000A5")]
			[Address(RVA = "0xF44B44", Offset = "0xF44B44", Length = "0x8")]
			get
			{
				return HorizontalWrapMode.Wrap;
			}
			[Token(Token = "0x60000A6")]
			[Address(RVA = "0xF44B4C", Offset = "0xF44B4C", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000029")]
		public VerticalWrapMode verticalOverflow
		{
			[Token(Token = "0x60000A7")]
			[Address(RVA = "0xF44B54", Offset = "0xF44B54", Length = "0x8")]
			get
			{
				return VerticalWrapMode.Truncate;
			}
			[Token(Token = "0x60000A8")]
			[Address(RVA = "0xF44B5C", Offset = "0xF44B5C", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700002A")]
		public float lineSpacing
		{
			[Token(Token = "0x60000A9")]
			[Address(RVA = "0xF44B64", Offset = "0xF44B64", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60000AA")]
			[Address(RVA = "0xF44B6C", Offset = "0xF44B6C", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x60000AB")]
		[Address(RVA = "0xF44B74", Offset = "0xF44B74", Length = "0x4")]
		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		[Token(Token = "0x60000AC")]
		[Address(RVA = "0xF44B78", Offset = "0xF44B78", Length = "0xB8")]
		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
		}

		[Token(Token = "0x60000AD")]
		[Address(RVA = "0xF44AA0", Offset = "0xF44AA0", Length = "0x8")]
		public FontData()
		{
		}
	}
}
