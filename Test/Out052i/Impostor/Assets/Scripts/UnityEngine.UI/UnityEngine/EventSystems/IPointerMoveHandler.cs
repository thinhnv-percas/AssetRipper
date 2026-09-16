using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x200009E")]
	public interface IPointerMoveHandler : IEventSystemHandler
	{
		[Token(Token = "0x600063E")]
		void OnPointerMove(PointerEventData eventData);
	}
}
