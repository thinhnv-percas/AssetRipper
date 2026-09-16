using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace UnityEngine.UI
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x727230", Offset = "0x727230")]
	[Token(Token = "0x2000018")]
	public class InputField : Selectable, IUpdateSelectedHandler, IEventSystemHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler, ISubmitHandler, ICanvasElement, ILayoutElement
	{
		[Token(Token = "0x2000087")]
		public enum ContentType
		{
			[Token(Token = "0x400025D")]
			Standard = 0,
			[Token(Token = "0x400025E")]
			Autocorrected = 1,
			[Token(Token = "0x400025F")]
			IntegerNumber = 2,
			[Token(Token = "0x4000260")]
			DecimalNumber = 3,
			[Token(Token = "0x4000261")]
			Alphanumeric = 4,
			[Token(Token = "0x4000262")]
			Name = 5,
			[Token(Token = "0x4000263")]
			EmailAddress = 6,
			[Token(Token = "0x4000264")]
			Password = 7,
			[Token(Token = "0x4000265")]
			Pin = 8,
			[Token(Token = "0x4000266")]
			Custom = 9
		}

		[Token(Token = "0x2000088")]
		public enum InputType
		{
			[Token(Token = "0x4000268")]
			Standard = 0,
			[Token(Token = "0x4000269")]
			AutoCorrect = 1,
			[Token(Token = "0x400026A")]
			Password = 2
		}

		[Token(Token = "0x2000089")]
		public enum CharacterValidation
		{
			[Token(Token = "0x400026C")]
			None = 0,
			[Token(Token = "0x400026D")]
			Integer = 1,
			[Token(Token = "0x400026E")]
			Decimal = 2,
			[Token(Token = "0x400026F")]
			Alphanumeric = 3,
			[Token(Token = "0x4000270")]
			Name = 4,
			[Token(Token = "0x4000271")]
			EmailAddress = 5
		}

		[Token(Token = "0x200008A")]
		public enum LineType
		{
			[Token(Token = "0x4000273")]
			SingleLine = 0,
			[Token(Token = "0x4000274")]
			MultiLineSubmit = 1,
			[Token(Token = "0x4000275")]
			MultiLineNewline = 2
		}

		[Token(Token = "0x200008B")]
		public delegate char OnValidateInput(string text, int charIndex, char addedChar);

		[Serializable]
		[Token(Token = "0x200008C")]
		public class SubmitEvent : UnityEvent<string>
		{
			[Token(Token = "0x6000646")]
			[Address(RVA = "0xF52F58", Offset = "0xF52F58", Length = "0x50")]
			public SubmitEvent()
			{
			}
		}

		[Serializable]
		[Token(Token = "0x200008D")]
		public class OnChangeEvent : UnityEvent<string>
		{
			[Token(Token = "0x6000647")]
			[Address(RVA = "0xF52FA8", Offset = "0xF52FA8", Length = "0x50")]
			public OnChangeEvent()
			{
			}
		}

		[Token(Token = "0x200008E")]
		protected enum EditState
		{
			[Token(Token = "0x4000277")]
			Continue = 0,
			[Token(Token = "0x4000278")]
			Finish = 1
		}

		[Token(Token = "0x400007E")]
		[FieldOffset(Offset = "0xE8")]
		protected TouchScreenKeyboard m_Keyboard;

		[Token(Token = "0x400007F")]
		private static readonly char[] kSeparators;

		[SerializeField]
		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x7289B4", Offset = "0x7289B4")]
		[Token(Token = "0x4000080")]
		[FieldOffset(Offset = "0xF0")]
		protected Text m_TextComponent;

		[SerializeField]
		[Token(Token = "0x4000081")]
		[FieldOffset(Offset = "0xF8")]
		protected Graphic m_Placeholder;

		[SerializeField]
		[Token(Token = "0x4000082")]
		[FieldOffset(Offset = "0x100")]
		private ContentType m_ContentType;

		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x728A20", Offset = "0x728A20")]
		[SerializeField]
		[Token(Token = "0x4000083")]
		[FieldOffset(Offset = "0x104")]
		private InputType m_InputType;

		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x728A6C", Offset = "0x728A6C")]
		[SerializeField]
		[Token(Token = "0x4000084")]
		[FieldOffset(Offset = "0x108")]
		private char m_AsteriskChar;

		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x728AB8", Offset = "0x728AB8")]
		[SerializeField]
		[Token(Token = "0x4000085")]
		[FieldOffset(Offset = "0x10C")]
		private TouchScreenKeyboardType m_KeyboardType;

		[SerializeField]
		[Token(Token = "0x4000086")]
		[FieldOffset(Offset = "0x110")]
		private LineType m_LineType;

		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x728B14", Offset = "0x728B14")]
		[SerializeField]
		[Token(Token = "0x4000087")]
		[FieldOffset(Offset = "0x114")]
		private bool m_HideMobileInput;

		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x728B60", Offset = "0x728B60")]
		[SerializeField]
		[Token(Token = "0x4000088")]
		[FieldOffset(Offset = "0x118")]
		private CharacterValidation m_CharacterValidation;

		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x728BAC", Offset = "0x728BAC")]
		[SerializeField]
		[Token(Token = "0x4000089")]
		[FieldOffset(Offset = "0x11C")]
		private int m_CharacterLimit;

		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x728BF8", Offset = "0x728BF8")]
		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x728BF8", Offset = "0x728BF8")]
		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x728BF8", Offset = "0x728BF8")]
		[SerializeField]
		[Token(Token = "0x400008A")]
		[FieldOffset(Offset = "0x120")]
		private SubmitEvent m_OnEndEdit;

		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x728C8C", Offset = "0x728C8C")]
		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x728C8C", Offset = "0x728C8C")]
		[SerializeField]
		[Token(Token = "0x400008B")]
		[FieldOffset(Offset = "0x128")]
		private OnChangeEvent m_OnValueChanged;

		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x728CFC", Offset = "0x728CFC")]
		[SerializeField]
		[Token(Token = "0x400008C")]
		[FieldOffset(Offset = "0x130")]
		private OnValidateInput m_OnValidateInput;

		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x728D48", Offset = "0x728D48")]
		[SerializeField]
		[Token(Token = "0x400008D")]
		[FieldOffset(Offset = "0x138")]
		private Color m_CaretColor;

		[SerializeField]
		[Token(Token = "0x400008E")]
		[FieldOffset(Offset = "0x148")]
		private bool m_CustomCaretColor;

		[SerializeField]
		[Token(Token = "0x400008F")]
		[FieldOffset(Offset = "0x14C")]
		private Color m_SelectionColor;

		[SerializeField]
		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x728DB4", Offset = "0x728DB4")]
		[Token(Token = "0x4000090")]
		[FieldOffset(Offset = "0x160")]
		protected string m_Text;

		[SerializeField]
		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x728E00", Offset = "0x728E00")]
		[Token(Token = "0x4000091")]
		[FieldOffset(Offset = "0x168")]
		private float m_CaretBlinkRate;

		[SerializeField]
		[AttributeAttribute(Type = typeof(RangeAttribute), RVA = "0x728E40", Offset = "0x728E40")]
		[Token(Token = "0x4000092")]
		[FieldOffset(Offset = "0x16C")]
		private int m_CaretWidth;

		[SerializeField]
		[Token(Token = "0x4000093")]
		[FieldOffset(Offset = "0x170")]
		private bool m_ReadOnly;

		[Token(Token = "0x4000094")]
		[FieldOffset(Offset = "0x174")]
		protected int m_CaretPosition;

		[Token(Token = "0x4000095")]
		[FieldOffset(Offset = "0x178")]
		protected int m_CaretSelectPosition;

		[Token(Token = "0x4000096")]
		[FieldOffset(Offset = "0x180")]
		private RectTransform caretRectTrans;

		[Token(Token = "0x4000097")]
		[FieldOffset(Offset = "0x188")]
		protected UIVertex[] m_CursorVerts;

		[Token(Token = "0x4000098")]
		[FieldOffset(Offset = "0x190")]
		private TextGenerator m_InputTextCache;

		[Token(Token = "0x4000099")]
		[FieldOffset(Offset = "0x198")]
		private CanvasRenderer m_CachedInputRenderer;

		[Token(Token = "0x400009A")]
		[FieldOffset(Offset = "0x1A0")]
		private bool m_PreventFontCallback;

		[NonSerialized]
		[Token(Token = "0x400009B")]
		[FieldOffset(Offset = "0x1A8")]
		protected Mesh m_Mesh;

		[Token(Token = "0x400009C")]
		[FieldOffset(Offset = "0x1B0")]
		private bool m_AllowInput;

		[Token(Token = "0x400009D")]
		[FieldOffset(Offset = "0x1B1")]
		private bool m_ShouldActivateNextUpdate;

		[Token(Token = "0x400009E")]
		[FieldOffset(Offset = "0x1B2")]
		private bool m_UpdateDrag;

		[Token(Token = "0x400009F")]
		[FieldOffset(Offset = "0x1B3")]
		private bool m_DragPositionOutOfBounds;

		[Token(Token = "0x40000A0")]
		private const float kHScrollSpeed = 0.05f;

		[Token(Token = "0x40000A1")]
		private const float kVScrollSpeed = 0.1f;

		[Token(Token = "0x40000A2")]
		[FieldOffset(Offset = "0x1B4")]
		protected bool m_CaretVisible;

		[Token(Token = "0x40000A3")]
		[FieldOffset(Offset = "0x1B8")]
		private Coroutine m_BlinkCoroutine;

		[Token(Token = "0x40000A4")]
		[FieldOffset(Offset = "0x1C0")]
		private float m_BlinkStartTime;

		[Token(Token = "0x40000A5")]
		[FieldOffset(Offset = "0x1C4")]
		protected int m_DrawStart;

		[Token(Token = "0x40000A6")]
		[FieldOffset(Offset = "0x1C8")]
		protected int m_DrawEnd;

		[Token(Token = "0x40000A7")]
		[FieldOffset(Offset = "0x1D0")]
		private Coroutine m_DragCoroutine;

		[Token(Token = "0x40000A8")]
		[FieldOffset(Offset = "0x1D8")]
		private string m_OriginalText;

		[Token(Token = "0x40000A9")]
		[FieldOffset(Offset = "0x1E0")]
		private bool m_WasCanceled;

		[Token(Token = "0x40000AA")]
		[FieldOffset(Offset = "0x1E1")]
		private bool m_HasDoneFocusTransition;

		[Token(Token = "0x40000AB")]
		[FieldOffset(Offset = "0x1E8")]
		private WaitForSecondsRealtime m_WaitForSecondsRealtime;

		[Token(Token = "0x40000AC")]
		[FieldOffset(Offset = "0x1F0")]
		private bool m_TouchKeyboardAllowsInPlaceEditing;

		[Token(Token = "0x40000AD")]
		private const string kEmailSpecialCharacters = "!#$%&'*+-/=?^_`{|}~";

		[Token(Token = "0x40000AE")]
		[FieldOffset(Offset = "0x1F8")]
		private Event m_ProcessingEvent;

		[Token(Token = "0x40000AF")]
		private const int k_MaxTextLength = 16382;

		[Token(Token = "0x1700005B")]
		private BaseInput input
		{
			[Token(Token = "0x600014C")]
			[Address(RVA = "0xF52BD4", Offset = "0xF52BD4", Length = "0x140")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700005C")]
		private string compositionString
		{
			[Token(Token = "0x600014D")]
			[Address(RVA = "0xF52D14", Offset = "0xF52D14", Length = "0xA4")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700005D")]
		protected Mesh mesh
		{
			[Token(Token = "0x600014F")]
			[Address(RVA = "0xF530A8", Offset = "0xF530A8", Length = "0xA4")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700005E")]
		protected TextGenerator cachedInputTextGenerator
		{
			[Token(Token = "0x6000150")]
			[Address(RVA = "0xF5314C", Offset = "0xF5314C", Length = "0x6C")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700005F")]
		public bool shouldHideMobileInput
		{
			[Token(Token = "0x6000152")]
			[Address(RVA = "0xF53218", Offset = "0xF53218", Length = "0x54")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000151")]
			[Address(RVA = "0xF531B8", Offset = "0xF531B8", Length = "0x60")]
			set
			{
			}
		}

		[Token(Token = "0x17000060")]
		private bool shouldActivateOnSelect
		{
			[Token(Token = "0x6000153")]
			[Address(RVA = "0xF5326C", Offset = "0xF5326C", Length = "0x20")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x17000061")]
		public string text
		{
			[Token(Token = "0x6000154")]
			[Address(RVA = "0xF5328C", Offset = "0xF5328C", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000155")]
			[Address(RVA = "0xF53294", Offset = "0xF53294", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000062")]
		public bool isFocused
		{
			[Token(Token = "0x6000158")]
			[Address(RVA = "0xF53DD8", Offset = "0xF53DD8", Length = "0x8")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x17000063")]
		public float caretBlinkRate
		{
			[Token(Token = "0x6000159")]
			[Address(RVA = "0xF53DE0", Offset = "0xF53DE0", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600015A")]
			[Address(RVA = "0xF53DE8", Offset = "0xF53DE8", Length = "0x84")]
			set
			{
			}
		}

		[Token(Token = "0x17000064")]
		public int caretWidth
		{
			[Token(Token = "0x600015B")]
			[Address(RVA = "0xF53ECC", Offset = "0xF53ECC", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x600015C")]
			[Address(RVA = "0xF53ED4", Offset = "0xF53ED4", Length = "0x7C")]
			set
			{
			}
		}

		[Token(Token = "0x17000065")]
		public Text textComponent
		{
			[Token(Token = "0x600015D")]
			[Address(RVA = "0xF53FB8", Offset = "0xF53FB8", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600015E")]
			[Address(RVA = "0xF53FC0", Offset = "0xF53FC0", Length = "0x268")]
			set
			{
			}
		}

		[Token(Token = "0x17000066")]
		public Graphic placeholder
		{
			[Token(Token = "0x600015F")]
			[Address(RVA = "0xF54228", Offset = "0xF54228", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000160")]
			[Address(RVA = "0xF54230", Offset = "0xF54230", Length = "0x60")]
			set
			{
			}
		}

		[Token(Token = "0x17000067")]
		public Color caretColor
		{
			[Token(Token = "0x6000161")]
			[Address(RVA = "0xF54290", Offset = "0xF54290", Length = "0x40")]
			get
			{
				return default(Color);
			}
			[Token(Token = "0x6000162")]
			[Address(RVA = "0xF542D0", Offset = "0xF542D0", Length = "0x3C")]
			set
			{
			}
		}

		[Token(Token = "0x17000068")]
		public bool customCaretColor
		{
			[Token(Token = "0x6000163")]
			[Address(RVA = "0xF5430C", Offset = "0xF5430C", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000164")]
			[Address(RVA = "0xF54314", Offset = "0xF54314", Length = "0x24")]
			set
			{
			}
		}

		[Token(Token = "0x17000069")]
		public Color selectionColor
		{
			[Token(Token = "0x6000165")]
			[Address(RVA = "0xF54338", Offset = "0xF54338", Length = "0x14")]
			get
			{
				return default(Color);
			}
			[Token(Token = "0x6000166")]
			[Address(RVA = "0xF5434C", Offset = "0xF5434C", Length = "0x3C")]
			set
			{
			}
		}

		[Token(Token = "0x1700006A")]
		public SubmitEvent onEndEdit
		{
			[Token(Token = "0x6000167")]
			[Address(RVA = "0xF54388", Offset = "0xF54388", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000168")]
			[Address(RVA = "0xF54390", Offset = "0xF54390", Length = "0x60")]
			set
			{
			}
		}

		[Obsolete]
		[Token(Token = "0x1700006B")]
		public OnChangeEvent onValueChange
		{
			[Token(Token = "0x6000169")]
			[Address(RVA = "0xF543F0", Offset = "0xF543F0", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600016A")]
			[Address(RVA = "0xF543F8", Offset = "0xF543F8", Length = "0x4")]
			set
			{
			}
		}

		[Token(Token = "0x1700006C")]
		public OnChangeEvent onValueChanged
		{
			[Token(Token = "0x600016B")]
			[Address(RVA = "0xF5445C", Offset = "0xF5445C", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600016C")]
			[Address(RVA = "0xF543FC", Offset = "0xF543FC", Length = "0x60")]
			set
			{
			}
		}

		[Token(Token = "0x1700006D")]
		public OnValidateInput onValidateInput
		{
			[Token(Token = "0x600016D")]
			[Address(RVA = "0xF54464", Offset = "0xF54464", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600016E")]
			[Address(RVA = "0xF5446C", Offset = "0xF5446C", Length = "0x60")]
			set
			{
			}
		}

		[Token(Token = "0x1700006E")]
		public int characterLimit
		{
			[Token(Token = "0x600016F")]
			[Address(RVA = "0xF544CC", Offset = "0xF544CC", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x6000170")]
			[Address(RVA = "0xF544D4", Offset = "0xF544D4", Length = "0xC4")]
			set
			{
			}
		}

		[Token(Token = "0x1700006F")]
		public ContentType contentType
		{
			[Token(Token = "0x6000171")]
			[Address(RVA = "0xF54598", Offset = "0xF54598", Length = "0x8")]
			get
			{
				return ContentType.Standard;
			}
			[Token(Token = "0x6000172")]
			[Address(RVA = "0xF545A0", Offset = "0xF545A0", Length = "0x7C")]
			set
			{
			}
		}

		[Token(Token = "0x17000070")]
		public LineType lineType
		{
			[Token(Token = "0x6000173")]
			[Address(RVA = "0xF546E8", Offset = "0xF546E8", Length = "0x8")]
			get
			{
				return LineType.SingleLine;
			}
			[Token(Token = "0x6000174")]
			[Address(RVA = "0xF546F0", Offset = "0xF546F0", Length = "0xCC")]
			set
			{
			}
		}

		[Token(Token = "0x17000071")]
		public InputType inputType
		{
			[Token(Token = "0x6000175")]
			[Address(RVA = "0xF54834", Offset = "0xF54834", Length = "0x8")]
			get
			{
				return InputType.Standard;
			}
			[Token(Token = "0x6000176")]
			[Address(RVA = "0xF5483C", Offset = "0xF5483C", Length = "0x8C")]
			set
			{
			}
		}

		[Token(Token = "0x17000072")]
		public TouchScreenKeyboard touchScreenKeyboard
		{
			[Token(Token = "0x6000177")]
			[Address(RVA = "0xF548E0", Offset = "0xF548E0", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000073")]
		public TouchScreenKeyboardType keyboardType
		{
			[Token(Token = "0x6000178")]
			[Address(RVA = "0xF548E8", Offset = "0xF548E8", Length = "0x8")]
			get
			{
				return TouchScreenKeyboardType.Default;
			}
			[Token(Token = "0x6000179")]
			[Address(RVA = "0xF548F0", Offset = "0xF548F0", Length = "0x8C")]
			set
			{
			}
		}

		[Token(Token = "0x17000074")]
		public CharacterValidation characterValidation
		{
			[Token(Token = "0x600017A")]
			[Address(RVA = "0xF5497C", Offset = "0xF5497C", Length = "0x8")]
			get
			{
				return CharacterValidation.None;
			}
			[Token(Token = "0x600017B")]
			[Address(RVA = "0xF54984", Offset = "0xF54984", Length = "0x8C")]
			set
			{
			}
		}

		[Token(Token = "0x17000075")]
		public bool readOnly
		{
			[Token(Token = "0x600017C")]
			[Address(RVA = "0xF54A10", Offset = "0xF54A10", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x600017D")]
			[Address(RVA = "0xF54A18", Offset = "0xF54A18", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x17000076")]
		public bool multiLine
		{
			[Token(Token = "0x600017E")]
			[Address(RVA = "0xF54A24", Offset = "0xF54A24", Length = "0x14")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x17000077")]
		public char asteriskChar
		{
			[Token(Token = "0x600017F")]
			[Address(RVA = "0xF54A38", Offset = "0xF54A38", Length = "0x8")]
			get
			{
				return '\0';
			}
			[Token(Token = "0x6000180")]
			[Address(RVA = "0xF54A40", Offset = "0xF54A40", Length = "0x7C")]
			set
			{
			}
		}

		[Token(Token = "0x17000078")]
		public bool wasCanceled
		{
			[Token(Token = "0x6000181")]
			[Address(RVA = "0xF54ABC", Offset = "0xF54ABC", Length = "0x8")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x17000079")]
		protected int caretPositionInternal
		{
			[Token(Token = "0x6000183")]
			[Address(RVA = "0xF54B00", Offset = "0xF54B00", Length = "0x30")]
			get
			{
				return 0;
			}
			[Token(Token = "0x6000184")]
			[Address(RVA = "0xF54B30", Offset = "0xF54B30", Length = "0x3C")]
			set
			{
			}
		}

		[Token(Token = "0x1700007A")]
		protected int caretSelectPositionInternal
		{
			[Token(Token = "0x6000185")]
			[Address(RVA = "0xF54B6C", Offset = "0xF54B6C", Length = "0x30")]
			get
			{
				return 0;
			}
			[Token(Token = "0x6000186")]
			[Address(RVA = "0xF54B9C", Offset = "0xF54B9C", Length = "0x3C")]
			set
			{
			}
		}

		[Token(Token = "0x1700007B")]
		private bool hasSelection
		{
			[Token(Token = "0x6000187")]
			[Address(RVA = "0xF54BD8", Offset = "0xF54BD8", Length = "0x34")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x1700007C")]
		public int caretPosition
		{
			[Token(Token = "0x6000188")]
			[Address(RVA = "0xF54C0C", Offset = "0xF54C0C", Length = "0x30")]
			get
			{
				return 0;
			}
			[Token(Token = "0x6000189")]
			[Address(RVA = "0xF54C3C", Offset = "0xF54C3C", Length = "0x2C")]
			set
			{
			}
		}

		[Token(Token = "0x1700007D")]
		public int selectionAnchorPosition
		{
			[Token(Token = "0x600018A")]
			[Address(RVA = "0xF54D30", Offset = "0xF54D30", Length = "0x30")]
			get
			{
				return 0;
			}
			[Token(Token = "0x600018B")]
			[Address(RVA = "0xF54C68", Offset = "0xF54C68", Length = "0x64")]
			set
			{
			}
		}

		[Token(Token = "0x1700007E")]
		public int selectionFocusPosition
		{
			[Token(Token = "0x600018C")]
			[Address(RVA = "0xF54D60", Offset = "0xF54D60", Length = "0x30")]
			get
			{
				return 0;
			}
			[Token(Token = "0x600018D")]
			[Address(RVA = "0xF54CCC", Offset = "0xF54CCC", Length = "0x64")]
			set
			{
			}
		}

		[Token(Token = "0x1700007F")]
		private static string clipboard
		{
			[Token(Token = "0x6000198")]
			[Address(RVA = "0xF556FC", Offset = "0xF556FC", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000199")]
			[Address(RVA = "0xF55704", Offset = "0xF55704", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000080")]
		public virtual float minWidth
		{
			[Token(Token = "0x60001DF")]
			[Address(RVA = "0xF5C138", Offset = "0xF5C138", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000081")]
		public virtual float preferredWidth
		{
			[Token(Token = "0x60001E0")]
			[Address(RVA = "0xF5C140", Offset = "0xF5C140", Length = "0x164")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000082")]
		public virtual float flexibleWidth
		{
			[Token(Token = "0x60001E1")]
			[Address(RVA = "0xF5C2A4", Offset = "0xF5C2A4", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000083")]
		public virtual float minHeight
		{
			[Token(Token = "0x60001E2")]
			[Address(RVA = "0xF5C2AC", Offset = "0xF5C2AC", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000084")]
		public virtual float preferredHeight
		{
			[Token(Token = "0x60001E3")]
			[Address(RVA = "0xF5C2B4", Offset = "0xF5C2B4", Length = "0x180")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000085")]
		public virtual float flexibleHeight
		{
			[Token(Token = "0x60001E4")]
			[Address(RVA = "0xF5C434", Offset = "0xF5C434", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000086")]
		public virtual int layoutPriority
		{
			[Token(Token = "0x60001E5")]
			[Address(RVA = "0xF5C43C", Offset = "0xF5C43C", Length = "0x8")]
			get
			{
				return 0;
			}
		}

		Transform ICanvasElement.transform
		{
			[Token(Token = "0x60001E7")]
			[Address(RVA = "0xF5C4C0", Offset = "0xF5C4C0", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x600014E")]
		[Address(RVA = "0xF52DB8", Offset = "0xF52DB8", Length = "0x1A0")]
		protected InputField()
		{
		}

		[Token(Token = "0x6000156")]
		[Address(RVA = "0xF53570", Offset = "0xF53570", Length = "0x8")]
		public void SetTextWithoutNotify(string input)
		{
		}

		[Token(Token = "0x6000157")]
		[Address(RVA = "0xF5329C", Offset = "0xF5329C", Length = "0x2D4")]
		private void SetText(string value, bool sendCallback = true)
		{
		}

		[Token(Token = "0x6000182")]
		[Address(RVA = "0xF54AC4", Offset = "0xF54AC4", Length = "0x3C")]
		protected void ClampPos(ref int pos)
		{
		}

		[Token(Token = "0x600018E")]
		[Address(RVA = "0xF54D90", Offset = "0xF54D90", Length = "0x244")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x600018F")]
		[Address(RVA = "0xF54FD4", Offset = "0xF54FD4", Length = "0x21C")]
		protected override void OnDisable()
		{
		}

		[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x72A098", Offset = "0x72A098")]
		[Token(Token = "0x6000190")]
		[Address(RVA = "0xF55364", Offset = "0xF55364", Length = "0x74")]
		private IEnumerator CaretBlink()
		{
			return null;
		}

		[Token(Token = "0x6000191")]
		[Address(RVA = "0xF55404", Offset = "0xF55404", Length = "0x48")]
		private void SetCaretVisible()
		{
		}

		[Token(Token = "0x6000192")]
		[Address(RVA = "0xF53E6C", Offset = "0xF53E6C", Length = "0x60")]
		private void SetCaretActive()
		{
		}

		[Token(Token = "0x6000193")]
		[Address(RVA = "0xF5544C", Offset = "0xF5544C", Length = "0x130")]
		private void UpdateCaretMaterial()
		{
		}

		[Token(Token = "0x6000194")]
		[Address(RVA = "0xF5557C", Offset = "0xF5557C", Length = "0x4")]
		protected void OnFocus()
		{
		}

		[Token(Token = "0x6000195")]
		[Address(RVA = "0xF55580", Offset = "0xF55580", Length = "0x50")]
		protected void SelectAll()
		{
		}

		[Token(Token = "0x6000196")]
		[Address(RVA = "0xF555D0", Offset = "0xF555D0", Length = "0xA0")]
		public void MoveTextEnd(bool shift)
		{
		}

		[Token(Token = "0x6000197")]
		[Address(RVA = "0xF55670", Offset = "0xF55670", Length = "0x8C")]
		public void MoveTextStart(bool shift)
		{
		}

		[Token(Token = "0x600019A")]
		[Address(RVA = "0xF5570C", Offset = "0xF5570C", Length = "0x3C")]
		private bool InPlaceEditing()
		{
			return false;
		}

		[Token(Token = "0x600019B")]
		[Address(RVA = "0xF55748", Offset = "0xF55748", Length = "0xF4")]
		private void UpdateCaretFromKeyboard()
		{
		}

		[Token(Token = "0x600019C")]
		[Address(RVA = "0xF5583C", Offset = "0xF5583C", Length = "0x400")]
		protected virtual void LateUpdate()
		{
		}

		[Obsolete]
		[Token(Token = "0x600019D")]
		[Address(RVA = "0xF56BB8", Offset = "0xF56BB8", Length = "0x2F8")]
		public Vector2 ScreenToLocal(Vector2 screen)
		{
			return default(Vector2);
		}

		[Token(Token = "0x600019E")]
		[Address(RVA = "0xF56EB0", Offset = "0xF56EB0", Length = "0x23C")]
		private int GetUnclampedCharacterLineFromPosition(Vector2 pos, TextGenerator generator)
		{
			return 0;
		}

		[Token(Token = "0x600019F")]
		[Address(RVA = "0xF570EC", Offset = "0xF570EC", Length = "0x2F4")]
		protected int GetCharacterIndexFromPosition(Vector2 pos)
		{
			return 0;
		}

		[Token(Token = "0x60001A0")]
		[Address(RVA = "0xF57590", Offset = "0xF57590", Length = "0xF4")]
		private bool MayDrag(PointerEventData eventData)
		{
			return false;
		}

		[Token(Token = "0x60001A1")]
		[Address(RVA = "0xF57684", Offset = "0xF57684", Length = "0x2C")]
		public virtual void OnBeginDrag(PointerEventData eventData)
		{
		}

		[Token(Token = "0x60001A2")]
		[Address(RVA = "0xF576B0", Offset = "0xF576B0", Length = "0x1A8")]
		public virtual void OnDrag(PointerEventData eventData)
		{
		}

		[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x72A134", Offset = "0x72A134")]
		[Token(Token = "0x60001A3")]
		[Address(RVA = "0xF57858", Offset = "0xF57858", Length = "0x80")]
		private IEnumerator MouseDragOutsideRect(PointerEventData eventData)
		{
			return null;
		}

		[Token(Token = "0x60001A4")]
		[Address(RVA = "0xF57904", Offset = "0xF57904", Length = "0x28")]
		public virtual void OnEndDrag(PointerEventData eventData)
		{
		}

		[Token(Token = "0x60001A5")]
		[Address(RVA = "0xF5792C", Offset = "0xF5792C", Length = "0x210")]
		public override void OnPointerDown(PointerEventData eventData)
		{
		}

		[Token(Token = "0x60001A6")]
		[Address(RVA = "0xF57B3C", Offset = "0xF57B3C", Length = "0x3FC")]
		protected EditState KeyPressed(Event evt)
		{
			return EditState.Continue;
		}

		[Token(Token = "0x60001A7")]
		[Address(RVA = "0xF5871C", Offset = "0xF5871C", Length = "0x70")]
		private bool IsValidChar(char c)
		{
			return false;
		}

		[Token(Token = "0x60001A8")]
		[Address(RVA = "0xF5878C", Offset = "0xF5878C", Length = "0x4")]
		public void ProcessEvent(Event e)
		{
		}

		[Token(Token = "0x60001A9")]
		[Address(RVA = "0xF58790", Offset = "0xF58790", Length = "0x13C")]
		public virtual void OnUpdateSelected(BaseEventData eventData)
		{
		}

		[Token(Token = "0x60001AA")]
		[Address(RVA = "0xF580EC", Offset = "0xF580EC", Length = "0xB4")]
		private string GetSelectedString()
		{
			return null;
		}

		[Token(Token = "0x60001AB")]
		[Address(RVA = "0xF588CC", Offset = "0xF588CC", Length = "0xD8")]
		private int FindtNextWordBegin()
		{
			return 0;
		}

		[Token(Token = "0x60001AC")]
		[Address(RVA = "0xF58560", Offset = "0xF58560", Length = "0x1A4")]
		private void MoveRight(bool shift, bool ctrl)
		{
		}

		[Token(Token = "0x60001AD")]
		[Address(RVA = "0xF589A4", Offset = "0xF589A4", Length = "0xBC")]
		private int FindtPrevWordBegin()
		{
			return 0;
		}

		[Token(Token = "0x60001AE")]
		[Address(RVA = "0xF583BC", Offset = "0xF583BC", Length = "0x1A4")]
		private void MoveLeft(bool shift, bool ctrl)
		{
		}

		[Token(Token = "0x60001AF")]
		[Address(RVA = "0xF58A60", Offset = "0xF58A60", Length = "0x128")]
		private int DetermineCharacterLine(int charPos, TextGenerator generator)
		{
			return 0;
		}

		[Token(Token = "0x60001B0")]
		[Address(RVA = "0xF58B88", Offset = "0xF58B88", Length = "0x370")]
		private int LineUpCharacterPosition(int originalPos, bool goToFirstChar)
		{
			return 0;
		}

		[Token(Token = "0x60001B1")]
		[Address(RVA = "0xF58EF8", Offset = "0xF58EF8", Length = "0x2D4")]
		private int LineDownCharacterPosition(int originalPos, bool goToLastChar)
		{
			return 0;
		}

		[Token(Token = "0x60001B2")]
		[Address(RVA = "0xF58710", Offset = "0xF58710", Length = "0xC")]
		private void MoveDown(bool shift)
		{
		}

		[Token(Token = "0x60001B3")]
		[Address(RVA = "0xF591CC", Offset = "0xF591CC", Length = "0x1A8")]
		private void MoveDown(bool shift, bool goToLastChar)
		{
		}

		[Token(Token = "0x60001B4")]
		[Address(RVA = "0xF58704", Offset = "0xF58704", Length = "0xC")]
		private void MoveUp(bool shift)
		{
		}

		[Token(Token = "0x60001B5")]
		[Address(RVA = "0xF59374", Offset = "0xF59374", Length = "0x1C4")]
		private void MoveUp(bool shift, bool goToFirstChar)
		{
		}

		[Token(Token = "0x60001B6")]
		[Address(RVA = "0xF581A0", Offset = "0xF581A0", Length = "0x1C4")]
		private void Delete()
		{
		}

		[Token(Token = "0x60001B7")]
		[Address(RVA = "0xF5803C", Offset = "0xF5803C", Length = "0xB0")]
		private void ForwardSpace()
		{
		}

		[Token(Token = "0x60001B8")]
		[Address(RVA = "0xF57F38", Offset = "0xF57F38", Length = "0x104")]
		private void Backspace()
		{
		}

		[Token(Token = "0x60001B9")]
		[Address(RVA = "0xF59538", Offset = "0xF59538", Length = "0x100")]
		private void Insert(char c)
		{
		}

		[Token(Token = "0x60001BA")]
		[Address(RVA = "0xF58364", Offset = "0xF58364", Length = "0x58")]
		private void UpdateTouchKeyboardFromEditChanges()
		{
		}

		[Token(Token = "0x60001BB")]
		[Address(RVA = "0xF56B94", Offset = "0xF56B94", Length = "0x24")]
		private void SendOnValueChangedAndUpdateLabel()
		{
		}

		[Token(Token = "0x60001BC")]
		[Address(RVA = "0xF53998", Offset = "0xF53998", Length = "0x7C")]
		private void SendOnValueChanged()
		{
		}

		[Token(Token = "0x60001BD")]
		[Address(RVA = "0xF59638", Offset = "0xF59638", Length = "0x7C")]
		protected void SendOnSubmit()
		{
		}

		[Token(Token = "0x60001BE")]
		[Address(RVA = "0xF596B4", Offset = "0xF596B4", Length = "0xC8")]
		protected virtual void Append(string input)
		{
		}

		[Token(Token = "0x60001BF")]
		[Address(RVA = "0xF5977C", Offset = "0xF5977C", Length = "0x160")]
		protected virtual void Append(char input)
		{
		}

		[Token(Token = "0x60001C0")]
		[Address(RVA = "0xF53A14", Offset = "0xF53A14", Length = "0x3C4")]
		protected void UpdateLabel()
		{
		}

		[Token(Token = "0x60001C1")]
		[Address(RVA = "0xF5A4E8", Offset = "0xF5A4E8", Length = "0x70")]
		private bool IsSelectionVisible()
		{
			return false;
		}

		[Token(Token = "0x60001C2")]
		[Address(RVA = "0xF5A558", Offset = "0xF5A558", Length = "0x194")]
		private static int GetLineStartPosition(TextGenerator gen, int line)
		{
			return 0;
		}

		[Token(Token = "0x60001C3")]
		[Address(RVA = "0xF573E0", Offset = "0xF573E0", Length = "0x1B0")]
		private static int GetLineEndPosition(TextGenerator gen, int line)
		{
			return 0;
		}

		[Token(Token = "0x60001C4")]
		[Address(RVA = "0xF598DC", Offset = "0xF598DC", Length = "0xC0C")]
		private void SetDrawRangeToContainCaretPosition(int caretPos)
		{
		}

		[Token(Token = "0x60001C5")]
		[Address(RVA = "0xF5A6EC", Offset = "0xF5A6EC", Length = "0x4")]
		public void ForceLabelUpdate()
		{
		}

		[Token(Token = "0x60001C6")]
		[Address(RVA = "0xF53F50", Offset = "0xF53F50", Length = "0x68")]
		private void MarkGeometryAsDirty()
		{
		}

		[Token(Token = "0x60001C7")]
		[Address(RVA = "0xF5A6F0", Offset = "0xF5A6F0", Length = "0x10")]
		public virtual void Rebuild(CanvasUpdate update)
		{
		}

		[Token(Token = "0x60001C8")]
		[Address(RVA = "0xF5AB00", Offset = "0xF5AB00", Length = "0x4")]
		public virtual void LayoutComplete()
		{
		}

		[Token(Token = "0x60001C9")]
		[Address(RVA = "0xF5AB04", Offset = "0xF5AB04", Length = "0x4")]
		public virtual void GraphicUpdateComplete()
		{
		}

		[Token(Token = "0x60001CA")]
		[Address(RVA = "0xF5A700", Offset = "0xF5A700", Length = "0x400")]
		private void UpdateGeometry()
		{
		}

		[Token(Token = "0x60001CB")]
		[Address(RVA = "0xF55EFC", Offset = "0xF55EFC", Length = "0x610")]
		private void AssignPositioningIfNeeded()
		{
		}

		[Token(Token = "0x60001CC")]
		[Address(RVA = "0xF5AB08", Offset = "0xF5AB08", Length = "0x238")]
		private void OnFillVBO(Mesh vbo)
		{
		}

		[Token(Token = "0x60001CD")]
		[Address(RVA = "0xF5AD40", Offset = "0xF5AD40", Length = "0x6E4")]
		private void GenerateCaret(VertexHelper vbo, Vector2 roundingOffset)
		{
		}

		[Token(Token = "0x60001CE")]
		[Address(RVA = "0xF5BD80", Offset = "0xF5BD80", Length = "0x158")]
		private void CreateCursorVerts()
		{
		}

		[Token(Token = "0x60001CF")]
		[Address(RVA = "0xF5B424", Offset = "0xF5B424", Length = "0x95C")]
		private void GenerateHighlight(VertexHelper vbo, Vector2 roundingOffset)
		{
		}

		[Token(Token = "0x60001D0")]
		[Address(RVA = "0xF5650C", Offset = "0xF5650C", Length = "0x688")]
		protected char Validate(string text, int pos, char ch)
		{
			return '\0';
		}

		[Token(Token = "0x60001D1")]
		[Address(RVA = "0xF5BED8", Offset = "0xF5BED8", Length = "0x140")]
		public void ActivateInputField()
		{
		}

		[Token(Token = "0x60001D2")]
		[Address(RVA = "0xF55C3C", Offset = "0xF55C3C", Length = "0x2C0")]
		private void ActivateInputFieldInternal()
		{
		}

		[Token(Token = "0x60001D3")]
		[Address(RVA = "0xF5C018", Offset = "0xF5C018", Length = "0x44")]
		public override void OnSelect(BaseEventData eventData)
		{
		}

		[Token(Token = "0x60001D4")]
		[Address(RVA = "0xF5C05C", Offset = "0xF5C05C", Length = "0x24")]
		public virtual void OnPointerClick(PointerEventData eventData)
		{
		}

		[Token(Token = "0x60001D5")]
		[Address(RVA = "0xF551F0", Offset = "0xF551F0", Length = "0x174")]
		public void DeactivateInputField()
		{
		}

		[Token(Token = "0x60001D6")]
		[Address(RVA = "0xF5C080", Offset = "0xF5C080", Length = "0x30")]
		public override void OnDeselect(BaseEventData eventData)
		{
		}

		[Token(Token = "0x60001D7")]
		[Address(RVA = "0xF5C0B0", Offset = "0xF5C0B0", Length = "0x54")]
		public virtual void OnSubmit(BaseEventData eventData)
		{
		}

		[Token(Token = "0x60001D8")]
		[Address(RVA = "0xF5461C", Offset = "0xF5461C", Length = "0xCC")]
		private void EnforceContentType()
		{
		}

		[Token(Token = "0x60001D9")]
		[Address(RVA = "0xF52FF8", Offset = "0xF52FF8", Length = "0xB0")]
		private void EnforceTextHOverflow()
		{
		}

		[Token(Token = "0x60001DA")]
		[Address(RVA = "0xF547BC", Offset = "0xF547BC", Length = "0x78")]
		private void SetToCustomIfContentTypeIsNot(params ContentType[] allowedContentTypes)
		{
		}

		[Token(Token = "0x60001DB")]
		[Address(RVA = "0xF548C8", Offset = "0xF548C8", Length = "0x18")]
		private void SetToCustom()
		{
		}

		[Token(Token = "0x60001DC")]
		[Address(RVA = "0xF5C104", Offset = "0xF5C104", Length = "0x2C")]
		protected override void DoStateTransition(SelectionState state, bool instant)
		{
		}

		[Token(Token = "0x60001DD")]
		[Address(RVA = "0xF5C130", Offset = "0xF5C130", Length = "0x4")]
		public virtual void CalculateLayoutInputHorizontal()
		{
		}

		[Token(Token = "0x60001DE")]
		[Address(RVA = "0xF5C134", Offset = "0xF5C134", Length = "0x4")]
		public virtual void CalculateLayoutInputVertical()
		{
		}
	}
}
