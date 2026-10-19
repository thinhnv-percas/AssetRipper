using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using PrimeTween;
using Reflex.Attributes;
using _game.BaseLayerSystems.EntitySystem.Core;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers
{
	[Token(Token = "0x2000158")]
	public abstract class TunnelSpawnHandlerBase : ITunnelSpawnHandler
	{
		[Inject(false)]
		[Token(Token = "0x4000455")]
		[FieldOffset(Offset = "0x10")]
		protected internal ITunnelSpawnAnimator _animator;

		[Token(Token = "0x60006A0")]
		public abstract void Handle(EntityManager em, Entity tunnel, IReadOnlyList<Entity> slotEntities);

		[Token(Token = "0x60006A1")]
		[Address(RVA = "0x3DB978C", Offset = "0x3DB978C", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\nL_001F:\n\tgoto L_004E;\nL_004E:\n\tinterfaceTailCallResult = _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers.ITunnelSpawnAnimator::Animate(this._animator, entity, tunnel);\n\treturn interfaceTailCallResult;\n")]
		protected internal Sequence AnimateSpawn(Entity entity, Entity tunnel)
		{
			return _animator.Animate(entity, tunnel);
		}

		[Token(Token = "0x60006A2")]
		[Address(RVA = "0x3DB9850", Offset = "0x3DB9850", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		protected internal TunnelSpawnHandlerBase()
		{
		}
	}
}
