using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[ExecuteAlways]
	[Token(Token = "0x200001E")]
	public abstract class HorizontalOrVerticalLayoutGroup : LayoutGroup
	{
		[SerializeField]
		[Token(Token = "0x40000CD")]
		[FieldOffset(Offset = "0x58")]
		protected float m_Spacing;

		[SerializeField]
		[Token(Token = "0x40000CE")]
		[FieldOffset(Offset = "0x5C")]
		protected bool m_ChildForceExpandWidth;

		[SerializeField]
		[Token(Token = "0x40000CF")]
		[FieldOffset(Offset = "0x5D")]
		protected bool m_ChildForceExpandHeight;

		[SerializeField]
		[Token(Token = "0x40000D0")]
		[FieldOffset(Offset = "0x5E")]
		protected bool m_ChildControlWidth;

		[SerializeField]
		[Token(Token = "0x40000D1")]
		[FieldOffset(Offset = "0x5F")]
		protected bool m_ChildControlHeight;

		[SerializeField]
		[Token(Token = "0x40000D2")]
		[FieldOffset(Offset = "0x60")]
		protected bool m_ChildScaleWidth;

		[SerializeField]
		[Token(Token = "0x40000D3")]
		[FieldOffset(Offset = "0x61")]
		protected bool m_ChildScaleHeight;

		[Token(Token = "0x1700009D")]
		public float spacing
		{
			[Token(Token = "0x600023B")]
			[Address(RVA = "0xF4B9BC", Offset = "0xF4B9BC", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600023C")]
			[Address(RVA = "0xF4B9C4", Offset = "0xF4B9C4", Length = "0x64")]
			set
			{
			}
		}

		[Token(Token = "0x1700009E")]
		public bool childForceExpandWidth
		{
			[Token(Token = "0x600023D")]
			[Address(RVA = "0xF4BA28", Offset = "0xF4BA28", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x600023E")]
			[Address(RVA = "0xF4BA30", Offset = "0xF4BA30", Length = "0x64")]
			set
			{
			}
		}

		[Token(Token = "0x1700009F")]
		public bool childForceExpandHeight
		{
			[Token(Token = "0x600023F")]
			[Address(RVA = "0xF4BA94", Offset = "0xF4BA94", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000240")]
			[Address(RVA = "0xF4BA9C", Offset = "0xF4BA9C", Length = "0x64")]
			set
			{
			}
		}

		[Token(Token = "0x170000A0")]
		public bool childControlWidth
		{
			[Token(Token = "0x6000241")]
			[Address(RVA = "0xF4BB00", Offset = "0xF4BB00", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000242")]
			[Address(RVA = "0xF4BB08", Offset = "0xF4BB08", Length = "0x64")]
			set
			{
			}
		}

		[Token(Token = "0x170000A1")]
		public bool childControlHeight
		{
			[Token(Token = "0x6000243")]
			[Address(RVA = "0xF4BB6C", Offset = "0xF4BB6C", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000244")]
			[Address(RVA = "0xF4BB74", Offset = "0xF4BB74", Length = "0x64")]
			set
			{
			}
		}

		[Token(Token = "0x170000A2")]
		public bool childScaleWidth
		{
			[Token(Token = "0x6000245")]
			[Address(RVA = "0xF4BBD8", Offset = "0xF4BBD8", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000246")]
			[Address(RVA = "0xF4BBE0", Offset = "0xF4BBE0", Length = "0x64")]
			set
			{
			}
		}

		[Token(Token = "0x170000A3")]
		public bool childScaleHeight
		{
			[Token(Token = "0x6000247")]
			[Address(RVA = "0xF4BC44", Offset = "0xF4BC44", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000248")]
			[Address(RVA = "0xF4BC4C", Offset = "0xF4BC4C", Length = "0x64")]
			set
			{
			}
		}

		[Token(Token = "0x6000249")]
		[Address(RVA = "0xF4B0F4", Offset = "0xF4B0F4", Length = "0x29C")]
		protected void CalcAlongAxis(int axis, bool isVertical)
		{
		}

		[Token(Token = "0x600024A")]
		[Address(RVA = "0xF4B3A8", Offset = "0xF4B3A8", Length = "0x608")]
		protected void SetChildrenAlongAxis(int axis, bool isVertical)
		{
		}

		[Token(Token = "0x600024B")]
		[Address(RVA = "0xF4BCB0", Offset = "0xF4BCB0", Length = "0x134")]
		private void GetChildSizes(RectTransform child, int axis, bool controlSize, bool childForceExpand, out float min, out float preferred, out float flexible)
		{
			min = default(float);
			preferred = default(float);
			flexible = default(float);
		}

		[Token(Token = "0x600024C")]
		[Address(RVA = "0xF4B0BC", Offset = "0xF4B0BC", Length = "0xC")]
		protected internal HorizontalOrVerticalLayoutGroup()
		{
		}
	}
}
