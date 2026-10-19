using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Collections;

namespace Unco.Extensions
{
	[Token(Token = "0x2000012")]
	public static class ListExtension
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000013")]
		private sealed class _003C_003Ec__9<T>
		{
			[Token(Token = "0x4000037")]
			public static readonly _003C_003Ec__9<T> _003C_003E9;

			[Token(Token = "0x4000038")]
			public static Predicate<T> _003C_003E9__9_0;

			[Token(Token = "0x6000062")]
			[Address(RVA = "0x4FFCC3C", Offset = "0x4FFCC3C", Length = "0x1A0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1>;\n\tv19 = *([v16 @ X0_v1 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1>)+135]) & 1;\n\tv20 = v19 == 0;\n\tif (v20) goto L_002B;\n\tv22 = Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>;\n\tv25 = *([v22 @ X0_v42 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>)+135]) & 1;\n\tv26 = v25 == 0;\n\tv47 = Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>;\n\tv52 = Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>;\n\tif (v26) goto L_0034;\nL_0016:\n\tv49 = new v47();\n\tv59 = Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1>;\n\tv77 = *([v59 @ X0_v41 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1>)+135]);\n\tv62 = *([v59 @ X0_v41 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1>)+135]) & 1;\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tv100 = v49;\n\tv74 = Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1>;\n\tv107 = v49;\n\tv103 = Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1>;\n\tif (v64) goto L_003E;\nL_001F:\n\tv76 = 0x220C238(v74, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv90 = Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1>;\n\tv93 = *([v76 @ X0_v37+C0]);\n\tv94 = *([v93 @ X8_v43+8]);\n\tv98 = *([v94 @ X8_v44]);\n\tv96 = *([v90 @ X0_v38 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1>)+135]) & 1;\n\tv97 = v96 == 0;\n\tv103 = Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1>;\n\tif (v97) goto L_0044;\n\tv105 = *([v94 @ X8_v44]);\n\tv107 = v100;\n\tgoto L_0048;\nL_002B:\n\tv27 = 0x220C238(Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1>, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv54 = *([v27 @ X0_v34+C0]);\n\tv47 = *([v54 @ X8_v38]);\n\tv56 = *([v47 @ X0_v39 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>)+135]) & 1;\n\tv57 = v56 == 0;\n\tv44 = ~v57;\n\tv52 = v47;\n\tif (v44) goto L_0016;\nL_0034:\n\tv53 = 0x220C238(v52, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv65 = new v53();\n\tv75 = Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1>;\n\tv77 = *([v75 @ X0_v33 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1>)+135]);\n\tv88 = *([v75 @ X0_v33 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1>)+135]) & 1;\n\tv71 = v88 == 0;\n\tv100 = v65;\n\tv74 = Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1>;\n\tv107 = v65;\n\tv103 = Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1>;\n\tif (v71) goto L_001F;\nL_003E:\n\tv83 = Il2CppMethodInfo;\n\tv98 = *([v83 @ X8_v35 (Il2CppMethodInfo)]);\n\tv85 = v77 & 1;\n\tv86 = v85 == 0;\n\tv87 = ~v86;\n\tv100 = v107;\n\tv105 = *([v83 @ X8_v35 (Il2CppMethodInfo)]);\n\tif (v87) goto L_0048;\nL_0044:\n\tv104 = 0x220C238(v103, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv105 = v98;\n\tv107 = v100;\nL_0048:\n\tv105(v114, v107, Il2CppMethodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv115 = Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1>;\n\tv118 = *([v115 @ X0_v5 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1>)+135]) & 1;\n\tv119 = v118 == 0;\n\tif (v119) goto L_0070;\n\tv121 = Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>;\n\tv124 = *([v121 @ X0_v25 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>)+135]) & 1;\n\tv125 = v124 == 0;\n\tv141 = Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>;\n\tif (v125) goto L_0079;\nL_0057:\n\tv133.<>9 = v107;\n\tv134 = Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1>;\n\tv137 = *([v134 @ X0_v24 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1>)+135]) & 1;\n\tv138 = v137 == 0;\n\tv161 = Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1>;\n\tif (v138) goto L_0083;\nL_005F:\n\tv154 = Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>;\n\tv157 = *([v154 @ X0_v22 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>)+135]) & 1;\n\tv158 = v157 == 0;\n\tv184 = Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>;\n\tif (v158) goto L_008C;\nL_006F:\n\treturn;\nL_0070:\n\tv126 = 0x220C238(Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1>, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv143 = *([v126 @ X0_v16+C0]);\n\tv141 = *([v143 @ X8_v16+10]);\n\tv145 = *([v141 @ X0_v13 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>)+135]) & 1;\n\tv146 = v145 == 0;\n\tv128 = ~v146;\n\tif (v128) goto L_0057;\nL_0079:\n\tv142 = 0x220C238(v141, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv163 = *([v142 @ X0_v14+B8]);\n\t*([v163 @ X8_v13]) = v107;\n\tv152 = Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1>;\n\tv165 = *([v152 @ X0_v15 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1>)+135]) & 1;\n\tv166 = v165 == 0;\n\tv148 = ~v166;\n\tv161 = Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1>;\n\tif (v148) goto L_005F;\nL_0083:\n\tv162 = 0x220C238(v161, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv186 = *([v162 @ X0_v11+C0]);\n\tv184 = *([v186 @ X8_v9+10]);\n\tv188 = *([v184 @ X0_v6 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>)+135]) & 1;\n\tv189 = v188 == 0;\n\tv168 = ~v189;\n\tif (v168) goto L_006F;\nL_008C:\n\tv185 = 0x220C238(v184, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\n")]
			static _003C_003Ec__9()
			{
				//IL_019d: Expected O, but got I
				//IL_01a5: Expected I, but got O
				//IL_0099: Expected O, but got I
				//IL_0277: Expected O, but got I
				//IL_02b0: Expected O, but got I
				//IL_0118: Expected O, but got I
				//IL_0128: Expected O, but got I
				//IL_021a: Expected O, but got I
				//IL_040b: Expected O, but got I
				//IL_04e9: Expected O, but got I
				//IL_0478: Expected O, but got I
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ X0_v1 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1>)+135]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X0_v42 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>)+135]");
					int num3 = (int)((nint)0 & (nint)1);
					bool flag = num3 == 0;
					nint num4 = 0;
					nint num5 = 0;
					if (!flag)
					{
						goto IL_007e;
					}
				}
				else
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ X0_v34+C0]");
					object obj = 0;
					nint num4 = (nint)obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X0_v39 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>)+135]");
					int num6 = (int)((nint)0 & (nint)1);
					bool flag2 = num6 == 0;
					bool flag3 = !flag2;
					nint num5 = num4;
					if (flag3)
					{
						goto IL_007e;
					}
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				_003C_003Ec__9<T> _003C_003Ec__10 = null;
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X0_v33 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1>)+135]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X0_v33 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1>)+135]");
				int num8 = (int)((nint)0 & (nint)1);
				bool flag4 = num8 == 0;
				_003C_003Ec__9<T> _003C_003Ec__11 = _003C_003Ec__10;
				nint num9 = 0;
				_003C_003Ec__9<T> _003C_003Ec__12 = _003C_003Ec__10;
				nint num10 = 0;
				if (flag4)
				{
					goto IL_00f3;
				}
				goto IL_0269;
				IL_04ca:
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ X0_v11+C0]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ X8_v9+10]");
				nint num11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ X0_v6 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>)+135]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					return;
				}
				goto IL_0537;
				IL_03ac:
				nint num12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ X0_v22 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>)+135]");
				int num13 = (int)((nint)0 & (nint)1);
				bool flag5 = num13 == 0;
				num11 = 0;
				if (!flag5)
				{
					return;
				}
				goto IL_0537;
				IL_0537:
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				return;
				IL_007e:
				_003C_003Ec__9<T> _003C_003Ec__13 = null;
				nint num14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X0_v41 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1>)+135]");
				obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X0_v41 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1>)+135]");
				int num15 = (int)((nint)0 & (nint)1);
				bool flag6 = num15 == 0;
				bool flag7 = !flag6;
				_003C_003Ec__11 = _003C_003Ec__13;
				num9 = 0;
				_003C_003Ec__12 = _003C_003Ec__13;
				num10 = 0;
				if (!flag7)
				{
					goto IL_00f3;
				}
				goto IL_0269;
				IL_0269:
				nint num16 = 0;
				object obj4 = num16;
				int num17 = (int)((nint)obj2 & 1);
				bool flag8 = num17 == 0;
				bool flag9 = !flag8;
				_003C_003Ec__11 = _003C_003Ec__12;
				object obj5 = num16;
				if (!flag9)
				{
					goto IL_02be;
				}
				goto IL_02e2;
				IL_00f3:
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				nint num18 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ X0_v37+C0]");
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ X8_v43+8]");
				object obj7 = 0;
				obj4 = obj7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ X0_v38 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1>)+135]");
				int num19 = (int)((nint)0 & (nint)1);
				bool flag10 = num19 == 0;
				num10 = 0;
				if (flag10)
				{
					goto IL_02be;
				}
				obj5 = obj7;
				_003C_003Ec__12 = _003C_003Ec__11;
				goto IL_02e2;
				IL_02be:
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				obj5 = obj4;
				_003C_003Ec__12 = _003C_003Ec__11;
				goto IL_02e2;
				IL_0364:
				_003C_003E9 = _003C_003Ec__12;
				nint num20 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ X0_v24 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1>)+135]");
				int num21 = (int)((nint)0 & (nint)1);
				bool flag11 = num21 == 0;
				nint num22 = 0;
				if (!flag11)
				{
					goto IL_03ac;
				}
				goto IL_04ca;
				IL_02e2:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v105 @ X21_v1 (should have been resolved before IL gen)");
				nint num23 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ X0_v5 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1>)+135]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					nint num24 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ X0_v25 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>)+135]");
					int num25 = (int)((nint)0 & (nint)1);
					bool flag12 = num25 == 0;
					nint num26 = 0;
					if (!flag12)
					{
						goto IL_0364;
					}
				}
				else
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ X0_v16+C0]");
					object obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ X8_v16+10]");
					nint num26 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ X0_v13 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>)+135]");
					if ((uint)((nuint)0u & (nuint)1u) != 0)
					{
						goto IL_0364;
					}
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X0_v14+B8]");
				object obj9 = 0;
				obj9 = _003C_003Ec__12;
				nint num27 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ X0_v15 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1>)+135]");
				int num28 = (int)((nint)0 & (nint)1);
				bool flag13 = num28 == 0;
				bool flag14 = !flag13;
				num22 = 0;
				if (flag14)
				{
					goto IL_03ac;
				}
				goto IL_04ca;
			}

			[Token(Token = "0x6000063")]
			[Address(RVA = "0x4FFCDDC", Offset = "0x4FFCDDC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec__9()
			{
			}

			internal unsafe bool _003CRemoveNulls_003Eb__9_0(T item)
			{
				//IL_0010: Expected O, but got I
				//IL_0034: Expected O, but got I
				//IL_0047: Expected I4, but got I8
				//IL_0137: Expected O, but got I
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
				object obj = 0;
				T val2 = default(T);
				T val = val2;
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ X19_v1 (Il2CppClass<T>)+FC]");
				object obj2 = (nint)0 + (nint)15;
				int num2 = (int)((nint)obj2 & 0x1FFFFFFF0L);
				byte* ptr = stackalloc byte[(int)(uint)num2];
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ X19_v1 (Il2CppClass<T>)+28]");
				bool flag = (nint)0 < (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ X19_v1 (Il2CppClass<T>)+28]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ X19_v1 (Il2CppClass<T>)+28]");
				int num4 = (int)(num3 ^ 0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ X19_v1 (Il2CppClass<T>)+28]");
				int num5 = (int)((nint)0 & (nint)num4);
				bool flag2 = num5 < 0;
				if (flag != flag2)
				{
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A1C");
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C12B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
				object obj3 = 0;
				object obj4 = default(object);
				if (obj3 == obj)
				{
					return (byte)((nint)obj4 ^ 1) != 0;
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5CF0");
				bool result = default(bool);
				return result;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000014")]
		private sealed class _003CGetRandomSample_003Ed__4<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000039")]
			[FieldOffset(Offset = "0x0")]
			private int _003C_003E1__state;

			[Token(Token = "0x400003A")]
			[FieldOffset(Offset = "0x0")]
			private T _003C_003E2__current;

			[Token(Token = "0x400003B")]
			[FieldOffset(Offset = "0x0")]
			private int _003C_003El__initialThreadId;

			[Token(Token = "0x400003C")]
			[FieldOffset(Offset = "0x0")]
			private IReadOnlyList<T> list;

			[Token(Token = "0x400003D")]
			[FieldOffset(Offset = "0x0")]
			public IReadOnlyList<T> _003C_003E3__list;

			[Token(Token = "0x400003E")]
			[FieldOffset(Offset = "0x0")]
			private int count;

			[Token(Token = "0x400003F")]
			[FieldOffset(Offset = "0x0")]
			public int _003C_003E3__count;

			[Token(Token = "0x4000040")]
			[FieldOffset(Offset = "0x0")]
			private Random rng;

			[Token(Token = "0x4000041")]
			[FieldOffset(Offset = "0x0")]
			public Random _003C_003E3__rng;

			[Token(Token = "0x4000042")]
			[FieldOffset(Offset = "0x0")]
			private T[] _003Cbuffer_003E5__2;

			[Token(Token = "0x4000043")]
			[FieldOffset(Offset = "0x0")]
			private int _003Ci_003E5__3;

			[Token(Token = "0x1700000E")]
			T IEnumerator<T>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000068")]
				[Address(RVA = "0x73677FC", Offset = "0x73677FC", Length = "0x48")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = Il2CppClass<T>;\n\tv17 = Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>;\n\tv19 = *([v17 @ X8_v3 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]) + 0x20;\n\tv20 = 0x21C1054(this, v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\treturnVal1 = 0x8BF6A34(il2cppRetVal, v20, *([v15 @ X9_v1 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal1;\n")]
				get
				{
					//IL_0022: Expected O, but got I
					nint num = 0;
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ X8_v3 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]");
					object obj = (nint)0 + (nint)32;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1054");
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A34");
					T result = default(T);
					return result;
				}
			}

			[Token(Token = "0x1700000F")]
			unsafe object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600006A")]
				[Address(RVA = "0x736787C", Offset = "0x736787C", Length = "0xB0")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = *([A4731E0]);\n\tv22 = Il2CppClass<T>;\n\tv26 = *([v22 @ X9_v1 (Il2CppClass<T>)+FC]) + 0xF;\n\tv27 = v26 & 0x1FFFFFFF0;\n\t// 21 StackAlloc v28 @ X21_v1 (System.Byte*), v27 @ X10_v2 (System.Int32)\n\tv30 = Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>;\n\tv32 = *([v30 @ X8_v6 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]) + 0x20;\n\tv33 = 0x21C1054(this, v32, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv52 = 0x8BF6A1C(v28, v33, *([v22 @ X9_v1 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t// 35 Box returnVal1 @ X0_v5 (System.Object), typeof(Il2CppClass<T>), v28 @ X21_v1 (System.Byte*)\n\tv60 = *([A4731E0]);\n\tv71 = *([v60 @ X9_v4]) != *([v17 @ X8_v2]);\n\tif (v71) goto L_003C;\n\treturn returnVal1;\nL_003C:\n\treturnVal2 = 0x8BF5CF0(returnVal1, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal2;\n")]
				get
				{
					//IL_0010: Expected O, but got I
					//IL_002c: Expected O, but got I
					//IL_003f: Expected I4, but got I8
					//IL_0066: Expected O, but got I
					//IL_00a6: Expected O, but got I
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
					object obj = 0;
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X9_v1 (Il2CppClass<T>)+FC]");
					object obj2 = (nint)0 + (nint)15;
					int num2 = (int)((nint)obj2 & 0x1FFFFFFF0L);
					byte* ptr = stackalloc byte[(int)(uint)num2];
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X8_v6 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]");
					object obj3 = (nint)0 + (nint)32;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1054");
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A1C");
					object result = (nint)ptr;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
					object obj4 = 0;
					if (obj4 == obj)
					{
						return result;
					}
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5CF0");
					object result2 = default(object);
					return result2;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000065")]
			[Address(RVA = "0x7366B50", Offset = "0x7366B50", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tv23 = Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>;\n\tv24 = *([v23 @ X8_v3 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]);\n\tv27 = 0x815C(*([v23 @ X8_v3 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]), 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv43 = 0x21C1054(this, *([v23 @ X8_v3 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v43 @ X0_v4]) = <>1__state;\n\tv47 = 0x21C0FD4(*([v24 @ X22_v1+8]), v43, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv49 = System.Environment::get_CurrentManagedThreadId();\n\tv53 = Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>;\n\tv54 = *([v53 @ X8_v6 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]);\n\tv55 = *([v53 @ X8_v6 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]) + 0x40;\n\tv57 = 0x815C(v55, 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv58 = *([v53 @ X8_v6 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]) + 0x40;\n\tv60 = 0x21C1054(this, v58, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v60 @ X0_v12]) = v49;\n\tv70 = 0x21C0FD4(*([v54 @ X19_v2+48]), v60, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\n")]
			public _003CGetRandomSample_003Ed__4(int _003C_003E1__state)
			{
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X8_v3 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]");
				object obj = 0;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @815C");
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1054");
				object obj2 = _003C_003E1__state;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C0FD4");
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v6 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v6 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]");
				object obj4 = (nint)0 + (nint)64;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @815C");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v6 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]");
				object obj5 = (nint)0 + (nint)64;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1054");
				object obj6 = currentManagedThreadId;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C0FD4");
			}

			[DebuggerHidden]
			[Token(Token = "0x6000066")]
			[Address(RVA = "0x7366C04", Offset = "0x7366C04", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000067")]
			[Address(RVA = "0x7366C08", Offset = "0x7366C08", Length = "0xBF4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv31 = *([A4731E0]);\n\tgoto L_0022;\n\tv100 = *([v94 @ X0_v7]) == 1;\n\tif (v100) goto L_0124;\n\tv105 = *([v94 @ X0_v7]) == 0;\n\tv106 = ~v105;\n\tif (v106) goto L_02E8;\n\tv117 = Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>;\n\tv1106 = *([v117 @ X8_v134 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]);\n\tv121 = 0x815C(*([v117 @ X8_v134 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]), 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv225 = 0x21C1054(this, *([v117 @ X8_v134 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v225 @ X0_v123]) = -1;\n\tv351 = 0x21C0FD4(*([v1106 @ X22_v28 (System.Byte*)+8]), v225, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv626 = Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>;\n\tv628 = *([v626 @ X8_v138 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]) + 0x60;\n\tv630 = 0x21C1054(this, v628, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv634 = *([v630 @ X0_v127]) == 0;\n\tif (v634) goto L_0437;\n\tv655 = Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>;\n\tv657 = *([v655 @ X8_v143 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]) + 0xA0;\n\tv659 = 0x21C1054(this, v657, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1131 = *([v659 @ X0_v129]);\n\tv665 = *([v659 @ X0_v129]) & 0x80000000;\n\tv666 = v665 == 0;\n\tv667 = ~v666;\n\tif (v667) goto L_015E;\n\tv724 = Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>;\n\tv726 = *([v724 @ X8_v202 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]) + 0xA0;\n\tv728 = 0x21C1054(this, v726, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv799 = Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>;\n\tv801 = *([v799 @ X8_v206 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]) + 0x60;\n\tv803 = 0x21C1054(this, v801, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv748 = *([v803 @ X0_v195]);\n\tgoto L_0096;\n\tv743 = *([v1014 @ X8_v212 (Il2CppClass<System.Byte*>)+B0]) + 8;\n\tv744 = v743 + 0x10;\n\tv1042 = v1073 - 1;\n\tv1041 = v1073 != 1;\nL_FFFFFFFF:\n\tv1073 = v1042;\nL_FFFFFFFF:\n\tv743 = v744;\n\tif (v1041) goto L_00A1;\nL_00B7:\n\tv1131 = *([v1061 @ X0_v217]);\n\tv780 = System.Collections.Generic.IReadOnlyCollection`1<T>::get_Count(v748);\n\tv738 = *([v728 @ X0_v193]) > v780;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv1106 = v748;\n\tif (v738) goto L_015E;\nL_00CA:\n\tv1151 = Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>;\n\tv1153 = *([v1151 @ X8_v216 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]) + 0xE0;\n\tv1155 = 0x21C1054(this, v1153, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1199 = *([v1155 @ X0_v199]) == 0;\n\tv1200 = ~v1199;\n\tif (v1200) goto L_00EB;\n\tv1216 = new System.Random();\n\tSystem.Random::.ctor(v1216);\n\tv1226 = Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>;\n\tv1222 = *([v1226 @ X8_v233 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]);\n\tv1272 = *([v1226 @ X8_v233 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]) + 0xE0;\n\tv1274 = 0x815C(v1272, 8, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1307 = *([v1226 @ X8_v233 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]) + 0xE0;\n\tv1309 = 0x21C1054(this, v1307, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v1309 @ X0_v213]) = v1216;\n\tv1224 = 0x21C0FD4(*([v1222 @ X23_v26+E8]), v1309, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\t;\nL_00EB:\n\tv1229 = Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>;\n\tv956 = *([v1229 @ X8_v222 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]) + 0x60;\n\tv968 = 0x21C1054(this, v956, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1106 = *([v968 @ X0_v202]);\n\tgoto L_00FF;\n\tv744 = *([v1131 @ X8_v197 (Il2CppClass<System.Byte*>)+B0]) + 8;\n\tv744 = v744 + 0x10;\n\tv1329 = v1102 - 1;\n\tv1328 = v1102 != 1;\nL_FFFFFFFF:\n\tv1102 = v1329;\n\tif (v1328) goto L_010A;\nL_FFFFFFFF:\n\tv850 = v1096;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv200 = *([v61 @ X8_v7 (Il2CppClass<T>)+FC]);\nL_FFFFFFFF:\n\tv204 = this;\n\tgoto L_0178;\nL_0124:\n\tv110 = Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>;\n\tv111 = *([v110 @ X8_v125 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]);\n\tv114 = 0x815C(*([v110 @ X8_v125 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]), 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv222 = 0x21C1054(this, *([v110 @ X8_v125 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v222 @ X0_v111]) = -1;\n\tv346 = 0x21C0FD4(*([v111 @ X22_v15+8]), v222, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv619 = Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>;\n\tv621 = *([v619 @ X8_v129 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]) + 0x140;\n\tv623 = 0x21C1054(this, v621, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv643 = Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>;\n\tv692 = *([v643 @ X9_v34 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]);\n\tv645 = *([v623 @ X0_v115]) + 1;\n\tv646 = *([v643 @ X9_v34 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]) + 0x140;\n\tv648 = 0x815C(v646, 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbe\n// ... truncated")]
			private unsafe bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ListExtension._003CGetRandomSample_003Ed__4::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000069")]
			[Address(RVA = "0x7367844", Offset = "0x7367844", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = 0xB292000 + 0x4A0;\n\tv28 = new v12();\n\tSystem.NotSupportedException::.ctor(v28);\n\tthrow v28;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}

			[DebuggerHidden]
			[Token(Token = "0x600006B")]
			[Address(RVA = "0x736792C", Offset = "0x736792C", Length = "0x220")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>;\n\tv26 = 0x21C1054(this, *([v24 @ X8_v3 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]), v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = *([v26 @ X0_v1]) != -2;\n\tif (v52) goto L_004C;\n\tv55 = Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>;\n\tv57 = *([v55 @ X8_v38 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]) + 0x40;\n\tv59 = 0x21C1054(this, v57, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv81 = System.Environment::get_CurrentManagedThreadId();\n\tv63 = *([v59 @ X0_v37]) != v81;\n\tif (v63) goto L_004C;\n\tv106 = Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>;\n\tv107 = *([v106 @ X8_v42 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]);\n\tv110 = 0x815C(*([v106 @ X8_v42 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]), 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv139 = 0x21C1054(this, *([v106 @ X8_v42 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv139.m_value = 0;\n\tv126 = Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>::.ctor(*([v107 @ X21_v7+8]), v139);\n\tv113 = this;\n\tgoto L_0058;\nL_004C:\n\tgoto L_004E;\nL_004E:\n\tv95 = new Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>();\n\tv103 = Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>::.ctor(v95, 0);\n\tv113 = v95;\n\tv145 = Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>;\n\tv146 = *([v145 @ X8_v12 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]);\n\tv147 = *([v145 @ X8_v12 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]) + 0x60;\n\tv149 = 0x815C(v147, 8, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv151 = *([v145 @ X8_v12 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]) + 0x60;\n\tv153 = 0x21C1054(v113, v151, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v153 @ X0_v9]) = *([v136 @ X0_v4]);\n\tv157 = 0x21C0FD4(*([v146 @ X23_v1+68]), v153, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv184 = Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>;\n\tv186 = *([v184 @ X8_v15 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]) + 0xC0;\n\tv188 = 0x21C1054(this, v186, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv192 = Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>;\n\tv193 = *([v192 @ X8_v19 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]);\n\tv194 = *([v192 @ X8_v19 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]) + 0xA0;\n\tv196 = 0x815C(v194, 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv197 = *([v192 @ X8_v19 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]) + 0xA0;\n\tv199 = 0x21C1054(v113, v197, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v199 @ X0_v17]) = *([v188 @ X0_v13]);\n\tv203 = 0x21C0FD4(*([v193 @ X23_v2+A8]), v199, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv206 = Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>;\n\tv208 = *([v206 @ X8_v22 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]) + 0x100;\n\tv210 = 0x21C1054(this, v208, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv175 = Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>;\n\tv214 = *([v175 @ X8_v26 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]);\n\tv215 = *([v175 @ X8_v26 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]) + 0xE0;\n\tv217 = 0x815C(v215, 8, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv218 = *([v175 @ X8_v26 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]) + 0xE0;\n\tv220 = 0x21C1054(v113, v218, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v220 @ X0_v25]) = *([v210 @ X0_v21]);\n\tv222 = 0x21C0FD4(*([v214 @ X19_v2+E8]), v220, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn v113;\nL_0058:\n\tv132 = Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>;\n\tv134 = *([v132 @ X8_v8 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]) + 0x80;\n\tv136 = 0x21C1054(this, v134, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n")]
			IEnumerator<T> IEnumerable<T>.GetEnumerator()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ListExtension._003CGetRandomSample_003Ed__4::GetEnumerator");
				return default;
			}

			[DebuggerHidden]
			[Token(Token = "0x600006C")]
			[Address(RVA = "0x7367B4C", Offset = "0x7367B4C", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis = Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>::System.Collections.Generic.IEnumerable<T>.GetEnumerator(this);\n\treturn this;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				((IEnumerable<T>)this).GetEnumerator();
				return this;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000015")]
		private sealed class _003CSliceRange_003Ed__3<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000044")]
			[FieldOffset(Offset = "0x0")]
			private int _003C_003E1__state;

			[Token(Token = "0x4000045")]
			[FieldOffset(Offset = "0x0")]
			private T _003C_003E2__current;

			[Token(Token = "0x4000046")]
			[FieldOffset(Offset = "0x0")]
			private int _003C_003El__initialThreadId;

			[Token(Token = "0x4000047")]
			[FieldOffset(Offset = "0x0")]
			private IList<T> list;

			[Token(Token = "0x4000048")]
			[FieldOffset(Offset = "0x0")]
			public IList<T> _003C_003E3__list;

			[Token(Token = "0x4000049")]
			[FieldOffset(Offset = "0x0")]
			private int startIndex;

			[Token(Token = "0x400004A")]
			[FieldOffset(Offset = "0x0")]
			public int _003C_003E3__startIndex;

			[Token(Token = "0x400004B")]
			[FieldOffset(Offset = "0x0")]
			private int endIndexInclusive;

			[Token(Token = "0x400004C")]
			[FieldOffset(Offset = "0x0")]
			public int _003C_003E3__endIndexInclusive;

			[Token(Token = "0x400004D")]
			[FieldOffset(Offset = "0x0")]
			private int _003Ci_003E5__2;

			[Token(Token = "0x17000010")]
			T IEnumerator<T>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000070")]
				[Address(RVA = "0x502F2B4", Offset = "0x502F2B4", Length = "0x48")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = Il2CppClass<T>;\n\tv17 = Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>;\n\tv19 = *([v17 @ X8_v3 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]) + 0x20;\n\tv20 = 0x21C1054(this, v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\treturnVal1 = 0x8BF6A34(il2cppRetVal, v20, *([v15 @ X9_v1 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal1;\n")]
				get
				{
					//IL_0022: Expected O, but got I
					nint num = 0;
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ X8_v3 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]");
					object obj = (nint)0 + (nint)32;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1054");
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A34");
					T result = default(T);
					return result;
				}
			}

			[Token(Token = "0x17000011")]
			unsafe object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000072")]
				[Address(RVA = "0x502F334", Offset = "0x502F334", Length = "0xB0")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = *([A4731E0]);\n\tv22 = Il2CppClass<T>;\n\tv26 = *([v22 @ X9_v1 (Il2CppClass<T>)+FC]) + 0xF;\n\tv27 = v26 & 0x1FFFFFFF0;\n\t// 21 StackAlloc v28 @ X21_v1 (System.Byte*), v27 @ X10_v2 (System.Int32)\n\tv30 = Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>;\n\tv32 = *([v30 @ X8_v6 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]) + 0x20;\n\tv33 = 0x21C1054(this, v32, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv52 = 0x8BF6A1C(v28, v33, *([v22 @ X9_v1 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t// 35 Box returnVal1 @ X0_v5 (System.Object), typeof(Il2CppClass<T>), v28 @ X21_v1 (System.Byte*)\n\tv60 = *([A4731E0]);\n\tv71 = *([v60 @ X9_v4]) != *([v17 @ X8_v2]);\n\tif (v71) goto L_003C;\n\treturn returnVal1;\nL_003C:\n\treturnVal2 = 0x8BF5CF0(returnVal1, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal2;\n")]
				get
				{
					//IL_0010: Expected O, but got I
					//IL_002c: Expected O, but got I
					//IL_003f: Expected I4, but got I8
					//IL_0066: Expected O, but got I
					//IL_00a6: Expected O, but got I
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
					object obj = 0;
					nint num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X9_v1 (Il2CppClass<T>)+FC]");
					object obj2 = (nint)0 + (nint)15;
					int num2 = (int)((nint)obj2 & 0x1FFFFFFF0L);
					byte* ptr = stackalloc byte[(int)(uint)num2];
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X8_v6 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]");
					object obj3 = (nint)0 + (nint)32;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1054");
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A1C");
					object result = (nint)ptr;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
					object obj4 = 0;
					if (obj4 == obj)
					{
						return result;
					}
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5CF0");
					object result2 = default(object);
					return result2;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x600006D")]
			[Address(RVA = "0x502ECC0", Offset = "0x502ECC0", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tv23 = Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>;\n\tv24 = *([v23 @ X8_v3 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]);\n\tv27 = 0x815C(*([v23 @ X8_v3 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]), 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv43 = 0x21C1054(this, *([v23 @ X8_v3 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v43 @ X0_v4]) = <>1__state;\n\tv47 = 0x21C0FD4(*([v24 @ X22_v1+8]), v43, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv49 = System.Environment::get_CurrentManagedThreadId();\n\tv53 = Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>;\n\tv54 = *([v53 @ X8_v6 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]);\n\tv55 = *([v53 @ X8_v6 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]) + 0x40;\n\tv57 = 0x815C(v55, 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv58 = *([v53 @ X8_v6 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]) + 0x40;\n\tv60 = 0x21C1054(this, v58, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v60 @ X0_v12]) = v49;\n\tv70 = 0x21C0FD4(*([v54 @ X19_v2+48]), v60, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\n")]
			public _003CSliceRange_003Ed__3(int _003C_003E1__state)
			{
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X8_v3 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]");
				object obj = 0;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @815C");
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1054");
				object obj2 = _003C_003E1__state;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C0FD4");
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v6 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v6 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]");
				object obj4 = (nint)0 + (nint)64;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @815C");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v6 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]");
				object obj5 = (nint)0 + (nint)64;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1054");
				object obj6 = currentManagedThreadId;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C0FD4");
			}

			[DebuggerHidden]
			[Token(Token = "0x600006E")]
			[Address(RVA = "0x502ED74", Offset = "0x502ED74", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x600006F")]
			[Address(RVA = "0x502ED78", Offset = "0x502ED78", Length = "0x53C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = *([A4731E0]);\n\tv28 = Il2CppClass<T>;\n\tv32 = *([v28 @ X9_v1 (Il2CppClass<T>)+FC]) + 0xF;\n\tv442 = v32 & 0x1FFFFFFF0;\n\t// 24 StackAlloc v34 @ X22_v1 (System.Byte*), v442 @ X10_v18 (System.Int32)\n\tv36 = Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>;\n\tv38 = 0x21C1054(this, *([v36 @ X8_v6 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]), v326, v458, v453, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv58 = *([v38 @ X0_v1]) == 1;\n\tif (v58) goto L_00C6;\n\tv63 = *([v38 @ X0_v1]) == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_010C;\n\tv74 = Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>;\n\tv75 = *([v74 @ X8_v73 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]);\n\tv78 = 0x815C(*([v74 @ X8_v73 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]), 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv157 = 0x21C1054(this, *([v74 @ X8_v73 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v157 @ X0_v85]) = -1;\n\tv254 = 0x21C0FD4(*([v75 @ X23_v16+8]), v157, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv386 = Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>;\n\tv388 = *([v386 @ X8_v77 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]) + 0x60;\n\tv390 = 0x21C1054(this, v388, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv489 = *([v390 @ X0_v89]) == 0;\n\tif (v489) goto L_01C6;\n\tv516 = Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>;\n\tv438 = *([v516 @ X8_v82 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]) + 0xA0;\n\tv434 = 0x21C1054(this, v438, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv561 = *([v434 @ X0_v91]) & 0x80000000;\n\tv562 = v561 == 0;\n\tv408 = ~v562;\n\tif (v408) goto L_01B1;\n\tv573 = Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>;\n\tv575 = *([v573 @ X8_v87 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]) + 0xE0;\n\tv577 = 0x21C1054(this, v575, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv594 = Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>;\n\tv439 = *([v594 @ X8_v91 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]) + 0xA0;\n\tv435 = 0x21C1054(this, v439, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv401 = *([v577 @ X0_v93]) < *([v435 @ X0_v95]);\n\tif (v401) goto L_01B1;\n\tv624 = Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>;\n\tv626 = *([v624 @ X8_v96 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]) + 0xE0;\n\tv628 = 0x21C1054(this, v626, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv322 = *([v628 @ X0_v97]);\n\tv638 = Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>;\n\tv615 = *([v638 @ X8_v100 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]) + 0x60;\n\tv613 = 0x21C1054(this, v615, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv327 = *([v613 @ X0_v99]);\n\tgoto L_008B;\n\tv352 = *([v355 @ X8_v50+B0]) + 8;\n\tv442 = v352 + 0x10;\n\tv692 = v354 - 1;\n\tv674 = v354 != 1;\n\tv352 = v442;\n\tv354 = v692;\n\tif (v674) goto L_0096;\nL_00AF:\n\tv436 = System.Collections.Generic.ICollection`1<T>::get_Count(v327);\n\tv402 = v322 >= v436;\n\tif (v402) goto L_01B1;\nL_00BD:\n\tv481 = Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>;\n\tv483 = *([v481 @ X8_v69 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]) + 0xA0;\n\tv485 = 0x21C1054(this, v483, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv495 = *([v485 @ X0_v81]);\n\tgoto L_00DF;\nL_00C6:\n\tv67 = Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>;\n\tv68 = *([v67 @ X8_v59 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]);\n\tv71 = 0x815C(*([v67 @ X8_v59 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]), 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv154 = 0x21C1054(this, *([v67 @ X8_v59 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v154 @ X0_v74]) = -1;\n\tv249 = 0x21C0FD4(*([v68 @ X23_v12+8]), v154, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv379 = Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>;\n\tv381 = *([v379 @ X8_v63 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]) + 0x120;\n\tv383 = 0x21C1054(this, v381, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv495 = *([v383 @ X0_v78]) + 1;\n\tv587 = Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>;\n\tv589 = *([v587 @ X8_v14 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]) + 0x120;\n\tv591 = 0x21C1054(this, v589, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv327 = *([v591 @ X0_v10]);\n\tv604 = Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>;\n\tv128 = *([v604 @ X8_v18 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]) + 0xE0;\n\tv126 = 0x21C1054(this, v128, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv101 = *([v591 @ X0_v10]) <= *([v126 @ X0_v12]);\n\tv326 = 0;\n\tif (v101) goto L_0126;\nL_010C:\n\tv140 = *([A4731E0]);\n\tv151 = *([v140 @ X9_v22]) != *([v23 @ X8_v2]);\n\treturnVal1 = 0;\n\tv238 = 0;\n\tif (v151) goto L_019B;\nL_0123:\n\treturn returnVal1;\nL_0126:\n\tv631 = Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>;\n\tv633 = *([v631 @ X8_v23 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]) + 0x60;\n\tv635 = 0x21C1054(this, v633, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv327 = *([v635 @ X0_v14]);\n\tv642 = Il2CppClass<Unc\n// ... truncated")]
			private unsafe bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ListExtension._003CSliceRange_003Ed__3::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000071")]
			[Address(RVA = "0x502F2FC", Offset = "0x502F2FC", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = 0xB292000 + 0x4A0;\n\tv28 = new v12();\n\tSystem.NotSupportedException::.ctor(v28);\n\tthrow v28;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000073")]
			[Address(RVA = "0x502F3E4", Offset = "0x502F3E4", Length = "0x220")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>;\n\tv26 = 0x21C1054(this, *([v24 @ X8_v3 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]), v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = *([v26 @ X0_v1]) != -2;\n\tif (v52) goto L_004C;\n\tv55 = Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>;\n\tv57 = *([v55 @ X8_v38 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]) + 0x40;\n\tv59 = 0x21C1054(this, v57, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv81 = System.Environment::get_CurrentManagedThreadId();\n\tv63 = *([v59 @ X0_v37]) != v81;\n\tif (v63) goto L_004C;\n\tv106 = Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>;\n\tv107 = *([v106 @ X8_v42 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]);\n\tv110 = 0x815C(*([v106 @ X8_v42 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]), 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv139 = 0x21C1054(this, *([v106 @ X8_v42 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv139.m_value = 0;\n\tv126 = Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>::.ctor(*([v107 @ X21_v7+8]), v139);\n\tv113 = this;\n\tgoto L_0058;\nL_004C:\n\tgoto L_004E;\nL_004E:\n\tv95 = new Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>();\n\tv103 = Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>::.ctor(v95, 0);\n\tv113 = v95;\n\tv145 = Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>;\n\tv146 = *([v145 @ X8_v12 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]);\n\tv147 = *([v145 @ X8_v12 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]) + 0x60;\n\tv149 = 0x815C(v147, 8, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv151 = *([v145 @ X8_v12 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]) + 0x60;\n\tv153 = 0x21C1054(v113, v151, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v153 @ X0_v9]) = *([v136 @ X0_v4]);\n\tv157 = 0x21C0FD4(*([v146 @ X23_v1+68]), v153, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv184 = Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>;\n\tv186 = *([v184 @ X8_v15 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]) + 0xC0;\n\tv188 = 0x21C1054(this, v186, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv192 = Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>;\n\tv193 = *([v192 @ X8_v19 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]);\n\tv194 = *([v192 @ X8_v19 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]) + 0xA0;\n\tv196 = 0x815C(v194, 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv197 = *([v192 @ X8_v19 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]) + 0xA0;\n\tv199 = 0x21C1054(v113, v197, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v199 @ X0_v17]) = *([v188 @ X0_v13]);\n\tv203 = 0x21C0FD4(*([v193 @ X23_v2+A8]), v199, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv206 = Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>;\n\tv208 = *([v206 @ X8_v22 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]) + 0x100;\n\tv210 = 0x21C1054(this, v208, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv175 = Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>;\n\tv214 = *([v175 @ X8_v26 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]);\n\tv215 = *([v175 @ X8_v26 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]) + 0xE0;\n\tv217 = 0x815C(v215, 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv218 = *([v175 @ X8_v26 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]) + 0xE0;\n\tv220 = 0x21C1054(v113, v218, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v220 @ X0_v25]) = *([v210 @ X0_v21]);\n\tv222 = 0x21C0FD4(*([v214 @ X19_v2+E8]), v220, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn v113;\nL_0058:\n\tv132 = Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>;\n\tv134 = *([v132 @ X8_v8 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]) + 0x80;\n\tv136 = 0x21C1054(this, v134, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n")]
			IEnumerator<T> IEnumerable<T>.GetEnumerator()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ListExtension._003CSliceRange_003Ed__3::GetEnumerator");
				return default;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000074")]
			[Address(RVA = "0x502F604", Offset = "0x502F604", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis = Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>::System.Collections.Generic.IEnumerable<T>.GetEnumerator(this);\n\treturn this;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				((IEnumerable<T>)this).GetEnumerator();
				return this;
			}
		}

		[Token(Token = "0x4000036")]
		private static Random _random;

		[Token(Token = "0x6000055")]
		[Address(RVA = "0x4A0DF7C", Offset = "0x4A0DF7C", Length = "0x518")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv31 = *([A4731E0]);\n\tgoto L_0026;\n\tgoto L_0026;\n\tv55 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0055;\n\tv388 = v371 >= 2;\n\tv124 = v371;\n\tv175 = v74;\n\tif (v388) goto L_00FA;\n\tgoto L_00B5;\nL_0091:\n\tv390 = System.Guid::NewGuid();\n\tv402 = v390;\n\tv401 = 0;\n\tv443 = System.Guid::GetHashCode(&v402 @ stack_-90_v6 (System.Guid));\n\tv475 = new System.Random();\n\tSystem.Random::.ctor(v475, v443);\n\tv517._random = v475;\n\tv407 = v371 >= 2;\n\tv124 = v371;\n\tv175 = v74;\n\tif (v407) goto L_00FA;\nL_00B5:\n\tv456 = *([A4731E0]);\n\tv215 = *([v456 @ X9_v40]) != *([v31 @ X8_v2]);\n\tif (v215) goto L_0205;\n\treturn originalList;\nL_00D4:\n\tv877 = 0x220C5E0(originalList, Il2CppClass<System.Collections.Generic.IList`1<T>>, 1, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_00D6:\n\tv562 = &v481 @ stack_-7C_v4 (System.Int32);\n\tv395 = v78;\n\tv426 = *([v877 @ X0_v39+8]);\n\tv426._inext(v429, *([v426 @ X1_v25 (System.Random)+8]), v426, originalList, &v562 @ stack_-78_v4, v78, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv406 = v124 <= 2;\n\tv124 = v397;\n\tv175 = v74;\n\tif (v406) goto L_00B5;\nL_00FA:\n\tv463 = System.Random::Next(v177._random, 0, v124);\n\tgoto L_0107;\n\tv529 = *([v482 @ X8_v33 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]) + 8;\n\tv529 = v529 + 0x10;\n\tv493 = v520 - 1;\n\tv491 = v520 != 1;\n\tv520 = v493;\n\tif (v491) goto L_010F;\nL_0129:\n\tv559 = 0x220C5E0(originalList, Il2CppClass<System.Collections.Generic.IList`1<T>>, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0130;\nL_012B:\n\t;\n\tv542 = *([v529 @ X10_v27]) << 4;\n\tv543 = v482 + v542;\n\tv559 = v543 + 0x138;\n\tv631 = *([v588 @ X8_v40 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]) + 8;\n\tv631 = v631 + 0x10;\n\tv598 = v622 - 1;\n\tv596 = v622 != 1;\n\tv622 = v598;\n\tif (v596) goto L_014F;\nL_0169:\n\tv660 = 0x220C5E0(originalList, Il2CppClass<System.Collections.Generic.IList`1<T>>, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0170;\nL_016B:\n\t;\n\tv643 = *([v631 @ X10_v22]) << 4;\n\tv644 = v588 + v643;\n\tv660 = v644 + 0x138;\n\tv745 = *([v702 @ X8_v48 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]) + 8;\n\tv745 = v745 + 0x10;\n\tv712 = v736 - 1;\n\tv710 = v736 != 1;\n\tv736 = v712;\n\tif (v710) goto L_019B;\nL_01B5:\n\tv775 = 0x220C5E0(originalList, Il2CppClass<System.Collections.Generic.IList`1<T>>, 1, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_01BD;\nL_01B7:\n\t;\n\tv757 = *([v745 @ X10_v17]) + 1;\n\tv758 = v757 << 4;\n\tv759 = v702 + v758;\n\tv775 = v759 + 0x138;\n\tv855 = *([v813 @ X8_v56 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]) + 8;\n\tv855 = v855 + 0x10;\n\tv822 = v846 - 1;\n\tv820 = v846 != 1;\n\tv846 = v822;\n\tif (v820) goto L_01E5;\n\tgoto L_00D4;\nL_01FE:\n\t;\n\tv868 = *([v855 @ X10_v10]) + 1;\n\tv865 = v868 << 4;\n\tv880 = v813 + v865;\n\tv877 = v880 + 0x138;\n\tgoto L_00D6;\nL_0205:\n\treturnVal1 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal1;\nL_0026:\n\tv62 = Il2CppClass<T>;\n\tv66 = *([v62 @ X8_v4 (Il2CppClass<T>)+FC]) + 0xF;\n\tv67 = v66 & 0x1FFFFFFF0;\n\t// 43 StackAlloc v68 @ X22_v1 (System.Byte*), v67 @ X26_v1 (System.Int32)\n\t// 46 StackAlloc v71 @ X23_v1 (System.Byte*), v67 @ X26_v1 (System.Int32)\n\t// 49 StackAlloc v74 @ X8_v8 (System.Byte*), v67 @ X26_v1 (System.Int32)\n\t// 53 StackAlloc v78 @ X25_v1 (System.Byte*), v67 @ X26_v1 (System.Int32)\n\tv81 = 0;\n\t// 58 StackAlloc v83 @ X0_v2 (System.Byte*), v67 @ X26_v1 (System.Int32)\n\tv87 = 0x8BF5F18(v83, *([v62 @ X8_v4 (Il2CppClass<T>)+FC]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t// 64 StackAlloc v91 @ X0_v4 (System.Byte*), v67 @ X26_v1 (System.Int32)\n\tv95 = 0x8BF5F18(v91, *([v62 @ X8_v4 (Il2CppClass<T>)+FC]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0055:\n\tgoto L_007B;\nL_007B:\n\tv371 = System.Collections.Generic.ICollection`1<T>::get_Count(originalList);\n\tv378 = v376._random == 0;\n\tif (v378) goto L_0091;\nL_0107:\n\tv397 = v124 - 1;\n\tv481 = v397;\n\tv482 = originalList->klass;\n\tv520 = originalList->klass->interface_offsets_count;\n\tv484 = *([v482 @ X8_v33 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]) == 0;\n\tif (v484) goto L_0129;\nL_010F:\n\t;\n\tv534 = *([v529 @ X10_v27-8]) == Il2CppClass<System.Collections.Generic.IList`1<T>>;\n\tif (v534) goto L_012B;\nL_0130:\n\tv562 = &v481 @ stack_-7C_v4 (System.Int32);\n\tv563 = v68;\n\tv564 = *([v559 @ X0_v18+8]);\n\t*([v564 @ X1_v12+10])(v570, *([v564 @ X1_v12+8]), v564, originalList, &v562 @ stack_-78_v4, v68, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv574 = 0x8BF6A1C(v83, v68, *([v62 @ X8_v4 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0148;\nL_0148:\n\tv481 = v463;\n\tv588 = originalList->klass;\n\tv622 = originalList->klass->interface_offsets_count;\n\tv590 = *([v588 @ X8_v40 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]) == 0;\n\tif (v590) goto L_0169;\nL_014F:\n\t;\n\tv636 = *([v631 @ X10_v22-8]) == Il2CppClass<System.Collections.Generic.IList`1<T>>;\n\tif (v636) goto L_016B;\nL_0170:\n\tv562 = &v481 @ stack_-7C_v4 (System.Int32);\n\tv664 = v71;\n\tv665 = *([v660 @ X0_v24+8]);\n\t*([v665 @ X1_v16+10])(v671, *([v665 @ X1_v16+8]), v665, originalList, &v562 @ stack_-78_v4, v71, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv675 = 0x8BF6A1C(v91, v71, *([v62 @ X8_v4 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv679 = 0x8BF6A1C(v175, v83, *([v62 @ X8_v4 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0192;\nL_0192:\n\tgoto L_0194;\nL_019B:\n\t;\n\tv750 = *([v745 @ X10_v17-8]) == Il2CppClass<System.Collections.Generic.IList`1<T>>;\n\tif (v750) goto L_01B7;\nL_01BD:\n\tv562 = &v481 @ stack_-7C_v4 (System.Int32);\n\tv779 = v175;\n\tv780 = *([v775 @ X0_v32+8]);\n\t*([v780 @ X1_v21+10])(v786, *([v780 @ X1_v21+8]), v780, originalList, &v562 @ stack_-78_v4, v175, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv790 = 0x8BF6A1C(v78, v91, *([v62 @ X8_v4 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_01DC;\nL_01DC:\n\tgoto L_01DE;\nL_01E5:\n\t;\n\tv860 = *([v855 @ X10_v10-8]) == Il2CppClass<System.Collections.Generic.IList`1<T>>;\n\tif (v860) goto L_01FE;\nL_0194:\n\tv481 = v463;\n\tv702 = originalList->klass;\n\tv736 = originalList->klass->interface_offsets_count;\n\tv704 = *([v702 @ X8_v48 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]) == 0;\n\tif (v704) goto L_01B5;\nL_01DE:\n\tv481 = v397;\n\tv813 = originalList->klass;\n\tv846 = originalList->klass->interface_offsets_co\n// ... truncated")]
		public unsafe static IList<T> Shuffle<T>(this IList<T> originalList)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ListExtension::Shuffle");
			return default;
		}

		[Token(Token = "0x6000056")]
		[Address(RVA = "0x4A0CE00", Offset = "0x4A0CE00", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tgoto L_0022;\n\tv43 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0022:\n\tv68 = v54._random;\n\tv56 = v54._random == 0;\n\tv57 = ~v56;\n\tif (v57) goto L_0041;\n\tv61 = System.Guid::NewGuid();\n\tv73 = v61;\n\tv85 = System.Guid::GetHashCode(&v73 @ stack_-50_v3 (System.Guid));\n\tv98 = new System.Random();\n\tSystem.Random::.ctor(v98, v85);\n\tv101._random = v98;\n\tv68 = v77._random;\nL_0041:\n\treturnVal1 = Unco.Extensions.ListExtension::GetRandom(originalList, v68);\n\treturn returnVal1;\n")]
		public static T GetRandom<T>(this IReadOnlyList<T> originalList)
		{
			Random random = _random;
			if (_random == null)
			{
				Guid guid = Guid.NewGuid();
				Guid guid2 = guid;
				int hashCode = guid2.GetHashCode();
				Random random2 = new Random(hashCode);
				_random = random2;
				random = _random;
			}
			return originalList.GetRandom(random);
		}

		[IteratorStateMachine(typeof(_003CSliceRange_003Ed__3<>))]
		[Token(Token = "0x6000057")]
		[Address(RVA = "0x4A0E494", Offset = "0x4A0E494", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv55 = Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>;\n\tgoto L_0019;\nL_0019:\n\tv58 = new v55();\n\tv67 = Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>::.ctor(v58, -2);\n\tv70 = Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>;\n\tv71 = *([v70 @ X8_v9 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]);\n\tv72 = *([v70 @ X8_v9 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]) + 0x80;\n\tv74 = 0x815C(v72, 8, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv76 = *([v70 @ X8_v9 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]) + 0x80;\n\tv78 = 0x21C1054(v58, v76, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v78 @ X0_v11]) = list;\n\tv82 = 0x21C0FD4(*([v71 @ X24_v1+88]), v78, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv108 = Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>;\n\tv109 = *([v108 @ X8_v11 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]);\n\tv110 = *([v108 @ X8_v11 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]) + 0xC0;\n\tv112 = 0x815C(v110, 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv113 = *([v108 @ X8_v11 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]) + 0xC0;\n\tv115 = 0x21C1054(v58, v113, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v115 @ X0_v17]) = startIndex;\n\tv119 = 0x21C0FD4(*([v109 @ X23_v2+C8]), v115, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv96 = Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>;\n\tv121 = *([v96 @ X8_v13 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]);\n\tv122 = *([v96 @ X8_v13 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]) + 0x100;\n\tv124 = 0x815C(v122, 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv125 = *([v96 @ X8_v13 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]) + 0x100;\n\tv127 = 0x21C1054(v58, v125, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v127 @ X0_v23]) = endIndexInclusive;\n\tv129 = 0x21C0FD4(*([v121 @ X20_v2+108]), v127, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn v58;\n\tv35 = 0x220C2B8(methodInfo, startIndex, endIndexInclusive, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv55 = Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>;\n\tgoto L_0019;\n")]
		public static IEnumerable<T> SliceRange<T>(this IList<T> list, int startIndex, int endIndexInclusive)
		{
			//IL_003a: Expected O, but got I
			//IL_0050: Expected O, but got I
			//IL_0075: Expected O, but got I
			//IL_00b6: Expected O, but got I
			//IL_00cc: Expected O, but got I
			//IL_00f6: Expected O, but got I
			//IL_010d: Expected O, but got I4
			//IL_0137: Expected O, but got I
			//IL_014d: Expected O, but got I
			//IL_0172: Expected O, but got I
			//IL_018e: Expected O, but got I4
			nint num = 0;
			IEnumerable<T> result = new _003CSliceRange_003Ed__3<T>(-2);
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ X8_v9 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ X8_v9 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]");
			object obj2 = (nint)0 + (nint)128;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @815C");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ X8_v9 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]");
			object obj3 = (nint)0 + (nint)128;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1054");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C0FD4");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ X8_v11 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ X8_v11 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]");
			object obj5 = (nint)0 + (nint)192;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @815C");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ X8_v11 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]");
			object obj6 = (nint)0 + (nint)192;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1054");
			object obj7 = startIndex;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C0FD4");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ X8_v13 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ X8_v13 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]");
			object obj9 = (nint)0 + (nint)256;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @815C");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ X8_v13 (Il2CppClass<Unco.Extensions.ListExtension+<SliceRange>d__3`1<T>>)+80]");
			object obj10 = (nint)0 + (nint)256;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1054");
			object obj11 = endIndexInclusive;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C0FD4");
			return result;
		}

		[IteratorStateMachine(typeof(_003CGetRandomSample_003Ed__4<>))]
		[Token(Token = "0x6000058")]
		[Address(RVA = "0x4A0D4EC", Offset = "0x4A0D4EC", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv55 = Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>;\n\tgoto L_0019;\nL_0019:\n\tv58 = new v55();\n\tv67 = Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>::.ctor(v58, -2);\n\tv70 = Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>;\n\tv71 = *([v70 @ X8_v9 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]);\n\tv72 = *([v70 @ X8_v9 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]) + 0x80;\n\tv74 = 0x815C(v72, 8, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv76 = *([v70 @ X8_v9 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]) + 0x80;\n\tv78 = 0x21C1054(v58, v76, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v78 @ X0_v11]) = list;\n\tv82 = 0x21C0FD4(*([v71 @ X24_v1+88]), v78, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv108 = Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>;\n\tv109 = *([v108 @ X8_v11 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]);\n\tv110 = *([v108 @ X8_v11 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]) + 0xC0;\n\tv112 = 0x815C(v110, 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv113 = *([v108 @ X8_v11 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]) + 0xC0;\n\tv115 = 0x21C1054(v58, v113, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v115 @ X0_v17]) = count;\n\tv119 = 0x21C0FD4(*([v109 @ X23_v2+C8]), v115, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv96 = Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>;\n\tv121 = *([v96 @ X8_v13 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]);\n\tv122 = *([v96 @ X8_v13 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]) + 0x100;\n\tv124 = 0x815C(v122, 8, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv125 = *([v96 @ X8_v13 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]) + 0x100;\n\tv127 = 0x21C1054(v58, v125, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v127 @ X0_v23]) = rng;\n\tv129 = 0x21C0FD4(*([v121 @ X20_v2+108]), v127, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn v58;\n\tv35 = 0x220C2B8(methodInfo, count, rng, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv55 = Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>;\n\tgoto L_0019;\n")]
		public static IEnumerable<T> GetRandomSample<T>(this IReadOnlyList<T> list, int count, Random? rng = null)
		{
			//IL_003a: Expected O, but got I
			//IL_0050: Expected O, but got I
			//IL_0075: Expected O, but got I
			//IL_00b6: Expected O, but got I
			//IL_00cc: Expected O, but got I
			//IL_00f6: Expected O, but got I
			//IL_010d: Expected O, but got I4
			//IL_0137: Expected O, but got I
			//IL_014d: Expected O, but got I
			//IL_0172: Expected O, but got I
			nint num = 0;
			IEnumerable<T> result = new _003CGetRandomSample_003Ed__4<T>(-2);
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ X8_v9 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ X8_v9 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]");
			object obj2 = (nint)0 + (nint)128;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @815C");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ X8_v9 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]");
			object obj3 = (nint)0 + (nint)128;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1054");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C0FD4");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ X8_v11 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ X8_v11 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]");
			object obj5 = (nint)0 + (nint)192;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @815C");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ X8_v11 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]");
			object obj6 = (nint)0 + (nint)192;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1054");
			object obj7 = count;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C0FD4");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ X8_v13 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ X8_v13 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]");
			object obj9 = (nint)0 + (nint)256;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @815C");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ X8_v13 (Il2CppClass<Unco.Extensions.ListExtension+<GetRandomSample>d__4`1<T>>)+80]");
			object obj10 = (nint)0 + (nint)256;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1054");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C0FD4");
			return result;
		}

		[Token(Token = "0x6000059")]
		[Address(RVA = "0x4A0D060", Offset = "0x4A0D060", Length = "0x204")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv24 = 0x220C2B8(v283, random, v283, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_001A:\n\tgoto L_001E;\n\tv256 = *([v122 @ X8_v9 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<T>>)+B0]) + 8;\n\tv153 = v256 + 0x10;\n\tv178 = v247 - 1;\n\tv176 = v247 != 1;\nL_FFFFFFFF:\n\tv247 = v178;\nL_FFFFFFFF:\n\tv256 = v153;\n\tif (v176) goto L_0029;\nL_003F:\n\tv385 = *([v199 @ X0_v37]);\n\tv269 = System.Collections.Generic.IReadOnlyCollection`1<T>::get_Count(originalList);\n\tv270 = v269 == 0;\nL_FFFFFFFF:\n\t;\n\tif (v270) goto L_00B8;\nL_004C:\n\tgoto L_0050;\n\tv153 = *([v385 @ X8_v10 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<T>>)+B0]) + 8;\n\tv153 = v153 + 0x10;\n\tv340 = v356 - 1;\n\tv339 = v356 != 1;\nL_FFFFFFFF:\n\tv356 = v340;\n\tif (v339) goto L_005B;\nL_0074:\n\tv404 = System.Collections.Generic.IReadOnlyCollection`1<T>::get_Count(originalList);\nL_FFFFFFFF:\n\tv233 = originalList;\nL_007D:\n\tv411 = System.Random::Next(random, 0, v404);\n\tgoto L_008A;\n\tv153 = *([v162 @ X8_v19 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<T>>)+B0]) + 8;\n\tv153 = v153 + 0x10;\n\tv426 = v136 - 1;\n\tv425 = v136 != 1;\nL_FFFFFFFF:\n\tv136 = v426;\n\tif (v425) goto L_0095;\nL_FFFFFFFF:\n\tv234 = v411;\n\tgoto L_00DC;\nL_00AD:\n\tv273 = *([v256 @ X10_v21]) << 4;\n\tv274 = v122 + v273;\n\tv275 = v274 + 0x138;\n\tv385 = *([v275 @ X0_v40]);\n\t*([v275 @ X0_v40])(v279, originalList, *([v275 @ X0_v40+8]), v283, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv280 = v279 == 0;\n\tv281 = ~v280;\nL_FFFFFFFF:\n\tv153 = v256;\n\tif (v281) goto L_004C;\nL_00B8:\n\tv325 = 0xB290000 + 0x6B8;\n\tv335 = new v325();\n\tSystem.IndexOutOfRangeException::.ctor(v335);\n\tthrow v335;\nL_00C2:\n\tv52 = *([v153 @ X10_v2]) << 4;\n\tv386 = v385 + v52;\n\tv387 = v386 + 0x138;\n\t*([v387 @ X0_v10])(v404, originalList, *([v387 @ X0_v10+8]), 0, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv389 = random == 0;\n\tv109 = ~v389;\n\tif (v109) goto L_007D;\n\tthrow System.NullReferenceException;\nL_00CE:\n\t;\nL_FFFFFFFF:\n\tv233 = v233;\nL_001E:\n\tv122 = originalList->klass;\n\tv247 = originalList->klass->interface_offsets_count;\n\tv124 = *([v122 @ X8_v9 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<T>>)+12E]) == 0;\n\tif (v124) goto L_003F;\nL_0029:\n\tv261 = *([v256 @ X10_v21-8]) == Il2CppClass<System.Collections.Generic.IReadOnlyCollection`1<T>>;\n\tif (v261) goto L_00AD;\nL_0050:\n\tv385 = originalList->klass;\n\tv356 = originalList->klass->interface_offsets_count;\n\tv334 = *([v385 @ X8_v10 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<T>>)+12E]) == 0;\n\tif (v334) goto L_0074;\nL_005B:\n\tv370 = *([v153 @ X10_v2-8]) == Il2CppClass<System.Collections.Generic.IReadOnlyCollection`1<T>>;\nL_FFFFFFFF:\n\tv233 = originalList;\n\tif (v370) goto L_00C2;\nL_008A:\n\tv162 = *([v233 @ X19_v2 (System.Collections.Generic.IReadOnlyList`1<T>)]);\n\tv136 = *([v162 @ X8_v19 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<T>>)+12E]);\n\tv160 = *([v162 @ X8_v19 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<T>>)+12E]) == 0;\n\tif (v160) goto L_FFFFFFFF;\nL_0095:\n\tv146 = *([v153 @ X10_v2-8]) == Il2CppClass<System.Collections.Generic.IReadOnlyList`1<T>>;\nL_FFFFFFFF:\n\tv234 = v411;\n\tif (v146) goto L_00CE;\nL_00DC:\n\tinterfaceTailCallResult = System.Collections.Generic.IReadOnlyList`1<T>::get_Item(v233, v234);\nL_00DC:\n\treturn interfaceTailCallResult;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T GetRandom<T>(this IReadOnlyList<T> originalList, Random random)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ListExtension::GetRandom");
			return default;
		}

		[Token(Token = "0x600005A")]
		[Address(RVA = "0x4A0C6B0", Offset = "0x4A0C6B0", Length = "0x244")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv29 = *([A4731E0]);\n\tv32 = v382;\n\tgoto L_001C;\n\tv37 = 0x220C2B8(methodInfo, v382, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv66 = *([v54 @ X8_v4 (Il2CppClass<T>)+28]) < 0;\n\tv69 = *([v54 @ X8_v4 (Il2CppClass<T>)+28]) ^ *([v54 @ X8_v4 (Il2CppClass<T>)+28]);\n\tv70 = *([v54 @ X8_v4 (Il2CppClass<T>)+28]) & v69;\n\tv71 = v70 < 0;\n\tv73 = v66 == v71;\n\tv74 = ~v73;\n\tv75 = ~v74;\n\tif (v75) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv243 = v382;\n\tgoto L_003A;\nL_FFFFFFFF:\n\tv243 = &v32 @ stack_-70_v1 (T);\nL_FFFFFFFF:\n\tv136 = *([v59 @ X20_v1 (System.Byte*)]);\n\tv334 = *([v300 @ X8_v13 (Il2CppClass<System.Collections.Generic.ICollection`1<T>>)+B0]) + 8;\n\tv334 = v334 + 0x10;\n\tv308 = v333 - 1;\n\tv312 = v333 != 1;\nL_FFFFFFFF:\n\tv333 = v308;\n\tif (v312) goto L_0054;\nL_006E:\n\tv360 = 0x220C5E0(list, Il2CppClass<System.Collections.Generic.ICollection`1<T>>, 4, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0075;\nL_0071:\n\tv355 = *([v334 @ X10_v16]) + 4;\n\tv356 = v355 << 4;\n\tv357 = v300 + v356;\n\tv360 = v357 + 0x138;\nL_0084:\n\tv142 = *([A4731E0]);\n\tv153 = *([v142 @ X9_v6]) != *([v29 @ X8_v2]);\nL_FFFFFFFF:\n\treturnVal1 = 0;\nL_FFFFFFFF:\n\tv238 = 0;\n\tif (v153) goto L_0106;\nL_009D:\n\treturn returnVal1;\nL_009F:\n\tv366 = Il2CppClass<T>;\n\tv371 = *([v366 @ X8_v17 (Il2CppClass<T>)+28]) < 0;\n\tv374 = *([v366 @ X8_v17 (Il2CppClass<T>)+28]) ^ *([v366 @ X8_v17 (Il2CppClass<T>)+28]);\n\tv375 = *([v366 @ X8_v17 (Il2CppClass<T>)+28]) & v374;\n\tv376 = v375 < 0;\n\tv378 = v371 == v376;\n\tv379 = ~v378;\n\tv178 = ~v379;\n\tif (v178) goto L_00B5;\n\tgoto L_00B5;\n\tv437 = *([v404 @ X8_v24 (Il2CppClass<System.Collections.Generic.ICollection`1<T>>)+B0]) + 8;\n\tv437 = v437 + 0x10;\n\tv411 = v436 - 1;\n\tv415 = v436 != 1;\nL_FFFFFFFF:\n\tv436 = v411;\n\tif (v415) goto L_00CE;\nL_00E8:\n\tv472 = 0x220C5E0(list, Il2CppClass<System.Collections.Generic.ICollection`1<T>>, 2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_00EF;\nL_00EB:\n\tv458 = *([v437 @ X10_v11]) + 2;\n\tv459 = v458 << 4;\n\tv460 = v404 + v459;\n\tv472 = v460 + 0x138;\nL_0106:\n\treturnVal2 = 0x8BF5CF0(v238, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal2;\nL_001C:\n\tv54 = Il2CppClass<T>;\n\tv57 = *([v54 @ X8_v4 (Il2CppClass<T>)+FC]) + 0xF;\n\tv58 = v57 & 0x1FFFFFFF0;\n\t// 33 StackAlloc v59 @ X20_v1 (System.Byte*), v58 @ X10_v2 (System.Int32)\n\tv61 = list == 0;\n\tif (v61) goto L_0084;\nL_003A:\n\tv246 = 0x8BF6A1C(v59, v243, *([v54 @ X8_v4 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0049;\nL_0049:\n\tv295 = *([v54 @ X8_v4 (Il2CppClass<T>)+28]) & 0x80000000;\n\tv296 = v295 == 0;\n\tv297 = ~v296;\nL_FFFFFFFF:\n\tv136 = v59;\n\tif (v297) goto L_004E;\nL_0054:\n\t;\n\tv348 = *([v334 @ X10_v16-8]) == Il2CppClass<System.Collections.Generic.ICollection`1<T>>;\n\tif (v348) goto L_0071;\nL_0075:\n\tv84 = v136;\n\tv99 = *([v360 @ X0_v10+8]);\n\t*([v99 @ X1_v7 (T)+10])(v132, *([v99 @ X1_v7 (T)+8]), *([v360 @ X0_v10+8]), list, &v84 @ stack_-60_v4 (System.IntPtr), &v77 @ stack_-61_v4, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv364 = v77 & 1;\n\tv134 = v364 == 0;\n\tif (v134) goto L_009F;\nL_00B5:\n\tv385 = 0x8BF6A1C(v59, &v32 @ stack_-70_v1 (T), *([v54 @ X8_v4 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_00C6;\nL_00C6:\n\tgoto L_00C8;\nL_00CE:\n\t;\n\tv451 = *([v437 @ X10_v11-8]) == Il2CppClass<System.Collections.Generic.ICollection`1<T>>;\n\tif (v451) goto L_00EB;\nL_00EF:\n\tv84 = v59;\n\tv176 = *([v472 @ X0_v16+8]);\n\t*([v176 @ X1_v11 (T)+10])(v476, *([v176 @ X1_v11 (T)+8]), *([v472 @ X0_v16+8]), list, &v84 @ stack_-60_v4 (System.IntPtr), v59, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv478 = *([A4731E0]);\n\tv190 = *([v478 @ X9_v13]) == *([v29 @ X8_v2]);\nL_FFFFFFFF:\n\treturnVal1 = 1;\nL_FFFFFFFF:\n\tv238 = 1;\n\tif (v190) goto L_009D;\nL_004E:\n\tv300 = list->klass;\n\tv333 = list->klass->interface_offsets_count;\n\tv302 = *([v300 @ X8_v13 (Il2CppClass<System.Collections.Generic.ICollection`1<T>>)+12E]) == 0;\n\tif (v302) goto L_006E;\nL_00C8:\n\tv404 = list->klass;\n\tv436 = list->klass->interface_offsets_count;\n\tv201 = *([v404 @ X8_v24 (Il2CppClass<System.Collections.Generic.ICollection`1<T>>)+12E]) == 0;\n\tif (v201) goto L_00E8;\n")]
		public unsafe static bool AddIfNotContain<T>(this ICollection<T> list, T newElement)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ListExtension::AddIfNotContain");
			return default;
		}

		[Token(Token = "0x600005B")]
		[Address(RVA = "0x4A0D630", Offset = "0x4A0D630", Length = "0x404")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv31 = *([A4731E0]);\n\tgoto L_001D;\n\tv39 = 0x220C2B8(methodInfo, methodInfo, v40, v41, v42, v201, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0053:\n\tv113 = new Il2CppClass<System.Collections.Generic.List`1<T>>();\n\tv119 = System.Collections.Generic.List`1<T>::.ctor(v113);\n\tv120 = originalList == 0;\n\tif (v120) goto L_00FD;\n\tv123 = Il2CppMethodInfo;\n\tv125 = v92;\n\t*([v123 @ X1_v12 (Il2CppMethodInfo)+10])(v130, *([v123 @ X1_v12 (Il2CppMethodInfo)]), Il2CppMethodInfo, originalList, &v125 @ stack_-90_v6 (System.Byte*), v92, v201, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv134 = 0x8BF6A1C(v95, v92, *([v57 @ X0_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv145 = v113 == 0;\n\tv146 = ~v145;\n\tv168 = v92;\n\tv171 = *([v57 @ X0_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+FC]);\n\tv174 = &v125 @ stack_-90_v6 (System.Byte*);\n\tif (v146) goto L_00BE;\n\tv149 = Il2CppMethodInfo;\n\tv149.m_value(v152, v259, Il2CppMethodInfo, *([v57 @ X0_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+FC]), &v125 @ stack_-90_v6 (System.Byte*), v92, v201, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv153 = v152 == 0;\n\tv154 = ~v153;\n\tv251 = &v259 @ stack_-B0_v3 (System.Byte*);\n\tv255 = &v80 @ stack_-A8_v1 (System.Byte*);\n\tv265 = &v137 @ stack_-A0_v6 (Il2CppMethodInfo);\n\tv278 = 0;\n\tif (v154) goto L_0105;\nL_007E:\n\tv309 = &v137 @ stack_-A0_v6 (Il2CppMethodInfo);\n\tv311 = *([v309 @ X21_v8 (System.Byte*)]);\n\tv430 = *([v311 @ X8_v55 (Il2CppClass<System.Byte*>)+38]);\n\tv414 = *([v430 @ X8_v22+18]);\n\tv314 = *([v430 @ X8_v22+18]) + 0x135;\n\tv316 = *([v314 @ X9_v25]) & 1;\n\tv317 = v316 == 0;\n\tv318 = ~v317;\n\tv398 = &v137 @ stack_-A0_v6 (Il2CppMethodInfo);\n\tv400 = 0;\n\tv402 = &v259 @ stack_-B0_v3 (System.Byte*);\n\tv403 = &v80 @ stack_-A8_v1 (System.Byte*);\n\tv407 = &v137 @ stack_-A0_v6 (Il2CppMethodInfo);\n\tv411 = 0;\n\tv246 = &v137 @ stack_-A0_v6 (Il2CppMethodInfo);\n\tv249 = 0;\n\tv251 = &v259 @ stack_-B0_v3 (System.Byte*);\n\tv255 = &v80 @ stack_-A8_v1 (System.Byte*);\n\tv265 = &v137 @ stack_-A0_v6 (Il2CppMethodInfo);\n\tv278 = 0;\n\tv428 = *([v430 @ X8_v22+18]);\n\tif (v318) goto L_008B;\nL_0088:\n\tv428 = 0x220C238(v414, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv443 = *([v398 @ X21_v7 (System.Byte*)]);\n\tv430 = *([v443 @ X8_v33 (Il2CppClass<System.Byte*>)+38]);\n\tv246 = v398;\n\tv249 = v400;\n\tv251 = v402;\n\tv255 = v403;\n\tv265 = v407;\n\tv278 = v411;\n\tv454 = *([A4731E0]);\n\tv320 = *([v454 @ X9_v9]) != *([v31 @ X8_v2]);\n\tif (v320) goto L_0102;\n\treturn v113;\nL_00B5:\n\tv178 = Il2CppMethodInfo;\n\tv162 = v246;\n\t*([v178 @ X1_v21 (Il2CppMethodInfo)+10])(v181, *([v178 @ X1_v21 (Il2CppMethodInfo)]), Il2CppMethodInfo, v113, &v162 @ stack_-70_v9 (System.IntPtr), v246, v201, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv168 = v246;\n\tv171 = v113;\n\tv174 = &v162 @ stack_-70_v9 (System.IntPtr);\n\tv350 = Il2CppMethodInfo;\n\tv207 = v246;\n\t*([v350 @ X1_v16 (Il2CppMethodInfo)+10])(v357, *([v350 @ X1_v16 (Il2CppMethodInfo)]), Il2CppMethodInfo, v259, &v207 @ stack_-70_v4 (System.Byte*), v246, v201, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv361 = 0x8BF6A1C(v100, v246, v249, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv438 = 0x8BF6A1C(v87, v246, v249, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_00E1;\n\tv482 = 0x8BF6A1C(v246, v100, v249, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_00B5;\nL_00FD:\n\tv135 = new System.NullReferenceException();\n\tv282 = Il2CppMethodInfo;\n\tgoto L_0116;\nL_0100:\n\tv287 = new System.OutOfMemoryException();\n\tv135 = v287;\n\tgoto L_0116;\nL_0102:\n\tv335 = 0x8BF5CF0(v432, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0105:\n\tv340 = Il2CppMethodInfo;\n\tv207 = v246;\n\t*([v340 @ X1_v8 (Il2CppMethodInfo)+10])(v343, *([v340 @ X1_v8 (Il2CppMethodInfo)]), Il2CppMethodInfo, v95, &v207 @ stack_-70_v4 (System.Byte*), v246, 0, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv347 = 0x8BF6A1C(v100, v246, v249, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv434 = 0x8BF6A1C(v87, v246, v249, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv135 = new System.NullReferenceException();\n\tv282 = v246;\nL_0116:\n\t// 278 Interrupt\n\tgoto L_012A;\nL_012A:\n\tv363 = v282 != 1;\n\tif (v363) goto L_013D;\n\tv440 = 0x8BF5BC4(v135, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv400 = *([v440 @ X0_v25]);\n\tv452 = 0x8BF5BF4(v440, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv462 = *([v265 @ stack_-88_v2 (System.Byte*)]);\n\tv430 = *([v462 @ X8_v26 (Il2CppClass<System.Byte*>)+38]);\n\tv414 = *([v430 @ X8_v22+18]);\n\tv463 = *([v430 @ X8_v22+18]) + 0x135;\n\tv464 = *([v463 @ X9_v12]) & 1;\n\tv417 = v464 == 0;\n\tv398 = v265;\n\tv402 = v251;\n\tv403 = v255;\n\tv407 = v265;\n\tv411 = *([v440 @ X0_v25]);\n\tif (v417) goto L_0088;\n\tv246 = v265;\n\tv249 = *([v440 @ X0_v25]);\n\tv278 = *([v440 @ X0_v25]);\n\tv428 = *([v430 @ X8_v22+18]);\n\tgoto L_008B;\nL_001D:\n\tv57 = Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>;\n\tv59 = Il2CppClass<T>;\n\tv249 = *([v59 @ X8_v4 (Il2CppClass<T>)+FC]);\n\tgoto L_002B;\nL_00BE:\n\tv191 = Il2CppMethodInfo;\n\tv191.m_value(v194, v259, Il2CppMethodInfo, v171, v174, v168, v201, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv195 = v194 & 1;\n\tv196 = v195 == 0;\n\tif (v196) goto L_007E;\nL_008B:\n\tv282 = *([v430 @ X8_v22+50]);\n\tv432 = 0x21C1F68(v428, *([v430 @ X8_v22+50]), *([v255 @ stack_-80_v2]), *([v251 @ stack_-78_v2]), 0, 0, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv444 = v249 == 0;\n\tv290 = ~v444;\n\tif (v290) goto L_0100;\nL_00E1:\n\tv179 = Il2CppMethodInfo;\n\tv164 = v87;\n\t*([v179 @ X1_v19 (Il2CppMethodInfo)+10])(v182, *([v179 @ X1_v19 (Il2CppMethodInfo)]), Il2CppMethodInfo, v113, &v164 @ stack_-70_v8 (System.IntPtr), &v156 @ stack_-91_v6, v201, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv460 = v156 & 1;\n\tv461 = v460 == 0;\n\tv185 = ~v461;\n\tv168 = &v156 @ stack_-91_v6;\n\tv171 = v113;\n\tv174 = &v164 @ stack_-70_v8 (System.IntPtr);\n\tif (v185) goto L_00BE;\nL_013D:\n\tv442 = 0x31C481C(&v278 @ stack_-90_v2 (System.Collections.Generic.List`1<T>), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_011C;\nL_011C:\n\tv135 = 0x8BF0368(v135, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_012A;\nL_002B:\n\tv73 = *([v57 @ X0_v2 (Il2CppClass<Sy\n// ... truncated")]
		public unsafe static List<T> GetUniqueList<T>(this List<T> originalList)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ListExtension::GetUniqueList");
			return default;
		}

		[Token(Token = "0x600005C")]
		[Address(RVA = "0x4A0C8F4", Offset = "0x4A0C8F4", Length = "0x390")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv29 = *([A4731E0]);\n\tgoto L_0025;\n\tgoto L_0025;\n\tv52 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_003E;\n\tv437 = v365;\n\tv269 = v365 == 0;\n\tif (v269) goto L_0146;\n\tgoto L_00AA;\n\tv691 = *([v584 @ X8_v34 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\n\tv691 = v691 + 0x10;\n\tv626 = v682 - 1;\n\tv624 = v682 != 1;\n\tv682 = v626;\n\tif (v624) goto L_00B0;\nL_00CA:\n\tv717 = 0x220C5E0(v365, Il2CppClass<System.Collections.Generic.IEnumerator`1<T>>, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_00D0;\nL_00CC:\n\t;\n\tv711 = *([v691 @ X10_v23]) << 4;\n\tv712 = v584 + v711;\n\tv717 = v712 + 0x138;\nL_00F2:\n\tv265 = new System.NullReferenceException();\n\tv304 = &v210 @ stack_-78_v6 (System.Collections.IEnumerator);\n\tv216 = 0;\n\tv332 = v262;\n\tgoto L_014B;\nL_00F5:\n\tv510 = &v210 @ stack_-78_v6 (System.Collections.IEnumerator);\n\tv532 = *([v510 @ X8_v30]);\n\tv512 = *([v510 @ X8_v30]) == 0;\n\tv529 = &v210 @ stack_-78_v6 (System.Collections.IEnumerator);\n\tv216 = 0;\n\tv551 = originalList;\n\tv553 = 0;\n\tv304 = &v210 @ stack_-78_v6 (System.Collections.IEnumerator);\n\tv216 = 0;\n\tv332 = 0;\n\tv160 = originalList;\n\tv164 = 0;\n\tif (v512) goto L_0126;\nL_00FF:\n\tgoto L_0125;\n\tv617 = *([A4731E0]);\n\tv312 = *([v617 @ X9_v7]) != *([v29 @ X8_v2]);\n\tif (v312) goto L_014C;\n\treturn v160;\nL_0146:\n\tv266 = new System.NullReferenceException();\n\tv304 = &v210 @ stack_-78_v6 (System.Collections.IEnumerator);\n\tv216 = 0;\n\tv332 = 0;\n\tgoto L_014B;\nL_014A:\n\tv166 = new System.OutOfMemoryException();\n\tv304 = v102;\n\tv332 = v151;\nL_014B:\n\t// 331 Interrupt\nL_015D:\n\tv396 = v332 != 1;\n\tif (v396) goto L_016B;\n\tv493 = 0x8BF5BC4(v418, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv553 = *([v493 @ X0_v9]);\n\tv508 = 0x8BF5BF4(v493, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv532 = *([v304 @ stack_-80_v1]);\n\tv515 = *([v304 @ stack_-80_v1]) == 0;\n\tv516 = ~v515;\n\tv529 = v304;\n\tv216 = *([v493 @ X0_v9]);\n\tif (v516) goto L_00FF;\n\tv216 = *([v493 @ X0_v9]);\n\tv160 = v551;\n\tv164 = *([v493 @ X0_v9]);\n\tgoto L_0126;\nL_016B:\n\tv414 = 0x3175484(&v216 @ stack_-88_v4 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv551 = v418;\n\tgoto L_014F;\nL_0025:\n\tv59 = Il2CppClass<T>;\n\tv63 = *([v59 @ X9_v1 (Il2CppClass<T>)+FC]) + 0xF;\n\tv64 = v63 & 0x1FFFFFFF0;\n\t// 42 StackAlloc v65 @ X22_v1 (System.Byte*), v64 @ X10_v2 (System.Int32)\n\t// 45 StackAlloc v68 @ X23_v1 (System.Byte*), v64 @ X10_v2 (System.Int32)\nL_003E:\n\tgoto L_0062;\nL_0062:\n\tv262 = 0;\n\tv365 = System.Collections.Generic.IEnumerable`1<T>::GetEnumerator(v151);\n\tv210 = v365;\n\tv367 = v365 == 0;\n\tif (v367) goto L_00F2;\nL_0098:\n\tv503 = System.Collections.IEnumerator::MoveNext(v437);\n\tv505 = v503 == 0;\n\tif (v505) goto L_00F5;\nL_00AA:\n\tv584 = *([v365 @ X0_v28 (System.Collections.IEnumerator)]);\n\tv682 = *([v584 @ X8_v34 (Il2CppClass<System.Collections.IEnumerator>)+12E]);\n\tv586 = *([v584 @ X8_v34 (Il2CppClass<System.Collections.IEnumerator>)+12E]) == 0;\n\tif (v586) goto L_00CA;\nL_00B0:\n\t;\n\tv696 = *([v691 @ X10_v23-8]) == Il2CppClass<System.Collections.Generic.IEnumerator`1<T>>;\n\tif (v696) goto L_00CC;\nL_00D0:\n\tv719 = v65;\n\tv720 = *([v717 @ X0_v37+8]);\n\t*([v720 @ X1_v17+10])(v726, *([v720 @ X1_v17+8]), v720, v365, &v719 @ stack_-68_v8 (System.Byte*), v65, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv730 = 0x8BF6A1C(v68, v65, *([v59 @ X9_v1 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_00E5;\nL_00E5:\n\tv389 = Il2CppMethodInfo;\n\tv374 = originalList;\n\tv371 = v68;\n\t*([v389 @ X1_v19 (Il2CppMethodInfo)+10])(v391, *([v389 @ X1_v19 (Il2CppMethodInfo)]), Il2CppMethodInfo, 0, &v374 @ stack_-68_v9 (System.Collections.Generic.List`1<T>), &v739 @ stack_-69, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv740 = v365 == 0;\n\tv392 = ~v740;\n\tv262 = Il2CppMethodInfo;\n\tv437 = v365;\n\tif (v392) goto L_0072;\nL_0126:\n\tv578 = v164 == 0;\n\tv156 = ~v578;\n\tif (v156) goto L_014A;\nL_0125:\n\tSystem.IDisposable::Dispose(v532);\n\tv304 = v529;\n\tv332 = 0;\n\tv160 = v551;\n\tv164 = v553;\nL_014C:\n\tv340 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv551 = v340;\nL_014F:\n\tv418 = 0x8BF0368(v551, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_015D;\nL_0072:\n\tgoto L_0098;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static List<T> AddRangeIfNotContains<T>(this List<T> originalList, IEnumerable<T> newElements)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ListExtension::AddRangeIfNotContains");
			return default;
		}

		[Token(Token = "0x600005D")]
		[Address(RVA = "0x4A0DDAC", Offset = "0x4A0DDAC", Length = "0x1D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_000D;\nL_000D:\n\tv20 = Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>;\n\tv23 = *([v20 @ X0_v47 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>)+135]) & 1;\n\tv24 = v23 == 0;\nL_FFFFFFFF:\n\tv49 = Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>;\n\tif (v24) goto L_003A;\nL_0015:\n\tgoto L_0017;\nL_0017:\n\tv63 = Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>;\n\tv66 = *([v63 @ X0_v45 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>)+135]) & 1;\n\tv67 = v66 == 0;\nL_FFFFFFFF:\n\tv73 = Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>;\nL_FFFFFFFF:\n\tv82 = Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>;\n\tif (v67) goto L_0048;\nL_001D:\n\tv79 = *([v73 @ X0_v43 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>)+B8]);\n\tv120 = *([v79 @ X8_v48 (Il2CppStaticFields<Unco.Extensions.ListExtension+<>c__9`1<T>>)+8]);\n\tv81 = *([v79 @ X8_v48 (Il2CppStaticFields<Unco.Extensions.ListExtension+<>c__9`1<T>>)+8]) == 0;\n\tif (v81) goto L_004F;\nL_002F:\n\tv131 = System.Collections.Generic.List`1<T>::RemoveAll(v131, v120);\nL_002F:\n\treturn;\n\tv26 = System.Predicate`1<T>::.ctor(methodInfo, methodInfo, v27);\n\tv42 = Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>;\n\tv55 = *([v42 @ X0_v39 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>)+135]) & 1;\n\tv56 = v55 == 0;\n\tv44 = ~v56;\nL_FFFFFFFF:\n\tv49 = Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>;\n\tif (v44) goto L_0015;\nL_003A:\n\tv52 = 0x220C238(v49, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv72 = *([v52 @ X0_v36+E4]) == 0;\n\tv59 = ~v72;\n\tif (v59) goto L_0017;\n\tv74 = Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>;\n\tv88 = *([v74 @ X0_v34 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>)+135]) & 1;\n\tv89 = v88 == 0;\n\tv76 = ~v89;\nL_FFFFFFFF:\n\tv73 = Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>;\nL_FFFFFFFF:\n\tv82 = Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>;\n\tif (v76) goto L_001D;\nL_0048:\n\tv85 = 0x220C238(v82, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv96 = *([v85 @ X0_v31+B8]);\n\tv120 = *([v96 @ X8_v34+8]);\n\tv108 = *([v96 @ X8_v34+8]) == 0;\n\tv94 = ~v108;\n\tif (v94) goto L_002F;\nL_004F:\n\tv103 = Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>;\n\tv106 = *([v103 @ X0_v29 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>)+135]) & 1;\n\tv107 = v106 == 0;\nL_FFFFFFFF:\n\tv157 = Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>;\n\tif (v107) goto L_008D;\n\tgoto L_0059;\nL_0059:\n\tv173 = Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>;\n\tv176 = *([v173 @ X0_v27 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>)+135]) & 1;\n\tv177 = v176 == 0;\nL_FFFFFFFF:\n\tv216 = Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>;\n\tif (v177) goto L_009B;\nL_0060:\n\tv113 = v202.<>9;\nL_FFFFFFFF:\n\tv242 = Il2CppClass<System.Predicate`1<T>>;\n\tgoto L_0069;\nL_0069:\n\tv245 = new v242();\n\tv252 = System.Predicate`1<T>::.ctor(v245, v113, Il2CppMethodInfo);\nL_FFFFFFFF:\n\tv261 = Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>;\n\tgoto L_007A;\nL_007A:\n\tv262 = *([v261 @ X0_v15 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>)+B8]);\n\t*([v262 @ X8_v17 (Il2CppStaticFields<Unco.Extensions.ListExtension+<>c__9`1<T>>)+8]) = v245;\n\tgoto L_0089;\nL_0089:\n\tv273 = originalList == 0;\n\tv125 = ~v273;\nL_FFFFFFFF:\n\tv120 = v245;\n\tif (v125) goto L_002F;\n\tv157 = new System.NullReferenceException();\nL_008D:\n\tv160 = 0x220C238(v157, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv188 = *([v160 @ X0_v8+E4]) == 0;\n\tv169 = ~v188;\n\tif (v169) goto L_0059;\n\tv197 = Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>;\n\tv221 = *([v197 @ X0_v6 (Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>)+135]) & 1;\n\tv222 = v221 == 0;\n\tv199 = ~v222;\nL_FFFFFFFF:\n\tv216 = Il2CppClass<Unco.Extensions.ListExtension+<>c__9`1<T>>;\n\tif (v199) goto L_0060;\nL_009B:\n\tv219 = 0x220C238(v216, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv224 = *([v219 @ X0_v2+B8]);\n\tv113 = *([v224 @ X9_v2]);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv242 = Il2CppClass<System.Predicate`1<T>>;\n\tgoto L_0069;\n")]
		public static void RemoveNulls<T>(this List<T> originalList)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ListExtension::RemoveNulls");
		}

		[Token(Token = "0x600005E")]
		[Address(RVA = "0x4A0DA34", Offset = "0x4A0DA34", Length = "0x378")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv35 = *([A4731E0]);\n\tv39 = item;\n\tgoto L_0020;\n\tv44 = 0x220C2B8(methodInfo, index, item, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv110 = System.Linq.Enumerable::ToList(enumerable);\n\tv113 = Il2CppClass<T>;\n\tv118 = *([v113 @ X8_v31 (Il2CppClass<T>)+28]) < 0;\n\tv121 = *([v113 @ X8_v31 (Il2CppClass<T>)+28]) ^ *([v113 @ X8_v31 (Il2CppClass<T>)+28]);\n\tv122 = *([v113 @ X8_v31 (Il2CppClass<T>)+28]) & v121;\n\tv123 = v122 < 0;\n\tv125 = v118 == v123;\n\tv126 = ~v125;\n\tv127 = ~v126;\n\tif (v127) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv310 = item;\n\tgoto L_006A;\nL_FFFFFFFF:\n\tv310 = &v39 @ stack_-98_v1 (T);\n\tv280 = Il2CppMethodInfo;\n\tgoto L_0077;\n\tv416 = Il2CppMethodInfo;\n\tv419 = v85;\n\t*([v416 @ X1_v16 (Il2CppMethodInfo)+10])(v423, *([v416 @ X1_v16 (Il2CppMethodInfo)]), Il2CppMethodInfo, v384, &v419 @ stack_-70_v8 (System.Byte*), v85, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv427 = 0x8BF6A1C(v88, v85, *([v62 @ X8_v6 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_00BB;\nL_00C6:\n\tv429 = &v379 @ stack_-A0_v7 (Il2CppMethodInfo);\n\tv430 = *([v429 @ X20_v9]);\n\tv496 = *([v430 @ X8_v46+38]);\n\tv476 = *([v496 @ X8_v18+40]);\n\tv433 = *([v496 @ X8_v18+40]) + 0x135;\n\tv435 = *([v433 @ X9_v20]) & 1;\n\tv436 = v435 == 0;\n\tv437 = ~v436;\nL_FFFFFFFF:\n\tv448 = &v379 @ stack_-A0_v7 (Il2CppMethodInfo);\nL_FFFFFFFF:\n\tv453 = &v384 @ stack_-B0_v7 (System.Byte*);\nL_FFFFFFFF:\n\tv454 = &v81 @ stack_-A8_v1 (System.Byte*);\nL_FFFFFFFF:\n\tv458 = &v379 @ stack_-A0_v7 (Il2CppMethodInfo);\nL_FFFFFFFF:\n\tv154 = 0;\nL_FFFFFFFF:\n\tv483 = 0;\nL_FFFFFFFF:\n\tv291 = &v384 @ stack_-B0_v7 (System.Byte*);\nL_FFFFFFFF:\n\tv292 = &v81 @ stack_-A8_v1 (System.Byte*);\nL_FFFFFFFF:\n\tv295 = &v379 @ stack_-A0_v7 (Il2CppMethodInfo);\nL_FFFFFFFF:\n\tv154 = 0;\nL_FFFFFFFF:\n\tv494 = *([v496 @ X8_v18+40]);\nL_FFFFFFFF:\n\tv206 = 0;\n\tif (v437) goto L_00D3;\nL_00D0:\n\tv494 = 0x220C238(v476, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv502 = *([v448 @ X20_v8]);\n\tv496 = *([v502 @ X8_v27+38]);\nL_FFFFFFFF:\n\tv291 = v453;\nL_FFFFFFFF:\n\tv292 = v454;\nL_FFFFFFFF:\n\tv295 = v458;\nL_FFFFFFFF:\n\tv206 = v483;\nL_00E0:\n\tv213 = *([A4731E0]);\n\tv224 = *([v213 @ X9_v15]) != *([v35 @ X8_v2]);\n\tif (v224) goto L_00FC;\n\treturn;\nL_00FC:\n\tv239 = 0x8BF5CF0(v197, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_00FD:\n\tv279 = new System.NullReferenceException();\n\tgoto L_0101;\nL_0100:\n\tv313 = new System.OutOfMemoryException();\nL_FFFFFFFF:\n\tv279 = v313;\nL_0101:\n\t// 257 Interrupt\nL_FFFFFFFF:\n\tv373 = v279;\nL_0111:\n\tv354 = v310 != 1;\n\tif (v354) goto L_0124;\n\tv439 = 0x8BF5BC4(v376, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv483 = *([v439 @ X0_v17]);\n\tv498 = 0x8BF5BF4(v439, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv504 = *([v295 @ stack_-88_v2]);\n\tv496 = *([v504 @ X8_v21+38]);\n\tv476 = *([v496 @ X8_v18+40]);\n\tv505 = *([v496 @ X8_v18+40]) + 0x135;\n\tv506 = *([v505 @ X9_v10]) & 1;\n\tv479 = v506 == 0;\nL_FFFFFFFF:\n\tv448 = v295;\nL_FFFFFFFF:\n\tv453 = v291;\nL_FFFFFFFF:\n\tv454 = v292;\nL_FFFFFFFF:\n\tv458 = v295;\nL_FFFFFFFF:\n\tv154 = *([v439 @ X0_v17]);\n\tif (v479) goto L_00D0;\nL_FFFFFFFF:\n\tv154 = *([v439 @ X0_v17]);\nL_FFFFFFFF:\n\tv494 = *([v496 @ X8_v18+40]);\nL_FFFFFFFF:\n\tv206 = *([v439 @ X0_v17]);\n\tgoto L_00D3;\nL_0020:\n\tv60 = Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>;\n\tv62 = Il2CppClass<T>;\n\tgoto L_002D;\nL_006A:\n\tv243 = 0x8BF6A1C(v85, v310, *([v62 @ X8_v6 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv272 = v110 == 0;\n\tif (v272) goto L_00FD;\nL_0077:\n\tv324 = index;\n\tv154 = &v324 @ stack_-70_v6 (System.Int32);\n\t*([v280 @ X1_v10 (Il2CppMethodInfo)+10])(v331, *([v280 @ X1_v10 (Il2CppMethodInfo)]), Il2CppMethodInfo, v110, &v154 @ stack_-90 (System.Int32), v85, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv338 = System.Collections.Generic.Queue`1<T>::Clear(enumerable);\n\tv340 = Il2CppMethodInfo;\n\tv342 = v93;\n\t*([v340 @ X1_v12 (Il2CppMethodInfo)+10])(v347, *([v340 @ X1_v12 (Il2CppMethodInfo)]), Il2CppMethodInfo, v110, &v342 @ stack_-90_v8 (System.Byte*), v93, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv352 = 0x8BF6A1C(v399, v93, *([v60 @ X0_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_00BB:\n\tv398 = Il2CppMethodInfo;\n\tv390 = v88;\n\t*([v398 @ X1_v18 (Il2CppMethodInfo)+10])(v501, *([v398 @ X1_v18 (Il2CppMethodInfo)]), Il2CppMethodInfo, enumerable, &v390 @ stack_-70_v9 (System.IntPtr), v88, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\nL_FFFFFFFF:\n\tv399 = v384;\n\tgoto L_009F;\nL_00D3:\n\tv310 = *([v496 @ X8_v18+68]);\n\tv197 = 0x21C1F68(v494, *([v496 @ X8_v18+68]), *([v292 @ stack_-80_v2]), *([v291 @ stack_-78_v2]), 0, 0, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv503 = v206 == 0;\n\tv200 = ~v503;\n\tif (v200) goto L_0100;\nL_0124:\n\tv372 = 0x31C4890(&v154 @ stack_-90 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv373 = v376;\n\tgoto L_0104;\nL_0104:\n\tv376 = 0x8BF0368(v373, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0111;\nL_002D:\n\tv74 = *([v60 @ X0_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+FC]) + 0x10;\n\tv77 = v74 + 0xF;\n\tv78 = v77 & 0x1FFFFFFF0;\n\t// 49 StackAlloc v79 @ X8_v13 (System.Byte*), v78 @ X8_v12 (System.Int32)\n\tv81 = v79;\n\tv83 = *([v62 @ X8_v6 (Il2CppClass<T>)+FC]) + 0xF;\n\tv84 = v83 & 0x1FFFFFFF0;\n\t// 55 StackAlloc v85 @ X21_v1 (System.Byte*), v84 @ X9_v4 (System.Int32)\n\t// 58 StackAlloc v88 @ X22_v1 (System.Byte*), v84 @ X9_v4 (System.Int32)\n\tv91 = *([v60 @ X0_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+FC]) + 0xF;\n\tv92 = v91 & 0x1FFFFFFF0;\n\t// 63 StackAlloc v93 @ X26_v1 (System.Byte*), v92 @ X9_v6 (System.Int32)\n\t// 66 StackAlloc v399 @ X0_v39 (System.Byte*), v92 @ X9_v6 (System.Int32)\n\tv197 = 0x8BF5F18(v399, *([v60 @ X0_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+FC]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv102 = enumerable == 0;\nL_FFFFFFFF:\n\tv310 = *([v60 @ X0_v2 (Il2CppClass<System.Collections.Generic.List`1<T>+Enumerator<T>>)+FC]);\n\tif (v102) goto L_00E0;\nL_009F:\n\tv410 = System.Collections.Generic.List`1<T>+Enumerator<T>::MoveNext(v399);\n\tv412 = v410 == 0;\n\tif (v412) goto L_00C6;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static void InsertAt<T>(this Queue<T> enumerable, int index, T item)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ListExtension::InsertAt");
		}

		[Token(Token = "0x600005F")]
		[Address(RVA = "0x4A0CD50", Offset = "0x4A0CD50", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_000E;\nL_000E:\n\tv22 = list == 0;\n\tif (v22) goto L_0047;\nL_0014:\n\treturnVal2 = System.Collections.Generic.List`1<T>::get_Count(list);\n\tv46 = returnVal2 == 0;\n\tif (v46) goto L_0039;\n\tv57 = ~index;\n\tv58 = index & v57;\n\tv63 = System.Collections.Generic.List`1<T>::get_Count(list);\n\tv76 = v58 < v63;\n\treturnVal2 = v58;\n\tif (v76) goto L_0039;\n\tv130 = System.Collections.Generic.List`1<T>::get_Count(list);\n\treturnVal2 = v130 - 1;\n\tv24 = 0x220C2B8(methodInfo, index, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv56 = list == 0;\n\tv40 = ~v56;\n\tif (v40) goto L_0014;\nL_0047:\n\treturn 0;\nL_0039:\n\treturn returnVal2;\n")]
		public static int GetClampedIndex<T>(this List<T> list, int index)
		{
			if (list != null)
			{
				int num = list.Count;
				if (num != 0)
				{
					int num2 = ~index;
					int num3 = index & num2;
					int count = list.Count;
					bool flag = num3 < count;
					num = num3;
					if (!flag)
					{
						int count2 = list.Count;
						num = count2 - 1;
					}
				}
				return num;
			}
			return 0;
		}

		[Token(Token = "0x6000060")]
		[Address(RVA = "0x4A0CC84", Offset = "0x4A0CC84", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = 0x220C2B8(methodInfo, list2, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0017:\n\tv44 = System.Collections.Generic.List`1<T>::get_Count(list1);\n\tv56 = System.Collections.Generic.List`1<T>::get_Count(list2);\n\tv66 = v44 != v56;\n\tif (v66) goto L_004A;\n\tv71 = System.Collections.Generic.List`1<T>::Sort(list1);\n\tv76 = System.Collections.Generic.List`1<T>::Sort(list2);\n\tv80 = System.Linq.Enumerable::SequenceEqual(v80, list2);\n\treturn list1;\nL_004A:\n\treturn 0;\n")]
		public static bool CompareLists<T>(List<T> list1, List<T> list2)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ListExtension::CompareLists");
			return default;
		}

		[Token(Token = "0x6000061")]
		[Address(RVA = "0x4A0E5D8", Offset = "0x4A0E5D8", Length = "0x5AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv29 = *([A4731E0]);\n\tgoto L_0025;\n\tgoto L_0025;\n\tv52 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0041;\n\tgoto L_0053;\nL_0078:\n\tgoto L_007A;\nL_007A:\n\tv129 = new Il2CppClass<System.Collections.Generic.List`1<T>>();\n\tv177 = System.Collections.Generic.List`1<T>::.ctor(v129, source);\n\tv178 = v129 == 0;\nL_FFFFFFFF:\n\tv430 = source;\n\tif (v178) goto L_020C;\n\tv281 = System.Collections.Generic.List`1<T>::get_Count(v129);\n\tv289 = Unity.Collections.NativeArray`1<T>::.ctor(&v74 @ stack_-98_v1 (Unity.Collections.NativeArray`1<T>), v281, allocator, 1);\n\tv294 = System.Collections.Generic.List`1<T>::get_Count(v129);\n\tv305 = v294 < 1;\n\tif (v305) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv601 = 0;\nL_FFFFFFFF:\n\tv601 = v9;\nL_FFFFFFFF:\n\tv650 = &v74 @ stack_-98_v1 (Unity.Collections.NativeArray`1<T>);\n\tgoto L_01D9;\nL_FFFFFFFF:\n\tv843 = v768;\n\tv581 = v534 == 0;\n\tif (v581) goto L_01F7;\n\tgoto L_015F;\n\tv1066 = *([v1023 @ X8_v67 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\n\tv1066 = v1066 + 0x10;\n\tv1033 = v1057 - 1;\n\tv1031 = v1057 != 1;\nL_FFFFFFFF:\n\tv1057 = v1033;\n\tif (v1031) goto L_0165;\nL_017F:\n\tv1082 = 0x220C5E0(v534, Il2CppClass<System.Collections.Generic.IEnumerator`1<T>>, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0185;\nL_0181:\n\t;\n\tv1078 = *([v1066 @ X10_v25]) << 4;\n\tv1079 = v1023 + v1078;\n\tv1082 = v1079 + 0x138;\nL_01A1:\n\tv578 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv806 = &v534 @ stack_-88_v10 (System.Collections.IEnumerator);\nL_FFFFFFFF:\n\tv187 = 0;\n\tgoto L_020B;\nL_01A4:\n\tv840 = &v534 @ stack_-88_v10 (System.Collections.IEnumerator);\n\tv810 = *([v840 @ X8_v63]);\n\tv838 = *([v840 @ X8_v63]) == 0;\nL_FFFFFFFF:\n\tv806 = &v534 @ stack_-88_v10 (System.Collections.IEnumerator);\nL_FFFFFFFF:\n\tv187 = 0;\nL_FFFFFFFF:\n\tv844 = 0;\nL_FFFFFFFF:\n\tv376 = &v534 @ stack_-88_v10 (System.Collections.IEnumerator);\nL_FFFFFFFF:\n\tv187 = 0;\nL_FFFFFFFF:\n\tv430 = 0;\nL_FFFFFFFF:\n\tv442 = 0;\n\tif (v838) goto L_01D5;\nL_01AE:\n\tgoto L_01D4;\nL_FFFFFFFF:\n\tv806 = v376;\nL_FFFFFFFF:\n\tv650 = &v70 @ stack_-80_v1 (Unity.Collections.NativeArray`1<T>);\n\treturn *([v650 @ X8_v8]);\nL_01F7:\n\tv579 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv806 = &v534 @ stack_-88_v10 (System.Collections.IEnumerator);\nL_FFFFFFFF:\n\tv187 = 0;\nL_FFFFFFFF:\n\tv361 = 0;\n\tgoto L_020B;\nL_01FA:\n\tv85 = 0xB28B000 + 0x600;\n\tv95 = new v85();\n\tv101 = 0xB310000 + 0x4E0;\n\tSystem.ArgumentNullException::.ctor(v95, v101);\n\tthrow v95;\nL_0208:\n\tv253 = 0x8BF5CF0(clobbered_X0, *([v650 @ X8_v8+8]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_020A:\n\tv444 = new System.OutOfMemoryException();\nL_020B:\n\t// 523 Interrupt\nL_FFFFFFFF:\n\tv430 = v361;\nL_021D:\n\tv656 = v430 != 1;\n\tif (v656) goto L_022B;\n\tv717 = 0x8BF5BC4(v673, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv844 = *([v717 @ X0_v12]);\n\tv743 = 0x8BF5BF4(v717, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv810 = *([v806 @ stack_-A0_v7]);\n\tv775 = *([v806 @ stack_-A0_v7]) == 0;\n\tv776 = ~v775;\nL_FFFFFFFF:\n\tv187 = *([v717 @ X0_v12]);\n\tif (v776) goto L_01AE;\nL_FFFFFFFF:\n\tv376 = v806;\nL_FFFFFFFF:\n\tv187 = *([v717 @ X0_v12]);\nL_FFFFFFFF:\n\tv442 = *([v717 @ X0_v12]);\n\tgoto L_01D5;\nL_022B:\n\tv719 = 0x3175484(&v187 @ stack_-A8 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0212;\nL_0025:\n\tv59 = Il2CppClass<T>;\n\tv63 = *([v59 @ X9_v1 (Il2CppClass<T>)+FC]) + 0xF;\n\tv64 = v63 & 0x1FFFFFFF0;\n\t// 42 StackAlloc v65 @ X20_v1 (System.Byte*), v64 @ X10_v2 (System.Int32)\n\t// 45 StackAlloc v68 @ X22_v1 (System.Byte*), v64 @ X10_v2 (System.Int32)\n\tv70 = 0;\n\tv71 = 0;\n\tv72 = 0;\n\tv74 = 0;\n\tv75 = source == 0;\n\tif (v75) goto L_01FA;\nL_0041:\n\tv94 = 0x21C11D0(source, Il2CppClass<System.Collections.Generic.ICollection`1<T>>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv98 = v94 == 0;\n\tif (v98) goto L_0078;\nL_0053:\n\tgoto L_00D8;\nL_00D8:\n\tv469 = System.Collections.Generic.ICollection`1<T>::get_Count(v94);\n\tv479 = Unity.Collections.NativeArray`1<T>::.ctor(&v70 @ stack_-80_v1 (Unity.Collections.NativeArray`1<T>), v469, allocator, 1);\n\tgoto L_00F1;\nL_020C:\n\tv673 = new System.NullReferenceException();\n\tgoto L_021D;\nL_00A8:\n\tv619 = Il2CppMethodInfo;\n\tv1084 = &v187 @ stack_-A8 (System.Int32);\n\tv623 = v65;\n\t*([v619 @ X1_v21 (Il2CppMethodInfo)+10])(v628, *([v619 @ X1_v21 (Il2CppMethodInfo)]), Il2CppMethodInfo, v129, &v1084 @ stack_-68_v14 (System.Byte*), v65, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv630 = Il2CppMethodInfo;\n\tv1084 = &v187 @ stack_-A8 (System.Int32);\n\tv492 = v65;\n\t*([v630 @ X1_v22 (Il2CppMethodInfo)+10])(v633, *([v630 @ X1_v22 (Il2CppMethodInfo)]), Il2CppMethodInfo, &v74 @ stack_-98_v1 (Unity.Collections.NativeArray`1<T>), &v1084 @ stack_-68_v14 (System.Byte*), v65, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv526 = System.Collections.Generic.List`1<T>::get_Count(v129);\n\tv500 = v601 + 1;\n\tv504 = v500 < v526;\nL_FFFFFFFF:\n\tv187 = v601;\nL_FFFFFFFF:\n\tv601 = v500;\n\tif (v504) goto L_00A8;\nL_01D9:\n\t;\n\tv361 = *([v650 @ X8_v8+8]);\n\tv653 = *([A4731E0]);\n\tv216 = *([v653 @ X9_v7]) != *([v29 @ X8_v2]);\n\tif (v216) goto L_0208;\nL_0115:\n\tv361 = 0;\n\tv768 = System.Collections.Generic.IEnumerable`1<T>::GetEnumerator(v94);\n\tv772 = v768 == 0;\n\tif (v772) goto L_01A1;\nL_014D:\n\tv836 = System.Collections.IEnumerator::MoveNext(v843);\n\tv1010 = v836 == 0;\n\tif (v1010) goto L_01A4;\nL_015F:\n\tv1023 = *([v534 @ stack_-88_v10 (System.Collections.IEnumerator)]);\n\tv1057 = *([v1023 @ X8_v67 (Il2CppClass<System.Collections.IEnumerator>)+12E]);\n\tv1025 = *([v1023 @ X8_v67 (Il2CppClass<System.Collections.IEnumerator>)+12E]) == 0;\n\tif (v1025) goto L_017F;\nL_0165:\n\t;\n\tv1071 = *([v1066 @ X10_v25-8]) == Il2CppClass<System.Collections.Generic.IEnumerator`1<T>>;\n\tif (v1071) goto L_0181;\nL_0185:\n\tv1084 = v65;\n\tv1085 = *([v1082 @ X0_v77+8]);\n\t*([v1085 @ X1_v37+10])(v1091, *([v1085 @ X1_v37+8]), v1085, v534, &v1084 @ stack_-68_v14 (System.Byte*), v65, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv1095 = 0x8BF6A1C(v68, v65, *([v59 @ X9_v1 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv800 = Il2CppMethodInfo;\n\tv1084 = &v198 @ stack_-6C;\n\tv781 = v68;\n\t*([v800 @ X1_v39 (Il2CppMethodInfo)+10])(v802, *([v800 @ X1_v39 (Il2CppMethodInfo)]), Il2CppMethodInfo, &v70 @ stack_-80_v1 (Unity.Collections.NativeArray`1<T>), &v1084 @ stack_-68_v14 (System.Byte*), v68, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv1098 = v534 == 0;\n\tv803 = ~v1098;\nL_FFFFFFFF:\n\tv361 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv843 = v534;\n\tif (v803) goto L_0127;\nL_0127:\n\tgoto L_014D;\nL_01D5:\n\tv892 = v442 == 0;\n\tv434 = ~v892;\nL_FFFFFFFF:\n\tv806 = v376;\nL_FFFFFFFF:\n\tv361 = v430;\n\tif (v434) goto L_020A;\nL_01D4:\n\tSystem.IDisposable::Dispose(v810);\nL_FFFFFFFF:\n\tv376 = v806;\nL_FFFFFFFF:\n\tv430 = 0;\nL_FFFFFFFF:\n\tv442 = v844;\nL_0212:\n\tv673 = 0x8BF0368(v673, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1\n// ... truncated")]
		public unsafe static NativeArray<T> ToNativeArray<T>(this IEnumerable<T> source, Allocator allocator) where T : struct
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ListExtension::ToNativeArray");
			return default;
		}
	}
}
