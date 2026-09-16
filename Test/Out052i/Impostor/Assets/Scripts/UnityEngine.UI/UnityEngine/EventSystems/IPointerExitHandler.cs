using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x20000A0")]
	public interface IPointerExitHandler : IEventSystemHandler
	{
		[Token(Token = "0x6000640")]
		void OnPointerExit(PointerEventData eventData);
	}
}
