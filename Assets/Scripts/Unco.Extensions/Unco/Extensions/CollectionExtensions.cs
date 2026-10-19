using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.Extensions
{
	[Token(Token = "0x2000007")]
	public static class CollectionExtensions
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000008")]
		private sealed class _003C_003Ec__11<T>
		{
			[Token(Token = "0x4000009")]
			public static readonly _003C_003Ec__11<T> _003C_003E9;

			[Token(Token = "0x400000A")]
			public static Func<T, int, _003C_003Ef__AnonymousType0<int, T>> _003C_003E9__11_0;

			[Token(Token = "0x400000B")]
			public static Func<_003C_003Ef__AnonymousType0<int, T>, T> _003C_003E9__11_3;

			[Token(Token = "0x400000C")]
			public static Func<IGrouping<int, _003C_003Ef__AnonymousType0<int, T>>, List<T>> _003C_003E9__11_2;

			[Token(Token = "0x600001D")]
			[Address(RVA = "0x4FDBDD4", Offset = "0x4FDBDD4", Length = "0x1A0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1>;\n\tv19 = *([v16 @ X0_v1 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1>)+135]) & 1;\n\tv20 = v19 == 0;\n\tif (v20) goto L_002B;\n\tv22 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>;\n\tv25 = *([v22 @ X0_v42 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>)+135]) & 1;\n\tv26 = v25 == 0;\n\tv47 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>;\n\tv52 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>;\n\tif (v26) goto L_0034;\nL_0016:\n\tv49 = new v47();\n\tv59 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1>;\n\tv77 = *([v59 @ X0_v41 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1>)+135]);\n\tv62 = *([v59 @ X0_v41 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1>)+135]) & 1;\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tv100 = v49;\n\tv74 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1>;\n\tv107 = v49;\n\tv103 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1>;\n\tif (v64) goto L_003E;\nL_001F:\n\tv76 = 0x220C238(v74, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv90 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1>;\n\tv93 = *([v76 @ X0_v37+C0]);\n\tv94 = *([v93 @ X8_v43+8]);\n\tv98 = *([v94 @ X8_v44]);\n\tv96 = *([v90 @ X0_v38 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1>)+135]) & 1;\n\tv97 = v96 == 0;\n\tv103 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1>;\n\tif (v97) goto L_0044;\n\tv105 = *([v94 @ X8_v44]);\n\tv107 = v100;\n\tgoto L_0048;\nL_002B:\n\tv27 = 0x220C238(Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1>, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv54 = *([v27 @ X0_v34+C0]);\n\tv47 = *([v54 @ X8_v38]);\n\tv56 = *([v47 @ X0_v39 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>)+135]) & 1;\n\tv57 = v56 == 0;\n\tv44 = ~v57;\n\tv52 = v47;\n\tif (v44) goto L_0016;\nL_0034:\n\tv53 = 0x220C238(v52, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv65 = new v53();\n\tv75 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1>;\n\tv77 = *([v75 @ X0_v33 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1>)+135]);\n\tv88 = *([v75 @ X0_v33 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1>)+135]) & 1;\n\tv71 = v88 == 0;\n\tv100 = v65;\n\tv74 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1>;\n\tv107 = v65;\n\tv103 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1>;\n\tif (v71) goto L_001F;\nL_003E:\n\tv83 = Il2CppMethodInfo;\n\tv98 = *([v83 @ X8_v35 (Il2CppMethodInfo)]);\n\tv85 = v77 & 1;\n\tv86 = v85 == 0;\n\tv87 = ~v86;\n\tv100 = v107;\n\tv105 = *([v83 @ X8_v35 (Il2CppMethodInfo)]);\n\tif (v87) goto L_0048;\nL_0044:\n\tv104 = 0x220C238(v103, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv105 = v98;\n\tv107 = v100;\nL_0048:\n\tv105(v114, v107, Il2CppMethodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv115 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1>;\n\tv118 = *([v115 @ X0_v5 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1>)+135]) & 1;\n\tv119 = v118 == 0;\n\tif (v119) goto L_0070;\n\tv121 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>;\n\tv124 = *([v121 @ X0_v25 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>)+135]) & 1;\n\tv125 = v124 == 0;\n\tv141 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>;\n\tif (v125) goto L_0079;\nL_0057:\n\tv133.<>9 = v107;\n\tv134 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1>;\n\tv137 = *([v134 @ X0_v24 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1>)+135]) & 1;\n\tv138 = v137 == 0;\n\tv161 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1>;\n\tif (v138) goto L_0083;\nL_005F:\n\tv154 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>;\n\tv157 = *([v154 @ X0_v22 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>)+135]) & 1;\n\tv158 = v157 == 0;\n\tv184 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>;\n\tif (v158) goto L_008C;\nL_006F:\n\treturn;\nL_0070:\n\tv126 = 0x220C238(Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1>, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv143 = *([v126 @ X0_v16+C0]);\n\tv141 = *([v143 @ X8_v16+10]);\n\tv145 = *([v141 @ X0_v13 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>)+135]) & 1;\n\tv146 = v145 == 0;\n\tv128 = ~v146;\n\tif (v128) goto L_0057;\nL_0079:\n\tv142 = 0x220C238(v141, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv163 = *([v142 @ X0_v14+B8]);\n\t*([v163 @ X8_v13]) = v107;\n\tv152 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1>;\n\tv165 = *([v152 @ X0_v15 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1>)+135]) & 1;\n\tv166 = v165 == 0;\n\tv148 = ~v166;\n\tv161 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1>;\n\tif (v148) goto L_005F;\nL_0083:\n\tv162 = 0x220C238(v161, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv186 = *([v162 @ X0_v11+C0]);\n\tv184 = *([v186 @ X8_v9+10]);\n\tv188 = *([v184 @ X0_v6 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>)+135]) & 1;\n\tv189 = v188 == 0;\n\tv168 = ~v189;\n\tif (v168) goto L_006F;\nL_008C:\n\tv185 = 0x220C238(v184, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\n")]
			static _003C_003Ec__11()
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
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v16 @ X0_v1 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1>)+135]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X0_v42 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>)+135]");
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
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X0_v39 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>)+135]");
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
				_003C_003Ec__11<T> _003C_003Ec__12 = null;
				nint num7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X0_v33 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1>)+135]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X0_v33 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1>)+135]");
				int num8 = (int)((nint)0 & (nint)1);
				bool flag4 = num8 == 0;
				_003C_003Ec__11<T> _003C_003Ec__13 = _003C_003Ec__12;
				nint num9 = 0;
				_003C_003Ec__11<T> _003C_003Ec__14 = _003C_003Ec__12;
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
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ X0_v6 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>)+135]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					return;
				}
				goto IL_0537;
				IL_03ac:
				nint num12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ X0_v22 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>)+135]");
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
				_003C_003Ec__11<T> _003C_003Ec__15 = null;
				nint num14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X0_v41 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1>)+135]");
				obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ X0_v41 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1>)+135]");
				int num15 = (int)((nint)0 & (nint)1);
				bool flag6 = num15 == 0;
				bool flag7 = !flag6;
				_003C_003Ec__13 = _003C_003Ec__15;
				num9 = 0;
				_003C_003Ec__14 = _003C_003Ec__15;
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
				_003C_003Ec__13 = _003C_003Ec__14;
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
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ X0_v38 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1>)+135]");
				int num19 = (int)((nint)0 & (nint)1);
				bool flag10 = num19 == 0;
				num10 = 0;
				if (flag10)
				{
					goto IL_02be;
				}
				obj5 = obj7;
				_003C_003Ec__14 = _003C_003Ec__13;
				goto IL_02e2;
				IL_02be:
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				obj5 = obj4;
				_003C_003Ec__14 = _003C_003Ec__13;
				goto IL_02e2;
				IL_0364:
				_003C_003E9 = _003C_003Ec__14;
				nint num20 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ X0_v24 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1>)+135]");
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
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ X0_v5 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1>)+135]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					nint num24 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ X0_v25 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>)+135]");
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
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ X0_v13 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>)+135]");
					if ((uint)((nuint)0u & (nuint)1u) != 0)
					{
						goto IL_0364;
					}
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X0_v14+B8]");
				object obj9 = 0;
				obj9 = _003C_003Ec__14;
				nint num27 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ X0_v15 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1>)+135]");
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

			[Token(Token = "0x600001E")]
			[Address(RVA = "0x4FDBF74", Offset = "0x4FDBF74", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec__11()
			{
			}

			internal unsafe _003C_003Ef__AnonymousType0<int, T> _003CChunkBy_003Eb__11_0(T x, int i)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("CollectionExtensions._003C_003Ec__11::_003CChunkBy_003Eb__11_0");
				return default;
			}

			internal List<T> _003CChunkBy_003Eb__11_2(IGrouping<int, _003C_003Ef__AnonymousType0<int, T>> x)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("CollectionExtensions._003C_003Ec__11::_003CChunkBy_003Eb__11_2");
				return default;
			}

			internal unsafe T _003CChunkBy_003Eb__11_3(_003C_003Ef__AnonymousType0<int, T> v)
			{
				//IL_0010: Expected O, but got I
				//IL_002c: Expected O, but got I
				//IL_003f: Expected I4, but got I8
				//IL_0086: Expected O, but got I
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
				object obj = 0;
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X9_v1 (Il2CppClass<T>)+FC]");
				object obj2 = (nint)0 + (nint)15;
				int num2 = (int)((nint)obj2 & 0x1FFFFFFF0L);
				byte* ptr = stackalloc byte[(int)(uint)num2];
				nint num3 = 0;
				byte* ptr2 = ptr;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v34 @ X1_v2 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A1C");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
				object obj3 = 0;
				T result = default(T);
				if (obj3 == obj)
				{
					return result;
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5CF0");
				T result2 = default(T);
				return result2;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200000A")]
		private sealed class _003CBatch_003Ed__8<T> : IEnumerable<IEnumerable<T>>, IEnumerable, IEnumerator<IEnumerable<T>>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400000E")]
			[FieldOffset(Offset = "0x0")]
			private int _003C_003E1__state;

			[Token(Token = "0x400000F")]
			[FieldOffset(Offset = "0x0")]
			private IEnumerable<T> _003C_003E2__current;

			[Token(Token = "0x4000010")]
			[FieldOffset(Offset = "0x0")]
			private int _003C_003El__initialThreadId;

			[Token(Token = "0x4000011")]
			[FieldOffset(Offset = "0x0")]
			private IEnumerable<T> source;

			[Token(Token = "0x4000012")]
			[FieldOffset(Offset = "0x0")]
			public IEnumerable<T> _003C_003E3__source;

			[Token(Token = "0x4000013")]
			[FieldOffset(Offset = "0x0")]
			private int batchSize;

			[Token(Token = "0x4000014")]
			[FieldOffset(Offset = "0x0")]
			public int _003C_003E3__batchSize;

			[Token(Token = "0x4000015")]
			[FieldOffset(Offset = "0x0")]
			private IEnumerator<T> _003Cenumerator_003E5__2;

			[Token(Token = "0x17000003")]
			IEnumerable<T> IEnumerator<IEnumerable<T>>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000028")]
				[Address(RVA = "0x6FC3068", Offset = "0x6FC3068", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000004")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600002A")]
				[Address(RVA = "0x6FC30A8", Offset = "0x6FC30A8", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000024")]
			[Address(RVA = "0x6FC2CC8", Offset = "0x6FC2CC8", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\tv16 = System.Environment::get_CurrentManagedThreadId();\n\tthis.<>l__initialThreadId = v16;\n\treturn;\n")]
			public _003CBatch_003Ed__8(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000025")]
			[Address(RVA = "0x6FC2D00", Offset = "0x6FC2D00", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this.<>1__state - 1;\n\tv6 = v4 == 0;\n\tv11 = ~v6;\n\tv12 = ~v11;\n\tif (v12) goto L_FFFFFFFF;\n\tv15 = this.<>1__state - -3;\n\tv30 = v15 == 0;\n\tgoto L_001C;\nL_FFFFFFFF:\n\tv30 = 1;\n\tthis = Unco.Extensions.CollectionExtensions+<Batch>d__8`1<T>::<>m__Finally1(this);\n\treturn;\nL_0023:\n\treturn;\nL_001C:\n\tv34 = ~v30;\n\tif (v34) goto L_0023;\n")]
			void IDisposable.Dispose()
			{
				bool flag;
				if (_003C_003E1__state - 1 != 0)
				{
					int num = _003C_003E1__state - -3;
					flag = num == 0;
				}
				else
				{
					flag = true;
				}
				if (flag)
				{
					_003C_003Em__Finally1();
				}
			}

			[Token(Token = "0x6000026")]
			[Address(RVA = "0x6FC2D28", Offset = "0x6FC2D28", Length = "0x27C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv62 = this.<>1__state == 0;\n\tv63 = ~v62;\n\tif (v63) goto L_00C9;\n\tthis.<>1__state = -1;\n\tgoto L_003E;\n\tgoto L_009C;\n\tv384 = *([v46 @ stack_-40_v2+20]);\n\tv385 = *([v384 @ X9_v5+C0]);\n\tv203 = *([v385 @ X9_v6+28]);\n\tv386 = v50.batchSize - 1;\n\t*([v203 @ X2_v3])(v387, v50.<enumerator>5__2, v386, *([v385 @ X9_v6+28]), v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv50.<>2__current = v387;\n\tv50.<>1__state = 1;\n\treturn 1;\nL_00BC:\n\tv393 = *([v46 @ stack_-40_v2+20]);\n\tv394 = *([v393 @ X8_v14+C0]);\n\tv158 = *([v394 @ X8_v15+8]);\n\t*([v158 @ X1_v4])(v161, v50, *([v394 @ X8_v15+8]), 0, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_00CA:\n\tv184 = new System.NullReferenceException();\n\tgoto L_00CD;\nL_00CD:\n\t// 205 Interrupt\n\tgoto L_00DD;\nL_00DD:\n\tv126 = v159 != 1;\n\tv196 = 0;\n\tv232 = v282;\n\tif (v126) goto L_00F3;\n\tv371 = 0x8BF5BC4(v282, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv162 = 0x8BF5BF4(v371, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv165 = *([v371 @ X0_v28]) == 0;\n\tif (v165) goto L_00C9;\n\tv372 = &v50 @ stack_-38_v2 (Unco.Extensions.CollectionExtensions+<Batch>d__8`1<T>);\n\tv414 = Unco.Extensions.CollectionExtensions+<Batch>d__8`1::MoveNext(*([v372 @ X9_v15]));\n\tv375 = new System.OutOfMemoryException();\n\tv196 = *([v371 @ X0_v28]);\n\tv232 = v375;\n\treturn returnVal3;\nL_0021:\n\tv57 = this.<>1__state == 1;\n\tv105 = this;\n\tif (v57) goto L_006C;\nL_00C9:\n\treturn 0;\nL_003E:\n\tgoto L_0064;\nL_0064:\n\tv404 = System.Collections.Generic.IEnumerable`1<T>::GetEnumerator(this.source);\n\tv50.<enumerator>5__2 = v404;\n\tv105 = v50;\nL_009C:\n\tv347 = System.Collections.IEnumerator::MoveNext(v105.<enumerator>5__2);\n\tv164 = v347 == 0;\n\tif (v164) goto L_00BC;\nL_00F3:\n\tv379 = 0x31C8944(&v196 @ stack_-58_v3 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv408 = 0x8BF0368(v232, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal3 = 0xA1B8(v408, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_006C:\n\tv105.<>1__state = -3;\n\tv109 = v105.<enumerator>5__2 == 0;\n\tif (v109) goto L_00CA;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("CollectionExtensions._003CBatch_003Ed__8::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[Token(Token = "0x6000027")]
			[Address(RVA = "0x6FC2FA4", Offset = "0x6FC2FA4", Length = "0xC4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv44 = *([v39 @ X19_v2 (System.Collections.Generic.IEnumerator`1<T>)]);\n\tv151 = *([v44 @ X8_v6 (Il2CppClass<System.Collections.Generic.IEnumerator`1<T>>)+12E]);\n\tv46 = *([v44 @ X8_v6 (Il2CppClass<System.Collections.Generic.IEnumerator`1<T>>)+12E]) == 0;\n\tif (v46) goto L_0043;\n\tv120 = *([v44 @ X8_v6 (Il2CppClass<System.Collections.Generic.IEnumerator`1<T>>)+B0]) + 8;\n\tv120 = v120 + 0x10;\n\tv87 = v151 - 1;\n\tv57 = v151 != 1;\n\tv151 = v87;\n\tif (v57) goto L_0025;\nL_0043:\n\tSystem.IDisposable::Dispose(this.<enumerator>5__2);\nL_0043:\n\treturn;\nL_0049:\n\treturn;\nL_004B:\n\tv94 = *([v120 @ X10_v4]) << 4;\n\tv132 = v44 + v94;\n\tv154 = v132 + 0x138;\n\t// 86 IndirectJump [v154 @ X0_v5], this.<enumerator>5__2 (System.Collections.Generic.IEnumerator`1<T>), this.<enumerator>5__2 (System.Collections.Generic.IEnumerator`1<T>), [v154 @ X0_v5+8], [v154 @ X0_v5], v22 @ X3, v23 @ X4, v24 @ X5, v25 @ X6, v26 @ X7, v27 @ V0, v28 @ V1, v29 @ V2, v30 @ V3, v31 @ V4, v32 @ V5, v33 @ V6, v34 @ V7\nL_0013:\n\tthis.<>1__state = -1;\n\tv39 = this.<enumerator>5__2;\n\tv40 = this.<enumerator>5__2 == 0;\n\tif (v40) goto L_0049;\nL_0025:\n\tv112 = *([v120 @ X10_v4-8]) == System.IDisposable;\n\tif (v112) goto L_004B;\n")]
			private void _003C_003Em__Finally1()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("CollectionExtensions._003CBatch_003Ed__8::_003C_003Em__Finally1");
			}

			[DebuggerHidden]
			[Token(Token = "0x6000029")]
			[Address(RVA = "0x6FC3070", Offset = "0x6FC3070", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = 0xB292000 + 0x4A0;\n\tv28 = new v12();\n\tSystem.NotSupportedException::.ctor(v28);\n\tthrow v28;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}

			[DebuggerHidden]
			[Token(Token = "0x600002B")]
			[Address(RVA = "0x6FC30B0", Offset = "0x6FC30B0", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv29 = this.<>1__state != -2;\n\tif (v29) goto L_0030;\n\tv32 = System.Environment::get_CurrentManagedThreadId();\n\tv36 = this.<>l__initialThreadId != v32;\n\tif (v36) goto L_0030;\n\tthis.<>1__state = 0;\n\tv91 = this;\n\tgoto L_003F;\nL_0030:\n\tgoto L_0032;\nL_0032:\n\tv78 = new Il2CppClass<Unco.Extensions.CollectionExtensions+<Batch>d__8`1<T>>();\n\tv86 = Unco.Extensions.CollectionExtensions+<Batch>d__8`1<T>::.ctor(v78, 0);\n\tv91 = v78;\nL_003F:\n\tv91.source = this.<>3__source;\n\tv91.batchSize = this.<>3__batchSize;\n\treturn v91;\n")]
			IEnumerator<IEnumerable<T>> IEnumerable<IEnumerable<T>>.GetEnumerator()
			{
				_003CBatch_003Ed__8<T> _003CBatch_003Ed__9;
				if (_003C_003E1__state == -2)
				{
					int currentManagedThreadId = Environment.CurrentManagedThreadId;
					if (_003C_003El__initialThreadId == currentManagedThreadId)
					{
						_003C_003E1__state = 0;
						_003CBatch_003Ed__9 = this;
						goto IL_0082;
					}
				}
				_003CBatch_003Ed__8<T> _003CBatch_003Ed__10 = new _003CBatch_003Ed__8<T>(0);
				_003CBatch_003Ed__9 = _003CBatch_003Ed__10;
				goto IL_0082;
				IL_0082:
				_003CBatch_003Ed__9.source = _003C_003E3__source;
				_003CBatch_003Ed__9.batchSize = _003C_003E3__batchSize;
				return _003CBatch_003Ed__9;
			}

			[DebuggerHidden]
			[Token(Token = "0x600002C")]
			[Address(RVA = "0x6FC3164", Offset = "0x6FC3164", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis = Unco.Extensions.CollectionExtensions+<Batch>d__8`1<T>::System.Collections.Generic.IEnumerable<System.Collections.Generic.IEnumerable<T>>.GetEnumerator(this);\n\treturn this;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				((IEnumerable<IEnumerable<T>>)this).GetEnumerator();
				return this;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200000B")]
		private sealed class _003CEnumerate_003Ed__1<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000016")]
			[FieldOffset(Offset = "0x0")]
			private int _003C_003E1__state;

			[Token(Token = "0x4000017")]
			[FieldOffset(Offset = "0x0")]
			private T _003C_003E2__current;

			[Token(Token = "0x4000018")]
			[FieldOffset(Offset = "0x0")]
			private int _003C_003El__initialThreadId;

			[Token(Token = "0x4000019")]
			[FieldOffset(Offset = "0x0")]
			private T data;

			[Token(Token = "0x400001A")]
			[FieldOffset(Offset = "0x0")]
			public T _003C_003E3__data;

			[Token(Token = "0x17000005")]
			T IEnumerator<T>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000030")]
				[Address(RVA = "0x713DF24", Offset = "0x713DF24", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000006")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000032")]
				[Address(RVA = "0x713DF64", Offset = "0x713DF64", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x600002D")]
			[Address(RVA = "0x713DE8C", Offset = "0x713DE8C", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\tv16 = System.Environment::get_CurrentManagedThreadId();\n\tthis.<>l__initialThreadId = v16;\n\treturn;\n")]
			public _003CEnumerate_003Ed__1(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x600002E")]
			[Address(RVA = "0x713DEC4", Offset = "0x713DEC4", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x600002F")]
			[Address(RVA = "0x713DEC8", Offset = "0x713DEC8", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = this.<>1__state == 0;\n\tif (v13) goto L_001A;\n\tv23 = this.<>1__state != 1;\n\tif (v23) goto L_0024;\n\tv50 = -1;\n\tgoto L_001F;\nL_001A:\n\tthis.<>2__current = this.data;\n\tthis.<>1__state = -1;\n\tv50 = 1;\nL_0024:\n\tv74 = this.<>1__state == 0;\n\treturn v74;\nL_001F:\n\tthis.<>1__state = v50;\n")]
			private bool MoveNext()
			{
				int num;
				if (_003C_003E1__state != 0)
				{
					if (_003C_003E1__state != 1)
					{
						goto IL_0074;
					}
					num = -1;
				}
				else
				{
					_003C_003E2__current = data;
					_003C_003E1__state = -1;
					num = 1;
				}
				_003C_003E1__state = num;
				goto IL_0074;
				IL_0074:
				return _003C_003E1__state == 0;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000031")]
			[Address(RVA = "0x713DF2C", Offset = "0x713DF2C", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = 0xB292000 + 0x4A0;\n\tv28 = new v12();\n\tSystem.NotSupportedException::.ctor(v28);\n\tthrow v28;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000033")]
			[Address(RVA = "0x713DF6C", Offset = "0x713DF6C", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv29 = this.<>1__state != -2;\n\tif (v29) goto L_0030;\n\tv32 = System.Environment::get_CurrentManagedThreadId();\n\tv36 = this.<>l__initialThreadId != v32;\n\tif (v36) goto L_0030;\n\tthis.<>1__state = 0;\n\tv97 = this;\n\tgoto L_003D;\nL_0030:\n\tgoto L_0032;\nL_0032:\n\tv78 = new Il2CppClass<Unco.Extensions.CollectionExtensions+<Enumerate>d__1`1<T>>();\n\tSystem.Object::.ctor(v78);\n\t*([v78 @ X0_v9 (System.Object)+10]) = 0;\n\tv84 = System.Environment::get_CurrentManagedThreadId();\n\t*([v78 @ X0_v9 (System.Object)+20]) = v84;\n\tv97 = v78;\nL_003D:\n\t*([v97 @ X20_v2 (System.Collections.Generic.IEnumerator`1<T>)+28]) = this.<>3__data;\n\treturn v97;\n")]
			IEnumerator<T> IEnumerable<T>.GetEnumerator()
			{
				//IL_007e: Expected O, but got I
				IEnumerator<T> result;
				if (_003C_003E1__state == -2)
				{
					int currentManagedThreadId = Environment.CurrentManagedThreadId;
					if (_003C_003El__initialThreadId == currentManagedThreadId)
					{
						_003C_003E1__state = 0;
						result = this;
						goto IL_00a5;
					}
				}
				object obj = (nint)(IntPtr)FormatterServices.GetUninitializedObject(typeof(IntPtr));
				_ = 0;
				int currentManagedThreadId2 = Environment.CurrentManagedThreadId;
				result = (IEnumerator<T>)obj;
				goto IL_00a5;
				IL_00a5:
				_ = _003C_003E3__data;
				return result;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000034")]
			[Address(RVA = "0x713E010", Offset = "0x713E010", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = Unco.Extensions.CollectionExtensions+<Enumerate>d__1`1<T>::System.Collections.Generic.IEnumerable<T>.GetEnumerator(this);\n\treturn returnVal1;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<T>)this).GetEnumerator();
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200000C")]
		private sealed class _003CGetSelfAndChild_003Ed__10<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable where T : Component
		{
			[Token(Token = "0x400001B")]
			[FieldOffset(Offset = "0x0")]
			private int _003C_003E1__state;

			[Token(Token = "0x400001C")]
			[FieldOffset(Offset = "0x0")]
			private T _003C_003E2__current;

			[Token(Token = "0x400001D")]
			[FieldOffset(Offset = "0x0")]
			private int _003C_003El__initialThreadId;

			[Token(Token = "0x400001E")]
			[FieldOffset(Offset = "0x0")]
			private GameObject c;

			[Token(Token = "0x400001F")]
			[FieldOffset(Offset = "0x0")]
			public GameObject _003C_003E3__c;

			[Token(Token = "0x4000020")]
			[FieldOffset(Offset = "0x0")]
			private T[] _003C_003E7__wrap1;

			[Token(Token = "0x4000021")]
			[FieldOffset(Offset = "0x0")]
			private int _003C_003E7__wrap2;

			[Token(Token = "0x17000007")]
			T IEnumerator<T>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000038")]
				[Address(RVA = "0x7367CF0", Offset = "0x7367CF0", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[Token(Token = "0x17000008")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600003A")]
				[Address(RVA = "0x7367D30", Offset = "0x7367D30", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<>2__current;\n")]
				get
				{
					return _003C_003E2__current;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000035")]
			[Address(RVA = "0x7367B60", Offset = "0x7367B60", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.<>1__state = <>1__state;\n\tv16 = System.Environment::get_CurrentManagedThreadId();\n\tthis.<>l__initialThreadId = v16;\n\treturn;\n")]
			public _003CGetSelfAndChild_003Ed__10(int _003C_003E1__state)
			{
				this._003C_003E1__state = _003C_003E1__state;
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				_003C_003El__initialThreadId = currentManagedThreadId;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000036")]
			[Address(RVA = "0x7367B98", Offset = "0x7367B98", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000037")]
			[Address(RVA = "0x7367B9C", Offset = "0x7367B9C", Length = "0x154")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = this.<>1__state == 2;\n\tif (v18) goto L_0078;\n\tv29 = this.<>1__state == 1;\n\tif (v29) goto L_003B;\n\tv42 = this.<>1__state == 0;\n\tv43 = ~v42;\n\tif (v43) goto L_0076;\n\tthis.<>1__state = -1;\n\tv149 = UnityEngine.GameObject::TryGetComponent(this.c, &v154 @ stack_-28_v7 (T));\n\tv152 = ~v149;\n\tif (v152) goto L_0042;\n\tthis.<>2__current = v154;\n\tthis.<>1__state = 1;\n\treturn 1;\nL_003B:\n\tthis.<>1__state = -1;\nL_0042:\n\tv215 = UnityEngine.GameObject::GetComponentsInChildren(this.c);\n\tthis.<>7__wrap1 = v215;\n\tthis.<>7__wrap2 = 0;\n\tv95 = this + 0x38;\n\tv92 = this.<>7__wrap1;\n\tv106 = 0;\nL_005A:\n\tv118 = v106 >= v92.Length;\n\tif (v118) goto L_006D;\n\tthis.<>2__current = v92[v106 @ X8_v8 (System.Int32)];\n\tthis.<>1__state = 2;\n\treturn 1;\nL_006D:\n\t*([v95 @ X0_v9]) = 0;\nL_0076:\n\treturn 0;\nL_0078:\n\tthis.<>1__state = -1;\n\tv106 = this.<>7__wrap2 + 1;\n\tthis.<>7__wrap2 = v106;\n\tv95 = this + 0x38;\n\tv92 = this.<>7__wrap1;\n\tv40 = this.<>7__wrap1 == 0;\n\tv41 = ~v40;\n\tif (v41) goto L_005A;\n\tv78 = new System.NullReferenceException();\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n")]
			private bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("CollectionExtensions._003CGetSelfAndChild_003Ed__10::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000039")]
			[Address(RVA = "0x7367CF8", Offset = "0x7367CF8", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = 0xB292000 + 0x4A0;\n\tv28 = new v12();\n\tSystem.NotSupportedException::.ctor(v28);\n\tthrow v28;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}

			[DebuggerHidden]
			[Token(Token = "0x600003B")]
			[Address(RVA = "0x7367D38", Offset = "0x7367D38", Length = "0xA4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv29 = this.<>1__state != -2;\n\tif (v29) goto L_0030;\n\tv32 = System.Environment::get_CurrentManagedThreadId();\n\tv36 = this.<>l__initialThreadId != v32;\n\tif (v36) goto L_0030;\n\tthis.<>1__state = 0;\n\tv97 = this;\n\tgoto L_003D;\nL_0030:\n\tgoto L_0032;\nL_0032:\n\tv78 = new Il2CppClass<Unco.Extensions.CollectionExtensions+<GetSelfAndChild>d__10`1<T>>();\n\tSystem.Object::.ctor(v78);\n\t*([v78 @ X0_v9 (System.Object)+10]) = 0;\n\tv84 = System.Environment::get_CurrentManagedThreadId();\n\t*([v78 @ X0_v9 (System.Object)+20]) = v84;\n\tv97 = v78;\nL_003D:\n\t*([v97 @ X20_v2 (System.Collections.Generic.IEnumerator`1<T>)+28]) = this.<>3__c;\n\treturn v97;\n")]
			IEnumerator<T> IEnumerable<T>.GetEnumerator()
			{
				//IL_007e: Expected O, but got I
				IEnumerator<T> result;
				if (_003C_003E1__state == -2)
				{
					int currentManagedThreadId = Environment.CurrentManagedThreadId;
					if (_003C_003El__initialThreadId == currentManagedThreadId)
					{
						_003C_003E1__state = 0;
						result = this;
						goto IL_00a5;
					}
				}
				object obj = (nint)(IntPtr)FormatterServices.GetUninitializedObject(typeof(IntPtr));
				_ = 0;
				int currentManagedThreadId2 = Environment.CurrentManagedThreadId;
				result = (IEnumerator<T>)obj;
				goto IL_00a5;
				IL_00a5:
				_ = _003C_003E3__c;
				return result;
			}

			[DebuggerHidden]
			[Token(Token = "0x600003C")]
			[Address(RVA = "0x7367DDC", Offset = "0x7367DDC", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = Unco.Extensions.CollectionExtensions+<GetSelfAndChild>d__10`1<T>::System.Collections.Generic.IEnumerable<T>.GetEnumerator(this);\n\treturn returnVal1;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<T>)this).GetEnumerator();
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200000D")]
		private sealed class _003CTraverse_003Ed__16<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000022")]
			[FieldOffset(Offset = "0x0")]
			private int _003C_003E1__state;

			[Token(Token = "0x4000023")]
			[FieldOffset(Offset = "0x0")]
			private T _003C_003E2__current;

			[Token(Token = "0x4000024")]
			[FieldOffset(Offset = "0x0")]
			private int _003C_003El__initialThreadId;

			[Token(Token = "0x4000025")]
			[FieldOffset(Offset = "0x0")]
			private IEnumerable<T> source;

			[Token(Token = "0x4000026")]
			[FieldOffset(Offset = "0x0")]
			public IEnumerable<T> _003C_003E3__source;

			[Token(Token = "0x4000027")]
			[FieldOffset(Offset = "0x0")]
			private Func<T, IEnumerable<T>> childSelector;

			[Token(Token = "0x4000028")]
			[FieldOffset(Offset = "0x0")]
			public Func<T, IEnumerable<T>> _003C_003E3__childSelector;

			[Token(Token = "0x4000029")]
			[FieldOffset(Offset = "0x0")]
			private IEnumerator<T> _003C_003E7__wrap1;

			[Token(Token = "0x400002A")]
			[FieldOffset(Offset = "0x0")]
			private T _003Citem_003E5__3;

			[Token(Token = "0x400002B")]
			[FieldOffset(Offset = "0x0")]
			private IEnumerator<T> _003C_003E7__wrap3;

			[Token(Token = "0x17000009")]
			T IEnumerator<T>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000042")]
				[Address(RVA = "0x531424C", Offset = "0x531424C", Length = "0x48")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = Il2CppClass<T>;\n\tv17 = Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>;\n\tv19 = *([v17 @ X8_v3 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]) + 0x20;\n\tv20 = 0x21C1054(this, v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\treturnVal1 = 0x8BF6A34(il2cppRetVal, v20, *([v15 @ X9_v1 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal1;\n")]
				get
				{
					//IL_0022: Expected O, but got I
					nint num = 0;
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ X8_v3 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]");
					object obj = (nint)0 + (nint)32;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1054");
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A34");
					T result = default(T);
					return result;
				}
			}

			[Token(Token = "0x1700000A")]
			unsafe object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000044")]
				[Address(RVA = "0x53142CC", Offset = "0x53142CC", Length = "0xB0")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = *([A4731E0]);\n\tv22 = Il2CppClass<T>;\n\tv26 = *([v22 @ X9_v1 (Il2CppClass<T>)+FC]) + 0xF;\n\tv27 = v26 & 0x1FFFFFFF0;\n\t// 21 StackAlloc v28 @ X21_v1 (System.Byte*), v27 @ X10_v2 (System.Int32)\n\tv30 = Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>;\n\tv32 = *([v30 @ X8_v6 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]) + 0x20;\n\tv33 = 0x21C1054(this, v32, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv52 = 0x8BF6A1C(v28, v33, *([v22 @ X9_v1 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t// 35 Box returnVal1 @ X0_v5 (System.Object), typeof(Il2CppClass<T>), v28 @ X21_v1 (System.Byte*)\n\tv60 = *([A4731E0]);\n\tv71 = *([v60 @ X9_v4]) != *([v17 @ X8_v2]);\n\tif (v71) goto L_003C;\n\treturn returnVal1;\nL_003C:\n\treturnVal2 = 0x8BF5CF0(returnVal1, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal2;\n")]
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
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X8_v6 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]");
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
			[Token(Token = "0x600003D")]
			[Address(RVA = "0x5313368", Offset = "0x5313368", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tv23 = Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>;\n\tv24 = *([v23 @ X8_v3 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]);\n\tv27 = 0x815C(*([v23 @ X8_v3 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]), 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv43 = 0x21C1054(this, *([v23 @ X8_v3 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v43 @ X0_v4]) = <>1__state;\n\tv47 = 0x21C0FD4(*([v24 @ X22_v1+8]), v43, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv49 = System.Environment::get_CurrentManagedThreadId();\n\tv53 = Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>;\n\tv54 = *([v53 @ X8_v6 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]);\n\tv55 = *([v53 @ X8_v6 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]) + 0x40;\n\tv57 = 0x815C(v55, 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv58 = *([v53 @ X8_v6 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]) + 0x40;\n\tv60 = 0x21C1054(this, v58, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v60 @ X0_v12]) = v49;\n\tv70 = 0x21C0FD4(*([v54 @ X19_v2+48]), v60, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\n")]
			public _003CTraverse_003Ed__16(int _003C_003E1__state)
			{
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X8_v3 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]");
				object obj = 0;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @815C");
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1054");
				object obj2 = _003C_003E1__state;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C0FD4");
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v6 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v6 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]");
				object obj4 = (nint)0 + (nint)64;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @815C");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v6 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]");
				object obj5 = (nint)0 + (nint)64;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1054");
				object obj6 = currentManagedThreadId;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C0FD4");
			}

			[DebuggerHidden]
			[Token(Token = "0x600003E")]
			[Address(RVA = "0x531341C", Offset = "0x531341C", Length = "0x118")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this;\n\tv15 = methodInfo;\n\tv18 = Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>;\n\tv20 = 0x21C1054(this, *([v18 @ X8_v3 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]), v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv36 = *([v20 @ X0_v1]) + 4;\n\tv37 = v36 < 6;\n\tv38 = ~v37;\n\tv39 = v36 - 6;\n\tv41 = v39 == 0;\n\tv47 = 1 << v36;\n\tv49 = v47 & 0x63;\n\tv50 = ~v38;\n\tv51 = v50 | v41;\n\tv52 = ~v51;\n\tif (v52) goto L_FFFFFFFF;\n\tv70 = v49 == 0;\n\tgoto L_0031;\nL_FFFFFFFF:\n\tv70 = 1;\n\tv81 = *([v20 @ X0_v1]) - 2;\n\tv83 = v81 == 0;\n\tv88 = ~v83;\n\tv89 = ~v88;\n\tif (v89) goto L_FFFFFFFF;\n\tv135 = *([v20 @ X0_v1]) - -4;\n\tv183 = v135 == 0;\n\tgoto L_0052;\nL_FFFFFFFF:\n\tv183 = 1;\n\tv193 = Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>::<>m__Finally2(this);\nL_FFFFFFFF:\n\tv98 = 0;\nL_FFFFFFFF:\n\tv104 = &v14 @ stack_-28_v1 (Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>);\nL_FFFFFFFF:\n\tv204 = &v15 @ stack_-30_v1 (Il2CppMethodInfo);\nL_FFFFFFFF:\n\tv128 = 0;\n\tgoto L_005F;\nL_FFFFFFFF:\n\tv98 = 0;\nL_FFFFFFFF:\n\tv104 = &v14 @ stack_-28_v1 (Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>);\nL_FFFFFFFF:\n\tv204 = &v15 @ stack_-30_v1 (Il2CppMethodInfo);\nL_FFFFFFFF:\n\tv128 = 0;\nL_006E:\n\treturn;\nL_0070:\n\tv213 = new System.OutOfMemoryException();\n\tv153 = v124 != 1;\n\tif (v153) goto L_0087;\n\tv216 = 0x8BF5BC4(v213, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv128 = *([v216 @ X0_v14]);\n\tv202 = 0x8BF5BF4(v216, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv98 = *([v216 @ X0_v14]);\nL_FFFFFFFF:\n\tv104 = &v14 @ stack_-28_v1 (Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>);\nL_FFFFFFFF:\n\tv204 = &v15 @ stack_-30_v1 (Il2CppMethodInfo);\n\tgoto L_005F;\n\treturn;\nL_0031:\n\tif (v70) goto L_006E;\nL_0052:\n\tv187 = ~v183;\n\tif (v187) goto L_FFFFFFFF;\nL_005F:\n\tv207 = *([v204 @ X8_v9]);\n\tv209 = *([v207 @ X8_v10+20]);\n\tv210 = *([v209 @ X8_v11+C0]);\n\tv124 = *([v210 @ X8_v12+10]);\n\t*([v124 @ X1_v4])(v122, *([v104 @ X9_v5]), v124, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv211 = v128 == 0;\n\tv91 = ~v211;\n\tif (v91) goto L_0070;\nL_0087:\n\tv218 = 0x31C9944(&v98 @ stack_-48_v3 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv220 = 0x8BF0368(v213, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv172 = 0xA1B8(v220, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			void IDisposable.Dispose()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("CollectionExtensions._003CTraverse_003Ed__16::Dispose");
			}

			[Token(Token = "0x600003F")]
			[Address(RVA = "0x5313534", Offset = "0x5313534", Length = "0xA70")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = *([A4731E0]);\n\tv28 = methodInfo;\n\tgoto L_0024;\n\tv89 = *([v80 @ X0_v2]) == 1;\n\tif (v89) goto L_0067;\n\tv112 = *([v80 @ X0_v2]) != 2;\n\tif (v112) goto L_02AC;\n\tv129 = Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>;\n\tv130 = *([v129 @ X8_v199 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]);\n\tv133 = 0x815C(*([v129 @ X8_v199 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]), 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv216 = 0x21C1054(v76, *([v129 @ X8_v199 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v216 @ X0_v181 (System.Func`2<T, System.Collections.Generic.IEnumerable`1<T>>)]) = -4;\n\tv353 = Unco.Extensions.CollectionExtensions::Traverse(*([v130 @ X22_v26+8]), v216);\n\tgoto L_018D;\nL_0067:\n\tv117 = Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>;\n\tv118 = *([v117 @ X8_v149 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]);\n\tv121 = 0x815C(*([v117 @ X8_v149 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]), 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv208 = 0x21C1054(v76, *([v117 @ X8_v149 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v208 @ X0_v140]) = -3;\n\tv340 = 0x21C0FD4(*([v118 @ X22_v20+8]), v208, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv465 = Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>;\n\tv467 = *([v465 @ X8_v154 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]) + 0xA0;\n\tv468 = 0x21C1054(v76, v467, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv525 = Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>;\n\tv527 = *([v525 @ X8_v159 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]) + 0x100;\n\tv528 = 0x21C1054(v76, v527, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv605 = 0x8BF6A1C(v68, v528, *([v62 @ X9_v1 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv620 = *([v468 @ X0_v144]) == 0;\n\tif (v620) goto L_0358;\n\tv726 = Il2CppMethodInfo;\n\tgoto L_0099;\n\tv862 = Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>;\n\tv864 = *([v862 @ X8_v171 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]) + 0xA0;\n\tv865 = 0x21C1054(v76, v864, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv928 = Unco.Extensions.CollectionExtensions::Traverse(v542, *([v865 @ X0_v153]));\n\tv704 = v928 == 0;\n\tif (v704) goto L_035C;\n\tgoto L_00C2;\n\tv1058 = *([v1001 @ X8_v182 (Il2CppClass<System.Collections.Generic.IEnumerable`1<T>>)+B0]) + 8;\n\tv1058 = v1058 + 0x10;\n\tv1023 = v1059 - 1;\n\tv1025 = v1059 != 1;\n\tv1059 = v1023;\n\tif (v1025) goto L_00C8;\nL_00E2:\n\tv1142 = Unco.Extensions.CollectionExtensions::Traverse(v928, Il2CppClass<System.Collections.Generic.IEnumerable`1<T>>);\n\tv1141 = 0;\n\tgoto L_0164;\nL_00E8:\n\tv98 = Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>;\n\tv99 = *([v98 @ X8_v72 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]);\n\tv102 = 0x815C(*([v98 @ X8_v72 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]), 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv124 = 0x21C1054(v76, *([v98 @ X8_v72 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v124 @ X0_v65 (System.Func`2<T, System.Collections.Generic.IEnumerable`1<T>>)]) = -1;\n\tv213 = Unco.Extensions.CollectionExtensions::Traverse(*([v99 @ X22_v11+8]), v124);\n\tv345 = Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>;\n\tv347 = *([v345 @ X8_v77 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]) + 0x60;\n\tv348 = 0x21C1054(v76, v347, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv469 = *([v348 @ X0_v69]);\n\tv470 = *([v348 @ X0_v69]) == 0;\n\tif (v470) goto L_0356;\n\tgoto L_010E;\n\tv734 = *([v611 @ X8_v84 (Il2CppClass<System.Collections.Generic.IEnumerable`1<T>>)+B0]) + 8;\n\tv734 = v734 + 0x10;\n\tv628 = v735 - 1;\n\tv630 = v735 != 1;\n\tv735 = v628;\n\tif (v630) goto L_0114;\nL_012E:\n\tv816 = Unco.Extensions.CollectionExtensions::Traverse(*([v348 @ X0_v69]), Il2CppClass<System.Collections.Generic.IEnumerable`1<T>>);\n\tv806 = 0;\n\tgoto L_0137;\nL_0131:\n\tv799 = *([v734 @ X10_v25]) << 4;\n\tv800 = v611 + v799;\n\tv816 = v800 + 0x138;\n\tv806 = 0;\n\tv988 = Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>;\n\tv972 = *([v988 @ X8_v94 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]);\n\tv991 = 0x815C(*([v988 @ X8_v94 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]), 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1005 = 0x21C1054(v76, *([v988 @ X8_v94 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v1005 @ X0_v84 (System.Func`2<T, System.Collections.Generic.IEnumerable`1<T>>)]) = -3;\n\tv975 = Unco.Extensions.CollectionExtensions::Traverse(*([v972 @ X22_v14+8]), v1005);\n\tgoto L_0222;\nL_015E:\n\tv1138 = *([v1058 @ X10_v45]) << 4;\n\tv1139 = v1001 + v1138;\n\tv1142 = v1139 + 0x138;\n\tv1141 = Il2CppMethodInfo;\n\tv1276 = Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>;\n\tv560 = *([v1276 @ X8_v192 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]);\n\tv1279 = 0x815C(*([v1276 @ X8_v192 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]), 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv1292 = 0x21C1054(v76, *([v1276 @ X8_v192 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobber\n// ... truncated")]
			private unsafe bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("CollectionExtensions._003CTraverse_003Ed__16::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[Token(Token = "0x6000040")]
			[Address(RVA = "0x5313FA4", Offset = "0x5313FA4", Length = "0x154")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv60 = Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>;\n\tv62 = *([v60 @ X8_v9 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]) + 0xE0;\n\tv64 = 0x21C1054(this, v62, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv66 = *([v64 @ X0_v9]) == 0;\n\tif (v66) goto L_006F;\n\tv69 = Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>;\n\tv71 = *([v69 @ X8_v14 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]) + 0xE0;\n\tv73 = 0x21C1054(this, v71, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv80 = *([v73 @ X0_v11]);\n\tv152 = *([v80 @ X19_v3]);\n\tv195 = *([v152 @ X8_v18+12E]);\n\tv150 = *([v152 @ X8_v18+12E]) == 0;\n\tif (v150) goto L_0067;\n\tv134 = *([v152 @ X8_v18+B0]) + 8;\n\tv134 = v134 + 0x10;\n\tv182 = v195 - 1;\n\tv172 = v195 != 1;\n\tv195 = v182;\n\tif (v172) goto L_0047;\nL_0067:\n\tSystem.IDisposable::Dispose(v80);\nL_0067:\n\treturn;\nL_006F:\n\treturn;\nL_0071:\n\tv88 = *([v134 @ X10_v4]) << 4;\n\tv153 = v152 + v88;\n\tv198 = v153 + 0x138;\n\tv141 = *([v198 @ X0_v16]);\n\tv144 = *([v198 @ X0_v16+8]);\n\t// 126 IndirectJump v141 @ X2_v4, v80 @ X19_v3, v80 @ X19_v3, v144 @ X1_v8, v141 @ X2_v4, v27 @ X3, v28 @ X4, v29 @ X5, v30 @ X6, v31 @ X7, v32 @ V0, v33 @ V1, v34 @ V2, v35 @ V3, v36 @ V4, v37 @ V5, v38 @ V6, v39 @ V7\nL_0017:\n\tv45 = Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>;\n\tv46 = *([v45 @ X8_v5 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]);\n\tv49 = 0x815C(*([v45 @ X8_v5 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]), 4, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv52 = 0x21C1054(this, *([v45 @ X8_v5 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v52 @ X0_v5]) = -1;\n\tv57 = 0x21C0FD4(*([v46 @ X21_v2+8]), v52, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0047:\n\tv118 = *([v134 @ X10_v4-8]) == System.IDisposable;\n\tif (v118) goto L_0071;\n")]
			private void _003C_003Em__Finally1()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("CollectionExtensions._003CTraverse_003Ed__16::_003C_003Em__Finally1");
			}

			[Token(Token = "0x6000041")]
			[Address(RVA = "0x53140F8", Offset = "0x53140F8", Length = "0x154")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv60 = Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>;\n\tv62 = *([v60 @ X8_v9 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]) + 0x120;\n\tv64 = 0x21C1054(this, v62, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv66 = *([v64 @ X0_v9]) == 0;\n\tif (v66) goto L_006F;\n\tv69 = Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>;\n\tv71 = *([v69 @ X8_v14 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]) + 0x120;\n\tv73 = 0x21C1054(this, v71, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv80 = *([v73 @ X0_v11]);\n\tv152 = *([v80 @ X19_v3]);\n\tv195 = *([v152 @ X8_v18+12E]);\n\tv150 = *([v152 @ X8_v18+12E]) == 0;\n\tif (v150) goto L_0067;\n\tv134 = *([v152 @ X8_v18+B0]) + 8;\n\tv134 = v134 + 0x10;\n\tv182 = v195 - 1;\n\tv172 = v195 != 1;\n\tv195 = v182;\n\tif (v172) goto L_0047;\nL_0067:\n\tSystem.IDisposable::Dispose(v80);\nL_0067:\n\treturn;\nL_006F:\n\treturn;\nL_0071:\n\tv88 = *([v134 @ X10_v4]) << 4;\n\tv153 = v152 + v88;\n\tv198 = v153 + 0x138;\n\tv141 = *([v198 @ X0_v16]);\n\tv144 = *([v198 @ X0_v16+8]);\n\t// 126 IndirectJump v141 @ X2_v4, v80 @ X19_v3, v80 @ X19_v3, v144 @ X1_v8, v141 @ X2_v4, v27 @ X3, v28 @ X4, v29 @ X5, v30 @ X6, v31 @ X7, v32 @ V0, v33 @ V1, v34 @ V2, v35 @ V3, v36 @ V4, v37 @ V5, v38 @ V6, v39 @ V7\nL_0017:\n\tv45 = Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>;\n\tv46 = *([v45 @ X8_v5 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]);\n\tv49 = 0x815C(*([v45 @ X8_v5 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]), 4, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv52 = 0x21C1054(this, *([v45 @ X8_v5 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v52 @ X0_v5]) = -3;\n\tv57 = 0x21C0FD4(*([v46 @ X21_v2+8]), v52, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0047:\n\tv118 = *([v134 @ X10_v4-8]) == System.IDisposable;\n\tif (v118) goto L_0071;\n")]
			private void _003C_003Em__Finally2()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("CollectionExtensions._003CTraverse_003Ed__16::_003C_003Em__Finally2");
			}

			[DebuggerHidden]
			[Token(Token = "0x6000043")]
			[Address(RVA = "0x5314294", Offset = "0x5314294", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = 0xB292000 + 0x4A0;\n\tv28 = new v12();\n\tSystem.NotSupportedException::.ctor(v28);\n\tthrow v28;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000045")]
			[Address(RVA = "0x531437C", Offset = "0x531437C", Length = "0x1C4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>;\n\tv26 = 0x21C1054(this, *([v24 @ X8_v3 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]), v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = *([v26 @ X0_v1]) != -2;\n\tif (v52) goto L_004C;\n\tv55 = Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>;\n\tv57 = *([v55 @ X8_v31 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]) + 0x40;\n\tv59 = 0x21C1054(this, v57, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv81 = System.Environment::get_CurrentManagedThreadId();\n\tv63 = *([v59 @ X0_v29]) != v81;\n\tif (v63) goto L_004C;\n\tv106 = Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>;\n\tv107 = *([v106 @ X8_v35 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]);\n\tv110 = 0x815C(*([v106 @ X8_v35 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]), 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv139 = 0x21C1054(this, *([v106 @ X8_v35 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv139.m_value = 0;\n\tv126 = Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>::.ctor(*([v107 @ X21_v7+8]), v139);\n\tv113 = this;\n\tgoto L_0058;\nL_004C:\n\tgoto L_004E;\nL_004E:\n\tv95 = new Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>();\n\tv103 = Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>::.ctor(v95, 0);\n\tv113 = v95;\n\tv145 = Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>;\n\tv146 = *([v145 @ X8_v12 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]);\n\tv147 = *([v145 @ X8_v12 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]) + 0x60;\n\tv149 = 0x815C(v147, 8, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv151 = *([v145 @ X8_v12 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]) + 0x60;\n\tv153 = 0x21C1054(v113, v151, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v153 @ X0_v9]) = *([v136 @ X0_v4]);\n\tv157 = 0x21C0FD4(*([v146 @ X23_v1+68]), v153, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv184 = Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>;\n\tv186 = *([v184 @ X8_v15 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]) + 0xC0;\n\tv188 = 0x21C1054(this, v186, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv175 = Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>;\n\tv192 = *([v175 @ X8_v19 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]);\n\tv193 = *([v175 @ X8_v19 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]) + 0xA0;\n\tv195 = 0x815C(v193, 8, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv196 = *([v175 @ X8_v19 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]) + 0xA0;\n\tv198 = 0x21C1054(v113, v196, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v198 @ X0_v17]) = *([v188 @ X0_v13]);\n\tv200 = 0x21C0FD4(*([v192 @ X19_v2+A8]), v198, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn v113;\nL_0058:\n\tv132 = Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>;\n\tv134 = *([v132 @ X8_v8 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]) + 0x80;\n\tv136 = 0x21C1054(this, v134, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n")]
			IEnumerator<T> IEnumerable<T>.GetEnumerator()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("CollectionExtensions._003CTraverse_003Ed__16::GetEnumerator");
				return default;
			}

			[DebuggerHidden]
			[Token(Token = "0x6000046")]
			[Address(RVA = "0x5314540", Offset = "0x5314540", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis = Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>::System.Collections.Generic.IEnumerable<T>.GetEnumerator(this);\n\treturn this;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				((IEnumerable<T>)this).GetEnumerator();
				return this;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200000E")]
		private sealed class _003CYieldBatchElements_003Ed__9<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400002C")]
			[FieldOffset(Offset = "0x0")]
			private int _003C_003E1__state;

			[Token(Token = "0x400002D")]
			[FieldOffset(Offset = "0x0")]
			private T _003C_003E2__current;

			[Token(Token = "0x400002E")]
			[FieldOffset(Offset = "0x0")]
			private int _003C_003El__initialThreadId;

			[Token(Token = "0x400002F")]
			[FieldOffset(Offset = "0x0")]
			private IEnumerator<T> source;

			[Token(Token = "0x4000030")]
			[FieldOffset(Offset = "0x0")]
			public IEnumerator<T> _003C_003E3__source;

			[Token(Token = "0x4000031")]
			[FieldOffset(Offset = "0x0")]
			private int batchSize;

			[Token(Token = "0x4000032")]
			[FieldOffset(Offset = "0x0")]
			public int _003C_003E3__batchSize;

			[Token(Token = "0x4000033")]
			[FieldOffset(Offset = "0x0")]
			private int _003Ci_003E5__2;

			[Token(Token = "0x1700000B")]
			T IEnumerator<T>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600004A")]
				[Address(RVA = "0x531CA8C", Offset = "0x531CA8C", Length = "0x48")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = Il2CppClass<T>;\n\tv17 = Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>;\n\tv19 = *([v17 @ X8_v3 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]) + 0x20;\n\tv20 = 0x21C1054(this, v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\treturnVal1 = 0x8BF6A34(il2cppRetVal, v20, *([v15 @ X9_v1 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal1;\n")]
				get
				{
					//IL_0022: Expected O, but got I
					nint num = 0;
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ X8_v3 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]");
					object obj = (nint)0 + (nint)32;
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1054");
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A34");
					T result = default(T);
					return result;
				}
			}

			[Token(Token = "0x1700000C")]
			unsafe object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600004C")]
				[Address(RVA = "0x531CB0C", Offset = "0x531CB0C", Length = "0xB0")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = *([A4731E0]);\n\tv22 = Il2CppClass<T>;\n\tv26 = *([v22 @ X9_v1 (Il2CppClass<T>)+FC]) + 0xF;\n\tv27 = v26 & 0x1FFFFFFF0;\n\t// 21 StackAlloc v28 @ X21_v1 (System.Byte*), v27 @ X10_v2 (System.Int32)\n\tv30 = Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>;\n\tv32 = *([v30 @ X8_v6 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]) + 0x20;\n\tv33 = 0x21C1054(this, v32, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv52 = 0x8BF6A1C(v28, v33, *([v22 @ X9_v1 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t// 35 Box returnVal1 @ X0_v5 (System.Object), typeof(Il2CppClass<T>), v28 @ X21_v1 (System.Byte*)\n\tv60 = *([A4731E0]);\n\tv71 = *([v60 @ X9_v4]) != *([v17 @ X8_v2]);\n\tif (v71) goto L_003C;\n\treturn returnVal1;\nL_003C:\n\treturnVal2 = 0x8BF5CF0(returnVal1, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal2;\n")]
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
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v30 @ X8_v6 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]");
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
			[Token(Token = "0x6000047")]
			[Address(RVA = "0x531C518", Offset = "0x531C518", Length = "0xB4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tv23 = Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>;\n\tv24 = *([v23 @ X8_v3 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]);\n\tv27 = 0x815C(*([v23 @ X8_v3 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]), 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv43 = 0x21C1054(this, *([v23 @ X8_v3 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v43 @ X0_v4]) = <>1__state;\n\tv47 = 0x21C0FD4(*([v24 @ X22_v1+8]), v43, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv49 = System.Environment::get_CurrentManagedThreadId();\n\tv53 = Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>;\n\tv54 = *([v53 @ X8_v6 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]);\n\tv55 = *([v53 @ X8_v6 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]) + 0x40;\n\tv57 = 0x815C(v55, 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv58 = *([v53 @ X8_v6 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]) + 0x40;\n\tv60 = 0x21C1054(this, v58, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v60 @ X0_v12]) = v49;\n\tv70 = 0x21C0FD4(*([v54 @ X19_v2+48]), v60, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\n")]
			public _003CYieldBatchElements_003Ed__9(int _003C_003E1__state)
			{
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X8_v3 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]");
				object obj = 0;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @815C");
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1054");
				object obj2 = _003C_003E1__state;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C0FD4");
				int currentManagedThreadId = Environment.CurrentManagedThreadId;
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v6 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v6 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]");
				object obj4 = (nint)0 + (nint)64;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @815C");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v6 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]");
				object obj5 = (nint)0 + (nint)64;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1054");
				object obj6 = currentManagedThreadId;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C0FD4");
			}

			[DebuggerHidden]
			[Token(Token = "0x6000048")]
			[Address(RVA = "0x531C5CC", Offset = "0x531C5CC", Length = "0x4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000049")]
			[Address(RVA = "0x531C5D0", Offset = "0x531C5D0", Length = "0x4BC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = *([A4731E0]);\n\tgoto L_001E;\n\tv79 = *([v64 @ X0_v3]) == 1;\n\tif (v79) goto L_008B;\n\tv91 = *([v64 @ X0_v3]) == 0;\n\tv92 = ~v91;\n\tif (v92) goto L_015A;\n\tv105 = Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>;\n\tv106 = *([v105 @ X8_v75 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]);\n\tv109 = 0x815C(*([v105 @ X8_v75 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]), 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv208 = 0x21C1054(this, *([v105 @ X8_v75 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v208 @ X0_v70]) = -1;\n\tv306 = 0x21C0FD4(*([v106 @ X23_v16+8]), v208, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv394 = Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>;\n\tv366 = *([v394 @ X8_v79 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]) + 0x60;\n\tv380 = 0x21C1054(this, v366, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv369 = *([v380 @ X0_v74]);\n\tgoto L_0067;\n\tv481 = *([v434 @ X8_v85+B0]) + 8;\n\tv481 = v481 + 0x10;\n\tv451 = v480 - 1;\n\tv449 = v480 != 1;\n\tv480 = v451;\n\tif (v449) goto L_0072;\nL_0087:\n\tv519 = 0x220C5E0(v369, Il2CppClass<System.Collections.Generic.IEnumerator`1<T>>, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0176;\nL_008B:\n\tv95 = Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>;\n\tv96 = *([v95 @ X8_v71 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]);\n\tv99 = 0x815C(*([v95 @ X8_v71 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]), 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv200 = 0x21C1054(this, *([v95 @ X8_v71 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v200 @ X0_v64]) = -1;\n\tv294 = 0x21C0FD4(*([v96 @ X23_v14+8]), v200, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv398 = 0;\n\tgoto L_00B6;\nL_009D:\n\tv86 = Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>;\n\tv87 = *([v86 @ X8_v62 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]);\n\tv90 = 0x815C(*([v86 @ X8_v62 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]), 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv102 = 0x21C1054(this, *([v86 @ X8_v62 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v102 @ X0_v56]) = -1;\n\tv205 = 0x21C0FD4(*([v87 @ X23_v12+8]), v102, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv297 = Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>;\n\tv299 = *([v297 @ X8_v66 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]) + 0xE0;\n\tv301 = 0x21C1054(this, v299, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv398 = *([v301 @ X0_v60]) + 1;\n\tv439 = Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>;\n\tv441 = *([v439 @ X8_v25 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]) + 0xE0;\n\tv443 = 0x21C1054(this, v441, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv475 = Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>;\n\tv135 = *([v475 @ X8_v29 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]) + 0xA0;\n\tv174 = 0x21C1054(this, v135, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv122 = *([v443 @ X0_v22]) >= *([v174 @ X0_v24]);\n\tif (v122) goto L_015A;\n\tv532 = Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>;\n\tv367 = *([v532 @ X8_v34 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]) + 0x60;\n\tv381 = 0x21C1054(this, v367, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv138 = *([v381 @ X0_v26]);\n\tv587 = *([v138 @ X23_v4]);\n\tv611 = *([v587 @ X8_v38+12E]);\n\tv589 = *([v587 @ X8_v38+12E]) == 0;\n\tif (v589) goto L_010F;\n\tv128 = *([v587 @ X8_v38+B0]) + 8;\n\tv128 = v128 + 0x10;\n\tv596 = v611 - 1;\n\tv595 = v611 != 1;\n\tv611 = v596;\n\tif (v595) goto L_00F6;\nL_010F:\n\tv175 = System.Collections.IEnumerator::MoveNext(v138);\n\tv622 = v175 & 1;\n\tv178 = v622 == 0;\n\tif (v178) goto L_015A;\nL_0115:\n\tv638 = Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>;\n\tv368 = *([v638 @ X8_v42 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]) + 0x60;\n\tv382 = 0x21C1054(this, v368, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv370 = *([v382 @ X0_v29]);\n\tgoto L_0129;\n\tv687 = *([v653 @ X8_v48+B0]) + 8;\n\tv687 = v687 + 0x10;\n\tv662 = v686 - 1;\n\tv660 = v686 != 1;\n\tv686 = v662;\n\tif (v660) goto L_0134;\nL_0149:\n\tv711 = 0x220C5E0(v370, Il2CppClass<System.Collections.Generic.IEnumerator`1<T>>, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0184;\nL_014C:\n\tv117 = *([v128 @ X10_v14]) << 4;\n\tv627 = v587 + v117;\n\tv628 = v627 + 0x138;\n\t*([v628 @ X0_v43])(v173, v138, *([v628 @ X0_v43+8]), 0, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv630 = v173 & 1;\n\tv631 = v630 == 0;\n\tv177 = ~v631;\n\tif (v177) goto L_0115;\nL_015A:\n\tv186 = *([A4731E0]);\n\tv197 = *([v186 @ X9_v24]) != *([v23 @ X8_v2]);\n\treturnVal1 = 0;\n\tv285 = 0;\n\tif (v197) goto L_01B4;\nL_0171:\n\treturn returnVal1;\nL_0173:\n\tv502 = *([v481 @ X10_v24]) << 4;\n\tv503 = v434 + v502;\n\tv519 = v503 + 0x138;\nL_0181:\n\tv707 = *([v687\n// ... truncated")]
			private unsafe bool MoveNext()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("CollectionExtensions._003CYieldBatchElements_003Ed__9::MoveNext");
				return default;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600004B")]
			[Address(RVA = "0x531CAD4", Offset = "0x531CAD4", Length = "0x38")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = 0xB292000 + 0x4A0;\n\tv28 = new v12();\n\tSystem.NotSupportedException::.ctor(v28);\n\tthrow v28;\n")]
			void IEnumerator.Reset()
			{
				int num = 187244544 + 1184;
				NotSupportedException ex = new NotSupportedException();
				throw ex;
			}

			[DebuggerHidden]
			[Token(Token = "0x600004D")]
			[Address(RVA = "0x531CBBC", Offset = "0x531CBBC", Length = "0x1C4")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>;\n\tv26 = 0x21C1054(this, *([v24 @ X8_v3 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]), v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv52 = *([v26 @ X0_v1]) != -2;\n\tif (v52) goto L_004C;\n\tv55 = Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>;\n\tv57 = *([v55 @ X8_v31 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]) + 0x40;\n\tv59 = 0x21C1054(this, v57, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv81 = System.Environment::get_CurrentManagedThreadId();\n\tv63 = *([v59 @ X0_v29]) != v81;\n\tif (v63) goto L_004C;\n\tv106 = Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>;\n\tv107 = *([v106 @ X8_v35 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]);\n\tv110 = 0x815C(*([v106 @ X8_v35 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]), 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv139 = 0x21C1054(this, *([v106 @ X8_v35 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv139.m_value = 0;\n\tv126 = Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>::.ctor(*([v107 @ X21_v7+8]), v139);\n\tv113 = this;\n\tgoto L_0058;\nL_004C:\n\tgoto L_004E;\nL_004E:\n\tv95 = new Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>();\n\tv103 = Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>::.ctor(v95, 0);\n\tv113 = v95;\n\tv145 = Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>;\n\tv146 = *([v145 @ X8_v12 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]);\n\tv147 = *([v145 @ X8_v12 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]) + 0x60;\n\tv149 = 0x815C(v147, 8, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv151 = *([v145 @ X8_v12 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]) + 0x60;\n\tv153 = 0x21C1054(v113, v151, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v153 @ X0_v9]) = *([v136 @ X0_v4]);\n\tv157 = 0x21C0FD4(*([v146 @ X23_v1+68]), v153, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv184 = Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>;\n\tv186 = *([v184 @ X8_v15 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]) + 0xC0;\n\tv188 = 0x21C1054(this, v186, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv175 = Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>;\n\tv192 = *([v175 @ X8_v19 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]);\n\tv193 = *([v175 @ X8_v19 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]) + 0xA0;\n\tv195 = 0x815C(v193, 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv196 = *([v175 @ X8_v19 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]) + 0xA0;\n\tv198 = 0x21C1054(v113, v196, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v198 @ X0_v17]) = *([v188 @ X0_v13]);\n\tv200 = 0x21C0FD4(*([v192 @ X19_v2+A8]), v198, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn v113;\nL_0058:\n\tv132 = Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>;\n\tv134 = *([v132 @ X8_v8 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]) + 0x80;\n\tv136 = 0x21C1054(this, v134, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n")]
			IEnumerator<T> IEnumerable<T>.GetEnumerator()
			{
				global::AssetRipperInjected.RecoveryStub.Missing("CollectionExtensions._003CYieldBatchElements_003Ed__9::GetEnumerator");
				return default;
			}

			[DebuggerHidden]
			[Token(Token = "0x600004E")]
			[Address(RVA = "0x531CD80", Offset = "0x531CD80", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis = Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>::System.Collections.Generic.IEnumerable<T>.GetEnumerator(this);\n\treturn this;\n")]
			IEnumerator IEnumerable.GetEnumerator()
			{
				((IEnumerable<T>)this).GetEnumerator();
				return this;
			}
		}

		[Token(Token = "0x600000C")]
		[Address(RVA = "0x484A694", Offset = "0x484A694", Length = "0x34C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv35 = *([A4731E0]);\n\tv38 = value;\n\tv39 = v500;\n\tgoto L_0020;\n\tv44 = 0x220C2B8(methodInfo, v500, value, methodInfo, v45, v407, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\nL_FFFFFFFF:\n\tv123 = v500;\n\tgoto L_0062;\nL_FFFFFFFF:\n\tv123 = &v39 @ stack_-88_v1 (K);\n\tv130 = Il2CppMethodInfo;\n\tgoto L_0070;\nL_FFFFFFFF:\n\tv228 = v500;\n\tgoto L_0090;\nL_FFFFFFFF:\n\tv228 = &v39 @ stack_-88_v1 (K);\n\tv287 = Il2CppMethodInfo;\n\tgoto L_00A6;\nL_FFFFFFFF:\n\tv354 = value;\n\tgoto L_00C9;\nL_FFFFFFFF:\n\tv354 = &v38 @ stack_-90_v1 (V);\nL_FFFFFFFF:\n\treturnVal2 = 0;\n\tgoto L_0116;\nL_00E5:\n\tv295 = Il2CppClass<V>;\n\tv300 = *([v295 @ X8_v36 (Il2CppClass<V>)+28]) < 0;\n\tv303 = *([v295 @ X8_v36 (Il2CppClass<V>)+28]) ^ *([v295 @ X8_v36 (Il2CppClass<V>)+28]);\n\tv304 = *([v295 @ X8_v36 (Il2CppClass<V>)+28]) & v303;\n\tv305 = v304 < 0;\n\tv307 = v300 == v305;\n\tv308 = ~v307;\n\tv309 = ~v308;\n\tif (v309) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv341 = value;\n\tgoto L_00FB;\nL_FFFFFFFF:\n\tv341 = &v38 @ stack_-90_v1 (V);\n\treturn returnVal2;\nL_0133:\n\tv482 = Il2CppClass<K>;\n\tv487 = *([v482 @ X8_v51 (Il2CppClass<K>)+28]) < 0;\n\tv490 = *([v482 @ X8_v51 (Il2CppClass<K>)+28]) ^ *([v482 @ X8_v51 (Il2CppClass<K>)+28]);\n\tv491 = *([v482 @ X8_v51 (Il2CppClass<K>)+28]) & v490;\n\tv492 = v491 < 0;\n\tv495 = v487 == v492;\n\tv496 = ~v495;\n\tv497 = ~v496;\n\tif (v497) goto L_014A;\n\tgoto L_014A;\nL_FFFFFFFF:\n\tv510 = value;\n\tgoto L_0161;\nL_FFFFFFFF:\n\tv510 = &v38 @ stack_-90_v1 (V);\nL_FFFFFFFF:\n\tv414 = v89;\nL_FFFFFFFF:\n\tv417 = Il2CppMethodInfo;\n\tgoto L_010A;\nL_016B:\n\treturnVal1 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal1;\nL_0020:\n\tv60 = Il2CppClass<V>;\n\tv62 = Il2CppClass<K>;\n\tgoto L_002F;\nL_0062:\n\tv126 = 0x8BF6A1C(v89, v123, *([v62 @ X8_v4 (Il2CppClass<K>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0070:\n\tv140 = v89;\n\t*([v130 @ X1_v4 (Il2CppMethodInfo)+10])(v147, *([v130 @ X1_v4 (Il2CppMethodInfo)]), Il2CppMethodInfo, dict, &v140 @ stack_-78_v2 (System.IntPtr), &v144 @ stack_-79_v2, v407, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv150 = Il2CppClass<K>;\n\tv155 = *([v150 @ X8_v26 (Il2CppClass<K>)+28]) < 0;\n\tv158 = *([v150 @ X8_v26 (Il2CppClass<K>)+28]) ^ *([v150 @ X8_v26 (Il2CppClass<K>)+28]);\n\tv159 = *([v150 @ X8_v26 (Il2CppClass<K>)+28]) & v158;\n\tv160 = v159 < 0;\n\tv164 = v155 == v160;\n\tv165 = ~v164;\n\tv166 = ~v165;\n\tif (v166) goto L_FFFFFFFF;\nL_0090:\n\tv230 = 0x8BF6A1C(v89, v228, *([v62 @ X8_v4 (Il2CppClass<K>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv286 = v144 != 1;\n\tif (v286) goto L_00E5;\nL_00A6:\n\tv140 = v89;\n\tv313 = v94;\n\t*([v287 @ X1_v13 (Il2CppMethodInfo)+10])(v318, *([v287 @ X1_v13 (Il2CppMethodInfo)]), Il2CppMethodInfo, dict, &v140 @ stack_-78_v2 (System.IntPtr), v94, v407, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv322 = 0x8BF6A1C(v100, v94, *([v60 @ X0_v2 (Il2CppClass<V>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv326 = Il2CppClass<V>;\n\tv331 = *([v326 @ X19_v10 (Il2CppClass<V>)+28]) < 0;\n\tv334 = *([v326 @ X19_v10 (Il2CppClass<V>)+28]) ^ *([v326 @ X19_v10 (Il2CppClass<V>)+28]);\n\tv335 = *([v326 @ X19_v10 (Il2CppClass<V>)+28]) & v334;\n\tv336 = v335 < 0;\n\tv338 = v331 == v336;\n\tv339 = ~v338;\n\tv340 = ~v339;\n\tif (v340) goto L_FFFFFFFF;\nL_00C9:\n\tv358 = 0x8BF6A1C(v97, v354, *([v60 @ X0_v2 (Il2CppClass<V>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t// 204 Box v439 @ X0_v30, typeof(Il2CppClass<V>), v97 @ X8_v16 (System.Byte*)\nL_FFFFFFFF:\n\tv478 = Il2CppMethodRgctx<Unco.Extensions.CollectionExtensions::ReplaceOrAdd>;\n\tgoto L_00D9;\nL_00D9:\n\tv140 = v439;\n\tv480 = 0x21C1F68(Il2CppClass<V>, *([v478 @ X8_v49 (Il2CppMethodRgctx<Unco.Extensions.CollectionExtensions::ReplaceOrAdd>)+28]), v82, v100, &v140 @ stack_-78_v2 (System.IntPtr), &v144 @ stack_-79_v2, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv481 = v144 & 1;\n\tv470 = v481 == 0;\n\tif (v470) goto L_0133;\nL_0116:\n\tv474 = *([A4731E0]);\n\tv197 = *([v474 @ X9_v13]) != *([v35 @ X8_v2]);\n\tif (v197) goto L_016B;\nL_00FB:\n\tv344 = 0x8BF6A1C(v94, v341, *([v60 @ X0_v2 (Il2CppClass<V>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv347 = Il2CppMethodInfo;\n\tv428 = *([v347 @ X1_v10 (Il2CppMethodInfo)]);\nL_FFFFFFFF:\n\tv414 = v89;\nL_FFFFFFFF:\n\tv417 = Il2CppMethodInfo;\n\tgoto L_010A;\nL_010A:\n\tgoto L_010C;\nL_014A:\n\tv502 = 0x8BF6A1C(v89, &v39 @ stack_-88_v1 (K), *([v62 @ X8_v4 (Il2CppClass<K>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv503 = Il2CppClass<V>;\n\tv393 = *([v503 @ X8_v54 (Il2CppClass<V>)+28]) < 0;\n\tv387 = *([v503 @ X8_v54 (Il2CppClass<V>)+28]) ^ *([v503 @ X8_v54 (Il2CppClass<V>)+28]);\n\tv385 = *([v503 @ X8_v54 (Il2CppClass<V>)+28]) & v387;\n\tv383 = v385 < 0;\n\tv507 = v393 == v383;\n\tv381 = ~v507;\n\tv379 = ~v381;\n\tif (v379) goto L_FFFFFFFF;\nL_0161:\n\tv512 = 0x8BF6A1C(v94, v510, *([v60 @ X0_v2 (Il2CppClass<V>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv377 = Il2CppMethodInfo;\n\tv428 = *([v377 @ X1_v20 (Il2CppMethodInfo)]);\n\tgoto L_FFFFFFFF;\nL_002F:\n\tv77 = *([v60 @ X0_v2 (Il2CppClass<V>)+FC]) + 0x10;\n\tv80 = v77 + 0xF;\n\tv81 = v80 & 0x1FFFFFFF0;\n\t// 51 StackAlloc v82 @ X8_v12 (System.Byte*), v81 @ X8_v11 (System.Int32)\n\tv87 = *([v62 @ X8_v4 (Il2CppClass<K>)+FC]) + 0xF;\n\tv88 = v87 & 0x1FFFFFFF0;\n\t// 58 StackAlloc v89 @ X21_v1 (System.Byte*), v88 @ X9_v4 (System.Int32)\n\tv92 = *([v60 @ X0_v2 (Il2CppClass<V>)+FC]) + 0xF;\n\tv93 = v92 & 0x1FFFFFFF0;\n\t// 63 StackAlloc v94 @ X20_v1 (System.Byte*), v93 @ X9_v6 (System.Int32)\n\t// 66 StackAlloc v97 @ X8_v16 (System.Byte*), v93 @ X9_v6 (System.Int32)\n\t// 70 StackAlloc v100 @ X28_v1 (System.Byte*), v93 @ X9_v6 (System.Int32)\n\tv104 = 0x8BF5F18(v100, *([v60 @ X0_v2 (Il2CppClass<V>)+FC]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv105 = Il2CppClass<K>;\n\tv110 = *([v105 @ X8_v18 (Il2CppClass<K>)+28]) < 0;\n\tv113 = *([v105 @ X8_v18 (Il2CppClass<K>)+28]) ^ *([v105 @ X8_v18 (Il2CppClass<K>)+28]);\n\tv114 = *([v105 @ X8_v18 (Il2CppClass<K>)+28]) & v113;\n\tv115 = v114 < 0;\n\tv118 = v110 == v115;\n\tv119 = ~v118;\n\tv120 = ~v119;\n\tif (v120) goto L_FFFFFFFF;\nL_010C:\n\tv140 = v414;\n\tv443 = v94;\n\t*([v417 @ X1_v6 (Il2CppMethodInfo)+10])(v448, v428, v417, dict, &v140 @ stack_-78_v2 (System.IntPtr), v94, &v144 @ stack_-79_v2, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\nL_FFFFFFFF:\n\treturnVal2 = 1;\n")]
		public unsafe static bool ReplaceOrAdd<K, V>(this Dictionary<K, V> dict, K key, V value)
		{
			//IL_0010: Expected O, but got I
			//IL_0584: Expected O, but got I
			//IL_0593: Expected O, but got I
			//IL_05a6: Expected I4, but got I8
			//IL_05c7: Expected O, but got I
			//IL_05da: Expected I4, but got I8
			//IL_05fb: Expected O, but got I
			//IL_060e: Expected I4, but got I8
			//IL_0495: Expected O, but got I
			//IL_0459: Expected O, but got I
			//IL_040e: Expected I, but got O
			//IL_0569: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj = 0;
			K val2 = default(K);
			K val = val2;
			nint num = 0;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ X0_v2 (Il2CppClass<V>)+FC]");
			object obj2 = (nint)0 + (nint)16;
			object obj3 = (nint)obj2 + 15;
			int num3 = (int)((nint)obj3 & 0x1FFFFFFF0L);
			byte* ptr = stackalloc byte[(int)(uint)num3];
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X8_v4 (Il2CppClass<K>)+FC]");
			object obj4 = (nint)0 + (nint)15;
			int num4 = (int)((nint)obj4 & 0x1FFFFFFF0L);
			byte* ptr2 = stackalloc byte[(int)(uint)num4];
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ X0_v2 (Il2CppClass<V>)+FC]");
			object obj5 = (nint)0 + (nint)15;
			int num5 = (int)((nint)obj5 & 0x1FFFFFFF0L);
			byte* ptr3 = stackalloc byte[(int)(uint)num5];
			byte* ptr4 = stackalloc byte[(int)(uint)num5];
			byte* ptr5 = stackalloc byte[(int)(uint)num5];
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5F18");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ X8_v18 (Il2CppClass<K>)+28]");
			bool flag = (nint)0 < (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ X8_v18 (Il2CppClass<K>)+28]");
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ X8_v18 (Il2CppClass<K>)+28]");
			int num8 = (int)(num7 ^ 0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ X8_v18 (Il2CppClass<K>)+28]");
			int num9 = (int)((nint)0 & (nint)num8);
			bool flag2 = num9 < 0;
			if (flag != flag2)
			{
				K val3 = val2;
			}
			else
			{
				K val3 = val;
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A1C");
			nint num10 = 0;
			nint num11 = (nint)ptr2;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v130 @ X1_v4 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			nint num12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ X8_v26 (Il2CppClass<K>)+28]");
			bool flag3 = (nint)0 < (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ X8_v26 (Il2CppClass<K>)+28]");
			nint num13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ X8_v26 (Il2CppClass<K>)+28]");
			int num14 = (int)(num13 ^ 0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v150 @ X8_v26 (Il2CppClass<K>)+28]");
			int num15 = (int)((nint)0 & (nint)num14);
			bool flag4 = num15 < 0;
			if (flag3 != flag4)
			{
				K val4 = val2;
			}
			else
			{
				K val4 = val;
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A1C");
			object obj6 = default(object);
			bool result;
			IntPtr intPtr;
			if ((nint)obj6 == 1)
			{
				nint num16 = 0;
				num11 = (nint)ptr2;
				byte* ptr6 = ptr3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v287 @ X1_v13 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A1C");
				nint num17 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ X19_v10 (Il2CppClass<V>)+28]");
				bool flag5 = (nint)0 < (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ X19_v10 (Il2CppClass<V>)+28]");
				nint num18 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ X19_v10 (Il2CppClass<V>)+28]");
				int num19 = (int)(num18 ^ 0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ X19_v10 (Il2CppClass<V>)+28]");
				int num20 = (int)((nint)0 & (nint)num19);
				bool flag6 = num20 < 0;
				if (flag5 != flag6)
				{
					V val5 = value;
				}
				else
				{
					V val5 = value;
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A1C");
				object obj7 = (nint)ptr4;
				nint num21 = 0;
				num11 = (nint)obj7;
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1F68");
				if ((int)((nint)obj6 & 1) != 0)
				{
					result = false;
					goto IL_0449;
				}
				nint num22 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v482 @ X8_v51 (Il2CppClass<K>)+28]");
				bool flag7 = (nint)0 < (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v482 @ X8_v51 (Il2CppClass<K>)+28]");
				nint num23 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v482 @ X8_v51 (Il2CppClass<K>)+28]");
				int num24 = (int)(num23 ^ 0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v482 @ X8_v51 (Il2CppClass<K>)+28]");
				int num25 = (int)((nint)0 & (nint)num24);
				bool flag8 = num25 < 0;
				if (flag7 != flag8)
				{
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A1C");
				nint num26 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ X8_v54 (Il2CppClass<V>)+28]");
				bool flag9 = (nint)0 < (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ X8_v54 (Il2CppClass<V>)+28]");
				nint num27 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ X8_v54 (Il2CppClass<V>)+28]");
				int num28 = (int)(num27 ^ 0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v503 @ X8_v54 (Il2CppClass<V>)+28]");
				int num29 = (int)((nint)0 & (nint)num28);
				bool flag10 = num29 < 0;
				if (flag9 != flag10)
				{
					V val6 = value;
				}
				else
				{
					V val6 = value;
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A1C");
				nint num30 = 0;
				object obj8 = num30;
				intPtr = (nint)ptr2;
				nint num31 = 0;
			}
			else
			{
				nint num32 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ X8_v36 (Il2CppClass<V>)+28]");
				bool flag11 = (nint)0 < (nint)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ X8_v36 (Il2CppClass<V>)+28]");
				nint num33 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ X8_v36 (Il2CppClass<V>)+28]");
				int num34 = (int)(num33 ^ 0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v295 @ X8_v36 (Il2CppClass<V>)+28]");
				int num35 = (int)((nint)0 & (nint)num34);
				bool flag12 = num35 < 0;
				if (flag11 != flag12)
				{
					V val7 = value;
				}
				else
				{
					V val7 = value;
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A1C");
				nint num36 = 0;
				object obj8 = num36;
				intPtr = (nint)ptr2;
				nint num31 = 0;
			}
			num11 = intPtr;
			IntPtr intPtr2 = (nint)ptr3;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v417 @ X1_v6 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			result = true;
			goto IL_0449;
			IL_0449:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj9 = 0;
			if (obj9 == obj)
			{
				return result;
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5CF0");
			bool result2 = default(bool);
			return result2;
		}

		[IteratorStateMachine(typeof(_003CEnumerate_003Ed__1<>))]
		[Token(Token = "0x600000D")]
		[Address(RVA = "0x4848468", Offset = "0x4848468", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv49 = Il2CppClass<Unco.Extensions.CollectionExtensions+<Enumerate>d__1`1<T>>;\n\tgoto L_0015;\nL_0015:\n\tv52 = new v49();\n\tUnco.Extensions.CollectionExtensions+<Enumerate>d__1`1<T>::.ctor(v52, -2);\n\tv60 = v52 == 0;\n\tif (v60) goto L_0035;\n\t*([v52 @ X0_v5 (System.Collections.Generic.IEnumerable`1<T>)+30]) = data;\n\treturn v52;\n\tv27 = 0x220C2B8(methodInfo, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv49 = Il2CppClass<Unco.Extensions.CollectionExtensions+<Enumerate>d__1`1<T>>;\n\tgoto L_0015;\nL_0035:\n\tthrow v52;\n")]
		public static IEnumerable<T> Enumerate<T>(this T data)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CollectionExtensions::Enumerate");
			return default;
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0x484A3A4", Offset = "0x484A3A4", Length = "0x2F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv35 = *([A4731E0]);\n\tv38 = newItem;\n\tgoto L_001F;\n\tv43 = 0x220C2B8(v174, predicate, newItem, v174, v172, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_FFFFFFFF:\n\tv182 = newItem;\nL_FFFFFFFF:\n\tv134 = 0;\n\tgoto L_0040;\nL_002E:\n\tv638 = 0x220C5E0(collection, Il2CppClass<System.Collections.Generic.IList`1<T>>, 1, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_002F:\n\tv500 = &v70 @ stack_-7C;\n\tv551 = v65;\n\tv550 = *([v638 @ X0_v21+8]);\n\t*([v550 @ X1_v16+10])(v554, *([v550 @ X1_v16+8]), v550, collection, &v500 @ stack_-78_v5 (System.IntPtr), v65, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_FFFFFFFF:\n\tv172 = v65;\nL_FFFFFFFF:\n\tv174 = &v500 @ stack_-78_v5 (System.IntPtr);\nL_FFFFFFFF:\n\tv183 = collection;\n\tv340 = *([v250 @ X8_v14 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]) + 8;\n\tv340 = v340 + 0x10;\n\tv259 = v331 - 1;\n\tv257 = v331 != 1;\nL_FFFFFFFF:\n\tv331 = v259;\n\tif (v257) goto L_004A;\nL_0066:\n\t;\n\tv353 = System.Collections.Generic.ICollection`1<T>::get_Count(collection);\n\tv364 = v134 < v353;\n\tif (v364) goto L_0090;\n\tgoto L_0135;\nL_0076:\n\t;\n\tv367 = *([v340 @ X10_v23]) << 4;\n\tv368 = v250 + v367;\n\tv369 = v368 + 0x138;\n\t*([v369 @ X0_v37])(v373, collection, *([v369 @ X0_v37+8]), v182, v174, v172, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv383 = v134 >= v373;\n\tif (v383) goto L_0135;\nL_0090:\n\tgoto L_0095;\n\tv470 = *([v427 @ X8_v21 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]) + 8;\n\tv470 = v470 + 0x10;\n\tv437 = v461 - 1;\n\tv435 = v461 != 1;\nL_FFFFFFFF:\n\tv461 = v437;\n\tif (v435) goto L_009B;\nL_00B5:\n\tv486 = 0x220C5E0(collection, Il2CppClass<System.Collections.Generic.IList`1<T>>, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_00BB;\nL_00B7:\n\t;\n\tv482 = *([v470 @ X10_v18]) << 4;\n\tv483 = v427 + v482;\n\tv486 = v483 + 0x138;\n\tgoto L_00CF;\n\tv519 = Il2CppClass<T>;\n\tv524 = *([v519 @ X8_v28 (Il2CppClass<T>)+28]) < 0;\n\tv527 = *([v519 @ X8_v28 (Il2CppClass<T>)+28]) ^ *([v519 @ X8_v28 (Il2CppClass<T>)+28]);\n\tv528 = *([v519 @ X8_v28 (Il2CppClass<T>)+28]) & v527;\n\tv529 = v528 < 0;\n\tv530 = v524 == v529;\n\tv531 = ~v530;\n\tv532 = ~v531;\n\tif (v532) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv559 = newItem;\n\tgoto L_00F9;\nL_FFFFFFFF:\n\tv559 = &v38 @ stack_-88_v1 (T);\n\tv625 = *([v583 @ X8_v34 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]) + 8;\n\tv625 = v625 + 0x10;\n\tv592 = v616 - 1;\n\tv590 = v616 != 1;\nL_FFFFFFFF:\n\tv616 = v592;\n\tif (v590) goto L_0114;\n\tgoto L_002E;\nL_012D:\n\t;\n\tv636 = *([v625 @ X10_v11]) + 1;\n\tv635 = v636 << 4;\n\tv641 = v583 + v635;\n\tv638 = v641 + 0x138;\n\tgoto L_002F;\nL_0135:\n\tv420 = *([A4731E0]);\n\tv206 = *([v420 @ X9_v9]) != *([v35 @ X8_v2]);\n\tif (v206) goto L_0152;\n\treturn;\nL_0152:\n\tv244 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_001F:\n\tv59 = Il2CppClass<T>;\n\tv63 = *([v59 @ X8_v6 (Il2CppClass<T>)+FC]) + 0xF;\n\tv64 = v63 & 0x1FFFFFFF0;\n\t// 36 StackAlloc v65 @ X24_v1 (System.Byte*), v64 @ X9_v2 (System.Int32)\nL_0040:\n\tgoto L_0044;\nL_004A:\n\t;\n\tv345 = *([v340 @ X10_v23-8]) == Il2CppClass<System.Collections.Generic.ICollection`1<T>>;\n\tif (v345) goto L_0076;\nL_0095:\n\tv427 = collection->klass;\n\tv461 = collection->klass->interface_offsets_count;\n\tv429 = *([v427 @ X8_v21 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]) == 0;\n\tif (v429) goto L_00B5;\nL_009B:\n\t;\n\tv475 = *([v470 @ X10_v18-8]) == Il2CppClass<System.Collections.Generic.IList`1<T>>;\n\tif (v475) goto L_00B7;\nL_00BB:\n\tv500 = &v70 @ stack_-7C;\n\tv125 = v65;\n\tv122 = *([v486 @ X0_v11+8]);\n\t*([v122 @ X1_v10+10])(v136, *([v122 @ X1_v10+8]), v122, collection, &v500 @ stack_-78_v5 (System.IntPtr), v65, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_00CF:\n\tv498 = Il2CppMethodInfo;\n\tv500 = v65;\n\t*([v498 @ X1_v11 (Il2CppMethodInfo)+10])(v506, *([v498 @ X1_v11 (Il2CppMethodInfo)]), Il2CppMethodInfo, predicate, &v500 @ stack_-78_v5 (System.IntPtr), &v70 @ stack_-7C, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv517 = v70 != 1;\nL_FFFFFFFF:\n\tv172 = &v70 @ stack_-7C;\nL_FFFFFFFF:\n\tv174 = &v500 @ stack_-78_v5 (System.IntPtr);\nL_FFFFFFFF:\n\tv183 = predicate;\n\tif (v517) goto L_0038;\nL_00F9:\n\tv562 = 0x8BF6A1C(v65, v559, *([v59 @ X8_v6 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_010B;\nL_010B:\n\tgoto L_010E;\nL_0114:\n\t;\n\tv630 = *([v625 @ X10_v11-8]) == Il2CppClass<System.Collections.Generic.IList`1<T>>;\n\tif (v630) goto L_012D;\nL_0044:\n\tv250 = collection->klass;\n\tv331 = collection->klass->interface_offsets_count;\n\tv241 = *([v250 @ X8_v14 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]) == 0;\n\tif (v241) goto L_0066;\nL_0038:\n\tv134 = v134 + 1;\nL_FFFFFFFF:\n\tv182 = v183;\nL_010E:\n\tv583 = collection->klass;\n\tv616 = collection->klass->interface_offsets_count;\n\tv555 = *([v583 @ X8_v34 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]) == 0;\n\tif (v555) goto L_002E;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static void Replace<T>(this IList<T> collection, Func<T, bool> predicate, T newItem)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CollectionExtensions::Replace");
		}

		[Token(Token = "0x600000F")]
		[Address(RVA = "0x4847FEC", Offset = "0x4847FEC", Length = "0x47C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv33 = *([A4731E0]);\n\tgoto L_0019;\nL_0019:\n\tv38 = Il2CppClass<T>;\n\tv73 = *([v38 @ X0_v82 (Il2CppClass<T>)+FC]);\nL_FFFFFFFF:\n\tv76 = *([v38 @ X0_v82 (Il2CppClass<T>)+FC]);\n\tgoto L_0024;\n\tgoto L_0046;\n\tv210 = *([v181 @ X8_v55 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]) + 8;\n\tv210 = v210 + 0x10;\n\tv251 = v321 - 1;\n\tv241 = v321 != 1;\nL_FFFFFFFF:\n\tv321 = v251;\n\tif (v241) goto L_0051;\nL_006A:\n\tv477 = System.Collections.Generic.ICollection`1<T>::get_Count(collection);\nL_0075:\n\tgoto L_0079;\n\tv210 = *([v221 @ X8_v60 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]) + 8;\n\tv210 = v210 + 0x10;\n\tv657 = v215 - 1;\n\tv639 = v215 != 1;\nL_FFFFFFFF:\n\tv215 = v657;\n\tif (v639) goto L_0084;\nL_009D:\n\tv285 = System.Collections.Generic.ICollection`1<T>::get_Count(other);\n\tv261 = v477 != v285;\nL_FFFFFFFF:\n\tv351 = 0;\n\tif (v261) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv346 = 0;\n\tgoto L_00C7;\nL_00AC:\n\t;\n\tv809 = v917;\n\tv447 = 0x21C1F68(Il2CppClass<T>, *([v925 @ X8_v44 (Il2CppMethodRgctx<Unco.Extensions.CollectionExtensions::CompareContent>)+28]), v83, v95, &v809 @ stack_-78_v5, &v311 @ stack_-7C, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv346 = v346 + 1;\n\tv423 = v311 != 1;\nL_FFFFFFFF:\n\tv351 = v83;\n\tif (v423) goto L_01EA;\nL_00C7:\n\tgoto L_00CB;\n\tv381 = *([v570 @ X8_v27 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]) + 8;\n\tv381 = v381 + 0x10;\n\tv633 = v670 - 1;\n\tv615 = v670 != 1;\nL_FFFFFFFF:\n\tv670 = v633;\n\tif (v615) goto L_00D1;\nL_00ED:\n\t;\n\tv681 = System.Collections.Generic.ICollection`1<T>::get_Count(collection);\n\tv374 = v346 - v681;\n\tv371 = v374 < 0;\n\tv365 = v346 ^ v681;\n\tv362 = v346 ^ v374;\n\tv359 = v365 & v362;\n\tv356 = v359 < 0;\n\tv683 = v371 == v356;\n\tv353 = v346 < v681;\n\tif (v353) goto L_011B;\nL_FFFFFFFF:\n\treturnVal1 = v683;\n\tgoto L_01CB;\nL_00FF:\n\t;\n\tv332 = *([v381 @ X10_v25]) << 4;\n\tv698 = v570 + v332;\n\tv699 = v698 + 0x138;\n\t*([v699 @ X0_v52])(v701, collection, *([v699 @ X0_v52+8]), v351, v95, &v809 @ stack_-78_v5, &v311 @ stack_-7C, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\n\tv375 = v346 - v701;\n\tv372 = v375 < 0;\n\tv366 = v346 ^ v701;\n\tv363 = v346 ^ v375;\n\tv360 = v366 & v363;\n\tv357 = v360 < 0;\n\tv703 = v372 == v357;\n\tv354 = v346 >= v701;\nL_FFFFFFFF:\n\treturnVal1 = v703;\n\tif (v354) goto L_01CB;\nL_011B:\n\tgoto L_0120;\n\tv777 = *([v735 @ X8_v32 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]) + 8;\n\tv777 = v777 + 0x10;\n\tv763 = v778 - 1;\n\tv743 = v778 != 1;\nL_FFFFFFFF:\n\tv778 = v763;\n\tif (v743) goto L_0126;\nL_0140:\n\tv807 = 0x220C5E0(collection, Il2CppClass<System.Collections.Generic.IList`1<T>>, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0146;\nL_0142:\n\t;\n\tv790 = *([v777 @ X10_v20]) << 4;\n\tv791 = v735 + v790;\n\tv807 = v791 + 0x138;\n\tv877 = *([v835 @ X8_v38 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]) + 8;\n\tv877 = v877 + 0x10;\n\tv863 = v878 - 1;\n\tv843 = v878 != 1;\nL_FFFFFFFF:\n\tv878 = v863;\n\tif (v843) goto L_0165;\nL_017F:\n\tv904 = 0x220C5E0(other, Il2CppClass<System.Collections.Generic.IList`1<T>>, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0185;\nL_0181:\n\t;\n\tv890 = *([v877 @ X10_v15]) << 4;\n\tv891 = v835 + v890;\n\tv904 = v891 + 0x138;\n\tv47 = 0x220C2B8(v191, other, v191, v334, v340, v338, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\n\tv66 = Il2CppClass<T>;\n\tv73 = *([v66 @ X0_v79 (Il2CppClass<T>)+FC]);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv76 = *([v66 @ X0_v79 (Il2CppClass<T>)+FC]);\n\tgoto L_0024;\nL_01AB:\n\tv116 = *([v210 @ X10_v5]) << 4;\n\tv460 = v181 + v116;\n\tv461 = v460 + 0x138;\n\t*([v461 @ X0_v71])(v477, collection, *([v461 @ X0_v71+8]), v191, v334, v340, v338, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\n\tv463 = other == 0;\n\tv170 = ~v463;\nL_FFFFFFFF:\n\tv351 = v191;\n\tif (v170) goto L_0075;\n\tthrow System.NullReferenceException;\nL_01B7:\n\tv223 = *([v210 @ X10_v5]) << 4;\n\tv224 = v221 + v223;\n\tv225 = v224 + 0x138;\n\t*([v225 @ X0_v11])(v229, other, *([v225 @ X0_v11+8]), 0, v334, v340, v338, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\n\tv234 = v477 == v229;\n\tif (v234) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\treturnVal1 = 0;\nL_01E6:\n\treturn returnVal1;\nL_01EA:\n\tv929 = *([A4731E0]);\n\tv509 = *([v929 @ X9_v26]) == *([v33 @ X8_v2]);\nL_FFFFFFFF:\n\treturnVal1 = 0;\nL_FFFFFFFF:\n\tv561 = 0;\n\tif (v509) goto L_01E6;\nL_01F6:\n\treturnVal2 = 0x8BF5CF0(v561, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal2;\nL_0024:\n\tv78 = v76 + 0x10;\n\tv81 = v78 + 0xF;\n\tv82 = v81 & 0x1FFFFFFF0;\n\t// 40 StackAlloc v83 @ X8_v9 (System.Byte*), v82 @ X8_v8 (System.Int32)\n\tv87 = v73 + 0xF;\n\tv88 = v87 & 0x1FFFFFFF0;\n\t// 46 StackAlloc v89 @ X24_v1 (System.Byte*), v88 @ X9_v4 (System.Int32)\n\t// 49 StackAlloc v92 @ X25_v1 (System.Byte*), v88 @ X9_v4 (System.Int32)\n\t// 52 StackAlloc v95 @ X26_v1 (System.Byte*), v88 @ X9_v4 (System.Int32)\n\tv99 = 0x8BF5F18(v95, v73, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0046:\n\tv181 = collection->klass;\n\tv321 = collection->klass->interface_offsets_count;\n\tv183 = *([v181 @ X8_v55 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]) == 0;\n\tif (v183) goto L_006A;\nL_0051:\n\tv141 = *([v210 @ X10_v5-8]) == Il2CppClass<System.Collections.Generic.ICollection`1<T>>;\n\tif (v141) goto L_01AB;\nL_0079:\n\tv221 = other->klass;\n\tv215 = other->klass->interface_offsets_count;\n\tv219 = *([v221 @ X8_v60 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]) == 0;\n\tif (v219) goto L_009D;\nL_0084:\n\tv203 = *([v210 @ X10_v5-8]) == Il2CppClass<System.Collections.Generic.ICollection`1<T>>;\nL_FFFFFFFF:\n\tv351 = 0;\n\tif (v203) goto L_01B7;\nL_00CB:\n\tv570 = collection->klass;\n\tv670 = collection->klass->interface_offsets_count;\n\tv392 = *([v570 @ X8_v27 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]) == 0;\n\tif (v392) goto L_00ED;\nL_00D1:\n\t;\n\tv675 = *([v381 @ X10_v25-8]) == Il2CppClass<System.Collections.Generic.ICollection`1<T>>;\n\tif (v675) goto L_00FF;\nL_01CB:\n\tv398 = *([A4731E0]);\n\tv409 = *([v398 @ X9_v7]) != *([v33 @ X8_v2]);\nL_FFFFFFFF:\n\tv561 = returnVal1;\n\tif (v409) goto L_01F6;\nL_0120:\n\tv735 = collection->klass;\n\tv778 = collection->klass->interface_offsets_count;\n\tv737 = *([v735 @ X8_v32 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]) == 0;\n\tif (v737) goto L_0140;\nL_0126:\n\t;\n\tv783 = *([v777 @ X10_v20-8]) == Il2CppClass<System.Collections.Generic.IList`1<T>>;\n\tif (v783) goto L_0142;\nL_0146:\n\tv809 = &v311 @ stack_-7C;\n\tv810 = v89;\n\tv811 = *([v807 @ X0_v21+8]);\n\t*([v811 @ X1_v16+10])(v817, *([v811 @ X1_v16+8]), v811, collection, &v809 @ stack_-78_v5, v89, &v311 @ stack_-7C, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\n\tv821 = 0x8BF6A1C(v95, v89, v73, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_015F;\nL_015F:\n\tv835 = other->klass;\n\tv878 = other->klass->interface_offsets_count;\n\tv837 = *([v835 @ X8_v38 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+12E]) == 0;\n\tif (v837) goto L_017F;\nL_0165:\n\t;\n\tv883 = *([v877 @ X10_v15-8]) == Il2CppClass<System.Collections.Generic.IList`1<T>>;\n\tif (v883) goto L_0181;\nL_0185:\n\tv809 = &v311 @ stack_-7C;\n\tv410 = v92;\n\tv907 = *([v904 @ X0_v27+8]);\n\t*([v907 @ X1_v20+10])(v913, *([v907 @ X1_v20+8]), v907, other, &v809 @ stack_-78_v5, v92, &v311 @ stack_-7C, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\n\t// 401 Box v917 @ X0_v31, typeof(Il2CppClass<T>), v92 @ X25_v1 (System.Byte*)\nL_FFFFFFFF:\n\tv925 = Il2CppMethodRgctx<Unco.Extensions.CollectionExtensions::CompareContent>;\n\tgo\n// ... truncated")]
		public unsafe static bool CompareContent<T>(this IList<T> collection, IList<T> other)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CollectionExtensions::CompareContent");
			return default;
		}

		[Token(Token = "0x6000010")]
		[Address(RVA = "0x4848614", Offset = "0x4848614", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = 0x220C2B8(methodInfo, v38, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0016:\n\tv49 = Unco.Extensions.CollectionExtensions::FindIndex(v42, v38);\n\tv52 = v49 - -1;\n\tv54 = v52 == 0;\n\tv60 = ~v54;\n\treturn v60;\n")]
		public static bool Exists<T>(this IReadOnlyList<T> list, Func<T, bool> predicate)
		{
			IReadOnlyList<T> list2 = default(IReadOnlyList<T>);
			Func<T, bool> predicate2 = default(Func<T, bool>);
			int num = list2.FindIndex(predicate2);
			int num2 = num - -1;
			bool flag = num2 == 0;
			return !flag;
		}

		[Token(Token = "0x6000011")]
		[Address(RVA = "0x4849E60", Offset = "0x4849E60", Length = "0x2EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv33 = *([A4731E0]);\n\tv36 = element;\n\tgoto L_001A;\nL_001A:\n\tv39 = Il2CppClass<T>;\n\tv74 = *([v39 @ X0_v47 (Il2CppClass<T>)+FC]);\nL_FFFFFFFF:\n\tv77 = *([v39 @ X0_v47 (Il2CppClass<T>)+FC]);\n\tgoto L_0025;\nL_FFFFFFFF:\n\tv206 = Il2CppClass<System.Collections.Generic.IReadOnlyCollection`1<T>>;\nL_FFFFFFFF:\n\tv261 = 0;\n\tgoto L_0047;\n\tv310 = *([v213 @ X8_v17 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<T>>)+B0]) + 8;\n\tv310 = v310 + 0x10;\n\tv296 = v311 - 1;\n\tv276 = v311 != 1;\nL_FFFFFFFF:\n\tv311 = v296;\n\tif (v276) goto L_004D;\nL_0069:\n\t;\n\tv324 = System.Collections.Generic.IReadOnlyCollection`1<T>::get_Count(list);\n\tv335 = v261 < v324;\n\tif (v335) goto L_0093;\n\tgoto L_FFFFFFFF;\nL_0079:\n\t;\n\tv388 = *([v310 @ X10_v15]) << 4;\n\tv389 = v213 + v388;\n\tv390 = v389 + 0x138;\n\t*([v390 @ X0_v35])(v394, list, *([v390 @ X0_v35+8]), v84, v95, &v543 @ stack_-78_v4, &v542 @ stack_-7C_v5, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv404 = v261 >= v394;\n\tif (v404) goto L_FFFFFFFF;\nL_0093:\n\tgoto L_0098;\n\tv512 = *([v453 @ X8_v25 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<T>>)+B0]) + 8;\n\tv512 = v512 + 0x10;\n\tv498 = v513 - 1;\n\tv478 = v513 != 1;\nL_FFFFFFFF:\n\tv513 = v498;\n\tif (v478) goto L_009E;\nL_00B8:\n\tv539 = 0x220C5E0(list, Il2CppClass<System.Collections.Generic.IReadOnlyList`1<T>>, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_00BF;\nL_00BA:\n\t;\n\tv525 = *([v512 @ X10_v10]) << 4;\n\tv526 = v453 + v525;\n\tv539 = v526 + 0x138;\nL_FFFFFFFF:\n\tv563 = element;\n\tgoto L_00E3;\nL_FFFFFFFF:\n\tv563 = &v36 @ stack_-88_v1 (T);\n\tv261 = v261 + 1;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv206 = Il2CppClass<System.Collections.Generic.IReadOnlyCollection`1<T>>;\n\tgoto L_0047;\nL_FFFFFFFF:\n\tv261 = -1;\n\treturn v261;\n\tv48 = 0x220C2B8(v195, element, v195, v187, v186, v185, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv67 = Il2CppClass<T>;\n\tv74 = *([v67 @ X0_v44 (Il2CppClass<T>)+FC]);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv77 = *([v67 @ X0_v44 (Il2CppClass<T>)+FC]);\n\tgoto L_0025;\nL_0134:\n\treturnVal1 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal1;\nL_0025:\n\tv79 = v77 + 0x10;\n\tv82 = v79 + 0xF;\n\tv83 = v82 & 0x1FFFFFFF0;\n\t// 41 StackAlloc v84 @ X23_v1 (System.Byte*), v83 @ X8_v8 (System.Int32)\n\tv87 = v74 + 0xF;\n\tv88 = v87 & 0x1FFFFFFF0;\n\t// 46 StackAlloc v89 @ X24_v1 (System.Byte*), v88 @ X9_v4 (System.Int32)\n\t// 49 StackAlloc v92 @ X25_v1 (System.Byte*), v88 @ X9_v4 (System.Int32)\n\t// 52 StackAlloc v95 @ X27_v1 (System.Byte*), v88 @ X9_v4 (System.Int32)\n\tv99 = 0x8BF5F18(v95, v74, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0047:\n\tv213 = list->klass;\n\tv311 = list->klass->interface_offsets_count;\n\tv215 = *([v213 @ X8_v17 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<T>>)+12E]) == 0;\n\tif (v215) goto L_0069;\nL_004D:\n\t;\n\tv316 = *([v310 @ X10_v15-8]) == v206;\n\tif (v316) goto L_0079;\nL_0098:\n\tv453 = list->klass;\n\tv513 = list->klass->interface_offsets_count;\n\tv455 = *([v453 @ X8_v25 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<T>>)+12E]) == 0;\n\tif (v455) goto L_00B8;\nL_009E:\n\t;\n\tv518 = *([v512 @ X10_v10-8]) == Il2CppClass<System.Collections.Generic.IReadOnlyList`1<T>>;\n\tif (v518) goto L_00BA;\nL_00BF:\n\tv543 = &v542 @ stack_-7C_v5;\n\tv121 = v89;\n\tv544 = *([v539 @ X0_v13+8]);\n\t*([v544 @ X1_v10+10])(v550, *([v544 @ X1_v10+8]), v544, list, &v543 @ stack_-78_v4, v89, &v542 @ stack_-7C_v5, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv554 = 0x8BF6A1C(v95, v89, v74, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv556 = Il2CppClass<T>;\n\tv161 = *([v556 @ X8_v29 (Il2CppClass<T>)+28]) < 0;\n\tv152 = *([v556 @ X8_v29 (Il2CppClass<T>)+28]) ^ *([v556 @ X8_v29 (Il2CppClass<T>)+28]);\n\tv149 = *([v556 @ X8_v29 (Il2CppClass<T>)+28]) & v152;\n\tv146 = v149 < 0;\n\tv560 = v161 == v146;\n\tv143 = ~v560;\n\tv133 = ~v143;\n\tif (v133) goto L_FFFFFFFF;\nL_00E3:\n\tv566 = 0x8BF6A1C(v92, v563, v74, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t// 230 Box v569 @ X0_v21, typeof(Il2CppClass<T>), v92 @ X25_v1 (System.Byte*)\nL_FFFFFFFF:\n\tv578 = Il2CppMethodRgctx<Unco.Extensions.CollectionExtensions::IndexOf>;\n\tgoto L_00F2;\nL_00F2:\n\t;\n\tv543 = v569;\n\tv178 = 0x21C1F68(Il2CppClass<T>, *([v578 @ X8_v33 (Il2CppMethodRgctx<Unco.Extensions.CollectionExtensions::IndexOf>)+18]), v84, v95, &v543 @ stack_-78_v4, &v542 @ stack_-7C_v5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv580 = v542 & 1;\n\tv581 = v580 == 0;\n\tv467 = ~v581;\n\tif (v467) goto L_010A;\nL_010A:\n\tv471 = *([A4731E0]);\n\tv239 = *([v471 @ X9_v10]) != *([v33 @ X8_v2]);\n\tif (v239) goto L_0134;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static int IndexOf<T>(this IReadOnlyList<T> list, T element)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CollectionExtensions::IndexOf");
			return default;
		}

		[Token(Token = "0x6000012")]
		[Address(RVA = "0x4848E00", Offset = "0x4848E00", Length = "0x1B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv24 = 0x220C2B8(v168, predicate, v168, v53, v55, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_FFFFFFFF:\n\tv180 = Il2CppClass<System.Collections.Generic.IReadOnlyCollection`1<T>>;\nL_FFFFFFFF:\n\tv374 = 0;\n\tgoto L_001F;\n\tv280 = *([v185 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<T>>)+B0]) + 8;\n\tv280 = v280 + 0x10;\n\tv195 = v271 - 1;\n\tv193 = v271 != 1;\nL_FFFFFFFF:\n\tv271 = v195;\n\tif (v193) goto L_0025;\nL_0041:\n\t;\n\tv293 = System.Collections.Generic.IReadOnlyCollection`1<T>::get_Count(list);\n\tv304 = v374 < v293;\n\tif (v304) goto L_006B;\n\tgoto L_FFFFFFFF;\nL_0051:\n\t;\n\tv307 = *([v280 @ X10_v15]) << 4;\n\tv308 = v185 + v307;\n\tv309 = v308 + 0x138;\n\t*([v309 @ X0_v26])(v313, list, *([v309 @ X0_v26+8]), v412, predicate.method, v412, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv323 = v374 >= v313;\n\tif (v323) goto L_FFFFFFFF;\nL_006B:\n\tgoto L_006F;\n\tv106 = *([v370 @ X8_v14 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<T>>)+B0]) + 8;\n\tv106 = v106 + 0x10;\n\tv381 = v395 - 1;\n\tv380 = v395 != 1;\nL_FFFFFFFF:\n\tv395 = v381;\n\tif (v380) goto L_0075;\nL_0091:\n\t;\n\tv413 = System.Collections.Generic.IReadOnlyList`1<T>::get_Item(list, v374);\n\tv406 = predicate == 0;\n\tv116 = ~v406;\nL_FFFFFFFF:\n\tv412 = v374;\n\tif (v116) goto L_00AB;\n\tgoto L_00C3;\nL_0099:\n\t;\n\tv59 = *([v106 @ X10_v10]) << 4;\n\tv408 = v370 + v59;\n\tv409 = v408 + 0x138;\n\t*([v409 @ X0_v17])(v413, list, v374, *([v409 @ X0_v17+8]), predicate.method, v412, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_FFFFFFFF:\n\tv412 = v374;\nL_00AB:\n\tv159 = System.Func`2<T, System.Boolean>::Invoke(predicate, v413);\n\tv418 = v159 & 1;\n\tv419 = v418 == 0;\n\tv376 = ~v419;\n\tif (v376) goto L_00C2;\n\tv374 = v374 + 1;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv180 = Il2CppClass<System.Collections.Generic.IReadOnlyCollection`1<T>>;\n\tgoto L_001F;\nL_FFFFFFFF:\n\tv374 = -1;\nL_00C3:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\nL_001F:\n\tv185 = list->klass;\n\tv271 = list->klass->interface_offsets_count;\n\tv187 = *([v185 @ X8_v7 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<T>>)+12E]) == 0;\n\tif (v187) goto L_0041;\nL_0025:\n\t;\n\tv285 = *([v280 @ X10_v15-8]) == v180;\n\tif (v285) goto L_0051;\nL_006F:\n\tv370 = list->klass;\n\tv395 = list->klass->interface_offsets_count;\n\tv372 = *([v370 @ X8_v14 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<T>>)+12E]) == 0;\n\tif (v372) goto L_0091;\nL_0075:\n\t;\n\tv90 = *([v106 @ X10_v10-8]) == Il2CppClass<System.Collections.Generic.IReadOnlyList`1<T>>;\n\tif (v90) goto L_0099;\nL_00C2:\n\treturn v374;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int FindIndex<T>(this IReadOnlyList<T> list, Func<T, bool> predicate)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CollectionExtensions::FindIndex");
			return default;
		}

		[Token(Token = "0x6000013")]
		[Address(RVA = "0x4848670", Offset = "0x4848670", Length = "0x324")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tgoto L_001B;\n\tv40 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_001B:\n\tv109 = 0;\n\tgoto L_002C;\n\tgoto L_0086;\n\tv443 = v266 == 0;\n\tif (v443) goto L_0125;\n\tgoto L_009B;\n\tv304 = System.Func`2<T, System.Boolean>::Invoke(predicate, v656);\n\tv658 = v304 & 1;\n\tv306 = v658 == 0;\n\tif (v306) goto L_005A;\n\tv402 = &v109 @ stack_-38_v6 (System.Collections.IEnumerator);\n\tv405 = *([v402 @ X8_v34]);\n\tv659 = *([v402 @ X8_v34]) == 0;\n\tv399 = ~v659;\nL_FFFFFFFF:\n\tv359 = &v109 @ stack_-38_v6 (System.Collections.IEnumerator);\nL_FFFFFFFF:\n\tv63 = 0;\nL_FFFFFFFF:\n\tv363 = 4;\nL_FFFFFFFF:\n\tv403 = v656;\nL_FFFFFFFF:\n\tv408 = 0;\n\tif (v399) goto L_00E2;\nL_FFFFFFFF:\n\tv128 = &v109 @ stack_-38_v6 (System.Collections.IEnumerator);\nL_FFFFFFFF:\n\tv63 = 0;\nL_FFFFFFFF:\n\tv135 = 4;\nL_FFFFFFFF:\n\tv162 = v656;\nL_FFFFFFFF:\n\tv589 = v656;\nL_FFFFFFFF:\n\tv177 = 0;\n\tgoto L_0109;\nL_00D8:\n\tv401 = &v109 @ stack_-38_v6 (System.Collections.IEnumerator);\n\tv405 = *([v401 @ X8_v26]);\n\tv398 = *([v401 @ X8_v26]) == 0;\nL_FFFFFFFF:\n\tv359 = &v109 @ stack_-38_v6 (System.Collections.IEnumerator);\nL_FFFFFFFF:\n\tv63 = 0;\nL_FFFFFFFF:\n\tv363 = 5;\nL_FFFFFFFF:\n\tv403 = 0;\nL_FFFFFFFF:\n\tv408 = 0;\nL_FFFFFFFF:\n\tv128 = &v109 @ stack_-38_v6 (System.Collections.IEnumerator);\nL_FFFFFFFF:\n\tv63 = 0;\nL_FFFFFFFF:\n\tv135 = 5;\nL_FFFFFFFF:\n\tv162 = 0;\nL_FFFFFFFF:\n\tv589 = 0;\nL_FFFFFFFF:\n\tv177 = 0;\n\tif (v398) goto L_0109;\nL_00E2:\n\tgoto L_0108;\n\tv515 = v135 == 5;\n\tif (v515) goto L_FFFFFFFF;\n\tv570 = v135 == 0;\n\tv571 = ~v570;\n\tif (v571) goto L_0122;\nL_FFFFFFFF:\n\tv589 = 0;\nL_0123:\n\tv322 = new System.NullReferenceException();\n\tgoto L_0128;\nL_0125:\n\tv441 = new System.NullReferenceException();\n\tgoto L_0128;\nL_0128:\n\t// 296 Interrupt\nL_FFFFFFFF:\n\tv128 = &v109 @ stack_-38_v6 (System.Collections.IEnumerator);\nL_FFFFFFFF:\n\tv63 = 0;\nL_012B:\n\tv179 = new System.OutOfMemoryException();\n\tgoto L_013B;\nL_013B:\n\tv241 = v162 != 1;\n\tif (v241) goto L_014C;\n\tv270 = 0x8BF5BC4(v179, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv408 = *([v270 @ X0_v15]);\n\tv315 = 0x8BF5BF4(v270, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv405 = *([v128 @ stack_-40_v3]);\n\tv327 = *([v128 @ stack_-40_v3]) == 0;\n\tv328 = ~v327;\nL_FFFFFFFF:\n\tv359 = v128;\nL_FFFFFFFF:\n\tv63 = *([v270 @ X0_v15]);\nL_FFFFFFFF:\n\tv363 = 0;\nL_FFFFFFFF:\n\tv403 = 0;\n\tif (v328) goto L_00E2;\nL_FFFFFFFF:\n\tv63 = *([v270 @ X0_v15]);\nL_FFFFFFFF:\n\tv135 = 0;\nL_FFFFFFFF:\n\tv589 = 0;\nL_FFFFFFFF:\n\tv177 = *([v270 @ X0_v15]);\n\tgoto L_0109;\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\nL_002C:\n\tgoto L_0052;\nL_0052:\n\tv266 = System.Collections.Generic.IEnumerable`1<T>::GetEnumerator(list);\n\tv109 = v266;\nL_0086:\n\tv396 = System.Collections.IEnumerator::MoveNext(v266);\n\tv547 = v396 == 0;\n\tif (v547) goto L_00D8;\nL_009B:\n\tgoto L_00BF;\nL_00BF:\n\tv162 = 0;\n\tv656 = System.Collections.Generic.IEnumerator`1<T>::get_Current(v266);\nL_005A:\n\tv312 = v266 == 0;\n\tif (v312) goto L_0123;\nL_0109:\n\tv465 = v177 == 0;\n\tv169 = ~v465;\n\tif (v169) goto L_012B;\nL_0108:\n\tSystem.IDisposable::Dispose(v405);\nL_FFFFFFFF:\n\tv128 = v359;\nL_FFFFFFFF:\n\tv135 = v363;\nL_FFFFFFFF:\n\tv162 = 0;\nL_FFFFFFFF:\n\tv589 = v403;\nL_FFFFFFFF:\n\tv177 = v408;\nL_0122:\n\treturn v589;\nL_014C:\n\tv272 = 0x3175484(&v63 @ stack_-48_v2 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv317 = 0x8BF0368(v179, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = 0xA1B8(v317, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n")]
		public static T Find<T>(this IReadOnlyList<T> list, Func<T, bool> predicate)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CollectionExtensions::Find");
			return default;
		}

		[IteratorStateMachine(typeof(_003CBatch_003Ed__8<>))]
		[Token(Token = "0x6000014")]
		[Address(RVA = "0x48474E0", Offset = "0x48474E0", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv50 = Il2CppClass<Unco.Extensions.CollectionExtensions+<Batch>d__8`1<T>>;\n\tgoto L_0016;\nL_0016:\n\tv53 = new v50();\n\tv62 = Unco.Extensions.CollectionExtensions+<Batch>d__8`1<T>::.ctor(v53, -2);\n\t*([v53 @ X0_v5 (System.Collections.Generic.IEnumerable`1<System.Collections.Generic.IEnumerable`1<T>>)+30]) = source;\n\t*([v53 @ X0_v5 (System.Collections.Generic.IEnumerable`1<System.Collections.Generic.IEnumerable`1<T>>)+3C]) = batchSize;\n\treturn v53;\n\tv29 = 0x220C2B8(methodInfo, batchSize, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv50 = Il2CppClass<Unco.Extensions.CollectionExtensions+<Batch>d__8`1<T>>;\n\tgoto L_0016;\n")]
		public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> source, int batchSize)
		{
			nint num = 0;
			return new _003CBatch_003Ed__8<T>(-2);
		}

		[IteratorStateMachine(typeof(_003CYieldBatchElements_003Ed__9<>))]
		[Token(Token = "0x6000015")]
		[Address(RVA = "0x484AAE8", Offset = "0x484AAE8", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv54 = Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>;\n\tgoto L_0018;\nL_0018:\n\tv57 = new v54();\n\tv66 = Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>::.ctor(v57, -2);\n\tv69 = Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>;\n\tv70 = *([v69 @ X8_v9 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]);\n\tv71 = *([v69 @ X8_v9 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]) + 0x80;\n\tv73 = 0x815C(v71, 8, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv75 = *([v69 @ X8_v9 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]) + 0x80;\n\tv77 = 0x21C1054(v57, v75, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v77 @ X0_v11]) = source;\n\tv81 = 0x21C0FD4(*([v70 @ X23_v1+88]), v77, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv97 = Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>;\n\tv107 = *([v97 @ X8_v11 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]);\n\tv108 = *([v97 @ X8_v11 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]) + 0xC0;\n\tv110 = 0x815C(v108, 4, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv111 = *([v97 @ X8_v11 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]) + 0xC0;\n\tv113 = 0x21C1054(v57, v111, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v113 @ X0_v17]) = batchSize;\n\tv115 = 0x21C0FD4(*([v107 @ X20_v2+C8]), v113, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn v57;\n\tv33 = 0x220C2B8(methodInfo, batchSize, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv54 = Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>;\n\tgoto L_0018;\n")]
		private static IEnumerable<T> YieldBatchElements<T>(IEnumerator<T> source, int batchSize)
		{
			//IL_003a: Expected O, but got I
			//IL_0050: Expected O, but got I
			//IL_0075: Expected O, but got I
			//IL_00b6: Expected O, but got I
			//IL_00cc: Expected O, but got I
			//IL_00f6: Expected O, but got I
			//IL_010d: Expected O, but got I4
			nint num = 0;
			IEnumerable<T> result = new _003CYieldBatchElements_003Ed__9<T>(-2);
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X8_v9 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X8_v9 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]");
			object obj2 = (nint)0 + (nint)128;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @815C");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X8_v9 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]");
			object obj3 = (nint)0 + (nint)128;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1054");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C0FD4");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ X8_v11 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ X8_v11 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]");
			object obj5 = (nint)0 + (nint)192;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @815C");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ X8_v11 (Il2CppClass<Unco.Extensions.CollectionExtensions+<YieldBatchElements>d__9`1<T>>)+80]");
			object obj6 = (nint)0 + (nint)192;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1054");
			object obj7 = batchSize;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C0FD4");
			return result;
		}

		[IteratorStateMachine(typeof(_003CGetSelfAndChild_003Ed__10<>))]
		[Token(Token = "0x6000016")]
		[Address(RVA = "0x4849DC8", Offset = "0x4849DC8", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv49 = Il2CppClass<Unco.Extensions.CollectionExtensions+<GetSelfAndChild>d__10`1<T>>;\n\tgoto L_0015;\nL_0015:\n\tv52 = new v49();\n\tUnco.Extensions.CollectionExtensions+<GetSelfAndChild>d__10`1<T>::.ctor(v52, -2);\n\tv60 = v52 == 0;\n\tif (v60) goto L_0035;\n\t*([v52 @ X0_v5 (System.Collections.Generic.IEnumerable`1<T>)+30]) = c;\n\treturn v52;\n\tv27 = 0x220C2B8(methodInfo, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv49 = Il2CppClass<Unco.Extensions.CollectionExtensions+<GetSelfAndChild>d__10`1<T>>;\n\tgoto L_0015;\nL_0035:\n\tthrow v52;\n")]
		public static IEnumerable<T> GetSelfAndChild<T>(this GameObject c) where T : Component
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CollectionExtensions::GetSelfAndChild");
			return default;
		}

		[Token(Token = "0x6000017")]
		[Address(RVA = "0x4847BEC", Offset = "0x4847BEC", Length = "0x400")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv54 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__DisplayClass11_0`1<T>>;\n\tgoto L_0018;\nL_0018:\n\tv57 = new v54();\n\tv65 = Unco.Extensions.CollectionExtensions+<>c__DisplayClass11_0`1<T>::.ctor(v57);\n\tv57.chunkSize = chunkSize;\n\tv68 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>;\n\tv71 = *([v68 @ X0_v8 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>)+135]) & 1;\n\tv72 = v71 == 0;\n\tif (v72) goto L_0038;\n\tgoto L_002C;\nL_002C:\n\tv83 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>;\n\tv86 = *([v83 @ X0_v92 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>)+135]) & 1;\n\tv87 = v86 == 0;\nL_FFFFFFFF:\n\tv126 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>;\nL_FFFFFFFF:\n\tv137 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>;\n\tif (v87) goto L_0046;\nL_0032:\n\tv132 = *([v126 @ X0_v90 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>)+B8]);\n\tv163 = *([v132 @ X9_v39 (Il2CppStaticFields<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>)+8]);\n\tv134 = *([v132 @ X9_v39 (Il2CppStaticFields<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>)+8]) == 0;\n\tv135 = ~v134;\n\tif (v135) goto L_008C;\n\tgoto L_004D;\nL_0038:\n\tv76 = 0x220C238(Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv92 = *([v76 @ X0_v89+E4]) == 0;\n\tv79 = ~v92;\n\tif (v79) goto L_002C;\n\tv127 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>;\n\tv142 = *([v127 @ X0_v88 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>)+135]) & 1;\n\tv143 = v142 == 0;\n\tv129 = ~v143;\nL_FFFFFFFF:\n\tv126 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>;\nL_FFFFFFFF:\n\tv137 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>;\n\tif (v129) goto L_0032;\nL_0046:\n\tv140 = 0x220C238(v137, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv152 = *([v140 @ X0_v85+B8]);\n\tv163 = *([v152 @ X9_v35+8]);\n\tv179 = *([v152 @ X9_v35+8]) == 0;\n\tv159 = ~v179;\n\tif (v159) goto L_008C;\nL_004D:\n\tv185 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>;\n\tv188 = *([v185 @ X0_v59 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>)+135]) & 1;\n\tv189 = v188 == 0;\n\tif (v189) goto L_0129;\n\tgoto L_0057;\nL_0057:\n\tv222 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>;\n\tv225 = *([v222 @ X0_v83 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>)+135]) & 1;\n\tv226 = v225 == 0;\nL_FFFFFFFF:\n\tv252 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>;\n\tif (v226) goto L_0137;\nL_005E:\n\tv149 = v243.<>9;\nL_FFFFFFFF:\n\tv286 = Il2CppClass<System.Func`3<T, System.Int32, <>f__AnonymousType0`2<System.Int32, T>>>;\n\tgoto L_0067;\nL_0067:\n\tv289 = new v286();\n\tv316 = System.Func`3<T, System.Int32, <>f__AnonymousType0`2<System.Int32, T>>::.ctor(v289, v149, Il2CppMethodInfo);\nL_FFFFFFFF:\n\tv349 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>;\n\tgoto L_0078;\nL_0078:\n\tv350 = *([v349 @ X0_v71 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>)+B8]);\n\t*([v350 @ X8_v79 (Il2CppStaticFields<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>)+8]) = v289;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv163 = v289;\nL_0097:\n\tv192 = new Il2CppClass<System.Func`2<<>f__AnonymousType0`2<System.Int32, T>, System.Int32>>();\n\tv202 = System.Func`2<<>f__AnonymousType0`2<System.Int32, T>, System.Int32>::.ctor(v192, v57, Il2CppMethodInfo);\n\tv208 = System.Linq.Enumerable::GroupBy(v170, v192);\n\tv211 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>;\n\tv214 = *([v211 @ X0_v18 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>)+135]) & 1;\n\tv215 = v214 == 0;\n\tif (v215) goto L_00BD;\n\tgoto L_00B1;\nL_00B1:\n\tv265 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>;\n\tv268 = *([v265 @ X0_v56 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>)+135]) & 1;\n\tv269 = v268 == 0;\nL_FFFFFFFF:\n\tv295 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>;\nL_FFFFFFFF:\n\tv306 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>;\n\tif (v269) goto L_00CB;\nL_00B7:\n\tv301 = *([v295 @ X0_v54 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>)+B8]);\n\tv331 = *([v301 @ X9_v20 (Il2CppStaticFields<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>)+18]);\n\tv303 = *([v301 @ X9_v20 (Il2CppStaticFields<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>)+18]) == 0;\n\tv304 = ~v303;\n\tif (v304) goto L_0111;\n\tgoto L_00D2;\nL_00BD:\n\tv234 = 0x220C238(Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv274 = *([v234 @ X0_v53+E4]) == 0;\n\tv261 = ~v274;\n\tif (v261) goto L_00B1;\n\tv296 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>;\n\tv311 = *([v296 @ X0_v52 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>)+135]) & 1;\n\tv312 = v311 == 0;\n\tv298 = ~v312;\nL_FFFFFFFF:\n\tv295 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>;\nL_FFFFFFFF:\n\tv306 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>;\n\tif (v298) goto L_00B7;\nL_00CB:\n\tv309 = 0x220C238(v306, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv328 = *([v309 @ X0_v49+B8]);\n\tv331 = *([v328 @ X9_v16+18]);\n\tv347 = *([v328 @ X9_v16+18]) == 0;\n\tv337 = ~v347;\n\tif (v337) goto L_0111;\nL_00D2:\n\tv362 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>;\n\tv365 = *([v362 @ X0_v23 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>)+135]) & 1;\n\tv366 = v365 == 0;\n\tif (v366) goto L_0142;\n\tgoto L_00DC;\nL_00DC:\n\tv380 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>;\n\tv383 = *([v380 @ X0_v47 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>)+135]) & 1;\n\tv384 = v383 == 0;\nL_FFFFFFFF:\n\tv407 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>;\n\tif (v384) goto L_0150;\nL_00E3:\n\tv342 = v398.<>9;\nL_FFFFFFFF:\n\tv425 = Il2CppClass<System.Func`2<System.Linq.IGrouping`2<System.Int32, <>f__AnonymousType0`2<System.Int32, T>>, System.Collections.Generic.List`1<T>>>;\n\tgoto L_00EC;\nL_00EC:\n\tv428 = new v425();\n\tv435 = System.Func`2<System.Linq.IGrouping`2<System.Int32, <>f__AnonymousType0`2<System.Int32, T>>, System.Collections.Generic.List`1<T>>::.ctor(v428, v342, Il2CppMethodInfo);\nL_FFFFFFFF:\n\tv444 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>;\n\tgoto L_00FD;\nL_00FD:\n\tv445 = *([v444 @ X0_v35 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>)+B8]);\n\t*([v445 @ X8_v41 (Il2CppStaticFields<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>)+18]) = v428;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv331 = v428;\n\tv33 = System.Func`3<T, System.Int32, <>f__AnonymousType0`2<System.Int32, T>>::.ctor(methodInfo, chunkSize, methodInfo);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv54 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__DisplayClass11_0`1<T>>;\n\tgoto L_0018;\nL_0129:\n\tv195 = 0x220C238(Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv231 = *([v195 @ X0_v66+E4]) == 0;\n\tv218 = ~v231;\n\tif (v218) goto L_0057;\n\tv238 = Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>;\n\tv257 = *([v238 @ X0_v65 (Il2CppClass<Unco.Extensions.CollectionExtensions+<>c__11`1<T>>)+135]) & 1;\n\tv258 = v257 == 0;\n\tv\n// ... truncated")]
		public static List<List<T>> ChunkBy<T>(this IEnumerable<T> source, int chunkSize)
		{
			return source.Select((x, i) => new { Index = i, Value = x })
				.GroupBy(x => x.Index / chunkSize)
				.Select(x => x.Select(v => v.Value).ToList())
				.ToList();
		}

		[Token(Token = "0x6000018")]
		[Address(RVA = "0x4847584", Offset = "0x4847584", Length = "0x668")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv33 = *([A4731E0]);\n\tgoto L_002A;\n\tgoto L_002A;\n\tv56 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_004E:\n\tv105 = new Il2CppClass<System.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<TKey, TValue>>>();\n\tv111 = System.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<TKey, TValue>>::.ctor(v105);\n\tgoto L_0065;\nL_0097:\n\tv491 = v453 / subCount;\n\tv311 = System.Math::Ceiling(v491);\n\tv495 = v311 == 0x7FF0000000000000;\n\tv309 = ~v495;\n\tif (v309) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv307 = 0xFFFFFFFF80000000;\n\tgoto L_00B2;\nL_FFFFFFFF:\n\tv307 = v491;\nL_00B4:\n\tv520 = new Il2CppClass<System.Collections.Generic.Dictionary`2<TKey, TValue>>();\n\tv530 = System.Collections.Generic.Dictionary`2<TKey, TValue>::.ctor(v520);\n\tgoto L_00C8;\nL_FFFFFFFF:\n\tv410 = 0;\nL_FFFFFFFF:\n\tv578 = v760;\nL_FFFFFFFF:\n\tv426 = v520;\n\tv405 = v283 == 0;\n\tif (v405) goto L_0246;\n\tgoto L_0135;\n\tv980 = *([v937 @ X8_v71 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\n\tv980 = v980 + 0x10;\n\tv947 = v971 - 1;\n\tv945 = v971 != 1;\nL_FFFFFFFF:\n\tv971 = v947;\n\tif (v945) goto L_013B;\nL_0155:\n\tv1005 = 0x220C5E0(v283, Il2CppClass<System.Collections.Generic.IEnumerator`1<System.Collections.Generic.KeyValuePair`2<TKey, TValue>>>, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_015B;\nL_0157:\n\t;\n\tv992 = *([v980 @ X10_v23]) << 4;\n\tv993 = v937 + v992;\n\tv1005 = v993 + 0x138;\n\tv406 = v105 == 0;\n\tif (v406) goto L_0248;\n\tv1046 = Il2CppMethodInfo;\n\tv1020 = v426;\n\t*([v1046 @ X1_v32 (Il2CppMethodInfo)+10])(v1049, *([v1046 @ X1_v32 (Il2CppMethodInfo)]), Il2CppMethodInfo, v105, &v1020 @ stack_-78_v12 (System.Collections.Generic.Dictionary`2<TKey, TValue>), v426, v44, v45, v46, 0x7FF0000000000000, v311, v49, v50, v51, v52, v53, v54);\n\tgoto L_0186;\nL_0186:\n\tv1065 = new Il2CppClass<System.Collections.Generic.Dictionary`2<TKey, TValue>>();\n\tv1025 = System.Collections.Generic.Dictionary`2<TKey, TValue>::.ctor(v1065);\nL_FFFFFFFF:\n\tv410 = 0;\nL_FFFFFFFF:\n\tv425 = v1065;\n\tgoto L_01B1;\nL_01C0:\n\tv396 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv393 = Il2CppMethodInfo;\n\tgoto L_0251;\nL_01C4:\n\tv576 = &v283 @ stack_-90_v7 (System.Collections.IEnumerator);\n\tv544 = *([v576 @ X8_v67]);\n\tv572 = *([v576 @ X8_v67]) == 0;\nL_FFFFFFFF:\n\tv539 = &v283 @ stack_-90_v7 (System.Collections.IEnumerator);\nL_FFFFFFFF:\n\tv541 = v105;\nL_FFFFFFFF:\n\tv147 = 0;\nL_FFFFFFFF:\n\tv546 = v105;\nL_FFFFFFFF:\n\tv553 = v311;\nL_FFFFFFFF:\n\tv554 = 0x7FF0000000000000;\nL_FFFFFFFF:\n\tv573 = 5;\nL_FFFFFFFF:\n\tv579 = v426;\nL_FFFFFFFF:\n\tv275 = &v283 @ stack_-90_v7 (System.Collections.IEnumerator);\nL_FFFFFFFF:\n\tv281 = v105;\nL_FFFFFFFF:\n\tv147 = 0;\nL_FFFFFFFF:\n\tv151 = v105;\nL_FFFFFFFF:\n\tv310 = v311;\nL_FFFFFFFF:\n\tv312 = 0x7FF0000000000000;\nL_FFFFFFFF:\n\tv393 = 0;\nL_FFFFFFFF:\n\tv212 = 5;\nL_FFFFFFFF:\n\tv423 = v426;\n\tif (v572) goto L_01F6;\nL_01CE:\n\tgoto L_01F4;\n\tv677 = v212 == 5;\n\tif (v677) goto L_0206;\n\tv724 = v212 == 0;\n\tv725 = ~v724;\nL_FFFFFFFF:\n\tv783 = v147;\n\tif (v725) goto L_0227;\nL_0206:\n\tv727 = v423 == 0;\n\tif (v727) goto L_024E;\n\tv783 = System.Collections.Generic.Dictionary`2<TKey, TValue>::get_Count(v423);\n\tv325 = v783 <= 0;\nL_FFFFFFFF:\n\tv393 = Il2CppMethodInfo;\n\tif (v325) goto L_0227;\n\tv782 = Il2CppMethodInfo;\n\tv147 = v423;\n\t*([v782 @ X1_v7 (Il2CppMethodInfo)+10])(v783, *([v782 @ X1_v7 (Il2CppMethodInfo)]), Il2CppMethodInfo, v151, &v147 @ stack_-88_v1 (System.Int32), v423, v44, v45, v46, v312, v310, v49, v50, v51, v52, v53, v54);\nL_FFFFFFFF:\n\tv147 = v423;\nL_FFFFFFFF:\n\tv393 = Il2CppMethodInfo;\n\treturn v151;\nL_0244:\n\tv397 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv275 = &v283 @ stack_-90_v7 (System.Collections.IEnumerator);\nL_FFFFFFFF:\n\tv281 = v105;\nL_FFFFFFFF:\n\tv147 = 0;\nL_FFFFFFFF:\n\tv310 = v311;\nL_FFFFFFFF:\n\tv312 = 0x7FF0000000000000;\nL_FFFFFFFF:\n\tv393 = v389;\nL_FFFFFFFF:\n\tv394 = v396;\nL_FFFFFFFF:\n\tv423 = v424;\n\tgoto L_0251;\nL_0246:\n\tv398 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv275 = &v283 @ stack_-90_v7 (System.Collections.IEnumerator);\nL_FFFFFFFF:\n\tv281 = v105;\nL_FFFFFFFF:\n\tv147 = 0;\nL_FFFFFFFF:\n\tv310 = v311;\nL_FFFFFFFF:\n\tv312 = 0x7FF0000000000000;\nL_FFFFFFFF:\n\tv393 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv394 = v397;\nL_FFFFFFFF:\n\tv423 = v425;\n\tgoto L_0251;\nL_0248:\n\tv399 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv275 = &v283 @ stack_-90_v7 (System.Collections.IEnumerator);\nL_FFFFFFFF:\n\tv281 = v105;\nL_FFFFFFFF:\n\tv147 = 0;\nL_FFFFFFFF:\n\tv310 = v311;\nL_FFFFFFFF:\n\tv312 = 0x7FF0000000000000;\nL_FFFFFFFF:\n\tv393 = 0;\nL_FFFFFFFF:\n\tv394 = v398;\nL_FFFFFFFF:\n\tv423 = v426;\n\tgoto L_0251;\nL_024B:\n\tv221 = new System.OutOfMemoryException();\nL_FFFFFFFF:\n\tv275 = &v283 @ stack_-90_v7 (System.Collections.IEnumerator);\nL_FFFFFFFF:\n\tv281 = v105;\nL_FFFFFFFF:\n\tv147 = 0;\nL_FFFFFFFF:\n\tv310 = v311;\nL_FFFFFFFF:\n\tv312 = 0x7FF0000000000000;\nL_FFFFFFFF:\n\tv393 = v83;\nL_FFFFFFFF:\n\tv394 = v399;\nL_FFFFFFFF:\n\tv423 = v426;\n\tgoto L_0251;\nL_024D:\n\tv809 = 0x8BF5CF0(v783, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_024E:\n\tv400 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv275 = v134;\nL_FFFFFFFF:\n\tv281 = v140;\nL_FFFFFFFF:\n\tv310 = v164;\nL_FFFFFFFF:\n\tv312 = v166;\nL_FFFFFFFF:\n\tv393 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv394 = v221;\nL_FFFFFFFF:\n\tv423 = subCount;\n\tgoto L_0251;\nL_0251:\n\t// 593 Interrupt\nL_FFFFFFFF:\n\tv483 = v394;\nL_0268:\n\tv464 = v393 != 1;\n\tif (v464) goto L_0277;\n\tv506 = 0x8BF5BC4(v486, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv517 = 0x8BF5BF4(v506, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv544 = *([v275 @ stack_-80_v2]);\n\tv524 = *([v275 @ stack_-80_v2]) == 0;\n\tv525 = ~v524;\nL_FFFFFFFF:\n\tv539 = v275;\nL_FFFFFFFF:\n\tv541 = v281;\nL_FFFFFFFF:\n\tv147 = *([v506 @ X0_v26]);\nL_FFFFFFFF:\n\tv546 = v281;\nL_FFFFFFFF:\n\tv553 = v310;\nL_FFFFFFFF:\n\tv554 = v312;\nL_FFFFFFFF:\n\tv573 = 0;\nL_FFFFFFFF:\n\tv579 = v423;\n\tif (v525) goto L_01CE;\nL_FFFFFFFF:\n\tv147 = *([v506 @ X0_v26]);\nL_FFFFFFFF:\n\tv151 = v281;\nL_FFFFFFFF:\n\tv212 = 0;\n\tgoto L_01F6;\nL_0277:\n\tv482 = 0x3175484(&v147 @ stack_-88_v1 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv483 = v486;\n\tgoto L_0254;\nL_002A:\n\tv63 = Il2CppClass<System.Collections.Generic.KeyValuePair`2<TKey, TValue>>;\n\tv65 = Il2CppClass<TKey>;\n\tv69 = *([v65 @ X8_v5 (Il2CppClass<TKey>)+FC]) + 0xF;\n\tv70 = v69 & 0x1FFFFFFF0;\n\t// 49 StackAlloc v71 @ X23_v1 (System.Byte*), v70 @ X8_v8 (System.Int32)\n\tv73 = Il2CppClass<TValue>;\n\tv76 = *([v73 @ X8_v9 (Il2CppClass<TValue>)+FC]) + 0xF;\n\tv77 = v76 & 0x1FFFFFFF0;\n\t// 56 StackAlloc v78 @ X24_v1 (System.Byte*), v77 @ X8_v12 (System.Int32)\n\tv81 = *([v63 @ X8_v4 (Il2CppClass<System.Collections.Generic.KeyValuePair`2<TKey, TValue>>)+FC]) + 0xF;\n\tv82 = v81 & 0x1FFFFFFF0;\n\t// 61 StackAlloc v83 @ X25_v1 (System.Byte*), v82 @ X9_v4 (System.Int32)\n\t// 65 StackAlloc v87 @ X26_v1 (System.Byte*), v82 @ X9_v4 (System.Int32)\n\tv91 = 0x8BF5F18(v87, *([v63 @ X8_v4 (Il2CppClass<System.Collections.Generic.KeyValuePair`2<TKey, TValue>>)+FC]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_004E;\nL_0065:\n\tgoto L_008B;\nL_008B:\n\tv453 = System.Collections.Generic.ICollectio\n// ... truncated")]
		public unsafe static List<Dictionary<TKey, TValue>> Chunk<TKey, TValue>(this IDictionary<TKey, TValue> original, int subCount)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CollectionExtensions::Chunk");
			return default;
		}

		[Token(Token = "0x6000019")]
		[Address(RVA = "0x484A14C", Offset = "0x484A14C", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_000A;\nL_000A:\n\tv15 = list == 0;\n\tif (v15) goto L_0046;\nL_0013:\n\tgoto L_001A;\n\tv18 = 0x220C2B8(methodInfo, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv55 = list == 0;\n\tv38 = ~v55;\n\tif (v38) goto L_0013;\nL_0046:\n\treturn 1;\nL_001A:\n\tgoto L_004E;\nL_004E:\n\tv186 = System.Collections.Generic.IReadOnlyCollection`1<T>::get_Count(list);\n\tv96 = v186 == 0;\n\treturn v96;\n")]
		public static bool IsNullOrEmpty<T>(this IReadOnlyCollection<T> list)
		{
			//IL_006e: Expected O, but got I4
			if (list == null)
			{
				return true;
			}
			object obj = list.Count;
			return obj == null;
		}

		[Token(Token = "0x600001A")]
		[Address(RVA = "0x4849388", Offset = "0x4849388", Length = "0x2E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tgoto L_0026;\n\tv44 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0026:\n\tgoto L_002D;\n\tgoto L_0087;\n\tv435 = v269 == 0;\n\tif (v435) goto L_010D;\n\tgoto L_009C;\n\tSystem.Action`1<T>::Invoke(action, v637);\n\tv170 = v637;\n\tgoto L_005B;\nL_00CC:\n\tv400 = &v61 @ stack_-48_v5 (System.Collections.IEnumerator);\n\tv401 = *([v400 @ X8_v26]);\n\tv398 = *([v400 @ X8_v26]) == 0;\n\tv361 = &v61 @ stack_-48_v5 (System.Collections.IEnumerator);\n\tv69 = 0;\n\tv403 = 0;\n\tv134 = &v61 @ stack_-48_v5 (System.Collections.IEnumerator);\n\tv69 = 0;\n\tv170 = 0;\n\tv181 = 0;\n\tif (v398) goto L_00FD;\nL_00D6:\n\tgoto L_00FC;\n\treturn source;\nL_010B:\n\tv325 = new System.NullReferenceException();\n\tgoto L_0110;\nL_010D:\n\tv434 = new System.NullReferenceException();\n\tgoto L_0110;\nL_0110:\n\t// 272 Interrupt\n\tv134 = &v61 @ stack_-48_v5 (System.Collections.IEnumerator);\n\tv69 = 0;\nL_0113:\n\tv183 = new System.OutOfMemoryException();\n\tgoto L_0122;\nL_0122:\n\tv244 = v170 != 1;\n\tif (v244) goto L_0130;\n\tv272 = 0x8BF5BC4(v183, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv403 = *([v272 @ X0_v14]);\n\tv318 = 0x8BF5BF4(v272, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv401 = *([v134 @ stack_-50_v3]);\n\tv328 = *([v134 @ stack_-50_v3]) == 0;\n\tv329 = ~v328;\n\tv361 = v134;\n\tv69 = *([v272 @ X0_v14]);\n\tif (v329) goto L_00D6;\n\tv69 = *([v272 @ X0_v14]);\n\tv181 = *([v272 @ X0_v14]);\n\tgoto L_00FD;\nL_0130:\n\tv275 = 0x3175484(&v69 @ stack_-58_v2 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv320 = 0x8BF0368(v183, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = 0xA1B8(v320, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\nL_002D:\n\tgoto L_0051;\nL_0051:\n\tv170 = 0;\n\tv269 = System.Collections.Generic.IEnumerable`1<T>::GetEnumerator(source);\n\tv61 = v269;\nL_0087:\n\tv396 = System.Collections.IEnumerator::MoveNext(v269);\n\tv533 = v396 == 0;\n\tif (v533) goto L_00CC;\nL_009C:\n\tgoto L_00C2;\nL_00C2:\n\tv637 = System.Collections.Generic.IEnumerator`1<T>::get_Current(v269);\nL_005B:\n\tv315 = v269 == 0;\n\tif (v315) goto L_010B;\nL_00FD:\n\tv456 = v181 == 0;\n\tv175 = ~v456;\n\tif (v175) goto L_0113;\nL_00FC:\n\tSystem.IDisposable::Dispose(v401);\n\tv134 = v361;\n\tv170 = 0;\n\tv181 = v403;\n")]
		public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CollectionExtensions::ForEach");
			return default;
		}

		[Token(Token = "0x600001B")]
		[Address(RVA = "0x4849A0C", Offset = "0x4849A0C", Length = "0x3BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv33 = *([A4731E0]);\n\tgoto L_0027;\n\tgoto L_0027;\n\tv56 = 0x220C2B8(methodInfo, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0041;\n\tv244 = 0;\n\tv456 = v409;\n\tv311 = v409 == 0;\n\tif (v311) goto L_0153;\n\tgoto L_00AF;\n\tv732 = *([v623 @ X8_v34 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\n\tv732 = v732 + 0x10;\n\tv665 = v723 - 1;\n\tv663 = v723 != 1;\n\tv723 = v665;\n\tif (v663) goto L_00B5;\nL_00CF:\n\tv756 = 0x220C5E0(v409, Il2CppClass<System.Collections.Generic.IEnumerator`1<T>>, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_00D5;\nL_00D1:\n\t;\n\tv752 = *([v732 @ X10_v23]) << 4;\n\tv753 = v623 + v752;\n\tv756 = v753 + 0x138;\n\tgoto L_00EC;\nL_00FB:\n\tv305 = new System.NullReferenceException();\n\tv345 = &v233 @ stack_-88_v7 (System.Collections.IEnumerator);\n\tv234 = 0;\n\tv376 = v301;\n\tgoto L_0158;\nL_00FE:\n\tv546 = &v233 @ stack_-88_v7 (System.Collections.IEnumerator);\n\tv591 = *([v546 @ X8_v30]);\n\tv548 = *([v546 @ X8_v30]) == 0;\n\tv565 = &v233 @ stack_-88_v7 (System.Collections.IEnumerator);\n\tv234 = 0;\n\tv590 = source;\n\tv592 = 0;\n\tv345 = &v233 @ stack_-88_v7 (System.Collections.IEnumerator);\n\tv234 = 0;\n\tv376 = 0;\n\tv171 = source;\n\tv175 = 0;\n\tif (v548) goto L_012F;\nL_0108:\n\tgoto L_012E;\n\tv656 = *([A4731E0]);\n\tv356 = *([v656 @ X9_v7]) != *([v33 @ X8_v2]);\n\tif (v356) goto L_0159;\n\treturn v171;\nL_0151:\n\tv306 = new System.NullReferenceException();\n\tv345 = &v233 @ stack_-88_v7 (System.Collections.IEnumerator);\n\tv234 = 0;\n\tv376 = v69;\n\tgoto L_0158;\nL_0153:\n\tv307 = new System.NullReferenceException();\n\tv345 = &v233 @ stack_-88_v7 (System.Collections.IEnumerator);\n\tv234 = 0;\n\tv376 = 0;\n\tgoto L_0158;\nL_0157:\n\tv177 = new System.OutOfMemoryException();\n\tv345 = v107;\n\tv376 = v162;\nL_0158:\n\t// 344 Interrupt\nL_016B:\n\tv432 = v376 != 1;\n\tif (v432) goto L_0179;\n\tv529 = 0x8BF5BC4(v454, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv592 = *([v529 @ X0_v9]);\n\tv544 = 0x8BF5BF4(v529, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv591 = *([v345 @ stack_-90_v1]);\n\tv551 = *([v345 @ stack_-90_v1]) == 0;\n\tv552 = ~v551;\n\tv565 = v345;\n\tv234 = *([v529 @ X0_v9]);\n\tif (v552) goto L_0108;\n\tv234 = *([v529 @ X0_v9]);\n\tv171 = v590;\n\tv175 = *([v529 @ X0_v9]);\n\tgoto L_012F;\nL_0179:\n\tv450 = 0x3175484(&v234 @ stack_-98_v4 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv590 = v454;\n\tgoto L_015C;\nL_0027:\n\tv63 = Il2CppClass<T>;\n\tv67 = *([v63 @ X9_v1 (Il2CppClass<T>)+FC]) + 0xF;\n\tv68 = v67 & 0x1FFFFFFF0;\n\t// 44 StackAlloc v69 @ X23_v1 (System.Byte*), v68 @ X10_v2 (System.Int32)\n\t// 47 StackAlloc v72 @ X24_v1 (System.Byte*), v68 @ X10_v2 (System.Int32)\n\tv233 = 0;\nL_0041:\n\tgoto L_0065;\nL_0065:\n\tv301 = 0;\n\tv409 = System.Collections.Generic.IEnumerable`1<T>::GetEnumerator(source);\n\tv233 = v409;\n\tv411 = v409 == 0;\n\tif (v411) goto L_00FB;\nL_009D:\n\tv539 = System.Collections.IEnumerator::MoveNext(v456);\n\tv541 = v539 == 0;\n\tif (v541) goto L_00FE;\nL_00AF:\n\tv623 = *([v409 @ X0_v28 (System.Collections.IEnumerator)]);\n\tv723 = *([v623 @ X8_v34 (Il2CppClass<System.Collections.IEnumerator>)+12E]);\n\tv625 = *([v623 @ X8_v34 (Il2CppClass<System.Collections.IEnumerator>)+12E]) == 0;\n\tif (v625) goto L_00CF;\nL_00B5:\n\t;\n\tv737 = *([v732 @ X10_v23-8]) == Il2CppClass<System.Collections.Generic.IEnumerator`1<T>>;\n\tif (v737) goto L_00D1;\nL_00D5:\n\tv224 = v69;\n\tv758 = *([v756 @ X0_v37+8]);\n\t*([v758 @ X1_v17+10])(v761, *([v758 @ X1_v17+8]), v758, v409, &v224 @ stack_-78_v8 (System.Byte*), v69, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv763 = 0x8BF6A1C(v72, v69, *([v63 @ X9_v1 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv310 = v162 == 0;\n\tif (v310) goto L_0151;\nL_00EC:\n\tv426 = Il2CppMethodInfo;\n\tv417 = v244;\n\tv420 = v72;\n\tv416 = &v417 @ stack_-7C_v8 (System.Int32);\n\t*([v426 @ X1_v19 (Il2CppMethodInfo)+10])(v428, *([v426 @ X1_v19 (Il2CppMethodInfo)]), Il2CppMethodInfo, v162, &v420 @ stack_-78_v9 (System.IntPtr), &v417 @ stack_-7C_v8 (System.Int32), v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv244 = v244 + 1;\n\tv772 = v409 == 0;\n\tv429 = ~v772;\n\tv301 = Il2CppMethodInfo;\n\tv456 = v409;\n\tif (v429) goto L_0077;\nL_012F:\n\tv617 = v175 == 0;\n\tv167 = ~v617;\n\tif (v167) goto L_0157;\nL_012E:\n\tSystem.IDisposable::Dispose(v591);\n\tv345 = v565;\n\tv376 = 0;\n\tv171 = v590;\n\tv175 = v592;\nL_0159:\n\tv384 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv590 = v384;\nL_015C:\n\tv454 = 0x8BF0368(v590, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_016B;\nL_0077:\n\tgoto L_009D;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CollectionExtensions::ForEach");
			return default;
		}

		[IteratorStateMachine(typeof(_003CTraverse_003Ed__16<>))]
		[Token(Token = "0x600001C")]
		[Address(RVA = "0x484A9E0", Offset = "0x484A9E0", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv54 = Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>;\n\tgoto L_0018;\nL_0018:\n\tv57 = new v54();\n\tv66 = Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>::.ctor(v57, -2);\n\tv69 = Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>;\n\tv70 = *([v69 @ X8_v9 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]);\n\tv71 = *([v69 @ X8_v9 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]) + 0x80;\n\tv73 = 0x815C(v71, 8, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv75 = *([v69 @ X8_v9 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]) + 0x80;\n\tv77 = 0x21C1054(v57, v75, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v77 @ X0_v11]) = source;\n\tv81 = 0x21C0FD4(*([v70 @ X23_v1+88]), v77, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv97 = Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>;\n\tv107 = *([v97 @ X8_v11 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]);\n\tv108 = *([v97 @ X8_v11 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]) + 0xC0;\n\tv110 = 0x815C(v108, 8, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv111 = *([v97 @ X8_v11 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]) + 0xC0;\n\tv113 = 0x21C1054(v57, v111, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v113 @ X0_v17]) = childSelector;\n\tv115 = 0x21C0FD4(*([v107 @ X20_v2+C8]), v113, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn v57;\n\tv33 = 0x220C2B8(methodInfo, childSelector, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv54 = Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>;\n\tgoto L_0018;\n")]
		public static IEnumerable<T> Traverse<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> childSelector)
		{
			//IL_003a: Expected O, but got I
			//IL_0050: Expected O, but got I
			//IL_0075: Expected O, but got I
			//IL_00b6: Expected O, but got I
			//IL_00cc: Expected O, but got I
			//IL_00f6: Expected O, but got I
			nint num = 0;
			IEnumerable<T> result = new _003CTraverse_003Ed__16<T>(-2);
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X8_v9 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X8_v9 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]");
			object obj2 = (nint)0 + (nint)128;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @815C");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X8_v9 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]");
			object obj3 = (nint)0 + (nint)128;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1054");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C0FD4");
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ X8_v11 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ X8_v11 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]");
			object obj5 = (nint)0 + (nint)192;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @815C");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ X8_v11 (Il2CppClass<Unco.Extensions.CollectionExtensions+<Traverse>d__16`1<T>>)+80]");
			object obj6 = (nint)0 + (nint)192;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1054");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C0FD4");
			return result;
		}
	}
}
