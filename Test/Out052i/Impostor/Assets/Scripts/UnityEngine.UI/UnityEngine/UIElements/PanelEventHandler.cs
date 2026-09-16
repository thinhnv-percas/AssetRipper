using Cpp2ILInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UIElements
{
	[AddComponentMenu("UI Toolkit/Panel Event Handler (UI Toolkit)")]
	[Token(Token = "0x2000092")]
	public class PanelEventHandler : UIBehaviour, IPointerMoveHandler, IEventSystemHandler, IPointerUpHandler, IPointerDownHandler, ISubmitHandler, ICancelHandler, IMoveHandler, IScrollHandler, ISelectHandler, IDeselectHandler, IPointerExitHandler, IPointerEnterHandler, IRuntimePanelComponent, IPointerClickHandler
	{
		[Token(Token = "0x2000093")]
		private enum PointerEventType
		{
			[Token(Token = "0x4000293")]
			Default = 0,
			[Token(Token = "0x4000294")]
			Down = 1,
			[Token(Token = "0x4000295")]
			Up = 2
		}

		[Token(Token = "0x2000094")]
		private class PointerEvent : IPointerEvent
		{
			[Token(Token = "0x1700016E")]
			[field: Token(Token = "0x4000296")]
			[field: FieldOffset(Offset = "0x10")]
			public int pointerId
			{
				[Token(Token = "0x60005AD")]
				[Address(RVA = "0x1841B08", Offset = "0x1841B08", Length = "0x8")]
				get;
				[Token(Token = "0x60005AE")]
				[Address(RVA = "0x1841B10", Offset = "0x1841B10", Length = "0x8")]
				private set;
			}

			[Token(Token = "0x1700016F")]
			[field: Token(Token = "0x4000297")]
			[field: FieldOffset(Offset = "0x18")]
			public string pointerType
			{
				[Token(Token = "0x60005AF")]
				[Address(RVA = "0x1841B18", Offset = "0x1841B18", Length = "0x8")]
				get;
				[Token(Token = "0x60005B0")]
				[Address(RVA = "0x1841B20", Offset = "0x1841B20", Length = "0x8")]
				private set;
			}

			[Token(Token = "0x17000170")]
			[field: Token(Token = "0x4000298")]
			[field: FieldOffset(Offset = "0x20")]
			public bool isPrimary
			{
				[Token(Token = "0x60005B1")]
				[Address(RVA = "0x1841B28", Offset = "0x1841B28", Length = "0x8")]
				get;
				[Token(Token = "0x60005B2")]
				[Address(RVA = "0x1841B30", Offset = "0x1841B30", Length = "0xC")]
				private set;
			}

			[Token(Token = "0x17000171")]
			[field: Token(Token = "0x4000299")]
			[field: FieldOffset(Offset = "0x24")]
			public int button
			{
				[Token(Token = "0x60005B3")]
				[Address(RVA = "0x1841B3C", Offset = "0x1841B3C", Length = "0x8")]
				get;
				[Token(Token = "0x60005B4")]
				[Address(RVA = "0x1841B44", Offset = "0x1841B44", Length = "0x8")]
				private set;
			}

			[Token(Token = "0x17000172")]
			[field: Token(Token = "0x400029A")]
			[field: FieldOffset(Offset = "0x28")]
			public int pressedButtons
			{
				[Token(Token = "0x60005B5")]
				[Address(RVA = "0x1841B4C", Offset = "0x1841B4C", Length = "0x8")]
				get;
				[Token(Token = "0x60005B6")]
				[Address(RVA = "0x1841B54", Offset = "0x1841B54", Length = "0x8")]
				private set;
			}

			[Token(Token = "0x17000173")]
			[field: Token(Token = "0x400029B")]
			[field: FieldOffset(Offset = "0x2C")]
			public Vector3 position
			{
				[Token(Token = "0x60005B7")]
				[Address(RVA = "0x1841B5C", Offset = "0x1841B5C", Length = "0xC")]
				get;
				[Token(Token = "0x60005B8")]
				[Address(RVA = "0x1841B68", Offset = "0x1841B68", Length = "0xC")]
				private set;
			}

			[Token(Token = "0x17000174")]
			[field: Token(Token = "0x400029C")]
			[field: FieldOffset(Offset = "0x38")]
			public Vector3 localPosition
			{
				[Token(Token = "0x60005B9")]
				[Address(RVA = "0x1841B74", Offset = "0x1841B74", Length = "0xC")]
				get;
				[Token(Token = "0x60005BA")]
				[Address(RVA = "0x1841B80", Offset = "0x1841B80", Length = "0xC")]
				private set;
			}

			[Token(Token = "0x17000175")]
			[field: Token(Token = "0x400029D")]
			[field: FieldOffset(Offset = "0x44")]
			public Vector3 deltaPosition
			{
				[Token(Token = "0x60005BB")]
				[Address(RVA = "0x1841B8C", Offset = "0x1841B8C", Length = "0xC")]
				get;
				[Token(Token = "0x60005BC")]
				[Address(RVA = "0x1841B98", Offset = "0x1841B98", Length = "0xC")]
				private set;
			}

			[Token(Token = "0x17000176")]
			[field: Token(Token = "0x400029E")]
			[field: FieldOffset(Offset = "0x50")]
			public float deltaTime
			{
				[Token(Token = "0x60005BD")]
				[Address(RVA = "0x1841BA4", Offset = "0x1841BA4", Length = "0x8")]
				get;
				[Token(Token = "0x60005BE")]
				[Address(RVA = "0x1841BAC", Offset = "0x1841BAC", Length = "0x8")]
				private set;
			}

			[Token(Token = "0x17000177")]
			[field: Token(Token = "0x400029F")]
			[field: FieldOffset(Offset = "0x54")]
			public int clickCount
			{
				[Token(Token = "0x60005BF")]
				[Address(RVA = "0x1841BB4", Offset = "0x1841BB4", Length = "0x8")]
				get;
				[Token(Token = "0x60005C0")]
				[Address(RVA = "0x1841BBC", Offset = "0x1841BBC", Length = "0x8")]
				private set;
			}

			[Token(Token = "0x17000178")]
			[field: Token(Token = "0x40002A0")]
			[field: FieldOffset(Offset = "0x58")]
			public float pressure
			{
				[Token(Token = "0x60005C1")]
				[Address(RVA = "0x1841BC4", Offset = "0x1841BC4", Length = "0x8")]
				get;
				[Token(Token = "0x60005C2")]
				[Address(RVA = "0x1841BCC", Offset = "0x1841BCC", Length = "0x8")]
				private set;
			}

			[Token(Token = "0x17000179")]
			[field: Token(Token = "0x40002A1")]
			[field: FieldOffset(Offset = "0x5C")]
			public float tangentialPressure
			{
				[Token(Token = "0x60005C3")]
				[Address(RVA = "0x1841BD4", Offset = "0x1841BD4", Length = "0x8")]
				get;
				[Token(Token = "0x60005C4")]
				[Address(RVA = "0x1841BDC", Offset = "0x1841BDC", Length = "0x8")]
				private set;
			}

			[Token(Token = "0x1700017A")]
			[field: Token(Token = "0x40002A2")]
			[field: FieldOffset(Offset = "0x60")]
			public float altitudeAngle
			{
				[Token(Token = "0x60005C5")]
				[Address(RVA = "0x1841BE4", Offset = "0x1841BE4", Length = "0x8")]
				get;
				[Token(Token = "0x60005C6")]
				[Address(RVA = "0x1841BEC", Offset = "0x1841BEC", Length = "0x8")]
				private set;
			}

			[Token(Token = "0x1700017B")]
			[field: Token(Token = "0x40002A3")]
			[field: FieldOffset(Offset = "0x64")]
			public float azimuthAngle
			{
				[Token(Token = "0x60005C7")]
				[Address(RVA = "0x1841BF4", Offset = "0x1841BF4", Length = "0x8")]
				get;
				[Token(Token = "0x60005C8")]
				[Address(RVA = "0x1841BFC", Offset = "0x1841BFC", Length = "0x8")]
				private set;
			}

			[Token(Token = "0x1700017C")]
			[field: Token(Token = "0x40002A4")]
			[field: FieldOffset(Offset = "0x68")]
			public float twist
			{
				[Token(Token = "0x60005C9")]
				[Address(RVA = "0x1841C04", Offset = "0x1841C04", Length = "0x8")]
				get;
				[Token(Token = "0x60005CA")]
				[Address(RVA = "0x1841C0C", Offset = "0x1841C0C", Length = "0x8")]
				private set;
			}

			[Token(Token = "0x1700017D")]
			[field: Token(Token = "0x40002A5")]
			[field: FieldOffset(Offset = "0x6C")]
			public Vector2 tilt
			{
				[Token(Token = "0x60005CB")]
				[Address(RVA = "0x1841C14", Offset = "0x1841C14", Length = "0x8")]
				get;
				[Token(Token = "0x60005CC")]
				[Address(RVA = "0x1841C1C", Offset = "0x1841C1C", Length = "0x8")]
				private set;
			}

			[Token(Token = "0x1700017E")]
			[field: Token(Token = "0x40002A6")]
			[field: FieldOffset(Offset = "0x74")]
			public PenStatus penStatus
			{
				[Token(Token = "0x60005CD")]
				[Address(RVA = "0x1841C24", Offset = "0x1841C24", Length = "0x8")]
				get;
				[Token(Token = "0x60005CE")]
				[Address(RVA = "0x1841C2C", Offset = "0x1841C2C", Length = "0x8")]
				private set;
			}

			[Token(Token = "0x1700017F")]
			[field: Token(Token = "0x40002A7")]
			[field: FieldOffset(Offset = "0x78")]
			public Vector2 radius
			{
				[Token(Token = "0x60005CF")]
				[Address(RVA = "0x1841C34", Offset = "0x1841C34", Length = "0x8")]
				get;
				[Token(Token = "0x60005D0")]
				[Address(RVA = "0x1841C3C", Offset = "0x1841C3C", Length = "0x8")]
				private set;
			}

			[Token(Token = "0x17000180")]
			[field: Token(Token = "0x40002A8")]
			[field: FieldOffset(Offset = "0x80")]
			public Vector2 radiusVariance
			{
				[Token(Token = "0x60005D1")]
				[Address(RVA = "0x1841C44", Offset = "0x1841C44", Length = "0x8")]
				get;
				[Token(Token = "0x60005D2")]
				[Address(RVA = "0x1841C4C", Offset = "0x1841C4C", Length = "0x8")]
				private set;
			}

			[Token(Token = "0x17000181")]
			[field: Token(Token = "0x40002A9")]
			[field: FieldOffset(Offset = "0x88")]
			public EventModifiers modifiers
			{
				[Token(Token = "0x60005D3")]
				[Address(RVA = "0x1841C54", Offset = "0x1841C54", Length = "0x8")]
				get;
				[Token(Token = "0x60005D4")]
				[Address(RVA = "0x1841C5C", Offset = "0x1841C5C", Length = "0x8")]
				private set;
			}

			[Token(Token = "0x17000182")]
			public bool shiftKey
			{
				[Token(Token = "0x60005D5")]
				[Address(RVA = "0x1841C64", Offset = "0x1841C64", Length = "0xC")]
				get
				{
					return false;
				}
			}

			[Token(Token = "0x17000183")]
			public bool ctrlKey
			{
				[Token(Token = "0x60005D6")]
				[Address(RVA = "0x1841C70", Offset = "0x1841C70", Length = "0xC")]
				get
				{
					return false;
				}
			}

			[Token(Token = "0x17000184")]
			public bool commandKey
			{
				[Token(Token = "0x60005D7")]
				[Address(RVA = "0x1841C7C", Offset = "0x1841C7C", Length = "0xC")]
				get
				{
					return false;
				}
			}

			[Token(Token = "0x17000185")]
			public bool altKey
			{
				[Token(Token = "0x60005D8")]
				[Address(RVA = "0x1841C88", Offset = "0x1841C88", Length = "0xC")]
				get
				{
					return false;
				}
			}

			[Token(Token = "0x17000186")]
			public bool actionKey
			{
				[Token(Token = "0x60005D9")]
				[Address(RVA = "0x1841C94", Offset = "0x1841C94", Length = "0x94")]
				get
				{
					return false;
				}
			}

			[Token(Token = "0x60005DA")]
			[Address(RVA = "0x1841588", Offset = "0x1841588", Length = "0x4C4")]
			public void Read(PanelEventHandler self, PointerEventData eventData, PointerEventType eventType)
			{
			}

			[Token(Token = "0x60005DB")]
			[Address(RVA = "0x1841A4C", Offset = "0x1841A4C", Length = "0x18")]
			public void SetPosition(Vector3 positionOverride, Vector3 deltaOverride)
			{
			}

			[Token(Token = "0x60005DC")]
			[Address(RVA = "0x1841AF8", Offset = "0x1841AF8", Length = "0x8")]
			public PointerEvent()
			{
			}
		}

		[Token(Token = "0x400028C")]
		[FieldOffset(Offset = "0x20")]
		private BaseRuntimePanel m_Panel;

		[Token(Token = "0x400028D")]
		[FieldOffset(Offset = "0x28")]
		private readonly PointerEvent m_PointerEvent;

		[Token(Token = "0x400028E")]
		[FieldOffset(Offset = "0x30")]
		private float m_LastClickTime;

		[Token(Token = "0x400028F")]
		[FieldOffset(Offset = "0x34")]
		private bool m_Selecting;

		[Token(Token = "0x4000290")]
		[FieldOffset(Offset = "0x38")]
		private Event m_Event;

		[Token(Token = "0x4000291")]
		private static EventModifiers s_Modifiers;

		[Token(Token = "0x17000169")]
		public IPanel panel
		{
			[Token(Token = "0x6000588")]
			[Address(RVA = "0x183F158", Offset = "0x183F158", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000589")]
			[Address(RVA = "0x183F160", Offset = "0x183F160", Length = "0xA4")]
			set
			{
			}
		}

		[Token(Token = "0x1700016A")]
		private GameObject selectableGameObject
		{
			[Token(Token = "0x600058A")]
			[Address(RVA = "0x183F56C", Offset = "0x183F56C", Length = "0x18")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700016B")]
		private EventSystem eventSystem
		{
			[Token(Token = "0x600058B")]
			[Address(RVA = "0x183F584", Offset = "0x183F584", Length = "0xD4")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700016C")]
		private bool isCurrentFocusedPanel
		{
			[Token(Token = "0x600058C")]
			[Address(RVA = "0x183F658", Offset = "0x183F658", Length = "0xC8")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x1700016D")]
		private Focusable currentFocusedElement
		{
			[Token(Token = "0x600058D")]
			[Address(RVA = "0x183F720", Offset = "0x183F720", Length = "0x38")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x600058E")]
		[Address(RVA = "0x183F758", Offset = "0x183F758", Length = "0x4")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x600058F")]
		[Address(RVA = "0x183F760", Offset = "0x183F760", Length = "0x4")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x6000590")]
		[Address(RVA = "0x183F3B8", Offset = "0x183F3B8", Length = "0x1B4")]
		private void RegisterCallbacks()
		{
		}

		[Token(Token = "0x6000591")]
		[Address(RVA = "0x183F204", Offset = "0x183F204", Length = "0x1B4")]
		private void UnregisterCallbacks()
		{
		}

		[Token(Token = "0x6000592")]
		[Address(RVA = "0x183F768", Offset = "0x183F768", Length = "0x8")]
		private void OnPanelDestroyed()
		{
		}

		[Token(Token = "0x6000593")]
		[Address(RVA = "0x183F770", Offset = "0x183F770", Length = "0xBC")]
		private void OnElementFocus(FocusEvent e)
		{
		}

		[Token(Token = "0x6000594")]
		[Address(RVA = "0x183F858", Offset = "0x183F858", Length = "0x4")]
		private void OnElementBlur(BlurEvent e)
		{
		}

		[Token(Token = "0x6000595")]
		[Address(RVA = "0x183F85C", Offset = "0x183F85C", Length = "0x78")]
		public void OnSelect(BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000596")]
		[Address(RVA = "0x183F8D4", Offset = "0x183F8D4", Length = "0x14")]
		public void OnDeselect(BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000597")]
		[Address(RVA = "0x183F8E8", Offset = "0x183F8E8", Length = "0x1AC")]
		public void OnPointerMove(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000598")]
		[Address(RVA = "0x183FC38", Offset = "0x183FC38", Length = "0x21C")]
		public void OnPointerUp(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000599")]
		[Address(RVA = "0x183FE54", Offset = "0x183FE54", Length = "0x28C")]
		public void OnPointerDown(PointerEventData eventData)
		{
		}

		[Token(Token = "0x600059A")]
		[Address(RVA = "0x18400E0", Offset = "0x18400E0", Length = "0x328")]
		public void OnPointerExit(PointerEventData eventData)
		{
		}

		[Token(Token = "0x600059B")]
		[Address(RVA = "0x1840408", Offset = "0x1840408", Length = "0x54")]
		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		[Token(Token = "0x600059C")]
		[Address(RVA = "0x184045C", Offset = "0x184045C", Length = "0x1C")]
		public void OnPointerClick(PointerEventData eventData)
		{
		}

		[Token(Token = "0x600059D")]
		[Address(RVA = "0x1840478", Offset = "0x1840478", Length = "0x210")]
		public void OnSubmit(BaseEventData eventData)
		{
		}

		[Token(Token = "0x600059E")]
		[Address(RVA = "0x18407D0", Offset = "0x18407D0", Length = "0x210")]
		public void OnCancel(BaseEventData eventData)
		{
		}

		[Token(Token = "0x600059F")]
		[Address(RVA = "0x18409E0", Offset = "0x18409E0", Length = "0x234")]
		public void OnMove(AxisEventData eventData)
		{
		}

		[Token(Token = "0x60005A0")]
		[Address(RVA = "0x1840C14", Offset = "0x1840C14", Length = "0x1F4")]
		public void OnScroll(PointerEventData eventData)
		{
		}

		[Token(Token = "0x60005A1")]
		[Address(RVA = "0x183FBD4", Offset = "0x183FBD4", Length = "0x64")]
		private void SendEvent(EventBase e, BaseEventData sourceEventData)
		{
		}

		[Token(Token = "0x60005A2")]
		[Address(RVA = "0x1840E08", Offset = "0x1840E08", Length = "0x20")]
		private void SendEvent(EventBase e, Event sourceEvent)
		{
		}

		[Token(Token = "0x60005A3")]
		[Address(RVA = "0x1840E28", Offset = "0x1840E28", Length = "0x5C")]
		internal void Update()
		{
		}

		[Token(Token = "0x60005A4")]
		[Address(RVA = "0x1840E84", Offset = "0x1840E84", Length = "0x8")]
		private void LateUpdate()
		{
		}

		[Token(Token = "0x60005A5")]
		[Address(RVA = "0x1840688", Offset = "0x1840688", Length = "0x148")]
		private void ProcessImguiEvents(Focusable target)
		{
		}

		[Token(Token = "0x60005A6")]
		[Address(RVA = "0x1840E8C", Offset = "0x1840E8C", Length = "0x80")]
		private void ProcessKeyboardEvent(Event e, Focusable target)
		{
		}

		[Token(Token = "0x60005A7")]
		[Address(RVA = "0x1840F0C", Offset = "0x1840F0C", Length = "0x68")]
		private void ProcessTabEvent(Event e, Focusable target)
		{
		}

		[Token(Token = "0x60005A8")]
		[Address(RVA = "0x1841394", Offset = "0x1841394", Length = "0x1F4")]
		private void SendTabEvent(Event e, NavigationMoveEvent.Direction direction, Focusable target)
		{
		}

		[Token(Token = "0x60005A9")]
		[Address(RVA = "0x1840F74", Offset = "0x1840F74", Length = "0x210")]
		private void SendKeyUpEvent(Event e, Focusable target)
		{
		}

		[Token(Token = "0x60005AA")]
		[Address(RVA = "0x1841184", Offset = "0x1841184", Length = "0x210")]
		private void SendKeyDownEvent(Event e, Focusable target)
		{
		}

		[Token(Token = "0x60005AB")]
		[Address(RVA = "0x183FA94", Offset = "0x183FA94", Length = "0x140")]
		private bool ReadPointerData(PointerEvent pe, PointerEventData eventData, PointerEventType eventType = PointerEventType.Default)
		{
			return false;
		}

		[Token(Token = "0x60005AC")]
		[Address(RVA = "0x1841A64", Offset = "0x1841A64", Length = "0x94")]
		public PanelEventHandler()
		{
		}
	}
}
