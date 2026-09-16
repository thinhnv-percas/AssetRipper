using System;
using Cpp2ILInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace UnityEngine.UI
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x7279A0", Offset = "0x7279A0")]
	[ExecuteInEditMode]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x7279A0", Offset = "0x7279A0")]
	[Token(Token = "0x2000035")]
	public class Slider : Selectable, IDragHandler, IEventSystemHandler, IInitializePotentialDragHandler, ICanvasElement
	{
		[Token(Token = "0x20000A7")]
		public enum Direction
		{
			[Token(Token = "0x40002DC")]
			LeftToRight = 0,
			[Token(Token = "0x40002DD")]
			RightToLeft = 1,
			[Token(Token = "0x40002DE")]
			BottomToTop = 2,
			[Token(Token = "0x40002DF")]
			TopToBottom = 3
		}

		[Serializable]
		[Token(Token = "0x20000A8")]
		public class SliderEvent : UnityEvent<float>
		{
			[Token(Token = "0x6000675")]
			[Address(RVA = "0xED89B4", Offset = "0xED89B4", Length = "0x50")]
			public SliderEvent()
			{
			}
		}

		[Token(Token = "0x20000A9")]
		private enum Axis
		{
			[Token(Token = "0x40002E1")]
			Horizontal = 0,
			[Token(Token = "0x40002E2")]
			Vertical = 1
		}

		[SerializeField]
		[Token(Token = "0x4000147")]
		[FieldOffset(Offset = "0xE8")]
		private RectTransform m_FillRect;

		[SerializeField]
		[Token(Token = "0x4000148")]
		[FieldOffset(Offset = "0xF0")]
		private RectTransform m_HandleRect;

		[Space]
		[SerializeField]
		[Token(Token = "0x4000149")]
		[FieldOffset(Offset = "0xF8")]
		private Direction m_Direction;

		[SerializeField]
		[Token(Token = "0x400014A")]
		[FieldOffset(Offset = "0xFC")]
		private float m_MinValue;

		[SerializeField]
		[Token(Token = "0x400014B")]
		[FieldOffset(Offset = "0x100")]
		private float m_MaxValue;

		[SerializeField]
		[Token(Token = "0x400014C")]
		[FieldOffset(Offset = "0x104")]
		private bool m_WholeNumbers;

		[SerializeField]
		[Token(Token = "0x400014D")]
		[FieldOffset(Offset = "0x108")]
		protected float m_Value;

		[Space]
		[SerializeField]
		[Token(Token = "0x400014E")]
		[FieldOffset(Offset = "0x110")]
		private SliderEvent m_OnValueChanged;

		[Token(Token = "0x400014F")]
		[FieldOffset(Offset = "0x118")]
		private Image m_FillImage;

		[Token(Token = "0x4000150")]
		[FieldOffset(Offset = "0x120")]
		private Transform m_FillTransform;

		[Token(Token = "0x4000151")]
		[FieldOffset(Offset = "0x128")]
		private RectTransform m_FillContainerRect;

		[Token(Token = "0x4000152")]
		[FieldOffset(Offset = "0x130")]
		private Transform m_HandleTransform;

		[Token(Token = "0x4000153")]
		[FieldOffset(Offset = "0x138")]
		private RectTransform m_HandleContainerRect;

		[Token(Token = "0x4000154")]
		[FieldOffset(Offset = "0x140")]
		private Vector2 m_Offset;

		[Token(Token = "0x4000155")]
		[FieldOffset(Offset = "0x148")]
		private DrivenRectTransformTracker m_Tracker;

		[Token(Token = "0x4000156")]
		[FieldOffset(Offset = "0x149")]
		private bool m_DelayedUpdateVisuals;

		[Token(Token = "0x1700010C")]
		public RectTransform fillRect
		{
			[Token(Token = "0x60003CD")]
			[Address(RVA = "0xED7D28", Offset = "0xED7D28", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60003CE")]
			[Address(RVA = "0xED7D30", Offset = "0xED7D30", Length = "0x84")]
			set
			{
			}
		}

		[Token(Token = "0x1700010D")]
		public RectTransform handleRect
		{
			[Token(Token = "0x60003CF")]
			[Address(RVA = "0xED8340", Offset = "0xED8340", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60003D0")]
			[Address(RVA = "0xED8348", Offset = "0xED8348", Length = "0x84")]
			set
			{
			}
		}

		[Token(Token = "0x1700010E")]
		public Direction direction
		{
			[Token(Token = "0x60003D1")]
			[Address(RVA = "0xED83CC", Offset = "0xED83CC", Length = "0x8")]
			get
			{
				return Direction.LeftToRight;
			}
			[Token(Token = "0x60003D2")]
			[Address(RVA = "0xED83D4", Offset = "0xED83D4", Length = "0x7C")]
			set
			{
			}
		}

		[Token(Token = "0x1700010F")]
		public float minValue
		{
			[Token(Token = "0x60003D3")]
			[Address(RVA = "0xED8450", Offset = "0xED8450", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60003D4")]
			[Address(RVA = "0xED8458", Offset = "0xED8458", Length = "0x98")]
			set
			{
			}
		}

		[Token(Token = "0x17000110")]
		public float maxValue
		{
			[Token(Token = "0x60003D5")]
			[Address(RVA = "0xED84F0", Offset = "0xED84F0", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60003D6")]
			[Address(RVA = "0xED84F8", Offset = "0xED84F8", Length = "0x98")]
			set
			{
			}
		}

		[Token(Token = "0x17000111")]
		public bool wholeNumbers
		{
			[Token(Token = "0x60003D7")]
			[Address(RVA = "0xED8590", Offset = "0xED8590", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60003D8")]
			[Address(RVA = "0xED8598", Offset = "0xED8598", Length = "0x98")]
			set
			{
			}
		}

		[Token(Token = "0x17000112")]
		public virtual float value
		{
			[Token(Token = "0x60003D9")]
			[Address(RVA = "0xED8630", Offset = "0xED8630", Length = "0xEC")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60003DA")]
			[Address(RVA = "0xED871C", Offset = "0xED871C", Length = "0x14")]
			set
			{
			}
		}

		[Token(Token = "0x17000113")]
		public float normalizedValue
		{
			[Token(Token = "0x60003DC")]
			[Address(RVA = "0xED8744", Offset = "0xED8744", Length = "0xE4")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60003DD")]
			[Address(RVA = "0xED8828", Offset = "0xED8828", Length = "0x9C")]
			set
			{
			}
		}

		[Token(Token = "0x17000114")]
		public SliderEvent onValueChanged
		{
			[Token(Token = "0x60003DE")]
			[Address(RVA = "0xED88C4", Offset = "0xED88C4", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60003DF")]
			[Address(RVA = "0xED88CC", Offset = "0xED88CC", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000115")]
		private float stepSize
		{
			[Token(Token = "0x60003E0")]
			[Address(RVA = "0xED88D4", Offset = "0xED88D4", Length = "0x28")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000116")]
		private Axis axis
		{
			[Token(Token = "0x60003ED")]
			[Address(RVA = "0xED8E0C", Offset = "0xED8E0C", Length = "0x10")]
			get
			{
				return Axis.Horizontal;
			}
		}

		[Token(Token = "0x17000117")]
		private bool reverseValue
		{
			[Token(Token = "0x60003EE")]
			[Address(RVA = "0xED8DF8", Offset = "0xED8DF8", Length = "0x14")]
			get
			{
				return false;
			}
		}

		Transform ICanvasElement.transform
		{
			[Token(Token = "0x60003FB")]
			[Address(RVA = "0xED98E0", Offset = "0xED98E0", Length = "0x184")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x60003DB")]
		[Address(RVA = "0xED8730", Offset = "0xED8730", Length = "0x14")]
		public virtual void SetValueWithoutNotify(float input)
		{
		}

		[Token(Token = "0x60003E1")]
		[Address(RVA = "0xED88FC", Offset = "0xED88FC", Length = "0xB8")]
		protected Slider()
		{
		}

		[Token(Token = "0x60003E2")]
		[Address(RVA = "0xED8A04", Offset = "0xED8A04", Length = "0x4")]
		public virtual void Rebuild(CanvasUpdate executing)
		{
		}

		[Token(Token = "0x60003E3")]
		[Address(RVA = "0xED8A08", Offset = "0xED8A08", Length = "0x4")]
		public virtual void LayoutComplete()
		{
		}

		[Token(Token = "0x60003E4")]
		[Address(RVA = "0xED8A0C", Offset = "0xED8A0C", Length = "0x4")]
		public virtual void GraphicUpdateComplete()
		{
		}

		[Token(Token = "0x60003E5")]
		[Address(RVA = "0xED8A10", Offset = "0xED8A10", Length = "0x48")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x60003E6")]
		[Address(RVA = "0xED8A58", Offset = "0xED8A58", Length = "0x2C")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x60003E7")]
		[Address(RVA = "0xED8A84", Offset = "0xED8A84", Length = "0x14")]
		protected virtual void Update()
		{
		}

		[Token(Token = "0x60003E8")]
		[Address(RVA = "0xED8A98", Offset = "0xED8A98", Length = "0x238")]
		protected override void OnDidApplyAnimationProperties()
		{
		}

		[Token(Token = "0x60003E9")]
		[Address(RVA = "0xED7DB4", Offset = "0xED7DB4", Length = "0x2C8")]
		private void UpdateCachedReferences()
		{
		}

		[Token(Token = "0x60003EA")]
		[Address(RVA = "0xED8CD0", Offset = "0xED8CD0", Length = "0x128")]
		private float ClampValue(float input)
		{
			return 0f;
		}

		[Token(Token = "0x60003EB")]
		[Address(RVA = "0xED8E1C", Offset = "0xED8E1C", Length = "0xCC")]
		protected virtual void Set(float input, bool sendCallback = true)
		{
		}

		[Token(Token = "0x60003EC")]
		[Address(RVA = "0xED8EE8", Offset = "0xED8EE8", Length = "0x48")]
		protected override void OnRectTransformDimensionsChange()
		{
		}

		[Token(Token = "0x60003EF")]
		[Address(RVA = "0xED807C", Offset = "0xED807C", Length = "0x2C4")]
		private void UpdateVisuals()
		{
		}

		[Token(Token = "0x60003F0")]
		[Address(RVA = "0xED8F30", Offset = "0xED8F30", Length = "0x26C")]
		private void UpdateDrag(PointerEventData eventData, Camera cam)
		{
		}

		[Token(Token = "0x60003F1")]
		[Address(RVA = "0xED919C", Offset = "0xED919C", Length = "0x6C")]
		private bool MayDrag(PointerEventData eventData)
		{
			return false;
		}

		[Token(Token = "0x60003F2")]
		[Address(RVA = "0xED9208", Offset = "0xED9208", Length = "0x1CC")]
		public override void OnPointerDown(PointerEventData eventData)
		{
		}

		[Token(Token = "0x60003F3")]
		[Address(RVA = "0xED93D4", Offset = "0xED93D4", Length = "0x58")]
		public virtual void OnDrag(PointerEventData eventData)
		{
		}

		[Token(Token = "0x60003F4")]
		[Address(RVA = "0xED942C", Offset = "0xED942C", Length = "0x274")]
		public override void OnMove(AxisEventData eventData)
		{
		}

		[Token(Token = "0x60003F5")]
		[Address(RVA = "0xED96A0", Offset = "0xED96A0", Length = "0x24")]
		public override Selectable FindSelectableOnLeft()
		{
			return null;
		}

		[Token(Token = "0x60003F6")]
		[Address(RVA = "0xED96C4", Offset = "0xED96C4", Length = "0x24")]
		public override Selectable FindSelectableOnRight()
		{
			return null;
		}

		[Token(Token = "0x60003F7")]
		[Address(RVA = "0xED96E8", Offset = "0xED96E8", Length = "0x24")]
		public override Selectable FindSelectableOnUp()
		{
			return null;
		}

		[Token(Token = "0x60003F8")]
		[Address(RVA = "0xED970C", Offset = "0xED970C", Length = "0x24")]
		public override Selectable FindSelectableOnDown()
		{
			return null;
		}

		[Token(Token = "0x60003F9")]
		[Address(RVA = "0xED9730", Offset = "0xED9730", Length = "0x1C")]
		public virtual void OnInitializePotentialDrag(PointerEventData eventData)
		{
		}

		[Token(Token = "0x60003FA")]
		[Address(RVA = "0xED974C", Offset = "0xED974C", Length = "0x194")]
		public void SetDirection(Direction direction, bool includeRectLayouts)
		{
		}
	}
}
