using System;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;

namespace _game.CoreSystem.New.GridEcsBinding.Components
{
	[Serializable]
	[Token(Token = "0x20003DB")]
	public struct GridIdComponent : IEntityData
	{
		[Token(Token = "0x4000C18")]
		[FieldOffset(Offset = "0x0")]
		public uint id;

		[Token(Token = "0x600103E")]
		[Address(RVA = "0x3CAEB58", Offset = "0x3CAEB58", Length = "0x64")]
		public void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GridIdComponent::Apply");
		}
	}
}
