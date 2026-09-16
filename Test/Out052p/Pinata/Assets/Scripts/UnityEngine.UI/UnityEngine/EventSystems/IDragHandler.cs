using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x2000058")]
	public interface IDragHandler : IEventSystemHandler
	{
		[Token(Token = "0x6000512")]
		void OnDrag(PointerEventData eventData);
	}
}
