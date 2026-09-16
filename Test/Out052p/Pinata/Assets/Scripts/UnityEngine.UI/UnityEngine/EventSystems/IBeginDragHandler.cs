using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x2000056")]
	public interface IBeginDragHandler : IEventSystemHandler
	{
		[Token(Token = "0x6000510")]
		void OnBeginDrag(PointerEventData eventData);
	}
}
