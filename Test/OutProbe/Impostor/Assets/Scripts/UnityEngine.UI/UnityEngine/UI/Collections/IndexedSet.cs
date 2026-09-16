using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace UnityEngine.UI.Collections
{
	[Token(Token = "0x2000089")]
	internal class IndexedSet<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
	{
		[Token(Token = "0x4000274")]
		[FieldOffset(Offset = "0x0")]
		private readonly List<T> m_List;

		[Token(Token = "0x4000275")]
		[FieldOffset(Offset = "0x0")]
		private Dictionary<T, int> m_Dictionary;

		[Token(Token = "0x4000276")]
		[FieldOffset(Offset = "0x0")]
		private int m_EnabledObjectCount;

		[Token(Token = "0x17000158")]
		public int Count
		{
			[Token(Token = "0x600054F")]
			[Address(RVA = "0xF840F0", Offset = "0xF840F0", Length = "0x8")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x17000159")]
		public int Capacity
		{
			[Token(Token = "0x6000550")]
			[Address(RVA = "0xF840F8", Offset = "0xF840F8", Length = "0x1C")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x1700015A")]
		public bool IsReadOnly
		{
			[Token(Token = "0x6000551")]
			[Address(RVA = "0xF84114", Offset = "0xF84114", Length = "0x8")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x1700015B")]
		public T this[int index]
		{
			[Token(Token = "0x6000556")]
			[Address(RVA = "0xF843C0", Offset = "0xF843C0", Length = "0x64")]
			get
			{
				return default(T);
			}
			[Token(Token = "0x6000557")]
			[Address(RVA = "0xF84424", Offset = "0xF84424", Length = "0xA4")]
			set
			{
			}
		}

		[Token(Token = "0x6000544")]
		[Address(RVA = "0xF83CE0", Offset = "0xF83CE0", Length = "0x14")]
		public void Add(T item)
		{
		}

		[Token(Token = "0x6000545")]
		[Address(RVA = "0xF83CF4", Offset = "0xF83CF4", Length = "0xE4")]
		public void Add(T item, bool isActive)
		{
		}

		[Token(Token = "0x6000546")]
		[Address(RVA = "0xF83DD8", Offset = "0xF83DD8", Length = "0xA0")]
		public bool AddUnique(T item, bool isActive = true)
		{
			return false;
		}

		[Token(Token = "0x6000547")]
		[Address(RVA = "0xF83E78", Offset = "0xF83E78", Length = "0x84")]
		public bool EnableItem(T item)
		{
			return false;
		}

		[Token(Token = "0x6000548")]
		[Address(RVA = "0xF83EFC", Offset = "0xF83EFC", Length = "0x8C")]
		public bool DisableItem(T item)
		{
			return false;
		}

		[Token(Token = "0x6000549")]
		[Address(RVA = "0xF83F88", Offset = "0xF83F88", Length = "0x70")]
		public bool Remove(T item)
		{
			return false;
		}

		[Token(Token = "0x600054A")]
		[Address(RVA = "0xF83FF8", Offset = "0xF83FF8", Length = "0x34")]
		public IEnumerator<T> GetEnumerator()
		{
			return null;
		}

		[Token(Token = "0x600054B")]
		[Address(RVA = "0xF8402C", Offset = "0xF8402C", Length = "0x14")]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		[Token(Token = "0x600054C")]
		[Address(RVA = "0xF84040", Offset = "0xF84040", Length = "0x68")]
		public void Clear()
		{
		}

		[Token(Token = "0x600054D")]
		[Address(RVA = "0xF840A8", Offset = "0xF840A8", Length = "0x24")]
		public bool Contains(T item)
		{
			return false;
		}

		[Token(Token = "0x600054E")]
		[Address(RVA = "0xF840CC", Offset = "0xF840CC", Length = "0x24")]
		public void CopyTo(T[] array, int arrayIndex)
		{
		}

		[Token(Token = "0x6000552")]
		[Address(RVA = "0xF8411C", Offset = "0xF8411C", Length = "0x40")]
		public int IndexOf(T item)
		{
			return 0;
		}

		[Token(Token = "0x6000553")]
		[Address(RVA = "0xF8415C", Offset = "0xF8415C", Length = "0x48")]
		public void Insert(int index, T item)
		{
		}

		[Token(Token = "0x6000554")]
		[Address(RVA = "0xF841A4", Offset = "0xF841A4", Length = "0x108")]
		public void RemoveAt(int index)
		{
		}

		[Token(Token = "0x6000555")]
		[Address(RVA = "0xF842AC", Offset = "0xF842AC", Length = "0x114")]
		private void Swap(int index1, int index2)
		{
		}

		[Token(Token = "0x6000558")]
		[Address(RVA = "0xF844C8", Offset = "0xF844C8", Length = "0xA8")]
		public void RemoveAll(Predicate<T> match)
		{
		}

		[Token(Token = "0x6000559")]
		[Address(RVA = "0xF84570", Offset = "0xF84570", Length = "0x94")]
		public void Sort(Comparison<T> sortLayoutFunction)
		{
		}

		[Token(Token = "0x600055A")]
		[Address(RVA = "0xF84604", Offset = "0xF84604", Length = "0x98")]
		public IndexedSet()
		{
		}
	}
}
