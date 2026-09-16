using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x200007C")]
	public class NotificationsConsentManager : ConsentManager
	{
		[Token(Token = "0x40002DF")]
		private const string DATA_PRIVACY_CONSENT_KEY = "EM_Notifications_DataPrivacyConsent";

		[Token(Token = "0x40002E0")]
		private static NotificationsConsentManager sInstance;

		[Token(Token = "0x1700019D")]
		public static NotificationsConsentManager Instance
		{
			[Token(Token = "0x6000591")]
			[Address(RVA = "0xFD0E40", Offset = "0xFD0E40", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EA9EC0]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv39 = 0 | 1;\n\t*([202569F]) = v39;\nL_0017:\n\tv53 = v43.sInstance;\n\tv45 = v43.sInstance == 0;\n\tv46 = ~v45;\n\tif (v46) goto L_0030;\n\tv47 = new EasyMobile.NotificationsConsentManager();\n\tEasyMobile.ConsentManager::.ctor(v47);\n\tv47.mDataPrivacyConsentKey = \"EM_Notifications_DataPrivacyConsent\";\n\tv66.sInstance = v47;\n\tv53 = v68.sInstance;\nL_0030:\n\treturn v53;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				NotificationsConsentManager result = sInstance;
				if (sInstance == null)
				{
					NotificationsConsentManager notificationsConsentManager = (NotificationsConsentManager)new ConsentManager();
					notificationsConsentManager.mDataPrivacyConsentKey = "EM_Notifications_DataPrivacyConsent";
					sInstance = notificationsConsentManager;
					result = sInstance;
				}
				return result;
			}
		}

		[Token(Token = "0x6000592")]
		[Address(RVA = "0xFD1508", Offset = "0xFD1508", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tEasyMobile.ConsentManager::.ctor(this);\n\tthis.mDataPrivacyConsentKey = key;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private NotificationsConsentManager(string key)
		{
			mDataPrivacyConsentKey = key;
		}
	}
}
