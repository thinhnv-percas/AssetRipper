using System;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;

namespace _game.CoreSystem.New.GridEcsBinding.Components
{
	[Serializable]
	[Token(Token = "0x20003DA")]
	public struct GridComponent : IEntityData
	{
		[Token(Token = "0x4000C14")]
		[FieldOffset(Offset = "0x0")]
		public int rows;

		[Token(Token = "0x4000C15")]
		[FieldOffset(Offset = "0x4")]
		public int columns;

		[Token(Token = "0x4000C16")]
		[FieldOffset(Offset = "0x8")]
		public float cellSize;

		[Token(Token = "0x4000C17")]
		[FieldOffset(Offset = "0xC")]
		public float padding;

		[Token(Token = "0x600103D")]
		[Address(RVA = "0x3CAEAF4", Offset = "0x3CAEAF4", Length = "0x64")]
		public void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GridComponent::Apply");
		}
	}
}
