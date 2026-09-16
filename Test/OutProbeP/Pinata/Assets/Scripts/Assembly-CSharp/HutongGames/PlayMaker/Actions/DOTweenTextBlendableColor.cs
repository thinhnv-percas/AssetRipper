using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using Doozy.PlayMaker;
using Doozy.PlayMaker.Actions;
using UnityEngine;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x750850", Offset = "0x750850")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x750850", Offset = "0x750850")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x750850", Offset = "0x750850")]
	[Token(Token = "0x20000E8")]
	public class DOTweenTextBlendableColor : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x78E104", Offset = "0x78E104")]
		[Token(Token = "0x4000BDC")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78E178", Offset = "0x78E178")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78E178", Offset = "0x78E178")]
		[Token(Token = "0x4000BDD")]
		[FieldOffset(Offset = "0x58")]
		public FsmColor to;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78E1D8", Offset = "0x78E1D8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78E1D8", Offset = "0x78E1D8")]
		[Token(Token = "0x4000BDE")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool setRelative;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78E228", Offset = "0x78E228")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78E228", Offset = "0x78E228")]
		[Token(Token = "0x4000BDF")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78E288", Offset = "0x78E288")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78E288", Offset = "0x78E288")]
		[Token(Token = "0x4000BE0")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78E2D8", Offset = "0x78E2D8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78E2D8", Offset = "0x78E2D8")]
		[Token(Token = "0x4000BE1")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x78E328", Offset = "0x78E328")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78E328", Offset = "0x78E328")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78E328", Offset = "0x78E328")]
		[Token(Token = "0x4000BE2")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78E39C", Offset = "0x78E39C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78E39C", Offset = "0x78E39C")]
		[Token(Token = "0x4000BE3")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x78E3EC", Offset = "0x78E3EC")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78E3EC", Offset = "0x78E3EC")]
		[Token(Token = "0x4000BE4")]
		[FieldOffset(Offset = "0x90")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78E43C", Offset = "0x78E43C")]
		[Token(Token = "0x4000BE5")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78E450", Offset = "0x78E450")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78E450", Offset = "0x78E450")]
		[Token(Token = "0x4000BE6")]
		[FieldOffset(Offset = "0xA0")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x78E4A0", Offset = "0x78E4A0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78E4A0", Offset = "0x78E4A0")]
		[Token(Token = "0x4000BE7")]
		[FieldOffset(Offset = "0xA8")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78E4F0", Offset = "0x78E4F0")]
		[Token(Token = "0x4000BE8")]
		[FieldOffset(Offset = "0xB0")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78E528", Offset = "0x78E528")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78E528", Offset = "0x78E528")]
		[Token(Token = "0x4000BE9")]
		[FieldOffset(Offset = "0xB8")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78E578", Offset = "0x78E578")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78E578", Offset = "0x78E578")]
		[Token(Token = "0x4000BEA")]
		[FieldOffset(Offset = "0xC0")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x78E5C8", Offset = "0x78E5C8")]
		[Token(Token = "0x4000BEB")]
		[FieldOffset(Offset = "0xC8")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78E600", Offset = "0x78E600")]
		[Token(Token = "0x4000BEC")]
		[FieldOffset(Offset = "0xCC")]
		public Ease easeType;

		[Token(Token = "0x4000BED")]
		[FieldOffset(Offset = "0xD0")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x78E638", Offset = "0x78E638")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78E638", Offset = "0x78E638")]
		[Token(Token = "0x4000BEE")]
		[FieldOffset(Offset = "0xD8")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78E688", Offset = "0x78E688")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78E688", Offset = "0x78E688")]
		[Token(Token = "0x4000BEF")]
		[FieldOffset(Offset = "0xE0")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78E6D8", Offset = "0x78E6D8")]
		[Token(Token = "0x4000BF0")]
		[FieldOffset(Offset = "0xE8")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x78E710", Offset = "0x78E710")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78E710", Offset = "0x78E710")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78E710", Offset = "0x78E710")]
		[Token(Token = "0x4000BF1")]
		[FieldOffset(Offset = "0xF0")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78E784", Offset = "0x78E784")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78E784", Offset = "0x78E784")]
		[Token(Token = "0x4000BF2")]
		[FieldOffset(Offset = "0xF8")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78E7D4", Offset = "0x78E7D4")]
		[Token(Token = "0x4000BF3")]
		[FieldOffset(Offset = "0x100")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78E80C", Offset = "0x78E80C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78E80C", Offset = "0x78E80C")]
		[Token(Token = "0x4000BF4")]
		[FieldOffset(Offset = "0x108")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x78E85C", Offset = "0x78E85C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78E85C", Offset = "0x78E85C")]
		[Token(Token = "0x4000BF5")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool debugThis;

		[Token(Token = "0x4000BF6")]
		[FieldOffset(Offset = "0x118")]
		private Tweener tween;

		[Token(Token = "0x600055A")]
		[Address(RVA = "0xA28418", Offset = "0xA28418", Length = "0x29C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EF7EF8]);\n\tv25 = *([v24 @ X8_v12]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021DA3]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmColor();\n\tHutongGames.PlayMaker.FsmColor::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.to = v50;\n\tv57 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v57);\n\tv57.useVariable = 0;\n\tthis.duration = v57;\n\tv79 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v79);\n\tv79.useVariable = 0;\n\tv79.value = 0;\n\tthis.setSpeedBased = v79;\n\tv80 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v80);\n\tv80.useVariable = 0;\n\tv80.value = 0;\n\tthis.setRelative = v80;\n\tv81 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v81);\n\tv81.useVariable = 0;\n\tv81.value = 0;\n\tthis.playInReverse = v81;\n\tv82 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v82);\n\tv82.useVariable = 0;\n\tv82.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v82;\n\tv83 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v83);\n\tv83.useVariable = 0;\n\tv83.value = 0;\n\tthis.finishImmediately = v83;\n\tv84 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v84);\n\tv84.useVariable = 0;\n\tthis.stringAsId = v84;\n\tv85 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v85);\n\tv85.useVariable = 0;\n\tthis.tagAsId = v85;\n\tv86 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v86);\n\tv86.value = 0f;\n\tthis.startDelay = v86;\n\tthis.selectedEase = 0x100000000;\n\tv87 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v87);\n\tv87.value = 0;\n\tthis.loops = v87;\n\tthis.loopType = 0;\n\tv88 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v88);\n\tv88.value = 1;\n\tthis.autoKillOnCompletion = v88;\n\tv89 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v89);\n\tv89.value = 0;\n\tthis.recyclable = v89;\n\tthis.updateType = 0;\n\tv90 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v90);\n\tv90.value = 0;\n\tthis.isIndependentUpdate = v90;\n\tv91 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v91);\n\tv91.value = 0;\n\tthis.debugThis = v91;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_01df: Expected I4, but got I8
			base.Reset();
			gameObject = null;
			FsmColor fsmColor = new FsmColor();
			fsmColor.useVariable = false;
			to = fsmColor;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = false;
			duration = fsmFloat;
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
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.Value = 0f;
			startDelay = fsmFloat2;
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

		[Token(Token = "0x600055B")]
		[Address(RVA = "0xA286B4", Offset = "0xA286B4", Length = "0x3E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv32 = *([1F0BA50]);\n\tv33 = *([v32 @ X8_v52]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2021DA4]) = v52;\nL_001F:\n\tv57 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv200 = UnityEngine.GameObject::GetComponent(v57);\n\tv157 = this.to;\n\tv265 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\t// 58 MakeStruct v82 @ AGGA28760_1_v3 (UnityEngine.Color), typeof(UnityEngine.Color), v157.value (UnityEngine.Color), v157.value.g (System.Single), v157.value.b (System.Single), v157.value.a (System.Single)\n\tv201 = DG.Tweening.DOTweenModuleUI::DOBlendableColor(v200, v82, v265);\n\tthis.tween = v201;\n\tv269 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv271 = v269 == 0;\n\tif (v271) goto L_0050;\n\tv276 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_0050:\n\tv279 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv282 = DG.Tweening.TweenSettingsExtensions::SetRelative(this.tween, v279);\n\tv285 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v285);\n\tv93 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv291 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v93);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv294 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv297 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v294, this.loopType);\n\tv299 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv302 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v299);\n\tv304 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv307 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v304);\n\tv309 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv312 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v309);\n\tv313 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv315 = v313 == 0;\n\tif (v315) goto L_00C1;\n\tv330 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv321 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v330);\nL_00C1:\n\tv328 = this.startEvent == 0;\n\tif (v328) goto L_00D9;\n\tv335 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v335, this, Il2CppMethodInfo);\n\tv341 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v335);\nL_00D9:\n\tv350 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv354 = v350 == 0;\n\tv355 = ~v354;\n\tif (v355) goto L_00FB;\n\tv361 = new DG.Tweening.TweenCallback();\n\tv370 = this.finishEvent == 0;\n\tif (v370) goto L_FFFFFFFF;\n\tgoto L_00F0;\nL_00F0:\n\tDG.Tweening.TweenCallback::.ctor(v361, this, *([v382 @ X8_v33 (Il2CppMethodInfo)]));\n\tv368 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v361);\nL_00FB:\n\tv375 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv381 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv387 = v381 == 0;\n\tif (v387) goto L_010E;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Text Blendable Color\");\nL_010E:\n\tv251 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv253 = v251 == 0;\n\tif (v253) goto L_012E;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_012E:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 241 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			Text component = ownerDefaultTarget.GetComponent<Text>();
			FsmColor fsmColor = to;
			float value = duration.Value;
			Color endValue = default(Color);
			endValue.r = fsmColor.value.r;
			endValue.g = fsmColor.value.g;
			endValue.b = fsmColor.value.b;
			endValue.a = fsmColor.value.a;
			Tweener tweener = component.DOBlendableColor(endValue, value);
			tween = tweener;
			if (setSpeedBased.Value)
			{
				Tweener tweener2 = tween.SetSpeedBased();
			}
			bool value2 = setRelative.Value;
			Tweener tweener3 = tween.SetRelative(value2);
			GameObject ownerDefaultTarget2 = Fsm.GetOwnerDefaultTarget(gameObject);
			tween.SetTweenId(tweenIdType, stringAsId, tagAsId, ownerDefaultTarget2);
			float value3 = startDelay.Value;
			Tweener tweener4 = tween.SetDelay(value3);
			tween.SetSelectedEase(selectedEase, easeType, animationCurve);
			int value4 = loops.Value;
			Tweener tweener5 = tween.SetLoops(value4, loopType);
			bool value5 = autoKillOnCompletion.Value;
			Tweener tweener6 = tween.SetAutoKill(value5);
			bool value6 = recyclable.Value;
			Tweener tweener7 = tween.SetRecyclable(value6);
			bool value7 = isIndependentUpdate.Value;
			Tweener tweener8 = tween.SetUpdate(updateType, value7);
			if (playInReverse.Value)
			{
				bool value8 = setReverseRelative.Value;
				Tweener tweener9 = tween.From(value8);
			}
			if (startEvent != null)
			{
				TweenCallback action = delegate
				{
					Fsm.Event(startEvent);
				};
				Tweener tweener10 = tween.OnStart(action);
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
				Tweener tweener11 = tween.OnComplete(action2);
			}
			Tweener tweener12 = tween.Play();
			if (debugThis.Value)
			{
				State.Debug("DOTween Text Blendable Color");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x600055C")]
		[Address(RVA = "0xA28A98", Offset = "0xA28A98", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EDB0C0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021DA5]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenTextBlendableColor()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
