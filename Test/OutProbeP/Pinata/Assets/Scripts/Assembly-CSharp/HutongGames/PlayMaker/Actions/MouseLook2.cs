using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x757F68", Offset = "0x757F68")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x757F68", Offset = "0x757F68")]
	[Token(Token = "0x2000244")]
	public class MouseLook2 : ComponentAction<Rigidbody>
	{
		[Token(Token = "0x200048C")]
		public enum RotationAxes
		{
			[Token(Token = "0x400217A")]
			MouseXAndY = 0,
			[Token(Token = "0x400217B")]
			MouseX = 1,
			[Token(Token = "0x400217C")]
			MouseY = 2
		}

		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B3E2C", Offset = "0x7B3E2C")]
		[Token(Token = "0x400158A")]
		[FieldOffset(Offset = "0x60")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B3E78", Offset = "0x7B3E78")]
		[Token(Token = "0x400158B")]
		[FieldOffset(Offset = "0x68")]
		public RotationAxes axes;

		[RequiredField]
		[Token(Token = "0x400158C")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat sensitivityX;

		[RequiredField]
		[Token(Token = "0x400158D")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat sensitivityY;

		[RequiredField]
		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7B3ED0", Offset = "0x7B3ED0")]
		[Token(Token = "0x400158E")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat minimumX;

		[RequiredField]
		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7B3F18", Offset = "0x7B3F18")]
		[Token(Token = "0x400158F")]
		[FieldOffset(Offset = "0x88")]
		public FsmFloat maximumX;

		[RequiredField]
		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7B3F60", Offset = "0x7B3F60")]
		[Token(Token = "0x4001590")]
		[FieldOffset(Offset = "0x90")]
		public FsmFloat minimumY;

		[RequiredField]
		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7B3FA8", Offset = "0x7B3FA8")]
		[Token(Token = "0x4001591")]
		[FieldOffset(Offset = "0x98")]
		public FsmFloat maximumY;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7B3FF0", Offset = "0x7B3FF0")]
		[Token(Token = "0x4001592")]
		[FieldOffset(Offset = "0xA0")]
		public bool everyFrame;

		[Token(Token = "0x4001593")]
		[FieldOffset(Offset = "0xA4")]
		private float rotationX;

		[Token(Token = "0x4001594")]
		[FieldOffset(Offset = "0xA8")]
		private float rotationY;

		[Token(Token = "0x6000B5A")]
		[Address(RVA = "0xA3C588", Offset = "0xA3C588", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.gameObject = 0;\n\tthis.axes = 0;\n\tv15 = HutongGames.PlayMaker.FsmFloat::op_Implicit(15f);\n\tthis.sensitivityX = v15;\n\tv18 = HutongGames.PlayMaker.FsmFloat::op_Implicit(15f);\n\tthis.sensitivityY = v18;\n\tv22 = HutongGames.PlayMaker.FsmFloat::op_Implicit(-360f);\n\tthis.minimumX = v22;\n\tv26 = HutongGames.PlayMaker.FsmFloat::op_Implicit(360f);\n\tthis.maximumX = v26;\n\tv30 = HutongGames.PlayMaker.FsmFloat::op_Implicit(-60f);\n\tthis.minimumY = v30;\n\tv34 = HutongGames.PlayMaker.FsmFloat::op_Implicit(60f);\n\tthis.maximumY = v34;\n\tthis.everyFrame = 1;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			axes = default(RotationAxes);
			FsmFloat fsmFloat = 15f;
			sensitivityX = fsmFloat;
			FsmFloat fsmFloat2 = 15f;
			sensitivityY = fsmFloat2;
			FsmFloat fsmFloat3 = -360f;
			minimumX = fsmFloat3;
			FsmFloat fsmFloat4 = 360f;
			maximumX = fsmFloat4;
			FsmFloat fsmFloat5 = -60f;
			minimumY = fsmFloat5;
			FsmFloat fsmFloat6 = 60f;
			maximumY = fsmFloat6;
			everyFrame = true;
		}

		[Token(Token = "0x6000B5B")]
		[Address(RVA = "0xA3C630", Offset = "0xA3C630", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EA5690]);\n\tv23 = *([v22 @ X8_v13]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021E56]) = v42;\nL_001A:\n\tv47 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.MouseLook2)+30]), this.gameObject);\n\tgoto L_002C;\n\tv74 = *([v70 @ X8_v4+E0]);\n\tv75 = v74 == 0;\n\tv76 = ~v75;\n\tif (v76) goto L_002C;\n\tv121 = v70;\n\tv79 = \"il2cpp_codegen_runtime_class_init\"(v121, v45, v46, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_002C:\n\tv84 = UnityEngine.Object::op_Equality(v47, 0);\n\tv123 = v84 == 0;\n\tv124 = ~v123;\n\tif (v124) goto L_0070;\n\tv129 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::UpdateCache(this, v47);\n\tv137 = v129 == 0;\n\tv138 = ~v137;\n\tif (v138) goto L_005B;\n\tv142 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::get_rigidbody(this);\n\tgoto L_004E;\n\tv154 = *([v64 @ X8_v10+E0]);\n\tv155 = v154 == 0;\n\tv156 = ~v155;\n\tif (v156) goto L_004E;\n\tv161 = v64;\n\tv158 = \"il2cpp_codegen_runtime_class_init\"(v161, v141, v56, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_004E:\n\tv147 = UnityEngine.Object::op_Implicit(v142);\n\tv149 = v147 == 0;\n\tif (v149) goto L_005B;\n\tv60 = HutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::get_rigidbody(this);\n\tUnityEngine.Rigidbody::set_freezeRotation(v60, 1);\nL_005B:\n\tHutongGames.PlayMaker.Actions.MouseLook2::DoMouseLook(this);\n\tv107 = ~this.everyFrame;\n\tif (v107) goto L_0070;\n\treturn;\nL_0070:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			//IL_001c: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.MouseLook2)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
			if (!(ownerDefaultTarget == null))
			{
				if (!UpdateCache(ownerDefaultTarget))
				{
					Rigidbody rigidbody = base.rigidbody;
					if ((bool)rigidbody)
					{
						Rigidbody rigidbody2 = base.rigidbody;
						rigidbody2.freezeRotation = true;
					}
				}
				DoMouseLook();
				if (everyFrame)
				{
					return;
				}
			}
			Finish();
		}

		[Token(Token = "0x6000B5C")]
		[Address(RVA = "0xA3C908", Offset = "0xA3C908", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.MouseLook2::DoMouseLook(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoMouseLook();
		}

		[Token(Token = "0x6000B5D")]
		[Address(RVA = "0xA3C770", Offset = "0xA3C770", Length = "0x198")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EAE2B0]);\n\tv21 = *([v20 @ X8_v11]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021E57]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(*([this @ X0 (HutongGames.PlayMaker.Actions.MouseLook2)+30]), this.gameObject);\n\tgoto L_002B;\n\tv127 = *([v50 @ X8_v6+E0]);\n\tv128 = v127 == 0;\n\tv129 = ~v128;\n\tif (v129) goto L_002B;\n\tv134 = v50;\n\tv131 = \"il2cpp_codegen_runtime_class_init\"(v134, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv112 = UnityEngine.Object::op_Equality(v45, 0);\n\tv136 = v112 == 0;\n\tv137 = ~v136;\n\tif (v137) goto L_008E;\n\tv115 = UnityEngine.GameObject::get_transform(v45);\n\tv89 = this.axes == 2;\n\tif (v89) goto L_0060;\n\tv88 = this.axes == 1;\n\tif (v88) goto L_0073;\n\tv211 = this.axes == 0;\n\tv206 = ~v211;\n\tif (v206) goto L_008E;\n\tv213 = HutongGames.PlayMaker.Actions.MouseLook2::GetYRotation(this);\n\tv221 = HutongGames.PlayMaker.Actions.MouseLook2::GetXRotation(this);\n\tv231 = 0;\n\tv113 = 0x1586898(&v231 @ stack_-40_v5, 0, 0, v25, v26, v27, v28, v29, v213, v221, 0, v33, v34, v35, v36, v37);\n\tv261 = v115 == 0;\n\tv118 = ~v261;\n\tif (v118) goto L_0086;\n\tgoto L_0091;\nL_0060:\n\tv69 = HutongGames.PlayMaker.Actions.MouseLook2::GetYRotation(this);\n\tv219 = UnityEngine.Transform::get_localEulerAngles(v115);\n\tv245 = v219.y;\n\tv247 = -v69;\n\tv231 = 0;\n\tgoto L_0080;\nL_0073:\n\tv247 = UnityEngine.Transform::get_localEulerAngles(v115);\n\tv226 = HutongGames.PlayMaker.Actions.MouseLook2::GetXRotation(this);\nL_0080:\n\tv260 = 0x1586898(v257, 0, 0, v25, v26, v27, v28, v29, v247, v245, v244, v33, v34, v35, v36, v37);\nL_0086:\n\t// 134 MakeStruct v187 @ AGGA3C8E4_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v231 @ stack_-40_v5, v267 @ stack_-3C, v189 @ stack_-38_v4 (System.Int32)\n\tUnityEngine.Transform::set_localEulerAngles(v115, v187);\nL_008E:\n\treturn;\n\tthrow System.NullReferenceException;\nL_0091:\n\tthrow System.NullReferenceException;\n// 99 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoMouseLook()
		{
			//IL_001c: Expected O, but got I
			//IL_0172: Expected O, but got F4
			//IL_017b: Expected O, but got I4
			//IL_0184: Expected O, but got I4
			//IL_01f3: Expected F4, but got O
			//IL_0200: Expected F4, but got O
			//IL_00f2: Expected O, but got I4
			//IL_0124: Expected O, but got I4
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (HutongGames.PlayMaker.Actions.MouseLook2)+30]");
			GameObject ownerDefaultTarget = ((Fsm)0).GetOwnerDefaultTarget(gameObject);
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
						goto IL_01e6;
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
			goto IL_01e6;
			IL_01e6:
			Vector3 localEulerAngles2 = default(Vector3);
			localEulerAngles2.x = (float)obj;
			object obj3 = default(object);
			localEulerAngles2.y = (float)obj3;
			localEulerAngles2.z = num;
			transform.localEulerAngles = localEulerAngles2;
		}

		[Token(Token = "0x6000B5E")]
		[Address(RVA = "0xA3C99C", Offset = "0xA3C99C", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EC4D60]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021E58]) = v42;\nL_001A:\n\treturnVal1 = UnityEngine.Input::GetAxis(\"Mouse X\");\n\tv53 = HutongGames.PlayMaker.FsmFloat::get_Value(this.sensitivityX);\n\tv57 = returnVal1 * v53;\n\tv58 = this.rotationX + v57;\n\tthis.rotationX = v58;\n\treturnVal2 = HutongGames.PlayMaker.Actions.MouseLook2::ClampAngle(v58, this.minimumX, this.maximumX);\n\tthis.rotationX = returnVal2;\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private float GetXRotation()
		{
			float axis = Input.GetAxis("Mouse X");
			float value = sensitivityX.Value;
			float num = axis * value;
			return rotationX = ClampAngle(rotationX += num, minimumX, maximumX);
		}

		[Token(Token = "0x6000B5F")]
		[Address(RVA = "0xA3C90C", Offset = "0xA3C90C", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1ED8A98]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2021E59]) = v42;\nL_001A:\n\treturnVal1 = UnityEngine.Input::GetAxis(\"Mouse Y\");\n\tv53 = HutongGames.PlayMaker.FsmFloat::get_Value(this.sensitivityY);\n\tv57 = returnVal1 * v53;\n\tv58 = this.rotationY + v57;\n\tthis.rotationY = v58;\n\treturnVal2 = HutongGames.PlayMaker.Actions.MouseLook2::ClampAngle(v58, this.minimumY, this.maximumY);\n\tthis.rotationY = returnVal2;\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\treturn returnVal1;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private float GetYRotation()
		{
			float axis = Input.GetAxis("Mouse Y");
			float value = sensitivityY.Value;
			float num = axis * value;
			return rotationY = ClampAngle(rotationY += num, minimumY, maximumY);
		}

		[Token(Token = "0x6000B60")]
		[Address(RVA = "0xA3CA2C", Offset = "0xA3CA2C", Length = "0xB4")]
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

		[Token(Token = "0x6000B61")]
		[Address(RVA = "0xA3CAE0", Offset = "0xA3CAE0", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EA5C18]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021E5A]) = v38;\nL_001C:\n\tHutongGames.PlayMaker.Actions.ComponentAction`1<UnityEngine.Rigidbody>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MouseLook2()
		{
		}
	}
}
