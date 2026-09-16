using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x2000055")]
	public interface IPointerClickHandler : IEventSystemHandler
	{
		[Token(Token = "0x600050F")]
		void OnPointerClick(PointerEventData eventData);
	}
}
