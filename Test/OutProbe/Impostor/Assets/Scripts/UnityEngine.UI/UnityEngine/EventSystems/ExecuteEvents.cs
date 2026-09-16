using System.Collections.Generic;
using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x20000B7")]
	public static class ExecuteEvents
	{
		[Token(Token = "0x20000B8")]
		public delegate void EventFunction<T1>(T1 handler, BaseEventData eventData);

		[Token(Token = "0x4000304")]
		private static readonly EventFunction<IPointerMoveHandler> s_PointerMoveHandler;

		[Token(Token = "0x4000305")]
		private static readonly EventFunction<IPointerEnterHandler> s_PointerEnterHandler;

		[Token(Token = "0x4000306")]
		private static readonly EventFunction<IPointerExitHandler> s_PointerExitHandler;

		[Token(Token = "0x4000307")]
		private static readonly EventFunction<IPointerDownHandler> s_PointerDownHandler;

		[Token(Token = "0x4000308")]
		private static readonly EventFunction<IPointerUpHandler> s_PointerUpHandler;

		[Token(Token = "0x4000309")]
		private static readonly EventFunction<IPointerClickHandler> s_PointerClickHandler;

		[Token(Token = "0x400030A")]
		private static readonly EventFunction<IInitializePotentialDragHandler> s_InitializePotentialDragHandler;

		[Token(Token = "0x400030B")]
		private static readonly EventFunction<IBeginDragHandler> s_BeginDragHandler;

		[Token(Token = "0x400030C")]
		private static readonly EventFunction<IDragHandler> s_DragHandler;

		[Token(Token = "0x400030D")]
		private static readonly EventFunction<IEndDragHandler> s_EndDragHandler;

		[Token(Token = "0x400030E")]
		private static readonly EventFunction<IDropHandler> s_DropHandler;

		[Token(Token = "0x400030F")]
		private static readonly EventFunction<IScrollHandler> s_ScrollHandler;

		[Token(Token = "0x4000310")]
		private static readonly EventFunction<IUpdateSelectedHandler> s_UpdateSelectedHandler;

		[Token(Token = "0x4000311")]
		private static readonly EventFunction<ISelectHandler> s_SelectHandler;

		[Token(Token = "0x4000312")]
		private static readonly EventFunction<IDeselectHandler> s_DeselectHandler;

		[Token(Token = "0x4000313")]
		private static readonly EventFunction<IMoveHandler> s_MoveHandler;

		[Token(Token = "0x4000314")]
		private static readonly EventFunction<ISubmitHandler> s_SubmitHandler;

		[Token(Token = "0x4000315")]
		private static readonly EventFunction<ICancelHandler> s_CancelHandler;

		[Token(Token = "0x4000316")]
		private static readonly List<Transform> s_InternalTransformList;

		[Token(Token = "0x170001C3")]
		public static EventFunction<IPointerMoveHandler> pointerMoveHandler
		{
			[Token(Token = "0x60006A4")]
			[Address(RVA = "0x1846A08", Offset = "0x1846A08", Length = "0x58")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170001C4")]
		public static EventFunction<IPointerEnterHandler> pointerEnterHandler
		{
			[Token(Token = "0x60006A5")]
			[Address(RVA = "0x1846A60", Offset = "0x1846A60", Length = "0x58")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170001C5")]
		public static EventFunction<IPointerExitHandler> pointerExitHandler
		{
			[Token(Token = "0x60006A6")]
			[Address(RVA = "0x1846AB8", Offset = "0x1846AB8", Length = "0x58")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170001C6")]
		public static EventFunction<IPointerDownHandler> pointerDownHandler
		{
			[Token(Token = "0x60006A7")]
			[Address(RVA = "0x1846B10", Offset = "0x1846B10", Length = "0x58")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170001C7")]
		public static EventFunction<IPointerUpHandler> pointerUpHandler
		{
			[Token(Token = "0x60006A8")]
			[Address(RVA = "0x1846B68", Offset = "0x1846B68", Length = "0x58")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170001C8")]
		public static EventFunction<IPointerClickHandler> pointerClickHandler
		{
			[Token(Token = "0x60006A9")]
			[Address(RVA = "0x1846BC0", Offset = "0x1846BC0", Length = "0x58")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170001C9")]
		public static EventFunction<IInitializePotentialDragHandler> initializePotentialDrag
		{
			[Token(Token = "0x60006AA")]
			[Address(RVA = "0x1846C18", Offset = "0x1846C18", Length = "0x58")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170001CA")]
		public static EventFunction<IBeginDragHandler> beginDragHandler
		{
			[Token(Token = "0x60006AB")]
			[Address(RVA = "0x1846C70", Offset = "0x1846C70", Length = "0x58")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170001CB")]
		public static EventFunction<IDragHandler> dragHandler
		{
			[Token(Token = "0x60006AC")]
			[Address(RVA = "0x1846CC8", Offset = "0x1846CC8", Length = "0x58")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170001CC")]
		public static EventFunction<IEndDragHandler> endDragHandler
		{
			[Token(Token = "0x60006AD")]
			[Address(RVA = "0x1846D20", Offset = "0x1846D20", Length = "0x58")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170001CD")]
		public static EventFunction<IDropHandler> dropHandler
		{
			[Token(Token = "0x60006AE")]
			[Address(RVA = "0x1846D78", Offset = "0x1846D78", Length = "0x58")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170001CE")]
		public static EventFunction<IScrollHandler> scrollHandler
		{
			[Token(Token = "0x60006AF")]
			[Address(RVA = "0x1846DD0", Offset = "0x1846DD0", Length = "0x58")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170001CF")]
		public static EventFunction<IUpdateSelectedHandler> updateSelectedHandler
		{
			[Token(Token = "0x60006B0")]
			[Address(RVA = "0x1846E28", Offset = "0x1846E28", Length = "0x58")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170001D0")]
		public static EventFunction<ISelectHandler> selectHandler
		{
			[Token(Token = "0x60006B1")]
			[Address(RVA = "0x1846E80", Offset = "0x1846E80", Length = "0x58")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170001D1")]
		public static EventFunction<IDeselectHandler> deselectHandler
		{
			[Token(Token = "0x60006B2")]
			[Address(RVA = "0x1846ED8", Offset = "0x1846ED8", Length = "0x58")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170001D2")]
		public static EventFunction<IMoveHandler> moveHandler
		{
			[Token(Token = "0x60006B3")]
			[Address(RVA = "0x1846F30", Offset = "0x1846F30", Length = "0x58")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170001D3")]
		public static EventFunction<ISubmitHandler> submitHandler
		{
			[Token(Token = "0x60006B4")]
			[Address(RVA = "0x1846F88", Offset = "0x1846F88", Length = "0x58")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170001D4")]
		public static EventFunction<ICancelHandler> cancelHandler
		{
			[Token(Token = "0x60006B5")]
			[Address(RVA = "0x1846FE0", Offset = "0x1846FE0", Length = "0x58")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x6000691")]
		[Address(RVA = "0xDC0A84", Offset = "0xDC0A84", Length = "0x18C")]
		public static T ValidateEventData<T>(BaseEventData data) where T : class
		{
			return null;
		}

		[Token(Token = "0x6000692")]
		[Address(RVA = "0x1845A70", Offset = "0x1845A70", Length = "0xF4")]
		private static void Execute(IPointerMoveHandler handler, BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000693")]
		[Address(RVA = "0x1845B64", Offset = "0x1845B64", Length = "0xF4")]
		private static void Execute(IPointerEnterHandler handler, BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000694")]
		[Address(RVA = "0x1845C58", Offset = "0x1845C58", Length = "0xF4")]
		private static void Execute(IPointerExitHandler handler, BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000695")]
		[Address(RVA = "0x1845D4C", Offset = "0x1845D4C", Length = "0xF4")]
		private static void Execute(IPointerDownHandler handler, BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000696")]
		[Address(RVA = "0x1845E40", Offset = "0x1845E40", Length = "0xF4")]
		private static void Execute(IPointerUpHandler handler, BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000697")]
		[Address(RVA = "0x1845F34", Offset = "0x1845F34", Length = "0xF4")]
		private static void Execute(IPointerClickHandler handler, BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000698")]
		[Address(RVA = "0x1846028", Offset = "0x1846028", Length = "0xF4")]
		private static void Execute(IInitializePotentialDragHandler handler, BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000699")]
		[Address(RVA = "0x184611C", Offset = "0x184611C", Length = "0xF4")]
		private static void Execute(IBeginDragHandler handler, BaseEventData eventData)
		{
		}

		[Token(Token = "0x600069A")]
		[Address(RVA = "0x1846210", Offset = "0x1846210", Length = "0xF4")]
		private static void Execute(IDragHandler handler, BaseEventData eventData)
		{
		}

		[Token(Token = "0x600069B")]
		[Address(RVA = "0x1846304", Offset = "0x1846304", Length = "0xF4")]
		private static void Execute(IEndDragHandler handler, BaseEventData eventData)
		{
		}

		[Token(Token = "0x600069C")]
		[Address(RVA = "0x18463F8", Offset = "0x18463F8", Length = "0xF4")]
		private static void Execute(IDropHandler handler, BaseEventData eventData)
		{
		}

		[Token(Token = "0x600069D")]
		[Address(RVA = "0x18464EC", Offset = "0x18464EC", Length = "0xF4")]
		private static void Execute(IScrollHandler handler, BaseEventData eventData)
		{
		}

		[Token(Token = "0x600069E")]
		[Address(RVA = "0x18465E0", Offset = "0x18465E0", Length = "0xA4")]
		private static void Execute(IUpdateSelectedHandler handler, BaseEventData eventData)
		{
		}

		[Token(Token = "0x600069F")]
		[Address(RVA = "0x1846684", Offset = "0x1846684", Length = "0xA4")]
		private static void Execute(ISelectHandler handler, BaseEventData eventData)
		{
		}

		[Token(Token = "0x60006A0")]
		[Address(RVA = "0x1846728", Offset = "0x1846728", Length = "0xA4")]
		private static void Execute(IDeselectHandler handler, BaseEventData eventData)
		{
		}

		[Token(Token = "0x60006A1")]
		[Address(RVA = "0x18467CC", Offset = "0x18467CC", Length = "0xF4")]
		private static void Execute(IMoveHandler handler, BaseEventData eventData)
		{
		}

		[Token(Token = "0x60006A2")]
		[Address(RVA = "0x18468C0", Offset = "0x18468C0", Length = "0xA4")]
		private static void Execute(ISubmitHandler handler, BaseEventData eventData)
		{
		}

		[Token(Token = "0x60006A3")]
		[Address(RVA = "0x1846964", Offset = "0x1846964", Length = "0xA4")]
		private static void Execute(ICancelHandler handler, BaseEventData eventData)
		{
		}

		[Token(Token = "0x60006B6")]
		[Address(RVA = "0x1847038", Offset = "0x1847038", Length = "0x194")]
		private static void GetEventChain(GameObject root, IList<Transform> eventChain)
		{
		}

		[Token(Token = "0x60006B7")]
		[Address(RVA = "0xDBF568", Offset = "0xDBF568", Length = "0x3C4")]
		public static bool Execute<T>(GameObject target, BaseEventData eventData, EventFunction<T> functor) where T : IEventSystemHandler
		{
			return false;
		}

		[Token(Token = "0x60006B8")]
		[Address(RVA = "0xDBFD88", Offset = "0xDBFD88", Length = "0x15C")]
		public static GameObject ExecuteHierarchy<T>(GameObject root, BaseEventData eventData, EventFunction<T> callbackFunction) where T : IEventSystemHandler
		{
			return null;
		}

		[Token(Token = "0x60006B9")]
		[Address(RVA = "0xDC0884", Offset = "0xDC0884", Length = "0x100")]
		private static bool ShouldSendToComponent<T>(Component component) where T : IEventSystemHandler
		{
			return false;
		}

		[Token(Token = "0x60006BA")]
		[Address(RVA = "0xDC02A8", Offset = "0xDC02A8", Length = "0x2EC")]
		private static void GetEventList<T>(GameObject go, IList<IEventSystemHandler> results) where T : IEventSystemHandler
		{
		}

		[Token(Token = "0x60006BB")]
		[Address(RVA = "0xDBF37C", Offset = "0xDBF37C", Length = "0xF4")]
		public static bool CanHandleEvent<T>(GameObject go) where T : IEventSystemHandler
		{
			return false;
		}

		[Token(Token = "0x60006BC")]
		[Address(RVA = "0xDC0044", Offset = "0xDC0044", Length = "0x130")]
		public static GameObject GetEventHandler<T>(GameObject root) where T : IEventSystemHandler
		{
			return null;
		}
	}
}
