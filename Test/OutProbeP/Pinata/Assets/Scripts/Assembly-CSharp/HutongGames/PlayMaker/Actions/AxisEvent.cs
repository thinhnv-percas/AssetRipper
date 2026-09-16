using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75D264", Offset = "0x75D264")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75D264", Offset = "0x75D264")]
	[Token(Token = "0x2000340")]
	public class AxisEvent : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8770", Offset = "0x7C8770")]
		[Token(Token = "0x4001ABC")]
		[FieldOffset(Offset = "0x50")]
		public FsmString horizontalAxis;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C87A8", Offset = "0x7C87A8")]
		[Token(Token = "0x4001ABD")]
		[FieldOffset(Offset = "0x58")]
		public FsmString verticalAxis;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C87E0", Offset = "0x7C87E0")]
		[Token(Token = "0x4001ABE")]
		[FieldOffset(Offset = "0x60")]
		public FsmEvent leftEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8818", Offset = "0x7C8818")]
		[Token(Token = "0x4001ABF")]
		[FieldOffset(Offset = "0x68")]
		public FsmEvent rightEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8850", Offset = "0x7C8850")]
		[Token(Token = "0x4001AC0")]
		[FieldOffset(Offset = "0x70")]
		public FsmEvent upEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8888", Offset = "0x7C8888")]
		[Token(Token = "0x4001AC1")]
		[FieldOffset(Offset = "0x78")]
		public FsmEvent downEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C88C0", Offset = "0x7C88C0")]
		[Token(Token = "0x4001AC2")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent anyDirection;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C88F8", Offset = "0x7C88F8")]
		[Token(Token = "0x4001AC3")]
		[FieldOffset(Offset = "0x88")]
		public FsmEvent noDirection;

		[Token(Token = "0x6001045")]
		[Address(RVA = "0xA8B060", Offset = "0xA8B060", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1F0BE58]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20221C3]) = v38;\nL_0017:\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"Horizontal\");\n\tthis.horizontalAxis = v43;\n\tv48 = HutongGames.PlayMaker.FsmString::op_Implicit(\"Vertical\");\n\tthis.verticalAxis = v48;\n\tthis.upEvent = 0;\n\tthis.anyDirection = 0;\n\tthis.leftEvent = 0;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmString fsmString = "Horizontal";
			horizontalAxis = fsmString;
			FsmString fsmString2 = "Vertical";
			verticalAxis = fsmString2;
			upEvent = null;
			anyDirection = null;
			leftEvent = null;
		}

		[Token(Token = "0x6001046")]
		[Address(RVA = "0xA8B0DC", Offset = "0xA8B0DC", Length = "0x1D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EBF348]);\n\tv23 = *([v22 @ X8_v20]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20221C4]) = v42;\nL_001A:\n\tv47 = HutongGames.PlayMaker.FsmString::get_Value(this.horizontalAxis);\n\tv117 = System.String::op_Inequality(v47, \"\");\n\tv119 = v117 == 0;\n\tif (v119) goto L_0030;\n\tv193 = HutongGames.PlayMaker.FsmString::get_Value(this.horizontalAxis);\n\tv189 = UnityEngine.Input::GetAxis(v193);\nL_0030:\n\tv197 = HutongGames.PlayMaker.FsmString::get_Value(this.verticalAxis);\n\tv198 = System.String::op_Inequality(v197, \"\");\n\tv200 = v198 == 0;\n\tif (v200) goto L_0040;\n\tv207 = HutongGames.PlayMaker.FsmString::get_Value(this.verticalAxis);\n\tv189 = UnityEngine.Input::GetAxis(v207);\nL_0040:\n\tv189 = v92 * v92;\n\tv210 = v86 * v86;\n\tv189 = v189 + v210;\n\tv214 = 0xBCCE68(&v189 @ V0_v17 (System.Single), 0, 0, v27, v28, v29, v30, v31, 0, v210, v34, v35, v36, v37, v38, v39);\n\tv216 = v214 & 1;\n\tv217 = v216 == 0;\n\tif (v217) goto L_0056;\n\tv99 = this.noDirection;\n\tv219 = this.noDirection == 0;\n\tv220 = ~v219;\n\tif (v220) goto L_00A6;\n\tgoto L_00AE;\nL_0056:\n\tgoto L_005E;\n\tv232 = *([v223 @ X0_v17 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv233 = v232 == 0;\n\tv234 = ~v233;\n\tif (v234) goto L_005E;\n\tv236 = \"il2cpp_codegen_runtime_class_init\"(v223, v172, v95, v27, v28, v29, v30, v31, v213, v210, v34, v35, v36, v37, v38, v39);\nL_005E:\n\tv175 = 0x6D29A0(UnityEngine.Mathf, 0, 0, v27, v28, v29, v30, v31, v86, v92, v34, v35, v36, v37, v38, v39);\n\tv189 = v86 * 57.29578f;\n\tv189 = v189 + 45f;\n\tv160 = v189 + 360f;\n\tv130 = v189 >= 0;\n\tif (v130) goto L_0079;\n\tgoto L_0079;\nL_0079:\n\tv189 = v189 / 90f;\n\tv262 = v189 < 3;\n\tv154 = ~v262;\n\tv151 = v189 - 3;\n\tv145 = v151 == 0;\n\tv263 = ~v145;\n\tv121 = v154 & v263;\n\tif (v121) goto L_009F;\n\tv127 = 0x1818000 + 0xDE8;\n\tv183 = *([v127 @ X9_v2 (System.Int32)+v189 @ V0_v17 (System.Single)*4]) + v127;\n\t// 139 IndirectJump v183 @ X8_v16, v175 @ X0_v19, v175 @ X0_v19, 0, 0, v27 @ X3, v28 @ X4, v29 @ X5, v30 @ X6, v31 @ X7, v189 @ V0_v17 (System.Single), v160 @ V1_v8 (System.Single), 90f, v35 @ V3, v36 @ V4, v37 @ V5, v38 @ V6, v39 @ V7\n\tX1 = *([X19+68]);\n\tTEMP = ~TEMP;\n\t// 143 ConditionalJump @b38, TEMP\n\tgoto L_009F;\n\tX1 = *([X19+70]);\n\tTEMP = ~TEMP;\n\t// 148 ConditionalJump @b38, TEMP\n\tgoto L_009F;\n\tX1 = *([X19+60]);\n\tTEMP = ~TEMP;\n\t// 153 ConditionalJump @b38, TEMP\n\tgoto L_009F;\n\tX1 = *([X19+78]);\n\tTEMP = ~TEMP;\n\t// 158 ConditionalJump @b38, TEMP\nL_009F:\n\tv99 = this.anyDirection;\n\tv230 = this.anyDirection == 0;\n\tif (v230) goto L_00AE;\nL_00A6:\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, v99);\nL_00AE:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 101 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			//IL_01c9: Expected O, but got I
			string value = horizontalAxis.Value;
			bool flag = value != "";
			bool flag2 = !flag;
			float num = 0f;
			float axis;
			if (!flag2)
			{
				string value2 = horizontalAxis.Value;
				axis = Input.GetAxis(value2);
				num = axis;
			}
			string value3 = verticalAxis.Value;
			bool flag3 = value3 != "";
			bool flag4 = !flag3;
			float num2 = 0f;
			if (!flag4)
			{
				string value4 = verticalAxis.Value;
				axis = Input.GetAxis(value4);
				num2 = axis;
			}
			axis = num * num;
			float num3 = num2 * num2;
			axis += num3;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @BCCE68 (inside System.Single::IsNaN +0x250)");
			object obj = default(object);
			FsmEvent fsmEvent;
			if ((uint)((ulong)(long)(IntPtr)obj & 1uL) != 0)
			{
				fsmEvent = noDirection;
				if (noDirection == null)
				{
					return;
				}
			}
			else
			{
				Il2CppRuntime.Boundary("SYSTEM_API:atan2f", "Method not found @6D29A0 (native atan2f)");
				axis = num2 * 57.29578f;
				axis += 45f;
				float num4 = axis + 360f;
				if (axis < 0f)
				{
					axis = num4;
				}
				axis /= 90f;
				bool flag5 = axis < 4E-45f;
				bool flag6 = !flag5;
				float num5 = axis - 4E-45f;
				bool flag7 = num5 == 0f;
				bool flag8 = !flag7;
				if (!(flag6 && flag8))
				{
					int num6 = 25264128 + 3560;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v127 @ X9_v2 (System.Int32)+v189 @ V0_v17 (System.Single)*4]");
					object obj2 = 0L + (long)num6;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v183 @ X8_v16 (should have been resolved before IL gen)");
				}
				fsmEvent = anyDirection;
				if (anyDirection == null)
				{
					return;
				}
			}
			Fsm.Event(fsmEvent);
		}

		[Token(Token = "0x6001047")]
		[Address(RVA = "0xA8B2B4", Offset = "0xA8B2B4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AxisEvent()
		{
		}
	}
}
