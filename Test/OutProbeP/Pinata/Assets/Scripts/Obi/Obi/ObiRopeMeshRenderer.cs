using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Profiling;
using UnityEngine;

namespace Obi
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x74514C", Offset = "0x74514C")]
	[ExecuteInEditMode]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x74514C", Offset = "0x74514C")]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x74514C", Offset = "0x74514C")]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x74514C", Offset = "0x74514C")]
	[Token(Token = "0x200007F")]
	public class ObiRopeMeshRenderer : MonoBehaviour
	{
		[Token(Token = "0x4000236")]
		private static ProfilerMarker m_UpdateMeshRopeRendererChunksPerfMarker;

		[AttributeAttribute(Type = typeof(SerializeProperty), RVA = "0x746B08", Offset = "0x746B08")]
		[SerializeField]
		[Token(Token = "0x4000237")]
		[FieldOffset(Offset = "0x18")]
		private Mesh mesh;

		[AttributeAttribute(Type = typeof(SerializeProperty), RVA = "0x746B54", Offset = "0x746B54")]
		[SerializeField]
		[Token(Token = "0x4000238")]
		[FieldOffset(Offset = "0x20")]
		private ObiPathFrame.Axis axis;

		[Token(Token = "0x4000239")]
		[FieldOffset(Offset = "0x24")]
		public float volumeScaling;

		[Token(Token = "0x400023A")]
		[FieldOffset(Offset = "0x28")]
		public bool stretchWithRope;

		[Token(Token = "0x400023B")]
		[FieldOffset(Offset = "0x29")]
		public bool spanEntireLength;

		[AttributeAttribute(Type = typeof(SerializeProperty), RVA = "0x746BA0", Offset = "0x746BA0")]
		[SerializeField]
		[Token(Token = "0x400023C")]
		[FieldOffset(Offset = "0x2C")]
		private int instances;

		[AttributeAttribute(Type = typeof(SerializeProperty), RVA = "0x746BEC", Offset = "0x746BEC")]
		[SerializeField]
		[Token(Token = "0x400023D")]
		[FieldOffset(Offset = "0x30")]
		private float instanceSpacing;

		[Token(Token = "0x400023E")]
		[FieldOffset(Offset = "0x34")]
		public float offset;

		[Token(Token = "0x400023F")]
		[FieldOffset(Offset = "0x38")]
		public Vector3 scale;

		[HideInInspector]
		[SerializeField]
		[Token(Token = "0x4000240")]
		[FieldOffset(Offset = "0x44")]
		private float meshSizeAlongAxis;

		[Token(Token = "0x4000241")]
		[FieldOffset(Offset = "0x48")]
		private Vector3[] inputVertices;

		[Token(Token = "0x4000242")]
		[FieldOffset(Offset = "0x50")]
		private Vector3[] inputNormals;

		[Token(Token = "0x4000243")]
		[FieldOffset(Offset = "0x58")]
		private Vector4[] inputTangents;

		[Token(Token = "0x4000244")]
		[FieldOffset(Offset = "0x60")]
		private Vector3[] vertices;

		[Token(Token = "0x4000245")]
		[FieldOffset(Offset = "0x68")]
		private Vector3[] normals;

		[Token(Token = "0x4000246")]
		[FieldOffset(Offset = "0x70")]
		private Vector4[] tangents;

		[Token(Token = "0x4000247")]
		[FieldOffset(Offset = "0x78")]
		private int[] orderedVertices;

		[Token(Token = "0x4000248")]
		[FieldOffset(Offset = "0x80")]
		private ObiPathSmoother smoother;

		[NonSerialized]
		[HideInInspector]
		[Token(Token = "0x4000249")]
		[FieldOffset(Offset = "0x88")]
		public Mesh deformedMesh;

		[Token(Token = "0x170000CA")]
		public Mesh SourceMesh
		{
			[Token(Token = "0x60004F0")]
			[Address(RVA = "0xC3EEF0", Offset = "0xC3EEF0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.mesh;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SourceMesh;
			}
			[Token(Token = "0x60004EF")]
			[Address(RVA = "0xC3E71C", Offset = "0xC3E71C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.mesh = value;\n\tObi.ObiRopeMeshRenderer::PreprocessInputMesh(this);\n\treturn;\n")]
			set
			{
				mesh = value;
				PreprocessInputMesh();
			}
		}

		[Token(Token = "0x170000CB")]
		public ObiPathFrame.Axis SweepAxis
		{
			[Token(Token = "0x60004F2")]
			[Address(RVA = "0xC3EF00", Offset = "0xC3EF00", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.axis;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return SweepAxis;
			}
			[Token(Token = "0x60004F1")]
			[Address(RVA = "0xC3EEF8", Offset = "0xC3EEF8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.axis = value;\n\tObi.ObiRopeMeshRenderer::PreprocessInputMesh(this);\n\treturn;\n")]
			set
			{
				axis = value;
				PreprocessInputMesh();
			}
		}

		[Token(Token = "0x170000CC")]
		public int Instances
		{
			[Token(Token = "0x60004F4")]
			[Address(RVA = "0xC3EF10", Offset = "0xC3EF10", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.instances;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Instances;
			}
			[Token(Token = "0x60004F3")]
			[Address(RVA = "0xC3EF08", Offset = "0xC3EF08", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.instances = value;\n\tObi.ObiRopeMeshRenderer::PreprocessInputMesh(this);\n\treturn;\n")]
			set
			{
				instances = value;
				PreprocessInputMesh();
			}
		}

		[Token(Token = "0x170000CD")]
		public float InstanceSpacing
		{
			[Token(Token = "0x60004F6")]
			[Address(RVA = "0xC3EF20", Offset = "0xC3EF20", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.instanceSpacing;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return InstanceSpacing;
			}
			[Token(Token = "0x60004F5")]
			[Address(RVA = "0xC3EF18", Offset = "0xC3EF18", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.instanceSpacing = value;\n\tObi.ObiRopeMeshRenderer::PreprocessInputMesh(this);\n\treturn;\n")]
			set
			{
				instanceSpacing = value;
				PreprocessInputMesh();
			}
		}

		[Token(Token = "0x60004F7")]
		[Address(RVA = "0xC3EF28", Offset = "0xC3EF28", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EE8B20]);\n\tv21 = *([v20 @ X8_v10]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20231ED]) = v40;\nL_0018:\n\tv45 = UnityEngine.Component::GetComponent(this);\n\tthis.smoother = v45;\n\tv50 = new Obi.ObiActor+ActorCallback();\n\tObi.ObiActor+ActorCallback::.ctor(v50, this, Il2CppMethodInfo);\n\tObi.ObiPathSmoother::add_OnCurveGenerated(v45, v50);\n\tObi.ObiRopeMeshRenderer::PreprocessInputMesh(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 40 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnEnable()
		{
			ObiPathSmoother obiPathSmoother = (smoother = GetComponent<ObiPathSmoother>());
			ObiActor.ActorCallback value = UpdateRenderer;
			obiPathSmoother.OnCurveGenerated += value;
			PreprocessInputMesh();
		}

		[Token(Token = "0x60004F8")]
		[Address(RVA = "0xC3EFD4", Offset = "0xC3EFD4", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EBA570]);\n\tv21 = *([v20 @ X8_v14]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20231EE]) = v40;\nL_0018:\n\tv45 = new Obi.ObiActor+ActorCallback();\n\tObi.ObiActor+ActorCallback::.ctor(v45, this, Il2CppMethodInfo);\n\tObi.ObiPathSmoother::remove_OnCurveGenerated(this.smoother, v45);\n\tgoto L_003A;\n\tv64 = *([v60 @ X0_v7+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_003A;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v60, v54, v51, v49, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_003A:\n\tUnityEngine.Object::DestroyImmediate(this.deformedMesh);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDisable()
		{
			ObiActor.ActorCallback value = UpdateRenderer;
			smoother.OnCurveGenerated -= value;
			UnityEngine.Object.DestroyImmediate(deformedMesh);
		}

		[Token(Token = "0x60004F9")]
		[Address(RVA = "0xC3E724", Offset = "0xC3E724", Length = "0x7CC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv40 = &v41 @ stack_-10_v2;\n\tgoto L_0023;\n\tv50 = *([1EC4C00]);\n\tv51 = *([v50 @ X8_v78]);\n\tv52 = \"il2cpp_codegen_initialize_method\"(v51, methodInfo, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67);\n\tv70 = 0 | 1;\n\t*([20231EF]) = v70;\nL_0023:\n\t*([v40 @ X29_v1-98]) = 0;\n\t*([v40 @ X29_v1-A0]) = 0;\n\t*([v40 @ X29_v1-B8]) = 0;\n\t*([v40 @ X29_v1-B0]) = 0;\n\t*([v40 @ X29_v1-C0]) = 0;\n\tgoto L_003A;\n\tv80 = *([v75 @ X0_v2+E0]);\n\tv81 = v80 == 0;\n\tv82 = ~v81;\n\tgoto L_003A;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v75, methodInfo, v54, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67);\nL_003A:\n\tv90 = UnityEngine.Object::op_Equality(this.deformedMesh, 0);\n\tv92 = v90 == 0;\n\tif (v92) goto L_0061;\n\tv96 = new UnityEngine.Mesh();\n\tUnityEngine.Mesh::.ctor(v96);\n\tthis.deformedMesh = v96;\n\tUnityEngine.Object::set_name(v96, \"deformedMesh\");\n\tUnityEngine.Mesh::MarkDynamic(this.deformedMesh);\n\tv102 = UnityEngine.Component::GetComponent(this);\n\tUnityEngine.MeshFilter::set_mesh(v102, this.deformedMesh);\nL_0061:\n\tUnityEngine.Mesh::Clear(this.deformedMesh);\n\tgoto L_0070;\n\tv757 = *([v525 @ X0_v12+E0]);\n\tv758 = v757 == 0;\n\tv759 = ~v758;\n\tif (v759) goto L_0070;\n\tv761 = \"il2cpp_codegen_runtime_class_init\"(v525, v112, v97, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67);\nL_0070:\n\tv767 = UnityEngine.Object::op_Equality(this.mesh, 0);\n\tv943 = v767 == 0;\n\tif (v943) goto L_0082;\n\t// 120 NewArr v949 @ X0_v134 (System.Int32[]), typeof(System.Int32[]), 0\n\tthis.orderedVertices = v949;\n\tgoto L_02D3;\nL_0082:\n\tgoto L_008B;\n\tv959 = *([v953 @ X0_v17+E0]);\n\tv960 = v959 == 0;\n\tv961 = ~v960;\n\tif (v961) goto L_008B;\n\tv963 = \"il2cpp_codegen_runtime_class_init\"(v953, v765, v766, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67);\nL_008B:\n\tv968 = UnityEngine.Mathf::Max(0, this.instances);\n\tthis.instances = v968;\n\tv1003 = new UnityEngine.Mesh();\n\tUnityEngine.Mesh::.ctor(v1003);\n\t// 152 NewArr v1008 @ X0_v24 (UnityEngine.CombineInstance[]), typeof(UnityEngine.CombineInstance[]), this.instances (System.Int32)\n\tgoto L_00A8;\n\tv1013 = *([v516 @ X8_v19+E0]);\n\tv1014 = v1013 == 0;\n\tv1015 = ~v1014;\n\tif (v1015) goto L_00A8;\n\tv1020 = v516;\n\tv1017 = \"il2cpp_codegen_runtime_class_init\"(v1020, v495, v487, v55, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67);\nL_00A8:\n\tv467 = UnityEngine.Vector3::get_zero();\n\t*([v40 @ X29_v1-A0]) = v467;\n\t*([v40 @ X29_v1-9C]) = v467.y;\n\t*([v40 @ X29_v1-98]) = v467.z;\n\tv1021 = &v650 @ stack_-120_v4 (System.Single);\n\tv1023 = UnityEngine.Mesh::get_bounds(this.mesh);\n\tv1025 = &v41 @ stack_-10_v2 - 0xC0;\n\t*([v40 @ X29_v1-B0]) = *([v1021 @ X8_v20+10]);\n\t*([v40 @ X29_v1-C0]) = *([v1021 @ X8_v20]);\n\tv1027 = 0x100E250(v1025, 0, 0, v55, v56, v57, v58, v59, *([v1021 @ X8_v20]), v467.y, v467.z, v63, v64, v65, v66, v67);\n\tthrow System.TypeLoadException;\n\tv749 = this.instances;\n\tv590 = v749 < 1;\n\tif (v590) goto L_01B2;\nL_00E2:\n\tv1123 = *([v1008 @ X0_v24 (UnityEngine.CombineInstance[])+18]);\n\tv1124 = v349 < v1123;\n\tv1125 = ~v1124;\n\tif (v1125) goto L_02D4;\n\tv1136 = this.mesh;\n\tv1137 = v349 * 0x68;\n\tv1138 = v1008 + v1137;\n\tv452 = v1138 + 0x20;\n\tv1141 = 0x101113C(v452, v1136, 0, v55, v56, v57, v58, v59, v1117, v1116, v1115, v1096, v1088, v1087, v1086, v67);\n\tv341 = *([v40 @ X29_v1-A0]);\n\tv1174 = *([v40 @ X29_v1-9C]);\n\tv1177 = *([v40 @ X29_v1-98]);\n\tgoto L_0105;\n\tv1181 = *([v1175 @ X0_v101+E0]);\n\tv1182 = v1181 == 0;\n\tv1183 = ~v1182;\n\tif (v1183) goto L_0105;\n\tv1185 = \"il2cpp_codegen_runtime_class_init\"(v1175, v1136, v1140, v55, v56, v57, v58, v59, v1177, v1116, v1115, v1096, v1088, v1087, v1086, v67);\nL_0105:\n\tv1189 = UnityEngine.Quaternion::get_identity(0);\n\tv1190 = v1189.y;\n\tv1191 = v1189.z;\n\tv1192 = v1189.w;\n\tgoto L_0118;\n\tv1199 = *([v1193 @ X0_v104+E0]);\n\tv1200 = v1199 == 0;\n\tv1201 = ~v1200;\n\tif (v1201) goto L_0118;\n\tv1203 = \"il2cpp_codegen_runtime_class_init\"(v1193, v1136, v1140, v55, v56, v57, v58, v59, v1189, v1190, v1191, v1192, v1088, v1087, v1086, v67);\nL_0118:\n\tv1207 = UnityEngine.Vector3::get_one(0);\n\tgoto L_012A;\n\tv1216 = *([v1210 @ X0_v107+E0]);\n\tv1217 = v1216 == 0;\n\tv1218 = ~v1217;\n\tif (v1218) goto L_012A;\n\tv1220 = \"il2cpp_codegen_runtime_class_init\"(v1210, v1136, v1140, v55, v56, v57, v58, v59, v1207, v1208, v1209, v1192, v1088, v1087, v1086, v67);\nL_012A:\n\tv1222 = &v1113 @ stack_-120_v8 (System.Single);\n\t// 308 MakeStruct v267 @ AGGC3EA90_0_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v341 @ V10_v8, v1174 @ V0_v10, v1177 @ V0_v11\n\tv262 = v1189;\n\tv1166 = UnityEngine.Matrix4x4::TRS(v267, v262, v1207, 0);\n\tv448 = *([v1222 @ X8_v55]);\n\tv428 = *([v1222 @ X8_v55+10]);\n\tv247 = *([v1222 @ X8_v55+20]);\n\tv227 = *([v1222 @ X8_v55+30]);\n\tv517 = *([v1008 @ X0_v24 (UnityEngine.CombineInstance[])+18]);\n\tv1224 = v349 < v517;\n\tv402 = ~v1224;\n\tif (v402) goto L_02D4;\n\tv1238 = 0x10111E0(v452, &v448 @ stack_-120_v9 (System.Single), 0, v55, v56, v57, v58, v59, v227, v247, v428, v448, v1190, v1191, v1192, v67);\n\tv503 = this.mesh;\n\tv1264 = &v186 @ stack_-178_v6;\n\tv1266 = UnityEngine.Mesh::get_bounds(v503, 0);\n\tv187 = *([v1264 @ X8_v57]);\n\tv163 = *([v1264 @ X8_v57+10]);\n\tv1268 = &v41 @ stack_-10_v2 - 0xC0;\n\t*([v40 @ X29_v1-B0]) = v163;\n\t*([v40 @ X29_v1-C0]) = v187;\n\tv1270 = 0x100E250(v1268, 0, 0, v55, v56, v57, v58, v59, v187, v247, v428, v448, v1190, v1191, v1192, v67);\n\tthrow System.TypeLoadException;\n\tv1282 = UnityEngine.Mesh::get_bounds(v504, 0);\n\tv1040 = v1282.m_Center;\n\tv1036 = *([v1282 @ X0_v120 (UnityEngine.Bounds)+10]);\n\tv1287 = &v41 @ stack_-10_v2 - 0xC0;\n\t*([v40 @ X29_v1-B0]) = v1036;\n\t*([v40 @ X29_v1-C0]) = v1040;\n\tv1289 = 0x100E390(v1287, 0, 0, v55, v56, v57, v58, v59, v1040, v247, v428, v448, v1190, v1191, v1192, v67);\n\tthrow System.TypeLoadException;\n\tv1061 = this.instances;\n\tv1042 = v1041 < v1061;\n\tif (v1042) goto L_00E2;\nL_01B2:\n\tUnityEngine.Mesh::CombineMeshes(v1003, v1008, 1, 1, 0);\n\tv1135 = UnityEngine.Mesh::get_vertices(v1003, 0);\n\tthis.inputVertices = v1135;\n\tv1173 = UnityEngine.Mesh::get_normals(v1003, 0);\n\tthis.inputNormals = v1173;\n\tv713 = UnityEngine.Mesh::get_tangents(v1003, 0);\n\tv751 = this.inputVertices;\n\tthis.inputTangents = v713;\n\tv695 = *([v751 @ X8_v25 (UnityEngine.Vector3[])+18]);\n\tv714 = \"SzArrayNew\"(System.Single[], v695, 1, 1, 0, v57, v58, v59, v470, v464, v459, v328, v295, v291, v287, v67);\n\tv752 = this.inputVertices;\n\tv696 = *([v752 @ X8_v26 (UnityEngine.Vector3[])+18]);\n\tv715 = \"SzArrayNew\"(System.Int32[], v696, 1, 1, 0, v57, v58, v59, v470, v464, v459, v328, v295, v291, v287, v67);\n\tthis.orderedVertices = v715;\n\tv1225 = *([v714 @ X0_v47 (System.Single[])+18]);\n\tv1236 = v1225 < 1;\n\tif (v1236) goto L_0225;\nL_01E2:\n\tv753 = this.inputVertices;\n\tv663 = *([v753 @ X8_v39 (UnityEngine.Vector3[])+18]);\n\tv1267 = v654 < v663;\n\tv1157 = ~v1267;\n\tif (v1157) goto L_02D4;\n\tv717 = new System.TypeLoadException();\n\tv1169 = *([v714 @ X0_v47 (System.Single[])+18]);\n\tv1276 = v654 < v1169;\n\tv632 = ~v1276;\n\tif (v632) goto L_02D4;\n\tv714[v654 @ X22_v10 (System.Int32)] = v470;\n\tv754 = this.orderedVertices;\n\tv1162 = *([v754 @ X8_v43 (System.Int32[])+18]);\n\tv1283 = v654 < v1162;\n\tv1158 = ~v1283;\n\tif (v1158) goto L_02D4;\n\tv754[v654 @ X22_v10 (System.Int32)] = v654;\n\tv1256 = *([v714 @ X0_v47 (System.Single[])+18]);\n\tv1250 = v654 + 1;\n\tv1241 = v1250 < v1256;\n\tif (v1241) goto L_01E2;\nL_0225:\n\tv1258 = this.orderedVertices;\n\tSystem.Array::Sort(v714, v1258, Il2CppMethodInfo);\n\tv666 = this.deformedMesh;\n\tv718 = UnityEngine.Mesh::get_vertices(v1003, 0);\n\tUnityEngine.Mesh::set_vertices(v666, v718, 0);\n\tv667 = this.deformedMesh;\n\tv719 = UnityEngine.Mesh::get_normals(v1003, 0);\n\tUnityEngine.Mesh::set_normals(v667, v719, 0);\n\tv668 = this.deformedMesh;\n\tv720 = UnityEngine.Mesh::get_tangents(v1003, 0);\n\tUnityEngine.Mesh::set_tangents(v668, v720, 0);\n\tv669 = this.deformedMesh;\n\tv721 = UnityEngine.Mesh::get_uv(v1003, 0);\n\tUnityEngine.Mesh::set_uv(v669, v721, 0);\n\tv670 = this.deformedMesh;\n\tv722 = UnityEngine.Mesh::get_uv2(v1003, 0);\n\tUnityEngine.Mesh::set_uv2(v670, v722, 0);\n\tv671 = this.deformedMesh;\n\tv723 = UnityEngine.Mesh::get_uv3(v1003, 0);\n\tUnityEngine.Mesh::set_uv3(v671, v723, 0);\n\tv672 = this.deformedMesh;\n\tv724 = UnityEngine.Mesh::ge\n// ... truncated")]
		private void PreprocessInputMesh()
		{
			//IL_016d: Expected O, but got F4
			//IL_018b: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			if (deformedMesh == null)
			{
				(deformedMesh = new Mesh()).name = "deformedMesh";
				deformedMesh.MarkDynamic();
				MeshFilter component = GetComponent<MeshFilter>();
				component.mesh = deformedMesh;
			}
			deformedMesh.Clear();
			if (SourceMesh == null)
			{
				int[] array = new int[0];
				orderedVertices = array;
				return;
			}
			int num = Mathf.Max(0, Instances);
			instances = num;
			Mesh mesh = new Mesh();
			CombineInstance[] array2 = new CombineInstance[Instances];
			Vector3 zero = Vector3.zero;
			_ = zero.y;
			_ = zero.z;
			float num2 = default(float);
			object obj3 = num2;
			Bounds bounds = SourceMesh.bounds;
			object obj4 = (long)(IntPtr)obj2 - 192L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1021 @ X8_v20+10]");
			_ = 0;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @100E250 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x188)");
			throw new TypeLoadException();
		}

		[Token(Token = "0x60004FA")]
		[Address(RVA = "0xC3F090", Offset = "0xC3F090", Length = "0xA10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv40 = &v41 @ stack_-10_v2;\n\tgoto L_0029;\n\tv52 = *([1EFC3B8]);\n\tv53 = *([v52 @ X8_v121]);\n\tv54 = \"il2cpp_codegen_initialize_method\"(v53, actor, methodInfo, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv71 = 0 | 1;\n\t*([20231F0]) = v71;\nL_0029:\n\t*([v40 @ X29_v1-98]) = 0;\n\t*([v40 @ X29_v1-A0]) = 0;\n\t*([v40 @ X29_v1-C0]) = 0;\n\t*([v40 @ X29_v1-B0]) = 0;\n\t*([v40 @ X29_v1-E0]) = 0;\n\t*([v40 @ X29_v1-D0]) = 0;\n\tv77 = 0x6D26F0(&v74 @ stack_-138, 0, 0x44, v56, v57, v58, v59, v60, 0, v62, v63, v980, v978, v976, v67, v68);\n\tgoto L_0043;\n\tv86 = *([v82 @ X0_v4 (Il2CppClass<Obi.ObiRopeMeshRenderer>)+E0]);\n\tv87 = v86 == 0;\n\tv88 = ~v87;\n\tgoto L_0043;\n\tv97 = \"il2cpp_codegen_runtime_class_init\"(v82, v76, v75, v56, v57, v58, v59, v60, v72, v62, v63, v64, v65, v66, v67, v68);\n\tv90 = Obi.ObiRopeMeshRenderer;\nL_0043:\n\tUnity.Profiling.ProfilerMarker::Internal_Begin(v93.m_UpdateMeshRopeRendererChunksPerfMarker);\n\tgoto L_0054;\n\tv105 = *([v101 @ X0_v7+E0]);\n\tv106 = v105 == 0;\n\tv107 = ~v106;\n\tgoto L_0054;\n\tv109 = \"il2cpp_codegen_runtime_class_init\"(v101, v94, v75, v56, v57, v58, v59, v60, v72, v62, v63, v64, v65, v66, v67, v68);\nL_0054:\n\tv115 = UnityEngine.Object::op_Equality(this.mesh, 0);\n\tv117 = v115 == 0;\n\tv118 = ~v117;\n\tif (v118) goto L_038F;\n\tv119 = this.smoother;\n\tv700 = v119.smoothChunks;\n\tv704 = v700.count == 0;\n\tif (v704) goto L_038F;\n\tv701 = Obi.ObiList`1<Obi.ObiList`1<Obi.ObiPathFrame>>::get_Item(v700, 0);\n\tv653 = v701.count <= 1;\n\tif (v653) goto L_038F;\n\tv1717 = actor == 0;\n\tif (v1717) goto L_00A0;\n\tgoto L_FFFFFFFF;\n\tgoto L_00A0;\n\tv1948 = v1948_asT == 0;\n\tif (v1948) goto L_FFFFFFFF;\n\tgoto L_00A0;\nL_00A0:\n\tv1976 = ~this.stretchWithRope;\n\tif (v1976) goto L_FFFFFFFF;\n\tv1983 = this.smoother;\n\tv2596 = v1983.smoothLength / *([v1970 @ X22_v27 (Obi.ObiActor)+84]);\n\tgoto L_00B4;\nL_00B4:\n\tgoto L_00BF;\n\tv3116 = *([v2603 @ X0_v96+E0]);\n\tv3117 = v3116 == 0;\n\tv3118 = ~v3117;\n\tgoto L_00BF;\n\tv3120 = \"il2cpp_codegen_runtime_class_init\"(v2603, v691, v688, v56, v57, v58, v59, v60, v2596, v2594, v63, v64, v65, v66, v67, v68);\nL_00BF:\n\tv3128 = UnityEngine.Mathf::Max(v2596, 0.01f);\n\tv3156 = 1f / v3128;\n\tv3158 = v3156 + -1f;\n\tv3159 = this.volumeScaling * v3158;\n\tv3160 = v3159 + 1f;\n\tv1072 = UnityEngine.Mathf::Clamp(v3160, 0.01f, 2f);\n\t*([v40 @ X29_v1-A0]) = this.scale;\n\t*([v40 @ X29_v1-98]) = this.scale.z;\n\tv3373 = ~this.spanEntireLength;\n\tif (v3373) goto L_00DE;\n\tv3150 = v1970 == 0;\n\tif (v3150) goto L_03EB;\n\tthrow System.TypeLoadException;\nL_00DE:\n\tv3644 = &v621 @ stack_-190;\n\tv3647 = Obi.ObiList`1<Obi.ObiPathFrame>::get_Item(v701, 0);\n\tv3666 = &v564 @ stack_-1D8;\n\tv3669 = Obi.ObiList`1<Obi.ObiPathFrame>::get_Item(v701, 1);\n\tgoto L_0122;\n\tv4097 = *([v3882 @ X0_v105+E0]);\n\tv4098 = v4097 == 0;\n\tv4099 = ~v4098;\n\tif (v4099) goto L_0122;\n\tv4101 = \"il2cpp_codegen_runtime_class_init\"(v3882, v3667, v3665, v56, v57, v58, v59, v60, v3633, v3631, v3132, v64, v65, v66, v67, v68);\nL_0122:\n\t// 290 MakeStruct v500 @ AGGC3F358_0_v25 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v3644 @ X8_v51], [v3644 @ X8_v51+4], [v3644 @ X8_v51+8]\n\t// 291 MakeStruct v497 @ AGGC3F358_1_v25 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v3666 @ X8_v52], [v3666 @ X8_v52+4], [v3666 @ X8_v52+8]\n\tv4111 = UnityEngine.Vector3::Distance(v500, v497);\n\tv4317 = &v495 @ stack_-220;\n\tv4320 = Obi.ObiList`1<Obi.ObiPathFrame>::get_Item(v701, 0);\n\tv495 = *([v4317 @ X8_v57]);\n\tv4328 = 0x6D2410(&v74 @ stack_-138, &v495 @ stack_-220, 0x44, v56, v57, v58, v59, v60, v4111, *([v3644 @ X8_v51+4]), *([v3644 @ X8_v51+8]), *([v3666 @ X8_v52]), *([v3666 @ X8_v52+4]), *([v3666 @ X8_v52+8]), v67, v68);\n\tv4550 = new System.TypeLoadException();\n\t*([v40 @ X29_v1-C0]) = v4555;\n\t*([v40 @ X29_v1-B0]) = v4557;\n\t*([v40 @ X29_v1-E0]) = v443;\n\t*([v40 @ X29_v1-D0]) = v4560;\n\tv1709 = this.orderedVertices;\nL_0156:\n\tv5173 = 0 < v1709.Length;\n\tv1692 = ~v5173;\n\tv1676 = 0 >= v1709.Length;\n\tif (v1676) goto L_038C;\n\tif (v1692) goto L_03AC;\n\tv1903 = this.inputVertices;\n\tv5598 = v1709[v1580 @ X27_v29 (System.Int32)] < v1903.Length;\n\tv1920 = ~v5598;\n\tif (v1920) goto L_03B0;\n\tthrow System.TypeLoadException;\n\tv6030 = this.offset;\n\tv6031 = v1666 * v1666;\n\tv6033 = v6031 + v6030;\n\tv6035 = v6033 - v1612;\n\tv6036 = v2596 * v6035;\n\tv6037 = v1635 + v6036;\n\tv6049 = v6037 <= v1631;\n\tif (v6049) goto L_024D;\nL_019B:\n\tgoto L_01A5;\n\tv6661 = *([v6425 @ X0_v147 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv6662 = v6661 == 0;\n\tv6663 = ~v6662;\n\tif (v6663) goto L_01A5;\n\tv6673 = \"il2cpp_codegen_runtime_class_init\"(v6425, v6413, v6411, v56, v57, v58, v59, v60, v6391, v6389, v6385, v6371, v6369, v6367, v67, v68);\n\tv6664 = UnityEngine.Mathf;\nL_01A5:\n\tv6430 = v6447.Epsilon;\n\tv6431 = v6379 <= v6430;\n\tif (v6431) goto L_FFFFFFFF;\n\tv6675 = v701.count;\n\tgoto L_01BD;\n\tv6684 = *([v6443 @ X0_v148 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv6685 = v6684 == 0;\n\tv6686 = ~v6685;\n\tif (v6686) goto L_01BD;\n\tv6688 = \"il2cpp_codegen_runtime_class_init\"(v6443, v6413, v6411, v56, v57, v58, v59, v60, v6430, v6389, v6385, v6371, v6369, v6367, v67, v68);\nL_01BD:\n\tv6691 = v6419 + 1;\n\tv6692 = v6675 - 1;\n\tv6694 = UnityEngine.Mathf::Min(v6691, v6692, 0);\n\tv6706 = v701.count;\n\tv6707 = v6694 + 1;\n\tv6708 = v6706 - 1;\n\tv6710 = UnityEngine.Mathf::Min(v6707, v6708, 0);\n\tv6724 = v6694 - 1;\n\tv6727 = UnityEngine.Mathf::Max(v6724, 0, 0);\n\tv6734 = &v6363 @ stack_-2A8_v29;\n\tv6737 = Obi.ObiList`1<Obi.ObiPathFrame>::get_Item(v701, v6694, Il2CppMethodInfo);\n\tv6364 = *([v6734 @ X8_v98]);\n\tv6362 = *([v6734 @ X8_v98+4]);\n\tv6360 = *([v6734 @ X8_v98+8]);\n\tv6750 = &v6329 @ stack_-2F0_v29;\n\tv6753 = Obi.ObiList`1<Obi.ObiPathFrame>::get_Item(v701, v6710, Il2CppMethodInfo);\n\tv6330 = *([v6750 @ X8_v99]);\n\tv6328 = *([v6750 @ X8_v99+4]);\n\tv6326 = *([v6750 @ X8_v99+8]);\n\tgoto L_0211;\n\tv6771 = *([v6764 @ X0_v160+E0]);\n\tv6772 = v6771 == 0;\n\tv6773 = ~v6772;\n\tif (v6773) goto L_0211;\n\tv6775 = \"il2cpp_codegen_runtime_class_init\"(v6764, v6752, v6749, v56, v57, v58, v59, v60, v6430, v6389, v6385, v6371, v6369, v6367, v67, v68);\nL_0211:\n\t// 529 MakeStruct v6294 @ AGGC3F554_0_v30 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v6364 @ stack_-2A8_v30, v6362 @ stack_-2A4_v30, v6360 @ stack_-2A0_v30\n\t// 530 MakeStruct v6292 @ AGGC3F554_1_v30 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v6330 @ stack_-2F0_v30, v6328 @ stack_-2EC_v30 (System.Single), v6326 @ stack_-2E8_v30 (System.Single)\n\tv6782 = UnityEngine.Vector3::Distance(v6294, v6292, 0);\n\tv6792 = Obi.ObiList`1<Obi.ObiPathFrame>::get_Item(v701, v6694, Il2CppMethodInfo);\n\tv6290 = v6792.position;\n\tv6798 = 0x6D2410(&v74 @ stack_-138, &v6290 @ stack_-338_v30 (UnityEngine.Vector3), 0x44, v56, v57, v58, v59, v60, v6782, v6362, v6360, v6330, v6328, v6326, v67, v68);\n\tthrow System.TypeLoadException;\n\tv6392 = *([v1578 @ X28_v28+20]);\n\tv6390 = *([v1578 @ X28_v28+30]);\n\tv6386 = *([v1578 @ X28_v28]);\n\tv6372 = *([v1578 @ X28_v28+10]);\n\tv6384 = v6383 - v6379;\n\t*([v40 @ X29_v1-C0]) = v6392;\n\t*([v40 @ X29_v1-B0]) = v6390;\n\t*([v40 @ X29_v1-E0]) = v6386;\n\t*([v40 @ X29_v1-D0]) = v6372;\n\tv6394 = v6384 > v6782;\n\tif (v6394) goto L_019B;\n\tgoto L_024D;\nL_024D:\n\tv6448 = &v1458 @ stack_-3C0_v27;\n\tv2904 = Obi.ObiList`1<Obi.ObiPathFrame>::get_Item(v701, v2908, Il2CppMethodInfo);\n\tv2671 = *([v6448 @ X8_v67]);\n\tv2639 = *([v6448 @ X8_v67+40]);\n\tv2910 = this.inputVertices;\n\tv2877 = *([v2910 @ X8_v68 (UnityEngine.Vector3[])+18]);\n\tv6678 = v1709[v1580 @ X27_v29 (System.Int32)] < v2877;\n\tv2895 = ~v6678;\n\tif (v2895) goto L_03B6;\n\tv6696 = v1709[v1580 @ X27_v29 (System.Int32)] * 0xC;\n\tv6697 = v2910 + v6696;\n\tv6698 = *([v6697 @ X8_v69+28]);\n\tv6699 = *([v6697 @ X8_v69+20]);\n\tv6700 = *([v6697 @ X8_v69+24]);\n\tv6702 = *([v40 @ X29_v1-A0]);\n\tv3585 = *([v40 @ X29_v1-9C]);\n\tv3541 = *([v40 @ X29_v1-98]);\n\tgoto L_028C;\n\tv6711 = *([v6701 @ X0_v127+E0]);\n\tv6712 = v6711 == 0;\n\tv6713 = ~v6712;\n\tif (v6713) goto L_028C;\n\tv6715 = \"il2cpp_codegen_runtime_class_init\"(v6701, v2899, v2897, v56, v57, v58, v59, v60, v6698, v2869, v2865, v2815, v2813, v2811, v67, v68);\nL_028C:\n\t// 652 MakeStruct v3427 @ AGGC3F634_0_v28 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v6702 @ V12_v32, v3585 @ V8_v32, v3541 @ V9_v33\n\tv6723 = UnityEngine.Ve\n// ... truncated")]
		public void UpdateRenderer(ObiActor actor)
		{
			//IL_04f5: Expected I, but got O
			//IL_03dc: Expected I, but got O
			//IL_028b: Expected F4, but got O
			//IL_02a0: Expected F4, but got I
			//IL_02b5: Expected F4, but got I
			//IL_02c2: Expected F4, but got O
			//IL_02d7: Expected F4, but got I
			//IL_02ec: Expected F4, but got I
			//IL_0462: Expected I, but got O
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			Il2CppRuntime.Boundary("SYSTEM_API:memset", "Method not found @6D26F0 (native memset)");
			ProfilerMarker.Internal_Begin((IntPtr)m_UpdateMeshRopeRendererChunksPerfMarker);
			if (!(SourceMesh == null))
			{
				ObiPathSmoother obiPathSmoother = smoother;
				ObiList<ObiList<ObiPathFrame>> smoothChunks = obiPathSmoother.smoothChunks;
				if (smoothChunks.Count != 0)
				{
					ObiList<ObiPathFrame> obiList = smoothChunks.get_Item(0);
					if (obiList.Count > 1)
					{
						bool flag = (object)actor == null;
						ObiActor obiActor = actor;
						if (!flag)
						{
							ObiRopeBase obiRopeBase = actor as ObiRopeBase;
							obiActor = (((object)obiRopeBase == null) ? null : actor);
						}
						float a;
						if (stretchWithRope)
						{
							ObiPathSmoother obiPathSmoother2 = smoother;
							float num = obiPathSmoother2.SmoothLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1970 @ X22_v27 (Obi.ObiActor)+84]");
							a = num / 0f;
						}
						else
						{
							a = 1f;
						}
						float num2 = Mathf.Max(a, 0.01f);
						float num3 = 1f / num2;
						float num4 = num3 + -1f;
						float num5 = volumeScaling * num4;
						float value = num5 + 1f;
						float num6 = Mathf.Clamp(value, 0.01f, 2f);
						_ = scale;
						_ = scale.z;
						if (spanEntireLength)
						{
							bool flag2 = (object)obiActor == null;
							int num7 = 0;
							if (!flag2)
							{
								throw new TypeLoadException();
							}
							NullReferenceException ex = new NullReferenceException();
							bool flag3 = 0 != 1;
							NullReferenceException ex2 = ex;
							if (!flag3)
							{
								Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
								Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
								ProfilerMarker.Internal_End((IntPtr)m_UpdateMeshRopeRendererChunksPerfMarker);
								object obj3 = default(object);
								if (obj3 == null)
								{
									return;
								}
								TypeLoadException ex3 = new TypeLoadException();
								ex2 = null;
								num7 = 0;
								ex = (NullReferenceException)(object)ex3;
							}
							Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
							return;
						}
						object obj5 = default(object);
						object obj4 = obj5;
						ObiPathFrame obiPathFrame = obiList.get_Item(0);
						object obj7 = default(object);
						object obj6 = obj7;
						ObiPathFrame obiPathFrame2 = obiList.get_Item(1);
						Vector3 a2 = default(Vector3);
						a2.x = (float)obj4;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3644 @ X8_v51+4]");
						a2.y = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3644 @ X8_v51+8]");
						a2.z = 0f;
						Vector3 b = default(Vector3);
						b.x = (float)obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3666 @ X8_v52+4]");
						b.y = 0f;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3666 @ X8_v52+8]");
						b.z = 0f;
						float num8 = Vector3.Distance(a2, b);
						object obj9 = default(object);
						object obj8 = obj9;
						ObiPathFrame obiPathFrame3 = obiList.get_Item(0);
						obj9 = obj8;
						Il2CppRuntime.Boundary("SYSTEM_API:memcpy", "Method not found @6D2410 (native memcpy)");
						TypeLoadException ex4 = new TypeLoadException();
						int[] array = orderedVertices;
						int num9 = 0;
						bool flag4 = 0 < array.Length;
						bool flag5 = !flag4;
						if (0 < array.Length)
						{
							if (!flag5)
							{
								Vector3[] array2 = inputVertices;
								if (array[num9] < array2.Length)
								{
									throw new TypeLoadException();
								}
								IndexOutOfRangeException ex5 = new IndexOutOfRangeException();
								throw ex5;
							}
							IndexOutOfRangeException ex6 = new IndexOutOfRangeException();
							throw ex6;
						}
						CommitMeshData();
					}
				}
			}
			ProfilerMarker.Internal_End((IntPtr)m_UpdateMeshRopeRendererChunksPerfMarker);
		}

		[Token(Token = "0x60004FB")]
		[Address(RVA = "0xC3FAA0", Offset = "0xC3FAA0", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Mesh::set_vertices(this.deformedMesh, this.vertices);\n\tUnityEngine.Mesh::set_normals(this.deformedMesh, this.normals);\n\tUnityEngine.Mesh::set_tangents(this.deformedMesh, this.tangents);\n\tUnityEngine.Mesh::RecalculateBounds(this.deformedMesh);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CommitMeshData()
		{
			deformedMesh.vertices = vertices;
			deformedMesh.normals = normals;
			deformedMesh.tangents = tangents;
			deformedMesh.RecalculateBounds();
		}

		[Token(Token = "0x60004FC")]
		[Address(RVA = "0xC3FB08", Offset = "0xC3FB08", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1ED5478]);\n\tv19 = *([v18 @ X8_v13]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20231F1]) = v38;\nL_0016:\n\tthis.stretchWithRope = 0x101;\n\tthis.instances = 0x3F80000000000001;\n\tgoto L_0025;\n\tv48 = *([v44 @ X0_v2+E0]);\n\tv49 = v48 == 0;\n\tv50 = ~v49;\n\tgoto L_0025;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0025:\n\tv56 = UnityEngine.Vector3::get_one();\n\tthis.scale = v56;\n\tthis.scale.y = v56.y;\n\tthis.scale.z = v56.z;\n\tthis.meshSizeAlongAxis = 1f;\n\t// 49 NewArr v64 @ X0_v6 (System.Int32[]), typeof(System.Int32[]), 0\n\tthis.orderedVertices = v64;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiRopeMeshRenderer()
		{
			//IL_0094: Expected I4, but got I8
			base._002Ector();
			stretchWithRope = true;
			spanEntireLength = true;
			instances = 1;
			Vector3 vector = (scale = Vector3.one);
			scale.y = vector.y;
			scale.z = vector.z;
			meshSizeAlongAxis = 1f;
			int[] array = new int[0];
			orderedVertices = array;
		}

		[Token(Token = "0x60004FD")]
		[Address(RVA = "0xC3FBB4", Offset = "0xC3FBB4", Length = "0x1068")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1EC87B8]);\n\tv15 = *([v14 @ X8_v10]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20231F2]) = v35;\nL_0016:\n\tv41 = Unity.Profiling.ProfilerMarker::Internal_Create(\"UpdateMeshRopeRenderer\", 0);\n\tv45.m_UpdateMeshRopeRendererChunksPerfMarker = v41;\n\treturn;\n\tUnityEngine.EventSystems.AbstractEventData::Reset(X0, X1);\n\treturn;\n\tX0 = *([X8]);\n\tX0 = 0xC33004(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\tX0 = *([X22]);\n\tX0 = 0xC3C00C(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\tX10 = *([X10+898]);\n\tX0 = 0xC2B004(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\treturn;\n// 1041 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static ObiRopeMeshRenderer()
		{
			//IL_002a: Expected O, but got I
			IntPtr intPtr = ProfilerMarker.Internal_Create("UpdateMeshRopeRenderer", default(Unity.Profiling.MarkerFlags));
			m_UpdateMeshRopeRendererChunksPerfMarker = (ProfilerMarker)(long)intPtr;
		}
	}
}
