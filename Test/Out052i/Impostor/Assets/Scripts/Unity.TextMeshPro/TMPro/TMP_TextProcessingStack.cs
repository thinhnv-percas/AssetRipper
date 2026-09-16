using System.Diagnostics;
using Cpp2ILInjected;

namespace TMPro
{
	[DebuggerDisplay("Item count = {m_Count}")]
	[Token(Token = "0x20000A0")]
	public struct TMP_TextProcessingStack<T>
	{
		[Token(Token = "0x40005E8")]
		[FieldOffset(Offset = "0x0")]
		public T[] itemStack;

		[Token(Token = "0x40005E9")]
		[FieldOffset(Offset = "0x0")]
		public int index;

		[Token(Token = "0x40005EA")]
		[FieldOffset(Offset = "0x0")]
		private T m_DefaultItem;

		[Token(Token = "0x40005EB")]
		[FieldOffset(Offset = "0x0")]
		private int m_Capacity;

		[Token(Token = "0x40005EC")]
		[FieldOffset(Offset = "0x0")]
		private int m_RolloverSize;

		[Token(Token = "0x40005ED")]
		[FieldOffset(Offset = "0x0")]
		private int m_Count;

		[Token(Token = "0x40005EE")]
		private const int k_DefaultCapacity = 4;

		[Token(Token = "0x1700016E")]
		public int Count
		{
			[Token(Token = "0x600060B")]
			[Address(RVA = "0x116CC00", Offset = "0x116CC00", Length = "0x8")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x1700016F")]
		public T current
		{
			[Token(Token = "0x600060C")]
			[Address(RVA = "0x116CC08", Offset = "0x116CC08", Length = "0x4C")]
			get
			{
				return default(T);
			}
		}

		[Token(Token = "0x17000170")]
		public int rolloverSize
		{
			[Token(Token = "0x600060D")]
			[Address(RVA = "0x116CC54", Offset = "0x116CC54", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x600060E")]
			[Address(RVA = "0x116CC5C", Offset = "0x116CC5C", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x6000608")]
		[Address(RVA = "0x116CB10", Offset = "0x116CB10", Length = "0x2C")]
		public TMP_TextProcessingStack(T[] stack)
		{
			itemStack = null;
			index = 0;
			m_DefaultItem = default(T);
			m_Capacity = 0;
			m_RolloverSize = 0;
			m_Count = 0;
		}

		[Token(Token = "0x6000609")]
		[Address(RVA = "0x116CB3C", Offset = "0x116CB3C", Length = "0x64")]
		public TMP_TextProcessingStack(int capacity)
		{
			itemStack = null;
			index = 0;
			m_DefaultItem = default(T);
			m_Capacity = 0;
			m_RolloverSize = 0;
			m_Count = 0;
		}

		[Token(Token = "0x600060A")]
		[Address(RVA = "0x116CBA0", Offset = "0x116CBA0", Length = "0x60")]
		public TMP_TextProcessingStack(int capacity, int rolloverSize)
		{
			itemStack = null;
			index = 0;
			m_DefaultItem = default(T);
			m_Capacity = 0;
			m_RolloverSize = 0;
			m_Count = 0;
		}

		[Token(Token = "0x600060F")]
		[Address(RVA = "0x116CC64", Offset = "0x116CC64", Length = "0x8C")]
		internal static void SetDefault(TMP_TextProcessingStack<T>[] stack, T item)
		{
		}

		[Token(Token = "0x6000610")]
		[Address(RVA = "0x116CCF0", Offset = "0x116CCF0", Length = "0xC")]
		public void Clear()
		{
		}

		[Token(Token = "0x6000611")]
		[Address(RVA = "0x116CCFC", Offset = "0x116CCFC", Length = "0x80")]
		public void SetDefault(T item)
		{
		}

		[Token(Token = "0x6000612")]
		[Address(RVA = "0x116CD7C", Offset = "0x116CD7C", Length = "0x48")]
		public void Add(T item)
		{
		}

		[Token(Token = "0x6000613")]
		[Address(RVA = "0x116CDC4", Offset = "0x116CDC4", Length = "0x64")]
		public T Remove()
		{
			return default(T);
		}

		[Token(Token = "0x6000614")]
		[Address(RVA = "0x116CE28", Offset = "0x116CE28", Length = "0xC8")]
		public void Push(T item)
		{
		}

		[Token(Token = "0x6000615")]
		[Address(RVA = "0x116CEF0", Offset = "0x116CEF0", Length = "0x8C")]
		public T Pop()
		{
			return default(T);
		}

		[Token(Token = "0x6000616")]
		[Address(RVA = "0x116CF7C", Offset = "0x116CF7C", Length = "0x48")]
		public T Peek()
		{
			return default(T);
		}

		[Token(Token = "0x6000617")]
		[Address(RVA = "0x116CFC4", Offset = "0x116CFC4", Length = "0x4C")]
		public T CurrentItem()
		{
			return default(T);
		}

		[Token(Token = "0x6000618")]
		[Address(RVA = "0x116D010", Offset = "0x116D010", Length = "0x4C")]
		public T PreviousItem()
		{
			return default(T);
		}
	}
}
