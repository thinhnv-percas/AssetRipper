using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.Utils
{
	[Serializable]
	[Token(Token = "0x2000007")]
	public struct PairReference<T, TK>
	{
		[Token(Token = "0x4000015")]
		[FieldOffset(Offset = "0x0")]
		public T Key;

		[SerializeReference]
		[Token(Token = "0x4000016")]
		[FieldOffset(Offset = "0x0")]
		public TK Value;

		[Token(Token = "0x600000F")]
		[Address(RVA = "0x5EA17C8", Offset = "0x5EA17C8", Length = "0x204")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv35 = *([A4731E0]);\n\tv38 = valueC;\n\tv39 = v139;\n\tv40 = Il2CppClass<Unco.Utils.PairReference`2>;\n\tv97 = *([v40 @ X24_v1 (Il2CppClass<Unco.Utils.PairReference`2>)+135]);\n\tv43 = *([v40 @ X24_v1 (Il2CppClass<Unco.Utils.PairReference`2>)+135]) & 1;\n\tv44 = v43 == 0;\n\tv45 = ~v44;\n\tif (v45) goto L_002E;\n\tv47 = 0x220C238(Il2CppClass<Unco.Utils.PairReference`2>, v139, valueC, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv66 = Il2CppClass<Unco.Utils.PairReference`2>;\n\tv97 = *([v66 @ X24_v17 (Il2CppClass<Unco.Utils.PairReference`2>)+135]);\n\tv69 = *([v47 @ X0_v32+C0]);\n\tv70 = *([v69 @ X9_v13]);\n\tv92 = *([v70 @ X9_v14+FC]);\n\tv72 = *([v66 @ X24_v17 (Il2CppClass<Unco.Utils.PairReference`2>)+135]) & 1;\n\tv73 = v72 == 0;\nL_FFFFFFFF:\n\tv96 = Il2CppClass<Unco.Utils.PairReference`2>;\nL_FFFFFFFF:\n\tv74 = *([v70 @ X9_v14+FC]);\nL_FFFFFFFF:\n\tv78 = Il2CppClass<Unco.Utils.PairReference`2>;\n\tif (v73) goto L_0035;\nL_002C:\n\tgoto L_003A;\nL_002E:\n\tv61 = Il2CppClass<T>;\n\tv92 = *([v61 @ X9_v11 (Il2CppClass<T>)+FC]);\n\tv63 = *([v40 @ X24_v1 (Il2CppClass<Unco.Utils.PairReference`2>)+135]) & 1;\n\tv64 = v63 == 0;\n\tv65 = ~v64;\nL_FFFFFFFF:\n\tv96 = Il2CppClass<Unco.Utils.PairReference`2>;\nL_FFFFFFFF:\n\tv74 = *([v61 @ X9_v11 (Il2CppClass<T>)+FC]);\nL_FFFFFFFF:\n\tv78 = Il2CppClass<Unco.Utils.PairReference`2>;\n\tif (v65) goto L_002C;\nL_0035:\n\tv81 = 0x220C238(v78, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv89 = Il2CppClass<Unco.Utils.PairReference`2>;\n\tv97 = *([v89 @ X24_v15 (Il2CppClass<Unco.Utils.PairReference`2>)+135]);\nL_FFFFFFFF:\n\tv92 = v74;\nL_FFFFFFFF:\n\tv96 = Il2CppClass<Unco.Utils.PairReference`2>;\n\tv116 = 0x220C238(v96, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0050;\n\tgoto L_0066;\nL_FFFFFFFF:\n\tv194 = valueC;\n\tgoto L_009C;\nL_FFFFFFFF:\n\tv194 = &v38 @ stack_-78_v1 (TK);\n\tv202 = 0x220C238(Il2CppClass<Unco.Utils.PairReference`2>, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_00CA:\n\tv240 = 0x8BF5CF0(v213, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_003A:\n\tv99 = Il2CppClass<TK>;\n\tv103 = v92 + 0xF;\n\tv104 = v103 & 0x1FFFFFFF0;\n\t// 63 StackAlloc v105 @ X27_v1 (System.Byte*), v104 @ X10_v2 (System.Int32)\n\tv108 = *([v99 @ X9_v3 (Il2CppClass<TK>)+FC]) + 0xF;\n\tv109 = v108 & 0x1FFFFFFF0;\n\t// 68 StackAlloc v110 @ X23_v1 (System.Byte*), v109 @ X10_v4 (System.Int32)\n\tv112 = v97 & 1;\n\tv113 = v112 == 0;\n\tv114 = ~v113;\n\tif (v114) goto L_0050;\nL_0050:\n\tv122 = Il2CppClass<T>;\n\tv127 = *([v122 @ X8_v8 (Il2CppClass<T>)+28]) < 0;\n\tv130 = *([v122 @ X8_v8 (Il2CppClass<T>)+28]) ^ *([v122 @ X8_v8 (Il2CppClass<T>)+28]);\n\tv131 = *([v122 @ X8_v8 (Il2CppClass<T>)+28]) & v130;\n\tv132 = v131 < 0;\n\tv134 = v127 == v132;\n\tv135 = ~v134;\n\tv136 = ~v135;\n\tif (v136) goto L_0066;\nL_0066:\n\tv142 = 0x8BF6A1C(v105, &v39 @ stack_-70_v1 (T), v92, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0071;\nL_0071:\n\tv154 = Il2CppClass<Unco.Utils.PairReference`2<T, TK>>;\n\tv159 = 0x21C1058(this, *([v154 @ X8_v14 (Il2CppClass<Unco.Utils.PairReference`2<T, TK>>)+80]), v105, v92, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv160 = Il2CppClass<Unco.Utils.PairReference`2>;\n\tgoto L_0086;\nL_0086:\n\tv177 = Il2CppClass<TK>;\n\tv182 = *([v177 @ X8_v18 (Il2CppClass<TK>)+28]) < 0;\n\tv185 = *([v177 @ X8_v18 (Il2CppClass<TK>)+28]) ^ *([v177 @ X8_v18 (Il2CppClass<TK>)+28]);\n\tv186 = *([v177 @ X8_v18 (Il2CppClass<TK>)+28]) & v185;\n\tv187 = v186 < 0;\n\tv189 = v182 == v187;\n\tv190 = ~v189;\n\tv191 = ~v190;\n\tif (v191) goto L_FFFFFFFF;\nL_009C:\n\tv197 = 0x8BF6A1C(v110, v194, *([v99 @ X9_v3 (Il2CppClass<TK>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv198 = *([v160 @ X24_v5 (Il2CppClass<Unco.Utils.PairReference`2>)+135]) & 1;\n\tv199 = v198 == 0;\n\tv200 = ~v199;\n\tif (v200) goto L_00A5;\nL_00A5:\n\tv207 = Il2CppClass<Unco.Utils.PairReference`2<T, TK>>;\n\tv209 = *([v207 @ X8_v22 (Il2CppClass<Unco.Utils.PairReference`2<T, TK>>)+80]) + 0x20;\n\tv213 = 0x21C1058(this, v209, v110, *([v99 @ X9_v3 (Il2CppClass<TK>)+FC]), clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv216 = *([A4731E0]);\n\tv227 = *([v216 @ X9_v7]) != *([v35 @ X8_v2]);\n\tif (v227) goto L_00CA;\n")]
		public unsafe PairReference(T keyC, TK valueC)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PairReference::.ctor");
			this = default;
		}

		[Token(Token = "0x6000010")]
		[Address(RVA = "0x5EA19CC", Offset = "0x5EA19CC", Length = "0x210")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv35 = *([A4731E0]);\n\tv38 = Il2CppClass<Unco.Utils.PairReference`2>;\n\tv90 = *([v38 @ X0_v1 (Il2CppClass<Unco.Utils.PairReference`2>)+135]);\n\tv41 = *([v38 @ X0_v1 (Il2CppClass<Unco.Utils.PairReference`2>)+135]) & 1;\n\tv42 = v41 == 0;\n\tv43 = ~v42;\n\tif (v43) goto L_002C;\n\tv44 = 0x220C238(Il2CppClass<Unco.Utils.PairReference`2>, key, value, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv64 = Il2CppClass<Unco.Utils.PairReference`2>;\n\tv90 = *([v64 @ X0_v41 (Il2CppClass<Unco.Utils.PairReference`2>)+135]);\n\tv67 = *([v44 @ X0_v40+C0]);\n\tv68 = *([v67 @ X8_v35]);\n\tv88 = *([v68 @ X8_v36+FC]);\n\tv70 = *([v64 @ X0_v41 (Il2CppClass<Unco.Utils.PairReference`2>)+135]) & 1;\n\tv71 = v70 == 0;\n\tv91 = Il2CppClass<Unco.Utils.PairReference`2>;\n\tv72 = *([v68 @ X8_v36+FC]);\n\tv75 = Il2CppClass<Unco.Utils.PairReference`2>;\n\tif (v71) goto L_0032;\nL_002A:\n\tgoto L_0038;\nL_002C:\n\tv58 = Il2CppClass<T>;\n\tv88 = *([v58 @ X8_v31 (Il2CppClass<T>)+FC]);\n\tv60 = *([v38 @ X0_v1 (Il2CppClass<Unco.Utils.PairReference`2>)+135]) & 1;\n\tv61 = v60 == 0;\n\tv62 = ~v61;\n\tv91 = Il2CppClass<Unco.Utils.PairReference`2>;\n\tv72 = *([v58 @ X8_v31 (Il2CppClass<T>)+FC]);\n\tv75 = Il2CppClass<Unco.Utils.PairReference`2>;\n\tif (v62) goto L_002A;\nL_0032:\n\tv77 = 0x220C238(v75, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv85 = Il2CppClass<Unco.Utils.PairReference`2>;\n\tv90 = *([v85 @ X0_v38 (Il2CppClass<Unco.Utils.PairReference`2>)+135]);\n\tv88 = v72;\n\tv91 = Il2CppClass<Unco.Utils.PairReference`2>;\n\tv110 = 0x220C238(v91, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_004A:\n\tv113 = Il2CppClass<Unco.Utils.PairReference`2<T, TK>>;\n\tv116 = 0x21C1054(this, *([v113 @ X8_v11 (Il2CppClass<Unco.Utils.PairReference`2<T, TK>>)+80]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv121 = 0x8BF6A1C(v100, v116, v88, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv125 = 0x8BF6A34(key, v116, v88, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0066;\nL_0066:\n\tgoto L_006A;\nL_006A:\n\tv145 = 0x21C0FD4(Il2CppClass<T>, key, v100, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0074;\nL_0074:\n\tv155 = Il2CppClass<Unco.Utils.PairReference`2<T, TK>>;\n\tv157 = *([v155 @ X8_v20 (Il2CppClass<Unco.Utils.PairReference`2<T, TK>>)+80]) + 0x20;\n\tv159 = 0x21C1054(this, v157, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv164 = 0x8BF6A1C(v105, v159, *([v94 @ X8_v7 (Il2CppClass<TK>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv168 = 0x8BF6A34(value, v159, *([v94 @ X8_v7 (Il2CppClass<TK>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tgoto L_0091;\nL_0091:\n\tgoto L_0095;\nL_0095:\n\tv188 = 0x21C0FD4(Il2CppClass<TK>, value, v105, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv191 = *([A4731E0]);\n\tv202 = *([v191 @ X9_v4]) != *([v35 @ X8_v2]);\n\tif (v202) goto L_00B4;\n\treturn;\nL_00B4:\n\tv215 = 0x8BF5CF0(v188, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0038:\n\tv94 = Il2CppClass<TK>;\n\tv98 = v88 + 0xF;\n\tv99 = v98 & 0x1FFFFFFF0;\n\t// 61 StackAlloc v100 @ X25_v1 (System.Byte*), v99 @ X10_v2 (System.Int32)\n\tv103 = *([v94 @ X8_v7 (Il2CppClass<TK>)+FC]) + 0xF;\n\tv104 = v103 & 0x1FFFFFFF0;\n\t// 66 StackAlloc v105 @ X22_v1 (System.Byte*), v104 @ X10_v4 (System.Int32)\n\tv107 = v90 & 1;\n\tv108 = v107 == 0;\n\tv109 = ~v108;\n\tif (v109) goto L_004A;\n")]
		public unsafe void Deconstruct(out T key, out TK value)
		{
			//IL_0024: Expected O, but got I
			//IL_003a: Expected O, but got I
			//IL_012f: Expected O, but got I
			//IL_0175: Expected O, but got I
			//IL_009d: Expected O, but got I
			//IL_00ad: Expected O, but got I
			//IL_00c5: Expected O, but got I
			//IL_0100: Expected O, but got I
			//IL_02e7: Expected O, but got I
			//IL_02fa: Expected I4, but got I8
			//IL_031b: Expected O, but got I
			//IL_032e: Expected I4, but got I8
			//IL_01ae: Expected O, but got I
			//IL_0247: Expected O, but got I
			//IL_02a2: Expected O, but got I
			key = default(T);
			value = default(TK);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj = 0;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X0_v1 (Il2CppClass<Unco.Utils.PairReference`2>)+135]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X0_v1 (Il2CppClass<Unco.Utils.PairReference`2>)+135]");
			object obj5;
			object obj6;
			nint num4;
			if ((int)((nint)0 & (nint)1) == 0)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ X0_v41 (Il2CppClass<Unco.Utils.PairReference`2>)+135]");
				obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X0_v40+C0]");
				object obj3 = 0;
				object obj4 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ X8_v36+FC]");
				obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v64 @ X0_v41 (Il2CppClass<Unco.Utils.PairReference`2>)+135]");
				int num3 = (int)((nint)0 & (nint)1);
				bool flag = num3 == 0;
				num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ X8_v36+FC]");
				obj6 = 0;
				nint num5 = 0;
				if (flag)
				{
					goto IL_0189;
				}
			}
			else
			{
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ X8_v31 (Il2CppClass<T>)+FC]");
				obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X0_v1 (Il2CppClass<Unco.Utils.PairReference`2>)+135]");
				int num7 = (int)((nint)0 & (nint)1);
				bool flag2 = num7 == 0;
				bool flag3 = !flag2;
				num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ X8_v31 (Il2CppClass<T>)+FC]");
				obj6 = 0;
				nint num5 = 0;
				if (!flag3)
				{
					goto IL_0189;
				}
			}
			goto IL_02d2;
			IL_02d2:
			nint num8 = 0;
			object obj7 = (nint)obj5 + 15;
			int num9 = (int)((nint)obj7 & 0x1FFFFFFF0L);
			byte* ptr = stackalloc byte[(int)(uint)num9];
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ X8_v7 (Il2CppClass<TK>)+FC]");
			object obj8 = (nint)0 + (nint)15;
			int num10 = (int)((nint)obj8 & 0x1FFFFFFF0L);
			byte* ptr2 = stackalloc byte[(int)(uint)num10];
			if ((int)((nint)obj2 & 1) == 0)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			}
			nint num11 = 0;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1054");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A1C");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A34");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C0FD4");
			nint num12 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ X8_v20 (Il2CppClass<Unco.Utils.PairReference`2<T, TK>>)+80]");
			object obj9 = (nint)0 + (nint)32;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1054");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A1C");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A34");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C0FD4");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj10 = 0;
			if (obj10 != obj)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5CF0");
			}
			return;
			IL_0189:
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			nint num13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ X0_v38 (Il2CppClass<Unco.Utils.PairReference`2>)+135]");
			obj2 = 0;
			obj5 = obj6;
			num4 = 0;
			goto IL_02d2;
		}
	}
}
