using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using Doozy.PlayMaker.Actions;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74D124", Offset = "0x74D124")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74D124", Offset = "0x74D124")]
	[Attribute(Type = typeof(HelpUrlAttribute), RVA = "0x74D124", Offset = "0x74D124")]
	[Token(Token = "0x200007D")]
	public class DOTweenAdditionalMethodsClearCachedTweens : FsmStateAction
	{
		[Attribute(Type = typeof(ActionSection), RVA = "0x764E00", Offset = "0x764E00")]
		[Token(Token = "0x40002CE")]
		[FieldOffset(Offset = "0x50")]
		public FsmBool debugThis;

		[Token(Token = "0x600036B")]
		[Address(RVA = "0xA96A90", Offset = "0xA96A90", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EDB218]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022217]) = v38;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tv44 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v44);\n\tv44.value = 0;\n\tthis.debugThis = v44;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			FsmBool fsmBool = new FsmBool();
			fsmBool.value = false;
			debugThis = fsmBool;
		}

		[Token(Token = "0x600036C")]
		[Address(RVA = "0xA96B0C", Offset = "0xA96B0C", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EEC270]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022218]) = v38;\nL_0019:\n\tgoto L_0020;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0020;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0020:\n\tDG.Tweening.DOTween::ClearCachedTweens();\n\tv56 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv59 = v56 == 0;\n\tif (v59) goto L_0036;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Additional Methods Clear Cached Tweens\");\nL_0036:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DOTween.ClearCachedTweens();
			if (debugThis.Value)
			{
				State.Debug("DOTween Additional Methods Clear Cached Tweens");
			}
			Finish();
		}

		[Token(Token = "0x600036D")]
		[Address(RVA = "0xA96BAC", Offset = "0xA96BAC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenAdditionalMethodsClearCachedTweens()
		{
		}
	}
}
