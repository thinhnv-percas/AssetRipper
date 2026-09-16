using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace TMPro
{
	[AddComponentMenu("UI/TextMeshPro - Input Field", 11)]
	[Token(Token = "0x2000055")]
	public class TMP_InputField : Selectable, IUpdateSelectedHandler, IEventSystemHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler, ISubmitHandler, ICanvasElement, ILayoutElement, IScrollHandler
	{
		[Token(Token = "0x2000056")]
		public enum ContentType
		{
			[Token(Token = "0x40002A2")]
			Standard = 0,
			[Token(Token = "0x40002A3")]
			Autocorrected = 1,
			[Token(Token = "0x40002A4")]
			IntegerNumber = 2,
			[Token(Token = "0x40002A5")]
			DecimalNumber = 3,
			[Token(Token = "0x40002A6")]
			Alphanumeric = 4,
			[Token(Token = "0x40002A7")]
			Name = 5,
			[Token(Token = "0x40002A8")]
			EmailAddress = 6,
			[Token(Token = "0x40002A9")]
			Password = 7,
			[Token(Token = "0x40002AA")]
			Pin = 8,
			[Token(Token = "0x40002AB")]
			Custom = 9
		}

		[Token(Token = "0x2000057")]
		public enum InputType
		{
			[Token(Token = "0x40002AD")]
			Standard = 0,
			[Token(Token = "0x40002AE")]
			AutoCorrect = 1,
			[Token(Token = "0x40002AF")]
			Password = 2
		}

		[Token(Token = "0x2000058")]
		public enum CharacterValidation
		{
			[Token(Token = "0x40002B1")]
			None = 0,
			[Token(Token = "0x40002B2")]
			Digit = 1,
			[Token(Token = "0x40002B3")]
			Integer = 2,
			[Token(Token = "0x40002B4")]
			Decimal = 3,
			[Token(Token = "0x40002B5")]
			Alphanumeric = 4,
			[Token(Token = "0x40002B6")]
			Name = 5,
			[Token(Token = "0x40002B7")]
			Regex = 6,
			[Token(Token = "0x40002B8")]
			EmailAddress = 7,
			[Token(Token = "0x40002B9")]
			CustomValidator = 8
		}

		[Token(Token = "0x2000059")]
		public enum LineType
		{
			[Token(Token = "0x40002BB")]
			SingleLine = 0,
			[Token(Token = "0x40002BC")]
			MultiLineSubmit = 1,
			[Token(Token = "0x40002BD")]
			MultiLineNewline = 2
		}

		[Token(Token = "0x200005A")]
		public delegate char OnValidateInput(string text, int charIndex, char addedChar);

		[Serializable]
		[Token(Token = "0x200005B")]
		public class SubmitEvent : UnityEvent<string>
		{
			[Token(Token = "0x6000371")]
			[Address(RVA = "0x1601850", Offset = "0x1601850", Length = "0x48")]
			public SubmitEvent()
			{
			}
		}

		[Serializable]
		[Token(Token = "0x200005C")]
		public class OnChangeEvent : UnityEvent<string>
		{
			[Token(Token = "0x6000372")]
			[Address(RVA = "0x1601898", Offset = "0x1601898", Length = "0x48")]
			public OnChangeEvent()
			{
			}
		}

		[Serializable]
		[Token(Token = "0x200005D")]
		public class SelectionEvent : UnityEvent<string>
		{
			[Token(Token = "0x6000373")]
			[Address(RVA = "0x16018E0", Offset = "0x16018E0", Length = "0x48")]
			public SelectionEvent()
			{
			}
		}

		[Serializable]
		[Token(Token = "0x200005E")]
		public class TextSelectionEvent : UnityEvent<string, int, int>
		{
			[Token(Token = "0x6000374")]
			[Address(RVA = "0x1601928", Offset = "0x1601928", Length = "0x48")]
			public TextSelectionEvent()
			{
			}
		}

		[Serializable]
		[Token(Token = "0x200005F")]
		public class TouchScreenKeyboardEvent : UnityEvent<TouchScreenKeyboard.Status>
		{
			[Token(Token = "0x6000375")]
			[Address(RVA = "0x1601970", Offset = "0x1601970", Length = "0x48")]
			public TouchScreenKeyboardEvent()
			{
			}
		}

		[Token(Token = "0x2000060")]
		protected enum EditState
		{
			[Token(Token = "0x40002BF")]
			Continue = 0,
			[Token(Token = "0x40002C0")]
			Finish = 1
		}

		[CompilerGenerated]
		[Token(Token = "0x2000061")]
		private sealed class _003CCaretBlink_003Ed__276 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x40002C1")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x40002C2")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x40002C3")]
			[FieldOffset(Offset = "0x20")]
			public TMP_InputField _003C_003E4__this;

			[Token(Token = "0x170000B6")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000379")]
				[Address(RVA = "0x1601AE8", Offset = "0x1601AE8", Length = "0x8")]
				get
				{
					return null;
				}
			}

			[Token(Token = "0x170000B7")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600037B")]
				[Address(RVA = "0x1601B28", Offset = "0x1601B28", Length = "0x8")]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000376")]
			[Address(RVA = "0x16019B8", Offset = "0x16019B8", Length = "0x28")]
			public _003CCaretBlink_003Ed__276(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			[Token(Token = "0x6000377")]
			[Address(RVA = "0x16019E0", Offset = "0x16019E0", Length = "0x4")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000378")]
			[Address(RVA = "0x16019E4", Offset = "0x16019E4", Length = "0x104")]
			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x600037A")]
			[Address(RVA = "0x1601AF0", Offset = "0x1601AF0", Length = "0x38")]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000062")]
		private sealed class _003CMouseDragOutsideRect_003Ed__294 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x40002C4")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x40002C5")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x40002C6")]
			[FieldOffset(Offset = "0x20")]
			public TMP_InputField _003C_003E4__this;

			[Token(Token = "0x40002C7")]
			[FieldOffset(Offset = "0x28")]
			public PointerEventData eventData;

			[Token(Token = "0x170000B8")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600037F")]
				[Address(RVA = "0x1601D84", Offset = "0x1601D84", Length = "0x8")]
				get
				{
					return null;
				}
			}

			[Token(Token = "0x170000B9")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000381")]
				[Address(RVA = "0x1601DC4", Offset = "0x1601DC4", Length = "0x8")]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x600037C")]
			[Address(RVA = "0x1601B30", Offset = "0x1601B30", Length = "0x28")]
			public _003CMouseDragOutsideRect_003Ed__294(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			[Token(Token = "0x600037D")]
			[Address(RVA = "0x1601B58", Offset = "0x1601B58", Length = "0x4")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x600037E")]
			[Address(RVA = "0x1601B5C", Offset = "0x1601B5C", Length = "0x228")]
			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x6000380")]
			[Address(RVA = "0x1601D8C", Offset = "0x1601D8C", Length = "0x38")]
			void IEnumerator.Reset()
			{
			}
		}

		[Token(Token = "0x4000242")]
		[FieldOffset(Offset = "0x100")]
		protected TouchScreenKeyboard m_SoftKeyboard;

		[Token(Token = "0x4000243")]
		private static readonly char[] kSeparators;

		[Token(Token = "0x4000244")]
		[FieldOffset(Offset = "0x108")]
		protected RectTransform m_RectTransform;

		[SerializeField]
		[Token(Token = "0x4000245")]
		[FieldOffset(Offset = "0x110")]
		protected RectTransform m_TextViewport;

		[Token(Token = "0x4000246")]
		[FieldOffset(Offset = "0x118")]
		protected RectMask2D m_TextComponentRectMask;

		[Token(Token = "0x4000247")]
		[FieldOffset(Offset = "0x120")]
		protected RectMask2D m_TextViewportRectMask;

		[Token(Token = "0x4000248")]
		[FieldOffset(Offset = "0x128")]
		private Rect m_CachedViewportRect;

		[SerializeField]
		[Token(Token = "0x4000249")]
		[FieldOffset(Offset = "0x138")]
		protected TMP_Text m_TextComponent;

		[Token(Token = "0x400024A")]
		[FieldOffset(Offset = "0x140")]
		protected RectTransform m_TextComponentRectTransform;

		[SerializeField]
		[Token(Token = "0x400024B")]
		[FieldOffset(Offset = "0x148")]
		protected Graphic m_Placeholder;

		[SerializeField]
		[Token(Token = "0x400024C")]
		[FieldOffset(Offset = "0x150")]
		protected Scrollbar m_VerticalScrollbar;

		[SerializeField]
		[Token(Token = "0x400024D")]
		[FieldOffset(Offset = "0x158")]
		protected TMP_ScrollbarEventHandler m_VerticalScrollbarEventHandler;

		[Token(Token = "0x400024E")]
		[FieldOffset(Offset = "0x160")]
		private bool m_IsDrivenByLayoutComponents;

		[SerializeField]
		[Token(Token = "0x400024F")]
		[FieldOffset(Offset = "0x168")]
		private LayoutGroup m_LayoutGroup;

		[Token(Token = "0x4000250")]
		[FieldOffset(Offset = "0x170")]
		private IScrollHandler m_IScrollHandlerParent;

		[Token(Token = "0x4000251")]
		[FieldOffset(Offset = "0x178")]
		private float m_ScrollPosition;

		[SerializeField]
		[Token(Token = "0x4000252")]
		[FieldOffset(Offset = "0x17C")]
		protected float m_ScrollSensitivity;

		[SerializeField]
		[Token(Token = "0x4000253")]
		[FieldOffset(Offset = "0x180")]
		private ContentType m_ContentType;

		[SerializeField]
		[Token(Token = "0x4000254")]
		[FieldOffset(Offset = "0x184")]
		private InputType m_InputType;

		[SerializeField]
		[Token(Token = "0x4000255")]
		[FieldOffset(Offset = "0x188")]
		private char m_AsteriskChar;

		[SerializeField]
		[Token(Token = "0x4000256")]
		[FieldOffset(Offset = "0x18C")]
		private TouchScreenKeyboardType m_KeyboardType;

		[SerializeField]
		[Token(Token = "0x4000257")]
		[FieldOffset(Offset = "0x190")]
		private LineType m_LineType;

		[SerializeField]
		[Token(Token = "0x4000258")]
		[FieldOffset(Offset = "0x194")]
		private bool m_HideMobileInput;

		[SerializeField]
		[Token(Token = "0x4000259")]
		[FieldOffset(Offset = "0x195")]
		private bool m_HideSoftKeyboard;

		[SerializeField]
		[Token(Token = "0x400025A")]
		[FieldOffset(Offset = "0x198")]
		private CharacterValidation m_CharacterValidation;

		[SerializeField]
		[Token(Token = "0x400025B")]
		[FieldOffset(Offset = "0x1A0")]
		private string m_RegexValue;

		[SerializeField]
		[Token(Token = "0x400025C")]
		[FieldOffset(Offset = "0x1A8")]
		private float m_GlobalPointSize;

		[SerializeField]
		[Token(Token = "0x400025D")]
		[FieldOffset(Offset = "0x1AC")]
		private int m_CharacterLimit;

		[SerializeField]
		[Token(Token = "0x400025E")]
		[FieldOffset(Offset = "0x1B0")]
		private SubmitEvent m_OnEndEdit;

		[SerializeField]
		[Token(Token = "0x400025F")]
		[FieldOffset(Offset = "0x1B8")]
		private SubmitEvent m_OnSubmit;

		[SerializeField]
		[Token(Token = "0x4000260")]
		[FieldOffset(Offset = "0x1C0")]
		private SelectionEvent m_OnSelect;

		[SerializeField]
		[Token(Token = "0x4000261")]
		[FieldOffset(Offset = "0x1C8")]
		private SelectionEvent m_OnDeselect;

		[SerializeField]
		[Token(Token = "0x4000262")]
		[FieldOffset(Offset = "0x1D0")]
		private TextSelectionEvent m_OnTextSelection;

		[SerializeField]
		[Token(Token = "0x4000263")]
		[FieldOffset(Offset = "0x1D8")]
		private TextSelectionEvent m_OnEndTextSelection;

		[SerializeField]
		[Token(Token = "0x4000264")]
		[FieldOffset(Offset = "0x1E0")]
		private OnChangeEvent m_OnValueChanged;

		[SerializeField]
		[Token(Token = "0x4000265")]
		[FieldOffset(Offset = "0x1E8")]
		private TouchScreenKeyboardEvent m_OnTouchScreenKeyboardStatusChanged;

		[SerializeField]
		[Token(Token = "0x4000266")]
		[FieldOffset(Offset = "0x1F0")]
		private OnValidateInput m_OnValidateInput;

		[SerializeField]
		[Token(Token = "0x4000267")]
		[FieldOffset(Offset = "0x1F8")]
		private Color m_CaretColor;

		[SerializeField]
		[Token(Token = "0x4000268")]
		[FieldOffset(Offset = "0x208")]
		private bool m_CustomCaretColor;

		[SerializeField]
		[Token(Token = "0x4000269")]
		[FieldOffset(Offset = "0x20C")]
		private Color m_SelectionColor;

		[TextArea(5, 10)]
		[SerializeField]
		[Token(Token = "0x400026A")]
		[FieldOffset(Offset = "0x220")]
		protected string m_Text;

		[SerializeField]
		[Range(0f, 4f)]
		[Token(Token = "0x400026B")]
		[FieldOffset(Offset = "0x228")]
		private float m_CaretBlinkRate;

		[SerializeField]
		[Range(1f, 5f)]
		[Token(Token = "0x400026C")]
		[FieldOffset(Offset = "0x22C")]
		private int m_CaretWidth;

		[SerializeField]
		[Token(Token = "0x400026D")]
		[FieldOffset(Offset = "0x230")]
		private bool m_ReadOnly;

		[SerializeField]
		[Token(Token = "0x400026E")]
		[FieldOffset(Offset = "0x231")]
		private bool m_RichText;

		[Token(Token = "0x400026F")]
		[FieldOffset(Offset = "0x234")]
		protected int m_StringPosition;

		[Token(Token = "0x4000270")]
		[FieldOffset(Offset = "0x238")]
		protected int m_StringSelectPosition;

		[Token(Token = "0x4000271")]
		[FieldOffset(Offset = "0x23C")]
		protected int m_CaretPosition;

		[Token(Token = "0x4000272")]
		[FieldOffset(Offset = "0x240")]
		protected int m_CaretSelectPosition;

		[Token(Token = "0x4000273")]
		[FieldOffset(Offset = "0x248")]
		private RectTransform caretRectTrans;

		[Token(Token = "0x4000274")]
		[FieldOffset(Offset = "0x250")]
		protected UIVertex[] m_CursorVerts;

		[Token(Token = "0x4000275")]
		[FieldOffset(Offset = "0x258")]
		private CanvasRenderer m_CachedInputRenderer;

		[Token(Token = "0x4000276")]
		[FieldOffset(Offset = "0x260")]
		private Vector2 m_LastPosition;

		[NonSerialized]
		[Token(Token = "0x4000277")]
		[FieldOffset(Offset = "0x268")]
		protected Mesh m_Mesh;

		[Token(Token = "0x4000278")]
		[FieldOffset(Offset = "0x270")]
		private bool m_AllowInput;

		[Token(Token = "0x4000279")]
		[FieldOffset(Offset = "0x271")]
		private bool m_ShouldActivateNextUpdate;

		[Token(Token = "0x400027A")]
		[FieldOffset(Offset = "0x272")]
		private bool m_UpdateDrag;

		[Token(Token = "0x400027B")]
		[FieldOffset(Offset = "0x273")]
		private bool m_DragPositionOutOfBounds;

		[Token(Token = "0x400027C")]
		private const float kHScrollSpeed = 0.05f;

		[Token(Token = "0x400027D")]
		private const float kVScrollSpeed = 0.1f;

		[Token(Token = "0x400027E")]
		[FieldOffset(Offset = "0x274")]
		protected bool m_CaretVisible;

		[Token(Token = "0x400027F")]
		[FieldOffset(Offset = "0x278")]
		private Coroutine m_BlinkCoroutine;

		[Token(Token = "0x4000280")]
		[FieldOffset(Offset = "0x280")]
		private float m_BlinkStartTime;

		[Token(Token = "0x4000281")]
		[FieldOffset(Offset = "0x288")]
		private Coroutine m_DragCoroutine;

		[Token(Token = "0x4000282")]
		[FieldOffset(Offset = "0x290")]
		private string m_OriginalText;

		[Token(Token = "0x4000283")]
		[FieldOffset(Offset = "0x298")]
		private bool m_WasCanceled;

		[Token(Token = "0x4000284")]
		[FieldOffset(Offset = "0x299")]
		private bool m_HasDoneFocusTransition;

		[Token(Token = "0x4000285")]
		[FieldOffset(Offset = "0x2A0")]
		private WaitForSecondsRealtime m_WaitForSecondsRealtime;

		[Token(Token = "0x4000286")]
		[FieldOffset(Offset = "0x2A8")]
		private bool m_PreventCallback;

		[Token(Token = "0x4000287")]
		[FieldOffset(Offset = "0x2A9")]
		private bool m_TouchKeyboardAllowsInPlaceEditing;

		[Token(Token = "0x4000288")]
		[FieldOffset(Offset = "0x2AA")]
		private bool m_IsTextComponentUpdateRequired;

		[Token(Token = "0x4000289")]
		[FieldOffset(Offset = "0x2AB")]
		private bool m_isLastKeyBackspace;

		[Token(Token = "0x400028A")]
		[FieldOffset(Offset = "0x2AC")]
		private float m_PointerDownClickStartTime;

		[Token(Token = "0x400028B")]
		[FieldOffset(Offset = "0x2B0")]
		private float m_KeyDownStartTime;

		[Token(Token = "0x400028C")]
		[FieldOffset(Offset = "0x2B4")]
		private float m_DoubleClickDelay;

		[Token(Token = "0x400028D")]
		private const string kEmailSpecialCharacters = "!#$%&'*+-/=?^_`{|}~";

		[Token(Token = "0x400028E")]
		[FieldOffset(Offset = "0x2B8")]
		private bool m_IsCompositionActive;

		[Token(Token = "0x400028F")]
		[FieldOffset(Offset = "0x2B9")]
		private bool m_ShouldUpdateIMEWindowPosition;

		[Token(Token = "0x4000290")]
		[FieldOffset(Offset = "0x2BC")]
		private int m_PreviousIMEInsertionLine;

		[SerializeField]
		[Token(Token = "0x4000291")]
		[FieldOffset(Offset = "0x2C0")]
		protected TMP_FontAsset m_GlobalFontAsset;

		[SerializeField]
		[Token(Token = "0x4000292")]
		[FieldOffset(Offset = "0x2C8")]
		protected bool m_OnFocusSelectAll;

		[Token(Token = "0x4000293")]
		[FieldOffset(Offset = "0x2C9")]
		protected bool m_isSelectAll;

		[SerializeField]
		[Token(Token = "0x4000294")]
		[FieldOffset(Offset = "0x2CA")]
		protected bool m_ResetOnDeActivation;

		[Token(Token = "0x4000295")]
		[FieldOffset(Offset = "0x2CB")]
		private bool m_SelectionStillActive;

		[Token(Token = "0x4000296")]
		[FieldOffset(Offset = "0x2CC")]
		private bool m_ReleaseSelection;

		[Token(Token = "0x4000297")]
		[FieldOffset(Offset = "0x2D0")]
		private GameObject m_PreviouslySelectedObject;

		[SerializeField]
		[Token(Token = "0x4000298")]
		[FieldOffset(Offset = "0x2D8")]
		private bool m_RestoreOriginalTextOnEscape;

		[SerializeField]
		[Token(Token = "0x4000299")]
		[FieldOffset(Offset = "0x2D9")]
		protected bool m_isRichTextEditingAllowed;

		[SerializeField]
		[Token(Token = "0x400029A")]
		[FieldOffset(Offset = "0x2DC")]
		protected int m_LineLimit;

		[SerializeField]
		[Token(Token = "0x400029B")]
		[FieldOffset(Offset = "0x2E0")]
		protected TMP_InputValidator m_InputValidator;

		[Token(Token = "0x400029C")]
		[FieldOffset(Offset = "0x2E8")]
		private bool m_isSelected;

		[Token(Token = "0x400029D")]
		[FieldOffset(Offset = "0x2E9")]
		private bool m_IsStringPositionDirty;

		[Token(Token = "0x400029E")]
		[FieldOffset(Offset = "0x2EA")]
		private bool m_IsCaretPositionDirty;

		[Token(Token = "0x400029F")]
		[FieldOffset(Offset = "0x2EB")]
		private bool m_forceRectTransformAdjustment;

		[Token(Token = "0x40002A0")]
		[FieldOffset(Offset = "0x2F0")]
		private Event m_ProcessingEvent;

		[Token(Token = "0x17000075")]
		private BaseInput inputSystem
		{
			[Token(Token = "0x600028C")]
			[Address(RVA = "0x15E0720", Offset = "0x15E0720", Length = "0x110")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000076")]
		private string compositionString
		{
			[Token(Token = "0x600028D")]
			[Address(RVA = "0x15E0830", Offset = "0x15E0830", Length = "0x94")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000077")]
		private int compositionLength
		{
			[Token(Token = "0x600028E")]
			[Address(RVA = "0x15E08C4", Offset = "0x15E08C4", Length = "0x2C")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x17000078")]
		protected Mesh mesh
		{
			[Token(Token = "0x6000290")]
			[Address(RVA = "0x15E0C04", Offset = "0x15E0C04", Length = "0xA0")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000079")]
		public bool shouldHideMobileInput
		{
			[Token(Token = "0x6000291")]
			[Address(RVA = "0x15E0CA4", Offset = "0x15E0CA4", Length = "0x88")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000292")]
			[Address(RVA = "0x15E0D2C", Offset = "0x15E0D2C", Length = "0xBC")]
			set
			{
			}
		}

		[Token(Token = "0x1700007A")]
		public bool shouldHideSoftKeyboard
		{
			[Token(Token = "0x6000293")]
			[Address(RVA = "0x15E0DE8", Offset = "0x15E0DE8", Length = "0xF8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000294")]
			[Address(RVA = "0x15E0EE0", Offset = "0x15E0EE0", Length = "0x160")]
			set
			{
			}
		}

		[Token(Token = "0x1700007B")]
		public string text
		{
			[Token(Token = "0x6000296")]
			[Address(RVA = "0x15E10D8", Offset = "0x15E10D8", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000297")]
			[Address(RVA = "0x15E10E0", Offset = "0x15E10E0", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700007C")]
		public bool isFocused
		{
			[Token(Token = "0x600029A")]
			[Address(RVA = "0x15E1704", Offset = "0x15E1704", Length = "0x8")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x1700007D")]
		public float caretBlinkRate
		{
			[Token(Token = "0x600029B")]
			[Address(RVA = "0x15E170C", Offset = "0x15E170C", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600029C")]
			[Address(RVA = "0x15E1714", Offset = "0x15E1714", Length = "0x7C")]
			set
			{
			}
		}

		[Token(Token = "0x1700007E")]
		public int caretWidth
		{
			[Token(Token = "0x600029D")]
			[Address(RVA = "0x15E17E4", Offset = "0x15E17E4", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x600029E")]
			[Address(RVA = "0x15E17EC", Offset = "0x15E17EC", Length = "0x74")]
			set
			{
			}
		}

		[Token(Token = "0x1700007F")]
		public RectTransform textViewport
		{
			[Token(Token = "0x600029F")]
			[Address(RVA = "0x15E18B8", Offset = "0x15E18B8", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60002A0")]
			[Address(RVA = "0x15D1DA0", Offset = "0x15D1DA0", Length = "0x58")]
			set
			{
			}
		}

		[Token(Token = "0x17000080")]
		public TMP_Text textComponent
		{
			[Token(Token = "0x60002A1")]
			[Address(RVA = "0x15E18C0", Offset = "0x15E18C0", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60002A2")]
			[Address(RVA = "0x15D1DF8", Offset = "0x15D1DF8", Length = "0x74")]
			set
			{
			}
		}

		[Token(Token = "0x17000081")]
		public Graphic placeholder
		{
			[Token(Token = "0x60002A3")]
			[Address(RVA = "0x15E18C8", Offset = "0x15E18C8", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60002A4")]
			[Address(RVA = "0x15D1E6C", Offset = "0x15D1E6C", Length = "0x58")]
			set
			{
			}
		}

		[Token(Token = "0x17000082")]
		public Scrollbar verticalScrollbar
		{
			[Token(Token = "0x60002A5")]
			[Address(RVA = "0x15E18D0", Offset = "0x15E18D0", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60002A6")]
			[Address(RVA = "0x15E18D8", Offset = "0x15E18D8", Length = "0x1B4")]
			set
			{
			}
		}

		[Token(Token = "0x17000083")]
		public float scrollSensitivity
		{
			[Token(Token = "0x60002A7")]
			[Address(RVA = "0x15E1A8C", Offset = "0x15E1A8C", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60002A8")]
			[Address(RVA = "0x15E1A94", Offset = "0x15E1A94", Length = "0x74")]
			set
			{
			}
		}

		[Token(Token = "0x17000084")]
		public Color caretColor
		{
			[Token(Token = "0x60002A9")]
			[Address(RVA = "0x15E1B08", Offset = "0x15E1B08", Length = "0x44")]
			get
			{
				return default(Color);
			}
			[Token(Token = "0x60002AA")]
			[Address(RVA = "0x15E1B4C", Offset = "0x15E1B4C", Length = "0x2C")]
			set
			{
			}
		}

		[Token(Token = "0x17000085")]
		public bool customCaretColor
		{
			[Token(Token = "0x60002AB")]
			[Address(RVA = "0x15E1B78", Offset = "0x15E1B78", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60002AC")]
			[Address(RVA = "0x15E1B80", Offset = "0x15E1B80", Length = "0x1C")]
			set
			{
			}
		}

		[Token(Token = "0x17000086")]
		public Color selectionColor
		{
			[Token(Token = "0x60002AD")]
			[Address(RVA = "0x15E1B9C", Offset = "0x15E1B9C", Length = "0x14")]
			get
			{
				return default(Color);
			}
			[Token(Token = "0x60002AE")]
			[Address(RVA = "0x15E1BB0", Offset = "0x15E1BB0", Length = "0x2C")]
			set
			{
			}
		}

		[Token(Token = "0x17000087")]
		public SubmitEvent onEndEdit
		{
			[Token(Token = "0x60002AF")]
			[Address(RVA = "0x15E1BDC", Offset = "0x15E1BDC", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60002B0")]
			[Address(RVA = "0x15E1BE4", Offset = "0x15E1BE4", Length = "0x58")]
			set
			{
			}
		}

		[Token(Token = "0x17000088")]
		public SubmitEvent onSubmit
		{
			[Token(Token = "0x60002B1")]
			[Address(RVA = "0x15E1C3C", Offset = "0x15E1C3C", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60002B2")]
			[Address(RVA = "0x15E1C44", Offset = "0x15E1C44", Length = "0x58")]
			set
			{
			}
		}

		[Token(Token = "0x17000089")]
		public SelectionEvent onSelect
		{
			[Token(Token = "0x60002B3")]
			[Address(RVA = "0x15E1C9C", Offset = "0x15E1C9C", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60002B4")]
			[Address(RVA = "0x15E1CA4", Offset = "0x15E1CA4", Length = "0x58")]
			set
			{
			}
		}

		[Token(Token = "0x1700008A")]
		public SelectionEvent onDeselect
		{
			[Token(Token = "0x60002B5")]
			[Address(RVA = "0x15E1CFC", Offset = "0x15E1CFC", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60002B6")]
			[Address(RVA = "0x15E1D04", Offset = "0x15E1D04", Length = "0x58")]
			set
			{
			}
		}

		[Token(Token = "0x1700008B")]
		public TextSelectionEvent onTextSelection
		{
			[Token(Token = "0x60002B7")]
			[Address(RVA = "0x15E1D5C", Offset = "0x15E1D5C", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60002B8")]
			[Address(RVA = "0x15E1D64", Offset = "0x15E1D64", Length = "0x58")]
			set
			{
			}
		}

		[Token(Token = "0x1700008C")]
		public TextSelectionEvent onEndTextSelection
		{
			[Token(Token = "0x60002B9")]
			[Address(RVA = "0x15E1DBC", Offset = "0x15E1DBC", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60002BA")]
			[Address(RVA = "0x15E1DC4", Offset = "0x15E1DC4", Length = "0x58")]
			set
			{
			}
		}

		[Token(Token = "0x1700008D")]
		public OnChangeEvent onValueChanged
		{
			[Token(Token = "0x60002BB")]
			[Address(RVA = "0x15E1E1C", Offset = "0x15E1E1C", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60002BC")]
			[Address(RVA = "0x15E1E24", Offset = "0x15E1E24", Length = "0x58")]
			set
			{
			}
		}

		[Token(Token = "0x1700008E")]
		public TouchScreenKeyboardEvent onTouchScreenKeyboardStatusChanged
		{
			[Token(Token = "0x60002BD")]
			[Address(RVA = "0x15E1E7C", Offset = "0x15E1E7C", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60002BE")]
			[Address(RVA = "0x15E1E84", Offset = "0x15E1E84", Length = "0x58")]
			set
			{
			}
		}

		[Token(Token = "0x1700008F")]
		public OnValidateInput onValidateInput
		{
			[Token(Token = "0x60002BF")]
			[Address(RVA = "0x15E1EDC", Offset = "0x15E1EDC", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60002C0")]
			[Address(RVA = "0x15E1EE4", Offset = "0x15E1EE4", Length = "0x58")]
			set
			{
			}
		}

		[Token(Token = "0x17000090")]
		public int characterLimit
		{
			[Token(Token = "0x60002C1")]
			[Address(RVA = "0x15E1F3C", Offset = "0x15E1F3C", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x60002C2")]
			[Address(RVA = "0x15E1F44", Offset = "0x15E1F44", Length = "0xC0")]
			set
			{
			}
		}

		[Token(Token = "0x17000091")]
		public float pointSize
		{
			[Token(Token = "0x60002C3")]
			[Address(RVA = "0x15E2004", Offset = "0x15E2004", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60002C4")]
			[Address(RVA = "0x15E200C", Offset = "0x15E200C", Length = "0xB4")]
			set
			{
			}
		}

		[Token(Token = "0x17000092")]
		public TMP_FontAsset fontAsset
		{
			[Token(Token = "0x60002C5")]
			[Address(RVA = "0x15E21A8", Offset = "0x15E21A8", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60002C6")]
			[Address(RVA = "0x15D1EC4", Offset = "0x15D1EC4", Length = "0x80")]
			set
			{
			}
		}

		[Token(Token = "0x17000093")]
		public bool onFocusSelectAll
		{
			[Token(Token = "0x60002C7")]
			[Address(RVA = "0x15E2290", Offset = "0x15E2290", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60002C8")]
			[Address(RVA = "0x15E2298", Offset = "0x15E2298", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x17000094")]
		public bool resetOnDeActivation
		{
			[Token(Token = "0x60002C9")]
			[Address(RVA = "0x15E22A4", Offset = "0x15E22A4", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60002CA")]
			[Address(RVA = "0x15E22AC", Offset = "0x15E22AC", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x17000095")]
		public bool restoreOriginalTextOnEscape
		{
			[Token(Token = "0x60002CB")]
			[Address(RVA = "0x15E22B8", Offset = "0x15E22B8", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60002CC")]
			[Address(RVA = "0x15E22C0", Offset = "0x15E22C0", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x17000096")]
		public bool isRichTextEditingAllowed
		{
			[Token(Token = "0x60002CD")]
			[Address(RVA = "0x15E22CC", Offset = "0x15E22CC", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60002CE")]
			[Address(RVA = "0x15E22D4", Offset = "0x15E22D4", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x17000097")]
		public ContentType contentType
		{
			[Token(Token = "0x60002CF")]
			[Address(RVA = "0x15E22E0", Offset = "0x15E22E0", Length = "0x8")]
			get
			{
				return ContentType.Standard;
			}
			[Token(Token = "0x60002D0")]
			[Address(RVA = "0x15E22E8", Offset = "0x15E22E8", Length = "0x74")]
			set
			{
			}
		}

		[Token(Token = "0x17000098")]
		public LineType lineType
		{
			[Token(Token = "0x60002D1")]
			[Address(RVA = "0x15E2418", Offset = "0x15E2418", Length = "0x8")]
			get
			{
				return LineType.SingleLine;
			}
			[Token(Token = "0x60002D2")]
			[Address(RVA = "0x15E2420", Offset = "0x15E2420", Length = "0xC0")]
			set
			{
			}
		}

		[Token(Token = "0x17000099")]
		public int lineLimit
		{
			[Token(Token = "0x60002D3")]
			[Address(RVA = "0x15E2544", Offset = "0x15E2544", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x60002D4")]
			[Address(RVA = "0x15E254C", Offset = "0x15E254C", Length = "0x6C")]
			set
			{
			}
		}

		[Token(Token = "0x1700009A")]
		public InputType inputType
		{
			[Token(Token = "0x60002D5")]
			[Address(RVA = "0x15E25B8", Offset = "0x15E25B8", Length = "0x8")]
			get
			{
				return InputType.Standard;
			}
			[Token(Token = "0x60002D6")]
			[Address(RVA = "0x15E25C0", Offset = "0x15E25C0", Length = "0x84")]
			set
			{
			}
		}

		[Token(Token = "0x1700009B")]
		public TouchScreenKeyboardType keyboardType
		{
			[Token(Token = "0x60002D7")]
			[Address(RVA = "0x15E265C", Offset = "0x15E265C", Length = "0x8")]
			get
			{
				return TouchScreenKeyboardType.Default;
			}
			[Token(Token = "0x60002D8")]
			[Address(RVA = "0x15E2664", Offset = "0x15E2664", Length = "0x84")]
			set
			{
			}
		}

		[Token(Token = "0x1700009C")]
		public CharacterValidation characterValidation
		{
			[Token(Token = "0x60002D9")]
			[Address(RVA = "0x15E26E8", Offset = "0x15E26E8", Length = "0x8")]
			get
			{
				return CharacterValidation.None;
			}
			[Token(Token = "0x60002DA")]
			[Address(RVA = "0x15E26F0", Offset = "0x15E26F0", Length = "0x84")]
			set
			{
			}
		}

		[Token(Token = "0x1700009D")]
		public TMP_InputValidator inputValidator
		{
			[Token(Token = "0x60002DB")]
			[Address(RVA = "0x15E2774", Offset = "0x15E2774", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60002DC")]
			[Address(RVA = "0x15E277C", Offset = "0x15E277C", Length = "0x84")]
			set
			{
			}
		}

		[Token(Token = "0x1700009E")]
		public bool readOnly
		{
			[Token(Token = "0x60002DD")]
			[Address(RVA = "0x15E2818", Offset = "0x15E2818", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60002DE")]
			[Address(RVA = "0x15E2820", Offset = "0x15E2820", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x1700009F")]
		public bool richText
		{
			[Token(Token = "0x60002DF")]
			[Address(RVA = "0x15E282C", Offset = "0x15E282C", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60002E0")]
			[Address(RVA = "0x15E2834", Offset = "0x15E2834", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x170000A0")]
		public bool multiLine
		{
			[Token(Token = "0x60002E1")]
			[Address(RVA = "0x15E28C8", Offset = "0x15E28C8", Length = "0x14")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x170000A1")]
		public char asteriskChar
		{
			[Token(Token = "0x60002E2")]
			[Address(RVA = "0x15E28DC", Offset = "0x15E28DC", Length = "0x8")]
			get
			{
				return '\0';
			}
			[Token(Token = "0x60002E3")]
			[Address(RVA = "0x15E28E4", Offset = "0x15E28E4", Length = "0x74")]
			set
			{
			}
		}

		[Token(Token = "0x170000A2")]
		public bool wasCanceled
		{
			[Token(Token = "0x60002E4")]
			[Address(RVA = "0x15E2958", Offset = "0x15E2958", Length = "0x8")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x170000A3")]
		protected int caretPositionInternal
		{
			[Token(Token = "0x60002E7")]
			[Address(RVA = "0x15E29DC", Offset = "0x15E29DC", Length = "0x18")]
			get
			{
				return 0;
			}
			[Token(Token = "0x60002E8")]
			[Address(RVA = "0x15E29F4", Offset = "0x15E29F4", Length = "0x10")]
			set
			{
			}
		}

		[Token(Token = "0x170000A4")]
		protected int stringPositionInternal
		{
			[Token(Token = "0x60002E9")]
			[Address(RVA = "0x15E2A04", Offset = "0x15E2A04", Length = "0x18")]
			get
			{
				return 0;
			}
			[Token(Token = "0x60002EA")]
			[Address(RVA = "0x15E2A1C", Offset = "0x15E2A1C", Length = "0x38")]
			set
			{
			}
		}

		[Token(Token = "0x170000A5")]
		protected int caretSelectPositionInternal
		{
			[Token(Token = "0x60002EB")]
			[Address(RVA = "0x15E2A54", Offset = "0x15E2A54", Length = "0x18")]
			get
			{
				return 0;
			}
			[Token(Token = "0x60002EC")]
			[Address(RVA = "0x15E2A6C", Offset = "0x15E2A6C", Length = "0x10")]
			set
			{
			}
		}

		[Token(Token = "0x170000A6")]
		protected int stringSelectPositionInternal
		{
			[Token(Token = "0x60002ED")]
			[Address(RVA = "0x15E2A7C", Offset = "0x15E2A7C", Length = "0x18")]
			get
			{
				return 0;
			}
			[Token(Token = "0x60002EE")]
			[Address(RVA = "0x15E2A94", Offset = "0x15E2A94", Length = "0x38")]
			set
			{
			}
		}

		[Token(Token = "0x170000A7")]
		private bool hasSelection
		{
			[Token(Token = "0x60002EF")]
			[Address(RVA = "0x15E2ACC", Offset = "0x15E2ACC", Length = "0x3C")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x170000A8")]
		public int caretPosition
		{
			[Token(Token = "0x60002F0")]
			[Address(RVA = "0x15E2B08", Offset = "0x15E2B08", Length = "0x18")]
			get
			{
				return 0;
			}
			[Token(Token = "0x60002F1")]
			[Address(RVA = "0x15E2B20", Offset = "0x15E2B20", Length = "0x34")]
			set
			{
			}
		}

		[Token(Token = "0x170000A9")]
		public int selectionAnchorPosition
		{
			[Token(Token = "0x60002F2")]
			[Address(RVA = "0x15E2BCC", Offset = "0x15E2BCC", Length = "0x18")]
			get
			{
				return 0;
			}
			[Token(Token = "0x60002F3")]
			[Address(RVA = "0x15E2B54", Offset = "0x15E2B54", Length = "0x3C")]
			set
			{
			}
		}

		[Token(Token = "0x170000AA")]
		public int selectionFocusPosition
		{
			[Token(Token = "0x60002F4")]
			[Address(RVA = "0x15E2BE4", Offset = "0x15E2BE4", Length = "0x18")]
			get
			{
				return 0;
			}
			[Token(Token = "0x60002F5")]
			[Address(RVA = "0x15E2B90", Offset = "0x15E2B90", Length = "0x3C")]
			set
			{
			}
		}

		[Token(Token = "0x170000AB")]
		public int stringPosition
		{
			[Token(Token = "0x60002F6")]
			[Address(RVA = "0x15E2BFC", Offset = "0x15E2BFC", Length = "0x18")]
			get
			{
				return 0;
			}
			[Token(Token = "0x60002F7")]
			[Address(RVA = "0x15E2C14", Offset = "0x15E2C14", Length = "0x34")]
			set
			{
			}
		}

		[Token(Token = "0x170000AC")]
		public int selectionStringAnchorPosition
		{
			[Token(Token = "0x60002F8")]
			[Address(RVA = "0x15E2CF8", Offset = "0x15E2CF8", Length = "0x18")]
			get
			{
				return 0;
			}
			[Token(Token = "0x60002F9")]
			[Address(RVA = "0x15E2C48", Offset = "0x15E2C48", Length = "0x58")]
			set
			{
			}
		}

		[Token(Token = "0x170000AD")]
		public int selectionStringFocusPosition
		{
			[Token(Token = "0x60002FA")]
			[Address(RVA = "0x15E2D10", Offset = "0x15E2D10", Length = "0x18")]
			get
			{
				return 0;
			}
			[Token(Token = "0x60002FB")]
			[Address(RVA = "0x15E2CA0", Offset = "0x15E2CA0", Length = "0x58")]
			set
			{
			}
		}

		[Token(Token = "0x170000AE")]
		private static string clipboard
		{
			[Token(Token = "0x6000308")]
			[Address(RVA = "0x15E4788", Offset = "0x15E4788", Length = "0x50")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000309")]
			[Address(RVA = "0x15E47D8", Offset = "0x15E47D8", Length = "0x58")]
			set
			{
			}
		}

		[Token(Token = "0x170000AF")]
		public virtual float minWidth
		{
			[Token(Token = "0x6000362")]
			[Address(RVA = "0x15EB348", Offset = "0x15EB348", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x170000B0")]
		public virtual float preferredWidth
		{
			[Token(Token = "0x6000363")]
			[Address(RVA = "0x15EB350", Offset = "0x15EB350", Length = "0x130")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x170000B1")]
		public virtual float flexibleWidth
		{
			[Token(Token = "0x6000364")]
			[Address(RVA = "0x15EB480", Offset = "0x15EB480", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x170000B2")]
		public virtual float minHeight
		{
			[Token(Token = "0x6000365")]
			[Address(RVA = "0x15EB488", Offset = "0x15EB488", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x170000B3")]
		public virtual float preferredHeight
		{
			[Token(Token = "0x6000366")]
			[Address(RVA = "0x15EB490", Offset = "0x15EB490", Length = "0x130")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x170000B4")]
		public virtual float flexibleHeight
		{
			[Token(Token = "0x6000367")]
			[Address(RVA = "0x15EB5C0", Offset = "0x15EB5C0", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x170000B5")]
		public virtual int layoutPriority
		{
			[Token(Token = "0x6000368")]
			[Address(RVA = "0x15EB5C8", Offset = "0x15EB5C8", Length = "0x8")]
			get
			{
				return 0;
			}
		}

		Transform ICanvasElement.transform
		{
			[Token(Token = "0x600036C")]
			[Address(RVA = "0x15EB664", Offset = "0x15EB664", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x600028F")]
		[Address(RVA = "0x15E08F0", Offset = "0x15E08F0", Length = "0x280")]
		protected TMP_InputField()
		{
		}

		[Token(Token = "0x6000295")]
		[Address(RVA = "0x15E1040", Offset = "0x15E1040", Length = "0x98")]
		private bool isKeyboardUsingEvents()
		{
			return false;
		}

		[Token(Token = "0x6000298")]
		[Address(RVA = "0x15E121C", Offset = "0x15E121C", Length = "0x8")]
		public void SetTextWithoutNotify(string input)
		{
		}

		[Token(Token = "0x6000299")]
		[Address(RVA = "0x15E10E8", Offset = "0x15E10E8", Length = "0x134")]
		private void SetText(string value, bool sendCallback = true)
		{
		}

		[Token(Token = "0x60002E5")]
		[Address(RVA = "0x15E2960", Offset = "0x15E2960", Length = "0x38")]
		protected void ClampStringPos(ref int pos)
		{
		}

		[Token(Token = "0x60002E6")]
		[Address(RVA = "0x15E2998", Offset = "0x15E2998", Length = "0x44")]
		protected void ClampCaretPos(ref int pos)
		{
		}

		[Token(Token = "0x60002FC")]
		[Address(RVA = "0x15E2D28", Offset = "0x15E2D28", Length = "0x734")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x60002FD")]
		[Address(RVA = "0x15E3960", Offset = "0x15E3960", Length = "0x320")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x60002FE")]
		[Address(RVA = "0x15E3E3C", Offset = "0x15E3E3C", Length = "0x138")]
		private void ON_TEXT_CHANGED(UnityEngine.Object obj)
		{
		}

		[IteratorStateMachine(typeof(_003CCaretBlink_003Ed__276))]
		[Token(Token = "0x60002FF")]
		[Address(RVA = "0x15E40BC", Offset = "0x15E40BC", Length = "0x68")]
		private IEnumerator CaretBlink()
		{
			return null;
		}

		[Token(Token = "0x6000300")]
		[Address(RVA = "0x15E4124", Offset = "0x15E4124", Length = "0x38")]
		private void SetCaretVisible()
		{
		}

		[Token(Token = "0x6000301")]
		[Address(RVA = "0x15E1790", Offset = "0x15E1790", Length = "0x54")]
		private void SetCaretActive()
		{
		}

		[Token(Token = "0x6000302")]
		[Address(RVA = "0x15E415C", Offset = "0x15E415C", Length = "0x10")]
		protected void OnFocus()
		{
		}

		[Token(Token = "0x6000303")]
		[Address(RVA = "0x15E416C", Offset = "0x15E416C", Length = "0x38")]
		protected void SelectAll()
		{
		}

		[Token(Token = "0x6000304")]
		[Address(RVA = "0x15E41A4", Offset = "0x15E41A4", Length = "0x138")]
		public void MoveTextEnd(bool shift)
		{
		}

		[Token(Token = "0x6000305")]
		[Address(RVA = "0x15E433C", Offset = "0x15E433C", Length = "0x13C")]
		public void MoveTextStart(bool shift)
		{
		}

		[Token(Token = "0x6000306")]
		[Address(RVA = "0x15E4478", Offset = "0x15E4478", Length = "0x180")]
		public void MoveToEndOfLine(bool shift, bool ctrl)
		{
		}

		[Token(Token = "0x6000307")]
		[Address(RVA = "0x15E45F8", Offset = "0x15E45F8", Length = "0x190")]
		public void MoveToStartOfLine(bool shift, bool ctrl)
		{
		}

		[Token(Token = "0x600030A")]
		[Address(RVA = "0x15E4830", Offset = "0x15E4830", Length = "0x104")]
		private bool InPlaceEditing()
		{
			return false;
		}

		[Token(Token = "0x600030B")]
		[Address(RVA = "0x15E4934", Offset = "0x15E4934", Length = "0x148")]
		private void UpdateStringPositionFromKeyboard()
		{
		}

		[Token(Token = "0x600030C")]
		[Address(RVA = "0x15E4A7C", Offset = "0x15E4A7C", Length = "0x648")]
		protected virtual void LateUpdate()
		{
		}

		[Token(Token = "0x600030D")]
		[Address(RVA = "0x15E5D44", Offset = "0x15E5D44", Length = "0xD8")]
		private bool MayDrag(PointerEventData eventData)
		{
			return false;
		}

		[Token(Token = "0x600030E")]
		[Address(RVA = "0x15E5E1C", Offset = "0x15E5E1C", Length = "0x20")]
		public virtual void OnBeginDrag(PointerEventData eventData)
		{
		}

		[Token(Token = "0x600030F")]
		[Address(RVA = "0x15E5E3C", Offset = "0x15E5E3C", Length = "0x294")]
		public virtual void OnDrag(PointerEventData eventData)
		{
		}

		[IteratorStateMachine(typeof(_003CMouseDragOutsideRect_003Ed__294))]
		[Token(Token = "0x6000310")]
		[Address(RVA = "0x15E60D0", Offset = "0x15E60D0", Length = "0x74")]
		private IEnumerator MouseDragOutsideRect(PointerEventData eventData)
		{
			return null;
		}

		[Token(Token = "0x6000311")]
		[Address(RVA = "0x15E6144", Offset = "0x15E6144", Length = "0x1C")]
		public virtual void OnEndDrag(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000312")]
		[Address(RVA = "0x15E6160", Offset = "0x15E6160", Length = "0x738")]
		public override void OnPointerDown(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000313")]
		[Address(RVA = "0x15E6898", Offset = "0x15E6898", Length = "0x424")]
		protected EditState KeyPressed(Event evt)
		{
			return EditState.Continue;
		}

		[Token(Token = "0x6000314")]
		[Address(RVA = "0x15E7CD8", Offset = "0x15E7CD8", Length = "0x20")]
		protected virtual bool IsValidChar(char c)
		{
			return false;
		}

		[Token(Token = "0x6000315")]
		[Address(RVA = "0x15E7CF8", Offset = "0x15E7CF8", Length = "0x4")]
		public void ProcessEvent(Event e)
		{
		}

		[Token(Token = "0x6000316")]
		[Address(RVA = "0x15E7CFC", Offset = "0x15E7CFC", Length = "0x1A0")]
		public virtual void OnUpdateSelected(BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000317")]
		[Address(RVA = "0x15E7EF8", Offset = "0x15E7EF8", Length = "0x1B8")]
		public virtual void OnScroll(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000318")]
		[Address(RVA = "0x15E80B0", Offset = "0x15E80B0", Length = "0xE0")]
		private float GetScrollPositionRelativeToViewport()
		{
			return 0f;
		}

		[Token(Token = "0x6000319")]
		[Address(RVA = "0x15E7268", Offset = "0x15E7268", Length = "0xC0")]
		private string GetSelectedString()
		{
			return null;
		}

		[Token(Token = "0x600031A")]
		[Address(RVA = "0x15E8328", Offset = "0x15E8328", Length = "0xD4")]
		private int FindNextWordBegin()
		{
			return 0;
		}

		[Token(Token = "0x600031B")]
		[Address(RVA = "0x15E78AC", Offset = "0x15E78AC", Length = "0x3FC")]
		private void MoveRight(bool shift, bool ctrl)
		{
		}

		[Token(Token = "0x600031C")]
		[Address(RVA = "0x15E83FC", Offset = "0x15E83FC", Length = "0xB8")]
		private int FindPrevWordBegin()
		{
			return 0;
		}

		[Token(Token = "0x600031D")]
		[Address(RVA = "0x15E74FC", Offset = "0x15E74FC", Length = "0x3B0")]
		private void MoveLeft(bool shift, bool ctrl)
		{
		}

		[Token(Token = "0x600031E")]
		[Address(RVA = "0x15E84B4", Offset = "0x15E84B4", Length = "0x150")]
		private int LineUpCharacterPosition(int originalPos, bool goToFirstChar)
		{
			return 0;
		}

		[Token(Token = "0x600031F")]
		[Address(RVA = "0x15E8604", Offset = "0x15E8604", Length = "0x14C")]
		private int LineDownCharacterPosition(int originalPos, bool goToLastChar)
		{
			return 0;
		}

		[Token(Token = "0x6000320")]
		[Address(RVA = "0x15E8750", Offset = "0x15E8750", Length = "0x1E4")]
		private int PageUpCharacterPosition(int originalPos, bool goToFirstChar)
		{
			return 0;
		}

		[Token(Token = "0x6000321")]
		[Address(RVA = "0x15E8934", Offset = "0x15E8934", Length = "0x1EC")]
		private int PageDownCharacterPosition(int originalPos, bool goToLastChar)
		{
			return 0;
		}

		[Token(Token = "0x6000322")]
		[Address(RVA = "0x15E7CB4", Offset = "0x15E7CB4", Length = "0xC")]
		private void MoveDown(bool shift)
		{
		}

		[Token(Token = "0x6000323")]
		[Address(RVA = "0x15E8B20", Offset = "0x15E8B20", Length = "0x1C4")]
		private void MoveDown(bool shift, bool goToLastChar)
		{
		}

		[Token(Token = "0x6000324")]
		[Address(RVA = "0x15E7CA8", Offset = "0x15E7CA8", Length = "0xC")]
		private void MoveUp(bool shift)
		{
		}

		[Token(Token = "0x6000325")]
		[Address(RVA = "0x15E8CE4", Offset = "0x15E8CE4", Length = "0x1B0")]
		private void MoveUp(bool shift, bool goToFirstChar)
		{
		}

		[Token(Token = "0x6000326")]
		[Address(RVA = "0x15E7CC0", Offset = "0x15E7CC0", Length = "0xC")]
		private void MovePageUp(bool shift)
		{
		}

		[Token(Token = "0x6000327")]
		[Address(RVA = "0x15E8E94", Offset = "0x15E8E94", Length = "0x2AC")]
		private void MovePageUp(bool shift, bool goToFirstChar)
		{
		}

		[Token(Token = "0x6000328")]
		[Address(RVA = "0x15E7CCC", Offset = "0x15E7CCC", Length = "0xC")]
		private void MovePageDown(bool shift)
		{
		}

		[Token(Token = "0x6000329")]
		[Address(RVA = "0x15E9140", Offset = "0x15E9140", Length = "0x2BC")]
		private void MovePageDown(bool shift, bool goToLastChar)
		{
		}

		[Token(Token = "0x600032A")]
		[Address(RVA = "0x15E7328", Offset = "0x15E7328", Length = "0x198")]
		private void Delete()
		{
		}

		[Token(Token = "0x600032B")]
		[Address(RVA = "0x15E7044", Offset = "0x15E7044", Length = "0x224")]
		private void DeleteKey()
		{
		}

		[Token(Token = "0x600032C")]
		[Address(RVA = "0x15E6CBC", Offset = "0x15E6CBC", Length = "0x388")]
		private void Backspace()
		{
		}

		[Token(Token = "0x600032D")]
		[Address(RVA = "0x15E93FC", Offset = "0x15E93FC", Length = "0xB0")]
		protected virtual void Append(string input)
		{
		}

		[Token(Token = "0x600032E")]
		[Address(RVA = "0x15E94AC", Offset = "0x15E94AC", Length = "0x23C")]
		protected virtual void Append(char input)
		{
		}

		[Token(Token = "0x600032F")]
		[Address(RVA = "0x15E96E8", Offset = "0x15E96E8", Length = "0x110")]
		private void Insert(char c)
		{
		}

		[Token(Token = "0x6000330")]
		[Address(RVA = "0x15E74C0", Offset = "0x15E74C0", Length = "0x3C")]
		private void UpdateTouchKeyboardFromEditChanges()
		{
		}

		[Token(Token = "0x6000331")]
		[Address(RVA = "0x15E5D2C", Offset = "0x15E5D2C", Length = "0x18")]
		private void SendOnValueChangedAndUpdateLabel()
		{
		}

		[Token(Token = "0x6000332")]
		[Address(RVA = "0x15E16A8", Offset = "0x15E16A8", Length = "0x5C")]
		private void SendOnValueChanged()
		{
		}

		[Token(Token = "0x6000333")]
		[Address(RVA = "0x15E97F8", Offset = "0x15E97F8", Length = "0x5C")]
		protected void SendOnEndEdit()
		{
		}

		[Token(Token = "0x6000334")]
		[Address(RVA = "0x15E7E9C", Offset = "0x15E7E9C", Length = "0x5C")]
		protected void SendOnSubmit()
		{
		}

		[Token(Token = "0x6000335")]
		[Address(RVA = "0x15E9854", Offset = "0x15E9854", Length = "0x5C")]
		protected void SendOnFocus()
		{
		}

		[Token(Token = "0x6000336")]
		[Address(RVA = "0x15E98B0", Offset = "0x15E98B0", Length = "0x5C")]
		protected void SendOnFocusLost()
		{
		}

		[Token(Token = "0x6000337")]
		[Address(RVA = "0x15E990C", Offset = "0x15E990C", Length = "0xA8")]
		protected void SendOnTextSelection()
		{
		}

		[Token(Token = "0x6000338")]
		[Address(RVA = "0x15E99B4", Offset = "0x15E99B4", Length = "0x94")]
		protected void SendOnEndTextSelection()
		{
		}

		[Token(Token = "0x6000339")]
		[Address(RVA = "0x15E54CC", Offset = "0x15E54CC", Length = "0x74")]
		protected void SendTouchScreenKeyboardStatusChanged()
		{
		}

		[Token(Token = "0x600033A")]
		[Address(RVA = "0x15E1224", Offset = "0x15E1224", Length = "0x484")]
		protected void UpdateLabel()
		{
		}

		[Token(Token = "0x600033B")]
		[Address(RVA = "0x15E3FE4", Offset = "0x15E3FE4", Length = "0xD8")]
		private void UpdateScrollbar()
		{
		}

		[Token(Token = "0x600033C")]
		[Address(RVA = "0x15E9A48", Offset = "0x15E9A48", Length = "0x3C")]
		private void OnScrollbarValueChange(float value)
		{
		}

		[Token(Token = "0x600033D")]
		[Address(RVA = "0x15E395C", Offset = "0x15E395C", Length = "0x4")]
		private void UpdateMaskRegions()
		{
		}

		[Token(Token = "0x600033E")]
		[Address(RVA = "0x15E8190", Offset = "0x15E8190", Length = "0x198")]
		private void AdjustTextPositionRelativeToViewport(float relativePosition)
		{
		}

		[Token(Token = "0x600033F")]
		[Address(RVA = "0x15E3F74", Offset = "0x15E3F74", Length = "0x70")]
		private int GetCaretPositionFromStringIndex(int stringIndex)
		{
			return 0;
		}

		[Token(Token = "0x6000340")]
		[Address(RVA = "0x15E9A84", Offset = "0x15E9A84", Length = "0x74")]
		private int GetMinCaretPositionFromStringIndex(int stringIndex)
		{
			return 0;
		}

		[Token(Token = "0x6000341")]
		[Address(RVA = "0x15E9AF8", Offset = "0x15E9AF8", Length = "0x70")]
		private int GetMaxCaretPositionFromStringIndex(int stringIndex)
		{
			return 0;
		}

		[Token(Token = "0x6000342")]
		[Address(RVA = "0x15E42DC", Offset = "0x15E42DC", Length = "0x60")]
		private int GetStringIndexFromCaretPosition(int caretPosition)
		{
			return 0;
		}

		[Token(Token = "0x6000343")]
		[Address(RVA = "0x15E9B68", Offset = "0x15E9B68", Length = "0x4")]
		public void ForceLabelUpdate()
		{
		}

		[Token(Token = "0x6000344")]
		[Address(RVA = "0x15E1860", Offset = "0x15E1860", Length = "0x58")]
		private void MarkGeometryAsDirty()
		{
		}

		[Token(Token = "0x6000345")]
		[Address(RVA = "0x15E9B6C", Offset = "0x15E9B6C", Length = "0x10")]
		public virtual void Rebuild(CanvasUpdate update)
		{
		}

		[Token(Token = "0x6000346")]
		[Address(RVA = "0x15E9C30", Offset = "0x15E9C30", Length = "0x4")]
		public virtual void LayoutComplete()
		{
		}

		[Token(Token = "0x6000347")]
		[Address(RVA = "0x15E9C34", Offset = "0x15E9C34", Length = "0x4")]
		public virtual void GraphicUpdateComplete()
		{
		}

		[Token(Token = "0x6000348")]
		[Address(RVA = "0x15E9B7C", Offset = "0x15E9B7C", Length = "0xB4")]
		private void UpdateGeometry()
		{
		}

		[Token(Token = "0x6000349")]
		[Address(RVA = "0x15E345C", Offset = "0x15E345C", Length = "0x500")]
		private void AssignPositioningIfNeeded()
		{
		}

		[Token(Token = "0x600034A")]
		[Address(RVA = "0x15E9C38", Offset = "0x15E9C38", Length = "0x368")]
		private void OnFillVBO(Mesh vbo)
		{
		}

		[Token(Token = "0x600034B")]
		[Address(RVA = "0x15E9FA0", Offset = "0x15E9FA0", Length = "0x5E4")]
		private void GenerateCaret(VertexHelper vbo, Vector2 roundingOffset)
		{
		}

		[Token(Token = "0x600034C")]
		[Address(RVA = "0x15EAB58", Offset = "0x15EAB58", Length = "0x150")]
		private void CreateCursorVerts()
		{
		}

		[Token(Token = "0x600034D")]
		[Address(RVA = "0x15EA584", Offset = "0x15EA584", Length = "0x5D4")]
		private void GenerateHightlight(VertexHelper vbo, Vector2 roundingOffset)
		{
		}

		[Token(Token = "0x600034E")]
		[Address(RVA = "0x15EACA8", Offset = "0x15EACA8", Length = "0x480")]
		private void AdjustRectTransformRelativeToViewport(Vector2 startPosition, float height, bool isCharVisible)
		{
		}

		[Token(Token = "0x600034F")]
		[Address(RVA = "0x15E5540", Offset = "0x15E5540", Length = "0x7EC")]
		protected char Validate(string text, int pos, char ch)
		{
			return '\0';
		}

		[Token(Token = "0x6000350")]
		[Address(RVA = "0x15EB128", Offset = "0x15EB128", Length = "0x114")]
		public void ActivateInputField()
		{
		}

		[Token(Token = "0x6000351")]
		[Address(RVA = "0x15E50C4", Offset = "0x15E50C4", Length = "0x3DC")]
		private void ActivateInputFieldInternal()
		{
		}

		[Token(Token = "0x6000352")]
		[Address(RVA = "0x15EB23C", Offset = "0x15EB23C", Length = "0x24")]
		public override void OnSelect(BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000353")]
		[Address(RVA = "0x15EB260", Offset = "0x15EB260", Length = "0x24")]
		public virtual void OnPointerClick(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000354")]
		[Address(RVA = "0x15EB284", Offset = "0x15EB284", Length = "0x4")]
		public void OnControlClick()
		{
		}

		[Token(Token = "0x6000355")]
		[Address(RVA = "0x15E54A0", Offset = "0x15E54A0", Length = "0x2C")]
		public void ReleaseSelection()
		{
		}

		[Token(Token = "0x6000356")]
		[Address(RVA = "0x15E3C80", Offset = "0x15E3C80", Length = "0x1BC")]
		public void DeactivateInputField(bool clearSelection = false)
		{
		}

		[Token(Token = "0x6000357")]
		[Address(RVA = "0x15EB288", Offset = "0x15EB288", Length = "0x38")]
		public override void OnDeselect(BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000358")]
		[Address(RVA = "0x15EB2C0", Offset = "0x15EB2C0", Length = "0x54")]
		public virtual void OnSubmit(BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000359")]
		[Address(RVA = "0x15E235C", Offset = "0x15E235C", Length = "0xBC")]
		private void EnforceContentType()
		{
		}

		[Token(Token = "0x600035A")]
		[Address(RVA = "0x15E0B70", Offset = "0x15E0B70", Length = "0x94")]
		private void SetTextComponentWrapMode()
		{
		}

		[Token(Token = "0x600035B")]
		[Address(RVA = "0x15E2840", Offset = "0x15E2840", Length = "0x88")]
		private void SetTextComponentRichTextMode()
		{
		}

		[Token(Token = "0x600035C")]
		[Address(RVA = "0x15E24E0", Offset = "0x15E24E0", Length = "0x64")]
		private void SetToCustomIfContentTypeIsNot(params ContentType[] allowedContentTypes)
		{
		}

		[Token(Token = "0x600035D")]
		[Address(RVA = "0x15E2644", Offset = "0x15E2644", Length = "0x18")]
		private void SetToCustom()
		{
		}

		[Token(Token = "0x600035E")]
		[Address(RVA = "0x15E2800", Offset = "0x15E2800", Length = "0x18")]
		private void SetToCustom(CharacterValidation characterValidation)
		{
		}

		[Token(Token = "0x600035F")]
		[Address(RVA = "0x15EB314", Offset = "0x15EB314", Length = "0x2C")]
		protected override void DoStateTransition(SelectionState state, bool instant)
		{
		}

		[Token(Token = "0x6000360")]
		[Address(RVA = "0x15EB340", Offset = "0x15EB340", Length = "0x4")]
		public virtual void CalculateLayoutInputHorizontal()
		{
		}

		[Token(Token = "0x6000361")]
		[Address(RVA = "0x15EB344", Offset = "0x15EB344", Length = "0x4")]
		public virtual void CalculateLayoutInputVertical()
		{
		}

		[Token(Token = "0x6000369")]
		[Address(RVA = "0x15E20C0", Offset = "0x15E20C0", Length = "0xE8")]
		public void SetGlobalPointSize(float pointSize)
		{
		}

		[Token(Token = "0x600036A")]
		[Address(RVA = "0x15E21B0", Offset = "0x15E21B0", Length = "0xE0")]
		public void SetGlobalFontAsset(TMP_FontAsset fontAsset)
		{
		}
	}
}
