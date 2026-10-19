using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Core;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Commands
{
	[Token(Token = "0x200016C")]
	public struct Cmd_TunnelSpawn : IEntityData
	{
		[Token(Token = "0x400047A")]
		[FieldOffset(Offset = "0x0")]
		public EntityId tunnelId;

		[Token(Token = "0x60006E8")]
		[Address(RVA = "0x3E5853C", Offset = "0x3E5853C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv55 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(*([builder @ X1 (_game.BaseLayerSystems.EntitySystem.EntityBuilder&)]), this.tunnelId);\n\treturn;\n")]
		public void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Cmd_TunnelSpawn::Apply");
		}
	}
}
