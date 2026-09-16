using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using JetBrains.Annotations;
using Morpeh.Utils;
using Unity.IL2CPP.CompilerServices;

namespace Morpeh
{
	[AttributeAttribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73D2C0", Offset = "0x73D2C0")]
	[AttributeAttribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73D2C0", Offset = "0x73D2C0")]
	[AttributeAttribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73D2C0", Offset = "0x73D2C0")]
	[Token(Token = "0x2000010")]
	public sealed class Filter : IEnumerable<IEntity>, IEnumerable, IDisposable
	{
		[Token(Token = "0x200003B")]
		private enum FilterMode
		{
			[Token(Token = "0x4000064")]
			None = 0,
			[Token(Token = "0x4000065")]
			Include = 1,
			[Token(Token = "0x4000066")]
			Exclude = 2
		}

		[Token(Token = "0x200003C")]
		public struct ComponentsBag<T> where T : struct, IComponent
		{
			[Token(Token = "0x4000067")]
			internal static ComponentsBag<T> Empty;

			[Token(Token = "0x4000068")]
			private static ComponentsBag<T>[] cache;

			[Token(Token = "0x4000069")]
			private static int cacheLength;

			[Token(Token = "0x400006A")]
			private static int cacheCapacity;

			[Token(Token = "0x400006B")]
			private static readonly bool isMarker;

			[Token(Token = "0x400006C")]
			[FieldOffset(Offset = "0x0")]
			private T[] sharedComponents;

			[Token(Token = "0x400006D")]
			[FieldOffset(Offset = "0x0")]
			private int[] ids;

			[Token(Token = "0x400006E")]
			[FieldOffset(Offset = "0x0")]
			private World world;

			[Token(Token = "0x60000F3")]
			[Address(RVA = "0x10969C8", Offset = "0x10969C8", Length = "0x420")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0011;\n\tv19 = v14;\n\tv20 = 0x8907BC(v19, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0011:\n\tv38 = Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>;\n\tgoto L_001A;\n\tv43 = v38;\n\tv44 = 0x8907BC(v43, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv47 = *([v38 @ X20_v2 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]);\nL_001A:\n\tv48 = *([v38 @ X20_v2 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]) & 0x200;\n\tv49 = v48 == 0;\n\tif (v49) goto L_004A;\n\tgoto L_0026;\n\tv72 = v50;\n\tv73 = 0x8907BC(v72, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\tv66 = Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>;\n\tgoto L_002F;\n\tv89 = v66;\n\tv90 = 0x8907BC(v89, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_002F:\n\tv91 = *([v66 @ X20_v25 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+E0]) == 0;\n\tv60 = ~v91;\n\tif (v60) goto L_004A;\n\tgoto L_0040;\n\tv111 = v98;\n\tv112 = 0x8907BC(v111, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0040:\n\tgoto L_004A;\n\tv156 = v65;\n\tv157 = 0x8907BC(v156, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_004A:\n\tgoto L_0053;\n\tv80 = v67;\n\tv81 = 0x8907BC(v80, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0053:\n\tgoto L_0057;\n\tv92 = v84;\n\tv93 = 0x8907BC(v92, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0057:\n\tv96 = v95.info;\n\tv97 = v95.info == 0;\n\tif (v97) goto L_00EE;\n\tgoto L_0064;\n\tv117 = v103;\n\tv118 = 0x8907BC(v117, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0064:\n\tv121 = Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>;\n\tgoto L_006C;\n\tv160 = v121;\n\tv161 = 0x8907BC(v160, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_006C:\n\tv163 = *([v121 @ X20_v9 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+B8]);\n\t*([v163 @ X8_v39 (Il2CppStaticFields<Morpeh.Filter+ComponentsBag`1<T>>)+28]) = v96.isMarker;\n\tgoto L_0077;\n\tv181 = v164;\n\tv182 = 0x8907BC(v181, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0077:\n\tv185 = Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>;\n\tgoto L_007F;\n\tv202 = v185;\n\tv203 = 0x8907BC(v202, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_007F:\n\tv205 = *([v185 @ X20_v11 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+B8]);\n\tv207 = *([v205 @ X8_v43 (Il2CppStaticFields<Morpeh.Filter+ComponentsBag`1<T>>)+28]) == 0;\n\tv208 = ~v207;\n\tif (v208) goto L_00EC;\n\tgoto L_008D;\n\tv402 = v269;\n\tv403 = 0x8907BC(v402, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_008D:\n\tv406 = Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>;\n\tgoto L_0095;\n\tv458 = v406;\n\tv459 = 0x8907BC(v458, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0095:\n\tv461 = *([v406 @ X20_v15 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+B8]);\n\t*([v461 @ X8_v49 (Il2CppStaticFields<Morpeh.Filter+ComponentsBag`1<T>>)+20]) = 0;\n\tgoto L_00A0;\n\tv485 = v462;\n\tv486 = 0x8907BC(v485, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_00A0:\n\tv489 = Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>;\n\tgoto L_00A8;\n\tv495 = v489;\n\tv496 = 0x8907BC(v495, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_00A8:\n\tv498 = *([v489 @ X20_v17 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+B8]);\n\t*([v498 @ X8_v53 (Il2CppStaticFields<Morpeh.Filter+ComponentsBag`1<T>>)+24]) = 0x10;\n\tgoto L_00B4;\n\tv511 = v500;\n\tv512 = 0x8907BC(v511, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_00B4:\n\tv515 = Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>;\n\tgoto L_00BD;\n\tv520 = v515;\n\tv521 = 0x8907BC(v520, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_00BD:\n\tv524 = *([v515 @ X20_v19 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+B8]);\n\tgoto L_00CC;\n\tv535 = v523;\n\tv536 = 0x8907BC(v535, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_00CC:\n\tgoto L_00D1;\n\tv553 = v279;\n\tv554 = 0x8907BC(v553, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_00D1:\n\t// 209 NewArr v557 @ X0_v43 (Il2CppClass<ComponentsBag`1<T>[]>), typeof(Il2CppClass<ComponentsBag`1<T>[]>), [v524 @ X8_v57 (Il2CppStaticFields<Morpeh.Filter+ComponentsBag`1<T>>)+24]\n\tgoto L_00DC;\n\tv568 = v562;\n\tv569 = 0x8907BC(v568, v275, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_00DC:\n\tv287 = Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>;\n\tgoto L_00E4;\n\tv578 = v287;\n\tv579 = 0x8907BC(v578, v275, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_00E4:\n\tv285 = *([v287 @ X20_v22 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+B8]);\n\t*([v285 @ X8_v63 (Il2CppStaticFields<Morpeh.Filter+ComponentsBag`1<T>>)+18]) = v557;\nL_00EC:\n\treturn;\nL_00EE:\n\tv110 = new System.NullReferenceException();\n\tgoto L_010E;\n\tv170 = *([1EAA208]);\n\tv171 = *([v170 @ X8_v35]);\n\tv172 = \"il2cpp_codegen_initialize_method\"(v171, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv175 = 0 | 1;\n\t*([2026ACD]) = v175;\nL_010E:\n\tv312 = *([v22 @ X2]);\n\tv179 = v110 + 8;\n\tSystem.Array::Resize(v179, *([v22 @ X2]));\n\tv201 = *([v22 @ X2]) < 1;\n\tif (v201) goto L_018C;\nL_0121:\n\tv317 = v110._className;\n\tv467 = v301 < *([v21 @ X1+18]);\n\tv441 = ~v467;\n\tif (v441) goto L_018F;\n\tv453 = *([v317 @ X8_v18 (System.String)+58]);\n\tv470 = v301 << 2;\n\tv505 = v21 + v470;\n\tv506 = *([v505 @ X9_v7+20]) < *([v453 @ X8_v25+18]);\n\tv442 = ~v506;\n\tif (v442) goto L_018F;\n\tv417 = *([v505 @ X9_v7+20]) << 3;\n\tv454 = v453 + v417;\n\tv529 = *([v23 @ X3+18]);\n\tv213 = *([v110 @ X0_v7 (System.NullReferenceException)+8]);\n\tv547 = *([v529 @ X25_v6 (System.Int32[]&)+12E]);\n\tv532 = *([v529 @ X25_v6 (System.Int32[]&)+12E]) & 1;\n\tv533 = v532 == 0;\n\tv534 = ~v533;\n\tif (v534) goto L_0154;\n\tv544 = System.Array::Resize(v529, v312);\n\tv211 = *([v23 @ X3+18]);\n\tv547 = *([v211 @ X24_v7 (System.Int32[]&)+12E]);\nL_0154:\n\tv549 = *([v529 @ X25_v6 (System.Int32[]&)+C0]);\n\tv249 = *([v549 @ X9_v9+18]);\n\tv550 = v547 & 1;\n\tv551 = v550 == 0;\n\tv552 = ~v551;\n\tif (v552) goto L_015D;\n\tv559 = System.Array::Resize(v211, v312);\nL_015D:\n\tv455 = *([v211 @ X24_v7 (System.Int32[]&)+C0]);\n\tv312 = *([v455 @ X8_v29+18]);\n\t*([v249 @ X9_v10])(v252, *([v454 @ X8_v26+20]), *([v455 @ X8_v29+18]), Il2CppMethodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv567 = v301 < *([v213 @ X28_v6+18]);\n\tv478 = ~v567;\n\tif (v478) goto L_018F;\n\tv220 = v301 << 2;\n\tv575 = v213 + v220;\n\t*([v575 @ X8_v31+20]) = v252;\n\tv301 = v301 + 1;\n\tv227 = v301 < *([v22 @ X2]);\n\tif (v227) goto L_0121;\nL_018C:\n\treturn;\n\tv457 = new System.NullReferenceException();\nL_018F:\n\tv484 = new System.IndexOutOfRangeException();\n\tthrow v484;\n\treturn;\n\tX10 = *([X0]);\n\tX8 = *([X0+8]);\n\tX9 = *([X1]);\n\tTEMPSHIFT = X9 << 2;\n\tX8 = X8 + TEMPSHIFT;\n\tX8 = *([X8+20]);\n\tX9 = *([X2]);\n\tX11 = *([X2+8]);\n\tTEMPSHIFT = X8 << 4;\n\tX8 = X10 + TEMPSHIFT;\n\t*([X8+20]) = X9;\n\t*([X8+28]) = X11;\n\treturn;\n// 256 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			unsafe static ComponentsBag()
			{
				//IL_0434: Expected I4, but got O
				//IL_0450: Expected I4, but got O
				//IL_0205: Expected O, but got I
				//IL_0226: Expected O, but got I
				//IL_0281: Expected O, but got I
				//IL_02a6: Expected O, but got I
				//IL_02b6: Expected O, but got I
				//IL_047d: Expected O, but got I
				//IL_048d: Expected O, but got I
				//IL_0350: Expected O, but got I
				//IL_0329: Expected O, but got I
				//IL_0180: Expected I, but got O
				//IL_03ba: Expected O, but got I
				IntPtr intPtr = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v38 @ X20_v2 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr2 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ X20_v25 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				CommonCacheTypeIdentifier.TypeInfo info = CacheTypeIdentifier<T>.info;
				if (CacheTypeIdentifier<T>.info != null)
				{
					IntPtr intPtr3 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ X20_v9 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+B8]");
					IntPtr intPtr4 = (IntPtr)0;
					_ = info.isMarker;
					IntPtr intPtr5 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ X20_v11 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+B8]");
					IntPtr intPtr6 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ X8_v43 (Il2CppStaticFields<Morpeh.Filter+ComponentsBag`1<T>>)+28]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						IntPtr intPtr7 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ X20_v15 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+B8]");
						IntPtr intPtr8 = (IntPtr)0;
						_ = 0;
						IntPtr intPtr9 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v489 @ X20_v17 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+B8]");
						IntPtr intPtr10 = (IntPtr)0;
						_ = 16;
						IntPtr intPtr11 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v515 @ X20_v19 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+B8]");
						IntPtr intPtr12 = (IntPtr)0;
						IntPtr intPtr13 = (IntPtr)null;
						IntPtr intPtr14 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ X20_v22 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+B8]");
						IntPtr intPtr15 = (IntPtr)0;
					}
					return;
				}
				NullReferenceException ex = new NullReferenceException();
				object obj = default(object);
				int newSize = (int)obj;
				Array.Resize(ref *(int[]*)((long)(IntPtr)ex + 8L), (int)obj);
				if ((long)(IntPtr)obj < 1L)
				{
					return;
				}
				int num = 0;
				object obj4 = default(object);
				while (true)
				{
					string className = ((Exception)ex)._className;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X1+18]");
					if ((long)num2 >= 0L)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v317 @ X8_v18 (System.String)+58]");
					object obj2 = 0;
					int num3 = num << 2;
					object obj3 = (long)(IntPtr)obj4 + (long)num3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v505 @ X9_v7+20]");
					IntPtr intPtr16 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v453 @ X8_v25+18]");
					if ((long)intPtr16 >= 0L)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v505 @ X9_v7+20]");
					int num4 = 0;
					object obj5 = (long)(IntPtr)obj2 + (long)num4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X3+18]");
					ref int[] reference = ref *(int[]*)null;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ X0_v7 (System.NullReferenceException)+8]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ X25_v6 (System.Int32[]&)+12E]");
					object obj7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ X25_v6 (System.Int32[]&)+12E]");
					int num5 = 0;
					bool flag = num5 == 0;
					bool flag2 = !flag;
					ref int[] array = ref reference;
					if (!flag2)
					{
						Array.Resize(ref reference, newSize);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v23 @ X3+18]");
						array = ref *(int[]*)null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ X24_v7 (System.Int32[]&)+12E]");
						obj7 = 0;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v529 @ X25_v6 (System.Int32[]&)+C0]");
					object obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v549 @ X9_v9+18]");
					object obj9 = 0;
					if ((int)((long)(IntPtr)obj7 & 1L) == 0)
					{
						Array.Resize(ref array, newSize);
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ X24_v7 (System.Int32[]&)+C0]");
					object obj10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v455 @ X8_v29+18]");
					newSize = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v249 @ X9_v10] (should have been resolved before IL gen)");
					int num6 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v213 @ X28_v6+18]");
					if ((long)num6 >= 0L)
					{
						break;
					}
					int num7 = num << 2;
					object obj11 = (long)(IntPtr)obj6 + (long)num7;
					num++;
					if ((long)num >= (long)(IntPtr)obj)
					{
						return;
					}
				}
				IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
				throw ex2;
			}

			[Token(Token = "0x60000F4")]
			[Address(RVA = "0x856A80", Offset = "0x856A80", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this + 0x10;\n\tv2 = 0x1096C48(v0, entities, len, methodInfo, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17);\n\treturn;\n")]
			internal unsafe void Update(int[] entities, in int len)
			{
				//IL_000b: Expected O, but got Ref
				object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1096C48 (inside Morpeh.Filter+ComponentsBag`1::.cctor +0x280)");
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[AttributeAttribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73DEB8", Offset = "0x73DEB8")]
			[AttributeAttribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73DEB8", Offset = "0x73DEB8")]
			[AttributeAttribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73DEB8", Offset = "0x73DEB8")]
			[Token(Token = "0x60000F5")]
			[Address(RVA = "0x856A88", Offset = "0x856A88", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.ids;\n\tv3 = index->klass;\n\tv8 = v2[v3 @ X9_v1] << 4;\n\tv9 = this.sharedComponents + v8;\n\treturnVal1 = v9 + 0x20;\n\treturn returnVal1;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public unsafe ref T GetComponent(in int index)
			{
				//IL_0017: Expected O, but got I4
				//IL_003e: Expected O, but got I
				int[] array = ids;
				object obj = index;
				int num = array[obj] << 4;
				object obj2 = (long)(IntPtr)sharedComponents + (long)num;
				return ref *(T*)((long)(IntPtr)obj2 + 32L);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			[AttributeAttribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73DF94", Offset = "0x73DF94")]
			[AttributeAttribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73DF94", Offset = "0x73DF94")]
			[AttributeAttribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73DF94", Offset = "0x73DF94")]
			[Token(Token = "0x60000F6")]
			[Address(RVA = "0x856AA4", Offset = "0x856AA4", Length = "0x20")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.ids;\n\tv3 = index->klass;\n\tv11 = v2[v3 @ X9_v1] << 4;\n\tv12 = this.sharedComponents + v11;\n\tvalue->klass = value->klass;\n\tvalue->monitor = value->monitor;\n\treturn;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void SetComponent(in int index, in T value)
			{
				//IL_0017: Expected O, but got I4
				//IL_003e: Expected O, but got I
				int[] array = ids;
				object obj = index;
				int num = array[obj] << 4;
				object obj2 = (long)(IntPtr)sharedComponents + (long)num;
				System.Runtime.CompilerServices.Unsafe.As<T, object>(ref value);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [value @ X2 (T&)+8]");
				_ = 0;
			}

			[Token(Token = "0x60000F7")]
			[Address(RVA = "0x1096DE8", Offset = "0x1096DE8", Length = "0x130")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv21 = v14;\n\tv22 = 0x8907BC(v21, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0012:\n\tv39 = Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>;\n\tgoto L_001B;\n\tv44 = v39;\n\tv45 = 0x8907BC(v44, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\n\tv48 = *([v39 @ X21_v2 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+12E]);\nL_001B:\n\tv49 = *([v39 @ X21_v2 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+12E]) & 0x200;\n\tv50 = v49 == 0;\n\tif (v50) goto L_004B;\n\tgoto L_0027;\n\tv73 = v51;\n\tv74 = 0x8907BC(v73, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0027:\n\tv67 = Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>;\n\tgoto L_0030;\n\tv90 = v67;\n\tv91 = 0x8907BC(v90, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0030:\n\tv92 = *([v67 @ X21_v7 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+E0]) == 0;\n\tv61 = ~v92;\n\tif (v61) goto L_004B;\n\tgoto L_0041;\n\tv117 = v99;\n\tv118 = 0x8907BC(v117, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0041:\n\tgoto L_004B;\n\tv154 = v66;\n\tv155 = 0x8907BC(v154, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_004B:\n\tgoto L_004F;\n\tv81 = v68;\n\tv82 = 0x8907BC(v81, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_004F:\n\tv85 = Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>;\n\tgoto L_0057;\n\tv93 = v85;\n\tv94 = 0x8907BC(v93, methodInfo, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36);\nL_0057:\n\tv96 = *([v85 @ X20_v3 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+B8]);\n\tv97 = *([v96 @ X8_v9 (Il2CppStaticFields<Morpeh.Filter+ComponentsBag`1<T>>)+18]);\n\tv106 = *([index @ X0 (System.Int32&)]) < *([v97 @ X8_v10+18]);\n\tv107 = ~v106;\n\tif (v107) goto L_0074;\n\tv128 = *([index @ X0 (System.Int32&)]) * 0x18;\n\tv129 = v97 + v128;\n\treturnVal1 = v129 + 0x20;\n\treturn returnVal1;\n\tv116 = new System.NullReferenceException();\nL_0074:\n\tv153 = new System.IndexOutOfRangeException();\n\tthrow v153;\n\treturn returnVal2;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			internal unsafe static ref ComponentsBag<T> Get(in int index)
			{
				//IL_008a: Expected O, but got I
				//IL_00d6: Expected O, but got I4
				//IL_00e5: Expected O, but got I
				IntPtr intPtr = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v39 @ X21_v2 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr2 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v67 @ X21_v7 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				IntPtr intPtr3 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ X20_v3 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+B8]");
				IntPtr intPtr4 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v96 @ X8_v9 (Il2CppStaticFields<Morpeh.Filter+ComponentsBag`1<T>>)+18]");
				object obj = 0;
				int num = index;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ X8_v10+18]");
				if ((long)num < 0L)
				{
					object obj2 = index * 24;
					object obj3 = (long)(IntPtr)obj + (long)(IntPtr)obj2;
					return ref *(ComponentsBag<T>*)((long)(IntPtr)obj3 + 32L);
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}

			[Token(Token = "0x60000F8")]
			[Address(RVA = "0x1096F18", Offset = "0x1096F18", Length = "0x58C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv34 = *([1EBBA18]);\n\tv35 = *([v34 @ X8_v101]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([2026ACE]) = v53;\nL_001F:\n\t// 31 NewArr v58 @ X0_v3 (System.Int32[]), typeof(System.Int32[]), 1\n\tgoto L_002A;\n\tv65 = v59;\n\tv66 = System.Array::Resize(v65, v56, v37);\nL_002A:\n\tv69 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_0033;\n\tv74 = v69;\n\tv75 = System.Array::Resize(v74, v56, v37);\n\tv78 = *([v69 @ X22_v2 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]);\nL_0033:\n\tv79 = *([v69 @ X22_v2 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]) & 0x200;\n\tv80 = v79 == 0;\n\tif (v80) goto L_0063;\n\tgoto L_003F;\n\tv103 = v81;\n\tv104 = System.Array::Resize(v103, v56, v37);\nL_003F:\n\tv88 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_0048;\n\tv120 = v88;\n\tv121 = System.Array::Resize(v120, v56, v37);\nL_0048:\n\tv122 = *([v88 @ X22_v43 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]) == 0;\n\tv94 = ~v122;\n\tif (v94) goto L_0063;\n\tgoto L_0059;\n\tv147 = v133;\n\tv148 = System.Array::Resize(v147, v56, v37);\nL_0059:\n\tgoto L_0063;\n\tv160 = v87;\n\tv161 = System.Array::Resize(v160, v56, v37);\nL_0063:\n\tgoto L_006C;\n\tv111 = v98;\n\tv112 = System.Array::Resize(v111, v56, v37);\nL_006C:\n\tgoto L_0076;\n\tv123 = v115;\n\tv124 = System.Array::Resize(v123, v56, v37);\nL_0076:\n\tgoto L_007A;\n\tv138 = v126;\n\tv139 = System.Array::Resize(v138, v56, v37);\nL_007A:\n\tv142 = Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>;\n\tgoto L_0083;\n\tv153 = v142;\n\tv154 = System.Array::Resize(v153, v56, v37);\n\tv157 = *([v142 @ X22_v6 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+12E]);\nL_0083:\n\tv158 = *([v142 @ X22_v6 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+12E]) & 0x200;\n\tv159 = v158 == 0;\n\tif (v159) goto L_00B3;\n\tgoto L_008F;\n\tv186 = v164;\n\tv187 = System.Array::Resize(v186, v56, v37);\nL_008F:\n\tv171 = Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>;\n\tgoto L_0098;\n\tv203 = v171;\n\tv204 = System.Array::Resize(v203, v56, v37);\nL_0098:\n\tv205 = *([v171 @ X22_v39 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+E0]) == 0;\n\tv177 = ~v205;\n\tif (v177) goto L_00B3;\n\tgoto L_00A9;\n\tv230 = v216;\n\tv231 = System.Array::Resize(v230, v56, v37);\nL_00A9:\n\tgoto L_00B3;\n\tv253 = v170;\n\tv254 = System.Array::Resize(v253, v56, v37);\nL_00B3:\n\tgoto L_00B7;\n\tv194 = v181;\n\tv195 = System.Array::Resize(v194, v56, v37);\nL_00B7:\n\tv198 = Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>;\n\tgoto L_00C0;\n\tv206 = v198;\n\tv207 = System.Array::Resize(v206, v56, v37);\nL_00C0:\n\tv210 = *([v198 @ X22_v9 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+B8]);\n\tgoto L_00CA;\n\tv221 = v209;\n\tv222 = System.Array::Resize(v221, v56, v37);\nL_00CA:\n\tv225 = Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>;\n\tgoto L_00D2;\n\tv236 = v225;\n\tv237 = System.Array::Resize(v236, v56, v37);\nL_00D2:\n\tv239 = *([v225 @ X22_v10 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+B8]);\n\tv252 = *([v210 @ X8_v21 (Il2CppStaticFields<Morpeh.Filter+ComponentsBag`1<T>>)+24]) > *([v239 @ X8_v24 (Il2CppStaticFields<Morpeh.Filter+ComponentsBag`1<T>>)+20]);\n\tif (v252) goto L_0176;\n\tgoto L_00EA;\n\tv289 = v257;\n\tv290 = System.Array::Resize(v289, v56, v37);\nL_00EA:\n\tv293 = Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>;\n\tgoto L_00F3;\n\tv307 = v293;\n\tv308 = System.Array::Resize(v307, v56, v37);\n\tv311 = *([v293 @ X22_v25 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+12E]);\nL_00F3:\n\tv312 = *([v293 @ X22_v25 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+12E]) & 0x200;\n\tv313 = v312 == 0;\n\tif (v313) goto L_0123;\n\tgoto L_00FF;\n\tv365 = v321;\n\tv366 = System.Array::Resize(v365, v56, v37);\nL_00FF:\n\tv328 = Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>;\n\tgoto L_0108;\n\tv399 = v328;\n\tv400 = System.Array::Resize(v399, v56, v37);\nL_0108:\n\tv401 = *([v328 @ X22_v35 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+E0]) == 0;\n\tv334 = ~v401;\n\tif (v334) goto L_0123;\n\tgoto L_0119;\n\tv456 = v425;\n\tv457 = System.Array::Resize(v456, v56, v37);\nL_0119:\n\tgoto L_0123;\n\tv483 = v327;\n\tv484 = System.Array::Resize(v483, v56, v37);\nL_0123:\n\tgoto L_0127;\n\tv373 = v338;\n\tv374 = System.Array::Resize(v373, v56, v37);\nL_0127:\n\tv377 = Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>;\n\tgoto L_012F;\n\tv402 = v377;\n\tv403 = System.Array::Resize(v402, v56, v37);\nL_012F:\n\tv405 = Il2CppClass<Morpeh.Filter+ComponentsBag`1>;\n\tv406 = *([v377 @ X22_v28 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+B8]);\n\tgoto L_013F;\n\tv430 = v405;\n\tv431 = System.Array::Resize(v430, v56, v37);\n\tv433 = Il2CppClass<Morpeh.Filter+ComponentsBag`1>;\n\tv436 = *([v433 @ X22_v33 (Il2CppClass<Morpeh.Filter+ComponentsBag`1>)+12E]);\nL_013F:\n\tv439 = *([v405 @ X23_v8 (Il2CppClass<Morpeh.Filter+ComponentsBag`1>)+12E]) & 1;\n\tv440 = v439 == 0;\n\tv441 = ~v440;\n\tif (v441) goto L_0146;\n\tv463 = System.Array::Resize(Il2CppClass<Morpeh.Filter+ComponentsBag`1>, 1);\nL_0146:\n\tv466 = Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>;\n\tgoto L_0150;\n\tv487 = v466;\n\tv488 = System.Array::Resize(v487, v56, v37);\nL_0150:\n\tv277 = *([v406 @ X9_v11 (Il2CppStaticFields<Morpeh.Filter+ComponentsBag`1<T>>)+24]) << 1;\n\tv491 = *([v466 @ X22_v31 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+B8]) + 0x18;\n\tgoto L_015D;\n\tv511 = v271;\n\tv512 = System.Array::Resize(v511, v56, v37);\nL_015D:\n\tv516 = System.Array::Resize(v491, v277);\n\tgoto L_0167;\n\tv541 = v517;\n\tv542 = System.Array::Resize(v541, v267, v265);\nL_0167:\n\tv275 = Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>;\n\tgoto L_016F;\n\tv560 = v275;\n\tv561 = System.Array::Resize(v560, v267, v265);\nL_016F:\n\tv283 = *([v275 @ X23_v11 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+B8]);\n\t*([v283 @ X8_v74 (Il2CppStaticFields<Morpeh.Filter+ComponentsBag`1<T>>)+24]) = v277;\nL_0176:\n\tgoto L_017A;\n\tv298 = v284;\n\tv299 = System.Array::Resize(v298, v266, v264);\nL_017A:\n\tv302 = Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>;\n\tgoto L_0183;\n\tv314 = v302;\n\tv315 = System.Array::Resize(v314, v266, v264);\n\tv318 = *([v302 @ X22_v13 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+12E]);\nL_0183:\n\tv319 = *([v302 @ X22_v13 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+12E]) & 0x200;\n\tv320 = v319 == 0;\n\tif (v320) goto L_01B3;\n\tgoto L_018F;\n\tv382 = v343;\n\tv383 = System.Array::Resize(v382, v266, v264);\nL_018F:\n\tv350 = Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>;\n\tgoto L_0198;\n\tv412 = v350;\n\tv413 = System.Array::Resize(v412, v266, v264);\nL_0198:\n\tv414 = *([v350 @ X22_v21 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+E0]) == 0;\n\tv356 = ~v414;\n\tif (v356) goto L_01B3;\n\tgoto L_01A9;\n\tv471 = v442;\n\tv472 = System.Array::Resize(v471, v266, v264);\nL_01A9:\n\tgoto L_01B3;\n\tv495 = v349;\n\tv496 = System.Array::Resize(v495, v266, v264);\nL_01B3:\n\tgoto L_01B7;\n\tv390 = v360;\n\tv391 = System.Array::Resize(v390, v266, v264);\nL_01B7:\n\tv394 = Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>;\n\tgoto L_01C0;\n\tv415 = v394;\n\tv416 = System.Array::Resize(v415, v266, v264);\nL_01C0:\n\tv419 = *([v394 @ X22_v16 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+B8]);\n\tgoto L_01CA;\n\tv447 = v418;\n\tv448 = System.Array::Resize(v447, v266, v264);\nL_01CA:\n\tv451 = Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>;\n\tgoto L_01D2;\n\tv477 = v451;\n\tv478 = System.Array::Resize(v477, v266, v264);\nL_01D2:\n\tv480 = *([v451 @ X23_v5 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+B8]);\n\tv481 = *([v480 @ X8_v38 (Il2CppStaticFields<Morpeh.Filter+ComponentsBag`1<T>>)+18]);\n\tv500 = *([v419 @ X8_v35 (Il2CppStaticFields<Morpeh.Filter+ComponentsBag`1<T>>)+20]) < *([v481 @ X8_v39+18]);\n\tv501 = ~v500;\n\tif (v501) goto L_021E;\n\tv523 = *([v419 @ X8_v35 (Il2CppStaticFields<Morpeh.Filter+ComponentsBag`1<T>>)+20]) * 0x18;\n\tv524 = v481 + v523;\n\t*([v524 @ X8_v40+20]) = v127.Components;\n\t*([v524 @ X8_v40+28]) = v58;\n\t*([v524 @ X8_v40+30]) = world;\n\tgoto L_01F0;\n\tv548 = v525;\n\tv549 = System.Array::Resize(v548, v266, v264);\nL_01F0:\n\tv552 = Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>;\n\tgoto L_01F9;\n\tv562 = v552;\n\tv563 = System.Array::Resize(v562, v266, v264);\nL_01F9:\n\tv566 = *([v552 @ X20_v3 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+B8]);\n\tgoto L_0203;\n\tv572 = v565;\n\tv573 = System.Array::Resize(v572, v266, v264);\nL_0203:\n\tv576 = Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>;\n\tgoto L_020B;\n\tv620 =\n// ... truncated")]
			internal unsafe static int Create(World world)
			{
				//IL_02d8: Expected O, but got I
				//IL_0338: Expected O, but got I
				//IL_039e: Expected O, but got I
				int[] array = new int[1];
				IntPtr intPtr = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ X22_v2 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr2 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ X22_v43 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				IntPtr intPtr3 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ X22_v6 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr4 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v171 @ X22_v39 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				IntPtr intPtr5 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ X22_v9 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+B8]");
				IntPtr intPtr6 = (IntPtr)0;
				IntPtr intPtr7 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v225 @ X22_v10 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+B8]");
				IntPtr intPtr8 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ X8_v21 (Il2CppStaticFields<Morpeh.Filter+ComponentsBag`1<T>>)+24]");
				IntPtr intPtr9 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ X8_v24 (Il2CppStaticFields<Morpeh.Filter+ComponentsBag`1<T>>)+20]");
				if ((long)intPtr9 <= 0L)
				{
					IntPtr intPtr10 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v293 @ X22_v25 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+12E]");
					if (0u != 0)
					{
						IntPtr intPtr11 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ X22_v35 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+E0]");
						if ((IntPtr)0 != (IntPtr)0)
						{
						}
					}
					IntPtr intPtr12 = (IntPtr)0;
					IntPtr intPtr13 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v377 @ X22_v28 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+B8]");
					IntPtr intPtr14 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v405 @ X23_v8 (Il2CppClass<Morpeh.Filter+ComponentsBag`1>)+12E]");
					if (0 == 0)
					{
						Array.Resize(ref *(ComponentsBag<T>[]*)null, 1);
					}
					IntPtr intPtr15 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v406 @ X9_v11 (Il2CppStaticFields<Morpeh.Filter+ComponentsBag`1<T>>)+24]");
					int newSize = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v466 @ X22_v31 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+B8]");
					Array.Resize(ref *(ComponentsBag<T>[]*)(0L + 24L), newSize);
					IntPtr intPtr16 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v275 @ X23_v11 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+B8]");
					IntPtr intPtr17 = (IntPtr)0;
				}
				IntPtr intPtr18 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v302 @ X22_v13 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr19 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v350 @ X22_v21 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				IntPtr intPtr20 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v394 @ X22_v16 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+B8]");
				IntPtr intPtr21 = (IntPtr)0;
				IntPtr intPtr22 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v451 @ X23_v5 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+B8]");
				IntPtr intPtr23 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ X8_v38 (Il2CppStaticFields<Morpeh.Filter+ComponentsBag`1<T>>)+18]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ X8_v35 (Il2CppStaticFields<Morpeh.Filter+ComponentsBag`1<T>>)+20]");
				IntPtr intPtr24 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ X8_v39+18]");
				if ((long)intPtr24 < 0L)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ X8_v35 (Il2CppStaticFields<Morpeh.Filter+ComponentsBag`1<T>>)+20]");
					int num = 0;
					object obj2 = (long)(IntPtr)obj + (long)num;
					_ = CacheComponents<T>.Components;
					IntPtr intPtr25 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v552 @ X20_v3 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+B8]");
					IntPtr intPtr26 = (IntPtr)0;
					IntPtr intPtr27 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v576 @ X19_v3 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+B8]");
					IntPtr intPtr28 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v566 @ X8_v44 (Il2CppStaticFields<Morpeh.Filter+ComponentsBag`1<T>>)+20]");
					object obj3 = 0L + 1L;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v419 @ X8_v35 (Il2CppStaticFields<Morpeh.Filter+ComponentsBag`1<T>>)+20]");
					return 0;
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				throw ex;
			}
		}

		[Token(Token = "0x200003D")]
		public struct EntityEnumerator : IEnumerator<IEntity>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400006F")]
			[FieldOffset(Offset = "0x0")]
			public World world;

			[Token(Token = "0x4000070")]
			[FieldOffset(Offset = "0x8")]
			internal Entity current;

			[Token(Token = "0x4000071")]
			[FieldOffset(Offset = "0x10")]
			public int[] ids;

			[Token(Token = "0x4000072")]
			[FieldOffset(Offset = "0x18")]
			internal int id;

			[Token(Token = "0x4000073")]
			[FieldOffset(Offset = "0x1C")]
			internal int length;

			[Token(Token = "0x1700001B")]
			public IEntity Current
			{
				[Token(Token = "0x60000FC")]
				[Address(RVA = "0x8639DC", Offset = "0x8639DC", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.id;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					//IL_0007: Expected O, but got I4
					return (IEntity)id;
				}
			}

			[Token(Token = "0x1700001C")]
			object IEnumerator.Current
			{
				[Token(Token = "0x60000FD")]
				[Address(RVA = "0x8639E4", Offset = "0x8639E4", Length = "0x8")]
				[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.id;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
				get
				{
					//IL_0007: Expected O, but got I4
					return id;
				}
			}

			[Token(Token = "0x60000F9")]
			[Address(RVA = "0x8639B0", Offset = "0x8639B0", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.ids = world;\n\tthis.id = 0;\n\t*([this @ X0 (Morpeh.Filter+EntityEnumerator)+20]) = ids;\n\t*([this @ X0 (Morpeh.Filter+EntityEnumerator)+28]) = 0xFFFFFFFF;\n\t*([this @ X0 (Morpeh.Filter+EntityEnumerator)+2C]) = length;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			internal EntityEnumerator(World world, int[] ids, int length)
			{
				this.ids = (int[])(object)world;
				id = 0;
				_ = 4294967295L;
			}

			[Token(Token = "0x60000FA")]
			[Address(RVA = "0x8639C4", Offset = "0x8639C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this + 0x10;\n\treturnVal1 = 0x15F75B8(v0, methodInfo, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17);\n\treturn returnVal1;\n")]
			public unsafe bool MoveNext()
			{
				//IL_000b: Expected O, but got Ref
				object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @15F75B8 (inside Morpeh.Filter::<.ctor>b__15_1 +0x60)");
				bool result = default(bool);
				return result;
			}

			[Token(Token = "0x60000FB")]
			[Address(RVA = "0x8639CC", Offset = "0x8639CC", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.id = 0;\n\t*([this @ X0 (Morpeh.Filter+EntityEnumerator)+28]) = 0xFFFFFFFF;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void Reset()
			{
				id = 0;
				length = 0;
				_ = 4294967295L;
			}

			[Token(Token = "0x60000FE")]
			[Address(RVA = "0x8639EC", Offset = "0x8639EC", Length = "0x14")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.id = 0;\n\t*([this @ X0 (Morpeh.Filter+EntityEnumerator)+20]) = 0;\n\t*([this @ X0 (Morpeh.Filter+EntityEnumerator)+28]) = 0xFFFFFFFF;\n\t*([this @ X0 (Morpeh.Filter+EntityEnumerator)+2C]) = 0xFFFFFFFF;\n\tthis.ids = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public void Dispose()
			{
				id = 0;
				_ = 0;
				_ = 4294967295L;
				_ = 4294967295L;
				ids = null;
			}
		}

		[Token(Token = "0x4000024")]
		[FieldOffset(Offset = "0x10")]
		public int Length;

		[Token(Token = "0x4000025")]
		[FieldOffset(Offset = "0x18")]
		internal ObservableHashSet<int> Entities;

		[Token(Token = "0x4000026")]
		[FieldOffset(Offset = "0x20")]
		public World world;

		[Token(Token = "0x4000027")]
		[FieldOffset(Offset = "0x28")]
		public int[] entitiesCacheForBags;

		[Token(Token = "0x4000028")]
		[FieldOffset(Offset = "0x30")]
		private int entitiesCacheForBagsCapacity;

		[Token(Token = "0x4000029")]
		[FieldOffset(Offset = "0x38")]
		private int[] componentsBags;

		[Token(Token = "0x400002A")]
		[FieldOffset(Offset = "0x40")]
		private int componentsBagsTripleCount;

		[Token(Token = "0x400002B")]
		[FieldOffset(Offset = "0x48")]
		private List<Filter> childs;

		[Token(Token = "0x400002C")]
		[FieldOffset(Offset = "0x50")]
		private FastBitMask mask;

		[Token(Token = "0x400002D")]
		[FieldOffset(Offset = "0x70")]
		private FilterMode filterMode;

		[CanBeNull]
		[Token(Token = "0x400002E")]
		[FieldOffset(Offset = "0x78")]
		private List<int> addedList;

		[CanBeNull]
		[Token(Token = "0x400002F")]
		[FieldOffset(Offset = "0x80")]
		private List<int> removedList;

		[Token(Token = "0x4000030")]
		[FieldOffset(Offset = "0x88")]
		private List<int> dirtyList;

		[Token(Token = "0x6000043")]
		[Address(RVA = "0x15F6494", Offset = "0x15F6494", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1F080D8]);\n\tv23 = *([v22 @ X8_v23]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, world, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A045]) = v41;\nL_0017:\n\tSystem.Object::.ctor(this);\n\tthis.world = world;\n\tv47 = new Morpeh.Utils.ObservableHashSet`1<System.Int32>();\n\tMorpeh.Utils.ObservableHashSet`1<System.Int32>::.ctor(v47);\n\tthis.Entities = v47;\n\tv55 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v55, 0x10000);\n\tthis.dirtyList = v55;\n\tv64 = new System.Collections.Generic.List`1<Morpeh.Filter>();\n\tSystem.Collections.Generic.List`1<Morpeh.Filter>::.ctor(v64);\n\tthis.childs = v64;\n\tgoto L_0045;\n\tv75 = *([v71 @ X0_v9 (Il2CppClass<Morpeh.Utils.FastBitMask>)+E0]);\n\tv76 = v75 == 0;\n\tv77 = ~v76;\n\tif (v77) goto L_0045;\n\tv91 = \"il2cpp_codegen_runtime_class_init\"(v71, v68, v60, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv79 = Morpeh.Utils.FastBitMask;\nL_0045:\n\tv82 = *([v78 @ X0_v10 (Il2CppClass<Morpeh.Utils.FastBitMask>)+B8]);\n\tthis.filterMode = 1;\n\tthis.mask = v82.None;\n\tthis.mask.field2 = *([v82 @ X8_v17 (Il2CppStaticFields<Morpeh.Utils.FastBitMask>)+10]);\n\t// 80 NewArr v90 @ X0_v12 (System.Int32[]), typeof(System.Int32[]), 0\n\tthis.entitiesCacheForBags = v90;\n\tthis.entitiesCacheForBagsCapacity = 0;\n\treturn;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal Filter(World world)
		{
			//IL_0054: Expected I, but got O
			//IL_0081: Expected I, but got O
			//IL_00ae: Expected I8, but got I
			base._002Ector();
			this.world = world;
			ObservableHashSet<int> entities = new ObservableHashSet<int>();
			Entities = entities;
			dirtyList = new List<int>(65536);
			childs = new List<Filter>();
			IntPtr intPtr = (IntPtr)typeof(FastBitMask);
			IntPtr intPtr2 = (IntPtr)FastBitMask.None;
			filterMode = FilterMode.Include;
			mask = FastBitMask.None;
			ref FastBitMask reference = ref mask;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ X8_v17 (Il2CppStaticFields<Morpeh.Utils.FastBitMask>)+10]");
			reference.field2 = 0uL;
			int[] array = new int[0];
			entitiesCacheForBags = array;
			entitiesCacheForBagsCapacity = 0;
		}

		[Token(Token = "0x6000044")]
		[Address(RVA = "0x15F65C0", Offset = "0x15F65C0", Length = "0x430")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv40 = *([1F06FD8]);\n\tv41 = *([v40 @ X8_v45]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, world, rootEntities, mask, mode, fillWithPreviousEntities, methodInfo, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([202A046]) = v55;\nL_0022:\n\tv60 = 0;\n\tSystem.Object::.ctor(this);\n\tthis.world = world;\n\tv64 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v64, 0x20);\n\tthis.addedList = v64;\n\tv71 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v71, 0x20);\n\tthis.removedList = v71;\n\tv78 = new Morpeh.Utils.ObservableHashSet`1<System.Int32>();\n\tMorpeh.Utils.ObservableHashSet`1<System.Int32>::.ctor(v78);\n\tthis.Entities = v78;\n\tv84 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v84, 0x400);\n\tthis.dirtyList = v84;\n\tv91 = new System.Collections.Generic.List`1<Morpeh.Filter>();\n\tSystem.Collections.Generic.List`1<Morpeh.Filter>::.ctor(v91);\n\tthis.childs = v91;\n\tthis.filterMode = mode;\n\tthis.mask = mask.field0;\n\tthis.mask.field2 = mask.field2;\n\t// 91 NewArr v102 @ X0_v14 (System.Int32[]), typeof(System.Int32[]), 0\n\tthis.componentsBags = v102;\n\t// 95 NewArr v105 @ X0_v16 (System.Int32[]), typeof(System.Int32[]), 0\n\tthis.entitiesCacheForBags = v105;\n\tthis.componentsBagsTripleCount = 0;\n\tthis.entitiesCacheForBagsCapacity = 0;\n\tv110 = new System.Action`1<System.Int32>();\n\tSystem.Action`1<System.Int32>::.ctor(v110, this, Il2CppMethodInfo);\n\tv122 = System.Delegate::Combine(rootEntities.OnAddItem, v110);\n\tv124 = v122 == 0;\n\tif (v124) goto L_0085;\n\tv135 = *([v122 @ X0_v20 (System.Delegate)]) != System.Action`1<System.Int32>;\n\tif (v135) goto L_FFFFFFFF;\nL_0085:\n\trootEntities.OnAddItem = v122;\n\tv158 = new System.Action`1<System.Int32>();\n\tSystem.Action`1<System.Int32>::.ctor(v158, this, Il2CppMethodInfo);\n\tv191 = System.Delegate::Combine(rootEntities.OnRemoveItem, v158);\n\tv193 = v191 == 0;\n\tif (v193) goto L_00A2;\n\tv167 = *([v191 @ X0_v37 (System.Delegate)]) != System.Action`1<System.Int32>;\n\tif (v167) goto L_014D;\nL_00A2:\n\trootEntities.OnRemoveItem = v191;\n\tv224 = fillWithPreviousEntities == 0;\n\tif (v224) goto L_0178;\n\tv230 = this + 0x50;\n\tv234 = System.Collections.Generic.HashSet`1<System.Int32>::GetEnumerator(rootEntities);\nL_00B9:\n\tv437 = 0x1183AF4(&v233 @ stack_-88_v3, Il2CppMethodInfo, v425, Il2CppMethodInfo, mode, fillWithPreviousEntities, methodInfo, v44, v233, mask.field2, v47, v48, v49, v50, v51, v52);\n\tv456 = v437 & 1;\n\tv443 = v456 == 0;\n\tif (v443) goto L_014A;\n\tv463 = this.world;\n\tv464 = v463.Entities;\n\tv449 = v464[v326 @ stack_-78 (System.Int32)];\n\tv469 = this.filterMode == 1;\n\tif (v469) goto L_00FD;\n\tv386 = this.filterMode != 2;\n\tif (v386) goto L_00B9;\n\tv481 = *([v449 @ X22_v11 (Morpeh.Entity)]);\n\tv484 = *([v481 @ X8_v38 (Il2CppClass<Morpeh.Entity>)+126]) == 0;\n\tif (v484) goto L_00FB;\n\tv568 = *([v481 @ X8_v38 (Il2CppClass<Morpeh.Entity>)+B0]) + 8;\nL_00E6:\n\tv582 = *([v568 @ X11_v14-8]) == Morpeh.IEntity;\n\tif (v582) goto L_0122;\n\tv567 = v567 + 1;\n\tv598 = v567 < *([v481 @ X8_v38 (Il2CppClass<Morpeh.Entity>)+126]);\n\tv541 = ~v598;\n\tv568 = v568 + 0x10;\n\tv525 = ~v541;\n\tif (v525) goto L_00E6;\nL_00FB:\n\tv605 = 0x8909C4(v464[v326 @ stack_-78 (System.Int32)], Morpeh.IEntity, 8, Il2CppMethodInfo, mode, fillWithPreviousEntities, methodInfo, v44, v233, mask.field2, v47, v48, v49, v50, v51, v52);\n\tgoto L_0127;\nL_00FD:\n\tv477 = *([v449 @ X22_v11 (Morpeh.Entity)]);\n\tv480 = *([v477 @ X8_v34 (Il2CppClass<Morpeh.Entity>)+126]) == 0;\n\tif (v480) goto L_011F;\n\tv547 = *([v477 @ X8_v34 (Il2CppClass<Morpeh.Entity>)+B0]) + 8;\nL_010A:\n\tv561 = *([v547 @ X11_v8-8]) == Morpeh.IEntity;\n\tif (v561) goto L_0135;\n\tv546 = v546 + 1;\n\tv587 = v546 < *([v477 @ X8_v34 (Il2CppClass<Morpeh.Entity>)+126]);\n\tv511 = ~v587;\n\tv547 = v547 + 0x10;\n\tv495 = ~v511;\n\tif (v495) goto L_010A;\nL_011F:\n\tv594 = 0x8909C4(v464[v326 @ stack_-78 (System.Int32)], Morpeh.IEntity, 8, Il2CppMethodInfo, mode, fillWithPreviousEntities, methodInfo, v44, v233, mask.field2, v47, v48, v49, v50, v51, v52);\n\tgoto L_013A;\nL_0122:\n\tv600 = *([v568 @ X11_v14]) + 8;\n\tv601 = v600 << 4;\n\tv602 = v481 + v601;\n\tv605 = v602 + 0x130;\nL_0127:\n\tv425 = *([v605 @ X0_v53+8]);\n\t*([v605 @ X0_v53])(v440, v464[v326 @ stack_-78 (System.Int32)], v230, *([v605 @ X0_v53+8]), Il2CppMethodInfo, mode, fillWithPreviousEntities, methodInfo, v44, v233, mask.field2, v47, v48, v49, v50, v51, v52);\n\tv608 = v440 & 1;\n\tv609 = v608 == 0;\n\tv444 = ~v609;\n\tif (v444) goto L_00B9;\n\tv438 = Morpeh.Utils.ObservableHashSet`1<System.Int32>::Add(this.Entities, v326);\n\tgoto L_00B9;\nL_0135:\n\tv589 = *([v547 @ X11_v8]) + 8;\n\tv590 = v589 << 4;\n\tv591 = v477 + v590;\n\tv594 = v591 + 0x130;\nL_013A:\n\tv425 = *([v594 @ X0_v45+8]);\n\t*([v594 @ X0_v45])(v441, v464[v326 @ stack_-78 (System.Int32)], v230, *([v594 @ X0_v45+8]), Il2CppMethodInfo, mode, fillWithPreviousEntities, methodInfo, v44, v233, mask.field2, v47, v48, v49, v50, v51, v52);\n\tv597 = v441 & 1;\n\tv445 = v597 == 0;\n\tif (v445) goto L_00B9;\n\tv439 = Morpeh.Utils.ObservableHashSet`1<System.Int32>::Add(this.Entities, v326);\n\tgoto L_00B9;\nL_014A:\n\tv459 = 0x1183AF0(&v233 @ stack_-88_v3, Il2CppMethodInfo, v425, Il2CppMethodInfo, mode, fillWithPreviousEntities, methodInfo, v44, v233, mask.field2, v47, v48, v49, v50, v51, v52);\n\tgoto L_0168;\nL_014D:\n\tv198 = new System.InvalidCastException();\n\tgoto L_015B;\n\tgoto L_015B;\n\tgoto L_015B;\n\tgoto L_015B;\nL_015B:\n\tv210 = v188 != 1;\n\tif (v210) goto L_0179;\n\tv225 = 0x6D2BC0(v198, v188, v186, v185, mode, fillWithPreviousEntities, methodInfo, v44, mask.field0, mask.field2, v47, v48, v49, v50, v51, v52);\n\tv311 = 0x6D2490(v225, v188, v186, v185, mode, fillWithPreviousEntities, methodInfo, v44, mask.field0, mask.field2, v47, v48, v49, v50, v51, v52);\n\tv315 = 0x1183AF0(&v60 @ stack_-70_v1, Il2CppMethodInfo, v186, v185, mode, fillWithPreviousEntities, methodInfo, v44, mask.field0, mask.field2, v47, v48, v49, v50, v51, v52);\n\tv455 = *([v225 @ X0_v27]) == 0;\n\tv317 = ~v455;\n\tif (v317) goto L_017D;\nL_0168:\n\tv462 = this.Entities;\n\tthis.Length = v462._count;\n\tMorpeh.Filter::CacheEntities(this);\nL_0178:\n\treturn;\nL_0179:\n\tv226 = 0x6D2380(v198, v188, v186, v185, mode, fillWithPreviousEntities, methodInfo, v44, mask.field0, mask.field2, v47, v48, v49, v50, v51, v52);\nL_017D:\n\tthrow System.TypeLoadException;\n// 247 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private Filter(World world, ObservableHashSet<int> rootEntities, FastBitMask mask, FilterMode mode, bool fillWithPreviousEntities)
		{
			//IL_05e5: Expected O, but got I4
			//IL_009c: Expected O, but got I8
			//IL_050f: Expected I, but got O
			//IL_051d: Expected I, but got O
			//IL_01eb: Expected I, but got O
			//IL_01f9: Expected I, but got O
			//IL_023d: Expected O, but got I
			//IL_024f: Expected I, but got O
			//IL_0381: Expected I, but got O
			//IL_03bc: Expected O, but got I
			//IL_02c5: Expected I, but got O
			//IL_049b: Unknown result type (might be due to invalid IL or missing references)
			//IL_04a0: Expected O, but got Unknown
			//IL_04bd: Expected O, but got I
			//IL_04cc: Expected O, but got I
			//IL_0408: Expected O, but got I
			//IL_0300: Expected O, but got I
			//IL_043e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0443: Expected O, but got Unknown
			//IL_0460: Expected O, but got I
			//IL_046f: Expected O, but got I
			//IL_034c: Expected O, but got I
			base._002Ector();
			object obj = 0;
			this.world = world;
			List<int> list = new List<int>(32);
			addedList = list;
			List<int> list2 = new List<int>(32);
			removedList = list2;
			ObservableHashSet<int> entities = new ObservableHashSet<int>();
			Entities = entities;
			List<int> list3 = new List<int>(1024);
			dirtyList = list3;
			List<Filter> list4 = new List<Filter>();
			childs = list4;
			filterMode = mode;
			this.mask = (FastBitMask)mask.field0;
			this.mask.field2 = mask.field2;
			int[] array = new int[0];
			componentsBags = array;
			int[] array2 = new int[0];
			entitiesCacheForBags = array2;
			componentsBagsTripleCount = 0;
			entitiesCacheForBagsCapacity = 0;
			Action<int> b = delegate(int item)
			{
				addedList.Add(item);
			};
			Delegate obj2 = Delegate.Combine(rootEntities.OnAddItem, b);
			IntPtr intPtr3;
			IntPtr intPtr;
			IntPtr intPtr2;
			if ((object)obj2 == null || (object)obj2.GetType() == typeof(Action<int>))
			{
				rootEntities.OnAddItem = (Action<int>)obj2;
				Action<int> b2 = delegate(int item)
				{
					removedList.Add(item);
				};
				Delegate obj3 = Delegate.Combine(rootEntities.OnRemoveItem, b2);
				if (obj3 != null)
				{
					bool flag = (object)obj3.GetType() != typeof(Action<int>);
					intPtr = (IntPtr)0;
					intPtr2 = (IntPtr)null;
					intPtr3 = (IntPtr)typeof(Action<int>);
					if (flag)
					{
						goto IL_0603;
					}
				}
				rootEntities.OnRemoveItem = (Action<int>)obj3;
				if (!fillWithPreviousEntities)
				{
					return;
				}
				object obj4 = (long)(IntPtr)this + 80L;
				HashSet<int>.Enumerator enumerator = rootEntities.GetEnumerator();
				IntPtr intPtr4 = (IntPtr)null;
				object obj5 = default(object);
				int num = default(int);
				object obj14 = default(object);
				object obj15 = default(object);
				while (true)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1183AF4 (inside System.Collections.Generic.GenericEqualityComparer`1<UnityEngine.Vector4>::.ctor +0x50)");
					if ((int)((long)(IntPtr)obj5 & 1L) == 0)
					{
						break;
					}
					World world2 = this.world;
					Entity[] entities2 = world2.Entities;
					Entity entity = entities2[num];
					if (filterMode != FilterMode.Include)
					{
						if (filterMode != FilterMode.Exclude)
						{
							continue;
						}
						IntPtr intPtr5 = (IntPtr)entity;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ X8_v38 (Il2CppClass<Morpeh.Entity>)+126]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							goto IL_0365;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ X8_v38 (Il2CppClass<Morpeh.Entity>)+B0]");
						object obj6 = 0L + 8L;
						int num2 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v568 @ X11_v14-8]");
							if ((IntPtr)0 == (IntPtr)typeof(IEntity))
							{
								break;
							}
							num2++;
							int num3 = num2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v481 @ X8_v38 (Il2CppClass<Morpeh.Entity>)+126]");
							bool flag2 = (long)num3 < 0L;
							bool flag3 = !flag2;
							obj6 = (long)(IntPtr)obj6 + 16L;
							if (!flag3)
							{
								continue;
							}
							goto IL_0365;
						}
						object obj7 = obj6 + 8;
						int num4 = (int)((long)(IntPtr)obj7 << 4);
						object obj8 = (long)intPtr5 + (long)num4;
						object obj9 = (long)(IntPtr)obj8 + 304L;
						goto IL_0676;
					}
					IntPtr intPtr6 = (IntPtr)entity;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v477 @ X8_v34 (Il2CppClass<Morpeh.Entity>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_0421;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v477 @ X8_v34 (Il2CppClass<Morpeh.Entity>)+B0]");
					object obj10 = 0L + 8L;
					int num5 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v547 @ X11_v8-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IEntity))
						{
							break;
						}
						num5++;
						int num6 = num5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v477 @ X8_v34 (Il2CppClass<Morpeh.Entity>)+126]");
						bool flag4 = (long)num6 < 0L;
						bool flag5 = !flag4;
						obj10 = (long)(IntPtr)obj10 + 16L;
						if (!flag5)
						{
							continue;
						}
						goto IL_0421;
					}
					object obj11 = obj10 + 8;
					int num7 = (int)((long)(IntPtr)obj11 << 4);
					object obj12 = (long)intPtr6 + (long)num7;
					object obj13 = (long)(IntPtr)obj12 + 304L;
					goto IL_06f1;
					IL_0365:
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
					goto IL_0676;
					IL_06f1:
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v594 @ X0_v45+8]");
					intPtr4 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v594 @ X0_v45] (should have been resolved before IL gen)");
					if ((uint)((ulong)(long)(IntPtr)obj14 & 1uL) != 0)
					{
						bool flag6 = Entities.Add(num);
						intPtr4 = (IntPtr)0;
					}
					continue;
					IL_0676:
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v605 @ X0_v53+8]");
					intPtr4 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v605 @ X0_v53] (should have been resolved before IL gen)");
					if ((int)((long)(IntPtr)obj15 & 1L) == 0)
					{
						bool flag7 = Entities.Add(num);
						intPtr4 = (IntPtr)0;
					}
					continue;
					IL_0421:
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
					goto IL_06f1;
				}
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1183AF0 (inside System.Collections.Generic.GenericEqualityComparer`1<UnityEngine.Vector4>::.ctor +0x4C)");
				goto IL_059d;
			}
			intPtr = (IntPtr)0;
			intPtr2 = (IntPtr)null;
			intPtr3 = (IntPtr)typeof(Action<int>);
			goto IL_0603;
			IL_059d:
			ObservableHashSet<int> entities3 = Entities;
			Length = entities3.Count;
			CacheEntities();
			return;
			IL_0603:
			InvalidCastException ex = new InvalidCastException();
			if (intPtr3 == (IntPtr)1)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1183AF0 (inside System.Collections.Generic.GenericEqualityComparer`1<UnityEngine.Vector4>::.ctor +0x4C)");
				object obj16 = default(object);
				if (obj16 == null)
				{
					goto IL_059d;
				}
			}
			else
			{
				Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x6000045")]
		[Address(RVA = "0x15F6B40", Offset = "0x15F6B40", Length = "0x1B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EB8098]);\n\tv19 = *([v18 @ X8_v25]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A047]) = v38;\nL_0015:\n\tv41 = 0;\n\tv47 = System.Collections.Generic.List`1<Morpeh.Filter>::GetEnumerator(this.childs);\nL_0020:\n\tv57 = System.Collections.Generic.List`1<Morpeh.Filter>+Enumerator<Morpeh.Filter>::MoveNext(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<Morpeh.Filter>+Enumerator<Morpeh.Filter>));\n\tv55 = v57 == 0;\n\tif (v55) goto L_002B;\n\tMorpeh.Filter::Dispose(0);\n\tgoto L_0020;\nL_002B:\n\tv63 = System.Collections.Generic.List`1<Morpeh.Filter>+Enumerator<Morpeh.Filter>::Dispose(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<Morpeh.Filter>+Enumerator<Morpeh.Filter>));\n\tgoto L_0048;\n\tgoto L_002E;\nL_002E:\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0086;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1F082D8]);\n\tX0 = &stack[8];\n\tX1 = *([X8]);\n\tX0 = 0xEF9AAC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0087;\nL_0048:\n\tSystem.Collections.Generic.List`1<Morpeh.Filter>::Clear(this.childs);\n\tthis.childs = 0;\n\tthis.Length = 0xFFFFFFFF;\n\tSystem.Collections.Generic.HashSet`1<System.Int32>::Clear(this.Entities);\n\tthis.world = 0;\n\tthis.entitiesCacheForBags = 0;\n\tthis.Entities = 0;\n\tthis.entitiesCacheForBagsCapacity = 0xFFFFFFFF;\n\tthis.componentsBags = 0;\n\tthis.componentsBagsTripleCount = 0xFFFFFFFF;\n\tgoto L_0064;\n\tv79 = *([v75 @ X0_v11 (Il2CppClass<Morpeh.Utils.FastBitMask>)+E0]);\n\tv80 = v79 == 0;\n\tv81 = ~v80;\n\tif (v81) goto L_0064;\n\tv91 = \"il2cpp_codegen_runtime_class_init\"(v75, v72, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv83 = Morpeh.Utils.FastBitMask;\nL_0064:\n\tv86 = *([v82 @ X0_v12 (Il2CppClass<Morpeh.Utils.FastBitMask>)+B8]);\n\tthis.filterMode = 0;\n\tthis.mask = v86.None;\n\tthis.mask.field2 = *([v86 @ X8_v14 (Il2CppStaticFields<Morpeh.Utils.FastBitMask>)+10]);\n\tv90 = this.addedList == 0;\n\tif (v90) goto L_0072;\n\tSystem.Collections.Generic.List`1<System.Int32>::Clear(this.addedList);\nL_0072:\n\tthis.addedList = 0;\n\tv98 = this.removedList == 0;\n\tif (v98) goto L_0079;\n\tSystem.Collections.Generic.List`1<System.Int32>::Clear(this.removedList);\nL_0079:\n\tthis.removedList = 0;\n\tSystem.Collections.Generic.List`1<System.Int32>::Clear(this.dirtyList);\n\tthis.dirtyList = 0;\n\treturn;\nL_0086:\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0087:\n\tX0 = X20;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Dispose()
		{
			//IL_008b: Expected I, but got O
			//IL_0141: Expected I, but got O
			//IL_0177: Expected I8, but got I
			List<Filter>.Enumerator enumerator = default(List<Filter>.Enumerator);
			List<Filter>.Enumerator enumerator2 = childs.GetEnumerator();
			while (enumerator.MoveNext())
			{
				((Filter)null).Dispose();
			}
			enumerator.Dispose();
			childs.Clear();
			childs = null;
			Length = -1;
			Entities.Clear();
			world = null;
			entitiesCacheForBags = null;
			Entities = null;
			entitiesCacheForBagsCapacity = -1;
			componentsBags = null;
			componentsBagsTripleCount = -1;
			IntPtr intPtr = (IntPtr)typeof(FastBitMask);
			IntPtr intPtr2 = (IntPtr)FastBitMask.None;
			filterMode = default(FilterMode);
			mask = FastBitMask.None;
			ref FastBitMask reference = ref mask;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ X8_v14 (Il2CppStaticFields<Morpeh.Utils.FastBitMask>)+10]");
			reference.field2 = 0uL;
			if (addedList != null)
			{
				addedList.Clear();
			}
			addedList = null;
			if (removedList != null)
			{
				removedList.Clear();
			}
			removedList = null;
			dirtyList.Clear();
			dirtyList = null;
		}

		[Token(Token = "0x6000046")]
		[Address(RVA = "0x15F6CF4", Offset = "0x15F6CF4", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv22 = *([1EEA838]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, id, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A048]) = v41;\nL_0020:\n\tSystem.Collections.Generic.List`1<System.Int32>::Add(this.dirtyList, id);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal void EntityChanged(int id)
		{
			dirtyList.Add(id);
		}

		[Token(Token = "0x6000047")]
		[Address(RVA = "0x15F6D54", Offset = "0x15F6D54", Length = "0x604")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv34 = *([1EC2830]);\n\tv35 = *([v34 @ X8_v78]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([202A049]) = v54;\nL_0025:\n\tgoto L_0037;\n\tv65 = *([v61 @ X0_v2 (Il2CppClass<Morpeh.Utils.FastBitMask>)+E0]);\n\tv66 = v65 == 0;\n\tv67 = ~v66;\n\tgoto L_0037;\n\tv84 = \"il2cpp_codegen_runtime_class_init\"(v61, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv69 = Morpeh.Utils.FastBitMask;\nL_0037:\n\tv83 = this.mask.field3 != v72.None;\n\tif (v83) goto L_009F;\n\tv94 = this.mask.field2 != v72.None;\n\tif (v94) goto L_009F;\n\tv96 = this.mask != v72.None;\n\tif (v96) goto L_009F;\n\tv97 = this.mask.field1 != v72.None;\n\tif (v97) goto L_009F;\n\tv363 = this.childs;\n\tv555 = v363._size;\n\tv302 = v363._size < 1;\n\tif (v302) goto L_009D;\n\tv356 = v363._size - 1;\n\tgoto L_006E;\nL_006B:\n\tv363 = this.childs;\n\tv387 = v387 + 1;\n\tv555 = v363._size;\nL_006E:\n\tv558 = v387 < v555;\n\tv559 = ~v558;\n\tv567 = ~v559;\n\tif (v567) goto L_007B;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_007B:\n\tv667 = v363._items;\n\tMorpeh.Filter::ChildrensUpdate(v667[v387 @ X20_v21 (System.Int32)], this.dirtyList);\n\tv365 = v356 != v387;\n\tif (v365) goto L_006B;\nL_009D:\n\tSystem.Collections.Generic.List`1<System.Int32>::Clear(this.dirtyList);\n\treturn;\nL_009F:\n\tv218 = this.dirtyList;\n\tv124 = v218._size - 1;\n\tv125 = v124 & 0x80000000;\n\tv126 = v125 == 0;\n\tv127 = ~v126;\n\tif (v127) goto L_016D;\n\tv137 = this + 0x50;\n\tgoto L_00B4;\nL_00B2:\n\tv218 = this.dirtyList;\n\tv231 = v218._size;\nL_00B4:\n\tv233 = v217 < v231;\n\tv234 = ~v233;\n\tv242 = ~v234;\n\tif (v242) goto L_00C1;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_00C1:\n\tv305 = v218._items;\n\tv306 = this.world;\n\tv309 = v306.Entities;\n\tv159 = v309[v305[v217 @ X21_v20 (System.Int32)]];\n\tv312 = v309[v305[v217 @ X21_v20 (System.Int32)]] == 0;\n\tif (v312) goto L_0169;\n\tv457 = this.filterMode;\n\tv414 = this.filterMode != 1;\n\tif (v414) goto L_0125;\n\tv568 = *([v159 @ X23_v13 (Morpeh.Entity)]);\n\tv571 = *([v568 @ X8_v61 (Il2CppClass<Morpeh.Entity>)+126]) == 0;\n\tif (v571) goto L_00FA;\n\tv811 = *([v568 @ X8_v61 (Il2CppClass<Morpeh.Entity>)+B0]) + 8;\nL_00E5:\n\tv825 = *([v811 @ X11_v36-8]) == Morpeh.IEntity;\n\tif (v825) goto L_00FD;\n\tv810 = v810 + 1;\n\tv913 = v810 < *([v568 @ X8_v61 (Il2CppClass<Morpeh.Entity>)+126]);\n\tv767 = ~v913;\n\tv811 = v811 + 0x10;\n\tv751 = ~v767;\n\tif (v751) goto L_00E5;\nL_00FA:\n\tv920 = 0x8909C4(v309[v305[v217 @ X21_v20 (System.Int32)]], Morpeh.IEntity, 8, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_0105;\nL_00FD:\n\tv915 = *([v811 @ X11_v36]) + 8;\n\tv916 = v915 << 4;\n\tv917 = v568 + v916;\n\tv920 = v917 + 0x130;\nL_0105:\n\t*([v920 @ X0_v57])(v926, v309[v305[v217 @ X21_v20 (System.Int32)]], v137, *([v920 @ X0_v57+8]), v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv928 = v926 & 1;\n\tv929 = v928 == 0;\n\tif (v929) goto L_0116;\n\tv1095 = Morpeh.Utils.ObservableHashSet`1<System.Int32>::Add(this.Entities, v305[v217 @ X21_v20 (System.Int32)]);\n\tv1195 = v1095 == 0;\n\tv1196 = ~v1195;\n\tif (v1196) goto L_011A;\n\tgoto L_011B;\nL_0116:\n\tv1099 = Morpeh.Utils.ObservableHashSet`1<System.Int32>::Remove(this.Entities, v305[v217 @ X21_v20 (System.Int32)]);\nL_011A:\n\tMorpeh.Utils.ListExtensions::RemoveAtFast(this.dirtyList, v217);\nL_011B:\n\tv457 = this.filterMode;\nL_0125:\n\tv432 = v457 != 2;\n\tif (v432) goto L_0169;\n\tv771 = *([v159 @ X23_v13 (Morpeh.Entity)]);\n\tv774 = *([v771 @ X8_v56 (Il2CppClass<Morpeh.Entity>)+126]) == 0;\n\tif (v774) goto L_0149;\n\tv932 = *([v771 @ X8_v56 (Il2CppClass<Morpeh.Entity>)+B0]) + 8;\nL_0134:\n\tv946 = *([v932 @ X11_v30-8]) == Morpeh.IEntity;\n\tif (v946) goto L_014C;\n\tv931 = v931 + 1;\n\tv1100 = v931 < *([v771 @ X8_v56 (Il2CppClass<Morpeh.Entity>)+126]);\n\tv856 = ~v1100;\n\tv932 = v932 + 0x10;\n\tv840 = ~v856;\n\tif (v840) goto L_0134;\nL_0149:\n\tv1107 = 0x8909C4(v309[v305[v217 @ X21_v20 (System.Int32)]], Morpeh.IEntity, 8, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_0154;\nL_014C:\n\tv1102 = *([v932 @ X11_v30]) + 8;\n\tv1103 = v1102 << 4;\n\tv1104 = v771 + v1103;\n\tv1107 = v1104 + 0x130;\nL_0154:\n\t*([v1107 @ X0_v45])(v1113, v309[v305[v217 @ X21_v20 (System.Int32)]], v137, *([v1107 @ X0_v45+8]), v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv1114 = v1113 & 1;\n\tv1115 = v1114 == 0;\n\tif (v1115) goto L_0161;\n\tv1207 = Morpeh.Utils.ObservableHashSet`1<System.Int32>::Remove(this.Entities, v305[v217 @ X21_v20 (System.Int32)]);\n\tgoto L_0168;\nL_0161:\n\tv450 = Morpeh.Utils.ObservableHashSet`1<System.Int32>::Add(this.Entities, v305[v217 @ X21_v20 (System.Int32)]);\n\tv454 = v450 == 0;\n\tif (v454) goto L_0169;\nL_0168:\n\tMorpeh.Utils.ListExtensions::RemoveAtFast(this.dirtyList, v217);\nL_0169:\n\tv217 = v217 - 1;\n\tv458 = v217 & 0x80000000;\n\tv190 = v458 == 0;\n\tif (v190) goto L_00B2;\nL_016D:\n\tv640 = this.addedList;\n\tv342 = v640._size;\n\tv207 = v640._size > 0;\n\tif (v207) goto L_01A5;\n\tv243 = this.removedList;\n\tv256 = v243._size > 0;\n\tif (v256) goto L_01A5;\n\tv313 = this.dirtyList;\n\tv261 = v218._size != v313._size;\n\tif (v261) goto L_01A5;\n\tgoto L_0278;\nL_01A5:\n\tv289 = this.componentsBagsTripleCount < 3;\n\tif (v289) goto L_01C6;\nL_01A9:\n\tv483 = this.componentsBags;\n\tv482 = v480 + 3;\n\tv483[v480 @ X8_v43 (System.Int32)] = 1;\n\tv325 = v482 < this.componentsBagsTripleCount;\n\tif (v325) goto L_01A9;\n\tv640 = this.addedList;\n\tv342 = v640._size;\nL_01C6:\n\tv354 = v342 < 1;\n\tif (v354) goto L_FFFFFFFF;\n\tv491 = this + 0x50;\n\tgoto L_01D1;\nL_01D0:\n\tv653 = v640._size;\nL_01D1:\n\tv655 = v637 < v653;\n\tv656 = ~v655;\n\tv664 = ~v656;\n\tif (v664) goto L_01DE;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_01DE:\n\tv790 = v640._items;\n\tv791 = this.world;\n\tv795 = v791.Entities;\n\tv515 = v795[v790[v637 @ X23_v10 (System.Int32)]];\n\tv803 = this.filterMode == 2;\n\tif (v803) goto L_0221;\n\tv908 = this.filterMode != 1;\n\tif (v908) goto L_0266;\n\tv991 = *([v515 @ X22_v10 (Morpeh.Entity)]);\n\tv994 = *([v991 @ X8_v38 (Il2CppClass<Morpeh.Entity>)+126]) == 0;\n\tif (v994) goto L_021F;\n\tv1239 = *([v991 @ X8_v38 (Il2CppClass<Morpeh.Entity>)+B0]) + 8;\nL_020A:\n\tv1253 = *([v1239 @ X11_v18-8]) == Morpeh.IEntity;\n\tif (v1253) goto L_0246;\n\tv1238 = v1238 + 1;\n\tv1274 = v1238 < *([v991 @ X8_v38 (Il2CppClass<Morpeh.Entity>)+126]);\n\tv1169 = ~v1274;\n\tv1239 = v1239 + 0x10;\n\tv1153 = ~v1169;\n\tif (v1153) goto L_020A;\nL_021F:\n\tv1281 = 0x8909C4(v795[v790[v637 @ X23_v10 (System.Int32)]], Morpeh.IEntity, 8, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_024B;\nL_0221:\n\tv909 = *([v515 @ X22_v10 (Morpeh.Entity)]);\n\tv912 = *([v909 @ X8_v34 (Il2CppClass<Morpeh.Entity>)+126]) == 0;\n\tif (v912) goto L_0243;\n\tv1175 = *([v909 @ X8_v34 (Il2CppClass<Morpeh.Entity>)+B0]) + 8;\nL_022E:\n\tv1189 = *([v1175 @ X11_v12-8]) == Morpeh.IEntity;\n\tif (v1189) goto L_0255;\n\tv1174 = v1174 + 1;\n\tv1258 = v1174 < *([v909 @ X8_v34 (Il2CppClass<Morpeh.Entity>)+126]);\n\tv1088 = ~v1258;\n\tv1175 = v1175 + 0x10;\n\tv1072 = ~v1088;\n\tif (v1072) goto L_022E;\nL_0243:\n\tv1265 = 0x8909C4(v795[v790[v637 @ X23_v10 (System.Int32)]], Morpeh.IEntity, 8, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_025A;\nL_0246:\n\tv1276 = *([v1239 @ X11_v18]) + 8;\n\tv1277 = v1276 << 4;\n\tv1278 = v991 + v1277;\n\tv1281 = v1278 + 0x130;\nL_024B:\n\t;\n\t*([v1281 @ X0_v34])(v1053, v795[v790[v637 @ X23_v10 (System.Int32)]], v491, *([v1281 @ X0_v34+8]), v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv1284 = v1053 & 1;\n\tv1285 = v1284 == 0;\n\tv1056 = ~v1285;\n\tif (v1056) goto L_0265;\n\tgoto L_0266;\nL_0255:\n\tv1260 = *([v1175 @ X11_v12]) + 8;\n\tv1261 = v1260 << 4;\n\tv1262 = v909 + v1261;\n\tv1265 = v1262 + 0x130;\nL_025A:\n\t;\n\t*([v1265 @ X0_v28])(v1054, v795[v790[v637 @ X23_v10 (System.Int32)]], v491, *([v1265 @ X0_v28+8]), v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv1268 = v1054 & 1;\n\tv1269 = v1268 == 0;\n\tv1057 = ~v1269;\n\tif (v1057) goto L_0266;\nL_0265:\n\tv1052 = Morpeh.Utils.ObservableHashSet`1<System.Int32>::Add(this.Entities, v790[v637 @ X23_v10 (System.Int32)]);\nL_0266:\n\tv640 = this.addedList;\n\tv637 = v637 + 1;\n\tv517 = v637 != v342;\n\tif (v517) goto L_0\n// ... truncated")]
		public void Update()
		{
			//IL_0183: Expected I4, but got I8
			//IL_01b7: Expected O, but got I
			//IL_06c6: Expected O, but got I
			//IL_05a6: Expected I4, but got I8
			//IL_083c: Expected I, but got O
			//IL_0299: Expected I, but got O
			//IL_0423: Expected I, but got O
			//IL_0877: Expected O, but got I
			//IL_02d4: Expected O, but got I
			//IL_0780: Expected I, but got O
			//IL_045e: Expected O, but got I
			//IL_093d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0942: Expected O, but got Unknown
			//IL_095f: Expected O, but got I
			//IL_096e: Expected O, but got I
			//IL_0356: Unknown result type (might be due to invalid IL or missing references)
			//IL_035b: Expected O, but got Unknown
			//IL_0378: Expected O, but got I
			//IL_0387: Expected O, but got I
			//IL_08c3: Expected O, but got I
			//IL_07bb: Expected O, but got I
			//IL_04e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_04e5: Expected O, but got Unknown
			//IL_0502: Expected O, but got I
			//IL_0511: Expected O, but got I
			//IL_0320: Expected O, but got I
			//IL_04aa: Expected O, but got I
			//IL_08f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_08fe: Expected O, but got Unknown
			//IL_091b: Expected O, but got I
			//IL_092a: Expected O, but got I
			//IL_0807: Expected O, but got I
			if (mask.field3 == (ulong)(long)FastBitMask.None && mask.field2 == (ulong)(long)FastBitMask.None && (object)mask == (object)FastBitMask.None && mask.field1 == (ulong)(long)FastBitMask.None)
			{
				List<Filter> list = childs;
				int count = list.Count;
				if (list.Count >= 1)
				{
					int num = list.Count - 1;
					int num2 = 0;
					while (true)
					{
						if (num2 >= count)
						{
							throw new ArgumentOutOfRangeException();
						}
						Filter[] items = list._items;
						items[num2].ChildrensUpdate(dirtyList);
						if (num != num2)
						{
							list = childs;
							num2++;
							count = list.Count;
							continue;
						}
						break;
					}
				}
				dirtyList.Clear();
				return;
			}
			List<int> list2 = dirtyList;
			int num3 = list2.Count - 1;
			if ((int)(num3 & 0x80000000L) == 0)
			{
				object obj = (long)(IntPtr)this + 80L;
				int num4 = num3;
				int count2 = list2.Count;
				object obj6 = default(object);
				object obj7 = default(object);
				while (true)
				{
					if (num4 >= count2)
					{
						throw new ArgumentOutOfRangeException();
					}
					int[] items2 = list2._items;
					World world = this.world;
					Entity[] entities = world.Entities;
					Entity entity = entities[items2[num4]];
					if (entities[items2[num4]] == null)
					{
						goto IL_0586;
					}
					FilterMode filterMode = this.filterMode;
					if (this.filterMode != FilterMode.Include)
					{
						goto IL_0c2e;
					}
					IntPtr intPtr = (IntPtr)entity;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v568 @ X8_v61 (Il2CppClass<Morpeh.Entity>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_0339;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v568 @ X8_v61 (Il2CppClass<Morpeh.Entity>)+B0]");
					object obj2 = 0L + 8L;
					int num5 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v811 @ X11_v36-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IEntity))
						{
							break;
						}
						num5++;
						int num6 = num5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v568 @ X8_v61 (Il2CppClass<Morpeh.Entity>)+126]");
						bool flag = (long)num6 < 0L;
						bool flag2 = !flag;
						obj2 = (long)(IntPtr)obj2 + 16L;
						if (!flag2)
						{
							continue;
						}
						goto IL_0339;
					}
					object obj3 = obj2 + 8;
					int num7 = (int)((long)(IntPtr)obj3 << 4);
					object obj4 = (long)intPtr + (long)num7;
					object obj5 = (long)(IntPtr)obj4 + 304L;
					goto IL_0c78;
					IL_0339:
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
					goto IL_0c78;
					IL_0c78:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v920 @ X0_v57] (should have been resolved before IL gen)");
					if ((uint)((ulong)(long)(IntPtr)obj6 & 1uL) != 0)
					{
						if (!Entities.Add(items2[num4]))
						{
							goto IL_040c;
						}
					}
					else
					{
						bool flag3 = Entities.Remove(items2[num4]);
					}
					dirtyList.RemoveAtFast(num4);
					goto IL_040c;
					IL_04c3:
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
					goto IL_0cd8;
					IL_0cd8:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1107 @ X0_v45] (should have been resolved before IL gen)");
					if ((uint)((ulong)(long)(IntPtr)obj7 & 1uL) != 0)
					{
						bool flag4 = Entities.Remove(items2[num4]);
					}
					else if (!Entities.Add(items2[num4]))
					{
						goto IL_0586;
					}
					dirtyList.RemoveAtFast(num4);
					goto IL_0586;
					IL_0586:
					num4--;
					if ((int)(num4 & 0x80000000L) == 0)
					{
						list2 = dirtyList;
						count2 = list2.Count;
						continue;
					}
					break;
					IL_040c:
					filterMode = this.filterMode;
					goto IL_0c2e;
					IL_0c2e:
					if (filterMode != FilterMode.Exclude)
					{
						goto IL_0586;
					}
					IntPtr intPtr2 = (IntPtr)entity;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v771 @ X8_v56 (Il2CppClass<Morpeh.Entity>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_04c3;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v771 @ X8_v56 (Il2CppClass<Morpeh.Entity>)+B0]");
					object obj8 = 0L + 8L;
					int num8 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v932 @ X11_v30-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IEntity))
						{
							break;
						}
						num8++;
						int num9 = num8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v771 @ X8_v56 (Il2CppClass<Morpeh.Entity>)+126]");
						bool flag5 = (long)num9 < 0L;
						bool flag6 = !flag5;
						obj8 = (long)(IntPtr)obj8 + 16L;
						if (!flag6)
						{
							continue;
						}
						goto IL_04c3;
					}
					object obj9 = obj8 + 8;
					int num10 = (int)((long)(IntPtr)obj9 << 4);
					object obj10 = (long)intPtr2 + (long)num10;
					object obj11 = (long)(IntPtr)obj10 + 304L;
					goto IL_0cd8;
				}
			}
			List<int> list3 = addedList;
			int count3 = list3.Count;
			int num11;
			if (list3.Count <= 0)
			{
				List<int> list4 = removedList;
				if (list4.Count <= 0)
				{
					List<int> list5 = dirtyList;
					if (list2.Count == list5.Count)
					{
						num11 = 0;
						goto IL_0d0e;
					}
				}
			}
			if (componentsBagsTripleCount >= 3)
			{
				int num12 = 2;
				int num13 = default(int);
				num12 = num13;
				bool flag7;
				do
				{
					int[] array = componentsBags;
					int num14 = num12 + 3;
					array[num12] = 1;
					flag7 = num14 < componentsBagsTripleCount;
					num12 = num14;
				}
				while (flag7);
				list3 = addedList;
				count3 = list3.Count;
			}
			if (count3 >= 1)
			{
				object obj12 = (long)(IntPtr)this + 80L;
				int num15 = 0;
				int num16 = count3;
				object obj21 = default(object);
				object obj22 = default(object);
				while (true)
				{
					if (num15 >= num16)
					{
						throw new ArgumentOutOfRangeException();
					}
					int[] items3 = list3._items;
					World world2 = this.world;
					Entity[] entities2 = world2.Entities;
					Entity entity2 = entities2[items3[num15]];
					if (this.filterMode != FilterMode.Exclude)
					{
						if (this.filterMode != FilterMode.Include)
						{
							goto IL_0995;
						}
						IntPtr intPtr3 = (IntPtr)entity2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v991 @ X8_v38 (Il2CppClass<Morpeh.Entity>)+126]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							goto IL_0820;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v991 @ X8_v38 (Il2CppClass<Morpeh.Entity>)+B0]");
						object obj13 = 0L + 8L;
						int num17 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1239 @ X11_v18-8]");
							if ((IntPtr)0 == (IntPtr)typeof(IEntity))
							{
								break;
							}
							num17++;
							int num18 = num17;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v991 @ X8_v38 (Il2CppClass<Morpeh.Entity>)+126]");
							bool flag8 = (long)num18 < 0L;
							bool flag9 = !flag8;
							obj13 = (long)(IntPtr)obj13 + 16L;
							if (!flag9)
							{
								continue;
							}
							goto IL_0820;
						}
						object obj14 = obj13 + 8;
						int num19 = (int)((long)(IntPtr)obj14 << 4);
						object obj15 = (long)intPtr3 + (long)num19;
						object obj16 = (long)(IntPtr)obj15 + 304L;
						goto IL_0e19;
					}
					IntPtr intPtr4 = (IntPtr)entity2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v909 @ X8_v34 (Il2CppClass<Morpeh.Entity>)+126]");
					if ((IntPtr)0 == (IntPtr)0)
					{
						goto IL_08dc;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v909 @ X8_v34 (Il2CppClass<Morpeh.Entity>)+B0]");
					object obj17 = 0L + 8L;
					int num20 = 0;
					while (true)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1175 @ X11_v12-8]");
						if ((IntPtr)0 == (IntPtr)typeof(IEntity))
						{
							break;
						}
						num20++;
						int num21 = num20;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v909 @ X8_v34 (Il2CppClass<Morpeh.Entity>)+126]");
						bool flag10 = (long)num21 < 0L;
						bool flag11 = !flag10;
						obj17 = (long)(IntPtr)obj17 + 16L;
						if (!flag11)
						{
							continue;
						}
						goto IL_08dc;
					}
					object obj18 = obj17 + 8;
					int num22 = (int)((long)(IntPtr)obj18 << 4);
					object obj19 = (long)intPtr4 + (long)num22;
					object obj20 = (long)(IntPtr)obj19 + 304L;
					goto IL_0e85;
					IL_08dc:
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
					goto IL_0e85;
					IL_0820:
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8909C4");
					goto IL_0e19;
					IL_0e19:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1281 @ X0_v34] (should have been resolved before IL gen)");
					if ((uint)((ulong)(long)(IntPtr)obj21 & 1uL) != 0)
					{
						goto IL_0973;
					}
					goto IL_0995;
					IL_0e85:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1265 @ X0_v28] (should have been resolved before IL gen)");
					if ((int)((long)(IntPtr)obj22 & 1L) == 0)
					{
						goto IL_0973;
					}
					goto IL_0995;
					IL_0973:
					bool flag12 = Entities.Add(items3[num15]);
					goto IL_0995;
					IL_0995:
					list3 = addedList;
					num15++;
					if (num15 != count3)
					{
						num16 = list3.Count;
						continue;
					}
					break;
				}
			}
			num11 = 1;
			goto IL_0d0e;
			IL_0d0e:
			list3.Clear();
			List<int> list6 = removedList;
			int count4 = list6.Count;
			if (list6.Count >= 1)
			{
				int num23 = list6.Count - 1;
				int num24 = 0;
				while (true)
				{
					if (num24 >= count4)
					{
						throw new ArgumentOutOfRangeException();
					}
					int[] items4 = list6._items;
					bool flag13 = Entities.Remove(items4[num24]);
					list6 = removedList;
					if (num23 != num24)
					{
						count4 = list6.Count;
						num24++;
						continue;
					}
					break;
				}
			}
			list6.Clear();
			List<Filter> list7 = childs;
			int count5 = list7.Count;
			if (list7.Count >= 1)
			{
				int num25 = list7.Count - 1;
				int num26 = 0;
				while (true)
				{
					if (num26 >= count5)
					{
						throw new ArgumentOutOfRangeException();
					}
					Filter[] items5 = list7._items;
					items5[num26].ChildrensUpdate(dirtyList);
					if (num25 != num26)
					{
						list7 = childs;
						num26++;
						count5 = list7.Count;
						continue;
					}
					break;
				}
			}
			dirtyList.Clear();
			ObservableHashSet<int> entities3 = Entities;
			Length = entities3.Count;
			if (num11 != 0)
			{
				CacheEntities();
			}
		}

		[Token(Token = "0x6000048")]
		[Address(RVA = "0x15F6A04", Offset = "0x15F6A04", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv20 = *([1F0F190]);\n\tv21 = *([v20 @ X8_v18]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([202A04A]) = v40;\nL_0019:\n\tv46 = this + 0x28;\n\tv56 = this.entitiesCacheForBagsCapacity >= this.Length;\n\tif (v56) goto L_0031;\n\tSystem.Array::Resize(v46, this.Length);\n\tthis.entitiesCacheForBagsCapacity = this.Length;\nL_0031:\n\tv71 = System.Collections.Generic.HashSet`1<System.Int32>::GetEnumerator(this.Entities);\n\tgoto L_0042;\nL_003A:\n\tv104 = this.entitiesCacheForBags;\n\tv93 = v92 + 1;\n\tv104[v92 @ X20_v3 (System.Int32)] = v73;\nL_0042:\n\tv89 = System.Collections.Generic.HashSet`1<System.Int32>+Enumerator<System.Int32>::MoveNext(&v70 @ stack_-68_v1 (System.Collections.Generic.HashSet`1<System.Int32>+Enumerator<System.Int32>));\n\tv98 = v89 == 0;\n\tv91 = ~v98;\n\tif (v91) goto L_003A;\n\tv103 = System.Collections.Generic.HashSet`1<System.Int32>+Enumerator<System.Int32>::Dispose(&v70 @ stack_-68_v1 (System.Collections.Generic.HashSet`1<System.Int32>+Enumerator<System.Int32>));\n\tgoto L_0069;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_006A;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EFBAE8]);\n\tX0 = &stack[20];\n\tX1 = *([X8]);\n\tX0 = 0x1183AF0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_006B;\nL_0069:\n\treturn;\nL_006A:\n\tX0 = 0x6D2380(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_006B:\n\tX0 = X19;\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void CacheEntities()
		{
			//IL_004d: Expected I4, but got O
			ref int[] reference = ref *(int[]*)((long)(IntPtr)this + 40L);
			if (entitiesCacheForBagsCapacity < Length)
			{
				Array.Resize(ref reference, Length);
				entitiesCacheForBagsCapacity = Length;
			}
			HashSet<int>.Enumerator enumerator = Entities.GetEnumerator();
			int num = 0;
			HashSet<int>.Enumerator enumerator2 = default(HashSet<int>.Enumerator);
			object obj = default(object);
			while (enumerator2.MoveNext())
			{
				int[] array = reference;
				int num2 = num + 1;
				array[num] = (int)obj;
				num = num2;
			}
			enumerator2.Dispose();
		}

		[Token(Token = "0x6000049")]
		[Address(RVA = "0x15F7358", Offset = "0x15F7358", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv22 = *([1EE0D08]);\n\tv23 = *([v22 @ X8_v6]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, parentDirtyList, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A04B]) = v41;\nL_001A:\n\tSystem.Collections.Generic.List`1<System.Int32>::AddRange(this.dirtyList, parentDirtyList);\n\tMorpeh.Filter::Update(this);\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ChildrensUpdate(List<int> parentDirtyList)
		{
			dirtyList.AddRange(parentDirtyList);
			Update();
		}

		[Token(Token = "0x600004A")]
		[Address(RVA = "0x14F668C", Offset = "0x14F668C", Length = "0x3F0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv28 = *([1EBCAC8]);\n\tv29 = *([v28 @ X8_v84]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2028E60]) = v47;\nL_0019:\n\tv49 = Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>;\n\tgoto L_0022;\n\tv54 = v49;\n\tv55 = System.Array::Resize(v54, methodInfo, v31);\n\tv58 = *([v49 @ X21_v2 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]);\nL_0022:\n\tv59 = *([v49 @ X21_v2 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]) & 0x200;\n\tv60 = v59 == 0;\n\tif (v60) goto L_0043;\n\tv62 = Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>;\n\tgoto L_002F;\n\tv84 = v62;\n\tv85 = System.Array::Resize(v84, methodInfo, v31);\nL_002F:\n\tv86 = *([v62 @ X21_v20 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+E0]) == 0;\n\tv72 = ~v86;\n\tif (v72) goto L_0043;\n\tgoto L_0043;\n\tv115 = v77;\n\tv116 = System.Array::Resize(v115, methodInfo, v31);\nL_0043:\n\tgoto L_0047;\n\tv87 = v79;\n\tv88 = System.Array::Resize(v87, methodInfo, v31);\nL_0047:\n\tv91 = v90.info;\n\tv93 = ~v91.isMarker;\n\tif (v93) goto L_0086;\n\tv98 = Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>;\n\tgoto L_0055;\n\tv119 = v98;\n\tv120 = System.Array::Resize(v119, methodInfo, v31);\n\tv123 = *([v98 @ X20_v4 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+12E]);\nL_0055:\n\tv124 = *([v98 @ X20_v4 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+12E]) & 0x200;\n\tv125 = v124 == 0;\n\tif (v125) goto L_0071;\n\tv169 = Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>;\n\tgoto L_0062;\n\tv223 = v169;\n\tv224 = System.Array::Resize(v223, methodInfo, v31);\nL_0062:\n\tv225 = *([v169 @ X20_v6 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+E0]) == 0;\n\tv179 = ~v225;\n\tif (v179) goto L_0071;\n\tgoto L_0071;\n\tv400 = v181;\n\tv401 = System.Array::Resize(v400, methodInfo, v31);\nL_0071:\n\tv186 = Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>;\n\tgoto L_FFFFFFFF;\n\tv226 = v186;\n\tv227 = System.Array::Resize(v226, methodInfo, v31);\n\tgoto L_0189;\nL_0086:\n\tv114 = this.componentsBagsTripleCount < 1;\n\tif (v114) goto L_00AA;\n\tv126 = this.componentsBags;\nL_008B:\n\tv204 = v194 - 2;\n\tv211 = v126[v204 @ X10_v9 (System.Int32)] == v91.id;\n\tif (v211) goto L_0137;\n\tv136 = v194 + 1;\n\tv133 = v194 + 3;\n\tv144 = v136 < this.componentsBagsTripleCount;\n\tif (v144) goto L_008B;\nL_00AA:\n\tv163 = Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>;\n\tgoto L_00B3;\n\tv216 = v163;\n\tv217 = System.Array::Resize(v216, methodInfo, v31);\n\tv220 = *([v163 @ X22_v4 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+12E]);\nL_00B3:\n\tv221 = *([v163 @ X22_v4 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+12E]) & 0x200;\n\tv222 = v221 == 0;\n\tif (v222) goto L_00D2;\n\tv239 = Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>;\n\tgoto L_00C0;\n\tv366 = v239;\n\tv367 = System.Array::Resize(v366, methodInfo, v31);\nL_00C0:\n\tv368 = *([v239 @ X22_v7 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+E0]) == 0;\n\tv251 = ~v368;\n\tif (v251) goto L_00D2;\n\tgoto L_00D2;\n\tv444 = v245;\n\tv445 = System.Array::Resize(v444, methodInfo, v31);\nL_00D2:\n\tv259 = Morpeh.Filter+ComponentsBag`1<T>::Create(this.world);\n\tv261 = this + 0x38;\n\tv378 = this.componentsBags;\n\tv376 = *([v261 @ X8_v20 (System.Int32[]&)+8]) + 3;\n\t*([v261 @ X8_v20 (System.Int32[]&)+8]) = v376;\n\tv277 = v376 < v378.Length;\n\tif (v277) goto L_00F0;\n\tv371 = v376 << 1;\n\tSystem.Array::Resize(v261, v371);\n\tv378 = this.componentsBags;\n\tv376 = this.componentsBagsTripleCount;\nL_00F0:\n\tv297 = v376 - 3;\n\tv378[v297 @ X10_v6 (System.Int32)] = v91.id;\n\tv385 = this.componentsBags;\n\tv386 = this.componentsBagsTripleCount - 2;\n\tv385[v386 @ X8_v23 (System.Int32)] = v259;\n\tv390 = this.componentsBags;\n\tv391 = this.componentsBagsTripleCount - 1;\n\tv390[v391 @ X8_v26 (System.Int32)] = 0;\n\tv395 = Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>;\n\tgoto L_010C;\n\tv432 = v395;\n\tv433 = System.Array::Resize(v432, v375, v374);\n\tv436 = *([v395 @ X21_v9 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+12E]);\nL_010C:\n\tv437 = *([v395 @ X21_v9 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+12E]) & 0x200;\n\tv438 = v437 == 0;\n\tif (v438) goto L_0128;\n\tv449 = Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>;\n\tgoto L_0119;\n\tv474 = v449;\n\tv475 = System.Array::Resize(v474, v375, v374);\nL_0119:\n\tv476 = *([v449 @ X21_v12 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+E0]) == 0;\n\tv458 = ~v476;\n\tif (v458) goto L_0128;\n\tgoto L_0128;\n\tv484 = v463;\n\tv485 = System.Array::Resize(v484, v375, v374);\nL_0128:\n\tv465 = this.componentsBagsTripleCount - 2;\n\tv286 = v465 << 2;\n\tv302 = this.componentsBags + v286;\n\tv466 = v302 + 0x20;\n\tv469 = Morpeh.Filter+ComponentsBag`1<T>::Get(v466);\n\tv290 = this + 0x10;\n\tv335 = Morpeh.Filter+ComponentsBag`1<T>::Update(v469, this.entitiesCacheForBags, v290);\n\tgoto L_0189;\nL_0137:\n\tv233 = Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>;\n\tgoto L_0140;\n\tv359 = v233;\n\tv360 = System.Array::Resize(v359, methodInfo, v31);\n\tv363 = *([v233 @ X21_v14 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+12E]);\nL_0140:\n\tv364 = *([v233 @ X21_v14 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+12E]) & 0x200;\n\tv365 = v364 == 0;\n\tif (v365) goto L_015C;\n\tv405 = Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>;\n\tgoto L_014D;\n\tv439 = v405;\n\tv440 = System.Array::Resize(v439, methodInfo, v31);\nL_014D:\n\tv441 = *([v405 @ X21_v17 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+E0]) == 0;\n\tv414 = ~v441;\n\tif (v414) goto L_015C;\n\tgoto L_015C;\n\tv477 = v419;\n\tv478 = System.Array::Resize(v477, methodInfo, v31);\nL_015C:\n\tv421 = v194 - 1;\n\tv422 = v421 << 2;\n\tv301 = v126 + v422;\n\tv423 = v301 + 0x20;\n\tv336 = Morpeh.Filter+ComponentsBag`1<T>::Get(v423);\n\tv425 = this.componentsBags;\n\tv305 = v425[v194 @ X22_v10 (System.Int32)] < 1;\n\tif (v305) goto L_0189;\n\tv289 = this + 0x10;\n\tv334 = Morpeh.Filter+ComponentsBag`1<T>::Update(v336, this.entitiesCacheForBags, v289);\n\tv473 = this.componentsBags;\n\tv473[v194 @ X22_v10 (System.Int32)] = 0;\nL_0189:\n\treturn v347;\n// 237 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe ref ComponentsBag<T> Select<T>() where T : struct, IComponent
		{
			//IL_029f: Expected O, but got I
			//IL_035c: Expected O, but got I
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ X21_v2 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X21_v20 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			CommonCacheTypeIdentifier.TypeInfo info = CacheTypeIdentifier<T>.info;
			ref ComponentsBag<T> result;
			if (info.isMarker)
			{
				IntPtr intPtr3 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ X20_v4 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr4 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v169 @ X20_v6 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				IntPtr intPtr5 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ X19_v5 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+B8]");
				result = ref *(ComponentsBag<T>*)null;
			}
			else
			{
				if (componentsBagsTripleCount < 1)
				{
					goto IL_0155;
				}
				int[] array = componentsBags;
				int num = 2;
				while (true)
				{
					int num2 = num - 2;
					if (array[num2] == info.id)
					{
						break;
					}
					int num3 = num + 1;
					int num4 = num + 3;
					bool flag = num3 < componentsBagsTripleCount;
					num = num4;
					if (flag)
					{
						continue;
					}
					goto IL_0155;
				}
				IntPtr intPtr6 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v233 @ X21_v14 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr7 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v405 @ X21_v17 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				int num5 = num - 1;
				int num6 = num5 << 2;
				object obj = (long)(IntPtr)array + (long)num6;
				ref ComponentsBag<T> reference = ref ComponentsBag<T>.Get(in *(int*)((long)(IntPtr)obj + 32L));
				int[] array2 = componentsBags;
				bool flag2 = array2[num] < 1;
				result = ref reference;
				if (!flag2)
				{
					reference.Update(entitiesCacheForBags, in *(int*)((long)(IntPtr)this + 16L));
					int[] array3 = componentsBags;
					array3[num] = 0;
					result = ref reference;
				}
			}
			goto IL_0436;
			IL_0436:
			return ref result;
			IL_0155:
			IntPtr intPtr8 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ X22_v4 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr9 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v239 @ X22_v7 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			int num7 = ComponentsBag<T>.Create(world);
			ref int[] reference2 = ref *(int[]*)((long)(IntPtr)this + 56L);
			int[] array4 = reference2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ X8_v20 (System.Int32[]&)+8]");
			int num8 = 3;
			if (num8 >= array4.Length)
			{
				int newSize = num8 << 1;
				Array.Resize(ref reference2, newSize);
				array4 = componentsBags;
				num8 = componentsBagsTripleCount;
			}
			int num9 = num8 - 3;
			array4[num9] = info.id;
			int[] array5 = componentsBags;
			int num10 = componentsBagsTripleCount - 2;
			array5[num10] = num7;
			int[] array6 = componentsBags;
			int num11 = componentsBagsTripleCount - 1;
			array6[num11] = 0;
			IntPtr intPtr10 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v395 @ X21_v9 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr11 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v449 @ X21_v12 (Il2CppClass<Morpeh.Filter+ComponentsBag`1<T>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			int num12 = componentsBagsTripleCount - 2;
			int num13 = num12 << 2;
			object obj2 = (long)(IntPtr)componentsBags + (long)num13;
			ref ComponentsBag<T> reference3 = ref ComponentsBag<T>.Get(in *(int*)((long)(IntPtr)obj2 + 32L));
			reference3.Update(entitiesCacheForBags, in *(int*)((long)(IntPtr)this + 16L));
			result = ref reference3;
			goto IL_0436;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x600004B")]
		[Address(RVA = "0x15F73C0", Offset = "0x15F73C0", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.world;\n\tv5 = v0.Entities;\n\treturn v5[v2[v3 @ X10_v1]];\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public IEntity GetEntity(in int id)
		{
			World world = this.world;
			Entity[] entities = world.Entities;
			int[] array = default(int[]);
			object obj = default(object);
			return entities[array[obj]];
		}

		[Token(Token = "0x600004C")]
		[Address(RVA = "0x14F61AC", Offset = "0x14F61AC", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = Il2CppMethodInfo;\n\tv6 = *([v5 @ X3_v1 (Il2CppMethodInfo)]);\n\t// 5 IndirectJump v6 @ X4_v1, this @ X0 (Morpeh.Filter), this @ X0 (Morpeh.Filter), 1, fillWithPreviousEntities @ X1 (System.Boolean), methodof(Morpeh.Filter::CreateFilter), v6 @ X4_v1, v8 @ X5, v9 @ X6, v10 @ X7, v11 @ V0, v12 @ V1, v13 @ V2, v14 @ V3, v15 @ V4, v16 @ V5, v17 @ V6, v18 @ V7\n\treturn X0;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Filter With<T>(bool fillWithPreviousEntities = true) where T : struct, IComponent
		{
			//IL_000e: Expected O, but got I
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v6 @ X4_v1 (should have been resolved before IL gen)");
			return null;
		}

		[Token(Token = "0x600004D")]
		[Address(RVA = "0x14F65CC", Offset = "0x14F65CC", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = Il2CppMethodInfo;\n\tv6 = *([v5 @ X3_v1 (Il2CppMethodInfo)]);\n\t// 5 IndirectJump v6 @ X4_v1, this @ X0 (Morpeh.Filter), this @ X0 (Morpeh.Filter), 2, fillWithPreviousEntities @ X1 (System.Boolean), methodof(Morpeh.Filter::CreateFilter), v6 @ X4_v1, v8 @ X5, v9 @ X6, v10 @ X7, v11 @ V0, v12 @ V1, v13 @ V2, v14 @ V3, v15 @ V4, v16 @ V5, v17 @ V6, v18 @ V7\n\treturn X0;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Filter Without<T>(bool fillWithPreviousEntities = true) where T : struct, IComponent
		{
			//IL_000e: Expected O, but got I
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v6 @ X4_v1 (should have been resolved before IL gen)");
			return null;
		}

		[Token(Token = "0x600004E")]
		[Address(RVA = "0x14EEEAC", Offset = "0x14EEEAC", Length = "0x280")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv40 = *([1ECD550]);\n\tv41 = *([v40 @ X8_v48]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, mode, fillWithPreviousEntities, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv57 = 0 | 1;\n\t*([2028E32]) = v57;\nL_001E:\n\tv147 = this.childs;\n\tv70 = v147._size < 1;\n\tif (v70) goto L_00CB;\n\tgoto L_0031;\nL_002F:\n\tv147 = this.childs;\n\tv145 = v147._size;\nL_0031:\n\tv149 = v142 < v145;\n\tv150 = ~v149;\n\tv158 = ~v150;\n\tif (v158) goto L_003E;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_003E:\n\tv168 = v147._items;\n\tv100 = v168[v142 @ X25_v6 (System.Int32)];\n\tv181 = v100.filterMode != mode;\n\tif (v181) goto L_00BB;\n\tv210 = Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>;\n\tgoto L_005D;\n\tv282 = v210;\n\tv283 = 0x8907BC(v282, mode, fillWithPreviousEntities, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv286 = *([v210 @ X24_v7 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]);\nL_005D:\n\tv287 = *([v210 @ X24_v7 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]) & 0x200;\n\tv288 = v287 == 0;\n\tif (v288) goto L_007E;\n\tv305 = Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>;\n\tgoto L_006A;\n\tv336 = v305;\n\tv337 = 0x8907BC(v336, mode, fillWithPreviousEntities, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\nL_006A:\n\tv338 = *([v305 @ X24_v11 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+E0]) == 0;\n\tv317 = ~v338;\n\tif (v317) goto L_007E;\n\tgoto L_007E;\n\tv409 = v311;\n\tv410 = 0x8907BC(v409, mode, fillWithPreviousEntities, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\nL_007E:\n\tgoto L_0084;\n\tv339 = v322;\n\tv340 = 0x8907BC(v339, mode, fillWithPreviousEntities, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\nL_0084:\n\tv345 = v343.info;\n\tgoto L_0099;\n\tv404 = *([v346 @ X0_v29+E0]);\n\tv405 = v404 == 0;\n\tv406 = ~v405;\n\tif (v406) goto L_0099;\n\tv407 = \"il2cpp_codegen_runtime_class_init\"(v346, mode, fillWithPreviousEntities, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\nL_0099:\n\tv218 = v100.mask.field3 != v345.mask;\n\tif (v218) goto L_00BB;\n\tv219 = v100.mask.field2 != v345.mask;\n\tif (v219) goto L_00BB;\n\tv217 = v100.mask != v345.mask;\n\tif (v217) goto L_00BB;\n\tv241 = v100.mask.field1 == v345.mask;\n\tif (v241) goto L_0123;\nL_00BB:\n\tv142 = v142 + 1;\n\tv82 = v142 < v147._size;\n\tif (v82) goto L_002F;\nL_00CB:\n\tv121 = Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>;\n\tgoto L_00D4;\n\tv159 = v121;\n\tv160 = 0x8907BC(v159, mode, fillWithPreviousEntities, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv163 = *([v121 @ X23_v4 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]);\nL_00D4:\n\tv164 = *([v121 @ X23_v4 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]) & 0x200;\n\tv165 = v164 == 0;\n\tif (v165) goto L_00F5;\n\tv183 = Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>;\n\tgoto L_00E1;\n\tv266 = v183;\n\tv267 = 0x8907BC(v266, mode, fillWithPreviousEntities, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\nL_00E1:\n\tv268 = *([v183 @ X23_v7 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+E0]) == 0;\n\tv195 = ~v268;\n\tif (v195) goto L_00F5;\n\tgoto L_00F5;\n\tv327 = v189;\n\tv328 = 0x8907BC(v327, mode, fillWithPreviousEntities, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\nL_00F5:\n\tgoto L_00F9;\n\tv269 = v200;\n\tv270 = 0x8907BC(v269, mode, fillWithPreviousEntities, methodInfo, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\nL_00F9:\n\tv273 = v272.info;\n\tv276 = v273.mask;\n\tv281 = new Morpeh.Filter();\n\tMorpeh.Filter::.ctor(v281, this.world, this.Entities, &v276 @ V0_v3 (Morpeh.Utils.FastBitMask), mode, fillWithPreviousEntities);\n\tSystem.Collections.Generic.List`1<Morpeh.Filter>::Add(this.childs, v281);\nL_0123:\n\treturn v378;\n// 205 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe Filter CreateFilter<T>(FilterMode mode, bool fillWithPreviousEntities) where T : struct, IComponent
		{
			//IL_025a: Expected O, but got Ref
			List<Filter> list = childs;
			if (list.Count < 1)
			{
				goto IL_01d7;
			}
			int num = 0;
			int count = list.Count;
			Filter result;
			while (true)
			{
				if (num >= count)
				{
					throw new ArgumentOutOfRangeException();
				}
				Filter[] items = list._items;
				Filter filter = items[num];
				if (filter.filterMode == mode)
				{
					IntPtr intPtr = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ X24_v7 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]");
					if (0u != 0)
					{
						IntPtr intPtr2 = (IntPtr)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v305 @ X24_v11 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+E0]");
						if ((IntPtr)0 != (IntPtr)0)
						{
						}
					}
					CommonCacheTypeIdentifier.TypeInfo info = CacheTypeIdentifier<T>.info;
					if (filter.mask.field3 == (ulong)(long)info.mask && filter.mask.field2 == (ulong)(long)info.mask && (object)filter.mask == (object)info.mask)
					{
						bool flag = filter.mask.field1 == (ulong)(long)info.mask;
						result = items[num];
						if (flag)
						{
							break;
						}
					}
				}
				num++;
				if (num < list.Count)
				{
					list = childs;
					count = list.Count;
					continue;
				}
				goto IL_01d7;
			}
			goto IL_0280;
			IL_0280:
			return result;
			IL_01d7:
			IntPtr intPtr3 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ X23_v4 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr4 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v183 @ X23_v7 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			CommonCacheTypeIdentifier.TypeInfo info2 = CacheTypeIdentifier<T>.info;
			FastBitMask fastBitMask = info2.mask;
			Filter filter2 = new Filter(world, Entities, (FastBitMask)(&fastBitMask), mode, fillWithPreviousEntities);
			childs.Add(filter2);
			result = filter2;
			goto IL_0280;
		}

		[Token(Token = "0x600004F")]
		[Address(RVA = "0x15F73E0", Offset = "0x15F73E0", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnBuffer.world = this.world;\n\treturnBuffer.current = 0;\n\treturnBuffer.ids = this.entitiesCacheForBags;\n\treturnBuffer.id = 0xFFFFFFFF;\n\treturnBuffer.length = this.Length;\n\treturn this;\n\tX8 = 0xFFFFFFFF;\n\t*([X0]) = X1;\n\t*([X0+8]) = 0;\n\t*([X0+10]) = X2;\n\t*([X0+18]) = X8;\n\t*([X0+1C]) = X3;\n\treturn X0;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe EntityEnumerator GetEnumerator()
		{
			//IL_000a: Expected native int or pointer, but got O
			//IL_0014: Expected native int or pointer, but got O
			//IL_0023: Expected native int or pointer, but got O
			//IL_0031: Expected native int or pointer, but got O
			//IL_0040: Expected native int or pointer, but got O
			EntityEnumerator entityEnumerator = default(EntityEnumerator);
			System.Runtime.CompilerServices.Unsafe.Write(&((EntityEnumerator*)(IntPtr)entityEnumerator)->world, world);
			System.Runtime.CompilerServices.Unsafe.Write(&((EntityEnumerator*)(IntPtr)entityEnumerator)->current, null);
			System.Runtime.CompilerServices.Unsafe.Write(&((EntityEnumerator*)(IntPtr)entityEnumerator)->ids, entitiesCacheForBags);
			((EntityEnumerator*)(IntPtr)entityEnumerator)->id = -1;
			((EntityEnumerator*)(IntPtr)entityEnumerator)->length = Length;
			return (EntityEnumerator)this;
		}

		[Token(Token = "0x6000050")]
		[Address(RVA = "0x15F7410", Offset = "0x15F7410", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1F00198]);\n\tv19 = *([v18 @ X8_v5]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A04C]) = v38;\nL_0014:\n\tv40 = this.world;\n\t// 32 Box returnVal1 @ X0_v3 (System.Collections.Generic.IEnumerator`1<Morpeh.IEntity>), typeof(Morpeh.Filter+EntityEnumerator), &v40 @ X8_v3 (Morpeh.World)\n\treturn returnVal1;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		IEnumerator<IEntity> IEnumerable<IEntity>.GetEnumerator()
		{
			World world = this.world;
			return (EntityEnumerator)world;
		}

		[Token(Token = "0x6000051")]
		[Address(RVA = "0x15F7484", Offset = "0x15F7484", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1F04DB8]);\n\tv19 = *([v18 @ X8_v5]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A04D]) = v38;\nL_0014:\n\tv40 = this.world;\n\t// 32 Box returnVal1 @ X0_v3 (System.Collections.IEnumerator), typeof(Morpeh.Filter+EntityEnumerator), &v40 @ X8_v3 (Morpeh.World)\n\treturn returnVal1;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		IEnumerator IEnumerable.GetEnumerator()
		{
			World world = this.world;
			return (EntityEnumerator)world;
		}
	}
}
