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
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74DC7C", Offset = "0x74DC7C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x74DC7C", Offset = "0x74DC7C")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x74DC7C", Offset = "0x74DC7C")]
	[Token(Token = "0x2000093")]
	public class DOTweenCanvasGroupFade : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x76E6E0", Offset = "0x76E6E0")]
		[Token(Token = "0x40004F4")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76E754", Offset = "0x76E754")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76E754", Offset = "0x76E754")]
		[Token(Token = "0x40004F5")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat to;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76E7B4", Offset = "0x76E7B4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76E7B4", Offset = "0x76E7B4")]
		[Token(Token = "0x40004F6")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool setRelative;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76E804", Offset = "0x76E804")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76E804", Offset = "0x76E804")]
		[Token(Token = "0x40004F7")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76E864", Offset = "0x76E864")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76E864", Offset = "0x76E864")]
		[Token(Token = "0x40004F8")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76E8B4", Offset = "0x76E8B4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76E8B4", Offset = "0x76E8B4")]
		[Token(Token = "0x40004F9")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x76E904", Offset = "0x76E904")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76E904", Offset = "0x76E904")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76E904", Offset = "0x76E904")]
		[Token(Token = "0x40004FA")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76E978", Offset = "0x76E978")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76E978", Offset = "0x76E978")]
		[Token(Token = "0x40004FB")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x76E9C8", Offset = "0x76E9C8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76E9C8", Offset = "0x76E9C8")]
		[Token(Token = "0x40004FC")]
		[FieldOffset(Offset = "0x90")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76EA18", Offset = "0x76EA18")]
		[Token(Token = "0x40004FD")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76EA2C", Offset = "0x76EA2C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76EA2C", Offset = "0x76EA2C")]
		[Token(Token = "0x40004FE")]
		[FieldOffset(Offset = "0xA0")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x76EA7C", Offset = "0x76EA7C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76EA7C", Offset = "0x76EA7C")]
		[Token(Token = "0x40004FF")]
		[FieldOffset(Offset = "0xA8")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76EACC", Offset = "0x76EACC")]
		[Token(Token = "0x4000500")]
		[FieldOffset(Offset = "0xB0")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76EB04", Offset = "0x76EB04")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76EB04", Offset = "0x76EB04")]
		[Token(Token = "0x4000501")]
		[FieldOffset(Offset = "0xB8")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76EB54", Offset = "0x76EB54")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76EB54", Offset = "0x76EB54")]
		[Token(Token = "0x4000502")]
		[FieldOffset(Offset = "0xC0")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x76EBA4", Offset = "0x76EBA4")]
		[Token(Token = "0x4000503")]
		[FieldOffset(Offset = "0xC8")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76EBDC", Offset = "0x76EBDC")]
		[Token(Token = "0x4000504")]
		[FieldOffset(Offset = "0xCC")]
		public Ease easeType;

		[Token(Token = "0x4000505")]
		[FieldOffset(Offset = "0xD0")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x76EC14", Offset = "0x76EC14")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76EC14", Offset = "0x76EC14")]
		[Token(Token = "0x4000506")]
		[FieldOffset(Offset = "0xD8")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76EC64", Offset = "0x76EC64")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76EC64", Offset = "0x76EC64")]
		[Token(Token = "0x4000507")]
		[FieldOffset(Offset = "0xE0")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76ECB4", Offset = "0x76ECB4")]
		[Token(Token = "0x4000508")]
		[FieldOffset(Offset = "0xE8")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x76ECEC", Offset = "0x76ECEC")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76ECEC", Offset = "0x76ECEC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76ECEC", Offset = "0x76ECEC")]
		[Token(Token = "0x4000509")]
		[FieldOffset(Offset = "0xF0")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76ED60", Offset = "0x76ED60")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76ED60", Offset = "0x76ED60")]
		[Token(Token = "0x400050A")]
		[FieldOffset(Offset = "0xF8")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76EDB0", Offset = "0x76EDB0")]
		[Token(Token = "0x400050B")]
		[FieldOffset(Offset = "0x100")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76EDE8", Offset = "0x76EDE8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76EDE8", Offset = "0x76EDE8")]
		[Token(Token = "0x400050C")]
		[FieldOffset(Offset = "0x108")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x76EE38", Offset = "0x76EE38")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76EE38", Offset = "0x76EE38")]
		[Token(Token = "0x400050D")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool debugThis;

		[Token(Token = "0x400050E")]
		[FieldOffset(Offset = "0x118")]
		private Tweener tween;

		[Token(Token = "0x60003E3")]
		[Address(RVA = "0xAEF9D0", Offset = "0xAEF9D0", Length = "0x294")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EA9BD0]);\n\tv25 = *([v24 @ X8_v10]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202242A]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.to = v50;\n\tv55 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v55);\n\tv55.useVariable = 0;\n\tthis.duration = v55;\n\tv76 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v76);\n\tv76.useVariable = 0;\n\tv76.value = 0;\n\tthis.setSpeedBased = v76;\n\tv77 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v77);\n\tv77.useVariable = 0;\n\tv77.value = 0;\n\tthis.setRelative = v77;\n\tv78 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v78);\n\tv78.useVariable = 0;\n\tv78.value = 0;\n\tthis.playInReverse = v78;\n\tv79 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v79);\n\tv79.useVariable = 0;\n\tv79.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v79;\n\tv80 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v80);\n\tv80.useVariable = 0;\n\tv80.value = 0;\n\tthis.finishImmediately = v80;\n\tv81 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v81);\n\tv81.useVariable = 0;\n\tthis.stringAsId = v81;\n\tv82 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v82);\n\tv82.useVariable = 0;\n\tthis.tagAsId = v82;\n\tv83 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v83);\n\tv83.value = 0f;\n\tthis.startDelay = v83;\n\tthis.selectedEase = 0x100000000;\n\tv84 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v84);\n\tv84.value = 0;\n\tthis.loops = v84;\n\tthis.loopType = 0;\n\tv85 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v85);\n\tv85.value = 1;\n\tthis.autoKillOnCompletion = v85;\n\tv86 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v86);\n\tv86.value = 0;\n\tthis.recyclable = v86;\n\tthis.updateType = 0;\n\tv87 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v87);\n\tv87.value = 0;\n\tthis.isIndependentUpdate = v87;\n\tv88 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v88);\n\tv88.value = 0;\n\tthis.debugThis = v88;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 112 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_01df: Expected I4, but got I8
			base.Reset();
			gameObject = null;
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
			FsmString fsmString = new FsmString();
			fsmString.useVariable = false;
			stringAsId = fsmString;
			FsmString fsmString2 = new FsmString();
			fsmString2.useVariable = false;
			tagAsId = fsmString2;
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

		[Token(Token = "0x60003E4")]
		[Address(RVA = "0xAEFC64", Offset = "0xAEFC64", Length = "0x3AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1EDD990]);\n\tv27 = *([v26 @ X8_v49]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([202242B]) = v46;\nL_001C:\n\tv51 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv170 = UnityEngine.GameObject::GetComponent(v51);\n\tv79 = HutongGames.PlayMaker.FsmFloat::get_Value(this.to);\n\tv223 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tv171 = DG.Tweening.DOTweenModuleUI::DOFade(v170, v79, v223);\n\tthis.tween = v171;\n\tv227 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv230 = DG.Tweening.TweenSettingsExtensions::SetRelative(v171, v227);\n\tv233 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v233);\n\tv81 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv239 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v81);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv242 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv245 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v242, this.loopType);\n\tv247 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv250 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v247);\n\tv252 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv255 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v252);\n\tv257 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv260 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v257);\n\tv261 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv263 = v261 == 0;\n\tif (v263) goto L_00AD;\n\tv278 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv269 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v278);\nL_00AD:\n\tv276 = this.startEvent == 0;\n\tif (v276) goto L_00C5;\n\tv283 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v283, this, Il2CppMethodInfo);\n\tv289 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v283);\nL_00C5:\n\tv298 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv302 = v298 == 0;\n\tv303 = ~v302;\n\tif (v303) goto L_00E7;\n\tv309 = new DG.Tweening.TweenCallback();\n\tv318 = this.finishEvent == 0;\n\tif (v318) goto L_FFFFFFFF;\n\tgoto L_00DC;\nL_00DC:\n\tDG.Tweening.TweenCallback::.ctor(v309, this, *([v330 @ X8_v32 (Il2CppMethodInfo)]));\n\tv316 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v309);\nL_00E7:\n\tv323 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv329 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv335 = v329 == 0;\n\tif (v335) goto L_00FA;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Canvas Group Fade\");\nL_00FA:\n\tv208 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv210 = v208 == 0;\n\tif (v210) goto L_0114;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0114:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 220 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			CanvasGroup component = ownerDefaultTarget.GetComponent<CanvasGroup>();
			float value = to.Value;
			float value2 = duration.Value;
			TweenerCore<float, float, FloatOptions> t = (TweenerCore<float, float, FloatOptions>)(tween = component.DOFade(value, value2));
			bool value3 = setRelative.Value;
			Tweener tweener = ((Tweener)t).SetRelative(value3);
			GameObject ownerDefaultTarget2 = Fsm.GetOwnerDefaultTarget(gameObject);
			tween.SetTweenId(tweenIdType, stringAsId, tagAsId, ownerDefaultTarget2);
			float value4 = startDelay.Value;
			Tweener tweener2 = tween.SetDelay(value4);
			tween.SetSelectedEase(selectedEase, easeType, animationCurve);
			int value5 = loops.Value;
			Tweener tweener3 = tween.SetLoops(value5, loopType);
			bool value6 = autoKillOnCompletion.Value;
			Tweener tweener4 = tween.SetAutoKill(value6);
			bool value7 = recyclable.Value;
			Tweener tweener5 = tween.SetRecyclable(value7);
			bool value8 = isIndependentUpdate.Value;
			Tweener tweener6 = tween.SetUpdate(updateType, value8);
			if (playInReverse.Value)
			{
				bool value9 = setReverseRelative.Value;
				Tweener tweener7 = tween.From(value9);
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
				State.Debug("DOTween Canvas Group Fade");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x60003E5")]
		[Address(RVA = "0xAF0010", Offset = "0xAF0010", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ECC580]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202242C]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenCanvasGroupFade()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
