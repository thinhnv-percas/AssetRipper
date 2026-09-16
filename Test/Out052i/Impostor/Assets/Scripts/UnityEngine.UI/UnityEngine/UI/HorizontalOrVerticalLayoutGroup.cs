using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[ExecuteAlways]
	[Token(Token = "0x2000047")]
	public abstract class HorizontalOrVerticalLayoutGroup : LayoutGroup
	{
		[SerializeField]
		[Token(Token = "0x400016A")]
		[FieldOffset(Offset = "0x60")]
		protected float m_Spacing;

		[SerializeField]
		[Token(Token = "0x400016B")]
		[FieldOffset(Offset = "0x64")]
		protected bool m_ChildForceExpandWidth;

		[SerializeField]
		[Token(Token = "0x400016C")]
		[FieldOffset(Offset = "0x65")]
		protected bool m_ChildForceExpandHeight;

		[SerializeField]
		[Token(Token = "0x400016D")]
		[FieldOffset(Offset = "0x66")]
		protected bool m_ChildControlWidth;

		[SerializeField]
		[Token(Token = "0x400016E")]
		[FieldOffset(Offset = "0x67")]
		protected bool m_ChildControlHeight;

		[SerializeField]
		[Token(Token = "0x400016F")]
		[FieldOffset(Offset = "0x68")]
		protected bool m_ChildScaleWidth;

		[SerializeField]
		[Token(Token = "0x4000170")]
		[FieldOffset(Offset = "0x69")]
		protected bool m_ChildScaleHeight;

		[SerializeField]
		[Token(Token = "0x4000171")]
		[FieldOffset(Offset = "0x6A")]
		protected bool m_ReverseArrangement;

		[Token(Token = "0x170000AE")]
		public float spacing
		{
			[Token(Token = "0x600029C")]
			[Address(RVA = "0x18262A4", Offset = "0x18262A4", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600029D")]
			[Address(RVA = "0x18262AC", Offset = "0x18262AC", Length = "0x5C")]
			set
			{
			}
		}

		[Token(Token = "0x170000AF")]
		public bool childForceExpandWidth
		{
			[Token(Token = "0x600029E")]
			[Address(RVA = "0x1826308", Offset = "0x1826308", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x600029F")]
			[Address(RVA = "0x1826310", Offset = "0x1826310", Length = "0x5C")]
			set
			{
			}
		}

		[Token(Token = "0x170000B0")]
		public bool childForceExpandHeight
		{
			[Token(Token = "0x60002A0")]
			[Address(RVA = "0x182636C", Offset = "0x182636C", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60002A1")]
			[Address(RVA = "0x1826374", Offset = "0x1826374", Length = "0x5C")]
			set
			{
			}
		}

		[Token(Token = "0x170000B1")]
		public bool childControlWidth
		{
			[Token(Token = "0x60002A2")]
			[Address(RVA = "0x18263D0", Offset = "0x18263D0", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60002A3")]
			[Address(RVA = "0x18263D8", Offset = "0x18263D8", Length = "0x5C")]
			set
			{
			}
		}

		[Token(Token = "0x170000B2")]
		public bool childControlHeight
		{
			[Token(Token = "0x60002A4")]
			[Address(RVA = "0x1826434", Offset = "0x1826434", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60002A5")]
			[Address(RVA = "0x182643C", Offset = "0x182643C", Length = "0x5C")]
			set
			{
			}
		}

		[Token(Token = "0x170000B3")]
		public bool childScaleWidth
		{
			[Token(Token = "0x60002A6")]
			[Address(RVA = "0x1826498", Offset = "0x1826498", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60002A7")]
			[Address(RVA = "0x18264A0", Offset = "0x18264A0", Length = "0x5C")]
			set
			{
			}
		}

		[Token(Token = "0x170000B4")]
		public bool childScaleHeight
		{
			[Token(Token = "0x60002A8")]
			[Address(RVA = "0x18264FC", Offset = "0x18264FC", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60002A9")]
			[Address(RVA = "0x1826504", Offset = "0x1826504", Length = "0x5C")]
			set
			{
			}
		}

		[Token(Token = "0x170000B5")]
		public bool reverseArrangement
		{
			[Token(Token = "0x60002AA")]
			[Address(RVA = "0x1826560", Offset = "0x1826560", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60002AB")]
			[Address(RVA = "0x1826568", Offset = "0x1826568", Length = "0x5C")]
			set
			{
			}
		}

		[Token(Token = "0x60002AC")]
		[Address(RVA = "0x1825990", Offset = "0x1825990", Length = "0x2A0")]
		protected void CalcAlongAxis(int axis, bool isVertical)
		{
		}

		[Token(Token = "0x60002AD")]
		[Address(RVA = "0x1825C48", Offset = "0x1825C48", Length = "0x650")]
		protected void SetChildrenAlongAxis(int axis, bool isVertical)
		{
		}

		[Token(Token = "0x60002AE")]
		[Address(RVA = "0x18265C4", Offset = "0x18265C4", Length = "0x114")]
		private void GetChildSizes(RectTransform child, int axis, bool controlSize, bool childForceExpand, out float min, out float preferred, out float flexible)
		{
			min = default(float);
			preferred = default(float);
			flexible = default(float);
		}

		[Token(Token = "0x60002AF")]
		[Address(RVA = "0x1825964", Offset = "0x1825964", Length = "0xC")]
		protected internal HorizontalOrVerticalLayoutGroup()
		{
		}
	}
}
