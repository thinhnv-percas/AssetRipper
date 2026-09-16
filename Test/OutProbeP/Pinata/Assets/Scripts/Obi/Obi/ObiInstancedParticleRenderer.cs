using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Profiling;
using UnityEngine;

namespace Obi
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x7446E8", Offset = "0x7446E8")]
	[ExecuteInEditMode]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x7446E8", Offset = "0x7446E8")]
	[Token(Token = "0x200003E")]
	public class ObiInstancedParticleRenderer : MonoBehaviour
	{
		[Token(Token = "0x40000DF")]
		private static ProfilerMarker m_DrawParticlesPerfMarker;

		[Token(Token = "0x40000E0")]
		[FieldOffset(Offset = "0x18")]
		public bool render;

		[Token(Token = "0x40000E1")]
		[FieldOffset(Offset = "0x20")]
		public Mesh mesh;

		[Token(Token = "0x40000E2")]
		[FieldOffset(Offset = "0x28")]
		public Material material;

		[Token(Token = "0x40000E3")]
		[FieldOffset(Offset = "0x30")]
		public Vector3 instanceScale;

		[Token(Token = "0x40000E4")]
		[FieldOffset(Offset = "0x40")]
		private List<Matrix4x4> matrices;

		[Token(Token = "0x40000E5")]
		[FieldOffset(Offset = "0x48")]
		private List<Vector4> colors;

		[Token(Token = "0x40000E6")]
		[FieldOffset(Offset = "0x50")]
		private MaterialPropertyBlock mpb;

		[Token(Token = "0x40000E7")]
		[FieldOffset(Offset = "0x58")]
		private int meshesPerBatch;

		[Token(Token = "0x40000E8")]
		[FieldOffset(Offset = "0x5C")]
		private int batchCount;

		[Token(Token = "0x60002E3")]
		[Address(RVA = "0xE46408", Offset = "0xE46408", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1EBEC48]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024756]) = v38;\nL_0017:\n\tv43 = UnityEngine.Component::GetComponent(this);\n\tv49 = new Obi.ObiActor+ActorCallback();\n\tv53 = Il2CppMethodInfo;\n\tv49.m_target = this;\n\tv49.method = Il2CppMethodInfo;\n\tv49.method_ptr = *([v53 @ X9_v3 (Il2CppMethodInfo)]);\n\tObi.ObiActor::add_OnInterpolate(v43, v49);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void OnEnable()
		{
			ObiActor component = GetComponent<ObiActor>();
			ObiActor.ActorCallback actorCallback = null;
			IntPtr method_ptr = (IntPtr)0;
			((Delegate)actorCallback).m_target = this;
			((Delegate)actorCallback).method = (IntPtr)__ldftn(ObiInstancedParticleRenderer.DrawParticles);
			((Delegate)actorCallback).method_ptr = method_ptr;
			component.OnInterpolate += actorCallback;
		}

		[Token(Token = "0x60002E4")]
		[Address(RVA = "0xE464A4", Offset = "0xE464A4", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1ED0A58]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024757]) = v38;\nL_0017:\n\tv43 = UnityEngine.Component::GetComponent(this);\n\tv49 = new Obi.ObiActor+ActorCallback();\n\tv53 = Il2CppMethodInfo;\n\tv49.m_target = this;\n\tv49.method = Il2CppMethodInfo;\n\tv49.method_ptr = *([v53 @ X9_v3 (Il2CppMethodInfo)]);\n\tObi.ObiActor::remove_OnInterpolate(v43, v49);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void OnDisable()
		{
			ObiActor component = GetComponent<ObiActor>();
			ObiActor.ActorCallback actorCallback = null;
			IntPtr method_ptr = (IntPtr)0;
			((Delegate)actorCallback).m_target = this;
			((Delegate)actorCallback).method = (IntPtr)__ldftn(ObiInstancedParticleRenderer.DrawParticles);
			((Delegate)actorCallback).method_ptr = method_ptr;
			component.OnInterpolate -= actorCallback;
		}

		[Token(Token = "0x60002E5")]
		[Address(RVA = "0xE46540", Offset = "0xE46540", Length = "0x67C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv52 = *([1EDBBA0]);\n\tv53 = *([v52 @ X8_v75]);\n\tv54 = \"il2cpp_codegen_initialize_method\"(v53, actor, methodInfo, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv71 = 0 | 1;\n\t*([2024758]) = v71;\nL_0024:\n\tv72 = 0;\n\tv78 = 0;\n\tv79 = 0;\n\tgoto L_003B;\n\tv84 = *([v80 @ X0_v2 (Il2CppClass<Obi.ObiInstancedParticleRenderer>)+E0]);\n\tv85 = v84 == 0;\n\tv86 = ~v85;\n\tgoto L_003B;\n\tv95 = \"il2cpp_codegen_runtime_class_init\"(v80, actor, methodInfo, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv88 = Obi.ObiInstancedParticleRenderer;\nL_003B:\n\tUnity.Profiling.ProfilerMarker::Internal_Begin(v91.m_DrawParticlesPerfMarker);\n\tgoto L_004C;\n\tv103 = *([v99 @ X0_v5+E0]);\n\tv104 = v103 == 0;\n\tv105 = ~v104;\n\tgoto L_004C;\n\tv107 = \"il2cpp_codegen_runtime_class_init\"(v99, v92, methodInfo, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68);\nL_004C:\n\tv113 = UnityEngine.Object::op_Equality(this.mesh, 0);\n\tv115 = v113 == 0;\n\tv116 = ~v115;\n\tif (v116) goto L_0089;\n\tgoto L_005F;\n\tv335 = *([v117 @ X0_v12+E0]);\n\tv336 = v335 == 0;\n\tv337 = ~v336;\n\tif (v337) goto L_005F;\n\tv339 = \"il2cpp_codegen_runtime_class_init\"(v117, v111, v112, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68);\nL_005F:\n\tv317 = UnityEngine.Object::op_Equality(this.material, 0);\n\tv513 = v317 == 0;\n\tv323 = ~v513;\n\tif (v323) goto L_0089;\n\tv324 = ~this.render;\n\tif (v324) goto L_0089;\n\tv318 = UnityEngine.Behaviour::get_isActiveAndEnabled(this);\n\tv325 = v318 == 0;\n\tif (v325) goto L_0089;\n\tv319 = UnityEngine.Behaviour::get_isActiveAndEnabled(actor);\n\tv326 = v319 == 0;\n\tif (v326) goto L_0089;\n\tgoto L_0083;\n\tv758 = *([v751 @ X0_v50+E0]);\n\tv759 = v758 == 0;\n\tv760 = ~v759;\n\tif (v760) goto L_0083;\n\tv762 = \"il2cpp_codegen_runtime_class_init\"(v751, v308, v302, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68);\nL_0083:\n\tv316 = UnityEngine.Object::op_Equality(actor.m_Solver, 0);\n\tv322 = v316 == 0;\n\tif (v322) goto L_00A1;\nL_0089:\n\tUnity.Profiling.ProfilerMarker::Internal_End(v91.m_DrawParticlesPerfMarker);\nL_009F:\n\treturn;\nL_00A1:\n\tthis.meshesPerBatch = 0x3FF;\n\tv930 = Obi.ObiActor::get_particleCount(actor);\n\tv1010 = v930 / this.meshesPerBatch;\n\tv1011 = v1010 + 1;\n\tthis.batchCount = v1011;\n\tv1013 = Obi.ObiActor::get_particleCount(actor);\n\tgoto L_00BA;\n\tv1239 = *([v1144 @ X0_v58+E0]);\n\tv1240 = v1239 == 0;\n\tv1241 = ~v1240;\n\tif (v1241) goto L_00BA;\n\tv1243 = \"il2cpp_codegen_runtime_class_init\"(v1144, v305, v301, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68);\nL_00BA:\n\tv1249 = UnityEngine.Mathf::Min(this.meshesPerBatch, v1013);\n\tthis.meshesPerBatch = v1249;\n\tv1402 = 0x158BA74(&v72 @ stack_-F0_v1 (UnityEngine.Vector4), 0, 0, v419, v417, v343, v59, v60, 1f, 0, 0, 0, v407, v405, v399, v68);\n\tv1436 = 0x158BA74(&v78 @ stack_-100_v1 (UnityEngine.Vector4), 0, 0, v419, v417, v343, v59, v60, 0, 1f, 0, 0, v407, v405, v399, v68);\n\tv1443 = 0x158BA74(&v79 @ stack_-110_v1 (UnityEngine.Vector4), 0, 0, v419, v417, v343, v59, v60, 0, 0, 1f, 0, v407, v405, v399, v68);\nL_00DE:\n\tv241 = v314 >= this.batchCount;\n\tif (v241) goto L_0089;\n\tSystem.Collections.Generic.List`1<UnityEngine.Matrix4x4>::Clear(this.matrices);\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector4>::Clear(this.colors);\n\tv1483 = new UnityEngine.MaterialPropertyBlock();\n\tUnityEngine.MaterialPropertyBlock::.ctor(v1483);\n\tthis.mpb = v1483;\n\tgoto L_0101;\n\tv1493 = *([v1487 @ X0_v74+E0]);\n\tv1494 = v1493 == 0;\n\tv1495 = ~v1494;\n\tif (v1495) goto L_0101;\n\tv1497 = \"il2cpp_codegen_runtime_class_init\"(v1487, v1486, v303, v232, v230, v123, v59, v60, v273, v271, v269, v267, v216, v214, v206, v68);\nL_0101:\n\tv730 = v314 + 1;\n\tv1500 = this.meshesPerBatch * v730;\n\tv1503 = UnityEngine.Mathf::Min(v1500, actor.m_ActiveParticleCount);\n\tv1505 = this.meshesPerBatch * v314;\n\tv1515 = v1505 >= v1503;\n\tif (v1515) goto L_01D7;\nL_0115:\n\tv749 = actor.solverIndices;\n\tv1537 = v735 < v749.Length;\n\tv703 = ~v1537;\n\tif (v703) goto L_020A;\n\tObi.ObiActor::GetParticleAnisotropy(actor, v749[v735 @ X24_v17 (System.Int32)], &v72 @ stack_-F0_v1 (UnityEngine.Vector4), &v78 @ stack_-100_v1 (UnityEngine.Vector4), &v79 @ stack_-110_v1 (UnityEngine.Vector4));\n\tv1565 = Obi.ObiActor::GetParticlePosition(actor, v749[v735 @ X24_v17 (System.Int32)]);\n\tv1573 = Obi.ObiActor::GetParticleOrientation(actor, v749[v735 @ X24_v17 (System.Int32)]);\n\tv1584 = 0x158BA80(&v72 @ stack_-F0_v1 (UnityEngine.Vector4), 3, 0, &v78 @ stack_-100_v1 (UnityEngine.Vector4), &v79 @ stack_-110_v1 (UnityEngine.Vector4), 0, v59, v60, v1573, v1573.y, v1573.z, v1573.w, v669, v667, v661, v68);\n\tv1589 = 0x158BA80(&v78 @ stack_-100_v1 (UnityEngine.Vector4), 3, 0, &v78 @ stack_-100_v1 (UnityEngine.Vector4), &v79 @ stack_-110_v1 (UnityEngine.Vector4), 0, v59, v60, v1573, v1573.y, v1573.z, v1573.w, v669, v667, v661, v68);\n\tv1593 = 0x158BA80(&v79 @ stack_-110_v1 (UnityEngine.Vector4), 3, 0, &v78 @ stack_-100_v1 (UnityEngine.Vector4), &v79 @ stack_-110_v1 (UnityEngine.Vector4), 0, v59, v60, v1573, v1573.y, v1573.z, v1573.w, v669, v667, v661, v68);\n\tv1599 = 0x1586898(&v1076 @ stack_-120_v15, 0, 0, &v78 @ stack_-100_v1 (UnityEngine.Vector4), &v79 @ stack_-110_v1 (UnityEngine.Vector4), 0, v59, v60, v1573, v1573, v1573, v1573.w, v669, v667, v661, v68);\n\tgoto L_0172;\n\tv1609 = *([v1605 @ X0_v97+E0]);\n\tv1610 = v1609 == 0;\n\tv1611 = ~v1610;\n\tif (v1611) goto L_0172;\n\tv1613 = \"il2cpp_codegen_runtime_class_init\"(v1605, v1129, v1127, v1084, v1082, v123, v59, v60, v1597, v1598, v1594, v1576, v669, v667, v661, v68);\nL_0172:\n\t// 370 MakeStruct v1068 @ AGGE46968_0_v14 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v1076 @ stack_-120_v15, v1618 @ stack_-11C, 0\n\t// 371 MakeStruct v1066 @ AGGE46968_1_v14 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.instanceScale (UnityEngine.Vector3), this.instanceScale.y (System.Single), this.instanceScale.z (System.Single)\n\tv1624 = UnityEngine.Vector3::Scale(v1068, v1066);\n\tgoto L_0194;\n\tv1633 = *([v1629 @ X0_v100+E0]);\n\tv1634 = v1633 == 0;\n\tv1635 = ~v1634;\n\tif (v1635) goto L_0194;\n\tv1637 = \"il2cpp_codegen_runtime_class_init\"(v1629, v1129, v1127, v1084, v1082, v123, v59, v60, v1624, v1625, v1626, v1620, v1621, v1622, v661, v68);\nL_0194:\n\tv1135 = UnityEngine.Matrix4x4::TRS(v1565, v1573, v1624);\n\tv1052 = v1135.m00;\n\tSystem.Collections.Generic.List`1<UnityEngine.Matrix4x4>::Add(this.matrices, &v1052 @ stack_-160_v14 (System.Single));\n\tv1649 = Obi.ObiActor::GetParticleColor(actor, v749[v735 @ X24_v17 (System.Int32)]);\n\tv449 = UnityEngine.Color::op_Implicit(v1649);\n\tv447 = v449.y;\n\tv445 = v449.z;\n\tv443 = v449.w;\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector4>::Add(this.colors, v449);\n\tv735 = v735 + 1;\n\tv1518 = v735 < v1503;\n\tif (v1518) goto L_0115;\nL_01D7:\n\tv1381 = this.colors;\n\tv1404 = v1381._size < 1;\n\tif (v1404) goto L_01F9;\n\tv1426 = this.mpb == 0;\n\tif (v1426) goto L_0218;\n\tUnityEngine.MaterialPropertyBlock::SetVectorArray(this.mpb, \"_Color\", v1381);\nL_01F9:\n\tgoto L_0205;\n\tv1558 = *([v1549 @ X0_v80+E0]);\n\tv1559 = v1558 == 0;\n\tv1560 = ~v1559;\n\tif (v1560) goto L_0205;\n\tv1562 = \"il2cpp_codegen_runtime_class_init\"(v1549, v1540, v1381, v1538, v1324, v123, v59, v60, v1356, v1354, v1352, v1350, v1314, v1312, v1306, v68);\nL_0205:\n\tUnityEngine.Graphics::DrawMeshInstanced(this.mesh, 0, this.material, this.matrices, this.mpb);\n\tgoto L_00DE;\n\tv603 = new System.NullReferenceException();\nL_020A:\n\tv750 = new System.IndexOutOfRangeException();\n\tthrow v750;\n\tv849 = new System.NullReferenceException();\n\tv927 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\tv1395 = new System.NullReferenceException();\nL_0218:\n\tv1429 = new System.NullReferenceException();\n\tgoto L_0247;\n\tgoto L_0247;\n\tgoto L_0247;\n\tgoto L_0247;\n\tgoto L_0247;\n\tgoto L_0247;\n\tgoto L_0247;\n\tgoto L_0247;\n\tgoto L_0247;\n\tgoto L_0247;\n\tgoto L_0247;\n\tgoto L_0247;\n\tgoto L_0247;\n\tgoto L_0247;\n\tgoto L_0247;\n\tgoto L_0247;\n\tgoto L_0247;\n\tgoto L_0247;\n\tgoto L_0247;\n\tgoto L_0247;\n\tgoto L_0247;\n\tgoto L_0247;\n\tgoto L_0247;\n\tgoto L_0247;\n\tgoto L_0247;\n\tgoto L_0247;\n\tgoto L_0247;\n\tgoto L_0247;\n\tgoto L_0247;\n\tgoto L_0247\n// ... truncated")]
		private unsafe void DrawParticles(ObiActor actor)
		{
			//IL_06d1: Expected I, but got O
			//IL_0125: Expected I, but got O
			//IL_0653: Expected I, but got O
			//IL_03c0: Expected F4, but got O
			//IL_03cd: Expected F4, but got O
			//IL_0463: Expected O, but got Ref
			Vector4 b = default(Vector4);
			Vector4 b2 = default(Vector4);
			Vector4 b3 = default(Vector4);
			ProfilerMarker.Internal_Begin((IntPtr)m_DrawParticlesPerfMarker);
			if (!(mesh == null) && !(material == null) && render && base.isActiveAndEnabled && actor.isActiveAndEnabled && !(actor.solver == null))
			{
				meshesPerBatch = 1023;
				int particleCount = actor.particleCount;
				int num = particleCount / meshesPerBatch;
				int num2 = num + 1;
				batchCount = num2;
				int particleCount2 = actor.particleCount;
				int num3 = Mathf.Min(meshesPerBatch, particleCount2);
				meshesPerBatch = num3;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158BA74 (inside UnityEngine.Vector3Int::.cctor +0xA8)");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158BA74 (inside UnityEngine.Vector3Int::.cctor +0xA8)");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158BA74 (inside UnityEngine.Vector3Int::.cctor +0xA8)");
				float num4 = 0f;
				float num5 = 1f;
				float num6 = 0f;
				Vector4 vector = default(Vector4);
				int num7 = 0;
				Quaternion particleOrientation = default(Quaternion);
				Vector3 a2 = default(Vector3);
				object obj = default(object);
				object obj2 = default(object);
				Vector3 b4 = default(Vector3);
				object obj3 = default(object);
				while (num7 < batchCount)
				{
					matrices.Clear();
					colors.Clear();
					MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
					mpb = materialPropertyBlock;
					int num8 = num7 + 1;
					int a = meshesPerBatch * num8;
					int num9 = Mathf.Min(a, actor.activeParticleCount);
					int num10 = meshesPerBatch * num7;
					bool flag = num10 >= num9;
					int num11 = actor.activeParticleCount;
					MaterialPropertyBlock materialPropertyBlock2;
					List<Matrix4x4> list;
					if (!flag)
					{
						float w = particleOrientation.w;
						float z = particleOrientation.z;
						float y = particleOrientation.y;
						int num12 = num10;
						bool flag2;
						do
						{
							int[] solverIndices = actor.solverIndices;
							if (num12 < solverIndices.Length)
							{
								actor.GetParticleAnisotropy(solverIndices[num12], ref b, ref b2, ref b3);
								Vector3 particlePosition = actor.GetParticlePosition(solverIndices[num12]);
								particleOrientation = actor.GetParticleOrientation(solverIndices[num12]);
								Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158BA80 (inside UnityEngine.Vector3Int::.cctor +0xB4)");
								Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158BA80 (inside UnityEngine.Vector3Int::.cctor +0xB4)");
								Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158BA80 (inside UnityEngine.Vector3Int::.cctor +0xB4)");
								Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
								a2.x = (float)obj;
								a2.y = (float)obj2;
								a2.z = 0f;
								b4.x = instanceScale.x;
								b4.y = instanceScale.y;
								b4.z = instanceScale.z;
								Vector3 s = Vector3.Scale(a2, b4);
								float m = Matrix4x4.TRS(particlePosition, particleOrientation, s).m00;
								matrices.Add((Matrix4x4)(&m));
								Color particleColor = actor.GetParticleColor(solverIndices[num12]);
								vector = particleColor;
								num6 = vector.y;
								num5 = vector.z;
								num4 = vector.w;
								colors.Add(vector);
								num12++;
								flag2 = num12 < num9;
								materialPropertyBlock2 = (MaterialPropertyBlock)b3;
								list = (List<Matrix4x4>)b2;
								num11 = 0;
								w = particleOrientation.w;
								z = particleOrientation.z;
								y = particleOrientation.y;
								continue;
							}
							IndexOutOfRangeException ex = new IndexOutOfRangeException();
							throw ex;
						}
						while (flag2);
					}
					List<Vector4> list2 = colors;
					if (list2.Count >= 1)
					{
						if (mpb == null)
						{
							NullReferenceException ex2 = new NullReferenceException();
							bool flag3 = num11 != 1;
							NullReferenceException ex3 = ex2;
							if (!flag3)
							{
								Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
								Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
								ProfilerMarker.Internal_End((IntPtr)m_DrawParticlesPerfMarker);
								if (obj3 == null)
								{
									return;
								}
								TypeLoadException ex4 = new TypeLoadException();
								ex3 = null;
								num11 = 0;
								ex2 = (NullReferenceException)(object)ex4;
							}
							Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
							return;
						}
						mpb.SetVectorArray("_Color", list2);
					}
					Graphics.DrawMeshInstanced(mesh, 0, material, matrices, mpb);
					materialPropertyBlock2 = mpb;
					list = matrices;
					num7 = num8;
				}
			}
			ProfilerMarker.Internal_End((IntPtr)m_DrawParticlesPerfMarker);
		}

		[Token(Token = "0x60002E6")]
		[Address(RVA = "0xE46BBC", Offset = "0xE46BBC", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1ECE170]);\n\tv19 = *([v18 @ X8_v18]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024759]) = v38;\nL_0014:\n\tthis.render = 1;\n\tgoto L_0022;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0022;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0022:\n\tv54 = UnityEngine.Vector3::get_one();\n\tthis.instanceScale = v54;\n\tthis.instanceScale.y = v54.y;\n\tthis.instanceScale.z = v54.z;\n\tv60 = new System.Collections.Generic.List`1<UnityEngine.Matrix4x4>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Matrix4x4>::.ctor(v60);\n\tthis.matrices = v60;\n\tv68 = new System.Collections.Generic.List`1<UnityEngine.Vector4>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector4>::.ctor(v68);\n\tthis.colors = v68;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiInstancedParticleRenderer()
		{
			render = true;
			Vector3 vector = (instanceScale = Vector3.one);
			instanceScale.y = vector.y;
			instanceScale.z = vector.z;
			List<Matrix4x4> list = new List<Matrix4x4>();
			matrices = list;
			List<Vector4> list2 = new List<Vector4>();
			colors = list2;
		}

		[Token(Token = "0x60002E7")]
		[Address(RVA = "0xE46C8C", Offset = "0xE46C8C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1EFCC60]);\n\tv15 = *([v14 @ X8_v10]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202475A]) = v35;\nL_0016:\n\tv41 = Unity.Profiling.ProfilerMarker::Internal_Create(\"DrawParticles\", 0);\n\tv45.m_DrawParticlesPerfMarker = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static ObiInstancedParticleRenderer()
		{
			//IL_002a: Expected O, but got I
			IntPtr intPtr = ProfilerMarker.Internal_Create("DrawParticles", default(Unity.Profiling.MarkerFlags));
			m_DrawParticlesPerfMarker = (ProfilerMarker)(long)intPtr;
		}
	}
}
