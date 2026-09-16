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
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74FD7C", Offset = "0x74FD7C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x74FD7C", Offset = "0x74FD7C")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x74FD7C", Offset = "0x74FD7C")]
	[Token(Token = "0x20000D3")]
	public class DOTweenRectTransformSizeDelta : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x783320", Offset = "0x783320")]
		[Token(Token = "0x400097F")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x783394", Offset = "0x783394")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x783394", Offset = "0x783394")]
		[Token(Token = "0x4000980")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector2 to;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7833F4", Offset = "0x7833F4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7833F4", Offset = "0x7833F4")]
		[Token(Token = "0x4000981")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool setRelative;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x783444", Offset = "0x783444")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x783444", Offset = "0x783444")]
		[Token(Token = "0x4000982")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool snapping;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x783494", Offset = "0x783494")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x783494", Offset = "0x783494")]
		[Token(Token = "0x4000983")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7834F4", Offset = "0x7834F4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7834F4", Offset = "0x7834F4")]
		[Token(Token = "0x4000984")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x783544", Offset = "0x783544")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x783544", Offset = "0x783544")]
		[Token(Token = "0x4000985")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x783594", Offset = "0x783594")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x783594", Offset = "0x783594")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x783594", Offset = "0x783594")]
		[Token(Token = "0x4000986")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x783608", Offset = "0x783608")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x783608", Offset = "0x783608")]
		[Token(Token = "0x4000987")]
		[FieldOffset(Offset = "0x90")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x783658", Offset = "0x783658")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x783658", Offset = "0x783658")]
		[Token(Token = "0x4000988")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7836A8", Offset = "0x7836A8")]
		[Token(Token = "0x4000989")]
		[FieldOffset(Offset = "0xA0")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7836BC", Offset = "0x7836BC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7836BC", Offset = "0x7836BC")]
		[Token(Token = "0x400098A")]
		[FieldOffset(Offset = "0xA8")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x78370C", Offset = "0x78370C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78370C", Offset = "0x78370C")]
		[Token(Token = "0x400098B")]
		[FieldOffset(Offset = "0xB0")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78375C", Offset = "0x78375C")]
		[Token(Token = "0x400098C")]
		[FieldOffset(Offset = "0xB8")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x783794", Offset = "0x783794")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x783794", Offset = "0x783794")]
		[Token(Token = "0x400098D")]
		[FieldOffset(Offset = "0xC0")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7837E4", Offset = "0x7837E4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7837E4", Offset = "0x7837E4")]
		[Token(Token = "0x400098E")]
		[FieldOffset(Offset = "0xC8")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x783834", Offset = "0x783834")]
		[Token(Token = "0x400098F")]
		[FieldOffset(Offset = "0xD0")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78386C", Offset = "0x78386C")]
		[Token(Token = "0x4000990")]
		[FieldOffset(Offset = "0xD4")]
		public Ease easeType;

		[Token(Token = "0x4000991")]
		[FieldOffset(Offset = "0xD8")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7838A4", Offset = "0x7838A4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7838A4", Offset = "0x7838A4")]
		[Token(Token = "0x4000992")]
		[FieldOffset(Offset = "0xE0")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7838F4", Offset = "0x7838F4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7838F4", Offset = "0x7838F4")]
		[Token(Token = "0x4000993")]
		[FieldOffset(Offset = "0xE8")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x783944", Offset = "0x783944")]
		[Token(Token = "0x4000994")]
		[FieldOffset(Offset = "0xF0")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x78397C", Offset = "0x78397C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78397C", Offset = "0x78397C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78397C", Offset = "0x78397C")]
		[Token(Token = "0x4000995")]
		[FieldOffset(Offset = "0xF8")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7839F0", Offset = "0x7839F0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7839F0", Offset = "0x7839F0")]
		[Token(Token = "0x4000996")]
		[FieldOffset(Offset = "0x100")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x783A40", Offset = "0x783A40")]
		[Token(Token = "0x4000997")]
		[FieldOffset(Offset = "0x108")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x783A78", Offset = "0x783A78")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x783A78", Offset = "0x783A78")]
		[Token(Token = "0x4000998")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x783AC8", Offset = "0x783AC8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x783AC8", Offset = "0x783AC8")]
		[Token(Token = "0x4000999")]
		[FieldOffset(Offset = "0x118")]
		public FsmBool debugThis;

		[Token(Token = "0x400099A")]
		[FieldOffset(Offset = "0x120")]
		private Tweener tween;

		[Token(Token = "0x60004F1")]
		[Address(RVA = "0xA1E314", Offset = "0xA1E314", Length = "0x2C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1F0BAC0]);\n\tv25 = *([v24 @ X8_v12]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021D64]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.FsmVector2::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.to = v50;\n\tv57 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v57);\n\tv57.useVariable = 0;\n\tthis.duration = v57;\n\tv80 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v80);\n\tv80.useVariable = 0;\n\tv80.value = 0;\n\tthis.setSpeedBased = v80;\n\tv81 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v81);\n\tv81.useVariable = 0;\n\tv81.value = 0;\n\tthis.snapping = v81;\n\tv82 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v82);\n\tv82.useVariable = 0;\n\tv82.value = 0;\n\tthis.setRelative = v82;\n\tv83 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v83);\n\tv83.useVariable = 0;\n\tv83.value = 0;\n\tthis.playInReverse = v83;\n\tv84 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v84);\n\tv84.useVariable = 0;\n\tv84.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v84;\n\tv85 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v85);\n\tv85.useVariable = 0;\n\tv85.value = 0;\n\tthis.finishImmediately = v85;\n\tv86 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v86);\n\tv86.useVariable = 0;\n\tthis.stringAsId = v86;\n\tv87 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v87);\n\tv87.useVariable = 0;\n\tthis.tagAsId = v87;\n\tv88 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v88);\n\tv88.value = 0f;\n\tthis.startDelay = v88;\n\tthis.selectedEase = 0x100000000;\n\tv89 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v89);\n\tv89.value = 0;\n\tthis.loops = v89;\n\tthis.loopType = 0;\n\tv90 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v90);\n\tv90.value = 1;\n\tthis.autoKillOnCompletion = v90;\n\tv91 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v91);\n\tv91.value = 0;\n\tthis.recyclable = v91;\n\tthis.updateType = 0;\n\tv92 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v92);\n\tv92.value = 0;\n\tthis.isIndependentUpdate = v92;\n\tv93 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v93);\n\tv93.value = 0;\n\tthis.debugThis = v93;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 119 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_0214: Expected I4, but got I8
			base.Reset();
			gameObject = null;
			FsmVector2 fsmVector = new FsmVector2();
			fsmVector.useVariable = false;
			to = fsmVector;
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
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.Value = 0f;
			startDelay = fsmFloat2;
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

		[Token(Token = "0x60004F2")]
		[Address(RVA = "0xA1E5D4", Offset = "0xA1E5D4", Length = "0x3F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv30 = *([1EFB188]);\n\tv31 = *([v30 @ X8_v52]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2021D65]) = v50;\nL_001E:\n\tv55 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv194 = UnityEngine.GameObject::GetComponent(v55);\n\tv154 = this.to;\n\tv88 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tv254 = HutongGames.PlayMaker.FsmBool::get_Value(this.snapping);\n\t// 60 MakeStruct v80 @ AGGA1E68C_1_v3 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v154.value (UnityEngine.Vector2), v154.value.y (System.Single)\n\tv195 = DG.Tweening.DOTweenModuleUI::DOSizeDelta(v194, v80, v88, v254);\n\tthis.tween = v195;\n\tv258 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv260 = v258 == 0;\n\tif (v260) goto L_0052;\n\tv265 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_0052:\n\tv268 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv271 = DG.Tweening.TweenSettingsExtensions::SetRelative(this.tween, v268);\n\tv274 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v274);\n\tv90 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv280 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v90);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv283 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv286 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v283, this.loopType);\n\tv288 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv291 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v288);\n\tv293 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv296 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v293);\n\tv298 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv301 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v298);\n\tv302 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv304 = v302 == 0;\n\tif (v304) goto L_00C3;\n\tv319 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv310 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v319);\nL_00C3:\n\tv317 = this.startEvent == 0;\n\tif (v317) goto L_00DB;\n\tv324 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v324, this, Il2CppMethodInfo);\n\tv330 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v324);\nL_00DB:\n\tv339 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv343 = v339 == 0;\n\tv344 = ~v343;\n\tif (v344) goto L_00FD;\n\tv350 = new DG.Tweening.TweenCallback();\n\tv359 = this.finishEvent == 0;\n\tif (v359) goto L_FFFFFFFF;\n\tgoto L_00F2;\nL_00F2:\n\tDG.Tweening.TweenCallback::.ctor(v350, this, *([v371 @ X8_v33 (Il2CppMethodInfo)]));\n\tv357 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v350);\nL_00FD:\n\tv364 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv370 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv376 = v370 == 0;\n\tif (v376) goto L_0110;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween RectTransform Size Delta\");\nL_0110:\n\tv240 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv242 = v240 == 0;\n\tif (v242) goto L_012E;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_012E:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 240 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			RectTransform component = ownerDefaultTarget.GetComponent<RectTransform>();
			FsmVector2 fsmVector = to;
			float value = duration.Value;
			bool value2 = snapping.Value;
			Vector2 endValue = default(Vector2);
			endValue.x = fsmVector.value.x;
			endValue.y = fsmVector.value.y;
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = component.DOSizeDelta(endValue, value, value2);
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
				State.Debug("DOTween RectTransform Size Delta");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x60004F3")]
		[Address(RVA = "0xA1E9C4", Offset = "0xA1E9C4", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EA3338]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021D66]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenRectTransformSizeDelta()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
