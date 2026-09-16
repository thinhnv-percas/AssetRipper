using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity.Examples
{
	[RequireComponent(typeof(MeshFilter))]
	[ExecuteAlways]
	[RequireComponent(typeof(MeshRenderer))]
	[Token(Token = "0x2000054")]
	public class RenderExistingMesh : MonoBehaviour
	{
		[Serializable]
		[Token(Token = "0x2000055")]
		public struct MaterialReplacement
		{
			[Token(Token = "0x40001C3")]
			[FieldOffset(Offset = "0x0")]
			public Material originalMaterial;

			[Token(Token = "0x40001C4")]
			[FieldOffset(Offset = "0x8")]
			public Material replacementMaterial;
		}

		[Token(Token = "0x40001BB")]
		[FieldOffset(Offset = "0x20")]
		public MeshRenderer referenceRenderer;

		[Token(Token = "0x40001BC")]
		[FieldOffset(Offset = "0x28")]
		private bool updateViaSkeletonCallback;

		[Token(Token = "0x40001BD")]
		[FieldOffset(Offset = "0x30")]
		private MeshFilter referenceMeshFilter;

		[Token(Token = "0x40001BE")]
		[FieldOffset(Offset = "0x38")]
		private MeshRenderer ownRenderer;

		[Token(Token = "0x40001BF")]
		[FieldOffset(Offset = "0x40")]
		private MeshFilter ownMeshFilter;

		[Token(Token = "0x40001C0")]
		[FieldOffset(Offset = "0x48")]
		public MaterialReplacement[] replacementMaterials;

		[Token(Token = "0x40001C1")]
		[FieldOffset(Offset = "0x50")]
		private Dictionary<Material, Material> replacementMaterialDict;

		[Token(Token = "0x40001C2")]
		[FieldOffset(Offset = "0x58")]
		private Material[] sharedMaterials;

		[Token(Token = "0x6000161")]
		[Address(RVA = "0x1517CE4", Offset = "0x1517CE4", Length = "0x1EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv49 = Il2CppMethodInfo;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv58 = Il2CppMethodInfo;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv63 = Il2CppMethodInfo;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv70 = UnityEngine.Object;\n\tv71 = \"il2cpp_codegen_initialize_runtime_metadata\"(v70, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv83 = Il2CppMethodInfo;\n\tv84 = \"il2cpp_codegen_initialize_runtime_metadata\"(v83, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv125 = Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v125, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A37A78]) = v42;\nL_002C:\n\tgoto L_0031;\n\tv51 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0031:\n\tv56 = UnityEngine.Object::op_Equality(this.referenceRenderer, 0);\n\tv61 = v56 == 0;\n\tif (v61) goto L_FFFFFFFF;\n\tv67 = UnityEngine.Component::get_transform(this);\n\tv86 = UnityEngine.Transform::get_parent(v67);\n\tv76 = UnityEngine.Component::GetComponentInParent(v86);\n\tthis.referenceRenderer = v76;\n\tgoto L_004A;\nL_004A:\n\tv123 = UnityEngine.Component::GetComponent(v75);\n\tgoto L_0055;\n\tv150 = v112;\n\tv151 = \"il2cpp_codegen_runtime_class_init\"(v150, v122, v55, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0055:\n\tv155 = UnityEngine.Object::op_Implicit(v123);\n\tv157 = v155 == 0;\n\tif (v157) goto L_007F;\n\tv106 = new Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate();\n\tSpine.Unity.SkeletonRenderer+SkeletonRendererDelegate::.ctor(v106, this, Il2CppMethodInfo);\n\tSpine.Unity.SkeletonRenderer::remove_OnMeshAndMaterialsUpdated(v123, v106);\n\tv184 = new Spine.Unity.SkeletonRenderer+SkeletonRendererDelegate();\n\tSpine.Unity.SkeletonRenderer+SkeletonRendererDelegate::.ctor(v184, this, Il2CppMethodInfo);\n\tSpine.Unity.SkeletonRenderer::add_OnMeshAndMaterialsUpdated(v123, v184);\n\tthis.updateViaSkeletonCallback = 1;\nL_007F:\n\tv174 = UnityEngine.Component::GetComponent(this.referenceRenderer);\n\tthis.referenceMeshFilter = v174;\n\tv177 = UnityEngine.Component::GetComponent(this);\n\tthis.ownRenderer = v177;\n\tv182 = UnityEngine.Component::GetComponent(this);\n\tthis.ownMeshFilter = v182;\n\tSpine.Unity.Examples.RenderExistingMesh::InitializeDict(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 98 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			Component component;
			if (referenceRenderer == null)
			{
				Transform transform = base.transform;
				Transform parent = transform.parent;
				component = (referenceRenderer = parent.GetComponentInParent<MeshRenderer>());
			}
			else
			{
				component = referenceRenderer;
			}
			SkeletonAnimation component2 = component.GetComponent<SkeletonAnimation>();
			if ((bool)component2)
			{
				SkeletonRenderer.SkeletonRendererDelegate value = UpdateOnCallback;
				component2.OnMeshAndMaterialsUpdated -= value;
				SkeletonRenderer.SkeletonRendererDelegate value2 = UpdateOnCallback;
				component2.OnMeshAndMaterialsUpdated += value2;
				updateViaSkeletonCallback = true;
			}
			MeshFilter component3 = referenceRenderer.GetComponent<MeshFilter>();
			referenceMeshFilter = component3;
			MeshRenderer component4 = GetComponent<MeshRenderer>();
			ownRenderer = component4;
			MeshFilter component5 = GetComponent<MeshFilter>();
			ownMeshFilter = component5;
			InitializeDict();
		}

		[Token(Token = "0x6000162")]
		[Address(RVA = "0x1517F70", Offset = "0x1517F70", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = ~this.updateViaSkeletonCallback;\n\tif (v2) goto L_0004;\n\treturn;\nL_0004:\n\tSpine.Unity.Examples.RenderExistingMesh::UpdateMaterials(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void LateUpdate()
		{
			if (!updateViaSkeletonCallback)
			{
				UpdateMaterials();
			}
		}

		[Token(Token = "0x6000163")]
		[Address(RVA = "0x151811C", Offset = "0x151811C", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.Examples.RenderExistingMesh::UpdateMaterials(this);\n\treturn;\n")]
		private void UpdateOnCallback(SkeletonRenderer r)
		{
			UpdateMaterials();
		}

		[Token(Token = "0x6000164")]
		[Address(RVA = "0x1517F80", Offset = "0x1517F80", Length = "0x19C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv50 = Il2CppMethodInfo;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv148 = UnityEngine.Material[];\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v148, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A37A79]) = v46;\nL_0021:\n\tv54 = UnityEngine.MeshFilter::get_sharedMesh(this.referenceMeshFilter);\n\tUnityEngine.MeshFilter::set_sharedMesh(this.ownMeshFilter, v54);\n\tv126 = UnityEngine.Renderer::get_sharedMaterials(this.referenceRenderer);\n\tv141 = this.sharedMaterials;\n\tv264 = v126.Length;\n\tv255 = v141.Length == v126.Length;\n\tif (v255) goto L_004F;\n\t// 66 NewArr v263 @ X0_v27 (UnityEngine.Material[]), typeof(UnityEngine.Material[]), v126.Length\n\tthis.sharedMaterials = v263;\n\tv264 = v126.Length;\nL_004F:\n\tv278 = v264 < 1;\n\tif (v278) goto L_00A7;\nL_0067:\n\tv311 = System.Collections.Generic.Dictionary`2<UnityEngine.Material, UnityEngine.Material>::ContainsKey(this.replacementMaterialDict, *([v126 @ X0_v13 (UnityEngine.Material[])+v71 @ X24_v7 (System.Int32)*8]));\n\tv313 = v311 == 0;\n\tif (v313) goto L_008A;\n\tv64 = this.sharedMaterials;\n\tv129 = System.Collections.Generic.Dictionary`2<UnityEngine.Material, UnityEngine.Material>::get_Item(this.replacementMaterialDict, *([v126 @ X0_v13 (UnityEngine.Material[])+v71 @ X24_v7 (System.Int32)*8]));\n\tv326 = v129 == 0;\n\tif (v326) goto L_0088;\n\t// 122 IsInst v206 @ X0_v25, typeof(UnityEngine.Material), v129 @ X0_v22 (UnityEngine.Material)\n\tv208 = v206 == 0;\n\tif (v208) goto L_00AB;\nL_0088:\n\t*([v64 @ X26_v8 (UnityEngine.Material[])+v71 @ X24_v7 (System.Int32)*8]) = v129;\nL_008A:\n\tv300 = v71 - 3;\n\tv71 = v71 + 1;\n\tv282 = v300 < v126.Length;\n\tif (v282) goto L_0067;\nL_00A7:\n\tUnityEngine.Renderer::set_sharedMaterials(this.ownRenderer, this.sharedMaterials);\n\treturn;\n\tv146 = new System.NullReferenceException();\n\tv185 = new System.IndexOutOfRangeException();\nL_00AB:\n\tv212 = new System.ArrayTypeMismatchException();\n\tthrow v212;\n\treturn;\n// 132 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UpdateMaterials()
		{
			//IL_0055: Expected O, but got I4
			//IL_0098: Expected O, but got I4
			//IL_00c2: Expected O, but got I
			//IL_0104: Expected O, but got I
			Mesh sharedMesh = referenceMeshFilter.sharedMesh;
			ownMeshFilter.sharedMesh = sharedMesh;
			Material[] array = referenceRenderer.sharedMaterials;
			Material[] array2 = sharedMaterials;
			object obj = array.Length;
			if (array2.Length != array.Length)
			{
				Material[] array3 = new Material[array.Length];
				sharedMaterials = array3;
				obj = array.Length;
			}
			if ((nint)obj >= 1)
			{
				int num = 4;
				int num2;
				do
				{
					Dictionary<Material, Material> dictionary = replacementMaterialDict;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ X0_v13 (UnityEngine.Material[])+v71 @ X24_v7 (System.Int32)*8]");
					if (dictionary.ContainsKey((Material)0))
					{
						Material[] array4 = sharedMaterials;
						Dictionary<Material, Material> dictionary2 = replacementMaterialDict;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ X0_v13 (UnityEngine.Material[])+v71 @ X24_v7 (System.Int32)*8]");
						Material material = dictionary2[(Material)0];
						if ((object)material != null)
						{
							object obj2 = material as Material;
							if (obj2 == null)
							{
								ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
								throw ex;
							}
						}
					}
					num2 = num - 3;
					num++;
				}
				while (num2 < array.Length);
			}
			ownRenderer.sharedMaterials = sharedMaterials;
		}

		[Token(Token = "0x6000165")]
		[Address(RVA = "0x1517ED0", Offset = "0x1517ED0", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37A7A]) = v37;\nL_0012:\n\tv98 = this.replacementMaterials;\nL_0023:\n\tv45 = v101 >= v98.Length;\n\tif (v45) goto L_0045;\n\tv173 = v98 + v88;\n\tv101 = v101 + 1;\n\tv51 = v88 + 0x10;\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Material, UnityEngine.Material>::set_Item(this.replacementMaterialDict, *([v173 @ X8_v7+20]), *([v173 @ X8_v7+28]));\n\tv98 = this.replacementMaterials;\n\tv174 = this.replacementMaterials == 0;\n\tv94 = ~v174;\n\tif (v94) goto L_0023;\n\tthrow System.NullReferenceException;\nL_0045:\n\treturn;\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 52 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void InitializeDict()
		{
			//IL_002a: Expected O, but got I
			//IL_0069: Expected O, but got I
			//IL_0069: Expected O, but got I
			MaterialReplacement[] array = replacementMaterials;
			int num = 0;
			int num2 = 0;
			while (num2 < array.Length)
			{
				object obj = (nint)array + num;
				num2++;
				int num3 = num + 16;
				Dictionary<Material, Material> dictionary = replacementMaterialDict;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X8_v7+20]");
				nint num4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v173 @ X8_v7+28]");
				dictionary[(Material)num4] = (Material)0;
				array = replacementMaterials;
				bool flag = replacementMaterials == null;
				bool flag2 = !flag;
				num = num3;
				if (!flag2)
				{
					throw new NullReferenceException();
				}
			}
		}

		[Token(Token = "0x6000166")]
		[Address(RVA = "0x1518120", Offset = "0x1518120", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv55 = System.Collections.Generic.Dictionary`2<UnityEngine.Material, UnityEngine.Material>;\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv60 = MaterialReplacement[];\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv65 = UnityEngine.Material[];\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A37A7B]) = v50;\nL_0027:\n\t// 39 NewArr v53 @ X0_v3 (MaterialReplacement[]), typeof(MaterialReplacement[]), 0\n\tthis.replacementMaterials = v53;\n\tv58 = new System.Collections.Generic.Dictionary`2<UnityEngine.Material, UnityEngine.Material>();\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Material, UnityEngine.Material>::.ctor(v58);\n\tthis.replacementMaterialDict = v58;\n\t// 49 NewArr v68 @ X0_v7 (UnityEngine.Material[]), typeof(UnityEngine.Material[]), 0\n\tthis.sharedMaterials = v68;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public RenderExistingMesh()
		{
			MaterialReplacement[] array = new MaterialReplacement[0];
			replacementMaterials = array;
			Dictionary<Material, Material> dictionary = new Dictionary<Material, Material>();
			replacementMaterialDict = dictionary;
			Material[] array2 = new Material[0];
			sharedMaterials = array2;
		}
	}
}
