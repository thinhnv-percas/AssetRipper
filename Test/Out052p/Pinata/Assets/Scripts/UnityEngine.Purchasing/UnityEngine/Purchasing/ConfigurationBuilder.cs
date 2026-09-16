using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine.Purchasing.Extension;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000004")]
	public class ConfigurationBuilder
	{
		[Token(Token = "0x4000003")]
		[FieldOffset(Offset = "0x10")]
		private PurchasingFactory m_Factory;

		[Token(Token = "0x4000004")]
		[FieldOffset(Offset = "0x18")]
		private HashSet<ProductDefinition> m_Products;

		[Attribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x726368", Offset = "0x726368")]
		[CompilerGenerated]
		[Token(Token = "0x4000005")]
		[FieldOffset(Offset = "0x20")]
		private bool _003CuseCloudCatalog_003Ek__BackingField;

		[Token(Token = "0x17000001")]
		[field: Attribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x7263A4", Offset = "0x7263A4")]
		[field: Token(Token = "0x4000006")]
		[field: FieldOffset(Offset = "0x21")]
		public bool useCatalogProvider
		{
			[Token(Token = "0x600000A")]
			[Address(RVA = "0x160DB00", Offset = "0x160DB00", Length = "0x8")]
			get;
		}

		[Token(Token = "0x17000002")]
		public HashSet<ProductDefinition> products
		{
			[Token(Token = "0x600000B")]
			[Address(RVA = "0x160DB08", Offset = "0x160DB08", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000003")]
		internal PurchasingFactory factory
		{
			[Token(Token = "0x600000C")]
			[Address(RVA = "0x160DB10", Offset = "0x160DB10", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x6000009")]
		[Address(RVA = "0x160DA7C", Offset = "0x160DA7C", Length = "0x84")]
		internal ConfigurationBuilder(PurchasingFactory factory)
		{
		}

		[Token(Token = "0x600000D")]
		[Address(RVA = "0xACD4C0", Offset = "0xACD4C0", Length = "0x24")]
		public T Configure<T>() where T : IStoreConfiguration
		{
			return default(T);
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0x160DB18", Offset = "0x160DB18", Length = "0x8C")]
		public static ConfigurationBuilder Instance(IPurchasingModule first, params IPurchasingModule[] rest)
		{
			return null;
		}

		[Token(Token = "0x600000F")]
		[Address(RVA = "0x160DD7C", Offset = "0x160DD7C", Length = "0xC")]
		public ConfigurationBuilder AddProduct(string id, ProductType type)
		{
			return null;
		}

		[Token(Token = "0x6000010")]
		[Address(RVA = "0x160DD88", Offset = "0x160DD88", Length = "0x8")]
		public ConfigurationBuilder AddProduct(string id, ProductType type, IDs storeIDs)
		{
			return null;
		}

		[Token(Token = "0x6000011")]
		[Address(RVA = "0x160DD90", Offset = "0x160DD90", Length = "0xE8")]
		public ConfigurationBuilder AddProduct(string id, ProductType type, IDs storeIDs, IEnumerable<PayoutDefinition> payouts)
		{
			return null;
		}
	}
}
