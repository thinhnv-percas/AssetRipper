using System;
using System.Collections;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Obi
{
	[Token(Token = "0x200002F")]
	public class CastedEnumerator<TTo, TFrom> : IEnumerator<TTo>, IEnumerator, IDisposable
	{
		[Token(Token = "0x40000B7")]
		[FieldOffset(Offset = "0x0")]
		public IEnumerator<TFrom> BaseEnumerator;

		[Token(Token = "0x17000041")]
		object IEnumerator.Current
		{
			[Token(Token = "0x6000270")]
			[Address(RVA = "0x10A5000", Offset = "0x10A5000", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this.BaseEnumerator;\n\tgoto L_0013;\n\tv37 = v16;\n\tv38 = 0x8907BC(v37, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0013:\n\tv40 = *([v10 @ X19_v1 (System.Collections.Generic.IEnumerator`1<TFrom>)]);\n\tv42 = *([v40 @ X8_v4 (Il2CppClass<System.Collections.Generic.IEnumerator`1<TFrom>>)+126]) == 0;\n\tif (v42) goto L_0035;\n\tv145 = *([v40 @ X8_v4 (Il2CppClass<System.Collections.Generic.IEnumerator`1<TFrom>>)+B0]) + 8;\nL_001F:\n\tv150 = *([v145 @ X11_v5-8]) == Il2CppClass<System.Collections.Generic.IEnumerator`1<TFrom>>;\n\tif (v150) goto L_0038;\n\tv144 = v144 + 1;\n\tv155 = v144 < *([v40 @ X8_v4 (Il2CppClass<System.Collections.Generic.IEnumerator`1<TFrom>>)+126]);\n\tv74 = ~v155;\n\tv145 = v145 + 0x10;\n\tv50 = ~v74;\n\tif (v50) goto L_001F;\nL_0035:\n\tv162 = 0x8909C4(v10, Il2CppClass<System.Collections.Generic.IEnumerator`1<TFrom>>, 0, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tgoto L_003B;\nL_0038:\n\tv157 = *([v145 @ X11_v5]) << 4;\n\tv158 = v40 + v157;\n\tv162 = v158 + 0x130;\nL_003B:\n\tv94 = *([v162 @ X0_v4]);\n\tv96 = *([v162 @ X0_v4+8]);\n\t// 67 IndirectJump v94 @ X2_v2, v10 @ X19_v1 (System.Collections.Generic.IEnumerator`1<TFrom>), v10 @ X19_v1 (System.Collections.Generic.IEnumerator`1<TFrom>), v96 @ X1_v2, v94 @ X2_v2, v24 @ X3, v25 @ X4, v26 @ X5, v27 @ X6, v28 @ X7, v29 @ V0, v30 @ V1, v31 @ V2, v32 @ V3, v33 @ V4, v34 @ V5, v35 @ V6, v36 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_001c: Expected I, but got O
				//IL_013a: Expected O, but got I
				//IL_0057: Expected O, but got I
				//IL_00de: Expected I4, but got O
				//IL_00ec: Expected O, but got I
				//IL_00fb: Expected O, but got I
				//IL_00a3: Expected O, but got I
				IEnumerator<TFrom> baseEnumerator = BaseEnumerator;
				IntPtr intPtr = (IntPtr)baseEnumerator;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X8_v4 (Il2CppClass<System.Collections.Generic.IEnumerator`1<TFrom>>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_00bc;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X8_v4 (Il2CppClass<System.Collections.Generic.IEnumerator`1<TFrom>>)+B0]");
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
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X8_v4 (Il2CppClass<System.Collections.Generic.IEnumerator`1<TFrom>>)+126]");
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
				goto IL_0122;
				IL_00bc:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				goto IL_0122;
				IL_0122:
				object obj4 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ X0_v4+8]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v94 @ X2_v2 (should have been resolved before IL gen)");
				return null;
			}
		}

		[Token(Token = "0x17000042")]
		public TTo Current
		{
			[Token(Token = "0x6000273")]
			[Address(RVA = "0x10A520C", Offset = "0x10A520C", Length = "0xF4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.BaseEnumerator;\n\tgoto L_0015;\n\tv40 = v19;\n\tv41 = 0x8907BC(v40, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0015:\n\tv43 = *([v12 @ X20_v1 (System.Collections.Generic.IEnumerator`1<TFrom>)]);\n\tv45 = *([v43 @ X8_v4 (Il2CppClass<System.Collections.Generic.IEnumerator`1<TFrom>>)+126]) == 0;\n\tif (v45) goto L_0038;\n\tv151 = *([v43 @ X8_v4 (Il2CppClass<System.Collections.Generic.IEnumerator`1<TFrom>>)+B0]) + 8;\nL_0021:\n\tv156 = *([v151 @ X11_v5-8]) == Il2CppClass<System.Collections.Generic.IEnumerator`1<TFrom>>;\n\tif (v156) goto L_003A;\n\tv150 = v150 + 1;\n\tv161 = v150 < *([v43 @ X8_v4 (Il2CppClass<System.Collections.Generic.IEnumerator`1<TFrom>>)+126]);\n\tv77 = ~v161;\n\tv151 = v151 + 0x10;\n\tv53 = ~v77;\n\tif (v53) goto L_0021;\nL_0038:\n\tgoto L_0040;\nL_003A:\n\t;\nL_0040:\n\tv172 = System.Collections.Generic.IEnumerator`1<TFrom>::get_Current(v12);\n\tgoto L_004C;\n\tv180 = v176;\n\tv181 = 0x8907BC(v180, v170, v97, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_004C:\n\tv183 = v172 == 0;\n\tif (v183) goto L_FFFFFFFF;\n\t// 80 IsInst returnVal2 @ X0_v8 (TTo), typeof(TTo), v172 @ X0_v6\n\tv194 = returnVal2 == 0;\n\tv192 = ~v194;\n\tif (v192) goto L_005E;\n\tthrow System.InvalidCastException;\nL_005E:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 66 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_001c: Expected I, but got O
				//IL_0057: Expected O, but got I
				//IL_00a3: Expected O, but got I
				IEnumerator<TFrom> baseEnumerator = BaseEnumerator;
				IntPtr intPtr = (IntPtr)baseEnumerator;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ X8_v4 (Il2CppClass<System.Collections.Generic.IEnumerator`1<TFrom>>)+126]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ X8_v4 (Il2CppClass<System.Collections.Generic.IEnumerator`1<TFrom>>)+B0]");
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
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ X8_v4 (Il2CppClass<System.Collections.Generic.IEnumerator`1<TFrom>>)+126]");
							bool flag = (long)num2 < 0L;
							flag2 = !flag;
							obj = (long)(IntPtr)obj + 16L;
							continue;
						}
						break;
					}
					while (!flag2);
				}
				object current = baseEnumerator.Current;
				TTo val;
				if (current != null)
				{
					val = (TTo)((current is TTo) ? current : null);
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
		}

		[Token(Token = "0x600026E")]
		[Address(RVA = "0x10A4F14", Offset = "0x10A4F14", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.BaseEnumerator = baseEnumerator;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CastedEnumerator(IEnumerator<TFrom> baseEnumerator)
		{
			BaseEnumerator = baseEnumerator;
		}

		[Token(Token = "0x600026F")]
		[Address(RVA = "0x10A4F4C", Offset = "0x10A4F4C", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EF62D8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026B0A]) = v38;\nL_001C:\n\tgoto L_0048;\n\tv49 = *([v42 @ X8_v3+B0]);\n\tv50 = 0;\n\tv51 = v49 + 8;\n\tv53 = *([v100 @ X11_v5-8]);\n\tv106 = v53 == v45;\n\tif (v106) goto L_003C;\n\tv86 = v101 + 1;\n\tv159 = v86 < v44;\n\tv80 = ~v159;\n\tv83 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_FFFFFFFF;\n\tv87 = v39;\n\tv88 = 0;\n\tv89 = 0x8909C4(v87, v45, v88, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0048;\nL_003C:\n\tv160 = *([v100 @ X11_v5]);\n\tv161 = v160 << 4;\n\tv162 = v42 + v161;\n\tv163 = v162 + 0x130;\nL_0048:\n\tSystem.IDisposable::Dispose(this.BaseEnumerator);\n\tthrow System.NullReferenceException;\n\treturn;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Dispose()
		{
			BaseEnumerator.Dispose();
		}

		[Token(Token = "0x6000271")]
		[Address(RVA = "0x10A50A0", Offset = "0x10A50A0", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EBA808]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026B0B]) = v38;\nL_001C:\n\tgoto L_0048;\n\tv49 = *([v42 @ X8_v3+B0]);\n\tv50 = 0;\n\tv51 = v49 + 8;\n\tv53 = *([v100 @ X11_v5-8]);\n\tv106 = v53 == v45;\n\tif (v106) goto L_003C;\n\tv86 = v101 + 1;\n\tv159 = v86 < v44;\n\tv80 = ~v159;\n\tv83 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_FFFFFFFF;\n\tv87 = v39;\n\tv88 = 0;\n\tv89 = 0x8909C4(v87, v45, v88, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0048;\nL_003C:\n\tv160 = *([v100 @ X11_v5]);\n\tv161 = v160 << 4;\n\tv162 = v42 + v161;\n\tv163 = v162 + 0x130;\nL_0048:\n\tinterfaceTailCallResult = System.Collections.IEnumerator::MoveNext(this.BaseEnumerator);\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool MoveNext()
		{
			return BaseEnumerator.MoveNext();
		}

		[Token(Token = "0x6000272")]
		[Address(RVA = "0x10A5154", Offset = "0x10A5154", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EB11E8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2026B0C]) = v38;\nL_0013:\n\tv39 = this.BaseEnumerator;\n\tv42 = *([v39 @ X19_v2 (System.Collections.Generic.IEnumerator`1<TFrom>)]);\n\tv46 = *([v42 @ X8_v3 (Il2CppClass<System.Collections.Generic.IEnumerator`1<TFrom>>)+126]) == 0;\n\tif (v46) goto L_003A;\n\tv100 = *([v42 @ X8_v3 (Il2CppClass<System.Collections.Generic.IEnumerator`1<TFrom>>)+B0]) + 8;\nL_0025:\n\tv106 = *([v100 @ X11_v5-8]) == System.Collections.IEnumerator;\n\tif (v106) goto L_003D;\n\tv101 = v101 + 1;\n\tv159 = v101 < *([v42 @ X8_v3 (Il2CppClass<System.Collections.Generic.IEnumerator`1<TFrom>>)+126]);\n\tv80 = ~v159;\n\tv100 = v100 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_0025;\nL_003A:\n\tv166 = 0x8909C4(v39, System.Collections.IEnumerator, 2, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tgoto L_0041;\nL_003D:\n\tv161 = *([v100 @ X11_v5]) + 2;\n\tv162 = v161 << 4;\n\tv163 = v42 + v162;\n\tv166 = v163 + 0x130;\nL_0041:\n\tv119 = *([v166 @ X0_v4]);\n\tv141 = *([v166 @ X0_v4+8]);\n\t// 73 IndirectJump v119 @ X2_v2, v39 @ X19_v2 (System.Collections.Generic.IEnumerator`1<TFrom>), v39 @ X19_v2 (System.Collections.Generic.IEnumerator`1<TFrom>), v141 @ X1_v2, v119 @ X2_v2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Reset()
		{
			//IL_000d: Expected I, but got O
			//IL_0151: Expected O, but got I
			//IL_0048: Expected O, but got I
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Expected O, but got Unknown
			//IL_00ec: Expected O, but got I
			//IL_00fb: Expected O, but got I
			//IL_0094: Expected O, but got I
			IEnumerator<TFrom> baseEnumerator = BaseEnumerator;
			IntPtr intPtr = (IntPtr)baseEnumerator;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<System.Collections.Generic.IEnumerator`1<TFrom>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<System.Collections.Generic.IEnumerator`1<TFrom>>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v100 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IEnumerator))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ X8_v3 (Il2CppClass<System.Collections.Generic.IEnumerator`1<TFrom>>)+126]");
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
		}
	}
}
