using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TMPro
{
	[RequireComponent(typeof(RectTransform))]
	[Token(Token = "0x200000D")]
	public class TextContainer : UIBehaviour
	{
		[Token(Token = "0x4000029")]
		[FieldOffset(Offset = "0x20")]
		private bool m_hasChanged;

		[SerializeField]
		[Token(Token = "0x400002A")]
		[FieldOffset(Offset = "0x24")]
		private Vector2 m_pivot;

		[SerializeField]
		[Token(Token = "0x400002B")]
		[FieldOffset(Offset = "0x2C")]
		private TextContainerAnchors m_anchorPosition;

		[SerializeField]
		[Token(Token = "0x400002C")]
		[FieldOffset(Offset = "0x30")]
		private Rect m_rect;

		[Token(Token = "0x400002D")]
		[FieldOffset(Offset = "0x40")]
		private bool m_isDefaultWidth;

		[Token(Token = "0x400002E")]
		[FieldOffset(Offset = "0x41")]
		private bool m_isDefaultHeight;

		[Token(Token = "0x400002F")]
		[FieldOffset(Offset = "0x42")]
		private bool m_isAutoFitting;

		[Token(Token = "0x4000030")]
		[FieldOffset(Offset = "0x48")]
		private Vector3[] m_corners;

		[Token(Token = "0x4000031")]
		[FieldOffset(Offset = "0x50")]
		private Vector3[] m_worldCorners;

		[SerializeField]
		[Token(Token = "0x4000032")]
		[FieldOffset(Offset = "0x58")]
		private Vector4 m_margins;

		[Token(Token = "0x4000033")]
		[FieldOffset(Offset = "0x68")]
		private RectTransform m_rectTransform;

		[Token(Token = "0x4000034")]
		private static Vector2 k_defaultSize;

		[Token(Token = "0x4000035")]
		[FieldOffset(Offset = "0x70")]
		private TextMeshPro m_textMeshPro;

		[Token(Token = "0x17000002")]
		public bool hasChanged
		{
			[Token(Token = "0x600002E")]
			[Address(RVA = "0x15C001C", Offset = "0x15C001C", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x600002F")]
			[Address(RVA = "0x15C0024", Offset = "0x15C0024", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x17000003")]
		public Vector2 pivot
		{
			[Token(Token = "0x6000030")]
			[Address(RVA = "0x15C0030", Offset = "0x15C0030", Length = "0x8")]
			get
			{
				return default(Vector2);
			}
			[Token(Token = "0x6000031")]
			[Address(RVA = "0x15C0038", Offset = "0x15C0038", Length = "0x58")]
			set
			{
			}
		}

		[Token(Token = "0x17000004")]
		public TextContainerAnchors anchorPosition
		{
			[Token(Token = "0x6000032")]
			[Address(RVA = "0x15C0298", Offset = "0x15C0298", Length = "0x8")]
			get
			{
				return TextContainerAnchors.TopLeft;
			}
			[Token(Token = "0x6000033")]
			[Address(RVA = "0x15C02A0", Offset = "0x15C02A0", Length = "0x3C")]
			set
			{
			}
		}

		[Token(Token = "0x17000005")]
		public Rect rect
		{
			[Token(Token = "0x6000034")]
			[Address(RVA = "0x15C0354", Offset = "0x15C0354", Length = "0xC")]
			get
			{
				return default(Rect);
			}
			[Token(Token = "0x6000035")]
			[Address(RVA = "0x15C0360", Offset = "0x15C0360", Length = "0x48")]
			set
			{
			}
		}

		[Token(Token = "0x17000006")]
		public Vector2 size
		{
			[Token(Token = "0x6000036")]
			[Address(RVA = "0x15C03A8", Offset = "0x15C03A8", Length = "0x8")]
			get
			{
				return default(Vector2);
			}
			[Token(Token = "0x6000037")]
			[Address(RVA = "0x15C03B0", Offset = "0x15C03B0", Length = "0x40")]
			set
			{
			}
		}

		[Token(Token = "0x17000007")]
		public float width
		{
			[Token(Token = "0x6000038")]
			[Address(RVA = "0x15C03F8", Offset = "0x15C03F8", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000039")]
			[Address(RVA = "0x15C0400", Offset = "0x15C0400", Length = "0x14")]
			set
			{
			}
		}

		[Token(Token = "0x17000008")]
		public float height
		{
			[Token(Token = "0x600003A")]
			[Address(RVA = "0x15C0414", Offset = "0x15C0414", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600003B")]
			[Address(RVA = "0x15C041C", Offset = "0x15C041C", Length = "0x14")]
			set
			{
			}
		}

		[Token(Token = "0x17000009")]
		public bool isDefaultWidth
		{
			[Token(Token = "0x600003C")]
			[Address(RVA = "0x15C0430", Offset = "0x15C0430", Length = "0x8")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x1700000A")]
		public bool isDefaultHeight
		{
			[Token(Token = "0x600003D")]
			[Address(RVA = "0x15C0438", Offset = "0x15C0438", Length = "0x8")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x1700000B")]
		public bool isAutoFitting
		{
			[Token(Token = "0x600003E")]
			[Address(RVA = "0x15C0440", Offset = "0x15C0440", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x600003F")]
			[Address(RVA = "0x15C0448", Offset = "0x15C0448", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x1700000C")]
		public Vector3[] corners
		{
			[Token(Token = "0x6000040")]
			[Address(RVA = "0x15C0454", Offset = "0x15C0454", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700000D")]
		public Vector3[] worldCorners
		{
			[Token(Token = "0x6000041")]
			[Address(RVA = "0x15C045C", Offset = "0x15C045C", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700000E")]
		public Vector4 margins
		{
			[Token(Token = "0x6000042")]
			[Address(RVA = "0x15C0464", Offset = "0x15C0464", Length = "0xC")]
			get
			{
				return default(Vector4);
			}
			[Token(Token = "0x6000043")]
			[Address(RVA = "0x15C0470", Offset = "0x15C0470", Length = "0x5C")]
			set
			{
			}
		}

		[Token(Token = "0x1700000F")]
		public RectTransform rectTransform
		{
			[Token(Token = "0x6000044")]
			[Address(RVA = "0x15C04CC", Offset = "0x15C04CC", Length = "0x94")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000010")]
		public TextMeshPro textMeshPro
		{
			[Token(Token = "0x6000045")]
			[Address(RVA = "0x15C0560", Offset = "0x15C0560", Length = "0x94")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x6000046")]
		[Address(RVA = "0x15C05F4", Offset = "0x15C05F4", Length = "0xC8")]
		protected override void Awake()
		{
		}

		[Token(Token = "0x6000047")]
		[Address(RVA = "0x15C06BC", Offset = "0x15C06BC", Length = "0x4")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x6000048")]
		[Address(RVA = "0x15C06C0", Offset = "0x15C06C0", Length = "0x4")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x6000049")]
		[Address(RVA = "0x15C0188", Offset = "0x15C0188", Length = "0x110")]
		private void OnContainerChanged()
		{
		}

		[Token(Token = "0x600004A")]
		[Address(RVA = "0x15C0818", Offset = "0x15C0818", Length = "0x15C")]
		protected override void OnRectTransformDimensionsChange()
		{
		}

		[Token(Token = "0x600004B")]
		[Address(RVA = "0x15C03F0", Offset = "0x15C03F0", Length = "0x8")]
		private void SetRect(Vector2 size)
		{
		}

		[Token(Token = "0x600004C")]
		[Address(RVA = "0x15C06C4", Offset = "0x15C06C4", Length = "0x154")]
		private void UpdateCorners()
		{
		}

		[Token(Token = "0x600004D")]
		[Address(RVA = "0x15C02DC", Offset = "0x15C02DC", Length = "0x78")]
		private Vector2 GetPivot(TextContainerAnchors anchor)
		{
			return default(Vector2);
		}

		[Token(Token = "0x600004E")]
		[Address(RVA = "0x15C0090", Offset = "0x15C0090", Length = "0xF8")]
		private TextContainerAnchors GetAnchorPosition(Vector2 pivot)
		{
			return TextContainerAnchors.TopLeft;
		}

		[Token(Token = "0x600004F")]
		[Address(RVA = "0x15C0974", Offset = "0x15C0974", Length = "0x70")]
		public TextContainer()
		{
		}
	}
}
