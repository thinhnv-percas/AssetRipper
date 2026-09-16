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
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x74FE84", Offset = "0x74FE84")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x74FE84", Offset = "0x74FE84")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x74FE84", Offset = "0x74FE84")]
	[Token(Token = "0x20000D5")]
	public class DOTweenRigidbody2DMove : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x784330", Offset = "0x784330")]
		[Token(Token = "0x40009B7")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7843A4", Offset = "0x7843A4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7843A4", Offset = "0x7843A4")]
		[Token(Token = "0x40009B8")]
		[FieldOffset(Offset = "0x58")]
		public Target target;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x784404", Offset = "0x784404")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x784404", Offset = "0x784404")]
		[Token(Token = "0x40009B9")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector2 to;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x784454", Offset = "0x784454")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x784454", Offset = "0x784454")]
		[Token(Token = "0x40009BA")]
		[FieldOffset(Offset = "0x68")]
		public FsmGameObject toGameObject;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7844A4", Offset = "0x7844A4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7844A4", Offset = "0x7844A4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7844A4", Offset = "0x7844A4")]
		[Token(Token = "0x40009BB")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool snapping;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x784518", Offset = "0x784518")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x784518", Offset = "0x784518")]
		[Token(Token = "0x40009BC")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool setRelative;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x784568", Offset = "0x784568")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x784568", Offset = "0x784568")]
		[Token(Token = "0x40009BD")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7845C8", Offset = "0x7845C8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7845C8", Offset = "0x7845C8")]
		[Token(Token = "0x40009BE")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x784618", Offset = "0x784618")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x784618", Offset = "0x784618")]
		[Token(Token = "0x40009BF")]
		[FieldOffset(Offset = "0x90")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x784668", Offset = "0x784668")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x784668", Offset = "0x784668")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x784668", Offset = "0x784668")]
		[Token(Token = "0x40009C0")]
		[FieldOffset(Offset = "0x98")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7846DC", Offset = "0x7846DC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7846DC", Offset = "0x7846DC")]
		[Token(Token = "0x40009C1")]
		[FieldOffset(Offset = "0xA0")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x78472C", Offset = "0x78472C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78472C", Offset = "0x78472C")]
		[Token(Token = "0x40009C2")]
		[FieldOffset(Offset = "0xA8")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78477C", Offset = "0x78477C")]
		[Token(Token = "0x40009C3")]
		[FieldOffset(Offset = "0xB0")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x784790", Offset = "0x784790")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x784790", Offset = "0x784790")]
		[Token(Token = "0x40009C4")]
		[FieldOffset(Offset = "0xB8")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7847E0", Offset = "0x7847E0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7847E0", Offset = "0x7847E0")]
		[Token(Token = "0x40009C5")]
		[FieldOffset(Offset = "0xC0")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x784830", Offset = "0x784830")]
		[Token(Token = "0x40009C6")]
		[FieldOffset(Offset = "0xC8")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x784868", Offset = "0x784868")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x784868", Offset = "0x784868")]
		[Token(Token = "0x40009C7")]
		[FieldOffset(Offset = "0xD0")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7848B8", Offset = "0x7848B8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7848B8", Offset = "0x7848B8")]
		[Token(Token = "0x40009C8")]
		[FieldOffset(Offset = "0xD8")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x784908", Offset = "0x784908")]
		[Token(Token = "0x40009C9")]
		[FieldOffset(Offset = "0xE0")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x784940", Offset = "0x784940")]
		[Token(Token = "0x40009CA")]
		[FieldOffset(Offset = "0xE4")]
		public Ease easeType;

		[Token(Token = "0x40009CB")]
		[FieldOffset(Offset = "0xE8")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x784978", Offset = "0x784978")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x784978", Offset = "0x784978")]
		[Token(Token = "0x40009CC")]
		[FieldOffset(Offset = "0xF0")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7849C8", Offset = "0x7849C8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7849C8", Offset = "0x7849C8")]
		[Token(Token = "0x40009CD")]
		[FieldOffset(Offset = "0xF8")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x784A18", Offset = "0x784A18")]
		[Token(Token = "0x40009CE")]
		[FieldOffset(Offset = "0x100")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x784A50", Offset = "0x784A50")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x784A50", Offset = "0x784A50")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x784A50", Offset = "0x784A50")]
		[Token(Token = "0x40009CF")]
		[FieldOffset(Offset = "0x108")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x784AC4", Offset = "0x784AC4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x784AC4", Offset = "0x784AC4")]
		[Token(Token = "0x40009D0")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x784B14", Offset = "0x784B14")]
		[Token(Token = "0x40009D1")]
		[FieldOffset(Offset = "0x118")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x784B4C", Offset = "0x784B4C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x784B4C", Offset = "0x784B4C")]
		[Token(Token = "0x40009D2")]
		[FieldOffset(Offset = "0x120")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x784B9C", Offset = "0x784B9C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x784B9C", Offset = "0x784B9C")]
		[Token(Token = "0x40009D3")]
		[FieldOffset(Offset = "0x128")]
		public FsmBool debugThis;

		[Token(Token = "0x40009D4")]
		[FieldOffset(Offset = "0x130")]
		private Tweener tween;

		[Token(Token = "0x60004FB")]
		[Address(RVA = "0xA1F290", Offset = "0xA1F290", Length = "0x2E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1F02958]);\n\tv25 = *([v24 @ X8_v14]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021D6A]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.FsmVector2::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.to = v50;\n\tv57 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.FsmGameObject::.ctor(v57);\n\tv57.useVariable = 0;\n\tthis.toGameObject = v57;\n\tv82 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v82);\n\tv82.useVariable = 0;\n\tthis.duration = v82;\n\tv83 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v83);\n\tv83.useVariable = 0;\n\tv83.value = 0;\n\tthis.setSpeedBased = v83;\n\tv84 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v84);\n\tv84.useVariable = 0;\n\tv84.value = 0;\n\tthis.snapping = v84;\n\tv85 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v85);\n\tv85.useVariable = 0;\n\tv85.value = 0;\n\tthis.setRelative = v85;\n\tv86 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v86);\n\tv86.useVariable = 0;\n\tv86.value = 0;\n\tthis.playInReverse = v86;\n\tv87 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v87);\n\tv87.useVariable = 0;\n\tv87.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v87;\n\tv88 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v88);\n\tv88.useVariable = 0;\n\tv88.value = 0;\n\tthis.finishImmediately = v88;\n\tv89 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v89);\n\tv89.useVariable = 0;\n\tthis.stringAsId = v89;\n\tv90 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v90);\n\tv90.useVariable = 0;\n\tthis.tagAsId = v90;\n\tv91 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v91);\n\tv91.value = 0f;\n\tthis.startDelay = v91;\n\tthis.selectedEase = 0x100000000;\n\tv92 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v92);\n\tv92.value = 0;\n\tthis.loops = v92;\n\tthis.loopType = 0;\n\tv93 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v93);\n\tv93.value = 1;\n\tthis.autoKillOnCompletion = v93;\n\tv94 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v94);\n\tv94.value = 0;\n\tthis.recyclable = v94;\n\tthis.updateType = 0;\n\tv95 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v95);\n\tv95.value = 0;\n\tthis.isIndependentUpdate = v95;\n\tv96 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v96);\n\tv96.value = 0;\n\tthis.debugThis = v96;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 126 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_023b: Expected I4, but got I8
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
			duration = fsmFloat;
			FsmBool fsmBool = new FsmBool();
			fsmBool.useVariable = false;
			fsmBool.value = false;
			setSpeedBased = fsmBool;
			FsmBool fsmBool2 = new FsmBool();
			fsmBool2.useVariable = false;
			fsmBool2.value = false;
			snapping = fsmBool2;
			FsmBool fsmBool3 = new FsmBool();
			fsmBool3.useVariable = false;
			fsmBool3.value = false;
			setRelative = fsmBool3;
			FsmBool fsmBool4 = new FsmBool();
			fsmBool4.useVariable = false;
			fsmBool4.value = false;
			playInReverse = fsmBool4;
			FsmBool fsmBool5 = new FsmBool();
			fsmBool5.useVariable = false;
			fsmBool5.value = false;
			startEvent = null;
			finishEvent = null;
			setReverseRelative = fsmBool5;
			FsmBool fsmBool6 = new FsmBool();
			fsmBool6.useVariable = false;
			fsmBool6.value = false;
			finishImmediately = fsmBool6;
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
			FsmBool fsmBool7 = new FsmBool();
			fsmBool7.value = true;
			autoKillOnCompletion = fsmBool7;
			FsmBool fsmBool8 = new FsmBool();
			fsmBool8.value = false;
			recyclable = fsmBool8;
			updateType = default(UpdateType);
			FsmBool fsmBool9 = new FsmBool();
			fsmBool9.value = false;
			isIndependentUpdate = fsmBool9;
			FsmBool fsmBool10 = new FsmBool();
			fsmBool10.value = false;
			debugThis = fsmBool10;
		}

		[Token(Token = "0x60004FC")]
		[Address(RVA = "0xA1F578", Offset = "0xA1F578", Length = "0x4A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv30 = *([1EB5878]);\n\tv31 = *([v30 @ X8_v62]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2021D6B]) = v50;\nL_001E:\n\tv56 = this.target == 1;\n\tif (v56) goto L_0042;\n\tv61 = this.target == 0;\n\tv62 = ~v61;\n\tif (v62) goto L_008A;\n\tv176 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv260 = UnityEngine.GameObject::GetComponent(v176);\n\tv214 = this.to;\n\tv340 = this.duration;\n\tv84 = v214.value;\n\tv82 = v214.value.y;\n\tgoto L_0076;\nL_0042:\n\tv101 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv261 = UnityEngine.GameObject::GetComponent(v101);\n\tv178 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.toGameObject);\n\tv179 = UnityEngine.GameObject::get_transform(v178);\n\tv346 = UnityEngine.Transform::get_position(v179);\n\tgoto L_006E;\n\tv361 = *([v355 @ X0_v80+E0]);\n\tv362 = v361 == 0;\n\tv363 = ~v362;\n\tif (v363) goto L_006E;\n\tv365 = \"il2cpp_codegen_runtime_class_init\"(v355, v161, v100, v35, v36, v37, v38, v39, v346, v349, v350, v43, v44, v45, v46, v47);\nL_006E:\n\tv136 = UnityEngine.Vector2::op_Implicit(v346);\n\tv340 = this.duration;\nL_0076:\n\tv137 = HutongGames.PlayMaker.FsmFloat::get_Value(v340);\n\tv348 = HutongGames.PlayMaker.FsmBool::get_Value(this.snapping);\n\t// 131 MakeStruct v68 @ AGGA1F6EC_1_v4 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v84 @ V8_v6 (UnityEngine.Vector2), v82 @ V9_v6 (System.Single)\n\tv90 = DG.Tweening.DOTweenModulePhysics2D::DOMove(v96, v68, v137, v348);\n\tthis.tween = v90;\nL_008A:\n\tv241 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv270 = v241 == 0;\n\tif (v270) goto L_0098;\n\tv279 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_0098:\n\tv330 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv334 = DG.Tweening.TweenSettingsExtensions::SetRelative(this.tween, v330);\n\tv344 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v344);\n\tv138 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv373 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v138);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv376 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv379 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v376, this.loopType);\n\tv381 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv384 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v381);\n\tv386 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv389 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v386);\n\tv391 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv394 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v391);\n\tv395 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv397 = v395 == 0;\n\tif (v397) goto L_0109;\n\tv412 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv403 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v412);\nL_0109:\n\tv410 = this.startEvent == 0;\n\tif (v410) goto L_0121;\n\tv417 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v417, this, Il2CppMethodInfo);\n\tv423 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v417);\nL_0121:\n\tv432 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv436 = v432 == 0;\n\tv437 = ~v436;\n\tif (v437) goto L_0143;\n\tv443 = new DG.Tweening.TweenCallback();\n\tv452 = this.finishEvent == 0;\n\tif (v452) goto L_FFFFFFFF;\n\tgoto L_0138;\nL_0138:\n\tDG.Tweening.TweenCallback::.ctor(v443, this, *([v464 @ X8_v29 (Il2CppMethodInfo)]));\n\tv450 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v443);\nL_0143:\n\tv457 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv463 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv469 = v463 == 0;\n\tif (v469) goto L_0156;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween RigidBody2D Move\");\nL_0156:\n\tv316 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv318 = v316 == 0;\n\tif (v318) goto L_0174;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0174:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 288 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			FsmFloat fsmFloat;
			Vector2 vector;
			float y;
			Rigidbody2D rigidbody2D;
			if (target != Target.GameObject)
			{
				if (target != Target.Value)
				{
					goto IL_01aa;
				}
				GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
				Rigidbody2D component = ownerDefaultTarget.GetComponent<Rigidbody2D>();
				FsmVector2 fsmVector = to;
				fsmFloat = duration;
				vector = fsmVector.value;
				y = fsmVector.value.y;
				rigidbody2D = component;
			}
			else
			{
				GameObject ownerDefaultTarget2 = Fsm.GetOwnerDefaultTarget(gameObject);
				Rigidbody2D component2 = ownerDefaultTarget2.GetComponent<Rigidbody2D>();
				GameObject value = toGameObject.Value;
				Transform transform = value.transform;
				Vector3 position = transform.position;
				Vector2 vector2 = position;
				fsmFloat = duration;
				y = vector2.y;
				vector = vector2;
				rigidbody2D = component2;
			}
			float value2 = fsmFloat.Value;
			bool value3 = snapping.Value;
			Vector2 endValue = default(Vector2);
			endValue.x = vector.x;
			endValue.y = y;
			TweenerCore<Vector2, Vector2, VectorOptions> tweenerCore = rigidbody2D.DOMove(endValue, value2, value3);
			tween = tweenerCore;
			goto IL_01aa;
			IL_01aa:
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
				State.Debug("DOTween RigidBody2D Move");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x60004FD")]
		[Address(RVA = "0xA1FA20", Offset = "0xA1FA20", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ED16D8]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021D6C]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenRigidbody2DMove()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
