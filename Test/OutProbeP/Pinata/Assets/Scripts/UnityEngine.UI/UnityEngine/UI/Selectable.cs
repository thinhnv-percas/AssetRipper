using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace UnityEngine.UI
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x727930", Offset = "0x727930")]
	[ExecuteAlways]
	[SelectionBase]
	[DisallowMultipleComponent]
	[Token(Token = "0x2000033")]
	public class Selectable : UIBehaviour, IMoveHandler, IEventSystemHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
	{
		[Token(Token = "0x20000A5")]
		public enum Transition
		{
			[Token(Token = "0x40002D1")]
			None = 0,
			[Token(Token = "0x40002D2")]
			ColorTint = 1,
			[Token(Token = "0x40002D3")]
			SpriteSwap = 2,
			[Token(Token = "0x40002D4")]
			Animation = 3
		}

		[Token(Token = "0x20000A6")]
		protected enum SelectionState
		{
			[Token(Token = "0x40002D6")]
			Normal = 0,
			[Token(Token = "0x40002D7")]
			Highlighted = 1,
			[Token(Token = "0x40002D8")]
			Pressed = 2,
			[Token(Token = "0x40002D9")]
			Selected = 3,
			[Token(Token = "0x40002DA")]
			Disabled = 4
		}

		[Token(Token = "0x4000137")]
		private static Selectable[] s_Selectables;

		[Token(Token = "0x4000138")]
		private static int s_SelectableCount;

		[Token(Token = "0x4000139")]
		private static bool s_IsDirty;

		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x7296E0", Offset = "0x7296E0")]
		[SerializeField]
		[Token(Token = "0x400013A")]
		[FieldOffset(Offset = "0x18")]
		private Navigation m_Navigation;

		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x72972C", Offset = "0x72972C")]
		[SerializeField]
		[Token(Token = "0x400013B")]
		[FieldOffset(Offset = "0x40")]
		private Transition m_Transition;

		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x729778", Offset = "0x729778")]
		[SerializeField]
		[Token(Token = "0x400013C")]
		[FieldOffset(Offset = "0x44")]
		private ColorBlock m_Colors;

		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x7297C4", Offset = "0x7297C4")]
		[SerializeField]
		[Token(Token = "0x400013D")]
		[FieldOffset(Offset = "0xA0")]
		private SpriteState m_SpriteState;

		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x729810", Offset = "0x729810")]
		[SerializeField]
		[Token(Token = "0x400013E")]
		[FieldOffset(Offset = "0xC0")]
		private AnimationTriggers m_AnimationTriggers;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x72985C", Offset = "0x72985C")]
		[SerializeField]
		[Token(Token = "0x400013F")]
		[FieldOffset(Offset = "0xC8")]
		private bool m_Interactable;

		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x7298A8", Offset = "0x7298A8")]
		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x7298A8", Offset = "0x7298A8")]
		[SerializeField]
		[Token(Token = "0x4000140")]
		[FieldOffset(Offset = "0xD0")]
		private Graphic m_TargetGraphic;

		[Token(Token = "0x4000141")]
		[FieldOffset(Offset = "0xD8")]
		private bool m_GroupsAllowInteraction;

		[Token(Token = "0x4000142")]
		[FieldOffset(Offset = "0xD9")]
		private bool m_WillRemove;

		[Token(Token = "0x4000146")]
		[FieldOffset(Offset = "0xE0")]
		private readonly List<CanvasGroup> m_CanvasGroupCache;

		[Token(Token = "0x170000FC")]
		public static Selectable[] allSelectablesArray
		{
			[Token(Token = "0x600038C")]
			[Address(RVA = "0xED595C", Offset = "0xED595C", Length = "0xE0")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000FD")]
		public static int allSelectableCount
		{
			[Token(Token = "0x600038D")]
			[Address(RVA = "0xED5C54", Offset = "0xED5C54", Length = "0x68")]
			get
			{
				return 0;
			}
		}

		[Obsolete]
		[Token(Token = "0x170000FE")]
		public static List<Selectable> allSelectables
		{
			[Token(Token = "0x600038E")]
			[Address(RVA = "0xED5CBC", Offset = "0xED5CBC", Length = "0x94")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170000FF")]
		public Navigation navigation
		{
			[Token(Token = "0x6000390")]
			[Address(RVA = "0xED5E78", Offset = "0xED5E78", Length = "0x1C")]
			get
			{
				return default(Navigation);
			}
			[Token(Token = "0x6000391")]
			[Address(RVA = "0xED5E94", Offset = "0xED5E94", Length = "0xA0")]
			set
			{
			}
		}

		[Token(Token = "0x17000100")]
		public Transition transition
		{
			[Token(Token = "0x6000392")]
			[Address(RVA = "0xED5FA4", Offset = "0xED5FA4", Length = "0x8")]
			get
			{
				return Transition.None;
			}
			[Token(Token = "0x6000393")]
			[Address(RVA = "0xED5FAC", Offset = "0xED5FAC", Length = "0x7C")]
			set
			{
			}
		}

		[Token(Token = "0x17000101")]
		public ColorBlock colors
		{
			[Token(Token = "0x6000394")]
			[Address(RVA = "0xED6028", Offset = "0xED6028", Length = "0x10")]
			get
			{
				return default(ColorBlock);
			}
			[Token(Token = "0x6000395")]
			[Address(RVA = "0xED6038", Offset = "0xED6038", Length = "0xA0")]
			set
			{
			}
		}

		[Token(Token = "0x17000102")]
		public SpriteState spriteState
		{
			[Token(Token = "0x6000396")]
			[Address(RVA = "0xED60D8", Offset = "0xED60D8", Length = "0x14")]
			get
			{
				return default(SpriteState);
			}
			[Token(Token = "0x6000397")]
			[Address(RVA = "0xED60EC", Offset = "0xED60EC", Length = "0x90")]
			set
			{
			}
		}

		[Token(Token = "0x17000103")]
		public AnimationTriggers animationTriggers
		{
			[Token(Token = "0x6000398")]
			[Address(RVA = "0xED617C", Offset = "0xED617C", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000399")]
			[Address(RVA = "0xED6184", Offset = "0xED6184", Length = "0x7C")]
			set
			{
			}
		}

		[Token(Token = "0x17000104")]
		public Graphic targetGraphic
		{
			[Token(Token = "0x600039A")]
			[Address(RVA = "0xED6200", Offset = "0xED6200", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600039B")]
			[Address(RVA = "0xED6208", Offset = "0xED6208", Length = "0x7C")]
			set
			{
			}
		}

		[Token(Token = "0x17000105")]
		public bool interactable
		{
			[Token(Token = "0x600039C")]
			[Address(RVA = "0xED6284", Offset = "0xED6284", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x600039D")]
			[Address(RVA = "0xED628C", Offset = "0xED628C", Length = "0x188")]
			set
			{
			}
		}

		[Token(Token = "0x17000106")]
		[field: Token(Token = "0x4000143")]
		[field: FieldOffset(Offset = "0xDA")]
		private bool isPointerInside
		{
			[Token(Token = "0x600039E")]
			[Address(RVA = "0xED6414", Offset = "0xED6414", Length = "0x8")]
			get;
			[Token(Token = "0x600039F")]
			[Address(RVA = "0xED641C", Offset = "0xED641C", Length = "0xC")]
			set;
		}

		[Token(Token = "0x17000107")]
		[field: Token(Token = "0x4000144")]
		[field: FieldOffset(Offset = "0xDB")]
		private bool isPointerDown
		{
			[Token(Token = "0x60003A0")]
			[Address(RVA = "0xED6428", Offset = "0xED6428", Length = "0x8")]
			get;
			[Token(Token = "0x60003A1")]
			[Address(RVA = "0xED6430", Offset = "0xED6430", Length = "0xC")]
			set;
		}

		[Token(Token = "0x17000108")]
		[field: Token(Token = "0x4000145")]
		[field: FieldOffset(Offset = "0xDC")]
		private bool hasSelection
		{
			[Token(Token = "0x60003A2")]
			[Address(RVA = "0xED643C", Offset = "0xED643C", Length = "0x8")]
			get;
			[Token(Token = "0x60003A3")]
			[Address(RVA = "0xED6444", Offset = "0xED6444", Length = "0xC")]
			set;
		}

		[Token(Token = "0x17000109")]
		public Image image
		{
			[Token(Token = "0x60003A5")]
			[Address(RVA = "0xED6450", Offset = "0xED6450", Length = "0x84")]
			get
			{
				return null;
			}
			[Token(Token = "0x60003A6")]
			[Address(RVA = "0xED64D4", Offset = "0xED64D4", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700010A")]
		public Animator animator
		{
			[Token(Token = "0x60003A7")]
			[Address(RVA = "0xED64DC", Offset = "0xED64DC", Length = "0x50")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700010B")]
		protected SelectionState currentSelectionState
		{
			[Token(Token = "0x60003B1")]
			[Address(RVA = "0xED67A0", Offset = "0xED67A0", Length = "0x5C")]
			get
			{
				return SelectionState.Normal;
			}
		}

		[Token(Token = "0x600038F")]
		[Address(RVA = "0xED5D50", Offset = "0xED5D50", Length = "0x128")]
		public static int AllSelectablesNoAlloc(Selectable[] selectables)
		{
			return 0;
		}

		[Token(Token = "0x60003A4")]
		[Address(RVA = "0xED3BBC", Offset = "0xED3BBC", Length = "0xE4")]
		protected internal Selectable()
		{
		}

		[Token(Token = "0x60003A8")]
		[Address(RVA = "0xED652C", Offset = "0xED652C", Length = "0x90")]
		protected override void Awake()
		{
		}

		[Token(Token = "0x60003A9")]
		[Address(RVA = "0xED65BC", Offset = "0xED65BC", Length = "0x1C0")]
		protected override void OnCanvasGroupChanged()
		{
		}

		[Token(Token = "0x60003AA")]
		[Address(RVA = "0xED677C", Offset = "0xED677C", Length = "0x20")]
		public virtual bool IsInteractable()
		{
			return false;
		}

		[Token(Token = "0x60003AB")]
		[Address(RVA = "0xED679C", Offset = "0xED679C", Length = "0x4")]
		protected override void OnDidApplyAnimationProperties()
		{
		}

		[Token(Token = "0x60003AC")]
		[Address(RVA = "0xED3FA4", Offset = "0xED3FA4", Length = "0x220")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x60003AD")]
		[Address(RVA = "0xED67FC", Offset = "0xED67FC", Length = "0x34")]
		protected override void OnTransformParentChanged()
		{
		}

		[Token(Token = "0x60003AE")]
		[Address(RVA = "0xED5F34", Offset = "0xED5F34", Length = "0x70")]
		private void OnSetProperty()
		{
		}

		[Token(Token = "0x60003AF")]
		[Address(RVA = "0xED41F0", Offset = "0xED41F0", Length = "0x98")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x60003B0")]
		[Address(RVA = "0xED5A3C", Offset = "0xED5A3C", Length = "0x218")]
		private static void RemoveInvalidSelectables()
		{
		}

		[Token(Token = "0x60003B2")]
		[Address(RVA = "0xED6830", Offset = "0xED6830", Length = "0x94")]
		protected virtual void InstantClearState()
		{
		}

		[Token(Token = "0x60003B3")]
		[Address(RVA = "0xED6C20", Offset = "0xED6C20", Length = "0x1AC")]
		protected virtual void DoStateTransition(SelectionState state, bool instant)
		{
		}

		[Token(Token = "0x60003B4")]
		[Address(RVA = "0xED6DCC", Offset = "0xED6DCC", Length = "0x4B8")]
		public Selectable FindSelectable(Vector3 dir)
		{
			return null;
		}

		[Token(Token = "0x60003B5")]
		[Address(RVA = "0xED7284", Offset = "0xED7284", Length = "0x238")]
		private static Vector3 GetPointOnRectEdge(RectTransform rect, Vector2 dir)
		{
			return default(Vector3);
		}

		[Token(Token = "0x60003B6")]
		[Address(RVA = "0xED74BC", Offset = "0xED74BC", Length = "0xCC")]
		private void Navigate(AxisEventData eventData, Selectable sel)
		{
		}

		[Token(Token = "0x60003B7")]
		[Address(RVA = "0xED4FEC", Offset = "0xED4FEC", Length = "0x140")]
		public virtual Selectable FindSelectableOnLeft()
		{
			return null;
		}

		[Token(Token = "0x60003B8")]
		[Address(RVA = "0xED5150", Offset = "0xED5150", Length = "0x140")]
		public virtual Selectable FindSelectableOnRight()
		{
			return null;
		}

		[Token(Token = "0x60003B9")]
		[Address(RVA = "0xED52B4", Offset = "0xED52B4", Length = "0x140")]
		public virtual Selectable FindSelectableOnUp()
		{
			return null;
		}

		[Token(Token = "0x60003BA")]
		[Address(RVA = "0xED5418", Offset = "0xED5418", Length = "0x140")]
		public virtual Selectable FindSelectableOnDown()
		{
			return null;
		}

		[Token(Token = "0x60003BB")]
		[Address(RVA = "0xED4F2C", Offset = "0xED4F2C", Length = "0x9C")]
		public virtual void OnMove(AxisEventData eventData)
		{
		}

		[Token(Token = "0x60003BC")]
		[Address(RVA = "0xED68C4", Offset = "0xED68C4", Length = "0xF8")]
		private void StartColorTween(Color targetColor, bool instant)
		{
		}

		[Token(Token = "0x60003BD")]
		[Address(RVA = "0xED69BC", Offset = "0xED69BC", Length = "0xB8")]
		private void DoSpriteSwap(Sprite newSprite)
		{
		}

		[Token(Token = "0x60003BE")]
		[Address(RVA = "0xED6A74", Offset = "0xED6A74", Length = "0x1AC")]
		private void TriggerAnimation(string triggername)
		{
		}

		[Token(Token = "0x60003BF")]
		[Address(RVA = "0xED7588", Offset = "0xED7588", Length = "0x68")]
		protected bool IsHighlighted()
		{
			return false;
		}

		[Token(Token = "0x60003C0")]
		[Address(RVA = "0xED75F0", Offset = "0xED75F0", Length = "0x58")]
		protected bool IsPressed()
		{
			return false;
		}

		[Token(Token = "0x60003C1")]
		[Address(RVA = "0xED7648", Offset = "0xED7648", Length = "0xA8")]
		private void EvaluateAndTransitionToSelectionState()
		{
		}

		[Token(Token = "0x60003C2")]
		[Address(RVA = "0xED4A54", Offset = "0xED4A54", Length = "0x148")]
		public virtual void OnPointerDown(PointerEventData eventData)
		{
		}

		[Token(Token = "0x60003C3")]
		[Address(RVA = "0xED4C6C", Offset = "0xED4C6C", Length = "0x28")]
		public virtual void OnPointerUp(PointerEventData eventData)
		{
		}

		[Token(Token = "0x60003C4")]
		[Address(RVA = "0xED76F0", Offset = "0xED76F0", Length = "0xC")]
		public virtual void OnPointerEnter(PointerEventData eventData)
		{
		}

		[Token(Token = "0x60003C5")]
		[Address(RVA = "0xED76FC", Offset = "0xED76FC", Length = "0x8")]
		public virtual void OnPointerExit(PointerEventData eventData)
		{
		}

		[Token(Token = "0x60003C6")]
		[Address(RVA = "0xED7704", Offset = "0xED7704", Length = "0xC")]
		public virtual void OnSelect(BaseEventData eventData)
		{
		}

		[Token(Token = "0x60003C7")]
		[Address(RVA = "0xED7710", Offset = "0xED7710", Length = "0x8")]
		public virtual void OnDeselect(BaseEventData eventData)
		{
		}

		[Token(Token = "0x60003C8")]
		[Address(RVA = "0xED7718", Offset = "0xED7718", Length = "0x134")]
		public virtual void Select()
		{
		}
	}
}
