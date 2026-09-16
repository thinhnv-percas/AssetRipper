using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x2000053")]
	public interface IPointerDownHandler : IEventSystemHandler
	{
		[Token(Token = "0x600050D")]
		void OnPointerDown(PointerEventData eventData);
	}
}
