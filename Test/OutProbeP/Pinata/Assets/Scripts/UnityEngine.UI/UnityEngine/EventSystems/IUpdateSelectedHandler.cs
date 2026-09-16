using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x200005C")]
	public interface IUpdateSelectedHandler : IEventSystemHandler
	{
		[Token(Token = "0x6000516")]
		void OnUpdateSelected(BaseEventData eventData);
	}
}
