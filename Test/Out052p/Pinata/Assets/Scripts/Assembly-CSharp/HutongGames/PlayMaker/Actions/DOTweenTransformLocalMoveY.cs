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
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75100C", Offset = "0x75100C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75100C", Offset = "0x75100C")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x75100C", Offset = "0x75100C")]
	[Token(Token = "0x20000F7")]
	public class DOTweenTransformLocalMoveY : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x795868", Offset = "0x795868")]
		[Token(Token = "0x4000D7F")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7958DC", Offset = "0x7958DC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7958DC", Offset = "0x7958DC")]
		[Token(Token = "0x4000D80")]
		[FieldOffset(Offset = "0x58")]
		public Target target;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79593C", Offset = "0x79593C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79593C", Offset = "0x79593C")]
		[Token(Token = "0x4000D81")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat to;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79598C", Offset = "0x79598C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79598C", Offset = "0x79598C")]
		[Token(Token = "0x4000D82")]
		[FieldOffset(Offset = "0x68")]
		public FsmGameObject toGameObject;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7959DC", Offset = "0x7959DC")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7959DC", Offset = "0x7959DC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7959DC", Offset = "0x7959DC")]
		[Token(Token = "0x4000D83")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool setRelative;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x795A50", Offset = "0x795A50")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x795A50", Offset = "0x795A50")]
		[Token(Token = "0x4000D84")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool snapping;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x795AA0", Offset = "0x795AA0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x795AA0", Offset = "0x795AA0")]
		[Token(Token = "0x4000D85")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x795B00", Offset = "0x795B00")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x795B00", Offset = "0x795B00")]
		[Token(Token = "0x4000D86")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x795B50", Offset = "0x795B50")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x795B50", Offset = "0x795B50")]
		[Token(Token = "0x4000D87")]
		[FieldOffset(Offset = "0x90")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x795BA0", Offset = "0x795BA0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x795BA0", Offset = "0x795BA0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x795BA0", Offset = "0x795BA0")]
		[Token(Token = "0x4000D88")]
		[FieldOffset(Offset = "0x98")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x795C14", Offset = "0x795C14")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x795C14", Offset = "0x795C14")]
		[Token(Token = "0x4000D89")]
		[FieldOffset(Offset = "0xA0")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x795C64", Offset = "0x795C64")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x795C64", Offset = "0x795C64")]
		[Token(Token = "0x4000D8A")]
		[FieldOffset(Offset = "0xA8")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x795CB4", Offset = "0x795CB4")]
		[Token(Token = "0x4000D8B")]
		[FieldOffset(Offset = "0xB0")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x795CC8", Offset = "0x795CC8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x795CC8", Offset = "0x795CC8")]
		[Token(Token = "0x4000D8C")]
		[FieldOffset(Offset = "0xB8")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x795D18", Offset = "0x795D18")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x795D18", Offset = "0x795D18")]
		[Token(Token = "0x4000D8D")]
		[FieldOffset(Offset = "0xC0")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x795D68", Offset = "0x795D68")]
		[Token(Token = "0x4000D8E")]
		[FieldOffset(Offset = "0xC8")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x795DA0", Offset = "0x795DA0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x795DA0", Offset = "0x795DA0")]
		[Token(Token = "0x4000D8F")]
		[FieldOffset(Offset = "0xD0")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x795DF0", Offset = "0x795DF0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x795DF0", Offset = "0x795DF0")]
		[Token(Token = "0x4000D90")]
		[FieldOffset(Offset = "0xD8")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x795E40", Offset = "0x795E40")]
		[Token(Token = "0x4000D91")]
		[FieldOffset(Offset = "0xE0")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x795E78", Offset = "0x795E78")]
		[Token(Token = "0x4000D92")]
		[FieldOffset(Offset = "0xE4")]
		public Ease easeType;

		[Token(Token = "0x4000D93")]
		[FieldOffset(Offset = "0xE8")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x795EB0", Offset = "0x795EB0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x795EB0", Offset = "0x795EB0")]
		[Token(Token = "0x4000D94")]
		[FieldOffset(Offset = "0xF0")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x795F00", Offset = "0x795F00")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x795F00", Offset = "0x795F00")]
		[Token(Token = "0x4000D95")]
		[FieldOffset(Offset = "0xF8")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x795F50", Offset = "0x795F50")]
		[Token(Token = "0x4000D96")]
		[FieldOffset(Offset = "0x100")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x795F88", Offset = "0x795F88")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x795F88", Offset = "0x795F88")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x795F88", Offset = "0x795F88")]
		[Token(Token = "0x4000D97")]
		[FieldOffset(Offset = "0x108")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x795FFC", Offset = "0x795FFC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x795FFC", Offset = "0x795FFC")]
		[Token(Token = "0x4000D98")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79604C", Offset = "0x79604C")]
		[Token(Token = "0x4000D99")]
		[FieldOffset(Offset = "0x118")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x796084", Offset = "0x796084")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x796084", Offset = "0x796084")]
		[Token(Token = "0x4000D9A")]
		[FieldOffset(Offset = "0x120")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7960D4", Offset = "0x7960D4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7960D4", Offset = "0x7960D4")]
		[Token(Token = "0x4000D9B")]
		[FieldOffset(Offset = "0x128")]
		public FsmBool debugThis;

		[Token(Token = "0x4000D9C")]
		[FieldOffset(Offset = "0x130")]
		private Tweener tween;

		[Token(Token = "0x60005A5")]
		[Address(RVA = "0xA7A1E4", Offset = "0xA7A1E4", Length = "0x2E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EBC568]);\n\tv25 = *([v24 @ X8_v12]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202214C]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.to = v50;\n\tv57 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.FsmGameObject::.ctor(v57);\n\tv57.useVariable = 0;\n\tthis.toGameObject = v57;\n\tv80 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v80);\n\tv80.useVariable = 0;\n\tthis.duration = v80;\n\tv81 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v81);\n\tv81.useVariable = 0;\n\tv81.value = 0;\n\tthis.setSpeedBased = v81;\n\tv82 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v82);\n\tv82.useVariable = 0;\n\tv82.value = 0;\n\tthis.snapping = v82;\n\tv83 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v83);\n\tv83.useVariable = 0;\n\tv83.value = 0;\n\tthis.setRelative = v83;\n\tv84 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v84);\n\tv84.useVariable = 0;\n\tv84.value = 0;\n\tthis.playInReverse = v84;\n\tv85 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v85);\n\tv85.useVariable = 0;\n\tv85.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v85;\n\tv86 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v86);\n\tv86.useVariable = 0;\n\tv86.value = 0;\n\tthis.finishImmediately = v86;\n\tv87 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v87);\n\tv87.useVariable = 0;\n\tthis.stringAsId = v87;\n\tv88 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v88);\n\tv88.useVariable = 0;\n\tthis.tagAsId = v88;\n\tv89 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v89);\n\tv89.value = 0f;\n\tthis.startDelay = v89;\n\tthis.selectedEase = 0x100000000;\n\tv90 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v90);\n\tv90.value = 0;\n\tthis.loops = v90;\n\tthis.loopType = 0;\n\tv91 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v91);\n\tv91.value = 1;\n\tthis.autoKillOnCompletion = v91;\n\tv92 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v92);\n\tv92.value = 0;\n\tthis.recyclable = v92;\n\tthis.updateType = 0;\n\tv93 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v93);\n\tv93.value = 0;\n\tthis.isIndependentUpdate = v93;\n\tv94 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v94);\n\tv94.value = 0;\n\tthis.debugThis = v94;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 124 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60005A6")]
		[Address(RVA = "0xA7A4C4", Offset = "0xA7A4C4", Length = "0x460")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv28 = *([1F0B950]);\n\tv29 = *([v28 @ X8_v57]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([202214D]) = v48;\nL_001D:\n\tv54 = this.target == 1;\n\tif (v54) goto L_0044;\n\tv59 = this.target == 0;\n\tv60 = ~v59;\n\tif (v60) goto L_0073;\n\tv161 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv242 = UnityEngine.GameObject::GetComponent(v161);\n\tv124 = HutongGames.PlayMaker.FsmFloat::get_Value(this.to);\n\tv316 = this.duration;\n\tv313 = this.duration == 0;\n\tv181 = ~v313;\n\tif (v181) goto L_0061;\n\tgoto L_015C;\nL_0044:\n\tv91 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv243 = UnityEngine.GameObject::GetComponent(v91);\n\tv163 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.toGameObject);\n\tv164 = UnityEngine.GameObject::get_transform(v163);\n\tv125 = UnityEngine.Transform::get_position(v164);\n\tv316 = this.duration;\nL_0061:\n\tv126 = HutongGames.PlayMaker.FsmFloat::get_Value(v316);\n\tv323 = HutongGames.PlayMaker.FsmBool::get_Value(this.snapping);\n\tv80 = DG.Tweening.ShortcutExtensions::DOLocalMoveY(v86, v72, v126, v323);\n\tthis.tween = v80;\nL_0073:\n\tv225 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv252 = v225 == 0;\n\tif (v252) goto L_0081;\n\tv261 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_0081:\n\tv307 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv312 = DG.Tweening.TweenSettingsExtensions::SetRelative(this.tween, v307);\n\tv320 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v320);\n\tv127 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv329 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v127);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv332 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv335 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v332, this.loopType);\n\tv337 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv340 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v337);\n\tv342 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv345 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v342);\n\tv347 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv350 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v347);\n\tv351 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv353 = v351 == 0;\n\tif (v353) goto L_00F2;\n\tv368 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv359 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v368);\nL_00F2:\n\tv366 = this.startEvent == 0;\n\tif (v366) goto L_010A;\n\tv373 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v373, this, Il2CppMethodInfo);\n\tv379 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v373);\nL_010A:\n\tv388 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv392 = v388 == 0;\n\tv393 = ~v392;\n\tif (v393) goto L_012C;\n\tv399 = new DG.Tweening.TweenCallback();\n\tv408 = this.finishEvent == 0;\n\tif (v408) goto L_FFFFFFFF;\n\tgoto L_0121;\nL_0121:\n\tDG.Tweening.TweenCallback::.ctor(v399, this, *([v420 @ X8_v29 (Il2CppMethodInfo)]));\n\tv406 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v399);\nL_012C:\n\tv413 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv419 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv425 = v419 == 0;\n\tif (v425) goto L_013F;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Transform Local Move Y\");\nL_013F:\n\tv293 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv295 = v293 == 0;\n\tif (v295) goto L_015B;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_015B:\n\treturn;\nL_015C:\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n// 271 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			FsmFloat fsmFloat;
			float endValue;
			Transform transform;
			if (target != Target.GameObject)
			{
				if (target != Target.Value)
				{
					goto IL_0184;
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
				Vector3 position = transform2.position;
				fsmFloat = duration;
				endValue = position.y;
				transform = component2;
			}
			float value3 = fsmFloat.Value;
			bool value4 = snapping.Value;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = transform.DOLocalMoveY(endValue, value3, value4);
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
			if (playInReverse.Value)
			{
				bool value11 = setReverseRelative.Value;
				Tweener tweener8 = tween.From(value11);
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
				State.Debug("DOTween Transform Local Move Y");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x60005A7")]
		[Address(RVA = "0xA7A924", Offset = "0xA7A924", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ECC370]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202214E]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenTransformLocalMoveY()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
