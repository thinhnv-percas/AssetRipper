using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x20000A2")]
	public interface IPointerUpHandler : IEventSystemHandler
	{
		[Token(Token = "0x6000642")]
		void OnPointerUp(PointerEventData eventData);
	}
}
