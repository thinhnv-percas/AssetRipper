using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x200008B")]
	public class GlobalConsentManager : ConsentManager
	{
		[Token(Token = "0x4000358")]
		private const string DATA_PRIVACY_CONSENT_KEY = "EM_Global_DataPrivacyConsent";

		[Token(Token = "0x4000359")]
		private static GlobalConsentManager sInstance;

		[Token(Token = "0x170001AF")]
		public static GlobalConsentManager Instance
		{
			[Token(Token = "0x60005EA")]
			[Address(RVA = "0xBF4F68", Offset = "0xBF4F68", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1ECA758]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([2022EDE]) = v39;\nL_0017:\n\tv53 = v43.sInstance;\n\tv45 = v43.sInstance == 0;\n\tv46 = ~v45;\n\tif (v46) goto L_0030;\n\tv47 = new EasyMobile.GlobalConsentManager();\n\tEasyMobile.ConsentManager::.ctor(v47);\n\tv47.mDataPrivacyConsentKey = \"EM_Global_DataPrivacyConsent\";\n\tv66.sInstance = v47;\n\tv53 = v68.sInstance;\nL_0030:\n\treturn v53;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				GlobalConsentManager result = sInstance;
				if (sInstance == null)
				{
					GlobalConsentManager globalConsentManager = (GlobalConsentManager)new ConsentManager();
					globalConsentManager.mDataPrivacyConsentKey = "EM_Global_DataPrivacyConsent";
					sInstance = globalConsentManager;
					result = sInstance;
				}
				return result;
			}
		}

		[Token(Token = "0x60005EB")]
		[Address(RVA = "0xBF5000", Offset = "0xBF5000", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEasyMobile.ConsentManager::.ctor(this);\n\tthis.mDataPrivacyConsentKey = key;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private GlobalConsentManager(string key)
		{
			mDataPrivacyConsentKey = key;
		}
	}
}
