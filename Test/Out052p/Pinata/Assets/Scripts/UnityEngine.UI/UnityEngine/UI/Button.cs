using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace UnityEngine.UI
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x726F6C", Offset = "0x726F6C")]
	[Token(Token = "0x2000003")]
	public class Button : Selectable, IPointerClickHandler, IEventSystemHandler, ISubmitHandler
	{
		[Serializable]
		[Token(Token = "0x2000073")]
		public class ButtonClickedEvent : UnityEvent
		{
			[Token(Token = "0x6000615")]
			[Address(RVA = "0xC4CB0C", Offset = "0xC4CB0C", Length = "0x8")]
			public ButtonClickedEvent()
			{
			}
		}

		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x728214", Offset = "0x728214")]
		[SerializeField]
		[Token(Token = "0x400000B")]
		[FieldOffset(Offset = "0xE8")]
		private ButtonClickedEvent m_OnClick;

		[Token(Token = "0x17000006")]
		public ButtonClickedEvent onClick
		{
			[Token(Token = "0x600000D")]
			[Address(RVA = "0xC4CB14", Offset = "0xC4CB14", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600000E")]
			[Address(RVA = "0xC4CB1C", Offset = "0xC4CB1C", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x600000C")]
		[Address(RVA = "0xC4CA84", Offset = "0xC4CA84", Length = "0x88")]
		protected Button()
		{
		}

		[Token(Token = "0x600000F")]
		[Address(RVA = "0xC4CB24", Offset = "0xC4CB24", Length = "0xA0")]
		private void Press()
		{
		}

		[Token(Token = "0x6000010")]
		[Address(RVA = "0xC4CBC4", Offset = "0xC4CBC4", Length = "0x24")]
		public virtual void OnPointerClick(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000011")]
		[Address(RVA = "0xC4CBE8", Offset = "0xC4CBE8", Length = "0x88")]
		public virtual void OnSubmit(BaseEventData eventData)
		{
		}

		[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x729F20", Offset = "0x729F20")]
		[Token(Token = "0x6000012")]
		[Address(RVA = "0xC4CC70", Offset = "0xC4CC70", Length = "0x74")]
		private IEnumerator OnFinishSubmit()
		{
			return null;
		}
	}
}
