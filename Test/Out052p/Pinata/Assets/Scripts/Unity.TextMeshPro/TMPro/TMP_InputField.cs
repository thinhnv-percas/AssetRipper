using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace TMPro
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x7481B8", Offset = "0x7481B8")]
	[Token(Token = "0x200002A")]
	public class TMP_InputField : Selectable, IUpdateSelectedHandler, IEventSystemHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler, ISubmitHandler, ICanvasElement, ILayoutElement, IScrollHandler
	{
		[Token(Token = "0x2000081")]
		public enum ContentType
		{
			[Token(Token = "0x40004B1")]
			Standard = 0,
			[Token(Token = "0x40004B2")]
			Autocorrected = 1,
			[Token(Token = "0x40004B3")]
			IntegerNumber = 2,
			[Token(Token = "0x40004B4")]
			DecimalNumber = 3,
			[Token(Token = "0x40004B5")]
			Alphanumeric = 4,
			[Token(Token = "0x40004B6")]
			Name = 5,
			[Token(Token = "0x40004B7")]
			EmailAddress = 6,
			[Token(Token = "0x40004B8")]
			Password = 7,
			[Token(Token = "0x40004B9")]
			Pin = 8,
			[Token(Token = "0x40004BA")]
			Custom = 9
		}

		[Token(Token = "0x2000082")]
		public enum InputType
		{
			[Token(Token = "0x40004BC")]
			Standard = 0,
			[Token(Token = "0x40004BD")]
			AutoCorrect = 1,
			[Token(Token = "0x40004BE")]
			Password = 2
		}

		[Token(Token = "0x2000083")]
		public enum CharacterValidation
		{
			[Token(Token = "0x40004C0")]
			None = 0,
			[Token(Token = "0x40004C1")]
			Digit = 1,
			[Token(Token = "0x40004C2")]
			Integer = 2,
			[Token(Token = "0x40004C3")]
			Decimal = 3,
			[Token(Token = "0x40004C4")]
			Alphanumeric = 4,
			[Token(Token = "0x40004C5")]
			Name = 5,
			[Token(Token = "0x40004C6")]
			Regex = 6,
			[Token(Token = "0x40004C7")]
			EmailAddress = 7,
			[Token(Token = "0x40004C8")]
			CustomValidator = 8
		}

		[Token(Token = "0x2000084")]
		public enum LineType
		{
			[Token(Token = "0x40004CA")]
			SingleLine = 0,
			[Token(Token = "0x40004CB")]
			MultiLineSubmit = 1,
			[Token(Token = "0x40004CC")]
			MultiLineNewline = 2
		}

		[Token(Token = "0x2000085")]
		public delegate char OnValidateInput(string text, int charIndex, char addedChar);

		[Serializable]
		[Token(Token = "0x2000086")]
		public class SubmitEvent : UnityEvent<string>
		{
			[Token(Token = "0x6000580")]
			[Address(RVA = "0x935264", Offset = "0x935264", Length = "0x50")]
			public SubmitEvent()
			{
			}
		}

		[Serializable]
		[Token(Token = "0x2000087")]
		public class OnChangeEvent : UnityEvent<string>
		{
			[Token(Token = "0x6000581")]
			[Address(RVA = "0x934CBC", Offset = "0x934CBC", Length = "0x50")]
			public OnChangeEvent()
			{
			}
		}

		[Serializable]
		[Token(Token = "0x2000088")]
		public class SelectionEvent : UnityEvent<string>
		{
			[Token(Token = "0x6000582")]
			[Address(RVA = "0x935214", Offset = "0x935214", Length = "0x50")]
			public SelectionEvent()
			{
			}
		}

		[Serializable]
		[Token(Token = "0x2000089")]
		public class TextSelectionEvent : UnityEvent<string, int, int>
		{
			[Token(Token = "0x6000583")]
			[Address(RVA = "0x9352B4", Offset = "0x9352B4", Length = "0x50")]
			public TextSelectionEvent()
			{
			}
		}

		[Serializable]
		[Token(Token = "0x200008A")]
		public class TouchScreenKeyboardEvent : UnityEvent<TouchScreenKeyboard.Status>
		{
			[Token(Token = "0x6000584")]
			[Address(RVA = "0x935304", Offset = "0x935304", Length = "0x50")]
			public TouchScreenKeyboardEvent()
			{
			}
		}

		[Token(Token = "0x200008B")]
		protected enum EditState
		{
			[Token(Token = "0x40004CE")]
			Continue = 0,
			[Token(Token = "0x40004CF")]
			Finish = 1
		}

		[Token(Token = "0x4000124")]
		[FieldOffset(Offset = "0xE8")]
		protected TouchScreenKeyboard m_SoftKeyboard;

		[Token(Token = "0x4000125")]
		private static readonly char[] kSeparators;

		[SerializeField]
		[Token(Token = "0x4000126")]
		[FieldOffset(Offset = "0xF0")]
		protected RectTransform m_TextViewport;

		[SerializeField]
		[Token(Token = "0x4000127")]
		[FieldOffset(Offset = "0xF8")]
		protected TMP_Text m_TextComponent;

		[Token(Token = "0x4000128")]
		[FieldOffset(Offset = "0x100")]
		protected RectTransform m_TextComponentRectTransform;

		[SerializeField]
		[Token(Token = "0x4000129")]
		[FieldOffset(Offset = "0x108")]
		protected Graphic m_Placeholder;

		[SerializeField]
		[Token(Token = "0x400012A")]
		[FieldOffset(Offset = "0x110")]
		protected Scrollbar m_VerticalScrollbar;

		[SerializeField]
		[Token(Token = "0x400012B")]
		[FieldOffset(Offset = "0x118")]
		protected TMP_ScrollbarEventHandler m_VerticalScrollbarEventHandler;

		[Token(Token = "0x400012C")]
		[FieldOffset(Offset = "0x120")]
		private bool m_IsDrivenByLayoutComponents;

		[Token(Token = "0x400012D")]
		[FieldOffset(Offset = "0x124")]
		private float m_ScrollPosition;

		[SerializeField]
		[Token(Token = "0x400012E")]
		[FieldOffset(Offset = "0x128")]
		protected float m_ScrollSensitivity;

		[SerializeField]
		[Token(Token = "0x400012F")]
		[FieldOffset(Offset = "0x12C")]
		private ContentType m_ContentType;

		[SerializeField]
		[Token(Token = "0x4000130")]
		[FieldOffset(Offset = "0x130")]
		private InputType m_InputType;

		[SerializeField]
		[Token(Token = "0x4000131")]
		[FieldOffset(Offset = "0x134")]
		private char m_AsteriskChar;

		[SerializeField]
		[Token(Token = "0x4000132")]
		[FieldOffset(Offset = "0x138")]
		private TouchScreenKeyboardType m_KeyboardType;

		[SerializeField]
		[Token(Token = "0x4000133")]
		[FieldOffset(Offset = "0x13C")]
		private LineType m_LineType;

		[SerializeField]
		[Token(Token = "0x4000134")]
		[FieldOffset(Offset = "0x140")]
		private bool m_HideMobileInput;

		[SerializeField]
		[Token(Token = "0x4000135")]
		[FieldOffset(Offset = "0x141")]
		private bool m_HideSoftKeyboard;

		[SerializeField]
		[Token(Token = "0x4000136")]
		[FieldOffset(Offset = "0x144")]
		private CharacterValidation m_CharacterValidation;

		[SerializeField]
		[Token(Token = "0x4000137")]
		[FieldOffset(Offset = "0x148")]
		private string m_RegexValue;

		[SerializeField]
		[Token(Token = "0x4000138")]
		[FieldOffset(Offset = "0x150")]
		private float m_GlobalPointSize;

		[SerializeField]
		[Token(Token = "0x4000139")]
		[FieldOffset(Offset = "0x154")]
		private int m_CharacterLimit;

		[SerializeField]
		[Token(Token = "0x400013A")]
		[FieldOffset(Offset = "0x158")]
		private SubmitEvent m_OnEndEdit;

		[SerializeField]
		[Token(Token = "0x400013B")]
		[FieldOffset(Offset = "0x160")]
		private SubmitEvent m_OnSubmit;

		[SerializeField]
		[Token(Token = "0x400013C")]
		[FieldOffset(Offset = "0x168")]
		private SelectionEvent m_OnSelect;

		[SerializeField]
		[Token(Token = "0x400013D")]
		[FieldOffset(Offset = "0x170")]
		private SelectionEvent m_OnDeselect;

		[SerializeField]
		[Token(Token = "0x400013E")]
		[FieldOffset(Offset = "0x178")]
		private TextSelectionEvent m_OnTextSelection;

		[SerializeField]
		[Token(Token = "0x400013F")]
		[FieldOffset(Offset = "0x180")]
		private TextSelectionEvent m_OnEndTextSelection;

		[SerializeField]
		[Token(Token = "0x4000140")]
		[FieldOffset(Offset = "0x188")]
		private OnChangeEvent m_OnValueChanged;

		[SerializeField]
		[Token(Token = "0x4000141")]
		[FieldOffset(Offset = "0x190")]
		private TouchScreenKeyboardEvent m_OnTouchScreenKeyboardStatusChanged;

		[SerializeField]
		[Token(Token = "0x4000142")]
		[FieldOffset(Offset = "0x198")]
		private OnValidateInput m_OnValidateInput;

		[SerializeField]
		[Token(Token = "0x4000143")]
		[FieldOffset(Offset = "0x1A0")]
		private Color m_CaretColor;

		[SerializeField]
		[Token(Token = "0x4000144")]
		[FieldOffset(Offset = "0x1B0")]
		private bool m_CustomCaretColor;

		[SerializeField]
		[Token(Token = "0x4000145")]
		[FieldOffset(Offset = "0x1B4")]
		private Color m_SelectionColor;

		[SerializeField]
		[AttributeAttribute(Type = typeof(TextAreaAttribute), RVA = "0x748B0C", Offset = "0x748B0C")]
		[Token(Token = "0x4000146")]
		[FieldOffset(Offset = "0x1C8")]
		protected string m_Text;

		[SerializeField]
		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x748B4C", Offset = "0x748B4C")]
		[Token(Token = "0x4000147")]
		[FieldOffset(Offset = "0x1D0")]
		private float m_CaretBlinkRate;

		[SerializeField]
		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x748B8C", Offset = "0x748B8C")]
		[Token(Token = "0x4000148")]
		[FieldOffset(Offset = "0x1D4")]
		private int m_CaretWidth;

		[SerializeField]
		[Token(Token = "0x4000149")]
		[FieldOffset(Offset = "0x1D8")]
		private bool m_ReadOnly;

		[SerializeField]
		[Token(Token = "0x400014A")]
		[FieldOffset(Offset = "0x1D9")]
		private bool m_RichText;

		[Token(Token = "0x400014B")]
		[FieldOffset(Offset = "0x1DC")]
		protected int m_StringPosition;

		[Token(Token = "0x400014C")]
		[FieldOffset(Offset = "0x1E0")]
		protected int m_StringSelectPosition;

		[Token(Token = "0x400014D")]
		[FieldOffset(Offset = "0x1E4")]
		protected int m_CaretPosition;

		[Token(Token = "0x400014E")]
		[FieldOffset(Offset = "0x1E8")]
		protected int m_CaretSelectPosition;

		[Token(Token = "0x400014F")]
		[FieldOffset(Offset = "0x1F0")]
		private RectTransform caretRectTrans;

		[Token(Token = "0x4000150")]
		[FieldOffset(Offset = "0x1F8")]
		protected UIVertex[] m_CursorVerts;

		[Token(Token = "0x4000151")]
		[FieldOffset(Offset = "0x200")]
		private CanvasRenderer m_CachedInputRenderer;

		[Token(Token = "0x4000152")]
		[FieldOffset(Offset = "0x208")]
		private Vector2 m_LastPosition;

		[NonSerialized]
		[Token(Token = "0x4000153")]
		[FieldOffset(Offset = "0x210")]
		protected Mesh m_Mesh;

		[Token(Token = "0x4000154")]
		[FieldOffset(Offset = "0x218")]
		private bool m_AllowInput;

		[Token(Token = "0x4000155")]
		[FieldOffset(Offset = "0x219")]
		private bool m_ShouldActivateNextUpdate;

		[Token(Token = "0x4000156")]
		[FieldOffset(Offset = "0x21A")]
		private bool m_UpdateDrag;

		[Token(Token = "0x4000157")]
		[FieldOffset(Offset = "0x21B")]
		private bool m_DragPositionOutOfBounds;

		[Token(Token = "0x4000158")]
		private const float kHScrollSpeed = 0.05f;

		[Token(Token = "0x4000159")]
		private const float kVScrollSpeed = 0.1f;

		[Token(Token = "0x400015A")]
		[FieldOffset(Offset = "0x21C")]
		protected bool m_CaretVisible;

		[Token(Token = "0x400015B")]
		[FieldOffset(Offset = "0x220")]
		private Coroutine m_BlinkCoroutine;

		[Token(Token = "0x400015C")]
		[FieldOffset(Offset = "0x228")]
		private float m_BlinkStartTime;

		[Token(Token = "0x400015D")]
		[FieldOffset(Offset = "0x230")]
		private Coroutine m_DragCoroutine;

		[Token(Token = "0x400015E")]
		[FieldOffset(Offset = "0x238")]
		private string m_OriginalText;

		[Token(Token = "0x400015F")]
		[FieldOffset(Offset = "0x240")]
		private bool m_WasCanceled;

		[Token(Token = "0x4000160")]
		[FieldOffset(Offset = "0x241")]
		private bool m_HasDoneFocusTransition;

		[Token(Token = "0x4000161")]
		[FieldOffset(Offset = "0x248")]
		private WaitForSecondsRealtime m_WaitForSecondsRealtime;

		[Token(Token = "0x4000162")]
		[FieldOffset(Offset = "0x250")]
		private bool m_PreventCallback;

		[Token(Token = "0x4000163")]
		[FieldOffset(Offset = "0x251")]
		private bool m_TouchKeyboardAllowsInPlaceEditing;

		[Token(Token = "0x4000164")]
		[FieldOffset(Offset = "0x252")]
		private bool m_IsTextComponentUpdateRequired;

		[Token(Token = "0x4000165")]
		[FieldOffset(Offset = "0x253")]
		private bool m_IsScrollbarUpdateRequired;

		[Token(Token = "0x4000166")]
		[FieldOffset(Offset = "0x254")]
		private bool m_IsUpdatingScrollbarValues;

		[Token(Token = "0x4000167")]
		[FieldOffset(Offset = "0x255")]
		private bool m_isLastKeyBackspace;

		[Token(Token = "0x4000168")]
		[FieldOffset(Offset = "0x258")]
		private float m_PointerDownClickStartTime;

		[Token(Token = "0x4000169")]
		[FieldOffset(Offset = "0x25C")]
		private float m_KeyDownStartTime;

		[Token(Token = "0x400016A")]
		[FieldOffset(Offset = "0x260")]
		private float m_DoubleClickDelay;

		[Token(Token = "0x400016B")]
		private const string kEmailSpecialCharacters = "!#$%&'*+-/=?^_`{|}~";

		[SerializeField]
		[Token(Token = "0x400016C")]
		[FieldOffset(Offset = "0x268")]
		protected TMP_FontAsset m_GlobalFontAsset;

		[SerializeField]
		[Token(Token = "0x400016D")]
		[FieldOffset(Offset = "0x270")]
		protected bool m_OnFocusSelectAll;

		[Token(Token = "0x400016E")]
		[FieldOffset(Offset = "0x271")]
		protected bool m_isSelectAll;

		[SerializeField]
		[Token(Token = "0x400016F")]
		[FieldOffset(Offset = "0x272")]
		protected bool m_ResetOnDeActivation;

		[Token(Token = "0x4000170")]
		[FieldOffset(Offset = "0x273")]
		private bool m_SelectionStillActive;

		[Token(Token = "0x4000171")]
		[FieldOffset(Offset = "0x274")]
		private bool m_ReleaseSelection;

		[Token(Token = "0x4000172")]
		[FieldOffset(Offset = "0x278")]
		private GameObject m_SelectedObject;

		[SerializeField]
		[Token(Token = "0x4000173")]
		[FieldOffset(Offset = "0x280")]
		private bool m_RestoreOriginalTextOnEscape;

		[SerializeField]
		[Token(Token = "0x4000174")]
		[FieldOffset(Offset = "0x281")]
		protected bool m_isRichTextEditingAllowed;

		[SerializeField]
		[Token(Token = "0x4000175")]
		[FieldOffset(Offset = "0x284")]
		protected int m_LineLimit;

		[SerializeField]
		[Token(Token = "0x4000176")]
		[FieldOffset(Offset = "0x288")]
		protected TMP_InputValidator m_InputValidator;

		[Token(Token = "0x4000177")]
		[FieldOffset(Offset = "0x290")]
		private bool m_isSelected;

		[Token(Token = "0x4000178")]
		[FieldOffset(Offset = "0x291")]
		private bool m_IsStringPositionDirty;

		[Token(Token = "0x4000179")]
		[FieldOffset(Offset = "0x292")]
		private bool m_IsCaretPositionDirty;

		[Token(Token = "0x400017A")]
		[FieldOffset(Offset = "0x293")]
		private bool m_forceRectTransformAdjustment;

		[Token(Token = "0x400017B")]
		[FieldOffset(Offset = "0x298")]
		private Event m_ProcessingEvent;

		[Token(Token = "0x17000058")]
		private BaseInput inputSystem
		{
			[Token(Token = "0x60001D3")]
			[Address(RVA = "0x928048", Offset = "0x928048", Length = "0x140")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000059")]
		private string compositionString
		{
			[Token(Token = "0x60001D4")]
			[Address(RVA = "0x928188", Offset = "0x928188", Length = "0xA4")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700005A")]
		protected Mesh mesh
		{
			[Token(Token = "0x60001D6")]
			[Address(RVA = "0x928570", Offset = "0x928570", Length = "0xA4")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700005B")]
		public bool shouldHideMobileInput
		{
			[Token(Token = "0x60001D7")]
			[Address(RVA = "0x928614", Offset = "0x928614", Length = "0x54")]
			get
			{
				return false;
			}
			[Token(Token = "0x60001D8")]
			[Address(RVA = "0x928668", Offset = "0x928668", Length = "0xA0")]
			set
			{
			}
		}

		[Token(Token = "0x1700005C")]
		public bool shouldHideSoftKeyboard
		{
			[Token(Token = "0x60001D9")]
			[Address(RVA = "0x928708", Offset = "0x928708", Length = "0x74")]
			get
			{
				return false;
			}
			[Token(Token = "0x60001DA")]
			[Address(RVA = "0x92877C", Offset = "0x92877C", Length = "0xFC")]
			set
			{
			}
		}

		[Token(Token = "0x1700005D")]
		public string text
		{
			[Token(Token = "0x60001DC")]
			[Address(RVA = "0x9288B4", Offset = "0x9288B4", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60001DD")]
			[Address(RVA = "0x9288BC", Offset = "0x9288BC", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700005E")]
		public bool isFocused
		{
			[Token(Token = "0x60001E0")]
			[Address(RVA = "0x928F04", Offset = "0x928F04", Length = "0x8")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x1700005F")]
		public float caretBlinkRate
		{
			[Token(Token = "0x60001E1")]
			[Address(RVA = "0x928F0C", Offset = "0x928F0C", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60001E2")]
			[Address(RVA = "0x928F14", Offset = "0x928F14", Length = "0x84")]
			set
			{
			}
		}

		[Token(Token = "0x17000060")]
		public int caretWidth
		{
			[Token(Token = "0x60001E3")]
			[Address(RVA = "0x928FF8", Offset = "0x928FF8", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x60001E4")]
			[Address(RVA = "0x929000", Offset = "0x929000", Length = "0x7C")]
			set
			{
			}
		}

		[Token(Token = "0x17000061")]
		public RectTransform textViewport
		{
			[Token(Token = "0x60001E5")]
			[Address(RVA = "0x9290E4", Offset = "0x9290E4", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60001E6")]
			[Address(RVA = "0x91D490", Offset = "0x91D490", Length = "0x60")]
			set
			{
			}
		}

		[Token(Token = "0x17000062")]
		public TMP_Text textComponent
		{
			[Token(Token = "0x60001E7")]
			[Address(RVA = "0x9290EC", Offset = "0x9290EC", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60001E8")]
			[Address(RVA = "0x91D4F0", Offset = "0x91D4F0", Length = "0x7C")]
			set
			{
			}
		}

		[Token(Token = "0x17000063")]
		public Graphic placeholder
		{
			[Token(Token = "0x60001E9")]
			[Address(RVA = "0x9290F4", Offset = "0x9290F4", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60001EA")]
			[Address(RVA = "0x91D56C", Offset = "0x91D56C", Length = "0x60")]
			set
			{
			}
		}

		[Token(Token = "0x17000064")]
		public Scrollbar verticalScrollbar
		{
			[Token(Token = "0x60001EB")]
			[Address(RVA = "0x9290FC", Offset = "0x9290FC", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60001EC")]
			[Address(RVA = "0x929104", Offset = "0x929104", Length = "0x1A4")]
			set
			{
			}
		}

		[Token(Token = "0x17000065")]
		public float scrollSensitivity
		{
			[Token(Token = "0x60001ED")]
			[Address(RVA = "0x9292A8", Offset = "0x9292A8", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60001EE")]
			[Address(RVA = "0x9292B0", Offset = "0x9292B0", Length = "0x7C")]
			set
			{
			}
		}

		[Token(Token = "0x17000066")]
		public Color caretColor
		{
			[Token(Token = "0x60001EF")]
			[Address(RVA = "0x92932C", Offset = "0x92932C", Length = "0x40")]
			get
			{
				return default(Color);
			}
			[Token(Token = "0x60001F0")]
			[Address(RVA = "0x92936C", Offset = "0x92936C", Length = "0x38")]
			set
			{
			}
		}

		[Token(Token = "0x17000067")]
		public bool customCaretColor
		{
			[Token(Token = "0x60001F1")]
			[Address(RVA = "0x9293A4", Offset = "0x9293A4", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60001F2")]
			[Address(RVA = "0x9293AC", Offset = "0x9293AC", Length = "0x24")]
			set
			{
			}
		}

		[Token(Token = "0x17000068")]
		public Color selectionColor
		{
			[Token(Token = "0x60001F3")]
			[Address(RVA = "0x9293D0", Offset = "0x9293D0", Length = "0x14")]
			get
			{
				return default(Color);
			}
			[Token(Token = "0x60001F4")]
			[Address(RVA = "0x9293E4", Offset = "0x9293E4", Length = "0x38")]
			set
			{
			}
		}

		[Token(Token = "0x17000069")]
		public SubmitEvent onEndEdit
		{
			[Token(Token = "0x60001F5")]
			[Address(RVA = "0x92941C", Offset = "0x92941C", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60001F6")]
			[Address(RVA = "0x929424", Offset = "0x929424", Length = "0x60")]
			set
			{
			}
		}

		[Token(Token = "0x1700006A")]
		public SubmitEvent onSubmit
		{
			[Token(Token = "0x60001F7")]
			[Address(RVA = "0x929484", Offset = "0x929484", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60001F8")]
			[Address(RVA = "0x92948C", Offset = "0x92948C", Length = "0x60")]
			set
			{
			}
		}

		[Token(Token = "0x1700006B")]
		public SelectionEvent onSelect
		{
			[Token(Token = "0x60001F9")]
			[Address(RVA = "0x9294EC", Offset = "0x9294EC", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60001FA")]
			[Address(RVA = "0x9294F4", Offset = "0x9294F4", Length = "0x60")]
			set
			{
			}
		}

		[Token(Token = "0x1700006C")]
		public SelectionEvent onDeselect
		{
			[Token(Token = "0x60001FB")]
			[Address(RVA = "0x929554", Offset = "0x929554", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60001FC")]
			[Address(RVA = "0x92955C", Offset = "0x92955C", Length = "0x60")]
			set
			{
			}
		}

		[Token(Token = "0x1700006D")]
		public TextSelectionEvent onTextSelection
		{
			[Token(Token = "0x60001FD")]
			[Address(RVA = "0x9295BC", Offset = "0x9295BC", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60001FE")]
			[Address(RVA = "0x9295C4", Offset = "0x9295C4", Length = "0x60")]
			set
			{
			}
		}

		[Token(Token = "0x1700006E")]
		public TextSelectionEvent onEndTextSelection
		{
			[Token(Token = "0x60001FF")]
			[Address(RVA = "0x929624", Offset = "0x929624", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000200")]
			[Address(RVA = "0x92962C", Offset = "0x92962C", Length = "0x60")]
			set
			{
			}
		}

		[Token(Token = "0x1700006F")]
		public OnChangeEvent onValueChanged
		{
			[Token(Token = "0x6000201")]
			[Address(RVA = "0x92968C", Offset = "0x92968C", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000202")]
			[Address(RVA = "0x929694", Offset = "0x929694", Length = "0x60")]
			set
			{
			}
		}

		[Token(Token = "0x17000070")]
		public TouchScreenKeyboardEvent onTouchScreenKeyboardStatusChanged
		{
			[Token(Token = "0x6000203")]
			[Address(RVA = "0x9296F4", Offset = "0x9296F4", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000204")]
			[Address(RVA = "0x9296FC", Offset = "0x9296FC", Length = "0x60")]
			set
			{
			}
		}

		[Token(Token = "0x17000071")]
		public OnValidateInput onValidateInput
		{
			[Token(Token = "0x6000205")]
			[Address(RVA = "0x92975C", Offset = "0x92975C", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000206")]
			[Address(RVA = "0x929764", Offset = "0x929764", Length = "0x60")]
			set
			{
			}
		}

		[Token(Token = "0x17000072")]
		public int characterLimit
		{
			[Token(Token = "0x6000207")]
			[Address(RVA = "0x9297C4", Offset = "0x9297C4", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x6000208")]
			[Address(RVA = "0x9297CC", Offset = "0x9297CC", Length = "0xC4")]
			set
			{
			}
		}

		[Token(Token = "0x17000073")]
		public float pointSize
		{
			[Token(Token = "0x6000209")]
			[Address(RVA = "0x929890", Offset = "0x929890", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600020A")]
			[Address(RVA = "0x929898", Offset = "0x929898", Length = "0xB8")]
			set
			{
			}
		}

		[Token(Token = "0x17000074")]
		public TMP_FontAsset fontAsset
		{
			[Token(Token = "0x600020B")]
			[Address(RVA = "0x929A40", Offset = "0x929A40", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600020C")]
			[Address(RVA = "0x91D5CC", Offset = "0x91D5CC", Length = "0x88")]
			set
			{
			}
		}

		[Token(Token = "0x17000075")]
		public bool onFocusSelectAll
		{
			[Token(Token = "0x600020D")]
			[Address(RVA = "0x929B38", Offset = "0x929B38", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x600020E")]
			[Address(RVA = "0x929B40", Offset = "0x929B40", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x17000076")]
		public bool resetOnDeActivation
		{
			[Token(Token = "0x600020F")]
			[Address(RVA = "0x929B4C", Offset = "0x929B4C", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000210")]
			[Address(RVA = "0x929B54", Offset = "0x929B54", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x17000077")]
		public bool restoreOriginalTextOnEscape
		{
			[Token(Token = "0x6000211")]
			[Address(RVA = "0x929B60", Offset = "0x929B60", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000212")]
			[Address(RVA = "0x929B68", Offset = "0x929B68", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x17000078")]
		public bool isRichTextEditingAllowed
		{
			[Token(Token = "0x6000213")]
			[Address(RVA = "0x929B74", Offset = "0x929B74", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000214")]
			[Address(RVA = "0x929B7C", Offset = "0x929B7C", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x17000079")]
		public ContentType contentType
		{
			[Token(Token = "0x6000215")]
			[Address(RVA = "0x929B88", Offset = "0x929B88", Length = "0x8")]
			get
			{
				return ContentType.Standard;
			}
			[Token(Token = "0x6000216")]
			[Address(RVA = "0x929B90", Offset = "0x929B90", Length = "0x7C")]
			set
			{
			}
		}

		[Token(Token = "0x1700007A")]
		public LineType lineType
		{
			[Token(Token = "0x6000217")]
			[Address(RVA = "0x929CD8", Offset = "0x929CD8", Length = "0x8")]
			get
			{
				return LineType.SingleLine;
			}
			[Token(Token = "0x6000218")]
			[Address(RVA = "0x929CE0", Offset = "0x929CE0", Length = "0xCC")]
			set
			{
			}
		}

		[Token(Token = "0x1700007B")]
		public int lineLimit
		{
			[Token(Token = "0x6000219")]
			[Address(RVA = "0x929E24", Offset = "0x929E24", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x600021A")]
			[Address(RVA = "0x929E2C", Offset = "0x929E2C", Length = "0x80")]
			set
			{
			}
		}

		[Token(Token = "0x1700007C")]
		public InputType inputType
		{
			[Token(Token = "0x600021B")]
			[Address(RVA = "0x929EAC", Offset = "0x929EAC", Length = "0x8")]
			get
			{
				return InputType.Standard;
			}
			[Token(Token = "0x600021C")]
			[Address(RVA = "0x929EB4", Offset = "0x929EB4", Length = "0x8C")]
			set
			{
			}
		}

		[Token(Token = "0x1700007D")]
		public TouchScreenKeyboardType keyboardType
		{
			[Token(Token = "0x600021D")]
			[Address(RVA = "0x929F58", Offset = "0x929F58", Length = "0x8")]
			get
			{
				return TouchScreenKeyboardType.Default;
			}
			[Token(Token = "0x600021E")]
			[Address(RVA = "0x929F60", Offset = "0x929F60", Length = "0x8C")]
			set
			{
			}
		}

		[Token(Token = "0x1700007E")]
		public CharacterValidation characterValidation
		{
			[Token(Token = "0x600021F")]
			[Address(RVA = "0x929FEC", Offset = "0x929FEC", Length = "0x8")]
			get
			{
				return CharacterValidation.None;
			}
			[Token(Token = "0x6000220")]
			[Address(RVA = "0x929FF4", Offset = "0x929FF4", Length = "0x8C")]
			set
			{
			}
		}

		[Token(Token = "0x1700007F")]
		public TMP_InputValidator inputValidator
		{
			[Token(Token = "0x6000221")]
			[Address(RVA = "0x92A080", Offset = "0x92A080", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000222")]
			[Address(RVA = "0x92A088", Offset = "0x92A088", Length = "0x8C")]
			set
			{
			}
		}

		[Token(Token = "0x17000080")]
		public bool readOnly
		{
			[Token(Token = "0x6000223")]
			[Address(RVA = "0x92A12C", Offset = "0x92A12C", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000224")]
			[Address(RVA = "0x92A134", Offset = "0x92A134", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x17000081")]
		public bool richText
		{
			[Token(Token = "0x6000225")]
			[Address(RVA = "0x92A140", Offset = "0x92A140", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000226")]
			[Address(RVA = "0x92A148", Offset = "0x92A148", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x17000082")]
		public bool multiLine
		{
			[Token(Token = "0x6000227")]
			[Address(RVA = "0x92A1EC", Offset = "0x92A1EC", Length = "0x14")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x17000083")]
		public char asteriskChar
		{
			[Token(Token = "0x6000228")]
			[Address(RVA = "0x92A200", Offset = "0x92A200", Length = "0x8")]
			get
			{
				return '\0';
			}
			[Token(Token = "0x6000229")]
			[Address(RVA = "0x92A208", Offset = "0x92A208", Length = "0x7C")]
			set
			{
			}
		}

		[Token(Token = "0x17000084")]
		public bool wasCanceled
		{
			[Token(Token = "0x600022A")]
			[Address(RVA = "0x92A284", Offset = "0x92A284", Length = "0x8")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x17000085")]
		protected int caretPositionInternal
		{
			[Token(Token = "0x600022D")]
			[Address(RVA = "0x92A314", Offset = "0x92A314", Length = "0x30")]
			get
			{
				return 0;
			}
			[Token(Token = "0x600022E")]
			[Address(RVA = "0x92A344", Offset = "0x92A344", Length = "0x10")]
			set
			{
			}
		}

		[Token(Token = "0x17000086")]
		protected int stringPositionInternal
		{
			[Token(Token = "0x600022F")]
			[Address(RVA = "0x92A354", Offset = "0x92A354", Length = "0x30")]
			get
			{
				return 0;
			}
			[Token(Token = "0x6000230")]
			[Address(RVA = "0x92A384", Offset = "0x92A384", Length = "0x3C")]
			set
			{
			}
		}

		[Token(Token = "0x17000087")]
		protected int caretSelectPositionInternal
		{
			[Token(Token = "0x6000231")]
			[Address(RVA = "0x92A3C0", Offset = "0x92A3C0", Length = "0x30")]
			get
			{
				return 0;
			}
			[Token(Token = "0x6000232")]
			[Address(RVA = "0x92A3F0", Offset = "0x92A3F0", Length = "0x10")]
			set
			{
			}
		}

		[Token(Token = "0x17000088")]
		protected int stringSelectPositionInternal
		{
			[Token(Token = "0x6000233")]
			[Address(RVA = "0x92A400", Offset = "0x92A400", Length = "0x30")]
			get
			{
				return 0;
			}
			[Token(Token = "0x6000234")]
			[Address(RVA = "0x92A430", Offset = "0x92A430", Length = "0x3C")]
			set
			{
			}
		}

		[Token(Token = "0x17000089")]
		private bool hasSelection
		{
			[Token(Token = "0x6000235")]
			[Address(RVA = "0x92A46C", Offset = "0x92A46C", Length = "0x34")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x1700008A")]
		public int caretPosition
		{
			[Token(Token = "0x6000236")]
			[Address(RVA = "0x92A4A0", Offset = "0x92A4A0", Length = "0x4")]
			get
			{
				return 0;
			}
			[Token(Token = "0x6000237")]
			[Address(RVA = "0x92A4A4", Offset = "0x92A4A4", Length = "0x38")]
			set
			{
			}
		}

		[Token(Token = "0x1700008B")]
		public int selectionAnchorPosition
		{
			[Token(Token = "0x6000238")]
			[Address(RVA = "0x92A574", Offset = "0x92A574", Length = "0x4")]
			get
			{
				return 0;
			}
			[Token(Token = "0x6000239")]
			[Address(RVA = "0x92A4DC", Offset = "0x92A4DC", Length = "0x4C")]
			set
			{
			}
		}

		[Token(Token = "0x1700008C")]
		public int selectionFocusPosition
		{
			[Token(Token = "0x600023A")]
			[Address(RVA = "0x92A578", Offset = "0x92A578", Length = "0x4")]
			get
			{
				return 0;
			}
			[Token(Token = "0x600023B")]
			[Address(RVA = "0x92A528", Offset = "0x92A528", Length = "0x4C")]
			set
			{
			}
		}

		[Token(Token = "0x1700008D")]
		public int stringPosition
		{
			[Token(Token = "0x600023C")]
			[Address(RVA = "0x92A57C", Offset = "0x92A57C", Length = "0x4")]
			get
			{
				return 0;
			}
			[Token(Token = "0x600023D")]
			[Address(RVA = "0x92A580", Offset = "0x92A580", Length = "0x38")]
			set
			{
			}
		}

		[Token(Token = "0x1700008E")]
		public int selectionStringAnchorPosition
		{
			[Token(Token = "0x600023E")]
			[Address(RVA = "0x92A690", Offset = "0x92A690", Length = "0x4")]
			get
			{
				return 0;
			}
			[Token(Token = "0x600023F")]
			[Address(RVA = "0x92A5B8", Offset = "0x92A5B8", Length = "0x6C")]
			set
			{
			}
		}

		[Token(Token = "0x1700008F")]
		public int selectionStringFocusPosition
		{
			[Token(Token = "0x6000240")]
			[Address(RVA = "0x92A694", Offset = "0x92A694", Length = "0x4")]
			get
			{
				return 0;
			}
			[Token(Token = "0x6000241")]
			[Address(RVA = "0x92A624", Offset = "0x92A624", Length = "0x6C")]
			set
			{
			}
		}

		[Token(Token = "0x17000090")]
		private static string clipboard
		{
			[Token(Token = "0x600024E")]
			[Address(RVA = "0x92C034", Offset = "0x92C034", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600024F")]
			[Address(RVA = "0x92C03C", Offset = "0x92C03C", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000091")]
		public virtual float minWidth
		{
			[Token(Token = "0x60002A6")]
			[Address(RVA = "0x9335F8", Offset = "0x9335F8", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000092")]
		public virtual float preferredWidth
		{
			[Token(Token = "0x60002A7")]
			[Address(RVA = "0x933600", Offset = "0x933600", Length = "0xB4")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000093")]
		public virtual float flexibleWidth
		{
			[Token(Token = "0x60002A8")]
			[Address(RVA = "0x9336B4", Offset = "0x9336B4", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000094")]
		public virtual float minHeight
		{
			[Token(Token = "0x60002A9")]
			[Address(RVA = "0x9336BC", Offset = "0x9336BC", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000095")]
		public virtual float preferredHeight
		{
			[Token(Token = "0x60002AA")]
			[Address(RVA = "0x9336C4", Offset = "0x9336C4", Length = "0xA0")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000096")]
		public virtual float flexibleHeight
		{
			[Token(Token = "0x60002AB")]
			[Address(RVA = "0x933764", Offset = "0x933764", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000097")]
		public virtual int layoutPriority
		{
			[Token(Token = "0x60002AC")]
			[Address(RVA = "0x93376C", Offset = "0x93376C", Length = "0x8")]
			get
			{
				return 0;
			}
		}

		Transform ICanvasElement.transform
		{
			[Token(Token = "0x60002B0")]
			[Address(RVA = "0x9337F0", Offset = "0x9337F0", Length = "0x1008")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x60001D5")]
		[Address(RVA = "0x92822C", Offset = "0x92822C", Length = "0x294")]
		protected TMP_InputField()
		{
		}

		[Token(Token = "0x60001DB")]
		[Address(RVA = "0x928878", Offset = "0x928878", Length = "0x3C")]
		private bool isKeyboardUsingEvents()
		{
			return false;
		}

		[Token(Token = "0x60001DE")]
		[Address(RVA = "0x928A00", Offset = "0x928A00", Length = "0x8")]
		public void SetTextWithoutNotify(string input)
		{
		}

		[Token(Token = "0x60001DF")]
		[Address(RVA = "0x9288C4", Offset = "0x9288C4", Length = "0x13C")]
		private void SetText(string value, bool sendCallback = true)
		{
		}

		[Token(Token = "0x600022B")]
		[Address(RVA = "0x92A28C", Offset = "0x92A28C", Length = "0x3C")]
		protected void ClampStringPos(ref int pos)
		{
		}

		[Token(Token = "0x600022C")]
		[Address(RVA = "0x92A2C8", Offset = "0x92A2C8", Length = "0x4C")]
		protected void ClampCaretPos(ref int pos)
		{
		}

		[Token(Token = "0x6000242")]
		[Address(RVA = "0x92A698", Offset = "0x92A698", Length = "0x600")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x6000243")]
		[Address(RVA = "0x92B2E8", Offset = "0x92B2E8", Length = "0x2F8")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x6000244")]
		[Address(RVA = "0x92B77C", Offset = "0x92B77C", Length = "0xF8")]
		private void ON_TEXT_CHANGED(UnityEngine.Object obj)
		{
		}

		[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x7495D0", Offset = "0x7495D0")]
		[Token(Token = "0x6000245")]
		[Address(RVA = "0x92B8F8", Offset = "0x92B8F8", Length = "0x74")]
		private IEnumerator CaretBlink()
		{
			return null;
		}

		[Token(Token = "0x6000246")]
		[Address(RVA = "0x92B96C", Offset = "0x92B96C", Length = "0x48")]
		private void SetCaretVisible()
		{
		}

		[Token(Token = "0x6000247")]
		[Address(RVA = "0x928F98", Offset = "0x928F98", Length = "0x60")]
		private void SetCaretActive()
		{
		}

		[Token(Token = "0x6000248")]
		[Address(RVA = "0x92B9B4", Offset = "0x92B9B4", Length = "0x10")]
		protected void OnFocus()
		{
		}

		[Token(Token = "0x6000249")]
		[Address(RVA = "0x92B9C4", Offset = "0x92B9C4", Length = "0x58")]
		protected void SelectAll()
		{
		}

		[Token(Token = "0x600024A")]
		[Address(RVA = "0x92BA1C", Offset = "0x92BA1C", Length = "0x15C")]
		public void MoveTextEnd(bool shift)
		{
		}

		[Token(Token = "0x600024B")]
		[Address(RVA = "0x92BBEC", Offset = "0x92BBEC", Length = "0x128")]
		public void MoveTextStart(bool shift)
		{
		}

		[Token(Token = "0x600024C")]
		[Address(RVA = "0x92BD14", Offset = "0x92BD14", Length = "0x188")]
		public void MoveToEndOfLine(bool shift, bool ctrl)
		{
		}

		[Token(Token = "0x600024D")]
		[Address(RVA = "0x92BE9C", Offset = "0x92BE9C", Length = "0x198")]
		public void MoveToStartOfLine(bool shift, bool ctrl)
		{
		}

		[Token(Token = "0x6000250")]
		[Address(RVA = "0x92C044", Offset = "0x92C044", Length = "0x13C")]
		private bool InPlaceEditing()
		{
			return false;
		}

		[Token(Token = "0x6000251")]
		[Address(RVA = "0x92C180", Offset = "0x92C180", Length = "0x148")]
		private void UpdateStringPositionFromKeyboard()
		{
		}

		[Token(Token = "0x6000252")]
		[Address(RVA = "0x92C2C8", Offset = "0x92C2C8", Length = "0x5D8")]
		protected virtual void LateUpdate()
		{
		}

		[Token(Token = "0x6000253")]
		[Address(RVA = "0x92D594", Offset = "0x92D594", Length = "0x160")]
		private bool MayDrag(PointerEventData eventData)
		{
			return false;
		}

		[Token(Token = "0x6000254")]
		[Address(RVA = "0x92D6F4", Offset = "0x92D6F4", Length = "0x2C")]
		public virtual void OnBeginDrag(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000255")]
		[Address(RVA = "0x92D720", Offset = "0x92D720", Length = "0x2DC")]
		public virtual void OnDrag(PointerEventData eventData)
		{
		}

		[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x749634", Offset = "0x749634")]
		[Token(Token = "0x6000256")]
		[Address(RVA = "0x92D9FC", Offset = "0x92D9FC", Length = "0x80")]
		private IEnumerator MouseDragOutsideRect(PointerEventData eventData)
		{
			return null;
		}

		[Token(Token = "0x6000257")]
		[Address(RVA = "0x92DA7C", Offset = "0x92DA7C", Length = "0x28")]
		public virtual void OnEndDrag(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000258")]
		[Address(RVA = "0x92DAA4", Offset = "0x92DAA4", Length = "0x790")]
		public override void OnPointerDown(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000259")]
		[Address(RVA = "0x92E234", Offset = "0x92E234", Length = "0x450")]
		protected EditState KeyPressed(Event evt)
		{
			return EditState.Continue;
		}

		[Token(Token = "0x600025A")]
		[Address(RVA = "0x92F968", Offset = "0x92F968", Length = "0x10")]
		protected virtual bool IsValidChar(char c)
		{
			return false;
		}

		[Token(Token = "0x600025B")]
		[Address(RVA = "0x92F978", Offset = "0x92F978", Length = "0x4")]
		public void ProcessEvent(Event e)
		{
		}

		[Token(Token = "0x600025C")]
		[Address(RVA = "0x92F97C", Offset = "0x92F97C", Length = "0x148")]
		public virtual void OnUpdateSelected(BaseEventData eventData)
		{
		}

		[Token(Token = "0x600025D")]
		[Address(RVA = "0x92FB28", Offset = "0x92FB28", Length = "0x180")]
		public virtual void OnScroll(PointerEventData eventData)
		{
		}

		[Token(Token = "0x600025E")]
		[Address(RVA = "0x92EBF8", Offset = "0x92EBF8", Length = "0xB4")]
		private string GetSelectedString()
		{
			return null;
		}

		[Token(Token = "0x600025F")]
		[Address(RVA = "0x92FCA8", Offset = "0x92FCA8", Length = "0xD8")]
		private int FindNextWordBegin()
		{
			return 0;
		}

		[Token(Token = "0x6000260")]
		[Address(RVA = "0x92F560", Offset = "0x92F560", Length = "0x3D8")]
		private void MoveRight(bool shift, bool ctrl)
		{
		}

		[Token(Token = "0x6000261")]
		[Address(RVA = "0x92FD80", Offset = "0x92FD80", Length = "0xBC")]
		private int FindPrevWordBegin()
		{
			return 0;
		}

		[Token(Token = "0x6000262")]
		[Address(RVA = "0x92F184", Offset = "0x92F184", Length = "0x3DC")]
		private void MoveLeft(bool shift, bool ctrl)
		{
		}

		[Token(Token = "0x6000263")]
		[Address(RVA = "0x92FE3C", Offset = "0x92FE3C", Length = "0x21C")]
		private int LineUpCharacterPosition(int originalPos, bool goToFirstChar)
		{
			return 0;
		}

		[Token(Token = "0x6000264")]
		[Address(RVA = "0x930058", Offset = "0x930058", Length = "0x218")]
		private int LineDownCharacterPosition(int originalPos, bool goToLastChar)
		{
			return 0;
		}

		[Token(Token = "0x6000265")]
		[Address(RVA = "0x930270", Offset = "0x930270", Length = "0x2BC")]
		private int PageUpCharacterPosition(int originalPos, bool goToFirstChar)
		{
			return 0;
		}

		[Token(Token = "0x6000266")]
		[Address(RVA = "0x93052C", Offset = "0x93052C", Length = "0x2B8")]
		private int PageDownCharacterPosition(int originalPos, bool goToLastChar)
		{
			return 0;
		}

		[Token(Token = "0x6000267")]
		[Address(RVA = "0x92F944", Offset = "0x92F944", Length = "0xC")]
		private void MoveDown(bool shift)
		{
		}

		[Token(Token = "0x6000268")]
		[Address(RVA = "0x9307E4", Offset = "0x9307E4", Length = "0x20C")]
		private void MoveDown(bool shift, bool goToLastChar)
		{
		}

		[Token(Token = "0x6000269")]
		[Address(RVA = "0x92F938", Offset = "0x92F938", Length = "0xC")]
		private void MoveUp(bool shift)
		{
		}

		[Token(Token = "0x600026A")]
		[Address(RVA = "0x9309F0", Offset = "0x9309F0", Length = "0x1F8")]
		private void MoveUp(bool shift, bool goToFirstChar)
		{
		}

		[Token(Token = "0x600026B")]
		[Address(RVA = "0x92F950", Offset = "0x92F950", Length = "0xC")]
		private void MovePageUp(bool shift)
		{
		}

		[Token(Token = "0x600026C")]
		[Address(RVA = "0x930BE8", Offset = "0x930BE8", Length = "0x384")]
		private void MovePageUp(bool shift, bool goToFirstChar)
		{
		}

		[Token(Token = "0x600026D")]
		[Address(RVA = "0x92F95C", Offset = "0x92F95C", Length = "0xC")]
		private void MovePageDown(bool shift)
		{
		}

		[Token(Token = "0x600026E")]
		[Address(RVA = "0x930F6C", Offset = "0x930F6C", Length = "0x398")]
		private void MovePageDown(bool shift, bool goToLastChar)
		{
		}

		[Token(Token = "0x600026F")]
		[Address(RVA = "0x92ECAC", Offset = "0x92ECAC", Length = "0x488")]
		private void Delete()
		{
		}

		[Token(Token = "0x6000270")]
		[Address(RVA = "0x92E9F8", Offset = "0x92E9F8", Length = "0x200")]
		private void DeleteKey()
		{
		}

		[Token(Token = "0x6000271")]
		[Address(RVA = "0x92E684", Offset = "0x92E684", Length = "0x374")]
		private void Backspace()
		{
		}

		[Token(Token = "0x6000272")]
		[Address(RVA = "0x931304", Offset = "0x931304", Length = "0xC0")]
		protected virtual void Append(string input)
		{
		}

		[Token(Token = "0x6000273")]
		[Address(RVA = "0x9313C4", Offset = "0x9313C4", Length = "0x104")]
		protected virtual void Append(char input)
		{
		}

		[Token(Token = "0x6000274")]
		[Address(RVA = "0x9314C8", Offset = "0x9314C8", Length = "0x17C")]
		private void Insert(char c)
		{
		}

		[Token(Token = "0x6000275")]
		[Address(RVA = "0x92F134", Offset = "0x92F134", Length = "0x50")]
		private void UpdateTouchKeyboardFromEditChanges()
		{
		}

		[Token(Token = "0x6000276")]
		[Address(RVA = "0x92D570", Offset = "0x92D570", Length = "0x24")]
		private void SendOnValueChangedAndUpdateLabel()
		{
		}

		[Token(Token = "0x6000277")]
		[Address(RVA = "0x928EA0", Offset = "0x928EA0", Length = "0x64")]
		private void SendOnValueChanged()
		{
		}

		[Token(Token = "0x6000278")]
		[Address(RVA = "0x931644", Offset = "0x931644", Length = "0x64")]
		protected void SendOnEndEdit()
		{
		}

		[Token(Token = "0x6000279")]
		[Address(RVA = "0x92FAC4", Offset = "0x92FAC4", Length = "0x64")]
		protected void SendOnSubmit()
		{
		}

		[Token(Token = "0x600027A")]
		[Address(RVA = "0x9316A8", Offset = "0x9316A8", Length = "0x64")]
		protected void SendOnFocus()
		{
		}

		[Token(Token = "0x600027B")]
		[Address(RVA = "0x93170C", Offset = "0x93170C", Length = "0x64")]
		protected void SendOnFocusLost()
		{
		}

		[Token(Token = "0x600027C")]
		[Address(RVA = "0x931770", Offset = "0x931770", Length = "0x9C")]
		protected void SendOnTextSelection()
		{
		}

		[Token(Token = "0x600027D")]
		[Address(RVA = "0x93180C", Offset = "0x93180C", Length = "0x94")]
		protected void SendOnEndTextSelection()
		{
		}

		[Token(Token = "0x600027E")]
		[Address(RVA = "0x92CE74", Offset = "0x92CE74", Length = "0x7C")]
		protected void SendTouchScreenKeyboardStatusChanged()
		{
		}

		[Token(Token = "0x600027F")]
		[Address(RVA = "0x928B80", Offset = "0x928B80", Length = "0x320")]
		protected void UpdateLabel()
		{
		}

		[Token(Token = "0x6000280")]
		[Address(RVA = "0x92CD00", Offset = "0x92CD00", Length = "0x174")]
		private void UpdateScrollbar()
		{
		}

		[Token(Token = "0x6000281")]
		[Address(RVA = "0x9318A0", Offset = "0x9318A0", Length = "0x5C")]
		private void OnScrollbarValueChange(float value)
		{
		}

		[Token(Token = "0x6000282")]
		[Address(RVA = "0x928A08", Offset = "0x928A08", Length = "0x178")]
		private void AdjustTextPositionRelativeToViewport(float relativePosition)
		{
		}

		[Token(Token = "0x6000283")]
		[Address(RVA = "0x92B874", Offset = "0x92B874", Length = "0x84")]
		private int GetCaretPositionFromStringIndex(int stringIndex)
		{
			return 0;
		}

		[Token(Token = "0x6000284")]
		[Address(RVA = "0x9318FC", Offset = "0x9318FC", Length = "0x88")]
		private int GetMinCaretPositionFromStringIndex(int stringIndex)
		{
			return 0;
		}

		[Token(Token = "0x6000285")]
		[Address(RVA = "0x931984", Offset = "0x931984", Length = "0x84")]
		private int GetMaxCaretPositionFromStringIndex(int stringIndex)
		{
			return 0;
		}

		[Token(Token = "0x6000286")]
		[Address(RVA = "0x92BB78", Offset = "0x92BB78", Length = "0x74")]
		private int GetStringIndexFromCaretPosition(int caretPosition)
		{
			return 0;
		}

		[Token(Token = "0x6000287")]
		[Address(RVA = "0x931A08", Offset = "0x931A08", Length = "0x4")]
		public void ForceLabelUpdate()
		{
		}

		[Token(Token = "0x6000288")]
		[Address(RVA = "0x92907C", Offset = "0x92907C", Length = "0x68")]
		private void MarkGeometryAsDirty()
		{
		}

		[Token(Token = "0x6000289")]
		[Address(RVA = "0x931A0C", Offset = "0x931A0C", Length = "0x10")]
		public virtual void Rebuild(CanvasUpdate update)
		{
		}

		[Token(Token = "0x600028A")]
		[Address(RVA = "0x931AE4", Offset = "0x931AE4", Length = "0x4")]
		public virtual void LayoutComplete()
		{
		}

		[Token(Token = "0x600028B")]
		[Address(RVA = "0x931AE8", Offset = "0x931AE8", Length = "0x4")]
		public virtual void GraphicUpdateComplete()
		{
		}

		[Token(Token = "0x600028C")]
		[Address(RVA = "0x931A1C", Offset = "0x931A1C", Length = "0xC8")]
		private void UpdateGeometry()
		{
		}

		[Token(Token = "0x600028D")]
		[Address(RVA = "0x92AC98", Offset = "0x92AC98", Length = "0x650")]
		private void AssignPositioningIfNeeded()
		{
		}

		[Token(Token = "0x600028E")]
		[Address(RVA = "0x931AEC", Offset = "0x931AEC", Length = "0x340")]
		private void OnFillVBO(Mesh vbo)
		{
		}

		[Token(Token = "0x600028F")]
		[Address(RVA = "0x931E2C", Offset = "0x931E2C", Length = "0x4AC")]
		private void GenerateCaret(VertexHelper vbo, Vector2 roundingOffset)
		{
		}

		[Token(Token = "0x6000290")]
		[Address(RVA = "0x932B28", Offset = "0x932B28", Length = "0x158")]
		private void CreateCursorVerts()
		{
		}

		[Token(Token = "0x6000291")]
		[Address(RVA = "0x9322D8", Offset = "0x9322D8", Length = "0x850")]
		private void GenerateHightlight(VertexHelper vbo, Vector2 roundingOffset)
		{
		}

		[Token(Token = "0x6000292")]
		[Address(RVA = "0x932C80", Offset = "0x932C80", Length = "0x70C")]
		private void AdjustRectTransformRelativeToViewport(Vector2 startPosition, float height, bool isCharVisible)
		{
		}

		[Token(Token = "0x6000293")]
		[Address(RVA = "0x92CEF0", Offset = "0x92CEF0", Length = "0x680")]
		protected char Validate(string text, int pos, char ch)
		{
			return '\0';
		}

		[Token(Token = "0x6000294")]
		[Address(RVA = "0x93338C", Offset = "0x93338C", Length = "0x138")]
		public void ActivateInputField()
		{
		}

		[Token(Token = "0x6000295")]
		[Address(RVA = "0x92C8A0", Offset = "0x92C8A0", Length = "0x460")]
		private void ActivateInputFieldInternal()
		{
		}

		[Token(Token = "0x6000296")]
		[Address(RVA = "0x9334C4", Offset = "0x9334C4", Length = "0x30")]
		public override void OnSelect(BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000297")]
		[Address(RVA = "0x9334F4", Offset = "0x9334F4", Length = "0x24")]
		public virtual void OnPointerClick(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000298")]
		[Address(RVA = "0x933518", Offset = "0x933518", Length = "0x4")]
		public void OnControlClick()
		{
		}

		[Token(Token = "0x6000299")]
		[Address(RVA = "0x93351C", Offset = "0x93351C", Length = "0x8")]
		public void ReleaseSelection()
		{
		}

		[Token(Token = "0x600029A")]
		[Address(RVA = "0x92B5E0", Offset = "0x92B5E0", Length = "0x19C")]
		public void DeactivateInputField(bool clearSelection = false)
		{
		}

		[Token(Token = "0x600029B")]
		[Address(RVA = "0x933524", Offset = "0x933524", Length = "0x3C")]
		public override void OnDeselect(BaseEventData eventData)
		{
		}

		[Token(Token = "0x600029C")]
		[Address(RVA = "0x933560", Offset = "0x933560", Length = "0x64")]
		public virtual void OnSubmit(BaseEventData eventData)
		{
		}

		[Token(Token = "0x600029D")]
		[Address(RVA = "0x929C0C", Offset = "0x929C0C", Length = "0xCC")]
		private void EnforceContentType()
		{
		}

		[Token(Token = "0x600029E")]
		[Address(RVA = "0x9284C0", Offset = "0x9284C0", Length = "0xB0")]
		private void SetTextComponentWrapMode()
		{
		}

		[Token(Token = "0x600029F")]
		[Address(RVA = "0x92A154", Offset = "0x92A154", Length = "0x98")]
		private void SetTextComponentRichTextMode()
		{
		}

		[Token(Token = "0x60002A0")]
		[Address(RVA = "0x929DAC", Offset = "0x929DAC", Length = "0x78")]
		private void SetToCustomIfContentTypeIsNot(params ContentType[] allowedContentTypes)
		{
		}

		[Token(Token = "0x60002A1")]
		[Address(RVA = "0x929F40", Offset = "0x929F40", Length = "0x18")]
		private void SetToCustom()
		{
		}

		[Token(Token = "0x60002A2")]
		[Address(RVA = "0x92A114", Offset = "0x92A114", Length = "0x18")]
		private void SetToCustom(CharacterValidation characterValidation)
		{
		}

		[Token(Token = "0x60002A3")]
		[Address(RVA = "0x9335C4", Offset = "0x9335C4", Length = "0x2C")]
		protected override void DoStateTransition(SelectionState state, bool instant)
		{
		}

		[Token(Token = "0x60002A4")]
		[Address(RVA = "0x9335F0", Offset = "0x9335F0", Length = "0x4")]
		public virtual void CalculateLayoutInputHorizontal()
		{
		}

		[Token(Token = "0x60002A5")]
		[Address(RVA = "0x9335F4", Offset = "0x9335F4", Length = "0x4")]
		public virtual void CalculateLayoutInputVertical()
		{
		}

		[Token(Token = "0x60002AD")]
		[Address(RVA = "0x929950", Offset = "0x929950", Length = "0xF0")]
		public void SetGlobalPointSize(float pointSize)
		{
		}

		[Token(Token = "0x60002AE")]
		[Address(RVA = "0x929A48", Offset = "0x929A48", Length = "0xF0")]
		public void SetGlobalFontAsset(TMP_FontAsset fontAsset)
		{
		}
	}
}
