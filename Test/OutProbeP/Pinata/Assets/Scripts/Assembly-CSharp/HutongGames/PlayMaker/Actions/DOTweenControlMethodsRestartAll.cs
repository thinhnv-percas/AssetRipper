using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using Doozy.PlayMaker.Actions;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74E540", Offset = "0x74E540")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74E540", Offset = "0x74E540")]
	[Attribute(Type = typeof(HelpUrlAttribute), RVA = "0x74E540", Offset = "0x74E540")]
	[Token(Token = "0x20000A4")]
	public class DOTweenControlMethodsRestartAll : FsmStateAction
	{
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x76FFA0", Offset = "0x76FFA0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x76FFA0", Offset = "0x76FFA0")]
		[Token(Token = "0x4000548")]
		[FieldOffset(Offset = "0x50")]
		public FsmBool includeDelay;

		[Attribute(Type = typeof(ActionSection), RVA = "0x76FFF0", Offset = "0x76FFF0")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x76FFF0", Offset = "0x76FFF0")]
		[Token(Token = "0x4000549")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool debugThis;

		[Token(Token = "0x6000418")]
		[Address(RVA = "0xAF26C4", Offset = "0xAF26C4", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1EE0A48]);\n\tv21 = *([v20 @ X8_v7]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202244D]) = v40;\nL_0016:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tv46 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v46);\n\tv46.useVariable = 0;\n\tv46.value = 1;\n\tthis.includeDelay = v46;\n\tv52 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v52);\n\tv52.value = 0;\n\tthis.debugThis = v52;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			FsmBool fsmBool = new FsmBool();
			fsmBool.useVariable = false;
			fsmBool.value = true;
			includeDelay = fsmBool;
			FsmBool fsmBool2 = new FsmBool();
			fsmBool2.value = false;
			debugThis = fsmBool2;
		}

		[Token(Token = "0x6000419")]
		[Address(RVA = "0xAF2770", Offset = "0xAF2770", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EE4D70]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202244E]) = v40;\nL_0018:\n\tv44 = HutongGames.PlayMaker.FsmBool::get_Value(this.includeDelay);\n\tgoto L_0029;\n\tv68 = *([v49 @ X8_v6+E0]);\n\tv69 = v68 == 0;\n\tv70 = ~v69;\n\tif (v70) goto L_0029;\n\tv75 = v49;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v75, v43, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0029:\n\tv59 = DG.Tweening.DOTween::RestartAll(v44);\n\tv105 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv94 = v105 == 0;\n\tif (v94) goto L_004B;\n\t// 58 Box v113 @ X0_v16 (System.Object), typeof(System.Int32), &v59 @ X0_v10 (System.Int32)\n\tv129 = System.String::Concat(\"DOTween Control Methods Restart All - Restarted \", v113, \" tweens\");\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, v129);\nL_004B:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			bool value = includeDelay.Value;
			int num = DOTween.RestartAll(value);
			if (debugThis.Value)
			{
				object obj = num;
				string message = string.Concat("DOTween Control Methods Restart All - Restarted ", obj, " tweens");
				State.Debug(message);
			}
			Finish();
		}

		[Token(Token = "0x600041A")]
		[Address(RVA = "0xAF2884", Offset = "0xAF2884", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenControlMethodsRestartAll()
		{
		}
	}
}
