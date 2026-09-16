using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine.Serialization;

namespace UnityEngine.EventSystems
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x727CF0", Offset = "0x727CF0")]
	[Token(Token = "0x2000062")]
	public class EventSystem : UIBehaviour
	{
		[Token(Token = "0x40001B2")]
		[FieldOffset(Offset = "0x18")]
		private List<BaseInputModule> m_SystemInputModules;

		[Token(Token = "0x40001B3")]
		[FieldOffset(Offset = "0x20")]
		private BaseInputModule m_CurrentInputModule;

		[Token(Token = "0x40001B4")]
		private static List<EventSystem> m_EventSystems;

		[SerializeField]
		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x729CE0", Offset = "0x729CE0")]
		[Token(Token = "0x40001B5")]
		[FieldOffset(Offset = "0x28")]
		private GameObject m_FirstSelected;

		[SerializeField]
		[Token(Token = "0x40001B6")]
		[FieldOffset(Offset = "0x30")]
		private bool m_sendNavigationEvents;

		[SerializeField]
		[Token(Token = "0x40001B7")]
		[FieldOffset(Offset = "0x34")]
		private int m_DragThreshold;

		[Token(Token = "0x40001B8")]
		[FieldOffset(Offset = "0x38")]
		private GameObject m_CurrentSelected;

		[Token(Token = "0x40001B9")]
		[FieldOffset(Offset = "0x40")]
		private bool m_HasFocus;

		[Token(Token = "0x40001BA")]
		[FieldOffset(Offset = "0x41")]
		private bool m_SelectionGuard;

		[Token(Token = "0x40001BB")]
		[FieldOffset(Offset = "0x48")]
		private BaseEventData m_DummyData;

		[Token(Token = "0x40001BC")]
		private static readonly Comparison<RaycastResult> s_RaycastComparer;

		[Token(Token = "0x1700016A")]
		public static EventSystem current
		{
			[Token(Token = "0x600051C")]
			[Address(RVA = "0xC42690", Offset = "0xC42690", Length = "0xC4")]
			get
			{
				return null;
			}
			[Token(Token = "0x600051D")]
			[Address(RVA = "0xC42754", Offset = "0xC42754", Length = "0x108")]
			set
			{
			}
		}

		[Token(Token = "0x1700016B")]
		public bool sendNavigationEvents
		{
			[Token(Token = "0x600051E")]
			[Address(RVA = "0xC4285C", Offset = "0xC4285C", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x600051F")]
			[Address(RVA = "0xC42864", Offset = "0xC42864", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x1700016C")]
		public int pixelDragThreshold
		{
			[Token(Token = "0x6000520")]
			[Address(RVA = "0xC42870", Offset = "0xC42870", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x6000521")]
			[Address(RVA = "0xC42878", Offset = "0xC42878", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700016D")]
		public BaseInputModule currentInputModule
		{
			[Token(Token = "0x6000522")]
			[Address(RVA = "0xC42880", Offset = "0xC42880", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x1700016E")]
		public GameObject firstSelectedGameObject
		{
			[Token(Token = "0x6000523")]
			[Address(RVA = "0xC42888", Offset = "0xC42888", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000524")]
			[Address(RVA = "0xC42890", Offset = "0xC42890", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700016F")]
		public GameObject currentSelectedGameObject
		{
			[Token(Token = "0x6000525")]
			[Address(RVA = "0xC42898", Offset = "0xC42898", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Obsolete]
		[Token(Token = "0x17000170")]
		public GameObject lastSelectedGameObject
		{
			[Token(Token = "0x6000526")]
			[Address(RVA = "0xC428A0", Offset = "0xC428A0", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000171")]
		public bool isFocused
		{
			[Token(Token = "0x6000527")]
			[Address(RVA = "0xC428A8", Offset = "0xC428A8", Length = "0x8")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x17000172")]
		public bool alreadySelecting
		{
			[Token(Token = "0x600052A")]
			[Address(RVA = "0xC42934", Offset = "0xC42934", Length = "0x8")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x17000173")]
		private BaseEventData baseEventDataCache
		{
			[Token(Token = "0x600052C")]
			[Address(RVA = "0xC4293C", Offset = "0xC4293C", Length = "0x70")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x6000528")]
		[Address(RVA = "0xC428B0", Offset = "0xC428B0", Length = "0x84")]
		protected EventSystem()
		{
		}

		[Token(Token = "0x6000529")]
		[Address(RVA = "0xC41344", Offset = "0xC41344", Length = "0x150")]
		public void UpdateModules()
		{
		}

		[Token(Token = "0x600052B")]
		[Address(RVA = "0xC40D7C", Offset = "0xC40D7C", Length = "0x1F4")]
		public void SetSelectedGameObject(GameObject selected, BaseEventData pointer)
		{
		}

		[Token(Token = "0x600052D")]
		[Address(RVA = "0xC429AC", Offset = "0xC429AC", Length = "0x30")]
		public void SetSelectedGameObject(GameObject selected)
		{
		}

		[Token(Token = "0x600052E")]
		[Address(RVA = "0xC429DC", Offset = "0xC429DC", Length = "0x3A4")]
		private static int RaycastComparer(RaycastResult lhs, RaycastResult rhs)
		{
			return 0;
		}

		[Token(Token = "0x600052F")]
		[Address(RVA = "0xC42D80", Offset = "0xC42D80", Length = "0x1C0")]
		public void RaycastAll(PointerEventData eventData, List<RaycastResult> raycastResults)
		{
		}

		[Token(Token = "0x6000530")]
		[Address(RVA = "0xC42F40", Offset = "0xC42F40", Length = "0x8")]
		public bool IsPointerOverGameObject()
		{
			return false;
		}

		[Token(Token = "0x6000531")]
		[Address(RVA = "0xC42F48", Offset = "0xC42F48", Length = "0xB4")]
		public bool IsPointerOverGameObject(int pointerId)
		{
			return false;
		}

		[Token(Token = "0x6000532")]
		[Address(RVA = "0xC42FFC", Offset = "0xC42FFC", Length = "0x84")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x6000533")]
		[Address(RVA = "0xC43080", Offset = "0xC43080", Length = "0xD8")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x6000534")]
		[Address(RVA = "0xC43158", Offset = "0xC43158", Length = "0x10C")]
		private void TickModules()
		{
		}

		[Token(Token = "0x6000535")]
		[Address(RVA = "0xC43264", Offset = "0xC43264", Length = "0xC")]
		protected virtual void OnApplicationFocus(bool hasFocus)
		{
		}

		[Token(Token = "0x6000536")]
		[Address(RVA = "0xC43270", Offset = "0xC43270", Length = "0x298")]
		protected virtual void Update()
		{
		}

		[Token(Token = "0x6000537")]
		[Address(RVA = "0xC43508", Offset = "0xC43508", Length = "0x120")]
		private void ChangeEventModule(BaseInputModule module)
		{
		}

		[Token(Token = "0x6000538")]
		[Address(RVA = "0xC43628", Offset = "0xC43628", Length = "0x128")]
		public override string ToString()
		{
			return null;
		}
	}
}
