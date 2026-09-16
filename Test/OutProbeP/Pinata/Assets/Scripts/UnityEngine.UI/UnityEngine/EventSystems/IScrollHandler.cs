using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x200005B")]
	public interface IScrollHandler : IEventSystemHandler
	{
		[Token(Token = "0x6000515")]
		void OnScroll(PointerEventData eventData);
	}
}
