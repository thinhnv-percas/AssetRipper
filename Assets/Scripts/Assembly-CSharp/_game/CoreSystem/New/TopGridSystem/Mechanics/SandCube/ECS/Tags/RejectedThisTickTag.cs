using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;
using _game.CoreSystem.New.TopGridSystem.Core.Conditions;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.SandCube.ECS.Tags
{
	[Token(Token = "0x200019F")]
	public struct RejectedThisTickTag : IEntityData
	{
		[Token(Token = "0x4000527")]
		[FieldOffset(Offset = "0x0")]
		public BlockReason reason;

		[Token(Token = "0x600079E")]
		[Address(RVA = "0x3E6BA1C", Offset = "0x3E6BA1C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv55 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(*([builder @ X1 (_game.BaseLayerSystems.EntitySystem.EntityBuilder&)]), this.reason);\n\treturn;\n")]
		public void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RejectedThisTickTag::Apply");
		}
	}
}
