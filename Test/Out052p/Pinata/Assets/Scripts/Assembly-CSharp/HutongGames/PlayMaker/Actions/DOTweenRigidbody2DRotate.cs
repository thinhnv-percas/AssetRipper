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
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x750010", Offset = "0x750010")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x750010", Offset = "0x750010")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x750010", Offset = "0x750010")]
	[Token(Token = "0x20000D8")]
	public class DOTweenRigidbody2DRotate : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x785D64", Offset = "0x785D64")]
		[Token(Token = "0x4000A11")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x785DD8", Offset = "0x785DD8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x785DD8", Offset = "0x785DD8")]
		[Token(Token = "0x4000A12")]
		[FieldOffset(Offset = "0x58")]
		public Target target;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x785E38", Offset = "0x785E38")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x785E38", Offset = "0x785E38")]
		[Token(Token = "0x4000A13")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat toAngle;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x785E88", Offset = "0x785E88")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x785E88", Offset = "0x785E88")]
		[Token(Token = "0x4000A14")]
		[FieldOffset(Offset = "0x68")]
		public FsmGameObject toGameObject;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x785ED8", Offset = "0x785ED8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x785ED8", Offset = "0x785ED8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x785ED8", Offset = "0x785ED8")]
		[Token(Token = "0x4000A15")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool setRelative;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x785F4C", Offset = "0x785F4C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x785F4C", Offset = "0x785F4C")]
		[Token(Token = "0x4000A16")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x785FAC", Offset = "0x785FAC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x785FAC", Offset = "0x785FAC")]
		[Token(Token = "0x4000A17")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x785FFC", Offset = "0x785FFC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x785FFC", Offset = "0x785FFC")]
		[Token(Token = "0x4000A18")]
		[FieldOffset(Offset = "0x88")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x78604C", Offset = "0x78604C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78604C", Offset = "0x78604C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78604C", Offset = "0x78604C")]
		[Token(Token = "0x4000A19")]
		[FieldOffset(Offset = "0x90")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7860C0", Offset = "0x7860C0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7860C0", Offset = "0x7860C0")]
		[Token(Token = "0x4000A1A")]
		[FieldOffset(Offset = "0x98")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x786110", Offset = "0x786110")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x786110", Offset = "0x786110")]
		[Token(Token = "0x4000A1B")]
		[FieldOffset(Offset = "0xA0")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x786160", Offset = "0x786160")]
		[Token(Token = "0x4000A1C")]
		[FieldOffset(Offset = "0xA8")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x786174", Offset = "0x786174")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x786174", Offset = "0x786174")]
		[Token(Token = "0x4000A1D")]
		[FieldOffset(Offset = "0xB0")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7861C4", Offset = "0x7861C4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7861C4", Offset = "0x7861C4")]
		[Token(Token = "0x4000A1E")]
		[FieldOffset(Offset = "0xB8")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x786214", Offset = "0x786214")]
		[Token(Token = "0x4000A1F")]
		[FieldOffset(Offset = "0xC0")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78624C", Offset = "0x78624C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78624C", Offset = "0x78624C")]
		[Token(Token = "0x4000A20")]
		[FieldOffset(Offset = "0xC8")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78629C", Offset = "0x78629C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78629C", Offset = "0x78629C")]
		[Token(Token = "0x4000A21")]
		[FieldOffset(Offset = "0xD0")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7862EC", Offset = "0x7862EC")]
		[Token(Token = "0x4000A22")]
		[FieldOffset(Offset = "0xD8")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x786324", Offset = "0x786324")]
		[Token(Token = "0x4000A23")]
		[FieldOffset(Offset = "0xDC")]
		public Ease easeType;

		[Token(Token = "0x4000A24")]
		[FieldOffset(Offset = "0xE0")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x78635C", Offset = "0x78635C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78635C", Offset = "0x78635C")]
		[Token(Token = "0x4000A25")]
		[FieldOffset(Offset = "0xE8")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7863AC", Offset = "0x7863AC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7863AC", Offset = "0x7863AC")]
		[Token(Token = "0x4000A26")]
		[FieldOffset(Offset = "0xF0")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7863FC", Offset = "0x7863FC")]
		[Token(Token = "0x4000A27")]
		[FieldOffset(Offset = "0xF8")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x786434", Offset = "0x786434")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x786434", Offset = "0x786434")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x786434", Offset = "0x786434")]
		[Token(Token = "0x4000A28")]
		[FieldOffset(Offset = "0x100")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7864A8", Offset = "0x7864A8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7864A8", Offset = "0x7864A8")]
		[Token(Token = "0x4000A29")]
		[FieldOffset(Offset = "0x108")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7864F8", Offset = "0x7864F8")]
		[Token(Token = "0x4000A2A")]
		[FieldOffset(Offset = "0x110")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x786530", Offset = "0x786530")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x786530", Offset = "0x786530")]
		[Token(Token = "0x4000A2B")]
		[FieldOffset(Offset = "0x118")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x786580", Offset = "0x786580")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x786580", Offset = "0x786580")]
		[Token(Token = "0x4000A2C")]
		[FieldOffset(Offset = "0x120")]
		public FsmBool debugThis;

		[Token(Token = "0x4000A2D")]
		[FieldOffset(Offset = "0x128")]
		private Tweener tween;

		[Token(Token = "0x600050A")]
		[Address(RVA = "0xA20AA4", Offset = "0xA20AA4", Length = "0x2BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EF0C58]);\n\tv25 = *([v24 @ X8_v12]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021D73]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.toAngle = v50;\n\tv57 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.FsmGameObject::.ctor(v57);\n\tv57.useVariable = 0;\n\tthis.toGameObject = v57;\n\tv79 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v79);\n\tv79.useVariable = 0;\n\tthis.duration = v79;\n\tv80 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v80);\n\tv80.useVariable = 0;\n\tv80.value = 0;\n\tthis.setSpeedBased = v80;\n\tv81 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v81);\n\tv81.useVariable = 0;\n\tv81.value = 0;\n\tthis.setRelative = v81;\n\tv82 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v82);\n\tv82.useVariable = 0;\n\tv82.value = 0;\n\tthis.playInReverse = v82;\n\tv83 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v83);\n\tv83.useVariable = 0;\n\tv83.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v83;\n\tv84 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v84);\n\tv84.useVariable = 0;\n\tv84.value = 0;\n\tthis.finishImmediately = v84;\n\tv85 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v85);\n\tv85.useVariable = 0;\n\tthis.stringAsId = v85;\n\tv86 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v86);\n\tv86.useVariable = 0;\n\tthis.tagAsId = v86;\n\tv87 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v87);\n\tv87.value = 0f;\n\tthis.startDelay = v87;\n\tthis.selectedEase = 0x100000000;\n\tv88 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v88);\n\tv88.value = 0;\n\tthis.loops = v88;\n\tthis.loopType = 0;\n\tv89 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v89);\n\tv89.value = 1;\n\tthis.autoKillOnCompletion = v89;\n\tv90 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v90);\n\tv90.value = 0;\n\tthis.recyclable = v90;\n\tthis.updateType = 0;\n\tv91 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v91);\n\tv91.value = 0;\n\tthis.isIndependentUpdate = v91;\n\tv92 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v92);\n\tv92.value = 0;\n\tthis.debugThis = v92;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 119 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_0206: Expected I4, but got I8
			base.Reset();
			gameObject = null;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = false;
			toAngle = fsmFloat;
			FsmGameObject fsmGameObject = new FsmGameObject();
			fsmGameObject.useVariable = false;
			toGameObject = fsmGameObject;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = false;
			duration = fsmFloat2;
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

		[Token(Token = "0x600050B")]
		[Address(RVA = "0xA20D60", Offset = "0xA20D60", Length = "0x448")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1EB3938]);\n\tv27 = *([v26 @ X8_v57]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2021D74]) = v46;\nL_001C:\n\tv52 = this.target == 1;\n\tif (v52) goto L_0043;\n\tv57 = this.target == 0;\n\tv58 = ~v57;\n\tif (v58) goto L_006C;\n\tv156 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv236 = UnityEngine.GameObject::GetComponent(v156);\n\tv122 = HutongGames.PlayMaker.FsmFloat::get_Value(this.toAngle);\n\tv309 = this.duration;\n\tv305 = this.duration == 0;\n\tv175 = ~v305;\n\tif (v175) goto L_0061;\n\tgoto L_0153;\nL_0043:\n\tv89 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv237 = UnityEngine.GameObject::GetComponent(v89);\n\tv158 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.toGameObject);\n\tv159 = UnityEngine.GameObject::get_transform(v158);\n\tv123 = UnityEngine.Transform::get_rotation(v159);\n\tv309 = this.duration;\nL_0061:\n\tv311 = HutongGames.PlayMaker.FsmFloat::get_Value(v309);\n\tv78 = DG.Tweening.DOTweenModulePhysics2D::DORotate(v84, v70, v311);\n\tthis.tween = v78;\nL_006C:\n\tv219 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv246 = v219 == 0;\n\tif (v246) goto L_007A;\n\tv255 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_007A:\n\tv299 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv304 = DG.Tweening.TweenSettingsExtensions::SetRelative(this.tween, v299);\n\tv314 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v314);\n\tv124 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv321 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v124);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv324 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv327 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v324, this.loopType);\n\tv329 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv332 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v329);\n\tv334 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv337 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v334);\n\tv339 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv342 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v339);\n\tv343 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv345 = v343 == 0;\n\tif (v345) goto L_00EB;\n\tv360 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv351 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v360);\nL_00EB:\n\tv358 = this.startEvent == 0;\n\tif (v358) goto L_0103;\n\tv365 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v365, this, Il2CppMethodInfo);\n\tv371 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v365);\nL_0103:\n\tv380 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv384 = v380 == 0;\n\tv385 = ~v384;\n\tif (v385) goto L_0125;\n\tv391 = new DG.Tweening.TweenCallback();\n\tv400 = this.finishEvent == 0;\n\tif (v400) goto L_FFFFFFFF;\n\tgoto L_011A;\nL_011A:\n\tDG.Tweening.TweenCallback::.ctor(v391, this, *([v412 @ X8_v29 (Il2CppMethodInfo)]));\n\tv398 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v391);\nL_0125:\n\tv405 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv411 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv417 = v411 == 0;\n\tif (v417) goto L_0138;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween RigidBody2D Rotate\");\nL_0138:\n\tv285 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv287 = v285 == 0;\n\tif (v287) goto L_0152;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0152:\n\treturn;\nL_0153:\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 263 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			FsmFloat fsmFloat;
			float endValue;
			Rigidbody2D rigidbody2D;
			if (target != Target.GameObject)
			{
				if (target != Target.Value)
				{
					goto IL_016c;
				}
				GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
				Rigidbody2D component = ownerDefaultTarget.GetComponent<Rigidbody2D>();
				float value = toAngle.Value;
				fsmFloat = duration;
				bool flag = duration == null;
				bool flag2 = !flag;
				endValue = value;
				rigidbody2D = component;
				if (!flag2)
				{
					throw new NullReferenceException();
				}
			}
			else
			{
				GameObject ownerDefaultTarget2 = Fsm.GetOwnerDefaultTarget(gameObject);
				Rigidbody2D component2 = ownerDefaultTarget2.GetComponent<Rigidbody2D>();
				GameObject value2 = toGameObject.Value;
				Transform transform = value2.transform;
				Quaternion rotation = transform.rotation;
				fsmFloat = duration;
				endValue = rotation.z;
				rigidbody2D = component2;
			}
			float value3 = fsmFloat.Value;
			TweenerCore<float, float, FloatOptions> tweenerCore = rigidbody2D.DORotate(endValue, value3);
			tween = tweenerCore;
			goto IL_016c;
			IL_016c:
			if (setSpeedBased.Value)
			{
				Tweener tweener = tween.SetSpeedBased();
			}
			bool value4 = setRelative.Value;
			Tweener tweener2 = tween.SetRelative(value4);
			GameObject ownerDefaultTarget3 = Fsm.GetOwnerDefaultTarget(gameObject);
			tween.SetTweenId(tweenIdType, stringAsId, tagAsId, ownerDefaultTarget3);
			float value5 = startDelay.Value;
			Tweener tweener3 = tween.SetDelay(value5);
			tween.SetSelectedEase(selectedEase, easeType, animationCurve);
			int value6 = loops.Value;
			Tweener tweener4 = tween.SetLoops(value6, loopType);
			bool value7 = autoKillOnCompletion.Value;
			Tweener tweener5 = tween.SetAutoKill(value7);
			bool value8 = recyclable.Value;
			Tweener tweener6 = tween.SetRecyclable(value8);
			bool value9 = isIndependentUpdate.Value;
			Tweener tweener7 = tween.SetUpdate(updateType, value9);
			if (playInReverse.Value)
			{
				bool value10 = setReverseRelative.Value;
				Tweener tweener8 = tween.From(value10);
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
				State.Debug("DOTween RigidBody2D Rotate");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x600050C")]
		[Address(RVA = "0xA211A8", Offset = "0xA211A8", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EF4068]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021D75]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenRigidbody2DRotate()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
