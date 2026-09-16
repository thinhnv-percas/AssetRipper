using System;
using Cpp2ILInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace UnityEngine.UI
{
	[DisallowMultipleComponent]
	[AddComponentMenu("UI/Scroll Rect", 37)]
	[SelectionBase]
	[ExecuteAlways]
	[RequireComponent(typeof(RectTransform))]
	[Token(Token = "0x2000065")]
	public class ScrollRect : UIBehaviour, IInitializePotentialDragHandler, IEventSystemHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IScrollHandler, ICanvasElement, ILayoutElement, ILayoutGroup, ILayoutController
	{
		[Token(Token = "0x2000066")]
		public enum MovementType
		{
			[Token(Token = "0x40001FF")]
			Unrestricted = 0,
			[Token(Token = "0x4000200")]
			Elastic = 1,
			[Token(Token = "0x4000201")]
			Clamped = 2
		}

		[Token(Token = "0x2000067")]
		public enum ScrollbarVisibility
		{
			[Token(Token = "0x4000203")]
			Permanent = 0,
			[Token(Token = "0x4000204")]
			AutoHide = 1,
			[Token(Token = "0x4000205")]
			AutoHideAndExpandViewport = 2
		}

		[Serializable]
		[Token(Token = "0x2000068")]
		public class ScrollRectEvent : UnityEvent<Vector2>
		{
			[Token(Token = "0x600041F")]
			[Address(RVA = "0x1831388", Offset = "0x1831388", Length = "0x48")]
			public ScrollRectEvent()
			{
			}
		}

		[SerializeField]
		[Token(Token = "0x40001D9")]
		[FieldOffset(Offset = "0x20")]
		private RectTransform m_Content;

		[SerializeField]
		[Token(Token = "0x40001DA")]
		[FieldOffset(Offset = "0x28")]
		private bool m_Horizontal;

		[SerializeField]
		[Token(Token = "0x40001DB")]
		[FieldOffset(Offset = "0x29")]
		private bool m_Vertical;

		[SerializeField]
		[Token(Token = "0x40001DC")]
		[FieldOffset(Offset = "0x2C")]
		private MovementType m_MovementType;

		[SerializeField]
		[Token(Token = "0x40001DD")]
		[FieldOffset(Offset = "0x30")]
		private float m_Elasticity;

		[SerializeField]
		[Token(Token = "0x40001DE")]
		[FieldOffset(Offset = "0x34")]
		private bool m_Inertia;

		[SerializeField]
		[Token(Token = "0x40001DF")]
		[FieldOffset(Offset = "0x38")]
		private float m_DecelerationRate;

		[SerializeField]
		[Token(Token = "0x40001E0")]
		[FieldOffset(Offset = "0x3C")]
		private float m_ScrollSensitivity;

		[SerializeField]
		[Token(Token = "0x40001E1")]
		[FieldOffset(Offset = "0x40")]
		private RectTransform m_Viewport;

		[SerializeField]
		[Token(Token = "0x40001E2")]
		[FieldOffset(Offset = "0x48")]
		private Scrollbar m_HorizontalScrollbar;

		[SerializeField]
		[Token(Token = "0x40001E3")]
		[FieldOffset(Offset = "0x50")]
		private Scrollbar m_VerticalScrollbar;

		[SerializeField]
		[Token(Token = "0x40001E4")]
		[FieldOffset(Offset = "0x58")]
		private ScrollbarVisibility m_HorizontalScrollbarVisibility;

		[SerializeField]
		[Token(Token = "0x40001E5")]
		[FieldOffset(Offset = "0x5C")]
		private ScrollbarVisibility m_VerticalScrollbarVisibility;

		[SerializeField]
		[Token(Token = "0x40001E6")]
		[FieldOffset(Offset = "0x60")]
		private float m_HorizontalScrollbarSpacing;

		[SerializeField]
		[Token(Token = "0x40001E7")]
		[FieldOffset(Offset = "0x64")]
		private float m_VerticalScrollbarSpacing;

		[SerializeField]
		[Token(Token = "0x40001E8")]
		[FieldOffset(Offset = "0x68")]
		private ScrollRectEvent m_OnValueChanged;

		[Token(Token = "0x40001E9")]
		[FieldOffset(Offset = "0x70")]
		private Vector2 m_PointerStartLocalCursor;

		[Token(Token = "0x40001EA")]
		[FieldOffset(Offset = "0x78")]
		protected Vector2 m_ContentStartPosition;

		[Token(Token = "0x40001EB")]
		[FieldOffset(Offset = "0x80")]
		private RectTransform m_ViewRect;

		[Token(Token = "0x40001EC")]
		[FieldOffset(Offset = "0x88")]
		protected Bounds m_ContentBounds;

		[Token(Token = "0x40001ED")]
		[FieldOffset(Offset = "0xA0")]
		private Bounds m_ViewBounds;

		[Token(Token = "0x40001EE")]
		[FieldOffset(Offset = "0xB8")]
		private Vector2 m_Velocity;

		[Token(Token = "0x40001EF")]
		[FieldOffset(Offset = "0xC0")]
		private bool m_Dragging;

		[Token(Token = "0x40001F0")]
		[FieldOffset(Offset = "0xC1")]
		private bool m_Scrolling;

		[Token(Token = "0x40001F1")]
		[FieldOffset(Offset = "0xC4")]
		private Vector2 m_PrevPosition;

		[Token(Token = "0x40001F2")]
		[FieldOffset(Offset = "0xCC")]
		private Bounds m_PrevContentBounds;

		[Token(Token = "0x40001F3")]
		[FieldOffset(Offset = "0xE4")]
		private Bounds m_PrevViewBounds;

		[NonSerialized]
		[Token(Token = "0x40001F4")]
		[FieldOffset(Offset = "0xFC")]
		private bool m_HasRebuiltLayout;

		[Token(Token = "0x40001F5")]
		[FieldOffset(Offset = "0xFD")]
		private bool m_HSliderExpand;

		[Token(Token = "0x40001F6")]
		[FieldOffset(Offset = "0xFE")]
		private bool m_VSliderExpand;

		[Token(Token = "0x40001F7")]
		[FieldOffset(Offset = "0x100")]
		private float m_HSliderHeight;

		[Token(Token = "0x40001F8")]
		[FieldOffset(Offset = "0x104")]
		private float m_VSliderWidth;

		[NonSerialized]
		[Token(Token = "0x40001F9")]
		[FieldOffset(Offset = "0x108")]
		private RectTransform m_Rect;

		[Token(Token = "0x40001FA")]
		[FieldOffset(Offset = "0x110")]
		private RectTransform m_HorizontalScrollbarRect;

		[Token(Token = "0x40001FB")]
		[FieldOffset(Offset = "0x118")]
		private RectTransform m_VerticalScrollbarRect;

		[Token(Token = "0x40001FC")]
		[FieldOffset(Offset = "0x120")]
		private DrivenRectTransformTracker m_Tracker;

		[Token(Token = "0x40001FD")]
		[FieldOffset(Offset = "0x128")]
		private readonly Vector3[] m_Corners;

		[Token(Token = "0x170000F7")]
		public RectTransform content
		{
			[Token(Token = "0x60003C4")]
			[Address(RVA = "0x1830BC4", Offset = "0x1830BC4", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60003C5")]
			[Address(RVA = "0x1830BCC", Offset = "0x1830BCC", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000F8")]
		public bool horizontal
		{
			[Token(Token = "0x60003C6")]
			[Address(RVA = "0x1830BD4", Offset = "0x1830BD4", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60003C7")]
			[Address(RVA = "0x1830BDC", Offset = "0x1830BDC", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x170000F9")]
		public bool vertical
		{
			[Token(Token = "0x60003C8")]
			[Address(RVA = "0x1830BE8", Offset = "0x1830BE8", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60003C9")]
			[Address(RVA = "0x1830BF0", Offset = "0x1830BF0", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x170000FA")]
		public MovementType movementType
		{
			[Token(Token = "0x60003CA")]
			[Address(RVA = "0x1830BFC", Offset = "0x1830BFC", Length = "0x8")]
			get
			{
				return MovementType.Unrestricted;
			}
			[Token(Token = "0x60003CB")]
			[Address(RVA = "0x1830C04", Offset = "0x1830C04", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000FB")]
		public float elasticity
		{
			[Token(Token = "0x60003CC")]
			[Address(RVA = "0x1830C0C", Offset = "0x1830C0C", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60003CD")]
			[Address(RVA = "0x1830C14", Offset = "0x1830C14", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000FC")]
		public bool inertia
		{
			[Token(Token = "0x60003CE")]
			[Address(RVA = "0x1830C1C", Offset = "0x1830C1C", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60003CF")]
			[Address(RVA = "0x1830C24", Offset = "0x1830C24", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x170000FD")]
		public float decelerationRate
		{
			[Token(Token = "0x60003D0")]
			[Address(RVA = "0x1830C30", Offset = "0x1830C30", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60003D1")]
			[Address(RVA = "0x1830C38", Offset = "0x1830C38", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000FE")]
		public float scrollSensitivity
		{
			[Token(Token = "0x60003D2")]
			[Address(RVA = "0x1830C40", Offset = "0x1830C40", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60003D3")]
			[Address(RVA = "0x1830C48", Offset = "0x1830C48", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000FF")]
		public RectTransform viewport
		{
			[Token(Token = "0x60003D4")]
			[Address(RVA = "0x1830C50", Offset = "0x1830C50", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60003D5")]
			[Address(RVA = "0x1830C58", Offset = "0x1830C58", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000100")]
		public Scrollbar horizontalScrollbar
		{
			[Token(Token = "0x60003D6")]
			[Address(RVA = "0x1830D14", Offset = "0x1830D14", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60003D7")]
			[Address(RVA = "0x1830D1C", Offset = "0x1830D1C", Length = "0x17C")]
			set
			{
			}
		}

		[Token(Token = "0x17000101")]
		public Scrollbar verticalScrollbar
		{
			[Token(Token = "0x60003D8")]
			[Address(RVA = "0x1830E98", Offset = "0x1830E98", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60003D9")]
			[Address(RVA = "0x1830EA0", Offset = "0x1830EA0", Length = "0x17C")]
			set
			{
			}
		}

		[Token(Token = "0x17000102")]
		public ScrollbarVisibility horizontalScrollbarVisibility
		{
			[Token(Token = "0x60003DA")]
			[Address(RVA = "0x183101C", Offset = "0x183101C", Length = "0x8")]
			get
			{
				return ScrollbarVisibility.Permanent;
			}
			[Token(Token = "0x60003DB")]
			[Address(RVA = "0x1831024", Offset = "0x1831024", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000103")]
		public ScrollbarVisibility verticalScrollbarVisibility
		{
			[Token(Token = "0x60003DC")]
			[Address(RVA = "0x183102C", Offset = "0x183102C", Length = "0x8")]
			get
			{
				return ScrollbarVisibility.Permanent;
			}
			[Token(Token = "0x60003DD")]
			[Address(RVA = "0x1831034", Offset = "0x1831034", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000104")]
		public float horizontalScrollbarSpacing
		{
			[Token(Token = "0x60003DE")]
			[Address(RVA = "0x183103C", Offset = "0x183103C", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60003DF")]
			[Address(RVA = "0x1831044", Offset = "0x1831044", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000105")]
		public float verticalScrollbarSpacing
		{
			[Token(Token = "0x60003E0")]
			[Address(RVA = "0x18310D4", Offset = "0x18310D4", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60003E1")]
			[Address(RVA = "0x18310DC", Offset = "0x18310DC", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000106")]
		public ScrollRectEvent onValueChanged
		{
			[Token(Token = "0x60003E2")]
			[Address(RVA = "0x18310E4", Offset = "0x18310E4", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60003E3")]
			[Address(RVA = "0x18310EC", Offset = "0x18310EC", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000107")]
		protected RectTransform viewRect
		{
			[Token(Token = "0x60003E4")]
			[Address(RVA = "0x18310F4", Offset = "0x18310F4", Length = "0xF0")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000108")]
		public Vector2 velocity
		{
			[Token(Token = "0x60003E5")]
			[Address(RVA = "0x18311E4", Offset = "0x18311E4", Length = "0x8")]
			get
			{
				return default(Vector2);
			}
			[Token(Token = "0x60003E6")]
			[Address(RVA = "0x18311EC", Offset = "0x18311EC", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000109")]
		private RectTransform rectTransform
		{
			[Token(Token = "0x60003E7")]
			[Address(RVA = "0x18311F4", Offset = "0x18311F4", Length = "0x94")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700010A")]
		public Vector2 normalizedPosition
		{
			[Token(Token = "0x60003FB")]
			[Address(RVA = "0x1832EA0", Offset = "0x1832EA0", Length = "0x30")]
			get
			{
				return default(Vector2);
			}
			[Token(Token = "0x60003FC")]
			[Address(RVA = "0x1833110", Offset = "0x1833110", Length = "0x48")]
			set
			{
			}
		}

		[Token(Token = "0x1700010B")]
		public float horizontalNormalizedPosition
		{
			[Token(Token = "0x60003FD")]
			[Address(RVA = "0x1832F10", Offset = "0x1832F10", Length = "0x100")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60003FE")]
			[Address(RVA = "0x1833158", Offset = "0x1833158", Length = "0x14")]
			set
			{
			}
		}

		[Token(Token = "0x1700010C")]
		public float verticalNormalizedPosition
		{
			[Token(Token = "0x60003FF")]
			[Address(RVA = "0x1833010", Offset = "0x1833010", Length = "0x100")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000400")]
			[Address(RVA = "0x183316C", Offset = "0x183316C", Length = "0x14")]
			set
			{
			}
		}

		[Token(Token = "0x1700010D")]
		private bool hScrollingNeeded
		{
			[Token(Token = "0x6000406")]
			[Address(RVA = "0x1833444", Offset = "0x1833444", Length = "0x88")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x1700010E")]
		private bool vScrollingNeeded
		{
			[Token(Token = "0x6000407")]
			[Address(RVA = "0x18334CC", Offset = "0x18334CC", Length = "0x88")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x1700010F")]
		public virtual float minWidth
		{
			[Token(Token = "0x600040A")]
			[Address(RVA = "0x183355C", Offset = "0x183355C", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000110")]
		public virtual float preferredWidth
		{
			[Token(Token = "0x600040B")]
			[Address(RVA = "0x1833564", Offset = "0x1833564", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000111")]
		public virtual float flexibleWidth
		{
			[Token(Token = "0x600040C")]
			[Address(RVA = "0x183356C", Offset = "0x183356C", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000112")]
		public virtual float minHeight
		{
			[Token(Token = "0x600040D")]
			[Address(RVA = "0x1833574", Offset = "0x1833574", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000113")]
		public virtual float preferredHeight
		{
			[Token(Token = "0x600040E")]
			[Address(RVA = "0x183357C", Offset = "0x183357C", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000114")]
		public virtual float flexibleHeight
		{
			[Token(Token = "0x600040F")]
			[Address(RVA = "0x1833584", Offset = "0x1833584", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000115")]
		public virtual int layoutPriority
		{
			[Token(Token = "0x6000410")]
			[Address(RVA = "0x183358C", Offset = "0x183358C", Length = "0x8")]
			get
			{
				return 0;
			}
		}

		Transform ICanvasElement.transform
		{
			[Token(Token = "0x600041E")]
			[Address(RVA = "0x18342CC", Offset = "0x18342CC", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x60003E8")]
		[Address(RVA = "0x1831288", Offset = "0x1831288", Length = "0x100")]
		protected ScrollRect()
		{
		}

		[Token(Token = "0x60003E9")]
		[Address(RVA = "0x18313D0", Offset = "0x18313D0", Length = "0x88")]
		public virtual void Rebuild(CanvasUpdate executing)
		{
		}

		[Token(Token = "0x60003EA")]
		[Address(RVA = "0x1831D60", Offset = "0x1831D60", Length = "0x4")]
		public virtual void LayoutComplete()
		{
		}

		[Token(Token = "0x60003EB")]
		[Address(RVA = "0x1831D64", Offset = "0x1831D64", Length = "0x4")]
		public virtual void GraphicUpdateComplete()
		{
		}

		[Token(Token = "0x60003EC")]
		[Address(RVA = "0x1831458", Offset = "0x1831458", Length = "0x358")]
		private void UpdateCachedData()
		{
		}

		[Token(Token = "0x60003ED")]
		[Address(RVA = "0x1831D68", Offset = "0x1831D68", Length = "0x1BC")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x60003EE")]
		[Address(RVA = "0x1831F24", Offset = "0x1831F24", Length = "0x230")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x60003EF")]
		[Address(RVA = "0x1832154", Offset = "0x1832154", Length = "0x80")]
		public override bool IsActive()
		{
			return false;
		}

		[Token(Token = "0x60003F0")]
		[Address(RVA = "0x18321D4", Offset = "0x18321D4", Length = "0x74")]
		private void EnsureLayoutHasRebuilt()
		{
		}

		[Token(Token = "0x60003F1")]
		[Address(RVA = "0x1832248", Offset = "0x1832248", Length = "0x50")]
		public virtual void StopMovement()
		{
		}

		[Token(Token = "0x60003F2")]
		[Address(RVA = "0x1832298", Offset = "0x1832298", Length = "0x16C")]
		public virtual void OnScroll(PointerEventData data)
		{
		}

		[Token(Token = "0x60003F3")]
		[Address(RVA = "0x1832434", Offset = "0x1832434", Length = "0x60")]
		public virtual void OnInitializePotentialDrag(PointerEventData eventData)
		{
		}

		[Token(Token = "0x60003F4")]
		[Address(RVA = "0x1832494", Offset = "0x1832494", Length = "0x12C")]
		public virtual void OnBeginDrag(PointerEventData eventData)
		{
		}

		[Token(Token = "0x60003F5")]
		[Address(RVA = "0x18325C0", Offset = "0x18325C0", Length = "0x20")]
		public virtual void OnEndDrag(PointerEventData eventData)
		{
		}

		[Token(Token = "0x60003F6")]
		[Address(RVA = "0x18325E0", Offset = "0x18325E0", Length = "0x1FC")]
		public virtual void OnDrag(PointerEventData eventData)
		{
		}

		[Token(Token = "0x60003F7")]
		[Address(RVA = "0x1832814", Offset = "0x1832814", Length = "0xB4")]
		protected virtual void SetContentAnchoredPosition(Vector2 position)
		{
		}

		[Token(Token = "0x60003F8")]
		[Address(RVA = "0x18328C8", Offset = "0x18328C8", Length = "0x5D8")]
		protected virtual void LateUpdate()
		{
		}

		[Token(Token = "0x60003F9")]
		[Address(RVA = "0x1831C88", Offset = "0x1831C88", Length = "0xD8")]
		protected void UpdatePrevData()
		{
		}

		[Token(Token = "0x60003FA")]
		[Address(RVA = "0x1831B08", Offset = "0x1831B08", Length = "0x180")]
		private void UpdateScrollbars(Vector2 offset)
		{
		}

		[Token(Token = "0x6000401")]
		[Address(RVA = "0x1833180", Offset = "0x1833180", Length = "0x14")]
		private void SetHorizontalNormalizedPosition(float value)
		{
		}

		[Token(Token = "0x6000402")]
		[Address(RVA = "0x1833194", Offset = "0x1833194", Length = "0x14")]
		private void SetVerticalNormalizedPosition(float value)
		{
		}

		[Token(Token = "0x6000403")]
		[Address(RVA = "0x18331A8", Offset = "0x18331A8", Length = "0x298")]
		protected virtual void SetNormalizedPosition(float value, int axis)
		{
		}

		[Token(Token = "0x6000404")]
		[Address(RVA = "0x18327DC", Offset = "0x18327DC", Length = "0x38")]
		private static float RubberDelta(float overStretching, float viewSize)
		{
			return 0f;
		}

		[Token(Token = "0x6000405")]
		[Address(RVA = "0x1833440", Offset = "0x1833440", Length = "0x4")]
		protected override void OnRectTransformDimensionsChange()
		{
		}

		[Token(Token = "0x6000408")]
		[Address(RVA = "0x1833554", Offset = "0x1833554", Length = "0x4")]
		public virtual void CalculateLayoutInputHorizontal()
		{
		}

		[Token(Token = "0x6000409")]
		[Address(RVA = "0x1833558", Offset = "0x1833558", Length = "0x4")]
		public virtual void CalculateLayoutInputVertical()
		{
		}

		[Token(Token = "0x6000411")]
		[Address(RVA = "0x1833594", Offset = "0x1833594", Length = "0x4E4")]
		public virtual void SetLayoutHorizontal()
		{
		}

		[Token(Token = "0x6000412")]
		[Address(RVA = "0x1833B6C", Offset = "0x1833B6C", Length = "0xB8")]
		public virtual void SetLayoutVertical()
		{
		}

		[Token(Token = "0x6000413")]
		[Address(RVA = "0x1832ED0", Offset = "0x1832ED0", Length = "0x40")]
		private void UpdateScrollbarVisibility()
		{
		}

		[Token(Token = "0x6000414")]
		[Address(RVA = "0x1833E78", Offset = "0x1833E78", Length = "0x104")]
		private static void UpdateOneScrollbarVisibility(bool xScrollingNeeded, bool xAxisEnabled, ScrollbarVisibility scrollbarVisibility, Scrollbar scrollbar)
		{
		}

		[Token(Token = "0x6000415")]
		[Address(RVA = "0x1833C24", Offset = "0x1833C24", Length = "0x254")]
		private void UpdateScrollbarLayout()
		{
		}

		[Token(Token = "0x6000416")]
		[Address(RVA = "0x18317B0", Offset = "0x18317B0", Length = "0x358")]
		protected void UpdateBounds()
		{
		}

		[Token(Token = "0x6000417")]
		[Address(RVA = "0x1833F7C", Offset = "0x1833F7C", Length = "0x7C")]
		internal static void AdjustBounds(ref Bounds viewBounds, ref Vector2 contentPivot, ref Vector3 contentSize, ref Vector3 contentPos)
		{
		}

		[Token(Token = "0x6000418")]
		[Address(RVA = "0x1833A78", Offset = "0x1833A78", Length = "0xF4")]
		private Bounds GetBounds()
		{
			return default(Bounds);
		}

		[Token(Token = "0x6000419")]
		[Address(RVA = "0x1833FF8", Offset = "0x1833FF8", Length = "0x190")]
		internal static Bounds InternalGetBounds(Vector3[] corners, ref Matrix4x4 viewWorldToLocalMatrix)
		{
			return default(Bounds);
		}

		[Token(Token = "0x600041A")]
		[Address(RVA = "0x1832404", Offset = "0x1832404", Length = "0x30")]
		private Vector2 CalculateOffset(Vector2 delta)
		{
			return default(Vector2);
		}

		[Token(Token = "0x600041B")]
		[Address(RVA = "0x1834188", Offset = "0x1834188", Length = "0x144")]
		internal static Vector2 InternalCalculateOffset(ref Bounds viewBounds, ref Bounds contentBounds, bool horizontal, bool vertical, MovementType movementType, ref Vector2 delta)
		{
			return default(Vector2);
		}

		[Token(Token = "0x600041C")]
		[Address(RVA = "0x183104C", Offset = "0x183104C", Length = "0x88")]
		protected void SetDirty()
		{
		}

		[Token(Token = "0x600041D")]
		[Address(RVA = "0x1830C60", Offset = "0x1830C60", Length = "0xB4")]
		protected void SetDirtyCaching()
		{
		}
	}
}
