using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Core;

namespace _game.CoreSystem.New.MoldSystem.Core.Components
{
	[Serializable]
	[Token(Token = "0x200030A")]
	public struct MoldLinkedComponent : IEntityData
	{
		[Token(Token = "0x4000942")]
		[FieldOffset(Offset = "0x0")]
		public EntityId partnerEntityId;

		[Token(Token = "0x6000D54")]
		[Address(RVA = "0x3EED858", Offset = "0x3EED858", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.partnerEntityId = partnerEntityId;\n\treturn;\n")]
		public MoldLinkedComponent(EntityId partnerEntityId)
		{
			this.partnerEntityId = partnerEntityId;
		}

		[Token(Token = "0x6000D55")]
		[Address(RVA = "0x3EED860", Offset = "0x3EED860", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv55 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(*([builder @ X1 (_game.BaseLayerSystems.EntitySystem.EntityBuilder&)]), this.partnerEntityId);\n\treturn;\n")]
		public void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MoldLinkedComponent::Apply");
		}
	}
}
