using System;
using System.Collections.Generic;
using System.Diagnostics;
using Cpp2ILInjected;
using UnityEngine.Purchasing.Extension;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000016")]
	internal class PurchasingFactory : IPurchasingBinder, IExtensionProvider
	{
		[Token(Token = "0x400003F")]
		[FieldOffset(Offset = "0x10")]
		private Dictionary<Type, IStoreConfiguration> m_ConfigMap;

		[Token(Token = "0x4000040")]
		[FieldOffset(Offset = "0x18")]
		private Dictionary<Type, IStoreExtension> m_ExtensionMap;

		[Token(Token = "0x4000041")]
		[FieldOffset(Offset = "0x20")]
		private IStore m_Store;

		[Token(Token = "0x4000042")]
		[FieldOffset(Offset = "0x28")]
		private ICatalogProvider m_CatalogProvider;

		[Token(Token = "0x1700001F")]
		[field: AttributeAttribute(Type = typeof(DebuggerBrowsableAttribute), RVA = "0x726878", Offset = "0x726878")]
		[field: Token(Token = "0x4000043")]
		[field: FieldOffset(Offset = "0x30")]
		public string storeName
		{
			[Token(Token = "0x6000065")]
			[Address(RVA = "0x160F0A8", Offset = "0x160F0A8", Length = "0x8")]
			get;
			[Token(Token = "0x6000066")]
			[Address(RVA = "0x160F0B0", Offset = "0x160F0B0", Length = "0x8")]
			private set;
		}

		[Token(Token = "0x17000020")]
		public IStore service
		{
			[Token(Token = "0x6000067")]
			[Address(RVA = "0x160F0B8", Offset = "0x160F0B8", Length = "0x88")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000068")]
			[Address(RVA = "0x160F140", Offset = "0x160F140", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x6000064")]
		[Address(RVA = "0x160DBA4", Offset = "0x160DBA4", Length = "0x1D8")]
		public PurchasingFactory(IPurchasingModule first, params IPurchasingModule[] remainingModules)
		{
		}

		[Token(Token = "0x6000069")]
		[Address(RVA = "0x160F148", Offset = "0x160F148", Length = "0x18")]
		public void RegisterStore(string name, IStore s)
		{
		}

		[Token(Token = "0x600006A")]
		[Address(RVA = "0xB866A8", Offset = "0xB866A8", Length = "0xAC")]
		public void RegisterExtension<T>(T instance) where T : IStoreExtension
		{
		}

		[Token(Token = "0x600006B")]
		[Address(RVA = "0xB865FC", Offset = "0xB865FC", Length = "0xAC")]
		public void RegisterConfiguration<T>(T instance) where T : IStoreConfiguration
		{
		}

		[Token(Token = "0x600006C")]
		[Address(RVA = "0xACD700", Offset = "0xACD700", Length = "0x1B0")]
		public T GetConfig<T>() where T : IStoreConfiguration
		{
			return default(T);
		}

		[Token(Token = "0x600006D")]
		[Address(RVA = "0xACD8B0", Offset = "0xACD8B0", Length = "0x1B0")]
		public T GetExtension<T>() where T : IStoreExtension
		{
			return default(T);
		}

		[Token(Token = "0x600006E")]
		[Address(RVA = "0x160F160", Offset = "0x160F160", Length = "0x8")]
		public void SetCatalogProvider(ICatalogProvider provider)
		{
		}

		[Token(Token = "0x600006F")]
		[Address(RVA = "0x160F168", Offset = "0x160F168", Length = "0x70")]
		public void SetCatalogProviderFunction(Action<Action<HashSet<ProductDefinition>>> func)
		{
		}

		[Token(Token = "0x6000070")]
		[Address(RVA = "0x160F204", Offset = "0x160F204", Length = "0x8")]
		internal ICatalogProvider GetCatalogProvider()
		{
			return null;
		}
	}
}
