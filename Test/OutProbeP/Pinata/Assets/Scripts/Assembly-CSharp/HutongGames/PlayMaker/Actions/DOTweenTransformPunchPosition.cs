using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using Doozy.PlayMaker;
using Doozy.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7515B8", Offset = "0x7515B8")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7515B8", Offset = "0x7515B8")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x7515B8", Offset = "0x7515B8")]
	[Token(Token = "0x2000102")]
	public class DOTweenTransformPunchPosition : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x79BB5C", Offset = "0x79BB5C")]
		[Token(Token = "0x4000ED5")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79BBD0", Offset = "0x79BBD0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79BBD0", Offset = "0x79BBD0")]
		[Token(Token = "0x4000ED6")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 punch;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79BC30", Offset = "0x79BC30")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79BC30", Offset = "0x79BC30")]
		[Token(Token = "0x4000ED7")]
		[FieldOffset(Offset = "0x60")]
		public FsmInt vibrato;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79BC80", Offset = "0x79BC80")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79BC80", Offset = "0x79BC80")]
		[Token(Token = "0x4000ED8")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat elasticity;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79BCD0", Offset = "0x79BCD0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79BCD0", Offset = "0x79BCD0")]
		[Token(Token = "0x4000ED9")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool snapping;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79BD20", Offset = "0x79BD20")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79BD20", Offset = "0x79BD20")]
		[Token(Token = "0x4000EDA")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79BD80", Offset = "0x79BD80")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79BD80", Offset = "0x79BD80")]
		[Token(Token = "0x4000EDB")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79BDD0", Offset = "0x79BDD0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79BDD0", Offset = "0x79BDD0")]
		[Token(Token = "0x4000EDC")]
		[FieldOffset(Offset = "0x88")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79BE20", Offset = "0x79BE20")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79BE20", Offset = "0x79BE20")]
		[Token(Token = "0x4000EDD")]
		[FieldOffset(Offset = "0x90")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79BE70", Offset = "0x79BE70")]
		[Token(Token = "0x4000EDE")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79BE84", Offset = "0x79BE84")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79BE84", Offset = "0x79BE84")]
		[Token(Token = "0x4000EDF")]
		[FieldOffset(Offset = "0xA0")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79BED4", Offset = "0x79BED4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79BED4", Offset = "0x79BED4")]
		[Token(Token = "0x4000EE0")]
		[FieldOffset(Offset = "0xA8")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79BF24", Offset = "0x79BF24")]
		[Token(Token = "0x4000EE1")]
		[FieldOffset(Offset = "0xB0")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79BF5C", Offset = "0x79BF5C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79BF5C", Offset = "0x79BF5C")]
		[Token(Token = "0x4000EE2")]
		[FieldOffset(Offset = "0xB8")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79BFAC", Offset = "0x79BFAC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79BFAC", Offset = "0x79BFAC")]
		[Token(Token = "0x4000EE3")]
		[FieldOffset(Offset = "0xC0")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79BFFC", Offset = "0x79BFFC")]
		[Token(Token = "0x4000EE4")]
		[FieldOffset(Offset = "0xC8")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79C034", Offset = "0x79C034")]
		[Token(Token = "0x4000EE5")]
		[FieldOffset(Offset = "0xCC")]
		public Ease easeType;

		[Token(Token = "0x4000EE6")]
		[FieldOffset(Offset = "0xD0")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79C06C", Offset = "0x79C06C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79C06C", Offset = "0x79C06C")]
		[Token(Token = "0x4000EE7")]
		[FieldOffset(Offset = "0xD8")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79C0BC", Offset = "0x79C0BC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79C0BC", Offset = "0x79C0BC")]
		[Token(Token = "0x4000EE8")]
		[FieldOffset(Offset = "0xE0")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79C10C", Offset = "0x79C10C")]
		[Token(Token = "0x4000EE9")]
		[FieldOffset(Offset = "0xE8")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79C144", Offset = "0x79C144")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79C144", Offset = "0x79C144")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79C144", Offset = "0x79C144")]
		[Token(Token = "0x4000EEA")]
		[FieldOffset(Offset = "0xF0")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79C1B8", Offset = "0x79C1B8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79C1B8", Offset = "0x79C1B8")]
		[Token(Token = "0x4000EEB")]
		[FieldOffset(Offset = "0xF8")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79C208", Offset = "0x79C208")]
		[Token(Token = "0x4000EEC")]
		[FieldOffset(Offset = "0x100")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79C240", Offset = "0x79C240")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79C240", Offset = "0x79C240")]
		[Token(Token = "0x4000EED")]
		[FieldOffset(Offset = "0x108")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79C290", Offset = "0x79C290")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79C290", Offset = "0x79C290")]
		[Token(Token = "0x4000EEE")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool debugThis;

		[Token(Token = "0x4000EEF")]
		[FieldOffset(Offset = "0x118")]
		private Tweener tween;

		[Token(Token = "0x60005DD")]
		[Address(RVA = "0xA80424", Offset = "0xA80424", Length = "0x2A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EFCC38]);\n\tv25 = *([v24 @ X8_v12]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202216D]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.punch = v50;\n\tv57 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v57);\n\tv57.useVariable = 0;\n\tv57.value = 0xA;\n\tthis.vibrato = v57;\n\tv80 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v80);\n\tv80.useVariable = 0;\n\tv80.value = 1f;\n\tthis.elasticity = v80;\n\tv81 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v81);\n\tv81.useVariable = 0;\n\tv81.value = 0;\n\tthis.snapping = v81;\n\tv82 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v82);\n\tv82.useVariable = 0;\n\tthis.duration = v82;\n\tv83 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v83);\n\tv83.useVariable = 0;\n\tv83.value = 0;\n\tthis.setSpeedBased = v83;\n\tv84 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v84);\n\tv84.value = 0f;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.startDelay = v84;\n\tv85 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v85);\n\tv85.useVariable = 0;\n\tv85.value = 0;\n\tthis.finishImmediately = v85;\n\tv86 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v86);\n\tv86.useVariable = 0;\n\tthis.stringAsId = v86;\n\tv87 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v87);\n\tv87.useVariable = 0;\n\tthis.tagAsId = v87;\n\tthis.selectedEase = 0x100000000;\n\tv88 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v88);\n\tv88.value = 0;\n\tthis.loops = v88;\n\tthis.loopType = 0;\n\tv89 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v89);\n\tv89.value = 1;\n\tthis.autoKillOnCompletion = v89;\n\tv90 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v90);\n\tv90.value = 0;\n\tthis.recyclable = v90;\n\tthis.updateType = 0;\n\tv91 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v91);\n\tv91.value = 0;\n\tthis.isIndependentUpdate = v91;\n\tv92 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v92);\n\tv92.value = 0;\n\tthis.debugThis = v92;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 116 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60005DE")]
		[Address(RVA = "0xA806C4", Offset = "0xA806C4", Length = "0x3DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv34 = *([1F053E0]);\n\tv35 = *([v34 @ X8_v48]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([202216E]) = v54;\nL_0020:\n\tv59 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv205 = UnityEngine.GameObject::GetComponent(v59);\n\tv106 = HutongGames.PlayMaker.FsmVector3::get_Value(this.punch);\n\tv107 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tv206 = HutongGames.PlayMaker.FsmInt::get_Value(this.vibrato);\n\tv108 = HutongGames.PlayMaker.FsmFloat::get_Value(this.elasticity);\n\tv277 = HutongGames.PlayMaker.FsmBool::get_Value(this.snapping);\n\tv207 = DG.Tweening.ShortcutExtensions::DOPunchPosition(v205, v106, v107, v206, v108, v277);\n\tthis.tween = v207;\n\tv281 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv283 = v281 == 0;\n\tif (v283) goto L_006E;\n\tv288 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_006E:\n\tv292 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v292);\n\tv110 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv298 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v110);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv301 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv304 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v301, this.loopType);\n\tv306 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv309 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v306);\n\tv311 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv314 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v311);\n\tv318 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv325 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v318);\n\tv327 = this.startEvent == 0;\n\tif (v327) goto L_00D3;\n\tv332 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v332, this, Il2CppMethodInfo);\n\tv338 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v332);\nL_00D3:\n\tv345 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv349 = v345 == 0;\n\tv350 = ~v349;\n\tif (v350) goto L_00F5;\n\tv356 = new DG.Tweening.TweenCallback();\n\tv365 = this.finishEvent == 0;\n\tif (v365) goto L_FFFFFFFF;\n\tgoto L_00EA;\nL_00EA:\n\tDG.Tweening.TweenCallback::.ctor(v356, this, *([v377 @ X8_v31 (Il2CppMethodInfo)]));\n\tv363 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v356);\nL_00F5:\n\tv370 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv376 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv382 = v376 == 0;\n\tif (v382) goto L_0108;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Transform Punch Position\");\nL_0108:\n\tv261 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv263 = v261 == 0;\n\tif (v263) goto L_012A;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_012A:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 242 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			Transform component = ownerDefaultTarget.GetComponent<Transform>();
			Vector3 value = punch.Value;
			float value2 = duration.Value;
			int value3 = vibrato.Value;
			float value4 = elasticity.Value;
			bool value5 = snapping.Value;
			Tweener tweener = component.DOPunchPosition(value, value2, value3, value4, value5);
			tween = tweener;
			if (setSpeedBased.Value)
			{
				Tweener tweener2 = tween.SetSpeedBased();
			}
			GameObject ownerDefaultTarget2 = Fsm.GetOwnerDefaultTarget(gameObject);
			tween.SetTweenId(tweenIdType, stringAsId, tagAsId, ownerDefaultTarget2);
			float value6 = startDelay.Value;
			Tweener tweener3 = tween.SetDelay(value6);
			tween.SetSelectedEase(selectedEase, easeType, animationCurve);
			int value7 = loops.Value;
			Tweener tweener4 = tween.SetLoops(value7, loopType);
			bool value8 = autoKillOnCompletion.Value;
			Tweener tweener5 = tween.SetAutoKill(value8);
			bool value9 = recyclable.Value;
			Tweener tweener6 = tween.SetRecyclable(value9);
			bool value10 = isIndependentUpdate.Value;
			Tweener tweener7 = tween.SetUpdate(updateType, value10);
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
				State.Debug("DOTween Transform Punch Position");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x60005DF")]
		[Address(RVA = "0xA80AA0", Offset = "0xA80AA0", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EF2DA0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202216F]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenTransformPunchPosition()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
