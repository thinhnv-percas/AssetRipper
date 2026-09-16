using System;
using Cpp2ILInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace UnityEngine.UI
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x727A78", Offset = "0x727A78")]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x727A78", Offset = "0x727A78")]
	[Token(Token = "0x2000039")]
	public class Toggle : Selectable, IPointerClickHandler, IEventSystemHandler, ISubmitHandler, ICanvasElement
	{
		[Token(Token = "0x20000AB")]
		public enum ToggleTransition
		{
			[Token(Token = "0x40002EE")]
			None = 0,
			[Token(Token = "0x40002EF")]
			Fade = 1
		}

		[Serializable]
		[Token(Token = "0x20000AC")]
		public class ToggleEvent : UnityEvent<bool>
		{
			[Token(Token = "0x6000677")]
			[Address(RVA = "0xEDBC0C", Offset = "0xEDBC0C", Length = "0x50")]
			public ToggleEvent()
			{
			}
		}

		[Token(Token = "0x4000163")]
		[FieldOffset(Offset = "0xE8")]
		public ToggleTransition toggleTransition;

		[Token(Token = "0x4000164")]
		[FieldOffset(Offset = "0xF0")]
		public Graphic graphic;

		[SerializeField]
		[Token(Token = "0x4000165")]
		[FieldOffset(Offset = "0xF8")]
		private ToggleGroup m_Group;

		[Token(Token = "0x4000166")]
		[FieldOffset(Offset = "0x100")]
		public ToggleEvent onValueChanged;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x729AF4", Offset = "0x729AF4")]
		[SerializeField]
		[Token(Token = "0x4000167")]
		[FieldOffset(Offset = "0x108")]
		private bool m_IsOn;

		[Token(Token = "0x17000134")]
		public ToggleGroup group
		{
			[Token(Token = "0x600043C")]
			[Address(RVA = "0xEDB908", Offset = "0xEDB908", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600043D")]
			[Address(RVA = "0xEDB910", Offset = "0xEDB910", Length = "0x30")]
			set
			{
			}
		}

		[Token(Token = "0x17000135")]
		public bool isOn
		{
			[Token(Token = "0x6000447")]
			[Address(RVA = "0xEDC2E4", Offset = "0xEDC2E4", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000448")]
			[Address(RVA = "0xEDC2EC", Offset = "0xEDC2EC", Length = "0xC")]
			set
			{
			}
		}

		Transform ICanvasElement.transform
		{
			[Token(Token = "0x6000450")]
			[Address(RVA = "0xEDC4CC", Offset = "0xEDC4CC", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x600043E")]
		[Address(RVA = "0xEDBB84", Offset = "0xEDBB84", Length = "0x88")]
		protected Toggle()
		{
		}

		[Token(Token = "0x600043F")]
		[Address(RVA = "0xEDBC5C", Offset = "0xEDBC5C", Length = "0x4")]
		public virtual void Rebuild(CanvasUpdate executing)
		{
		}

		[Token(Token = "0x6000440")]
		[Address(RVA = "0xEDBC60", Offset = "0xEDBC60", Length = "0x4")]
		public virtual void LayoutComplete()
		{
		}

		[Token(Token = "0x6000441")]
		[Address(RVA = "0xEDBC64", Offset = "0xEDBC64", Length = "0x4")]
		public virtual void GraphicUpdateComplete()
		{
		}

		[Token(Token = "0x6000442")]
		[Address(RVA = "0xEDBC68", Offset = "0xEDBC68", Length = "0x90")]
		protected override void OnDestroy()
		{
		}

		[Token(Token = "0x6000443")]
		[Address(RVA = "0xEDBDB0", Offset = "0xEDBDB0", Length = "0x38")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x6000444")]
		[Address(RVA = "0xEDBDE8", Offset = "0xEDBDE8", Length = "0x2C")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x6000445")]
		[Address(RVA = "0xEDBE14", Offset = "0xEDBE14", Length = "0x108")]
		protected override void OnDidApplyAnimationProperties()
		{
		}

		[Token(Token = "0x6000446")]
		[Address(RVA = "0xEDB940", Offset = "0xEDB940", Length = "0x170")]
		private void SetToggleGroup(ToggleGroup newGroup, bool setMemberValue)
		{
		}

		[Token(Token = "0x6000449")]
		[Address(RVA = "0xEDC2F8", Offset = "0xEDC2F8", Length = "0xC")]
		public void SetIsOnWithoutNotify(bool value)
		{
		}

		[Token(Token = "0x600044A")]
		[Address(RVA = "0xEDBF1C", Offset = "0xEDBF1C", Length = "0x164")]
		private void Set(bool value, bool sendCallback = true)
		{
		}

		[Token(Token = "0x600044B")]
		[Address(RVA = "0xEDBAB0", Offset = "0xEDBAB0", Length = "0xD4")]
		private void PlayEffect(bool instant)
		{
		}

		[Token(Token = "0x600044C")]
		[Address(RVA = "0xEDC438", Offset = "0xEDC438", Length = "0x8")]
		protected override void Start()
		{
		}

		[Token(Token = "0x600044D")]
		[Address(RVA = "0xEDC440", Offset = "0xEDC440", Length = "0x64")]
		private void InternalToggle()
		{
		}

		[Token(Token = "0x600044E")]
		[Address(RVA = "0xEDC4A4", Offset = "0xEDC4A4", Length = "0x24")]
		public virtual void OnPointerClick(PointerEventData eventData)
		{
		}

		[Token(Token = "0x600044F")]
		[Address(RVA = "0xEDC4C8", Offset = "0xEDC4C8", Length = "0x4")]
		public virtual void OnSubmit(BaseEventData eventData)
		{
		}
	}
}
