using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using Doozy.PlayMaker;
using Doozy.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74EF90", Offset = "0x74EF90")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x74EF90", Offset = "0x74EF90")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x74EF90", Offset = "0x74EF90")]
	[Token(Token = "0x20000B8")]
	public class DOTweenLineRendererColor : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x775F14", Offset = "0x775F14")]
		[Token(Token = "0x4000696")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x775F88", Offset = "0x775F88")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x775F88", Offset = "0x775F88")]
		[Token(Token = "0x4000697")]
		[FieldOffset(Offset = "0x58")]
		public FsmColor startValue_color_1;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x775FE8", Offset = "0x775FE8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x775FE8", Offset = "0x775FE8")]
		[Token(Token = "0x4000698")]
		[FieldOffset(Offset = "0x60")]
		public FsmColor startValue_color_2;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x776048", Offset = "0x776048")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x776048", Offset = "0x776048")]
		[Token(Token = "0x4000699")]
		[FieldOffset(Offset = "0x68")]
		public FsmColor endValue_color_1;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7760A8", Offset = "0x7760A8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7760A8", Offset = "0x7760A8")]
		[Token(Token = "0x400069A")]
		[FieldOffset(Offset = "0x70")]
		public FsmColor endValue_color_2;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x776108", Offset = "0x776108")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x776108", Offset = "0x776108")]
		[Token(Token = "0x400069B")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool setRelative;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x776158", Offset = "0x776158")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x776158", Offset = "0x776158")]
		[Token(Token = "0x400069C")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7761B8", Offset = "0x7761B8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7761B8", Offset = "0x7761B8")]
		[Token(Token = "0x400069D")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x776208", Offset = "0x776208")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x776208", Offset = "0x776208")]
		[Token(Token = "0x400069E")]
		[FieldOffset(Offset = "0x90")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x776258", Offset = "0x776258")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x776258", Offset = "0x776258")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x776258", Offset = "0x776258")]
		[Token(Token = "0x400069F")]
		[FieldOffset(Offset = "0x98")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7762CC", Offset = "0x7762CC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7762CC", Offset = "0x7762CC")]
		[Token(Token = "0x40006A0")]
		[FieldOffset(Offset = "0xA0")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77631C", Offset = "0x77631C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77631C", Offset = "0x77631C")]
		[Token(Token = "0x40006A1")]
		[FieldOffset(Offset = "0xA8")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77636C", Offset = "0x77636C")]
		[Token(Token = "0x40006A2")]
		[FieldOffset(Offset = "0xB0")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x776380", Offset = "0x776380")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x776380", Offset = "0x776380")]
		[Token(Token = "0x40006A3")]
		[FieldOffset(Offset = "0xB8")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7763D0", Offset = "0x7763D0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7763D0", Offset = "0x7763D0")]
		[Token(Token = "0x40006A4")]
		[FieldOffset(Offset = "0xC0")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x776420", Offset = "0x776420")]
		[Token(Token = "0x40006A5")]
		[FieldOffset(Offset = "0xC8")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x776458", Offset = "0x776458")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x776458", Offset = "0x776458")]
		[Token(Token = "0x40006A6")]
		[FieldOffset(Offset = "0xD0")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7764A8", Offset = "0x7764A8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7764A8", Offset = "0x7764A8")]
		[Token(Token = "0x40006A7")]
		[FieldOffset(Offset = "0xD8")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7764F8", Offset = "0x7764F8")]
		[Token(Token = "0x40006A8")]
		[FieldOffset(Offset = "0xE0")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x776530", Offset = "0x776530")]
		[Token(Token = "0x40006A9")]
		[FieldOffset(Offset = "0xE4")]
		public Ease easeType;

		[Token(Token = "0x40006AA")]
		[FieldOffset(Offset = "0xE8")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x776568", Offset = "0x776568")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x776568", Offset = "0x776568")]
		[Token(Token = "0x40006AB")]
		[FieldOffset(Offset = "0xF0")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7765B8", Offset = "0x7765B8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7765B8", Offset = "0x7765B8")]
		[Token(Token = "0x40006AC")]
		[FieldOffset(Offset = "0xF8")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x776608", Offset = "0x776608")]
		[Token(Token = "0x40006AD")]
		[FieldOffset(Offset = "0x100")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x776640", Offset = "0x776640")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x776640", Offset = "0x776640")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x776640", Offset = "0x776640")]
		[Token(Token = "0x40006AE")]
		[FieldOffset(Offset = "0x108")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7766B4", Offset = "0x7766B4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7766B4", Offset = "0x7766B4")]
		[Token(Token = "0x40006AF")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x776704", Offset = "0x776704")]
		[Token(Token = "0x40006B0")]
		[FieldOffset(Offset = "0x118")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77673C", Offset = "0x77673C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77673C", Offset = "0x77673C")]
		[Token(Token = "0x40006B1")]
		[FieldOffset(Offset = "0x120")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77678C", Offset = "0x77678C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77678C", Offset = "0x77678C")]
		[Token(Token = "0x40006B2")]
		[FieldOffset(Offset = "0x128")]
		public FsmBool debugThis;

		[Token(Token = "0x40006B3")]
		[FieldOffset(Offset = "0x130")]
		private Tweener tween;

		[Token(Token = "0x600046A")]
		[Address(RVA = "0xAF8BB8", Offset = "0xAF8BB8", Length = "0x2FC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1ED93E8]);\n\tv25 = *([v24 @ X8_v10]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022480]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmColor();\n\tHutongGames.PlayMaker.FsmColor::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.startValue_color_1 = v50;\n\tv55 = new HutongGames.PlayMaker.FsmColor();\n\tHutongGames.PlayMaker.FsmColor::.ctor(v55);\n\tv55.useVariable = 0;\n\tthis.startValue_color_2 = v55;\n\tv81 = new HutongGames.PlayMaker.FsmColor();\n\tHutongGames.PlayMaker.FsmColor::.ctor(v81);\n\tv81.useVariable = 0;\n\tthis.endValue_color_1 = v81;\n\tv82 = new HutongGames.PlayMaker.FsmColor();\n\tHutongGames.PlayMaker.FsmColor::.ctor(v82);\n\tv82.useVariable = 0;\n\tthis.endValue_color_2 = v82;\n\tv83 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v83);\n\tv83.useVariable = 0;\n\tthis.duration = v83;\n\tv84 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v84);\n\tv84.useVariable = 0;\n\tv84.value = 0;\n\tthis.setSpeedBased = v84;\n\tv85 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v85);\n\tv85.useVariable = 0;\n\tv85.value = 0;\n\tthis.setRelative = v85;\n\tv86 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v86);\n\tv86.useVariable = 0;\n\tv86.value = 0;\n\tthis.playInReverse = v86;\n\tv87 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v87);\n\tv87.useVariable = 0;\n\tv87.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v87;\n\tv88 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v88);\n\tv88.useVariable = 0;\n\tv88.value = 0;\n\tthis.finishImmediately = v88;\n\tv89 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v89);\n\tv89.useVariable = 0;\n\tthis.stringAsId = v89;\n\tv90 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v90);\n\tv90.useVariable = 0;\n\tthis.tagAsId = v90;\n\tv91 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v91);\n\tv91.value = 0f;\n\tthis.startDelay = v91;\n\tthis.selectedEase = 0x100000000;\n\tv92 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v92);\n\tv92.value = 0;\n\tthis.loops = v92;\n\tthis.loopType = 0;\n\tv93 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v93);\n\tv93.value = 1;\n\tthis.autoKillOnCompletion = v93;\n\tv94 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v94);\n\tv94.value = 0;\n\tthis.recyclable = v94;\n\tthis.updateType = 0;\n\tv95 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v95);\n\tv95.value = 0;\n\tthis.isIndependentUpdate = v95;\n\tv96 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v96);\n\tv96.value = 0;\n\tthis.debugThis = v96;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 129 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_0254: Expected I4, but got I8
			base.Reset();
			gameObject = null;
			FsmColor fsmColor = new FsmColor();
			fsmColor.useVariable = false;
			startValue_color_1 = fsmColor;
			FsmColor fsmColor2 = new FsmColor();
			fsmColor2.useVariable = false;
			startValue_color_2 = fsmColor2;
			FsmColor fsmColor3 = new FsmColor();
			fsmColor3.useVariable = false;
			endValue_color_1 = fsmColor3;
			FsmColor fsmColor4 = new FsmColor();
			fsmColor4.useVariable = false;
			endValue_color_2 = fsmColor4;
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
			FsmInt fsmInt = new FsmInt();
			fsmInt.Value = 0;
			loops = fsmInt;
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

		[Token(Token = "0x600046B")]
		[Address(RVA = "0xAF8EB4", Offset = "0xAF8EB4", Length = "0x450")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv34 = *([1EF4838]);\n\tv35 = *([v34 @ X8_v58]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2022481]) = v54;\nL_001B:\n\tv55 = this.startValue_color_1;\n\tv164 = this.endValue_color_1;\n\tv377 = v55.value;\n\tv126 = v164.value;\n\tv267 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv169 = UnityEngine.GameObject::GetComponent(v267);\n\tv110 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tv170 = DG.Tweening.ShortcutExtensions::DOColor(v169, &v377 @ X12_v3 (UnityEngine.Color), &v126 @ X21_v3 (UnityEngine.Color), v110);\n\tthis.tween = v170;\n\tv397 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv400 = DG.Tweening.TweenSettingsExtensions::SetRelative(v170, v397);\n\tv403 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v403);\n\tv213 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv409 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v213);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv412 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv415 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v412, this.loopType);\n\tv417 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv420 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v417);\n\tv422 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv425 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v422);\n\tv427 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv430 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v427);\n\tv431 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv433 = v431 == 0;\n\tif (v433) goto L_00E7;\n\tv448 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv439 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v448);\nL_00E7:\n\tv446 = this.startEvent == 0;\n\tif (v446) goto L_00FF;\n\tv453 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v453, this, Il2CppMethodInfo);\n\tv459 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v453);\nL_00FF:\n\tv468 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv472 = v468 == 0;\n\tv473 = ~v472;\n\tif (v473) goto L_0121;\n\tv479 = new DG.Tweening.TweenCallback();\n\tv488 = this.finishEvent == 0;\n\tif (v488) goto L_FFFFFFFF;\n\tgoto L_0116;\nL_0116:\n\tDG.Tweening.TweenCallback::.ctor(v479, this, *([v500 @ X8_v41 (Il2CppMethodInfo)]));\n\tv486 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v479);\nL_0121:\n\tv493 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv499 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv505 = v499 == 0;\n\tif (v505) goto L_0134;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Line Renderer Color\");\nL_0134:\n\tv515 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv369 = v515 == 0;\n\tif (v369) goto L_0148;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\nL_0148:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 270 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override void OnEnter()
		{
			//IL_007e: Expected O, but got Ref
			//IL_007e: Expected O, but got Ref
			FsmColor fsmColor = startValue_color_1;
			FsmColor fsmColor2 = endValue_color_1;
			Color value = fsmColor.value;
			Color value2 = fsmColor2.value;
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			LineRenderer component = ownerDefaultTarget.GetComponent<LineRenderer>();
			float value3 = duration.Value;
			Tweener t = (tween = component.DOColor((Color2)(&value), (Color2)(&value2), value3));
			bool value4 = setRelative.Value;
			Tweener tweener = t.SetRelative(value4);
			GameObject ownerDefaultTarget2 = Fsm.GetOwnerDefaultTarget(gameObject);
			tween.SetTweenId(tweenIdType, stringAsId, tagAsId, ownerDefaultTarget2);
			float value5 = startDelay.Value;
			Tweener tweener2 = tween.SetDelay(value5);
			tween.SetSelectedEase(selectedEase, easeType, animationCurve);
			int value6 = loops.Value;
			Tweener tweener3 = tween.SetLoops(value6, loopType);
			bool value7 = autoKillOnCompletion.Value;
			Tweener tweener4 = tween.SetAutoKill(value7);
			bool value8 = recyclable.Value;
			Tweener tweener5 = tween.SetRecyclable(value8);
			bool value9 = isIndependentUpdate.Value;
			Tweener tweener6 = tween.SetUpdate(updateType, value9);
			if (playInReverse.Value)
			{
				bool value10 = setReverseRelative.Value;
				Tweener tweener7 = tween.From(value10);
			}
			if (startEvent != null)
			{
				TweenCallback action = delegate
				{
					Fsm.Event(startEvent);
				};
				Tweener tweener8 = tween.OnStart(action);
			}
			if (!finishImmediately.Value)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Delegate over an unresolved function pointer: TweenCallback");
				TweenCallback action2 = null;
				if (finishEvent != null)
				{
					IntPtr intPtr = (IntPtr)0;
				}
				else
				{
					IntPtr intPtr = (IntPtr)0;
				}
				Tweener tweener9 = tween.OnComplete(action2);
			}
			Tweener tweener10 = tween.Play();
			if (debugThis.Value)
			{
				State.Debug("DOTween Line Renderer Color");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x600046C")]
		[Address(RVA = "0xAF9304", Offset = "0xAF9304", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EB8230]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022482]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenLineRendererColor()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
