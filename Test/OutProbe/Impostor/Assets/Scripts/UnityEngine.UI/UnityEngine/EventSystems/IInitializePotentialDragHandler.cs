using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x20000A5")]
	public interface IInitializePotentialDragHandler : IEventSystemHandler
	{
		[Token(Token = "0x6000645")]
		void OnInitializePotentialDrag(PointerEventData eventData);
	}
}
