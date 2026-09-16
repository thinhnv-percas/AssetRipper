using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[NoActionTargets]
	[Attribute(Type = typeof(ActionCategoryAttribute), RVA = "0x758164", Offset = "0x758164")]
	[Attribute(Type = typeof(TooltipAttribute), RVA = "0x758164", Offset = "0x758164")]
	[Token(Token = "0x2000249")]
	public class TransformInputToWorldSpace : FsmStateAction
	{
		[Token(Token = "0x200048D")]
		public enum AxisPlane
		{
			[Token(Token = "0x400217E")]
			XZ = 0,
			[Token(Token = "0x400217F")]
			XY = 1,
			[Token(Token = "0x4002180")]
			YZ = 2
		}

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B46DC", Offset = "0x7B46DC")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B46DC", Offset = "0x7B46DC")]
		[Token(Token = "0x40015B4")]
		[FieldOffset(Offset = "0x50")]
		public FsmFloat horizontalInput;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B472C", Offset = "0x7B472C")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B472C", Offset = "0x7B472C")]
		[Token(Token = "0x40015B5")]
		[FieldOffset(Offset = "0x58")]
		public FsmFloat verticalInput;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B477C", Offset = "0x7B477C")]
		[Token(Token = "0x40015B6")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat multiplier;

		[RequiredField]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B47B4", Offset = "0x7B47B4")]
		[Token(Token = "0x40015B7")]
		[FieldOffset(Offset = "0x68")]
		public AxisPlane mapToPlane;

		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B4800", Offset = "0x7B4800")]
		[Token(Token = "0x40015B8")]
		[FieldOffset(Offset = "0x70")]
		public FsmGameObject relativeTo;

		[RequiredField]
		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B4838", Offset = "0x7B4838")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B4838", Offset = "0x7B4838")]
		[Token(Token = "0x40015B9")]
		[FieldOffset(Offset = "0x78")]
		public FsmVector3 storeVector;

		[Attribute(Type = typeof(UIHintAttribute), RVA = "0x7B4898", Offset = "0x7B4898")]
		[Attribute(Type = typeof(TooltipAttribute), RVA = "0x7B4898", Offset = "0x7B4898")]
		[Token(Token = "0x40015BA")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat storeMagnitude;

		[Token(Token = "0x6000B76")]
		[Address(RVA = "0x9A0A70", Offset = "0x9A0A70", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.horizontalInput = 0;\n\tthis.verticalInput = 0;\n\tv12 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.multiplier = v12;\n\tthis.mapToPlane = 0;\n\tthis.storeVector = 0;\n\tthis.storeMagnitude = 0;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			horizontalInput = null;
			verticalInput = null;
			FsmFloat fsmFloat = 1f;
			multiplier = fsmFloat;
			mapToPlane = default(AxisPlane);
			storeVector = null;
			storeMagnitude = null;
		}

		[Token(Token = "0x6000B77")]
		[Address(RVA = "0x9A0AA8", Offset = "0x9A0AA8", Length = "0x3F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv28 = *([1EBCE50]);\n\tv29 = *([v28 @ X8_v47]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([20217CE]) = v48;\nL_0022:\n\tv58 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.relativeTo);\n\tgoto L_0034;\n\tv290 = *([v198 @ X8_v7+E0]);\n\tv291 = v290 == 0;\n\tv292 = ~v291;\n\tif (v292) goto L_0034;\n\tv298 = v198;\n\tv294 = \"il2cpp_codegen_runtime_class_init\"(v298, v57, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0034:\n\tv297 = UnityEngine.Object::op_Equality(v58, 0);\n\tv300 = v297 == 0;\n\tif (v300) goto L_0065;\n\tv364 = this.mapToPlane == 2;\n\tif (v364) goto L_00D0;\n\tv373 = this.mapToPlane == 1;\n\tif (v373) goto L_00E8;\n\tv384 = this.mapToPlane == 0;\n\tv385 = ~v384;\n\tif (v385) goto L_0100;\n\tgoto L_005D;\n\tv463 = *([v403 @ X0_v66+E0]);\n\tv464 = v463 == 0;\n\tv465 = ~v464;\n\tif (v465) goto L_005D;\n\tv467 = \"il2cpp_codegen_runtime_class_init\"(v403, v171, v166, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_005D:\n\tv400 = UnityEngine.Vector3::get_forward();\n\tv484 = v400.y;\n\tv483 = v400.z;\n\tgoto L_00F6;\nL_0065:\n\tv181 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.relativeTo);\n\tv439 = UnityEngine.GameObject::get_transform(v181);\n\tv443 = this.mapToPlane == 0;\n\tif (v443) goto L_00A7;\n\tv445 = this.mapToPlane - 1;\n\tv502 = v445 < 1;\n\tv264 = ~v502;\n\tv262 = v445 - 1;\n\tv258 = v262 == 0;\n\tv503 = ~v258;\n\tv239 = v264 & v503;\n\tif (v239) goto L_0100;\n\tgoto L_0088;\n\tv528 = *([v517 @ X0_v47+E0]);\n\tv529 = v528 == 0;\n\tv530 = ~v529;\n\tif (v530) goto L_0088;\n\tv532 = \"il2cpp_codegen_runtime_class_init\"(v517, v269, v166, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0088:\n\tv400 = UnityEngine.Vector3::get_up();\n\tv545 = 0x158A710(&v400 @ V0_v24 (UnityEngine.Vector3), 0, 0, v33, v34, v35, v36, v37, v400, v400.y, v400.z, v41, v42, v43, v44, v45);\n\tv400 = UnityEngine.Vector3::get_right();\n\tv400 = UnityEngine.Transform::TransformDirection(v439, v400);\n\tv423 = v400.y;\n\tv421 = v400.z;\n\tgoto L_FFFFFFFF;\nL_00A7:\n\tgoto L_00AE;\n\tv521 = *([v506 @ X0_v38+E0]);\n\tv522 = v521 == 0;\n\tv523 = ~v522;\n\tif (v523) goto L_00AE;\n\tv525 = \"il2cpp_codegen_runtime_class_init\"(v506, v269, v166, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_00AE:\n\tv400 = UnityEngine.Vector3::get_forward();\n\tv400 = UnityEngine.Transform::TransformDirection(v439, v400);\n\tv571 = 0x158A710(&v400 @ V0_v24 (UnityEngine.Vector3), 0, 0, v33, v34, v35, v36, v37, v400, v400.y, v400.z, v41, v42, v43, v44, v45);\n\tv411 = -v400;\n\tv440 = 0x1586898(&v107 @ stack_-70_v5 (UnityEngine.Vector3), 0, 0, v33, v34, v35, v36, v37, v400.z, 0, v411, v411, v42, v43, v44, v45);\n\tgoto L_0100;\nL_00D0:\n\tgoto L_00D7;\n\tv392 = *([v380 @ X0_v55+E0]);\n\tv393 = v392 == 0;\n\tv394 = ~v393;\n\tif (v394) goto L_00D7;\n\tv396 = \"il2cpp_codegen_runtime_class_init\"(v380, v171, v166, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_00D7:\n\tv400 = UnityEngine.Vector3::get_up();\n\tv400 = UnityEngine.Vector3::get_forward();\n\tv423 = v400.y;\n\tv421 = v400.z;\n\tgoto L_FFFFFFFF;\nL_00E8:\n\tgoto L_00EF;\n\tv447 = *([v388 @ X0_v62+E0]);\n\tv448 = v447 == 0;\n\tv449 = ~v448;\n\tif (v449) goto L_00EF;\n\tv451 = \"il2cpp_codegen_runtime_class_init\"(v388, v171, v166, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_00EF:\n\tv400 = UnityEngine.Vector3::get_up();\n\tv484 = v400.y;\n\tv483 = v400.z;\nL_00F6:\n\tv400 = UnityEngine.Vector3::get_right();\n\tv423 = v400.y;\n\tv421 = v400.z;\nL_0100:\n\tv472 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.horizontalInput);\n\tv481 = v472 == 0;\n\tv482 = ~v481;\n\tif (v482) goto L_0110;\n\tv511 = HutongGames.PlayMaker.FsmFloat::get_Value(this.horizontalInput);\nL_0110:\n\tv527 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.verticalInput);\n\tv537 = v527 == 0;\n\tv538 = ~v537;\n\tif (v538) goto L_0125;\n\tv552 = HutongGames.PlayMaker.FsmFloat::get_Value(this.verticalInput);\nL_0125:\n\tgoto L_0130;\n\tv572 = *([v560 @ X0_v20+E0]);\n\tv573 = v572 == 0;\n\tv574 = ~v573;\n\tgoto L_0130;\n\tv576 = \"il2cpp_codegen_runtime_class_init\"(v560, v175, v166, v33, v34, v35, v36, v37, v551, v133, v129, v109, v42, v43, v44, v45);\nL_0130:\n\t// 304 MakeStruct v98 @ AGG9A0DB0_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v107 @ stack_-70_v5 (UnityEngine.Vector3), v423 @ V1_v3 (System.Single), v65 @ stack_-68_v5 (System.Single)\n\tv400 = UnityEngine.Vector3::op_Multiply(v104, v98);\n\t// 317 MakeStruct v89 @ AGG9A0DD4_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v124 @ stack_-60_v5 (UnityEngine.Vector3), v122 @ stack_-5C_v4 (System.Single), v119 @ stack_-58_v5 (System.Single)\n\tv400 = UnityEngine.Vector3::op_Multiply(v549, v89);\n\tv400 = UnityEngine.Vector3::op_Addition(v400, v400);\n\tv602 = HutongGames.PlayMaker.FsmFloat::get_Value(this.multiplier);\n\tv400 = UnityEngine.Vector3::op_Multiply(v400, v602);\n\tv201 = this.storeVector;\n\tv201.value = v400;\n\tv201.value.y = v400.y;\n\tv201.value.z = v400.z;\n\tv607 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.storeMagnitude);\n\tv609 = v607 == 0;\n\tv610 = ~v609;\n\tif (v610) goto L_0184;\n\tv282 = this.storeMagnitude;\n\tv275 = 0x158AD58(&v400 @ V0_v24 (UnityEngine.Vector3), 0, 0, v33, v34, v35, v36, v37, v400, v400.y, v400.z, v602, v400.y, v400.z, v44, v45);\n\tv282.value = v400;\nL_0184:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 261 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
				goto IL_05cb;
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
					goto IL_05cb;
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
			bool isNone = horizontalInput.IsNone;
			bool flag8 = !isNone;
			bool flag9 = !flag8;
			float num3 = 0f;
			if (!flag9)
			{
				float value3 = horizontalInput.Value;
				num3 = value3;
			}
			bool isNone2 = verticalInput.IsNone;
			bool flag10 = !isNone2;
			bool flag11 = !flag10;
			float num4 = 0f;
			if (!flag11)
			{
				float value4 = verticalInput.Value;
				num4 = value4;
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
			float value5 = multiplier.Value;
			forward *= value5;
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
			IL_05cb:
			z = z4;
			vector = forward;
			goto IL_035e;
		}

		[Token(Token = "0x6000B78")]
		[Address(RVA = "0x9A0EA0", Offset = "0x9A0EA0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public TransformInputToWorldSpace()
		{
		}
	}
}
