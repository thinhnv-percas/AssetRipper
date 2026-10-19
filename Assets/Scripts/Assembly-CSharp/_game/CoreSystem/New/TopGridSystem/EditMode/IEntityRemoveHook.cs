using System.Collections.Generic;
using Cpp2ILInjected;
using _game.BaseLayerSystems.EntitySystem.Core;

namespace _game.CoreSystem.New.TopGridSystem.EditMode
{
	[Token(Token = "0x200024E")]
	public interface IEntityRemoveHook
	{
		[Token(Token = "0x6000A04")]
		void OnBeforeRemove(IReadOnlyList<Entity> entities);

		[Token(Token = "0x6000A05")]
		void OnBeforeDestroyEntity(Entity entity);

		[Token(Token = "0x6000A06")]
		void OnAfterRemove();
	}
}
