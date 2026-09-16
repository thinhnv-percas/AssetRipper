using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x20000AE")]
	public interface ISubmitHandler : IEventSystemHandler
	{
		[Token(Token = "0x600064E")]
		void OnSubmit(BaseEventData eventData);
	}
}
