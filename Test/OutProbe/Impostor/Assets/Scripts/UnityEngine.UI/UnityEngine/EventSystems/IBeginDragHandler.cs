using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x20000A4")]
	public interface IBeginDragHandler : IEventSystemHandler
	{
		[Token(Token = "0x6000644")]
		void OnBeginDrag(PointerEventData eventData);
	}
}
