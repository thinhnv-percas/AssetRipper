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
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x7518D0", Offset = "0x7518D0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7518D0", Offset = "0x7518D0")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x7518D0", Offset = "0x7518D0")]
	[Token(Token = "0x2000108")]
	public class DOTweenTransformScaleY : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x79EB14", Offset = "0x79EB14")]
		[Token(Token = "0x4000F7D")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79EB88", Offset = "0x79EB88")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79EB88", Offset = "0x79EB88")]
		[Token(Token = "0x4000F7E")]
		[FieldOffset(Offset = "0x58")]
		public Target target;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79EBE8", Offset = "0x79EBE8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79EBE8", Offset = "0x79EBE8")]
		[Token(Token = "0x4000F7F")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat to;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79EC38", Offset = "0x79EC38")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79EC38", Offset = "0x79EC38")]
		[Token(Token = "0x4000F80")]
		[FieldOffset(Offset = "0x68")]
		public FsmGameObject toGameObject;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79EC88", Offset = "0x79EC88")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79EC88", Offset = "0x79EC88")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79EC88", Offset = "0x79EC88")]
		[Token(Token = "0x4000F81")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool setRelative;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79ECFC", Offset = "0x79ECFC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79ECFC", Offset = "0x79ECFC")]
		[Token(Token = "0x4000F82")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79ED5C", Offset = "0x79ED5C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79ED5C", Offset = "0x79ED5C")]
		[Token(Token = "0x4000F83")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79EDAC", Offset = "0x79EDAC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79EDAC", Offset = "0x79EDAC")]
		[Token(Token = "0x4000F84")]
		[FieldOffset(Offset = "0x88")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79EDFC", Offset = "0x79EDFC")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79EDFC", Offset = "0x79EDFC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79EDFC", Offset = "0x79EDFC")]
		[Token(Token = "0x4000F85")]
		[FieldOffset(Offset = "0x90")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79EE70", Offset = "0x79EE70")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79EE70", Offset = "0x79EE70")]
		[Token(Token = "0x4000F86")]
		[FieldOffset(Offset = "0x98")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79EEC0", Offset = "0x79EEC0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79EEC0", Offset = "0x79EEC0")]
		[Token(Token = "0x4000F87")]
		[FieldOffset(Offset = "0xA0")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79EF10", Offset = "0x79EF10")]
		[Token(Token = "0x4000F88")]
		[FieldOffset(Offset = "0xA8")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79EF24", Offset = "0x79EF24")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79EF24", Offset = "0x79EF24")]
		[Token(Token = "0x4000F89")]
		[FieldOffset(Offset = "0xB0")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79EF74", Offset = "0x79EF74")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79EF74", Offset = "0x79EF74")]
		[Token(Token = "0x4000F8A")]
		[FieldOffset(Offset = "0xB8")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79EFC4", Offset = "0x79EFC4")]
		[Token(Token = "0x4000F8B")]
		[FieldOffset(Offset = "0xC0")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79EFFC", Offset = "0x79EFFC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79EFFC", Offset = "0x79EFFC")]
		[Token(Token = "0x4000F8C")]
		[FieldOffset(Offset = "0xC8")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79F04C", Offset = "0x79F04C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79F04C", Offset = "0x79F04C")]
		[Token(Token = "0x4000F8D")]
		[FieldOffset(Offset = "0xD0")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79F09C", Offset = "0x79F09C")]
		[Token(Token = "0x4000F8E")]
		[FieldOffset(Offset = "0xD8")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79F0D4", Offset = "0x79F0D4")]
		[Token(Token = "0x4000F8F")]
		[FieldOffset(Offset = "0xDC")]
		public Ease easeType;

		[Token(Token = "0x4000F90")]
		[FieldOffset(Offset = "0xE0")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79F10C", Offset = "0x79F10C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79F10C", Offset = "0x79F10C")]
		[Token(Token = "0x4000F91")]
		[FieldOffset(Offset = "0xE8")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79F15C", Offset = "0x79F15C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79F15C", Offset = "0x79F15C")]
		[Token(Token = "0x4000F92")]
		[FieldOffset(Offset = "0xF0")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79F1AC", Offset = "0x79F1AC")]
		[Token(Token = "0x4000F93")]
		[FieldOffset(Offset = "0xF8")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79F1E4", Offset = "0x79F1E4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79F1E4", Offset = "0x79F1E4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79F1E4", Offset = "0x79F1E4")]
		[Token(Token = "0x4000F94")]
		[FieldOffset(Offset = "0x100")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79F258", Offset = "0x79F258")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79F258", Offset = "0x79F258")]
		[Token(Token = "0x4000F95")]
		[FieldOffset(Offset = "0x108")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79F2A8", Offset = "0x79F2A8")]
		[Token(Token = "0x4000F96")]
		[FieldOffset(Offset = "0x110")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79F2E0", Offset = "0x79F2E0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79F2E0", Offset = "0x79F2E0")]
		[Token(Token = "0x4000F97")]
		[FieldOffset(Offset = "0x118")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79F330", Offset = "0x79F330")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79F330", Offset = "0x79F330")]
		[Token(Token = "0x4000F98")]
		[FieldOffset(Offset = "0x120")]
		public FsmBool debugThis;

		[Token(Token = "0x4000F99")]
		[FieldOffset(Offset = "0x128")]
		private Tweener tween;

		[Token(Token = "0x60005FB")]
		[Address(RVA = "0xA830CC", Offset = "0xA830CC", Length = "0x2DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EB25A0]);\n\tv25 = *([v24 @ X8_v12]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202217F]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.to = v50;\n\tv57 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.FsmGameObject::.ctor(v57);\n\tv57.useVariable = 0;\n\tthis.toGameObject = v57;\n\tv80 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v80);\n\tv80.useVariable = 0;\n\tv80.value = 0;\n\tthis.setRelative = v80;\n\tv81 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v81);\n\tv81.useVariable = 0;\n\tthis.duration = v81;\n\tv82 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v82);\n\tv82.useVariable = 0;\n\tv82.value = 0;\n\tthis.setSpeedBased = v82;\n\tv83 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v83);\n\tv83.value = 0f;\n\tthis.startDelay = v83;\n\tv84 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v84);\n\tv84.useVariable = 0;\n\tv84.value = 0;\n\tthis.playInReverse = v84;\n\tv85 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v85);\n\tv85.useVariable = 0;\n\tv85.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v85;\n\tv86 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v86);\n\tv86.useVariable = 0;\n\tv86.value = 0;\n\tthis.finishImmediately = v86;\n\tv87 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v87);\n\tv87.useVariable = 0;\n\tthis.stringAsId = v87;\n\tv88 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v88);\n\tv88.useVariable = 0;\n\tthis.tagAsId = v88;\n\tv89 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v89);\n\tv89.value = 0f;\n\tthis.startDelay = v89;\n\tthis.selectedEase = 0x100000000;\n\tv90 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v90);\n\tv90.value = 0;\n\tthis.loops = v90;\n\tthis.loopType = 0;\n\tv91 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v91);\n\tv91.value = 1;\n\tthis.autoKillOnCompletion = v91;\n\tv92 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v92);\n\tv92.value = 0;\n\tthis.recyclable = v92;\n\tthis.updateType = 0;\n\tv93 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v93);\n\tv93.value = 0;\n\tthis.isIndependentUpdate = v93;\n\tv94 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v94);\n\tv94.value = 0;\n\tthis.debugThis = v94;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 124 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60005FC")]
		[Address(RVA = "0xA833A8", Offset = "0xA833A8", Length = "0x448")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv26 = *([1EEEDA0]);\n\tv27 = *([v26 @ X8_v57]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2022180]) = v46;\nL_001C:\n\tv52 = this.target == 1;\n\tif (v52) goto L_0043;\n\tv57 = this.target == 0;\n\tv58 = ~v57;\n\tif (v58) goto L_006B;\n\tv152 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv231 = UnityEngine.GameObject::GetComponent(v152);\n\tv118 = HutongGames.PlayMaker.FsmFloat::get_Value(this.to);\n\tv303 = this.duration;\n\tv299 = this.duration == 0;\n\tv171 = ~v299;\n\tif (v171) goto L_0060;\n\tgoto L_0152;\nL_0043:\n\tv87 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv232 = UnityEngine.GameObject::GetComponent(v87);\n\tv154 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.toGameObject);\n\tv155 = UnityEngine.GameObject::get_transform(v154);\n\tv119 = UnityEngine.Transform::get_localScale(v155);\n\tv303 = this.duration;\nL_0060:\n\tv305 = HutongGames.PlayMaker.FsmFloat::get_Value(v303);\n\tv76 = DG.Tweening.ShortcutExtensions::DOScaleY(v82, v68, v305);\n\tthis.tween = v76;\nL_006B:\n\tv215 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv241 = v215 == 0;\n\tif (v241) goto L_0079;\n\tv250 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_0079:\n\tv293 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv298 = DG.Tweening.TweenSettingsExtensions::SetRelative(this.tween, v293);\n\tv308 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v308);\n\tv120 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv315 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v120);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv318 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv321 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v318, this.loopType);\n\tv323 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv326 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v323);\n\tv328 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv331 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v328);\n\tv333 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv336 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v333);\n\tv337 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv339 = v337 == 0;\n\tif (v339) goto L_00EA;\n\tv354 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv345 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v354);\nL_00EA:\n\tv352 = this.startEvent == 0;\n\tif (v352) goto L_0102;\n\tv359 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v359, this, Il2CppMethodInfo);\n\tv365 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v359);\nL_0102:\n\tv374 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv378 = v374 == 0;\n\tv379 = ~v378;\n\tif (v379) goto L_0124;\n\tv385 = new DG.Tweening.TweenCallback();\n\tv394 = this.finishEvent == 0;\n\tif (v394) goto L_FFFFFFFF;\n\tgoto L_0119;\nL_0119:\n\tDG.Tweening.TweenCallback::.ctor(v385, this, *([v406 @ X8_v29 (Il2CppMethodInfo)]));\n\tv392 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v385);\nL_0124:\n\tv399 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv405 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv411 = v405 == 0;\n\tif (v411) goto L_0137;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Transform Scale Y\");\nL_0137:\n\tv279 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv281 = v279 == 0;\n\tif (v281) goto L_0151;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0151:\n\treturn;\nL_0152:\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 262 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			FsmFloat fsmFloat;
			float endValue;
			Transform transform;
			if (target != Target.GameObject)
			{
				if (target != Target.Value)
				{
					goto IL_016c;
				}
				GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
				Transform component = ownerDefaultTarget.GetComponent<Transform>();
				float value = to.Value;
				fsmFloat = duration;
				bool flag = duration == null;
				bool flag2 = !flag;
				endValue = value;
				transform = component;
				if (!flag2)
				{
					throw new NullReferenceException();
				}
			}
			else
			{
				GameObject ownerDefaultTarget2 = Fsm.GetOwnerDefaultTarget(gameObject);
				Transform component2 = ownerDefaultTarget2.GetComponent<Transform>();
				GameObject value2 = toGameObject.Value;
				Transform transform2 = value2.transform;
				Vector3 localScale = transform2.localScale;
				fsmFloat = duration;
				endValue = localScale.y;
				transform = component2;
			}
			float value3 = fsmFloat.Value;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = transform.DOScaleY(endValue, value3);
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
				State.Debug("DOTween Transform Scale Y");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x60005FD")]
		[Address(RVA = "0xA837F0", Offset = "0xA837F0", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ED03F8]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022181]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenTransformScaleY()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
