using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Pin.ECS.Data
{
	[Serializable]
	[Token(Token = "0x20001B6")]
	public struct PinNodeComponent : IEntityData
	{
		[Token(Token = "0x4000553")]
		[FieldOffset(Offset = "0x0")]
		public int pinId;

		[Token(Token = "0x4000554")]
		[FieldOffset(Offset = "0x4")]
		public int pathIndex;

		[Token(Token = "0x4000555")]
		[FieldOffset(Offset = "0x8")]
		public bool isMarker;

		[Token(Token = "0x60007EA")]
		[Address(RVA = "0x3E71710", Offset = "0x3E71710", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\nL_0024:\n\tv56 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(*([builder @ X1 (_game.BaseLayerSystems.EntitySystem.EntityBuilder&)]), this.pinId);\n\treturn;\n")]
		public void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PinNodeComponent::Apply");
		}
	}
}
