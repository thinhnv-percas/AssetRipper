using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using Doozy.PlayMaker;
using Doozy.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7516C0", Offset = "0x7516C0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7516C0", Offset = "0x7516C0")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x7516C0", Offset = "0x7516C0")]
	[Token(Token = "0x2000104")]
	public class DOTweenTransformPunchScale : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x79CA64", Offset = "0x79CA64")]
		[Token(Token = "0x4000F0B")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79CAD8", Offset = "0x79CAD8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79CAD8", Offset = "0x79CAD8")]
		[Token(Token = "0x4000F0C")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 punch;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79CB38", Offset = "0x79CB38")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79CB38", Offset = "0x79CB38")]
		[Token(Token = "0x4000F0D")]
		[FieldOffset(Offset = "0x60")]
		public FsmInt vibrato;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79CB88", Offset = "0x79CB88")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79CB88", Offset = "0x79CB88")]
		[Token(Token = "0x4000F0E")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat elasticity;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79CBD8", Offset = "0x79CBD8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79CBD8", Offset = "0x79CBD8")]
		[Token(Token = "0x4000F0F")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79CC38", Offset = "0x79CC38")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79CC38", Offset = "0x79CC38")]
		[Token(Token = "0x4000F10")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79CC88", Offset = "0x79CC88")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79CC88", Offset = "0x79CC88")]
		[Token(Token = "0x4000F11")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79CCD8", Offset = "0x79CCD8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79CCD8", Offset = "0x79CCD8")]
		[Token(Token = "0x4000F12")]
		[FieldOffset(Offset = "0x88")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79CD28", Offset = "0x79CD28")]
		[Token(Token = "0x4000F13")]
		[FieldOffset(Offset = "0x90")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79CD3C", Offset = "0x79CD3C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79CD3C", Offset = "0x79CD3C")]
		[Token(Token = "0x4000F14")]
		[FieldOffset(Offset = "0x98")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79CD8C", Offset = "0x79CD8C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79CD8C", Offset = "0x79CD8C")]
		[Token(Token = "0x4000F15")]
		[FieldOffset(Offset = "0xA0")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79CDDC", Offset = "0x79CDDC")]
		[Token(Token = "0x4000F16")]
		[FieldOffset(Offset = "0xA8")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79CE14", Offset = "0x79CE14")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79CE14", Offset = "0x79CE14")]
		[Token(Token = "0x4000F17")]
		[FieldOffset(Offset = "0xB0")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79CE64", Offset = "0x79CE64")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79CE64", Offset = "0x79CE64")]
		[Token(Token = "0x4000F18")]
		[FieldOffset(Offset = "0xB8")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79CEB4", Offset = "0x79CEB4")]
		[Token(Token = "0x4000F19")]
		[FieldOffset(Offset = "0xC0")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79CEEC", Offset = "0x79CEEC")]
		[Token(Token = "0x4000F1A")]
		[FieldOffset(Offset = "0xC4")]
		public Ease easeType;

		[Token(Token = "0x4000F1B")]
		[FieldOffset(Offset = "0xC8")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79CF24", Offset = "0x79CF24")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79CF24", Offset = "0x79CF24")]
		[Token(Token = "0x4000F1C")]
		[FieldOffset(Offset = "0xD0")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79CF74", Offset = "0x79CF74")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79CF74", Offset = "0x79CF74")]
		[Token(Token = "0x4000F1D")]
		[FieldOffset(Offset = "0xD8")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79CFC4", Offset = "0x79CFC4")]
		[Token(Token = "0x4000F1E")]
		[FieldOffset(Offset = "0xE0")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79CFFC", Offset = "0x79CFFC")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79CFFC", Offset = "0x79CFFC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79CFFC", Offset = "0x79CFFC")]
		[Token(Token = "0x4000F1F")]
		[FieldOffset(Offset = "0xE8")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79D070", Offset = "0x79D070")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79D070", Offset = "0x79D070")]
		[Token(Token = "0x4000F20")]
		[FieldOffset(Offset = "0xF0")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79D0C0", Offset = "0x79D0C0")]
		[Token(Token = "0x4000F21")]
		[FieldOffset(Offset = "0xF8")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79D0F8", Offset = "0x79D0F8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79D0F8", Offset = "0x79D0F8")]
		[Token(Token = "0x4000F22")]
		[FieldOffset(Offset = "0x100")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79D148", Offset = "0x79D148")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79D148", Offset = "0x79D148")]
		[Token(Token = "0x4000F23")]
		[FieldOffset(Offset = "0x108")]
		public FsmBool debugThis;

		[Token(Token = "0x4000F24")]
		[FieldOffset(Offset = "0x110")]
		private Tweener tween;

		[Token(Token = "0x60005E7")]
		[Address(RVA = "0xA81258", Offset = "0xA81258", Length = "0x27C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1ECAB90]);\n\tv25 = *([v24 @ X8_v12]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022173]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.punch = v50;\n\tv57 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v57);\n\tv57.useVariable = 0;\n\tv57.value = 0xA;\n\tthis.vibrato = v57;\n\tv79 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v79);\n\tv79.useVariable = 0;\n\tv79.value = 1f;\n\tthis.elasticity = v79;\n\tv80 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v80);\n\tv80.useVariable = 0;\n\tthis.duration = v80;\n\tv81 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v81);\n\tv81.useVariable = 0;\n\tv81.value = 0;\n\tthis.setSpeedBased = v81;\n\tv82 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v82);\n\tv82.value = 0f;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.startDelay = v82;\n\tv83 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v83);\n\tv83.useVariable = 0;\n\tv83.value = 0;\n\tthis.finishImmediately = v83;\n\tv84 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v84);\n\tv84.useVariable = 0;\n\tthis.stringAsId = v84;\n\tv85 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v85);\n\tv85.useVariable = 0;\n\tthis.tagAsId = v85;\n\tthis.selectedEase = 0x100000000;\n\tv86 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v86);\n\tv86.value = 0;\n\tthis.loops = v86;\n\tthis.loopType = 0;\n\tv87 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v87);\n\tv87.value = 1;\n\tthis.autoKillOnCompletion = v87;\n\tv88 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v88);\n\tv88.value = 0;\n\tthis.recyclable = v88;\n\tthis.updateType = 0;\n\tv89 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v89);\n\tv89.value = 0;\n\tthis.isIndependentUpdate = v89;\n\tv90 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v90);\n\tv90.value = 0;\n\tthis.debugThis = v90;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 111 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_01aa: Expected I4, but got I8
			base.Reset();
			gameObject = null;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = false;
			punch = fsmVector;
			FsmInt fsmInt = new FsmInt();
			fsmInt.useVariable = false;
			fsmInt.Value = 10;
			vibrato = fsmInt;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = false;
			fsmFloat.Value = 1f;
			elasticity = fsmFloat;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = false;
			duration = fsmFloat2;
			FsmBool fsmBool = new FsmBool();
			fsmBool.useVariable = false;
			fsmBool.value = false;
			setSpeedBased = fsmBool;
			FsmFloat fsmFloat3 = new FsmFloat();
			fsmFloat3.Value = 0f;
			startEvent = null;
			finishEvent = null;
			startDelay = fsmFloat3;
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
			selectedEase = SelectedEase.EaseType;
			FsmInt fsmInt2 = new FsmInt();
			fsmInt2.Value = 0;
			loops = fsmInt2;
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

		[Token(Token = "0x60005E8")]
		[Address(RVA = "0xA814D4", Offset = "0xA814D4", Length = "0x3B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv32 = *([1EF3DD0]);\n\tv33 = *([v32 @ X8_v48]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2022174]) = v52;\nL_001F:\n\tv57 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv194 = UnityEngine.GameObject::GetComponent(v57);\n\tv101 = HutongGames.PlayMaker.FsmVector3::get_Value(this.punch);\n\tv102 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tv195 = HutongGames.PlayMaker.FsmInt::get_Value(this.vibrato);\n\tv264 = HutongGames.PlayMaker.FsmFloat::get_Value(this.elasticity);\n\tv196 = DG.Tweening.ShortcutExtensions::DOPunchScale(v194, v101, v102, v195, v264);\n\tthis.tween = v196;\n\tv268 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv270 = v268 == 0;\n\tif (v270) goto L_0066;\n\tv275 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_0066:\n\tv279 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v279);\n\tv104 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv285 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v104);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv288 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv291 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v288, this.loopType);\n\tv293 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv296 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v293);\n\tv298 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv301 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v298);\n\tv305 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv312 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v305);\n\tv314 = this.startEvent == 0;\n\tif (v314) goto L_00CB;\n\tv319 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v319, this, Il2CppMethodInfo);\n\tv325 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v319);\nL_00CB:\n\tv332 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv336 = v332 == 0;\n\tv337 = ~v336;\n\tif (v337) goto L_00ED;\n\tv343 = new DG.Tweening.TweenCallback();\n\tv352 = this.finishEvent == 0;\n\tif (v352) goto L_FFFFFFFF;\n\tgoto L_00E2;\nL_00E2:\n\tDG.Tweening.TweenCallback::.ctor(v343, this, *([v364 @ X8_v31 (Il2CppMethodInfo)]));\n\tv350 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v343);\nL_00ED:\n\tv357 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv363 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv369 = v363 == 0;\n\tif (v369) goto L_0100;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Transform Punch Scale\");\nL_0100:\n\tv248 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv250 = v248 == 0;\n\tif (v250) goto L_0120;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0120:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 233 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			Transform component = ownerDefaultTarget.GetComponent<Transform>();
			Vector3 value = punch.Value;
			float value2 = duration.Value;
			int value3 = vibrato.Value;
			float value4 = elasticity.Value;
			Tweener tweener = component.DOPunchScale(value, value2, value3, value4);
			tween = tweener;
			if (setSpeedBased.Value)
			{
				Tweener tweener2 = tween.SetSpeedBased();
			}
			GameObject ownerDefaultTarget2 = Fsm.GetOwnerDefaultTarget(gameObject);
			tween.SetTweenId(tweenIdType, stringAsId, tagAsId, ownerDefaultTarget2);
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
				State.Debug("DOTween Transform Punch Scale");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x60005E9")]
		[Address(RVA = "0xA8188C", Offset = "0xA8188C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1F04E68]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022175]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenTransformPunchScale()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
