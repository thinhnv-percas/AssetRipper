using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Token(Token = "0x2000054")]
	public class ObiSphericalForceZone : ObiExternalForce
	{
		[Token(Token = "0x400017A")]
		[FieldOffset(Offset = "0x30")]
		public float radius;

		[Token(Token = "0x400017B")]
		[FieldOffset(Offset = "0x34")]
		public bool radial;

		[Token(Token = "0x600038B")]
		[Address(RVA = "0x102D7E4", Offset = "0x102D7E4", Length = "0x4B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv36 = &v37 @ stack_-10_v2;\n\tgoto L_0024;\n\tv48 = *([1ED8038]);\n\tv49 = *([v48 @ X8_v57]);\n\tv50 = \"il2cpp_codegen_initialize_method\"(v49, actor, methodInfo, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64);\n\tv67 = 0 | 1;\n\t*([202625A]) = v67;\nL_0024:\n\t*([v36 @ X29_v1-D0]) = 0;\n\t*([v36 @ X29_v1-C8]) = 0;\n\t*([v36 @ X29_v1-A0]) = 0;\n\t*([v36 @ X29_v1-90]) = 0;\n\t*([v36 @ X29_v1-C0]) = 0;\n\t*([v36 @ X29_v1-B0]) = 0;\n\tv74 = Obi.ObiExternalForce::GetTurbulence(this, this.turbulence);\n\tv448 = UnityEngine.Component::get_transform(actor.m_Solver);\n\tv578 = &v423 @ stack_-120;\n\tv698 = UnityEngine.Transform::get_worldToLocalMatrix(v448);\n\tv423 = *([v578 @ X8_v6]);\n\tv570 = UnityEngine.Component::get_transform(this);\n\tv874 = &v375 @ stack_-160;\n\tv876 = UnityEngine.Transform::get_localToWorldMatrix(v570);\n\tv375 = *([v874 @ X8_v7]);\n\tgoto L_0085;\n\tv883 = *([v879 @ X0_v16+E0]);\n\tv884 = v883 == 0;\n\tv885 = ~v884;\n\tif (v885) goto L_0085;\n\tv887 = \"il2cpp_codegen_runtime_class_init\"(v879, v875, methodInfo, v52, v53, v54, v55, v56, v74, v58, v59, v60, v61, v62, v63, v64);\nL_0085:\n\tv902 = UnityEngine.Matrix4x4::op_Multiply(&v423 @ stack_-120, &v375 @ stack_-160);\n\t*([v36 @ X29_v1-A0]) = v902.m02;\n\t*([v36 @ X29_v1-90]) = v902.m03;\n\t*([v36 @ X29_v1-C0]) = v902.m00;\n\t*([v36 @ X29_v1-B0]) = v902.m01;\n\tgoto L_00AB;\n\tv912 = *([v908 @ X0_v20+E0]);\n\tv913 = v912 == 0;\n\tv914 = ~v913;\n\tif (v914) goto L_00AB;\n\tv916 = \"il2cpp_codegen_runtime_class_init\"(v908, v900, v901, v52, v53, v54, v55, v56, v905, v904, v907, v906, v61, v62, v63, v64);\nL_00AB:\n\tv920 = UnityEngine.Vector4::get_zero();\n\tv925 = UnityEngine.Vector4::op_Implicit(v920);\n\tv928 = &v37 @ stack_-10_v2 - 0xC0;\n\tv930 = 0x10C27FC(v928, 0, 0, v52, v53, v54, v55, v56, v925, v925.y, v925.z, v920.w, v61, v62, v63, v64);\n\tv932 = UnityEngine.Vector4::op_Implicit(v925);\n\tgoto L_00CE;\n\tv942 = *([v938 @ X0_v27+E0]);\n\tv943 = v942 == 0;\n\tv944 = ~v943;\n\tif (v944) goto L_00CE;\n\tv946 = \"il2cpp_codegen_runtime_class_init\"(v938, v929, v901, v52, v53, v54, v55, v56, v932, v933, v934, v935, v61, v62, v63, v64);\nL_00CE:\n\tv950 = UnityEngine.Vector3::get_forward();\n\tv953 = &v37 @ stack_-10_v2 - 0xC0;\n\tv955 = 0x10C2868(v953, 0, 0, v52, v53, v54, v55, v56, v950, v950.y, v950.z, v932.w, v61, v62, v63, v64);\n\tv957 = UnityEngine.Vector4::op_Implicit(v950);\n\tv972 = actor.m_ActiveParticleCount < 1;\n\tif (v972) goto L_0214;\n\tv977 = this.radius * this.radius;\n\tv978 = this.intensity + v74;\nL_00F8:\n\tv431 = Obi.ObiSolver::get_positions(actor.m_Solver);\n\tv440 = actor.solverIndices;\n\tv1025 = v160 < v440.Length;\n\tv492 = ~v1025;\n\tif (v492) goto L_0217;\n\tv1026 = *([v431 @ X0_v36 (Obi.ObiNativeVector4List)]);\n\tv1030 = Obi.ObiNativeVector4List::get_Item(v431, v440[v160 @ X24_v7 (System.Int32)]);\n\tgoto L_0128;\n\tv1039 = *([v1031 @ X0_v38+E0]);\n\tv1040 = v1039 == 0;\n\tv1041 = ~v1040;\n\tif (v1041) goto L_0128;\n\tv1043 = \"il2cpp_codegen_runtime_class_init\"(v1031, v1028, v304, v52, v53, v54, v55, v56, v324, v327, v318, v321, v121, v124, v115, v118);\nL_0128:\n\t// 296 MakeStruct v113 @ AGG102DA54_0_v6 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), Vector4_arg @ V0_v29 (UnityEngine.Vector4), v327 @ V1_v13 (System.Single), v318 @ V2_v13 (System.Single), v321 @ V3_v11 (System.Single)\n\tv1052 = UnityEngine.Vector4::op_Subtraction(v113, v932);\n\tv1056 = &v37 @ stack_-10_v2 - 0xD0;\n\t*([v36 @ X29_v1-D0]) = v1052;\n\t*([v36 @ X29_v1-CC]) = v1052.y;\n\t*([v36 @ X29_v1-C8]) = v1052.z;\n\t*([v36 @ X29_v1-C4]) = v1052.w;\n\tv1058 = 0x158C010(v1056, 0, *([v1026 @ X9_v7 (Il2CppClass<Obi.ObiNativeVector4List>)+188]), v52, v53, v54, v55, v56, v1052, v1052.y, v1052.z, v1052.w, v932, v932.y, v932.z, v932.w);\n\tgoto L_0142;\n\tv1064 = *([v1059 @ X0_v43+E0]);\n\tv1065 = v1064 == 0;\n\tv1066 = ~v1065;\n\tif (v1066) goto L_0142;\n\tv1068 = \"il2cpp_codegen_runtime_class_init\"(v1059, v1057, v304, v52, v53, v54, v55, v56, v1052, v1053, v1054, v1055, v1046, v125, v116, v119);\nL_0142:\n\tv1073 = v977 - v1052;\n\tv1074 = v1073 / v977;\n\tv1075 = UnityEngine.Mathf::Clamp01(v1074);\n\tv1078 = ~this.radial;\n\tif (v1078) goto L_FFFFFFFF;\n\tgoto L_0157;\n\tv1095 = *([v1079 @ X0_v66 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv1096 = v1095 == 0;\n\tv1097 = ~v1096;\n\tif (v1097) goto L_0157;\n\tv1099 = \"il2cpp_codegen_runtime_class_init\"(v1079, v1057, v304, v52, v53, v54, v55, v56, v1075, v1071, v1054, v1055, v1046, v125, v116, v119);\nL_0157:\n\tv1115 = UnityEngine.Mathf::Sqrt(v1052);\n\tv1123 = v1115 - v1115;\n\tv1120 = v1115 ^ v1115;\n\tv1119 = v1115 ^ v1123;\n\tv1118 = v1120 & v1119;\n\tv1117 = v1118 < 0;\n\tv1116 = ~v1117;\n\tif (v1116) goto L_016A;\n\tv1153 = 0x6D2F50(UnityEngine.Mathf, 0, *([v1026 @ X9_v7 (Il2CppClass<Obi.ObiNativeVector4List>)+188]), v52, v53, v54, v55, v56, v1052, v977, v1052.z, v1052.w, v932, v932.y, v932.z, v932.w);\nL_016A:\n\tgoto L_0174;\n\tv1163 = *([v1157 @ X0_v69+E0]);\n\tv1164 = v1163 == 0;\n\tv1165 = ~v1164;\n\tgoto L_0174;\n\tv1167 = \"il2cpp_codegen_runtime_class_init\"(v1157, v1057, v304, v52, v53, v54, v55, v56, v1155, v1071, v1054, v1055, v1046, v125, v116, v119);\nL_0174:\n\tv1114 = v1115 + 1E-45f;\n\t// 375 MakeStruct v1110 @ AGG102DB14_0_v7 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), [v36 @ X29_v1-D0], [v36 @ X29_v1-CC], [v36 @ X29_v1-C8], [v36 @ X29_v1-C4]\n\tv1131 = UnityEngine.Vector4::op_Division(v1110, v1114);\n\tv1134 = v1131.y;\n\tv1125 = v1131.z;\n\tv1128 = v1131.w;\n\tgoto L_0195;\n\tgoto L_0195;\n\tv1103 = *([v1087 @ X0_v64+E0]);\n\tv1104 = v218;\n\tv1105 = v215;\n\tv1106 = v209;\n\tv1107 = v212;\n\tv1108 = v1103 == 0;\n\tv1109 = ~v1108;\n\tif (v1109) goto L_0195;\n\tv1138 = \"il2cpp_codegen_runtime_class_init\"(v1087, v1057, v304, v52, v53, v54, v55, v56, v1105, v1104, v1107, v1106, v1046, v125, v116, v119);\n\tv1135 = v218;\n\tv1132 = v215;\n\tv1129 = v209;\n\tv1126 = v212;\nL_0195:\n\t// 405 MakeStruct v82 @ AGG102DB54_0_v6 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), v1131 @ V0_v25 (UnityEngine.Vector4), v1134 @ V1_v17 (System.Single), v1125 @ V2_v16 (System.Single), v1128 @ V3_v14 (System.Single)\n\tv1146 = UnityEngine.Vector4::op_Multiply(v82, v1075);\n\tv325 = UnityEngine.Vector4::op_Multiply(v1146, v978);\n\tv432 = Obi.ObiActor::get_usesCustomExternalForces(actor);\n\tv1174 = v432 == 0;\n\tif (v1174) goto L_01B4;\n\tv433 = Obi.ObiSolver::get_wind(actor.m_Solver);\n\tgoto L_01B5;\nL_01B4:\n\tv433 = Obi.ObiSolver::get_externalForces(actor.m_Solver);\nL_01B5:\n\tv442 = actor.solverIndices;\n\tv1179 = v160 < v442.Length;\n\tv206 = ~v1179;\n\tif (v206) goto L_0217;\n\tv1186 = Obi.ObiNativeVector4List::get_Item(v433, v442[v160 @ X24_v7 (System.Int32)]);\n\tgoto L_01E8;\n\tv1191 = *([v1187 @ X0_v54+E0]);\n\tv1192 = v1191 == 0;\n\tv1193 = ~v1192;\n\tif (v1193) goto L_01E8;\n\tv1195 = \"il2cpp_codegen_runtime_class_init\"(v1187, v1185, v1184, v52, v53, v54, v55, v56, v325, v328, v319, v322, v122, v125, v116, v119);\nL_01E8:\n\tVector4_arg = UnityEngine.Vector4::op_Addition(v325, v325);\n\tv327 = Vector4_arg.y;\n\tv318 = Vector4_arg.z;\n\tv321 = Vector4_arg.w;\n\tv1019 = Obi.ObiNativeVector4List::set_Item(v433, v442[v160 @ X24_v7 (System.Int32)], Vector4_arg);\n\tv160 = v160 + 1;\n\tv1002 = v160 < actor.m_ActiveParticleCount;\n\tif (v1002) goto L_00F8;\nL_0214:\n\treturn;\n\tv581 = new System.NullReferenceException();\nL_0217:\n\tv696 = new System.IndexOutOfRangeException();\n\tthrow v696;\n\treturn;\n// 375 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override void ApplyForcesToActor(ObiActor actor)
		{
			//IL_007f: Expected O, but got Ref
			//IL_007f: Expected O, but got Ref
			//IL_00da: Expected O, but got I
			//IL_0113: Expected O, but got I
			//IL_01a0: Expected O, but got F4
			//IL_0209: Expected I, but got O
			//IL_0282: Expected O, but got I
			//IL_033b: Expected O, but got F4
			//IL_0348: Expected O, but got F4
			//IL_03c0: Expected F4, but got I
			//IL_03d5: Expected F4, but got I
			//IL_03ea: Expected F4, but got I
			//IL_03ff: Expected F4, but got I
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			float num = GetTurbulence(turbulence);
			Transform transform = actor.solver.transform;
			object obj4 = default(object);
			object obj3 = obj4;
			Matrix4x4 worldToLocalMatrix = transform.worldToLocalMatrix;
			obj4 = obj3;
			Transform transform2 = base.transform;
			object obj6 = default(object);
			object obj5 = obj6;
			Matrix4x4 localToWorldMatrix = transform2.localToWorldMatrix;
			obj6 = obj5;
			Matrix4x4 matrix4x = (Matrix4x4)(&obj4) * (Matrix4x4)(&obj6);
			_ = matrix4x.m02;
			_ = matrix4x.m03;
			_ = matrix4x.m00;
			_ = matrix4x.m01;
			Vector4 zero = Vector4.zero;
			Vector3 vector = zero;
			object obj7 = (long)(IntPtr)obj2 - 192L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10C27FC (inside UnityEngine.Matrix4x4::op_Multiply +0x1A8)");
			Vector4 vector2 = vector;
			Vector3 forward = Vector3.forward;
			object obj8 = (long)(IntPtr)obj2 - 192L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @10C2868 (inside UnityEngine.Matrix4x4::op_Multiply +0x214)");
			Vector4 vector3 = forward;
			if (actor.activeParticleCount < 1)
			{
				return;
			}
			float num2 = radius * radius;
			float num3 = intensity + num;
			int num4 = 0;
			float z = vector3.z;
			float w = vector3.w;
			Vector4 value = (Vector4)num3;
			float y = vector3.y;
			Vector4 vector5 = default(Vector4);
			Vector4 vector7 = default(Vector4);
			Vector4 vector9 = default(Vector4);
			while (true)
			{
				ObiNativeVector4List positions = actor.solver.positions;
				int[] solverIndices = actor.solverIndices;
				if (num4 >= solverIndices.Length)
				{
					break;
				}
				IntPtr intPtr = (IntPtr)positions;
				Vector4 vector4 = positions.get_Item(solverIndices[num4]);
				vector5.x = value.x;
				vector5.y = y;
				vector5.z = z;
				vector5.w = w;
				Vector4 vector6 = vector5 - vector2;
				object obj9 = (long)(IntPtr)obj2 - 208L;
				_ = vector6.y;
				_ = vector6.z;
				_ = vector6.w;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158C010 (inside UnityEngine.Vector4::Magnitude +0x1B4)");
				float num5 = num2 - vector6.x;
				float value2 = num5 / num2;
				float num6 = Mathf.Clamp01(value2);
				Vector4 vector8;
				float y2;
				float z2;
				float w2;
				if (radial)
				{
					float num7 = Mathf.Sqrt(vector6.x);
					float num8 = num7 - num7;
					object obj10 = num7 ^ num7;
					object obj11 = num7 ^ num8;
					int num9 = (int)((long)(IntPtr)obj10 & (long)(IntPtr)obj11);
					if (num9 < 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2F50 (native sqrtf)");
						num7 = vector6.x;
					}
					float num10 = num7 + float.Epsilon;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-D0]");
					vector7.x = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-CC]");
					vector7.y = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-C8]");
					vector7.z = 0f;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ X29_v1-C4]");
					vector7.w = 0f;
					vector8 = vector7 / num10;
					y2 = vector8.y;
					z2 = vector8.z;
					w2 = vector8.w;
				}
				else
				{
					z2 = vector3.z;
					w2 = vector3.w;
					vector8 = vector3;
					y2 = vector3.y;
				}
				vector9.x = vector8.x;
				vector9.y = y2;
				vector9.z = z2;
				vector9.w = w2;
				Vector4 vector10 = vector9 * num6;
				Vector4 vector11 = vector10 * num3;
				ObiNativeVector4List obiNativeVector4List = ((!actor.usesCustomExternalForces) ? actor.solver.externalForces : actor.solver.wind);
				int[] solverIndices2 = actor.solverIndices;
				if (num4 >= solverIndices2.Length)
				{
					break;
				}
				Vector4 vector12 = obiNativeVector4List.get_Item(solverIndices2[num4]);
				value = vector11 + vector11;
				y = value.y;
				z = value.z;
				w = value.w;
				obiNativeVector4List.set_Item(solverIndices2[num4], value);
				num4++;
				if (num4 >= actor.activeParticleCount)
				{
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x600038C")]
		[Address(RVA = "0x102DC98", Offset = "0x102DC98", Length = "0x364")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv32 = *([1F0CFD8]);\n\tv33 = *([v32 @ X8_v21]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv52 = 0 | 1;\n\t*([202625B]) = v52;\nL_001C:\n\tv55 = UnityEngine.Component::get_transform(this);\n\tv60 = UnityEngine.Transform::get_localToWorldMatrix(v55);\n\tv62 = v60.m00;\n\tUnityEngine.Gizmos::set_matrix(&v62 @ stack_-A0_v1 (System.Single));\n\tv92 = 0;\n\tv97 = 0x101059C(&v92 @ stack_-F0_v1, 0, v36, v37, v38, v39, v40, v41, 0, 0.7f, 1f, 1f, v46, v47, v48, v49);\n\t// 76 MakeStruct v185 @ AGG102DD48_0_v1 (UnityEngine.Color), typeof(UnityEngine.Color), 0, v258 @ stack_-EC, 0, v261 @ stack_-E4\n\tUnityEngine.Gizmos::set_color(v185);\n\tgoto L_005B;\n\tv269 = *([v265 @ X0_v10+E0]);\n\tv270 = v269 == 0;\n\tv271 = ~v270;\n\tif (v271) goto L_005B;\n\tv273 = \"il2cpp_codegen_runtime_class_init\"(v265, v95, v36, v37, v38, v39, v40, v41, v256, v257, v259, v260, v46, v47, v48, v49);\nL_005B:\n\tv277 = UnityEngine.Vector3::get_zero();\n\tUnityEngine.Gizmos::DrawWireSphere(v277, this.radius);\n\tv285 = Obi.ObiExternalForce::GetTurbulence(this, 1f);\n\tv289 = ~this.radial;\n\tif (v289) goto L_0110;\n\tv291 = this.radius * -0.5f;\n\tv62 = 0;\n\tv298 = 0x1586898(&v62 @ stack_-A0_v1 (System.Single), 0, v36, v37, v38, v39, v40, v41, 0, 0, v291, this.radius, v46, v47, v48, v49);\n\tgoto L_0083;\n\tv324 = *([v305 @ X0_v21+E0]);\n\tv325 = v324 == 0;\n\tv326 = ~v325;\n\tif (v326) goto L_0083;\n\tv328 = \"il2cpp_codegen_runtime_class_init\"(v305, v296, v36, v37, v38, v39, v40, v41, v294, v295, v291, v280, v46, v47, v48, v49);\nL_0083:\n\t// 131 MakeStruct v336 @ AGG102DDEC_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v60.m10 (System.Single), 0\n\tv337 = UnityEngine.Vector3::op_Multiply(v336, v285);\n\tv382 = this.radius * 0.5f;\n\tv92 = 0;\n\tv387 = 0x1586898(&v92 @ stack_-F0_v1, 0, v36, v37, v38, v39, v40, v41, 0, 0, v382, v285, v46, v47, v48, v49);\n\t// 153 MakeStruct v358 @ AGG102DE34_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v258 @ stack_-EC, 0\n\tv393 = UnityEngine.Vector3::op_Multiply(v358, v285);\n\tUnityEngine.Gizmos::DrawLine(v337, v393);\n\tv407 = this.radius * -0.5f;\n\tv352 = 0;\n\tv409 = 0x1586898(&v352 @ stack_-100_v2, 0, v36, v37, v38, v39, v40, v41, 0, v407, 0, v393, v393.y, v393.z, v48, v49);\n\t// 181 MakeStruct v351 @ AGG102DE8C_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v412 @ stack_-FC, 0\n\tv416 = UnityEngine.Vector3::op_Multiply(v351, v285);\n\tv424 = this.radius * 0.5f;\n\tv349 = 0;\n\tv428 = 0x1586898(&v349 @ stack_-110_v2, 0, v36, v37, v38, v39, v40, v41, 0, v424, 0, v285, v393.y, v393.z, v48, v49);\n\t// 202 MakeStruct v348 @ AGG102DED0_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v431 @ stack_-10C, 0\n\tv435 = UnityEngine.Vector3::op_Multiply(v348, v285);\n\tUnityEngine.Gizmos::DrawLine(v416, v435);\n\tv449 = this.radius * -0.5f;\n\tv344 = 0;\n\tv451 = 0x1586898(&v344 @ stack_-120_v2, 0, v36, v37, v38, v39, v40, v41, v449, 0, 0, v435, v435.y, v435.z, v48, v49);\n\t// 230 MakeStruct v343 @ AGG102DF28_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v454 @ stack_-11C, 0\n\tv458 = UnityEngine.Vector3::op_Multiply(v343, v285);\n\tv463 = this.radius * 0.5f;\n\tv341 = 0;\n\tv466 = 0x1586898(&v341 @ stack_-130_v2, 0, v36, v37, v38, v39, v40, v41, v463, 0, 0, v285, v435.y, v435.z, v48, v49);\n\t// 251 MakeStruct v340 @ AGG102DF6C_0_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v469 @ stack_-12C, 0\n\tv473 = UnityEngine.Vector3::op_Multiply(v340, v285);\n\tUnityEngine.Gizmos::DrawLine(v458, v473);\n\tgoto L_012B;\nL_0110:\n\tgoto L_011A;\n\tv309 = *([v301 @ X0_v16 (Il2CppClass<Obi.ObiUtils>)+E0]);\n\tv310 = v309 == 0;\n\tv311 = ~v310;\n\tif (v311) goto L_011A;\n\tv313 = \"il2cpp_codegen_runtime_class_init\"(v301, v284, v36, v37, v38, v39, v40, v41, v285, v278, v279, v280, v46, v47, v48, v49);\nL_011A:\n\tv320 = v285 + this.radius;\n\tv321 = this.radius * 0.2f;\n\tv322 = this.radius * 0.3f;\n\tObi.ObiUtils::DrawArrowGizmo(v320, v321, v322, v321);\nL_012B:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 224 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void OnDrawGizmosSelected()
		{
			//IL_0028: Expected O, but got Ref
			//IL_0036: Expected O, but got I4
			//IL_005b: Expected F4, but got O
			//IL_0076: Expected F4, but got O
			//IL_0154: Expected O, but got I4
			//IL_017e: Expected F4, but got O
			//IL_01ca: Expected O, but got I4
			//IL_01ef: Expected F4, but got O
			//IL_022e: Expected O, but got I4
			//IL_0253: Expected F4, but got O
			//IL_029f: Expected O, but got I4
			//IL_02c9: Expected F4, but got O
			//IL_0303: Expected O, but got I4
			//IL_032d: Expected F4, but got O
			Transform transform = base.transform;
			Matrix4x4 localToWorldMatrix = transform.localToWorldMatrix;
			float num = localToWorldMatrix.m00;
			Gizmos.matrix = (Matrix4x4)(&num);
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
			Vector3 zero = Vector3.zero;
			Gizmos.DrawWireSphere(zero, radius);
			float num2 = GetTurbulence(1f);
			if (radial)
			{
				float num3 = radius * -0.5f;
				num = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
				Vector3 vector = default(Vector3);
				vector.x = 0f;
				vector.y = localToWorldMatrix.m10;
				vector.z = 0f;
				Vector3 vector2 = vector * num2;
				float num4 = radius * 0.5f;
				obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
				Vector3 vector3 = default(Vector3);
				vector3.x = 0f;
				vector3.y = (float)obj2;
				vector3.z = 0f;
				Vector3 to = vector3 * num2;
				Gizmos.DrawLine(vector2, to);
				float num5 = radius * -0.5f;
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
				Vector3 vector4 = default(Vector3);
				vector4.x = 0f;
				object obj5 = default(object);
				vector4.y = (float)obj5;
				vector4.z = 0f;
				Vector3 vector5 = vector4 * num2;
				float num6 = radius * 0.5f;
				object obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
				Vector3 vector6 = default(Vector3);
				vector6.x = 0f;
				object obj7 = default(object);
				vector6.y = (float)obj7;
				vector6.z = 0f;
				Vector3 to2 = vector6 * num2;
				Gizmos.DrawLine(vector5, to2);
				float num7 = radius * -0.5f;
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
				Vector3 vector7 = default(Vector3);
				vector7.x = 0f;
				object obj9 = default(object);
				vector7.y = (float)obj9;
				vector7.z = 0f;
				Vector3 vector8 = vector7 * num2;
				float num8 = radius * 0.5f;
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
				Vector3 vector9 = default(Vector3);
				vector9.x = 0f;
				object obj11 = default(object);
				vector9.y = (float)obj11;
				vector9.z = 0f;
				Vector3 to3 = vector9 * num2;
				Gizmos.DrawLine(vector8, to3);
			}
			else
			{
				float bodyLenght = num2 + radius;
				float num9 = radius * 0.2f;
				float headLenght = radius * 0.3f;
				ObiUtils.DrawArrowGizmo(bodyLenght, num9, headLenght, num9);
			}
		}

		[Token(Token = "0x600038D")]
		[Address(RVA = "0x102E2D0", Offset = "0x102E2D0", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.radius = 5f;\n\tthis.radial = 1;\n\tObi.ObiExternalForce::.ctor(this);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiSphericalForceZone()
		{
			radius = 5f;
			radial = true;
		}
	}
}
