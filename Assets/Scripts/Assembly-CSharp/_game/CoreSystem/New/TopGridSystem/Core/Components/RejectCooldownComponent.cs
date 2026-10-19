using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;

namespace _game.CoreSystem.New.TopGridSystem.Core.Components
{
	[Token(Token = "0x200027E")]
	public struct RejectCooldownComponent : IEntityData
	{
		[Token(Token = "0x40007EF")]
		[FieldOffset(Offset = "0x0")]
		public int framesLeft;

		[Token(Token = "0x6000B31")]
		[Address(RVA = "0x3EC4EA4", Offset = "0x3EC4EA4", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv55 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(*([builder @ X1 (_game.BaseLayerSystems.EntitySystem.EntityBuilder&)]), this.framesLeft);\n\treturn;\n")]
		public void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("RejectCooldownComponent::Apply");
		}
	}
}
