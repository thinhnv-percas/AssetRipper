using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x757F18", Offset = "0x757F18")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x757F18", Offset = "0x757F18")]
	[Token(Token = "0x2000243")]
	public class MouseLook : FsmStateAction
	{
		[Token(Token = "0x200048B")]
		public enum RotationAxes
		{
			[Token(Token = "0x4002176")]
			MouseXAndY = 0,
			[Token(Token = "0x4002177")]
			MouseX = 1,
			[Token(Token = "0x4002178")]
			MouseY = 2
		}

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B3B68", Offset = "0x7B3B68")]
		[Token(Token = "0x400157F")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B3BB4", Offset = "0x7B3BB4")]
		[Token(Token = "0x4001580")]
		[FieldOffset(Offset = "0x58")]
		public RotationAxes axes;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B3BEC", Offset = "0x7B3BEC")]
		[Token(Token = "0x4001581")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat sensitivityX;

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B3C38", Offset = "0x7B3C38")]
		[Token(Token = "0x4001582")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat sensitivityY;

		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7B3C84", Offset = "0x7B3C84")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B3C84", Offset = "0x7B3C84")]
		[Token(Token = "0x4001583")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat minimumX;

		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7B3CE0", Offset = "0x7B3CE0")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B3CE0", Offset = "0x7B3CE0")]
		[Token(Token = "0x4001584")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat maximumX;

		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7B3D3C", Offset = "0x7B3D3C")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B3D3C", Offset = "0x7B3D3C")]
		[Token(Token = "0x4001585")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat minimumY;

		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7B3D98", Offset = "0x7B3D98")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B3D98", Offset = "0x7B3D98")]
		[Token(Token = "0x4001586")]
		[FieldOffset(Offset = "0x88")]
		public FsmFloat maximumY;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B3DF4", Offset = "0x7B3DF4")]
		[Token(Token = "0x4001587")]
		[FieldOffset(Offset = "0x90")]
		public bool everyFrame;

		[Token(Token = "0x4001588")]
		[FieldOffset(Offset = "0x94")]
		private float rotationX;

		[Token(Token = "0x4001589")]
		[FieldOffset(Offset = "0x98")]
		private float rotationY;

		[Token(Token = "0x6000B52")]
		[Address(RVA = "0xA3BF88", Offset = "0xA3BF88", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1F0F558]);\n\tv25 = *([v24 @ X8_v7]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021E51]) = v44;\nL_0019:\n\tthis.gameObject = 0;\n\tthis.axes = 0;\n\tv48 = HutongGames.PlayMaker.FsmFloat::op_Implicit(15f);\n\tthis.sensitivityX = v48;\n\tv51 = HutongGames.PlayMaker.FsmFloat::op_Implicit(15f);\n\tthis.sensitivityY = v51;\n\tv55 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v55);\n\tv55.useVariable = 1;\n\tthis.minimumX = v55;\n\tv61 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v61);\n\tv61.useVariable = 1;\n\tthis.maximumX = v61;\n\tv97 = HutongGames.PlayMaker.FsmFloat::op_Implicit(-60f);\n\tthis.minimumY = v97;\n\tv84 = HutongGames.PlayMaker.FsmFloat::op_Implicit(60f);\n\tthis.maximumY = v84;\n\tthis.everyFrame = 1;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			axes = default(RotationAxes);
			FsmFloat fsmFloat = 15f;
			sensitivityX = fsmFloat;
			FsmFloat fsmFloat2 = 15f;
			sensitivityY = fsmFloat2;
			FsmFloat fsmFloat3 = new FsmFloat();
			fsmFloat3.useVariable = true;
			minimumX = fsmFloat3;
			FsmFloat fsmFloat4 = new FsmFloat();
			fsmFloat4.useVariable = true;
			maximumX = fsmFloat4;
			FsmFloat fsmFloat5 = -60f;
			minimumY = fsmFloat5;
			FsmFloat fsmFloat6 = 60f;
			maximumY = fsmFloat6;
			everyFrame = true;
		}

		[Token(Token = "0x6000B53")]
		[Address(RVA = "0xA3C084", Offset = "0xA3C084", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv20 = *([1EE1170]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021E52]) = v40;\nL_001B:\n\tv47 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002D;\n\tv120 = *([v89 @ X8_v5+E0]);\n\tv121 = v120 == 0;\n\tv122 = ~v121;\n\tif (v122) goto L_002D;\n\tv127 = v89;\n\tv124 = \"il2cpp_codegen_runtime_class_init\"(v127, v45, v46, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002D:\n\tv111 = UnityEngine.Object::op_Equality(v47, 0);\n\tv129 = v111 == 0;\n\tv130 = ~v129;\n\tif (v130) goto L_007E;\n\tv202 = UnityEngine.GameObject::GetComponent(v47);\n\tgoto L_0048;\n\tv207 = *([v83 @ X8_v10+E0]);\n\tv208 = v207 == 0;\n\tv209 = ~v208;\n\tif (v209) goto L_0048;\n\tv214 = v83;\n\tv211 = \"il2cpp_codegen_runtime_class_init\"(v214, v201, v105, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0048:\n\tv112 = UnityEngine.Object::op_Inequality(v202, 0);\n\tv216 = v112 == 0;\n\tif (v216) goto L_0054;\n\tUnityEngine.Rigidbody::set_freezeRotation(v202, 1);\nL_0054:\n\tv77 = UnityEngine.GameObject::get_transform(v47);\n\tv65 = UnityEngine.Transform::get_localRotation(v77);\n\tv227 = 0x10CC508(&v65 @ V0_v5 (UnityEngine.Quaternion), 0, v72, v25, v26, v27, v28, v29, v65, v65.y, v65.z, v65.w, v34, v35, v36, v37);\n\tthis.rotationX = v65.y;\n\tv78 = UnityEngine.GameObject::get_transform(v47);\n\tv65 = UnityEngine.Transform::get_localRotation(v78);\n\tv231 = 0x10CC508(&v65 @ V0_v5 (UnityEngine.Quaternion), 0, v72, v25, v26, v27, v28, v29, v65, v65.y, v65.z, v65.w, v34, v35, v36, v37);\n\tthis.rotationY = v65;\n\tHutongGames.PlayMaker.Actions.MouseLook::DoMouseLook(this);\n\tv232 = ~this.everyFrame;\n\tv193 = ~v232;\n\tif (v193) goto L_0085;\nL_007E:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\nL_0085:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 91 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			//IL_008d: Expected O, but got I4
			//IL_00b2: Expected O, but got I4
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null))
			{
				Rigidbody component = ownerDefaultTarget.GetComponent<Rigidbody>();
				bool flag = component != null;
				bool flag2 = !flag;
				object obj = 0;
				if (!flag2)
				{
					component.freezeRotation = true;
					obj = 0;
				}
				Transform transform = ownerDefaultTarget.transform;
				Quaternion localRotation = transform.localRotation;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CC508 (inside UnityEngine.Quaternion::Internal_MakePositive +0x9C)");
				rotationX = localRotation.y;
				Transform transform2 = ownerDefaultTarget.transform;
				localRotation = transform2.localRotation;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CC508 (inside UnityEngine.Quaternion::Internal_MakePositive +0x9C)");
				rotationY = localRotation.x;
				DoMouseLook();
				if (everyFrame)
				{
					return;
				}
			}
			Finish();
		}

		[Token(Token = "0x6000B54")]
		[Address(RVA = "0xA3C3A8", Offset = "0xA3C3A8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.MouseLook::DoMouseLook(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoMouseLook();
		}

		[Token(Token = "0x6000B55")]
		[Address(RVA = "0xA3C210", Offset = "0xA3C210", Length = "0x198")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EC00F0]);\n\tv21 = *([v20 @ X8_v11]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021E53]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv127 = *([v50 @ X8_v6+E0]);\n\tv128 = v127 == 0;\n\tv129 = ~v128;\n\tif (v129) goto L_002B;\n\tv134 = v50;\n\tv131 = \"il2cpp_codegen_runtime_class_init\"(v134, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv112 = UnityEngine.Object::op_Equality(v45, 0);\n\tv136 = v112 == 0;\n\tv137 = ~v136;\n\tif (v137) goto L_008E;\n\tv115 = UnityEngine.GameObject::get_transform(v45);\n\tv89 = this.axes == 2;\n\tif (v89) goto L_0060;\n\tv88 = this.axes == 1;\n\tif (v88) goto L_0073;\n\tv211 = this.axes == 0;\n\tv206 = ~v211;\n\tif (v206) goto L_008E;\n\tv213 = HutongGames.PlayMaker.Actions.MouseLook::GetYRotation(this);\n\tv221 = HutongGames.PlayMaker.Actions.MouseLook::GetXRotation(this);\n\tv231 = 0;\n\tv113 = 0x1586898(&v231 @ stack_-40_v5, 0, 0, v25, v26, v27, v28, v29, v213, v221, 0, v33, v34, v35, v36, v37);\n\tv261 = v115 == 0;\n\tv118 = ~v261;\n\tif (v118) goto L_0086;\n\tgoto L_0091;\nL_0060:\n\tv69 = HutongGames.PlayMaker.Actions.MouseLook::GetYRotation(this);\n\tv219 = UnityEngine.Transform::get_localEulerAngles(v115);\n\tv245 = v219.y;\n\tv247 = -v69;\n\tv231 = 0;\n\tgoto L_0080;\nL_0073:\n\tv247 = UnityEngine.Transform::get_localEulerAngles(v115);\n\tv226 = HutongGames.PlayMaker.Actions.MouseLook::GetXRotation(this);\nL_0080:\n\tv260 = 0x1586898(v257, 0, 0, v25, v26, v27, v28, v29, v247, v245, v244, v33, v34, v35, v36, v37);\nL_0086:\n\t// 134 MakeStruct v187 @ AGGA3C384_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v231 @ stack_-40_v5, v267 @ stack_-3C, v189 @ stack_-38_v4 (System.Int32)\n\tUnityEngine.Transform::set_localEulerAngles(v115, v187);\nL_008E:\n\treturn;\n\tthrow System.NullReferenceException;\nL_0091:\n\tthrow System.NullReferenceException;\n// 99 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoMouseLook()
		{
			//IL_016c: Expected O, but got F4
			//IL_0175: Expected O, but got I4
			//IL_017e: Expected O, but got I4
			//IL_01ed: Expected F4, but got O
			//IL_01fa: Expected F4, but got O
			//IL_00ec: Expected O, but got I4
			//IL_011e: Expected O, but got I4
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget == null)
			{
				return;
			}
			Transform transform = ownerDefaultTarget.transform;
			int num;
			object obj = default(object);
			if (axes != RotationAxes.MouseY)
			{
				if (axes != RotationAxes.MouseX)
				{
					if (axes == RotationAxes.MouseXAndY)
					{
						float yRotation = GetYRotation();
						float xRotation = GetXRotation();
						obj = 0;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
						bool flag = (object)transform == null;
						bool flag2 = !flag;
						obj = 0;
						num = 0;
						if (!flag2)
						{
							throw new NullReferenceException();
						}
						goto IL_01e0;
					}
					return;
				}
				Vector3 localEulerAngles = transform.localEulerAngles;
				float xRotation2 = GetXRotation();
				num = 0;
				int num2 = 0;
				float num3 = xRotation2;
				object obj2 = obj;
			}
			else
			{
				float yRotation2 = GetYRotation();
				float num3 = transform.localEulerAngles.y;
				Vector3 localEulerAngles = (Vector3)(0f - yRotation2);
				obj = 0;
				obj = 0;
				num = 0;
				int num2 = 0;
				object obj2 = obj;
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			goto IL_01e0;
			IL_01e0:
			Vector3 localEulerAngles2 = default(Vector3);
			localEulerAngles2.x = (float)obj;
			object obj3 = default(object);
			localEulerAngles2.y = (float)obj3;
			localEulerAngles2.z = num;
			transform.localEulerAngles = localEulerAngles2;
		}

		[Token(Token = "0x6000B56")]
		[Address(RVA = "0xA3C43C", Offset = "0xA3C43C", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1ED0638]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021E54]) = v42;\nL_001A:\n\treturnVal1 = UnityEngine.Input::GetAxis(\"Mouse X\");\n\tv53 = HutongGames.PlayMaker.FsmFloat::get_Value(this.sensitivityX);\n\tv57 = returnVal1 * v53;\n\tv58 = this.rotationX + v57;\n\tthis.rotationX = v58;\n\treturnVal2 = HutongGames.PlayMaker.Actions.MouseLook::ClampAngle(v58, this.minimumX, this.maximumX);\n\tthis.rotationX = returnVal2;\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private float GetXRotation()
		{
			float axis = Input.GetAxis("Mouse X");
			float value = sensitivityX.Value;
			float num = axis * value;
			return rotationX = ClampAngle(rotationX += num, minimumX, maximumX);
		}

		[Token(Token = "0x6000B57")]
		[Address(RVA = "0xA3C3AC", Offset = "0xA3C3AC", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EB6050]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021E55]) = v42;\nL_001A:\n\treturnVal1 = UnityEngine.Input::GetAxis(\"Mouse Y\");\n\tv53 = HutongGames.PlayMaker.FsmFloat::get_Value(this.sensitivityY);\n\tv57 = returnVal1 * v53;\n\tv58 = this.rotationY + v57;\n\tthis.rotationY = v58;\n\treturnVal2 = HutongGames.PlayMaker.Actions.MouseLook::ClampAngle(v58, this.minimumY, this.maximumY);\n\tthis.rotationY = returnVal2;\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private float GetYRotation()
		{
			float axis = Input.GetAxis("Mouse Y");
			float value = sensitivityY.Value;
			float num = axis * value;
			return rotationY = ClampAngle(rotationY += num, minimumY, maximumY);
		}

		[Token(Token = "0x6000B58")]
		[Address(RVA = "0xA3C4CC", Offset = "0xA3C4CC", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = HutongGames.PlayMaker.NamedVariable::get_IsNone(min);\n\tv37 = v21 == 0;\n\tv38 = ~v37;\n\tif (v38) goto L_002B;\n\tv80 = HutongGames.PlayMaker.FsmFloat::get_Value(min);\n\tv81 = v80 <= angle;\n\tif (v81) goto L_002B;\n\tv90 = HutongGames.PlayMaker.FsmFloat::get_Value(min);\nL_002B:\n\tv99 = HutongGames.PlayMaker.NamedVariable::get_IsNone(max);\n\tv154 = v99 == 0;\n\tv140 = ~v154;\n\tif (v140) goto L_0051;\n\tv157 = HutongGames.PlayMaker.FsmFloat::get_Value(max);\n\tv104 = v75 <= v157;\n\tif (v104) goto L_0051;\n\treturnVal3 = HutongGames.PlayMaker.FsmFloat::get_Value(max);\n\treturn returnVal3;\nL_0051:\n\treturn v75;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 65 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static float ClampAngle(float angle, FsmFloat min, FsmFloat max)
		{
			bool isNone = min.IsNone;
			bool flag = !isNone;
			bool flag2 = !flag;
			float num = angle;
			if (!flag2)
			{
				float value = min.Value;
				bool flag3 = !(value > angle);
				num = angle;
				if (!flag3)
				{
					float value2 = min.Value;
					num = value2;
				}
			}
			if (!max.IsNone)
			{
				float value3 = max.Value;
				if (num > value3)
				{
					return max.Value;
				}
			}
			return num;
		}

		[Token(Token = "0x6000B59")]
		[Address(RVA = "0xA3C580", Offset = "0xA3C580", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MouseLook()
		{
		}
	}
}
