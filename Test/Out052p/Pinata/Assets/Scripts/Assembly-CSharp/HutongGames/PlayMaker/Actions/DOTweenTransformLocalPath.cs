using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening;
using Doozy.PlayMaker;
using Doozy.PlayMaker.Actions;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x751114", Offset = "0x751114")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x751114", Offset = "0x751114")]
	[AttributeAttribute(Type = typeof(HelpUrlAttribute), RVA = "0x751114", Offset = "0x751114")]
	[Token(Token = "0x20000F9")]
	public class DOTweenTransformLocalPath : FsmStateAction
	{
		[Token(Token = "0x2000478")]
		public enum LookAt
		{
			[Token(Token = "0x400210B")]
			nothing = 0,
			[Token(Token = "0x400210C")]
			position = 1,
			[Token(Token = "0x400210D")]
			target = 2,
			[Token(Token = "0x400210E")]
			ahead = 3
		}

		[RequiredField]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7969E0", Offset = "0x7969E0")]
		[Token(Token = "0x4000DBB")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x796A54", Offset = "0x796A54")]
		[Token(Token = "0x4000DBC")]
		[FieldOffset(Offset = "0x58")]
		public FsmGameObject[] path;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x796AA0", Offset = "0x796AA0")]
		[Token(Token = "0x4000DBD")]
		[FieldOffset(Offset = "0x60")]
		public PathType pathType;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x796AD8", Offset = "0x796AD8")]
		[Token(Token = "0x4000DBE")]
		[FieldOffset(Offset = "0x64")]
		public PathMode pathMode;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x796B10", Offset = "0x796B10")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x796B10", Offset = "0x796B10")]
		[Token(Token = "0x4000DBF")]
		[FieldOffset(Offset = "0x68")]
		public FsmInt resolution;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x796B60", Offset = "0x796B60")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x796B60", Offset = "0x796B60")]
		[Token(Token = "0x4000DC0")]
		[FieldOffset(Offset = "0x70")]
		public FsmColor gizmoColor;

		[RequiredField]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x796BB0", Offset = "0x796BB0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x796BB0", Offset = "0x796BB0")]
		[Token(Token = "0x4000DC1")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat duration;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x796C10", Offset = "0x796C10")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x796C10", Offset = "0x796C10")]
		[Token(Token = "0x4000DC2")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool setSpeedBased;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x796C60", Offset = "0x796C60")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x796C60", Offset = "0x796C60")]
		[Token(Token = "0x4000DC3")]
		[FieldOffset(Offset = "0x88")]
		public FsmFloat startDelay;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x796CB0", Offset = "0x796CB0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x796CB0", Offset = "0x796CB0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x796CB0", Offset = "0x796CB0")]
		[Token(Token = "0x4000DC4")]
		[FieldOffset(Offset = "0x90")]
		public FsmBool closePath;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x796D24", Offset = "0x796D24")]
		[Token(Token = "0x4000DC5")]
		[FieldOffset(Offset = "0x98")]
		public AxisConstraint lockPosition;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x796D5C", Offset = "0x796D5C")]
		[Token(Token = "0x4000DC6")]
		[FieldOffset(Offset = "0x9C")]
		public AxisConstraint lockRotation;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x796D94", Offset = "0x796D94")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x796D94", Offset = "0x796D94")]
		[Token(Token = "0x4000DC7")]
		[FieldOffset(Offset = "0xA0")]
		public LookAt lookAt;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x796DF4", Offset = "0x796DF4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x796DF4", Offset = "0x796DF4")]
		[Token(Token = "0x4000DC8")]
		[FieldOffset(Offset = "0xA8")]
		public FsmVector3 lookAtPosition;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x796E44", Offset = "0x796E44")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x796E44", Offset = "0x796E44")]
		[Token(Token = "0x4000DC9")]
		[FieldOffset(Offset = "0xB0")]
		public FsmGameObject lookAtTarget;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x796E94", Offset = "0x796E94")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x796E94", Offset = "0x796E94")]
		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x796E94", Offset = "0x796E94")]
		[Token(Token = "0x4000DCA")]
		[FieldOffset(Offset = "0xB8")]
		public FsmFloat lookAhead;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x796EFC", Offset = "0x796EFC")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x796EFC", Offset = "0x796EFC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x796EFC", Offset = "0x796EFC")]
		[Token(Token = "0x4000DCB")]
		[FieldOffset(Offset = "0xC0")]
		public FsmVector3 forwardDirection;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x796F70", Offset = "0x796F70")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x796F70", Offset = "0x796F70")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x796F70", Offset = "0x796F70")]
		[Token(Token = "0x4000DCC")]
		[FieldOffset(Offset = "0xC8")]
		public FsmVector3 up;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x796FE4", Offset = "0x796FE4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x796FE4", Offset = "0x796FE4")]
		[Token(Token = "0x4000DCD")]
		[FieldOffset(Offset = "0xD0")]
		public FsmEvent startEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x797034", Offset = "0x797034")]
		[Token(Token = "0x4000DCE")]
		[FieldOffset(Offset = "0xD8")]
		public FsmEvent finishEvent;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x797048", Offset = "0x797048")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x797048", Offset = "0x797048")]
		[Token(Token = "0x4000DCF")]
		[FieldOffset(Offset = "0xE0")]
		public FsmBool finishImmediately;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x797098", Offset = "0x797098")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x797098", Offset = "0x797098")]
		[Token(Token = "0x4000DD0")]
		[FieldOffset(Offset = "0xE8")]
		public string tweenIdDescription;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7970E8", Offset = "0x7970E8")]
		[Token(Token = "0x4000DD1")]
		[FieldOffset(Offset = "0xF0")]
		public TweenId tweenIdType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x797120", Offset = "0x797120")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x797120", Offset = "0x797120")]
		[Token(Token = "0x4000DD2")]
		[FieldOffset(Offset = "0xF8")]
		public FsmString stringAsId;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x797170", Offset = "0x797170")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x797170", Offset = "0x797170")]
		[Token(Token = "0x4000DD3")]
		[FieldOffset(Offset = "0x100")]
		public FsmString tagAsId;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7971C0", Offset = "0x7971C0")]
		[Token(Token = "0x4000DD4")]
		[FieldOffset(Offset = "0x108")]
		public SelectedEase selectedEase;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7971F8", Offset = "0x7971F8")]
		[Token(Token = "0x4000DD5")]
		[FieldOffset(Offset = "0x10C")]
		public Ease easeType;

		[Token(Token = "0x4000DD6")]
		[FieldOffset(Offset = "0x110")]
		public FsmAnimationCurve animationCurve;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x797230", Offset = "0x797230")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x797230", Offset = "0x797230")]
		[Token(Token = "0x4000DD7")]
		[FieldOffset(Offset = "0x118")]
		public string loopsDescriptionArea;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x797280", Offset = "0x797280")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x797280", Offset = "0x797280")]
		[Token(Token = "0x4000DD8")]
		[FieldOffset(Offset = "0x120")]
		public FsmInt loops;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7972D0", Offset = "0x7972D0")]
		[Token(Token = "0x4000DD9")]
		[FieldOffset(Offset = "0x128")]
		public LoopType loopType;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x797308", Offset = "0x797308")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x797308", Offset = "0x797308")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x797308", Offset = "0x797308")]
		[Token(Token = "0x4000DDA")]
		[FieldOffset(Offset = "0x130")]
		public FsmBool autoKillOnCompletion;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x79737C", Offset = "0x79737C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x79737C", Offset = "0x79737C")]
		[Token(Token = "0x4000DDB")]
		[FieldOffset(Offset = "0x138")]
		public FsmBool recyclable;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7973CC", Offset = "0x7973CC")]
		[Token(Token = "0x4000DDC")]
		[FieldOffset(Offset = "0x140")]
		public UpdateType updateType;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x797404", Offset = "0x797404")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x797404", Offset = "0x797404")]
		[Token(Token = "0x4000DDD")]
		[FieldOffset(Offset = "0x148")]
		public FsmBool isIndependentUpdate;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x797454", Offset = "0x797454")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x797454", Offset = "0x797454")]
		[Token(Token = "0x4000DDE")]
		[FieldOffset(Offset = "0x150")]
		public FsmBool debugThis;

		[Token(Token = "0x4000DDF")]
		[FieldOffset(Offset = "0x158")]
		private Tweener tween;

		[Token(Token = "0x60005AF")]
		[Address(RVA = "0xA7B1C4", Offset = "0xA7B1C4", Length = "0x354")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EBC768]);\n\tv27 = *([v26 @ X8_v19]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2022152]) = v46;\nL_0019:\n\tHutongGames.PlayMaker.FsmStateAction::Reset(this);\n\tthis.gameObject = 0;\n\tv52 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v52);\n\tv52.useVariable = 0;\n\tthis.duration = v52;\n\tv59 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v59);\n\tv59.useVariable = 0;\n\tv59.value = 0;\n\tthis.setSpeedBased = v59;\n\tthis.pathType = 0x100000000;\n\tv97 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v97);\n\tv97.useVariable = 0;\n\tv97.value = 0xA;\n\tthis.resolution = v97;\n\tv98 = new HutongGames.PlayMaker.FsmColor();\n\tHutongGames.PlayMaker.FsmColor::.ctor(v98);\n\tv98.useVariable = 0;\n\tthis.gizmoColor = v98;\n\tv99 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v99);\n\tv99.useVariable = 0;\n\tv99.value = 0;\n\tthis.closePath = v99;\n\tthis.lockPosition = 0;\n\tthis.lookAt = 0;\n\tv100 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v100);\n\tv100.useVariable = 0;\n\tgoto L_006F;\n\tv192 = *([v188 @ X0_v18+E0]);\n\tv193 = v192 == 0;\n\tv194 = ~v193;\n\tif (v194) goto L_006F;\n\tv196 = \"il2cpp_codegen_runtime_class_init\"(v188, v84, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_006F:\n\tv71 = UnityEngine.Vector3::get_zero();\n\tv100.value = v71;\n\tv100.value.y = v71.y;\n\tv100.value.z = v71.z;\n\tthis.lookAtPosition = v100;\n\tv101 = new HutongGames.PlayMaker.FsmGameObject();\n\tHutongGames.PlayMaker.FsmGameObject::.ctor(v101);\n\tv101.useVariable = 0;\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(v101, 0);\n\tthis.lookAtTarget = v101;\n\tv102 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v102);\n\tv102.useVariable = 0;\n\tv102.value = 0f;\n\tthis.lookAhead = v102;\n\tv103 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v103);\n\tv103.useVariable = 0;\n\tv72 = UnityEngine.Vector3::get_forward();\n\tv103.value = v72;\n\tv103.value.y = v72.y;\n\tv103.value.z = v72.z;\n\tthis.forwardDirection = v103;\n\tv104 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v104);\n\tv104.useVariable = 0;\n\tv73 = UnityEngine.Vector3::get_up();\n\tv104.value = v73;\n\tv104.value.y = v73.y;\n\tv104.value.z = v73.z;\n\tthis.startEvent = 0;\n\tthis.finishEvent = 0;\n\tthis.up = v104;\n\tv105 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v105);\n\tv105.useVariable = 0;\n\tv105.value = 0;\n\tthis.finishImmediately = v105;\n\tv106 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v106);\n\tv106.value = 0f;\n\tthis.startDelay = v106;\n\tthis.easeType = 1;\n\tv107 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v107);\n\tv107.value = 0;\n\tthis.loops = v107;\n\tthis.loopType = 0;\n\tv108 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v108);\n\tv108.value = 1;\n\tthis.autoKillOnCompletion = v108;\n\tv109 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v109);\n\tv109.value = 0;\n\tthis.recyclable = v109;\n\tthis.updateType = 0;\n\tv110 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v110);\n\tv110.value = 0;\n\tthis.isIndependentUpdate = v110;\n\tv111 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v111);\n\tv111.value = 0;\n\tthis.debugThis = v111;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 148 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			//IL_0061: Expected I4, but got I8
			base.Reset();
			gameObject = null;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = false;
			duration = fsmFloat;
			FsmBool fsmBool = new FsmBool();
			fsmBool.useVariable = false;
			fsmBool.value = false;
			setSpeedBased = fsmBool;
			pathType = PathType.Linear;
			FsmInt fsmInt = new FsmInt();
			fsmInt.useVariable = false;
			fsmInt.Value = 10;
			resolution = fsmInt;
			FsmColor fsmColor = new FsmColor();
			fsmColor.useVariable = false;
			gizmoColor = fsmColor;
			FsmBool fsmBool2 = new FsmBool();
			fsmBool2.useVariable = false;
			fsmBool2.value = false;
			closePath = fsmBool2;
			lockPosition = default(AxisConstraint);
			lookAt = default(LookAt);
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = false;
			Vector3 vector = (fsmVector.value = Vector3.zero);
			fsmVector.value.y = vector.y;
			fsmVector.value.z = vector.z;
			lookAtPosition = fsmVector;
			FsmGameObject fsmGameObject = new FsmGameObject();
			fsmGameObject.useVariable = false;
			fsmGameObject.Value = null;
			lookAtTarget = fsmGameObject;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = false;
			fsmFloat2.Value = 0f;
			lookAhead = fsmFloat2;
			FsmVector3 fsmVector2 = new FsmVector3();
			fsmVector2.useVariable = false;
			Vector3 vector2 = (fsmVector2.value = Vector3.forward);
			fsmVector2.value.y = vector2.y;
			fsmVector2.value.z = vector2.z;
			forwardDirection = fsmVector2;
			FsmVector3 fsmVector3 = new FsmVector3();
			fsmVector3.useVariable = false;
			Vector3 vector3 = (fsmVector3.value = Vector3.up);
			fsmVector3.value.y = vector3.y;
			fsmVector3.value.z = vector3.z;
			startEvent = null;
			finishEvent = null;
			up = fsmVector3;
			FsmBool fsmBool3 = new FsmBool();
			fsmBool3.useVariable = false;
			fsmBool3.value = false;
			finishImmediately = fsmBool3;
			FsmFloat fsmFloat3 = new FsmFloat();
			fsmFloat3.Value = 0f;
			startDelay = fsmFloat3;
			easeType = Ease.Linear;
			FsmInt fsmInt2 = new FsmInt();
			fsmInt2.Value = 0;
			loops = fsmInt2;
			loopType = default(LoopType);
			FsmBool fsmBool4 = new FsmBool();
			fsmBool4.value = true;
			autoKillOnCompletion = fsmBool4;
			FsmBool fsmBool5 = new FsmBool();
			fsmBool5.value = false;
			recyclable = fsmBool5;
			updateType = default(UpdateType);
			FsmBool fsmBool6 = new FsmBool();
			fsmBool6.value = false;
			isIndependentUpdate = fsmBool6;
			FsmBool fsmBool7 = new FsmBool();
			fsmBool7.value = false;
			debugThis = fsmBool7;
		}

		[Token(Token = "0x60005B0")]
		[Address(RVA = "0xA7B518", Offset = "0xA7B518", Length = "0x99C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv36 = *([1F10E00]);\n\tv37 = *([v36 @ X8_v67]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2022153]) = v56;\nL_0021:\n\tv61 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_0033;\n\tv285 = *([v211 @ X8_v6+E0]);\n\tv286 = v285 == 0;\n\tv287 = ~v286;\n\tif (v287) goto L_0033;\n\tv296 = v211;\n\tv289 = \"il2cpp_codegen_runtime_class_init\"(v296, v59, v60, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0033:\n\tv292 = UnityEngine.Object::op_Equality(v61, 0);\n\tv298 = v292 == 0;\n\tif (v298) goto L_004A;\n\tv341 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv443 = v341 == 0;\n\tif (v443) goto L_0321;\n\tv422 = this.fsmState;\n\tgoto L_0085;\nL_004A:\n\tv346 = UnityEngine.GameObject::GetComponent(v61);\n\tgoto L_005A;\n\tv464 = *([v212 @ X8_v11+E0]);\n\tv465 = v464 == 0;\n\tv466 = ~v465;\n\tif (v466) goto L_005A;\n\tv481 = v212;\n\tv468 = \"il2cpp_codegen_runtime_class_init\"(v481, v345, v149, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_005A:\n\tv332 = UnityEngine.Object::op_Equality(v346, 0);\n\tv483 = v332 == 0;\n\tif (v483) goto L_0087;\n\tv459 = HutongGames.PlayMaker.FsmBool::get_Value(this.debugThis);\n\tv462 = v459 == 0;\n\tif (v462) goto L_0321;\n\tv489 = UnityEngine.Object::get_name(v61);\n\tv507 = System.String::Concat(\"ERROR - DOTween Transform Local Path - The GameObject [\", v489, \"] does not have a Transform Component\");\nL_0085:\n\tDoozy.PlayMaker.Actions.DOTweenActionsUtils::Debug(v422, v419);\n\treturn;\nL_0087:\n\tv213 = this.path;\n\t// 142 NewArr v179 @ X0_v23 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), v213.Length\n\tv501 = v179.Length < 1;\n\tif (v501) goto L_00DF;\nL_00A1:\n\tv281 = this.path;\n\tv537 = v89 < v281.Length;\n\tv127 = ~v537;\n\tif (v127) goto L_0323;\n\tv181 = HutongGames.PlayMaker.FsmGameObject::get_Value(v281[v89 @ X22_v12 (System.Int32)]);\n\tv423 = UnityEngine.GameObject::get_transform(v181);\n\tv75 = UnityEngine.Transform::get_position(v423);\n\tv553 = v89 < v179.Length;\n\tv269 = ~v553;\n\tif (v269) goto L_0323;\n\tv528 = v89 * 0xC;\n\tv558 = v179 + v528;\n\t*([v558 @ X8_v58+20]) = v75;\n\tv179[v89 @ X22_v12 (System.Int32)].y = v75.y;\n\tv179[v89 @ X22_v12 (System.Int32)].z = v75.z;\n\tv89 = v89 + 1;\n\tv511 = v89 < v179.Length;\n\tif (v511) goto L_00A1;\nL_00DF:\n\tv223 = this.lookAt;\n\tv531 = this.lookAt < 3;\n\tv128 = ~v531;\n\tv124 = this.lookAt - 3;\n\tv116 = v124 == 0;\n\tv532 = ~v116;\n\tv96 = v128 & v532;\n\tif (v96) goto L_0260;\n\tv410 = 0x1818000 + 0xDB4;\n\tv434 = *([v410 @ X9_v14 (System.Int32)+v223 @ X8_v15 (HutongGames.PlayMaker.Actions.DOTweenTransformLocalPath+LookAt)*4]) + v410;\n\t// 241 IndirectJump v434 @ X8_v53, v423 @ X0_v24 (UnityEngine.Transform), v423 @ X0_v24 (UnityEngine.Transform), 0, 0, v41 @ X3, v42 @ X4, v43 @ X5, v44 @ X6, v45 @ X7, v75 @ V0_v5 (UnityEngine.Vector3), v75.y (System.Single), v75.z (System.Single), v49 @ V3, v50 @ V4, v51 @ V5, v52 @ V6, v53 @ V7\n\tX0 = *([X19+78]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = 0;\n\tV0 = HutongGames.PlayMaker.FsmFloat::get_Value(X0, X1);\n\tX0 = *([X19+68]);\n\tV8 = V0;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX22 = *([X19+60]);\n\tX23 = *([X19+64]);\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmInt::get_Value(X0, X1);\n\tX8 = *([X19+70]);\n\tX24 = X0;\n\tif (TEMP) goto L_0328;\n\tV0 = *([X8+38]);\n\tV1 = *([X8+3C]);\n\tV2 = *([X8+40]);\n\tV3 = *([X8+44]);\n\tX8 = *([1F0BBC0]);\n\tX0 = X29 - 0x78;\n\t*([X29-68]) = 0;\n\t*([X29-78]) = 0;\n\t*([X29-70]) = 0;\n\tX1 = *([X8]);\n\tX0 = 0x115CE84(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV0 = *([X25]);\n\tX8 = *([X29-68]);\n\tX5 = &stack[80];\n\tX0 = X20;\n\tstack[80] = V0;\n\tX1 = X21;\n\tV0 = V8;\n\tX2 = X22;\n\tX3 = X23;\n\tX4 = X24;\n\tX6 = 0;\n\tstack[90] = X8;\n\tX0 = DG.Tweening.ShortcutExtensions::DOLocalPath(X0, X1, V0, X2, X3, X4, X5, X6);\n\tX8 = *([X19+90]);\n\tX20 = X0;\n\tif (TEMP) goto L_0328;\n\tX0 = X8;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmBool::get_Value(X0, X1);\n\tX2 = *([X19+98]);\n\tX3 = *([X19+9C]);\n\tX1 = X0 & 1;\n\tX0 = X20;\n\tX4 = 0;\n\tX0 = DG.Tweening.TweenSettingsExtensions::SetOptions(X0, X1, X2, X3, X4);\n\tgoto L_025B;\n\tX0 = *([X19+78]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = 0;\n\tV0 = HutongGames.PlayMaker.FsmFloat::get_Value(X0, X1);\n\tX0 = *([X19+68]);\n\tV8 = V0;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX22 = *([X19+60]);\n\tX23 = *([X19+64]);\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmInt::get_Value(X0, X1);\n\tX8 = *([X19+70]);\n\tX24 = X0;\n\tif (TEMP) goto L_0328;\n\tV0 = *([X8+38]);\n\tV1 = *([X8+3C]);\n\tV2 = *([X8+40]);\n\tV3 = *([X8+44]);\n\tX8 = *([1F0BBC0]);\n\tX0 = X29 - 0x78;\n\t*([X29-68]) = 0;\n\t*([X29-78]) = 0;\n\t*([X29-70]) = 0;\n\tX1 = *([X8]);\n\tX0 = 0x115CE84(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV0 = *([X25]);\n\tX8 = *([X29-68]);\n\tX5 = &stack[60];\n\tX0 = X20;\n\tstack[60] = V0;\n\tX1 = X21;\n\tV0 = V8;\n\tX2 = X22;\n\tX3 = X23;\n\tX4 = X24;\n\tX6 = 0;\n\tstack[70] = X8;\n\tX0 = DG.Tweening.ShortcutExtensions::DOLocalPath(X0, X1, V0, X2, X3, X4, X5, X6);\n\tX8 = *([X19+90]);\n\tX20 = X0;\n\tif (TEMP) goto L_0328;\n\tX0 = X8;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmBool::get_Value(X0, X1);\n\tX2 = *([X19+98]);\n\tX3 = *([X19+9C]);\n\tX1 = X0 & 1;\n\tX0 = X20;\n\tX4 = 0;\n\tX0 = DG.Tweening.TweenSettingsExtensions::SetOptions(X0, X1, X2, X3, X4);\n\tX8 = *([X19+A8]);\n\tX20 = X0;\n\tif (TEMP) goto L_0328;\n\tX0 = X8;\n\tX1 = 0;\n\tV0 = HutongGames.PlayMaker.FsmVector3::get_Value(X0, X1);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tX0 = *([X19+C0]);\n\tV8 = V0;\n\tV9 = V1;\n\tV10 = V2;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = 0;\n\tV0 = HutongGames.PlayMaker.FsmVector3::get_Value(X0, X1);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tX21 = *([1EE2958]);\n\tX0 = &stack[50];\n\tstack[50] = 0;\n\tstack[58] = 0;\n\tX1 = *([X21]);\n\tX0 = 0x115D2C0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X19+C8]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = 0;\n\tV0 = HutongGames.PlayMaker.FsmVector3::get_Value(X0, X1);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tX1 = *([X21]);\n\tX0 = &stack[40];\n\tstack[40] = 0;\n\tstack[48] = 0;\n\tX0 = 0x115D2C0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = stack[50];\n\tX2 = stack[58];\n\tX3 = stack[40];\n\tX4 = stack[48];\n\tX0 = X20;\n\tV0 = V8;\n\tV1 = V9;\n\tV2 = V10;\n\tX5 = 0;\n\t// 400 MakeStruct AGGA7B968_1, typeof(UnityEngine.Vector3), V0, V1, V2\n\tX0 = DG.Tweening.TweenSettingsExtensions::SetLookAt(X0, AGGA7B968_1, X1, X2, X3);\n\tgoto L_025B;\n\tX0 = *([X19+78]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = 0;\n\tV0 = HutongGames.PlayMaker.FsmFloat::get_Value(X0, X1);\n\tX0 = *([X19+68]);\n\tV8 = V0;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX22 = *([X19+60]);\n\tX23 = *([X19+64]);\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmInt::get_Value(X0, X1);\n\tX8 = *([X19+70]);\n\tX24 = X0;\n\tif (TEMP) goto L_0328;\n\tV0 = *([X8+38]);\n\tV1 = *([X8+3C]);\n\tV2 = *([X8+40]);\n\tV3 = *([X8+44]);\n\tX8 = *([1F0BBC0]);\n\tX0 = X29 - 0x78;\n\t*([X29-68]) = 0;\n\t*([X29-78]) = 0;\n\t*([X29-70]) = 0;\n\tX1 = *([X8]);\n\tX0 = 0x115CE84(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV0 = *([X25]);\n\tX8 = *([X29-68]);\n\tX5 = &stack[20];\n\tX0 = X20;\n\tstack[20] = V0;\n\tX1 = X21;\n\tV0 = V8;\n\tX2 = X22;\n\tX3 = X23;\n\tX4 = X24;\n\tX6 = 0;\n\tstack[30] = X8;\n\tX0 = DG.Tweening.ShortcutExtensions::DOLocalPath(X0, X1, V0, X2, X3, X4, X5, X6);\n\tX8 = *([X19+90]);\n\tX20 = X0;\n\tif (TEMP) goto L_0328;\n\tX0 = X8;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmBool::get_Value(X0, X1);\n\tX2 = *([X19+98]);\n\tX3 = *([X19+9C]);\n\tX1 = X0 & 1;\n\tX0 = X20;\n\tX4 = 0;\n\tX0 = DG.Tweening.TweenSettingsExtensions::SetOptions(X0, X1, X2, X3, X4);\n\tX8 = *([X19+B0]);\n\tX20 = X0;\n\tif (TEMP) goto L_0328;\n\tX0 = X8;\n\tX1 = 0;\n\tX0 = HutongGames.PlayMaker.FsmGameObject::get_Value(X0, X1);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = 0;\n\tX0 = UnityEngine.GameObject::get_transform(X0, X1);\n\tX8 = *([X19+C0]);\n\tX21 = X0;\n\tif (TEMP) goto L_0328;\n\tX0 = X8;\n\tX1 = 0;\n\tV0 = HutongGames.PlayMaker.FsmVector3::get_Value(X0, X1);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tX22 = *([1EE2958]);\n\tX0 = &stack[50];\n\tstack[50] = 0;\n\tstack[58] = 0;\n\tX1 = *([X22]);\n\tX0 = 0x115D2C0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X19+C8]);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX1 = 0;\n\tV0 = HutongGames.PlayMaker.FsmVector3::get_Value(X0, X1);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\n// ... truncated")]
		public override void OnEnter()
		{
			//IL_032d: Expected O, but got I
			//IL_0237: Expected O, but got I
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			FsmState state;
			string message;
			if (ownerDefaultTarget == null)
			{
				if (!debugThis.Value)
				{
					return;
				}
				state = State;
				message = "ERROR - DOTween Transform Local Path - The gameObject is null";
			}
			else
			{
				Transform component = ownerDefaultTarget.GetComponent<Transform>();
				if (!(component == null))
				{
					FsmGameObject[] array = path;
					Vector3[] array2 = new Vector3[array.Length];
					bool flag = array2.Length < 1;
					Transform transform = (Transform)(object)array2;
					if (!flag)
					{
						int num = 0;
						while (true)
						{
							FsmGameObject[] array3 = path;
							if (num < array3.Length)
							{
								GameObject value = array3[num].Value;
								transform = value.transform;
								Vector3 position = transform.position;
								if (num < array2.Length)
								{
									int num2 = num * 12;
									object obj = (long)(IntPtr)array2 + (long)num2;
									array2[num].y = position.y;
									array2[num].z = position.z;
									num++;
									if (num >= array2.Length)
									{
										break;
									}
									continue;
								}
							}
							IndexOutOfRangeException ex = new IndexOutOfRangeException();
							throw ex;
						}
					}
					LookAt lookAt = this.lookAt;
					bool flag2 = this.lookAt < LookAt.ahead;
					bool flag3 = !flag2;
					int num3 = (int)(this.lookAt - 3);
					bool flag4 = num3 == 0;
					bool flag5 = !flag4;
					if (!(flag3 && flag5))
					{
						int num4 = 25264128 + 3508;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v410 @ X9_v14 (System.Int32)+v223 @ X8_v15 (HutongGames.PlayMaker.Actions.DOTweenTransformLocalPath+LookAt)*4]");
						object obj2 = 0L + (long)num4;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v434 @ X8_v53 (should have been resolved before IL gen)");
					}
					if (setSpeedBased.Value)
					{
						Tweener tweener = tween.SetSpeedBased();
					}
					GameObject ownerDefaultTarget2 = Fsm.GetOwnerDefaultTarget(gameObject);
					tween.SetTweenId(tweenIdType, stringAsId, tagAsId, ownerDefaultTarget2);
					float value2 = startDelay.Value;
					Tweener tweener2 = tween.SetDelay(value2);
					tween.SetSelectedEase(selectedEase, easeType, animationCurve);
					int value3 = loops.Value;
					Tweener tweener3 = tween.SetLoops(value3, loopType);
					bool value4 = autoKillOnCompletion.Value;
					Tweener tweener4 = tween.SetAutoKill(value4);
					bool value5 = recyclable.Value;
					Tweener tweener5 = tween.SetRecyclable(value5);
					bool value6 = isIndependentUpdate.Value;
					Tweener tweener6 = tween.SetUpdate(updateType, value6);
					if (startEvent != null)
					{
						TweenCallback action = delegate
						{
							Fsm.Event(startEvent);
						};
						Tweener tweener7 = tween.OnStart(action);
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
						Tweener tweener8 = tween.OnComplete(action2);
					}
					Tweener tweener9 = tween.Play();
					if (debugThis.Value)
					{
						State.Debug("DOTween Transform Local Path");
					}
					if (finishImmediately.Value)
					{
						Finish();
					}
					return;
				}
				if (!debugThis.Value)
				{
					return;
				}
				string text = ownerDefaultTarget.name;
				string text2 = "ERROR - DOTween Transform Local Path - The GameObject [" + text + "] does not have a Transform Component";
				message = text2;
				state = State;
			}
			state.Debug(message);
		}

		[Token(Token = "0x60005B1")]
		[Address(RVA = "0xA7BEB4", Offset = "0xA7BEB4", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EA5058]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022154]) = v38;\nL_0018:\n\tthis.tweenIdDescription = \"Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods\";\n\tthis.loopsDescriptionArea = \"Setting loops to -1 will make the tween loop infinitely.\";\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public DOTweenTransformLocalPath()
		{
			tweenIdDescription = "Set an ID for the tween, which can then be used as a filter with DOTween's Control Methods";
			loopsDescriptionArea = "Setting loops to -1 will make the tween loop infinitely.";
		}
	}
}
