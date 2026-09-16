using System;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Token(Token = "0x200001E")]
	public class ObiEdgeShapeTracker2D : ObiShapeTracker
	{
		[Token(Token = "0x400006D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x60")]
		private int pointCount;

		[Token(Token = "0x400006E")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x64")]
		private GCHandle pointsHandle;

		[Token(Token = "0x400006F")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x68")]
		private GCHandle indicesHandle;

		[Token(Token = "0x4000070")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x6C")]
		private bool edgeDataHasChanged;

		[Token(Token = "0x60001EE")]
		[Address(RVA = "0xE416F8", Offset = "0xE416F8", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiShapeTracker::.ctor(this);\n\tthis.collider = collider;\n\tthis.adaptor.is2D = 1;\n\tv18 = Oni::CreateShape(5);\n\tthis.oniShape = v18;\n\tObi.ObiEdgeShapeTracker2D::UpdateEdgeData(this);\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiEdgeShapeTracker2D(EdgeCollider2D collider)
		{
			base.collider = collider;
			adaptor.is2D = true;
			IntPtr intPtr = Oni.CreateShape(Oni.ShapeType.EdgeMesh);
			oniShape = intPtr;
			UpdateEdgeData();
		}

		[Token(Token = "0x60001EF")]
		[Address(RVA = "0xE45A40", Offset = "0xE45A40", Length = "0x27C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv34 = *([1EEE158]);\n\tv35 = *([v34 @ X8_v35]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([202474E]) = v54;\nL_001B:\n\tv55 = this.collider;\n\tv56 = this.collider == 0;\n\tif (v56) goto L_FFFFFFFF;\n\tv70 = *([v55 @ X8_v3 (UnityEngine.Component)]) != UnityEngine.EdgeCollider2D;\n\tif (v70) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0039;\nL_0039:\n\tgoto L_0042;\n\tv104 = *([v100 @ X0_v2+E0]);\n\tv105 = v104 == 0;\n\tv106 = ~v105;\n\tgoto L_0042;\n\tv108 = \"il2cpp_codegen_runtime_class_init\"(v100, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0042:\n\tv114 = UnityEngine.Object::op_Inequality(v96, 0);\n\tv116 = v114 == 0;\n\tif (v116) goto L_0116;\n\tv189 = UnityEngine.EdgeCollider2D::get_pointCount(v96);\n\t// 80 NewArr v337 @ X0_v13 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), v189 @ X0_v11 (System.Int32)\n\tv340 = UnityEngine.EdgeCollider2D::get_edgeCount(v96);\n\tv343 = v340 << 1;\n\t// 90 NewArr v345 @ X0_v17 (System.Int32[]), typeof(System.Int32[]), v343 @ X1_v7 (System.Int32)\n\tv348 = UnityEngine.EdgeCollider2D::get_points(v96);\n\tv285 = UnityEngine.EdgeCollider2D::get_pointCount(v96);\n\tv224 = v285 < 1;\n\tif (v224) goto L_00BA;\nL_0076:\n\tv404 = v390 < v348.Length;\n\tv277 = ~v404;\n\tif (v277) goto L_0117;\n\tv210 = v390 << 3;\n\tv427 = v348 + v210;\n\tgoto L_0092;\n\tv471 = *([v426 @ X0_v39+E0]);\n\tv472 = v471 == 0;\n\tv473 = ~v472;\n\tif (v473) goto L_0092;\n\tv475 = \"il2cpp_codegen_runtime_class_init\"(v426, v237, v113, v39, v40, v41, v42, v43, v386, v385, v383, v47, v48, v49, v50, v51);\nL_0092:\n\t// 146 MakeStruct v195 @ AGGE45BA8_0_v6 (UnityEngine.Vector2), typeof(UnityEngine.Vector2), [v427 @ X8_v27+20], v348[v390 @ X26_v7 (System.Int32)].y (System.Single)\n\tv201 = UnityEngine.Vector2::op_Implicit(v195);\n\tv496 = v390 < v337.Length;\n\tv458 = ~v496;\n\tif (v458) goto L_0117;\n\tv376 = v390 * 0xC;\n\tv377 = v337 + v376;\n\t*([v377 @ X8_v30+20]) = v201;\n\tv337[v390 @ X26_v7 (System.Int32)].y = v201.y;\n\tv337[v390 @ X26_v7 (System.Int32)].z = v201.z;\n\tv390 = v390 + 1;\n\tv374 = UnityEngine.EdgeCollider2D::get_pointCount(v96);\n\tv354 = v390 < v374;\n\tif (v354) goto L_0076;\nL_00BA:\n\tv287 = UnityEngine.EdgeCollider2D::get_edgeCount(v96);\n\tv226 = v287 < 1;\n\tif (v226) goto L_00FB;\nL_00CC:\n\tv464 = v432 - 1;\n\tv489 = v464 < v345.Length;\n\tv459 = ~v489;\n\tif (v459) goto L_0117;\n\tv345[v464 @ X8_v21 (System.Int32)] = v434;\n\tv494 = v432 < v345.Length;\n\tv460 = ~v494;\n\tif (v460) goto L_0117;\n\tv434 = v434 + 1;\n\tv345[v432 @ X24_v8 (System.Int32)] = v434;\n\tv421 = UnityEngine.EdgeCollider2D::get_edgeCount(v96);\n\tv432 = v432 + 2;\n\tv407 = v434 < v421;\n\tif (v407) goto L_00CC;\nL_00FB:\n\tOni::UnpinMemory(this.pointsHandle);\n\tOni::UnpinMemory(this.indicesHandle);\n\tv492 = Oni::PinMemory(v337);\n\tthis.pointsHandle = v492;\n\tv170 = Oni::PinMemory(v345);\n\tthis.indicesHandle = v170;\n\tthis.edgeDataHasChanged = 1;\nL_0116:\n\treturn;\nL_0117:\n\tv466 = new System.IndexOutOfRangeException();\n\tthrow v466;\n\tthrow System.NullReferenceException;\n// 202 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateEdgeData()
		{
			//IL_012f: Expected O, but got I
			//IL_0149: Expected F4, but got I
			//IL_01bb: Expected O, but got I
			Component component = collider;
			UnityEngine.Object obj;
			if ((object)collider != null)
			{
				Component component2 = (((object)component.GetType() != typeof(EdgeCollider2D)) ? null : collider);
				obj = component2;
			}
			else
			{
				obj = null;
			}
			if (!(obj != null))
			{
				return;
			}
			int num = ((EdgeCollider2D)obj).pointCount;
			Vector3[] array = new Vector3[num];
			int edgeCount = ((EdgeCollider2D)obj).edgeCount;
			int num2 = edgeCount << 1;
			int[] array2 = new int[num2];
			Vector2[] points = ((EdgeCollider2D)obj).points;
			int num3 = ((EdgeCollider2D)obj).pointCount;
			if (num3 < 1)
			{
				goto IL_022d;
			}
			int num4 = 0;
			Vector2 vector = default(Vector2);
			while (num4 < points.Length)
			{
				int num5 = num4 << 3;
				object obj2 = (long)(IntPtr)points + (long)num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ X8_v27+20]");
				vector.x = 0f;
				vector.y = points[num4].y;
				Vector3 vector2 = vector;
				if (num4 >= array.Length)
				{
					break;
				}
				int num6 = num4 * 12;
				object obj3 = (long)(IntPtr)array + (long)num6;
				array[num4].y = vector2.y;
				array[num4].z = vector2.z;
				num4++;
				int num7 = ((EdgeCollider2D)obj).pointCount;
				if (num4 < num7)
				{
					continue;
				}
				goto IL_022d;
			}
			goto IL_0360;
			IL_0302:
			Oni.UnpinMemory(pointsHandle);
			Oni.UnpinMemory(indicesHandle);
			GCHandle gCHandle = Oni.PinMemory(array);
			pointsHandle = gCHandle;
			GCHandle gCHandle2 = Oni.PinMemory(array2);
			indicesHandle = gCHandle2;
			edgeDataHasChanged = true;
			return;
			IL_0360:
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_022d:
			int edgeCount2 = ((EdgeCollider2D)obj).edgeCount;
			if (edgeCount2 < 1)
			{
				goto IL_0302;
			}
			int num8 = 1;
			int num9 = 0;
			while (true)
			{
				int num10 = num8 - 1;
				if (num10 >= array2.Length)
				{
					break;
				}
				array2[num10] = num9;
				if (num8 >= array2.Length)
				{
					break;
				}
				num9 = (array2[num8] = num9 + 1);
				int edgeCount3 = ((EdgeCollider2D)obj).edgeCount;
				num8 += 2;
				if (num9 < edgeCount3)
				{
					continue;
				}
				goto IL_0302;
			}
			goto IL_0360;
		}

		[Token(Token = "0x60001F0")]
		[Address(RVA = "0xE45CBC", Offset = "0xE45CBC", Length = "0x164")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EEA7A8]);\n\tv27 = *([v26 @ X8_v16]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([202474F]) = v46;\nL_0017:\n\tv47 = this.collider;\n\tv48 = this.collider == 0;\n\tif (v48) goto L_FFFFFFFF;\n\tv62 = *([v47 @ X8_v3 (UnityEngine.Component)]) != UnityEngine.EdgeCollider2D;\n\tif (v62) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0035;\nL_0035:\n\tgoto L_003E;\n\tv96 = *([v92 @ X0_v2+E0]);\n\tv97 = v96 == 0;\n\tv98 = ~v97;\n\tgoto L_003E;\n\tv100 = \"il2cpp_codegen_runtime_class_init\"(v92, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_003E:\n\tv106 = UnityEngine.Object::op_Inequality(v88, 0);\n\tv108 = v106 == 0;\n\tif (v108) goto L_FFFFFFFF;\n\tv132 = UnityEngine.EdgeCollider2D::get_pointCount(v88);\n\tv112 = v132 != this.pointCount;\n\tif (v112) goto L_0058;\n\tv134 = ~this.edgeDataHasChanged;\n\tif (v134) goto L_FFFFFFFF;\nL_0058:\n\tv211 = UnityEngine.EdgeCollider2D::get_pointCount(v88);\n\tthis.pointCount = v211;\n\tv212 = this + 0x64;\n\tthis.edgeDataHasChanged = 0;\n\tv154 = this + 0x18;\n\tv214 = 0xF74EC4(v212, 0, 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv215 = this + 0x68;\n\tv217 = 0xF74EC4(v215, 0, 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv220 = UnityEngine.EdgeCollider2D::get_pointCount(v88);\n\tv223 = UnityEngine.EdgeCollider2D::get_edgeCount(v88);\n\tv146 = v223 << 1;\n\tv227 = 0x103BBD0(v154, v214, v217, v220, v146, 0, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tOni::UpdateShape(this.oniShape, v154);\n\tgoto L_0082;\nL_0082:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 90 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override bool UpdateIfNeeded()
		{
			//IL_00e9: Expected O, but got I
			//IL_011b: Expected O, but got I
			Component component = collider;
			UnityEngine.Object obj;
			if ((object)collider != null)
			{
				Component component2 = (((object)component.GetType() != typeof(EdgeCollider2D)) ? null : collider);
				obj = component2;
			}
			else
			{
				obj = null;
			}
			if (obj != null)
			{
				int num = ((EdgeCollider2D)obj).pointCount;
				if (num != pointCount || edgeDataHasChanged)
				{
					int num2 = ((EdgeCollider2D)obj).pointCount;
					pointCount = num2;
					object obj2 = (long)(IntPtr)this + 100L;
					edgeDataHasChanged = false;
					ref Oni.Shape reference = ref *(Oni.Shape*)((long)(IntPtr)this + 24L);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @F74EC4 (inside System.Runtime.InteropServices.GCHandle::GetTarget +0x38)");
					object obj3 = (long)(IntPtr)this + 104L;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @F74EC4 (inside System.Runtime.InteropServices.GCHandle::GetTarget +0x38)");
					int num3 = ((EdgeCollider2D)obj).pointCount;
					int edgeCount = ((EdgeCollider2D)obj).edgeCount;
					int num4 = edgeCount << 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @103BBD0 (inside Oni::GetProfilingInfo +0xDC0)");
					Oni.UpdateShape(OniShape, ref reference);
					return true;
				}
			}
			return false;
		}

		[Token(Token = "0x60001F1")]
		[Address(RVA = "0xE45E20", Offset = "0xE45E20", Length = "0x38")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiShapeTracker::Destroy(this);\n\tOni::UnpinMemory(this.pointsHandle);\n\tOni::UnpinMemory(this.indicesHandle);\n\treturn;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Destroy()
		{
			base.Destroy();
			Oni.UnpinMemory(pointsHandle);
			Oni.UnpinMemory(indicesHandle);
		}
	}
}
