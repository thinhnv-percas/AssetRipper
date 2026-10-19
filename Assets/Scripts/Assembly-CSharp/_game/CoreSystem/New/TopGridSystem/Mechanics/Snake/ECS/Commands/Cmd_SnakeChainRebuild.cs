using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.ECS.Commands
{
	[Token(Token = "0x200017D")]
	public struct Cmd_SnakeChainRebuild : IEntityData
	{
		[Token(Token = "0x40004A4")]
		[FieldOffset(Offset = "0x0")]
		public int snakeId;

		[Token(Token = "0x40004A5")]
		[FieldOffset(Offset = "0x4")]
		public bool snakeRemoved;

		[Token(Token = "0x40004A6")]
		[FieldOffset(Offset = "0x8")]
		public float waveDurationSeconds;

		[Token(Token = "0x600072C")]
		[Address(RVA = "0x3E6208C", Offset = "0x3E6208C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\nL_0024:\n\tv56 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(*([builder @ X1 (_game.BaseLayerSystems.EntitySystem.EntityBuilder&)]), this.snakeId);\n\treturn;\n")]
		public void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Cmd_SnakeChainRebuild::Apply");
		}
	}
}
