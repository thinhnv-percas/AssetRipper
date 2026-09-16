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
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7517C8", Offset = "0x7517C8")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7517C8", Offset = "0x7517C8")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x7517C8", Offset = "0x7517C8")]
	[Token(Token = "0x2000106")]
	public class DOTweenTransformScale : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x79DA3C", Offset = "0x79DA3C")]
		[Token(Token = "0x4000F43")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79DAB0", Offset = "0x79DAB0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79DAB0", Offset = "0x79DAB0")]
		[Token(Token = "0x4000F44")]
		[FieldOffset(Offset = "0x58")]
		public Target target;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79DB10", Offset = "0x79DB10")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79DB10", Offset = "0x79DB10")]
		[Token(Token = "0x4000F45")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 to;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79DB60", Offset = "0x79DB60")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79DB60", Offset = "0x79DB60")]
		[Token(Token = "0x4000F46")]
		[FieldOffset(Offset = "0x68")]
		public FsmGameObject toGameObject;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79DBB0", Offset = "0x79DBB0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79DBB0", Offset = "0x79DBB0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79DBB0", Offset = "0x79DBB0")]
		[Token(Token = "0x4000F47")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool setRelative;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79DC24", Offset = "0x79DC24")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79DC24", Offset = "0x79DC24")]
		[Token(Token = "0x4000F48")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79DC84", Offset = "0x79DC84")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79DC84", Offset = "0x79DC84")]
		[Token(Token = "0x4000F49")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79DCD4", Offset = "0x79DCD4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79DCD4", Offset = "0x79DCD4")]
		[Token(Token = "0x4000F4A")]
		[FieldOffset(Offset = "0x88")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79DD24", Offset = "0x79DD24")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79DD24", Offset = "0x79DD24")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79DD24", Offset = "0x79DD24")]
		[Token(Token = "0x4000F4B")]
		[FieldOffset(Offset = "0x90")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79DD98", Offset = "0x79DD98")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79DD98", Offset = "0x79DD98")]
		[Token(Token = "0x4000F4C")]
		[FieldOffset(Offset = "0x98")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79DDE8", Offset = "0x79DDE8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79DDE8", Offset = "0x79DDE8")]
		[Token(Token = "0x4000F4D")]
		[FieldOffset(Offset = "0xA0")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79DE38", Offset = "0x79DE38")]
		[Token(Token = "0x4000F4E")]
		[FieldOffset(Offset = "0xA8")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79DE4C", Offset = "0x79DE4C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79DE4C", Offset = "0x79DE4C")]
		[Token(Token = "0x4000F4F")]
		[FieldOffset(Offset = "0xB0")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79DE9C", Offset = "0x79DE9C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79DE9C", Offset = "0x79DE9C")]
		[Token(Token = "0x4000F50")]
		[FieldOffset(Offset = "0xB8")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79DEEC", Offset = "0x79DEEC")]
		[Token(Token = "0x4000F51")]
		[FieldOffset(Offset = "0xC0")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79DF24", Offset = "0x79DF24")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79DF24", Offset = "0x79DF24")]
		[Token(Token = "0x4000F52")]
		[FieldOffset(Offset = "0xC8")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79DF74", Offset = "0x79DF74")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79DF74", Offset = "0x79DF74")]
		[Token(Token = "0x4000F53")]
		[FieldOffset(Offset = "0xD0")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79DFC4", Offset = "0x79DFC4")]
		[Token(Token = "0x4000F54")]
		[FieldOffset(Offset = "0xD8")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79DFFC", Offset = "0x79DFFC")]
		[Token(Token = "0x4000F55")]
		[FieldOffset(Offset = "0xDC")]
		public Ease easeType;

		[Token(Token = "0x4000F56")]
		[FieldOffset(Offset = "0xE0")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79E034", Offset = "0x79E034")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79E034", Offset = "0x79E034")]
		[Token(Token = "0x4000F57")]
		[FieldOffset(Offset = "0xE8")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79E084", Offset = "0x79E084")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79E084", Offset = "0x79E084")]
		[Token(Token = "0x4000F58")]
		[FieldOffset(Offset = "0xF0")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79E0D4", Offset = "0x79E0D4")]
		[Token(Token = "0x4000F59")]
		[FieldOffset(Offset = "0xF8")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79E10C", Offset = "0x79E10C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79E10C", Offset = "0x79E10C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79E10C", Offset = "0x79E10C")]
		[Token(Token = "0x4000F5A")]
		[FieldOffset(Offset = "0x100")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79E180", Offset = "0x79E180")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79E180", Offset = "0x79E180")]
		[Token(Token = "0x4000F5B")]
		[FieldOffset(Offset = "0x108")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79E1D0", Offset = "0x79E1D0")]
		[Token(Token = "0x4000F5C")]
		[FieldOffset(Offset = "0x110")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79E208", Offset = "0x79E208")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79E208", Offset = "0x79E208")]
		[Token(Token = "0x4000F5D")]
		[FieldOffset(Offset = "0x118")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79E258", Offset = "0x79E258")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79E258", Offset = "0x79E258")]
		[Token(Token = "0x4000F5E")]
		[FieldOffset(Offset = "0x120")]
		public FsmBool debugThis;

		[Token(Token = "0x4000F5F")]
		[FieldOffset(Offset = "0x128")]
		private Tweener tween;

		[Token(Token = "0x60005F1")]
		[Address(RVA = "0xA82118", Offset = "0xA82118", Length = "0x2E4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EEFD10]);\n\tv25 = *([v24 @ X8_v14]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022179]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.to = v50;\n\tv57 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.FsmGameObject::.ctor(v57);\n\tv57.useVariable = 0;\n\tthis.toGameObject = v57;\n\tv82 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v82);\n\tv82.useVariable = 0;\n\tv82.value = 0;\n\tthis.setRelative = v82;\n\tv83 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v83);\n\tv83.useVariable = 0;\n\tthis.duration = v83;\n\tv84 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v84);\n\tv84.useVariable = 0;\n\tv84.value = 0;\n\tthis.setSpeedBased = v84;\n\tv85 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v85);\n\tv85.value = 0f;\n\tthis.startDelay = v85;\n\tv86 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v86);\n\tv86.useVariable = 0;\n\tv86.value = 0;\n\tthis.playInReverse = v86;\n\tv87 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v87);\n\tv87.useVariable = 0;\n\tv87.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v87;\n\tv88 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v88);\n\tv88.useVariable = 0;\n\tv88.value = 0;\n\tthis.finishImmediately = v88;\n\tv89 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v89);\n\tv89.useVariable = 0;\n\tthis.stringAsId = v89;\n\tv90 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v90);\n\tv90.useVariable = 0;\n\tthis.tagAsId = v90;\n\tv91 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v91);\n\tv91.value = 0f;\n\tthis.startDelay = v91;\n\tthis.selectedEase = 0x100000000;\n\tv92 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v92);\n\tv92.value = 0;\n\tthis.loops = v92;\n\tthis.loopType = 0;\n\tv93 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v93);\n\tv93.value = 1;\n\tthis.autoKillOnCompletion = v93;\n\tv94 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v94);\n\tv94.value = 0;\n\tthis.recyclable = v94;\n\tthis.updateType = 0;\n\tv95 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v95);\n\tv95.value = 0;\n\tthis.isIndependentUpdate = v95;\n\tv96 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v96);\n\tv96.value = 0;\n\tthis.debugThis = v96;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 126 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_022d: Expected I4, but got I8
			base.Reset();
			gameObject = null;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = false;
			to = fsmVector;
			FsmGameObject fsmGameObject = new FsmGameObject();
			fsmGameObject.useVariable = false;
			toGameObject = fsmGameObject;
			FsmBool fsmBool = new FsmBool();
			fsmBool.useVariable = false;
			fsmBool.value = false;
			setRelative = fsmBool;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = false;
			duration = fsmFloat;
			FsmBool fsmBool2 = new FsmBool();
			fsmBool2.useVariable = false;
			fsmBool2.value = false;
			setSpeedBased = fsmBool2;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.Value = 0f;
			startDelay = fsmFloat2;
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
			FsmFloat fsmFloat3 = new FsmFloat();
			fsmFloat3.Value = 0f;
			startDelay = fsmFloat3;
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

		[Token(Token = "0x60005F2")]
		[Address(RVA = "0xA823FC", Offset = "0xA823FC", Length = "0x458")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv30 = *([1EEE5D0]);\n\tv31 = *([v30 @ X8_v57]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([202217A]) = v50;\nL_001E:\n\tv56 = this.target == 1;\n\tif (v56) goto L_0042;\n\tv61 = this.target == 0;\n\tv62 = ~v61;\n\tif (v62) goto L_006F;\n\tv165 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv243 = UnityEngine.GameObject::GetComponent(v165);\n\tv134 = HutongGames.PlayMaker.FsmVector3::get_Value(this.to);\n\tv131 = v134.y;\n\tv129 = v134.z;\n\tgoto L_0061;\nL_0042:\n\tv100 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv244 = UnityEngine.GameObject::GetComponent(v100);\n\tv166 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.toGameObject);\n\tv167 = UnityEngine.GameObject::get_transform(v166);\n\tv134 = UnityEngine.Transform::get_localScale(v167);\n\tv131 = v134.y;\n\tv129 = v134.z;\nL_0061:\n\tv335 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\t// 104 MakeStruct v74 @ AGGA82520_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v134 @ V0_v1 (UnityEngine.Vector3), v131 @ V1_v1 (System.Single), v129 @ V2_v1 (System.Single)\n\tv89 = DG.Tweening.ShortcutExtensions::DOScale(v95, v74, v335);\n\tthis.tween = v89;\nL_006F:\n\tv223 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv255 = v223 == 0;\n\tif (v255) goto L_007D;\n\tv264 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_007D:\n\tv315 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv322 = DG.Tweening.TweenSettingsExtensions::SetRelative(this.tween, v315);\n\tv333 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v333);\n\tv133 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv342 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v133);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv345 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv348 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v345, this.loopType);\n\tv350 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv353 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v350);\n\tv355 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv358 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v355);\n\tv360 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv363 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v360);\n\tv364 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv366 = v364 == 0;\n\tif (v366) goto L_00EE;\n\tv381 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv372 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v381);\nL_00EE:\n\tv379 = this.startEvent == 0;\n\tif (v379) goto L_0106;\n\tv386 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v386, this, Il2CppMethodInfo);\n\tv392 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v386);\nL_0106:\n\tv401 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv405 = v401 == 0;\n\tv406 = ~v405;\n\tif (v406) goto L_0128;\n\tv412 = new DG.Tweening.TweenCallback();\n\tv421 = this.finishEvent == 0;\n\tif (v421) goto L_FFFFFFFF;\n\tgoto L_011D;\nL_011D:\n\tDG.Tweening.TweenCallback::.ctor(v412, this, *([v433 @ X8_v30 (Il2CppMethodInfo)]));\n\tv419 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v412);\nL_0128:\n\tv426 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv432 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv438 = v432 == 0;\n\tif (v438) goto L_013B;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Transform Scale\");\nL_013B:\n\tv301 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv303 = v301 == 0;\n\tif (v303) goto L_0159;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0159:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 269 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			Vector3 vector;
			float y;
			float z;
			Transform transform;
			if (target != Target.GameObject)
			{
				if (target != Target.Value)
				{
					goto IL_017b;
				}
				GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
				Transform component = ownerDefaultTarget.GetComponent<Transform>();
				vector = to.Value;
				y = vector.y;
				z = vector.z;
				transform = component;
			}
			else
			{
				GameObject ownerDefaultTarget2 = Fsm.GetOwnerDefaultTarget(gameObject);
				Transform component2 = ownerDefaultTarget2.GetComponent<Transform>();
				GameObject value = toGameObject.Value;
				Transform transform2 = value.transform;
				vector = transform2.localScale;
				y = vector.y;
				z = vector.z;
				transform = component2;
			}
			float value2 = duration.Value;
			Vector3 endValue = default(Vector3);
			endValue.x = vector.x;
			endValue.y = y;
			endValue.z = z;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = transform.DOScale(endValue, value2);
			tween = tweenerCore;
			goto IL_017b;
			IL_017b:
			if (setSpeedBased.Value)
			{
				Tweener tweener = tween.SetSpeedBased();
			}
			bool value3 = setRelative.Value;
			Tweener tweener2 = tween.SetRelative(value3);
			GameObject ownerDefaultTarget3 = Fsm.GetOwnerDefaultTarget(gameObject);
			tween.SetTweenId(tweenIdType, stringAsId, tagAsId, ownerDefaultTarget3);
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
				State.Debug("DOTween Transform Scale");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x60005F3")]
		[Address(RVA = "0xA82854", Offset = "0xA82854", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EEDF00]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202217B]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenTransformScale()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
