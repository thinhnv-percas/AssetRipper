using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Data
{
	[Serializable]
	[Token(Token = "0x200021A")]
	public struct HammerAreaGroupIdComponent : IEntityData
	{
		[Token(Token = "0x4000693")]
		[FieldOffset(Offset = "0x0")]
		public int groupId;

		[Token(Token = "0x600095D")]
		[Address(RVA = "0x3E92BC4", Offset = "0x3E92BC4", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv55 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(*([builder @ X1 (_game.BaseLayerSystems.EntitySystem.EntityBuilder&)]), this.groupId);\n\treturn;\n")]
		public void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HammerAreaGroupIdComponent::Apply");
		}
	}
}
