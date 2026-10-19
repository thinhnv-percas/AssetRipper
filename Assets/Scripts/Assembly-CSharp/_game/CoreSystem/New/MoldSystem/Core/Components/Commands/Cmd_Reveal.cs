using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;

namespace _game.CoreSystem.New.MoldSystem.Core.Components.Commands
{
	[Token(Token = "0x2000324")]
	public struct Cmd_Reveal : IEntityData
	{
		[Token(Token = "0x400094A")]
		[FieldOffset(Offset = "0x0")]
		public GameColor color;

		[Token(Token = "0x6000D6E")]
		[Address(RVA = "0x3EEE22C", Offset = "0x3EEE22C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv55 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(*([builder @ X1 (_game.BaseLayerSystems.EntitySystem.EntityBuilder&)]), this.color);\n\treturn;\n")]
		public void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Cmd_Reveal::Apply");
		}
	}
}
