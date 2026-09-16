using System;
using Cpp2ILInjected;
using UnityEngine.Serialization;

namespace UnityEngine.EventSystems
{
	[AddComponentMenu("Event/Standalone Input Module")]
	[Token(Token = "0x20000BF")]
	public class StandaloneInputModule : PointerInputModule
	{
		[Obsolete("Mode is no longer needed on input module as it handles both mouse and keyboard simultaneously.", false)]
		[Token(Token = "0x20000C0")]
		public enum InputMode
		{
			[Token(Token = "0x4000339")]
			Mouse = 0,
			[Token(Token = "0x400033A")]
			Buttons = 1
		}

		[Token(Token = "0x4000329")]
		[FieldOffset(Offset = "0x68")]
		private float m_PrevActionTime;

		[Token(Token = "0x400032A")]
		[FieldOffset(Offset = "0x6C")]
		private Vector2 m_LastMoveVector;

		[Token(Token = "0x400032B")]
		[FieldOffset(Offset = "0x74")]
		private int m_ConsecutiveMoveCount;

		[Token(Token = "0x400032C")]
		[FieldOffset(Offset = "0x78")]
		private Vector2 m_LastMousePosition;

		[Token(Token = "0x400032D")]
		[FieldOffset(Offset = "0x80")]
		private Vector2 m_MousePosition;

		[Token(Token = "0x400032E")]
		[FieldOffset(Offset = "0x88")]
		private GameObject m_CurrentFocusedGameObject;

		[Token(Token = "0x400032F")]
		[FieldOffset(Offset = "0x90")]
		private PointerEventData m_InputPointerEvent;

		[Token(Token = "0x4000330")]
		private const float doubleClickTime = 0.3f;

		[SerializeField]
		[Token(Token = "0x4000331")]
		[FieldOffset(Offset = "0x98")]
		private string m_HorizontalAxis;

		[SerializeField]
		[Token(Token = "0x4000332")]
		[FieldOffset(Offset = "0xA0")]
		private string m_VerticalAxis;

		[SerializeField]
		[Token(Token = "0x4000333")]
		[FieldOffset(Offset = "0xA8")]
		private string m_SubmitButton;

		[SerializeField]
		[Token(Token = "0x4000334")]
		[FieldOffset(Offset = "0xB0")]
		private string m_CancelButton;

		[SerializeField]
		[Token(Token = "0x4000335")]
		[FieldOffset(Offset = "0xB8")]
		private float m_InputActionsPerSecond;

		[SerializeField]
		[Token(Token = "0x4000336")]
		[FieldOffset(Offset = "0xBC")]
		private float m_RepeatDelay;

		[FormerlySerializedAs("m_AllowActivationOnMobileDevice")]
		[HideInInspector]
		[SerializeField]
		[Token(Token = "0x4000337")]
		[FieldOffset(Offset = "0xC0")]
		private bool m_ForceModuleActive;

		[Obsolete("Mode is no longer needed on input module as it handles both mouse and keyboard simultaneously.", false)]
		[Token(Token = "0x170001E3")]
		public InputMode inputMode
		{
			[Token(Token = "0x6000709")]
			[Address(RVA = "0x184A380", Offset = "0x184A380", Length = "0x8")]
			get
			{
				return InputMode.Mouse;
			}
		}

		[Obsolete("allowActivationOnMobileDevice has been deprecated. Use forceModuleActive instead (UnityUpgradable) -> forceModuleActive")]
		[Token(Token = "0x170001E4")]
		public bool allowActivationOnMobileDevice
		{
			[Token(Token = "0x600070A")]
			[Address(RVA = "0x184A388", Offset = "0x184A388", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x600070B")]
			[Address(RVA = "0x184A390", Offset = "0x184A390", Length = "0xC")]
			set
			{
			}
		}

		[Obsolete("forceModuleActive has been deprecated. There is no need to force the module awake as StandaloneInputModule works for all platforms")]
		[Token(Token = "0x170001E5")]
		public bool forceModuleActive
		{
			[Token(Token = "0x600070C")]
			[Address(RVA = "0x184A39C", Offset = "0x184A39C", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x600070D")]
			[Address(RVA = "0x184A3A4", Offset = "0x184A3A4", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x170001E6")]
		public float inputActionsPerSecond
		{
			[Token(Token = "0x600070E")]
			[Address(RVA = "0x184A3B0", Offset = "0x184A3B0", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600070F")]
			[Address(RVA = "0x184A3B8", Offset = "0x184A3B8", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170001E7")]
		public float repeatDelay
		{
			[Token(Token = "0x6000710")]
			[Address(RVA = "0x184A3C0", Offset = "0x184A3C0", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000711")]
			[Address(RVA = "0x184A3C8", Offset = "0x184A3C8", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170001E8")]
		public string horizontalAxis
		{
			[Token(Token = "0x6000712")]
			[Address(RVA = "0x184A3D0", Offset = "0x184A3D0", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000713")]
			[Address(RVA = "0x184A3D8", Offset = "0x184A3D8", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170001E9")]
		public string verticalAxis
		{
			[Token(Token = "0x6000714")]
			[Address(RVA = "0x184A3E0", Offset = "0x184A3E0", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000715")]
			[Address(RVA = "0x184A3E8", Offset = "0x184A3E8", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170001EA")]
		public string submitButton
		{
			[Token(Token = "0x6000716")]
			[Address(RVA = "0x184A3F0", Offset = "0x184A3F0", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000717")]
			[Address(RVA = "0x184A3F8", Offset = "0x184A3F8", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170001EB")]
		public string cancelButton
		{
			[Token(Token = "0x6000718")]
			[Address(RVA = "0x184A400", Offset = "0x184A400", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000719")]
			[Address(RVA = "0x184A408", Offset = "0x184A408", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x6000708")]
		[Address(RVA = "0x184A2CC", Offset = "0x184A2CC", Length = "0xB4")]
		protected StandaloneInputModule()
		{
		}

		[Token(Token = "0x600071A")]
		[Address(RVA = "0x184A410", Offset = "0x184A410", Length = "0x8")]
		private bool ShouldIgnoreEventsOnNoFocus()
		{
			return false;
		}

		[Token(Token = "0x600071B")]
		[Address(RVA = "0x184A418", Offset = "0x184A418", Length = "0xD0")]
		public override void UpdateModule()
		{
		}

		[Token(Token = "0x600071C")]
		[Address(RVA = "0x184A4E8", Offset = "0x184A4E8", Length = "0x36C")]
		private void ReleaseMouse(PointerEventData pointerEvent, GameObject currentOverGo)
		{
		}

		[Token(Token = "0x600071D")]
		[Address(RVA = "0x184A854", Offset = "0x184A854", Length = "0x238")]
		public override bool ShouldActivateModule()
		{
			return false;
		}

		[Token(Token = "0x600071E")]
		[Address(RVA = "0x184AA8C", Offset = "0x184AA8C", Length = "0x100")]
		public override void ActivateModule()
		{
		}

		[Token(Token = "0x600071F")]
		[Address(RVA = "0x184AB8C", Offset = "0x184AB8C", Length = "0x4")]
		public override void DeactivateModule()
		{
		}

		[Token(Token = "0x6000720")]
		[Address(RVA = "0x184AB90", Offset = "0x184AB90", Length = "0xA4")]
		public override void Process()
		{
		}

		[Token(Token = "0x6000721")]
		[Address(RVA = "0x184AD7C", Offset = "0x184AD7C", Length = "0x164")]
		private bool ProcessTouchEvents()
		{
			return false;
		}

		[Token(Token = "0x6000722")]
		[Address(RVA = "0x184B35C", Offset = "0x184B35C", Length = "0x694")]
		protected void ProcessTouchPress(PointerEventData pointerEvent, bool pressed, bool released)
		{
		}

		[Token(Token = "0x6000723")]
		[Address(RVA = "0x184B148", Offset = "0x184B148", Length = "0x214")]
		protected bool SendSubmitEventToSelectedObject()
		{
			return false;
		}

		[Token(Token = "0x6000724")]
		[Address(RVA = "0x184B9F0", Offset = "0x184B9F0", Length = "0x10C")]
		private Vector2 GetRawMoveVector()
		{
			return default(Vector2);
		}

		[Token(Token = "0x6000725")]
		[Address(RVA = "0x184AEE8", Offset = "0x184AEE8", Length = "0x260")]
		protected bool SendMoveEventToSelectedObject()
		{
			return false;
		}

		[Token(Token = "0x6000726")]
		[Address(RVA = "0x184AEE0", Offset = "0x184AEE0", Length = "0x8")]
		protected void ProcessMouseEvent()
		{
		}

		[Obsolete("This method is no longer checked, overriding it with return true does nothing!")]
		[Token(Token = "0x6000727")]
		[Address(RVA = "0x184BDA4", Offset = "0x184BDA4", Length = "0x8")]
		protected virtual bool ForceAutoSelect()
		{
			return false;
		}

		[Token(Token = "0x6000728")]
		[Address(RVA = "0x184BAFC", Offset = "0x184BAFC", Length = "0x2A8")]
		protected void ProcessMouseEvent(int id)
		{
		}

		[Token(Token = "0x6000729")]
		[Address(RVA = "0x184AC34", Offset = "0x184AC34", Length = "0x148")]
		protected bool SendUpdateEventToSelectedObject()
		{
			return false;
		}

		[Token(Token = "0x600072A")]
		[Address(RVA = "0x184BDAC", Offset = "0x184BDAC", Length = "0x374")]
		protected void ProcessMousePress(MouseButtonEventData data)
		{
		}

		[Token(Token = "0x600072B")]
		[Address(RVA = "0x184C120", Offset = "0x184C120", Length = "0x8")]
		protected GameObject GetCurrentFocusedGameObject()
		{
			return null;
		}
	}
}
