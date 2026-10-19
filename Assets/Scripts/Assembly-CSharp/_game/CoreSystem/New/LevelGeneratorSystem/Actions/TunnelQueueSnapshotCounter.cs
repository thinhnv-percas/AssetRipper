using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;
using _game.CoreSystem.LevelCreator;
using _game.CoreSystem.New.Shared.Components;
using _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags;
using _game.CoreSystem.SandSystem.Components;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Actions
{
	[Token(Token = "0x20003D0")]
	public static class TunnelQueueSnapshotCounter
	{
		[Token(Token = "0x6001027")]
		[Address(RVA = "0x3CAD468", Offset = "0x3CAD468", Length = "0x46C")]
		public static Dictionary<GameColor, int> CountByColor(LevelCreatorData data)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TunnelQueueSnapshotCounter::CountByColor");
			return default;
		}

		[Token(Token = "0x6001028")]
		[Address(RVA = "0x3CAD8D4", Offset = "0x3CAD8D4", Length = "0x274")]
		private static bool TryGetSandCubeColor(IList<IEntityData> components, out GameColor color)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TunnelQueueSnapshotCounter::TryGetSandCubeColor");
			color = default;
			return default;
		}
	}
}
