using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x2000020")]
	public class AdvertisingConsentManager : ConsentManager
	{
		[Token(Token = "0x400011B")]
		private const string DATA_PRIVACY_CONSENT_KEY = "EM_Ads_DataPrivacyConsent";

		[Token(Token = "0x400011C")]
		private static AdvertisingConsentManager sInstance;

		[Token(Token = "0x17000038")]
		public static AdvertisingConsentManager Instance
		{
			[Token(Token = "0x6000103")]
			[Address(RVA = "0xA44F24", Offset = "0xA44F24", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EFF9A0]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2021F2B]) = v39;\nL_0017:\n\tv53 = v43.sInstance;\n\tv45 = v43.sInstance == 0;\n\tv46 = ~v45;\n\tif (v46) goto L_0030;\n\tv47 = new EasyMobile.AdvertisingConsentManager();\n\tSystem.Object::.ctor(v47);\n\tv47.mDataPrivacyConsentKey = \"EM_Ads_DataPrivacyConsent\";\n\tv66.sInstance = v47;\n\tv53 = v68.sInstance;\nL_0030:\n\treturn v53;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				AdvertisingConsentManager result = sInstance;
				if (sInstance == null)
				{
					AdvertisingConsentManager advertisingConsentManager = null;
					advertisingConsentManager.mDataPrivacyConsentKey = "EM_Ads_DataPrivacyConsent";
					sInstance = advertisingConsentManager;
					result = sInstance;
				}
				return result;
			}
		}

		[Token(Token = "0x6000104")]
		[Address(RVA = "0xA4D680", Offset = "0xA4D680", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.mDataPrivacyConsentKey = key;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private AdvertisingConsentManager(string key)
		{
			mDataPrivacyConsentKey = key;
		}
	}
}
