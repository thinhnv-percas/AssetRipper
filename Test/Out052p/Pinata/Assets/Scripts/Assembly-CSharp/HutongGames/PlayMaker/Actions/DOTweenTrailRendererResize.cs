using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using Doozy.PlayMaker;
using Doozy.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x750A60", Offset = "0x750A60")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x750A60", Offset = "0x750A60")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x750A60", Offset = "0x750A60")]
	[Token(Token = "0x20000EC")]
	public class DOTweenTrailRendererResize : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x79007C", Offset = "0x79007C")]
		[Token(Token = "0x4000C4B")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7900F0", Offset = "0x7900F0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7900F0", Offset = "0x7900F0")]
		[Token(Token = "0x4000C4C")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat toStartWidth;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x790150", Offset = "0x790150")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x790150", Offset = "0x790150")]
		[Token(Token = "0x4000C4D")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat toEndWidth;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7901B0", Offset = "0x7901B0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7901B0", Offset = "0x7901B0")]
		[Token(Token = "0x4000C4E")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x790210", Offset = "0x790210")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x790210", Offset = "0x790210")]
		[Token(Token = "0x4000C4F")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x790260", Offset = "0x790260")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x790260", Offset = "0x790260")]
		[Token(Token = "0x4000C50")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7902B0", Offset = "0x7902B0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7902B0", Offset = "0x7902B0")]
		[Token(Token = "0x4000C51")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x790300", Offset = "0x790300")]
		[Token(Token = "0x4000C52")]
		[FieldOffset(Offset = "0x88")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x790314", Offset = "0x790314")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x790314", Offset = "0x790314")]
		[Token(Token = "0x4000C53")]
		[FieldOffset(Offset = "0x90")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x790364", Offset = "0x790364")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x790364", Offset = "0x790364")]
		[Token(Token = "0x4000C54")]
		[FieldOffset(Offset = "0x98")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7903B4", Offset = "0x7903B4")]
		[Token(Token = "0x4000C55")]
		[FieldOffset(Offset = "0xA0")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7903EC", Offset = "0x7903EC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7903EC", Offset = "0x7903EC")]
		[Token(Token = "0x4000C56")]
		[FieldOffset(Offset = "0xA8")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79043C", Offset = "0x79043C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79043C", Offset = "0x79043C")]
		[Token(Token = "0x4000C57")]
		[FieldOffset(Offset = "0xB0")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79048C", Offset = "0x79048C")]
		[Token(Token = "0x4000C58")]
		[FieldOffset(Offset = "0xB8")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7904C4", Offset = "0x7904C4")]
		[Token(Token = "0x4000C59")]
		[FieldOffset(Offset = "0xBC")]
		public Ease easeType;

		[Token(Token = "0x4000C5A")]
		[FieldOffset(Offset = "0xC0")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7904FC", Offset = "0x7904FC")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7904FC", Offset = "0x7904FC")]
		[Token(Token = "0x4000C5B")]
		[FieldOffset(Offset = "0xC8")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79054C", Offset = "0x79054C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79054C", Offset = "0x79054C")]
		[Token(Token = "0x4000C5C")]
		[FieldOffset(Offset = "0xD0")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79059C", Offset = "0x79059C")]
		[Token(Token = "0x4000C5D")]
		[FieldOffset(Offset = "0xD8")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7905D4", Offset = "0x7905D4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7905D4", Offset = "0x7905D4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7905D4", Offset = "0x7905D4")]
		[Token(Token = "0x4000C5E")]
		[FieldOffset(Offset = "0xE0")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x790648", Offset = "0x790648")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x790648", Offset = "0x790648")]
		[Token(Token = "0x4000C5F")]
		[FieldOffset(Offset = "0xE8")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x790698", Offset = "0x790698")]
		[Token(Token = "0x4000C60")]
		[FieldOffset(Offset = "0xF0")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7906D0", Offset = "0x7906D0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7906D0", Offset = "0x7906D0")]
		[Token(Token = "0x4000C61")]
		[FieldOffset(Offset = "0xF8")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x790720", Offset = "0x790720")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x790720", Offset = "0x790720")]
		[Token(Token = "0x4000C62")]
		[FieldOffset(Offset = "0x100")]
		public FsmBool debugThis;

		[Token(Token = "0x4000C63")]
		[FieldOffset(Offset = "0x108")]
		private Tweener tween;

		[Token(Token = "0x600056E")]
		[Address(RVA = "0xA75084", Offset = "0xA75084", Length = "0x248")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EBC7A8]);\n\tv25 = *([v24 @ X8_v10]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202212B]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.toStartWidth = v50;\n\tv55 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v55);\n\tv55.useVariable = 0;\n\tthis.toEndWidth = v55;\n\tv74 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v74);\n\tv74.useVariable = 0;\n\tthis.duration = v74;\n\tv75 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v75);\n\tv75.useVariable = 0;\n\tv75.value = 0;\n\tthis.setSpeedBased = v75;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tv76 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v76);\n\tv76.useVariable = 0;\n\tv76.value = 0;\n\tthis.finishImmediately = v76;\n\tv77 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v77);\n\tv77.useVariable = 0;\n\tthis.stringAsId = v77;\n\tv78 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v78);\n\tv78.useVariable = 0;\n\tthis.tagAsId = v78;\n\tv79 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v79);\n\tv79.value = 0f;\n\tthis.startDelay = v79;\n\tthis.selectedEase = 0x100000000;\n\tv80 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v80);\n\tv80.value = 0;\n\tthis.loops = v80;\n\tthis.loopType = 0;\n\tv81 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v81);\n\tv81.value = 1;\n\tthis.autoKillOnCompletion = v81;\n\tv82 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v82);\n\tv82.value = 0;\n\tthis.recyclable = v82;\n\tthis.updateType = 0;\n\tv83 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v83);\n\tv83.value = 0;\n\tthis.isIndependentUpdate = v83;\n\tv84 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v84);\n\tv84.value = 0;\n\tthis.debugThis = v84;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 102 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_0167: Expected I4, but got I8
			base.Reset();
			gameObject = null;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = false;
			toStartWidth = fsmFloat;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = false;
			toEndWidth = fsmFloat2;
			FsmFloat fsmFloat3 = new FsmFloat();
			fsmFloat3.useVariable = false;
			duration = fsmFloat3;
			FsmBool fsmBool = new FsmBool();
			fsmBool.useVariable = false;
			fsmBool.value = false;
			setSpeedBased = fsmBool;
			startEvent = null;
			finishEvent = null;
			FsmBool fsmBool2 = new FsmBool();
			fsmBool2.useVariable = false;
			fsmBool2.value = false;
			finishImmediately = fsmBool2;
			FsmString fsmString = new FsmString();
			fsmString.useVariable = false;
			stringAsId = fsmString;
			FsmString fsmString2 = new FsmString();
			fsmString2.useVariable = false;
			tagAsId = fsmString2;
			FsmFloat fsmFloat4 = new FsmFloat();
			fsmFloat4.Value = 0f;
			startDelay = fsmFloat4;
			selectedEase = SelectedEase.EaseType;
			FsmInt fsmInt = new FsmInt();
			fsmInt.Value = 0;
			loops = fsmInt;
			loopType = default(LoopType);
			FsmBool fsmBool3 = new FsmBool();
			fsmBool3.value = true;
			autoKillOnCompletion = fsmBool3;
			FsmBool fsmBool4 = new FsmBool();
			fsmBool4.value = false;
			recyclable = fsmBool4;
			updateType = default(UpdateType);
			FsmBool fsmBool5 = new FsmBool();
			fsmBool5.value = false;
			isIndependentUpdate = fsmBool5;
			FsmBool fsmBool6 = new FsmBool();
			fsmBool6.value = false;
			debugThis = fsmBool6;
		}

		[Token(Token = "0x600056F")]
		[Address(RVA = "0xA752CC", Offset = "0xA752CC", Length = "0x380")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv28 = *([1EA9828]);\n\tv29 = *([v28 @ X8_v47]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([202212C]) = v48;\nL_001D:\n\tv53 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv169 = UnityEngine.GameObject::GetComponent(v53);\n\tv83 = HutongGames.PlayMaker.FsmFloat::get_Value(this.toStartWidth);\n\tv84 = HutongGames.PlayMaker.FsmFloat::get_Value(this.toEndWidth);\n\tv226 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tv170 = DG.Tweening.ShortcutExtensions::DOResize(v169, v83, v84, v226);\n\tthis.tween = v170;\n\tv230 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv232 = v230 == 0;\n\tif (v232) goto L_0055;\n\tv237 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_0055:\n\tv241 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v241);\n\tv86 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv247 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v86);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv250 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv253 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v250, this.loopType);\n\tv255 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv258 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v255);\n\tv260 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv263 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v260);\n\tv267 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv274 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v267);\n\tv276 = this.startEvent == 0;\n\tif (v276) goto L_00BA;\n\tv281 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v281, this, Il2CppMethodInfo);\n\tv287 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v281);\nL_00BA:\n\tv294 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv298 = v294 == 0;\n\tv299 = ~v298;\n\tif (v299) goto L_00DC;\n\tv305 = new DG.Tweening.TweenCallback();\n\tv314 = this.finishEvent == 0;\n\tif (v314) goto L_FFFFFFFF;\n\tgoto L_00D1;\nL_00D1:\n\tDG.Tweening.TweenCallback::.ctor(v305, this, *([v326 @ X8_v30 (Il2CppMethodInfo)]));\n\tv312 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v305);\nL_00DC:\n\tv319 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv325 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv331 = v325 == 0;\n\tif (v331) goto L_00EF;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Trail Renderer Resize\");\nL_00EF:\n\tv211 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv213 = v211 == 0;\n\tif (v213) goto L_010B;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_010B:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 213 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			TrailRenderer component = ownerDefaultTarget.GetComponent<TrailRenderer>();
			float value = toStartWidth.Value;
			float value2 = toEndWidth.Value;
			float value3 = duration.Value;
			Tweener tweener = component.DOResize(value, value2, value3);
			tween = tweener;
			if (setSpeedBased.Value)
			{
				Tweener tweener2 = tween.SetSpeedBased();
			}
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
				State.Debug("DOTween Trail Renderer Resize");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000570")]
		[Address(RVA = "0xA7564C", Offset = "0xA7564C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EEBEE0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202212D]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenTrailRendererResize()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
