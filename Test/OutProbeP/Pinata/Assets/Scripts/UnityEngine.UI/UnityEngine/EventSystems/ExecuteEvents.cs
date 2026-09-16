using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine.UI;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x2000065")]
	public static class ExecuteEvents
	{
		[Token(Token = "0x20000BC")]
		public delegate void EventFunction<T1>(T1 handler, BaseEventData eventData);

		[Token(Token = "0x40001D0")]
		private static readonly EventFunction<IPointerEnterHandler> s_PointerEnterHandler;

		[Token(Token = "0x40001D1")]
		private static readonly EventFunction<IPointerExitHandler> s_PointerExitHandler;

		[Token(Token = "0x40001D2")]
		private static readonly EventFunction<IPointerDownHandler> s_PointerDownHandler;

		[Token(Token = "0x40001D3")]
		private static readonly EventFunction<IPointerUpHandler> s_PointerUpHandler;

		[Token(Token = "0x40001D4")]
		private static readonly EventFunction<IPointerClickHandler> s_PointerClickHandler;

		[Token(Token = "0x40001D5")]
		private static readonly EventFunction<IInitializePotentialDragHandler> s_InitializePotentialDragHandler;

		[Token(Token = "0x40001D6")]
		private static readonly EventFunction<IBeginDragHandler> s_BeginDragHandler;

		[Token(Token = "0x40001D7")]
		private static readonly EventFunction<IDragHandler> s_DragHandler;

		[Token(Token = "0x40001D8")]
		private static readonly EventFunction<IEndDragHandler> s_EndDragHandler;

		[Token(Token = "0x40001D9")]
		private static readonly EventFunction<IDropHandler> s_DropHandler;

		[Token(Token = "0x40001DA")]
		private static readonly EventFunction<IScrollHandler> s_ScrollHandler;

		[Token(Token = "0x40001DB")]
		private static readonly EventFunction<IUpdateSelectedHandler> s_UpdateSelectedHandler;

		[Token(Token = "0x40001DC")]
		private static readonly EventFunction<ISelectHandler> s_SelectHandler;

		[Token(Token = "0x40001DD")]
		private static readonly EventFunction<IDeselectHandler> s_DeselectHandler;

		[Token(Token = "0x40001DE")]
		private static readonly EventFunction<IMoveHandler> s_MoveHandler;

		[Token(Token = "0x40001DF")]
		private static readonly EventFunction<ISubmitHandler> s_SubmitHandler;

		[Token(Token = "0x40001E0")]
		private static readonly EventFunction<ICancelHandler> s_CancelHandler;

		[Token(Token = "0x40001E1")]
		private static readonly ObjectPool<List<IEventSystemHandler>> s_HandlerListPool;

		[Token(Token = "0x40001E2")]
		private static readonly List<Transform> s_InternalTransformList;

		[Token(Token = "0x17000176")]
		public static EventFunction<IPointerEnterHandler> pointerEnterHandler
		{
			[Token(Token = "0x6000563")]
			[Address(RVA = "0xC44AB0", Offset = "0xC44AB0", Length = "0x68")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000177")]
		public static EventFunction<IPointerExitHandler> pointerExitHandler
		{
			[Token(Token = "0x6000564")]
			[Address(RVA = "0xC44B18", Offset = "0xC44B18", Length = "0x68")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000178")]
		public static EventFunction<IPointerDownHandler> pointerDownHandler
		{
			[Token(Token = "0x6000565")]
			[Address(RVA = "0xC44B80", Offset = "0xC44B80", Length = "0x68")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000179")]
		public static EventFunction<IPointerUpHandler> pointerUpHandler
		{
			[Token(Token = "0x6000566")]
			[Address(RVA = "0xC44BE8", Offset = "0xC44BE8", Length = "0x68")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700017A")]
		public static EventFunction<IPointerClickHandler> pointerClickHandler
		{
			[Token(Token = "0x6000567")]
			[Address(RVA = "0xC44C50", Offset = "0xC44C50", Length = "0x68")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700017B")]
		public static EventFunction<IInitializePotentialDragHandler> initializePotentialDrag
		{
			[Token(Token = "0x6000568")]
			[Address(RVA = "0xC44CB8", Offset = "0xC44CB8", Length = "0x68")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700017C")]
		public static EventFunction<IBeginDragHandler> beginDragHandler
		{
			[Token(Token = "0x6000569")]
			[Address(RVA = "0xC44D20", Offset = "0xC44D20", Length = "0x68")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700017D")]
		public static EventFunction<IDragHandler> dragHandler
		{
			[Token(Token = "0x600056A")]
			[Address(RVA = "0xC44D88", Offset = "0xC44D88", Length = "0x68")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700017E")]
		public static EventFunction<IEndDragHandler> endDragHandler
		{
			[Token(Token = "0x600056B")]
			[Address(RVA = "0xC44DF0", Offset = "0xC44DF0", Length = "0x68")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700017F")]
		public static EventFunction<IDropHandler> dropHandler
		{
			[Token(Token = "0x600056C")]
			[Address(RVA = "0xC44E58", Offset = "0xC44E58", Length = "0x68")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000180")]
		public static EventFunction<IScrollHandler> scrollHandler
		{
			[Token(Token = "0x600056D")]
			[Address(RVA = "0xC44EC0", Offset = "0xC44EC0", Length = "0x68")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000181")]
		public static EventFunction<IUpdateSelectedHandler> updateSelectedHandler
		{
			[Token(Token = "0x600056E")]
			[Address(RVA = "0xC44F28", Offset = "0xC44F28", Length = "0x68")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000182")]
		public static EventFunction<ISelectHandler> selectHandler
		{
			[Token(Token = "0x600056F")]
			[Address(RVA = "0xC44F90", Offset = "0xC44F90", Length = "0x68")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000183")]
		public static EventFunction<IDeselectHandler> deselectHandler
		{
			[Token(Token = "0x6000570")]
			[Address(RVA = "0xC44FF8", Offset = "0xC44FF8", Length = "0x68")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000184")]
		public static EventFunction<IMoveHandler> moveHandler
		{
			[Token(Token = "0x6000571")]
			[Address(RVA = "0xC45060", Offset = "0xC45060", Length = "0x68")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000185")]
		public static EventFunction<ISubmitHandler> submitHandler
		{
			[Token(Token = "0x6000572")]
			[Address(RVA = "0xC450C8", Offset = "0xC450C8", Length = "0x68")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000186")]
		public static EventFunction<ICancelHandler> cancelHandler
		{
			[Token(Token = "0x6000573")]
			[Address(RVA = "0xC45130", Offset = "0xC45130", Length = "0x68")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x6000551")]
		[Address(RVA = "0xACC84C", Offset = "0xACC84C", Length = "0x1C4")]
		public static T ValidateEventData<T>(BaseEventData data) where T : class
		{
			return null;
		}

		[Token(Token = "0x6000552")]
		[Address(RVA = "0xC43B50", Offset = "0xC43B50", Length = "0xF8")]
		private static void Execute(IPointerEnterHandler handler, BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000553")]
		[Address(RVA = "0xC43C48", Offset = "0xC43C48", Length = "0xF8")]
		private static void Execute(IPointerExitHandler handler, BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000554")]
		[Address(RVA = "0xC43D40", Offset = "0xC43D40", Length = "0xF8")]
		private static void Execute(IPointerDownHandler handler, BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000555")]
		[Address(RVA = "0xC43E38", Offset = "0xC43E38", Length = "0xF8")]
		private static void Execute(IPointerUpHandler handler, BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000556")]
		[Address(RVA = "0xC43F30", Offset = "0xC43F30", Length = "0xF8")]
		private static void Execute(IPointerClickHandler handler, BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000557")]
		[Address(RVA = "0xC44028", Offset = "0xC44028", Length = "0xF8")]
		private static void Execute(IInitializePotentialDragHandler handler, BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000558")]
		[Address(RVA = "0xC44120", Offset = "0xC44120", Length = "0xF8")]
		private static void Execute(IBeginDragHandler handler, BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000559")]
		[Address(RVA = "0xC44218", Offset = "0xC44218", Length = "0xF8")]
		private static void Execute(IDragHandler handler, BaseEventData eventData)
		{
		}

		[Token(Token = "0x600055A")]
		[Address(RVA = "0xC44310", Offset = "0xC44310", Length = "0xF8")]
		private static void Execute(IEndDragHandler handler, BaseEventData eventData)
		{
		}

		[Token(Token = "0x600055B")]
		[Address(RVA = "0xC44408", Offset = "0xC44408", Length = "0xF8")]
		private static void Execute(IDropHandler handler, BaseEventData eventData)
		{
		}

		[Token(Token = "0x600055C")]
		[Address(RVA = "0xC44500", Offset = "0xC44500", Length = "0xF8")]
		private static void Execute(IScrollHandler handler, BaseEventData eventData)
		{
		}

		[Token(Token = "0x600055D")]
		[Address(RVA = "0xC445F8", Offset = "0xC445F8", Length = "0xC0")]
		private static void Execute(IUpdateSelectedHandler handler, BaseEventData eventData)
		{
		}

		[Token(Token = "0x600055E")]
		[Address(RVA = "0xC446B8", Offset = "0xC446B8", Length = "0xC0")]
		private static void Execute(ISelectHandler handler, BaseEventData eventData)
		{
		}

		[Token(Token = "0x600055F")]
		[Address(RVA = "0xC44778", Offset = "0xC44778", Length = "0xC0")]
		private static void Execute(IDeselectHandler handler, BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000560")]
		[Address(RVA = "0xC44838", Offset = "0xC44838", Length = "0xF8")]
		private static void Execute(IMoveHandler handler, BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000561")]
		[Address(RVA = "0xC44930", Offset = "0xC44930", Length = "0xC0")]
		private static void Execute(ISubmitHandler handler, BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000562")]
		[Address(RVA = "0xC449F0", Offset = "0xC449F0", Length = "0xC0")]
		private static void Execute(ICancelHandler handler, BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000574")]
		[Address(RVA = "0xC45198", Offset = "0xC45198", Length = "0x1B4")]
		private static void GetEventChain(GameObject root, IList<Transform> eventChain)
		{
		}

		[Token(Token = "0x6000575")]
		[Address(RVA = "0xD6BB80", Offset = "0xD6BB80", Length = "0x3EC")]
		public static bool Execute<T>(GameObject target, BaseEventData eventData, EventFunction<T> functor) where T : IEventSystemHandler
		{
			return false;
		}

		[Token(Token = "0x6000576")]
		[Address(RVA = "0x16489C8", Offset = "0x16489C8", Length = "0x168")]
		public static GameObject ExecuteHierarchy<T>(GameObject root, BaseEventData eventData, EventFunction<T> callbackFunction) where T : IEventSystemHandler
		{
			return null;
		}

		[Token(Token = "0x6000577")]
		[Address(RVA = "0xD6BF6C", Offset = "0xD6BF6C", Length = "0x668")]
		private static bool ShouldSendToComponent<T>(Component component) where T : IEventSystemHandler
		{
			return false;
		}

		[Token(Token = "0x6000578")]
		[Address(RVA = "0xB849EC", Offset = "0xB849EC", Length = "0x2BC")]
		private static void GetEventList<T>(GameObject go, IList<IEventSystemHandler> results) where T : IEventSystemHandler
		{
		}

		[Token(Token = "0x6000579")]
		[Address(RVA = "0xD6BA98", Offset = "0xD6BA98", Length = "0xE8")]
		public static bool CanHandleEvent<T>(GameObject go) where T : IEventSystemHandler
		{
			return false;
		}

		[Token(Token = "0x600057A")]
		[Address(RVA = "0x1648B30", Offset = "0x1648B30", Length = "0x154")]
		public static GameObject GetEventHandler<T>(GameObject root) where T : IEventSystemHandler
		{
			return null;
		}
	}
}
