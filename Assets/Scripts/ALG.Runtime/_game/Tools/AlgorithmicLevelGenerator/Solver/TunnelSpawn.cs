using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Solver
{
	[Token(Token = "0x200002A")]
	public class TunnelSpawn
	{
		[Token(Token = "0x40000E8")]
		[FieldOffset(Offset = "0x10")]
		public TunnelLocation Tunnel;

		[Token(Token = "0x40000E9")]
		[FieldOffset(Offset = "0x18")]
		public TappedCube Spawned;

		[Token(Token = "0x40000EA")]
		[FieldOffset(Offset = "0x20")]
		public int QueueRemaining;

		[Token(Token = "0x600005F")]
		[Address(RVA = "0x3C05F1C", Offset = "0x3C05F1C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public TunnelSpawn()
		{
		}
	}
}
