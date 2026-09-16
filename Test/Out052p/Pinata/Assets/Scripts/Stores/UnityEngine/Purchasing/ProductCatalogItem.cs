using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Serializable]
	[Token(Token = "0x2000068")]
	public class ProductCatalogItem
	{
		[Token(Token = "0x400015C")]
		[FieldOffset(Offset = "0x10")]
		public string id;

		[Token(Token = "0x400015D")]
		[FieldOffset(Offset = "0x18")]
		public ProductType type;

		[SerializeField]
		[Token(Token = "0x400015E")]
		[FieldOffset(Offset = "0x20")]
		private List<StoreID> storeIDs;

		[Token(Token = "0x400015F")]
		[FieldOffset(Offset = "0x28")]
		public LocalizedProductDescription defaultDescription;

		[Token(Token = "0x4000160")]
		[FieldOffset(Offset = "0x30")]
		public int applePriceTier;

		[Token(Token = "0x4000161")]
		[FieldOffset(Offset = "0x34")]
		public int xiaomiPriceTier;

		[Token(Token = "0x4000162")]
		[FieldOffset(Offset = "0x38")]
		public Price googlePrice;

		[SerializeField]
		[Token(Token = "0x4000163")]
		[FieldOffset(Offset = "0x40")]
		private List<LocalizedProductDescription> descriptions;

		[Token(Token = "0x4000164")]
		[FieldOffset(Offset = "0x48")]
		public Price udpPrice;

		[SerializeField]
		[Token(Token = "0x4000165")]
		[FieldOffset(Offset = "0x50")]
		private List<ProductCatalogPayout> payouts;

		[Token(Token = "0x17000031")]
		public IList<ProductCatalogPayout> Payouts
		{
			[Token(Token = "0x600017E")]
			[Address(RVA = "0xC6B794", Offset = "0xC6B794", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.payouts;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return payouts;
			}
		}

		[Token(Token = "0x17000032")]
		public ICollection<StoreID> allStoreIDs
		{
			[Token(Token = "0x600017F")]
			[Address(RVA = "0xC6B79C", Offset = "0xC6B79C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.storeIDs;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return storeIDs;
			}
		}

		[Token(Token = "0x6000180")]
		[Address(RVA = "0xC6B7A4", Offset = "0xC6B7A4", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EE97E0]);\n\tv21 = *([v20 @ X8_v19]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023396]) = v40;\nL_0017:\n\tv44 = new System.Collections.Generic.List`1<UnityEngine.Purchasing.StoreID>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Purchasing.StoreID>::.ctor(v44);\n\tthis.storeIDs = v44;\n\tv52 = new UnityEngine.Purchasing.LocalizedProductDescription();\n\tv52.googleLocale = 4;\n\tSystem.Object::.ctor(v52);\n\tthis.defaultDescription = v52;\n\tthis.applePriceTier = 0;\n\tv59 = new UnityEngine.Purchasing.Price();\n\tSystem.Object::.ctor(v59);\n\tthis.googlePrice = v59;\n\tv65 = new System.Collections.Generic.List`1<UnityEngine.Purchasing.LocalizedProductDescription>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Purchasing.LocalizedProductDescription>::.ctor(v65);\n\tthis.descriptions = v65;\n\tv71 = new UnityEngine.Purchasing.Price();\n\tSystem.Object::.ctor(v71);\n\tthis.udpPrice = v71;\n\tv77 = new System.Collections.Generic.List`1<UnityEngine.Purchasing.ProductCatalogPayout>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Purchasing.ProductCatalogPayout>::.ctor(v77);\n\tthis.payouts = v77;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 57 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ProductCatalogItem()
		{
			List<StoreID> list = new List<StoreID>();
			storeIDs = list;
			LocalizedProductDescription localizedProductDescription = new LocalizedProductDescription();
			localizedProductDescription.googleLocale = TranslationLocale.en_US;
			((object)localizedProductDescription)._002Ector();
			defaultDescription = localizedProductDescription;
			applePriceTier = 0;
			Price price = new Price();
			googlePrice = price;
			List<LocalizedProductDescription> list2 = new List<LocalizedProductDescription>();
			descriptions = list2;
			Price price2 = new Price();
			udpPrice = price2;
			List<ProductCatalogPayout> list3 = new List<ProductCatalogPayout>();
			payouts = list3;
		}
	}
}
