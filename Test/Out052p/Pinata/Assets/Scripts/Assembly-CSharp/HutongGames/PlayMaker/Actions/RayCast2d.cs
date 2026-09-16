using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75AC0C", Offset = "0x75AC0C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75AC0C", Offset = "0x75AC0C")]
	[Token(Token = "0x20002CD")]
	public class RayCast2d : FsmStateAction
	{
		[Attribute(Type = typeof(ActionSection), RVA = "0x7BECCC", Offset = "0x7BECCC")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BECCC", Offset = "0x7BECCC")]
		[Token(Token = "0x4001866")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault fromGameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BED2C", Offset = "0x7BED2C")]
		[Token(Token = "0x4001867")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector2 fromPosition;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BED64", Offset = "0x7BED64")]
		[Token(Token = "0x4001868")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector2 direction;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BED9C", Offset = "0x7BED9C")]
		[Token(Token = "0x4001869")]
		[FieldOffset(Offset = "0x68")]
		public Space space;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BEDD4", Offset = "0x7BEDD4")]
		[Token(Token = "0x400186A")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat distance;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BEE0C", Offset = "0x7BEE0C")]
		[Token(Token = "0x400186B")]
		[FieldOffset(Offset = "0x78")]
		public FsmInt minDepth;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BEE44", Offset = "0x7BEE44")]
		[Token(Token = "0x400186C")]
		[FieldOffset(Offset = "0x80")]
		public FsmInt maxDepth;

		[Attribute(Type = typeof(ActionSection), RVA = "0x7BEE7C", Offset = "0x7BEE7C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BEE7C", Offset = "0x7BEE7C")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BEE7C", Offset = "0x7BEE7C")]
		[Token(Token = "0x400186D")]
		[FieldOffset(Offset = "0x88")]
		public FsmEvent hitEvent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BEEF0", Offset = "0x7BEEF0")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BEEF0", Offset = "0x7BEEF0")]
		[Token(Token = "0x400186E")]
		[FieldOffset(Offset = "0x90")]
		public FsmBool storeDidHit;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BEF40", Offset = "0x7BEF40")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BEF40", Offset = "0x7BEF40")]
		[Token(Token = "0x400186F")]
		[FieldOffset(Offset = "0x98")]
		public FsmGameObject storeHitObject;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BEF90", Offset = "0x7BEF90")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BEF90", Offset = "0x7BEF90")]
		[Token(Token = "0x4001870")]
		[FieldOffset(Offset = "0xA0")]
		public FsmVector2 storeHitPoint;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BEFE0", Offset = "0x7BEFE0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BEFE0", Offset = "0x7BEFE0")]
		[Token(Token = "0x4001871")]
		[FieldOffset(Offset = "0xA8")]
		public FsmVector2 storeHitNormal;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BF030", Offset = "0x7BF030")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BF030", Offset = "0x7BF030")]
		[Token(Token = "0x4001872")]
		[FieldOffset(Offset = "0xB0")]
		public FsmFloat storeHitDistance;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BF080", Offset = "0x7BF080")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BF080", Offset = "0x7BF080")]
		[Token(Token = "0x4001873")]
		[FieldOffset(Offset = "0xB8")]
		public FsmFloat storeHitFraction;

		[Attribute(Type = typeof(ActionSection), RVA = "0x7BF0D0", Offset = "0x7BF0D0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BF0D0", Offset = "0x7BF0D0")]
		[Token(Token = "0x4001874")]
		[FieldOffset(Offset = "0xC0")]
		public FsmInt repeatInterval;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BF130", Offset = "0x7BF130")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BF130", Offset = "0x7BF130")]
		[Token(Token = "0x4001875")]
		[FieldOffset(Offset = "0xC8")]
		public FsmInt[] layerMask;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BF180", Offset = "0x7BF180")]
		[Token(Token = "0x4001876")]
		[FieldOffset(Offset = "0xD0")]
		public FsmBool invertMask;

		[Attribute(Type = typeof(ActionSection), RVA = "0x7BF1B8", Offset = "0x7BF1B8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BF1B8", Offset = "0x7BF1B8")]
		[Token(Token = "0x4001877")]
		[FieldOffset(Offset = "0xD8")]
		public FsmColor debugColor;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BF218", Offset = "0x7BF218")]
		[Token(Token = "0x4001878")]
		[FieldOffset(Offset = "0xE0")]
		public FsmBool debug;

		[Token(Token = "0x4001879")]
		[FieldOffset(Offset = "0xE8")]
		private Transform _transform;

		[Token(Token = "0x400187A")]
		[FieldOffset(Offset = "0xF0")]
		private int repeat;

		[Token(Token = "0x6000E07")]
		[Address(RVA = "0xB1D158", Offset = "0xB1D158", Length = "0x174")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ED4C10]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2022588]) = v42;\nL_0015:\n\tthis.fromGameObject = 0;\n\tv46 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.FsmVector2::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.fromPosition = v46;\n\tv52 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.FsmVector2::.ctor(v52);\n\tv52.useVariable = 1;\n\tthis.direction = v52;\n\tthis.space = 1;\n\tv62 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v62);\n\tv62.useVariable = 1;\n\tthis.minDepth = v62;\n\tv63 = new HutongGames.PlayMaker.FsmInt();\n\tHutongGames.PlayMaker.FsmInt::.ctor(v63);\n\tv63.useVariable = 1;\n\tthis.maxDepth = v63;\n\tv110 = HutongGames.PlayMaker.FsmFloat::op_Implicit(100f);\n\tthis.distance = v110;\n\tthis.storeHitFraction = 0;\n\tthis.storeHitNormal = 0;\n\tthis.storeHitObject = 0;\n\tthis.hitEvent = 0;\n\tv114 = HutongGames.PlayMaker.FsmInt::op_Implicit(1);\n\tthis.repeatInterval = v114;\n\t// 83 NewArr v118 @ X0_v18 (HutongGames.PlayMaker.FsmInt[]), typeof(HutongGames.PlayMaker.FsmInt[]), 0\n\tthis.layerMask = v118;\n\tv121 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.invertMask = v121;\n\tv86 = UnityEngine.Color::get_yellow();\n\tv124 = HutongGames.PlayMaker.FsmColor::op_Implicit(v86);\n\tthis.debugColor = v124;\n\tv94 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.debug = v94;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			fromGameObject = null;
			FsmVector2 fsmVector = new FsmVector2();
			fsmVector.useVariable = true;
			fromPosition = fsmVector;
			FsmVector2 fsmVector2 = new FsmVector2();
			fsmVector2.useVariable = true;
			direction = fsmVector2;
			space = Space.Self;
			FsmInt fsmInt = new FsmInt();
			fsmInt.useVariable = true;
			minDepth = fsmInt;
			FsmInt fsmInt2 = new FsmInt();
			fsmInt2.useVariable = true;
			maxDepth = fsmInt2;
			FsmFloat fsmFloat = 100f;
			distance = fsmFloat;
			storeHitFraction = null;
			storeHitNormal = null;
			storeHitObject = null;
			hitEvent = null;
			FsmInt fsmInt3 = 1;
			repeatInterval = fsmInt3;
			FsmInt[] array = new FsmInt[0];
			layerMask = array;
			FsmBool fsmBool = false;
			invertMask = fsmBool;
			Color yellow = Color.yellow;
			FsmColor fsmColor = yellow;
			debugColor = fsmColor;
			FsmBool fsmBool2 = false;
			debug = fsmBool2;
		}

		[Token(Token = "0x6000E08")]
		[Address(RVA = "0xB1D2CC", Offset = "0xB1D2CC", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EFF690]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2022589]) = v38;\nL_0018:\n\tv43 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.fromGameObject);\n\tgoto L_002A;\n\tv77 = *([v56 @ X8_v7+E0]);\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_002A;\n\tv84 = v56;\n\tv81 = \"il2cpp_codegen_runtime_class_init\"(v84, v41, v42, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002A:\n\tv70 = UnityEngine.Object::op_Inequality(v43, 0);\n\tv86 = v70 == 0;\n\tif (v86) goto L_0035;\n\tv112 = UnityEngine.GameObject::get_transform(v43);\n\tthis._transform = v112;\nL_0035:\n\tHutongGames.PlayMaker.Actions.RayCast2d::DoRaycast(this);\n\tv96 = HutongGames.PlayMaker.FsmInt::get_Value(this.repeatInterval);\n\tv99 = v96 == 0;\n\tif (v99) goto L_004A;\n\treturn;\nL_004A:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(fromGameObject);
			if (ownerDefaultTarget != null)
			{
				Transform transform = ownerDefaultTarget.transform;
				_transform = transform;
			}
			DoRaycast();
			if (repeatInterval.Value == 0)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000E09")]
		[Address(RVA = "0xB1DA30", Offset = "0xB1DA30", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.repeat - 1;\n\tthis.repeat = v2;\n\tv3 = this.repeat == 1;\n\tif (v3) goto L_0006;\n\treturn;\nL_0006:\n\tHutongGames.PlayMaker.Actions.RayCast2d::DoRaycast(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			int num = repeat - 1;
			repeat = num;
			if (repeat == 1)
			{
				DoRaycast();
			}
		}

		[Token(Token = "0x6000E0A")]
		[Address(RVA = "0xB1D3AC", Offset = "0xB1D3AC", Length = "0x684")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv42 = *([1EBDB30]);\n\tv43 = *([v42 @ X8_v61]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv62 = 0 | 1;\n\t*([202258A]) = v62;\nL_002A:\n\tv73 = HutongGames.PlayMaker.FsmInt::get_Value(this.repeatInterval);\n\tthis.repeat = v73;\n\tv454 = HutongGames.PlayMaker.FsmFloat::get_Value(this.distance);\n\tgoto L_0041;\n\tv612 = *([v458 @ X0_v10+E0]);\n\tv613 = v612 == 0;\n\tv614 = ~v613;\n\tif (v614) goto L_0041;\n\tv616 = \"il2cpp_codegen_runtime_class_init\"(v458, v405, v46, v47, v48, v49, v50, v51, v454, v53, v54, v55, v56, v57, v58, v59);\nL_0041:\n\tv398 = UnityEngine.Mathf::Abs(v454);\n\tgoto L_0052;\n\tv624 = *([v620 @ X0_v12 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv625 = v624 == 0;\n\tv626 = ~v625;\n\tif (v626) goto L_0052;\n\tv632 = \"il2cpp_codegen_runtime_class_init\"(v620, v405, v46, v47, v48, v49, v50, v51, v454, v53, v54, v55, v56, v57, v58, v59);\n\tv627 = UnityEngine.Mathf;\nL_0052:\n\tv194 = v398 < v630.Epsilon;\n\tif (v194) goto L_0260;\n\tv440 = this.fromPosition;\n\tv226 = v440.value.y;\n\tgoto L_006E;\n\tv672 = *([v668 @ X0_v15+E0]);\n\tv673 = v672 == 0;\n\tv674 = ~v673;\n\tif (v674) goto L_006E;\n\tv676 = \"il2cpp_codegen_runtime_class_init\"(v668, v405, v46, v47, v48, v49, v50, v51, v235, v53, v54, v55, v56, v57, v58, v59);\nL_006E:\n\tv679 = UnityEngine.Object::op_Inequality(this._transform, 0);\n\tv681 = v679 == 0;\n\tif (v681) goto L_0086;\n\tv236 = UnityEngine.Transform::get_position(this._transform);\n\tv233 = v440.value + v236;\n\tv686 = UnityEngine.Transform::get_position(this._transform);\n\tv226 = v226 + v686.y;\nL_0086:\n\tv401 = HutongGames.PlayMaker.FsmFloat::get_Value(this.distance);\n\tv164 = v401 <= 0;\n\tif (v164) goto L_FFFFFFFF;\n\tv401 = HutongGames.PlayMaker.FsmFloat::get_Value(this.distance);\n\tgoto L_009D;\nL_009D:\n\tv443 = this.direction;\n\tv158 = v443.value;\n\tv701 = 0x1588F3C(&v158 @ X9_v4 (UnityEngine.Vector2), 0, 0, v47, v48, v49, v50, v51, v401, v686.y, v686.z, v55, v56, v98, v96, v59);\n\tgoto L_00B7;\n\tv706 = *([v702 @ X0_v24+E0]);\n\tv707 = v706 == 0;\n\tv708 = ~v707;\n\tif (v708) goto L_00B7;\n\tv710 = \"il2cpp_codegen_runtime_class_init\"(v702, v700, v219, v47, v48, v49, v50, v51, v401, v215, v210, v55, v56, v57, v58, v59);\nL_00B7:\n\tv417 = UnityEngine.Object::op_Inequality(this._transform, 0);\n\tv715 = v417 == 0;\n\tif (v715) goto L_00E4;\n\tv368 = this.space != 1;\n\tif (v368) goto L_00E4;\n\tv441 = this.direction;\n\tv787 = 0;\n\tv418 = 0x1586898(&v787 @ stack_-F0_v9 (UnityEngine.Vector2), 0, 0, v47, v48, v49, v50, v51, v441.value, v441.value.y, 0, v55, v56, v98, v96, v59);\n\t// 218 MakeStruct v718 @ AGGB1D5D8_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v124 @ stack_-EC, 0\n\tv723 = UnityEngine.Transform::TransformDirection(this._transform, v718);\nL_00E4:\n\tv728 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.minDepth);\n\tv731 = v728 == 0;\n\tif (v731) goto L_0121;\n\tv733 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.maxDepth);\n\tv735 = v733 == 0;\n\tif (v735) goto L_0121;\n\tv747 = HutongGames.PlayMaker.FsmBool::get_Value(this.invertMask);\n\tv756 = HutongGames.PlayMaker.ActionHelpers::LayerArrayToLayerMask(this.layerMask, v747);\n\tgoto L_0110;\n\tv767 = *([v761 @ X8_v51+E0]);\n\tv768 = v767 == 0;\n\tv769 = ~v768;\n\tif (v769) goto L_0110;\n\tv786 = v761;\n\tv772 = \"il2cpp_codegen_runtime_class_init\"(v786, v753, v755, v47, v48, v49, v50, v51, v238, v216, v211, v55, v56, v57, v58, v59);\nL_0110:\n\t// 272 MakeStruct v782 @ AGGB1D678_0_v5 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v233 @ V8_v8 (System.Single), v226 @ V9_v6 (System.Single)\n\t// 273 MakeStruct v783 @ AGGB1D678_1_v5 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v150 @ V11_v6 (System.Single), v148 @ V12_v6 (System.Single)\n\tv784 = UnityEngine.Physics2D::Raycast(v782, v783, v161, v756);\n\tv787 = v784.m_Centroid;\n\tv125 = *([v784 @ X0_v104 (UnityEngine.RaycastHit2D)+4]);\n\tv810 = v784.m_Normal;\n\tgoto L_017F;\nL_0121:\n\tv739 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.minDepth);\n\tv742 = v739 == 0;\n\tif (v742) goto L_012C;\n\tgoto L_0132;\nL_012C:\n\tv751 = HutongGames.PlayMaker.FsmInt::get_Value(this.minDepth);\nL_0132:\n\tv757 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.maxDepth);\n\tv766 = v757 == 0;\n\tif (v766) goto L_013C;\n\tgoto L_0143;\nL_013C:\n\tv799 = HutongGames.PlayMaker.FsmInt::get_Value(this.maxDepth);\nL_0143:\n\tv853 = HutongGames.PlayMaker.FsmBool::get_Value(this.invertMask);\n\tv867 = HutongGames.PlayMaker.ActionHelpers::LayerArrayToLayerMask(this.layerMask, v853);\n\tgoto L_0160;\n\tv881 = *([v873 @ X8_v46+E0]);\n\tv882 = v881 == 0;\n\tv883 = ~v882;\n\tif (v883) goto L_0160;\n\tv894 = v873;\n\tv885 = \"il2cpp_codegen_runtime_class_init\"(v894, v865, v825, v47, v48, v49, v50, v51, v238, v216, v211, v55, v56, v57, v58, v59);\nL_0160:\n\t// 352 MakeStruct v802 @ AGGB1D758_0_v5 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v233 @ V8_v8 (System.Single), v226 @ V9_v6 (System.Single)\n\t// 353 MakeStruct v801 @ AGGB1D758_1_v5 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v150 @ V11_v6 (System.Single), v148 @ V12_v6 (System.Single)\n\tv831 = UnityEngine.Physics2D::Raycast(v802, v801, v161, v867, v103, v101);\n\tv787 = v831.m_Centroid;\n\tv125 = *([v831 @ X0_v89 (UnityEngine.RaycastHit2D)+4]);\n\tv810 = v831.m_Normal;\nL_017F:\n\tgoto L_018E;\n\tv854 = *([v847 @ X0_v32+E0]);\n\tv855 = v854 == 0;\n\tv856 = ~v855;\n\tgoto L_018E;\n\tv858 = \"il2cpp_codegen_runtime_class_init\"(v847, v828, v824, v47, v48, v49, v50, v51, v844, v843, v212, v135, v133, v98, v96, v59);\nL_018E:\n\tHutongGames.PlayMaker.Fsm::RecordLastRaycastHit2DInfo(this.fsm, &v787 @ stack_-F0_v9 (UnityEngine.Vector2));\n\tv870 = 0x16415C8(&v787 @ stack_-F0_v9 (UnityEngine.Vector2), 0, 0, v47, v48, v49, v50, v51, v810, v787, v212, v135, v133, v103, v101, v59);\n\tgoto L_01A1;\n\tv887 = *([v877 @ X8_v28+E0]);\n\tv888 = v887 == 0;\n\tv889 = ~v888;\n\tif (v889) goto L_01A1;\n\tv895 = v877;\n\tv891 = \"il2cpp_codegen_runtime_class_init\"(v895, v869, v864, v47, v48, v49, v50, v51, v239, v217, v212, v135, v133, v98, v96, v59);\nL_01A1:\n\tv419 = UnityEngine.Object::op_Inequality(v870, 0);\n\tv293 = this.storeDidHit;\n\tv293.value = v419;\n\tv897 = v419 == 0;\n\tif (v897) goto L_01E0;\n\tv266 = 0x16415C8(&v787 @ stack_-F0_v9 (UnityEngine.Vector2), 0, 0, v47, v48, v49, v50, v51, v810, v787, v212, v135, v133, v103, v101, v59);\n\tv420 = UnityEngine.Component::get_gameObject(v266);\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.storeHitObject, v420);\n\tv448 = this.storeHitPoint;\n\tv421 = 0x16415A8(&v787 @ stack_-F0_v9 (UnityEngine.Vector2), 0, 0, v47, v48, v49, v50, v51, v810, v787, v212, v135, v133, v103, v101, v59);\n\tv448.value = v810;\n\tv448.value.y = v787;\n\tv449 = this.storeHitNormal;\n\tv422 = 0x16415B0(&v787 @ stack_-F0_v9 (UnityEngine.Vector2), 0, 0, v47, v48, v49, v50, v51, v810, v787, v212, v135, v133, v103, v101, v59);\n\tv449.value = v810;\n\tv449.value.y = v787;\n\tv450 = this.storeHitDistance;\n\tv423 = 0x16415B8(&v787 @ stack_-F0_v9 (UnityEngine.Vector2), 0, 0, v47, v48, v49, v50, v51, v810, v787, v212, v135, v133, v103, v101, v59);\n\tv450.value = v810;\n\tv298 = this.storeHitFraction;\n\tv424 = 0x16415C0(&v787 @ stack_-F0_v9 (UnityEngine.Vector2), 0, 0, v47, v48, v49, v50, v51, v810, v787, v212, v135, v133, v103, v101, v59);\n\tv298.value = v810;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.hitEvent);\nL_01E0:\n\tv662 = HutongGames.PlayMaker.FsmBool::get_Value(this.debug);\n\tv664 = v662 == 0;\n\tif (v664) goto L_0260;\n\tgoto L_01F2;\n\tv910 = *([v905 @ X0_v43+E0]);\n\tv911 = v910 == 0;\n\tv912 = ~v911;\n\tif (v912) goto L_01F2;\n\tv914 = \"il2cpp_codegen_runtime_class_init\"(v905, v660, v223, v47, v48, v49, v50, v51, v239, v217, v212, v135, v133, v98, v96, v59);\nL_01F2:\n\tv921 = UnityEngine.Mathf::Min(v161, 1000f);\n\tv787 = 0;\n\tv929 = 0x1586898(&v787 @ stack_-F0_v9 (UnityEngine.Vector2), 0, v223, v47, v48, v49, v50, v51, v233, v226, 0, v135, v133, v103, v101, v59);\n\tv934 = 0x1586898(&v322 @ stack_-C8_v4, 0, v223, v47, v48, v49, v50, v51, v150, v148, 0, v135, v133, v103, v101, v59);\n\tgoto L_0219;\n\tv945 = *([v941 @ X0_v50+E0]);\n\tv946 = v945 == 0;\n\tv947 = ~v946;\n\tif (v947) goto L_0219;\n\tv949 = \"il2cpp_codegen_runtime_class_init\"(v941, v413, v223, v47, v48, v49, v50, v51, v932, v933,\n// ... truncated")]
		private unsafe void DoRaycast()
		{
			//IL_023b: Expected F4, but got O
			//IL_0369: Expected O, but got I
			//IL_04df: Expected O, but got I
			//IL_0518: Expected O, but got Ref
			//IL_056e: Expected O, but got I4
			//IL_0718: Expected F4, but got O
			//IL_0725: Expected F4, but got O
			//IL_075f: Expected F4, but got O
			//IL_07b2: Expected F4, but got O
			//IL_069b: Expected O, but got I4
			int value = repeatInterval.Value;
			repeat = value;
			float value2 = distance.Value;
			float num = Mathf.Abs(value2);
			if (num < Mathf.Epsilon)
			{
				return;
			}
			FsmVector2 fsmVector = fromPosition;
			float num2 = fsmVector.value.y;
			bool flag = _transform != null;
			bool flag2 = !flag;
			float x = fsmVector.value.x;
			Vector3 position2 = default(Vector3);
			if (!flag2)
			{
				Vector3 position = _transform.position;
				x = fsmVector.value.x + position.x;
				position2 = _transform.position;
				num2 += position2.y;
			}
			float value3 = distance.Value;
			float num3;
			if (value3 > 0f)
			{
				value3 = distance.Value;
				num3 = value3;
			}
			else
			{
				num3 = float.PositiveInfinity;
			}
			FsmVector2 fsmVector2 = direction;
			Vector2 value4 = fsmVector2.value;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1588F3C (inside UnityEngine.Vector2::get_zero +0x68)");
			bool flag3 = _transform != null;
			bool flag4 = !flag3;
			float y = position2.y;
			float num4 = value3;
			Vector2 vector;
			if (!flag4)
			{
				bool flag5 = space != Space.Self;
				y = position2.y;
				num4 = value3;
				if (!flag5)
				{
					FsmVector2 fsmVector3 = direction;
					vector = default(Vector2);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
					Vector3 vector2 = default(Vector3);
					vector2.x = 0f;
					object obj = default(object);
					vector2.y = (float)obj;
					vector2.z = 0f;
					Vector3 vector3 = _transform.TransformDirection(vector2);
					y = vector3.y;
					num4 = vector3.x;
				}
			}
			object obj2;
			Vector2 normal;
			if (minDepth.IsNone && maxDepth.IsNone)
			{
				bool value5 = invertMask.Value;
				int num5 = ActionHelpers.LayerArrayToLayerMask(layerMask, value5);
				Vector2 origin = default(Vector2);
				origin.x = x;
				origin.y = num2;
				Vector2 vector4 = default(Vector2);
				vector4.x = num4;
				vector4.y = y;
				RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, vector4, num3, num5);
				vector = raycastHit2D.m_Centroid;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v784 @ X0_v104 (UnityEngine.RaycastHit2D)+4]");
				obj2 = 0;
				normal = raycastHit2D.m_Normal;
				float num6 = num3;
				float num7 = y;
				float num8 = num4;
			}
			else
			{
				float num9;
				if (minDepth.IsNone)
				{
					num9 = float.NegativeInfinity;
				}
				else
				{
					int value6 = minDepth.Value;
					num9 = value6;
				}
				float num10;
				if (maxDepth.IsNone)
				{
					num10 = float.PositiveInfinity;
				}
				else
				{
					int value7 = maxDepth.Value;
					num10 = value7;
				}
				bool value8 = invertMask.Value;
				int num11 = ActionHelpers.LayerArrayToLayerMask(layerMask, value8);
				Vector2 origin2 = default(Vector2);
				origin2.x = x;
				origin2.y = num2;
				Vector2 vector5 = default(Vector2);
				vector5.x = num4;
				vector5.y = y;
				RaycastHit2D raycastHit2D2 = Physics2D.Raycast(origin2, vector5, num3, num11, num9, num10);
				vector = raycastHit2D2.m_Centroid;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v831 @ X0_v89 (UnityEngine.RaycastHit2D)+4]");
				obj2 = 0;
				normal = raycastHit2D2.m_Normal;
				float num6 = num3;
				float num7 = y;
				float num8 = num4;
			}
			Fsm.RecordLastRaycastHit2DInfo(Fsm, (RaycastHit2D)(&vector));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @16415C8 (inside UnityEngine.PhysicsScene2D::GetRayIntersectionArray_Internal_Injected +0xA0)");
			Object obj3 = default(Object);
			bool flag6 = obj3 != null;
			FsmBool fsmBool = storeDidHit;
			fsmBool.value = flag6;
			bool flag7 = !flag6;
			object obj4 = 0;
			if (!flag7)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @16415C8 (inside UnityEngine.PhysicsScene2D::GetRayIntersectionArray_Internal_Injected +0xA0)");
				Component component = default(Component);
				GameObject gameObject = component.gameObject;
				storeHitObject.Value = gameObject;
				FsmVector2 fsmVector4 = storeHitPoint;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @16415A8 (inside UnityEngine.PhysicsScene2D::GetRayIntersectionArray_Internal_Injected +0x80)");
				fsmVector4.value = normal;
				fsmVector4.value.y = vector.x;
				FsmVector2 fsmVector5 = storeHitNormal;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @16415B0 (inside UnityEngine.PhysicsScene2D::GetRayIntersectionArray_Internal_Injected +0x88)");
				fsmVector5.value = normal;
				fsmVector5.value.y = vector.x;
				FsmFloat fsmFloat = storeHitDistance;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @16415B8 (inside UnityEngine.PhysicsScene2D::GetRayIntersectionArray_Internal_Injected +0x90)");
				fsmFloat.Value = normal.x;
				FsmFloat fsmFloat2 = storeHitFraction;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @16415C0 (inside UnityEngine.PhysicsScene2D::GetRayIntersectionArray_Internal_Injected +0x98)");
				fsmFloat2.Value = normal.x;
				Fsm.Event(hitEvent);
				obj4 = 0;
			}
			if (debug.Value)
			{
				float num12 = Mathf.Min(num3, 1000f);
				vector = default(Vector2);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
				Vector3 vector6 = default(Vector3);
				object obj5 = default(object);
				vector6.x = (float)obj5;
				object obj6 = default(object);
				vector6.y = (float)obj6;
				vector6.z = 0f;
				Vector3 vector7 = vector6 * num12;
				Vector3 vector8 = default(Vector3);
				vector8.x = 0f;
				vector8.y = (float)obj2;
				vector8.z = 0f;
				Vector3 end = vector8 + vector7;
				FsmColor fsmColor = debugColor;
				Vector3 start = default(Vector3);
				start.x = 0f;
				start.y = (float)obj2;
				start.z = 0f;
				Debug.DrawLine(start, end, fsmColor.value);
			}
		}

		[Token(Token = "0x6000E0B")]
		[Address(RVA = "0xB1DA48", Offset = "0xB1DA48", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RayCast2d()
		{
		}
	}
}
