using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.CoreSystem.New.GridEcsBinding;

namespace _game.CoreSystem.New.LevelGeneratorSystem.PostProcess
{
	[Token(Token = "0x2000342")]
	public static class WallTrapAnalyzer
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x2000343")]
		private struct _003C_003Ec__DisplayClass2_0
		{
			[Token(Token = "0x40009A6")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public int cols;

			[Token(Token = "0x40009A7")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
			public int rows;

			[Token(Token = "0x40009A8")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public Func<int, int, bool> isWall;
		}

		[Token(Token = "0x40009A4")]
		private static readonly int[] Dx = new int[8] { -1, 1, 0, 0, -1, -1, 1, 1 };

		[Token(Token = "0x40009A5")]
		private static readonly int[] Dy = new int[8] { 0, 0, -1, 1, -1, 1, -1, 1 };

		[Token(Token = "0x6000DD0")]
		[Address(RVA = "0x3EFCB90", Offset = "0x3EFCB90", Length = "0x690")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv33 = *([A4731E0]);\n\tgoto L_004A;\n\tv97 = v68 < 1;\n\tif (v97) goto L_0327;\n\tv112 = rows < 1;\n\tif (v112) goto L_0327;\n\tv270 = v68;\n\tv275 = 0x21C1134(System.Boolean[2], &v270 @ stack_-78_v3 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv361 = new System.Collections.Generic.Queue`1<System.ValueTuple`2<System.Int32, System.Int32>>();\n\tSystem.Collections.Generic.Queue`1<System.ValueTuple`2<System.Int32, System.Int32>>::.ctor(v361);\n\tv418 = v68 < 1;\n\tif (v418) goto L_012B;\n\tv422 = v275 == 0;\n\tif (v422) goto L_FFFFFFFF;\n\tv483 = v275 + 0x20;\nL_FFFFFFFF:\n\tv684 = 0;\nL_FFFFFFFF:\n\tv771 = v68;\n\tgoto L_00A7;\nL_0095:\n\tSystem.Collections.Generic.Queue`1<System.ValueTuple`2<System.Int32, System.Int32>>::Enqueue(v361, v553);\nL_0096:\n\tv684 = v684 + 1;\n\tv441 = v684 >= v68;\nL_FFFFFFFF:\n\tv771 = v68;\n\tif (v441) goto L_012B;\nL_00A7:\n\tgoto L_00B3;\n\tv571 = rows < 1;\n\tif (v571) goto L_0096;\n\tv852 = System.Func`3<System.Int32, System.Int32, System.Boolean>::Invoke(isWall, v684, 0);\n\tv922 = v852 & 1;\n\tv923 = v922 == 0;\n\tv853 = ~v923;\n\tif (v853) goto L_0096;\n\tv930 = *([v275 @ X0_v11+10]);\n\tv693 = *([v930 @ X8_v84+10]) * v684;\n\t*([v483 @ X24_v14+v693 @ X8_v86]) = 1;\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(&v553 @ stack_-78_v21 (System.ValueTuple`2<System.Int32, System.Int32>), v684, 0);\n\tv1123 = v361 == 0;\n\tv672 = ~v1123;\n\tif (v672) goto L_0095;\n\tgoto L_0324;\nL_FFFFFFFF:\n\tv685 = 0;\nL_FFFFFFFF:\n\tv486 = v68;\n\tgoto L_00FF;\nL_FFFFFFFF:\n\tv486 = v68;\nL_00FF:\n\tgoto L_010D;\n\tv572 = rows < 1;\n\tif (v572) goto L_00EF;\n\tv664 = System.Func`3<System.Int32, System.Int32, System.Boolean>::Invoke(isWall, v685, 0);\n\tv925 = v664 == 0;\n\tv674 = ~v925;\n\tif (v674) goto L_FFFFFFFF;\n\tgoto L_0324;\nL_012B:\n\tv153 = v275 + 0x20;\n\tv507 = v361.Count < 1;\nL_FFFFFFFF:\n\tv115 = v68;\n\tif (v507) goto L_022E;\nL_FFFFFFFF:\n\tv735 = v68;\nL_FFFFFFFF:\n\t;\n\tgoto L_014E;\nL_0148:\n\tv746 = v361.Count <= 0;\nL_FFFFFFFF:\n\tv115 = v735;\n\tif (v746) goto L_022E;\nL_014E:\n\tv830 = System.Collections.Generic.Queue`1<System.ValueTuple`2<System.Int32, System.Int32>>::Dequeue(v361);\n\tv688 = v830 >> 0x20;\nL_FFFFFFFF:\n\tv545 = 8;\n\tgoto L_0162;\nL_0153:\n\tv545 = v545 + 1;\n\tv880 = v545 == 0x10;\n\tif (v880) goto L_0148;\nL_0162:\n\tgoto L_0166;\n\tv562 = v569.Dy;\n\tv690 = *([v695 @ X8_v55 (System.Int32[])+v545 @ X27_v10 (System.Int32)*4]) + v830;\n\tv1125 = v690 & 0x80000000;\n\tv1126 = v1125 == 0;\n\tv1127 = ~v1126;\n\tif (v1127) goto L_0153;\n\tv547 = *([v562 @ X9_v33 (System.Int32[])+v545 @ X27_v10 (System.Int32)*4]) + v688;\n\tv1174 = v547 & 0x80000000;\n\tv1175 = v1174 == 0;\n\tv1176 = ~v1175;\n\tif (v1176) goto L_0153;\n\tv1209 = v735 - v690;\n\tv1210 = v1209 < 0;\n\tv1211 = v1209 == 0;\n\tv1212 = v735 ^ v690;\n\tv1213 = v735 ^ v1209;\n\tv1214 = v1212 & v1213;\n\tv1215 = v1214 < 0;\n\tv1216 = v1210 == v1215;\n\tv513 = ~v1211;\n\tv1217 = v1216 & v513;\n\tv511 = ~v1217;\n\tif (v511) goto L_FFFFFFFF;\n\tv1228 = rows - v547;\n\tv626 = v1228 < 0;\n\tv617 = v1228 == 0;\n\tv1231 = rows ^ v547;\n\tv1232 = rows ^ v1228;\n\tv1233 = v1231 & v1232;\n\tv581 = v1233 < 0;\n\tgoto L_01AE;\nL_FFFFFFFF:\n\tv581 = 0;\nL_FFFFFFFF:\n\tv617 = 1;\nL_FFFFFFFF:\n\tv626 = 0;\n\tv666 = System.Func`3<System.Int32, System.Int32, System.Boolean>::Invoke(isWall, v690, v547);\n\tv1248 = v666 & 1;\n\tv1249 = v1248 == 0;\n\tv1199 = ~v1249;\n\tif (v1199) goto L_0153;\n\tv1052 = *([v275 @ X0_v11+10]);\n\tv1256 = *([v1052 @ X8_v60+10]) * v690;\n\tv1257 = v547 + v1256;\n\tv1258 = *([v153 @ X26_v7+v1257 @ X8_v62]) & 1;\n\tv1259 = v1258 == 0;\n\tv1200 = ~v1259;\n\tif (v1200) goto L_0153;\n\tv996 = v547 < v688;\n\tif (v996) goto L_0153;\n\tgoto L_01F6;\nL_01F6:\n\tv1048 = _game.CoreSystem.New.LevelGeneratorSystem.PostProcess.WallTrapAnalyzer::<FindTraps>g__Passable|2_1(v690, v547, v830, v688, &v988 @ stack_-88_v10 (_game.CoreSystem.New.LevelGeneratorSystem.PostProcess.WallTrapAnalyzer+<>c__DisplayClass2_0));\n\tv1050 = ~v1048;\nL_FFFFFFFF:\n\tv735 = v988;\nL_FFFFFFFF:\n\t;\n\tif (v1050) goto L_0153;\n\tv1054 = *([v275 @ X0_v11+10]);\n\tv1201 = *([v1054 @ X8_v65+10]) * v690;\n\tv1272 = v547 + v1201;\n\t*([v153 @ X26_v7+v1272 @ X8_v67]) = 1;\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(&v1179 @ stack_-78_v17 (System.ValueTuple`2<System.Int32, System.Int32>), v690, v547);\n\tSystem.Collections.Generic.Queue`1<System.ValueTuple`2<System.Int32, System.Int32>>::Enqueue(v361, v1179);\nL_FFFFFFFF:\n\tv735 = v988;\nL_FFFFFFFF:\n\t;\n\tgoto L_0153;\nL_022E:\n\tv175 = rows < 1;\n\tif (v175) goto L_0327;\n\tv176 = v115 < 1;\n\tif (v176) goto L_0327;\nL_FFFFFFFF:\n\tv1107 = v115;\nL_FFFFFFFF:\n\tv246 = v115;\nL_FFFFFFFF:\n\tv700 = 0;\n\tgoto L_025E;\nL_FFFFFFFF:\n\tv225 = v1107;\nL_025E:\n\tv920 = v1107 < 1;\n\tif (v920) goto L_FFFFFFFF;\n\tv928 = v275 == 0;\n\tif (v928) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv687 = 0;\nL_FFFFFFFF:\n\tv1094 = v1107;\n\tgoto L_027C;\nL_0269:\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::Add(v77, v556);\nL_026A:\n\tv687 = v687 + 1;\n\tv949 = v687 >= v115;\nL_FFFFFFFF:\n\tv1094 = v115;\nL_FFFFFFFF:\n\tv225 = v115;\nL_FFFFFFFF:\n\tv246 = v115;\n\tif (v949) goto L_0246;\nL_027C:\n\tgoto L_0288;\n\tv575 = v700 >= rows;\n\tif (v575) goto L_026A;\n\tv1049 = System.Func`3<System.Int32, System.Int32, System.Boolean>::Invoke(isWall, v687, v700);\n\tv1222 = v1049 & 1;\n\tv1223 = v1222 == 0;\n\tv1051 = ~v1223;\n\tif (v1051) goto L_026A;\n\tv1056 = *([v275 @ X0_v11+10]);\n\tv1243 = *([v1056 @ X8_v38+10]) * v687;\n\tv1244 = v700 + v1243;\n\tv1245 = *([v153 @ X26_v7+v1244 @ X8_v40]) & 1;\n\tv1246 = v1245 == 0;\n\tv1153 = ~v1246;\n\tif (v1153) goto L_026A;\n\t_game.CoreSystem.New.GridEcsBinding.GridCoord::.ctor(&v556 @ stack_-78_v12 (_game.CoreSystem.New.GridEcsBinding.GridCoord), v687, v700);\n\tgoto L_0269;\nL_FFFFFFFF:\n\tv683 = 0;\nL_FFFFFFFF:\n\tv984 = v246;\n\tgoto L_02FB;\nL_FFFFFFFF:\n\tv984 = v115;\nL_02FB:\n\tgoto L_030A;\n\tv570 = v700 >= rows;\n\tif (v570) goto L_02E9;\n\tv660 = System.Func`3<System.Int32, System.Int32, System.Boolean>::Invoke(isWall, v683, v700);\n\tv1225 = v660 == 0;\n\tv670 = ~v1225;\n\tif (v670) goto L_FFFFFFFF;\nL_0324:\n\tv223 = new System.NullReferenceException();\nL_0327:\n\tv255 = *([A4731E0]);\n\tv266 = *([v255 @ X9_v4]) != *([v33 @ X8_v2]);\n\tif (v266) goto L_0344;\n\treturn v77;\nL_0344:\n\treturnVal2 = 0x8BF5CF0(clobbered_X0, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal2;\nL_004A:\n\tv77 = new System.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>();\n\tSystem.Collections.Generic.List`1<_game.CoreSystem.New.GridEcsBinding.GridCoord>::.ctor(v77);\nL_00B3:\n\tv782 = v684 >= v771;\n\tif (v782) goto L_0096;\nL_010D:\n\tv797 = v486 <= v685;\n\tif (v797) goto L_00EF;\nL_00EF:\n\tv685 = v685 + 1;\n\tv442 = v685 >= v486;\n\tif (v442) goto L_012B;\nL_0166:\n\tv695 = v569.Dx;\nL_01AE:\n\tv1240 = v626 == v581;\n\tv1241 = ~v1240;\n\tv574 = v1241 | v617;\n\tif (v574) goto L_0153;\nL_0246:\n\tv700 = v700 + 1;\n\tv177 = v700 >= rows;\nL_FFFFFFFF:\n\tv1107 = v225;\n\tif (v177) goto L_0327;\nL_0288:\n\tv1105 = v687 >= v1094;\n\tif (v1105) goto L_026A;\nL_030A:\n\tv1122 = v1107 <= v683;\n\tif (v1122) goto L_02E9;\nL_02E9:\n\tv683 = v683 + 1;\n\tv950 = v683 >= v984;\nL_FFFFFFFF:\n\tv1107 = v984;\nL_FFFFFFFF:\n\tv225 = v984;\nL_FFFFFFFF:\n\tv246 = v984;\n\tif (v950) goto L_0246;\n// 14 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static List<GridCoord> FindTraps(int cols, int rows, Func<int, int, bool> isWall)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("WallTrapAnalyzer::FindTraps");
			return default;
		}

		[Token(Token = "0x6000DD1")]
		[Address(RVA = "0x3EFD470", Offset = "0x3EFD470", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tgoto L_001B;\nL_001B:\n\tv75 = _game.CoreSystem.New.LevelGeneratorSystem.PostProcess.WallTrapAnalyzer::FindTraps(cols, rows, isWall);\n\treturn v75.Count;\n")]
		public static int CountTraps(int cols, int rows, Func<int, int, bool> isWall)
		{
			List<GridCoord> list = FindTraps(cols, rows, isWall);
			return list.Count;
		}
	}
}
