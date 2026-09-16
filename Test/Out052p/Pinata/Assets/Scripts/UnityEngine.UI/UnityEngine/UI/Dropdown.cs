using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI.CoroutineTween;

namespace UnityEngine.UI
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x726FA8", Offset = "0x726FA8")]
	[AttributeAttribute(Type = typeof(RequireComponent), RVA = "0x726FA8", Offset = "0x726FA8")]
	[Token(Token = "0x200000E")]
	public class Dropdown : Selectable, IPointerClickHandler, IEventSystemHandler, ISubmitHandler, ICancelHandler
	{
		[Token(Token = "0x2000078")]
		protected internal class DropdownItem : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, ICancelHandler
		{
			[SerializeField]
			[Token(Token = "0x4000228")]
			[FieldOffset(Offset = "0x18")]
			private Text m_Text;

			[SerializeField]
			[Token(Token = "0x4000229")]
			[FieldOffset(Offset = "0x20")]
			private Image m_Image;

			[SerializeField]
			[Token(Token = "0x400022A")]
			[FieldOffset(Offset = "0x28")]
			private RectTransform m_RectTransform;

			[SerializeField]
			[Token(Token = "0x400022B")]
			[FieldOffset(Offset = "0x30")]
			private Toggle m_Toggle;

			[Token(Token = "0x170001AB")]
			public Text text
			{
				[Token(Token = "0x6000620")]
				[Address(RVA = "0xF44748", Offset = "0xF44748", Length = "0x8")]
				get
				{
					return null;
				}
				[Token(Token = "0x6000621")]
				[Address(RVA = "0xF44750", Offset = "0xF44750", Length = "0x8")]
				set
				{
				}
			}

			[Token(Token = "0x170001AC")]
			public Image image
			{
				[Token(Token = "0x6000622")]
				[Address(RVA = "0xF44758", Offset = "0xF44758", Length = "0x8")]
				get
				{
					return null;
				}
				[Token(Token = "0x6000623")]
				[Address(RVA = "0xF44760", Offset = "0xF44760", Length = "0x8")]
				set
				{
				}
			}

			[Token(Token = "0x170001AD")]
			public RectTransform rectTransform
			{
				[Token(Token = "0x6000624")]
				[Address(RVA = "0xF44768", Offset = "0xF44768", Length = "0x8")]
				get
				{
					return null;
				}
				[Token(Token = "0x6000625")]
				[Address(RVA = "0xF44770", Offset = "0xF44770", Length = "0x8")]
				set
				{
				}
			}

			[Token(Token = "0x170001AE")]
			public Toggle toggle
			{
				[Token(Token = "0x6000626")]
				[Address(RVA = "0xF44778", Offset = "0xF44778", Length = "0x8")]
				get
				{
					return null;
				}
				[Token(Token = "0x6000627")]
				[Address(RVA = "0xF44780", Offset = "0xF44780", Length = "0x8")]
				set
				{
				}
			}

			[Token(Token = "0x6000628")]
			[Address(RVA = "0xF44788", Offset = "0xF44788", Length = "0x90")]
			public virtual void OnPointerEnter(PointerEventData eventData)
			{
			}

			[Token(Token = "0x6000629")]
			[Address(RVA = "0xF44818", Offset = "0xF44818", Length = "0xAC")]
			public virtual void OnCancel(BaseEventData eventData)
			{
			}

			[Token(Token = "0x600062A")]
			[Address(RVA = "0xF448C4", Offset = "0xF448C4", Length = "0x8")]
			public DropdownItem()
			{
			}
		}

		[Serializable]
		[Token(Token = "0x2000079")]
		public class OptionData
		{
			[SerializeField]
			[Token(Token = "0x400022C")]
			[FieldOffset(Offset = "0x10")]
			private string m_Text;

			[SerializeField]
			[Token(Token = "0x400022D")]
			[FieldOffset(Offset = "0x18")]
			private Sprite m_Image;

			[Token(Token = "0x170001AF")]
			public string text
			{
				[Token(Token = "0x600062B")]
				[Address(RVA = "0xF448CC", Offset = "0xF448CC", Length = "0x8")]
				get
				{
					return null;
				}
				[Token(Token = "0x600062C")]
				[Address(RVA = "0xF448D4", Offset = "0xF448D4", Length = "0x8")]
				set
				{
				}
			}

			[Token(Token = "0x170001B0")]
			public Sprite image
			{
				[Token(Token = "0x600062D")]
				[Address(RVA = "0xF448DC", Offset = "0xF448DC", Length = "0x8")]
				get
				{
					return null;
				}
				[Token(Token = "0x600062E")]
				[Address(RVA = "0xF448E4", Offset = "0xF448E4", Length = "0x8")]
				set
				{
				}
			}

			[Token(Token = "0x600062F")]
			[Address(RVA = "0xF448EC", Offset = "0xF448EC", Length = "0x8")]
			public OptionData()
			{
			}

			[Token(Token = "0x6000630")]
			[Address(RVA = "0xF448F4", Offset = "0xF448F4", Length = "0x2C")]
			public OptionData(string text)
			{
			}

			[Token(Token = "0x6000631")]
			[Address(RVA = "0xF44920", Offset = "0xF44920", Length = "0x2C")]
			public OptionData(Sprite image)
			{
			}

			[Token(Token = "0x6000632")]
			[Address(RVA = "0xF4494C", Offset = "0xF4494C", Length = "0x38")]
			public OptionData(string text, Sprite image)
			{
			}
		}

		[Serializable]
		[Token(Token = "0x200007A")]
		public class OptionDataList
		{
			[SerializeField]
			[Token(Token = "0x400022E")]
			[FieldOffset(Offset = "0x10")]
			private List<OptionData> m_Options;

			[Token(Token = "0x170001B1")]
			public List<OptionData> options
			{
				[Token(Token = "0x6000633")]
				[Address(RVA = "0xF44984", Offset = "0xF44984", Length = "0x8")]
				get
				{
					return null;
				}
				[Token(Token = "0x6000634")]
				[Address(RVA = "0xF4498C", Offset = "0xF4498C", Length = "0x8")]
				set
				{
				}
			}

			[Token(Token = "0x6000635")]
			[Address(RVA = "0xF44994", Offset = "0xF44994", Length = "0x74")]
			public OptionDataList()
			{
			}
		}

		[Serializable]
		[Token(Token = "0x200007B")]
		public class DropdownEvent : UnityEvent<int>
		{
			[Token(Token = "0x6000636")]
			[Address(RVA = "0xF446F8", Offset = "0xF446F8", Length = "0x50")]
			public DropdownEvent()
			{
			}
		}

		[SerializeField]
		[Token(Token = "0x400002E")]
		[FieldOffset(Offset = "0xE8")]
		private RectTransform m_Template;

		[SerializeField]
		[Token(Token = "0x400002F")]
		[FieldOffset(Offset = "0xF0")]
		private Text m_CaptionText;

		[SerializeField]
		[Token(Token = "0x4000030")]
		[FieldOffset(Offset = "0xF8")]
		private Image m_CaptionImage;

		[Space]
		[SerializeField]
		[Token(Token = "0x4000031")]
		[FieldOffset(Offset = "0x100")]
		private Text m_ItemText;

		[SerializeField]
		[Token(Token = "0x4000032")]
		[FieldOffset(Offset = "0x108")]
		private Image m_ItemImage;

		[Space]
		[SerializeField]
		[Token(Token = "0x4000033")]
		[FieldOffset(Offset = "0x110")]
		private int m_Value;

		[Space]
		[SerializeField]
		[Token(Token = "0x4000034")]
		[FieldOffset(Offset = "0x118")]
		private OptionDataList m_Options;

		[Space]
		[SerializeField]
		[Token(Token = "0x4000035")]
		[FieldOffset(Offset = "0x120")]
		private DropdownEvent m_OnValueChanged;

		[SerializeField]
		[Token(Token = "0x4000036")]
		[FieldOffset(Offset = "0x128")]
		private float m_AlphaFadeSpeed;

		[Token(Token = "0x4000037")]
		[FieldOffset(Offset = "0x130")]
		private GameObject m_Dropdown;

		[Token(Token = "0x4000038")]
		[FieldOffset(Offset = "0x138")]
		private GameObject m_Blocker;

		[Token(Token = "0x4000039")]
		[FieldOffset(Offset = "0x140")]
		private List<DropdownItem> m_Items;

		[Token(Token = "0x400003A")]
		[FieldOffset(Offset = "0x148")]
		private TweenRunner<FloatTween> m_AlphaTweenRunner;

		[Token(Token = "0x400003B")]
		[FieldOffset(Offset = "0x150")]
		private bool validTemplate;

		[Token(Token = "0x400003C")]
		private static OptionData s_NoOptionData;

		[Token(Token = "0x17000015")]
		public RectTransform template
		{
			[Token(Token = "0x6000060")]
			[Address(RVA = "0xC543E8", Offset = "0xC543E8", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000061")]
			[Address(RVA = "0xC537D0", Offset = "0xC537D0", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000016")]
		public Text captionText
		{
			[Token(Token = "0x6000062")]
			[Address(RVA = "0xC543F0", Offset = "0xC543F0", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000063")]
			[Address(RVA = "0xC537D8", Offset = "0xC537D8", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000017")]
		public Image captionImage
		{
			[Token(Token = "0x6000064")]
			[Address(RVA = "0xC543F8", Offset = "0xC543F8", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000065")]
			[Address(RVA = "0xC54400", Offset = "0xC54400", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000018")]
		public Text itemText
		{
			[Token(Token = "0x6000066")]
			[Address(RVA = "0xC54408", Offset = "0xC54408", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000067")]
			[Address(RVA = "0xC537E0", Offset = "0xC537E0", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000019")]
		public Image itemImage
		{
			[Token(Token = "0x6000068")]
			[Address(RVA = "0xC54410", Offset = "0xC54410", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000069")]
			[Address(RVA = "0xC54418", Offset = "0xC54418", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700001A")]
		public List<OptionData> options
		{
			[Token(Token = "0x600006A")]
			[Address(RVA = "0xC537E8", Offset = "0xC537E8", Length = "0x20")]
			get
			{
				return null;
			}
			[Token(Token = "0x600006B")]
			[Address(RVA = "0xC54420", Offset = "0xC54420", Length = "0x20")]
			set
			{
			}
		}

		[Token(Token = "0x1700001B")]
		public DropdownEvent onValueChanged
		{
			[Token(Token = "0x600006C")]
			[Address(RVA = "0xC54440", Offset = "0xC54440", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600006D")]
			[Address(RVA = "0xC54448", Offset = "0xC54448", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700001C")]
		public float alphaFadeSpeed
		{
			[Token(Token = "0x600006E")]
			[Address(RVA = "0xC54450", Offset = "0xC54450", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600006F")]
			[Address(RVA = "0xC54458", Offset = "0xC54458", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700001D")]
		public int value
		{
			[Token(Token = "0x6000070")]
			[Address(RVA = "0xC54460", Offset = "0xC54460", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x6000071")]
			[Address(RVA = "0xC54468", Offset = "0xC54468", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x6000072")]
		[Address(RVA = "0xC54594", Offset = "0xC54594", Length = "0x8")]
		public void SetValueWithoutNotify(int input)
		{
		}

		[Token(Token = "0x6000073")]
		[Address(RVA = "0xC54470", Offset = "0xC54470", Length = "0x124")]
		private void Set(int value, bool sendCallback = true)
		{
		}

		[Token(Token = "0x6000074")]
		[Address(RVA = "0xC5459C", Offset = "0xC5459C", Length = "0xDC")]
		protected Dropdown()
		{
		}

		[Token(Token = "0x6000075")]
		[Address(RVA = "0xC54678", Offset = "0xC54678", Length = "0x150")]
		protected override void Awake()
		{
		}

		[Token(Token = "0x6000076")]
		[Address(RVA = "0xC547C8", Offset = "0xC547C8", Length = "0x4")]
		protected override void Start()
		{
		}

		[Token(Token = "0x6000077")]
		[Address(RVA = "0xC547CC", Offset = "0xC547CC", Length = "0xA4")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x6000078")]
		[Address(RVA = "0xC53808", Offset = "0xC53808", Length = "0x20C")]
		public void RefreshShownValue()
		{
		}

		[Token(Token = "0x6000079")]
		[Address(RVA = "0xC549DC", Offset = "0xC549DC", Length = "0x7C")]
		public void AddOptions(List<OptionData> options)
		{
		}

		[Token(Token = "0x600007A")]
		[Address(RVA = "0xC54A58", Offset = "0xC54A58", Length = "0xF0")]
		public void AddOptions(List<string> options)
		{
		}

		[Token(Token = "0x600007B")]
		[Address(RVA = "0xC54B48", Offset = "0xC54B48", Length = "0xF0")]
		public void AddOptions(List<Sprite> options)
		{
		}

		[Token(Token = "0x600007C")]
		[Address(RVA = "0xC54C38", Offset = "0xC54C38", Length = "0x70")]
		public void ClearOptions()
		{
		}

		[Token(Token = "0x600007D")]
		[Address(RVA = "0xC54CA8", Offset = "0xC54CA8", Length = "0x67C")]
		private void SetupTemplate()
		{
		}

		[Token(Token = "0x600007E")]
		[Address(RVA = "0xACE160", Offset = "0xACE160", Length = "0xC8")]
		private static T GetOrAddComponent<T>(GameObject go) where T : Component
		{
			return null;
		}

		[Token(Token = "0x600007F")]
		[Address(RVA = "0xC55324", Offset = "0xC55324", Length = "0x4")]
		public virtual void OnPointerClick(PointerEventData eventData)
		{
		}

		[Token(Token = "0x6000080")]
		[Address(RVA = "0xC55FE8", Offset = "0xC55FE8", Length = "0x4")]
		public virtual void OnSubmit(BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000081")]
		[Address(RVA = "0xC55FEC", Offset = "0xC55FEC", Length = "0x4")]
		public virtual void OnCancel(BaseEventData eventData)
		{
		}

		[Token(Token = "0x6000082")]
		[Address(RVA = "0xC55328", Offset = "0xC55328", Length = "0xCC0")]
		public void Show()
		{
		}

		[Token(Token = "0x6000083")]
		[Address(RVA = "0xC564CC", Offset = "0xC564CC", Length = "0x468")]
		protected virtual GameObject CreateBlocker(Canvas rootCanvas)
		{
			return null;
		}

		[Token(Token = "0x6000084")]
		[Address(RVA = "0xC56934", Offset = "0xC56934", Length = "0x68")]
		protected virtual void DestroyBlocker(GameObject blocker)
		{
		}

		[Token(Token = "0x6000085")]
		[Address(RVA = "0xC5699C", Offset = "0xC5699C", Length = "0x70")]
		protected virtual GameObject CreateDropdownList(GameObject template)
		{
			return null;
		}

		[Token(Token = "0x6000086")]
		[Address(RVA = "0xC56A0C", Offset = "0xC56A0C", Length = "0x68")]
		protected virtual void DestroyDropdownList(GameObject dropdownList)
		{
		}

		[Token(Token = "0x6000087")]
		[Address(RVA = "0xC56A74", Offset = "0xC56A74", Length = "0x70")]
		protected virtual DropdownItem CreateItem(DropdownItem itemTemplate)
		{
			return null;
		}

		[Token(Token = "0x6000088")]
		[Address(RVA = "0xC56AE4", Offset = "0xC56AE4", Length = "0x4")]
		protected virtual void DestroyItem(DropdownItem item)
		{
		}

		[Token(Token = "0x6000089")]
		[Address(RVA = "0xC5610C", Offset = "0xC5610C", Length = "0x2A8")]
		private DropdownItem AddItem(OptionData data, bool selected, DropdownItem itemTemplate, List<DropdownItem> items)
		{
			return null;
		}

		[Token(Token = "0x600008A")]
		[Address(RVA = "0xC56AE8", Offset = "0xC56AE8", Length = "0x88")]
		private void AlphaFadeList(float duration, float alpha)
		{
		}

		[Token(Token = "0x600008B")]
		[Address(RVA = "0xC563B4", Offset = "0xC563B4", Length = "0x118")]
		private void AlphaFadeList(float duration, float start, float end)
		{
		}

		[Token(Token = "0x600008C")]
		[Address(RVA = "0xC56B70", Offset = "0xC56B70", Length = "0xB8")]
		private void SetAlpha(float alpha)
		{
		}

		[Token(Token = "0x600008D")]
		[Address(RVA = "0xC55FF0", Offset = "0xC55FF0", Length = "0x11C")]
		public void Hide()
		{
		}

		[AttributeAttribute(Type = typeof(IteratorStateMachineAttribute), RVA = "0x729F84", Offset = "0x729F84")]
		[Token(Token = "0x600008E")]
		[Address(RVA = "0xC56C28", Offset = "0xC56C28", Length = "0x84")]
		private IEnumerator DelayedDestroyDropdownList(float delay)
		{
			return null;
		}

		[Token(Token = "0x600008F")]
		[Address(RVA = "0xC54870", Offset = "0xC54870", Length = "0x16C")]
		private void ImmediateDestroyDropdownList()
		{
		}

		[Token(Token = "0x6000090")]
		[Address(RVA = "0xC56CAC", Offset = "0xC56CAC", Length = "0x150")]
		private void OnSelectItem(Toggle toggle)
		{
		}
	}
}
