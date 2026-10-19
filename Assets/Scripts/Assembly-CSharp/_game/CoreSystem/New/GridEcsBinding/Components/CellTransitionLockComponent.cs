using System;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;

namespace _game.CoreSystem.New.GridEcsBinding.Components
{
	[Serializable]
	[Token(Token = "0x20003D8")]
	public struct CellTransitionLockComponent : IEntityData
	{
		[Token(Token = "0x4000C13")]
		[FieldOffset(Offset = "0x0")]
		public float secondsRemaining;

		[Token(Token = "0x600103B")]
		[Address(RVA = "0x3CAEA2C", Offset = "0x3CAEA2C", Length = "0x64")]
		public void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CellTransitionLockComponent::Apply");
		}
	}
}
