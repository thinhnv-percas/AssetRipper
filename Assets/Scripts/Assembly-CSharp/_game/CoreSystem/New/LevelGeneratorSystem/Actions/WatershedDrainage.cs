using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using _game.CoreSystem.FrameSystem;
using _game.CoreSystem.FrameSystem.StuckAnalysis;
using _game.CoreSystem.LevelCreator;
using _game.CoreSystem.New.GridEcsBinding;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Actions
{
	[Token(Token = "0x20003D3")]
	public static class WatershedDrainage
	{
		[Token(Token = "0x600102B")]
		[Address(RVA = "0x3CADFB4", Offset = "0x3CADFB4", Length = "0x550")]
		public unsafe static WallDrainageReport Check(FrameData frame, GridData<SandCubeCellData> grid, Func<GridCoord, bool> isNoPlace)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("WatershedDrainage::Check");
			return default;
		}
	}
}
