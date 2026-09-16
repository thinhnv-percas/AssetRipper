using System;
using System.Collections.Generic;
using System.Threading;
using AssetRipperInjected;
using Cpp2ILInjected;
using Mycom.Tracker.Unity.Internal.Implementations.Android;
using Mycom.Tracker.Unity.Internal.Interfaces;
using UnityEngine.Purchasing;

namespace Mycom.Tracker.Unity
{
	[Token(Token = "0x2000004")]
	public static class MyTracker
	{
		[Token(Token = "0x4000007")]
		private static readonly ITracker Tracker = Mycom.Tracker.Unity.Internal.Implementations.Android.Tracker.Instance;

		[Token(Token = "0x4000008")]
		private static int State;

		[Token(Token = "0x17000001")]
		public static bool IsDebugMode
		{
			[Token(Token = "0x6000003")]
			[Address(RVA = "0x1622CD0", Offset = "0x1622CD0", Length = "0xDC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB1DA8]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202A30E]) = v35;\nL_0017:\n\tgoto L_001F;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Mycom.Tracker.Unity.MyTracker>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001F;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Mycom.Tracker.Unity.MyTracker;\nL_001F:\n\tv50 = v49.Tracker;\n\tv54 = *([v50 @ X19_v4 (Mycom.Tracker.Unity.Internal.Interfaces.ITracker)]);\n\tv58 = *([v54 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]) == 0;\n\tif (v58) goto L_0046;\n\tv112 = *([v54 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+B0]) + 8;\nL_0031:\n\tv118 = *([v112 @ X11_v5-8]) == Mycom.Tracker.Unity.Internal.Interfaces.ITracker;\n\tif (v118) goto L_0049;\n\tv113 = v113 + 1;\n\tv169 = v113 < *([v54 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]);\n\tv92 = ~v169;\n\tv112 = v112 + 0x10;\n\tv68 = ~v92;\n\tif (v68) goto L_0031;\nL_0046:\n\tv176 = 0x8909C4(v50, Mycom.Tracker.Unity.Internal.Interfaces.ITracker, 3, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tgoto L_004D;\nL_0049:\n\tv171 = *([v112 @ X11_v5]) + 3;\n\tv172 = v171 << 4;\n\tv173 = v54 + v172;\n\tv176 = v173 + 0x130;\nL_004D:\n\tv131 = *([v176 @ X0_v6]);\n\tv153 = *([v176 @ X0_v6+8]);\n\t// 84 IndirectJump v131 @ X2_v2, v50 @ X19_v4 (Mycom.Tracker.Unity.Internal.Interfaces.ITracker), v50 @ X19_v4 (Mycom.Tracker.Unity.Internal.Interfaces.ITracker), v153 @ X1_v2, v131 @ X2_v2, v19 @ X3, v20 @ X4, v21 @ X5, v22 @ X6, v23 @ X7, v24 @ V0, v25 @ V1, v26 @ V2, v27 @ V3, v28 @ V4, v29 @ V5, v30 @ V6, v31 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_000d: Expected I, but got O
				//IL_0150: Expected O, but got I
				//IL_0048: Expected O, but got I
				//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ca: Expected O, but got Unknown
				//IL_00e7: Expected O, but got I
				//IL_00f6: Expected O, but got I
				//IL_0094: Expected O, but got I
				ITracker tracker = Tracker;
				IntPtr intPtr = (IntPtr)tracker;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00ad;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ITracker))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00ad;
				}
				object obj2 = obj + 3;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_0138;
				IL_00ad:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_0138;
				IL_0138:
				object obj5 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ X0_v6+8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v131 @ X2_v2 (should have been resolved before IL gen)");
				return false;
			}
			[Token(Token = "0x6000004")]
			[Address(RVA = "0x1622DAC", Offset = "0x1622DAC", Length = "0xE4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB94C8]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A30F]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Mycom.Tracker.Unity.MyTracker>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = Mycom.Tracker.Unity.MyTracker;\nL_0021:\n\tv53 = v52.Tracker;\n\tv57 = *([v53 @ X20_v4 (Mycom.Tracker.Unity.Internal.Interfaces.ITracker)]);\n\tv61 = *([v57 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]) == 0;\n\tif (v61) goto L_0048;\n\tv115 = *([v57 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+B0]) + 8;\nL_0033:\n\tv121 = *([v115 @ X11_v5-8]) == Mycom.Tracker.Unity.Internal.Interfaces.ITracker;\n\tif (v121) goto L_004B;\n\tv116 = v116 + 1;\n\tv176 = v116 < *([v57 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]);\n\tv95 = ~v176;\n\tv115 = v115 + 0x10;\n\tv71 = ~v95;\n\tif (v71) goto L_0033;\nL_0048:\n\tv183 = 0x8909C4(v53, Mycom.Tracker.Unity.Internal.Interfaces.ITracker, 6, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_004F;\nL_004B:\n\tv178 = *([v115 @ X11_v5]) + 6;\n\tv179 = v178 << 4;\n\tv180 = v57 + v179;\n\tv183 = v180 + 0x130;\nL_004F:\n\tv129 = *([v183 @ X0_v6]);\n\tv136 = *([v183 @ X0_v6+8]);\n\t// 88 IndirectJump v129 @ X3_v1, v53 @ X20_v4 (Mycom.Tracker.Unity.Internal.Interfaces.ITracker), v53 @ X20_v4 (Mycom.Tracker.Unity.Internal.Interfaces.ITracker), value @ X0 (System.Boolean), v136 @ X2_v2, v129 @ X3_v1, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_000d: Expected I, but got O
				//IL_0150: Expected O, but got I
				//IL_0048: Expected O, but got I
				//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ca: Expected O, but got Unknown
				//IL_00e7: Expected O, but got I
				//IL_00f6: Expected O, but got I
				//IL_0094: Expected O, but got I
				ITracker tracker = Tracker;
				IntPtr intPtr = (IntPtr)tracker;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00ad;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ITracker))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00ad;
				}
				object obj2 = obj + 6;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_0138;
				IL_00ad:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_0138;
				IL_0138:
				object obj5 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ X0_v6+8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v129 @ X3_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x17000002")]
		public static bool IsEnabled
		{
			[Token(Token = "0x6000005")]
			[Address(RVA = "0x1622E90", Offset = "0x1622E90", Length = "0xDC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F0BB08]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202A310]) = v35;\nL_0017:\n\tgoto L_001F;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Mycom.Tracker.Unity.MyTracker>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001F;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Mycom.Tracker.Unity.MyTracker;\nL_001F:\n\tv50 = v49.Tracker;\n\tv54 = *([v50 @ X19_v4 (Mycom.Tracker.Unity.Internal.Interfaces.ITracker)]);\n\tv58 = *([v54 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]) == 0;\n\tif (v58) goto L_0046;\n\tv112 = *([v54 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+B0]) + 8;\nL_0031:\n\tv118 = *([v112 @ X11_v5-8]) == Mycom.Tracker.Unity.Internal.Interfaces.ITracker;\n\tif (v118) goto L_0049;\n\tv113 = v113 + 1;\n\tv169 = v113 < *([v54 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]);\n\tv92 = ~v169;\n\tv112 = v112 + 0x10;\n\tv68 = ~v92;\n\tif (v68) goto L_0031;\nL_0046:\n\tv176 = 0x8909C4(v50, Mycom.Tracker.Unity.Internal.Interfaces.ITracker, 4, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tgoto L_004D;\nL_0049:\n\tv171 = *([v112 @ X11_v5]) + 4;\n\tv172 = v171 << 4;\n\tv173 = v54 + v172;\n\tv176 = v173 + 0x130;\nL_004D:\n\tv131 = *([v176 @ X0_v6]);\n\tv153 = *([v176 @ X0_v6+8]);\n\t// 84 IndirectJump v131 @ X2_v2, v50 @ X19_v4 (Mycom.Tracker.Unity.Internal.Interfaces.ITracker), v50 @ X19_v4 (Mycom.Tracker.Unity.Internal.Interfaces.ITracker), v153 @ X1_v2, v131 @ X2_v2, v19 @ X3, v20 @ X4, v21 @ X5, v22 @ X6, v23 @ X7, v24 @ V0, v25 @ V1, v26 @ V2, v27 @ V3, v28 @ V4, v29 @ V5, v30 @ V6, v31 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_000d: Expected I, but got O
				//IL_0150: Expected O, but got I
				//IL_0048: Expected O, but got I
				//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ca: Expected O, but got Unknown
				//IL_00e7: Expected O, but got I
				//IL_00f6: Expected O, but got I
				//IL_0094: Expected O, but got I
				ITracker tracker = Tracker;
				IntPtr intPtr = (IntPtr)tracker;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00ad;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ITracker))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00ad;
				}
				object obj2 = obj + 4;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_0138;
				IL_00ad:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_0138;
				IL_0138:
				object obj5 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v176 @ X0_v6+8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v131 @ X2_v2 (should have been resolved before IL gen)");
				return false;
			}
			[Token(Token = "0x6000006")]
			[Address(RVA = "0x1622F6C", Offset = "0x1622F6C", Length = "0xE4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED8F10]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A311]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Mycom.Tracker.Unity.MyTracker>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = Mycom.Tracker.Unity.MyTracker;\nL_0021:\n\tv53 = v52.Tracker;\n\tv57 = *([v53 @ X20_v4 (Mycom.Tracker.Unity.Internal.Interfaces.ITracker)]);\n\tv61 = *([v57 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]) == 0;\n\tif (v61) goto L_0048;\n\tv115 = *([v57 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+B0]) + 8;\nL_0033:\n\tv121 = *([v115 @ X11_v5-8]) == Mycom.Tracker.Unity.Internal.Interfaces.ITracker;\n\tif (v121) goto L_004B;\n\tv116 = v116 + 1;\n\tv176 = v116 < *([v57 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]);\n\tv95 = ~v176;\n\tv115 = v115 + 0x10;\n\tv71 = ~v95;\n\tif (v71) goto L_0033;\nL_0048:\n\tv183 = 0x8909C4(v53, Mycom.Tracker.Unity.Internal.Interfaces.ITracker, 7, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_004F;\nL_004B:\n\tv178 = *([v115 @ X11_v5]) + 7;\n\tv179 = v178 << 4;\n\tv180 = v57 + v179;\n\tv183 = v180 + 0x130;\nL_004F:\n\tv129 = *([v183 @ X0_v6]);\n\tv136 = *([v183 @ X0_v6+8]);\n\t// 88 IndirectJump v129 @ X3_v1, v53 @ X20_v4 (Mycom.Tracker.Unity.Internal.Interfaces.ITracker), v53 @ X20_v4 (Mycom.Tracker.Unity.Internal.Interfaces.ITracker), value @ X0 (System.Boolean), v136 @ X2_v2, v129 @ X3_v1, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_000d: Expected I, but got O
				//IL_0150: Expected O, but got I
				//IL_0048: Expected O, but got I
				//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
				//IL_00ca: Expected O, but got Unknown
				//IL_00e7: Expected O, but got I
				//IL_00f6: Expected O, but got I
				//IL_0094: Expected O, but got I
				ITracker tracker = Tracker;
				IntPtr intPtr = (IntPtr)tracker;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00ad;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ITracker))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00ad;
				}
				object obj2 = obj + 7;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_0138;
				IL_00ad:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_0138;
				IL_0138:
				object obj5 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ X0_v6+8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v129 @ X3_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x17000003")]
		public static MyTrackerParams MyTrackerParams
		{
			[Token(Token = "0x6000007")]
			[Address(RVA = "0x1623050", Offset = "0x1623050", Length = "0xD8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EF9718]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202A312]) = v35;\nL_0017:\n\tgoto L_0028;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Mycom.Tracker.Unity.MyTracker>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\t// 27 Jump @b17\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Mycom.Tracker.Unity.MyTracker;\nL_0028:\n\tgoto L_0053;\n\tv61 = *([v54 @ X8_v6+B0]);\n\tv62 = 0;\n\tv63 = v61 + 8;\n\tv65 = *([v112 @ X11_v5-8]);\n\tv118 = v65 == v57;\n\tif (v118) goto L_0048;\n\tv98 = v113 + 1;\n\tv169 = v98 < v56;\n\tv92 = ~v169;\n\tv95 = v112 + 0x10;\n\tv68 = ~v92;\n\tif (v68) goto L_FFFFFFFF;\n\tv99 = v50;\n\tv100 = 0;\n\tv101 = 0x8909C4(v99, v57, v100, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tgoto L_0053;\nL_0048:\n\tv170 = *([v112 @ X11_v5]);\n\tv171 = v170 << 4;\n\tv172 = v54 + v171;\n\tv173 = v172 + 0x130;\nL_0053:\n\tinterfaceTailCallResult = Mycom.Tracker.Unity.Internal.Interfaces.ITracker::get_MyTrackerParams(v49.Tracker);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Tracker.MyTrackerParams;
			}
		}

		[Token(Token = "0x6000008")]
		[Address(RVA = "0x1623128", Offset = "0x1623128", Length = "0x20C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EB7BF8]);\n\tv21 = *([v20 @ X8_v38]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A313]) = v40;\nL_001A:\n\tgoto L_0025;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<Mycom.Tracker.Unity.MyTracker>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0025;\n\tv60 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = Mycom.Tracker.Unity.MyTracker;\nL_0025:\n\tv58 = v50.Tracker + 8;\n\tv59 = System.Threading.Interlocked::CompareExchange(v58, 1, 0);\n\tv61 = v59 == 0;\n\tif (v61) goto L_003A;\n\tgoto L_FFFFFFFF;\n\tv71 = *([v64 @ X0_v34+E0]);\n\tv72 = v71 == 0;\n\tv73 = ~v72;\n\tif (v73) goto L_FFFFFFFF;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v64, v55, v56, v57, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_0053;\nL_003A:\n\tv70 = System.String::IsNullOrEmpty(id);\n\tv81 = v70 == 0;\n\tif (v81) goto L_005B;\n\tgoto L_FFFFFFFF;\n\tv107 = *([v97 @ X0_v31+E0]);\n\tv108 = v107 == 0;\n\tv109 = ~v108;\n\tif (v109) goto L_FFFFFFFF;\n\tv110 = \"il2cpp_codegen_runtime_class_init\"(v97, v69, v56, v57, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0053:\n\tMycom.Tracker.Unity.LibraryLogger::Log(*([v87 @ X8_v6 (System.String)]));\n\treturn;\nL_005B:\n\tgoto L_0068;\n\tv113 = *([v103 @ X0_v10 (Il2CppClass<Mycom.Tracker.Unity.SDKVersion>)+E0]);\n\tv114 = v113 == 0;\n\tv115 = ~v114;\n\tif (v115) goto L_0068;\n\tv196 = \"il2cpp_codegen_runtime_class_init\"(v103, v69, v56, v57, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv117 = Mycom.Tracker.Unity.SDKVersion;\nL_0068:\n\tv126 = System.String::Concat(\"MyTracker unity package version \", v121.Version);\n\tgoto L_0078;\n\tv204 = *([v200 @ X8_v12+E0]);\n\tv205 = v204 == 0;\n\tv206 = ~v205;\n\tgoto L_0078;\n\tv211 = v200;\n\tv208 = \"il2cpp_codegen_runtime_class_init\"(v211, v124, v123, v57, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0078:\n\tMycom.Tracker.Unity.LibraryLogger::Log(v126);\n\tgoto L_0085;\n\tv216 = *([v212 @ X0_v16 (Il2CppClass<Mycom.Tracker.Unity.MyTracker>)+E0]);\n\tv217 = v216 == 0;\n\tv218 = ~v217;\n\tif (v218) goto L_0085;\n\tv223 = \"il2cpp_codegen_runtime_class_init\"(v212, v124, v123, v57, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv220 = Mycom.Tracker.Unity.MyTracker;\nL_0085:\n\tv193 = v190.Tracker;\n\tv225 = *([v193 @ X20_v6 (Mycom.Tracker.Unity.Internal.Interfaces.ITracker)]);\n\tv184 = *([v225 @ X8_v16 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]) == 0;\n\tif (v184) goto L_00AC;\n\tv270 = *([v225 @ X8_v16 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+B0]) + 8;\nL_0097:\n\tv276 = *([v270 @ X11_v5-8]) == Mycom.Tracker.Unity.Internal.Interfaces.ITracker;\n\tif (v276) goto L_00AF;\n\tv271 = v271 + 1;\n\tv281 = v271 < *([v225 @ X8_v16 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]);\n\tv252 = ~v281;\n\tv270 = v270 + 0x10;\n\tv236 = ~v252;\n\tif (v236) goto L_0097;\nL_00AC:\n\tv288 = 0x8909C4(v193, Mycom.Tracker.Unity.Internal.Interfaces.ITracker, 1, 0, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tgoto L_00B3;\nL_00AF:\n\tv283 = *([v270 @ X11_v5]) + 1;\n\tv284 = v283 << 4;\n\tv285 = v225 + v284;\n\tv288 = v285 + 0x130;\nL_00B3:\n\tv133 = *([v288 @ X0_v20]);\n\tv140 = *([v288 @ X0_v20+8]);\n\t// 189 IndirectJump v133 @ X3_v2, v193 @ X20_v6 (Mycom.Tracker.Unity.Internal.Interfaces.ITracker), v193 @ X20_v6 (Mycom.Tracker.Unity.Internal.Interfaces.ITracker), id @ X0 (System.String), v140 @ X2_v4, v133 @ X3_v2, v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 111 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static void Create(string id)
		{
			//IL_0072: Expected I, but got O
			//IL_021b: Expected O, but got I
			//IL_00ad: Expected O, but got I
			//IL_012a: Unknown result type (might be due to invalid IL or missing references)
			//IL_012f: Expected O, but got Unknown
			//IL_014c: Expected O, but got I
			//IL_015b: Expected O, but got I
			//IL_00f9: Expected O, but got I
			string message;
			object obj4 = default(object);
			if (Interlocked.CompareExchange(ref *(int*)((long)(IntPtr)Tracker + 8L), 1, 0) != 0)
			{
				message = "MyTracker has been already created";
			}
			else
			{
				if (!string.IsNullOrEmpty(id))
				{
					string message2 = "MyTracker unity package version " + SDKVersion.Version;
					LibraryLogger.Log(message2);
					ITracker tracker = Tracker;
					IntPtr intPtr = (IntPtr)tracker;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ X8_v16 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_0112;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ X8_v16 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+B0]");
					object obj = 0L + 8L;
					int num = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v270 @ X11_v5-8]");
						if ((IntPtr)0 == (IntPtr)typeof(ITracker))
						{
							break;
						}
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ X8_v16 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]");
						bool flag = (long)num2 < 0L;
						bool flag2 = !flag;
						obj = (long)(IntPtr)obj + 16L;
						if (!flag2)
						{
							continue;
						}
						goto IL_0112;
					}
					object obj2 = obj + 1;
					int num3 = (int)((long)(IntPtr)obj2 << 4);
					object obj3 = (long)intPtr + (long)num3;
					obj4 = (long)(IntPtr)obj3 + 304L;
					goto IL_0203;
				}
				message = "id parameter is null";
			}
			LibraryLogger.Log(message);
			return;
			IL_0203:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v288 @ X0_v20+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v133 @ X3_v2 (should have been resolved before IL gen)");
			return;
			IL_0112:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0203;
		}

		[Token(Token = "0x6000009")]
		[Address(RVA = "0x1623334", Offset = "0x1623334", Length = "0x150")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1ECDD00]);\n\tv15 = *([v14 @ X8_v23]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202A314]) = v35;\nL_0017:\n\tgoto L_0022;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Mycom.Tracker.Unity.MyTracker>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0022;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Mycom.Tracker.Unity.MyTracker;\nL_0022:\n\tv53 = v45.Tracker + 8;\n\tv54 = System.Threading.Interlocked::CompareExchange(v53, 2, 1);\n\tv65 = v54 != 1;\n\tif (v65) goto L_006A;\n\tgoto L_003B;\n\tv76 = *([v66 @ X0_v10 (Il2CppClass<Mycom.Tracker.Unity.MyTracker>)+E0]);\n\tv77 = v76 == 0;\n\tv78 = ~v77;\n\tif (v78) goto L_003B;\n\tv99 = \"il2cpp_codegen_runtime_class_init\"(v66, v50, v51, v52, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv80 = Mycom.Tracker.Unity.MyTracker;\nL_003B:\n\tv84 = v83.Tracker;\n\tv101 = *([v84 @ X19_v5 (Mycom.Tracker.Unity.Internal.Interfaces.ITracker)]);\n\tv105 = *([v101 @ X8_v16 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]) == 0;\n\tif (v105) goto L_0062;\n\tv187 = *([v101 @ X8_v16 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+B0]) + 8;\nL_004D:\n\tv202 = *([v187 @ X11_v5-8]) == Mycom.Tracker.Unity.Internal.Interfaces.ITracker;\n\tif (v202) goto L_007A;\n\tv188 = v188 + 1;\n\tv207 = v188 < *([v101 @ X8_v16 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]);\n\tv136 = ~v207;\n\tv187 = v187 + 0x10;\n\tv120 = ~v136;\n\tif (v120) goto L_004D;\nL_0062:\n\tv214 = 0x8909C4(v84, Mycom.Tracker.Unity.Internal.Interfaces.ITracker, 2, 0, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tgoto L_007E;\nL_006A:\n\tgoto L_0077;\n\tv86 = *([v72 @ X0_v6+E0]);\n\tv87 = v86 == 0;\n\tv88 = ~v87;\n\tif (v88) goto L_0077;\n\tv90 = \"il2cpp_codegen_runtime_class_init\"(v72, v50, v51, v52, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0077:\n\tMycom.Tracker.Unity.LibraryLogger::Log(\"MyTracker has been already initialized\");\n\treturn;\nL_007A:\n\tv209 = *([v187 @ X11_v5]) + 2;\n\tv210 = v209 << 4;\n\tv211 = v101 + v210;\n\tv214 = v211 + 0x130;\nL_007E:\n\tv148 = *([v214 @ X0_v14]);\n\tv152 = *([v214 @ X0_v14+8]);\n\t// 133 IndirectJump v148 @ X2_v3, v84 @ X19_v5 (Mycom.Tracker.Unity.Internal.Interfaces.ITracker), v84 @ X19_v5 (Mycom.Tracker.Unity.Internal.Interfaces.ITracker), v152 @ X1_v3, v148 @ X2_v3, 0, v20 @ X4, v21 @ X5, v22 @ X6, v23 @ X7, v24 @ V0, v25 @ V1, v26 @ V2, v27 @ V3, v28 @ V4, v29 @ V5, v30 @ V6, v31 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static void Init()
		{
			//IL_0012: Expected I, but got O
			//IL_01ac: Expected O, but got I
			//IL_004d: Expected O, but got I
			//IL_00da: Unknown result type (might be due to invalid IL or missing references)
			//IL_00df: Expected O, but got Unknown
			//IL_00fc: Expected O, but got I
			//IL_010b: Expected O, but got I
			//IL_0099: Expected O, but got I
			int num = Interlocked.CompareExchange(ref *(int*)((long)(IntPtr)Tracker + 8L), 2, 1);
			if (num != 1)
			{
				LibraryLogger.Log("MyTracker has been already initialized");
				return;
			}
			ITracker tracker = Tracker;
			IntPtr intPtr = (IntPtr)tracker;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ X8_v16 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00b2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ X8_v16 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+B0]");
			object obj = 0L + 8L;
			int num2 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ITracker))
				{
					break;
				}
				num2++;
				int num3 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ X8_v16 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]");
				bool flag = (long)num3 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00b2;
			}
			object obj2 = obj + 2;
			int num4 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num4;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0194;
			IL_0194:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v214 @ X0_v14+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v148 @ X2_v3 (should have been resolved before IL gen)");
			return;
			IL_00b2:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0194;
		}

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x1623484", Offset = "0x1623484", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EA7EB0]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A315]) = v38;\nL_0019:\n\tgoto L_002A;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Mycom.Tracker.Unity.MyTracker>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\t// 29 Jump @b17\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = Mycom.Tracker.Unity.MyTracker;\nL_002A:\n\tgoto L_0058;\n\tv64 = *([v57 @ X8_v6+B0]);\n\tv65 = 0;\n\tv66 = v64 + 8;\n\tv68 = *([v115 @ X11_v5-8]);\n\tv121 = v68 == v60;\n\tif (v121) goto L_004A;\n\tv101 = v116 + 1;\n\tv176 = v101 < v59;\n\tv95 = ~v176;\n\tv98 = v115 + 0x10;\n\tv71 = ~v95;\n\tif (v71) goto L_FFFFFFFF;\n\tv102 = 5;\n\tv103 = v53;\n\tv104 = 0x8909C4(v103, v60, v102, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0058;\nL_004A:\n\tv177 = *([v115 @ X11_v5]);\n\tv178 = v177 + 5;\n\tv179 = v178 << 4;\n\tv180 = v57 + v179;\n\tv181 = v180 + 0x130;\nL_0058:\n\tMycom.Tracker.Unity.Internal.Interfaces.ITracker::SetAttributionListener(v52.Tracker, listener);\n\tthrow System.NullReferenceException;\n\treturn;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetAttributionListener(Action<MyTrackerAttribution> listener)
		{
			Tracker.SetAttributionListener(listener);
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x1623568", Offset = "0x1623568", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EB4008]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, eventParams, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A316]) = v41;\nL_0017:\n\tv44 = System.String::IsNullOrEmpty(name);\n\tv46 = v44 == 0;\n\tif (v46) goto L_0029;\n\treturn 0;\nL_0029:\n\tgoto L_0031;\n\tv129 = *([v55 @ X0_v4 (Il2CppClass<Mycom.Tracker.Unity.MyTracker>)+E0]);\n\tv130 = v129 == 0;\n\tv131 = ~v130;\n\tif (v131) goto L_0031;\n\tv136 = \"il2cpp_codegen_runtime_class_init\"(v55, v43, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv133 = Mycom.Tracker.Unity.MyTracker;\nL_0031:\n\tv126 = v123.Tracker;\n\tv138 = *([v126 @ X21_v4 (Mycom.Tracker.Unity.Internal.Interfaces.ITracker)]);\n\tv115 = *([v138 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]) == 0;\n\tif (v115) goto L_0058;\n\tv183 = *([v138 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+B0]) + 8;\nL_0043:\n\tv189 = *([v183 @ X11_v5-8]) == Mycom.Tracker.Unity.Internal.Interfaces.ITracker;\n\tif (v189) goto L_005B;\n\tv184 = v184 + 1;\n\tv194 = v184 < *([v138 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]);\n\tv165 = ~v194;\n\tv183 = v183 + 0x10;\n\tv149 = ~v165;\n\tif (v149) goto L_0043;\nL_0058:\n\tv201 = 0x8909C4(v126, Mycom.Tracker.Unity.Internal.Interfaces.ITracker, 8, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_005F;\nL_005B:\n\tv196 = *([v183 @ X11_v5]) + 8;\n\tv197 = v196 << 4;\n\tv198 = v138 + v197;\n\tv201 = v198 + 0x130;\nL_005F:\n\tv62 = *([v201 @ X0_v8]);\n\tv60 = *([v201 @ X0_v8+8]);\n\t// 106 IndirectJump v62 @ X4_v1, v126 @ X21_v4 (Mycom.Tracker.Unity.Internal.Interfaces.ITracker), v126 @ X21_v4 (Mycom.Tracker.Unity.Internal.Interfaces.ITracker), name @ X0 (System.String), eventParams @ X1 (System.Collections.Generic.IDictionary`2<System.String, System.String>), v60 @ X3_v1, v62 @ X4_v1, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool TrackEvent(string name, IDictionary<string, string> eventParams = null)
		{
			//IL_0018: Expected I, but got O
			//IL_0180: Expected O, but got I
			//IL_0053: Expected O, but got I
			//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d5: Expected O, but got Unknown
			//IL_00f2: Expected O, but got I
			//IL_0101: Expected O, but got I
			//IL_009f: Expected O, but got I
			if (string.IsNullOrEmpty(name))
			{
				return false;
			}
			ITracker tracker = Tracker;
			IntPtr intPtr = (IntPtr)tracker;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00b8;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ITracker))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00b8;
			}
			object obj2 = obj + 8;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0168;
			IL_0168:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ X0_v8+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v62 @ X4_v1 (should have been resolved before IL gen)");
			return false;
			IL_00b8:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0168;
		}

		[Token(Token = "0x600000C")]
		[Address(RVA = "0x1623680", Offset = "0x1623680", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F0E6F0]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A317]) = v38;\nL_0019:\n\tgoto L_002A;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Mycom.Tracker.Unity.MyTracker>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\t// 29 Jump @b17\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = Mycom.Tracker.Unity.MyTracker;\nL_002A:\n\tgoto L_0058;\n\tv64 = *([v57 @ X8_v6+B0]);\n\tv65 = 0;\n\tv66 = v64 + 8;\n\tv68 = *([v115 @ X11_v5-8]);\n\tv121 = v68 == v60;\n\tif (v121) goto L_004A;\n\tv101 = v116 + 1;\n\tv176 = v101 < v59;\n\tv95 = ~v176;\n\tv98 = v115 + 0x10;\n\tv71 = ~v95;\n\tif (v71) goto L_FFFFFFFF;\n\tv102 = 9;\n\tv103 = v53;\n\tv104 = 0x8909C4(v103, v60, v102, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0058;\nL_004A:\n\tv177 = *([v115 @ X11_v5]);\n\tv178 = v177 + 9;\n\tv179 = v178 << 4;\n\tv180 = v57 + v179;\n\tv181 = v180 + 0x130;\nL_0058:\n\tinterfaceTailCallResult = Mycom.Tracker.Unity.Internal.Interfaces.ITracker::TrackInviteEvent(v52.Tracker, eventParams);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool TrackInviteEvent(IDictionary<string, string> eventParams = null)
		{
			return Tracker.TrackInviteEvent(eventParams);
		}

		[Token(Token = "0x600000D")]
		[Address(RVA = "0x1623764", Offset = "0x1623764", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1F0C468]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, eventParams, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A318]) = v41;\nL_001B:\n\tgoto L_002C;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<Mycom.Tracker.Unity.MyTracker>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\t// 31 Jump @b17\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v44, eventParams, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv52 = Mycom.Tracker.Unity.MyTracker;\nL_002C:\n\tgoto L_005C;\n\tv67 = *([v60 @ X8_v6+B0]);\n\tv68 = 0;\n\tv69 = v67 + 8;\n\tv71 = *([v118 @ X11_v5-8]);\n\tv124 = v71 == v63;\n\tif (v124) goto L_004C;\n\tv104 = v119 + 1;\n\tv183 = v104 < v62;\n\tv98 = ~v183;\n\tv101 = v118 + 0x10;\n\tv74 = ~v98;\n\tif (v74) goto L_FFFFFFFF;\n\tv105 = 0xA;\n\tv106 = v56;\n\tv107 = 0x8909C4(v106, v63, v105, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_005C;\nL_004C:\n\tv184 = *([v118 @ X11_v5]);\n\tv185 = v184 + 0xA;\n\tv186 = v185 << 4;\n\tv187 = v60 + v186;\n\tv188 = v187 + 0x130;\nL_005C:\n\tinterfaceTailCallResult = Mycom.Tracker.Unity.Internal.Interfaces.ITracker::TrackLevelEvent(v55.Tracker, level, eventParams);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool TrackLevelEvent(int? level = null, IDictionary<string, string> eventParams = null)
		{
			return Tracker.TrackLevelEvent(level, eventParams);
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0x1623858", Offset = "0x1623858", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1ED97A0]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A319]) = v38;\nL_0019:\n\tgoto L_002A;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Mycom.Tracker.Unity.MyTracker>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\t// 29 Jump @b17\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = Mycom.Tracker.Unity.MyTracker;\nL_002A:\n\tgoto L_0058;\n\tv64 = *([v57 @ X8_v6+B0]);\n\tv65 = 0;\n\tv66 = v64 + 8;\n\tv68 = *([v115 @ X11_v5-8]);\n\tv121 = v68 == v60;\n\tif (v121) goto L_004A;\n\tv101 = v116 + 1;\n\tv176 = v101 < v59;\n\tv95 = ~v176;\n\tv98 = v115 + 0x10;\n\tv71 = ~v95;\n\tif (v71) goto L_FFFFFFFF;\n\tv102 = 0xB;\n\tv103 = v53;\n\tv104 = 0x8909C4(v103, v60, v102, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0058;\nL_004A:\n\tv177 = *([v115 @ X11_v5]);\n\tv178 = v177 + 0xB;\n\tv179 = v178 << 4;\n\tv180 = v57 + v179;\n\tv181 = v180 + 0x130;\nL_0058:\n\tinterfaceTailCallResult = Mycom.Tracker.Unity.Internal.Interfaces.ITracker::TrackLoginEvent(v52.Tracker, eventParams);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool TrackLoginEvent(IDictionary<string, string> eventParams = null)
		{
			return Tracker.TrackLoginEvent(eventParams);
		}

		[Token(Token = "0x600000F")]
		[Address(RVA = "0x162393C", Offset = "0x162393C", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EB4B78]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A31A]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<Mycom.Tracker.Unity.MyTracker>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv55 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = Mycom.Tracker.Unity.MyTracker;\nL_0021:\n\tv53 = v52.Tracker;\n\tv57 = *([v53 @ X20_v4 (Mycom.Tracker.Unity.Internal.Interfaces.ITracker)]);\n\tv61 = *([v57 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]) == 0;\n\tif (v61) goto L_0048;\n\tv115 = *([v57 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+B0]) + 8;\nL_0033:\n\tv121 = *([v115 @ X11_v5-8]) == Mycom.Tracker.Unity.Internal.Interfaces.ITracker;\n\tif (v121) goto L_004B;\n\tv116 = v116 + 1;\n\tv176 = v116 < *([v57 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]);\n\tv95 = ~v176;\n\tv115 = v115 + 0x10;\n\tv71 = ~v95;\n\tif (v71) goto L_0033;\nL_0048:\n\tv183 = 0x8909C4(v53, Mycom.Tracker.Unity.Internal.Interfaces.ITracker, 0xC, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_004F;\nL_004B:\n\tv178 = *([v115 @ X11_v5]) + 0xC;\n\tv179 = v178 << 4;\n\tv180 = v57 + v179;\n\tv183 = v180 + 0x130;\nL_004F:\n\tv129 = *([v183 @ X0_v6]);\n\tv136 = *([v183 @ X0_v6+8]);\n\t// 88 IndirectJump v129 @ X3_v1, v53 @ X20_v4 (Mycom.Tracker.Unity.Internal.Interfaces.ITracker), v53 @ X20_v4 (Mycom.Tracker.Unity.Internal.Interfaces.ITracker), eventParams @ X0 (System.Collections.Generic.IDictionary`2<System.String, System.String>), v136 @ X2_v2, v129 @ X3_v1, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool TrackRegistrationEvent(IDictionary<string, string> eventParams = null)
		{
			//IL_000d: Expected I, but got O
			//IL_0150: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Expected O, but got Unknown
			//IL_00e7: Expected O, but got I
			//IL_00f6: Expected O, but got I
			//IL_0094: Expected O, but got I
			ITracker tracker = Tracker;
			IntPtr intPtr = (IntPtr)tracker;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ITracker))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 12;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0138;
			IL_00ad:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0138;
			IL_0138:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ X0_v6+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v129 @ X3_v1 (should have been resolved before IL gen)");
			return false;
		}

		[Token(Token = "0x6000010")]
		[Address(RVA = "0x1623A20", Offset = "0x1623A20", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EA7A38]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202A31B]) = v35;\nL_0017:\n\tgoto L_0028;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<Mycom.Tracker.Unity.MyTracker>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\t// 27 Jump @b17\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = Mycom.Tracker.Unity.MyTracker;\nL_0028:\n\tgoto L_0054;\n\tv61 = *([v54 @ X8_v6+B0]);\n\tv62 = 0;\n\tv63 = v61 + 8;\n\tv65 = *([v112 @ X11_v5-8]);\n\tv118 = v65 == v57;\n\tif (v118) goto L_0048;\n\tv98 = v113 + 1;\n\tv169 = v98 < v56;\n\tv92 = ~v169;\n\tv95 = v112 + 0x10;\n\tv68 = ~v92;\n\tif (v68) goto L_FFFFFFFF;\n\tv99 = 0xD;\n\tv100 = v50;\n\tv101 = 0x8909C4(v100, v57, v99, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tgoto L_0054;\nL_0048:\n\tv170 = *([v112 @ X11_v5]);\n\tv171 = v170 + 0xD;\n\tv172 = v171 << 4;\n\tv173 = v54 + v172;\n\tv174 = v173 + 0x130;\nL_0054:\n\tinterfaceTailCallResult = Mycom.Tracker.Unity.Internal.Interfaces.ITracker::Flush(v49.Tracker);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool Flush()
		{
			return Tracker.Flush();
		}

		[Token(Token = "0x6000011")]
		[Address(RVA = "0x1623AFC", Offset = "0x1623AFC", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = *([1EE8DC0]);\n\tv31 = *([v30 @ X8_v12]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, purchaseData, dataSignature, eventParams, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([202A31C]) = v47;\nL_001F:\n\tgoto L_0027;\n\tv54 = *([v50 @ X0_v2 (Il2CppClass<Mycom.Tracker.Unity.MyTracker>)+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0027;\n\tv64 = \"il2cpp_codegen_runtime_class_init\"(v50, purchaseData, dataSignature, eventParams, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv58 = Mycom.Tracker.Unity.MyTracker;\nL_0027:\n\tv62 = v61.Tracker;\n\tv66 = *([v62 @ X23_v4 (Mycom.Tracker.Unity.Internal.Interfaces.ITracker)]);\n\tv70 = *([v66 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]) == 0;\n\tif (v70) goto L_004E;\n\tv124 = *([v66 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+B0]) + 8;\nL_0039:\n\tv130 = *([v124 @ X11_v5-8]) == Mycom.Tracker.Unity.Internal.Interfaces.ITracker;\n\tif (v130) goto L_0051;\n\tv125 = v125 + 1;\n\tv197 = v125 < *([v66 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]);\n\tv104 = ~v197;\n\tv124 = v124 + 0x10;\n\tv80 = ~v104;\n\tif (v80) goto L_0039;\nL_004E:\n\tv204 = 0x8909C4(v62, Mycom.Tracker.Unity.Internal.Interfaces.ITracker, 0xE, eventParams, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_0055;\nL_0051:\n\tv199 = *([v124 @ X11_v5]) + 0xE;\n\tv200 = v199 << 4;\n\tv201 = v66 + v200;\n\tv204 = v201 + 0x130;\nL_0055:\n\tv144 = *([v204 @ X0_v6]);\n\tv142 = *([v204 @ X0_v6+8]);\n\t// 100 IndirectJump v144 @ X6_v1, v62 @ X23_v4 (Mycom.Tracker.Unity.Internal.Interfaces.ITracker), v62 @ X23_v4 (Mycom.Tracker.Unity.Internal.Interfaces.ITracker), skuDetails @ X0 (System.String), purchaseData @ X1 (System.String), dataSignature @ X2 (System.String), eventParams @ X3 (System.Collections.Generic.IDictionary`2<System.String, System.String>), v142 @ X5_v1, v144 @ X6_v1, v36 @ X7, v37 @ V0, v38 @ V1, v39 @ V2, v40 @ V3, v41 @ V4, v42 @ V5, v43 @ V6, v44 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool TrackPurchaseEvent(string skuDetails, string purchaseData, string dataSignature, IDictionary<string, string> eventParams = null)
		{
			//IL_000d: Expected I, but got O
			//IL_0150: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Expected O, but got Unknown
			//IL_00e7: Expected O, but got I
			//IL_00f6: Expected O, but got I
			//IL_0094: Expected O, but got I
			ITracker tracker = Tracker;
			IntPtr intPtr = (IntPtr)tracker;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ITracker))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 14;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0138;
			IL_00ad:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0138;
			IL_0138:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v204 @ X0_v6+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v144 @ X6_v1 (should have been resolved before IL gen)");
			return false;
		}

		[Token(Token = "0x6000012")]
		[Address(RVA = "0x1623C08", Offset = "0x1623C08", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1ED1F70]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, eventParams, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A31D]) = v41;\nL_001B:\n\tgoto L_0023;\n\tv48 = *([v44 @ X0_v2 (Il2CppClass<Mycom.Tracker.Unity.MyTracker>)+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0023;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v44, eventParams, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv52 = Mycom.Tracker.Unity.MyTracker;\nL_0023:\n\tv56 = v55.Tracker;\n\tv60 = *([v56 @ X21_v4 (Mycom.Tracker.Unity.Internal.Interfaces.ITracker)]);\n\tv64 = *([v60 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]) == 0;\n\tif (v64) goto L_004A;\n\tv118 = *([v60 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+B0]) + 8;\nL_0035:\n\tv124 = *([v118 @ X11_v5-8]) == Mycom.Tracker.Unity.Internal.Interfaces.ITracker;\n\tif (v124) goto L_004D;\n\tv119 = v119 + 1;\n\tv183 = v119 < *([v60 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]);\n\tv98 = ~v183;\n\tv118 = v118 + 0x10;\n\tv74 = ~v98;\n\tif (v74) goto L_0035;\nL_004A:\n\tv190 = 0x8909C4(v56, Mycom.Tracker.Unity.Internal.Interfaces.ITracker, 0xF, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0051;\nL_004D:\n\tv185 = *([v118 @ X11_v5]) + 0xF;\n\tv186 = v185 << 4;\n\tv187 = v60 + v186;\n\tv190 = v187 + 0x130;\nL_0051:\n\tv134 = *([v190 @ X0_v6]);\n\tv132 = *([v190 @ X0_v6+8]);\n\t// 92 IndirectJump v134 @ X4_v1, v56 @ X21_v4 (Mycom.Tracker.Unity.Internal.Interfaces.ITracker), v56 @ X21_v4 (Mycom.Tracker.Unity.Internal.Interfaces.ITracker), product @ X0 (UnityEngine.Purchasing.Product), eventParams @ X1 (System.Collections.Generic.IDictionary`2<System.String, System.String>), v132 @ X3_v1, v134 @ X4_v1, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool TrackPurchaseEvent(Product product, IDictionary<string, string> eventParams = null)
		{
			//IL_000d: Expected I, but got O
			//IL_0150: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ca: Expected O, but got Unknown
			//IL_00e7: Expected O, but got I
			//IL_00f6: Expected O, but got I
			//IL_0094: Expected O, but got I
			ITracker tracker = Tracker;
			IntPtr intPtr = (IntPtr)tracker;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ITracker))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ X8_v6 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITracker>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 15;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0138;
			IL_00ad:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0138;
			IL_0138:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v190 @ X0_v6+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v134 @ X4_v1 (should have been resolved before IL gen)");
			return false;
		}
	}
}
