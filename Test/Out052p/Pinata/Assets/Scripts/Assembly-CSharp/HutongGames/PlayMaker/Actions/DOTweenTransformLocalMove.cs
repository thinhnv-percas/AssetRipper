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
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x750F04", Offset = "0x750F04")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x750F04", Offset = "0x750F04")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x750F04", Offset = "0x750F04")]
	[Token(Token = "0x20000F5")]
	public class DOTweenTransformLocalMove : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7946F0", Offset = "0x7946F0")]
		[Token(Token = "0x4000D43")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x794764", Offset = "0x794764")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x794764", Offset = "0x794764")]
		[Token(Token = "0x4000D44")]
		[FieldOffset(Offset = "0x58")]
		public Target target;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7947C4", Offset = "0x7947C4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7947C4", Offset = "0x7947C4")]
		[Token(Token = "0x4000D45")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 to;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x794814", Offset = "0x794814")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x794814", Offset = "0x794814")]
		[Token(Token = "0x4000D46")]
		[FieldOffset(Offset = "0x68")]
		public FsmGameObject toGameObject;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x794864", Offset = "0x794864")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x794864", Offset = "0x794864")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x794864", Offset = "0x794864")]
		[Token(Token = "0x4000D47")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool setRelative;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7948D8", Offset = "0x7948D8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7948D8", Offset = "0x7948D8")]
		[Token(Token = "0x4000D48")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool snapping;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x794928", Offset = "0x794928")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x794928", Offset = "0x794928")]
		[Token(Token = "0x4000D49")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x794988", Offset = "0x794988")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x794988", Offset = "0x794988")]
		[Token(Token = "0x4000D4A")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7949D8", Offset = "0x7949D8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7949D8", Offset = "0x7949D8")]
		[Token(Token = "0x4000D4B")]
		[FieldOffset(Offset = "0x90")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x794A28", Offset = "0x794A28")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x794A28", Offset = "0x794A28")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x794A28", Offset = "0x794A28")]
		[Token(Token = "0x4000D4C")]
		[FieldOffset(Offset = "0x98")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x794A9C", Offset = "0x794A9C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x794A9C", Offset = "0x794A9C")]
		[Token(Token = "0x4000D4D")]
		[FieldOffset(Offset = "0xA0")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x794AEC", Offset = "0x794AEC")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x794AEC", Offset = "0x794AEC")]
		[Token(Token = "0x4000D4E")]
		[FieldOffset(Offset = "0xA8")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x794B3C", Offset = "0x794B3C")]
		[Token(Token = "0x4000D4F")]
		[FieldOffset(Offset = "0xB0")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x794B50", Offset = "0x794B50")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x794B50", Offset = "0x794B50")]
		[Token(Token = "0x4000D50")]
		[FieldOffset(Offset = "0xB8")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x794BA0", Offset = "0x794BA0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x794BA0", Offset = "0x794BA0")]
		[Token(Token = "0x4000D51")]
		[FieldOffset(Offset = "0xC0")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x794BF0", Offset = "0x794BF0")]
		[Token(Token = "0x4000D52")]
		[FieldOffset(Offset = "0xC8")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x794C28", Offset = "0x794C28")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x794C28", Offset = "0x794C28")]
		[Token(Token = "0x4000D53")]
		[FieldOffset(Offset = "0xD0")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x794C78", Offset = "0x794C78")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x794C78", Offset = "0x794C78")]
		[Token(Token = "0x4000D54")]
		[FieldOffset(Offset = "0xD8")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x794CC8", Offset = "0x794CC8")]
		[Token(Token = "0x4000D55")]
		[FieldOffset(Offset = "0xE0")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x794D00", Offset = "0x794D00")]
		[Token(Token = "0x4000D56")]
		[FieldOffset(Offset = "0xE4")]
		public Ease easeType;

		[Token(Token = "0x4000D57")]
		[FieldOffset(Offset = "0xE8")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x794D38", Offset = "0x794D38")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x794D38", Offset = "0x794D38")]
		[Token(Token = "0x4000D58")]
		[FieldOffset(Offset = "0xF0")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x794D88", Offset = "0x794D88")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x794D88", Offset = "0x794D88")]
		[Token(Token = "0x4000D59")]
		[FieldOffset(Offset = "0xF8")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x794DD8", Offset = "0x794DD8")]
		[Token(Token = "0x4000D5A")]
		[FieldOffset(Offset = "0x100")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x794E10", Offset = "0x794E10")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x794E10", Offset = "0x794E10")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x794E10", Offset = "0x794E10")]
		[Token(Token = "0x4000D5B")]
		[FieldOffset(Offset = "0x108")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x794E84", Offset = "0x794E84")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x794E84", Offset = "0x794E84")]
		[Token(Token = "0x4000D5C")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x794ED4", Offset = "0x794ED4")]
		[Token(Token = "0x4000D5D")]
		[FieldOffset(Offset = "0x118")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x794F0C", Offset = "0x794F0C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x794F0C", Offset = "0x794F0C")]
		[Token(Token = "0x4000D5E")]
		[FieldOffset(Offset = "0x120")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x794F5C", Offset = "0x794F5C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x794F5C", Offset = "0x794F5C")]
		[Token(Token = "0x4000D5F")]
		[FieldOffset(Offset = "0x128")]
		public FsmBool debugThis;

		[Token(Token = "0x4000D60")]
		[FieldOffset(Offset = "0x130")]
		private Tweener tween;

		[Token(Token = "0x600059B")]
		[Address(RVA = "0xA791F8", Offset = "0xA791F8", Length = "0x2E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EFEED0]);\n\tv25 = *([v24 @ X8_v14]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022146]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.to = v50;\n\tv57 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.FsmGameObject::.ctor(v57);\n\tv57.useVariable = 0;\n\tthis.toGameObject = v57;\n\tv82 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v82);\n\tv82.useVariable = 0;\n\tthis.duration = v82;\n\tv83 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v83);\n\tv83.useVariable = 0;\n\tv83.value = 0;\n\tthis.setSpeedBased = v83;\n\tv84 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v84);\n\tv84.useVariable = 0;\n\tv84.value = 0;\n\tthis.snapping = v84;\n\tv85 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v85);\n\tv85.useVariable = 0;\n\tv85.value = 0;\n\tthis.setRelative = v85;\n\tv86 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v86);\n\tv86.useVariable = 0;\n\tv86.value = 0;\n\tthis.playInReverse = v86;\n\tv87 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v87);\n\tv87.useVariable = 0;\n\tv87.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v87;\n\tv88 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v88);\n\tv88.useVariable = 0;\n\tv88.value = 0;\n\tthis.finishImmediately = v88;\n\tv89 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v89);\n\tv89.useVariable = 0;\n\tthis.stringAsId = v89;\n\tv90 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v90);\n\tv90.useVariable = 0;\n\tthis.tagAsId = v90;\n\tv91 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v91);\n\tv91.value = 0f;\n\tthis.startDelay = v91;\n\tthis.selectedEase = 0x100000000;\n\tv92 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v92);\n\tv92.value = 0;\n\tthis.loops = v92;\n\tthis.loopType = 0;\n\tv93 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v93);\n\tv93.value = 1;\n\tthis.autoKillOnCompletion = v93;\n\tv94 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v94);\n\tv94.value = 0;\n\tthis.recyclable = v94;\n\tthis.updateType = 0;\n\tv95 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v95);\n\tv95.value = 0;\n\tthis.isIndependentUpdate = v95;\n\tv96 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v96);\n\tv96.value = 0;\n\tthis.debugThis = v96;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 126 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_023b: Expected I4, but got I8
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

		[Token(Token = "0x600059C")]
		[Address(RVA = "0xA794E0", Offset = "0xA794E0", Length = "0x470")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv32 = *([1EABB68]);\n\tv33 = *([v32 @ X8_v57]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2022147]) = v52;\nL_001F:\n\tv58 = this.target == 1;\n\tif (v58) goto L_0043;\n\tv63 = this.target == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_0077;\n\tv173 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv254 = UnityEngine.GameObject::GetComponent(v173);\n\tv140 = HutongGames.PlayMaker.FsmVector3::get_Value(this.to);\n\tv136 = v140.y;\n\tv134 = v140.z;\n\tgoto L_0062;\nL_0043:\n\tv104 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv255 = UnityEngine.GameObject::GetComponent(v104);\n\tv174 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.toGameObject);\n\tv175 = UnityEngine.GameObject::get_transform(v174);\n\tv140 = UnityEngine.Transform::get_position(v175);\n\tv136 = v140.y;\n\tv134 = v140.z;\nL_0062:\n\tv138 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tv350 = HutongGames.PlayMaker.FsmBool::get_Value(this.snapping);\n\t// 112 MakeStruct v76 @ AGGA7961C_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v140 @ V0_v1 (UnityEngine.Vector3), v136 @ V1_v1 (System.Single), v134 @ V2_v1 (System.Single)\n\tv93 = DG.Tweening.ShortcutExtensions::DOLocalMove(v99, v76, v138, v350);\n\tthis.tween = v93;\nL_0077:\n\tv233 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv266 = v233 == 0;\n\tif (v266) goto L_0085;\n\tv275 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_0085:\n\tv329 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv336 = DG.Tweening.TweenSettingsExtensions::SetRelative(this.tween, v329);\n\tv347 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v347);\n\tv139 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv356 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v139);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv359 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv362 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v359, this.loopType);\n\tv364 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv367 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v364);\n\tv369 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv372 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v369);\n\tv374 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv377 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v374);\n\tv378 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv380 = v378 == 0;\n\tif (v380) goto L_00F6;\n\tv395 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv386 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v395);\nL_00F6:\n\tv393 = this.startEvent == 0;\n\tif (v393) goto L_010E;\n\tv400 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v400, this, Il2CppMethodInfo);\n\tv406 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v400);\nL_010E:\n\tv415 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv419 = v415 == 0;\n\tv420 = ~v419;\n\tif (v420) goto L_0130;\n\tv426 = new DG.Tweening.TweenCallback();\n\tv435 = this.finishEvent == 0;\n\tif (v435) goto L_FFFFFFFF;\n\tgoto L_0125;\nL_0125:\n\tDG.Tweening.TweenCallback::.ctor(v426, this, *([v447 @ X8_v30 (Il2CppMethodInfo)]));\n\tv433 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v426);\nL_0130:\n\tv440 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv446 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv452 = v446 == 0;\n\tif (v452) goto L_0143;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Transform Local Move\");\nL_0143:\n\tv315 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv317 = v315 == 0;\n\tif (v317) goto L_0163;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0163:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 278 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
				vector = transform2.position;
				y = vector.y;
				z = vector.z;
				transform = component2;
			}
			float value2 = duration.Value;
			bool value3 = snapping.Value;
			Vector3 endValue = default(Vector3);
			endValue.x = vector.x;
			endValue.y = y;
			endValue.z = z;
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = transform.DOLocalMove(endValue, value2, value3);
			tween = tweenerCore;
			goto IL_0193;
			IL_0193:
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
				State.Debug("DOTween Transform Local Move");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x600059D")]
		[Address(RVA = "0xA79950", Offset = "0xA79950", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EB3F88]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022148]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenTransformLocalMove()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
