using System;
using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[AddComponentMenu("UI/Legacy/Text", 100)]
	[RequireComponent(typeof(CanvasRenderer))]
	[Token(Token = "0x2000074")]
	public class Text : MaskableGraphic, ILayoutElement
	{
		[SerializeField]
		[Token(Token = "0x4000248")]
		[FieldOffset(Offset = "0xD8")]
		private FontData m_FontData;

		[SerializeField]
		[TextArea(3, 10)]
		[Token(Token = "0x4000249")]
		[FieldOffset(Offset = "0xE0")]
		protected string m_Text;

		[Token(Token = "0x400024A")]
		[FieldOffset(Offset = "0xE8")]
		private TextGenerator m_TextCache;

		[Token(Token = "0x400024B")]
		[FieldOffset(Offset = "0xF0")]
		private TextGenerator m_TextCacheForLayout;

		[Token(Token = "0x400024C")]
		protected static Material s_DefaultText;

		[NonSerialized]
		[Token(Token = "0x400024D")]
		[FieldOffset(Offset = "0xF8")]
		protected bool m_DisableFontTextureRebuiltCallback;

		[Token(Token = "0x400024E")]
		[FieldOffset(Offset = "0x100")]
		private readonly UIVertex[] m_TempVerts;

		[Token(Token = "0x17000136")]
		public TextGenerator cachedTextGenerator
		{
			[Token(Token = "0x60004A4")]
			[Address(RVA = "0x18387F4", Offset = "0x18387F4", Length = "0x88")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000137")]
		public TextGenerator cachedTextGeneratorForLayout
		{
			[Token(Token = "0x60004A5")]
			[Address(RVA = "0x183887C", Offset = "0x183887C", Length = "0x64")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000138")]
		public override Texture mainTexture
		{
			[Token(Token = "0x60004A6")]
			[Address(RVA = "0x18388E0", Offset = "0x18388E0", Length = "0x1A8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000139")]
		public Font font
		{
			[Token(Token = "0x60004A8")]
			[Address(RVA = "0x1838A88", Offset = "0x1838A88", Length = "0x1C")]
			get
			{
				return null;
			}
			[Token(Token = "0x60004A9")]
			[Address(RVA = "0x1838BB0", Offset = "0x1838BB0", Length = "0x114")]
			set
			{
			}
		}

		[Token(Token = "0x1700013A")]
		public virtual string text
		{
			[Token(Token = "0x60004AA")]
			[Address(RVA = "0x1838CC4", Offset = "0x1838CC4", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60004AB")]
			[Address(RVA = "0x1838CCC", Offset = "0x1838CCC", Length = "0xC8")]
			set
			{
			}
		}

		[Token(Token = "0x1700013B")]
		public bool supportRichText
		{
			[Token(Token = "0x60004AC")]
			[Address(RVA = "0x1838D94", Offset = "0x1838D94", Length = "0x1C")]
			get
			{
				return false;
			}
			[Token(Token = "0x60004AD")]
			[Address(RVA = "0x1838DB0", Offset = "0x1838DB0", Length = "0x60")]
			set
			{
			}
		}

		[Token(Token = "0x1700013C")]
		public bool resizeTextForBestFit
		{
			[Token(Token = "0x60004AE")]
			[Address(RVA = "0x1838E10", Offset = "0x1838E10", Length = "0x1C")]
			get
			{
				return false;
			}
			[Token(Token = "0x60004AF")]
			[Address(RVA = "0x1838E2C", Offset = "0x1838E2C", Length = "0x60")]
			set
			{
			}
		}

		[Token(Token = "0x1700013D")]
		public int resizeTextMinSize
		{
			[Token(Token = "0x60004B0")]
			[Address(RVA = "0x1838E8C", Offset = "0x1838E8C", Length = "0x1C")]
			get
			{
				return 0;
			}
			[Token(Token = "0x60004B1")]
			[Address(RVA = "0x1838EA8", Offset = "0x1838EA8", Length = "0x54")]
			set
			{
			}
		}

		[Token(Token = "0x1700013E")]
		public int resizeTextMaxSize
		{
			[Token(Token = "0x60004B2")]
			[Address(RVA = "0x1838EFC", Offset = "0x1838EFC", Length = "0x1C")]
			get
			{
				return 0;
			}
			[Token(Token = "0x60004B3")]
			[Address(RVA = "0x1838F18", Offset = "0x1838F18", Length = "0x54")]
			set
			{
			}
		}

		[Token(Token = "0x1700013F")]
		public TextAnchor alignment
		{
			[Token(Token = "0x60004B4")]
			[Address(RVA = "0x1838F6C", Offset = "0x1838F6C", Length = "0x1C")]
			get
			{
				return TextAnchor.UpperLeft;
			}
			[Token(Token = "0x60004B5")]
			[Address(RVA = "0x1838F88", Offset = "0x1838F88", Length = "0x54")]
			set
			{
			}
		}

		[Token(Token = "0x17000140")]
		public bool alignByGeometry
		{
			[Token(Token = "0x60004B6")]
			[Address(RVA = "0x1838FDC", Offset = "0x1838FDC", Length = "0x1C")]
			get
			{
				return false;
			}
			[Token(Token = "0x60004B7")]
			[Address(RVA = "0x1838FF8", Offset = "0x1838FF8", Length = "0x48")]
			set
			{
			}
		}

		[Token(Token = "0x17000141")]
		public int fontSize
		{
			[Token(Token = "0x60004B8")]
			[Address(RVA = "0x1839040", Offset = "0x1839040", Length = "0x1C")]
			get
			{
				return 0;
			}
			[Token(Token = "0x60004B9")]
			[Address(RVA = "0x183905C", Offset = "0x183905C", Length = "0x54")]
			set
			{
			}
		}

		[Token(Token = "0x17000142")]
		public HorizontalWrapMode horizontalOverflow
		{
			[Token(Token = "0x60004BA")]
			[Address(RVA = "0x18390B0", Offset = "0x18390B0", Length = "0x1C")]
			get
			{
				return HorizontalWrapMode.Wrap;
			}
			[Token(Token = "0x60004BB")]
			[Address(RVA = "0x18390CC", Offset = "0x18390CC", Length = "0x54")]
			set
			{
			}
		}

		[Token(Token = "0x17000143")]
		public VerticalWrapMode verticalOverflow
		{
			[Token(Token = "0x60004BC")]
			[Address(RVA = "0x1839120", Offset = "0x1839120", Length = "0x1C")]
			get
			{
				return VerticalWrapMode.Truncate;
			}
			[Token(Token = "0x60004BD")]
			[Address(RVA = "0x183913C", Offset = "0x183913C", Length = "0x54")]
			set
			{
			}
		}

		[Token(Token = "0x17000144")]
		public float lineSpacing
		{
			[Token(Token = "0x60004BE")]
			[Address(RVA = "0x1839190", Offset = "0x1839190", Length = "0x1C")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60004BF")]
			[Address(RVA = "0x18391AC", Offset = "0x18391AC", Length = "0x54")]
			set
			{
			}
		}

		[Token(Token = "0x17000145")]
		public FontStyle fontStyle
		{
			[Token(Token = "0x60004C0")]
			[Address(RVA = "0x1839200", Offset = "0x1839200", Length = "0x1C")]
			get
			{
				return FontStyle.Normal;
			}
			[Token(Token = "0x60004C1")]
			[Address(RVA = "0x183921C", Offset = "0x183921C", Length = "0x54")]
			set
			{
			}
		}

		[Token(Token = "0x17000146")]
		public float pixelsPerUnit
		{
			[Token(Token = "0x60004C2")]
			[Address(RVA = "0x1839270", Offset = "0x1839270", Length = "0x148")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000147")]
		public virtual float minWidth
		{
			[Token(Token = "0x60004CD")]
			[Address(RVA = "0x1839F9C", Offset = "0x1839F9C", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000148")]
		public virtual float preferredWidth
		{
			[Token(Token = "0x60004CE")]
			[Address(RVA = "0x1839FA4", Offset = "0x1839FA4", Length = "0xDC")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000149")]
		public virtual float flexibleWidth
		{
			[Token(Token = "0x60004CF")]
			[Address(RVA = "0x183A080", Offset = "0x183A080", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x1700014A")]
		public virtual float minHeight
		{
			[Token(Token = "0x60004D0")]
			[Address(RVA = "0x183A088", Offset = "0x183A088", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x1700014B")]
		public virtual float preferredHeight
		{
			[Token(Token = "0x60004D1")]
			[Address(RVA = "0x183A090", Offset = "0x183A090", Length = "0xB8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x1700014C")]
		public virtual float flexibleHeight
		{
			[Token(Token = "0x60004D2")]
			[Address(RVA = "0x183A148", Offset = "0x183A148", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x1700014D")]
		public virtual int layoutPriority
		{
			[Token(Token = "0x60004D3")]
			[Address(RVA = "0x183A150", Offset = "0x183A150", Length = "0x8")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x60004A3")]
		[Address(RVA = "0x183875C", Offset = "0x183875C", Length = "0x98")]
		protected Text()
		{
		}

		[Token(Token = "0x60004A7")]
		[Address(RVA = "0x1838AA4", Offset = "0x1838AA4", Length = "0x10C")]
		public void FontTextureChanged()
		{
		}

		[Token(Token = "0x60004C3")]
		[Address(RVA = "0x18393B8", Offset = "0x18393B8", Length = "0x7C")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x60004C4")]
		[Address(RVA = "0x1839434", Offset = "0x1839434", Length = "0x64")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x60004C5")]
		[Address(RVA = "0x1839498", Offset = "0x1839498", Length = "0x88")]
		protected override void UpdateGeometry()
		{
		}

		[Token(Token = "0x60004C6")]
		[Address(RVA = "0x1839520", Offset = "0x1839520", Length = "0x70")]
		internal void AssignDefaultFont()
		{
		}

		[Token(Token = "0x60004C7")]
		[Address(RVA = "0x1839590", Offset = "0x1839590", Length = "0xBC")]
		internal void AssignDefaultFontIfNecessary()
		{
		}

		[Token(Token = "0x60004C8")]
		[Address(RVA = "0x183964C", Offset = "0x183964C", Length = "0x1F0")]
		public TextGenerationSettings GetGenerationSettings(Vector2 extents)
		{
			return default(TextGenerationSettings);
		}

		[Token(Token = "0x60004C9")]
		[Address(RVA = "0x183983C", Offset = "0x183983C", Length = "0x6C")]
		public static Vector2 GetTextAnchorPivot(TextAnchor anchor)
		{
			return default(Vector2);
		}

		[Token(Token = "0x60004CA")]
		[Address(RVA = "0x18398A8", Offset = "0x18398A8", Length = "0x5DC")]
		protected override void OnPopulateMesh(VertexHelper toFill)
		{
		}

		[Token(Token = "0x60004CB")]
		[Address(RVA = "0x1839F94", Offset = "0x1839F94", Length = "0x4")]
		public virtual void CalculateLayoutInputHorizontal()
		{
		}

		[Token(Token = "0x60004CC")]
		[Address(RVA = "0x1839F98", Offset = "0x1839F98", Length = "0x4")]
		public virtual void CalculateLayoutInputVertical()
		{
		}
	}
}
