using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine.Events;

namespace UnityEngine.UI
{
	[Token(Token = "0x200003C")]
	internal class ObjectPool<T> where T : new()
	{
		[Token(Token = "0x400016B")]
		[FieldOffset(Offset = "0x0")]
		private readonly Stack<T> m_Stack;

		[Token(Token = "0x400016C")]
		[FieldOffset(Offset = "0x0")]
		private readonly UnityAction<T> m_ActionOnGet;

		[Token(Token = "0x400016D")]
		[FieldOffset(Offset = "0x0")]
		private readonly UnityAction<T> m_ActionOnRelease;

		[Token(Token = "0x17000137")]
		public int countAll
		{
			[Token(Token = "0x6000461")]
			[Address(RVA = "0x11DF008", Offset = "0x11DF008", Length = "0x8")]
			get;
			[Token(Token = "0x6000462")]
			[Address(RVA = "0x11DF010", Offset = "0x11DF010", Length = "0x8")]
			private set;
		}

		[Token(Token = "0x17000138")]
		public int countActive
		{
			[Token(Token = "0x6000463")]
			[Address(RVA = "0x11DF018", Offset = "0x11DF018", Length = "0x60")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x17000139")]
		public int countInactive
		{
			[Token(Token = "0x6000464")]
			[Address(RVA = "0x11DF078", Offset = "0x11DF078", Length = "0x28")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x6000465")]
		[Address(RVA = "0x11DF0A0", Offset = "0x11DF0A0", Length = "0x94")]
		public ObjectPool(UnityAction<T> actionOnGet, UnityAction<T> actionOnRelease)
		{
		}

		[Token(Token = "0x6000466")]
		[Address(RVA = "0x11DF134", Offset = "0x11DF134", Length = "0xE0")]
		public T Get()
		{
			return default(T);
		}

		[Token(Token = "0x6000467")]
		[Address(RVA = "0x11DF214", Offset = "0x11DF214", Length = "0x10C")]
		public void Release(T element)
		{
		}
	}
}
