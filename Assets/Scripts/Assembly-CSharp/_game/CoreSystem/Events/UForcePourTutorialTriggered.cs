using Cpp2ILInjected;
using Unco.EventBusSystem.Runtime;
using _game.BaseLayerSystems.EntitySystem.Core;

namespace _game.CoreSystem.Events
{
	[Token(Token = "0x2000506")]
	public struct UForcePourTutorialTriggered : IEvent
	{
		[Token(Token = "0x40010CE")]
		[FieldOffset(Offset = "0x0")]
		public Entity entity;
	}
}
