using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace TMPro
{
	[Token(Token = "0x2000004")]
	public class FastAction
	{
		[Token(Token = "0x4000006")]
		[FieldOffset(Offset = "0x10")]
		private LinkedList<Action> delegates;

		[Token(Token = "0x4000007")]
		[FieldOffset(Offset = "0x18")]
		private Dictionary<Action, LinkedListNode<Action>> lookup;

		[Token(Token = "0x6000003")]
		[Address(RVA = "0x15BEEBC", Offset = "0x15BEEBC", Length = "0xC0")]
		public void Add(Action rhs)
		{
		}

		[Token(Token = "0x6000004")]
		[Address(RVA = "0x15BEF7C", Offset = "0x15BEF7C", Length = "0xC0")]
		public void Remove(Action rhs)
		{
		}

		[Token(Token = "0x6000005")]
		[Address(RVA = "0x15BF03C", Offset = "0x15BF03C", Length = "0x98")]
		public void Call()
		{
		}

		[Token(Token = "0x6000006")]
		[Address(RVA = "0x15BF0D4", Offset = "0x15BF0D4", Length = "0xC4")]
		public FastAction()
		{
		}
	}
	[Token(Token = "0x2000005")]
	public class FastAction<A>
	{
		[Token(Token = "0x4000008")]
		[FieldOffset(Offset = "0x0")]
		private LinkedList<Action<A>> delegates;

		[Token(Token = "0x4000009")]
		[FieldOffset(Offset = "0x0")]
		private Dictionary<Action<A>, LinkedListNode<Action<A>>> lookup;

		[Token(Token = "0x6000007")]
		[Address(RVA = "0xF5B504", Offset = "0xF5B504", Length = "0x88")]
		public void Add(Action<A> rhs)
		{
		}

		[Token(Token = "0x6000008")]
		[Address(RVA = "0xF5B58C", Offset = "0xF5B58C", Length = "0x88")]
		public void Remove(Action<A> rhs)
		{
		}

		[Token(Token = "0x6000009")]
		[Address(RVA = "0xF5B614", Offset = "0xF5B614", Length = "0x68")]
		public void Call(A a)
		{
		}

		[Token(Token = "0x600000A")]
		[Address(RVA = "0xF5B67C", Offset = "0xF5B67C", Length = "0x98")]
		public FastAction()
		{
		}
	}
	[Token(Token = "0x2000006")]
	public class FastAction<A, B>
	{
		[Token(Token = "0x400000A")]
		[FieldOffset(Offset = "0x0")]
		private LinkedList<Action<A, B>> delegates;

		[Token(Token = "0x400000B")]
		[FieldOffset(Offset = "0x0")]
		private Dictionary<Action<A, B>, LinkedListNode<Action<A, B>>> lookup;

		[Token(Token = "0x600000B")]
		[Address(RVA = "0xF5BC8C", Offset = "0xF5BC8C", Length = "0x88")]
		public void Add(Action<A, B> rhs)
		{
		}

		[Token(Token = "0x600000C")]
		[Address(RVA = "0xF5BD14", Offset = "0xF5BD14", Length = "0x88")]
		public void Remove(Action<A, B> rhs)
		{
		}

		[Token(Token = "0x600000D")]
		[Address(RVA = "0xF5BD9C", Offset = "0xF5BD9C", Length = "0x78")]
		public void Call(A a, B b)
		{
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0xF5BE14", Offset = "0xF5BE14", Length = "0x98")]
		public FastAction()
		{
		}
	}
	[Token(Token = "0x2000007")]
	public class FastAction<A, B, C>
	{
		[Token(Token = "0x400000C")]
		[FieldOffset(Offset = "0x0")]
		private LinkedList<Action<A, B, C>> delegates;

		[Token(Token = "0x400000D")]
		[FieldOffset(Offset = "0x0")]
		private Dictionary<Action<A, B, C>, LinkedListNode<Action<A, B, C>>> lookup;

		[Token(Token = "0x600000F")]
		[Address(RVA = "0xF5C490", Offset = "0xF5C490", Length = "0x88")]
		public void Add(Action<A, B, C> rhs)
		{
		}

		[Token(Token = "0x6000010")]
		[Address(RVA = "0xF5C518", Offset = "0xF5C518", Length = "0x88")]
		public void Remove(Action<A, B, C> rhs)
		{
		}

		[Token(Token = "0x6000011")]
		[Address(RVA = "0xF5C5A0", Offset = "0xF5C5A0", Length = "0x80")]
		public void Call(A a, B b, C c)
		{
		}

		[Token(Token = "0x6000012")]
		[Address(RVA = "0xF5C620", Offset = "0xF5C620", Length = "0x98")]
		public FastAction()
		{
		}
	}
}
