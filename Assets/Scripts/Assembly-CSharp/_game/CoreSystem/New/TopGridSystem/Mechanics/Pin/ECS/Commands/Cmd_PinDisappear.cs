using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Commands
{
	[Token(Token = "0x20001B7")]
	public struct Cmd_PinDisappear : IEntityData
	{
		[Token(Token = "0x4000556")]
		[FieldOffset(Offset = "0x0")]
		public int pinId;

		[Token(Token = "0x60007EB")]
		[Address(RVA = "0x3E71778", Offset = "0x3E71778", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv55 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(*([builder @ X1 (_game.BaseLayerSystems.EntitySystem.EntityBuilder&)]), this.pinId);\n\treturn;\n")]
		public void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Cmd_PinDisappear::Apply");
		}
	}
}
