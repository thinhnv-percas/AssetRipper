using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x20000AB")]
	public interface ISelectHandler : IEventSystemHandler
	{
		[Token(Token = "0x600064B")]
		void OnSelect(BaseEventData eventData);
	}
}
