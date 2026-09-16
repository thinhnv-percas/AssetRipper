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
	[RequireComponent(typeof(RectTransform))]
	[AddComponentMenu("UI/Dropdown - TextMeshPro", 35)]
	[Token(Token = "0x2000036")]
	public class TMP_Dropdown : Selectable, IPointerClickHandler, IEventSystemHandler, ISubmitHandler, ICancelHandler
	{
		[Token(Token = "0x2000037")]
		protected internal class DropdownItem : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, ICancelHandler
		{
			[SerializeField]
			[Token(Token = "0x4000199")]
			[FieldOffset(Offset = "0x20")]
			private TMP_Text m_Text;

			[SerializeField]
			[Token(Token = "0x400019A")]
			[FieldOffset(Offset = "0x28")]
			private Image m_Image;

			[SerializeField]
			[Token(Token = "0x400019B")]
			[FieldOffset(Offset = "0x30")]
			private RectTransform m_RectTransform;

			[SerializeField]
			[Token(Token = "0x400019C")]
			[FieldOffset(Offset = "0x38")]
			private Toggle m_Toggle;

			[Token(Token = "0x17000044")]
			public TMP_Text text
			{
				[Token(Token = "0x60001B6")]
				[Address(RVA = "0x15D5D50", Offset = "0x15D5D50", Length = "0x8")]
				get
				{
					return null;
				}
				[Token(Token = "0x60001B7")]
				[Address(RVA = "0x15D5D58", Offset = "0x15D5D58", Length = "0x8")]
				set
				{
				}
			}

			[Token(Token = "0x17000045")]
			public Image image
			{
				[Token(Token = "0x60001B8")]
				[Address(RVA = "0x15D5D60", Offset = "0x15D5D60", Length = "0x8")]
				get
				{
					return null;
				}
				[Token(Token = "0x60001B9")]
				[Address(RVA = "0x15D5D68", Offset = "0x15D5D68", Length = "0x8")]
				set
				{
				}
			}

			[Token(Token = "0x17000046")]
			public RectTransform rectTransform
			{
				[Token(Token = "0x60001BA")]
				[Address(RVA = "0x15D5D70", Offset = "0x15D5D70", Length = "0x8")]
				get
				{
					return null;
				}
				[Token(Token = "0x60001BB")]
				[Address(RVA = "0x15D5D78", Offset = "0x15D5D78", Length = "0x8")]
				set
				{
				}
			}

			[Token(Token = "0x17000047")]
			public Toggle toggle
			{
				[Token(Token = "0x60001BC")]
				[Address(RVA = "0x15D5D80", Offset = "0x15D5D80", Length = "0x8")]
				get
				{
					return null;
				}
				[Token(Token = "0x60001BD")]
				[Address(RVA = "0x15D5D88", Offset = "0x15D5D88", Length = "0x8")]
				set
				{
				}
			}

			[Token(Token = "0x60001BE")]
			[Address(RVA = "0x15D5D90", Offset = "0x15D5D90", Length = "0x7C")]
			public virtual void OnPointerEnter(PointerEventData eventData)
			{
			}

			[Token(Token = "0x60001BF")]
			[Address(RVA = "0x15D5E0C", Offset = "0x15D5E0C", Length = "0xAC")]
			public virtual void OnCancel(BaseEventData eventData)
			{
			}

			[Token(Token = "0x60001C0")]
			[Address(RVA = "0x15D5EB8", Offset = "0x15D5EB8", Length = "0x8")]
			public DropdownItem()
			{
			}
		}

		[Serializable]
		[Token(Token = "0x2000038")]
		public class OptionData
		{
			[SerializeField]
			[Token(Token = "0x400019D")]
			[FieldOffset(Offset = "0x10")]
			private string m_Text;

			[SerializeField]
			[Token(Token = "0x400019E")]
			[FieldOffset(Offset = "0x18")]
			private Sprite m_Image;

			[Token(Token = "0x17000048")]
			public string text
			{
				[Token(Token = "0x60001C1")]
				[Address(RVA = "0x15D5EC0", Offset = "0x15D5EC0", Length = "0x8")]
				get
				{
					return null;
				}
				[Token(Token = "0x60001C2")]
				[Address(RVA = "0x15D5EC8", Offset = "0x15D5EC8", Length = "0x8")]
				set
				{
				}
			}

			[Token(Token = "0x17000049")]
			public Sprite image
			{
				[Token(Token = "0x60001C3")]
				[Address(RVA = "0x15D5ED0", Offset = "0x15D5ED0", Length = "0x8")]
				get
				{
					return null;
				}
				[Token(Token = "0x60001C4")]
				[Address(RVA = "0x15D5ED8", Offset = "0x15D5ED8", Length = "0x8")]
				set
				{
				}
			}

			[Token(Token = "0x60001C5")]
			[Address(RVA = "0x15D2D58", Offset = "0x15D2D58", Length = "0x8")]
			public OptionData()
			{
			}

			[Token(Token = "0x60001C6")]
			[Address(RVA = "0x15D39D4", Offset = "0x15D39D4", Length = "0x28")]
			public OptionData(string text)
			{
			}

			[Token(Token = "0x60001C7")]
			[Address(RVA = "0x15D3B4C", Offset = "0x15D3B4C", Length = "0x28")]
			public OptionData(Sprite image)
			{
			}

			[Token(Token = "0x60001C8")]
			[Address(RVA = "0x15D5EE0", Offset = "0x15D5EE0", Length = "0x2C")]
			public OptionData(string text, Sprite image)
			{
			}
		}

		[Serializable]
		[Token(Token = "0x2000039")]
		public class OptionDataList
		{
			[SerializeField]
			[Token(Token = "0x400019F")]
			[FieldOffset(Offset = "0x10")]
			private List<OptionData> m_Options;

			[Token(Token = "0x1700004A")]
			public List<OptionData> options
			{
				[Token(Token = "0x60001C9")]
				[Address(RVA = "0x15D5F0C", Offset = "0x15D5F0C", Length = "0x8")]
				get
				{
					return null;
				}
				[Token(Token = "0x60001CA")]
				[Address(RVA = "0x15D5F14", Offset = "0x15D5F14", Length = "0x8")]
				set
				{
				}
			}

			[Token(Token = "0x60001CB")]
			[Address(RVA = "0x15D3390", Offset = "0x15D3390", Length = "0x80")]
			public OptionDataList()
			{
			}
		}

		[Serializable]
		[Token(Token = "0x200003A")]
		public class DropdownEvent : UnityEvent<int>
		{
			[Token(Token = "0x60001CC")]
			[Address(RVA = "0x15D3410", Offset = "0x15D3410", Length = "0x48")]
			public DropdownEvent()
			{
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x200003C")]
		private sealed class _003CDelayedDestroyDropdownList_003Ed__81 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x40001A2")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x40001A3")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x40001A4")]
			[FieldOffset(Offset = "0x20")]
			public float delay;

			[Token(Token = "0x40001A5")]
			[FieldOffset(Offset = "0x28")]
			public TMP_Dropdown _003C_003E4__this;

			[Token(Token = "0x1700004B")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60001D2")]
				[Address(RVA = "0x15D5FEC", Offset = "0x15D5FEC", Length = "0x8")]
				get
				{
					return null;
				}
			}

			[Token(Token = "0x1700004C")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60001D4")]
				[Address(RVA = "0x15D602C", Offset = "0x15D602C", Length = "0x8")]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60001CF")]
			[Address(RVA = "0x15D5B84", Offset = "0x15D5B84", Length = "0x28")]
			public _003CDelayedDestroyDropdownList_003Ed__81(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			[Token(Token = "0x60001D0")]
			[Address(RVA = "0x15D5F40", Offset = "0x15D5F40", Length = "0x4")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x60001D1")]
			[Address(RVA = "0x15D5F44", Offset = "0x15D5F44", Length = "0xA8")]
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
			[Token(Token = "0x60001D3")]
			[Address(RVA = "0x15D5FF4", Offset = "0x15D5FF4", Length = "0x38")]
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		[Token(Token = "0x4000188")]
		[FieldOffset(Offset = "0x100")]
		private RectTransform m_Template;

		[SerializeField]
		[Token(Token = "0x4000189")]
		[FieldOffset(Offset = "0x108")]
		private TMP_Text m_CaptionText;

		[SerializeField]
		[Token(Token = "0x400018A")]
		[FieldOffset(Offset = "0x110")]
		private Image m_CaptionImage;

		[SerializeField]
		[Token(Token = "0x400018B")]
		[FieldOffset(Offset = "0x118")]
		private Graphic m_Placeholder;

		[SerializeField]
		[Space]
		[Token(Token = "0x400018C")]
		[FieldOffset(Offset = "0x120")]
		private TMP_Text m_ItemText;

		[SerializeField]
		[Token(Token = "0x400018D")]
		[FieldOffset(Offset = "0x128")]
		private Image m_ItemImage;

		[SerializeField]
		[Space]
		[Token(Token = "0x400018E")]
		[FieldOffset(Offset = "0x130")]
		private int m_Value;

		[SerializeField]
		[Space]
		[Token(Token = "0x400018F")]
		[FieldOffset(Offset = "0x138")]
		private OptionDataList m_Options;

		[SerializeField]
		[Space]
		[Token(Token = "0x4000190")]
		[FieldOffset(Offset = "0x140")]
		private DropdownEvent m_OnValueChanged;

		[SerializeField]
		[Token(Token = "0x4000191")]
		[FieldOffset(Offset = "0x148")]
		private float m_AlphaFadeSpeed;

		[Token(Token = "0x4000192")]
		[FieldOffset(Offset = "0x150")]
		private GameObject m_Dropdown;

		[Token(Token = "0x4000193")]
		[FieldOffset(Offset = "0x158")]
		private GameObject m_Blocker;

		[Token(Token = "0x4000194")]
		[FieldOffset(Offset = "0x160")]
		private List<DropdownItem> m_Items;

		[Token(Token = "0x4000195")]
		[FieldOffset(Offset = "0x168")]
		private TweenRunner<FloatTween> m_AlphaTweenRunner;

		[Token(Token = "0x4000196")]
		[FieldOffset(Offset = "0x170")]
		private bool validTemplate;

		[Token(Token = "0x4000197")]
		[FieldOffset(Offset = "0x178")]
		private Coroutine m_Coroutine;

		[Token(Token = "0x4000198")]
		private static OptionData s_NoOptionData;

		[Token(Token = "0x17000039")]
		public RectTransform template
		{
			[Token(Token = "0x6000181")]
			[Address(RVA = "0x15D3028", Offset = "0x15D3028", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000182")]
			[Address(RVA = "0x15D2D24", Offset = "0x15D2D24", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700003A")]
		public TMP_Text captionText
		{
			[Token(Token = "0x6000183")]
			[Address(RVA = "0x15D3030", Offset = "0x15D3030", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000184")]
			[Address(RVA = "0x15D2D2C", Offset = "0x15D2D2C", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700003B")]
		public Image captionImage
		{
			[Token(Token = "0x6000185")]
			[Address(RVA = "0x15D3038", Offset = "0x15D3038", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000186")]
			[Address(RVA = "0x15D3040", Offset = "0x15D3040", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700003C")]
		public Graphic placeholder
		{
			[Token(Token = "0x6000187")]
			[Address(RVA = "0x15D3048", Offset = "0x15D3048", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000188")]
			[Address(RVA = "0x15D3050", Offset = "0x15D3050", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700003D")]
		public TMP_Text itemText
		{
			[Token(Token = "0x6000189")]
			[Address(RVA = "0x15D3058", Offset = "0x15D3058", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600018A")]
			[Address(RVA = "0x15D2D34", Offset = "0x15D2D34", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700003E")]
		public Image itemImage
		{
			[Token(Token = "0x600018B")]
			[Address(RVA = "0x15D3060", Offset = "0x15D3060", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600018C")]
			[Address(RVA = "0x15D3068", Offset = "0x15D3068", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700003F")]
		public List<OptionData> options
		{
			[Token(Token = "0x600018D")]
			[Address(RVA = "0x15D2D3C", Offset = "0x15D2D3C", Length = "0x1C")]
			get
			{
				return null;
			}
			[Token(Token = "0x600018E")]
			[Address(RVA = "0x15D3070", Offset = "0x15D3070", Length = "0x1C")]
			set
			{
			}
		}

		[Token(Token = "0x17000040")]
		public DropdownEvent onValueChanged
		{
			[Token(Token = "0x600018F")]
			[Address(RVA = "0x15D308C", Offset = "0x15D308C", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000190")]
			[Address(RVA = "0x15D3094", Offset = "0x15D3094", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000041")]
		public float alphaFadeSpeed
		{
			[Token(Token = "0x6000191")]
			[Address(RVA = "0x15D309C", Offset = "0x15D309C", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000192")]
			[Address(RVA = "0x15D30A4", Offset = "0x15D30A4", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000042")]
		public int value
		{
			[Token(Token = "0x6000193")]
			[Address(RVA = "0x15D30AC", Offset = "0x15D30AC", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x6000194")]
			[Address(RVA = "0x15D30B4", Offset = "0x15D30B4", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000043")]
		public bool IsExpanded
		{
			[Token(Token = "0x6000197")]
			[Address(RVA = "0x15D322C", Offset = "0x15D322C", Length = "0x60")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x6000195")]
		[Address(RVA = "0x15D3224", Offset = "0x15D3224", Length = "0x8")]
		public void SetValueWithoutNotify(int input)
		{
		}

		[Token(Token = "0x6000196")]
		[Address(RVA = "0x15D30BC", Offset = "0x15D30BC", Length = "0x168")]
		private void SetValue(int value, bool sendCallback = true)
		{
		}

		[Token(Token = "0x6000198")]
		[Address(RVA = "0x15D328C", Offset = "0x15D328C", Length = "0x104")]
		protected TMP_Dropdown()
		{
		}

		[Token(Token = "0x6000199")]
		[Address(RVA = "0x15D3458", Offset = "0x15D3458", Length = "0xFC")]
		protected override void Awake()
		{
		}

		[Token(Token = "0x600019A")]
		[Address(RVA = "0x15D3554", Offset = "0x15D3554", Length = "0x9C")]
		protected override void Start()
		{
		}

		[Token(Token = "0x600019B")]
		[Address(RVA = "0x15D35F0", Offset = "0x15D35F0", Length = "0x94")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x600019C")]
		[Address(RVA = "0x15D2D60", Offset = "0x15D2D60", Length = "0x238")]
		public void RefreshShownValue()
		{
		}

		[Token(Token = "0x600019D")]
		[Address(RVA = "0x15D381C", Offset = "0x15D381C", Length = "0x68")]
		public void AddOptions(List<OptionData> options)
		{
		}

		[Token(Token = "0x600019E")]
		[Address(RVA = "0x15D3884", Offset = "0x15D3884", Length = "0x150")]
		public void AddOptions(List<string> options)
		{
		}

		[Token(Token = "0x600019F")]
		[Address(RVA = "0x15D39FC", Offset = "0x15D39FC", Length = "0x150")]
		public void AddOptions(List<Sprite> options)
		{
		}

		[Token(Token = "0x60001A0")]
		[Address(RVA = "0x15D3B74", Offset = "0x15D3B74", Length = "0xB0")]
		public void ClearOptions()
		{
		}

		[Token(Token = "0x60001A1")]
		[Address(RVA = "0x15D3C24", Offset = "0x15D3C24", Length = "0x670")]
		private void SetupTemplate()
		{
		}

		[Token(Token = "0x60001A2")]
		[Address(RVA = "0xCABD68", Offset = "0xCABD68", Length = "0xA4")]
		private static T GetOrAddComponent<T>(GameObject go) where T : Component
		{
			return null;
		}

		[Token(Token = "0x60001A3")]
		[Address(RVA = "0x15D4294", Offset = "0x15D4294", Length = "0x4")]
		public virtual void OnPointerClick(PointerEventData eventData)
		{
		}

		[Token(Token = "0x60001A4")]
		[Address(RVA = "0x15D4E60", Offset = "0x15D4E60", Length = "0x4")]
		public virtual void OnSubmit(BaseEventData eventData)
		{
		}

		[Token(Token = "0x60001A5")]
		[Address(RVA = "0x15D4E64", Offset = "0x15D4E64", Length = "0x4")]
		public virtual void OnCancel(BaseEventData eventData)
		{
		}

		[Token(Token = "0x60001A6")]
		[Address(RVA = "0x15D4298", Offset = "0x15D4298", Length = "0xBC8")]
		public void Show()
		{
		}

		[Token(Token = "0x60001A7")]
		[Address(RVA = "0x15D5380", Offset = "0x15D5380", Length = "0x4D4")]
		protected virtual GameObject CreateBlocker(Canvas rootCanvas)
		{
			return null;
		}

		[Token(Token = "0x60001A8")]
		[Address(RVA = "0x15D5854", Offset = "0x15D5854", Length = "0x58")]
		protected virtual void DestroyBlocker(GameObject blocker)
		{
		}

		[Token(Token = "0x60001A9")]
		[Address(RVA = "0x15D58AC", Offset = "0x15D58AC", Length = "0x6C")]
		protected virtual GameObject CreateDropdownList(GameObject template)
		{
			return null;
		}

		[Token(Token = "0x60001AA")]
		[Address(RVA = "0x15D5918", Offset = "0x15D5918", Length = "0x58")]
		protected virtual void DestroyDropdownList(GameObject dropdownList)
		{
		}

		[Token(Token = "0x60001AB")]
		[Address(RVA = "0x15D5970", Offset = "0x15D5970", Length = "0x6C")]
		protected virtual DropdownItem CreateItem(DropdownItem itemTemplate)
		{
			return null;
		}

		[Token(Token = "0x60001AC")]
		[Address(RVA = "0x15D59DC", Offset = "0x15D59DC", Length = "0x4")]
		protected virtual void DestroyItem(DropdownItem item)
		{
		}

		[Token(Token = "0x60001AD")]
		[Address(RVA = "0x15D4F84", Offset = "0x15D4F84", Length = "0x2E8")]
		private DropdownItem AddItem(OptionData data, bool selected, DropdownItem itemTemplate, List<DropdownItem> items)
		{
			return null;
		}

		[Token(Token = "0x60001AE")]
		[Address(RVA = "0x15D59E0", Offset = "0x15D59E0", Length = "0x80")]
		private void AlphaFadeList(float duration, float alpha)
		{
		}

		[Token(Token = "0x60001AF")]
		[Address(RVA = "0x15D526C", Offset = "0x15D526C", Length = "0x114")]
		private void AlphaFadeList(float duration, float start, float end)
		{
		}

		[Token(Token = "0x60001B0")]
		[Address(RVA = "0x15D5A60", Offset = "0x15D5A60", Length = "0xB4")]
		private void SetAlpha(float alpha)
		{
		}

		[Token(Token = "0x60001B1")]
		[Address(RVA = "0x15D4E68", Offset = "0x15D4E68", Length = "0x114")]
		public void Hide()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedDestroyDropdownList_003Ed__81))]
		[Token(Token = "0x60001B2")]
		[Address(RVA = "0x15D5B14", Offset = "0x15D5B14", Length = "0x70")]
		private IEnumerator DelayedDestroyDropdownList(float delay)
		{
			return null;
		}

		[Token(Token = "0x60001B3")]
		[Address(RVA = "0x15D3684", Offset = "0x15D3684", Length = "0x198")]
		private void ImmediateDestroyDropdownList()
		{
		}

		[Token(Token = "0x60001B4")]
		[Address(RVA = "0x15D5BAC", Offset = "0x15D5BAC", Length = "0x134")]
		private void OnSelectItem(Toggle toggle)
		{
		}
	}
}
