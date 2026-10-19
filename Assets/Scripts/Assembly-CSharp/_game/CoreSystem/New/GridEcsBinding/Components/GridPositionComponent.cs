using System;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;

namespace _game.CoreSystem.New.GridEcsBinding.Components
{
	[Serializable]
	[Token(Token = "0x20003DC")]
	public struct GridPositionComponent : IEntityData
	{
		[Token(Token = "0x4000C19")]
		[FieldOffset(Offset = "0x0")]
		public GridCoord coord;

		[Token(Token = "0x600103F")]
		[Address(RVA = "0x3CAEBBC", Offset = "0x3CAEBBC", Length = "0x68")]
		public void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GridPositionComponent::Apply");
		}
	}
}
