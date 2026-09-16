using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x2000060")]
	public interface ISubmitHandler : IEventSystemHandler
	{
		[Token(Token = "0x600051A")]
		void OnSubmit(BaseEventData eventData);
	}
}
