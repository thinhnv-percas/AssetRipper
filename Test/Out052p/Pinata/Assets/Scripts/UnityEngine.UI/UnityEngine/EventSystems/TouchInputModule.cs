using System;
using Cpp2ILInjected;
using UnityEngine.Serialization;

namespace UnityEngine.EventSystems
{
	[Obsolete]
	[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x727DFC", Offset = "0x727DFC")]
	[Token(Token = "0x200006A")]
	public class TouchInputModule : PointerInputModule
	{
		[Token(Token = "0x40001FD")]
		[FieldOffset(Offset = "0x58")]
		private Vector2 m_LastMousePosition;

		[Token(Token = "0x40001FE")]
		[FieldOffset(Offset = "0x60")]
		private Vector2 m_MousePosition;

		[Token(Token = "0x40001FF")]
		[FieldOffset(Offset = "0x68")]
		private PointerEventData m_InputPointerEvent;

		[SerializeField]
		[AttributeAttribute(Type = typeof(FormerlySerializedAsAttribute), RVA = "0x729E44", Offset = "0x729E44")]
		[Token(Token = "0x4000200")]
		[FieldOffset(Offset = "0x70")]
		private bool m_ForceModuleActive;

		[Obsolete]
		[Token(Token = "0x1700019B")]
		public bool allowActivationOnStandalone
		{
			[Token(Token = "0x60005D8")]
			[Address(RVA = "0xC4AF48", Offset = "0xC4AF48", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60005D9")]
			[Address(RVA = "0xC4AF50", Offset = "0xC4AF50", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x1700019C")]
		public bool forceModuleActive
		{
			[Token(Token = "0x60005DA")]
			[Address(RVA = "0xC4AF5C", Offset = "0xC4AF5C", Length = "0x8")]
			get
			{
				return false;
			}
			[Token(Token = "0x60005DB")]
			[Address(RVA = "0xC4AF64", Offset = "0xC4AF64", Length = "0xC")]
			set
			{
			}
		}

		[Token(Token = "0x60005D7")]
		[Address(RVA = "0xC4AF44", Offset = "0xC4AF44", Length = "0x4")]
		protected TouchInputModule()
		{
		}

		[Token(Token = "0x60005DC")]
		[Address(RVA = "0xC4AF70", Offset = "0xC4AF70", Length = "0x168")]
		public override void UpdateModule()
		{
		}

		[Token(Token = "0x60005DD")]
		[Address(RVA = "0xC4B0D8", Offset = "0xC4B0D8", Length = "0x3C")]
		public override bool IsModuleSupported()
		{
			return false;
		}

		[Token(Token = "0x60005DE")]
		[Address(RVA = "0xC4B114", Offset = "0xC4B114", Length = "0x140")]
		public override bool ShouldActivateModule()
		{
			return false;
		}

		[Token(Token = "0x60005DF")]
		[Address(RVA = "0xC4B254", Offset = "0xC4B254", Length = "0x34")]
		private bool UseFakeInput()
		{
			return false;
		}

		[Token(Token = "0x60005E0")]
		[Address(RVA = "0xC4B288", Offset = "0xC4B288", Length = "0x38")]
		public override void Process()
		{
		}

		[Token(Token = "0x60005E1")]
		[Address(RVA = "0xC4B2C0", Offset = "0xC4B2C0", Length = "0x150")]
		private void FakeTouches()
		{
		}

		[Token(Token = "0x60005E2")]
		[Address(RVA = "0xC4B410", Offset = "0xC4B410", Length = "0x15C")]
		private void ProcessTouchEvents()
		{
		}

		[Token(Token = "0x60005E3")]
		[Address(RVA = "0xC4B56C", Offset = "0xC4B56C", Length = "0x6E8")]
		protected void ProcessTouchPress(PointerEventData pointerEvent, bool pressed, bool released)
		{
		}

		[Token(Token = "0x60005E4")]
		[Address(RVA = "0xC4BC54", Offset = "0xC4BC54", Length = "0x4")]
		public override void DeactivateModule()
		{
		}

		[Token(Token = "0x60005E5")]
		[Address(RVA = "0xC4BC58", Offset = "0xC4BC58", Length = "0x1DC")]
		public override string ToString()
		{
			return null;
		}
	}
}
