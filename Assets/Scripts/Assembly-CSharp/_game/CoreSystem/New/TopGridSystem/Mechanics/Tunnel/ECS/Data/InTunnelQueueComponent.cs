using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;
using _game.BaseLayerSystems.EntitySystem.Core;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Data
{
	[Serializable]
	[Token(Token = "0x2000163")]
	public struct InTunnelQueueComponent : IEntityData
	{
		[Token(Token = "0x400046D")]
		[FieldOffset(Offset = "0x0")]
		public EntityId tunnelId;

		[Token(Token = "0x400046E")]
		[FieldOffset(Offset = "0x8")]
		public int orderIndex;

		[Token(Token = "0x60006C6")]
		[Address(RVA = "0x3E55B98", Offset = "0x3E55B98", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\nL_0024:\n\tv56 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(*([builder @ X1 (_game.BaseLayerSystems.EntitySystem.EntityBuilder&)]), this.tunnelId);\n\treturn;\n")]
		public void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("InTunnelQueueComponent::Apply");
		}
	}
}
