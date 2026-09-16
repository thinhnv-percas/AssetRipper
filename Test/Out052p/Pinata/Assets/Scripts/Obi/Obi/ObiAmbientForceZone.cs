using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Token(Token = "0x2000052")]
	public class ObiAmbientForceZone : ObiExternalForce
	{
		[Token(Token = "0x6000382")]
		[Address(RVA = "0xE3D80C", Offset = "0xE3D80C", Length = "0x3A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv32 = &v33 @ stack_-10_v2;\n\tgoto L_0022;\n\tv44 = *([1EEC640]);\n\tv45 = *([v44 @ X8_v45]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, actor, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60);\n\tv63 = 0 | 1;\n\t*([20246F3]) = v63;\nL_0022:\n\t*([v32 @ X29_v1-90]) = 0;\n\t*([v32 @ X29_v1-80]) = 0;\n\t*([v32 @ X29_v1-B0]) = 0;\n\t*([v32 @ X29_v1-A0]) = 0;\n\tv342 = UnityEngine.Component::get_transform(actor.m_Solver);\n\tv525 = UnityEngine.Transform::get_worldToLocalMatrix(v342);\n\tv424 = UnityEngine.Component::get_transform(this);\n\tv660 = &v319 @ stack_-140;\n\tv662 = UnityEngine.Transform::get_localToWorldMatrix(v424);\n\tv319 = *([v660 @ X8_v7]);\n\tgoto L_0058;\n\tv669 = *([v665 @ X0_v15+E0]);\n\tv670 = v669 == 0;\n\tv671 = ~v670;\n\tif (v671) goto L_0058;\n\tv673 = \"il2cpp_codegen_runtime_class_init\"(v665, v661, methodInfo, v48, v49, v50, v51, v52, v64, v54, v55, v56, v57, v58, v59, v60);\nL_0058:\n\tv717 = *([v32 @ X29_v1-F0]);\n\tv688 = UnityEngine.Matrix4x4::op_Multiply(&v717 @ V3_v7 (System.Single), &v319 @ stack_-140);\n\t*([v32 @ X29_v1-90]) = v688.m02;\n\t*([v32 @ X29_v1-80]) = v688.m03;\n\t*([v32 @ X29_v1-B0]) = v688.m00;\n\t*([v32 @ X29_v1-A0]) = v688.m01;\n\tgoto L_0090;\n\tv699 = *([v695 @ X0_v19+E0]);\n\tv700 = v699 == 0;\n\tv701 = ~v700;\n\tif (v701) goto L_0090;\n\tv703 = \"il2cpp_codegen_runtime_class_init\"(v695, v686, v687, v48, v49, v50, v51, v52, v691, v690, v693, v692, v57, v58, v59, v60);\nL_0090:\n\tv707 = UnityEngine.Vector3::get_forward();\n\tv716 = Obi.ObiExternalForce::GetTurbulence(this, this.turbulence);\n\tv717 = this.intensity + v716;\n\tv722 = UnityEngine.Vector3::op_Multiply(v707, v717);\n\tv725 = &v33 @ stack_-10_v2 - 0xB0;\n\tv727 = 0x10C2868(v725, 0, 0, v48, v49, v50, v51, v52, v722, v722.y, v722.z, v717, v57, v58, v59, v60);\n\tgoto L_00BA;\n\tv736 = *([v732 @ X0_v26+E0]);\n\tv737 = v736 == 0;\n\tv738 = ~v737;\n\tif (v738) goto L_00BA;\n\tv740 = \"il2cpp_codegen_runtime_class_init\"(v732, v726, v687, v48, v49, v50, v51, v52, v722, v723, v724, v717, v57, v58, v59, v60);\nL_00BA:\n\tv747 = UnityEngine.Vector4::op_Implicit(v722);\n\tv271 = v747.y;\n\tv262 = v747.z;\n\tv717 = v747.w;\n\tv755 = Obi.ObiActor::get_usesCustomExternalForces(actor);\n\tv767 = v755 == 0;\n\tif (v767) goto L_012A;\n\tv769 = actor.m_ActiveParticleCount < 1;\n\tif (v769) goto L_018F;\nL_00DC:\n\tv324 = Obi.ObiSolver::get_wind(actor.m_Solver);\n\tv335 = actor.solverIndices;\n\tv849 = v109 < v335.Length;\n\tv159 = ~v849;\n\tif (v159) goto L_0192;\n\tv857 = Obi.ObiNativeVector4List::get_Item(v324, v335[v109 @ X23_v10 (System.Int32)]);\n\tgoto L_010E;\n\tv873 = *([v858 @ X0_v48+E0]);\n\tv874 = v873 == 0;\n\tv875 = ~v874;\n\tif (v875) goto L_010E;\n\tv877 = \"il2cpp_codegen_runtime_class_init\"(v858, v856, v855, v48, v49, v50, v51, v52, v267, v270, v261, v264, v90, v87, v84, v81);\nL_010E:\n\t// 270 MakeStruct v776 @ AGGE3DA80_0_v6 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), v267 @ V0_v19 (UnityEngine.Vector4), v271 @ V1_v13 (System.Single), v262 @ V2_v13 (System.Single), v717 @ V3_v7 (System.Single)\n\tv267 = UnityEngine.Vector4::op_Addition(v776, v747);\n\tv271 = v267.y;\n\tv262 = v267.z;\n\tv717 = v267.w;\n\tv835 = Obi.ObiNativeVector4List::set_Item(v324, v335[v109 @ X23_v10 (System.Int32)], v267);\n\tv109 = v109 + 1;\n\tv803 = v109 < actor.m_ActiveParticleCount;\n\tif (v803) goto L_00DC;\n\tgoto L_018F;\nL_012A:\n\tv771 = actor.m_ActiveParticleCount < 1;\n\tif (v771) goto L_018F;\nL_0131:\n\tv325 = Obi.ObiSolver::get_externalForces(actor.m_Solver);\n\tv336 = actor.solverIndices;\n\tv850 = v110 < v336.Length;\n\tv161 = ~v850;\n\tif (v161) goto L_0192;\n\tv868 = Obi.ObiNativeVector4List::get_Item(v325, v336[v110 @ X23_v7 (System.Int32)]);\n\tgoto L_0163;\n\tv884 = *([v869 @ X0_v37+E0]);\n\tv885 = v884 == 0;\n\tv886 = ~v885;\n\tif (v886) goto L_0163;\n\tv888 = \"il2cpp_codegen_runtime_class_init\"(v869, v867, v866, v48, v49, v50, v51, v52, v268, v271, v262, v265, v91, v88, v85, v82);\nL_0163:\n\t// 355 MakeStruct v774 @ AGGE3DB48_0_v6 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), v268 @ V0_v16 (UnityEngine.Vector4), v271 @ V1_v13 (System.Single), v262 @ V2_v13 (System.Single), v717 @ V3_v7 (System.Single)\n\tv268 = UnityEngine.Vector4::op_Addition(v774, v747);\n\tv271 = v268.y;\n\tv262 = v268.z;\n\tv717 = v268.w;\n\tv834 = Obi.ObiNativeVector4List::set_Item(v325, v336[v110 @ X23_v7 (System.Int32)], v268);\n\tv110 = v110 + 1;\n\tv802 = v110 < actor.m_ActiveParticleCount;\n\tif (v802) goto L_0131;\nL_018F:\n\treturn;\n\tv440 = new System.NullReferenceException();\nL_0192:\n\tv523 = new System.IndexOutOfRangeException();\n\tthrow v523;\n\treturn;\n// 301 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override void ApplyForcesToActor(ObiActor actor)
		{
			//IL_0072: Expected F4, but got I
			//IL_007f: Expected O, but got Ref
			//IL_007f: Expected O, but got Ref
			//IL_00ff: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			Transform transform = actor.solver.transform;
			Matrix4x4 worldToLocalMatrix = transform.worldToLocalMatrix;
			Transform transform2 = base.transform;
			object obj4 = default(object);
			object obj3 = obj4;
			Matrix4x4 localToWorldMatrix = transform2.localToWorldMatrix;
			obj4 = obj3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v32 @ X29_v1-F0]");
			float num = 0f;
			Matrix4x4 matrix4x = (Matrix4x4)(&num) * (Matrix4x4)(&obj4);
			_ = matrix4x.m02;
			_ = matrix4x.m03;
			_ = matrix4x.m00;
			_ = matrix4x.m01;
			Vector3 forward = Vector3.forward;
			float num2 = GetTurbulence(turbulence);
			num = intensity + num2;
			Vector3 vector = forward * num;
			object obj5 = (long)(IntPtr)obj2 - 176L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10C2868 (inside UnityEngine.Matrix4x4::op_Multiply +0x214)");
			Vector4 vector2 = vector;
			float y = vector2.y;
			float z = vector2.z;
			num = vector2.w;
			if (actor.usesCustomExternalForces)
			{
				if (actor.activeParticleCount < 1)
				{
					return;
				}
				int num3 = 0;
				Vector4 value = vector2;
				Vector4 vector4 = default(Vector4);
				while (true)
				{
					ObiNativeVector4List wind = actor.solver.wind;
					int[] solverIndices = actor.solverIndices;
					if (num3 >= solverIndices.Length)
					{
						break;
					}
					Vector4 vector3 = wind.get_Item(solverIndices[num3]);
					vector4.x = value.x;
					vector4.y = y;
					vector4.z = z;
					vector4.w = num;
					value = vector4 + vector2;
					y = value.y;
					z = value.z;
					num = value.w;
					wind.set_Item(solverIndices[num3], value);
					num3++;
					if (num3 >= actor.activeParticleCount)
					{
						return;
					}
				}
			}
			else
			{
				if (actor.activeParticleCount < 1)
				{
					return;
				}
				int num4 = 0;
				Vector4 value2 = vector2;
				Vector4 vector6 = default(Vector4);
				while (true)
				{
					ObiNativeVector4List externalForces = actor.solver.externalForces;
					int[] solverIndices2 = actor.solverIndices;
					if (num4 >= solverIndices2.Length)
					{
						break;
					}
					Vector4 vector5 = externalForces.get_Item(solverIndices2[num4]);
					vector6.x = value2.x;
					vector6.y = y;
					vector6.z = z;
					vector6.w = num;
					value2 = vector6 + vector2;
					y = value2.y;
					z = value2.z;
					num = value2.w;
					externalForces.set_Item(solverIndices2[num4], value2);
					num4++;
					if (num4 >= actor.activeParticleCount)
					{
						return;
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x6000383")]
		[Address(RVA = "0xE3DC48", Offset = "0xE3DC48", Length = "0x118")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv20 = *([1EB3D88]);\n\tv21 = *([v20 @ X8_v13]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20246F4]) = v40;\nL_0016:\n\tv43 = UnityEngine.Component::get_transform(this);\n\tv48 = UnityEngine.Transform::get_localToWorldMatrix(v43);\n\tv50 = v48.m00;\n\tUnityEngine.Gizmos::set_matrix(&v50 @ stack_-70_v1 (System.Single));\n\tv80 = 0;\n\tv86 = 0x101059C(&v80 @ stack_-C0_v1, 0, v24, v25, v26, v27, v28, v29, 0, 0.7f, 1f, 1f, v34, v35, v36, v37);\n\t// 71 MakeStruct v93 @ AGGE3DCF0_0_v1 (UnityEngine.Color), typeof(UnityEngine.Color), 0, v163 @ stack_-BC, 0, v166 @ stack_-B4\n\tUnityEngine.Gizmos::set_color(v93);\n\tv170 = Obi.ObiExternalForce::GetTurbulence(this, 1f);\n\tgoto L_005E;\n\tv178 = *([v174 @ X0_v11+E0]);\n\tv179 = v178 == 0;\n\tv180 = ~v179;\n\tif (v180) goto L_005E;\n\tv182 = \"il2cpp_codegen_runtime_class_init\"(v174, v84, v24, v25, v26, v27, v28, v29, v170, v162, v164, v165, v34, v35, v36, v37);\nL_005E:\n\tv114 = v170 + 0.5f;\n\tObi.ObiUtils::DrawArrowGizmo(v114, 0.2f, 0.3f, 0.2f);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 81 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void OnDrawGizmosSelected()
		{
			//IL_0028: Expected O, but got Ref
			//IL_0036: Expected O, but got I4
			//IL_005b: Expected F4, but got O
			//IL_0076: Expected F4, but got O
			Transform transform = base.transform;
			float m = transform.localToWorldMatrix.m00;
			Gizmos.matrix = (Matrix4x4)(&m);
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @101059C (inside UnityEngine.ClassLibraryInitializer::Init +0x8)");
			Color color = default(Color);
			color.r = 0f;
			object obj2 = default(object);
			color.g = (float)obj2;
			color.b = 0f;
			object obj3 = default(object);
			color.a = (float)obj3;
			Gizmos.color = color;
			float num = GetTurbulence(1f);
			float bodyLenght = num + 0.5f;
			ObiUtils.DrawArrowGizmo(bodyLenght, 0.2f, 0.3f, 0.2f);
		}

		[Token(Token = "0x6000384")]
		[Address(RVA = "0xE3DD60", Offset = "0xE3DD60", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.turbulenceFrequency = 1f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiAmbientForceZone()
		{
			turbulenceFrequency = 1f;
		}
	}
}
