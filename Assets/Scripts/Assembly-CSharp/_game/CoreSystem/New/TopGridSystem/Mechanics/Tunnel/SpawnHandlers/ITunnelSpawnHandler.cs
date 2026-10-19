using System.Collections.Generic;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem.Core;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers
{
	[Token(Token = "0x2000153")]
	public interface ITunnelSpawnHandler
	{
		[Token(Token = "0x6000695")]
		void Handle(EntityManager em, Entity tunnel, IReadOnlyList<Entity> slotEntities);
	}
}
