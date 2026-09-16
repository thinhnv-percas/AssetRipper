using System;
using Cpp2ILInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace UnityEngine.UI
{
	[RequireComponent(typeof(RectTransform))]
	[ExecuteAlways]
	[AddComponentMenu("UI/Slider", 34)]
	[Token(Token = "0x200006D")]
	public class Slider : Selectable, IDragHandler, IEventSystemHandler, IInitializePotentialDragHandler, ICanvasElement
	{
		[Token(Token = "0x200006E")]
		public enum Direction
		{
			[Token(Token = "0x4000232")]
			LeftToRight = 0,
			[Token(Token = "0x4000233")]
			RightToLeft = 1,
			[Token(Token = "0x4000234")]
			BottomToTop = 2,
			[Token(Token = "0x4000235")]
			TopToBottom = 3
		}

		[Serializable]
		[Token(Token = "0x200006F")]
		public class SliderEvent : UnityEvent<float>
		{
			[Token(Token = "0x6000491")]
			[Address(RVA = "0x1836A60", Offset = "0x1836A60", Length = "0x48")]
			public SliderEvent()
			{
			}
		}

		[Token(Token = "0x2000070")]
		private enum Axis
		{
			[Token(Token = "0x4000237")]
			Horizontal = 0,
			[Token(Token = "0x4000238")]
			Vertical = 1
		}

		[SerializeField]
		[Token(Token = "0x4000221")]
		[FieldOffset(Offset = "0x100")]
		private RectTransform m_FillRect;

		[SerializeField]
		[Token(Token = "0x4000222")]
		[FieldOffset(Offset = "0x108")]
		private RectTransform m_HandleRect;

		[Space]
		[SerializeField]
		[Token(Token = "0x4000223")]
		[FieldOffset(Offset = "0x110")]
		private Direction m_Direction;

		[SerializeField]
		[Token(Token = "0x4000224")]
		[FieldOffset(Offset = "0x114")]
		private float m_MinValue;

		[SerializeField]
		[Token(Token = "0x4000225")]
		[FieldOffset(Offset = "0x118")]
		private float m_MaxValue;

		[SerializeField]
		[Token(Token = "0x4000226")]
		[FieldOffset(Offset = "0x11C")]
		private bool m_WholeNumbers;

		[SerializeField]
		[Token(Token = "0x4000227")]
		[FieldOffset(Offset = "0x120")]
		protected float m_Value;

		[SerializeField]
		[Space]
		[Token(Token = "0x4000228")]
		[FieldOffset(Offset = "0x128")]
		private SliderEvent m_OnValueChanged;

		[Token(Token = "0x4000229")]
		[FieldOffset(Offset = "0x130")]
		private Image m_FillImage;

		[Token(Token = "0x400022A")]
		[FieldOffset(Offset = "0x138")]
		private Transform m_FillTransform;

		[Token(Token = "0x400022B")]
		[FieldOffset(Offset = "0x140")]
		private RectTransform m_FillContainerRect;

		[Token(Token = "0x400022C")]
		[FieldOffset(Offset = "0x148")]
		private Transform m_HandleTransform;

		[Token(Token = "0x400022D")]
		[FieldOffset(Offset = "0x150")]
		private RectTransform m_HandleContainerRect;

		[Token(Token = "0x400022E")]
		[FieldOffset(Offset = "0x158")]
		private Vector2 m_Offset;

		[Token(Token = "0x400022F")]
		[FieldOffset(Offset = "0x160")]
		private DrivenRectTransformTracker m_Tracker;

		[Token(Token = "0x4000230")]
		[FieldOffset(Offset = "0x161")]
		private bool m_DelayedUpdateVisuals;

		[Token(Token = "0x17000126")]
		public RectTransform fillRect
		{
			[Token(Token = "0x6000462")]
			[Address(RVA = "0x1835EB0", Offset = "0x1835EB0", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000463")]
			[Address(RVA = "0x1835EB8", Offset = "0x1835EB8", Length = "0x7C")]
			set
			{
			}
		}

		[Token(Token = "0x17000127")]
		public RectTransform handleRect
		{
			[Token(Token = "0x6000464")]
			[Address(RVA = "0x18364BC", Offset = "0x18364BC", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000465")]
			[Address(RVA = "0x18364C4", Offset = "0x18364C4", Length = "0x7C")]
			set
			{
			}
		}

		[Token(Token = "0x17000128")]
		public Direction direction
		{
			[Token(Token = "0x6000466")]
			[Address(RVA = "0x1836540", Offset = "0x1836540", Length = "0x8")]
			get
			{
				return Direction.LeftToRight;
			}
			[Token(Token = "0x6000467")]
			[Address(RVA = "0x1836548", Offset = "0x1836548", Length = "0x74")]
			set
			{
			}
		}

		[Token(Token = "0x17000129")]
		public float minValue
		{
			[Token(Token = "0x6000468")]
			[Address(RVA = "0x18365BC", Offset = "0x18365BC", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000469")]
			[Address(RVA = "0x18365C4", Offset = "0x18365C4", Length = "0x90")]
			set
			{
			}
		}

		[Token(Token = "0x1700012A")]
		public float maxValue
		{
			[Token(Token = "0x600046A")]
			[Address(RVA = "0x1836654", Offset = "0x1836654", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600046B")]
			[Address(RVA = "0x183665C", Offset = "0x183665C", Length = "0x90")]
			set
			{
			}
		}

		[Token(Token = "0x1700012B")]
		public bool wholeNumbers
		{
			[Token(Token = "0x600046C")]
			[Address(RVA = "0x18366EC", Offset = "0x18366EC", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x600046D")]
			[Address(RVA = "0x18366F4", Offset = "0x18366F4", Length = "0x90")]
			set
			{
			}
		}

		[Token(Token = "0x1700012C")]
		public virtual float value
		{
			[Token(Token = "0x600046E")]
			[Address(RVA = "0x1836784", Offset = "0x1836784", Length = "0xA0")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600046F")]
			[Address(RVA = "0x1836824", Offset = "0x1836824", Length = "0x14")]
			set
			{
			}
		}

		[Token(Token = "0x1700012D")]
		public float normalizedValue
		{
			[Token(Token = "0x6000471")]
			[Address(RVA = "0x183684C", Offset = "0x183684C", Length = "0xE4")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000472")]
			[Address(RVA = "0x1836930", Offset = "0x1836930", Length = "0x38")]
			set
			{
			}
		}

		[Token(Token = "0x1700012E")]
		public SliderEvent onValueChanged
		{
			[Token(Token = "0x6000473")]
			[Address(RVA = "0x1836968", Offset = "0x1836968", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000474")]
			[Address(RVA = "0x1836970", Offset = "0x1836970", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700012F")]
		private float stepSize
		{
			[Token(Token = "0x6000475")]
			[Address(RVA = "0x1836978", Offset = "0x1836978", Length = "0x2C")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000130")]
		private Axis axis
		{
			[Token(Token = "0x6000482")]
			[Address(RVA = "0x1836E00", Offset = "0x1836E00", Length = "0x10")]
			get
			{
				return Axis.Horizontal;
			}
		}

		[Token(Token = "0x17000131")]
		private bool reverseValue
		{
			[Token(Token = "0x6000483")]
			[Address(RVA = "0x1836DEC", Offset = "0x1836DEC", Length = "0x14")]
			get
			{
				return false;
			}
		}

		Transform ICanvasElement.transform
		{
			[Token(Token = "0x6000490")]
			[Address(RVA = "0x18377EC", Offset = "0x18377EC", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x6000470")]
		[Address(RVA = "0x1836838", Offset = "0x1836838", Length = "0x14")]
		public virtual void SetValueWithoutNotify(float input)
		{
		}

		[Token(Token = "0x6000476")]
		[Address(RVA = "0x18369A4", Offset = "0x18369A4", Length = "0xBC")]
		protected Slider()
		{
		}

		[Token(Token = "0x6000477")]
		[Address(RVA = "0x1836AA8", Offset = "0x1836AA8", Length = "0x4")]
		public virtual void Rebuild(CanvasUpdate executing)
		{
		}

		[Token(Token = "0x6000478")]
		[Address(RVA = "0x1836AAC", Offset = "0x1836AAC", Length = "0x4")]
		public virtual void LayoutComplete()
		{
		}

		[Token(Token = "0x6000479")]
		[Address(RVA = "0x1836AB0", Offset = "0x1836AB0", Length = "0x4")]
		public virtual void GraphicUpdateComplete()
		{
		}

		[Token(Token = "0x600047A")]
		[Address(RVA = "0x1836AB4", Offset = "0x1836AB4", Length = "0x3C")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x600047B")]
		[Address(RVA = "0x1836AF0", Offset = "0x1836AF0", Length = "0x20")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x600047C")]
		[Address(RVA = "0x1836B10", Offset = "0x1836B10", Length = "0x40")]
		protected virtual void Update()
		{
		}

		[Token(Token = "0x600047D")]
		[Address(RVA = "0x1836B50", Offset = "0x1836B50", Length = "0x1E8")]
		protected override void OnDidApplyAnimationProperties()
		{
		}

		[Token(Token = "0x600047E")]
		[Address(RVA = "0x1835F34", Offset = "0x1835F34", Length = "0x2A4")]
		private void UpdateCachedReferences()
		{
		}

		[Token(Token = "0x600047F")]
		[Address(RVA = "0x1836D38", Offset = "0x1836D38", Length = "0xB4")]
		private float ClampValue(float input)
		{
			return 0f;
		}

		[Token(Token = "0x6000480")]
		[Address(RVA = "0x1836E10", Offset = "0x1836E10", Length = "0xC4")]
		protected virtual void Set(float input, bool sendCallback = true)
		{
		}

		[Token(Token = "0x6000481")]
		[Address(RVA = "0x1836ED4", Offset = "0x1836ED4", Length = "0x38")]
		protected override void OnRectTransformDimensionsChange()
		{
		}

		[Token(Token = "0x6000484")]
		[Address(RVA = "0x18361D8", Offset = "0x18361D8", Length = "0x2E4")]
		private void UpdateVisuals()
		{
		}

		[Token(Token = "0x6000485")]
		[Address(RVA = "0x1836F0C", Offset = "0x1836F0C", Length = "0x1F8")]
		private void UpdateDrag(PointerEventData eventData, Camera cam)
		{
		}

		[Token(Token = "0x6000486")]
		[Address(RVA = "0x1837104", Offset = "0x1837104", Length = "0x64")]
		private bool MayDrag(PointerEventData eventData)
		{
			return false;
		}

		[Token(Token = "0x6000487")]
		[Address(RVA = "0x1837168", Offset = "0x1837168", Length = "0x1B8")]
		public override void OnPointerDown(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000488")]
		[Address(RVA = "0x1837320", Offset = "0x1837320", Length = "0x50")]
		public virtual void OnDrag(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000489")]
		[Address(RVA = "0x1837370", Offset = "0x1837370", Length = "0x24C")]
		public override void OnMove(AxisEventData eventData)
		{
		}

		[Token(Token = "0x600048A")]
		[Address(RVA = "0x18375BC", Offset = "0x18375BC", Length = "0x24")]
		public override Selectable FindSelectableOnLeft()
		{
			return null;
		}

		[Token(Token = "0x600048B")]
		[Address(RVA = "0x18375E0", Offset = "0x18375E0", Length = "0x24")]
		public override Selectable FindSelectableOnRight()
		{
			return null;
		}

		[Token(Token = "0x600048C")]
		[Address(RVA = "0x1837604", Offset = "0x1837604", Length = "0x24")]
		public override Selectable FindSelectableOnUp()
		{
			return null;
		}

		[Token(Token = "0x600048D")]
		[Address(RVA = "0x1837628", Offset = "0x1837628", Length = "0x24")]
		public override Selectable FindSelectableOnDown()
		{
			return null;
		}

		[Token(Token = "0x600048E")]
		[Address(RVA = "0x183764C", Offset = "0x183764C", Length = "0x18")]
		public virtual void OnInitializePotentialDrag(PointerEventData eventData)
		{
		}

		[Token(Token = "0x600048F")]
		[Address(RVA = "0x1837664", Offset = "0x1837664", Length = "0x188")]
		public void SetDirection(Direction direction, bool includeRectLayouts)
		{
		}
	}
}
