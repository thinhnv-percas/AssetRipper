using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using Doozy.PlayMaker;
using Doozy.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75121C", Offset = "0x75121C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75121C", Offset = "0x75121C")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x75121C", Offset = "0x75121C")]
	[Token(Token = "0x20000FB")]
	public class DOTweenTransformLookAtGameObject : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x797D48", Offset = "0x797D48")]
		[Token(Token = "0x4000DFE")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x797DBC", Offset = "0x797DBC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x797DBC", Offset = "0x797DBC")]
		[Token(Token = "0x4000DFF")]
		[FieldOffset(Offset = "0x58")]
		public FsmGameObject target;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x797E1C", Offset = "0x797E1C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x797E1C", Offset = "0x797E1C")]
		[Token(Token = "0x4000E00")]
		[FieldOffset(Offset = "0x60")]
		public FsmBool setRelative;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x797E6C", Offset = "0x797E6C")]
		[Token(Token = "0x4000E01")]
		[FieldOffset(Offset = "0x68")]
		public AxisConstraint axisConstraint;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x797EA4", Offset = "0x797EA4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x797EA4", Offset = "0x797EA4")]
		[Token(Token = "0x4000E02")]
		[FieldOffset(Offset = "0x70")]
		public FsmVector3 up;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x797EF4", Offset = "0x797EF4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x797EF4", Offset = "0x797EF4")]
		[Token(Token = "0x4000E03")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x797F54", Offset = "0x797F54")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x797F54", Offset = "0x797F54")]
		[Token(Token = "0x4000E04")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x797FA4", Offset = "0x797FA4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x797FA4", Offset = "0x797FA4")]
		[Token(Token = "0x4000E05")]
		[FieldOffset(Offset = "0x88")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x797FF4", Offset = "0x797FF4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x797FF4", Offset = "0x797FF4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x797FF4", Offset = "0x797FF4")]
		[Token(Token = "0x4000E06")]
		[FieldOffset(Offset = "0x90")]
		public FsmBool playInReverse;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x798068", Offset = "0x798068")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x798068", Offset = "0x798068")]
		[Token(Token = "0x4000E07")]
		[FieldOffset(Offset = "0x98")]
		public FsmBool setReverseRelative;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7980B8", Offset = "0x7980B8")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7980B8", Offset = "0x7980B8")]
		[Token(Token = "0x4000E08")]
		[FieldOffset(Offset = "0xA0")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x798108", Offset = "0x798108")]
		[Token(Token = "0x4000E09")]
		[FieldOffset(Offset = "0xA8")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79811C", Offset = "0x79811C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79811C", Offset = "0x79811C")]
		[Token(Token = "0x4000E0A")]
		[FieldOffset(Offset = "0xB0")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x79816C", Offset = "0x79816C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79816C", Offset = "0x79816C")]
		[Token(Token = "0x4000E0B")]
		[FieldOffset(Offset = "0xB8")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7981BC", Offset = "0x7981BC")]
		[Token(Token = "0x4000E0C")]
		[FieldOffset(Offset = "0xC0")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7981F4", Offset = "0x7981F4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7981F4", Offset = "0x7981F4")]
		[Token(Token = "0x4000E0D")]
		[FieldOffset(Offset = "0xC8")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x798244", Offset = "0x798244")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x798244", Offset = "0x798244")]
		[Token(Token = "0x4000E0E")]
		[FieldOffset(Offset = "0xD0")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x798294", Offset = "0x798294")]
		[Token(Token = "0x4000E0F")]
		[FieldOffset(Offset = "0xD8")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7982CC", Offset = "0x7982CC")]
		[Token(Token = "0x4000E10")]
		[FieldOffset(Offset = "0xDC")]
		public Ease easeType;

		[Token(Token = "0x4000E11")]
		[FieldOffset(Offset = "0xE0")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x798304", Offset = "0x798304")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x798304", Offset = "0x798304")]
		[Token(Token = "0x4000E12")]
		[FieldOffset(Offset = "0xE8")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x798354", Offset = "0x798354")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x798354", Offset = "0x798354")]
		[Token(Token = "0x4000E13")]
		[FieldOffset(Offset = "0xF0")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7983A4", Offset = "0x7983A4")]
		[Token(Token = "0x4000E14")]
		[FieldOffset(Offset = "0xF8")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7983DC", Offset = "0x7983DC")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7983DC", Offset = "0x7983DC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7983DC", Offset = "0x7983DC")]
		[Token(Token = "0x4000E15")]
		[FieldOffset(Offset = "0x100")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x798450", Offset = "0x798450")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x798450", Offset = "0x798450")]
		[Token(Token = "0x4000E16")]
		[FieldOffset(Offset = "0x108")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7984A0", Offset = "0x7984A0")]
		[Token(Token = "0x4000E17")]
		[FieldOffset(Offset = "0x110")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7984D8", Offset = "0x7984D8")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7984D8", Offset = "0x7984D8")]
		[Token(Token = "0x4000E18")]
		[FieldOffset(Offset = "0x118")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x798528", Offset = "0x798528")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x798528", Offset = "0x798528")]
		[Token(Token = "0x4000E19")]
		[FieldOffset(Offset = "0x120")]
		public FsmBool debugThis;

		[Token(Token = "0x4000E1A")]
		[FieldOffset(Offset = "0x128")]
		private Tweener tween;

		[Token(Token = "0x60005BA")]
		[Address(RVA = "0xA7C750", Offset = "0xA7C750", Length = "0x2D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv24 = *([1F0A3F0]);\n\tv25 = *([v24 @ X8_v17]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2022158]) = v44;\nL_0018:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tthis.target = 0;\n\tv50 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v50);\n\tv50.useVariable = 0;\n\tthis.duration = v50;\n\tv57 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v57);\n\tv57.useVariable = 0;\n\tv57.value = 0;\n\tthis.setSpeedBased = v57;\n\tthis.axisConstraint = 0;\n\tv83 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v83);\n\tv83.useVariable = 0;\n\tgoto L_004A;\n\tv162 = *([v158 @ X0_v12+E0]);\n\tv163 = v162 == 0;\n\tv164 = ~v163;\n\tif (v164) goto L_004A;\n\tv166 = \"il2cpp_codegen_runtime_class_init\"(v158, v69, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_004A:\n\tv65 = UnityEngine.Vector3::get_up();\n\tv83.value = v65;\n\tv83.value.y = v65.y;\n\tv83.value.z = v65.z;\n\tthis.up = v83;\n\tv84 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v84);\n\tv84.useVariable = 0;\n\tv84.value = 0;\n\tthis.setRelative = v84;\n\tv85 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v85);\n\tv85.useVariable = 0;\n\tv85.value = 0;\n\tthis.playInReverse = v85;\n\tv86 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v86);\n\tv86.useVariable = 0;\n\tv86.value = 0;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.setReverseRelative = v86;\n\tv87 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v87);\n\tv87.useVariable = 0;\n\tv87.value = 0;\n\tthis.finishImmediately = v87;\n\tv88 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v88);\n\tv88.useVariable = 0;\n\tthis.stringAsId = v88;\n\tv89 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v89);\n\tv89.useVariable = 0;\n\tthis.tagAsId = v89;\n\tv90 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v90);\n\tv90.value = 0f;\n\tthis.startDelay = v90;\n\tthis.selectedEase = 0x100000000;\n\tv91 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v91);\n\tv91.value = 0;\n\tthis.loops = v91;\n\tthis.loopType = 0;\n\tv92 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v92);\n\tv92.value = 1;\n\tthis.autoKillOnCompletion = v92;\n\tv93 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v93);\n\tv93.value = 0;\n\tthis.recyclable = v93;\n\tthis.updateType = 0;\n\tv94 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v94);\n\tv94.value = 0;\n\tthis.isIndependentUpdate = v94;\n\tv95 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v95);\n\tv95.value = 0;\n\tthis.debugThis = v95;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 123 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_0241: Expected I4, but got I8
			base.Reset();
			gameObject = null;
			target = null;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = false;
			duration = fsmFloat;
			FsmBool fsmBool = new FsmBool();
			fsmBool.useVariable = false;
			fsmBool.value = false;
			setSpeedBased = fsmBool;
			axisConstraint = default(AxisConstraint);
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = false;
			Vector3 vector = (fsmVector.value = Vector3.up);
			fsmVector.value.y = vector.y;
			fsmVector.value.z = vector.z;
			up = fsmVector;
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

		[Token(Token = "0x60005BB")]
		[Address(RVA = "0xA7CA20", Offset = "0xA7CA20", Length = "0x430")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv32 = *([1EE8148]);\n\tv33 = *([v32 @ X8_v54]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([2022159]) = v52;\nL_001F:\n\tv57 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tv223 = UnityEngine.GameObject::GetComponent(v57);\n\tv143 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.target);\n\tv144 = UnityEngine.GameObject::get_transform(v143);\n\tv109 = UnityEngine.Transform::get_position(v144);\n\tv110 = HutongGames.PlayMaker.FsmFloat::get_Value(this.duration);\n\tv277 = HutongGames.PlayMaker.FsmVector3::get_Value(this.up);\n\tv87 = 0;\n\tv284 = 0x115D2C0(&v87 @ stack_-70_v3 (System.Nullable`1<UnityEngine.Vector3>), Il2CppMethodInfo, 0, v37, v38, v39, v40, v41, v277, v277.y, v277.z, v45, v46, v47, v48, v49);\n\tv224 = DG.Tweening.ShortcutExtensions::DOLookAt(v223, v109, v110, this.axisConstraint, 0);\n\tthis.tween = v224;\n\tv288 = HutongGames.PlayMaker.FsmBool::get_Value(this.setSpeedBased);\n\tv290 = v288 == 0;\n\tif (v290) goto L_006E;\n\tv295 = DG.Tweening.TweenSettingsExtensions::SetSpeedBased(this.tween);\nL_006E:\n\tv298 = HutongGames.PlayMaker.FsmBool::get_Value(this.setRelative);\n\tv301 = DG.Tweening.TweenSettingsExtensions::SetRelative(this.tween, v298);\n\tv304 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tDoozy.PlayMaker.DOTweenExtensions::SetTweenId(this.tween, this.tweenIdType, this.stringAsId, this.tagAsId, v304);\n\tv112 = HutongGames.PlayMaker.FsmFloat::get_Value(this.startDelay);\n\tv310 = DG.Tweening.TweenSettingsExtensions::SetDelay(this.tween, v112);\n\tDoozy.PlayMaker.DOTweenExtensions::SetSelectedEase(this.tween, this.selectedEase, this.easeType, this.animationCurve);\n\tv313 = HutongGames.PlayMaker.FsmInt::get_Value(this.loops);\n\tv316 = DG.Tweening.TweenSettingsExtensions::SetLoops(this.tween, v313, this.loopType);\n\tv318 = HutongGames.PlayMaker.FsmBool::get_Value(this.autoKillOnCompletion);\n\tv321 = DG.Tweening.TweenSettingsExtensions::SetAutoKill(this.tween, v318);\n\tv323 = HutongGames.PlayMaker.FsmBool::get_Value(this.recyclable);\n\tv326 = DG.Tweening.TweenSettingsExtensions::SetRecyclable(this.tween, v323);\n\tv328 = HutongGames.PlayMaker.FsmBool::get_Value(this.isIndependentUpdate);\n\tv331 = DG.Tweening.TweenSettingsExtensions::SetUpdate(this.tween, this.updateType, v328);\n\tv332 = HutongGames.PlayMaker.FsmBool::get_Value(this.playInReverse);\n\tv334 = v332 == 0;\n\tif (v334) goto L_00DF;\n\tv349 = HutongGames.PlayMaker.FsmBool::get_Value(this.setReverseRelative);\n\tv340 = DG.Tweening.TweenSettingsExtensions::From(this.tween, v349);\nL_00DF:\n\tv347 = this.startEvent == 0;\n\tif (v347) goto L_00F7;\n\tv354 = new DG.Tweening.TweenCallback();\n\tDG.Tweening.TweenCallback::.ctor(v354, this, Il2CppMethodInfo);\n\tv360 = DG.Tweening.TweenSettingsExtensions::OnStart(this.tween, v354);\nL_00F7:\n\tv369 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv373 = v369 == 0;\n\tv374 = ~v373;\n\tif (v374) goto L_0119;\n\tv380 = new DG.Tweening.TweenCallback();\n\tv389 = this.finishEvent == 0;\n\tif (v389) goto L_FFFFFFFF;\n\tgoto L_010E;\nL_010E:\n\tDG.Tweening.TweenCallback::.ctor(v380, this, *([v401 @ X8_v35 (Il2CppMethodInfo)]));\n\tv387 = DG.Tweening.TweenSettingsExtensions::OnComplete(this.tween, v380);\nL_0119:\n\tv394 = DG.Tweening.TweenExtensions::Play(this.tween);\n\tv400 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv406 = v400 == 0;\n\tif (v406) goto L_012C;\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(this.fsmState, \"DOTween Transform Look At GameObject\");\nL_012C:\n\tv416 = HutongGames.PlayMaker.FsmBool::get_Value(this.finishImmediately);\n\tv267 = v416 == 0;\n\tif (v267) goto L_013F;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\nL_013F:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 255 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			Transform component = ownerDefaultTarget.GetComponent<Transform>();
			GameObject value = target.Value;
			Transform transform = value.transform;
			Vector3 position = transform.position;
			float value2 = duration.Value;
			Vector3 value3 = up.Value;
			Vector3? vector = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @115D2C0 (inside System.Nullable`1<UnityEngine.Color>::Unbox +0xC8)");
			Tweener tweener = component.DOLookAt(position, value2, axisConstraint);
			tween = tweener;
			if (setSpeedBased.Value)
			{
				Tweener tweener2 = tween.SetSpeedBased();
			}
			bool value4 = setRelative.Value;
			Tweener tweener3 = tween.SetRelative(value4);
			GameObject ownerDefaultTarget2 = Fsm.GetOwnerDefaultTarget(gameObject);
			tween.SetTweenId(tweenIdType, stringAsId, tagAsId, ownerDefaultTarget2);
			float value5 = startDelay.Value;
			Tweener tweener4 = tween.SetDelay(value5);
			tween.SetSelectedEase(selectedEase, easeType, animationCurve);
			int value6 = loops.Value;
			Tweener tweener5 = tween.SetLoops(value6, loopType);
			bool value7 = autoKillOnCompletion.Value;
			Tweener tweener6 = tween.SetAutoKill(value7);
			bool value8 = recyclable.Value;
			Tweener tweener7 = tween.SetRecyclable(value8);
			bool value9 = isIndependentUpdate.Value;
			Tweener tweener8 = tween.SetUpdate(updateType, value9);
			if (playInReverse.Value)
			{
				bool value10 = setReverseRelative.Value;
				Tweener tweener9 = tween.From(value10);
			}
			if (startEvent != null)
			{
				TweenCallback action = delegate
				{
					Fsm.Event(startEvent);
				};
				Tweener tweener10 = tween.OnStart(action);
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
				Tweener tweener11 = tween.OnComplete(action2);
			}
			Tweener tweener12 = tween.Play();
			if (debugThis.Value)
			{
				State.Debug("DOTween Transform Look At GameObject");
			}
			if (finishImmediately.Value)
			{
				Finish();
			}
		}

		[Token(Token = "0x60005BC")]
		[Address(RVA = "0xA7CE50", Offset = "0xA7CE50", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1ECC8F8]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202215A]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenTransformLookAtGameObject()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
