using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Solver
{
	[Token(Token = "0x2000026")]
	public class TapResult
	{
		[Token(Token = "0x40000D2")]
		[FieldOffset(Offset = "0x10")]
		public TappedCube Cube;

		[Token(Token = "0x40000D3")]
		[FieldOffset(Offset = "0x18")]
		public int ParticlesProduced;

		[Token(Token = "0x40000D4")]
		[FieldOffset(Offset = "0x20")]
		public List<MoldFill> MoldFills;

		[Token(Token = "0x40000D5")]
		[FieldOffset(Offset = "0x28")]
		public List<MoldActivation> MoldActivations;

		[Token(Token = "0x40000D6")]
		[FieldOffset(Offset = "0x30")]
		public List<NewPourable> NewPourable;

		[Token(Token = "0x40000D7")]
		[FieldOffset(Offset = "0x38")]
		public List<TunnelSpawn> TunnelSpawns;

		[Token(Token = "0x40000D8")]
		[FieldOffset(Offset = "0x40")]
		public List<IceHit> IceHits;

		[Token(Token = "0x40000D9")]
		[FieldOffset(Offset = "0x48")]
		public SolverColor KeyUnlock;

		[Token(Token = "0x40000DA")]
		[FieldOffset(Offset = "0x50")]
		public List<SolverColor> KeyUnlocks;

		[Token(Token = "0x40000DB")]
		[FieldOffset(Offset = "0x58")]
		public List<CoverReveal> CoverReveals;

		[Token(Token = "0x40000DC")]
		[FieldOffset(Offset = "0x60")]
		public List<TappedCube> BondedCluster;

		[Token(Token = "0x600005B")]
		[Address(RVA = "0x3C05C14", Offset = "0x3C05C14", Length = "0x26C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0052;\n\tv89 = new System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.MoldActivation>();\n\tSystem.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.MoldActivation>::.ctor(v89);\n\tthis.MoldActivations = v89;\n\tv106 = new System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.NewPourable>();\n\tSystem.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.NewPourable>::.ctor(v106);\n\tthis.NewPourable = v106;\n\tv123 = new System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.TunnelSpawn>();\n\tSystem.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.TunnelSpawn>::.ctor(v123);\n\tthis.TunnelSpawns = v123;\n\tv142 = new System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.IceHit>();\n\tSystem.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.IceHit>::.ctor(v142);\n\tthis.IceHits = v142;\n\tv156 = new System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor>();\n\tSystem.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.SolverColor>::.ctor(v156);\n\tthis.KeyUnlocks = v156;\n\tv168 = new System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.CoverReveal>();\n\tSystem.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.CoverReveal>::.ctor(v168);\n\tthis.CoverReveals = v168;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_0052:\n\tv72 = new System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.MoldFill>();\n\tSystem.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.MoldFill>::.ctor(v72);\n\tthis.MoldFills = v72;\n")]
		public TapResult()
		{
			List<MoldFill> moldFills = new List<MoldFill>();
			MoldFills = moldFills;
			MoldActivations = new List<MoldActivation>();
			NewPourable = new List<NewPourable>();
			TunnelSpawns = new List<TunnelSpawn>();
			IceHits = new List<IceHit>();
			KeyUnlocks = new List<SolverColor>();
			CoverReveals = new List<CoverReveal>();
		}
	}
}
