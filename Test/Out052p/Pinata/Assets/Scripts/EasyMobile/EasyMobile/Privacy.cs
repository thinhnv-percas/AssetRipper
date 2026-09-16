using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x200008D")]
	public static class Privacy
	{
		[Token(Token = "0x170001B1")]
		public static ConsentStatus GlobalDataPrivacyConsent
		{
			[Token(Token = "0x60005F1")]
			[Address(RVA = "0xFD25E0", Offset = "0xFD25E0", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = EasyMobile.GlobalConsentManager::get_Instance();\n\tv9 = *([v7 @ X0_v2 (EasyMobile.GlobalConsentManager)]);\n\tv10 = *([v9 @ X8_v1 (Il2CppClass<EasyMobile.GlobalConsentManager>)+1C0]);\n\tv11 = *([v9 @ X8_v1 (Il2CppClass<EasyMobile.GlobalConsentManager>)+1C8]);\n\t// 14 IndirectJump v10 @ X2_v1, v7 @ X0_v2 (EasyMobile.GlobalConsentManager), v7 @ X0_v2 (EasyMobile.GlobalConsentManager), v11 @ X1_v1, v10 @ X2_v1, v14 @ X3, v15 @ X4, v16 @ X5, v17 @ X6, v18 @ X7, v19 @ V0, v20 @ V1, v21 @ V2, v22 @ V3, v23 @ V4, v24 @ V5, v25 @ V6, v26 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_0016: Expected I, but got O
				//IL_0026: Expected O, but got I
				//IL_0036: Expected O, but got I
				GlobalConsentManager instance = GlobalConsentManager.Instance;
				IntPtr intPtr = (IntPtr)instance;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ X8_v1 (Il2CppClass<EasyMobile.GlobalConsentManager>)+1C0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ X8_v1 (Il2CppClass<EasyMobile.GlobalConsentManager>)+1C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v10 @ X2_v1 (should have been resolved before IL gen)");
				return ConsentStatus.Unknown;
			}
		}

		[Token(Token = "0x60005F2")]
		[Address(RVA = "0xFD2608", Offset = "0xFD2608", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF3658]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20256A9]) = v38;\nL_0019:\n\tgoto L_0026;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0026;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\tEasyMobile.EEARegionValidator::ValidateEEARegionStatus(callback);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void IsInEEARegion(Action<EEARegionStatus> callback)
		{
			EEARegionValidator.ValidateEEARegionStatus(callback);
		}

		[Token(Token = "0x60005F3")]
		[Address(RVA = "0xFD2670", Offset = "0xFD2670", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = EasyMobile.EM_Settings::get_Privacy();\n\treturn v7.mDefaultConsentDialog;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ConsentDialog GetDefaultConsentDialog()
		{
			PrivacySettings privacy = EM_Settings.Privacy;
			return privacy.DefaultConsentDialog;
		}

		[Token(Token = "0x60005F4")]
		[Address(RVA = "0xFD2694", Offset = "0xFD2694", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = EasyMobile.Privacy::GetDefaultConsentDialog();\n\tv14 = v12 == 0;\n\tif (v14) goto L_0015;\n\tEasyMobile.ConsentDialog::Show(v12, dismissible);\nL_0015:\n\treturn v12;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ConsentDialog ShowDefaultConsentDialog(bool dismissible = false)
		{
			ConsentDialog defaultConsentDialog = GetDefaultConsentDialog();
			defaultConsentDialog?.Show(dismissible);
			return defaultConsentDialog;
		}

		[Token(Token = "0x60005F5")]
		[Address(RVA = "0xFD26D0", Offset = "0xFD26D0", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = EasyMobile.GlobalConsentManager::get_Instance();\n\tv9 = *([v7 @ X0_v2 (EasyMobile.GlobalConsentManager)]);\n\tv10 = *([v9 @ X8_v1 (Il2CppClass<EasyMobile.GlobalConsentManager>)+1D0]);\n\tv11 = *([v9 @ X8_v1 (Il2CppClass<EasyMobile.GlobalConsentManager>)+1D8]);\n\t// 14 IndirectJump v10 @ X2_v1, v7 @ X0_v2 (EasyMobile.GlobalConsentManager), v7 @ X0_v2 (EasyMobile.GlobalConsentManager), v11 @ X1_v1, v10 @ X2_v1, v14 @ X3, v15 @ X4, v16 @ X5, v17 @ X6, v18 @ X7, v19 @ V0, v20 @ V1, v21 @ V2, v22 @ V3, v23 @ V4, v24 @ V5, v25 @ V6, v26 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void GrantGlobalDataPrivacyConsent()
		{
			//IL_0016: Expected I, but got O
			//IL_0026: Expected O, but got I
			//IL_0036: Expected O, but got I
			GlobalConsentManager instance = GlobalConsentManager.Instance;
			IntPtr intPtr = (IntPtr)instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ X8_v1 (Il2CppClass<EasyMobile.GlobalConsentManager>)+1D0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ X8_v1 (Il2CppClass<EasyMobile.GlobalConsentManager>)+1D8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v10 @ X2_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x60005F6")]
		[Address(RVA = "0xFD26F8", Offset = "0xFD26F8", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = EasyMobile.GlobalConsentManager::get_Instance();\n\tv9 = *([v7 @ X0_v2 (EasyMobile.GlobalConsentManager)]);\n\tv10 = *([v9 @ X8_v1 (Il2CppClass<EasyMobile.GlobalConsentManager>)+1E0]);\n\tv11 = *([v9 @ X8_v1 (Il2CppClass<EasyMobile.GlobalConsentManager>)+1E8]);\n\t// 14 IndirectJump v10 @ X2_v1, v7 @ X0_v2 (EasyMobile.GlobalConsentManager), v7 @ X0_v2 (EasyMobile.GlobalConsentManager), v11 @ X1_v1, v10 @ X2_v1, v14 @ X3, v15 @ X4, v16 @ X5, v17 @ X6, v18 @ X7, v19 @ V0, v20 @ V1, v21 @ V2, v22 @ V3, v23 @ V4, v24 @ V5, v25 @ V6, v26 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void RevokeGlobalDataPrivacyConsent()
		{
			//IL_0016: Expected I, but got O
			//IL_0026: Expected O, but got I
			//IL_0036: Expected O, but got I
			GlobalConsentManager instance = GlobalConsentManager.Instance;
			IntPtr intPtr = (IntPtr)instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ X8_v1 (Il2CppClass<EasyMobile.GlobalConsentManager>)+1E0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v9 @ X8_v1 (Il2CppClass<EasyMobile.GlobalConsentManager>)+1E8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v10 @ X2_v1 (should have been resolved before IL gen)");
		}
	}
}
