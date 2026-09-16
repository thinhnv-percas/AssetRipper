using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75AACC", Offset = "0x75AACC")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75AACC", Offset = "0x75AACC")]
	[Token(Token = "0x20002C9")]
	public class LookAt2d : FsmStateAction
	{
		[RequiredField]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BE5A4", Offset = "0x7BE5A4")]
		[Token(Token = "0x4001849")]
		[FieldOffset(Offset = "0x50")]
		public FsmOwnerDefault gameObject;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BE5F0", Offset = "0x7BE5F0")]
		[Token(Token = "0x400184A")]
		[FieldOffset(Offset = "0x58")]
		public FsmVector2 vector2Target;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BE628", Offset = "0x7BE628")]
		[Token(Token = "0x400184B")]
		[FieldOffset(Offset = "0x60")]
		public FsmVector3 vector3Target;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BE660", Offset = "0x7BE660")]
		[Token(Token = "0x400184C")]
		[FieldOffset(Offset = "0x68")]
		public FsmFloat rotationOffset;

		[AttributeAttribute(Type = typeof(TitleAttribute), RVA = "0x7BE698", Offset = "0x7BE698")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BE698", Offset = "0x7BE698")]
		[Token(Token = "0x400184D")]
		[FieldOffset(Offset = "0x70")]
		public FsmBool debug;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BE6F8", Offset = "0x7BE6F8")]
		[Token(Token = "0x400184E")]
		[FieldOffset(Offset = "0x78")]
		public FsmColor debugLineColor;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7BE730", Offset = "0x7BE730")]
		[Token(Token = "0x400184F")]
		[FieldOffset(Offset = "0x80")]
		public bool everyFrame;

		[Token(Token = "0x6000DF2")]
		[Address(RVA = "0xA3B2B4", Offset = "0xA3B2B4", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = *([1EB7B58]);\n\tv21 = *([v20 @ X8_v6]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2021E4A]) = v40;\nL_0014:\n\tthis.gameObject = 0;\n\tthis.vector2Target = 0;\n\tv44 = new HutongGames.PlayMaker.FsmVector3();\n\tHutongGames.PlayMaker.FsmVector3::.ctor(v44);\n\tv44.useVariable = 1;\n\tthis.vector3Target = v44;\n\tv51 = HutongGames.PlayMaker.FsmBool::op_Implicit(0);\n\tthis.debug = v51;\n\tv55 = UnityEngine.Color::get_green();\n\tv61 = HutongGames.PlayMaker.FsmColor::op_Implicit(v55);\n\tthis.debugLineColor = v61;\n\tthis.everyFrame = 1;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			gameObject = null;
			vector2Target = null;
			FsmVector3 fsmVector = new FsmVector3();
			fsmVector.useVariable = true;
			vector3Target = fsmVector;
			FsmBool fsmBool = false;
			debug = fsmBool;
			Color green = Color.green;
			FsmColor fsmColor = green;
			debugLineColor = fsmColor;
			everyFrame = true;
		}

		[Token(Token = "0x6000DF3")]
		[Address(RVA = "0xA3B35C", Offset = "0xA3B35C", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.LookAt2d::DoLookAt(this);\n\tv12 = ~this.everyFrame;\n\tif (v12) goto L_0015;\n\treturn;\nL_0015:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			DoLookAt();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6000DF4")]
		[Address(RVA = "0xA3B6D4", Offset = "0xA3B6D4", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.LookAt2d::DoLookAt(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoLookAt();
		}

		[Token(Token = "0x6000DF5")]
		[Address(RVA = "0xA3B398", Offset = "0xA3B398", Length = "0x33C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = &v27 @ stack_-10_v2;\n\tgoto L_0025;\n\tv36 = *([1F0C7D0]);\n\tv37 = *([v36 @ X8_v37]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([2021E4B]) = v56;\nL_0025:\n\tv65 = HutongGames.PlayMaker.Fsm::GetOwnerDefaultTarget(this.fsm, this.gameObject);\n\tgoto L_0037;\n\tv235 = *([v172 @ X8_v7+E0]);\n\tv236 = v235 == 0;\n\tv237 = ~v236;\n\tif (v237) goto L_0037;\n\tv242 = v172;\n\tv239 = \"il2cpp_codegen_runtime_class_init\"(v242, v63, v64, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0037:\n\tv219 = UnityEngine.Object::op_Equality(v65, 0);\n\tv244 = v219 == 0;\n\tv245 = ~v244;\n\tif (v245) goto L_0125;\n\tv164 = this.vector2Target;\n\tv371 = 0x1586898(&v129 @ stack_-80_v5 (UnityEngine.Vector3), 0, 0, v41, v42, v43, v44, v45, v164.value, v164.value.y, 0, v49, v50, v51, v52, v53);\n\tv372 = HutongGames.PlayMaker.NamedVariable::get_IsNone(this.vector3Target);\n\tv374 = v372 == 0;\n\tv375 = ~v374;\n\tif (v375) goto L_007D;\n\tv398 = HutongGames.PlayMaker.FsmVector3::get_Value(this.vector3Target);\n\tgoto L_006E;\n\tv408 = *([v404 @ X0_v47+E0]);\n\tv409 = v408 == 0;\n\tv410 = ~v409;\n\tif (v410) goto L_006E;\n\tv412 = \"il2cpp_codegen_runtime_class_init\"(v404, v393, v144, v41, v42, v43, v44, v45, v398, v400, v401, v49, v50, v51, v52, v53);\nL_006E:\n\t// 110 MakeStruct v379 @ AGGA3B4D4_0_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v129 @ stack_-80_v5 (UnityEngine.Vector3), v88 @ stack_-7C_v4 (System.Single), 0\n\tv392 = UnityEngine.Vector3::op_Addition(v379, v398);\nL_007D:\n\tv154 = UnityEngine.GameObject::get_transform(v65);\n\tv417 = UnityEngine.Transform::get_position(v154);\n\tgoto L_009A;\n\tv426 = *([v422 @ X0_v20+E0]);\n\tv427 = v426 == 0;\n\tv428 = ~v427;\n\tif (v428) goto L_009A;\n\tv430 = \"il2cpp_codegen_runtime_class_init\"(v422, v416, v144, v41, v42, v43, v44, v45, v417, v418, v419, v102, v99, v96, v52, v53);\nL_009A:\n\t// 154 MakeStruct v83 @ AGGA3B550_0_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v123 @ V10_v6 (UnityEngine.Vector3), v119 @ V9_v6 (System.Single), v115 @ V8_v6 (System.Single)\n\tv437 = UnityEngine.Vector3::op_Subtraction(v83, v417);\n\tv441 = 0x158A620(&v437 @ V0_v8 (UnityEngine.Vector3), 0, 0, v41, v42, v43, v44, v45, v437, v437.y, v437.z, v417, v417.y, v417.z, v52, v53);\n\tgoto L_00B5;\n\tv449 = *([v445 @ X0_v25 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv450 = v449 == 0;\n\tv451 = ~v450;\n\tif (v451) goto L_00B5;\n\tv453 = \"il2cpp_codegen_runtime_class_init\"(v445, v440, v144, v41, v42, v43, v44, v45, v437, v438, v201, v190, v100, v97, v52, v53);\nL_00B5:\n\tv456 = 0x6D29A0(UnityEngine.Mathf, 0, 0, v41, v42, v43, v44, v45, v437.y, v437, v437.z, v417, v417.y, v417.z, v52, v53);\n\tv220 = UnityEngine.GameObject::get_transform(v65);\n\tv120 = v437.y * 57.29578f;\n\tv460 = HutongGames.PlayMaker.FsmFloat::get_Value(this.rotationOffset);\n\tgoto L_00D1;\n\tv467 = *([v463 @ X0_v31+E0]);\n\tv468 = v467 == 0;\n\tv469 = ~v468;\n\tif (v469) goto L_00D1;\n\tv471 = \"il2cpp_codegen_runtime_class_init\"(v463, v215, v144, v41, v42, v43, v44, v45, v460, v205, v201, v190, v100, v97, v52, v53);\nL_00D1:\n\tv473 = v120 - v460;\n\tv138 = UnityEngine.Quaternion::Euler(0f, 0f, v473);\n\tUnityEngine.Transform::set_rotation(v220, v138);\n\tv366 = HutongGames.PlayMaker.FsmBool::get_Value(this.debug);\n\tv368 = v366 == 0;\n\tif (v368) goto L_0125;\n\tv156 = UnityEngine.GameObject::get_transform(v65);\n\tv362 = UnityEngine.Transform::get_position(v156);\n\tv361 = v362.y;\n\tv231 = this.debugLineColor;\n\tv481 = UnityEngine.Debug;\n\tv482 = *([v481 @ X0_v39 (Il2CppClass<UnityEngine.Debug>)+12F]) & 2;\n\tv483 = v482 == 0;\n\tif (v483) goto L_0114;\n\tv485 = *([v481 @ X0_v39 (Il2CppClass<UnityEngine.Debug>)+E0]) == 0;\n\tv486 = ~v485;\n\tif (v486) goto L_0114;\n\t*([v26 @ X29_v1-18]) = v362.y;\n\t*([v26 @ X29_v1-14]) = v362;\n\tv361 = *([v26 @ X29_v1-18]);\n\tv362 = *([v26 @ X29_v1-14]);\nL_0114:\n\t// 276 MakeStruct v336 @ AGGA3B6A0_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v362 @ V0_v15 (UnityEngine.Vector3), v361 @ V1_v13 (System.Single), v362.z (System.Single)\n\t// 277 MakeStruct v335 @ AGGA3B6A0_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v392 @ V0_v19 (UnityEngine.Vector3), v392.y (System.Single), v85 @ stack_-78_v5 (System.Single)\n\tUnityEngine.Debug::DrawLine(v336, v335, v231.value);\nL_0125:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 209 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoLookAt()
		{
			//IL_02c6: Expected I, but got O
			//IL_0348: Expected F4, but got I
			//IL_0358: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			GameObject ownerDefaultTarget = Fsm.GetOwnerDefaultTarget(gameObject);
			if (ownerDefaultTarget == null)
			{
				return;
			}
			FsmVector2 fsmVector = vector2Target;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			bool isNone = vector3Target.IsNone;
			bool flag = !isNone;
			bool flag2 = !flag;
			float z = 0f;
			float z2 = 0f;
			float num = default(float);
			float y = num;
			Vector3 vector2 = default(Vector3);
			Vector3 vector = vector2;
			Vector3 vector4 = default(Vector3);
			if (!flag2)
			{
				Vector3 value = vector3Target.Value;
				Vector3 vector3 = default(Vector3);
				vector3.x = vector2.x;
				vector3.y = num;
				vector3.z = 0f;
				vector4 = vector3 + value;
				z = vector4.z;
				z2 = vector4.z;
				y = vector4.y;
				vector = vector4;
			}
			Transform transform = ownerDefaultTarget.transform;
			Vector3 position = transform.position;
			Vector3 vector5 = default(Vector3);
			vector5.x = vector.x;
			vector5.y = y;
			vector5.z = z2;
			Vector3 vector6 = vector5 - position;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158A620 (inside UnityEngine.Vector3::get_zero +0x6C)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D29A0 (native atan2f)");
			Transform transform2 = ownerDefaultTarget.transform;
			float num2 = vector6.y * 57.29578f;
			float value2 = rotationOffset.Value;
			float z3 = num2 - value2;
			Quaternion rotation = Quaternion.Euler(0f, 0f, z3);
			transform2.rotation = rotation;
			if (!debug.Value)
			{
				return;
			}
			Transform transform3 = ownerDefaultTarget.transform;
			Vector3 vector7 = transform3.position;
			float y2 = vector7.y;
			FsmColor fsmColor = debugLineColor;
			IntPtr intPtr = (IntPtr)typeof(Debug);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ X0_v39 (Il2CppClass<UnityEngine.Debug>)+12F]");
			if (0u != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ X0_v39 (Il2CppClass<UnityEngine.Debug>)+E0]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					_ = vector7.y;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ X29_v1-18]");
					y2 = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v26 @ X29_v1-14]");
					vector7 = (Vector3)0;
				}
			}
			Vector3 start = default(Vector3);
			start.x = vector7.x;
			start.y = y2;
			start.z = vector7.z;
			Vector3 end = default(Vector3);
			end.x = vector4.x;
			end.y = vector4.y;
			end.z = z;
			Debug.DrawLine(start, end, fsmColor.value);
		}

		[Token(Token = "0x6000DF6")]
		[Address(RVA = "0xA3B6D8", Offset = "0xA3B6D8", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 1;\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public LookAt2d()
		{
			everyFrame = true;
		}
	}
}
