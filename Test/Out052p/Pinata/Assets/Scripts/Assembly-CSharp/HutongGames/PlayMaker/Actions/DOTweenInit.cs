using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using Doozy.PlayMaker.Actions;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74EB70", Offset = "0x74EB70")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74EB70", Offset = "0x74EB70")]
	[Attribute(Type = typeof(HelpUrlAttribute), RVA = "0x74EB70", Offset = "0x74EB70")]
	[Token(Token = "0x20000B0")]
	public class DOTweenInit : FsmStateAction
	{
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7726A0", Offset = "0x7726A0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7726A0", Offset = "0x7726A0")]
		[Token(Token = "0x40005D0")]
		[FieldOffset(Offset = "0x50")]
		public FsmBool recycleAllByDefault;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7726F0", Offset = "0x7726F0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7726F0", Offset = "0x7726F0")]
		[Token(Token = "0x40005D1")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool useSafeMode;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x772740", Offset = "0x772740")]
		[Token(Token = "0x40005D2")]
		[FieldOffset(Offset = "0x60")]
		public LogBehaviour logBehaviour;

		[Attribute(Type = typeof(ActionSection), RVA = "0x772778", Offset = "0x772778")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x772778", Offset = "0x772778")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x772778", Offset = "0x772778")]
		[Token(Token = "0x40005D3")]
		[FieldOffset(Offset = "0x68")]
		public FsmInt tweenersCapacity;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7727EC", Offset = "0x7727EC")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7727EC", Offset = "0x7727EC")]
		[Token(Token = "0x40005D4")]
		[FieldOffset(Offset = "0x70")]
		public FsmInt sequencesCapacity;

		[Attribute(Type = typeof(ActionSection), RVA = "0x77283C", Offset = "0x77283C")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x77283C", Offset = "0x77283C")]
		[Token(Token = "0x40005D5")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool debugThis;

		[Token(Token = "0x6000444")]
		[Address(RVA = "0xAF55E0", Offset = "0xAF55E0", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EC0558]);\n\tv23 = *([v22 @ X8_v9]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022469]) = v42;\nL_0017:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tv48 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v48);\n\tv48.value = 0;\n\tthis.recycleAllByDefault = v48;\n\tv53 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v53);\n\tv53.value = 1;\n\tthis.useSafeMode = v53;\n\tthis.logBehaviour = 2;\n\tv65 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v65);\n\tv65.useVariable = 0;\n\tv65.value = 0xC8;\n\tthis.tweenersCapacity = v65;\n\tv66 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v66);\n\tv66.useVariable = 0;\n\tv66.value = 0xA;\n\tthis.sequencesCapacity = v66;\n\tv67 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v67);\n\tv67.value = 0;\n\tthis.debugThis = v67;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			FsmBool fsmBool = new FsmBool();
			fsmBool.value = false;
			recycleAllByDefault = fsmBool;
			FsmBool fsmBool2 = new FsmBool();
			fsmBool2.value = true;
			useSafeMode = fsmBool2;
			logBehaviour = LogBehaviour.ErrorsOnly;
			FsmInt fsmInt = new FsmInt();
			fsmInt.useVariable = false;
			fsmInt.Value = 200;
			tweenersCapacity = fsmInt;
			FsmInt fsmInt2 = new FsmInt();
			fsmInt2.useVariable = false;
			fsmInt2.Value = 10;
			sequencesCapacity = fsmInt2;
			FsmBool fsmBool3 = new FsmBool();
			fsmBool3.value = false;
			debugThis = fsmBool3;
		}

		[Token(Token = "0x6000445")]
		[Address(RVA = "0xAF5708", Offset = "0xAF5708", Length = "0x1DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EB2DC8]);\n\tv23 = *([v22 @ X8_v23]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202246A]) = v42;\nL_0019:\n\tv46 = HutongGames.PlayMaker.FsmBool::get_Value(this.recycleAllByDefault);\n\tv109 = 0;\n\tv132 = System.Nullable`1<System.Boolean>::.ctor(&v109 @ stack_-34_v2 (System.Nullable`1<System.Boolean>), v46);\n\tv174 = HutongGames.PlayMaker.FsmBool::get_Value(this.useSafeMode);\n\tv102 = 0;\n\tv178 = System.Nullable`1<System.Boolean>::.ctor(&v102 @ stack_-38_v2 (System.Nullable`1<System.Boolean>), v174);\n\tv99 = 0;\n\tv184 = System.Nullable`1<DG.Tweening.LogBehaviour>::.ctor(&v99 @ stack_-40_v2 (System.Nullable`1<DG.Tweening.LogBehaviour>), this.logBehaviour);\n\tgoto L_0042;\n\tv191 = *([v187 @ X0_v14+E0]);\n\tv192 = v191 == 0;\n\tv193 = ~v192;\n\tif (v193) goto L_0042;\n\tv195 = \"il2cpp_codegen_runtime_class_init\"(v187, v180, v183, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0042:\n\tv200 = DG.Tweening.DOTween::Init(0, 0, 0);\n\tv205 = HutongGames.PlayMaker.FsmInt::get_Value(this.tweenersCapacity);\n\tv208 = HutongGames.PlayMaker.FsmInt::get_Value(this.sequencesCapacity);\n\tgoto L_0083;\n\tv220 = *([v215 @ X8_v13+B0]);\n\tv221 = 0;\n\tv222 = v220 + 8;\n\tv224 = *([v260 @ X11_v6-8]);\n\tv266 = v224 == v218;\n\tif (v266) goto L_007A;\n\tv246 = v261 + 1;\n\tv271 = v246 < v217;\n\tv242 = ~v271;\n\tv244 = v260 + 0x10;\n\tv226 = ~v242;\n\tif (v226) goto L_FFFFFFFF;\n\tv247 = v127;\n\tv248 = 0;\n\tv249 = 0x8909C4(v247, v218, v248, v96, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tgoto L_0083;\nL_007A:\n\tv272 = *([v260 @ X11_v6]);\n\tv273 = v272 << 4;\n\tv274 = v215 + v273;\n\tv275 = v274 + 0x130;\nL_0083:\n\tv280 = DG.Tweening.IDOTweenInit::SetCapacity(v200, v205, v208);\n\tv282 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv164 = v282 == 0;\n\tif (v164) goto L_0094;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Init\");\nL_0094:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tv116 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 107 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			bool value = recycleAllByDefault.Value;
			bool? flag = null;
			flag = value;
			bool value2 = useSafeMode.Value;
			bool? flag2 = null;
			flag2 = value2;
			LogBehaviour? logBehaviour = null;
			logBehaviour = this.logBehaviour;
			IDOTweenInit iDOTweenInit = DOTween.Init();
			int value3 = tweenersCapacity.Value;
			int value4 = sequencesCapacity.Value;
			IDOTweenInit iDOTweenInit2 = iDOTweenInit.SetCapacity(value3, value4);
			if (debugThis.Value)
			{
				State.Debug("DOTween Init");
			}
			Finish();
		}

		[Token(Token = "0x6000446")]
		[Address(RVA = "0xAF58E4", Offset = "0xAF58E4", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.logBehaviour = 2;\n\tv13 = HutongGames.PlayMaker.FsmInt::op_Implicit(0xC8);\n\tthis.tweenersCapacity = v13;\n\tv16 = HutongGames.PlayMaker.FsmInt::op_Implicit(0xA);\n\tthis.sequencesCapacity = v16;\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenInit()
		{
			logBehaviour = LogBehaviour.ErrorsOnly;
			FsmInt fsmInt = 200;
			tweenersCapacity = fsmInt;
			FsmInt fsmInt2 = 10;
			sequencesCapacity = fsmInt2;
		}
	}
}
