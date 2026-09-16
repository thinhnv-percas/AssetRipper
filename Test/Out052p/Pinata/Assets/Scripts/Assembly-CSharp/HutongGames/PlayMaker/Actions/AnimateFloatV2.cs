using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x751C04", Offset = "0x751C04")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x751C04", Offset = "0x751C04")]
	[Token(Token = "0x200010F")]
	public class AnimateFloatV2 : AnimateFsmAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A1420", Offset = "0x7A1420")]
		[Token(Token = "0x4001018")]
		[FieldOffset(Offset = "0xD8")]
		public FsmFloat floatVariable;

		[RequiredField]
		[Token(Token = "0x4001019")]
		[FieldOffset(Offset = "0xE0")]
		public FsmAnimationCurve animCurve;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7A146C", Offset = "0x7A146C")]
		[Token(Token = "0x400101A")]
		[FieldOffset(Offset = "0xE8")]
		public Calculation calculation;

		[Token(Token = "0x400101B")]
		[FieldOffset(Offset = "0xEC")]
		private bool finishInNextStep;

		[Token(Token = "0x600061D")]
		[Address(RVA = "0xA14F38", Offset = "0xA14F38", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EA5830]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021D2D]) = v38;\nL_0014:\n\tHutongGames.PlayMaker.Actions.AnimateFsmAction::Reset(this);\n\tv43 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v43);\n\tv43.useVariable = 1;\n\tthis.floatVariable = v43;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			floatVariable = fsmFloat;
		}

		[Token(Token = "0x600061E")]
		[Address(RVA = "0xA14FB4", Offset = "0xA14FB4", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv19 = *([1EC2D48]);\n\tv20 = *([v19 @ X8_v4]);\n\tv21 = \"il2cpp_codegen_initialize_method\"(v20, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv39 = 0 | 1;\n\t*([2021D2E]) = v39;\nL_0015:\n\tHutongGames.PlayMaker.Actions.AnimateFsmAction::OnEnter(this);\n\tthis.finishInNextStep = 0;\n\tv44 = 0xA15EDC(this, 1, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\treturn;\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+B8]) = X0;\n\tX0 = *([X20]);\n\tX1 = 0 | 1;\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19+D8]);\n\tX20 = X0;\n\t*([X19+C0]) = X20;\n\tif (TEMP) goto L_0068;\n\tX0 = X8;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.NamedVariable::get_IsNone(X0, X1);\n\tV0 = 0;\n\tTEMP = X0 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0033;\n\tX0 = *([X19+D8]);\n\tif (TEMP) goto L_0069;\n\tX1 = 0;\n\tV0 = HutongGames.PlayMaker.FsmFloat::get_Value(X0, X1);\nL_0033:\n\tTEMP = X20 == 0;\n\tif (TEMP) goto L_0068;\n\tX8 = *([X20+18]);\n\tif (TEMP) goto L_006A;\n\t*([X20+20]) = V0;\n\tX8 = *([1EE7038]);\n\tX1 = 0 | 1;\n\tX0 = *([X8]);\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+B0]) = X0;\n\tif (TEMP) goto L_0069;\n\tX8 = *([X0+18]);\n\tif (TEMP) goto L_006A;\n\tX8 = *([X19+E8]);\n\tX1 = 0 | 1;\n\t*([X0+20]) = X8;\n\tX8 = *([1EF1080]);\n\tX0 = *([X8]);\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19+E0]);\n\tX20 = X0;\n\t*([X19+A8]) = X20;\n\tif (TEMP) goto L_0068;\n\tif (TEMP) goto L_0068;\n\tX21 = *([X8+10]);\n\tif (TEMP) goto L_005B;\n\tX8 = *([X20]);\n\tX0 = X21;\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_006E;\nL_005B:\n\tX8 = *([X20+18]);\n\tif (TEMP) goto L_006A;\n\t*([X20+20]) = X21;\n\tX0 = X19;\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX21 = stack[0];\n\t// 101 ShiftStack 48\n\tHutongGames.PlayMaker.Actions.AnimateFsmAction::Init(X0, X1);\n\treturn;\nL_0068:\n\tX0 = 0;\nL_0069:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_006A:\n\tX0 = 0x8D82E4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_006B:\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_006E:\n\tX0 = 0x8D82D8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_006B;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			base.OnEnter();
			finishInNextStep = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @A15EDC (inside HutongGames.PlayMaker.Actions.AnimateFsmAction::CheckFinished +0xA4)");
		}

		[Token(Token = "0x600061F")]
		[Address(RVA = "0xA15110", Offset = "0xA15110", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void OnExit()
		{
		}

		[Token(Token = "0x6000620")]
		[Address(RVA = "0xA15114", Offset = "0xA15114", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.AnimateFsmAction::OnUpdate(this);\n\tv14 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.floatVariable);\n\tv49 = v14 == 0;\n\tv50 = ~v49;\n\tif (v50) goto L_001F;\n\tv70 = ~this.isRunning;\n\tif (v70) goto L_001F;\n\tv56 = this.resultFloats;\n\tv83 = v56.Length == 0;\n\tif (v83) goto L_0055;\n\tv53 = this.floatVariable;\n\tv53.value = v56[0];\nL_001F:\n\tv75 = ~this.finishInNextStep;\n\tif (v75) goto L_0031;\n\tv87 = ~this.looping;\n\tv88 = ~v87;\n\tif (v88) goto L_0031;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\tv92 = this.finishEvent == 0;\n\tif (v92) goto L_0031;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.finishEvent);\nL_0031:\n\tv96 = ~this.finishAction;\n\tif (v96) goto L_0051;\n\tv101 = ~this.finishInNextStep;\n\tv102 = ~v101;\n\tif (v102) goto L_0051;\n\tv66 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.floatVariable);\n\tv124 = v66 == 0;\n\tv125 = ~v124;\n\tif (v125) goto L_004C;\n\tv57 = this.resultFloats;\n\tv84 = v57.Length == 0;\n\tif (v84) goto L_0055;\n\tv54 = this.floatVariable;\n\tv54.value = v57[0];\nL_004C:\n\tthis.finishInNextStep = 1;\nL_0051:\n\treturn;\n\tthrow System.NullReferenceException;\n\tv68 = new System.NullReferenceException();\nL_0055:\n\tv86 = new System.IndexOutOfRangeException();\n\tthrow v86;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			base.OnUpdate();
			if (!floatVariable.IsNone && isRunning)
			{
				float[] array = resultFloats;
				if (array.Length == 0)
				{
					goto IL_01e8;
				}
				FsmFloat fsmFloat = floatVariable;
				fsmFloat.Value = array[0];
			}
			if (finishInNextStep && !looping)
			{
				Finish();
				if (finishEvent != null)
				{
					Fsm.Event(finishEvent);
				}
			}
			if (!finishAction || finishInNextStep)
			{
				return;
			}
			if (!floatVariable.IsNone)
			{
				float[] array2 = resultFloats;
				if (array2.Length == 0)
				{
					goto IL_01e8;
				}
				FsmFloat fsmFloat2 = floatVariable;
				fsmFloat2.Value = array2[0];
			}
			finishInNextStep = true;
			return;
			IL_01e8:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000621")]
		[Address(RVA = "0xA1520C", Offset = "0xA1520C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public AnimateFloatV2()
		{
		}
	}
}
