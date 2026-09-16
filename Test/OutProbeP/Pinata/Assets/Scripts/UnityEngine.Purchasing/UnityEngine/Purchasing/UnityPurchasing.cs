using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine.Purchasing.Extension;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x200001D")]
	public abstract class UnityPurchasing
	{
		[Token(Token = "0x6000094")]
		[Address(RVA = "0x16112EC", Offset = "0x16112EC", Length = "0xD8")]
		public static void Initialize(IStoreListener listener, ConfigurationBuilder builder)
		{
		}

		[Token(Token = "0x6000095")]
		[Address(RVA = "0x16113C4", Offset = "0x16113C4", Length = "0x1A8")]
		internal static void Initialize(IStoreListener listener, ConfigurationBuilder builder, ILogger logger, string persistentDatapath, IUnityAnalytics analytics, ICatalogProvider catalog)
		{
		}

		[Token(Token = "0x6000096")]
		[Address(RVA = "0x1611574", Offset = "0x1611574", Length = "0x158")]
		internal static void FetchAndMergeProducts(bool useCatalog, HashSet<ProductDefinition> localProductSet, ICatalogProvider catalog, Action<HashSet<ProductDefinition>> callback)
		{
		}
	}
}
