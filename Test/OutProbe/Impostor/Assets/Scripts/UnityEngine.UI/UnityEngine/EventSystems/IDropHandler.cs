using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x20000A8")]
	public interface IDropHandler : IEventSystemHandler
	{
		[Token(Token = "0x6000648")]
		void OnDrop(PointerEventData eventData);
	}
}
