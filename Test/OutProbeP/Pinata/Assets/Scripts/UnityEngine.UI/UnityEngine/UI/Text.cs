using System;
using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x727A3C", Offset = "0x727A3C")]
	[Token(Token = "0x2000038")]
	public class Text : MaskableGraphic, ILayoutElement
	{
		[SerializeField]
		[Token(Token = "0x400015C")]
		[FieldOffset(Offset = "0xC0")]
		private FontData m_FontData;

		[AttributeAttribute(Type = typeof(TextAreaAttribute), RVA = "0x729AA4", Offset = "0x729AA4")]
		[SerializeField]
		[Token(Token = "0x400015D")]
		[FieldOffset(Offset = "0xC8")]
		protected string m_Text;

		[Token(Token = "0x400015E")]
		[FieldOffset(Offset = "0xD0")]
		private TextGenerator m_TextCache;

		[Token(Token = "0x400015F")]
		[FieldOffset(Offset = "0xD8")]
		private TextGenerator m_TextCacheForLayout;

		[Token(Token = "0x4000160")]
		protected static Material s_DefaultText;

		[NonSerialized]
		[Token(Token = "0x4000161")]
		[FieldOffset(Offset = "0xE0")]
		protected bool m_DisableFontTextureRebuiltCallback;

		[Token(Token = "0x4000162")]
		[FieldOffset(Offset = "0xE8")]
		private readonly UIVertex[] m_TempVerts;

		[Token(Token = "0x1700011C")]
		public TextGenerator cachedTextGenerator
		{
			[Token(Token = "0x600040C")]
			[Address(RVA = "0xED9C90", Offset = "0xED9C90", Length = "0x9C")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700011D")]
		public TextGenerator cachedTextGeneratorForLayout
		{
			[Token(Token = "0x600040D")]
			[Address(RVA = "0xED9D2C", Offset = "0xED9D2C", Length = "0x6C")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700011E")]
		public override Texture mainTexture
		{
			[Token(Token = "0x600040E")]
			[Address(RVA = "0xED9D98", Offset = "0xED9D98", Length = "0x1F0")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700011F")]
		public Font font
		{
			[Token(Token = "0x6000410")]
			[Address(RVA = "0xED9F88", Offset = "0xED9F88", Length = "0x20")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000411")]
			[Address(RVA = "0xEDA0C8", Offset = "0xEDA0C8", Length = "0xF8")]
			set
			{
			}
		}

		[Token(Token = "0x17000120")]
		public virtual string text
		{
			[Token(Token = "0x6000412")]
			[Address(RVA = "0xEDA1C0", Offset = "0xEDA1C0", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000413")]
			[Address(RVA = "0xEDA1C8", Offset = "0xEDA1C8", Length = "0xDC")]
			set
			{
			}
		}

		[Token(Token = "0x17000121")]
		public bool supportRichText
		{
			[Token(Token = "0x6000414")]
			[Address(RVA = "0xEDA2A4", Offset = "0xEDA2A4", Length = "0x20")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000415")]
			[Address(RVA = "0xEDA2C4", Offset = "0xEDA2C4", Length = "0x78")]
			set
			{
			}
		}

		[Token(Token = "0x17000122")]
		public bool resizeTextForBestFit
		{
			[Token(Token = "0x6000416")]
			[Address(RVA = "0xEDA33C", Offset = "0xEDA33C", Length = "0x20")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000417")]
			[Address(RVA = "0xEDA35C", Offset = "0xEDA35C", Length = "0x78")]
			set
			{
			}
		}

		[Token(Token = "0x17000123")]
		public int resizeTextMinSize
		{
			[Token(Token = "0x6000418")]
			[Address(RVA = "0xEDA3D4", Offset = "0xEDA3D4", Length = "0x20")]
			get
			{
				return 0;
			}
			[Token(Token = "0x6000419")]
			[Address(RVA = "0xEDA3F4", Offset = "0xEDA3F4", Length = "0x6C")]
			set
			{
			}
		}

		[Token(Token = "0x17000124")]
		public int resizeTextMaxSize
		{
			[Token(Token = "0x600041A")]
			[Address(RVA = "0xEDA460", Offset = "0xEDA460", Length = "0x20")]
			get
			{
				return 0;
			}
			[Token(Token = "0x600041B")]
			[Address(RVA = "0xEDA480", Offset = "0xEDA480", Length = "0x6C")]
			set
			{
			}
		}

		[Token(Token = "0x17000125")]
		public TextAnchor alignment
		{
			[Token(Token = "0x600041C")]
			[Address(RVA = "0xEDA4EC", Offset = "0xEDA4EC", Length = "0x20")]
			get
			{
				return TextAnchor.UpperLeft;
			}
			[Token(Token = "0x600041D")]
			[Address(RVA = "0xEDA50C", Offset = "0xEDA50C", Length = "0x6C")]
			set
			{
			}
		}

		[Token(Token = "0x17000126")]
		public bool alignByGeometry
		{
			[Token(Token = "0x600041E")]
			[Address(RVA = "0xEDA578", Offset = "0xEDA578", Length = "0x20")]
			get
			{
				return false;
			}
			[Token(Token = "0x600041F")]
			[Address(RVA = "0xEDA598", Offset = "0xEDA598", Length = "0x48")]
			set
			{
			}
		}

		[Token(Token = "0x17000127")]
		public int fontSize
		{
			[Token(Token = "0x6000420")]
			[Address(RVA = "0xEDA5E0", Offset = "0xEDA5E0", Length = "0x20")]
			get
			{
				return 0;
			}
			[Token(Token = "0x6000421")]
			[Address(RVA = "0xEDA600", Offset = "0xEDA600", Length = "0x6C")]
			set
			{
			}
		}

		[Token(Token = "0x17000128")]
		public HorizontalWrapMode horizontalOverflow
		{
			[Token(Token = "0x6000422")]
			[Address(RVA = "0xEDA66C", Offset = "0xEDA66C", Length = "0x20")]
			get
			{
				return HorizontalWrapMode.Wrap;
			}
			[Token(Token = "0x6000423")]
			[Address(RVA = "0xEDA68C", Offset = "0xEDA68C", Length = "0x6C")]
			set
			{
			}
		}

		[Token(Token = "0x17000129")]
		public VerticalWrapMode verticalOverflow
		{
			[Token(Token = "0x6000424")]
			[Address(RVA = "0xEDA6F8", Offset = "0xEDA6F8", Length = "0x20")]
			get
			{
				return VerticalWrapMode.Truncate;
			}
			[Token(Token = "0x6000425")]
			[Address(RVA = "0xEDA718", Offset = "0xEDA718", Length = "0x6C")]
			set
			{
			}
		}

		[Token(Token = "0x1700012A")]
		public float lineSpacing
		{
			[Token(Token = "0x6000426")]
			[Address(RVA = "0xEDA784", Offset = "0xEDA784", Length = "0x20")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000427")]
			[Address(RVA = "0xEDA7A4", Offset = "0xEDA7A4", Length = "0x6C")]
			set
			{
			}
		}

		[Token(Token = "0x1700012B")]
		public FontStyle fontStyle
		{
			[Token(Token = "0x6000428")]
			[Address(RVA = "0xEDA810", Offset = "0xEDA810", Length = "0x20")]
			get
			{
				return FontStyle.Normal;
			}
			[Token(Token = "0x6000429")]
			[Address(RVA = "0xEDA830", Offset = "0xEDA830", Length = "0x6C")]
			set
			{
			}
		}

		[Token(Token = "0x1700012C")]
		public float pixelsPerUnit
		{
			[Token(Token = "0x600042A")]
			[Address(RVA = "0xEDA89C", Offset = "0xEDA89C", Length = "0x170")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x1700012D")]
		public virtual float minWidth
		{
			[Token(Token = "0x6000434")]
			[Address(RVA = "0xEDB6F8", Offset = "0xEDB6F8", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x1700012E")]
		public virtual float preferredWidth
		{
			[Token(Token = "0x6000435")]
			[Address(RVA = "0xEDB700", Offset = "0xEDB700", Length = "0xFC")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x1700012F")]
		public virtual float flexibleWidth
		{
			[Token(Token = "0x6000436")]
			[Address(RVA = "0xEDB7FC", Offset = "0xEDB7FC", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000130")]
		public virtual float minHeight
		{
			[Token(Token = "0x6000437")]
			[Address(RVA = "0xEDB804", Offset = "0xEDB804", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000131")]
		public virtual float preferredHeight
		{
			[Token(Token = "0x6000438")]
			[Address(RVA = "0xEDB80C", Offset = "0xEDB80C", Length = "0xE8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000132")]
		public virtual float flexibleHeight
		{
			[Token(Token = "0x6000439")]
			[Address(RVA = "0xEDB8F4", Offset = "0xEDB8F4", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000133")]
		public virtual int layoutPriority
		{
			[Token(Token = "0x600043A")]
			[Address(RVA = "0xEDB8FC", Offset = "0xEDB8FC", Length = "0x8")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x600040B")]
		[Address(RVA = "0xED9C08", Offset = "0xED9C08", Length = "0x88")]
		protected Text()
		{
		}

		[Token(Token = "0x600040F")]
		[Address(RVA = "0xED9FA8", Offset = "0xED9FA8", Length = "0x120")]
		public void FontTextureChanged()
		{
		}

		[Token(Token = "0x600042B")]
		[Address(RVA = "0xEDAA0C", Offset = "0xEDAA0C", Length = "0x88")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x600042C")]
		[Address(RVA = "0xEDAA94", Offset = "0xEDAA94", Length = "0x70")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x600042D")]
		[Address(RVA = "0xEDAB04", Offset = "0xEDAB04", Length = "0x9C")]
		protected override void UpdateGeometry()
		{
		}

		[Token(Token = "0x600042E")]
		[Address(RVA = "0xEDABA0", Offset = "0xEDABA0", Length = "0x64")]
		internal void AssignDefaultFont()
		{
		}

		[Token(Token = "0x600042F")]
		[Address(RVA = "0xEDAC04", Offset = "0xEDAC04", Length = "0x1F8")]
		public TextGenerationSettings GetGenerationSettings(Vector2 extents)
		{
			return default(TextGenerationSettings);
		}

		[Token(Token = "0x6000430")]
		[Address(RVA = "0xEDADFC", Offset = "0xEDADFC", Length = "0x134")]
		public static Vector2 GetTextAnchorPivot(TextAnchor anchor)
		{
			return default(Vector2);
		}

		[Token(Token = "0x6000431")]
		[Address(RVA = "0xEDAF30", Offset = "0xEDAF30", Length = "0x6A8")]
		protected override void OnPopulateMesh(VertexHelper toFill)
		{
		}

		[Token(Token = "0x6000432")]
		[Address(RVA = "0xEDB6F0", Offset = "0xEDB6F0", Length = "0x4")]
		public virtual void CalculateLayoutInputHorizontal()
		{
		}

		[Token(Token = "0x6000433")]
		[Address(RVA = "0xEDB6F4", Offset = "0xEDB6F4", Length = "0x4")]
		public virtual void CalculateLayoutInputVertical()
		{
		}
	}
}
