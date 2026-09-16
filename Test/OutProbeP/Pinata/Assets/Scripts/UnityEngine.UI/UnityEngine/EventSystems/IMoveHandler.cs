using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x200005F")]
	public interface IMoveHandler : IEventSystemHandler
	{
		[Token(Token = "0x6000519")]
		void OnMove(AxisEventData eventData);
	}
}
