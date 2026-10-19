using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Commands
{
	[Token(Token = "0x20001A6")]
	public struct Cmd_Reveal : IEntityData
	{
		[Token(Token = "0x4000528")]
		[FieldOffset(Offset = "0x0")]
		public GameColor color;

		[Token(Token = "0x4000529")]
		[FieldOffset(Offset = "0x4")]
		public bool scheduled;

		[Token(Token = "0x60007A5")]
		[Address(RVA = "0x3E6BCD8", Offset = "0x3E6BCD8", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv55 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(*([builder @ X1 (_game.BaseLayerSystems.EntitySystem.EntityBuilder&)]), this.color);\n\treturn;\n")]
		public void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Cmd_Reveal::Apply");
		}
	}
}
