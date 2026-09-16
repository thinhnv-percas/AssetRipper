using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75A058", Offset = "0x75A058")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x75A058", Offset = "0x75A058")]
	[Token(Token = "0x20002A8")]
	public class Raycast : FsmStateAction
	{
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BA688", Offset = "0x7BA688")]
		[Token(Token = "0x4001755")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault fromGameObject;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BA6C0", Offset = "0x7BA6C0")]
		[Token(Token = "0x4001756")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector3 fromPosition;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BA6F8", Offset = "0x7BA6F8")]
		[Token(Token = "0x4001757")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 direction;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BA730", Offset = "0x7BA730")]
		[Token(Token = "0x4001758")]
		[FieldOffset(Offset = "0x68")]
		public Space space;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BA768", Offset = "0x7BA768")]
		[Token(Token = "0x4001759")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat distance;

		[Attribute(Type = typeof(ActionSection), RVA = "0x7BA7A0", Offset = "0x7BA7A0")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BA7A0", Offset = "0x7BA7A0")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BA7A0", Offset = "0x7BA7A0")]
		[Token(Token = "0x400175A")]
		[FieldOffset(Offset = "0x78")]
		public FsmEvent hitEvent;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BA814", Offset = "0x7BA814")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BA814", Offset = "0x7BA814")]
		[Token(Token = "0x400175B")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool storeDidHit;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BA864", Offset = "0x7BA864")]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BA864", Offset = "0x7BA864")]
		[Token(Token = "0x400175C")]
		[FieldOffset(Offset = "0x88")]
		public FsmGameObject storeHitObject;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BA8B4", Offset = "0x7BA8B4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BA8B4", Offset = "0x7BA8B4")]
		[Token(Token = "0x400175D")]
		[FieldOffset(Offset = "0x90")]
		public FsmVector3 storeHitPoint;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BA904", Offset = "0x7BA904")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BA904", Offset = "0x7BA904")]
		[Token(Token = "0x400175E")]
		[FieldOffset(Offset = "0x98")]
		public FsmVector3 storeHitNormal;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BA954", Offset = "0x7BA954")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BA954", Offset = "0x7BA954")]
		[Token(Token = "0x400175F")]
		[FieldOffset(Offset = "0xA0")]
		public FsmFloat storeHitDistance;

		[Attribute(Type = typeof(ActionSection), RVA = "0x7BA9A4", Offset = "0x7BA9A4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BA9A4", Offset = "0x7BA9A4")]
		[Token(Token = "0x4001760")]
		[FieldOffset(Offset = "0xA8")]
		public FsmInt repeatInterval;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7BAA04", Offset = "0x7BAA04")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BAA04", Offset = "0x7BAA04")]
		[Token(Token = "0x4001761")]
		[FieldOffset(Offset = "0xB0")]
		public FsmInt[] layerMask;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BAA54", Offset = "0x7BAA54")]
		[Token(Token = "0x4001762")]
		[FieldOffset(Offset = "0xB8")]
		public FsmBool invertMask;

		[Attribute(Type = typeof(ActionSection), RVA = "0x7BAA8C", Offset = "0x7BAA8C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BAA8C", Offset = "0x7BAA8C")]
		[Token(Token = "0x4001763")]
		[FieldOffset(Offset = "0xC0")]
		public FsmColor debugColor;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7BAAEC", Offset = "0x7BAAEC")]
		[Token(Token = "0x4001764")]
		[FieldOffset(Offset = "0xC8")]
		public FsmBool debug;

		[Token(Token = "0x4001765")]
		[FieldOffset(Offset = "0xD0")]
		private int repeat;

		[Token(Token = "0x6000D3A")]
		[Address(RVA = "0xB1DA50", Offset = "0xB1DA50", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ECC1F8]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202258B]) = v42;\nL_0015:\n\tthis.fromGameObject = 0;\n\tv46 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.fromPosition = v46;\n\tv52 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v52);\n\tv52.useVariable = 1;\n\tthis.direction = v52;\n\tthis.space = 1;\n\tv96 = HutongGames.PlayMaker.FsmFloat::op_Implicit(100f);\n\tthis.distance = v96;\n\tthis.storeHitNormal = 0;\n\tthis.storeHitObject = 0;\n\tthis.hitEvent = 0;\n\tv100 = HutongGames.PlayMaker.FsmInt::op_Implicit(1);\n\tthis.repeatInterval = v100;\n\t// 61 NewArr v104 @ X0_v14 (HutongGames.PlayMaker.FsmInt[]), typeof(HutongGames.PlayMaker.FsmInt[]), 0\n\tthis.layerMask = v104;\n\tv107 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.invertMask = v107;\n\tv77 = UnityEngine.Color::get_yellow();\n\tv110 = HutongGames.PlayMaker.FsmColor::op_Implicit(v77);\n\tthis.debugColor = v110;\n\tv83 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.debug = v83;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
			storeHitObject = null;
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

		[Token(Token = "0x6000D3B")]
		[Address(RVA = "0xB1DB74", Offset = "0xB1DB74", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.Raycast::DoRaycast(this);\n\tv14 = HutongGames.PlayMaker.FsmInt::get_Value(this.repeatInterval);\n\tv30 = v14 == 0;\n\tif (v30) goto L_0019;\n\treturn;\nL_0019:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoRaycast();
			if (repeatInterval.Value == 0)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000D3C")]
		[Address(RVA = "0xB1E0E4", Offset = "0xB1E0E4", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.repeat - 1;\n\tthis.repeat = v2;\n\tv3 = this.repeat == 1;\n\tif (v3) goto L_0006;\n\treturn;\nL_0006:\n\tHutongGames.PlayMaker.Actions.Raycast::DoRaycast(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			int num = repeat - 1;
			repeat = num;
			if (repeat == 1)
			{
				DoRaycast();
			}
		}

		[Token(Token = "0x6000D3D")]
		[Address(RVA = "0xB1DBC0", Offset = "0xB1DBC0", Length = "0x524")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv38 = *([1EA3F18]);\n\tv39 = *([v38 @ X8_v43]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv58 = 0 | 1;\n\t*([202258C]) = v58;\nL_002A:\n\tv71 = HutongGames.PlayMaker.FsmInt::get_Value(this.repeatInterval);\n\tthis.repeat = v71;\n\tv191 = HutongGames.PlayMaker.FsmFloat::get_Value(this.distance);\n\tv171 = v191 == 0;\n\tif (v171) goto L_01CE;\n\tv553 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.fromGameObject);\n\tgoto L_0053;\n\tv558 = *([v234 @ X8_v7+E0]);\n\tv559 = v558 == 0;\n\tv560 = ~v559;\n\tif (v560) goto L_0053;\n\tv565 = v234;\n\tv562 = \"il2cpp_codegen_runtime_class_init\"(v565, v551, v552, v43, v44, v45, v46, v47, v191, v49, v50, v51, v52, v53, v54, v55);\nL_0053:\n\tv352 = UnityEngine.Object::op_Inequality(v553, 0);\n\tv567 = v352 == 0;\n\tif (v567) goto L_0067;\n\tv212 = UnityEngine.GameObject::get_transform(v553);\n\tv196 = UnityEngine.Transform::get_position(v212);\n\tv133 = v196.y;\n\tv129 = v196.z;\n\tgoto L_0071;\nL_0067:\n\tv196 = HutongGames.PlayMaker.FsmVector3::get_Value(this.fromPosition);\n\tv133 = v196.y;\n\tv129 = v196.z;\nL_0071:\n\tv191 = HutongGames.PlayMaker.FsmFloat::get_Value(this.distance);\n\tv126 = v191 <= 0;\n\tif (v126) goto L_FFFFFFFF;\n\tv191 = HutongGames.PlayMaker.FsmFloat::get_Value(this.distance);\n\tgoto L_008C;\nL_008C:\n\tv335 = HutongGames.PlayMaker.FsmVector3::get_Value(this.direction);\n\tgoto L_009F;\n\tv594 = *([v590 @ X0_v20+E0]);\n\tv595 = v594 == 0;\n\tv596 = ~v595;\n\tif (v596) goto L_009F;\n\tv598 = \"il2cpp_codegen_runtime_class_init\"(v590, v589, v145, v43, v44, v45, v46, v47, v335, v308, v304, v51, v52, v53, v54, v55);\nL_009F:\n\tv353 = UnityEngine.Object::op_Inequality(v553, 0);\n\tv603 = v353 == 0;\n\tif (v603) goto L_00CD;\n\tv302 = this.space != 1;\n\tif (v302) goto L_00CD;\n\tv354 = UnityEngine.GameObject::get_transform(v553);\n\tv336 = HutongGames.PlayMaker.FsmVector3::get_Value(this.direction);\n\tv611 = UnityEngine.Transform::TransformDirection(v354, v336);\nL_00CD:\n\tv617 = HutongGames.PlayMaker.FsmBool::get_Value(this.invertMask);\n\tv622 = HutongGames.PlayMaker.ActionHelpers::LayerArrayToLayerMask(this.layerMask, v617);\n\t// 220 MakeStruct v102 @ AGGB1DE00_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v196 @ V0_v6 (UnityEngine.Vector3), v133 @ V1_v4 (System.Single), v129 @ V2_v4 (System.Single)\n\t// 221 MakeStruct v99 @ AGGB1DE00_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v121 @ V12_v6 (UnityEngine.Vector3), v119 @ V13_v6 (System.Single), v117 @ V14_v6 (System.Single)\n\tv356 = UnityEngine.Physics::Raycast(v102, v99, &v112 @ stack_-A0_v5 (UnityEngine.RaycastHit), v123, v622);\n\tv382 = this.fsm;\n\tv382.<RaycastHitInfo>k__BackingField.m_Distance = v627;\n\tv382.<RaycastHitInfo>k__BackingField.m_Normal.y = 0f;\n\tv382.<RaycastHitInfo>k__BackingField = v112;\n\tv635 = 0x164C7C8(&v112 @ stack_-A0_v5 (UnityEngine.RaycastHit), 0, 0, v43, v44, v45, v46, v47, v112, 0, v112, v121, v119, v117, v123, v55);\n\tgoto L_0103;\n\tv640 = *([v636 @ X8_v14+E0]);\n\tv641 = v640 == 0;\n\tv642 = ~v641;\n\tif (v642) goto L_0103;\n\tv647 = v636;\n\tv644 = \"il2cpp_codegen_runtime_class_init\"(v647, v631, v317, v43, v44, v45, v46, v47, v193, v134, v130, v110, v108, v106, v104, v55);\nL_0103:\n\tv357 = UnityEngine.Object::op_Inequality(v635, 0);\n\tv235 = this.storeDidHit;\n\tv235.value = v357;\n\tv649 = v357 == 0;\n\tif (v649) goto L_0161;\n\tv215 = 0x164C7C8(&v112 @ stack_-A0_v5 (UnityEngine.RaycastHit), 0, 0, v43, v44, v45, v46, v47, v112, 0, v112, v121, v119, v117, v123, v55);\n\tv358 = UnityEngine.Component::get_gameObject(v215);\n\tHutongGames.PlayMaker.FsmGameObject::set_Value(this.storeHitObject, v358);\n\tv383 = this.fsm;\n\tv393 = this.storeHitPoint;\n\tv338 = v383.<RaycastHitInfo>k__BackingField;\n\tv360 = 0x164C878(&v338 @ V0_v26 (UnityEngine.Vector3), 0, 0, v43, v44, v45, v46, v47, v383.<RaycastHitInfo>k__BackingField, 0, v112, v121, v119, v117, v123, v55);\n\tv393.value = v383.<RaycastHitInfo>k__BackingField;\n\tv393.value.y = 0f;\n\tv393.value.z = v112;\n\tv385 = this.fsm;\n\tv394 = this.storeHitNormal;\n\tv339 = v385.<RaycastHitInfo>k__BackingField;\n\tv361 = 0x164C884(&v339 @ V0_v29 (UnityEngine.Vector3), 0, 0, v43, v44, v45, v46, v47, v385.<RaycastHitInfo>k__BackingField, 0, v112, v121, v119, v117, v123, v55);\n\tv394.value = v385.<RaycastHitInfo>k__BackingField;\n\tv394.value.y = 0f;\n\tv394.value.z = v112;\n\tv387 = this.fsm;\n\tv243 = this.storeHitDistance;\n\tv191 = v387.<RaycastHitInfo>k__BackingField;\n\tv362 = 0x164C890(&v191 @ V0_v4 (System.Single), 0, 0, v43, v44, v45, v46, v47, v387.<RaycastHitInfo>k__BackingField, 0, v112, v121, v119, v117, v123, v55);\n\tv243.value = v387.<RaycastHitInfo>k__BackingField;\n\tHutongGames.PlayMaker.Fsm::Event(this.fsm, this.hitEvent);\nL_0161:\n\tv546 = HutongGames.PlayMaker.FsmBool::get_Value(this.debug);\n\tv548 = v546 == 0;\n\tif (v548) goto L_01CE;\n\tgoto L_0175;\n\tv663 = *([v659 @ X0_v39+E0]);\n\tv664 = v663 == 0;\n\tv665 = ~v664;\n\tif (v665) goto L_0175;\n\tv667 = \"il2cpp_codegen_runtime_class_init\"(v659, v350, v148, v43, v44, v45, v46, v47, v195, v134, v130, v110, v108, v106, v104, v55);\nL_0175:\n\tv191 = UnityEngine.Mathf::Min(v123, 1000f);\n\tgoto L_0188;\n\tv686 = *([v678 @ X0_v42+E0]);\n\tv687 = v686 == 0;\n\tv688 = ~v687;\n\tif (v688) goto L_0188;\n\tv690 = \"il2cpp_codegen_runtime_class_init\"(v678, v350, v148, v43, v44, v45, v46, v47, v674, v671, v130, v110, v108, v106, v104, v55);\nL_0188:\n\t// 392 MakeStruct v267 @ AGGB1E028_0_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v121 @ V12_v6 (UnityEngine.Vector3), v119 @ V13_v6 (System.Single), v117 @ V14_v6 (System.Single)\n\tv698 = UnityEngine.Vector3::op_Multiply(v267, v191);\n\t// 406 MakeStruct v256 @ AGGB1E050_0_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v196 @ V0_v6 (UnityEngine.Vector3), v133 @ V1_v4 (System.Single), v129 @ V2_v4 (System.Single)\n\tv340 = UnityEngine.Vector3::op_Addition(v256, v698);\n\tv388 = this.debugColor;\n\tgoto L_01BC;\n\tv713 = *([v710 @ X0_v46+E0]);\n\tv714 = v713 == 0;\n\tv715 = ~v714;\n\tif (v715) goto L_01BC;\n\tv717 = \"il2cpp_codegen_runtime_class_init\"(v710, v350, v148, v43, v44, v45, v46, v47, v340, v310, v306, v288, v286, v284, v104, v55);\nL_01BC:\n\t// 444 MakeStruct v520 @ AGGB1E0B0_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v196 @ V0_v6 (UnityEngine.Vector3), v133 @ V1_v4 (System.Single), v129 @ V2_v4 (System.Single)\n\tUnityEngine.Debug::DrawLine(v520, v340, v388.value);\nL_01CE:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 339 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoRaycast()
		{
			//IL_031d: Expected F4, but got O
			//IL_0443: Expected F4, but got O
			//IL_04b4: Expected F4, but got O
			//IL_04da: Expected F4, but got O
			//IL_0500: Expected F4, but got O
			int value = repeatInterval.Value;
			repeat = value;
			float value2 = distance.Value;
			if (value2 == 0f)
			{
				return;
			}
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(fromGameObject);
			Vector3 vector;
			float y;
			float z;
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
			bool flag4 = Physics.Raycast(origin, vector4, out var hitInfo, num, num2);
			Fsm fsm = Fsm;
			object obj = default(object);
			fsm.RaycastHitInfo.m_Distance = (float)obj;
			fsm.RaycastHitInfo.m_Normal.y = 0f;
			fsm.RaycastHitInfo = hitInfo;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @164C7C8 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x150)");
			Object obj2 = default(Object);
			bool flag5 = obj2 != null;
			FsmBool fsmBool = storeDidHit;
			fsmBool.value = flag5;
			if (flag5)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @164C7C8 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x150)");
				Component component = default(Component);
				GameObject gameObject = component.gameObject;
				storeHitObject.Value = gameObject;
				Fsm fsm2 = Fsm;
				FsmVector3 fsmVector = storeHitPoint;
				Vector3 vector5 = (Vector3)fsm2.RaycastHitInfo;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @164C878 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x200)");
				fsmVector.value = (Vector3)fsm2.RaycastHitInfo;
				fsmVector.value.y = 0f;
				fsmVector.value.z = (float)hitInfo;
				Fsm fsm3 = Fsm;
				FsmVector3 fsmVector2 = storeHitNormal;
				Vector3 vector6 = (Vector3)fsm3.RaycastHitInfo;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @164C884 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x20C)");
				fsmVector2.value = (Vector3)fsm3.RaycastHitInfo;
				fsmVector2.value.y = 0f;
				fsmVector2.value.z = (float)hitInfo;
				Fsm fsm4 = Fsm;
				FsmFloat fsmFloat = storeHitDistance;
				value2 = (float)fsm4.RaycastHitInfo;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @164C890 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x218)");
				fsmFloat.Value = (float)fsm4.RaycastHitInfo;
				Fsm.Event(hitEvent);
			}
			if (debug.Value)
			{
				value2 = Mathf.Min(num, 1000f);
				Vector3 vector7 = default(Vector3);
				vector7.x = vector2.x;
				vector7.y = y2;
				vector7.z = z2;
				Vector3 vector8 = vector7 * value2;
				Vector3 vector9 = default(Vector3);
				vector9.x = vector.x;
				vector9.y = y;
				vector9.z = z;
				Vector3 end = vector9 + vector8;
				FsmColor fsmColor = debugColor;
				Vector3 start = default(Vector3);
				start.x = vector.x;
				start.y = y;
				start.z = z;
				Debug.DrawLine(start, end, fsmColor.value);
			}
		}

		[Token(Token = "0x6000D3E")]
		[Address(RVA = "0xB1E0FC", Offset = "0xB1E0FC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Raycast()
		{
		}
	}
}
