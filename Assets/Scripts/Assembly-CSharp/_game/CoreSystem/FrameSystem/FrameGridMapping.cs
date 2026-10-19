using System;
using Cpp2ILInjected;
using Unity.Mathematics;

namespace _game.CoreSystem.FrameSystem
{
	[Token(Token = "0x20004E3")]
	public static class FrameGridMapping
	{
		[Token(Token = "0x60014A0")]
		[Address(RVA = "0x3CFB1A0", Offset = "0x3CFB1A0", Length = "0x278")]
		public static int2 WorldToCell(float2 world, float4x4 worldToLocal, float cellSize, int columns, int rows)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FrameGridMapping::WorldToCell");
			return default;
		}
	}
}
