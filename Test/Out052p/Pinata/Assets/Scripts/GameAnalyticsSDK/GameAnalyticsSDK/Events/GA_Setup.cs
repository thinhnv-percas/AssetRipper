using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using GameAnalyticsSDK.Utilities;
using GameAnalyticsSDK.Validators;
using GameAnalyticsSDK.Wrapper;

namespace GameAnalyticsSDK.Events
{
	[Token(Token = "0x2000018")]
	public static class GA_Setup
	{
		[Token(Token = "0x60000E8")]
		[Address(RVA = "0x15A0F44", Offset = "0x15A0F44", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F10598]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20297D3]) = v38;\nL_0019:\n\tv44 = System.Collections.Generic.List`1<System.String>::ToArray(customDimensions);\n\tv47 = GameAnalyticsSDK.Validators.GAValidator::ValidateCustomDimensions(v44);\n\tv49 = v47 == 0;\n\tif (v49) goto L_003B;\n\tv73 = GameAnalyticsSDK.Utilities.GA_MiniJSON+Serializer::Serialize(customDimensions);\n\tgoto L_0034;\n\tv80 = *([v65 @ X8_v7+E0]);\n\tv81 = v80 == 0;\n\tv82 = ~v81;\n\tif (v82) goto L_0034;\n\tv85 = v65;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v85, v43, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0034:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::SetAvailableCustomDimensions01(v73);\n\treturn;\nL_003B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetAvailableCustomDimensions01(List<string> customDimensions)
		{
			string[] customDimensions2 = customDimensions.ToArray();
			if (GAValidator.ValidateCustomDimensions(customDimensions2))
			{
				string availableCustomDimensions = GA_MiniJSON.Serializer.Serialize(customDimensions);
				GA_Wrapper.SetAvailableCustomDimensions01(availableCustomDimensions);
			}
		}

		[Token(Token = "0x60000E9")]
		[Address(RVA = "0x15A10B0", Offset = "0x15A10B0", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF9268]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20297D4]) = v38;\nL_0019:\n\tv44 = System.Collections.Generic.List`1<System.String>::ToArray(customDimensions);\n\tv47 = GameAnalyticsSDK.Validators.GAValidator::ValidateCustomDimensions(v44);\n\tv49 = v47 == 0;\n\tif (v49) goto L_003B;\n\tv73 = GameAnalyticsSDK.Utilities.GA_MiniJSON+Serializer::Serialize(customDimensions);\n\tgoto L_0034;\n\tv80 = *([v65 @ X8_v7+E0]);\n\tv81 = v80 == 0;\n\tv82 = ~v81;\n\tif (v82) goto L_0034;\n\tv85 = v65;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v85, v43, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0034:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::SetAvailableCustomDimensions02(v73);\n\treturn;\nL_003B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetAvailableCustomDimensions02(List<string> customDimensions)
		{
			string[] customDimensions2 = customDimensions.ToArray();
			if (GAValidator.ValidateCustomDimensions(customDimensions2))
			{
				string availableCustomDimensions = GA_MiniJSON.Serializer.Serialize(customDimensions);
				GA_Wrapper.SetAvailableCustomDimensions02(availableCustomDimensions);
			}
		}

		[Token(Token = "0x60000EA")]
		[Address(RVA = "0x15A11BC", Offset = "0x15A11BC", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EA9AB8]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20297D5]) = v38;\nL_0019:\n\tv44 = System.Collections.Generic.List`1<System.String>::ToArray(customDimensions);\n\tv47 = GameAnalyticsSDK.Validators.GAValidator::ValidateCustomDimensions(v44);\n\tv49 = v47 == 0;\n\tif (v49) goto L_003B;\n\tv73 = GameAnalyticsSDK.Utilities.GA_MiniJSON+Serializer::Serialize(customDimensions);\n\tgoto L_0034;\n\tv80 = *([v65 @ X8_v7+E0]);\n\tv81 = v80 == 0;\n\tv82 = ~v81;\n\tif (v82) goto L_0034;\n\tv85 = v65;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v85, v43, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0034:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::SetAvailableCustomDimensions03(v73);\n\treturn;\nL_003B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetAvailableCustomDimensions03(List<string> customDimensions)
		{
			string[] customDimensions2 = customDimensions.ToArray();
			if (GAValidator.ValidateCustomDimensions(customDimensions2))
			{
				string availableCustomDimensions = GA_MiniJSON.Serializer.Serialize(customDimensions);
				GA_Wrapper.SetAvailableCustomDimensions03(availableCustomDimensions);
			}
		}

		[Token(Token = "0x60000EB")]
		[Address(RVA = "0x15A12C8", Offset = "0x15A12C8", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB1A78]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20297D6]) = v38;\nL_0019:\n\tv44 = System.Collections.Generic.List`1<System.String>::ToArray(resourceCurrencies);\n\tv47 = GameAnalyticsSDK.Validators.GAValidator::ValidateResourceCurrencies(v44);\n\tv49 = v47 == 0;\n\tif (v49) goto L_003B;\n\tv73 = GameAnalyticsSDK.Utilities.GA_MiniJSON+Serializer::Serialize(resourceCurrencies);\n\tgoto L_0034;\n\tv80 = *([v65 @ X8_v7+E0]);\n\tv81 = v80 == 0;\n\tv82 = ~v81;\n\tif (v82) goto L_0034;\n\tv85 = v65;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v85, v43, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0034:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::SetAvailableResourceCurrencies(v73);\n\treturn;\nL_003B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetAvailableResourceCurrencies(List<string> resourceCurrencies)
		{
			string[] resourceCurrencies2 = resourceCurrencies.ToArray();
			if (GAValidator.ValidateResourceCurrencies(resourceCurrencies2))
			{
				string availableResourceCurrencies = GA_MiniJSON.Serializer.Serialize(resourceCurrencies);
				GA_Wrapper.SetAvailableResourceCurrencies(availableResourceCurrencies);
			}
		}

		[Token(Token = "0x60000EC")]
		[Address(RVA = "0x15A1504", Offset = "0x15A1504", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F07728]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20297D7]) = v38;\nL_0019:\n\tv44 = System.Collections.Generic.List`1<System.String>::ToArray(resourceItemTypes);\n\tv47 = GameAnalyticsSDK.Validators.GAValidator::ValidateResourceItemTypes(v44);\n\tv49 = v47 == 0;\n\tif (v49) goto L_003B;\n\tv73 = GameAnalyticsSDK.Utilities.GA_MiniJSON+Serializer::Serialize(resourceItemTypes);\n\tgoto L_0034;\n\tv80 = *([v65 @ X8_v7+E0]);\n\tv81 = v80 == 0;\n\tv82 = ~v81;\n\tif (v82) goto L_0034;\n\tv85 = v65;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v85, v43, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0034:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::SetAvailableResourceItemTypes(v73);\n\treturn;\nL_003B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetAvailableResourceItemTypes(List<string> resourceItemTypes)
		{
			string[] resourceItemTypes2 = resourceItemTypes.ToArray();
			if (GAValidator.ValidateResourceItemTypes(resourceItemTypes2))
			{
				string availableResourceItemTypes = GA_MiniJSON.Serializer.Serialize(resourceItemTypes);
				GA_Wrapper.SetAvailableResourceItemTypes(availableResourceItemTypes);
			}
		}

		[Token(Token = "0x60000ED")]
		[Address(RVA = "0x15A1734", Offset = "0x15A1734", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EBB570]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20297D8]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::SetInfoLog(enabled);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetInfoLog(bool enabled)
		{
			GA_Wrapper.SetInfoLog(enabled);
		}

		[Token(Token = "0x60000EE")]
		[Address(RVA = "0x15A17FC", Offset = "0x15A17FC", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EBE6E8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20297D9]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::SetVerboseLog(enabled);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetVerboseLog(bool enabled)
		{
			GA_Wrapper.SetVerboseLog(enabled);
		}

		[Token(Token = "0x60000EF")]
		[Address(RVA = "0x15A18C4", Offset = "0x15A18C4", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC4DE8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20297DA]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::SetFacebookId(facebookId);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetFacebookId(string facebookId)
		{
			GA_Wrapper.SetFacebookId(facebookId);
		}

		[Token(Token = "0x60000F0")]
		[Address(RVA = "0x15A198C", Offset = "0x15A198C", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1ECDB18]);\n\tv19 = *([v18 @ X8_v18]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20297DB]) = v38;\nL_0017:\n\tv43 = gender == 2;\n\tif (v43) goto L_FFFFFFFF;\n\tv58 = gender != 1;\n\tif (v58) goto L_0055;\n\tgoto L_0034;\nL_0034:\n\tv111 = \"il2cpp_vm_object_box\"(v107, &v108 @ X8_v3 (System.Int32), v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv108 = *([v111 @ X0_v3]);\n\t*([v108 @ X8_v3 (System.Int32)+160])(v136, v111, *([v108 @ X8_v3 (System.Int32)+168]), v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv138 = \"il2cpp_vm_object_unbox\"(v111, *([v108 @ X8_v3 (System.Int32)+168]), v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_004F;\n\tv145 = *([v141 @ X0_v9+E0]);\n\tv146 = v145 == 0;\n\tv147 = ~v146;\n\tif (v147) goto L_004F;\n\tv149 = \"il2cpp_codegen_runtime_class_init\"(v141, v70, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_004F:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::SetGender(v136);\nL_0055:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 63 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetGender(GAGender gender)
		{
			//IL_004f: Expected I, but got O
			//IL_0065: Expected I4, but got O
			//IL_0033: Expected I, but got O
			int num;
			switch (gender)
			{
			case GAGender.male:
			{
				IntPtr intPtr = (IntPtr)typeof(GAGender);
				num = 1;
				break;
			}
			case GAGender.female:
			{
				IntPtr intPtr = (IntPtr)typeof(GAGender);
				num = 2;
				break;
			}
			default:
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object obj = default(object);
			num = (int)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v108 @ X8_v3 (System.Int32)+160] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
			string gender2 = default(string);
			GA_Wrapper.SetGender(gender2);
		}

		[Token(Token = "0x60000F1")]
		[Address(RVA = "0x15A1AD4", Offset = "0x15A1AD4", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F05FD0]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20297DC]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::SetBirthYear(birthYear);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetBirthYear(int birthYear)
		{
			GA_Wrapper.SetBirthYear(birthYear);
		}

		[Token(Token = "0x60000F2")]
		[Address(RVA = "0x15A1B9C", Offset = "0x15A1B9C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F10C58]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20297DD]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::SetCustomDimension01(customDimension);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetCustomDimension01(string customDimension)
		{
			GA_Wrapper.SetCustomDimension01(customDimension);
		}

		[Token(Token = "0x60000F3")]
		[Address(RVA = "0x15A1C64", Offset = "0x15A1C64", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ECD178]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20297DE]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::SetCustomDimension02(customDimension);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetCustomDimension02(string customDimension)
		{
			GA_Wrapper.SetCustomDimension02(customDimension);
		}

		[Token(Token = "0x60000F4")]
		[Address(RVA = "0x15A1D2C", Offset = "0x15A1D2C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ECC430]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20297DF]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tGameAnalyticsSDK.Wrapper.GA_Wrapper::SetCustomDimension03(customDimension);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetCustomDimension03(string customDimension)
		{
			GA_Wrapper.SetCustomDimension03(customDimension);
		}
	}
}
