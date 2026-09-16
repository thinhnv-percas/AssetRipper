using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Doozy.PlayMaker;
using Doozy.PlayMaker.Actions;
using UnityEngine;
using UnityEngine.Audio;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74D5C8", Offset = "0x74D5C8")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x74D5C8", Offset = "0x74D5C8")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x74D5C8", Offset = "0x74D5C8")]
	[Token(Token = "0x2000086")]
	public class DOTweenAudioMixerSetFloat : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x4000394")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7683FC", Offset = "0x7683FC")]
		[Token(Token = "0x4000395")]
		[FieldOffset(Offset = "0x58")]
		public string descriptionArea;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x768410", Offset = "0x768410")]
		[Token(Token = "0x4000396")]
		[FieldOffset(Offset = "0x60")]
		public AudioMixer audioMixer;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76845C", Offset = "0x76845C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76845C", Offset = "0x76845C")]
		[Token(Token = "0x4000397")]
		[FieldOffset(Offset = "0x68")]
		public FsmString floatName;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7684BC", Offset = "0x7684BC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7684BC", Offset = "0x7684BC")]
		[Token(Token = "0x4000398")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat to;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76851C", Offset = "0x76851C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76851C", Offset = "0x76851C")]
		[Token(Token = "0x4000399")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool setRelative;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76856C", Offset = "0x76856C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76856C", Offset = "0x76856C")]
		[Token(Token = "0x400039A")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7685CC", Offset = "0x7685CC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7685CC", Offset = "0x7685CC")]
		[Token(Token = "0x400039B")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76861C", Offset = "0x76861C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76861C", Offset = "0x76861C")]
		[Token(Token = "0x400039C")]
		[FieldOffset(Offset = "0x90")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x76866C", Offset = "0x76866C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76866C", Offset = "0x76866C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76866C", Offset = "0x76866C")]
		[Token(Token = "0x400039D")]
		[FieldOffset(Offset = "0x98")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7686E0", Offset = "0x7686E0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7686E0", Offset = "0x7686E0")]
		[Token(Token = "0x400039E")]
		[FieldOffset(Offset = "0xA0")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x768730", Offset = "0x768730")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x768730", Offset = "0x768730")]
		[Token(Token = "0x400039F")]
		[FieldOffset(Offset = "0xA8")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x768780", Offset = "0x768780")]
		[Token(Token = "0x40003A0")]
		[FieldOffset(Offset = "0xB0")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x768794", Offset = "0x768794")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x768794", Offset = "0x768794")]
		[Token(Token = "0x40003A1")]
		[FieldOffset(Offset = "0xB8")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7687E4", Offset = "0x7687E4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7687E4", Offset = "0x7687E4")]
		[Token(Token = "0x40003A2")]
		[FieldOffset(Offset = "0xC0")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x768834", Offset = "0x768834")]
		[Token(Token = "0x40003A3")]
		[FieldOffset(Offset = "0xC8")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76886C", Offset = "0x76886C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76886C", Offset = "0x76886C")]
		[Token(Token = "0x40003A4")]
		[FieldOffset(Offset = "0xD0")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7688BC", Offset = "0x7688BC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7688BC", Offset = "0x7688BC")]
		[Token(Token = "0x40003A5")]
		[FieldOffset(Offset = "0xD8")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x76890C", Offset = "0x76890C")]
		[Token(Token = "0x40003A6")]
		[FieldOffset(Offset = "0xE0")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x768944", Offset = "0x768944")]
		[Token(Token = "0x40003A7")]
		[FieldOffset(Offset = "0xE4")]
		public Ease easeType;

		[Token(Token = "0x40003A8")]
		[FieldOffset(Offset = "0xE8")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x76897C", Offset = "0x76897C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76897C", Offset = "0x76897C")]
		[Token(Token = "0x40003A9")]
		[FieldOffset(Offset = "0xF0")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7689CC", Offset = "0x7689CC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7689CC", Offset = "0x7689CC")]
		[Token(Token = "0x40003AA")]
		[FieldOffset(Offset = "0xF8")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x768A1C", Offset = "0x768A1C")]
		[Token(Token = "0x40003AB")]
		[FieldOffset(Offset = "0x100")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x768A54", Offset = "0x768A54")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x768A54", Offset = "0x768A54")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x768A54", Offset = "0x768A54")]
		[Token(Token = "0x40003AC")]
		[FieldOffset(Offset = "0x108")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x768AC8", Offset = "0x768AC8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x768AC8", Offset = "0x768AC8")]
		[Token(Token = "0x40003AD")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x768B18", Offset = "0x768B18")]
		[Token(Token = "0x40003AE")]
		[FieldOffset(Offset = "0x118")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x768B50", Offset = "0x768B50")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x768B50", Offset = "0x768B50")]
		[Token(Token = "0x40003AF")]
		[FieldOffset(Offset = "0x120")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x768BA0", Offset = "0x768BA0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x768BA0", Offset = "0x768BA0")]
		[Token(Token = "0x40003B0")]
		[FieldOffset(Offset = "0x128")]
		public FsmBool debugThis;

		[Token(Token = "0x40003B1")]
		[FieldOffset(Offset = "0x130")]
		private Tweener tween;

		[Token(Token = "0x60003A2")]
		[Address(RVA = "0xA9A460", Offset = "0xA9A460", Length = "0x2B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1F01AD0]);\n\tv25 = *([v24 @ X8_v10]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022230]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tv50 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.floatName = v50;\n\tv57 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v57);\n\tv57.useVariable = 0;\n\tthis.to = v57;\n\tv78 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v78);\n\tv78.useVariable = 0;\n\tthis.duration = v78;\n\tv79 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v79);\n\tv79.useVariable = 0;\n\tv79.value = 0;\n\tthis.setSpeedBased = v79;\n\tv80 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v80);\n\tv80.useVariable = 0;\n\tv80.value = 0;\n\tthis.setRelative = v80;\n\tv81 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v81);\n\tv81.useVariable = 0;\n\tv81.value = 0;\n\tthis.playInReverse = v81;\n\tv82 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v82);\n\tv82.useVariable = 0;\n\tv82.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v82;\n\tv83 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v83);\n\tv83.useVariable = 0;\n\tv83.value = 0;\n\tthis.finishImmediately = v83;\n\tv84 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v84);\n\tv84.useVariable = 0;\n\tthis.stringAsId = v84;\n\tv85 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v85);\n\tv85.useVariable = 0;\n\tthis.tagAsId = v85;\n\tv86 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v86);\n\tv86.value = 0f;\n\tthis.startDelay = v86;\n\tthis.selectedEase = 0x100000000;\n\tv87 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v87);\n\tv87.value = 0;\n\tthis.loops = v87;\n\tthis.loopType = 0;\n\tv88 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v88);\n\tv88.value = 1;\n\tthis.autoKillOnCompletion = v88;\n\tv89 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v89);\n\tv89.value = 0;\n\tthis.recyclable = v89;\n\tthis.updateType = 0;\n\tv90 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v90);\n\tv90.value = 0;\n\tthis.isIndependentUpdate = v90;\n\tv91 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v91);\n\tv91.value = 0;\n\tthis.debugThis = v91;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 117 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_0206: Expected I4, but got I8
			base.Reset();
			FsmString fsmString = new FsmString();
			fsmString.useVariable = false;
			floatName = fsmString;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = false;
			to = fsmFloat;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = false;
			duration = fsmFloat2;
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
			FsmString fsmString2 = new FsmString();
			fsmString2.useVariable = false;
			stringAsId = fsmString2;
			FsmString fsmString3 = new FsmString();
			fsmString3.useVariable = false;
			tagAsId = fsmString3;
			FsmFloat fsmFloat3 = new FsmFloat();
			fsmFloat3.Value = 0f;
			startDelay = fsmFloat3;
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

		[Token(Token = "0x60003A3")]
		[Address(RVA = "0xA9A710", Offset = "0xA9A710", Length = "0x43C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv26 = *([1F094C8]);\n\tv27 = *([v26 @ X8_v58]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2022231]) = v46;\nL_001E:\n\tgoto L_0027;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0027;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0027:\n\tv64 = UnityEngine.Object::op_Equality(this.audioMixer, 0);\n\tv66 = v64 == 0;\n\tif (v66) goto L_0048;\n\tv72 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv185 = v72 == 0;\n\tif (v185) goto L_0148;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"ERROR - DOTween AudioMixer SetFloat - There is no AudioMixer linked to this state\");\n\treturn;\nL_0048:\n\tv183 = HutongGames.PlayMaker.FsmString::get_Value(this.floatName);\n\tv88 = HutongGames.PlayMaker.FsmFloat::get_Value(this.to);\n\tv277 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tv199 = DG.Tweening.DOTweenModuleAudio::DOSetFloat(this.audioMixer, v183, v88, v277);\n\tthis.tween = v199;\n\tv281 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv283 = v281 == 0;\n\tif (v283) goto L_0070;\n\tv288 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_0070:\n\tv291 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv294 = DG.Tweening.TweenSettingsExtensions::SetRelative(this.tween, v291);\n\tv297 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v297);\n\tv90 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv303 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v90);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv306 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv309 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v306, this.loopType);\n\tv311 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv314 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v311);\n\tv316 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv319 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v316);\n\tv321 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv324 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v321);\n\tv325 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv327 = v325 == 0;\n\tif (v327) goto L_00E1;\n\tv342 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv333 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v342);\nL_00E1:\n\tv340 = this.startEvent == 0;\n\tif (v340) goto L_00F9;\n\tv347 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v347, this, Il2CppMethodInfo);\n\tv353 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v347);\nL_00F9:\n\tv362 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv366 = v362 == 0;\n\tv367 = ~v366;\n\tif (v367) goto L_011B;\n\tv373 = new DG.Tweening.TweenCallback();\n\tv382 = this.finishEvent == 0;\n\tif (v382) goto L_FFFFFFFF;\n\tgoto L_0110;\nL_0110:\n\tDG.Tweening.TweenCallback::.ctor(v373, this, *([v394 @ X8_v36 (Il2CppMethodInfo)]));\n\tv380 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v373);\nL_011B:\n\tv387 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv393 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv399 = v393 == 0;\n\tif (v399) goto L_012E;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween AudioMixer SetFloat\");\nL_012E:\n\tv234 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv236 = v234 == 0;\n\tif (v236) goto L_0148;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0148:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 255 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			if (audioMixer == null)
			{
				if (debugThis.Value)
				{
					State.Debug("ERROR - DOTween AudioMixer SetFloat - There is no AudioMixer linked to this state");
				}
				return;
			}
			string value = floatName.Value;
			float value2 = to.Value;
			float value3 = duration.Value;
			TweenerCore<float, float, FloatOptions> tweenerCore = audioMixer.DOSetFloat(value, value2, value3);
			tween = tweenerCore;
			if (setSpeedBased.Value)
			{
				Tweener tweener = tween.SetSpeedBased();
			}
			bool value4 = setRelative.Value;
			Tweener tweener2 = tween.SetRelative(value4);
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			tween.SetTweenId(tweenIdType, stringAsId, tagAsId, ownerDefaultTarget);
			float value5 = startDelay.Value;
			Tweener tweener3 = tween.SetDelay(value5);
			tween.SetSelectedEase(selectedEase, easeType, animationCurve);
			int value6 = loops.Value;
			Tweener tweener4 = tween.SetLoops(value6, loopType);
			bool value7 = autoKillOnCompletion.Value;
			Tweener tweener5 = tween.SetAutoKill(value7);
			bool value8 = recyclable.Value;
			Tweener tweener6 = tween.SetRecyclable(value8);
			bool value9 = isIndependentUpdate.Value;
			Tweener tweener7 = tween.SetUpdate(updateType, value9);
			if (playInReverse.Value)
			{
				bool value10 = setReverseRelative.Value;
				Tweener tweener8 = tween.From(value10);
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
				State.Debug("DOTween AudioMixer SetFloat");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x60003A4")]
		[Address(RVA = "0xA9AB4C", Offset = "0xA9AB4C", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1F073E8]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022232]) = v38;\nL_001A:\n\tthis.descriptionArea = \"Drag and Drop an AudioMixer from the ProjectView\";\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenAudioMixerSetFloat()
		{
			descriptionArea = "Drag and Drop an AudioMixer from the ProjectView";
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
