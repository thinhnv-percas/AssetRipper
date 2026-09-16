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
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74F5C0", Offset = "0x74F5C0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x74F5C0", Offset = "0x74F5C0")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x74F5C0", Offset = "0x74F5C0")]
	[Token(Token = "0x20000C4")]
	public class DOTweenMaterialVectorProperty : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x77BE54", Offset = "0x77BE54")]
		[Token(Token = "0x40007E3")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77BEC8", Offset = "0x77BEC8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77BEC8", Offset = "0x77BEC8")]
		[Token(Token = "0x40007E4")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector2 to;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77BF28", Offset = "0x77BF28")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77BF28", Offset = "0x77BF28")]
		[Token(Token = "0x40007E5")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool setRelative;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77BF78", Offset = "0x77BF78")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77BF78", Offset = "0x77BF78")]
		[Token(Token = "0x40007E6")]
		[FieldOffset(Offset = "0x68")]
		public FsmString property;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77BFD8", Offset = "0x77BFD8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77BFD8", Offset = "0x77BFD8")]
		[Token(Token = "0x40007E7")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77C038", Offset = "0x77C038")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77C038", Offset = "0x77C038")]
		[Token(Token = "0x40007E8")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77C088", Offset = "0x77C088")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77C088", Offset = "0x77C088")]
		[Token(Token = "0x40007E9")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77C0D8", Offset = "0x77C0D8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77C0D8", Offset = "0x77C0D8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77C0D8", Offset = "0x77C0D8")]
		[Token(Token = "0x40007EA")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77C14C", Offset = "0x77C14C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77C14C", Offset = "0x77C14C")]
		[Token(Token = "0x40007EB")]
		[FieldOffset(Offset = "0x90")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77C19C", Offset = "0x77C19C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77C19C", Offset = "0x77C19C")]
		[Token(Token = "0x40007EC")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77C1EC", Offset = "0x77C1EC")]
		[Token(Token = "0x40007ED")]
		[FieldOffset(Offset = "0xA0")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77C200", Offset = "0x77C200")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77C200", Offset = "0x77C200")]
		[Token(Token = "0x40007EE")]
		[FieldOffset(Offset = "0xA8")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77C250", Offset = "0x77C250")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77C250", Offset = "0x77C250")]
		[Token(Token = "0x40007EF")]
		[FieldOffset(Offset = "0xB0")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77C2A0", Offset = "0x77C2A0")]
		[Token(Token = "0x40007F0")]
		[FieldOffset(Offset = "0xB8")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77C2D8", Offset = "0x77C2D8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77C2D8", Offset = "0x77C2D8")]
		[Token(Token = "0x40007F1")]
		[FieldOffset(Offset = "0xC0")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77C328", Offset = "0x77C328")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77C328", Offset = "0x77C328")]
		[Token(Token = "0x40007F2")]
		[FieldOffset(Offset = "0xC8")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77C378", Offset = "0x77C378")]
		[Token(Token = "0x40007F3")]
		[FieldOffset(Offset = "0xD0")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77C3B0", Offset = "0x77C3B0")]
		[Token(Token = "0x40007F4")]
		[FieldOffset(Offset = "0xD4")]
		public Ease easeType;

		[Token(Token = "0x40007F5")]
		[FieldOffset(Offset = "0xD8")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77C3E8", Offset = "0x77C3E8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77C3E8", Offset = "0x77C3E8")]
		[Token(Token = "0x40007F6")]
		[FieldOffset(Offset = "0xE0")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77C438", Offset = "0x77C438")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77C438", Offset = "0x77C438")]
		[Token(Token = "0x40007F7")]
		[FieldOffset(Offset = "0xE8")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77C488", Offset = "0x77C488")]
		[Token(Token = "0x40007F8")]
		[FieldOffset(Offset = "0xF0")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77C4C0", Offset = "0x77C4C0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77C4C0", Offset = "0x77C4C0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77C4C0", Offset = "0x77C4C0")]
		[Token(Token = "0x40007F9")]
		[FieldOffset(Offset = "0xF8")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77C534", Offset = "0x77C534")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77C534", Offset = "0x77C534")]
		[Token(Token = "0x40007FA")]
		[FieldOffset(Offset = "0x100")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77C584", Offset = "0x77C584")]
		[Token(Token = "0x40007FB")]
		[FieldOffset(Offset = "0x108")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77C5BC", Offset = "0x77C5BC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x77C5BC", Offset = "0x77C5BC")]
		[Token(Token = "0x40007FC")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x77C60C", Offset = "0x77C60C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x77C60C", Offset = "0x77C60C")]
		[Token(Token = "0x40007FD")]
		[FieldOffset(Offset = "0x118")]
		public FsmBool debugThis;

		[Token(Token = "0x40007FE")]
		[FieldOffset(Offset = "0x120")]
		private Tweener tween;

		[Token(Token = "0x60004A6")]
		[Address(RVA = "0xA17638", Offset = "0xA17638", Length = "0x2BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EDC538]);\n\tv25 = *([v24 @ X8_v12]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021D37]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.FsmVector2::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.to = v50;\n\tv57 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v57);\n\tv57.useVariable = 0;\n\tthis.property = v57;\n\tv80 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v80);\n\tv80.useVariable = 0;\n\tthis.duration = v80;\n\tv81 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v81);\n\tv81.useVariable = 0;\n\tv81.value = 0;\n\tthis.setSpeedBased = v81;\n\tv82 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v82);\n\tv82.useVariable = 0;\n\tv82.value = 0;\n\tthis.setRelative = v82;\n\tv83 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v83);\n\tv83.useVariable = 0;\n\tv83.value = 0;\n\tthis.playInReverse = v83;\n\tv84 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v84);\n\tv84.useVariable = 0;\n\tv84.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v84;\n\tv85 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v85);\n\tv85.useVariable = 0;\n\tv85.value = 0;\n\tthis.finishImmediately = v85;\n\tv86 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v86);\n\tv86.useVariable = 0;\n\tthis.stringAsId = v86;\n\tv87 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v87);\n\tv87.useVariable = 0;\n\tthis.tagAsId = v87;\n\tv88 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v88);\n\tv88.value = 0f;\n\tthis.startDelay = v88;\n\tthis.selectedEase = 0x100000000;\n\tv89 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v89);\n\tv89.value = 0;\n\tthis.loops = v89;\n\tthis.loopType = 0;\n\tv90 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v90);\n\tv90.value = 1;\n\tthis.autoKillOnCompletion = v90;\n\tv91 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v91);\n\tv91.value = 0;\n\tthis.recyclable = v91;\n\tthis.updateType = 0;\n\tv92 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v92);\n\tv92.value = 0;\n\tthis.isIndependentUpdate = v92;\n\tv93 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v93);\n\tv93.value = 0;\n\tthis.debugThis = v93;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 119 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60004A7")]
		[Address(RVA = "0xA178F4", Offset = "0xA178F4", Length = "0x448")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv32 = *([1EAC570]);\n\tv33 = *([v32 @ X8_v55]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2021D38]) = v52;\nL_001F:\n\tv57 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv141 = UnityEngine.GameObject::GetComponent(v57);\n\tv219 = UnityEngine.Renderer::get_material(v141);\n\tv227 = this.to;\n\tgoto L_003F;\n\tv295 = *([v292 @ X0_v11+E0]);\n\tv296 = v295 == 0;\n\tv297 = ~v296;\n\tif (v297) goto L_003F;\n\tv299 = \"il2cpp_codegen_runtime_class_init\"(v292, v127, v56, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_003F:\n\t// 63 MakeStruct v98 @ AGGA179A8_0_v3 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v227.value (UnityEngine.Vector2), v227.value.y (System.Single)\n\tv103 = UnityEngine.Vector4::op_Implicit(v98);\n\tv220 = HutongGames.PlayMaker.FsmString::get_Value(this.property);\n\tv306 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tv221 = DG.Tweening.ShortcutExtensions::DOVector(v219, v103, v220, v306);\n\tthis.tween = v221;\n\tv310 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv312 = v310 == 0;\n\tif (v312) goto L_0072;\n\tv317 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_0072:\n\tv320 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv323 = DG.Tweening.TweenSettingsExtensions::SetRelative(this.tween, v320);\n\tv326 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v326);\n\tv105 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv332 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v105);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv335 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv338 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v335, this.loopType);\n\tv340 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv343 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v340);\n\tv345 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv348 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v345);\n\tv350 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv353 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v350);\n\tv354 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv356 = v354 == 0;\n\tif (v356) goto L_00E3;\n\tv371 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv362 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v371);\nL_00E3:\n\tv369 = this.startEvent == 0;\n\tif (v369) goto L_00FB;\n\tv376 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v376, this, Il2CppMethodInfo);\n\tv382 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v376);\nL_00FB:\n\tv391 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv395 = v391 == 0;\n\tv396 = ~v395;\n\tif (v396) goto L_011D;\n\tv402 = new DG.Tweening.TweenCallback();\n\tv411 = this.finishEvent == 0;\n\tif (v411) goto L_FFFFFFFF;\n\tgoto L_0112;\nL_0112:\n\tDG.Tweening.TweenCallback::.ctor(v402, this, *([v423 @ X8_v35 (Il2CppMethodInfo)]));\n\tv409 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v402);\nL_011D:\n\tv416 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv422 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv428 = v422 == 0;\n\tif (v428) goto L_0130;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Material Vector Property\");\nL_0130:\n\tv275 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv277 = v275 == 0;\n\tif (v277) goto L_0150;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0150:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 266 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			Renderer component = ownerDefaultTarget.GetComponent<Renderer>();
			Material material = component.material;
			FsmVector2 fsmVector = to;
			Vector2 vector = default(Vector2);
			vector.x = fsmVector.value.x;
			vector.y = fsmVector.value.y;
			Vector4 endValue = vector;
			string value = property.Value;
			float value2 = duration.Value;
			TweenerCore<Vector4, Vector4, VectorOptions> tweenerCore = material.DOVector(endValue, value, value2);
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
				State.Debug("DOTween Material Vector Property");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x60004A8")]
		[Address(RVA = "0xA17D3C", Offset = "0xA17D3C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EA5FB0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021D39]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenMaterialVectorProperty()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
