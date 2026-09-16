using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x2000057")]
	public class SkeletonBounds
	{
		[Token(Token = "0x4000228")]
		[FieldOffset(Offset = "0x10")]
		private ExposedList<Polygon> polygonPool;

		[Token(Token = "0x4000229")]
		[FieldOffset(Offset = "0x18")]
		private float minX;

		[Token(Token = "0x400022A")]
		[FieldOffset(Offset = "0x1C")]
		private float minY;

		[Token(Token = "0x400022B")]
		[FieldOffset(Offset = "0x20")]
		private float maxX;

		[Token(Token = "0x400022C")]
		[FieldOffset(Offset = "0x24")]
		private float maxY;

		[CompilerGenerated]
		[Token(Token = "0x400022D")]
		[FieldOffset(Offset = "0x28")]
		private ExposedList<BoundingBoxAttachment> _003CBoundingBoxes_003Ek__BackingField;

		[CompilerGenerated]
		[Token(Token = "0x400022E")]
		[FieldOffset(Offset = "0x30")]
		private ExposedList<Polygon> _003CPolygons_003Ek__BackingField;

		[Token(Token = "0x17000113")]
		public ExposedList<BoundingBoxAttachment> BoundingBoxes
		{
			[CompilerGenerated]
			[Token(Token = "0x600037C")]
			[Address(RVA = "0x153D758", Offset = "0x153D758", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<BoundingBoxes>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return BoundingBoxes;
			}
			[CompilerGenerated]
			[Token(Token = "0x600037D")]
			[Address(RVA = "0x153D760", Offset = "0x153D760", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<BoundingBoxes>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CBoundingBoxes_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000114")]
		public ExposedList<Polygon> Polygons
		{
			[CompilerGenerated]
			[Token(Token = "0x600037E")]
			[Address(RVA = "0x153D768", Offset = "0x153D768", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Polygons>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return Polygons;
			}
			[CompilerGenerated]
			[Token(Token = "0x600037F")]
			[Address(RVA = "0x153D770", Offset = "0x153D770", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Polygons>k__BackingField = value;\n\treturn;\n")]
			private set
			{
				_003CPolygons_003Ek__BackingField = value;
			}
		}

		[Token(Token = "0x17000115")]
		public float MinX
		{
			[Token(Token = "0x6000380")]
			[Address(RVA = "0x153D778", Offset = "0x153D778", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.minX;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MinX;
			}
			[Token(Token = "0x6000381")]
			[Address(RVA = "0x153D780", Offset = "0x153D780", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.minX = value;\n\treturn;\n")]
			set
			{
				MinX = value;
			}
		}

		[Token(Token = "0x17000116")]
		public float MinY
		{
			[Token(Token = "0x6000382")]
			[Address(RVA = "0x153D788", Offset = "0x153D788", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.minY;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MinY;
			}
			[Token(Token = "0x6000383")]
			[Address(RVA = "0x153D790", Offset = "0x153D790", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.minY = value;\n\treturn;\n")]
			set
			{
				MinY = value;
			}
		}

		[Token(Token = "0x17000117")]
		public float MaxX
		{
			[Token(Token = "0x6000384")]
			[Address(RVA = "0x153D798", Offset = "0x153D798", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.maxX;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MaxX;
			}
			[Token(Token = "0x6000385")]
			[Address(RVA = "0x153D7A0", Offset = "0x153D7A0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.maxX = value;\n\treturn;\n")]
			set
			{
				MaxX = value;
			}
		}

		[Token(Token = "0x17000118")]
		public float MaxY
		{
			[Token(Token = "0x6000386")]
			[Address(RVA = "0x153D7A8", Offset = "0x153D7A8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.maxY;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MaxY;
			}
			[Token(Token = "0x6000387")]
			[Address(RVA = "0x153D7B0", Offset = "0x153D7B0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.maxY = value;\n\treturn;\n")]
			set
			{
				MaxY = value;
			}
		}

		[Token(Token = "0x17000119")]
		public float Width
		{
			[Token(Token = "0x6000388")]
			[Address(RVA = "0x153D7B8", Offset = "0x153D7B8", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = this.maxX - this.minX;\n\treturn returnVal1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MaxX - MinX;
			}
		}

		[Token(Token = "0x1700011A")]
		public float Height
		{
			[Token(Token = "0x6000389")]
			[Address(RVA = "0x153D7C8", Offset = "0x153D7C8", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = this.maxY - this.minY;\n\treturn returnVal1;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return MaxY - MinY;
			}
		}

		[Token(Token = "0x600038A")]
		[Address(RVA = "0x153D7D8", Offset = "0x153D7D8", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv54 = Il2CppMethodInfo;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv59 = Spine.ExposedList`1<Spine.BoundingBoxAttachment>;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv64 = Spine.ExposedList`1<Spine.Polygon>;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A37B8F]) = v50;\nL_0026:\n\tv52 = new Spine.ExposedList`1<Spine.Polygon>();\n\tSpine.ExposedList`1<Spine.Polygon>::.ctor(v52);\n\tthis.polygonPool = v52;\n\tSystem.Object::.ctor(this);\n\tv66 = new Spine.ExposedList`1<Spine.BoundingBoxAttachment>();\n\tSpine.ExposedList`1<Spine.BoundingBoxAttachment>::.ctor(v66);\n\tthis.<BoundingBoxes>k__BackingField = v66;\n\tv70 = new Spine.ExposedList`1<Spine.Polygon>();\n\tSpine.ExposedList`1<Spine.Polygon>::.ctor(v70);\n\tthis.<Polygons>k__BackingField = v70;\n\treturn;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkeletonBounds()
		{
			ExposedList<Polygon> exposedList = new ExposedList<Polygon>();
			polygonPool = exposedList;
			ExposedList<BoundingBoxAttachment> exposedList2 = new ExposedList<BoundingBoxAttachment>();
			BoundingBoxes = exposedList2;
			ExposedList<Polygon> exposedList3 = new ExposedList<Polygon>();
			Polygons = exposedList3;
		}

		[Token(Token = "0x600038B")]
		[Address(RVA = "0x153D8B8", Offset = "0x153D8B8", Length = "0x2F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0032;\n\tv36 = Spine.BoundingBoxAttachment;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v36, skeleton, updateAabb, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv57 = Il2CppMethodInfo;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, skeleton, updateAabb, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv236 = Il2CppMethodInfo;\n\tv237 = \"il2cpp_codegen_initialize_runtime_metadata\"(v236, skeleton, updateAabb, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv279 = Il2CppMethodInfo;\n\tv280 = \"il2cpp_codegen_initialize_runtime_metadata\"(v279, skeleton, updateAabb, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv283 = Il2CppMethodInfo;\n\tv284 = \"il2cpp_codegen_initialize_runtime_metadata\"(v283, skeleton, updateAabb, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv365 = Il2CppMethodInfo;\n\tv366 = \"il2cpp_codegen_initialize_runtime_metadata\"(v365, skeleton, updateAabb, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv380 = Spine.Polygon;\n\tv381 = \"il2cpp_codegen_initialize_runtime_metadata\"(v380, skeleton, updateAabb, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv420 = System.Single[];\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v420, skeleton, updateAabb, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv54 = 1;\n\t*([1A37B90]) = v54;\nL_0032:\n\tv59 = skeleton.slots;\n\tv221 = this.<Polygons>k__BackingField;\n\tSpine.ExposedList`1<Spine.BoundingBoxAttachment>::Clear(this.<BoundingBoxes>k__BackingField, 1);\n\tv378 = v221.Count < 1;\n\tif (v378) goto L_007A;\nL_0053:\n\tv224 = v221.Items;\n\tSpine.ExposedList`1<Spine.Polygon>::Add(this.polygonPool, v224[v95 @ X23_v10 (System.Int32)]);\n\tv95 = v95 + 1;\n\tv389 = v221.Count != v95;\n\tif (v389) goto L_0053;\nL_007A:\n\tSpine.ExposedList`1<Spine.Polygon>::Clear(v221, 1);\n\tv433 = v59.Count < 1;\n\tif (v433) goto L_0128;\nL_008A:\n\tv225 = v59.Items;\n\tv97 = v225[v78 @ X29_v7 (System.Int32)];\n\tv227 = v97.bone;\n\tv472 = ~v227.active;\n\tif (v472) goto L_011A;\n\tv76 = v97.attachment;\n\tv473 = v97.attachment == 0;\n\tif (v473) goto L_011A;\n\tgoto L_FFFFFFFF;\n\tv102 = v102_asT == 0;\n\tif (v102) goto L_011A;\n\tSpine.ExposedList`1<Spine.BoundingBoxAttachment>::Add(this.<BoundingBoxes>k__BackingField, v97.attachment);\n\tv204 = this.polygonPool;\n\tv190 = v204.Count - 1;\n\tv103 = v204.Count < 1;\n\tif (v103) goto L_00F4;\n\tv229 = v204.Items;\n\tSpine.ExposedList`1<Spine.Polygon>::RemoveAt(v204, v190);\n\tgoto L_00FA;\nL_00F4:\n\tv521 = new Spine.Polygon();\n\tSpine.Polygon::.ctor(v521);\nL_00FA:\n\tSpine.ExposedList`1<Spine.Polygon>::Add(v221, v65);\n\tv503 = v65.<Vertices>k__BackingField;\n\tv65.<Count>k__BackingField = v76.worldVerticesLength;\n\tv477 = v76.worldVerticesLength <= v503.Length;\n\tif (v477) goto L_0119;\n\t// 275 NewArr v540 @ X0_v20 (System.Single[]), typeof(System.Single[]), v76.worldVerticesLength (System.Int32)\n\tv65.<Vertices>k__BackingField = v540;\nL_0119:\n\tSpine.VertexAttachment::ComputeWorldVertices(v97.attachment, v225[v78 @ X29_v7 (System.Int32)], v503);\nL_011A:\n\tv78 = v78 + 1;\n\tv449 = v59.Count != v78;\n\tif (v449) goto L_008A;\nL_0128:\n\tv348 = updateAabb == 0;\n\tif (v348) goto L_0142;\n\tSpine.SkeletonBounds::AabbCompute(this);\n\treturn;\nL_0142:\n\tthis.minX = *([407A90]);\n\treturn;\n\tv234 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\n\treturn;\n// 261 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Update(Skeleton skeleton, bool updateAabb)
		{
			//IL_032e: Expected F4, but got I
			ExposedList<Slot> slots = skeleton.Slots;
			ExposedList<Polygon> polygons = Polygons;
			BoundingBoxes.Clear();
			if (polygons.Count >= 1)
			{
				int num = 0;
				do
				{
					Polygon[] items = polygons.Items;
					polygonPool.Add(items[num]);
					num++;
				}
				while (polygons.Count != num);
			}
			polygons.Clear();
			if (slots.Count >= 1)
			{
				int num2 = 0;
				do
				{
					Slot[] items2 = slots.Items;
					Slot slot = items2[num2];
					Bone bone = slot.Bone;
					if (bone.Active)
					{
						VertexAttachment attachment = (VertexAttachment)slot.Attachment;
						if (slot.Attachment != null)
						{
							BoundingBoxAttachment boundingBoxAttachment = slot.Attachment as BoundingBoxAttachment;
							if (boundingBoxAttachment != null)
							{
								BoundingBoxes.Add((BoundingBoxAttachment)slot.Attachment);
								ExposedList<Polygon> exposedList = polygonPool;
								int num3 = exposedList.Count - 1;
								Polygon polygon;
								if (exposedList.Count >= 1)
								{
									Polygon[] items3 = exposedList.Items;
									exposedList.RemoveAt(num3);
									polygon = items3[num3];
								}
								else
								{
									Polygon polygon2 = new Polygon();
									polygon = polygon2;
								}
								polygons.Add(polygon);
								float[] array = polygon.Vertices;
								polygon.Count = attachment.WorldVerticesLength;
								if (attachment.WorldVerticesLength > array.Length)
								{
									float[] array2 = (polygon.Vertices = new float[attachment.WorldVerticesLength]);
									array = array2;
								}
								((VertexAttachment)slot.Attachment).ComputeWorldVertices(items2[num2], array);
							}
						}
					}
					num2++;
				}
				while (slots.Count != num2);
			}
			if (updateAabb)
			{
				AabbCompute();
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [407A90]");
			MinX = 0f;
		}

		[Token(Token = "0x600038C")]
		[Address(RVA = "0x153DC04", Offset = "0x153DC04", Length = "0x1A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv38 = System.Math;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv57 = 1;\n\t*([1A37B91]) = v57;\nL_001C:\n\tv58 = this.<Polygons>k__BackingField;\n\tv71 = v58.Count < 1;\n\tif (v71) goto L_FFFFFFFF;\nL_0035:\n\tv185 = v58.Items;\n\tv186 = v185[v107 @ X22_v5 (System.Int32)];\n\tv124 = v186.<Count>k__BackingField < 1;\n\tif (v124) goto L_009C;\n\tv90 = v186.<Vertices>k__BackingField;\nL_0064:\n\tv309 = v336 + 1;\n\tgoto L_007E;\n\tv388 = \"il2cpp_codegen_runtime_class_init\"(v383, methodInfo, v41, v42, v43, v44, v45, v46, v305, v304, v49, v50, v51, v52, v53, v54);\nL_007E:\n\tv393 = System.Math::Min(v313, v90[v336 @ X8_v14 (System.Int32)]);\n\tv397 = System.Math::Min(v312, v90[v309 @ X26_v8 (System.Int32)]);\n\tv401 = System.Math::Max(v314, v90[v336 @ X8_v14 (System.Int32)]);\n\tv340 = System.Math::Max(v311, v90[v309 @ X26_v8 (System.Int32)]);\n\tv336 = v309 + 1;\n\tv350 = v336 < v186.<Count>k__BackingField;\n\tif (v350) goto L_0064;\nL_009C:\n\tv107 = v107 + 1;\n\tv215 = v107 != v58.Count;\n\tif (v215) goto L_0035;\n\tgoto L_00AF;\nL_00AF:\n\tthis.minX = v240;\n\tthis.minY = v238;\n\tthis.maxX = v241;\n\tthis.maxY = v237;\n\treturn;\n\tv176 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 164 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void AabbCompute()
		{
			ExposedList<Polygon> polygons = Polygons;
			float num;
			float num2;
			float num4;
			float num5;
			if (polygons.Count >= 1)
			{
				num = -2.1474836E+09f;
				num2 = 2.1474836E+09f;
				int num3 = 0;
				num4 = 2.1474836E+09f;
				num5 = -2.1474836E+09f;
				do
				{
					Polygon[] items = polygons.Items;
					Polygon polygon = items[num3];
					if (polygon.Count >= 1)
					{
						float[] vertices = polygon.Vertices;
						float val = num;
						float val2 = num2;
						float val3 = num4;
						float val4 = num5;
						int num6 = 0;
						bool flag;
						do
						{
							int num7 = num6 + 1;
							float num8 = Math.Min(val3, vertices[num6]);
							float num9 = Math.Min(val2, vertices[num7]);
							float num10 = Math.Max(val4, vertices[num6]);
							float num11 = Math.Max(val, vertices[num7]);
							num6 = num7 + 1;
							flag = num6 < polygon.Count;
							num = num11;
							num2 = num9;
							num4 = num8;
							num5 = num10;
							val = num11;
							val2 = num9;
							val3 = num8;
							val4 = num10;
						}
						while (flag);
					}
					num3++;
				}
				while (num3 != polygons.Count);
			}
			else
			{
				num = -2.1474836E+09f;
				num2 = 2.1474836E+09f;
				num4 = 2.1474836E+09f;
				num5 = -2.1474836E+09f;
			}
			MinX = num4;
			MinY = num2;
			MaxX = num5;
			MaxY = num;
		}

		[Token(Token = "0x600038D")]
		[Address(RVA = "0x153DDA8", Offset = "0x153DDA8", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.minX < x;\n\tv4 = ~v2;\n\tv5 = this.minX - x;\n\tv7 = v5 == 0;\n\tv12 = ~v7;\n\tv13 = v4 & v12;\n\tif (v13) goto L_0028;\n\tv25 = this.maxX < x;\n\tif (v25) goto L_0028;\n\tv48 = this.minY < y;\n\tv45 = ~v48;\n\tv43 = this.minY - y;\n\tv39 = v43 == 0;\n\tv50 = ~v45;\n\tv29 = v50 | v39;\n\tif (v29) goto L_002C;\nL_0028:\n\treturn 0;\nL_002C:\n\tv70 = this.maxY - y;\n\tv68 = v70 < 0;\n\tv64 = this.maxY ^ y;\n\tv62 = this.maxY ^ v70;\n\tv60 = v64 & v62;\n\tv58 = v60 < 0;\n\tv56 = v68 == v58;\n\treturn v56;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool AabbContainsPoint(float x, float y)
		{
			//IL_0121: Expected O, but got F4
			//IL_0130: Expected O, but got F4
			bool flag = MinX < x;
			bool flag2 = !flag;
			float num = MinX - x;
			bool flag3 = num == 0f;
			bool flag4 = !flag3;
			if (!(flag2 && flag4) && !(MaxX < x))
			{
				bool flag5 = MinY < y;
				bool flag6 = !flag5;
				float num2 = MinY - y;
				bool flag7 = num2 == 0f;
				bool flag8 = !flag6;
				if (flag8 || flag7)
				{
					float num3 = MaxY - y;
					bool flag9 = num3 < 0f;
					object obj = MaxY ^ y;
					object obj2 = MaxY ^ num3;
					int num4 = (int)((nint)obj & (nint)obj2);
					bool flag10 = num4 < 0;
					return flag9 == flag10;
				}
			}
			return false;
		}

		[Token(Token = "0x600038E")]
		[Address(RVA = "0x153DDE4", Offset = "0x153DDE4", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = this.minX < x1;\n\tif (v16) goto L_0025;\n\tv27 = this.minX >= x2;\n\tif (v27) goto L_0063;\nL_0025:\n\tv48 = this.minY < y1;\n\tif (v48) goto L_0032;\n\tv51 = this.minY >= y2;\n\tif (v51) goto L_0063;\nL_0032:\n\tv97 = this.maxX < x1;\n\tv98 = ~v97;\n\tv99 = this.maxX - x1;\n\tv101 = v99 == 0;\n\tv106 = ~v101;\n\tv107 = v98 & v106;\n\tif (v107) goto L_004A;\n\tv156 = this.maxX < x2;\n\tv84 = ~v156;\n\tv80 = this.maxX - x2;\n\tv72 = v80 == 0;\n\tv157 = ~v84;\n\tv52 = v157 | v72;\n\tif (v52) goto L_0063;\nL_004A:\n\tv167 = this.maxY < y1;\n\tv168 = ~v167;\n\tv169 = this.maxY - y1;\n\tv171 = v169 == 0;\n\tv176 = ~v171;\n\tv177 = v168 & v176;\n\tif (v177) goto L_0064;\n\tv178 = this.maxY < y2;\n\tv82 = ~v178;\n\tv78 = this.maxY - y2;\n\tv70 = v78 == 0;\n\tv179 = ~v70;\n\tv50 = v82 & v179;\n\tif (v50) goto L_0064;\nL_0063:\n\treturn 0;\nL_0064:\n\tv189 = y2 - y1;\n\tv190 = x2 - x1;\n\tv122 = v189 / v190;\n\tv191 = this.minX - x1;\n\tv192 = v122 * v191;\n\tv193 = v192 + y1;\n\tv205 = v193 <= this.minY;\n\tif (v205) goto L_0081;\n\tv209 = v193 < this.maxY;\n\tif (v209) goto L_00B7;\nL_0081:\n\tv223 = this.maxX - x1;\n\tv224 = v122 * v223;\n\tv225 = v224 + y1;\n\tv237 = v225 <= this.minY;\n\tif (v237) goto L_009B;\n\tv250 = v225 < this.maxY;\n\tif (v250) goto L_00B7;\nL_009B:\n\tv264 = this.minY - y1;\n\tv265 = v264 / v122;\n\tv125 = v265 + x1;\n\tv277 = v125 <= this.minX;\n\tif (v277) goto L_00B8;\n\tv238 = v125 >= this.maxX;\n\tif (v238) goto L_00B8;\nL_00B7:\n\treturn 1;\nL_00B8:\n\tv288 = this.maxY - y1;\n\tv120 = v288 / v122;\n\tv118 = v120 + x1;\n\tv291 = v118 - this.minX;\n\tv292 = v291 < 0;\n\tv293 = v291 == 0;\n\tv294 = v118 ^ this.minX;\n\tv295 = v118 ^ v291;\n\tv296 = v294 & v295;\n\tv297 = v296 < 0;\n\tv298 = v292 == v297;\n\tv116 = ~v293;\n\tv131 = v298 & v116;\n\tv152 = v118 - this.maxX;\n\tv149 = v152 < 0;\n\treturnVal3 = v131 & v149;\n\treturn returnVal3;\n// 133 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool AabbIntersectsSegment(float x1, float y1, float x2, float y2)
		{
			//IL_041d: Expected O, but got F4
			//IL_042a: Expected O, but got F4
			if ((MinX < x1 || MinX < x2) && (MinY < y1 || MinY < y2))
			{
				bool flag = MaxX < x1;
				bool flag2 = !flag;
				float num = MaxX - x1;
				bool flag3 = num == 0f;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					bool flag5 = MaxX < x2;
					bool flag6 = !flag5;
					float num2 = MaxX - x2;
					bool flag7 = num2 == 0f;
					bool flag8 = !flag6;
					if (flag8 || flag7)
					{
						goto IL_021a;
					}
				}
				bool flag9 = MaxY < y1;
				bool flag10 = !flag9;
				float num3 = MaxY - y1;
				bool flag11 = num3 == 0f;
				bool flag12 = !flag11;
				if (!(flag10 && flag12))
				{
					bool flag13 = MaxY < y2;
					bool flag14 = !flag13;
					float num4 = MaxY - y2;
					bool flag15 = num4 == 0f;
					bool flag16 = !flag15;
					if (!(flag14 && flag16))
					{
						goto IL_021a;
					}
				}
				float num5 = y2 - y1;
				float num6 = x2 - x1;
				float num7 = num5 / num6;
				float num8 = MinX - x1;
				float num9 = num7 * num8;
				float num10 = num9 + y1;
				if (!(num10 > MinY) || !(num10 < MaxY))
				{
					float num11 = MaxX - x1;
					float num12 = num7 * num11;
					float num13 = num12 + y1;
					if (!(num13 > MinY) || !(num13 < MaxY))
					{
						float num14 = MinY - y1;
						float num15 = num14 / num7;
						float num16 = num15 + x1;
						if (!(num16 > MinX) || !(num16 < MaxX))
						{
							float num17 = MaxY - y1;
							float num18 = num17 / num7;
							float num19 = num18 + x1;
							float num20 = num19 - MinX;
							bool flag17 = num20 < 0f;
							bool flag18 = num20 == 0f;
							object obj = num19 ^ MinX;
							object obj2 = num19 ^ num20;
							int num21 = (int)((nint)obj & (nint)obj2);
							bool flag19 = num21 < 0;
							bool flag20 = flag17 == flag19;
							bool flag21 = !flag18;
							bool flag22 = flag20 && flag21;
							float num22 = num19 - MaxX;
							bool flag23 = num22 < 0f;
							return flag22 && flag23;
						}
					}
				}
				return true;
			}
			goto IL_021a;
			IL_021a:
			return false;
		}

		[Token(Token = "0x600038F")]
		[Address(RVA = "0x153DEC0", Offset = "0x153DEC0", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = this.minX >= bounds.maxX;\n\tif (v16) goto L_FFFFFFFF;\n\tv45 = this.maxX <= bounds.minX;\n\tif (v45) goto L_FFFFFFFF;\n\tv47 = this.minY >= bounds.maxY;\n\tif (v47) goto L_FFFFFFFF;\n\tv90 = this.maxY - bounds.minY;\n\tv88 = v90 < 0;\n\tv86 = v90 == 0;\n\tv84 = this.maxY ^ bounds.minY;\n\tv82 = this.maxY ^ v90;\n\tv80 = v84 & v82;\n\tv78 = v80 < 0;\n\tv122 = v88 == v78;\n\tv74 = ~v86;\n\tv76 = v122 & v74;\n\tgoto L_0040;\nL_0040:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool AabbIntersectsSkeleton(SkeletonBounds bounds)
		{
			//IL_00c4: Expected O, but got F4
			//IL_00d3: Expected O, but got F4
			if (MinX < bounds.MaxX && MaxX > bounds.MinX && MinY < bounds.MaxY)
			{
				float num = MaxY - bounds.MinY;
				bool flag = num < 0f;
				bool flag2 = num == 0f;
				object obj = MaxY ^ bounds.MinY;
				object obj2 = MaxY ^ num;
				int num2 = (int)((nint)obj & (nint)obj2);
				bool flag3 = num2 < 0;
				bool flag4 = flag == flag3;
				bool flag5 = !flag2;
				return flag4 && flag5;
			}
			return false;
		}

		[Token(Token = "0x6000390")]
		[Address(RVA = "0x153DF1C", Offset = "0x153DF1C", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = polygon.<Count>k__BackingField < 1;\n\tif (v15) goto L_FFFFFFFF;\n\tv56 = polygon.<Vertices>k__BackingField;\n\tv44 = polygon.<Count>k__BackingField - 2;\nL_0018:\n\tv188 = v47 + 1;\n\tv118 = v44 + 1;\n\tv239 = v56[v188 @ X14_v4 (System.Int32)] >= y;\n\tif (v239) goto L_0054;\n\tv249 = v56[v118 @ X15_v5 (System.Int32)] >= y;\n\tif (v249) goto L_007B;\nL_0054:\n\tv269 = v56[v188 @ X14_v4 (System.Int32)] < y;\n\tif (v269) goto L_008D;\n\tv270 = v56[v118 @ X15_v5 (System.Int32)] >= y;\n\tif (v270) goto L_008D;\nL_007B:\n\tv289 = y - v56[v188 @ X14_v4 (System.Int32)];\n\tv322 = v56[v118 @ X15_v5 (System.Int32)] - v56[v188 @ X14_v4 (System.Int32)];\n\tv323 = v289 / v322;\n\tv292 = v56[v44 @ X13_v4 (System.Int32)] - v56[v47 @ X11_v4 (System.Int32)];\n\tv324 = v323 * v292;\n\tv293 = v56[v47 @ X11_v4 (System.Int32)] + v324;\n\tv301 = v293 >= x;\n\tif (v301) goto L_008D;\n\tv123 = v123 ^ 1;\nL_008D:\n\tv114 = v47 + 2;\n\tv128 = v114 < polygon.<Count>k__BackingField;\n\tif (v128) goto L_0018;\n\tgoto L_009E;\nL_009E:\n\treturnVal2 = v123 & 1;\n\treturn returnVal2;\n\tv17 = new System.IndexOutOfRangeException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 133 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool ContainsPoint(Polygon polygon, float x, float y)
		{
			int num3;
			if (polygon.Count >= 1)
			{
				float[] vertices = polygon.Vertices;
				int num = polygon.Count - 2;
				int num2 = 0;
				num3 = 0;
				bool flag;
				do
				{
					int num4 = num2 + 1;
					int num5 = num + 1;
					if ((vertices[num4] < y && !(vertices[num5] < y)) || (!(vertices[num4] < y) && vertices[num5] < y))
					{
						float num6 = y - vertices[num4];
						float num7 = vertices[num5] - vertices[num4];
						float num8 = num6 / num7;
						float num9 = vertices[num] - vertices[num2];
						float num10 = num8 * num9;
						float num11 = vertices[num2] + num10;
						if (num11 < x)
						{
							num3 ^= 1;
						}
					}
					int num12 = num2 + 2;
					flag = num12 < polygon.Count;
					num = num2;
					num2 = num12;
				}
				while (flag);
			}
			else
			{
				num3 = 0;
			}
			return (byte)(num3 & 1) != 0;
		}

		[Token(Token = "0x6000391")]
		[Address(RVA = "0x153E004", Offset = "0x153E004", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this.<Polygons>k__BackingField;\n\tv28 = v14.Count < 1;\n\tif (v28) goto L_FFFFFFFF;\nL_001C:\n\tv46 = v14.Items;\n\tv31 = Spine.SkeletonBounds::ContainsPoint(v30, v46[v58 @ X20_v7 (System.Int32)], x, y);\n\tv244 = v31 == 0;\n\tv151 = ~v244;\n\tif (v151) goto L_0042;\n\tv58 = v58 + 1;\n\tv133 = v14.Count != v58;\n\tif (v133) goto L_001C;\n\tgoto L_005E;\nL_0042:\n\tv47 = this.<BoundingBoxes>k__BackingField;\n\tv48 = v47.Items;\nL_005E:\n\treturn returnVal1;\n\tv105 = new System.NullReferenceException();\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 80 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public BoundingBoxAttachment ContainsPoint(float x, float y)
		{
			//IL_00ba: Expected O, but got I4
			ExposedList<Polygon> polygons = Polygons;
			if (polygons.Count >= 1)
			{
				SkeletonBounds skeletonBounds = this;
				int num = 0;
				bool flag2;
				do
				{
					Polygon[] items = polygons.Items;
					bool flag = skeletonBounds.ContainsPoint(items[num], x, y);
					if (!flag)
					{
						num++;
						flag2 = polygons.Count != num;
						skeletonBounds = (SkeletonBounds)flag;
						continue;
					}
					ExposedList<BoundingBoxAttachment> boundingBoxes = BoundingBoxes;
					BoundingBoxAttachment[] items2 = boundingBoxes.Items;
					return items2[num];
				}
				while (flag2);
			}
			return null;
		}

		[Token(Token = "0x6000392")]
		[Address(RVA = "0x153E0B8", Offset = "0x153E0B8", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = this.<Polygons>k__BackingField;\n\tv32 = v18.Count < 1;\n\tif (v32) goto L_FFFFFFFF;\nL_0020:\n\tv58 = v18.Items;\n\tv35 = Spine.SkeletonBounds::IntersectsSegment(v34, v58[v70 @ X20_v7 (System.Int32)], x1, y1, x2, y2);\n\tv276 = v35 == 0;\n\tv169 = ~v276;\n\tif (v169) goto L_0048;\n\tv70 = v70 + 1;\n\tv151 = v18.Count != v70;\n\tif (v151) goto L_0020;\n\tgoto L_0066;\nL_0048:\n\tv59 = this.<BoundingBoxes>k__BackingField;\n\tv60 = v59.Items;\nL_0066:\n\treturn returnVal1;\n\tv121 = new System.NullReferenceException();\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 88 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public BoundingBoxAttachment IntersectsSegment(float x1, float y1, float x2, float y2)
		{
			//IL_00c2: Expected O, but got I4
			ExposedList<Polygon> polygons = Polygons;
			if (polygons.Count >= 1)
			{
				SkeletonBounds skeletonBounds = this;
				int num = 0;
				bool flag2;
				do
				{
					Polygon[] items = polygons.Items;
					bool flag = skeletonBounds.IntersectsSegment(items[num], x1, y1, x2, y2);
					if (!flag)
					{
						num++;
						flag2 = polygons.Count != num;
						skeletonBounds = (SkeletonBounds)flag;
						continue;
					}
					ExposedList<BoundingBoxAttachment> boundingBoxes = BoundingBoxes;
					BoundingBoxAttachment[] items2 = boundingBoxes.Items;
					return items2[num];
				}
				while (flag2);
			}
			return null;
		}

		[Token(Token = "0x6000393")]
		[Address(RVA = "0x153E184", Offset = "0x153E184", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = polygon.<Vertices>k__BackingField;\n\tv107 = polygon.<Count>k__BackingField - 2;\n\tv117 = polygon.<Count>k__BackingField - 1;\n\tv232 = polygon.<Count>k__BackingField < 1;\n\tif (v232) goto L_FFFFFFFF;\n\tv235 = x1 * y2;\n\tv236 = y1 * x2;\n\tv135 = x1 - x2;\n\tv134 = y1 - y2;\n\tv138 = v235 - v236;\nL_003E:\n\tv161 = v136 + 1;\n\tv310 = v139 * v4[v161 @ X11_v7 (System.Int32)];\n\tv311 = v140 * v4[v136 @ X12_v6 (System.Int32)];\n\tv312 = v139 - v4[v136 @ X12_v6 (System.Int32)];\n\tv313 = v140 - v4[v161 @ X11_v7 (System.Int32)];\n\tv314 = v310 - v311;\n\tv315 = v135 * v313;\n\tv316 = v134 * v312;\n\tv317 = v138 * v312;\n\tv245 = v315 - v316;\n\tv239 = v135 * v314;\n\tv318 = v317 - v239;\n\tv243 = v318 / v245;\n\tv329 = v243 < v139;\n\tif (v329) goto L_007F;\n\tv330 = v243 < v4[v136 @ X12_v6 (System.Int32)];\n\tv331 = ~v330;\n\tv332 = v243 - v4[v136 @ X12_v6 (System.Int32)];\n\tv334 = v332 == 0;\n\tv339 = ~v331;\n\tv340 = v339 | v334;\n\tif (v340) goto L_0097;\nL_007F:\n\tv360 = v243 < v4[v136 @ X12_v6 (System.Int32)];\n\tif (v360) goto L_0121;\n\tv390 = v243 < v139;\n\tv378 = ~v390;\n\tv376 = v243 - v139;\n\tv372 = v376 == 0;\n\tv391 = ~v372;\n\tv362 = v378 & v391;\n\tif (v362) goto L_0121;\nL_0097:\n\tv389 = v243 < x1;\n\tif (v389) goto L_00AF;\n\tv457 = v243 < x2;\n\tv458 = ~v457;\n\tv459 = v243 - x2;\n\tv461 = v459 == 0;\n\tv466 = ~v458;\n\tv467 = v466 | v461;\n\tif (v467) goto L_00BD;\nL_00AF:\n\tv394 = v243 < x2;\n\tif (v394) goto L_0121;\n\tv501 = v243 < x1;\n\tv451 = ~v501;\n\tv444 = v243 - x1;\n\tv430 = v444 == 0;\n\tv502 = ~v430;\n\tv395 = v451 & v502;\n\tif (v395) goto L_0121;\nL_00BD:\n\tv296 = v138 * v313;\n\tv488 = v134 * v314;\n\tv489 = v296 - v488;\n\tv297 = v489 / v245;\n\tv500 = v297 < v140;\n\tif (v500) goto L_00E3;\n\tv503 = v297 < v4[v161 @ X11_v7 (System.Int32)];\n\tv504 = ~v503;\n\tv505 = v297 - v4[v161 @ X11_v7 (System.Int32)];\n\tv507 = v505 == 0;\n\tv512 = ~v504;\n\tv513 = v512 | v507;\n\tif (v513) goto L_00FB;\nL_00E3:\n\tv396 = v297 < v4[v161 @ X11_v7 (System.Int32)];\n\tif (v396) goto L_0121;\n\tv545 = v297 < v140;\n\tv453 = ~v545;\n\tv446 = v297 - v140;\n\tv432 = v446 == 0;\n\tv546 = ~v432;\n\tv397 = v453 & v546;\n\tif (v397) goto L_0121;\nL_00FB:\n\tv544 = v297 < y1;\n\tif (v544) goto L_0113;\n\tv547 = v297 < y2;\n\tv548 = ~v547;\n\tv549 = v297 - y2;\n\tv551 = v549 == 0;\n\tv556 = ~v548;\n\tv557 = v556 | v551;\n\tif (v557) goto L_FFFFFFFF;\nL_0113:\n\tv398 = v297 < y2;\n\tif (v398) goto L_0121;\n\tv569 = v297 < y1;\n\tv449 = ~v569;\n\tv442 = v297 - y1;\n\tv428 = v442 == 0;\n\tv570 = ~v449;\n\tv393 = v570 | v428;\n\tif (v393) goto L_FFFFFFFF;\nL_0121:\n\tv136 = v161 + 1;\n\tv265 = v136 < polygon.<Count>k__BackingField;\n\tif (v265) goto L_003E;\n\tgoto L_0133;\nL_0133:\n\treturn returnVal2;\n\tv7 = new System.IndexOutOfRangeException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 204 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IntersectsSegment(Polygon polygon, float x1, float y1, float x2, float y2)
		{
			float[] vertices = polygon.Vertices;
			int num = polygon.Count - 2;
			int num2 = polygon.Count - 1;
			if (polygon.Count >= 1)
			{
				float num3 = x1 * y2;
				float num4 = y1 * x2;
				float num5 = x1 - x2;
				float num6 = y1 - y2;
				float num7 = num3 - num4;
				int num8 = 0;
				float num9 = vertices[num];
				float num10 = vertices[num2];
				bool flag9;
				do
				{
					int num11 = num8 + 1;
					float num12 = num9 * vertices[num11];
					float num13 = num10 * vertices[num8];
					float num14 = num9 - vertices[num8];
					float num15 = num10 - vertices[num11];
					float num16 = num12 - num13;
					float num17 = num5 * num15;
					float num18 = num6 * num14;
					float num19 = num7 * num14;
					float num20 = num17 - num18;
					float num21 = num5 * num16;
					float num22 = num19 - num21;
					float num23 = num22 / num20;
					if (!(num23 < num9))
					{
						bool flag = num23 < vertices[num8];
						bool flag2 = !flag;
						float num24 = num23 - vertices[num8];
						bool flag3 = num24 == 0f;
						bool flag4 = !flag2;
						if (flag4 || flag3)
						{
							goto IL_02e3;
						}
					}
					if (!(num23 < vertices[num8]))
					{
						bool flag5 = num23 < num9;
						bool flag6 = !flag5;
						float num25 = num23 - num9;
						bool flag7 = num25 == 0f;
						bool flag8 = !flag7;
						if (!(flag6 && flag8))
						{
							goto IL_02e3;
						}
					}
					goto IL_0634;
					IL_0634:
					num8 = num11 + 1;
					flag9 = num8 < polygon.Count;
					num9 = vertices[num8];
					num10 = vertices[num11];
					continue;
					IL_0693:
					return true;
					IL_03e1:
					float num26 = num7 * num15;
					float num27 = num6 * num16;
					float num28 = num26 - num27;
					float num29 = num28 / num20;
					if (!(num29 < num10))
					{
						bool flag10 = num29 < vertices[num11];
						bool flag11 = !flag10;
						float num30 = num29 - vertices[num11];
						bool flag12 = num30 == 0f;
						bool flag13 = !flag11;
						if (flag13 || flag12)
						{
							goto IL_0536;
						}
					}
					if (!(num29 < vertices[num11]))
					{
						bool flag14 = num29 < num10;
						bool flag15 = !flag14;
						float num31 = num29 - num10;
						bool flag16 = num31 == 0f;
						bool flag17 = !flag16;
						if (!(flag15 && flag17))
						{
							goto IL_0536;
						}
					}
					goto IL_0634;
					IL_02e3:
					if (!(num23 < x1))
					{
						bool flag18 = num23 < x2;
						bool flag19 = !flag18;
						float num32 = num23 - x2;
						bool flag20 = num32 == 0f;
						bool flag21 = !flag19;
						if (flag21 || flag20)
						{
							goto IL_03e1;
						}
					}
					if (!(num23 < x2))
					{
						bool flag22 = num23 < x1;
						bool flag23 = !flag22;
						float num33 = num23 - x1;
						bool flag24 = num33 == 0f;
						bool flag25 = !flag24;
						if (!(flag23 && flag25))
						{
							goto IL_03e1;
						}
					}
					goto IL_0634;
					IL_0536:
					if (!(num29 < y1))
					{
						bool flag26 = num29 < y2;
						bool flag27 = !flag26;
						float num34 = num29 - y2;
						bool flag28 = num34 == 0f;
						bool flag29 = !flag27;
						if (flag29 || flag28)
						{
							goto IL_0693;
						}
					}
					if (!(num29 < y2))
					{
						bool flag30 = num29 < y1;
						bool flag31 = !flag30;
						float num35 = num29 - y1;
						bool flag32 = num35 == 0f;
						bool flag33 = !flag31;
						if (flag33 || flag32)
						{
							goto IL_0693;
						}
					}
					goto IL_0634;
				}
				while (flag9);
			}
			return false;
		}

		[Token(Token = "0x6000394")]
		[Address(RVA = "0x153E2F4", Offset = "0x153E2F4", Length = "0x94")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, attachment, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv36 = 1;\n\t*([1A37B92]) = v36;\nL_0019:\n\tv43 = Spine.ExposedList`1<Spine.BoundingBoxAttachment>::IndexOf(this.<BoundingBoxes>k__BackingField, attachment);\n\tv66 = v43 + 1;\n\tv51 = v66 == 0;\n\tif (v51) goto L_FFFFFFFF;\n\tv63 = this.<Polygons>k__BackingField;\n\tv64 = v63.Items;\n\tgoto L_003B;\nL_003B:\n\treturn returnVal2;\n\tv65 = new System.NullReferenceException();\n\treturnVal1 = new System.IndexOutOfRangeException();\n\treturn returnVal1;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Polygon GetPolygon(BoundingBoxAttachment attachment)
		{
			int num = BoundingBoxes.IndexOf(attachment);
			if (num + 1 != 0)
			{
				ExposedList<Polygon> polygons = Polygons;
				Polygon[] items = polygons.Items;
				return items[num];
			}
			return null;
		}
	}
}
