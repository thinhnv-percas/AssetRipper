using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x200005A")]
	public interface IDropHandler : IEventSystemHandler
	{
		[Token(Token = "0x6000514")]
		void OnDrop(PointerEventData eventData);
	}
}
