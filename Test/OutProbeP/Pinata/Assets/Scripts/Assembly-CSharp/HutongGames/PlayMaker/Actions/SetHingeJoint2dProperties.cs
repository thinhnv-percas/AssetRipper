using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75AD9C", Offset = "0x75AD9C")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75AD9C", Offset = "0x75AD9C")]
	[Token(Token = "0x20002D2")]
	public class SetHingeJoint2dProperties : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BF7C0", Offset = "0x7BF7C0")]
		[AttributeAttribute(Type = typeof(CheckForComponentAttribute), RVA = "0x7BF7C0", Offset = "0x7BF7C0")]
		[Token(Token = "0x400188E")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7BF858", Offset = "0x7BF858")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BF858", Offset = "0x7BF858")]
		[Token(Token = "0x400188F")]
		[FieldOffset(Offset = "0x58")]
		public FsmBool useLimits;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BF8B8", Offset = "0x7BF8B8")]
		[Token(Token = "0x4001890")]
		[FieldOffset(Offset = "0x60")]
		public FsmFloat min;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BF8F0", Offset = "0x7BF8F0")]
		[Token(Token = "0x4001891")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat max;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7BF928", Offset = "0x7BF928")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BF928", Offset = "0x7BF928")]
		[Token(Token = "0x4001892")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool useMotor;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BF988", Offset = "0x7BF988")]
		[Token(Token = "0x4001893")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat motorSpeed;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BF9C0", Offset = "0x7BF9C0")]
		[Token(Token = "0x4001894")]
		[FieldOffset(Offset = "0x80")]
		public FsmFloat maxMotorTorque;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BF9F8", Offset = "0x7BF9F8")]
		[Token(Token = "0x4001895")]
		[FieldOffset(Offset = "0x88")]
		public bool everyFrame;

		[Token(Token = "0x4001896")]
		[FieldOffset(Offset = "0x90")]
		private HingeJoint2D _joint;

		[Token(Token = "0x4001897")]
		[FieldOffset(Offset = "0x98")]
		private JointMotor2D _motor;

		[Token(Token = "0x4001898")]
		[FieldOffset(Offset = "0xA0")]
		private JointAngleLimits2D _limits;

		[Token(Token = "0x6000E1E")]
		[Address(RVA = "0x995340", Offset = "0x995340", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1EB50E8]);\n\tv25 = *([v24 @ X8_v4]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2021757]) = v44;\nL_0019:\n\tv48 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v48);\n\tv48.useVariable = 1;\n\tthis.useLimits = v48;\n\tv56 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v56);\n\tv56.useVariable = 1;\n\tthis.min = v56;\n\tv69 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v69);\n\tv69.useVariable = 1;\n\tthis.max = v69;\n\tv70 = new HutongGames.PlayMaker.FsmBool();\n\tHutongGames.PlayMaker.FsmBool::.ctor(v70);\n\tv70.useVariable = 1;\n\tthis.useMotor = v70;\n\tv71 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v71);\n\tv71.useVariable = 1;\n\tthis.motorSpeed = v71;\n\tv72 = new HutongGames.PlayMaker.FsmFloat();\n\tHutongGames.PlayMaker.FsmFloat::.ctor(v72);\n\tv72.useVariable = 1;\n\tthis.maxMotorTorque = v72;\n\tthis.everyFrame = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 62 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			FsmBool fsmBool = new FsmBool();
			fsmBool.useVariable = true;
			useLimits = fsmBool;
			FsmFloat fsmFloat = new FsmFloat();
			fsmFloat.useVariable = true;
			min = fsmFloat;
			FsmFloat fsmFloat2 = new FsmFloat();
			fsmFloat2.useVariable = true;
			max = fsmFloat2;
			FsmBool fsmBool2 = new FsmBool();
			fsmBool2.useVariable = true;
			useMotor = fsmBool2;
			FsmFloat fsmFloat3 = new FsmFloat();
			fsmFloat3.useVariable = true;
			motorSpeed = fsmFloat3;
			FsmFloat fsmFloat4 = new FsmFloat();
			fsmFloat4.useVariable = true;
			maxMotorTorque = fsmFloat4;
			everyFrame = false;
		}

		[Token(Token = "0x6000E1F")]
		[Address(RVA = "0x995478", Offset = "0x995478", Length = "0x140")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1EFC268]);\n\tv21 = *([v20 @ X8_v15]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021758]) = v40;\nL_0019:\n\tv45 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_002B;\n\tv93 = *([v73 @ X8_v5+E0]);\n\tv94 = v93 == 0;\n\tv95 = ~v94;\n\tif (v95) goto L_002B;\n\tv100 = v73;\n\tv97 = \"il2cpp_codegen_runtime_class_init\"(v100, v43, v44, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_002B:\n\tv86 = UnityEngine.Object::op_Inequality(v45, 0);\n\tv102 = v86 == 0;\n\tif (v102) goto L_005A;\n\tv148 = UnityEngine.GameObject::GetComponent(v45);\n\tthis._joint = v148;\n\tgoto L_0045;\n\tv154 = *([v150 @ X0_v17+E0]);\n\tv155 = v154 == 0;\n\tv156 = ~v155;\n\tif (v156) goto L_0045;\n\tv158 = \"il2cpp_codegen_runtime_class_init\"(v150, v147, v82, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0045:\n\tv139 = UnityEngine.Object::op_Inequality(v148, 0);\n\tv141 = v139 == 0;\n\tif (v141) goto L_005A;\n\tv49 = UnityEngine.HingeJoint2D::get_motor(this._joint);\n\tthis._motor = v49;\n\tthis._motor.m_MaximumMotorTorque = v49.m_MaximumMotorTorque;\n\tv136 = UnityEngine.HingeJoint2D::get_limits(this._joint);\n\tthis._limits = v136;\n\tthis._limits.m_UpperAngle = v136.m_UpperAngle;\nL_005A:\n\tHutongGames.PlayMaker.Actions.SetHingeJoint2dProperties::SetProperties(this);\n\tv123 = this.everyFrame == 0;\n\tif (v123) goto L_006E;\n\treturn;\nL_006E:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget != null && (_joint = ownerDefaultTarget.GetComponent<HingeJoint2D>()) != null)
			{
				JointMotor2D jointMotor2D = (_motor = _joint.motor);
				_motor.maxMotorTorque = jointMotor2D.m_MaximumMotorTorque;
				JointAngleLimits2D jointAngleLimits2D = (_limits = _joint.limits);
				_limits.max = jointAngleLimits2D.m_UpperAngle;
			}
			SetProperties();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000E20")]
		[Address(RVA = "0x9957DC", Offset = "0x9957DC", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SetHingeJoint2dProperties::SetProperties(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			SetProperties();
		}

		[Token(Token = "0x6000E21")]
		[Address(RVA = "0x9955B8", Offset = "0x9955B8", Length = "0x224")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EAD268]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2021759]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Equality(this._joint, 0);\n\tv58 = v56 == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_00AD;\n\tv90 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.useMotor);\n\tv196 = v90 == 0;\n\tv197 = ~v196;\n\tif (v197) goto L_0041;\n\tv201 = HutongGames.PlayMaker.FsmBool::get_Value(this.useMotor);\n\tUnityEngine.HingeJoint2D::set_useMotor(this._joint, v201);\nL_0041:\n\tv213 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.motorSpeed);\n\tv215 = v213 == 0;\n\tv216 = ~v215;\n\tif (v216) goto L_005B;\n\tv154 = this + 0x98;\n\tv98 = HutongGames.PlayMaker.FsmFloat::get_Value(this.motorSpeed);\n\tv226 = 0x163E678(v154, 0, v76, v23, v24, v25, v26, v27, v98, v72, v30, v31, v32, v33, v34, v35);\n\tv72 = this._motor.m_MaximumMotorTorque;\n\t// 85 MakeStruct v217 @ AGG9956A4_1_v5 (UnityEngine.JointMotor2D), typeof(UnityEngine.JointMotor2D), this._motor (UnityEngine.JointMotor2D), this._motor.m_MaximumMotorTorque (System.Single)\n\tUnityEngine.HingeJoint2D::set_motor(this._joint, v217);\nL_005B:\n\tv224 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.maxMotorTorque);\n\tv228 = v224 == 0;\n\tv229 = ~v228;\n\tif (v229) goto L_0075;\n\tv156 = this + 0x98;\n\tv100 = HutongGames.PlayMaker.FsmFloat::get_Value(this.maxMotorTorque);\n\tv239 = 0x163E680(v156, 0, v76, v23, v24, v25, v26, v27, v100, v72, v30, v31, v32, v33, v34, v35);\n\tv72 = this._motor.m_MaximumMotorTorque;\n\t// 111 MakeStruct v230 @ AGG9956EC_1_v5 (UnityEngine.JointMotor2D), typeof(UnityEngine.JointMotor2D), this._motor (UnityEngine.JointMotor2D), this._motor.m_MaximumMotorTorque (System.Single)\n\tUnityEngine.HingeJoint2D::set_motor(this._joint, v230);\nL_0075:\n\tv237 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.useLimits);\n\tv241 = v237 == 0;\n\tv242 = ~v241;\n\tif (v242) goto L_008A;\n\tv202 = HutongGames.PlayMaker.FsmBool::get_Value(this.useLimits);\n\tUnityEngine.HingeJoint2D::set_useLimits(this._joint, v202);\nL_008A:\n\tv248 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.min);\n\tv250 = v248 == 0;\n\tv251 = ~v250;\n\tif (v251) goto L_00A4;\n\tv159 = this + 0xA0;\n\tv102 = HutongGames.PlayMaker.FsmFloat::get_Value(this.min);\n\tv260 = 0x163E668(v159, 0, v76, v23, v24, v25, v26, v27, v102, v72, v30, v31, v32, v33, v34, v35);\n\tv72 = this._limits.m_UpperAngle;\n\t// 158 MakeStruct v252 @ AGG995770_1_v5 (UnityEngine.JointAngleLimits2D), typeof(UnityEngine.JointAngleLimits2D), this._limits (UnityEngine.JointAngleLimits2D), this._limits.m_UpperAngle (System.Single)\n\tUnityEngine.HingeJoint2D::set_limits(this._joint, v252);\nL_00A4:\n\tv80 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.max);\n\tv82 = v80 == 0;\n\tif (v82) goto L_00B2;\nL_00AD:\n\treturn;\nL_00B2:\n\tv160 = this + 0xA0;\n\tv103 = HutongGames.PlayMaker.FsmFloat::get_Value(this.max);\n\tv264 = 0x163E670(v160, 0, v76, v23, v24, v25, v26, v27, v103, v72, v30, v31, v32, v33, v34, v35);\n\t// 194 MakeStruct v164 @ AGG9957CC_1_v1 (UnityEngine.JointAngleLimits2D), typeof(UnityEngine.JointAngleLimits2D), this._limits (UnityEngine.JointAngleLimits2D), this._limits.m_UpperAngle (System.Single)\n\tUnityEngine.HingeJoint2D::set_limits(this._joint, v164);\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 130 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void SetProperties()
		{
			//IL_006f: Expected O, but got I4
			//IL_00f1: Expected O, but got I
			//IL_00a9: Expected O, but got I4
			//IL_01a2: Expected O, but got I
			//IL_0362: Expected O, but got I
			//IL_02bb: Expected O, but got I
			//IL_0273: Expected O, but got I4
			if (!(_joint == null))
			{
				bool isNone = useMotor.IsNone;
				bool flag = !isNone;
				bool flag2 = !flag;
				object obj = 0;
				if (!flag2)
				{
					bool value = useMotor.Value;
					_joint.useMotor = value;
					obj = 0;
				}
				if (!motorSpeed.IsNone)
				{
					object obj2 = (long)(IntPtr)this + 152L;
					float value2 = motorSpeed.Value;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @163E678 (inside UnityEngine.Joint2D::get_reactionTorque +0x50)");
					float maximumMotorTorque = _motor.m_MaximumMotorTorque;
					JointMotor2D motor = default(JointMotor2D);
					motor.motorSpeed = _motor.m_MotorSpeed;
					motor.maxMotorTorque = _motor.m_MaximumMotorTorque;
					_joint.motor = motor;
				}
				if (!maxMotorTorque.IsNone)
				{
					object obj3 = (long)(IntPtr)this + 152L;
					float value3 = maxMotorTorque.Value;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @163E680 (inside UnityEngine.Joint2D::get_reactionTorque +0x58)");
					float maximumMotorTorque = _motor.m_MaximumMotorTorque;
					JointMotor2D motor2 = default(JointMotor2D);
					motor2.motorSpeed = _motor.m_MotorSpeed;
					motor2.maxMotorTorque = _motor.m_MaximumMotorTorque;
					_joint.motor = motor2;
				}
				if (!useLimits.IsNone)
				{
					bool value4 = useLimits.Value;
					_joint.useLimits = value4;
					obj = 0;
				}
				if (!min.IsNone)
				{
					object obj4 = (long)(IntPtr)this + 160L;
					float value5 = min.Value;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @163E668 (inside UnityEngine.Joint2D::get_reactionTorque +0x40)");
					float maximumMotorTorque = _limits.m_UpperAngle;
					JointAngleLimits2D limits = default(JointAngleLimits2D);
					limits.min = _limits.m_LowerAngle;
					limits.max = _limits.m_UpperAngle;
					_joint.limits = limits;
				}
				if (!max.IsNone)
				{
					object obj5 = (long)(IntPtr)this + 160L;
					float value6 = max.Value;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @163E670 (inside UnityEngine.Joint2D::get_reactionTorque +0x48)");
					JointAngleLimits2D limits2 = default(JointAngleLimits2D);
					limits2.min = _limits.m_LowerAngle;
					limits2.max = _limits.m_UpperAngle;
					_joint.limits = limits2;
				}
			}
		}

		[Token(Token = "0x6000E22")]
		[Address(RVA = "0x9957E0", Offset = "0x9957E0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SetHingeJoint2dProperties()
		{
		}
	}
}
