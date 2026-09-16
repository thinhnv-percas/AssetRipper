using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x2000057")]
	public interface IInitializePotentialDragHandler : IEventSystemHandler
	{
		[Token(Token = "0x6000511")]
		void OnInitializePotentialDrag(PointerEventData eventData);
	}
}
