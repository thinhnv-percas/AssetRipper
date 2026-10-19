using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.Tools.AlgorithmicLevelGenerator.Solver;

namespace _game.Tools.AlgorithmicLevelGenerator.Generator
{
	[Token(Token = "0x200005C")]
	public class Template
	{
		[Token(Token = "0x4000176")]
		[FieldOffset(Offset = "0x10")]
		public string TemplateId;

		[Token(Token = "0x4000177")]
		[FieldOffset(Offset = "0x18")]
		public int GridCols;

		[Token(Token = "0x4000178")]
		[FieldOffset(Offset = "0x1C")]
		public int GridRows;

		[Token(Token = "0x4000179")]
		[FieldOffset(Offset = "0x20")]
		public List<CubeSlot> CubeSlots;

		[Token(Token = "0x400017A")]
		[FieldOffset(Offset = "0x28")]
		public List<TunnelSlot> TunnelSlots;

		[Token(Token = "0x400017B")]
		[FieldOffset(Offset = "0x30")]
		public HashSet<(int Col, int Row)> Walls;

		[Token(Token = "0x400017C")]
		[FieldOffset(Offset = "0x38")]
		public int MoldCellsTotal;

		[Token(Token = "0x400017D")]
		[FieldOffset(Offset = "0x40")]
		public List<MoldCellSlot> MoldSlots;

		[Token(Token = "0x400017E")]
		[FieldOffset(Offset = "0x48")]
		public int MoldGridColumns;

		[Token(Token = "0x400017F")]
		[FieldOffset(Offset = "0x4C")]
		public int FrameConveyorCapacity;

		[Token(Token = "0x4000180")]
		[FieldOffset(Offset = "0x50")]
		public List<int[][]> Bonds;

		[Token(Token = "0x4000181")]
		[FieldOffset(Offset = "0x58")]
		public List<PinSlot> PinSlots;

		[Token(Token = "0x4000182")]
		[FieldOffset(Offset = "0x60")]
		public List<ParsedHammerArea> HammerAreas;

		[Token(Token = "0x60000EC")]
		[Address(RVA = "0x3C1BF10", Offset = "0x3C1BF10", Length = "0x278")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0052;\n\tv89 = new System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Generator.TunnelSlot>();\n\tSystem.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Generator.TunnelSlot>::.ctor(v89);\n\tthis.TunnelSlots = v89;\n\tv106 = new System.Collections.Generic.HashSet`1<System.ValueTuple`2<System.Int32, System.Int32>>();\n\tSystem.Collections.Generic.HashSet`1<System.ValueTuple`2<System.Int32, System.Int32>>::.ctor(v106);\n\tthis.Walls = v106;\n\tv123 = new System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Generator.MoldCellSlot>();\n\tSystem.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Generator.MoldCellSlot>::.ctor(v123);\n\tthis.MoldSlots = v123;\n\tthis.MoldGridColumns = 2.54639494936E-313d;\n\tv144 = new System.Collections.Generic.List`1<System.Int32[][]>();\n\tSystem.Collections.Generic.List`1<System.Int32[][]>::.ctor(v144);\n\tthis.Bonds = v144;\n\tv158 = new System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Generator.PinSlot>();\n\tSystem.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Generator.PinSlot>::.ctor(v158);\n\tthis.PinSlots = v158;\n\tv170 = new System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.ParsedHammerArea>();\n\tSystem.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Solver.ParsedHammerArea>::.ctor(v170);\n\tthis.HammerAreas = v170;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_0052:\n\tv72 = new System.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Generator.CubeSlot>();\n\tSystem.Collections.Generic.List`1<_game.Tools.AlgorithmicLevelGenerator.Generator.CubeSlot>::.ctor(v72);\n\tthis.CubeSlots = v72;\n")]
		public Template()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Template::.ctor");
		}
	}
}
