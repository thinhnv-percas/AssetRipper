using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x751EDC", Offset = "0x751EDC")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x751EDC", Offset = "0x751EDC")]
	[Token(Token = "0x2000119")]
	public class EaseFloat : EaseFsmAction
	{
		[RequiredField]
		[Token(Token = "0x400108C")]
		[FieldOffset(Offset = "0xC8")]
		public FsmFloat fromValue;

		[RequiredField]
		[Token(Token = "0x400108D")]
		[FieldOffset(Offset = "0xD0")]
		public FsmFloat toValue;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7A1ED8", Offset = "0x7A1ED8")]
		[Token(Token = "0x400108E")]
		[FieldOffset(Offset = "0xD8")]
		public FsmFloat floatVariable;

		[Token(Token = "0x400108F")]
		[FieldOffset(Offset = "0xE0")]
		private bool finishInNextStep;

		[Token(Token = "0x6000653")]
		[Address(RVA = "0xB71A80", Offset = "0xB71A80", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.EaseFsmAction::Reset(this);\n\tthis.finishInNextStep = 0;\n\tthis.toValue = 0;\n\tthis.floatVariable = 0;\n\tthis.fromValue = 0;\n\treturn;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			finishInNextStep = false;
			toValue = null;
			floatVariable = null;
			fromValue = null;
		}

		[Token(Token = "0x6000654")]
		[Address(RVA = "0xB71AAC", Offset = "0xB71AAC", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1EFA210]);\n\tv21 = *([v20 @ X8_v13]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20228FF]) = v40;\nL_0015:\n\tHutongGames.PlayMaker.Actions.EaseFsmAction::OnEnter(this);\n\t// 26 NewArr v46 @ X0_v4 (System.Single[]), typeof(System.Single[]), 1\n\tthis.fromFloats = v46;\n\tv52 = HutongGames.PlayMaker.FsmFloat::get_Value(this.fromValue);\n\tv82 = v46.Length == 0;\n\tif (v82) goto L_0052;\n\tv46[0] = v52;\n\t// 43 NewArr v61 @ X0_v15 (System.Single[]), typeof(System.Single[]), 1\n\tthis.toFloats = v61;\n\tv54 = HutongGames.PlayMaker.FsmFloat::get_Value(this.toValue);\n\tv83 = v61.Length == 0;\n\tif (v83) goto L_0052;\n\tv61[0] = v54;\n\t// 60 NewArr v122 @ X0_v18 (System.Single[]), typeof(System.Single[]), 1\n\tthis.resultFloats = v122;\n\tthis.finishInNextStep = 0;\n\tv70 = this.floatVariable;\n\tv55 = HutongGames.PlayMaker.FsmFloat::get_Value(this.fromValue);\n\tv70.value = v55;\n\treturn;\n\tv77 = new System.NullReferenceException();\nL_0052:\n\tv89 = new System.IndexOutOfRangeException();\n\tthrow v89;\n\tthrow System.NullReferenceException;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			base.OnEnter();
			float[] array = (fromFloats = new float[1]);
			float value = fromValue.Value;
			if (array.Length != 0)
			{
				array[0] = value;
				float[] array2 = (toFloats = new float[1]);
				float value2 = toValue.Value;
				if (array2.Length != 0)
				{
					array2[0] = value2;
					float[] array3 = new float[1];
					resultFloats = array3;
					finishInNextStep = false;
					FsmFloat fsmFloat = floatVariable;
					float value3 = fromValue.Value;
					fsmFloat.Value = value3;
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000655")]
		[Address(RVA = "0xB71BC4", Offset = "0xB71BC4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void OnExit()
		{
		}

		[Token(Token = "0x6000656")]
		[Address(RVA = "0xB71BC8", Offset = "0xB71BC8", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.EaseFsmAction::OnUpdate(this);\n\tv16 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.floatVariable);\n\tv69 = v16 == 0;\n\tv70 = ~v69;\n\tif (v70) goto L_0020;\n\tv78 = ~this.isRunning;\n\tif (v78) goto L_0020;\n\tv94 = this.resultFloats;\n\tv106 = v94.Length == 0;\n\tif (v106) goto L_0066;\n\tv79 = this.floatVariable;\n\tv79.value = v94[0];\nL_0020:\n\tv84 = ~this.finishInNextStep;\n\tif (v84) goto L_002E;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\tv100 = this.finishEvent == 0;\n\tif (v100) goto L_002E;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.finishEvent);\nL_002E:\n\tv103 = ~this.finishAction;\n\tif (v103) goto L_0063;\n\tv117 = ~this.finishInNextStep;\n\tv118 = ~v117;\n\tif (v118) goto L_0063;\n\tv164 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.floatVariable);\n\tv166 = v164 == 0;\n\tv163 = ~v166;\n\tif (v163) goto L_005D;\n\tv85 = this.floatVariable;\n\tv75 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.reverse);\n\tv168 = v75 == 0;\n\tv72 = ~v168;\n\tif (v72) goto L_0054;\n\tv76 = HutongGames.PlayMaker.FsmBool::get_Value(this.reverse);\n\tv73 = v76 == 0;\n\tif (v73) goto L_0054;\n\tv91 = this.fromValue;\n\tv170 = this.fromValue == 0;\n\tv41 = ~v170;\n\tif (v41) goto L_0058;\n\tthrow System.NullReferenceException;\nL_0054:\n\tv91 = this.toValue;\nL_0058:\n\tv93 = HutongGames.PlayMaker.FsmFloat::get_Value(v91);\n\tv85.value = v93;\nL_005D:\n\tthis.finishInNextStep = 1;\nL_0063:\n\treturn;\n\tv116 = new System.NullReferenceException();\nL_0066:\n\tv147 = new System.IndexOutOfRangeException();\n\tthrow v147;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			base.OnUpdate();
			if (!floatVariable.IsNone && isRunning)
			{
				float[] array = resultFloats;
				if (array.Length == 0)
				{
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				FsmFloat fsmFloat = floatVariable;
				fsmFloat.Value = array[0];
			}
			if (finishInNextStep)
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
				FsmFloat fsmFloat2 = floatVariable;
				FsmFloat fsmFloat3;
				if (!reverse.IsNone && reverse.Value)
				{
					fsmFloat3 = fromValue;
					if (fromValue == null)
					{
						throw new NullReferenceException();
					}
				}
				else
				{
					fsmFloat3 = toValue;
				}
				float value = fsmFloat3.Value;
				fsmFloat2.Value = value;
			}
			finishInNextStep = true;
		}

		[Token(Token = "0x6000657")]
		[Address(RVA = "0xB71CE4", Offset = "0xB71CE4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.EaseFsmAction::.ctor(this);\n\treturn;\n")]
		public EaseFloat()
		{
		}
	}
}
