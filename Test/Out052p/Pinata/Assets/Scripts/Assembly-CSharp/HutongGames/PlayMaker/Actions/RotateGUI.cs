using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x756C20", Offset = "0x756C20")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x756C20", Offset = "0x756C20")]
	[Token(Token = "0x2000208")]
	public class RotateGUI : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x40014BD")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat angle;

		[RequiredField]
		[Token(Token = "0x40014BE")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat pivotX;

		[RequiredField]
		[Token(Token = "0x40014BF")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat pivotY;

		[Token(Token = "0x40014C0")]
		[FieldOffset(Offset = "0x68")]
		public bool normalized;

		[Token(Token = "0x40014C1")]
		[FieldOffset(Offset = "0x69")]
		public bool applyGlobally;

		[Token(Token = "0x40014C2")]
		[FieldOffset(Offset = "0x6A")]
		private bool applied;

		[Token(Token = "0x6000A85")]
		[Address(RVA = "0xB24828", Offset = "0xB24828", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0f);\n\tthis.angle = v14;\n\tv18 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0.5f);\n\tthis.pivotX = v18;\n\tv21 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0.5f);\n\tthis.pivotY = v21;\n\tthis.normalized = 1;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmFloat fsmFloat = 0f;
			angle = fsmFloat;
			FsmFloat fsmFloat2 = 0.5f;
			pivotX = fsmFloat2;
			FsmFloat fsmFloat3 = 0.5f;
			pivotY = fsmFloat3;
			normalized = true;
			applyGlobally = false;
		}

		[Token(Token = "0x6000A86")]
		[Address(RVA = "0xB24888", Offset = "0xB24888", Length = "0x1D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = &v15 @ stack_-10_v2;\n\tgoto L_0016;\n\tv24 = *([1EC5F00]);\n\tv25 = *([v24 @ X8_v28]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20225D2]) = v44;\nL_0016:\n\t*([v14 @ X29_v1-28]) = 0;\n\tv46 = ~this.applied;\n\tv47 = ~v46;\n\tif (v47) goto L_00AB;\n\tv152 = HutongGames.PlayMaker.FsmFloat::get_Value(this.pivotX);\n\tv208 = HutongGames.PlayMaker.FsmFloat::get_Value(this.pivotY);\n\tv209 = &v15 @ stack_-10_v2 - 0x28;\n\tv211 = 0x1588A6C(v209, 0, v28, v29, v30, v31, v32, v33, v152, v208, v36, v37, v38, v39, v40, v41);\n\tv212 = ~this.normalized;\n\tif (v212) goto L_003E;\n\tv215 = UnityEngine.Screen::get_width();\n\tv221 = *([v14 @ X29_v1-28]) * v215;\n\t*([v14 @ X29_v1-28]) = v221;\n\tv219 = UnityEngine.Screen::get_height();\n\tv217 = *([v14 @ X29_v1-24]) * v219;\n\t*([v14 @ X29_v1-24]) = v217;\nL_003E:\n\tv130 = HutongGames.PlayMaker.FsmFloat::get_Value(this.angle);\n\t// 66 MakeStruct v118 @ AGGB2495C_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), [v14 @ X29_v1-28], [v14 @ X29_v1-24]\n\tUnityEngine.GUIUtility::RotateAroundPivot(v130, v118);\n\tv138 = ~this.applyGlobally;\n\tif (v138) goto L_00AB;\n\tgoto L_0055;\n\tv230 = *([v226 @ X0_v12+E0]);\n\tv231 = v230 == 0;\n\tv232 = ~v231;\n\tif (v232) goto L_0055;\n\tv234 = \"il2cpp_codegen_runtime_class_init\"(v226, v132, v28, v29, v30, v31, v32, v33, v130, v125, v122, v37, v38, v39, v40, v41);\nL_0055:\n\tv239 = UnityEngine.GUI::get_matrix();\n\tgoto L_007E;\n\tv245 = *([v241 @ X0_v16+E0]);\n\tv246 = v245 == 0;\n\tv247 = ~v246;\n\tif (v247) goto L_007E;\n\tv249 = \"il2cpp_codegen_runtime_class_init\"(v241, v132, v28, v29, v30, v31, v32, v33, v130, v125, v122, v37, v38, v39, v40, v41);\nL_007E:\n\tgoto L_008A;\n\tv260 = *([1ED14F8]);\n\tv261 = *([v260 @ X8_v22]);\n\tv262 = \"il2cpp_codegen_initialize_method\"(v261, v132, v28, v29, v30, v31, v32, v33, v253, v252, v255, v254, v38, v39, v40, v41);\n\tv265 = 0 | 1;\n\t*([202262E]) = v265;\nL_008A:\n\t*([v14 @ X29_v1-50]) = v239.m02;\n\t*([v14 @ X29_v1-40]) = v239.m03;\n\t*([v14 @ X29_v1-70]) = v239.m00;\n\t*([v14 @ X29_v1-60]) = v239.m01;\n\tgoto L_0098;\n\tv271 = *([v267 @ X0_v19 (Il2CppClass<PlayMakerGUI>)+E0]);\n\tv272 = v271 == 0;\n\tv273 = ~v272;\n\tgoto L_0098;\n\tv279 = \"il2cpp_codegen_runtime_class_init\"(v267, v132, v28, v29, v30, v31, v32, v33, v266, v124, v121, v66, v38, v39, v40, v41);\n\tv274 = PlayMakerGUI;\nL_0098:\n\tv140 = *([v134 @ X0_v20 (Il2CppClass<PlayMakerGUI>)+B8]);\n\t*([v140 @ X8_v19 (Il2CppStaticFields<PlayMakerGUI>)+A0]) = *([v14 @ X29_v1-40]);\n\t*([v140 @ X8_v19 (Il2CppStaticFields<PlayMakerGUI>)+90]) = *([v14 @ X29_v1-50]);\n\t*([v140 @ X8_v19 (Il2CppStaticFields<PlayMakerGUI>)+80]) = *([v14 @ X29_v1-60]);\n\tv140.guiMatrix = *([v14 @ X29_v1-70]);\n\tthis.applied = 1;\nL_00AB:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 107 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnGUI()
		{
			//IL_003f: Expected O, but got I
			//IL_00dd: Expected F4, but got I
			//IL_00f2: Expected F4, but got I
			//IL_0087: Expected O, but got I
			//IL_00af: Expected O, but got I
			//IL_019a: Expected I, but got O
			//IL_01a8: Expected I, but got O
			//IL_01e0: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			if (!applied)
			{
				float value = pivotX.Value;
				float value2 = pivotY.Value;
				object obj3 = (long)(IntPtr)obj2 - 40L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
				if (normalized)
				{
					int width = Screen.width;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ X29_v1-28]");
					object obj4 = 0L * (long)width;
					int height = Screen.height;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ X29_v1-24]");
					object obj5 = 0L * (long)height;
				}
				float value3 = angle.Value;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ X29_v1-28]");
				Vector2 pivotPoint = default(Vector2);
				pivotPoint.x = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ X29_v1-24]");
				pivotPoint.y = 0f;
				GUIUtility.RotateAroundPivot(value3, pivotPoint);
				if (applyGlobally)
				{
					Matrix4x4 matrix = GUI.matrix;
					_ = matrix.m02;
					_ = matrix.m03;
					_ = matrix.m00;
					_ = matrix.m01;
					IntPtr intPtr = (IntPtr)typeof(PlayMakerGUI);
					IntPtr intPtr2 = (IntPtr)PlayMakerGUI.fsmList;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ X29_v1-40]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ X29_v1-50]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ X29_v1-60]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ X29_v1-70]");
					PlayMakerGUI.guiMatrix = (Matrix4x4)0;
					applied = true;
				}
			}
		}

		[Token(Token = "0x6000A87")]
		[Address(RVA = "0xB24A5C", Offset = "0xB24A5C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.applied = 0;\n\treturn;\n")]
		public override void OnUpdate()
		{
			applied = false;
		}

		[Token(Token = "0x6000A88")]
		[Address(RVA = "0xB24A64", Offset = "0xB24A64", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RotateGUI()
		{
		}
	}
}
