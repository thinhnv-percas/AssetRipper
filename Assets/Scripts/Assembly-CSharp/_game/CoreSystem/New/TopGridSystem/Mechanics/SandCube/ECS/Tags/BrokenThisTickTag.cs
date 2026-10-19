using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;
using _game.CoreSystem.New.GridEcsBinding;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags
{
	[Token(Token = "0x200019A")]
	public struct BrokenThisTickTag : IEntityData
	{
		[Token(Token = "0x4000526")]
		[FieldOffset(Offset = "0x0")]
		public GridCoord coord;

		[Token(Token = "0x6000799")]
		[Address(RVA = "0x3E6B824", Offset = "0x3E6B824", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\nL_0024:\n\tv56 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(*([builder @ X1 (_game.BaseLayerSystems.EntitySystem.EntityBuilder&)]), this.coord);\n\treturn;\n")]
		public void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BrokenThisTickTag::Apply");
		}
	}
}
