using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x200005D")]
	public interface ISelectHandler : IEventSystemHandler
	{
		[Token(Token = "0x6000517")]
		void OnSelect(BaseEventData eventData);
	}
}
