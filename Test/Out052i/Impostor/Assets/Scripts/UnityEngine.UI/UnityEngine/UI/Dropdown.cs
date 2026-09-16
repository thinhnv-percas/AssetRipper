using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI.CoroutineTween;

namespace UnityEngine.UI
{
	[RequireComponent(typeof(RectTransform))]
	[AddComponentMenu("UI/Legacy/Dropdown", 102)]
	[Token(Token = "0x2000015")]
	public class Dropdown : Selectable, IPointerClickHandler, IEventSystemHandler, ISubmitHandler, ICancelHandler
	{
		[Token(Token = "0x2000016")]
		protected internal class DropdownItem : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, ICancelHandler
		{
			[SerializeField]
			[Token(Token = "0x4000053")]
			[FieldOffset(Offset = "0x20")]
			private Text m_Text;

			[SerializeField]
			[Token(Token = "0x4000054")]
			[FieldOffset(Offset = "0x28")]
			private Image m_Image;

			[SerializeField]
			[Token(Token = "0x4000055")]
			[FieldOffset(Offset = "0x30")]
			private RectTransform m_RectTransform;

			[SerializeField]
			[Token(Token = "0x4000056")]
			[FieldOffset(Offset = "0x38")]
			private Toggle m_Toggle;

			[Token(Token = "0x1700001F")]
			public Text text
			{
				[Token(Token = "0x60000A4")]
				[Address(RVA = "0x16CAE70", Offset = "0x16CAE70", Length = "0x8")]
				get
				{
					return null;
				}
				[Token(Token = "0x60000A5")]
				[Address(RVA = "0x16CAE78", Offset = "0x16CAE78", Length = "0x8")]
				set
				{
				}
			}

			[Token(Token = "0x17000020")]
			public Image image
			{
				[Token(Token = "0x60000A6")]
				[Address(RVA = "0x16CAE80", Offset = "0x16CAE80", Length = "0x8")]
				get
				{
					return null;
				}
				[Token(Token = "0x60000A7")]
				[Address(RVA = "0x16CAE88", Offset = "0x16CAE88", Length = "0x8")]
				set
				{
				}
			}

			[Token(Token = "0x17000021")]
			public RectTransform rectTransform
			{
				[Token(Token = "0x60000A8")]
				[Address(RVA = "0x16CAE90", Offset = "0x16CAE90", Length = "0x8")]
				get
				{
					return null;
				}
				[Token(Token = "0x60000A9")]
				[Address(RVA = "0x16CAE98", Offset = "0x16CAE98", Length = "0x8")]
				set
				{
				}
			}

			[Token(Token = "0x17000022")]
			public Toggle toggle
			{
				[Token(Token = "0x60000AA")]
				[Address(RVA = "0x16CAEA0", Offset = "0x16CAEA0", Length = "0x8")]
				get
				{
					return null;
				}
				[Token(Token = "0x60000AB")]
				[Address(RVA = "0x16CAEA8", Offset = "0x16CAEA8", Length = "0x8")]
				set
				{
				}
			}

			[Token(Token = "0x60000AC")]
			[Address(RVA = "0x16CAEB0", Offset = "0x16CAEB0", Length = "0x7C")]
			public virtual void OnPointerEnter(PointerEventData eventData)
			{
			}

			[Token(Token = "0x60000AD")]
			[Address(RVA = "0x16CAF2C", Offset = "0x16CAF2C", Length = "0xAC")]
			public virtual void OnCancel(BaseEventData eventData)
			{
			}

			[Token(Token = "0x60000AE")]
			[Address(RVA = "0x16CAFD8", Offset = "0x16CAFD8", Length = "0x8")]
			public DropdownItem()
			{
			}
		}

		[Serializable]
		[Token(Token = "0x2000017")]
		public class OptionData
		{
			[SerializeField]
			[Token(Token = "0x4000057")]
			[FieldOffset(Offset = "0x10")]
			private string m_Text;

			[SerializeField]
			[Token(Token = "0x4000058")]
			[FieldOffset(Offset = "0x18")]
			private Sprite m_Image;

			[Token(Token = "0x17000023")]
			public string text
			{
				[Token(Token = "0x60000AF")]
				[Address(RVA = "0x16CAFE0", Offset = "0x16CAFE0", Length = "0x8")]
				get
				{
					return null;
				}
				[Token(Token = "0x60000B0")]
				[Address(RVA = "0x16CAFE8", Offset = "0x16CAFE8", Length = "0x8")]
				set
				{
				}
			}

			[Token(Token = "0x17000024")]
			public Sprite image
			{
				[Token(Token = "0x60000B1")]
				[Address(RVA = "0x16CAFF0", Offset = "0x16CAFF0", Length = "0x8")]
				get
				{
					return null;
				}
				[Token(Token = "0x60000B2")]
				[Address(RVA = "0x16CAFF8", Offset = "0x16CAFF8", Length = "0x8")]
				set
				{
				}
			}

			[Token(Token = "0x60000B3")]
			[Address(RVA = "0x16C759C", Offset = "0x16C759C", Length = "0x8")]
			public OptionData()
			{
			}

			[Token(Token = "0x60000B4")]
			[Address(RVA = "0x16C8AE8", Offset = "0x16C8AE8", Length = "0x28")]
			public OptionData(string text)
			{
			}

			[Token(Token = "0x60000B5")]
			[Address(RVA = "0x16C8C64", Offset = "0x16C8C64", Length = "0x28")]
			public OptionData(Sprite image)
			{
			}

			[Token(Token = "0x60000B6")]
			[Address(RVA = "0x16CB000", Offset = "0x16CB000", Length = "0x2C")]
			public OptionData(string text, Sprite image)
			{
			}
		}

		[Serializable]
		[Token(Token = "0x2000018")]
		public class OptionDataList
		{
			[SerializeField]
			[Token(Token = "0x4000059")]
			[FieldOffset(Offset = "0x10")]
			private List<OptionData> m_Options;

			[Token(Token = "0x17000025")]
			public List<OptionData> options
			{
				[Token(Token = "0x60000B7")]
				[Address(RVA = "0x16CB02C", Offset = "0x16CB02C", Length = "0x8")]
				get
				{
					return null;
				}
				[Token(Token = "0x60000B8")]
				[Address(RVA = "0x16CB034", Offset = "0x16CB034", Length = "0x8")]
				set
				{
				}
			}

			[Token(Token = "0x60000B9")]
			[Address(RVA = "0x16C84C4", Offset = "0x16C84C4", Length = "0x80")]
			public OptionDataList()
			{
			}
		}

		[Serializable]
		[Token(Token = "0x2000019")]
		public class DropdownEvent : UnityEvent<int>
		{
			[Token(Token = "0x60000BA")]
			[Address(RVA = "0x16C8544", Offset = "0x16C8544", Length = "0x48")]
			public DropdownEvent()
			{
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200001B")]
		private sealed class _003CDelayedDestroyDropdownList_003Ed__75 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x400005C")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x400005D")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x400005E")]
			[FieldOffset(Offset = "0x20")]
			public float delay;

			[Token(Token = "0x400005F")]
			[FieldOffset(Offset = "0x28")]
			public Dropdown _003C_003E4__this;

			[Token(Token = "0x17000026")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60000C0")]
				[Address(RVA = "0x16CB10C", Offset = "0x16CB10C", Length = "0x8")]
				get
				{
					return null;
				}
			}

			[Token(Token = "0x17000027")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60000C2")]
				[Address(RVA = "0x16CB14C", Offset = "0x16CB14C", Length = "0x8")]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60000BD")]
			[Address(RVA = "0x16CACA4", Offset = "0x16CACA4", Length = "0x28")]
			public _003CDelayedDestroyDropdownList_003Ed__75(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			[Token(Token = "0x60000BE")]
			[Address(RVA = "0x16CB060", Offset = "0x16CB060", Length = "0x4")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x60000BF")]
			[Address(RVA = "0x16CB064", Offset = "0x16CB064", Length = "0xA8")]
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
			[Token(Token = "0x60000C1")]
			[Address(RVA = "0x16CB114", Offset = "0x16CB114", Length = "0x38")]
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		[Token(Token = "0x4000043")]
		[FieldOffset(Offset = "0x100")]
		private RectTransform m_Template;

		[SerializeField]
		[Token(Token = "0x4000044")]
		[FieldOffset(Offset = "0x108")]
		private Text m_CaptionText;

		[SerializeField]
		[Token(Token = "0x4000045")]
		[FieldOffset(Offset = "0x110")]
		private Image m_CaptionImage;

		[Space]
		[SerializeField]
		[Token(Token = "0x4000046")]
		[FieldOffset(Offset = "0x118")]
		private Text m_ItemText;

		[SerializeField]
		[Token(Token = "0x4000047")]
		[FieldOffset(Offset = "0x120")]
		private Image m_ItemImage;

		[Space]
		[SerializeField]
		[Token(Token = "0x4000048")]
		[FieldOffset(Offset = "0x128")]
		private int m_Value;

		[Space]
		[SerializeField]
		[Token(Token = "0x4000049")]
		[FieldOffset(Offset = "0x130")]
		private OptionDataList m_Options;

		[SerializeField]
		[Space]
		[Token(Token = "0x400004A")]
		[FieldOffset(Offset = "0x138")]
		private DropdownEvent m_OnValueChanged;

		[SerializeField]
		[Token(Token = "0x400004B")]
		[FieldOffset(Offset = "0x140")]
		private float m_AlphaFadeSpeed;

		[Token(Token = "0x400004C")]
		[FieldOffset(Offset = "0x148")]
		private GameObject m_Dropdown;

		[Token(Token = "0x400004D")]
		[FieldOffset(Offset = "0x150")]
		private GameObject m_Blocker;

		[Token(Token = "0x400004E")]
		[FieldOffset(Offset = "0x158")]
		private List<DropdownItem> m_Items;

		[Token(Token = "0x400004F")]
		[FieldOffset(Offset = "0x160")]
		private TweenRunner<FloatTween> m_AlphaTweenRunner;

		[Token(Token = "0x4000050")]
		[FieldOffset(Offset = "0x168")]
		private bool validTemplate;

		[Token(Token = "0x4000051")]
		private const int kHighSortingLayer = 30000;

		[Token(Token = "0x4000052")]
		private static OptionData s_NoOptionData;

		[Token(Token = "0x17000016")]
		public RectTransform template
		{
			[Token(Token = "0x6000072")]
			[Address(RVA = "0x16C8200", Offset = "0x16C8200", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000073")]
			[Address(RVA = "0x16C7568", Offset = "0x16C7568", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000017")]
		public Text captionText
		{
			[Token(Token = "0x6000074")]
			[Address(RVA = "0x16C8208", Offset = "0x16C8208", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000075")]
			[Address(RVA = "0x16C7570", Offset = "0x16C7570", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000018")]
		public Image captionImage
		{
			[Token(Token = "0x6000076")]
			[Address(RVA = "0x16C8210", Offset = "0x16C8210", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000077")]
			[Address(RVA = "0x16C8218", Offset = "0x16C8218", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000019")]
		public Text itemText
		{
			[Token(Token = "0x6000078")]
			[Address(RVA = "0x16C8220", Offset = "0x16C8220", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000079")]
			[Address(RVA = "0x16C7578", Offset = "0x16C7578", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700001A")]
		public Image itemImage
		{
			[Token(Token = "0x600007A")]
			[Address(RVA = "0x16C8228", Offset = "0x16C8228", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600007B")]
			[Address(RVA = "0x16C8230", Offset = "0x16C8230", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700001B")]
		public List<OptionData> options
		{
			[Token(Token = "0x600007C")]
			[Address(RVA = "0x16C7580", Offset = "0x16C7580", Length = "0x1C")]
			get
			{
				return null;
			}
			[Token(Token = "0x600007D")]
			[Address(RVA = "0x16C8238", Offset = "0x16C8238", Length = "0x1C")]
			set
			{
			}
		}

		[Token(Token = "0x1700001C")]
		public DropdownEvent onValueChanged
		{
			[Token(Token = "0x600007E")]
			[Address(RVA = "0x16C8254", Offset = "0x16C8254", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600007F")]
			[Address(RVA = "0x16C825C", Offset = "0x16C825C", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700001D")]
		public float alphaFadeSpeed
		{
			[Token(Token = "0x6000080")]
			[Address(RVA = "0x16C8264", Offset = "0x16C8264", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000081")]
			[Address(RVA = "0x16C826C", Offset = "0x16C826C", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700001E")]
		public int value
		{
			[Token(Token = "0x6000082")]
			[Address(RVA = "0x16C8274", Offset = "0x16C8274", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x6000083")]
			[Address(RVA = "0x16C827C", Offset = "0x16C827C", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x6000084")]
		[Address(RVA = "0x16C83B8", Offset = "0x16C83B8", Length = "0x8")]
		public void SetValueWithoutNotify(int input)
		{
		}

		[Token(Token = "0x6000085")]
		[Address(RVA = "0x16C8284", Offset = "0x16C8284", Length = "0x134")]
		private void Set(int value, bool sendCallback = true)
		{
		}

		[Token(Token = "0x6000086")]
		[Address(RVA = "0x16C83C0", Offset = "0x16C83C0", Length = "0x104")]
		protected Dropdown()
		{
		}

		[Token(Token = "0x6000087")]
		[Address(RVA = "0x16C858C", Offset = "0x16C858C", Length = "0xFC")]
		protected override void Awake()
		{
		}

		[Token(Token = "0x6000088")]
		[Address(RVA = "0x16C8688", Offset = "0x16C8688", Length = "0x9C")]
		protected override void Start()
		{
		}

		[Token(Token = "0x6000089")]
		[Address(RVA = "0x16C8724", Offset = "0x16C8724", Length = "0x94")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x600008A")]
		[Address(RVA = "0x16C75A4", Offset = "0x16C75A4", Length = "0x1DC")]
		public void RefreshShownValue()
		{
		}

		[Token(Token = "0x600008B")]
		[Address(RVA = "0x16C892C", Offset = "0x16C892C", Length = "0x68")]
		public void AddOptions(List<OptionData> options)
		{
		}

		[Token(Token = "0x600008C")]
		[Address(RVA = "0x16C8994", Offset = "0x16C8994", Length = "0x154")]
		public void AddOptions(List<string> options)
		{
		}

		[Token(Token = "0x600008D")]
		[Address(RVA = "0x16C8B10", Offset = "0x16C8B10", Length = "0x154")]
		public void AddOptions(List<Sprite> options)
		{
		}

		[Token(Token = "0x600008E")]
		[Address(RVA = "0x16C8C8C", Offset = "0x16C8C8C", Length = "0x78")]
		public void ClearOptions()
		{
		}

		[Token(Token = "0x600008F")]
		[Address(RVA = "0x16C8D04", Offset = "0x16C8D04", Length = "0x698")]
		private void SetupTemplate(Canvas rootCanvas)
		{
		}

		[Token(Token = "0x6000090")]
		[Address(RVA = "0xDAD9E8", Offset = "0xDAD9E8", Length = "0xA4")]
		private static T GetOrAddComponent<T>(GameObject go) where T : Component
		{
			return null;
		}

		[Token(Token = "0x6000091")]
		[Address(RVA = "0x16C939C", Offset = "0x16C939C", Length = "0x4")]
		public virtual void OnPointerClick(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000092")]
		[Address(RVA = "0x16C9F20", Offset = "0x16C9F20", Length = "0x4")]
		public virtual void OnSubmit(BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000093")]
		[Address(RVA = "0x16C9F24", Offset = "0x16C9F24", Length = "0x4")]
		public virtual void OnCancel(BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000094")]
		[Address(RVA = "0x16C93A0", Offset = "0x16C93A0", Length = "0xB80")]
		public void Show()
		{
		}

		[Token(Token = "0x6000095")]
		[Address(RVA = "0x16CA430", Offset = "0x16CA430", Length = "0x544")]
		protected virtual GameObject CreateBlocker(Canvas rootCanvas)
		{
			return null;
		}

		[Token(Token = "0x6000096")]
		[Address(RVA = "0x16CA974", Offset = "0x16CA974", Length = "0x58")]
		protected virtual void DestroyBlocker(GameObject blocker)
		{
		}

		[Token(Token = "0x6000097")]
		[Address(RVA = "0x16CA9CC", Offset = "0x16CA9CC", Length = "0x6C")]
		protected virtual GameObject CreateDropdownList(GameObject template)
		{
			return null;
		}

		[Token(Token = "0x6000098")]
		[Address(RVA = "0x16CAA38", Offset = "0x16CAA38", Length = "0x58")]
		protected virtual void DestroyDropdownList(GameObject dropdownList)
		{
		}

		[Token(Token = "0x6000099")]
		[Address(RVA = "0x16CAA90", Offset = "0x16CAA90", Length = "0x6C")]
		protected virtual DropdownItem CreateItem(DropdownItem itemTemplate)
		{
			return null;
		}

		[Token(Token = "0x600009A")]
		[Address(RVA = "0x16CAAFC", Offset = "0x16CAAFC", Length = "0x4")]
		protected virtual void DestroyItem(DropdownItem item)
		{
		}

		[Token(Token = "0x600009B")]
		[Address(RVA = "0x16CA02C", Offset = "0x16CA02C", Length = "0x2E4")]
		private DropdownItem AddItem(OptionData data, bool selected, DropdownItem itemTemplate, List<DropdownItem> items)
		{
			return null;
		}

		[Token(Token = "0x600009C")]
		[Address(RVA = "0x16CAB00", Offset = "0x16CAB00", Length = "0x80")]
		private void AlphaFadeList(float duration, float alpha)
		{
		}

		[Token(Token = "0x600009D")]
		[Address(RVA = "0x16CA310", Offset = "0x16CA310", Length = "0x120")]
		private void AlphaFadeList(float duration, float start, float end)
		{
		}

		[Token(Token = "0x600009E")]
		[Address(RVA = "0x16CAB80", Offset = "0x16CAB80", Length = "0xB4")]
		private void SetAlpha(float alpha)
		{
		}

		[Token(Token = "0x600009F")]
		[Address(RVA = "0x16C9F28", Offset = "0x16C9F28", Length = "0xFC")]
		public void Hide()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedDestroyDropdownList_003Ed__75))]
		[Token(Token = "0x60000A0")]
		[Address(RVA = "0x16CAC34", Offset = "0x16CAC34", Length = "0x70")]
		private IEnumerator DelayedDestroyDropdownList(float delay)
		{
			return null;
		}

		[Token(Token = "0x60000A1")]
		[Address(RVA = "0x16C87B8", Offset = "0x16C87B8", Length = "0x174")]
		private void ImmediateDestroyDropdownList()
		{
		}

		[Token(Token = "0x60000A2")]
		[Address(RVA = "0x16CACCC", Offset = "0x16CACCC", Length = "0x134")]
		private void OnSelectItem(Toggle toggle)
		{
		}
	}
}
