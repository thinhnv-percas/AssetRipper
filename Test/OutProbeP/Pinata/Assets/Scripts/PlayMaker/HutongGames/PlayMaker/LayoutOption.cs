using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	[Token(Token = "0x200004A")]
	public class LayoutOption
	{
		[Token(Token = "0x2000095")]
		public enum LayoutOptionType
		{
			[Token(Token = "0x4000372")]
			Width = 0,
			[Token(Token = "0x4000373")]
			Height = 1,
			[Token(Token = "0x4000374")]
			MinWidth = 2,
			[Token(Token = "0x4000375")]
			MaxWidth = 3,
			[Token(Token = "0x4000376")]
			MinHeight = 4,
			[Token(Token = "0x4000377")]
			MaxHeight = 5,
			[Token(Token = "0x4000378")]
			ExpandWidth = 6,
			[Token(Token = "0x4000379")]
			ExpandHeight = 7
		}

		[Token(Token = "0x4000119")]
		[FieldOffset(Offset = "0x10")]
		public LayoutOptionType option;

		[Token(Token = "0x400011A")]
		[FieldOffset(Offset = "0x18")]
		public FsmFloat floatParam;

		[Token(Token = "0x400011B")]
		[FieldOffset(Offset = "0x20")]
		public FsmBool boolParam;

		[Token(Token = "0x6000153")]
		[Address(RVA = "0xE51954", Offset = "0xE51954", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tv13 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0f);\n\tthis.floatParam = v13;\n\tv16 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.boolParam = v16;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public LayoutOption()
		{
			FsmFloat fsmFloat = 0f;
			floatParam = fsmFloat;
			FsmBool fsmBool = false;
			boolParam = fsmBool;
		}

		[Token(Token = "0x6000154")]
		[Address(RVA = "0xE519D4", Offset = "0xE519D4", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EBEA48]);\n\tv25 = *([v24 @ X8_v8]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, source, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20247AD]) = v43;\nL_0018:\n\tSystem.Object::.ctor(this);\n\tthis.option = source.option;\n\tv52 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v52, source.floatParam);\n\tthis.floatParam = v52;\n\tv62 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v62, source.boolParam);\n\tthis.boolParam = v62;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public LayoutOption(LayoutOption source)
		{
			option = source.option;
			floatParam = new FsmFloat(source.floatParam);
			boolParam = new FsmBool(source.boolParam);
		}

		[Token(Token = "0x6000155")]
		[Address(RVA = "0xE51998", Offset = "0xE51998", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0f);\n\tthis.floatParam = v12;\n\tv15 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.boolParam = v15;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ResetParameters()
		{
			FsmFloat fsmFloat = 0f;
			floatParam = fsmFloat;
			FsmBool fsmBool = false;
			boolParam = fsmBool;
		}

		[Token(Token = "0x6000156")]
		[Address(RVA = "0xE51A90", Offset = "0xE51A90", Length = "0x120")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.option;\n\tv8 = this.option < 7;\n\tv9 = ~v8;\n\tv10 = this.option - 7;\n\tv12 = v10 == 0;\n\tv17 = ~v12;\n\tv18 = v9 & v17;\n\tif (v18) goto L_0046;\n\tv20 = 0x181C000 + 0x794;\n\tv22 = *([v20 @ X9_v2 (System.Int32)+v6 @ X8_v1 (HutongGames.PlayMaker.LayoutOption+LayoutOptionType)*4]) + v20;\n\t// 21 IndirectJump v22 @ X8_v3, this @ X0 (HutongGames.PlayMaker.LayoutOption), this @ X0 (HutongGames.PlayMaker.LayoutOption), methodInfo @ X1 (Il2CppMethodInfo), v24 @ X2, v25 @ X3, v26 @ X4, v27 @ X5, v28 @ X6, v29 @ X7, v30 @ V0, v31 @ V1, v32 @ V2, v33 @ V3, v34 @ V4, v35 @ V5, v36 @ V6, v37 @ V7\n\tX0 = *([X0+18]);\n\tif (TEMP) goto L_0075;\n\tX1 = 0;\n\tV0 = HutongGames.PlayMaker.FsmFloat::get_Value(X0, X1);\n\tX0 = 0;\n\tX29 = stack[0];\n\tX30 = stack[8];\n\t// 30 ShiftStack 16\n\tX0 = UnityEngine.GUILayout::Width(V0, X0);\n\treturn X0;\n\tX0 = *([X0+18]);\n\tif (TEMP) goto L_0075;\n\tX1 = 0;\n\tV0 = HutongGames.PlayMaker.FsmFloat::get_Value(X0, X1);\n\tX0 = 0;\n\tX29 = stack[0];\n\tX30 = stack[8];\n\t// 41 ShiftStack 16\n\tX0 = UnityEngine.GUILayout::MinWidth(V0, X0);\n\treturn X0;\n\tX0 = *([X0+18]);\n\tif (TEMP) goto L_0075;\n\tX1 = 0;\n\tV0 = HutongGames.PlayMaker.FsmFloat::get_Value(X0, X1);\n\tX0 = 0;\n\tX29 = stack[0];\n\tX30 = stack[8];\n\t// 52 ShiftStack 16\n\tX0 = UnityEngine.GUILayout::MaxWidth(V0, X0);\n\treturn X0;\n\tX0 = *([X0+18]);\n\tif (TEMP) goto L_0075;\n\tX1 = 0;\n\tV0 = HutongGames.PlayMaker.FsmFloat::get_Value(X0, X1);\n\tX0 = 0;\n\tX29 = stack[0];\n\tX30 = stack[8];\n\t// 63 ShiftStack 16\n\tX0 = UnityEngine.GUILayout::MinHeight(V0, X0);\n\treturn X0;\nL_0046:\n\treturn 0;\n\tX0 = *([X0+18]);\n\tif (TEMP) goto L_0075;\n\tX1 = 0;\n\tV0 = HutongGames.PlayMaker.FsmFloat::get_Value(X0, X1);\n\tX0 = 0;\n\tX29 = stack[0];\n\tX30 = stack[8];\n\t// 79 ShiftStack 16\n\tX0 = UnityEngine.GUILayout::Height(V0, X0);\n\treturn X0;\n\tX0 = *([X0+18]);\n\tif (TEMP) goto L_0075;\n\tX1 = 0;\n\tV0 = HutongGames.PlayMaker.FsmFloat::get_Value(X0, X1);\n\tX0 = 0;\n\tX29 = stack[0];\n\tX30 = stack[8];\n\t// 90 ShiftStack 16\n\tX0 = UnityEngine.GUILayout::MaxHeight(V0, X0);\n\treturn X0;\n\tX0 = *([X0+20]);\n\tif (TEMP) goto L_0075;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmBool::get_Value(X0, X1);\n\tX0 = X0 & 1;\n\tX1 = 0;\n\tX29 = stack[0];\n\tX30 = stack[8];\n\t// 102 ShiftStack 16\n\tX0 = UnityEngine.GUILayout::ExpandWidth(X0, X1);\n\treturn X0;\n\tX0 = *([X0+20]);\n\tif (TEMP) goto L_0075;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmBool::get_Value(X0, X1);\n\tX0 = X0 & 1;\n\tX1 = 0;\n\tX29 = stack[0];\n\tX30 = stack[8];\n\t// 114 ShiftStack 16\n\tX0 = UnityEngine.GUILayout::ExpandHeight(X0, X1);\n\treturn X0;\nL_0075:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GUILayoutOption GetGUILayoutOption()
		{
			//IL_008f: Expected O, but got I
			LayoutOptionType layoutOptionType = option;
			bool flag = option < LayoutOptionType.ExpandHeight;
			bool flag2 = !flag;
			int num = (int)(option - 7);
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num2 = 25280512 + 1940;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v20 @ X9_v2 (System.Int32)+v6 @ X8_v1 (HutongGames.PlayMaker.LayoutOption+LayoutOptionType)*4]");
				object obj = 0L + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v22 @ X8_v3 (should have been resolved before IL gen)");
			}
			return null;
		}
	}
}
