using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;
using _game.CoreSystem.New.GridEcsBinding;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.ECS.Commands
{
	[Token(Token = "0x200017E")]
	public struct Cmd_SnakeShift : IEntityData
	{
		[Token(Token = "0x40004A7")]
		[FieldOffset(Offset = "0x0")]
		public GridCoord fromCoord;

		[Token(Token = "0x40004A8")]
		[FieldOffset(Offset = "0xC")]
		public GridCoord toCoord;

		[Token(Token = "0x40004A9")]
		[FieldOffset(Offset = "0x18")]
		public int snakeId;

		[Token(Token = "0x40004AA")]
		[FieldOffset(Offset = "0x1C")]
		public int delayIndex;

		[Token(Token = "0x40004AB")]
		[FieldOffset(Offset = "0x20")]
		public bool isTail;

		[Token(Token = "0x600072D")]
		[Address(RVA = "0x3E620F4", Offset = "0x3E620F4", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tv49 = this.fromCoord;\n\tv55 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(*([builder @ X1 (_game.BaseLayerSystems.EntitySystem.EntityBuilder&)]), &v49 @ stack_-60_v1 (_game.CoreSystem.New.GridEcsBinding.GridCoord));\n\treturn;\n")]
		public unsafe void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("Cmd_SnakeShift::Apply");
		}
	}
}
