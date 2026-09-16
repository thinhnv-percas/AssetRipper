using System;
using System.Collections.Generic;
using System.ComponentModel;
using Cpp2ILInjected;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace UnityEngine.EventSystems
{
	[AddComponentMenu("Event/Event Trigger")]
	[Token(Token = "0x20000B3")]
	public class EventTrigger : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler, IInitializePotentialDragHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler, IScrollHandler, IUpdateSelectedHandler, ISelectHandler, IDeselectHandler, IMoveHandler, ISubmitHandler, ICancelHandler
	{
		[Serializable]
		[Token(Token = "0x20000B4")]
		public class TriggerEvent : UnityEvent<BaseEventData>
		{
			[Token(Token = "0x600068F")]
			[Address(RVA = "0x18459C4", Offset = "0x18459C4", Length = "0x48")]
			public TriggerEvent()
			{
			}
		}

		[Serializable]
		[Token(Token = "0x20000B5")]
		public class Entry
		{
			[Token(Token = "0x40002F0")]
			[FieldOffset(Offset = "0x10")]
			public EventTriggerType eventID;

			[Token(Token = "0x40002F1")]
			[FieldOffset(Offset = "0x18")]
			public TriggerEvent callback;

			[Token(Token = "0x6000690")]
			[Address(RVA = "0x1845A0C", Offset = "0x1845A0C", Length = "0x64")]
			public Entry()
			{
			}
		}

		[FormerlySerializedAs("delegates")]
		[SerializeField]
		[Token(Token = "0x40002EF")]
		[FieldOffset(Offset = "0x20")]
		private List<Entry> m_Delegates;

		[Obsolete("Please use triggers instead (UnityUpgradable) -> triggers", true)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Token(Token = "0x170001C1")]
		public List<Entry> delegates
		{
			[Token(Token = "0x6000678")]
			[Address(RVA = "0x1845780", Offset = "0x1845780", Length = "0x4")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000679")]
			[Address(RVA = "0x18457FC", Offset = "0x18457FC", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170001C2")]
		public List<Entry> triggers
		{
			[Token(Token = "0x600067B")]
			[Address(RVA = "0x1845784", Offset = "0x1845784", Length = "0x78")]
			get
			{
				return null;
			}
			[Token(Token = "0x600067C")]
			[Address(RVA = "0x184580C", Offset = "0x184580C", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x600067A")]
		[Address(RVA = "0x1845804", Offset = "0x1845804", Length = "0x8")]
		protected EventTrigger()
		{
		}

		[Token(Token = "0x600067D")]
		[Address(RVA = "0x1845814", Offset = "0x1845814", Length = "0xE4")]
		private void Execute(EventTriggerType id, BaseEventData eventData)
		{
		}

		[Token(Token = "0x600067E")]
		[Address(RVA = "0x18458F8", Offset = "0x18458F8", Length = "0xC")]
		public virtual void OnPointerEnter(PointerEventData eventData)
		{
		}

		[Token(Token = "0x600067F")]
		[Address(RVA = "0x1845904", Offset = "0x1845904", Length = "0xC")]
		public virtual void OnPointerExit(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000680")]
		[Address(RVA = "0x1845910", Offset = "0x1845910", Length = "0xC")]
		public virtual void OnDrag(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000681")]
		[Address(RVA = "0x184591C", Offset = "0x184591C", Length = "0xC")]
		public virtual void OnDrop(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000682")]
		[Address(RVA = "0x1845928", Offset = "0x1845928", Length = "0xC")]
		public virtual void OnPointerDown(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000683")]
		[Address(RVA = "0x1845934", Offset = "0x1845934", Length = "0xC")]
		public virtual void OnPointerUp(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000684")]
		[Address(RVA = "0x1845940", Offset = "0x1845940", Length = "0xC")]
		public virtual void OnPointerClick(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000685")]
		[Address(RVA = "0x184594C", Offset = "0x184594C", Length = "0xC")]
		public virtual void OnSelect(BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000686")]
		[Address(RVA = "0x1845958", Offset = "0x1845958", Length = "0xC")]
		public virtual void OnDeselect(BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000687")]
		[Address(RVA = "0x1845964", Offset = "0x1845964", Length = "0xC")]
		public virtual void OnScroll(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000688")]
		[Address(RVA = "0x1845970", Offset = "0x1845970", Length = "0xC")]
		public virtual void OnMove(AxisEventData eventData)
		{
		}

		[Token(Token = "0x6000689")]
		[Address(RVA = "0x184597C", Offset = "0x184597C", Length = "0xC")]
		public virtual void OnUpdateSelected(BaseEventData eventData)
		{
		}

		[Token(Token = "0x600068A")]
		[Address(RVA = "0x1845988", Offset = "0x1845988", Length = "0xC")]
		public virtual void OnInitializePotentialDrag(PointerEventData eventData)
		{
		}

		[Token(Token = "0x600068B")]
		[Address(RVA = "0x1845994", Offset = "0x1845994", Length = "0xC")]
		public virtual void OnBeginDrag(PointerEventData eventData)
		{
		}

		[Token(Token = "0x600068C")]
		[Address(RVA = "0x18459A0", Offset = "0x18459A0", Length = "0xC")]
		public virtual void OnEndDrag(PointerEventData eventData)
		{
		}

		[Token(Token = "0x600068D")]
		[Address(RVA = "0x18459AC", Offset = "0x18459AC", Length = "0xC")]
		public virtual void OnSubmit(BaseEventData eventData)
		{
		}

		[Token(Token = "0x600068E")]
		[Address(RVA = "0x18459B8", Offset = "0x18459B8", Length = "0xC")]
		public virtual void OnCancel(BaseEventData eventData)
		{
		}
	}
}
