using Cpp2ILInjected;
using Unity.Mathematics;

namespace _game.CoreSystem.FrameSystem.StuckAnalysis
{
	[Token(Token = "0x20004F4")]
	public readonly struct DrainageResult
	{
		[Token(Token = "0x400109D")]
		[FieldOffset(Offset = "0x0")]
		public readonly bool FullyDrains;

		[Token(Token = "0x400109E")]
		[FieldOffset(Offset = "0x4")]
		public readonly int TrappedCellCount;

		[Token(Token = "0x400109F")]
		[FieldOffset(Offset = "0x8")]
		public readonly int OpenCellCount;

		[Token(Token = "0x40010A0")]
		[FieldOffset(Offset = "0xC")]
		public readonly float2 TrappedMin;

		[Token(Token = "0x40010A1")]
		[FieldOffset(Offset = "0x14")]
		public readonly float2 TrappedMax;

		[Token(Token = "0x60014C0")]
		[Address(RVA = "0x3CFF39C", Offset = "0x3CFF39C", Length = "0x14")]
		public DrainageResult(bool fullyDrains, int trappedCellCount, int openCellCount, float2 trappedMin, float2 trappedMax)
		{
			FullyDrains = fullyDrains;
			TrappedCellCount = trappedCellCount;
			OpenCellCount = openCellCount;
			TrappedMin = trappedMin;
			_ = trappedMin.y;
			TrappedMax = trappedMax;
			_ = trappedMax.y;
		}
	}
}
