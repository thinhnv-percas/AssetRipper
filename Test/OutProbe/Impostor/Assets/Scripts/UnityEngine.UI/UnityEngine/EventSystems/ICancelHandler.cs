using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x20000AF")]
	public interface ICancelHandler : IEventSystemHandler
	{
		[Token(Token = "0x600064F")]
		void OnCancel(BaseEventData eventData);
	}
}
