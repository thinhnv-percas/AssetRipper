using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Obi
{
	[AttributeAttribute(Type = typeof(DefaultMemberAttribute), RVA = "0x7443D4", Offset = "0x7443D4")]
	[Token(Token = "0x200002E")]
	public class CastedList<TTo, TFrom> : IList<TTo>, ICollection<TTo>, IEnumerable<TTo>, IEnumerable
	{
		[Token(Token = "0x40000B6")]
		[FieldOffset(Offset = "0x0")]
		public IList<TFrom> BaseList;

		[Token(Token = "0x1700003E")]
		public int Count
		{
			[Token(Token = "0x6000262")]
			[Address(RVA = "0x10A54D0", Offset = "0x10A54D0", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.BaseList;\n\tgoto L_0013;\n\tv37 = v16;\n\tv38 = 0x8907BC(v37, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0013:\n\tv40 = *([v10 @ X19_v1 (System.Collections.Generic.IList`1<TFrom>)]);\n\tv42 = *([v40 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]) == 0;\n\tif (v42) goto L_0035;\n\tv145 = *([v40 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+B0]) + 8;\nL_001F:\n\tv150 = *([v145 @ X11_v5-8]) == Il2CppClass<System.Collections.Generic.ICollection`1<TFrom>>;\n\tif (v150) goto L_0038;\n\tv144 = v144 + 1;\n\tv155 = v144 < *([v40 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]);\n\tv74 = ~v155;\n\tv145 = v145 + 0x10;\n\tv50 = ~v74;\n\tif (v50) goto L_001F;\nL_0035:\n\tv162 = 0x8909C4(v10, Il2CppClass<System.Collections.Generic.ICollection`1<TFrom>>, 0, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tgoto L_003B;\nL_0038:\n\tv157 = *([v145 @ X11_v5]) << 4;\n\tv158 = v40 + v157;\n\tv162 = v158 + 0x130;\nL_003B:\n\tv94 = *([v162 @ X0_v4]);\n\tv96 = *([v162 @ X0_v4+8]);\n\t// 67 IndirectJump v94 @ X2_v2, v10 @ X19_v1 (System.Collections.Generic.IList`1<TFrom>), v10 @ X19_v1 (System.Collections.Generic.IList`1<TFrom>), v96 @ X1_v2, v94 @ X2_v2, v24 @ X3, v25 @ X4, v26 @ X5, v27 @ X6, v28 @ X7, v29 @ V0, v30 @ V1, v31 @ V2, v32 @ V3, v33 @ V4, v34 @ V5, v35 @ V6, v36 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_001c: Expected I, but got O
				//IL_0135: Expected O, but got I
				//IL_0057: Expected O, but got I
				//IL_00d9: Expected I4, but got O
				//IL_00e7: Expected O, but got I
				//IL_00f6: Expected O, but got I
				//IL_00a3: Expected O, but got I
				IList<TFrom> baseList = BaseList;
				IntPtr intPtr = (IntPtr)baseList;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00bc;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00bc;
				}
				int num3 = obj << 4;
				object obj2 = (long)intPtr + (long)num3;
				object obj3 = (long)(IntPtr)obj2 + 304L;
				goto IL_011d;
				IL_00bc:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_011d;
				IL_011d:
				object obj4 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ X0_v4+8]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v94 @ X2_v2 (should have been resolved before IL gen)");
				return 0;
			}
		}

		[Token(Token = "0x1700003F")]
		public bool IsReadOnly
		{
			[Token(Token = "0x6000263")]
			[Address(RVA = "0x10A5570", Offset = "0x10A5570", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.BaseList;\n\tgoto L_0013;\n\tv37 = v16;\n\tv38 = 0x8907BC(v37, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0013:\n\tv40 = *([v10 @ X19_v1 (System.Collections.Generic.IList`1<TFrom>)]);\n\tv42 = *([v40 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]) == 0;\n\tif (v42) goto L_0035;\n\tv145 = *([v40 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+B0]) + 8;\nL_001F:\n\tv150 = *([v145 @ X11_v5-8]) == Il2CppClass<System.Collections.Generic.ICollection`1<TFrom>>;\n\tif (v150) goto L_0038;\n\tv144 = v144 + 1;\n\tv155 = v144 < *([v40 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]);\n\tv74 = ~v155;\n\tv145 = v145 + 0x10;\n\tv50 = ~v74;\n\tif (v50) goto L_001F;\nL_0035:\n\tv163 = 0x8909C4(v10, Il2CppClass<System.Collections.Generic.ICollection`1<TFrom>>, 1, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tgoto L_003C;\nL_0038:\n\tv157 = *([v145 @ X11_v5]) + 1;\n\tv158 = v157 << 4;\n\tv159 = v40 + v158;\n\tv163 = v159 + 0x130;\nL_003C:\n\tv96 = *([v163 @ X0_v4]);\n\tv94 = *([v163 @ X0_v4+8]);\n\t// 68 IndirectJump v96 @ X2_v2, v10 @ X19_v1 (System.Collections.Generic.IList`1<TFrom>), v10 @ X19_v1 (System.Collections.Generic.IList`1<TFrom>), v94 @ X1_v2, v96 @ X2_v2, v24 @ X3, v25 @ X4, v26 @ X5, v27 @ X6, v28 @ X7, v29 @ V0, v30 @ V1, v31 @ V2, v32 @ V3, v33 @ V4, v34 @ V5, v35 @ V6, v36 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_001c: Expected I, but got O
				//IL_0144: Expected O, but got I
				//IL_0057: Expected O, but got I
				//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
				//IL_00d9: Expected O, but got Unknown
				//IL_00f6: Expected O, but got I
				//IL_0105: Expected O, but got I
				//IL_00a3: Expected O, but got I
				IList<TFrom> baseList = BaseList;
				IntPtr intPtr = (IntPtr)baseList;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00bc;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00bc;
				}
				object obj2 = obj + 1;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_012c;
				IL_00bc:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_012c;
				IL_012c:
				object obj5 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ X0_v4+8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v96 @ X2_v2 (should have been resolved before IL gen)");
				return false;
			}
		}

		[Token(Token = "0x17000040")]
		public TTo Item
		{
			[Token(Token = "0x6000269")]
			[Address(RVA = "0x10A5AD0", Offset = "0x10A5AD0", Length = "0xFC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.BaseList;\n\tgoto L_0017;\n\tv43 = v23;\n\tv44 = 0x8907BC(v43, index, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0017:\n\tv46 = *([v14 @ X21_v1 (System.Collections.Generic.IList`1<TFrom>)]);\n\tv48 = *([v46 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]) == 0;\n\tif (v48) goto L_003A;\n\tv156 = *([v46 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+B0]) + 8;\nL_0023:\n\tv161 = *([v156 @ X11_v5-8]) == Il2CppClass<System.Collections.Generic.IList`1<TFrom>>;\n\tif (v161) goto L_003C;\n\tv155 = v155 + 1;\n\tv166 = v155 < *([v46 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]);\n\tv80 = ~v166;\n\tv156 = v156 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_0023;\nL_003A:\n\tgoto L_0043;\nL_003C:\n\t;\nL_0043:\n\tv178 = System.Collections.Generic.IList`1<TFrom>::get_Item(v14, index);\n\tgoto L_004F;\n\tv186 = v182;\n\tv187 = 0x8907BC(v186, v177, v100, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_004F:\n\tv189 = v178 == 0;\n\tif (v189) goto L_FFFFFFFF;\n\t// 83 IsInst returnVal2 @ X0_v8 (TTo), typeof(TTo), v178 @ X0_v6\n\tv200 = returnVal2 == 0;\n\tv198 = ~v200;\n\tif (v198) goto L_0062;\n\tthrow System.InvalidCastException;\nL_0062:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_001c: Expected I, but got O
				//IL_0057: Expected O, but got I
				//IL_00a3: Expected O, but got I
				IList<TFrom> baseList = BaseList;
				IntPtr intPtr = (IntPtr)baseList;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+B0]");
					object obj = 0L + 8L;
					int num = 0;
					bool flag2;
					do
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v156 @ X11_v5-8]");
						if ((IntPtr)0 != (IntPtr)0)
						{
							num++;
							int num2 = num;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]");
							bool flag = (long)num2 < 0L;
							flag2 = !flag;
							obj = (long)(IntPtr)obj + 16L;
							continue;
						}
						break;
					}
					while (!flag2);
				}
				object obj2 = baseList.get_Item(index);
				TTo val;
				if (obj2 != null)
				{
					val = (TTo)((obj2 is TTo) ? obj2 : null);
					if (val == null)
					{
						throw new InvalidCastException();
					}
				}
				else
				{
					val = (TTo)null;
				}
				return val;
			}
			[Token(Token = "0x600026A")]
			[Address(RVA = "0x10A5BCC", Offset = "0x10A5BCC", Length = "0x10C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = this.BaseList;\n\tgoto L_0021;\n\tv48 = v29;\n\tv49 = 0x8907BC(v48, index, value, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv58 = Il2CppClass<Obi.CastedList`2>;\n\tv52 = Il2CppRgctx<Obi.CastedList`2>;\nL_0021:\n\tgoto L_0024;\n\tv59 = v53;\n\tv60 = 0x8907BC(v59, index, value, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0024:\n\tv62 = value == 0;\n\tif (v62) goto L_FFFFFFFF;\n\t// 40 IsInst v138 @ X0_v13 (System.Int32), typeof(TFrom), value @ X2 (TTo)\n\tv148 = v138 == 0;\n\tv144 = ~v148;\n\tif (v144) goto L_0031;\n\tthrow System.InvalidCastException;\nL_0031:\n\tv153 = *([v18 @ X20_v1 (System.Collections.Generic.IList`1<TFrom>)]);\n\tv125 = *([v153 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]) == 0;\n\tif (v125) goto L_0053;\n\tv198 = *([v153 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+B0]) + 8;\nL_003D:\n\tv203 = *([v198 @ X11_v5-8]) == Il2CppClass<System.Collections.Generic.IList`1<TFrom>>;\n\tif (v203) goto L_0056;\n\tv197 = v197 + 1;\n\tv208 = v197 < *([v153 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]);\n\tv178 = ~v208;\n\tv198 = v198 + 0x10;\n\tv162 = ~v178;\n\tif (v162) goto L_003D;\nL_0053:\n\tv216 = 0x8909C4(v18, Il2CppClass<System.Collections.Generic.IList`1<TFrom>>, 1, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_005A;\nL_0056:\n\tv210 = *([v198 @ X11_v5]) + 1;\n\tv211 = v210 << 4;\n\tv212 = v153 + v211;\n\tv216 = v212 + 0x130;\nL_005A:\n\tv68 = *([v216 @ X0_v6]);\n\tv66 = *([v216 @ X0_v6+8]);\n\t// 104 IndirectJump v68 @ X4_v1, v18 @ X20_v1 (System.Collections.Generic.IList`1<TFrom>), v18 @ X20_v1 (System.Collections.Generic.IList`1<TFrom>), index @ X1 (System.Int32), v152 @ X22_v2 (System.Int32), v66 @ X3_v1, v68 @ X4_v1, v37 @ X5, v38 @ X6, v39 @ X7, v40 @ V0, v41 @ V1, v42 @ V2, v43 @ V3, v44 @ V4, v45 @ V5, v46 @ V6, v47 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			set
			{
				//IL_0150: Expected I, but got O
				//IL_003e: Expected I4, but got O
				//IL_01af: Expected O, but got I
				//IL_0090: Expected O, but got I
				//IL_010d: Unknown result type (might be due to invalid IL or missing references)
				//IL_0112: Expected O, but got Unknown
				//IL_012f: Expected O, but got I
				//IL_013e: Expected O, but got I
				//IL_00dc: Expected O, but got I
				IList<TFrom> baseList = BaseList;
				if (value != null)
				{
					if ((int)((value is TFrom) ? value : null) == 0)
					{
						throw new InvalidCastException();
					}
				}
				else
				{
					int num = 0;
				}
				IntPtr intPtr = (IntPtr)baseList;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00f5;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+B0]");
				object obj = 0L + 8L;
				int num2 = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ X11_v5-8]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						break;
					}
					num2++;
					int num3 = num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]");
					bool flag = (long)num3 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_00f5;
				}
				object obj2 = obj + 1;
				int num4 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num4;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_0197;
				IL_00f5:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
				goto IL_0197;
				IL_0197:
				object obj5 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ X0_v6+8]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v68 @ X4_v1 (should have been resolved before IL gen)");
			}
		}

		[Token(Token = "0x600025F")]
		[Address(RVA = "0x10A5300", Offset = "0x10A5300", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.BaseList = baseList;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CastedList(IList<TFrom> baseList)
		{
			BaseList = baseList;
		}

		[Token(Token = "0x6000260")]
		[Address(RVA = "0x10A5338", Offset = "0x10A5338", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.BaseList;\n\tgoto L_0013;\n\tv37 = v16;\n\tv38 = 0x8907BC(v37, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0013:\n\tv40 = *([v10 @ X19_v1 (System.Collections.Generic.IList`1<TFrom>)]);\n\tv42 = *([v40 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]) == 0;\n\tif (v42) goto L_0035;\n\tv145 = *([v40 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+B0]) + 8;\nL_001F:\n\tv150 = *([v145 @ X11_v5-8]) == Il2CppClass<System.Collections.Generic.IEnumerable`1<TFrom>>;\n\tif (v150) goto L_0038;\n\tv144 = v144 + 1;\n\tv155 = v144 < *([v40 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]);\n\tv74 = ~v155;\n\tv145 = v145 + 0x10;\n\tv50 = ~v74;\n\tif (v50) goto L_001F;\nL_0035:\n\tv162 = 0x8909C4(v10, Il2CppClass<System.Collections.Generic.IEnumerable`1<TFrom>>, 0, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tgoto L_003B;\nL_0038:\n\tv157 = *([v145 @ X11_v5]) << 4;\n\tv158 = v40 + v157;\n\tv162 = v158 + 0x130;\nL_003B:\n\tv94 = *([v162 @ X0_v4]);\n\tv96 = *([v162 @ X0_v4+8]);\n\t// 67 IndirectJump v94 @ X2_v2, v10 @ X19_v1 (System.Collections.Generic.IList`1<TFrom>), v10 @ X19_v1 (System.Collections.Generic.IList`1<TFrom>), v96 @ X1_v2, v94 @ X2_v2, v24 @ X3, v25 @ X4, v26 @ X5, v27 @ X6, v28 @ X7, v29 @ V0, v30 @ V1, v31 @ V2, v32 @ V3, v33 @ V4, v34 @ V5, v35 @ V6, v36 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		IEnumerator IEnumerable.GetEnumerator()
		{
			//IL_001c: Expected I, but got O
			//IL_0135: Expected O, but got I
			//IL_0057: Expected O, but got I
			//IL_00d9: Expected I4, but got O
			//IL_00e7: Expected O, but got I
			//IL_00f6: Expected O, but got I
			//IL_00a3: Expected O, but got I
			IList<TFrom> baseList = BaseList;
			IntPtr intPtr = (IntPtr)baseList;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00bc;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00bc;
			}
			int num3 = obj << 4;
			object obj2 = (long)intPtr + (long)num3;
			object obj3 = (long)(IntPtr)obj2 + 304L;
			goto IL_011d;
			IL_00bc:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_011d;
			IL_011d:
			object obj4 = obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ X0_v4+8]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v94 @ X2_v2 (should have been resolved before IL gen)");
			return null;
		}

		[Token(Token = "0x6000261")]
		[Address(RVA = "0x10A53D8", Offset = "0x10A53D8", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.BaseList;\n\tgoto L_0015;\n\tv40 = v19;\n\tv41 = 0x8907BC(v40, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0015:\n\tv43 = *([v12 @ X20_v1 (System.Collections.Generic.IList`1<TFrom>)]);\n\tv45 = *([v43 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]) == 0;\n\tif (v45) goto L_0038;\n\tv151 = *([v43 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+B0]) + 8;\nL_0021:\n\tv156 = *([v151 @ X11_v5-8]) == Il2CppClass<System.Collections.Generic.IEnumerable`1<TFrom>>;\n\tif (v156) goto L_003A;\n\tv150 = v150 + 1;\n\tv161 = v150 < *([v43 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]);\n\tv77 = ~v161;\n\tv151 = v151 + 0x10;\n\tv53 = ~v77;\n\tif (v53) goto L_0021;\nL_0038:\n\tgoto L_0040;\nL_003A:\n\t;\nL_0040:\n\tv173 = System.Collections.Generic.IEnumerable`1<TFrom>::GetEnumerator(v12);\n\tgoto L_004D;\n\tv181 = v177;\n\tv182 = 0x8907BC(v181, v171, v166, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_004D:\n\tv185 = new Il2CppClass<Obi.CastedEnumerator`2<TTo, TFrom>>();\n\tv189 = Obi.CastedEnumerator`2<TTo, TFrom>::.ctor(v185, v173);\n\treturn v185;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IEnumerator<TTo> GetEnumerator()
		{
			//IL_001c: Expected I, but got O
			//IL_0057: Expected O, but got I
			//IL_00a3: Expected O, but got I
			IList<TFrom> baseList = BaseList;
			IntPtr intPtr = (IntPtr)baseList;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]");
			if ((IntPtr)0 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				bool flag2;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ X11_v5-8]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]");
						bool flag = (long)num2 < 0L;
						flag2 = !flag;
						obj = (long)(IntPtr)obj + 16L;
						continue;
					}
					break;
				}
				while (!flag2);
			}
			IEnumerator<TFrom> enumerator = baseList.GetEnumerator();
			return new CastedEnumerator<TTo, TFrom>(enumerator);
		}

		[Token(Token = "0x6000264")]
		[Address(RVA = "0x10A5614", Offset = "0x10A5614", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = this.BaseList;\n\tgoto L_001F;\n\tv45 = v25;\n\tv46 = 0x8907BC(v45, item, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv55 = Il2CppClass<Obi.CastedList`2>;\n\tv49 = Il2CppRgctx<Obi.CastedList`2>;\nL_001F:\n\tgoto L_0022;\n\tv56 = v50;\n\tv57 = 0x8907BC(v56, item, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0022:\n\tv59 = item == 0;\n\tif (v59) goto L_FFFFFFFF;\n\t// 38 IsInst v131 @ X0_v13 (System.Int32), typeof(TFrom), item @ X1 (TTo)\n\tv141 = v131 == 0;\n\tv137 = ~v141;\n\tif (v137) goto L_002F;\n\tthrow System.InvalidCastException;\nL_002F:\n\tv146 = *([v16 @ X19_v1 (System.Collections.Generic.IList`1<TFrom>)]);\n\tv120 = *([v146 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]) == 0;\n\tif (v120) goto L_0051;\n\tv191 = *([v146 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+B0]) + 8;\nL_003B:\n\tv196 = *([v191 @ X11_v5-8]) == Il2CppClass<System.Collections.Generic.ICollection`1<TFrom>>;\n\tif (v196) goto L_0054;\n\tv190 = v190 + 1;\n\tv201 = v190 < *([v146 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]);\n\tv171 = ~v201;\n\tv191 = v191 + 0x10;\n\tv155 = ~v171;\n\tif (v155) goto L_003B;\nL_0051:\n\tv209 = 0x8909C4(v16, Il2CppClass<System.Collections.Generic.ICollection`1<TFrom>>, 2, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_0058;\nL_0054:\n\tv203 = *([v191 @ X11_v5]) + 2;\n\tv204 = v203 << 4;\n\tv205 = v146 + v204;\n\tv209 = v205 + 0x130;\nL_0058:\n\tv63 = *([v209 @ X0_v6]);\n\tv73 = *([v209 @ X0_v6+8]);\n\t// 100 IndirectJump v63 @ X3_v1, v16 @ X19_v1 (System.Collections.Generic.IList`1<TFrom>), v16 @ X19_v1 (System.Collections.Generic.IList`1<TFrom>), v145 @ X21_v2 (System.Int32), v73 @ X2_v2, v63 @ X3_v1, v33 @ X4, v34 @ X5, v35 @ X6, v36 @ X7, v37 @ V0, v38 @ V1, v39 @ V2, v40 @ V3, v41 @ V4, v42 @ V5, v43 @ V6, v44 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Add(TTo item)
		{
			//IL_0150: Expected I, but got O
			//IL_003e: Expected I4, but got O
			//IL_01af: Expected O, but got I
			//IL_0090: Expected O, but got I
			//IL_010d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Expected O, but got Unknown
			//IL_012f: Expected O, but got I
			//IL_013e: Expected O, but got I
			//IL_00dc: Expected O, but got I
			IList<TFrom> baseList = BaseList;
			if (item != null)
			{
				if ((int)((item is TFrom) ? item : null) == 0)
				{
					throw new InvalidCastException();
				}
			}
			else
			{
				int num = 0;
			}
			IntPtr intPtr = (IntPtr)baseList;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00f5;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+B0]");
			object obj = 0L + 8L;
			int num2 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					break;
				}
				num2++;
				int num3 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]");
				bool flag = (long)num3 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00f5;
			}
			object obj2 = obj + 2;
			int num4 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num4;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0197;
			IL_00f5:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0197;
			IL_0197:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ X0_v6+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v63 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000265")]
		[Address(RVA = "0x10A5718", Offset = "0x10A5718", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.BaseList;\n\tgoto L_0013;\n\tv37 = v16;\n\tv38 = 0x8907BC(v37, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0013:\n\tv40 = *([v10 @ X19_v1 (System.Collections.Generic.IList`1<TFrom>)]);\n\tv42 = *([v40 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]) == 0;\n\tif (v42) goto L_0035;\n\tv145 = *([v40 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+B0]) + 8;\nL_001F:\n\tv150 = *([v145 @ X11_v5-8]) == Il2CppClass<System.Collections.Generic.ICollection`1<TFrom>>;\n\tif (v150) goto L_0038;\n\tv144 = v144 + 1;\n\tv155 = v144 < *([v40 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]);\n\tv74 = ~v155;\n\tv145 = v145 + 0x10;\n\tv50 = ~v74;\n\tif (v50) goto L_001F;\nL_0035:\n\tv163 = 0x8909C4(v10, Il2CppClass<System.Collections.Generic.ICollection`1<TFrom>>, 3, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tgoto L_003C;\nL_0038:\n\tv157 = *([v145 @ X11_v5]) + 3;\n\tv158 = v157 << 4;\n\tv159 = v40 + v158;\n\tv163 = v159 + 0x130;\nL_003C:\n\tv96 = *([v163 @ X0_v4]);\n\tv94 = *([v163 @ X0_v4+8]);\n\t// 68 IndirectJump v96 @ X2_v2, v10 @ X19_v1 (System.Collections.Generic.IList`1<TFrom>), v10 @ X19_v1 (System.Collections.Generic.IList`1<TFrom>), v94 @ X1_v2, v96 @ X2_v2, v24 @ X3, v25 @ X4, v26 @ X5, v27 @ X6, v28 @ X7, v29 @ V0, v30 @ V1, v31 @ V2, v32 @ V3, v33 @ V4, v34 @ V5, v35 @ V6, v36 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Clear()
		{
			//IL_001c: Expected I, but got O
			//IL_0144: Expected O, but got I
			//IL_0057: Expected O, but got I
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Expected O, but got Unknown
			//IL_00f6: Expected O, but got I
			//IL_0105: Expected O, but got I
			//IL_00a3: Expected O, but got I
			IList<TFrom> baseList = BaseList;
			IntPtr intPtr = (IntPtr)baseList;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00bc;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00bc;
			}
			object obj2 = obj + 3;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_012c;
			IL_00bc:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_012c;
			IL_012c:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ X0_v4+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v96 @ X2_v2 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000266")]
		[Address(RVA = "0x10A57BC", Offset = "0x10A57BC", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = this.BaseList;\n\tgoto L_001F;\n\tv45 = v25;\n\tv46 = 0x8907BC(v45, item, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv55 = Il2CppClass<Obi.CastedList`2>;\n\tv49 = Il2CppRgctx<Obi.CastedList`2>;\nL_001F:\n\tgoto L_0022;\n\tv56 = v50;\n\tv57 = 0x8907BC(v56, item, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0022:\n\tv59 = item == 0;\n\tif (v59) goto L_FFFFFFFF;\n\t// 38 IsInst v131 @ X0_v13 (System.Int32), typeof(TFrom), item @ X1 (TTo)\n\tv141 = v131 == 0;\n\tv137 = ~v141;\n\tif (v137) goto L_002F;\n\tthrow System.InvalidCastException;\nL_002F:\n\tv146 = *([v16 @ X19_v1 (System.Collections.Generic.IList`1<TFrom>)]);\n\tv120 = *([v146 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]) == 0;\n\tif (v120) goto L_0051;\n\tv191 = *([v146 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+B0]) + 8;\nL_003B:\n\tv196 = *([v191 @ X11_v5-8]) == Il2CppClass<System.Collections.Generic.ICollection`1<TFrom>>;\n\tif (v196) goto L_0054;\n\tv190 = v190 + 1;\n\tv201 = v190 < *([v146 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]);\n\tv171 = ~v201;\n\tv191 = v191 + 0x10;\n\tv155 = ~v171;\n\tif (v155) goto L_003B;\nL_0051:\n\tv209 = 0x8909C4(v16, Il2CppClass<System.Collections.Generic.ICollection`1<TFrom>>, 4, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_0058;\nL_0054:\n\tv203 = *([v191 @ X11_v5]) + 4;\n\tv204 = v203 << 4;\n\tv205 = v146 + v204;\n\tv209 = v205 + 0x130;\nL_0058:\n\tv63 = *([v209 @ X0_v6]);\n\tv73 = *([v209 @ X0_v6+8]);\n\t// 100 IndirectJump v63 @ X3_v1, v16 @ X19_v1 (System.Collections.Generic.IList`1<TFrom>), v16 @ X19_v1 (System.Collections.Generic.IList`1<TFrom>), v145 @ X21_v2 (System.Int32), v73 @ X2_v2, v63 @ X3_v1, v33 @ X4, v34 @ X5, v35 @ X6, v36 @ X7, v37 @ V0, v38 @ V1, v39 @ V2, v40 @ V3, v41 @ V4, v42 @ V5, v43 @ V6, v44 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool Contains(TTo item)
		{
			//IL_0150: Expected I, but got O
			//IL_003e: Expected I4, but got O
			//IL_01af: Expected O, but got I
			//IL_0090: Expected O, but got I
			//IL_010d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Expected O, but got Unknown
			//IL_012f: Expected O, but got I
			//IL_013e: Expected O, but got I
			//IL_00dc: Expected O, but got I
			IList<TFrom> baseList = BaseList;
			if (item != null)
			{
				if ((int)((item is TFrom) ? item : null) == 0)
				{
					throw new InvalidCastException();
				}
			}
			else
			{
				int num = 0;
			}
			IntPtr intPtr = (IntPtr)baseList;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00f5;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+B0]");
			object obj = 0L + 8L;
			int num2 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					break;
				}
				num2++;
				int num3 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]");
				bool flag = (long)num3 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00f5;
			}
			object obj2 = obj + 4;
			int num4 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num4;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0197;
			IL_00f5:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0197;
			IL_0197:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ X0_v6+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v63 @ X3_v1 (should have been resolved before IL gen)");
			return false;
		}

		[Token(Token = "0x6000267")]
		[Address(RVA = "0x10A58C0", Offset = "0x10A58C0", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = this.BaseList;\n\tgoto L_0021;\n\tv48 = v29;\n\tv49 = 0x8907BC(v48, array, arrayIndex, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv58 = Il2CppClass<Obi.CastedList`2>;\n\tv52 = Il2CppRgctx<Obi.CastedList`2>;\nL_0021:\n\tgoto L_0024;\n\tv59 = v53;\n\tv60 = 0x8907BC(v59, array, arrayIndex, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0024:\n\tv62 = array == 0;\n\tif (v62) goto L_FFFFFFFF;\n\t// 40 IsInst v138 @ X0_v13 (System.Int32), typeof(TFrom[]), array @ X1 (TTo[])\n\tv148 = v138 == 0;\n\tv144 = ~v148;\n\tif (v144) goto L_0031;\n\tthrow System.InvalidCastException;\nL_0031:\n\tv153 = *([v18 @ X20_v1 (System.Collections.Generic.IList`1<TFrom>)]);\n\tv125 = *([v153 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]) == 0;\n\tif (v125) goto L_0053;\n\tv198 = *([v153 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+B0]) + 8;\nL_003D:\n\tv203 = *([v198 @ X11_v5-8]) == Il2CppClass<System.Collections.Generic.ICollection`1<TFrom>>;\n\tif (v203) goto L_0056;\n\tv197 = v197 + 1;\n\tv208 = v197 < *([v153 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]);\n\tv178 = ~v208;\n\tv198 = v198 + 0x10;\n\tv162 = ~v178;\n\tif (v162) goto L_003D;\nL_0053:\n\tv216 = 0x8909C4(v18, Il2CppClass<System.Collections.Generic.ICollection`1<TFrom>>, 5, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_005A;\nL_0056:\n\tv210 = *([v198 @ X11_v5]) + 5;\n\tv211 = v210 << 4;\n\tv212 = v153 + v211;\n\tv216 = v212 + 0x130;\nL_005A:\n\tv68 = *([v216 @ X0_v6]);\n\tv66 = *([v216 @ X0_v6+8]);\n\t// 104 IndirectJump v68 @ X4_v1, v18 @ X20_v1 (System.Collections.Generic.IList`1<TFrom>), v18 @ X20_v1 (System.Collections.Generic.IList`1<TFrom>), v152 @ X22_v2 (System.Int32), arrayIndex @ X2 (System.Int32), v66 @ X3_v1, v68 @ X4_v1, v37 @ X5, v38 @ X6, v39 @ X7, v40 @ V0, v41 @ V1, v42 @ V2, v43 @ V3, v44 @ V4, v45 @ V5, v46 @ V6, v47 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CopyTo(TTo[] array, int arrayIndex)
		{
			//IL_0150: Expected I, but got O
			//IL_003e: Expected I4, but got O
			//IL_01af: Expected O, but got I
			//IL_0090: Expected O, but got I
			//IL_010d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Expected O, but got Unknown
			//IL_012f: Expected O, but got I
			//IL_013e: Expected O, but got I
			//IL_00dc: Expected O, but got I
			IList<TFrom> baseList = BaseList;
			if (array != null)
			{
				if ((int)(array as TFrom[]) == 0)
				{
					throw new InvalidCastException();
				}
			}
			else
			{
				int num = 0;
			}
			IntPtr intPtr = (IntPtr)baseList;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00f5;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+B0]");
			object obj = 0L + 8L;
			int num2 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					break;
				}
				num2++;
				int num3 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]");
				bool flag = (long)num3 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00f5;
			}
			object obj2 = obj + 5;
			int num4 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num4;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0197;
			IL_00f5:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0197;
			IL_0197:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ X0_v6+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v68 @ X4_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000268")]
		[Address(RVA = "0x10A59CC", Offset = "0x10A59CC", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = this.BaseList;\n\tgoto L_001F;\n\tv45 = v25;\n\tv46 = 0x8907BC(v45, item, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv55 = Il2CppClass<Obi.CastedList`2>;\n\tv49 = Il2CppRgctx<Obi.CastedList`2>;\nL_001F:\n\tgoto L_0022;\n\tv56 = v50;\n\tv57 = 0x8907BC(v56, item, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0022:\n\tv59 = item == 0;\n\tif (v59) goto L_FFFFFFFF;\n\t// 38 IsInst v131 @ X0_v13 (System.Int32), typeof(TFrom), item @ X1 (TTo)\n\tv141 = v131 == 0;\n\tv137 = ~v141;\n\tif (v137) goto L_002F;\n\tthrow System.InvalidCastException;\nL_002F:\n\tv146 = *([v16 @ X19_v1 (System.Collections.Generic.IList`1<TFrom>)]);\n\tv120 = *([v146 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]) == 0;\n\tif (v120) goto L_0051;\n\tv191 = *([v146 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+B0]) + 8;\nL_003B:\n\tv196 = *([v191 @ X11_v5-8]) == Il2CppClass<System.Collections.Generic.ICollection`1<TFrom>>;\n\tif (v196) goto L_0054;\n\tv190 = v190 + 1;\n\tv201 = v190 < *([v146 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]);\n\tv171 = ~v201;\n\tv191 = v191 + 0x10;\n\tv155 = ~v171;\n\tif (v155) goto L_003B;\nL_0051:\n\tv209 = 0x8909C4(v16, Il2CppClass<System.Collections.Generic.ICollection`1<TFrom>>, 6, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_0058;\nL_0054:\n\tv203 = *([v191 @ X11_v5]) + 6;\n\tv204 = v203 << 4;\n\tv205 = v146 + v204;\n\tv209 = v205 + 0x130;\nL_0058:\n\tv63 = *([v209 @ X0_v6]);\n\tv73 = *([v209 @ X0_v6+8]);\n\t// 100 IndirectJump v63 @ X3_v1, v16 @ X19_v1 (System.Collections.Generic.IList`1<TFrom>), v16 @ X19_v1 (System.Collections.Generic.IList`1<TFrom>), v145 @ X21_v2 (System.Int32), v73 @ X2_v2, v63 @ X3_v1, v33 @ X4, v34 @ X5, v35 @ X6, v36 @ X7, v37 @ V0, v38 @ V1, v39 @ V2, v40 @ V3, v41 @ V4, v42 @ V5, v43 @ V6, v44 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool Remove(TTo item)
		{
			//IL_0150: Expected I, but got O
			//IL_003e: Expected I4, but got O
			//IL_01af: Expected O, but got I
			//IL_0090: Expected O, but got I
			//IL_010d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Expected O, but got Unknown
			//IL_012f: Expected O, but got I
			//IL_013e: Expected O, but got I
			//IL_00dc: Expected O, but got I
			IList<TFrom> baseList = BaseList;
			if (item != null)
			{
				if ((int)((item is TFrom) ? item : null) == 0)
				{
					throw new InvalidCastException();
				}
			}
			else
			{
				int num = 0;
			}
			IntPtr intPtr = (IntPtr)baseList;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00f5;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+B0]");
			object obj = 0L + 8L;
			int num2 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					break;
				}
				num2++;
				int num3 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]");
				bool flag = (long)num3 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00f5;
			}
			object obj2 = obj + 6;
			int num4 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num4;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0197;
			IL_00f5:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0197;
			IL_0197:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ X0_v6+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v63 @ X3_v1 (should have been resolved before IL gen)");
			return false;
		}

		[Token(Token = "0x600026B")]
		[Address(RVA = "0x10A5CD8", Offset = "0x10A5CD8", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = this.BaseList;\n\tgoto L_001F;\n\tv45 = v25;\n\tv46 = 0x8907BC(v45, item, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv55 = Il2CppClass<Obi.CastedList`2>;\n\tv49 = Il2CppRgctx<Obi.CastedList`2>;\nL_001F:\n\tgoto L_0022;\n\tv56 = v50;\n\tv57 = 0x8907BC(v56, item, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0022:\n\tv59 = item == 0;\n\tif (v59) goto L_FFFFFFFF;\n\t// 38 IsInst v131 @ X0_v13 (System.Int32), typeof(TFrom), item @ X1 (TTo)\n\tv141 = v131 == 0;\n\tv137 = ~v141;\n\tif (v137) goto L_002F;\n\tthrow System.InvalidCastException;\nL_002F:\n\tv146 = *([v16 @ X19_v1 (System.Collections.Generic.IList`1<TFrom>)]);\n\tv120 = *([v146 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]) == 0;\n\tif (v120) goto L_0051;\n\tv191 = *([v146 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+B0]) + 8;\nL_003B:\n\tv196 = *([v191 @ X11_v5-8]) == Il2CppClass<System.Collections.Generic.IList`1<TFrom>>;\n\tif (v196) goto L_0054;\n\tv190 = v190 + 1;\n\tv201 = v190 < *([v146 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]);\n\tv171 = ~v201;\n\tv191 = v191 + 0x10;\n\tv155 = ~v171;\n\tif (v155) goto L_003B;\nL_0051:\n\tv209 = 0x8909C4(v16, Il2CppClass<System.Collections.Generic.IList`1<TFrom>>, 2, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_0058;\nL_0054:\n\tv203 = *([v191 @ X11_v5]) + 2;\n\tv204 = v203 << 4;\n\tv205 = v146 + v204;\n\tv209 = v205 + 0x130;\nL_0058:\n\tv63 = *([v209 @ X0_v6]);\n\tv73 = *([v209 @ X0_v6+8]);\n\t// 100 IndirectJump v63 @ X3_v1, v16 @ X19_v1 (System.Collections.Generic.IList`1<TFrom>), v16 @ X19_v1 (System.Collections.Generic.IList`1<TFrom>), v145 @ X21_v2 (System.Int32), v73 @ X2_v2, v63 @ X3_v1, v33 @ X4, v34 @ X5, v35 @ X6, v36 @ X7, v37 @ V0, v38 @ V1, v39 @ V2, v40 @ V3, v41 @ V4, v42 @ V5, v43 @ V6, v44 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int IndexOf(TTo item)
		{
			//IL_0150: Expected I, but got O
			//IL_003e: Expected I4, but got O
			//IL_01af: Expected O, but got I
			//IL_0090: Expected O, but got I
			//IL_010d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Expected O, but got Unknown
			//IL_012f: Expected O, but got I
			//IL_013e: Expected O, but got I
			//IL_00dc: Expected O, but got I
			IList<TFrom> baseList = BaseList;
			if (item != null)
			{
				if ((int)((item is TFrom) ? item : null) == 0)
				{
					throw new InvalidCastException();
				}
			}
			else
			{
				int num = 0;
			}
			IntPtr intPtr = (IntPtr)baseList;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00f5;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+B0]");
			object obj = 0L + 8L;
			int num2 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					break;
				}
				num2++;
				int num3 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]");
				bool flag = (long)num3 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00f5;
			}
			object obj2 = obj + 2;
			int num4 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num4;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0197;
			IL_00f5:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0197;
			IL_0197:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v209 @ X0_v6+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v63 @ X3_v1 (should have been resolved before IL gen)");
			return 0;
		}

		[Token(Token = "0x600026C")]
		[Address(RVA = "0x10A5DDC", Offset = "0x10A5DDC", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = this.BaseList;\n\tgoto L_0021;\n\tv48 = v29;\n\tv49 = 0x8907BC(v48, index, item, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv58 = Il2CppClass<Obi.CastedList`2>;\n\tv52 = Il2CppRgctx<Obi.CastedList`2>;\nL_0021:\n\tgoto L_0024;\n\tv59 = v53;\n\tv60 = 0x8907BC(v59, index, item, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0024:\n\tv62 = item == 0;\n\tif (v62) goto L_FFFFFFFF;\n\t// 40 IsInst v138 @ X0_v13 (System.Int32), typeof(TFrom), item @ X2 (TTo)\n\tv148 = v138 == 0;\n\tv144 = ~v148;\n\tif (v144) goto L_0031;\n\tthrow System.InvalidCastException;\nL_0031:\n\tv153 = *([v18 @ X20_v1 (System.Collections.Generic.IList`1<TFrom>)]);\n\tv125 = *([v153 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]) == 0;\n\tif (v125) goto L_0053;\n\tv198 = *([v153 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+B0]) + 8;\nL_003D:\n\tv203 = *([v198 @ X11_v5-8]) == Il2CppClass<System.Collections.Generic.IList`1<TFrom>>;\n\tif (v203) goto L_0056;\n\tv197 = v197 + 1;\n\tv208 = v197 < *([v153 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]);\n\tv178 = ~v208;\n\tv198 = v198 + 0x10;\n\tv162 = ~v178;\n\tif (v162) goto L_003D;\nL_0053:\n\tv216 = 0x8909C4(v18, Il2CppClass<System.Collections.Generic.IList`1<TFrom>>, 3, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_005A;\nL_0056:\n\tv210 = *([v198 @ X11_v5]) + 3;\n\tv211 = v210 << 4;\n\tv212 = v153 + v211;\n\tv216 = v212 + 0x130;\nL_005A:\n\tv68 = *([v216 @ X0_v6]);\n\tv66 = *([v216 @ X0_v6+8]);\n\t// 104 IndirectJump v68 @ X4_v1, v18 @ X20_v1 (System.Collections.Generic.IList`1<TFrom>), v18 @ X20_v1 (System.Collections.Generic.IList`1<TFrom>), index @ X1 (System.Int32), v152 @ X22_v2 (System.Int32), v66 @ X3_v1, v68 @ X4_v1, v37 @ X5, v38 @ X6, v39 @ X7, v40 @ V0, v41 @ V1, v42 @ V2, v43 @ V3, v44 @ V4, v45 @ V5, v46 @ V6, v47 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Insert(int index, TTo item)
		{
			//IL_0150: Expected I, but got O
			//IL_003e: Expected I4, but got O
			//IL_01af: Expected O, but got I
			//IL_0090: Expected O, but got I
			//IL_010d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Expected O, but got Unknown
			//IL_012f: Expected O, but got I
			//IL_013e: Expected O, but got I
			//IL_00dc: Expected O, but got I
			IList<TFrom> baseList = BaseList;
			if (item != null)
			{
				if ((int)((item is TFrom) ? item : null) == 0)
				{
					throw new InvalidCastException();
				}
			}
			else
			{
				int num = 0;
			}
			IntPtr intPtr = (IntPtr)baseList;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00f5;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+B0]");
			object obj = 0L + 8L;
			int num2 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					break;
				}
				num2++;
				int num3 = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v153 @ X8_v5 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]");
				bool flag = (long)num3 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00f5;
			}
			object obj2 = obj + 3;
			int num4 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num4;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_0197;
			IL_00f5:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0197;
			IL_0197:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ X0_v6+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v68 @ X4_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x600026D")]
		[Address(RVA = "0x10A5EE8", Offset = "0x10A5EE8", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.BaseList;\n\tgoto L_0015;\n\tv40 = v20;\n\tv41 = 0x8907BC(v40, index, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0015:\n\tv43 = *([v12 @ X20_v1 (System.Collections.Generic.IList`1<TFrom>)]);\n\tv45 = *([v43 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]) == 0;\n\tif (v45) goto L_0037;\n\tv152 = *([v43 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+B0]) + 8;\nL_0021:\n\tv157 = *([v152 @ X11_v5-8]) == Il2CppClass<System.Collections.Generic.IList`1<TFrom>>;\n\tif (v157) goto L_003A;\n\tv151 = v151 + 1;\n\tv162 = v151 < *([v43 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]);\n\tv77 = ~v162;\n\tv152 = v152 + 0x10;\n\tv53 = ~v77;\n\tif (v53) goto L_0021;\nL_0037:\n\tv170 = 0x8909C4(v12, Il2CppClass<System.Collections.Generic.IList`1<TFrom>>, 4, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_003E;\nL_003A:\n\tv164 = *([v152 @ X11_v5]) + 4;\n\tv165 = v164 << 4;\n\tv166 = v43 + v165;\n\tv170 = v166 + 0x130;\nL_003E:\n\tv92 = *([v170 @ X0_v4]);\n\tv101 = *([v170 @ X0_v4+8]);\n\t// 72 IndirectJump v92 @ X3_v1, v12 @ X20_v1 (System.Collections.Generic.IList`1<TFrom>), v12 @ X20_v1 (System.Collections.Generic.IList`1<TFrom>), index @ X1 (System.Int32), v101 @ X2_v2, v92 @ X3_v1, v28 @ X4, v29 @ X5, v30 @ X6, v31 @ X7, v32 @ V0, v33 @ V1, v34 @ V2, v35 @ V3, v36 @ V4, v37 @ V5, v38 @ V6, v39 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RemoveAt(int index)
		{
			//IL_001c: Expected I, but got O
			//IL_0144: Expected O, but got I
			//IL_0057: Expected O, but got I
			//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d9: Expected O, but got Unknown
			//IL_00f6: Expected O, but got I
			//IL_0105: Expected O, but got I
			//IL_00a3: Expected O, but got I
			IList<TFrom> baseList = BaseList;
			IntPtr intPtr = (IntPtr)baseList;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00bc;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ X8_v4 (Il2CppClass<System.Collections.Generic.IList`1<TFrom>>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00bc;
			}
			object obj2 = obj + 4;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_012c;
			IL_00bc:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_012c;
			IL_012c:
			object obj5 = obj4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ X0_v4+8]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v92 @ X3_v1 (should have been resolved before IL gen)");
		}
	}
}
