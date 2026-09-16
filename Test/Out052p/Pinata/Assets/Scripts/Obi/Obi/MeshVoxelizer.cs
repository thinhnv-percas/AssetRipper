using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Token(Token = "0x200003B")]
	public class MeshVoxelizer
	{
		[Token(Token = "0x20000B0")]
		public enum Voxel
		{
			[Token(Token = "0x40002F2")]
			Inside = 0,
			[Token(Token = "0x40002F3")]
			Boundary = 1,
			[Token(Token = "0x40002F4")]
			Outside = 2
		}

		[Token(Token = "0x40000CF")]
		[FieldOffset(Offset = "0x10")]
		public Mesh input;

		[Token(Token = "0x40000D0")]
		[FieldOffset(Offset = "0x18")]
		public float voxelSize;

		[Token(Token = "0x40000D1")]
		[FieldOffset(Offset = "0x20")]
		public Voxel[,,] voxels;

		[Token(Token = "0x40000D2")]
		[FieldOffset(Offset = "0x28")]
		private Vector3Int origin;

		[Token(Token = "0x17000052")]
		public Vector3Int Origin
		{
			[Token(Token = "0x60002CB")]
			[Address(RVA = "0xE2F278", Offset = "0xE2F278", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.origin;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return origin;
			}
		}

		[Token(Token = "0x60002CC")]
		[Address(RVA = "0xE2F288", Offset = "0xE2F288", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.input = input;\n\tthis.voxelSize = voxelSize;\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MeshVoxelizer(Mesh input, float voxelSize)
		{
			this.input = input;
			this.voxelSize = voxelSize;
		}

		[Token(Token = "0x60002CD")]
		[Address(RVA = "0xE2F2C4", Offset = "0xE2F2C4", Length = "0x11C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv30 = &v31 @ stack_-10_v2;\n\tgoto L_0031;\n\tv46 = *([1F03B58]);\n\tv47 = *([v46 @ X8_v9]);\n\tv48 = \"il2cpp_codegen_initialize_method\"(v47, methodInfo, v50, v51, v52, v53, v54, v55, v1, v0, v2, v2, v3, v5, v56, v57);\n\tv61 = 0 | 1;\n\t*([2024689]) = v61;\nL_0031:\n\tgoto L_0038;\n\tv74 = *([v69 @ X0_v2+E0]);\n\tv75 = v74 == 0;\n\tv76 = ~v75;\n\tgoto L_0038;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v69, methodInfo, v50, v51, v52, v53, v54, v55, v1, v0, v2, v2, v3, v5, v56, v57);\nL_0038:\n\tv82 = UnityEngine.Vector3::get_zero();\n\tv94 = 0x100E128(&v103 @ stack_-78_v4 (UnityEngine.Vector3), 0, v50, v51, v52, v53, v54, v55, v1, v1.y, v1.z, v82, v82.y, v82.z, v56, v57);\n\tv101 = 0x100E858(&v103 @ stack_-78_v4 (UnityEngine.Vector3), 0, v50, v51, v52, v53, v54, v55, v2, v2.y, v2.z, v82, v82.y, v82.z, v56, v57);\n\treturnVal1 = 0x100E858(&v103 @ stack_-78_v4 (UnityEngine.Vector3), 0, v50, v51, v52, v53, v54, v55, *([v30 @ X29_v1+10]), *([v30 @ X29_v1+14]), *([v30 @ X29_v1+18]), v82, v82.y, v82.z, v56, v57);\n\t*([returnBuffer @ X8 (UnityEngine.Bounds)+10]) = 0;\n\treturnBuffer.m_Center = v103;\n\treturn returnVal1;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe Bounds GetTriangleBounds(Vector3 v1, Vector3 v2, Vector3 v3)
		{
			//IL_004c: Expected native int or pointer, but got O
			object obj2 = default(object);
			object obj = obj2;
			Vector3 zero = Vector3.zero;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @100E128 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x60)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @100E858 (inside UnityEngine.Bounds::op_Inequality +0x138)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @100E858 (inside UnityEngine.Bounds::op_Inequality +0x138)");
			_ = 0;
			Bounds bounds = default(Bounds);
			Vector3 center = default(Vector3);
			((Bounds*)(IntPtr)bounds)->m_Center = center;
			Bounds result = default(Bounds);
			return result;
		}

		[Token(Token = "0x60002CE")]
		[Address(RVA = "0xE2F3E0", Offset = "0xE2F3E0", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv34 = *([1EEDA28]);\n\tv35 = *([v34 @ X8_v9]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, point, v0, v2, v44, v45, v46, v47, v48);\n\tv51 = 0 | 1;\n\t*([202468A]) = v51;\nL_0024:\n\tgoto L_002A;\n\tv59 = *([v55 @ X0_v2+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tgoto L_002A;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v55, methodInfo, v38, v39, v40, v41, v42, v43, point, v0, v2, v44, v45, v46, v47, v48);\nL_002A:\n\tv66 = point / this.voxelSize;\n\tv68 = UnityEngine.Mathf::FloorToInt(v66);\n\tv72 = point.y / this.voxelSize;\n\tv73 = UnityEngine.Mathf::FloorToInt(v72);\n\tv77 = point.z / this.voxelSize;\n\tv78 = UnityEngine.Mathf::FloorToInt(v77);\n\tv81 = 0;\n\tv86 = 0x158B4E4(&v81 @ stack_-60_v1 (UnityEngine.Vector3Int), v68, v73, v78, 0, v41, v42, v43, v77, point.y, point.z, v44, v45, v46, v47, v48);\n\treturn 0;\n// 55 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private Vector3Int GetPointVoxel(Vector3 point)
		{
			Vector3 vector = default(Vector3);
			float f = vector.x / voxelSize;
			int num = Mathf.FloorToInt(f);
			float f2 = point.y / voxelSize;
			int num2 = Mathf.FloorToInt(f2);
			float f3 = point.z / voxelSize;
			int num3 = Mathf.FloorToInt(f3);
			Vector3Int vector3Int = default(Vector3Int);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4E4 (inside UnityEngine.Vector3::.cctor +0xE8)");
			return default(Vector3Int);
		}

		[Token(Token = "0x60002CF")]
		[Address(RVA = "0xE2F4CC", Offset = "0xE2F4CC", Length = "0x184")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv30 = *([1EBE820]);\n\tv31 = *([v30 @ X8_v16]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, coords, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([202468B]) = v48;\nL_0022:\n\tgoto L_0028;\n\tv57 = *([v53 @ X0_v2+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tgoto L_0028;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v53, coords, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_0028:\n\tv64 = methodInfo & 0xFFFFFFFF;\n\tv69 = UnityEngine.Vector3Int::op_Subtraction(coords, v64);\n\tthis = 0x158B4F0(&v69 @ X0_v5 (UnityEngine.Vector3Int), 0, this.origin, this.origin.m_Z, 0, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv75 = this & 0x80000000;\n\tv76 = v75 == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_FFFFFFFF;\n\tthis = 0x158B4F8(&v69 @ X0_v5 (UnityEngine.Vector3Int), 0, this.origin, this.origin.m_Z, 0, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv125 = this & 0x80000000;\n\tv126 = v125 == 0;\n\tv117 = ~v126;\n\tif (v117) goto L_FFFFFFFF;\n\tthis = 0x158B500(&v69 @ X0_v5 (UnityEngine.Vector3Int), 0, this.origin, this.origin.m_Z, 0, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv218 = this & 0x80000000;\n\tv219 = v218 == 0;\n\tv118 = ~v219;\n\tif (v118) goto L_FFFFFFFF;\n\tv222 = 0x158B4F0(&v69 @ X0_v5 (UnityEngine.Vector3Int), 0, this.origin, this.origin.m_Z, 0, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv224 = System.Array::GetLength(this.voxels, 0);\n\tv128 = v222 >= v224;\n\tif (v128) goto L_0093;\n\tv228 = 0x158B4F8(&v69 @ X0_v5 (UnityEngine.Vector3Int), 0, 0, this.origin.m_Z, 0, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv115 = System.Array::GetLength(this.voxels, 1);\n\tv83 = v228 >= v115;\n\tif (v83) goto L_FFFFFFFF;\n\tthis = 0x158B500(&v69 @ X0_v5 (UnityEngine.Vector3Int), 0, 0, this.origin.m_Z, 0, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv237 = System.Array::GetLength(this.voxels, 2);\n\tv150 = this - v237;\n\tv147 = v150 < 0;\n\tv141 = this ^ v237;\n\tv138 = this ^ v150;\n\tv135 = v141 & v138;\n\tv132 = v135 < 0;\n\tv239 = v147 == v132;\n\tv129 = ~v239;\n\tgoto L_0093;\nL_0093:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 100 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool VoxelExists(Vector3Int coords)
		{
			//IL_0018: Expected O, but got I8
			//IL_0048: Expected I4, but got I8
			//IL_008a: Expected I4, but got I8
			//IL_00cc: Expected I4, but got I8
			//IL_01af: Expected O, but got I
			IntPtr intPtr = default(IntPtr);
			Vector3Int vector3Int = (Vector3Int)((long)intPtr & 0xFFFFFFFFL);
			Vector3Int vector3Int2 = coords - vector3Int;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F0 (inside UnityEngine.Vector3::.cctor +0xF4)");
			bool result;
			if ((int)((long)(IntPtr)this & 0x80000000L) == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F8 (inside UnityEngine.Vector3::.cctor +0xFC)");
				if ((int)((long)(IntPtr)this & 0x80000000L) == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B500 (inside UnityEngine.Vector3::.cctor +0x104)");
					if ((int)((long)(IntPtr)this & 0x80000000L) == 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F0 (inside UnityEngine.Vector3::.cctor +0xF4)");
						int length = voxels.GetLength(0);
						int num = default(int);
						bool flag = num >= length;
						result = false;
						if (!flag)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F8 (inside UnityEngine.Vector3::.cctor +0xFC)");
							int length2 = voxels.GetLength(1);
							int num2 = default(int);
							if (num2 >= length2)
							{
								goto IL_0217;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B500 (inside UnityEngine.Vector3::.cctor +0x104)");
							int length3 = voxels.GetLength(2);
							object obj = (long)(IntPtr)this - (long)length3;
							bool flag2 = (long)(IntPtr)obj < 0L;
							int num3 = (int)((long)(IntPtr)this ^ (long)length3);
							int num4 = (int)((long)(IntPtr)this ^ (long)(IntPtr)obj);
							int num5 = num3 & num4;
							bool flag3 = num5 < 0;
							bool flag4 = flag2 == flag3;
							bool flag5 = !flag4;
							result = flag5;
						}
						goto IL_022a;
					}
				}
			}
			goto IL_0217;
			IL_0217:
			result = false;
			goto IL_022a;
			IL_022a:
			return result;
		}

		[Token(Token = "0x60002D0")]
		[Address(RVA = "0xE2F650", Offset = "0xE2F650", Length = "0x324")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv46 = &v47 @ stack_-10_v2;\n\tgoto L_0030;\n\tv64 = *([1EDD660]);\n\tv65 = *([v64 @ X8_v22]);\n\tv66 = \"il2cpp_codegen_initialize_method\"(v65, bounds, methodInfo, v68, v69, v70, v71, v72, v1, v0, v2, v2, v3, v5, v73, v74);\n\tv77 = 0 | 1;\n\t*([202468C]) = v77;\nL_0030:\n\tthis = 0x100E4C4(bounds, 0, methodInfo, v68, v69, v70, v71, v72, v1, v1.y, v1.z, v2, v2.y, v2.z, v73, v74);\n\tv83 = Obi.MeshVoxelizer::GetPointVoxel(this, v1);\n\tthis = 0x100E564(bounds, 0, methodInfo, v68, v69, v70, v71, v72, v1, v1.y, v1.z, v2, v2.y, v2.z, v73, v74);\n\tv91 = Obi.MeshVoxelizer::GetPointVoxel(this, v1);\n\tv96 = 0x158B4F0(&v83 @ X0_v5 (UnityEngine.Vector3Int), 0, methodInfo, v68, v69, v70, v71, v72, v1, v1.y, v1.z, v2, v2.y, v2.z, v73, v74);\n\tthis = 0x158B4F0(&v91 @ X0_v9 (UnityEngine.Vector3Int), 0, methodInfo, v68, v69, v70, v71, v72, v1, v1.y, v1.z, v2, v2.y, v2.z, v73, v74);\n\tv112 = v96 > this;\n\tif (v112) goto L_0157;\n\tv118 = this + 0x28;\nL_005B:\n\tthis = 0x158B4F8(&v83 @ X0_v5 (UnityEngine.Vector3Int), 0, methodInfo, v68, v69, v70, v71, v72, v198, v244, v242, v188, v240, v238, v73, v74);\n\tthis = 0x158B4F8(&v91 @ X0_v9 (UnityEngine.Vector3Int), 0, methodInfo, v68, v69, v70, v71, v72, v198, v244, v242, v188, v240, v238, v73, v74);\n\tv443 = this > this;\n\tif (v443) goto L_0133;\n\tv378 = v309 + 0.5f;\nL_0072:\n\tthis = 0x158B500(&v83 @ X0_v5 (UnityEngine.Vector3Int), 0, methodInfo, v68, v69, v70, v71, v72, v474, v503, v502, v470, v501, v500, v73, v74);\n\tthis = 0x158B500(&v91 @ X0_v9 (UnityEngine.Vector3Int), 0, methodInfo, v68, v69, v70, v71, v72, v474, v503, v502, v470, v501, v500, v73, v74);\n\tv572 = this > this;\n\tif (v572) goto L_0122;\n\tv374 = v382 + 0.5f;\nL_0089:\n\tv653 = v376 + 0.5f;\n\tv319 = 0;\n\tthis = 0x1586898(&v319 @ stack_-D0_v7, 0, methodInfo, v68, v69, v70, v71, v72, v378, v374, v653, v632, v648, v647, v73, v74);\n\tgoto L_00A1;\n\tv667 = *([v662 @ X0_v34+E0]);\n\tv668 = v667 == 0;\n\tv669 = ~v668;\n\tgoto L_00A1;\n\tv671 = \"il2cpp_codegen_runtime_class_init\"(v662, v657, methodInfo, v68, v69, v70, v71, v72, v655, v656, v653, v632, v648, v647, v73, v74);\nL_00A1:\n\t// 161 MakeStruct v368 @ AGGE2F7E0_0_v7 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), 0, v676 @ stack_-CC, 0\n\tv680 = UnityEngine.Vector3::op_Multiply(v368, this.voxelSize);\n\tv684 = UnityEngine.Vector3::get_one();\n\tv689 = UnityEngine.Vector3::op_Multiply(v684, this.voxelSize);\n\tv356 = 0;\n\tthis = 0x100E128(&v356 @ stack_-E8_v7, 0, methodInfo, v68, v69, v70, v71, v72, v680, v680.y, v680.z, v689, v689.y, v689.z, v73, v74);\n\tv354 = 0;\n\tv704 = Obi.MeshVoxelizer::IsIntersecting(&v354 @ stack_-100_v7, v1, v2, *([v46 @ X29_v1+10]));\n\tv706 = v704 == 0;\n\tif (v706) goto L_0111;\n\tv340 = this.voxels;\n\tthis = 0x158B4F0(v118, 0, methodInfo, v68, v69, v70, v71, v72, v1, v1.y, v1.z, v2, v2.y, v2.z, v73, v74);\n\tthis = 0x158B4F8(v118, 0, methodInfo, v68, v69, v70, v71, v72, v1, v1.y, v1.z, v2, v2.y, v2.z, v73, v74);\n\tthis = 0x158B500(v118, 0, methodInfo, v68, v69, v70, v71, v72, v1, v1.y, v1.z, v2, v2.y, v2.z, v73, v74);\n\tv745 = *([v340 @ X28_v9 (Voxel[3])+10]);\n\tv746 = v309 - this;\n\tv748 = v746 < *([v745 @ X9_v9]);\n\tv749 = ~v748;\n\tif (v749) goto L_0158;\n\tv774 = v382 - this;\n\tv775 = v774 < *([v745 @ X9_v9+10]);\n\tv776 = ~v775;\n\tif (v776) goto L_0158;\n\tv785 = v376 - this;\n\tv786 = v785 < *([v745 @ X9_v9+20]);\n\tv730 = ~v786;\n\tif (v730) goto L_0158;\n\tv788 = *([v745 @ X9_v9+10]) * v746;\n\tv789 = v774 + v788;\n\tv735 = *([v745 @ X9_v9+20]) * v789;\n\tv790 = v785 + v735;\n\tv710 = v790 << 2;\n\tv736 = v340 + v710;\n\t*([v736 @ X8_v18+20]) = 1;\nL_0111:\n\tv376 = v376 + 1;\n\tthis = 0x158B500(&v91 @ X0_v9 (UnityEngine.Vector3Int), 0, methodInfo, v68, v69, v70, v71, v72, v1, v1.y, v1.z, v2, v2.y, v2.z, v73, v74);\n\tv585 = v376 <= this;\n\tif (v585) goto L_0089;\nL_0122:\n\tv382 = v382 + 1;\n\tthis = 0x158B4F8(&v91 @ X0_v9 (UnityEngine.Vector3Int), 0, methodInfo, v68, v69, v70, v71, v72, v474, v503, v502, v470, v501, v500, v73, v74);\n\tv477 = v382 <= this;\n\tif (v477) goto L_0072;\nL_0133:\n\tv233 = v309 + 1;\n\tthis = 0x158B4F0(&v91 @ X0_v9 (UnityEngine.Vector3Int), 0, methodInfo, v68, v69, v70, v71, v72, v198, v244, v242, v188, v240, v238, v73, v74);\n\tv209 = v233 <= this;\n\tif (v209) goto L_005B;\nL_0157:\n\treturn;\nL_0158:\n\tv784 = new System.IndexOutOfRangeException();\n\tthrow v784;\n\tthrow System.NullReferenceException;\n// 266 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void AppendOverlappingVoxels(Bounds bounds, Vector3 v1, Vector3 v2, Vector3 v3)
		{
			//IL_0060: Expected O, but got I
			//IL_03f3: Expected O, but got F4
			//IL_0366: Expected O, but got I
			//IL_04eb: Expected O, but got I4
			//IL_014e: Expected F4, but got O
			//IL_0199: Expected O, but got I4
			//IL_01b1: Expected O, but got I4
			//IL_01ce: Expected O, but got I
			//IL_01ce: Expected O, but got Ref
			//IL_0446: Expected O, but got I
			//IL_0231: Expected O, but got I
			//IL_0279: Expected O, but got I
			//IL_02b5: Expected O, but got I
			//IL_033e: Expected I4, but got F4
			//IL_034c: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @100E4C4 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x3FC)");
			Vector3Int pointVoxel = GetPointVoxel(v1);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @100E564 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x49C)");
			Vector3Int pointVoxel2 = GetPointVoxel(v1);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F0 (inside UnityEngine.Vector3::.cctor +0xF4)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F0 (inside UnityEngine.Vector3::.cctor +0xF4)");
			Vector3 vector = default(Vector3);
			if (vector.x > (float)this)
			{
				return;
			}
			object obj3 = (long)(IntPtr)this + 40L;
			Vector3 vector2 = v2;
			Vector3 vector3 = v1;
			Vector3 vector4 = vector;
			float num = v2.z;
			float num2 = v2.y;
			float num3 = v1.z;
			float y = v1.y;
			Vector3 vector8 = default(Vector3);
			object obj7 = default(object);
			bool flag3;
			do
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F8 (inside UnityEngine.Vector3::.cctor +0xFC)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F8 (inside UnityEngine.Vector3::.cctor +0xFC)");
				if (System.Runtime.CompilerServices.Unsafe.As<MeshVoxelizer, UIntPtr>(ref this) <= System.Runtime.CompilerServices.Unsafe.As<MeshVoxelizer, UIntPtr>(ref this))
				{
					float num4 = vector4.x + 0.5f;
					Vector3 vector5 = vector2;
					Vector3 vector6 = vector4;
					object obj4 = this;
					float num5 = num;
					float num6 = num2;
					float num7 = num3;
					float num8 = 0.5f;
					bool flag2;
					do
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B500 (inside UnityEngine.Vector3::.cctor +0x104)");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B500 (inside UnityEngine.Vector3::.cctor +0x104)");
						if (System.Runtime.CompilerServices.Unsafe.As<MeshVoxelizer, UIntPtr>(ref this) <= System.Runtime.CompilerServices.Unsafe.As<MeshVoxelizer, UIntPtr>(ref this))
						{
							float num9 = (float)obj4 + 0.5f;
							Vector3 vector7 = vector5;
							object obj5 = this;
							float num10 = num5;
							float num11 = num6;
							bool flag;
							do
							{
								float num12 = (float)obj5 + 0.5f;
								object obj6 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
								vector8.x = 0f;
								vector8.y = (float)obj7;
								vector8.z = 0f;
								Vector3 vector9 = vector8 * voxelSize;
								Vector3 one = Vector3.one;
								Vector3 vector10 = one * voxelSize;
								object obj8 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @100E128 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x60)");
								object obj9 = 0;
								Vector3 v4 = v1;
								Vector3 v5 = v2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X29_v1+10]");
								if (IsIntersecting((Bounds)(&obj9), v4, v5, (Vector3)0))
								{
									Voxel[,,] array = voxels;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F0 (inside UnityEngine.Vector3::.cctor +0xF4)");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F8 (inside UnityEngine.Vector3::.cctor +0xFC)");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B500 (inside UnityEngine.Vector3::.cctor +0x104)");
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ X28_v9 (Voxel[3])+10]");
									object obj10 = 0;
									float num13 = vector4.x - (float)this;
									if (num13 < (float)obj10)
									{
										object obj11 = (long)(IntPtr)obj4 - (long)(IntPtr)this;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ X9_v9+10]");
										if ((long)(IntPtr)obj11 < 0L)
										{
											object obj12 = (long)(IntPtr)obj5 - (long)(IntPtr)this;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ X9_v9+20]");
											if ((long)(IntPtr)obj12 < 0L)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ X9_v9+10]");
												float num14 = 0f * num13;
												float num15 = (float)obj11 + num14;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v745 @ X9_v9+20]");
												float num16 = 0f * num15;
												float num17 = (float)obj12 + num16;
												int num18 = num17 << 2;
												object obj13 = (long)(IntPtr)array + (long)num18;
												_ = 1;
												goto IL_0437;
											}
										}
									}
									IndexOutOfRangeException ex = new IndexOutOfRangeException();
									throw ex;
								}
								goto IL_0437;
								IL_0437:
								obj5 = (long)(IntPtr)obj5 + 1L;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B500 (inside UnityEngine.Vector3::.cctor +0x104)");
								flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5) <= System.Runtime.CompilerServices.Unsafe.As<MeshVoxelizer, UIntPtr>(ref this);
								vector5 = v2;
								vector6 = v1;
								num5 = v2.z;
								num6 = v2.y;
								num7 = v1.z;
								num8 = v1.y;
								vector7 = v2;
								num10 = v2.z;
								num11 = v2.y;
							}
							while (flag);
						}
						obj4 = (long)(IntPtr)obj4 + 1L;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F8 (inside UnityEngine.Vector3::.cctor +0xFC)");
						flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) <= System.Runtime.CompilerServices.Unsafe.As<MeshVoxelizer, UIntPtr>(ref this);
						vector2 = vector5;
						vector3 = vector6;
						num = num5;
						num2 = num6;
						num3 = num7;
						y = num8;
					}
					while (flag2);
				}
				float num19 = vector4.x + float.Epsilon;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F0 (inside UnityEngine.Vector3::.cctor +0xF4)");
				flag3 = !(num19 > (float)this);
				vector4 = (Vector3)num19;
			}
			while (flag3);
		}

		[Token(Token = "0x60002D1")]
		[Address(RVA = "0xE30194", Offset = "0xE30194", Length = "0x604")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv41 = &v42 @ stack_-10_v2;\n\tgoto L_0027;\n\tv54 = *([1F016C0]);\n\tv55 = *([v54 @ X8_v56]);\n\tv56 = \"il2cpp_codegen_initialize_method\"(v55, methodInfo, v58, v59, v60, v61, v62, v63, scale, v0, v2, v64, v65, v66, v67, v68);\n\tv71 = 0 | 1;\n\t*([202468D]) = v71;\nL_0027:\n\t*([v41 @ X29_v1-98]) = 0;\n\t*([v41 @ X29_v1-A0]) = 0;\n\tgoto L_0041;\n\tv85 = *([v81 @ X0_v2+E0]);\n\tv86 = v85 == 0;\n\tv87 = ~v86;\n\tgoto L_0041;\n\tv89 = \"il2cpp_codegen_runtime_class_init\"(v81, methodInfo, v58, v59, v60, v61, v62, v63, scale, v0, v2, v64, v65, v66, v67, v68);\nL_0041:\n\tv97 = UnityEngine.Mathf::Max(0.001f, this.voxelSize);\n\tthis.voxelSize = v97;\n\tv841 = &v101 @ stack_-100;\n\tv103 = UnityEngine.Mesh::get_bounds(this.input);\n\tv101 = *([v841 @ X8_v26 (UnityEngine.Mesh)]);\n\tv397 = 0x100E4C4(&v101 @ stack_-100, 0, v58, v59, v60, v61, v62, v63, *([v841 @ X8_v26 (UnityEngine.Mesh)]), this.voxelSize, scale.z, v64, v65, v66, v67, v68);\n\tgoto L_006D;\n\tv561 = *([v399 @ X0_v11+E0]);\n\tv562 = v561 == 0;\n\tv563 = ~v562;\n\tif (v563) goto L_006D;\n\tv565 = \"il2cpp_codegen_runtime_class_init\"(v399, v396, v58, v59, v60, v61, v62, v63, v394, v94, v2, v64, v65, v66, v67, v68);\nL_006D:\n\t// 109 MakeStruct v305 @ AGGE302C8_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v841 @ X8_v26 (UnityEngine.Mesh)], this.voxelSize (System.Single), scale.z (System.Single)\n\tv359 = UnityEngine.Vector3::Scale(scale, v305);\n\tv573 = Obi.MeshVoxelizer::GetPointVoxel(this, v359);\n\tv282 = 0;\n\tv580 = 0x158B4E4(&v282 @ stack_-110_v2, 1, 1, 1, 0, v61, v62, v63, v359, v359.y, v359.z, *([v841 @ X8_v26 (UnityEngine.Mesh)]), this.voxelSize, scale.z, v67, v68);\n\tgoto L_008F;\n\tv587 = *([v583 @ X0_v18+E0]);\n\tv588 = v587 == 0;\n\tv589 = ~v588;\n\tif (v589) goto L_008F;\n\tv591 = \"il2cpp_codegen_runtime_class_init\"(v583, v576, v577, v578, v579, v61, v62, v63, v359, v390, v386, v320, v316, v312, v67, v68);\nL_008F:\n\tv594 = UnityEngine.Vector3Int::op_Subtraction(v573, 0);\n\tv382 = this + 0x28;\n\tthis.origin = v594;\n\tthis.origin.m_Z = 0;\n\tv841 = &v280 @ stack_-128;\n\tv598 = UnityEngine.Mesh::get_bounds(this.input);\n\tv280 = *([v841 @ X8_v26 (UnityEngine.Mesh)]);\n\tv603 = 0x100E564(&v280 @ stack_-128, 0, 0, 0, 0, v61, v62, v63, *([v841 @ X8_v26 (UnityEngine.Mesh)]), v359.y, v359.z, *([v841 @ X8_v26 (UnityEngine.Mesh)]), this.voxelSize, scale.z, v67, v68);\n\t// 175 MakeStruct v258 @ AGGE3038C_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v841 @ X8_v26 (UnityEngine.Mesh)], v359.y (System.Single), v359.z (System.Single)\n\tv360 = UnityEngine.Vector3::Scale(scale, v258);\n\tv609 = Obi.MeshVoxelizer::GetPointVoxel(this, v360);\n\tv246 = 0;\n\tv617 = 0x158B4E4(&v246 @ stack_-138_v2, 1, 1, 1, 0, v61, v62, v63, v360, v360.y, v360.z, *([v841 @ X8_v26 (UnityEngine.Mesh)]), v359.y, v359.z, v67, v68);\n\tv621 = UnityEngine.Vector3Int::op_Addition(v609, 0);\n\t*([v41 @ X29_v1-A0]) = v621;\n\t*([v41 @ X29_v1-98]) = 0;\n\tv622 = &v42 @ stack_-10_v2 - 0xA0;\n\tv624 = 0x158B4F0(v622, 0, 0, 0, 0, v61, v62, v63, v360, v360.y, v360.z, *([v841 @ X8_v26 (UnityEngine.Mesh)]), v359.y, v359.z, v67, v68);\n\tv628 = 0x158B4F0(v382, 0, 0, 0, 0, v61, v62, v63, v360, v360.y, v360.z, *([v841 @ X8_v26 (UnityEngine.Mesh)]), v359.y, v359.z, v67, v68);\n\tv630 = &v42 @ stack_-10_v2 - 0xA0;\n\tv632 = 0x158B4F8(v630, 0, 0, 0, 0, v61, v62, v63, v360, v360.y, v360.z, *([v841 @ X8_v26 (UnityEngine.Mesh)]), v359.y, v359.z, v67, v68);\n\tv636 = 0x158B4F8(v382, 0, 0, 0, 0, v61, v62, v63, v360, v360.y, v360.z, *([v841 @ X8_v26 (UnityEngine.Mesh)]), v359.y, v359.z, v67, v68);\n\tv638 = &v42 @ stack_-10_v2 - 0xA0;\n\tv640 = 0x158B500(v638, 0, 0, 0, 0, v61, v62, v63, v360, v360.y, v360.z, *([v841 @ X8_v26 (UnityEngine.Mesh)]), v359.y, v359.z, v67, v68);\n\tv643 = 0x158B500(v382, 0, 0, 0, 0, v61, v62, v63, v360, v360.y, v360.z, *([v841 @ X8_v26 (UnityEngine.Mesh)]), v359.y, v359.z, v67, v68);\n\tv841 = v624 + 1;\n\tv841 = v841 - v628;\n\tv657 = 0x8D821C(Voxel[3], &v841 @ X8_v26 (UnityEngine.Mesh), 0, 0, 0, v61, v62, v63, v360, v360.y, v360.z, *([v841 @ X8_v26 (UnityEngine.Mesh)]), v359.y, v359.z, v67, v68);\n\tthis.voxels = v657;\nL_00F6:\n\tv864 = System.Array::GetLength(v862, 0);\n\tv183 = v383 >= v864;\n\tif (v183) goto L_016B;\nL_0109:\n\tv880 = System.Array::GetLength(v878, 1);\n\tv716 = v788 >= v880;\n\tif (v716) goto L_0162;\nL_011C:\n\tv813 = System.Array::GetLength(v908, 2);\n\tv717 = v778 >= v813;\n\tif (v717) goto L_015C;\n\tv838 = this.voxels;\n\tv1054 = *([v838 @ X8_v49 (Voxel[3])+10]);\n\tv1084 = v383 < *([v1054 @ X10_v9]);\n\tv1041 = ~v1084;\n\tif (v1041) goto L_0268;\n\tv1087 = v788 < *([v1054 @ X10_v9+10]);\n\tv1042 = ~v1087;\n\tif (v1042) goto L_0268;\n\tv1094 = v778 < *([v1054 @ X10_v9+20]);\n\tv757 = ~v1094;\n\tif (v757) goto L_0268;\n\tv1104 = *([v1054 @ X10_v9+10]) * v383;\n\tv1105 = v788 + v1104;\n\tv1106 = *([v1054 @ X10_v9+20]) * v1105;\n\tv762 = v778 + v1106;\n\tv713 = v762 << 2;\n\tv841 = v838 + v713;\n\t*([v841 @ X8_v26 (UnityEngine.Mesh)+20]) = 0;\n\tv778 = v778 + 1;\n\tv1107 = this.voxels == 0;\n\tv824 = ~v1107;\n\tif (v824) goto L_011C;\n\tgoto L_026D;\nL_015C:\n\tv788 = v788 + 1;\n\tv989 = this.voxels == 0;\n\tv825 = ~v989;\n\tif (v825) goto L_0109;\n\tgoto L_026D;\nL_0162:\n\tv383 = v383 + 1;\n\tv883 = this.voxels == 0;\n\tv826 = ~v883;\n\tif (v826) goto L_00F6;\n\tgoto L_026D;\nL_016B:\n\tv817 = UnityEngine.Mesh::get_triangles(this.input);\n\tv841 = this.input;\n\tv818 = UnityEngine.Mesh::get_vertices(this.input);\n\tv842 = v817.Length;\n\tv896 = v817.Length < 1;\n\tif (v896) goto L_0252;\nL_0187:\n\tv775 = v783 - 2;\n\tv988 = v775 < v842;\n\tv758 = ~v988;\n\tif (v758) goto L_0268;\n\tv1086 = v817[v775 @ X24_v9 (System.Int32)] < v818.Length;\n\tv1043 = ~v1086;\n\tif (v1043) goto L_0268;\n\tv1089 = v817[v775 @ X24_v9 (System.Int32)] * 0xC;\n\tv841 = v818 + v1089;\n\tgoto L_01BC;\n\tv1095 = *([v1088 @ X0_v62+E0]);\n\tv1096 = v1095 == 0;\n\tv1097 = ~v1096;\n\tif (v1097) goto L_01BC;\n\tv1099 = \"il2cpp_codegen_runtime_class_init\"(v1088, v806, v296, v291, v288, v61, v62, v63, v808, v849, v847, v796, v794, v792, v67, v68);\nL_01BC:\n\t// 444 MakeStruct v935 @ AGGE30610_0_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v841 @ X8_v26 (UnityEngine.Mesh)+20], v818[v817[v783 @ X22_v10 (System.Int32)]].y (System.Single), v818[v817[v783 @ X22_v10 (System.Int32)]].z (System.Single)\n\tv1066 = UnityEngine.Vector3::Scale(v935, scale);\n\tv1055 = v775 + 1;\n\tv1108 = v1055 < v817.Length;\n\tv1044 = ~v1108;\n\tif (v1044) goto L_0268;\n\tv1109 = v783 - 1;\n\t*([v41 @ X29_v1-44]) = v1066.z;\n\tv1111 = v817[v1109 @ X8_v35 (System.Int32)] < v818.Length;\n\tv1045 = ~v1111;\n\tif (v1045) goto L_0268;\n\tv1072 = v817[v1109 @ X8_v35 (System.Int32)] * 0xC;\n\tv841 = v818 + v1072;\n\t// 488 MakeStruct v931 @ AGGE30664_0_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v841 @ X8_v26 (UnityEngine.Mesh)+20], v818[v817[v783 @ X22_v10 (System.Int32)]].y (System.Single), v818[v817[v783 @ X22_v10 (System.Int32)]].z (System.Single)\n\tv1067 = UnityEngine.Vector3::Scale(v931, scale);\n\tv950 = v1055 + 1;\n\tv1116 = v950 < v817.Length;\n\tv1046 = ~v1116;\n\tif (v1046) goto L_0268;\n\tv1118 = v817[v783 @ X22_v10 (System.Int32)] < v818.Length;\n\tv1047 = ~v1118;\n\tif (v1047) goto L_0268;\n\tv965 = v817[v783 @ X22_v10 (System.Int32)] * 0xC;\n\tv841 = v818 + v965;\n\t// 531 MakeStruct v927 @ AGGE306B4_0_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v841 @ X8_v26 (UnityEngine.Mesh)+20], v818[v817[v783 @ X22_v10 (System.Int32)]].y (System.Single), v818[v817[v783 @ X22_v10 (System.Int32)]].z (System.Single)\n\tv1127 = UnityEngine.Vector3::Scale(v927, scale);\n\t*([v41 @ X29_v1-48]) = v1127;\n\t// 550 MakeStruct v922 @ AGGE306EC_1_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v1066 @ V0_v15 (UnityEngine.Vector3), v1066.y (System.Single), [v41 @ X29_v1-44]\n\tv1140 = Obi.MeshVoxelizer::GetTriangleBounds(0, v922, v1067, v1127);\n\tv920 = v1140.m_Center;\n\t// 575 MakeStruct v912 @ AGGE3072C_2_v6 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v1066 @ V0_v15 (UnityEngine.Vector3), v1066.y (System.Single), [v41 @ X29_v1-44]\n\tObi.MeshVoxelizer::AppendOverlappingVoxels(this, &v920 @ stack_-E8_v7 (UnityEngine.Vector3), v912, v1067, *([v41 @ X29_v1-48]));\n\tv842 = v817.Length;\n\tv948 = v950 + 1;\n\tv783 = v783 + 3;\n\tv939 = v948 < v817.Length;\n\tif (v939) goto L_0187;\nL_0252:\n\tObi.MeshVoxelizer::FloodFill(this);\n\tr\n// ... truncated")]
		public unsafe void Voxelize(Vector3 scale)
		{
			//IL_0070: Expected F4, but got O
			//IL_00be: Expected O, but got I4
			//IL_00f4: Expected O, but got I
			//IL_014e: Expected F4, but got O
			//IL_019f: Expected O, but got I4
			//IL_01e3: Expected O, but got I
			//IL_020b: Expected O, but got I
			//IL_0233: Expected O, but got I
			//IL_025b: Expected O, but got I
			//IL_026a: Expected O, but got I
			//IL_02e8: Expected O, but got I
			//IL_056e: Expected O, but got I
			//IL_058b: Expected F4, but got I
			//IL_068c: Expected O, but got I
			//IL_06a4: Expected F4, but got I
			//IL_03d0: Expected O, but got I
			//IL_078d: Expected O, but got I
			//IL_07a5: Expected F4, but got I
			//IL_083d: Expected F4, but got I
			//IL_089f: Expected F4, but got I
			//IL_08bd: Expected O, but got I
			//IL_08bd: Expected O, but got Ref
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			_ = 0;
			float num = Mathf.Max(0.001f, voxelSize);
			voxelSize = num;
			object obj3 = default(object);
			Mesh mesh = (Mesh)obj3;
			Bounds bounds = input.bounds;
			obj3 = mesh;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @100E4C4 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x3FC)");
			Vector3 b = default(Vector3);
			b.x = (float)mesh;
			b.y = voxelSize;
			b.z = scale.z;
			Vector3 point = Vector3.Scale(scale, b);
			Vector3Int pointVoxel = GetPointVoxel(point);
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4E4 (inside UnityEngine.Vector3::.cctor +0xE8)");
			Vector3Int vector3Int = pointVoxel - default(Vector3Int);
			object obj5 = (long)(IntPtr)this + 40L;
			origin = vector3Int;
			origin.m_Z = 0;
			object obj6 = default(object);
			mesh = (Mesh)obj6;
			Bounds bounds2 = input.bounds;
			obj6 = mesh;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @100E564 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x49C)");
			Vector3 b2 = default(Vector3);
			b2.x = (float)mesh;
			b2.y = point.y;
			b2.z = point.z;
			Vector3 point2 = Vector3.Scale(scale, b2);
			Vector3Int pointVoxel2 = GetPointVoxel(point2);
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4E4 (inside UnityEngine.Vector3::.cctor +0xE8)");
			Vector3Int vector3Int2 = pointVoxel2 + default(Vector3Int);
			_ = 0;
			object obj8 = (long)(IntPtr)obj2 - 160L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F0 (inside UnityEngine.Vector3::.cctor +0xF4)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F0 (inside UnityEngine.Vector3::.cctor +0xF4)");
			object obj9 = (long)(IntPtr)obj2 - 160L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F8 (inside UnityEngine.Vector3::.cctor +0xFC)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F8 (inside UnityEngine.Vector3::.cctor +0xFC)");
			object obj10 = (long)(IntPtr)obj2 - 160L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B500 (inside UnityEngine.Vector3::.cctor +0x104)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B500 (inside UnityEngine.Vector3::.cctor +0x104)");
			object obj11 = default(object);
			mesh = (Mesh)((long)(IntPtr)obj11 + 1L);
			object obj12 = default(object);
			mesh = (Mesh)((long)(IntPtr)mesh - (long)(IntPtr)obj12);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8D821C");
			Voxel[,,] array = default(Voxel[,,]);
			voxels = array;
			Array array2 = array;
			int num2 = 0;
			Vector3 a = default(Vector3);
			Vector3 a2 = default(Vector3);
			Vector3 a3 = default(Vector3);
			Vector3 v3 = default(Vector3);
			Vector3 vector2 = default(Vector3);
			while (true)
			{
				int length = array2.GetLength(0);
				if (num2 < length)
				{
					int num3 = 0;
					Array array3 = voxels;
					while (true)
					{
						int length2 = array3.GetLength(1);
						if (num3 < length2)
						{
							int num4 = 0;
							Array array4 = voxels;
							while (true)
							{
								int length3 = array4.GetLength(2);
								if (num4 >= length3)
								{
									break;
								}
								Voxel[,,] array5 = voxels;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v838 @ X8_v49 (Voxel[3])+10]");
								object obj13 = 0;
								if ((long)num2 >= (long)(IntPtr)obj13)
								{
									goto end_IL_099f;
								}
								int num5 = num3;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1054 @ X10_v9+10]");
								if ((long)num5 >= 0L)
								{
									goto end_IL_099f;
								}
								int num6 = num4;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1054 @ X10_v9+20]");
								if ((long)num6 >= 0L)
								{
									goto end_IL_099f;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1054 @ X10_v9+10]");
								int num7 = (int)(0L * (long)num2);
								int num8 = num3 + num7;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1054 @ X10_v9+20]");
								int num9 = (int)(0L * (long)num8);
								int num10 = num4 + num9;
								int num11 = num10 << 2;
								mesh = (Mesh)((long)(IntPtr)array5 + (long)num11);
								_ = 0;
								num4++;
								bool flag = voxels == null;
								bool flag2 = !flag;
								array4 = voxels;
								if (flag2)
								{
									continue;
								}
								goto IL_0918;
							}
							num3++;
							bool flag3 = voxels == null;
							bool flag4 = !flag3;
							array3 = voxels;
							if (flag4)
							{
								continue;
							}
						}
						else
						{
							num2++;
							bool flag5 = voxels == null;
							bool flag6 = !flag5;
							array2 = voxels;
							if (flag6)
							{
								break;
							}
						}
						goto IL_0918;
						IL_0918:
						NullReferenceException ex = new NullReferenceException();
						throw new NullReferenceException();
					}
					continue;
				}
				int[] triangles = input.triangles;
				mesh = input;
				Vector3[] vertices = input.vertices;
				int num12 = triangles.Length;
				if (triangles.Length >= 1)
				{
					int num13 = 2;
					while (true)
					{
						int num14 = num13 - 2;
						if (num14 >= num12 || triangles[num14] >= vertices.Length)
						{
							break;
						}
						int num15 = triangles[num14] * 12;
						mesh = (Mesh)((long)(IntPtr)vertices + (long)num15);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v841 @ X8_v26 (UnityEngine.Mesh)+20]");
						a.x = 0f;
						a.y = vertices[triangles[num13]].y;
						a.z = vertices[triangles[num13]].z;
						Vector3 vector = Vector3.Scale(a, scale);
						int num16 = num14 + 1;
						if (num16 >= triangles.Length)
						{
							break;
						}
						int num17 = num13 - 1;
						_ = vector.z;
						if (triangles[num17] >= vertices.Length)
						{
							break;
						}
						int num18 = triangles[num17] * 12;
						mesh = (Mesh)((long)(IntPtr)vertices + (long)num18);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v841 @ X8_v26 (UnityEngine.Mesh)+20]");
						a2.x = 0f;
						a2.y = vertices[triangles[num13]].y;
						a2.z = vertices[triangles[num13]].z;
						Vector3 v = Vector3.Scale(a2, scale);
						int num19 = num16 + 1;
						if (num19 >= triangles.Length || triangles[num13] >= vertices.Length)
						{
							break;
						}
						int num20 = triangles[num13] * 12;
						mesh = (Mesh)((long)(IntPtr)vertices + (long)num20);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v841 @ X8_v26 (UnityEngine.Mesh)+20]");
						a3.x = 0f;
						a3.y = vertices[triangles[num13]].y;
						a3.z = vertices[triangles[num13]].z;
						Vector3 v2 = Vector3.Scale(a3, scale);
						v3.x = vector.x;
						v3.y = vector.y;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ X29_v1-44]");
						v3.z = 0f;
						Vector3 center = ((MeshVoxelizer)null).GetTriangleBounds(v3, v, v2).m_Center;
						vector2.x = vector.x;
						vector2.y = vector.y;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ X29_v1-44]");
						vector2.z = 0f;
						Vector3 v4 = vector2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ X29_v1-48]");
						AppendOverlappingVoxels((Bounds)(&center), v4, v, (Vector3)0);
						num12 = triangles.Length;
						int num21 = num19 + 1;
						num13 += 3;
						if (num21 < triangles.Length)
						{
							continue;
						}
						goto IL_0903;
					}
					break;
				}
				goto IL_0903;
				IL_0903:
				FloodFill();
				return;
				continue;
				end_IL_099f:
				break;
			}
			IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
			throw ex2;
		}

		[Token(Token = "0x60002D2")]
		[Address(RVA = "0xE30798", Offset = "0xE30798", Length = "0xA0C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv30 = *([1EA9250]);\n\tv31 = *([v30 @ X8_v92]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([202468E]) = v50;\nL_0020:\n\tv58 = new System.Collections.Generic.Queue`1<UnityEngine.Vector3Int>();\n\tSystem.Collections.Generic.Queue`1<UnityEngine.Vector3Int>::.ctor(v58);\n\tv64 = 0;\n\tv58 = 0x158B4E4(&v64 @ stack_-80_v1 (UnityEngine.Vector3Int), 0, 0, 0, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tSystem.Collections.Generic.Queue`1<UnityEngine.Vector3Int>::Enqueue(v58, 0);\n\tv484 = this.voxels;\n\tv502 = *([v484 @ X8_v8 (Voxel[3])+10]);\n\tv504 = *([v502 @ X9_v2]) == 0;\n\tif (v504) goto L_0439;\n\tv574 = *([v502 @ X9_v2+10]) == 0;\n\tif (v574) goto L_0439;\n\tv841 = *([v502 @ X9_v2+20]) == 0;\n\tif (v841) goto L_0439;\n\t*([v484 @ X8_v8 (Voxel[3])+20]) = 2;\n\tv876 = v58._size < 1;\n\tif (v876) goto L_0438;\n\tgoto L_00A9;\nL_0058:\n\tv58 = 0x158B4F0(&v916 @ X0_v16 (UnityEngine.Vector3Int), 0, v416, v901, v900, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv58 = 0x158B4F8(&v916 @ X0_v16 (UnityEngine.Vector3Int), 0, v416, v901, v900, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv58 = 0x158B500(&v916 @ X0_v16 (UnityEngine.Vector3Int), 0, v416, v901, v900, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv401 = v58 - 1;\n\tv58 = 0x158B4E4(&v150 @ stack_-70_v35 (UnityEngine.Vector3Int), v58, v58, v401, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv131 = this.voxels;\n\tv58 = 0x158B4F0(&v150 @ stack_-70_v35 (UnityEngine.Vector3Int), 0, v58, v401, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv58 = 0x158B4F8(&v150 @ stack_-70_v35 (UnityEngine.Vector3Int), 0, v58, v401, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv58 = 0x158B500(&v150 @ stack_-70_v35 (UnityEngine.Vector3Int), 0, v58, v401, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv818 = *([v131 @ X26_v13 (Voxel[3])+10]);\n\tv1345 = v58 < *([v818 @ X9_v15]);\n\tv785 = ~v1345;\n\tif (v785) goto L_0439;\n\tv1349 = v58 < *([v818 @ X9_v15+10]);\n\tv786 = ~v1349;\n\tif (v786) goto L_0439;\n\tv1350 = v58 < *([v818 @ X9_v15+20]);\n\tv787 = ~v1350;\n\tif (v787) goto L_0439;\n\tv1351 = *([v818 @ X9_v15+10]) * v58;\n\tv1352 = v58 + v1351;\n\tv1188 = *([v818 @ X9_v15+20]) * v1352;\n\tv1353 = v58 + v1188;\n\tv1171 = v1353 << 2;\n\tv1190 = v131 + v1171;\n\t*([v1190 @ X8_v36+20]) = 2;\n\tSystem.Collections.Generic.Queue`1<UnityEngine.Vector3Int>::Enqueue(v58, v150);\n\tgoto L_042B;\nL_00A9:\n\tv916 = System.Collections.Generic.Queue`1<UnityEngine.Vector3Int>::Dequeue(v58);\n\tv450 = 0x158B4F0(&v916 @ X0_v16 (UnityEngine.Vector3Int), 0, v416, v901, v900, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv920 = System.Array::GetLength(this.voxels, 0);\n\tv487 = v920 - 1;\n\tv202 = v450 >= v487;\n\tif (v202) goto L_0153;\n\tv133 = this.voxels;\n\tv58 = 0x158B4F0(&v916 @ X0_v16 (UnityEngine.Vector3Int), 0, 0, v901, v900, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv58 = 0x158B4F8(&v916 @ X0_v16 (UnityEngine.Vector3Int), 0, 0, v901, v900, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv58 = 0x158B500(&v916 @ X0_v16 (UnityEngine.Vector3Int), 0, 0, v901, v900, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv815 = *([v133 @ X26_v22 (Voxel[3])+10]);\n\tv844 = v58 + 1;\n\tv982 = v844 < *([v815 @ X10_v28]);\n\tv788 = ~v982;\n\tif (v788) goto L_0439;\n\tv987 = v58 < *([v815 @ X10_v28+10]);\n\tv789 = ~v987;\n\tif (v789) goto L_0439;\n\tv989 = v58 < *([v815 @ X10_v28+20]);\n\tv339 = ~v989;\n\tif (v339) goto L_0439;\n\tv1023 = *([v815 @ X10_v28+10]) * v844;\n\tv1024 = v58 + v1023;\n\tv1025 = *([v815 @ X10_v28+20]) * v1024;\n\tv1026 = v58 + v1025;\n\tv89 = v1026 << 2;\n\tv1027 = v133 + v89;\n\tv1028 = *([v1027 @ X8_v83+20]) == 0;\n\tv948 = ~v1028;\n\tif (v948) goto L_0153;\n\tv58 = 0x158B4F0(&v916 @ X0_v16 (UnityEngine.Vector3Int), 0, 0, v901, v900, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv58 = 0x158B4F8(&v916 @ X0_v16 (UnityEngine.Vector3Int), 0, 0, v901, v900, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv58 = 0x158B500(&v916 @ X0_v16 (UnityEngine.Vector3Int), 0, 0, v901, v900, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv1086 = v58 + 1;\n\tv58 = 0x158B4E4(&v150 @ stack_-70_v35 (UnityEngine.Vector3Int), v1086, v58, v58, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv134 = this.voxels;\n\tv58 = 0x158B4F0(&v150 @ stack_-70_v35 (UnityEngine.Vector3Int), 0, v58, v58, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv58 = 0x158B4F8(&v150 @ stack_-70_v35 (UnityEngine.Vector3Int), 0, v58, v58, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv58 = 0x158B500(&v150 @ stack_-70_v35 (UnityEngine.Vector3Int), 0, v58, v58, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv821 = *([v134 @ X26_v23 (Voxel[3])+10]);\n\tv1208 = v58 < *([v821 @ X9_v37]);\n\tv790 = ~v1208;\n\tif (v790) goto L_0439;\n\tv1219 = v58 < *([v821 @ X9_v37+10]);\n\tv791 = ~v1219;\n\tif (v791) goto L_0439;\n\tv1229 = v58 < *([v821 @ X9_v37+20]);\n\tv792 = ~v1229;\n\tif (v792) goto L_0439;\n\tv1242 = *([v821 @ X9_v37+10]) * v58;\n\tv1243 = v58 + v1242;\n\tv947 = *([v821 @ X9_v37+20]) * v1243;\n\tv1244 = v58 + v947;\n\tv925 = v1244 << 2;\n\tv949 = v134 + v925;\n\t*([v949 @ X8_v89+20]) = 2;\n\tSystem.Collections.Generic.Queue`1<UnityEngine.Vector3Int>::Enqueue(v58, v150);\nL_0153:\n\tv58 = 0x158B4F0(&v916 @ X0_v16 (UnityEngine.Vector3Int), 0, v421, v901, v900, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv203 = v58 < 1;\n\tif (v203) goto L_01F0;\n\tv135 = this.voxels;\n\tv58 = 0x158B4F0(&v916 @ X0_v16 (UnityEngine.Vector3Int), 0, v421, v901, v900, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv58 = 0x158B4F8(&v916 @ X0_v16 (UnityEngine.Vector3Int), 0, v421, v901, v900, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv58 = 0x158B500(&v916 @ X0_v16 (UnityEngine.Vector3Int), 0, v421, v901, v900, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv816 = *([v135 @ X26_v20 (Voxel[3])+10]);\n\tv847 = v58 - 1;\n\tv990 = v847 < *([v816 @ X10_v25]);\n\tv793 = ~v990;\n\tif (v793) goto L_0439;\n\tv1029 = v58 < *([v816 @ X10_v25+10]);\n\tv794 = ~v1029;\n\tif (v794) goto L_0439;\n\tv1038 = v58 < *([v816 @ X10_v25+20]);\n\tv341 = ~v1038;\n\tif (v341) goto L_0439;\n\tv1065 = *([v816 @ X10_v25+10]) * v847;\n\tv1066 = v58 + v1065;\n\tv1067 = *([v816 @ X10_v25+20]) * v1066;\n\tv1068 = v58 + v1067;\n\tv91 = v1068 << 2;\n\tv1069 = v135 + v91;\n\tv1070 = *([v1069 @ X8_v72+20]) == 0;\n\tv975 = ~v1070;\n\tif (v975) goto L_01F0;\n\tv58 = 0x158B4F0(&v916 @ X0_v16 (UnityEngine.Vector3Int), 0, v421, v901, v900, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv58 = 0x158B4F8(&v916 @ X0_v16 (UnityEngine.Vector3Int), 0, v421, v901, v900, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv58 = 0x158B500(&v916 @ X0_v16 (UnityEngine.Vector3Int), 0, v421, v901, v900, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv1142 = v58 - 1;\n\tv58 = 0x158B4E4(&v150 @ stack_-70_v35 (UnityEngine.Vector3Int), v1142, v58, v58, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv136 = this.voxels;\n\tv58 = 0x158B4F0(&v150 @ stack_-70_v35 (UnityEngine.Vector3Int), 0, v58, v58, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv58 = 0x158B4F8(&v150 @ stack_-70_v35 (UnityEngine.Vector3Int), 0, v58, v58, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv58 = 0x158B500(&v150 @ stack_-70_v35 (UnityEngine.Vector3Int), 0, v58, v58, 0, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv824 = *([v136 @ X26_v21 (Voxel[3])+10]);\n\tv1230 = v58 < *([v824 @ X9_v33]);\n\tv795 = ~v1230;\n\tif (v795) goto L_0439;\n\tv1245 = v58 < *([v824 @ X9_v33+10]);\n\tv796 = ~v1245;\n\tif (v796) goto L_0439;\n\tv1261 = v58 < *([v824 @ X9_v33+20]);\n\tv797 = ~v1261;\n\tif (v797) goto L_0439;\n\tv1272 = *([v824 @ X9_v33+10]) * v58;\n\tv1273 = v58 + v1272;\n\tv974 = *([v824 @ X9_v33+20]) * v1273;\n\tv1274 = v58 + v974;\n\tv962 = v1274 << 2;\n\tv977 = v136 + v962;\n\t*([v977 @ X8_v78+20]) = 2;\n\tSystem.Collections.Generic.Queue`1<UnityEngine.Vector3Int>::Enqueue(v58, v150);\nL_01F0:\n\tv455 = 0x158B4F8(&v916 @ X0_v16 (UnityEngine.Vector3Int), 0, v421, v901, v900, v37, v38, v39, v4\n// ... truncated")]
		private void FloodFill()
		{
			//IL_003b: Expected O, but got I
			//IL_00d3: Expected O, but got I4
			//IL_032e: Expected O, but got I
			//IL_033d: Expected O, but got I
			//IL_066a: Expected O, but got I
			//IL_0679: Expected O, but got I
			//IL_09cf: Expected O, but got I
			//IL_0d0b: Expected O, but got I
			//IL_0a05: Expected O, but got I
			//IL_1070: Expected O, but got I
			//IL_0d41: Expected O, but got I
			//IL_03d8: Expected O, but got I
			//IL_03e7: Expected O, but got I
			//IL_03fd: Expected O, but got I
			//IL_040c: Expected O, but got I
			//IL_0429: Expected O, but got I
			//IL_13ac: Expected O, but got I
			//IL_0714: Expected O, but got I
			//IL_0723: Expected O, but got I
			//IL_0739: Expected O, but got I
			//IL_0748: Expected O, but got I
			//IL_0765: Expected O, but got I
			//IL_0a79: Expected O, but got I
			//IL_0a88: Expected O, but got I
			//IL_0a9e: Expected O, but got I
			//IL_0aad: Expected O, but got I
			//IL_0aca: Expected O, but got I
			//IL_0494: Expected O, but got I
			//IL_10d5: Expected O, but got I
			//IL_0db5: Expected O, but got I
			//IL_0dc4: Expected O, but got I
			//IL_0dda: Expected O, but got I
			//IL_0de9: Expected O, but got I
			//IL_0e06: Expected O, but got I
			//IL_07c7: Expected O, but got I
			//IL_1411: Expected O, but got I
			//IL_111a: Expected O, but got I
			//IL_1129: Expected O, but got I
			//IL_113f: Expected O, but got I
			//IL_114e: Expected O, but got I
			//IL_116b: Expected O, but got I
			//IL_0b35: Expected O, but got I
			//IL_04e5: Expected O, but got I
			//IL_1456: Expected O, but got I
			//IL_1465: Expected O, but got I
			//IL_147b: Expected O, but got I
			//IL_148a: Expected O, but got I
			//IL_14a7: Expected O, but got I
			//IL_0e68: Expected O, but got I
			//IL_0818: Expected O, but got I
			//IL_0119: Expected O, but got I
			//IL_11d6: Expected O, but got I
			//IL_0b86: Expected O, but got I
			//IL_0eb9: Expected O, but got I
			//IL_016a: Expected O, but got I
			//IL_1227: Expected O, but got I
			//IL_0580: Expected O, but got I
			//IL_058f: Expected O, but got I
			//IL_05a5: Expected O, but got I
			//IL_05b4: Expected O, but got I
			//IL_05d1: Expected O, but got I
			//IL_05ed: Expected O, but got I4
			//IL_08b3: Expected O, but got I
			//IL_08c2: Expected O, but got I
			//IL_08d8: Expected O, but got I
			//IL_08e7: Expected O, but got I
			//IL_0904: Expected O, but got I
			//IL_0920: Expected O, but got I4
			//IL_0c21: Expected O, but got I
			//IL_0c30: Expected O, but got I
			//IL_0c46: Expected O, but got I
			//IL_0c55: Expected O, but got I
			//IL_0c72: Expected O, but got I
			//IL_0c8e: Expected O, but got I4
			//IL_0f54: Expected O, but got I
			//IL_0f63: Expected O, but got I
			//IL_0f79: Expected O, but got I
			//IL_0f88: Expected O, but got I
			//IL_0fa5: Expected O, but got I
			//IL_0fc1: Expected O, but got I4
			//IL_0205: Expected O, but got I
			//IL_0214: Expected O, but got I
			//IL_022a: Expected O, but got I
			//IL_0239: Expected O, but got I
			//IL_0256: Expected O, but got I
			//IL_0272: Expected O, but got I4
			//IL_12c2: Expected O, but got I
			//IL_12d1: Expected O, but got I
			//IL_12e7: Expected O, but got I
			//IL_12f6: Expected O, but got I
			//IL_1313: Expected O, but got I
			//IL_132f: Expected O, but got I4
			Queue<Vector3Int> queue = new Queue<Vector3Int>();
			Vector3Int vector3Int = default(Vector3Int);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4E4 (inside UnityEngine.Vector3::.cctor +0xE8)");
			queue.Enqueue(default(Vector3Int));
			Voxel[,,] array = voxels;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v484 @ X8_v8 (Voxel[3])+10]");
			object obj = 0;
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v502 @ X9_v2+10]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v502 @ X9_v2+20]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						_ = 2;
						if (queue.Count < 1)
						{
							return;
						}
						object obj2 = 0;
						IntPtr intPtr = (IntPtr)0;
						int num = 0;
						int num3 = default(int);
						Vector3Int item = default(Vector3Int);
						int num10 = default(int);
						int num17 = default(int);
						while (true)
						{
							Vector3Int vector3Int2 = queue.Dequeue();
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F0 (inside UnityEngine.Vector3::.cctor +0xF4)");
							int length = voxels.GetLength(0);
							int num2 = length - 1;
							bool flag = num3 >= num2;
							int num4 = 0;
							if (!flag)
							{
								Voxel[,,] array2 = voxels;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F0 (inside UnityEngine.Vector3::.cctor +0xF4)");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F8 (inside UnityEngine.Vector3::.cctor +0xFC)");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B500 (inside UnityEngine.Vector3::.cctor +0x104)");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ X26_v22 (Voxel[3])+10]");
								object obj3 = 0;
								object obj4 = (long)(IntPtr)queue + 1L;
								if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3))
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v815 @ X10_v28+10]");
								if ((long)(IntPtr)queue >= 0L)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v815 @ X10_v28+20]");
								if ((long)(IntPtr)queue >= 0L)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v815 @ X10_v28+10]");
								object obj5 = 0L * (long)(IntPtr)obj4;
								object obj6 = (long)(IntPtr)queue + (long)(IntPtr)obj5;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v815 @ X10_v28+20]");
								object obj7 = 0L * (long)(IntPtr)obj6;
								object obj8 = (long)(IntPtr)queue + (long)(IntPtr)obj7;
								int num5 = (int)((long)(IntPtr)obj8 << 2);
								object obj9 = (long)(IntPtr)array2 + (long)num5;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1027 @ X8_v83+20]");
								bool flag2 = (IntPtr)0 == (IntPtr)0;
								bool flag3 = !flag2;
								num4 = 0;
								if (!flag3)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F0 (inside UnityEngine.Vector3::.cctor +0xF4)");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F8 (inside UnityEngine.Vector3::.cctor +0xFC)");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B500 (inside UnityEngine.Vector3::.cctor +0x104)");
									object obj10 = (long)(IntPtr)queue + 1L;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4E4 (inside UnityEngine.Vector3::.cctor +0xE8)");
									Voxel[,,] array3 = voxels;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F0 (inside UnityEngine.Vector3::.cctor +0xF4)");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F8 (inside UnityEngine.Vector3::.cctor +0xFC)");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B500 (inside UnityEngine.Vector3::.cctor +0x104)");
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v134 @ X26_v23 (Voxel[3])+10]");
									object obj11 = 0;
									if (System.Runtime.CompilerServices.Unsafe.As<Queue<Vector3Int>, UIntPtr>(ref queue) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj11))
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v821 @ X9_v37+10]");
									if ((long)(IntPtr)queue >= 0L)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v821 @ X9_v37+20]");
									if ((long)(IntPtr)queue >= 0L)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v821 @ X9_v37+10]");
									object obj12 = 0L * (long)(IntPtr)queue;
									object obj13 = (long)(IntPtr)queue + (long)(IntPtr)obj12;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v821 @ X9_v37+20]");
									object obj14 = 0L * (long)(IntPtr)obj13;
									object obj15 = (long)(IntPtr)queue + (long)(IntPtr)obj14;
									int num6 = (int)((long)(IntPtr)obj15 << 2);
									object obj16 = (long)(IntPtr)array3 + (long)num6;
									_ = 2;
									queue.Enqueue(item);
									obj2 = 0;
									intPtr = (IntPtr)0;
									num4 = 0;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F0 (inside UnityEngine.Vector3::.cctor +0xF4)");
							if ((long)(IntPtr)queue >= 1L)
							{
								Voxel[,,] array4 = voxels;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F0 (inside UnityEngine.Vector3::.cctor +0xF4)");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F8 (inside UnityEngine.Vector3::.cctor +0xFC)");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B500 (inside UnityEngine.Vector3::.cctor +0x104)");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ X26_v20 (Voxel[3])+10]");
								object obj17 = 0;
								object obj18 = (long)(IntPtr)queue - 1L;
								if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj18) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj17))
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v816 @ X10_v25+10]");
								if ((long)(IntPtr)queue >= 0L)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v816 @ X10_v25+20]");
								if ((long)(IntPtr)queue >= 0L)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v816 @ X10_v25+10]");
								object obj19 = 0L * (long)(IntPtr)obj18;
								object obj20 = (long)(IntPtr)queue + (long)(IntPtr)obj19;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v816 @ X10_v25+20]");
								object obj21 = 0L * (long)(IntPtr)obj20;
								object obj22 = (long)(IntPtr)queue + (long)(IntPtr)obj21;
								int num7 = (int)((long)(IntPtr)obj22 << 2);
								object obj23 = (long)(IntPtr)array4 + (long)num7;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1069 @ X8_v72+20]");
								if ((IntPtr)0 == (IntPtr)0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F0 (inside UnityEngine.Vector3::.cctor +0xF4)");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F8 (inside UnityEngine.Vector3::.cctor +0xFC)");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B500 (inside UnityEngine.Vector3::.cctor +0x104)");
									object obj24 = (long)(IntPtr)queue - 1L;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4E4 (inside UnityEngine.Vector3::.cctor +0xE8)");
									Voxel[,,] array5 = voxels;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F0 (inside UnityEngine.Vector3::.cctor +0xF4)");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F8 (inside UnityEngine.Vector3::.cctor +0xFC)");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B500 (inside UnityEngine.Vector3::.cctor +0x104)");
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ X26_v21 (Voxel[3])+10]");
									object obj25 = 0;
									if (System.Runtime.CompilerServices.Unsafe.As<Queue<Vector3Int>, UIntPtr>(ref queue) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj25))
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v824 @ X9_v33+10]");
									if ((long)(IntPtr)queue >= 0L)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v824 @ X9_v33+20]");
									if ((long)(IntPtr)queue >= 0L)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v824 @ X9_v33+10]");
									object obj26 = 0L * (long)(IntPtr)queue;
									object obj27 = (long)(IntPtr)queue + (long)(IntPtr)obj26;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v824 @ X9_v33+20]");
									object obj28 = 0L * (long)(IntPtr)obj27;
									object obj29 = (long)(IntPtr)queue + (long)(IntPtr)obj28;
									int num8 = (int)((long)(IntPtr)obj29 << 2);
									object obj30 = (long)(IntPtr)array5 + (long)num8;
									_ = 2;
									queue.Enqueue(item);
									obj2 = 0;
									intPtr = (IntPtr)0;
									num4 = 0;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F8 (inside UnityEngine.Vector3::.cctor +0xFC)");
							int length2 = voxels.GetLength(1);
							int num9 = length2 - 1;
							bool flag4 = num10 >= num9;
							int num11 = 0;
							if (!flag4)
							{
								Voxel[,,] array6 = voxels;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F0 (inside UnityEngine.Vector3::.cctor +0xF4)");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F8 (inside UnityEngine.Vector3::.cctor +0xFC)");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B500 (inside UnityEngine.Vector3::.cctor +0x104)");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v138 @ X26_v18 (Voxel[3])+10]");
								object obj31 = 0;
								if (System.Runtime.CompilerServices.Unsafe.As<Queue<Vector3Int>, UIntPtr>(ref queue) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj31))
								{
									break;
								}
								object obj32 = (long)(IntPtr)queue + 1L;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v850 @ X8_v58+10]");
								if ((long)(IntPtr)obj32 >= 0L)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v850 @ X8_v58+20]");
								if ((long)(IntPtr)queue >= 0L)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v850 @ X8_v58+10]");
								object obj33 = 0L * (long)(IntPtr)queue;
								object obj34 = (long)(IntPtr)obj32 + (long)(IntPtr)obj33;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v850 @ X8_v58+20]");
								object obj35 = 0L * (long)(IntPtr)obj34;
								object obj36 = (long)(IntPtr)queue + (long)(IntPtr)obj35;
								int num12 = (int)((long)(IntPtr)obj36 << 2);
								object obj37 = (long)(IntPtr)array6 + (long)num12;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1149 @ X8_v61+20]");
								bool flag5 = (IntPtr)0 == (IntPtr)0;
								bool flag6 = !flag5;
								num11 = 0;
								if (!flag6)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F0 (inside UnityEngine.Vector3::.cctor +0xF4)");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F8 (inside UnityEngine.Vector3::.cctor +0xFC)");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B500 (inside UnityEngine.Vector3::.cctor +0x104)");
									object obj38 = (long)(IntPtr)queue + 1L;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4E4 (inside UnityEngine.Vector3::.cctor +0xE8)");
									Voxel[,,] array7 = voxels;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F0 (inside UnityEngine.Vector3::.cctor +0xF4)");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F8 (inside UnityEngine.Vector3::.cctor +0xFC)");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B500 (inside UnityEngine.Vector3::.cctor +0x104)");
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ X26_v19 (Voxel[3])+10]");
									object obj39 = 0;
									if (System.Runtime.CompilerServices.Unsafe.As<Queue<Vector3Int>, UIntPtr>(ref queue) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj39))
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v828 @ X9_v29+10]");
									if ((long)(IntPtr)queue >= 0L)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v828 @ X9_v29+20]");
									if ((long)(IntPtr)queue >= 0L)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v828 @ X9_v29+10]");
									object obj40 = 0L * (long)(IntPtr)queue;
									object obj41 = (long)(IntPtr)queue + (long)(IntPtr)obj40;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v828 @ X9_v29+20]");
									object obj42 = 0L * (long)(IntPtr)obj41;
									object obj43 = (long)(IntPtr)queue + (long)(IntPtr)obj42;
									int num13 = (int)((long)(IntPtr)obj43 << 2);
									object obj44 = (long)(IntPtr)array7 + (long)num13;
									_ = 2;
									queue.Enqueue(item);
									obj2 = 0;
									intPtr = (IntPtr)0;
									num11 = 0;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F8 (inside UnityEngine.Vector3::.cctor +0xFC)");
							if ((long)(IntPtr)queue >= 1L)
							{
								Voxel[,,] array8 = voxels;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F0 (inside UnityEngine.Vector3::.cctor +0xF4)");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F8 (inside UnityEngine.Vector3::.cctor +0xFC)");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B500 (inside UnityEngine.Vector3::.cctor +0x104)");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ X26_v16 (Voxel[3])+10]");
								object obj45 = 0;
								if (System.Runtime.CompilerServices.Unsafe.As<Queue<Vector3Int>, UIntPtr>(ref queue) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj45))
								{
									break;
								}
								object obj46 = (long)(IntPtr)queue - 1L;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v854 @ X8_v48+10]");
								if ((long)(IntPtr)obj46 >= 0L)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v854 @ X8_v48+20]");
								if ((long)(IntPtr)queue >= 0L)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v854 @ X8_v48+10]");
								object obj47 = 0L * (long)(IntPtr)queue;
								object obj48 = (long)(IntPtr)obj46 + (long)(IntPtr)obj47;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v854 @ X8_v48+20]");
								object obj49 = 0L * (long)(IntPtr)obj48;
								object obj50 = (long)(IntPtr)queue + (long)(IntPtr)obj49;
								int num14 = (int)((long)(IntPtr)obj50 << 2);
								object obj51 = (long)(IntPtr)array8 + (long)num14;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1203 @ X8_v51+20]");
								if ((IntPtr)0 == (IntPtr)0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F0 (inside UnityEngine.Vector3::.cctor +0xF4)");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F8 (inside UnityEngine.Vector3::.cctor +0xFC)");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B500 (inside UnityEngine.Vector3::.cctor +0x104)");
									object obj52 = (long)(IntPtr)queue - 1L;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4E4 (inside UnityEngine.Vector3::.cctor +0xE8)");
									Voxel[,,] array9 = voxels;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F0 (inside UnityEngine.Vector3::.cctor +0xF4)");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F8 (inside UnityEngine.Vector3::.cctor +0xFC)");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B500 (inside UnityEngine.Vector3::.cctor +0x104)");
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ X26_v17 (Voxel[3])+10]");
									object obj53 = 0;
									if (System.Runtime.CompilerServices.Unsafe.As<Queue<Vector3Int>, UIntPtr>(ref queue) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj53))
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ X9_v24+10]");
									if ((long)(IntPtr)queue >= 0L)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ X9_v24+20]");
									if ((long)(IntPtr)queue >= 0L)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ X9_v24+10]");
									object obj54 = 0L * (long)(IntPtr)queue;
									object obj55 = (long)(IntPtr)queue + (long)(IntPtr)obj54;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v832 @ X9_v24+20]");
									object obj56 = 0L * (long)(IntPtr)obj55;
									object obj57 = (long)(IntPtr)queue + (long)(IntPtr)obj56;
									int num15 = (int)((long)(IntPtr)obj57 << 2);
									object obj58 = (long)(IntPtr)array9 + (long)num15;
									_ = 2;
									queue.Enqueue(item);
									obj2 = 0;
									intPtr = (IntPtr)0;
									num11 = 0;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B500 (inside UnityEngine.Vector3::.cctor +0x104)");
							int length3 = voxels.GetLength(2);
							int num16 = length3 - 1;
							bool flag7 = num17 >= num16;
							num = 0;
							if (!flag7)
							{
								Voxel[,,] array10 = voxels;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F0 (inside UnityEngine.Vector3::.cctor +0xF4)");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F8 (inside UnityEngine.Vector3::.cctor +0xFC)");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B500 (inside UnityEngine.Vector3::.cctor +0x104)");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ X26_v14 (Voxel[3])+10]");
								object obj59 = 0;
								if (System.Runtime.CompilerServices.Unsafe.As<Queue<Vector3Int>, UIntPtr>(ref queue) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj59))
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v834 @ X9_v17+10]");
								if ((long)(IntPtr)queue >= 0L)
								{
									break;
								}
								object obj60 = (long)(IntPtr)queue + 1L;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v834 @ X9_v17+20]");
								if ((long)(IntPtr)obj60 >= 0L)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v834 @ X9_v17+10]");
								object obj61 = 0L * (long)(IntPtr)queue;
								object obj62 = (long)(IntPtr)queue + (long)(IntPtr)obj61;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v834 @ X9_v17+20]");
								object obj63 = 0L * (long)(IntPtr)obj62;
								object obj64 = (long)(IntPtr)obj60 + (long)(IntPtr)obj63;
								int num18 = (int)((long)(IntPtr)obj64 << 2);
								object obj65 = (long)(IntPtr)array10 + (long)num18;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1258 @ X8_v41+20]");
								bool flag8 = (IntPtr)0 == (IntPtr)0;
								bool flag9 = !flag8;
								num = 0;
								if (!flag9)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F0 (inside UnityEngine.Vector3::.cctor +0xF4)");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F8 (inside UnityEngine.Vector3::.cctor +0xFC)");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B500 (inside UnityEngine.Vector3::.cctor +0x104)");
									object obj66 = (long)(IntPtr)queue + 1L;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4E4 (inside UnityEngine.Vector3::.cctor +0xE8)");
									Voxel[,,] array11 = voxels;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F0 (inside UnityEngine.Vector3::.cctor +0xF4)");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F8 (inside UnityEngine.Vector3::.cctor +0xFC)");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B500 (inside UnityEngine.Vector3::.cctor +0x104)");
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v144 @ X26_v15 (Voxel[3])+10]");
									object obj67 = 0;
									if (System.Runtime.CompilerServices.Unsafe.As<Queue<Vector3Int>, UIntPtr>(ref queue) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj67))
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v835 @ X9_v19+10]");
									if ((long)(IntPtr)queue >= 0L)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v835 @ X9_v19+20]");
									if ((long)(IntPtr)queue >= 0L)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v835 @ X9_v19+10]");
									object obj68 = 0L * (long)(IntPtr)queue;
									object obj69 = (long)(IntPtr)queue + (long)(IntPtr)obj68;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v835 @ X9_v19+20]");
									object obj70 = 0L * (long)(IntPtr)obj69;
									object obj71 = (long)(IntPtr)queue + (long)(IntPtr)obj70;
									int num19 = (int)((long)(IntPtr)obj71 << 2);
									object obj72 = (long)(IntPtr)array11 + (long)num19;
									_ = 2;
									queue.Enqueue(item);
									obj2 = 0;
									intPtr = (IntPtr)0;
									num = 0;
								}
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B500 (inside UnityEngine.Vector3::.cctor +0x104)");
							if ((long)(IntPtr)queue >= 1L)
							{
								Voxel[,,] array12 = voxels;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F0 (inside UnityEngine.Vector3::.cctor +0xF4)");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F8 (inside UnityEngine.Vector3::.cctor +0xFC)");
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B500 (inside UnityEngine.Vector3::.cctor +0x104)");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v145 @ X26_v12 (Voxel[3])+10]");
								object obj73 = 0;
								if (System.Runtime.CompilerServices.Unsafe.As<Queue<Vector3Int>, UIntPtr>(ref queue) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj73))
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v837 @ X9_v13+10]");
								if ((long)(IntPtr)queue >= 0L)
								{
									break;
								}
								object obj74 = (long)(IntPtr)queue - 1L;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v837 @ X9_v13+20]");
								if ((long)(IntPtr)obj74 >= 0L)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v837 @ X9_v13+10]");
								object obj75 = 0L * (long)(IntPtr)queue;
								object obj76 = (long)(IntPtr)queue + (long)(IntPtr)obj75;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v837 @ X9_v13+20]");
								object obj77 = 0L * (long)(IntPtr)obj76;
								object obj78 = (long)(IntPtr)obj74 + (long)(IntPtr)obj77;
								int num20 = (int)((long)(IntPtr)obj78 << 2);
								object obj79 = (long)(IntPtr)array12 + (long)num20;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1287 @ X8_v30+20]");
								if ((IntPtr)0 == (IntPtr)0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F0 (inside UnityEngine.Vector3::.cctor +0xF4)");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F8 (inside UnityEngine.Vector3::.cctor +0xFC)");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B500 (inside UnityEngine.Vector3::.cctor +0x104)");
									object obj80 = (long)(IntPtr)queue - 1L;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4E4 (inside UnityEngine.Vector3::.cctor +0xE8)");
									Voxel[,,] array13 = voxels;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F0 (inside UnityEngine.Vector3::.cctor +0xF4)");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B4F8 (inside UnityEngine.Vector3::.cctor +0xFC)");
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @158B500 (inside UnityEngine.Vector3::.cctor +0x104)");
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ X26_v13 (Voxel[3])+10]");
									object obj81 = 0;
									if (System.Runtime.CompilerServices.Unsafe.As<Queue<Vector3Int>, UIntPtr>(ref queue) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj81))
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v818 @ X9_v15+10]");
									if ((long)(IntPtr)queue >= 0L)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v818 @ X9_v15+20]");
									if ((long)(IntPtr)queue >= 0L)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v818 @ X9_v15+10]");
									object obj82 = 0L * (long)(IntPtr)queue;
									object obj83 = (long)(IntPtr)queue + (long)(IntPtr)obj82;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v818 @ X9_v15+20]");
									object obj84 = 0L * (long)(IntPtr)obj83;
									object obj85 = (long)(IntPtr)queue + (long)(IntPtr)obj84;
									int num21 = (int)((long)(IntPtr)obj85 << 2);
									object obj86 = (long)(IntPtr)array13 + (long)num21;
									_ = 2;
									queue.Enqueue(item);
									obj2 = 0;
									intPtr = (IntPtr)0;
									num = 0;
								}
							}
							if (queue.Count < 1)
							{
								return;
							}
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x60002D3")]
		[Address(RVA = "0xE2F974", Offset = "0xE2F974", Length = "0x820")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv46 = &v47 @ stack_-10_v2;\n\tgoto L_002D;\n\tv62 = *([1EF5308]);\n\tv63 = *([v62 @ X8_v56]);\n\tv64 = \"il2cpp_codegen_initialize_method\"(v63, methodInfo, v66, v67, v68, v69, v70, v71, v1, v0, v2, v2, v3, v5, v72, v73);\n\tv76 = 0 | 1;\n\t*([202468F]) = v76;\nL_002D:\n\t*([v46 @ X29_v1-98]) = 0;\n\t// 55 NewArr v86 @ X0_v3 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), 3\n\tv90 = v86.Length == 0;\n\tif (v90) goto L_0102;\n\tv315 = v86.Length == 1;\n\t*([v86 @ X0_v3 (UnityEngine.Vector3[])+20]) = v1;\n\t*([v86 @ X0_v3 (UnityEngine.Vector3[])+24]) = v1.y;\n\t*([v86 @ X0_v3 (UnityEngine.Vector3[])+28]) = v1.z;\n\tif (v315) goto L_0102;\n\tv844 = v86.Length < 2;\n\tv718 = ~v844;\n\tv700 = v86.Length - 2;\n\tv664 = v700 == 0;\n\t*([v86 @ X0_v3 (UnityEngine.Vector3[])+2C]) = v2;\n\t*([v86 @ X0_v3 (UnityEngine.Vector3[])+30]) = v2.y;\n\t*([v86 @ X0_v3 (UnityEngine.Vector3[])+34]) = v2.z;\n\tv845 = ~v718;\n\tv575 = v845 | v664;\n\tif (v575) goto L_0102;\n\t*([v86 @ X0_v3 (UnityEngine.Vector3[])+38]) = *([v46 @ X29_v1+10]);\n\t*([v86 @ X0_v3 (UnityEngine.Vector3[])+3C]) = *([v46 @ X29_v1+14]);\n\t*([v86 @ X0_v3 (UnityEngine.Vector3[])+40]) = *([v46 @ X29_v1+18]);\n\t// 99 NewArr v1026 @ X0_v97 (UnityEngine.Vector3[]), typeof(UnityEngine.Vector3[]), 3\n\tv511 = 0;\n\tv736 = 0x1586898(&v511 @ stack_-E0_v8, 0, v66, v67, v68, v69, v70, v71, 1f, 0, 0, v2, v2.y, v2.z, v72, v73);\n\tv753 = v1026.Length == 0;\n\tif (v753) goto L_0102;\n\t*([v1026 @ X0_v97 (UnityEngine.Vector3[])+20]) = 0;\n\t*([v1026 @ X0_v97 (UnityEngine.Vector3[])+28]) = 0;\n\tv490 = 0;\n\tv737 = 0x1586898(&v490 @ stack_-F0_v8, 0, v66, v67, v68, v69, v70, v71, 0, 1f, 0, v2, v2.y, v2.z, v72, v73);\n\tv1058 = v1026.Length < 1;\n\tv719 = ~v1058;\n\tv701 = v1026.Length - 1;\n\tv665 = v701 == 0;\n\tv1059 = ~v719;\n\tv576 = v1059 | v665;\n\tif (v576) goto L_0102;\n\t*([v1026 @ X0_v97 (UnityEngine.Vector3[])+2C]) = 0;\n\t*([v1026 @ X0_v97 (UnityEngine.Vector3[])+34]) = 0;\n\tv482 = 0;\n\tv738 = 0x1586898(&v482 @ stack_-100_v8, 0, v66, v67, v68, v69, v70, v71, 0, 0, 1f, v2, v2.y, v2.z, v72, v73);\n\tv1067 = v1026.Length < 2;\n\tv720 = ~v1067;\n\tv702 = v1026.Length - 2;\n\tv666 = v702 == 0;\n\tv1068 = ~v720;\n\tv577 = v1068 | v666;\n\tif (v577) goto L_0102;\n\tv791 = v1026.Length & 0xFFFFFFFF;\n\t*([v1026 @ X0_v97 (UnityEngine.Vector3[])+38]) = 0;\n\t*([v1026 @ X0_v97 (UnityEngine.Vector3[])+3C]) = v1072;\n\t*([v1026 @ X0_v97 (UnityEngine.Vector3[])+40]) = 0;\n\tv752 = v791 == 0;\n\tif (v752) goto L_0102;\n\tv1027 = v1026 + 0x28;\nL_00B3:\n\tv1102 = &v47 @ stack_-10_v2 - 0x98;\n\t// 182 MakeStruct v330 @ AGGE2FB3C_1_v8 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), [v1027 @ X24_v14-8], [v1027 @ X24_v14-4], [v1027 @ X24_v14]\n\tObi.MeshVoxelizer::Project(v86, v330, v1102, &v339 @ stack_-B0_v12 (System.Double));\n\tv1110 = 0x100E4C4(box, 0, &v339 @ stack_-B0_v12 (System.Double), v67, v68, v69, v70, v71, *([v1027 @ X24_v14-8]), *([v1027 @ X24_v14-4]), *([v1027 @ X24_v14]), v2, v2.y, v2.z, v72, v73);\n\tthrow System.TypeLoadException;\n\tv1130 = v339 < v1101;\n\tif (v1130) goto L_FFFFFFFF;\n\tv541 = *([v46 @ X29_v1-98]);\n\tv1141 = 0x100E564(box, 0, 0, v67, v68, v69, v70, v71, v1101, v828, v818, v2, v3, v5, v72, v73);\n\tv735 = new System.TypeLoadException();\n\tv1220 = v541 > v1101;\n\tif (v1220) goto L_FFFFFFFF;\n\tv1031 = v1029 > 1;\n\tif (v1031) goto L_0106;\n\tv787 = *([v1026 @ X0_v97 (UnityEngine.Vector3[])+18]);\n\tv464 = v1029 + 1;\n\tv460 = v1027 + 0xC;\n\tv1349 = v464 < v787;\n\tv717 = ~v1349;\n\tv574 = ~v717;\n\tif (v574) goto L_00B3;\nL_0102:\n\tv843 = new System.IndexOutOfRangeException();\n\tthrow v843;\nL_0106:\n\tv1044 = *([v352 @ X23_v8 (Il2CppClass<UnityEngine.Vector3[]>)]);\n\tv1046 = \"SzArrayNew\"(v1044, 8, v456, v67, v68, v69, v70, v71, v558, v832, v822, v414, v812, v806, v72, v73);\n\tv739 = 0x100E4C4(v758, 0, v456, v67, v68, v69, v70, v71, v558, v832, v822, v414, v812, v806, v72, v73);\n\tv792 = *([v1046 @ X0_v14 (System.Collections.Generic.IEnumerable`1<UnityEngine.Vector3>)+18]);\n\tv754 = v792 == 0;\n\tif (v754) goto L_0102;\n\t*([v1046 @ X0_v14 (System.Collections.Generic.IEnumerable`1<UnityEngine.Vector3>)+20]) = v558;\n\t*([v1046 @ X0_v14 (System.Collections.Generic.IEnumerable`1<UnityEngine.Vector3>)+24]) = v832;\n\t*([v1046 @ X0_v14 (System.Collections.Generic.IEnumerable`1<UnityEngine.Vector3>)+28]) = v822;\n\tv740 = 0x100E564(v758, 0, v456, v67, v68, v69, v70, v71, v558, v832, v822, v414, v812, v806, v72, v73);\n\tv793 = *([v1046 @ X0_v14 (System.Collections.Generic.IEnumerable`1<UnityEngine.Vector3>)+18]);\n\tv1060 = v793 < 1;\n\tv722 = ~v1060;\n\tv704 = v793 - 1;\n\tv668 = v704 == 0;\n\tv1061 = ~v722;\n\tv579 = v1061 | v668;\n\tif (v579) goto L_0102;\n\t*([v1046 @ X0_v14 (System.Collections.Generic.IEnumerable`1<UnityEngine.Vector3>)+2C]) = v558;\n\t*([v1046 @ X0_v14 (System.Collections.Generic.IEnumerable`1<UnityEngine.Vector3>)+30]) = v832;\n\t*([v1046 @ X0_v14 (System.Collections.Generic.IEnumerable`1<UnityEngine.Vector3>)+34]) = v822;\n\tv1066 = 0x100E4C4(v758, 0, v456, v67, v68, v69, v70, v71, v558, v832, v822, v414, v812, v806, v72, v73);\n\tv1071 = 0x100E4C4(v758, 0, v456, v67, v68, v69, v70, v71, v558, v832, v822, v414, v812, v806, v72, v73);\n\tv1075 = 0x100E564(v758, 0, v456, v67, v68, v69, v70, v71, v558, v832, v822, v414, v812, v806, v72, v73);\n\tv513 = 0;\n\tv741 = 0x1586898(&v513 @ stack_-E0_v6, 0, v456, v67, v68, v69, v70, v71, v558, v832, v822, v414, v812, v806, v72, v73);\n\tv794 = *([v1046 @ X0_v14 (System.Collections.Generic.IEnumerable`1<UnityEngine.Vector3>)+18]);\n\tv1105 = v794 < 2;\n\tv723 = ~v1105;\n\tv705 = v794 - 2;\n\tv669 = v705 == 0;\n\tv1106 = ~v723;\n\tv580 = v1106 | v669;\n\tif (v580) goto L_0102;\n\t*([v1046 @ X0_v14 (System.Collections.Generic.IEnumerable`1<UnityEngine.Vector3>)+38]) = 0;\n\t*([v1046 @ X0_v14 (System.Collections.Generic.IEnumerable`1<UnityEngine.Vector3>)+3C]) = v1112;\n\t*([v1046 @ X0_v14 (System.Collections.Generic.IEnumerable`1<UnityEngine.Vector3>)+40]) = 0;\n\tv1115 = 0x100E4C4(v758, 0, v456, v67, v68, v69, v70, v71, v558, v832, v822, v414, v812, v806, v72, v73);\n\tv1125 = 0x100E564(v758, 0, v456, v67, v68, v69, v70, v71, v558, v832, v822, v414, v812, v806, v72, v73);\n\tv1138 = 0x100E4C4(v758, 0, v456, v67, v68, v69, v70, v71, v558, v832, v822, v414, v812, v806, v72, v73);\n\tv492 = 0;\n\tv742 = 0x1586898(&v492 @ stack_-F0_v6, 0, v456, v67, v68, v69, v70, v71, v558, v832, v822, v414, v812, v806, v72, v73);\n\tv795 = *([v1046 @ X0_v14 (System.Collections.Generic.IEnumerable`1<UnityEngine.Vector3>)+18]);\n\tv1335 = v795 < 3;\n\tv724 = ~v1335;\n\tv706 = v795 - 3;\n\tv670 = v706 == 0;\n\tv1336 = ~v724;\n\tv581 = v1336 | v670;\n\tif (v581) goto L_0102;\n\t*([v1046 @ X0_v14 (System.Collections.Generic.IEnumerable`1<UnityEngine.Vector3>)+44]) = 0;\n\t*([v1046 @ X0_v14 (System.Collections.Generic.IEnumerable`1<UnityEngine.Vector3>)+48]) = v1340;\n\t*([v1046 @ X0_v14 (System.Collections.Generic.IEnumerable`1<UnityEngine.Vector3>)+4C]) = 0;\n\tv1343 = 0x100E564(v758, 0, v456, v67, v68, v69, v70, v71, v558, v832, v822, v414, v812, v806, v72, v73);\n\tv1348 = 0x100E4C4(v758, 0, v456, v67, v68, v69, v70, v71, v558, v832, v822, v414, v812, v806, v72, v73);\n\tv1352 = 0x100E4C4(v758, 0, v456, v67, v68, v69, v70, v71, v558, v832, v822, v414, v812, v806, v72, v73);\n\tv484 = 0;\n\tv743 = 0x1586898(&v484 @ stack_-100_v6, 0, v456, v67, v68, v69, v70, v71, v558, v832, v822, v414, v812, v806, v72, v73);\n\tv796 = *([v1046 @ X0_v14 (System.Collections.Generic.IEnumerable`1<UnityEngine.Vector3>)+18]);\n\tv1354 = v796 < 4;\n\tv725 = ~v1354;\n\tv707 = v796 - 4;\n\tv671 = v707 == 0;\n\tv1355 = ~v725;\n\tv582 = v1355 | v671;\n\tif (v582) goto L_0102;\n\t*([v1046 @ X0_v14 (System.Collections.Generic.IEnumerable`1<UnityEngine.Vector3>)+50]) = 0;\n\t*([v1046 @ X0_v14 (System.Collections.Generic.IEnumerable`1<UnityEngine.Vector3>)+54]) = v1072;\n\t*([v1046 @ X0_v14 (System.Collections.Generic.IEnumerable`1<UnityEngine.Vector3>)+58]) = 0;\n\tv1359 = 0x100E4C4(v758, 0, v456, v67, v68, v69, v70, v71, v558, v832, v822, v414, v812, v806, v72, v73);\n\tv1362 = 0x100E564(v758, 0, v456, v67, v68, v69, v70, v71, v558, v832, v822, v414, v812, v806, v72, v73);\n\tv1365 = 0x100E564(v758, 0, v456, v67, v68, v69, v70, v71, v558, v832, v822, v414, v812, v806, v72, v73);\n\tv433 = 0;\n\tv744 = 0x1586898(&v433 @ stack_-110_v6, 0, v456, v67, v68, v69, v70, v71, v558, v832, v8\n// ... truncated")]
		public unsafe static bool IsIntersecting(Bounds box, Vector3 v1, Vector3 v2, Vector3 v3)
		{
			//IL_0090: Expected O, but got I4
			//IL_011c: Expected O, but got I4
			//IL_015f: Expected O, but got I4
			//IL_0195: Expected O, but got I4
			//IL_01df: Expected O, but got I4
			//IL_0215: Expected O, but got I4
			//IL_025e: Expected I4, but got I8
			//IL_029b: Expected O, but got I
			//IL_02eb: Expected F4, but got I
			//IL_0300: Expected F4, but got I
			//IL_030d: Expected F4, but got O
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			Vector3[] array = new Vector3[3];
			if (array.Length != 0)
			{
				bool flag = array.Length == 1;
				_ = v1.y;
				_ = v1.z;
				if (!flag)
				{
					bool flag2 = array.Length < 2;
					bool flag3 = !flag2;
					object obj3 = array.Length - 2;
					bool flag4 = obj3 == null;
					_ = v2.y;
					_ = v2.z;
					bool flag5 = !flag3;
					if (!(flag5 || flag4))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X29_v1+10]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X29_v1+14]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X29_v1+18]");
						_ = 0;
						Vector3[] array2 = new Vector3[3];
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
						if (array2.Length != 0)
						{
							_ = 0;
							_ = 0;
							object obj5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
							bool flag6 = array2.Length < 1;
							bool flag7 = !flag6;
							object obj6 = array2.Length - 1;
							bool flag8 = obj6 == null;
							bool flag9 = !flag7;
							if (!(flag9 || flag8))
							{
								_ = 0;
								_ = 0;
								object obj7 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
								bool flag10 = array2.Length < 2;
								bool flag11 = !flag10;
								object obj8 = array2.Length - 2;
								bool flag12 = obj8 == null;
								bool flag13 = !flag11;
								if (!(flag13 || flag12))
								{
									int num = (int)(array2.Length & 0xFFFFFFFFL);
									_ = 0;
									_ = 0;
									if (num != 0)
									{
										object obj9 = (long)(IntPtr)array2 + 40L;
										ref double min = ref *(double*)((long)(IntPtr)obj2 - 152L);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1027 @ X24_v14-8]");
										Vector3 axis = default(Vector3);
										axis.x = 0f;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1027 @ X24_v14-4]");
										axis.y = 0f;
										axis.z = (float)obj9;
										Project(array, axis, out min, out var _);
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @100E4C4 (inside UnityEngine.BootConfigData::WrapBootConfigData +0x3FC)");
										throw new TypeLoadException();
									}
								}
							}
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x60002D4")]
		[Address(RVA = "0xE311A4", Offset = "0xE311A4", Length = "0x314")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv514 = v226.y;\n\tv513 = v226.z;\n\tgoto L_0026;\n\tv48 = *([1EADCD8]);\n\tv49 = *([v48 @ X8_v30]);\n\tv50 = \"il2cpp_codegen_initialize_method\"(v49, min, max, methodInfo, v52, v53, v54, v55, axis, v0, v2, v56, v57, v58, v59, v60);\n\tv63 = 0 | 1;\n\t*([2024690]) = v63;\nL_0026:\n\t*([v255 @ X1_v3 (System.Double&)]) = 0x7FF0000000000000;\n\t*([v233 @ X2_v3 (System.Double&)]) = 0xFFF0000000000000;\n\tgoto L_0057;\n\tv75 = *([v68 @ X8_v12+B0]);\n\tv76 = 0;\n\tv77 = v75 + 8;\n\tv79 = *([v169 @ X11_v28-8]);\n\tv175 = v79 == v71;\n\tif (v175) goto L_0050;\n\tv112 = v170 + 1;\n\tv180 = v112 < v70;\n\tv106 = ~v180;\n\tv109 = v169 + 0x10;\n\tv82 = ~v106;\n\tif (v82) goto L_FFFFFFFF;\n\tv113 = v42;\n\tv114 = 0;\n\tv115 = 0x8909C4(v113, v71, v114, methodInfo, v52, v53, v54, v55, axis, v0, v2, v56, v57, v58, v59, v60);\n\tgoto L_0057;\nL_0050:\n\tv181 = *([v169 @ X11_v28]);\n\tv182 = v181 << 4;\n\tv183 = v68 + v182;\n\tv184 = v183 + 0x130;\nL_0057:\n\tv151 = System.Collections.Generic.IEnumerable`1<UnityEngine.Vector3>::GetEnumerator(points);\n\tv153 = v151 == 0;\n\tif (v153) goto L_00FA;\n\tgoto L_00C6;\nL_0066:\n\tgoto L_008D;\n\tv615 = *([v589 @ X8_v19+B0]);\n\tv616 = 0;\n\tv617 = v615 + 8;\n\tv619 = *([v663 @ X11_v18-8]);\n\tv669 = v619 == v590;\n\tif (v669) goto L_0086;\n\tv641 = v664 + 1;\n\tv674 = v641 < v591;\n\tv637 = ~v674;\n\tv639 = v663 + 0x10;\n\tv621 = ~v637;\n\tif (v621) goto L_FFFFFFFF;\n\tv642 = v155;\n\tv643 = 0;\n\tv644 = 0x8909C4(v642, v590, v643, methodInfo, v52, v53, v54, v55, v298, v338, v336, v296, v294, v292, v59, v60);\n\tgoto L_008D;\nL_0086:\n\tv675 = *([v663 @ X11_v18]);\n\tv676 = v675 << 4;\n\tv677 = v589 + v676;\n\tv678 = v677 + 0x130;\nL_008D:\n\tv692 = System.Collections.Generic.IEnumerator`1<UnityEngine.Vector3>::get_Current(v151);\n\tgoto L_00A3;\n\tv697 = *([v693 @ X0_v30+E0]);\n\tv698 = v697 == 0;\n\tv699 = ~v698;\n\tgoto L_00A3;\n\tv701 = \"il2cpp_codegen_runtime_class_init\"(v693, v325, v303, methodInfo, v52, v53, v54, v55, v298, v338, v336, v296, v294, v292, v59, v60);\nL_00A3:\n\t// 163 MakeStruct v289 @ AGGE31340_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v468 @ V0_v3 (UnityEngine.Vector3), v514 @ V1_v4 (System.Single), v513 @ V2_v4 (System.Single)\n\tv704 = UnityEngine.Vector3::Dot(v226, v289);\n\tv717 = *([v255 @ X1_v3 (System.Double&)]) <= v704;\n\tif (v717) goto L_00B5;\n\t*([v255 @ X1_v3 (System.Double&)]) = v704;\nL_00B5:\n\t;\n\tv305 = *([v233 @ X2_v3 (System.Double&)]) >= v704;\n\tif (v305) goto L_00C6;\n\t*([v233 @ X2_v3 (System.Double&)]) = v704;\nL_00C6:\n\tgoto L_00ED;\n\tv346 = *([v340 @ X8_v16+B0]);\n\tv347 = 0;\n\tv348 = v346 + 8;\n\tv350 = *([v447 @ X11_v23-8]);\n\tv453 = v350 == v341;\n\tif (v453) goto L_00E6;\n\tv372 = v448 + 1;\n\tv546 = v372 < v342;\n\tv368 = ~v546;\n\tv370 = v447 + 0x10;\n\tv352 = ~v368;\n\tif (v352) goto L_FFFFFFFF;\n\tv373 = v155;\n\tv374 = 0;\n\tv375 = 0x8909C4(v373, v341, v374, methodInfo, v52, v53, v54, v55, v298, v338, v336, v296, v294, v292, v59, v60);\n\tgoto L_00ED;\nL_00E6:\n\tv547 = *([v447 @ X11_v23]);\n\tv548 = v547 << 4;\n\tv549 = v340 + v548;\n\tv550 = v549 + 0x130;\nL_00ED:\n\tv502 = System.Collections.IEnumerator::MoveNext(v151);\n\tv555 = v502 == 0;\n\tv556 = ~v555;\n\tif (v556) goto L_0066;\n\tv588 = v151 == 0;\n\tv504 = ~v588;\n\tif (v504) goto L_0115;\n\tgoto L_013D;\n\tv74 = new System.NullReferenceException();\nL_00FA:\n\tv158 = new System.NullReferenceException();\n\tgoto L_0107;\n\tgoto L_0107;\n\tgoto L_0107;\nL_0107:\n\tv197 = v255 != 1;\n\tif (v197) goto L_015B;\n\tv204 = 0x6D2BC0(v158, v255, v233, methodInfo, v52, v53, v54, v55, v226, v226.y, v226.z, v467, v466, v465, v59, v60);\n\tv508 = *([v204 @ X0_v16]);\n\tv345 = 0x6D2490(v204, v255, v233, methodInfo, v52, v53, v54, v55, v226, v226.y, v226.z, v467, v466, v465, v59, v60);\n\tv377 = points == 0;\n\tif (v377) goto L_013D;\nL_0115:\n\tgoto L_013C;\n\tv557 = *([v516 @ X8_v7+B0]);\n\tv558 = 0;\n\tv559 = v557 + 8;\n\tv561 = *([v603 @ X11_v8-8]);\n\tv609 = v561 == v519;\n\tif (v609) goto L_0135;\n\tv583 = v604 + 1;\n\tv645 = v583 < v518;\n\tv579 = ~v645;\n\tv581 = v603 + 0x10;\n\tv563 = ~v579;\n\tif (v563) goto L_FFFFFFFF;\n\tv584 = v505;\n\tv585 = 0;\n\tv586 = 0x8909C4(v584, v519, v585, methodInfo, v52, v53, v54, v55, v468, v514, v513, v467, v466, v465, v59, v60);\n\tgoto L_013C;\nL_0135:\n\tv646 = *([v603 @ X11_v8]);\n\tv647 = v646 << 4;\n\tv648 = v516 + v647;\n\tv649 = v648 + 0x130;\nL_013C:\n\tSystem.IDisposable::Dispose(v505);\nL_013D:\n\tv545 = v268 + 1;\n\tv246 = v545 == 0;\n\tv236 = ~v246;\n\tif (v236) goto L_0156;\n\tv587 = v270 == 0;\n\tv264 = ~v587;\n\tif (v264) goto L_015A;\nL_0156:\n\treturn;\nL_015A:\n\tv262 = new System.TypeLoadException();\nL_015B:\n\tv279 = 0x6D2380(v158, 0, 0, methodInfo, v52, v53, v54, v55, v226, v514, v513, v467, v466, v465, v59, v60);\n\treturn;\n// 203 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe static void Project(IEnumerable<Vector3> points, Vector3 axis, out double min, out double max)
		{
			//IL_01c3: Expected I4, but got O
			//IL_021b: Expected I4, but got O
			//IL_035b: Expected O, but got F4
			//IL_00b6: Expected Ref, but got F4
			//IL_00c3: Expected Ref, but got F4
			//IL_00e0: Expected O, but got F4
			//IL_00e8: Expected O, but got F4
			min = default(double);
			max = default(double);
			Vector3 vector = default(Vector3);
			float num = vector.y;
			float z = vector.z;
			ref double reference = ref *(double*)9218868437227405312L;
			ref double reference2 = ref *(double*)(-4503599627370496L);
			IEnumerator<Vector3> enumerator = points.GetEnumerator();
			bool flag = enumerator == null;
			IEnumerator<Vector3> enumerator2 = (IEnumerator<Vector3>)points;
			Vector3 vector2;
			int num5;
			int num6;
			float num7;
			float num8;
			Vector3 vector4;
			int num9;
			int num10;
			float num11;
			float num12;
			float num3 = default(float);
			float num4 = default(float);
			Vector3 vector3 = default(Vector3);
			NullReferenceException ex;
			if (!flag)
			{
				vector2 = vector;
				Vector3 rhs = default(Vector3);
				while (enumerator.MoveNext())
				{
					Vector3 current = enumerator.Current;
					rhs.x = vector2.x;
					rhs.y = num;
					rhs.z = z;
					float num2 = Vector3.Dot(vector, rhs);
					if ((float)reference > num2)
					{
						reference = ref *(double*)num2;
					}
					bool flag2 = !((float)reference2 < num2);
					num3 = z;
					num4 = num;
					vector3 = vector2;
					vector2 = (Vector3)num2;
					num = (float)reference2;
					if (!flag2)
					{
						reference2 = ref *(double*)num2;
						num3 = z;
						num4 = (float)reference2;
						vector3 = (Vector3)num2;
						vector2 = (Vector3)num2;
						num = (float)reference2;
					}
				}
				bool flag3 = enumerator == null;
				bool flag4 = !flag3;
				enumerator2 = enumerator;
				num5 = 0;
				num6 = 0;
				if (!flag4)
				{
					num7 = num3;
					num8 = num4;
					vector4 = vector3;
					vector = vector2;
					num9 = 0;
					num10 = 0;
					num11 = z;
					num12 = num;
					goto IL_03ab;
				}
			}
			else
			{
				ex = new NullReferenceException();
				if (System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference) != (void*)1)
				{
					goto IL_02af;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
				object obj = default(object);
				num6 = (int)obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
				bool flag5 = points == null;
				vector2 = vector;
				num5 = -1;
				num7 = num3;
				num8 = num4;
				vector4 = vector3;
				num9 = -1;
				num10 = (int)obj;
				num11 = vector.z;
				num12 = vector.y;
				if (flag5)
				{
					goto IL_03ab;
				}
			}
			enumerator2.Dispose();
			num7 = num3;
			num8 = num4;
			vector4 = vector3;
			vector = vector2;
			num9 = num5;
			num10 = num6;
			num11 = z;
			num12 = num;
			goto IL_03ab;
			IL_02af:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			return;
			IL_03ab:
			if (num9 + 1 != 0 || num10 == 0)
			{
				return;
			}
			TypeLoadException ex2 = new TypeLoadException();
			num3 = num7;
			num4 = num8;
			vector3 = vector4;
			ex = (NullReferenceException)(object)ex2;
			z = num11;
			num = num12;
			goto IL_02af;
		}
	}
}
