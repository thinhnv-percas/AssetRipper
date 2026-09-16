using System;
using Cpp2ILInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace UnityEngine.UI
{
	[AddComponentMenu("UI/Toggle", 30)]
	[RequireComponent(typeof(RectTransform))]
	[Token(Token = "0x2000075")]
	public class Toggle : Selectable, IPointerClickHandler, IEventSystemHandler, ISubmitHandler, ICanvasElement
	{
		[Token(Token = "0x2000076")]
		public enum ToggleTransition
		{
			[Token(Token = "0x4000255")]
			None = 0,
			[Token(Token = "0x4000256")]
			Fade = 1
		}

		[Serializable]
		[Token(Token = "0x2000077")]
		public class ToggleEvent : UnityEvent<bool>
		{
			[Token(Token = "0x60004E9")]
			[Address(RVA = "0x183A40C", Offset = "0x183A40C", Length = "0x48")]
			public ToggleEvent()
			{
			}
		}

		[Token(Token = "0x400024F")]
		[FieldOffset(Offset = "0x100")]
		public ToggleTransition toggleTransition;

		[Token(Token = "0x4000250")]
		[FieldOffset(Offset = "0x108")]
		public Graphic graphic;

		[SerializeField]
		[Token(Token = "0x4000251")]
		[FieldOffset(Offset = "0x110")]
		private ToggleGroup m_Group;

		[Token(Token = "0x4000252")]
		[FieldOffset(Offset = "0x118")]
		public ToggleEvent onValueChanged;

		[SerializeField]
		[Tooltip("Is the toggle currently on or off?")]
		[Token(Token = "0x4000253")]
		[FieldOffset(Offset = "0x120")]
		private bool m_IsOn;

		[Token(Token = "0x1700014E")]
		public ToggleGroup group
		{
			[Token(Token = "0x60004D4")]
			[Address(RVA = "0x183A158", Offset = "0x183A158", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60004D5")]
			[Address(RVA = "0x183A160", Offset = "0x183A160", Length = "0x20")]
			set
			{
			}
		}

		[Token(Token = "0x1700014F")]
		public bool isOn
		{
			[Token(Token = "0x60004DF")]
			[Address(RVA = "0x183AE20", Offset = "0x183AE20", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60004E0")]
			[Address(RVA = "0x183AE28", Offset = "0x183AE28", Length = "0xC")]
			set
			{
			}
		}

		Transform ICanvasElement.transform
		{
			[Token(Token = "0x60004E8")]
			[Address(RVA = "0x183AFFC", Offset = "0x183AFFC", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x60004D6")]
		[Address(RVA = "0x183A380", Offset = "0x183A380", Length = "0x8C")]
		protected Toggle()
		{
		}

		[Token(Token = "0x60004D7")]
		[Address(RVA = "0x183A454", Offset = "0x183A454", Length = "0x4")]
		public virtual void Rebuild(CanvasUpdate executing)
		{
		}

		[Token(Token = "0x60004D8")]
		[Address(RVA = "0x183A458", Offset = "0x183A458", Length = "0x4")]
		public virtual void LayoutComplete()
		{
		}

		[Token(Token = "0x60004D9")]
		[Address(RVA = "0x183A45C", Offset = "0x183A45C", Length = "0x4")]
		public virtual void GraphicUpdateComplete()
		{
		}

		[Token(Token = "0x60004DA")]
		[Address(RVA = "0x183A460", Offset = "0x183A460", Length = "0x80")]
		protected override void OnDestroy()
		{
		}

		[Token(Token = "0x60004DB")]
		[Address(RVA = "0x183A8D0", Offset = "0x183A8D0", Length = "0x2C")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x60004DC")]
		[Address(RVA = "0x183A8FC", Offset = "0x183A8FC", Length = "0x20")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x60004DD")]
		[Address(RVA = "0x183A91C", Offset = "0x183A91C", Length = "0x124")]
		protected override void OnDidApplyAnimationProperties()
		{
		}

		[Token(Token = "0x60004DE")]
		[Address(RVA = "0x183A180", Offset = "0x183A180", Length = "0x13C")]
		private void SetToggleGroup(ToggleGroup newGroup, bool setMemberValue)
		{
		}

		[Token(Token = "0x60004E1")]
		[Address(RVA = "0x183AE34", Offset = "0x183AE34", Length = "0xC")]
		public void SetIsOnWithoutNotify(bool value)
		{
		}

		[Token(Token = "0x60004E2")]
		[Address(RVA = "0x183AA40", Offset = "0x183AA40", Length = "0x174")]
		private void Set(bool value, bool sendCallback = true)
		{
		}

		[Token(Token = "0x60004E3")]
		[Address(RVA = "0x183A2BC", Offset = "0x183A2BC", Length = "0xC4")]
		private void PlayEffect(bool instant)
		{
		}

		[Token(Token = "0x60004E4")]
		[Address(RVA = "0x183AF78", Offset = "0x183AF78", Length = "0x8")]
		protected override void Start()
		{
		}

		[Token(Token = "0x60004E5")]
		[Address(RVA = "0x183AF80", Offset = "0x183AF80", Length = "0x54")]
		private void InternalToggle()
		{
		}

		[Token(Token = "0x60004E6")]
		[Address(RVA = "0x183AFD4", Offset = "0x183AFD4", Length = "0x24")]
		public virtual void OnPointerClick(PointerEventData eventData)
		{
		}

		[Token(Token = "0x60004E7")]
		[Address(RVA = "0x183AFF8", Offset = "0x183AFF8", Length = "0x4")]
		public virtual void OnSubmit(BaseEventData eventData)
		{
		}
	}
}
