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
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74F95C", Offset = "0x74F95C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x74F95C", Offset = "0x74F95C")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x74F95C", Offset = "0x74F95C")]
	[Token(Token = "0x20000CB")]
	public class DOTweenRectTransformAnchorPosX : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x77F58C", Offset = "0x77F58C")]
		[Token(Token = "0x40008A5")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77F600", Offset = "0x77F600")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77F600", Offset = "0x77F600")]
		[Token(Token = "0x40008A6")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat to;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77F660", Offset = "0x77F660")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77F660", Offset = "0x77F660")]
		[Token(Token = "0x40008A7")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool setRelative;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77F6B0", Offset = "0x77F6B0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77F6B0", Offset = "0x77F6B0")]
		[Token(Token = "0x40008A8")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool snapping;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77F700", Offset = "0x77F700")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77F700", Offset = "0x77F700")]
		[Token(Token = "0x40008A9")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77F760", Offset = "0x77F760")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77F760", Offset = "0x77F760")]
		[Token(Token = "0x40008AA")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77F7B0", Offset = "0x77F7B0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77F7B0", Offset = "0x77F7B0")]
		[Token(Token = "0x40008AB")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77F800", Offset = "0x77F800")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77F800", Offset = "0x77F800")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77F800", Offset = "0x77F800")]
		[Token(Token = "0x40008AC")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77F874", Offset = "0x77F874")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77F874", Offset = "0x77F874")]
		[Token(Token = "0x40008AD")]
		[FieldOffset(Offset = "0x90")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77F8C4", Offset = "0x77F8C4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77F8C4", Offset = "0x77F8C4")]
		[Token(Token = "0x40008AE")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77F914", Offset = "0x77F914")]
		[Token(Token = "0x40008AF")]
		[FieldOffset(Offset = "0xA0")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77F928", Offset = "0x77F928")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77F928", Offset = "0x77F928")]
		[Token(Token = "0x40008B0")]
		[FieldOffset(Offset = "0xA8")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77F978", Offset = "0x77F978")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77F978", Offset = "0x77F978")]
		[Token(Token = "0x40008B1")]
		[FieldOffset(Offset = "0xB0")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77F9C8", Offset = "0x77F9C8")]
		[Token(Token = "0x40008B2")]
		[FieldOffset(Offset = "0xB8")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77FA00", Offset = "0x77FA00")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77FA00", Offset = "0x77FA00")]
		[Token(Token = "0x40008B3")]
		[FieldOffset(Offset = "0xC0")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77FA50", Offset = "0x77FA50")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77FA50", Offset = "0x77FA50")]
		[Token(Token = "0x40008B4")]
		[FieldOffset(Offset = "0xC8")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77FAA0", Offset = "0x77FAA0")]
		[Token(Token = "0x40008B5")]
		[FieldOffset(Offset = "0xD0")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77FAD8", Offset = "0x77FAD8")]
		[Token(Token = "0x40008B6")]
		[FieldOffset(Offset = "0xD4")]
		public Ease easeType;

		[Token(Token = "0x40008B7")]
		[FieldOffset(Offset = "0xD8")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77FB10", Offset = "0x77FB10")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77FB10", Offset = "0x77FB10")]
		[Token(Token = "0x40008B8")]
		[FieldOffset(Offset = "0xE0")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77FB60", Offset = "0x77FB60")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77FB60", Offset = "0x77FB60")]
		[Token(Token = "0x40008B9")]
		[FieldOffset(Offset = "0xE8")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77FBB0", Offset = "0x77FBB0")]
		[Token(Token = "0x40008BA")]
		[FieldOffset(Offset = "0xF0")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77FBE8", Offset = "0x77FBE8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77FBE8", Offset = "0x77FBE8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77FBE8", Offset = "0x77FBE8")]
		[Token(Token = "0x40008BB")]
		[FieldOffset(Offset = "0xF8")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77FC5C", Offset = "0x77FC5C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77FC5C", Offset = "0x77FC5C")]
		[Token(Token = "0x40008BC")]
		[FieldOffset(Offset = "0x100")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77FCAC", Offset = "0x77FCAC")]
		[Token(Token = "0x40008BD")]
		[FieldOffset(Offset = "0x108")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77FCE4", Offset = "0x77FCE4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77FCE4", Offset = "0x77FCE4")]
		[Token(Token = "0x40008BE")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77FD34", Offset = "0x77FD34")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77FD34", Offset = "0x77FD34")]
		[Token(Token = "0x40008BF")]
		[FieldOffset(Offset = "0x118")]
		public FsmBool debugThis;

		[Token(Token = "0x40008C0")]
		[FieldOffset(Offset = "0x120")]
		private Tweener tween;

		[Token(Token = "0x60004C9")]
		[Address(RVA = "0xA1A9CC", Offset = "0xA1A9CC", Length = "0x2B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EB9700]);\n\tv25 = *([v24 @ X8_v10]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021D4C]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.to = v50;\n\tv55 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v55);\n\tv55.useVariable = 0;\n\tthis.duration = v55;\n\tv77 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v77);\n\tv77.useVariable = 0;\n\tv77.value = 0;\n\tthis.setSpeedBased = v77;\n\tv78 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v78);\n\tv78.useVariable = 0;\n\tv78.value = 0;\n\tthis.snapping = v78;\n\tv79 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v79);\n\tv79.useVariable = 0;\n\tv79.value = 0;\n\tthis.setRelative = v79;\n\tv80 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v80);\n\tv80.useVariable = 0;\n\tv80.value = 0;\n\tthis.playInReverse = v80;\n\tv81 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v81);\n\tv81.useVariable = 0;\n\tv81.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v81;\n\tv82 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v82);\n\tv82.useVariable = 0;\n\tv82.value = 0;\n\tthis.finishImmediately = v82;\n\tv83 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v83);\n\tv83.useVariable = 0;\n\tthis.stringAsId = v83;\n\tv84 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v84);\n\tv84.useVariable = 0;\n\tthis.tagAsId = v84;\n\tv85 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v85);\n\tv85.value = 0f;\n\tthis.startDelay = v85;\n\tthis.selectedEase = 0x100000000;\n\tv86 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v86);\n\tv86.value = 0;\n\tthis.loops = v86;\n\tthis.loopType = 0;\n\tv87 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v87);\n\tv87.value = 1;\n\tthis.autoKillOnCompletion = v87;\n\tv88 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v88);\n\tv88.value = 0;\n\tthis.recyclable = v88;\n\tthis.updateType = 0;\n\tv89 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v89);\n\tv89.value = 0;\n\tthis.isIndependentUpdate = v89;\n\tv90 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v90);\n\tv90.value = 0;\n\tthis.debugThis = v90;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 117 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_0214: Expected I4, but got I8
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
			snapping = fsmBool2;
			FsmBool fsmBool3 = new FsmBool();
			fsmBool3.useVariable = false;
			fsmBool3.value = false;
			setRelative = fsmBool3;
			FsmBool fsmBool4 = new FsmBool();
			fsmBool4.useVariable = false;
			fsmBool4.value = false;
			playInReverse = fsmBool4;
			FsmBool fsmBool5 = new FsmBool();
			fsmBool5.useVariable = false;
			fsmBool5.value = false;
			startEvent = null;
			finishEvent = null;
			setReverseRelative = fsmBool5;
			FsmBool fsmBool6 = new FsmBool();
			fsmBool6.useVariable = false;
			fsmBool6.value = false;
			finishImmediately = fsmBool6;
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
			FsmBool fsmBool7 = new FsmBool();
			fsmBool7.value = true;
			autoKillOnCompletion = fsmBool7;
			FsmBool fsmBool8 = new FsmBool();
			fsmBool8.value = false;
			recyclable = fsmBool8;
			updateType = default(UpdateType);
			FsmBool fsmBool9 = new FsmBool();
			fsmBool9.value = false;
			isIndependentUpdate = fsmBool9;
			FsmBool fsmBool10 = new FsmBool();
			fsmBool10.value = false;
			debugThis = fsmBool10;
		}

		[Token(Token = "0x60004CA")]
		[Address(RVA = "0xA1AC84", Offset = "0xA1AC84", Length = "0x3EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv28 = *([1EECC40]);\n\tv29 = *([v28 @ X8_v52]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2021D4D]) = v48;\nL_001D:\n\tv53 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv184 = UnityEngine.GameObject::GetComponent(v53);\n\tv83 = HutongGames.PlayMaker.FsmFloat::get_Value(this.to);\n\tv84 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tv240 = HutongGames.PlayMaker.FsmBool::get_Value(this.snapping);\n\tv185 = DG.Tweening.DOTweenModuleUI::DOAnchorPosX(v184, v83, v84, v240);\n\tthis.tween = v185;\n\tv244 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv246 = v244 == 0;\n\tif (v246) goto L_0051;\n\tv251 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_0051:\n\tv254 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv257 = DG.Tweening.TweenSettingsExtensions::SetRelative(this.tween, v254);\n\tv260 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v260);\n\tv86 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv266 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v86);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv269 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv272 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v269, this.loopType);\n\tv274 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv277 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v274);\n\tv279 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv282 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v279);\n\tv284 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv287 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v284);\n\tv288 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv290 = v288 == 0;\n\tif (v290) goto L_00C2;\n\tv305 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv296 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v305);\nL_00C2:\n\tv303 = this.startEvent == 0;\n\tif (v303) goto L_00DA;\n\tv310 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v310, this, Il2CppMethodInfo);\n\tv316 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v310);\nL_00DA:\n\tv325 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv329 = v325 == 0;\n\tv330 = ~v329;\n\tif (v330) goto L_00FC;\n\tv336 = new DG.Tweening.TweenCallback();\n\tv345 = this.finishEvent == 0;\n\tif (v345) goto L_FFFFFFFF;\n\tgoto L_00F1;\nL_00F1:\n\tDG.Tweening.TweenCallback::.ctor(v336, this, *([v357 @ X8_v33 (Il2CppMethodInfo)]));\n\tv343 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v336);\nL_00FC:\n\tv350 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv356 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv362 = v356 == 0;\n\tif (v362) goto L_010F;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween RectTransform Anchor Pos X\");\nL_010F:\n\tv225 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv227 = v225 == 0;\n\tif (v227) goto L_012B;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_012B:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 238 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			RectTransform component = ownerDefaultTarget.GetComponent<RectTransform>();
			float value = to.Value;
			float value2 = duration.Value;
			bool value3 = snapping.Value;
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = component.DOAnchorPosX(value, value2, value3);
			tween = tweenerCore;
			if (setSpeedBased.Value)
			{
				Tweener tweener = tween.SetSpeedBased();
			}
			bool value4 = setRelative.Value;
			Tweener tweener2 = tween.SetRelative(value4);
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
				State.Debug("DOTween RectTransform Anchor Pos X");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x60004CB")]
		[Address(RVA = "0xA1B070", Offset = "0xA1B070", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EC4760]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021D4E]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenRectTransformAnchorPosX()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
