using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Seeding
{
	[Token(Token = "0x200032D")]
	public sealed class MoldLayout
	{
		[Token(Token = "0x170000FF")]
		[field: Token(Token = "0x4000959")]
		[field: FieldOffset(Offset = "0x10")]
		public int Columns
		{
			[Token(Token = "0x6000D8E")]
			[Address(RVA = "0x3EF2874", Offset = "0x3EF2874", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Columns;\n")]
			get;
		}

		[Token(Token = "0x17000100")]
		[field: Token(Token = "0x400095A")]
		[field: FieldOffset(Offset = "0x14")]
		public int Rows
		{
			[Token(Token = "0x6000D8F")]
			[Address(RVA = "0x3EF287C", Offset = "0x3EF287C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Rows;\n")]
			get;
		}

		[Token(Token = "0x17000101")]
		[field: Token(Token = "0x400095B")]
		[field: FieldOffset(Offset = "0x18")]
		public IReadOnlyList<MoldCell> Cells
		{
			[Token(Token = "0x6000D90")]
			[Address(RVA = "0x3EF2884", Offset = "0x3EF2884", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Cells;\n")]
			get;
		}

		[Token(Token = "0x6000D91")]
		[Address(RVA = "0x3EEED04", Offset = "0x3EEED04", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.Cells = cells;\n\tthis.Columns = columns;\n\tthis.Rows = rows;\n\treturn;\n")]
		public MoldLayout(int columns, int rows, IReadOnlyList<MoldCell> cells)
		{
			Cells = cells;
			Columns = columns;
			Rows = rows;
		}

		[Token(Token = "0x6000D92")]
		[Address(RVA = "0x3EF288C", Offset = "0x3EF288C", Length = "0x2C4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002B;\n\tgoto L_0060;\n\tv172 = v279 + 0x20;\n\tv176 = 0;\n\tv396 = 0;\n\tv416 = *([v504 @ X8_v18 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.LevelGeneratorSystem.Seeding.MoldCell>>)+B0]) + 8;\n\tv416 = v416 + 0x10;\n\tv529 = v542 - 1;\n\tv511 = v542 != 1;\n\tv542 = v529;\n\tif (v511) goto L_007B;\nL_0094:\n\tv421 = System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.LevelGeneratorSystem.Seeding.MoldCell>::get_Count(v392);\n\tv397 = v176 < v421;\n\tif (v397) goto L_00B5;\n\tv134 = v279;\n\tgoto L_011F;\nL_00A3:\n\tv394 = *([v416 @ X10_v18]) << 4;\n\tv556 = v504 + v394;\n\tv557 = v556 + 0x138;\n\t*([v557 @ X0_v33])(v422, v392, *([v557 @ X0_v33+8]), v396, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv398 = v176 >= v422;\n\tv134 = v279;\n\tif (v398) goto L_011F;\nL_00B5:\n\tv180 = this.Cells;\n\tv561 = *([v180 @ X24_v8 (System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.LevelGeneratorSystem.Seeding.MoldCell>)]);\n\tv589 = *([v561 @ X8_v20 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.LevelGeneratorSystem.Seeding.MoldCell>>)+12E]);\n\tv563 = *([v561 @ X8_v20 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.LevelGeneratorSystem.Seeding.MoldCell>>)+12E]) == 0;\n\tif (v563) goto L_00DB;\n\tv260 = *([v561 @ X8_v20 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.LevelGeneratorSystem.Seeding.MoldCell>>)+B0]) + 8;\n\tv260 = v260 + 0x10;\n\tv576 = v589 - 1;\n\tv566 = v589 != 1;\n\tv589 = v576;\n\tif (v566) goto L_00C4;\nL_00DB:\n\tv396 = *([v579 @ X0_v23+8]);\n\tv278 = System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.LevelGeneratorSystem.Seeding.MoldCell>::get_Item(v180, v176);\n\tv592 = v279 == 0;\n\tv288 = ~v592;\n\tv270 = v176;\n\tif (v288) goto L_00F9;\n\tv172 = v9;\n\tv134 = this.Cells;\n\tgoto L_0102;\nL_00E4:\n\tv185 = *([v260 @ X10_v13]) << 4;\n\tv594 = v561 + v185;\n\tv595 = v594 + 0x138;\n\tv396 = *([v595 @ X0_v26+8]);\n\t*([v595 @ X0_v26])(v278, v180, v176, *([v595 @ X0_v26+8]), methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv270 = v176;\nL_00F9:\n\tv607 = v176 * 0xC;\n\tv292 = v172 + v607;\n\t*([v292 @ X8_v23]) = v278;\n\t*([v292 @ X8_v23+8]) = v270;\n\tv176 = v176 + 1;\n\tv392 = this.Cells;\n\tv608 = this.Cells == 0;\n\tv285 = ~v608;\n\tv134 = v279;\n\tif (v285) goto L_0070;\nL_0102:\n\tv300 = new System.NullReferenceException();\nL_011F:\n\tv479 = i * 0xC;\n\tv121 = v172 + v479;\n\tv130 = j * 0xC;\n\tv480 = v172 + v130;\n\t*([v121 @ X9_v4+8]) = *([v480 @ X8_v8+8]);\n\t*([v480 @ X8_v8]) = *([v480 @ X8_v8]);\n\t*([v480 @ X8_v8+8]) = *([v121 @ X9_v4+8]);\n\tv483 = new _game.CoreSystem.New.LevelGeneratorSystem.Seeding.MoldLayout();\n\tSystem.Object::.ctor(v483);\n\tv483.Columns = this.Columns;\n\tv483.Cells = v134;\n\tv135 = v483;\nL_0147:\n\treturn v135;\nL_002B:\n\tv65 = i == j;\n\tv135 = this;\n\tif (v65) goto L_0147;\nL_0060:\n\tv470 = System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.LevelGeneratorSystem.Seeding.MoldCell>::get_Count(this.Cells);\n\t// 101 NewArr v279 @ X0_v18 (_game.CoreSystem.New.LevelGeneratorSystem.Seeding.MoldCell[]), typeof(_game.CoreSystem.New.LevelGeneratorSystem.Seeding.MoldCell[]), v470 @ X0_v16 (System.Int32)\n\tv392 = this.Cells;\nL_007B:\n\tv547 = *([v416 @ X10_v18-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.LevelGeneratorSystem.Seeding.MoldCell>;\n\tif (v547) goto L_00A3;\nL_00C4:\n\tv232 = *([v260 @ X10_v13-8]) == System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.LevelGeneratorSystem.Seeding.MoldCell>;\n\tif (v232) goto L_00E4;\nL_0070:\n\tv504 = *([v392 @ X24_v7 (System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.LevelGeneratorSystem.Seeding.MoldCell>)]);\n\tv542 = *([v504 @ X8_v18 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.LevelGeneratorSystem.Seeding.MoldCell>>)+12E]);\n\tv424 = *([v504 @ X8_v18 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.LevelGeneratorSystem.Seeding.MoldCell>>)+12E]) == 0;\n\tif (v424) goto L_0094;\n")]
		public MoldLayout SwapColors(int i, int j)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldLayout::SwapColors");
			return default;
		}

		[Token(Token = "0x6000D93")]
		[Address(RVA = "0x3EF2B50", Offset = "0x3EF2B50", Length = "0x21C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tv189 = 0;\n\tv266 = *([v222 @ X8_v6 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.LevelGeneratorSystem.Seeding.MoldCell>>)+B0]) + 8;\n\tv266 = v266 + 0x10;\n\tv300 = v322 - 1;\n\tv299 = v322 != 1;\n\tv322 = v300;\n\tif (v299) goto L_0049;\nL_0062:\n\tv275 = System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.LevelGeneratorSystem.Seeding.MoldCell>::get_Count(v220);\n\tv235 = v189 < v275;\n\tif (v235) goto L_0083;\n\tgoto L_00D9;\nL_0071:\n\tv231 = *([v266 @ X10_v14]) << 4;\n\tv344 = v222 + v231;\n\tv345 = v344 + 0x138;\n\t*([v345 @ X0_v25])(v276, v220, *([v345 @ X0_v25+8]), v204, Il2CppMethodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv236 = v189 >= v276;\n\tif (v236) goto L_00D9;\nL_0083:\n\tv197 = this.Cells;\n\tv349 = *([v197 @ X22_v7 (System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.LevelGeneratorSystem.Seeding.MoldCell>)]);\n\tv369 = *([v349 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.LevelGeneratorSystem.Seeding.MoldCell>>)+12E]);\n\tv351 = *([v349 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.LevelGeneratorSystem.Seeding.MoldCell>>)+12E]) == 0;\n\tif (v351) goto L_00AC;\n\tv167 = *([v349 @ X8_v8 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.LevelGeneratorSystem.Seeding.MoldCell>>)+B0]) + 8;\n\tv167 = v167 + 0x10;\n\tv355 = v369 - 1;\n\tv354 = v369 != 1;\n\tv369 = v355;\n\tif (v354) goto L_0092;\nL_00AC:\n\tv180 = System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.LevelGeneratorSystem.Seeding.MoldCell>::get_Item(v197, v189);\n\tv380 = v57 == 0;\n\tv185 = ~v380;\n\tv386 = v189;\n\tif (v185) goto L_00C0;\n\tgoto L_00CC;\nL_00B2:\n\tv96 = *([v167 @ X10_v9]) << 4;\n\tv382 = v349 + v96;\n\tv383 = v382 + 0x138;\n\t*([v383 @ X0_v18])(v181, v197, v189, *([v383 @ X0_v18+8]), Il2CppMethodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv386 = v189;\nL_00C0:\n\tv394 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, System.Int32>::TryGetValue(v57, v386, &v87 @ stack_-54_v5 (System.Int32));\n\tv204 = v87 + 1;\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, System.Int32>::set_Item(v57, v386, v204);\n\tv188 = v189 + 1;\n\tv220 = this.Cells;\n\tv395 = this.Cells == 0;\n\tv183 = ~v395;\n\tv189 = v188;\n\tif (v183) goto L_003E;\nL_00CC:\n\tthrow System.NullReferenceException;\nL_00D9:\n\treturn v57;\nL_002D:\n\tv57 = new System.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, System.Int32>();\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.GameColor, System.Int32>::.ctor(v57);\n\tv220 = this.Cells;\nL_0049:\n\tv335 = *([v266 @ X10_v14-8]) == System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.LevelGeneratorSystem.Seeding.MoldCell>;\n\tif (v335) goto L_0071;\nL_0092:\n\tv143 = *([v167 @ X10_v9-8]) == System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.LevelGeneratorSystem.Seeding.MoldCell>;\n\tif (v143) goto L_00B2;\nL_003E:\n\tv222 = *([v220 @ X22_v6 (System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.LevelGeneratorSystem.Seeding.MoldCell>)]);\n\tv322 = *([v222 @ X8_v6 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.LevelGeneratorSystem.Seeding.MoldCell>>)+12E]);\n\tv224 = *([v222 @ X8_v6 (Il2CppClass<System.Collections.Generic.IReadOnlyList`1<_game.CoreSystem.New.LevelGeneratorSystem.Seeding.MoldCell>>)+12E]) == 0;\n\tif (v224) goto L_0062;\n")]
		public IReadOnlyDictionary<GameColor, int> CountByColor()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldLayout::CountByColor");
			return default;
		}
	}
}
