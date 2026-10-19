using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Core;

namespace _game.CoreSystem.New.MoldSystem.Core.Components
{
	[Token(Token = "0x2000307")]
	public struct BoundMoldComponent : IEntityData
	{
		[Token(Token = "0x400093C")]
		[FieldOffset(Offset = "0x0")]
		public EntityId moldEntityId;

		[Token(Token = "0x6000D51")]
		[Address(RVA = "0x3EED72C", Offset = "0x3EED72C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv55 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(*([builder @ X1 (_game.BaseLayerSystems.EntitySystem.EntityBuilder&)]), this.moldEntityId);\n\treturn;\n")]
		public void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("BoundMoldComponent::Apply");
		}
	}
}
