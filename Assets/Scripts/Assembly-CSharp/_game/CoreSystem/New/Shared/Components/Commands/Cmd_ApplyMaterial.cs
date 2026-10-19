using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;

namespace _game.CoreSystem.New.Shared.Components.Commands
{
	[Token(Token = "0x200029E")]
	public struct Cmd_ApplyMaterial : IEntityData
	{
		[Token(Token = "0x4000810")]
		[FieldOffset(Offset = "0x0")]
		public GameColor color;

		[Token(Token = "0x4000811")]
		[FieldOffset(Offset = "0x4")]
		public bool isHidden;

		[Token(Token = "0x6000B89")]
		[Address(RVA = "0x3EC7A84", Offset = "0x3EC7A84", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv55 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(*([builder @ X1 (_game.BaseLayerSystems.EntitySystem.EntityBuilder&)]), this.color);\n\treturn;\n")]
		public void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Cmd_ApplyMaterial::Apply");
		}
	}
}
