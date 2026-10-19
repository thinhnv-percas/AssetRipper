using System;
using System.Collections.Generic;
using System.Linq;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.Tools.AlgorithmicLevelGenerator.Solver;

namespace _game.Tools.AlgorithmicLevelGenerator.Generator
{
	[Token(Token = "0x2000040")]
	public class ConstructiveSimulator
	{
		[Token(Token = "0x4000124")]
		[FieldOffset(Offset = "0x10")]
		public readonly int MoldCols;

		[Token(Token = "0x4000125")]
		[FieldOffset(Offset = "0x14")]
		public int ConveyorCapacity;

		[Token(Token = "0x4000126")]
		[FieldOffset(Offset = "0x18")]
		public int MoldCellsAssigned;

		[Token(Token = "0x4000127")]
		[FieldOffset(Offset = "0x1C")]
		public int ActiveRowIndex;

		[Token(Token = "0x4000128")]
		[FieldOffset(Offset = "0x20")]
		public SolverColor[] ActiveCellColors;

		[Token(Token = "0x4000129")]
		[FieldOffset(Offset = "0x28")]
		public int[] ActiveCellFills;

		[Token(Token = "0x400012A")]
		[FieldOffset(Offset = "0x30")]
		public Dictionary<SolverColor, int> ConveyorPool;

		[Token(Token = "0x400012B")]
		[FieldOffset(Offset = "0x38")]
		public int TapCount;

		[Token(Token = "0x60000A6")]
		[Address(RVA = "0x3C168C4", Offset = "0x3C168C4", Length = "0x1A0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tSystem.Object::.ctor(this);\n\tthis.MoldCols = moldCols;\n\tthis.ConveyorCapacity = conveyorCapacity;\n\t// 60 NewArr v81 @ X0_v9 (_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor[]), typeof(_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor[]), moldCols @ X1 (System.Int32)\n\tthis.ActiveCellColors = v81;\n\t// 69 NewArr v89 @ X0_v13 (System.Int32[]), typeof(System.Int32[]), moldCols @ X1 (System.Int32)\n\tthis.ActiveCellFills = v89;\n\tv104 = moldCols < 1;\n\tif (v104) goto L_00BA;\n\tv105 = this.ActiveCellColors;\n\tv242 = moldCols - 1;\n\tv165 = v242 < v105.Length;\n\tv166 = ~v165;\n\tv174 = ~v166;\n\tv175 = ~v174;\n\tif (v175) goto L_FFFFFFFF;\n\tgoto L_006D;\nL_FFFFFFFF:\n\tv242 = v105.Length;\nL_FFFFFFFF:\n\tv122 = 0;\n\tgoto L_009A;\nL_0079:\n\tv253 = v242 + 1;\n\tv290 = v253 & 7;\n\tv256 = v290 == 0;\n\tv260 = ~v256;\n\tif (v260) goto L_0086;\nL_FFFFFFFF:\n\tv290 = 8;\n\tgoto L_0086;\nL_009A:\n\tv110 = v122 << 2;\n\tv284 = v105 + v110;\n\tv208 = v284 + 0x20;\n\tv183 = moldCols - v122;\nL_00A0:\n\t*([v208 @ X8_v8]) = 0;\n\tv208 = v208 + 4;\n\tv125 = v183 - 1;\n\tv131 = v183 != 1;\nL_FFFFFFFF:\n\tv183 = v125;\n\tif (v131) goto L_00A0;\nL_00BA:\n\treturn;\nL_002C:\n\tv62 = new System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>();\n\tSystem.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>::.ctor(v62);\n\tthis.ConveyorPool = v62;\nL_006D:\n\tv243 = v242 < 8;\n\tv244 = ~v243;\n\tif (v244) goto L_0079;\nL_0086:\n\tv122 = v253 - v290;\n\tv295 = v105 + 0x30;\nL_FFFFFFFF:\n\tv294 = v122;\nL_FFFFFFFF:\n\tv294 = v114;\nL_FFFFFFFF:\n\tv295 = v117;\nL_008A:\n\t*([v295 @ X12_v7-10]) = 0;\n\t*([v295 @ X12_v7]) = 0;\n\tv295 = v295 + 0x20;\n\tv262 = v294 - 8;\n\tv266 = v294 != 8;\nL_FFFFFFFF:\n\tv294 = v262;\n\tif (v266) goto L_008A;\n")]
		public ConstructiveSimulator(int moldCols, int conveyorCapacity)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConstructiveSimulator::.ctor");
		}

		[Token(Token = "0x60000A7")]
		[Address(RVA = "0x3C16A64", Offset = "0x3C16A64", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tv43 = System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>::get_Values(this.ConveyorPool);\n\treturnVal2 = System.Linq.Enumerable::Sum(v43);\n\treturn returnVal2;\n")]
		public int ConveyorTotal()
		{
			IEnumerable<int> values = ConveyorPool.Values;
			return values.Sum();
		}

		[Token(Token = "0x60000A8")]
		[Address(RVA = "0x3C16AC0", Offset = "0x3C16AC0", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\nL_0018:\n\tv43 = System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>::get_Values(this.ConveyorPool);\n\tv46 = System.Linq.Enumerable::Sum(v43);\n\tv50 = v46 - this.ConveyorCapacity;\n\tv51 = v50 < 0;\n\tv52 = v50 == 0;\n\tv53 = v46 ^ this.ConveyorCapacity;\n\tv54 = v46 ^ v50;\n\tv55 = v53 & v54;\n\tv56 = v55 < 0;\n\tv57 = v51 == v56;\n\tv58 = ~v52;\n\tv59 = v57 & v58;\n\treturn v59;\n")]
		public bool IsConveyorOverflowing()
		{
			IEnumerable<int> values = ConveyorPool.Values;
			int num = values.Sum();
			int num2 = num - ConveyorCapacity;
			bool flag = num2 < 0;
			bool flag2 = num2 == 0;
			int num3 = num ^ ConveyorCapacity;
			int num4 = num ^ num2;
			int num5 = num3 & num4;
			bool flag3 = num5 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			return flag4 && flag5;
		}

		[Token(Token = "0x60000A9")]
		[Address(RVA = "0x3C16B2C", Offset = "0x3C16B2C", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = this.MoldCols < 1;\n\tif (v18) goto L_FFFFFFFF;\n\tv25 = this.ActiveCellColors + 0x20;\nL_FFFFFFFF:\n\treturnVal1 = 0;\nL_0022:\n\tv30 = *([v25 @ X9_v4+returnVal1 @ X0_v1 (System.Int32)*4]) == 0;\n\tif (v30) goto L_0034;\n\treturnVal1 = returnVal1 + 1;\n\tv36 = this.MoldCols != returnVal1;\n\tif (v36) goto L_0022;\nL_FFFFFFFF:\n\treturnVal1 = -1;\nL_0034:\n\treturn returnVal1;\n")]
		public int NextUnassignedCellIndex()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConstructiveSimulator::NextUnassignedCellIndex");
			return default;
		}

		[Token(Token = "0x60000AA")]
		[Address(RVA = "0x3C16B84", Offset = "0x3C16B84", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv18 = this.MoldCols < 1;\n\tif (v18) goto L_0063;\n\tv185 = this.ActiveCellColors;\nL_FFFFFFFF:\n\tv183 = 0;\nL_0020:\n\tv42 = v183 << 2;\n\tv196 = v185 + v42;\n\tv154 = *([v196 @ X12_v6+20]) == 0;\n\tif (v154) goto L_0075;\n\tv183 = v183 + 1;\n\tv156 = this.MoldCols != v183;\n\tif (v156) goto L_0020;\n\tv245 = this.ActiveRowIndex + 1;\n\tthis.ActiveRowIndex = v245;\nL_FFFFFFFF:\n\tv99 = 8;\nL_0041:\n\t*([v185 @ X8_v1 (_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor[])+v99 @ X10_v9 (System.Int32)*4]) = 0;\n\tv47 = this.ActiveCellFills;\n\t*([v47 @ X11_v8 (System.Int32[])+v99 @ X10_v9 (System.Int32)*4]) = 0;\n\tv120 = v99 - 7;\n\tv99 = v99 + 1;\n\tv128 = v120 < this.MoldCols;\n\tif (v128) goto L_0041;\n\tgoto L_FFFFFFFF;\nL_0063:\n\tv22 = this.ActiveRowIndex + 1;\n\tthis.ActiveRowIndex = v22;\n\tv185 = this.ActiveCellColors;\nL_FFFFFFFF:\n\tv183 = 0;\nL_0075:\n\tv43 = v183 << 2;\n\tv241 = v185 + v43;\n\t*([v241 @ X8_v2+20]) = color;\n\tv60 = this.ActiveCellFills;\n\tv60[v183 @ X9_v1 (System.Int32)] = 0;\n\tv228 = this.MoldCellsAssigned + 1;\n\tthis.MoldCellsAssigned = v228;\n\t_game.Tools.AlgorithmicLevelGenerator.Generator.ConstructiveSimulator::DrainConveyor(this);\n\treturn;\n")]
		public void AssignNextMoldCell(SolverColor color)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConstructiveSimulator::AssignNextMoldCell");
		}

		[Token(Token = "0x60000AB")]
		[Address(RVA = "0x3C16FE0", Offset = "0x3C16FE0", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\nL_0027:\n\tv60 = System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>::ContainsKey(this.ConveyorPool, color);\n\tv81 = v60 == 0;\n\tv82 = ~v81;\n\tif (v82) goto L_003B;\n\tSystem.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>::set_Item(this.ConveyorPool, color, 0);\nL_003B:\n\tv119 = System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>::get_Item(this.ConveyorPool, color);\n\tv96 = v119 + particles;\n\tSystem.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>::set_Item(this.ConveyorPool, color, v96);\n\tv103 = this.TapCount + 1;\n\tthis.TapCount = v103;\n\t_game.Tools.AlgorithmicLevelGenerator.Generator.ConstructiveSimulator::DrainConveyor(this);\n\treturn;\n")]
		public void TapCube(SolverColor color, int particles)
		{
			if (!ConveyorPool.ContainsKey(color))
			{
				ConveyorPool[color] = 0;
			}
			int num = ConveyorPool[color];
			int value = num + particles;
			ConveyorPool[color] = value;
			int tapCount = TapCount + 1;
			TapCount = tapCount;
			DrainConveyor();
		}

		[Token(Token = "0x60000AC")]
		[Address(RVA = "0x3C16D04", Offset = "0x3C16D04", Length = "0x2DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\nL_0030:\n\tv276 = v97 < 0;\n\tv273 = v97 == 0;\n\tv267 = v97 ^ v97;\n\tv264 = v97 & v267;\n\tv261 = v264 < 0;\n\tv638 = v276 == v261;\n\tv256 = ~v273;\n\tv258 = v638 & v256;\n\tv253 = v184 & v258;\n\tv640 = v253 & 1;\n\tv286 = v640 == 0;\n\tif (v286) goto L_01A1;\nL_003E:\n\tv97 = v97 - 1;\nL_FFFFFFFF:\n\tv181 = 8;\nL_FFFFFFFF:\n\tv184 = 0;\n\tgoto L_0062;\nL_0052:\n\tv706 = System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>::Remove(this.ConveyorPool, *([v215 @ X8_v7 (_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor[])+v181 @ X28_v5 (System.Int32)*4]));\nL_FFFFFFFF:\n\tv184 = 1;\nL_0062:\n\tv215 = this.ActiveCellColors;\n\tv516 = *([v215 @ X8_v7 (_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor[])+v181 @ X28_v5 (System.Int32)*4]) == 0;\n\tif (v516) goto L_0054;\n\tv448 = this.ActiveCellFills;\n\tv359 = *([v448 @ X8_v17 (System.Int32[])+v181 @ X28_v5 (System.Int32)*4]) > 0;\n\tif (v359) goto L_0054;\n\tv562 = System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>::ContainsKey(this.ConveyorPool, *([v215 @ X8_v7 (_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor[])+v181 @ X28_v5 (System.Int32)*4]));\n\tv564 = ~v562;\n\tif (v564) goto L_0054;\n\tv432 = System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>::get_Item(this.ConveyorPool, *([v215 @ X8_v7 (_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor[])+v181 @ X28_v5 (System.Int32)*4]));\n\tv360 = v432 < 1;\n\tif (v360) goto L_0054;\n\tv450 = this.ActiveCellFills;\n\t*([v450 @ X8_v19 (System.Int32[])+v181 @ X28_v5 (System.Int32)*4]) = 1;\n\tv698 = System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>::get_Item(this.ConveyorPool, *([v215 @ X8_v7 (_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor[])+v181 @ X28_v5 (System.Int32)*4]));\n\tv345 = v698 - 1;\n\tSystem.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>::set_Item(this.ConveyorPool, *([v215 @ X8_v7 (_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor[])+v181 @ X28_v5 (System.Int32)*4]), v345);\n\tv700 = System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>::get_Item(this.ConveyorPool, *([v215 @ X8_v7 (_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor[])+v181 @ X28_v5 (System.Int32)*4]));\n\tv701 = v700 == 0;\n\tv702 = ~v701;\n\tif (v702) goto L_FFFFFFFF;\n\tv703 = this.ConveyorPool == 0;\n\tv442 = ~v703;\n\tif (v442) goto L_0052;\n\tgoto L_01A2;\nL_00DD:\n\tv361 = this.MoldCols < 1;\n\tif (v361) goto L_011E;\n\tv322 = this.ActiveCellColors + 0x20;\nL_FFFFFFFF:\n\tv353 = 0;\nL_00F1:\n\tv636 = *([v322 @ X11_v13+v353 @ X9_v17 (System.Int32)*4]) == 0;\n\tif (v636) goto L_0030;\n\tv320 = this.ActiveCellFills;\n\tv618 = v320[v353 @ X9_v17 (System.Int32)] < 1;\n\tif (v618) goto L_0030;\n\tv353 = v353 + 1;\n\tv580 = v137 != v353;\n\tif (v580) goto L_00F1;\nL_011E:\n\tv323 = this.ActiveRowIndex * v137;\n\tv611 = this.MoldCellsAssigned <= v323;\n\tif (v611) goto L_0030;\n\tv354 = this.ActiveRowIndex + 1;\n\tthis.ActiveRowIndex = v354;\n\tv363 = v137 < 1;\n\tif (v363) goto L_0174;\n\tv355 = this.ActiveCellColors + 0x20;\nL_FFFFFFFF:\n\tv451 = 0;\nL_014A:\n\t*([v355 @ X9_v15+v451 @ X8_v14 (System.Int32)*4]) = 0;\n\tv324 = this.ActiveCellFills;\n\tv324[v451 @ X8_v14 (System.Int32)] = 0;\n\tv451 = v451 + 1;\n\tv653 = v451 < this.MoldCols;\n\tif (v653) goto L_014A;\nL_FFFFFFFF:\n\tv137 = this.MoldCols;\n\tgoto L_01A1;\nL_0179:\n\tv158 = this.ActiveRowIndex * v137;\n\tv170 = this.MoldCellsAssigned <= v158;\n\tif (v170) goto L_01A1;\n\tv217 = this.ActiveRowIndex + 1;\n\tthis.ActiveRowIndex = v217;\n\tv227 = v97 >= 1;\n\tif (v227) goto L_003E;\nL_01A1:\n\treturn;\nL_01A2:\n\tv453 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\nL_0029:\n\tv137 = this.MoldCols;\n\tv97 = this.MoldCols << 4;\n\tgoto L_0049;\nL_0054:\n\tv137 = this.MoldCols;\n\tv186 = v181 - 7;\n\tv181 = v181 + 1;\n\tv190 = v186 >= this.MoldCols;\n\tif (v190) goto L_00DD;\nL_0174:\n\tv259 = v97 >= 1;\n\tif (v259) goto L_003E;\nL_0049:\n\tv150 = v137 < 1;\n\tif (v150) goto L_0179;\n")]
		public void DrainConveyor()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConstructiveSimulator::DrainConveyor");
		}

		[Token(Token = "0x60000AD")]
		[Address(RVA = "0x3C16C88", Offset = "0x3C16C88", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = this.ActiveRowIndex + 1;\n\tthis.ActiveRowIndex = v8;\n\tv20 = this.MoldCols < 1;\n\tif (v20) goto L_0047;\n\tv33 = this.ActiveCellColors + 0x20;\n\tv105 = 0;\nL_0024:\n\t*([v33 @ X9_v3+v105 @ X8_v7 (System.Int32)*4]) = 0;\n\tv73 = this.ActiveCellFills;\n\tv73[v105 @ X8_v7 (System.Int32)] = 0;\n\tv105 = v105 + 1;\n\tv42 = v105 < this.MoldCols;\n\tif (v42) goto L_0024;\nL_0047:\n\treturn;\n")]
		private void AdvanceToNextRow()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConstructiveSimulator::AdvanceToNextRow");
		}

		[Token(Token = "0x60000AE")]
		[Address(RVA = "0x3C170D4", Offset = "0x3C170D4", Length = "0x250")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002E;\n\tv55.MoldCellsAssigned = this.MoldCellsAssigned;\n\tv55.TapCount = this.TapCount;\n\tv82 = this.MoldCols < 1;\n\tif (v82) goto L_0092;\n\tv255 = this.ActiveCellColors;\n\tv248 = this.ActiveCellColors == 0;\n\tv239 = this.MoldCols;\n\tif (v248) goto L_00CC;\n\tv164 = v255.Length;\n\tv287 = v55.ActiveCellColors == 0;\n\tv92 = 0;\n\tif (v287) goto L_00C8;\n\tv158 = 8;\nL_0062:\n\t*([v170 @ X9_v6 (_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor[])+v158 @ X11_v7 (System.Int32)*4]) = *([v255 @ X8_v13 (_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor[])+v158 @ X11_v7 (System.Int32)*4]);\n\tv146 = this.ActiveCellFills;\n\tv249 = this.ActiveCellFills == 0;\n\tv239 = v258;\n\tif (v249) goto L_00CC;\n\tv140 = v55.ActiveCellFills;\n\tv250 = v55.ActiveCellFills == 0;\n\tv239 = v258;\n\tif (v250) goto L_00CC;\n\t*([v140 @ X14_v8 (System.Int32[])+v158 @ X11_v7 (System.Int32)*4]) = *([v146 @ X13_v9 (System.Int32[])+v158 @ X11_v7 (System.Int32)*4]);\n\tv166 = v164 - 1;\n\tv269 = v158 - 7;\n\tv158 = v158 + 1;\n\tv273 = v269 < this.MoldCols;\n\tv164 = v166;\n\tif (v273) goto L_0062;\nL_0092:\n\tv251 = this.ConveyorPool == 0;\n\tv239 = v258;\n\tif (v251) goto L_00CC;\n\tv259 = 0xB2A8000 + 0xAC8;\n\tv299 = System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>::GetEnumerator(this.ConveyorPool);\n\tv325 = v299._dictionary;\n\tSystem.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>::set_Item(v55.ConveyorPool, *([v299 @ X0_v24 (System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>+Enumerator<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>)+10]), *([v299 @ X0_v24 (System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>+Enumerator<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>)+14]));\n\tgoto L_00AC;\nL_00BA:\n\tSystem.Collections.Generic.Dictionary`2<System.Int32Enum, System.Int32>+Enumerator<System.Int32Enum, System.Int32>::Dispose(&v325 @ stack_-60_v6 (System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>));\nL_00C5:\n\treturn v55;\n\tv243 = new System.IndexOutOfRangeException();\n\tv86 = &v50 @ stack_-60_v1 (System.Int32);\n\tv239 = Il2CppMethodInfo;\n\tv258 = v259;\nL_00CC:\n\tv264 = new System.NullReferenceException();\n\tgoto L_00D9;\nL_00D9:\n\tv310 = v239 != 1;\n\tv342 = v264;\n\tif (v310) goto L_00E9;\n\tv333 = 0x8BF5BC4(v264, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv381 = 0x8BF5BF4(v333, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.Dictionary`2<System.Int32Enum, System.Int32>+Enumerator<System.Int32Enum, System.Int32>::Dispose(v86);\n\tv341 = *([v333 @ X0_v13]) == 0;\n\tif (v341) goto L_00C5;\n\tv339 = new System.OutOfMemoryException();\n\tv92 = *([v333 @ X0_v13]);\n\tv342 = v339;\n\treturn returnVal1;\nL_002E:\n\tv50 = 0;\n\tv258 = this.MoldCols;\n\tv55 = new _game.Tools.AlgorithmicLevelGenerator.Generator.ConstructiveSimulator();\n\t_game.Tools.AlgorithmicLevelGenerator.Generator.ConstructiveSimulator::.ctor(v55, this.MoldCols, this.ConveyorCapacity);\n\tv65 = v55 == 0;\n\tv239 = this.MoldCols;\n\tif (v65) goto L_00CC;\nL_00C8:\n\tv331 = v166 == 0;\n\tv252 = ~v331;\n\tv86 = &v50 @ stack_-60_v1 (System.Int32);\n\tv239 = Il2CppMethodInfo;\n\tv258 = v259;\n\tif (v252) goto L_00CC;\nL_00AC:\n\tv379 = System.Collections.Generic.Dictionary`2<System.Int32Enum, System.Int32>+Enumerator<System.Int32Enum, System.Int32>::MoveNext(&v325 @ stack_-60_v6 (System.Collections.Generic.Dictionary`2<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor, System.Int32>));\n\tv386 = v379 == 0;\n\tif (v386) goto L_00BA;\nL_00E9:\n\tv345 = 0x3176078(&v92 @ stack_-70 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv383 = 0x8BF0368(v342, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal1 = 0xA1B8(v383, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe ConstructiveSimulator Clone()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConstructiveSimulator::Clone");
			return default;
		}
	}
}
