using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using Doozy.PlayMaker.Actions;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74DF10", Offset = "0x74DF10")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74DF10", Offset = "0x74DF10")]
	[Attribute(Type = typeof(HelpUrlAttribute), RVA = "0x74DF10", Offset = "0x74DF10")]
	[Token(Token = "0x2000098")]
	public class DOTweenControlMethodsGoToAll : FsmStateAction
	{
		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x76F2B8", Offset = "0x76F2B8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x76F2B8", Offset = "0x76F2B8")]
		[Token(Token = "0x400051D")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat to;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x76F318", Offset = "0x76F318")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x76F318", Offset = "0x76F318")]
		[Token(Token = "0x400051E")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool andPlay;

		[Attribute(Type = typeof(ActionSection), RVA = "0x76F368", Offset = "0x76F368")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x76F368", Offset = "0x76F368")]
		[Token(Token = "0x400051F")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool debugThis;

		[Token(Token = "0x60003F4")]
		[Address(RVA = "0xAF09FC", Offset = "0xAF09FC", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1F0F178]);\n\tv21 = *([v20 @ X8_v6]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022435]) = v40;\nL_0016:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tv46 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v46);\n\tv46.useVariable = 0;\n\tthis.to = v46;\n\tv53 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v53);\n\tv53.useVariable = 0;\n\tv53.value = 0;\n\tthis.andPlay = v53;\n\tv59 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v59);\n\tv59.value = 0;\n\tthis.debugThis = v59;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = false;
			to = fsmFloat;
			FsmBool fsmBool = new FsmBool();
			fsmBool.useVariable = false;
			fsmBool.value = false;
			andPlay = fsmBool;
			FsmBool fsmBool2 = new FsmBool();
			fsmBool2.value = false;
			debugThis = fsmBool2;
		}

		[Token(Token = "0x60003F5")]
		[Address(RVA = "0xAF0ACC", Offset = "0xAF0ACC", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EC6568]);\n\tv23 = *([v22 @ X8_v16]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022436]) = v42;\nL_0019:\n\tv46 = HutongGames.PlayMaker.FsmFloat::get_Value(this.to);\n\tv75 = HutongGames.PlayMaker.FsmBool::get_Value(this.andPlay);\n\tgoto L_0031;\n\tv113 = *([v79 @ X8_v6+E0]);\n\tv114 = v113 == 0;\n\tv115 = ~v114;\n\tif (v115) goto L_0031;\n\tv120 = v79;\n\tv117 = \"il2cpp_codegen_runtime_class_init\"(v120, v74, v26, v27, v28, v29, v30, v31, v46, v33, v34, v35, v36, v37, v38, v39);\nL_0031:\n\tv65 = DG.Tweening.DOTween::GotoAll(v46, v75);\n\tv123 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv104 = v123 == 0;\n\tif (v104) goto L_0053;\n\t// 66 Box v131 @ X0_v18 (System.Object), typeof(System.Int32), &v65 @ X0_v12 (System.Int32)\n\tv147 = System.String::Concat(\"DOTween Control Methods Go To All - \", v131, \" tweens involved\");\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, v147);\nL_0053:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			float value = to.Value;
			bool value2 = andPlay.Value;
			int num = DOTween.GotoAll(value, value2);
			if (debugThis.Value)
			{
				object obj = num;
				string message = string.Concat("DOTween Control Methods Go To All - ", obj, " tweens involved");
				State.Debug(message);
			}
			Finish();
		}

		[Token(Token = "0x60003F6")]
		[Address(RVA = "0xAF0C08", Offset = "0xAF0C08", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenControlMethodsGoToAll()
		{
		}
	}
}
