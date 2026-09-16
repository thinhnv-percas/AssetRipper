using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace TMPro
{
	[Token(Token = "0x2000002")]
	public class FastAction
	{
		[Token(Token = "0x4000001")]
		[FieldOffset(Offset = "0x10")]
		private LinkedList<Action> delegates;

		[Token(Token = "0x4000002")]
		[FieldOffset(Offset = "0x18")]
		private Dictionary<Action, LinkedListNode<Action>> lookup;

		[Token(Token = "0x6000001")]
		[Address(RVA = "0x9176D0", Offset = "0x9176D0", Length = "0xC4")]
		public void Add(Action rhs)
		{
		}

		[Token(Token = "0x6000002")]
		[Address(RVA = "0x917794", Offset = "0x917794", Length = "0xB0")]
		public void Remove(Action rhs)
		{
		}

		[Token(Token = "0x6000003")]
		[Address(RVA = "0x917844", Offset = "0x917844", Length = "0x84")]
		public void Call()
		{
		}

		[Token(Token = "0x6000004")]
		[Address(RVA = "0x9178C8", Offset = "0x9178C8", Length = "0x23C")]
		public FastAction()
		{
		}
	}
	[Token(Token = "0x2000003")]
	public class FastAction<A>
	{
		[Token(Token = "0x4000003")]
		[FieldOffset(Offset = "0x0")]
		private LinkedList<Action<A>> delegates;

		[Token(Token = "0x4000004")]
		[FieldOffset(Offset = "0x0")]
		private Dictionary<Action<A>, LinkedListNode<Action<A>>> lookup;

		[Token(Token = "0x6000005")]
		[Address(RVA = "0x11CB65C", Offset = "0x11CB65C", Length = "0xB0")]
		public void Add(Action<A> rhs)
		{
		}

		[Token(Token = "0x6000006")]
		[Address(RVA = "0x11CB70C", Offset = "0x11CB70C", Length = "0x9C")]
		public void Remove(Action<A> rhs)
		{
		}

		[Token(Token = "0x6000007")]
		[Address(RVA = "0x11CB7A8", Offset = "0x11CB7A8", Length = "0xA8")]
		public void Call(A a)
		{
		}

		[Token(Token = "0x6000008")]
		[Address(RVA = "0x11CB850", Offset = "0x11CB850", Length = "0xB0")]
		public FastAction()
		{
		}
	}
	[Token(Token = "0x2000004")]
	public class FastAction<A, B>
	{
		[Token(Token = "0x4000005")]
		[FieldOffset(Offset = "0x0")]
		private LinkedList<Action<A, B>> delegates;

		[Token(Token = "0x4000006")]
		[FieldOffset(Offset = "0x0")]
		private Dictionary<Action<A, B>, LinkedListNode<Action<A, B>>> lookup;

		[Token(Token = "0x6000009")]
		[Address(RVA = "0x11CBB98", Offset = "0x11CBB98", Length = "0xB0")]
		public void Add(Action<A, B> rhs)
		{
		}

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x11CBC48", Offset = "0x11CBC48", Length = "0x9C")]
		public void Remove(Action<A, B> rhs)
		{
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x11CBCE4", Offset = "0x11CBCE4", Length = "0xB0")]
		public void Call(A a, B b)
		{
		}

		[Token(Token = "0x600000C")]
		[Address(RVA = "0x11CBD94", Offset = "0x11CBD94", Length = "0xB0")]
		public FastAction()
		{
		}
	}
	[Token(Token = "0x2000005")]
	public class FastAction<A, B, C>
	{
		[Token(Token = "0x4000007")]
		[FieldOffset(Offset = "0x0")]
		private LinkedList<Action<A, B, C>> delegates;

		[Token(Token = "0x4000008")]
		[FieldOffset(Offset = "0x0")]
		private Dictionary<Action<A, B, C>, LinkedListNode<Action<A, B, C>>> lookup;

		[Token(Token = "0x600000D")]
		[Address(RVA = "0x11CC0E4", Offset = "0x11CC0E4", Length = "0xB0")]
		public void Add(Action<A, B, C> rhs)
		{
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0x11CC194", Offset = "0x11CC194", Length = "0x9C")]
		public void Remove(Action<A, B, C> rhs)
		{
		}

		[Token(Token = "0x600000F")]
		[Address(RVA = "0x11CC230", Offset = "0x11CC230", Length = "0xB4")]
		public void Call(A a, B b, C c)
		{
		}

		[Token(Token = "0x6000010")]
		[Address(RVA = "0x11CC2E4", Offset = "0x11CC2E4", Length = "0xB0")]
		public FastAction()
		{
		}
	}
}
