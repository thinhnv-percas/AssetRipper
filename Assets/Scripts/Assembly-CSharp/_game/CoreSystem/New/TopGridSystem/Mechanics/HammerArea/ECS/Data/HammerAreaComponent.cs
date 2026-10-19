using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.HammerArea.ECS.Data
{
	[Serializable]
	[Token(Token = "0x2000219")]
	public struct HammerAreaComponent : IEntityData
	{
		[Token(Token = "0x400068C")]
		[FieldOffset(Offset = "0x0")]
		public int groupId;

		[Token(Token = "0x400068D")]
		[FieldOffset(Offset = "0x4")]
		public int dataCounter;

		[Token(Token = "0x400068E")]
		[FieldOffset(Offset = "0x8")]
		public int visualCounter;

		[Token(Token = "0x400068F")]
		[FieldOffset(Offset = "0xC")]
		public int launchCounter;

		[Token(Token = "0x4000690")]
		[FieldOffset(Offset = "0x10")]
		public int maxCounter;

		[Token(Token = "0x4000691")]
		[FieldOffset(Offset = "0x14")]
		public int sizeX;

		[Token(Token = "0x4000692")]
		[FieldOffset(Offset = "0x18")]
		public int sizeY;

		[Token(Token = "0x600095C")]
		[Address(RVA = "0x3E92B44", Offset = "0x3E92B44", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001B:\n\tv48 = this.groupId;\n\tv53 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(*([builder @ X1 (_game.BaseLayerSystems.EntitySystem.EntityBuilder&)]), &v48 @ stack_-50_v1 (System.Int32));\n\treturn;\n")]
		public unsafe void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("HammerAreaComponent::Apply");
		}
	}
}
