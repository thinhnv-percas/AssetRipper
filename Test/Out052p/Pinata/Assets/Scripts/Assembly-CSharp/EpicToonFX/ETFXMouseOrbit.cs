using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace EpicToonFX
{
	[Token(Token = "0x2000064")]
	public class ETFXMouseOrbit : MonoBehaviour
	{
		[Token(Token = "0x400029C")]
		[FieldOffset(Offset = "0x18")]
		public Transform target;

		[Token(Token = "0x400029D")]
		[FieldOffset(Offset = "0x20")]
		public float distance;

		[Token(Token = "0x400029E")]
		[FieldOffset(Offset = "0x24")]
		public float xSpeed;

		[Token(Token = "0x400029F")]
		[FieldOffset(Offset = "0x28")]
		public float ySpeed;

		[Token(Token = "0x40002A0")]
		[FieldOffset(Offset = "0x2C")]
		public float yMinLimit;

		[Token(Token = "0x40002A1")]
		[FieldOffset(Offset = "0x30")]
		public float yMaxLimit;

		[Token(Token = "0x40002A2")]
		[FieldOffset(Offset = "0x34")]
		public float distanceMin;

		[Token(Token = "0x40002A3")]
		[FieldOffset(Offset = "0x38")]
		public float distanceMax;

		[Token(Token = "0x40002A4")]
		[FieldOffset(Offset = "0x3C")]
		public float smoothTime;

		[Token(Token = "0x40002A5")]
		[FieldOffset(Offset = "0x40")]
		private float rotationYAxis;

		[Token(Token = "0x40002A6")]
		[FieldOffset(Offset = "0x44")]
		private float rotationXAxis;

		[Token(Token = "0x40002A7")]
		[FieldOffset(Offset = "0x48")]
		private float velocityX;

		[Token(Token = "0x40002A8")]
		[FieldOffset(Offset = "0x4C")]
		private float velocityY;

		[Token(Token = "0x60002AE")]
		[Address(RVA = "0xA05378", Offset = "0xA05378", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1EAC800]);\n\tv21 = *([v20 @ X8_v9]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021C8B]) = v40;\nL_0016:\n\tv43 = UnityEngine.Component::get_transform(this);\n\tv46 = UnityEngine.Transform::get_eulerAngles(v43);\n\tthis.rotationYAxis = v46.y;\n\tthis.rotationXAxis = v46;\n\tv71 = UnityEngine.Component::GetComponent(this);\n\tgoto L_0034;\n\tv106 = *([v64 @ X8_v6+E0]);\n\tv107 = v106 == 0;\n\tv108 = ~v107;\n\tif (v108) goto L_0034;\n\tv113 = v64;\n\tv110 = \"il2cpp_codegen_runtime_class_init\"(v113, v70, v24, v25, v26, v27, v28, v29, v46, v55, v53, v33, v34, v35, v36, v37);\nL_0034:\n\tv93 = UnityEngine.Object::op_Implicit(v71);\n\tv95 = v93 == 0;\n\tif (v95) goto L_004D;\n\tv60 = UnityEngine.Component::GetComponent(this);\n\tUnityEngine.Rigidbody::set_freezeRotation(v60, 1);\n\treturn;\nL_004D:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			Transform transform = base.transform;
			Vector3 eulerAngles = transform.eulerAngles;
			rotationYAxis = eulerAngles.y;
			rotationXAxis = eulerAngles.x;
			Rigidbody component = GetComponent<Rigidbody>();
			if ((bool)component)
			{
				Rigidbody component2 = GetComponent<Rigidbody>();
				component2.freezeRotation = true;
			}
		}

		[Token(Token = "0x60002AF")]
		[Address(RVA = "0xA05454", Offset = "0xA05454", Length = "0x400")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = &v27 @ stack_-10_v2;\n\tgoto L_0021;\n\tv36 = *([1ED5518]);\n\tv37 = *([v36 @ X8_v37]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2021C8C]) = v56;\nL_0021:\n\tv62 = 0;\n\tgoto L_0032;\n\tv71 = *([v65 @ X0_v2+E0]);\n\tv72 = v71 == 0;\n\tv73 = ~v72;\n\tgoto L_0032;\n\tv75 = \"il2cpp_codegen_runtime_class_init\"(v65, methodInfo, v40, v41, v42, v43, v44, v45, v61, v47, v48, v49, v50, v51, v52, v53);\nL_0032:\n\tv80 = UnityEngine.Object::op_Implicit(this.target);\n\tv82 = v80 == 0;\n\tif (v82) goto L_014E;\n\tv85 = UnityEngine.Input::GetMouseButton(1);\n\tv168 = v85 == 0;\n\tif (v168) goto L_0057;\n\tv234 = UnityEngine.Input::GetAxis(\"Mouse X\");\n\tv238 = this.xSpeed * v234;\n\tv240 = v238 * this.distance;\n\tv243 = v240 * 0.02f;\n\tv244 = this.velocityX + v243;\n\tthis.velocityX = v244;\n\tv249 = UnityEngine.Input::GetAxis(\"Mouse Y\");\n\tv268 = this.ySpeed * v249;\n\tv269 = v268 * 0.02f;\n\tv253 = this.velocityY + v269;\n\tthis.velocityY = v253;\n\tgoto L_005D;\nL_0057:\n\tv253 = this.velocityY;\nL_005D:\n\tv265 = this.rotationXAxis - v253;\n\tv266 = this.rotationYAxis + this.velocityX;\n\tthis.rotationYAxis = v266;\n\tthis.rotationXAxis = v265;\n\tv267 = EpicToonFX.ETFXMouseOrbit::ClampAngle(v265, this.yMinLimit, this.yMaxLimit);\n\tthis.rotationXAxis = v267;\n\tgoto L_0075;\n\tv277 = *([v273 @ X0_v10+E0]);\n\tv278 = v277 == 0;\n\tv279 = ~v278;\n\tgoto L_0075;\n\tv281 = \"il2cpp_codegen_runtime_class_init\"(v273, v257, v40, v41, v42, v43, v44, v45, v267, v263, v264, v266, v262, v260, v52, v53);\nL_0075:\n\tv288 = UnityEngine.Quaternion::Euler(v267, this.rotationYAxis, 0f);\n\t*([v26 @ X29_v1-18]) = v288.z;\n\t*([v26 @ X29_v1-14]) = v288.y;\n\tv298 = UnityEngine.Input::GetAxis(\"Mouse ScrollWheel\");\n\tgoto L_0093;\n\tv307 = *([v303 @ X0_v14+E0]);\n\tv308 = v307 == 0;\n\tv309 = ~v308;\n\tif (v309) goto L_0093;\n\tv311 = \"il2cpp_codegen_runtime_class_init\"(v303, v295, v40, v41, v42, v43, v44, v45, v298, v289, v290, v291, v262, v260, v52, v53);\nL_0093:\n\tv315 = v298 * -5f;\n\tv316 = this.distance + v315;\n\tv320 = UnityEngine.Mathf::Clamp(v316, this.distanceMin, this.distanceMax);\n\tthis.distance = v320;\n\tv324 = UnityEngine.Transform::get_position(this.target);\n\tv355 = UnityEngine.Component::get_transform(this);\n\tv367 = UnityEngine.Transform::get_position(v355);\n\tv378 = UnityEngine.Physics::Linecast(v324, v367, &v62 @ stack_-A0_v1 (UnityEngine.RaycastHit));\n\tv385 = this.distance;\n\tv381 = v378 == 0;\n\tif (v381) goto L_00C1;\n\tv384 = 0x164C890(&v62 @ stack_-A0_v1 (UnityEngine.RaycastHit), 0, v40, v41, v42, v43, v44, v45, v324, v324.y, v324.z, v367, v367.y, v367.z, v52, v53);\n\tv385 = v385 - v324;\n\tthis.distance = v385;\nL_00C1:\n\tv389 = -v385;\n\tv393 = 0x1586898(&v87 @ stack_-B0_v4, 0, v40, v41, v42, v43, v44, v45, 0, 0, v389, v367, v367.y, v367.z, v52, v53);\n\tgoto L_00DD;\n\tv401 = *([v394 @ X0_v27+E0]);\n\tv402 = v401 == 0;\n\tv403 = ~v402;\n\tgoto L_00DD;\n\tv405 = \"il2cpp_codegen_runtime_class_init\"(v394, v351, v40, v41, v42, v43, v44, v45, v391, v392, v389, v370, v371, v372, v52, v53);\nL_00DD:\n\t// 221 MakeStruct v104 @ AGGA05700_0_v3 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v288 @ V0_v7 (UnityEngine.Quaternion), [v26 @ X29_v1-14], [v26 @ X29_v1-18], v288.w (System.Single)\n\t// 222 MakeStruct v101 @ AGGA05700_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v87 @ stack_-B0_v4, v396 @ stack_-AC, 0\n\tv344 = UnityEngine.Quaternion::op_Multiply(v104, v101);\n\tv412 = UnityEngine.Transform::get_position(this.target);\n\tgoto L_0104;\n\tv421 = *([v417 @ X0_v31+E0]);\n\tv422 = v421 == 0;\n\tv423 = ~v422;\n\tif (v423) goto L_0104;\n\tv425 = \"il2cpp_codegen_runtime_class_init\"(v417, v411, v40, v41, v42, v43, v44, v45, v412, v413, v414, v333, v326, v325, v107, v53);\nL_0104:\n\tv345 = UnityEngine.Vector3::op_Addition(v344, v412);\n\tv357 = UnityEngine.Component::get_transform(this);\n\t// 276 MakeStruct v92 @ AGGA05798_1_v3 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), v288 @ V0_v7 (UnityEngine.Quaternion), [v26 @ X29_v1-14], [v26 @ X29_v1-18], v288.w (System.Single)\n\tUnityEngine.Transform::set_rotation(v357, v92);\n\tv358 = UnityEngine.Component::get_transform(this);\n\tUnityEngine.Transform::set_position(v358, v345);\n\tv439 = UnityEngine.Time::get_deltaTime();\n\tgoto L_0130;\n\tv444 = *([v440 @ X0_v39+E0]);\n\tv445 = v444 == 0;\n\tv446 = ~v445;\n\tif (v446) goto L_0130;\n\tv448 = \"il2cpp_codegen_runtime_class_init\"(v440, v145, v40, v41, v42, v43, v44, v45, v439, v435, v436, v127, v117, v115, v107, v53);\nL_0130:\n\tv449 = v439 * this.smoothTime;\n\tv453 = UnityEngine.Mathf::Lerp(this.velocityX, 0f, v449);\n\tthis.velocityX = v453;\n\tv455 = UnityEngine.Time::get_deltaTime();\n\tv129 = v455 * this.smoothTime;\n\tv139 = UnityEngine.Mathf::Lerp(this.velocityY, 0f, v129);\n\tthis.velocityY = v139;\nL_014E:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 227 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void LateUpdate()
		{
			//IL_0117: Expected I4, but got O
			//IL_048d: Expected O, but got F4
			//IL_0278: Expected F4, but got I
			//IL_028d: Expected F4, but got I
			//IL_02ac: Expected F4, but got O
			//IL_02b9: Expected F4, but got O
			//IL_0338: Expected F4, but got I
			//IL_034d: Expected F4, but got I
			object obj2 = default(object);
			object obj = obj2;
			RaycastHit hitInfo = default(RaycastHit);
			if ((bool)target)
			{
				float num7;
				if (Input.GetMouseButton(1))
				{
					float axis = Input.GetAxis("Mouse X");
					float num = xSpeed * axis;
					float num2 = num * distance;
					float num3 = num2 * 0.02f;
					float num4 = velocityX + num3;
					velocityX = num4;
					float axis2 = Input.GetAxis("Mouse Y");
					float num5 = ySpeed * axis2;
					float num6 = num5 * 0.02f;
					num7 = (velocityY += num6);
					bool flag = (byte)(int)"Mouse Y" != 0;
				}
				else
				{
					num7 = velocityY;
				}
				float angle = rotationXAxis - num7;
				float num8 = rotationYAxis + velocityX;
				rotationYAxis = num8;
				rotationXAxis = angle;
				Quaternion quaternion = Quaternion.Euler(rotationXAxis = ClampAngle(angle, yMinLimit, yMaxLimit), rotationYAxis, 0f);
				_ = quaternion.z;
				_ = quaternion.y;
				float axis3 = Input.GetAxis("Mouse ScrollWheel");
				float num9 = axis3 * -5f;
				float value = distance + num9;
				float num10 = Mathf.Clamp(value, distanceMin, distanceMax);
				distance = num10;
				Vector3 position = target.position;
				Transform transform = base.transform;
				Vector3 position2 = transform.position;
				bool flag2 = Physics.Linecast(position, position2, out hitInfo);
				float num11 = distance;
				if (flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @164C890 (inside UnityEngine.PhysicsScene::Internal_SphereCast +0x218)");
					num11 = (distance = num11 - position.x);
				}
				object obj3 = 0f - num11;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
				Quaternion quaternion2 = default(Quaternion);
				quaternion2.x = quaternion.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ X29_v1-14]");
				quaternion2.y = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ X29_v1-18]");
				quaternion2.z = 0f;
				quaternion2.w = quaternion.w;
				Vector3 vector = default(Vector3);
				object obj4 = default(object);
				vector.x = (float)obj4;
				object obj5 = default(object);
				vector.y = (float)obj5;
				vector.z = 0f;
				Vector3 vector2 = quaternion2 * vector;
				Vector3 position3 = target.position;
				Vector3 position4 = vector2 + position3;
				Transform transform2 = base.transform;
				Quaternion rotation = default(Quaternion);
				rotation.x = quaternion.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ X29_v1-14]");
				rotation.y = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ X29_v1-18]");
				rotation.z = 0f;
				rotation.w = quaternion.w;
				transform2.rotation = rotation;
				Transform transform3 = base.transform;
				transform3.position = position4;
				float deltaTime = Time.deltaTime;
				float t = deltaTime * smoothTime;
				float num12 = Mathf.Lerp(velocityX, 0f, t);
				velocityX = num12;
				float deltaTime2 = Time.deltaTime;
				float t2 = deltaTime2 * smoothTime;
				float num13 = Mathf.Lerp(velocityY, 0f, t2);
				velocityY = num13;
			}
		}

		[Token(Token = "0x60002B0")]
		[Address(RVA = "0xA05854", Offset = "0xA05854", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv26 = *([1EFFED8]);\n\tv27 = *([v26 @ X8_v8]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, v29, v30, v31, v32, v33, v34, v35, angle, min, max, v36, v37, v38, v39, v40);\n\tv44 = 0 | 1;\n\t*([2021C8D]) = v44;\nL_001E:\n\tv66 = angle + 360f;\n\tv63 = angle >= -360f;\n\tif (v63) goto L_FFFFFFFF;\n\tgoto L_002F;\nL_002F:\n\tv67 = v66 + -360f;\n\tv70 = v66 - 360f;\n\tv71 = v70 < 0;\n\tv72 = v70 == 0;\n\tv73 = v66 ^ 360f;\n\tv74 = v66 ^ v70;\n\tv75 = v73 & v74;\n\tv76 = v75 < 0;\n\tv77 = v71 == v76;\n\tv78 = ~v72;\n\tv79 = v77 & v78;\n\tv80 = ~v79;\n\tif (v80) goto L_FFFFFFFF;\n\tgoto L_0044;\nL_0044:\n\tgoto L_0055;\n\tv86 = *([v51 @ X0_v2+E0]);\n\tv87 = v86 == 0;\n\tv88 = ~v87;\n\tgoto L_0055;\n\tv90 = \"il2cpp_codegen_runtime_class_init\"(v51, v29, v30, v31, v32, v33, v34, v35, v49, v67, v66, v36, v37, v38, v39, v40);\nL_0055:\n\treturnVal1 = UnityEngine.Mathf::Clamp(v83, min, max);\n\treturn returnVal1;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float ClampAngle(float angle, float min, float max)
		{
			//IL_00cd: Expected O, but got F4
			//IL_00da: Expected O, but got F4
			float num = angle + 360f;
			if (!(angle < -360f))
			{
				num = angle;
			}
			float num2 = num + -360f;
			float num3 = num - 360f;
			bool flag = num3 < 0f;
			bool flag2 = num3 == 0f;
			object obj = num ^ 360f;
			object obj2 = num ^ num3;
			int num4 = (int)((long)(IntPtr)obj & (long)(IntPtr)obj2);
			bool flag3 = num4 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			float value = ((!(flag4 && flag5)) ? num : num2);
			return Mathf.Clamp(value, min, max);
		}

		[Token(Token = "0x60002B1")]
		[Address(RVA = "0xA05904", Offset = "0xA05904", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.distance = *([18186A0]);\n\tthis.yMaxLimit = *([18186B0]);\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ETFXMouseOrbit()
		{
			//IL_0018: Expected F4, but got I
			//IL_002a: Expected F4, but got I
			base._002Ector();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18186A0]");
			distance = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18186B0]");
			yMaxLimit = 0f;
		}
	}
}
