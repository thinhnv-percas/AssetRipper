using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75A0A8", Offset = "0x75A0A8")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75A0A8", Offset = "0x75A0A8")]
	[Token(Token = "0x20002A9")]
	public class RaycastAll : FsmStateAction
	{
		[Token(Token = "0x4001766")]
		public static RaycastHit[] RaycastAllHitInfo;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BAB24", Offset = "0x7BAB24")]
		[Token(Token = "0x4001767")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault fromGameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BAB5C", Offset = "0x7BAB5C")]
		[Token(Token = "0x4001768")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 fromPosition;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BAB94", Offset = "0x7BAB94")]
		[Token(Token = "0x4001769")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 direction;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BABCC", Offset = "0x7BABCC")]
		[Token(Token = "0x400176A")]
		[FieldOffset(Offset = "0x68")]
		public Space space;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BAC04", Offset = "0x7BAC04")]
		[Token(Token = "0x400176B")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat distance;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7BAC3C", Offset = "0x7BAC3C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BAC3C", Offset = "0x7BAC3C")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BAC3C", Offset = "0x7BAC3C")]
		[Token(Token = "0x400176C")]
		[FieldOffset(Offset = "0x78")]
		public FsmEvent hitEvent;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BACB0", Offset = "0x7BACB0")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BACB0", Offset = "0x7BACB0")]
		[Token(Token = "0x400176D")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool storeDidHit;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BAD00", Offset = "0x7BAD00")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BAD00", Offset = "0x7BAD00")]
		[AttributeAttribute(Type = typeof(ArrayEditorAttribute), RVA = "0x7BAD00", Offset = "0x7BAD00")]
		[Token(Token = "0x400176E")]
		[FieldOffset(Offset = "0x88")]
		public FsmArray storeHitObjects;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BAD84", Offset = "0x7BAD84")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BAD84", Offset = "0x7BAD84")]
		[Token(Token = "0x400176F")]
		[FieldOffset(Offset = "0x90")]
		public FsmVector3 storeHitPoint;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BADD4", Offset = "0x7BADD4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BADD4", Offset = "0x7BADD4")]
		[Token(Token = "0x4001770")]
		[FieldOffset(Offset = "0x98")]
		public FsmVector3 storeHitNormal;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BAE24", Offset = "0x7BAE24")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BAE24", Offset = "0x7BAE24")]
		[Token(Token = "0x4001771")]
		[FieldOffset(Offset = "0xA0")]
		public FsmFloat storeHitDistance;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7BAE74", Offset = "0x7BAE74")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BAE74", Offset = "0x7BAE74")]
		[Token(Token = "0x4001772")]
		[FieldOffset(Offset = "0xA8")]
		public FsmInt repeatInterval;

		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7BAED4", Offset = "0x7BAED4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BAED4", Offset = "0x7BAED4")]
		[Token(Token = "0x4001773")]
		[FieldOffset(Offset = "0xB0")]
		public FsmInt[] layerMask;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BAF24", Offset = "0x7BAF24")]
		[Token(Token = "0x4001774")]
		[FieldOffset(Offset = "0xB8")]
		public FsmBool invertMask;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7BAF5C", Offset = "0x7BAF5C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BAF5C", Offset = "0x7BAF5C")]
		[Token(Token = "0x4001775")]
		[FieldOffset(Offset = "0xC0")]
		public FsmColor debugColor;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BAFBC", Offset = "0x7BAFBC")]
		[Token(Token = "0x4001776")]
		[FieldOffset(Offset = "0xC8")]
		public FsmBool debug;

		[Token(Token = "0x4001777")]
		[FieldOffset(Offset = "0xD0")]
		private int repeat;

		[Token(Token = "0x6000D3F")]
		[Address(RVA = "0xB1E104", Offset = "0xB1E104", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1EFFFB8]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202258D]) = v42;\nL_0015:\n\tthis.fromGameObject = 0;\n\tv46 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.fromPosition = v46;\n\tv52 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v52);\n\tv52.useVariable = 1;\n\tthis.direction = v52;\n\tthis.space = 1;\n\tv96 = HutongGames.PlayMaker.FsmFloat::op_Implicit(100f);\n\tthis.distance = v96;\n\tthis.storeHitNormal = 0;\n\tthis.storeHitObjects = 0;\n\tthis.hitEvent = 0;\n\tv100 = HutongGames.PlayMaker.FsmInt::op_Implicit(1);\n\tthis.repeatInterval = v100;\n\t// 61 NewArr v104 @ X0_v14 (HutongGames.PlayMaker.FsmInt[]), typeof(HutongGames.PlayMaker.FsmInt[]), 0\n\tthis.layerMask = v104;\n\tv107 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.invertMask = v107;\n\tv77 = UnityEngine.Color::get_yellow();\n\tv110 = HutongGames.PlayMaker.FsmColor::op_Implicit(v77);\n\tthis.debugColor = v110;\n\tv83 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.debug = v83;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			fromGameObject = null;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = true;
			fromPosition = fsmVector;
			FsmVector3 fsmVector2 = new FsmVector3();
			fsmVector2.useVariable = true;
			direction = fsmVector2;
			space = Space.Self;
			FsmFloat fsmFloat = 100f;
			distance = fsmFloat;
			storeHitNormal = null;
			storeHitObjects = null;
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

		[Token(Token = "0x6000D40")]
		[Address(RVA = "0xB1E228", Offset = "0xB1E228", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.RaycastAll::DoRaycast(this);\n\tv14 = HutongGames.PlayMaker.FsmInt::get_Value(this.repeatInterval);\n\tv30 = v14 == 0;\n\tif (v30) goto L_0019;\n\treturn;\nL_0019:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoRaycast();
			if (repeatInterval.Value == 0)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000D41")]
		[Address(RVA = "0xB1E820", Offset = "0xB1E820", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.repeat - 1;\n\tthis.repeat = v2;\n\tv3 = this.repeat == 1;\n\tif (v3) goto L_0006;\n\treturn;\nL_0006:\n\tHutongGames.PlayMaker.Actions.RaycastAll::DoRaycast(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			int num = repeat - 1;
			repeat = num;
			if (repeat == 1)
			{
				DoRaycast();
			}
		}

		[Token(Token = "0x6000D42")]
		[Address(RVA = "0xB1E274", Offset = "0xB1E274", Length = "0x5AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tv46 = *([1ECB8D8]);\n\tv47 = *([v46 @ X8_v60]);\n\tv48 = \"il2cpp_codegen_initialize_method\"(v47, methodInfo, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63);\n\tv66 = 0 | 1;\n\t*([202258E]) = v66;\nL_002E:\n\tv79 = HutongGames.PlayMaker.FsmInt::get_Value(this.repeatInterval);\n\tthis.repeat = v79;\n\tv325 = HutongGames.PlayMaker.FsmFloat::get_Value(this.distance);\n\tv293 = v325 == 0;\n\tif (v293) goto L_0216;\n\tv905 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.fromGameObject);\n\tgoto L_0057;\n\tv914 = *([v372 @ X8_v31+E0]);\n\tv915 = v914 == 0;\n\tv916 = ~v915;\n\tif (v916) goto L_0057;\n\tv921 = v372;\n\tv918 = \"il2cpp_codegen_runtime_class_init\"(v921, v903, v904, v51, v52, v53, v54, v55, v325, v57, v58, v59, v60, v61, v62, v63);\nL_0057:\n\tv581 = UnityEngine.Object::op_Inequality(v905, 0);\n\tv923 = v581 == 0;\n\tif (v923) goto L_006B;\n\tv348 = UnityEngine.GameObject::get_transform(v905);\n\tv331 = UnityEngine.Transform::get_position(v348);\n\tv931 = v331.y;\n\tv511 = v331.z;\n\tgoto L_0075;\nL_006B:\n\tv331 = HutongGames.PlayMaker.FsmVector3::get_Value(this.fromPosition);\n\tv931 = v331.y;\n\tv511 = v331.z;\nL_0075:\n\tv325 = HutongGames.PlayMaker.FsmFloat::get_Value(this.distance);\n\tv224 = v325 <= 0;\n\tif (v224) goto L_FFFFFFFF;\n\tv325 = HutongGames.PlayMaker.FsmFloat::get_Value(this.distance);\n\tgoto L_0090;\nL_0090:\n\tv561 = HutongGames.PlayMaker.FsmVector3::get_Value(this.direction);\n\tv931 = v561.y;\n\tgoto L_00A3;\n\tv964 = *([v959 @ X0_v49+E0]);\n\tv965 = v964 == 0;\n\tv966 = ~v965;\n\tif (v966) goto L_00A3;\n\tv968 = \"il2cpp_codegen_runtime_class_init\"(v959, v958, v254, v51, v52, v53, v54, v55, v561, v516, v512, v59, v60, v61, v62, v63);\nL_00A3:\n\tv582 = UnityEngine.Object::op_Inequality(v905, 0);\n\tv979 = v582 == 0;\n\tif (v979) goto L_00D1;\n\tv509 = this.space != 1;\n\tif (v509) goto L_00D1;\n\tv583 = UnityEngine.GameObject::get_transform(v905);\n\tv562 = HutongGames.PlayMaker.FsmVector3::get_Value(this.direction);\n\tv999 = UnityEngine.Transform::TransformDirection(v583, v562);\n\tv931 = v999.y;\nL_00D1:\n\tv1012 = HutongGames.PlayMaker.FsmBool::get_Value(this.invertMask);\n\tv1029 = HutongGames.PlayMaker.ActionHelpers::LayerArrayToLayerMask(this.layerMask, v1012);\n\t// 222 MakeStruct v182 @ AGGB1E4B4_0_v8 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v331 @ V0_v26 (UnityEngine.Vector3), v931 @ V1_v23 (System.Single), v511 @ V2_v12 (System.Single)\n\t// 223 MakeStruct v177 @ AGGB1E4B4_1_v8 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v503 @ V12_v9 (UnityEngine.Vector3), v500 @ V13_v9 (System.Single), v498 @ V14_v9 (System.Single)\n\tv585 = UnityEngine.Physics::RaycastAll(v182, v177, v506, v1029);\n\tv1037.RaycastAllHitInfo = v585;\n\tv485 = v521.RaycastAllHitInfo;\n\tv522 = this.storeDidHit;\n\tv547 = v485.Length == 0;\n\tv510 = ~v547;\n\tv522.value = v510;\n\tv957 = v485.Length == 0;\n\tif (v957) goto L_01A5;\n\tv615 = v1049.RaycastAllHitInfo;\n\t// 261 NewArr v586 @ X0_v60 (System.Object[]), typeof(UnityEngine.GameObject[]), v615.Length\n\tv732 = v1053.RaycastAllHitInfo;\nL_010E:\n\t;\n\tv225 = v158 >= v732.Length;\n\tif (v225) goto L_015D;\n\tv1066 = v158 < v732.Length;\n\tv319 = ~v1066;\n\tif (v319) goto L_0217;\n\tv1067 = v158 * 0x2C;\n\tv373 = v732 + v1067;\n\tv931 = *([v373 @ X8_v46+20]);\n\tv325 = v732[v158 @ X23_v10 (System.Int32)].m_Normal.y;\n\tv351 = 0x164C7C8(&v931 @ V1_v23 (System.Single), 0, 0, v51, v52, v53, v54, v55, v732[v158 @ X23_v10 (System.Int32)].m_Normal.y, *([v373 @ X8_v46+20]), v511, v503, v500, v498, v506, v63);\n\tv587 = UnityEngine.Component::get_gameObject(v351);\n\tv1072 = v587 == 0;\n\tif (v1072) goto L_0141;\n\t// 318 IsInst v441 @ X0_v69, typeof(System.Object), v587 @ X0_v66 (UnityEngine.GameObject)\nL_0141:\n\t;\n\tv1075 = v158 < v586.Length;\n\tv557 = ~v1075;\n\tif (v557) goto L_0217;\n\tv586[v158 @ X23_v10 (System.Int32)] = v587;\n\tv158 = v158 + 1;\n\tv732 = v1078.RaycastAllHitInfo;\n\tv1079 = v1078.RaycastAllHitInfo == 0;\n\tv593 = ~v1079;\n\tif (v593) goto L_010E;\n\tthrow System.NullReferenceException;\nL_015D:\n\tHutongGames.PlayMaker.FsmArray::set_Values(this.storeHitObjects, v586);\n\tv617 = this.fsm;\n\tv626 = this.storeHitPoint;\n\tv564 = v617.<RaycastHitInfo>k__BackingField;\n\tv588 = 0x164C878(&v564 @ V0_v17 (UnityEngine.Vector3), 0, 0, v51, v52, v53, v54, v55, v617.<RaycastHitInfo>k__BackingField, v931, v511, v503, v500, v498, v506, v63);\n\tv626.value = v617.<RaycastHitInfo>k__BackingField;\n\tv626.value.y = v931;\n\tv626.value.z = v511;\n\tv619 = this.fsm;\n\tv627 = this.storeHitNormal;\n\tv565 = v619.<RaycastHitInfo>k__BackingField;\n\tv589 = 0x164C884(&v565 @ V0_v20 (UnityEngine.Vector3), 0, 0, v51, v52, v53, v54, v55, v619.<RaycastHitInfo>k__BackingField, v931, v511, v503, v500, v498, v506, v63);\n\tv627.value = v619.<RaycastHitInfo>k__BackingField;\n\tv627.value.y = v931;\n\tv627.value.z = v511;\n\tv621 = this.fsm;\n\tv383 = this.storeHitDistance;\n\tv325 = v621.<RaycastHitInfo>k__BackingField;\n\tv590 = 0x164C890(&v325 @ V0_v25 (System.Single), 0, 0, v51, v52, v53, v54, v55, v621.<RaycastHitInfo>k__BackingField, v931, v511, v503, v500, v498, v506, v63);\n\tv383.value = v621.<RaycastHitInfo>k__BackingField;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.hitEvent);\nL_01A5:\n\tv814 = HutongGames.PlayMaker.FsmBool::get_Value(this.debug);\n\tv817 = v814 == 0;\n\tif (v817) goto L_0216;\n\tgoto L_01B9;\n\tv980 = *([v974 @ X0_v14+E0]);\n\tv981 = v980 == 0;\n\tv982 = ~v981;\n\tif (v982) goto L_01B9;\n\tv984 = \"il2cpp_codegen_runtime_class_init\"(v974, v578, v258, v51, v52, v53, v54, v55, v330, v239, v233, v200, v196, v192, v188, v63);\nL_01B9:\n\tv325 = UnityEngine.Mathf::Min(v506, 1000f);\n\tgoto L_01CC;\n\tv1013 = *([v1007 @ X0_v17+E0]);\n\tv1014 = v1013 == 0;\n\tv1015 = ~v1014;\n\tif (v1015) goto L_01CC;\n\tv1017 = \"il2cpp_codegen_runtime_class_init\"(v1007, v578, v258, v51, v52, v53, v54, v55, v991, v988, v233, v200, v196, v192, v188, v63);\nL_01CC:\n\t// 460 MakeStruct v463 @ AGGB1E74C_0_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v503 @ V12_v9 (UnityEngine.Vector3), v500 @ V13_v9 (System.Single), v498 @ V14_v9 (System.Single)\n\tv1025 = UnityEngine.Vector3::op_Multiply(v463, v325);\n\t// 474 MakeStruct v455 @ AGGB1E774_0_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v83 @ V8_v6 (UnityEngine.Vector3), v87 @ V9_v6 (System.Single), v91 @ V15_v6 (System.Single)\n\tv566 = UnityEngine.Vector3::op_Addition(v455, v1025);\n\tv622 = this.debugColor;\n\tgoto L_0200;\n\tv1043 = *([v1040 @ X0_v21+E0]);\n\tv1044 = v1043 == 0;\n\tv1045 = ~v1044;\n\tif (v1045) goto L_0200;\n\tv1047 = \"il2cpp_codegen_runtime_class_init\"(v1040, v578, v258, v51, v52, v53, v54, v55, v566, v519, v514, v496, v494, v492, v188, v63);\nL_0200:\n\t// 512 MakeStruct v737 @ AGGB1E7D4_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v83 @ V8_v6 (UnityEngine.Vector3), v87 @ V9_v6 (System.Single), v91 @ V15_v6 (System.Single)\n\tUnityEngine.Debug::DrawLine(v737, v566, v622.value);\nL_0216:\n\treturn;\nL_0217:\n\tv700 = new System.IndexOutOfRangeException();\n\tgoto L_021D;\n\tv386 = new System.NullReferenceException();\n\tv447 = new System.ArrayTypeMismatchException();\nL_021D:\n\tthrow v699;\n// 393 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoRaycast()
		{
			//IL_0416: Expected O, but got I
			//IL_0426: Expected F4, but got I
			//IL_0635: Expected F4, but got O
			//IL_0656: Expected F4, but got O
			int value = repeatInterval.Value;
			repeat = value;
			float value2 = distance.Value;
			if (value2 == 0f)
			{
				return;
			}
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(fromGameObject);
			Vector3 vector;
			float z;
			float y;
			if (ownerDefaultTarget != null)
			{
				Transform transform = ownerDefaultTarget.transform;
				vector = transform.position;
				y = vector.y;
				z = vector.z;
			}
			else
			{
				vector = fromPosition.Value;
				y = vector.y;
				z = vector.z;
			}
			value2 = distance.Value;
			float num;
			if (value2 > 0f)
			{
				value2 = distance.Value;
				num = value2;
			}
			else
			{
				num = float.PositiveInfinity;
			}
			Vector3 value3 = direction.Value;
			y = value3.y;
			bool flag = ownerDefaultTarget != null;
			bool flag2 = !flag;
			float z2 = value3.z;
			float y2 = value3.y;
			Vector3 vector2 = value3;
			if (!flag2)
			{
				bool flag3 = space != Space.Self;
				z2 = value3.z;
				y2 = value3.y;
				vector2 = value3;
				if (!flag3)
				{
					Transform transform2 = ownerDefaultTarget.transform;
					Vector3 value4 = direction.Value;
					Vector3 vector3 = transform2.TransformDirection(value4);
					y = vector3.y;
					z2 = vector3.z;
					y2 = vector3.y;
					vector2 = vector3;
				}
			}
			bool value5 = invertMask.Value;
			int num2 = ActionHelpers.LayerArrayToLayerMask(layerMask, value5);
			Vector3 origin = default(Vector3);
			origin.x = vector.x;
			origin.y = y;
			origin.z = z;
			Vector3 vector4 = default(Vector3);
			vector4.x = vector2.x;
			vector4.y = y2;
			vector4.z = z2;
			RaycastHit[] raycastAllHitInfo = Physics.RaycastAll(origin, vector4, num, num2);
			RaycastAllHitInfo = raycastAllHitInfo;
			RaycastHit[] raycastAllHitInfo2 = RaycastAllHitInfo;
			FsmBool fsmBool = storeDidHit;
			bool flag4 = raycastAllHitInfo2.Length == 0;
			bool value6 = !flag4;
			fsmBool.value = value6;
			bool flag5 = raycastAllHitInfo2.Length == 0;
			Vector3 vector5 = vector;
			float y3 = y;
			float z3 = z;
			if (!flag5)
			{
				RaycastHit[] raycastAllHitInfo3 = RaycastAllHitInfo;
				object[] array = new GameObject[raycastAllHitInfo3.Length];
				RaycastHit[] raycastAllHitInfo4 = RaycastAllHitInfo;
				int num3 = 0;
				Component component = default(Component);
				IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
				while (true)
				{
					bool flag6 = num3 >= raycastAllHitInfo4.Length;
					vector5 = vector;
					y3 = y;
					z3 = z;
					if (flag6)
					{
						break;
					}
					if (num3 < raycastAllHitInfo4.Length)
					{
						int num4 = num3 * 44;
						object obj = (long)(IntPtr)raycastAllHitInfo4 + (long)num4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v373 @ X8_v46+20]");
						y = 0f;
						value2 = raycastAllHitInfo4[num3].m_Normal.y;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @164C7C8 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x150)");
						GameObject gameObject = component.gameObject;
						if ((object)gameObject != null)
						{
							object obj2 = gameObject as object;
						}
						if (num3 < array.Length)
						{
							array[num3] = gameObject;
							num3++;
							raycastAllHitInfo4 = RaycastAllHitInfo;
							bool flag7 = RaycastAllHitInfo == null;
							bool flag8 = !flag7;
							vector5 = vector;
							y3 = y;
							z3 = z;
							if (!flag8)
							{
								throw new NullReferenceException();
							}
							continue;
						}
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex2;
				}
				storeHitObjects.Values = array;
				Fsm fsm = Fsm;
				FsmVector3 fsmVector = storeHitPoint;
				Vector3 vector6 = (Vector3)fsm.RaycastHitInfo;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @164C878 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x200)");
				fsmVector.value = (Vector3)fsm.RaycastHitInfo;
				fsmVector.value.y = y;
				fsmVector.value.z = z;
				Fsm fsm2 = Fsm;
				FsmVector3 fsmVector2 = storeHitNormal;
				Vector3 vector7 = (Vector3)fsm2.RaycastHitInfo;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @164C884 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x20C)");
				fsmVector2.value = (Vector3)fsm2.RaycastHitInfo;
				fsmVector2.value.y = y;
				fsmVector2.value.z = z;
				Fsm fsm3 = Fsm;
				FsmFloat fsmFloat = storeHitDistance;
				value2 = (float)fsm3.RaycastHitInfo;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @164C890 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x218)");
				fsmFloat.Value = (float)fsm3.RaycastHitInfo;
				Fsm.Event(hitEvent);
			}
			if (debug.Value)
			{
				value2 = Mathf.Min(num, 1000f);
				Vector3 vector8 = default(Vector3);
				vector8.x = vector2.x;
				vector8.y = y2;
				vector8.z = z2;
				Vector3 vector9 = vector8 * value2;
				Vector3 vector10 = default(Vector3);
				vector10.x = vector5.x;
				vector10.y = y3;
				vector10.z = z3;
				Vector3 end = vector10 + vector9;
				FsmColor fsmColor = debugColor;
				Vector3 start = default(Vector3);
				start.x = vector5.x;
				start.y = y3;
				start.z = z3;
				Debug.DrawLine(start, end, fsmColor.value);
			}
		}

		[Token(Token = "0x6000D43")]
		[Address(RVA = "0xB1E838", Offset = "0xB1E838", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RaycastAll()
		{
		}
	}
}
