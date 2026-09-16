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
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x751324", Offset = "0x751324")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x751324", Offset = "0x751324")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x751324", Offset = "0x751324")]
	[Token(Token = "0x20000FD")]
	public class DOTweenTransformMove : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x798DA8", Offset = "0x798DA8")]
		[Token(Token = "0x4000E38")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x798E1C", Offset = "0x798E1C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x798E1C", Offset = "0x798E1C")]
		[Token(Token = "0x4000E39")]
		[FieldOffset(Offset = "0x58")]
		public Target target;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x798E7C", Offset = "0x798E7C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x798E7C", Offset = "0x798E7C")]
		[Token(Token = "0x4000E3A")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 to;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x798ECC", Offset = "0x798ECC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x798ECC", Offset = "0x798ECC")]
		[Token(Token = "0x4000E3B")]
		[FieldOffset(Offset = "0x68")]
		public FsmGameObject toGameObject;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x798F1C", Offset = "0x798F1C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x798F1C", Offset = "0x798F1C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x798F1C", Offset = "0x798F1C")]
		[Token(Token = "0x4000E3C")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool setRelative;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x798F90", Offset = "0x798F90")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x798F90", Offset = "0x798F90")]
		[Token(Token = "0x4000E3D")]
		[FieldOffset(Offset = "0x78")]
		public FsmBool snapping;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x798FE0", Offset = "0x798FE0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x798FE0", Offset = "0x798FE0")]
		[Token(Token = "0x4000E3E")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x799040", Offset = "0x799040")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x799040", Offset = "0x799040")]
		[Token(Token = "0x4000E3F")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x799090", Offset = "0x799090")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x799090", Offset = "0x799090")]
		[Token(Token = "0x4000E40")]
		[FieldOffset(Offset = "0x90")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7990E0", Offset = "0x7990E0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7990E0", Offset = "0x7990E0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7990E0", Offset = "0x7990E0")]
		[Token(Token = "0x4000E41")]
		[FieldOffset(Offset = "0x98")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x799154", Offset = "0x799154")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x799154", Offset = "0x799154")]
		[Token(Token = "0x4000E42")]
		[FieldOffset(Offset = "0xA0")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7991A4", Offset = "0x7991A4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7991A4", Offset = "0x7991A4")]
		[Token(Token = "0x4000E43")]
		[FieldOffset(Offset = "0xA8")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7991F4", Offset = "0x7991F4")]
		[Token(Token = "0x4000E44")]
		[FieldOffset(Offset = "0xB0")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x799208", Offset = "0x799208")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x799208", Offset = "0x799208")]
		[Token(Token = "0x4000E45")]
		[FieldOffset(Offset = "0xB8")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x799258", Offset = "0x799258")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x799258", Offset = "0x799258")]
		[Token(Token = "0x4000E46")]
		[FieldOffset(Offset = "0xC0")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7992A8", Offset = "0x7992A8")]
		[Token(Token = "0x4000E47")]
		[FieldOffset(Offset = "0xC8")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7992E0", Offset = "0x7992E0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7992E0", Offset = "0x7992E0")]
		[Token(Token = "0x4000E48")]
		[FieldOffset(Offset = "0xD0")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x799330", Offset = "0x799330")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x799330", Offset = "0x799330")]
		[Token(Token = "0x4000E49")]
		[FieldOffset(Offset = "0xD8")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x799380", Offset = "0x799380")]
		[Token(Token = "0x4000E4A")]
		[FieldOffset(Offset = "0xE0")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7993B8", Offset = "0x7993B8")]
		[Token(Token = "0x4000E4B")]
		[FieldOffset(Offset = "0xE4")]
		public Ease easeType;

		[Token(Token = "0x4000E4C")]
		[FieldOffset(Offset = "0xE8")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7993F0", Offset = "0x7993F0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7993F0", Offset = "0x7993F0")]
		[Token(Token = "0x4000E4D")]
		[FieldOffset(Offset = "0xF0")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x799440", Offset = "0x799440")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x799440", Offset = "0x799440")]
		[Token(Token = "0x4000E4E")]
		[FieldOffset(Offset = "0xF8")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x799490", Offset = "0x799490")]
		[Token(Token = "0x4000E4F")]
		[FieldOffset(Offset = "0x100")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7994C8", Offset = "0x7994C8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7994C8", Offset = "0x7994C8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7994C8", Offset = "0x7994C8")]
		[Token(Token = "0x4000E50")]
		[FieldOffset(Offset = "0x108")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79953C", Offset = "0x79953C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79953C", Offset = "0x79953C")]
		[Token(Token = "0x4000E51")]
		[FieldOffset(Offset = "0x110")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79958C", Offset = "0x79958C")]
		[Token(Token = "0x4000E52")]
		[FieldOffset(Offset = "0x118")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7995C4", Offset = "0x7995C4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7995C4", Offset = "0x7995C4")]
		[Token(Token = "0x4000E53")]
		[FieldOffset(Offset = "0x120")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x799614", Offset = "0x799614")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x799614", Offset = "0x799614")]
		[Token(Token = "0x4000E54")]
		[FieldOffset(Offset = "0x128")]
		public FsmBool debugThis;

		[Token(Token = "0x4000E55")]
		[FieldOffset(Offset = "0x130")]
		private Tweener tween;

		[Token(Token = "0x60005C4")]
		[Address(RVA = "0xA7D6B8", Offset = "0xA7D6B8", Length = "0x2E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1EC3100]);\n\tv25 = *([v24 @ X8_v14]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202215E]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv50 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.to = v50;\n\tv57 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.FsmGameObject::.ctor(v57);\n\tv57.useVariable = 0;\n\tthis.toGameObject = v57;\n\tv82 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v82);\n\tv82.useVariable = 0;\n\tthis.duration = v82;\n\tv83 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v83);\n\tv83.useVariable = 0;\n\tv83.value = 0;\n\tthis.setSpeedBased = v83;\n\tv84 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v84);\n\tv84.useVariable = 0;\n\tv84.value = 0;\n\tthis.snapping = v84;\n\tv85 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v85);\n\tv85.useVariable = 0;\n\tv85.value = 0;\n\tthis.setRelative = v85;\n\tv86 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v86);\n\tv86.useVariable = 0;\n\tv86.value = 0;\n\tthis.playInReverse = v86;\n\tv87 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v87);\n\tv87.useVariable = 0;\n\tv87.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v87;\n\tv88 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v88);\n\tv88.useVariable = 0;\n\tv88.value = 0;\n\tthis.finishImmediately = v88;\n\tv89 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v89);\n\tv89.useVariable = 0;\n\tthis.stringAsId = v89;\n\tv90 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v90);\n\tv90.useVariable = 0;\n\tthis.tagAsId = v90;\n\tv91 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v91);\n\tv91.value = 0f;\n\tthis.startDelay = v91;\n\tthis.selectedEase = 0x100000000;\n\tv92 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v92);\n\tv92.value = 0;\n\tthis.loops = v92;\n\tthis.loopType = 0;\n\tv93 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v93);\n\tv93.value = 1;\n\tthis.autoKillOnCompletion = v93;\n\tv94 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v94);\n\tv94.value = 0;\n\tthis.recyclable = v94;\n\tthis.updateType = 0;\n\tv95 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v95);\n\tv95.value = 0;\n\tthis.isIndependentUpdate = v95;\n\tv96 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v96);\n\tv96.value = 0;\n\tthis.debugThis = v96;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 126 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x60005C5")]
		[Address(RVA = "0xA7D9A0", Offset = "0xA7D9A0", Length = "0x470")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv32 = *([1EDD4E0]);\n\tv33 = *([v32 @ X8_v57]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([202215F]) = v52;\nL_001F:\n\tv58 = this.target == 1;\n\tif (v58) goto L_0043;\n\tv63 = this.target == 0;\n\tv64 = ~v63;\n\tif (v64) goto L_0077;\n\tv173 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv254 = UnityEngine.GameObject::GetComponent(v173);\n\tv140 = HutongGames.PlayMaker.FsmVector3::get_Value(this.to);\n\tv136 = v140.y;\n\tv134 = v140.z;\n\tgoto L_0062;\nL_0043:\n\tv104 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv255 = UnityEngine.GameObject::GetComponent(v104);\n\tv174 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.toGameObject);\n\tv175 = UnityEngine.GameObject::get_transform(v174);\n\tv140 = UnityEngine.Transform::get_position(v175);\n\tv136 = v140.y;\n\tv134 = v140.z;\nL_0062:\n\tv138 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tv350 = HutongGames.PlayMaker.FsmBool::get_Value(this.snapping);\n\t// 112 MakeStruct v76 @ AGGA7DADC_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v140 @ V0_v1 (UnityEngine.Vector3), v136 @ V1_v1 (System.Single), v134 @ V2_v1 (System.Single)\n\tv93 = DG.Tweening.ShortcutExtensions::DOMove(v99, v76, v138, v350);\n\tthis.tween = v93;\nL_0077:\n\tv233 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv266 = v233 == 0;\n\tif (v266) goto L_0085;\n\tv275 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_0085:\n\tv329 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv336 = DG.Tweening.TweenSettingsExtensions::SetRelative(this.tween, v329);\n\tv347 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v347);\n\tv139 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv356 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v139);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv359 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv362 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v359, this.loopType);\n\tv364 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv367 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v364);\n\tv369 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv372 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v369);\n\tv374 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv377 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v374);\n\tv378 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv380 = v378 == 0;\n\tif (v380) goto L_00F6;\n\tv395 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv386 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v395);\nL_00F6:\n\tv393 = this.startEvent == 0;\n\tif (v393) goto L_010E;\n\tv400 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v400, this, Il2CppMethodInfo);\n\tv406 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v400);\nL_010E:\n\tv415 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv419 = v415 == 0;\n\tv420 = ~v419;\n\tif (v420) goto L_0130;\n\tv426 = new DG.Tweening.TweenCallback();\n\tv435 = this.finishEvent == 0;\n\tif (v435) goto L_FFFFFFFF;\n\tgoto L_0125;\nL_0125:\n\tDG.Tweening.TweenCallback::.ctor(v426, this, *([v447 @ X8_v30 (Il2CppMethodInfo)]));\n\tv433 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v426);\nL_0130:\n\tv440 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv446 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv452 = v446 == 0;\n\tif (v452) goto L_0143;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Transform Move\");\nL_0143:\n\tv315 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv317 = v315 == 0;\n\tif (v317) goto L_0163;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0163:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 278 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = transform.DOMove(endValue, value2, value3);
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
				State.Debug("DOTween Transform Move");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x60005C6")]
		[Address(RVA = "0xA7DE10", Offset = "0xA7DE10", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EA52E0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022160]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenTransformMove()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
