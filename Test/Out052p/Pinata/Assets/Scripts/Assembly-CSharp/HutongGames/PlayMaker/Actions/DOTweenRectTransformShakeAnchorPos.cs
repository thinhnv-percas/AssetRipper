using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using Doozy.PlayMaker;
using Doozy.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74FCF8", Offset = "0x74FCF8")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x74FCF8", Offset = "0x74FCF8")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x74FCF8", Offset = "0x74FCF8")]
	[Token(Token = "0x20000D2")]
	public class DOTweenRectTransformShakeAnchorPos : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x782B9C", Offset = "0x782B9C")]
		[Token(Token = "0x4000964")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x782C10", Offset = "0x782C10")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x782C10", Offset = "0x782C10")]
		[Token(Token = "0x4000965")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector2 strength;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x782C70", Offset = "0x782C70")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x782C70", Offset = "0x782C70")]
		[Token(Token = "0x4000966")]
		[FieldOffset(Offset = "0x60")]
		public FsmInt vibrato;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x782CC0", Offset = "0x782CC0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x782CC0", Offset = "0x782CC0")]
		[Token(Token = "0x4000967")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat randomness;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x782D10", Offset = "0x782D10")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x782D10", Offset = "0x782D10")]
		[Token(Token = "0x4000968")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool snapping;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x782D60", Offset = "0x782D60")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x782D60", Offset = "0x782D60")]
		[Token(Token = "0x4000969")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x782DC0", Offset = "0x782DC0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x782DC0", Offset = "0x782DC0")]
		[Token(Token = "0x400096A")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x782E10", Offset = "0x782E10")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x782E10", Offset = "0x782E10")]
		[Token(Token = "0x400096B")]
		[FieldOffset(Offset = "0x88")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x782E60", Offset = "0x782E60")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x782E60", Offset = "0x782E60")]
		[Token(Token = "0x400096C")]
		[FieldOffset(Offset = "0x90")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x782EB0", Offset = "0x782EB0")]
		[Token(Token = "0x400096D")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x782EC4", Offset = "0x782EC4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x782EC4", Offset = "0x782EC4")]
		[Token(Token = "0x400096E")]
		[FieldOffset(Offset = "0xA0")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x782F14", Offset = "0x782F14")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x782F14", Offset = "0x782F14")]
		[Token(Token = "0x400096F")]
		[FieldOffset(Offset = "0xA8")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x782F64", Offset = "0x782F64")]
		[Token(Token = "0x4000970")]
		[FieldOffset(Offset = "0xB0")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x782F9C", Offset = "0x782F9C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x782F9C", Offset = "0x782F9C")]
		[Token(Token = "0x4000971")]
		[FieldOffset(Offset = "0xB8")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x782FEC", Offset = "0x782FEC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x782FEC", Offset = "0x782FEC")]
		[Token(Token = "0x4000972")]
		[FieldOffset(Offset = "0xC0")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x78303C", Offset = "0x78303C")]
		[Token(Token = "0x4000973")]
		[FieldOffset(Offset = "0xC8")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x783074", Offset = "0x783074")]
		[Token(Token = "0x4000974")]
		[FieldOffset(Offset = "0xCC")]
		public Ease easeType;

		[Token(Token = "0x4000975")]
		[FieldOffset(Offset = "0xD0")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7830AC", Offset = "0x7830AC")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7830AC", Offset = "0x7830AC")]
		[Token(Token = "0x4000976")]
		[FieldOffset(Offset = "0xD8")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7830FC", Offset = "0x7830FC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7830FC", Offset = "0x7830FC")]
		[Token(Token = "0x4000977")]
		[FieldOffset(Offset = "0xE0")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78314C", Offset = "0x78314C")]
		[Token(Token = "0x4000978")]
		[FieldOffset(Offset = "0xE8")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x783184", Offset = "0x783184")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x783184", Offset = "0x783184")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x783184", Offset = "0x783184")]
		[Token(Token = "0x4000979")]
		[FieldOffset(Offset = "0xF0")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7831F8", Offset = "0x7831F8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7831F8", Offset = "0x7831F8")]
		[Token(Token = "0x400097A")]
		[FieldOffset(Offset = "0xF8")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x783248", Offset = "0x783248")]
		[Token(Token = "0x400097B")]
		[FieldOffset(Offset = "0x100")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x783280", Offset = "0x783280")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x783280", Offset = "0x783280")]
		[Token(Token = "0x400097C")]
		[FieldOffset(Offset = "0x108")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7832D0", Offset = "0x7832D0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7832D0", Offset = "0x7832D0")]
		[Token(Token = "0x400097D")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool debugThis;

		[Token(Token = "0x400097E")]
		[FieldOffset(Offset = "0x118")]
		private Tweener tween;

		[Token(Token = "0x60004EC")]
		[Address(RVA = "0xA1DC04", Offset = "0xA1DC04", Length = "0x2A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EA61A8]);\n\tv25 = *([v24 @ X8_v12]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021D61]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.FsmVector2::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.strength = v50;\n\tv57 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v57);\n\tv57.useVariable = 0;\n\tv57.value = 0xA;\n\tthis.vibrato = v57;\n\tv80 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v80);\n\tv80.useVariable = 0;\n\tv80.value = 90f;\n\tthis.randomness = v80;\n\tv81 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v81);\n\tv81.useVariable = 0;\n\tv81.value = 0;\n\tthis.snapping = v81;\n\tv82 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v82);\n\tv82.useVariable = 0;\n\tthis.duration = v82;\n\tv83 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v83);\n\tv83.useVariable = 0;\n\tv83.value = 0;\n\tthis.setSpeedBased = v83;\n\tv84 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v84);\n\tv84.value = 0f;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.startDelay = v84;\n\tv85 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v85);\n\tv85.useVariable = 0;\n\tv85.value = 0;\n\tthis.finishImmediately = v85;\n\tv86 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v86);\n\tv86.useVariable = 0;\n\tthis.stringAsId = v86;\n\tv87 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v87);\n\tv87.useVariable = 0;\n\tthis.tagAsId = v87;\n\tthis.selectedEase = 0x100000000;\n\tv88 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v88);\n\tv88.value = 0;\n\tthis.loops = v88;\n\tthis.loopType = 0;\n\tv89 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v89);\n\tv89.value = 1;\n\tthis.autoKillOnCompletion = v89;\n\tv90 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v90);\n\tv90.value = 0;\n\tthis.recyclable = v90;\n\tthis.updateType = 0;\n\tv91 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v91);\n\tv91.value = 0;\n\tthis.isIndependentUpdate = v91;\n\tv92 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v92);\n\tv92.value = 0;\n\tthis.debugThis = v92;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 116 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_01df: Expected I4, but got I8
			base.Reset();
			gameObject = null;
			FsmVector2 fsmVector = new FsmVector2();
			fsmVector.useVariable = false;
			strength = fsmVector;
			FsmInt fsmInt = new FsmInt();
			fsmInt.useVariable = false;
			fsmInt.Value = 10;
			vibrato = fsmInt;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = false;
			fsmFloat.Value = 90f;
			randomness = fsmFloat;
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

		[Token(Token = "0x60004ED")]
		[Address(RVA = "0xA1DEA4", Offset = "0xA1DEA4", Length = "0x3C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv32 = *([1EC25D0]);\n\tv33 = *([v32 @ X8_v49]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2021D62]) = v52;\nL_001F:\n\tv57 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv192 = UnityEngine.GameObject::GetComponent(v57);\n\tv99 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tv151 = this.strength;\n\tv194 = HutongGames.PlayMaker.FsmInt::get_Value(this.vibrato);\n\tv100 = HutongGames.PlayMaker.FsmFloat::get_Value(this.randomness);\n\tv262 = HutongGames.PlayMaker.FsmBool::get_Value(this.snapping);\n\t// 78 MakeStruct v67 @ AGGA1DF98_2_v3 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v151.value (UnityEngine.Vector2), v151.value.y (System.Single)\n\tv195 = DG.Tweening.DOTweenModuleUI::DOShakeAnchorPos(v192, v99, v67, v194, v100, v262, 1);\n\tthis.tween = v195;\n\tv266 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv268 = v266 == 0;\n\tif (v268) goto L_0068;\n\tv273 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_0068:\n\tv277 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v277);\n\tv102 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv283 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v102);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv286 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv289 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v286, this.loopType);\n\tv291 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv294 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v291);\n\tv296 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv299 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v296);\n\tv303 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv310 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v303);\n\tv312 = this.startEvent == 0;\n\tif (v312) goto L_00CD;\n\tv317 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v317, this, Il2CppMethodInfo);\n\tv323 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v317);\nL_00CD:\n\tv330 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv334 = v330 == 0;\n\tv335 = ~v334;\n\tif (v335) goto L_00EF;\n\tv341 = new DG.Tweening.TweenCallback();\n\tv350 = this.finishEvent == 0;\n\tif (v350) goto L_FFFFFFFF;\n\tgoto L_00E4;\nL_00E4:\n\tDG.Tweening.TweenCallback::.ctor(v341, this, *([v362 @ X8_v32 (Il2CppMethodInfo)]));\n\tv348 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v341);\nL_00EF:\n\tv355 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv361 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv367 = v361 == 0;\n\tif (v367) goto L_0102;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween RectTransform Shake Anchor Pos\");\nL_0102:\n\tv247 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv249 = v247 == 0;\n\tif (v249) goto L_0122;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0122:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 233 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			RectTransform component = ownerDefaultTarget.GetComponent<RectTransform>();
			float value = duration.Value;
			FsmVector2 fsmVector = strength;
			int value2 = vibrato.Value;
			float value3 = randomness.Value;
			bool value4 = snapping.Value;
			Vector2 vector = default(Vector2);
			vector.x = fsmVector.value.x;
			vector.y = fsmVector.value.y;
			Tweener tweener = component.DOShakeAnchorPos(value, vector, value2, value3, value4);
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
				State.Debug("DOTween RectTransform Shake Anchor Pos");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x60004EE")]
		[Address(RVA = "0xA1E264", Offset = "0xA1E264", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1F028F8]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021D63]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenRectTransformShakeAnchorPos()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
