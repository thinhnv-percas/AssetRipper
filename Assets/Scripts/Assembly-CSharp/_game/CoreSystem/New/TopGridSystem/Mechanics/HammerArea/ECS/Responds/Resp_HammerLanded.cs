using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Responds
{
	[Token(Token = "0x2000218")]
	public struct Resp_HammerLanded : IEntityData
	{
		[Token(Token = "0x400068B")]
		[FieldOffset(Offset = "0x0")]
		public int count;

		[Token(Token = "0x600095B")]
		[Address(RVA = "0x3E92AE0", Offset = "0x3E92AE0", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv55 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(*([builder @ X1 (_game.BaseLayerSystems.EntitySystem.EntityBuilder&)]), this.count);\n\treturn;\n")]
		public void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Resp_HammerLanded::Apply");
		}
	}
}
