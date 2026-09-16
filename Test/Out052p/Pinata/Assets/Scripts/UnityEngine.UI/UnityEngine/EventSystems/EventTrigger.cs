using System;
using System.Collections.Generic;
using System.ComponentModel;
using Cpp2ILInjected;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace UnityEngine.EventSystems
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x727D28", Offset = "0x727D28")]
	[Token(Token = "0x2000063")]
	public class EventTrigger : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IInitializePotentialDragHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IScrollHandler, IUpdateSelectedHandler, ISelectHandler, IDeselectHandler, IMoveHandler, ISubmitHandler, ICancelHandler
	{
		[Serializable]
		[Token(Token = "0x20000BA")]
		public class TriggerEvent : UnityEvent<BaseEventData>
		{
			[Token(Token = "0x600069C")]
			[Address(RVA = "0xC43B00", Offset = "0xC43B00", Length = "0x50")]
			public TriggerEvent()
			{
			}
		}

		[Serializable]
		[Token(Token = "0x20000BB")]
		public class Entry
		{
			[Token(Token = "0x4000304")]
			[FieldOffset(Offset = "0x10")]
			public EventTriggerType eventID;

			[Token(Token = "0x4000305")]
			[FieldOffset(Offset = "0x18")]
			public TriggerEvent callback;

			[Token(Token = "0x600069D")]
			[Address(RVA = "0xC43A94", Offset = "0xC43A94", Length = "0x6C")]
			public Entry()
			{
			}
		}

		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x729D4C", Offset = "0x729D4C")]
		[SerializeField]
		[Token(Token = "0x40001BD")]
		[FieldOffset(Offset = "0x18")]
		private List<Entry> m_Delegates;

		[AttributeAttribute(Type = typeof(EditorBrowsableAttribute), RVA = "0x72ABB4", Offset = "0x72ABB4")]
		[Obsolete]
		[Token(Token = "0x17000174")]
		public List<Entry> delegates
		{
			[Token(Token = "0x600053A")]
			[Address(RVA = "0xC43804", Offset = "0xC43804", Length = "0x4")]
			get
			{
				return null;
			}
			[Token(Token = "0x600053B")]
			[Address(RVA = "0xC4387C", Offset = "0xC4387C", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000175")]
		public List<Entry> triggers
		{
			[Token(Token = "0x600053D")]
			[Address(RVA = "0xC43808", Offset = "0xC43808", Length = "0x74")]
			get
			{
				return null;
			}
			[Token(Token = "0x600053E")]
			[Address(RVA = "0xC4388C", Offset = "0xC4388C", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x600053C")]
		[Address(RVA = "0xC43884", Offset = "0xC43884", Length = "0x8")]
		protected EventTrigger()
		{
		}

		[Token(Token = "0x600053F")]
		[Address(RVA = "0xC43894", Offset = "0xC43894", Length = "0xF0")]
		private void Execute(EventTriggerType id, BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000540")]
		[Address(RVA = "0xC43984", Offset = "0xC43984", Length = "0x10")]
		public virtual void OnPointerEnter(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000541")]
		[Address(RVA = "0xC43994", Offset = "0xC43994", Length = "0x10")]
		public virtual void OnPointerExit(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000542")]
		[Address(RVA = "0xC439A4", Offset = "0xC439A4", Length = "0x10")]
		public virtual void OnDrag(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000543")]
		[Address(RVA = "0xC439B4", Offset = "0xC439B4", Length = "0x10")]
		public virtual void OnDrop(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000544")]
		[Address(RVA = "0xC439C4", Offset = "0xC439C4", Length = "0x10")]
		public virtual void OnPointerDown(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000545")]
		[Address(RVA = "0xC439D4", Offset = "0xC439D4", Length = "0x10")]
		public virtual void OnPointerUp(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000546")]
		[Address(RVA = "0xC439E4", Offset = "0xC439E4", Length = "0x10")]
		public virtual void OnPointerClick(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000547")]
		[Address(RVA = "0xC439F4", Offset = "0xC439F4", Length = "0x10")]
		public virtual void OnSelect(BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000548")]
		[Address(RVA = "0xC43A04", Offset = "0xC43A04", Length = "0x10")]
		public virtual void OnDeselect(BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000549")]
		[Address(RVA = "0xC43A14", Offset = "0xC43A14", Length = "0x10")]
		public virtual void OnScroll(PointerEventData eventData)
		{
		}

		[Token(Token = "0x600054A")]
		[Address(RVA = "0xC43A24", Offset = "0xC43A24", Length = "0x10")]
		public virtual void OnMove(AxisEventData eventData)
		{
		}

		[Token(Token = "0x600054B")]
		[Address(RVA = "0xC43A34", Offset = "0xC43A34", Length = "0x10")]
		public virtual void OnUpdateSelected(BaseEventData eventData)
		{
		}

		[Token(Token = "0x600054C")]
		[Address(RVA = "0xC43A44", Offset = "0xC43A44", Length = "0x10")]
		public virtual void OnInitializePotentialDrag(PointerEventData eventData)
		{
		}

		[Token(Token = "0x600054D")]
		[Address(RVA = "0xC43A54", Offset = "0xC43A54", Length = "0x10")]
		public virtual void OnBeginDrag(PointerEventData eventData)
		{
		}

		[Token(Token = "0x600054E")]
		[Address(RVA = "0xC43A64", Offset = "0xC43A64", Length = "0x10")]
		public virtual void OnEndDrag(PointerEventData eventData)
		{
		}

		[Token(Token = "0x600054F")]
		[Address(RVA = "0xC43A74", Offset = "0xC43A74", Length = "0x10")]
		public virtual void OnSubmit(BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000550")]
		[Address(RVA = "0xC43A84", Offset = "0xC43A84", Length = "0x10")]
		public virtual void OnCancel(BaseEventData eventData)
		{
		}
	}
}
