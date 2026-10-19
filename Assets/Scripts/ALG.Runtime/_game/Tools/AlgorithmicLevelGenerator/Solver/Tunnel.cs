using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Solver
{
	[Token(Token = "0x200002E")]
	public class Tunnel
	{
		[Token(Token = "0x40000F4")]
		[FieldOffset(Offset = "0x10")]
		public int Col;

		[Token(Token = "0x40000F5")]
		[FieldOffset(Offset = "0x14")]
		public int Row;

		[Token(Token = "0x40000F6")]
		[FieldOffset(Offset = "0x18")]
		public TunnelDirection Direction;

		[Token(Token = "0x40000F7")]
		[FieldOffset(Offset = "0x20")]
		public Queue<SolverColor> Queue;

		[Token(Token = "0x6000063")]
		[Address(RVA = "0x3C0D590", Offset = "0x3C0D590", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv59 = this.Direction == 0;\n\tif (v59) goto L_FFFFFFFF;\n\tv78 = this.Direction != 1;\n\tif (v78) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv113 = 1;\nL_FFFFFFFF:\n\tv115 = 0;\nL_FFFFFFFF:\n\tv137 = &v80 @ stack_-38_v7 (System.ValueTuple`2<System.Int32, System.Int32>);\n\tgoto L_0059;\nL_003B:\n\tv64 = this.Direction == 2;\n\tif (v64) goto L_FFFFFFFF;\n\tv92 = this.Direction != 3;\n\tif (v92) goto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv115 = 1;\nL_FFFFFFFF:\n\tv137 = &v80 @ stack_-38_v7 (System.ValueTuple`2<System.Int32, System.Int32>);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv115 = 0;\nL_FFFFFFFF:\n\tv137 = &v80 @ stack_-38_v7 (System.ValueTuple`2<System.Int32, System.Int32>);\n\tgoto L_FFFFFFFF;\nL_FFFFFFFF:\n\tv113 = -1;\nL_FFFFFFFF:\n\tv115 = 0;\nL_FFFFFFFF:\n\tv137 = &v80 @ stack_-38_v7 (System.ValueTuple`2<System.Int32, System.Int32>);\n\tgoto L_0059;\nL_FFFFFFFF:\n\tv115 = -1;\nL_FFFFFFFF:\n\tv137 = &v80 @ stack_-38_v7 (System.ValueTuple`2<System.Int32, System.Int32>);\nL_0024:\n\tv58 = this.Direction > 1;\n\tif (v58) goto L_003B;\nL_0059:\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(v137, v115, v113);\n\treturn v80;\nL_FFFFFFFF:\n\tv113 = 0;\n")]
		public unsafe (int, int) GetSpawnDelta()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Tunnel::GetSpawnDelta");
			return default;
		}

		[Token(Token = "0x6000064")]
		[Address(RVA = "0x3C05E98", Offset = "0x3C05E98", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\nL_0017:\n\tv45 = _game.Tools.AlgorithmicLevelGenerator.Solver.Tunnel::GetSpawnDelta(this);\n\tv47 = v45 >> 0x20;\n\tv54 = this.Col + v45;\n\tv55 = this.Row + v47;\n\tSystem.ValueTuple`2<System.Int32, System.Int32>::.ctor(&v53 @ stack_-38_v2 (System.ValueTuple`2<System.Int32, System.Int32>), v54, v55);\n\treturn v53;\n")]
		public (int, int) GetSpawnTarget()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Tunnel::GetSpawnTarget");
			return default;
		}

		[Token(Token = "0x6000065")]
		[Address(RVA = "0x3C0CD50", Offset = "0x3C0CD50", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tSystem.Object::.ctor(v54);\n\tv54.Col = this.Col;\n\tv54.Direction = this.Direction;\n\tv92 = new System.Collections.Generic.Queue`1<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor>();\n\tSystem.Collections.Generic.Queue`1<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor>::.ctor(v92, this.Queue);\n\tv54.Queue = v92;\n\treturn v54;\nL_0023:\n\tv54 = new _game.Tools.AlgorithmicLevelGenerator.Solver.Tunnel();\n\tgoto L_0036;\nL_0036:\n\tv76 = new System.Collections.Generic.Queue`1<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor>();\n\tSystem.Collections.Generic.Queue`1<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor>::.ctor(v76);\n\tv54.Queue = v76;\n")]
		public Tunnel Clone()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Tunnel::Clone");
			return default;
		}

		[Token(Token = "0x6000066")]
		[Address(RVA = "0x3BFF8D4", Offset = "0x3BFF8D4", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.Queue`1<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor>();\n\tSystem.Collections.Generic.Queue`1<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor>::.ctor(v48);\n\tthis.Queue = v48;\n")]
		public Tunnel()
		{
			Queue<SolverColor> queue = new Queue<SolverColor>();
			Queue = queue;
		}
	}
}
