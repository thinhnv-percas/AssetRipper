using System;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;

namespace _game.CoreSystem.New.GridEcsBinding.Components
{
	[Serializable]
	[Token(Token = "0x20003D7")]
	public struct CellStateChangedThisTickTag : IEntityData
	{
		[Token(Token = "0x4000C11")]
		[FieldOffset(Offset = "0x0")]
		public bool wasBusy;

		[Token(Token = "0x4000C12")]
		[FieldOffset(Offset = "0x1")]
		public bool isBusy;

		[Token(Token = "0x600103A")]
		[Address(RVA = "0x3CAE9C8", Offset = "0x3CAE9C8", Length = "0x64")]
		public void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CellStateChangedThisTickTag::Apply");
		}
	}
}
