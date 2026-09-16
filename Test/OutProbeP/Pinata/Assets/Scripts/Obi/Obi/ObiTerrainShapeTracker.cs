using System;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Token(Token = "0x2000025")]
	public class ObiTerrainShapeTracker : ObiShapeTracker
	{
		[Token(Token = "0x4000081")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x60")]
		public bool triangleBasedContacts;

		[Token(Token = "0x4000082")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x64")]
		private Vector3 size;

		[Token(Token = "0x4000083")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x70")]
		private int resolutionU;

		[Token(Token = "0x4000084")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x74")]
		private int resolutionV;

		[Token(Token = "0x4000085")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x78")]
		private bool heightmapDataHasChanged;

		[Token(Token = "0x4000086")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x7C")]
		private GCHandle dataHandle;

		[Token(Token = "0x6000204")]
		[Address(RVA = "0x1030280", Offset = "0x1030280", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiShapeTracker::.ctor(this);\n\tthis.collider = collider;\n\tthis.triangleBasedContacts = triangleBasedContacts;\n\tthis.adaptor.is2D = 0;\n\tv20 = Oni::CreateShape(3);\n\tthis.oniShape = v20;\n\tObi.ObiTerrainShapeTracker::UpdateHeightData(this);\n\treturn;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiTerrainShapeTracker(TerrainCollider collider, bool triangleBasedContacts)
		{
			base.collider = collider;
			this.triangleBasedContacts = triangleBasedContacts;
			adaptor.is2D = false;
			IntPtr intPtr = Oni.CreateShape(Oni.ShapeType.Heightmap);
			oniShape = intPtr;
			UpdateHeightData();
		}

		[Token(Token = "0x6000205")]
		[Address(RVA = "0x10302D0", Offset = "0x10302D0", Length = "0x20C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1ED4E10]);\n\tv25 = *([v24 @ X8_v21]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2026270]) = v44;\nL_0017:\n\tv46 = this.collider == 0;\n\tif (v46) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0044;\n\tv100 = v100_asT == 0;\n\tif (v100) goto L_FFFFFFFF;\n\tgoto L_0044;\nL_0044:\n\tgoto L_004D;\n\tv126 = *([v122 @ X0_v2+E0]);\n\tv127 = v126 == 0;\n\tv128 = ~v127;\n\tgoto L_004D;\n\tv130 = \"il2cpp_codegen_runtime_class_init\"(v122, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_004D:\n\tv136 = UnityEngine.Object::op_Inequality(v117, 0);\n\tv138 = v136 == 0;\n\tif (v138) goto L_00EB;\n\tv217 = UnityEngine.TerrainCollider::get_terrainData(v117);\n\tv375 = UnityEngine.TerrainData::get_heightmapWidth(v217);\n\tv378 = UnityEngine.TerrainData::get_heightmapHeight(v217);\n\tv381 = UnityEngine.TerrainData::GetHeights(v217, 0, 0, v375, v378);\n\tv250 = v378 * v375;\n\t// 109 NewArr v296 @ X0_v20 (System.Single[]), typeof(System.Single[]), v250 @ X1_v9 (System.Int32)\n\tv395 = v378 < 1;\n\tif (v395) goto L_00DB;\nL_008B:\n\tv238 = v375 < 1;\n\tif (v238) goto L_00CC;\n\tv231 = v427 << 0x20;\nL_0091:\n\tv472 = *([v381 @ X0_v18 (System.Single[2])+10]);\n\tv473 = v302 < *([v472 @ X15_v8]);\n\tv474 = ~v473;\n\tif (v474) goto L_00EC;\n\tv482 = v234 < *([v472 @ X15_v8+10]);\n\tv285 = ~v482;\n\tif (v285) goto L_00EC;\n\tv432 = v427 + v234;\n\tv493 = v432 < v296.Length;\n\tv491 = ~v493;\n\tif (v491) goto L_00EC;\n\tv456 = v302 * *([v472 @ X15_v8+10]);\n\tv494 = v234 + v456;\n\tv495 = v494 << 2;\n\tv496 = v381 + v495;\n\tv234 = v234 + 1;\n\tv439 = v231 >> 0x1E;\n\tv433 = v296 + v439;\n\tv231 = v231 + 0x100000000;\n\t*([v433 @ X16_v11+20]) = *([v496 @ X15_v12+20]);\n\tv438 = v234 < v375;\n\tif (v438) goto L_0091;\nL_00CC:\n\tv302 = v302 + 1;\n\tv427 = v427 + v375;\n\tv403 = v302 < v378;\n\tif (v403) goto L_008B;\nL_00DB:\n\tOni::UnpinMemory(this.dataHandle);\n\tv201 = System.Runtime.InteropServices.GCHandle::Alloc(v296, 3);\n\tthis.dataHandle = v201;\n\tthis.heightmapDataHasChanged = 1;\nL_00EB:\n\treturn;\nL_00EC:\n\tv492 = new System.IndexOutOfRangeException();\n\tthrow v492;\n\tthrow System.NullReferenceException;\n// 176 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void UpdateHeightData()
		{
			//IL_0301: Expected O, but got I
			//IL_01e6: Expected O, but got I
			//IL_0210: Expected O, but got I
			//IL_0222: Expected I4, but got I8
			UnityEngine.Object obj;
			if ((object)collider == null)
			{
				obj = null;
			}
			else
			{
				TerrainCollider terrainCollider = collider as TerrainCollider;
				obj = (((object)terrainCollider == null) ? null : collider);
			}
			if (!(obj != null))
			{
				return;
			}
			TerrainData terrainData = ((TerrainCollider)obj).terrainData;
			int heightmapWidth = terrainData.heightmapWidth;
			int heightmapHeight = terrainData.heightmapHeight;
			float[,] heights = terrainData.GetHeights(0, 0, heightmapWidth, heightmapHeight);
			int num = heightmapHeight * heightmapWidth;
			float[] array = new float[num];
			if (heightmapHeight >= 1)
			{
				int num2 = 0;
				int num3 = 0;
				do
				{
					if (heightmapWidth >= 1)
					{
						int num4 = num2 << 32;
						int num5 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v381 @ X0_v18 (System.Single[2])+10]");
							object obj2 = 0;
							if ((long)num3 < (long)(IntPtr)obj2)
							{
								int num6 = num5;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v472 @ X15_v8+10]");
								if ((long)num6 < 0L)
								{
									int num7 = num2 + num5;
									if (num7 < array.Length)
									{
										int num8 = num3;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v472 @ X15_v8+10]");
										int num9 = (int)((long)num8 * 0L);
										int num10 = num5 + num9;
										int num11 = num10 << 2;
										object obj3 = (long)(IntPtr)heights + (long)num11;
										num5++;
										int num12 = num4 >> 30;
										object obj4 = (long)(IntPtr)array + (long)num12;
										num4 = (int)(num4 + 4294967296L);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v496 @ X15_v12+20]");
										_ = 0;
										if (num5 >= heightmapWidth)
										{
											break;
										}
										continue;
									}
								}
							}
							IndexOutOfRangeException ex = new IndexOutOfRangeException();
							throw ex;
						}
					}
					num3++;
					num2 += heightmapWidth;
				}
				while (num3 < heightmapHeight);
			}
			Oni.UnpinMemory(dataHandle);
			GCHandle gCHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
			dataHandle = gCHandle;
			heightmapDataHasChanged = true;
		}

		[Token(Token = "0x6000206")]
		[Address(RVA = "0x1030534", Offset = "0x1030534", Length = "0x284")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv38 = *([1F10760]);\n\tv39 = *([v38 @ X8_v24]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv58 = 0 | 1;\n\t*([2026271]) = v58;\nL_001E:\n\tv60 = this.collider == 0;\n\tif (v60) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_004B;\n\tv114 = v114_asT == 0;\n\tif (v114) goto L_FFFFFFFF;\n\tgoto L_004B;\nL_004B:\n\tgoto L_0054;\n\tv140 = *([v136 @ X0_v2+E0]);\n\tv141 = v140 == 0;\n\tv142 = ~v141;\n\tgoto L_0054;\n\tv144 = \"il2cpp_codegen_runtime_class_init\"(v136, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_0054:\n\tv150 = UnityEngine.Object::op_Inequality(v131, 0);\n\tv152 = v150 == 0;\n\tif (v152) goto L_FFFFFFFF;\n\tv153 = v131 == 0;\n\tif (v153) goto L_00F4;\n\tv226 = UnityEngine.TerrainCollider::get_terrainData(v131);\n\tgoto L_006C;\n\tv348 = *([v219 @ X8_v10+E0]);\n\tv349 = v348 == 0;\n\tv350 = ~v349;\n\tif (v350) goto L_006C;\n\tv355 = v219;\n\tv352 = \"il2cpp_codegen_runtime_class_init\"(v355, v225, v149, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_006C:\n\tv213 = UnityEngine.Object::op_Inequality(v226, 0);\n\tv216 = v213 == 0;\n\tif (v216) goto L_FFFFFFFF;\n\tv232 = v226 == 0;\n\tif (v232) goto L_00F4;\n\tv359 = UnityEngine.TerrainData::get_size(v226);\n\tgoto L_0091;\n\tv368 = *([v364 @ X0_v18+E0]);\n\tv369 = v368 == 0;\n\tv370 = ~v369;\n\tif (v370) goto L_0091;\n\tv372 = \"il2cpp_codegen_runtime_class_init\"(v364, v358, v190, v43, v44, v45, v46, v47, v359, v360, v361, v51, v52, v53, v54, v55);\nL_0091:\n\t// 145 MakeStruct v161 @ AGG1030698_1_v3 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), this.size (UnityEngine.Vector3), this.size.y (System.Single), this.size.z (System.Single)\n\tv376 = UnityEngine.Vector3::op_Inequality(v359, v161);\n\tv378 = v376 == 0;\n\tif (v378) goto L_009A;\n\tv384 = this + 0x70;\n\tgoto L_00BD;\nL_009A:\n\tv382 = UnityEngine.TerrainData::get_heightmapWidth(v226);\n\tv384 = this + 0x70;\n\tv383 = v382 != this.resolutionU;\n\tif (v383) goto L_00BD;\n\tv214 = UnityEngine.TerrainData::get_heightmapHeight(v226);\n\tv156 = v214 != this.resolutionV;\n\tif (v156) goto L_00BD;\n\tv217 = ~this.heightmapDataHasChanged;\n\tif (v217) goto L_FFFFFFFF;\nL_00BD:\n\tv263 = UnityEngine.TerrainData::get_size(v226);\n\tthis.size = v263;\n\tthis.size.y = v263.y;\n\tthis.size.z = v263.z;\n\tv404 = UnityEngine.TerrainData::get_heightmapWidth(v226);\n\t*([v384 @ X21_v6]) = v404;\n\tv408 = UnityEngine.TerrainData::get_heightmapHeight(v226);\n\tthis.resolutionV = v408;\n\tthis.heightmapDataHasChanged = 0;\n\tv410 = this + 0x7C;\n\tv246 = this + 0x18;\n\tv412 = 0xF74EC4(v410, 0, 0, v43, v44, v45, v46, v47, v263, v263.y, v263.z, this.size, this.size.y, this.size.z, v54, v55);\n\tthis.adaptor.data = v412;\n\tv284 = v408 * *([v384 @ X21_v6]);\n\tthis.adaptor.size = this.size;\n\tthis.adaptor.size.z = this.size.z;\n\tthis.adaptor.resolutionU = this.resolutionU;\n\tthis.adaptor.resolutionV = v408;\n\tthis.adaptor.dataCount = v284;\n\tthis.adaptor.accurateContacts = this.triangleBasedContacts;\n\tOni::UpdateShape(this.oniShape, v246);\n\tgoto L_00F2;\nL_00F2:\n\treturn returnVal1;\nL_00F4:\n\treturnVal2 = new System.NullReferenceException();\n\tv310 = v227 * v228;\n\t*([returnVal2 @ X0_v11 (System.NullReferenceException)+C]) = v48;\n\treturnVal2._className = v49;\n\t*([returnVal2 @ X0_v11 (System.NullReferenceException)+14]) = v50;\n\treturnVal2._helpURL = v228;\n\t*([returnVal2 @ X0_v11 (System.NullReferenceException)+34]) = v227;\n\treturnVal2._message = v43;\n\treturnVal2._innerException = v310;\n\treturn returnVal2;\n// 162 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override bool UpdateIfNeeded()
		{
			//IL_009c: Expected O, but got I4
			//IL_0397: Expected O, but got I
			//IL_03df: Expected I4, but got O
			//IL_0104: Expected O, but got I4
			//IL_01bd: Expected O, but got I
			//IL_019f: Expected O, but got I
			//IL_0280: Expected O, but got I4
			//IL_02ae: Expected O, but got I
			//IL_02e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ea: Expected I4, but got Unknown
			//IL_0325: Expected I4, but got O
			UnityEngine.Object obj;
			if ((object)collider == null)
			{
				obj = null;
			}
			else
			{
				TerrainCollider terrainCollider = collider as TerrainCollider;
				obj = (((object)terrainCollider == null) ? null : collider);
			}
			if (obj != null)
			{
				bool flag = (object)obj == null;
				object obj2 = 0;
				UnityEngine.Object obj3 = null;
				if (!flag)
				{
					TerrainData terrainData = ((TerrainCollider)obj).terrainData;
					if (!(terrainData != null))
					{
						goto IL_0371;
					}
					bool flag2 = (object)terrainData == null;
					obj2 = 0;
					obj3 = null;
					if (!flag2)
					{
						Vector3 vector = terrainData.size;
						Vector3 vector2 = default(Vector3);
						vector2.x = size.x;
						vector2.y = size.y;
						vector2.z = size.z;
						object obj4;
						if (vector != vector2)
						{
							obj4 = (long)(IntPtr)this + 112L;
						}
						else
						{
							int heightmapWidth = terrainData.heightmapWidth;
							obj4 = (long)(IntPtr)this + 112L;
							if (heightmapWidth == resolutionU)
							{
								int heightmapHeight = terrainData.heightmapHeight;
								if (heightmapHeight == resolutionV && !heightmapDataHasChanged)
								{
									goto IL_0371;
								}
							}
						}
						Vector3 vector3 = (size = terrainData.size);
						size.y = vector3.y;
						size.z = vector3.z;
						int heightmapWidth2 = terrainData.heightmapWidth;
						obj4 = heightmapWidth2;
						int num = (resolutionV = terrainData.heightmapHeight);
						heightmapDataHasChanged = false;
						object obj5 = (long)(IntPtr)this + 124L;
						ref Oni.Shape reference = ref *(Oni.Shape*)((long)(IntPtr)this + 24L);
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @F74EC4 (inside System.Runtime.InteropServices.GCHandle::GetTarget +0x38)");
						IntPtr data = default(IntPtr);
						adaptor.data = data;
						int dataCount = num * obj4;
						adaptor.size = size;
						adaptor.size.z = size.z;
						adaptor.resolutionU = (int)obj4;
						adaptor.resolutionV = num;
						adaptor.dataCount = dataCount;
						adaptor.accurateContacts = triangleBasedContacts;
						Oni.UpdateShape(OniShape, ref reference);
						return true;
					}
				}
				NullReferenceException ex = new NullReferenceException();
				Exception innerException = (Exception)((long)(IntPtr)obj2 * (long)(IntPtr)obj3);
				string className = default(string);
				((Exception)ex)._className = className;
				((Exception)ex)._helpURL = (string)(object)obj3;
				string message = default(string);
				((Exception)ex)._message = message;
				((Exception)ex)._innerException = innerException;
				return (byte)(int)ex != 0;
			}
			goto IL_0371;
			IL_0371:
			return false;
		}

		[Token(Token = "0x6000207")]
		[Address(RVA = "0x10307B8", Offset = "0x10307B8", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tObi.ObiShapeTracker::Destroy(this);\n\tOni::UnpinMemory(this.dataHandle);\n\treturn;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Destroy()
		{
			base.Destroy();
			Oni.UnpinMemory(dataHandle);
		}
	}
}
