using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x20000A1")]
	public interface IPointerDownHandler : IEventSystemHandler
	{
		[Token(Token = "0x6000641")]
		void OnPointerDown(PointerEventData eventData);
	}
}
