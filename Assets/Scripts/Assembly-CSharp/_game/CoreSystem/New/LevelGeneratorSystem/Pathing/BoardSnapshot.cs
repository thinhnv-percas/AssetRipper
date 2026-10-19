using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.CoreSystem.New.GridEcsBinding;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Pathing
{
	[Token(Token = "0x2000357")]
	public sealed class BoardSnapshot
	{
		[Token(Token = "0x40009D7")]
		[FieldOffset(Offset = "0x18")]
		internal readonly Dictionary<GridCoord, BoardCell> _byCoord;

		[Token(Token = "0x1700010A")]
		[field: Token(Token = "0x40009D6")]
		[field: FieldOffset(Offset = "0x10")]
		public IReadOnlyList<BoardCell> Cells
		{
			[Token(Token = "0x6000DFB")]
			[Address(RVA = "0x3F00E50", Offset = "0x3F00E50", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Cells;\n")]
			get;
		}

		[Token(Token = "0x6000DFC")]
		[Address(RVA = "0x3F00E58", Offset = "0x3F00E58", Length = "0x4BC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = *([B78E9BE]) & 1;\n\tv25 = v24 == 0;\n\tif (v25) goto L_0039;\n\tSystem.Object::.ctor(this);\n\tv48 = cells == 0;\nL_FFFFFFFF:\n\tv285 = 0;\n\tif (v48) goto L_0048;\nL_0019:\n\tv66 = this == 0;\n\tv67 = ~v66;\nL_FFFFFFFF:\n\tv93 = cells;\n\tif (v67) goto L_0061;\n\tgoto L_01AF;\nL_0039:\n\t*([B78E9BE]) = 1;\n\tSystem.Object::.ctor(this);\n\tv447 = cells == 0;\n\tv63 = ~v447;\nL_FFFFFFFF:\n\tv285 = 0;\n\tif (v63) goto L_0019;\nL_0048:\n\tgoto L_0049;\nL_0049:\n\tv100 = Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.Pathing.BoardCell>>;\n\tv103 = *([v100 @ X0_v74 (Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.Pathing.BoardCell>>)+135]) & 1;\n\tv104 = v103 == 0;\nL_FFFFFFFF:\n\tv226 = Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.Pathing.BoardCell>>;\n\tif (v104) goto L_019D;\nL_0051:\n\tgoto L_0059;\nL_0059:\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv93 = v92.Value;\nL_0061:\n\tthis.Cells = v93;\n\tgoto L_0098;\n\tgoto L_00D4;\n\tv465 = &v836 @ stack_-60_v9 (_game.CoreSystem.New.GridEcsBinding.GridCoord);\nL_FFFFFFFF:\n\tv801 = v719;\n\tgoto L_013F;\n\t*([v465 @ X23_v8+C]) = *([v465 @ X23_v8+C]);\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, _game.CoreSystem.New.LevelGeneratorSystem.Pathing.BoardCell>::set_Item(this._byCoord, v836, &v836 @ stack_-60_v9 (_game.CoreSystem.New.GridEcsBinding.GridCoord));\n\tv941 = v200 == 0;\n\tv776 = ~v941;\nL_FFFFFFFF:\n\tv801 = v200;\n\tif (v776) goto L_00E7;\nL_0152:\n\tv782 = new System.NullReferenceException();\nL_FFFFFFFF:\n\t;\n\tgoto L_01AE;\nL_0155:\n\tv505 = &v200 @ stack_-68_v7 (System.Collections.Generic.IEnumerator`1<_game.CoreSystem.New.LevelGeneratorSystem.Pathing.BoardCell>);\n\tv510 = *([v505 @ X8_v31]);\n\tv503 = *([v505 @ X8_v31]) == 0;\nL_FFFFFFFF:\n\tv448 = &v200 @ stack_-68_v7 (System.Collections.Generic.IEnumerator`1<_game.CoreSystem.New.LevelGeneratorSystem.Pathing.BoardCell>);\nL_FFFFFFFF:\n\tv119 = 0;\nL_FFFFFFFF:\n\tv508 = 0;\nL_FFFFFFFF:\n\tv237 = &v200 @ stack_-68_v7 (System.Collections.Generic.IEnumerator`1<_game.CoreSystem.New.LevelGeneratorSystem.Pathing.BoardCell>);\nL_FFFFFFFF:\n\tv119 = 0;\nL_FFFFFFFF:\n\tv285 = 0;\nL_FFFFFFFF:\n\tv302 = 0;\n\tif (v503) goto L_0186;\nL_015F:\n\tgoto L_0185;\n\treturn;\n\tv106 = System.Array::Empty();\n\tv219 = Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.Pathing.BoardCell>>;\n\tv232 = *([v219 @ X0_v67 (Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.Pathing.BoardCell>>)+135]) & 1;\n\tv233 = v232 == 0;\n\tv221 = ~v233;\nL_FFFFFFFF:\n\tv226 = Il2CppClass<System.EmptyArray`1<_game.CoreSystem.New.LevelGeneratorSystem.Pathing.BoardCell>>;\n\tif (v221) goto L_0051;\nL_019D:\n\tv229 = 0x220C238(v226, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv332 = *([v229 @ X0_v64+E4]) == 0;\n\tv318 = ~v332;\n\tif (v318) goto L_0059;\n\tgoto L_01AA;\nL_01AA:\n\tgoto L_FFFFFFFF;\nL_01AB:\n\tv838 = new System.NullReferenceException();\n\tgoto L_01AE;\nL_01AE:\n\t// 430 Interrupt\nL_FFFFFFFF:\n\tv237 = &v200 @ stack_-68_v7 (System.Collections.Generic.IEnumerator`1<_game.CoreSystem.New.LevelGeneratorSystem.Pathing.BoardCell>);\nL_FFFFFFFF:\n\tv119 = 0;\nL_01B1:\n\tv306 = new System.OutOfMemoryException();\n\tgoto L_01C0;\nL_01C0:\n\tv389 = v285 != 1;\n\tif (v389) goto L_01CE;\n\tv414 = 0x8BF5BC4(v306, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv508 = *([v414 @ X0_v12]);\n\tv437 = 0x8BF5BF4(v414, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv510 = *([v237 @ stack_-88_v3]);\n\tv443 = *([v237 @ stack_-88_v3]) == 0;\n\tv444 = ~v443;\nL_FFFFFFFF:\n\tv448 = v237;\nL_FFFFFFFF:\n\tv119 = *([v414 @ X0_v12]);\n\tif (v444) goto L_015F;\nL_FFFFFFFF:\n\tv119 = *([v414 @ X0_v12]);\nL_FFFFFFFF:\n\tv302 = *([v414 @ X0_v12]);\n\tgoto L_0186;\nL_01CE:\n\tv417 = 0x3175484(&v119 @ stack_-90 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv439 = 0x8BF0368(v306, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv445 = 0xA1B8(v439, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\nL_01AF:\n\tthrow System.NullReferenceException;\nL_0098:\n\tv428 = System.Collections.Generic.IReadOnlyCollection`1<_game.CoreSystem.New.LevelGeneratorSystem.Pathing.BoardCell>::get_Count(this.Cells);\n\tv431 = new System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, _game.CoreSystem.New.LevelGeneratorSystem.Pathing.BoardCell>();\n\tSystem.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, _game.CoreSystem.New.LevelGeneratorSystem.Pathing.BoardCell>::.ctor(v431, v428);\n\tthis._byCoord = v431;\nL_00D4:\n\tv719 = System.Collections.Generic.IEnumerable`1<_game.CoreSystem.New.LevelGeneratorSystem.Pathing.BoardCell>::GetEnumerator(this.Cells);\n\tv722 = v719 == 0;\nL_FFFFFFFF:\n\t;\n\tif (v722) goto L_0152;\nL_010D:\n\tv497 = System.Collections.IEnumerator::MoveNext(v801);\n\tv873 = v497 == 0;\n\tif (v873) goto L_0155;\nL_013F:\n\tv939 = System.Collections.Generic.IEnumerator`1<_game.CoreSystem.New.LevelGeneratorSystem.Pathing.BoardCell>::get_Current(v200);\n\tv840 = this._byCoord == 0;\n\tif (v840) goto L_01AB;\nL_00E7:\n\tgoto L_010D;\nL_0186:\n\tv536 = v302 == 0;\n\tv296 = ~v536;\n\tif (v296) goto L_01B1;\nL_0185:\n\tSystem.IDisposable::Dispose(v510);\nL_FFFFFFFF:\n\tv237 = v448;\nL_FFFFFFFF:\n\tv285 = 0;\nL_FFFFFFFF:\n\tv302 = v508;\n")]
		public unsafe BoardSnapshot(IReadOnlyList<BoardCell> cells)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BoardSnapshot::.ctor");
		}

		[Token(Token = "0x6000DFD")]
		[Address(RVA = "0x3F01314", Offset = "0x3F01314", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\nL_002C:\n\treturnVal1 = System.Collections.Generic.Dictionary`2<_game.CoreSystem.New.GridEcsBinding.GridCoord, _game.CoreSystem.New.LevelGeneratorSystem.Pathing.BoardCell>::TryGetValue(this._byCoord, v48, v46);\n\treturn returnVal1;\n")]
		public bool TryGet(GridCoord coord, out BoardCell cell)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BoardSnapshot::TryGet");
			cell = default;
			return default;
		}
	}
}
