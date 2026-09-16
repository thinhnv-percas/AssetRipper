using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using Doozy.PlayMaker;
using Doozy.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x750D78", Offset = "0x750D78")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x750D78", Offset = "0x750D78")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x750D78", Offset = "0x750D78")]
	[Token(Token = "0x20000F2")]
	public class DOTweenTransformBlendableScaleBy : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x792DB4", Offset = "0x792DB4")]
		[Token(Token = "0x4000CEC")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x792E28", Offset = "0x792E28")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x792E28", Offset = "0x792E28")]
		[Token(Token = "0x4000CED")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 by;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x792E88", Offset = "0x792E88")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x792E88", Offset = "0x792E88")]
		[Token(Token = "0x4000CEE")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool setRelative;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x792ED8", Offset = "0x792ED8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x792ED8", Offset = "0x792ED8")]
		[Token(Token = "0x4000CEF")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x792F38", Offset = "0x792F38")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x792F38", Offset = "0x792F38")]
		[Token(Token = "0x4000CF0")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x792F88", Offset = "0x792F88")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x792F88", Offset = "0x792F88")]
		[Token(Token = "0x4000CF1")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x792FD8", Offset = "0x792FD8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x792FD8", Offset = "0x792FD8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x792FD8", Offset = "0x792FD8")]
		[Token(Token = "0x4000CF2")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79304C", Offset = "0x79304C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79304C", Offset = "0x79304C")]
		[Token(Token = "0x4000CF3")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79309C", Offset = "0x79309C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79309C", Offset = "0x79309C")]
		[Token(Token = "0x4000CF4")]
		[FieldOffset(Offset = "0x90")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7930EC", Offset = "0x7930EC")]
		[Token(Token = "0x4000CF5")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x793100", Offset = "0x793100")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x793100", Offset = "0x793100")]
		[Token(Token = "0x4000CF6")]
		[FieldOffset(Offset = "0xA0")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x793150", Offset = "0x793150")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x793150", Offset = "0x793150")]
		[Token(Token = "0x4000CF7")]
		[FieldOffset(Offset = "0xA8")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7931A0", Offset = "0x7931A0")]
		[Token(Token = "0x4000CF8")]
		[FieldOffset(Offset = "0xB0")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7931D8", Offset = "0x7931D8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7931D8", Offset = "0x7931D8")]
		[Token(Token = "0x4000CF9")]
		[FieldOffset(Offset = "0xB8")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x793228", Offset = "0x793228")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x793228", Offset = "0x793228")]
		[Token(Token = "0x4000CFA")]
		[FieldOffset(Offset = "0xC0")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x793278", Offset = "0x793278")]
		[Token(Token = "0x4000CFB")]
		[FieldOffset(Offset = "0xC8")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7932B0", Offset = "0x7932B0")]
		[Token(Token = "0x4000CFC")]
		[FieldOffset(Offset = "0xCC")]
		public Ease easeType;

		[Token(Token = "0x4000CFD")]
		[FieldOffset(Offset = "0xD0")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7932E8", Offset = "0x7932E8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7932E8", Offset = "0x7932E8")]
		[Token(Token = "0x4000CFE")]
		[FieldOffset(Offset = "0xD8")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x793338", Offset = "0x793338")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x793338", Offset = "0x793338")]
		[Token(Token = "0x4000CFF")]
		[FieldOffset(Offset = "0xE0")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x793388", Offset = "0x793388")]
		[Token(Token = "0x4000D00")]
		[FieldOffset(Offset = "0xE8")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7933C0", Offset = "0x7933C0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7933C0", Offset = "0x7933C0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7933C0", Offset = "0x7933C0")]
		[Token(Token = "0x4000D01")]
		[FieldOffset(Offset = "0xF0")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x793434", Offset = "0x793434")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x793434", Offset = "0x793434")]
		[Token(Token = "0x4000D02")]
		[FieldOffset(Offset = "0xF8")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x793484", Offset = "0x793484")]
		[Token(Token = "0x4000D03")]
		[FieldOffset(Offset = "0x100")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7934BC", Offset = "0x7934BC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7934BC", Offset = "0x7934BC")]
		[Token(Token = "0x4000D04")]
		[FieldOffset(Offset = "0x108")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79350C", Offset = "0x79350C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79350C", Offset = "0x79350C")]
		[Token(Token = "0x4000D05")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool debugThis;

		[Token(Token = "0x4000D06")]
		[FieldOffset(Offset = "0x118")]
		private Tweener tween;

		[Token(Token = "0x600058C")]
		[Address(RVA = "0xA77AB4", Offset = "0xA77AB4", Length = "0x29C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1ECF540]);\n\tv25 = *([v24 @ X8_v12]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202213D]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.by = v50;\n\tv57 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v57);\n\tv57.useVariable = 0;\n\tthis.duration = v57;\n\tv79 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v79);\n\tv79.useVariable = 0;\n\tv79.value = 0;\n\tthis.setSpeedBased = v79;\n\tv80 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v80);\n\tv80.useVariable = 0;\n\tv80.value = 0;\n\tthis.setRelative = v80;\n\tv81 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v81);\n\tv81.useVariable = 0;\n\tv81.value = 0;\n\tthis.playInReverse = v81;\n\tv82 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v82);\n\tv82.useVariable = 0;\n\tv82.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v82;\n\tv83 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v83);\n\tv83.useVariable = 0;\n\tv83.value = 0;\n\tthis.finishImmediately = v83;\n\tv84 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v84);\n\tv84.useVariable = 0;\n\tthis.stringAsId = v84;\n\tv85 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v85);\n\tv85.useVariable = 0;\n\tthis.tagAsId = v85;\n\tv86 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v86);\n\tv86.value = 0f;\n\tthis.startDelay = v86;\n\tthis.selectedEase = 0x100000000;\n\tv87 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v87);\n\tv87.value = 0;\n\tthis.loops = v87;\n\tthis.loopType = 0;\n\tv88 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v88);\n\tv88.value = 1;\n\tthis.autoKillOnCompletion = v88;\n\tv89 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v89);\n\tv89.value = 0;\n\tthis.recyclable = v89;\n\tthis.updateType = 0;\n\tv90 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v90);\n\tv90.value = 0;\n\tthis.isIndependentUpdate = v90;\n\tv91 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v91);\n\tv91.value = 0;\n\tthis.debugThis = v91;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_01df: Expected I4, but got I8
			base.Reset();
			gameObject = null;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = false;
			by = fsmVector;
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

		[Token(Token = "0x600058D")]
		[Address(RVA = "0xA77D50", Offset = "0xA77D50", Length = "0x3F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv30 = *([1EEF8B8]);\n\tv31 = *([v30 @ X8_v52]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([202213E]) = v50;\nL_001E:\n\tv55 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv196 = UnityEngine.GameObject::GetComponent(v55);\n\tv96 = HutongGames.PlayMaker.FsmVector3::get_Value(this.by);\n\tv258 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tv197 = DG.Tweening.ShortcutExtensions::DOBlendableScaleBy(v196, v96, v258);\n\tthis.tween = v197;\n\tv262 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv264 = v262 == 0;\n\tif (v264) goto L_0052;\n\tv269 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_0052:\n\tv272 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv275 = DG.Tweening.TweenSettingsExtensions::SetRelative(this.tween, v272);\n\tv278 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v278);\n\tv98 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv284 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v98);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv287 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv290 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v287, this.loopType);\n\tv292 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv295 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v292);\n\tv297 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv300 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v297);\n\tv302 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv305 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v302);\n\tv306 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv308 = v306 == 0;\n\tif (v308) goto L_00C3;\n\tv323 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv314 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v323);\nL_00C3:\n\tv321 = this.startEvent == 0;\n\tif (v321) goto L_00DB;\n\tv328 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v328, this, Il2CppMethodInfo);\n\tv334 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v328);\nL_00DB:\n\tv343 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv347 = v343 == 0;\n\tv348 = ~v347;\n\tif (v348) goto L_00FD;\n\tv354 = new DG.Tweening.TweenCallback();\n\tv363 = this.finishEvent == 0;\n\tif (v363) goto L_FFFFFFFF;\n\tgoto L_00F2;\nL_00F2:\n\tDG.Tweening.TweenCallback::.ctor(v354, this, *([v375 @ X8_v33 (Il2CppMethodInfo)]));\n\tv361 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v354);\nL_00FD:\n\tv368 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv374 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv380 = v374 == 0;\n\tif (v380) goto L_0110;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Transform Blendable Scale By\");\nL_0110:\n\tv243 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv245 = v243 == 0;\n\tif (v245) goto L_012E;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_012E:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 242 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			Transform component = ownerDefaultTarget.GetComponent<Transform>();
			Vector3 value = by.Value;
			float value2 = duration.Value;
			Tweener tweener = component.DOBlendableScaleBy(value, value2);
			tween = tweener;
			if (setSpeedBased.Value)
			{
				Tweener tweener2 = tween.SetSpeedBased();
			}
			bool value3 = setRelative.Value;
			Tweener tweener3 = tween.SetRelative(value3);
			GameObject ownerDefaultTarget2 = Fsm.GetOwnerDefaultTarget(gameObject);
			tween.SetTweenId(tweenIdType, stringAsId, tagAsId, ownerDefaultTarget2);
			float value4 = startDelay.Value;
			Tweener tweener4 = tween.SetDelay(value4);
			tween.SetSelectedEase(selectedEase, easeType, animationCurve);
			int value5 = loops.Value;
			Tweener tweener5 = tween.SetLoops(value5, loopType);
			bool value6 = autoKillOnCompletion.Value;
			Tweener tweener6 = tween.SetAutoKill(value6);
			bool value7 = recyclable.Value;
			Tweener tweener7 = tween.SetRecyclable(value7);
			bool value8 = isIndependentUpdate.Value;
			Tweener tweener8 = tween.SetUpdate(updateType, value8);
			if (playInReverse.Value)
			{
				bool value9 = setReverseRelative.Value;
				Tweener tweener9 = tween.From(value9);
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
				State.Debug("DOTween Transform Blendable Scale By");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x600058E")]
		[Address(RVA = "0xA78140", Offset = "0xA78140", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EC4A28]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202213F]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenTransformBlendableScaleBy()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
