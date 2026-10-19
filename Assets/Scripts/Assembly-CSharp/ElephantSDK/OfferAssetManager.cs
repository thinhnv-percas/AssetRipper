using System.Collections.Generic;
using Cpp2ILInjected;

namespace ElephantSDK
{
	[Token(Token = "0x2000956")]
	public class OfferAssetManager
	{
		[Token(Token = "0x4001F6D")]
		internal static OfferAssetManager _instance;

		[Token(Token = "0x4001F6E")]
		[FieldOffset(Offset = "0x10")]
		public OfferUIData offerUIData;

		[Token(Token = "0x4001F6F")]
		[FieldOffset(Offset = "0x18")]
		public Dictionary<string, string> localPricingCache;

		[Token(Token = "0x4001F70")]
		[FieldOffset(Offset = "0x20")]
		public Dictionary<string, string> templateFieldsCache;

		[Token(Token = "0x4001F71")]
		[FieldOffset(Offset = "0x28")]
		public OfferData currentOffer;

		[Token(Token = "0x4001F72")]
		[FieldOffset(Offset = "0x30")]
		public OfferMetaData offerMetaData;

		[Token(Token = "0x4001F73")]
		[FieldOffset(Offset = "0x38")]
		public Offer currentOfferResponse;

		[Token(Token = "0x4001F74")]
		[FieldOffset(Offset = "0x40")]
		public List<PurchaseOption> purchaseOptions;

		[Token(Token = "0x4001F75")]
		[FieldOffset(Offset = "0x48")]
		public string iapNames;

		[Token(Token = "0x4001F76")]
		[FieldOffset(Offset = "0x50")]
		public List<string> offerUrls;

		[Token(Token = "0x60027E8")]
		[Address(RVA = "0x3E46038", Offset = "0x3E46038", Length = "0xA0")]
		public static OfferAssetManager GetInstance()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("OfferAssetManager::GetInstance");
			return default;
		}

		[Token(Token = "0x60027E9")]
		[Address(RVA = "0x3E483A8", Offset = "0x3E483A8", Length = "0xE4")]
		public void SetTemplateFields(Pair[] templateFields, string offerName)
		{
			if (templateFields != null && templateFields.Length >= 1)
			{
				int num = 0;
				do
				{
					Pair pair = templateFields[num];
					string key = offerName + "_" + pair.key;
					templateFieldsCache[key] = pair.value;
					num++;
				}
				while (num < templateFields.Length);
			}
		}

		[Token(Token = "0x60027EA")]
		[Address(RVA = "0x3E48AD8", Offset = "0x3E48AD8", Length = "0x158")]
		public OfferAssetManager()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			localPricingCache = dictionary;
			Dictionary<string, string> dictionary2 = new Dictionary<string, string>();
			templateFieldsCache = dictionary2;
			List<PurchaseOption> list = new List<PurchaseOption>();
			purchaseOptions = list;
			List<string> list2 = new List<string>();
			offerUrls = list2;
		}
	}
}
