using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x20000A9")]
	public interface IScrollHandler : IEventSystemHandler
	{
		[Token(Token = "0x6000649")]
		void OnScroll(PointerEventData eventData);
	}
}
