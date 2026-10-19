using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;
using _game.CoreSystem.New.GridEcsBinding;

namespace _game.CoreSystem.New.MoldSystem.Core.Components
{
	[Token(Token = "0x200030E")]
	public struct VisualPositionComponent : IEntityData
	{
		[Token(Token = "0x4000948")]
		[FieldOffset(Offset = "0x0")]
		public GridCoord coord;

		[Token(Token = "0x6000D58")]
		[Address(RVA = "0x3EED98C", Offset = "0x3EED98C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\nL_0024:\n\tv56 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(*([builder @ X1 (_game.BaseLayerSystems.EntitySystem.EntityBuilder&)]), this.coord);\n\treturn;\n")]
		public void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VisualPositionComponent::Apply");
		}
	}
}
