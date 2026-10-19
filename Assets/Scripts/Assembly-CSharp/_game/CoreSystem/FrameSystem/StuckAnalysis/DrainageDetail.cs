using Cpp2ILInjected;
using Unity.Mathematics;

namespace _game.CoreSystem.FrameSystem.StuckAnalysis
{
	[Token(Token = "0x20004F3")]
	public sealed class DrainageDetail
	{
		[Token(Token = "0x4001093")]
		[FieldOffset(Offset = "0x10")]
		public readonly int Cols;

		[Token(Token = "0x4001094")]
		[FieldOffset(Offset = "0x14")]
		public readonly int Rows;

		[Token(Token = "0x4001095")]
		[FieldOffset(Offset = "0x18")]
		public readonly float CellSize;

		[Token(Token = "0x4001096")]
		[FieldOffset(Offset = "0x1C")]
		public readonly float2 Origin;

		[Token(Token = "0x4001097")]
		[FieldOffset(Offset = "0x28")]
		public readonly bool[,] Open;

		[Token(Token = "0x4001098")]
		[FieldOffset(Offset = "0x30")]
		public readonly bool[,] Drained;

		[Token(Token = "0x4001099")]
		[FieldOffset(Offset = "0x38")]
		public readonly bool[,] CubeReach;

		[Token(Token = "0x400109A")]
		[FieldOffset(Offset = "0x40")]
		public readonly bool[,] Playable;

		[Token(Token = "0x400109B")]
		[FieldOffset(Offset = "0x48")]
		public readonly float[,] RetainDepth;

		[Token(Token = "0x400109C")]
		[FieldOffset(Offset = "0x50")]
		public readonly DrainageResult Summary;

		[Token(Token = "0x60014BD")]
		[Address(RVA = "0x3CFF0F4", Offset = "0x3CFF0F4", Length = "0x11C")]
		public DrainageDetail(float2 origin, float cellSize, bool[,] open, bool[,] drained, bool[,] cubeReach, bool[,] playable, DrainageResult summary, float[,] retainDepth = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DrainageDetail::.ctor");
		}

		[Token(Token = "0x60014BE")]
		[Address(RVA = "0x3CFF210", Offset = "0x3CFF210", Length = "0x30")]
		public float2 CellCenter(int i, int j)
		{
			float num = (float)i + 0.5f;
			float num2 = num * CellSize;
			float x = Origin.x + num2;
			float2 result = default(float2);
			result.x = x;
			return result;
		}

		[Token(Token = "0x60014BF")]
		[Address(RVA = "0x3CFF240", Offset = "0x3CFF240", Length = "0x15C")]
		public unsafe static DrainageDetail Empty(DrainageResult summary)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("DrainageDetail::Empty");
			return default;
		}
	}
}
