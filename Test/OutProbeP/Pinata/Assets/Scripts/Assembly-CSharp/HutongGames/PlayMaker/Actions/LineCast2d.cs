using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75AA7C", Offset = "0x75AA7C")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75AA7C", Offset = "0x75AA7C")]
	[Token(Token = "0x20002C8")]
	public class LineCast2d : FsmStateAction
	{
		[Attribute(Type = typeof(ActionSection), RVA = "0x7BE0A8", Offset = "0x7BE0A8")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BE0A8", Offset = "0x7BE0A8")]
		[Token(Token = "0x4001835")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault fromGameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BE108", Offset = "0x7BE108")]
		[Token(Token = "0x4001836")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector2 fromPosition;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BE140", Offset = "0x7BE140")]
		[Token(Token = "0x4001837")]
		[FieldOffset(Offset = "0x60")]
		public FsmGameObject toGameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BE178", Offset = "0x7BE178")]
		[Token(Token = "0x4001838")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector2 toPosition;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BE1B0", Offset = "0x7BE1B0")]
		[Token(Token = "0x4001839")]
		[FieldOffset(Offset = "0x70")]
		public FsmInt minDepth;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BE1E8", Offset = "0x7BE1E8")]
		[Token(Token = "0x400183A")]
		[FieldOffset(Offset = "0x78")]
		public FsmInt maxDepth;

		[Attribute(Type = typeof(ActionSection), RVA = "0x7BE220", Offset = "0x7BE220")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BE220", Offset = "0x7BE220")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BE220", Offset = "0x7BE220")]
		[Token(Token = "0x400183B")]
		[FieldOffset(Offset = "0x80")]
		public FsmEvent hitEvent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BE294", Offset = "0x7BE294")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BE294", Offset = "0x7BE294")]
		[Token(Token = "0x400183C")]
		[FieldOffset(Offset = "0x88")]
		public FsmBool storeDidHit;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BE2E4", Offset = "0x7BE2E4")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BE2E4", Offset = "0x7BE2E4")]
		[Token(Token = "0x400183D")]
		[FieldOffset(Offset = "0x90")]
		public FsmGameObject storeHitObject;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BE334", Offset = "0x7BE334")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BE334", Offset = "0x7BE334")]
		[Token(Token = "0x400183E")]
		[FieldOffset(Offset = "0x98")]
		public FsmVector2 storeHitPoint;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BE384", Offset = "0x7BE384")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BE384", Offset = "0x7BE384")]
		[Token(Token = "0x400183F")]
		[FieldOffset(Offset = "0xA0")]
		public FsmVector2 storeHitNormal;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BE3D4", Offset = "0x7BE3D4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BE3D4", Offset = "0x7BE3D4")]
		[Token(Token = "0x4001840")]
		[FieldOffset(Offset = "0xA8")]
		public FsmFloat storeHitDistance;

		[Attribute(Type = typeof(ActionSection), RVA = "0x7BE424", Offset = "0x7BE424")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BE424", Offset = "0x7BE424")]
		[Token(Token = "0x4001841")]
		[FieldOffset(Offset = "0xB0")]
		public FsmInt repeatInterval;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BE484", Offset = "0x7BE484")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BE484", Offset = "0x7BE484")]
		[Token(Token = "0x4001842")]
		[FieldOffset(Offset = "0xB8")]
		public FsmInt[] layerMask;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BE4D4", Offset = "0x7BE4D4")]
		[Token(Token = "0x4001843")]
		[FieldOffset(Offset = "0xC0")]
		public FsmBool invertMask;

		[Attribute(Type = typeof(ActionSection), RVA = "0x7BE50C", Offset = "0x7BE50C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BE50C", Offset = "0x7BE50C")]
		[Token(Token = "0x4001844")]
		[FieldOffset(Offset = "0xC8")]
		public FsmColor debugColor;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BE56C", Offset = "0x7BE56C")]
		[Token(Token = "0x4001845")]
		[FieldOffset(Offset = "0xD0")]
		public FsmBool debug;

		[Token(Token = "0x4001846")]
		[FieldOffset(Offset = "0xD8")]
		private Transform _fromTrans;

		[Token(Token = "0x4001847")]
		[FieldOffset(Offset = "0xE0")]
		private Transform _toTrans;

		[Token(Token = "0x4001848")]
		[FieldOffset(Offset = "0xE8")]
		private int repeat;

		[Token(Token = "0x6000DED")]
		[Address(RVA = "0xA397CC", Offset = "0xA397CC", Length = "0x108")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EE4DF0]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021E3B]) = v42;\nL_0015:\n\tthis.fromGameObject = 0;\n\tv46 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.FsmVector2::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.fromPosition = v46;\n\tthis.toGameObject = 0;\n\tv52 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.FsmVector2::.ctor(v52);\n\tv52.useVariable = 1;\n\tthis.toPosition = v52;\n\tthis.storeHitObject = 0;\n\tthis.storeHitNormal = 0;\n\tthis.hitEvent = 0;\n\tv96 = HutongGames.PlayMaker.FsmInt::op_Implicit(1);\n\tthis.repeatInterval = v96;\n\t// 56 NewArr v100 @ X0_v12 (HutongGames.PlayMaker.FsmInt[]), typeof(HutongGames.PlayMaker.FsmInt[]), 0\n\tthis.layerMask = v100;\n\tv103 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.invertMask = v103;\n\tv77 = UnityEngine.Color::get_yellow();\n\tv106 = HutongGames.PlayMaker.FsmColor::op_Implicit(v77);\n\tthis.debugColor = v106;\n\tv83 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.debug = v83;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			fromGameObject = null;
			FsmVector2 fsmVector = new FsmVector2();
			fsmVector.useVariable = true;
			fromPosition = fsmVector;
			toGameObject = null;
			FsmVector2 fsmVector2 = new FsmVector2();
			fsmVector2.useVariable = true;
			toPosition = fsmVector2;
			storeHitObject = null;
			storeHitNormal = null;
			hitEvent = null;
			FsmInt fsmInt = 1;
			repeatInterval = fsmInt;
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

		[Token(Token = "0x6000DEE")]
		[Address(RVA = "0xA398D4", Offset = "0xA398D4", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EB9918]);\n\tv21 = *([v20 @ X8_v9]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021E3C]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.fromGameObject);\n\tgoto L_002B;\n\tv91 = *([v66 @ X8_v5+E0]);\n\tv92 = v91 == 0;\n\tv93 = ~v92;\n\tif (v93) goto L_002B;\n\tv98 = v66;\n\tv95 = \"il2cpp_codegen_runtime_class_init\"(v98, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv82 = UnityEngine.Object::op_Inequality(v45, 0);\n\tv100 = v82 == 0;\n\tif (v100) goto L_0039;\n\tv129 = UnityEngine.GameObject::get_transform(v45);\n\tthis._fromTrans = v129;\nL_0039:\n\tv133 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.toGameObject);\n\tgoto L_0049;\n\tv137 = *([v65 @ X8_v6+E0]);\n\tv138 = v137 == 0;\n\tv139 = ~v138;\n\tif (v139) goto L_0049;\n\tv144 = v65;\n\tv141 = \"il2cpp_codegen_runtime_class_init\"(v144, v132, v54, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0049:\n\tv83 = UnityEngine.Object::op_Inequality(v133, 0);\n\tv146 = v83 == 0;\n\tif (v146) goto L_0054;\n\tv149 = UnityEngine.GameObject::get_transform(v133);\n\tthis._toTrans = v149;\nL_0054:\n\tHutongGames.PlayMaker.Actions.LineCast2d::DoRaycast(this);\n\tv113 = HutongGames.PlayMaker.FsmInt::get_Value(this.repeatInterval);\n\tv116 = v113 == 0;\n\tif (v116) goto L_006B;\n\treturn;\nL_006B:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(fromGameObject);
			if (ownerDefaultTarget != null)
			{
				Transform transform = ownerDefaultTarget.transform;
				_fromTrans = transform;
			}
			GameObject value = toGameObject.Value;
			if (value != null)
			{
				Transform transform2 = value.transform;
				_toTrans = transform2;
			}
			DoRaycast();
			if (repeatInterval.Value == 0)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000DEF")]
		[Address(RVA = "0xA39EE8", Offset = "0xA39EE8", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.repeat - 1;\n\tthis.repeat = v2;\n\tv3 = this.repeat == 1;\n\tif (v3) goto L_0006;\n\treturn;\nL_0006:\n\tHutongGames.PlayMaker.Actions.LineCast2d::DoRaycast(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			int num = repeat - 1;
			repeat = num;
			if (repeat == 1)
			{
				DoRaycast();
			}
		}

		[Token(Token = "0x6000DF0")]
		[Address(RVA = "0xA39A18", Offset = "0xA39A18", Length = "0x4D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv36 = *([1EF2628]);\n\tv37 = *([v36 @ X8_v40]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2021E3D]) = v56;\nL_0026:\n\tv66 = HutongGames.PlayMaker.FsmInt::get_Value(this.repeatInterval);\n\tv235 = this.fromPosition;\n\tthis.repeat = v66;\n\tv168 = v235.value.y;\n\tgoto L_003D;\n\tv316 = *([v312 @ X0_v9+E0]);\n\tv317 = v316 == 0;\n\tv318 = ~v317;\n\tif (v318) goto L_003D;\n\tv320 = \"il2cpp_codegen_runtime_class_init\"(v312, v65, v40, v41, v42, v43, v44, v45, v57, v47, v48, v49, v50, v51, v52, v53);\nL_003D:\n\tv323 = UnityEngine.Object::op_Inequality(this._fromTrans, 0);\n\tv415 = v323 == 0;\n\tif (v415) goto L_0051;\n\tv155 = UnityEngine.Transform::get_position(this._fromTrans);\n\tv171 = v235.value + v155;\n\tv418 = UnityEngine.Transform::get_position(this._fromTrans);\n\tv168 = v168 + v418.y;\nL_0051:\n\tv304 = this.toPosition;\n\tv138 = v304.value.y;\n\tgoto L_0064;\n\tv427 = *([v423 @ X0_v14+E0]);\n\tv428 = v427 == 0;\n\tv429 = ~v428;\n\tif (v429) goto L_0064;\n\tv431 = \"il2cpp_codegen_runtime_class_init\"(v423, v285, v161, v41, v42, v43, v44, v45, v156, v150, v144, v49, v50, v51, v52, v53);\nL_0064:\n\tv434 = UnityEngine.Object::op_Inequality(this._toTrans, 0);\n\tv436 = v434 == 0;\n\tif (v436) goto L_007C;\n\tv157 = UnityEngine.Transform::get_position(this._toTrans);\n\tv141 = v304.value + v157;\n\tv441 = UnityEngine.Transform::get_position(this._toTrans);\n\tv138 = v138 + v441.y;\nL_007C:\n\tv445 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.minDepth);\n\tv447 = v445 == 0;\n\tif (v447) goto L_00B8;\n\tv449 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.maxDepth);\n\tv451 = v449 == 0;\n\tif (v451) goto L_00B8;\n\tv460 = HutongGames.PlayMaker.FsmBool::get_Value(this.invertMask);\n\tv469 = HutongGames.PlayMaker.ActionHelpers::LayerArrayToLayerMask(this.layerMask, v460);\n\tgoto L_00A7;\n\tv480 = *([v474 @ X8_v34+E0]);\n\tv481 = v480 == 0;\n\tv482 = ~v481;\n\tif (v482) goto L_00A7;\n\tv499 = v474;\n\tv485 = \"il2cpp_codegen_runtime_class_init\"(v499, v466, v468, v41, v42, v43, v44, v45, v158, v152, v146, v49, v50, v51, v52, v53);\nL_00A7:\n\t// 167 MakeStruct v494 @ AGGA39BEC_0_v4 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v171 @ V8_v4 (System.Single), v168 @ V9_v4 (System.Single)\n\t// 168 MakeStruct v495 @ AGGA39BEC_1_v4 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v141 @ V10_v4 (System.Single), v138 @ V11_v4 (System.Single)\n\tv496 = UnityEngine.Physics2D::Linecast(v494, v495, v469);\n\tv500 = v496.m_Centroid;\n\tv121 = *([v496 @ X0_v84 (UnityEngine.RaycastHit2D)+4]);\n\tv523 = v496.m_Normal;\n\tgoto L_0116;\nL_00B8:\n\tv452 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.minDepth);\n\tv455 = v452 == 0;\n\tif (v455) goto L_00C3;\n\tgoto L_00C9;\nL_00C3:\n\tv464 = HutongGames.PlayMaker.FsmInt::get_Value(this.minDepth);\nL_00C9:\n\tv470 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.maxDepth);\n\tv479 = v470 == 0;\n\tif (v479) goto L_00D4;\n\tgoto L_00DB;\nL_00D4:\n\tv512 = HutongGames.PlayMaker.FsmInt::get_Value(this.maxDepth);\nL_00DB:\n\tv565 = HutongGames.PlayMaker.FsmBool::get_Value(this.invertMask);\n\tv579 = HutongGames.PlayMaker.ActionHelpers::LayerArrayToLayerMask(this.layerMask, v565);\n\tgoto L_00F7;\n\tv593 = *([v585 @ X8_v28+E0]);\n\tv594 = v593 == 0;\n\tv595 = ~v594;\n\tif (v595) goto L_00F7;\n\tv606 = v585;\n\tv597 = \"il2cpp_codegen_runtime_class_init\"(v606, v577, v539, v41, v42, v43, v44, v45, v158, v152, v146, v49, v50, v51, v52, v53);\nL_00F7:\n\t// 247 MakeStruct v515 @ AGGA39CCC_0_v4 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v171 @ V8_v4 (System.Single), v168 @ V9_v4 (System.Single)\n\t// 248 MakeStruct v514 @ AGGA39CCC_1_v4 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v141 @ V10_v4 (System.Single), v138 @ V11_v4 (System.Single)\n\tv543 = UnityEngine.Physics2D::Linecast(v515, v514, v579, v96, v94);\n\tv500 = v543.m_Centroid;\n\tv121 = *([v543 @ X0_v69 (UnityEngine.RaycastHit2D)+4]);\n\tv523 = v543.m_Normal;\nL_0116:\n\tgoto L_0125;\n\tv566 = *([v559 @ X0_v22+E0]);\n\tv567 = v566 == 0;\n\tv568 = ~v567;\n\tgoto L_0125;\n\tv570 = \"il2cpp_codegen_runtime_class_init\"(v559, v540, v538, v41, v42, v43, v44, v45, v556, v555, v147, v132, v91, v89, v52, v53);\nL_0125:\n\tHutongGames.PlayMaker.Fsm::RecordLastRaycastHit2DInfo(this.fsm, &v500 @ stack_-E0_v8 (UnityEngine.Vector2));\n\tv582 = 0x16415C8(&v500 @ stack_-E0_v8 (UnityEngine.Vector2), 0, 0, v41, v42, v43, v44, v45, v523, v500, v147, v132, v96, v94, v52, v53);\n\tgoto L_0138;\n\tv599 = *([v589 @ X8_v17+E0]);\n\tv600 = v599 == 0;\n\tv601 = ~v600;\n\tif (v601) goto L_0138;\n\tv607 = v589;\n\tv603 = \"il2cpp_codegen_runtime_class_init\"(v607, v581, v576, v41, v42, v43, v44, v45, v159, v153, v147, v132, v91, v89, v52, v53);\nL_0138:\n\tv287 = UnityEngine.Object::op_Inequality(v582, 0);\n\tv226 = this.storeDidHit;\n\tv226.value = v287;\n\tv609 = v287 == 0;\n\tif (v609) goto L_0170;\n\tv200 = 0x16415C8(&v500 @ stack_-E0_v8 (UnityEngine.Vector2), 0, 0, v41, v42, v43, v44, v45, v523, v500, v147, v132, v96, v94, v52, v53);\n\tv288 = UnityEngine.Component::get_gameObject(v200);\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.storeHitObject, v288);\n\tv307 = this.storeHitPoint;\n\tv289 = 0x16415A8(&v500 @ stack_-E0_v8 (UnityEngine.Vector2), 0, 0, v41, v42, v43, v44, v45, v523, v500, v147, v132, v96, v94, v52, v53);\n\tv307.value = v523;\n\tv307.value.y = v500;\n\tv308 = this.storeHitNormal;\n\tv290 = 0x16415B0(&v500 @ stack_-E0_v8 (UnityEngine.Vector2), 0, 0, v41, v42, v43, v44, v45, v523, v500, v147, v132, v96, v94, v52, v53);\n\tv308.value = v523;\n\tv308.value.y = v500;\n\tv232 = this.storeHitDistance;\n\tv291 = 0x16415C0(&v500 @ stack_-E0_v8 (UnityEngine.Vector2), 0, 0, v41, v42, v43, v44, v45, v523, v500, v147, v132, v96, v94, v52, v53);\n\tv232.value = v523;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.hitEvent);\nL_0170:\n\tv616 = HutongGames.PlayMaker.FsmBool::get_Value(this.debug);\n\tv619 = v616 == 0;\n\tif (v619) goto L_01B4;\n\tv500 = 0;\n\tv625 = 0x1586898(&v500 @ stack_-E0_v8 (UnityEngine.Vector2), 0, v165, v41, v42, v43, v44, v45, v171, v168, 0, v132, v96, v94, v52, v53);\n\tv292 = 0x1586898(&v241 @ stack_-B0_v4, 0, v165, v41, v42, v43, v44, v45, v141, v138, 0, v132, v96, v94, v52, v53);\n\tv303 = this.debugColor;\n\tgoto L_01A3;\n\tv666 = *([v662 @ X0_v38+E0]);\n\tv667 = v666 == 0;\n\tv668 = ~v667;\n\tif (v668) goto L_01A3;\n\tv670 = \"il2cpp_codegen_runtime_class_init\"(v662, v284, v165, v41, v42, v43, v44, v45, v274, v272, v270, v132, v91, v89, v52, v53);\nL_01A3:\n\t// 419 MakeStruct v627 @ AGGA39EB4_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v121 @ stack_-DC_v3, 0\n\t// 420 MakeStruct v626 @ AGGA39EB4_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v241 @ stack_-B0_v4, v660 @ stack_-AC, 0\n\tUnityEngine.Debug::DrawLine(v627, v626, v303.value);\nL_01B4:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 301 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void DoRaycast()
		{
			//IL_0277: Expected O, but got I
			//IL_03e1: Expected O, but got I
			//IL_0412: Expected O, but got Ref
			//IL_046d: Expected O, but got I4
			//IL_0610: Expected F4, but got O
			//IL_062b: Expected F4, but got O
			//IL_0638: Expected F4, but got O
			//IL_0583: Expected O, but got I4
			int value = repeatInterval.Value;
			FsmVector2 fsmVector = fromPosition;
			repeat = value;
			float num = fsmVector.value.y;
			bool flag = _fromTrans != null;
			bool flag2 = !flag;
			float x = fsmVector.value.x;
			if (!flag2)
			{
				Vector3 position = _fromTrans.position;
				x = fsmVector.value.x + position.x;
				num += _fromTrans.position.y;
			}
			FsmVector2 fsmVector2 = toPosition;
			float num2 = fsmVector2.value.y;
			bool flag3 = _toTrans != null;
			bool flag4 = !flag3;
			float num3 = fsmVector2.value.x;
			if (!flag4)
			{
				Vector3 position2 = _toTrans.position;
				num3 = fsmVector2.value.x + position2.x;
				num2 += _toTrans.position.y;
			}
			Vector2 vector;
			object obj;
			Vector2 normal;
			if (minDepth.IsNone && maxDepth.IsNone)
			{
				bool value2 = invertMask.Value;
				int num4 = ActionHelpers.LayerArrayToLayerMask(layerMask, value2);
				Vector2 start = default(Vector2);
				start.x = x;
				start.y = num;
				Vector2 end = default(Vector2);
				end.x = num3;
				end.y = num2;
				RaycastHit2D raycastHit2D = Physics2D.Linecast(start, end, num4);
				vector = raycastHit2D.m_Centroid;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ X0_v84 (UnityEngine.RaycastHit2D)+4]");
				obj = 0;
				normal = raycastHit2D.m_Normal;
				float num5 = num2;
				float num6 = num3;
			}
			else
			{
				float num7;
				if (minDepth.IsNone)
				{
					num7 = float.NegativeInfinity;
				}
				else
				{
					int value3 = minDepth.Value;
					num7 = value3;
				}
				float num8;
				if (maxDepth.IsNone)
				{
					num8 = float.PositiveInfinity;
				}
				else
				{
					int value4 = maxDepth.Value;
					num8 = value4;
				}
				bool value5 = invertMask.Value;
				int num9 = ActionHelpers.LayerArrayToLayerMask(layerMask, value5);
				Vector2 start2 = default(Vector2);
				start2.x = x;
				start2.y = num;
				Vector2 end2 = default(Vector2);
				end2.x = num3;
				end2.y = num2;
				RaycastHit2D raycastHit2D2 = Physics2D.Linecast(start2, end2, num9, num7, num8);
				vector = raycastHit2D2.m_Centroid;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v543 @ X0_v69 (UnityEngine.RaycastHit2D)+4]");
				obj = 0;
				normal = raycastHit2D2.m_Normal;
				float num5 = num2;
				float num6 = num3;
			}
			Fsm.RecordLastRaycastHit2DInfo(Fsm, (RaycastHit2D)(&vector));
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @16415C8 (inside UnityEngine.PhysicsScene2D::GetRayIntersectionArray_Internal_Injected +0xA0)");
			Object obj2 = default(Object);
			bool flag5 = obj2 != null;
			FsmBool fsmBool = storeDidHit;
			fsmBool.value = flag5;
			bool flag6 = !flag5;
			object obj3 = 0;
			if (!flag6)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @16415C8 (inside UnityEngine.PhysicsScene2D::GetRayIntersectionArray_Internal_Injected +0xA0)");
				Component component = default(Component);
				GameObject gameObject = component.gameObject;
				storeHitObject.Value = gameObject;
				FsmVector2 fsmVector3 = storeHitPoint;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @16415A8 (inside UnityEngine.PhysicsScene2D::GetRayIntersectionArray_Internal_Injected +0x80)");
				fsmVector3.value = normal;
				fsmVector3.value.y = vector.x;
				FsmVector2 fsmVector4 = storeHitNormal;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @16415B0 (inside UnityEngine.PhysicsScene2D::GetRayIntersectionArray_Internal_Injected +0x88)");
				fsmVector4.value = normal;
				fsmVector4.value.y = vector.x;
				FsmFloat fsmFloat = storeHitDistance;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @16415C0 (inside UnityEngine.PhysicsScene2D::GetRayIntersectionArray_Internal_Injected +0x98)");
				fsmFloat.Value = normal.x;
				Fsm.Event(hitEvent);
				obj3 = 0;
			}
			if (debug.Value)
			{
				vector = default(Vector2);
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
				FsmColor fsmColor = debugColor;
				Vector3 start3 = default(Vector3);
				start3.x = 0f;
				start3.y = (float)obj;
				start3.z = 0f;
				Vector3 end3 = default(Vector3);
				object obj4 = default(object);
				end3.x = (float)obj4;
				object obj5 = default(object);
				end3.y = (float)obj5;
				end3.z = 0f;
				Debug.DrawLine(start3, end3, fsmColor.value);
			}
		}

		[Token(Token = "0x6000DF1")]
		[Address(RVA = "0xA39F00", Offset = "0xA39F00", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public LineCast2d()
		{
		}
	}
}
