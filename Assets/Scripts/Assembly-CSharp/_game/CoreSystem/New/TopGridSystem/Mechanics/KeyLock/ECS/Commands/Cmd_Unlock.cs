using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.ECS.Commands
{
	[Token(Token = "0x2000202")]
	public struct Cmd_Unlock : IEntityData
	{
		[Token(Token = "0x4000662")]
		[FieldOffset(Offset = "0x0")]
		public GameColor lockColor;

		[Token(Token = "0x6000916")]
		[Address(RVA = "0x3E8D168", Offset = "0x3E8D168", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv55 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(*([builder @ X1 (_game.BaseLayerSystems.EntitySystem.EntityBuilder&)]), this.lockColor);\n\treturn;\n")]
		public void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Cmd_Unlock::Apply");
		}
	}
}
