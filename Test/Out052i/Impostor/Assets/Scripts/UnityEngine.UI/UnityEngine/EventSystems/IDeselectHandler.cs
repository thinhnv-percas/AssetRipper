using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x20000AC")]
	public interface IDeselectHandler : IEventSystemHandler
	{
		[Token(Token = "0x600064C")]
		void OnDeselect(BaseEventData eventData);
	}
}
