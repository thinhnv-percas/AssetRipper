using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace UnityEngine.UI
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x7277D8", Offset = "0x7277D8")]
	[ExecuteAlways]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x7277D8", Offset = "0x7277D8")]
	[Token(Token = "0x2000031")]
	public class Scrollbar : Selectable, IBeginDragHandler, IEventSystemHandler, IDragHandler, IInitializePotentialDragHandler, ICanvasElement
	{
		[Token(Token = "0x200009E")]
		public enum Direction
		{
			[Token(Token = "0x40002BD")]
			LeftToRight = 0,
			[Token(Token = "0x40002BE")]
			RightToLeft = 1,
			[Token(Token = "0x40002BF")]
			BottomToTop = 2,
			[Token(Token = "0x40002C0")]
			TopToBottom = 3
		}

		[Serializable]
		[Token(Token = "0x200009F")]
		public class ScrollEvent : UnityEvent<float>
		{
			[Token(Token = "0x600066D")]
			[Address(RVA = "0xED3B6C", Offset = "0xED3B6C", Length = "0x50")]
			public ScrollEvent()
			{
			}
		}

		[Token(Token = "0x20000A0")]
		private enum Axis
		{
			[Token(Token = "0x40002C2")]
			Horizontal = 0,
			[Token(Token = "0x40002C3")]
			Vertical = 1
		}

		[SerializeField]
		[Token(Token = "0x4000106")]
		[FieldOffset(Offset = "0xE8")]
		private RectTransform m_HandleRect;

		[SerializeField]
		[Token(Token = "0x4000107")]
		[FieldOffset(Offset = "0xF0")]
		private Direction m_Direction;

		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x7294E4", Offset = "0x7294E4")]
		[SerializeField]
		[Token(Token = "0x4000108")]
		[FieldOffset(Offset = "0xF4")]
		private float m_Value;

		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x729524", Offset = "0x729524")]
		[SerializeField]
		[Token(Token = "0x4000109")]
		[FieldOffset(Offset = "0xF8")]
		private float m_Size;

		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x729564", Offset = "0x729564")]
		[SerializeField]
		[Token(Token = "0x400010A")]
		[FieldOffset(Offset = "0xFC")]
		private int m_NumberOfSteps;

		[Space]
		[SerializeField]
		[Token(Token = "0x400010B")]
		[FieldOffset(Offset = "0x100")]
		private ScrollEvent m_OnValueChanged;

		[Token(Token = "0x400010C")]
		[FieldOffset(Offset = "0x108")]
		private RectTransform m_ContainerRect;

		[Token(Token = "0x400010D")]
		[FieldOffset(Offset = "0x110")]
		private Vector2 m_Offset;

		[Token(Token = "0x400010E")]
		[FieldOffset(Offset = "0x118")]
		private DrivenRectTransformTracker m_Tracker;

		[Token(Token = "0x400010F")]
		[FieldOffset(Offset = "0x120")]
		private Coroutine m_PointerDownRepeat;

		[Token(Token = "0x4000110")]
		[FieldOffset(Offset = "0x128")]
		private bool isPointerDownAndNotDragging;

		[Token(Token = "0x4000111")]
		[FieldOffset(Offset = "0x129")]
		private bool m_DelayedUpdateVisuals;

		[Token(Token = "0x170000D4")]
		public RectTransform handleRect
		{
			[Token(Token = "0x6000306")]
			[Address(RVA = "0xED36C8", Offset = "0xED36C8", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000307")]
			[Address(RVA = "0xED36D0", Offset = "0xED36D0", Length = "0x84")]
			set
			{
			}
		}

		[Token(Token = "0x170000D5")]
		public Direction direction
		{
			[Token(Token = "0x6000308")]
			[Address(RVA = "0xED3A2C", Offset = "0xED3A2C", Length = "0x8")]
			get
			{
				return Direction.LeftToRight;
			}
			[Token(Token = "0x6000309")]
			[Address(RVA = "0xED3A34", Offset = "0xED3A34", Length = "0x7C")]
			set
			{
			}
		}

		[Token(Token = "0x170000D6")]
		public float value
		{
			[Token(Token = "0x600030B")]
			[Address(RVA = "0xED3CA0", Offset = "0xED3CA0", Length = "0x10C")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600030C")]
			[Address(RVA = "0xED1FFC", Offset = "0xED1FFC", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000D7")]
		public float size
		{
			[Token(Token = "0x600030E")]
			[Address(RVA = "0xED3E84", Offset = "0xED3E84", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600030F")]
			[Address(RVA = "0xED1E04", Offset = "0xED1E04", Length = "0xA8")]
			set
			{
			}
		}

		[Token(Token = "0x170000D8")]
		public int numberOfSteps
		{
			[Token(Token = "0x6000310")]
			[Address(RVA = "0xED3E8C", Offset = "0xED3E8C", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x6000311")]
			[Address(RVA = "0xED3E94", Offset = "0xED3E94", Length = "0x8C")]
			set
			{
			}
		}

		[Token(Token = "0x170000D9")]
		public ScrollEvent onValueChanged
		{
			[Token(Token = "0x6000312")]
			[Address(RVA = "0xED3F20", Offset = "0xED3F20", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000313")]
			[Address(RVA = "0xED3F28", Offset = "0xED3F28", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000DA")]
		private float stepSize
		{
			[Token(Token = "0x6000314")]
			[Address(RVA = "0xED3F30", Offset = "0xED3F30", Length = "0x2C")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x170000DB")]
		private Axis axis
		{
			[Token(Token = "0x600031E")]
			[Address(RVA = "0xED42E4", Offset = "0xED42E4", Length = "0x10")]
			get
			{
				return Axis.Horizontal;
			}
		}

		[Token(Token = "0x170000DC")]
		private bool reverseValue
		{
			[Token(Token = "0x600031F")]
			[Address(RVA = "0xED42F4", Offset = "0xED42F4", Length = "0x14")]
			get
			{
				return false;
			}
		}

		Transform ICanvasElement.transform
		{
			[Token(Token = "0x6000330")]
			[Address(RVA = "0xED5708", Offset = "0xED5708", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x600030A")]
		[Address(RVA = "0xED3AB0", Offset = "0xED3AB0", Length = "0xBC")]
		protected Scrollbar()
		{
		}

		[Token(Token = "0x600030D")]
		[Address(RVA = "0xED3E7C", Offset = "0xED3E7C", Length = "0x8")]
		public virtual void SetValueWithoutNotify(float input)
		{
		}

		[Token(Token = "0x6000315")]
		[Address(RVA = "0xED3F5C", Offset = "0xED3F5C", Length = "0x4")]
		public virtual void Rebuild(CanvasUpdate executing)
		{
		}

		[Token(Token = "0x6000316")]
		[Address(RVA = "0xED3F60", Offset = "0xED3F60", Length = "0x4")]
		public virtual void LayoutComplete()
		{
		}

		[Token(Token = "0x6000317")]
		[Address(RVA = "0xED3F64", Offset = "0xED3F64", Length = "0x4")]
		public virtual void GraphicUpdateComplete()
		{
		}

		[Token(Token = "0x6000318")]
		[Address(RVA = "0xED3F68", Offset = "0xED3F68", Length = "0x3C")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x6000319")]
		[Address(RVA = "0xED41C4", Offset = "0xED41C4", Length = "0x2C")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x600031A")]
		[Address(RVA = "0xED4288", Offset = "0xED4288", Length = "0x14")]
		protected virtual void Update()
		{
		}

		[Token(Token = "0x600031B")]
		[Address(RVA = "0xED3754", Offset = "0xED3754", Length = "0xFC")]
		private void UpdateCachedReferences()
		{
		}

		[Token(Token = "0x600031C")]
		[Address(RVA = "0xED3DAC", Offset = "0xED3DAC", Length = "0xD0")]
		private void Set(float input, bool sendCallback = true)
		{
		}

		[Token(Token = "0x600031D")]
		[Address(RVA = "0xED429C", Offset = "0xED429C", Length = "0x48")]
		protected override void OnRectTransformDimensionsChange()
		{
		}

		[Token(Token = "0x6000320")]
		[Address(RVA = "0xED3850", Offset = "0xED3850", Length = "0x1DC")]
		private void UpdateVisuals()
		{
		}

		[Token(Token = "0x6000321")]
		[Address(RVA = "0xED4308", Offset = "0xED4308", Length = "0x284")]
		private void UpdateDrag(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000322")]
		[Address(RVA = "0xED458C", Offset = "0xED458C", Length = "0x144")]
		private void DoUpdateDrag(Vector2 handleCorner, float remainingSize)
		{
		}

		[Token(Token = "0x6000323")]
		[Address(RVA = "0xED46D0", Offset = "0xED46D0", Length = "0x6C")]
		private bool MayDrag(PointerEventData eventData)
		{
			return false;
		}

		[Token(Token = "0x6000324")]
		[Address(RVA = "0xED473C", Offset = "0xED473C", Length = "0x210")]
		public virtual void OnBeginDrag(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000325")]
		[Address(RVA = "0xED494C", Offset = "0xED494C", Length = "0xAC")]
		public virtual void OnDrag(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000326")]
		[Address(RVA = "0xED49F8", Offset = "0xED49F8", Length = "0x5C")]
		public override void OnPointerDown(PointerEventData eventData)
		{
		}

		[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x72A288", Offset = "0x72A288")]
		[Token(Token = "0x6000327")]
		[Address(RVA = "0xED4B9C", Offset = "0xED4B9C", Length = "0x80")]
		protected IEnumerator ClickRepeat(PointerEventData eventData)
		{
			return null;
		}

		[Token(Token = "0x6000328")]
		[Address(RVA = "0xED4C48", Offset = "0xED4C48", Length = "0x24")]
		public override void OnPointerUp(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000329")]
		[Address(RVA = "0xED4C94", Offset = "0xED4C94", Length = "0x298")]
		public override void OnMove(AxisEventData eventData)
		{
		}

		[Token(Token = "0x600032A")]
		[Address(RVA = "0xED4FC8", Offset = "0xED4FC8", Length = "0x24")]
		public override Selectable FindSelectableOnLeft()
		{
			return null;
		}

		[Token(Token = "0x600032B")]
		[Address(RVA = "0xED512C", Offset = "0xED512C", Length = "0x24")]
		public override Selectable FindSelectableOnRight()
		{
			return null;
		}

		[Token(Token = "0x600032C")]
		[Address(RVA = "0xED5290", Offset = "0xED5290", Length = "0x24")]
		public override Selectable FindSelectableOnUp()
		{
			return null;
		}

		[Token(Token = "0x600032D")]
		[Address(RVA = "0xED53F4", Offset = "0xED53F4", Length = "0x24")]
		public override Selectable FindSelectableOnDown()
		{
			return null;
		}

		[Token(Token = "0x600032E")]
		[Address(RVA = "0xED5558", Offset = "0xED5558", Length = "0x1C")]
		public virtual void OnInitializePotentialDrag(PointerEventData eventData)
		{
		}

		[Token(Token = "0x600032F")]
		[Address(RVA = "0xED5574", Offset = "0xED5574", Length = "0x194")]
		public void SetDirection(Direction direction, bool includeRectLayouts)
		{
		}
	}
}
