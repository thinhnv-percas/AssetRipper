using System;
using System.Collections.Generic;
using System.Linq;
using AssetRipperInjected;
using Cpp2ILInjected;
using Mycom.Tracker.Unity.Internal.Interfaces;

namespace Mycom.Tracker.Unity
{
	[Token(Token = "0x2000006")]
	public sealed class MyTrackerParams
	{
		[Token(Token = "0x400000A")]
		[FieldOffset(Offset = "0x10")]
		internal readonly ITrackerParams _trackerParams;

		[Token(Token = "0x17000005")]
		public int Age
		{
			[Token(Token = "0x6000017")]
			[Address(RVA = "0x1623DAC", Offset = "0x1623DAC", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EB9ED8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A31F]) = v38;\nL_001C:\n\tgoto L_0048;\n\tv49 = *([v42 @ X8_v3+B0]);\n\tv50 = 0;\n\tv51 = v49 + 8;\n\tv53 = *([v100 @ X11_v5-8]);\n\tv106 = v53 == v45;\n\tif (v106) goto L_003C;\n\tv86 = v101 + 1;\n\tv159 = v86 < v44;\n\tv80 = ~v159;\n\tv83 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_FFFFFFFF;\n\tv87 = v39;\n\tv88 = 0;\n\tv89 = 0x8909C4(v87, v45, v88, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0048;\nL_003C:\n\tv160 = *([v100 @ X11_v5]);\n\tv161 = v160 << 4;\n\tv162 = v42 + v161;\n\tv163 = v162 + 0x130;\nL_0048:\n\tinterfaceTailCallResult = Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams::GetAge(this._trackerParams);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return _trackerParams.GetAge();
			}
			[Token(Token = "0x6000018")]
			[Address(RVA = "0x1623E60", Offset = "0x1623E60", Length = "0xC8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1ED7040]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A320]) = v41;\nL_001E:\n\tgoto L_004D;\n\tv52 = *([v45 @ X8_v3+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v103 @ X11_v5-8]);\n\tv109 = v56 == v48;\n\tif (v109) goto L_003E;\n\tv89 = v104 + 1;\n\tv166 = v89 < v47;\n\tv83 = ~v166;\n\tv86 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = 0x13;\n\tv91 = v42;\n\tv92 = 0x8909C4(v91, v48, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004D;\nL_003E:\n\tv167 = *([v103 @ X11_v5]);\n\tv168 = v167 + 0x13;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv171 = v170 + 0x130;\nL_004D:\n\tMycom.Tracker.Unity.Internal.Interfaces.ITrackerParams::SetAge(this._trackerParams, value);\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_trackerParams.SetAge(value);
			}
		}

		[Token(Token = "0x17000006")]
		public int BufferingPeriod
		{
			[Token(Token = "0x6000019")]
			[Address(RVA = "0x1623F28", Offset = "0x1623F28", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EF30C0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A321]) = v38;\nL_0013:\n\tv39 = this._trackerParams;\n\tv42 = *([v39 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams)]);\n\tv46 = *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]) == 0;\n\tif (v46) goto L_003A;\n\tv100 = *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]) + 8;\nL_0025:\n\tv106 = *([v100 @ X11_v5-8]) == Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams;\n\tif (v106) goto L_003D;\n\tv101 = v101 + 1;\n\tv159 = v101 < *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]);\n\tv80 = ~v159;\n\tv100 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_0025;\nL_003A:\n\tv166 = 0x8909C4(v39, Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams, 1, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0041;\nL_003D:\n\tv161 = *([v100 @ X11_v5]) + 1;\n\tv162 = v161 << 4;\n\tv163 = v42 + v162;\n\tv166 = v163 + 0x130;\nL_0041:\n\tv119 = *([v166 @ X0_v4]);\n\tv141 = *([v166 @ X0_v4+8]);\n\t// 73 IndirectJump v119 @ X2_v2, v39 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), v39 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), v141 @ X1_v2, v119 @ X2_v2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_000d: Expected I, but got O
				//IL_0151: Expected O, but got I
				//IL_0048: Expected O, but got I
				//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
				//IL_00cf: Expected O, but got Unknown
				//IL_00ec: Expected O, but got I
				//IL_00fb: Expected O, but got I
				//IL_0094: Expected O, but got I
				ITrackerParams trackerParams = _trackerParams;
				IntPtr intPtr = (IntPtr)trackerParams;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00ad;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ITrackerParams))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00ad;
				}
				object obj2 = obj + 1;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_0139;
				IL_00ad:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_0139;
				IL_0139:
				object obj5 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ X0_v4+8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v119 @ X2_v2 (should have been resolved before IL gen)");
				return 0;
			}
			[Token(Token = "0x600001A")]
			[Address(RVA = "0x1623FE0", Offset = "0x1623FE0", Length = "0xC8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1EDF640]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A322]) = v41;\nL_001E:\n\tgoto L_004D;\n\tv52 = *([v45 @ X8_v3+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v103 @ X11_v5-8]);\n\tv109 = v56 == v48;\n\tif (v109) goto L_003E;\n\tv89 = v104 + 1;\n\tv166 = v89 < v47;\n\tv83 = ~v166;\n\tv86 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = 0x14;\n\tv91 = v42;\n\tv92 = 0x8909C4(v91, v48, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004D;\nL_003E:\n\tv167 = *([v103 @ X11_v5]);\n\tv168 = v167 + 0x14;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv171 = v170 + 0x130;\nL_004D:\n\tMycom.Tracker.Unity.Internal.Interfaces.ITrackerParams::SetBufferingPeriod(this._trackerParams, value);\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_trackerParams.SetBufferingPeriod(value);
			}
		}

		[Token(Token = "0x17000007")]
		public string CustomUserId
		{
			[Token(Token = "0x600001B")]
			[Address(RVA = "0x16240A8", Offset = "0x16240A8", Length = "0xD0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EAD458]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A323]) = v38;\nL_0013:\n\tv39 = this._trackerParams;\n\tv42 = *([v39 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams)]);\n\tv46 = *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]) == 0;\n\tif (v46) goto L_003A;\n\tv100 = *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]) + 8;\nL_0025:\n\tv106 = *([v100 @ X11_v5-8]) == Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams;\n\tif (v106) goto L_003D;\n\tv101 = v101 + 1;\n\tv160 = v101 < *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]);\n\tv80 = ~v160;\n\tv100 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_0025;\nL_003A:\n\tv166 = 0x8909C4(v39, Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams, 2, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0044;\nL_003D:\n\tv162 = *([v100 @ X11_v5]) + 2;\n\tv163 = v162 << 4;\n\tv164 = v42 + v163;\n\tv166 = v164 + 0x130;\nL_0044:\n\t*([v166 @ X0_v4])(v171, v39, *([v166 @ X0_v4+8]), 2, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv151 = v171 == 0;\n\tif (v151) goto L_0050;\n\treturnVal2 = System.Linq.Enumerable::FirstOrDefault(v171);\nL_0050:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_000d: Expected I, but got O
				//IL_0048: Expected O, but got I
				//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
				//IL_00cf: Expected O, but got Unknown
				//IL_00ec: Expected O, but got I
				//IL_00fb: Expected O, but got I
				//IL_0094: Expected O, but got I
				ITrackerParams trackerParams = _trackerParams;
				IntPtr intPtr = (IntPtr)trackerParams;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00ad;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ITrackerParams))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00ad;
				}
				object obj2 = obj + 2;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_0150;
				IL_00ad:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_0150;
				IL_0150:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v166 @ X0_v4] (should have been resolved before IL gen)");
				IEnumerable<string> enumerable = default(IEnumerable<string>);
				bool flag3 = enumerable == null;
				string result = (string)(object)enumerable;
				if (!flag3)
				{
					result = enumerable.FirstOrDefault();
				}
				return result;
			}
			[Token(Token = "0x600001C")]
			[Address(RVA = "0x1624178", Offset = "0x1624178", Length = "0x12C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv120 = *([202A324]);\n\tgoto L_0015;\n\tv22 = *([1EF22D8]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A324]) = v41;\nL_0015:\n\tv42 = this._trackerParams;\n\tv43 = value == 0;\n\tif (v43) goto L_0053;\n\t// 28 NewArr v48 @ X0_v13 (System.String[]), typeof(System.String[]), 1\n\tv76 = *([v48 @ X0_v13 (System.String[])]);\n\tv57 = \"il2cpp_codegen_object_is_inst\"(value, *([v76 @ X8_v13+40]), methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv156 = v57 == 0;\n\tif (v156) goto L_0069;\n\tv48[0] = value;\nL_002D:\n\tv120 = *([v42 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams)]);\n\tv75 = *([v120 @ X8_v4 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]) == 0;\n\tif (v75) goto L_0050;\n\tv109 = *([v120 @ X8_v4 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]) + 8;\nL_003B:\n\tv99 = *([v109 @ X11_v2-8]) == Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams;\n\tif (v99) goto L_0059;\n\tv116 = v116 + 1;\n\tv233 = v116 < *([v120 @ X8_v4 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]);\n\tv148 = ~v233;\n\tv109 = v109 + 0x10;\n\tv132 = ~v148;\n\tif (v132) goto L_003B;\nL_0050:\n\tv179 = 0x8909C4(this._trackerParams, Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams, 0x15, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0067;\nL_0053:\n\tv50 = this._trackerParams == 0;\n\tv51 = ~v50;\n\tif (v51) goto L_002D;\n\tthrow System.NullReferenceException;\nL_0059:\n\tv123 = *([v109 @ X11_v2]) + 0x15;\n\tv124 = v123 << 4;\n\tv125 = v120 + v124;\n\tv179 = v125 + 0x130;\nL_0067:\n\t// 103 IndirectJump [v179 @ X0_v2], this._trackerParams (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), this._trackerParams (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), v182 @ X20_v2 (System.Int32), [v179 @ X0_v2+8], [v179 @ X0_v2], v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tv78 = new System.NullReferenceException();\nL_0069:\n\tv161 = new System.ArrayTypeMismatchException();\n\tgoto L_006E;\n\tv234 = new System.IndexOutOfRangeException();\nL_006E:\n\tthrow v236;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0083: Expected I, but got O
				//IL_00be: Expected O, but got I
				//IL_0076: Expected I4, but got O
				//IL_017a: Unknown result type (might be due to invalid IL or missing references)
				//IL_017f: Expected O, but got Unknown
				//IL_019c: Expected O, but got I
				//IL_01ab: Expected O, but got I
				//IL_010a: Expected O, but got I
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [202A324]");
				IntPtr intPtr = (IntPtr)0;
				ITrackerParams trackerParams = _trackerParams;
				if (value != null)
				{
					string[] array = new string[1];
					object obj = array;
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_codegen_object_is_inst\"");
					object obj2 = default(object);
					if (obj2 == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						ArrayTypeMismatchException ex2 = default(ArrayTypeMismatchException);
						throw ex2;
					}
					array[0] = value;
					int num = (int)array;
				}
				else
				{
					bool flag = _trackerParams == null;
					bool flag2 = !flag;
					int num = 0;
					if (!flag2)
					{
						throw new NullReferenceException();
					}
				}
				intPtr = (IntPtr)trackerParams;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ X8_v4 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_0123;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ X8_v4 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]");
				object obj3 = 0L + 8L;
				int num2 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ X11_v2-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ITrackerParams))
					{
						break;
					}
					num2++;
					int num3 = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ X8_v4 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
					bool flag3 = (long)num3 < 0L;
					bool flag4 = !flag3;
					obj3 = (long)(IntPtr)obj3 + 16L;
					if (!flag4)
					{
						continue;
					}
					goto IL_0123;
				}
				object obj4 = obj3 + 21;
				int num4 = (int)((long)(IntPtr)obj4 << 4);
				object obj5 = (long)intPtr + (long)num4;
				object obj6 = (long)(IntPtr)obj5 + 304L;
				goto IL_0214;
				IL_0123:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_0214;
				IL_0214:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v179 @ X0_v2] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-30), the output could be wrong!");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-30), the output could be wrong!");
			}
		}

		[Token(Token = "0x17000008")]
		public string[] CustomUserIds
		{
			[Token(Token = "0x600001D")]
			[Address(RVA = "0x16242A4", Offset = "0x16242A4", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EC3A58]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A325]) = v38;\nL_0013:\n\tv39 = this._trackerParams;\n\tv42 = *([v39 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams)]);\n\tv46 = *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]) == 0;\n\tif (v46) goto L_003A;\n\tv100 = *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]) + 8;\nL_0025:\n\tv106 = *([v100 @ X11_v5-8]) == Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams;\n\tif (v106) goto L_003D;\n\tv101 = v101 + 1;\n\tv159 = v101 < *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]);\n\tv80 = ~v159;\n\tv100 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_0025;\nL_003A:\n\tv166 = 0x8909C4(v39, Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams, 2, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0041;\nL_003D:\n\tv161 = *([v100 @ X11_v5]) + 2;\n\tv162 = v161 << 4;\n\tv163 = v42 + v162;\n\tv166 = v163 + 0x130;\nL_0041:\n\tv119 = *([v166 @ X0_v4]);\n\tv141 = *([v166 @ X0_v4+8]);\n\t// 73 IndirectJump v119 @ X2_v2, v39 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), v39 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), v141 @ X1_v2, v119 @ X2_v2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_000d: Expected I, but got O
				//IL_0151: Expected O, but got I
				//IL_0048: Expected O, but got I
				//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
				//IL_00cf: Expected O, but got Unknown
				//IL_00ec: Expected O, but got I
				//IL_00fb: Expected O, but got I
				//IL_0094: Expected O, but got I
				ITrackerParams trackerParams = _trackerParams;
				IntPtr intPtr = (IntPtr)trackerParams;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00ad;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ITrackerParams))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00ad;
				}
				object obj2 = obj + 2;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_0139;
				IL_00ad:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_0139;
				IL_0139:
				object obj5 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ X0_v4+8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v119 @ X2_v2 (should have been resolved before IL gen)");
				return null;
			}
			[Token(Token = "0x600001E")]
			[Address(RVA = "0x162435C", Offset = "0x162435C", Length = "0xC8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1ECA3F8]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A326]) = v41;\nL_001E:\n\tgoto L_004D;\n\tv52 = *([v45 @ X8_v3+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v103 @ X11_v5-8]);\n\tv109 = v56 == v48;\n\tif (v109) goto L_003E;\n\tv89 = v104 + 1;\n\tv166 = v89 < v47;\n\tv83 = ~v166;\n\tv86 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = 0x15;\n\tv91 = v42;\n\tv92 = 0x8909C4(v91, v48, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004D;\nL_003E:\n\tv167 = *([v103 @ X11_v5]);\n\tv168 = v167 + 0x15;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv171 = v170 + 0x130;\nL_004D:\n\tMycom.Tracker.Unity.Internal.Interfaces.ITrackerParams::SetCustomUserIds(this._trackerParams, value);\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_trackerParams.SetCustomUserIds(value);
			}
		}

		[Token(Token = "0x17000009")]
		public string Email
		{
			[Token(Token = "0x600001F")]
			[Address(RVA = "0x1624424", Offset = "0x1624424", Length = "0xD0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EAF5E0]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A327]) = v38;\nL_0013:\n\tv39 = this._trackerParams;\n\tv42 = *([v39 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams)]);\n\tv46 = *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]) == 0;\n\tif (v46) goto L_003A;\n\tv100 = *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]) + 8;\nL_0025:\n\tv106 = *([v100 @ X11_v5-8]) == Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams;\n\tif (v106) goto L_003D;\n\tv101 = v101 + 1;\n\tv160 = v101 < *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]);\n\tv80 = ~v160;\n\tv100 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_0025;\nL_003A:\n\tv166 = 0x8909C4(v39, Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams, 3, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0044;\nL_003D:\n\tv162 = *([v100 @ X11_v5]) + 3;\n\tv163 = v162 << 4;\n\tv164 = v42 + v163;\n\tv166 = v164 + 0x130;\nL_0044:\n\t*([v166 @ X0_v4])(v171, v39, *([v166 @ X0_v4+8]), 3, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv151 = v171 == 0;\n\tif (v151) goto L_0050;\n\treturnVal2 = System.Linq.Enumerable::FirstOrDefault(v171);\nL_0050:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_000d: Expected I, but got O
				//IL_0048: Expected O, but got I
				//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
				//IL_00cf: Expected O, but got Unknown
				//IL_00ec: Expected O, but got I
				//IL_00fb: Expected O, but got I
				//IL_0094: Expected O, but got I
				ITrackerParams trackerParams = _trackerParams;
				IntPtr intPtr = (IntPtr)trackerParams;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00ad;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ITrackerParams))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
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
				goto IL_0150;
				IL_00ad:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_0150;
				IL_0150:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v166 @ X0_v4] (should have been resolved before IL gen)");
				IEnumerable<string> enumerable = default(IEnumerable<string>);
				bool flag3 = enumerable == null;
				string result = (string)(object)enumerable;
				if (!flag3)
				{
					result = enumerable.FirstOrDefault();
				}
				return result;
			}
			[Token(Token = "0x6000020")]
			[Address(RVA = "0x16244F4", Offset = "0x16244F4", Length = "0x12C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv120 = *([202A328]);\n\tgoto L_0015;\n\tv22 = *([1EC8388]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A328]) = v41;\nL_0015:\n\tv42 = this._trackerParams;\n\tv43 = value == 0;\n\tif (v43) goto L_0053;\n\t// 28 NewArr v48 @ X0_v13 (System.String[]), typeof(System.String[]), 1\n\tv76 = *([v48 @ X0_v13 (System.String[])]);\n\tv57 = \"il2cpp_codegen_object_is_inst\"(value, *([v76 @ X8_v13+40]), methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv156 = v57 == 0;\n\tif (v156) goto L_0069;\n\tv48[0] = value;\nL_002D:\n\tv120 = *([v42 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams)]);\n\tv75 = *([v120 @ X8_v4 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]) == 0;\n\tif (v75) goto L_0050;\n\tv109 = *([v120 @ X8_v4 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]) + 8;\nL_003B:\n\tv99 = *([v109 @ X11_v2-8]) == Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams;\n\tif (v99) goto L_0059;\n\tv116 = v116 + 1;\n\tv233 = v116 < *([v120 @ X8_v4 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]);\n\tv148 = ~v233;\n\tv109 = v109 + 0x10;\n\tv132 = ~v148;\n\tif (v132) goto L_003B;\nL_0050:\n\tv179 = 0x8909C4(this._trackerParams, Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams, 0x16, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0067;\nL_0053:\n\tv50 = this._trackerParams == 0;\n\tv51 = ~v50;\n\tif (v51) goto L_002D;\n\tthrow System.NullReferenceException;\nL_0059:\n\tv123 = *([v109 @ X11_v2]) + 0x16;\n\tv124 = v123 << 4;\n\tv125 = v120 + v124;\n\tv179 = v125 + 0x130;\nL_0067:\n\t// 103 IndirectJump [v179 @ X0_v2], this._trackerParams (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), this._trackerParams (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), v182 @ X20_v2 (System.Int32), [v179 @ X0_v2+8], [v179 @ X0_v2], v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tv78 = new System.NullReferenceException();\nL_0069:\n\tv161 = new System.ArrayTypeMismatchException();\n\tgoto L_006E;\n\tv234 = new System.IndexOutOfRangeException();\nL_006E:\n\tthrow v236;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0083: Expected I, but got O
				//IL_00be: Expected O, but got I
				//IL_0076: Expected I4, but got O
				//IL_017a: Unknown result type (might be due to invalid IL or missing references)
				//IL_017f: Expected O, but got Unknown
				//IL_019c: Expected O, but got I
				//IL_01ab: Expected O, but got I
				//IL_010a: Expected O, but got I
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [202A328]");
				IntPtr intPtr = (IntPtr)0;
				ITrackerParams trackerParams = _trackerParams;
				if (value != null)
				{
					string[] array = new string[1];
					object obj = array;
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_codegen_object_is_inst\"");
					object obj2 = default(object);
					if (obj2 == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						ArrayTypeMismatchException ex2 = default(ArrayTypeMismatchException);
						throw ex2;
					}
					array[0] = value;
					int num = (int)array;
				}
				else
				{
					bool flag = _trackerParams == null;
					bool flag2 = !flag;
					int num = 0;
					if (!flag2)
					{
						throw new NullReferenceException();
					}
				}
				intPtr = (IntPtr)trackerParams;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ X8_v4 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_0123;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ X8_v4 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]");
				object obj3 = 0L + 8L;
				int num2 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ X11_v2-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ITrackerParams))
					{
						break;
					}
					num2++;
					int num3 = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ X8_v4 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
					bool flag3 = (long)num3 < 0L;
					bool flag4 = !flag3;
					obj3 = (long)(IntPtr)obj3 + 16L;
					if (!flag4)
					{
						continue;
					}
					goto IL_0123;
				}
				object obj4 = obj3 + 22;
				int num4 = (int)((long)(IntPtr)obj4 << 4);
				object obj5 = (long)intPtr + (long)num4;
				object obj6 = (long)(IntPtr)obj5 + 304L;
				goto IL_0214;
				IL_0123:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_0214;
				IL_0214:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v179 @ X0_v2] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-30), the output could be wrong!");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-30), the output could be wrong!");
			}
		}

		[Token(Token = "0x1700000A")]
		public string[] Emails
		{
			[Token(Token = "0x6000021")]
			[Address(RVA = "0x1624620", Offset = "0x1624620", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EC9D60]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A329]) = v38;\nL_0013:\n\tv39 = this._trackerParams;\n\tv42 = *([v39 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams)]);\n\tv46 = *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]) == 0;\n\tif (v46) goto L_003A;\n\tv100 = *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]) + 8;\nL_0025:\n\tv106 = *([v100 @ X11_v5-8]) == Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams;\n\tif (v106) goto L_003D;\n\tv101 = v101 + 1;\n\tv159 = v101 < *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]);\n\tv80 = ~v159;\n\tv100 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_0025;\nL_003A:\n\tv166 = 0x8909C4(v39, Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams, 3, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0041;\nL_003D:\n\tv161 = *([v100 @ X11_v5]) + 3;\n\tv162 = v161 << 4;\n\tv163 = v42 + v162;\n\tv166 = v163 + 0x130;\nL_0041:\n\tv119 = *([v166 @ X0_v4]);\n\tv141 = *([v166 @ X0_v4+8]);\n\t// 73 IndirectJump v119 @ X2_v2, v39 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), v39 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), v141 @ X1_v2, v119 @ X2_v2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_000d: Expected I, but got O
				//IL_0151: Expected O, but got I
				//IL_0048: Expected O, but got I
				//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
				//IL_00cf: Expected O, but got Unknown
				//IL_00ec: Expected O, but got I
				//IL_00fb: Expected O, but got I
				//IL_0094: Expected O, but got I
				ITrackerParams trackerParams = _trackerParams;
				IntPtr intPtr = (IntPtr)trackerParams;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00ad;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ITrackerParams))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
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
				goto IL_0139;
				IL_00ad:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_0139;
				IL_0139:
				object obj5 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ X0_v4+8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v119 @ X2_v2 (should have been resolved before IL gen)");
				return null;
			}
			[Token(Token = "0x6000022")]
			[Address(RVA = "0x16246D8", Offset = "0x16246D8", Length = "0xC8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1EC7E88]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A32A]) = v41;\nL_001E:\n\tgoto L_004D;\n\tv52 = *([v45 @ X8_v3+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v103 @ X11_v5-8]);\n\tv109 = v56 == v48;\n\tif (v109) goto L_003E;\n\tv89 = v104 + 1;\n\tv166 = v89 < v47;\n\tv83 = ~v166;\n\tv86 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = 0x16;\n\tv91 = v42;\n\tv92 = 0x8909C4(v91, v48, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004D;\nL_003E:\n\tv167 = *([v103 @ X11_v5]);\n\tv168 = v167 + 0x16;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv171 = v170 + 0x130;\nL_004D:\n\tMycom.Tracker.Unity.Internal.Interfaces.ITrackerParams::SetEmails(this._trackerParams, value);\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_trackerParams.SetEmails(value);
			}
		}

		[Token(Token = "0x1700000B")]
		public int ForcingPeriod
		{
			[Token(Token = "0x6000023")]
			[Address(RVA = "0x16247A0", Offset = "0x16247A0", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F06F10]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A32B]) = v38;\nL_0013:\n\tv39 = this._trackerParams;\n\tv42 = *([v39 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams)]);\n\tv46 = *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]) == 0;\n\tif (v46) goto L_003A;\n\tv100 = *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]) + 8;\nL_0025:\n\tv106 = *([v100 @ X11_v5-8]) == Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams;\n\tif (v106) goto L_003D;\n\tv101 = v101 + 1;\n\tv159 = v101 < *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]);\n\tv80 = ~v159;\n\tv100 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_0025;\nL_003A:\n\tv166 = 0x8909C4(v39, Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams, 4, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0041;\nL_003D:\n\tv161 = *([v100 @ X11_v5]) + 4;\n\tv162 = v161 << 4;\n\tv163 = v42 + v162;\n\tv166 = v163 + 0x130;\nL_0041:\n\tv119 = *([v166 @ X0_v4]);\n\tv141 = *([v166 @ X0_v4+8]);\n\t// 73 IndirectJump v119 @ X2_v2, v39 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), v39 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), v141 @ X1_v2, v119 @ X2_v2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_000d: Expected I, but got O
				//IL_0151: Expected O, but got I
				//IL_0048: Expected O, but got I
				//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
				//IL_00cf: Expected O, but got Unknown
				//IL_00ec: Expected O, but got I
				//IL_00fb: Expected O, but got I
				//IL_0094: Expected O, but got I
				ITrackerParams trackerParams = _trackerParams;
				IntPtr intPtr = (IntPtr)trackerParams;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00ad;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ITrackerParams))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
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
				goto IL_0139;
				IL_00ad:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_0139;
				IL_0139:
				object obj5 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ X0_v4+8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v119 @ X2_v2 (should have been resolved before IL gen)");
				return 0;
			}
			[Token(Token = "0x6000024")]
			[Address(RVA = "0x1624858", Offset = "0x1624858", Length = "0xC8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1F103F0]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A32C]) = v41;\nL_001E:\n\tgoto L_004D;\n\tv52 = *([v45 @ X8_v3+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v103 @ X11_v5-8]);\n\tv109 = v56 == v48;\n\tif (v109) goto L_003E;\n\tv89 = v104 + 1;\n\tv166 = v89 < v47;\n\tv83 = ~v166;\n\tv86 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = 0x17;\n\tv91 = v42;\n\tv92 = 0x8909C4(v91, v48, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004D;\nL_003E:\n\tv167 = *([v103 @ X11_v5]);\n\tv168 = v167 + 0x17;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv171 = v170 + 0x130;\nL_004D:\n\tMycom.Tracker.Unity.Internal.Interfaces.ITrackerParams::SetForcingPeriod(this._trackerParams, value);\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_trackerParams.SetForcingPeriod(value);
			}
		}

		[Token(Token = "0x1700000C")]
		public GenderEnum Gender
		{
			[Token(Token = "0x6000025")]
			[Address(RVA = "0x1624920", Offset = "0x1624920", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EFC830]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A32D]) = v38;\nL_001C:\n\tgoto L_0049;\n\tv49 = *([v42 @ X8_v3+B0]);\n\tv50 = 0;\n\tv51 = v49 + 8;\n\tv53 = *([v100 @ X11_v5-8]);\n\tv106 = v53 == v45;\n\tif (v106) goto L_003C;\n\tv86 = v101 + 1;\n\tv159 = v86 < v44;\n\tv80 = ~v159;\n\tv83 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_FFFFFFFF;\n\tv87 = 5;\n\tv88 = v39;\n\tv89 = 0x8909C4(v88, v45, v87, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0049;\nL_003C:\n\tv160 = *([v100 @ X11_v5]);\n\tv161 = v160 + 5;\n\tv162 = v161 << 4;\n\tv163 = v42 + v162;\n\tv164 = v163 + 0x130;\nL_0049:\n\tinterfaceTailCallResult = Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams::GetGender(this._trackerParams);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return _trackerParams.GetGender();
			}
			[Token(Token = "0x6000026")]
			[Address(RVA = "0x16249D8", Offset = "0x16249D8", Length = "0xC8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EE1258]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A32E]) = v41;\nL_0015:\n\tv42 = this._trackerParams;\n\tv45 = *([v42 @ X20_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams)]);\n\tv49 = *([v45 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]) == 0;\n\tif (v49) goto L_003C;\n\tv103 = *([v45 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]) + 8;\nL_0027:\n\tv109 = *([v103 @ X11_v5-8]) == Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams;\n\tif (v109) goto L_003F;\n\tv104 = v104 + 1;\n\tv166 = v104 < *([v45 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]);\n\tv83 = ~v166;\n\tv103 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_0027;\nL_003C:\n\tv173 = 0x8909C4(v42, Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams, 0x18, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0043;\nL_003F:\n\tv168 = *([v103 @ X11_v5]) + 0x18;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv173 = v170 + 0x130;\nL_0043:\n\tv117 = *([v173 @ X0_v4]);\n\tv124 = *([v173 @ X0_v4+8]);\n\t// 77 IndirectJump v117 @ X3_v1, v42 @ X20_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), v42 @ X20_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), value @ X1 (Mycom.Tracker.Unity.GenderEnum), v124 @ X2_v2, v117 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_000d: Expected I, but got O
				//IL_0151: Expected O, but got I
				//IL_0048: Expected O, but got I
				//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
				//IL_00cf: Expected O, but got Unknown
				//IL_00ec: Expected O, but got I
				//IL_00fb: Expected O, but got I
				//IL_0094: Expected O, but got I
				ITrackerParams trackerParams = _trackerParams;
				IntPtr intPtr = (IntPtr)trackerParams;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00ad;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ITrackerParams))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00ad;
				}
				object obj2 = obj + 24;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_0139;
				IL_00ad:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_0139;
				IL_0139:
				object obj5 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X0_v4+8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v117 @ X3_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x1700000D")]
		public RegionEnum Region
		{
			[Token(Token = "0x6000027")]
			[Address(RVA = "0x1624AA0", Offset = "0x1624AA0", Length = "0xC8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1EE4200]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A32F]) = v41;\nL_001E:\n\tgoto L_004D;\n\tv52 = *([v45 @ X8_v3+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v103 @ X11_v5-8]);\n\tv109 = v56 == v48;\n\tif (v109) goto L_003E;\n\tv89 = v104 + 1;\n\tv166 = v89 < v47;\n\tv83 = ~v166;\n\tv86 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = 0x19;\n\tv91 = v42;\n\tv92 = 0x8909C4(v91, v48, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004D;\nL_003E:\n\tv167 = *([v103 @ X11_v5]);\n\tv168 = v167 + 0x19;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv171 = v170 + 0x130;\nL_004D:\n\tMycom.Tracker.Unity.Internal.Interfaces.ITrackerParams::SetRegion(this._trackerParams, value);\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_trackerParams.SetRegion(value);
			}
		}

		[Token(Token = "0x1700000E")]
		public string IcqId
		{
			[Token(Token = "0x6000028")]
			[Address(RVA = "0x1624B68", Offset = "0x1624B68", Length = "0xD0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F06C90]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A330]) = v38;\nL_0013:\n\tv39 = this._trackerParams;\n\tv42 = *([v39 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams)]);\n\tv46 = *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]) == 0;\n\tif (v46) goto L_003A;\n\tv100 = *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]) + 8;\nL_0025:\n\tv106 = *([v100 @ X11_v5-8]) == Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams;\n\tif (v106) goto L_003D;\n\tv101 = v101 + 1;\n\tv160 = v101 < *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]);\n\tv80 = ~v160;\n\tv100 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_0025;\nL_003A:\n\tv166 = 0x8909C4(v39, Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams, 6, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0044;\nL_003D:\n\tv162 = *([v100 @ X11_v5]) + 6;\n\tv163 = v162 << 4;\n\tv164 = v42 + v163;\n\tv166 = v164 + 0x130;\nL_0044:\n\t*([v166 @ X0_v4])(v171, v39, *([v166 @ X0_v4+8]), 6, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv151 = v171 == 0;\n\tif (v151) goto L_0050;\n\treturnVal2 = System.Linq.Enumerable::FirstOrDefault(v171);\nL_0050:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_000d: Expected I, but got O
				//IL_0048: Expected O, but got I
				//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
				//IL_00cf: Expected O, but got Unknown
				//IL_00ec: Expected O, but got I
				//IL_00fb: Expected O, but got I
				//IL_0094: Expected O, but got I
				ITrackerParams trackerParams = _trackerParams;
				IntPtr intPtr = (IntPtr)trackerParams;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00ad;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ITrackerParams))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
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
				goto IL_0150;
				IL_00ad:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_0150;
				IL_0150:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v166 @ X0_v4] (should have been resolved before IL gen)");
				IEnumerable<string> enumerable = default(IEnumerable<string>);
				bool flag3 = enumerable == null;
				string result = (string)(object)enumerable;
				if (!flag3)
				{
					result = enumerable.FirstOrDefault();
				}
				return result;
			}
			[Token(Token = "0x6000029")]
			[Address(RVA = "0x1624C38", Offset = "0x1624C38", Length = "0x12C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv120 = *([202A331]);\n\tgoto L_0015;\n\tv22 = *([1EE8418]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A331]) = v41;\nL_0015:\n\tv42 = this._trackerParams;\n\tv43 = value == 0;\n\tif (v43) goto L_0053;\n\t// 28 NewArr v48 @ X0_v13 (System.String[]), typeof(System.String[]), 1\n\tv76 = *([v48 @ X0_v13 (System.String[])]);\n\tv57 = \"il2cpp_codegen_object_is_inst\"(value, *([v76 @ X8_v13+40]), methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv156 = v57 == 0;\n\tif (v156) goto L_0069;\n\tv48[0] = value;\nL_002D:\n\tv120 = *([v42 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams)]);\n\tv75 = *([v120 @ X8_v4 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]) == 0;\n\tif (v75) goto L_0050;\n\tv109 = *([v120 @ X8_v4 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]) + 8;\nL_003B:\n\tv99 = *([v109 @ X11_v2-8]) == Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams;\n\tif (v99) goto L_0059;\n\tv116 = v116 + 1;\n\tv233 = v116 < *([v120 @ X8_v4 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]);\n\tv148 = ~v233;\n\tv109 = v109 + 0x10;\n\tv132 = ~v148;\n\tif (v132) goto L_003B;\nL_0050:\n\tv179 = 0x8909C4(this._trackerParams, Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams, 0x1A, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0067;\nL_0053:\n\tv50 = this._trackerParams == 0;\n\tv51 = ~v50;\n\tif (v51) goto L_002D;\n\tthrow System.NullReferenceException;\nL_0059:\n\tv123 = *([v109 @ X11_v2]) + 0x1A;\n\tv124 = v123 << 4;\n\tv125 = v120 + v124;\n\tv179 = v125 + 0x130;\nL_0067:\n\t// 103 IndirectJump [v179 @ X0_v2], this._trackerParams (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), this._trackerParams (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), v182 @ X20_v2 (System.Int32), [v179 @ X0_v2+8], [v179 @ X0_v2], v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tv78 = new System.NullReferenceException();\nL_0069:\n\tv161 = new System.ArrayTypeMismatchException();\n\tgoto L_006E;\n\tv234 = new System.IndexOutOfRangeException();\nL_006E:\n\tthrow v236;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0083: Expected I, but got O
				//IL_00be: Expected O, but got I
				//IL_0076: Expected I4, but got O
				//IL_017a: Unknown result type (might be due to invalid IL or missing references)
				//IL_017f: Expected O, but got Unknown
				//IL_019c: Expected O, but got I
				//IL_01ab: Expected O, but got I
				//IL_010a: Expected O, but got I
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [202A331]");
				IntPtr intPtr = (IntPtr)0;
				ITrackerParams trackerParams = _trackerParams;
				if (value != null)
				{
					string[] array = new string[1];
					object obj = array;
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_codegen_object_is_inst\"");
					object obj2 = default(object);
					if (obj2 == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						ArrayTypeMismatchException ex2 = default(ArrayTypeMismatchException);
						throw ex2;
					}
					array[0] = value;
					int num = (int)array;
				}
				else
				{
					bool flag = _trackerParams == null;
					bool flag2 = !flag;
					int num = 0;
					if (!flag2)
					{
						throw new NullReferenceException();
					}
				}
				intPtr = (IntPtr)trackerParams;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ X8_v4 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_0123;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ X8_v4 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]");
				object obj3 = 0L + 8L;
				int num2 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ X11_v2-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ITrackerParams))
					{
						break;
					}
					num2++;
					int num3 = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ X8_v4 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
					bool flag3 = (long)num3 < 0L;
					bool flag4 = !flag3;
					obj3 = (long)(IntPtr)obj3 + 16L;
					if (!flag4)
					{
						continue;
					}
					goto IL_0123;
				}
				object obj4 = obj3 + 26;
				int num4 = (int)((long)(IntPtr)obj4 << 4);
				object obj5 = (long)intPtr + (long)num4;
				object obj6 = (long)(IntPtr)obj5 + 304L;
				goto IL_0214;
				IL_0123:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_0214;
				IL_0214:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v179 @ X0_v2] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-30), the output could be wrong!");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-30), the output could be wrong!");
			}
		}

		[Token(Token = "0x1700000F")]
		public string[] IcqIds
		{
			[Token(Token = "0x600002A")]
			[Address(RVA = "0x1624D64", Offset = "0x1624D64", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EEBCC0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A332]) = v38;\nL_0013:\n\tv39 = this._trackerParams;\n\tv42 = *([v39 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams)]);\n\tv46 = *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]) == 0;\n\tif (v46) goto L_003A;\n\tv100 = *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]) + 8;\nL_0025:\n\tv106 = *([v100 @ X11_v5-8]) == Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams;\n\tif (v106) goto L_003D;\n\tv101 = v101 + 1;\n\tv159 = v101 < *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]);\n\tv80 = ~v159;\n\tv100 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_0025;\nL_003A:\n\tv166 = 0x8909C4(v39, Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams, 6, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0041;\nL_003D:\n\tv161 = *([v100 @ X11_v5]) + 6;\n\tv162 = v161 << 4;\n\tv163 = v42 + v162;\n\tv166 = v163 + 0x130;\nL_0041:\n\tv119 = *([v166 @ X0_v4]);\n\tv141 = *([v166 @ X0_v4+8]);\n\t// 73 IndirectJump v119 @ X2_v2, v39 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), v39 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), v141 @ X1_v2, v119 @ X2_v2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_000d: Expected I, but got O
				//IL_0151: Expected O, but got I
				//IL_0048: Expected O, but got I
				//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
				//IL_00cf: Expected O, but got Unknown
				//IL_00ec: Expected O, but got I
				//IL_00fb: Expected O, but got I
				//IL_0094: Expected O, but got I
				ITrackerParams trackerParams = _trackerParams;
				IntPtr intPtr = (IntPtr)trackerParams;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00ad;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ITrackerParams))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
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
				goto IL_0139;
				IL_00ad:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_0139;
				IL_0139:
				object obj5 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ X0_v4+8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v119 @ X2_v2 (should have been resolved before IL gen)");
				return null;
			}
			[Token(Token = "0x600002B")]
			[Address(RVA = "0x1624E1C", Offset = "0x1624E1C", Length = "0xC8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1ED7388]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A333]) = v41;\nL_001E:\n\tgoto L_004D;\n\tv52 = *([v45 @ X8_v3+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v103 @ X11_v5-8]);\n\tv109 = v56 == v48;\n\tif (v109) goto L_003E;\n\tv89 = v104 + 1;\n\tv166 = v89 < v47;\n\tv83 = ~v166;\n\tv86 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = 0x1A;\n\tv91 = v42;\n\tv92 = 0x8909C4(v91, v48, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004D;\nL_003E:\n\tv167 = *([v103 @ X11_v5]);\n\tv168 = v167 + 0x1A;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv171 = v170 + 0x130;\nL_004D:\n\tMycom.Tracker.Unity.Internal.Interfaces.ITrackerParams::SetIcqIds(this._trackerParams, value);\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_trackerParams.SetIcqIds(value);
			}
		}

		[Token(Token = "0x17000010")]
		public string Id
		{
			[Token(Token = "0x600002C")]
			[Address(RVA = "0x1624EE4", Offset = "0x1624EE4", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EDAC08]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A334]) = v38;\nL_0013:\n\tv39 = this._trackerParams;\n\tv42 = *([v39 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams)]);\n\tv46 = *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]) == 0;\n\tif (v46) goto L_003A;\n\tv100 = *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]) + 8;\nL_0025:\n\tv106 = *([v100 @ X11_v5-8]) == Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams;\n\tif (v106) goto L_003D;\n\tv101 = v101 + 1;\n\tv159 = v101 < *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]);\n\tv80 = ~v159;\n\tv100 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_0025;\nL_003A:\n\tv166 = 0x8909C4(v39, Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams, 7, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0041;\nL_003D:\n\tv161 = *([v100 @ X11_v5]) + 7;\n\tv162 = v161 << 4;\n\tv163 = v42 + v162;\n\tv166 = v163 + 0x130;\nL_0041:\n\tv119 = *([v166 @ X0_v4]);\n\tv141 = *([v166 @ X0_v4+8]);\n\t// 73 IndirectJump v119 @ X2_v2, v39 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), v39 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), v141 @ X1_v2, v119 @ X2_v2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_000d: Expected I, but got O
				//IL_0151: Expected O, but got I
				//IL_0048: Expected O, but got I
				//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
				//IL_00cf: Expected O, but got Unknown
				//IL_00ec: Expected O, but got I
				//IL_00fb: Expected O, but got I
				//IL_0094: Expected O, but got I
				ITrackerParams trackerParams = _trackerParams;
				IntPtr intPtr = (IntPtr)trackerParams;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00ad;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ITrackerParams))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
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
				goto IL_0139;
				IL_00ad:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_0139;
				IL_0139:
				object obj5 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ X0_v4+8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v119 @ X2_v2 (should have been resolved before IL gen)");
				return null;
			}
		}

		[Token(Token = "0x17000011")]
		public bool IsTrackingEnvironmentEnabled
		{
			[Token(Token = "0x600002D")]
			[Address(RVA = "0x1624F9C", Offset = "0x1624F9C", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EE7A68]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A335]) = v38;\nL_0013:\n\tv39 = this._trackerParams;\n\tv42 = *([v39 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams)]);\n\tv46 = *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]) == 0;\n\tif (v46) goto L_003A;\n\tv100 = *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]) + 8;\nL_0025:\n\tv106 = *([v100 @ X11_v5-8]) == Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams;\n\tif (v106) goto L_003D;\n\tv101 = v101 + 1;\n\tv159 = v101 < *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]);\n\tv80 = ~v159;\n\tv100 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_0025;\nL_003A:\n\tv166 = 0x8909C4(v39, Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams, 0x10, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0041;\nL_003D:\n\tv161 = *([v100 @ X11_v5]) + 0x10;\n\tv162 = v161 << 4;\n\tv163 = v42 + v162;\n\tv166 = v163 + 0x130;\nL_0041:\n\tv119 = *([v166 @ X0_v4]);\n\tv141 = *([v166 @ X0_v4+8]);\n\t// 73 IndirectJump v119 @ X2_v2, v39 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), v39 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), v141 @ X1_v2, v119 @ X2_v2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_000d: Expected I, but got O
				//IL_0151: Expected O, but got I
				//IL_0048: Expected O, but got I
				//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
				//IL_00cf: Expected O, but got Unknown
				//IL_00ec: Expected O, but got I
				//IL_00fb: Expected O, but got I
				//IL_0094: Expected O, but got I
				ITrackerParams trackerParams = _trackerParams;
				IntPtr intPtr = (IntPtr)trackerParams;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00ad;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ITrackerParams))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00ad;
				}
				object obj2 = obj + 16;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_0139;
				IL_00ad:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_0139;
				IL_0139:
				object obj5 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ X0_v4+8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v119 @ X2_v2 (should have been resolved before IL gen)");
				return false;
			}
			[Token(Token = "0x600002E")]
			[Address(RVA = "0x1625054", Offset = "0x1625054", Length = "0xC8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1EEC870]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A336]) = v41;\nL_001E:\n\tgoto L_004D;\n\tv52 = *([v45 @ X8_v3+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v103 @ X11_v5-8]);\n\tv109 = v56 == v48;\n\tif (v109) goto L_003E;\n\tv89 = v104 + 1;\n\tv166 = v89 < v47;\n\tv83 = ~v166;\n\tv86 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = 0x22;\n\tv91 = v42;\n\tv92 = 0x8909C4(v91, v48, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004D;\nL_003E:\n\tv167 = *([v103 @ X11_v5]);\n\tv168 = v167 + 0x22;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv171 = v170 + 0x130;\nL_004D:\n\tMycom.Tracker.Unity.Internal.Interfaces.ITrackerParams::SetTrackingEnvironmentEnabled(this._trackerParams, value);\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_trackerParams.SetTrackingEnvironmentEnabled(value);
			}
		}

		[Token(Token = "0x17000012")]
		public bool IsTrackingLaunchEnabled
		{
			[Token(Token = "0x600002F")]
			[Address(RVA = "0x162511C", Offset = "0x162511C", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EF3920]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A337]) = v38;\nL_001C:\n\tgoto L_0049;\n\tv49 = *([v42 @ X8_v3+B0]);\n\tv50 = 0;\n\tv51 = v49 + 8;\n\tv53 = *([v100 @ X11_v5-8]);\n\tv106 = v53 == v45;\n\tif (v106) goto L_003C;\n\tv86 = v101 + 1;\n\tv159 = v86 < v44;\n\tv80 = ~v159;\n\tv83 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_FFFFFFFF;\n\tv87 = 0x11;\n\tv88 = v39;\n\tv89 = 0x8909C4(v88, v45, v87, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0049;\nL_003C:\n\tv160 = *([v100 @ X11_v5]);\n\tv161 = v160 + 0x11;\n\tv162 = v161 << 4;\n\tv163 = v42 + v162;\n\tv164 = v163 + 0x130;\nL_0049:\n\tinterfaceTailCallResult = Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams::IsTrackingLaunchEnabled(this._trackerParams);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return _trackerParams.IsTrackingLaunchEnabled();
			}
			[Token(Token = "0x6000030")]
			[Address(RVA = "0x16251D4", Offset = "0x16251D4", Length = "0xC8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1EE7F58]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A338]) = v41;\nL_001E:\n\tgoto L_004D;\n\tv52 = *([v45 @ X8_v3+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v103 @ X11_v5-8]);\n\tv109 = v56 == v48;\n\tif (v109) goto L_003E;\n\tv89 = v104 + 1;\n\tv166 = v89 < v47;\n\tv83 = ~v166;\n\tv86 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = 0x23;\n\tv91 = v42;\n\tv92 = 0x8909C4(v91, v48, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004D;\nL_003E:\n\tv167 = *([v103 @ X11_v5]);\n\tv168 = v167 + 0x23;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv171 = v170 + 0x130;\nL_004D:\n\tMycom.Tracker.Unity.Internal.Interfaces.ITrackerParams::SetTrackingLaunchEnabled(this._trackerParams, value);\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_trackerParams.SetTrackingLaunchEnabled(value);
			}
		}

		[Token(Token = "0x17000013")]
		public bool IsTrackingLocationEnabled
		{
			[Token(Token = "0x6000031")]
			[Address(RVA = "0x162529C", Offset = "0x162529C", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1ED6180]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A339]) = v38;\nL_001C:\n\tgoto L_0049;\n\tv49 = *([v42 @ X8_v3+B0]);\n\tv50 = 0;\n\tv51 = v49 + 8;\n\tv53 = *([v100 @ X11_v5-8]);\n\tv106 = v53 == v45;\n\tif (v106) goto L_003C;\n\tv86 = v101 + 1;\n\tv159 = v86 < v44;\n\tv80 = ~v159;\n\tv83 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_FFFFFFFF;\n\tv87 = 0x12;\n\tv88 = v39;\n\tv89 = 0x8909C4(v88, v45, v87, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0049;\nL_003C:\n\tv160 = *([v100 @ X11_v5]);\n\tv161 = v160 + 0x12;\n\tv162 = v161 << 4;\n\tv163 = v42 + v162;\n\tv164 = v163 + 0x130;\nL_0049:\n\tinterfaceTailCallResult = Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams::IsTrackingLocationEnabled(this._trackerParams);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return _trackerParams.IsTrackingLocationEnabled();
			}
			[Token(Token = "0x6000032")]
			[Address(RVA = "0x1625354", Offset = "0x1625354", Length = "0xC8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1EAE820]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A33A]) = v41;\nL_001E:\n\tgoto L_004D;\n\tv52 = *([v45 @ X8_v3+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v103 @ X11_v5-8]);\n\tv109 = v56 == v48;\n\tif (v109) goto L_003E;\n\tv89 = v104 + 1;\n\tv166 = v89 < v47;\n\tv83 = ~v166;\n\tv86 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = 0x24;\n\tv91 = v42;\n\tv92 = 0x8909C4(v91, v48, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004D;\nL_003E:\n\tv167 = *([v103 @ X11_v5]);\n\tv168 = v167 + 0x24;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv171 = v170 + 0x130;\nL_004D:\n\tMycom.Tracker.Unity.Internal.Interfaces.ITrackerParams::SetTrackingLocationEnabled(this._trackerParams, value);\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_trackerParams.SetTrackingLocationEnabled(value);
			}
		}

		[Token(Token = "0x17000014")]
		public string Lang
		{
			[Token(Token = "0x6000033")]
			[Address(RVA = "0x162541C", Offset = "0x162541C", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EDB9C8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A33B]) = v38;\nL_0013:\n\tv39 = this._trackerParams;\n\tv42 = *([v39 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams)]);\n\tv46 = *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]) == 0;\n\tif (v46) goto L_003A;\n\tv100 = *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]) + 8;\nL_0025:\n\tv106 = *([v100 @ X11_v5-8]) == Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams;\n\tif (v106) goto L_003D;\n\tv101 = v101 + 1;\n\tv159 = v101 < *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]);\n\tv80 = ~v159;\n\tv100 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_0025;\nL_003A:\n\tv166 = 0x8909C4(v39, Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams, 8, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0041;\nL_003D:\n\tv161 = *([v100 @ X11_v5]) + 8;\n\tv162 = v161 << 4;\n\tv163 = v42 + v162;\n\tv166 = v163 + 0x130;\nL_0041:\n\tv119 = *([v166 @ X0_v4]);\n\tv141 = *([v166 @ X0_v4+8]);\n\t// 73 IndirectJump v119 @ X2_v2, v39 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), v39 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), v141 @ X1_v2, v119 @ X2_v2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_000d: Expected I, but got O
				//IL_0151: Expected O, but got I
				//IL_0048: Expected O, but got I
				//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
				//IL_00cf: Expected O, but got Unknown
				//IL_00ec: Expected O, but got I
				//IL_00fb: Expected O, but got I
				//IL_0094: Expected O, but got I
				ITrackerParams trackerParams = _trackerParams;
				IntPtr intPtr = (IntPtr)trackerParams;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00ad;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ITrackerParams))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00ad;
				}
				object obj2 = obj + 8;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_0139;
				IL_00ad:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_0139;
				IL_0139:
				object obj5 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ X0_v4+8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v119 @ X2_v2 (should have been resolved before IL gen)");
				return null;
			}
			[Token(Token = "0x6000034")]
			[Address(RVA = "0x16254D4", Offset = "0x16254D4", Length = "0xC8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1F107F8]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A33C]) = v41;\nL_001E:\n\tgoto L_004D;\n\tv52 = *([v45 @ X8_v3+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v103 @ X11_v5-8]);\n\tv109 = v56 == v48;\n\tif (v109) goto L_003E;\n\tv89 = v104 + 1;\n\tv166 = v89 < v47;\n\tv83 = ~v166;\n\tv86 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = 0x1B;\n\tv91 = v42;\n\tv92 = 0x8909C4(v91, v48, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004D;\nL_003E:\n\tv167 = *([v103 @ X11_v5]);\n\tv168 = v167 + 0x1B;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv171 = v170 + 0x130;\nL_004D:\n\tMycom.Tracker.Unity.Internal.Interfaces.ITrackerParams::SetLang(this._trackerParams, value);\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_trackerParams.SetLang(value);
			}
		}

		[Token(Token = "0x17000015")]
		public int LaunchTimeout
		{
			[Token(Token = "0x6000035")]
			[Address(RVA = "0x162559C", Offset = "0x162559C", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EEB1B8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A33D]) = v38;\nL_001C:\n\tgoto L_0049;\n\tv49 = *([v42 @ X8_v3+B0]);\n\tv50 = 0;\n\tv51 = v49 + 8;\n\tv53 = *([v100 @ X11_v5-8]);\n\tv106 = v53 == v45;\n\tif (v106) goto L_003C;\n\tv86 = v101 + 1;\n\tv159 = v86 < v44;\n\tv80 = ~v159;\n\tv83 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_FFFFFFFF;\n\tv87 = 9;\n\tv88 = v39;\n\tv89 = 0x8909C4(v88, v45, v87, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0049;\nL_003C:\n\tv160 = *([v100 @ X11_v5]);\n\tv161 = v160 + 9;\n\tv162 = v161 << 4;\n\tv163 = v42 + v162;\n\tv164 = v163 + 0x130;\nL_0049:\n\tinterfaceTailCallResult = Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams::GetLaunchTimeout(this._trackerParams);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return _trackerParams.GetLaunchTimeout();
			}
			[Token(Token = "0x6000036")]
			[Address(RVA = "0x1625654", Offset = "0x1625654", Length = "0xC8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ECB010]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A33E]) = v41;\nL_0015:\n\tv42 = this._trackerParams;\n\tv45 = *([v42 @ X20_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams)]);\n\tv49 = *([v45 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]) == 0;\n\tif (v49) goto L_003C;\n\tv103 = *([v45 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]) + 8;\nL_0027:\n\tv109 = *([v103 @ X11_v5-8]) == Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams;\n\tif (v109) goto L_003F;\n\tv104 = v104 + 1;\n\tv166 = v104 < *([v45 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]);\n\tv83 = ~v166;\n\tv103 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_0027;\nL_003C:\n\tv173 = 0x8909C4(v42, Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams, 0x1C, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0043;\nL_003F:\n\tv168 = *([v103 @ X11_v5]) + 0x1C;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv173 = v170 + 0x130;\nL_0043:\n\tv117 = *([v173 @ X0_v4]);\n\tv124 = *([v173 @ X0_v4+8]);\n\t// 77 IndirectJump v117 @ X3_v1, v42 @ X20_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), v42 @ X20_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), value @ X1 (System.Int32), v124 @ X2_v2, v117 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_000d: Expected I, but got O
				//IL_0151: Expected O, but got I
				//IL_0048: Expected O, but got I
				//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
				//IL_00cf: Expected O, but got Unknown
				//IL_00ec: Expected O, but got I
				//IL_00fb: Expected O, but got I
				//IL_0094: Expected O, but got I
				ITrackerParams trackerParams = _trackerParams;
				IntPtr intPtr = (IntPtr)trackerParams;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00ad;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ITrackerParams))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00ad;
				}
				object obj2 = obj + 28;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_0139;
				IL_00ad:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_0139;
				IL_0139:
				object obj5 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X0_v4+8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v117 @ X3_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x17000016")]
		public string MrgsAppId
		{
			[Token(Token = "0x6000037")]
			[Address(RVA = "0x162571C", Offset = "0x162571C", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EE7260]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A33F]) = v38;\nL_001C:\n\tgoto L_0049;\n\tv49 = *([v42 @ X8_v3+B0]);\n\tv50 = 0;\n\tv51 = v49 + 8;\n\tv53 = *([v100 @ X11_v5-8]);\n\tv106 = v53 == v45;\n\tif (v106) goto L_003C;\n\tv86 = v101 + 1;\n\tv159 = v86 < v44;\n\tv80 = ~v159;\n\tv83 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_FFFFFFFF;\n\tv87 = 0xA;\n\tv88 = v39;\n\tv89 = 0x8909C4(v88, v45, v87, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0049;\nL_003C:\n\tv160 = *([v100 @ X11_v5]);\n\tv161 = v160 + 0xA;\n\tv162 = v161 << 4;\n\tv163 = v42 + v162;\n\tv164 = v163 + 0x130;\nL_0049:\n\tinterfaceTailCallResult = Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams::GetMrgsAppId(this._trackerParams);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return _trackerParams.GetMrgsAppId();
			}
			[Token(Token = "0x6000038")]
			[Address(RVA = "0x16257D4", Offset = "0x16257D4", Length = "0xC8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1ED5C48]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A340]) = v41;\nL_001E:\n\tgoto L_004D;\n\tv52 = *([v45 @ X8_v3+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v103 @ X11_v5-8]);\n\tv109 = v56 == v48;\n\tif (v109) goto L_003E;\n\tv89 = v104 + 1;\n\tv166 = v89 < v47;\n\tv83 = ~v166;\n\tv86 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = 0x1D;\n\tv91 = v42;\n\tv92 = 0x8909C4(v91, v48, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004D;\nL_003E:\n\tv167 = *([v103 @ X11_v5]);\n\tv168 = v167 + 0x1D;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv171 = v170 + 0x130;\nL_004D:\n\tMycom.Tracker.Unity.Internal.Interfaces.ITrackerParams::SetMrgsAppId(this._trackerParams, value);\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_trackerParams.SetMrgsAppId(value);
			}
		}

		[Token(Token = "0x17000017")]
		public string MrgsId
		{
			[Token(Token = "0x6000039")]
			[Address(RVA = "0x162589C", Offset = "0x162589C", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EBFD98]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A341]) = v38;\nL_001C:\n\tgoto L_0049;\n\tv49 = *([v42 @ X8_v3+B0]);\n\tv50 = 0;\n\tv51 = v49 + 8;\n\tv53 = *([v100 @ X11_v5-8]);\n\tv106 = v53 == v45;\n\tif (v106) goto L_003C;\n\tv86 = v101 + 1;\n\tv159 = v86 < v44;\n\tv80 = ~v159;\n\tv83 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_FFFFFFFF;\n\tv87 = 0xB;\n\tv88 = v39;\n\tv89 = 0x8909C4(v88, v45, v87, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0049;\nL_003C:\n\tv160 = *([v100 @ X11_v5]);\n\tv161 = v160 + 0xB;\n\tv162 = v161 << 4;\n\tv163 = v42 + v162;\n\tv164 = v163 + 0x130;\nL_0049:\n\tinterfaceTailCallResult = Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams::GetMrgsId(this._trackerParams);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return _trackerParams.GetMrgsId();
			}
			[Token(Token = "0x600003A")]
			[Address(RVA = "0x1625954", Offset = "0x1625954", Length = "0xC8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1F0B650]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A342]) = v41;\nL_0015:\n\tv42 = this._trackerParams;\n\tv45 = *([v42 @ X20_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams)]);\n\tv49 = *([v45 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]) == 0;\n\tif (v49) goto L_003C;\n\tv103 = *([v45 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]) + 8;\nL_0027:\n\tv109 = *([v103 @ X11_v5-8]) == Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams;\n\tif (v109) goto L_003F;\n\tv104 = v104 + 1;\n\tv166 = v104 < *([v45 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]);\n\tv83 = ~v166;\n\tv103 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_0027;\nL_003C:\n\tv173 = 0x8909C4(v42, Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams, 0x1E, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0043;\nL_003F:\n\tv168 = *([v103 @ X11_v5]) + 0x1E;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv173 = v170 + 0x130;\nL_0043:\n\tv117 = *([v173 @ X0_v4]);\n\tv124 = *([v173 @ X0_v4+8]);\n\t// 77 IndirectJump v117 @ X3_v1, v42 @ X20_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), v42 @ X20_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), value @ X1 (System.String), v124 @ X2_v2, v117 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_000d: Expected I, but got O
				//IL_0151: Expected O, but got I
				//IL_0048: Expected O, but got I
				//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
				//IL_00cf: Expected O, but got Unknown
				//IL_00ec: Expected O, but got I
				//IL_00fb: Expected O, but got I
				//IL_0094: Expected O, but got I
				ITrackerParams trackerParams = _trackerParams;
				IntPtr intPtr = (IntPtr)trackerParams;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00ad;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ITrackerParams))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00ad;
				}
				object obj2 = obj + 30;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_0139;
				IL_00ad:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_0139;
				IL_0139:
				object obj5 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X0_v4+8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v117 @ X3_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x17000018")]
		public string MrgsUserId
		{
			[Token(Token = "0x600003B")]
			[Address(RVA = "0x1625A1C", Offset = "0x1625A1C", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F0F0F0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A343]) = v38;\nL_0013:\n\tv39 = this._trackerParams;\n\tv42 = *([v39 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams)]);\n\tv46 = *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]) == 0;\n\tif (v46) goto L_003A;\n\tv100 = *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]) + 8;\nL_0025:\n\tv106 = *([v100 @ X11_v5-8]) == Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams;\n\tif (v106) goto L_003D;\n\tv101 = v101 + 1;\n\tv159 = v101 < *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]);\n\tv80 = ~v159;\n\tv100 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_0025;\nL_003A:\n\tv166 = 0x8909C4(v39, Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams, 0xC, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0041;\nL_003D:\n\tv161 = *([v100 @ X11_v5]) + 0xC;\n\tv162 = v161 << 4;\n\tv163 = v42 + v162;\n\tv166 = v163 + 0x130;\nL_0041:\n\tv119 = *([v166 @ X0_v4]);\n\tv141 = *([v166 @ X0_v4+8]);\n\t// 73 IndirectJump v119 @ X2_v2, v39 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), v39 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), v141 @ X1_v2, v119 @ X2_v2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_000d: Expected I, but got O
				//IL_0151: Expected O, but got I
				//IL_0048: Expected O, but got I
				//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
				//IL_00cf: Expected O, but got Unknown
				//IL_00ec: Expected O, but got I
				//IL_00fb: Expected O, but got I
				//IL_0094: Expected O, but got I
				ITrackerParams trackerParams = _trackerParams;
				IntPtr intPtr = (IntPtr)trackerParams;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00ad;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ITrackerParams))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
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
				goto IL_0139;
				IL_00ad:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_0139;
				IL_0139:
				object obj5 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ X0_v4+8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v119 @ X2_v2 (should have been resolved before IL gen)");
				return null;
			}
			[Token(Token = "0x600003C")]
			[Address(RVA = "0x1625AD4", Offset = "0x1625AD4", Length = "0xC8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EB78C0]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A344]) = v41;\nL_0015:\n\tv42 = this._trackerParams;\n\tv45 = *([v42 @ X20_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams)]);\n\tv49 = *([v45 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]) == 0;\n\tif (v49) goto L_003C;\n\tv103 = *([v45 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]) + 8;\nL_0027:\n\tv109 = *([v103 @ X11_v5-8]) == Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams;\n\tif (v109) goto L_003F;\n\tv104 = v104 + 1;\n\tv166 = v104 < *([v45 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]);\n\tv83 = ~v166;\n\tv103 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_0027;\nL_003C:\n\tv173 = 0x8909C4(v42, Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams, 0x1F, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0043;\nL_003F:\n\tv168 = *([v103 @ X11_v5]) + 0x1F;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv173 = v170 + 0x130;\nL_0043:\n\tv117 = *([v173 @ X0_v4]);\n\tv124 = *([v173 @ X0_v4+8]);\n\t// 77 IndirectJump v117 @ X3_v1, v42 @ X20_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), v42 @ X20_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), value @ X1 (System.String), v124 @ X2_v2, v117 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_000d: Expected I, but got O
				//IL_0151: Expected O, but got I
				//IL_0048: Expected O, but got I
				//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
				//IL_00cf: Expected O, but got Unknown
				//IL_00ec: Expected O, but got I
				//IL_00fb: Expected O, but got I
				//IL_0094: Expected O, but got I
				ITrackerParams trackerParams = _trackerParams;
				IntPtr intPtr = (IntPtr)trackerParams;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00ad;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ITrackerParams))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00ad;
				}
				object obj2 = obj + 31;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_0139;
				IL_00ad:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_0139;
				IL_0139:
				object obj5 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X0_v4+8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v117 @ X3_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x17000019")]
		public string OkId
		{
			[Token(Token = "0x600003D")]
			[Address(RVA = "0x1625B9C", Offset = "0x1625B9C", Length = "0xD0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1F0C338]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A345]) = v38;\nL_001C:\n\tgoto L_0044;\n\tv49 = *([v42 @ X8_v3+B0]);\n\tv50 = 0;\n\tv51 = v49 + 8;\n\tv53 = *([v100 @ X11_v5-8]);\n\tv106 = v53 == v45;\n\tif (v106) goto L_003C;\n\tv86 = v101 + 1;\n\tv160 = v86 < v44;\n\tv80 = ~v160;\n\tv83 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_FFFFFFFF;\n\tv87 = 0xD;\n\tv88 = v39;\n\tv89 = 0x8909C4(v88, v45, v87, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0044;\nL_003C:\n\tv161 = *([v100 @ X11_v5]);\n\tv162 = v161 + 0xD;\n\tv163 = v162 << 4;\n\tv164 = v42 + v163;\n\tv165 = v164 + 0x130;\nL_0044:\n\tv171 = Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams::GetOkIds(this._trackerParams);\n\tv151 = v171 == 0;\n\tif (v151) goto L_0050;\n\treturnVal2 = System.Linq.Enumerable::FirstOrDefault(v171);\nL_0050:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				string[] okIds = _trackerParams.GetOkIds();
				bool flag = okIds == null;
				string result = (string)(object)okIds;
				if (!flag)
				{
					result = okIds.FirstOrDefault();
				}
				return result;
			}
			[Token(Token = "0x600003E")]
			[Address(RVA = "0x1625C6C", Offset = "0x1625C6C", Length = "0x12C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv120 = *([202A346]);\n\tgoto L_0015;\n\tv22 = *([1EB2500]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A346]) = v41;\nL_0015:\n\tv42 = this._trackerParams;\n\tv43 = value == 0;\n\tif (v43) goto L_0053;\n\t// 28 NewArr v48 @ X0_v13 (System.String[]), typeof(System.String[]), 1\n\tv76 = *([v48 @ X0_v13 (System.String[])]);\n\tv57 = \"il2cpp_codegen_object_is_inst\"(value, *([v76 @ X8_v13+40]), methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv156 = v57 == 0;\n\tif (v156) goto L_0069;\n\tv48[0] = value;\nL_002D:\n\tv120 = *([v42 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams)]);\n\tv75 = *([v120 @ X8_v4 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]) == 0;\n\tif (v75) goto L_0050;\n\tv109 = *([v120 @ X8_v4 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]) + 8;\nL_003B:\n\tv99 = *([v109 @ X11_v2-8]) == Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams;\n\tif (v99) goto L_0059;\n\tv116 = v116 + 1;\n\tv233 = v116 < *([v120 @ X8_v4 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]);\n\tv148 = ~v233;\n\tv109 = v109 + 0x10;\n\tv132 = ~v148;\n\tif (v132) goto L_003B;\nL_0050:\n\tv179 = 0x8909C4(this._trackerParams, Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams, 0x20, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0067;\nL_0053:\n\tv50 = this._trackerParams == 0;\n\tv51 = ~v50;\n\tif (v51) goto L_002D;\n\tthrow System.NullReferenceException;\nL_0059:\n\tv123 = *([v109 @ X11_v2]) + 0x20;\n\tv124 = v123 << 4;\n\tv125 = v120 + v124;\n\tv179 = v125 + 0x130;\nL_0067:\n\t// 103 IndirectJump [v179 @ X0_v2], this._trackerParams (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), this._trackerParams (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), v182 @ X20_v2 (System.Int32), [v179 @ X0_v2+8], [v179 @ X0_v2], v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tv78 = new System.NullReferenceException();\nL_0069:\n\tv161 = new System.ArrayTypeMismatchException();\n\tgoto L_006E;\n\tv234 = new System.IndexOutOfRangeException();\nL_006E:\n\tthrow v236;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0083: Expected I, but got O
				//IL_00be: Expected O, but got I
				//IL_0076: Expected I4, but got O
				//IL_017a: Unknown result type (might be due to invalid IL or missing references)
				//IL_017f: Expected O, but got Unknown
				//IL_019c: Expected O, but got I
				//IL_01ab: Expected O, but got I
				//IL_010a: Expected O, but got I
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [202A346]");
				IntPtr intPtr = (IntPtr)0;
				ITrackerParams trackerParams = _trackerParams;
				if (value != null)
				{
					string[] array = new string[1];
					object obj = array;
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_codegen_object_is_inst\"");
					object obj2 = default(object);
					if (obj2 == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						ArrayTypeMismatchException ex2 = default(ArrayTypeMismatchException);
						throw ex2;
					}
					array[0] = value;
					int num = (int)array;
				}
				else
				{
					bool flag = _trackerParams == null;
					bool flag2 = !flag;
					int num = 0;
					if (!flag2)
					{
						throw new NullReferenceException();
					}
				}
				intPtr = (IntPtr)trackerParams;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ X8_v4 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_0123;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ X8_v4 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]");
				object obj3 = 0L + 8L;
				int num2 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ X11_v2-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ITrackerParams))
					{
						break;
					}
					num2++;
					int num3 = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ X8_v4 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
					bool flag3 = (long)num3 < 0L;
					bool flag4 = !flag3;
					obj3 = (long)(IntPtr)obj3 + 16L;
					if (!flag4)
					{
						continue;
					}
					goto IL_0123;
				}
				object obj4 = obj3 + 32;
				int num4 = (int)((long)(IntPtr)obj4 << 4);
				object obj5 = (long)intPtr + (long)num4;
				object obj6 = (long)(IntPtr)obj5 + 304L;
				goto IL_0214;
				IL_0123:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_0214;
				IL_0214:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v179 @ X0_v2] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-30), the output could be wrong!");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-30), the output could be wrong!");
			}
		}

		[Token(Token = "0x1700001A")]
		public string[] OkIds
		{
			[Token(Token = "0x600003F")]
			[Address(RVA = "0x1625D98", Offset = "0x1625D98", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EE1E68]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A347]) = v38;\nL_001C:\n\tgoto L_0049;\n\tv49 = *([v42 @ X8_v3+B0]);\n\tv50 = 0;\n\tv51 = v49 + 8;\n\tv53 = *([v100 @ X11_v5-8]);\n\tv106 = v53 == v45;\n\tif (v106) goto L_003C;\n\tv86 = v101 + 1;\n\tv159 = v86 < v44;\n\tv80 = ~v159;\n\tv83 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_FFFFFFFF;\n\tv87 = 0xD;\n\tv88 = v39;\n\tv89 = 0x8909C4(v88, v45, v87, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0049;\nL_003C:\n\tv160 = *([v100 @ X11_v5]);\n\tv161 = v160 + 0xD;\n\tv162 = v161 << 4;\n\tv163 = v42 + v162;\n\tv164 = v163 + 0x130;\nL_0049:\n\tinterfaceTailCallResult = Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams::GetOkIds(this._trackerParams);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return _trackerParams.GetOkIds();
			}
			[Token(Token = "0x6000040")]
			[Address(RVA = "0x1625E50", Offset = "0x1625E50", Length = "0xC8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1F0D2D0]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A348]) = v41;\nL_0015:\n\tv42 = this._trackerParams;\n\tv45 = *([v42 @ X20_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams)]);\n\tv49 = *([v45 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]) == 0;\n\tif (v49) goto L_003C;\n\tv103 = *([v45 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]) + 8;\nL_0027:\n\tv109 = *([v103 @ X11_v5-8]) == Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams;\n\tif (v109) goto L_003F;\n\tv104 = v104 + 1;\n\tv166 = v104 < *([v45 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]);\n\tv83 = ~v166;\n\tv103 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_0027;\nL_003C:\n\tv173 = 0x8909C4(v42, Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams, 0x20, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0043;\nL_003F:\n\tv168 = *([v103 @ X11_v5]) + 0x20;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv173 = v170 + 0x130;\nL_0043:\n\tv117 = *([v173 @ X0_v4]);\n\tv124 = *([v173 @ X0_v4+8]);\n\t// 77 IndirectJump v117 @ X3_v1, v42 @ X20_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), v42 @ X20_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), value @ X1 (System.String[]), v124 @ X2_v2, v117 @ X3_v1, v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_000d: Expected I, but got O
				//IL_0151: Expected O, but got I
				//IL_0048: Expected O, but got I
				//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
				//IL_00cf: Expected O, but got Unknown
				//IL_00ec: Expected O, but got I
				//IL_00fb: Expected O, but got I
				//IL_0094: Expected O, but got I
				ITrackerParams trackerParams = _trackerParams;
				IntPtr intPtr = (IntPtr)trackerParams;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00ad;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ITrackerParams))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v45 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00ad;
				}
				object obj2 = obj + 32;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_0139;
				IL_00ad:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_0139;
				IL_0139:
				object obj5 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X0_v4+8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v117 @ X3_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x1700001B")]
		public string Phone
		{
			[Token(Token = "0x6000041")]
			[Address(RVA = "0x1625F18", Offset = "0x1625F18", Length = "0xD0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F0EEC0]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A349]) = v38;\nL_0013:\n\tv39 = this._trackerParams;\n\tv42 = *([v39 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams)]);\n\tv46 = *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]) == 0;\n\tif (v46) goto L_003A;\n\tv100 = *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]) + 8;\nL_0025:\n\tv106 = *([v100 @ X11_v5-8]) == Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams;\n\tif (v106) goto L_003D;\n\tv101 = v101 + 1;\n\tv160 = v101 < *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]);\n\tv80 = ~v160;\n\tv100 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_0025;\nL_003A:\n\tv166 = 0x8909C4(v39, Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams, 0xE, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0044;\nL_003D:\n\tv162 = *([v100 @ X11_v5]) + 0xE;\n\tv163 = v162 << 4;\n\tv164 = v42 + v163;\n\tv166 = v164 + 0x130;\nL_0044:\n\t*([v166 @ X0_v4])(v171, v39, *([v166 @ X0_v4+8]), 0xE, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv151 = v171 == 0;\n\tif (v151) goto L_0050;\n\treturnVal2 = System.Linq.Enumerable::FirstOrDefault(v171);\nL_0050:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_000d: Expected I, but got O
				//IL_0048: Expected O, but got I
				//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
				//IL_00cf: Expected O, but got Unknown
				//IL_00ec: Expected O, but got I
				//IL_00fb: Expected O, but got I
				//IL_0094: Expected O, but got I
				ITrackerParams trackerParams = _trackerParams;
				IntPtr intPtr = (IntPtr)trackerParams;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00ad;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ITrackerParams))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
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
				goto IL_0150;
				IL_00ad:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_0150;
				IL_0150:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v166 @ X0_v4] (should have been resolved before IL gen)");
				IEnumerable<string> enumerable = default(IEnumerable<string>);
				bool flag3 = enumerable == null;
				string result = (string)(object)enumerable;
				if (!flag3)
				{
					result = enumerable.FirstOrDefault();
				}
				return result;
			}
			[Token(Token = "0x6000042")]
			[Address(RVA = "0x1625FE8", Offset = "0x1625FE8", Length = "0x12C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv120 = *([202A34A]);\n\tgoto L_0015;\n\tv22 = *([1EEF6F0]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A34A]) = v41;\nL_0015:\n\tv42 = this._trackerParams;\n\tv43 = value == 0;\n\tif (v43) goto L_0053;\n\t// 28 NewArr v48 @ X0_v13 (System.String[]), typeof(System.String[]), 1\n\tv76 = *([v48 @ X0_v13 (System.String[])]);\n\tv57 = \"il2cpp_codegen_object_is_inst\"(value, *([v76 @ X8_v13+40]), methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv156 = v57 == 0;\n\tif (v156) goto L_0069;\n\tv48[0] = value;\nL_002D:\n\tv120 = *([v42 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams)]);\n\tv75 = *([v120 @ X8_v4 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]) == 0;\n\tif (v75) goto L_0050;\n\tv109 = *([v120 @ X8_v4 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]) + 8;\nL_003B:\n\tv99 = *([v109 @ X11_v2-8]) == Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams;\n\tif (v99) goto L_0059;\n\tv116 = v116 + 1;\n\tv233 = v116 < *([v120 @ X8_v4 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]);\n\tv148 = ~v233;\n\tv109 = v109 + 0x10;\n\tv132 = ~v148;\n\tif (v132) goto L_003B;\nL_0050:\n\tv179 = 0x8909C4(this._trackerParams, Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams, 0x21, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0067;\nL_0053:\n\tv50 = this._trackerParams == 0;\n\tv51 = ~v50;\n\tif (v51) goto L_002D;\n\tthrow System.NullReferenceException;\nL_0059:\n\tv123 = *([v109 @ X11_v2]) + 0x21;\n\tv124 = v123 << 4;\n\tv125 = v120 + v124;\n\tv179 = v125 + 0x130;\nL_0067:\n\t// 103 IndirectJump [v179 @ X0_v2], this._trackerParams (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), this._trackerParams (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), v182 @ X20_v2 (System.Int32), [v179 @ X0_v2+8], [v179 @ X0_v2], v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tv78 = new System.NullReferenceException();\nL_0069:\n\tv161 = new System.ArrayTypeMismatchException();\n\tgoto L_006E;\n\tv234 = new System.IndexOutOfRangeException();\nL_006E:\n\tthrow v236;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0083: Expected I, but got O
				//IL_00be: Expected O, but got I
				//IL_0076: Expected I4, but got O
				//IL_017a: Unknown result type (might be due to invalid IL or missing references)
				//IL_017f: Expected O, but got Unknown
				//IL_019c: Expected O, but got I
				//IL_01ab: Expected O, but got I
				//IL_010a: Expected O, but got I
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [202A34A]");
				IntPtr intPtr = (IntPtr)0;
				ITrackerParams trackerParams = _trackerParams;
				if (value != null)
				{
					string[] array = new string[1];
					object obj = array;
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_codegen_object_is_inst\"");
					object obj2 = default(object);
					if (obj2 == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						ArrayTypeMismatchException ex2 = default(ArrayTypeMismatchException);
						throw ex2;
					}
					array[0] = value;
					int num = (int)array;
				}
				else
				{
					bool flag = _trackerParams == null;
					bool flag2 = !flag;
					int num = 0;
					if (!flag2)
					{
						throw new NullReferenceException();
					}
				}
				intPtr = (IntPtr)trackerParams;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ X8_v4 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_0123;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ X8_v4 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]");
				object obj3 = 0L + 8L;
				int num2 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ X11_v2-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ITrackerParams))
					{
						break;
					}
					num2++;
					int num3 = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ X8_v4 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
					bool flag3 = (long)num3 < 0L;
					bool flag4 = !flag3;
					obj3 = (long)(IntPtr)obj3 + 16L;
					if (!flag4)
					{
						continue;
					}
					goto IL_0123;
				}
				object obj4 = obj3 + 33;
				int num4 = (int)((long)(IntPtr)obj4 << 4);
				object obj5 = (long)intPtr + (long)num4;
				object obj6 = (long)(IntPtr)obj5 + 304L;
				goto IL_0214;
				IL_0123:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_0214;
				IL_0214:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v179 @ X0_v2] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-30), the output could be wrong!");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-30), the output could be wrong!");
			}
		}

		[Token(Token = "0x1700001C")]
		public string[] Phones
		{
			[Token(Token = "0x6000043")]
			[Address(RVA = "0x1626114", Offset = "0x1626114", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EBFFA8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A34B]) = v38;\nL_0013:\n\tv39 = this._trackerParams;\n\tv42 = *([v39 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams)]);\n\tv46 = *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]) == 0;\n\tif (v46) goto L_003A;\n\tv100 = *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]) + 8;\nL_0025:\n\tv106 = *([v100 @ X11_v5-8]) == Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams;\n\tif (v106) goto L_003D;\n\tv101 = v101 + 1;\n\tv159 = v101 < *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]);\n\tv80 = ~v159;\n\tv100 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_0025;\nL_003A:\n\tv166 = 0x8909C4(v39, Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams, 0xE, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0041;\nL_003D:\n\tv161 = *([v100 @ X11_v5]) + 0xE;\n\tv162 = v161 << 4;\n\tv163 = v42 + v162;\n\tv166 = v163 + 0x130;\nL_0041:\n\tv119 = *([v166 @ X0_v4]);\n\tv141 = *([v166 @ X0_v4+8]);\n\t// 73 IndirectJump v119 @ X2_v2, v39 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), v39 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), v141 @ X1_v2, v119 @ X2_v2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_000d: Expected I, but got O
				//IL_0151: Expected O, but got I
				//IL_0048: Expected O, but got I
				//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
				//IL_00cf: Expected O, but got Unknown
				//IL_00ec: Expected O, but got I
				//IL_00fb: Expected O, but got I
				//IL_0094: Expected O, but got I
				ITrackerParams trackerParams = _trackerParams;
				IntPtr intPtr = (IntPtr)trackerParams;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00ad;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ITrackerParams))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
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
				goto IL_0139;
				IL_00ad:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_0139;
				IL_0139:
				object obj5 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ X0_v4+8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v119 @ X2_v2 (should have been resolved before IL gen)");
				return null;
			}
			[Token(Token = "0x6000044")]
			[Address(RVA = "0x16261CC", Offset = "0x16261CC", Length = "0xC8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1EFDEB0]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A34C]) = v41;\nL_001E:\n\tgoto L_004D;\n\tv52 = *([v45 @ X8_v3+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v103 @ X11_v5-8]);\n\tv109 = v56 == v48;\n\tif (v109) goto L_003E;\n\tv89 = v104 + 1;\n\tv166 = v89 < v47;\n\tv83 = ~v166;\n\tv86 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = 0x21;\n\tv91 = v42;\n\tv92 = 0x8909C4(v91, v48, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004D;\nL_003E:\n\tv167 = *([v103 @ X11_v5]);\n\tv168 = v167 + 0x21;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv171 = v170 + 0x130;\nL_004D:\n\tMycom.Tracker.Unity.Internal.Interfaces.ITrackerParams::SetPhones(this._trackerParams, value);\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_trackerParams.SetPhones(value);
			}
		}

		[Token(Token = "0x1700001D")]
		public string VkId
		{
			[Token(Token = "0x6000045")]
			[Address(RVA = "0x1626294", Offset = "0x1626294", Length = "0xD0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EAF948]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A34D]) = v38;\nL_0013:\n\tv39 = this._trackerParams;\n\tv42 = *([v39 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams)]);\n\tv46 = *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]) == 0;\n\tif (v46) goto L_003A;\n\tv100 = *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]) + 8;\nL_0025:\n\tv106 = *([v100 @ X11_v5-8]) == Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams;\n\tif (v106) goto L_003D;\n\tv101 = v101 + 1;\n\tv160 = v101 < *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]);\n\tv80 = ~v160;\n\tv100 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_0025;\nL_003A:\n\tv166 = 0x8909C4(v39, Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams, 0xF, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0044;\nL_003D:\n\tv162 = *([v100 @ X11_v5]) + 0xF;\n\tv163 = v162 << 4;\n\tv164 = v42 + v163;\n\tv166 = v164 + 0x130;\nL_0044:\n\t*([v166 @ X0_v4])(v171, v39, *([v166 @ X0_v4+8]), 0xF, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv151 = v171 == 0;\n\tif (v151) goto L_0050;\n\treturnVal2 = System.Linq.Enumerable::FirstOrDefault(v171);\nL_0050:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_000d: Expected I, but got O
				//IL_0048: Expected O, but got I
				//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
				//IL_00cf: Expected O, but got Unknown
				//IL_00ec: Expected O, but got I
				//IL_00fb: Expected O, but got I
				//IL_0094: Expected O, but got I
				ITrackerParams trackerParams = _trackerParams;
				IntPtr intPtr = (IntPtr)trackerParams;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00ad;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ITrackerParams))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
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
				goto IL_0150;
				IL_00ad:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_0150;
				IL_0150:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v166 @ X0_v4] (should have been resolved before IL gen)");
				IEnumerable<string> enumerable = default(IEnumerable<string>);
				bool flag3 = enumerable == null;
				string result = (string)(object)enumerable;
				if (!flag3)
				{
					result = enumerable.FirstOrDefault();
				}
				return result;
			}
			[Token(Token = "0x6000046")]
			[Address(RVA = "0x1626364", Offset = "0x1626364", Length = "0x12C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv120 = *([202A34E]);\n\tgoto L_0015;\n\tv22 = *([1F08B98]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A34E]) = v41;\nL_0015:\n\tv42 = this._trackerParams;\n\tv43 = value == 0;\n\tif (v43) goto L_0053;\n\t// 28 NewArr v48 @ X0_v13 (System.String[]), typeof(System.String[]), 1\n\tv76 = *([v48 @ X0_v13 (System.String[])]);\n\tv57 = \"il2cpp_codegen_object_is_inst\"(value, *([v76 @ X8_v13+40]), methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv156 = v57 == 0;\n\tif (v156) goto L_0069;\n\tv48[0] = value;\nL_002D:\n\tv120 = *([v42 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams)]);\n\tv75 = *([v120 @ X8_v4 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]) == 0;\n\tif (v75) goto L_0050;\n\tv109 = *([v120 @ X8_v4 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]) + 8;\nL_003B:\n\tv99 = *([v109 @ X11_v2-8]) == Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams;\n\tif (v99) goto L_0059;\n\tv116 = v116 + 1;\n\tv233 = v116 < *([v120 @ X8_v4 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]);\n\tv148 = ~v233;\n\tv109 = v109 + 0x10;\n\tv132 = ~v148;\n\tif (v132) goto L_003B;\nL_0050:\n\tv179 = 0x8909C4(this._trackerParams, Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams, 0x25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0067;\nL_0053:\n\tv50 = this._trackerParams == 0;\n\tv51 = ~v50;\n\tif (v51) goto L_002D;\n\tthrow System.NullReferenceException;\nL_0059:\n\tv123 = *([v109 @ X11_v2]) + 0x25;\n\tv124 = v123 << 4;\n\tv125 = v120 + v124;\n\tv179 = v125 + 0x130;\nL_0067:\n\t// 103 IndirectJump [v179 @ X0_v2], this._trackerParams (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), this._trackerParams (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), v182 @ X20_v2 (System.Int32), [v179 @ X0_v2+8], [v179 @ X0_v2], v27 @ X4, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tv78 = new System.NullReferenceException();\nL_0069:\n\tv161 = new System.ArrayTypeMismatchException();\n\tgoto L_006E;\n\tv234 = new System.IndexOutOfRangeException();\nL_006E:\n\tthrow v236;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0083: Expected I, but got O
				//IL_00be: Expected O, but got I
				//IL_0076: Expected I4, but got O
				//IL_017a: Unknown result type (might be due to invalid IL or missing references)
				//IL_017f: Expected O, but got Unknown
				//IL_019c: Expected O, but got I
				//IL_01ab: Expected O, but got I
				//IL_010a: Expected O, but got I
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [202A34E]");
				IntPtr intPtr = (IntPtr)0;
				ITrackerParams trackerParams = _trackerParams;
				if (value != null)
				{
					string[] array = new string[1];
					object obj = array;
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_codegen_object_is_inst\"");
					object obj2 = default(object);
					if (obj2 == null)
					{
						ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
						ArrayTypeMismatchException ex2 = default(ArrayTypeMismatchException);
						throw ex2;
					}
					array[0] = value;
					int num = (int)array;
				}
				else
				{
					bool flag = _trackerParams == null;
					bool flag2 = !flag;
					int num = 0;
					if (!flag2)
					{
						throw new NullReferenceException();
					}
				}
				intPtr = (IntPtr)trackerParams;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ X8_v4 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_0123;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ X8_v4 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]");
				object obj3 = 0L + 8L;
				int num2 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ X11_v2-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ITrackerParams))
					{
						break;
					}
					num2++;
					int num3 = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ X8_v4 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
					bool flag3 = (long)num3 < 0L;
					bool flag4 = !flag3;
					obj3 = (long)(IntPtr)obj3 + 16L;
					if (!flag4)
					{
						continue;
					}
					goto IL_0123;
				}
				object obj4 = obj3 + 37;
				int num4 = (int)((long)(IntPtr)obj4 << 4);
				object obj5 = (long)intPtr + (long)num4;
				object obj6 = (long)(IntPtr)obj5 + 304L;
				goto IL_0214;
				IL_0123:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_0214;
				IL_0214:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v179 @ X0_v2] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-30), the output could be wrong!");
				Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-30), the output could be wrong!");
			}
		}

		[Token(Token = "0x1700001E")]
		public string[] VkIds
		{
			[Token(Token = "0x6000047")]
			[Address(RVA = "0x1626490", Offset = "0x1626490", Length = "0xB8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EFC480]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A34F]) = v38;\nL_0013:\n\tv39 = this._trackerParams;\n\tv42 = *([v39 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams)]);\n\tv46 = *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]) == 0;\n\tif (v46) goto L_003A;\n\tv100 = *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]) + 8;\nL_0025:\n\tv106 = *([v100 @ X11_v5-8]) == Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams;\n\tif (v106) goto L_003D;\n\tv101 = v101 + 1;\n\tv159 = v101 < *([v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]);\n\tv80 = ~v159;\n\tv100 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_0025;\nL_003A:\n\tv166 = 0x8909C4(v39, Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams, 0xF, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0041;\nL_003D:\n\tv161 = *([v100 @ X11_v5]) + 0xF;\n\tv162 = v161 << 4;\n\tv163 = v42 + v162;\n\tv166 = v163 + 0x130;\nL_0041:\n\tv119 = *([v166 @ X0_v4]);\n\tv141 = *([v166 @ X0_v4+8]);\n\t// 73 IndirectJump v119 @ X2_v2, v39 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), v39 @ X19_v2 (Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams), v141 @ X1_v2, v119 @ X2_v2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_000d: Expected I, but got O
				//IL_0151: Expected O, but got I
				//IL_0048: Expected O, but got I
				//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
				//IL_00cf: Expected O, but got Unknown
				//IL_00ec: Expected O, but got I
				//IL_00fb: Expected O, but got I
				//IL_0094: Expected O, but got I
				ITrackerParams trackerParams = _trackerParams;
				IntPtr intPtr = (IntPtr)trackerParams;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00ad;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ITrackerParams))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<Mycom.Tracker.Unity.Internal.Interfaces.ITrackerParams>)+126]");
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
				goto IL_0139;
				IL_00ad:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_0139;
				IL_0139:
				object obj5 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v166 @ X0_v4+8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v119 @ X2_v2 (should have been resolved before IL gen)");
				return null;
			}
			[Token(Token = "0x6000048")]
			[Address(RVA = "0x1626548", Offset = "0x1626548", Length = "0xC8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1EEDCE0]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A350]) = v41;\nL_001E:\n\tgoto L_004D;\n\tv52 = *([v45 @ X8_v3+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v103 @ X11_v5-8]);\n\tv109 = v56 == v48;\n\tif (v109) goto L_003E;\n\tv89 = v104 + 1;\n\tv166 = v89 < v47;\n\tv83 = ~v166;\n\tv86 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = 0x25;\n\tv91 = v42;\n\tv92 = 0x8909C4(v91, v48, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004D;\nL_003E:\n\tv167 = *([v103 @ X11_v5]);\n\tv168 = v167 + 0x25;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv171 = v170 + 0x130;\nL_004D:\n\tMycom.Tracker.Unity.Internal.Interfaces.ITrackerParams::SetVkIds(this._trackerParams, value);\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_trackerParams.SetVkIds(value);
			}
		}

		[Token(Token = "0x1700001F")]
		public string ProxyHost
		{
			[Token(Token = "0x6000049")]
			[Address(RVA = "0x1626610", Offset = "0x1626610", Length = "0xC8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = *([1EB5A28]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, value, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A351]) = v41;\nL_001E:\n\tgoto L_004D;\n\tv52 = *([v45 @ X8_v3+B0]);\n\tv53 = 0;\n\tv54 = v52 + 8;\n\tv56 = *([v103 @ X11_v5-8]);\n\tv109 = v56 == v48;\n\tif (v109) goto L_003E;\n\tv89 = v104 + 1;\n\tv166 = v89 < v47;\n\tv83 = ~v166;\n\tv86 = v103 + 0x10;\n\tv59 = ~v83;\n\tif (v59) goto L_FFFFFFFF;\n\tv90 = 0x26;\n\tv91 = v42;\n\tv92 = 0x8909C4(v91, v48, v90, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_004D;\nL_003E:\n\tv167 = *([v103 @ X11_v5]);\n\tv168 = v167 + 0x26;\n\tv169 = v168 << 4;\n\tv170 = v45 + v169;\n\tv171 = v170 + 0x130;\nL_004D:\n\tMycom.Tracker.Unity.Internal.Interfaces.ITrackerParams::SetProxyHost(this._trackerParams, value);\n\tthrow System.NullReferenceException;\n\treturn;\n// 50 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				_trackerParams.SetProxyHost(value);
			}
		}

		[Token(Token = "0x600004A")]
		[Address(RVA = "0x161C538", Offset = "0x161C538", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis._trackerParams = trackerParams;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal MyTrackerParams(ITrackerParams trackerParams)
		{
			_trackerParams = trackerParams;
		}
	}
}
