using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TMPro
{
	[Token(Token = "0x2000077")]
	public class TMP_ScrollbarEventHandler : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, ISelectHandler, IDeselectHandler
	{
		[Token(Token = "0x40003A5")]
		[FieldOffset(Offset = "0x20")]
		public bool isSelected;

		[Token(Token = "0x60003C6")]
		[Address(RVA = "0x1608058", Offset = "0x1608058", Length = "0x68")]
		public void OnPointerClick(PointerEventData eventData)
		{
		}

		[Token(Token = "0x60003C7")]
		[Address(RVA = "0x16080C0", Offset = "0x16080C0", Length = "0x78")]
		public void OnSelect(BaseEventData eventData)
		{
		}

		[Token(Token = "0x60003C8")]
		[Address(RVA = "0x1608138", Offset = "0x1608138", Length = "0x74")]
		public void OnDeselect(BaseEventData eventData)
		{
		}

		[Token(Token = "0x60003C9")]
		[Address(RVA = "0x16081AC", Offset = "0x16081AC", Length = "0x8")]
		public TMP_ScrollbarEventHandler()
		{
		}
	}
}
