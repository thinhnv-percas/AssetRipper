using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using Doozy.PlayMaker;
using Doozy.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7506C4", Offset = "0x7506C4")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7506C4", Offset = "0x7506C4")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x7506C4", Offset = "0x7506C4")]
	[Token(Token = "0x20000E5")]
	public class DOTweenSpriteRendererBlendableColor : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x78CA0C", Offset = "0x78CA0C")]
		[Token(Token = "0x4000B8B")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78CA80", Offset = "0x78CA80")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78CA80", Offset = "0x78CA80")]
		[Token(Token = "0x4000B8C")]
		[FieldOffset(Offset = "0x58")]
		public FsmColor to;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78CAE0", Offset = "0x78CAE0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78CAE0", Offset = "0x78CAE0")]
		[Token(Token = "0x4000B8D")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool setRelative;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78CB30", Offset = "0x78CB30")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78CB30", Offset = "0x78CB30")]
		[Token(Token = "0x4000B8E")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78CB90", Offset = "0x78CB90")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78CB90", Offset = "0x78CB90")]
		[Token(Token = "0x4000B8F")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78CBE0", Offset = "0x78CBE0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78CBE0", Offset = "0x78CBE0")]
		[Token(Token = "0x4000B90")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x78CC30", Offset = "0x78CC30")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78CC30", Offset = "0x78CC30")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78CC30", Offset = "0x78CC30")]
		[Token(Token = "0x4000B91")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78CCA4", Offset = "0x78CCA4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78CCA4", Offset = "0x78CCA4")]
		[Token(Token = "0x4000B92")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x78CCF4", Offset = "0x78CCF4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78CCF4", Offset = "0x78CCF4")]
		[Token(Token = "0x4000B93")]
		[FieldOffset(Offset = "0x90")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78CD44", Offset = "0x78CD44")]
		[Token(Token = "0x4000B94")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78CD58", Offset = "0x78CD58")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78CD58", Offset = "0x78CD58")]
		[Token(Token = "0x4000B95")]
		[FieldOffset(Offset = "0xA0")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x78CDA8", Offset = "0x78CDA8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78CDA8", Offset = "0x78CDA8")]
		[Token(Token = "0x4000B96")]
		[FieldOffset(Offset = "0xA8")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78CDF8", Offset = "0x78CDF8")]
		[Token(Token = "0x4000B97")]
		[FieldOffset(Offset = "0xB0")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78CE30", Offset = "0x78CE30")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78CE30", Offset = "0x78CE30")]
		[Token(Token = "0x4000B98")]
		[FieldOffset(Offset = "0xB8")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78CE80", Offset = "0x78CE80")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78CE80", Offset = "0x78CE80")]
		[Token(Token = "0x4000B99")]
		[FieldOffset(Offset = "0xC0")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x78CED0", Offset = "0x78CED0")]
		[Token(Token = "0x4000B9A")]
		[FieldOffset(Offset = "0xC8")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78CF08", Offset = "0x78CF08")]
		[Token(Token = "0x4000B9B")]
		[FieldOffset(Offset = "0xCC")]
		public Ease easeType;

		[Token(Token = "0x4000B9C")]
		[FieldOffset(Offset = "0xD0")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x78CF40", Offset = "0x78CF40")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78CF40", Offset = "0x78CF40")]
		[Token(Token = "0x4000B9D")]
		[FieldOffset(Offset = "0xD8")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78CF90", Offset = "0x78CF90")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78CF90", Offset = "0x78CF90")]
		[Token(Token = "0x4000B9E")]
		[FieldOffset(Offset = "0xE0")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78CFE0", Offset = "0x78CFE0")]
		[Token(Token = "0x4000B9F")]
		[FieldOffset(Offset = "0xE8")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x78D018", Offset = "0x78D018")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78D018", Offset = "0x78D018")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78D018", Offset = "0x78D018")]
		[Token(Token = "0x4000BA0")]
		[FieldOffset(Offset = "0xF0")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78D08C", Offset = "0x78D08C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78D08C", Offset = "0x78D08C")]
		[Token(Token = "0x4000BA1")]
		[FieldOffset(Offset = "0xF8")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78D0DC", Offset = "0x78D0DC")]
		[Token(Token = "0x4000BA2")]
		[FieldOffset(Offset = "0x100")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78D114", Offset = "0x78D114")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78D114", Offset = "0x78D114")]
		[Token(Token = "0x4000BA3")]
		[FieldOffset(Offset = "0x108")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x78D164", Offset = "0x78D164")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78D164", Offset = "0x78D164")]
		[Token(Token = "0x4000BA4")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool debugThis;

		[Token(Token = "0x4000BA5")]
		[FieldOffset(Offset = "0x118")]
		private Tweener tween;

		[Token(Token = "0x600054B")]
		[Address(RVA = "0xA26EA0", Offset = "0xA26EA0", Length = "0x29C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv23 = *([1ED0800]);\n\tv24 = *([v23 @ X8_v6]);\n\tv25 = \"il2cpp_codegen_initialize_method\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([2021D9A]) = v43;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv49 = new HutongGames.PlayMaker.FsmColor();\n\tHutongGames.PlayMaker.FsmColor::.ctor(v49);\n\tv49.useVariable = 0;\n\tthis.to = v49;\n\tv56 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v56);\n\tv56.useVariable = 0;\n\tthis.duration = v56;\n\tv68 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v68);\n\tv68.useVariable = 0;\n\tv68.value = 0;\n\tthis.setSpeedBased = v68;\n\tv69 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v69);\n\tv69.useVariable = 0;\n\tv69.value = 0;\n\tthis.setRelative = v69;\n\tv70 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v70);\n\tv70.useVariable = 0;\n\tv70.value = 0;\n\tthis.playInReverse = v70;\n\tv71 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v71);\n\tv71.useVariable = 0;\n\tv71.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v71;\n\tv72 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v72);\n\tv72.useVariable = 0;\n\tv72.value = 0;\n\tthis.finishImmediately = v72;\n\tv95 = 0xA2927C(v72, 0, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\treturn;\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX20 = X0;\n\tHutongGames.PlayMaker.FsmString::.ctor(X0, X1);\n\tif (TEMP) goto L_FFFFFFFF;\n\t*([X20+10]) = 0;\n\t*([X19+B8]) = X20;\n\tX0 = *([X23]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX20 = X0;\n\tHutongGames.PlayMaker.FsmString::.ctor(X0, X1);\n\tif (TEMP) goto L_FFFFFFFF;\n\t*([X20+10]) = 0;\n\t*([X19+C0]) = X20;\n\tX0 = *([X22]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX20 = X0;\n\tHutongGames.PlayMaker.FsmFloat::.ctor(X0, X1);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = 0 | 0x100000000;\n\t*([X20+38]) = 0;\n\t*([X19+78]) = X20;\n\t*([X19+C8]) = X8;\n\tX8 = *([1ECE5A0]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX20 = X0;\n\tHutongGames.PlayMaker.FsmInt::.ctor(X0, X1);\n\tif (TEMP) goto L_FFFFFFFF;\n\t*([X20+38]) = 0;\n\t*([X19+E0]) = X20;\n\t*([X19+E8]) = 0;\n\tX0 = *([X21]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX20 = X0;\n\tHutongGames.PlayMaker.FsmBool::.ctor(X0, X1);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = 0 | 1;\n\t*([X20+38]) = X8;\n\t*([X19+F0]) = X20;\n\tX0 = *([X21]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX20 = X0;\n\tHutongGames.PlayMaker.FsmBool::.ctor(X0, X1);\n\tif (TEMP) goto L_FFFFFFFF;\n\t*([X20+38]) = 0;\n\t*([X19+F8]) = X20;\n\t*([X19+100]) = 0;\n\tX0 = *([X21]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX20 = X0;\n\tHutongGames.PlayMaker.FsmBool::.ctor(X0, X1);\n\tif (TEMP) goto L_FFFFFFFF;\n\t*([X20+38]) = 0;\n\t*([X19+108]) = X20;\n\tX0 = *([X21]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX20 = X0;\n\tHutongGames.PlayMaker.FsmBool::.ctor(X0, X1);\n\tif (TEMP) goto L_FFFFFFFF;\n\t*([X20+38]) = 0;\n\t*([X19+110]) = X20;\n\tX29 = stack[30];\n\tX30 = stack[38];\n\tX20 = stack[20];\n\tX19 = stack[28];\n\tX22 = stack[10];\n\tX21 = stack[18];\n\tX23 = stack[0];\n\t// 191 ShiftStack 64\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
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
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @A2927C (inside HutongGames.PlayMaker.Actions.DOTweenTextColor::<OnEnter>b__28_1 +0x28)");
		}

		[Token(Token = "0x600054C")]
		[Address(RVA = "0xA2713C", Offset = "0xA2713C", Length = "0x3E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv32 = *([1EAC3D0]);\n\tv33 = *([v32 @ X8_v52]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2021D9B]) = v52;\nL_001F:\n\tv57 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv200 = UnityEngine.GameObject::GetComponent(v57);\n\tv157 = this.to;\n\tv265 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\t// 58 MakeStruct v82 @ AGGA271E8_1_v3 (UnityEngine.Color), typeof(UnityEngine.Color), v157.value (UnityEngine.Color), v157.value.g (System.Single), v157.value.b (System.Single), v157.value.a (System.Single)\n\tv201 = DG.Tweening.DOTweenModuleSprite::DOBlendableColor(v200, v82, v265);\n\tthis.tween = v201;\n\tv269 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv271 = v269 == 0;\n\tif (v271) goto L_0050;\n\tv276 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_0050:\n\tv279 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv282 = DG.Tweening.TweenSettingsExtensions::SetRelative(this.tween, v279);\n\tv285 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v285);\n\tv93 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv291 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v93);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv294 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv297 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v294, this.loopType);\n\tv299 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv302 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v299);\n\tv304 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv307 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v304);\n\tv309 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv312 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v309);\n\tv313 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv315 = v313 == 0;\n\tif (v315) goto L_00C1;\n\tv330 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv321 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v330);\nL_00C1:\n\tv328 = this.startEvent == 0;\n\tif (v328) goto L_00D9;\n\tv335 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v335, this, Il2CppMethodInfo);\n\tv341 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v335);\nL_00D9:\n\tv350 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv354 = v350 == 0;\n\tv355 = ~v354;\n\tif (v355) goto L_00FB;\n\tv361 = new DG.Tweening.TweenCallback();\n\tv370 = this.finishEvent == 0;\n\tif (v370) goto L_FFFFFFFF;\n\tgoto L_00F0;\nL_00F0:\n\tDG.Tweening.TweenCallback::.ctor(v361, this, *([v382 @ X8_v33 (Il2CppMethodInfo)]));\n\tv368 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v361);\nL_00FB:\n\tv375 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv381 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv387 = v381 == 0;\n\tif (v387) goto L_010E;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Sprite Renderer Blendable Color\");\nL_010E:\n\tv251 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv253 = v251 == 0;\n\tif (v253) goto L_012E;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_012E:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 241 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			SpriteRenderer component = ownerDefaultTarget.GetComponent<SpriteRenderer>();
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
				State.Debug("DOTween Sprite Renderer Blendable Color");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x600054D")]
		[Address(RVA = "0xA27520", Offset = "0xA27520", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ED6940]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021D9C]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenSpriteRendererBlendableColor()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
