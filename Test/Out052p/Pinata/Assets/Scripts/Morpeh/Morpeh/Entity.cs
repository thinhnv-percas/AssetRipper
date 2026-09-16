using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Morpeh.Utils;
using Unity.IL2CPP.CompilerServices;

namespace Morpeh
{
	[Serializable]
	[AttributeAttribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73D02C", Offset = "0x73D02C")]
	[AttributeAttribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73D02C", Offset = "0x73D02C")]
	[AttributeAttribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73D02C", Offset = "0x73D02C")]
	[Token(Token = "0x200000D")]
	public sealed class Entity : IEntity, IDisposable
	{
		[Token(Token = "0x400000E")]
		[FieldOffset(Offset = "0x10")]
		internal int InternalID;

		[Token(Token = "0x400000F")]
		[FieldOffset(Offset = "0x18")]
		public FastBitMask ComponentsMask;

		[Token(Token = "0x4000010")]
		[FieldOffset(Offset = "0x38")]
		internal World World;

		[Token(Token = "0x4000011")]
		[FieldOffset(Offset = "0x40")]
		private int[] components;

		[Token(Token = "0x4000012")]
		[FieldOffset(Offset = "0x48")]
		private int componentsDoubleCount;

		[Token(Token = "0x17000006")]
		public int ID
		{
			[Token(Token = "0x6000016")]
			[Address(RVA = "0x15F5B50", Offset = "0x15F5B50", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.InternalID;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return ID;
			}
		}

		[Token(Token = "0x6000017")]
		[Address(RVA = "0x15F5B58", Offset = "0x15F5B58", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EA4FE0]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, id, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([202A040]) = v41;\nL_0017:\n\tSystem.Object::.ctor(this);\n\tthis.InternalID = id;\n\tthis.componentsDoubleCount = 0;\n\t// 30 NewArr v48 @ X0_v4 (System.Int32[]), typeof(System.Int32[]), 2\n\tthis.components = v48;\n\tgoto L_002D;\n\tv55 = *([v51 @ X0_v5 (Il2CppClass<Morpeh.Utils.FastBitMask>)+E0]);\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\tgoto L_002D;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v51, v46, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv59 = Morpeh.Utils.FastBitMask;\nL_002D:\n\tv62 = *([v58 @ X0_v6 (Il2CppClass<Morpeh.Utils.FastBitMask>)+B8]);\n\tthis.ComponentsMask = v62.None;\n\tthis.ComponentsMask.field2 = *([v62 @ X8_v7 (Il2CppStaticFields<Morpeh.Utils.FastBitMask>)+10]);\n\treturn;\n// 35 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal Entity(int id)
		{
			//IL_0046: Expected I, but got O
			//IL_0054: Expected I, but got O
			//IL_0076: Expected I8, but got I
			base._002Ector();
			InternalID = id;
			componentsDoubleCount = 0;
			int[] array = new int[2];
			components = array;
			IntPtr intPtr = (IntPtr)typeof(FastBitMask);
			IntPtr intPtr2 = (IntPtr)FastBitMask.None;
			ComponentsMask = FastBitMask.None;
			ref FastBitMask componentsMask = ref ComponentsMask;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X8_v7 (Il2CppStaticFields<Morpeh.Utils.FastBitMask>)+10]");
			componentsMask.field2 = 0uL;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x6000018")]
		[Address(RVA = "0xACE228", Offset = "0xACE228", Length = "0x3F8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv26 = *([1EBA038]);\n\tv27 = *([v26 @ X8_v73]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([20223CF]) = v45;\nL_0018:\n\tv47 = Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>;\n\tgoto L_0021;\n\tv52 = v47;\n\tv53 = System.Array::Resize(v52, methodInfo, v29);\n\tv56 = *([v47 @ X21_v2 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]);\nL_0021:\n\tv57 = *([v47 @ X21_v2 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]) & 0x200;\n\tv58 = v57 == 0;\n\tif (v58) goto L_0042;\n\tv60 = Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>;\n\tgoto L_002E;\n\tv82 = v60;\n\tv83 = System.Array::Resize(v82, methodInfo, v29);\nL_002E:\n\tv84 = *([v60 @ X21_v19 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+E0]) == 0;\n\tv70 = ~v84;\n\tif (v70) goto L_0042;\n\tgoto L_0042;\n\tv120 = v75;\n\tv121 = System.Array::Resize(v120, methodInfo, v29);\nL_0042:\n\tgoto L_004A;\n\tv85 = v77;\n\tv86 = System.Array::Resize(v85, methodInfo, v29);\n\tv89 = Il2CppMethodRgctx<Morpeh.Entity::AddComponent>;\nL_004A:\n\tv94 = v91.info;\n\tv95 = Morpeh.Entity::Has(this);\n\tv97 = v95 == 0;\n\tif (v97) goto L_005F;\n\tv102 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tv156 = *([v102 @ X20_v17 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]);\n\tv104 = *([v102 @ X20_v17 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]) & 1;\n\tv105 = v104 == 0;\n\tv106 = ~v105;\n\tif (v106) goto L_0090;\n\tv125 = Morpeh.Entity::Has(Il2CppClass<Morpeh.CacheComponents`1<T>>);\n\tv169 = *([v102 @ X20_v17 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]) & 0x200;\n\tv170 = v169 == 0;\n\tv171 = ~v170;\n\tif (v171) goto L_0094;\n\tgoto L_00B2;\nL_005F:\n\tv108 = v94.id >> 6;\n\tv109 = v108 < 3;\n\tv110 = ~v109;\n\tv111 = v108 - 3;\n\tv113 = v111 == 0;\n\tv118 = ~v113;\n\tv119 = v110 & v118;\n\tif (v119) goto L_007E;\n\tv163 = 0x1819000 + 0xB0;\n\tv165 = *([v163 @ X10_v8 (System.Int32)+v108 @ X9_v6 (System.Int32)*4]) + v163;\n\t// 112 IndirectJump v165 @ X9_v21, v95 @ X0_v6 (System.Boolean), v95 @ X0_v6 (System.Boolean), methodof(Morpeh.Entity::Has), v172 @ X2_v2 (Il2CppMethodInfo), v30 @ X3, v31 @ X4, v32 @ X5, v33 @ X6, v34 @ X7, v35 @ V0, v36 @ V1, v37 @ V2, v38 @ V3, v39 @ V4, v40 @ V5, v41 @ V6, v42 @ V7\n\tX9 = X20 + 0x18;\n\tgoto L_0078;\n\tX9 = X20 + 0x20;\n\tgoto L_0078;\n\tX9 = X20 + 0x28;\n\tgoto L_0078;\n\tX9 = X20 + 0x30;\nL_0078:\n\tX10 = *([X9]);\n\tX8 = X8 & 0x3F;\n\tX11 = 0 | 1;\n\tX8 = X11 << X8;\n\tX8 = X10 | X8;\n\t*([X9]) = X8;\nL_007E:\n\tv166 = this.World;\n\tMorpeh.Filter::EntityChanged(v166.Filter, this.InternalID);\n\tv159 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tv156 = *([v159 @ X21_v9 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]);\n\tgoto L_008E;\n\tv298 = v159;\n\tv299 = System.Array::Resize(v298, v129, v127);\n\tv300 = *([v159 @ X21_v9 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]);\nL_008E:\n\tv154 = ~v94.isMarker;\n\tif (v154) goto L_00B7;\nL_0090:\n\tv160 = v156 & 0x200;\n\tv161 = v160 == 0;\n\tif (v161) goto L_00B2;\nL_0094:\n\tv191 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_009D;\n\tv295 = v191;\n\tv296 = System.Array::Resize(v295, v173, v172);\nL_009D:\n\tv297 = *([v191 @ X20_v5 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]) == 0;\n\tv214 = ~v297;\n\tif (v214) goto L_00B2;\n\tgoto L_00B2;\n\tv306 = v216;\n\tv307 = System.Array::Resize(v306, v173, v172);\nL_00B2:\n\tv228 = Il2CppMethodInfo;\n\tv229 = *([v228 @ X0_v8 (Il2CppMethodInfo)]);\n\t// 182 IndirectJump v229 @ X1_v3, methodof(Morpeh.CacheComponents`1<T>::Empty), methodof(Morpeh.CacheComponents`1<T>::Empty), v229 @ X1_v3, v196 @ X2_v1 (Il2CppMethodInfo), v30 @ X3, v31 @ X4, v32 @ X5, v33 @ X6, v34 @ X7, v35 @ V0, v36 @ V1, v37 @ V2, v38 @ V3, v39 @ V4, v40 @ V5, v41 @ V6, v42 @ V7\nL_00B7:\n\tv304 = *([v159 @ X21_v9 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]) & 0x200;\n\tv305 = v304 == 0;\n\tif (v305) goto L_00D5;\n\tv311 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_00C4;\n\tv347 = v311;\n\tv348 = System.Array::Resize(v347, v129, v127);\nL_00C4:\n\tv349 = *([v311 @ X21_v16 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]) == 0;\n\tv321 = ~v349;\n\tif (v321) goto L_00D5;\n\tgoto L_00D5;\n\tv449 = v326;\n\tv450 = System.Array::Resize(v449, v129, v127);\nL_00D5:\n\tv330 = Morpeh.CacheComponents`1<T>::Add();\n\tv332 = this + 0x40;\n\tv429 = this.components;\n\tv346 = *([v332 @ X8_v28 (System.Int32[]&)+8]) < 1;\n\tif (v346) goto L_0106;\nL_00E9:\n\tv408 = v398 - 1;\n\tv415 = v429[v408 @ X12_v4 (System.Int32)] == v94.id;\n\tif (v415) goto L_0157;\n\tv357 = v398 + 1;\n\tv355 = v398 + 2;\n\tv362 = v357 < *([v332 @ X8_v28 (System.Int32[]&)+8]);\n\tif (v362) goto L_00E9;\nL_0106:\n\tv427 = *([v332 @ X8_v28 (System.Int32[]&)+8]) + 2;\n\tthis.componentsDoubleCount = v427;\n\tv391 = v427 < v429.Length;\n\tif (v391) goto L_011E;\n\tv422 = v427 << 1;\n\tSystem.Array::Resize(v332, v422);\n\tv429 = this.components;\n\tv427 = this.componentsDoubleCount;\nL_011E:\n\tv433 = v427 - 2;\n\tv429[v433 @ X10_v5 (System.Int32)] = v94.id;\n\tv437 = this.components;\n\tv438 = this.componentsDoubleCount - 1;\n\tv437[v438 @ X8_v32 (System.Int32)] = v330;\n\tv444 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_0134;\n\tv464 = v444;\n\tv465 = System.Array::Resize(v464, v426, v425);\n\tv468 = *([v444 @ X21_v14 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]);\nL_0134:\n\tv469 = *([v444 @ X21_v14 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]) & 0x200;\n\tv470 = v469 == 0;\n\tif (v470) goto L_0151;\n\tv480 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_0141;\n\tv522 = v480;\n\tv523 = System.Array::Resize(v522, v426, v425);\nL_0141:\n\tv524 = *([v480 @ X20_v11 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]) == 0;\n\tv490 = ~v524;\n\tif (v490) goto L_0151;\n\tgoto L_0151;\n\tv540 = v492;\n\tv541 = System.Array::Resize(v540, v426, v425);\nL_0151:\n\tv498 = this.componentsDoubleCount - 1;\n\tv499 = v498 << 2;\n\tv285 = this.components + v499;\n\tgoto L_0183;\nL_0157:\n\tv429[v398 @ X23_v11 (System.Int32)] = v330;\n\tv459 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_0164;\n\tv471 = v459;\n\tv472 = System.Array::Resize(v471, v129, v127);\n\tv474 = *([v459 @ X20_v13 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]);\nL_0164:\n\tv477 = *([v459 @ X20_v13 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]) & 0x200;\n\tv478 = v477 == 0;\n\tif (v478) goto L_0181;\n\tv502 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_0171;\n\tv531 = v502;\n\tv532 = System.Array::Resize(v531, v129, v127);\nL_0171:\n\tv533 = *([v502 @ X20_v15 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]) == 0;\n\tv512 = ~v533;\n\tif (v512) goto L_0181;\n\tgoto L_0181;\n\tv544 = v514;\n\tv545 = System.Array::Resize(v544, v129, v127);\nL_0181:\n\tv520 = v398 << 2;\n\tv285 = *([v332 @ X8_v28 (System.Int32[]&)]) + v520;\nL_0183:\n\tv235 = *([v246 @ X1_v7 (Il2CppMethodInfo)]);\n\tv277 = v285 + 0x20;\n\t// 397 IndirectJump v235 @ X2_v6, v277 @ X0_v25, v277 @ X0_v25, v246 @ X1_v7 (Il2CppMethodInfo), v235 @ X2_v6, v30 @ X3, v31 @ X4, v32 @ X5, v33 @ X6, v34 @ X7, v35 @ V0, v36 @ V1, v37 @ V2, v38 @ V3, v39 @ V4, v40 @ V5, v41 @ V6, v42 @ V7\n\treturn X0;\n// 220 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe ref T AddComponent<T>() where T : struct, IComponent
		{
			//IL_04f7: Expected O, but got I
			//IL_0060: Expected O, but got I
			//IL_0511: Expected I, but got O
			//IL_0180: Expected O, but got I
			//IL_0204: Expected O, but got I
			//IL_00a5: Expected O, but got I
			//IL_03fa: Expected O, but got I
			//IL_05b9: Expected O, but got I
			//IL_05c8: Expected O, but got I
			//IL_0478: Unknown result type (might be due to invalid IL or missing references)
			//IL_047d: Expected O, but got Unknown
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X21_v2 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ X21_v19 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			CommonCacheTypeIdentifier.TypeInfo info = CacheTypeIdentifier<T>.info;
			object obj = default(object);
			if (Has<T>())
			{
				IntPtr intPtr3 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ X20_v17 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]");
				obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ X20_v17 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]");
				if (0 == 0)
				{
					bool flag = ((Entity)0).Has<T>();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ X20_v17 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]");
					if (0u != 0)
					{
						goto IL_01b6;
					}
					goto IL_01f6;
				}
			}
			else
			{
				int num = info.id >> 6;
				bool flag2 = num < 3;
				bool flag3 = !flag2;
				int num2 = num - 3;
				bool flag4 = num2 == 0;
				bool flag5 = !flag4;
				if (!(flag3 && flag5))
				{
					int num3 = 25268224 + 176;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v163 @ X10_v8 (System.Int32)+v108 @ X9_v6 (System.Int32)*4]");
					object obj2 = 0L + (long)num3;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v165 @ X9_v21 (should have been resolved before IL gen)");
				}
				else
				{
					World world = World;
					world.Filter.EntityChanged(ID);
					IntPtr intPtr4 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ X21_v9 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]");
					obj = 0;
					bool flag6 = !info.isMarker;
					IntPtr intPtr5 = (IntPtr)null;
					if (flag6)
					{
						goto IL_020e;
					}
				}
			}
			if ((uint)((ulong)(long)(IntPtr)obj & 0x200uL) != 0)
			{
				goto IL_01b6;
			}
			goto IL_01f6;
			IL_05b1:
			IntPtr intPtr6;
			object obj3 = (long)intPtr6;
			object obj5;
			object obj4 = (long)(IntPtr)obj5 + 32L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v235 @ X2_v6 (should have been resolved before IL gen)");
			goto IL_05d2;
			IL_01b6:
			IntPtr intPtr7 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v191 @ X20_v5 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
			goto IL_01f6;
			IL_020e:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ X21_v9 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr8 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v311 @ X21_v16 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			int num4 = CacheComponents<T>.Add();
			ref int[] reference = ref *(int[]*)((long)(IntPtr)this + 64L);
			int[] array = reference;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ X8_v28 (System.Int32[]&)+8]");
			if (0L < 1L)
			{
				goto IL_031a;
			}
			int num5 = 1;
			while (true)
			{
				int num6 = num5 - 1;
				if (array[num6] == info.id)
				{
					break;
				}
				int num7 = num5 + 1;
				int num8 = num5 + 2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ X8_v28 (System.Int32[]&)+8]");
				bool flag7 = (long)num7 < 0L;
				num5 = num8;
				if (flag7)
				{
					continue;
				}
				goto IL_031a;
			}
			array[num5] = num4;
			IntPtr intPtr9 = (IntPtr)0;
			goto IL_05d2;
			IL_05d2:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v459 @ X20_v13 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr10 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v502 @ X20_v15 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			int num9 = num5 << 2;
			obj5 = reference + num9;
			intPtr6 = (IntPtr)0;
			goto IL_05b1;
			IL_031a:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v332 @ X8_v28 (System.Int32[]&)+8]");
			int num10 = (componentsDoubleCount = 2);
			if (num10 >= array.Length)
			{
				int newSize = num10 << 1;
				Array.Resize(ref reference, newSize);
				array = components;
				num10 = componentsDoubleCount;
			}
			int num11 = num10 - 2;
			array[num11] = info.id;
			int[] array2 = components;
			int num12 = componentsDoubleCount - 1;
			array2[num12] = num4;
			IntPtr intPtr11 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v444 @ X21_v14 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr12 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v480 @ X20_v11 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			int num13 = componentsDoubleCount - 1;
			int num14 = num13 << 2;
			obj5 = (long)(IntPtr)components + (long)num14;
			intPtr6 = (IntPtr)0;
			goto IL_05b1;
			IL_01f6:
			IntPtr intPtr13 = (IntPtr)0;
			object obj6 = (long)intPtr13;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v229 @ X1_v3 (should have been resolved before IL gen)");
			goto IL_020e;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x6000019")]
		[Address(RVA = "0xACEE10", Offset = "0xACEE10", Length = "0x408")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv28 = *([1EC43B0]);\n\tv29 = *([v28 @ X8_v74]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, exist, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([20223D2]) = v46;\nL_0019:\n\tv48 = Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>;\n\tgoto L_0022;\n\tv53 = v48;\n\tv54 = 0x8907BC(v53, exist, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv57 = *([v48 @ X22_v2 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]);\nL_0022:\n\tv58 = *([v48 @ X22_v2 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]) & 0x200;\n\tv59 = v58 == 0;\n\tif (v59) goto L_0043;\n\tv61 = Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>;\n\tgoto L_002F;\n\tv83 = v61;\n\tv84 = 0x8907BC(v83, exist, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_002F:\n\tv85 = *([v61 @ X22_v12 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+E0]) == 0;\n\tv71 = ~v85;\n\tif (v71) goto L_0043;\n\tgoto L_0043;\n\tv122 = v76;\n\tv123 = 0x8907BC(v122, exist, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0043:\n\tgoto L_004B;\n\tv86 = v78;\n\tv87 = 0x8907BC(v86, exist, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv90 = Il2CppMethodRgctx<Morpeh.Entity::AddComponent>;\nL_004B:\n\tv95 = v92.info;\n\tv96 = Morpeh.Entity::Has(this);\n\tv98 = v96 == 0;\n\tif (v98) goto L_0061;\n\t*([exist @ X1 (System.Boolean&)]) = 1;\n\tv104 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tv160 = *([v104 @ X20_v17 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]);\n\tv106 = *([v104 @ X20_v17 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]) & 1;\n\tv107 = v106 == 0;\n\tv108 = ~v107;\n\tif (v108) goto L_0094;\n\tv127 = 0x8907BC(Il2CppClass<Morpeh.CacheComponents`1<T>>, Il2CppMethodInfo, v174, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv171 = *([v104 @ X20_v17 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]) & 0x200;\n\tv172 = v171 == 0;\n\tv173 = ~v172;\n\tif (v173) goto L_0098;\n\tgoto L_00B6;\nL_0061:\n\t*([exist @ X1 (System.Boolean&)]) = 0;\n\tv110 = v95.id >> 6;\n\tv111 = v110 < 3;\n\tv112 = ~v111;\n\tv113 = v110 - 3;\n\tv115 = v113 == 0;\n\tv120 = ~v115;\n\tv121 = v112 & v120;\n\tif (v121) goto L_0082;\n\tv165 = 0x1819000 + 0xE0;\n\tv167 = *([v165 @ X10_v8 (System.Int32)+v110 @ X9_v6 (System.Int32)*4]) + v165;\n\t// 116 IndirectJump v167 @ X9_v21, v96 @ X0_v6 (System.Boolean), v96 @ X0_v6 (System.Boolean), methodof(Morpeh.Entity::Has), v174 @ X2_v2 (Il2CppMethodInfo), v31 @ X3, v32 @ X4, v33 @ X5, v34 @ X6, v35 @ X7, v36 @ V0, v37 @ V1, v38 @ V2, v39 @ V3, v40 @ V4, v41 @ V5, v42 @ V6, v43 @ V7\n\tX9 = X20 + 0x18;\n\tgoto L_007C;\n\tX9 = X20 + 0x20;\n\tgoto L_007C;\n\tX9 = X20 + 0x28;\n\tgoto L_007C;\n\tX9 = X20 + 0x30;\nL_007C:\n\tX10 = *([X9]);\n\tX8 = X8 & 0x3F;\n\tX11 = 0 | 1;\n\tX8 = X11 << X8;\n\tX8 = X10 | X8;\n\t*([X9]) = X8;\nL_0082:\n\tv168 = this.World;\n\tMorpeh.Filter::EntityChanged(v168.Filter, this.InternalID);\n\tv159 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tv160 = *([v159 @ X21_v6 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]);\n\tgoto L_0092;\n\tv300 = v159;\n\tv301 = 0x8907BC(v300, v131, v129, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv302 = *([v159 @ X21_v6 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]);\nL_0092:\n\tv156 = ~v95.isMarker;\n\tif (v156) goto L_00BB;\nL_0094:\n\tv162 = v160 & 0x200;\n\tv163 = v162 == 0;\n\tif (v163) goto L_00B6;\nL_0098:\n\tv193 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_00A1;\n\tv297 = v193;\n\tv298 = 0x8907BC(v297, v175, v174, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_00A1:\n\tv299 = *([v193 @ X20_v5 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]) == 0;\n\tv216 = ~v299;\n\tif (v216) goto L_00B6;\n\tgoto L_00B6;\n\tv308 = v218;\n\tv309 = 0x8907BC(v308, v175, v174, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_00B6:\n\tv230 = Il2CppMethodInfo;\n\tv231 = *([v230 @ X0_v8 (Il2CppMethodInfo)]);\n\t// 186 IndirectJump v231 @ X1_v3, methodof(Morpeh.CacheComponents`1<T>::Empty), methodof(Morpeh.CacheComponents`1<T>::Empty), v231 @ X1_v3, v198 @ X2_v1 (Il2CppMethodInfo), v31 @ X3, v32 @ X4, v33 @ X5, v34 @ X6, v35 @ X7, v36 @ V0, v37 @ V1, v38 @ V2, v39 @ V3, v40 @ V4, v41 @ V5, v42 @ V6, v43 @ V7\nL_00BB:\n\tv306 = *([v159 @ X21_v6 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]) & 0x200;\n\tv307 = v306 == 0;\n\tif (v307) goto L_00D9;\n\tv313 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_00C8;\n\tv349 = v313;\n\tv350 = 0x8907BC(v349, v131, v129, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_00C8:\n\tv351 = *([v313 @ X21_v13 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]) == 0;\n\tv323 = ~v351;\n\tif (v323) goto L_00D9;\n\tgoto L_00D9;\n\tv451 = v325;\n\tv452 = 0x8907BC(v451, v131, v129, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_00D9:\n\tv332 = Morpeh.CacheComponents`1<T>::Add();\n\tv334 = this + 0x40;\n\tv431 = this.components;\n\tv348 = *([v334 @ X8_v28 (System.Int32[]&)+8]) < 1;\n\tif (v348) goto L_010A;\nL_00ED:\n\tv410 = v400 - 1;\n\tv417 = v431[v410 @ X12_v4 (System.Int32)] == v95.id;\n\tif (v417) goto L_015B;\n\tv359 = v400 + 1;\n\tv357 = v400 + 2;\n\tv364 = v359 < *([v334 @ X8_v28 (System.Int32[]&)+8]);\n\tif (v364) goto L_00ED;\nL_010A:\n\tv429 = *([v334 @ X8_v28 (System.Int32[]&)+8]) + 2;\n\tthis.componentsDoubleCount = v429;\n\tv393 = v429 < v431.Length;\n\tif (v393) goto L_0122;\n\tv424 = v429 << 1;\n\tSystem.Array::Resize(v334, v424);\n\tv431 = this.components;\n\tv429 = this.componentsDoubleCount;\nL_0122:\n\tv435 = v429 - 2;\n\tv431[v435 @ X10_v5 (System.Int32)] = v95.id;\n\tv439 = this.components;\n\tv440 = this.componentsDoubleCount - 1;\n\tv439[v440 @ X8_v32 (System.Int32)] = v332;\n\tv446 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_0138;\n\tv466 = v446;\n\tv467 = System.Array::Resize(v466, v428, v427);\n\tv470 = *([v446 @ X21_v11 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]);\nL_0138:\n\tv471 = *([v446 @ X21_v11 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]) & 0x200;\n\tv472 = v471 == 0;\n\tif (v472) goto L_0155;\n\tv482 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_0145;\n\tv524 = v482;\n\tv525 = System.Array::Resize(v524, v428, v427);\nL_0145:\n\tv526 = *([v482 @ X20_v11 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]) == 0;\n\tv492 = ~v526;\n\tif (v492) goto L_0155;\n\tgoto L_0155;\n\tv542 = v494;\n\tv543 = System.Array::Resize(v542, v428, v427);\nL_0155:\n\tv500 = this.componentsDoubleCount - 1;\n\tv501 = v500 << 2;\n\tv287 = this.components + v501;\n\tgoto L_0187;\nL_015B:\n\tv431[v400 @ X23_v11 (System.Int32)] = v332;\n\tv461 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_0168;\n\tv473 = v461;\n\tv474 = 0x8907BC(v473, v131, v129, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv476 = *([v461 @ X20_v13 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]);\nL_0168:\n\tv479 = *([v461 @ X20_v13 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]) & 0x200;\n\tv480 = v479 == 0;\n\tif (v480) goto L_0185;\n\tv504 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_0175;\n\tv533 = v504;\n\tv534 = 0x8907BC(v533, v131, v129, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0175:\n\tv535 = *([v504 @ X20_v15 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]) == 0;\n\tv514 = ~v535;\n\tif (v514) goto L_0185;\n\tgoto L_0185;\n\tv546 = v516;\n\tv547 = 0x8907BC(v546, v131, v129, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_0185:\n\tv522 = v400 << 2;\n\tv287 = *([v334 @ X8_v28 (System.Int32[]&)]) + v522;\nL_0187:\n\tv237 = *([v248 @ X1_v7 (Il2CppMethodInfo)]);\n\tv277 = v287 + 0x20;\n\t// 401 IndirectJump v237 @ X2_v6, v277 @ X0_v25, v277 @ X0_v25, v248 @ X1_v7 (Il2CppMethodInfo), v237 @ X2_v6, v31 @ X3, v32 @ X4, v33 @ X5, v34 @ X6, v35 @ X7, v36 @ V0, v37 @ V1, v38 @ V2, v39 @ V3, v40 @ V4, v41 @ V5, v42 @ V6, v43 @ V7\n\treturn X0;\n// 222 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe ref T AddComponent<T>(out bool exist) where T : struct, IComponent
		{
			//IL_0512: Expected O, but got I
			//IL_0073: Expected O, but got I
			//IL_052c: Expected I, but got O
			//IL_019b: Expected O, but got I
			//IL_021f: Expected O, but got I
			//IL_0415: Expected O, but got I
			//IL_05d4: Expected O, but got I
			//IL_05e3: Expected O, but got I
			//IL_0493: Unknown result type (might be due to invalid IL or missing references)
			//IL_0498: Expected O, but got Unknown
			exist = default(bool);
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X22_v2 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ X22_v12 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			CommonCacheTypeIdentifier.TypeInfo info = CacheTypeIdentifier<T>.info;
			object obj = default(object);
			if (Has<T>())
			{
				ref bool reference = ref *(bool*)1;
				IntPtr intPtr3 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ X20_v17 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]");
				obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ X20_v17 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]");
				if (0 == 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8907BC");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ X20_v17 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]");
					if (0u != 0)
					{
						goto IL_01d1;
					}
					goto IL_0211;
				}
			}
			else
			{
				ref bool reference = ref *(bool*)null;
				int num = info.id >> 6;
				bool flag = num < 3;
				bool flag2 = !flag;
				int num2 = num - 3;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				if (!(flag2 && flag4))
				{
					int num3 = 25268224 + 224;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ X10_v8 (System.Int32)+v110 @ X9_v6 (System.Int32)*4]");
					object obj2 = 0L + (long)num3;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v167 @ X9_v21 (should have been resolved before IL gen)");
				}
				else
				{
					World world = World;
					world.Filter.EntityChanged(ID);
					IntPtr intPtr4 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ X21_v6 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]");
					obj = 0;
					bool flag5 = !info.isMarker;
					IntPtr intPtr5 = (IntPtr)null;
					if (flag5)
					{
						goto IL_0229;
					}
				}
			}
			if ((uint)((ulong)(long)(IntPtr)obj & 0x200uL) != 0)
			{
				goto IL_01d1;
			}
			goto IL_0211;
			IL_05cc:
			IntPtr intPtr6;
			object obj3 = (long)intPtr6;
			object obj5;
			object obj4 = (long)(IntPtr)obj5 + 32L;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v237 @ X2_v6 (should have been resolved before IL gen)");
			goto IL_05ed;
			IL_01d1:
			IntPtr intPtr7 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ X20_v5 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]");
			if ((IntPtr)0 != (IntPtr)0)
			{
			}
			goto IL_0211;
			IL_0229:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ X21_v6 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr8 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ X21_v13 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			int num4 = CacheComponents<T>.Add();
			ref int[] reference2 = ref *(int[]*)((long)(IntPtr)this + 64L);
			int[] array = reference2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ X8_v28 (System.Int32[]&)+8]");
			if (0L < 1L)
			{
				goto IL_0335;
			}
			int num5 = 1;
			while (true)
			{
				int num6 = num5 - 1;
				if (array[num6] == info.id)
				{
					break;
				}
				int num7 = num5 + 1;
				int num8 = num5 + 2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ X8_v28 (System.Int32[]&)+8]");
				bool flag6 = (long)num7 < 0L;
				num5 = num8;
				if (flag6)
				{
					continue;
				}
				goto IL_0335;
			}
			array[num5] = num4;
			IntPtr intPtr9 = (IntPtr)0;
			goto IL_05ed;
			IL_05ed:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v461 @ X20_v13 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr10 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v504 @ X20_v15 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			int num9 = num5 << 2;
			obj5 = reference2 + num9;
			intPtr6 = (IntPtr)0;
			goto IL_05cc;
			IL_0335:
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v334 @ X8_v28 (System.Int32[]&)+8]");
			int num10 = (componentsDoubleCount = 2);
			if (num10 >= array.Length)
			{
				int newSize = num10 << 1;
				Array.Resize(ref reference2, newSize);
				array = components;
				num10 = componentsDoubleCount;
			}
			int num11 = num10 - 2;
			array[num11] = info.id;
			int[] array2 = components;
			int num12 = componentsDoubleCount - 1;
			array2[num12] = num4;
			IntPtr intPtr11 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v446 @ X21_v11 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr12 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v482 @ X20_v11 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			int num13 = componentsDoubleCount - 1;
			int num14 = num13 << 2;
			obj5 = (long)(IntPtr)components + (long)num14;
			intPtr6 = (IntPtr)0;
			goto IL_05cc;
			IL_0211:
			IntPtr intPtr13 = (IntPtr)0;
			object obj6 = (long)intPtr13;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v231 @ X1_v3 (should have been resolved before IL gen)");
			goto IL_0229;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x600001A")]
		[Address(RVA = "0xF14A0C", Offset = "0xF14A0C", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>;\n\tgoto L_0013;\n\tv22 = v17;\n\tv23 = 0x8907BC(v22, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = *([v17 @ X21_v1 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]);\nL_0013:\n\tv41 = *([v17 @ X21_v1 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]) & 0x200;\n\tv42 = v41 == 0;\n\tif (v42) goto L_0034;\n\tv44 = Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>;\n\tgoto L_0020;\n\tv66 = v44;\n\tv67 = 0x8907BC(v66, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0020:\n\tv68 = *([v44 @ X21_v4 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+E0]) == 0;\n\tv54 = ~v68;\n\tif (v54) goto L_0034;\n\tgoto L_0034;\n\tv134 = v56;\n\tv135 = 0x8907BC(v134, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0034:\n\tgoto L_0038;\n\tv69 = v61;\n\tv70 = 0x8907BC(v69, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0038:\n\tv73 = v72.info;\n\tv75 = ~v73.isMarker;\n\tif (v75) goto L_0044;\nL_0043:\n\treturn returnVal1;\nL_0044:\n\tv130 = this.components;\n\tv90 = v130.Length < 1;\n\tif (v90) goto L_FFFFFFFF;\nL_0054:\n\tv184 = v143 - 1;\n\tv155 = v130[v184 @ X12_v3 (System.Int32)] == v73.id;\n\tif (v155) goto L_FFFFFFFF;\n\tv84 = v143 + 1;\n\tv143 = v143 + 2;\n\tv91 = v84 < v130.Length;\n\tif (v91) goto L_0054;\n\tgoto L_FFFFFFFF;\n\tgoto L_0043;\n\treturn X0;\n// 80 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal int GetComponentId<T>() where T : struct, IComponent
		{
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ X21_v1 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X21_v4 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			CommonCacheTypeIdentifier.TypeInfo info = CacheTypeIdentifier<T>.info;
			if (!info.isMarker)
			{
				int[] array = components;
				if (array.Length >= 1)
				{
					int num = 1;
					int num3;
					do
					{
						int num2 = num - 1;
						if (array[num2] != info.id)
						{
							num3 = num + 1;
							num += 2;
							continue;
						}
						return array[num];
					}
					while (num3 < array.Length);
				}
			}
			return -1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x600001B")]
		[Address(RVA = "0xAD11D8", Offset = "0xAD11D8", Length = "0x1F4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv19 = Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>;\n\tgoto L_0014;\n\tv24 = v19;\n\tv25 = 0x8907BC(v24, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = *([v19 @ X21_v1 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]);\nL_0014:\n\tv43 = *([v19 @ X21_v1 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]) & 0x200;\n\tv44 = v43 == 0;\n\tif (v44) goto L_0035;\n\tv46 = Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>;\n\tgoto L_0021;\n\tv68 = v46;\n\tv69 = 0x8907BC(v68, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0021:\n\tv70 = *([v46 @ X21_v9 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+E0]) == 0;\n\tv56 = ~v70;\n\tif (v56) goto L_0035;\n\tgoto L_0035;\n\tv106 = v58;\n\tv107 = 0x8907BC(v106, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0035:\n\tgoto L_0039;\n\tv71 = v63;\n\tv72 = 0x8907BC(v71, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0039:\n\tv75 = v74.info;\n\tv77 = ~v75.isMarker;\n\tif (v77) goto L_0046;\n\tv85 = Morpeh.Entity::Has(this);\n\tv87 = v85 == 0;\n\tv88 = ~v87;\n\tif (v88) goto L_0073;\nL_0046:\n\tv93 = this.components;\n\tv105 = v93.Length < 1;\n\tif (v105) goto L_0073;\nL_0056:\n\tv179 = v178 - 1;\n\tv186 = v93[v179 @ X10_v3 (System.Int32)] == v75.id;\n\tif (v186) goto L_00A3;\n\tv114 = v178 + 1;\n\tv178 = v178 + 2;\n\tv120 = v114 < v93.Length;\n\tif (v120) goto L_0056;\nL_0073:\n\tv154 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_007C;\n\tv160 = v154;\n\tv161 = 0x8907BC(v160, v146, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv164 = *([v154 @ X20_v2 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]);\nL_007C:\n\tv165 = *([v154 @ X20_v2 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]) & 0x200;\n\tv166 = v165 == 0;\n\tif (v166) goto L_009C;\n\tv192 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_0089;\n\tv225 = v192;\n\tv226 = 0x8907BC(v225, v146, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0089:\n\tv227 = *([v192 @ X20_v5 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]) == 0;\n\tv202 = ~v227;\n\tif (v202) goto L_009C;\n\tgoto L_009C;\n\tv290 = v204;\n\tv291 = 0x8907BC(v290, v146, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_009C:\n\tv213 = Il2CppMethodInfo;\n\tv214 = *([v213 @ X0_v7 (Il2CppMethodInfo)]);\n\t// 161 IndirectJump v214 @ X1_v2, methodof(Morpeh.CacheComponents`1<T>::Empty), methodof(Morpeh.CacheComponents`1<T>::Empty), v214 @ X1_v2, v26 @ X2, v27 @ X3, v28 @ X4, v29 @ X5, v30 @ X6, v31 @ X7, v32 @ V0, v33 @ V1, v34 @ V2, v35 @ V3, v36 @ V4, v37 @ V5, v38 @ V6, v39 @ V7\nL_00A3:\n\tv220 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_00AC;\n\tv263 = v220;\n\tv264 = 0x8907BC(v263, v89, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv267 = *([v220 @ X20_v7 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]);\nL_00AC:\n\tv268 = *([v220 @ X20_v7 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]) & 0x200;\n\tv269 = v268 == 0;\n\tif (v269) goto L_00CC;\n\tv274 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_00B9;\n\tv294 = v274;\n\tv295 = 0x8907BC(v294, v89, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00B9:\n\tv296 = *([v274 @ X20_v10 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]) == 0;\n\tv283 = ~v296;\n\tif (v283) goto L_00CC;\n\tgoto L_00CC;\n\tv300 = v285;\n\tv301 = 0x8907BC(v300, v89, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_00CC:\n\tv246 = Il2CppMethodInfo;\n\tv231 = v178 << 2;\n\tv258 = v93 + v231;\n\tv250 = v258 + 0x20;\n\tv229 = *([v246 @ X1_v4 (Il2CppMethodInfo)]);\n\t// 212 IndirectJump v229 @ X2_v1, v250 @ X0_v21, v250 @ X0_v21, methodof(Morpeh.CacheComponents`1<T>::Get), v229 @ X2_v1, v27 @ X3, v28 @ X4, v29 @ X5, v30 @ X6, v31 @ X7, v32 @ V0, v33 @ V1, v34 @ V2, v35 @ V3, v36 @ V4, v37 @ V5, v38 @ V6, v39 @ V7\n\treturn X0;\n// 130 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ref T GetComponent<T>() where T : struct, IComponent
		{
			//IL_0173: Expected O, but got I
			//IL_01ea: Expected O, but got I
			//IL_01f9: Expected O, but got I
			//IL_0201: Expected O, but got I
			IntPtr intPtr = (IntPtr)0;
			int[] array = default(int[]);
			int num = default(int);
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v19 @ X21_v1 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr2 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X21_v9 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				CommonCacheTypeIdentifier.TypeInfo info = CacheTypeIdentifier<T>.info;
				if (!info.isMarker || !Has<T>())
				{
					array = components;
					if (array.Length >= 1)
					{
						num = 1;
						while (true)
						{
							int num2 = num - 1;
							if (array[num2] == info.id)
							{
								break;
							}
							int num3 = num + 1;
							num += 2;
							if (num3 < array.Length)
							{
								continue;
							}
							goto IL_011a;
						}
						goto IL_017d;
					}
				}
				goto IL_011a;
				IL_011a:
				IntPtr intPtr3 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ X20_v2 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr4 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ X20_v5 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				IntPtr intPtr5 = (IntPtr)0;
				object obj = (long)intPtr5;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v214 @ X1_v2 (should have been resolved before IL gen)");
				goto IL_017d;
				IL_017d:
				IntPtr intPtr6 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v220 @ X20_v7 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr7 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ X20_v10 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				IntPtr intPtr8 = (IntPtr)0;
				int num4 = num << 2;
				object obj2 = (long)(IntPtr)array + (long)num4;
				object obj3 = (long)(IntPtr)obj2 + 32L;
				object obj4 = (long)intPtr8;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v229 @ X2_v1 (should have been resolved before IL gen)");
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x600001C")]
		[Address(RVA = "0xAD13CC", Offset = "0xAD13CC", Length = "0x214")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>;\n\tgoto L_0015;\n\tv26 = v21;\n\tv27 = 0x8907BC(v26, exist, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = *([v21 @ X22_v1 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]);\nL_0015:\n\tv44 = *([v21 @ X22_v1 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]) & 0x200;\n\tv45 = v44 == 0;\n\tif (v45) goto L_0036;\n\tv47 = Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>;\n\tgoto L_0022;\n\tv69 = v47;\n\tv70 = 0x8907BC(v69, exist, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0022:\n\tv71 = *([v47 @ X22_v13 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+E0]) == 0;\n\tv57 = ~v71;\n\tif (v57) goto L_0036;\n\tgoto L_0036;\n\tv106 = v59;\n\tv107 = 0x8907BC(v106, exist, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0036:\n\tgoto L_003A;\n\tv72 = v64;\n\tv73 = 0x8907BC(v72, exist, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_003A:\n\tv76 = v75.info;\n\tv78 = ~v76.isMarker;\n\tif (v78) goto L_0049;\n\tv86 = Morpeh.Entity::Has(this);\n\tv88 = v86 == 0;\n\tif (v88) goto L_0049;\n\t*([exist @ X1 (System.Boolean&)]) = 1;\n\tgoto L_0077;\nL_0049:\n\tv93 = this.components;\n\tv105 = v93.Length < 1;\n\tif (v105) goto L_0075;\nL_0059:\n\tv187 = v186 - 1;\n\tv194 = v93[v187 @ X11_v4 (System.Int32)] == v76.id;\n\tif (v194) goto L_00A7;\n\tv117 = v186 + 1;\n\tv186 = v186 + 2;\n\tv122 = v117 < v93.Length;\n\tif (v122) goto L_0059;\nL_0075:\n\t*([exist @ X1 (System.Boolean&)]) = 0;\nL_0077:\n\tv170 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_0080;\n\tv199 = v170;\n\tv200 = 0x8907BC(v199, v164, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv203 = *([v170 @ X20_v2 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]);\nL_0080:\n\tv204 = *([v170 @ X20_v2 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]) & 0x200;\n\tv205 = v204 == 0;\n\tif (v205) goto L_00A0;\n\tv217 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_008D;\n\tv249 = v217;\n\tv250 = 0x8907BC(v249, v164, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_008D:\n\tv251 = *([v217 @ X20_v5 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]) == 0;\n\tv227 = ~v251;\n\tif (v227) goto L_00A0;\n\tgoto L_00A0;\n\tv311 = v229;\n\tv312 = 0x8907BC(v311, v164, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00A0:\n\tv238 = Il2CppMethodInfo;\n\tv239 = *([v238 @ X0_v7 (Il2CppMethodInfo)]);\n\t// 165 IndirectJump v239 @ X1_v2, methodof(Morpeh.CacheComponents`1<T>::Empty), methodof(Morpeh.CacheComponents`1<T>::Empty), v239 @ X1_v2, methodInfo @ X2 (Il2CppMethodInfo), v28 @ X3, v29 @ X4, v30 @ X5, v31 @ X6, v32 @ X7, v33 @ V0, v34 @ V1, v35 @ V2, v36 @ V3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\nL_00A7:\n\t*([exist @ X1 (System.Boolean&)]) = 1;\n\tv211 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_00B3;\n\tv242 = v211;\n\tv243 = 0x8907BC(v242, v89, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv246 = *([v211 @ X20_v7 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]);\nL_00B3:\n\tv247 = *([v211 @ X20_v7 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]) & 0x200;\n\tv248 = v247 == 0;\n\tif (v248) goto L_00D3;\n\tv289 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_00C0;\n\tv308 = v289;\n\tv309 = 0x8907BC(v308, v89, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00C0:\n\tv310 = *([v289 @ X20_v10 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]) == 0;\n\tv298 = ~v310;\n\tif (v298) goto L_00D3;\n\tgoto L_00D3;\n\tv318 = v300;\n\tv319 = 0x8907BC(v318, v89, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_00D3:\n\tv271 = Il2CppMethodInfo;\n\tv255 = v186 << 2;\n\tv283 = this.components + v255;\n\tv273 = v283 + 0x20;\n\tv253 = *([v271 @ X1_v4 (Il2CppMethodInfo)]);\n\t// 219 IndirectJump v253 @ X2_v1, v273 @ X0_v21, v273 @ X0_v21, methodof(Morpeh.CacheComponents`1<T>::Get), v253 @ X2_v1, v28 @ X3, v29 @ X4, v30 @ X5, v31 @ X6, v32 @ X7, v33 @ V0, v34 @ V1, v35 @ V2, v36 @ V3, v37 @ V4, v38 @ V5, v39 @ V6, v40 @ V7\n\treturn X0;\n// 134 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe ref T GetComponent<T>(out bool exist) where T : struct, IComponent
		{
			//IL_0183: Expected O, but got I
			//IL_0205: Expected O, but got I
			//IL_0214: Expected O, but got I
			//IL_021c: Expected O, but got I
			exist = default(bool);
			IntPtr intPtr = (IntPtr)0;
			int num = default(int);
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X22_v1 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr2 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v47 @ X22_v13 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				CommonCacheTypeIdentifier.TypeInfo info = CacheTypeIdentifier<T>.info;
				ref bool reference;
				if (info.isMarker && Has<T>())
				{
					reference = ref *(bool*)1;
					goto IL_0259;
				}
				int[] array = components;
				if (array.Length < 1)
				{
					goto IL_0127;
				}
				num = 1;
				while (true)
				{
					int num2 = num - 1;
					if (array[num2] == info.id)
					{
						break;
					}
					int num3 = num + 1;
					num += 2;
					if (num3 < array.Length)
					{
						continue;
					}
					goto IL_0127;
				}
				goto IL_018d;
				IL_0259:
				IntPtr intPtr3 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v170 @ X20_v2 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr4 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v217 @ X20_v5 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				IntPtr intPtr5 = (IntPtr)0;
				object obj = (long)intPtr5;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v239 @ X1_v2 (should have been resolved before IL gen)");
				goto IL_018d;
				IL_0127:
				reference = ref *(bool*)null;
				goto IL_0259;
				IL_018d:
				reference = ref *(bool*)1;
				IntPtr intPtr6 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v211 @ X20_v7 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr7 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v289 @ X20_v10 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				IntPtr intPtr8 = (IntPtr)0;
				int num4 = num << 2;
				object obj2 = (long)(IntPtr)components + (long)num4;
				object obj3 = (long)(IntPtr)obj2 + 32L;
				object obj4 = (long)intPtr8;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v253 @ X2_v1 (should have been resolved before IL gen)");
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x600001D")]
		[Address(RVA = "0xBB4100", Offset = "0xBB4100", Length = "0x43C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv36 = *([1EA76E8]);\n\tv37 = *([v36 @ X8_v77]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, value, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([2022C59]) = v54;\nL_001E:\n\tv57 = Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>;\n\tgoto L_0027;\n\tv62 = v57;\n\tv63 = 0x8907BC(v62, value, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv66 = *([v57 @ X22_v2 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]);\nL_0027:\n\tv67 = *([v57 @ X22_v2 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]) & 0x200;\n\tv68 = v67 == 0;\n\tif (v68) goto L_0048;\n\tv70 = Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>;\n\tgoto L_0034;\n\tv92 = v70;\n\tv93 = 0x8907BC(v92, value, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0034:\n\tv94 = *([v70 @ X22_v23 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+E0]) == 0;\n\tv80 = ~v94;\n\tif (v80) goto L_0048;\n\tgoto L_0048;\n\tv126 = v85;\n\tv127 = 0x8907BC(v126, value, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0048:\n\tgoto L_004D;\n\tv95 = v87;\n\tv96 = 0x8907BC(v95, value, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_004D:\n\tv100 = v98.info;\n\tv105 = ~this.ComponentsMask;\n\tv106 = v100.mask & v105;\n\tv107 = v106 == 0;\n\tv108 = ~v107;\n\tif (v108) goto L_00D2;\n\tv114 = ~this.ComponentsMask.field1;\n\tv115 = v100.mask.field1 & v114;\n\tv116 = v115 == 0;\n\tv117 = ~v116;\n\tif (v117) goto L_00D2;\n\tv131 = ~this.ComponentsMask.field2;\n\tv121 = v100.mask.field2 & v131;\n\tv132 = v121 == 0;\n\tv123 = ~v132;\n\tif (v123) goto L_00D2;\n\tv164 = ~this.ComponentsMask.field3;\n\tv165 = v100.mask.field3 & v164;\n\tv141 = v165 == 0;\n\tv166 = ~v100.isMarker;\n\tv150 = ~v166;\n\tif (v150) goto L_00D5;\nL_0072:\n\tv162 = v159 == 0;\n\tif (v162) goto L_00F3;\n\tv204 = this.components;\n\tv182 = v204.Length < 1;\n\tif (v182) goto L_00DE;\n\tgoto L_0086;\nL_0084:\n\tv204 = this.components;\n\tv179 = v179 + 2;\nL_0086:\n\tv371 = v179 - 2;\n\tv385 = v204[v371 @ X8_v53 (System.Int32)] != v100.id;\n\tif (v385) goto L_00CE;\n\tv421 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_00A0;\n\tv482 = v421;\n\tv483 = 0x8907BC(v482, v352, v353, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv486 = *([v421 @ X22_v18 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]);\nL_00A0:\n\tv487 = *([v421 @ X22_v18 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]) & 0x200;\n\tv488 = v487 == 0;\n\tif (v488) goto L_00BC;\n\tv544 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_00AD;\n\tv577 = v544;\n\tv578 = 0x8907BC(v577, v352, v353, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_00AD:\n\tv579 = *([v544 @ X22_v20 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]) == 0;\n\tv553 = ~v579;\n\tif (v553) goto L_00BC;\n\tgoto L_00BC;\n\tv610 = v557;\n\tv611 = 0x8907BC(v610, v352, v353, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_00BC:\n\tv559 = v179 - 1;\n\tv428 = v559 << 2;\n\tv429 = v204 + v428;\n\tv560 = v429 + 0x20;\n\tthis = Morpeh.CacheComponents`1<T>::Set(v560, value);\nL_00CE:\n\tv183 = v179 < v204.Length;\n\tif (v183) goto L_0084;\n\tgoto L_00DE;\nL_00D2:\n\tv125 = ~v100.isMarker;\n\tif (v125) goto L_0072;\nL_00D5:\n\tv152 = v147 == 0;\n\tv153 = ~v152;\n\tif (v153) goto L_00DE;\n\tv167 = this.World;\n\tMorpeh.Filter::EntityChanged(v167.Filter, this.InternalID);\nL_00DE:\n\tv229 = v100.id >> 6;\n\tv230 = v229 < 3;\n\tv231 = ~v230;\n\tv232 = v229 - 3;\n\tv234 = v232 == 0;\n\tv239 = ~v234;\n\tv240 = v231 & v239;\n\tif (v240) goto L_01C9;\n\tv250 = 0x1819000 + 0xA60;\n\tv252 = *([v250 @ X10_v5 (System.Int32)+v229 @ X9_v5 (System.Int32)*4]) + v250;\n\t// 239 IndirectJump v252 @ X9_v7, this @ X0 (Morpeh.Entity), this @ X0 (Morpeh.Entity), value @ X1 (T&), v174 @ X2_v9 (Il2CppMethodInfo), v39 @ X3, v40 @ X4, v41 @ X5, v42 @ X6, v43 @ X7, v44 @ V0, v45 @ V1, v46 @ V2, v47 @ V3, v48 @ V4, v49 @ V5, v50 @ V6, v51 @ V7\n\tX23 = X19 + 0x20;\n\tgoto L_01B7;\nL_00F3:\n\tv244 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_00FC;\n\tv312 = v244;\n\tv313 = 0x8907BC(v312, value, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv316 = *([v244 @ X22_v8 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]);\nL_00FC:\n\tv317 = *([v244 @ X22_v8 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]) & 0x200;\n\tv318 = v317 == 0;\n\tif (v318) goto L_011A;\n\tv387 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_0109;\n\tv436 = v387;\n\tv437 = 0x8907BC(v436, value, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0109:\n\tv438 = *([v387 @ X22_v14 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]) == 0;\n\tv397 = ~v438;\n\tif (v397) goto L_011A;\n\tgoto L_011A;\n\tv561 = v402;\n\tv562 = 0x8907BC(v561, value, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_011A:\n\tv406 = Morpeh.CacheComponents`1<T>::Add();\n\tv466 = this.componentsDoubleCount;\n\tv408 = this + 0x40;\n\tv419 = this.componentsDoubleCount < 1;\n\tif (v419) goto L_014E;\nL_012B:\n\tv506 = *([v408 @ X0_v12 (System.Int32[]&)]);\n\tv520 = v506[v505 @ X9_v23 (System.Int32)] != v100.id;\n\tif (v520) goto L_0140;\n\tv566 = v505 + 1;\n\tv506[v566 @ X12_v6 (System.Int32)] = v406;\nL_0140:\n\tv505 = v505 + 2;\n\tv445 = v505 < v466;\n\tif (v445) goto L_012B;\n\tv466 = this.componentsDoubleCount;\nL_014E:\n\tv527 = this.components;\n\tv529 = v466 + 2;\n\tthis.componentsDoubleCount = v529;\n\tv481 = v529 < v527.Length;\n\tif (v481) goto L_0166;\n\tv523 = v529 << 1;\n\tSystem.Array::Resize(v408, v523);\n\tv527 = this.components;\n\tv529 = this.componentsDoubleCount;\nL_0166:\n\tv532 = v529 - 2;\n\tv527[v532 @ X8_v25 (System.Int32)] = v100.id;\n\tv537 = this.components;\n\tv538 = this.componentsDoubleCount - 1;\n\tv537[v538 @ X8_v28 (System.Int32)] = v406;\n\tv540 = this.World;\n\tMorpeh.Filter::EntityChanged(v540.Filter, this.InternalID);\n\tv572 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_0180;\n\tv580 = v572;\n\tv581 = 0x8907BC(v580, v541, v535, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv584 = *([v572 @ X22_v10 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]);\nL_0180:\n\tv585 = *([v572 @ X22_v10 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]) & 0x200;\n\tv586 = v585 == 0;\n\tif (v586) goto L_01A0;\n\tv591 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_018D;\n\tv614 = v591;\n\tv615 = 0x8907BC(v614, v541, v535, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_018D:\n\tv616 = *([v591 @ X22_v12 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]) == 0;\n\tv600 = ~v616;\n\tif (v600) goto L_01A0;\n\tgoto L_01A0;\n\tv622 = v604;\n\tv623 = 0x8907BC(v622, v541, v535, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_01A0:\n\tthis = Morpeh.CacheComponents`1<T>::Set(&v406 @ X0_v11 (System.Int32), value);\n\tv291 = v100.id >> 6;\n\tv608 = v291 < 3;\n\tv283 = ~v608;\n\tv277 = v291 - 3;\n\tv285 = v277 == 0;\n\tv609 = ~v285;\n\tv269 = v283 & v609;\n\tif (v269) goto L_01C9;\n\tv339 = 0x1819000 + 0xA50;\n\tv341 = *([v339 @ X10_v14 (System.Int32)+v291 @ X9_v16 (System.Int32)*4]) + v339;\n\t// 435 IndirectJump v341 @ X9_v18, this @ X0 (Morpeh.Entity), this @ X0 (Morpeh.Entity), value @ X1 (T&), methodof(Morpeh.CacheComponents`1<T>::Set), v39 @ X3, v40 @ X4, v41 @ X5, v42 @ X6, v43 @ X7, v44 @ V0, v45 @ V1, v46 @ V2, v47 @ V3, v48 @ V4, v49 @ V5, v50 @ V6, v51 @ V7\n\tX23 = X19 + 0x28;\n\tgoto L_01B7;\n\tX23 = X19 + 0x30;\nL_01B7:\n\tX9 = *([X23]);\n\tX8 = X8 & 0x3F;\n\tX10 = 0 | 1;\n\tX8 = X10 << X8;\n\tX8 = X9 | X8;\n\t*([X23]) = X8;\nL_01C9:\n\treturn;\n// 264 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void SetComponent<T>(in T value) where T : struct, IComponent
		{
			//IL_005e: Expected I4, but got O
			//IL_006b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0070: Expected I4, but got Unknown
			//IL_00a8: Expected I4, but got I8
			//IL_00bf: Expected I4, but got I8
			//IL_00f7: Expected I4, but got I8
			//IL_010e: Expected I4, but got I8
			//IL_0332: Expected I, but got O
			//IL_03cb: Expected O, but got I
			//IL_0146: Expected I4, but got I8
			//IL_015d: Expected I4, but got I8
			//IL_05b4: Expected O, but got I
			//IL_028b: Expected O, but got I
			while (true)
			{
				IntPtr intPtr = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ X22_v2 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr2 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ X22_v23 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				CommonCacheTypeIdentifier.TypeInfo info = CacheTypeIdentifier<T>.info;
				int num = (int)(~ComponentsMask);
				bool flag4;
				bool flag5;
				if ((int)(info.mask & num) == 0)
				{
					int num2 = (int)(~ComponentsMask.field1);
					if ((int)((long)info.mask.field1 & (long)num2) == 0)
					{
						int num3 = (int)(~ComponentsMask.field2);
						if ((int)((long)info.mask.field2 & (long)num3) == 0)
						{
							int num4 = (int)(~ComponentsMask.field3);
							int num5 = (int)((long)info.mask.field3 & (long)num4);
							bool flag = num5 == 0;
							bool flag2 = !info.isMarker;
							bool flag3 = !flag2;
							flag4 = flag;
							flag5 = flag;
							if (!flag3)
							{
								goto IL_01a5;
							}
							goto IL_02e7;
						}
					}
				}
				bool flag6 = !info.isMarker;
				flag4 = false;
				flag5 = false;
				if (flag6)
				{
					goto IL_01a5;
				}
				goto IL_02e7;
				IL_02e7:
				if (!flag5)
				{
					World world = World;
					world.Filter.EntityChanged(ID);
					IntPtr intPtr3 = (IntPtr)null;
				}
				goto IL_0337;
				IL_03d5:
				IntPtr intPtr4 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v244 @ X22_v8 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr5 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v387 @ X22_v14 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				int id = CacheComponents<T>.Add();
				int num6 = componentsDoubleCount;
				ref int[] reference = ref *(int[]*)((long)(IntPtr)this + 64L);
				if (componentsDoubleCount >= 1)
				{
					int num7 = 0;
					do
					{
						int[] array = reference;
						if (array[num7] == info.id)
						{
							int num8 = num7 + 1;
							array[num8] = id;
						}
						num7 += 2;
					}
					while (num7 < num6);
					num6 = componentsDoubleCount;
				}
				int[] array2 = components;
				int num9 = (componentsDoubleCount = num6 + 2);
				if (num9 >= array2.Length)
				{
					int newSize = num9 << 1;
					Array.Resize(ref reference, newSize);
					array2 = components;
					num9 = componentsDoubleCount;
				}
				int num10 = num9 - 2;
				array2[num10] = info.id;
				int[] array3 = components;
				int num11 = componentsDoubleCount - 1;
				array3[num11] = id;
				World world2 = World;
				world2.Filter.EntityChanged(ID);
				IntPtr intPtr6 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v572 @ X22_v10 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]");
				if (0u != 0)
				{
					IntPtr intPtr7 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v591 @ X22_v12 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]");
					if ((IntPtr)0 != (IntPtr)0)
					{
					}
				}
				CacheComponents<T>.Set(in id, in value);
				int num12 = info.id >> 6;
				bool flag7 = num12 < 3;
				bool flag8 = !flag7;
				int num13 = num12 - 3;
				bool flag9 = num13 == 0;
				bool flag10 = !flag9;
				if (!(flag8 && flag10))
				{
					int num14 = 25268224 + 2640;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ X10_v14 (System.Int32)+v291 @ X9_v16 (System.Int32)*4]");
					object obj = 0L + (long)num14;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v341 @ X9_v18 (should have been resolved before IL gen)");
					continue;
				}
				break;
				IL_0337:
				int num15 = info.id >> 6;
				bool flag11 = num15 < 3;
				bool flag12 = !flag11;
				int num16 = num15 - 3;
				bool flag13 = num16 == 0;
				bool flag14 = !flag13;
				if (!(flag12 && flag14))
				{
					int num17 = 25268224 + 2656;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v250 @ X10_v5 (System.Int32)+v229 @ X9_v5 (System.Int32)*4]");
					object obj2 = 0L + (long)num17;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v252 @ X9_v7 (should have been resolved before IL gen)");
					goto IL_03d5;
				}
				break;
				IL_01a5:
				if (flag4)
				{
					int[] array4 = components;
					if (array4.Length >= 1)
					{
						int num18 = 2;
						while (true)
						{
							int num19 = num18 - 2;
							if (array4[num19] == info.id)
							{
								IntPtr intPtr8 = (IntPtr)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v421 @ X22_v18 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]");
								if (0u != 0)
								{
									IntPtr intPtr9 = (IntPtr)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v544 @ X22_v20 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]");
									if ((IntPtr)0 != (IntPtr)0)
									{
									}
								}
								int num20 = num18 - 1;
								int num21 = num20 << 2;
								object obj3 = (long)(IntPtr)array4 + (long)num21;
								CacheComponents<T>.Set(in *(int*)((long)(IntPtr)obj3 + 32L), in value);
								IntPtr intPtr3 = (IntPtr)0;
							}
							if (num18 < array4.Length)
							{
								array4 = components;
								num18 += 2;
								continue;
							}
							break;
						}
					}
					goto IL_0337;
				}
				goto IL_03d5;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x600001E")]
		[Address(RVA = "0x11BC710", Offset = "0x11BC710", Length = "0x378")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv28 = *([1EF1630]);\n\tv29 = *([v28 @ X8_v51]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([2027B19]) = v47;\nL_0019:\n\tv49 = Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>;\n\tgoto L_0022;\n\tv54 = v49;\n\tv55 = 0x8907BC(v54, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv58 = *([v49 @ X21_v2 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]);\nL_0022:\n\tv59 = *([v49 @ X21_v2 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]) & 0x200;\n\tv60 = v59 == 0;\n\tif (v60) goto L_0043;\n\tv62 = Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>;\n\tgoto L_002F;\n\tv84 = v62;\n\tv85 = 0x8907BC(v84, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_002F:\n\tv86 = *([v62 @ X21_v19 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+E0]) == 0;\n\tv72 = ~v86;\n\tif (v72) goto L_0043;\n\tgoto L_0043;\n\tv118 = v77;\n\tv119 = 0x8907BC(v118, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0043:\n\tgoto L_0047;\n\tv87 = v79;\n\tv88 = 0x8907BC(v87, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0047:\n\tv91 = v90.info;\n\tv93 = ~v91.isMarker;\n\tif (v93) goto L_0085;\n\tv101 = ~v45.ComponentsMask;\n\tv102 = v91.mask & v101;\n\tv103 = v102 == 0;\n\tv104 = ~v103;\n\tif (v104) goto L_FFFFFFFF;\n\tv126 = ~v45.ComponentsMask.field1;\n\tv127 = v91.mask.field1 & v126;\n\tv128 = v127 == 0;\n\tv129 = ~v128;\n\tif (v129) goto L_FFFFFFFF;\n\tv189 = ~v45.ComponentsMask.field2;\n\tv170 = v91.mask.field2 & v189;\n\tv190 = v170 == 0;\n\tv180 = ~v190;\n\tif (v180) goto L_FFFFFFFF;\n\tv276 = ~v45.ComponentsMask.field3;\n\tv164 = v91.mask.field3 & v276;\n\tv277 = v164 == 0;\n\tv181 = ~v277;\n\tif (v181) goto L_FFFFFFFF;\n\tv345 = v91.id >> 6;\n\tv346 = v345 < 3;\n\tv312 = ~v346;\n\tv309 = v345 - 3;\n\tv303 = v309 == 0;\n\tv347 = ~v303;\n\tv288 = v312 & v347;\n\tif (v288) goto L_015D;\n\tv356 = 0x182A000 + 0x678;\n\tv285 = *([v356 @ X14_v2 (System.Int32)+v345 @ X13_v6 (System.Int32)*4]) + v356;\n\t// 130 IndirectJump v285 @ X14_v3, v89 @ X0_v4 (Morpeh.Entity), v89 @ X0_v4 (Morpeh.Entity), methodInfo @ X1 (Il2CppMethodInfo), v31 @ X2, v32 @ X3, v33 @ X4, v34 @ X5, v35 @ X6, v36 @ X7, v37 @ V0, v38 @ V1, v39 @ V2, v40 @ V3, v41 @ V4, v42 @ V5, v43 @ V6, v44 @ V7\n\tX13 = X9;\n\tgoto L_014C;\nL_0085:\n\tv105 = v45.components;\n\tv117 = v105.Length < 1;\n\tif (v117) goto L_FFFFFFFF;\nL_0095:\n\tv262 = v260 - 1;\n\tv269 = v105[v262 @ X10_v8 (System.Int32)] == v91.id;\n\tif (v269) goto L_00BD;\n\tv173 = v260 + 1;\n\tv260 = v260 + 2;\n\tv134 = v173 < v105.Length;\n\tif (v134) goto L_0095;\nL_00BB:\n\treturn returnVal1;\nL_00BD:\n\tv340 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_00C6;\n\tv348 = v340;\n\tv349 = 0x8907BC(v348, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv352 = *([v340 @ X21_v12 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]);\nL_00C6:\n\tv353 = *([v340 @ X21_v12 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]) & 0x200;\n\tv354 = v353 == 0;\n\tif (v354) goto L_00E2;\n\tv365 = Il2CppClass<Morpeh.CacheComponents`1<T>>;\n\tgoto L_00D3;\n\tv405 = v365;\n\tv406 = 0x8907BC(v405, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_00D3:\n\tv407 = *([v365 @ X21_v15 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]) == 0;\n\tv374 = ~v407;\n\tif (v374) goto L_00E2;\n\tgoto L_00E2;\n\tv552 = v378;\n\tv553 = 0x8907BC(v552, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_00E2:\n\tv283 = v260 << 2;\n\tv380 = v105 + v283;\n\tv381 = v380 + 0x20;\n\tv327 = Morpeh.CacheComponents`1<T>::Remove(v381);\n\tv383 = v91.id >> 6;\n\tv384 = v383 < 3;\n\tv313 = ~v384;\n\tv310 = v383 - 3;\n\tv304 = v310 == 0;\n\tv385 = ~v304;\n\tv289 = v313 & v385;\n\tif (v289) goto L_0113;\n\tv322 = 0x182A000 + 0x688;\n\tv324 = *([v322 @ X10_v12 (System.Int32)+v383 @ X9_v9 (System.Int32)*4]) + v322;\n\t// 250 IndirectJump v324 @ X9_v11, v327 @ X0_v17 (System.Boolean), v327 @ X0_v17 (System.Boolean), methodof(Morpeh.CacheComponents`1<T>::Remove), v31 @ X2, v32 @ X3, v33 @ X4, v34 @ X5, v35 @ X6, v36 @ X7, v37 @ V0, v38 @ V1, v39 @ V2, v40 @ V3, v41 @ V4, v42 @ V5, v43 @ V6, v44 @ V7\n\tX9 = X19 + 0x18;\n\tgoto L_0102;\n\tX9 = X19 + 0x20;\n\tgoto L_0102;\n\tX9 = X19 + 0x28;\n\tgoto L_0102;\n\tX9 = X19 + 0x30;\nL_0102:\n\tX10 = *([X9]);\n\tX8 = X8 & 0x3F;\n\tX11 = 0 | 1;\n\tX8 = X11 << X8;\n\tTEMP = ~X8;\n\tX8 = X10 & TEMP;\n\t*([X9]) = X8;\nL_0113:\n\tgoto L_0125;\n\tv498 = *([v416 @ X0_v18 (Il2CppClass<Morpeh.Utils.FastBitMask>)+E0]);\n\tv499 = v498 == 0;\n\tv500 = ~v499;\n\tgoto L_0125;\n\tv556 = \"il2cpp_codegen_runtime_class_init\"(v416, v281, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv501 = Morpeh.Utils.FastBitMask;\nL_0125:\n\tv437 = v45.ComponentsMask.field2 != v503.None;\n\tif (v437) goto L_0197;\n\tv434 = v45.ComponentsMask != v503.None;\n\tif (v434) goto L_0197;\n\tv435 = v45.ComponentsMask.field1 != v503.None;\n\tif (v435) goto L_0197;\n\tv580 = v45.World;\n\tv523 = v45.ComponentsMask.field3 == v45.ComponentsMask.field1;\n\tif (v523) goto L_0195;\n\tgoto L_019B;\n\tX13 = X10;\n\tgoto L_014C;\n\tX13 = X11;\nL_014C:\n\tX14 = *([X13]);\n\tX12 = X12 & 0x3F;\n\tX15 = 0 | 1;\n\tX12 = X15 << X12;\n\tTEMP = ~X12;\n\tX12 = X14 & TEMP;\n\t*([X13]) = X12;\n\tX21 = *([X8]);\n\tX20 = *([X9]);\n\tX24 = *([X10]);\n\tX23 = *([X11]);\nL_015D:\n\tgoto L_016F;\n\tv386 = *([v360 @ X0_v33 (Il2CppClass<Morpeh.Utils.FastBitMask>)+E0]);\n\tv387 = v386 == 0;\n\tv388 = ~v387;\n\tgoto L_016F;\n\tv420 = \"il2cpp_codegen_runtime_class_init\"(v360, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv390 = Morpeh.Utils.FastBitMask;\nL_016F:\n\tv404 = v45.ComponentsMask.field2 != v393.None;\n\tif (v404) goto L_0197;\n\tv430 = v45.ComponentsMask != v393.None;\n\tif (v430) goto L_0197;\n\tv436 = v45.ComponentsMask.field1 != v393.None;\n\tif (v436) goto L_0197;\n\tv580 = v45.World;\n\tv509 = v45.ComponentsMask.field3 != v45.ComponentsMask.field1;\n\tif (v509) goto L_019B;\nL_0195:\n\tMorpeh.World::RemoveEntity(v580, v45);\n\tgoto L_FFFFFFFF;\nL_0197:\n\tv542 = v45.World;\nL_019B:\n\tMorpeh.Filter::EntityChanged(v542.Filter, v45.InternalID);\n\tgoto L_00BB;\n\treturn X0;\n// 241 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe bool RemoveComponent<T>() where T : struct, IComponent
		{
			//IL_007c: Expected I4, but got O
			//IL_0089: Unknown result type (might be due to invalid IL or missing references)
			//IL_008e: Expected I4, but got Unknown
			//IL_00c6: Expected I4, but got I8
			//IL_00dd: Expected I4, but got I8
			//IL_0115: Expected I4, but got I8
			//IL_012c: Expected I4, but got I8
			//IL_0327: Expected O, but got I
			//IL_0164: Expected I4, but got I8
			//IL_017b: Expected I4, but got I8
			//IL_03d7: Expected O, but got I
			//IL_0237: Expected O, but got I
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ X21_v2 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X21_v19 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			CommonCacheTypeIdentifier.TypeInfo info = CacheTypeIdentifier<T>.info;
			if (!info.isMarker)
			{
				goto IL_0241;
			}
			int num = (int)(~ComponentsMask);
			World world;
			World world2;
			if ((int)(info.mask & num) == 0)
			{
				int num2 = (int)(~ComponentsMask.field1);
				if ((int)((long)info.mask.field1 & (long)num2) == 0)
				{
					int num3 = (int)(~ComponentsMask.field2);
					if ((int)((long)info.mask.field2 & (long)num3) == 0)
					{
						int num4 = (int)(~ComponentsMask.field3);
						if ((int)((long)info.mask.field3 & (long)num4) == 0)
						{
							int num5 = info.id >> 6;
							bool flag = num5 < 3;
							bool flag2 = !flag;
							int num6 = num5 - 3;
							bool flag3 = num6 == 0;
							bool flag4 = !flag3;
							if (!(flag2 && flag4))
							{
								int num7 = 25337856 + 1656;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v356 @ X14_v2 (System.Int32)+v345 @ X13_v6 (System.Int32)*4]");
								object obj = 0L + (long)num7;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v285 @ X14_v3 (should have been resolved before IL gen)");
								goto IL_0241;
							}
							if (ComponentsMask.field2 != (ulong)(long)FastBitMask.None || (object)ComponentsMask != (object)FastBitMask.None || ComponentsMask.field1 != (ulong)(long)FastBitMask.None)
							{
								goto IL_0506;
							}
							world = World;
							bool flag5 = ComponentsMask.field3 != ComponentsMask.field1;
							world2 = World;
							if (!flag5)
							{
								goto IL_04f7;
							}
							goto IL_05ca;
						}
					}
				}
			}
			goto IL_02b2;
			IL_04f7:
			world.RemoveEntity(this);
			goto IL_0515;
			IL_0241:
			int[] array = components;
			if (array.Length < 1)
			{
				goto IL_02b2;
			}
			int num8 = 1;
			while (true)
			{
				int num9 = num8 - 1;
				if (array[num9] == info.id)
				{
					break;
				}
				int num10 = num8 + 1;
				num8 += 2;
				if (num10 < array.Length)
				{
					continue;
				}
				goto IL_02b2;
			}
			IntPtr intPtr3 = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ X21_v12 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr4 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v365 @ X21_v15 (Il2CppClass<Morpeh.CacheComponents`1<T>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			int num11 = num8 << 2;
			object obj2 = (long)(IntPtr)array + (long)num11;
			bool flag6 = CacheComponents<T>.Remove(in *(int*)((long)(IntPtr)obj2 + 32L));
			int num12 = info.id >> 6;
			bool flag7 = num12 < 3;
			bool flag8 = !flag7;
			int num13 = num12 - 3;
			bool flag9 = num13 == 0;
			bool flag10 = !flag9;
			if (!(flag8 && flag10))
			{
				int num14 = 25337856 + 1672;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ X10_v12 (System.Int32)+v383 @ X9_v9 (System.Int32)*4]");
				object obj3 = 0L + (long)num14;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v324 @ X9_v11 (should have been resolved before IL gen)");
			}
			else if (ComponentsMask.field2 != (ulong)(long)FastBitMask.None)
			{
				goto IL_0506;
			}
			if ((object)ComponentsMask != (object)FastBitMask.None || ComponentsMask.field1 != (ulong)(long)FastBitMask.None)
			{
				goto IL_0506;
			}
			world = World;
			if (ComponentsMask.field3 == ComponentsMask.field1)
			{
				goto IL_04f7;
			}
			world2 = World;
			goto IL_05ca;
			IL_0515:
			return true;
			IL_0506:
			world2 = World;
			goto IL_05ca;
			IL_05ca:
			world2.Filter.EntityChanged(ID);
			goto IL_0515;
			IL_02b2:
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x600001F")]
		[Address(RVA = "0x15F5C04", Offset = "0x15F5C04", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = ~this.ComponentsMask;\n\tv5 = *([mask @ X1 (Morpeh.Utils.FastBitMask&)]) & v4;\n\tv6 = v5 == 0;\n\tv7 = ~v6;\n\tif (v7) goto L_0020;\n\tv10 = ~this.ComponentsMask.field1;\n\tv11 = *([mask @ X1 (Morpeh.Utils.FastBitMask&)+8]) & v10;\n\tv12 = v11 == 0;\n\tv13 = ~v12;\n\tif (v13) goto L_0020;\n\tv22 = ~this.ComponentsMask.field2;\n\tv19 = *([mask @ X1 (Morpeh.Utils.FastBitMask&)+10]) & v22;\n\tv23 = v19 == 0;\n\tv15 = ~v23;\n\tif (v15) goto L_0020;\n\tv44 = ~this.ComponentsMask.field3;\n\tv39 = *([mask @ X1 (Morpeh.Utils.FastBitMask&)+18]) & v44;\n\tv33 = v39 == 0;\n\treturn v33;\nL_0020:\n\treturn 0;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool Has(in FastBitMask mask)
		{
			//IL_000b: Expected I4, but got O
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Expected I4, but got Unknown
			int num = (int)(~ComponentsMask);
			if ((int)(mask & num) == 0)
			{
				long num2 = (long)(~ComponentsMask.field1);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [mask @ X1 (Morpeh.Utils.FastBitMask&)+8]");
				long num3 = 0 & num2;
				if (num3 == 0)
				{
					long num4 = (long)(~ComponentsMask.field2);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [mask @ X1 (Morpeh.Utils.FastBitMask&)+10]");
					long num5 = 0 & num4;
					if (num5 == 0)
					{
						long num6 = (long)(~ComponentsMask.field3);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [mask @ X1 (Morpeh.Utils.FastBitMask&)+18]");
						long num7 = 0 & num6;
						return num7 == 0;
					}
				}
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x6000020")]
		[Address(RVA = "0x11B9B00", Offset = "0x11B9B00", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>;\n\tgoto L_0013;\n\tv22 = v17;\n\tv23 = 0x8907BC(v22, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = *([v17 @ X21_v1 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]);\nL_0013:\n\tv41 = *([v17 @ X21_v1 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]) & 0x200;\n\tv42 = v41 == 0;\n\tif (v42) goto L_0034;\n\tv44 = Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>;\n\tgoto L_0020;\n\tv66 = v44;\n\tv67 = 0x8907BC(v66, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0020:\n\tv68 = *([v44 @ X21_v4 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+E0]) == 0;\n\tv54 = ~v68;\n\tif (v54) goto L_0034;\n\tgoto L_0034;\n\tv96 = v56;\n\tv97 = 0x8907BC(v96, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0034:\n\tgoto L_0039;\n\tv69 = v61;\n\tv70 = 0x8907BC(v69, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0039:\n\tv74 = v72.info;\n\tv76 = ~this.ComponentsMask;\n\tv77 = v74.mask & v76;\n\tv78 = v77 == 0;\n\tv79 = ~v78;\n\tif (v79) goto L_FFFFFFFF;\n\tv85 = ~this.ComponentsMask.field1;\n\tv86 = v74.mask.field1 & v85;\n\tv87 = v86 == 0;\n\tv88 = ~v87;\n\tif (v88) goto L_FFFFFFFF;\n\tv101 = ~this.ComponentsMask.field2;\n\tv90 = v74.mask.field2 & v101;\n\tv102 = v90 == 0;\n\tv94 = ~v102;\n\tif (v94) goto L_FFFFFFFF;\n\tv129 = ~this.ComponentsMask.field3;\n\tv121 = v74.mask.field3 & v129;\n\tv111 = v121 == 0;\n\tgoto L_005F;\nL_005F:\n\treturn returnVal1;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool Has<T>() where T : struct, IComponent
		{
			//IL_0064: Expected I4, but got O
			//IL_0071: Unknown result type (might be due to invalid IL or missing references)
			//IL_0076: Expected I4, but got Unknown
			//IL_00ae: Expected I4, but got I8
			//IL_00c5: Expected I4, but got I8
			//IL_00fd: Expected I4, but got I8
			//IL_0114: Expected I4, but got I8
			//IL_014c: Expected I4, but got I8
			//IL_0163: Expected I4, but got I8
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v17 @ X21_v1 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+12E]");
			if (0u != 0)
			{
				IntPtr intPtr2 = (IntPtr)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X21_v4 (Il2CppClass<Morpeh.CacheTypeIdentifier`1<T>>)+E0]");
				if ((IntPtr)0 != (IntPtr)0)
				{
				}
			}
			CommonCacheTypeIdentifier.TypeInfo info = CacheTypeIdentifier<T>.info;
			int num = (int)(~ComponentsMask);
			if ((int)(info.mask & num) == 0)
			{
				int num2 = (int)(~ComponentsMask.field1);
				if ((int)((long)info.mask.field1 & (long)num2) == 0)
				{
					int num3 = (int)(~ComponentsMask.field2);
					if ((int)((long)info.mask.field2 & (long)num3) == 0)
					{
						int num4 = (int)(~ComponentsMask.field3);
						int num5 = (int)((long)info.mask.field3 & (long)num4);
						return num5 == 0;
					}
				}
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[Token(Token = "0x6000021")]
		[Address(RVA = "0x15F5C50", Offset = "0x15F5C50", Length = "0xB0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv24 = *([1EC6DB8]);\n\tv25 = *([v24 @ X8_v10]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([202A041]) = v44;\nL_0020:\n\tgoto L_002D;\n\tv55 = *([v51 @ X0_v2 (Il2CppClass<Morpeh.Utils.FastBitMask>)+E0]);\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\tgoto L_002D;\n\tv114 = \"il2cpp_codegen_runtime_class_init\"(v51, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv59 = Morpeh.Utils.FastBitMask;\nL_002D:\n\tv68 = this.ComponentsMask - v62.None;\n\tv70 = v68 == 0;\n\tv78 = this.ComponentsMask.field1 - v62.None;\n\tv80 = v78 == 0;\n\tv88 = this.ComponentsMask.field2 - v62.None;\n\tv90 = v88 == 0;\n\tv95 = v70 & v80;\n\tv99 = this.ComponentsMask.field3 - v62.None;\n\tv101 = v99 == 0;\n\tv110 = v90 & v95;\n\treturnVal1 = v101 & v110;\n\treturn returnVal1;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public bool IsDisposed()
		{
			//IL_0039: Unknown result type (might be due to invalid IL or missing references)
			//IL_003e: Expected O, but got Unknown
			//IL_005d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0062: Expected O, but got Unknown
			//IL_008e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0093: Expected O, but got Unknown
			object obj = (object)ComponentsMask - (object)FastBitMask.None;
			bool flag = obj == null;
			object obj2 = ComponentsMask.field1 - FastBitMask.None;
			bool flag2 = obj2 == null;
			object obj3 = ComponentsMask.field2 - FastBitMask.None;
			bool flag3 = obj3 == null;
			bool flag4 = flag && flag2;
			object obj4 = ComponentsMask.field3 - FastBitMask.None;
			bool flag5 = obj4 == null;
			bool flag6 = flag3 && flag4;
			return flag5 && flag6;
		}

		[Token(Token = "0x6000022")]
		[Address(RVA = "0x15F5D00", Offset = "0x15F5D00", Length = "0x1E8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv34 = *([1EC4E38]);\n\tv35 = *([v34 @ X8_v20]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([202A042]) = v54;\nL_001F:\n\tv151 = v52.components;\n\tv71 = v151.Length < 1;\n\tif (v71) goto L_FFFFFFFF;\n\tv77 = 0x1844000 + 0x860;\n\tv79 = 0x1844000 + 0x850;\n\tgoto L_003A;\nL_0036:\n\tv151 = v52.components;\nL_003A:\n\tv81 = v151[v148 @ X23_v4 (System.Int32)] >> 6;\n\tv156 = v81 < 3;\n\tv157 = ~v156;\n\tv158 = v81 - 3;\n\tv160 = v158 == 0;\n\tv165 = ~v160;\n\tv166 = v157 & v165;\n\tif (v166) goto L_005B;\n\tv190 = *([v79 @ X27_v4 (System.Int32)+v81 @ X28_v4 (System.Int32)*4]) + v79;\n\t// 74 IndirectJump v190 @ X10_v8, v120 @ X0_v8 (Morpeh.Entity), v120 @ X0_v8 (Morpeh.Entity), v101 @ X1_v3 (Il2CppMethodInfo), v38 @ X2, v39 @ X3, v40 @ X4, v41 @ X5, v42 @ X6, v43 @ X7, v44 @ V0, v45 @ V1, v46 @ V2, v47 @ V3, v48 @ V4, v49 @ V5, v50 @ V6, v51 @ V7\n\tX9 = &stack[10];\n\tgoto L_0050;\n\tX9 = &stack[8];\n\tgoto L_0050;\n\tX9 = &stack[0];\nL_0050:\n\tX10 = *([X9]);\n\tX11 = X20 & 0x3F;\n\tX11 = X26 << X11;\n\tX10 = X10 | X11;\n\t*([X9]) = X10;\nL_005B:\n\tgoto L_0082;\n\tgoto L_0082;\n\tgoto L_0082;\n\tgoto L_0082;\n\tv272 = v148 + 1;\n\tgoto L_0081;\n\tv276 = *([v271 @ X0_v9+E0]);\n\tv277 = v276 == 0;\n\tv278 = ~v277;\n\tif (v278) goto L_0081;\n\tv280 = \"il2cpp_codegen_runtime_class_init\"(v271, v143, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0081:\n\tv254 = Morpeh.ComponentsCleaner::Clean(v151[v148 @ X23_v4 (System.Int32)], v151[v272 @ X9_v14 (System.Int32)]);\nL_0082:\n\tv259 = v81 < 3;\n\tv221 = ~v259;\n\tv219 = v81 - 3;\n\tv215 = v219 == 0;\n\tv260 = ~v215;\n\tv205 = v221 & v260;\n\tif (v205) goto L_009E;\n\tv227 = *([v77 @ X25_v4 (System.Int32)+v81 @ X28_v4 (System.Int32)*4]) + v77;\n\t// 146 IndirectJump v227 @ X9_v7, v120 @ X0_v8 (Morpeh.Entity), v120 @ X0_v8 (Morpeh.Entity), v101 @ X1_v3 (Il2CppMethodInfo), v38 @ X2, v39 @ X3, v40 @ X4, v41 @ X5, v42 @ X6, v43 @ X7, v44 @ V0, v45 @ V1, v46 @ V2, v47 @ V3, v48 @ V4, v49 @ V5, v50 @ V6, v51 @ V7\n\tX8 = &stack[10];\n\tgoto L_0098;\n\tX8 = &stack[8];\n\tgoto L_0098;\n\tX8 = &stack[0];\nL_0098:\n\tX9 = *([X8]);\n\tX10 = X20 & 0x3F;\n\tX10 = X26 << X10;\n\tTEMP = ~X10;\n\tX9 = X9 & TEMP;\n\t*([X8]) = X9;\nL_009E:\n\tv148 = v148 + 2;\n\tv83 = v148 < v151.Length;\n\tif (v83) goto L_0036;\n\tgoto L_00B8;\n\tv167 = *([v129 @ X0_v3 (Il2CppClass<Morpeh.Utils.FastBitMask>)+E0]);\n\tv168 = v167 == 0;\n\tv169 = ~v168;\n\tif (v169) goto L_00B8;\n\tv198 = \"il2cpp_codegen_runtime_class_init\"(v129, v100, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv171 = Morpeh.Utils.FastBitMask;\nL_00B8:\n\tv174 = *([v170 @ X0_v4 (Il2CppClass<Morpeh.Utils.FastBitMask>)+B8]);\n\tv52.ComponentsMask = v174.None;\n\tv52.ComponentsMask.field2 = *([v174 @ X8_v7 (Il2CppStaticFields<Morpeh.Utils.FastBitMask>)+10]);\n\treturn;\n// 124 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Dispose()
		{
			//IL_0144: Expected I, but got O
			//IL_021b: Expected I, but got O
			//IL_023d: Expected I8, but got I
			//IL_0055: Expected O, but got I
			//IL_012c: Expected O, but got I
			int[] array = components;
			if (array.Length >= 1)
			{
				int num = 25444352 + 2144;
				int num2 = 25444352 + 2128;
				int num3 = 0;
				while (true)
				{
					int num4 = array[num3] >> 6;
					bool flag = num4 < 3;
					bool flag2 = !flag;
					int num5 = num4 - 3;
					bool flag3 = num5 == 0;
					bool flag4 = !flag3;
					if (!(flag2 && flag4))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ X27_v4 (System.Int32)+v81 @ X28_v4 (System.Int32)*4]");
						object obj = 0L + (long)num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v190 @ X10_v8 (should have been resolved before IL gen)");
					}
					bool flag5 = num4 < 3;
					bool flag6 = !flag5;
					int num6 = num4 - 3;
					bool flag7 = num6 == 0;
					bool flag8 = !flag7;
					if (!(flag6 && flag8))
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ X25_v4 (System.Int32)+v81 @ X28_v4 (System.Int32)*4]");
						object obj2 = 0L + (long)num;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v227 @ X9_v7 (should have been resolved before IL gen)");
						break;
					}
					num3 += 2;
					if (num3 < array.Length)
					{
						array = components;
						continue;
					}
					break;
				}
			}
			IntPtr intPtr = (IntPtr)typeof(FastBitMask);
			IntPtr intPtr2 = (IntPtr)FastBitMask.None;
			ComponentsMask = FastBitMask.None;
			ref FastBitMask componentsMask = ref ComponentsMask;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ X8_v7 (Il2CppStaticFields<Morpeh.Utils.FastBitMask>)+10]");
			componentsMask.field2 = 0uL;
		}

		[Token(Token = "0x6000023")]
		[Address(RVA = "0xBB3F00", Offset = "0xBB3F00", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = Il2CppMethodInfo;\n\tv3 = *([v2 @ X2_v1 (Il2CppMethodInfo)]);\n\t// 3 IndirectJump v3 @ X3_v1, this @ X0 (Morpeh.Entity), this @ X0 (Morpeh.Entity), value @ X1 (T&), methodof(Morpeh.Entity::SetComponent), v3 @ X3_v1, v6 @ X4, v7 @ X5, v8 @ X6, v9 @ X7, v10 @ V0, v11 @ V1, v12 @ V2, v13 @ V3, v14 @ V4, v15 @ V5, v16 @ V6, v17 @ V7\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		void IEntity.SetComponent<T>(in T value)
		{
			//IL_000e: Expected O, but got I
			IntPtr intPtr = (IntPtr)0;
			object obj = (long)intPtr;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v3 @ X3_v1 (should have been resolved before IL gen)");
		}

		[Token(Token = "0x6000024")]
		[Address(RVA = "0x15F5EE8", Offset = "0x15F5EE8", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = ~this.ComponentsMask;\n\tv5 = *([mask @ X1 (Morpeh.Utils.FastBitMask&)]) & v4;\n\tv6 = v5 == 0;\n\tv7 = ~v6;\n\tif (v7) goto L_0020;\n\tv10 = ~this.ComponentsMask.field1;\n\tv11 = *([mask @ X1 (Morpeh.Utils.FastBitMask&)+8]) & v10;\n\tv12 = v11 == 0;\n\tv13 = ~v12;\n\tif (v13) goto L_0020;\n\tv22 = ~this.ComponentsMask.field2;\n\tv19 = *([mask @ X1 (Morpeh.Utils.FastBitMask&)+10]) & v22;\n\tv23 = v19 == 0;\n\tv15 = ~v23;\n\tif (v15) goto L_0020;\n\tv44 = ~this.ComponentsMask.field3;\n\tv39 = *([mask @ X1 (Morpeh.Utils.FastBitMask&)+18]) & v44;\n\tv33 = v39 == 0;\n\treturn v33;\nL_0020:\n\treturn 0;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		bool IEntity.Has(in FastBitMask mask)
		{
			//IL_000b: Expected I4, but got O
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Expected I4, but got Unknown
			int num = (int)(~ComponentsMask);
			if ((int)(mask & num) == 0)
			{
				long num2 = (long)(~ComponentsMask.field1);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [mask @ X1 (Morpeh.Utils.FastBitMask&)+8]");
				long num3 = 0 & num2;
				if (num3 == 0)
				{
					long num4 = (long)(~ComponentsMask.field2);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [mask @ X1 (Morpeh.Utils.FastBitMask&)+10]");
					long num5 = 0 & num4;
					if (num5 == 0)
					{
						long num6 = (long)(~ComponentsMask.field3);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [mask @ X1 (Morpeh.Utils.FastBitMask&)+18]");
						long num7 = 0 & num6;
						return num7 == 0;
					}
				}
			}
			return false;
		}
	}
}
