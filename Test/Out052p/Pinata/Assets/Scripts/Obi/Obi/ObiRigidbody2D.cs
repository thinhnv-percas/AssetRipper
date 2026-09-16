using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[ExecuteInEditMode]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x744350", Offset = "0x744350")]
	[Token(Token = "0x200002C")]
	public class ObiRigidbody2D : ObiRigidbodyBase
	{
		[Token(Token = "0x40000AB")]
		[FieldOffset(Offset = "0xA0")]
		private Rigidbody2D unityRigidbody;

		[Token(Token = "0x600024E")]
		[Address(RVA = "0xC32D9C", Offset = "0xC32D9C", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1F00F00]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023199]) = v38;\nL_0017:\n\tv43 = UnityEngine.Component::GetComponent(this);\n\tthis.unityRigidbody = v43;\n\tObi.ObiRigidbodyBase::Awake(this);\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Awake()
		{
			Rigidbody2D component = GetComponent<Rigidbody2D>();
			unityRigidbody = component;
			base.Awake();
		}

		[Token(Token = "0x600024F")]
		[Address(RVA = "0xC32DF8", Offset = "0xC32DF8", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = UnityEngine.Rigidbody2D::get_velocity(this.unityRigidbody);\n\tv64 = UnityEngine.Rigidbody2D::get_velocity(this.unityRigidbody);\n\tv26 = 0;\n\tv103 = 0x1586898(&v26 @ stack_-40_v2 (UnityEngine.Vector3), 0, v52, v53, v54, v55, v56, v57, v17, v64.y, 0, v58, v59, v60, v61, v62);\n\tthis.velocity = 0;\n\tthis.velocity.z = 0f;\n\tv105 = UnityEngine.Rigidbody2D::get_angularVelocity(this.unityRigidbody);\n\tv86 = v105 * 0.017453292f;\n\tv74 = 0;\n\tv110 = 0x1586898(&v74 @ stack_-50_v1 (UnityEngine.Vector3), 0, v52, v53, v54, v55, v56, v57, 0, 0, v86, v58, v59, v60, v61, v62);\n\tv113 = this + 0x28;\n\tthis.angularVelocity = 0;\n\tthis.angularVelocity.z = 0f;\n\tv115 = 0x103B828(v113, this.unityRigidbody, this.kinematicForParticles, 0, v54, v55, v56, v57, 0, 0, v86, v58, v59, v60, v61, v62);\n\tv97 = Obi.ObiRigidbodyBase::get_OniRigidbody(this);\n\tOni::UpdateRigidbody(v97, v113);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override void UpdateIfNeeded()
		{
			Vector2 vector = unityRigidbody.velocity;
			Vector2 vector2 = unityRigidbody.velocity;
			Vector3 vector3 = default(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			velocity = default(Vector3);
			velocity.z = 0f;
			float num = unityRigidbody.angularVelocity;
			float num2 = num * ((float)Math.PI / 180f);
			Vector3 vector4 = default(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			ref Oni.Rigidbody reference = ref *(Oni.Rigidbody*)((long)(IntPtr)this + 40L);
			angularVelocity = default(Vector3);
			angularVelocity.z = 0f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @103B828 (inside Oni::GetProfilingInfo +0xA18)");
			IntPtr rigidbody = base.OniRigidbody;
			Oni.UpdateRigidbody(rigidbody, ref reference);
		}

		[Token(Token = "0x6000250")]
		[Address(RVA = "0xC32EEC", Offset = "0xC32EEC", Length = "0x1D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv30 = *([1F03BE8]);\n\tv31 = *([v30 @ X8_v16]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([202319A]) = v50;\nL_001A:\n\tv52 = UnityEngine.Application::get_isPlaying();\n\tv54 = v52 == 0;\n\tif (v54) goto L_009C;\n\tv60 = UnityEngine.Rigidbody2D::get_isKinematic(this.unityRigidbody);\n\tv152 = v60 == 0;\n\tv153 = ~v152;\n\tif (v153) goto L_002C;\n\tv154 = ~this.kinematicForParticles;\n\tv62 = ~v154;\n\tif (v62) goto L_009C;\nL_002C:\n\tv158 = Obi.ObiRigidbodyBase::get_OniRigidbody(this);\n\tv108 = this + 0x6C;\n\tOni::GetRigidbodyVelocity(v158, v108);\n\tgoto L_0049;\n\tv167 = *([v163 @ X0_v11+E0]);\n\tv168 = v167 == 0;\n\tv169 = ~v168;\n\tif (v169) goto L_0049;\n\tv171 = \"il2cpp_codegen_runtime_class_init\"(v163, v108, v106, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0049:\n\t// 73 MakeStruct v79 @ AGGC32FB8_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.oniVelocities (Oni+RigidbodyVelocities), this.oniVelocities.linearVelocity.y (System.Single), this.oniVelocities.linearVelocity.z (System.Single)\n\t// 74 MakeStruct v76 @ AGGC32FB8_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.velocity (UnityEngine.Vector3), this.velocity.y (System.Single), this.velocity.z (System.Single)\n\tv92 = UnityEngine.Vector3::op_Subtraction(v79, v76);\n\tv179 = UnityEngine.Rigidbody2D::get_velocity(this.unityRigidbody);\n\tv120 = 0;\n\tv183 = 0x1588A6C(&v120 @ stack_-58_v1, 0, 0, v35, v36, v37, v38, v39, v92, v92.y, v92.z, this.velocity, this.velocity.y, this.velocity.z, v46, v47);\n\tv144 = 0xC3FC20(v183, 0, 0, v35, v36, v37, v38, v39, v92, v92.y, v92.z, this.velocity, this.velocity.y, this.velocity.z, v46, v47);\n\treturn;\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_006C;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_006C;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_006C:\n\tV2 = stack[8];\n\tV3 = stack[C];\n\tV0 = V8;\n\tV1 = V9;\n\tX0 = 0;\n\t// 113 MakeStruct AGGC33028_0, typeof(UnityEngine.Vector2), V0, V1\n\t// 114 MakeStruct AGGC33028_1, typeof(UnityEngine.Vector2), V2, V3\n\tV0 = UnityEngine.Vector2::op_Addition(AGGC33028_0, AGGC33028_1, X0);\n\tV1 = *([V0+4]);\n\tX0 = X20;\n\tX1 = 0;\n\t// 119 MakeStruct AGGC33034_1, typeof(UnityEngine.Vector2), V0, V1\n\tUnityEngine.Rigidbody2D::set_velocity(X0, AGGC33034_1, X1);\n\tX20 = *([X19+A0]);\n\tif (TEMP) goto L_009D;\n\tX0 = X20;\n\tX1 = 0;\n\tV0 = UnityEngine.Rigidbody2D::get_angularVelocity(X0, X1);\n\tX0 = X19 + 0x78;\n\tX1 = 0 | 2;\n\tX2 = 0;\n\tV8 = V0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = X19 + 0x90;\n\tX1 = 0 | 2;\n\tX2 = 0;\n\tV9 = V0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV1 = 57.29578f;\n\tV0 = V9 - V0;\n\tX0 = X20;\n\tX1 = 0;\n\tV0 = V0 * V1;\n\tV0 = V8 + V0;\n\tUnityEngine.Rigidbody2D::set_angularVelocity(X0, V0, X1);\nL_009C:\n\treturn;\nL_009D:\n\t;\n\tv110 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override void UpdateVelocities()
		{
			//IL_009e: Expected F4, but got O
			//IL_013a: Expected O, but got I4
			if (Application.isPlaying && (unityRigidbody.isKinematic || !kinematicForParticles))
			{
				IntPtr rigidbody = base.OniRigidbody;
				Oni.GetRigidbodyVelocity(rigidbody, ref *(Oni.RigidbodyVelocities*)((long)(IntPtr)this + 108L));
				Vector3 vector = default(Vector3);
				vector.x = (float)oniVelocities;
				vector.y = oniVelocities.linearVelocity.y;
				vector.z = oniVelocities.linearVelocity.z;
				Vector3 vector2 = default(Vector3);
				vector2.x = velocity.x;
				vector2.y = velocity.y;
				vector2.z = velocity.z;
				Vector3 vector3 = vector - vector2;
				Vector2 vector4 = unityRigidbody.velocity;
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1588A6C (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x78)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @C3FC20 (inside Obi.ObiRopeMeshRenderer::.cctor +0x6C)");
			}
		}

		[Token(Token = "0x6000251")]
		[Address(RVA = "0xC330BC", Offset = "0xC330BC", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1F00568]);\n\tv19 = *([v18 @ X8_v9]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202319B]) = v38;\nL_0019:\n\tgoto L_0025;\n\tv45 = *([v41 @ X0_v2+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0025;\n\tv49 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tObi.ObiRigidbodyBase::.ctor(this);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiRigidbody2D()
		{
		}
	}
}
