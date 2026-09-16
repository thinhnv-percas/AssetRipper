using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Doozy.PlayMaker;
using Doozy.PlayMaker.Actions;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74F6C8", Offset = "0x74F6C8")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x74F6C8", Offset = "0x74F6C8")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x74F6C8", Offset = "0x74F6C8")]
	[Token(Token = "0x20000C6")]
	public class DOTweenOutlineFade : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x77CE04", Offset = "0x77CE04")]
		[Token(Token = "0x400081A")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77CE78", Offset = "0x77CE78")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77CE78", Offset = "0x77CE78")]
		[Token(Token = "0x400081B")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat to;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77CED8", Offset = "0x77CED8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77CED8", Offset = "0x77CED8")]
		[Token(Token = "0x400081C")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool setRelative;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77CF28", Offset = "0x77CF28")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77CF28", Offset = "0x77CF28")]
		[Token(Token = "0x400081D")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77CF88", Offset = "0x77CF88")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77CF88", Offset = "0x77CF88")]
		[Token(Token = "0x400081E")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77CFD8", Offset = "0x77CFD8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77CFD8", Offset = "0x77CFD8")]
		[Token(Token = "0x400081F")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77D028", Offset = "0x77D028")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77D028", Offset = "0x77D028")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77D028", Offset = "0x77D028")]
		[Token(Token = "0x4000820")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77D09C", Offset = "0x77D09C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77D09C", Offset = "0x77D09C")]
		[Token(Token = "0x4000821")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77D0EC", Offset = "0x77D0EC")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77D0EC", Offset = "0x77D0EC")]
		[Token(Token = "0x4000822")]
		[FieldOffset(Offset = "0x90")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77D13C", Offset = "0x77D13C")]
		[Token(Token = "0x4000823")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77D150", Offset = "0x77D150")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77D150", Offset = "0x77D150")]
		[Token(Token = "0x4000824")]
		[FieldOffset(Offset = "0xA0")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77D1A0", Offset = "0x77D1A0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77D1A0", Offset = "0x77D1A0")]
		[Token(Token = "0x4000825")]
		[FieldOffset(Offset = "0xA8")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77D1F0", Offset = "0x77D1F0")]
		[Token(Token = "0x4000826")]
		[FieldOffset(Offset = "0xB0")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77D228", Offset = "0x77D228")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77D228", Offset = "0x77D228")]
		[Token(Token = "0x4000827")]
		[FieldOffset(Offset = "0xB8")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77D278", Offset = "0x77D278")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77D278", Offset = "0x77D278")]
		[Token(Token = "0x4000828")]
		[FieldOffset(Offset = "0xC0")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77D2C8", Offset = "0x77D2C8")]
		[Token(Token = "0x4000829")]
		[FieldOffset(Offset = "0xC8")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77D300", Offset = "0x77D300")]
		[Token(Token = "0x400082A")]
		[FieldOffset(Offset = "0xCC")]
		public Ease easeType;

		[Token(Token = "0x400082B")]
		[FieldOffset(Offset = "0xD0")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77D338", Offset = "0x77D338")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77D338", Offset = "0x77D338")]
		[Token(Token = "0x400082C")]
		[FieldOffset(Offset = "0xD8")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77D388", Offset = "0x77D388")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77D388", Offset = "0x77D388")]
		[Token(Token = "0x400082D")]
		[FieldOffset(Offset = "0xE0")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77D3D8", Offset = "0x77D3D8")]
		[Token(Token = "0x400082E")]
		[FieldOffset(Offset = "0xE8")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77D410", Offset = "0x77D410")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77D410", Offset = "0x77D410")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77D410", Offset = "0x77D410")]
		[Token(Token = "0x400082F")]
		[FieldOffset(Offset = "0xF0")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77D484", Offset = "0x77D484")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77D484", Offset = "0x77D484")]
		[Token(Token = "0x4000830")]
		[FieldOffset(Offset = "0xF8")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77D4D4", Offset = "0x77D4D4")]
		[Token(Token = "0x4000831")]
		[FieldOffset(Offset = "0x100")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77D50C", Offset = "0x77D50C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77D50C", Offset = "0x77D50C")]
		[Token(Token = "0x4000832")]
		[FieldOffset(Offset = "0x108")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77D55C", Offset = "0x77D55C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77D55C", Offset = "0x77D55C")]
		[Token(Token = "0x4000833")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool debugThis;

		[Token(Token = "0x4000834")]
		[FieldOffset(Offset = "0x118")]
		private Tweener tween;

		[Token(Token = "0x60004B0")]
		[Address(RVA = "0xA1851C", Offset = "0xA1851C", Length = "0x294")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EF80D8]);\n\tv25 = *([v24 @ X8_v10]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021D3D]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.to = v50;\n\tv55 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v55);\n\tv55.useVariable = 0;\n\tthis.duration = v55;\n\tv76 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v76);\n\tv76.useVariable = 0;\n\tv76.value = 0;\n\tthis.setSpeedBased = v76;\n\tv77 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v77);\n\tv77.useVariable = 0;\n\tv77.value = 0;\n\tthis.setRelative = v77;\n\tv78 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v78);\n\tv78.useVariable = 0;\n\tv78.value = 0;\n\tthis.playInReverse = v78;\n\tv79 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v79);\n\tv79.useVariable = 0;\n\tv79.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v79;\n\tv80 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v80);\n\tv80.useVariable = 0;\n\tv80.value = 0;\n\tthis.finishImmediately = v80;\n\tv81 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v81);\n\tv81.useVariable = 0;\n\tthis.stringAsId = v81;\n\tv82 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v82);\n\tv82.useVariable = 0;\n\tthis.tagAsId = v82;\n\tv83 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v83);\n\tv83.value = 0f;\n\tthis.startDelay = v83;\n\tthis.selectedEase = 0x100000000;\n\tv84 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v84);\n\tv84.value = 0;\n\tthis.loops = v84;\n\tthis.loopType = 0;\n\tv85 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v85);\n\tv85.value = 1;\n\tthis.autoKillOnCompletion = v85;\n\tv86 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v86);\n\tv86.value = 0;\n\tthis.recyclable = v86;\n\tthis.updateType = 0;\n\tv87 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v87);\n\tv87.value = 0;\n\tthis.isIndependentUpdate = v87;\n\tv88 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v88);\n\tv88.value = 0;\n\tthis.debugThis = v88;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 112 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60004B1")]
		[Address(RVA = "0xA187B0", Offset = "0xA187B0", Length = "0x3D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1ED1830]);\n\tv27 = *([v26 @ X8_v52]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2021D3E]) = v46;\nL_001C:\n\tv51 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv174 = UnityEngine.GameObject::GetComponent(v51);\n\tv79 = HutongGames.PlayMaker.FsmFloat::get_Value(this.to);\n\tv227 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tv175 = DG.Tweening.DOTweenModuleUI::DOFade(v174, v79, v227);\n\tthis.tween = v175;\n\tv231 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv233 = v231 == 0;\n\tif (v233) goto L_0049;\n\tv238 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_0049:\n\tv241 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv244 = DG.Tweening.TweenSettingsExtensions::SetRelative(this.tween, v241);\n\tv247 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v247);\n\tv81 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv253 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v81);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv256 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv259 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v256, this.loopType);\n\tv261 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv264 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v261);\n\tv266 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv269 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v266);\n\tv271 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv274 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v271);\n\tv275 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv277 = v275 == 0;\n\tif (v277) goto L_00BA;\n\tv292 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv283 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v292);\nL_00BA:\n\tv290 = this.startEvent == 0;\n\tif (v290) goto L_00D2;\n\tv297 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v297, this, Il2CppMethodInfo);\n\tv303 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v297);\nL_00D2:\n\tv312 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv316 = v312 == 0;\n\tv317 = ~v316;\n\tif (v317) goto L_00F4;\n\tv323 = new DG.Tweening.TweenCallback();\n\tv332 = this.finishEvent == 0;\n\tif (v332) goto L_FFFFFFFF;\n\tgoto L_00E9;\nL_00E9:\n\tDG.Tweening.TweenCallback::.ctor(v323, this, *([v344 @ X8_v33 (Il2CppMethodInfo)]));\n\tv330 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v323);\nL_00F4:\n\tv337 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv343 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv349 = v343 == 0;\n\tif (v349) goto L_0107;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Outline Fade\");\nL_0107:\n\tv212 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv214 = v212 == 0;\n\tif (v214) goto L_0121;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0121:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 229 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			Outline component = ownerDefaultTarget.GetComponent<Outline>();
			float value = to.Value;
			float value2 = duration.Value;
			TweenerCore<Color, Color, ColorOptions> tweenerCore = component.DOFade(value, value2);
			tween = tweenerCore;
			if (setSpeedBased.Value)
			{
				Tweener tweener = tween.SetSpeedBased();
			}
			bool value3 = setRelative.Value;
			Tweener tweener2 = tween.SetRelative(value3);
			GameObject ownerDefaultTarget2 = Fsm.GetOwnerDefaultTarget(gameObject);
			tween.SetTweenId(tweenIdType, stringAsId, tagAsId, ownerDefaultTarget2);
			float value4 = startDelay.Value;
			Tweener tweener3 = tween.SetDelay(value4);
			tween.SetSelectedEase(selectedEase, easeType, animationCurve);
			int value5 = loops.Value;
			Tweener tweener4 = tween.SetLoops(value5, loopType);
			bool value6 = autoKillOnCompletion.Value;
			Tweener tweener5 = tween.SetAutoKill(value6);
			bool value7 = recyclable.Value;
			Tweener tweener6 = tween.SetRecyclable(value7);
			bool value8 = isIndependentUpdate.Value;
			Tweener tweener7 = tween.SetUpdate(updateType, value8);
			if (playInReverse.Value)
			{
				bool value9 = setReverseRelative.Value;
				Tweener tweener8 = tween.From(value9);
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
				State.Debug("DOTween Outline Fade");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x60004B2")]
		[Address(RVA = "0xA18B84", Offset = "0xA18B84", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EB6868]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021D3F]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenOutlineFade()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
