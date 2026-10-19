using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Data
{
	[Serializable]
	[Token(Token = "0x2000234")]
	public struct GarageComponent : IEntityData
	{
		[Token(Token = "0x40006D0")]
		[FieldOffset(Offset = "0x0")]
		public int groupId;

		[Token(Token = "0x40006D1")]
		[FieldOffset(Offset = "0x4")]
		public int counter;

		[Token(Token = "0x40006D2")]
		[FieldOffset(Offset = "0x8")]
		public int sizeX;

		[Token(Token = "0x40006D3")]
		[FieldOffset(Offset = "0xC")]
		public int sizeY;

		[Token(Token = "0x60009B4")]
		[Address(RVA = "0x3E99DF0", Offset = "0x3E99DF0", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\nL_0024:\n\tv56 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(*([builder @ X1 (_game.BaseLayerSystems.EntitySystem.EntityBuilder&)]), this.groupId);\n\treturn;\n")]
		public void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GarageComponent::Apply");
		}
	}
}
