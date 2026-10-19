using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.KeyLock.ECS.Tags
{
	[Token(Token = "0x20001FC")]
	public struct WaitingForUnlockOpenTag : IEntityData
	{
		[Token(Token = "0x400065C")]
		[FieldOffset(Offset = "0x0")]
		public GameColor color;

		[Token(Token = "0x600090E")]
		[Address(RVA = "0x3E8C90C", Offset = "0x3E8C90C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv55 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(*([builder @ X1 (_game.BaseLayerSystems.EntitySystem.EntityBuilder&)]), this.color);\n\treturn;\n")]
		public void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("WaitingForUnlockOpenTag::Apply");
		}
	}
}
