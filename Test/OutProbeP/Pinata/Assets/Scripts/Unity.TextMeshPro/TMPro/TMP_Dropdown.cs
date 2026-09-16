using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace TMPro
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x74812C", Offset = "0x74812C")]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x74812C", Offset = "0x74812C")]
	[Token(Token = "0x2000017")]
	public class TMP_Dropdown : Selectable, IPointerClickHandler, IEventSystemHandler, ISubmitHandler, ICancelHandler
	{
		[Token(Token = "0x2000075")]
		protected internal class DropdownItem : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, ICancelHandler
		{
			[SerializeField]
			[Token(Token = "0x4000494")]
			[FieldOffset(Offset = "0x18")]
			private TMP_Text m_Text;

			[SerializeField]
			[Token(Token = "0x4000495")]
			[FieldOffset(Offset = "0x20")]
			private Image m_Image;

			[SerializeField]
			[Token(Token = "0x4000496")]
			[FieldOffset(Offset = "0x28")]
			private RectTransform m_RectTransform;

			[SerializeField]
			[Token(Token = "0x4000497")]
			[FieldOffset(Offset = "0x30")]
			private Toggle m_Toggle;

			[Token(Token = "0x1700013F")]
			public TMP_Text text
			{
				[Token(Token = "0x600054B")]
				[Address(RVA = "0x921188", Offset = "0x921188", Length = "0x8")]
				get
				{
					return null;
				}
				[Token(Token = "0x600054C")]
				[Address(RVA = "0x921190", Offset = "0x921190", Length = "0x8")]
				set
				{
				}
			}

			[Token(Token = "0x17000140")]
			public Image image
			{
				[Token(Token = "0x600054D")]
				[Address(RVA = "0x921198", Offset = "0x921198", Length = "0x8")]
				get
				{
					return null;
				}
				[Token(Token = "0x600054E")]
				[Address(RVA = "0x9211A0", Offset = "0x9211A0", Length = "0x8")]
				set
				{
				}
			}

			[Token(Token = "0x17000141")]
			public RectTransform rectTransform
			{
				[Token(Token = "0x600054F")]
				[Address(RVA = "0x9211A8", Offset = "0x9211A8", Length = "0x8")]
				get
				{
					return null;
				}
				[Token(Token = "0x6000550")]
				[Address(RVA = "0x9211B0", Offset = "0x9211B0", Length = "0x8")]
				set
				{
				}
			}

			[Token(Token = "0x17000142")]
			public Toggle toggle
			{
				[Token(Token = "0x6000551")]
				[Address(RVA = "0x9211B8", Offset = "0x9211B8", Length = "0x8")]
				get
				{
					return null;
				}
				[Token(Token = "0x6000552")]
				[Address(RVA = "0x9211C0", Offset = "0x9211C0", Length = "0x8")]
				set
				{
				}
			}

			[Token(Token = "0x6000553")]
			[Address(RVA = "0x9211C8", Offset = "0x9211C8", Length = "0x90")]
			public virtual void OnPointerEnter(PointerEventData eventData)
			{
			}

			[Token(Token = "0x6000554")]
			[Address(RVA = "0x921258", Offset = "0x921258", Length = "0xA8")]
			public virtual void OnCancel(BaseEventData eventData)
			{
			}

			[Token(Token = "0x6000555")]
			[Address(RVA = "0x921300", Offset = "0x921300", Length = "0x8")]
			public DropdownItem()
			{
			}
		}

		[Serializable]
		[Token(Token = "0x2000076")]
		public class OptionData
		{
			[SerializeField]
			[Token(Token = "0x4000498")]
			[FieldOffset(Offset = "0x10")]
			private string m_Text;

			[SerializeField]
			[Token(Token = "0x4000499")]
			[FieldOffset(Offset = "0x18")]
			private Sprite m_Image;

			[Token(Token = "0x17000143")]
			public string text
			{
				[Token(Token = "0x6000556")]
				[Address(RVA = "0x921308", Offset = "0x921308", Length = "0x8")]
				get
				{
					return null;
				}
				[Token(Token = "0x6000557")]
				[Address(RVA = "0x921310", Offset = "0x921310", Length = "0x8")]
				set
				{
				}
			}

			[Token(Token = "0x17000144")]
			public Sprite image
			{
				[Token(Token = "0x6000558")]
				[Address(RVA = "0x921318", Offset = "0x921318", Length = "0x8")]
				get
				{
					return null;
				}
				[Token(Token = "0x6000559")]
				[Address(RVA = "0x921320", Offset = "0x921320", Length = "0x8")]
				set
				{
				}
			}

			[Token(Token = "0x600055A")]
			[Address(RVA = "0x91E440", Offset = "0x91E440", Length = "0x8")]
			public OptionData()
			{
			}

			[Token(Token = "0x600055B")]
			[Address(RVA = "0x91F00C", Offset = "0x91F00C", Length = "0x2C")]
			public OptionData(string text)
			{
			}

			[Token(Token = "0x600055C")]
			[Address(RVA = "0x91F128", Offset = "0x91F128", Length = "0x2C")]
			public OptionData(Sprite image)
			{
			}

			[Token(Token = "0x600055D")]
			[Address(RVA = "0x921328", Offset = "0x921328", Length = "0x38")]
			public OptionData(string text, Sprite image)
			{
			}
		}

		[Serializable]
		[Token(Token = "0x2000077")]
		public class OptionDataList
		{
			[SerializeField]
			[Token(Token = "0x400049A")]
			[FieldOffset(Offset = "0x10")]
			private List<OptionData> m_Options;

			[Token(Token = "0x17000145")]
			public List<OptionData> options
			{
				[Token(Token = "0x600055E")]
				[Address(RVA = "0x921360", Offset = "0x921360", Length = "0x8")]
				get
				{
					return null;
				}
				[Token(Token = "0x600055F")]
				[Address(RVA = "0x921368", Offset = "0x921368", Length = "0x8")]
				set
				{
				}
			}

			[Token(Token = "0x6000560")]
			[Address(RVA = "0x91EA5C", Offset = "0x91EA5C", Length = "0x74")]
			public OptionDataList()
			{
			}
		}

		[Serializable]
		[Token(Token = "0x2000078")]
		public class DropdownEvent : UnityEvent<int>
		{
			[Token(Token = "0x6000561")]
			[Address(RVA = "0x91EAD0", Offset = "0x91EAD0", Length = "0x50")]
			public DropdownEvent()
			{
			}
		}

		[SerializeField]
		[Token(Token = "0x400009D")]
		[FieldOffset(Offset = "0xE8")]
		private RectTransform m_Template;

		[SerializeField]
		[Token(Token = "0x400009E")]
		[FieldOffset(Offset = "0xF0")]
		private TMP_Text m_CaptionText;

		[SerializeField]
		[Token(Token = "0x400009F")]
		[FieldOffset(Offset = "0xF8")]
		private Image m_CaptionImage;

		[Space]
		[SerializeField]
		[Token(Token = "0x40000A0")]
		[FieldOffset(Offset = "0x100")]
		private TMP_Text m_ItemText;

		[SerializeField]
		[Token(Token = "0x40000A1")]
		[FieldOffset(Offset = "0x108")]
		private Image m_ItemImage;

		[Space]
		[SerializeField]
		[Token(Token = "0x40000A2")]
		[FieldOffset(Offset = "0x110")]
		private int m_Value;

		[Space]
		[SerializeField]
		[Token(Token = "0x40000A3")]
		[FieldOffset(Offset = "0x118")]
		private OptionDataList m_Options;

		[Space]
		[SerializeField]
		[Token(Token = "0x40000A4")]
		[FieldOffset(Offset = "0x120")]
		private DropdownEvent m_OnValueChanged;

		[Token(Token = "0x40000A5")]
		[FieldOffset(Offset = "0x128")]
		private GameObject m_Dropdown;

		[Token(Token = "0x40000A6")]
		[FieldOffset(Offset = "0x130")]
		private GameObject m_Blocker;

		[Token(Token = "0x40000A7")]
		[FieldOffset(Offset = "0x138")]
		private List<DropdownItem> m_Items;

		[Token(Token = "0x40000A8")]
		[FieldOffset(Offset = "0x140")]
		private TweenRunner<FloatTween> m_AlphaTweenRunner;

		[Token(Token = "0x40000A9")]
		[FieldOffset(Offset = "0x148")]
		private bool validTemplate;

		[Token(Token = "0x40000AA")]
		private static OptionData s_NoOptionData;

		[Token(Token = "0x1700002A")]
		public RectTransform template
		{
			[Token(Token = "0x6000117")]
			[Address(RVA = "0x91E780", Offset = "0x91E780", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000118")]
			[Address(RVA = "0x91E408", Offset = "0x91E408", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700002B")]
		public TMP_Text captionText
		{
			[Token(Token = "0x6000119")]
			[Address(RVA = "0x91E788", Offset = "0x91E788", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600011A")]
			[Address(RVA = "0x91E410", Offset = "0x91E410", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700002C")]
		public Image captionImage
		{
			[Token(Token = "0x600011B")]
			[Address(RVA = "0x91E790", Offset = "0x91E790", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600011C")]
			[Address(RVA = "0x91E798", Offset = "0x91E798", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700002D")]
		public TMP_Text itemText
		{
			[Token(Token = "0x600011D")]
			[Address(RVA = "0x91E7A0", Offset = "0x91E7A0", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600011E")]
			[Address(RVA = "0x91E418", Offset = "0x91E418", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700002E")]
		public Image itemImage
		{
			[Token(Token = "0x600011F")]
			[Address(RVA = "0x91E7A8", Offset = "0x91E7A8", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000120")]
			[Address(RVA = "0x91E7B0", Offset = "0x91E7B0", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700002F")]
		public List<OptionData> options
		{
			[Token(Token = "0x6000121")]
			[Address(RVA = "0x91E420", Offset = "0x91E420", Length = "0x20")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000122")]
			[Address(RVA = "0x91E7B8", Offset = "0x91E7B8", Length = "0x20")]
			set
			{
			}
		}

		[Token(Token = "0x17000030")]
		public DropdownEvent onValueChanged
		{
			[Token(Token = "0x6000123")]
			[Address(RVA = "0x91E7D8", Offset = "0x91E7D8", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000124")]
			[Address(RVA = "0x91E7E0", Offset = "0x91E7E0", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000031")]
		public int value
		{
			[Token(Token = "0x6000125")]
			[Address(RVA = "0x91E7E8", Offset = "0x91E7E8", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x6000126")]
			[Address(RVA = "0x91E7F0", Offset = "0x91E7F0", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000032")]
		public bool IsExpanded
		{
			[Token(Token = "0x6000129")]
			[Address(RVA = "0x91E924", Offset = "0x91E924", Length = "0x70")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x6000127")]
		[Address(RVA = "0x91E91C", Offset = "0x91E91C", Length = "0x8")]
		public void SetValueWithoutNotify(int input)
		{
		}

		[Token(Token = "0x6000128")]
		[Address(RVA = "0x91E7F8", Offset = "0x91E7F8", Length = "0x124")]
		private void SetValue(int value, bool sendCallback = true)
		{
		}

		[Token(Token = "0x600012A")]
		[Address(RVA = "0x91E994", Offset = "0x91E994", Length = "0xC8")]
		protected TMP_Dropdown()
		{
		}

		[Token(Token = "0x600012B")]
		[Address(RVA = "0x91EB20", Offset = "0x91EB20", Length = "0x150")]
		protected override void Awake()
		{
		}

		[Token(Token = "0x600012C")]
		[Address(RVA = "0x91EC70", Offset = "0x91EC70", Length = "0x28")]
		protected override void Start()
		{
		}

		[Token(Token = "0x600012D")]
		[Address(RVA = "0x91EC98", Offset = "0x91EC98", Length = "0x9C")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x600012E")]
		[Address(RVA = "0x91E448", Offset = "0x91E448", Length = "0x204")]
		public void RefreshShownValue()
		{
		}

		[Token(Token = "0x600012F")]
		[Address(RVA = "0x91EEA0", Offset = "0x91EEA0", Length = "0x7C")]
		public void AddOptions(List<OptionData> options)
		{
		}

		[Token(Token = "0x6000130")]
		[Address(RVA = "0x91EF1C", Offset = "0x91EF1C", Length = "0xF0")]
		public void AddOptions(List<string> options)
		{
		}

		[Token(Token = "0x6000131")]
		[Address(RVA = "0x91F038", Offset = "0x91F038", Length = "0xF0")]
		public void AddOptions(List<Sprite> options)
		{
		}

		[Token(Token = "0x6000132")]
		[Address(RVA = "0x91F154", Offset = "0x91F154", Length = "0x70")]
		public void ClearOptions()
		{
		}

		[Token(Token = "0x6000133")]
		[Address(RVA = "0x91F1C4", Offset = "0x91F1C4", Length = "0x4B0")]
		private void SetupTemplate()
		{
		}

		[Token(Token = "0x6000134")]
		[Address(RVA = "0xACC3D4", Offset = "0xACC3D4", Length = "0xC8")]
		private static T GetOrAddComponent<T>(GameObject go) where T : Component
		{
			return null;
		}

		[Token(Token = "0x6000135")]
		[Address(RVA = "0x91F674", Offset = "0x91F674", Length = "0x4")]
		public virtual void OnPointerClick(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000136")]
		[Address(RVA = "0x92033C", Offset = "0x92033C", Length = "0x4")]
		public virtual void OnSubmit(BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000137")]
		[Address(RVA = "0x920340", Offset = "0x920340", Length = "0x4")]
		public virtual void OnCancel(BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000138")]
		[Address(RVA = "0x91F678", Offset = "0x91F678", Length = "0xCC4")]
		public void Show()
		{
		}

		[Token(Token = "0x6000139")]
		[Address(RVA = "0x920830", Offset = "0x920830", Length = "0x2A4")]
		protected virtual GameObject CreateBlocker(Canvas rootCanvas)
		{
			return null;
		}

		[Token(Token = "0x600013A")]
		[Address(RVA = "0x920AD4", Offset = "0x920AD4", Length = "0x68")]
		protected virtual void DestroyBlocker(GameObject blocker)
		{
		}

		[Token(Token = "0x600013B")]
		[Address(RVA = "0x920B3C", Offset = "0x920B3C", Length = "0x70")]
		protected virtual GameObject CreateDropdownList(GameObject template)
		{
			return null;
		}

		[Token(Token = "0x600013C")]
		[Address(RVA = "0x920BAC", Offset = "0x920BAC", Length = "0x68")]
		protected virtual void DestroyDropdownList(GameObject dropdownList)
		{
		}

		[Token(Token = "0x600013D")]
		[Address(RVA = "0x920C14", Offset = "0x920C14", Length = "0x70")]
		protected virtual DropdownItem CreateItem(DropdownItem itemTemplate)
		{
			return null;
		}

		[Token(Token = "0x600013E")]
		[Address(RVA = "0x920C84", Offset = "0x920C84", Length = "0x4")]
		protected virtual void DestroyItem(DropdownItem item)
		{
		}

		[Token(Token = "0x600013F")]
		[Address(RVA = "0x920478", Offset = "0x920478", Length = "0x2A0")]
		private DropdownItem AddItem(OptionData data, bool selected, DropdownItem itemTemplate, List<DropdownItem> items)
		{
			return null;
		}

		[Token(Token = "0x6000140")]
		[Address(RVA = "0x920C88", Offset = "0x920C88", Length = "0x88")]
		private void AlphaFadeList(float duration, float alpha)
		{
		}

		[Token(Token = "0x6000141")]
		[Address(RVA = "0x920718", Offset = "0x920718", Length = "0x118")]
		private void AlphaFadeList(float duration, float start, float end)
		{
		}

		[Token(Token = "0x6000142")]
		[Address(RVA = "0x920D10", Offset = "0x920D10", Length = "0xB8")]
		private void SetAlpha(float alpha)
		{
		}

		[Token(Token = "0x6000143")]
		[Address(RVA = "0x920344", Offset = "0x920344", Length = "0x12C")]
		public void Hide()
		{
		}

		[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x74956C", Offset = "0x74956C")]
		[Token(Token = "0x6000144")]
		[Address(RVA = "0x920DC8", Offset = "0x920DC8", Length = "0x84")]
		private IEnumerator DelayedDestroyDropdownList(float delay)
		{
			return null;
		}

		[Token(Token = "0x6000145")]
		[Address(RVA = "0x91ED34", Offset = "0x91ED34", Length = "0x16C")]
		private void ImmediateDestroyDropdownList()
		{
		}

		[Token(Token = "0x6000146")]
		[Address(RVA = "0x920E78", Offset = "0x920E78", Length = "0x150")]
		private void OnSelectItem(Toggle toggle)
		{
		}
	}
}
