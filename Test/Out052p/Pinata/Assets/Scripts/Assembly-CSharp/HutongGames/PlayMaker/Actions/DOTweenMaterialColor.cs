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
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74F11C", Offset = "0x74F11C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x74F11C", Offset = "0x74F11C")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x74F11C", Offset = "0x74F11C")]
	[Token(Token = "0x20000BB")]
	public class DOTweenMaterialColor : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x77778C", Offset = "0x77778C")]
		[Token(Token = "0x40006EB")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x777800", Offset = "0x777800")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x777800", Offset = "0x777800")]
		[Token(Token = "0x40006EC")]
		[FieldOffset(Offset = "0x58")]
		public FsmColor to;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x777860", Offset = "0x777860")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x777860", Offset = "0x777860")]
		[Token(Token = "0x40006ED")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool setRelative;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7778B0", Offset = "0x7778B0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7778B0", Offset = "0x7778B0")]
		[Token(Token = "0x40006EE")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x777910", Offset = "0x777910")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x777910", Offset = "0x777910")]
		[Token(Token = "0x40006EF")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x777960", Offset = "0x777960")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x777960", Offset = "0x777960")]
		[Token(Token = "0x40006F0")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7779B0", Offset = "0x7779B0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7779B0", Offset = "0x7779B0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7779B0", Offset = "0x7779B0")]
		[Token(Token = "0x40006F1")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x777A24", Offset = "0x777A24")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x777A24", Offset = "0x777A24")]
		[Token(Token = "0x40006F2")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x777A74", Offset = "0x777A74")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x777A74", Offset = "0x777A74")]
		[Token(Token = "0x40006F3")]
		[FieldOffset(Offset = "0x90")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x777AC4", Offset = "0x777AC4")]
		[Token(Token = "0x40006F4")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x777AD8", Offset = "0x777AD8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x777AD8", Offset = "0x777AD8")]
		[Token(Token = "0x40006F5")]
		[FieldOffset(Offset = "0xA0")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x777B28", Offset = "0x777B28")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x777B28", Offset = "0x777B28")]
		[Token(Token = "0x40006F6")]
		[FieldOffset(Offset = "0xA8")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x777B78", Offset = "0x777B78")]
		[Token(Token = "0x40006F7")]
		[FieldOffset(Offset = "0xB0")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x777BB0", Offset = "0x777BB0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x777BB0", Offset = "0x777BB0")]
		[Token(Token = "0x40006F8")]
		[FieldOffset(Offset = "0xB8")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x777C00", Offset = "0x777C00")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x777C00", Offset = "0x777C00")]
		[Token(Token = "0x40006F9")]
		[FieldOffset(Offset = "0xC0")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x777C50", Offset = "0x777C50")]
		[Token(Token = "0x40006FA")]
		[FieldOffset(Offset = "0xC8")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x777C88", Offset = "0x777C88")]
		[Token(Token = "0x40006FB")]
		[FieldOffset(Offset = "0xCC")]
		public Ease easeType;

		[Token(Token = "0x40006FC")]
		[FieldOffset(Offset = "0xD0")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x777CC0", Offset = "0x777CC0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x777CC0", Offset = "0x777CC0")]
		[Token(Token = "0x40006FD")]
		[FieldOffset(Offset = "0xD8")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x777D10", Offset = "0x777D10")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x777D10", Offset = "0x777D10")]
		[Token(Token = "0x40006FE")]
		[FieldOffset(Offset = "0xE0")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x777D60", Offset = "0x777D60")]
		[Token(Token = "0x40006FF")]
		[FieldOffset(Offset = "0xE8")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x777D98", Offset = "0x777D98")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x777D98", Offset = "0x777D98")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x777D98", Offset = "0x777D98")]
		[Token(Token = "0x4000700")]
		[FieldOffset(Offset = "0xF0")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x777E0C", Offset = "0x777E0C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x777E0C", Offset = "0x777E0C")]
		[Token(Token = "0x4000701")]
		[FieldOffset(Offset = "0xF8")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x777E5C", Offset = "0x777E5C")]
		[Token(Token = "0x4000702")]
		[FieldOffset(Offset = "0x100")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x777E94", Offset = "0x777E94")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x777E94", Offset = "0x777E94")]
		[Token(Token = "0x4000703")]
		[FieldOffset(Offset = "0x108")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x777EE4", Offset = "0x777EE4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x777EE4", Offset = "0x777EE4")]
		[Token(Token = "0x4000704")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool debugThis;

		[Token(Token = "0x4000705")]
		[FieldOffset(Offset = "0x118")]
		private Tweener tween;

		[Token(Token = "0x6000479")]
		[Address(RVA = "0xAFA268", Offset = "0xAFA268", Length = "0x29C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EB9A00]);\n\tv25 = *([v24 @ X8_v12]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022489]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmColor();\n\tHutongGames.PlayMaker.FsmColor::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.to = v50;\n\tv57 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v57);\n\tv57.useVariable = 0;\n\tthis.duration = v57;\n\tv79 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v79);\n\tv79.useVariable = 0;\n\tv79.value = 0;\n\tthis.setSpeedBased = v79;\n\tv80 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v80);\n\tv80.useVariable = 0;\n\tv80.value = 0;\n\tthis.setRelative = v80;\n\tv81 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v81);\n\tv81.useVariable = 0;\n\tv81.value = 0;\n\tthis.playInReverse = v81;\n\tv82 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v82);\n\tv82.useVariable = 0;\n\tv82.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v82;\n\tv83 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v83);\n\tv83.useVariable = 0;\n\tv83.value = 0;\n\tthis.finishImmediately = v83;\n\tv84 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v84);\n\tv84.useVariable = 0;\n\tthis.stringAsId = v84;\n\tv85 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v85);\n\tv85.useVariable = 0;\n\tthis.tagAsId = v85;\n\tv86 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v86);\n\tv86.value = 0f;\n\tthis.startDelay = v86;\n\tthis.selectedEase = 0x100000000;\n\tv87 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v87);\n\tv87.value = 0;\n\tthis.loops = v87;\n\tthis.loopType = 0;\n\tv88 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v88);\n\tv88.value = 1;\n\tthis.autoKillOnCompletion = v88;\n\tv89 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v89);\n\tv89.value = 0;\n\tthis.recyclable = v89;\n\tthis.updateType = 0;\n\tv90 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v90);\n\tv90.value = 0;\n\tthis.isIndependentUpdate = v90;\n\tv91 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v91);\n\tv91.value = 0;\n\tthis.debugThis = v91;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x600047A")]
		[Address(RVA = "0xAFA504", Offset = "0xAFA504", Length = "0x3F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv32 = *([1EEE250]);\n\tv33 = *([v32 @ X8_v52]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([202248A]) = v52;\nL_001F:\n\tv57 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv129 = UnityEngine.GameObject::GetComponent(v57);\n\tv204 = UnityEngine.Renderer::get_material(v129);\n\tv161 = this.to;\n\tv268 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\t// 62 MakeStruct v82 @ AGGAFA5BC_1_v3 (UnityEngine.Color), typeof(UnityEngine.Color), v161.value (UnityEngine.Color), v161.value.g (System.Single), v161.value.b (System.Single), v161.value.a (System.Single)\n\tv205 = DG.Tweening.ShortcutExtensions::DOColor(v204, v82, v268);\n\tthis.tween = v205;\n\tv272 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv274 = v272 == 0;\n\tif (v274) goto L_0054;\n\tv279 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_0054:\n\tv282 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv285 = DG.Tweening.TweenSettingsExtensions::SetRelative(this.tween, v282);\n\tv288 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v288);\n\tv93 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv294 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v93);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv297 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv300 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v297, this.loopType);\n\tv302 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv305 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v302);\n\tv307 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv310 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v307);\n\tv312 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv315 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v312);\n\tv316 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv318 = v316 == 0;\n\tif (v318) goto L_00C5;\n\tv333 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv324 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v333);\nL_00C5:\n\tv331 = this.startEvent == 0;\n\tif (v331) goto L_00DD;\n\tv338 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v338, this, Il2CppMethodInfo);\n\tv344 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v338);\nL_00DD:\n\tv353 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv357 = v353 == 0;\n\tv358 = ~v357;\n\tif (v358) goto L_00FF;\n\tv364 = new DG.Tweening.TweenCallback();\n\tv373 = this.finishEvent == 0;\n\tif (v373) goto L_FFFFFFFF;\n\tgoto L_00F4;\nL_00F4:\n\tDG.Tweening.TweenCallback::.ctor(v364, this, *([v385 @ X8_v33 (Il2CppMethodInfo)]));\n\tv371 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v364);\nL_00FF:\n\tv378 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv384 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv390 = v384 == 0;\n\tif (v390) goto L_0112;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Material Color\");\nL_0112:\n\tv254 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv256 = v254 == 0;\n\tif (v256) goto L_0132;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0132:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 244 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			Renderer component = ownerDefaultTarget.GetComponent<Renderer>();
			Material material = component.material;
			FsmColor fsmColor = to;
			float value = duration.Value;
			Color endValue = default(Color);
			endValue.r = fsmColor.value.r;
			endValue.g = fsmColor.value.g;
			endValue.b = fsmColor.value.b;
			endValue.a = fsmColor.value.a;
			TweenerCore<Color, Color, ColorOptions> tweenerCore = material.DOColor(endValue, value);
			tween = tweenerCore;
			if (setSpeedBased.Value)
			{
				Tweener tweener = tween.SetSpeedBased();
			}
			bool value2 = setRelative.Value;
			Tweener tweener2 = tween.SetRelative(value2);
			GameObject ownerDefaultTarget2 = Fsm.GetOwnerDefaultTarget(gameObject);
			tween.SetTweenId(tweenIdType, stringAsId, tagAsId, ownerDefaultTarget2);
			float value3 = startDelay.Value;
			Tweener tweener3 = tween.SetDelay(value3);
			tween.SetSelectedEase(selectedEase, easeType, animationCurve);
			int value4 = loops.Value;
			Tweener tweener4 = tween.SetLoops(value4, loopType);
			bool value5 = autoKillOnCompletion.Value;
			Tweener tweener5 = tween.SetAutoKill(value5);
			bool value6 = recyclable.Value;
			Tweener tweener6 = tween.SetRecyclable(value6);
			bool value7 = isIndependentUpdate.Value;
			Tweener tweener7 = tween.SetUpdate(updateType, value7);
			if (playInReverse.Value)
			{
				bool value8 = setReverseRelative.Value;
				Tweener tweener8 = tween.From(value8);
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
				State.Debug("DOTween Material Color");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x600047B")]
		[Address(RVA = "0xAFA8F4", Offset = "0xAFA8F4", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EBB790]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202248B]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenMaterialColor()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
