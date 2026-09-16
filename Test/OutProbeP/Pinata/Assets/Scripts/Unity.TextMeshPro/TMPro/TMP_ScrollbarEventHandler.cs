using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TMPro
{
	[Token(Token = "0x2000039")]
	public class TMP_ScrollbarEventHandler : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, ISelectHandler, IDeselectHandler
	{
		[Token(Token = "0x4000201")]
		[FieldOffset(Offset = "0x18")]
		public bool isSelected;

		[Token(Token = "0x60002F0")]
		[Address(RVA = "0x93ADD0", Offset = "0x93ADD0", Length = "0x6C")]
		public void OnPointerClick(PointerEventData eventData)
		{
		}

		[Token(Token = "0x60002F1")]
		[Address(RVA = "0x93AE3C", Offset = "0x93AE3C", Length = "0x7C")]
		public void OnSelect(BaseEventData eventData)
		{
		}

		[Token(Token = "0x60002F2")]
		[Address(RVA = "0x93AEB8", Offset = "0x93AEB8", Length = "0x78")]
		public void OnDeselect(BaseEventData eventData)
		{
		}

		[Token(Token = "0x60002F3")]
		[Address(RVA = "0x93AF30", Offset = "0x93AF30", Length = "0x8")]
		public TMP_ScrollbarEventHandler()
		{
		}
	}
}
