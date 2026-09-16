using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[NoActionTargets]
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x757B48", Offset = "0x757B48")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x757B48", Offset = "0x757B48")]
	[Token(Token = "0x2000237")]
	public class GetAxisVector : FsmStateAction
	{
		[Token(Token = "0x200048A")]
		public enum AxisPlane
		{
			[Token(Token = "0x4002172")]
			XZ = 0,
			[Token(Token = "0x4002173")]
			XY = 1,
			[Token(Token = "0x4002174")]
			YZ = 2
		}

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B3298", Offset = "0x7B3298")]
		[Token(Token = "0x4001558")]
		[FieldOffset(Offset = "0x50")]
		public FsmString horizontalAxis;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B32D0", Offset = "0x7B32D0")]
		[Token(Token = "0x4001559")]
		[FieldOffset(Offset = "0x58")]
		public FsmString verticalAxis;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B3308", Offset = "0x7B3308")]
		[Token(Token = "0x400155A")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat multiplier;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B3340", Offset = "0x7B3340")]
		[Token(Token = "0x400155B")]
		[FieldOffset(Offset = "0x68")]
		public AxisPlane mapToPlane;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B338C", Offset = "0x7B338C")]
		[Token(Token = "0x400155C")]
		[FieldOffset(Offset = "0x70")]
		public FsmGameObject relativeTo;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B33C4", Offset = "0x7B33C4")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B33C4", Offset = "0x7B33C4")]
		[Token(Token = "0x400155D")]
		[FieldOffset(Offset = "0x78")]
		public FsmVector3 storeVector;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B3424", Offset = "0x7B3424")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B3424", Offset = "0x7B3424")]
		[Token(Token = "0x400155E")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat storeMagnitude;

		[Token(Token = "0x6000B21")]
		[Address(RVA = "0xB83320", Offset = "0xB83320", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EDB3B0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20229D2]) = v38;\nL_0017:\n\tv43 = HutongGames.PlayMaker.FsmString::op_Implicit(\"Horizontal\");\n\tthis.horizontalAxis = v43;\n\tv48 = HutongGames.PlayMaker.FsmString::op_Implicit(\"Vertical\");\n\tthis.verticalAxis = v48;\n\tv51 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.multiplier = v51;\n\tthis.mapToPlane = 0;\n\tthis.storeVector = 0;\n\tthis.storeMagnitude = 0;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmString fsmString = "Horizontal";
			horizontalAxis = fsmString;
			FsmString fsmString2 = "Vertical";
			verticalAxis = fsmString2;
			FsmFloat fsmFloat = 1f;
			multiplier = fsmFloat;
			mapToPlane = default(AxisPlane);
			storeVector = null;
			storeMagnitude = null;
		}

		[Token(Token = "0x6000B22")]
		[Address(RVA = "0xB833A8", Offset = "0xB833A8", Length = "0x440")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv28 = *([1EB6C80]);\n\tv29 = *([v28 @ X8_v47]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([20229D3]) = v48;\nL_0022:\n\tv58 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.relativeTo);\n\tgoto L_0034;\n\tv296 = *([v204 @ X8_v7+E0]);\n\tv297 = v296 == 0;\n\tv298 = ~v297;\n\tif (v298) goto L_0034;\n\tv304 = v204;\n\tv300 = \"il2cpp_codegen_runtime_class_init\"(v304, v57, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0034:\n\tv303 = UnityEngine.Object::op_Equality(v58, 0);\n\tv306 = v303 == 0;\n\tif (v306) goto L_0065;\n\tv370 = this.mapToPlane == 2;\n\tif (v370) goto L_00D0;\n\tv379 = this.mapToPlane == 1;\n\tif (v379) goto L_00E8;\n\tv390 = this.mapToPlane == 0;\n\tv391 = ~v390;\n\tif (v391) goto L_0100;\n\tgoto L_005D;\n\tv469 = *([v409 @ X0_v74+E0]);\n\tv470 = v469 == 0;\n\tv471 = ~v470;\n\tif (v471) goto L_005D;\n\tv473 = \"il2cpp_codegen_runtime_class_init\"(v409, v171, v166, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_005D:\n\tv406 = UnityEngine.Vector3::get_forward();\n\tv490 = v406.y;\n\tv489 = v406.z;\n\tgoto L_00F6;\nL_0065:\n\tv183 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.relativeTo);\n\tv445 = UnityEngine.GameObject::get_transform(v183);\n\tv449 = this.mapToPlane == 0;\n\tif (v449) goto L_00A7;\n\tv451 = this.mapToPlane - 1;\n\tv508 = v451 < 1;\n\tv270 = ~v508;\n\tv268 = v451 - 1;\n\tv264 = v268 == 0;\n\tv509 = ~v264;\n\tv245 = v270 & v509;\n\tif (v245) goto L_0100;\n\tgoto L_0088;\n\tv539 = *([v526 @ X0_v55+E0]);\n\tv540 = v539 == 0;\n\tv541 = ~v540;\n\tif (v541) goto L_0088;\n\tv543 = \"il2cpp_codegen_runtime_class_init\"(v526, v275, v166, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0088:\n\tv406 = UnityEngine.Vector3::get_up();\n\tv556 = 0x158A710(&v406 @ V0_v24 (UnityEngine.Vector3), 0, 0, v33, v34, v35, v36, v37, v406, v406.y, v406.z, v41, v42, v43, v44, v45);\n\tv406 = UnityEngine.Vector3::get_right();\n\tv406 = UnityEngine.Transform::TransformDirection(v445, v406);\n\tv429 = v406.y;\n\tv427 = v406.z;\n\tgoto L_FFFFFFFF;\nL_00A7:\n\tgoto L_00AE;\n\tv530 = *([v512 @ X0_v46+E0]);\n\tv531 = v530 == 0;\n\tv532 = ~v531;\n\tif (v532) goto L_00AE;\n\tv534 = \"il2cpp_codegen_runtime_class_init\"(v512, v275, v166, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_00AE:\n\tv406 = UnityEngine.Vector3::get_forward();\n\tv406 = UnityEngine.Transform::TransformDirection(v445, v406);\n\tv587 = 0x158A710(&v406 @ V0_v24 (UnityEngine.Vector3), 0, 0, v33, v34, v35, v36, v37, v406, v406.y, v406.z, v41, v42, v43, v44, v45);\n\tv417 = -v406;\n\tv446 = 0x1586898(&v107 @ stack_-70_v5 (UnityEngine.Vector3), 0, 0, v33, v34, v35, v36, v37, v406.z, 0, v417, v417, v42, v43, v44, v45);\n\tgoto L_0100;\nL_00D0:\n\tgoto L_00D7;\n\tv398 = *([v386 @ X0_v63+E0]);\n\tv399 = v398 == 0;\n\tv400 = ~v399;\n\tif (v400) goto L_00D7;\n\tv402 = \"il2cpp_codegen_runtime_class_init\"(v386, v171, v166, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_00D7:\n\tv406 = UnityEngine.Vector3::get_up();\n\tv406 = UnityEngine.Vector3::get_forward();\n\tv429 = v406.y;\n\tv427 = v406.z;\n\tgoto L_FFFFFFFF;\nL_00E8:\n\tgoto L_00EF;\n\tv453 = *([v394 @ X0_v70+E0]);\n\tv454 = v453 == 0;\n\tv455 = ~v454;\n\tif (v455) goto L_00EF;\n\tv457 = \"il2cpp_codegen_runtime_class_init\"(v394, v171, v166, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_00EF:\n\tv406 = UnityEngine.Vector3::get_up();\n\tv490 = v406.y;\n\tv489 = v406.z;\nL_00F6:\n\tv406 = UnityEngine.Vector3::get_right();\n\tv429 = v406.y;\n\tv427 = v406.z;\nL_0100:\n\tv478 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.horizontalAxis);\n\tv487 = v478 == 0;\n\tv488 = ~v487;\n\tif (v488) goto L_011D;\n\tv537 = HutongGames.PlayMaker.FsmString::get_Value(this.horizontalAxis);\n\tv521 = System.String::IsNullOrEmpty(v537);\n\tv561 = v521 == 0;\n\tv523 = ~v561;\n\tif (v523) goto L_011D;\n\tv520 = HutongGames.PlayMaker.FsmString::get_Value(this.horizontalAxis);\n\tv517 = UnityEngine.Input::GetAxis(v520);\nL_011D:\n\tv538 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.verticalAxis);\n\tv548 = v538 == 0;\n\tv549 = ~v548;\n\tif (v549) goto L_013F;\n\tv589 = HutongGames.PlayMaker.FsmString::get_Value(this.verticalAxis);\n\tv569 = System.String::IsNullOrEmpty(v589);\n\tv616 = v569 == 0;\n\tv571 = ~v616;\n\tif (v571) goto L_013F;\n\tv568 = HutongGames.PlayMaker.FsmString::get_Value(this.verticalAxis);\n\tv565 = UnityEngine.Input::GetAxis(v568);\nL_013F:\n\tgoto L_014A;\n\tv590 = *([v576 @ X0_v20+E0]);\n\tv591 = v590 == 0;\n\tv592 = ~v591;\n\tgoto L_014A;\n\tv594 = \"il2cpp_codegen_runtime_class_init\"(v576, v177, v166, v33, v34, v35, v36, v37, v564, v133, v129, v109, v42, v43, v44, v45);\nL_014A:\n\t// 330 MakeStruct v98 @ AGGB836F8_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v107 @ stack_-70_v5 (UnityEngine.Vector3), v429 @ V1_v3 (System.Single), v65 @ stack_-68_v5 (System.Single)\n\tv406 = UnityEngine.Vector3::op_Multiply(v104, v98);\n\t// 343 MakeStruct v89 @ AGGB8371C_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v124 @ stack_-60_v5 (UnityEngine.Vector3), v122 @ stack_-5C_v4 (System.Single), v119 @ stack_-58_v5 (System.Single)\n\tv406 = UnityEngine.Vector3::op_Multiply(v562, v89);\n\tv406 = UnityEngine.Vector3::op_Addition(v406, v406);\n\tv624 = HutongGames.PlayMaker.FsmFloat::get_Value(this.multiplier);\n\tv406 = UnityEngine.Vector3::op_Multiply(v406, v624);\n\tv207 = this.storeVector;\n\tv207.value = v406;\n\tv207.value.y = v406.y;\n\tv207.value.z = v406.z;\n\tv629 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.storeMagnitude);\n\tv631 = v629 == 0;\n\tv632 = ~v631;\n\tif (v632) goto L_019E;\n\tv288 = this.storeMagnitude;\n\tv281 = 0x158AD58(&v406 @ V0_v24 (UnityEngine.Vector3), 0, 0, v33, v34, v35, v36, v37, v406, v406.y, v406.z, v624, v406.y, v406.z, v44, v45);\n\tv288.value = v406;\nL_019E:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 275 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnUpdate()
		{
			//IL_0290: Unsupported input type for neg.
			//IL_0290: Unknown result type (might be due to invalid IL or missing references)
			//IL_0295: Expected O, but got Unknown
			GameObject value = relativeTo.Value;
			float z;
			Vector3 vector = default(Vector3);
			float z2;
			Vector3 vector2;
			float y2 = default(float);
			float z4;
			float y3 = default(float);
			Vector3 forward;
			if (value == null)
			{
				if (mapToPlane != AxisPlane.YZ)
				{
					float y;
					float z3;
					if (mapToPlane != AxisPlane.XY)
					{
						bool flag = mapToPlane == AxisPlane.XZ;
						bool flag2 = !flag;
						z = 0f;
						vector = default(Vector3);
						z2 = 0f;
						vector2 = default(Vector3);
						if (flag2)
						{
							goto IL_035e;
						}
						forward = Vector3.forward;
						y = forward.y;
						z3 = forward.z;
					}
					else
					{
						forward = Vector3.up;
						y = forward.y;
						z3 = forward.z;
					}
					forward = Vector3.right;
					y2 = forward.y;
					z4 = forward.z;
					z2 = z3;
					y3 = y;
					vector2 = forward;
				}
				else
				{
					forward = Vector3.up;
					forward = Vector3.forward;
					y2 = forward.y;
					z4 = forward.z;
					z2 = forward.z;
					y3 = forward.y;
					vector2 = forward;
				}
				goto IL_0693;
			}
			GameObject value2 = relativeTo.Value;
			Transform transform = value2.transform;
			if (mapToPlane != AxisPlane.XZ)
			{
				int num = (int)(mapToPlane - 1);
				bool flag3 = num < 1;
				bool flag4 = !flag3;
				int num2 = num - 1;
				bool flag5 = num2 == 0;
				bool flag6 = !flag5;
				bool flag7 = flag4 && flag6;
				z = 0f;
				vector = default(Vector3);
				z2 = 0f;
				vector2 = default(Vector3);
				if (!flag7)
				{
					forward = Vector3.up;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158A710 (inside UnityEngine.Vector3::get_zero +0x15C)");
					forward = Vector3.right;
					forward = transform.TransformDirection(forward);
					y2 = forward.y;
					z4 = forward.z;
					z2 = forward.z;
					y3 = forward.y;
					vector2 = forward;
					goto IL_0693;
				}
			}
			else
			{
				forward = Vector3.forward;
				forward = transform.TransformDirection(forward);
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158A710 (inside UnityEngine.Vector3::get_zero +0x15C)");
				object obj = 0 - forward;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
				z = 0f;
				z2 = forward.z;
				y3 = forward.y;
				vector2 = forward;
			}
			goto IL_035e;
			IL_035e:
			bool isNone = horizontalAxis.IsNone;
			bool flag8 = !isNone;
			bool flag9 = !flag8;
			float num3 = 0f;
			if (!flag9)
			{
				string value3 = horizontalAxis.Value;
				bool flag10 = string.IsNullOrEmpty(value3);
				bool flag11 = !flag10;
				bool flag12 = !flag11;
				num3 = 0f;
				if (!flag12)
				{
					string value4 = horizontalAxis.Value;
					float axis = Input.GetAxis(value4);
					num3 = axis;
				}
			}
			bool isNone2 = verticalAxis.IsNone;
			bool flag13 = !isNone2;
			bool flag14 = !flag13;
			float num4 = 0f;
			if (!flag14)
			{
				string value5 = verticalAxis.Value;
				bool flag15 = string.IsNullOrEmpty(value5);
				bool flag16 = !flag15;
				bool flag17 = !flag16;
				num4 = 0f;
				if (!flag17)
				{
					string value6 = verticalAxis.Value;
					float axis2 = Input.GetAxis(value6);
					num4 = axis2;
				}
			}
			Vector3 vector3 = default(Vector3);
			vector3.x = vector.x;
			vector3.y = y2;
			vector3.z = z;
			forward = num3 * vector3;
			Vector3 vector4 = default(Vector3);
			vector4.x = vector2.x;
			vector4.y = y3;
			vector4.z = z2;
			forward = num4 * vector4;
			forward += forward;
			float value7 = multiplier.Value;
			forward *= value7;
			FsmVector3 fsmVector = storeVector;
			fsmVector.value = forward;
			fsmVector.value.y = forward.y;
			fsmVector.value.z = forward.z;
			if (!storeMagnitude.IsNone)
			{
				FsmFloat fsmFloat = storeMagnitude;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158AD58 (inside UnityEngine.Vector3::ClampMagnitude +0xDC)");
				fsmFloat.Value = forward.x;
			}
			return;
			IL_0693:
			z = z4;
			vector = forward;
			goto IL_035e;
		}

		[Token(Token = "0x6000B23")]
		[Address(RVA = "0xB837E8", Offset = "0xB837E8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GetAxisVector()
		{
		}
	}
}
