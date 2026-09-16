using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Token(Token = "0x200003C")]
	public class VoxelDistanceField
	{
		[Token(Token = "0x40000D3")]
		[FieldOffset(Offset = "0x10")]
		public Vector3Int[,,] distanceField;

		[Token(Token = "0x40000D4")]
		[FieldOffset(Offset = "0x18")]
		private MeshVoxelizer voxelizer;

		[Token(Token = "0x60002D5")]
		[Address(RVA = "0x10362A4", Offset = "0x10362A4", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.voxelizer = voxelizer;\n\treturn;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public VoxelDistanceField(MeshVoxelizer voxelizer)
		{
			this.voxelizer = voxelizer;
		}

		[Token(Token = "0x60002D6")]
		[Address(RVA = "0x10362D0", Offset = "0x10362D0", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = 0x158B4F0(&coords @ X1 (UnityEngine.Vector3Int), 0, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv32 = v18 & 0x80000000;\n\tv33 = v32 == 0;\n\tv34 = ~v33;\n\tif (v34) goto L_FFFFFFFF;\n\tv37 = 0x158B4F8(&coords @ X1 (UnityEngine.Vector3Int), 0, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv83 = v37 & 0x80000000;\n\tv84 = v83 == 0;\n\tv73 = ~v84;\n\tif (v73) goto L_FFFFFFFF;\n\tv80 = 0x158B500(&coords @ X1 (UnityEngine.Vector3Int), 0, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv170 = v80 & 0x80000000;\n\tv171 = v170 == 0;\n\tv74 = ~v171;\n\tif (v74) goto L_FFFFFFFF;\n\tv174 = 0x158B4F0(&coords @ X1 (UnityEngine.Vector3Int), 0, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv118 = this.voxelizer;\n\tv200 = System.Array::GetLength(v118.voxels, 0);\n\tv86 = v174 >= v200;\n\tif (v86) goto L_006F;\n\tv196 = 0x158B4F8(&coords @ X1 (UnityEngine.Vector3Int), 0, 0, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv71 = this.voxelizer;\n\tv81 = System.Array::GetLength(v71.voxels, 1);\n\tv40 = v196 >= v81;\n\tif (v40) goto L_FFFFFFFF;\n\tv197 = 0x158B500(&coords @ X1 (UnityEngine.Vector3Int), 0, 0, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv119 = this.voxelizer;\n\tv208 = System.Array::GetLength(v119.voxels, 2);\n\tv108 = v197 - v208;\n\tv105 = v108 < 0;\n\tv99 = v197 ^ v208;\n\tv96 = v197 ^ v108;\n\tv93 = v99 & v96;\n\tv90 = v93 < 0;\n\tv210 = v105 == v90;\n\tv87 = ~v210;\n\tgoto L_006F;\nL_006F:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 75 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool VoxelExists(Vector3Int coords)
		{
			//IL_0022: Expected I4, but got I8
			//IL_006c: Expected I4, but got I8
			//IL_00b6: Expected I4, but got I8
			//IL_01d2: Expected O, but got I
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158B4F0 (inside UnityEngine.Vector3::.cctor +0xF4)");
			object obj = default(object);
			bool result;
			if ((int)((long)(IntPtr)obj & 0x80000000L) == 0)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158B4F8 (inside UnityEngine.Vector3::.cctor +0xFC)");
				object obj2 = default(object);
				if ((int)((long)(IntPtr)obj2 & 0x80000000L) == 0)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158B500 (inside UnityEngine.Vector3::.cctor +0x104)");
					object obj3 = default(object);
					if ((int)((long)(IntPtr)obj3 & 0x80000000L) == 0)
					{
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158B4F0 (inside UnityEngine.Vector3::.cctor +0xF4)");
						MeshVoxelizer meshVoxelizer = voxelizer;
						int length = meshVoxelizer.voxels.GetLength(0);
						int num = default(int);
						bool flag = num >= length;
						result = false;
						if (!flag)
						{
							Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158B4F8 (inside UnityEngine.Vector3::.cctor +0xFC)");
							MeshVoxelizer meshVoxelizer2 = voxelizer;
							int length2 = meshVoxelizer2.voxels.GetLength(1);
							int num2 = default(int);
							if (num2 >= length2)
							{
								goto IL_0240;
							}
							Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158B500 (inside UnityEngine.Vector3::.cctor +0x104)");
							MeshVoxelizer meshVoxelizer3 = voxelizer;
							int length3 = meshVoxelizer3.voxels.GetLength(2);
							object obj5 = default(object);
							object obj4 = (long)(IntPtr)obj5 - (long)length3;
							bool flag2 = (long)(IntPtr)obj4 < 0L;
							int num3 = (int)((long)(IntPtr)obj5 ^ (long)length3);
							int num4 = (int)((long)(IntPtr)obj5 ^ (long)(IntPtr)obj4);
							int num5 = num3 & num4;
							bool flag3 = num5 < 0;
							bool flag4 = flag2 == flag3;
							bool flag5 = !flag4;
							result = flag5;
						}
						goto IL_024e;
					}
				}
			}
			goto IL_0240;
			IL_0240:
			result = false;
			goto IL_024e;
			IL_024e:
			return result;
		}

		[Token(Token = "0x60002D7")]
		[Address(RVA = "0x10363DC", Offset = "0x10363DC", Length = "0x450")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv36 = *([1EEEFD0]);\n\tv37 = *([v36 @ X8_v45]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv56 = 0 | 1;\n\t*([20262A9]) = v56;\nL_001C:\n\tv57 = this.voxelizer;\n\tv276 = System.Array::GetLength(v57.voxels, 0);\n\tv311 = this.voxelizer;\n\tv277 = System.Array::GetLength(v311.voxels, 1);\n\tv312 = this.voxelizer;\n\tv466 = System.Array::GetLength(v312.voxels, 2);\n\tv278 = 0x8D821C(UnityEngine.Vector3Int[3], &v276 @ X0_v7 (System.Int32), 0, v78, v65, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv313 = this.voxelizer;\n\tthis.distanceField = v278;\n\tv279 = System.Array::GetLength(v313.voxels, 0);\n\tv314 = this.voxelizer;\n\tv280 = System.Array::GetLength(v314.voxels, 1);\n\tv315 = this.voxelizer;\n\tv473 = System.Array::GetLength(v315.voxels, 2);\n\tv281 = 0x8D821C(UnityEngine.Vector3Int[3], &v279 @ X0_v15 (System.Int32), 0, v78, v65, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0076:\n\tv492 = System.Array::GetLength(v317, 0);\n\tv117 = v244 >= v492;\n\tif (v117) goto L_0138;\nL_0089:\n\tv288 = System.Array::GetLength(v509, 1);\n\tv118 = v238 >= v288;\n\tif (v118) goto L_012F;\nL_009C:\n\tv284 = System.Array::GetLength(v591, 2);\n\tv119 = v108 >= v284;\n\tif (v119) goto L_0129;\n\tv319 = this.voxelizer;\n\tv320 = v319.voxels;\n\tv565 = *([v320 @ X8_v35 (Voxel[3])+10]);\n\tv597 = v244 < *([v565 @ X10_v8]);\n\tv559 = ~v597;\n\tif (v559) goto L_01C4;\n\tv600 = v238 < *([v565 @ X10_v8+10]);\n\tv560 = ~v600;\n\tif (v560) goto L_01C4;\n\tv607 = v108 < *([v565 @ X10_v8+20]);\n\tv561 = ~v607;\n\tif (v561) goto L_01C4;\n\tv618 = *([v565 @ X10_v8+10]) * v244;\n\tv619 = v238 + v618;\n\tv620 = *([v565 @ X10_v8+20]) * v619;\n\tv232 = v108 + v620;\n\tv92 = v232 << 2;\n\tv621 = v320 + v92;\n\tv85 = this.distanceField;\n\tv120 = *([v621 @ X8_v36+20]) != 2;\n\tif (v120) goto L_FFFFFFFF;\n\tv627 = 0;\n\tgoto L_00F2;\nL_00F2:\n\tthis = 0x158B4E4(this, v271, v258, v78, 0, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv568 = *([v85 @ X28_v8 (UnityEngine.Vector3Int[3])+10]);\n\tv674 = v244 < *([v568 @ X9_v15]);\n\tv562 = ~v674;\n\tif (v562) goto L_01C4;\n\tv694 = v238 < *([v568 @ X9_v15+10]);\n\tv563 = ~v694;\n\tif (v563) goto L_01C4;\n\tv703 = v108 < *([v568 @ X9_v15+20]);\n\tv184 = ~v703;\n\tif (v184) goto L_01C4;\n\tv704 = *([v568 @ X9_v15+10]) * v244;\n\tv705 = v238 + v704;\n\tv706 = *([v568 @ X9_v15+20]) * v705;\n\tv707 = v108 + v706;\n\tv708 = v707 * 0xC;\n\tv322 = v85 + v708;\n\t*([v322 @ X8_v42+20]) = v627;\n\t*([v322 @ X8_v42+28]) = v215;\n\tv108 = v108 + 1;\n\tv709 = this.distanceField == 0;\n\tv304 = ~v709;\n\tif (v304) goto L_009C;\n\tgoto L_01C9;\nL_0129:\n\tv238 = v238 + 1;\n\tv596 = this.distanceField == 0;\n\tv305 = ~v596;\n\tif (v305) goto L_0089;\n\tgoto L_01C9;\nL_012F:\n\tv244 = v244 + 1;\n\tv513 = this.distanceField == 0;\n\tv306 = ~v513;\n\tif (v306) goto L_0076;\n\tgoto L_01C9;\nL_0138:\n\t// 312 NewArr v289 @ X0_v29 (System.Int32[]), typeof(System.Int32[]), 3\n\tv290 = System.Array::GetLength(this.distanceField, 0);\n\tv514 = v289.Length == 0;\n\tif (v514) goto L_01C4;\n\tv289[0] = v290;\n\tv574 = System.Array::GetLength(this.distanceField, 1);\n\tv594 = v289.Length < 1;\n\tv357 = ~v594;\n\tv355 = v289.Length - 1;\n\tv351 = v355 == 0;\n\tv595 = ~v357;\n\tv341 = v595 | v351;\n\tif (v341) goto L_01C4;\n\tv289[1] = v574;\n\tv575 = System.Array::GetLength(this.distanceField, 2);\n\tv598 = v289.Length < 2;\n\tv564 = ~v598;\n\tv558 = v289.Length - 2;\n\tv546 = v558 == 0;\n\tv599 = ~v564;\n\tv516 = v599 | v546;\n\tif (v516) goto L_01C4;\n\tv289[2] = v575;\n\tgoto L_017D;\n\tv608 = *([v603 @ X0_v36+E0]);\n\tv609 = v608 == 0;\n\tv610 = ~v609;\n\tif (v610) goto L_017D;\n\tv612 = \"il2cpp_codegen_runtime_class_init\"(v603, v572, v570, v76, v63, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_017D:\n\tv617 = UnityEngine.Mathf::Max(v289);\n\tv625 = UnityEngine.Mathf::Log(v617, 2f);\n\tv640 = UnityEngine.Mathf::FloorToInt(v625);\n\tv683 = v640 - 1;\n\tv650 = v640 < 1;\n\tif (v650) goto L_01B1;\nL_0198:\n\tgoto L_01A0;\n\tv695 = *([v690 @ X0_v45+E0]);\n\tv696 = v695 == 0;\n\tv697 = ~v696;\n\tgoto L_01A0;\n\tv699 = \"il2cpp_codegen_runtime_class_init\"(v690, v685, v684, v676, v63, v43, v44, v45, v675, v400, v48, v49, v50, v51, v52, v53);\nL_01A0:\n\tthis = 0x6D2E60(v683, v685, v684, v676, 0, v43, v44, v45, 1f, 2f, v48, v49, v50, v51, v52, v53);\n\tv684 = this.distanceField;\n\tObi.VoxelDistanceField::JumpFloodPass(this, 1f, this.distanceField, v677);\n\tv671 = this.distanceField;\n\tv683 = v683 - 1;\n\tv669 = v683 + 1;\n\tv660 = v669 == 0;\n\tthis.distanceField = v677;\n\tv658 = ~v660;\n\tif (v658) goto L_0198;\nL_01B1:\n\tv673 = v640 & 1;\n\tv456 = v673 == 0;\n\tif (v456) goto L_01C3;\n\tthis.distanceField = v671;\nL_01C3:\n\treturn;\nL_01C4:\n\tv579 = new System.IndexOutOfRangeException();\n\tthrow v579;\nL_01C9:\n\tthrow System.NullReferenceException;\n// 313 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void JumpFlood()
		{
			//IL_0583: Expected O, but got I4
			//IL_060f: Expected O, but got I4
			//IL_0185: Expected O, but got I
			//IL_06c8: Expected O, but got I4
			//IL_026a: Expected O, but got I
			//IL_0711: Expected I4, but got F4
			//IL_077b: Expected I4, but got F4
			//IL_02a5: Expected O, but got I4
			//IL_02bf: Expected O, but got I4
			//IL_031d: Expected O, but got I
			//IL_0402: Expected O, but got I
			MeshVoxelizer meshVoxelizer = voxelizer;
			int length = meshVoxelizer.voxels.GetLength(0);
			MeshVoxelizer meshVoxelizer2 = voxelizer;
			int length2 = meshVoxelizer2.voxels.GetLength(1);
			MeshVoxelizer meshVoxelizer3 = voxelizer;
			int length3 = meshVoxelizer3.voxels.GetLength(2);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8D821C");
			MeshVoxelizer meshVoxelizer4 = voxelizer;
			Vector3Int[,,] array = default(Vector3Int[,,]);
			distanceField = array;
			int length4 = meshVoxelizer4.voxels.GetLength(0);
			MeshVoxelizer meshVoxelizer5 = voxelizer;
			int length5 = meshVoxelizer5.voxels.GetLength(1);
			MeshVoxelizer meshVoxelizer6 = voxelizer;
			int length6 = meshVoxelizer6.voxels.GetLength(2);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8D821C");
			int num = 0;
			Array array2 = distanceField;
			int num11 = default(int);
			object obj3 = default(object);
			Vector3Int[,,] array8 = default(Vector3Int[,,]);
			while (true)
			{
				IL_085c:
				int length7 = array2.GetLength(0);
				if (num < length7)
				{
					int num2 = 0;
					Array array3 = distanceField;
					while (true)
					{
						int length8 = array3.GetLength(1);
						if (num2 < length8)
						{
							int num3 = 0;
							Array array4 = distanceField;
							while (true)
							{
								int length9 = array4.GetLength(2);
								if (num3 >= length9)
								{
									break;
								}
								MeshVoxelizer meshVoxelizer7 = voxelizer;
								MeshVoxelizer.Voxel[,,] voxels = meshVoxelizer7.voxels;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ X8_v35 (Voxel[3])+10]");
								object obj = 0;
								if ((long)num >= (long)(IntPtr)obj)
								{
									goto end_IL_082b;
								}
								int num4 = num2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ X10_v8+10]");
								if ((long)num4 >= 0L)
								{
									goto end_IL_082b;
								}
								int num5 = num3;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ X10_v8+20]");
								if ((long)num5 >= 0L)
								{
									goto end_IL_082b;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ X10_v8+10]");
								int num6 = (int)(0L * (long)num);
								int num7 = num2 + num6;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v565 @ X10_v8+20]");
								int num8 = (int)(0L * (long)num7);
								int num9 = num3 + num8;
								int num10 = num9 << 2;
								object obj2 = (long)(IntPtr)voxels + (long)num10;
								Vector3Int[,,] array5 = distanceField;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v621 @ X8_v36+20]");
								if ((IntPtr)0 == (IntPtr)2)
								{
									obj3 = 0;
									num11 = num3;
									int num12 = 0;
									obj3 = 0;
									int num13 = num2;
									int num14 = num;
									VoxelDistanceField voxelDistanceField = (VoxelDistanceField)obj3;
								}
								else
								{
									num11 = -1;
									int num12 = 0;
									int num13 = -1;
									int num14 = -1;
									VoxelDistanceField voxelDistanceField = (VoxelDistanceField)obj3;
								}
								Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158B4E4 (inside UnityEngine.Vector3::.cctor +0xE8)");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ X28_v8 (UnityEngine.Vector3Int[3])+10]");
								object obj4 = 0;
								if ((long)num >= (long)(IntPtr)obj4)
								{
									goto end_IL_082b;
								}
								int num15 = num2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v568 @ X9_v15+10]");
								if ((long)num15 >= 0L)
								{
									goto end_IL_082b;
								}
								int num16 = num3;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v568 @ X9_v15+20]");
								if ((long)num16 >= 0L)
								{
									goto end_IL_082b;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v568 @ X9_v15+10]");
								int num17 = (int)(0L * (long)num);
								int num18 = num2 + num17;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v568 @ X9_v15+20]");
								int num19 = (int)(0L * (long)num18);
								int num20 = num3 + num19;
								int num21 = num20 * 12;
								object obj5 = (long)(IntPtr)array5 + (long)num21;
								num3++;
								bool flag = distanceField == null;
								bool flag2 = !flag;
								array4 = distanceField;
								if (flag2)
								{
									continue;
								}
								goto IL_07e0;
							}
							num2++;
							bool flag3 = distanceField == null;
							bool flag4 = !flag3;
							array3 = distanceField;
							if (flag4)
							{
								continue;
							}
						}
						else
						{
							num++;
							bool flag5 = distanceField == null;
							bool flag6 = !flag5;
							array2 = distanceField;
							if (flag6)
							{
								goto IL_085c;
							}
						}
						goto IL_07e0;
						IL_07e0:
						throw new NullReferenceException();
						continue;
						end_IL_082b:
						break;
					}
				}
				else
				{
					int[] array6 = new int[3];
					int length10 = distanceField.GetLength(0);
					if (array6.Length != 0)
					{
						array6[0] = length10;
						int length11 = distanceField.GetLength(1);
						bool flag7 = array6.Length < 1;
						bool flag8 = !flag7;
						object obj6 = array6.Length - 1;
						bool flag9 = obj6 == null;
						bool flag10 = !flag8;
						if (!(flag10 || flag9))
						{
							array6[1] = length11;
							int length12 = distanceField.GetLength(2);
							bool flag11 = array6.Length < 2;
							bool flag12 = !flag11;
							object obj7 = array6.Length - 2;
							bool flag13 = obj7 == null;
							bool flag14 = !flag12;
							if (!(flag14 || flag13))
							{
								array6[2] = length12;
								int num22 = Mathf.Max(array6);
								float f = Mathf.Log(num22, 2f);
								int num23 = Mathf.FloorToInt(f);
								int num24 = num23 - 1;
								bool flag15 = num23 < 1;
								Vector3Int[,,] array7 = array8;
								if (!flag15)
								{
									Vector3Int[,,] array9 = (Vector3Int[,,])num11;
									Vector3Int[,,] array10 = array8;
									Vector3Int[,,] array11 = null;
									int num25 = 0;
									bool flag17;
									do
									{
										Il2CppRuntime.Boundary("EXTERNAL_DEPENDENCY:ldexpf", "Method not found @6D2E60 (native ldexpf)");
										array11 = distanceField;
										JumpFloodPass(1, distanceField, array10);
										array7 = distanceField;
										num24--;
										int num26 = num24 + 1;
										bool flag16 = num26 == 0;
										distanceField = array10;
										flag17 = !flag16;
										array9 = array10;
										array10 = distanceField;
										num25 = 1;
									}
									while (flag17);
								}
								if ((num23 & 1) != 0)
								{
									distanceField = array7;
								}
								break;
							}
						}
					}
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
		}

		[Token(Token = "0x60002D8")]
		[Address(RVA = "0x103682C", Offset = "0x103682C", Length = "0x588")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv28 = &v29 @ stack_-10_v2;\n\tgoto L_0020;\n\tv44 = *([1EF6BD8]);\n\tv45 = *([v44 @ X8_v67]);\n\tv46 = \"il2cpp_codegen_initialize_method\"(v45, stride, input, output, methodInfo, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58);\n\tv61 = 0 | 1;\n\t*([20262AA]) = v61;\nL_0020:\n\t*([v28 @ X29_v1-68]) = 0;\n\t*([v28 @ X29_v1-70]) = 0;\n\t*([v28 @ X29_v1-78]) = 0;\n\t*([v28 @ X29_v1-80]) = 0;\n\t*([v28 @ X29_v1-88]) = 0;\n\t*([v28 @ X29_v1-90]) = 0;\n\tv70 = System.Array::GetLength(input, 0);\n\tv268 = v70 < 1;\n\tif (v268) goto L_0273;\n\tv270 = 0 - stride;\nL_0049:\n\tv504 = System.Array::GetLength(v376, 1);\n\tv515 = v504 < 1;\n\tif (v515) goto L_0255;\nL_005D:\n\tv635 = System.Array::GetLength(v577, 2);\n\tv648 = v635 < 1;\n\tif (v648) goto L_0243;\nL_0071:\n\tv734 = &v29 @ stack_-10_v2 - 0x70;\n\tv237 = 0x158B4E4(v734, v178, v677, v156, 0, v48, v49, v50, v657, v52, v53, v54, v55, v56, v57, v58);\n\tv737 = *([v709 @ X21_v11 (UnityEngine.Vector3Int[3])+10]);\n\tv738 = *([v737 @ X8_v16]);\n\tv739 = v178 < *([v737 @ X8_v16]);\n\tv740 = ~v739;\n\tif (v740) goto L_0274;\n\tv738 = *([v737 @ X8_v16+10]);\n\tv749 = v677 < *([v737 @ X8_v16+10]);\n\tv750 = ~v749;\n\tif (v750) goto L_0274;\n\tv910 = v156 < *([v737 @ X8_v16+20]);\n\tv227 = ~v910;\n\tif (v227) goto L_0274;\n\tv912 = *([v737 @ X8_v16+10]) * v178;\n\tv738 = v609 + v912;\n\tv914 = *([v737 @ X8_v16+20]) * v738;\n\tv915 = v156 + v914;\n\tv917 = v915 * 0xC;\n\tv738 = v709 + v917;\n\tv738 = *([v738 @ X9_v8 (System.Int32)+28]);\n\t*([v28 @ X29_v1-80]) = *([v738 @ X9_v8 (System.Int32)+20]);\n\t*([v28 @ X29_v1-78]) = v738;\n\tv785 = *([output @ X3 (UnityEngine.Vector3Int[3])+10]);\n\tv919 = v178 < *([v785 @ X11_v10]);\n\tv876 = ~v919;\n\tif (v876) goto L_0274;\n\tv920 = v677 < *([v785 @ X11_v10+10]);\n\tv877 = ~v920;\n\tif (v877) goto L_0274;\n\tv921 = v156 < *([v785 @ X11_v10+20]);\n\tv878 = ~v921;\n\tif (v878) goto L_0274;\n\tv924 = &v29 @ stack_-10_v2 - 0x80;\n\tv926 = *([v785 @ X11_v10+10]) * v178;\n\tv927 = v609 + v926;\n\tv929 = *([v785 @ X11_v10+20]) * v927;\n\tv930 = v156 + v929;\n\tv932 = v930 * 0xC;\n\tv933 = output + v932;\n\t*([v933 @ X10_v15+20]) = *([v738 @ X9_v8 (System.Int32)+20]);\n\t*([v933 @ X10_v15+28]) = v738;\n\tv934 = 0x158B4F0(v924, 0, v677, v156, 0, v48, v49, v50, v657, v52, v53, v54, v55, v56, v57, v58);\n\tv945 = v934 != v178;\n\tif (v945) goto L_0108;\n\tv946 = &v29 @ stack_-10_v2 - 0x80;\n\tv948 = 0x158B4F8(v946, 0, v677, v156, 0, v48, v49, v50, v657, v52, v53, v54, v55, v56, v57, v58);\n\tv950 = v948 != v677;\n\tif (v950) goto L_0108;\n\tv988 = &v29 @ stack_-10_v2 - 0x80;\n\tv978 = 0x158B500(v988, 0, v677, v156, 0, v48, v49, v50, v657, v52, v53, v54, v55, v56, v57, v58);\n\tv964 = v978 == v156;\n\tif (v964) goto L_022F;\nL_0108:\n\tv981 = &v29 @ stack_-10_v2 - 0x80;\n\tv983 = 0x158B4F0(v981, 0, v677, v156, 0, v48, v49, v50, v657, v52, v53, v54, v55, v56, v57, v58);\n\tv985 = v983 & 0x80000000;\n\tv986 = v985 == 0;\n\tv987 = ~v986;\n\tif (v987) goto L_FFFFFFFF;\n\tgoto L_0124;\n\tv1001 = *([v994 @ X0_v58+E0]);\n\tv1002 = v1001 == 0;\n\tv1003 = ~v1002;\n\tif (v1003) goto L_0124;\n\tv1005 = \"il2cpp_codegen_runtime_class_init\"(v994, v982, v231, v110, v113, v48, v49, v50, v88, v52, v53, v54, v55, v56, v57, v58);\nL_0124:\n\tv1013 = v805 & 0xFFFFFFFF00000000;\n\tv738 = v806 & 0xFFFFFFFF00000000;\n\tv1015 = v1013 | *([v28 @ X29_v1-78]);\n\tv1016 = v738 | *([v28 @ X29_v1-68]);\n\tv1019 = UnityEngine.Vector3Int::op_Subtraction(*([v28 @ X29_v1-80]), v1015);\n\t*([v28 @ X29_v1-90]) = v1019;\n\t*([v28 @ X29_v1-88]) = v1015;\n\tv1092 = &v29 @ stack_-10_v2 - 0x90;\n\tv1032 = 0x158B62C(v1092, 0, *([v28 @ X29_v1-70]), v1016, 0, v48, v49, v50, v657, v52, v53, v54, v55, v56, v57, v58);\n\tgoto L_FFFFFFFF;\nL_0136:\n\tv1137 = v738 * v708;\n\tv1138 = v178 + v1137;\nL_013A:\n\tv1195 = v1192 * v708;\n\tv761 = v1164 + v1195;\nL_0144:\n\tv1233 = 0x158B4E4(&v1230 @ stack_-B0_v14 (UnityEngine.Vector3Int), v1055, v761, v804, 0, v48, v49, v50, v1037, v52, v53, v54, v55, v56, v57, v58);\n\tv738 = v1199 & 0xFFFFFFFF00000000;\n\tv1238 = Obi.VoxelDistanceField::VoxelExists(v1084, v1230);\n\tv894 = v1238 == 0;\n\tif (v894) goto L_01FD;\n\tv1243 = 0x158B4F0(&v1230 @ stack_-B0_v14 (UnityEngine.Vector3Int), 0, v738, v804, 0, v48, v49, v50, v1037, v52, v53, v54, v55, v56, v57, v58);\n\tv1285 = 0x158B4F8(&v1230 @ stack_-B0_v14 (UnityEngine.Vector3Int), 0, v738, v804, 0, v48, v49, v50, v1037, v52, v53, v54, v55, v56, v57, v58);\n\tv892 = 0x158B500(&v1230 @ stack_-B0_v14 (UnityEngine.Vector3Int), 0, v738, v804, 0, v48, v49, v50, v1037, v52, v53, v54, v55, v56, v57, v58);\n\tv903 = *([v709 @ X21_v11 (UnityEngine.Vector3Int[3])+10]);\n\tv738 = *([v903 @ X8_v39]);\n\tv1295 = v1243 < *([v903 @ X8_v39]);\n\tv879 = ~v1295;\n\tif (v879) goto L_0274;\n\tv738 = *([v903 @ X8_v39+10]);\n\tv1296 = v1285 < *([v903 @ X8_v39+10]);\n\tv880 = ~v1296;\n\tif (v880) goto L_0274;\n\tv1297 = v892 < *([v903 @ X8_v39+20]);\n\tv881 = ~v1297;\n\tif (v881) goto L_0274;\n\tv1298 = *([v903 @ X8_v39+10]) * v1243;\n\tv738 = v1285 + v1298;\n\tv1300 = *([v903 @ X8_v39+20]) * v738;\n\tv1301 = v892 + v1300;\n\tv1303 = v1301 * 0xC;\n\tv1304 = v709 + v1303;\n\tv1252 = *([v1304 @ X8_v42+20]);\n\tv1272 = 0x158B4F0(&v1252 @ X9_v28 (UnityEngine.Vector3Int), 0, v738, v804, 0, v48, v49, v50, v1037, v52, v53, v54, v55, v56, v57, v58);\n\tv1306 = v1272 & 0x80000000;\n\tv1307 = v1306 == 0;\n\tv1274 = ~v1307;\n\tif (v1274) goto L_01FD;\n\tgoto L_01AA;\n\tv1315 = *([v1310 @ X0_v51+E0]);\n\tv1316 = v1315 == 0;\n\tv1317 = ~v1316;\n\tif (v1317) goto L_01AA;\n\tv1319 = \"il2cpp_codegen_runtime_class_init\"(v1310, v1271, v886, v774, v776, v48, v49, v50, v762, v52, v53, v54, v55, v56, v57, v58);\nL_01AA:\n\tv738 = v1058 & 0xFFFFFFFF00000000;\n\tv1325 = v1057 & 0xFFFFFFFF00000000;\n\tv899 = v738 | *([v28 @ X29_v1-68]);\n\tv1326 = v1325 | *([v1304 @ X8_v42+28]);\n\tv1327 = UnityEngine.Vector3Int::op_Subtraction(v1252, v1326);\n\t*([v28 @ X29_v1-90]) = v1327;\n\t*([v28 @ X29_v1-88]) = v1326;\n\tv1328 = &v29 @ stack_-10_v2 - 0x90;\n\tv893 = 0x158B62C(v1328, 0, *([v28 @ X29_v1-70]), v899, 0, v48, v49, v50, v1037, v52, v53, v54, v55, v56, v57, v58);\n\tv812 = v1245 <= v893;\n\tif (v812) goto L_FFFFFFFF;\n\tv738 = *([output @ X3 (UnityEngine.Vector3Int[3])+10]);\n\tv1340 = v178 < *([v738 @ X9_v8 (System.Int32)]);\n\tv882 = ~v1340;\n\tif (v882) goto L_0274;\n\tv1349 = v609 < *([v738 @ X9_v8 (System.Int32)+10]);\n\tv883 = ~v1349;\n\tif (v883) goto L_0274;\n\tv738 = *([v738 @ X9_v8 (System.Int32)+20]);\n\tv1350 = v156 < *([v738 @ X9_v8 (System.Int32)+20]);\n\tv884 = ~v1350;\n\tif (v884) goto L_0274;\n\tv1351 = *([v738 @ X9_v8 (System.Int32)+10]) * v178;\n\tv1352 = v609 + v1351;\n\tv1353 = *([v738 @ X9_v8 (System.Int32)+20]) * v1352;\n\tv1354 = v156 + v1353;\n\tv1347 = v1354 * 0xC;\n\tv1348 = output + v1347;\n\t*([v1348 @ X8_v55+20]) = v1252;\n\t*([v1348 @ X8_v55+28]) = *([v1304 @ X8_v42+28]);\nL_01FD:\n\tv778 = v778 + 1;\n\tv804 = v804 + v708;\n\tv1205 = v778 < 1;\n\tif (v1205) goto L_0144;\n\tv1193 = v1192 + 1;\n\tv1168 = v1192 <= 0;\n\tif (v1168) goto L_013A;\n\tv1088 = v738 + 1;\n\tv1060 = v738 <= 0;\n\tif (v1060) goto L_0136;\nL_022F:\n\tv156 = v156 + 1;\n\tv705 = System.Array::GetLength(v709, 2);\n\tv710 = v149 + 1;\n\tv683 = v156 < v705;\n\tif (v683) goto L_0071;\nL_0243:\n\tv609 = v676 + 1;\n\tv573 = System.Array::GetLength(v577, 1);\n\tv551 = v609 < v573;\n\tif (v551) goto L_005D;\nL_0255:\n\tv380 = v178 + 1;\n\tv368 = System.Array::GetLength(v376, 0);\n\tv346 = v380 < v368;\n\tif (v346) goto L_0049;\nL_0273:\n\treturn;\nL_0274:\n\tv909 = new System.IndexOutOfRangeException();\n\tthrow v909;\n\tthrow System.NullReferenceException;\n// 438 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void JumpFloodPass(int stride, Vector3Int[,,] input, Vector3Int[,,] output)
		{
			//IL_0c10: Expected O, but got I
			//IL_0c2f: Expected O, but got I
			//IL_0c37: Expected I4, but got O
			//IL_0250: Expected O, but got I
			//IL_02e7: Expected O, but got I
			//IL_0347: Expected O, but got I
			//IL_040d: Expected O, but got I
			//IL_042f: Expected I4, but got I8
			//IL_0396: Expected O, but got I
			//IL_0bd9: Expected O, but got I4
			//IL_0be7: Expected O, but got I
			//IL_0bfc: Expected O, but got I8
			//IL_0472: Expected I4, but got I8
			//IL_0484: Expected I4, but got I8
			//IL_0499: Expected O, but got I
			//IL_04c3: Expected O, but got I
			//IL_04e0: Expected O, but got I
			//IL_03d3: Expected O, but got I
			//IL_0ba8: Expected O, but got I
			//IL_0bb6: Expected O, but got I
			//IL_0504: Expected I4, but got O
			//IL_0ce5: Expected I4, but got I8
			//IL_08b2: Expected O, but got I
			//IL_0561: Expected O, but got I
			//IL_0569: Expected I4, but got O
			//IL_08f0: Expected O, but got I4
			//IL_094a: Expected I4, but got O
			//IL_0615: Expected O, but got I
			//IL_0639: Expected O, but got I
			//IL_0648: Expected O, but got I
			//IL_0657: Expected O, but got I
			//IL_0666: Expected O, but got I
			//IL_0676: Expected O, but got I
			//IL_0699: Expected I4, but got I8
			//IL_06e2: Expected I4, but got I8
			//IL_06f4: Expected I4, but got I8
			//IL_071e: Expected O, but got I
			//IL_0748: Expected O, but got I
			//IL_0b88: Expected I4, but got O
			//IL_0884: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			int length = input.GetLength(0);
			if (length < 1)
			{
				return;
			}
			int num = -stride;
			int num2 = num;
			int num3 = num;
			int num4 = 0;
			int num5 = num;
			int num6 = num;
			VoxelDistanceField voxelDistanceField = this;
			int num7 = stride;
			Vector3Int[,,] array = input;
			float num8 = default(float);
			int num9 = default(int);
			int num41 = default(int);
			int num42 = default(int);
			int num43 = default(int);
			object obj11 = default(object);
			float num48 = default(float);
			Vector3Int coords = default(Vector3Int);
			object obj20 = default(object);
			object obj21 = default(object);
			object obj22 = default(object);
			object obj28 = default(object);
			float num60 = default(float);
			bool flag10;
			do
			{
				int length2 = array.GetLength(1);
				if (length2 >= 1)
				{
					num8 = num8;
					num9 = num9;
					int num10 = 0;
					int num11 = num2;
					int num12 = num3;
					int num13 = num5;
					int num14 = num6;
					VoxelDistanceField voxelDistanceField2 = voxelDistanceField;
					int num15 = num7;
					Vector3Int[,,] array2 = array;
					bool flag9;
					do
					{
						int length3 = array2.GetLength(2);
						bool flag = length3 < 1;
						int num16 = num10;
						if (!flag)
						{
							float num17 = num8;
							int num18 = num9;
							int num19 = num;
							int num20 = 0;
							int num21 = num10;
							int num22 = num11;
							int num23 = num12;
							int num24 = num13;
							int num25 = num14;
							VoxelDistanceField voxelDistanceField3 = voxelDistanceField2;
							int num26 = num15;
							Vector3Int[,,] array3 = array2;
							bool flag8;
							do
							{
								object obj3 = (long)(IntPtr)obj2 - 112L;
								Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158B4E4 (inside UnityEngine.Vector3::.cctor +0xE8)");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v709 @ X21_v11 (UnityEngine.Vector3Int[3])+10]");
								object obj4 = 0;
								int num27 = (int)obj4;
								if ((long)num4 < (long)(IntPtr)obj4)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v737 @ X8_v16+10]");
									num27 = 0;
									int num28 = num21;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v737 @ X8_v16+10]");
									if ((long)num28 < 0L)
									{
										int num29 = num20;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v737 @ X8_v16+20]");
										if ((long)num29 < 0L)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v737 @ X8_v16+10]");
											int num30 = (int)(0L * (long)num4);
											num27 = num10 + num30;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v737 @ X8_v16+20]");
											int num31 = (int)(0L * (long)num27);
											int num32 = num20 + num31;
											int num33 = num32 * 12;
											num27 = (int)((long)(IntPtr)array3 + (long)num33);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v738 @ X9_v8 (System.Int32)+28]");
											num27 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v738 @ X9_v8 (System.Int32)+20]");
											_ = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [output @ X3 (UnityEngine.Vector3Int[3])+10]");
											object obj5 = 0;
											if ((long)num4 < (long)(IntPtr)obj5)
											{
												int num34 = num21;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v785 @ X11_v10+10]");
												if ((long)num34 < 0L)
												{
													int num35 = num20;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v785 @ X11_v10+20]");
													if ((long)num35 < 0L)
													{
														object obj6 = (long)(IntPtr)obj2 - 128L;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v785 @ X11_v10+10]");
														int num36 = (int)(0L * (long)num4);
														int num37 = num10 + num36;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v785 @ X11_v10+20]");
														int num38 = (int)(0L * (long)num37);
														int num39 = num20 + num38;
														int num40 = num39 * 12;
														object obj7 = (long)(IntPtr)output + (long)num40;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v738 @ X9_v8 (System.Int32)+20]");
														_ = 0;
														Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158B4F0 (inside UnityEngine.Vector3::.cctor +0xF4)");
														if (num41 == num4)
														{
															object obj8 = (long)(IntPtr)obj2 - 128L;
															Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158B4F8 (inside UnityEngine.Vector3::.cctor +0xFC)");
															if (num42 == num21)
															{
																object obj9 = (long)(IntPtr)obj2 - 128L;
																Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158B500 (inside UnityEngine.Vector3::.cctor +0x104)");
																if (num43 == num20)
																{
																	goto IL_0960;
																}
															}
														}
														object obj10 = (long)(IntPtr)obj2 - 128L;
														Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158B4F0 (inside UnityEngine.Vector3::.cctor +0xF4)");
														float num47;
														if ((int)((long)(IntPtr)obj11 & 0x80000000L) == 0)
														{
															int num44 = (int)(num22 & -4294967296L);
															num27 = (int)(num23 & -4294967296L);
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ X29_v1-78]");
															Vector3Int vector3Int = (Vector3Int)((long)num44 | 0L);
															int num45 = num27;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ X29_v1-68]");
															int num46 = (int)((long)num45 | 0L);
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ X29_v1-80]");
															Vector3Int vector3Int2 = (Vector3Int)0 - vector3Int;
															object obj12 = (long)(IntPtr)obj2 - 144L;
															Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158B62C (inside UnityEngine.Vector3::.cctor +0x230)");
															num47 = num48;
															num22 = (int)vector3Int;
															num23 = num46;
														}
														else
														{
															num47 = float.MaxValue;
														}
														float num49 = num17;
														int num50 = num18;
														num27 = -1;
														int num51 = num21;
														int num52 = num24;
														int num53 = num25;
														VoxelDistanceField voxelDistanceField4 = voxelDistanceField3;
														while (true)
														{
															object obj13 = num27 * num26;
															object obj14 = (long)num4 + (long)(IntPtr)obj13;
															object obj15 = obj14;
															object obj16 = 4294967295L;
															while (true)
															{
																object obj17 = (long)(IntPtr)obj16 * (long)num26;
																object obj18 = (long)num51 + (long)(IntPtr)obj17;
																int num54 = -2;
																int num55 = num19;
																while (true)
																{
																	Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158B4E4 (inside UnityEngine.Vector3::.cctor +0xE8)");
																	num27 = (int)(num50 & -4294967296L);
																	bool flag2 = voxelDistanceField4.VoxelExists(coords);
																	bool flag3 = !flag2;
																	num50 = num27;
																	if (!flag3)
																	{
																		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158B4F0 (inside UnityEngine.Vector3::.cctor +0xF4)");
																		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158B4F8 (inside UnityEngine.Vector3::.cctor +0xFC)");
																		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158B500 (inside UnityEngine.Vector3::.cctor +0x104)");
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v709 @ X21_v11 (UnityEngine.Vector3Int[3])+10]");
																		object obj19 = 0;
																		num27 = (int)obj19;
																		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj20) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj19))
																		{
																			break;
																		}
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v903 @ X8_v39+10]");
																		num27 = 0;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v903 @ X8_v39+10]");
																		if ((long)(IntPtr)obj21 >= 0L)
																		{
																			break;
																		}
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v903 @ X8_v39+20]");
																		if ((long)(IntPtr)obj22 >= 0L)
																		{
																			break;
																		}
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v903 @ X8_v39+10]");
																		object obj23 = 0L * (long)(IntPtr)obj20;
																		num27 = (int)((long)(IntPtr)obj21 + (long)(IntPtr)obj23);
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v903 @ X8_v39+20]");
																		object obj24 = 0L * (long)num27;
																		object obj25 = (long)(IntPtr)obj22 + (long)(IntPtr)obj24;
																		object obj26 = (long)(IntPtr)obj25 * 12L;
																		object obj27 = (long)(IntPtr)array3 + (long)(IntPtr)obj26;
																		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1304 @ X8_v42+20]");
																		Vector3Int vector3Int3 = (Vector3Int)0;
																		Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158B4F0 (inside UnityEngine.Vector3::.cctor +0xF4)");
																		int num56 = (int)((long)(IntPtr)obj28 & 0x80000000L);
																		bool flag4 = num56 == 0;
																		bool flag5 = !flag4;
																		num50 = num27;
																		if (!flag5)
																		{
																			num27 = (int)(num53 & -4294967296L);
																			int num57 = (int)(num52 & -4294967296L);
																			int num58 = num27;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ X29_v1-68]");
																			int num59 = (int)((long)num58 | 0L);
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1304 @ X8_v42+28]");
																			Vector3Int vector3Int4 = (Vector3Int)((long)num57 | 0L);
																			Vector3Int vector3Int5 = vector3Int3 - vector3Int4;
																			object obj29 = (long)(IntPtr)obj2 - 144L;
																			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @158B62C (inside UnityEngine.Vector3::.cctor +0x230)");
																			if (num47 > num60)
																			{
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [output @ X3 (UnityEngine.Vector3Int[3])+10]");
																				num27 = 0;
																				if (num4 >= num27)
																				{
																					break;
																				}
																				int num61 = num10;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v738 @ X9_v8 (System.Int32)+10]");
																				if ((long)num61 >= 0L)
																				{
																					break;
																				}
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v738 @ X9_v8 (System.Int32)+20]");
																				num27 = 0;
																				int num62 = num20;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v738 @ X9_v8 (System.Int32)+20]");
																				if ((long)num62 >= 0L)
																				{
																					break;
																				}
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v738 @ X9_v8 (System.Int32)+10]");
																				int num63 = (int)(0L * (long)num4);
																				int num64 = num10 + num63;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v738 @ X9_v8 (System.Int32)+20]");
																				int num65 = (int)(0L * (long)num64);
																				int num66 = num20 + num65;
																				int num67 = num66 * 12;
																				object obj30 = (long)(IntPtr)output + (long)num67;
																				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1304 @ X8_v42+28]");
																				_ = 0;
																				num47 = num60;
																			}
																			num49 = num60;
																			num50 = num27;
																			obj15 = obj14;
																			num52 = (int)vector3Int4;
																			num53 = num59;
																			voxelDistanceField4 = this;
																		}
																	}
																	num54++;
																	num55 += num26;
																	if (num54 < 1)
																	{
																		continue;
																	}
																	goto IL_08a3;
																}
																break;
																IL_08a3:
																object obj31 = (long)(IntPtr)obj16 + 1L;
																bool flag6 = (long)(IntPtr)obj16 <= 0L;
																num51 = num10;
																obj16 = obj31;
																if (flag6)
																{
																	continue;
																}
																goto IL_08e2;
															}
															break;
															IL_08e2:
															object obj32 = num27 + 1;
															bool flag7 = num27 <= 0;
															num17 = num49;
															num18 = num50;
															num21 = num10;
															num24 = num52;
															num25 = num53;
															voxelDistanceField3 = voxelDistanceField4;
															num26 = num26;
															array3 = array3;
															num27 = (int)obj32;
															num51 = num10;
															if (flag7)
															{
																continue;
															}
															goto IL_0960;
														}
													}
												}
											}
										}
									}
								}
								IndexOutOfRangeException ex = new IndexOutOfRangeException();
								throw ex;
								IL_0960:
								num20++;
								int length4 = array3.GetLength(2);
								int num68 = num19 + 1;
								flag8 = num20 < length4;
								num8 = num17;
								num9 = num18;
								num16 = num21;
								num11 = num22;
								num12 = num23;
								num13 = num24;
								num14 = num25;
								voxelDistanceField2 = voxelDistanceField3;
								num15 = num26;
								array2 = array3;
								num19 = num68;
							}
							while (flag8);
						}
						num10 = num16 + 1;
						int length5 = array2.GetLength(1);
						flag9 = num10 < length5;
						num2 = num11;
						num3 = num12;
						num5 = num13;
						num6 = num14;
						voxelDistanceField = voxelDistanceField2;
						num7 = num15;
						array = array2;
					}
					while (flag9);
				}
				int num69 = num4 + 1;
				int length6 = array.GetLength(0);
				flag10 = num69 < length6;
				num4 = num69;
			}
			while (flag10);
		}
	}
}
