using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using Doozy.PlayMaker.Actions;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74D334", Offset = "0x74D334")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x74D334", Offset = "0x74D334")]
	[Attribute(Type = typeof(HelpUrlAttribute), RVA = "0x74D334", Offset = "0x74D334")]
	[Token(Token = "0x2000081")]
	public class DOTweenAnimateInt : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x4000308")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x765DC8", Offset = "0x765DC8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x765DC8", Offset = "0x765DC8")]
		[Token(Token = "0x4000309")]
		[FieldOffset(Offset = "0x58")]
		public FsmInt variable;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x765E28", Offset = "0x765E28")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x765E28", Offset = "0x765E28")]
		[Token(Token = "0x400030A")]
		[FieldOffset(Offset = "0x60")]
		public FsmInt to;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x765E88", Offset = "0x765E88")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x765E88", Offset = "0x765E88")]
		[Token(Token = "0x400030B")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool setRelative;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x765ED8", Offset = "0x765ED8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x765ED8", Offset = "0x765ED8")]
		[Token(Token = "0x400030C")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat duration;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x765F38", Offset = "0x765F38")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x765F38", Offset = "0x765F38")]
		[Token(Token = "0x400030D")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool setSpeedBased;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x765F88", Offset = "0x765F88")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x765F88", Offset = "0x765F88")]
		[Token(Token = "0x400030E")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat startDelay;

		[Attribute(Type = typeof(ActionSection), RVA = "0x765FD8", Offset = "0x765FD8")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x765FD8", Offset = "0x765FD8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x765FD8", Offset = "0x765FD8")]
		[Token(Token = "0x400030F")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool playInReverse;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x76604C", Offset = "0x76604C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x76604C", Offset = "0x76604C")]
		[Token(Token = "0x4000310")]
		[FieldOffset(Offset = "0x90")]
		public FsmBool setReverseRelative;

		[Attribute(Type = typeof(ActionSection), RVA = "0x76609C", Offset = "0x76609C")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x76609C", Offset = "0x76609C")]
		[Token(Token = "0x4000311")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent startEvent;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7660EC", Offset = "0x7660EC")]
		[Token(Token = "0x4000312")]
		[FieldOffset(Offset = "0xA0")]
		public FsmEvent finishEvent;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x766100", Offset = "0x766100")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x766100", Offset = "0x766100")]
		[Token(Token = "0x4000313")]
		[FieldOffset(Offset = "0xA8")]
		public FsmBool finishImmediately;

		[Attribute(Type = typeof(ActionSection), RVA = "0x766150", Offset = "0x766150")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x766150", Offset = "0x766150")]
		[Token(Token = "0x4000314")]
		[FieldOffset(Offset = "0xB0")]
		public string tweenIdDescription;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7661A0", Offset = "0x7661A0")]
		[Token(Token = "0x4000315")]
		[FieldOffset(Offset = "0xB8")]
		public TweenId tweenIdType;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7661D8", Offset = "0x7661D8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7661D8", Offset = "0x7661D8")]
		[Token(Token = "0x4000316")]
		[FieldOffset(Offset = "0xC0")]
		public FsmString stringAsId;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x766228", Offset = "0x766228")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x766228", Offset = "0x766228")]
		[Token(Token = "0x4000317")]
		[FieldOffset(Offset = "0xC8")]
		public FsmString tagAsId;

		[Attribute(Type = typeof(ActionSection), RVA = "0x766278", Offset = "0x766278")]
		[Token(Token = "0x4000318")]
		[FieldOffset(Offset = "0xD0")]
		public SelectedEase selectedEase;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7662B0", Offset = "0x7662B0")]
		[Token(Token = "0x4000319")]
		[FieldOffset(Offset = "0xD4")]
		public Ease easeType;

		[Token(Token = "0x400031A")]
		[FieldOffset(Offset = "0xD8")]
		public FsmAnimationCurve animationCurve;

		[Attribute(Type = typeof(ActionSection), RVA = "0x7662E8", Offset = "0x7662E8")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7662E8", Offset = "0x7662E8")]
		[Token(Token = "0x400031B")]
		[FieldOffset(Offset = "0xE0")]
		public string loopsDescriptionArea;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x766338", Offset = "0x766338")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x766338", Offset = "0x766338")]
		[Token(Token = "0x400031C")]
		[FieldOffset(Offset = "0xE8")]
		public FsmInt loops;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x766388", Offset = "0x766388")]
		[Token(Token = "0x400031D")]
		[FieldOffset(Offset = "0xF0")]
		public LoopType loopType;

		[Attribute(Type = typeof(ActionSection), RVA = "0x7663C0", Offset = "0x7663C0")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7663C0", Offset = "0x7663C0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7663C0", Offset = "0x7663C0")]
		[Token(Token = "0x400031E")]
		[FieldOffset(Offset = "0xF8")]
		public FsmBool autoKillOnCompletion;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x766434", Offset = "0x766434")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x766434", Offset = "0x766434")]
		[Token(Token = "0x400031F")]
		[FieldOffset(Offset = "0x100")]
		public FsmBool recyclable;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x766484", Offset = "0x766484")]
		[Token(Token = "0x4000320")]
		[FieldOffset(Offset = "0x108")]
		public UpdateType updateType;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7664BC", Offset = "0x7664BC")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7664BC", Offset = "0x7664BC")]
		[Token(Token = "0x4000321")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool isIndependentUpdate;

		[Attribute(Type = typeof(ActionSection), RVA = "0x76650C", Offset = "0x76650C")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x76650C", Offset = "0x76650C")]
		[Token(Token = "0x4000322")]
		[FieldOffset(Offset = "0x118")]
		public FsmBool debugThis;

		[Token(Token = "0x4000323")]
		[FieldOffset(Offset = "0x120")]
		private Tweener tween;

		[Token(Token = "0x600037F")]
		[Address(RVA = "0xA97CB8", Offset = "0xA97CB8", Length = "0x2B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EFB158]);\n\tv27 = *([v26 @ X8_v9]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2022221]) = v46;\nL_0019:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv52 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v52);\n\tv52.useVariable = 1;\n\tthis.variable = v52;\n\tv58 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v58);\n\tv58.useVariable = 0;\n\tthis.to = v58;\n\tv82 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v82);\n\tv82.useVariable = 0;\n\tthis.duration = v82;\n\tv83 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v83);\n\tv83.useVariable = 0;\n\tv83.value = 0;\n\tthis.setSpeedBased = v83;\n\tv84 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v84);\n\tv84.useVariable = 0;\n\tv84.value = 0;\n\tthis.setRelative = v84;\n\tv85 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v85);\n\tv85.useVariable = 0;\n\tv85.value = 0;\n\tthis.playInReverse = v85;\n\tv86 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v86);\n\tv86.useVariable = 0;\n\tv86.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v86;\n\tv87 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v87);\n\tv87.useVariable = 0;\n\tv87.value = 0;\n\tthis.finishImmediately = v87;\n\tv88 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v88);\n\tv88.useVariable = 0;\n\tthis.stringAsId = v88;\n\tv89 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v89);\n\tv89.useVariable = 0;\n\tthis.tagAsId = v89;\n\tv90 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v90);\n\tv90.value = 0f;\n\tthis.startDelay = v90;\n\tthis.selectedEase = 0x100000000;\n\tv91 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v91);\n\tv91.value = 0;\n\tthis.loops = v91;\n\tthis.loopType = 0;\n\tv92 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v92);\n\tv92.value = 1;\n\tthis.autoKillOnCompletion = v92;\n\tv93 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v93);\n\tv93.value = 0;\n\tthis.recyclable = v93;\n\tthis.updateType = 0;\n\tv94 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v94);\n\tv94.value = 0;\n\tthis.isIndependentUpdate = v94;\n\tv95 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v95);\n\tv95.value = 0;\n\tthis.debugThis = v95;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 120 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_0206: Expected I4, but got I8
			base.Reset();
			gameObject = null;
			FsmInt fsmInt = new FsmInt();
			fsmInt.useVariable = true;
			variable = fsmInt;
			FsmInt fsmInt2 = new FsmInt();
			fsmInt2.useVariable = false;
			to = fsmInt2;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = false;
			duration = fsmFloat;
			FsmBool fsmBool = new FsmBool();
			fsmBool.useVariable = false;
			fsmBool.value = false;
			setSpeedBased = fsmBool;
			FsmBool fsmBool2 = new FsmBool();
			fsmBool2.useVariable = false;
			fsmBool2.value = false;
			setRelative = fsmBool2;
			FsmBool fsmBool3 = new FsmBool();
			fsmBool3.useVariable = false;
			fsmBool3.value = false;
			playInReverse = fsmBool3;
			FsmBool fsmBool4 = new FsmBool();
			fsmBool4.useVariable = false;
			fsmBool4.value = false;
			startEvent = null;
			finishEvent = null;
			setReverseRelative = fsmBool4;
			FsmBool fsmBool5 = new FsmBool();
			fsmBool5.useVariable = false;
			fsmBool5.value = false;
			finishImmediately = fsmBool5;
			FsmString fsmString = new FsmString();
			fsmString.useVariable = false;
			stringAsId = fsmString;
			FsmString fsmString2 = new FsmString();
			fsmString2.useVariable = false;
			tagAsId = fsmString2;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.Value = 0f;
			startDelay = fsmFloat2;
			selectedEase = SelectedEase.EaseType;
			FsmInt fsmInt3 = new FsmInt();
			fsmInt3.Value = 0;
			loops = fsmInt3;
			loopType = default(LoopType);
			FsmBool fsmBool6 = new FsmBool();
			fsmBool6.value = true;
			autoKillOnCompletion = fsmBool6;
			FsmBool fsmBool7 = new FsmBool();
			fsmBool7.value = false;
			recyclable = fsmBool7;
			updateType = default(UpdateType);
			FsmBool fsmBool8 = new FsmBool();
			fsmBool8.value = false;
			isIndependentUpdate = fsmBool8;
			FsmBool fsmBool9 = new FsmBool();
			fsmBool9.value = false;
			debugThis = fsmBool9;
		}

		[Token(Token = "0x6000380")]
		[Address(RVA = "0xA97F70", Offset = "0xA97F70", Length = "0x438")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv25 = *([1EBDDD0]);\n\tv26 = *([v25 @ X8_v12]);\n\tv27 = \"il2cpp_codegen_initialize_method\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2022222]) = v45;\nL_001A:\n\tv49 = new DG.Tweening.Core.DOGetter`1<System.Int32>();\n\tDG.Tweening.Core.DOGetter`1<System.Int32>::.ctor(v49, this, Il2CppMethodInfo);\n\tv61 = new DG.Tweening.Core.DOSetter`1<System.Int32>();\n\tv65 = DG.Tweening.Core.DOGetter`1<System.Int32>::.ctor(v61, this, Il2CppMethodInfo);\n\treturn;\n\tX1 = X19;\n\tX21 = X0;\n\tX2 = *([X8]);\n\tX3 = *([1ED3000]);\n\tDG.Tweening.Core.DOSetter`1<System.Int32>::.ctor(X0, X1, X2, X3);\n\tX0 = *([X19+60]);\n\tif (TEMP) goto L_013E;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmInt::get_Value(X0, X1);\n\tX8 = *([X19+70]);\n\tX22 = X0;\n\tif (TEMP) goto L_013F;\n\tX0 = X8;\n\tX1 = 0;\n\tV0 = HutongGames.PlayMaker.FsmFloat::get_Value(X0, X1);\n\tX8 = *([1F00430]);\n\tV8 = V0;\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_004B;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_004B;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_004B:\n\tX0 = X20;\n\tX1 = X21;\n\tX2 = X22;\n\tV0 = V8;\n\tX3 = 0;\n\tX0 = DG.Tweening.DOTween::To(X0, X1, X2, V0, X3);\n\tX8 = *([X19+78]);\n\t*([X19+120]) = X0;\n\tif (TEMP) goto L_013F;\n\tX0 = X8;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmBool::get_Value(X0, X1);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0060;\n\tX0 = *([X19+120]);\n\tX8 = *([1EEDB38]);\n\tX1 = *([X8]);\n\tX0 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased /* +4 sharing this address */(X0, X1);\nL_0060:\n\tX0 = *([X19+68]);\n\tif (TEMP) goto L_013E;\n\tX20 = *([X19+120]);\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmBool::get_Value(X0, X1);\n\tX8 = *([1EEA7C8]);\n\tX1 = X0 & 1;\n\tX0 = X20;\n\tX2 = *([X8]);\n\tX0 = DG.Tweening.TweenSettingsExtensions::SetRelative /* +4 sharing this address */(X0, X1, X2);\n\tX0 = *([X19+30]);\n\tif (TEMP) goto L_013E;\n\tX1 = *([X19+50]);\n\tX20 = *([X19+C0]);\n\tX21 = *([X19+C8]);\n\tX22 = *([X19+B8]);\n\tX23 = *([X19+120]);\n\tX2 = 0;\n\tX0 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(X0, X1, X2);\n\tX4 = X0;\n\tX0 = X23;\n\tX1 = X22;\n\tX2 = X20;\n\tX3 = X21;\n\tX5 = 0;\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(X0, X1, X2, X3, X4, X5);\n\tX0 = *([X19+80]);\n\tif (TEMP) goto L_013E;\n\tX20 = *([X19+120]);\n\tX1 = 0;\n\tV0 = HutongGames.PlayMaker.FsmFloat::get_Value(X0, X1);\n\tX8 = *([1ED8EC8]);\n\tX0 = X20;\n\tX1 = *([X8]);\n\tX0 = DG.Tweening.TweenSettingsExtensions::SetDelay /* +5 sharing this address */(X0, V0, X1);\n\tX0 = *([X19+120]);\n\tX1 = *([X19+D0]);\n\tX2 = *([X19+D4]);\n\tX3 = *([X19+D8]);\n\tX4 = 0;\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(X0, X1, X2, X3, X4);\n\tX0 = *([X19+E8]);\n\tif (TEMP) goto L_013E;\n\tX20 = *([X19+120]);\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmInt::get_Value(X0, X1);\n\tX2 = *([X19+F0]);\n\tX8 = *([1EE6E00]);\n\tX1 = X0;\n\tX0 = X20;\n\tX3 = *([X8]);\n\tX0 = DG.Tweening.TweenSettingsExtensions::SetLoops /* +5 sharing this address */(X0, X1, X2, X3);\n\tX0 = *([X19+F8]);\n\tif (TEMP) goto L_013E;\n\tX20 = *([X19+120]);\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmBool::get_Value(X0, X1);\n\tX8 = *([1EA6E00]);\n\tX1 = X0 & 1;\n\tX0 = X20;\n\tX2 = *([X8]);\n\tX0 = DG.Tweening.TweenSettingsExtensions::SetAutoKill /* +5 sharing this address */(X0, X1, X2);\n\tX0 = *([X19+100]);\n\tif (TEMP) goto L_013E;\n\tX20 = *([X19+120]);\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmBool::get_Value(X0, X1);\n\tX8 = *([1ED17F8]);\n\tX1 = X0 & 1;\n\tX0 = X20;\n\tX2 = *([X8]);\n\tX0 = DG.Tweening.TweenSettingsExtensions::SetRecyclable /* +3 sharing this address */(X0, X1, X2);\n\tX0 = *([X19+110]);\n\tif (TEMP) goto L_013E;\n\tX20 = *([X19+108]);\n\tX21 = *([X19+120]);\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmBool::get_Value(X0, X1);\n\tX8 = *([1ED5DF8]);\n\tX2 = X0 & 1;\n\tX0 = X21;\n\tX1 = X20;\n\tX3 = *([X8]);\n\tX0 = DG.Tweening.TweenSettingsExtensions::SetUpdate /* +3 sharing this address */(X0, X1, X2, X3);\n\tX0 = *([X19+88]);\n\tif (TEMP) goto L_013E;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmBool::get_Value(X0, X1);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_00D5;\n\tX0 = *([X19+90]);\n\tif (TEMP) goto L_013E;\n\tX20 = *([X19+120]);\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmBool::get_Value(X0, X1);\n\tX8 = *([1EEA250]);\n\tX1 = X0 & 1;\n\tX0 = X20;\n\tX2 = *([X8]);\n\tX0 = DG.Tweening.TweenSettingsExtensions::From /* +2 sharing this address */(X0, X1, X2);\nL_00D5:\n\tX8 = *([X19+98]);\n\tif (TEMP) goto L_00EA;\n\tX20 = *([X19+120]);\n\tX8 = *([1EF3F98]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EB8F08]);\n\tX1 = X19;\n\tX3 = 0;\n\tX21 = X0;\n\tX2 = *([X8]);\n\tDG.Tweening.TweenCallback::.ctor(X0, X1, X2, X3);\n\tX8 = *([1F01228]);\n\tX0 = X20;\n\tX1 = X21;\n\tX2 = *([X8]);\n\tX0 = DG.Tweening.TweenSettingsExtensions::OnStart /* +5 sharing this address */(X0, X1, X2);\nL_00EA:\n\tX0 = *([X19+A8]);\n\tif (TEMP) goto L_013E;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmBool::get_Value(X0, X1);\n\tTEMP = X0 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_010C;\n\tX22 = *([X19+A0]);\n\tX20 = *([X19+120]);\n\tX8 = *([1EF3F98]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = X0;\n\tif (TEMP) goto L_00FF;\n\tX8 = *([1EF5A08]);\n\tgoto L_0101;\nL_00FF:\n\tX8 = 0x1EA5000;\n\tX8 = *([1EA5AA8]);\nL_0101:\n\tX2 = *([X8]);\n\tX0 = X21;\n\tX1 = X19;\n\tX3 = 0;\n\tDG.Tweening.TweenCallback::.ctor(X0, X1, X2, X3);\n\tX8 = *([1EE6378]);\n\tX0 = X20;\n\tX1 = X21;\n\tX2 = *([X8]);\n\tX0 = DG.Tweening.TweenSettingsExtensions::OnComplete /* +5 sharing this address */(X0, X1, X2);\nL_010C:\n\tX8 = 0x1F01000;\n\tX0 = *([X19+120]);\n\tX8 = *([1F01CE0]);\n\tX1 = *([X8]);\n\tX0 = DG.Tweening.TweenExtensions::Play /* +5 sharing this address */(X0, X1);\n\tX0 = *([X19+118]);\n\tif (TEMP) goto L_013E;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmBool::get_Value(X0, X1);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_011F;\n\tX0 = *([X19+28]);\n\tX8 = *([1EFFBA8]);\n\tX2 = 0;\n\tX1 = *([X8]);\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(X0, X1, X2);\nL_011F:\n\tX0 = *([X19+A8]);\n\tif (TEMP) goto L_013E;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmBool::get_Value(X0, X1);\n\tTEMP = X0 & 1;\n\tif (TEMP) goto L_0134;\n\tX0 = X19;\n\tX29 = stack[30];\n\tX30 = stack[38];\n\tX20 = stack[20];\n\tX19 = stack[28];\n\tX22 = stack[10];\n\tX21 = stack[18];\n\tX23 = stack[8];\n\tX1 = 0;\n\tV8 = stack[0];\n\t// 305 ShiftStack 64\n\tHutongGames.PlayMaker.FsmStateAction::Finish(X0, X1);\n\treturn;\nL_0134:\n\tX29 = stack[30];\n\tX30 = stack[38];\n\tX20 = stack[20];\n\tX19 = stack[28];\n\tX22 = stack[10];\n\tX21 = stack[18];\n\tX23 = stack[8];\n\tV8 = stack[0];\n\t// 316 ShiftStack 64\n\treturn;\nL_013E:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_013F:\n\tX0 = 0;\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DOGetter<int> dOGetter = () => variable.Value;
			DOSetter<int> dOSetter = () => variable.Value;
		}

		[Token(Token = "0x6000381")]
		[Address(RVA = "0xA983A8", Offset = "0xA983A8", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EC9140]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022223]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenAnimateInt()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
