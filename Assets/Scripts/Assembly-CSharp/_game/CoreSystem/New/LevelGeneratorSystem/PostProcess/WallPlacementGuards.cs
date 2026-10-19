using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.LevelGeneratorSystem.Actions;

namespace _game.CoreSystem.New.LevelGeneratorSystem.PostProcess
{
	[Token(Token = "0x2000341")]
	public static class WallPlacementGuards
	{
		[Token(Token = "0x40009A3")]
		private static readonly (int dx, int dy)[] Cardinals;

		[Token(Token = "0x6000DCD")]
		[Address(RVA = "0x3EFA6E8", Offset = "0x3EFA6E8", Length = "0x3A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv378 = 0xB296000 + 0x748;\n\tgoto L_002A;\n\tv175 = v72.Cardinals + 0x20;\n\tv89 = actions == 0;\n\tif (v89) goto L_0192;\n\tv201 = v73.Length < 1;\n\tif (v201) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv446 = v72.Cardinals;\nL_FFFFFFFF:\n\tv129 = 0;\nL_FFFFFFFF:\n\tv279 = gridSize;\n\tgoto L_0059;\nL_004A:\n\tv129 = v129 + 1;\n\tv233 = v129 >= v446.Length;\n\tif (v233) goto L_FFFFFFFF;\nL_0059:\n\tv384 = v129 << 3;\n\tv385 = v175 + v384;\n\tv386 = *([v385 @ X8_v18]);\n\tv389 = *([v385 @ X8_v18]) + wall;\n\tv390 = *([v386 @ X8_v19+4]) + wall.y;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v113 @ stack_-70_v8 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v389, v390);\n\tv416 = *([v378 @ X22_v7 (System.Int32)]);\n\tv418 = *([v416 @ X0_v17+E4]) == 0;\n\tif (v418) goto L_006D;\n\tv422 = v113 & 0x80000000;\n\tv423 = v422 == 0;\n\tif (v423) goto L_0071;\n\tgoto L_004A;\nL_006D:\n\tv434 = v113 & 0x80000000;\n\tv435 = v434 == 0;\n\tv430 = ~v435;\n\tif (v430) goto L_004A;\nL_0071:\n\tv431 = v113 & 0x8000000000000000;\n\tv432 = v431 == 0;\n\tv433 = ~v432;\n\tif (v433) goto L_004A;\n\tv460 = v279 <= v113;\n\tif (v460) goto L_004A;\n\tv461 = gridSize.y <= v113.y;\n\tif (v461) goto L_004A;\n\tgoto L_00C3;\n\tv159 = v654 == 0;\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv159 = 1;\n\tv179 = *([v378 @ X22_v7 (System.Int32)]);\n\tgoto L_00E9;\n\tv694 = *([v91 @ X28_v6+18]) < 1;\n\tif (v694) goto L_FFFFFFFF;\n\tv540 = v91 + 0x20;\nL_FFFFFFFF:\n\tv523 = 0;\nL_FFFFFFFF:\n\tv279 = gridSize;\n\tgoto L_0118;\nL_0106:\n\tv524 = _game.CoreSystem.New.LevelGeneratorSystem.Actions.IGeneratorActions::IsCellOccupied(0, v442);\n\tv527 = ~v524;\nL_FFFFFFFF:\n\tv446 = v72.Cardinals;\nL_FFFFFFFF:\n\tv279 = gridSize;\nL_FFFFFFFF:\n\tv697 = v72.Cardinals;\nL_FFFFFFFF:\n\tv718 = gridSize;\n\tif (v527) goto L_004A;\nL_010B:\n\tv523 = v523 + 1;\n\tv703 = v523 >= *([v91 @ X28_v6+18]);\nL_FFFFFFFF:\n\tv446 = v697;\nL_FFFFFFFF:\n\tv279 = v718;\n\tif (v703) goto L_FFFFFFFF;\nL_0118:\n\tv458 = v523 << 3;\n\tv732 = v540 + v458;\n\tv733 = *([v732 @ X8_v33]);\n\tv452 = v113 + *([v732 @ X8_v33]);\n\tv544 = v654 + *([v733 @ X8_v34+4]);\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v442 @ stack_-80_v8 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v452, v544);\n\tgoto L_012A;\nL_012A:\n\tv739 = v442 & 0x80000000;\n\tv740 = v739 == 0;\n\tv528 = ~v740;\n\tif (v528) goto L_004A;\n\tv741 = v442 & 0x8000000000000000;\n\tv742 = v741 == 0;\n\tv529 = ~v742;\n\tif (v529) goto L_004A;\n\tv464 = v279 <= v442;\n\tif (v464) goto L_004A;\n\tv465 = gridSize.y <= v442.y;\n\tif (v465) goto L_004A;\n\tv759 = v442 != wall;\n\tif (v759) goto L_016E;\n\tv766 = v761 == wall.y;\nL_FFFFFFFF:\n\tv697 = v446;\nL_FFFFFFFF:\n\tv718 = v279;\n\tif (v766) goto L_010B;\nL_016E:\n\tgoto L_0106;\nL_0192:\n\tv203 = v73.Length < 1;\n\tif (v203) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv189 = 0;\n\tgoto L_01A3;\nL_0196:\n\tv189 = v189 + 1;\n\tv234 = v189 >= v73.Length;\n\tif (v234) goto L_FFFFFFFF;\nL_01A3:\n\tv119 = v189 << 3;\n\tv411 = v175 + v119;\n\tv412 = *([v411 @ X8_v11]);\n\tv109 = *([v411 @ X8_v11]) + wall;\n\tv197 = *([v412 @ X8_v12+4]) + wall.y;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v113 @ stack_-70_v8 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v109, v197);\n\tgoto L_01B1;\nL_01B1:\n\tv425 = v113 & 0x80000000;\n\tv426 = v425 == 0;\n\tif (v426) goto L_01BA;\n\tgoto L_0196;\nL_01BA:\n\tv438 = v113 & 0x8000000000000000;\n\tv439 = v438 == 0;\n\tv181 = ~v439;\n\tif (v181) goto L_0196;\n\tv550 = gridSize <= v113;\n\tif (v550) goto L_0196;\n\tv137 = gridSize.y <= v113.y;\n\tif (v137) goto L_0196;\n\tthrow System.NullReferenceException;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tgoto L_01EB;\nL_FFFFFFFF:\n\treturnVal1 = 1;\nL_002A:\n\tgoto L_002E;\nL_00C3:\n\tv526 = _game.CoreSystem.New.LevelGeneratorSystem.Actions.IGeneratorActions::IsCubeAt(actions, v113);\n\tv659 = v526 == 0;\n\tv139 = ~v659;\n\tv94 = ~v139;\n\tif (v94) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv279 = gridSize;\n\tif (v159) goto L_004A;\nL_00E9:\n\tv187 = *([v179 @ X0_v23+B8]);\n\tv91 = *([v187 @ X8_v29]);\nL_01EB:\n\treturn returnVal1;\nL_002E:\n\tv73 = v72.Cardinals;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool WouldBreakAdjacentPourability(IGeneratorActions actions, GridCoord wall, Vector2Int gridSize)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("WallPlacementGuards::WouldBreakAdjacentPourability");
			return default;
		}

		[Token(Token = "0x6000DCE")]
		[Address(RVA = "0x3EFCA18", Offset = "0x3EFCA18", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv15 = c < 0;\n\tif (v15) goto L_FFFFFFFF;\n\tv18 = size - c;\n\tv34 = v18 < 0;\n\tv33 = v18 == 0;\n\tv21 = size ^ c;\n\tv22 = size ^ v18;\n\tv23 = v21 & v22;\n\tv29 = v23 < 0;\n\tgoto L_001E;\nL_FFFFFFFF:\n\tv29 = 0;\nL_FFFFFFFF:\n\tv33 = 1;\nL_FFFFFFFF:\n\tv34 = 0;\n\tv43 = size.y - c.y;\n\tv59 = v43 < 0;\n\tv58 = v43 == 0;\n\tv46 = size.y ^ c.y;\n\tv47 = size.y ^ v43;\n\tv48 = v46 & v47;\n\tv54 = v48 < 0;\n\tgoto L_0032;\nL_FFFFFFFF:\n\tv54 = 0;\nL_FFFFFFFF:\n\tv58 = 1;\nL_FFFFFFFF:\n\tv59 = 0;\nL_FFFFFFFF:\n\treturnVal1 = 0;\n\tgoto L_0042;\nL_FFFFFFFF:\n\treturnVal1 = v64;\nL_001E:\n\tv37 = v34 == v29;\n\tv38 = ~v33;\n\tv39 = v37 & v38;\n\tv40 = ~v39;\n\tif (v40) goto L_FFFFFFFF;\nL_0032:\n\tv62 = v59 == v54;\n\tv63 = ~v58;\n\tv64 = v62 & v63;\n\tv66 = c & 0xFFFFFFFF80000000;\n\tv68 = v66 == 0;\n\tv71 = ~v68;\n\tv72 = ~v71;\n\tif (v72) goto L_FFFFFFFF;\nL_0042:\n\treturn returnVal1;\n")]
		public static bool InBounds(GridCoord c, Vector2Int size)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("WallPlacementGuards::InBounds");
			return default;
		}

		[Token(Token = "0x6000DCF")]
		[Address(RVA = "0x3EFCA3C", Offset = "0x3EFCA3C", Length = "0x154")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\t*([v48 @ X0_v3 (System.ValueTuple`2<System.Int32, System.Int32>[])+20]) = v56;\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(&v117 @ stack_-40_v4 (System.ValueTuple`2<System.Int32, System.Int32>), 1, 0);\n\t*([v48 @ X0_v3 (System.ValueTuple`2<System.Int32, System.Int32>[])+28]) = v117;\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(&v126 @ stack_-48_v4 (System.ValueTuple`2<System.Int32, System.Int32>), 0, -1);\n\t*([v48 @ X0_v3 (System.ValueTuple`2<System.Int32, System.Int32>[])+30]) = v126;\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(&v120 @ stack_-50_v4 (System.ValueTuple`2<System.Int32, System.Int32>), 0, 1);\n\t*([v48 @ X0_v3 (System.ValueTuple`2<System.Int32, System.Int32>[])+38]) = v120;\n\tv197.Cardinals = v48;\n\treturn;\nL_001F:\n\t// 31 NewArr v48 @ X0_v3 (System.ValueTuple`2<System.Int32, System.Int32>[]), typeof(System.ValueTuple`2<System.Int32, System.Int32>[]), 4\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(&v56 @ stack_-38_v2 (System.ValueTuple`2<System.Int32, System.Int32>), -1, 0);\n")]
		static WallPlacementGuards()
		{
			(int, int)[] cardinals = new(int, int)[4];
			(int, int) tuple = (-1, 0);
			(int, int) tuple2 = (1, 0);
			(int, int) tuple3 = (0, -1);
			(int, int) tuple4 = (0, 1);
			Cardinals = cardinals;
		}
	}
}
