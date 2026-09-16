using AssetRipperInjected;
using Cpp2ILInjected;

namespace com.adjust.sdk
{
	[Token(Token = "0x2000013")]
	public static class AdjustLogLevelExtension
	{
		[Token(Token = "0x6000104")]
		[Address(RVA = "0x156EDF4", Offset = "0x156EDF4", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EEF1B8]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20290C8]) = v38;\nL_0013:\n\tv39 = AdjustLogLevel - 1;\n\tv40 = v39 < 6;\n\tv41 = ~v40;\n\tv42 = v39 - 6;\n\tv44 = v42 == 0;\n\tv49 = ~v44;\n\tv50 = v41 & v49;\n\tif (v50) goto L_FFFFFFFF;\n\tv52 = 0x1E9D000 + 0xAE0;\n\tv58 = *([v52 @ X9_v3 (System.Int32)+v39 @ X8_v3 (System.Int32)*8]);\n\tgoto L_002C;\nL_002C:\n\treturn *([v58 @ X8_v4 (System.String)]);\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string ToLowercaseString(this AdjustLogLevel AdjustLogLevel)
		{
			//IL_0024: Expected O, but got I
			int num = (int)(AdjustLogLevel - 1);
			bool flag = num < 6;
			bool flag2 = !flag;
			int num2 = num - 6;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 32100352 + 2784;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X9_v3 (System.Int32)+v39 @ X8_v3 (System.Int32)*8]");
				return (string)0;
			}
			return "unknown";
		}

		[Token(Token = "0x6000105")]
		[Address(RVA = "0x156A0F0", Offset = "0x156A0F0", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EBA110]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20290C9]) = v38;\nL_0013:\n\tv39 = AdjustLogLevel - 1;\n\tv40 = v39 < 6;\n\tv41 = ~v40;\n\tv42 = v39 - 6;\n\tv44 = v42 == 0;\n\tv49 = ~v44;\n\tv50 = v41 & v49;\n\tif (v50) goto L_FFFFFFFF;\n\tv52 = 0x1E9D000 + 0xAA0;\n\tv58 = *([v52 @ X9_v3 (System.Int32)+v39 @ X8_v3 (System.Int32)*8]);\n\tgoto L_002C;\nL_002C:\n\treturn *([v58 @ X8_v4 (System.String)]);\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string ToUppercaseString(this AdjustLogLevel AdjustLogLevel)
		{
			//IL_0024: Expected O, but got I
			int num = (int)(AdjustLogLevel - 1);
			bool flag = num < 6;
			bool flag2 = !flag;
			int num2 = num - 6;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 32100352 + 2720;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X9_v3 (System.Int32)+v39 @ X8_v3 (System.Int32)*8]");
				return (string)0;
			}
			return "UNKNOWN";
		}
	}
}
