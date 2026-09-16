using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x2000088")]
	public static class EEARegionStatusExtension
	{
		[Token(Token = "0x60005E6")]
		[Address(RVA = "0xA55B60", Offset = "0xA55B60", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv20 = *([1EF6438]);\n\tv21 = *([v20 @ X8_v13]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021FAA]) = v40;\nL_0017:\n\tv44 = System.String::IsNullOrEmpty(countryCode);\n\tv48 = v44 == 0;\n\tv49 = ~v48;\n\tif (v49) goto L_0050;\n\tv53 = 0;\n\t// 35 Box v55 @ X0_v7, typeof(EasyMobile.EEARegionStatus), &v53 @ stack_-24_v3\n\tv124 = *([v55 @ X0_v7]);\n\t*([v124 @ X8_v8+160])(v127, v55, *([v124 @ X8_v8+168]), v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv129 = \"il2cpp_vm_object_unbox\"(v55, *([v124 @ X8_v8+168]), v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv135 = System.String::Equals(countryCode, v127);\n\tv87 = v135 == 0;\n\tif (v87) goto L_003D;\n\tgoto L_0050;\nL_003D:\n\tv138 = EasyMobile.EEACountriesExtension::IsEEACountry(countryCode);\n\tv67 = v138 == 0;\n\tv58 = ~v67;\n\tif (v58) goto L_FFFFFFFF;\n\tv85 = 1 + 1;\n\tgoto L_0050;\nL_0050:\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static EEARegionStatus CheckEEARegionStatus(this string countryCode)
		{
			//IL_000e: Expected O, but got I4
			//IL_0017: Expected I4, but got O
			bool flag = string.IsNullOrEmpty(countryCode);
			bool flag2 = !flag;
			bool flag3 = !flag2;
			EEARegionStatus result = default(EEARegionStatus);
			if (!flag3)
			{
				object obj = 0;
				object obj2 = (EEARegionStatus)obj;
				object obj3 = obj2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v124 @ X8_v8+160] (should have been resolved before IL gen)");
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				string value = default(string);
				if (!countryCode.Equals(value))
				{
					if (!countryCode.IsEEACountry())
					{
						return EEARegionStatus.NotInEEA;
					}
					return EEARegionStatus.InEEA;
				}
				result = default(EEARegionStatus);
			}
			return result;
		}
	}
}
