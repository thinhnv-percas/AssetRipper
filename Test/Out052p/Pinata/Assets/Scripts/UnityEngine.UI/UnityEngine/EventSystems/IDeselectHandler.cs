using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x200005E")]
	public interface IDeselectHandler : IEventSystemHandler
	{
		[Token(Token = "0x6000518")]
		void OnDeselect(BaseEventData eventData);
	}
}
