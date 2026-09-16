using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x20000A7")]
	public interface IEndDragHandler : IEventSystemHandler
	{
		[Token(Token = "0x6000647")]
		void OnEndDrag(PointerEventData eventData);
	}
}
