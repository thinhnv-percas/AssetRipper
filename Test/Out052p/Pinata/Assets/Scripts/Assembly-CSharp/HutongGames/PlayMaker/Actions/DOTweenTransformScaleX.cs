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
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75184C", Offset = "0x75184C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75184C", Offset = "0x75184C")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x75184C", Offset = "0x75184C")]
	[Token(Token = "0x2000107")]
	public class DOTweenTransformScaleX : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x79E2A8", Offset = "0x79E2A8")]
		[Token(Token = "0x4000F60")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79E31C", Offset = "0x79E31C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79E31C", Offset = "0x79E31C")]
		[Token(Token = "0x4000F61")]
		[FieldOffset(Offset = "0x58")]
		public Target target;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79E37C", Offset = "0x79E37C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79E37C", Offset = "0x79E37C")]
		[Token(Token = "0x4000F62")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat to;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79E3CC", Offset = "0x79E3CC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79E3CC", Offset = "0x79E3CC")]
		[Token(Token = "0x4000F63")]
		[FieldOffset(Offset = "0x68")]
		public FsmGameObject toGameObject;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79E41C", Offset = "0x79E41C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79E41C", Offset = "0x79E41C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79E41C", Offset = "0x79E41C")]
		[Token(Token = "0x4000F64")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool setRelative;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79E490", Offset = "0x79E490")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79E490", Offset = "0x79E490")]
		[Token(Token = "0x4000F65")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79E4F0", Offset = "0x79E4F0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79E4F0", Offset = "0x79E4F0")]
		[Token(Token = "0x4000F66")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79E540", Offset = "0x79E540")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79E540", Offset = "0x79E540")]
		[Token(Token = "0x4000F67")]
		[FieldOffset(Offset = "0x88")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79E590", Offset = "0x79E590")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79E590", Offset = "0x79E590")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79E590", Offset = "0x79E590")]
		[Token(Token = "0x4000F68")]
		[FieldOffset(Offset = "0x90")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79E604", Offset = "0x79E604")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79E604", Offset = "0x79E604")]
		[Token(Token = "0x4000F69")]
		[FieldOffset(Offset = "0x98")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79E654", Offset = "0x79E654")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79E654", Offset = "0x79E654")]
		[Token(Token = "0x4000F6A")]
		[FieldOffset(Offset = "0xA0")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79E6A4", Offset = "0x79E6A4")]
		[Token(Token = "0x4000F6B")]
		[FieldOffset(Offset = "0xA8")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79E6B8", Offset = "0x79E6B8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79E6B8", Offset = "0x79E6B8")]
		[Token(Token = "0x4000F6C")]
		[FieldOffset(Offset = "0xB0")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79E708", Offset = "0x79E708")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79E708", Offset = "0x79E708")]
		[Token(Token = "0x4000F6D")]
		[FieldOffset(Offset = "0xB8")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79E758", Offset = "0x79E758")]
		[Token(Token = "0x4000F6E")]
		[FieldOffset(Offset = "0xC0")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79E790", Offset = "0x79E790")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79E790", Offset = "0x79E790")]
		[Token(Token = "0x4000F6F")]
		[FieldOffset(Offset = "0xC8")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79E7E0", Offset = "0x79E7E0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79E7E0", Offset = "0x79E7E0")]
		[Token(Token = "0x4000F70")]
		[FieldOffset(Offset = "0xD0")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79E830", Offset = "0x79E830")]
		[Token(Token = "0x4000F71")]
		[FieldOffset(Offset = "0xD8")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79E868", Offset = "0x79E868")]
		[Token(Token = "0x4000F72")]
		[FieldOffset(Offset = "0xDC")]
		public Ease easeType;

		[Token(Token = "0x4000F73")]
		[FieldOffset(Offset = "0xE0")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79E8A0", Offset = "0x79E8A0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79E8A0", Offset = "0x79E8A0")]
		[Token(Token = "0x4000F74")]
		[FieldOffset(Offset = "0xE8")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79E8F0", Offset = "0x79E8F0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79E8F0", Offset = "0x79E8F0")]
		[Token(Token = "0x4000F75")]
		[FieldOffset(Offset = "0xF0")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79E940", Offset = "0x79E940")]
		[Token(Token = "0x4000F76")]
		[FieldOffset(Offset = "0xF8")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79E978", Offset = "0x79E978")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79E978", Offset = "0x79E978")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79E978", Offset = "0x79E978")]
		[Token(Token = "0x4000F77")]
		[FieldOffset(Offset = "0x100")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79E9EC", Offset = "0x79E9EC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79E9EC", Offset = "0x79E9EC")]
		[Token(Token = "0x4000F78")]
		[FieldOffset(Offset = "0x108")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79EA3C", Offset = "0x79EA3C")]
		[Token(Token = "0x4000F79")]
		[FieldOffset(Offset = "0x110")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79EA74", Offset = "0x79EA74")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79EA74", Offset = "0x79EA74")]
		[Token(Token = "0x4000F7A")]
		[FieldOffset(Offset = "0x118")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79EAC4", Offset = "0x79EAC4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79EAC4", Offset = "0x79EAC4")]
		[Token(Token = "0x4000F7B")]
		[FieldOffset(Offset = "0x120")]
		public FsmBool debugThis;

		[Token(Token = "0x4000F7C")]
		[FieldOffset(Offset = "0x128")]
		private Tweener tween;

		[Token(Token = "0x60005F6")]
		[Address(RVA = "0xA82904", Offset = "0xA82904", Length = "0x2DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EC5EB0]);\n\tv25 = *([v24 @ X8_v12]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202217C]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.to = v50;\n\tv57 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.FsmGameObject::.ctor(v57);\n\tv57.useVariable = 0;\n\tthis.toGameObject = v57;\n\tv80 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v80);\n\tv80.useVariable = 0;\n\tv80.value = 0;\n\tthis.setRelative = v80;\n\tv81 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v81);\n\tv81.useVariable = 0;\n\tthis.duration = v81;\n\tv82 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v82);\n\tv82.useVariable = 0;\n\tv82.value = 0;\n\tthis.setSpeedBased = v82;\n\tv83 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v83);\n\tv83.value = 0f;\n\tthis.startDelay = v83;\n\tv84 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v84);\n\tv84.useVariable = 0;\n\tv84.value = 0;\n\tthis.playInReverse = v84;\n\tv85 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v85);\n\tv85.useVariable = 0;\n\tv85.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v85;\n\tv86 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v86);\n\tv86.useVariable = 0;\n\tv86.value = 0;\n\tthis.finishImmediately = v86;\n\tv87 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v87);\n\tv87.useVariable = 0;\n\tthis.stringAsId = v87;\n\tv88 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v88);\n\tv88.useVariable = 0;\n\tthis.tagAsId = v88;\n\tv89 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v89);\n\tv89.value = 0f;\n\tthis.startDelay = v89;\n\tthis.selectedEase = 0x100000000;\n\tv90 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v90);\n\tv90.value = 0;\n\tthis.loops = v90;\n\tthis.loopType = 0;\n\tv91 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v91);\n\tv91.value = 1;\n\tthis.autoKillOnCompletion = v91;\n\tv92 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v92);\n\tv92.value = 0;\n\tthis.recyclable = v92;\n\tthis.updateType = 0;\n\tv93 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v93);\n\tv93.value = 0;\n\tthis.isIndependentUpdate = v93;\n\tv94 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v94);\n\tv94.value = 0;\n\tthis.debugThis = v94;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 124 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_022d: Expected I4, but got I8
			base.Reset();
			gameObject = null;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = false;
			to = fsmFloat;
			FsmGameObject fsmGameObject = new FsmGameObject();
			fsmGameObject.useVariable = false;
			toGameObject = fsmGameObject;
			FsmBool fsmBool = new FsmBool();
			fsmBool.useVariable = false;
			fsmBool.value = false;
			setRelative = fsmBool;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = false;
			duration = fsmFloat2;
			FsmBool fsmBool2 = new FsmBool();
			fsmBool2.useVariable = false;
			fsmBool2.value = false;
			setSpeedBased = fsmBool2;
			FsmFloat fsmFloat3 = new FsmFloat();
			fsmFloat3.Value = 0f;
			startDelay = fsmFloat3;
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
			FsmFloat fsmFloat4 = new FsmFloat();
			fsmFloat4.Value = 0f;
			startDelay = fsmFloat4;
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

		[Token(Token = "0x60005F7")]
		[Address(RVA = "0xA82BE0", Offset = "0xA82BE0", Length = "0x43C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1EAC388]);\n\tv27 = *([v26 @ X8_v57]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([202217D]) = v46;\nL_001C:\n\tv52 = this.target == 1;\n\tif (v52) goto L_003E;\n\tv57 = this.target == 0;\n\tv58 = ~v57;\n\tif (v58) goto L_0066;\n\tv147 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv221 = UnityEngine.GameObject::GetComponent(v147);\n\tv116 = HutongGames.PlayMaker.FsmFloat::get_Value(this.to);\n\tgoto L_005B;\nL_003E:\n\tv87 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv222 = UnityEngine.GameObject::GetComponent(v87);\n\tv148 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.toGameObject);\n\tv149 = UnityEngine.GameObject::get_transform(v148);\n\tv295 = UnityEngine.Transform::get_localScale(v149);\nL_005B:\n\tv303 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tv76 = DG.Tweening.ShortcutExtensions::DOScaleX(v82, v116, v303);\n\tthis.tween = v76;\nL_0066:\n\tv205 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv233 = v205 == 0;\n\tif (v233) goto L_0074;\n\tv242 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_0074:\n\tv285 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv292 = DG.Tweening.TweenSettingsExtensions::SetRelative(this.tween, v285);\n\tv301 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v301);\n\tv115 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv310 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v115);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv313 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv316 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v313, this.loopType);\n\tv318 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv321 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v318);\n\tv323 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv326 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v323);\n\tv328 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv331 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v328);\n\tv332 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv334 = v332 == 0;\n\tif (v334) goto L_00E5;\n\tv349 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv340 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v349);\nL_00E5:\n\tv347 = this.startEvent == 0;\n\tif (v347) goto L_00FD;\n\tv354 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v354, this, Il2CppMethodInfo);\n\tv360 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v354);\nL_00FD:\n\tv369 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv373 = v369 == 0;\n\tv374 = ~v373;\n\tif (v374) goto L_011F;\n\tv380 = new DG.Tweening.TweenCallback();\n\tv389 = this.finishEvent == 0;\n\tif (v389) goto L_FFFFFFFF;\n\tgoto L_0114;\nL_0114:\n\tDG.Tweening.TweenCallback::.ctor(v380, this, *([v401 @ X8_v30 (Il2CppMethodInfo)]));\n\tv387 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v380);\nL_011F:\n\tv394 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv400 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv406 = v400 == 0;\n\tif (v406) goto L_0132;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Transform Scale X\");\nL_0132:\n\tv271 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv273 = v271 == 0;\n\tif (v273) goto L_014C;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_014C:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 261 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			float endValue;
			Transform transform;
			if (target != Target.GameObject)
			{
				if (target != Target.Value)
				{
					goto IL_0128;
				}
				GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
				Transform component = ownerDefaultTarget.GetComponent<Transform>();
				endValue = to.Value;
				transform = component;
			}
			else
			{
				GameObject ownerDefaultTarget2 = Fsm.GetOwnerDefaultTarget(gameObject);
				Transform component2 = ownerDefaultTarget2.GetComponent<Transform>();
				GameObject value = toGameObject.Value;
				Transform transform2 = value.transform;
				endValue = transform2.localScale.x;
				transform = component2;
			}
			float value2 = duration.Value;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = transform.DOScaleX(endValue, value2);
			tween = tweenerCore;
			goto IL_0128;
			IL_0128:
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
				State.Debug("DOTween Transform Scale X");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x60005F8")]
		[Address(RVA = "0xA8301C", Offset = "0xA8301C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EDC8D0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202217E]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenTransformScaleX()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
