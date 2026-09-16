using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Profiling;
using UnityEngine;

namespace Obi
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x745060", Offset = "0x745060")]
	[ExecuteInEditMode]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x745060", Offset = "0x745060")]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x745060", Offset = "0x745060")]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x745060", Offset = "0x745060")]
	[Token(Token = "0x200007E")]
	public class ObiRopeLineRenderer : MonoBehaviour
	{
		[Token(Token = "0x4000228")]
		private static ProfilerMarker m_UpdateLineRopeRendererChunksPerfMarker;

		[Token(Token = "0x4000229")]
		[FieldOffset(Offset = "0x18")]
		private List<Vector3> vertices;

		[Token(Token = "0x400022A")]
		[FieldOffset(Offset = "0x20")]
		private List<Vector3> normals;

		[Token(Token = "0x400022B")]
		[FieldOffset(Offset = "0x28")]
		private List<Vector4> tangents;

		[Token(Token = "0x400022C")]
		[FieldOffset(Offset = "0x30")]
		private List<Vector2> uvs;

		[Token(Token = "0x400022D")]
		[FieldOffset(Offset = "0x38")]
		private List<Color> vertColors;

		[Token(Token = "0x400022E")]
		[FieldOffset(Offset = "0x40")]
		private List<int> tris;

		[Token(Token = "0x400022F")]
		[FieldOffset(Offset = "0x48")]
		private ObiRopeBase rope;

		[Token(Token = "0x4000230")]
		[FieldOffset(Offset = "0x50")]
		private ObiPathSmoother smoother;

		[NonSerialized]
		[HideInInspector]
		[Token(Token = "0x4000231")]
		[FieldOffset(Offset = "0x58")]
		public Mesh lineMesh;

		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x746AF0", Offset = "0x746AF0")]
		[Token(Token = "0x4000232")]
		[FieldOffset(Offset = "0x60")]
		public float uvAnchor;

		[Token(Token = "0x4000233")]
		[FieldOffset(Offset = "0x64")]
		public Vector2 uvScale;

		[Token(Token = "0x4000234")]
		[FieldOffset(Offset = "0x6C")]
		public bool normalizeV;

		[Token(Token = "0x4000235")]
		[FieldOffset(Offset = "0x70")]
		public float thicknessScale;

		[Token(Token = "0x60004E7")]
		[Address(RVA = "0xC3D658", Offset = "0xC3D658", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EB9CF0]);\n\tv25 = *([v24 @ X8_v15]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20231E6]) = v44;\nL_0017:\n\tObi.ObiRopeLineRenderer::CreateMeshIfNeeded(this);\n\tv54 = new UnityEngine.Camera+CameraCallback();\n\tUnityEngine.Camera+CameraCallback::.ctor(v54, this, Il2CppMethodInfo);\n\tv64 = System.Delegate::Combine(v50.onPreCull, v54);\n\tv67 = v64 == 0;\n\tif (v67) goto L_003D;\n\tv79 = *([v64 @ X0_v6 (System.Delegate)]) != UnityEngine.Camera+CameraCallback;\n\tif (v79) goto L_0053;\nL_003D:\n\tv66.onPreCull = v64;\n\tv105 = UnityEngine.Component::GetComponent(this);\n\tthis.rope = v105;\n\tv111 = UnityEngine.Component::GetComponent(this);\n\tthis.smoother = v111;\n\treturn;\nL_0053:\n\tthrow System.InvalidCastException;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnEnable()
		{
			CreateMeshIfNeeded();
			Camera.CameraCallback b = UpdateRenderer;
			Delegate obj = Delegate.Combine(Camera.onPreCull, b);
			if ((object)obj == null || (object)obj.GetType() == typeof(Camera.CameraCallback))
			{
				Camera.onPreCull = (Camera.CameraCallback)obj;
				ObiRopeBase component = GetComponent<ObiRopeBase>();
				rope = component;
				ObiPathSmoother component2 = GetComponent<ObiPathSmoother>();
				smoother = component2;
				return;
			}
			throw new InvalidCastException();
		}

		[Token(Token = "0x60004E8")]
		[Address(RVA = "0xC3D84C", Offset = "0xC3D84C", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv24 = *([1EBBAA8]);\n\tv25 = *([v24 @ X8_v16]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20231E7]) = v44;\nL_001E:\n\tv53 = new UnityEngine.Camera+CameraCallback();\n\tUnityEngine.Camera+CameraCallback::.ctor(v53, this, Il2CppMethodInfo);\n\tv63 = System.Delegate::Remove(v49.onPreCull, v53);\n\tv66 = v63 == 0;\n\tif (v66) goto L_003B;\n\tv78 = *([v63 @ X0_v5 (System.Delegate)]) != UnityEngine.Camera+CameraCallback;\n\tif (v78) goto L_0055;\nL_003B:\n\tv65.onPreCull = v63;\n\tgoto L_0053;\n\tv108 = *([v103 @ X0_v6+E0]);\n\tv109 = v108 == 0;\n\tv110 = ~v109;\n\tif (v110) goto L_0053;\n\tv112 = \"il2cpp_codegen_runtime_class_init\"(v103, v99, v62, v57, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0053:\n\tUnityEngine.Object::DestroyImmediate(this.lineMesh);\n\treturn;\nL_0055:\n\tthrow System.InvalidCastException;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDisable()
		{
			Camera.CameraCallback value = UpdateRenderer;
			Delegate obj = Delegate.Remove(Camera.onPreCull, value);
			if ((object)obj == null || (object)obj.GetType() == typeof(Camera.CameraCallback))
			{
				Camera.onPreCull = (Camera.CameraCallback)obj;
				UnityEngine.Object.DestroyImmediate(lineMesh);
				return;
			}
			throw new InvalidCastException();
		}

		[Token(Token = "0x60004E9")]
		[Address(RVA = "0xC3D754", Offset = "0xC3D754", Length = "0xF8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = *([1F0E5D0]);\n\tv19 = *([v18 @ X8_v17]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20231E8]) = v38;\nL_001A:\n\tgoto L_0023;\n\tv46 = *([v42 @ X0_v2+E0]);\n\tv47 = v46 == 0;\n\tv48 = ~v47;\n\tgoto L_0023;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0023:\n\tv56 = UnityEngine.Object::op_Equality(this.lineMesh, 0);\n\tv58 = v56 == 0;\n\tif (v58) goto L_0051;\n\tv62 = new UnityEngine.Mesh();\n\tUnityEngine.Mesh::.ctor(v62);\n\tthis.lineMesh = v62;\n\tUnityEngine.Object::set_name(v62, \"extrudedMesh\");\n\tUnityEngine.Mesh::MarkDynamic(this.lineMesh);\n\tv78 = UnityEngine.Component::GetComponent(this);\n\tUnityEngine.MeshFilter::set_mesh(v78, this.lineMesh);\n\treturn;\nL_0051:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 59 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CreateMeshIfNeeded()
		{
			if (lineMesh == null)
			{
				(lineMesh = new Mesh()).name = "extrudedMesh";
				lineMesh.MarkDynamic();
				MeshFilter component = GetComponent<MeshFilter>();
				component.mesh = lineMesh;
			}
		}

		[Token(Token = "0x60004EA")]
		[Address(RVA = "0xC3D93C", Offset = "0xC3D93C", Length = "0xA90")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv40 = &v41 @ stack_-10_v2;\n\tgoto L_0025;\n\tv52 = *([1EEB780]);\n\tv53 = *([v52 @ X8_v126]);\n\tv54 = \"il2cpp_codegen_initialize_method\"(v53, camera, methodInfo, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv71 = 0 | 1;\n\t*([20231E9]) = v71;\nL_0025:\n\t*([v40 @ X29_v1-98]) = 0;\n\t*([v40 @ X29_v1-A0]) = 0;\n\t*([v40 @ X29_v1-A8]) = 0;\n\t*([v40 @ X29_v1-B0]) = 0;\n\t*([v40 @ X29_v1-B8]) = 0;\n\tgoto L_003B;\n\tv78 = *([v74 @ X0_v2 (Il2CppClass<Obi.ObiRopeLineRenderer>)+E0]);\n\tv79 = v78 == 0;\n\tv80 = ~v79;\n\tgoto L_003B;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v74, camera, methodInfo, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv82 = Obi.ObiRopeLineRenderer;\nL_003B:\n\tUnity.Profiling.ProfilerMarker::Internal_Begin(v85.m_UpdateLineRopeRendererChunksPerfMarker);\n\tgoto L_004B;\n\tv96 = *([v92 @ X0_v5+E0]);\n\tv97 = v96 == 0;\n\tv98 = ~v97;\n\tgoto L_004B;\n\tv100 = \"il2cpp_codegen_runtime_class_init\"(v92, v86, methodInfo, v56, v57, v58, v59, v60, v61, v62, v63, v64, v65, v66, v67, v68);\nL_004B:\n\tv106 = UnityEngine.Object::op_Equality(camera, 0);\n\tv108 = v106 == 0;\n\tv109 = ~v108;\n\tif (v109) goto L_0380;\n\tv768 = UnityEngine.Component::get_gameObject(this.rope);\n\tv755 = UnityEngine.GameObject::get_activeInHierarchy(v768);\n\tv758 = v755 == 0;\n\tif (v758) goto L_0380;\n\tObi.ObiRopeLineRenderer::CreateMeshIfNeeded(this);\n\tObi.ObiRopeLineRenderer::ClearMeshData(this);\n\tv2404 = this.smoother;\n\tv2630 = this.rope;\n\tv2865 = UnityEngine.Component::get_transform(this.rope);\n\tv3096 = UnityEngine.Component::get_transform(camera);\n\tv3319 = UnityEngine.Transform::get_position(v3096);\n\tv4852 = UnityEngine.Transform::InverseTransformPoint(v2865, v3319);\n\tgoto L_0090;\n\tv5338 = *([v5098 @ X0_v92+E0]);\n\tv5339 = v5338 == 0;\n\tv5340 = ~v5339;\n\tif (v5340) goto L_0090;\n\tv5342 = \"il2cpp_codegen_runtime_class_init\"(v5098, v4851, v105, v56, v57, v58, v59, v60, v4852, v5094, v5095, v64, v65, v66, v67, v68);\nL_0090:\n\tv5346 = UnityEngine.Vector3::get_forward();\n\tgoto L_00A0;\n\tv5873 = *([v5608 @ X0_v95+E0]);\n\tv5874 = v5873 == 0;\n\tv5875 = ~v5874;\n\tif (v5875) goto L_00A0;\n\tv5877 = \"il2cpp_codegen_runtime_class_init\"(v5608, v4851, v105, v56, v57, v58, v59, v60, v5346, v5604, v5605, v64, v65, v66, v67, v68);\nL_00A0:\n\tv5881 = UnityEngine.Vector4::get_zero();\n\tgoto L_00B1;\n\tv6362 = *([v6122 @ X0_v98+E0]);\n\tv6363 = v6362 == 0;\n\tv6364 = ~v6363;\n\tif (v6364) goto L_00B1;\n\tv6366 = \"il2cpp_codegen_runtime_class_init\"(v6122, v4851, v105, v56, v57, v58, v59, v60, v5881, v6117, v6118, v6119, v65, v66, v67, v68);\nL_00B1:\n\tv6370 = UnityEngine.Vector2::get_zero();\n\t*([v40 @ X29_v1-98]) = v6370;\n\t*([v40 @ X29_v1-94]) = v6370.y;\n\tv1694 = this.smoother;\n\tv6854 = *([v2630 @ X0_v87 (UnityEngine.Component)+84]) * this.uvScale.y;\n\tv4334 = v2404.smoothLength / *([v2630 @ X0_v87 (UnityEngine.Component)+84]);\n\tv6859 = v6854 * this.uvAnchor;\n\tv8124 = -v6859;\nL_00C3:\n\tv1688 = v1694.smoothChunks;\n\tv2126 = v1692 >= v1688.count;\n\tif (v2126) goto L_037D;\n\tv2167 = Obi.ObiList`1<Obi.ObiList`1<Obi.ObiPathFrame>>::get_Item(v1688, v1692);\n\tv8043 = v2167.count < 1;\n\tif (v8043) goto L_0375;\n\tv8116 = v8117 << 1;\nL_00EB:\n\tgoto L_00F1;\n\tv8138 = *([v8132 @ X0_v111+E0]);\n\tv8139 = v8138 == 0;\n\tv8140 = ~v8139;\n\tgoto L_00F1;\n\tv8142 = \"il2cpp_codegen_runtime_class_init\"(v8132, v8128, v8127, v56, v57, v58, v59, v60, v8123, v8122, v8121, v8120, v8075, v8074, v67, v68);\nL_00F1:\n\tv8145 = v3745 - 1;\n\tv8148 = UnityEngine.Mathf::Max(v8145, 0);\n\tv8154 = v3745 | v1692;\n\tv8155 = v8154 == 0;\n\tv8156 = ~v8155;\n\tif (v8156) goto L_0106;\n\tv8163 = Obi.ObiList`1<Obi.ObiPathFrame>::get_Item(v2167, v3745);\nL_0106:\n\tv8172 = &v676 @ stack_-158;\n\tv8175 = Obi.ObiList`1<Obi.ObiPathFrame>::get_Item(v2167, v3745);\n\tv676 = *([v8172 @ X8_v61]);\n\tv8177 = &v621 @ stack_-1A0;\n\tv8179 = Obi.ObiList`1<Obi.ObiPathFrame>::get_Item(v2167, v8148);\n\tv621 = *([v8177 @ X8_v62]);\n\tgoto L_014A;\n\tv8186 = *([v8180 @ X0_v120+E0]);\n\tv8187 = v8186 == 0;\n\tv8188 = ~v8187;\n\tif (v8188) goto L_014A;\n\tv8190 = \"il2cpp_codegen_runtime_class_init\"(v8180, v4364, v4362, v56, v57, v58, v59, v60, v8123, v8122, v8121, v8120, v8075, v8074, v67, v68);\nL_014A:\n\t// 330 MakeStruct v3633 @ AGGC3DC68_0_v32 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v8172 @ X8_v61], [v8172 @ X8_v61+4], [v8172 @ X8_v61+8]\n\t// 331 MakeStruct v3631 @ AGGC3DC68_1_v32 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v8177 @ X8_v62], [v8177 @ X8_v62+4], [v8177 @ X8_v62+8]\n\tv4351 = UnityEngine.Vector3::Distance(v3633, v3631);\n\tv8197 = ~this.normalizeV;\n\tif (v8197) goto L_015B;\n\tv4371 = this.smoother;\n\tv8198 = v4371.smoothLength;\nL_015B:\n\tv8203 = &v552 @ stack_-1E8;\n\tv8206 = Obi.ObiList`1<Obi.ObiPathFrame>::get_Item(v2167, v3745);\n\tv552 = *([v8203 @ X8_v67]);\n\tv8209 = &v501 @ stack_-230;\n\tv8212 = Obi.ObiList`1<Obi.ObiPathFrame>::get_Item(v2167, v3745);\n\tv501 = *([v8209 @ X8_v68]);\n\tgoto L_019F;\n\tv8220 = *([v8213 @ X0_v127+E0]);\n\tv8221 = v8220 == 0;\n\tv8222 = ~v8221;\n\tgoto L_019F;\n\tv8224 = \"il2cpp_codegen_runtime_class_init\"(v8213, v8211, v8208, v56, v57, v58, v59, v60, v4351, v4349, v4347, v4340, v4279, v4277, v67, v68);\nL_019F:\n\t// 415 MakeStruct v3559 @ AGGC3DD10_0_v32 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v8209 @ X8_v68], [v8209 @ X8_v68+4], [v8209 @ X8_v68+8]\n\tv8234 = UnityEngine.Vector3::op_Subtraction(v3559, v4852);\n\t*([v40 @ X29_v1-A8]) = v8234;\n\t*([v40 @ X29_v1-A4]) = v8234.y;\n\t*([v40 @ X29_v1-A0]) = v8234.z;\n\tv8237 = &v41 @ stack_-10_v2 - 0xA8;\n\tv8239 = 0x158A620(v8237, 0, Il2CppMethodInfo, v56, v57, v58, v59, v60, v8234, v8234.y, v8234.z, v4852, v4852.y, v4852.z, v67, v68);\n\tv8243 = &v441 @ stack_-278;\n\tv8246 = Obi.ObiList`1<Obi.ObiPathFrame>::get_Item(v2167, v3745);\n\tv441 = *([v8243 @ X8_v71]);\n\t// 458 MakeStruct v3521 @ AGGC3DD60_0_v32 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v40 @ X29_v1-A8], [v40 @ X29_v1-A4], [v40 @ X29_v1-A0]\n\t// 459 MakeStruct v3519 @ AGGC3DD60_1_v32 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v8243 @ X8_v71+C], [v8243 @ X8_v71+10], [v8243 @ X8_v71+14]\n\tv8254 = UnityEngine.Vector3::Cross(v3521, v3519);\n\t*([v40 @ X29_v1-B8]) = v8254;\n\t*([v40 @ X29_v1-B4]) = v8254.y;\n\t*([v40 @ X29_v1-B0]) = v8254.z;\n\tv8257 = &v41 @ stack_-10_v2 - 0xB8;\n\tv8259 = 0x158A620(v8257, 0, Il2CppMethodInfo, v56, v57, v58, v59, v60, v8254, v8254.y, v8254.z, *([v8243 @ X8_v71+C]), *([v8243 @ X8_v71+10]), *([v8243 @ X8_v71+14]), v67, v68);\n\tv3779 = &v384 @ stack_-2C0;\n\tv8262 = Obi.ObiList`1<Obi.ObiPathFrame>::get_Item(v2167, v3745);\n\tv384 = *([v3779 @ X8_v73]);\n\tv3679 = *([v8203 @ X8_v67+40]) * this.thicknessScale;\n\t// 503 MakeStruct v3481 @ AGGC3DDB8_0_v32 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v40 @ X29_v1-B8], [v40 @ X29_v1-B4], [v40 @ X29_v1-B0]\n\tv8268 = UnityEngine.Vector3::op_Multiply(v3481, v3679);\n\t// 514 MakeStruct v3479 @ AGGC3DDD8_0_v32 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v3779 @ X8_v73], [v3779 @ X8_v73+4], [v3779 @ X8_v73+8]\n\tv3759 = UnityEngine.Vector3::op_Addition(v3479, v8268);\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::Add(this.vertices, v3759);\n\tv4046 = &v318 @ stack_-308;\n\tv8279 = Obi.ObiList`1<Obi.ObiPathFrame>::get_Item(v2167, v3745);\n\tv318 = *([v4046 @ X8_v76]);\n\t// 559 MakeStruct v3839 @ AGGC3DE28_0_v32 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v40 @ X29_v1-B8], [v40 @ X29_v1-B4], [v40 @ X29_v1-B0]\n\tv8285 = UnityEngine.Vector3::op_Multiply(v3839, v3679);\n\t// 570 MakeStruct v3837 @ AGGC3DE48_0_v32 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v4046 @ X8_v76], [v4046 @ X8_v76+4], [v4046 @ X8_v76+8]\n\tv4028 = UnityEngine.Vector3::op_Subtraction(v3837, v8285);\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::Add(this.vertices, v4028);\n\t// 587 MakeStruct v4423 @ AGGC3DE70_0_v32 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v40 @ X29_v1-A8], [v40 @ X29_v1-A4], [v40 @ X29_v1-A0]\n\tv4594 = UnityEngine.Vector3::op_UnaryNegation(v4423);\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::Add(this.normals, v4594);\n\t// 602 MakeStruct v4659 @ AGGC3DE94_0_v32 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v40 @ X29_v1-A8], [v40 @ X29_v1-A4], [v40 @ X29_v1-A0]\n\tv4832 = UnityEngine.Ve\n// ... truncated")]
		public void UpdateRenderer(Camera camera)
		{
			//IL_0c89: Expected I, but got O
			//IL_0bb5: Expected I, but got O
			//IL_02f7: Expected F4, but got O
			//IL_030c: Expected F4, but got I
			//IL_0321: Expected F4, but got I
			//IL_032e: Expected F4, but got O
			//IL_0343: Expected F4, but got I
			//IL_0358: Expected F4, but got I
			//IL_03ba: Expected F4, but got O
			//IL_03cf: Expected F4, but got I
			//IL_03e4: Expected F4, but got I
			//IL_041d: Expected O, but got I
			//IL_046d: Expected F4, but got I
			//IL_0482: Expected F4, but got I
			//IL_0497: Expected F4, but got I
			//IL_04ac: Expected F4, but got I
			//IL_04c1: Expected F4, but got I
			//IL_04d6: Expected F4, but got I
			//IL_0514: Expected O, but got I
			//IL_057e: Expected F4, but got I
			//IL_0593: Expected F4, but got I
			//IL_05a8: Expected F4, but got I
			//IL_05c6: Expected F4, but got O
			//IL_05db: Expected F4, but got I
			//IL_05f0: Expected F4, but got I
			//IL_0655: Expected F4, but got I
			//IL_066a: Expected F4, but got I
			//IL_067f: Expected F4, but got I
			//IL_069d: Expected F4, but got O
			//IL_06b2: Expected F4, but got I
			//IL_06c7: Expected F4, but got I
			//IL_0704: Expected F4, but got I
			//IL_0719: Expected F4, but got I
			//IL_072e: Expected F4, but got I
			//IL_0767: Expected F4, but got I
			//IL_077c: Expected F4, but got I
			//IL_0791: Expected F4, but got I
			//IL_07ca: Expected F4, but got I
			//IL_07df: Expected F4, but got I
			//IL_07f4: Expected F4, but got I
			//IL_0907: Expected F4, but got I
			//IL_091c: Expected F4, but got I
			//IL_0931: Expected F4, but got I
			//IL_0946: Expected F4, but got I
			//IL_09e6: Expected O, but got I
			//IL_0a11: Expected F4, but got I
			//IL_0a26: Expected F4, but got I
			//IL_0a44: Expected O, but got I
			//IL_0a6f: Expected F4, but got I
			//IL_0a84: Expected F4, but got I
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			ProfilerMarker.Internal_Begin((IntPtr)m_UpdateLineRopeRendererChunksPerfMarker);
			if (!(camera == null))
			{
				GameObject gameObject = rope.gameObject;
				if (gameObject.activeInHierarchy)
				{
					CreateMeshIfNeeded();
					ClearMeshData();
					ObiPathSmoother obiPathSmoother = smoother;
					Component component = rope;
					Transform transform = rope.transform;
					Transform transform2 = camera.transform;
					Vector3 position = transform2.position;
					Vector3 vector = transform.InverseTransformPoint(position);
					Vector3 forward = Vector3.forward;
					Vector4 zero = Vector4.zero;
					_ = Vector2.zero.y;
					ObiPathSmoother obiPathSmoother2 = smoother;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2630 @ X0_v87 (UnityEngine.Component)+84]");
					float num = 0f * uvScale.y;
					float num2 = obiPathSmoother.SmoothLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2630 @ X0_v87 (UnityEngine.Component)+84]");
					float num3 = num2 / 0f;
					float num4 = num * uvAnchor;
					float num5 = 0f - num4;
					int num6 = 0;
					int num7 = 0;
					object obj4 = default(object);
					object obj6 = default(object);
					Vector3 a2 = default(Vector3);
					Vector3 b = default(Vector3);
					object obj8 = default(object);
					object obj10 = default(object);
					Vector3 vector2 = default(Vector3);
					object obj13 = default(object);
					Vector3 lhs = default(Vector3);
					Vector3 rhs = default(Vector3);
					object obj16 = default(object);
					Vector3 vector5 = default(Vector3);
					Vector3 vector7 = default(Vector3);
					object obj18 = default(object);
					Vector3 vector8 = default(Vector3);
					Vector3 vector10 = default(Vector3);
					Vector3 vector11 = default(Vector3);
					Vector3 vector12 = default(Vector3);
					Vector3 vector13 = default(Vector3);
					Vector4 item5 = default(Vector4);
					Vector4 item6 = default(Vector4);
					object obj20 = default(object);
					Vector4 vector16 = default(Vector4);
					Vector2 item9 = default(Vector2);
					Vector2 item10 = default(Vector2);
					int num17 = default(int);
					IntPtr markerPtr = default(IntPtr);
					object obj23 = default(object);
					while (true)
					{
						ObiList<ObiList<ObiPathFrame>> smoothChunks = obiPathSmoother2.smoothChunks;
						if (num7 >= smoothChunks.Count)
						{
							break;
						}
						ObiList<ObiPathFrame> obiList = smoothChunks.get_Item(num7);
						bool flag = obiList.Count < 1;
						int num8 = num7;
						if (!flag)
						{
							int num9 = num6 << 1;
							int num10 = 0;
							do
							{
								int a = num10 - 1;
								int index = Mathf.Max(a, 0);
								if ((num10 | num7) == 0)
								{
									ObiPathFrame obiPathFrame = obiList.get_Item(num10);
								}
								object obj3 = obj4;
								ObiPathFrame obiPathFrame2 = obiList.get_Item(num10);
								obj4 = obj3;
								object obj5 = obj6;
								ObiPathFrame obiPathFrame3 = obiList.get_Item(index);
								obj6 = obj5;
								a2.x = (float)obj3;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8172 @ X8_v61+4]");
								a2.y = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8172 @ X8_v61+8]");
								a2.z = 0f;
								b.x = (float)obj5;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8177 @ X8_v62+4]");
								b.y = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8177 @ X8_v62+8]");
								b.z = 0f;
								float num11 = Vector3.Distance(a2, b);
								bool flag2 = !normalizeV;
								float num12 = num3;
								if (!flag2)
								{
									ObiPathSmoother obiPathSmoother3 = smoother;
									num12 = obiPathSmoother3.SmoothLength;
								}
								object obj7 = obj8;
								ObiPathFrame obiPathFrame4 = obiList.get_Item(num10);
								obj8 = obj7;
								object obj9 = obj10;
								ObiPathFrame obiPathFrame5 = obiList.get_Item(num10);
								obj10 = obj9;
								vector2.x = (float)obj9;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8209 @ X8_v68+4]");
								vector2.y = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8209 @ X8_v68+8]");
								vector2.z = 0f;
								Vector3 vector3 = vector2 - vector;
								_ = vector3.y;
								_ = vector3.z;
								object obj11 = (long)(IntPtr)obj2 - 168L;
								Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158A620 (inside UnityEngine.Vector3::get_zero +0x6C)");
								object obj12 = obj13;
								ObiPathFrame obiPathFrame6 = obiList.get_Item(num10);
								obj13 = obj12;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-A8]");
								lhs.x = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-A4]");
								lhs.y = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-A0]");
								lhs.z = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8243 @ X8_v71+C]");
								rhs.x = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8243 @ X8_v71+10]");
								rhs.y = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8243 @ X8_v71+14]");
								rhs.z = 0f;
								Vector3 vector4 = Vector3.Cross(lhs, rhs);
								_ = vector4.y;
								_ = vector4.z;
								object obj14 = (long)(IntPtr)obj2 - 184L;
								Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158A620 (inside UnityEngine.Vector3::get_zero +0x6C)");
								object obj15 = obj16;
								ObiPathFrame obiPathFrame7 = obiList.get_Item(num10);
								obj16 = obj15;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8203 @ X8_v67+40]");
								float num13 = 0f * thicknessScale;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-B8]");
								vector5.x = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-B4]");
								vector5.y = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-B0]");
								vector5.z = 0f;
								Vector3 vector6 = vector5 * num13;
								vector7.x = (float)obj15;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3779 @ X8_v73+4]");
								vector7.y = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3779 @ X8_v73+8]");
								vector7.z = 0f;
								Vector3 item = vector7 + vector6;
								vertices.Add(item);
								object obj17 = obj18;
								ObiPathFrame obiPathFrame8 = obiList.get_Item(num10);
								obj18 = obj17;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-B8]");
								vector8.x = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-B4]");
								vector8.y = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-B0]");
								vector8.z = 0f;
								Vector3 vector9 = vector8 * num13;
								vector10.x = (float)obj17;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4046 @ X8_v76+4]");
								vector10.y = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v4046 @ X8_v76+8]");
								vector10.z = 0f;
								Vector3 item2 = vector10 - vector9;
								vertices.Add(item2);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-A8]");
								vector11.x = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-A4]");
								vector11.y = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-A0]");
								vector11.z = 0f;
								Vector3 item3 = -vector11;
								normals.Add(item3);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-A8]");
								vector12.x = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-A4]");
								vector12.y = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-A0]");
								vector12.z = 0f;
								Vector3 item4 = -vector12;
								normals.Add(item4);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-B8]");
								vector13.x = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-B4]");
								vector13.y = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-B0]");
								vector13.z = 0f;
								Vector3 vector14 = -vector13;
								Vector4 vector15 = vector14;
								item5.x = vector15.x;
								item5.y = vector15.y;
								item5.z = vector15.z;
								item5.w = 1f;
								tangents.Add(item5);
								item6.x = vector15.x;
								item6.y = vector15.y;
								item6.z = vector15.z;
								item6.w = 1f;
								tangents.Add(item6);
								object obj19 = obj20;
								ObiPathFrame obiPathFrame9 = obiList.get_Item(num10);
								obj20 = obj19;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5600 @ X8_v83+30]");
								vector16.x = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5600 @ X8_v83+34]");
								vector16.y = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5600 @ X8_v83+38]");
								vector16.z = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v5600 @ X8_v83+3C]");
								vector16.w = 0f;
								Color item7 = vector16;
								vertColors.Add(item7);
								Color item8 = obiList.get_Item(num10).color;
								vertColors.Add(item8);
								float num14 = num11 / num12;
								float num15 = uvScale.y * num14;
								num5 += num15;
								object obj21 = (long)(IntPtr)obj2 - 152L;
								Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588BC0 (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x1CC)");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-98]");
								item9.x = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-94]");
								item9.y = 0f;
								uvs.Add(item9);
								object obj22 = (long)(IntPtr)obj2 - 152L;
								Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1588BC0 (inside UnityEngine.UnitySynchronizationContext::ExecuteTasks +0x1CC)");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-98]");
								item10.x = 0f;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ X29_v1-94]");
								item10.y = 0f;
								uvs.Add(item10);
								int num16 = obiList.Count - 1;
								bool flag3 = num10 >= num16;
								num8 = 0;
								if (!flag3)
								{
									tris.Add(num9);
									int item11 = num9 + 2;
									tris.Add(item11);
									int item12 = num9 + 1;
									tris.Add(item12);
									tris.Add(item12);
									tris.Add(item11);
									if (tris == null)
									{
										NullReferenceException ex = new NullReferenceException();
										if (num17 == 1)
										{
											Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
											Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
											ProfilerMarker.Internal_End(markerPtr);
											if (obj23 == null)
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
									num8 = num9 + 3;
									tris.Add(num8);
								}
								num10++;
								num9 += 2;
							}
							while (num10 < obiList.Count);
							num6 += num10;
						}
						obiPathSmoother2 = smoother;
						num7++;
						if ((object)smoother == null)
						{
							throw new NullReferenceException();
						}
					}
					CommitMeshData();
				}
			}
			ProfilerMarker.Internal_End((IntPtr)m_UpdateLineRopeRendererChunksPerfMarker);
		}

		[Token(Token = "0x60004EB")]
		[Address(RVA = "0xC3E3CC", Offset = "0xC3E3CC", Length = "0xD8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv18 = *([1ECC4C0]);\n\tv19 = *([v18 @ X8_v14]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20231EA]) = v38;\nL_0017:\n\tUnityEngine.Mesh::Clear(this.lineMesh);\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::Clear(this.vertices);\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::Clear(this.normals);\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector4>::Clear(this.tangents);\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector2>::Clear(this.uvs);\n\tSystem.Collections.Generic.List`1<UnityEngine.Color>::Clear(this.vertColors);\n\tSystem.Collections.Generic.List`1<System.Int32>::Clear(this.tris);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ClearMeshData()
		{
			lineMesh.Clear();
			vertices.Clear();
			normals.Clear();
			tangents.Clear();
			uvs.Clear();
			vertColors.Clear();
			tris.Clear();
		}

		[Token(Token = "0x60004EC")]
		[Address(RVA = "0xC3E4A4", Offset = "0xC3E4A4", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Mesh::SetVertices(this.lineMesh, this.vertices);\n\tUnityEngine.Mesh::SetNormals(this.lineMesh, this.normals);\n\tUnityEngine.Mesh::SetTangents(this.lineMesh, this.tangents);\n\tUnityEngine.Mesh::SetColors(this.lineMesh, this.vertColors);\n\tUnityEngine.Mesh::SetUVs(this.lineMesh, 0, this.uvs);\n\tUnityEngine.Mesh::SetTriangles(this.lineMesh, this.tris, 0, 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void CommitMeshData()
		{
			lineMesh.SetVertices(vertices);
			lineMesh.SetNormals(normals);
			lineMesh.SetTangents(tangents);
			lineMesh.SetColors(vertColors);
			lineMesh.SetUVs(0, uvs);
			lineMesh.SetTriangles(tris, 0, calculateBounds: true);
		}

		[Token(Token = "0x60004ED")]
		[Address(RVA = "0xC3E544", Offset = "0xC3E544", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EF4BE8]);\n\tv23 = *([v22 @ X8_v26]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([20231EB]) = v42;\nL_0018:\n\tv46 = new System.Collections.Generic.List`1<UnityEngine.Vector3>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::.ctor(v46);\n\tthis.vertices = v46;\n\tv52 = new System.Collections.Generic.List`1<UnityEngine.Vector3>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector3>::.ctor(v52);\n\tthis.normals = v52;\n\tv58 = new System.Collections.Generic.List`1<UnityEngine.Vector4>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector4>::.ctor(v58);\n\tthis.tangents = v58;\n\tv66 = new System.Collections.Generic.List`1<UnityEngine.Vector2>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector2>::.ctor(v66);\n\tthis.uvs = v66;\n\tv74 = new System.Collections.Generic.List`1<UnityEngine.Color>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Color>::.ctor(v74);\n\tthis.vertColors = v74;\n\tv82 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v82);\n\tthis.tris = v82;\n\tgoto L_005A;\n\tv93 = *([v89 @ X0_v14+E0]);\n\tv94 = v93 == 0;\n\tv95 = ~v94;\n\tif (v95) goto L_005A;\n\tv97 = \"il2cpp_codegen_runtime_class_init\"(v89, v86, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_005A:\n\tv101 = UnityEngine.Vector2::get_one();\n\tthis.uvScale = v101;\n\tthis.uvScale.y = v101.y;\n\tthis.normalizeV = 1;\n\tthis.thicknessScale = 0.8f;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiRopeLineRenderer()
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

		[Token(Token = "0x60004EE")]
		[Address(RVA = "0xC3E6B4", Offset = "0xC3E6B4", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1ECDCD8]);\n\tv15 = *([v14 @ X8_v10]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20231EC]) = v35;\nL_0016:\n\tv41 = Unity.Profiling.ProfilerMarker::Internal_Create(\"UpdateLineRopeRenderer\", 0);\n\tv45.m_UpdateLineRopeRendererChunksPerfMarker = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static ObiRopeLineRenderer()
		{
			//IL_002a: Expected O, but got I
			IntPtr intPtr = ProfilerMarker.Internal_Create("UpdateLineRopeRenderer", default(Unity.Profiling.MarkerFlags));
			m_UpdateLineRopeRendererChunksPerfMarker = (ProfilerMarker)(long)intPtr;
		}
	}
}
