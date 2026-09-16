using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

namespace UnityEngine.EventSystems
{
	[AddComponentMenu("Event/Event System")]
	[DisallowMultipleComponent]
	[Token(Token = "0x20000B0")]
	public class EventSystem : UIBehaviour
	{
		[Token(Token = "0x20000B1")]
		private struct UIToolkitOverrideConfig
		{
			[Token(Token = "0x40002EB")]
			[FieldOffset(Offset = "0x0")]
			public EventSystem activeEventSystem;

			[Token(Token = "0x40002EC")]
			[FieldOffset(Offset = "0x8")]
			public bool sendEvents;

			[Token(Token = "0x40002ED")]
			[FieldOffset(Offset = "0x9")]
			public bool createPanelGameObjectsOnStart;
		}

		[Token(Token = "0x40002DD")]
		[FieldOffset(Offset = "0x20")]
		private List<BaseInputModule> m_SystemInputModules;

		[Token(Token = "0x40002DE")]
		[FieldOffset(Offset = "0x28")]
		private BaseInputModule m_CurrentInputModule;

		[Token(Token = "0x40002DF")]
		private static List<EventSystem> m_EventSystems;

		[SerializeField]
		[FormerlySerializedAs("m_Selected")]
		[Token(Token = "0x40002E0")]
		[FieldOffset(Offset = "0x30")]
		private GameObject m_FirstSelected;

		[SerializeField]
		[Token(Token = "0x40002E1")]
		[FieldOffset(Offset = "0x38")]
		private bool m_sendNavigationEvents;

		[SerializeField]
		[Token(Token = "0x40002E2")]
		[FieldOffset(Offset = "0x3C")]
		private int m_DragThreshold;

		[Token(Token = "0x40002E3")]
		[FieldOffset(Offset = "0x40")]
		private GameObject m_CurrentSelected;

		[Token(Token = "0x40002E4")]
		[FieldOffset(Offset = "0x48")]
		private bool m_HasFocus;

		[Token(Token = "0x40002E5")]
		[FieldOffset(Offset = "0x49")]
		private bool m_SelectionGuard;

		[Token(Token = "0x40002E6")]
		[FieldOffset(Offset = "0x50")]
		private BaseEventData m_DummyData;

		[Token(Token = "0x40002E7")]
		private static readonly Comparison<RaycastResult> s_RaycastComparer;

		[Token(Token = "0x40002E8")]
		private static UIToolkitOverrideConfig s_UIToolkitOverride;

		[Token(Token = "0x40002E9")]
		[FieldOffset(Offset = "0x58")]
		private bool m_Started;

		[Token(Token = "0x40002EA")]
		[FieldOffset(Offset = "0x59")]
		private bool m_IsTrackingUIToolkitPanels;

		[Token(Token = "0x170001B4")]
		public static EventSystem current
		{
			[Token(Token = "0x6000650")]
			[Address(RVA = "0x1843930", Offset = "0x1843930", Length = "0xC4")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000651")]
			[Address(RVA = "0x18439F4", Offset = "0x18439F4", Length = "0x194")]
			set
			{
			}
		}

		[Token(Token = "0x170001B5")]
		public bool sendNavigationEvents
		{
			[Token(Token = "0x6000652")]
			[Address(RVA = "0x1843B88", Offset = "0x1843B88", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000653")]
			[Address(RVA = "0x1843B90", Offset = "0x1843B90", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x170001B6")]
		public int pixelDragThreshold
		{
			[Token(Token = "0x6000654")]
			[Address(RVA = "0x1843B9C", Offset = "0x1843B9C", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x6000655")]
			[Address(RVA = "0x1843BA4", Offset = "0x1843BA4", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170001B7")]
		public BaseInputModule currentInputModule
		{
			[Token(Token = "0x6000656")]
			[Address(RVA = "0x1843BAC", Offset = "0x1843BAC", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170001B8")]
		public GameObject firstSelectedGameObject
		{
			[Token(Token = "0x6000657")]
			[Address(RVA = "0x1843BB4", Offset = "0x1843BB4", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000658")]
			[Address(RVA = "0x1843BBC", Offset = "0x1843BBC", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170001B9")]
		public GameObject currentSelectedGameObject
		{
			[Token(Token = "0x6000659")]
			[Address(RVA = "0x1843BC4", Offset = "0x1843BC4", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Obsolete("lastSelectedGameObject is no longer supported")]
		[Token(Token = "0x170001BA")]
		public GameObject lastSelectedGameObject
		{
			[Token(Token = "0x600065A")]
			[Address(RVA = "0x1843BCC", Offset = "0x1843BCC", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170001BB")]
		public bool isFocused
		{
			[Token(Token = "0x600065B")]
			[Address(RVA = "0x1843BD4", Offset = "0x1843BD4", Length = "0x8")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x170001BC")]
		public bool alreadySelecting
		{
			[Token(Token = "0x600065E")]
			[Address(RVA = "0x1843DAC", Offset = "0x1843DAC", Length = "0x8")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x170001BD")]
		private BaseEventData baseEventDataCache
		{
			[Token(Token = "0x6000660")]
			[Address(RVA = "0x1843DB4", Offset = "0x1843DB4", Length = "0x68")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170001BE")]
		private bool isUIToolkitActiveEventSystem
		{
			[Token(Token = "0x6000666")]
			[Address(RVA = "0x1844528", Offset = "0x1844528", Length = "0xF0")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x170001BF")]
		private bool sendUIToolkitEvents
		{
			[Token(Token = "0x6000667")]
			[Address(RVA = "0x1844618", Offset = "0x1844618", Length = "0x74")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x170001C0")]
		private bool createUIToolkitPanelGameObjectsOnStart
		{
			[Token(Token = "0x6000668")]
			[Address(RVA = "0x184468C", Offset = "0x184468C", Length = "0x74")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x600065C")]
		[Address(RVA = "0x1843BDC", Offset = "0x1843BDC", Length = "0x90")]
		protected EventSystem()
		{
		}

		[Token(Token = "0x600065D")]
		[Address(RVA = "0x1843C6C", Offset = "0x1843C6C", Length = "0x140")]
		public void UpdateModules()
		{
		}

		[Token(Token = "0x600065F")]
		[Address(RVA = "0x18425F8", Offset = "0x18425F8", Length = "0x224")]
		public void SetSelectedGameObject(GameObject selected, BaseEventData pointer)
		{
		}

		[Token(Token = "0x6000661")]
		[Address(RVA = "0x183F82C", Offset = "0x183F82C", Length = "0x2C")]
		public void SetSelectedGameObject(GameObject selected)
		{
		}

		[Token(Token = "0x6000662")]
		[Address(RVA = "0x1843E1C", Offset = "0x1843E1C", Length = "0x3B8")]
		private static int RaycastComparer(RaycastResult lhs, RaycastResult rhs)
		{
			return 0;
		}

		[Token(Token = "0x6000663")]
		[Address(RVA = "0x184428C", Offset = "0x184428C", Length = "0x1F0")]
		public void RaycastAll(PointerEventData eventData, List<RaycastResult> raycastResults)
		{
		}

		[Token(Token = "0x6000664")]
		[Address(RVA = "0x184447C", Offset = "0x184447C", Length = "0x8")]
		public bool IsPointerOverGameObject()
		{
			return false;
		}

		[Token(Token = "0x6000665")]
		[Address(RVA = "0x1844484", Offset = "0x1844484", Length = "0xA4")]
		public bool IsPointerOverGameObject(int pointerId)
		{
			return false;
		}

		[Token(Token = "0x6000669")]
		[Address(RVA = "0x1844700", Offset = "0x1844700", Length = "0x19C")]
		public static void SetUITookitEventSystemOverride(EventSystem activeEventSystem, bool sendEvents = true, bool createPanelGameObjectsOnStart = true)
		{
		}

		[Token(Token = "0x600066A")]
		[Address(RVA = "0x184489C", Offset = "0x184489C", Length = "0x238")]
		private void StartTrackingUIToolkitPanels()
		{
		}

		[Token(Token = "0x600066B")]
		[Address(RVA = "0x1844D6C", Offset = "0x1844D6C", Length = "0xAC")]
		private void StopTrackingUIToolkitPanels()
		{
		}

		[Token(Token = "0x600066C")]
		[Address(RVA = "0x1844AD4", Offset = "0x1844AD4", Length = "0x298")]
		private void CreateUIToolkitPanelGameObject(BaseRuntimePanel panel)
		{
		}

		[Token(Token = "0x600066D")]
		[Address(RVA = "0x1844E20", Offset = "0x1844E20", Length = "0xC")]
		protected override void Start()
		{
		}

		[Token(Token = "0x600066E")]
		[Address(RVA = "0x1844E30", Offset = "0x1844E30", Length = "0x124")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x600066F")]
		[Address(RVA = "0x1844F54", Offset = "0x1844F54", Length = "0x110")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x6000670")]
		[Address(RVA = "0x1845064", Offset = "0x1845064", Length = "0x100")]
		private void TickModules()
		{
		}

		[Token(Token = "0x6000671")]
		[Address(RVA = "0x1845164", Offset = "0x1845164", Length = "0x14")]
		protected virtual void OnApplicationFocus(bool hasFocus)
		{
		}

		[Token(Token = "0x6000672")]
		[Address(RVA = "0x1845178", Offset = "0x1845178", Length = "0x268")]
		protected virtual void Update()
		{
		}

		[Token(Token = "0x6000673")]
		[Address(RVA = "0x18453E0", Offset = "0x18453E0", Length = "0xF8")]
		private void ChangeEventModule(BaseInputModule module)
		{
		}

		[Token(Token = "0x6000674")]
		[Address(RVA = "0x18454D8", Offset = "0x18454D8", Length = "0x158")]
		public override string ToString()
		{
			return null;
		}
	}
}
