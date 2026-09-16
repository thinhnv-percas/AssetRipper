using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine.Unity
{
	[Token(Token = "0x20000AC")]
	public class MeshRendererBuffers : IDisposable
	{
		[Token(Token = "0x20000AD")]
		public class SmartMesh : IDisposable
		{
			[Token(Token = "0x4000415")]
			[FieldOffset(Offset = "0x10")]
			public Mesh mesh;

			[Token(Token = "0x4000416")]
			[FieldOffset(Offset = "0x18")]
			public SkeletonRendererInstruction instructionUsed;

			[Token(Token = "0x6000695")]
			[Address(RVA = "0x156F95C", Offset = "0x156F95C", Length = "0x2C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.Mesh::Clear(this.mesh);\n\tSpine.Unity.SkeletonRendererInstruction::Clear(this.instructionUsed);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void Clear()
			{
				mesh.Clear();
				instructionUsed.Clear();
			}

			[Token(Token = "0x6000696")]
			[Address(RVA = "0x156FA7C", Offset = "0x156FA7C", Length = "0x8C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = UnityEngine.Object;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37CD6]) = v37;\nL_0018:\n\tgoto L_001D;\n\tv43 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001D:\n\tv48 = UnityEngine.Object::op_Inequality(this.mesh, 0);\n\tv50 = v48 == 0;\n\tif (v50) goto L_002B;\n\tgoto L_002A;\n\tv67 = \"il2cpp_codegen_runtime_class_init\"(v51, v46, v47, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_002A:\n\tUnityEngine.Object::Destroy(this.mesh);\nL_002B:\n\tthis.mesh = 0;\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void Dispose()
			{
				if (mesh != null)
				{
					UnityEngine.Object.Destroy(mesh);
				}
				mesh = null;
			}

			[Token(Token = "0x6000697")]
			[Address(RVA = "0x156FB08", Offset = "0x156FB08", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = Spine.Unity.SkeletonRendererInstruction;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A37CD7]) = v37;\nL_0013:\n\tv38 = Spine.Unity.SpineMesh::NewSkeletonMesh();\n\tv35.mesh = v38;\n\tv40 = new Spine.Unity.SkeletonRendererInstruction();\n\tSpine.Unity.SkeletonRendererInstruction::.ctor(v40);\n\tv35.instructionUsed = v40;\n\tSystem.Object::.ctor(v35);\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public SmartMesh()
			{
				Mesh mesh = SpineMesh.NewSkeletonMesh();
				this.mesh = mesh;
				SkeletonRendererInstruction skeletonRendererInstruction = new SkeletonRendererInstruction();
				instructionUsed = skeletonRendererInstruction;
			}
		}

		[Token(Token = "0x4000412")]
		[FieldOffset(Offset = "0x10")]
		private DoubleBuffered<SmartMesh> doubleBufferedMesh;

		[Token(Token = "0x4000413")]
		[FieldOffset(Offset = "0x18")]
		internal readonly ExposedList<Material> submeshMaterials;

		[Token(Token = "0x4000414")]
		[FieldOffset(Offset = "0x20")]
		internal Material[] sharedMaterials;

		[Token(Token = "0x600068D")]
		[Address(RVA = "0x1564458", Offset = "0x1564458", Length = "0xE4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv38 = Il2CppMethodInfo;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv49 = Spine.Unity.DoubleBuffered`1<Spine.Unity.MeshRendererBuffers+SmartMesh>;\n\tv50 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv57 = Il2CppMethodInfo;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A37CCF]) = v34;\nL_001A:\n\tv36 = this.doubleBufferedMesh == 0;\n\tif (v36) goto L_003B;\n\tv43 = Spine.Unity.DoubleBuffered`1<Spine.Unity.MeshRendererBuffers+SmartMesh>::GetNext(this.doubleBufferedMesh);\n\tSpine.Unity.MeshRendererBuffers+SmartMesh::Clear(v43);\n\tv62 = Spine.Unity.DoubleBuffered`1<Spine.Unity.MeshRendererBuffers+SmartMesh>::GetNext(this.doubleBufferedMesh);\n\tSpine.Unity.MeshRendererBuffers+SmartMesh::Clear(v62);\n\tSpine.ExposedList`1<UnityEngine.Material>::Clear(this.submeshMaterials, 1);\n\treturn;\nL_003B:\n\tv47 = new Spine.Unity.DoubleBuffered`1<Spine.Unity.MeshRendererBuffers+SmartMesh>();\n\tSpine.Unity.DoubleBuffered`1<Spine.Unity.MeshRendererBuffers+SmartMesh>::.ctor(v47);\n\tthis.doubleBufferedMesh = v47;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Initialize()
		{
			if (doubleBufferedMesh != null)
			{
				SmartMesh next = doubleBufferedMesh.GetNext();
				next.Clear();
				SmartMesh next2 = doubleBufferedMesh.GetNext();
				next2.Clear();
				submeshMaterials.Clear();
			}
			else
			{
				DoubleBuffered<SmartMesh> doubleBuffered = new DoubleBuffered<SmartMesh>();
				doubleBufferedMesh = doubleBuffered;
			}
		}

		[Token(Token = "0x600068E")]
		[Address(RVA = "0x15672B4", Offset = "0x15672B4", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv38 = Il2CppMethodInfo;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A37CD0]) = v34;\nL_0013:\n\tv35 = this.submeshMaterials;\n\tv39 = this.sharedMaterials;\n\tv55 = v35.Count != v39.Length;\n\tif (v55) goto L_002F;\n\tSpine.ExposedList`1<UnityEngine.Material>::CopyTo(v35, v39);\n\treturnVal2 = this.sharedMaterials;\n\tgoto L_0035;\nL_002F:\n\treturnVal2 = Spine.ExposedList`1<UnityEngine.Material>::ToArray(v35);\n\tthis.sharedMaterials = returnVal2;\nL_0035:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Material[] GetUpdatedSharedMaterialsArray()
		{
			ExposedList<Material> exposedList = submeshMaterials;
			object[] array = sharedMaterials;
			Material[] result;
			if (exposedList.Count != array.Length)
			{
				result = (sharedMaterials = exposedList.ToArray());
			}
			else
			{
				exposedList.CopyTo((Material[])array);
				result = sharedMaterials;
			}
			return result;
		}

		[Token(Token = "0x600068F")]
		[Address(RVA = "0x1567348", Offset = "0x1567348", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.submeshMaterials;\n\tv5 = this.sharedMaterials;\n\tv99 = v2.Count != v5.Length;\n\tif (v99) goto L_FFFFFFFF;\n\tv25 = v2.Count < 1;\n\tif (v25) goto L_FFFFFFFF;\n\tv73 = v2.Items;\n\tv64 = 0 - v2.Count;\nL_003B:\n\tv146 = v64 + v22;\n\tv160 = v146 + 1;\n\tv189 = v160 == 0;\n\tif (v189) goto L_004F;\n\tv173 = v73[v22 @ X12_v4 (System.Int32)] == v5[v22 @ X12_v4 (System.Int32)];\n\tv22 = v22 + 1;\n\tif (v173) goto L_003B;\nL_004F:\n\tv158 = v73[v22 @ X12_v4 (System.Int32)] - v5[v22 @ X12_v4 (System.Int32)];\n\tv156 = v158 == 0;\n\tv151 = ~v156;\n\tgoto L_005E;\n\tgoto L_005E;\nL_005E:\n\treturn returnVal2;\n\tv8 = new System.IndexOutOfRangeException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool MaterialsChangedInLastUpdate()
		{
			ExposedList<Material> exposedList = submeshMaterials;
			Material[] array = sharedMaterials;
			if (exposedList.Count == array.Length)
			{
				if (exposedList.Count >= 1)
				{
					Material[] items = exposedList.Items;
					int num = -exposedList.Count;
					int num2 = 0;
					bool flag;
					do
					{
						int num3 = num + num2;
						if (num3 + 1 == 0)
						{
							break;
						}
						flag = (object)items[num2] == array[num2];
						num2++;
					}
					while (flag);
					object obj = (object)items[num2] - (object)array[num2];
					bool flag2 = obj == null;
					return !flag2;
				}
				return false;
			}
			return true;
		}

		[Token(Token = "0x6000690")]
		[Address(RVA = "0x1566D98", Offset = "0x1566D98", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, instructions, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 1;\n\t*([1A37CD1]) = v44;\nL_0018:\n\tv139 = this.submeshMaterials;\n\tv123 = this.submeshMaterials + 0x10;\n\tv120 = *([v123 @ X0_v8 (System.Object[]&)]);\n\tv67 = instructions.Count <= v120.Length;\n\tif (v67) goto L_0040;\n\tSystem.Array::Resize(v123, instructions.Count);\n\tv139 = this.submeshMaterials;\nL_0040:\n\tv139.Count = instructions.Count;\n\tv68 = instructions.Count < 1;\n\tif (v68) goto L_0083;\n\tv55 = v139.Items;\n\tv51 = instructions.Items + 0x30;\nL_0059:\n\tv270 = *([v51 @ X25_v6]) == 0;\n\tif (v270) goto L_006C;\n\t// 94 IsInst v163 @ X0_v15, typeof(UnityEngine.Material), [v51 @ X25_v6]\n\tv165 = v163 == 0;\n\tif (v165) goto L_0086;\nL_006C:\n\tv55[v53 @ X22_v6 (System.Int32)] = *([v51 @ X25_v6]);\n\tv53 = v53 + 1;\n\tv51 = v51 + 0x30;\n\tv192 = instructions.Count != v53;\n\tif (v192) goto L_0059;\nL_0083:\n\treturn;\n\tv122 = new System.IndexOutOfRangeException();\n\tv143 = new System.NullReferenceException();\nL_0086:\n\tv172 = new System.ArrayTypeMismatchException();\n\tthrow v172;\n\treturn;\n// 105 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void UpdateSharedMaterials(ExposedList<SubmeshInstruction> instructions)
		{
			//IL_00cf: Expected O, but got I
			//IL_0152: Expected O, but got I
			ExposedList<Material> exposedList = submeshMaterials;
			ref object[] reference = ref *(object[]*)((nint)submeshMaterials + 16);
			object[] array = reference;
			if (instructions.Count > array.Length)
			{
				Array.Resize(ref reference, instructions.Count);
				exposedList = submeshMaterials;
			}
			exposedList.Count = instructions.Count;
			if (instructions.Count < 1)
			{
				return;
			}
			Material[] items = exposedList.Items;
			object obj = (nint)instructions.Items + 48;
			int num = 0;
			while (true)
			{
				if (obj != null)
				{
					object obj2 = obj as Material;
					if (obj2 == null)
					{
						break;
					}
				}
				items[num] = (Material)obj;
				num++;
				obj = (nint)obj + 48;
				if (instructions.Count == num)
				{
					return;
				}
			}
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw ex;
		}

		[Token(Token = "0x6000691")]
		[Address(RVA = "0x1564ABC", Offset = "0x1564ABC", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A37CD2]) = v33;\nL_001A:\n\treturnVal1 = Spine.Unity.DoubleBuffered`1<Spine.Unity.MeshRendererBuffers+SmartMesh>::GetNext(this.doubleBufferedMesh);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SmartMesh GetNextMesh()
		{
			return doubleBufferedMesh.GetNext();
		}

		[Token(Token = "0x6000692")]
		[Address(RVA = "0x156F988", Offset = "0x156F988", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv43 = UnityEngine.Material[];\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A37CD3]) = v38;\nL_0018:\n\t// 24 NewArr v41 @ X0_v3 (UnityEngine.Material[]), typeof(UnityEngine.Material[]), 0\n\tthis.sharedMaterials = v41;\n\tSpine.ExposedList`1<UnityEngine.Material>::Clear(this.submeshMaterials, 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Clear()
		{
			Material[] array = new Material[0];
			sharedMaterials = array;
			submeshMaterials.Clear();
		}

		[Token(Token = "0x6000693")]
		[Address(RVA = "0x156FA04", Offset = "0x156FA04", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A37CD4]) = v33;\nL_0011:\n\tv35 = this.doubleBufferedMesh == 0;\n\tif (v35) goto L_0027;\n\tv39 = Spine.Unity.DoubleBuffered`1<Spine.Unity.MeshRendererBuffers+SmartMesh>::GetNext(this.doubleBufferedMesh);\n\tSpine.Unity.MeshRendererBuffers+SmartMesh::Dispose(v39);\n\tv43 = Spine.Unity.DoubleBuffered`1<Spine.Unity.MeshRendererBuffers+SmartMesh>::GetNext(this.doubleBufferedMesh);\n\tSpine.Unity.MeshRendererBuffers+SmartMesh::Dispose(v43);\n\tthis.doubleBufferedMesh = 0;\nL_0027:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Dispose()
		{
			if (doubleBufferedMesh != null)
			{
				SmartMesh next = doubleBufferedMesh.GetNext();
				next.Dispose();
				SmartMesh next2 = doubleBufferedMesh.GetNext();
				next2.Dispose();
				doubleBufferedMesh = null;
			}
		}

		[Token(Token = "0x6000694")]
		[Address(RVA = "0x15643B8", Offset = "0x15643B8", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv50 = Spine.ExposedList`1<UnityEngine.Material>;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv55 = UnityEngine.Material[];\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v55, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A37CD5]) = v46;\nL_0020:\n\tv48 = new Spine.ExposedList`1<UnityEngine.Material>();\n\tSpine.ExposedList`1<UnityEngine.Material>::.ctor(v48);\n\tthis.submeshMaterials = v48;\n\t// 39 NewArr v58 @ X0_v5 (UnityEngine.Material[]), typeof(UnityEngine.Material[]), 0\n\tthis.sharedMaterials = v58;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 36 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MeshRendererBuffers()
		{
			ExposedList<Material> exposedList = new ExposedList<Material>();
			submeshMaterials = exposedList;
			Material[] array = new Material[0];
			sharedMaterials = array;
		}
	}
}
