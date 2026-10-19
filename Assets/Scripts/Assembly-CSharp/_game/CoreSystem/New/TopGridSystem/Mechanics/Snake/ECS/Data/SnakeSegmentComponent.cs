using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;
using _game.CoreSystem.New.GridEcsBinding;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.ECS.Data
{
	[Serializable]
	[Token(Token = "0x200017B")]
	public struct SnakeSegmentComponent : IEntityData
	{
		[Token(Token = "0x40004A2")]
		[FieldOffset(Offset = "0x0")]
		public int snakeId;

		[Token(Token = "0x40004A3")]
		[FieldOffset(Offset = "0x4")]
		public GridCoord next;

		[Token(Token = "0x600072A")]
		[Address(RVA = "0x3E62028", Offset = "0x3E62028", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\nL_0024:\n\tv56 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(*([builder @ X1 (_game.BaseLayerSystems.EntitySystem.EntityBuilder&)]), this.snakeId);\n\treturn;\n")]
		public void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SnakeSegmentComponent::Apply");
		}
	}
}
