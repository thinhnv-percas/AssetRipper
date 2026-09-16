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
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74D4C0", Offset = "0x74D4C0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x74D4C0", Offset = "0x74D4C0")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x74D4C0", Offset = "0x74D4C0")]
	[Token(Token = "0x2000084")]
	public class DOTweenAnimateVector2 : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x400035C")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7674B4", Offset = "0x7674B4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7674B4", Offset = "0x7674B4")]
		[Token(Token = "0x400035D")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector2 variable;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x767514", Offset = "0x767514")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x767514", Offset = "0x767514")]
		[Token(Token = "0x400035E")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector2 to;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x767574", Offset = "0x767574")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x767574", Offset = "0x767574")]
		[Token(Token = "0x400035F")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool setRelative;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7675C4", Offset = "0x7675C4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7675C4", Offset = "0x7675C4")]
		[Token(Token = "0x4000360")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x767624", Offset = "0x767624")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x767624", Offset = "0x767624")]
		[Token(Token = "0x4000361")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x767674", Offset = "0x767674")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x767674", Offset = "0x767674")]
		[Token(Token = "0x4000362")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7676C4", Offset = "0x7676C4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7676C4", Offset = "0x7676C4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7676C4", Offset = "0x7676C4")]
		[Token(Token = "0x4000363")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x767738", Offset = "0x767738")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x767738", Offset = "0x767738")]
		[Token(Token = "0x4000364")]
		[FieldOffset(Offset = "0x90")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x767788", Offset = "0x767788")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x767788", Offset = "0x767788")]
		[Token(Token = "0x4000365")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7677D8", Offset = "0x7677D8")]
		[Token(Token = "0x4000366")]
		[FieldOffset(Offset = "0xA0")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7677EC", Offset = "0x7677EC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7677EC", Offset = "0x7677EC")]
		[Token(Token = "0x4000367")]
		[FieldOffset(Offset = "0xA8")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x76783C", Offset = "0x76783C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76783C", Offset = "0x76783C")]
		[Token(Token = "0x4000368")]
		[FieldOffset(Offset = "0xB0")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76788C", Offset = "0x76788C")]
		[Token(Token = "0x4000369")]
		[FieldOffset(Offset = "0xB8")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7678C4", Offset = "0x7678C4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7678C4", Offset = "0x7678C4")]
		[Token(Token = "0x400036A")]
		[FieldOffset(Offset = "0xC0")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x767914", Offset = "0x767914")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x767914", Offset = "0x767914")]
		[Token(Token = "0x400036B")]
		[FieldOffset(Offset = "0xC8")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x767964", Offset = "0x767964")]
		[Token(Token = "0x400036C")]
		[FieldOffset(Offset = "0xD0")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76799C", Offset = "0x76799C")]
		[Token(Token = "0x400036D")]
		[FieldOffset(Offset = "0xD4")]
		public Ease easeType;

		[Token(Token = "0x400036E")]
		[FieldOffset(Offset = "0xD8")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7679D4", Offset = "0x7679D4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7679D4", Offset = "0x7679D4")]
		[Token(Token = "0x400036F")]
		[FieldOffset(Offset = "0xE0")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x767A24", Offset = "0x767A24")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x767A24", Offset = "0x767A24")]
		[Token(Token = "0x4000370")]
		[FieldOffset(Offset = "0xE8")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x767A74", Offset = "0x767A74")]
		[Token(Token = "0x4000371")]
		[FieldOffset(Offset = "0xF0")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x767AAC", Offset = "0x767AAC")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x767AAC", Offset = "0x767AAC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x767AAC", Offset = "0x767AAC")]
		[Token(Token = "0x4000372")]
		[FieldOffset(Offset = "0xF8")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x767B20", Offset = "0x767B20")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x767B20", Offset = "0x767B20")]
		[Token(Token = "0x4000373")]
		[FieldOffset(Offset = "0x100")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x767B70", Offset = "0x767B70")]
		[Token(Token = "0x4000374")]
		[FieldOffset(Offset = "0x108")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x767BA8", Offset = "0x767BA8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x767BA8", Offset = "0x767BA8")]
		[Token(Token = "0x4000375")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x767BF8", Offset = "0x767BF8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x767BF8", Offset = "0x767BF8")]
		[Token(Token = "0x4000376")]
		[FieldOffset(Offset = "0x118")]
		public FsmBool debugThis;

		[Token(Token = "0x4000377")]
		[FieldOffset(Offset = "0x120")]
		private Tweener tween;

		[Token(Token = "0x6000394")]
		[Address(RVA = "0xA99478", Offset = "0xA99478", Length = "0x2C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EE6B38]);\n\tv25 = *([v24 @ X8_v11]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202222A]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.FsmVector2::.ctor(v50);\n\tv50.useVariable = 1;\n\tthis.variable = v50;\n\tv56 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.FsmVector2::.ctor(v56);\n\tv56.useVariable = 0;\n\tthis.to = v56;\n\tv80 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v80);\n\tv80.useVariable = 0;\n\tthis.duration = v80;\n\tv81 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v81);\n\tv81.useVariable = 0;\n\tv81.value = 0;\n\tthis.setSpeedBased = v81;\n\tv82 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v82);\n\tv82.useVariable = 0;\n\tv82.value = 0;\n\tthis.setRelative = v82;\n\tv83 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v83);\n\tv83.useVariable = 0;\n\tv83.value = 0;\n\tthis.playInReverse = v83;\n\tv84 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v84);\n\tv84.useVariable = 0;\n\tv84.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v84;\n\tv85 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v85);\n\tv85.useVariable = 0;\n\tv85.value = 0;\n\tthis.finishImmediately = v85;\n\tv86 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v86);\n\tv86.useVariable = 0;\n\tthis.stringAsId = v86;\n\tv87 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v87);\n\tv87.useVariable = 0;\n\tthis.tagAsId = v87;\n\tv88 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v88);\n\tv88.value = 0f;\n\tthis.startDelay = v88;\n\tthis.selectedEase = 0x100000000;\n\tv89 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v89);\n\tv89.value = 0;\n\tthis.loops = v89;\n\tthis.loopType = 0;\n\tv90 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v90);\n\tv90.value = 1;\n\tthis.autoKillOnCompletion = v90;\n\tv91 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v91);\n\tv91.value = 0;\n\tthis.recyclable = v91;\n\tthis.updateType = 0;\n\tv92 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v92);\n\tv92.value = 0;\n\tthis.isIndependentUpdate = v92;\n\tv93 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v93);\n\tv93.value = 0;\n\tthis.debugThis = v93;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 120 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_0206: Expected I4, but got I8
			base.Reset();
			gameObject = null;
			FsmVector2 fsmVector = new FsmVector2();
			fsmVector.useVariable = true;
			variable = fsmVector;
			FsmVector2 fsmVector2 = new FsmVector2();
			fsmVector2.useVariable = false;
			to = fsmVector2;
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

		[Token(Token = "0x6000395")]
		[Address(RVA = "0xA99738", Offset = "0xA99738", Length = "0x438")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv30 = *([1EB5B08]);\n\tv31 = *([v30 @ X8_v63]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([202222B]) = v50;\nL_001C:\n\tv54 = new DG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOGetter`1<UnityEngine.Vector2>::.ctor(v54, this, Il2CppMethodInfo);\n\tv66 = new DG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>();\n\tDG.Tweening.Core.DOSetter`1<UnityEngine.Vector2>::.ctor(v66, this, Il2CppMethodInfo);\n\tv75 = this.to;\n\tv106 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tgoto L_0050;\n\tv215 = *([v211 @ X0_v11+E0]);\n\tv216 = v215 == 0;\n\tv217 = ~v216;\n\tif (v217) goto L_0050;\n\tv219 = \"il2cpp_codegen_runtime_class_init\"(v211, v105, v73, v74, v36, v37, v38, v39, v106, v41, v42, v43, v44, v45, v46, v47);\nL_0050:\n\t// 80 MakeStruct v81 @ AGGA9983C_2_v3 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v75.value (UnityEngine.Vector2), v75.value.y (System.Single)\n\tv99 = DG.Tweening.DOTween::To(v54, v66, v81, v106);\n\tthis.tween = v99;\n\tv272 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv274 = v272 == 0;\n\tif (v274) goto L_0066;\n\tv279 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_0066:\n\tv282 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv285 = DG.Tweening.TweenSettingsExtensions::SetRelative(this.tween, v282);\n\tv288 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v288);\n\tv122 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv294 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v122);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv297 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv300 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v297, this.loopType);\n\tv302 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv305 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v302);\n\tv307 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv310 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v307);\n\tv312 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv315 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v312);\n\tv316 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv318 = v316 == 0;\n\tif (v318) goto L_00D7;\n\tv333 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv324 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v333);\nL_00D7:\n\tv331 = this.startEvent == 0;\n\tif (v331) goto L_00EF;\n\tv338 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v338, this, Il2CppMethodInfo);\n\tv344 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v338);\nL_00EF:\n\tv353 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv357 = v353 == 0;\n\tv358 = ~v357;\n\tif (v358) goto L_0111;\n\tv364 = new DG.Tweening.TweenCallback();\n\tv373 = this.finishEvent == 0;\n\tif (v373) goto L_FFFFFFFF;\n\tgoto L_0106;\nL_0106:\n\tDG.Tweening.TweenCallback::.ctor(v364, this, *([v385 @ X8_v43 (Il2CppMethodInfo)]));\n\tv371 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v364);\nL_0111:\n\tv378 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv384 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv390 = v384 == 0;\n\tif (v390) goto L_0124;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Animate Vector2\");\nL_0124:\n\tv257 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv259 = v257 == 0;\n\tif (v259) goto L_0142;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0142:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 253 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DOGetter<Vector2> getter = delegate
			{
				FsmVector2 fsmVector2 = variable;
				return fsmVector2.value;
			};
			DOSetter<Vector2> setter = delegate(Vector2 x)
			{
				FsmVector2 fsmVector2 = variable;
				fsmVector2.value = x;
				fsmVector2.value.y = x.y;
			};
			FsmVector2 fsmVector = to;
			float value = duration.Value;
			Vector2 endValue = default(Vector2);
			endValue.x = fsmVector.value.x;
			endValue.y = fsmVector.value.y;
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = DOTween.To(getter, setter, endValue, value);
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
				State.Debug("DOTween Animate Vector2");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000396")]
		[Address(RVA = "0xA99B70", Offset = "0xA99B70", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EE8E98]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202222C]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenAnimateVector2()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
