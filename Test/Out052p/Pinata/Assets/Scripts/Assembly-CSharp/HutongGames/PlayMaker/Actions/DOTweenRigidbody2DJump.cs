using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using Doozy.PlayMaker;
using Doozy.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74FE00", Offset = "0x74FE00")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x74FE00", Offset = "0x74FE00")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x74FE00", Offset = "0x74FE00")]
	[Token(Token = "0x20000D4")]
	public class DOTweenRigidbody2DJump : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x783B18", Offset = "0x783B18")]
		[Token(Token = "0x400099B")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x783B8C", Offset = "0x783B8C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x783B8C", Offset = "0x783B8C")]
		[Token(Token = "0x400099C")]
		[FieldOffset(Offset = "0x58")]
		public Target target;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x783BEC", Offset = "0x783BEC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x783BEC", Offset = "0x783BEC")]
		[Token(Token = "0x400099D")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector2 to;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x783C3C", Offset = "0x783C3C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x783C3C", Offset = "0x783C3C")]
		[Token(Token = "0x400099E")]
		[FieldOffset(Offset = "0x68")]
		public FsmGameObject toGameObject;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x783C8C", Offset = "0x783C8C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x783C8C", Offset = "0x783C8C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x783C8C", Offset = "0x783C8C")]
		[Token(Token = "0x400099F")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool snapping;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x783D00", Offset = "0x783D00")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x783D00", Offset = "0x783D00")]
		[Token(Token = "0x40009A0")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat jumpPower;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x783D60", Offset = "0x783D60")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x783D60", Offset = "0x783D60")]
		[Token(Token = "0x40009A1")]
		[FieldOffset(Offset = "0x80")]
		public FsmInt numJumps;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x783DC0", Offset = "0x783DC0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x783DC0", Offset = "0x783DC0")]
		[Token(Token = "0x40009A2")]
		[FieldOffset(Offset = "0x88")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x783E20", Offset = "0x783E20")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x783E20", Offset = "0x783E20")]
		[Token(Token = "0x40009A3")]
		[FieldOffset(Offset = "0x90")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x783E70", Offset = "0x783E70")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x783E70", Offset = "0x783E70")]
		[Token(Token = "0x40009A4")]
		[FieldOffset(Offset = "0x98")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x783EC0", Offset = "0x783EC0")]
		[Token(Token = "0x40009A5")]
		[FieldOffset(Offset = "0xA0")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x783ED4", Offset = "0x783ED4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x783ED4", Offset = "0x783ED4")]
		[Token(Token = "0x40009A6")]
		[FieldOffset(Offset = "0xA8")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x783F24", Offset = "0x783F24")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x783F24", Offset = "0x783F24")]
		[Token(Token = "0x40009A7")]
		[FieldOffset(Offset = "0xB0")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x783F74", Offset = "0x783F74")]
		[Token(Token = "0x40009A8")]
		[FieldOffset(Offset = "0xB8")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x783FAC", Offset = "0x783FAC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x783FAC", Offset = "0x783FAC")]
		[Token(Token = "0x40009A9")]
		[FieldOffset(Offset = "0xC0")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x783FFC", Offset = "0x783FFC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x783FFC", Offset = "0x783FFC")]
		[Token(Token = "0x40009AA")]
		[FieldOffset(Offset = "0xC8")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x78404C", Offset = "0x78404C")]
		[Token(Token = "0x40009AB")]
		[FieldOffset(Offset = "0xD0")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x784084", Offset = "0x784084")]
		[Token(Token = "0x40009AC")]
		[FieldOffset(Offset = "0xD4")]
		public Ease easeType;

		[Token(Token = "0x40009AD")]
		[FieldOffset(Offset = "0xD8")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7840BC", Offset = "0x7840BC")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7840BC", Offset = "0x7840BC")]
		[Token(Token = "0x40009AE")]
		[FieldOffset(Offset = "0xE0")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78410C", Offset = "0x78410C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78410C", Offset = "0x78410C")]
		[Token(Token = "0x40009AF")]
		[FieldOffset(Offset = "0xE8")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78415C", Offset = "0x78415C")]
		[Token(Token = "0x40009B0")]
		[FieldOffset(Offset = "0xF0")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x784194", Offset = "0x784194")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x784194", Offset = "0x784194")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x784194", Offset = "0x784194")]
		[Token(Token = "0x40009B1")]
		[FieldOffset(Offset = "0xF8")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x784208", Offset = "0x784208")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x784208", Offset = "0x784208")]
		[Token(Token = "0x40009B2")]
		[FieldOffset(Offset = "0x100")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x784258", Offset = "0x784258")]
		[Token(Token = "0x40009B3")]
		[FieldOffset(Offset = "0x108")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x784290", Offset = "0x784290")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x784290", Offset = "0x784290")]
		[Token(Token = "0x40009B4")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7842E0", Offset = "0x7842E0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7842E0", Offset = "0x7842E0")]
		[Token(Token = "0x40009B5")]
		[FieldOffset(Offset = "0x118")]
		public FsmBool debugThis;

		[Token(Token = "0x40009B6")]
		[FieldOffset(Offset = "0x120")]
		private Sequence sequence;

		[Token(Token = "0x60004F6")]
		[Address(RVA = "0xA1EA74", Offset = "0xA1EA74", Length = "0x298")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1F0BE20]);\n\tv27 = *([v26 @ X8_v12]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2021D67]) = v46;\nL_0019:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv52 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.FsmVector2::.ctor(v52);\n\tv52.useVariable = 0;\n\tthis.to = v52;\n\tv59 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.FsmGameObject::.ctor(v59);\n\tv59.useVariable = 0;\n\tthis.toGameObject = v59;\n\tv84 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v84);\n\tv84.useVariable = 0;\n\tthis.jumpPower = v84;\n\tv85 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v85);\n\tv85.useVariable = 0;\n\tthis.numJumps = v85;\n\tv86 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v86);\n\tv86.useVariable = 0;\n\tthis.duration = v86;\n\tv87 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v87);\n\tv87.useVariable = 0;\n\tv87.value = 0;\n\tthis.snapping = v87;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tv88 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v88);\n\tv88.useVariable = 0;\n\tv88.value = 0;\n\tthis.finishImmediately = v88;\n\tv89 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v89);\n\tv89.useVariable = 0;\n\tthis.stringAsId = v89;\n\tv90 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v90);\n\tv90.useVariable = 0;\n\tthis.tagAsId = v90;\n\tv91 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v91);\n\tv91.value = 0f;\n\tthis.startDelay = v91;\n\tthis.selectedEase = 0x100000000;\n\tv92 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v92);\n\tv92.value = 0;\n\tthis.loops = v92;\n\tthis.loopType = 0;\n\tv93 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v93);\n\tv93.value = 1;\n\tthis.autoKillOnCompletion = v93;\n\tv94 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v94);\n\tv94.value = 0;\n\tthis.recyclable = v94;\n\tthis.updateType = 0;\n\tv95 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v95);\n\tv95.value = 0;\n\tthis.isIndependentUpdate = v95;\n\tv96 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v96);\n\tv96.value = 0;\n\tthis.debugThis = v96;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 118 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_01b5: Expected I4, but got I8
			base.Reset();
			gameObject = null;
			FsmVector2 fsmVector = new FsmVector2();
			fsmVector.useVariable = false;
			to = fsmVector;
			FsmGameObject fsmGameObject = new FsmGameObject();
			fsmGameObject.useVariable = false;
			toGameObject = fsmGameObject;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = false;
			jumpPower = fsmFloat;
			FsmInt fsmInt = new FsmInt();
			fsmInt.useVariable = false;
			numJumps = fsmInt;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = false;
			duration = fsmFloat2;
			FsmBool fsmBool = new FsmBool();
			fsmBool.useVariable = false;
			fsmBool.value = false;
			snapping = fsmBool;
			startEvent = null;
			finishEvent = null;
			FsmBool fsmBool2 = new FsmBool();
			fsmBool2.useVariable = false;
			fsmBool2.value = false;
			finishImmediately = fsmBool2;
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
			FsmInt fsmInt2 = new FsmInt();
			fsmInt2.Value = 0;
			loops = fsmInt2;
			loopType = default(LoopType);
			FsmBool fsmBool3 = new FsmBool();
			fsmBool3.value = true;
			autoKillOnCompletion = fsmBool3;
			FsmBool fsmBool4 = new FsmBool();
			fsmBool4.value = false;
			recyclable = fsmBool4;
			updateType = default(UpdateType);
			FsmBool fsmBool5 = new FsmBool();
			fsmBool5.value = false;
			isIndependentUpdate = fsmBool5;
			FsmBool fsmBool6 = new FsmBool();
			fsmBool6.value = false;
			debugThis = fsmBool6;
		}

		[Token(Token = "0x60004F7")]
		[Address(RVA = "0xA1ED0C", Offset = "0xA1ED0C", Length = "0x4D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv32 = *([1ECCE30]);\n\tv33 = *([v32 @ X8_v56]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2021D68]) = v52;\nL_0020:\n\tgoto L_0027;\n\tv59 = *([v55 @ X0_v2+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tgoto L_0027;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v55, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_0027:\n\tv67 = DG.Tweening.DOTween::Sequence();\n\tthis.sequence = v67;\n\tv70 = this.target == 0;\n\tif (v70) goto L_008D;\n\tv80 = this.target != 1;\n\tif (v80) goto L_00C7;\n\tv194 = this + 0x30;\n\tv223 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv454 = UnityEngine.GameObject::GetComponent(v223);\n\tv224 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.toGameObject);\n\tv225 = UnityEngine.GameObject::get_transform(v224);\n\tv144 = UnityEngine.Transform::get_position(v225);\n\tv227 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.toGameObject);\n\tv228 = UnityEngine.GameObject::get_transform(v227);\n\tv459 = UnityEngine.Transform::get_position(v228);\n\tv128 = 0;\n\tv463 = 0x1588A6C(&v128 @ stack_-38_v5 (UnityEngine.Vector2), 0, 0, v37, v38, v39, v40, v41, v144, v459.y, v459.z, v45, v46, v47, v48, v49);\n\tv146 = HutongGames.PlayMaker.FsmFloat::get_Value(this.jumpPower);\n\tv351 = HutongGames.PlayMaker.FsmInt::get_Value(this.numJumps);\n\tv147 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tv505 = HutongGames.PlayMaker.FsmBool::get_Value(this.snapping);\n\tgoto L_00C0;\nL_008D:\n\tv194 = this + 0x30;\n\tv92 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv454 = UnityEngine.GameObject::GetComponent(v92);\n\tv270 = this.to;\n\tv148 = HutongGames.PlayMaker.FsmFloat::get_Value(this.jumpPower);\n\tv353 = HutongGames.PlayMaker.FsmInt::get_Value(this.numJumps);\n\tv149 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tv433 = HutongGames.PlayMaker.FsmBool::get_Value(this.snapping);\nL_00C0:\n\t// 192 MakeStruct v289 @ AGGA1EF44_1_v2 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v300 @ V0_v3 (UnityEngine.Vector2), v299 @ V1_v2 (System.Single)\n\tv456 = DG.Tweening.DOTweenModulePhysics2D::DOJump(v454, v289, v298, v452, v293, v450);\n\tv315 = DG.Tweening.TweenSettingsExtensions::Append(v67, v456);\n\tgoto L_00D1;\nL_00C7:\n\tv194 = this + 0x30;\nL_00D1:\n\tv365 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([v194 @ X23_v1]), this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.sequence, this.tweenIdType, this.stringAsId, this.tagAsId, v365);\n\tv151 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv424 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.sequence, v151);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.sequence, this.selectedEase, this.easeType, this.animationCurve);\n\tv427 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv431 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.sequence, v427, this.loopType);\n\tv435 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv445 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.sequence, v435);\n\tv461 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv466 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.sequence, v461);\n\tv470 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv477 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.sequence, this.updateType, v470);\n\tv479 = this.startEvent == 0;\n\tif (v479) goto L_0136;\n\tv484 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v484, this, Il2CppMethodInfo);\n\tv490 = DG.Tweening.TweenSettingsExtensions::OnStart(this.sequence, v484);\nL_0136:\n\tv498 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv502 = v498 == 0;\n\tv503 = ~v502;\n\tif (v503) goto L_0158;\n\tv511 = new DG.Tweening.TweenCallback();\n\tv520 = this.finishEvent == 0;\n\tif (v520) goto L_FFFFFFFF;\n\tgoto L_014D;\nL_014D:\n\tDG.Tweening.TweenCallback::.ctor(v511, this, *([v533 @ X8_v29 (Il2CppMethodInfo)]));\n\tv518 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.sequence, v511);\nL_0158:\n\tv525 = DG.Tweening.TweenExtensions::Play(this.sequence);\n\tv532 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv538 = v532 == 0;\n\tif (v538) goto L_016B;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween RigidBody2D Jump\");\nL_016B:\n\tv548 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv411 = v548 == 0;\n\tif (v411) goto L_017E;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\nL_017E:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 299 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			//IL_01a8: Expected O, but got I
			//IL_027e: Expected O, but got I
			//IL_0065: Expected O, but got I
			Sequence s = (this.sequence = DOTween.Sequence());
			object obj;
			Rigidbody2D component;
			float num;
			float num2;
			float y;
			Vector2 vector2;
			bool flag;
			int num4;
			if (target != Target.Value)
			{
				if (target != Target.GameObject)
				{
					obj = (long)(IntPtr)this + 48L;
					goto IL_0283;
				}
				obj = (long)(IntPtr)this + 48L;
				GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
				component = ownerDefaultTarget.GetComponent<Rigidbody2D>();
				GameObject value = toGameObject.Value;
				Transform transform = value.transform;
				Vector3 position = transform.position;
				GameObject value2 = toGameObject.Value;
				Transform transform2 = value2.transform;
				Vector3 position2 = transform2.position;
				Vector2 vector = default(Vector2);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
				float value3 = jumpPower.Value;
				int value4 = numJumps.Value;
				float value5 = duration.Value;
				bool value6 = snapping.Value;
				num = value5;
				num2 = value3;
				float num3 = default(float);
				y = num3;
				vector2 = default(Vector2);
				flag = value6;
				num4 = value4;
			}
			else
			{
				obj = (long)(IntPtr)this + 48L;
				GameObject ownerDefaultTarget2 = Fsm.GetOwnerDefaultTarget(gameObject);
				component = ownerDefaultTarget2.GetComponent<Rigidbody2D>();
				FsmVector2 fsmVector = to;
				float value7 = jumpPower.Value;
				int value8 = numJumps.Value;
				float value9 = duration.Value;
				bool value10 = snapping.Value;
				num = value9;
				num2 = value7;
				y = fsmVector.value.y;
				vector2 = fsmVector.value;
				flag = value10;
				num4 = value8;
			}
			Vector2 endValue = default(Vector2);
			endValue.x = vector2.x;
			endValue.y = y;
			Sequence t = component.DOJump(endValue, num2, num4, num, flag);
			Sequence sequence = s.Append(t);
			goto IL_0283;
			IL_0283:
			GameObject ownerDefaultTarget3 = ((Fsm)obj).GetOwnerDefaultTarget(gameObject);
			this.sequence.SetTweenId(tweenIdType, stringAsId, tagAsId, ownerDefaultTarget3);
			float value11 = startDelay.Value;
			Sequence sequence2 = this.sequence.SetDelay(value11);
			this.sequence.SetSelectedEase(selectedEase, easeType, animationCurve);
			int value12 = loops.Value;
			Sequence sequence3 = this.sequence.SetLoops(value12, loopType);
			bool value13 = autoKillOnCompletion.Value;
			Sequence sequence4 = this.sequence.SetAutoKill(value13);
			bool value14 = recyclable.Value;
			Sequence sequence5 = this.sequence.SetRecyclable(value14);
			bool value15 = isIndependentUpdate.Value;
			Sequence sequence6 = this.sequence.SetUpdate(updateType, value15);
			if (startEvent != null)
			{
				TweenCallback action = delegate
				{
					Fsm.Event(startEvent);
				};
				Sequence sequence7 = this.sequence.OnStart(action);
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
				Sequence sequence8 = this.sequence.OnComplete(action2);
			}
			Sequence sequence9 = this.sequence.Play();
			if (debugThis.Value)
			{
				State.Debug("DOTween RigidBody2D Jump");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x60004F8")]
		[Address(RVA = "0xA1F1E0", Offset = "0xA1F1E0", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EDCAD0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021D69]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenRigidbody2DJump()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
