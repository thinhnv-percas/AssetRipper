using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x20000AD")]
	public interface IMoveHandler : IEventSystemHandler
	{
		[Token(Token = "0x600064D")]
		void OnMove(AxisEventData eventData);
	}
}
