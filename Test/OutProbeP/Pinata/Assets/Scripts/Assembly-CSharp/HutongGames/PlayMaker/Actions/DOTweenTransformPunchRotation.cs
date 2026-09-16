using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using Doozy.PlayMaker;
using Doozy.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75163C", Offset = "0x75163C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75163C", Offset = "0x75163C")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x75163C", Offset = "0x75163C")]
	[Token(Token = "0x2000103")]
	public class DOTweenTransformPunchRotation : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x79C2E0", Offset = "0x79C2E0")]
		[Token(Token = "0x4000EF0")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79C354", Offset = "0x79C354")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79C354", Offset = "0x79C354")]
		[Token(Token = "0x4000EF1")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 punch;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79C3B4", Offset = "0x79C3B4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79C3B4", Offset = "0x79C3B4")]
		[Token(Token = "0x4000EF2")]
		[FieldOffset(Offset = "0x60")]
		public FsmInt vibrato;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79C404", Offset = "0x79C404")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79C404", Offset = "0x79C404")]
		[Token(Token = "0x4000EF3")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat elasticity;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79C454", Offset = "0x79C454")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79C454", Offset = "0x79C454")]
		[Token(Token = "0x4000EF4")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool snapping;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79C4A4", Offset = "0x79C4A4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79C4A4", Offset = "0x79C4A4")]
		[Token(Token = "0x4000EF5")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79C504", Offset = "0x79C504")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79C504", Offset = "0x79C504")]
		[Token(Token = "0x4000EF6")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79C554", Offset = "0x79C554")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79C554", Offset = "0x79C554")]
		[Token(Token = "0x4000EF7")]
		[FieldOffset(Offset = "0x88")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79C5A4", Offset = "0x79C5A4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79C5A4", Offset = "0x79C5A4")]
		[Token(Token = "0x4000EF8")]
		[FieldOffset(Offset = "0x90")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79C5F4", Offset = "0x79C5F4")]
		[Token(Token = "0x4000EF9")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79C608", Offset = "0x79C608")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79C608", Offset = "0x79C608")]
		[Token(Token = "0x4000EFA")]
		[FieldOffset(Offset = "0xA0")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79C658", Offset = "0x79C658")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79C658", Offset = "0x79C658")]
		[Token(Token = "0x4000EFB")]
		[FieldOffset(Offset = "0xA8")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79C6A8", Offset = "0x79C6A8")]
		[Token(Token = "0x4000EFC")]
		[FieldOffset(Offset = "0xB0")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79C6E0", Offset = "0x79C6E0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79C6E0", Offset = "0x79C6E0")]
		[Token(Token = "0x4000EFD")]
		[FieldOffset(Offset = "0xB8")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79C730", Offset = "0x79C730")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79C730", Offset = "0x79C730")]
		[Token(Token = "0x4000EFE")]
		[FieldOffset(Offset = "0xC0")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79C780", Offset = "0x79C780")]
		[Token(Token = "0x4000EFF")]
		[FieldOffset(Offset = "0xC8")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79C7B8", Offset = "0x79C7B8")]
		[Token(Token = "0x4000F00")]
		[FieldOffset(Offset = "0xCC")]
		public Ease easeType;

		[Token(Token = "0x4000F01")]
		[FieldOffset(Offset = "0xD0")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79C7F0", Offset = "0x79C7F0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79C7F0", Offset = "0x79C7F0")]
		[Token(Token = "0x4000F02")]
		[FieldOffset(Offset = "0xD8")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79C840", Offset = "0x79C840")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79C840", Offset = "0x79C840")]
		[Token(Token = "0x4000F03")]
		[FieldOffset(Offset = "0xE0")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79C890", Offset = "0x79C890")]
		[Token(Token = "0x4000F04")]
		[FieldOffset(Offset = "0xE8")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79C8C8", Offset = "0x79C8C8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79C8C8", Offset = "0x79C8C8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79C8C8", Offset = "0x79C8C8")]
		[Token(Token = "0x4000F05")]
		[FieldOffset(Offset = "0xF0")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79C93C", Offset = "0x79C93C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79C93C", Offset = "0x79C93C")]
		[Token(Token = "0x4000F06")]
		[FieldOffset(Offset = "0xF8")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79C98C", Offset = "0x79C98C")]
		[Token(Token = "0x4000F07")]
		[FieldOffset(Offset = "0x100")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79C9C4", Offset = "0x79C9C4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79C9C4", Offset = "0x79C9C4")]
		[Token(Token = "0x4000F08")]
		[FieldOffset(Offset = "0x108")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79CA14", Offset = "0x79CA14")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79CA14", Offset = "0x79CA14")]
		[Token(Token = "0x4000F09")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool debugThis;

		[Token(Token = "0x4000F0A")]
		[FieldOffset(Offset = "0x118")]
		private Tweener tween;

		[Token(Token = "0x60005E2")]
		[Address(RVA = "0xA80B50", Offset = "0xA80B50", Length = "0x2A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1ED2420]);\n\tv25 = *([v24 @ X8_v12]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022170]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.punch = v50;\n\tv57 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v57);\n\tv57.useVariable = 0;\n\tv57.value = 0xA;\n\tthis.vibrato = v57;\n\tv80 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v80);\n\tv80.useVariable = 0;\n\tv80.value = 1f;\n\tthis.elasticity = v80;\n\tv81 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v81);\n\tv81.useVariable = 0;\n\tv81.value = 0;\n\tthis.snapping = v81;\n\tv82 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v82);\n\tv82.useVariable = 0;\n\tthis.duration = v82;\n\tv83 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v83);\n\tv83.useVariable = 0;\n\tv83.value = 0;\n\tthis.setSpeedBased = v83;\n\tv84 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v84);\n\tv84.value = 0f;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.startDelay = v84;\n\tv85 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v85);\n\tv85.useVariable = 0;\n\tv85.value = 0;\n\tthis.finishImmediately = v85;\n\tv86 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v86);\n\tv86.useVariable = 0;\n\tthis.stringAsId = v86;\n\tv87 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v87);\n\tv87.useVariable = 0;\n\tthis.tagAsId = v87;\n\tthis.selectedEase = 0x100000000;\n\tv88 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v88);\n\tv88.value = 0;\n\tthis.loops = v88;\n\tthis.loopType = 0;\n\tv89 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v89);\n\tv89.value = 1;\n\tthis.autoKillOnCompletion = v89;\n\tv90 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v90);\n\tv90.value = 0;\n\tthis.recyclable = v90;\n\tthis.updateType = 0;\n\tv91 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v91);\n\tv91.value = 0;\n\tthis.isIndependentUpdate = v91;\n\tv92 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v92);\n\tv92.value = 0;\n\tthis.debugThis = v92;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 116 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_01df: Expected I4, but got I8
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
			FsmBool fsmBool = new FsmBool();
			fsmBool.useVariable = false;
			fsmBool.value = false;
			snapping = fsmBool;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = false;
			duration = fsmFloat2;
			FsmBool fsmBool2 = new FsmBool();
			fsmBool2.useVariable = false;
			fsmBool2.value = false;
			setSpeedBased = fsmBool2;
			FsmFloat fsmFloat3 = new FsmFloat();
			fsmFloat3.Value = 0f;
			startEvent = null;
			finishEvent = null;
			startDelay = fsmFloat3;
			FsmBool fsmBool3 = new FsmBool();
			fsmBool3.useVariable = false;
			fsmBool3.value = false;
			finishImmediately = fsmBool3;
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
			FsmBool fsmBool4 = new FsmBool();
			fsmBool4.value = true;
			autoKillOnCompletion = fsmBool4;
			FsmBool fsmBool5 = new FsmBool();
			fsmBool5.value = false;
			recyclable = fsmBool5;
			updateType = default(UpdateType);
			FsmBool fsmBool6 = new FsmBool();
			fsmBool6.value = false;
			isIndependentUpdate = fsmBool6;
			FsmBool fsmBool7 = new FsmBool();
			fsmBool7.value = false;
			debugThis = fsmBool7;
		}

		[Token(Token = "0x60005E3")]
		[Address(RVA = "0xA80DF0", Offset = "0xA80DF0", Length = "0x3B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv32 = *([1F05210]);\n\tv33 = *([v32 @ X8_v48]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2022171]) = v52;\nL_001F:\n\tv57 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv194 = UnityEngine.GameObject::GetComponent(v57);\n\tv101 = HutongGames.PlayMaker.FsmVector3::get_Value(this.punch);\n\tv102 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tv195 = HutongGames.PlayMaker.FsmInt::get_Value(this.vibrato);\n\tv264 = HutongGames.PlayMaker.FsmFloat::get_Value(this.elasticity);\n\tv196 = DG.Tweening.ShortcutExtensions::DOPunchRotation(v194, v101, v102, v195, v264);\n\tthis.tween = v196;\n\tv268 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv270 = v268 == 0;\n\tif (v270) goto L_0066;\n\tv275 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_0066:\n\tv279 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v279);\n\tv104 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv285 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v104);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv288 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv291 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v288, this.loopType);\n\tv293 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv296 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v293);\n\tv298 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv301 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v298);\n\tv305 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv312 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v305);\n\tv314 = this.startEvent == 0;\n\tif (v314) goto L_00CB;\n\tv319 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v319, this, Il2CppMethodInfo);\n\tv325 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v319);\nL_00CB:\n\tv332 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv336 = v332 == 0;\n\tv337 = ~v336;\n\tif (v337) goto L_00ED;\n\tv343 = new DG.Tweening.TweenCallback();\n\tv352 = this.finishEvent == 0;\n\tif (v352) goto L_FFFFFFFF;\n\tgoto L_00E2;\nL_00E2:\n\tDG.Tweening.TweenCallback::.ctor(v343, this, *([v364 @ X8_v31 (Il2CppMethodInfo)]));\n\tv350 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v343);\nL_00ED:\n\tv357 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv363 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv369 = v363 == 0;\n\tif (v369) goto L_0100;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Transform Punch Rotation\");\nL_0100:\n\tv248 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv250 = v248 == 0;\n\tif (v250) goto L_0120;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0120:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 233 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			Transform component = ownerDefaultTarget.GetComponent<Transform>();
			Vector3 value = punch.Value;
			float value2 = duration.Value;
			int value3 = vibrato.Value;
			float value4 = elasticity.Value;
			Tweener tweener = component.DOPunchRotation(value, value2, value3, value4);
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
				State.Debug("DOTween Transform Punch Rotation");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x60005E4")]
		[Address(RVA = "0xA811A8", Offset = "0xA811A8", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EE2A70]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022172]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenTransformPunchRotation()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
