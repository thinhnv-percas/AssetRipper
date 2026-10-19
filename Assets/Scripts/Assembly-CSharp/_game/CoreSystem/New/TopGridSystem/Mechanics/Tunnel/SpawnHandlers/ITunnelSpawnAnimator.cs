using Cpp2ILInjected;
using PrimeTween;
using _game.BaseLayerSystems.EntitySystem.Core;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Tunnel.SpawnHandlers
{
	[Token(Token = "0x2000152")]
	public interface ITunnelSpawnAnimator
	{
		[Token(Token = "0x6000694")]
		Sequence Animate(Entity entity, Entity tunnel);
	}
}
