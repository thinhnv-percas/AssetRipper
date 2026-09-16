using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Profiling;
using UnityEngine;

namespace Obi
{
	[Token(Token = "0x2000040")]
	public class ParticleImpostorRendering
	{
		[Token(Token = "0x40000F0")]
		private static ProfilerMarker m_ParticlesToMeshPerfMarker;

		[Token(Token = "0x40000F1")]
		[FieldOffset(Offset = "0x10")]
		private List<Mesh> meshes;

		[Token(Token = "0x40000F2")]
		[FieldOffset(Offset = "0x18")]
		private List<Vector3> vertices;

		[Token(Token = "0x40000F3")]
		[FieldOffset(Offset = "0x20")]
		private List<Vector3> normals;

		[Token(Token = "0x40000F4")]
		[FieldOffset(Offset = "0x28")]
		private List<Color> colors;

		[Token(Token = "0x40000F5")]
		[FieldOffset(Offset = "0x30")]
		private List<int> triangles;

		[Token(Token = "0x40000F6")]
		[FieldOffset(Offset = "0x38")]
		private List<Vector4> anisotropy1;

		[Token(Token = "0x40000F7")]
		[FieldOffset(Offset = "0x40")]
		private List<Vector4> anisotropy2;

		[Token(Token = "0x40000F8")]
		[FieldOffset(Offset = "0x48")]
		private List<Vector4> anisotropy3;

		[Token(Token = "0x40000F9")]
		[FieldOffset(Offset = "0x50")]
		private int particlesPerDrawcall;

		[Token(Token = "0x40000FA")]
		[FieldOffset(Offset = "0x54")]
		private int drawcallCount;

		[Token(Token = "0x40000FB")]
		[FieldOffset(Offset = "0x58")]
		private Vector3 particleOffset0;

		[Token(Token = "0x40000FC")]
		[FieldOffset(Offset = "0x64")]
		private Vector3 particleOffset1;

		[Token(Token = "0x40000FD")]
		[FieldOffset(Offset = "0x70")]
		private Vector3 particleOffset2;

		[Token(Token = "0x40000FE")]
		[FieldOffset(Offset = "0x7C")]
		private Vector3 particleOffset3;

		[Token(Token = "0x17000055")]
		public IEnumerable<Mesh> Meshes
		{
			[Token(Token = "0x60002F1")]
			[Address(RVA = "0x10346D8", Offset = "0x10346D8", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv18 = *([1EE3D28]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202629B]) = v38;\nL_001E:\n\treturnVal1 = System.Collections.Generic.List`1<UnityEngine.Mesh>::AsReadOnly(this.meshes);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return meshes.AsReadOnly();
			}
		}

		[Token(Token = "0x60002F2")]
		[Address(RVA = "0x1034730", Offset = "0x1034730", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Mesh::Clear(mesh);\n\tUnityEngine.Mesh::SetVertices(mesh, this.vertices);\n\tUnityEngine.Mesh::SetNormals(mesh, this.normals);\n\tUnityEngine.Mesh::SetColors(mesh, this.colors);\n\tUnityEngine.Mesh::SetUVs(mesh, 0, this.anisotropy1);\n\tUnityEngine.Mesh::SetUVs(mesh, 1, this.anisotropy2);\n\tUnityEngine.Mesh::SetUVs(mesh, 2, this.anisotropy3);\n\tUnityEngine.Mesh::SetTriangles(mesh, this.triangles, 0, 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Apply(Mesh mesh)
		{
			mesh.Clear();
			mesh.SetVertices(vertices);
			mesh.SetNormals(normals);
			mesh.SetColors(colors);
			mesh.SetUVs(0, anisotropy1);
			mesh.SetUVs(1, anisotropy2);
			mesh.SetUVs(2, anisotropy3);
			mesh.SetTriangles(triangles, 0, calculateBounds: true);
		}

		[Token(Token = "0x60002F3")]
		[Address(RVA = "0x10347E8", Offset = "0x10347E8", Length = "0x138")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EEC920]);\n\tv23 = *([v22 @ X8_v17]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202629C]) = v42;\nL_0017:\n\tv45 = 0;\n\tv47 = this.meshes == 0;\n\tif (v47) goto L_0065;\n\tv52 = System.Collections.Generic.List`1<UnityEngine.Mesh>::GetEnumerator(this.meshes);\nL_0026:\n\tv82 = System.Collections.Generic.List`1<UnityEngine.Mesh>+Enumerator<UnityEngine.Mesh>::MoveNext(&v45 @ stack_-48_v1 (System.Collections.Generic.List`1<UnityEngine.Mesh>+Enumerator<UnityEngine.Mesh>));\n\tv88 = v82 == 0;\n\tif (v88) goto L_003D;\n\tgoto L_0037;\n\tv115 = *([v89 @ X0_v15+E0]);\n\tv116 = v115 == 0;\n\tv117 = ~v116;\n\tif (v117) goto L_0037;\n\tv119 = \"il2cpp_codegen_runtime_class_init\"(v89, v80, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0037:\n\tUnityEngine.Object::DestroyImmediate(0);\n\tgoto L_0026;\nL_003D:\n\tv95 = System.Collections.Generic.List`1<UnityEngine.Mesh>+Enumerator<UnityEngine.Mesh>::Dispose(&v45 @ stack_-48_v1 (System.Collections.Generic.List`1<UnityEngine.Mesh>+Enumerator<UnityEngine.Mesh>));\n\tgoto L_0057;\n\tgoto L_0040;\nL_0040:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0066;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1F0D808]);\n\tX0 = &stack[8];\n\tX1 = *([X8]);\n\tX0 = 0xEF9AAC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_006A;\nL_0057:\n\tv62 = this.meshes == 0;\n\tif (v62) goto L_0065;\n\tSystem.Collections.Generic.List`1<UnityEngine.Mesh>::Clear(this.meshes);\n\treturn;\nL_0065:\n\tv67 = new System.NullReferenceException();\nL_0066:\n\tv70 = System.Collections.Generic.List`1<UnityEngine.Mesh>+Enumerator<UnityEngine.Mesh>::Dispose(v67);\nL_006A:\n\tthrow System.TypeLoadException;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void ClearMeshes()
		{
			List<Mesh>.Enumerator enumerator = default(List<Mesh>.Enumerator);
			if (meshes != null)
			{
				List<Mesh>.Enumerator enumerator2 = meshes.GetEnumerator();
				while (enumerator.MoveNext())
				{
					UnityEngine.Object.DestroyImmediate(null);
				}
				enumerator.Dispose();
				if (meshes != null)
				{
					meshes.Clear();
					return;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			((List<Mesh>.Enumerator*)ex)->Dispose();
			throw new TypeLoadException();
		}

		[Token(Token = "0x60002F4")]
		[Address(RVA = "0x1034920", Offset = "0x1034920", Length = "0xC2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002F;\n\tv50 = *([1EF3AC8]);\n\tv51 = *([v50 @ X8_v116]);\n\tv52 = \"il2cpp_codegen_initialize_method\"(v51, collection, methodInfo, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv69 = 0 | 1;\n\t*([202629D]) = v69;\nL_002F:\n\tgoto L_003A;\n\tv82 = *([v78 @ X0_v2 (Il2CppClass<Obi.ParticleImpostorRendering>)+E0]);\n\tv83 = v82 == 0;\n\tv84 = ~v83;\n\tgoto L_003A;\n\tv93 = \"il2cpp_codegen_runtime_class_init\"(v78, collection, methodInfo, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv86 = Obi.ParticleImpostorRendering;\nL_003A:\n\tUnity.Profiling.ProfilerMarker::Internal_Begin(v89.m_ParticlesToMeshPerfMarker);\n\tthis.particlesPerDrawcall = 0x3F7A;\n\tv97 = collection->klass;\n\tv101 = *([v97 @ X8_v45 (Il2CppClass<Obi.IObiParticleCollection>)+126]) == 0;\n\tif (v101) goto L_0063;\n\tv413 = *([v97 @ X8_v45 (Il2CppClass<Obi.IObiParticleCollection>)+B0]) + 8;\nL_004E:\n\tv418 = *([v413 @ X11_v85-8]) == Obi.IObiParticleCollection;\n\tif (v418) goto L_0066;\n\tv412 = v412 + 1;\n\tv561 = v412 < *([v97 @ X8_v45 (Il2CppClass<Obi.IObiParticleCollection>)+126]);\n\tv302 = ~v561;\n\tv413 = v413 + 0x10;\n\tv286 = ~v302;\n\tif (v286) goto L_004E;\nL_0063:\n\tv582 = 0x8909C4(collection, Obi.IObiParticleCollection, 1, v1416, v1414, v1418, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tgoto L_006D;\nL_0066:\n\tv563 = *([v413 @ X11_v85]) + 1;\n\tv564 = v563 << 4;\n\tv565 = v97 + v564;\n\tv582 = v565 + 0x130;\nL_006D:\n\t*([v582 @ X0_v91])(v587, collection, *([v582 @ X0_v91+8]), v870, v1416, v1414, v1418, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tv588 = v587 / this.particlesPerDrawcall;\n\tv589 = v588 + 1;\n\tthis.drawcallCount = v589;\n\tv590 = collection->klass;\n\tv593 = *([v590 @ X8_v50 (Il2CppClass<Obi.IObiParticleCollection>)+126]) == 0;\n\tif (v593) goto L_0094;\n\tv781 = *([v590 @ X8_v50 (Il2CppClass<Obi.IObiParticleCollection>)+B0]) + 8;\nL_007F:\n\tv786 = *([v781 @ X11_v80-8]) == Obi.IObiParticleCollection;\n\tif (v786) goto L_0097;\n\tv780 = v780 + 1;\n\tv864 = v780 < *([v590 @ X8_v50 (Il2CppClass<Obi.IObiParticleCollection>)+126]);\n\tv689 = ~v864;\n\tv781 = v781 + 0x10;\n\tv673 = ~v689;\n\tif (v673) goto L_007F;\nL_0094:\n\tv871 = 0x8909C4(collection, Obi.IObiParticleCollection, 1, v1416, v1414, v1418, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tgoto L_009E;\nL_0097:\n\tv866 = *([v781 @ X11_v80]) + 1;\n\tv867 = v866 << 4;\n\tv868 = v590 + v867;\n\tv871 = v868 + 0x130;\nL_009E:\n\t*([v871 @ X0_v94])(v876, collection, *([v871 @ X0_v94+8]), v870, v1416, v1414, v1418, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\n\tgoto L_00AF;\n\tv1018 = *([v879 @ X0_v97+E0]);\n\tv1019 = v1018 == 0;\n\tv1020 = ~v1019;\n\tgoto L_00AF;\n\tv1022 = \"il2cpp_codegen_runtime_class_init\"(v879, v874, v870, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66);\nL_00AF:\n\tv394 = UnityEngine.Mathf::Min(this.particlesPerDrawcall, v876);\n\tv398 = this.meshes;\n\tthis.particlesPerDrawcall = v394;\n\tv1187 = this.drawcallCount == v398._size;\n\tif (v1187) goto L_0100;\n\tObi.ParticleImpostorRendering::ClearMeshes(this);\n\tv1282 = this.drawcallCount < 1;\n\tif (v1282) goto L_0100;\nL_00D7:\n\tv1654 = new UnityEngine.Mesh();\n\tUnityEngine.Mesh::.ctor(v1654);\n\tUnityEngine.Object::set_name(v1654, \"Particle impostors\");\n\tUnityEngine.Object::set_hideFlags(v1654, 0x3D);\n\tSystem.Collections.Generic.List`1<UnityEngine.Mesh>::Add(this.meshes, v1654);\n\tv1652 = v1652 + 1;\n\tv1281 = v1652 < this.drawcallCount;\n\tif (v1281) goto L_00D7;\nL_0100:\n\tv1325 = System.Collections.Generic.List`1<UnityEngine.Mesh>::Add(&v1320 @ stack_-B0_v43, 0);\n\tv1412 = System.Collections.Generic.List`1<UnityEngine.Mesh>::Add(&v1407 @ stack_-C0_v43, 0);\n\tv1559 = System.Collections.Generic.List`1<UnityEngine.Mesh>::Add(&v958 @ stack_-D0_v47 (System.Int32), 0);\nL_0123:\n\tv526 = v559 >= this.drawcallCount;\n\tif (v526) goto L_03A9;\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::Clear(this.vertices);\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::Clear(this.normals);\n\tSystem.Collections.Generic.List`1<UnityEngine.Color>::Clear(this.colors);\n\tSystem.Collections.Generic.List`1<System.Int32>::Clear(this.triangles);\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector4>::Clear(this.anisotropy1);\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector4>::Clear(this.anisotropy2);\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector4>::Clear(this.anisotropy3);\n\tv3267 = collection->klass;\n\tv3271 = *([v3267 @ X8_v65 (Il2CppClass<Obi.IObiParticleCollection>)+126]) == 0;\n\tif (v3271) goto L_016B;\n\tv3469 = *([v3267 @ X8_v65 (Il2CppClass<Obi.IObiParticleCollection>)+B0]) + 8;\nL_0156:\n\tv3474 = *([v3469 @ X11_v75-8]) == Obi.IObiParticleCollection;\n\tif (v3474) goto L_016E;\n\tv3468 = v3468 + 1;\n\tv3557 = v3468 < *([v3267 @ X8_v65 (Il2CppClass<Obi.IObiParticleCollection>)+126]);\n\tv3372 = ~v3557;\n\tv3469 = v3469 + 0x10;\n\tv3356 = ~v3372;\n\tif (v3356) goto L_0156;\nL_016B:\n\tv3578 = 0x8909C4(collection, Obi.IObiParticleCollection, 1, &v1407 @ stack_-C0_v43, &v958 @ stack_-D0_v47 (System.Int32), *([v4261 @ X0_v141+8]), v57, v58, v1499, v1495, v1493, v1491, v63, v64, v65, v66);\n\tgoto L_0175;\nL_016E:\n\tv3559 = *([v3469 @ X11_v75]) + 1;\n\tv3560 = v3559 << 4;\n\tv3561 = v3267 + v3560;\n\tv3578 = v3561 + 0x130;\nL_0175:\n\t*([v3578 @ X0_v123])(v3583, collection, *([v3578 @ X0_v123+8]), v524, &v1407 @ stack_-C0_v43, &v958 @ stack_-D0_v47 (System.Int32), *([v4261 @ X0_v141+8]), v57, v58, v1499, v1495, v1493, v1491, v63, v64, v65, v66);\n\tgoto L_0183;\n\tv3667 = *([v3587 @ X0_v126+E0]);\n\tv3668 = v3667 == 0;\n\tv3669 = ~v3668;\n\tgoto L_0183;\n\tv3671 = \"il2cpp_codegen_runtime_class_init\"(v3587, v3581, v3565, v426, v424, v428, v57, v58, v512, v508, v506, v504, v63, v64, v65, v66);\nL_0183:\n\tv954 = v559 + 1;\n\tv3674 = this.particlesPerDrawcall * v954;\n\tv3677 = UnityEngine.Mathf::Min(v3674, v3583);\n\tv978 = this.particlesPerDrawcall * v559;\n\tv3764 = v978 >= v3677;\n\tif (v3764) goto L_0389;\nL_0197:\n\tv3967 = collection->klass;\n\tv3970 = *([v3967 @ X8_v78 (Il2CppClass<Obi.IObiParticleCollection>)+126]) == 0;\n\tif (v3970) goto L_01B9;\n\tv4037 = *([v3967 @ X8_v78 (Il2CppClass<Obi.IObiParticleCollection>)+B0]) + 8;\nL_01A4:\n\tv4042 = *([v4037 @ X11_v70-8]) == Obi.IObiParticleCollection;\n\tif (v4042) goto L_01BC;\n\tv4036 = v4036 + 1;\n\tv4048 = v4036 < *([v3967 @ X8_v78 (Il2CppClass<Obi.IObiParticleCollection>)+126]);\n\tv4015 = ~v4048;\n\tv4037 = v4037 + 0x10;\n\tv3999 = ~v4015;\n\tif (v3999) goto L_01A4;\nL_01B9:\n\tv4069 = 0x8909C4(collection, Obi.IObiParticleCollection, 3, v3935, v3934, v3936, v57, v58, v970, v966, v964, v962, v63, v64, v65, v66);\n\tgoto L_01C4;\nL_01BC:\n\tv4050 = *([v4037 @ X11_v70]) + 3;\n\tv4051 = v4050 << 4;\n\tv4052 = v3967 + v4051;\n\tv4069 = v4052 + 0x130;\nL_01C4:\n\t*([v4069 @ X0_v135])(v4075, collection, v978, *([v4069 @ X0_v135+8]), v3935, v3934, v3936, v57, v58, v970, v966, v964, v962, v63, v64, v65, v66);\n\tv4076 = collection->klass;\n\tv4079 = *([v4076 @ X8_v81 (Il2CppClass<Obi.IObiParticleCollection>)+126]) == 0;\n\tif (v4079) goto L_01E8;\n\tv4142 = *([v4076 @ X8_v81 (Il2CppClass<Obi.IObiParticleCollection>)+B0]) + 8;\nL_01D3:\n\tv4147 = *([v4142 @ X11_v65-8]) == Obi.IObiParticleCollection;\n\tif (v4147) goto L_01EB;\n\tv4141 = v4141 + 1;\n\tv4156 = v4141 < *([v4076 @ X8_v81 (Il2CppClass<Obi.IObiParticleCollection>)+126]);\n\tv4121 = ~v4156;\n\tv4142 = v4142 + 0x10;\n\tv4105 = ~v4121;\n\tif (v4105) goto L_01D3;\nL_01E8:\n\tv4177 = 0x8909C4(collection, Obi.IObiParticleCollection, 4, v3935, v3934, v3936, v57, v58, v970, v966, v964, v962, v63, v64, v65, v66);\n\tgoto L_01F3;\nL_01EB:\n\tv4158 = *([v4142 @ X11_v65]) + 4;\n\tv4159 = v4158 << 4;\n\tv4160 = v4076 + v4159;\n\tv4177 = v4160 + 0x130;\nL_01F3:\n\t*([v4177 @ X0_v138])(v4183, collection, v4075, *([v4177 @ X0_v138+8]), v3935, v3934, v3936, v57, v58, v970, v966, v964, v962, v63, v64, v65, v66);\n\tv4184 = collection->klass;\n\tv4187 = *([v4184 @ X8_v84 (Il2CppClass<Obi.IObiParticleCollection>)+126]) == 0;\n\tif (v4187) goto L_0219;\n\tv4230 = *([v4184 @ X8_v84 (Il2CppClass<Obi.IObiParticleCollection>)+B0]) + 8;\nL_0204:\n\tv4235 = *([v4230 @ X11_v60-8]) == Obi.IObiParticleCollection;\n\tif (v4235) goto L_021C;\n\tv4229 = v4229 + 1;\n\tv4240 = v4229 < *([v4184 @ X8_v84 (Il2CppClass<Obi.IObiParticleCollection>)+126]);\n\tv4210 = ~v4240;\n\tv4230 = v4230\n// ... truncated")]
		public void UpdateMeshes(IObiParticleCollection collection)
		{
			//IL_1217: Expected I, but got O
			//IL_000d: Expected I, but got O
			//IL_128b: Expected I, but got O
			//IL_0048: Expected O, but got I
			//IL_0127: Expected O, but got I
			//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			//IL_00f5: Expected O, but got I
			//IL_0104: Expected O, but got I
			//IL_0094: Expected O, but got I
			//IL_022e: Expected I, but got O
			//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_01b7: Expected O, but got Unknown
			//IL_01d4: Expected O, but got I
			//IL_01e3: Expected O, but got I
			//IL_0173: Expected O, but got I
			//IL_02f9: Expected O, but got I4
			//IL_0258: Expected I, but got O
			//IL_116c: Expected I, but got O
			//IL_03a1: Expected I, but got O
			//IL_03dc: Expected O, but got I
			//IL_04f0: Expected I, but got O
			//IL_0467: Unknown result type (might be due to invalid IL or missing references)
			//IL_046c: Expected O, but got Unknown
			//IL_0489: Expected O, but got I
			//IL_0498: Expected O, but got I
			//IL_0506: Expected O, but got I4
			//IL_051e: Expected O, but got I
			//IL_0428: Expected O, but got I
			//IL_1495: Expected I, but got O
			//IL_136d: Expected I, but got O
			//IL_0562: Expected O, but got I
			//IL_13ce: Expected I, but got O
			//IL_0630: Expected O, but got I
			//IL_05e4: Unknown result type (might be due to invalid IL or missing references)
			//IL_05e9: Expected O, but got Unknown
			//IL_0606: Expected O, but got I
			//IL_0615: Expected O, but got I
			//IL_05ae: Expected O, but got I
			//IL_142f: Expected I, but got O
			//IL_06fe: Expected O, but got I
			//IL_06b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_06b7: Expected O, but got Unknown
			//IL_06d4: Expected O, but got I
			//IL_06e3: Expected O, but got I
			//IL_067c: Expected O, but got I
			//IL_07cc: Expected O, but got I
			//IL_0780: Unknown result type (might be due to invalid IL or missing references)
			//IL_0785: Expected O, but got Unknown
			//IL_07a2: Expected O, but got I
			//IL_07b1: Expected O, but got I
			//IL_074a: Expected O, but got I
			//IL_084e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0853: Expected O, but got Unknown
			//IL_0870: Expected O, but got I
			//IL_087f: Expected O, but got I
			//IL_0818: Expected O, but got I
			//IL_0bf1: Expected F4, but got O
			//IL_0bfe: Expected F4, but got O
			//IL_0c19: Expected F4, but got O
			//IL_0c3a: Expected F4, but got O
			//IL_0c47: Expected F4, but got O
			//IL_0c62: Expected F4, but got O
			//IL_0c83: Expected F4, but got O
			//IL_0c90: Expected F4, but got O
			//IL_0cab: Expected F4, but got O
			//IL_0ccc: Expected F4, but got O
			//IL_0cd9: Expected F4, but got O
			//IL_0cf4: Expected F4, but got O
			//IL_0d15: Expected F4, but got O
			//IL_0d22: Expected F4, but got O
			//IL_0d3d: Expected F4, but got O
			//IL_0d5e: Expected F4, but got O
			//IL_0d6b: Expected F4, but got O
			//IL_0d86: Expected F4, but got O
			//IL_0da7: Expected F4, but got O
			//IL_0db4: Expected F4, but got O
			//IL_0dcf: Expected F4, but got O
			//IL_0df0: Expected F4, but got O
			//IL_0dfd: Expected F4, but got O
			//IL_0e18: Expected F4, but got O
			//IL_106d: Expected O, but got I4
			//IL_1085: Expected O, but got I
			ProfilerMarker.Internal_Begin((IntPtr)m_ParticlesToMeshPerfMarker);
			particlesPerDrawcall = 16250;
			IntPtr intPtr = (IntPtr)collection;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ X8_v45 (Il2CppClass<Obi.IObiParticleCollection>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00ad;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ X8_v45 (Il2CppClass<Obi.IObiParticleCollection>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ X11_v85-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IObiParticleCollection))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ X8_v45 (Il2CppClass<Obi.IObiParticleCollection>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00ad;
			}
			object obj2 = obj + 1;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			IntPtr intPtr2 = default(IntPtr);
			int num4 = (int)(long)intPtr2;
			goto IL_1251;
			IL_00ad:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			num4 = 1;
			goto IL_1251;
			IL_1251:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v582 @ X0_v91] (should have been resolved before IL gen)");
			object obj5 = default(object);
			int num5 = (int)((long)(IntPtr)obj5 / (long)particlesPerDrawcall);
			int num6 = num5 + 1;
			drawcallCount = num6;
			IntPtr intPtr3 = (IntPtr)collection;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v590 @ X8_v50 (Il2CppClass<Obi.IObiParticleCollection>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_018c;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v590 @ X8_v50 (Il2CppClass<Obi.IObiParticleCollection>)+B0]");
			object obj6 = 0L + 8L;
			int num7 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v781 @ X11_v80-8]");
				if ((IntPtr)0 == (IntPtr)typeof(IObiParticleCollection))
				{
					break;
				}
				num7++;
				int num8 = num7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v590 @ X8_v50 (Il2CppClass<Obi.IObiParticleCollection>)+126]");
				bool flag3 = (long)num8 < 0L;
				bool flag4 = !flag3;
				obj6 = (long)(IntPtr)obj6 + 16L;
				if (!flag4)
				{
					continue;
				}
				goto IL_018c;
			}
			object obj7 = obj6 + 1;
			int num9 = (int)((long)(IntPtr)obj7 << 4);
			object obj8 = (long)intPtr3 + (long)num9;
			object obj9 = (long)(IntPtr)obj8 + 304L;
			goto IL_12da;
			IL_12da:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v871 @ X0_v94] (should have been resolved before IL gen)");
			int b = default(int);
			int num10 = Mathf.Min(particlesPerDrawcall, b);
			List<Mesh> list = meshes;
			particlesPerDrawcall = num10;
			bool flag5 = drawcallCount == list.Count;
			IntPtr intPtr4 = (IntPtr)null;
			if (!flag5)
			{
				ClearMeshes();
				bool flag6 = drawcallCount < 1;
				intPtr4 = (IntPtr)null;
				if (!flag6)
				{
					int num11 = 0;
					bool flag7;
					do
					{
						Mesh mesh = new Mesh();
						mesh.name = "Particle impostors";
						mesh.hideFlags = HideFlags.HideAndDontSave;
						meshes.Add(mesh);
						num11++;
						flag7 = num11 < drawcallCount;
						intPtr4 = (IntPtr)0;
					}
					while (flag7);
				}
			}
			object obj10 = default(object);
			((List<Mesh>)obj10).Add((Mesh)null);
			object obj11 = default(object);
			((List<Mesh>)obj11).Add((Mesh)null);
			int num12 = default(int);
			((List<Mesh>)num12).Add(null);
			int num13 = 0;
			float num14 = 1f;
			int num15 = 0;
			int num16 = 0;
			int num17 = 0;
			int b2 = default(int);
			Vector3 item = default(Vector3);
			Vector3 item2 = default(Vector3);
			Vector3 item3 = default(Vector3);
			Vector3 item4 = default(Vector3);
			Vector3 item5 = default(Vector3);
			Vector3 item6 = default(Vector3);
			Vector3 item7 = default(Vector3);
			Vector3 item8 = default(Vector3);
			Color item9 = default(Color);
			Color item10 = default(Color);
			Color item11 = default(Color);
			Color item12 = default(Color);
			Vector4 item13 = default(Vector4);
			object obj35 = default(object);
			object obj36 = default(object);
			Vector4 item14 = default(Vector4);
			Vector4 item15 = default(Vector4);
			Vector4 item16 = default(Vector4);
			Vector4 item17 = default(Vector4);
			object obj37 = default(object);
			object obj38 = default(object);
			Vector4 item18 = default(Vector4);
			Vector4 item19 = default(Vector4);
			Vector4 item20 = default(Vector4);
			Vector4 item21 = default(Vector4);
			int num41 = default(int);
			int num42 = default(int);
			Vector4 item22 = default(Vector4);
			Vector4 item23 = default(Vector4);
			Vector4 item24 = default(Vector4);
			List<int> list3 = default(List<int>);
			IntPtr markerPtr = default(IntPtr);
			while (true)
			{
				if (num17 < drawcallCount)
				{
					vertices.Clear();
					normals.Clear();
					colors.Clear();
					triangles.Clear();
					anisotropy1.Clear();
					anisotropy2.Clear();
					anisotropy3.Clear();
					IntPtr intPtr5 = (IntPtr)collection;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3267 @ X8_v65 (Il2CppClass<Obi.IObiParticleCollection>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_0441;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3267 @ X8_v65 (Il2CppClass<Obi.IObiParticleCollection>)+B0]");
					object obj12 = 0L + 8L;
					int num18 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3469 @ X11_v75-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IObiParticleCollection))
						{
							break;
						}
						num18++;
						int num19 = num18;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3267 @ X8_v65 (Il2CppClass<Obi.IObiParticleCollection>)+126]");
						bool flag8 = (long)num19 < 0L;
						bool flag9 = !flag8;
						obj12 = (long)(IntPtr)obj12 + 16L;
						if (!flag9)
						{
							continue;
						}
						goto IL_0441;
					}
					object obj13 = obj12 + 1;
					int num20 = (int)((long)(IntPtr)obj13 << 4);
					object obj14 = (long)intPtr5 + (long)num20;
					object obj15 = (long)(IntPtr)obj14 + 304L;
					goto IL_1322;
				}
				ProfilerMarker.Internal_End((IntPtr)m_ParticlesToMeshPerfMarker);
				break;
				IL_1322:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v3578 @ X0_v123] (should have been resolved before IL gen)");
				int num21 = num17 + 1;
				int a = particlesPerDrawcall * num21;
				int num22 = Mathf.Min(a, b2);
				int num23 = particlesPerDrawcall * num17;
				bool flag10 = num23 >= num22;
				intPtr4 = (IntPtr)null;
				if (!flag10)
				{
					object obj16 = num12;
					object obj17 = obj11;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4261 @ X0_v141+8]");
					object obj18 = 0;
					int num24 = num13;
					float num25 = num14;
					int num26 = num15;
					int num27 = num16;
					int num28 = 0;
					bool flag19;
					do
					{
						IntPtr intPtr6 = (IntPtr)collection;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3967 @ X8_v78 (Il2CppClass<Obi.IObiParticleCollection>)+126]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							goto IL_05c7;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3967 @ X8_v78 (Il2CppClass<Obi.IObiParticleCollection>)+B0]");
						object obj19 = 0L + 8L;
						int num29 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4037 @ X11_v70-8]");
							if ((IntPtr)0 == (IntPtr)typeof(IObiParticleCollection))
							{
								break;
							}
							num29++;
							int num30 = num29;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3967 @ X8_v78 (Il2CppClass<Obi.IObiParticleCollection>)+126]");
							bool flag11 = (long)num30 < 0L;
							bool flag12 = !flag11;
							obj19 = (long)(IntPtr)obj19 + 16L;
							if (!flag12)
							{
								continue;
							}
							goto IL_05c7;
						}
						object obj20 = obj19 + 3;
						int num31 = (int)((long)(IntPtr)obj20 << 4);
						object obj21 = (long)intPtr6 + (long)num31;
						object obj22 = (long)(IntPtr)obj21 + 304L;
						goto IL_135b;
						IL_0695:
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
						goto IL_13bc;
						IL_13bc:
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v4177 @ X0_v138] (should have been resolved before IL gen)");
						IntPtr intPtr7 = (IntPtr)collection;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4184 @ X8_v84 (Il2CppClass<Obi.IObiParticleCollection>)+126]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							goto IL_0763;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4184 @ X8_v84 (Il2CppClass<Obi.IObiParticleCollection>)+B0]");
						object obj23 = 0L + 8L;
						int num32 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4230 @ X11_v60-8]");
							if ((IntPtr)0 == (IntPtr)typeof(IObiParticleCollection))
							{
								break;
							}
							num32++;
							int num33 = num32;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4184 @ X8_v84 (Il2CppClass<Obi.IObiParticleCollection>)+126]");
							bool flag13 = (long)num33 < 0L;
							bool flag14 = !flag13;
							obj23 = (long)(IntPtr)obj23 + 16L;
							if (!flag14)
							{
								continue;
							}
							goto IL_0763;
						}
						object obj24 = obj23 + 6;
						int num34 = (int)((long)(IntPtr)obj24 << 4);
						object obj25 = (long)intPtr7 + (long)num34;
						object obj26 = (long)(IntPtr)obj25 + 304L;
						goto IL_141d;
						IL_141d:
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v4261 @ X0_v141] (should have been resolved before IL gen)");
						IntPtr intPtr8 = (IntPtr)collection;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4268 @ X8_v87 (Il2CppClass<Obi.IObiParticleCollection>)+126]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							goto IL_0831;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4268 @ X8_v87 (Il2CppClass<Obi.IObiParticleCollection>)+B0]");
						object obj27 = 0L + 8L;
						int num35 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4313 @ X11_v55-8]");
							if ((IntPtr)0 == (IntPtr)typeof(IObiParticleCollection))
							{
								break;
							}
							num35++;
							int num36 = num35;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4268 @ X8_v87 (Il2CppClass<Obi.IObiParticleCollection>)+126]");
							bool flag15 = (long)num36 < 0L;
							bool flag16 = !flag15;
							obj27 = (long)(IntPtr)obj27 + 16L;
							if (!flag16)
							{
								continue;
							}
							goto IL_0831;
						}
						object obj28 = obj27 + 8;
						int num37 = (int)((long)(IntPtr)obj28 << 4);
						object obj29 = (long)intPtr8 + (long)num37;
						object obj30 = (long)(IntPtr)obj29 + 304L;
						goto IL_147e;
						IL_05c7:
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
						goto IL_135b;
						IL_135b:
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v4069 @ X0_v135] (should have been resolved before IL gen)");
						IntPtr intPtr9 = (IntPtr)collection;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4076 @ X8_v81 (Il2CppClass<Obi.IObiParticleCollection>)+126]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							goto IL_0695;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4076 @ X8_v81 (Il2CppClass<Obi.IObiParticleCollection>)+B0]");
						object obj31 = 0L + 8L;
						int num38 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4142 @ X11_v65-8]");
							if ((IntPtr)0 == (IntPtr)typeof(IObiParticleCollection))
							{
								break;
							}
							num38++;
							int num39 = num38;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4076 @ X8_v81 (Il2CppClass<Obi.IObiParticleCollection>)+126]");
							bool flag17 = (long)num39 < 0L;
							bool flag18 = !flag17;
							obj31 = (long)(IntPtr)obj31 + 16L;
							if (!flag18)
							{
								continue;
							}
							goto IL_0695;
						}
						object obj32 = obj31 + 4;
						int num40 = (int)((long)(IntPtr)obj32 << 4);
						object obj33 = (long)intPtr9 + (long)num40;
						object obj34 = (long)(IntPtr)obj33 + 304L;
						goto IL_13bc;
						IL_147e:
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v4330 @ X0_v144] (should have been resolved before IL gen)");
						item.x = num27;
						item.y = num26;
						item.z = num25;
						vertices.Add(item);
						item2.x = num27;
						item2.y = num26;
						item2.z = num25;
						vertices.Add(item2);
						item3.x = num27;
						item3.y = num26;
						item3.z = num25;
						vertices.Add(item3);
						item4.x = num27;
						item4.y = num26;
						item4.z = num25;
						vertices.Add(item4);
						item5.x = particleOffset0.x;
						item5.y = particleOffset0.y;
						item5.z = particleOffset0.z;
						normals.Add(item5);
						item6.x = particleOffset1.x;
						item6.y = particleOffset1.y;
						item6.z = particleOffset1.z;
						normals.Add(item6);
						item7.x = particleOffset2.x;
						item7.y = particleOffset2.y;
						item7.z = particleOffset2.z;
						normals.Add(item7);
						item8.x = particleOffset3.x;
						item8.y = particleOffset3.y;
						item8.z = particleOffset3.z;
						normals.Add(item8);
						item9.r = num27;
						item9.g = num26;
						item9.b = num25;
						item9.a = num24;
						colors.Add(item9);
						item10.r = num27;
						item10.g = num26;
						item10.b = num25;
						item10.a = num24;
						colors.Add(item10);
						item11.r = num27;
						item11.g = num26;
						item11.b = num25;
						item11.a = num24;
						colors.Add(item11);
						item12.r = num27;
						item12.g = num26;
						item12.b = num25;
						item12.a = num24;
						colors.Add(item12);
						item13.x = (float)obj10;
						item13.y = (float)obj35;
						item13.z = 0f;
						item13.w = (float)obj36;
						anisotropy1.Add(item13);
						item14.x = (float)obj10;
						item14.y = (float)obj35;
						item14.z = 0f;
						item14.w = (float)obj36;
						anisotropy1.Add(item14);
						item15.x = (float)obj10;
						item15.y = (float)obj35;
						item15.z = 0f;
						item15.w = (float)obj36;
						anisotropy1.Add(item15);
						item16.x = (float)obj10;
						item16.y = (float)obj35;
						item16.z = 0f;
						item16.w = (float)obj36;
						anisotropy1.Add(item16);
						item17.x = (float)obj11;
						item17.y = (float)obj37;
						item17.z = 0f;
						item17.w = (float)obj38;
						anisotropy2.Add(item17);
						item18.x = (float)obj11;
						item18.y = (float)obj37;
						item18.z = 0f;
						item18.w = (float)obj38;
						anisotropy2.Add(item18);
						item19.x = (float)obj11;
						item19.y = (float)obj37;
						item19.z = 0f;
						item19.w = (float)obj38;
						anisotropy2.Add(item19);
						item20.x = (float)obj11;
						item20.y = (float)obj37;
						item20.z = 0f;
						item20.w = (float)obj38;
						anisotropy2.Add(item20);
						item21.x = num12;
						item21.y = num41;
						item21.z = 0f;
						item21.w = num42;
						anisotropy3.Add(item21);
						item22.x = num12;
						item22.y = num41;
						item22.z = 0f;
						item22.w = num42;
						anisotropy3.Add(item22);
						item23.x = num12;
						item23.y = num41;
						item23.z = 0f;
						item23.w = num42;
						anisotropy3.Add(item23);
						item24.x = num12;
						item24.y = num41;
						item24.z = 0f;
						item24.w = num42;
						anisotropy3.Add(item24);
						int item25 = num28 | 2;
						triangles.Add(item25);
						int item26 = num28 | 1;
						triangles.Add(item26);
						triangles.Add(num28);
						int item27 = num28 | 3;
						triangles.Add(item27);
						triangles.Add(item25);
						if (triangles != null)
						{
							triangles.Add(num28);
							num23++;
							num28 += 4;
							flag19 = num23 < num22;
							num13 = num42;
							num14 = 0f;
							num15 = num41;
							num16 = num12;
							intPtr4 = (IntPtr)0;
							obj16 = num12;
							obj17 = obj11;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4261 @ X0_v141+8]");
							obj18 = 0;
							num24 = num42;
							num25 = 0f;
							num26 = num41;
							num27 = num12;
							continue;
						}
						NullReferenceException ex = new NullReferenceException();
						List<int> list2 = (List<int>)(object)ex;
						while (true)
						{
							if (0 == 1)
							{
								list2.Add(0);
								list3.Add(0);
								ProfilerMarker.Internal_End(markerPtr);
								if (list3 == null)
								{
									break;
								}
							}
							else
							{
								list2.Add(0);
							}
							TypeLoadException ex2 = new TypeLoadException();
							list2 = (List<int>)(object)ex2;
						}
						return;
						IL_0831:
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
						goto IL_147e;
						IL_0763:
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
						goto IL_141d;
					}
					while (flag19);
				}
				List<Mesh> list4 = meshes;
				bool flag20 = list4.Count < num17;
				bool flag21 = !flag20;
				int num43 = list4.Count - num17;
				bool flag22 = num43 == 0;
				bool flag23 = !flag22;
				if (!(flag21 && flag23))
				{
					throw new ArgumentOutOfRangeException();
				}
				Mesh[] items = list4._items;
				Apply(items[num17]);
				num17 = num21;
				continue;
				IL_0441:
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
				intPtr4 = (IntPtr)1;
				goto IL_1322;
			}
			return;
			IL_018c:
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
			num4 = 1;
			goto IL_12da;
		}

		[Token(Token = "0x60002F5")]
		[Address(RVA = "0x103554C", Offset = "0x103554C", Length = "0x258")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv26 = *([1EECD98]);\n\tv27 = *([v26 @ X8_v20]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([202629E]) = v46;\nL_001A:\n\tv50 = new System.Collections.Generic.List`1<UnityEngine.Mesh>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Mesh>::.ctor(v50);\n\tthis.meshes = v50;\n\tv58 = new System.Collections.Generic.List`1<UnityEngine.Vector3>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::.ctor(v58, 0xFA0);\n\tthis.vertices = v58;\n\tv65 = new System.Collections.Generic.List`1<UnityEngine.Vector3>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::.ctor(v65, 0xFA0);\n\tthis.normals = v65;\n\tv72 = new System.Collections.Generic.List`1<UnityEngine.Color>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Color>::.ctor(v72, 0xFA0);\n\tthis.colors = v72;\n\tv81 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v81, 0x1770);\n\tthis.triangles = v81;\n\tv90 = new System.Collections.Generic.List`1<UnityEngine.Vector4>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector4>::.ctor(v90, 0xFA0);\n\tthis.anisotropy1 = v90;\n\tv97 = new System.Collections.Generic.List`1<UnityEngine.Vector4>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector4>::.ctor(v97, 0xFA0);\n\tthis.anisotropy2 = v97;\n\tv102 = new System.Collections.Generic.List`1<UnityEngine.Vector4>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector4>::.ctor(v102, 0xFA0);\n\tthis.anisotropy3 = v102;\n\tv108 = 0;\n\tv114 = System.Collections.Generic.List`1<UnityEngine.Vector4>::.ctor(&v108 @ stack_-50_v1 (UnityEngine.Vector3), 0);\n\tthis.particleOffset0 = 0;\n\tthis.particleOffset0.z = 0f;\n\tv119 = 0;\n\tv125 = System.Collections.Generic.List`1<UnityEngine.Vector4>::.ctor(&v119 @ stack_-60_v1 (UnityEngine.Vector3), 0);\n\tthis.particleOffset1 = 0;\n\tthis.particleOffset1.z = 0f;\n\tv129 = 0;\n\tv135 = System.Collections.Generic.List`1<UnityEngine.Vector4>::.ctor(&v129 @ stack_-70_v1 (UnityEngine.Vector3), 0);\n\tthis.particleOffset2 = 0;\n\tthis.particleOffset2.z = 0f;\n\tv139 = 0;\n\tv145 = System.Collections.Generic.List`1<UnityEngine.Vector4>::.ctor(&v139 @ stack_-80_v1 (UnityEngine.Vector3), 0);\n\tthis.particleOffset3 = 0;\n\tthis.particleOffset3.z = 0f;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 113 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ParticleImpostorRendering()
		{
			List<Mesh> list = new List<Mesh>();
			meshes = list;
			List<Vector3> list2 = new List<Vector3>(4000);
			vertices = list2;
			List<Vector3> list3 = new List<Vector3>(4000);
			normals = list3;
			List<Color> list4 = new List<Color>(4000);
			colors = list4;
			List<int> list5 = new List<int>(6000);
			triangles = list5;
			List<Vector4> list6 = new List<Vector4>(4000);
			anisotropy1 = list6;
			List<Vector4> list7 = new List<Vector4>(4000);
			anisotropy2 = list7;
			List<Vector4> list8 = new List<Vector4>(4000);
			anisotropy3 = list8;
			Vector3 vector = default(Vector3);
			particleOffset0 = default(Vector3);
			particleOffset0.z = 0f;
			Vector3 vector2 = default(Vector3);
			particleOffset1 = default(Vector3);
			particleOffset1.z = 0f;
			Vector3 vector3 = default(Vector3);
			particleOffset2 = default(Vector3);
			particleOffset2.z = 0f;
			Vector3 vector4 = default(Vector3);
			particleOffset3 = default(Vector3);
			particleOffset3.z = 0f;
		}

		[Token(Token = "0x60002F6")]
		[Address(RVA = "0x10357A4", Offset = "0x10357A4", Length = "0x90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1EBAB98]);\n\tv15 = *([v14 @ X8_v10]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202629F]) = v35;\nL_0016:\n\tv41 = Unity.Profiling.ProfilerMarker::Internal_Create(\"ParticlesToMesh\", 0);\n\tv45.m_ParticlesToMeshPerfMarker = v41;\n\treturn;\n\tX8 = X0 + 4;\n\tC = X1 < 0;\n\tC = ~C;\n\tTEMP1 = X1 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 0;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tTEMPCSEL = ~TEMPCOND;\n\tif (TEMPCSEL) goto L_0030;\n\tX8 = X8;\n\tgoto L_0031;\nL_0030:\n\tX8 = X0;\nL_0031:\n\t;\n\tX0 = *([X8]);\n\treturn;\n\tX8 = X0 + 4;\n\tC = X1 < 0;\n\tC = ~C;\n\tTEMP1 = X1 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 0;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCSEL = ~Z;\n\tif (TEMPCSEL) goto L_0042;\n\tX8 = X0;\n\tgoto L_0043;\nL_0042:\n\tX8 = X8;\nL_0043:\n\t;\n\t*([X8]) = X2;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static ParticleImpostorRendering()
		{
			//IL_002a: Expected O, but got I
			IntPtr intPtr = ProfilerMarker.Internal_Create("ParticlesToMesh", default(Unity.Profiling.MarkerFlags));
			m_ParticlesToMeshPerfMarker = (ProfilerMarker)(long)intPtr;
		}
	}
}
