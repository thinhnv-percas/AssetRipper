using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;
using _game.CoreSystem.New.GridEcsBinding;

namespace _game.CoreSystem.New.MoldSystem.Core.Components.Tags
{
	[Token(Token = "0x2000316")]
	public struct ShiftingTag : IEntityData
	{
		[Token(Token = "0x4000949")]
		[FieldOffset(Offset = "0x0")]
		public GridCoord toCoord;

		[Token(Token = "0x6000D60")]
		[Address(RVA = "0x3EEDCB0", Offset = "0x3EEDCB0", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\nL_0024:\n\tv56 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(*([builder @ X1 (_game.BaseLayerSystems.EntitySystem.EntityBuilder&)]), this.toCoord);\n\treturn;\n")]
		public void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ShiftingTag::Apply");
		}
	}
}
