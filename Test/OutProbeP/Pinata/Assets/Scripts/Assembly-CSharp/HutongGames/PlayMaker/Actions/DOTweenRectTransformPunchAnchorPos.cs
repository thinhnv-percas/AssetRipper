using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using Doozy.PlayMaker;
using Doozy.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74FC74", Offset = "0x74FC74")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x74FC74", Offset = "0x74FC74")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x74FC74", Offset = "0x74FC74")]
	[Token(Token = "0x20000D1")]
	public class DOTweenRectTransformPunchAnchorPos : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x782418", Offset = "0x782418")]
		[Token(Token = "0x4000949")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78248C", Offset = "0x78248C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78248C", Offset = "0x78248C")]
		[Token(Token = "0x400094A")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector2 punch;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7824EC", Offset = "0x7824EC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7824EC", Offset = "0x7824EC")]
		[Token(Token = "0x400094B")]
		[FieldOffset(Offset = "0x60")]
		public FsmInt vibrato;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78253C", Offset = "0x78253C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78253C", Offset = "0x78253C")]
		[Token(Token = "0x400094C")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat elasticity;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78258C", Offset = "0x78258C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78258C", Offset = "0x78258C")]
		[Token(Token = "0x400094D")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool snapping;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7825DC", Offset = "0x7825DC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7825DC", Offset = "0x7825DC")]
		[Token(Token = "0x400094E")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78263C", Offset = "0x78263C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78263C", Offset = "0x78263C")]
		[Token(Token = "0x400094F")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78268C", Offset = "0x78268C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78268C", Offset = "0x78268C")]
		[Token(Token = "0x4000950")]
		[FieldOffset(Offset = "0x88")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7826DC", Offset = "0x7826DC")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7826DC", Offset = "0x7826DC")]
		[Token(Token = "0x4000951")]
		[FieldOffset(Offset = "0x90")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78272C", Offset = "0x78272C")]
		[Token(Token = "0x4000952")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x782740", Offset = "0x782740")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x782740", Offset = "0x782740")]
		[Token(Token = "0x4000953")]
		[FieldOffset(Offset = "0xA0")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x782790", Offset = "0x782790")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x782790", Offset = "0x782790")]
		[Token(Token = "0x4000954")]
		[FieldOffset(Offset = "0xA8")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7827E0", Offset = "0x7827E0")]
		[Token(Token = "0x4000955")]
		[FieldOffset(Offset = "0xB0")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x782818", Offset = "0x782818")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x782818", Offset = "0x782818")]
		[Token(Token = "0x4000956")]
		[FieldOffset(Offset = "0xB8")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x782868", Offset = "0x782868")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x782868", Offset = "0x782868")]
		[Token(Token = "0x4000957")]
		[FieldOffset(Offset = "0xC0")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7828B8", Offset = "0x7828B8")]
		[Token(Token = "0x4000958")]
		[FieldOffset(Offset = "0xC8")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7828F0", Offset = "0x7828F0")]
		[Token(Token = "0x4000959")]
		[FieldOffset(Offset = "0xCC")]
		public Ease easeType;

		[Token(Token = "0x400095A")]
		[FieldOffset(Offset = "0xD0")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x782928", Offset = "0x782928")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x782928", Offset = "0x782928")]
		[Token(Token = "0x400095B")]
		[FieldOffset(Offset = "0xD8")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x782978", Offset = "0x782978")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x782978", Offset = "0x782978")]
		[Token(Token = "0x400095C")]
		[FieldOffset(Offset = "0xE0")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7829C8", Offset = "0x7829C8")]
		[Token(Token = "0x400095D")]
		[FieldOffset(Offset = "0xE8")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x782A00", Offset = "0x782A00")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x782A00", Offset = "0x782A00")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x782A00", Offset = "0x782A00")]
		[Token(Token = "0x400095E")]
		[FieldOffset(Offset = "0xF0")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x782A74", Offset = "0x782A74")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x782A74", Offset = "0x782A74")]
		[Token(Token = "0x400095F")]
		[FieldOffset(Offset = "0xF8")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x782AC4", Offset = "0x782AC4")]
		[Token(Token = "0x4000960")]
		[FieldOffset(Offset = "0x100")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x782AFC", Offset = "0x782AFC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x782AFC", Offset = "0x782AFC")]
		[Token(Token = "0x4000961")]
		[FieldOffset(Offset = "0x108")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x782B4C", Offset = "0x782B4C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x782B4C", Offset = "0x782B4C")]
		[Token(Token = "0x4000962")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool debugThis;

		[Token(Token = "0x4000963")]
		[FieldOffset(Offset = "0x118")]
		private Tweener tween;

		[Token(Token = "0x60004E7")]
		[Address(RVA = "0xA1D4F8", Offset = "0xA1D4F8", Length = "0x2A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EB5318]);\n\tv27 = *([v26 @ X8_v12]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2021D5E]) = v46;\nL_0019:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv52 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.FsmVector2::.ctor(v52);\n\tv52.useVariable = 0;\n\tthis.punch = v52;\n\tv59 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v59);\n\tv59.useVariable = 0;\n\tthis.duration = v59;\n\tv83 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v83);\n\tv83.useVariable = 0;\n\tv83.value = 0;\n\tthis.setSpeedBased = v83;\n\tv84 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v84);\n\tv84.useVariable = 0;\n\tv84.value = 0xA;\n\tthis.vibrato = v84;\n\tv85 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v85);\n\tv85.useVariable = 0;\n\tv85.value = 1f;\n\tthis.elasticity = v85;\n\tv86 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v86);\n\tv86.useVariable = 0;\n\tv86.value = 0;\n\tthis.snapping = v86;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tv87 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v87);\n\tv87.useVariable = 0;\n\tv87.value = 0;\n\tthis.finishImmediately = v87;\n\tv88 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v88);\n\tv88.useVariable = 0;\n\tthis.stringAsId = v88;\n\tv89 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v89);\n\tv89.useVariable = 0;\n\tthis.tagAsId = v89;\n\tv90 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v90);\n\tv90.value = 0f;\n\tthis.startDelay = v90;\n\tthis.selectedEase = 0x100000000;\n\tv91 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v91);\n\tv91.value = 0;\n\tthis.loops = v91;\n\tthis.loopType = 0;\n\tv92 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v92);\n\tv92.value = 1;\n\tthis.autoKillOnCompletion = v92;\n\tv93 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v93);\n\tv93.value = 0;\n\tthis.recyclable = v93;\n\tthis.updateType = 0;\n\tv94 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v94);\n\tv94.value = 0;\n\tthis.isIndependentUpdate = v94;\n\tv95 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v95);\n\tv95.value = 0;\n\tthis.debugThis = v95;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 118 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_01df: Expected I4, but got I8
			base.Reset();
			gameObject = null;
			FsmVector2 fsmVector = new FsmVector2();
			fsmVector.useVariable = false;
			punch = fsmVector;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = false;
			duration = fsmFloat;
			FsmBool fsmBool = new FsmBool();
			fsmBool.useVariable = false;
			fsmBool.value = false;
			setSpeedBased = fsmBool;
			FsmInt fsmInt = new FsmInt();
			fsmInt.useVariable = false;
			fsmInt.Value = 10;
			vibrato = fsmInt;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = false;
			fsmFloat2.Value = 1f;
			elasticity = fsmFloat2;
			FsmBool fsmBool2 = new FsmBool();
			fsmBool2.useVariable = false;
			fsmBool2.value = false;
			snapping = fsmBool2;
			startEvent = null;
			finishEvent = null;
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
			FsmFloat fsmFloat3 = new FsmFloat();
			fsmFloat3.Value = 0f;
			startDelay = fsmFloat3;
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

		[Token(Token = "0x60004E8")]
		[Address(RVA = "0xA1D79C", Offset = "0xA1D79C", Length = "0x3B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv32 = *([1EF98C0]);\n\tv33 = *([v32 @ X8_v48]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2021D5F]) = v52;\nL_001F:\n\tv57 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv193 = UnityEngine.GameObject::GetComponent(v57);\n\tv153 = this.punch;\n\tv94 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tv194 = HutongGames.PlayMaker.FsmInt::get_Value(this.vibrato);\n\tv95 = HutongGames.PlayMaker.FsmFloat::get_Value(this.elasticity);\n\tv260 = HutongGames.PlayMaker.FsmBool::get_Value(this.snapping);\n\t// 76 MakeStruct v70 @ AGGA1D888_1_v3 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v153.value (UnityEngine.Vector2), v153.value.y (System.Single)\n\tv195 = DG.Tweening.DOTweenModuleUI::DOPunchAnchorPos(v193, v70, v94, v194, v95, v260);\n\tthis.tween = v195;\n\tv264 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv266 = v264 == 0;\n\tif (v266) goto L_0066;\n\tv271 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_0066:\n\tv275 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v275);\n\tv97 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv281 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v97);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv284 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv287 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v284, this.loopType);\n\tv289 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv292 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v289);\n\tv294 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv297 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v294);\n\tv301 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv308 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v301);\n\tv310 = this.startEvent == 0;\n\tif (v310) goto L_00CB;\n\tv315 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v315, this, Il2CppMethodInfo);\n\tv321 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v315);\nL_00CB:\n\tv328 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv332 = v328 == 0;\n\tv333 = ~v332;\n\tif (v333) goto L_00ED;\n\tv339 = new DG.Tweening.TweenCallback();\n\tv348 = this.finishEvent == 0;\n\tif (v348) goto L_FFFFFFFF;\n\tgoto L_00E2;\nL_00E2:\n\tDG.Tweening.TweenCallback::.ctor(v339, this, *([v360 @ X8_v31 (Il2CppMethodInfo)]));\n\tv346 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v339);\nL_00ED:\n\tv353 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv359 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv365 = v359 == 0;\n\tif (v365) goto L_0100;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween RectTransform Punch Anchor Pos\");\nL_0100:\n\tv245 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv247 = v245 == 0;\n\tif (v247) goto L_0120;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0120:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 231 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			RectTransform component = ownerDefaultTarget.GetComponent<RectTransform>();
			FsmVector2 fsmVector = punch;
			float value = duration.Value;
			int value2 = vibrato.Value;
			float value3 = elasticity.Value;
			bool value4 = snapping.Value;
			Vector2 vector = default(Vector2);
			vector.x = fsmVector.value.x;
			vector.y = fsmVector.value.y;
			Tweener tweener = component.DOPunchAnchorPos(vector, value, value2, value3, value4);
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
				State.Debug("DOTween RectTransform Punch Anchor Pos");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x60004E9")]
		[Address(RVA = "0xA1DB54", Offset = "0xA1DB54", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ECA9C0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021D60]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenRectTransformPunchAnchorPos()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
