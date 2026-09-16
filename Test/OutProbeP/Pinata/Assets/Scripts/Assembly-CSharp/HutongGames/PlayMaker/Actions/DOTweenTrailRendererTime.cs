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
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x750AE4", Offset = "0x750AE4")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x750AE4", Offset = "0x750AE4")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x750AE4", Offset = "0x750AE4")]
	[Token(Token = "0x20000ED")]
	public class DOTweenTrailRendererTime : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x790770", Offset = "0x790770")]
		[Token(Token = "0x4000C64")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7907E4", Offset = "0x7907E4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7907E4", Offset = "0x7907E4")]
		[Token(Token = "0x4000C65")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat to;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x790844", Offset = "0x790844")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x790844", Offset = "0x790844")]
		[Token(Token = "0x4000C66")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7908A4", Offset = "0x7908A4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7908A4", Offset = "0x7908A4")]
		[Token(Token = "0x4000C67")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7908F4", Offset = "0x7908F4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7908F4", Offset = "0x7908F4")]
		[Token(Token = "0x4000C68")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x790944", Offset = "0x790944")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x790944", Offset = "0x790944")]
		[Token(Token = "0x4000C69")]
		[FieldOffset(Offset = "0x78")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x790994", Offset = "0x790994")]
		[Token(Token = "0x4000C6A")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7909A8", Offset = "0x7909A8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7909A8", Offset = "0x7909A8")]
		[Token(Token = "0x4000C6B")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7909F8", Offset = "0x7909F8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7909F8", Offset = "0x7909F8")]
		[Token(Token = "0x4000C6C")]
		[FieldOffset(Offset = "0x90")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x790A48", Offset = "0x790A48")]
		[Token(Token = "0x4000C6D")]
		[FieldOffset(Offset = "0x98")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x790A80", Offset = "0x790A80")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x790A80", Offset = "0x790A80")]
		[Token(Token = "0x4000C6E")]
		[FieldOffset(Offset = "0xA0")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x790AD0", Offset = "0x790AD0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x790AD0", Offset = "0x790AD0")]
		[Token(Token = "0x4000C6F")]
		[FieldOffset(Offset = "0xA8")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x790B20", Offset = "0x790B20")]
		[Token(Token = "0x4000C70")]
		[FieldOffset(Offset = "0xB0")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x790B58", Offset = "0x790B58")]
		[Token(Token = "0x4000C71")]
		[FieldOffset(Offset = "0xB4")]
		public Ease easeType;

		[Token(Token = "0x4000C72")]
		[FieldOffset(Offset = "0xB8")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x790B90", Offset = "0x790B90")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x790B90", Offset = "0x790B90")]
		[Token(Token = "0x4000C73")]
		[FieldOffset(Offset = "0xC0")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x790BE0", Offset = "0x790BE0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x790BE0", Offset = "0x790BE0")]
		[Token(Token = "0x4000C74")]
		[FieldOffset(Offset = "0xC8")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x790C30", Offset = "0x790C30")]
		[Token(Token = "0x4000C75")]
		[FieldOffset(Offset = "0xD0")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x790C68", Offset = "0x790C68")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x790C68", Offset = "0x790C68")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x790C68", Offset = "0x790C68")]
		[Token(Token = "0x4000C76")]
		[FieldOffset(Offset = "0xD8")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x790CDC", Offset = "0x790CDC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x790CDC", Offset = "0x790CDC")]
		[Token(Token = "0x4000C77")]
		[FieldOffset(Offset = "0xE0")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x790D2C", Offset = "0x790D2C")]
		[Token(Token = "0x4000C78")]
		[FieldOffset(Offset = "0xE8")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x790D64", Offset = "0x790D64")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x790D64", Offset = "0x790D64")]
		[Token(Token = "0x4000C79")]
		[FieldOffset(Offset = "0xF0")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x790DB4", Offset = "0x790DB4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x790DB4", Offset = "0x790DB4")]
		[Token(Token = "0x4000C7A")]
		[FieldOffset(Offset = "0xF8")]
		public FsmBool debugThis;

		[Token(Token = "0x4000C7B")]
		[FieldOffset(Offset = "0x100")]
		private Tweener tween;

		[Token(Token = "0x6000573")]
		[Address(RVA = "0xA756FC", Offset = "0xA756FC", Length = "0x228")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EDEE18]);\n\tv25 = *([v24 @ X8_v10]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202212E]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.to = v50;\n\tv55 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v55);\n\tv55.useVariable = 0;\n\tthis.duration = v55;\n\tv73 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v73);\n\tv73.useVariable = 0;\n\tv73.value = 0;\n\tthis.setSpeedBased = v73;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tv74 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v74);\n\tv74.useVariable = 0;\n\tv74.value = 0;\n\tthis.finishImmediately = v74;\n\tv75 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v75);\n\tv75.useVariable = 0;\n\tthis.stringAsId = v75;\n\tv76 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v76);\n\tv76.useVariable = 0;\n\tthis.tagAsId = v76;\n\tv77 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v77);\n\tv77.value = 0f;\n\tthis.startDelay = v77;\n\tthis.selectedEase = 0x100000000;\n\tv78 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v78);\n\tv78.value = 0;\n\tthis.loops = v78;\n\tthis.loopType = 0;\n\tv79 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v79);\n\tv79.value = 1;\n\tthis.autoKillOnCompletion = v79;\n\tv80 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v80);\n\tv80.value = 0;\n\tthis.recyclable = v80;\n\tthis.updateType = 0;\n\tv81 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v81);\n\tv81.value = 0;\n\tthis.isIndependentUpdate = v81;\n\tv82 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v82);\n\tv82.value = 0;\n\tthis.debugThis = v82;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 97 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_0140: Expected I4, but got I8
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
			FsmFloat fsmFloat3 = new FsmFloat();
			fsmFloat3.Value = 0f;
			startDelay = fsmFloat3;
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

		[Token(Token = "0x6000574")]
		[Address(RVA = "0xA75924", Offset = "0xA75924", Length = "0x368")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1EC12D0]);\n\tv27 = *([v26 @ X8_v47]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([202212F]) = v46;\nL_001C:\n\tv51 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv157 = UnityEngine.GameObject::GetComponent(v51);\n\tv77 = HutongGames.PlayMaker.FsmFloat::get_Value(this.to);\n\tv210 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tv158 = DG.Tweening.ShortcutExtensions::DOTime(v157, v77, v210);\n\tthis.tween = v158;\n\tv214 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv216 = v214 == 0;\n\tif (v216) goto L_004D;\n\tv221 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_004D:\n\tv225 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v225);\n\tv79 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv231 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v79);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv234 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv237 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v234, this.loopType);\n\tv239 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv242 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v239);\n\tv244 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv247 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v244);\n\tv251 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv258 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v251);\n\tv260 = this.startEvent == 0;\n\tif (v260) goto L_00B2;\n\tv265 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v265, this, Il2CppMethodInfo);\n\tv271 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v265);\nL_00B2:\n\tv278 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv282 = v278 == 0;\n\tv283 = ~v282;\n\tif (v283) goto L_00D4;\n\tv289 = new DG.Tweening.TweenCallback();\n\tv298 = this.finishEvent == 0;\n\tif (v298) goto L_FFFFFFFF;\n\tgoto L_00C9;\nL_00C9:\n\tDG.Tweening.TweenCallback::.ctor(v289, this, *([v310 @ X8_v30 (Il2CppMethodInfo)]));\n\tv296 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v289);\nL_00D4:\n\tv303 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv309 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv315 = v309 == 0;\n\tif (v315) goto L_00E7;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Trail Renderer Time\");\nL_00E7:\n\tv195 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv197 = v195 == 0;\n\tif (v197) goto L_0101;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0101:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 204 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			TrailRenderer component = ownerDefaultTarget.GetComponent<TrailRenderer>();
			float value = to.Value;
			float value2 = duration.Value;
			TweenerCore<float, float, FloatOptions> tweenerCore = component.DOTime(value, value2);
			tween = tweenerCore;
			if (setSpeedBased.Value)
			{
				Tweener tweener = tween.SetSpeedBased();
			}
			GameObject ownerDefaultTarget2 = Fsm.GetOwnerDefaultTarget(gameObject);
			tween.SetTweenId(tweenIdType, stringAsId, tagAsId, ownerDefaultTarget2);
			float value3 = startDelay.Value;
			Tweener tweener2 = tween.SetDelay(value3);
			tween.SetSelectedEase(selectedEase, easeType, animationCurve);
			int value4 = loops.Value;
			Tweener tweener3 = tween.SetLoops(value4, loopType);
			bool value5 = autoKillOnCompletion.Value;
			Tweener tweener4 = tween.SetAutoKill(value5);
			bool value6 = recyclable.Value;
			Tweener tweener5 = tween.SetRecyclable(value6);
			bool value7 = isIndependentUpdate.Value;
			Tweener tweener6 = tween.SetUpdate(updateType, value7);
			if (startEvent != null)
			{
				TweenCallback action = delegate
				{
					Fsm.Event(startEvent);
				};
				Tweener tweener7 = tween.OnStart(action);
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
				Tweener tweener8 = tween.OnComplete(action2);
			}
			Tweener tweener9 = tween.Play();
			if (debugThis.Value)
			{
				State.Debug("DOTween Trail Renderer Time");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000575")]
		[Address(RVA = "0xA75C8C", Offset = "0xA75C8C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EE9020]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022130]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenTrailRendererTime()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
