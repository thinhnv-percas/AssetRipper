using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Cpp2ILInjected;

namespace UnityEngine.UI.Collections
{
	[AttributeAttribute(Type = typeof(DefaultMemberAttribute), RVA = "0x727CA8", Offset = "0x727CA8")]
	[Token(Token = "0x2000046")]
	internal class IndexedSet<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		[Token(Token = "0x4000187")]
		[FieldOffset(Offset = "0x0")]
		private readonly List<T> m_List;

		[Token(Token = "0x4000188")]
		[FieldOffset(Offset = "0x0")]
		private Dictionary<T, int> m_Dictionary;

		[Token(Token = "0x17000141")]
		public int Count
		{
			[Token(Token = "0x60004A1")]
			[Address(RVA = "0x11DBF80", Offset = "0x11DBF80", Length = "0x28")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x17000142")]
		public bool IsReadOnly
		{
			[Token(Token = "0x60004A2")]
			[Address(RVA = "0x11DBFA8", Offset = "0x11DBFA8", Length = "0x8")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x17000143")]
		public T Item
		{
			[Token(Token = "0x60004A6")]
			[Address(RVA = "0x11DC1E0", Offset = "0x11DC1E0", Length = "0x28")]
			get
			{
				return default(T);
			}
			[Token(Token = "0x60004A7")]
			[Address(RVA = "0x11DC208", Offset = "0x11DC208", Length = "0xD0")]
			set
			{
			}
		}

		[Token(Token = "0x6000499")]
		[Address(RVA = "0x11DBC6C", Offset = "0x11DBC6C", Length = "0x98")]
		public void Add(T item)
		{
		}

		[Token(Token = "0x600049A")]
		[Address(RVA = "0x11DBD04", Offset = "0x11DBD04", Length = "0xCC")]
		public bool AddUnique(T item)
		{
			return false;
		}

		[Token(Token = "0x600049B")]
		[Address(RVA = "0x11DBDD0", Offset = "0x11DBDD0", Length = "0x80")]
		public bool Remove(T item)
		{
			return false;
		}

		[Token(Token = "0x600049C")]
		[Address(RVA = "0x11DBE50", Offset = "0x11DBE50", Length = "0x64")]
		public IEnumerator<T> GetEnumerator()
		{
			return null;
		}

		[Token(Token = "0x600049D")]
		[Address(RVA = "0x11DBEB4", Offset = "0x11DBEB4", Length = "0x24")]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		[Token(Token = "0x600049E")]
		[Address(RVA = "0x11DBED8", Offset = "0x11DBED8", Length = "0x58")]
		public void Clear()
		{
		}

		[Token(Token = "0x600049F")]
		[Address(RVA = "0x11DBF30", Offset = "0x11DBF30", Length = "0x28")]
		public bool Contains(T item)
		{
			return false;
		}

		[Token(Token = "0x60004A0")]
		[Address(RVA = "0x11DBF58", Offset = "0x11DBF58", Length = "0x28")]
		public void CopyTo(T[] array, int arrayIndex)
		{
		}

		[Token(Token = "0x60004A3")]
		[Address(RVA = "0x11DBFB0", Offset = "0x11DBFB0", Length = "0x50")]
		public int IndexOf(T item)
		{
			return 0;
		}

		[Token(Token = "0x60004A4")]
		[Address(RVA = "0x11DC000", Offset = "0x11DC000", Length = "0x70")]
		public void Insert(int index, T item)
		{
		}

		[Token(Token = "0x60004A5")]
		[Address(RVA = "0x11DC070", Offset = "0x11DC070", Length = "0x170")]
		public void RemoveAt(int index)
		{
		}

		[Token(Token = "0x60004A8")]
		[Address(RVA = "0x11DC2D8", Offset = "0x11DC2D8", Length = "0xE4")]
		public void RemoveAll(Predicate<T> match)
		{
		}

		[Token(Token = "0x60004A9")]
		[Address(RVA = "0x11DC3BC", Offset = "0x11DC3BC", Length = "0xCC")]
		public void Sort(Comparison<T> sortLayoutFunction)
		{
		}

		[Token(Token = "0x60004AA")]
		[Address(RVA = "0x11DC488", Offset = "0x11DC488", Length = "0xB0")]
		public IndexedSet()
		{
		}
	}
}
