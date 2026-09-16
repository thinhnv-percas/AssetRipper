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
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7513A8", Offset = "0x7513A8")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7513A8", Offset = "0x7513A8")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x7513A8", Offset = "0x7513A8")]
	[Token(Token = "0x20000FE")]
	public class DOTweenTransformMoveX : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x799664", Offset = "0x799664")]
		[Token(Token = "0x4000E56")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7996D8", Offset = "0x7996D8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7996D8", Offset = "0x7996D8")]
		[Token(Token = "0x4000E57")]
		[FieldOffset(Offset = "0x58")]
		public Target target;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x799738", Offset = "0x799738")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x799738", Offset = "0x799738")]
		[Token(Token = "0x4000E58")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat to;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x799788", Offset = "0x799788")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x799788", Offset = "0x799788")]
		[Token(Token = "0x4000E59")]
		[FieldOffset(Offset = "0x68")]
		public FsmGameObject toGameObject;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7997D8", Offset = "0x7997D8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7997D8", Offset = "0x7997D8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7997D8", Offset = "0x7997D8")]
		[Token(Token = "0x4000E5A")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool setRelative;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79984C", Offset = "0x79984C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79984C", Offset = "0x79984C")]
		[Token(Token = "0x4000E5B")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool snapping;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79989C", Offset = "0x79989C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79989C", Offset = "0x79989C")]
		[Token(Token = "0x4000E5C")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7998FC", Offset = "0x7998FC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7998FC", Offset = "0x7998FC")]
		[Token(Token = "0x4000E5D")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79994C", Offset = "0x79994C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79994C", Offset = "0x79994C")]
		[Token(Token = "0x4000E5E")]
		[FieldOffset(Offset = "0x90")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79999C", Offset = "0x79999C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79999C", Offset = "0x79999C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79999C", Offset = "0x79999C")]
		[Token(Token = "0x4000E5F")]
		[FieldOffset(Offset = "0x98")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x799A10", Offset = "0x799A10")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x799A10", Offset = "0x799A10")]
		[Token(Token = "0x4000E60")]
		[FieldOffset(Offset = "0xA0")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x799A60", Offset = "0x799A60")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x799A60", Offset = "0x799A60")]
		[Token(Token = "0x4000E61")]
		[FieldOffset(Offset = "0xA8")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x799AB0", Offset = "0x799AB0")]
		[Token(Token = "0x4000E62")]
		[FieldOffset(Offset = "0xB0")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x799AC4", Offset = "0x799AC4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x799AC4", Offset = "0x799AC4")]
		[Token(Token = "0x4000E63")]
		[FieldOffset(Offset = "0xB8")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x799B14", Offset = "0x799B14")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x799B14", Offset = "0x799B14")]
		[Token(Token = "0x4000E64")]
		[FieldOffset(Offset = "0xC0")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x799B64", Offset = "0x799B64")]
		[Token(Token = "0x4000E65")]
		[FieldOffset(Offset = "0xC8")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x799B9C", Offset = "0x799B9C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x799B9C", Offset = "0x799B9C")]
		[Token(Token = "0x4000E66")]
		[FieldOffset(Offset = "0xD0")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x799BEC", Offset = "0x799BEC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x799BEC", Offset = "0x799BEC")]
		[Token(Token = "0x4000E67")]
		[FieldOffset(Offset = "0xD8")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x799C3C", Offset = "0x799C3C")]
		[Token(Token = "0x4000E68")]
		[FieldOffset(Offset = "0xE0")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x799C74", Offset = "0x799C74")]
		[Token(Token = "0x4000E69")]
		[FieldOffset(Offset = "0xE4")]
		public Ease easeType;

		[Token(Token = "0x4000E6A")]
		[FieldOffset(Offset = "0xE8")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x799CAC", Offset = "0x799CAC")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x799CAC", Offset = "0x799CAC")]
		[Token(Token = "0x4000E6B")]
		[FieldOffset(Offset = "0xF0")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x799CFC", Offset = "0x799CFC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x799CFC", Offset = "0x799CFC")]
		[Token(Token = "0x4000E6C")]
		[FieldOffset(Offset = "0xF8")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x799D4C", Offset = "0x799D4C")]
		[Token(Token = "0x4000E6D")]
		[FieldOffset(Offset = "0x100")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x799D84", Offset = "0x799D84")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x799D84", Offset = "0x799D84")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x799D84", Offset = "0x799D84")]
		[Token(Token = "0x4000E6E")]
		[FieldOffset(Offset = "0x108")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x799DF8", Offset = "0x799DF8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x799DF8", Offset = "0x799DF8")]
		[Token(Token = "0x4000E6F")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x799E48", Offset = "0x799E48")]
		[Token(Token = "0x4000E70")]
		[FieldOffset(Offset = "0x118")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x799E80", Offset = "0x799E80")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x799E80", Offset = "0x799E80")]
		[Token(Token = "0x4000E71")]
		[FieldOffset(Offset = "0x120")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x799ED0", Offset = "0x799ED0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x799ED0", Offset = "0x799ED0")]
		[Token(Token = "0x4000E72")]
		[FieldOffset(Offset = "0x128")]
		public FsmBool debugThis;

		[Token(Token = "0x4000E73")]
		[FieldOffset(Offset = "0x130")]
		private Tweener tween;

		[Token(Token = "0x60005C9")]
		[Address(RVA = "0xA7DEC0", Offset = "0xA7DEC0", Length = "0x2E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EAB540]);\n\tv25 = *([v24 @ X8_v12]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022161]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.to = v50;\n\tv57 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.FsmGameObject::.ctor(v57);\n\tv57.useVariable = 0;\n\tthis.toGameObject = v57;\n\tv80 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v80);\n\tv80.useVariable = 0;\n\tthis.duration = v80;\n\tv81 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v81);\n\tv81.useVariable = 0;\n\tv81.value = 0;\n\tthis.setSpeedBased = v81;\n\tv82 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v82);\n\tv82.useVariable = 0;\n\tv82.value = 0;\n\tthis.snapping = v82;\n\tv83 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v83);\n\tv83.useVariable = 0;\n\tv83.value = 0;\n\tthis.setRelative = v83;\n\tv84 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v84);\n\tv84.useVariable = 0;\n\tv84.value = 0;\n\tthis.playInReverse = v84;\n\tv85 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v85);\n\tv85.useVariable = 0;\n\tv85.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v85;\n\tv86 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v86);\n\tv86.useVariable = 0;\n\tv86.value = 0;\n\tthis.finishImmediately = v86;\n\tv87 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v87);\n\tv87.useVariable = 0;\n\tthis.stringAsId = v87;\n\tv88 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v88);\n\tv88.useVariable = 0;\n\tthis.tagAsId = v88;\n\tv89 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v89);\n\tv89.value = 0f;\n\tthis.startDelay = v89;\n\tthis.selectedEase = 0x100000000;\n\tv90 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v90);\n\tv90.value = 0;\n\tthis.loops = v90;\n\tthis.loopType = 0;\n\tv91 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v91);\n\tv91.value = 1;\n\tthis.autoKillOnCompletion = v91;\n\tv92 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v92);\n\tv92.value = 0;\n\tthis.recyclable = v92;\n\tthis.updateType = 0;\n\tv93 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v93);\n\tv93.value = 0;\n\tthis.isIndependentUpdate = v93;\n\tv94 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v94);\n\tv94.value = 0;\n\tthis.debugThis = v94;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 124 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_023b: Expected I4, but got I8
			base.Reset();
			gameObject = null;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = false;
			to = fsmFloat;
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

		[Token(Token = "0x60005CA")]
		[Address(RVA = "0xA7E1A0", Offset = "0xA7E1A0", Length = "0x454")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv28 = *([1EFE4F8]);\n\tv29 = *([v28 @ X8_v57]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([2022162]) = v48;\nL_001D:\n\tv54 = this.target == 1;\n\tif (v54) goto L_003F;\n\tv59 = this.target == 0;\n\tv60 = ~v59;\n\tif (v60) goto L_006E;\n\tv155 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv232 = UnityEngine.GameObject::GetComponent(v155);\n\tv122 = HutongGames.PlayMaker.FsmFloat::get_Value(this.to);\n\tgoto L_005C;\nL_003F:\n\tv91 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv233 = UnityEngine.GameObject::GetComponent(v91);\n\tv156 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.toGameObject);\n\tv157 = UnityEngine.GameObject::get_transform(v156);\n\tv309 = UnityEngine.Transform::get_position(v157);\nL_005C:\n\tv120 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tv318 = HutongGames.PlayMaker.FsmBool::get_Value(this.snapping);\n\tv80 = DG.Tweening.ShortcutExtensions::DOMoveX(v86, v122, v120, v318);\n\tthis.tween = v80;\nL_006E:\n\tv215 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv244 = v215 == 0;\n\tif (v244) goto L_007C;\n\tv253 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_007C:\n\tv299 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv306 = DG.Tweening.TweenSettingsExtensions::SetRelative(this.tween, v299);\n\tv315 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v315);\n\tv121 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv324 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v121);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv327 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv330 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v327, this.loopType);\n\tv332 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv335 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v332);\n\tv337 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv340 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v337);\n\tv342 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv345 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v342);\n\tv346 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv348 = v346 == 0;\n\tif (v348) goto L_00ED;\n\tv363 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv354 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v363);\nL_00ED:\n\tv361 = this.startEvent == 0;\n\tif (v361) goto L_0105;\n\tv368 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v368, this, Il2CppMethodInfo);\n\tv374 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v368);\nL_0105:\n\tv383 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv387 = v383 == 0;\n\tv388 = ~v387;\n\tif (v388) goto L_0127;\n\tv394 = new DG.Tweening.TweenCallback();\n\tv403 = this.finishEvent == 0;\n\tif (v403) goto L_FFFFFFFF;\n\tgoto L_011C;\nL_011C:\n\tDG.Tweening.TweenCallback::.ctor(v394, this, *([v415 @ X8_v30 (Il2CppMethodInfo)]));\n\tv401 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v394);\nL_0127:\n\tv408 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv414 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv420 = v414 == 0;\n\tif (v420) goto L_013A;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Transform Move X\");\nL_013A:\n\tv285 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv287 = v285 == 0;\n\tif (v287) goto L_0156;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0156:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 270 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			float endValue;
			Transform transform;
			if (target != Target.GameObject)
			{
				if (target != Target.Value)
				{
					goto IL_0140;
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
				endValue = transform2.position.x;
				transform = component2;
			}
			float value2 = duration.Value;
			bool value3 = snapping.Value;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = transform.DOMoveX(endValue, value2, value3);
			tween = tweenerCore;
			goto IL_0140;
			IL_0140:
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
				State.Debug("DOTween Transform Move X");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x60005CB")]
		[Address(RVA = "0xA7E5F4", Offset = "0xA7E5F4", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1F03488]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022163]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenTransformMoveX()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
