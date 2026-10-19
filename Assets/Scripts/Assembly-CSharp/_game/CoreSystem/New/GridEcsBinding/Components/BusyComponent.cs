using System;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;

namespace _game.CoreSystem.New.GridEcsBinding.Components
{
	[Serializable]
	[Token(Token = "0x20003D6")]
	public struct BusyComponent : IEntityData
	{
		[Token(Token = "0x4000C10")]
		[FieldOffset(Offset = "0x0")]
		public bool isBusy;

		[Token(Token = "0x6001039")]
		[Address(RVA = "0x3CAE964", Offset = "0x3CAE964", Length = "0x64")]
		public void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BusyComponent::Apply");
		}
	}
}
