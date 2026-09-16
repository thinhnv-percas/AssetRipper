using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75AFF0", Offset = "0x75AFF0")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75AFF0", Offset = "0x75AFF0")]
	[Token(Token = "0x20002D9")]
	public class SmoothLookAt2d : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C01B0", Offset = "0x7C01B0")]
		[Token(Token = "0x40018B1")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C01FC", Offset = "0x7C01FC")]
		[Token(Token = "0x40018B2")]
		[FieldOffset(Offset = "0x58")]
		public FsmGameObject targetObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C0234", Offset = "0x7C0234")]
		[Token(Token = "0x40018B3")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector2 targetPosition2d;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C026C", Offset = "0x7C026C")]
		[Token(Token = "0x40018B4")]
		[FieldOffset(Offset = "0x68")]
		public FsmVector3 targetPosition;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C02A4", Offset = "0x7C02A4")]
		[Token(Token = "0x40018B5")]
		[FieldOffset(Offset = "0x70")]
		public FsmFloat rotationOffset;

		[AttributeAttribute(Type = typeof(HasFloatSliderAttribute), RVA = "0x7C02DC", Offset = "0x7C02DC")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C02DC", Offset = "0x7C02DC")]
		[Token(Token = "0x40018B6")]
		[FieldOffset(Offset = "0x78")]
		public FsmFloat speed;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C0330", Offset = "0x7C0330")]
		[Token(Token = "0x40018B7")]
		[FieldOffset(Offset = "0x80")]
		public FsmBool debug;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C0368", Offset = "0x7C0368")]
		[Token(Token = "0x40018B8")]
		[FieldOffset(Offset = "0x88")]
		public FsmFloat finishTolerance;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C03A0", Offset = "0x7C03A0")]
		[Token(Token = "0x40018B9")]
		[FieldOffset(Offset = "0x90")]
		public FsmEvent finishEvent;

		[Token(Token = "0x40018BA")]
		[FieldOffset(Offset = "0x98")]
		private GameObject previousGo;

		[Token(Token = "0x40018BB")]
		[FieldOffset(Offset = "0xA0")]
		private Quaternion lastRotation;

		[Token(Token = "0x40018BC")]
		[FieldOffset(Offset = "0xB0")]
		private Quaternion desiredRotation;

		[Token(Token = "0x6000E3F")]
		[Address(RVA = "0x99CD60", Offset = "0x99CD60", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EFBEA0]);\n\tv21 = *([v20 @ X8_v10]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20217B4]) = v40;\nL_0014:\n\tthis.gameObject = 0;\n\tthis.targetObject = 0;\n\tv44 = new HutongGames.PlayMaker.FsmVector2();\n\tHutongGames.PlayMaker.FsmVector2::.ctor(v44);\n\tv44.useVariable = 1;\n\tthis.targetPosition2d = v44;\n\tv52 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v52);\n\tv52.useVariable = 1;\n\tthis.targetPosition = v52;\n\tv84 = HutongGames.PlayMaker.FsmFloat::op_Implicit(0f);\n\tthis.rotationOffset = v84;\n\tv86 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.debug = v86;\n\tv89 = HutongGames.PlayMaker.FsmFloat::op_Implicit(5f);\n\tthis.speed = v89;\n\tv73 = HutongGames.PlayMaker.FsmFloat::op_Implicit(1f);\n\tthis.finishTolerance = v73;\n\tthis.finishEvent = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			targetObject = null;
			FsmVector2 fsmVector = new FsmVector2();
			fsmVector.useVariable = true;
			targetPosition2d = fsmVector;
			FsmVector3 fsmVector2 = new FsmVector3();
			fsmVector2.useVariable = true;
			targetPosition = fsmVector2;
			FsmFloat fsmFloat = 0f;
			rotationOffset = fsmFloat;
			FsmBool fsmBool = false;
			debug = fsmBool;
			FsmFloat fsmFloat2 = 5f;
			speed = fsmFloat2;
			FsmFloat fsmFloat3 = 1f;
			finishTolerance = fsmFloat3;
			finishEvent = null;
		}

		[Token(Token = "0x6000E40")]
		[Address(RVA = "0x99CE48", Offset = "0x99CE48", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Fsm::set_HandleLateUpdate(this.fsm, 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnPreprocess()
		{
			Fsm.HandleLateUpdate = true;
		}

		[Token(Token = "0x6000E41")]
		[Address(RVA = "0x99CE68", Offset = "0x99CE68", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.previousGo = 0;\n\treturn;\n")]
		public override void OnEnter()
		{
			previousGo = null;
		}

		[Token(Token = "0x6000E42")]
		[Address(RVA = "0x99CE70", Offset = "0x99CE70", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.SmoothLookAt2d::DoSmoothLookAt(this);\n\treturn;\n")]
		public override void OnLateUpdate()
		{
			DoSmoothLookAt();
		}

		[Token(Token = "0x6000E43")]
		[Address(RVA = "0x99CE74", Offset = "0x99CE74", Length = "0x6EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0028;\n\tv42 = *([1EC91D0]);\n\tv43 = *([v42 @ X8_v62]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv62 = 0 | 1;\n\t*([20217B5]) = v62;\nL_0028:\n\tv71 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_003A;\n\tv436 = *([v418 @ X8_v4+E0]);\n\tv437 = v436 == 0;\n\tv438 = ~v437;\n\tif (v438) goto L_003A;\n\tv580 = v418;\n\tv440 = \"il2cpp_codegen_runtime_class_init\"(v580, v69, v70, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\nL_003A:\n\tv443 = UnityEngine.Object::op_Equality(v71, 0);\n\tv582 = v443 == 0;\n\tv583 = ~v582;\n\tif (v583) goto L_0283;\n\tv615 = HutongGames.PlayMaker.FsmGameObject::get_Value(this.targetObject);\n\tgoto L_0054;\n\tv619 = *([v419 @ X8_v6+E0]);\n\tv620 = v619 == 0;\n\tv621 = ~v620;\n\tif (v621) goto L_0054;\n\tv628 = v419;\n\tv623 = \"il2cpp_codegen_runtime_class_init\"(v628, v614, v356, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\nL_0054:\n\tv627 = UnityEngine.Object::op_Inequality(this.previousGo, v71);\n\tv630 = v627 == 0;\n\tif (v630) goto L_006D;\n\tv381 = UnityEngine.GameObject::get_transform(v71);\n\tv638 = UnityEngine.Transform::get_rotation(v381);\n\tthis.lastRotation = v638;\n\tthis.lastRotation.y = v638.y;\n\tthis.lastRotation.z = v638.z;\n\tthis.lastRotation.w = v638.w;\n\tthis.desiredRotation = v638;\n\tthis.desiredRotation.y = v638.y;\n\tthis.desiredRotation.z = v638.z;\n\tthis.desiredRotation.w = v638.w;\n\tthis.previousGo = v71;\nL_006D:\n\tv420 = this.targetPosition2d;\n\tv321 = v420.value;\n\tv702 = 0x1586898(&v665 @ stack_-90_v6 (UnityEngine.Vector3), 0, 0, v47, v48, v49, v50, v51, v420.value, v420.value.y, 0, v638.w, v56, v57, v58, v59);\n\tv703 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.targetPosition);\n\tv705 = v703 == 0;\n\tv706 = ~v705;\n\tif (v706) goto L_00AB;\n\tv736 = HutongGames.PlayMaker.FsmVector3::get_Value(this.targetPosition);\n\tgoto L_009F;\n\tv754 = *([v748 @ X0_v106+E0]);\n\tv755 = v754 == 0;\n\tv756 = ~v755;\n\tif (v756) goto L_009F;\n\tv758 = \"il2cpp_codegen_runtime_class_init\"(v748, v725, v357, v47, v48, v49, v50, v51, v736, v744, v745, v286, v56, v57, v58, v59);\nL_009F:\n\t// 159 MakeStruct v710 @ AGG99D02C_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v665 @ stack_-90_v6 (UnityEngine.Vector3), v201 @ stack_-8C, 0\n\tv723 = UnityEngine.Vector3::op_Addition(v710, v736);\nL_00AB:\n\tgoto L_00B4;\n\tv737 = *([v732 @ X0_v21+E0]);\n\tv738 = v737 == 0;\n\tv739 = ~v738;\n\tgoto L_00B4;\n\tv741 = \"il2cpp_codegen_runtime_class_init\"(v732, v724, v357, v47, v48, v49, v50, v51, v322, v310, v298, v287, v223, v215, v58, v59);\nL_00B4:\n\tv685 = UnityEngine.Object::op_Inequality(v615, 0);\n\tv753 = v685 == 0;\n\tif (v753) goto L_0285;\n\tv384 = UnityEngine.GameObject::get_transform(v615);\n\tv771 = UnityEngine.Transform::get_position(v384);\n\tgoto L_00D3;\n\tv788 = *([v777 @ X0_v73+E0]);\n\tv789 = v788 == 0;\n\tv790 = ~v789;\n\tif (v790) goto L_00D3;\n\tv792 = \"il2cpp_codegen_runtime_class_init\"(v777, v366, v358, v47, v48, v49, v50, v51, v771, v774, v775, v287, v223, v215, v58, v59);\nL_00D3:\n\tv323 = UnityEngine.Vector3::get_zero();\n\tv810 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.targetPosition);\n\tv817 = v810 == 0;\n\tv818 = ~v817;\n\tif (v818) goto L_0106;\n\tv843 = HutongGames.PlayMaker.FsmVector3::get_Value(this.targetPosition);\n\tgoto L_00FF;\n\tv861 = *([v850 @ X0_v99+E0]);\n\tv862 = v861 == 0;\n\tv863 = ~v862;\n\tif (v863) goto L_00FF;\n\tv865 = \"il2cpp_codegen_runtime_class_init\"(v850, v837, v358, v47, v48, v49, v50, v51, v843, v848, v849, v287, v223, v215, v58, v59);\nL_00FF:\n\tv836 = UnityEngine.Vector3::op_Addition(v323, v843);\nL_0106:\n\tv686 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.targetPosition2d);\n\tv341 = &v665 @ stack_-90_v6 (UnityEngine.Vector3) | 4;\n\tv353 = &v665 @ stack_-90_v6 (UnityEngine.Vector3) + 8;\n\tv870 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.targetPosition2d);\n\tv882 = v870 == 0;\n\tif (v882) goto L_0121;\n\tv886 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.targetPosition);\n\tv896 = v886 == 0;\n\tv888 = ~v896;\n\tif (v888) goto L_0166;\nL_0121:\n\tv687 = UnityEngine.GameObject::get_transform(v615);\n\tv697 = this.targetPosition2d;\n\tgoto L_0137;\n\tv928 = *([v899 @ X0_v87+E0]);\n\tv929 = v928 == 0;\n\tv930 = ~v929;\n\tif (v930) goto L_0137;\n\tv932 = \"il2cpp_codegen_runtime_class_init\"(v899, v682, v358, v47, v48, v49, v50, v51, v324, v312, v300, v288, v224, v216, v58, v59);\nL_0137:\n\t// 311 MakeStruct v648 @ AGG99D1BC_0_v5 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), v697.value (UnityEngine.Vector2), v697.value.y (System.Single)\n\tv672 = UnityEngine.Vector2::op_Implicit(v648);\n\tv938 = UnityEngine.Transform::TransformPoint(v687, v672);\n\tgoto L_0157;\n\tv945 = *([v941 @ X0_v91+E0]);\n\tv946 = v945 == 0;\n\tv947 = ~v946;\n\tif (v947) goto L_0157;\n\tv949 = \"il2cpp_codegen_runtime_class_init\"(v941, v923, v358, v47, v48, v49, v50, v51, v938, v939, v940, v288, v224, v216, v58, v59);\nL_0157:\n\t// 343 MakeStruct v909 @ AGG99D210_0_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v665 @ stack_-90_v6 (UnityEngine.Vector3), v771.y (System.Single), v771.z (System.Single)\n\tv922 = UnityEngine.Vector3::op_Addition(v909, v938);\nL_0166:\n\tv388 = UnityEngine.GameObject::get_transform(v71);\n\tv773 = UnityEngine.Transform::get_position(v388);\n\tgoto L_0183;\n\tv795 = *([v784 @ X0_v28+E0]);\n\tv796 = v795 == 0;\n\tv797 = ~v796;\n\tif (v797) goto L_0183;\n\tv799 = \"il2cpp_codegen_runtime_class_init\"(v784, v772, v358, v47, v48, v49, v50, v51, v773, v781, v782, v289, v225, v217, v58, v59);\nL_0183:\n\t// 387 MakeStruct v162 @ AGG99D28C_0_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v922 @ V0_v36 (UnityEngine.Vector3), v341.m_value (System.Int32), [v353 @ X23_v7]\n\tv806 = UnityEngine.Vector3::op_Subtraction(v162, v773);\n\tv809 = 0x158A620(&v806 @ V0_v9 (UnityEngine.Vector3), 0, 0, v47, v48, v49, v50, v51, v806, v806.y, v806.z, v773, v773.y, v773.z, v58, v59);\n\tgoto L_019E;\n\tv819 = *([v812 @ X0_v33 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv820 = v819 == 0;\n\tv821 = ~v820;\n\tif (v821) goto L_019E;\n\tv823 = \"il2cpp_codegen_runtime_class_init\"(v812, v370, v358, v47, v48, v49, v50, v51, v806, v807, v302, v290, v226, v218, v58, v59);\nL_019E:\n\tv825 = 0x6D29A0(UnityEngine.Mathf, 0, 0, v47, v48, v49, v50, v51, v806.y, v806, v806.z, v773, v773.y, v773.z, v58, v59);\n\tv846 = v806.y * 57.29578f;\n\tv847 = HutongGames.PlayMaker.FsmFloat::get_Value(this.rotationOffset);\n\tgoto L_01B4;\n\tv871 = *([v857 @ X0_v37+E0]);\n\tv872 = v871 == 0;\n\tv873 = ~v872;\n\tif (v873) goto L_01B4;\n\tv875 = \"il2cpp_codegen_runtime_class_init\"(v857, v371, v358, v47, v48, v49, v50, v51, v847, v845, v302, v290, v226, v218, v58, v59);\nL_01B4:\n\tv877 = v846 - v847;\n\tv327 = UnityEngine.Quaternion::Euler(0f, 0f, v877);\n\tthis.desiredRotation = v327;\n\tthis.desiredRotation.y = v327.y;\n\tthis.desiredRotation.z = v327.z;\n\tthis.desiredRotation.w = v327.w;\n\tv892 = HutongGames.PlayMaker.FsmFloat::get_Value(this.speed);\n\tv894 = UnityEngine.Time::get_deltaTime();\n\tv902 = v892 * v894;\n\t// 476 MakeStruct v131 @ AGG99D398_0_v3 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), this.lastRotation (UnityEngine.Quaternion), this.lastRotation.y (System.Single), this.lastRotation.z (System.Single), this.lastRotation.w (System.Single)\n\tv328 = UnityEngine.Quaternion::Slerp(v131, v327, v902);\n\tthis.lastRotation = v328;\n\tthis.lastRotation.y = v328.y;\n\tthis.lastRotation.z = v328.z;\n\tthis.lastRotation.w = v328.w;\n\tv391 = UnityEngine.GameObject::get_transform(v71);\n\tv603 = this.lastRotation.y;\n\tv602 = this.lastRotation.z;\n\tv601 = this.lastRotation.w;\n\t// 496 MakeStruct v125 @ AGG99D3C0_1_v3 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), this.lastRotation (UnityEngine.Quaternion), this.lastRotation.y (System.Single), this.lastRotation.z (System.Single), this.lastRotation.w (System.Single)\n\tUnityEngine.Transform::set_rotation(v391, v125);\n\tv954 = HutongGames.PlayMaker.FsmBool::get_Value(this.debug);\n\tv956 = v954 == 0;\n\tif (v956) goto L_022D;\n\tv393 = UnityEngine.GameObject::get_transform(v71);\n\tv989 = UnityEngine.Transform::get_position(v393);\n\tv603 = v989.y;\n\tv602 = v989.z;\n\tv996 = UnityEngine.Color::get_grey();\n\tgoto L_022A;\n\n// ... truncated")]
		private unsafe void DoSmoothLookAt()
		{
			//IL_0930: Expected O, but got I
			//IL_01d9: Expected F4, but got O
			//IL_045b: Expected F4, but got I4
			//IL_0468: Expected F4, but got O
			//IL_02ed: Expected O, but got I
			//IL_07e1: Expected O, but got I
			//IL_07f7: Expected O, but got I
			//IL_0769: Expected F4, but got I4
			//IL_0776: Expected F4, but got O
			//IL_078f: Expected F4, but got O
			//IL_079c: Expected O, but got I4
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget == null)
			{
				return;
			}
			GameObject value = targetObject.Value;
			if (previousGo != ownerDefaultTarget)
			{
				Transform transform = ownerDefaultTarget.transform;
				Quaternion quaternion = (lastRotation = transform.rotation);
				lastRotation.y = quaternion.y;
				lastRotation.z = quaternion.z;
				lastRotation.w = quaternion.w;
				desiredRotation = quaternion;
				desiredRotation.y = quaternion.y;
				desiredRotation.z = quaternion.z;
				desiredRotation.w = quaternion.w;
				previousGo = ownerDefaultTarget;
			}
			FsmVector2 fsmVector = targetPosition2d;
			Vector2 value2 = fsmVector.value;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			Vector3 vector2 = default(Vector3);
			if (!targetPosition.IsNone)
			{
				Vector3 value3 = targetPosition.Value;
				Vector3 vector = default(Vector3);
				vector.x = vector2.x;
				object obj = default(object);
				vector.y = (float)obj;
				vector.z = 0f;
				Vector3 vector3 = vector + value3;
			}
			int num;
			object obj2;
			Vector3 vector8 = default(Vector3);
			if (value != null)
			{
				Transform transform2 = value.transform;
				Vector3 position = transform2.position;
				Vector3 zero = Vector3.zero;
				if (!targetPosition.IsNone)
				{
					Vector3 value4 = targetPosition.Value;
					Vector3 vector4 = zero + value4;
				}
				bool isNone = targetPosition2d.IsNone;
				num = (int)((long)(IntPtr)vector2 | 4L);
				obj2 = (long)(IntPtr)vector2 + 8L;
				if (!targetPosition2d.IsNone || !targetPosition.IsNone)
				{
					Transform transform3 = value.transform;
					FsmVector2 fsmVector2 = targetPosition2d;
					Vector2 vector5 = default(Vector2);
					vector5.x = fsmVector2.value.x;
					vector5.y = fsmVector2.value.y;
					Vector3 position2 = vector5;
					Vector3 vector6 = transform3.TransformPoint(position2);
					Vector3 vector7 = default(Vector3);
					vector7.x = vector2.x;
					vector7.y = position.y;
					vector7.z = position.z;
					vector8 = vector7 + vector6;
				}
			}
			else
			{
				num = (int)((long)(IntPtr)vector2 | 4L);
				obj2 = (long)(IntPtr)vector2 + 8L;
				if ((object)ownerDefaultTarget == null)
				{
					NullReferenceException ex = new NullReferenceException();
					throw new NullReferenceException();
				}
			}
			Transform transform4 = ownerDefaultTarget.transform;
			Vector3 position3 = transform4.position;
			Vector3 vector9 = default(Vector3);
			vector9.x = vector8.x;
			vector9.y = ((int*)num)->m_value;
			vector9.z = (float)obj2;
			Vector3 vector10 = vector9 - position3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158A620 (inside UnityEngine.Vector3::get_zero +0x6C)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D29A0 (native atan2f)");
			float num2 = vector10.y * 57.29578f;
			float value5 = rotationOffset.Value;
			float z = num2 - value5;
			Quaternion quaternion2 = (desiredRotation = Quaternion.Euler(0f, 0f, z));
			desiredRotation.y = quaternion2.y;
			desiredRotation.z = quaternion2.z;
			desiredRotation.w = quaternion2.w;
			float value6 = speed.Value;
			float deltaTime = Time.deltaTime;
			float t = value6 * deltaTime;
			Quaternion a = default(Quaternion);
			a.x = lastRotation.x;
			a.y = lastRotation.y;
			a.z = lastRotation.z;
			a.w = lastRotation.w;
			Quaternion quaternion3 = (lastRotation = Quaternion.Slerp(a, quaternion2, t));
			lastRotation.y = quaternion3.y;
			lastRotation.z = quaternion3.z;
			lastRotation.w = quaternion3.w;
			Transform transform5 = ownerDefaultTarget.transform;
			float y = lastRotation.y;
			float z2 = lastRotation.z;
			float w = lastRotation.w;
			Quaternion rotation = default(Quaternion);
			rotation.x = lastRotation.x;
			rotation.y = lastRotation.y;
			rotation.z = lastRotation.z;
			rotation.w = lastRotation.w;
			transform5.rotation = rotation;
			bool value7 = debug.Value;
			bool flag = !value7;
			float y2 = quaternion2.y;
			Quaternion quaternion4 = quaternion2;
			value2 = (Vector2)lastRotation;
			if (!flag)
			{
				Transform transform6 = ownerDefaultTarget.transform;
				Vector3 position4 = transform6.position;
				y = position4.y;
				z2 = position4.z;
				Color grey = Color.grey;
				Vector3 end = default(Vector3);
				end.x = vector8.x;
				end.y = ((int*)num)->m_value;
				end.z = (float)obj2;
				Debug.DrawLine(position4, end, grey);
				y2 = (float)obj2;
				quaternion4 = (Quaternion)((int*)num)->m_value;
				w = vector8.x;
				value2 = position4;
			}
			if (finishEvent != null)
			{
				object obj3 = (long)(IntPtr)this + 176L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CC508 (inside UnityEngine.Quaternion::Internal_MakePositive +0x9C)");
				object obj4 = (long)(IntPtr)this + 160L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10CC508 (inside UnityEngine.Quaternion::Internal_MakePositive +0x9C)");
				Vector3 vector11 = default(Vector3);
				vector11.x = value2.x;
				vector11.y = y;
				vector11.z = z2;
				Vector3 to = default(Vector3);
				to.x = value2.x;
				to.y = y;
				to.z = z2;
				float f = Vector3.Angle(vector11, to);
				float num3 = Mathf.Abs(f);
				float value8 = finishTolerance.Value;
				bool flag2 = num3 < value8;
				bool flag3 = !flag2;
				float num4 = num3 - value8;
				bool flag4 = num4 == 0f;
				bool flag5 = !flag4;
				if (!(flag3 && flag5))
				{
					Fsm.Event(finishEvent);
				}
			}
		}

		[Token(Token = "0x6000E44")]
		[Address(RVA = "0x99D560", Offset = "0x99D560", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SmoothLookAt2d()
		{
		}
	}
}
