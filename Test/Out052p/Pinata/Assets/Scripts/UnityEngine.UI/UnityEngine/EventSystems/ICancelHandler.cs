using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x2000061")]
	public interface ICancelHandler : IEventSystemHandler
	{
		[Token(Token = "0x600051B")]
		void OnCancel(BaseEventData eventData);
	}
}
