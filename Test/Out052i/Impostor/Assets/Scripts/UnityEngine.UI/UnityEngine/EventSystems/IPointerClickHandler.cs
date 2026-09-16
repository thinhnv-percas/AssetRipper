using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x20000A3")]
	public interface IPointerClickHandler : IEventSystemHandler
	{
		[Token(Token = "0x6000643")]
		void OnPointerClick(PointerEventData eventData);
	}
}
