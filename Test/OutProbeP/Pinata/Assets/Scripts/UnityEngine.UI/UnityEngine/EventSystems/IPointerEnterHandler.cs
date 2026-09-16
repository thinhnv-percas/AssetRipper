using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x2000051")]
	public interface IPointerEnterHandler : IEventSystemHandler
	{
		[Token(Token = "0x600050B")]
		void OnPointerEnter(PointerEventData eventData);
	}
}
