using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x2000059")]
	public interface IEndDragHandler : IEventSystemHandler
	{
		[Token(Token = "0x6000513")]
		void OnEndDrag(PointerEventData eventData);
	}
}
