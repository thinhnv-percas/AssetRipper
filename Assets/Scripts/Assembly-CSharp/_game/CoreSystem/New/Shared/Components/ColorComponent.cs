using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;

namespace _game.CoreSystem.New.Shared.Components
{
	[Serializable]
	[Token(Token = "0x2000297")]
	public struct ColorComponent : IEntityData
	{
		[Token(Token = "0x400080F")]
		[FieldOffset(Offset = "0x0")]
		public GameColor color;

		[Token(Token = "0x6000B82")]
		[Address(RVA = "0x3EC77C8", Offset = "0x3EC77C8", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv55 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(*([builder @ X1 (_game.BaseLayerSystems.EntitySystem.EntityBuilder&)]), this.color);\n\treturn;\n")]
		public void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ColorComponent::Apply");
		}
	}
}
