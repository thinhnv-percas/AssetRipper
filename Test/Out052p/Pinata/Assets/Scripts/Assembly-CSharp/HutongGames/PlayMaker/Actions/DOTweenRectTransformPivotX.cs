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
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74FB6C", Offset = "0x74FB6C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x74FB6C", Offset = "0x74FB6C")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x74FB6C", Offset = "0x74FB6C")]
	[Token(Token = "0x20000CF")]
	public class DOTweenRectTransformPivotX : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7814C8", Offset = "0x7814C8")]
		[Token(Token = "0x4000913")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78153C", Offset = "0x78153C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78153C", Offset = "0x78153C")]
		[Token(Token = "0x4000914")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat to;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78159C", Offset = "0x78159C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78159C", Offset = "0x78159C")]
		[Token(Token = "0x4000915")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool setRelative;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7815EC", Offset = "0x7815EC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7815EC", Offset = "0x7815EC")]
		[Token(Token = "0x4000916")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78164C", Offset = "0x78164C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78164C", Offset = "0x78164C")]
		[Token(Token = "0x4000917")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78169C", Offset = "0x78169C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78169C", Offset = "0x78169C")]
		[Token(Token = "0x4000918")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7816EC", Offset = "0x7816EC")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7816EC", Offset = "0x7816EC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7816EC", Offset = "0x7816EC")]
		[Token(Token = "0x4000919")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x781760", Offset = "0x781760")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x781760", Offset = "0x781760")]
		[Token(Token = "0x400091A")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7817B0", Offset = "0x7817B0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7817B0", Offset = "0x7817B0")]
		[Token(Token = "0x400091B")]
		[FieldOffset(Offset = "0x90")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x781800", Offset = "0x781800")]
		[Token(Token = "0x400091C")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x781814", Offset = "0x781814")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x781814", Offset = "0x781814")]
		[Token(Token = "0x400091D")]
		[FieldOffset(Offset = "0xA0")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x781864", Offset = "0x781864")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x781864", Offset = "0x781864")]
		[Token(Token = "0x400091E")]
		[FieldOffset(Offset = "0xA8")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7818B4", Offset = "0x7818B4")]
		[Token(Token = "0x400091F")]
		[FieldOffset(Offset = "0xB0")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7818EC", Offset = "0x7818EC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7818EC", Offset = "0x7818EC")]
		[Token(Token = "0x4000920")]
		[FieldOffset(Offset = "0xB8")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78193C", Offset = "0x78193C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78193C", Offset = "0x78193C")]
		[Token(Token = "0x4000921")]
		[FieldOffset(Offset = "0xC0")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x78198C", Offset = "0x78198C")]
		[Token(Token = "0x4000922")]
		[FieldOffset(Offset = "0xC8")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7819C4", Offset = "0x7819C4")]
		[Token(Token = "0x4000923")]
		[FieldOffset(Offset = "0xCC")]
		public Ease easeType;

		[Token(Token = "0x4000924")]
		[FieldOffset(Offset = "0xD0")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7819FC", Offset = "0x7819FC")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7819FC", Offset = "0x7819FC")]
		[Token(Token = "0x4000925")]
		[FieldOffset(Offset = "0xD8")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x781A4C", Offset = "0x781A4C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x781A4C", Offset = "0x781A4C")]
		[Token(Token = "0x4000926")]
		[FieldOffset(Offset = "0xE0")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x781A9C", Offset = "0x781A9C")]
		[Token(Token = "0x4000927")]
		[FieldOffset(Offset = "0xE8")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x781AD4", Offset = "0x781AD4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x781AD4", Offset = "0x781AD4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x781AD4", Offset = "0x781AD4")]
		[Token(Token = "0x4000928")]
		[FieldOffset(Offset = "0xF0")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x781B48", Offset = "0x781B48")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x781B48", Offset = "0x781B48")]
		[Token(Token = "0x4000929")]
		[FieldOffset(Offset = "0xF8")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x781B98", Offset = "0x781B98")]
		[Token(Token = "0x400092A")]
		[FieldOffset(Offset = "0x100")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x781BD0", Offset = "0x781BD0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x781BD0", Offset = "0x781BD0")]
		[Token(Token = "0x400092B")]
		[FieldOffset(Offset = "0x108")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x781C20", Offset = "0x781C20")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x781C20", Offset = "0x781C20")]
		[Token(Token = "0x400092C")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool debugThis;

		[Token(Token = "0x400092D")]
		[FieldOffset(Offset = "0x118")]
		private Tweener tween;

		[Token(Token = "0x60004DD")]
		[Address(RVA = "0xA1C6C8", Offset = "0xA1C6C8", Length = "0x294")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EBD990]);\n\tv25 = *([v24 @ X8_v10]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021D58]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.to = v50;\n\tv55 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v55);\n\tv55.useVariable = 0;\n\tthis.duration = v55;\n\tv76 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v76);\n\tv76.useVariable = 0;\n\tv76.value = 0;\n\tthis.setSpeedBased = v76;\n\tv77 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v77);\n\tv77.useVariable = 0;\n\tv77.value = 0;\n\tthis.setRelative = v77;\n\tv78 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v78);\n\tv78.useVariable = 0;\n\tv78.value = 0;\n\tthis.playInReverse = v78;\n\tv79 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v79);\n\tv79.useVariable = 0;\n\tv79.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v79;\n\tv80 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v80);\n\tv80.useVariable = 0;\n\tv80.value = 0;\n\tthis.finishImmediately = v80;\n\tv81 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v81);\n\tv81.useVariable = 0;\n\tthis.stringAsId = v81;\n\tv82 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v82);\n\tv82.useVariable = 0;\n\tthis.tagAsId = v82;\n\tv83 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v83);\n\tv83.value = 0f;\n\tthis.startDelay = v83;\n\tthis.selectedEase = 0x100000000;\n\tv84 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v84);\n\tv84.value = 0;\n\tthis.loops = v84;\n\tthis.loopType = 0;\n\tv85 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v85);\n\tv85.value = 1;\n\tthis.autoKillOnCompletion = v85;\n\tv86 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v86);\n\tv86.value = 0;\n\tthis.recyclable = v86;\n\tthis.updateType = 0;\n\tv87 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v87);\n\tv87.value = 0;\n\tthis.isIndependentUpdate = v87;\n\tv88 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v88);\n\tv88.value = 0;\n\tthis.debugThis = v88;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 112 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60004DE")]
		[Address(RVA = "0xA1C95C", Offset = "0xA1C95C", Length = "0x3D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1EFFF30]);\n\tv27 = *([v26 @ X8_v52]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2021D59]) = v46;\nL_001C:\n\tv51 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv174 = UnityEngine.GameObject::GetComponent(v51);\n\tv79 = HutongGames.PlayMaker.FsmFloat::get_Value(this.to);\n\tv227 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tv175 = DG.Tweening.DOTweenModuleUI::DOPivotX(v174, v79, v227);\n\tthis.tween = v175;\n\tv231 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv233 = v231 == 0;\n\tif (v233) goto L_0049;\n\tv238 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_0049:\n\tv241 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv244 = DG.Tweening.TweenSettingsExtensions::SetRelative(this.tween, v241);\n\tv247 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v247);\n\tv81 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv253 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v81);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv256 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv259 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v256, this.loopType);\n\tv261 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv264 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v261);\n\tv266 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv269 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v266);\n\tv271 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv274 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v271);\n\tv275 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv277 = v275 == 0;\n\tif (v277) goto L_00BA;\n\tv292 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv283 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v292);\nL_00BA:\n\tv290 = this.startEvent == 0;\n\tif (v290) goto L_00D2;\n\tv297 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v297, this, Il2CppMethodInfo);\n\tv303 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v297);\nL_00D2:\n\tv312 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv316 = v312 == 0;\n\tv317 = ~v316;\n\tif (v317) goto L_00F4;\n\tv323 = new DG.Tweening.TweenCallback();\n\tv332 = this.finishEvent == 0;\n\tif (v332) goto L_FFFFFFFF;\n\tgoto L_00E9;\nL_00E9:\n\tDG.Tweening.TweenCallback::.ctor(v323, this, *([v344 @ X8_v33 (Il2CppMethodInfo)]));\n\tv330 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v323);\nL_00F4:\n\tv337 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv343 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv349 = v343 == 0;\n\tif (v349) goto L_0107;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween RectTransform PivotX\");\nL_0107:\n\tv212 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv214 = v212 == 0;\n\tif (v214) goto L_0121;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0121:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 229 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			RectTransform component = ownerDefaultTarget.GetComponent<RectTransform>();
			float value = to.Value;
			float value2 = duration.Value;
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = component.DOPivotX(value, value2);
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
				State.Debug("DOTween RectTransform PivotX");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x60004DF")]
		[Address(RVA = "0xA1CD30", Offset = "0xA1CD30", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EAC6C0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021D5A]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenRectTransformPivotX()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
