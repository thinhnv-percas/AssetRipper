using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x20000AA")]
	public interface IUpdateSelectedHandler : IEventSystemHandler
	{
		[Token(Token = "0x600064A")]
		void OnUpdateSelected(BaseEventData eventData);
	}
}
