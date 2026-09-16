using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;

namespace Obi
{
	[Token(Token = "0x2000058")]
	public class ObiParticlePicker : MonoBehaviour
	{
		[Token(Token = "0x20000BD")]
		public class ParticlePickEventArgs : EventArgs
		{
			[Token(Token = "0x400030F")]
			[FieldOffset(Offset = "0x10")]
			public int particleIndex;

			[Token(Token = "0x4000310")]
			[FieldOffset(Offset = "0x14")]
			public Vector3 worldPosition;

			[Token(Token = "0x6000575")]
			[Address(RVA = "0xC2A650", Offset = "0xC2A650", Length = "0xA0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv34 = *([1EEECF0]);\n\tv35 = *([v34 @ X8_v9]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, particleIndex, methodInfo, v38, v39, v40, v41, v42, worldPosition, v0, v2, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([202314C]) = v50;\nL_0023:\n\tgoto L_002B;\n\tv57 = *([v53 @ X0_v2+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tgoto L_002B;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v53, particleIndex, methodInfo, v38, v39, v40, v41, v42, worldPosition, v0, v2, v43, v44, v45, v46, v47);\nL_002B:\n\tSystem.EventArgs::.ctor(this);\n\tthis.particleIndex = particleIndex;\n\tthis.worldPosition = worldPosition;\n\tthis.worldPosition.y = worldPosition.y;\n\tthis.worldPosition.z = worldPosition.z;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public ParticlePickEventArgs(int particleIndex, Vector3 worldPosition)
			{
				this.particleIndex = particleIndex;
				this.worldPosition = worldPosition;
				this.worldPosition.y = worldPosition.y;
				this.worldPosition.z = worldPosition.z;
			}
		}

		[Serializable]
		[Token(Token = "0x20000BE")]
		public class ParticlePickUnityEvent : UnityEvent<ParticlePickEventArgs>
		{
			[Token(Token = "0x6000576")]
			[Address(RVA = "0xC2A778", Offset = "0xC2A778", Length = "0x50")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EA4D88]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202314D]) = v38;\nL_001C:\n\tUnityEngine.Events.UnityEvent`1<Obi.ObiParticlePicker+ParticlePickEventArgs>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public ParticlePickUnityEvent()
			{
			}
		}

		[Token(Token = "0x400018F")]
		[FieldOffset(Offset = "0x18")]
		public ObiSolver solver;

		[Token(Token = "0x4000190")]
		[FieldOffset(Offset = "0x20")]
		public float radiusScale;

		[Token(Token = "0x4000191")]
		[FieldOffset(Offset = "0x28")]
		public ParticlePickUnityEvent OnParticlePicked;

		[Token(Token = "0x4000192")]
		[FieldOffset(Offset = "0x30")]
		public ParticlePickUnityEvent OnParticleHeld;

		[Token(Token = "0x4000193")]
		[FieldOffset(Offset = "0x38")]
		public ParticlePickUnityEvent OnParticleDragged;

		[Token(Token = "0x4000194")]
		[FieldOffset(Offset = "0x40")]
		public ParticlePickUnityEvent OnParticleReleased;

		[Token(Token = "0x4000195")]
		[FieldOffset(Offset = "0x48")]
		private Vector3 lastMousePos;

		[Token(Token = "0x4000196")]
		[FieldOffset(Offset = "0x54")]
		private int pickedParticleIndex;

		[Token(Token = "0x4000197")]
		[FieldOffset(Offset = "0x58")]
		private float pickedParticleDepth;

		[Token(Token = "0x60003B4")]
		[Address(RVA = "0xC29E24", Offset = "0xC29E24", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = UnityEngine.Input::get_mousePosition();\n\tthis.lastMousePos = v11;\n\tthis.lastMousePos.y = v11.y;\n\tthis.lastMousePos.z = v11.z;\n\treturn;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			Vector3 vector = (lastMousePos = Input.mousePosition);
			lastMousePos.y = vector.y;
			lastMousePos.z = vector.z;
		}

		[Token(Token = "0x60003B5")]
		[Address(RVA = "0xC29E50", Offset = "0xC29E50", Length = "0x800")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv34 = &v35 @ stack_-10_v2;\n\tgoto L_0024;\n\tv44 = *([1EE1220]);\n\tv45 = *([v44 @ X8_v72]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61);\n\tv64 = 0 | 1;\n\t*([202314A]) = v64;\nL_0024:\n\t*([v34 @ X29_v1-34]) = 0;\n\tgoto L_0038;\n\tv79 = *([v74 @ X0_v2+E0]);\n\tv80 = v79 == 0;\n\tv81 = ~v80;\n\tgoto L_0038;\n\tv83 = \"il2cpp_codegen_runtime_class_init\"(v74, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59, v60, v61);\nL_0038:\n\tv89 = UnityEngine.Object::op_Inequality(this.solver, 0);\n\tv91 = v89 == 0;\n\tif (v91) goto L_02D4;\n\tv94 = UnityEngine.Input::GetMouseButtonDown(0);\n\tv470 = v94 == 0;\n\tif (v470) goto L_0160;\n\tthis.pickedParticleIndex = 0xFFFFFFFF;\n\tv492 = UnityEngine.Camera::get_main();\n\tv468 = UnityEngine.Input::get_mousePosition();\n\tv414 = v468.y;\n\tv407 = v468.z;\n\tv729 = UnityEngine.Camera::ScreenPointToRay(v492, v468);\n\tv397 = v729.m_Origin;\n\tv916 = this.solver;\nL_006D:\n\tv442 = Obi.ObiSolver::get_renderablePositions(v916);\n\tv297 = v463 >= v442.m_Count;\n\tif (v297) goto L_01BF;\n\tv968 = Obi.ObiSolver::get_renderablePositions(this.solver);\n\tv1020 = *([v968 @ X0_v92 (Obi.ObiNativeVector4List)]);\n\tv1023 = Obi.ObiNativeVector4List::get_Item(v968, v463);\n\tgoto L_009B;\n\tv1050 = *([v1024 @ X0_v94+E0]);\n\tv1051 = v1050 == 0;\n\tv1052 = ~v1051;\n\tif (v1052) goto L_009B;\n\tv1054 = \"il2cpp_codegen_runtime_class_init\"(v1024, v1021, v1022, v49, v50, v51, v52, v53, v421, v414, v407, v260, v223, v218, v60, v61);\nL_009B:\n\t// 155 MakeStruct v759 @ AGGC29FF4_0_v6 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), v421 @ V0_v31 (System.Single), v414 @ V1_v27 (System.Single), v407 @ V2_v29 (System.Single), v468 @ V0_v2 (UnityEngine.Vector3)\n\tv468 = UnityEngine.Vector4::op_Implicit(v759);\n\t*([v34 @ X29_v1-38]) = v468;\n\tv1075 = 0x10C8B24(&v397 @ stack_-E8_v10 (UnityEngine.Vector3), 0, *([v1020 @ X8_v54 (Il2CppClass<Obi.ObiNativeVector4List>)+188]), v49, v50, v51, v52, v53, v468, v468.y, v468.z, v468, v468.y, v468.z, v60, v61);\n\tv1089 = 0x10C8B24(&v397 @ stack_-E8_v10 (UnityEngine.Vector3), 0, *([v1020 @ X8_v54 (Il2CppClass<Obi.ObiNativeVector4List>)+188]), v49, v50, v51, v52, v53, v468, v468.y, v468.z, v468, v468.y, v468.z, v60, v61);\n\tv1100 = 0x10C8B18(&v397 @ stack_-E8_v10 (UnityEngine.Vector3), 0, *([v1020 @ X8_v54 (Il2CppClass<Obi.ObiNativeVector4List>)+188]), v49, v50, v51, v52, v53, v468, v468.y, v468.z, v468, v468.y, v468.z, v60, v61);\n\tgoto L_00C7;\n\tv1131 = *([v1114 @ X0_v103+E0]);\n\tv1132 = v1131 == 0;\n\tv1133 = ~v1132;\n\tif (v1133) goto L_00C7;\n\tv1135 = \"il2cpp_codegen_runtime_class_init\"(v1114, v1097, v1022, v49, v50, v51, v52, v53, v1062, v1071, v1072, v1060, v223, v218, v60, v61);\nL_00C7:\n\tv468 = UnityEngine.Vector3::op_Addition(v468, v468);\n\tgoto L_00D7;\n\tv1156 = *([v1149 @ X0_v106+E0]);\n\tv1157 = v1156 == 0;\n\tv1158 = ~v1157;\n\tif (v1158) goto L_00D7;\n\tv1160 = \"il2cpp_codegen_runtime_class_init\"(v1149, v1097, v1022, v49, v50, v51, v52, v53, v1145, v1147, v1148, v1141, v1142, v1143, v60, v61);\nL_00D7:\n\tv468 = *([v34 @ X29_v1-38]);\n\tv1165 = &v35 @ stack_-10_v2 - 0x34;\n\t// 227 MakeStruct v744 @ AGGC2A0CC_0_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v34 @ X29_v1-38], v468.y (System.Single), v468.z (System.Single)\n\tv468 = Obi.ObiUtils::ProjectPointLine(v744, v468, v468, v1165, 0);\n\tv970 = Obi.ObiSolver::get_renderablePositions(this.solver);\n\tv1174 = Obi.ObiNativeVector4List::get_Item(v970, v463);\n\t// 248 MakeStruct v742 @ AGGC2A104_0_v6 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), v468 @ V0_v2 (UnityEngine.Vector3), v468.y (System.Single), v468.z (System.Single), v468 @ V0_v2 (UnityEngine.Vector3)\n\tv468 = UnityEngine.Vector4::op_Implicit(v742);\n\tv468 = UnityEngine.Vector3::op_Subtraction(v468, v468);\n\tv1192 = UnityEngine.Vector3::SqrMagnitude(v468);\n\tgoto L_0117;\n\tv1197 = *([v1193 @ X0_v115+E0]);\n\tv1198 = v1197 == 0;\n\tv1199 = ~v1198;\n\tif (v1199) goto L_0117;\n\tv1201 = \"il2cpp_codegen_runtime_class_init\"(v1193, v961, v957, v49, v50, v51, v52, v53, v1192, v1190, v948, v760, v751, v750, v60, v61);\nL_0117:\n\tv421 = UnityEngine.Mathf::Max(0f, *([v34 @ X29_v1-34]));\n\t*([v34 @ X29_v1-34]) = v421;\n\tv972 = Obi.ObiSolver::get_principalRadii(this.solver);\n\tv1217 = Obi.ObiNativeVector4List::get_Item(v972, v463);\n\tv1219 = UnityEngine.Events.UnityEvent`1<Obi.ObiParticlePicker+ParticlePickEventArgs>::Invoke(&v421 @ V0_v31 (System.Single), 0);\n\tv414 = *([v34 @ X29_v1-34]);\n\tv1230 = *([v34 @ X29_v1-34]) >= v785;\n\tif (v1230) goto L_0158;\n\tv1247 = v1192 >= v786;\n\tif (v1247) goto L_0158;\n\tv407 = this.radiusScale;\n\tv1266 = v421 * this.radiusScale;\n\tv421 = v1266 * v1266;\n\tv1267 = v1192 < v421;\n\tv1256 = ~v1267;\n\tv1255 = v1192 - v421;\n\tv1253 = v1255 == 0;\n\tv1268 = ~v1253;\n\tv1248 = v1256 & v1268;\n\tif (v1248) goto L_0158;\n\tthis.pickedParticleIndex = v463;\nL_0158:\n\tv916 = this.solver;\n\tv463 = v463 + 1;\n\tv1261 = this.solver == 0;\n\tv847 = ~v1261;\n\tif (v847) goto L_006D;\n\tthrow System.NullReferenceException;\nL_0160:\n\tv575 = this.pickedParticleIndex & 0x80000000;\n\tv576 = v575 == 0;\n\tv448 = ~v576;\n\tif (v448) goto L_02D4;\n\tv468 = UnityEngine.Input::get_mousePosition();\n\tgoto L_0182;\n\tv875 = *([v721 @ X0_v12+E0]);\n\tv876 = v875 == 0;\n\tv877 = ~v876;\n\tif (v877) goto L_0182;\n\tv879 = \"il2cpp_codegen_runtime_class_init\"(v721, v434, v427, v49, v50, v51, v52, v53, v711, v715, v716, v259, v222, v217, v60, v61);\nL_0182:\n\t// 386 MakeStruct v150 @ AGGC2A240_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.lastMousePos (UnityEngine.Vector3), this.lastMousePos.y (System.Single), this.lastMousePos.z (System.Single)\n\tv468 = UnityEngine.Vector3::op_Subtraction(v468, v150);\n\tv891 = UnityEngine.Events.UnityEvent`1<Obi.ObiParticlePicker+ParticlePickEventArgs>::Invoke(&v468 @ V0_v2 (UnityEngine.Vector3), 0);\n\tv294 = v468 <= 0.01f;\n\tif (v294) goto L_025A;\n\tv919 = this.OnParticleDragged == 0;\n\tif (v919) goto L_025A;\n\tv925 = UnityEngine.Camera::get_main();\n\tv468 = UnityEngine.Input::get_mousePosition();\n\tv468 = UnityEngine.Input::get_mousePosition();\n\tv397 = 0;\n\tv838 = UnityEngine.Events.UnityEvent`1<Obi.ObiParticlePicker+ParticlePickEventArgs>::Invoke(&v397 @ stack_-E8_v10 (UnityEngine.Vector3), 0);\n\t// 440 MakeStruct v1037 @ AGGC2A2C0_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v390 @ stack_-E4_v2, 0\n\tv468 = UnityEngine.Camera::ScreenToWorldPoint(v925, v1037);\n\tv1079 = v468.y;\n\tv1078 = v468.z;\n\tgoto L_0282;\nL_01BF:\n\tv995 = this.pickedParticleIndex & 0x80000000;\n\tv996 = v995 == 0;\n\tv449 = ~v996;\n\tif (v449) goto L_02D4;\n\tv973 = UnityEngine.Camera::get_main();\n\tv839 = UnityEngine.Component::get_transform(v973);\n\tv974 = Obi.ObiSolver::get_renderablePositions(this.solver);\n\tv1102 = Obi.ObiNativeVector4List::get_Item(v974, this.pickedParticleIndex);\n\tgoto L_01EA;\n\tv1120 = *([v1103 @ X0_v69+E0]);\n\tv1121 = v1120 == 0;\n\tv1122 = ~v1121;\n\tif (v1122) goto L_01EA;\n\tv1124 = \"il2cpp_codegen_runtime_class_init\"(v1103, v964, v429, v49, v50, v51, v52, v53, v421, v414, v407, v260, v223, v218, v60, v61);\nL_01EA:\n\t// 490 MakeStruct v134 @ AGGC2A350_0_v5 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), v421 @ V0_v31 (System.Single), v414 @ V1_v27 (System.Single), v407 @ V2_v29 (System.Single), v468 @ V0_v2 (UnityEngine.Vector3)\n\tv468 = UnityEngine.Vector4::op_Implicit(v134);\n\tv975 = UnityEngine.Camera::get_main();\n\tv976 = UnityEngine.Component::get_transform(v975);\n\tv468 = UnityEngine.Transform::get_position(v976);\n\tgoto L_0213;\n\tv1177 = *([v1169 @ X0_v75+E0]);\n\tv1178 = v1177 == 0;\n\tv1179 = ~v1178;\n\tif (v1179) goto L_0213;\n\tv1181 = \"il2cpp_codegen_runtime_class_init\"(v1169, v828, v429, v49, v50, v51, v52, v53, v1166, v1167, v1168, v941, v223, v218, v60, v61);\nL_0213:\n\tv468 = UnityEngine.Vector3::op_Subtraction(v468, v468);\n\tv468 = UnityEngine.Transform::InverseTransformVector(v839, v468);\n\tthis.pickedParticleDepth = v468.z;\n\tv450 = this.OnParticlePicked == 0;\n\tif (v450) goto L_02D4;\n\tv1206 = UnityEngine.Camera::get_main();\n\tv468 = UnityEngine.Input::get_mousePosition();\n\tv468 = UnityEngine.Input::get_mousePosition();\n\tv397 = 0;\n\tv841 = UnityEngine.Events.UnityEvent`1<Obi.ObiParticlePicker+ParticlePickEventArgs>::Invoke(&v3\n// ... truncated")]
		private unsafe void LateUpdate()
		{
			//IL_0498: Expected I4, but got I8
			//IL_0620: Expected I4, but got I8
			//IL_0882: Expected F4, but got O
			//IL_013d: Expected I, but got O
			//IL_05c4: Expected F4, but got O
			//IL_097b: Expected F4, but got O
			//IL_0201: Expected O, but got I
			//IL_0225: Expected F4, but got I
			//IL_0325: Expected F4, but got I
			//IL_0362: Expected O, but got F4
			//IL_0372: Expected F4, but got I
			//IL_07be: Expected F4, but got I
			//IL_0471: Expected F4, but got I
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			object obj3 = default(object);
			Vector3 vector;
			if (solver != null)
			{
				if (Input.GetMouseButtonDown(0))
				{
					pickedParticleIndex = -1;
					Camera main = Camera.main;
					vector = Input.mousePosition;
					float y = vector.y;
					float z = vector.z;
					Vector3 origin = main.ScreenPointToRay(vector).m_Origin;
					ObiSolver obiSolver = solver;
					float num = float.MaxValue;
					float num2 = float.MaxValue;
					float num3 = float.MaxValue;
					int num4 = 0;
					Vector4 vector3 = default(Vector4);
					Vector3 point = default(Vector3);
					Vector4 vector5 = default(Vector4);
					while (true)
					{
						ObiNativeVector4List renderablePositions = obiSolver.renderablePositions;
						if (num4 >= renderablePositions.count)
						{
							break;
						}
						ObiNativeVector4List renderablePositions2 = solver.renderablePositions;
						IntPtr intPtr = (IntPtr)renderablePositions2;
						Vector4 vector2 = renderablePositions2.get_Item(num4);
						vector3.x = num3;
						vector3.y = y;
						vector3.z = z;
						vector3.w = vector.x;
						vector = vector3;
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10C8B24 (inside UnityEngine.Object::.cctor +0x3F4)");
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10C8B24 (inside UnityEngine.Object::.cctor +0x3F4)");
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10C8B18 (inside UnityEngine.Object::.cctor +0x3E8)");
						vector += vector;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1-38]");
						vector = (Vector3)0;
						ref float mu = ref *(float*)((long)(IntPtr)obj2 - 52L);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1-38]");
						point.x = 0f;
						point.y = vector.y;
						point.z = vector.z;
						vector = ObiUtils.ProjectPointLine(point, vector, vector, out mu, clampToSegment: false);
						ObiNativeVector4List renderablePositions3 = solver.renderablePositions;
						Vector4 vector4 = renderablePositions3.get_Item(num4);
						vector5.x = vector.x;
						vector5.y = vector.y;
						vector5.z = vector.z;
						vector5.w = vector.x;
						vector = vector5;
						vector -= vector;
						float num5 = Vector3.SqrMagnitude(vector);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1-34]");
						num3 = Mathf.Max(0f, 0f);
						ObiNativeVector4List principalRadii = solver.principalRadii;
						Vector4 vector6 = principalRadii.get_Item(num4);
						((UnityEvent<ParticlePickEventArgs>)num3).Invoke(null);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1-34]");
						y = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1-34]");
						bool flag = !(0f < num);
						z = num;
						if (!flag)
						{
							bool flag2 = !(num5 < num2);
							z = num2;
							if (!flag2)
							{
								z = radiusScale;
								float num6 = num3 * radiusScale;
								num3 = num6 * num6;
								bool flag3 = num5 < num3;
								bool flag4 = !flag3;
								float num7 = num5 - num3;
								bool flag5 = num7 == 0f;
								bool flag6 = !flag5;
								if (!(flag4 && flag6))
								{
									pickedParticleIndex = num4;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ X29_v1-34]");
									num = 0f;
									num2 = num5;
								}
							}
						}
						obiSolver = solver;
						num4++;
						if ((object)solver == null)
						{
							throw new NullReferenceException();
						}
					}
					if ((int)(pickedParticleIndex & 0x80000000L) == 0)
					{
						Camera main2 = Camera.main;
						Transform transform = main2.transform;
						ObiNativeVector4List renderablePositions4 = solver.renderablePositions;
						Vector4 vector7 = renderablePositions4.get_Item(pickedParticleIndex);
						Vector4 vector8 = default(Vector4);
						vector8.x = num3;
						vector8.y = y;
						vector8.z = z;
						vector8.w = vector.x;
						vector = vector8;
						Camera main3 = Camera.main;
						Transform transform2 = main3.transform;
						vector = transform2.position;
						vector -= vector;
						pickedParticleDepth = transform.InverseTransformVector(vector).z;
						if (OnParticlePicked != null)
						{
							Camera main4 = Camera.main;
							vector = Input.mousePosition;
							vector = Input.mousePosition;
							((UnityEvent<ParticlePickEventArgs>)default(Vector3)).Invoke((ParticlePickEventArgs)null);
							Vector3 position = default(Vector3);
							position.x = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v729 @ X0_v57 (UnityEngine.Ray)+4]");
							position.y = 0f;
							position.z = 0f;
							vector = main4.ScreenToWorldPoint(position);
							ParticlePickEventArgs arg = new ParticlePickEventArgs(pickedParticleIndex, vector);
							OnParticlePicked.Invoke(arg);
						}
					}
				}
				else if ((int)(pickedParticleIndex & 0x80000000L) == 0)
				{
					vector = Input.mousePosition;
					Vector3 vector9 = default(Vector3);
					vector9.x = lastMousePos.x;
					vector9.y = lastMousePos.y;
					vector9.z = lastMousePos.z;
					vector -= vector9;
					((UnityEvent<ParticlePickEventArgs>)vector).Invoke((ParticlePickEventArgs)null);
					float y2;
					float z2;
					UnityEvent<ParticlePickEventArgs> unityEvent;
					if (vector.x > 0.01f && OnParticleDragged != null)
					{
						Camera main5 = Camera.main;
						vector = Input.mousePosition;
						vector = Input.mousePosition;
						((UnityEvent<ParticlePickEventArgs>)default(Vector3)).Invoke((ParticlePickEventArgs)null);
						Vector3 position2 = default(Vector3);
						position2.x = 0f;
						position2.y = (float)obj3;
						position2.z = 0f;
						vector = main5.ScreenToWorldPoint(position2);
						y2 = vector.y;
						z2 = vector.z;
						unityEvent = OnParticleDragged;
					}
					else
					{
						if (OnParticleHeld == null)
						{
							goto IL_08dd;
						}
						Camera main6 = Camera.main;
						vector = Input.mousePosition;
						vector = Input.mousePosition;
						((UnityEvent<ParticlePickEventArgs>)default(Vector3)).Invoke((ParticlePickEventArgs)null);
						Vector3 position3 = default(Vector3);
						position3.x = 0f;
						position3.y = (float)obj3;
						position3.z = 0f;
						vector = main6.ScreenToWorldPoint(position3);
						y2 = vector.y;
						z2 = vector.z;
						unityEvent = OnParticleHeld;
					}
					Vector3 worldPosition = default(Vector3);
					ParticlePickEventArgs arg2 = new ParticlePickEventArgs(pickedParticleIndex, worldPosition);
					worldPosition.x = vector.x;
					worldPosition.y = y2;
					worldPosition.z = z2;
					unityEvent.Invoke(arg2);
					goto IL_08dd;
				}
			}
			goto IL_09e7;
			IL_09e7:
			vector = (lastMousePos = Input.mousePosition);
			lastMousePos.y = vector.y;
			lastMousePos.z = vector.z;
			return;
			IL_08dd:
			if (Input.GetMouseButtonUp(0))
			{
				if (OnParticleReleased != null)
				{
					Camera main7 = Camera.main;
					vector = Input.mousePosition;
					vector = Input.mousePosition;
					((UnityEvent<ParticlePickEventArgs>)default(Vector3)).Invoke((ParticlePickEventArgs)null);
					Vector3 position4 = default(Vector3);
					position4.x = 0f;
					position4.y = (float)obj3;
					position4.z = 0f;
					vector = main7.ScreenToWorldPoint(position4);
					ParticlePickEventArgs arg3 = new ParticlePickEventArgs(pickedParticleIndex, vector);
					OnParticleReleased.Invoke(arg3);
				}
				pickedParticleIndex = -1;
			}
			goto IL_09e7;
		}

		[Token(Token = "0x60003B6")]
		[Address(RVA = "0xC2A6F0", Offset = "0xC2A6F0", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1F0D098]);\n\tv19 = *([v18 @ X8_v11]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202314B]) = v38;\nL_0014:\n\tthis.radiusScale = 1f;\n\tgoto L_0022;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0022;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0022:\n\tv54 = UnityEngine.Vector3::get_zero();\n\tthis.lastMousePos = v54;\n\tthis.lastMousePos.y = v54.y;\n\tthis.lastMousePos.z = v54.z;\n\tthis.pickedParticleIndex = 0xFFFFFFFF;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiParticlePicker()
		{
			radiusScale = 1f;
			Vector3 vector = (lastMousePos = Vector3.zero);
			lastMousePos.y = vector.y;
			lastMousePos.z = vector.z;
			pickedParticleIndex = -1;
		}
	}
}
