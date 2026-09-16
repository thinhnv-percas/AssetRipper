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
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74F434", Offset = "0x74F434")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x74F434", Offset = "0x74F434")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x74F434", Offset = "0x74F434")]
	[Token(Token = "0x20000C1")]
	public class DOTweenMaterialOffsetProperty : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x77A69C", Offset = "0x77A69C")]
		[Token(Token = "0x4000790")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77A710", Offset = "0x77A710")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77A710", Offset = "0x77A710")]
		[Token(Token = "0x4000791")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector2 to;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77A770", Offset = "0x77A770")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77A770", Offset = "0x77A770")]
		[Token(Token = "0x4000792")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool setRelative;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77A7C0", Offset = "0x77A7C0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77A7C0", Offset = "0x77A7C0")]
		[Token(Token = "0x4000793")]
		[FieldOffset(Offset = "0x68")]
		public FsmString property;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77A820", Offset = "0x77A820")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77A820", Offset = "0x77A820")]
		[Token(Token = "0x4000794")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77A880", Offset = "0x77A880")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77A880", Offset = "0x77A880")]
		[Token(Token = "0x4000795")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77A8D0", Offset = "0x77A8D0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77A8D0", Offset = "0x77A8D0")]
		[Token(Token = "0x4000796")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77A920", Offset = "0x77A920")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77A920", Offset = "0x77A920")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77A920", Offset = "0x77A920")]
		[Token(Token = "0x4000797")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77A994", Offset = "0x77A994")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77A994", Offset = "0x77A994")]
		[Token(Token = "0x4000798")]
		[FieldOffset(Offset = "0x90")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77A9E4", Offset = "0x77A9E4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77A9E4", Offset = "0x77A9E4")]
		[Token(Token = "0x4000799")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77AA34", Offset = "0x77AA34")]
		[Token(Token = "0x400079A")]
		[FieldOffset(Offset = "0xA0")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77AA48", Offset = "0x77AA48")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77AA48", Offset = "0x77AA48")]
		[Token(Token = "0x400079B")]
		[FieldOffset(Offset = "0xA8")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77AA98", Offset = "0x77AA98")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77AA98", Offset = "0x77AA98")]
		[Token(Token = "0x400079C")]
		[FieldOffset(Offset = "0xB0")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77AAE8", Offset = "0x77AAE8")]
		[Token(Token = "0x400079D")]
		[FieldOffset(Offset = "0xB8")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77AB20", Offset = "0x77AB20")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77AB20", Offset = "0x77AB20")]
		[Token(Token = "0x400079E")]
		[FieldOffset(Offset = "0xC0")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77AB70", Offset = "0x77AB70")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77AB70", Offset = "0x77AB70")]
		[Token(Token = "0x400079F")]
		[FieldOffset(Offset = "0xC8")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77ABC0", Offset = "0x77ABC0")]
		[Token(Token = "0x40007A0")]
		[FieldOffset(Offset = "0xD0")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77ABF8", Offset = "0x77ABF8")]
		[Token(Token = "0x40007A1")]
		[FieldOffset(Offset = "0xD4")]
		public Ease easeType;

		[Token(Token = "0x40007A2")]
		[FieldOffset(Offset = "0xD8")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77AC30", Offset = "0x77AC30")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77AC30", Offset = "0x77AC30")]
		[Token(Token = "0x40007A3")]
		[FieldOffset(Offset = "0xE0")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77AC80", Offset = "0x77AC80")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77AC80", Offset = "0x77AC80")]
		[Token(Token = "0x40007A4")]
		[FieldOffset(Offset = "0xE8")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77ACD0", Offset = "0x77ACD0")]
		[Token(Token = "0x40007A5")]
		[FieldOffset(Offset = "0xF0")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77AD08", Offset = "0x77AD08")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77AD08", Offset = "0x77AD08")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77AD08", Offset = "0x77AD08")]
		[Token(Token = "0x40007A6")]
		[FieldOffset(Offset = "0xF8")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77AD7C", Offset = "0x77AD7C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77AD7C", Offset = "0x77AD7C")]
		[Token(Token = "0x40007A7")]
		[FieldOffset(Offset = "0x100")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77ADCC", Offset = "0x77ADCC")]
		[Token(Token = "0x40007A8")]
		[FieldOffset(Offset = "0x108")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77AE04", Offset = "0x77AE04")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77AE04", Offset = "0x77AE04")]
		[Token(Token = "0x40007A9")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77AE54", Offset = "0x77AE54")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77AE54", Offset = "0x77AE54")]
		[Token(Token = "0x40007AA")]
		[FieldOffset(Offset = "0x118")]
		public FsmBool debugThis;

		[Token(Token = "0x40007AB")]
		[FieldOffset(Offset = "0x120")]
		private Tweener tween;

		[Token(Token = "0x6000497")]
		[Address(RVA = "0xAFCE24", Offset = "0xAFCE24", Length = "0x2BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EBE180]);\n\tv25 = *([v24 @ X8_v12]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202249B]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.FsmVector2::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.to = v50;\n\tv57 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v57);\n\tv57.useVariable = 0;\n\tthis.property = v57;\n\tv80 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v80);\n\tv80.useVariable = 0;\n\tthis.duration = v80;\n\tv81 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v81);\n\tv81.useVariable = 0;\n\tv81.value = 0;\n\tthis.setSpeedBased = v81;\n\tv82 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v82);\n\tv82.useVariable = 0;\n\tv82.value = 0;\n\tthis.setRelative = v82;\n\tv83 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v83);\n\tv83.useVariable = 0;\n\tv83.value = 0;\n\tthis.playInReverse = v83;\n\tv84 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v84);\n\tv84.useVariable = 0;\n\tv84.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v84;\n\tv85 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v85);\n\tv85.useVariable = 0;\n\tv85.value = 0;\n\tthis.finishImmediately = v85;\n\tv86 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v86);\n\tv86.useVariable = 0;\n\tthis.stringAsId = v86;\n\tv87 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v87);\n\tv87.useVariable = 0;\n\tthis.tagAsId = v87;\n\tv88 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v88);\n\tv88.value = 0f;\n\tthis.startDelay = v88;\n\tthis.selectedEase = 0x100000000;\n\tv89 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v89);\n\tv89.value = 0;\n\tthis.loops = v89;\n\tthis.loopType = 0;\n\tv90 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v90);\n\tv90.value = 1;\n\tthis.autoKillOnCompletion = v90;\n\tv91 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v91);\n\tv91.value = 0;\n\tthis.recyclable = v91;\n\tthis.updateType = 0;\n\tv92 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v92);\n\tv92.value = 0;\n\tthis.isIndependentUpdate = v92;\n\tv93 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v93);\n\tv93.value = 0;\n\tthis.debugThis = v93;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 119 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_0206: Expected I4, but got I8
			base.Reset();
			gameObject = null;
			FsmVector2 fsmVector = new FsmVector2();
			fsmVector.useVariable = false;
			to = fsmVector;
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

		[Token(Token = "0x6000498")]
		[Address(RVA = "0xAFD0E0", Offset = "0xAFD0E0", Length = "0x3F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv28 = *([1EECB18]);\n\tv29 = *([v28 @ X8_v53]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([202249C]) = v48;\nL_001D:\n\tv53 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv119 = UnityEngine.GameObject::GetComponent(v53);\n\tv191 = UnityEngine.Renderer::get_material(v119);\n\tv151 = this.to;\n\tv192 = HutongGames.PlayMaker.FsmString::get_Value(this.property);\n\tv251 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\t// 64 MakeStruct v73 @ AGGAFD1A4_1_v3 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v151.value (UnityEngine.Vector2), v151.value.y (System.Single)\n\tv193 = DG.Tweening.ShortcutExtensions::DOOffset(v191, v73, v192, v251);\n\tthis.tween = v193;\n\tv255 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv257 = v255 == 0;\n\tif (v257) goto L_0056;\n\tv262 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_0056:\n\tv265 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv268 = DG.Tweening.TweenSettingsExtensions::SetRelative(this.tween, v265);\n\tv271 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v271);\n\tv80 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv277 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v80);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv280 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv283 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v280, this.loopType);\n\tv285 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv288 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v285);\n\tv290 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv293 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v290);\n\tv295 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv298 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v295);\n\tv299 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv301 = v299 == 0;\n\tif (v301) goto L_00C7;\n\tv316 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv307 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v316);\nL_00C7:\n\tv314 = this.startEvent == 0;\n\tif (v314) goto L_00DF;\n\tv321 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v321, this, Il2CppMethodInfo);\n\tv327 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v321);\nL_00DF:\n\tv336 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv340 = v336 == 0;\n\tv341 = ~v340;\n\tif (v341) goto L_0101;\n\tv347 = new DG.Tweening.TweenCallback();\n\tv356 = this.finishEvent == 0;\n\tif (v356) goto L_FFFFFFFF;\n\tgoto L_00F6;\nL_00F6:\n\tDG.Tweening.TweenCallback::.ctor(v347, this, *([v368 @ X8_v34 (Il2CppMethodInfo)]));\n\tv354 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v347);\nL_0101:\n\tv361 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv367 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv373 = v367 == 0;\n\tif (v373) goto L_0114;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Material Offset\");\nL_0114:\n\tv236 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv238 = v236 == 0;\n\tif (v238) goto L_0130;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0130:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 241 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			Renderer component = ownerDefaultTarget.GetComponent<Renderer>();
			Material material = component.material;
			FsmVector2 fsmVector = to;
			string value = property.Value;
			float value2 = duration.Value;
			Vector2 endValue = default(Vector2);
			endValue.x = fsmVector.value.x;
			endValue.y = fsmVector.value.y;
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = material.DOOffset(endValue, value, value2);
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
				State.Debug("DOTween Material Offset");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000499")]
		[Address(RVA = "0xAFD4D4", Offset = "0xAFD4D4", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EA9BB0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202249D]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenMaterialOffsetProperty()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
