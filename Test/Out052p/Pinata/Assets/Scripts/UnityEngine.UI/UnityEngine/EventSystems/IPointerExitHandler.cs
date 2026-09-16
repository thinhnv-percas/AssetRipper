using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x2000052")]
	public interface IPointerExitHandler : IEventSystemHandler
	{
		[Token(Token = "0x600050C")]
		void OnPointerExit(PointerEventData eventData);
	}
}
