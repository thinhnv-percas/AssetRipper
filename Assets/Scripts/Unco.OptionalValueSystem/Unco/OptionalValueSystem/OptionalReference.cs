using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Unco.OptionalValueSystem
{
	[Serializable]
	[Token(Token = "0x2000005")]
	public class OptionalReference<T>
	{
		[Token(Token = "0x4000008")]
		[FieldOffset(Offset = "0x0")]
		public bool HasValue;

		[SerializeReference]
		[Token(Token = "0x4000009")]
		[FieldOffset(Offset = "0x0")]
		private T m_value;

		[Token(Token = "0x17000003")]
		public T Value
		{
			[Token(Token = "0x6000008")]
			[Address(RVA = "0x5E99ED4", Offset = "0x5E99ED4", Length = "0x8C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1<T>>;\n\tv23 = *([v22 @ X8_v3 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1<T>>)+8]);\n\tv26 = 0x21C1054(this, *([v22 @ X8_v3 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1<T>>)+80]), methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv41 = *([v26 @ X0_v1]) & 1;\n\tv42 = v41 == 0;\n\tif (v42) goto L_0032;\n\tv45 = Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1<T>>;\n\tv47 = *([v45 @ X8_v7 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1<T>>)+80]) + 0x20;\n\tv49 = 0x21C1054(this, v47, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal2 = 0x8BF6A34(il2cppRetVal, v49, *([v23 @ X9_v1+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal2;\nL_0032:\n\treturnVal1 = 0x8BF5F18(il2cppRetVal, *([v23 @ X9_v1+FC]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal1;\n")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("OptionalReference::get_Value");
				return default;
			}
		}

		[Token(Token = "0x17000004")]
		public unsafe static OptionalReference<T> None
		{
			[Token(Token = "0x600000C")]
			[Address(RVA = "0x5E9A3B4", Offset = "0x5E9A3B4", Length = "0x1BC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = *([A4731E0]);\n\tv20 = Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>;\n\tgoto L_001D;\n\tv65 = Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1<T>>;\n\tv68 = *([v65 @ X0_v30 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1<T>>)+135]) & 1;\n\tv69 = v68 == 0;\n\tv72 = Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1<T>>;\n\tv79 = Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1<T>>;\n\tif (v69) goto L_0054;\nL_0030:\n\tv78 = new v72();\n\tv88 = Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>;\n\tv134 = *([v88 @ X0_v29 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>)+135]);\n\tv91 = *([v88 @ X0_v29 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>)+135]) & 1;\n\tv92 = v91 == 0;\n\tv93 = ~v92;\n\tv97 = Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>;\n\tv138 = v78;\n\tv128 = Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>;\n\tv165 = v78;\n\tif (v93) goto L_005E;\nL_0039:\n\tv105 = 0x220C238(v97, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv119 = Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>;\n\tv134 = *([v119 @ X0_v26 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>)+135]);\n\tv122 = *([v105 @ X0_v25+C0]);\n\tv123 = *([v122 @ X8_v32+18]);\n\tv137 = *([v123 @ X8_v33]);\n\tv125 = *([v119 @ X0_v26 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>)+135]) & 1;\n\tv126 = v125 == 0;\n\tv128 = Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>;\n\tv128 = Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>;\n\tv164 = *([v123 @ X8_v33]);\n\tv165 = v138;\n\tif (v126) goto L_0064;\nL_0046:\n\tv142 = v134 & 1;\n\tv143 = v142 == 0;\n\tif (v143) goto L_006F;\n\tv164 = v137;\n\tv165 = v138;\n\tv167 = Il2CppMethodInfo;\n\tgoto L_0076;\nL_004B:\n\tv71 = 0x220C238(Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv83 = *([v71 @ X0_v21+C0]);\n\tv72 = *([v83 @ X8_v25]);\n\tv85 = *([v72 @ X0_v27 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1<T>>)+135]) & 1;\n\tv86 = v85 == 0;\n\tv75 = ~v86;\n\tv79 = v72;\n\tif (v75) goto L_0030;\nL_0054:\n\tv82 = 0x220C238(v79, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv94 = new v82();\n\tv98 = Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>;\n\tv134 = *([v98 @ X0_v19 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>)+135]);\n\tv117 = *([v98 @ X0_v19 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>)+135]) & 1;\n\tv100 = v117 == 0;\n\tv97 = Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>;\n\tv138 = v94;\n\tv128 = Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>;\n\tv165 = v94;\n\tif (v100) goto L_0039;\nL_005E:\n\tv112 = Il2CppMethodInfo;\n\tv137 = *([v112 @ X8_v22 (Il2CppMethodInfo)]);\n\tv114 = v134 & 1;\n\tv115 = v114 == 0;\n\tv116 = ~v115;\n\tv138 = v165;\n\tv164 = *([v112 @ X8_v22 (Il2CppMethodInfo)]);\n\tif (v116) goto L_0046;\nL_0064:\n\tv133 = 0x220C238(v128, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv148 = *([v133 @ X0_v13+C0]);\n\tv167 = *([v148 @ X8_v19+18]);\n\tgoto L_0076;\nL_006F:\n\tv160 = 0x220C238(Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0076:\n\tgoto L_0078;\n\treturn v165;\nL_009C:\n\treturnVal2 = 0x8BF5CF0(v186, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal2;\nL_001D:\n\tv52 = Il2CppClass<T>;\n\tv56 = *([v52 @ X8_v7 (Il2CppClass<T>)+FC]) + 0xF;\n\tv57 = v56 & 0x1FFFFFFF0;\n\t// 34 StackAlloc v58 @ X19_v1 (System.Byte*), v57 @ X9_v2 (System.Int32)\n\tv61 = 0x8BF5F18(v58, *([v52 @ X8_v7 (Il2CppClass<T>)+FC]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv62 = *([v20 @ X21_v1 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>)+135]) & 1;\n\tv63 = v62 == 0;\n\tif (v63) goto L_004B;\nL_0078:\n\tv176 = 0;\n\tv178 = v58;\n\tv179 = &v176 @ stack_-49_v1;\n\t*([v167 @ X20_v2 (Il2CppMethodInfo)+10])(v186, v164, v167, v165, &v178 @ stack_-48_v1 (System.IntPtr), &v176 @ stack_-49_v1, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv189 = *([A4731E0]);\n\tv200 = *([v189 @ X9_v5]) != *([v17 @ X8_v2]);\n\tif (v200) goto L_009C;\n")]
			get
			{
				//IL_0010: Expected O, but got I
				//IL_037a: Expected O, but got I
				//IL_038d: Expected I4, but got I8
				//IL_01d7: Expected O, but got I
				//IL_01df: Expected I, but got O
				//IL_007b: Expected O, but got I
				//IL_02b1: Expected O, but got I
				//IL_02ea: Expected O, but got I
				//IL_00fa: Expected O, but got I
				//IL_010a: Expected O, but got I
				//IL_011a: Expected O, but got I
				//IL_0254: Expected O, but got I
				//IL_0317: Expected O, but got I
				//IL_03e3: Expected O, but got I4
				//IL_040d: Expected O, but got I
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
				object obj = 0;
				nint num = 0;
				nint num2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X8_v7 (Il2CppClass<T>)+FC]");
				object obj2 = (nint)0 + (nint)15;
				int num3 = (int)((nint)obj2 & 0x1FFFFFFF0L);
				byte* ptr = stackalloc byte[(int)(uint)num3];
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5F18");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ X21_v1 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>)+135]");
				if ((uint)((nuint)0u & (nuint)1u) != 0)
				{
					nint num4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v65 @ X0_v30 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1<T>>)+135]");
					int num5 = (int)((nint)0 & (nint)1);
					bool flag = num5 == 0;
					nint num6 = 0;
					nint num7 = 0;
					if (!flag)
					{
						goto IL_0060;
					}
				}
				else
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X0_v21+C0]");
					object obj3 = 0;
					nint num6 = (nint)obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v72 @ X0_v27 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1<T>>)+135]");
					int num8 = (int)((nint)0 & (nint)1);
					bool flag2 = num8 == 0;
					bool flag3 = !flag2;
					nint num7 = num6;
					if (flag3)
					{
						goto IL_0060;
					}
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				OptionalReference<T> optionalReference = null;
				nint num9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ X0_v19 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>)+135]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ X0_v19 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>)+135]");
				int num10 = (int)((nint)0 & (nint)1);
				bool flag4 = num10 == 0;
				nint num11 = 0;
				OptionalReference<T> optionalReference2 = optionalReference;
				nint num12 = 0;
				OptionalReference<T> optionalReference3 = optionalReference;
				if (flag4)
				{
					goto IL_00d5;
				}
				goto IL_02a3;
				IL_03da:
				object obj5 = 0;
				IntPtr intPtr = (nint)ptr;
				object obj6 = obj5;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v167 @ X20_v2 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
				object obj7 = 0;
				if (obj7 == obj)
				{
					return optionalReference3;
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5CF0");
				OptionalReference<T> result = default(OptionalReference<T>);
				return result;
				IL_0171:
				object obj9;
				nint num13;
				object obj8;
				if ((int)((nint)obj4 & 1) != 0)
				{
					obj8 = obj9;
					optionalReference3 = optionalReference2;
					num13 = 0;
				}
				else
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				}
				goto IL_03da;
				IL_02f8:
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ X0_v13+C0]");
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v148 @ X8_v19+18]");
				num13 = 0;
				goto IL_03da;
				IL_0060:
				OptionalReference<T> optionalReference4 = null;
				nint num14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ X0_v29 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>)+135]");
				obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ X0_v29 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>)+135]");
				int num15 = (int)((nint)0 & (nint)1);
				bool flag5 = num15 == 0;
				bool flag6 = !flag5;
				num11 = 0;
				optionalReference2 = optionalReference4;
				num12 = 0;
				optionalReference3 = optionalReference4;
				if (!flag6)
				{
					goto IL_00d5;
				}
				goto IL_02a3;
				IL_02a3:
				nint num16 = 0;
				obj9 = num16;
				int num17 = (int)((nint)obj4 & 1);
				bool flag7 = num17 == 0;
				bool flag8 = !flag7;
				optionalReference2 = optionalReference3;
				obj8 = num16;
				if (flag8)
				{
					goto IL_0171;
				}
				goto IL_02f8;
				IL_00d5:
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				nint num18 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ X0_v26 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>)+135]");
				obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v105 @ X0_v25+C0]");
				object obj11 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v122 @ X8_v32+18]");
				object obj12 = 0;
				obj9 = obj12;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ X0_v26 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>)+135]");
				int num19 = (int)((nint)0 & (nint)1);
				bool flag9 = num19 == 0;
				num12 = 0;
				num12 = 0;
				obj8 = obj12;
				optionalReference3 = optionalReference2;
				if (!flag9)
				{
					goto IL_0171;
				}
				goto IL_02f8;
			}
		}

		[Token(Token = "0x6000009")]
		[Address(RVA = "0x5E99F60", Offset = "0x5E99F60", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = *([A4731E0]);\n\tgoto L_001B;\nL_001B:\n\tv50 = Il2CppClass<T>;\n\tv54 = *([v50 @ X8_v7 (Il2CppClass<T>)+FC]) + 0xF;\n\tv55 = v54 & 0x1FFFFFFF0;\n\t// 32 StackAlloc v56 @ X22_v1 (System.Byte*), v55 @ X9_v2 (System.Int32)\n\tgoto L_0038;\nL_0038:\n\tv68 = Il2CppMethodInfo;\n\tgoto L_0040;\nL_0040:\n\tv140 = Il2CppMethodInfo;\n\tv107 = v56;\n\t*([v140 @ X1_v2 (Il2CppMethodInfo)+10])(v144, *([v68 @ X8_v17 (Il2CppMethodInfo)]), Il2CppMethodInfo, conditional, &v107 @ stack_-50_v2 (System.Byte*), v56, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\treturnVal2 = 0x8BF6A1C(il2cppRetVal, v56, *([v50 @ X8_v7 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv147 = *([A4731E0]);\n\tv75 = *([v147 @ X9_v7]) != *([v25 @ X8_v2]);\n\tif (v75) goto L_0067;\n\treturn returnVal2;\nL_0067:\n\treturnVal1 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal1;\n")]
		public unsafe static implicit operator T(OptionalReference<T> conditional)
		{
			//IL_0010: Expected O, but got I
			//IL_0031: Expected O, but got I
			//IL_0044: Expected I4, but got I8
			//IL_009b: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj = 0;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X8_v7 (Il2CppClass<T>)+FC]");
			object obj2 = (nint)0 + (nint)15;
			int num2 = (int)((nint)obj2 & 0x1FFFFFFF0L);
			byte* ptr = stackalloc byte[(int)(uint)num2];
			nint num3 = 0;
			nint num4 = 0;
			byte* ptr2 = ptr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v140 @ X1_v2 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
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

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x5E9A084", Offset = "0x5E9A084", Length = "0x20C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv23 = *([A4731E0]);\n\tv26 = value;\n\tv27 = Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv73 = Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>;\n\tv69 = 0x220C238(v73, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_FFFFFFFF:\n\tv73 = Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>;\n\tgoto L_0032;\nL_FFFFFFFF:\n\tv92 = value;\n\tgoto L_0048;\nL_FFFFFFFF:\n\tv92 = &v26 @ stack_-68_v1 (T);\n\tv101 = Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1<T>>;\n\tv104 = *([v101 @ X0_v31 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1<T>>)+135]) & 1;\n\tv105 = v104 == 0;\nL_FFFFFFFF:\n\tv108 = Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1<T>>;\nL_FFFFFFFF:\n\tv115 = Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1<T>>;\n\tif (v105) goto L_0079;\nL_0055:\n\tv114 = new v108();\n\tv124 = Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>;\n\tv170 = *([v124 @ X0_v30 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>)+135]);\n\tv127 = *([v124 @ X0_v30 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>)+135]) & 1;\n\tv128 = v127 == 0;\n\tv129 = ~v128;\nL_FFFFFFFF:\n\tv133 = Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>;\nL_FFFFFFFF:\n\tv173 = v114;\nL_FFFFFFFF:\n\tv164 = Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>;\nL_FFFFFFFF:\n\tv200 = v114;\n\tif (v129) goto L_0083;\nL_005E:\n\tv141 = 0x220C238(v133, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv155 = Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>;\n\tv170 = *([v155 @ X0_v27 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>)+135]);\n\tv158 = *([v141 @ X0_v26+C0]);\n\tv159 = *([v158 @ X8_v37+18]);\n\tv175 = *([v159 @ X8_v38]);\n\tv161 = *([v155 @ X0_v27 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>)+135]) & 1;\n\tv162 = v161 == 0;\nL_FFFFFFFF:\n\tv164 = Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>;\nL_FFFFFFFF:\n\tv164 = Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>;\nL_FFFFFFFF:\n\tv200 = v173;\nL_FFFFFFFF:\n\tv202 = *([v159 @ X8_v38]);\n\tif (v162) goto L_0089;\nL_006B:\n\tv178 = v170 & 1;\n\tv179 = v178 == 0;\n\tif (v179) goto L_0094;\nL_FFFFFFFF:\n\tv200 = v173;\nL_FFFFFFFF:\n\tv202 = v175;\nL_FFFFFFFF:\n\tv203 = Il2CppMethodInfo;\n\tgoto L_009B;\nL_0070:\n\tv107 = 0x220C238(v73, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv119 = *([v107 @ X0_v22+C0]);\n\tv108 = *([v119 @ X8_v30]);\n\tv121 = *([v108 @ X0_v28 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1<T>>)+135]) & 1;\n\tv122 = v121 == 0;\n\tv111 = ~v122;\nL_FFFFFFFF:\n\tv115 = v108;\n\tif (v111) goto L_0055;\nL_0079:\n\tv118 = 0x220C238(v115, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv130 = new v118();\n\tv134 = Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>;\n\tv170 = *([v134 @ X0_v20 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>)+135]);\n\tv153 = *([v134 @ X0_v20 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>)+135]) & 1;\n\tv136 = v153 == 0;\nL_FFFFFFFF:\n\tv133 = Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>;\nL_FFFFFFFF:\n\tv173 = v130;\nL_FFFFFFFF:\n\tv164 = Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>;\nL_FFFFFFFF:\n\tv200 = v130;\n\tif (v136) goto L_005E;\nL_0083:\n\tv148 = Il2CppMethodInfo;\n\tv175 = *([v148 @ X8_v27 (Il2CppMethodInfo)]);\n\tv150 = v170 & 1;\n\tv151 = v150 == 0;\n\tv152 = ~v151;\nL_FFFFFFFF:\n\tv173 = v200;\nL_FFFFFFFF:\n\tv202 = *([v148 @ X8_v27 (Il2CppMethodInfo)]);\n\tif (v152) goto L_006B;\nL_0089:\n\tv169 = 0x220C238(v164, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv184 = *([v169 @ X0_v14+C0]);\n\tv203 = *([v184 @ X8_v24+18]);\n\tgoto L_009B;\nL_0094:\n\tv196 = 0x220C238(Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_009B:\n\tgoto L_009E;\n\treturn v200;\nL_00C4:\n\treturnVal2 = 0x8BF5CF0(v223, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal2;\n\tv57 = Il2CppClass<T>;\n\tv61 = *([v57 @ X9_v2 (Il2CppClass<T>)+FC]) + 0xF;\n\tv62 = v61 & 0x1FFFFFFF0;\n\t// 38 StackAlloc v63 @ X19_v1 (System.Byte*), v62 @ X10_v2 (System.Int32)\n\tv65 = *([v27 @ X21_v1 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>)+135]) & 1;\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\tif (v67) goto L_0032;\nL_0032:\n\tv75 = Il2CppClass<T>;\n\tv80 = *([v75 @ X8_v8 (Il2CppClass<T>)+28]) < 0;\n\tv83 = *([v75 @ X8_v8 (Il2CppClass<T>)+28]) ^ *([v75 @ X8_v8 (Il2CppClass<T>)+28]);\n\tv84 = *([v75 @ X8_v8 (Il2CppClass<T>)+28]) & v83;\n\tv85 = v84 < 0;\n\tv87 = v80 == v85;\n\tv88 = ~v87;\n\tv89 = ~v88;\n\tif (v89) goto L_FFFFFFFF;\nL_0048:\n\tv95 = 0x8BF6A1C(v63, v92, *([v57 @ X9_v2 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv98 = *([v73 @ X21_v3 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>)+135]) & 1;\n\tv99 = v98 == 0;\n\tif (v99) goto L_0070;\nL_009E:\n\tv213 = 1;\n\tv215 = v63;\n\tv216 = &v213 @ stack_-59_v1 (System.Int32);\n\t*([v203 @ X20_v2 (Il2CppMethodInfo)+10])(v223, v202, v203, v200, &v215 @ stack_-58_v1 (System.IntPtr), &v213 @ stack_-59_v1 (System.Int32), v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv226 = *([A4731E0]);\n\tv237 = *([v226 @ X9_v6]) != *([v23 @ X8_v2]);\n\tif (v237) goto L_00C4;\n")]
		public unsafe static implicit operator OptionalReference<T>(T value)
		{
			//IL_0010: Expected O, but got I
			//IL_03c1: Expected O, but got I
			//IL_03d4: Expected I4, but got I8
			//IL_021e: Expected O, but got I
			//IL_0226: Expected I, but got O
			//IL_00c2: Expected O, but got I
			//IL_02f8: Expected O, but got I
			//IL_0331: Expected O, but got I
			//IL_0141: Expected O, but got I
			//IL_0151: Expected O, but got I
			//IL_0161: Expected O, but got I
			//IL_029b: Expected O, but got I
			//IL_035e: Expected O, but got I
			//IL_0508: Expected O, but got I4
			//IL_0522: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj = 0;
			nint num = 0;
			nint num2 = 0;
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X9_v2 (Il2CppClass<T>)+FC]");
			object obj2 = (nint)0 + (nint)15;
			int num4 = (int)((nint)obj2 & 0x1FFFFFFF0L);
			byte* ptr = stackalloc byte[(int)(uint)num4];
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ X21_v1 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>)+135]");
			if ((int)((nint)0 & (nint)1) == 0)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				num2 = 0;
			}
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X8_v8 (Il2CppClass<T>)+28]");
			bool flag = (nint)0 < (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X8_v8 (Il2CppClass<T>)+28]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X8_v8 (Il2CppClass<T>)+28]");
			int num7 = (int)(num6 ^ 0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X8_v8 (Il2CppClass<T>)+28]");
			int num8 = (int)((nint)0 & (nint)num7);
			bool flag2 = num8 < 0;
			if (flag != flag2)
			{
				T val = value;
			}
			else
			{
				T val = value;
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A1C");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ X21_v3 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>)+135]");
			if ((uint)((nuint)0u & (nuint)1u) != 0)
			{
				nint num9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ X0_v31 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1<T>>)+135]");
				int num10 = (int)((nint)0 & (nint)1);
				bool flag3 = num10 == 0;
				nint num11 = 0;
				nint num12 = 0;
				if (!flag3)
				{
					goto IL_00a7;
				}
			}
			else
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ X0_v22+C0]");
				object obj3 = 0;
				nint num11 = (nint)obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v108 @ X0_v28 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1<T>>)+135]");
				int num13 = (int)((nint)0 & (nint)1);
				bool flag4 = num13 == 0;
				bool flag5 = !flag4;
				nint num12 = num11;
				if (flag5)
				{
					goto IL_00a7;
				}
			}
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			OptionalReference<T> optionalReference = null;
			nint num14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ X0_v20 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>)+135]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ X0_v20 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>)+135]");
			int num15 = (int)((nint)0 & (nint)1);
			bool flag6 = num15 == 0;
			nint num16 = 0;
			OptionalReference<T> optionalReference2 = optionalReference;
			nint num17 = 0;
			OptionalReference<T> optionalReference3 = optionalReference;
			if (flag6)
			{
				goto IL_011c;
			}
			goto IL_02ea;
			IL_033f:
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ X0_v14+C0]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ X8_v24+18]");
			nint num18 = 0;
			goto IL_04ef;
			IL_01b8:
			object obj7;
			object obj6;
			if ((int)((nint)obj4 & 1) != 0)
			{
				optionalReference3 = optionalReference2;
				obj6 = obj7;
				num18 = 0;
			}
			else
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			}
			goto IL_04ef;
			IL_011c:
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @220C238");
			nint num19 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ X0_v27 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>)+135]");
			obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ X0_v26+C0]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v158 @ X8_v37+18]");
			object obj9 = 0;
			obj7 = obj9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ X0_v27 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>)+135]");
			int num20 = (int)((nint)0 & (nint)1);
			bool flag7 = num20 == 0;
			num17 = 0;
			num17 = 0;
			optionalReference3 = optionalReference2;
			obj6 = obj9;
			if (!flag7)
			{
				goto IL_01b8;
			}
			goto IL_033f;
			IL_02ea:
			nint num21 = 0;
			obj7 = num21;
			int num22 = (int)((nint)obj4 & 1);
			bool flag8 = num22 == 0;
			bool flag9 = !flag8;
			optionalReference2 = optionalReference3;
			obj6 = num21;
			if (flag9)
			{
				goto IL_01b8;
			}
			goto IL_033f;
			IL_00a7:
			OptionalReference<T> optionalReference4 = null;
			nint num23 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ X0_v30 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>)+135]");
			obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v124 @ X0_v30 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1>)+135]");
			int num24 = (int)((nint)0 & (nint)1);
			bool flag10 = num24 == 0;
			bool flag11 = !flag10;
			num16 = 0;
			optionalReference2 = optionalReference4;
			num17 = 0;
			optionalReference3 = optionalReference4;
			if (!flag11)
			{
				goto IL_011c;
			}
			goto IL_02ea;
			IL_04ef:
			int num25 = 1;
			IntPtr intPtr = (nint)ptr;
			object obj10 = num25;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v203 @ X20_v2 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj11 = 0;
			if (obj11 == obj)
			{
				return optionalReference3;
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5CF0");
			OptionalReference<T> result = default(OptionalReference<T>);
			return result;
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x5E9A290", Offset = "0x5E9A290", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv31 = *([A4731E0]);\n\tv34 = v90;\n\tv37 = Il2CppClass<T>;\n\tv40 = *([v37 @ X8_v6 (Il2CppClass<T>)+FC]) + 0xF;\n\tv41 = v40 & 0x1FFFFFFF0;\n\t// 29 StackAlloc v42 @ X24_v1 (System.Byte*), v41 @ X9_v2 (System.Int32)\n\tSystem.Object::.ctor(this);\n\tv47 = Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1<T>>;\n\tv48 = *([v47 @ X8_v10 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1<T>>)+80]);\n\tv51 = 0x815C(*([v47 @ X8_v10 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1<T>>)+80]), 1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv66 = 0x21C1054(this, *([v47 @ X8_v10 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1<T>>)+80]), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\t*([v66 @ X0_v4]) = hasValue;\n\tv70 = 0x21C0FD4(*([v48 @ X25_v1+8]), v66, 0, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv73 = Il2CppClass<T>;\n\tv78 = *([v73 @ X8_v12 (Il2CppClass<T>)+28]) < 0;\n\tv81 = *([v73 @ X8_v12 (Il2CppClass<T>)+28]) ^ *([v73 @ X8_v12 (Il2CppClass<T>)+28]);\n\tv82 = *([v73 @ X8_v12 (Il2CppClass<T>)+28]) & v81;\n\tv83 = v82 < 0;\n\tv85 = v78 == v83;\n\tv86 = ~v85;\n\tv87 = ~v86;\n\tif (v87) goto L_0048;\n\tgoto L_0048;\n\treturn;\nL_006C:\n\tv125 = 0x8BF5CF0(v100, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0048:\n\tv93 = 0x8BF6A1C(v42, &v34 @ stack_-60_v1 (T), *([v37 @ X8_v6 (Il2CppClass<T>)+FC]), clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv94 = Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1<T>>;\n\tv96 = *([v94 @ X8_v15 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1<T>>)+80]) + 0x20;\n\tv100 = 0x21C1058(this, v96, v42, *([v37 @ X8_v6 (Il2CppClass<T>)+FC]), clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv103 = *([A4731E0]);\n\tv114 = *([v103 @ X9_v4]) != *([v31 @ X8_v2]);\n\tif (v114) goto L_006C;\n")]
		private unsafe OptionalReference(T value, bool hasValue)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj = 0;
			T val2 = default(T);
			T val = val2;
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ X8_v6 (Il2CppClass<T>)+FC]");
			object obj2 = (nint)0 + (nint)15;
			int num2 = (int)((nint)obj2 & 0x1FFFFFFF0L);
			byte* ptr = stackalloc byte[(int)(uint)num2];
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X8_v10 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1<T>>)+80]");
			object obj3 = 0;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @815C");
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1054");
			object obj4 = hasValue;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C0FD4");
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ X8_v12 (Il2CppClass<T>)+28]");
			bool flag = (nint)0 < (nint)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ X8_v12 (Il2CppClass<T>)+28]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ X8_v12 (Il2CppClass<T>)+28]");
			int num6 = (int)(num5 ^ 0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ X8_v12 (Il2CppClass<T>)+28]");
			int num7 = (int)((nint)0 & (nint)num6);
			bool flag2 = num7 < 0;
			if (flag != flag2)
			{
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6A1C");
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ X8_v15 (Il2CppClass<Unco.OptionalValueSystem.OptionalReference`1<T>>)+80]");
			object obj5 = (nint)0 + (nint)32;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1058");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj6 = 0;
			if (obj6 != obj)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5CF0");
			}
		}
	}
}
