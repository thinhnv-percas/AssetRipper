using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace UnityEngine.UI
{
	[AddComponentMenu("UI/Legacy/Input Field", 103)]
	[Token(Token = "0x200002E")]
	public class InputField : Selectable, IUpdateSelectedHandler, IEventSystemHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler, ISubmitHandler, ICanvasElement, ILayoutElement
	{
		[Token(Token = "0x200002F")]
		public enum ContentType
		{
			[Token(Token = "0x4000104")]
			Standard = 0,
			[Token(Token = "0x4000105")]
			Autocorrected = 1,
			[Token(Token = "0x4000106")]
			IntegerNumber = 2,
			[Token(Token = "0x4000107")]
			DecimalNumber = 3,
			[Token(Token = "0x4000108")]
			Alphanumeric = 4,
			[Token(Token = "0x4000109")]
			Name = 5,
			[Token(Token = "0x400010A")]
			EmailAddress = 6,
			[Token(Token = "0x400010B")]
			Password = 7,
			[Token(Token = "0x400010C")]
			Pin = 8,
			[Token(Token = "0x400010D")]
			Custom = 9
		}

		[Token(Token = "0x2000030")]
		public enum InputType
		{
			[Token(Token = "0x400010F")]
			Standard = 0,
			[Token(Token = "0x4000110")]
			AutoCorrect = 1,
			[Token(Token = "0x4000111")]
			Password = 2
		}

		[Token(Token = "0x2000031")]
		public enum CharacterValidation
		{
			[Token(Token = "0x4000113")]
			None = 0,
			[Token(Token = "0x4000114")]
			Integer = 1,
			[Token(Token = "0x4000115")]
			Decimal = 2,
			[Token(Token = "0x4000116")]
			Alphanumeric = 3,
			[Token(Token = "0x4000117")]
			Name = 4,
			[Token(Token = "0x4000118")]
			EmailAddress = 5
		}

		[Token(Token = "0x2000032")]
		public enum LineType
		{
			[Token(Token = "0x400011A")]
			SingleLine = 0,
			[Token(Token = "0x400011B")]
			MultiLineSubmit = 1,
			[Token(Token = "0x400011C")]
			MultiLineNewline = 2
		}

		[Token(Token = "0x2000033")]
		public delegate char OnValidateInput(string text, int charIndex, char addedChar);

		[Serializable]
		[Token(Token = "0x2000034")]
		public class SubmitEvent : UnityEvent<string>
		{
			[Token(Token = "0x6000235")]
			[Address(RVA = "0x18190F0", Offset = "0x18190F0", Length = "0x48")]
			public SubmitEvent()
			{
			}
		}

		[Serializable]
		[Token(Token = "0x2000035")]
		public class EndEditEvent : UnityEvent<string>
		{
			[Token(Token = "0x6000236")]
			[Address(RVA = "0x1819138", Offset = "0x1819138", Length = "0x48")]
			public EndEditEvent()
			{
			}
		}

		[Serializable]
		[Token(Token = "0x2000036")]
		public class OnChangeEvent : UnityEvent<string>
		{
			[Token(Token = "0x6000237")]
			[Address(RVA = "0x1819180", Offset = "0x1819180", Length = "0x48")]
			public OnChangeEvent()
			{
			}
		}

		[Token(Token = "0x2000037")]
		protected enum EditState
		{
			[Token(Token = "0x400011E")]
			Continue = 0,
			[Token(Token = "0x400011F")]
			Finish = 1
		}

		[CompilerGenerated]
		[Token(Token = "0x2000038")]
		private sealed class _003CCaretBlink_003Ed__172 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000120")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x4000121")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000122")]
			[FieldOffset(Offset = "0x20")]
			public InputField _003C_003E4__this;

			[Token(Token = "0x17000094")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600023B")]
				[Address(RVA = "0x18227A0", Offset = "0x18227A0", Length = "0x8")]
				get
				{
					return null;
				}
			}

			[Token(Token = "0x17000095")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x600023D")]
				[Address(RVA = "0x18227E0", Offset = "0x18227E0", Length = "0x8")]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x6000238")]
			[Address(RVA = "0x181B3A8", Offset = "0x181B3A8", Length = "0x28")]
			public _003CCaretBlink_003Ed__172(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			[Token(Token = "0x6000239")]
			[Address(RVA = "0x1822698", Offset = "0x1822698", Length = "0x4")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x600023A")]
			[Address(RVA = "0x182269C", Offset = "0x182269C", Length = "0x104")]
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
			[Token(Token = "0x600023C")]
			[Address(RVA = "0x18227A8", Offset = "0x18227A8", Length = "0x38")]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000039")]
		private sealed class _003CMouseDragOutsideRect_003Ed__196 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x4000123")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x4000124")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x4000125")]
			[FieldOffset(Offset = "0x20")]
			public PointerEventData eventData;

			[Token(Token = "0x4000126")]
			[FieldOffset(Offset = "0x28")]
			public InputField _003C_003E4__this;

			[Token(Token = "0x17000096")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000241")]
				[Address(RVA = "0x1822A54", Offset = "0x1822A54", Length = "0x8")]
				get
				{
					return null;
				}
			}

			[Token(Token = "0x17000097")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x6000243")]
				[Address(RVA = "0x1822A94", Offset = "0x1822A94", Length = "0x8")]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x600023E")]
			[Address(RVA = "0x181DDD4", Offset = "0x181DDD4", Length = "0x28")]
			public _003CMouseDragOutsideRect_003Ed__196(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			[Token(Token = "0x600023F")]
			[Address(RVA = "0x18227E8", Offset = "0x18227E8", Length = "0x4")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x6000240")]
			[Address(RVA = "0x18227EC", Offset = "0x18227EC", Length = "0x268")]
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
			[Token(Token = "0x6000242")]
			[Address(RVA = "0x1822A5C", Offset = "0x1822A5C", Length = "0x38")]
			void IEnumerator.Reset()
			{
			}
		}

		[Token(Token = "0x40000CB")]
		[FieldOffset(Offset = "0x100")]
		protected TouchScreenKeyboard m_Keyboard;

		[Token(Token = "0x40000CC")]
		private static readonly char[] kSeparators;

		[Token(Token = "0x40000CD")]
		private static bool s_IsQuestDeviceEvaluated;

		[Token(Token = "0x40000CE")]
		private static bool s_IsQuestDevice;

		[SerializeField]
		[FormerlySerializedAs("text")]
		[Token(Token = "0x40000CF")]
		[FieldOffset(Offset = "0x108")]
		protected Text m_TextComponent;

		[SerializeField]
		[Token(Token = "0x40000D0")]
		[FieldOffset(Offset = "0x110")]
		protected Graphic m_Placeholder;

		[SerializeField]
		[Token(Token = "0x40000D1")]
		[FieldOffset(Offset = "0x118")]
		private ContentType m_ContentType;

		[FormerlySerializedAs("inputType")]
		[SerializeField]
		[Token(Token = "0x40000D2")]
		[FieldOffset(Offset = "0x11C")]
		private InputType m_InputType;

		[FormerlySerializedAs("asteriskChar")]
		[SerializeField]
		[Token(Token = "0x40000D3")]
		[FieldOffset(Offset = "0x120")]
		private char m_AsteriskChar;

		[FormerlySerializedAs("keyboardType")]
		[SerializeField]
		[Token(Token = "0x40000D4")]
		[FieldOffset(Offset = "0x124")]
		private TouchScreenKeyboardType m_KeyboardType;

		[SerializeField]
		[Token(Token = "0x40000D5")]
		[FieldOffset(Offset = "0x128")]
		private LineType m_LineType;

		[SerializeField]
		[FormerlySerializedAs("hideMobileInput")]
		[Token(Token = "0x40000D6")]
		[FieldOffset(Offset = "0x12C")]
		private bool m_HideMobileInput;

		[FormerlySerializedAs("validation")]
		[SerializeField]
		[Token(Token = "0x40000D7")]
		[FieldOffset(Offset = "0x130")]
		private CharacterValidation m_CharacterValidation;

		[SerializeField]
		[FormerlySerializedAs("characterLimit")]
		[Token(Token = "0x40000D8")]
		[FieldOffset(Offset = "0x134")]
		private int m_CharacterLimit;

		[FormerlySerializedAs("m_OnSubmit")]
		[FormerlySerializedAs("onSubmit")]
		[FormerlySerializedAs("m_EndEdit")]
		[FormerlySerializedAs("m_OnEndEdit")]
		[SerializeField]
		[Token(Token = "0x40000D9")]
		[FieldOffset(Offset = "0x138")]
		private SubmitEvent m_OnSubmit;

		[SerializeField]
		[Token(Token = "0x40000DA")]
		[FieldOffset(Offset = "0x140")]
		private EndEditEvent m_OnDidEndEdit;

		[FormerlySerializedAs("onValueChange")]
		[FormerlySerializedAs("m_OnValueChange")]
		[SerializeField]
		[Token(Token = "0x40000DB")]
		[FieldOffset(Offset = "0x148")]
		private OnChangeEvent m_OnValueChanged;

		[FormerlySerializedAs("onValidateInput")]
		[SerializeField]
		[Token(Token = "0x40000DC")]
		[FieldOffset(Offset = "0x150")]
		private OnValidateInput m_OnValidateInput;

		[FormerlySerializedAs("selectionColor")]
		[SerializeField]
		[Token(Token = "0x40000DD")]
		[FieldOffset(Offset = "0x158")]
		private Color m_CaretColor;

		[SerializeField]
		[Token(Token = "0x40000DE")]
		[FieldOffset(Offset = "0x168")]
		private bool m_CustomCaretColor;

		[SerializeField]
		[Token(Token = "0x40000DF")]
		[FieldOffset(Offset = "0x16C")]
		private Color m_SelectionColor;

		[SerializeField]
		[Multiline]
		[FormerlySerializedAs("mValue")]
		[Token(Token = "0x40000E0")]
		[FieldOffset(Offset = "0x180")]
		protected string m_Text;

		[SerializeField]
		[Range(0f, 4f)]
		[Token(Token = "0x40000E1")]
		[FieldOffset(Offset = "0x188")]
		private float m_CaretBlinkRate;

		[SerializeField]
		[Range(1f, 5f)]
		[Token(Token = "0x40000E2")]
		[FieldOffset(Offset = "0x18C")]
		private int m_CaretWidth;

		[SerializeField]
		[Token(Token = "0x40000E3")]
		[FieldOffset(Offset = "0x190")]
		private bool m_ReadOnly;

		[SerializeField]
		[Token(Token = "0x40000E4")]
		[FieldOffset(Offset = "0x191")]
		private bool m_ShouldActivateOnSelect;

		[Token(Token = "0x40000E5")]
		[FieldOffset(Offset = "0x194")]
		protected int m_CaretPosition;

		[Token(Token = "0x40000E6")]
		[FieldOffset(Offset = "0x198")]
		protected int m_CaretSelectPosition;

		[Token(Token = "0x40000E7")]
		[FieldOffset(Offset = "0x1A0")]
		private RectTransform caretRectTrans;

		[Token(Token = "0x40000E8")]
		[FieldOffset(Offset = "0x1A8")]
		protected UIVertex[] m_CursorVerts;

		[Token(Token = "0x40000E9")]
		[FieldOffset(Offset = "0x1B0")]
		private TextGenerator m_InputTextCache;

		[Token(Token = "0x40000EA")]
		[FieldOffset(Offset = "0x1B8")]
		private CanvasRenderer m_CachedInputRenderer;

		[Token(Token = "0x40000EB")]
		[FieldOffset(Offset = "0x1C0")]
		private bool m_PreventFontCallback;

		[NonSerialized]
		[Token(Token = "0x40000EC")]
		[FieldOffset(Offset = "0x1C8")]
		protected Mesh m_Mesh;

		[Token(Token = "0x40000ED")]
		[FieldOffset(Offset = "0x1D0")]
		private bool m_AllowInput;

		[Token(Token = "0x40000EE")]
		[FieldOffset(Offset = "0x1D1")]
		private bool m_ShouldActivateNextUpdate;

		[Token(Token = "0x40000EF")]
		[FieldOffset(Offset = "0x1D2")]
		private bool m_UpdateDrag;

		[Token(Token = "0x40000F0")]
		[FieldOffset(Offset = "0x1D3")]
		private bool m_DragPositionOutOfBounds;

		[Token(Token = "0x40000F1")]
		private const float kHScrollSpeed = 0.05f;

		[Token(Token = "0x40000F2")]
		private const float kVScrollSpeed = 0.1f;

		[Token(Token = "0x40000F3")]
		[FieldOffset(Offset = "0x1D4")]
		protected bool m_CaretVisible;

		[Token(Token = "0x40000F4")]
		[FieldOffset(Offset = "0x1D8")]
		private Coroutine m_BlinkCoroutine;

		[Token(Token = "0x40000F5")]
		[FieldOffset(Offset = "0x1E0")]
		private float m_BlinkStartTime;

		[Token(Token = "0x40000F6")]
		[FieldOffset(Offset = "0x1E4")]
		protected int m_DrawStart;

		[Token(Token = "0x40000F7")]
		[FieldOffset(Offset = "0x1E8")]
		protected int m_DrawEnd;

		[Token(Token = "0x40000F8")]
		[FieldOffset(Offset = "0x1F0")]
		private Coroutine m_DragCoroutine;

		[Token(Token = "0x40000F9")]
		[FieldOffset(Offset = "0x1F8")]
		private string m_OriginalText;

		[Token(Token = "0x40000FA")]
		[FieldOffset(Offset = "0x200")]
		private bool m_WasCanceled;

		[Token(Token = "0x40000FB")]
		[FieldOffset(Offset = "0x201")]
		private bool m_HasDoneFocusTransition;

		[Token(Token = "0x40000FC")]
		[FieldOffset(Offset = "0x208")]
		private WaitForSecondsRealtime m_WaitForSecondsRealtime;

		[Token(Token = "0x40000FD")]
		[FieldOffset(Offset = "0x210")]
		private bool m_TouchKeyboardAllowsInPlaceEditing;

		[Token(Token = "0x40000FE")]
		[FieldOffset(Offset = "0x211")]
		private bool m_IsCompositionActive;

		[Token(Token = "0x40000FF")]
		private const string kEmailSpecialCharacters = "!#$%&'*+-/=?^_`{|}~";

		[Token(Token = "0x4000100")]
		private const string kOculusQuestDeviceModel = "Oculus Quest";

		[Token(Token = "0x4000101")]
		[FieldOffset(Offset = "0x218")]
		private Event m_ProcessingEvent;

		[Token(Token = "0x4000102")]
		private const int k_MaxTextLength = 16382;

		[Token(Token = "0x17000067")]
		private BaseInput input
		{
			[Token(Token = "0x600018B")]
			[Address(RVA = "0x1818DB0", Offset = "0x1818DB0", Length = "0x110")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000068")]
		private string compositionString
		{
			[Token(Token = "0x600018C")]
			[Address(RVA = "0x1818EC0", Offset = "0x1818EC0", Length = "0x94")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000069")]
		protected Mesh mesh
		{
			[Token(Token = "0x600018E")]
			[Address(RVA = "0x181925C", Offset = "0x181925C", Length = "0xA0")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700006A")]
		protected TextGenerator cachedInputTextGenerator
		{
			[Token(Token = "0x600018F")]
			[Address(RVA = "0x18192FC", Offset = "0x18192FC", Length = "0x64")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700006B")]
		public bool shouldHideMobileInput
		{
			[Token(Token = "0x6000191")]
			[Address(RVA = "0x18193B8", Offset = "0x18193B8", Length = "0x88")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000190")]
			[Address(RVA = "0x1819360", Offset = "0x1819360", Length = "0x58")]
			set
			{
			}
		}

		[Token(Token = "0x1700006C")]
		public virtual bool shouldActivateOnSelect
		{
			[Token(Token = "0x6000193")]
			[Address(RVA = "0x181944C", Offset = "0x181944C", Length = "0x70")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000192")]
			[Address(RVA = "0x1819440", Offset = "0x1819440", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x1700006D")]
		public string text
		{
			[Token(Token = "0x6000194")]
			[Address(RVA = "0x18194BC", Offset = "0x18194BC", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000195")]
			[Address(RVA = "0x18194C4", Offset = "0x18194C4", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700006E")]
		public bool isFocused
		{
			[Token(Token = "0x6000198")]
			[Address(RVA = "0x1819D1C", Offset = "0x1819D1C", Length = "0x8")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x1700006F")]
		public float caretBlinkRate
		{
			[Token(Token = "0x6000199")]
			[Address(RVA = "0x1819D24", Offset = "0x1819D24", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600019A")]
			[Address(RVA = "0x1819D2C", Offset = "0x1819D2C", Length = "0x7C")]
			set
			{
			}
		}

		[Token(Token = "0x17000070")]
		public int caretWidth
		{
			[Token(Token = "0x600019B")]
			[Address(RVA = "0x1819DFC", Offset = "0x1819DFC", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x600019C")]
			[Address(RVA = "0x1819E04", Offset = "0x1819E04", Length = "0x74")]
			set
			{
			}
		}

		[Token(Token = "0x17000071")]
		public Text textComponent
		{
			[Token(Token = "0x600019D")]
			[Address(RVA = "0x1819ED0", Offset = "0x1819ED0", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600019E")]
			[Address(RVA = "0x1819ED8", Offset = "0x1819ED8", Length = "0x280")]
			set
			{
			}
		}

		[Token(Token = "0x17000072")]
		public Graphic placeholder
		{
			[Token(Token = "0x600019F")]
			[Address(RVA = "0x181A158", Offset = "0x181A158", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60001A0")]
			[Address(RVA = "0x181A160", Offset = "0x181A160", Length = "0x58")]
			set
			{
			}
		}

		[Token(Token = "0x17000073")]
		public Color caretColor
		{
			[Token(Token = "0x60001A1")]
			[Address(RVA = "0x181A1B8", Offset = "0x181A1B8", Length = "0x44")]
			get
			{
				return default(Color);
			}
			[Token(Token = "0x60001A2")]
			[Address(RVA = "0x181A1FC", Offset = "0x181A1FC", Length = "0x2C")]
			set
			{
			}
		}

		[Token(Token = "0x17000074")]
		public bool customCaretColor
		{
			[Token(Token = "0x60001A3")]
			[Address(RVA = "0x181A228", Offset = "0x181A228", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60001A4")]
			[Address(RVA = "0x181A230", Offset = "0x181A230", Length = "0x1C")]
			set
			{
			}
		}

		[Token(Token = "0x17000075")]
		public Color selectionColor
		{
			[Token(Token = "0x60001A5")]
			[Address(RVA = "0x181A24C", Offset = "0x181A24C", Length = "0x14")]
			get
			{
				return default(Color);
			}
			[Token(Token = "0x60001A6")]
			[Address(RVA = "0x181A260", Offset = "0x181A260", Length = "0x2C")]
			set
			{
			}
		}

		[Token(Token = "0x17000076")]
		public EndEditEvent onEndEdit
		{
			[Token(Token = "0x60001A7")]
			[Address(RVA = "0x181A28C", Offset = "0x181A28C", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60001A8")]
			[Address(RVA = "0x181A294", Offset = "0x181A294", Length = "0x58")]
			set
			{
			}
		}

		[Token(Token = "0x17000077")]
		public SubmitEvent onSubmit
		{
			[Token(Token = "0x60001A9")]
			[Address(RVA = "0x181A2EC", Offset = "0x181A2EC", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60001AA")]
			[Address(RVA = "0x181A2F4", Offset = "0x181A2F4", Length = "0x58")]
			set
			{
			}
		}

		[Obsolete("onValueChange has been renamed to onValueChanged")]
		[Token(Token = "0x17000078")]
		public OnChangeEvent onValueChange
		{
			[Token(Token = "0x60001AB")]
			[Address(RVA = "0x181A34C", Offset = "0x181A34C", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60001AC")]
			[Address(RVA = "0x181A354", Offset = "0x181A354", Length = "0x4")]
			set
			{
			}
		}

		[Token(Token = "0x17000079")]
		public OnChangeEvent onValueChanged
		{
			[Token(Token = "0x60001AD")]
			[Address(RVA = "0x181A3B0", Offset = "0x181A3B0", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60001AE")]
			[Address(RVA = "0x181A358", Offset = "0x181A358", Length = "0x58")]
			set
			{
			}
		}

		[Token(Token = "0x1700007A")]
		public OnValidateInput onValidateInput
		{
			[Token(Token = "0x60001AF")]
			[Address(RVA = "0x181A3B8", Offset = "0x181A3B8", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60001B0")]
			[Address(RVA = "0x181A3C0", Offset = "0x181A3C0", Length = "0x58")]
			set
			{
			}
		}

		[Token(Token = "0x1700007B")]
		public int characterLimit
		{
			[Token(Token = "0x60001B1")]
			[Address(RVA = "0x181A418", Offset = "0x181A418", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x60001B2")]
			[Address(RVA = "0x181A420", Offset = "0x181A420", Length = "0xC0")]
			set
			{
			}
		}

		[Token(Token = "0x1700007C")]
		public ContentType contentType
		{
			[Token(Token = "0x60001B3")]
			[Address(RVA = "0x181A4E0", Offset = "0x181A4E0", Length = "0x8")]
			get
			{
				return ContentType.Standard;
			}
			[Token(Token = "0x60001B4")]
			[Address(RVA = "0x181A4E8", Offset = "0x181A4E8", Length = "0x74")]
			set
			{
			}
		}

		[Token(Token = "0x1700007D")]
		public LineType lineType
		{
			[Token(Token = "0x60001B5")]
			[Address(RVA = "0x181A618", Offset = "0x181A618", Length = "0x8")]
			get
			{
				return LineType.SingleLine;
			}
			[Token(Token = "0x60001B6")]
			[Address(RVA = "0x181A620", Offset = "0x181A620", Length = "0xC0")]
			set
			{
			}
		}

		[Token(Token = "0x1700007E")]
		public InputType inputType
		{
			[Token(Token = "0x60001B7")]
			[Address(RVA = "0x181A744", Offset = "0x181A744", Length = "0x8")]
			get
			{
				return InputType.Standard;
			}
			[Token(Token = "0x60001B8")]
			[Address(RVA = "0x181A74C", Offset = "0x181A74C", Length = "0x84")]
			set
			{
			}
		}

		[Token(Token = "0x1700007F")]
		public TouchScreenKeyboard touchScreenKeyboard
		{
			[Token(Token = "0x60001B9")]
			[Address(RVA = "0x181A7E8", Offset = "0x181A7E8", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000080")]
		public TouchScreenKeyboardType keyboardType
		{
			[Token(Token = "0x60001BA")]
			[Address(RVA = "0x181A7F0", Offset = "0x181A7F0", Length = "0x8")]
			get
			{
				return TouchScreenKeyboardType.Default;
			}
			[Token(Token = "0x60001BB")]
			[Address(RVA = "0x181A7F8", Offset = "0x181A7F8", Length = "0x84")]
			set
			{
			}
		}

		[Token(Token = "0x17000081")]
		public CharacterValidation characterValidation
		{
			[Token(Token = "0x60001BC")]
			[Address(RVA = "0x181A87C", Offset = "0x181A87C", Length = "0x8")]
			get
			{
				return CharacterValidation.None;
			}
			[Token(Token = "0x60001BD")]
			[Address(RVA = "0x181A884", Offset = "0x181A884", Length = "0x84")]
			set
			{
			}
		}

		[Token(Token = "0x17000082")]
		public bool readOnly
		{
			[Token(Token = "0x60001BE")]
			[Address(RVA = "0x181A908", Offset = "0x181A908", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60001BF")]
			[Address(RVA = "0x181A910", Offset = "0x181A910", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x17000083")]
		public bool multiLine
		{
			[Token(Token = "0x60001C0")]
			[Address(RVA = "0x181A91C", Offset = "0x181A91C", Length = "0x14")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x17000084")]
		public char asteriskChar
		{
			[Token(Token = "0x60001C1")]
			[Address(RVA = "0x181A930", Offset = "0x181A930", Length = "0x8")]
			get
			{
				return '\0';
			}
			[Token(Token = "0x60001C2")]
			[Address(RVA = "0x181A938", Offset = "0x181A938", Length = "0x74")]
			set
			{
			}
		}

		[Token(Token = "0x17000085")]
		public bool wasCanceled
		{
			[Token(Token = "0x60001C3")]
			[Address(RVA = "0x181A9AC", Offset = "0x181A9AC", Length = "0x8")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x17000086")]
		protected int caretPositionInternal
		{
			[Token(Token = "0x60001C5")]
			[Address(RVA = "0x181A9EC", Offset = "0x181A9EC", Length = "0x24")]
			get
			{
				return 0;
			}
			[Token(Token = "0x60001C6")]
			[Address(RVA = "0x181AA10", Offset = "0x181AA10", Length = "0x38")]
			set
			{
			}
		}

		[Token(Token = "0x17000087")]
		protected int caretSelectPositionInternal
		{
			[Token(Token = "0x60001C7")]
			[Address(RVA = "0x181AA48", Offset = "0x181AA48", Length = "0x24")]
			get
			{
				return 0;
			}
			[Token(Token = "0x60001C8")]
			[Address(RVA = "0x181AA6C", Offset = "0x181AA6C", Length = "0x38")]
			set
			{
			}
		}

		[Token(Token = "0x17000088")]
		private bool hasSelection
		{
			[Token(Token = "0x60001C9")]
			[Address(RVA = "0x181AAA4", Offset = "0x181AAA4", Length = "0x30")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x17000089")]
		public int caretPosition
		{
			[Token(Token = "0x60001CA")]
			[Address(RVA = "0x181AAD4", Offset = "0x181AAD4", Length = "0x24")]
			get
			{
				return 0;
			}
			[Token(Token = "0x60001CB")]
			[Address(RVA = "0x181AAF8", Offset = "0x181AAF8", Length = "0x28")]
			set
			{
			}
		}

		[Token(Token = "0x1700008A")]
		public int selectionAnchorPosition
		{
			[Token(Token = "0x60001CC")]
			[Address(RVA = "0x181ABD8", Offset = "0x181ABD8", Length = "0x24")]
			get
			{
				return 0;
			}
			[Token(Token = "0x60001CD")]
			[Address(RVA = "0x181AB20", Offset = "0x181AB20", Length = "0x5C")]
			set
			{
			}
		}

		[Token(Token = "0x1700008B")]
		public int selectionFocusPosition
		{
			[Token(Token = "0x60001CE")]
			[Address(RVA = "0x181ABFC", Offset = "0x181ABFC", Length = "0x24")]
			get
			{
				return 0;
			}
			[Token(Token = "0x60001CF")]
			[Address(RVA = "0x181AB7C", Offset = "0x181AB7C", Length = "0x5C")]
			set
			{
			}
		}

		[Token(Token = "0x1700008C")]
		private static string clipboard
		{
			[Token(Token = "0x60001DC")]
			[Address(RVA = "0x181B654", Offset = "0x181B654", Length = "0x50")]
			get
			{
				return null;
			}
			[Token(Token = "0x60001DD")]
			[Address(RVA = "0x181B6A4", Offset = "0x181B6A4", Length = "0x58")]
			set
			{
			}
		}

		[Token(Token = "0x1700008D")]
		public virtual float minWidth
		{
			[Token(Token = "0x6000228")]
			[Address(RVA = "0x1822248", Offset = "0x1822248", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x1700008E")]
		public virtual float preferredWidth
		{
			[Token(Token = "0x6000229")]
			[Address(RVA = "0x1822250", Offset = "0x1822250", Length = "0x14C")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x1700008F")]
		public virtual float flexibleWidth
		{
			[Token(Token = "0x600022A")]
			[Address(RVA = "0x182239C", Offset = "0x182239C", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000090")]
		public virtual float minHeight
		{
			[Token(Token = "0x600022B")]
			[Address(RVA = "0x18223A4", Offset = "0x18223A4", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000091")]
		public virtual float preferredHeight
		{
			[Token(Token = "0x600022C")]
			[Address(RVA = "0x18223AC", Offset = "0x18223AC", Length = "0x138")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000092")]
		public virtual float flexibleHeight
		{
			[Token(Token = "0x600022D")]
			[Address(RVA = "0x18224E4", Offset = "0x18224E4", Length = "0x8")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x17000093")]
		public virtual int layoutPriority
		{
			[Token(Token = "0x600022E")]
			[Address(RVA = "0x18224EC", Offset = "0x18224EC", Length = "0x8")]
			get
			{
				return 0;
			}
		}

		Transform ICanvasElement.transform
		{
			[Token(Token = "0x6000230")]
			[Address(RVA = "0x1822594", Offset = "0x1822594", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x600018D")]
		[Address(RVA = "0x1818F54", Offset = "0x1818F54", Length = "0x19C")]
		protected InputField()
		{
		}

		[Token(Token = "0x6000196")]
		[Address(RVA = "0x18197FC", Offset = "0x18197FC", Length = "0x8")]
		public void SetTextWithoutNotify(string input)
		{
		}

		[Token(Token = "0x6000197")]
		[Address(RVA = "0x18194CC", Offset = "0x18194CC", Length = "0x330")]
		private void SetText(string value, bool sendCallback = true)
		{
		}

		[Token(Token = "0x60001C4")]
		[Address(RVA = "0x181A9B4", Offset = "0x181A9B4", Length = "0x38")]
		protected void ClampPos(ref int pos)
		{
		}

		[Token(Token = "0x60001D0")]
		[Address(RVA = "0x181AC20", Offset = "0x181AC20", Length = "0xC0")]
		protected override void Awake()
		{
		}

		[Token(Token = "0x60001D1")]
		[Address(RVA = "0x181ACE0", Offset = "0x181ACE0", Length = "0x260")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x60001D2")]
		[Address(RVA = "0x181AF40", Offset = "0x181AF40", Length = "0x228")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x60001D3")]
		[Address(RVA = "0x181B2E4", Offset = "0x181B2E4", Length = "0x64")]
		protected override void OnDestroy()
		{
		}

		[IteratorStateMachine(typeof(_003CCaretBlink_003Ed__172))]
		[Token(Token = "0x60001D4")]
		[Address(RVA = "0x181B348", Offset = "0x181B348", Length = "0x60")]
		private IEnumerator CaretBlink()
		{
			return null;
		}

		[Token(Token = "0x60001D5")]
		[Address(RVA = "0x181B3D0", Offset = "0x181B3D0", Length = "0x38")]
		private void SetCaretVisible()
		{
		}

		[Token(Token = "0x60001D6")]
		[Address(RVA = "0x1819DA8", Offset = "0x1819DA8", Length = "0x54")]
		private void SetCaretActive()
		{
		}

		[Token(Token = "0x60001D7")]
		[Address(RVA = "0x181B408", Offset = "0x181B408", Length = "0x110")]
		private void UpdateCaretMaterial()
		{
		}

		[Token(Token = "0x60001D8")]
		[Address(RVA = "0x181B518", Offset = "0x181B518", Length = "0x30")]
		protected void OnFocus()
		{
		}

		[Token(Token = "0x60001D9")]
		[Address(RVA = "0x181B548", Offset = "0x181B548", Length = "0x30")]
		protected void SelectAll()
		{
		}

		[Token(Token = "0x60001DA")]
		[Address(RVA = "0x181B578", Offset = "0x181B578", Length = "0x60")]
		public void MoveTextEnd(bool shift)
		{
		}

		[Token(Token = "0x60001DB")]
		[Address(RVA = "0x181B5D8", Offset = "0x181B5D8", Length = "0x7C")]
		public void MoveTextStart(bool shift)
		{
		}

		[Token(Token = "0x60001DE")]
		[Address(RVA = "0x181B6FC", Offset = "0x181B6FC", Length = "0xB8")]
		private bool TouchScreenKeyboardShouldBeUsed()
		{
			return false;
		}

		[Token(Token = "0x60001DF")]
		[Address(RVA = "0x181B7B4", Offset = "0x181B7B4", Length = "0x30")]
		private bool InPlaceEditing()
		{
			return false;
		}

		[Token(Token = "0x60001E0")]
		[Address(RVA = "0x181B7E4", Offset = "0x181B7E4", Length = "0x80")]
		private bool InPlaceEditingChanged()
		{
			return false;
		}

		[Token(Token = "0x60001E1")]
		[Address(RVA = "0x181B864", Offset = "0x181B864", Length = "0xB4")]
		private RangeInt GetInternalSelection()
		{
			return default(RangeInt);
		}

		[Token(Token = "0x60001E2")]
		[Address(RVA = "0x181B918", Offset = "0x181B918", Length = "0xC8")]
		private void UpdateKeyboardCaret()
		{
		}

		[Token(Token = "0x60001E3")]
		[Address(RVA = "0x181B9E0", Offset = "0x181B9E0", Length = "0xE4")]
		private void UpdateCaretFromKeyboard()
		{
		}

		[Token(Token = "0x60001E4")]
		[Address(RVA = "0x181BAC4", Offset = "0x181BAC4", Length = "0x61C")]
		protected virtual void LateUpdate()
		{
		}

		[Obsolete("This function is no longer used. Please use RectTransformUtility.ScreenPointToLocalPointInRectangle() instead.")]
		[Token(Token = "0x60001E5")]
		[Address(RVA = "0x181D0DC", Offset = "0x181D0DC", Length = "0x398")]
		public Vector2 ScreenToLocal(Vector2 screen)
		{
			return default(Vector2);
		}

		[Token(Token = "0x60001E6")]
		[Address(RVA = "0x181D474", Offset = "0x181D474", Length = "0x210")]
		private int GetUnclampedCharacterLineFromPosition(Vector2 pos, TextGenerator generator)
		{
			return 0;
		}

		[Token(Token = "0x60001E7")]
		[Address(RVA = "0x181D684", Offset = "0x181D684", Length = "0x294")]
		protected int GetCharacterIndexFromPosition(Vector2 pos)
		{
			return 0;
		}

		[Token(Token = "0x60001E8")]
		[Address(RVA = "0x181DA7C", Offset = "0x181DA7C", Length = "0xD8")]
		private bool MayDrag(PointerEventData eventData)
		{
			return false;
		}

		[Token(Token = "0x60001E9")]
		[Address(RVA = "0x181DB54", Offset = "0x181DB54", Length = "0x20")]
		public virtual void OnBeginDrag(PointerEventData eventData)
		{
		}

		[Token(Token = "0x60001EA")]
		[Address(RVA = "0x181DB74", Offset = "0x181DB74", Length = "0x1F4")]
		public virtual void OnDrag(PointerEventData eventData)
		{
		}

		[IteratorStateMachine(typeof(_003CMouseDragOutsideRect_003Ed__196))]
		[Token(Token = "0x60001EB")]
		[Address(RVA = "0x181DD68", Offset = "0x181DD68", Length = "0x6C")]
		private IEnumerator MouseDragOutsideRect(PointerEventData eventData)
		{
			return null;
		}

		[Token(Token = "0x60001EC")]
		[Address(RVA = "0x181DDFC", Offset = "0x181DDFC", Length = "0x1C")]
		public virtual void OnEndDrag(PointerEventData eventData)
		{
		}

		[Token(Token = "0x60001ED")]
		[Address(RVA = "0x181DE18", Offset = "0x181DE18", Length = "0x1F0")]
		public override void OnPointerDown(PointerEventData eventData)
		{
		}

		[Token(Token = "0x60001EE")]
		[Address(RVA = "0x181E008", Offset = "0x181E008", Length = "0x404")]
		protected EditState KeyPressed(Event evt)
		{
			return EditState.Continue;
		}

		[Token(Token = "0x60001EF")]
		[Address(RVA = "0x181EAC8", Offset = "0x181EAC8", Length = "0x70")]
		private bool IsValidChar(char c)
		{
			return false;
		}

		[Token(Token = "0x60001F0")]
		[Address(RVA = "0x181EB38", Offset = "0x181EB38", Length = "0x4")]
		public void ProcessEvent(Event e)
		{
		}

		[Token(Token = "0x60001F1")]
		[Address(RVA = "0x181EB3C", Offset = "0x181EB3C", Length = "0x1A0")]
		public virtual void OnUpdateSelected(BaseEventData eventData)
		{
		}

		[Token(Token = "0x60001F2")]
		[Address(RVA = "0x181E5B4", Offset = "0x181E5B4", Length = "0xA8")]
		private string GetSelectedString()
		{
			return null;
		}

		[Token(Token = "0x60001F3")]
		[Address(RVA = "0x181ECDC", Offset = "0x181ECDC", Length = "0xBC")]
		private int FindtNextWordBegin()
		{
			return 0;
		}

		[Token(Token = "0x60001F4")]
		[Address(RVA = "0x181E984", Offset = "0x181E984", Length = "0x12C")]
		private void MoveRight(bool shift, bool ctrl)
		{
		}

		[Token(Token = "0x60001F5")]
		[Address(RVA = "0x181ED98", Offset = "0x181ED98", Length = "0xA0")]
		private int FindtPrevWordBegin()
		{
			return 0;
		}

		[Token(Token = "0x60001F6")]
		[Address(RVA = "0x181E858", Offset = "0x181E858", Length = "0x12C")]
		private void MoveLeft(bool shift, bool ctrl)
		{
		}

		[Token(Token = "0x60001F7")]
		[Address(RVA = "0x181EE38", Offset = "0x181EE38", Length = "0x110")]
		private int DetermineCharacterLine(int charPos, TextGenerator generator)
		{
			return 0;
		}

		[Token(Token = "0x60001F8")]
		[Address(RVA = "0x181EF48", Offset = "0x181EF48", Length = "0x358")]
		private int LineUpCharacterPosition(int originalPos, bool goToFirstChar)
		{
			return 0;
		}

		[Token(Token = "0x60001F9")]
		[Address(RVA = "0x181F2A0", Offset = "0x181F2A0", Length = "0x2B4")]
		private int LineDownCharacterPosition(int originalPos, bool goToLastChar)
		{
			return 0;
		}

		[Token(Token = "0x60001FA")]
		[Address(RVA = "0x181EABC", Offset = "0x181EABC", Length = "0xC")]
		private void MoveDown(bool shift)
		{
		}

		[Token(Token = "0x60001FB")]
		[Address(RVA = "0x181F554", Offset = "0x181F554", Length = "0x124")]
		private void MoveDown(bool shift, bool goToLastChar)
		{
		}

		[Token(Token = "0x60001FC")]
		[Address(RVA = "0x181EAB0", Offset = "0x181EAB0", Length = "0xC")]
		private void MoveUp(bool shift)
		{
		}

		[Token(Token = "0x60001FD")]
		[Address(RVA = "0x181F678", Offset = "0x181F678", Length = "0x158")]
		private void MoveUp(bool shift, bool goToFirstChar)
		{
		}

		[Token(Token = "0x60001FE")]
		[Address(RVA = "0x181E65C", Offset = "0x181E65C", Length = "0x1B4")]
		private void Delete()
		{
		}

		[Token(Token = "0x60001FF")]
		[Address(RVA = "0x181E510", Offset = "0x181E510", Length = "0xA4")]
		private void ForwardSpace()
		{
		}

		[Token(Token = "0x6000200")]
		[Address(RVA = "0x181E40C", Offset = "0x181E40C", Length = "0x104")]
		private void Backspace()
		{
		}

		[Token(Token = "0x6000201")]
		[Address(RVA = "0x181F7D0", Offset = "0x181F7D0", Length = "0x118")]
		private void Insert(char c)
		{
		}

		[Token(Token = "0x6000202")]
		[Address(RVA = "0x181E810", Offset = "0x181E810", Length = "0x48")]
		private void UpdateTouchKeyboardFromEditChanges()
		{
		}

		[Token(Token = "0x6000203")]
		[Address(RVA = "0x181D0C4", Offset = "0x181D0C4", Length = "0x18")]
		private void SendOnValueChangedAndUpdateLabel()
		{
		}

		[Token(Token = "0x6000204")]
		[Address(RVA = "0x18198A4", Offset = "0x18198A4", Length = "0x80")]
		private void SendOnValueChanged()
		{
		}

		[Token(Token = "0x6000205")]
		[Address(RVA = "0x181F8E8", Offset = "0x181F8E8", Length = "0x80")]
		protected void SendOnEndEdit()
		{
		}

		[Token(Token = "0x6000206")]
		[Address(RVA = "0x181C928", Offset = "0x181C928", Length = "0x80")]
		protected void SendOnSubmit()
		{
		}

		[Token(Token = "0x6000207")]
		[Address(RVA = "0x181F968", Offset = "0x181F968", Length = "0xBC")]
		protected virtual void Append(string input)
		{
		}

		[Token(Token = "0x6000208")]
		[Address(RVA = "0x181FA24", Offset = "0x181FA24", Length = "0x270")]
		protected virtual void Append(char input)
		{
		}

		[Token(Token = "0x6000209")]
		[Address(RVA = "0x1819924", Offset = "0x1819924", Length = "0x3F8")]
		protected void UpdateLabel()
		{
		}

		[Token(Token = "0x600020A")]
		[Address(RVA = "0x18207D0", Offset = "0x18207D0", Length = "0x6C")]
		private bool IsSelectionVisible()
		{
			return false;
		}

		[Token(Token = "0x600020B")]
		[Address(RVA = "0x182083C", Offset = "0x182083C", Length = "0x150")]
		private static int GetLineStartPosition(TextGenerator gen, int line)
		{
			return 0;
		}

		[Token(Token = "0x600020C")]
		[Address(RVA = "0x181D918", Offset = "0x181D918", Length = "0x164")]
		private static int GetLineEndPosition(TextGenerator gen, int line)
		{
			return 0;
		}

		[Token(Token = "0x600020D")]
		[Address(RVA = "0x181FC94", Offset = "0x181FC94", Length = "0xB3C")]
		private void SetDrawRangeToContainCaretPosition(int caretPos)
		{
		}

		[Token(Token = "0x600020E")]
		[Address(RVA = "0x182098C", Offset = "0x182098C", Length = "0x4")]
		public void ForceLabelUpdate()
		{
		}

		[Token(Token = "0x600020F")]
		[Address(RVA = "0x1819E78", Offset = "0x1819E78", Length = "0x58")]
		private void MarkGeometryAsDirty()
		{
		}

		[Token(Token = "0x6000210")]
		[Address(RVA = "0x1820990", Offset = "0x1820990", Length = "0x10")]
		public virtual void Rebuild(CanvasUpdate update)
		{
		}

		[Token(Token = "0x6000211")]
		[Address(RVA = "0x1820DC0", Offset = "0x1820DC0", Length = "0x4")]
		public virtual void LayoutComplete()
		{
		}

		[Token(Token = "0x6000212")]
		[Address(RVA = "0x1820DC4", Offset = "0x1820DC4", Length = "0x4")]
		public virtual void GraphicUpdateComplete()
		{
		}

		[Token(Token = "0x6000213")]
		[Address(RVA = "0x18209A0", Offset = "0x18209A0", Length = "0x420")]
		private void UpdateGeometry()
		{
		}

		[Token(Token = "0x6000214")]
		[Address(RVA = "0x181C428", Offset = "0x181C428", Length = "0x500")]
		private void AssignPositioningIfNeeded()
		{
		}

		[Token(Token = "0x6000215")]
		[Address(RVA = "0x1820DC8", Offset = "0x1820DC8", Length = "0x288")]
		private void OnFillVBO(Mesh vbo)
		{
		}

		[Token(Token = "0x6000216")]
		[Address(RVA = "0x1821050", Offset = "0x1821050", Length = "0x718")]
		private void GenerateCaret(VertexHelper vbo, Vector2 roundingOffset)
		{
		}

		[Token(Token = "0x6000217")]
		[Address(RVA = "0x1821ED0", Offset = "0x1821ED0", Length = "0x150")]
		private void CreateCursorVerts()
		{
		}

		[Token(Token = "0x6000218")]
		[Address(RVA = "0x1821768", Offset = "0x1821768", Length = "0x768")]
		private void GenerateHighlight(VertexHelper vbo, Vector2 roundingOffset)
		{
		}

		[Token(Token = "0x6000219")]
		[Address(RVA = "0x181C9A8", Offset = "0x181C9A8", Length = "0x71C")]
		protected char Validate(string text, int pos, char ch)
		{
			return '\0';
		}

		[Token(Token = "0x600021A")]
		[Address(RVA = "0x1822020", Offset = "0x1822020", Length = "0x120")]
		public void ActivateInputField()
		{
		}

		[Token(Token = "0x600021B")]
		[Address(RVA = "0x181C0E0", Offset = "0x181C0E0", Length = "0x348")]
		private void ActivateInputFieldInternal()
		{
		}

		[Token(Token = "0x600021C")]
		[Address(RVA = "0x1822140", Offset = "0x1822140", Length = "0x3C")]
		public override void OnSelect(BaseEventData eventData)
		{
		}

		[Token(Token = "0x600021D")]
		[Address(RVA = "0x182217C", Offset = "0x182217C", Length = "0x24")]
		public virtual void OnPointerClick(PointerEventData eventData)
		{
		}

		[Token(Token = "0x600021E")]
		[Address(RVA = "0x181B168", Offset = "0x181B168", Length = "0x17C")]
		public void DeactivateInputField()
		{
		}

		[Token(Token = "0x600021F")]
		[Address(RVA = "0x18221A0", Offset = "0x18221A0", Length = "0x2C")]
		public override void OnDeselect(BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000220")]
		[Address(RVA = "0x18221CC", Offset = "0x18221CC", Length = "0x48")]
		public virtual void OnSubmit(BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000221")]
		[Address(RVA = "0x181A55C", Offset = "0x181A55C", Length = "0xBC")]
		private void EnforceContentType()
		{
		}

		[Token(Token = "0x6000222")]
		[Address(RVA = "0x18191C8", Offset = "0x18191C8", Length = "0x94")]
		private void EnforceTextHOverflow()
		{
		}

		[Token(Token = "0x6000223")]
		[Address(RVA = "0x181A6E0", Offset = "0x181A6E0", Length = "0x64")]
		private void SetToCustomIfContentTypeIsNot(params ContentType[] allowedContentTypes)
		{
		}

		[Token(Token = "0x6000224")]
		[Address(RVA = "0x181A7D0", Offset = "0x181A7D0", Length = "0x18")]
		private void SetToCustom()
		{
		}

		[Token(Token = "0x6000225")]
		[Address(RVA = "0x1822214", Offset = "0x1822214", Length = "0x2C")]
		protected override void DoStateTransition(SelectionState state, bool instant)
		{
		}

		[Token(Token = "0x6000226")]
		[Address(RVA = "0x1822240", Offset = "0x1822240", Length = "0x4")]
		public virtual void CalculateLayoutInputHorizontal()
		{
		}

		[Token(Token = "0x6000227")]
		[Address(RVA = "0x1822244", Offset = "0x1822244", Length = "0x4")]
		public virtual void CalculateLayoutInputVertical()
		{
		}
	}
}
