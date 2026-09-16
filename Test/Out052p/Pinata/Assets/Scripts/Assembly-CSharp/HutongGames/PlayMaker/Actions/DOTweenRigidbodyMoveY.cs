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
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x750328", Offset = "0x750328")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x750328", Offset = "0x750328")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x750328", Offset = "0x750328")]
	[Token(Token = "0x20000DE")]
	public class DOTweenRigidbodyMoveY : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x789010", Offset = "0x789010")]
		[Token(Token = "0x4000AC1")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x789084", Offset = "0x789084")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x789084", Offset = "0x789084")]
		[Token(Token = "0x4000AC2")]
		[FieldOffset(Offset = "0x58")]
		public Target target;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7890E4", Offset = "0x7890E4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7890E4", Offset = "0x7890E4")]
		[Token(Token = "0x4000AC3")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat to;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x789134", Offset = "0x789134")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x789134", Offset = "0x789134")]
		[Token(Token = "0x4000AC4")]
		[FieldOffset(Offset = "0x68")]
		public FsmGameObject toGameObject;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x789184", Offset = "0x789184")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x789184", Offset = "0x789184")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x789184", Offset = "0x789184")]
		[Token(Token = "0x4000AC5")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool setRelative;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7891F8", Offset = "0x7891F8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7891F8", Offset = "0x7891F8")]
		[Token(Token = "0x4000AC6")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool snapping;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x789248", Offset = "0x789248")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x789248", Offset = "0x789248")]
		[Token(Token = "0x4000AC7")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7892A8", Offset = "0x7892A8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7892A8", Offset = "0x7892A8")]
		[Token(Token = "0x4000AC8")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7892F8", Offset = "0x7892F8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7892F8", Offset = "0x7892F8")]
		[Token(Token = "0x4000AC9")]
		[FieldOffset(Offset = "0x90")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x789348", Offset = "0x789348")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x789348", Offset = "0x789348")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x789348", Offset = "0x789348")]
		[Token(Token = "0x4000ACA")]
		[FieldOffset(Offset = "0x98")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7893BC", Offset = "0x7893BC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7893BC", Offset = "0x7893BC")]
		[Token(Token = "0x4000ACB")]
		[FieldOffset(Offset = "0xA0")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x78940C", Offset = "0x78940C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78940C", Offset = "0x78940C")]
		[Token(Token = "0x4000ACC")]
		[FieldOffset(Offset = "0xA8")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78945C", Offset = "0x78945C")]
		[Token(Token = "0x4000ACD")]
		[FieldOffset(Offset = "0xB0")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x789470", Offset = "0x789470")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x789470", Offset = "0x789470")]
		[Token(Token = "0x4000ACE")]
		[FieldOffset(Offset = "0xB8")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7894C0", Offset = "0x7894C0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7894C0", Offset = "0x7894C0")]
		[Token(Token = "0x4000ACF")]
		[FieldOffset(Offset = "0xC0")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x789510", Offset = "0x789510")]
		[Token(Token = "0x4000AD0")]
		[FieldOffset(Offset = "0xC8")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x789548", Offset = "0x789548")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x789548", Offset = "0x789548")]
		[Token(Token = "0x4000AD1")]
		[FieldOffset(Offset = "0xD0")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x789598", Offset = "0x789598")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x789598", Offset = "0x789598")]
		[Token(Token = "0x4000AD2")]
		[FieldOffset(Offset = "0xD8")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7895E8", Offset = "0x7895E8")]
		[Token(Token = "0x4000AD3")]
		[FieldOffset(Offset = "0xE0")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x789620", Offset = "0x789620")]
		[Token(Token = "0x4000AD4")]
		[FieldOffset(Offset = "0xE4")]
		public Ease easeType;

		[Token(Token = "0x4000AD5")]
		[FieldOffset(Offset = "0xE8")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x789658", Offset = "0x789658")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x789658", Offset = "0x789658")]
		[Token(Token = "0x4000AD6")]
		[FieldOffset(Offset = "0xF0")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7896A8", Offset = "0x7896A8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7896A8", Offset = "0x7896A8")]
		[Token(Token = "0x4000AD7")]
		[FieldOffset(Offset = "0xF8")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7896F8", Offset = "0x7896F8")]
		[Token(Token = "0x4000AD8")]
		[FieldOffset(Offset = "0x100")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x789730", Offset = "0x789730")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x789730", Offset = "0x789730")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x789730", Offset = "0x789730")]
		[Token(Token = "0x4000AD9")]
		[FieldOffset(Offset = "0x108")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7897A4", Offset = "0x7897A4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7897A4", Offset = "0x7897A4")]
		[Token(Token = "0x4000ADA")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7897F4", Offset = "0x7897F4")]
		[Token(Token = "0x4000ADB")]
		[FieldOffset(Offset = "0x118")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78982C", Offset = "0x78982C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x78982C", Offset = "0x78982C")]
		[Token(Token = "0x4000ADC")]
		[FieldOffset(Offset = "0x120")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x78987C", Offset = "0x78987C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x78987C", Offset = "0x78987C")]
		[Token(Token = "0x4000ADD")]
		[FieldOffset(Offset = "0x128")]
		public FsmBool debugThis;

		[Token(Token = "0x4000ADE")]
		[FieldOffset(Offset = "0x130")]
		private Tweener tween;

		[Token(Token = "0x6000528")]
		[Address(RVA = "0xA239B0", Offset = "0xA239B0", Length = "0x2B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EFAEA8]);\n\tv25 = *([v24 @ X8_v10]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021D85]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.to = v50;\n\tv55 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v55);\n\tv55.useVariable = 0;\n\tthis.duration = v55;\n\tv77 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v77);\n\tv77.useVariable = 0;\n\tv77.value = 0;\n\tthis.setSpeedBased = v77;\n\tv78 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v78);\n\tv78.useVariable = 0;\n\tv78.value = 0;\n\tthis.snapping = v78;\n\tv79 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v79);\n\tv79.useVariable = 0;\n\tv79.value = 0;\n\tthis.setRelative = v79;\n\tv80 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v80);\n\tv80.useVariable = 0;\n\tv80.value = 0;\n\tthis.playInReverse = v80;\n\tv81 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v81);\n\tv81.useVariable = 0;\n\tv81.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v81;\n\tv82 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v82);\n\tv82.useVariable = 0;\n\tv82.value = 0;\n\tthis.finishImmediately = v82;\n\tv83 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v83);\n\tv83.useVariable = 0;\n\tthis.stringAsId = v83;\n\tv84 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v84);\n\tv84.useVariable = 0;\n\tthis.tagAsId = v84;\n\tv85 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v85);\n\tv85.value = 0f;\n\tthis.startDelay = v85;\n\tthis.selectedEase = 0x100000000;\n\tv86 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v86);\n\tv86.value = 0;\n\tthis.loops = v86;\n\tthis.loopType = 0;\n\tv87 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v87);\n\tv87.value = 1;\n\tthis.autoKillOnCompletion = v87;\n\tv88 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v88);\n\tv88.value = 0;\n\tthis.recyclable = v88;\n\tthis.updateType = 0;\n\tv89 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v89);\n\tv89.value = 0;\n\tthis.isIndependentUpdate = v89;\n\tv90 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v90);\n\tv90.value = 0;\n\tthis.debugThis = v90;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 117 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_0214: Expected I4, but got I8
			base.Reset();
			gameObject = null;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = false;
			to = fsmFloat;
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
			FsmFloat fsmFloat3 = new FsmFloat();
			fsmFloat3.Value = 0f;
			startDelay = fsmFloat3;
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

		[Token(Token = "0x6000529")]
		[Address(RVA = "0xA23C68", Offset = "0xA23C68", Length = "0x460")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv28 = *([1EBC330]);\n\tv29 = *([v28 @ X8_v54]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2021D86]) = v48;\nL_001D:\n\tv54 = this.target == 1;\n\tif (v54) goto L_0044;\n\tv59 = this.target == 0;\n\tv60 = ~v59;\n\tif (v60) goto L_0073;\n\tv157 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv237 = UnityEngine.GameObject::GetComponent(v157);\n\tv121 = HutongGames.PlayMaker.FsmFloat::get_Value(this.to);\n\tv318 = this.duration;\n\tv315 = this.duration == 0;\n\tv177 = ~v315;\n\tif (v177) goto L_0061;\n\tgoto L_015D;\nL_0044:\n\tv91 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv238 = UnityEngine.GameObject::GetComponent(v91);\n\tv159 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.toGameObject);\n\tv160 = UnityEngine.GameObject::get_transform(v159);\n\tv122 = UnityEngine.Transform::get_position(v160);\n\tv318 = this.duration;\nL_0061:\n\tv123 = HutongGames.PlayMaker.FsmFloat::get_Value(v318);\n\tv325 = HutongGames.PlayMaker.FsmBool::get_Value(this.snapping);\n\tv80 = DG.Tweening.DOTweenModulePhysics::DOMoveY(v86, v72, v123, v325);\n\tthis.tween = v80;\nL_0073:\n\tv220 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv247 = v220 == 0;\n\tif (v247) goto L_0081;\n\tv256 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_0081:\n\tv309 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv314 = DG.Tweening.TweenSettingsExtensions::SetRelative(this.tween, v309);\n\tv322 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v322);\n\tv124 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv331 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v124);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv334 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv337 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v334, this.loopType);\n\tv339 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv342 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v339);\n\tv344 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv347 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v344);\n\tv349 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv352 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v349);\n\tv353 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv355 = v353 == 0;\n\tif (v355) goto L_00F2;\n\tv370 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv361 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v370);\nL_00F2:\n\tv368 = this.startEvent == 0;\n\tif (v368) goto L_010A;\n\tv375 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v375, this, Il2CppMethodInfo);\n\tv381 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v375);\nL_010A:\n\tv389 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv393 = v389 == 0;\n\tv394 = ~v393;\n\tif (v394) goto L_012D;\n\tv398 = new DG.Tweening.TweenCallback();\n\tv294 = this.finishEvent == 0;\n\tif (v294) goto L_011D;\n\tgoto L_011D;\nL_011D:\n\tv290 = DG.Tweening.TweenSettingsExtensions::SetUpdate(v398, 0, v135);\n\treturn;\n\tX0 = X21;\n\tX1 = X19;\n\tX3 = 0;\n\tDG.Tweening.TweenCallback::.ctor(X0, X1, X2, X3);\n\tX8 = *([1EE6378]);\n\tX0 = X20;\n\tX1 = X21;\n\tX2 = *([X8]);\n\tX0 = DG.Tweening.TweenSettingsExtensions::OnComplete /* +5 sharing this address */(X0, X1, X2);\nL_012D:\n\tv401 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv407 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv409 = v407 == 0;\n\tif (v409) goto L_0140;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween RigidBody Move Y\");\nL_0140:\n\tv292 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv295 = v292 == 0;\n\tif (v295) goto L_015C;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_015C:\n\treturn;\nL_015D:\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 263 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			FsmFloat fsmFloat;
			float endValue;
			Rigidbody rigidbody;
			if (target != Target.GameObject)
			{
				if (target != Target.Value)
				{
					goto IL_0184;
				}
				GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
				Rigidbody component = ownerDefaultTarget.GetComponent<Rigidbody>();
				float value = to.Value;
				fsmFloat = duration;
				bool flag = duration == null;
				bool flag2 = !flag;
				endValue = value;
				rigidbody = component;
				if (!flag2)
				{
					throw new NullReferenceException();
				}
			}
			else
			{
				GameObject ownerDefaultTarget2 = Fsm.GetOwnerDefaultTarget(gameObject);
				Rigidbody component2 = ownerDefaultTarget2.GetComponent<Rigidbody>();
				GameObject value2 = toGameObject.Value;
				Transform transform = value2.transform;
				Vector3 position = transform.position;
				fsmFloat = duration;
				endValue = position.y;
				rigidbody = component2;
			}
			float value3 = fsmFloat.Value;
			bool value4 = snapping.Value;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = rigidbody.DOMoveY(endValue, value3, value4);
			tween = tweenerCore;
			goto IL_0184;
			IL_0184:
			if (setSpeedBased.Value)
			{
				Tweener tweener = tween.SetSpeedBased();
			}
			bool value5 = setRelative.Value;
			Tweener tweener2 = tween.SetRelative(value5);
			GameObject ownerDefaultTarget3 = Fsm.GetOwnerDefaultTarget(gameObject);
			tween.SetTweenId(tweenIdType, stringAsId, tagAsId, ownerDefaultTarget3);
			float value6 = startDelay.Value;
			Tweener tweener3 = tween.SetDelay(value6);
			tween.SetSelectedEase(selectedEase, easeType, animationCurve);
			int value7 = loops.Value;
			Tweener tweener4 = tween.SetLoops(value7, loopType);
			bool value8 = autoKillOnCompletion.Value;
			Tweener tweener5 = tween.SetAutoKill(value8);
			bool value9 = recyclable.Value;
			Tweener tweener6 = tween.SetRecyclable(value9);
			bool value10 = isIndependentUpdate.Value;
			Tweener tweener7 = tween.SetUpdate(updateType, value10);
			bool value11 = playInReverse.Value;
			bool flag3 = !value11;
			IntPtr intPtr = (IntPtr)(value10 ? 1 : 0);
			if (!flag3)
			{
				bool value12 = setReverseRelative.Value;
				Tweener tweener8 = tween.From(value12);
				intPtr = (IntPtr)0;
			}
			if (startEvent != null)
			{
				TweenCallback action = delegate
				{
					Fsm.Event(startEvent);
				};
				Tweener tweener9 = tween.OnStart(action);
				intPtr = (IntPtr)0;
			}
			if (!finishImmediately.Value)
			{
				TweenCallback t = null;
				if (finishEvent != null)
				{
				}
				Tweener tweener10 = ((Tweener)(object)t).SetUpdate(default(UpdateType), (byte)(long)intPtr != 0);
				return;
			}
			Tweener tweener11 = tween.Play();
			if (debugThis.Value)
			{
				State.Debug("DOTween RigidBody Move Y");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x600052A")]
		[Address(RVA = "0xA240C8", Offset = "0xA240C8", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ECB748]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021D87]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenRigidbodyMoveY()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
