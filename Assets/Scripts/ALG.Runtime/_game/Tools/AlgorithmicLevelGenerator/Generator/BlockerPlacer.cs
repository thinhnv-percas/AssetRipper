using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.Tools.AlgorithmicLevelGenerator.Solver;

namespace _game.Tools.AlgorithmicLevelGenerator.Generator
{
	[Token(Token = "0x200002F")]
	public static class BlockerPlacer
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x2000030")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x40000F8")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x40000F9")]
			public static Func<MoldCellSlot, bool> _003C_003E9__0_0;

			[Token(Token = "0x40000FA")]
			public static Func<int, int> _003C_003E9__1_1;

			[Token(Token = "0x600006F")]
			[Address(RVA = "0x3C108AC", Offset = "0x3C108AC", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\treturn;\nL_0014:\n\tv40 = new _game.Tools.AlgorithmicLevelGenerator.Generator.BlockerPlacer+<>c();\n\tSystem.Object::.ctor(v40);\n\tv44.<>9 = v40;\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000070")]
			[Address(RVA = "0x3C10910", Offset = "0x3C10910", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec()
			{
			}

			internal bool _003CPlaceHidden_003Eb__0_0(MoldCellSlot s)
			{
				bool flag = s.Color == SolverColor.None;
				return !flag;
			}

			internal int _003CPlaceLinked_003Eb__1_1(int r)
			{
				return r;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000031")]
		private sealed class _003C_003Ec__DisplayClass1_0
		{
			[Token(Token = "0x40000FB")]
			[FieldOffset(Offset = "0x10")]
			public Dictionary<int, List<int>> colsByRow;

			[Token(Token = "0x40000FC")]
			[FieldOffset(Offset = "0x18")]
			public Dictionary<int, HashSet<int>> usedColsByRow;

			[Token(Token = "0x6000073")]
			[Address(RVA = "0x3C0EAB8", Offset = "0x3C0EAB8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec__DisplayClass1_0()
			{
			}

			internal bool _003CPlaceLinked_003Eb__0(int r)
			{
				int key = default(int);
				List<int> list = colsByRow[key];
				int num = list.Count - 1;
				bool flag = num < 0;
				bool flag2 = num == 0;
				int num2 = list.Count ^ 1;
				int num3 = list.Count ^ num;
				int num4 = num2 & num3;
				bool flag3 = num4 < 0;
				bool flag4 = flag == flag3;
				bool flag5 = !flag2;
				return flag4 && flag5;
			}

			internal int _003CPlaceLinked_003Eb__2(int r)
			{
				int key = default(int);
				List<int> list = colsByRow[key];
				int num = list.Count >> 31;
				int num2 = list.Count + num;
				return num2 >> 1;
			}

			internal int _003CPlaceLinked_003Eb__3(int r)
			{
				int key = default(int);
				List<int> list = colsByRow[key];
				int num = list.Count >> 31;
				int num2 = list.Count + num;
				return num2 >> 1;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000032")]
		private sealed class _003C_003Ec__DisplayClass1_1
		{
			[Token(Token = "0x40000FD")]
			[FieldOffset(Offset = "0x10")]
			public int r;

			[Token(Token = "0x40000FE")]
			[FieldOffset(Offset = "0x18")]
			public _003C_003Ec__DisplayClass1_0 CS_0024_003C_003E8__locals1;

			[Token(Token = "0x6000077")]
			[Address(RVA = "0x3C0EAC0", Offset = "0x3C0EAC0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec__DisplayClass1_1()
			{
			}

			internal bool _003CPlaceLinked_003Eb__4(int c)
			{
				_003C_003Ec__DisplayClass1_0 _003C_003Ec__DisplayClass1_3 = CS_0024_003C_003E8__locals1;
				HashSet<int> hashSet = _003C_003Ec__DisplayClass1_3.usedColsByRow[r];
				bool flag = hashSet.Contains(c);
				return (byte)((flag ? 1u : 0u) ^ 1u) != 0;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000033")]
		private sealed class _003C_003Ec__DisplayClass1_2
		{
			[Token(Token = "0x40000FF")]
			[FieldOffset(Offset = "0x10")]
			public int colA;

			[Token(Token = "0x4000100")]
			[FieldOffset(Offset = "0x14")]
			public int colB;

			[Token(Token = "0x4000101")]
			[FieldOffset(Offset = "0x18")]
			public _003C_003Ec__DisplayClass1_1 CS_0024_003C_003E8__locals2;

			[Token(Token = "0x6000079")]
			[Address(RVA = "0x3C0EAC8", Offset = "0x3C0EAC8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec__DisplayClass1_2()
			{
			}

			internal bool _003CPlaceLinked_003Eb__5(MoldCellSlot s)
			{
				if (s.Col == colA)
				{
					_003C_003Ec__DisplayClass1_1 _003C_003Ec__DisplayClass1_3 = CS_0024_003C_003E8__locals2;
					int num = s.Row - _003C_003Ec__DisplayClass1_3.r;
					return num == 0;
				}
				return false;
			}

			internal bool _003CPlaceLinked_003Eb__6(MoldCellSlot s)
			{
				if (s.Col == colB)
				{
					_003C_003Ec__DisplayClass1_1 _003C_003Ec__DisplayClass1_3 = CS_0024_003C_003E8__locals2;
					int num = s.Row - _003C_003Ec__DisplayClass1_3.r;
					return num == 0;
				}
				return false;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000034")]
		private sealed class _003C_003Ec__DisplayClass2_0
		{
			[Token(Token = "0x4000102")]
			[FieldOffset(Offset = "0x10")]
			public int row;

			[Token(Token = "0x600007C")]
			[Address(RVA = "0x3C0F090", Offset = "0x3C0F090", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec__DisplayClass2_0()
			{
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000035")]
		private sealed class _003C_003Ec__DisplayClass2_1
		{
			[Token(Token = "0x4000103")]
			[FieldOffset(Offset = "0x10")]
			public int c;

			[Token(Token = "0x4000104")]
			[FieldOffset(Offset = "0x18")]
			public _003C_003Ec__DisplayClass2_0 CS_0024_003C_003E8__locals1;

			[Token(Token = "0x600007D")]
			[Address(RVA = "0x3C0F098", Offset = "0x3C0F098", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
			public _003C_003Ec__DisplayClass2_1()
			{
			}

			internal bool _003CChooseColumnPair_003Eb__0(MoldCellSlot s)
			{
				if (s.Col == c)
				{
					_003C_003Ec__DisplayClass2_0 _003C_003Ec__DisplayClass2_2 = CS_0024_003C_003E8__locals1;
					int num = s.Row - _003C_003Ec__DisplayClass2_2.row;
					return num == 0;
				}
				return false;
			}
		}

		[Token(Token = "0x6000067")]
		[Address(RVA = "0x3C0D660", Offset = "0x3C0D660", Length = "0x2B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0041;\n\tv76 = new System.Random();\n\tSystem.Random::.ctor(v76, seed);\n\tgoto L_005A;\n\tgoto L_0068;\nL_0079:\n\tv260 = System.Linq.Enumerable::Where(slots, v255);\n\tv273 = System.Linq.Enumerable::ToList(v260);\n\tgoto L_008B;\nL_008B:\n\tv315 = System.Math::Min(hiddenCount, v273.Count);\n\tv377 = v273.Count;\n\tv317 = v273.Count - 1;\n\tv294 = v317 < 1;\n\tif (v294) goto L_00D3;\n\tSystem.Collections.Generic.List`1<System.Object>::set_Item(v273, v384, v397);\n\tv404 = v356 < 1;\n\tv348 = ~v404;\n\tv346 = v356 - 1;\n\tv342 = v346 == 0;\n\tv405 = ~v342;\n\tv332 = v348 & v405;\n\tv377 = v356;\n\tif (v332) goto L_00A1;\nL_00D3:\n\tv88 = v315 < 1;\n\tif (v88) goto L_00F9;\n\tv318 = 0;\n\t*([v127 @ X0_v20+1C]) = 1;\n\tv318 = v318 + 1;\n\tv87 = v315 != v318;\n\tif (v87) goto L_00DC;\nL_00F9:\n\treturn;\nL_0041:\n\tv67 = hiddenCount < 1;\n\tif (v67) goto L_00F9;\nL_005A:\n\tv233 = v231.<>9__0_0 == 0;\n\tv234 = ~v233;\n\tv255 = v231.<>9__0_0;\n\tif (v234) goto L_0079;\nL_0068:\n\tv271 = new System.Func`2<_game.Tools.AlgorithmicLevelGenerator.Generator.MoldCellSlot, System.Boolean>();\n\tSystem.Func`2<_game.Tools.AlgorithmicLevelGenerator.Generator.MoldCellSlot, System.Boolean>::.ctor(v271, v266.<>9, Il2CppMethodInfo);\n\tv285.<>9__0_0 = v271;\n\tv255 = v271;\nL_00A1:\n\tv356 = v377 - 1;\n\tv384 = System.Random::Next(v76, v377);\n\tv388 = System.Collections.Generic.List`1<System.Object>::get_Item(v273, v384);\n\tv397 = System.Collections.Generic.List`1<System.Object>::get_Item(v273, v356);\n\tSystem.Collections.Generic.List`1<System.Object>::set_Item(v273, v356, v388);\nL_00DC:\n\tv127 = System.Collections.Generic.List`1<System.Object>::get_Item(v273, v318);\n")]
		public static void PlaceHidden(List<MoldCellSlot> slots, int hiddenCount, int seed)
		{
			if (hiddenCount < 1)
			{
				return;
			}
			Random random = new Random(seed);
			bool flag = _003C_003Ec._003C_003E9__0_0 == null;
			bool flag2 = !flag;
			Func<object, bool> predicate = (Func<object, bool>)_003C_003Ec._003C_003E9__0_0;
			if (!flag2)
			{
				predicate = (Func<object, bool>)(_003C_003Ec._003C_003E9__0_0 = delegate(MoldCellSlot s)
				{
					bool flag8 = s.Color == SolverColor.None;
					return !flag8;
				});
			}
			IEnumerable<object> source = slots.Where(predicate);
			List<object> list = source.ToList();
			int num = Math.Min(hiddenCount, list.Count);
			int num2 = list.Count;
			int num3 = list.Count - 1;
			if (num3 >= 1)
			{
				bool flag7;
				do
				{
					int num4 = num2 - 1;
					int index = random.Next(num2);
					object value = list[index];
					object value2 = list[num4];
					list[num4] = value;
					list[index] = value2;
					bool flag3 = (uint)num4 < 1u;
					bool flag4 = !flag3;
					int num5 = num4 - 1;
					bool flag5 = num5 == 0;
					bool flag6 = !flag5;
					flag7 = flag4 && flag6;
					num2 = num4;
				}
				while (flag7);
			}
			if (num >= 1)
			{
				int num6 = 0;
				do
				{
					object obj = list[num6];
					_ = 1;
					num6++;
				}
				while (num != num6);
			}
		}

		[Token(Token = "0x6000068")]
		[Address(RVA = "0x3C0D910", Offset = "0x3C0D910", Length = "0x11A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_00D4;\n\tSystem.Collections.Generic.List`1<System.Int32[][]>::.ctor(v81);\n\tv91 = slots == 0;\n\tif (v91) goto L_0537;\n\tv105 = linkedPairCount < 1;\n\tif (v105) goto L_0537;\n\tv319 = slots.Count == 0;\n\tif (v319) goto L_0537;\n\tv371 = new System.Random();\n\tSystem.Random::.ctor(v371, seed);\n\tv383 = new System.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<System.Int32>>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<System.Int32>>::.ctor(v383);\n\tv394 = v71 == 0;\n\tv469 = linkedPairCount;\n\tv592 = Il2CppMethodInfo;\n\tv527 = seed;\n\tif (v394) goto L_0544;\n\tv527 = v71 + 0x10;\n\tv71.colsByRow = v383;\n\tv539 = System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Generator.MoldCellSlot>::GetEnumerator(slots);\n\tv550 = v539.Current;\n\tv553 = v539._list;\n\tgoto L_0136;\n\tv662 = v539.Current == 0;\n\tif (v662) goto L_0538;\n\tv627 = v550.Row < 1;\n\tif (v627) goto L_0136;\n\tv703 = v71.colsByRow == 0;\n\tif (v703) goto L_053E;\n\tv715 = System.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<System.Int32>>::TryGetValue(v71.colsByRow, v550.Row, &v714 @ stack_-88_v7 (System.Collections.Generic.List`1<System.Int32>));\n\tv990 = v715 == 0;\n\tv991 = ~v990;\n\tv870 = v550.Row;\n\tif (v991) goto L_0164;\n\tv1003 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v1003);\n\tv870 = v550.Row;\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<System.Int32>>::set_Item(v71.colsByRow, v550.Row, v1003);\n\tv714 = v1003;\nL_0164:\n\tv952 = v1003 == 0;\n\tif (v952) goto L_053C;\n\tv659 = System.Collections.Generic.List`1<System.Int32>::Contains(v1003, v550.Col);\n\tv1030 = v659 == 0;\n\tv663 = ~v1030;\n\tif (v663) goto L_0136;\n\tv1042 = v1003 == 0;\n\tif (v1042) goto L_0540;\n\tv1075 = v1003._version + 1;\n\tv1003._version = v1075;\n\tv661 = v1003._items == 0;\n\tif (v661) goto L_0540;\n\tgoto L_018A;\nL_018A:\n\tSystem.Collections.Generic.List`1<System.Int32>::Add(v1003, v550.Col);\n\tgoto L_0136;\nL_0190:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v553 @ stack_-80_v6 (System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Generator.MoldCellSlot>));\n\tv459 = &v553 @ stack_-80_v6 (System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Generator.MoldCellSlot>);\n\tv237 = 0;\n\tv252 = linkedPairCount;\n\tv592 = Il2CppMethodInfo;\nL_0194:\n\tv508 = v527.m_value == 0;\n\tv469 = v252;\n\tif (v508) goto L_0544;\n\tv707 = System.Collections.Generic.Dictionary`2<System.Int32, System.Object>::get_Keys(v527.m_value);\n\tv985 = new System.Func`2<System.Int32, System.Boolean>();\n\tSystem.Func`2<System.Int32, System.Boolean>::.ctor(v985, v71, Il2CppMethodInfo);\n\tv1078 = System.Linq.Enumerable::Where(v707, v985);\n\tgoto L_01B3;\nL_01B3:\n\tv1049 = v1031.<>9__1_1;\n\tv1033 = v1031.<>9__1_1 == 0;\n\tv1034 = ~v1033;\n\tv343 = v985;\n\tif (v1034) goto L_01E2;\n\tgoto L_01C6;\nL_01C6:\n\tgoto L_01CF;\n\tv1049 = v1097;\n\tv343 = v1097;\n\tv320 = v314.Count == 0;\n\tif (v320) goto L_0537;\n\tv1116 = new System.Func`2<System.Int32, System.Int32>();\n\tSystem.Func`2<System.Int32, System.Int32>::.ctor(v1116, v71, Il2CppMethodInfo);\n\tv1133 = System.Linq.Enumerable::Sum(v314, v1116);\n\tgoto L_020B;\nL_020B:\n\tv505 = System.Math::Min(v252, v1133);\n\tv1224 = v314.Count;\n\tv520 = v314.Count - 1;\n\tv473 = v520 < 1;\n\tv1163 = v314;\n\tif (v473) goto L_024E;\n\tv510 = v371 == 0;\n\tv469 = v252;\n\tv592 = v314.Count;\n\tv527 = v343;\n\tif (v510) goto L_0544;\n\tv1213 = v371;\n\tSystem.Collections.Generic.List`1<System.Int32>::set_Item(v314, v1230, v1246);\n\tv1286 = v1186 < 1;\n\tv1179 = ~v1286;\n\tv1178 = v1186 - 1;\n\tv1176 = v1178 == 0;\n\tv1287 = ~v1176;\n\tv1171 = v1179 & v1287;\n\tv1163 = v314;\n\tv1213 = v371;\n\tv1224 = v1186;\n\tif (v1171) goto L_0222;\nL_024E:\n\tv1196 = new System.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.HashSet`1<System.Int32>>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.HashSet`1<System.Int32>>::.ctor(v1196);\n\tv71.usedColsByRow = v1196;\n\tv1250 = &v237 @ stack_-B8 (System.Int32);\n\tv1252 = System.Collections.Generic.List`1<System.Int32>::GetEnumerator(v1163);\n\tv145 = v237.m_value;\n\tv528 = 0xB2AA000 + 0x730;\n\tv1293 = new System.Collections.Generic.HashSet`1<System.Int32>();\n\tSystem.Collections.Generic.HashSet`1<System.Int32>::.ctor(v1293);\n\tv951 = v71.usedColsByRow == 0;\n\tif (v951) goto L_053A;\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.HashSet`1<System.Int32>>::set_Item(v71.usedColsByRow, *([v1250 @ X8_v51+10]), v1293);\n\tgoto L_0277;\nL_028E:\n\tSystem.Collections.Generic.List`1<System.Int32>+Enumerator<System.Int32>::Dispose(&v145 @ stack_-A0_v8 (System.Collections.Generic.List`1<System.Int32>+Enumerator<System.Int32>));\n\tv1304 = new System.Func`2<System.Int32, System.Int32>();\n\tSystem.Func`2<System.Int32, System.Int32>::.ctor(v1304, v71, Il2CppMethodInfo);\n\tv315 = System.Linq.Enumerable::Max(v314, v1304);\n\tv257 = v315 < 1;\n\tif (v257) goto L_0537;\n\tv511 = v81 == 0;\n\tv459 = &v145 @ stack_-A0_v8 (System.Collections.Generic.List`1<System.Int32>+Enumerator<System.Int32>);\n\tv237 = 0;\n\tv469 = v315;\n\tv592 = v1304;\n\tv527 = v528;\n\tif (v511) goto L_0544;\n\tv181 = 0xB297000 + 0xC48;\n\tv528 = 0;\n\tv1356 = System.Collections.Generic.List`1<System.Int32>::GetEnumerator(v314);\n\tv145 = v1356;\n\tv1392 = new *([v181 @ X28_v12 (System.Int32)])();\n\tSystem.Object::.ctor(v1392);\n\tv914 = v1392 == 0;\n\tif (v914) goto L_0487;\n\t*([v1392 @ X0_v72 (System.Object)+18]) = v71;\n\t*([v1392 @ X0_v72 (System.Object)+10]) = v1356.Current;\n\tv1429 = new _game.Tools.AlgorithmicLevelGenerator.Generator.BlockerPlacer+<>c__DisplayClass1_2();\n\tSystem.Object::.ctor(v1429);\n\tv915 = v1429 == 0;\n\tif (v915) goto L_0489;\n\tv1429.CS$<>8__locals2 = v1392;\n\tv772 = v81.Count >= v505;\n\tif (v772) goto L_0478;\n\tv959 = v1429.CS$<>8__locals2;\n\tv917 = v1429.CS$<>8__locals2 == 0;\n\tif (v917) goto L_048D;\n\tv725 = v959.CS$<>8__locals1;\n\tv919 = v959.CS$<>8__locals1 == 0;\n\tif (v919) goto L_0491;\n\tv916 = v725.usedColsByRow == 0;\n\tif (v916) goto L_048B;\n\tv1371 = System.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.HashSet`1<System.Int32>>::get_Item(v725.usedColsByRow, v959.r);\n\tv918 = v1371 == 0;\n\tif (v918) goto L_048F;\n\tv750 = v1371.Count >> 0x1F;\n\tv1376 = v1371.Count + v750;\n\tv773 = v528 != v1376;\n\tif (v773) goto L_02D5;\n\tv960 = v1429.CS$<>8__locals2;\n\tv920 = v1429.CS$<>8__locals2 == 0;\n\tif (v920) goto L_0493;\n\tv726 = v960.CS$<>8__locals1;\n\tv921 = v960.CS$<>8__locals1 == 0;\n\tif (v921) goto L_0495;\n\tv922 = v726.colsByRow == 0;\n\tif (v922) goto L_0497;\n\tv1372 = System.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<System.Int32>>::get_Item(v726.colsByRow, v960.r);\n\tv923 = v1372 == 0;\n\tif (v923) goto L_0499;\n\tv751 = v1372.Count >> 0x1F;\n\tv1377 = v1372.Count + v751;\n\tv774 = v528 >= v1377;\n\tif (v774) goto L_02D5;\n\tv962 = v1429.CS$<>8__locals2;\n\tv927 = v1429.CS$<>8__locals2 == 0;\n\tif (v927) goto L_04A1;\n\tv727 = v962.CS$<>8__locals1;\n\tv924 = v962.CS$<>8__locals1 == 0;\n\tif (v924) goto L_049B;\n\tv928 = v727.colsByRow == 0;\n\tif (v928) goto L_04A3;\n\tv1447 = System.Collections.Generic.Dictionary`2<System.Int32, System.Collections.Generic.List`1<System.Int32>>::get_Item(v727.colsByRow, v962.r);\n\tv1452 = new System.Func`2<System.Int32, System.Boolean>();\n\tSystem.Func`2<System.Int32, System.Boolean>::.ctor(v1452, v1429.CS$<>8__locals2, Il2CppMethodInfo);\n\tv1463 = System.Linq.Enumerable::Where(v1447, v1452);\n\tv181 = 0xB297000 + 0xC48;\n\tv1373 = System.Linq.Enumerable::ToList(v1463);\n\tv925 = v1373 == 0;\n\tif (v925) goto L_049D;\n\tv775 = v1373.Count < 2;\n\tif (v775) goto L_02D5;\n\tv977 = v1429.CS$<>8__locals2;\n\tv948 = v1429.CS$<>8__locals2 == 0;\n\tif (v948) goto L_04CB;\n\tv1470 = _game.Tools.AlgorithmicLevelGenerator.Generator.BlockerPlacer::ChooseColumnPair(slots, v977.r, v1373, v371);\n\tv1429.colA = v1470;\n\tv970 = v1429.CS$<>8__locals2;\n\tv934 = v1429.CS$<>8__locals2 == 0;\n\tif (v934) goto L_04AF;\n\tv732 = v970.CS$<>8__locals1;\n\tv941 = v970.CS$<>8__locals1 == 0;\n\tif (v941) goto\n// ... truncated")]
		public unsafe static List<int[][]> PlaceLinked(List<MoldCellSlot> slots, int linkedPairCount, int seed)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BlockerPlacer::PlaceLinked");
			return default;
		}

		[Token(Token = "0x6000069")]
		[Address(RVA = "0x3C0EAD0", Offset = "0x3C0EAD0", Length = "0x5C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0050;\n\tv64.row = row;\n\tv82 = new System.Collections.Generic.Dictionary`2<System.Int32, _game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, _game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor>::.ctor(v82);\n\tv153 = System.Collections.Generic.List`1<System.Int32>::GetEnumerator(avail);\n\tv105 = v153;\n\tv163 = v82 == 0;\n\tif (v163) goto L_00B1;\nL_FFFFFFFF:\n\tv270 = v82;\n\tv191 = new _game.Tools.AlgorithmicLevelGenerator.Generator.BlockerPlacer+<>c__DisplayClass2_1();\n\tSystem.Object::.ctor(v191);\n\tv194 = v191 == 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv250 = v82;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv124 = 0;\nL_FFFFFFFF:\n\tv387 = 0;\n\tif (v194) goto L_01AC;\n\tv191.CS$<>8__locals1 = v64;\n\tv191.c = v153.Current;\n\tv546 = new System.Func`2<_game.Tools.AlgorithmicLevelGenerator.Generator.MoldCellSlot, System.Boolean>();\n\tSystem.Func`2<_game.Tools.AlgorithmicLevelGenerator.Generator.MoldCellSlot, System.Boolean>::.ctor(v546, v191, Il2CppMethodInfo);\n\tv511 = System.Linq.Enumerable::First(slots, v546);\n\tv324 = v511 == 0;\n\tif (v324) goto L_01DF;\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, _game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor>::set_Item(v82, v153.Current, *([v511 @ X0_v89 (System.Object)+18]));\nL_FFFFFFFF:\n\tv270 = v82;\n\tgoto L_0087;\nL_00B1:\n\tv130 = System.Collections.Generic.List`1<System.Int32>+Enumerator<System.Int32>::MoveNext(&v105 @ stack_-80_v8 (System.Collections.Generic.List`1<System.Int32>+Enumerator<System.Int32>));\n\tv328 = ~v130;\n\tv132 = ~v328;\nL_FFFFFFFF:\n\tv270 = v82;\n\tif (v132) goto L_01A5;\nL_00B9:\n\tSystem.Collections.Generic.List`1<System.Int32>+Enumerator<System.Int32>::Dispose(&v105 @ stack_-80_v8 (System.Collections.Generic.List`1<System.Int32>+Enumerator<System.Int32>));\nL_FFFFFFFF:\n\tv595 = avail;\nL_FFFFFFFF:\n\tv250 = v82;\n\tv547 = v270 == 0;\n\tif (v547) goto L_0170;\n\tv609 = rng == 0;\n\tif (v609) goto L_0188;\nL_FFFFFFFF:\n\tv729 = 0;\nL_FFFFFFFF:\n\tv804 = 0xFFFFFFFF80000000;\nL_FFFFFFFF:\n\tv810 = v495;\nL_FFFFFFFF:\n\tv812 = v519;\n\tgoto L_00EB;\nL_00E9:\n\tv560 = v742 >= v613;\nL_FFFFFFFF:\n\tv729 = v742;\nL_FFFFFFFF:\n\tv804 = v611;\nL_FFFFFFFF:\n\tv810 = v618;\nL_FFFFFFFF:\n\tv812 = v620;\n\tif (v560) goto L_0191;\nL_00EB:\n\tv742 = v729 + 1;\n\tv754 = v742 < v613;\nL_FFFFFFFF:\n\tv789 = v742;\n\tif (v754) goto L_0111;\nL_FFFFFFFF:\n\tv611 = v804;\nL_FFFFFFFF:\n\tv618 = v810;\nL_FFFFFFFF:\n\tv620 = v812;\n\tgoto L_00E9;\nL_FFFFFFFF:\n\tv804 = v871;\nL_FFFFFFFF:\n\tv810 = v818;\nL_FFFFFFFF:\n\tv812 = v837;\nL_0111:\n\tv818 = System.Collections.Generic.List`1<System.Int32>::get_Item(v595, v729);\n\tv837 = System.Collections.Generic.List`1<System.Int32>::get_Item(v595, v789);\n\tv847 = System.Collections.Generic.Dictionary`2<System.Int32, _game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor>::get_Item(v250, v818);\n\tv854 = System.Collections.Generic.Dictionary`2<System.Int32, _game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor>::get_Item(v250, v837);\n\tv865 = v847 != v854;\n\tif (v865) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv794 = 0;\n\tgoto L_0139;\nL_FFFFFFFF:\n\tv794 = 0x64;\n\tv883 = v871 != v804;\n\tif (v883) goto L_00FE;\n\tv889 = v818 < v810;\n\tif (v889) goto L_FFFFFFFF;\n\tv885 = v818 != v810;\n\tif (v885) goto L_FFFFFFFF;\n\tv932 = v837 - v812;\n\tv908 = v932 < 0;\n\tv935 = v837 ^ v812;\n\tv936 = v837 ^ v932;\n\tv937 = v935 & v936;\n\tv893 = v937 < 0;\n\tgoto L_0168;\nL_FFFFFFFF:\n\tv893 = 0;\nL_FFFFFFFF:\n\tv908 = 0;\n\tgoto L_00FE;\nL_0170:\n\tv575 = v595.Count == 1;\nL_FFFFFFFF:\n\tv618 = v495;\nL_FFFFFFFF:\n\tv620 = v519;\n\tif (v575) goto L_0191;\n\tv713 = System.Collections.Generic.List`1<System.Int32>::get_Item(v595, 0);\n\tv760 = System.Collections.Generic.List`1<System.Int32>::get_Item(v595, 1);\n\tthrow System.NullReferenceException;\nL_0188:\n\tv209 = v595.Count != 1;\nL_FFFFFFFF:\n\tv618 = v495;\nL_FFFFFFFF:\n\tv620 = v519;\n\tif (v209) goto L_01B1;\nL_0191:\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(&v627 @ stack_-68_v2 (System.ValueTuple`2<System.Int32, System.Int32>), v618, v620);\n\treturn v627;\nL_01A5:\n\tv191 = new _game.Tools.AlgorithmicLevelGenerator.Generator.BlockerPlacer+<>c__DisplayClass2_1();\n\tSystem.Object::.ctor(v191);\n\tv154 = v191 == 0;\n\tv155 = ~v154;\nL_FFFFFFFF:\n\tv387 = 0;\n\tif (v155) goto L_01C6;\nL_01AC:\n\tthrow v191;\nL_01B1:\n\tv758 = System.Collections.Generic.List`1<System.Int32>::get_Item(v595, 0);\n\tv822 = System.Collections.Generic.List`1<System.Int32>::get_Item(v595, 1);\n\tv842 = System.Collections.Generic.Dictionary`2<System.Int32, _game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor>::get_Item(v250, v758);\n\tv849 = System.Collections.Generic.Dictionary`2<System.Int32, _game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor>::get_Item(v250, v822);\n\tthrow System.NullReferenceException;\nL_01C6:\n\tv191.CS$<>8__locals1 = v64;\n\tv191.c = 0;\n\tv310 = new System.Func`2<_game.Tools.AlgorithmicLevelGenerator.Generator.MoldCellSlot, System.Boolean>();\n\tSystem.Func`2<_game.Tools.AlgorithmicLevelGenerator.Generator.MoldCellSlot, System.Boolean>::.ctor(v310, v191, Il2CppMethodInfo);\n\tv443 = System.Linq.Enumerable::First(slots, v310);\nL_01DF:\n\tv395 = new System.NullReferenceException();\n\tgoto L_01E2;\nL_01E2:\n\t// 482 Interrupt\n\tgoto L_01FB;\n\tv496 = 0x8BF5BC4(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv520 = 0x8BF5BF4(v496, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Int32>+Enumerator<System.Int32>::Dispose(&v105 @ stack_-80_v8 (System.Collections.Generic.List`1<System.Int32>+Enumerator<System.Int32>));\n\tv481 = *([v496 @ X0_v47]) == 0;\nL_FFFFFFFF:\n\tv595 = avail;\nL_FFFFFFFF:\n\tv270 = v250;\n\tif (v481) goto L_00C0;\n\tv500 = new System.OutOfMemoryException();\nL_FFFFFFFF:\n\tv124 = *([v496 @ X0_v47]);\nL_020C:\n\tv506 = 0x31762F8(&v124 @ stack_-98 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv522 = 0x8BF0368(v500, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = 0xA1B8(v522, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal1;\nL_0050:\n\tv64 = new _game.Tools.AlgorithmicLevelGenerator.Generator.BlockerPlacer+<>c__DisplayClass2_0();\n\tSystem.Object::.ctor(v64);\nL_0087:\n\tv327 = System.Collections.Generic.List`1<System.Int32>+Enumerator<System.Int32>::MoveNext(&v105 @ stack_-80_v8 (System.Collections.Generic.List`1<System.Int32>+Enumerator<System.Int32>));\n\tv420 = v327 == 0;\n\tif (v420) goto L_00B9;\nL_0139:\n\tv802 = System.Random::Next(rng, 0, 0x32);\n\tv871 = v802 + v794;\n\tv882 = v871 > v804;\n\tif (v882) goto L_FFFFFFFF;\nL_00FE:\n\tv789 = v789 + 1;\n\tv613 = v595.Count;\n\tv768 = v789 >= v595.Count;\nL_FFFFFFFF:\n\tv611 = v804;\nL_FFFFFFFF:\n\tv618 = v810;\nL_FFFFFFFF:\n\tv620 = v812;\n\tif (v768) goto L_00E9;\nL_0168:\n\tv943 = v908 == v893;\n\tv890 = ~v943;\n\tif (v890) goto L_FFFFFFFF;\nL_01FB:\n\tv459 = v387 != 1;\n\tif (v459) goto L_020C;\nL_00C0:\n\tv495 = System.Collections.Generic.List`1<System.Int32>::get_Item(v595, 0);\n\tv519 = System.Collections.Generic.List`1<System.Int32>::get_Item(v595, 1);\n\tv613 = v595.Count;\n\tv540 = v595.Count < 1;\nL_FFFFFFFF:\n\tv618 = v495;\nL_FFFFFFFF:\n\tv620 = v519;\n\tif (v540) goto L_0191;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static (int, int) ChooseColumnPair(List<MoldCellSlot> slots, int row, List<int> avail, Random rng)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BlockerPlacer::ChooseColumnPair");
			return default;
		}

		[Token(Token = "0x600006A")]
		[Address(RVA = "0x3C0F0A0", Offset = "0x3C0F0A0", Length = "0x940")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0078;\n\tgoto L_0091;\nL_0091:\n\tv386 = slots.Count + count;\n\tv427 = System.Math::Max(1, moldCols);\n\tv431 = slots.Count + v427;\n\tv432 = v431 - 1;\n\tv433 = v432 / v427;\n\tv436 = System.Math::Max(1, v433);\n\tv599 = System.Math::Max(1, shallowBias);\n\tv604 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v604);\n\tv342 = new System.Collections.Generic.List`1<System.Int64>();\n\tSystem.Collections.Generic.List`1<System.Int64>::.ctor(v342);\n\tv172 = v436 < 1;\n\tif (v172) goto L_FFFFFFFF;\n\tv634 = v427 - 1;\n\tv653 = v634 < 0;\n\tv637 = v427 ^ 1;\n\tv638 = v427 ^ v634;\n\tv639 = v637 & v638;\n\tv648 = v639 < 0;\n\tgoto L_00CC;\nL_FFFFFFFF:\n\tv648 = 0;\nL_FFFFFFFF:\n\tv653 = 1;\nL_00D5:\n\tv709 = new System.Random();\n\tSystem.Random::.ctor(v709, seed);\n\tv339 = new System.Collections.Generic.HashSet`1<System.Int32>();\n\tSystem.Collections.Generic.HashSet`1<System.Int32>::.ctor(v339);\n\tv353 = v604 == 0;\n\tif (v353) goto L_0273;\n\tv354 = v342 == 0;\n\tif (v354) goto L_0276;\n\tv992 = v709 == 0;\n\tif (v992) goto L_02B5;\n\tv1006 = v339.Count >= count;\nL_FFFFFFFF:\n\tv1048 = count;\n\tif (v1006) goto L_02C9;\nL_FFFFFFFF:\n\tv1049 = count;\n\tgoto L_0135;\nL_00FA:\n\tv83 = new System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Generator.MoldCellSlot>();\n\tSystem.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Generator.MoldCellSlot>::.ctor(v83, slots);\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv589 = moldCols;\nL_FFFFFFFF:\n\tv591 = v83;\n\tgoto L_03EA;\nL_0105:\n\tv1414 = System.Collections.Generic.List`1<System.Int64>::get_Item(v342, 0);\nL_FFFFFFFF:\n\tv1421 = 0;\n\tSystem.Collections.Generic.List`1<System.Int64>::RemoveAt(v342, v1421);\n\tv1007 = v339.Count >= v1049;\nL_FFFFFFFF:\n\tv1048 = v1049;\n\tif (v1007) goto L_02C9;\nL_0135:\n\tv1008 = v604.Count <= 0;\nL_FFFFFFFF:\n\tv1048 = v1049;\n\tif (v1008) goto L_02C9;\n\tv1233 = v342.Count < 1;\n\tif (v1233) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv1333 = 0;\nL_FFFFFFFF:\n\tv1335 = 0;\nL_FFFFFFFF:\n\tv1002 = v1335;\n\tgoto L_0160;\nL_FFFFFFFF:\n\tv1002 = 0;\n\tv1000 = v1000 * v1002;\n\tv1381 = v1000 == 0x7FF0000000000000;\n\tif (v1381) goto L_0105;\nL_FFFFFFFF:\n\tv1524 = 0;\nL_FFFFFFFF:\n\tv1526 = 0;\n\tv1524 = v1524 + 1;\n\tv1502 = v1524 < v604.Count;\n\tif (v1502) goto L_0182;\n\tgoto L_01A1;\nL_FFFFFFFF:\n\tv1421 = v1524;\nL_01A3:\n\tv355 = v604 == 0;\n\tif (v355) goto L_FFFFFFFF;\n\tv715 = v436 + 1;\n\tv716 = v599 & 0x7FFFFFFE;\nL_FFFFFFFF:\n\tv740 = v599;\nL_FFFFFFFF:\n\tv294 = v427;\nL_FFFFFFFF:\n\tv331 = v427;\nL_FFFFFFFF:\n\tv398 = 1;\n\tgoto L_01CE;\nL_01B2:\n\tv398 = v398 + 1;\n\tv331 = v331 + v427;\n\tv668 = v398 > v436;\nL_FFFFFFFF:\n\tv740 = v599;\nL_FFFFFFFF:\n\tv294 = v427;\n\tif (v668) goto L_00D5;\nL_01CE:\n\tv758 = v740 < 1;\n\tif (v758) goto L_FFFFFFFF;\n\tv776 = v715 - v398;\n\tv787 = v740 != 1;\n\tif (v787) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv862 = 0;\nL_FFFFFFFF:\n\tv958 = 1;\n\tgoto L_0201;\nL_FFFFFFFF:\n\tv380 = 1;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv874 = 1;\nL_FFFFFFFF:\n\tv875 = v716;\nL_FFFFFFFF:\n\tv877 = 1;\nL_FFFFFFFF:\n\tv874 = v117;\nL_FFFFFFFF:\n\tv875 = v126;\nL_FFFFFFFF:\n\tv877 = v153;\n\tv958 = v874 * v877;\n\tv844 = v740 == v716;\nL_FFFFFFFF:\n\tv862 = v716;\nL_FFFFFFFF:\n\tv380 = v958;\n\tif (v844) goto L_FFFFFFFF;\nL_0201:\n\tv948 = v740 - v862;\nL_FFFFFFFF:\n\tv948 = v153;\nL_FFFFFFFF:\n\tv958 = v23;\nL_FFFFFFFF:\n\tv286 = v331;\n\tgoto L_022B;\nL_022B:\n\tv177 = v286 >= v386;\n\tif (v177) goto L_0216;\n\tgoto L_024B;\nL_024B:\n\tSystem.Collections.Generic.List`1<System.Int32>::Add(v604, v286);\n\tgoto L_0267;\nL_0267:\n\tSystem.Collections.Generic.List`1<System.Int64>::Add(v342, v380);\n\tgoto L_0216;\nL_0273:\n\tv178 = v339.Count >= count;\nL_FFFFFFFF:\n\tv1048 = count;\n\tif (v178) goto L_02C9;\n\tgoto L_0415;\nL_0276:\n\tv993 = v339.Count >= count;\nL_FFFFFFFF:\n\tv1048 = count;\n\tif (v993) goto L_02C9;\n\tv179 = v604.Count <= 0;\nL_FFFFFFFF:\n\tv1048 = count;\n\tif (v179) goto L_02C9;\n\tgoto L_0415;\nL_FFFFFFFF:\n\tv157 = v427;\nL_FFFFFFFF:\n\tv370 = 1;\n\tv130 = v130 + 1;\n\tv662 = v121 - 1;\n\tv791 = v121 != 1;\nL_FFFFFFFF:\n\tv121 = v662;\n\tif (v791) goto L_0295;\n\tv370 = v370 + 1;\n\tv157 = v157 + v427;\n\tv669 = v370 <= v436;\n\tif (v669) goto L_FFFFFFFF;\n\tgoto L_00D5;\nL_02B5:\n\tv1009 = v339.Count >= count;\nL_FFFFFFFF:\n\tv1048 = count;\n\tif (v1009) goto L_02C9;\n\tv1005 = v604.Count > 0;\nL_FFFFFFFF:\n\tv1048 = count;\nL_FFFFFFFF:\n\tv408 = v342;\n\tif (v1005) goto L_03FE;\nL_02C9:\n\tv1074 = v427 * v436;\n\tv1137 = v427 + v1074;\n\tv1085 = v1137 >= v386;\n\tif (v1085) goto L_02F8;\n\tv1131 = System.Collections.Generic.HashSet`1<System.Int32>::Add(v339, v1137);\n\tv1137 = v1137 + 1;\n\tv1098 = v1137 < v386;\n\tif (v1098) goto L_02E2;\nL_02F8:\n\tv1485 = new System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Generator.MoldCellSlot>();\n\tSystem.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Generator.MoldCellSlot>::.ctor(v1485, v386);\n\tv1216 = v386 < 1;\n\tif (v1216) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv1483 = 0;\nL_FFFFFFFF:\n\tv400 = 0;\n\tgoto L_0327;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv1481 = v343;\nL_0319:\n\tv400 = v400 + 1;\n\tv1274 = v386 == v400;\nL_FFFFFFFF:\n\tv334 = v1483;\n\tif (v1274) goto L_0391;\nL_0327:\n\tv1292 = System.Collections.Generic.HashSet`1<System.Int32>::Contains(v339, v400);\n\tv1374 = ~v1292;\n\tif (v1374) goto L_035A;\n\tv343 = new _game.Tools.AlgorithmicLevelGenerator.Generator.MoldCellSlot();\n\t_game.Tools.AlgorithmicLevelGenerator.Generator.MoldCellSlot::.ctor(v343);\n\tv343.Color = 0;\n\tv343.IsHammer = 1;\n\tv1564 = v1485._version + 1;\n\tv1485._version = v1564;\n\tv159 = v1485._items;\n\tv1582 = v1485.Count;\n\tv1584 = v1485.Count < v159.Length;\n\tv1585 = ~v1584;\n\tif (v1585) goto L_FFFFFFFF;\n\tv1603 = v1485.Count + 1;\n\tv1485.Count = v1603;\n\tv159[v1582 @ X10_v28 (System.Int32)] = v343;\nL_FFFFFFFF:\n\t;\n\tgoto L_0380;\nL_035A:\n\tv182 = v1483 >= slots.Count;\nL_FFFFFFFF:\n\t;\n\tif (v182) goto L_0319;\n\tv344 = System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Generator.MoldCellSlot>::get_Item(slots, v1483);\n\tv1549 = v1485._version + 1;\n\tv1485._version = v1549;\n\tv160 = v1485._items;\n\tv1483 = v1483 + 1;\n\tv1567 = v1485.Count;\n\tv1569 = v1485.Count < v160.Length;\n\tv1570 = ~v1569;\n\tif (v1570) goto L_FFFFFFFF;\n\tv1593 = v1485.Count + 1;\n\tv1485.Count = v1593;\n\tv160[v1567 @ X10_v27 (System.Int32)] = v344;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv1481 = v344;\n\tgoto L_0318;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv334 = 0;\n\tv1200 = v1485 == 0;\n\tif (v1200) goto L_03F1;\n\tgoto L_03AF;\nL_03A0:\n\tSystem.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Generator.MoldCellSlot>::Add(v1485, v345);\n\tv334 = v334 + 1;\n\tv552 = slots.Count == v334;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv589 = moldCols;\nL_FFFFFFFF:\n\tv591 = v1485;\n\tif (v552) goto L_03EA;\nL_03AF:\n\tv345 = System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Generator.MoldCellSlot>::get_Item(slots, v334);\n\tgoto L_03A0;\nL_FFFFFFFF:\n\tv589 = moldCols;\nL_FFFFFFFF:\n\tv591 = v1485;\nL_03F1:\n\tv1433 = System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Generator.MoldCellSlot>::get_Item(slots, v334);\n\tv1199 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv408 = slots.Count;\nL_03FE:\n\tv184 = v408.Count < 1;\n\tif (v184) goto L_0415;\nL_FFFFFFFF:\n\tv1263 = 0;\nL_0415:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\nL_0078:\n\tv76 = count <= 0;\n\tif (v76) goto L_00FA;\nL_00CC:\n\tv656 = v653 == v648;\n\tif (v656) goto L_01A3;\nL_03EA:\n\treturnVal2 = _game.Tools.AlgorithmicLevelGenerator.Generator.BlockerPlacer::Renumber(v591, v589);\n\treturn returnVal2;\nL_0149:\n\tv1330 = System.Collections.Generic.List`1<System.Int64>::get_Item(v342, v1333);\n\tv1335 = v1330 + v1335;\n\tv1333 = v1333 + 1;\n\tv1308 = v1333 < v342.Count;\n\tif (v1308) goto L_0149;\nL_0160:\n\tv1357 = System.Random::NextDouble(v709);\n\tv1421 = v604.Count - 1;\n\tv1371 = v604.Count <= 0;\n\tif (v1371) goto L_010A;\nL_0182:\n\tv1415 = System.Collections.Generic.List`1<System.Int64>::get_Item(v342, v1524);\n\tv1526 = v1415 + v1526;\n\tv1545 = v1526 >= v1000;\n\tif (v1545) goto L_FFFFFFFF;\nL_01A1:\n\t;\nL_FFFFFFFF:\n\tv1049 = count;\n\tgoto L_010A;\nL_01E6:\n\tv877 = v877 * v776;\n\tv874 = v874 * v776;\n\tv876 = v875 - 2;\n\tv829 = v875 != 2;\nL_FFFFFFFF:\n\tv875 = v876;\n\tif (v829) goto L_01E6;\nL_0202:\n\tv380 = v958 * v776;\n\tv825 = v948 - 1;\n\tv828 = v948 != 1;\nL_FFFFFFFF:\n\tv948 = v825;\nL_FFFFFFFF:\n\tv\n// ... truncated")]
		public static List<MoldCellSlot> PlaceHammers(List<MoldCellSlot> slots, int count, int moldCols, int seed, int shallowBias)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BlockerPlacer::PlaceHammers");
			return default;
		}

		[Token(Token = "0x600006B")]
		[Address(RVA = "0x3C0F9E0", Offset = "0x3C0F9E0", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\nL_0027:\n\tv62 = slots.Count < 1;\n\tif (v62) goto L_0056;\n\tv73 = 0 - moldCols;\n\tv113 = 0;\n\tv71 = v113 / moldCols;\n\tv182 = v73 * v71;\n\tv111 = v113 + v182;\n\tv104.Col = v111;\n\tv105 = System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Generator.MoldCellSlot>::get_Item(slots, v113);\n\tv105.Row = v71;\n\tv113 = v113 + 1;\n\tv123 = v113 < slots.Count;\n\tif (v123) goto L_0030;\nL_0056:\n\treturn slots;\nL_0030:\n\tv104 = System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Generator.MoldCellSlot>::get_Item(slots, v113);\n")]
		private static List<MoldCellSlot> Renumber(List<MoldCellSlot> slots, int moldCols)
		{
			if (slots.Count >= 1)
			{
				int num = -moldCols;
				int num2 = 0;
				do
				{
					MoldCellSlot moldCellSlot = slots[num2];
					int num3 = num2 / moldCols;
					int num4 = num * num3;
					int col = num2 + num4;
					moldCellSlot.Col = col;
					MoldCellSlot moldCellSlot2 = slots[num2];
					moldCellSlot2.Row = num3;
					num2++;
				}
				while (num2 < slots.Count);
			}
			return slots;
		}

		[Token(Token = "0x600006C")]
		[Address(RVA = "0x3C0FAAC", Offset = "0x3C0FAAC", Length = "0x2C8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tgoto L_004B;\n\tv347 = v251;\n\tv349 = 0;\n\tgoto L_00B3;\n\tv332 = v342.Counter - v349;\n\tv330 = v332 < 0;\n\tv328 = v332 == 0;\n\tv326 = v342.Counter ^ v349;\n\tv324 = v342.Counter ^ v332;\n\tv322 = v326 & v324;\n\tv320 = v322 < 0;\n\tv651 = v330 == v320;\n\tv312 = ~v328;\n\tv318 = v651 & v312;\n\tv311 = ~v318;\n\tif (v311) goto L_00CA;\n\tv349 = v342.Counter;\n\tgoto L_00CA;\nL_00CD:\n\tv378 = new System.NullReferenceException();\n\tgoto L_0110;\nL_00D0:\n\tv472 = &v54 @ stack_-38_v2 (System.Collections.Generic.IEnumerator`1<_game.Tools.AlgorithmicLevelGenerator.Solver.ParsedHammerArea>);\n\tv482 = *([v472 @ X8_v17]);\n\tv474 = *([v472 @ X8_v17]) == 0;\n\tv480 = 0;\n\tv504 = 0;\n\tv480 = 0;\n\tv114 = 0;\n\tv122 = 0;\n\tif (v474) goto L_0101;\nL_00DA:\n\tgoto L_0100;\nL_010C:\n\treturn v123;\nL_010D:\n\tv454 = new System.NullReferenceException();\n\tgoto L_0110;\nL_0110:\n\t// 272 Interrupt\nL_0114:\n\tv590 = new System.OutOfMemoryException();\n\tgoto L_0123;\nL_0123:\n\tv176 = v114 != 1;\n\tif (v176) goto L_0132;\n\tv653 = 0x8BF5BC4(v590, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv504 = *([v653 @ X0_v24]);\n\tv499 = 0x8BF5BF4(v653, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv503 = &v54 @ stack_-38_v2 (System.Collections.Generic.IEnumerator`1<_game.Tools.AlgorithmicLevelGenerator.Solver.ParsedHammerArea>);\n\tv482 = *([v503 @ X8_v19]);\n\tv661 = *([v503 @ X8_v19]) == 0;\n\tv501 = ~v661;\n\tv480 = *([v653 @ X0_v24]);\n\tif (v501) goto L_00DA;\n\tv480 = *([v653 @ X0_v24]);\n\tv122 = *([v653 @ X0_v24]);\n\tgoto L_0101;\n\treturn returnVal2;\nL_001D:\n\tv43 = areas == 0;\n\tv123 = areas;\n\tif (v43) goto L_010C;\nL_004B:\n\tv251 = System.Collections.Generic.IEnumerable`1<_game.Tools.AlgorithmicLevelGenerator.Solver.ParsedHammerArea>::GetEnumerator(areas);\n\tv54 = v251;\n\tv254 = v251 == 0;\n\tif (v254) goto L_0112;\nL_0082:\n\tv468 = System.Collections.IEnumerator::MoveNext(v347);\n\tv470 = v468 == 0;\n\tif (v470) goto L_00D0;\nL_00B3:\n\tv342 = System.Collections.Generic.IEnumerator`1<_game.Tools.AlgorithmicLevelGenerator.Solver.ParsedHammerArea>::get_Current(v251);\n\tv456 = v342 == 0;\n\tif (v456) goto L_010D;\nL_00CA:\n\tv660 = v251 == 0;\n\tv344 = ~v660;\n\tv347 = v251;\n\tif (v344) goto L_005C;\nL_0101:\n\tv530 = v122 == 0;\n\tv118 = ~v530;\n\tv123 = v349;\n\tif (v118) goto L_0114;\nL_0100:\n\tSystem.IDisposable::Dispose(v482);\n\tv114 = 0;\n\tv122 = v504;\nL_0132:\n\tv655 = 0x3175484(&v480 @ stack_-48_v5 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv659 = 0x8BF0368(v590, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal2 = 0xA1B8(v659, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_0112:\n\tgoto L_00CD;\nL_005C:\n\tgoto L_0082;\n")]
		public static int HammerBudget(IReadOnlyList<ParsedHammerArea> areas)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BlockerPlacer::HammerBudget");
			return default;
		}

		[Token(Token = "0x600006D")]
		[Address(RVA = "0x3C0FD74", Offset = "0x3C0FD74", Length = "0x484")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tgoto L_005A;\nL_FFFFFFFF:\n\treturnVal1 = 2;\n\tgoto L_01AD;\n\tv200 = v318 == 0;\nL_FFFFFFFF:\n\treturnVal1 = 2;\n\tif (v200) goto L_01AD;\n\tgoto L_0097;\nL_FFFFFFFF:\n\tv140 = 0;\nL_FFFFFFFF:\n\tv501 = v403;\n\tgoto L_0101;\n\tgoto L_010F;\nL_010F:\n\tv843 = System.Math::Max(0, v807.SizeX);\n\tv494 = System.Math::Max(0, v807.SizeY);\n\tv863 = v494 * v843;\n\tv140 = v140 + v863;\n\tv864 = v403 == 0;\n\tv496 = ~v864;\nL_FFFFFFFF:\n\tv501 = v403;\n\tif (v496) goto L_00AA;\nL_011B:\n\tv531 = new System.NullReferenceException();\n\tgoto L_01B1;\nL_011F:\n\tv620 = &v111 @ stack_-68_v2 (System.Collections.Generic.IEnumerator`1<_game.Tools.AlgorithmicLevelGenerator.Solver.ParsedHammerArea>);\n\tv652 = *([v620 @ X8_v23]);\n\tv622 = *([v620 @ X8_v23]) == 0;\nL_FFFFFFFF:\n\tv628 = 0;\nL_FFFFFFFF:\n\tv630 = 6;\nL_FFFFFFFF:\n\tv654 = 0;\nL_FFFFFFFF:\n\tv628 = 0;\nL_FFFFFFFF:\n\tv138 = 6;\nL_FFFFFFFF:\n\tv193 = 0;\nL_FFFFFFFF:\n\tv210 = 0;\n\tif (v622) goto L_0150;\nL_0129:\n\tgoto L_014F;\n\tv169 = v138 == 6;\n\tif (v169) goto L_0166;\n\tv792 = v138 == 0;\n\tv201 = ~v792;\nL_FFFFFFFF:\n\treturnVal1 = v197;\n\tif (v201) goto L_01AD;\nL_0166:\n\tgoto L_016A;\nL_016A:\n\tv820 = v140 / cubeCount;\n\tv823 = System.Math::Min(1d, v820);\n\tgoto L_017B;\nL_0186:\n\tv132 = System.Math::Round(v128, 0, 1);\n\tv167 = v132 == 0x7FF0000000000000;\n\tv123 = ~v167;\n\tif (v123) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv870 = 0xFFFFFFFF80000000;\n\tgoto L_019B;\nL_FFFFFFFF:\n\tv870 = v132;\nL_01AD:\n\treturn returnVal1;\nL_01AE:\n\tv600 = new System.NullReferenceException();\n\tgoto L_01B1;\nL_01B1:\n\t// 433 Interrupt\nL_01B5:\n\tv749 = new System.OutOfMemoryException();\n\tgoto L_01C7;\nL_01C7:\n\tv267 = v193 != 1;\n\tif (v267) goto L_01D7;\n\tv835 = 0x8BF5BC4(v749, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv654 = *([v835 @ X0_v28]);\n\tv197 = 0x8BF5BF4(v835, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv651 = &v111 @ stack_-68_v2 (System.Collections.Generic.IEnumerator`1<_game.Tools.AlgorithmicLevelGenerator.Solver.ParsedHammerArea>);\n\tv652 = *([v651 @ X8_v25]);\n\tv862 = *([v651 @ X8_v25]) == 0;\n\tv649 = ~v862;\nL_FFFFFFFF:\n\tv628 = *([v835 @ X0_v28]);\nL_FFFFFFFF:\n\tv630 = 0;\n\tif (v649) goto L_0129;\nL_FFFFFFFF:\n\tv628 = *([v835 @ X0_v28]);\nL_FFFFFFFF:\n\tv138 = 0;\nL_FFFFFFFF:\n\tv210 = *([v835 @ X0_v28]);\n\tgoto L_0150;\n\treturn returnVal2;\nL_002A:\n\tv56 = areas == 0;\n\tif (v56) goto L_FFFFFFFF;\nL_005A:\n\tv318 = System.Collections.Generic.IReadOnlyCollection`1<_game.Tools.AlgorithmicLevelGenerator.Solver.ParsedHammerArea>::get_Count(areas);\n\tv151 = cubeCount < 1;\nL_FFFFFFFF:\n\treturnVal1 = 2;\n\tif (v151) goto L_01AD;\nL_0097:\n\tv403 = System.Collections.Generic.IEnumerable`1<_game.Tools.AlgorithmicLevelGenerator.Solver.ParsedHammerArea>::GetEnumerator(areas);\n\tv111 = v403;\n\tv406 = v403 == 0;\n\tif (v406) goto L_01B3;\nL_00D0:\n\tv197 = System.Collections.IEnumerator::MoveNext(v501);\n\tv617 = v197 == 0;\n\tif (v617) goto L_011F;\nL_0101:\n\tv807 = System.Collections.Generic.IEnumerator`1<_game.Tools.AlgorithmicLevelGenerator.Solver.ParsedHammerArea>::get_Current(v403);\n\tv602 = v807 == 0;\n\tif (v602) goto L_01AE;\nL_00AA:\n\tgoto L_00D0;\nL_0150:\n\tv688 = v210 == 0;\n\tv290 = ~v688;\n\tif (v290) goto L_01B5;\nL_014F:\n\tSystem.IDisposable::Dispose(v652);\nL_FFFFFFFF:\n\tv138 = v630;\nL_FFFFFFFF:\n\tv193 = 0;\nL_FFFFFFFF:\n\tv197 = v685;\nL_FFFFFFFF:\n\tv210 = v654;\nL_017B:\n\tv128 = v823 * 4d;\n\tgoto L_0186;\nL_019B:\n\tv873 = System.Math::Min(5, v870);\n\treturnVal1 = System.Math::Max(1, v873);\nL_01D7:\n\tv837 = 0x3175484(&v628 @ stack_-78_v5 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv854 = 0x8BF0368(v749, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal2 = 0xA1B8(v854, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\nL_01B3:\n\tgoto L_011B;\n")]
		public static int HammerShallowBias(IReadOnlyList<ParsedHammerArea> areas, int cubeCount)
		{
			//IL_0297: Expected I4, but got O
			//IL_02dd: Expected I4, but got O
			//IL_02fc: Expected I4, but got O
			//IL_030d: Expected I4, but got O
			//IL_0234: Expected I4, but got F8
			int result;
			IEnumerator<ParsedHammerArea> enumerator2;
			int num;
			bool flag3;
			IDisposable disposable;
			int num6;
			int num7;
			int num8;
			int num9;
			int num10;
			if (areas == null)
			{
				result = 2;
			}
			else
			{
				int count = areas.Count;
				bool flag = cubeCount < 1;
				result = 2;
				if (!flag)
				{
					bool flag2 = count == 0;
					result = 2;
					if (!flag2)
					{
						IEnumerator<ParsedHammerArea> enumerator = areas.GetEnumerator();
						enumerator2 = enumerator;
						if (enumerator != null)
						{
							num = 0;
							IEnumerator<ParsedHammerArea> enumerator3 = enumerator;
							while (true)
							{
								flag3 = enumerator3.MoveNext();
								if (!flag3)
								{
									break;
								}
								ParsedHammerArea current = enumerator.Current;
								if (current != null)
								{
									int num2 = Math.Max(0, current.SizeX);
									int num3 = Math.Max(0, current.SizeY);
									int num4 = num3 * num2;
									num += num4;
									bool flag4 = enumerator == null;
									bool flag5 = !flag4;
									enumerator3 = enumerator;
									if (flag5)
									{
										continue;
									}
								}
								else
								{
									NullReferenceException ex = new NullReferenceException();
								}
								goto IL_00dc;
							}
							object obj = enumerator2;
							disposable = (IDisposable)obj;
							bool flag6 = obj == null;
							int num5 = 0;
							num6 = 6;
							num7 = 0;
							num5 = 0;
							num8 = 6;
							num9 = 0;
							num10 = 0;
							if (flag6)
							{
								goto IL_03e6;
							}
							goto IL_040e;
						}
						goto IL_00dc;
					}
				}
			}
			goto IL_0239;
			IL_00dc:
			while (true)
			{
				NullReferenceException ex2 = new NullReferenceException();
			}
			IL_03e6:
			object obj2 = default(object);
			int result2 = default(int);
			while (num10 != 0)
			{
				OutOfMemoryException ex3 = new OutOfMemoryException();
				if (num9 == 1)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5BC4");
					num7 = (int)obj2;
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5BF4");
					object obj3 = enumerator2;
					disposable = (IDisposable)obj3;
					bool flag7 = obj3 == null;
					bool flag8 = !flag7;
					int num5 = (int)obj2;
					num6 = 0;
					if (flag8)
					{
						goto IL_040e;
					}
					num5 = (int)obj2;
					num8 = 0;
					num10 = (int)obj2;
					continue;
				}
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @3175484");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF0368");
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @A1B8");
				return result2;
			}
			if (num8 != 6)
			{
				bool flag9 = num8 == 0;
				bool flag10 = !flag9;
				result = (flag3 ? 1 : 0);
				if (flag10)
				{
					goto IL_0239;
				}
			}
			double val = (double)num / (double)cubeCount;
			double num11 = Math.Min(1.0, val);
			double value = num11 * 4.0;
			double num12 = Math.Round(value, 0, MidpointRounding.AwayFromZero);
			int val2 = ((num12 != 9.218868437227405E+18) ? ((int)num12) : (-2147483648));
			int val3 = Math.Min(5, val2);
			result = Math.Max(1, val3);
			goto IL_0239;
			IL_0239:
			return result;
			IL_040e:
			disposable.Dispose();
			num8 = num6;
			num9 = 0;
			bool flag11 = default(bool);
			flag3 = flag11;
			num10 = num7;
			goto IL_03e6;
		}

		[Token(Token = "0x600006E")]
		[Address(RVA = "0x3C101F8", Offset = "0x3C101F8", Length = "0x6B4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0058;\n\tv93 = t == 0;\nL_FFFFFFFF:\n\tv220 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv602 = v84;\n\tif (v93) goto L_020D;\n\tv98 = t.CubeSlots == 0;\nL_FFFFFFFF:\n\tv220 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv602 = v84;\n\tif (v98) goto L_020D;\n\tv258 = System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Generator.CubeSlot>::GetEnumerator(t.CubeSlots);\n\tv266 = v258.Current;\n\tv269 = v258._list;\n\tv276 = tapOrder == 0;\n\tif (v276) goto L_00CD;\n\tv291 = v84 == 0;\n\tif (v291) goto L_00ED;\n\tgoto L_008F;\nL_008C:\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Int32>::set_Item(v84, v822, v410);\nL_008F:\n\tv404 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v269 @ stack_-B0_v6 (System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Generator.CubeSlot>));\n\tv457 = v404 == 0;\n\tif (v457) goto L_0118;\n\tv417 = v266 + 0x38;\n\tv408 = v417.HasValue == 0;\n\tif (v408) goto L_008F;\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(&v537 @ stack_-98_v16 (System.ValueTuple`2<System.Int32, System.Int32>), v266.Col, v266.Row);\n\tv716 = System.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Int32>>::IndexOf(tapOrder, v537);\n\tv740 = v716 & 0x80000000;\n\tv741 = v740 == 0;\nL_FFFFFFFF:\n\tv410 = v716;\n\tif (v741) goto L_00AE;\n\tv410 = tapOrder.Count - 1;\n\tv405 = System.Collections.Generic.Dictionary`2<System.Int32, System.Int32>::get_Item(v84, v822);\n\tv363 = v410 >= v405;\n\tif (v363) goto L_008F;\n\tgoto L_008C;\n\tv328 = v266.CoverGroupId != 1;\n\tif (v328) goto L_00CD;\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(&v537 @ stack_-98_v16 (System.ValueTuple`2<System.Int32, System.Int32>), v266.Col, v266.Row);\n\tv587 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv186 = t;\nL_FFFFFFFF:\n\tv211 = &v269 @ stack_-B0_v6 (System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Generator.CubeSlot>);\nL_FFFFFFFF:\n\tv218 = 0;\nL_FFFFFFFF:\n\tv602 = v84;\n\tgoto L_020C;\n\tv420 = v266.CoverGroupId != 1;\n\tif (v420) goto L_00ED;\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(&v537 @ stack_-98_v16 (System.ValueTuple`2<System.Int32, System.Int32>), v266.Col, v266.Row);\n\tv721 = System.Collections.Generic.List`1<System.ValueTuple`2<System.Int32, System.Int32>>::IndexOf(tapOrder, v537);\n\tv744 = System.Nullable`1<System.Int32>::get_Value(&v266.CoverGroupId (System.Nullable`1<System.Int32>));\n\tv588 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv186 = t;\nL_FFFFFFFF:\n\tv211 = &v269 @ stack_-B0_v6 (System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Generator.CubeSlot>);\nL_FFFFFFFF:\n\tv218 = 0;\nL_FFFFFFFF:\n\tv221 = v530;\nL_FFFFFFFF:\n\tv602 = v84;\n\tgoto L_020C;\nL_0118:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v269 @ stack_-B0_v6 (System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Generator.CubeSlot>));\nL_FFFFFFFF:\n\tv186 = t;\nL_FFFFFFFF:\n\tv211 = &v269 @ stack_-B0_v6 (System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Generator.CubeSlot>);\nL_FFFFFFFF:\n\tv218 = 0;\nL_FFFFFFFF:\n\tv220 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv602 = v84;\nL_011B:\n\tv228 = v186.CubeSlots == 0;\n\tif (v228) goto L_020D;\n\tv607 = System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Generator.CubeSlot>::GetEnumerator(v186.CubeSlots);\n\tv579 = v607.Current;\n\tv269 = v607._list;\n\tv709 = v602 == 0;\n\tif (v709) goto L_01CF;\n\tgoto L_0149;\nL_0144:\n\tSystem.Nullable`1<System.Int32>::.ctor(&v893 @ stack_-98_v12 (System.Nullable`1<System.Int32>), 0);\nL_FFFFFFFF:\n\tv770 = v893;\nL_0146:\n\tv579.FrozenCoverCounter = v770;\n\tv830 = v607.Current == 0;\nL_FFFFFFFF:\n\t;\n\tif (v830) goto L_0209;\n\tv782 = v607.Current + 0x38;\n\tv785 = v782.HasValue == 0;\n\tif (v785) goto L_0149;\n\tv860 = v579.FrozenCoverCounter & 1;\n\tv861 = v860 == 0;\n\tv786 = ~v861;\n\tif (v786) goto L_0149;\n\tv866 = System.Nullable`1<System.Int32>::get_Value(v782);\n\tv873 = System.Collections.Generic.Dictionary`2<System.Int32, System.Int32>::get_Item(v602, v866);\n\tv788 = v873 - 1;\n\tv883 = v788 <= 0;\n\tif (v883) goto L_0144;\n\tgoto L_0179;\nL_0179:\n\tv898 = v78 * v873;\n\tv902 = 0x8BF6AF4(&v900 @ stack_-98_v7 (System.Double), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, v898, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv920 = v898 < 0;\n\tv924 = v898 == v898;\n\tv925 = ~v924;\n\tv926 = v920 == v925;\n\tif (v926) goto L_0194;\n\tv928 = v898 == -0.5d;\n\tv935 = ~v928;\n\tif (v935) goto L_01AC;\n\tv955 = v900 + -1d;\nL_FFFFFFFF:\n\tv914 = v900;\nL_FFFFFFFF:\n\tv964 = v900;\n\tgoto L_01A0;\nL_0194:\n\tv937 = v898 == 0.5d;\n\tv944 = ~v937;\n\tif (v944) goto L_01AF;\n\tv955 = v900 + 1d;\nL_FFFFFFFF:\n\tv914 = v900;\nL_FFFFFFFF:\n\tv964 = v900;\n\tgoto L_01AB;\nL_FFFFFFFF:\n\tv914 = v955;\nL_01AC:\n\tv948 = v898 + -0.5d;\n\tv914 = System.Math::Ceiling(v948);\n\tgoto L_01B4;\nL_01AF:\n\tv953 = v898 + 0.5d;\n\tv914 = System.Math::Floor(v953);\nL_01B4:\n\tv908 = v914 == 0x7FF0000000000000;\n\tv903 = ~v908;\n\tif (v903) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv987 = 0xFFFFFFFF80000000;\n\tgoto L_01C3;\nL_FFFFFFFF:\n\tv987 = v914;\nL_FFFFFFFF:\n\tv770 = v912;\n\tgoto L_0146;\nL_01CF:\n\tv601 = 0xB2A6000 + 0x78;\n\tv814 = v607.Current == 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv602 = v601;\n\tif (v814) goto L_0209;\n\tv545 = v579.CoverGroupId != 1;\n\tif (v545) goto L_01D2;\n\tv862 = v579.FrozenCoverCounter & 1;\n\tv863 = v862 == 0;\n\tv591 = ~v863;\n\tif (v591) goto L_01D2;\n\tv868 = v607.Current + 0x38;\n\tv869 = System.Nullable`1<System.Int32>::get_Value(v868);\n\tv589 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv186 = t;\nL_FFFFFFFF:\n\tv211 = &v269 @ stack_-B0_v6 (System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Generator.CubeSlot>);\nL_FFFFFFFF:\n\tv218 = 0;\nL_FFFFFFFF:\n\tv221 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv602 = v84;\n\tgoto L_020C;\nL_01F4:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v269 @ stack_-B0_v6 (System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Generator.CubeSlot>));\n\treturn;\nL_0209:\n\tv590 = new System.NullReferenceException();\nL_FFFFFFFF:\n\tv211 = &v269 @ stack_-B0_v6 (System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Generator.CubeSlot>);\nL_FFFFFFFF:\n\tv218 = 0;\nL_FFFFFFFF:\n\tv221 = Il2CppMethodInfo;\nL_FFFFFFFF:\n\tv602 = v601;\n\tgoto L_020C;\nL_020C:\n\t// 524 Interrupt\nL_FFFFFFFF:\n\tv220 = v221;\nL_0232:\n\tv287 = v220 != 1;\nL_FFFFFFFF:\n\tv306 = v250;\n\tif (v287) goto L_0244;\n\tv295 = 0x8BF5BC4(v250, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv357 = 0x8BF5BF4(v295, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(v211);\n\tv303 = *([v295 @ X0_v14]) == 0;\nL_FFFFFFFF:\n\tv218 = *([v295 @ X0_v14]);\nL_FFFFFFFF:\n\tv220 = Il2CppMethodInfo;\n\tif (v303) goto L_011B;\n\tv301 = new System.OutOfMemoryException();\nL_FFFFFFFF:\n\tv218 = *([v295 @ X0_v14]);\nL_FFFFFFFF:\n\tv306 = v301;\nL_0264:\n\tv452 = 0x8BF0368(v306, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv488 = 0xA1B8(v452, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_0058:\n\tv78 = _game.Tools.AlgorithmicLevelGenerator.Generator.DifficultyTuner::CoverCounterFactor(difficulty);\n\tv84 = new System.Collections.Generic.Dictionary`2<System.Int32, System.Int32>();\n\tSystem.Collections.Generic.Dictionary`2<System.Int32, System.Int32>::.ctor(v84);\nL_020D:\n\tv250 = new System.NullReferenceException();\n\tgoto L_0232;\nL_00AE:\n\tv822 = System.Nullabl\n// ... truncated")]
		public unsafe static void AssignCoverCounters(Template t, List<(int Col, int Row)> tapOrder, Difficulty difficulty)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BlockerPlacer::AssignCoverCounters");
		}
	}
}
