using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Spine
{
	[Token(Token = "0x2000059")]
	public class SkeletonClipping
	{
		[Token(Token = "0x4000231")]
		[FieldOffset(Offset = "0x10")]
		internal readonly Triangulator triangulator;

		[Token(Token = "0x4000232")]
		[FieldOffset(Offset = "0x18")]
		internal readonly ExposedList<float> clippingPolygon;

		[Token(Token = "0x4000233")]
		[FieldOffset(Offset = "0x20")]
		internal readonly ExposedList<float> clipOutput;

		[Token(Token = "0x4000234")]
		[FieldOffset(Offset = "0x28")]
		internal readonly ExposedList<float> clippedVertices;

		[Token(Token = "0x4000235")]
		[FieldOffset(Offset = "0x30")]
		internal readonly ExposedList<int> clippedTriangles;

		[Token(Token = "0x4000236")]
		[FieldOffset(Offset = "0x38")]
		internal readonly ExposedList<float> clippedUVs;

		[Token(Token = "0x4000237")]
		[FieldOffset(Offset = "0x40")]
		internal readonly ExposedList<float> scratch;

		[Token(Token = "0x4000238")]
		[FieldOffset(Offset = "0x48")]
		internal ClippingAttachment clipAttachment;

		[Token(Token = "0x4000239")]
		[FieldOffset(Offset = "0x50")]
		internal ExposedList<ExposedList<float>> clippingPolygons;

		[Token(Token = "0x1700011D")]
		public ExposedList<float> ClippedVertices
		{
			[Token(Token = "0x600039A")]
			[Address(RVA = "0x153E3A8", Offset = "0x153E3A8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.clippedVertices;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ClippedVertices;
			}
		}

		[Token(Token = "0x1700011E")]
		public ExposedList<int> ClippedTriangles
		{
			[Token(Token = "0x600039B")]
			[Address(RVA = "0x153E3B0", Offset = "0x153E3B0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.clippedTriangles;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ClippedTriangles;
			}
		}

		[Token(Token = "0x1700011F")]
		public ExposedList<float> ClippedUVs
		{
			[Token(Token = "0x600039C")]
			[Address(RVA = "0x153E3B8", Offset = "0x153E3B8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.clippedUVs;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ClippedUVs;
			}
		}

		[Token(Token = "0x17000120")]
		public bool IsClipping
		{
			[Token(Token = "0x600039D")]
			[Address(RVA = "0x153E3C0", Offset = "0x153E3C0", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this.clipAttachment == 0;\n\tv11 = ~v6;\n\treturn v11;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				bool flag = clipAttachment == null;
				return !flag;
			}
		}

		[Token(Token = "0x600039E")]
		[Address(RVA = "0x153E3D0", Offset = "0x153E3D0", Length = "0x294")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, slot, clip, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv47 = Il2CppMethodInfo;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v47, slot, clip, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv52 = Il2CppMethodInfo;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, slot, clip, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv198 = Il2CppMethodInfo;\n\tv199 = \"il2cpp_codegen_initialize_runtime_metadata\"(v198, slot, clip, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv246 = Il2CppMethodInfo;\n\tv247 = \"il2cpp_codegen_initialize_runtime_metadata\"(v246, slot, clip, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv250 = Il2CppMethodInfo;\n\tv38 = \"il2cpp_codegen_initialize_runtime_metadata\"(v250, slot, clip, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv40 = 1;\n\t*([1A37B94]) = v40;\nL_0027:\n\tv45 = this.clipAttachment == 0;\n\tif (v45) goto L_002B;\n\tgoto L_0098;\nL_002B:\n\tthis.clipAttachment = clip;\n\tv50 = clip == 0;\n\tif (v50) goto L_009E;\n\tv125 = this.clippingPolygon == 0;\n\tif (v125) goto L_009E;\n\tv175 = Spine.ExposedList`1<System.Single>::Resize(this.clippingPolygon, clip.worldVerticesLength);\n\tv181 = v175 == 0;\n\tif (v181) goto L_009E;\n\tSpine.VertexAttachment::ComputeWorldVertices(clip, slot, 0, clip.worldVerticesLength, v175.Items, 0, 2);\n\tSpine.SkeletonClipping::MakeClockwise(this.clippingPolygon);\n\tv182 = this.triangulator == 0;\n\tif (v182) goto L_009E;\n\tv272 = Spine.Triangulator::Triangulate(this.triangulator, this.clippingPolygon);\n\tv177 = Spine.Triangulator::Decompose(this.triangulator, this.clippingPolygon, v272);\n\tthis.clippingPolygons = v177;\n\tv183 = v177 == 0;\n\tif (v183) goto L_009E;\n\tv302 = Spine.ExposedList`1<Spine.ExposedList`1<System.Single>>::GetEnumerator(v177);\nL_0061:\n\tv329 = Spine.ExposedList`1<System.Object>+Enumerator<System.Object>::MoveNext(&v153 @ stack_-68_v4 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv294 = v329 == 0;\n\tif (v294) goto L_008D;\n\tSpine.SkeletonClipping::MakeClockwise(v305);\n\tv334 = v305.Items;\n\tSpine.ExposedList`1<System.Single>::Add(v305, v334[0]);\n\tv326 = v305.Items;\n\tSpine.ExposedList`1<System.Single>::Add(v305, v326[1]);\n\tgoto L_0061;\nL_008D:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v153 @ stack_-68_v4 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\nL_008E:\n\tv116 = this.clippingPolygons;\n\tv110 = this.clippingPolygons == 0;\n\tif (v110) goto L_009E;\n\treturnVal1 = v116.Count;\nL_0098:\n\treturn returnVal1;\n\tv360 = new System.IndexOutOfRangeException();\n\tv343 = new System.NullReferenceException();\n\tv348 = new System.NullReferenceException();\n\tv356 = new System.NullReferenceException();\n\tv174 = new System.IndexOutOfRangeException();\nL_009E:\n\tv196 = new System.NullReferenceException();\n\tgoto L_00B1;\n\tgoto L_00B1;\n\tgoto L_00B1;\n\tgoto L_00B1;\n\tgoto L_00B1;\n\tgoto L_00B1;\n\tgoto L_00B1;\n\tgoto L_00B1;\nL_00B1:\n\tv202 = v168 != 1;\n\tif (v202) goto L_00C1;\n\tv253 = 0x1854E70(v196, v168, v164, v158, v162, v156, v160, v154, v150, v30, v31, v32, v33, v34, v35, v36);\n\tv264 = 0x1854E80(v253, v168, v164, v158, v162, v156, v160, v154, v150, v30, v31, v32, v33, v34, v35, v36);\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v148 @ stack_-50_v3 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tv259 = *([v253 @ X0_v14]) == 0;\n\tif (v259) goto L_008E;\n\tthrow System.OutOfMemoryException;\nL_00C1:\n\tgoto L_00C7;\n\tX20 = X0;\nL_00C7:\n\tSpine.ExposedList`1<System.Object>+Enumerator<System.Object>::Dispose(&v148 @ stack_-50_v3 (Spine.ExposedList`1<System.Object>+Enumerator<System.Object>));\n\tgoto L_00CE;\n\tv274 = Spine.ExposedList`1<Spine.ExposedList`1<System.Single>>+Enumerator<Spine.ExposedList`1<System.Single>>::Dispose(v196);\nL_00CE:\n\tv277 = new System.OutOfMemoryException();\n\treturnVal2 = Spine.ExposedList`1<Spine.ExposedList`1<System.Single>>+Enumerator<Spine.ExposedList`1<System.Single>>::Dispose(v277);\n\treturn returnVal2;\n// 128 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe int ClipStart(Slot slot, ClippingAttachment clip)
		{
			//IL_003d: Expected O, but got I4
			//IL_0370: Expected O, but got I4
			//IL_01ec: Expected O, but got I
			//IL_01f9: Expected O, but got I4
			//IL_026e: Expected O, but got I4
			if (clipAttachment != null)
			{
				return 0;
			}
			clipAttachment = clip;
			bool flag = clip == null;
			ExposedList<object>.Enumerator enumerator2 = default(ExposedList<object>.Enumerator);
			ExposedList<object>.Enumerator enumerator = enumerator2;
			object obj = 0;
			int num = 0;
			int num3 = default(int);
			int num2 = num3;
			int num4 = 2;
			float[] array2 = default(float[]);
			float[] array = array2;
			ExposedList<int> exposedList2 = default(ExposedList<int>);
			ExposedList<int> exposedList = exposedList2;
			object obj3 = default(object);
			object obj5 = default(object);
			ExposedList<float> exposedList3 = default(ExposedList<float>);
			object obj2;
			if (!flag)
			{
				bool flag2 = clippingPolygon == null;
				enumerator = default(ExposedList<object>.Enumerator);
				obj2 = obj3;
				object obj4 = default(object);
				obj = obj4;
				int num5 = default(int);
				num = num5;
				IntPtr intPtr = default(IntPtr);
				num2 = (int)(nint)intPtr;
				int num6 = default(int);
				num4 = num6;
				float[] array3 = default(float[]);
				array = array3;
				exposedList = (ExposedList<int>)(object)clip;
				obj5 = slot;
				if (!flag2)
				{
					exposedList3 = clippingPolygon.Resize(clip.WorldVerticesLength);
					bool flag3 = exposedList3 == null;
					enumerator = default(ExposedList<object>.Enumerator);
					obj2 = obj3;
					obj = obj4;
					num = num5;
					num2 = (int)(nint)intPtr;
					num4 = num6;
					array = array3;
					exposedList = (ExposedList<int>)(object)clip;
					obj5 = slot;
					if (!flag3)
					{
						clip.ComputeWorldVertices(slot, 0, clip.WorldVerticesLength, exposedList3.Items, 0);
						MakeClockwise(clippingPolygon);
						bool flag4 = triangulator == null;
						enumerator = default(ExposedList<object>.Enumerator);
						obj2 = obj3;
						obj = obj4;
						num = num5;
						num2 = (int)(nint)intPtr;
						num4 = num6;
						array = array3;
						exposedList = (ExposedList<int>)0;
						obj5 = clip.WorldVerticesLength;
						if (!flag4)
						{
							exposedList2 = triangulator.Triangulate(clippingPolygon);
							ExposedList<ExposedList<float>> exposedList4 = (clippingPolygons = triangulator.Decompose(clippingPolygon, exposedList2));
							bool flag5 = exposedList4 == null;
							enumerator = default(ExposedList<object>.Enumerator);
							obj2 = obj3;
							obj = 0;
							num = 0;
							num2 = clip.WorldVerticesLength;
							num4 = 2;
							array = exposedList3.Items;
							exposedList = null;
							obj5 = slot;
							if (!flag5)
							{
								ExposedList<ExposedList<float>>.Enumerator enumerator3 = exposedList4.GetEnumerator();
								ExposedList<float> exposedList5 = default(ExposedList<float>);
								while (enumerator2.MoveNext())
								{
									MakeClockwise(exposedList5);
									float[] items = exposedList5.Items;
									exposedList5.Add(items[0]);
									float[] items2 = exposedList5.Items;
									exposedList5.Add(items2[1]);
								}
								enumerator2.Dispose();
								goto IL_033a;
							}
						}
					}
				}
			}
			goto IL_03ce;
			IL_03ce:
			NullReferenceException ex = new NullReferenceException();
			if ((nint)obj5 == 1)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @1854E70 (native __cxa_begin_catch)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @1854E80 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj6 = default(object);
				if (obj6 != null)
				{
					throw new OutOfMemoryException();
				}
				goto IL_033a;
			}
			enumerator.Dispose();
			OutOfMemoryException ex2 = new OutOfMemoryException();
			((ExposedList<ExposedList<float>>.Enumerator*)ex2)->Dispose();
			int result = default(int);
			return result;
			IL_033a:
			ExposedList<ExposedList<float>> exposedList6 = clippingPolygons;
			bool flag6 = clippingPolygons == null;
			enumerator = default(ExposedList<object>.Enumerator);
			obj2 = obj3;
			obj = 0;
			num = 0;
			num2 = clip.WorldVerticesLength;
			num4 = 2;
			array = exposedList3.Items;
			exposedList = exposedList2;
			obj5 = clippingPolygon;
			if (!flag6)
			{
				return exposedList6.Count;
			}
			goto IL_03ce;
		}

		[Token(Token = "0x600039F")]
		[Address(RVA = "0x153F86C", Offset = "0x153F86C", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.clipAttachment;\n\tv4 = this.clipAttachment == 0;\n\tif (v4) goto L_0015;\n\tv20 = v2.endSlot == slot.data;\n\tif (v20) goto L_0018;\nL_0015:\n\treturn;\nL_0018:\n\tSpine.SkeletonClipping::ClipEnd(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ClipEnd(Slot slot)
		{
			ClippingAttachment clippingAttachment = clipAttachment;
			if (clipAttachment != null && clippingAttachment.EndSlot == slot.Data)
			{
				ClipEnd();
			}
		}

		[Token(Token = "0x60003A0")]
		[Address(RVA = "0x153F8A0", Offset = "0x153F8A0", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv40 = Il2CppMethodInfo;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A37B95]) = v34;\nL_0016:\n\tv38 = this.clipAttachment == 0;\n\tif (v38) goto L_0039;\n\tthis.clipAttachment = 0;\n\tthis.clippingPolygons = 0;\n\tSpine.ExposedList`1<System.Single>::Clear(this.clippedVertices, 1);\n\tSpine.ExposedList`1<System.Int32>::Clear(this.clippedTriangles, 1);\n\tSpine.ExposedList`1<System.Single>::Clear(this.clippingPolygon, 1);\n\treturn;\nL_0039:\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ClipEnd()
		{
			if (clipAttachment != null)
			{
				clipAttachment = null;
				clippingPolygons = null;
				ClippedVertices.Clear();
				ClippedTriangles.Clear();
				clippingPolygon.Clear();
			}
		}

		[Token(Token = "0x60003A1")]
		[Address(RVA = "0x153F94C", Offset = "0x153F94C", Length = "0x778")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tv56 = Il2CppMethodInfo;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v56, vertices, verticesLength, triangles, trianglesLength, uvs, methodInfo, v60, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv76 = Il2CppMethodInfo;\n\tv77 = \"il2cpp_codegen_initialize_runtime_metadata\"(v76, vertices, verticesLength, triangles, trianglesLength, uvs, methodInfo, v60, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv599 = Il2CppMethodInfo;\n\tv600 = \"il2cpp_codegen_initialize_runtime_metadata\"(v599, vertices, verticesLength, triangles, trianglesLength, uvs, methodInfo, v60, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv604 = Il2CppMethodInfo;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v604, vertices, verticesLength, triangles, trianglesLength, uvs, methodInfo, v60, v61, v62, v63, v64, v65, v66, v67, v68);\n\tv72 = 1;\n\t*([1A37B96]) = v72;\nL_002E:\n\tv73 = this.clippingPolygons;\n\tv1245 = this.clippedVertices;\n\tv521 = v73.Items;\n\tv1242 = this.clippedTriangles;\n\tSpine.ExposedList`1<System.Single>::Clear(this.clippedVertices, 1);\n\tSpine.ExposedList`1<System.Single>::Clear(this.clippedUVs, 1);\n\tSpine.ExposedList`1<System.Int32>::Clear(this.clippedTriangles, 1);\n\tv354 = trianglesLength < 1;\n\tif (v354) goto L_03E0;\nL_0076:\n\tv290 = v567[v580 @ X8_v11 (System.Int32)] << 1;\n\tv581 = v290 | 1;\n\tv890 = v580 + 1;\n\tv891 = v567[v890 @ X12_v7 (System.Int32)] << 1;\n\tv291 = v891 | 1;\n\tv876 = v580 + 2;\n\tv872 = v567[v876 @ X15_v6 (System.Int32)] << 1;\n\tv250 = v872 | 1;\n\tv356 = v73.Count < 1;\n\tif (v356) goto L_03BD;\n\tv160 = vertices[v291 @ X12_v11 (System.Int32)] - vertices[v250 @ X11_v9 (System.Int32)];\n\tv156 = vertices[v872 @ X11_v8 (System.Int32)] - vertices[v891 @ X12_v10 (System.Int32)];\n\tv152 = vertices[v290 @ X12_v5 (System.Int32)] - vertices[v872 @ X11_v8 (System.Int32)];\n\tv1295 = vertices[v581 @ X8_v15 (System.Int32)] - vertices[v250 @ X11_v9 (System.Int32)];\n\tv138 = vertices[v250 @ X11_v9 (System.Int32)] - vertices[v581 @ X8_v15 (System.Int32)];\n\tv1296 = v152 * v160;\n\tv1297 = v156 * v1295;\n\tv1298 = v1296 + v1297;\n\tv134 = v814 / v1298;\nL_0172:\n\tv595 = v1245.Count;\n\tv533 = Spine.SkeletonClipping::Clip(this, vertices[v290 @ X12_v5 (System.Int32)], vertices[v581 @ X8_v15 (System.Int32)], vertices[v891 @ X12_v10 (System.Int32)], vertices[v291 @ X12_v11 (System.Int32)], vertices[v872 @ X11_v8 (System.Int32)], vertices[v250 @ X11_v9 (System.Int32)], v521[v568 @ X22_v10 (System.Int32)], v1244);\n\tv1311 = v533 == 0;\n\tif (v1311) goto L_02B4;\n\tv1314 = v1244.Count == 0;\n\tif (v1314) goto L_FFFFFFFF;\n\tv573 = v1244.Items;\n\tv583 = v1244.Count & 0xFFFFFFFE;\n\tv516 = v583 + v1245.Count;\n\tv534 = Spine.ExposedList`1<System.Single>::Resize(this.clippedVertices, v516);\n\tv497 = v534.Items;\n\tv535 = Spine.ExposedList`1<System.Single>::Resize(this.clippedUVs, v516);\n\tv358 = v1244.Count < 1;\n\tif (v358) goto L_0232;\n\tv585 = v535.Items;\nL_01BB:\n\tv304 = v252 + 1;\n\tv883 = v1245.Count + v252;\n\tv497[v883 @ X14_v21 (System.Int32)] = v573[v252 @ X11_v25 (System.Int32)];\n\tv1437 = v1245.Count + v252;\n\tv1438 = v1437 + 1;\n\tv497[v1438 @ X11_v27 (System.Int32)] = v573[v304 @ X10_v20 (System.Int32)];\n\tv1452 = v573[v252 @ X11_v25 (System.Int32)] - vertices[v872 @ X11_v8 (System.Int32)];\n\tv1453 = v573[v304 @ X10_v20 (System.Int32)] - vertices[v250 @ X11_v9 (System.Int32)];\n\tv1454 = v160 * v1452;\n\tv1455 = v156 * v1453;\n\tv1456 = v138 * v1452;\n\tv1457 = v152 * v1453;\n\tv1458 = v1454 + v1455;\n\tv1459 = v1456 + v1457;\n\tv871 = v134 * v1458;\n\tv869 = v134 * v1459;\n\tv1460 = 1f - v871;\n\tv1461 = uvs[v290 @ X12_v5 (System.Int32)] * v871;\n\tv1462 = uvs[v891 @ X12_v10 (System.Int32)] * v869;\n\tv925 = v1460 - v869;\n\tv1463 = v1461 + v1462;\n\tv863 = uvs[v872 @ X11_v8 (System.Int32)] * v925;\n\tv861 = v1463 + v863;\n\tv585[v883 @ X14_v21 (System.Int32)] = v861;\n\tv1468 = uvs[v581 @ X8_v15 (System.Int32)] * v871;\n\tv1360 = uvs[v291 @ X12_v11 (System.Int32)] * v869;\n\tv1366 = uvs[v250 @ X11_v9 (System.Int32)] * v925;\n\tv252 = v304 + 1;\n\tv1469 = v1468 + v1360;\n\tv1361 = v1469 + v1366;\n\tv585[v1438 @ X11_v27 (System.Int32)] = v1361;\n\tv1367 = v252 < v1244.Count;\n\tif (v1367) goto L_01BB;\nL_0232:\n\tv1173 = v1242.Count;\n\tv596 = v1244.Count >> 1;\n\tv316 = v596 << 1;\n\tv1381 = v596 + v316;\n\tv586 = v1381 + v1242.Count;\n\tv489 = v586 - 6;\n\tv536 = Spine.ExposedList`1<System.Int32>::Resize(this.clippedTriangles, v489);\n\tv361 = v1244.Count < 6;\n\tif (v361) goto L_02A1;\n\tv587 = v536.Items;\n\tv1415 = v596 - 3;\n\tv1416 = v1415 < 0;\n\tv1417 = v1415 == 0;\n\tv1418 = v596 ^ 3;\n\tv1419 = v596 ^ v1415;\n\tv1420 = v1418 & v1419;\n\tv1421 = v1420 < 0;\n\tv1423 = v1416 == v1421;\n\tv859 = ~v1417;\n\tv1424 = v1423 & v859;\n\tv858 = ~v1424;\n\tif (v858) goto L_FFFFFFFF;\n\tgoto L_0265;\nL_0265:\n\tv873 = v1434 - 2;\nL_0270:\n\tv893 = v1173 + 1;\n\tv587[v1173 @ X21_v15 (System.Int32)] = v1248;\n\tv1465 = v1248 + v919;\n\tv894 = v893 + 1;\n\tv880 = v1465 + 1;\n\tv587[v893 @ X12_v22 (System.Int32)] = v880;\n\tv1472 = v1173 + 2;\n\tv1473 = v1248 + v919;\n\tv919 = v919 + 1;\n\tv1399 = v1473 + 2;\n\tv1173 = v894 + 1;\n\tv587[v1472 @ X13_v18 (System.Int32)] = v1399;\n\tv1402 = v873 != v919;\n\tif (v1402) goto L_0270;\nL_02A1:\n\tv1248 = v596 + v1248;\n\tgoto L_02A5;\nL_02A5:\n\tv568 = v568 + 1;\n\tv1224 = v568 != v73.Count;\n\tif (v1224) goto L_0172;\n\tgoto L_03BD;\nL_02B4:\n\tv518 = v1245.Count + 6;\n\tv537 = Spine.ExposedList`1<System.Single>::Resize(this.clippedVertices, v518);\n\tv575 = v537.Items;\n\tv538 = Spine.ExposedList`1<System.Single>::Resize(this.clippedUVs, v518);\n\tv590 = v538.Items;\n\tv920 = v1245.Count + 1;\n\tv575[v595 @ X19_v11 (System.Int32)] = vertices[v290 @ X12_v5 (System.Int32)];\n\tv901 = v1245.Count + 2;\n\tv575[v920 @ X9_v16 (System.Int32)] = vertices[v581 @ X8_v15 (System.Int32)];\n\tv875 = v1245.Count + 3;\n\tv575[v901 @ X10_v13 (System.Int32)] = vertices[v891 @ X12_v10 (System.Int32)];\n\tv896 = v1245.Count + 4;\n\tv575[v875 @ X11_v14 (System.Int32)] = vertices[v291 @ X12_v11 (System.Int32)];\n\tv889 = v1245.Count + 5;\n\tv575[v896 @ X12_v16 (System.Int32)] = vertices[v872 @ X11_v8 (System.Int32)];\n\tv575[v889 @ X14_v10 (System.Int32)] = vertices[v250 @ X11_v9 (System.Int32)];\n\tv590[v595 @ X19_v11 (System.Int32)] = uvs[v290 @ X12_v5 (System.Int32)];\n\tv590[v920 @ X9_v16 (System.Int32)] = uvs[v581 @ X8_v15 (System.Int32)];\n\tv590[v901 @ X10_v13 (System.Int32)] = uvs[v891 @ X12_v10 (System.Int32)];\n\tv590[v875 @ X11_v14 (System.Int32)] = uvs[v291 @ X12_v11 (System.Int32)];\n\tv590[v896 @ X12_v16 (System.Int32)] = uvs[v872 @ X11_v8 (System.Int32)];\n\tv590[v889 @ X14_v10 (System.Int32)] = uvs[v250 @ X11_v9 (System.Int32)];\n\tv742 = 0x1854DA8(v538, v518, Il2CppMethodInfo, triangles, trianglesLength, uvs, methodInfo, v60, uvs[v250 @ X11_v9 (System.Int32)], uvs[v872 @ X11_v8 (System.Int32)], uvs[v291 @ X12_v11 (System.Int32)], uvs[v581 @ X8_v15 (System.Int32)], uvs[v290 @ X12_v5 (System.Int32)], vertices[v291 @ X12_v11 (System.Int32)], v1210, v1211);\n\treturn;\n\tX0 = X26;\n\tX1 = X19 + 3;\n\tX2 = *([1946000]);\n\tX0 = Spine.ExposedList`1<System.Int32>::Resize(X0, X1, X2);\n\tif (TEMP) goto L_FFFFFFFF;\n\tX8 = *([X0+10]);\n\tV2 = 1f;\n\tif (TEMP) goto L_FFFFFFFF;\n\tX9 = *([X8+18]);\n\tC = X19 < X9;\n\tC = ~C;\n\tTEMP1 = X19 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X19 ^ X9;\n\tTEMP3 = X19 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (C) goto L_FFFFFFFF;\n\tX10 = X19 + 1;\n\tTEMPSHIFT = X19 << 2;\n\tX11 = X8 + TEMPSHIFT;\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\t*([X11+20]) = X20;\n\tif (C) goto L_FFFFFFFF;\n\tTEMPSHIFT = X10 << 2;\n\tX12 = X8 + TEMPSHIFT;\n\tX10 = X19 + 2;\n\tX11 = X20 + 1;\n\tC = X10 < X9;\n\tC = ~C;\n\tTEMP1 = X10 - X9;\n\tN = TEMP1 < 0;\n\tTEMP2 = X10 ^ X9;\n\tTEMP3 = X10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\t*([X12+20]) = X11;\n\tif (C) goto L_FFFFFFFF;\n\tX9 = X20 + 2;\n\tTEMPSHIFT = X10 << 2;\n\tX8 = X8 + TEMPSHIFT;\n\tX20 = X20 + 3;\n\t*([X8+20]) = X9;\nL_03BD:\n\tv813 = v580 + 3;\n\tv815 = v813 < trianglesLength;\n\tif (v815) goto L_0076;\nL_03E0:\n\treturn;\n\tv529 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 784 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void ClipTriangles(float[] vertices, int verticesLength, int[] triangles, int trianglesLength, float[] uvs)
		{
			//IL_0373: Expected I4, but got I8
			ExposedList<ExposedList<float>> exposedList = clippingPolygons;
			ExposedList<float> exposedList2 = ClippedVertices;
			ExposedList<float>[] items = exposedList.Items;
			ExposedList<int> exposedList3 = ClippedTriangles;
			ClippedVertices.Clear();
			ClippedUVs.Clear();
			ClippedTriangles.Clear();
			if (trianglesLength < 1)
			{
				return;
			}
			float num = 1f;
			ExposedList<float> exposedList4 = clipOutput;
			int num2 = 0;
			int[] array = triangles;
			int num3 = 0;
			bool flag6;
			do
			{
				int num4 = array[num3] << 1;
				int num5 = num4 | 1;
				int num6 = num3 + 1;
				int num7 = array[num6] << 1;
				int num8 = num7 | 1;
				int num9 = num3 + 2;
				int num10 = array[num9] << 1;
				int num11 = num10 | 1;
				if (exposedList.Count >= 1)
				{
					float num12 = vertices[num8] - vertices[num11];
					float num13 = vertices[num10] - vertices[num7];
					float num14 = vertices[num4] - vertices[num10];
					float num15 = vertices[num5] - vertices[num11];
					float num16 = vertices[num11] - vertices[num5];
					float num17 = num14 * num12;
					float num18 = num13 * num15;
					float num19 = num17 + num18;
					float num20 = num / num19;
					float num21 = uvs[num5];
					float num22 = uvs[num4];
					int num23 = 0;
					do
					{
						int count = exposedList2.Count;
						if (Clip(vertices[num4], vertices[num5], vertices[num7], vertices[num8], vertices[num10], vertices[num11], items[num23], exposedList4))
						{
							if (exposedList4.Count != 0)
							{
								float[] items2 = exposedList4.Items;
								int num24 = (int)(exposedList4.Count & 0xFFFFFFFEL);
								int newSize = num24 + exposedList2.Count;
								ExposedList<float> exposedList5 = ClippedVertices.Resize(newSize);
								float[] items3 = exposedList5.Items;
								ExposedList<float> exposedList6 = ClippedUVs.Resize(newSize);
								if (exposedList4.Count >= 1)
								{
									float[] items4 = exposedList6.Items;
									int num25 = 0;
									do
									{
										int num26 = num25 + 1;
										int num27 = exposedList2.Count + num25;
										items3[num27] = items2[num25];
										int num28 = exposedList2.Count + num25;
										int num29 = num28 + 1;
										items3[num29] = items2[num26];
										float num30 = items2[num25] - vertices[num10];
										float num31 = items2[num26] - vertices[num11];
										float num32 = num12 * num30;
										float num33 = num13 * num31;
										float num34 = num16 * num30;
										float num35 = num14 * num31;
										float num36 = num32 + num33;
										float num37 = num34 + num35;
										float num38 = num20 * num36;
										float num39 = num20 * num37;
										float num40 = 1f - num38;
										float num41 = uvs[num4] * num38;
										float num42 = uvs[num7] * num39;
										float num43 = num40 - num39;
										float num44 = num41 + num42;
										float num45 = uvs[num10] * num43;
										float num46 = num44 + num45;
										items4[num27] = num46;
										float num47 = uvs[num5] * num38;
										float num48 = uvs[num8] * num39;
										float num49 = uvs[num11] * num43;
										num25 = num26 + 1;
										float num50 = num47 + num48;
										float num51 = num50 + num49;
										items4[num29] = num51;
									}
									while (num25 < exposedList4.Count);
								}
								int num52 = exposedList3.Count;
								int num53 = exposedList4.Count >> 1;
								int num54 = num53 << 1;
								int num55 = num53 + num54;
								int num56 = num55 + exposedList3.Count;
								int newSize2 = num56 - 6;
								ExposedList<int> exposedList7 = ClippedTriangles.Resize(newSize2);
								if (exposedList4.Count >= 6)
								{
									int[] items5 = exposedList7.Items;
									int num57 = num53 - 3;
									bool flag = num57 < 0;
									bool flag2 = num57 == 0;
									int num58 = num53 ^ 3;
									int num59 = num53 ^ num57;
									int num60 = num58 & num59;
									bool flag3 = num60 < 0;
									bool flag4 = flag == flag3;
									bool flag5 = !flag2;
									int num61 = ((!(flag4 && flag5)) ? 3 : num53);
									int num62 = num61 - 2;
									int num63 = 0;
									do
									{
										int num64 = num52 + 1;
										items5[num52] = num2;
										int num65 = num2 + num63;
										int num66 = num64 + 1;
										int num67 = num65 + 1;
										items5[num64] = num67;
										int num68 = num52 + 2;
										int num69 = num2 + num63;
										num63++;
										int num70 = num69 + 2;
										num52 = num66 + 1;
										items5[num68] = num70;
									}
									while (num62 != num63);
								}
								num2 = num53 + num2;
								num21 = uvs[num11];
								num22 = uvs[num10];
								num = 1f;
								exposedList4 = clipOutput;
							}
							else
							{
								num = 1f;
							}
							num23++;
							continue;
						}
						int newSize3 = exposedList2.Count + 6;
						ExposedList<float> exposedList8 = ClippedVertices.Resize(newSize3);
						float[] items6 = exposedList8.Items;
						ExposedList<float> exposedList9 = ClippedUVs.Resize(newSize3);
						float[] items7 = exposedList9.Items;
						int num71 = exposedList2.Count + 1;
						items6[count] = vertices[num4];
						int num72 = exposedList2.Count + 2;
						items6[num71] = vertices[num5];
						int num73 = exposedList2.Count + 3;
						items6[num72] = vertices[num7];
						int num74 = exposedList2.Count + 4;
						items6[num73] = vertices[num8];
						int num75 = exposedList2.Count + 5;
						items6[num74] = vertices[num10];
						items6[num75] = vertices[num11];
						items7[count] = uvs[num4];
						items7[num71] = uvs[num5];
						items7[num72] = uvs[num7];
						items7[num73] = uvs[num8];
						items7[num74] = uvs[num10];
						items7[num75] = uvs[num11];
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1854DA8 (inside System.__Il2CppComDelegate::Finalize +0x194)");
						return;
					}
					while (num23 != exposedList.Count);
				}
				int num76 = num3 + 3;
				flag6 = num76 < trianglesLength;
				array = triangles;
				num3 = num76;
			}
			while (flag6);
		}

		[Token(Token = "0x60003A2")]
		[Address(RVA = "0x15400C4", Offset = "0x15400C4", Length = "0x5D0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0036;\n\tv64 = Il2CppMethodInfo;\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, clippingArea, output, methodInfo, v67, v68, v69, v70, x1, y1, x2, y2, x3, y3, v71, v72);\n\tv79 = Il2CppMethodInfo;\n\tv80 = \"il2cpp_codegen_initialize_runtime_metadata\"(v79, clippingArea, output, methodInfo, v67, v68, v69, v70, x1, y1, x2, y2, x3, y3, v71, v72);\n\tv402 = Il2CppMethodInfo;\n\tv403 = \"il2cpp_codegen_initialize_runtime_metadata\"(v402, clippingArea, output, methodInfo, v67, v68, v69, v70, x1, y1, x2, y2, x3, y3, v71, v72);\n\tv407 = System.Math;\n\tv74 = \"il2cpp_codegen_initialize_runtime_metadata\"(v407, clippingArea, output, methodInfo, v67, v68, v69, v70, x1, y1, x2, y2, x3, y3, v71, v72);\n\tv76 = 1;\n\t*([1A37B97]) = v76;\nL_0036:\n\tv408 = clippingArea.Count + 3;\n\tv87 = clippingArea.Count < 0;\n\tv90 = clippingArea.Count ^ clippingArea.Count;\n\tv91 = clippingArea.Count & v90;\n\tv92 = v91 < 0;\n\tv93 = v87 == v92;\n\tv94 = ~v93;\n\tv95 = ~v94;\n\tif (v95) goto L_FFFFFFFF;\n\tgoto L_0048;\nL_0048:\n\tv320 = v408 & 0xFFFFFFFC;\n\tv388 = clippingArea.Count - v320;\n\tv304 = v388 - 2;\n\tv296 = v304 < 0;\n\tv280 = v388 ^ 2;\n\tv272 = v388 ^ v304;\n\tv264 = v280 & v272;\n\tv256 = v264 < 0;\n\tv410 = v296 == v256;\n\tv411 = ~v410;\n\tv412 = ~v411;\n\tif (v412) goto L_FFFFFFFF;\n\tgoto L_005B;\nL_005B:\n\tv530 = v296 == v256;\n\tv248 = ~v530;\n\tv245 = ~v248;\n\tif (v245) goto L_FFFFFFFF;\n\tgoto L_006C;\nL_006C:\n\tSpine.ExposedList`1<System.Single>::Clear(v613, 1);\n\tSpine.ExposedList`1<System.Single>::Add(v613, x1);\n\tSpine.ExposedList`1<System.Single>::Add(v613, y1);\n\tSpine.ExposedList`1<System.Single>::Add(v613, x2);\n\tSpine.ExposedList`1<System.Single>::Add(v613, y2);\n\tSpine.ExposedList`1<System.Single>::Add(v613, x3);\n\tSpine.ExposedList`1<System.Single>::Add(v613, y3);\n\tSpine.ExposedList`1<System.Single>::Add(v613, x1);\n\tSpine.ExposedList`1<System.Single>::Add(v613, y1);\n\tSpine.ExposedList`1<System.Single>::Clear(v354, 1);\n\tv389 = clippingArea.Items;\n\tv566 = clippingArea.Count - 4;\nL_00A6:\n\tv321 = v201 | 1;\n\tv241 = v201 + 2;\n\tv329 = v201 + 3;\n\tv385 = v613.Count - 2;\n\tv249 = v385 < 1;\n\tif (v249) goto L_0237;\n\tv397 = v613.Items;\n\tv835 = v389[v201 @ X28_v7 (System.Int32)] - v389[v241 @ X22_v8 (System.Int32)];\n\tv836 = v389[v321 @ X9_v12 (System.Int32)] - v389[v329 @ X10_v8 (System.Int32)];\n\tv837 = v389[v241 @ X22_v8 (System.Int32)] - v389[v201 @ X28_v7 (System.Int32)];\n\tv838 = v389[v329 @ X10_v8 (System.Int32)] - v389[v321 @ X9_v12 (System.Int32)];\nL_00FE:\n\tv708 = v740 + 1;\n\tv175 = v708 + 1;\n\tv110 = v175 + 1;\n\tv330 = v740 + 2;\n\tv867 = v740 + 3;\n\tv872 = v397[v708 @ X9_v16 (System.Int32)] - v389[v329 @ X10_v8 (System.Int32)];\n\tv873 = v397[v740 @ X8_v14 (System.Int32)] - v389[v241 @ X22_v8 (System.Int32)];\n\tv874 = v1093 * v872;\n\tv875 = v1024 * v873;\n\tv876 = v397[v867 @ X8_v15 (System.Int32)] - v389[v329 @ X10_v8 (System.Int32)];\n\tv877 = v874 - v875;\n\tv878 = v397[v330 @ X10_v13 (System.Int32)] - v389[v241 @ X22_v8 (System.Int32)];\n\tv879 = v1093 * v876;\n\tv880 = v1024 * v878;\n\tv890 = v879 - v880;\n\tv893 = v877 <= 0;\n\tif (v893) goto L_0161;\n\tv905 = v890 <= 0;\n\tif (v905) goto L_0195;\n\tSpine.ExposedList`1<System.Single>::Add(v354, v397[v330 @ X10_v13 (System.Int32)]);\n\tgoto L_01D7;\nL_0161:\n\tv917 = v890 <= 0;\n\tif (v917) goto L_FFFFFFFF;\n\tgoto L_016B;\n\tv944 = \"il2cpp_codegen_runtime_class_init\"(v925, v610, v223, methodInfo, v67, v68, v69, v70, v890, v880, v879, v581, v568, v570, v583, v72);\n\tv946 = v130;\n\tv948 = v125;\nL_016B:\n\tv950 = v397[v867 @ X8_v15 (System.Int32)] - v397[v708 @ X9_v16 (System.Int32)];\n\tv951 = v397[v330 @ X10_v13 (System.Int32)] - v397[v740 @ X8_v14 (System.Int32)];\n\tv953 = v143 * v950;\n\tv955 = v139 * v951;\n\tv956 = v953 - v955;\n\tv957 = UnityEngine.Mathf::Abs(v956);\n\tv1050 = v957 <= 1E-06f;\n\tif (v1050) goto L_01C3;\n\tv1071 = v389[v321 @ X9_v12 (System.Int32)] - v397[v708 @ X9_v16 (System.Int32)];\n\tv1072 = v389[v201 @ X28_v7 (System.Int32)] - v397[v740 @ X8_v14 (System.Int32)];\n\tv1073 = v1071 * v951;\n\tv1074 = v1072 * v950;\n\tv1075 = v1073 - v1074;\n\tv1076 = v1075 / v956;\n\tv1077 = v143 * v1076;\n\tv1078 = v389[v201 @ X28_v7 (System.Int32)] + v1077;\n\tSpine.ExposedList`1<System.Single>::Add(v354, v1078);\n\tv1085 = v139 * v1076;\n\tv1100 = v389[v321 @ X9_v12 (System.Int32)] + v1085;\n\tgoto L_01C7;\nL_0195:\n\tgoto L_0199;\n\tv930 = \"il2cpp_codegen_runtime_class_init\"(v921, v610, v223, methodInfo, v67, v68, v69, v70, v890, v880, v879, v581, v568, v570, v583, v72);\n\tv932 = v130;\n\tv934 = v125;\nL_0199:\n\tv936 = v397[v867 @ X8_v15 (System.Int32)] - v397[v708 @ X9_v16 (System.Int32)];\n\tv937 = v397[v330 @ X10_v13 (System.Int32)] - v397[v740 @ X8_v14 (System.Int32)];\n\tv939 = v143 * v936;\n\tv941 = v139 * v937;\n\tv942 = v939 - v941;\n\tv943 = UnityEngine.Mathf::Abs(v942);\n\tv1038 = v943 <= 1E-06f;\n\tif (v1038) goto L_01D1;\n\tv1056 = v389[v321 @ X9_v12 (System.Int32)] - v397[v708 @ X9_v16 (System.Int32)];\n\tv1057 = v389[v201 @ X28_v7 (System.Int32)] - v397[v740 @ X8_v14 (System.Int32)];\n\tv1058 = v1056 * v937;\n\tv1059 = v1057 * v936;\n\tv1060 = v1058 - v1059;\n\tv1061 = v1060 / v942;\n\tv1062 = v143 * v1061;\n\tv1063 = v389[v201 @ X28_v7 (System.Int32)] + v1062;\n\tSpine.ExposedList`1<System.Single>::Add(v354, v1063);\n\tv1082 = v139 * v1061;\n\tv988 = v389[v321 @ X9_v12 (System.Int32)] + v1082;\n\tgoto L_FFFFFFFF;\n\tgoto L_01DA;\nL_01C3:\n\tSpine.ExposedList`1<System.Single>::Add(v354, v389[v201 @ X28_v7 (System.Int32)]);\nL_01C7:\n\tSpine.ExposedList`1<System.Single>::Add(v354, v1100);\n\tSpine.ExposedList`1<System.Single>::Add(v354, v397[v330 @ X10_v13 (System.Int32)]);\n\tgoto L_FFFFFFFF;\nL_01D1:\n\tSpine.ExposedList`1<System.Single>::Add(v354, v389[v201 @ X28_v7 (System.Int32)]);\nL_01D7:\n\tSpine.ExposedList`1<System.Single>::Add(v354, v988);\nL_01DA:\n\tv740 = v110 - 1;\n\tv250 = v740 < v385;\n\tif (v250) goto L_00FE;\n\tv290 = v354.Count == v354.Count;\n\tif (v290) goto L_0237;\n\tv391 = v354.Items;\n\tSpine.ExposedList`1<System.Single>::Add(v354, v391[0]);\n\tv392 = v354.Items;\n\tSpine.ExposedList`1<System.Single>::Add(v354, v392[1]);\n\tv292 = v201 == v566;\n\tif (v292) goto L_0256;\n\tSpine.ExposedList`1<System.Single>::Clear(v613, 1);\n\tv1109 = v241 < v389.Length;\n\tv696 = ~v1109;\n\tv615 = ~v696;\n\tif (v615) goto L_00A6;\n\tthrow System.IndexOutOfRangeException;\nL_0237:\n\tSpine.ExposedList`1<System.Single>::Clear(output, 1);\nL_0238:\n\treturnVal2 = v768 & 1;\n\treturn returnVal2;\nL_0256:\n\tv793 = v354 == output;\n\tif (v793) goto L_0295;\n\tSpine.ExposedList`1<System.Single>::Clear(output, 1);\n\tv817 = v354.Count - 2;\n\tv777 = v817 < 1;\n\tif (v777) goto L_0238;\nL_0270:\n\tv395 = v354.Items;\n\tSpine.ExposedList`1<System.Single>::Add(output, v395[v399 @ X19_v10 (System.Int32)]);\n\tv399 = v399 + 1;\n\tv778 = v817 != v399;\n\tif (v778) goto L_0270;\n\tgoto L_0238;\nL_0295:\n\tv775 = output.Count - 2;\n\tv807 = Spine.ExposedList`1<System.Single>::Resize(output, v775);\n\tgoto L_0238;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 490 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal bool Clip(float x1, float y1, float x2, float y2, float x3, float y3, ExposedList<float> clippingArea, ExposedList<float> output)
		{
			//IL_08df: Expected I4, but got I8
			int num = clippingArea.Count + 3;
			bool flag = clippingArea.Count < 0;
			int num2 = clippingArea.Count ^ clippingArea.Count;
			int num3 = clippingArea.Count & num2;
			bool flag2 = num3 < 0;
			if (flag == flag2)
			{
				num = clippingArea.Count;
			}
			int num4 = (int)(num & 0xFFFFFFFCL);
			int num5 = clippingArea.Count - num4;
			int num6 = num5 - 2;
			bool flag3 = num6 < 0;
			int num7 = num5 ^ 2;
			int num8 = num5 ^ num6;
			int num9 = num7 & num8;
			bool flag4 = num9 < 0;
			ExposedList<float> exposedList = ((flag3 == flag4) ? output : scratch);
			ExposedList<float> exposedList2 = ((flag3 == flag4) ? scratch : output);
			exposedList.Clear();
			exposedList.Add(x1);
			exposedList.Add(y1);
			exposedList.Add(x2);
			exposedList.Add(y2);
			exposedList.Add(x3);
			exposedList.Add(y3);
			exposedList.Add(x1);
			exposedList.Add(y1);
			exposedList2.Clear();
			float[] items = clippingArea.Items;
			int num10 = clippingArea.Count - 4;
			int num11 = 0;
			int num12 = 0;
			while (true)
			{
				int num13 = num12 | 1;
				int num14 = num12 + 2;
				int num15 = num12 + 3;
				int num16 = exposedList.Count - 2;
				if (num16 >= 1)
				{
					float[] items2 = exposedList.Items;
					float num17 = items[num12] - items[num14];
					float num18 = items[num13] - items[num15];
					float num19 = items[num14] - items[num12];
					float num20 = items[num15] - items[num13];
					float num21 = num20;
					float num22 = num19;
					float num23 = num17;
					float num24 = num18;
					int num25 = 0;
					do
					{
						int num26 = num25 + 1;
						int num27 = num26 + 1;
						int num28 = num27 + 1;
						int num29 = num25 + 2;
						int num30 = num25 + 3;
						float num31 = items2[num26] - items[num15];
						float num32 = items2[num25] - items[num14];
						float num33 = num23 * num31;
						float num34 = num24 * num32;
						float num35 = items2[num30] - items[num15];
						float num36 = num33 - num34;
						float num37 = items2[num29] - items[num14];
						float num38 = num23 * num35;
						float num39 = num24 * num37;
						float num40 = num38 - num39;
						float item;
						if (num36 > 0f)
						{
							if (num40 > 0f)
							{
								exposedList2.Add(items2[num29]);
								item = items2[num30];
								goto IL_09a9;
							}
							float num41 = items2[num30] - items2[num26];
							float num42 = items2[num29] - items2[num25];
							float num43 = num22 * num41;
							float num44 = num21 * num42;
							float num45 = num43 - num44;
							float num46 = Mathf.Abs(num45);
							if (num46 > 1E-06f)
							{
								float num47 = items[num13] - items2[num26];
								float num48 = items[num12] - items2[num25];
								float num49 = num47 * num42;
								float num50 = num48 * num41;
								float num51 = num49 - num50;
								float num52 = num51 / num45;
								float num53 = num22 * num52;
								float item2 = items[num12] + num53;
								exposedList2.Add(item2);
								float num54 = num21 * num52;
								item = items[num13] + num54;
							}
							else
							{
								exposedList2.Add(items[num12]);
								item = items[num13];
							}
						}
						else
						{
							if (!(num40 > 0f))
							{
								num11 = 1;
								goto IL_0b56;
							}
							float num55 = items2[num30] - items2[num26];
							float num56 = items2[num29] - items2[num25];
							float num57 = num22 * num55;
							float num58 = num21 * num56;
							float num59 = num57 - num58;
							float num60 = Mathf.Abs(num59);
							float item4;
							if (num60 > 1E-06f)
							{
								float num61 = items[num13] - items2[num26];
								float num62 = items[num12] - items2[num25];
								float num63 = num61 * num56;
								float num64 = num62 * num55;
								float num65 = num63 - num64;
								float num66 = num65 / num59;
								float num67 = num22 * num66;
								float item3 = items[num12] + num67;
								exposedList2.Add(item3);
								float num68 = num21 * num66;
								item4 = items[num13] + num68;
								num23 = num17;
							}
							else
							{
								exposedList2.Add(items[num12]);
								item4 = items[num13];
							}
							exposedList2.Add(item4);
							exposedList2.Add(items2[num29]);
							item = items2[num30];
							num24 = num18;
						}
						num11 = 1;
						goto IL_09a9;
						IL_09a9:
						exposedList2.Add(item);
						num21 = num20;
						num22 = num19;
						goto IL_0b56;
						IL_0b56:
						num25 = num28 - 1;
					}
					while (num25 < num16);
					if (exposedList2.Count != exposedList2.Count)
					{
						float[] items3 = exposedList2.Items;
						exposedList2.Add(items3[0]);
						float[] items4 = exposedList2.Items;
						exposedList2.Add(items4[1]);
						if (num12 != num10)
						{
							exposedList.Clear();
							bool flag5 = num14 < items.Length;
							bool flag6 = !flag5;
							bool flag7 = !flag6;
							num12 = num14;
							exposedList = exposedList2;
							exposedList2 = exposedList2;
							if (!flag7)
							{
								throw new IndexOutOfRangeException();
							}
							continue;
						}
						if (exposedList2 != output)
						{
							output.Clear();
							int num69 = exposedList2.Count - 2;
							if (num69 >= 1)
							{
								int num70 = 0;
								do
								{
									float[] items5 = exposedList2.Items;
									output.Add(items5[num70]);
									num70++;
								}
								while (num69 != num70);
							}
						}
						else
						{
							int newSize = output.Count - 2;
							ExposedList<float> exposedList3 = output.Resize(newSize);
						}
						break;
					}
				}
				output.Clear();
				num11 = 1;
				break;
			}
			return (byte)(num11 & 1) != 0;
		}

		[Token(Token = "0x60003A3")]
		[Address(RVA = "0x153E664", Offset = "0x153E664", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = polygon.Items;\n\tv207 = polygon.Count - 2;\n\tv146 = polygon.Count - 1;\n\tv131 = v4[0];\n\tv147 = polygon.Count - 3;\n\tv277 = v4[v207 @ X10_v5 (System.Int32)] * v4[1];\n\tv278 = v4[0] * v4[v146 @ X12_v3 (System.Int32)];\n\tv292 = v277 - v278;\n\tv281 = v147 < 1;\n\tif (v281) goto L_0076;\nL_0044:\n\tv140 = v137 + 2;\n\tv123 = v137 + 3;\n\tv363 = v137 + 1;\n\tv367 = v131 * v4[v123 @ X15_v8 (System.Int32)];\n\tv289 = v4[v363 @ X14_v11 (System.Int32)] * v4[v140 @ X13_v11 (System.Int32)];\n\tv368 = v367 - v289;\n\tv292 = v134 + v368;\n\tv300 = v140 < v147;\n\tif (v300) goto L_0044;\nL_0076:\n\tv320 = v292 < 0;\n\tif (v320) goto L_00D4;\n\tv346 = polygon.Count < 2;\n\tif (v346) goto L_00D4;\n\tv208 = polygon.Count >> 1;\nL_0096:\n\tv139 = v141 + 1;\n\tv381 = v141 << 2;\n\tv125 = v4 + v381;\n\tv145 = v207 << 2;\n\tv382 = v4 + v145;\n\tv121 = v382 + 0x20;\n\tv142 = v207 + 1;\n\tv4[v141 @ X13_v7 (System.Int32)] = *([v121 @ X16_v7]);\n\tv349 = v139 + 1;\n\tv384 = v349 < v208;\n\tv359 = ~v384;\n\tv207 = v207 - 2;\n\t*([v125 @ X15_v6+24]) = v4[v142 @ X13_v8 (System.Int32)];\n\t*([v121 @ X16_v7]) = v4[v141 @ X13_v7 (System.Int32)];\n\tv4[v142 @ X13_v8 (System.Int32)] = *([v125 @ X15_v6+24]);\n\tv351 = ~v359;\n\tif (v351) goto L_0096;\nL_00D4:\n\treturn;\n\tv7 = new System.IndexOutOfRangeException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 171 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void MakeClockwise(ExposedList<float> polygon)
		{
			//IL_0233: Expected O, but got I
			//IL_024f: Expected O, but got I
			//IL_025e: Expected O, but got I
			//IL_027d: Expected F4, but got O
			//IL_02d6: Expected O, but got F4
			//IL_02ef: Expected F4, but got I
			float[] items = polygon.Items;
			int num = polygon.Count - 2;
			int num2 = polygon.Count - 1;
			float num3 = items[0];
			int num4 = polygon.Count - 3;
			float num5 = items[num] * items[1];
			float num6 = items[0] * items[num2];
			float num7 = num5 - num6;
			if (num4 >= 1)
			{
				float num8 = num7;
				int num9 = 0;
				bool flag;
				do
				{
					int num10 = num9 + 2;
					int num11 = num9 + 3;
					int num12 = num9 + 1;
					float num13 = num3 * items[num11];
					float num14 = items[num12] * items[num10];
					float num15 = num13 - num14;
					num7 = num8 + num15;
					flag = num10 < num4;
					num3 = items[num10];
					num8 = num7;
					num9 = num10;
				}
				while (flag);
			}
			if (!(num7 < 0f) && polygon.Count >= 2)
			{
				int num16 = polygon.Count >> 1;
				int num17 = 0;
				bool flag4;
				do
				{
					int num18 = num17 + 1;
					int num19 = num17 << 2;
					object obj = (nint)items + num19;
					int num20 = num << 2;
					object obj2 = (nint)items + num20;
					object obj3 = (nint)obj2 + 32;
					int num21 = num + 1;
					items[num17] = (float)obj3;
					int num22 = num18 + 1;
					bool flag2 = num22 < num16;
					bool flag3 = !flag2;
					num -= 2;
					_ = items[num21];
					obj3 = items[num17];
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ X15_v6+24]");
					items[num21] = 0f;
					flag4 = !flag3;
					num17 = num22;
				}
				while (flag4);
			}
		}

		[Token(Token = "0x60003A4")]
		[Address(RVA = "0x1540694", Offset = "0x1540694", Length = "0x178")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0032;\n\tv38 = Il2CppMethodInfo;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv62 = Il2CppMethodInfo;\n\tv63 = \"il2cpp_codegen_initialize_runtime_metadata\"(v62, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv66 = Il2CppMethodInfo;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv71 = Spine.ExposedList`1<System.Int32>;\n\tv72 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv76 = Spine.ExposedList`1<System.Single>;\n\tv77 = \"il2cpp_codegen_initialize_runtime_metadata\"(v76, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv81 = Spine.Triangulator;\n\tv56 = \"il2cpp_codegen_initialize_runtime_metadata\"(v81, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv58 = 1;\n\t*([1A37B98]) = v58;\nL_0032:\n\tv60 = new Spine.Triangulator();\n\tSpine.Triangulator::.ctor(v60);\n\tthis.triangulator = v60;\n\tv69 = new Spine.ExposedList`1<System.Single>();\n\tSpine.ExposedList`1<System.Single>::.ctor(v69);\n\tthis.clippingPolygon = v69;\n\tv79 = new Spine.ExposedList`1<System.Single>();\n\tSpine.ExposedList`1<System.Single>::.ctor(v79, 0x80);\n\tthis.clipOutput = v79;\n\tv86 = new Spine.ExposedList`1<System.Single>();\n\tSpine.ExposedList`1<System.Single>::.ctor(v86, 0x80);\n\tthis.clippedVertices = v86;\n\tv91 = new Spine.ExposedList`1<System.Int32>();\n\tSpine.ExposedList`1<System.Int32>::.ctor(v91, 0x80);\n\tthis.clippedTriangles = v91;\n\tv96 = new Spine.ExposedList`1<System.Single>();\n\tSpine.ExposedList`1<System.Single>::.ctor(v96, 0x80);\n\tthis.clippedUVs = v96;\n\tv101 = new Spine.ExposedList`1<System.Single>();\n\tSpine.ExposedList`1<System.Single>::.ctor(v101);\n\tthis.scratch = v101;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkeletonClipping()
		{
			//IL_001f: Expected O, but got I4
			//IL_003d: Expected O, but got I4
			//IL_005b: Expected O, but got I4
			//IL_0079: Expected O, but got I4
			base._002Ector();
			Triangulator triangulator = new Triangulator();
			this.triangulator = triangulator;
			ExposedList<float> exposedList = new ExposedList<float>();
			clippingPolygon = exposedList;
			ExposedList<float> exposedList2 = new ExposedList<float>((IEnumerable<float>)128);
			clipOutput = exposedList2;
			ExposedList<float> exposedList3 = new ExposedList<float>((IEnumerable<float>)128);
			clippedVertices = exposedList3;
			ExposedList<int> exposedList4 = new ExposedList<int>((IEnumerable<int>)128);
			clippedTriangles = exposedList4;
			ExposedList<float> exposedList5 = new ExposedList<float>((IEnumerable<float>)128);
			clippedUVs = exposedList5;
			ExposedList<float> exposedList6 = new ExposedList<float>();
			scratch = exposedList6;
		}
	}
}
