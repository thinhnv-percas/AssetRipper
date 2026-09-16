using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75AF50", Offset = "0x75AF50")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75AF50", Offset = "0x75AF50")]
	[Token(Token = "0x20002D7")]
	public class SetWheelJoint2dProperties : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BFEA8", Offset = "0x7BFEA8")]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7BFEA8", Offset = "0x7BFEA8")]
		[Token(Token = "0x40018A5")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7BFF40", Offset = "0x7BFF40")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BFF40", Offset = "0x7BFF40")]
		[Token(Token = "0x40018A6")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool useMotor;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BFFA0", Offset = "0x7BFFA0")]
		[Token(Token = "0x40018A7")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat motorSpeed;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BFFD8", Offset = "0x7BFFD8")]
		[Token(Token = "0x40018A8")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat maxMotorTorque;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7C0010", Offset = "0x7C0010")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C0010", Offset = "0x7C0010")]
		[Token(Token = "0x40018A9")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat angle;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C0070", Offset = "0x7C0070")]
		[Token(Token = "0x40018AA")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat dampingRatio;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C00A8", Offset = "0x7C00A8")]
		[Token(Token = "0x40018AB")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat frequency;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C00E0", Offset = "0x7C00E0")]
		[Token(Token = "0x40018AC")]
		[FieldOffset(Offset = "0x88")]
		public bool everyFrame;

		[Token(Token = "0x40018AD")]
		[FieldOffset(Offset = "0x90")]
		private WheelJoint2D _wj2d;

		[Token(Token = "0x40018AE")]
		[FieldOffset(Offset = "0x98")]
		private JointMotor2D _motor;

		[Token(Token = "0x40018AF")]
		[FieldOffset(Offset = "0xA0")]
		private JointSuspension2D _suspension;

		[Token(Token = "0x6000E36")]
		[Address(RVA = "0x99BA28", Offset = "0x99BA28", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EBDBE8]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20217AA]) = v42;\nL_0018:\n\tv46 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v46);\n\tv46.useVariable = 1;\n\tthis.useMotor = v46;\n\tv54 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v54);\n\tv54.useVariable = 1;\n\tthis.motorSpeed = v54;\n\tv66 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v66);\n\tv66.useVariable = 1;\n\tthis.maxMotorTorque = v66;\n\tv67 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v67);\n\tv67.useVariable = 1;\n\tthis.angle = v67;\n\tv68 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v68);\n\tv68.useVariable = 1;\n\tthis.dampingRatio = v68;\n\tv69 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v69);\n\tv69.useVariable = 1;\n\tthis.frequency = v69;\n\tthis.everyFrame = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmBool fsmBool = new FsmBool();
			fsmBool.useVariable = true;
			useMotor = fsmBool;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			motorSpeed = fsmFloat;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = true;
			maxMotorTorque = fsmFloat2;
			FsmFloat fsmFloat3 = new FsmFloat();
			fsmFloat3.useVariable = true;
			angle = fsmFloat3;
			FsmFloat fsmFloat4 = new FsmFloat();
			fsmFloat4.useVariable = true;
			dampingRatio = fsmFloat4;
			FsmFloat fsmFloat5 = new FsmFloat();
			fsmFloat5.useVariable = true;
			frequency = fsmFloat5;
			everyFrame = false;
		}

		[Token(Token = "0x6000E37")]
		[Address(RVA = "0x99BB58", Offset = "0x99BB58", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EA7410]);\n\tv21 = *([v20 @ X8_v15]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20217AB]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv93 = *([v73 @ X8_v5+E0]);\n\tv94 = v93 == 0;\n\tv95 = ~v94;\n\tif (v95) goto L_002B;\n\tv100 = v73;\n\tv97 = \"il2cpp_codegen_runtime_class_init\"(v100, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv86 = UnityEngine.Object::op_Inequality(v45, 0);\n\tv102 = v86 == 0;\n\tif (v102) goto L_005C;\n\tv151 = UnityEngine.GameObject::GetComponent(v45);\n\tthis._wj2d = v151;\n\tgoto L_0045;\n\tv157 = *([v153 @ X0_v17+E0]);\n\tv158 = v157 == 0;\n\tv159 = ~v158;\n\tif (v159) goto L_0045;\n\tv161 = \"il2cpp_codegen_runtime_class_init\"(v153, v150, v82, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0045:\n\tv142 = UnityEngine.Object::op_Inequality(v151, 0);\n\tv144 = v142 == 0;\n\tif (v144) goto L_005C;\n\tv49 = UnityEngine.WheelJoint2D::get_motor(this._wj2d);\n\tthis._motor = v49;\n\tthis._motor.m_MaximumMotorTorque = v49.m_MaximumMotorTorque;\n\tv139 = UnityEngine.WheelJoint2D::get_suspension(this._wj2d);\n\tthis._suspension = v139;\n\tthis._suspension.m_Frequency = v139.m_Frequency;\n\tthis._suspension.m_Angle = v139.m_Angle;\nL_005C:\n\tHutongGames.PlayMaker.Actions.SetWheelJoint2dProperties::SetProperties(this);\n\tv125 = this.everyFrame == 0;\n\tif (v125) goto L_0070;\n\treturn;\nL_0070:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget != null && (_wj2d = ownerDefaultTarget.GetComponent<WheelJoint2D>()) != null)
			{
				JointMotor2D jointMotor2D = (_motor = _wj2d.motor);
				_motor.maxMotorTorque = jointMotor2D.m_MaximumMotorTorque;
				JointSuspension2D jointSuspension2D = (_suspension = _wj2d.suspension);
				_suspension.frequency = jointSuspension2D.m_Frequency;
				_suspension.angle = jointSuspension2D.m_Angle;
			}
			SetProperties();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000E38")]
		[Address(RVA = "0x99BED8", Offset = "0x99BED8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetWheelJoint2dProperties::SetProperties(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			SetProperties();
		}

		[Token(Token = "0x6000E39")]
		[Address(RVA = "0x99BC9C", Offset = "0x99BC9C", Length = "0x23C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EE9618]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20217AC]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Equality(this._wj2d, 0);\n\tv58 = v56 == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_00B4;\n\tv95 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.useMotor);\n\tv215 = v95 == 0;\n\tv216 = ~v215;\n\tif (v216) goto L_0041;\n\tv219 = HutongGames.PlayMaker.FsmBool::get_Value(this.useMotor);\n\tUnityEngine.WheelJoint2D::set_useMotor(this._wj2d, v219);\nL_0041:\n\tv228 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.motorSpeed);\n\tv230 = v228 == 0;\n\tv231 = ~v230;\n\tif (v231) goto L_005B;\n\tv167 = this + 0x98;\n\tv107 = HutongGames.PlayMaker.FsmFloat::get_Value(this.motorSpeed);\n\tv241 = 0x163E678(v167, 0, v81, v23, v24, v25, v26, v27, v107, v77, v69, v31, v32, v33, v34, v35);\n\tv77 = this._motor.m_MaximumMotorTorque;\n\t// 85 MakeStruct v232 @ AGG99BD88_1_v5 (UnityEngine.JointMotor2D), typeof(UnityEngine.JointMotor2D), this._motor (UnityEngine.JointMotor2D), this._motor.m_MaximumMotorTorque (System.Single)\n\tUnityEngine.WheelJoint2D::set_motor(this._wj2d, v232);\nL_005B:\n\tv239 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.maxMotorTorque);\n\tv243 = v239 == 0;\n\tv244 = ~v243;\n\tif (v244) goto L_0075;\n\tv169 = this + 0x98;\n\tv109 = HutongGames.PlayMaker.FsmFloat::get_Value(this.maxMotorTorque);\n\tv254 = 0x163E680(v169, 0, v81, v23, v24, v25, v26, v27, v109, v77, v69, v31, v32, v33, v34, v35);\n\tv77 = this._motor.m_MaximumMotorTorque;\n\t// 111 MakeStruct v245 @ AGG99BDD0_1_v5 (UnityEngine.JointMotor2D), typeof(UnityEngine.JointMotor2D), this._motor (UnityEngine.JointMotor2D), this._motor.m_MaximumMotorTorque (System.Single)\n\tUnityEngine.WheelJoint2D::set_motor(this._wj2d, v245);\nL_0075:\n\tv252 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.angle);\n\tv256 = v252 == 0;\n\tv257 = ~v256;\n\tif (v257) goto L_0090;\n\tv171 = this + 0xA0;\n\tv111 = HutongGames.PlayMaker.FsmFloat::get_Value(this.angle);\n\tv268 = 0x163E698(v171, 0, v81, v23, v24, v25, v26, v27, v111, v77, v69, v31, v32, v33, v34, v35);\n\tv77 = this._suspension.m_Frequency;\n\tv69 = this._suspension.m_Angle;\n\t// 138 MakeStruct v258 @ AGG99BE1C_1_v5 (UnityEngine.JointSuspension2D), typeof(UnityEngine.JointSuspension2D), this._suspension (UnityEngine.JointSuspension2D), this._suspension.m_Frequency (System.Single), this._suspension.m_Angle (System.Single)\n\tUnityEngine.WheelJoint2D::set_suspension(this._wj2d, v258);\nL_0090:\n\tv266 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.dampingRatio);\n\tv270 = v266 == 0;\n\tv271 = ~v270;\n\tif (v271) goto L_00AB;\n\tv173 = this + 0xA0;\n\tv113 = HutongGames.PlayMaker.FsmFloat::get_Value(this.dampingRatio);\n\tv281 = 0x163E688(v173, 0, v81, v23, v24, v25, v26, v27, v113, v77, v69, v31, v32, v33, v34, v35);\n\tv77 = this._suspension.m_Frequency;\n\tv69 = this._suspension.m_Angle;\n\t// 165 MakeStruct v272 @ AGG99BE68_1_v5 (UnityEngine.JointSuspension2D), typeof(UnityEngine.JointSuspension2D), this._suspension (UnityEngine.JointSuspension2D), this._suspension.m_Frequency (System.Single), this._suspension.m_Angle (System.Single)\n\tUnityEngine.WheelJoint2D::set_suspension(this._wj2d, v272);\nL_00AB:\n\tv85 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.frequency);\n\tv87 = v85 == 0;\n\tif (v87) goto L_00B9;\nL_00B4:\n\treturn;\nL_00B9:\n\tv174 = this + 0xA0;\n\tv114 = HutongGames.PlayMaker.FsmFloat::get_Value(this.frequency);\n\tv285 = 0x163E690(v174, 0, v81, v23, v24, v25, v26, v27, v114, v77, v69, v31, v32, v33, v34, v35);\n\t// 202 MakeStruct v178 @ AGG99BEC8_1_v1 (UnityEngine.JointSuspension2D), typeof(UnityEngine.JointSuspension2D), this._suspension (UnityEngine.JointSuspension2D), this._suspension.m_Frequency (System.Single), this._suspension.m_Angle (System.Single)\n\tUnityEngine.WheelJoint2D::set_suspension(this._wj2d, v178);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 132 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SetProperties()
		{
			//IL_006f: Expected O, but got I4
			//IL_00f1: Expected O, but got I
			//IL_00a9: Expected O, but got I4
			//IL_019d: Expected O, but got I
			//IL_0249: Expected O, but got I
			//IL_03dd: Expected O, but got I
			//IL_0318: Expected O, but got I
			if (!(_wj2d == null))
			{
				bool isNone = useMotor.IsNone;
				bool flag = !isNone;
				bool flag2 = !flag;
				object obj = 0;
				if (!flag2)
				{
					bool value = useMotor.Value;
					_wj2d.useMotor = value;
					obj = 0;
				}
				if (!motorSpeed.IsNone)
				{
					object obj2 = (long)(IntPtr)this + 152L;
					float value2 = motorSpeed.Value;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @163E678 (inside UnityEngine.Joint2D::get_reactionTorque +0x50)");
					float maximumMotorTorque = _motor.m_MaximumMotorTorque;
					JointMotor2D motor = default(JointMotor2D);
					motor.motorSpeed = _motor.m_MotorSpeed;
					motor.maxMotorTorque = _motor.m_MaximumMotorTorque;
					_wj2d.motor = motor;
				}
				if (!maxMotorTorque.IsNone)
				{
					object obj3 = (long)(IntPtr)this + 152L;
					float value3 = maxMotorTorque.Value;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @163E680 (inside UnityEngine.Joint2D::get_reactionTorque +0x58)");
					float maximumMotorTorque = _motor.m_MaximumMotorTorque;
					JointMotor2D motor2 = default(JointMotor2D);
					motor2.motorSpeed = _motor.m_MotorSpeed;
					motor2.maxMotorTorque = _motor.m_MaximumMotorTorque;
					_wj2d.motor = motor2;
				}
				if (!angle.IsNone)
				{
					object obj4 = (long)(IntPtr)this + 160L;
					float value4 = angle.Value;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @163E698 (inside UnityEngine.Joint2D::get_reactionTorque +0x70)");
					float maximumMotorTorque = _suspension.m_Frequency;
					float num = _suspension.m_Angle;
					JointSuspension2D suspension = default(JointSuspension2D);
					suspension.dampingRatio = _suspension.m_DampingRatio;
					suspension.frequency = _suspension.m_Frequency;
					suspension.angle = _suspension.m_Angle;
					_wj2d.suspension = suspension;
				}
				if (!dampingRatio.IsNone)
				{
					object obj5 = (long)(IntPtr)this + 160L;
					float value5 = dampingRatio.Value;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @163E688 (inside UnityEngine.Joint2D::get_reactionTorque +0x60)");
					float maximumMotorTorque = _suspension.m_Frequency;
					float num = _suspension.m_Angle;
					JointSuspension2D suspension2 = default(JointSuspension2D);
					suspension2.dampingRatio = _suspension.m_DampingRatio;
					suspension2.frequency = _suspension.m_Frequency;
					suspension2.angle = _suspension.m_Angle;
					_wj2d.suspension = suspension2;
				}
				if (!frequency.IsNone)
				{
					object obj6 = (long)(IntPtr)this + 160L;
					float value6 = frequency.Value;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @163E690 (inside UnityEngine.Joint2D::get_reactionTorque +0x68)");
					JointSuspension2D suspension3 = default(JointSuspension2D);
					suspension3.dampingRatio = _suspension.m_DampingRatio;
					suspension3.frequency = _suspension.m_Frequency;
					suspension3.angle = _suspension.m_Angle;
					_wj2d.suspension = suspension3;
				}
			}
		}

		[Token(Token = "0x6000E3A")]
		[Address(RVA = "0x99BEDC", Offset = "0x99BEDC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetWheelJoint2dProperties()
		{
		}
	}
}
