using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Profiling;
using UnityEngine;

namespace Obi
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x744F74", Offset = "0x744F74")]
	[ExecuteInEditMode]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x744F74", Offset = "0x744F74")]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x744F74", Offset = "0x744F74")]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x744F74", Offset = "0x744F74")]
	[Token(Token = "0x200007D")]
	public class ObiRopeExtrudedRenderer : MonoBehaviour
	{
		[Token(Token = "0x400021A")]
		private static ProfilerMarker m_UpdateExtrudedRopeRendererChunksPerfMarker;

		[Token(Token = "0x400021B")]
		[FieldOffset(Offset = "0x18")]
		private List<Vector3> vertices;

		[Token(Token = "0x400021C")]
		[FieldOffset(Offset = "0x20")]
		private List<Vector3> normals;

		[Token(Token = "0x400021D")]
		[FieldOffset(Offset = "0x28")]
		private List<Vector4> tangents;

		[Token(Token = "0x400021E")]
		[FieldOffset(Offset = "0x30")]
		private List<Vector2> uvs;

		[Token(Token = "0x400021F")]
		[FieldOffset(Offset = "0x38")]
		private List<Color> vertColors;

		[Token(Token = "0x4000220")]
		[FieldOffset(Offset = "0x40")]
		private List<int> tris;

		[Token(Token = "0x4000221")]
		[FieldOffset(Offset = "0x48")]
		private ObiPathSmoother smoother;

		[NonSerialized]
		[HideInInspector]
		[Token(Token = "0x4000222")]
		[FieldOffset(Offset = "0x50")]
		public Mesh extrudedMesh;

		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x746AC8", Offset = "0x746AC8")]
		[Token(Token = "0x4000223")]
		[FieldOffset(Offset = "0x58")]
		public float uvAnchor;

		[Token(Token = "0x4000224")]
		[FieldOffset(Offset = "0x5C")]
		public Vector2 uvScale;

		[Token(Token = "0x4000225")]
		[FieldOffset(Offset = "0x64")]
		public bool normalizeV;

		[Token(Token = "0x4000226")]
		[FieldOffset(Offset = "0x68")]
		public ObiRopeSection section;

		[Token(Token = "0x4000227")]
		[FieldOffset(Offset = "0x70")]
		public float thicknessScale;

		[Token(Token = "0x60004DF")]
		[Address(RVA = "0xC3C6EC", Offset = "0xC3C6EC", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1ECF648]);\n\tv21 = *([v20 @ X8_v10]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20231DF]) = v40;\nL_0018:\n\tv45 = UnityEngine.Component::GetComponent(this);\n\tthis.smoother = v45;\n\tv50 = new Obi.ObiActor+ActorCallback();\n\tObi.ObiActor+ActorCallback::.ctor(v50, this, Il2CppMethodInfo);\n\tObi.ObiPathSmoother::add_OnCurveGenerated(v45, v50);\n\tObi.ObiRopeExtrudedRenderer::CreateMeshIfNeeded(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnEnable()
		{
			ObiPathSmoother obiPathSmoother = (smoother = GetComponent<ObiPathSmoother>());
			ObiActor.ActorCallback value = UpdateRenderer;
			obiPathSmoother.OnCurveGenerated += value;
			CreateMeshIfNeeded();
		}

		[Token(Token = "0x60004E0")]
		[Address(RVA = "0xC3C890", Offset = "0xC3C890", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EF4B18]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20231E0]) = v40;\nL_0018:\n\tv45 = new Obi.ObiActor+ActorCallback();\n\tObi.ObiActor+ActorCallback::.ctor(v45, this, Il2CppMethodInfo);\n\tObi.ObiPathSmoother::remove_OnCurveGenerated(this.smoother, v45);\n\tgoto L_003A;\n\tv64 = *([v60 @ X0_v7+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_003A;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v60, v54, v51, v49, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_003A:\n\tUnityEngine.Object::DestroyImmediate(this.extrudedMesh);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDisable()
		{
			ObiActor.ActorCallback value = UpdateRenderer;
			smoother.OnCurveGenerated -= value;
			UnityEngine.Object.DestroyImmediate(extrudedMesh);
		}

		[Token(Token = "0x60004E1")]
		[Address(RVA = "0xC3C798", Offset = "0xC3C798", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1EEFA60]);\n\tv19 = *([v18 @ X8_v17]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20231E1]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Equality(this.extrudedMesh, 0);\n\tv58 = v56 == 0;\n\tif (v58) goto L_0051;\n\tv62 = new UnityEngine.Mesh();\n\tUnityEngine.Mesh::.ctor(v62);\n\tthis.extrudedMesh = v62;\n\tUnityEngine.Object::set_name(v62, \"extrudedMesh\");\n\tUnityEngine.Mesh::MarkDynamic(this.extrudedMesh);\n\tv78 = UnityEngine.Component::GetComponent(this);\n\tUnityEngine.MeshFilter::set_mesh(v78, this.extrudedMesh);\n\treturn;\nL_0051:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CreateMeshIfNeeded()
		{
			if (extrudedMesh == null)
			{
				(extrudedMesh = new Mesh()).name = "extrudedMesh";
				extrudedMesh.MarkDynamic();
				MeshFilter component = GetComponent<MeshFilter>();
				component.mesh = extrudedMesh;
			}
		}

		[Token(Token = "0x60004E2")]
		[Address(RVA = "0xC3C94C", Offset = "0xC3C94C", Length = "0x9BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv40 = &v41 @ stack_-10_v2;\n\tgoto L_0027;\n\tv52 = *([1EF3A88]);\n\tv53 = *([v52 @ X8_v142]);\n\tv54 = \"il2cpp_codegen_initialize_method\"(v53, actor, methodInfo, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv71 = 0 | 1;\n\t*([20231E2]) = v71;\nL_0027:\n\t*([v40 @ X29_v1-98]) = 0;\n\tgoto L_0035;\n\tv78 = *([v74 @ X0_v2 (Il2CppClass<Obi.ObiRopeExtrudedRenderer>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tgoto L_0035;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v74, actor, methodInfo, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv82 = Obi.ObiRopeExtrudedRenderer;\nL_0035:\n\tv3347 = v85.m_UpdateExtrudedRopeRendererChunksPerfMarker;\n\tUnity.Profiling.ProfilerMarker::Internal_Begin(v85.m_UpdateExtrudedRopeRendererChunksPerfMarker);\n\tgoto L_0048;\n\tv97 = *([v93 @ X0_v5+E0]);\n\tv98 = v97 == 0;\n\tv99 = ~v98;\n\tgoto L_0048;\n\tv101 = \"il2cpp_codegen_runtime_class_init\"(v93, v86, methodInfo, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68);\nL_0048:\n\tv107 = UnityEngine.Object::op_Equality(this.section, 0);\n\tv109 = v107 == 0;\n\tif (v109) goto L_0050;\nL_004E:\n\tUnity.Profiling.ProfilerMarker::Internal_End(v3347);\n\tgoto L_03E5;\nL_0050:\n\tv663 = actor == 0;\n\tif (v663) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0078;\n\tv1110 = v1110_asT == 0;\n\tif (v1110) goto L_FFFFFFFF;\n\tgoto L_0078;\nL_0078:\n\tObi.ObiRopeExtrudedRenderer::CreateMeshIfNeeded(this);\n\tObi.ObiRopeExtrudedRenderer::ClearMeshData(this);\n\tv1328 = this.smoother;\n\tv1909 = Obi.ObiRopeSection::get_Segments(this.section);\n\tgoto L_0098;\n\tv2486 = *([v2106 @ X0_v56+E0]);\n\tv2487 = v2486 == 0;\n\tv2488 = ~v2487;\n\tif (v2488) goto L_0098;\n\tv2490 = \"il2cpp_codegen_runtime_class_init\"(v2106, v1908, v106, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68);\nL_0098:\n\tv2494 = UnityEngine.Vector4::get_zero();\n\tgoto L_00A9;\n\tv2903 = *([v2699 @ X0_v59+E0]);\n\tv2904 = v2903 == 0;\n\tv2905 = ~v2904;\n\tif (v2905) goto L_00A9;\n\tv2907 = \"il2cpp_codegen_runtime_class_init\"(v2699, v1908, v106, v56, v57, v58, v59, v60, v2494, v2694, v2695, v2696, v65, v66, v67, v68);\nL_00A9:\n\tv2911 = UnityEngine.Vector2::get_zero();\n\t*([v40 @ X29_v1-98]) = v2911;\n\t*([v40 @ X29_v1-94]) = v2911.y;\n\tv4258 = this.smoother;\n\tv3334 = v1328.smoothLength / *([v1122 @ X19_v6 (Obi.ObiActor)+84]);\n\tv3339 = this.uvScale.y * *([v1122 @ X19_v6 (Obi.ObiActor)+84]);\n\tv3664 = v1909 + 1;\n\tv3343 = v3339 * this.uvAnchor;\n\tv3344 = -v3343;\nL_00BF:\n\tv4259 = v4258.smoothChunks;\n\tv4261 = v1700 >= v4259.count;\n\tif (v4261) goto L_035B;\n\tv4679 = Obi.ObiList`1<Obi.ObiList`1<Obi.ObiPathFrame>>::get_Item(v4259, v1700);\n\tv5366 = v4679.count < 1;\n\tif (v5366) goto L_0352;\n\tv5752 = v3666 + 1;\n\tv5753 = v3664 * v5752;\n\tv5756 = v3664 * v3666;\nL_00EE:\n\tgoto L_00F4;\n\tv6147 = *([v6140 @ X0_v88+E0]);\n\tv6148 = v6147 == 0;\n\tv6149 = ~v6148;\n\tgoto L_00F4;\n\tv6151 = \"il2cpp_codegen_runtime_class_init\"(v6140, v6134, v6133, v56, v57, v58, v59, v60, v6127, v6126, v6125, v6124, v6103, v6102, v67, v68);\nL_00F4:\n\tv6154 = v2421 - 1;\n\tv6157 = UnityEngine.Mathf::Max(v6154, 0);\n\tv6162 = Obi.ObiList`1<Obi.ObiPathFrame>::get_Item(v4679, v2421);\n\tv6166 = &v553 @ stack_-138;\n\tv6168 = Obi.ObiList`1<Obi.ObiPathFrame>::get_Item(v4679, v6157);\n\tv553 = *([v6166 @ X8_v59]);\n\tgoto L_012E;\n\tv6182 = *([v6174 @ X0_v96+E0]);\n\tv6183 = v6182 == 0;\n\tv6184 = ~v6183;\n\tif (v6184) goto L_012E;\n\tv6186 = \"il2cpp_codegen_runtime_class_init\"(v6174, v4062, v4060, v56, v57, v58, v59, v60, v6127, v6126, v6125, v6124, v6103, v6102, v67, v68);\nL_012E:\n\t// 302 MakeStruct v2369 @ AGGC3CC44_0_v26 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v40 @ X29_v1-E0], [v40 @ X29_v1-DC], [v40 @ X29_v1-D8]\n\t// 303 MakeStruct v2367 @ AGGC3CC44_1_v26 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v6166 @ X8_v59], [v6166 @ X8_v59+4], [v6166 @ X8_v59+8]\n\tv4028 = UnityEngine.Vector3::Distance(v2369, v2367);\n\tv6191 = ~this.normalizeV;\n\tif (v6191) goto L_013B;\n\tv4070 = this.smoother;\n\tv6193 = v4070.smoothLength;\nL_013B:\n\tv6198 = &v490 @ stack_-180;\n\tv6201 = Obi.ObiList`1<Obi.ObiPathFrame>::get_Item(v4679, v2421);\n\tv490 = *([v6198 @ X8_v66]);\n\tv6205 = &v437 @ stack_-1C8;\n\tv6208 = Obi.ObiList`1<Obi.ObiPathFrame>::get_Item(v4679, v2421);\n\tv437 = *([v6205 @ X8_v67]);\n\tgoto L_0177;\n\tv6218 = *([v6214 @ X0_v103+E0]);\n\tv6219 = v6218 == 0;\n\tv6220 = ~v6219;\n\tgoto L_0177;\n\tv6222 = \"il2cpp_codegen_runtime_class_init\"(v6214, v6207, v6204, v56, v57, v58, v59, v60, v4028, v4026, v4024, v4022, v3983, v3981, v67, v68);\nL_0177:\n\tv6225 = *([v6198 @ X8_v66+40]) * this.thicknessScale;\n\t// 381 MakeStruct v2295 @ AGGC3CCD8_0_v26 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v6205 @ X8_v67+18], [v6205 @ X8_v67+1C], [v6205 @ X8_v67+20]\n\tv6231 = UnityEngine.Vector3::op_Multiply(v2295, v6225);\n\tv6238 = &v383 @ stack_-210;\n\tv6241 = Obi.ObiList`1<Obi.ObiPathFrame>::get_Item(v4679, v2421);\n\tv383 = *([v6238 @ X8_v72]);\n\t// 415 MakeStruct v2259 @ AGGC3CD10_0_v26 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v6238 @ X8_v72+24], [v6238 @ X8_v72+28], [v6238 @ X8_v72+2C]\n\tv6247 = UnityEngine.Vector3::op_Multiply(v2259, v6225);\n\tv6251 = v4028 / v6193;\n\tv6252 = this.uvScale.y * v6251;\n\tv6253 = v4015 + v6252;\n\tv6254 = v1909 & 0x80000000;\n\tv6255 = v6254 == 0;\n\tv6256 = ~v6255;\n\tif (v6256) goto L_033C;\nL_01B3:\n\tv5155 = this.section;\n\tv5519 = v5155.vertices;\n\tv6296 = v5519._size < v2429;\n\tv6065 = ~v6296;\n\tv6063 = v5519._size - v2429;\n\tv6059 = v6063 == 0;\n\tv6297 = ~v6059;\n\tv6028 = v6065 & v6297;\n\tif (v6028) goto L_01CB;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_01CB:\n\tv6049 = v2429 << 3;\n\tv6303 = v5519._items + v6049;\n\tgoto L_01DD;\n\tv6308 = *([v6304 @ X0_v112+E0]);\n\tv6309 = v6308 == 0;\n\tv6310 = ~v6309;\n\tif (v6310) goto L_01DD;\n\tv6312 = \"il2cpp_codegen_runtime_class_init\"(v6304, v5149, v5147, v56, v57, v58, v59, v60, v5115, v5113, v5111, v5109, v5074, v5072, v67, v68);\nL_01DD:\n\t// 477 MakeStruct v2245 @ AGGC3CDA4_1_v28 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v5121 @ V11_v32 (UnityEngine.Vector3), v5119 @ V12_v32 (System.Single), v5051 @ V15_v30 (System.Single)\n\tv6039 = UnityEngine.Vector3::op_Multiply(*([v6303 @ X8_v81+20]), v2245);\n\tv6075 = this.section;\n\tv2413 = v6075.vertices;\n\tv6319 = v2413._size < v2429;\n\tv2469 = ~v6319;\n\tv2467 = v2413._size - v2429;\n\tv2463 = v2467 == 0;\n\tv6320 = ~v2463;\n\tv2425 = v2469 & v6320;\n\tif (v2425) goto L_01F9;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_01F9:\n\tv6323 = v2413._items;\n\tv6330 = UnityEngine.Vector3::op_Multiply(v6323[v2471 @ X9_v38 (System.Int32)].y, v6247);\n\tv6340 = UnityEngine.Vector3::op_Addition(v6039, v6330);\n\tv6344 = &v299 @ stack_-258;\n\tv6347 = Obi.ObiList`1<Obi.ObiPathFrame>::get_Item(v4679, v2421);\n\tv299 = *([v6344 @ X8_v87]);\n\t// 562 MakeStruct v2203 @ AGGC3CE50_0_v28 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v6344 @ X8_v87], [v6344 @ X8_v87+4], [v6344 @ X8_v87+8]\n\tv6355 = UnityEngine.Vector3::op_Addition(v2203, v6340);\n\tv6361 = &v242 @ stack_-2A0;\n\tv6364 = Obi.ObiList`1<Obi.ObiPathFrame>::get_Item(v4679, v2421);\n\tv242 = *([v6361 @ X8_v88]);\n\t// 603 MakeStruct v2161 @ AGGC3CE98_1_v28 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v6361 @ X8_v88+C], [v6361 @ X8_v88+10], [v6361 @ X8_v88+14]\n\tv6370 = UnityEngine.Vector3::Cross(v6340, v2161);\n\tgoto L_0273;\n\tv6382 = *([v6378 @ X0_v124+E0]);\n\tv6383 = v6382 == 0;\n\tv6384 = ~v6383;\n\tif (v6384) goto L_0273;\n\tv6386 = \"il2cpp_codegen_runtime_class_init\"(v6378, v6363, v2473, v56, v57, v58, v59, v60, v6370, v6371, v6372, v6365, v2373, v2371, v67, v68);\nL_0273:\n\tv6392 = UnityEngine.Vector4::op_Implicit(v6370);\n\tv6397 = v2429 / v1909;\n\tv2441 = v6397 * this.uvScale;\n\tv6398 = &v41 @ stack_-10_v2 - 0x98;\n\tv6399 = 0x1588BC0(v6398, 0, Il2CppMethodInfo, v56, v57, v58, v59, v60, v2441, v6253, v1909, v6392.w, *([v6361 @ X8_v88+10]), *([v6361 @ X8_v88+14]), v67, v68);\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::Add(this.vertices, v6355);\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::Add(this.normals, v6340);\n\t// 676 MakeStruct v2952 @ AGGC3CF7C_1_v28 (UnityEngine.Vector4), typeof(UnityEngine.Vector4), v6392 @ V0_v53 (UnityEngine.Vector4), v6392.y (System.Single), v6392.z (System.Single), -1f\n\n// ... truncated")]
		public void UpdateRenderer(ObiActor actor)
		{
			//IL_0c1a: Expected I, but got O
			//IL_0c24: Expected I, but got O
			//IL_02ba: Expected F4, but got I
			//IL_02cf: Expected F4, but got I
			//IL_02e4: Expected F4, but got I
			//IL_02f1: Expected F4, but got O
			//IL_0306: Expected F4, but got I
			//IL_031b: Expected F4, but got I
			//IL_039e: Expected F4, but got I
			//IL_03b3: Expected F4, but got I
			//IL_03c8: Expected F4, but got I
			//IL_0417: Expected F4, but got I
			//IL_042c: Expected F4, but got I
			//IL_0441: Expected F4, but got I
			//IL_0498: Expected I4, but got I8
			//IL_059b: Expected O, but got I
			//IL_05e2: Expected F4, but got I
			//IL_06e9: Expected F4, but got O
			//IL_06fe: Expected F4, but got I
			//IL_0713: Expected F4, but got I
			//IL_0762: Expected F4, but got I
			//IL_0777: Expected F4, but got I
			//IL_078c: Expected F4, but got I
			//IL_07e7: Expected O, but got I
			//IL_08ce: Expected F4, but got I
			//IL_08e3: Expected F4, but got I
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			IntPtr intPtr = (IntPtr)m_UpdateExtrudedRopeRendererChunksPerfMarker;
			ProfilerMarker.Internal_Begin((IntPtr)m_UpdateExtrudedRopeRendererChunksPerfMarker);
			if (!(section == null))
			{
				if ((object)actor == null)
				{
					ObiActor obiActor = null;
				}
				else
				{
					ObiRopeBase obiRopeBase = actor as ObiRopeBase;
					if ((object)obiRopeBase != null)
					{
						ObiActor obiActor = actor;
					}
					else
					{
						ObiActor obiActor = null;
					}
				}
				CreateMeshIfNeeded();
				ClearMeshData();
				ObiPathSmoother obiPathSmoother = smoother;
				int segments = section.Segments;
				Vector4 zero = Vector4.zero;
				_ = Vector2.zero.y;
				ObiPathSmoother obiPathSmoother2 = smoother;
				float num = obiPathSmoother.SmoothLength;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1122 @ X19_v6 (Obi.ObiActor)+84]");
				float num2 = num / 0f;
				float num3 = uvScale.y;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1122 @ X19_v6 (Obi.ObiActor)+84]");
				float num4 = num3 * 0f;
				int num5 = segments + 1;
				float num6 = num4 * uvAnchor;
				float num7 = 0f - num6;
				float num8 = num7;
				int num9 = 0;
				int num10 = 0;
				object obj4 = default(object);
				Vector3 a2 = default(Vector3);
				Vector3 b = default(Vector3);
				object obj6 = default(object);
				object obj8 = default(object);
				Vector3 vector = default(Vector3);
				object obj10 = default(object);
				Vector3 vector3 = default(Vector3);
				Vector3 vector6 = default(Vector3);
				int num31 = default(int);
				object obj13 = default(object);
				Vector3 vector10 = default(Vector3);
				object obj15 = default(object);
				Vector3 rhs = default(Vector3);
				Vector4 item2 = default(Vector4);
				Vector2 item4 = default(Vector2);
				int num36 = default(int);
				IntPtr markerPtr = default(IntPtr);
				object obj17 = default(object);
				while (true)
				{
					ObiList<ObiList<ObiPathFrame>> smoothChunks = obiPathSmoother2.smoothChunks;
					if (num10 >= smoothChunks.Count)
					{
						break;
					}
					ObiList<ObiPathFrame> obiList = smoothChunks.get_Item(num10);
					bool flag = obiList.Count < 1;
					int num11 = num10;
					if (!flag)
					{
						int num12 = num9 + 1;
						int num13 = num5 * num12;
						int num14 = num5 * num9;
						IntPtr intPtr2 = intPtr;
						int num15 = num14;
						int num16 = num13;
						int num17 = 0;
						float num18 = num8;
						int num19 = num9;
						bool flag16;
						do
						{
							int a = num17 - 1;
							int index = Mathf.Max(a, 0);
							ObiPathFrame obiPathFrame = obiList.get_Item(num17);
							object obj3 = obj4;
							ObiPathFrame obiPathFrame2 = obiList.get_Item(index);
							obj4 = obj3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-E0]");
							a2.x = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-DC]");
							a2.y = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-D8]");
							a2.z = 0f;
							b.x = (float)obj3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6166 @ X8_v59+4]");
							b.y = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6166 @ X8_v59+8]");
							b.z = 0f;
							float num20 = Vector3.Distance(a2, b);
							bool flag2 = !normalizeV;
							float num21 = num2;
							if (!flag2)
							{
								ObiPathSmoother obiPathSmoother3 = smoother;
								num21 = obiPathSmoother3.SmoothLength;
							}
							object obj5 = obj6;
							ObiPathFrame obiPathFrame3 = obiList.get_Item(num17);
							obj6 = obj5;
							object obj7 = obj8;
							ObiPathFrame obiPathFrame4 = obiList.get_Item(num17);
							obj8 = obj7;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6198 @ X8_v66+40]");
							float num22 = 0f * thicknessScale;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6205 @ X8_v67+18]");
							vector.x = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6205 @ X8_v67+1C]");
							vector.y = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6205 @ X8_v67+20]");
							vector.z = 0f;
							Vector3 vector2 = vector * num22;
							object obj9 = obj10;
							ObiPathFrame obiPathFrame5 = obiList.get_Item(num17);
							obj10 = obj9;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6238 @ X8_v72+24]");
							vector3.x = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6238 @ X8_v72+28]");
							vector3.y = 0f;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6238 @ X8_v72+2C]");
							vector3.z = 0f;
							Vector3 vector4 = vector3 * num22;
							float num23 = num20 / num21;
							float num24 = uvScale.y * num23;
							float num25 = num18 + num24;
							int num26 = (int)(segments & 0x80000000L);
							bool flag3 = num26 == 0;
							bool flag4 = !flag3;
							num11 = num17;
							if (!flag4)
							{
								float z = vector2.z;
								int num27 = 0;
								float y = vector2.y;
								Vector3 vector5 = vector2;
								bool flag15;
								do
								{
									ObiRopeSection obiRopeSection = section;
									List<Vector2> list = obiRopeSection.vertices;
									bool flag5 = list.Count < num27;
									bool flag6 = !flag5;
									int num28 = list.Count - num27;
									bool flag7 = num28 == 0;
									bool flag8 = !flag7;
									if (!(flag6 && flag8))
									{
										throw new ArgumentOutOfRangeException();
									}
									int num29 = num27 << 3;
									object obj11 = (long)(IntPtr)list._items + (long)num29;
									vector6.x = vector5.x;
									vector6.y = y;
									vector6.z = z;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6303 @ X8_v81+20]");
									Vector3 vector7 = 0f * vector6;
									ObiRopeSection obiRopeSection2 = section;
									List<Vector2> list2 = obiRopeSection2.vertices;
									bool flag9 = list2.Count < num27;
									bool flag10 = !flag9;
									int num30 = list2.Count - num27;
									bool flag11 = num30 == 0;
									bool flag12 = !flag11;
									if (!(flag10 && flag12))
									{
										throw new ArgumentOutOfRangeException();
									}
									Vector2[] items = list2._items;
									Vector3 vector8 = items[num31].y * vector4;
									Vector3 vector9 = vector7 + vector8;
									object obj12 = obj13;
									ObiPathFrame obiPathFrame6 = obiList.get_Item(num17);
									obj13 = obj12;
									vector10.x = (float)obj12;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6344 @ X8_v87+4]");
									vector10.y = 0f;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6344 @ X8_v87+8]");
									vector10.z = 0f;
									Vector3 item = vector10 + vector9;
									object obj14 = obj15;
									ObiPathFrame obiPathFrame7 = obiList.get_Item(num17);
									obj15 = obj14;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6361 @ X8_v88+C]");
									rhs.x = 0f;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6361 @ X8_v88+10]");
									rhs.y = 0f;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6361 @ X8_v88+14]");
									rhs.z = 0f;
									Vector3 vector11 = Vector3.Cross(vector9, rhs);
									Vector4 vector12 = vector11;
									int num32 = num27 / segments;
									float num33 = (float)num32 * uvScale.x;
									object obj16 = (long)(IntPtr)obj2 - 152L;
									Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588BC0 (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x1CC)");
									vertices.Add(item);
									normals.Add(vector9);
									item2.x = vector12.x;
									item2.y = vector12.y;
									item2.z = vector12.z;
									item2.w = -1f;
									tangents.Add(item2);
									Color item3 = obiList.get_Item(num17).color;
									vertColors.Add(item3);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-98]");
									item4.x = 0f;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-94]");
									item4.y = 0f;
									uvs.Add(item4);
									bool flag13 = num27 >= segments;
									num11 = 0;
									if (!flag13)
									{
										int num34 = obiList.Count - 1;
										bool flag14 = num17 >= num34;
										num11 = 0;
										if (!flag14)
										{
											int item5 = num15 + num27;
											tris.Add(item5);
											int item6 = num16 + num27;
											tris.Add(item6);
											int num35 = num15 + num27;
											int item7 = num35 + 1;
											tris.Add(item7);
											tris.Add(item7);
											tris.Add(item6);
											if (tris == null)
											{
												NullReferenceException ex = new NullReferenceException();
												if (num36 == 1)
												{
													Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
													Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
													ProfilerMarker.Internal_End(markerPtr);
													if (obj17 == null)
													{
														return;
													}
												}
												else
												{
													Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
												}
												throw new TypeLoadException();
											}
											int num37 = num16 + num27;
											num11 = num37 + 1;
											tris.Add(num11);
										}
									}
									num27++;
									flag15 = num27 <= segments;
									intPtr2 = intPtr2;
									z = vector2.z;
									y = vector2.y;
									vector5 = vector2;
								}
								while (flag15);
							}
							num17++;
							num9 = num19 + 1;
							int num38 = num16 + num5;
							int num39 = num15 + num5;
							flag16 = num17 < obiList.Count;
							intPtr = intPtr2;
							num8 = num25;
							num15 = num39;
							num16 = num38;
							num18 = num25;
							num19 = num9;
						}
						while (flag16);
					}
					obiPathSmoother2 = smoother;
					num10++;
					if ((object)smoother == null)
					{
						throw new NullReferenceException();
					}
				}
				CommitMeshData();
			}
			ProfilerMarker.Internal_End(intPtr);
		}

		[Token(Token = "0x60004E3")]
		[Address(RVA = "0xC3D308", Offset = "0xC3D308", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1ED3940]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20231E3]) = v38;\nL_0017:\n\tUnityEngine.Mesh::Clear(this.extrudedMesh);\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::Clear(this.vertices);\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::Clear(this.normals);\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector4>::Clear(this.tangents);\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector2>::Clear(this.uvs);\n\tSystem.Collections.Generic.List`1<UnityEngine.Color>::Clear(this.vertColors);\n\tSystem.Collections.Generic.List`1<System.Int32>::Clear(this.tris);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ClearMeshData()
		{
			extrudedMesh.Clear();
			vertices.Clear();
			normals.Clear();
			tangents.Clear();
			uvs.Clear();
			vertColors.Clear();
			tris.Clear();
		}

		[Token(Token = "0x60004E4")]
		[Address(RVA = "0xC3D3E0", Offset = "0xC3D3E0", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Mesh::SetVertices(this.extrudedMesh, this.vertices);\n\tUnityEngine.Mesh::SetNormals(this.extrudedMesh, this.normals);\n\tUnityEngine.Mesh::SetTangents(this.extrudedMesh, this.tangents);\n\tUnityEngine.Mesh::SetColors(this.extrudedMesh, this.vertColors);\n\tUnityEngine.Mesh::SetUVs(this.extrudedMesh, 0, this.uvs);\n\tUnityEngine.Mesh::SetTriangles(this.extrudedMesh, this.tris, 0, 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CommitMeshData()
		{
			extrudedMesh.SetVertices(vertices);
			extrudedMesh.SetNormals(normals);
			extrudedMesh.SetTangents(tangents);
			extrudedMesh.SetColors(vertColors);
			extrudedMesh.SetUVs(0, uvs);
			extrudedMesh.SetTriangles(tris, 0, calculateBounds: true);
		}

		[Token(Token = "0x60004E5")]
		[Address(RVA = "0xC3D480", Offset = "0xC3D480", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EF5610]);\n\tv23 = *([v22 @ X8_v26]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20231E4]) = v42;\nL_0018:\n\tv46 = new System.Collections.Generic.List`1<UnityEngine.Vector3>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::.ctor(v46);\n\tthis.vertices = v46;\n\tv52 = new System.Collections.Generic.List`1<UnityEngine.Vector3>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::.ctor(v52);\n\tthis.normals = v52;\n\tv58 = new System.Collections.Generic.List`1<UnityEngine.Vector4>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector4>::.ctor(v58);\n\tthis.tangents = v58;\n\tv66 = new System.Collections.Generic.List`1<UnityEngine.Vector2>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector2>::.ctor(v66);\n\tthis.uvs = v66;\n\tv74 = new System.Collections.Generic.List`1<UnityEngine.Color>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Color>::.ctor(v74);\n\tthis.vertColors = v74;\n\tv82 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v82);\n\tthis.tris = v82;\n\tgoto L_005A;\n\tv93 = *([v89 @ X0_v14+E0]);\n\tv94 = v93 == 0;\n\tv95 = ~v94;\n\tif (v95) goto L_005A;\n\tv97 = \"il2cpp_codegen_runtime_class_init\"(v89, v86, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_005A:\n\tv101 = UnityEngine.Vector2::get_one();\n\tthis.uvScale = v101;\n\tthis.uvScale.y = v101.y;\n\tthis.normalizeV = 1;\n\tthis.thicknessScale = 0.8f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiRopeExtrudedRenderer()
		{
			List<Vector3> list = new List<Vector3>();
			vertices = list;
			List<Vector3> list2 = new List<Vector3>();
			normals = list2;
			List<Vector4> list3 = new List<Vector4>();
			tangents = list3;
			List<Vector2> list4 = new List<Vector2>();
			uvs = list4;
			List<Color> list5 = new List<Color>();
			vertColors = list5;
			List<int> list6 = new List<int>();
			tris = list6;
			Vector2 vector = (uvScale = Vector2.one);
			uvScale.y = vector.y;
			normalizeV = true;
			thicknessScale = 0.8f;
		}

		[Token(Token = "0x60004E6")]
		[Address(RVA = "0xC3D5F0", Offset = "0xC3D5F0", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1EA5148]);\n\tv15 = *([v14 @ X8_v10]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20231E5]) = v35;\nL_0016:\n\tv41 = Unity.Profiling.ProfilerMarker::Internal_Create(\"UpdateExtrudedRopeRenderer\", 0);\n\tv45.m_UpdateExtrudedRopeRendererChunksPerfMarker = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static ObiRopeExtrudedRenderer()
		{
			//IL_002a: Expected O, but got I
			IntPtr intPtr = ProfilerMarker.Internal_Create("UpdateExtrudedRopeRenderer", default(Unity.Profiling.MarkerFlags));
			m_UpdateExtrudedRopeRendererChunksPerfMarker = (ProfilerMarker)(long)intPtr;
		}
	}
}
