using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine.Unity
{
	[Token(Token = "0x20000AE")]
	public class SkeletonRendererInstruction
	{
		[Token(Token = "0x4000417")]
		[FieldOffset(Offset = "0x10")]
		public readonly ExposedList<SubmeshInstruction> submeshInstructions;

		[Token(Token = "0x4000418")]
		[FieldOffset(Offset = "0x18")]
		public bool immutableTriangles;

		[Token(Token = "0x4000419")]
		[FieldOffset(Offset = "0x19")]
		public bool hasActiveClipping;

		[Token(Token = "0x400041A")]
		[FieldOffset(Offset = "0x1C")]
		public int rawVertexCount;

		[Token(Token = "0x400041B")]
		[FieldOffset(Offset = "0x20")]
		public readonly ExposedList<Attachment> attachments;

		[Token(Token = "0x6000698")]
		[Address(RVA = "0x15647D0", Offset = "0x15647D0", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv38 = Il2CppMethodInfo;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A37CD8]) = v34;\nL_001A:\n\tSpine.ExposedList`1<Spine.Attachment>::Clear(this.attachments, 0);\n\tthis.rawVertexCount = 0xFFFFFFFF;\n\tthis.hasActiveClipping = 0;\n\tSpine.ExposedList`1<Spine.Unity.SubmeshInstruction>::Clear(this.submeshInstructions, 0);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 31 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Clear()
		{
			attachments.Clear(clearArray: false);
			rawVertexCount = -1;
			hasActiveClipping = false;
			submeshInstructions.Clear(clearArray: false);
		}

		[Token(Token = "0x6000699")]
		[Address(RVA = "0x156FC08", Offset = "0x156FC08", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv14 = Il2CppMethodInfo;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, methodInfo, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv33 = 1;\n\t*([1A37CD9]) = v33;\nL_001B:\n\tSpine.ExposedList`1<Spine.Attachment>::Clear(this.attachments, 1);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Dispose()
		{
			attachments.Clear();
		}

		[Token(Token = "0x600069A")]
		[Address(RVA = "0x1564B0C", Offset = "0x1564B0C", Length = "0x310")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv36 = Il2CppMethodInfo;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v36, instructions, startSubmesh, endSubmesh, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv57 = Il2CppMethodInfo;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, instructions, startSubmesh, endSubmesh, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv281 = Il2CppMethodInfo;\n\tv282 = \"il2cpp_codegen_initialize_runtime_metadata\"(v281, instructions, startSubmesh, endSubmesh, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv389 = Il2CppMethodInfo;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v389, instructions, startSubmesh, endSubmesh, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv53 = 1;\n\t*([1A37CDA]) = v53;\nL_0025:\n\tv54 = this.submeshInstructions;\n\tSpine.ExposedList`1<Spine.Unity.SubmeshInstruction>::Clear(this.submeshInstructions, 0);\n\tv237 = endSubmesh - startSubmesh;\n\tv240 = Spine.ExposedList`1<Spine.Unity.SubmeshInstruction>::Resize(this.submeshInstructions, v237);\n\tv263 = instructions.Items;\n\tv166 = v237 < 1;\n\tif (v166) goto L_00A0;\n\tv138 = v54.Items + 0x4D;\nL_004E:\n\tv308 = startSubmesh + v151;\n\tv608 = v308 * 0x30;\n\tv609 = instructions.Items + v608;\n\t*([v138 @ X13_v7-9]) = *([v609 @ X16_v8+44]);\n\t*([v138 @ X13_v7-1]) = *([v609 @ X16_v8+4C]);\n\t*([v138 @ X13_v7-D]) = *([v609 @ X16_v8+40]);\n\t*([v138 @ X13_v7-1D]) = *([v609 @ X16_v8+30]);\n\t*([v138 @ X13_v7-2D]) = *([v609 @ X16_v8+20]);\n\tv620 = *([v609 @ X16_v8+4C]) & 1;\n\tv151 = v151 + 1;\n\t*([v138 @ X13_v7+2]) = *([v609 @ X16_v8+4F]);\n\t*([v138 @ X13_v7]) = *([v609 @ X16_v8+4D]);\n\tv512 = this.hasActiveClipping | v620;\n\tthis.hasActiveClipping = v512;\n\t*([v138 @ X13_v7-5]) = v274;\n\tv274 = *([v609 @ X16_v8+44]) + v274;\n\tv138 = v138 + 0x30;\n\tv521 = v237 != v151;\n\tif (v521) goto L_004E;\n\tthis.rawVertexCount = v274;\n\tgoto L_00B0;\nL_00A0:\n\tthis.rawVertexCount = 0;\nL_00B0:\n\tv275 = endSubmesh - 1;\n\tv615 = startSubmesh * 0x30;\n\tv163 = instructions.Items + v615;\n\tv616 = v275 * 0x30;\n\tv276 = instructions.Items + v616;\n\tSpine.ExposedList`1<Spine.Attachment>::Clear(this.attachments, 0);\n\tv267 = *([v276 @ X8_v12+2C]) - *([v163 @ X10_v7+28]);\n\tv493 = Spine.ExposedList`1<Spine.Attachment>::Resize(this.attachments, v267);\n\tv277 = this.attachments;\n\tv154 = *([v263 @ X22_v6 (Spine.Unity.SubmeshInstruction[])+20]);\n\tv155 = v154.rawFirstVertexIndex;\n\tv169 = v267 < 1;\n\tif (v169) goto L_0138;\n\tv238 = v277.Items;\nL_00F4:\n\tv385 = *([v163 @ X10_v7+28]) + v272;\n\tv68 = v385 << 3;\n\tv665 = *([v155 @ X9_v11 (System.Int32)+10]) + v68;\n\tv278 = *([v665 @ X8_v20+20]);\n\tv157 = *([v278 @ X8_v21+18]);\n\tv666 = *([v157 @ X9_v16+85]) == 0;\n\tif (v666) goto L_0121;\n\tv676 = *([v278 @ X8_v21+40]) == 0;\n\tif (v676) goto L_0120;\n\t// 274 IsInst v370 @ X0_v21 (Spine.ExposedList`1<Spine.Attachment>), typeof(Spine.Attachment), [v278 @ X8_v21+40]\n\tv430 = v370 == 0;\n\tif (v430) goto L_0147;\nL_0120:\n\tv238[v272 @ X23_v10 (System.Int32)] = *([v278 @ X8_v21+40]);\nL_0121:\n\tv272 = v272 + 1;\n\tv628 = v267 != v272;\n\tif (v628) goto L_00F4;\nL_0138:\n\tv471 = *([v19 @ SYSREG+28]) != *([v19 @ SYSREG+28]);\n\tif (v471) goto L_014A;\n\treturn;\n\tv279 = new System.NullReferenceException();\n\tv387 = new System.IndexOutOfRangeException();\nL_0147:\n\tv438 = new System.ArrayTypeMismatchException();\n\tthrow v438;\nL_014A:\n\tv508 = 0x1854EB0(v493, v489, Il2CppMethodInfo, endSubmesh, methodInfo, v39, v40, v41, *([v609 @ X16_v8+44]), *([v609 @ X16_v8+20]), *([v609 @ X16_v8+30]), v45, v46, v47, v48, v49);\n\treturn;\n// 252 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetWithSubset(ExposedList<SubmeshInstruction> instructions, int startSubmesh, int endSubmesh)
		{
			//IL_0078: Expected O, but got I
			//IL_01eb: Expected O, but got I
			//IL_020c: Expected O, but got I
			//IL_00b0: Expected O, but got I
			//IL_0270: Expected O, but got I
			//IL_0137: Expected O, but got I
			//IL_0179: Expected O, but got I
			//IL_0492: Expected O, but got I
			//IL_02fb: Expected O, but got I
			//IL_030b: Expected O, but got I
			//IL_0320: Expected O, but got I
			//IL_03c8: Expected O, but got I
			//IL_0380: Expected O, but got I
			//IL_03a1: Expected I4, but got O
			ExposedList<SubmeshInstruction> exposedList = submeshInstructions;
			submeshInstructions.Clear(clearArray: false);
			int num = endSubmesh - startSubmesh;
			ExposedList<SubmeshInstruction> exposedList2 = submeshInstructions.Resize(num);
			SubmeshInstruction[] items = instructions.Items;
			if (num >= 1)
			{
				object obj = (nint)exposedList.Items + 77;
				int num2 = 0;
				int num3 = 0;
				do
				{
					int num4 = startSubmesh + num2;
					int num5 = num4 * 48;
					object obj2 = (nint)instructions.Items + num5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ X16_v8+44]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ X16_v8+4C]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ X16_v8+40]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ X16_v8+30]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ X16_v8+20]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ X16_v8+4C]");
					int num6 = (int)((nint)0 & (nint)1);
					num2++;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ X16_v8+4F]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ X16_v8+4D]");
					obj = 0;
					int num7 = (hasActiveClipping ? 1 : 0) | num6;
					hasActiveClipping = (byte)num7 != 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v609 @ X16_v8+44]");
					num3 = (int)((nint)0 + (nint)num3);
					obj = (nint)obj + 48;
				}
				while (num != num2);
				rawVertexCount = num3;
			}
			else
			{
				rawVertexCount = 0;
			}
			int num8 = endSubmesh - 1;
			int num9 = startSubmesh * 48;
			object obj3 = (nint)instructions.Items + num9;
			int num10 = num8 * 48;
			object obj4 = (nint)instructions.Items + num10;
			attachments.Clear(clearArray: false);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v276 @ X8_v12+2C]");
			nint num11 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ X10_v7+28]");
			int num12 = (int)(num11 - 0);
			ExposedList<Attachment> exposedList3 = attachments.Resize(num12);
			ExposedList<Attachment> exposedList4 = attachments;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ X22_v6 (Spine.Unity.SubmeshInstruction[])+20]");
			int rawFirstVertexIndex = ((SubmeshInstruction)0).rawFirstVertexIndex;
			bool flag = num12 < 1;
			int num13 = num12;
			if (!flag)
			{
				Attachment[] items2 = exposedList4.Items;
				int num14 = num12;
				ExposedList<Attachment> exposedList5 = exposedList3;
				int num15 = 0;
				bool flag3;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ X10_v7+28]");
					object obj5 = (nint)0 + (nint)num15;
					int num16 = (int)((nint)obj5 << 3);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v155 @ X9_v11 (System.Int32)+10]");
					object obj6 = (nint)0 + (nint)num16;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v665 @ X8_v20+20]");
					object obj7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v278 @ X8_v21+18]");
					object obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ X9_v16+85]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v278 @ X8_v21+40]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v278 @ X8_v21+40]");
							exposedList5 = (ExposedList<Attachment>)(object)(0 as Attachment);
							bool flag2 = exposedList5 == null;
							num14 = (int)typeof(Attachment);
							if (flag2)
							{
								ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
								num13 = 0;
								throw ex;
							}
						}
						int num17 = num15;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v278 @ X8_v21+40]");
						items2[num17] = (Attachment)0;
					}
					num15++;
					flag3 = num12 != num15;
					num13 = num14;
					exposedList3 = exposedList5;
				}
				while (flag3);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ SYSREG+28]");
			nint num18 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ SYSREG+28]");
			if (num18 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854EB0 (native __stack_chk_fail)");
			}
		}

		[Token(Token = "0x600069B")]
		[Address(RVA = "0x1567594", Offset = "0x1567594", Length = "0x1AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, other, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv40 = Il2CppMethodInfo;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, other, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv99 = Il2CppMethodInfo;\n\tv100 = \"il2cpp_codegen_initialize_runtime_metadata\"(v99, other, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv103 = Il2CppMethodInfo;\n\tv104 = \"il2cpp_codegen_initialize_runtime_metadata\"(v103, other, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv125 = Il2CppMethodInfo;\n\tv126 = \"il2cpp_codegen_initialize_runtime_metadata\"(v125, other, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv129 = Il2CppMethodInfo;\n\tv130 = \"il2cpp_codegen_initialize_runtime_metadata\"(v129, other, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv132 = Il2CppMethodInfo;\n\tv133 = \"il2cpp_codegen_initialize_runtime_metadata\"(v132, other, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv137 = Il2CppMethodInfo;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v137, other, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 1;\n\t*([1A37CDB]) = v37;\nL_002B:\n\tthis.immutableTriangles = other.immutableTriangles;\n\tthis.hasActiveClipping = other.hasActiveClipping;\n\tthis.rawVertexCount = other.rawVertexCount;\n\tSpine.ExposedList`1<Spine.Attachment>::Clear(this.attachments, 0);\n\tv69 = Spine.ExposedList`1<Spine.Attachment>::get_Capacity(other.attachments);\n\tSpine.ExposedList`1<Spine.Attachment>::EnsureCapacity(this.attachments, v69);\n\tv70 = other.attachments;\n\tv89 = this.attachments;\n\tv89.Count = v70.Count;\n\tSpine.ExposedList`1<Spine.Attachment>::CopyTo(v70, v89.Items);\n\tSpine.ExposedList`1<Spine.Unity.SubmeshInstruction>::Clear(this.submeshInstructions, 0);\n\tv73 = Spine.ExposedList`1<Spine.Unity.SubmeshInstruction>::get_Capacity(other.submeshInstructions);\n\tSpine.ExposedList`1<Spine.Unity.SubmeshInstruction>::EnsureCapacity(this.submeshInstructions, v73);\n\tv74 = other.submeshInstructions;\n\tv93 = this.submeshInstructions;\n\tv93.Count = v74.Count;\n\tSpine.ExposedList`1<Spine.Unity.SubmeshInstruction>::CopyTo(v74, v93.Items);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 90 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Set(SkeletonRendererInstruction other)
		{
			immutableTriangles = other.immutableTriangles;
			hasActiveClipping = other.hasActiveClipping;
			rawVertexCount = other.rawVertexCount;
			attachments.Clear(clearArray: false);
			int capacity = other.attachments.Capacity;
			attachments.EnsureCapacity(capacity);
			ExposedList<Attachment> exposedList = other.attachments;
			ExposedList<Attachment> exposedList2 = attachments;
			exposedList2.Count = exposedList.Count;
			exposedList.CopyTo(exposedList2.Items);
			submeshInstructions.Clear(clearArray: false);
			int capacity2 = other.submeshInstructions.Capacity;
			submeshInstructions.EnsureCapacity(capacity2);
			ExposedList<SubmeshInstruction> exposedList3 = other.submeshInstructions;
			ExposedList<SubmeshInstruction> exposedList4 = submeshInstructions;
			exposedList4.Count = exposedList3.Count;
			exposedList3.CopyTo(exposedList4.Items);
		}

		[Token(Token = "0x600069C")]
		[Address(RVA = "0x1564E1C", Offset = "0x1564E1C", Length = "0x1A4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = ~a.hasActiveClipping;\n\tv6 = ~v5;\n\tif (v6) goto L_FFFFFFFF;\n\tv277 = ~b.hasActiveClipping;\n\tv231 = ~v277;\n\tif (v231) goto L_FFFFFFFF;\n\tv181 = a.rawVertexCount != b.rawVertexCount;\n\tif (v181) goto L_FFFFFFFF;\n\tv56 = a.immutableTriangles != b.immutableTriangles;\n\tif (v56) goto L_FFFFFFFF;\n\tv50 = b.attachments;\n\tv44 = a.attachments;\n\tv57 = v44.Count != v50.Count;\n\tif (v57) goto L_FFFFFFFF;\n\tv129 = a.submeshInstructions;\n\tv36 = b.submeshInstructions;\n\tv182 = v129.Count != v36.Count;\n\tif (v182) goto L_FFFFFFFF;\n\tv58 = v50.Count < 1;\n\tif (v58) goto L_00A1;\n\tv45 = v44.Items;\n\tv51 = v50.Items;\nL_0089:\n\tv183 = v45[v25 @ X15_v12 (System.Int32)] != v51[v25 @ X15_v12 (System.Int32)];\n\tif (v183) goto L_FFFFFFFF;\n\tv25 = v25 + 1;\n\tv392 = v50.Count != v25;\n\tif (v392) goto L_0089;\nL_00A1:\n\tv60 = v129.Count < 1;\n\tif (v60) goto L_FFFFFFFF;\nL_00C0:\n\tv438 = v53 * 0x30;\n\tv174 = v129.Items + v438;\n\tv232 = v53 * 0x30;\n\tv439 = v36.Items + v232;\n\tv184 = *([v174 @ X14_v9+44]) != *([v439 @ X15_v7+44]);\n\tif (v184) goto L_FFFFFFFF;\n\tv358 = v53 * 0x30;\n\tv292 = v36.Items + v358;\n\tv302 = *([v174 @ X14_v9+48]) != *([v292 @ X15_v9+48]);\n\tif (v302) goto L_0119;\n\tv303 = *([v174 @ X14_v9+40]) != *([v292 @ X15_v9+40]);\n\tif (v303) goto L_0119;\n\tv304 = *([v174 @ X14_v9+2C]) != *([v292 @ X15_v9+2C]);\n\tif (v304) goto L_0119;\n\tv305 = *([v174 @ X14_v9+28]) != *([v292 @ X15_v9+28]);\n\tif (v305) goto L_0119;\n\tv53 = v53 + 1;\n\tv306 = v129.Count != v53;\n\tif (v306) goto L_00C0;\n\tgoto L_0119;\nL_0119:\n\treturn returnVal1;\n\tgoto L_0119;\n\tv146 = new System.NullReferenceException();\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 233 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool GeometryNotEqual(SkeletonRendererInstruction a, SkeletonRendererInstruction b)
		{
			//IL_0241: Expected O, but got I
			//IL_0262: Expected O, but got I
			//IL_02b2: Expected O, but got I
			ExposedList<SubmeshInstruction> exposedList3;
			ExposedList<SubmeshInstruction> exposedList4;
			if (!a.hasActiveClipping && !b.hasActiveClipping && a.rawVertexCount == b.rawVertexCount && a.immutableTriangles == b.immutableTriangles)
			{
				ExposedList<Attachment> exposedList = b.attachments;
				ExposedList<Attachment> exposedList2 = a.attachments;
				if (exposedList2.Count == exposedList.Count)
				{
					exposedList3 = a.submeshInstructions;
					exposedList4 = b.submeshInstructions;
					if (exposedList3.Count == exposedList4.Count)
					{
						if (exposedList.Count < 1)
						{
							goto IL_01f0;
						}
						Attachment[] items = exposedList2.Items;
						Attachment[] items2 = exposedList.Items;
						int num = 0;
						while (items[num] == items2[num])
						{
							num++;
							if (exposedList.Count != num)
							{
								continue;
							}
							goto IL_01f0;
						}
					}
				}
			}
			goto IL_03d2;
			IL_01f0:
			bool result;
			if (exposedList3.Count >= 1)
			{
				int num2 = 0;
				while (true)
				{
					int num3 = num2 * 48;
					object obj = (nint)exposedList3.Items + num3;
					int num4 = num2 * 48;
					object obj2 = (nint)exposedList4.Items + num4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ X14_v9+44]");
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v439 @ X15_v7+44]");
					if (num5 != 0)
					{
						break;
					}
					int num6 = num2 * 48;
					object obj3 = (nint)exposedList4.Items + num6;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ X14_v9+48]");
					nint num7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ X15_v9+48]");
					bool flag = num7 != 0;
					result = true;
					if (!flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ X14_v9+40]");
						nint num8 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ X15_v9+40]");
						bool flag2 = num8 != 0;
						result = true;
						if (!flag2)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ X14_v9+2C]");
							nint num9 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ X15_v9+2C]");
							bool flag3 = num9 != 0;
							result = true;
							if (!flag3)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ X14_v9+28]");
								nint num10 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v292 @ X15_v9+28]");
								bool flag4 = num10 != 0;
								result = true;
								if (!flag4)
								{
									num2++;
									if (exposedList3.Count != num2)
									{
										continue;
									}
									result = false;
								}
							}
						}
					}
					goto IL_03ee;
				}
				goto IL_03d2;
			}
			result = false;
			goto IL_03ee;
			IL_03d2:
			result = true;
			goto IL_03ee;
			IL_03ee:
			return result;
		}

		[Token(Token = "0x600069D")]
		[Address(RVA = "0x15679A8", Offset = "0x15679A8", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv54 = Il2CppMethodInfo;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv59 = Spine.ExposedList`1<Spine.Unity.SubmeshInstruction>;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv65 = Spine.ExposedList`1<Spine.Attachment>;\n\tv48 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46);\n\tv50 = 1;\n\t*([1A37CDC]) = v50;\nL_0026:\n\tv52 = new Spine.ExposedList`1<Spine.Unity.SubmeshInstruction>();\n\tSpine.ExposedList`1<Spine.Unity.SubmeshInstruction>::.ctor(v52);\n\tthis.submeshInstructions = v52;\n\tthis.rawVertexCount = 0xFFFFFFFF;\n\tv63 = new Spine.ExposedList`1<Spine.Attachment>();\n\tSpine.ExposedList`1<Spine.Attachment>::.ctor(v63);\n\tthis.attachments = v63;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 43 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public SkeletonRendererInstruction()
		{
			ExposedList<SubmeshInstruction> exposedList = new ExposedList<SubmeshInstruction>();
			submeshInstructions = exposedList;
			rawVertexCount = -1;
			ExposedList<Attachment> exposedList2 = new ExposedList<Attachment>();
			attachments = exposedList2;
		}
	}
}
