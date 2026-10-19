using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem;
using _game.CoreSystem.SandSystem.Components;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.ECS.Data
{
	[Serializable]
	[Token(Token = "0x2000164")]
	public struct TunnelQueueComponent : IEntityData
	{
		[Token(Token = "0x400046F")]
		[FieldOffset(Offset = "0x0")]
		public TunnelDirection direction;

		[Token(Token = "0x60006C7")]
		[Address(RVA = "0x3E55C00", Offset = "0x3E55C00", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\nL_0023:\n\tv55 = _game.BaseLayerSystems.EntitySystem.EntityBuilder::With(*([builder @ X1 (_game.BaseLayerSystems.EntitySystem.EntityBuilder&)]), this.direction);\n\treturn;\n")]
		public void Apply(ref EntityBuilder builder)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("TunnelQueueComponent::Apply");
		}
	}
}
