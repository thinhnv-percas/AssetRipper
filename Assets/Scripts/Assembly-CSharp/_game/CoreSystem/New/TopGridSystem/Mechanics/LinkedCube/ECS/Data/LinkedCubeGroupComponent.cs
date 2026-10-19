using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.ECS.Data
{
	[Serializable]
	[Token(Token = "0x20001DC")]
	public struct LinkedCubeGroupComponent : IEntityData
	{
		[Token(Token = "0x40005BB")]
		[FieldOffset(Offset = "0x0")]
		public int groupId;

		[Token(Token = "0x600087C")]
		[Address(RVA = "0x3E7F284", Offset = "0x3E7F284", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv55 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(*([builder @ X1 (_game.BaseLayerSystems.EntitySystem.EntityBuilder&)]), this.groupId);\n\treturn;\n")]
		public void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LinkedCubeGroupComponent::Apply");
		}
	}
}
