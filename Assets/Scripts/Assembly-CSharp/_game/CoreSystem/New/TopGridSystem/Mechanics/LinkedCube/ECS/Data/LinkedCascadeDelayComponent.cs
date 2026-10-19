using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.LinkedCube.ECS.Data
{
	[Serializable]
	[Token(Token = "0x20001DB")]
	public struct LinkedCascadeDelayComponent : IEntityData
	{
		[Token(Token = "0x40005B9")]
		[FieldOffset(Offset = "0x0")]
		public float delaySeconds;

		[Token(Token = "0x40005BA")]
		[FieldOffset(Offset = "0x4")]
		public int depth;

		[Token(Token = "0x600087B")]
		[Address(RVA = "0x3E7F220", Offset = "0x3E7F220", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv55 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(*([builder @ X1 (_game.BaseLayerSystems.EntitySystem.EntityBuilder&)]), this.delaySeconds);\n\treturn;\n")]
		public void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LinkedCascadeDelayComponent::Apply");
		}
	}
}
