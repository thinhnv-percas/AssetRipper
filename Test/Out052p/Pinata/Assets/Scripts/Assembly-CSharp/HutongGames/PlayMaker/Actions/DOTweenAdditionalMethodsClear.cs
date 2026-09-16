using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using Doozy.PlayMaker.Actions;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74D0A0", Offset = "0x74D0A0")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74D0A0", Offset = "0x74D0A0")]
	[Attribute(Type = typeof(HelpUrlAttribute), RVA = "0x74D0A0", Offset = "0x74D0A0")]
	[Token(Token = "0x200007C")]
	public class DOTweenAdditionalMethodsClear : FsmStateAction
	{
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x764D90", Offset = "0x764D90")]
		[Token(Token = "0x40002CC")]
		[FieldOffset(Offset = "0x50")]
		public FsmBool destroy;

		[Attribute(Type = typeof(ActionSection), RVA = "0x764DC8", Offset = "0x764DC8")]
		[Token(Token = "0x40002CD")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool debugThis;

		[Token(Token = "0x6000368")]
		[Address(RVA = "0xA96924", Offset = "0xA96924", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1EEE3C8]);\n\tv21 = *([v20 @ X8_v4]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022215]) = v40;\nL_0016:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tv46 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v46);\n\tv46.useVariable = 0;\n\tv46.value = 0;\n\tthis.destroy = v46;\n\tv51 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v51);\n\tv51.value = 0;\n\tthis.debugThis = v51;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			FsmBool fsmBool = new FsmBool();
			fsmBool.useVariable = false;
			fsmBool.value = false;
			destroy = fsmBool;
			FsmBool fsmBool2 = new FsmBool();
			fsmBool2.value = false;
			debugThis = fsmBool2;
		}

		[Token(Token = "0x6000369")]
		[Address(RVA = "0xA969CC", Offset = "0xA969CC", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EEBF98]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022216]) = v38;\nL_0017:\n\tv42 = HutongGames.PlayMaker.FsmBool::get_Value(this.destroy);\n\tgoto L_0028;\n\tv62 = *([v53 @ X8_v6+E0]);\n\tv63 = v62 == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_0028;\n\tv88 = v53;\n\tv66 = \"il2cpp_codegen_runtime_class_init\"(v88, v41, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0028:\n\tDG.Tweening.DOTween::Clear(v42);\n\tv90 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv79 = v90 == 0;\n\tif (v79) goto L_003E;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Additional Methods Clear\");\nL_003E:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			bool value = destroy.Value;
			DOTween.Clear(value);
			if (debugThis.Value)
			{
				State.Debug("DOTween Additional Methods Clear");
			}
			Finish();
		}

		[Token(Token = "0x600036A")]
		[Address(RVA = "0xA96A88", Offset = "0xA96A88", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenAdditionalMethodsClear()
		{
		}
	}
}
