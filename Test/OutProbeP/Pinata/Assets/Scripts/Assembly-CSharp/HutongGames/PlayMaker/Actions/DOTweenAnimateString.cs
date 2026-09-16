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
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74D43C", Offset = "0x74D43C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x74D43C", Offset = "0x74D43C")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x74D43C", Offset = "0x74D43C")]
	[Token(Token = "0x2000083")]
	public class DOTweenAnimateString : FsmStateAction
	{
		[RequiredField]
		[Token(Token = "0x4000340")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x766D10", Offset = "0x766D10")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x766D10", Offset = "0x766D10")]
		[Token(Token = "0x4000341")]
		[FieldOffset(Offset = "0x58")]
		public FsmString variable;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x766D70", Offset = "0x766D70")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x766D70", Offset = "0x766D70")]
		[Token(Token = "0x4000342")]
		[FieldOffset(Offset = "0x60")]
		public FsmString to;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x766DD0", Offset = "0x766DD0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x766DD0", Offset = "0x766DD0")]
		[Token(Token = "0x4000343")]
		[FieldOffset(Offset = "0x68")]
		public FsmBool setRelative;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x766E20", Offset = "0x766E20")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x766E20", Offset = "0x766E20")]
		[Token(Token = "0x4000344")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x766E80", Offset = "0x766E80")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x766E80", Offset = "0x766E80")]
		[Token(Token = "0x4000345")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x766ED0", Offset = "0x766ED0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x766ED0", Offset = "0x766ED0")]
		[Token(Token = "0x4000346")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x766F20", Offset = "0x766F20")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x766F20", Offset = "0x766F20")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x766F20", Offset = "0x766F20")]
		[Token(Token = "0x4000347")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x766F94", Offset = "0x766F94")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x766F94", Offset = "0x766F94")]
		[Token(Token = "0x4000348")]
		[FieldOffset(Offset = "0x90")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x766FE4", Offset = "0x766FE4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x766FE4", Offset = "0x766FE4")]
		[Token(Token = "0x4000349")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x767034", Offset = "0x767034")]
		[Token(Token = "0x400034A")]
		[FieldOffset(Offset = "0xA0")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x767048", Offset = "0x767048")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x767048", Offset = "0x767048")]
		[Token(Token = "0x400034B")]
		[FieldOffset(Offset = "0xA8")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x767098", Offset = "0x767098")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x767098", Offset = "0x767098")]
		[Token(Token = "0x400034C")]
		[FieldOffset(Offset = "0xB0")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7670E8", Offset = "0x7670E8")]
		[Token(Token = "0x400034D")]
		[FieldOffset(Offset = "0xB8")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x767120", Offset = "0x767120")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x767120", Offset = "0x767120")]
		[Token(Token = "0x400034E")]
		[FieldOffset(Offset = "0xC0")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x767170", Offset = "0x767170")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x767170", Offset = "0x767170")]
		[Token(Token = "0x400034F")]
		[FieldOffset(Offset = "0xC8")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7671C0", Offset = "0x7671C0")]
		[Token(Token = "0x4000350")]
		[FieldOffset(Offset = "0xD0")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7671F8", Offset = "0x7671F8")]
		[Token(Token = "0x4000351")]
		[FieldOffset(Offset = "0xD4")]
		public Ease easeType;

		[Token(Token = "0x4000352")]
		[FieldOffset(Offset = "0xD8")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x767230", Offset = "0x767230")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x767230", Offset = "0x767230")]
		[Token(Token = "0x4000353")]
		[FieldOffset(Offset = "0xE0")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x767280", Offset = "0x767280")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x767280", Offset = "0x767280")]
		[Token(Token = "0x4000354")]
		[FieldOffset(Offset = "0xE8")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7672D0", Offset = "0x7672D0")]
		[Token(Token = "0x4000355")]
		[FieldOffset(Offset = "0xF0")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x767308", Offset = "0x767308")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x767308", Offset = "0x767308")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x767308", Offset = "0x767308")]
		[Token(Token = "0x4000356")]
		[FieldOffset(Offset = "0xF8")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x76737C", Offset = "0x76737C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x76737C", Offset = "0x76737C")]
		[Token(Token = "0x4000357")]
		[FieldOffset(Offset = "0x100")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7673CC", Offset = "0x7673CC")]
		[Token(Token = "0x4000358")]
		[FieldOffset(Offset = "0x108")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x767404", Offset = "0x767404")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x767404", Offset = "0x767404")]
		[Token(Token = "0x4000359")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x767454", Offset = "0x767454")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x767454", Offset = "0x767454")]
		[Token(Token = "0x400035A")]
		[FieldOffset(Offset = "0x118")]
		public FsmBool debugThis;

		[Token(Token = "0x400035B")]
		[FieldOffset(Offset = "0x120")]
		private Tweener tween;

		[Token(Token = "0x600038D")]
		[Address(RVA = "0xA98C9C", Offset = "0xA98C9C", Length = "0x2B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EC89A8]);\n\tv25 = *([v24 @ X8_v11]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022227]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v50);\n\tv50.useVariable = 1;\n\tthis.variable = v50;\n\tv56 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v56);\n\tv56.useVariable = 0;\n\tthis.to = v56;\n\tv78 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v78);\n\tv78.useVariable = 0;\n\tthis.duration = v78;\n\tv79 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v79);\n\tv79.useVariable = 0;\n\tv79.value = 0;\n\tthis.setSpeedBased = v79;\n\tv80 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v80);\n\tv80.useVariable = 0;\n\tv80.value = 0;\n\tthis.setRelative = v80;\n\tv81 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v81);\n\tv81.useVariable = 0;\n\tv81.value = 0;\n\tthis.playInReverse = v81;\n\tv82 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v82);\n\tv82.useVariable = 0;\n\tv82.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v82;\n\tv83 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v83);\n\tv83.useVariable = 0;\n\tv83.value = 0;\n\tthis.finishImmediately = v83;\n\tv84 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v84);\n\tv84.useVariable = 0;\n\tthis.stringAsId = v84;\n\tv85 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v85);\n\tv85.useVariable = 0;\n\tthis.tagAsId = v85;\n\tv86 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v86);\n\tv86.value = 0f;\n\tthis.startDelay = v86;\n\tthis.selectedEase = 0x100000000;\n\tv87 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v87);\n\tv87.value = 0;\n\tthis.loops = v87;\n\tthis.loopType = 0;\n\tv88 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v88);\n\tv88.value = 1;\n\tthis.autoKillOnCompletion = v88;\n\tv89 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v89);\n\tv89.value = 0;\n\tthis.recyclable = v89;\n\tthis.updateType = 0;\n\tv90 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v90);\n\tv90.value = 0;\n\tthis.isIndependentUpdate = v90;\n\tv91 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v91);\n\tv91.value = 0;\n\tthis.debugThis = v91;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 118 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_0206: Expected I4, but got I8
			base.Reset();
			gameObject = null;
			FsmString fsmString = new FsmString();
			fsmString.useVariable = true;
			variable = fsmString;
			FsmString fsmString2 = new FsmString();
			fsmString2.useVariable = false;
			to = fsmString2;
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
			FsmString fsmString3 = new FsmString();
			fsmString3.useVariable = false;
			stringAsId = fsmString3;
			FsmString fsmString4 = new FsmString();
			fsmString4.useVariable = false;
			tagAsId = fsmString4;
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

		[Token(Token = "0x600038E")]
		[Address(RVA = "0xA98F54", Offset = "0xA98F54", Length = "0x438")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EDE740]);\n\tv27 = *([v26 @ X8_v63]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2022228]) = v46;\nL_001A:\n\tv50 = new DG.Tweening.Core.DOGetter`1<System.String>();\n\tDG.Tweening.Core.DOGetter`1<System.String>::.ctor(v50, this, Il2CppMethodInfo);\n\tv62 = new DG.Tweening.Core.DOSetter`1<System.String>();\n\tDG.Tweening.Core.DOSetter`1<System.String>::.ctor(v62, this, Il2CppMethodInfo);\n\tv74 = HutongGames.PlayMaker.FsmString::get_Value(this.to);\n\tv201 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tgoto L_004F;\n\tv246 = *([v204 @ X0_v14+E0]);\n\tv247 = v246 == 0;\n\tv248 = ~v247;\n\tif (v248) goto L_004F;\n\tv250 = \"il2cpp_codegen_runtime_class_init\"(v204, v200, v69, v70, v32, v33, v34, v35, v201, v37, v38, v39, v40, v41, v42, v43);\nL_004F:\n\tv191 = DG.Tweening.DOTween::To(v50, v62, v74, v201);\n\tthis.tween = v191;\n\tv256 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv258 = v256 == 0;\n\tif (v258) goto L_0064;\n\tv263 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_0064:\n\tv266 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv269 = DG.Tweening.TweenSettingsExtensions::SetRelative(this.tween, v266);\n\tv272 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v272);\n\tv86 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv278 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v86);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv281 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv284 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v281, this.loopType);\n\tv286 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv289 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v286);\n\tv291 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv294 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v291);\n\tv296 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv299 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v296);\n\tv300 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv302 = v300 == 0;\n\tif (v302) goto L_00D5;\n\tv317 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv308 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v317);\nL_00D5:\n\tv315 = this.startEvent == 0;\n\tif (v315) goto L_00ED;\n\tv322 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v322, this, Il2CppMethodInfo);\n\tv328 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v322);\nL_00ED:\n\tv337 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv341 = v337 == 0;\n\tv342 = ~v341;\n\tif (v342) goto L_010F;\n\tv348 = new DG.Tweening.TweenCallback();\n\tv357 = this.finishEvent == 0;\n\tif (v357) goto L_FFFFFFFF;\n\tgoto L_0104;\nL_0104:\n\tDG.Tweening.TweenCallback::.ctor(v348, this, *([v369 @ X8_v43 (Il2CppMethodInfo)]));\n\tv355 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v348);\nL_010F:\n\tv362 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv368 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv374 = v368 == 0;\n\tif (v374) goto L_0122;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Animate String\");\nL_0122:\n\tv233 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv235 = v233 == 0;\n\tif (v235) goto L_013C;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_013C:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 248 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DOGetter<string> getter = () => variable.Value;
			DOSetter<string> setter = delegate(string x)
			{
				FsmString fsmString = variable;
				fsmString.Value = x;
			};
			string value = to.Value;
			float value2 = duration.Value;
			TweenerCore<string, string, StringOptions> tweenerCore = DOTween.To(getter, setter, value, value2);
			tween = tweenerCore;
			if (setSpeedBased.Value)
			{
				Tweener tweener = tween.SetSpeedBased();
			}
			bool value3 = setRelative.Value;
			Tweener tweener2 = tween.SetRelative(value3);
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			tween.SetTweenId(tweenIdType, stringAsId, tagAsId, ownerDefaultTarget);
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
				State.Debug("DOTween Animate String");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x600038F")]
		[Address(RVA = "0xA9938C", Offset = "0xA9938C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ECD5C8]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022229]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenAnimateString()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
