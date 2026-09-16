using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x200009F")]
	public interface IPointerEnterHandler : IEventSystemHandler
	{
		[Token(Token = "0x600063F")]
		void OnPointerEnter(PointerEventData eventData);
	}
}
