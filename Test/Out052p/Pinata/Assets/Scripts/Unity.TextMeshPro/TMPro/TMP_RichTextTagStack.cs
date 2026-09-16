using Cpp2ILInjected;

namespace TMPro
{
	[Token(Token = "0x2000038")]
	public struct TMP_RichTextTagStack<T>
	{
		[Token(Token = "0x40001FC")]
		[FieldOffset(Offset = "0x0")]
		public T[] m_ItemStack;

		[Token(Token = "0x40001FD")]
		[FieldOffset(Offset = "0x0")]
		public int m_Index;

		[Token(Token = "0x40001FE")]
		[FieldOffset(Offset = "0x0")]
		private int m_Capacity;

		[Token(Token = "0x40001FF")]
		[FieldOffset(Offset = "0x0")]
		private T m_DefaultItem;

		[Token(Token = "0x4000200")]
		private const int k_DefaultCapacity = 4;

		[Token(Token = "0x60002E5")]
		[Address(RVA = "0x85BD70", Offset = "0x85BD70", Length = "0x28")]
		public TMP_RichTextTagStack(T[] tagStack)
		{
			m_ItemStack = null;
			m_Index = 0;
			m_Capacity = 0;
			m_DefaultItem = default(T);
		}

		[Token(Token = "0x60002E6")]
		[Address(RVA = "0x85BD98", Offset = "0x85BD98", Length = "0x8")]
		public TMP_RichTextTagStack(int capacity)
		{
			m_ItemStack = null;
			m_Index = 0;
			m_Capacity = 0;
			m_DefaultItem = default(T);
		}

		[Token(Token = "0x60002E7")]
		[Address(RVA = "0x85BDA0", Offset = "0x85BDA0", Length = "0x8")]
		public void Clear()
		{
		}

		[Token(Token = "0x60002E8")]
		[Address(RVA = "0x85BDA8", Offset = "0x85BDA8", Length = "0x8")]
		public void SetDefault(T item)
		{
		}

		[Token(Token = "0x60002E9")]
		[Address(RVA = "0x85BDB0", Offset = "0x85BDB0", Length = "0x8")]
		public void Add(T item)
		{
		}

		[Token(Token = "0x60002EA")]
		[Address(RVA = "0x85BDB8", Offset = "0x85BDB8", Length = "0x8")]
		public T Remove()
		{
			return default(T);
		}

		[Token(Token = "0x60002EB")]
		[Address(RVA = "0x85BDC0", Offset = "0x85BDC0", Length = "0x8")]
		public void Push(T item)
		{
		}

		[Token(Token = "0x60002EC")]
		[Address(RVA = "0x85BDC8", Offset = "0x85BDC8", Length = "0x8")]
		public T Pop()
		{
			return default(T);
		}

		[Token(Token = "0x60002ED")]
		[Address(RVA = "0x85BDD0", Offset = "0x85BDD0", Length = "0x8")]
		public T Peek()
		{
			return default(T);
		}

		[Token(Token = "0x60002EE")]
		[Address(RVA = "0x85BDD8", Offset = "0x85BDD8", Length = "0x8")]
		public T CurrentItem()
		{
			return default(T);
		}

		[Token(Token = "0x60002EF")]
		[Address(RVA = "0x85BDE0", Offset = "0x85BDE0", Length = "0x8")]
		public T PreviousItem()
		{
			return default(T);
		}
	}
}
