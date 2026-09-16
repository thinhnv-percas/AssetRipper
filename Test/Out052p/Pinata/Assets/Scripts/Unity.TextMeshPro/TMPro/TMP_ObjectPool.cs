using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine.Events;

namespace TMPro
{
	[Token(Token = "0x2000032")]
	internal class TMP_ObjectPool<T> where T : new()
	{
		[Token(Token = "0x40001A6")]
		[FieldOffset(Offset = "0x0")]
		private readonly Stack<T> m_Stack;

		[Token(Token = "0x40001A7")]
		[FieldOffset(Offset = "0x0")]
		private readonly UnityAction<T> m_ActionOnGet;

		[Token(Token = "0x40001A8")]
		[FieldOffset(Offset = "0x0")]
		private readonly UnityAction<T> m_ActionOnRelease;

		[Token(Token = "0x17000098")]
		public int countAll
		{
			[Token(Token = "0x60002DB")]
			[Address(RVA = "0x11CC9C4", Offset = "0x11CC9C4", Length = "0x8")]
			get;
			[Token(Token = "0x60002DC")]
			[Address(RVA = "0x11CC9CC", Offset = "0x11CC9CC", Length = "0x8")]
			private set;
		}

		[Token(Token = "0x17000099")]
		public int countActive
		{
			[Token(Token = "0x60002DD")]
			[Address(RVA = "0x11CC9D4", Offset = "0x11CC9D4", Length = "0x60")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x1700009A")]
		public int countInactive
		{
			[Token(Token = "0x60002DE")]
			[Address(RVA = "0x11CCA34", Offset = "0x11CCA34", Length = "0x28")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x60002DF")]
		[Address(RVA = "0x11CCA5C", Offset = "0x11CCA5C", Length = "0x94")]
		public TMP_ObjectPool(UnityAction<T> actionOnGet, UnityAction<T> actionOnRelease)
		{
		}

		[Token(Token = "0x60002E0")]
		[Address(RVA = "0x11CCAF0", Offset = "0x11CCAF0", Length = "0xE0")]
		public T Get()
		{
			return default(T);
		}

		[Token(Token = "0x60002E1")]
		[Address(RVA = "0x11CCBD0", Offset = "0x11CCBD0", Length = "0x1BC0")]
		public void Release(T element)
		{
		}
	}
}
