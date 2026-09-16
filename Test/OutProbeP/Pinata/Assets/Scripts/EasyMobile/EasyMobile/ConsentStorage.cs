using AssetRipperInjected;
using Cpp2ILInjected;
using EasyMobile.Internal;

namespace EasyMobile
{
	[Token(Token = "0x2000084")]
	public static class ConsentStorage
	{
		[Token(Token = "0x400031C")]
		public const int UnknownConsentStoredValue = -1;

		[Token(Token = "0x400031D")]
		public const int RevokedConsentStoredValue = 0;

		[Token(Token = "0x400031E")]
		public const int GrantedConsentStoredValue = 1;

		[Token(Token = "0x60005E2")]
		[Address(RVA = "0xA44E10", Offset = "0xA44E10", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = EasyMobile.Internal.StorageUtil::GetInt(key, 0xFFFFFFFF);\n\tv10 = v8 + 1;\n\tv12 = v10 == 0;\n\tif (v12) goto L_0025;\n\tv25 = v8 != 0;\n\tif (v25) goto L_FFFFFFFF;\n\tv29 = 1 + 1;\n\tgoto L_0020;\nL_0020:\n\treturn returnVal2;\nL_0025:\n\treturn 0;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ConsentStatus ReadConsent(string key)
		{
			int num = StorageUtil.GetInt(key, -1);
			if (num + 1 != 0)
			{
				if (num == 0)
				{
					return ConsentStatus.Revoked;
				}
				return ConsentStatus.Granted;
			}
			return default(ConsentStatus);
		}

		[Token(Token = "0x60005E3")]
		[Address(RVA = "0xA44E90", Offset = "0xA44E90", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = consent - 2;\n\tv5 = v3 == 0;\n\tv10 = ~v5;\n\tv16 = consent == 0;\n\tv21 = ~v16;\n\tv22 = ~v21;\n\tif (v22) goto L_FFFFFFFF;\n\tgoto L_001C;\nL_001C:\n\tEasyMobile.Internal.StorageUtil::SetInt(key, v25);\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SaveConsent(string key, ConsentStatus consent)
		{
			int num = (int)(consent - 2);
			bool flag = num == 0;
			bool flag2 = !flag;
			int value = ((consent == ConsentStatus.Unknown) ? (-1) : (flag2 ? 1 : 0));
			StorageUtil.SetInt(key, value);
		}
	}
}
