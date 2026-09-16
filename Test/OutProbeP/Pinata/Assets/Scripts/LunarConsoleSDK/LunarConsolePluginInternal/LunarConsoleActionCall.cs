using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace LunarConsolePluginInternal
{
	[Serializable]
	[Token(Token = "0x2000023")]
	public class LunarConsoleActionCall
	{
		[CompilerGenerated]
		[Token(Token = "0x2000038")]
		private sealed class _003C_003Ec__DisplayClass6_0
		{
			[Token(Token = "0x40000A7")]
			[FieldOffset(Offset = "0x10")]
			public string methodName;

			[Token(Token = "0x40000A8")]
			[FieldOffset(Offset = "0x18")]
			public Type paramType;

			[Token(Token = "0x6000199")]
			[Address(RVA = "0x13E1D5C", Offset = "0x13E1D5C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec__DisplayClass6_0()
			{
			}

			internal bool _003CResolveMethod_003Eb__0(MethodInfo method)
			{
				//IL_0182: Expected I, but got O
				//IL_019c: Expected O, but got I
				//IL_01ac: Expected O, but got I
				string name = method.Name;
				if (!(name != methodName))
				{
					ParameterInfo[] parameters = method.GetParameters();
					Type typeFromHandle = typeof(void);
					if (paramType == typeFromHandle)
					{
						return parameters.Length == 0;
					}
					if (parameters.Length == 1)
					{
						Type parameterType = parameters[0].ParameterType;
						if (parameterType == paramType)
						{
							return true;
						}
						if (parameters.Length != 0)
						{
							Type parameterType2 = parameters[0].ParameterType;
							IntPtr intPtr = (IntPtr)parameterType2;
							Type type = paramType;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ X8_v15 (Il2CppClass<System.Type>)+820]");
							object obj = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v273 @ X8_v15 (Il2CppClass<System.Type>)+828]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v244 @ X3_v1 (should have been resolved before IL gen)");
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
					}
				}
				return false;
			}
		}

		[Token(Token = "0x400006F")]
		private static readonly Type[] kParamTypes;

		[SerializeField]
		[Token(Token = "0x4000070")]
		[FieldOffset(Offset = "0x10")]
		private UnityEngine.Object m_target;

		[SerializeField]
		[Token(Token = "0x4000071")]
		[FieldOffset(Offset = "0x18")]
		private string m_methodName;

		[SerializeField]
		[Token(Token = "0x4000072")]
		[FieldOffset(Offset = "0x20")]
		private LunarPersistentListenerMode m_mode;

		[SerializeField]
		[Token(Token = "0x4000073")]
		[FieldOffset(Offset = "0x28")]
		private LunarArgumentCache m_arguments;

		[Token(Token = "0x17000027")]
		public UnityEngine.Object target
		{
			[Token(Token = "0x60000D7")]
			[Address(RVA = "0x13E2048", Offset = "0x13E2048", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_target;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return target;
			}
		}

		[Token(Token = "0x17000028")]
		public string methodName
		{
			[Token(Token = "0x60000D8")]
			[Address(RVA = "0x13E2050", Offset = "0x13E2050", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_methodName;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return methodName;
			}
		}

		[Token(Token = "0x17000029")]
		public LunarPersistentListenerMode mode
		{
			[Token(Token = "0x60000D9")]
			[Address(RVA = "0x13E2058", Offset = "0x13E2058", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_mode;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return mode;
			}
		}

		[Token(Token = "0x60000D2")]
		[Address(RVA = "0x13E1570", Offset = "0x13E1570", Length = "0x600")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ECE168]);\n\tv23 = *([v22 @ X8_v23]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2028AD4]) = v42;\nL_0015:\n\tv43 = v40.m_mode;\n\tv44 = v40.m_mode < 5;\n\tv45 = ~v44;\n\tv46 = v40.m_mode - 5;\n\tv48 = v46 == 0;\n\tv53 = ~v48;\n\tv54 = v45 & v53;\n\tif (v54) goto L_005A;\n\tv56 = 0x1835000 + 0x82C;\n\tv43 = *([v56 @ X9_v4 (System.Int32)+v43 @ X8_v3 (LunarConsolePluginInternal.LunarPersistentListenerMode)*4]);\n\tv43 = v43 + v56;\n\t// 38 IndirectJump v43 @ X8_v3 (LunarConsolePluginInternal.LunarPersistentListenerMode), v40 @ X0_v1 (LunarConsolePluginInternal.LunarConsoleActionCall), v40 @ X0_v1 (LunarConsolePluginInternal.LunarConsoleActionCall), methodInfo @ X1 (Il2CppMethodInfo), v26 @ X2, v27 @ X3, v28 @ X4, v29 @ X5, v30 @ X6, v31 @ X7, v32 @ V0, v33 @ V1, v34 @ V2, v35 @ V3, v36 @ V4, v37 @ V5, v38 @ V6, v39 @ V7\n\tX8 = *([1EDAE38]);\n\tX21 = *([X19+10]);\n\tX20 = *([X19+18]);\n\tX0 = *([X8]);\n\tX8 = *([1EC35B0]);\n\tX9 = *([X0+12F]);\n\tX22 = *([X8]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_0038;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0038;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0038:\n\tX0 = X22;\n\tX1 = 0;\n\tX0 = System.Type::GetTypeFromHandle(X0, X1);\n\tX8 = *([1EC3978]);\n\tX22 = X0;\n\tX8 = *([X8]);\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_0049;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0049;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0049:\n\tX0 = X21;\n\tX1 = X20;\n\tX2 = X22;\n\tX0 = LunarConsolePluginInternal.LunarConsoleActionCall::ResolveMethod(X0, X1, X2, X3);\n\tX8 = *([1EFE3C0]);\n\tX20 = X0;\n\tX1 = 0;\n\tX8 = *([X8]);\n\tX0 = X8;\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = X0;\n\tgoto L_0136;\nL_005A:\n\t// 90 NewArr v63 @ X0_v3 (System.Object[]), typeof(System.Object[]), 1\n\tv43 = v40.m_mode;\n\t// 98 Box v101 @ X0_v5, typeof(LunarConsolePluginInternal.LunarPersistentListenerMode), &v43 @ X8_v3 (LunarConsolePluginInternal.LunarPersistentListenerMode)\n\tv103 = v101 == 0;\n\tif (v103) goto L_006F;\n\t// 107 IsInst v108 @ X0_v18, typeof(System.Object), v101 @ X0_v5\nL_006F:\n\tv115 = v63.Length == 0;\n\tif (v115) goto L_01E5;\n\tv63[0] = v101;\n\tgoto L_0080;\n\tv129 = *([v119 @ X0_v13+E0]);\n\tv130 = v129 == 0;\n\tv131 = ~v130;\n\tif (v131) goto L_0080;\n\tv133 = \"il2cpp_codegen_runtime_class_init\"(v119, v109, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0080:\n\tgoto L_016A;\n\tX8 = *([1EDAE38]);\n\tX21 = *([X19+10]);\n\tX20 = *([X19+18]);\n\tX0 = *([X8]);\n\tX8 = *([1F01AE0]);\n\tX9 = *([X0+12F]);\n\tX22 = *([X8]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_0092;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0092;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0092:\n\tX0 = X22;\n\tX1 = 0;\n\tX0 = System.Type::GetTypeFromHandle(X0, X1);\n\tX8 = *([1EC3978]);\n\tX22 = X0;\n\tX8 = *([X8]);\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_00A3;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00A3;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00A3:\n\tX0 = X21;\n\tX1 = X20;\n\tX2 = X22;\n\tX0 = LunarConsolePluginInternal.LunarConsoleActionCall::ResolveMethod(X0, X1, X2, X3);\n\tX8 = *([1EFE3C0]);\n\tX20 = X0;\n\tX1 = 0 | 1;\n\tX8 = *([X8]);\n\tX0 = X8;\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19+28]);\n\tX21 = X0;\n\tif (TEMP) goto L_01E3;\n\tX8 = *([X8+30]);\n\tX9 = *([1EC5410]);\n\tX1 = &stack[C];\n\tstack[C] = X8;\n\tgoto L_0125;\n\tX8 = *([1EDAE38]);\n\tX21 = *([X19+10]);\n\tX20 = *([X19+18]);\n\tX0 = *([X8]);\n\tX8 = *([1EFD3D8]);\n\tX9 = *([X0+12F]);\n\tX22 = *([X8]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_00C9;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00C9;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00C9:\n\tX0 = X22;\n\tX1 = 0;\n\tX0 = System.Type::GetTypeFromHandle(X0, X1);\n\tX8 = *([1EC3978]);\n\tX22 = X0;\n\tX8 = *([X8]);\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_00DA;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00DA;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00DA:\n\tX0 = X21;\n\tX1 = X20;\n\tX2 = X22;\n\tX0 = LunarConsolePluginInternal.LunarConsoleActionCall::ResolveMethod(X0, X1, X2, X3);\n\tX8 = *([1EFE3C0]);\n\tX20 = X0;\n\tX1 = 0 | 1;\n\tX8 = *([X8]);\n\tX0 = X8;\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19+28]);\n\tX21 = X0;\n\tif (TEMP) goto L_01E3;\n\tX8 = *([X8+20]);\n\tX9 = *([1ED0418]);\n\tX1 = &stack[4];\n\tstack[4] = X8;\n\tgoto L_0125;\n\tX8 = *([1EDAE38]);\n\tX21 = *([X19+10]);\n\tX20 = *([X19+18]);\n\tX0 = *([X8]);\n\tX8 = *([1EF3A70]);\n\tX9 = *([X0+12F]);\n\tX22 = *([X8]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_0100;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0100;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0100:\n\tX0 = X22;\n\tX1 = 0;\n\tX0 = System.Type::GetTypeFromHandle(X0, X1);\n\tX8 = *([1EC3978]);\n\tX22 = X0;\n\tX8 = *([X8]);\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_0111;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0111;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0111:\n\tX0 = X21;\n\tX1 = X20;\n\tX2 = X22;\n\tX0 = LunarConsolePluginInternal.LunarConsoleActionCall::ResolveMethod(X0, X1, X2, X3);\n\tX8 = *([1EFE3C0]);\n\tX20 = X0;\n\tX1 = 0 | 1;\n\tX8 = *([X8]);\n\tX0 = X8;\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19+28]);\n\tX21 = X0;\n\tif (TEMP) goto L_01E3;\n\tX8 = *([X8+24]);\n\tX9 = *([1EE1A60]);\n\tX1 = &stack[8];\n\tstack[8] = X8;\nL_0125:\n\tX0 = *([X9]);\n\tX0 = 0x8D82A8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX22 = X0;\n\tif (TEMP) goto L_01E3;\n\tif (TEMP) goto L_0132;\nL_012C:\n\tX8 = *([X21]);\n\tX0 = X22;\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_01E7;\nL_0132:\n\tX8 = *([X21+18]);\n\tif (TEMP) goto L_01E5;\n\t*([X21+20]) = X22;\nL_0136:\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = System.Reflection.MethodInfo::op_Inequality(X0, X1, X2);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0145;\n\tif (TEMP) goto L_01E3;\n\tX1 = *([X19+10]);\n\tX0 = X20;\n\tX2 = X21;\n\tX3 = 0;\n\tX0 = System.Reflection.MethodBase::Invoke(X0, X1, X2, X3);\n\tgoto L_016B;\nL_0145:\n\tX8 = 0x1EFE000;\n\tX8 = *([1EFE3C0]);\n\tX1 = 0 | 1;\n\tX0 = *([X8]);\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tif (TEMP) goto L_01E4;\n\tX19 = *([X19+18]);\n\tif (TEMP) goto L_0156;\n\tX8 = *([X20]);\n\tX0 = X19;\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_01E7;\nL_0156:\n\tX8 = *([X20+18]);\n\tif (TEMP) goto L_01E5;\n\t*([X20+20]) = X19;\n\tX8 = *([1EB5228]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0166;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0166;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0166:\n\tX8 = 0x1EFC000;\n\tX8 = *([1EFC798]);\nL_016A:\n\tLunarConsolePluginInternal.Log::e(\"Unable to invoke action: unexpected invoke mode '{0}'\", v63);\nL_016B:\n\t;\n\treturn;\n\tX8 = *([1EDAE38]);\n\tX21 = *([X19+10]);\n\tX20 = *([X19+18]);\n\tX0 = *([X8]);\n\tX8 = *([1ECE0A0]);\n\tX9 = *([X0+12F]);\n\tX22 = *([X8]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_0184;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0184;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0184:\n\tX0 = X22;\n\tX1 = 0;\n\tX0 = System.Type::GetTypeFromHandle(X0, X1);\n\tX8 = *([1EC3978]);\n\tX22 = X0;\n\tX8 = *([X8]);\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_0195;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0195;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0195:\n\tX0 = X21;\n\tX1 = X20;\n\tX2 = X22;\n\tX0 = LunarConsolePluginInternal.LunarConsoleActionCall::ResolveMethod(X0, X1, X2, X3);\n\tX8 = *([1EFE3C0]);\n\tX20 = X0;\n\tX1 = 0 | 1;\n\tX8 = *([X8]);\n\tX0 = X8;\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2\n// ... truncated")]
		public void Invoke()
		{
			LunarPersistentListenerMode lunarPersistentListenerMode = mode;
			bool flag = mode < LunarPersistentListenerMode.Object;
			bool flag2 = !flag;
			int num = (int)(mode - 5);
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num2 = 25382912 + 2092;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ X9_v4 (System.Int32)+v43 @ X8_v3 (LunarConsolePluginInternal.LunarPersistentListenerMode)*4]");
				lunarPersistentListenerMode = LunarPersistentListenerMode.Void;
				lunarPersistentListenerMode += num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v43 @ X8_v3 (LunarConsolePluginInternal.LunarPersistentListenerMode) (should have been resolved before IL gen)");
			}
			object[] array = new object[1];
			lunarPersistentListenerMode = mode;
			object obj = lunarPersistentListenerMode;
			if (obj != null)
			{
				object obj2 = obj as object;
			}
			if (array.Length != 0)
			{
				array[0] = obj;
				Log.e("Unable to invoke action: unexpected invoke mode '{0}'", array);
				return;
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x60000D3")]
		[Address(RVA = "0x13E1C70", Offset = "0x13E1C70", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EE8230]);\n\tv27 = *([v26 @ X8_v15]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodName, paramType, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2028AD5]) = v44;\nL_001A:\n\tv48 = new LunarConsolePluginInternal.LunarConsoleActionCall+<>c__DisplayClass6_0();\n\tSystem.Object::.ctor(v48);\n\tv48.methodName = methodName;\n\tv48.paramType = paramType;\n\tv57 = System.Object::GetType(target);\n\tv79 = new LunarConsolePluginInternal.ListMethodsFilter();\n\tv63 = Il2CppMethodInfo;\n\tv79.m_target = v48;\n\tv79.method = Il2CppMethodInfo;\n\tv79.method_ptr = *([v63 @ X9_v4 (Il2CppMethodInfo)]);\n\tv67 = LunarConsolePluginInternal.ClassUtils::ListInstanceMethods(v57, v79);\n\tv86 = v67._size != 1;\n\tif (v86) goto L_FFFFFFFF;\n\tv132 = v67._items;\n\treturnVal2 = v132[0];\n\tgoto L_0051;\nL_0051:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe static MethodInfo ResolveMethod(object target, string methodName, Type paramType)
		{
			_003C_003Ec__DisplayClass6_0 _003C_003Ec__DisplayClass6_1 = new _003C_003Ec__DisplayClass6_0();
			_003C_003Ec__DisplayClass6_1.methodName = methodName;
			_003C_003Ec__DisplayClass6_1.paramType = paramType;
			Type type = target.GetType();
			ListMethodsFilter listMethodsFilter = null;
			IntPtr method_ptr = (IntPtr)0;
			((Delegate)listMethodsFilter).m_target = _003C_003Ec__DisplayClass6_1;
			((Delegate)listMethodsFilter).method = (IntPtr)__ldftn(_003C_003Ec__DisplayClass6_0._003CResolveMethod_003Eb__0);
			((Delegate)listMethodsFilter).method_ptr = method_ptr;
			List<MethodInfo> list = ClassUtils.ListInstanceMethods(type, listMethodsFilter);
			if (list.Count == 1)
			{
				MethodInfo[] items = list._items;
				return items[0];
			}
			return null;
		}

		[Token(Token = "0x60000D4")]
		[Address(RVA = "0x13E0EA4", Offset = "0x13E0EA4", Length = "0x428")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv38 = *([1EB8290]);\n\tv39 = *([v38 @ X8_v38]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, methodName, mode, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2028AD6]) = v56;\nL_0026:\n\tgoto L_002F;\n\tv66 = *([v62 @ X0_v2+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tgoto L_002F;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v62, methodName, mode, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_002F:\n\tv76 = UnityEngine.Object::op_Equality(target, 0);\n\tv78 = v76 == 0;\n\tif (v78) goto L_003B;\n\tgoto L_0161;\nL_003B:\n\tgoto L_0042;\n\tv194 = *([v82 @ X0_v8+E0]);\n\tv195 = v194 == 0;\n\tv196 = ~v195;\n\tif (v196) goto L_0042;\n\tv198 = \"il2cpp_codegen_runtime_class_init\"(v82, v74, v75, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0042:\n\tv202 = LunarConsolePluginInternal.LunarConsoleActionCall::ListActionMethods(target);\n\tv261 = System.Collections.Generic.List`1<System.Reflection.MethodInfo>::GetEnumerator(v202);\n\tv134 = mode - 1;\n\tv137 = 0x1835000 + 0x818;\nL_005D:\n\tv351 = 0xEF9AB0(&v156 @ stack_-98_v4, Il2CppMethodInfo, v159, methodInfo, v42, v43, v44, v45, v156, v47, v48, v49, v50, v51, v52, v53);\n\tv354 = v351 & 1;\n\tv355 = v354 == 0;\n\tif (v355) goto L_FFFFFFFF;\n\tv346 = *([v303 @ stack_-88]);\n\t*([v346 @ X8_v27+1A0])(v361, v303, *([v346 @ X8_v27+1A8]), v159, methodInfo, v42, v43, v44, v45, v156, v47, v48, v49, v50, v51, v52, v53);\n\tv338 = System.String::op_Equality(v361, methodName);\n\tv341 = v338 == 0;\n\tif (v341) goto L_005D;\n\tv379 = *([v303 @ stack_-88]);\n\t*([v379 @ X8_v28+240])(v339, v303, *([v379 @ X8_v28+248]), 0, methodInfo, v42, v43, v44, v45, v156, v47, v48, v49, v50, v51, v52, v53);\n\tv386 = mode == 0;\n\tif (v386) goto L_00B3;\n\tv306 = *([v339 @ X0_v43+18]) != 1;\n\tif (v306) goto L_005D;\n\tv327 = *([v339 @ X0_v43+20]);\n\tv347 = *([v327 @ X0_v44]);\n\t*([v347 @ X8_v31+1A0])(v241, v327, *([v347 @ X8_v31+1A8]), 0, methodInfo, v42, v43, v44, v45, v156, v47, v48, v49, v50, v51, v52, v53);\n\tv394 = v134 < 4;\n\tv221 = ~v394;\n\tv219 = v134 - 4;\n\tv215 = v219 == 0;\n\tv395 = ~v215;\n\tv205 = v221 & v395;\n\tif (v205) goto L_005D;\n\tv252 = *([v137 @ X28_v6 (System.Int32)+v134 @ X24_v5 (System.Int32)*4]) + v137;\n\t// 154 IndirectJump v252 @ X8_v33, v241 @ X0_v45, v241 @ X0_v45, [v347 @ X8_v31+1A8], 0, methodInfo @ X3 (Il2CppMethodInfo), v42 @ X4, v43 @ X5, v44 @ X6, v45 @ X7, v156 @ stack_-98_v4, v47 @ V1, v48 @ V2, v49 @ V3, v50 @ V4, v51 @ V5, v52 @ V6, v53 @ V7\n\tX8 = *([1EDAE38]);\n\tX22 = *([X22]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_00A8;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00A8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00A8:\n\tX0 = X22;\n\tX1 = 0;\n\tX0 = System.Type::GetTypeFromHandle(X0, X1);\n\tX1 = X0;\n\tX0 = X21;\n\tX2 = 0;\n\tX0 = System.Type::op_Equality(X0, X1, X2);\n\tgoto L_0112;\nL_00B3:\n\tv393 = *([v339 @ X0_v43+18]) == 0;\n\tv343 = ~v393;\n\tif (v343) goto L_005D;\n\tgoto L_FFFFFFFF;\n\tX8 = *([1EDAE38]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tX9 = *([1EF54C0]);\n\tX22 = *([X9]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_00C6;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00C6;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00C6:\n\tX0 = X22;\n\tX1 = 0;\n\tX0 = System.Type::GetTypeFromHandle(X0, X1);\n\tX1 = X0;\n\tif (TEMP) goto L_0128;\n\tX8 = *([X21]);\n\tX9 = *([X8+820]);\n\tX2 = *([X8+828]);\n\tX0 = X21;\n\tX9(X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX22 = *([1F01AE0]);\n\tgoto L_0114;\n\tX8 = *([1EDAE38]);\n\tX22 = *([X27]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_00E1;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00E1;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00E1:\n\tX0 = X22;\n\tX1 = 0;\n\tX0 = System.Type::GetTypeFromHandle(X0, X1);\n\tX1 = X0;\n\tX0 = X21;\n\tX2 = 0;\n\tX0 = System.Type::op_Equality(X0, X1, X2);\n\tgoto L_0112;\n\tX8 = *([1EDAE38]);\n\tX22 = *([X25]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_00F6;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00F6;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00F6:\n\tX0 = X22;\n\tX1 = 0;\n\tX0 = System.Type::GetTypeFromHandle(X0, X1);\n\tX1 = X0;\n\tX0 = X21;\n\tX2 = 0;\n\tX0 = System.Type::op_Equality(X0, X1, X2);\n\tgoto L_0112;\n\tX8 = *([1EDAE38]);\n\tX22 = *([X26]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_010B;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_010B;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_010B:\n\tX0 = X22;\n\tX1 = 0;\n\tX0 = System.Type::GetTypeFromHandle(X0, X1);\n\tX1 = X0;\n\tX0 = X21;\n\tX2 = 0;\n\tX0 = System.Type::op_Equality(X0, X1, X2);\nL_0112:\n\tX22 = 0x1F01000;\n\tX22 = *([1F01AE0]);\nL_0114:\n\tX28 = 0x1835000;\n\tX28 = X28 + 0x818;\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_005D;\n\tgoto L_0120;\nL_0120:\n\tv165 = 0xEF9AAC(&v156 @ stack_-98_v4, Il2CppMethodInfo, v159, methodInfo, v42, v43, v44, v45, v156, v47, v48, v49, v50, v51, v52, v53);\n\tgoto L_0161;\n\tv363 = new System.NullReferenceException();\n\tv380 = new System.NullReferenceException();\n\tv288 = new System.NullReferenceException();\n\tv296 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_0128:\n\t;\n\tv353 = new System.NullReferenceException();\n\tgoto L_013D;\n\tgoto L_013D;\n\tgoto L_013D;\n\tgoto L_013D;\n\tgoto L_013D;\n\tgoto L_013D;\n\tgoto L_013D;\n\tgoto L_013D;\n\tgoto L_013D;\n\tgoto L_013D;\n\tgoto L_013D;\n\tgoto L_013D;\n\tgoto L_013D;\n\tgoto L_013D;\n\tgoto L_013D;\n\tgoto L_013D;\n\tgoto L_013D;\n\tgoto L_013D;\n\tgoto L_013D;\nL_013D:\n\t;\n\tv87 = v324 != 1;\n\tif (v87) goto L_0162;\n\tv370 = 0x6D2BC0(v353, v324, v158, methodInfo, v42, v43, v44, v45, v139, v47, v48, v49, v50, v51, v52, v53);\n\tv173 = *([v370 @ X0_v20]);\n\tv381 = 0x6D2490(v370, v324, v158, methodInfo, v42, v43, v44, v45, v139, v47, v48, v49, v50, v51, v52, v53);\n\tv390 = &v127 @ stack_-80_v3;\n\tv161 = Il2CppMethodInfo;\n\tv164 = 0xEF9AAC(v390, v161, v158, methodInfo, v42, v43, v44, v45, v139, v47, v48, v49, v50, v51, v52, v53);\n\tv391 = v173 == 0;\n\tv167 = ~v391;\n\tif (v167) goto L_FFFFFFFF;\nL_0161:\n\treturn 0;\nL_0162:\n\tv371 = 0x6D2380(v353, v324, v158, methodInfo, v42, v43, v44, v45, v139, v47, v48, v49, v50, v51, v52, v53);\n\treturnVal2 = new System.TypeLoadException();\n\treturn returnVal2;\n// 158 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsPersistantListenerValid(UnityEngine.Object target, string methodName, LunarPersistentListenerMode mode)
		{
			//IL_007f: Expected O, but got I4
			//IL_00bf: Expected O, but got I4
			//IL_0204: Expected O, but got I4
			//IL_011f: Expected O, but got I4
			//IL_0220: Expected O, but got I4
			//IL_013d: Expected O, but got I
			//IL_01ac: Expected O, but got I4
			//IL_01cf: Expected O, but got I
			if (!(target == null))
			{
				List<MethodInfo> list = ListActionMethods(target);
				List<MethodInfo>.Enumerator enumerator = list.GetEnumerator();
				int num = (int)(mode - 1);
				int num2 = 25382912 + 2072;
				object obj = 0;
				object obj2 = default(object);
				object obj4 = default(object);
				string text = default(string);
				while (true)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @EF9AB0");
					if ((int)((long)(IntPtr)obj2 & 1L) == 0)
					{
						break;
					}
					object obj3 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v346 @ X8_v27+1A0] (should have been resolved before IL gen)");
					bool flag = text == methodName;
					bool flag2 = !flag;
					obj = 0;
					if (flag2)
					{
						continue;
					}
					object obj5 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v379 @ X8_v28+240] (should have been resolved before IL gen)");
					if (mode != LunarPersistentListenerMode.Void)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ X0_v43+18]");
						bool flag3 = (IntPtr)0 != (IntPtr)1;
						obj = 0;
						if (flag3)
						{
							continue;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ X0_v43+20]");
						object obj6 = 0;
						object obj7 = obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v347 @ X8_v31+1A0] (should have been resolved before IL gen)");
						bool flag4 = num < 4;
						bool flag5 = !flag4;
						int num3 = num - 4;
						bool flag6 = num3 == 0;
						bool flag7 = !flag6;
						bool flag8 = flag5 && flag7;
						obj = 0;
						if (flag8)
						{
							continue;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ X28_v6 (System.Int32)+v134 @ X24_v5 (System.Int32)*4]");
						object obj8 = 0L + (long)num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v252 @ X8_v33 (should have been resolved before IL gen)");
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ X0_v43+18]");
					bool flag9 = (IntPtr)0 == (IntPtr)0;
					bool flag10 = !flag9;
					obj = 0;
					if (!flag10)
					{
						obj = 0;
						break;
					}
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @EF9AAC");
			}
			return false;
		}

		[Token(Token = "0x60000D5")]
		[Address(RVA = "0x13E1D64", Offset = "0x13E1D64", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1ECCB78]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028AD7]) = v38;\nL_0016:\n\tv42 = new System.Collections.Generic.List`1<System.Reflection.MethodInfo>();\n\tSystem.Collections.Generic.List`1<System.Reflection.MethodInfo>::.ctor(v42);\n\tv50 = System.Object::GetType(target);\n\tv58 = new LunarConsolePluginInternal.ListMethodsFilter();\n\tv64 = Il2CppMethodInfo;\n\tv58.m_target = 0;\n\tv58.method = Il2CppMethodInfo;\n\tv58.method_ptr = *([v64 @ X9_v3 (Il2CppMethodInfo)]);\n\treturnVal2 = LunarConsolePluginInternal.ClassUtils::ListMethods(v42, v50, v58, 0x54);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static List<MethodInfo> ListActionMethods(object target)
		{
			List<MethodInfo> outList = new List<MethodInfo>();
			Type type = target.GetType();
			ListMethodsFilter listMethodsFilter = null;
			IntPtr method_ptr = (IntPtr)0;
			((Delegate)listMethodsFilter).m_target = null;
			((Delegate)listMethodsFilter).method = (IntPtr)(void*)(ulong)(UIntPtr/*delegate*<MethodInfo, bool>*/)(&IsValidActionMethod);
			((Delegate)listMethodsFilter).method_ptr = method_ptr;
			return ClassUtils.ListMethods(outList, type, listMethodsFilter, BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
		}

		[Token(Token = "0x60000D6")]
		[Address(RVA = "0x13E1E24", Offset = "0x13E1E24", Length = "0x224")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EC5090]);\n\tv23 = *([v22 @ X8_v29]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2028AD8]) = v42;\nL_0019:\n\tv46 = System.Reflection.MethodBase::get_IsPublic(method);\n\tv105 = v46 == 0;\n\tif (v105) goto L_FFFFFFFF;\n\tv147 = System.Reflection.MethodInfo::get_ReturnType(method);\n\tgoto L_0035;\n\tv209 = *([v151 @ X8_v8+E0]);\n\tv210 = v209 == 0;\n\tv211 = ~v210;\n\tif (v211) goto L_0035;\n\tv283 = v151;\n\tv213 = \"il2cpp_codegen_runtime_class_init\"(v283, v146, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0035:\n\tv217 = System.Type::GetTypeFromHandle(System.Void);\n\tv193 = System.Type::op_Inequality(v147, v217);\n\tv286 = v193 == 0;\n\tv198 = ~v286;\n\tif (v198) goto L_FFFFFFFF;\n\tv194 = System.Reflection.MethodBase::get_IsAbstract(method);\n\tv289 = v194 == 0;\n\tv199 = ~v289;\n\tif (v199) goto L_FFFFFFFF;\n\tv131 = System.Reflection.MethodBase::GetParameters(method);\n\tv158 = v131.Length > 1;\n\tif (v158) goto L_FFFFFFFF;\n\tgoto L_006A;\n\tv299 = *([v294 @ X0_v22+E0]);\n\tv300 = v299 == 0;\n\tv301 = ~v300;\n\tif (v301) goto L_006A;\n\tv303 = \"il2cpp_codegen_runtime_class_init\"(v294, v128, v118, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_006A:\n\tv308 = System.Type::GetTypeFromHandle(System.ObsoleteAttribute);\n\tv192 = System.Reflection.MemberInfo::GetCustomAttributes(method, v308, 0);\n\tv311 = v192 == 0;\n\tif (v311) goto L_008A;\n\tv197 = v192.Length == 0;\n\tif (v197) goto L_008A;\nL_007F:\n\treturn returnVal2;\nL_008A:\n\tv53 = v131.Length != 1;\n\tif (v53) goto L_FFFFFFFF;\n\tv324 = System.Reflection.ParameterInfo::get_ParameterType(v131[0]);\n\tgoto L_00A4;\n\tv329 = *([v100 @ X8_v19+E0]);\n\tv330 = v329 == 0;\n\tv331 = ~v330;\n\tif (v331) goto L_00A4;\n\tv337 = v100;\n\tv333 = \"il2cpp_codegen_runtime_class_init\"(v337, v323, v80, v48, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00A4:\n\tv94 = System.Type::GetTypeFromHandle(UnityEngine.Object);\n\tv318 = System.Type::IsSubclassOf(v324, v94);\n\tv340 = v318 == 0;\n\tv319 = ~v340;\n\tif (v319) goto L_FFFFFFFF;\n\tgoto L_00C4;\n\tv346 = *([v342 @ X0_v37 (Il2CppClass<LunarConsolePluginInternal.LunarConsoleActionCall>)+E0]);\n\tv347 = v346 == 0;\n\tv348 = ~v347;\n\tif (v348) goto L_00C4;\n\tv355 = \"il2cpp_codegen_runtime_class_init\"(v342, v92, v315, v48, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv350 = LunarConsolePluginInternal.LunarConsoleActionCall;\nL_00C4:\n\tv195 = System.Array::IndexOf(v205.kParamTypes, v324);\n\tv200 = v195 + 1;\n\tv170 = v200 == 0;\n\tif (v170) goto L_FFFFFFFF;\n\tgoto L_007F;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 137 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool IsValidActionMethod(MethodInfo method)
		{
			if (method.IsPublic)
			{
				Type returnType = method.ReturnType;
				Type typeFromHandle = typeof(void);
				if (!(returnType != typeFromHandle) && !method.IsAbstract)
				{
					ParameterInfo[] parameters = method.GetParameters();
					if (parameters.Length <= 1)
					{
						Type typeFromHandle2 = typeof(ObsoleteAttribute);
						object[] customAttributes = method.GetCustomAttributes(typeFromHandle2, inherit: false);
						if (customAttributes == null || customAttributes.Length == 0)
						{
							if (parameters.Length == 1)
							{
								Type parameterType = parameters[0].ParameterType;
								Type typeFromHandle3 = typeof(UnityEngine.Object);
								if (!parameterType.IsSubclassOf(typeFromHandle3))
								{
									int num = Array.IndexOf(kParamTypes, parameterType);
									if (num + 1 == 0)
									{
										goto IL_0158;
									}
								}
							}
							return true;
						}
					}
				}
			}
			goto IL_0158;
			IL_0158:
			return false;
		}

		[Token(Token = "0x60000DA")]
		[Address(RVA = "0x13E2060", Offset = "0x13E2060", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public LunarConsoleActionCall()
		{
		}

		[Token(Token = "0x60000DB")]
		[Address(RVA = "0x13E2068", Offset = "0x13E2068", Length = "0x1B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv16 = *([1EEF968]);\n\tv17 = *([v16 @ X8_v36]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([2028AD9]) = v37;\nL_0016:\n\t// 22 NewArr v42 @ X0_v3 (System.Type[]), typeof(System.Type[]), 4\n\tgoto L_002A;\n\tv53 = *([v47 @ X8_v7+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tgoto L_002A;\n\tv63 = v47;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v63, v40, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_002A:\n\tv62 = System.Type::GetTypeFromHandle(System.Int32);\n\tv66 = v62 == 0;\n\tif (v66) goto L_0037;\n\t// 51 IsInst v111 @ X0_v33, typeof(System.Type), v62 @ X0_v6 (System.Type)\nL_0037:\n\tv118 = v42.Length == 0;\n\tif (v118) goto L_0099;\n\tv42[0] = v62;\n\tv123 = System.Type::GetTypeFromHandle(System.Single);\n\tv231 = v123 == 0;\n\tif (v231) goto L_0049;\n\t// 69 IsInst v219 @ X0_v31, typeof(System.Type), v123 @ X0_v18 (System.Type)\nL_0049:\n\tv236 = v42.Length < 1;\n\tv157 = ~v236;\n\tv153 = v42.Length - 1;\n\tv145 = v153 == 0;\n\tv237 = ~v157;\n\tv125 = v237 | v145;\n\tif (v125) goto L_0099;\n\tv42[1] = v123;\n\tv242 = System.Type::GetTypeFromHandle(System.String);\n\tv243 = v242 == 0;\n\tif (v243) goto L_0065;\n\t// 97 IsInst v220 @ X0_v29, typeof(System.Type), v242 @ X0_v21 (System.Type)\nL_0065:\n\tv246 = v42.Length < 2;\n\tv158 = ~v246;\n\tv154 = v42.Length - 2;\n\tv146 = v154 == 0;\n\tv247 = ~v158;\n\tv126 = v247 | v146;\n\tif (v126) goto L_0099;\n\tv42[2] = v242;\n\tv252 = System.Type::GetTypeFromHandle(System.Boolean);\n\tv253 = v252 == 0;\n\tif (v253) goto L_0081;\n\t// 125 IsInst v221 @ X0_v27, typeof(System.Type), v252 @ X0_v24 (System.Type)\nL_0081:\n\tv256 = v42.Length < 3;\n\tv159 = ~v256;\n\tv155 = v42.Length - 3;\n\tv147 = v155 == 0;\n\tv257 = ~v159;\n\tv127 = v257 | v147;\n\tif (v127) goto L_0099;\n\tv42[3] = v252;\n\tv199.kParamTypes = v42;\n\treturn;\nL_0099:\n\tv180 = new System.IndexOutOfRangeException();\n\tgoto L_009E;\n\tv230 = new System.ArrayTypeMismatchException();\nL_009E:\n\tthrow v233;\n\tthrow System.NullReferenceException;\n// 98 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static LunarConsoleActionCall()
		{
			//IL_00e1: Expected O, but got I4
			//IL_0191: Expected O, but got I4
			//IL_0241: Expected O, but got I4
			Type[] array = new Type[4];
			Type typeFromHandle = typeof(int);
			if ((object)typeFromHandle != null)
			{
				object obj = typeFromHandle as Type;
			}
			if (array.Length != 0)
			{
				array[0] = typeFromHandle;
				Type typeFromHandle2 = typeof(float);
				if ((object)typeFromHandle2 != null)
				{
					object obj2 = typeFromHandle2 as Type;
				}
				bool flag = array.Length < 1;
				bool flag2 = !flag;
				object obj3 = array.Length - 1;
				bool flag3 = obj3 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = typeFromHandle2;
					Type typeFromHandle3 = typeof(string);
					if ((object)typeFromHandle3 != null)
					{
						object obj4 = typeFromHandle3 as Type;
					}
					bool flag5 = array.Length < 2;
					bool flag6 = !flag5;
					object obj5 = array.Length - 2;
					bool flag7 = obj5 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = typeFromHandle3;
						Type typeFromHandle4 = typeof(bool);
						if ((object)typeFromHandle4 != null)
						{
							object obj6 = typeFromHandle4 as Type;
						}
						bool flag9 = array.Length < 3;
						bool flag10 = !flag9;
						object obj7 = array.Length - 3;
						bool flag11 = obj7 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array[3] = typeFromHandle4;
							kParamTypes = array;
							return;
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}
	}
}
