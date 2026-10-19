using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Solver
{
	[Token(Token = "0x200000F")]
	public class MoldColumn
	{
		[Token(Token = "0x4000049")]
		[FieldOffset(Offset = "0x10")]
		public int Index;

		[Token(Token = "0x400004A")]
		[FieldOffset(Offset = "0x18")]
		public List<MoldCell> Cells;

		[Token(Token = "0x400004B")]
		[FieldOffset(Offset = "0x20")]
		public int ActiveIdx;

		[Token(Token = "0x17000002")]
		public MoldCell ActiveCell
		{
			[Token(Token = "0x600003F")]
			[Address(RVA = "0x3C009C0", Offset = "0x3C009C0", Length = "0x80")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv54 = this.ActiveIdx >= v39.Count;\n\tif (v54) goto L_0035;\n\treturnVal3 = System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.MoldCell>::get_Item(v39, this.ActiveIdx);\n\treturn returnVal3;\nL_0035:\n\treturn 0;\nL_0015:\n\tv39 = this.Cells;\n")]
			get
			{
				List<MoldCell> cells = Cells;
				if (ActiveIdx < cells.Count)
				{
					return cells[ActiveIdx];
				}
				return null;
			}
		}

		[Token(Token = "0x17000003")]
		public bool IsComplete
		{
			[Token(Token = "0x6000040")]
			[Address(RVA = "0x3C07858", Offset = "0x3C07858", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv44 = this.ActiveIdx - v38.Count;\n\tv45 = v44 < 0;\n\tv47 = this.ActiveIdx ^ v38.Count;\n\tv48 = this.ActiveIdx ^ v44;\n\tv49 = v47 & v48;\n\tv50 = v49 < 0;\n\tv51 = v45 == v50;\n\treturn v51;\nL_0012:\n\tv38 = this.Cells;\n")]
			get
			{
				List<MoldCell> cells = Cells;
				int num = ActiveIdx - cells.Count;
				bool flag = num < 0;
				int num2 = ActiveIdx ^ cells.Count;
				int num3 = ActiveIdx ^ num;
				int num4 = num2 & num3;
				bool flag2 = num4 < 0;
				return flag == flag2;
			}
		}

		[Token(Token = "0x6000041")]
		[Address(RVA = "0x3C01C90", Offset = "0x3C01C90", Length = "0x1E0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tgoto L_0050;\nL_0041:\n\tSystem.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.MoldActivation>::Add(v56, v171);\nL_0042:\n\tv211 = this.Cells;\nL_0050:\n\tv106 = this.ActiveIdx >= v211.Count;\n\tif (v106) goto L_00B3;\n\tv169 = System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.MoldCell>::get_Item(v211, this.ActiveIdx);\n\tv140 = v169.Fill < 0x3F7FBE77;\n\tv271 = v169.Fill == v169.Fill;\n\tv112 = ~v271;\n\tv272 = v140 == v112;\n\tv107 = ~v272;\n\tif (v107) goto L_00B3;\n\tv165 = this.ActiveIdx + 1;\n\tthis.ActiveIdx = v165;\n\tv170 = this.Cells;\n\tv105 = v165 >= v170.Count;\n\tif (v105) goto L_0042;\n\tv274 = System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.MoldCell>::get_Item(v170, v165);\n\tv171 = new _game.Tools.AlgorithmicLevelGenerator.Solver.MoldActivation();\n\tSystem.Object::.ctor(v171);\n\tv90 = this.ActiveIdx - 1;\n\tv171.Col = this.Index;\n\tv171.FromRow = v90;\n\tv171.ToRow = this.ActiveIdx;\n\tv171.NewColor = v274.Color;\n\tgoto L_0041;\nL_00B3:\n\treturn v56;\nL_002C:\n\tv56 = new System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.MoldActivation>();\n\tSystem.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.MoldActivation>::.ctor(v56);\n\tv211 = this.Cells;\n// 6 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public List<MoldActivation> Advance()
		{
			List<MoldActivation> list = new List<MoldActivation>();
			List<MoldCell> cells = Cells;
			while (ActiveIdx < cells.Count)
			{
				MoldCell moldCell = cells[ActiveIdx];
				bool flag = moldCell.Fill < 0.999f;
				bool flag2 = moldCell.Fill == moldCell.Fill;
				bool flag3 = !flag2;
				if (flag != flag3)
				{
					break;
				}
				int num = ++ActiveIdx;
				List<MoldCell> cells2 = Cells;
				if (num < cells2.Count)
				{
					MoldCell moldCell2 = cells2[num];
					MoldActivation moldActivation = new MoldActivation();
					int fromRow = ActiveIdx - 1;
					moldActivation.Col = Index;
					moldActivation.FromRow = fromRow;
					moldActivation.ToRow = ActiveIdx;
					moldActivation.NewColor = moldCell2.Color;
					list.Add(moldActivation);
				}
				cells = Cells;
			}
			return list;
		}

		[Token(Token = "0x6000042")]
		[Address(RVA = "0x3C0AEAC", Offset = "0x3C0AEAC", Length = "0x2DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002C;\n\tSystem.Object::.ctor(v58);\n\tv58.Index = this.Index;\n\tv58.ActiveIdx = this.ActiveIdx;\n\tv106 = this.Cells == 0;\n\tv188 = 0;\n\tif (v106) goto L_00CD;\n\tv116 = System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.MoldCell>::GetEnumerator(this.Cells);\n\tv173 = v116.Current;\n\tv165 = v116._list;\n\tgoto L_0078;\nL_0075:\n\tSystem.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.MoldCell>::AddWithResize(v58.Cells, v342);\nL_0078:\n\tv243 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v165 @ stack_-80_v3 (System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.MoldCell>));\n\tv255 = v243 == 0;\n\tif (v255) goto L_00B9;\n\tv232 = v58.Cells;\n\tgoto L_0089;\n\tv342.Col = v173.Col;\n\tv342.Color = v173.Color;\n\tv342.IsHidden = v173.IsHidden;\n\tv342.Fill = v173.Fill;\n\tv393 = v58.Cells == 0;\n\tif (v393) goto L_00C9;\n\tv396 = v232._version + 1;\n\tv232._version = v396;\n\tv221 = v232._items;\n\tv237 = v232._items == 0;\n\tif (v237) goto L_00C9;\n\tv219 = v232.Count;\n\tv397 = v232.Count < v221.Length;\n\tv217 = ~v397;\n\tif (v217) goto L_0075;\n\tv240 = v232.Count + 1;\n\tv232.Count = v240;\n\tv221[v219 @ X10_v4 (System.Int32)] = v342;\n\tgoto L_0078;\nL_00B9:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v165 @ stack_-80_v3 (System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.MoldCell>));\nL_00C8:\n\treturn v58;\nL_00C9:\n\tv346 = new System.NullReferenceException();\n\tv188 = Il2CppMethodInfo;\n\tgoto L_00CC;\nL_00CC:\n\t// 204 Interrupt\n\tv115 = 0;\nL_00DA:\n\tv253 = v188 != 1;\n\tif (v253) goto L_00EB;\n\tv256 = 0x8BF5BC4(v202, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv277 = 0x8BF5BF4(v256, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v165 @ stack_-80_v3 (System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.MoldCell>));\n\tv264 = *([v256 @ X0_v19]) == 0;\n\tif (v264) goto L_00C8;\n\tv262 = new System.OutOfMemoryException();\n\tv115 = *([v256 @ X0_v19]);\n\tv202 = v262;\nL_00EB:\n\tv271 = 0x31760F8(&v115 @ stack_-98 (System.Int32), clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv279 = 0x8BF0368(v202, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturnVal2 = 0xA1B8(v279, clobbered_X1, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal2;\nL_002C:\n\tv58 = new _game.Tools.AlgorithmicLevelGenerator.Solver.MoldColumn();\n\tgoto L_0041;\nL_0041:\n\tv83 = new System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.MoldCell>();\n\tSystem.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.MoldCell>::.ctor(v83);\n\tv58.Cells = v83;\nL_00CD:\n\tv202 = new System.NullReferenceException();\n\tgoto L_00DA;\nL_0089:\n\tv342 = new _game.Tools.AlgorithmicLevelGenerator.Solver.MoldCell();\n\tSystem.Object::.ctor(v342);\n\tv389 = v342 == 0;\n\tif (v389) goto L_00C9;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe MoldColumn Clone()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldColumn::Clone");
			return default;
		}

		[Token(Token = "0x6000043")]
		[Address(RVA = "0x3BFF968", Offset = "0x3BFF968", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.MoldCell>();\n\tSystem.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.MoldCell>::.ctor(v48);\n\tthis.Cells = v48;\n")]
		public MoldColumn()
		{
			List<MoldCell> cells = new List<MoldCell>();
			Cells = cells;
		}
	}
}
