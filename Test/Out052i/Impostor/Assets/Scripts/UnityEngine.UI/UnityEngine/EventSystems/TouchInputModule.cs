using System;
using Cpp2ILInjected;
using UnityEngine.Serialization;

namespace UnityEngine.EventSystems
{
	[AddComponentMenu("Event/Touch Input Module")]
	[Obsolete("TouchInputModule is no longer required as Touch input is now handled in StandaloneInputModule.")]
	[Token(Token = "0x20000C1")]
	public class TouchInputModule : PointerInputModule
	{
		[Token(Token = "0x400033B")]
		[FieldOffset(Offset = "0x68")]
		private Vector2 m_LastMousePosition;

		[Token(Token = "0x400033C")]
		[FieldOffset(Offset = "0x70")]
		private Vector2 m_MousePosition;

		[Token(Token = "0x400033D")]
		[FieldOffset(Offset = "0x78")]
		private PointerEventData m_InputPointerEvent;

		[FormerlySerializedAs("m_AllowActivationOnStandalone")]
		[SerializeField]
		[Token(Token = "0x400033E")]
		[FieldOffset(Offset = "0x80")]
		private bool m_ForceModuleActive;

		[Obsolete("allowActivationOnStandalone has been deprecated. Use forceModuleActive instead (UnityUpgradable) -> forceModuleActive")]
		[Token(Token = "0x170001EC")]
		public bool allowActivationOnStandalone
		{
			[Token(Token = "0x600072D")]
			[Address(RVA = "0x184C12C", Offset = "0x184C12C", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x600072E")]
			[Address(RVA = "0x184C134", Offset = "0x184C134", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x170001ED")]
		public bool forceModuleActive
		{
			[Token(Token = "0x600072F")]
			[Address(RVA = "0x184C140", Offset = "0x184C140", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x6000730")]
			[Address(RVA = "0x184C148", Offset = "0x184C148", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x600072C")]
		[Address(RVA = "0x184C128", Offset = "0x184C128", Length = "0x4")]
		protected TouchInputModule()
		{
		}

		[Token(Token = "0x6000731")]
		[Address(RVA = "0x184C154", Offset = "0x184C154", Length = "0x150")]
		public override void UpdateModule()
		{
		}

		[Token(Token = "0x6000732")]
		[Address(RVA = "0x184C2A4", Offset = "0x184C2A4", Length = "0x38")]
		public override bool IsModuleSupported()
		{
			return false;
		}

		[Token(Token = "0x6000733")]
		[Address(RVA = "0x184C2DC", Offset = "0x184C2DC", Length = "0xA4")]
		public override bool ShouldActivateModule()
		{
			return false;
		}

		[Token(Token = "0x6000734")]
		[Address(RVA = "0x184C380", Offset = "0x184C380", Length = "0x30")]
		private bool UseFakeInput()
		{
			return false;
		}

		[Token(Token = "0x6000735")]
		[Address(RVA = "0x184C3B0", Offset = "0x184C3B0", Length = "0x28")]
		public override void Process()
		{
		}

		[Token(Token = "0x6000736")]
		[Address(RVA = "0x184C3D8", Offset = "0x184C3D8", Length = "0x128")]
		private void FakeTouches()
		{
		}

		[Token(Token = "0x6000737")]
		[Address(RVA = "0x184C500", Offset = "0x184C500", Length = "0x148")]
		private void ProcessTouchEvents()
		{
		}

		[Token(Token = "0x6000738")]
		[Address(RVA = "0x184C648", Offset = "0x184C648", Length = "0x684")]
		protected void ProcessTouchPress(PointerEventData pointerEvent, bool pressed, bool released)
		{
		}

		[Token(Token = "0x6000739")]
		[Address(RVA = "0x184CCCC", Offset = "0x184CCCC", Length = "0x4")]
		public override void DeactivateModule()
		{
		}

		[Token(Token = "0x600073A")]
		[Address(RVA = "0x184CCD0", Offset = "0x184CCD0", Length = "0x248")]
		public override string ToString()
		{
			return null;
		}
	}
}
