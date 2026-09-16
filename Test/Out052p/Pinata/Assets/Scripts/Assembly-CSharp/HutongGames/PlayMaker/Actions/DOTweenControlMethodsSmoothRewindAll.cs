using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using Doozy.PlayMaker.Actions;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74E750", Offset = "0x74E750")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74E750", Offset = "0x74E750")]
	[Attribute(Type = typeof(HelpUrlAttribute), RVA = "0x74E750", Offset = "0x74E750")]
	[Token(Token = "0x20000A8")]
	public class DOTweenControlMethodsSmoothRewindAll : FsmStateAction
	{
		[Attribute(Type = typeof(ActionSection), RVA = "0x770470", Offset = "0x770470")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x770470", Offset = "0x770470")]
		[Token(Token = "0x4000558")]
		[FieldOffset(Offset = "0x50")]
		public FsmBool debugThis;

		[Token(Token = "0x6000424")]
		[Address(RVA = "0xAF30A8", Offset = "0xAF30A8", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1F080B0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022455]) = v38;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tv44 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v44);\n\tv44.value = 0;\n\tthis.debugThis = v44;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			base.Reset();
			FsmBool fsmBool = new FsmBool();
			fsmBool.value = false;
			debugThis = fsmBool;
		}

		[Token(Token = "0x6000425")]
		[Address(RVA = "0xAF3124", Offset = "0xAF3124", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EC2B08]);\n\tv21 = *([v20 @ X8_v17]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2022456]) = v40;\nL_001A:\n\tgoto L_0021;\n\tv47 = *([v43 @ X0_v2+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\tgoto L_0021;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0021:\n\tv55 = DG.Tweening.DOTween::SmoothRewindAll();\n\tv61 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv65 = v61 == 0;\n\tif (v65) goto L_0043;\n\t// 50 Box v72 @ X0_v13 (System.Object), typeof(System.Int32), &v55 @ X0_v5 (System.Int32)\n\tv115 = System.String::Concat(\"DOTween Control Methods Smooth Rewind All - Rewinding/Rewinded \", v72, \" tweens\");\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, v115);\nL_0043:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			int num = DOTween.SmoothRewindAll();
			if (debugThis.Value)
			{
				object obj = num;
				string message = string.Concat("DOTween Control Methods Smooth Rewind All - Rewinding/Rewinded ", obj, " tweens");
				State.Debug(message);
			}
			Finish();
		}

		[Token(Token = "0x6000426")]
		[Address(RVA = "0xAF3218", Offset = "0xAF3218", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenControlMethodsSmoothRewindAll()
		{
		}
	}
}
