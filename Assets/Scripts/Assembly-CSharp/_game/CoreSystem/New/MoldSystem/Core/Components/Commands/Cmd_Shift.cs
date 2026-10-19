using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;
using _game.CoreSystem.New.GridEcsBinding;

namespace _game.CoreSystem.New.MoldSystem.Core.Components.Commands
{
	[Token(Token = "0x2000325")]
	public struct Cmd_Shift : IEntityData
	{
		[Token(Token = "0x400094B")]
		[FieldOffset(Offset = "0x0")]
		public GridCoord toCoord;

		[Token(Token = "0x6000D6F")]
		[Address(RVA = "0x3EEE290", Offset = "0x3EEE290", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\nL_0024:\n\tv56 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(*([builder @ X1 (_game.BaseLayerSystems.EntitySystem.EntityBuilder&)]), this.toCoord);\n\treturn;\n")]
		public void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Cmd_Shift::Apply");
		}
	}
}
