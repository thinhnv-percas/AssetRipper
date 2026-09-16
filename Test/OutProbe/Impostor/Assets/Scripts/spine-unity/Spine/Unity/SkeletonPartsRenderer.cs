using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[HelpURL("http://esotericsoftware.com/spine-unity#SkeletonRenderSeparator")]
	[RequireComponent(typeof(MeshRenderer), typeof(MeshFilter))]
	[Token(Token = "0x2000092")]
	public class SkeletonPartsRenderer : MonoBehaviour
	{
		[Token(Token = "0x2000093")]
		public delegate void SkeletonPartsRendererDelegate(SkeletonPartsRenderer skeletonPartsRenderer);

		[Token(Token = "0x40003A1")]
		[FieldOffset(Offset = "0x20")]
		private MeshGenerator meshGenerator;

		[Token(Token = "0x40003A2")]
		[FieldOffset(Offset = "0x28")]
		internal MeshRenderer meshRenderer;

		[Token(Token = "0x40003A3")]
		[FieldOffset(Offset = "0x30")]
		private MeshFilter meshFilter;

		[CompilerGenerated]
		[Token(Token = "0x40003A4")]
		[FieldOffset(Offset = "0x38")]
		private SkeletonPartsRendererDelegate m_OnMeshAndMaterialsUpdated;

		[Token(Token = "0x40003A5")]
		[FieldOffset(Offset = "0x40")]
		private MeshRendererBuffers buffers;

		[Token(Token = "0x40003A6")]
		[FieldOffset(Offset = "0x48")]
		private SkeletonRendererInstruction currentInstructions;

		[Token(Token = "0x170001A9")]
		public MeshGenerator MeshGenerator
		{
			[Token(Token = "0x60005FF")]
			[Address(RVA = "0x156413C", Offset = "0x156413C", Length = "0x18")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonPartsRenderer::LazyIntialize(this);\n\treturn this.meshGenerator;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				LazyIntialize();
				return meshGenerator;
			}
		}

		[Token(Token = "0x170001AA")]
		public MeshRenderer MeshRenderer
		{
			[Token(Token = "0x6000600")]
			[Address(RVA = "0x1564250", Offset = "0x1564250", Length = "0x18")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonPartsRenderer::LazyIntialize(this);\n\treturn this.meshRenderer;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				LazyIntialize();
				return meshRenderer;
			}
		}

		[Token(Token = "0x170001AB")]
		public MeshFilter MeshFilter
		{
			[Token(Token = "0x6000601")]
			[Address(RVA = "0x1564268", Offset = "0x1564268", Length = "0x18")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonPartsRenderer::LazyIntialize(this);\n\treturn this.meshFilter;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				LazyIntialize();
				return meshFilter;
			}
		}

		[Token(Token = "0x1400002C")]
		public event SkeletonPartsRendererDelegate OnMeshAndMaterialsUpdated
		{
			[CompilerGenerated]
			[Token(Token = "0x6000602")]
			[Address(RVA = "0x1564280", Offset = "0x1564280", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.Unity.SkeletonPartsRenderer+SkeletonPartsRendererDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C8A]) = v38;\nL_0014:\n\tv40 = this + 0x38;\nL_001A:\n\tv88 = System.Delegate::Combine(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.SkeletonPartsRenderer+SkeletonPartsRendererDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			add
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 56;
				Delegate obj2 = this.m_OnMeshAndMaterialsUpdated;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Combine(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(SkeletonPartsRendererDelegate))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
			[CompilerGenerated]
			[Token(Token = "0x6000603")]
			[Address(RVA = "0x156431C", Offset = "0x156431C", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv20 = Spine.Unity.SkeletonPartsRenderer+SkeletonPartsRendererDelegate;\n\tv21 = \"il2cpp_codegen_initialize_runtime_metadata\"(v20, value, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 1;\n\t*([1A37C8B]) = v38;\nL_0014:\n\tv40 = this + 0x38;\nL_001A:\n\tv88 = System.Delegate::Remove(v83, value);\n\tv80 = v88 == 0;\n\tif (v80) goto L_002E;\n\tv100 = *([v88 @ X0_v4 (System.Delegate)]) != Spine.Unity.SkeletonPartsRenderer+SkeletonPartsRendererDelegate;\n\tif (v100) goto L_0043;\nL_002E:\n\tv78 = 0xAF4130(v40, v88, v83, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = v83 != v78;\n\tif (v47) goto L_001A;\n\treturn;\nL_0043:\n\tthrow System.InvalidCastException;\n// 53 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			remove
			{
				//IL_0078: Expected O, but got I
				object obj = (nint)this + 56;
				Delegate obj2 = this.m_OnMeshAndMaterialsUpdated;
				Delegate obj4 = default(Delegate);
				while (true)
				{
					Delegate obj3 = Delegate.Remove(obj2, value);
					if ((object)obj3 != null && (object)obj3.GetType() != typeof(SkeletonPartsRendererDelegate))
					{
						break;
					}
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME:AtomicCompareExchange", "Method not found @AF4130");
					bool flag = (object)obj2 != obj4;
					obj2 = obj4;
					if (!flag)
					{
						return;
					}
				}
				throw new InvalidCastException();
			}
		}

		[Token(Token = "0x6000604")]
		[Address(RVA = "0x1564154", Offset = "0x1564154", Length = "0xFC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv39 = Il2CppMethodInfo;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v39, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv57 = Spine.Unity.MeshGenerator;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv79 = Spine.Unity.MeshRendererBuffers;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v79, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A37C8C]) = v34;\nL_001A:\n\tv36 = this.buffers == 0;\n\tv37 = ~v36;\n\tif (v37) goto L_002F;\n\tv44 = new Spine.Unity.MeshRendererBuffers();\n\tSpine.Unity.MeshRendererBuffers::.ctor(v44);\n\tthis.buffers = v44;\n\tSpine.Unity.MeshRendererBuffers::Initialize(v44);\n\tv48 = this.meshGenerator == 0;\n\tif (v48) goto L_0033;\nL_002F:\n\treturn;\nL_0033:\n\tv87 = new Spine.Unity.MeshGenerator();\n\tSpine.Unity.MeshGenerator::.ctor(v87);\n\tthis.meshGenerator = v87;\n\tv92 = UnityEngine.Component::GetComponent(this);\n\tthis.meshFilter = v92;\n\tv82 = UnityEngine.Component::GetComponent(this);\n\tthis.meshRenderer = v82;\n\tSpine.Unity.SkeletonRendererInstruction::Clear(this.currentInstructions);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void LazyIntialize()
		{
			if (buffers == null)
			{
				(buffers = new MeshRendererBuffers()).Initialize();
				if (this.meshGenerator == null)
				{
					MeshGenerator meshGenerator = new MeshGenerator();
					this.meshGenerator = meshGenerator;
					MeshFilter component = GetComponent<MeshFilter>();
					meshFilter = component;
					MeshRenderer component2 = GetComponent<MeshRenderer>();
					meshRenderer = component2;
					currentInstructions.Clear();
				}
			}
		}

		[Token(Token = "0x6000605")]
		[Address(RVA = "0x1564858", Offset = "0x1564858", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonPartsRenderer::LazyIntialize(this);\n\tUnityEngine.MeshFilter::set_sharedMesh(this.meshFilter, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ClearMesh()
		{
			LazyIntialize();
			meshFilter.sharedMesh = null;
		}

		[Token(Token = "0x6000606")]
		[Address(RVA = "0x1564880", Offset = "0x1564880", Length = "0x23C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonPartsRenderer::LazyIntialize(this);\n\tv24 = Spine.Unity.MeshRendererBuffers::GetNextMesh(this.buffers);\n\tSpine.Unity.SkeletonRendererInstruction::SetWithSubset(this.currentInstructions, instructions, startSubmesh, v158);\n\tv230 = Spine.Unity.SkeletonRendererInstruction::GeometryNotEqual(this.currentInstructions, v24.instructionUsed);\n\tv195 = this.currentInstructions;\n\tv196 = v195.submeshInstructions;\n\tSpine.Unity.MeshGenerator::Begin(this.meshGenerator);\n\tv180 = this.currentInstructions;\n\tv272 = ~v180.hasActiveClipping;\n\tif (v272) goto L_006C;\n\tv155 = v196.Items + 0x20;\nL_0033:\n\tv197 = v180.submeshInstructions;\n\tv83 = v245 >= v197.Count;\n\tif (v83) goto L_0074;\n\tv63 = *([v155 @ X24_v7]);\n\tv245 = v245 + 1;\n\tv155 = v155 + 0x30;\n\tSpine.Unity.MeshGenerator::AddSubmesh(this.meshGenerator, &v63 @ V1, v230);\n\tv327 = this.currentInstructions == 0;\n\tv204 = ~v327;\n\tif (v204) goto L_0033;\n\tthrow System.NullReferenceException;\nL_006C:\n\tSpine.Unity.MeshGenerator::BuildMeshWithArrays(this.meshGenerator, v180, v230);\n\tv180 = this.currentInstructions;\nL_0074:\n\tSpine.Unity.MeshRendererBuffers::UpdateSharedMaterials(this.buffers, v180.submeshInstructions);\n\tv235 = this.meshGenerator;\n\tv201 = v235.vertexBuffer;\n\tv88 = v201.Count <= 0;\n\tif (v88) goto L_0099;\n\tSpine.Unity.MeshGenerator::FillVertexData(v235, v190.mesh);\n\tv281 = v256 == 0;\n\tif (v281) goto L_009E;\n\tSpine.Unity.MeshGenerator::FillTriangles(this.meshGenerator, v190.mesh);\n\tgoto L_00A6;\nL_0099:\n\tUnityEngine.Mesh::Clear(v190.mesh);\n\tgoto L_00B7;\nL_009E:\n\tv289 = Spine.Unity.MeshRendererBuffers::MaterialsChangedInLastUpdate(this.buffers);\n\tv295 = v289 == 0;\n\tif (v295) goto L_00B1;\nL_00A6:\n\tv239 = Spine.Unity.MeshRendererBuffers::GetUpdatedSharedMaterialsArray(this.buffers);\n\tUnityEngine.Renderer::set_sharedMaterials(this.meshRenderer, v239);\nL_00B1:\n\tSpine.Unity.MeshGenerator::FillLateVertexData(this.meshGenerator, v190.mesh);\nL_00B7:\n\tUnityEngine.MeshFilter::set_sharedMesh(this.meshFilter, v190.mesh);\n\tSpine.Unity.SkeletonRendererInstruction::Set(v190.instructionUsed, this.currentInstructions);\n\tv307 = this.OnMeshAndMaterialsUpdated == 0;\n\tif (v307) goto L_00D5;\n\tSpine.Unity.SkeletonPartsRenderer+SkeletonPartsRendererDelegate::Invoke(this.OnMeshAndMaterialsUpdated, this);\nL_00D5:\n\treturn;\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 166 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void RenderParts(ExposedList<SubmeshInstruction> instructions, int startSubmesh, int endSubmesh)
		{
			//IL_00d0: Expected O, but got I
			//IL_013f: Expected O, but got I
			//IL_0152: Expected O, but got Ref
			//IL_017e: Expected O, but got I
			//IL_019f: Expected O, but got I
			LazyIntialize();
			MeshRendererBuffers.SmartMesh nextMesh = buffers.GetNextMesh();
			int endSubmesh2 = default(int);
			currentInstructions.SetWithSubset(instructions, startSubmesh, endSubmesh2);
			bool flag = SkeletonRendererInstruction.GeometryNotEqual(currentInstructions, nextMesh.instructionUsed);
			SkeletonRendererInstruction skeletonRendererInstruction = currentInstructions;
			ExposedList<SubmeshInstruction> submeshInstructions = skeletonRendererInstruction.submeshInstructions;
			this.meshGenerator.Begin();
			SkeletonRendererInstruction skeletonRendererInstruction2 = currentInstructions;
			bool flag2 = !skeletonRendererInstruction2.hasActiveClipping;
			MeshRendererBuffers.SmartMesh smartMesh = nextMesh;
			bool flag3 = flag;
			if (!flag2)
			{
				object obj = (nint)submeshInstructions.Items + 32;
				int num = 0;
				while (true)
				{
					ExposedList<SubmeshInstruction> submeshInstructions2 = skeletonRendererInstruction2.submeshInstructions;
					bool flag4 = num >= submeshInstructions2.Count;
					smartMesh = nextMesh;
					flag3 = flag;
					if (flag4)
					{
						break;
					}
					object obj2 = obj;
					num++;
					obj = (nint)obj + 48;
					this.meshGenerator.AddSubmesh((SubmeshInstruction)(&obj2), flag);
					bool flag5 = currentInstructions == null;
					bool flag6 = !flag5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ X24_v7+10]");
					obj2 = 0;
					smartMesh = nextMesh;
					flag3 = flag;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ X24_v7+10]");
					obj2 = 0;
					skeletonRendererInstruction2 = currentInstructions;
					if (!flag6)
					{
						throw new NullReferenceException();
					}
				}
			}
			else
			{
				this.meshGenerator.BuildMeshWithArrays(skeletonRendererInstruction2, flag);
				skeletonRendererInstruction2 = currentInstructions;
			}
			buffers.UpdateSharedMaterials(skeletonRendererInstruction2.submeshInstructions);
			MeshGenerator meshGenerator = this.meshGenerator;
			ExposedList<Vector3> vertexBuffer = meshGenerator.vertexBuffer;
			if (vertexBuffer.Count > 0)
			{
				meshGenerator.FillVertexData(smartMesh.mesh);
				if (flag3)
				{
					this.meshGenerator.FillTriangles(smartMesh.mesh);
				}
				else if (!buffers.MaterialsChangedInLastUpdate())
				{
					goto IL_02ef;
				}
				Material[] updatedSharedMaterialsArray = buffers.GetUpdatedSharedMaterialsArray();
				meshRenderer.sharedMaterials = updatedSharedMaterialsArray;
				goto IL_02ef;
			}
			smartMesh.mesh.Clear();
			goto IL_0308;
			IL_02ef:
			this.meshGenerator.FillLateVertexData(smartMesh.mesh);
			goto IL_0308;
			IL_0308:
			meshFilter.sharedMesh = smartMesh.mesh;
			smartMesh.instructionUsed.Set(currentInstructions);
			if (this.OnMeshAndMaterialsUpdated != null)
			{
				this.OnMeshAndMaterialsUpdated(this);
			}
		}

		[Token(Token = "0x6000607")]
		[Address(RVA = "0x1567740", Offset = "0x1567740", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSpine.Unity.SkeletonPartsRenderer::LazyIntialize(this);\n\tUnityEngine.Renderer::SetPropertyBlock(this.meshRenderer, block);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetPropertyBlock(MaterialPropertyBlock block)
		{
			LazyIntialize();
			meshRenderer.SetPropertyBlock(block);
		}

		[Token(Token = "0x6000608")]
		[Address(RVA = "0x1567774", Offset = "0x1567774", Length = "0x1D8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tv34 = Il2CppMethodInfo;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, name, sortingOrder, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv57 = UnityEngine.GameObject;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, name, sortingOrder, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv66 = UnityEngine.MeshFilter;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, name, sortingOrder, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv75 = UnityEngine.MeshRenderer;\n\tv76 = \"il2cpp_codegen_initialize_runtime_metadata\"(v75, name, sortingOrder, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv79 = System.Type[];\n\tv80 = \"il2cpp_codegen_initialize_runtime_metadata\"(v79, name, sortingOrder, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv140 = System.Type;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v140, name, sortingOrder, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\n\tv52 = 1;\n\t*([1A37C8D]) = v52;\nL_002E:\n\t// 46 NewArr v55 @ X0_v3 (System.Type[]), typeof(System.Type[]), 2\n\tgoto L_003A;\n\tv68 = v59;\n\tv69 = \"il2cpp_codegen_runtime_class_init\"(v68, v54, sortingOrder, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48);\nL_003A:\n\tv73 = System.Type::GetTypeFromHandle(UnityEngine.MeshFilter);\n\tv82 = v73 == 0;\n\tif (v82) goto L_004B;\n\t// 67 IsInst v144 @ X0_v29, typeof(System.Type), v73 @ X0_v6 (System.Type)\n\tv148 = v144 == 0;\n\tif (v148) goto L_0096;\nL_004B:\n\tv55[0] = v73;\n\tv180 = System.Type::GetTypeFromHandle(UnityEngine.MeshRenderer);\n\tv204 = v180 == 0;\n\tif (v204) goto L_0067;\n\t// 85 IsInst v195 @ X0_v27, typeof(System.Type), v180 @ X0_v16 (System.Type)\n\tv197 = v195 == 0;\n\tif (v197) goto L_0096;\nL_0067:\n\tv55[1] = v180;\n\tv121 = new UnityEngine.GameObject();\n\tUnityEngine.GameObject::.ctor(v121, name, v55);\n\tv122 = UnityEngine.GameObject::get_transform(v121);\n\tUnityEngine.Transform::SetParent(v122, parent, 0);\n\tv123 = UnityEngine.GameObject::AddComponent(v121);\n\tSpine.Unity.SkeletonPartsRenderer::LazyIntialize(v123);\n\tUnityEngine.Renderer::set_sortingOrder(v123.meshRenderer, sortingOrder);\n\treturn v123;\n\tv138 = new System.NullReferenceException();\n\tv175 = new System.IndexOutOfRangeException();\nL_0096:\n\tv203 = new System.ArrayTypeMismatchException();\n\tthrow v203;\n\treturn returnVal1;\n// 108 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static SkeletonPartsRenderer NewPartsRendererGameObject(Transform parent, string name, int sortingOrder = 0)
		{
			Type[] array = new Type[2];
			Type typeFromHandle = typeof(MeshFilter);
			if ((object)typeFromHandle != null)
			{
				object obj = typeFromHandle as Type;
				if (obj == null)
				{
					goto IL_014a;
				}
			}
			array[0] = typeFromHandle;
			Type typeFromHandle2 = typeof(MeshRenderer);
			if ((object)typeFromHandle2 != null)
			{
				object obj2 = typeFromHandle2 as Type;
				if (obj2 == null)
				{
					goto IL_014a;
				}
			}
			array[1] = typeFromHandle2;
			GameObject gameObject = new GameObject(name, array);
			Transform transform = gameObject.transform;
			transform.SetParent(parent, worldPositionStays: false);
			SkeletonPartsRenderer skeletonPartsRenderer = gameObject.AddComponent<SkeletonPartsRenderer>();
			skeletonPartsRenderer.LazyIntialize();
			skeletonPartsRenderer.meshRenderer.sortingOrder = sortingOrder;
			return skeletonPartsRenderer;
			IL_014a:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}

		[Token(Token = "0x6000609")]
		[Address(RVA = "0x156794C", Offset = "0x156794C", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Spine.Unity.SkeletonRendererInstruction;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37C8E]) = v37;\nL_0014:\n\tv39 = new Spine.Unity.SkeletonRendererInstruction();\n\tSpine.Unity.SkeletonRendererInstruction::.ctor(v39);\n\tthis.currentInstructions = v39;\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkeletonPartsRenderer()
		{
			SkeletonRendererInstruction skeletonRendererInstruction = new SkeletonRendererInstruction();
			currentInstructions = skeletonRendererInstruction;
		}
	}
}
