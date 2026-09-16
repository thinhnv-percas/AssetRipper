using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Token(Token = "0x2000022")]
	public class ObiMeshShapeTracker : ObiShapeTracker
	{
		[Token(Token = "0x20000AB")]
		private class MeshDataHandles
		{
			[Token(Token = "0x40002E5")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			internal int refCount;

			[Token(Token = "0x40002E6")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x14")]
			private GCHandle verticesHandle;

			[Token(Token = "0x40002E7")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			private GCHandle indicesHandle;

			[Token(Token = "0x170000D3")]
			public int RefCount
			{
				[Token(Token = "0x600053B")]
				[Address(RVA = "0xE47A60", Offset = "0xE47A60", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.refCount;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					return RefCount;
				}
			}

			[Token(Token = "0x170000D4")]
			public IntPtr VerticesAddress
			{
				[Token(Token = "0x600053C")]
				[Address(RVA = "0xE47888", Offset = "0xE47888", Length = "0xC")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this + 0x14;\n\treturnVal1 = 0xF74EC4(v0, 0, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					//IL_000c: Expected O, but got I
					object obj = (long)(IntPtr)this + 20L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @F74EC4 (inside System.Runtime.InteropServices.GCHandle::GetTarget +0x38)");
					IntPtr result = default(IntPtr);
					return result;
				}
			}

			[Token(Token = "0x170000D5")]
			public IntPtr IndicesAddress
			{
				[Token(Token = "0x600053D")]
				[Address(RVA = "0xE47894", Offset = "0xE47894", Length = "0xC")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this + 0x18;\n\treturnVal1 = 0xF74EC4(v0, 0, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					//IL_000c: Expected O, but got I
					object obj = (long)(IntPtr)this + 24L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @F74EC4 (inside System.Runtime.InteropServices.GCHandle::GetTarget +0x38)");
					IntPtr result = default(IntPtr);
					return result;
				}
			}

			[Token(Token = "0x600053E")]
			[Address(RVA = "0xE47664", Offset = "0xE47664", Length = "0x74")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tOni::UnpinMemory(this.verticesHandle);\n\tOni::UnpinMemory(this.indicesHandle);\n\tv21 = UnityEngine.Mesh::get_vertices(mesh);\n\tv39 = Oni::PinMemory(v21);\n\tthis.verticesHandle = v39;\n\tv42 = UnityEngine.Mesh::get_triangles(mesh);\n\tv50 = Oni::PinMemory(v42);\n\tthis.indicesHandle = v50;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void FromMesh(Mesh mesh)
			{
				Oni.UnpinMemory(verticesHandle);
				Oni.UnpinMemory(indicesHandle);
				Vector3[] vertices = mesh.vertices;
				GCHandle gCHandle = Oni.PinMemory(vertices);
				verticesHandle = gCHandle;
				int[] triangles = mesh.triangles;
				GCHandle gCHandle2 = Oni.PinMemory(triangles);
				indicesHandle = gCHandle2;
			}

			[Token(Token = "0x600053F")]
			[Address(RVA = "0xE47654", Offset = "0xE47654", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.refCount + 1;\n\tthis.refCount = v2;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void Ref()
			{
				int num = RefCount + 1;
				refCount = num;
			}

			[Token(Token = "0x6000540")]
			[Address(RVA = "0xE475F0", Offset = "0xE475F0", Length = "0x54")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = this.refCount - 1;\n\tthis.refCount = v11;\n\tv23 = v11 <= 0;\n\tif (v23) goto L_001D;\n\treturn;\nL_001D:\n\tthis.refCount = 0;\n\tOni::UnpinMemory(this.verticesHandle);\n\tOni::UnpinMemory(this.indicesHandle);\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void Unref()
			{
				if ((refCount = RefCount - 1) <= 0)
				{
					refCount = 0;
					Oni.UnpinMemory(verticesHandle);
					Oni.UnpinMemory(indicesHandle);
				}
			}

			[Token(Token = "0x6000541")]
			[Address(RVA = "0xE47644", Offset = "0xE47644", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.refCount = 1;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public MeshDataHandles()
			{
				refCount = 1;
			}
		}

		[Token(Token = "0x4000079")]
		private static Dictionary<Mesh, MeshDataHandles> meshDataCache;

		[Token(Token = "0x400007A")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x60")]
		private bool meshDataHasChanged;

		[Token(Token = "0x400007B")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x68")]
		private MeshDataHandles handles;

		[Token(Token = "0x60001F9")]
		[Address(RVA = "0xE4110C", Offset = "0xE4110C", Length = "0x44")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiShapeTracker::.ctor(this);\n\tthis.collider = collider;\n\tthis.adaptor.is2D = 0;\n\tv17 = Oni::CreateShape(4);\n\tthis.oniShape = v17;\n\tObi.ObiMeshShapeTracker::UpdateMeshData(this);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiMeshShapeTracker(MeshCollider collider)
		{
			base.collider = collider;
			adaptor.is2D = false;
			IntPtr intPtr = Oni.CreateShape(Oni.ShapeType.TriangleMesh);
			oniShape = intPtr;
			UpdateMeshData();
		}

		[Token(Token = "0x60001FA")]
		[Address(RVA = "0xE473E0", Offset = "0xE473E0", Length = "0x210")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EB6E50]);\n\tv23 = *([v22 @ X8_v36]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([2024765]) = v42;\nL_0017:\n\tv45 = this.collider == 0;\n\tif (v45) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0044;\n\tv99 = v99_asT == 0;\n\tif (v99) goto L_FFFFFFFF;\n\tgoto L_0044;\nL_0044:\n\tgoto L_004D;\n\tv125 = *([v121 @ X0_v2+E0]);\n\tv126 = v125 == 0;\n\tv127 = ~v126;\n\tgoto L_004D;\n\tv129 = \"il2cpp_codegen_runtime_class_init\"(v121, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_004D:\n\tv135 = UnityEngine.Object::op_Inequality(v116, 0);\n\tv137 = v135 == 0;\n\tif (v137) goto L_00BC;\n\tv167 = UnityEngine.MeshCollider::get_sharedMesh(v116);\n\tv203 = this.handles == 0;\n\tif (v203) goto L_0060;\n\tObi.ObiMeshShapeTracker+MeshDataHandles::Unref(this.handles);\nL_0060:\n\tgoto L_0069;\n\tv210 = *([v206 @ X0_v13+E0]);\n\tv211 = v210 == 0;\n\tv212 = ~v211;\n\tif (v212) goto L_0069;\n\tv214 = \"il2cpp_codegen_runtime_class_init\"(v206, v166, v134, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0069:\n\tv220 = UnityEngine.Object::op_Inequality(v167, 0);\n\tv222 = v220 == 0;\n\tif (v222) goto L_00B4;\n\tgoto L_0083;\n\tv237 = *([v224 @ X0_v18 (Il2CppClass<Obi.ObiMeshShapeTracker>)+E0]);\n\tv238 = v237 == 0;\n\tv239 = ~v238;\n\t// 119 ConditionalJump @b48, v239 @ TEMP_v37\n\tv247 = \"il2cpp_codegen_runtime_class_init\"(v224, v218, v219, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv241 = Obi.ObiMeshShapeTracker;\nL_0083:\n\tv253 = System.Collections.Generic.Dictionary`2<UnityEngine.Mesh, Obi.ObiMeshShapeTracker+MeshDataHandles>::TryGetValue(v244.meshDataCache, v167, &v230 @ stack_-38_v6 (Obi.ObiMeshShapeTracker+MeshDataHandles));\n\tv269 = v253 == 0;\n\tif (v269) goto L_0092;\n\tv275 = v230.refCount + 1;\n\tv230.refCount = v275;\n\tthis.handles = v230;\n\tgoto L_00B2;\nL_0092:\n\tv273 = new Obi.ObiMeshShapeTracker+MeshDataHandles();\n\tv273.refCount = 1;\n\tSystem.Object::.ctor(v273);\n\tthis.handles = v273;\n\tgoto L_00A9;\n\tv282 = *([v278 @ X0_v27 (Il2CppClass<Obi.ObiMeshShapeTracker>)+E0]);\n\tv283 = v282 == 0;\n\tv284 = ~v283;\n\t// 161 ConditionalJump @b49, v284 @ TEMP_v34\n\tv289 = \"il2cpp_codegen_runtime_class_init\"(v278, v258, v250, v252, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv286 = Obi.ObiMeshShapeTracker;\nL_00A9:\n\t;\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Mesh, Obi.ObiMeshShapeTracker+MeshDataHandles>::set_Item(v267.meshDataCache, v167, this.handles);\n\tv233 = this.handles;\nL_00B2:\n\tObi.ObiMeshShapeTracker+MeshDataHandles::FromMesh(v233, v167);\nL_00B4:\n\tthis.meshDataHasChanged = 1;\nL_00BC:\n\treturn;\n\tthrow System.NullReferenceException;\n\tthrow System.NullReferenceException;\n\treturn;\n// 124 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateMeshData()
		{
			UnityEngine.Object obj;
			if ((object)collider == null)
			{
				obj = null;
			}
			else
			{
				MeshCollider meshCollider = collider as MeshCollider;
				obj = (((object)meshCollider == null) ? null : collider);
			}
			if (!(obj != null))
			{
				return;
			}
			Mesh sharedMesh = ((MeshCollider)obj).sharedMesh;
			if (handles != null)
			{
				handles.Unref();
			}
			if (sharedMesh != null)
			{
				MeshDataHandles meshDataHandles;
				if (meshDataCache.TryGetValue(sharedMesh, out var value))
				{
					int refCount = value.RefCount + 1;
					value.refCount = refCount;
					handles = value;
					meshDataHandles = value;
				}
				else
				{
					MeshDataHandles meshDataHandles2 = new MeshDataHandles();
					meshDataHandles2.refCount = 1;
					handles = meshDataHandles2;
					meshDataCache.set_Item(sharedMesh, handles);
					meshDataHandles = handles;
				}
				meshDataHandles.FromMesh(sharedMesh);
			}
			meshDataHasChanged = true;
		}

		[Token(Token = "0x60001FB")]
		[Address(RVA = "0xE476D8", Offset = "0xE476D8", Length = "0x1B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EC5098]);\n\tv25 = *([v24 @ X8_v17]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2024766]) = v44;\nL_0017:\n\tv46 = this.collider == 0;\n\tif (v46) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0044;\n\tv100 = v100_asT == 0;\n\tif (v100) goto L_FFFFFFFF;\n\tgoto L_0044;\nL_0044:\n\tgoto L_004D;\n\tv126 = *([v122 @ X0_v2+E0]);\n\tv127 = v126 == 0;\n\tv128 = ~v127;\n\tgoto L_004D;\n\tv130 = \"il2cpp_codegen_runtime_class_init\"(v122, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_004D:\n\tv136 = UnityEngine.Object::op_Inequality(v117, 0);\n\tv138 = v136 == 0;\n\tif (v138) goto L_FFFFFFFF;\n\tv159 = UnityEngine.MeshCollider::get_sharedMesh(v117);\n\tgoto L_0065;\n\tv242 = *([v152 @ X8_v10+E0]);\n\tv243 = v242 == 0;\n\tv244 = ~v243;\n\tif (v244) goto L_0065;\n\tv249 = v152;\n\tv246 = \"il2cpp_codegen_runtime_class_init\"(v249, v158, v135, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_0065:\n\tv147 = UnityEngine.Object::op_Inequality(v159, 0);\n\tv149 = v147 == 0;\n\tif (v149) goto L_FFFFFFFF;\n\tv150 = ~this.meshDataHasChanged;\n\tif (v150) goto L_FFFFFFFF;\n\tthis.meshDataHasChanged = 0;\n\tv251 = this.handles + 0x14;\n\tv170 = 0xF74EC4(v251, 0, 0, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv252 = this.handles + 0x18;\n\tv171 = 0xF74EC4(v252, 0, 0, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv255 = UnityEngine.Mesh::get_vertexCount(v159);\n\tv221 = UnityEngine.Mesh::get_triangles(v159);\n\tv202 = this + 0x18;\n\tv260 = 0x103BBD0(v202, v170, v171, v255, v221.Length, 0, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tOni::UpdateShape(this.oniShape, v202);\n\tgoto L_009D;\nL_009D:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 112 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override bool UpdateIfNeeded()
		{
			//IL_00fd: Expected O, but got I
			//IL_011d: Expected O, but got I
			UnityEngine.Object obj;
			if ((object)collider == null)
			{
				obj = null;
			}
			else
			{
				MeshCollider meshCollider = collider as MeshCollider;
				obj = (((object)meshCollider == null) ? null : collider);
			}
			if (obj != null)
			{
				Mesh sharedMesh = ((MeshCollider)obj).sharedMesh;
				if (sharedMesh != null && meshDataHasChanged)
				{
					meshDataHasChanged = false;
					object obj2 = (long)(IntPtr)handles + 20L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @F74EC4 (inside System.Runtime.InteropServices.GCHandle::GetTarget +0x38)");
					object obj3 = (long)(IntPtr)handles + 24L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @F74EC4 (inside System.Runtime.InteropServices.GCHandle::GetTarget +0x38)");
					int vertexCount = sharedMesh.vertexCount;
					int[] triangles = sharedMesh.triangles;
					ref Oni.Shape reference = ref *(Oni.Shape*)((long)(IntPtr)this + 24L);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @103BBD0 (inside Oni::GetProfilingInfo +0xDC0)");
					Oni.UpdateShape(OniShape, ref reference);
					return true;
				}
			}
			return false;
		}

		[Token(Token = "0x60001FC")]
		[Address(RVA = "0xE478A0", Offset = "0xE478A0", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1F09908]);\n\tv19 = *([v18 @ X8_v21]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2024767]) = v38;\nL_0015:\n\tObi.ObiShapeTracker::Destroy(this);\n\tv42 = this.collider == 0;\n\tif (v42) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0044;\n\tv96 = v96_asT == 0;\n\tif (v96) goto L_FFFFFFFF;\n\tgoto L_0044;\nL_0044:\n\tgoto L_004D;\n\tv122 = *([v118 @ X0_v3+E0]);\n\tv123 = v122 == 0;\n\tv124 = ~v123;\n\tgoto L_004D;\n\tv126 = \"il2cpp_codegen_runtime_class_init\"(v118, v40, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_004D:\n\tv132 = UnityEngine.Object::op_Inequality(v113, 0);\n\tv134 = v132 == 0;\n\tif (v134) goto L_006B;\n\tv136 = this.handles == 0;\n\tif (v136) goto L_006B;\n\tObi.ObiMeshShapeTracker+MeshDataHandles::Unref(this.handles);\n\tv206 = this.handles;\n\tv138 = v206.refCount <= 0;\n\tif (v138) goto L_0072;\nL_006B:\n\treturn;\nL_0072:\n\tgoto L_007F;\n\tv224 = *([v220 @ X0_v12 (Il2CppClass<Obi.ObiMeshShapeTracker>)+E0]);\n\tv225 = v224 == 0;\n\tv226 = ~v225;\n\t// 118 ConditionalJump @b33, v226 @ TEMP_v20\n\tv229 = \"il2cpp_codegen_runtime_class_init\"(v220, v130, v131, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv227 = Obi.ObiMeshShapeTracker;\nL_007F:\n\tv211 = UnityEngine.MeshCollider::get_sharedMesh(v113);\n\tv191 = System.Collections.Generic.Dictionary`2<UnityEngine.Mesh, Obi.ObiMeshShapeTracker+MeshDataHandles>::Remove(v216.meshDataCache, v211);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 103 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Destroy()
		{
			base.Destroy();
			UnityEngine.Object obj;
			if ((object)collider == null)
			{
				obj = null;
			}
			else
			{
				MeshCollider meshCollider = collider as MeshCollider;
				obj = (((object)meshCollider == null) ? null : collider);
			}
			if (obj != null && handles != null)
			{
				handles.Unref();
				MeshDataHandles meshDataHandles = handles;
				if (meshDataHandles.RefCount <= 0)
				{
					Mesh sharedMesh = ((MeshCollider)obj).sharedMesh;
					bool flag = meshDataCache.Remove(sharedMesh);
				}
			}
		}

		[Token(Token = "0x60001FD")]
		[Address(RVA = "0xE479EC", Offset = "0xE479EC", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EDDA80]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2024768]) = v35;\nL_0014:\n\tv39 = new System.Collections.Generic.Dictionary`2<UnityEngine.Mesh, Obi.ObiMeshShapeTracker+MeshDataHandles>();\n\tSystem.Collections.Generic.Dictionary`2<UnityEngine.Mesh, Obi.ObiMeshShapeTracker+MeshDataHandles>::.ctor(v39);\n\tv47.meshDataCache = v39;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static ObiMeshShapeTracker()
		{
			Dictionary<Mesh, MeshDataHandles> dictionary = new Dictionary<Mesh, MeshDataHandles>();
			meshDataCache = dictionary;
		}
	}
}
