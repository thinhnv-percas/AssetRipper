using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Solver
{
	[Token(Token = "0x200001A")]
	public class SolutionStep
	{
		[Token(Token = "0x4000086")]
		[FieldOffset(Offset = "0x10")]
		public int Step;

		[Token(Token = "0x4000087")]
		[FieldOffset(Offset = "0x18")]
		public string Action;

		[Token(Token = "0x4000088")]
		[FieldOffset(Offset = "0x20")]
		public TappedCube Cube;

		[Token(Token = "0x4000089")]
		[FieldOffset(Offset = "0x28")]
		public string Reason;

		[Token(Token = "0x400008A")]
		[FieldOffset(Offset = "0x30")]
		public int ParticlesProduced;

		[Token(Token = "0x400008B")]
		[FieldOffset(Offset = "0x38")]
		public List<MoldFill> MoldFills;

		[Token(Token = "0x400008C")]
		[FieldOffset(Offset = "0x40")]
		public List<MoldActivation> MoldActivations;

		[Token(Token = "0x400008D")]
		[FieldOffset(Offset = "0x48")]
		public List<NewPourable> NewPourable;

		[Token(Token = "0x400008E")]
		[FieldOffset(Offset = "0x50")]
		public List<TunnelSpawn> TunnelSpawns;

		[Token(Token = "0x400008F")]
		[FieldOffset(Offset = "0x58")]
		public SolverColor KeyUnlock;

		[Token(Token = "0x4000090")]
		[FieldOffset(Offset = "0x60")]
		public List<SolverColor> KeyUnlocks;

		[Token(Token = "0x4000091")]
		[FieldOffset(Offset = "0x68")]
		public List<CoverReveal> CoverReveals;

		[Token(Token = "0x4000092")]
		[FieldOffset(Offset = "0x70")]
		public List<string> ActiveFrontMoldsAfter;

		[Token(Token = "0x4000093")]
		[FieldOffset(Offset = "0x78")]
		public ConveyorState Conveyor;

		[Token(Token = "0x4000094")]
		[FieldOffset(Offset = "0x80")]
		public Dictionary<string, int> RemainingSupply;

		[Token(Token = "0x4000095")]
		[FieldOffset(Offset = "0x88")]
		public Dictionary<string, int> RemainingDemand;

		[Token(Token = "0x4000096")]
		[FieldOffset(Offset = "0x90")]
		public List<TappedCube> BondedCluster;

		[Token(Token = "0x4000097")]
		[FieldOffset(Offset = "0x98")]
		public List<LinkedMoldStateEntry> LinkedMoldState;

		[Token(Token = "0x600004D")]
		[Address(RVA = "0x3C0B6F8", Offset = "0x3C0B6F8", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tthis.Action = \"tap\";\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SolutionStep()
		{
			Action = "tap";
		}
	}
}
