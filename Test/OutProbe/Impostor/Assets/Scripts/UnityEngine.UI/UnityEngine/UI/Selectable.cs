using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

namespace UnityEngine.UI
{
	[ExecuteAlways]
	[AddComponentMenu("UI/Selectable", 35)]
	[SelectionBase]
	[DisallowMultipleComponent]
	[Token(Token = "0x2000069")]
	public class Selectable : UIBehaviour, IMoveHandler, IEventSystemHandler, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
	{
		[Token(Token = "0x200006A")]
		public enum Transition
		{
			[Token(Token = "0x4000217")]
			None = 0,
			[Token(Token = "0x4000218")]
			ColorTint = 1,
			[Token(Token = "0x4000219")]
			SpriteSwap = 2,
			[Token(Token = "0x400021A")]
			Animation = 3
		}

		[Token(Token = "0x200006B")]
		protected enum SelectionState
		{
			[Token(Token = "0x400021C")]
			Normal = 0,
			[Token(Token = "0x400021D")]
			Highlighted = 1,
			[Token(Token = "0x400021E")]
			Pressed = 2,
			[Token(Token = "0x400021F")]
			Selected = 3,
			[Token(Token = "0x4000220")]
			Disabled = 4
		}

		[Token(Token = "0x4000206")]
		protected static Selectable[] s_Selectables;

		[Token(Token = "0x4000207")]
		protected static int s_SelectableCount;

		[Token(Token = "0x4000208")]
		[FieldOffset(Offset = "0x20")]
		private bool m_EnableCalled;

		[FormerlySerializedAs("navigation")]
		[SerializeField]
		[Token(Token = "0x4000209")]
		[FieldOffset(Offset = "0x28")]
		private Navigation m_Navigation;

		[SerializeField]
		[FormerlySerializedAs("transition")]
		[Token(Token = "0x400020A")]
		[FieldOffset(Offset = "0x50")]
		private Transition m_Transition;

		[SerializeField]
		[FormerlySerializedAs("colors")]
		[Token(Token = "0x400020B")]
		[FieldOffset(Offset = "0x54")]
		private ColorBlock m_Colors;

		[FormerlySerializedAs("spriteState")]
		[SerializeField]
		[Token(Token = "0x400020C")]
		[FieldOffset(Offset = "0xB0")]
		private SpriteState m_SpriteState;

		[SerializeField]
		[FormerlySerializedAs("animationTriggers")]
		[Token(Token = "0x400020D")]
		[FieldOffset(Offset = "0xD0")]
		private AnimationTriggers m_AnimationTriggers;

		[SerializeField]
		[Tooltip("Can the Selectable be interacted with?")]
		[Token(Token = "0x400020E")]
		[FieldOffset(Offset = "0xD8")]
		private bool m_Interactable;

		[FormerlySerializedAs("m_HighlightGraphic")]
		[SerializeField]
		[FormerlySerializedAs("highlightGraphic")]
		[Token(Token = "0x400020F")]
		[FieldOffset(Offset = "0xE0")]
		private Graphic m_TargetGraphic;

		[Token(Token = "0x4000210")]
		[FieldOffset(Offset = "0xE8")]
		private bool m_GroupsAllowInteraction;

		[Token(Token = "0x4000211")]
		[FieldOffset(Offset = "0xEC")]
		protected int m_CurrentIndex;

		[Token(Token = "0x4000215")]
		[FieldOffset(Offset = "0xF8")]
		private readonly List<CanvasGroup> m_CanvasGroupCache;

		[Token(Token = "0x17000116")]
		public static Selectable[] allSelectablesArray
		{
			[Token(Token = "0x6000420")]
			[Address(RVA = "0x18342D4", Offset = "0x18342D4", Length = "0x9C")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000117")]
		public static int allSelectableCount
		{
			[Token(Token = "0x6000421")]
			[Address(RVA = "0x1834370", Offset = "0x1834370", Length = "0x58")]
			get
			{
				return 0;
			}
		}

		[Obsolete("Replaced with allSelectablesArray to have better performance when disabling a element", false)]
		[Token(Token = "0x17000118")]
		public static List<Selectable> allSelectables
		{
			[Token(Token = "0x6000422")]
			[Address(RVA = "0x18343C8", Offset = "0x18343C8", Length = "0x9C")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000119")]
		public Navigation navigation
		{
			[Token(Token = "0x6000424")]
			[Address(RVA = "0x1834520", Offset = "0x1834520", Length = "0x18")]
			get
			{
				return default(Navigation);
			}
			[Token(Token = "0x6000425")]
			[Address(RVA = "0x1834538", Offset = "0x1834538", Length = "0x88")]
			set
			{
			}
		}

		[Token(Token = "0x1700011A")]
		public Transition transition
		{
			[Token(Token = "0x6000426")]
			[Address(RVA = "0x1834624", Offset = "0x1834624", Length = "0x8")]
			get
			{
				return Transition.None;
			}
			[Token(Token = "0x6000427")]
			[Address(RVA = "0x183462C", Offset = "0x183462C", Length = "0x74")]
			set
			{
			}
		}

		[Token(Token = "0x1700011B")]
		public ColorBlock colors
		{
			[Token(Token = "0x6000428")]
			[Address(RVA = "0x18346A0", Offset = "0x18346A0", Length = "0x10")]
			get
			{
				return default(ColorBlock);
			}
			[Token(Token = "0x6000429")]
			[Address(RVA = "0x18346B0", Offset = "0x18346B0", Length = "0x98")]
			set
			{
			}
		}

		[Token(Token = "0x1700011C")]
		public SpriteState spriteState
		{
			[Token(Token = "0x600042A")]
			[Address(RVA = "0x1834748", Offset = "0x1834748", Length = "0xC")]
			get
			{
				return default(SpriteState);
			}
			[Token(Token = "0x600042B")]
			[Address(RVA = "0x1834754", Offset = "0x1834754", Length = "0x7C")]
			set
			{
			}
		}

		[Token(Token = "0x1700011D")]
		public AnimationTriggers animationTriggers
		{
			[Token(Token = "0x600042C")]
			[Address(RVA = "0x18347D0", Offset = "0x18347D0", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600042D")]
			[Address(RVA = "0x18347D8", Offset = "0x18347D8", Length = "0x74")]
			set
			{
			}
		}

		[Token(Token = "0x1700011E")]
		public Graphic targetGraphic
		{
			[Token(Token = "0x600042E")]
			[Address(RVA = "0x183484C", Offset = "0x183484C", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600042F")]
			[Address(RVA = "0x1834854", Offset = "0x1834854", Length = "0x74")]
			set
			{
			}
		}

		[Token(Token = "0x1700011F")]
		public bool interactable
		{
			[Token(Token = "0x6000430")]
			[Address(RVA = "0x18348C8", Offset = "0x18348C8", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000431")]
			[Address(RVA = "0x18348D0", Offset = "0x18348D0", Length = "0x170")]
			set
			{
			}
		}

		[Token(Token = "0x17000120")]
		[field: Token(Token = "0x4000212")]
		[field: FieldOffset(Offset = "0xF0")]
		private bool isPointerInside
		{
			[Token(Token = "0x6000432")]
			[Address(RVA = "0x1834A40", Offset = "0x1834A40", Length = "0x8")]
			get;
			[Token(Token = "0x6000433")]
			[Address(RVA = "0x1834A48", Offset = "0x1834A48", Length = "0xC")]
			set;
		}

		[Token(Token = "0x17000121")]
		[field: Token(Token = "0x4000213")]
		[field: FieldOffset(Offset = "0xF1")]
		private bool isPointerDown
		{
			[Token(Token = "0x6000434")]
			[Address(RVA = "0x1834A54", Offset = "0x1834A54", Length = "0x8")]
			get;
			[Token(Token = "0x6000435")]
			[Address(RVA = "0x1834A5C", Offset = "0x1834A5C", Length = "0xC")]
			set;
		}

		[Token(Token = "0x17000122")]
		[field: Token(Token = "0x4000214")]
		[field: FieldOffset(Offset = "0xF2")]
		private bool hasSelection
		{
			[Token(Token = "0x6000436")]
			[Address(RVA = "0x1834A68", Offset = "0x1834A68", Length = "0x8")]
			get;
			[Token(Token = "0x6000437")]
			[Address(RVA = "0x1834A70", Offset = "0x1834A70", Length = "0xC")]
			set;
		}

		[Token(Token = "0x17000123")]
		public Image image
		{
			[Token(Token = "0x6000439")]
			[Address(RVA = "0x1834A7C", Offset = "0x1834A7C", Length = "0x7C")]
			get
			{
				return null;
			}
			[Token(Token = "0x600043A")]
			[Address(RVA = "0x1834AF8", Offset = "0x1834AF8", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000124")]
		public Animator animator
		{
			[Token(Token = "0x600043B")]
			[Address(RVA = "0x1834B00", Offset = "0x1834B00", Length = "0x48")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000125")]
		protected SelectionState currentSelectionState
		{
			[Token(Token = "0x6000446")]
			[Address(RVA = "0x1834DA4", Offset = "0x1834DA4", Length = "0x50")]
			get
			{
				return SelectionState.Normal;
			}
		}

		[Token(Token = "0x6000423")]
		[Address(RVA = "0x1834464", Offset = "0x1834464", Length = "0xBC")]
		public static int AllSelectablesNoAlloc(Selectable[] selectables)
		{
			return 0;
		}

		[Token(Token = "0x6000438")]
		[Address(RVA = "0x182F018", Offset = "0x182F018", Length = "0x114")]
		protected internal Selectable()
		{
		}

		[Token(Token = "0x600043C")]
		[Address(RVA = "0x1834B48", Offset = "0x1834B48", Length = "0x8C")]
		protected override void Awake()
		{
		}

		[Token(Token = "0x600043D")]
		[Address(RVA = "0x1834BD4", Offset = "0x1834BD4", Length = "0x34")]
		protected override void OnCanvasGroupChanged()
		{
		}

		[Token(Token = "0x600043E")]
		[Address(RVA = "0x1834C08", Offset = "0x1834C08", Length = "0x178")]
		private bool ParentGroupAllowsInteraction()
		{
			return false;
		}

		[Token(Token = "0x600043F")]
		[Address(RVA = "0x1834D80", Offset = "0x1834D80", Length = "0x20")]
		public virtual bool IsInteractable()
		{
			return false;
		}

		[Token(Token = "0x6000440")]
		[Address(RVA = "0x1834DA0", Offset = "0x1834DA0", Length = "0x4")]
		protected override void OnDidApplyAnimationProperties()
		{
		}

		[Token(Token = "0x6000441")]
		[Address(RVA = "0x182F448", Offset = "0x182F448", Length = "0x2B8")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x6000442")]
		[Address(RVA = "0x1834DF4", Offset = "0x1834DF4", Length = "0x28")]
		protected override void OnTransformParentChanged()
		{
		}

		[Token(Token = "0x6000443")]
		[Address(RVA = "0x18345C0", Offset = "0x18345C0", Length = "0x64")]
		private void OnSetProperty()
		{
		}

		[Token(Token = "0x6000444")]
		[Address(RVA = "0x182F720", Offset = "0x182F720", Length = "0x128")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x6000445")]
		[Address(RVA = "0x1834E1C", Offset = "0x1834E1C", Length = "0x5C")]
		private void OnApplicationFocus(bool hasFocus)
		{
		}

		[Token(Token = "0x6000447")]
		[Address(RVA = "0x1834EC4", Offset = "0x1834EC4", Length = "0x70")]
		protected virtual void InstantClearState()
		{
		}

		[Token(Token = "0x6000448")]
		[Address(RVA = "0x1835274", Offset = "0x1835274", Length = "0x274")]
		protected virtual void DoStateTransition(SelectionState state, bool instant)
		{
		}

		[Token(Token = "0x6000449")]
		[Address(RVA = "0x18354E8", Offset = "0x18354E8", Length = "0x4B4")]
		public Selectable FindSelectable(Vector3 dir)
		{
			return null;
		}

		[Token(Token = "0x600044A")]
		[Address(RVA = "0x183599C", Offset = "0x183599C", Length = "0x180")]
		private static Vector3 GetPointOnRectEdge(RectTransform rect, Vector2 dir)
		{
			return default(Vector3);
		}

		[Token(Token = "0x600044B")]
		[Address(RVA = "0x1835B1C", Offset = "0x1835B1C", Length = "0xB8")]
		private void Navigate(AxisEventData eventData, Selectable sel)
		{
		}

		[Token(Token = "0x600044C")]
		[Address(RVA = "0x18303AC", Offset = "0x18303AC", Length = "0xD8")]
		public virtual Selectable FindSelectableOnLeft()
		{
			return null;
		}

		[Token(Token = "0x600044D")]
		[Address(RVA = "0x18304A8", Offset = "0x18304A8", Length = "0xD8")]
		public virtual Selectable FindSelectableOnRight()
		{
			return null;
		}

		[Token(Token = "0x600044E")]
		[Address(RVA = "0x18305A4", Offset = "0x18305A4", Length = "0xD8")]
		public virtual Selectable FindSelectableOnUp()
		{
			return null;
		}

		[Token(Token = "0x600044F")]
		[Address(RVA = "0x18306A0", Offset = "0x18306A0", Length = "0xD8")]
		public virtual Selectable FindSelectableOnDown()
		{
			return null;
		}

		[Token(Token = "0x6000450")]
		[Address(RVA = "0x18302FC", Offset = "0x18302FC", Length = "0x8C")]
		public virtual void OnMove(AxisEventData eventData)
		{
		}

		[Token(Token = "0x6000451")]
		[Address(RVA = "0x1834F34", Offset = "0x1834F34", Length = "0x110")]
		private void StartColorTween(Color targetColor, bool instant)
		{
		}

		[Token(Token = "0x6000452")]
		[Address(RVA = "0x1835044", Offset = "0x1835044", Length = "0xA8")]
		private void DoSpriteSwap(Sprite newSprite)
		{
		}

		[Token(Token = "0x6000453")]
		[Address(RVA = "0x18350EC", Offset = "0x18350EC", Length = "0x188")]
		private void TriggerAnimation(string triggername)
		{
		}

		[Token(Token = "0x6000454")]
		[Address(RVA = "0x1835BD4", Offset = "0x1835BD4", Length = "0x5C")]
		protected bool IsHighlighted()
		{
			return false;
		}

		[Token(Token = "0x6000455")]
		[Address(RVA = "0x1834E78", Offset = "0x1834E78", Length = "0x4C")]
		protected bool IsPressed()
		{
			return false;
		}

		[Token(Token = "0x6000456")]
		[Address(RVA = "0x1835C30", Offset = "0x1835C30", Length = "0x98")]
		private void EvaluateAndTransitionToSelectionState()
		{
		}

		[Token(Token = "0x6000457")]
		[Address(RVA = "0x182FE58", Offset = "0x182FE58", Length = "0x130")]
		public virtual void OnPointerDown(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000458")]
		[Address(RVA = "0x183008C", Offset = "0x183008C", Length = "0x28")]
		public virtual void OnPointerUp(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000459")]
		[Address(RVA = "0x1835CC8", Offset = "0x1835CC8", Length = "0xC")]
		public virtual void OnPointerEnter(PointerEventData eventData)
		{
		}

		[Token(Token = "0x600045A")]
		[Address(RVA = "0x1835CD4", Offset = "0x1835CD4", Length = "0x8")]
		public virtual void OnPointerExit(PointerEventData eventData)
		{
		}

		[Token(Token = "0x600045B")]
		[Address(RVA = "0x1835CDC", Offset = "0x1835CDC", Length = "0xC")]
		public virtual void OnSelect(BaseEventData eventData)
		{
		}

		[Token(Token = "0x600045C")]
		[Address(RVA = "0x1835CE8", Offset = "0x1835CE8", Length = "0x8")]
		public virtual void OnDeselect(BaseEventData eventData)
		{
		}

		[Token(Token = "0x600045D")]
		[Address(RVA = "0x1835CF0", Offset = "0x1835CF0", Length = "0x104")]
		public virtual void Select()
		{
		}
	}
}
