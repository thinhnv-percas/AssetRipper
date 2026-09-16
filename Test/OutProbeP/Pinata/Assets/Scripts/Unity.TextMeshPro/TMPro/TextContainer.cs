using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TMPro
{
	[Attribute(Type = typeof(RequireComponent), RVA = "0x747F00", Offset = "0x747F00")]
	[Attribute(Type = typeof(AddComponentMenu), RVA = "0x747F00", Offset = "0x747F00")]
	[Token(Token = "0x2000009")]
	public class TextContainer : UIBehaviour
	{
		[Token(Token = "0x4000022")]
		[FieldOffset(Offset = "0x18")]
		private bool m_hasChanged;

		[SerializeField]
		[Token(Token = "0x4000023")]
		[FieldOffset(Offset = "0x1C")]
		private Vector2 m_pivot;

		[SerializeField]
		[Token(Token = "0x4000024")]
		[FieldOffset(Offset = "0x24")]
		private TextContainerAnchors m_anchorPosition;

		[SerializeField]
		[Token(Token = "0x4000025")]
		[FieldOffset(Offset = "0x28")]
		private Rect m_rect;

		[Token(Token = "0x4000026")]
		[FieldOffset(Offset = "0x38")]
		private bool m_isDefaultWidth;

		[Token(Token = "0x4000027")]
		[FieldOffset(Offset = "0x39")]
		private bool m_isDefaultHeight;

		[Token(Token = "0x4000028")]
		[FieldOffset(Offset = "0x3A")]
		private bool m_isAutoFitting;

		[Token(Token = "0x4000029")]
		[FieldOffset(Offset = "0x40")]
		private Vector3[] m_corners;

		[Token(Token = "0x400002A")]
		[FieldOffset(Offset = "0x48")]
		private Vector3[] m_worldCorners;

		[SerializeField]
		[Token(Token = "0x400002B")]
		[FieldOffset(Offset = "0x50")]
		private Vector4 m_margins;

		[Token(Token = "0x400002C")]
		[FieldOffset(Offset = "0x60")]
		private RectTransform m_rectTransform;

		[Token(Token = "0x400002D")]
		private static Vector2 k_defaultSize;

		[Token(Token = "0x400002E")]
		[FieldOffset(Offset = "0x68")]
		private TextMeshPro m_textMeshPro;

		[Token(Token = "0x17000002")]
		public bool hasChanged
		{
			[Token(Token = "0x600002B")]
			[Address(RVA = "0xC91044", Offset = "0xC91044", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x600002C")]
			[Address(RVA = "0xC9104C", Offset = "0xC9104C", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x17000003")]
		public Vector2 pivot
		{
			[Token(Token = "0x600002D")]
			[Address(RVA = "0xC91058", Offset = "0xC91058", Length = "0x8")]
			get
			{
				return default(Vector2);
			}
			[Token(Token = "0x600002E")]
			[Address(RVA = "0xC91060", Offset = "0xC91060", Length = "0xCC")]
			set
			{
			}
		}

		[Token(Token = "0x17000004")]
		public TextContainerAnchors anchorPosition
		{
			[Token(Token = "0x600002F")]
			[Address(RVA = "0xC91590", Offset = "0xC91590", Length = "0x8")]
			get
			{
				return TextContainerAnchors.TopLeft;
			}
			[Token(Token = "0x6000030")]
			[Address(RVA = "0xC91598", Offset = "0xC91598", Length = "0x4C")]
			set
			{
			}
		}

		[Token(Token = "0x17000005")]
		public Rect rect
		{
			[Token(Token = "0x6000031")]
			[Address(RVA = "0xC916F4", Offset = "0xC916F4", Length = "0xC")]
			get
			{
				return default(Rect);
			}
			[Token(Token = "0x6000032")]
			[Address(RVA = "0xC91700", Offset = "0xC91700", Length = "0x8C")]
			set
			{
			}
		}

		[Token(Token = "0x17000006")]
		public Vector2 size
		{
			[Token(Token = "0x6000033")]
			[Address(RVA = "0xC9178C", Offset = "0xC9178C", Length = "0x64")]
			get
			{
				return default(Vector2);
			}
			[Token(Token = "0x6000034")]
			[Address(RVA = "0xC917F0", Offset = "0xC917F0", Length = "0xEC")]
			set
			{
			}
		}

		[Token(Token = "0x17000007")]
		public float width
		{
			[Token(Token = "0x6000035")]
			[Address(RVA = "0xC91970", Offset = "0xC91970", Length = "0xC")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000036")]
			[Address(RVA = "0xC9197C", Offset = "0xC9197C", Length = "0x74")]
			set
			{
			}
		}

		[Token(Token = "0x17000008")]
		public float height
		{
			[Token(Token = "0x6000037")]
			[Address(RVA = "0xC919F0", Offset = "0xC919F0", Length = "0xC")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000038")]
			[Address(RVA = "0xC919FC", Offset = "0xC919FC", Length = "0x70")]
			set
			{
			}
		}

		[Token(Token = "0x17000009")]
		public bool isDefaultWidth
		{
			[Token(Token = "0x6000039")]
			[Address(RVA = "0xC91A6C", Offset = "0xC91A6C", Length = "0x8")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x1700000A")]
		public bool isDefaultHeight
		{
			[Token(Token = "0x600003A")]
			[Address(RVA = "0xC91A74", Offset = "0xC91A74", Length = "0x8")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x1700000B")]
		public bool isAutoFitting
		{
			[Token(Token = "0x600003B")]
			[Address(RVA = "0xC91A7C", Offset = "0xC91A7C", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x600003C")]
			[Address(RVA = "0xC91A84", Offset = "0xC91A84", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x1700000C")]
		public Vector3[] corners
		{
			[Token(Token = "0x600003D")]
			[Address(RVA = "0xC91A90", Offset = "0xC91A90", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700000D")]
		public Vector3[] worldCorners
		{
			[Token(Token = "0x600003E")]
			[Address(RVA = "0xC91A98", Offset = "0xC91A98", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700000E")]
		public Vector4 margins
		{
			[Token(Token = "0x600003F")]
			[Address(RVA = "0xC91AA0", Offset = "0xC91AA0", Length = "0xC")]
			get
			{
				return default(Vector4);
			}
			[Token(Token = "0x6000040")]
			[Address(RVA = "0xC91AAC", Offset = "0xC91AAC", Length = "0xF4")]
			set
			{
			}
		}

		[Token(Token = "0x1700000F")]
		public RectTransform rectTransform
		{
			[Token(Token = "0x6000041")]
			[Address(RVA = "0xC91BA0", Offset = "0xC91BA0", Length = "0x98")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000010")]
		public TextMeshPro textMeshPro
		{
			[Token(Token = "0x6000042")]
			[Address(RVA = "0xC91C38", Offset = "0xC91C38", Length = "0x98")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x6000043")]
		[Address(RVA = "0xC91CD0", Offset = "0xC91CD0", Length = "0xB8")]
		protected override void Awake()
		{
		}

		[Token(Token = "0x6000044")]
		[Address(RVA = "0xC91D88", Offset = "0xC91D88", Length = "0x4")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x6000045")]
		[Address(RVA = "0xC91D8C", Offset = "0xC91D8C", Length = "0x4")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x6000046")]
		[Address(RVA = "0xC91450", Offset = "0xC91450", Length = "0x140")]
		private void OnContainerChanged()
		{
		}

		[Token(Token = "0x6000047")]
		[Address(RVA = "0xC9200C", Offset = "0xC9200C", Length = "0x194")]
		protected override void OnRectTransformDimensionsChange()
		{
		}

		[Token(Token = "0x6000048")]
		[Address(RVA = "0xC918DC", Offset = "0xC918DC", Length = "0x94")]
		private void SetRect(Vector2 size)
		{
		}

		[Token(Token = "0x6000049")]
		[Address(RVA = "0xC91D90", Offset = "0xC91D90", Length = "0x27C")]
		private void UpdateCorners()
		{
		}

		[Token(Token = "0x600004A")]
		[Address(RVA = "0xC915E4", Offset = "0xC915E4", Length = "0x110")]
		private Vector2 GetPivot(TextContainerAnchors anchor)
		{
			return default(Vector2);
		}

		[Token(Token = "0x600004B")]
		[Address(RVA = "0xC9112C", Offset = "0xC9112C", Length = "0x324")]
		private TextContainerAnchors GetAnchorPosition(Vector2 pivot)
		{
			return TextContainerAnchors.TopLeft;
		}

		[Token(Token = "0x600004C")]
		[Address(RVA = "0xC921A0", Offset = "0xC921A0", Length = "0x78")]
		public TextContainer()
		{
		}
	}
}
