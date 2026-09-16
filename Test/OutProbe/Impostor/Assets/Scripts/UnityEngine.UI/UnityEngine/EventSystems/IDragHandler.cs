using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x20000A6")]
	public interface IDragHandler : IEventSystemHandler
	{
		[Token(Token = "0x6000646")]
		void OnDrag(PointerEventData eventData);
	}
}
