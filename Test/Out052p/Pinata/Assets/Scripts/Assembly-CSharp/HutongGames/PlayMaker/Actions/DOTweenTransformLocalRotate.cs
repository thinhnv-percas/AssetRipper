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
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x751198", Offset = "0x751198")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x751198", Offset = "0x751198")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x751198", Offset = "0x751198")]
	[Token(Token = "0x20000FA")]
	public class DOTweenTransformLocalRotate : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7974A4", Offset = "0x7974A4")]
		[Token(Token = "0x4000DE0")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x797518", Offset = "0x797518")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x797518", Offset = "0x797518")]
		[Token(Token = "0x4000DE1")]
		[FieldOffset(Offset = "0x58")]
		public Target target;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x797578", Offset = "0x797578")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x797578", Offset = "0x797578")]
		[Token(Token = "0x4000DE2")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 to;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7975C8", Offset = "0x7975C8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7975C8", Offset = "0x7975C8")]
		[Token(Token = "0x4000DE3")]
		[FieldOffset(Offset = "0x68")]
		public FsmGameObject toGameObject;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x797618", Offset = "0x797618")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x797618", Offset = "0x797618")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x797618", Offset = "0x797618")]
		[Token(Token = "0x4000DE4")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool setRelative;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79768C", Offset = "0x79768C")]
		[Token(Token = "0x4000DE5")]
		[FieldOffset(Offset = "0x78")]
		public RotateMode rotateMode;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7976C4", Offset = "0x7976C4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7976C4", Offset = "0x7976C4")]
		[Token(Token = "0x4000DE6")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x797724", Offset = "0x797724")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x797724", Offset = "0x797724")]
		[Token(Token = "0x4000DE7")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x797774", Offset = "0x797774")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x797774", Offset = "0x797774")]
		[Token(Token = "0x4000DE8")]
		[FieldOffset(Offset = "0x90")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7977C4", Offset = "0x7977C4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7977C4", Offset = "0x7977C4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7977C4", Offset = "0x7977C4")]
		[Token(Token = "0x4000DE9")]
		[FieldOffset(Offset = "0x98")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x797838", Offset = "0x797838")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x797838", Offset = "0x797838")]
		[Token(Token = "0x4000DEA")]
		[FieldOffset(Offset = "0xA0")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x797888", Offset = "0x797888")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x797888", Offset = "0x797888")]
		[Token(Token = "0x4000DEB")]
		[FieldOffset(Offset = "0xA8")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7978D8", Offset = "0x7978D8")]
		[Token(Token = "0x4000DEC")]
		[FieldOffset(Offset = "0xB0")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7978EC", Offset = "0x7978EC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7978EC", Offset = "0x7978EC")]
		[Token(Token = "0x4000DED")]
		[FieldOffset(Offset = "0xB8")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79793C", Offset = "0x79793C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79793C", Offset = "0x79793C")]
		[Token(Token = "0x4000DEE")]
		[FieldOffset(Offset = "0xC0")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79798C", Offset = "0x79798C")]
		[Token(Token = "0x4000DEF")]
		[FieldOffset(Offset = "0xC8")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7979C4", Offset = "0x7979C4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7979C4", Offset = "0x7979C4")]
		[Token(Token = "0x4000DF0")]
		[FieldOffset(Offset = "0xD0")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x797A14", Offset = "0x797A14")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x797A14", Offset = "0x797A14")]
		[Token(Token = "0x4000DF1")]
		[FieldOffset(Offset = "0xD8")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x797A64", Offset = "0x797A64")]
		[Token(Token = "0x4000DF2")]
		[FieldOffset(Offset = "0xE0")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x797A9C", Offset = "0x797A9C")]
		[Token(Token = "0x4000DF3")]
		[FieldOffset(Offset = "0xE4")]
		public Ease easeType;

		[Token(Token = "0x4000DF4")]
		[FieldOffset(Offset = "0xE8")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x797AD4", Offset = "0x797AD4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x797AD4", Offset = "0x797AD4")]
		[Token(Token = "0x4000DF5")]
		[FieldOffset(Offset = "0xF0")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x797B24", Offset = "0x797B24")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x797B24", Offset = "0x797B24")]
		[Token(Token = "0x4000DF6")]
		[FieldOffset(Offset = "0xF8")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x797B74", Offset = "0x797B74")]
		[Token(Token = "0x4000DF7")]
		[FieldOffset(Offset = "0x100")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x797BAC", Offset = "0x797BAC")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x797BAC", Offset = "0x797BAC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x797BAC", Offset = "0x797BAC")]
		[Token(Token = "0x4000DF8")]
		[FieldOffset(Offset = "0x108")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x797C20", Offset = "0x797C20")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x797C20", Offset = "0x797C20")]
		[Token(Token = "0x4000DF9")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x797C70", Offset = "0x797C70")]
		[Token(Token = "0x4000DFA")]
		[FieldOffset(Offset = "0x118")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x797CA8", Offset = "0x797CA8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x797CA8", Offset = "0x797CA8")]
		[Token(Token = "0x4000DFB")]
		[FieldOffset(Offset = "0x120")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x797CF8", Offset = "0x797CF8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x797CF8", Offset = "0x797CF8")]
		[Token(Token = "0x4000DFC")]
		[FieldOffset(Offset = "0x128")]
		public FsmBool debugThis;

		[Token(Token = "0x4000DFD")]
		[FieldOffset(Offset = "0x130")]
		private Tweener tween;

		[Token(Token = "0x60005B4")]
		[Address(RVA = "0xA7BF64", Offset = "0xA7BF64", Length = "0x2C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1ED00F0]);\n\tv25 = *([v24 @ X8_v14]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022155]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.to = v50;\n\tv57 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.FsmGameObject::.ctor(v57);\n\tv57.useVariable = 0;\n\tthis.toGameObject = v57;\n\tv81 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v81);\n\tv81.useVariable = 0;\n\tthis.duration = v81;\n\tv82 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v82);\n\tv82.useVariable = 0;\n\tv82.value = 0;\n\tthis.setSpeedBased = v82;\n\tthis.rotateMode = 0;\n\tv83 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v83);\n\tv83.useVariable = 0;\n\tv83.value = 0;\n\tthis.setRelative = v83;\n\tv84 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v84);\n\tv84.useVariable = 0;\n\tv84.value = 0;\n\tthis.playInReverse = v84;\n\tv85 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v85);\n\tv85.useVariable = 0;\n\tv85.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v85;\n\tv86 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v86);\n\tv86.useVariable = 0;\n\tv86.value = 0;\n\tthis.finishImmediately = v86;\n\tv87 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v87);\n\tv87.useVariable = 0;\n\tthis.stringAsId = v87;\n\tv88 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v88);\n\tv88.useVariable = 0;\n\tthis.tagAsId = v88;\n\tv89 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v89);\n\tv89.value = 0f;\n\tthis.startDelay = v89;\n\tthis.selectedEase = 0x100000000;\n\tv90 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v90);\n\tv90.value = 0;\n\tthis.loops = v90;\n\tthis.loopType = 0;\n\tv91 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v91);\n\tv91.value = 1;\n\tthis.autoKillOnCompletion = v91;\n\tv92 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v92);\n\tv92.value = 0;\n\tthis.recyclable = v92;\n\tthis.updateType = 0;\n\tv93 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v93);\n\tv93.value = 0;\n\tthis.isIndependentUpdate = v93;\n\tv94 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v94);\n\tv94.value = 0;\n\tthis.debugThis = v94;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 121 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_021a: Expected I4, but got I8
			base.Reset();
			gameObject = null;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = false;
			to = fsmVector;
			FsmGameObject fsmGameObject = new FsmGameObject();
			fsmGameObject.useVariable = false;
			toGameObject = fsmGameObject;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = false;
			duration = fsmFloat;
			FsmBool fsmBool = new FsmBool();
			fsmBool.useVariable = false;
			fsmBool.value = false;
			setSpeedBased = fsmBool;
			rotateMode = default(RotateMode);
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

		[Token(Token = "0x60005B5")]
		[Address(RVA = "0xA7C22C", Offset = "0xA7C22C", Length = "0x464")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv30 = *([1EEAAF8]);\n\tv31 = *([v30 @ X8_v57]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2022156]) = v50;\nL_0020:\n\tv58 = this.target == 1;\n\tif (v58) goto L_0044;\n\tv63 = this.target == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_007A;\n\tv183 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv265 = UnityEngine.GameObject::GetComponent(v183);\n\tv333 = HutongGames.PlayMaker.FsmVector3::get_Value(this.to);\n\tv148 = v333.y;\n\tv146 = v333.z;\n\tgoto L_006B;\nL_0044:\n\tv112 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv266 = UnityEngine.GameObject::GetComponent(v112);\n\tv184 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.toGameObject);\n\tv185 = UnityEngine.GameObject::get_transform(v184);\n\tv346 = UnityEngine.Transform::get_rotation(v185);\n\tv148 = v346.y;\n\tv146 = v346.z;\n\tv349 = 0x10CC508(&v346 @ V0_v8 (UnityEngine.Quaternion), 0, 0, v35, v36, v37, v38, v39, v346, v346.y, v346.z, v346.w, v44, v45, v46, v47);\nL_006B:\n\tv355 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\t// 115 MakeStruct v70 @ AGGA7C370_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v333 @ V0_v9 (UnityEngine.Vector3), v148 @ V1_v4 (System.Single), v146 @ V2_v4 (System.Single)\n\tv101 = DG.Tweening.ShortcutExtensions::DOLocalRotate(v107, v70, v355, this.rotateMode);\n\tthis.tween = v101;\nL_007A:\n\tv241 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv277 = v241 == 0;\n\tif (v277) goto L_0088;\n\tv286 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_0088:\n\tv329 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv336 = DG.Tweening.TweenSettingsExtensions::SetRelative(this.tween, v329);\n\tv353 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v353);\n\tv151 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv364 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v151);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv367 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv370 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v367, this.loopType);\n\tv372 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv375 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v372);\n\tv377 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv380 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v377);\n\tv382 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv385 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v382);\n\tv386 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv388 = v386 == 0;\n\tif (v388) goto L_00F9;\n\tv403 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv394 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v403);\nL_00F9:\n\tv401 = this.startEvent == 0;\n\tif (v401) goto L_0111;\n\tv408 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v408, this, Il2CppMethodInfo);\n\tv414 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v408);\nL_0111:\n\tv423 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv427 = v423 == 0;\n\tv428 = ~v427;\n\tif (v428) goto L_0133;\n\tv434 = new DG.Tweening.TweenCallback();\n\tv443 = this.finishEvent == 0;\n\tif (v443) goto L_FFFFFFFF;\n\tgoto L_0128;\nL_0128:\n\tDG.Tweening.TweenCallback::.ctor(v434, this, *([v455 @ X8_v29 (Il2CppMethodInfo)]));\n\tv441 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v434);\nL_0133:\n\tv448 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv454 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv460 = v454 == 0;\n\tif (v460) goto L_0146;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Transform Local Rotate\");\nL_0146:\n\tv470 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv320 = v470 == 0;\n\tif (v320) goto L_0158;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\nL_0158:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 268 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
					goto IL_0193;
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
				Quaternion rotation = transform2.rotation;
				y = rotation.y;
				z = rotation.z;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CC508 (inside UnityEngine.Quaternion::Internal_MakePositive +0x9C)");
				vector = (Vector3)rotation;
				transform = component2;
			}
			float value2 = duration.Value;
			Vector3 endValue = default(Vector3);
			endValue.x = vector.x;
			endValue.y = y;
			endValue.z = z;
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = transform.DOLocalRotate(endValue, value2, rotateMode);
			tween = tweenerCore;
			goto IL_0193;
			IL_0193:
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
				State.Debug("DOTween Transform Local Rotate");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x60005B6")]
		[Address(RVA = "0xA7C690", Offset = "0xA7C690", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tDG.Tweening.TweenExtensions::Kill(this.tween, 1);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnExit()
		{
			tween.Kill(complete: true);
		}

		[Token(Token = "0x60005B7")]
		[Address(RVA = "0xA7C6A0", Offset = "0xA7C6A0", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ECEC70]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022157]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenTransformLocalRotate()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
