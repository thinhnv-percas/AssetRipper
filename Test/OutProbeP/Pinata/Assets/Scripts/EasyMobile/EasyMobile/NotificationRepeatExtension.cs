using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile
{
	[Token(Token = "0x2000079")]
	public static class NotificationRepeatExtension
	{
		[Token(Token = "0x6000567")]
		[Address(RVA = "0xFCF7A4", Offset = "0xFCF7A4", Length = "0x160")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F09B40]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, returnVal1, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2025681]) = v38;\nL_0013:\n\tv39 = t - 1;\n\tv40 = v39 < 3;\n\tv41 = ~v40;\n\tv42 = v39 - 3;\n\tv44 = v42 == 0;\n\tv50 = ~v44;\n\tv51 = v41 & v50;\n\tif (v51) goto L_003C;\n\tv53 = 0x181D000 + 0xDB8;\n\tv55 = *([v53 @ X9_v2 (System.Int32)+v39 @ X8_v3 (System.Int32)*4]) + v53;\n\t// 37 IndirectJump v55 @ X8_v9, t @ X0 (EasyMobile.NotificationRepeat), t @ X0 (EasyMobile.NotificationRepeat), methodInfo @ X1 (Il2CppMethodInfo), v22 @ X2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, returnVal1 @ V0 (System.Double), v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tX8 = *([1ED4850]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0032;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0032;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0032:\n\tV0 = 1d;\n\tX0 = 0;\n\tX0 = System.TimeSpan::FromMinutes(V0, X0);\n\tgoto L_0076;\nL_003C:\n\tgoto L_0044;\n\tv82 = *([v58 @ X0_v2 (Il2CppClass<System.TimeSpan>)+E0]);\n\tv83 = v82 == 0;\n\tv84 = ~v83;\n\tif (v84) goto L_0044;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v58, methodInfo, v22, v23, v24, v25, v26, v27, returnVal1, v29, v30, v31, v32, v33, v34, v35);\n\tv86 = System.TimeSpan;\nL_0044:\n\tv88 = v77.Zero;\n\tgoto L_0076;\n\tX8 = *([1ED4850]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0052;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0052;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0052:\n\tV0 = 1d;\n\tX0 = 0;\n\tX0 = System.TimeSpan::FromHours(V0, X0);\n\tgoto L_0076;\n\tX8 = *([1ED4850]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0062;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0062;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0062:\n\tV0 = 1d;\n\tgoto L_0071;\n\tX8 = *([1ED4850]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0070;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0070;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0070:\n\tV0 = 4.000000000698492d;\nL_0071:\n\tX0 = 0;\n\tX0 = System.TimeSpan::FromDays(V0, X0);\nL_0076:\n\tt = 0x9BD218(&v88 @ X0_v4 (System.TimeSpan), 0, v22, v23, v24, v25, v26, v27, returnVal1, v29, v30, v31, v32, v33, v34, v35);\n\treturn returnVal1;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static double ToSecondInterval(this NotificationRepeat t)
		{
			//IL_0029: Expected O, but got I
			int num = (int)(t - 1);
			bool flag = num < 3;
			bool flag2 = !flag;
			int num2 = num - 3;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 25284608 + 3512;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X9_v2 (System.Int32)+v39 @ X8_v3 (System.Int32)*4]");
				object obj = 0L + (long)num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v55 @ X8_v9 (should have been resolved before IL gen)");
			}
			TimeSpan zero = TimeSpan.Zero;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9BD218 (inside System.TimeSpan::TimeToTicks +0x298)");
			double result = default(double);
			return result;
		}

		[Token(Token = "0x6000568")]
		[Address(RVA = "0xFCF904", Offset = "0xFCF904", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EE3798]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, v21, v22, v23, v24, v25, v26, v27, interval, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 0 | 1;\n\t*([2025682]) = v38;\nL_001A:\n\tgoto L_0022;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0022;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, v21, v22, v23, v24, v25, v26, v27, interval, v28, v29, v30, v31, v32, v33, v34);\nL_0022:\n\tv55 = System.TimeSpan::FromSeconds(interval);\n\tv55 = 0x9BD1D0(&v55 @ X0_v5 (System.TimeSpan), 0, v22, v23, v24, v25, v26, v27, interval, v28, v29, v30, v31, v32, v33, v34);\n\tv65 = interval == 4.000000000698492d;\n\tif (v65) goto L_FFFFFFFF;\n\tv55 = 0x9BD1D0(&v55 @ X0_v5 (System.TimeSpan), 0, v22, v23, v24, v25, v26, v27, interval, 4.000000000698492d, v29, v30, v31, v32, v33, v34);\n\tv79 = interval == 1d;\n\tif (v79) goto L_FFFFFFFF;\n\tv55 = 0x9BD1E8(&v55 @ X0_v5 (System.TimeSpan), 0, v22, v23, v24, v25, v26, v27, interval, 4.000000000698492d, v29, v30, v31, v32, v33, v34);\n\tv97 = interval == 1d;\n\tif (v97) goto L_FFFFFFFF;\n\tv55 = 0x9BD200(&v55 @ X0_v5 (System.TimeSpan), 0, v22, v23, v24, v25, v26, v27, interval, 4.000000000698492d, v29, v30, v31, v32, v33, v34);\n\tv104 = interval - 1d;\n\tv98 = v104 == 0;\n\tgoto L_0065;\n\tgoto L_0065;\n\tgoto L_0065;\nL_0065:\n\treturn returnVal1;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static NotificationRepeat FromExactSecondInterval(double interval)
		{
			TimeSpan timeSpan = TimeSpan.FromSeconds(interval);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9BD1D0 (inside System.TimeSpan::TimeToTicks +0x250)");
			if (interval != 4.000000000698492)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9BD1D0 (inside System.TimeSpan::TimeToTicks +0x250)");
				if (interval != 1.0)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9BD1E8 (inside System.TimeSpan::TimeToTicks +0x268)");
					if (interval != 1.0)
					{
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @9BD200 (inside System.TimeSpan::TimeToTicks +0x280)");
						double num = interval - 1.0;
						return (num == 0.0) ? NotificationRepeat.EveryMinute : NotificationRepeat.None;
					}
					return NotificationRepeat.EveryHour;
				}
				return NotificationRepeat.EveryDay;
			}
			return NotificationRepeat.EveryWeek;
		}
	}
}
