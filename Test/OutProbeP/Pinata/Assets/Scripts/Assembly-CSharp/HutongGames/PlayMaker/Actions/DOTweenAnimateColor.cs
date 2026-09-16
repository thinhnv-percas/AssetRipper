using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Doozy.PlayMaker;
using Doozy.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74D22C", Offset = "0x74D22C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x74D22C", Offset = "0x74D22C")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x74D22C", Offset = "0x74D22C")]
	[Token(Token = "0x200007F")]
	public class DOTweenAnimateColor : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x40002D0")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x764E80", Offset = "0x764E80")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x764E80", Offset = "0x764E80")]
		[Token(Token = "0x40002D1")]
		[FieldOffset(Offset = "0x58")]
		public FsmColor variable;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x764EE0", Offset = "0x764EE0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x764EE0", Offset = "0x764EE0")]
		[Token(Token = "0x40002D2")]
		[FieldOffset(Offset = "0x60")]
		public FsmColor to;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x764F40", Offset = "0x764F40")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x764F40", Offset = "0x764F40")]
		[Token(Token = "0x40002D3")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool setRelative;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x764F90", Offset = "0x764F90")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x764F90", Offset = "0x764F90")]
		[Token(Token = "0x40002D4")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x764FF0", Offset = "0x764FF0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x764FF0", Offset = "0x764FF0")]
		[Token(Token = "0x40002D5")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x765040", Offset = "0x765040")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x765040", Offset = "0x765040")]
		[Token(Token = "0x40002D6")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x765090", Offset = "0x765090")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x765090", Offset = "0x765090")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x765090", Offset = "0x765090")]
		[Token(Token = "0x40002D7")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x765104", Offset = "0x765104")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x765104", Offset = "0x765104")]
		[Token(Token = "0x40002D8")]
		[FieldOffset(Offset = "0x90")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x765154", Offset = "0x765154")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x765154", Offset = "0x765154")]
		[Token(Token = "0x40002D9")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7651A4", Offset = "0x7651A4")]
		[Token(Token = "0x40002DA")]
		[FieldOffset(Offset = "0xA0")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7651B8", Offset = "0x7651B8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7651B8", Offset = "0x7651B8")]
		[Token(Token = "0x40002DB")]
		[FieldOffset(Offset = "0xA8")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x765208", Offset = "0x765208")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x765208", Offset = "0x765208")]
		[Token(Token = "0x40002DC")]
		[FieldOffset(Offset = "0xB0")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x765258", Offset = "0x765258")]
		[Token(Token = "0x40002DD")]
		[FieldOffset(Offset = "0xB8")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x765290", Offset = "0x765290")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x765290", Offset = "0x765290")]
		[Token(Token = "0x40002DE")]
		[FieldOffset(Offset = "0xC0")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7652E0", Offset = "0x7652E0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7652E0", Offset = "0x7652E0")]
		[Token(Token = "0x40002DF")]
		[FieldOffset(Offset = "0xC8")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x765330", Offset = "0x765330")]
		[Token(Token = "0x40002E0")]
		[FieldOffset(Offset = "0xD0")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x765368", Offset = "0x765368")]
		[Token(Token = "0x40002E1")]
		[FieldOffset(Offset = "0xD4")]
		public Ease easeType;

		[Token(Token = "0x40002E2")]
		[FieldOffset(Offset = "0xD8")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7653A0", Offset = "0x7653A0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7653A0", Offset = "0x7653A0")]
		[Token(Token = "0x40002E3")]
		[FieldOffset(Offset = "0xE0")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7653F0", Offset = "0x7653F0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7653F0", Offset = "0x7653F0")]
		[Token(Token = "0x40002E4")]
		[FieldOffset(Offset = "0xE8")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x765440", Offset = "0x765440")]
		[Token(Token = "0x40002E5")]
		[FieldOffset(Offset = "0xF0")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x765478", Offset = "0x765478")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x765478", Offset = "0x765478")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x765478", Offset = "0x765478")]
		[Token(Token = "0x40002E6")]
		[FieldOffset(Offset = "0xF8")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7654EC", Offset = "0x7654EC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7654EC", Offset = "0x7654EC")]
		[Token(Token = "0x40002E7")]
		[FieldOffset(Offset = "0x100")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76553C", Offset = "0x76553C")]
		[Token(Token = "0x40002E8")]
		[FieldOffset(Offset = "0x108")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x765574", Offset = "0x765574")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x765574", Offset = "0x765574")]
		[Token(Token = "0x40002E9")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7655C4", Offset = "0x7655C4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7655C4", Offset = "0x7655C4")]
		[Token(Token = "0x40002EA")]
		[FieldOffset(Offset = "0x118")]
		public FsmBool debugThis;

		[Token(Token = "0x40002EB")]
		[FieldOffset(Offset = "0x120")]
		private Tweener tween;

		[Token(Token = "0x6000371")]
		[Address(RVA = "0xA96CD8", Offset = "0xA96CD8", Length = "0x2C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EE2700]);\n\tv25 = *([v24 @ X8_v11]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202221B]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmColor();\n\tHutongGames.PlayMaker.FsmColor::.ctor(v50);\n\tv50.useVariable = 1;\n\tthis.variable = v50;\n\tv56 = new HutongGames.PlayMaker.FsmColor();\n\tHutongGames.PlayMaker.FsmColor::.ctor(v56);\n\tv56.useVariable = 0;\n\tthis.to = v56;\n\tv80 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v80);\n\tv80.useVariable = 0;\n\tthis.duration = v80;\n\tv81 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v81);\n\tv81.useVariable = 0;\n\tv81.value = 0;\n\tthis.setSpeedBased = v81;\n\tv82 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v82);\n\tv82.useVariable = 0;\n\tv82.value = 0;\n\tthis.setRelative = v82;\n\tv83 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v83);\n\tv83.useVariable = 0;\n\tv83.value = 0;\n\tthis.playInReverse = v83;\n\tv84 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v84);\n\tv84.useVariable = 0;\n\tv84.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v84;\n\tv85 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v85);\n\tv85.useVariable = 0;\n\tv85.value = 0;\n\tthis.finishImmediately = v85;\n\tv86 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v86);\n\tv86.useVariable = 0;\n\tthis.stringAsId = v86;\n\tv87 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v87);\n\tv87.useVariable = 0;\n\tthis.tagAsId = v87;\n\tv88 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v88);\n\tv88.value = 0f;\n\tthis.startDelay = v88;\n\tthis.selectedEase = 0x100000000;\n\tv89 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v89);\n\tv89.value = 0;\n\tthis.loops = v89;\n\tthis.loopType = 0;\n\tv90 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v90);\n\tv90.value = 1;\n\tthis.autoKillOnCompletion = v90;\n\tv91 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v91);\n\tv91.value = 0;\n\tthis.recyclable = v91;\n\tthis.updateType = 0;\n\tv92 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v92);\n\tv92.value = 0;\n\tthis.isIndependentUpdate = v92;\n\tv93 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v93);\n\tv93.value = 0;\n\tthis.debugThis = v93;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 120 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_0206: Expected I4, but got I8
			base.Reset();
			gameObject = null;
			FsmColor fsmColor = new FsmColor();
			fsmColor.useVariable = true;
			variable = fsmColor;
			FsmColor fsmColor2 = new FsmColor();
			fsmColor2.useVariable = false;
			to = fsmColor2;
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

		[Token(Token = "0x6000372")]
		[Address(RVA = "0xA96F98", Offset = "0xA96F98", Length = "0x450")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv34 = *([1F060C8]);\n\tv35 = *([v34 @ X8_v63]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([202221C]) = v54;\nL_001E:\n\tv58 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Color>::.ctor(v58, this, Il2CppMethodInfo);\n\tv70 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Color>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Color>::.ctor(v70, this, Il2CppMethodInfo);\n\tv79 = this.to;\n\tv118 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tgoto L_0056;\n\tv231 = *([v227 @ X0_v11+E0]);\n\tv232 = v231 == 0;\n\tv233 = ~v232;\n\tif (v233) goto L_0056;\n\tv235 = \"il2cpp_codegen_runtime_class_init\"(v227, v117, v77, v78, v40, v41, v42, v43, v118, v45, v46, v47, v48, v49, v50, v51);\nL_0056:\n\t// 86 MakeStruct v85 @ AGGA970AC_2_v3 (UnityEngine.Color), typeof(UnityEngine.Color), v79.value (UnityEngine.Color), v79.value.g (System.Single), v79.value.b (System.Single), v79.value.a (System.Single)\n\tv111 = DG.Tweening.DOTween::To(v58, v70, v85, v118);\n\tthis.tween = v111;\n\tv296 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv298 = v296 == 0;\n\tif (v298) goto L_006C;\n\tv303 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_006C:\n\tv306 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv309 = DG.Tweening.TweenSettingsExtensions::SetRelative(this.tween, v306);\n\tv312 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v312);\n\tv136 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv318 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v136);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv321 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv324 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v321, this.loopType);\n\tv326 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv329 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v326);\n\tv331 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv334 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v331);\n\tv336 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv339 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v336);\n\tv340 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv342 = v340 == 0;\n\tif (v342) goto L_00DD;\n\tv357 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv348 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v357);\nL_00DD:\n\tv355 = this.startEvent == 0;\n\tif (v355) goto L_00F5;\n\tv362 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v362, this, Il2CppMethodInfo);\n\tv368 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v362);\nL_00F5:\n\tv377 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv381 = v377 == 0;\n\tv382 = ~v381;\n\tif (v382) goto L_0117;\n\tv388 = new DG.Tweening.TweenCallback();\n\tv397 = this.finishEvent == 0;\n\tif (v397) goto L_FFFFFFFF;\n\tgoto L_010C;\nL_010C:\n\tDG.Tweening.TweenCallback::.ctor(v388, this, *([v409 @ X8_v43 (Il2CppMethodInfo)]));\n\tv395 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v388);\nL_0117:\n\tv402 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv408 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv414 = v408 == 0;\n\tif (v414) goto L_012A;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Animate Color\");\nL_012A:\n\tv281 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv283 = v281 == 0;\n\tif (v283) goto L_014C;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_014C:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 263 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DOGetter<Color> getter = delegate
			{
				FsmColor fsmColor2 = variable;
				return fsmColor2.value;
			};
			DOSetter<Color> setter = delegate(Color x)
			{
				FsmColor fsmColor2 = variable;
				fsmColor2.value = x;
				fsmColor2.value.g = x.g;
				fsmColor2.value.b = x.b;
				fsmColor2.value.a = x.a;
			};
			FsmColor fsmColor = to;
			float value = duration.Value;
			Color endValue = default(Color);
			endValue.r = fsmColor.value.r;
			endValue.g = fsmColor.value.g;
			endValue.b = fsmColor.value.b;
			endValue.a = fsmColor.value.a;
			TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTween.To(getter, setter, endValue, value);
			tween = tweenerCore;
			if (setSpeedBased.Value)
			{
				Tweener tweener = tween.SetSpeedBased();
			}
			bool value2 = setRelative.Value;
			Tweener tweener2 = tween.SetRelative(value2);
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			tween.SetTweenId(tweenIdType, stringAsId, tagAsId, ownerDefaultTarget);
			float value3 = startDelay.Value;
			Tweener tweener3 = tween.SetDelay(value3);
			tween.SetSelectedEase(selectedEase, easeType, animationCurve);
			int value4 = loops.Value;
			Tweener tweener4 = tween.SetLoops(value4, loopType);
			bool value5 = autoKillOnCompletion.Value;
			Tweener tweener5 = tween.SetAutoKill(value5);
			bool value6 = recyclable.Value;
			Tweener tweener6 = tween.SetRecyclable(value6);
			bool value7 = isIndependentUpdate.Value;
			Tweener tweener7 = tween.SetUpdate(updateType, value7);
			if (playInReverse.Value)
			{
				bool value8 = setReverseRelative.Value;
				Tweener tweener8 = tween.From(value8);
			}
			if (startEvent != null)
			{
				TweenCallback action = delegate
				{
					Fsm.Event(startEvent);
				};
				Tweener tweener9 = tween.OnStart(action);
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
				Tweener tweener10 = tween.OnComplete(action2);
			}
			Tweener tweener11 = tween.Play();
			if (debugThis.Value)
			{
				State.Debug("DOTween Animate Color");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000373")]
		[Address(RVA = "0xA973E8", Offset = "0xA973E8", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1F0A378]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202221D]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenAnimateColor()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
