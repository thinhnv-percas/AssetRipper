using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using _game.CoreSystem.FrameSystem.StuckAnalysis;
using _game.CoreSystem.New.GridEcsBinding;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Actions
{
	[Token(Token = "0x20003D1")]
	public static class WallDrainageReader
	{
		[Token(Token = "0x6001029")]
		[Address(RVA = "0x3CADB48", Offset = "0x3CADB48", Length = "0x35C")]
		public unsafe static WallDrainageReport Read(DrainageDetail detail, Func<float2, int2> worldToCell, int cols, int rows)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("WallDrainageReader::Read");
			return default;
		}
	}
}
