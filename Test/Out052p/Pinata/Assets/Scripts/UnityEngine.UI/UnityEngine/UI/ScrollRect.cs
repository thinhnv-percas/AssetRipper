using System;
using Cpp2ILInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace UnityEngine.UI
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x727874", Offset = "0x727874")]
	[SelectionBase]
	[ExecuteAlways]
	[DisallowMultipleComponent]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x727874", Offset = "0x727874")]
	[Token(Token = "0x2000032")]
	public class ScrollRect : UIBehaviour, IInitializePotentialDragHandler, IEventSystemHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IScrollHandler, ICanvasElement, ILayoutElement, ILayoutGroup, ILayoutController
	{
		[Token(Token = "0x20000A2")]
		public enum MovementType
		{
			[Token(Token = "0x40002C9")]
			Unrestricted = 0,
			[Token(Token = "0x40002CA")]
			Elastic = 1,
			[Token(Token = "0x40002CB")]
			Clamped = 2
		}

		[Token(Token = "0x20000A3")]
		public enum ScrollbarVisibility
		{
			[Token(Token = "0x40002CD")]
			Permanent = 0,
			[Token(Token = "0x40002CE")]
			AutoHide = 1,
			[Token(Token = "0x40002CF")]
			AutoHideAndExpandViewport = 2
		}

		[Serializable]
		[Token(Token = "0x20000A4")]
		public class ScrollRectEvent : UnityEvent<Vector2>
		{
			[Token(Token = "0x6000674")]
			[Address(RVA = "0xECFB78", Offset = "0xECFB78", Length = "0x50")]
			public ScrollRectEvent()
			{
			}
		}

		[SerializeField]
		[Token(Token = "0x4000112")]
		[FieldOffset(Offset = "0x18")]
		private RectTransform m_Content;

		[SerializeField]
		[Token(Token = "0x4000113")]
		[FieldOffset(Offset = "0x20")]
		private bool m_Horizontal;

		[SerializeField]
		[Token(Token = "0x4000114")]
		[FieldOffset(Offset = "0x21")]
		private bool m_Vertical;

		[SerializeField]
		[Token(Token = "0x4000115")]
		[FieldOffset(Offset = "0x24")]
		private MovementType m_MovementType;

		[SerializeField]
		[Token(Token = "0x4000116")]
		[FieldOffset(Offset = "0x28")]
		private float m_Elasticity;

		[SerializeField]
		[Token(Token = "0x4000117")]
		[FieldOffset(Offset = "0x2C")]
		private bool m_Inertia;

		[SerializeField]
		[Token(Token = "0x4000118")]
		[FieldOffset(Offset = "0x30")]
		private float m_DecelerationRate;

		[SerializeField]
		[Token(Token = "0x4000119")]
		[FieldOffset(Offset = "0x34")]
		private float m_ScrollSensitivity;

		[SerializeField]
		[Token(Token = "0x400011A")]
		[FieldOffset(Offset = "0x38")]
		private RectTransform m_Viewport;

		[SerializeField]
		[Token(Token = "0x400011B")]
		[FieldOffset(Offset = "0x40")]
		private Scrollbar m_HorizontalScrollbar;

		[SerializeField]
		[Token(Token = "0x400011C")]
		[FieldOffset(Offset = "0x48")]
		private Scrollbar m_VerticalScrollbar;

		[SerializeField]
		[Token(Token = "0x400011D")]
		[FieldOffset(Offset = "0x50")]
		private ScrollbarVisibility m_HorizontalScrollbarVisibility;

		[SerializeField]
		[Token(Token = "0x400011E")]
		[FieldOffset(Offset = "0x54")]
		private ScrollbarVisibility m_VerticalScrollbarVisibility;

		[SerializeField]
		[Token(Token = "0x400011F")]
		[FieldOffset(Offset = "0x58")]
		private float m_HorizontalScrollbarSpacing;

		[SerializeField]
		[Token(Token = "0x4000120")]
		[FieldOffset(Offset = "0x5C")]
		private float m_VerticalScrollbarSpacing;

		[SerializeField]
		[Token(Token = "0x4000121")]
		[FieldOffset(Offset = "0x60")]
		private ScrollRectEvent m_OnValueChanged;

		[Token(Token = "0x4000122")]
		[FieldOffset(Offset = "0x68")]
		private Vector2 m_PointerStartLocalCursor;

		[Token(Token = "0x4000123")]
		[FieldOffset(Offset = "0x70")]
		protected Vector2 m_ContentStartPosition;

		[Token(Token = "0x4000124")]
		[FieldOffset(Offset = "0x78")]
		private RectTransform m_ViewRect;

		[Token(Token = "0x4000125")]
		[FieldOffset(Offset = "0x80")]
		protected Bounds m_ContentBounds;

		[Token(Token = "0x4000126")]
		[FieldOffset(Offset = "0x98")]
		private Bounds m_ViewBounds;

		[Token(Token = "0x4000127")]
		[FieldOffset(Offset = "0xB0")]
		private Vector2 m_Velocity;

		[Token(Token = "0x4000128")]
		[FieldOffset(Offset = "0xB8")]
		private bool m_Dragging;

		[Token(Token = "0x4000129")]
		[FieldOffset(Offset = "0xB9")]
		private bool m_Scrolling;

		[Token(Token = "0x400012A")]
		[FieldOffset(Offset = "0xBC")]
		private Vector2 m_PrevPosition;

		[Token(Token = "0x400012B")]
		[FieldOffset(Offset = "0xC4")]
		private Bounds m_PrevContentBounds;

		[Token(Token = "0x400012C")]
		[FieldOffset(Offset = "0xDC")]
		private Bounds m_PrevViewBounds;

		[NonSerialized]
		[Token(Token = "0x400012D")]
		[FieldOffset(Offset = "0xF4")]
		private bool m_HasRebuiltLayout;

		[Token(Token = "0x400012E")]
		[FieldOffset(Offset = "0xF5")]
		private bool m_HSliderExpand;

		[Token(Token = "0x400012F")]
		[FieldOffset(Offset = "0xF6")]
		private bool m_VSliderExpand;

		[Token(Token = "0x4000130")]
		[FieldOffset(Offset = "0xF8")]
		private float m_HSliderHeight;

		[Token(Token = "0x4000131")]
		[FieldOffset(Offset = "0xFC")]
		private float m_VSliderWidth;

		[NonSerialized]
		[Token(Token = "0x4000132")]
		[FieldOffset(Offset = "0x100")]
		private RectTransform m_Rect;

		[Token(Token = "0x4000133")]
		[FieldOffset(Offset = "0x108")]
		private RectTransform m_HorizontalScrollbarRect;

		[Token(Token = "0x4000134")]
		[FieldOffset(Offset = "0x110")]
		private RectTransform m_VerticalScrollbarRect;

		[Token(Token = "0x4000135")]
		[FieldOffset(Offset = "0x118")]
		private DrivenRectTransformTracker m_Tracker;

		[Token(Token = "0x4000136")]
		[FieldOffset(Offset = "0x120")]
		private readonly Vector3[] m_Corners;

		[Token(Token = "0x170000DD")]
		public RectTransform content
		{
			[Token(Token = "0x6000331")]
			[Address(RVA = "0xECF3AC", Offset = "0xECF3AC", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000332")]
			[Address(RVA = "0xECF3B4", Offset = "0xECF3B4", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000DE")]
		public bool horizontal
		{
			[Token(Token = "0x6000333")]
			[Address(RVA = "0xECF3BC", Offset = "0xECF3BC", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000334")]
			[Address(RVA = "0xECF3C4", Offset = "0xECF3C4", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x170000DF")]
		public bool vertical
		{
			[Token(Token = "0x6000335")]
			[Address(RVA = "0xECF3D0", Offset = "0xECF3D0", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000336")]
			[Address(RVA = "0xECF3D8", Offset = "0xECF3D8", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x170000E0")]
		public MovementType movementType
		{
			[Token(Token = "0x6000337")]
			[Address(RVA = "0xECF3E4", Offset = "0xECF3E4", Length = "0x8")]
			get
			{
				return MovementType.Unrestricted;
			}
			[Token(Token = "0x6000338")]
			[Address(RVA = "0xECF3EC", Offset = "0xECF3EC", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000E1")]
		public float elasticity
		{
			[Token(Token = "0x6000339")]
			[Address(RVA = "0xECF3F4", Offset = "0xECF3F4", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600033A")]
			[Address(RVA = "0xECF3FC", Offset = "0xECF3FC", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000E2")]
		public bool inertia
		{
			[Token(Token = "0x600033B")]
			[Address(RVA = "0xECF404", Offset = "0xECF404", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x600033C")]
			[Address(RVA = "0xECF40C", Offset = "0xECF40C", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x170000E3")]
		public float decelerationRate
		{
			[Token(Token = "0x600033D")]
			[Address(RVA = "0xECF418", Offset = "0xECF418", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600033E")]
			[Address(RVA = "0xECF420", Offset = "0xECF420", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000E4")]
		public float scrollSensitivity
		{
			[Token(Token = "0x600033F")]
			[Address(RVA = "0xECF428", Offset = "0xECF428", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000340")]
			[Address(RVA = "0xECF430", Offset = "0xECF430", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000E5")]
		public RectTransform viewport
		{
			[Token(Token = "0x6000341")]
			[Address(RVA = "0xECF438", Offset = "0xECF438", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000342")]
			[Address(RVA = "0xECF440", Offset = "0xECF440", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000E6")]
		public Scrollbar horizontalScrollbar
		{
			[Token(Token = "0x6000343")]
			[Address(RVA = "0xECF508", Offset = "0xECF508", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000344")]
			[Address(RVA = "0xECF510", Offset = "0xECF510", Length = "0x178")]
			set
			{
			}
		}

		[Token(Token = "0x170000E7")]
		public Scrollbar verticalScrollbar
		{
			[Token(Token = "0x6000345")]
			[Address(RVA = "0xECF688", Offset = "0xECF688", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000346")]
			[Address(RVA = "0xECF690", Offset = "0xECF690", Length = "0x178")]
			set
			{
			}
		}

		[Token(Token = "0x170000E8")]
		public ScrollbarVisibility horizontalScrollbarVisibility
		{
			[Token(Token = "0x6000347")]
			[Address(RVA = "0xECF808", Offset = "0xECF808", Length = "0x8")]
			get
			{
				return ScrollbarVisibility.Permanent;
			}
			[Token(Token = "0x6000348")]
			[Address(RVA = "0xECF810", Offset = "0xECF810", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000E9")]
		public ScrollbarVisibility verticalScrollbarVisibility
		{
			[Token(Token = "0x6000349")]
			[Address(RVA = "0xECF818", Offset = "0xECF818", Length = "0x8")]
			get
			{
				return ScrollbarVisibility.Permanent;
			}
			[Token(Token = "0x600034A")]
			[Address(RVA = "0xECF820", Offset = "0xECF820", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000EA")]
		public float horizontalScrollbarSpacing
		{
			[Token(Token = "0x600034B")]
			[Address(RVA = "0xECF828", Offset = "0xECF828", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600034C")]
			[Address(RVA = "0xECF830", Offset = "0xECF830", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000EB")]
		public float verticalScrollbarSpacing
		{
			[Token(Token = "0x600034D")]
			[Address(RVA = "0xECF8CC", Offset = "0xECF8CC", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600034E")]
			[Address(RVA = "0xECF8D4", Offset = "0xECF8D4", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000EC")]
		public ScrollRectEvent onValueChanged
		{
			[Token(Token = "0x600034F")]
			[Address(RVA = "0xECF8DC", Offset = "0xECF8DC", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000350")]
			[Address(RVA = "0xECF8E4", Offset = "0xECF8E4", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000ED")]
		protected RectTransform viewRect
		{
			[Token(Token = "0x6000351")]
			[Address(RVA = "0xECF8EC", Offset = "0xECF8EC", Length = "0xF4")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000EE")]
		public Vector2 velocity
		{
			[Token(Token = "0x6000352")]
			[Address(RVA = "0xECF9E0", Offset = "0xECF9E0", Length = "0x8")]
			get
			{
				return default(Vector2);
			}
			[Token(Token = "0x6000353")]
			[Address(RVA = "0xECF9E8", Offset = "0xECF9E8", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000EF")]
		private RectTransform rectTransform
		{
			[Token(Token = "0x6000354")]
			[Address(RVA = "0xECF9F0", Offset = "0xECF9F0", Length = "0x98")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000F0")]
		public Vector2 normalizedPosition
		{
			[Token(Token = "0x6000368")]
			[Address(RVA = "0xED1D60", Offset = "0xED1D60", Length = "0x58")]
			get
			{
				return default(Vector2);
			}
			[Token(Token = "0x6000369")]
			[Address(RVA = "0xED2154", Offset = "0xED2154", Length = "0x54")]
			set
			{
			}
		}

		[Token(Token = "0x170000F1")]
		public float horizontalNormalizedPosition
		{
			[Token(Token = "0x600036A")]
			[Address(RVA = "0xED1EAC", Offset = "0xED1EAC", Length = "0x150")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600036B")]
			[Address(RVA = "0xED21A8", Offset = "0xED21A8", Length = "0x14")]
			set
			{
			}
		}

		[Token(Token = "0x170000F2")]
		public float verticalNormalizedPosition
		{
			[Token(Token = "0x600036C")]
			[Address(RVA = "0xED2004", Offset = "0xED2004", Length = "0x150")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600036D")]
			[Address(RVA = "0xED21BC", Offset = "0xED21BC", Length = "0x14")]
			set
			{
			}
		}

		[Token(Token = "0x170000F3")]
		private bool hScrollingNeeded
		{
			[Token(Token = "0x6000373")]
			[Address(RVA = "0xED2418", Offset = "0xED2418", Length = "0x68")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x170000F4")]
		private bool vScrollingNeeded
		{
			[Token(Token = "0x6000374")]
			[Address(RVA = "0xED2480", Offset = "0xED2480", Length = "0x68")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x170000F5")]
		public virtual float minWidth
		{
			[Token(Token = "0x6000377")]
			[Address(RVA = "0xED24F0", Offset = "0xED24F0", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x170000F6")]
		public virtual float preferredWidth
		{
			[Token(Token = "0x6000378")]
			[Address(RVA = "0xED24F8", Offset = "0xED24F8", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x170000F7")]
		public virtual float flexibleWidth
		{
			[Token(Token = "0x6000379")]
			[Address(RVA = "0xED2500", Offset = "0xED2500", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x170000F8")]
		public virtual float minHeight
		{
			[Token(Token = "0x600037A")]
			[Address(RVA = "0xED2508", Offset = "0xED2508", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x170000F9")]
		public virtual float preferredHeight
		{
			[Token(Token = "0x600037B")]
			[Address(RVA = "0xED2510", Offset = "0xED2510", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x170000FA")]
		public virtual float flexibleHeight
		{
			[Token(Token = "0x600037C")]
			[Address(RVA = "0xED2518", Offset = "0xED2518", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x170000FB")]
		public virtual int layoutPriority
		{
			[Token(Token = "0x600037D")]
			[Address(RVA = "0xED2520", Offset = "0xED2520", Length = "0x8")]
			get
			{
				return 0;
			}
		}

		Transform ICanvasElement.transform
		{
			[Token(Token = "0x600038B")]
			[Address(RVA = "0xED36C0", Offset = "0xED36C0", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x6000355")]
		[Address(RVA = "0xECFA88", Offset = "0xECFA88", Length = "0xF0")]
		protected ScrollRect()
		{
		}

		[Token(Token = "0x6000356")]
		[Address(RVA = "0xECFBC8", Offset = "0xECFBC8", Length = "0xB4")]
		public virtual void Rebuild(CanvasUpdate executing)
		{
		}

		[Token(Token = "0x6000357")]
		[Address(RVA = "0xED0898", Offset = "0xED0898", Length = "0x4")]
		public virtual void LayoutComplete()
		{
		}

		[Token(Token = "0x6000358")]
		[Address(RVA = "0xED089C", Offset = "0xED089C", Length = "0x4")]
		public virtual void GraphicUpdateComplete()
		{
		}

		[Token(Token = "0x6000359")]
		[Address(RVA = "0xECFC7C", Offset = "0xECFC7C", Length = "0x3C8")]
		private void UpdateCachedData()
		{
		}

		[Token(Token = "0x600035A")]
		[Address(RVA = "0xED08A0", Offset = "0xED08A0", Length = "0x1A4")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x600035B")]
		[Address(RVA = "0xED0A44", Offset = "0xED0A44", Length = "0x214")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x600035C")]
		[Address(RVA = "0xED0C58", Offset = "0xED0C58", Length = "0x90")]
		public override bool IsActive()
		{
			return false;
		}

		[Token(Token = "0x600035D")]
		[Address(RVA = "0xED0CE8", Offset = "0xED0CE8", Length = "0x84")]
		private void EnsureLayoutHasRebuilt()
		{
		}

		[Token(Token = "0x600035E")]
		[Address(RVA = "0xED0D6C", Offset = "0xED0D6C", Length = "0x6C")]
		public virtual void StopMovement()
		{
		}

		[Token(Token = "0x600035F")]
		[Address(RVA = "0xED0DD8", Offset = "0xED0DD8", Length = "0x2B0")]
		public virtual void OnScroll(PointerEventData data)
		{
		}

		[Token(Token = "0x6000360")]
		[Address(RVA = "0xED10C4", Offset = "0xED10C4", Length = "0x8C")]
		public virtual void OnInitializePotentialDrag(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000361")]
		[Address(RVA = "0xED1150", Offset = "0xED1150", Length = "0x134")]
		public virtual void OnBeginDrag(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000362")]
		[Address(RVA = "0xED1284", Offset = "0xED1284", Length = "0x28")]
		public virtual void OnEndDrag(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000363")]
		[Address(RVA = "0xED12AC", Offset = "0xED12AC", Length = "0x248")]
		public virtual void OnDrag(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000364")]
		[Address(RVA = "0xED15A0", Offset = "0xED15A0", Length = "0x118")]
		protected virtual void SetContentAnchoredPosition(Vector2 position)
		{
		}

		[Token(Token = "0x6000365")]
		[Address(RVA = "0xED16B8", Offset = "0xED16B8", Length = "0x6A8")]
		protected virtual void LateUpdate()
		{
		}

		[Token(Token = "0x6000366")]
		[Address(RVA = "0xED07BC", Offset = "0xED07BC", Length = "0xDC")]
		protected void UpdatePrevData()
		{
		}

		[Token(Token = "0x6000367")]
		[Address(RVA = "0xED05A0", Offset = "0xED05A0", Length = "0x21C")]
		private void UpdateScrollbars(Vector2 offset)
		{
		}

		[Token(Token = "0x600036E")]
		[Address(RVA = "0xED21D0", Offset = "0xED21D0", Length = "0x14")]
		private void SetHorizontalNormalizedPosition(float value)
		{
		}

		[Token(Token = "0x600036F")]
		[Address(RVA = "0xED21E4", Offset = "0xED21E4", Length = "0x14")]
		private void SetVerticalNormalizedPosition(float value)
		{
		}

		[Token(Token = "0x6000370")]
		[Address(RVA = "0xED21F8", Offset = "0xED21F8", Length = "0x21C")]
		protected virtual void SetNormalizedPosition(float value, int axis)
		{
		}

		[Token(Token = "0x6000371")]
		[Address(RVA = "0xED14F4", Offset = "0xED14F4", Length = "0xAC")]
		private static float RubberDelta(float overStretching, float viewSize)
		{
			return 0f;
		}

		[Token(Token = "0x6000372")]
		[Address(RVA = "0xED2414", Offset = "0xED2414", Length = "0x4")]
		protected override void OnRectTransformDimensionsChange()
		{
		}

		[Token(Token = "0x6000375")]
		[Address(RVA = "0xED24E8", Offset = "0xED24E8", Length = "0x4")]
		public virtual void CalculateLayoutInputHorizontal()
		{
		}

		[Token(Token = "0x6000376")]
		[Address(RVA = "0xED24EC", Offset = "0xED24EC", Length = "0x4")]
		public virtual void CalculateLayoutInputVertical()
		{
		}

		[Token(Token = "0x600037E")]
		[Address(RVA = "0xED2528", Offset = "0xED2528", Length = "0x5D4")]
		public virtual void SetLayoutHorizontal()
		{
		}

		[Token(Token = "0x600037F")]
		[Address(RVA = "0xED2BF0", Offset = "0xED2BF0", Length = "0x15C")]
		public virtual void SetLayoutVertical()
		{
		}

		[Token(Token = "0x6000380")]
		[Address(RVA = "0xED1DB8", Offset = "0xED1DB8", Length = "0x4C")]
		private void UpdateScrollbarVisibility()
		{
		}

		[Token(Token = "0x6000381")]
		[Address(RVA = "0xED3078", Offset = "0xED3078", Length = "0x108")]
		private static void UpdateOneScrollbarVisibility(bool xScrollingNeeded, bool xAxisEnabled, ScrollbarVisibility scrollbarVisibility, Scrollbar scrollbar)
		{
		}

		[Token(Token = "0x6000382")]
		[Address(RVA = "0xED2D4C", Offset = "0xED2D4C", Length = "0x32C")]
		private void UpdateScrollbarLayout()
		{
		}

		[Token(Token = "0x6000383")]
		[Address(RVA = "0xED0044", Offset = "0xED0044", Length = "0x55C")]
		protected void UpdateBounds()
		{
		}

		[Token(Token = "0x6000384")]
		[Address(RVA = "0xED3180", Offset = "0xED3180", Length = "0x140")]
		internal static void AdjustBounds(ref Bounds viewBounds, ref Vector2 contentPivot, ref Vector3 contentSize, ref Vector3 contentPos)
		{
		}

		[Token(Token = "0x6000385")]
		[Address(RVA = "0xED2AFC", Offset = "0xED2AFC", Length = "0xF4")]
		private Bounds GetBounds()
		{
			return default(Bounds);
		}

		[Token(Token = "0x6000386")]
		[Address(RVA = "0xED32C0", Offset = "0xED32C0", Length = "0x20C")]
		internal static Bounds InternalGetBounds(Vector3[] corners, ref Matrix4x4 viewWorldToLocalMatrix)
		{
			return default(Bounds);
		}

		[Token(Token = "0x6000387")]
		[Address(RVA = "0xED1088", Offset = "0xED1088", Length = "0x3C")]
		private Vector2 CalculateOffset(Vector2 delta)
		{
			return default(Vector2);
		}

		[Token(Token = "0x6000388")]
		[Address(RVA = "0xED34CC", Offset = "0xED34CC", Length = "0x1F4")]
		internal static Vector2 InternalCalculateOffset(ref Bounds viewBounds, ref Bounds contentBounds, bool horizontal, bool vertical, MovementType movementType, ref Vector2 delta)
		{
			return default(Vector2);
		}

		[Token(Token = "0x6000389")]
		[Address(RVA = "0xECF838", Offset = "0xECF838", Length = "0x94")]
		protected void SetDirty()
		{
		}

		[Token(Token = "0x600038A")]
		[Address(RVA = "0xECF448", Offset = "0xECF448", Length = "0xC0")]
		protected void SetDirtyCaching()
		{
		}
	}
}
