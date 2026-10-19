using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Commands
{
	[Token(Token = "0x200021B")]
	public struct Cmd_HammerAreaOpen : IEntityData
	{
		[Token(Token = "0x4000694")]
		[FieldOffset(Offset = "0x0")]
		public int groupId;

		[Token(Token = "0x600095E")]
		[Address(RVA = "0x3E92C28", Offset = "0x3E92C28", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv55 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(*([builder @ X1 (_game.BaseLayerSystems.EntitySystem.EntityBuilder&)]), this.groupId);\n\treturn;\n")]
		public void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Cmd_HammerAreaOpen::Apply");
		}
	}
}
