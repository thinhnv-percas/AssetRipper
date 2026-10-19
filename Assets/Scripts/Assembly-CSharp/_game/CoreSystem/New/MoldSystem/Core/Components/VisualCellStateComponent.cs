using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;

namespace _game.CoreSystem.New.MoldSystem.Core.Components
{
	[Token(Token = "0x200030D")]
	public struct VisualCellStateComponent : IEntityData
	{
		[Token(Token = "0x4000947")]
		[FieldOffset(Offset = "0x0")]
		public VisualCellState state;

		[Token(Token = "0x6000D57")]
		[Address(RVA = "0x3EED928", Offset = "0x3EED928", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv55 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(*([builder @ X1 (_game.BaseLayerSystems.EntitySystem.EntityBuilder&)]), this.state);\n\treturn;\n")]
		public void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VisualCellStateComponent::Apply");
		}
	}
}
