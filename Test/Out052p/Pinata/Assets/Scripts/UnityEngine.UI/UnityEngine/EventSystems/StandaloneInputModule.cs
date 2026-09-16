using System;
using Cpp2ILInjected;
using UnityEngine.Serialization;

namespace UnityEngine.EventSystems
{
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x727DC4", Offset = "0x727DC4")]
	[Token(Token = "0x2000069")]
	public class StandaloneInputModule : PointerInputModule
	{
		[Obsolete]
		[Token(Token = "0x20000C1")]
		public enum InputMode
		{
			[Token(Token = "0x400030D")]
			Mouse = 0,
			[Token(Token = "0x400030E")]
			Buttons = 1
		}

		[Token(Token = "0x40001EF")]
		[FieldOffset(Offset = "0x58")]
		private float m_PrevActionTime;

		[Token(Token = "0x40001F0")]
		[FieldOffset(Offset = "0x5C")]
		private Vector2 m_LastMoveVector;

		[Token(Token = "0x40001F1")]
		[FieldOffset(Offset = "0x64")]
		private int m_ConsecutiveMoveCount;

		[Token(Token = "0x40001F2")]
		[FieldOffset(Offset = "0x68")]
		private Vector2 m_LastMousePosition;

		[Token(Token = "0x40001F3")]
		[FieldOffset(Offset = "0x70")]
		private Vector2 m_MousePosition;

		[Token(Token = "0x40001F4")]
		[FieldOffset(Offset = "0x78")]
		private GameObject m_CurrentFocusedGameObject;

		[Token(Token = "0x40001F5")]
		[FieldOffset(Offset = "0x80")]
		private PointerEventData m_InputPointerEvent;

		[SerializeField]
		[Token(Token = "0x40001F6")]
		[FieldOffset(Offset = "0x88")]
		private string m_HorizontalAxis;

		[SerializeField]
		[Token(Token = "0x40001F7")]
		[FieldOffset(Offset = "0x90")]
		private string m_VerticalAxis;

		[SerializeField]
		[Token(Token = "0x40001F8")]
		[FieldOffset(Offset = "0x98")]
		private string m_SubmitButton;

		[SerializeField]
		[Token(Token = "0x40001F9")]
		[FieldOffset(Offset = "0xA0")]
		private string m_CancelButton;

		[SerializeField]
		[Token(Token = "0x40001FA")]
		[FieldOffset(Offset = "0xA8")]
		private float m_InputActionsPerSecond;

		[SerializeField]
		[Token(Token = "0x40001FB")]
		[FieldOffset(Offset = "0xAC")]
		private float m_RepeatDelay;

		[SerializeField]
		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x729DF8", Offset = "0x729DF8")]
		[Token(Token = "0x40001FC")]
		[FieldOffset(Offset = "0xB0")]
		private bool m_ForceModuleActive;

		[Obsolete]
		[Token(Token = "0x17000192")]
		public InputMode inputMode
		{
			[Token(Token = "0x60005B3")]
			[Address(RVA = "0xC48F70", Offset = "0xC48F70", Length = "0x8")]
			get
			{
				return InputMode.Mouse;
			}
		}

		[Obsolete]
		[Token(Token = "0x17000193")]
		public bool allowActivationOnMobileDevice
		{
			[Token(Token = "0x60005B4")]
			[Address(RVA = "0xC48F78", Offset = "0xC48F78", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60005B5")]
			[Address(RVA = "0xC48F80", Offset = "0xC48F80", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x17000194")]
		public bool forceModuleActive
		{
			[Token(Token = "0x60005B6")]
			[Address(RVA = "0xC48F8C", Offset = "0xC48F8C", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60005B7")]
			[Address(RVA = "0xC48F94", Offset = "0xC48F94", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x17000195")]
		public float inputActionsPerSecond
		{
			[Token(Token = "0x60005B8")]
			[Address(RVA = "0xC48FA0", Offset = "0xC48FA0", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60005B9")]
			[Address(RVA = "0xC48FA8", Offset = "0xC48FA8", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000196")]
		public float repeatDelay
		{
			[Token(Token = "0x60005BA")]
			[Address(RVA = "0xC48FB0", Offset = "0xC48FB0", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x60005BB")]
			[Address(RVA = "0xC48FB8", Offset = "0xC48FB8", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000197")]
		public string horizontalAxis
		{
			[Token(Token = "0x60005BC")]
			[Address(RVA = "0xC48FC0", Offset = "0xC48FC0", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60005BD")]
			[Address(RVA = "0xC48FC8", Offset = "0xC48FC8", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000198")]
		public string verticalAxis
		{
			[Token(Token = "0x60005BE")]
			[Address(RVA = "0xC48FD0", Offset = "0xC48FD0", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60005BF")]
			[Address(RVA = "0xC48FD8", Offset = "0xC48FD8", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x17000199")]
		public string submitButton
		{
			[Token(Token = "0x60005C0")]
			[Address(RVA = "0xC48FE0", Offset = "0xC48FE0", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60005C1")]
			[Address(RVA = "0xC48FE8", Offset = "0xC48FE8", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x1700019A")]
		public string cancelButton
		{
			[Token(Token = "0x60005C2")]
			[Address(RVA = "0xC48FF0", Offset = "0xC48FF0", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x60005C3")]
			[Address(RVA = "0xC48FF8", Offset = "0xC48FF8", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x60005B2")]
		[Address(RVA = "0xC48EE4", Offset = "0xC48EE4", Length = "0x8C")]
		protected StandaloneInputModule()
		{
		}

		[Token(Token = "0x60005C4")]
		[Address(RVA = "0xC49000", Offset = "0xC49000", Length = "0x24")]
		private bool ShouldIgnoreEventsOnNoFocus()
		{
			return false;
		}

		[Token(Token = "0x60005C5")]
		[Address(RVA = "0xC49024", Offset = "0xC49024", Length = "0xF8")]
		public override void UpdateModule()
		{
		}

		[Token(Token = "0x60005C6")]
		[Address(RVA = "0xC4911C", Offset = "0xC4911C", Length = "0x3A0")]
		private void ReleaseMouse(PointerEventData pointerEvent, GameObject currentOverGo)
		{
		}

		[Token(Token = "0x60005C7")]
		[Address(RVA = "0xC494BC", Offset = "0xC494BC", Length = "0x70")]
		public override bool IsModuleSupported()
		{
			return false;
		}

		[Token(Token = "0x60005C8")]
		[Address(RVA = "0xC4952C", Offset = "0xC4952C", Length = "0x230")]
		public override bool ShouldActivateModule()
		{
			return false;
		}

		[Token(Token = "0x60005C9")]
		[Address(RVA = "0xC4975C", Offset = "0xC4975C", Length = "0x134")]
		public override void ActivateModule()
		{
		}

		[Token(Token = "0x60005CA")]
		[Address(RVA = "0xC49890", Offset = "0xC49890", Length = "0x4")]
		public override void DeactivateModule()
		{
		}

		[Token(Token = "0x60005CB")]
		[Address(RVA = "0xC49894", Offset = "0xC49894", Length = "0xC4")]
		public override void Process()
		{
		}

		[Token(Token = "0x60005CC")]
		[Address(RVA = "0xC49AB0", Offset = "0xC49AB0", Length = "0x174")]
		private bool ProcessTouchEvents()
		{
			return false;
		}

		[Token(Token = "0x60005CD")]
		[Address(RVA = "0xC4A100", Offset = "0xC4A100", Length = "0x6E8")]
		protected void ProcessTouchPress(PointerEventData pointerEvent, bool pressed, bool released)
		{
		}

		[Token(Token = "0x60005CE")]
		[Address(RVA = "0xC49EC8", Offset = "0xC49EC8", Length = "0x238")]
		protected bool SendSubmitEventToSelectedObject()
		{
			return false;
		}

		[Token(Token = "0x60005CF")]
		[Address(RVA = "0xC4A7E8", Offset = "0xC4A7E8", Length = "0x150")]
		private Vector2 GetRawMoveVector()
		{
			return default(Vector2);
		}

		[Token(Token = "0x60005D0")]
		[Address(RVA = "0xC49C2C", Offset = "0xC49C2C", Length = "0x29C")]
		protected bool SendMoveEventToSelectedObject()
		{
			return false;
		}

		[Token(Token = "0x60005D1")]
		[Address(RVA = "0xC49C24", Offset = "0xC49C24", Length = "0x8")]
		protected void ProcessMouseEvent()
		{
		}

		[Obsolete]
		[Token(Token = "0x60005D2")]
		[Address(RVA = "0xC4ABB8", Offset = "0xC4ABB8", Length = "0x8")]
		protected virtual bool ForceAutoSelect()
		{
			return false;
		}

		[Token(Token = "0x60005D3")]
		[Address(RVA = "0xC4A938", Offset = "0xC4A938", Length = "0x280")]
		protected void ProcessMouseEvent(int id)
		{
		}

		[Token(Token = "0x60005D4")]
		[Address(RVA = "0xC49958", Offset = "0xC49958", Length = "0x158")]
		protected bool SendUpdateEventToSelectedObject()
		{
			return false;
		}

		[Token(Token = "0x60005D5")]
		[Address(RVA = "0xC4ABC0", Offset = "0xC4ABC0", Length = "0x37C")]
		protected void ProcessMousePress(MouseButtonEventData data)
		{
		}

		[Token(Token = "0x60005D6")]
		[Address(RVA = "0xC4AF3C", Offset = "0xC4AF3C", Length = "0x8")]
		protected GameObject GetCurrentFocusedGameObject()
		{
			return null;
		}
	}
}
