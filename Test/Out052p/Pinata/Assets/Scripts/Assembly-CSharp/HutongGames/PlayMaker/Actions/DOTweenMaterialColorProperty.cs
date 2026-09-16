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
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74F1A0", Offset = "0x74F1A0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x74F1A0", Offset = "0x74F1A0")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x74F1A0", Offset = "0x74F1A0")]
	[Token(Token = "0x20000BC")]
	public class DOTweenMaterialColorProperty : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x777F34", Offset = "0x777F34")]
		[Token(Token = "0x4000706")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x777FA8", Offset = "0x777FA8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x777FA8", Offset = "0x777FA8")]
		[Token(Token = "0x4000707")]
		[FieldOffset(Offset = "0x58")]
		public FsmColor to;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x778008", Offset = "0x778008")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x778008", Offset = "0x778008")]
		[Token(Token = "0x4000708")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool setRelative;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x778058", Offset = "0x778058")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x778058", Offset = "0x778058")]
		[Token(Token = "0x4000709")]
		[FieldOffset(Offset = "0x68")]
		public FsmString property;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7780B8", Offset = "0x7780B8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7780B8", Offset = "0x7780B8")]
		[Token(Token = "0x400070A")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x778118", Offset = "0x778118")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x778118", Offset = "0x778118")]
		[Token(Token = "0x400070B")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x778168", Offset = "0x778168")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x778168", Offset = "0x778168")]
		[Token(Token = "0x400070C")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7781B8", Offset = "0x7781B8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7781B8", Offset = "0x7781B8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7781B8", Offset = "0x7781B8")]
		[Token(Token = "0x400070D")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77822C", Offset = "0x77822C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77822C", Offset = "0x77822C")]
		[Token(Token = "0x400070E")]
		[FieldOffset(Offset = "0x90")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77827C", Offset = "0x77827C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77827C", Offset = "0x77827C")]
		[Token(Token = "0x400070F")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7782CC", Offset = "0x7782CC")]
		[Token(Token = "0x4000710")]
		[FieldOffset(Offset = "0xA0")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7782E0", Offset = "0x7782E0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7782E0", Offset = "0x7782E0")]
		[Token(Token = "0x4000711")]
		[FieldOffset(Offset = "0xA8")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x778330", Offset = "0x778330")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x778330", Offset = "0x778330")]
		[Token(Token = "0x4000712")]
		[FieldOffset(Offset = "0xB0")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x778380", Offset = "0x778380")]
		[Token(Token = "0x4000713")]
		[FieldOffset(Offset = "0xB8")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7783B8", Offset = "0x7783B8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7783B8", Offset = "0x7783B8")]
		[Token(Token = "0x4000714")]
		[FieldOffset(Offset = "0xC0")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x778408", Offset = "0x778408")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x778408", Offset = "0x778408")]
		[Token(Token = "0x4000715")]
		[FieldOffset(Offset = "0xC8")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x778458", Offset = "0x778458")]
		[Token(Token = "0x4000716")]
		[FieldOffset(Offset = "0xD0")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x778490", Offset = "0x778490")]
		[Token(Token = "0x4000717")]
		[FieldOffset(Offset = "0xD4")]
		public Ease easeType;

		[Token(Token = "0x4000718")]
		[FieldOffset(Offset = "0xD8")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7784C8", Offset = "0x7784C8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7784C8", Offset = "0x7784C8")]
		[Token(Token = "0x4000719")]
		[FieldOffset(Offset = "0xE0")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x778518", Offset = "0x778518")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x778518", Offset = "0x778518")]
		[Token(Token = "0x400071A")]
		[FieldOffset(Offset = "0xE8")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x778568", Offset = "0x778568")]
		[Token(Token = "0x400071B")]
		[FieldOffset(Offset = "0xF0")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7785A0", Offset = "0x7785A0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7785A0", Offset = "0x7785A0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7785A0", Offset = "0x7785A0")]
		[Token(Token = "0x400071C")]
		[FieldOffset(Offset = "0xF8")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x778614", Offset = "0x778614")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x778614", Offset = "0x778614")]
		[Token(Token = "0x400071D")]
		[FieldOffset(Offset = "0x100")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x778664", Offset = "0x778664")]
		[Token(Token = "0x400071E")]
		[FieldOffset(Offset = "0x108")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77869C", Offset = "0x77869C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77869C", Offset = "0x77869C")]
		[Token(Token = "0x400071F")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7786EC", Offset = "0x7786EC")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7786EC", Offset = "0x7786EC")]
		[Token(Token = "0x4000720")]
		[FieldOffset(Offset = "0x118")]
		public FsmBool debugThis;

		[Token(Token = "0x4000721")]
		[FieldOffset(Offset = "0x120")]
		private Tweener tween;

		[Token(Token = "0x600047E")]
		[Address(RVA = "0xAFA9A4", Offset = "0xAFA9A4", Length = "0x2BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EE35B0]);\n\tv25 = *([v24 @ X8_v12]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202248C]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmColor();\n\tHutongGames.PlayMaker.FsmColor::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.to = v50;\n\tv57 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v57);\n\tv57.useVariable = 0;\n\tthis.property = v57;\n\tv80 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v80);\n\tv80.useVariable = 0;\n\tthis.duration = v80;\n\tv81 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v81);\n\tv81.useVariable = 0;\n\tv81.value = 0;\n\tthis.setSpeedBased = v81;\n\tv82 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v82);\n\tv82.useVariable = 0;\n\tv82.value = 0;\n\tthis.setRelative = v82;\n\tv83 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v83);\n\tv83.useVariable = 0;\n\tv83.value = 0;\n\tthis.playInReverse = v83;\n\tv84 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v84);\n\tv84.useVariable = 0;\n\tv84.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v84;\n\tv85 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v85);\n\tv85.useVariable = 0;\n\tv85.value = 0;\n\tthis.finishImmediately = v85;\n\tv86 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v86);\n\tv86.useVariable = 0;\n\tthis.stringAsId = v86;\n\tv87 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v87);\n\tv87.useVariable = 0;\n\tthis.tagAsId = v87;\n\tv88 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v88);\n\tv88.value = 0f;\n\tthis.startDelay = v88;\n\tthis.selectedEase = 0x100000000;\n\tv89 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v89);\n\tv89.value = 0;\n\tthis.loops = v89;\n\tthis.loopType = 0;\n\tv90 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v90);\n\tv90.value = 1;\n\tthis.autoKillOnCompletion = v90;\n\tv91 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v91);\n\tv91.value = 0;\n\tthis.recyclable = v91;\n\tthis.updateType = 0;\n\tv92 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v92);\n\tv92.value = 0;\n\tthis.isIndependentUpdate = v92;\n\tv93 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v93);\n\tv93.value = 0;\n\tthis.debugThis = v93;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 119 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_0206: Expected I4, but got I8
			base.Reset();
			gameObject = null;
			FsmColor fsmColor = new FsmColor();
			fsmColor.useVariable = false;
			to = fsmColor;
			FsmString fsmString = new FsmString();
			fsmString.useVariable = false;
			property = fsmString;
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
			FsmString fsmString2 = new FsmString();
			fsmString2.useVariable = false;
			stringAsId = fsmString2;
			FsmString fsmString3 = new FsmString();
			fsmString3.useVariable = false;
			tagAsId = fsmString3;
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

		[Token(Token = "0x600047F")]
		[Address(RVA = "0xAFAC60", Offset = "0xAFAC60", Length = "0x40C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv32 = *([1F0D4C8]);\n\tv33 = *([v32 @ X8_v53]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([202248D]) = v52;\nL_001F:\n\tv57 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv131 = UnityEngine.GameObject::GetComponent(v57);\n\tv207 = UnityEngine.Renderer::get_material(v131);\n\tv163 = this.to;\n\tv208 = HutongGames.PlayMaker.FsmString::get_Value(this.property);\n\tv275 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\t// 70 MakeStruct v77 @ AGGAFAD34_1_v3 (UnityEngine.Color), typeof(UnityEngine.Color), v163.value (UnityEngine.Color), v163.value.g (System.Single), v163.value.b (System.Single), v163.value.a (System.Single)\n\tv209 = DG.Tweening.ShortcutExtensions::DOColor(v207, v77, v208, v275);\n\tthis.tween = v209;\n\tv279 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv281 = v279 == 0;\n\tif (v281) goto L_005C;\n\tv286 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_005C:\n\tv289 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv292 = DG.Tweening.TweenSettingsExtensions::SetRelative(this.tween, v289);\n\tv295 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v295);\n\tv88 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv301 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v88);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv304 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv307 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v304, this.loopType);\n\tv309 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv312 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v309);\n\tv314 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv317 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v314);\n\tv319 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv322 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v319);\n\tv323 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv325 = v323 == 0;\n\tif (v325) goto L_00CD;\n\tv340 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv331 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v340);\nL_00CD:\n\tv338 = this.startEvent == 0;\n\tif (v338) goto L_00E5;\n\tv345 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v345, this, Il2CppMethodInfo);\n\tv351 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v345);\nL_00E5:\n\tv360 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv364 = v360 == 0;\n\tv365 = ~v364;\n\tif (v365) goto L_0107;\n\tv371 = new DG.Tweening.TweenCallback();\n\tv380 = this.finishEvent == 0;\n\tif (v380) goto L_FFFFFFFF;\n\tgoto L_00FC;\nL_00FC:\n\tDG.Tweening.TweenCallback::.ctor(v371, this, *([v392 @ X8_v34 (Il2CppMethodInfo)]));\n\tv378 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v371);\nL_0107:\n\tv385 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv391 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv397 = v391 == 0;\n\tif (v397) goto L_011A;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Material Color Property\");\nL_011A:\n\tv260 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv262 = v260 == 0;\n\tif (v262) goto L_013A;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_013A:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 251 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			Renderer component = ownerDefaultTarget.GetComponent<Renderer>();
			Material material = component.material;
			FsmColor fsmColor = to;
			string value = property.Value;
			float value2 = duration.Value;
			Color endValue = default(Color);
			endValue.r = fsmColor.value.r;
			endValue.g = fsmColor.value.g;
			endValue.b = fsmColor.value.b;
			endValue.a = fsmColor.value.a;
			TweenerCore<Color, Color, ColorOptions> tweenerCore = material.DOColor(endValue, value, value2);
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
				State.Debug("DOTween Material Color Property");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000480")]
		[Address(RVA = "0xAFB06C", Offset = "0xAFB06C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EFE678]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202248E]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenMaterialColorProperty()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
