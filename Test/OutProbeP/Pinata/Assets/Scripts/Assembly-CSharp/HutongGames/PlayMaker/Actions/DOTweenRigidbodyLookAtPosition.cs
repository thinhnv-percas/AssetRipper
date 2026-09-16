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
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75019C", Offset = "0x75019C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75019C", Offset = "0x75019C")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x75019C", Offset = "0x75019C")]
	[Token(Token = "0x20000DB")]
	public class DOTweenRigidbodyLookAtPosition : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x787668", Offset = "0x787668")]
		[Token(Token = "0x4000A68")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7876DC", Offset = "0x7876DC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7876DC", Offset = "0x7876DC")]
		[Token(Token = "0x4000A69")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 position;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78773C", Offset = "0x78773C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78773C", Offset = "0x78773C")]
		[Token(Token = "0x4000A6A")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool setRelative;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78778C", Offset = "0x78778C")]
		[Token(Token = "0x4000A6B")]
		[FieldOffset(Offset = "0x68")]
		public AxisConstraint axisConstraint;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7877C4", Offset = "0x7877C4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7877C4", Offset = "0x7877C4")]
		[Token(Token = "0x4000A6C")]
		[FieldOffset(Offset = "0x70")]
		public FsmVector3 up;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x787814", Offset = "0x787814")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x787814", Offset = "0x787814")]
		[Token(Token = "0x4000A6D")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x787874", Offset = "0x787874")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x787874", Offset = "0x787874")]
		[Token(Token = "0x4000A6E")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7878C4", Offset = "0x7878C4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7878C4", Offset = "0x7878C4")]
		[Token(Token = "0x4000A6F")]
		[FieldOffset(Offset = "0x88")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x787914", Offset = "0x787914")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x787914", Offset = "0x787914")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x787914", Offset = "0x787914")]
		[Token(Token = "0x4000A70")]
		[FieldOffset(Offset = "0x90")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x787988", Offset = "0x787988")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x787988", Offset = "0x787988")]
		[Token(Token = "0x4000A71")]
		[FieldOffset(Offset = "0x98")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7879D8", Offset = "0x7879D8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7879D8", Offset = "0x7879D8")]
		[Token(Token = "0x4000A72")]
		[FieldOffset(Offset = "0xA0")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x787A28", Offset = "0x787A28")]
		[Token(Token = "0x4000A73")]
		[FieldOffset(Offset = "0xA8")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x787A3C", Offset = "0x787A3C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x787A3C", Offset = "0x787A3C")]
		[Token(Token = "0x4000A74")]
		[FieldOffset(Offset = "0xB0")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x787A8C", Offset = "0x787A8C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x787A8C", Offset = "0x787A8C")]
		[Token(Token = "0x4000A75")]
		[FieldOffset(Offset = "0xB8")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x787ADC", Offset = "0x787ADC")]
		[Token(Token = "0x4000A76")]
		[FieldOffset(Offset = "0xC0")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x787B14", Offset = "0x787B14")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x787B14", Offset = "0x787B14")]
		[Token(Token = "0x4000A77")]
		[FieldOffset(Offset = "0xC8")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x787B64", Offset = "0x787B64")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x787B64", Offset = "0x787B64")]
		[Token(Token = "0x4000A78")]
		[FieldOffset(Offset = "0xD0")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x787BB4", Offset = "0x787BB4")]
		[Token(Token = "0x4000A79")]
		[FieldOffset(Offset = "0xD8")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x787BEC", Offset = "0x787BEC")]
		[Token(Token = "0x4000A7A")]
		[FieldOffset(Offset = "0xDC")]
		public Ease easeType;

		[Token(Token = "0x4000A7B")]
		[FieldOffset(Offset = "0xE0")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x787C24", Offset = "0x787C24")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x787C24", Offset = "0x787C24")]
		[Token(Token = "0x4000A7C")]
		[FieldOffset(Offset = "0xE8")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x787C74", Offset = "0x787C74")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x787C74", Offset = "0x787C74")]
		[Token(Token = "0x4000A7D")]
		[FieldOffset(Offset = "0xF0")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x787CC4", Offset = "0x787CC4")]
		[Token(Token = "0x4000A7E")]
		[FieldOffset(Offset = "0xF8")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x787CFC", Offset = "0x787CFC")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x787CFC", Offset = "0x787CFC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x787CFC", Offset = "0x787CFC")]
		[Token(Token = "0x4000A7F")]
		[FieldOffset(Offset = "0x100")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x787D70", Offset = "0x787D70")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x787D70", Offset = "0x787D70")]
		[Token(Token = "0x4000A80")]
		[FieldOffset(Offset = "0x108")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x787DC0", Offset = "0x787DC0")]
		[Token(Token = "0x4000A81")]
		[FieldOffset(Offset = "0x110")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x787DF8", Offset = "0x787DF8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x787DF8", Offset = "0x787DF8")]
		[Token(Token = "0x4000A82")]
		[FieldOffset(Offset = "0x118")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x787E48", Offset = "0x787E48")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x787E48", Offset = "0x787E48")]
		[Token(Token = "0x4000A83")]
		[FieldOffset(Offset = "0x120")]
		public FsmBool debugThis;

		[Token(Token = "0x4000A84")]
		[FieldOffset(Offset = "0x128")]
		private Tweener tween;

		[Token(Token = "0x6000519")]
		[Address(RVA = "0xA2220C", Offset = "0xA2220C", Length = "0x2F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EF1850]);\n\tv25 = *([v24 @ X8_v15]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021D7C]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.position = v50;\n\tv57 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v57);\n\tv57.useVariable = 0;\n\tthis.duration = v57;\n\tv86 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v86);\n\tv86.useVariable = 0;\n\tv86.value = 0;\n\tthis.setSpeedBased = v86;\n\tthis.axisConstraint = 0;\n\tv87 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v87);\n\tv87.useVariable = 0;\n\tgoto L_0052;\n\tv168 = *([v164 @ X0_v14+E0]);\n\tv169 = v168 == 0;\n\tv170 = ~v169;\n\tif (v170) goto L_0052;\n\tv172 = \"il2cpp_codegen_runtime_class_init\"(v164, v70, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0052:\n\tv63 = UnityEngine.Vector3::get_up();\n\tv87.value = v63;\n\tv87.value.y = v63.y;\n\tv87.value.z = v63.z;\n\tthis.up = v87;\n\tv88 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v88);\n\tv88.useVariable = 0;\n\tv88.value = 0;\n\tthis.setRelative = v88;\n\tv89 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v89);\n\tv89.useVariable = 0;\n\tv89.value = 0;\n\tthis.playInReverse = v89;\n\tv90 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v90);\n\tv90.useVariable = 0;\n\tv90.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v90;\n\tv91 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v91);\n\tv91.useVariable = 0;\n\tv91.value = 0;\n\tthis.finishImmediately = v91;\n\tv92 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v92);\n\tv92.useVariable = 0;\n\tthis.stringAsId = v92;\n\tv93 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v93);\n\tv93.useVariable = 0;\n\tthis.tagAsId = v93;\n\tv94 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v94);\n\tv94.value = 0f;\n\tthis.startDelay = v94;\n\tthis.selectedEase = 0x100000000;\n\tv95 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v95);\n\tv95.value = 0;\n\tthis.loops = v95;\n\tthis.loopType = 0;\n\tv96 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v96);\n\tv96.value = 1;\n\tthis.autoKillOnCompletion = v96;\n\tv97 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v97);\n\tv97.value = 0;\n\tthis.recyclable = v97;\n\tthis.updateType = 0;\n\tv98 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v98);\n\tv98.value = 0;\n\tthis.isIndependentUpdate = v98;\n\tv99 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v99);\n\tv99.value = 0;\n\tthis.debugThis = v99;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 128 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_0268: Expected I4, but got I8
			base.Reset();
			gameObject = null;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = false;
			position = fsmVector;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = false;
			duration = fsmFloat;
			FsmBool fsmBool = new FsmBool();
			fsmBool.useVariable = false;
			fsmBool.value = false;
			setSpeedBased = fsmBool;
			axisConstraint = default(AxisConstraint);
			FsmVector3 fsmVector2 = new FsmVector3();
			fsmVector2.useVariable = false;
			Vector3 vector = (fsmVector2.value = Vector3.up);
			fsmVector2.value.y = vector.y;
			fsmVector2.value.z = vector.z;
			up = fsmVector2;
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

		[Token(Token = "0x600051A")]
		[Address(RVA = "0xA224FC", Offset = "0xA224FC", Length = "0x418")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv32 = *([1EB3050]);\n\tv33 = *([v32 @ X8_v54]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2021D7D]) = v52;\nL_001F:\n\tv57 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv217 = UnityEngine.GameObject::GetComponent(v57);\n\tv109 = HutongGames.PlayMaker.FsmVector3::get_Value(this.position);\n\tv110 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tv271 = HutongGames.PlayMaker.FsmVector3::get_Value(this.up);\n\tv87 = 0;\n\tv278 = 0x115D2C0(&v87 @ stack_-70_v3 (System.Nullable`1<UnityEngine.Vector3>), Il2CppMethodInfo, 0, v37, v38, v39, v40, v41, v271, v271.y, v271.z, v45, v46, v47, v48, v49);\n\tv218 = DG.Tweening.DOTweenModulePhysics::DOLookAt(v217, v109, v110, this.axisConstraint, 0);\n\tthis.tween = v218;\n\tv282 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv284 = v282 == 0;\n\tif (v284) goto L_0066;\n\tv289 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_0066:\n\tv292 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv295 = DG.Tweening.TweenSettingsExtensions::SetRelative(this.tween, v292);\n\tv298 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v298);\n\tv112 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv304 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v112);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv307 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv310 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v307, this.loopType);\n\tv312 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv315 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v312);\n\tv317 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv320 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v317);\n\tv322 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv325 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v322);\n\tv326 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv328 = v326 == 0;\n\tif (v328) goto L_00D7;\n\tv343 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv334 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v343);\nL_00D7:\n\tv341 = this.startEvent == 0;\n\tif (v341) goto L_00EF;\n\tv348 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v348, this, Il2CppMethodInfo);\n\tv354 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v348);\nL_00EF:\n\tv363 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv367 = v363 == 0;\n\tv368 = ~v367;\n\tif (v368) goto L_0111;\n\tv374 = new DG.Tweening.TweenCallback();\n\tv383 = this.finishEvent == 0;\n\tif (v383) goto L_FFFFFFFF;\n\tgoto L_0106;\nL_0106:\n\tDG.Tweening.TweenCallback::.ctor(v374, this, *([v395 @ X8_v35 (Il2CppMethodInfo)]));\n\tv381 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v374);\nL_0111:\n\tv388 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv394 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv400 = v394 == 0;\n\tif (v400) goto L_0124;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween RigidBody Look At Position\");\nL_0124:\n\tv410 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv261 = v410 == 0;\n\tif (v261) goto L_0137;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\nL_0137:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 249 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			Rigidbody component = ownerDefaultTarget.GetComponent<Rigidbody>();
			Vector3 value = position.Value;
			float value2 = duration.Value;
			Vector3 value3 = up.Value;
			Vector3? vector = null;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @115D2C0 (inside System.Nullable`1<UnityEngine.Color>::Unbox +0xC8)");
			TweenerCore<Quaternion, Vector3, QuaternionOptions> tweenerCore = component.DOLookAt(value, value2, axisConstraint);
			tween = tweenerCore;
			if (setSpeedBased.Value)
			{
				Tweener tweener = tween.SetSpeedBased();
			}
			bool value4 = setRelative.Value;
			Tweener tweener2 = tween.SetRelative(value4);
			GameObject ownerDefaultTarget2 = Fsm.GetOwnerDefaultTarget(gameObject);
			tween.SetTweenId(tweenIdType, stringAsId, tagAsId, ownerDefaultTarget2);
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
				State.Debug("DOTween RigidBody Look At Position");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x600051B")]
		[Address(RVA = "0xA22914", Offset = "0xA22914", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EAD338]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021D7E]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenRigidbodyLookAtPosition()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
