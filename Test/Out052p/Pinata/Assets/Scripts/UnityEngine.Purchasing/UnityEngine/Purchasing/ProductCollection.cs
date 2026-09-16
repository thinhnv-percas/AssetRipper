using System.Collections.Generic;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x200000E")]
	public class ProductCollection
	{
		[Token(Token = "0x400001B")]
		[FieldOffset(Offset = "0x10")]
		private Dictionary<string, Product> m_IdToProduct;

		[Token(Token = "0x400001C")]
		[FieldOffset(Offset = "0x18")]
		private Dictionary<string, Product> m_StoreSpecificIdToProduct;

		[Token(Token = "0x400001D")]
		[FieldOffset(Offset = "0x20")]
		private Product[] m_Products;

		[Token(Token = "0x400001E")]
		[FieldOffset(Offset = "0x28")]
		private HashSet<Product> m_ProductSet;

		[Token(Token = "0x1700000F")]
		public HashSet<Product> set
		{
			[Token(Token = "0x6000038")]
			[Address(RVA = "0x160EC5C", Offset = "0x160EC5C", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000010")]
		public Product[] all
		{
			[Token(Token = "0x6000039")]
			[Address(RVA = "0x160EC64", Offset = "0x160EC64", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x6000036")]
		[Address(RVA = "0x160EA5C", Offset = "0x160EA5C", Length = "0x88")]
		internal ProductCollection(Product[] products)
		{
		}

		[Token(Token = "0x6000037")]
		[Address(RVA = "0x160EAE4", Offset = "0x160EAE4", Length = "0x178")]
		internal void AddProducts(IEnumerable<Product> products)
		{
		}

		[Token(Token = "0x600003A")]
		[Address(RVA = "0x160EC6C", Offset = "0x160EC6C", Length = "0x78")]
		public Product WithID(string id)
		{
			return null;
		}

		[Token(Token = "0x600003B")]
		[Address(RVA = "0x160ECE4", Offset = "0x160ECE4", Length = "0x78")]
		public Product WithStoreSpecificID(string id)
		{
			return null;
		}
	}
}
