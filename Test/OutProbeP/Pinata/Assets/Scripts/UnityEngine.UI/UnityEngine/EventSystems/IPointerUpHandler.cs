using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x2000054")]
	public interface IPointerUpHandler : IEventSystemHandler
	{
		[Token(Token = "0x600050E")]
		void OnPointerUp(PointerEventData eventData);
	}
}
