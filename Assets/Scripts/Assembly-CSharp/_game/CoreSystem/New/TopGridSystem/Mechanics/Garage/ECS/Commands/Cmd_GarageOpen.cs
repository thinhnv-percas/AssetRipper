using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Garage.ECS.Commands
{
	[Token(Token = "0x2000236")]
	public struct Cmd_GarageOpen : IEntityData
	{
		[Token(Token = "0x40006D5")]
		[FieldOffset(Offset = "0x0")]
		public int groupId;

		[Token(Token = "0x60009B6")]
		[Address(RVA = "0x3E99EB8", Offset = "0x3E99EB8", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv55 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(*([builder @ X1 (_game.BaseLayerSystems.EntitySystem.EntityBuilder&)]), this.groupId);\n\treturn;\n")]
		public void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Cmd_GarageOpen::Apply");
		}
	}
}
