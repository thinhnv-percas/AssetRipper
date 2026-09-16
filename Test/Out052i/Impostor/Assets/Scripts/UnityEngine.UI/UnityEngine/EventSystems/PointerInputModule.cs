using System.Collections.Generic;
using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x20000BB")]
	public abstract class PointerInputModule : BaseInputModule
	{
		[Token(Token = "0x20000BC")]
		protected class ButtonState
		{
			[Token(Token = "0x4000324")]
			[FieldOffset(Offset = "0x10")]
			private PointerEventData.InputButton m_Button;

			[Token(Token = "0x4000325")]
			[FieldOffset(Offset = "0x18")]
			private MouseButtonEventData m_EventData;

			[Token(Token = "0x170001E1")]
			public MouseButtonEventData eventData
			{
				[Token(Token = "0x60006FB")]
				[Address(RVA = "0x1849F6C", Offset = "0x1849F6C", Length = "0x8")]
				get
				{
					return null;
				}
				[Token(Token = "0x60006FC")]
				[Address(RVA = "0x1849F74", Offset = "0x1849F74", Length = "0x8")]
				set
				{
				}
			}

			[Token(Token = "0x170001E2")]
			public PointerEventData.InputButton button
			{
				[Token(Token = "0x60006FD")]
				[Address(RVA = "0x1849F7C", Offset = "0x1849F7C", Length = "0x8")]
				get
				{
					return PointerEventData.InputButton.Left;
				}
				[Token(Token = "0x60006FE")]
				[Address(RVA = "0x1849F84", Offset = "0x1849F84", Length = "0x8")]
				set
				{
				}
			}

			[Token(Token = "0x60006FF")]
			[Address(RVA = "0x1849F8C", Offset = "0x1849F8C", Length = "0x8")]
			public ButtonState()
			{
			}
		}

		[Token(Token = "0x20000BD")]
		protected class MouseState
		{
			[Token(Token = "0x4000326")]
			[FieldOffset(Offset = "0x10")]
			private List<ButtonState> m_TrackedButtons;

			[Token(Token = "0x6000700")]
			[Address(RVA = "0x1849F94", Offset = "0x1849F94", Length = "0xBC")]
			public bool AnyPressesThisFrame()
			{
				return false;
			}

			[Token(Token = "0x6000701")]
			[Address(RVA = "0x184A060", Offset = "0x184A060", Length = "0xC0")]
			public bool AnyReleasesThisFrame()
			{
				return false;
			}

			[Token(Token = "0x6000702")]
			[Address(RVA = "0x184A134", Offset = "0x184A134", Length = "0x190")]
			public ButtonState GetButtonState(PointerEventData.InputButton button)
			{
				return null;
			}

			[Token(Token = "0x6000703")]
			[Address(RVA = "0x1849514", Offset = "0x1849514", Length = "0x38")]
			public void SetButtonState(PointerEventData.InputButton button, PointerEventData.FramePressState stateForMouseButton, PointerEventData data)
			{
			}

			[Token(Token = "0x6000704")]
			[Address(RVA = "0x1849EF0", Offset = "0x1849EF0", Length = "0x7C")]
			public MouseState()
			{
			}
		}

		[Token(Token = "0x20000BE")]
		public class MouseButtonEventData
		{
			[Token(Token = "0x4000327")]
			[FieldOffset(Offset = "0x10")]
			public PointerEventData.FramePressState buttonState;

			[Token(Token = "0x4000328")]
			[FieldOffset(Offset = "0x18")]
			public PointerEventData buttonData;

			[Token(Token = "0x6000705")]
			[Address(RVA = "0x184A050", Offset = "0x184A050", Length = "0x10")]
			public bool PressedThisFrame()
			{
				return false;
			}

			[Token(Token = "0x6000706")]
			[Address(RVA = "0x184A120", Offset = "0x184A120", Length = "0x14")]
			public bool ReleasedThisFrame()
			{
				return false;
			}

			[Token(Token = "0x6000707")]
			[Address(RVA = "0x184A2C4", Offset = "0x184A2C4", Length = "0x8")]
			public MouseButtonEventData()
			{
			}
		}

		[Token(Token = "0x400031E")]
		public const int kMouseLeftId = -1;

		[Token(Token = "0x400031F")]
		public const int kMouseRightId = -2;

		[Token(Token = "0x4000320")]
		public const int kMouseMiddleId = -3;

		[Token(Token = "0x4000321")]
		public const int kFakeTouchesId = -4;

		[Token(Token = "0x4000322")]
		[FieldOffset(Offset = "0x58")]
		protected Dictionary<int, PointerEventData> m_PointerData;

		[Token(Token = "0x4000323")]
		[FieldOffset(Offset = "0x60")]
		private readonly MouseState m_MouseState;

		[Token(Token = "0x60006EB")]
		[Address(RVA = "0x1848C20", Offset = "0x1848C20", Length = "0xEC")]
		protected bool GetPointerData(int id, out PointerEventData data, bool create)
		{
			data = null;
			return false;
		}

		[Token(Token = "0x60006EC")]
		[Address(RVA = "0x1848D0C", Offset = "0x1848D0C", Length = "0x5C")]
		protected void RemovePointerData(PointerEventData data)
		{
		}

		[Token(Token = "0x60006ED")]
		[Address(RVA = "0x1848D68", Offset = "0x1848D68", Length = "0x37C")]
		protected PointerEventData GetTouchPointerEventData(Touch input, out bool pressed, out bool released)
		{
			pressed = default(bool);
			released = default(bool);
			return null;
		}

		[Token(Token = "0x60006EE")]
		[Address(RVA = "0x18490E4", Offset = "0x18490E4", Length = "0x88")]
		protected void CopyFromTo(PointerEventData from, PointerEventData to)
		{
		}

		[Token(Token = "0x60006EF")]
		[Address(RVA = "0x184916C", Offset = "0x184916C", Length = "0x7C")]
		protected PointerEventData.FramePressState StateForMouseButton(int buttonId)
		{
			return PointerEventData.FramePressState.Pressed;
		}

		[Token(Token = "0x60006F0")]
		[Address(RVA = "0x18491E8", Offset = "0x18491E8", Length = "0x14")]
		protected virtual MouseState GetMousePointerEventData()
		{
			return null;
		}

		[Token(Token = "0x60006F1")]
		[Address(RVA = "0x18491FC", Offset = "0x18491FC", Length = "0x318")]
		protected virtual MouseState GetMousePointerEventData(int id)
		{
			return null;
		}

		[Token(Token = "0x60006F2")]
		[Address(RVA = "0x184954C", Offset = "0x184954C", Length = "0x20")]
		protected PointerEventData GetLastPointerEventData(int id)
		{
			return null;
		}

		[Token(Token = "0x60006F3")]
		[Address(RVA = "0x184956C", Offset = "0x184956C", Length = "0x30")]
		private static bool ShouldStartDrag(Vector2 pressPos, Vector2 currentPos, float threshold, bool useDragThreshold)
		{
			return false;
		}

		[Token(Token = "0x60006F4")]
		[Address(RVA = "0x184959C", Offset = "0x184959C", Length = "0x44")]
		protected virtual void ProcessMove(PointerEventData pointerEvent)
		{
		}

		[Token(Token = "0x60006F5")]
		[Address(RVA = "0x18495E0", Offset = "0x18495E0", Length = "0x2C0")]
		protected virtual void ProcessDrag(PointerEventData pointerEvent)
		{
		}

		[Token(Token = "0x60006F6")]
		[Address(RVA = "0x18498A0", Offset = "0x18498A0", Length = "0x9C")]
		public override bool IsPointerOverGameObject(int pointerId)
		{
			return false;
		}

		[Token(Token = "0x60006F7")]
		[Address(RVA = "0x184993C", Offset = "0x184993C", Length = "0x1C0")]
		protected void ClearSelection()
		{
		}

		[Token(Token = "0x60006F8")]
		[Address(RVA = "0x1849AFC", Offset = "0x1849AFC", Length = "0x268")]
		public override string ToString()
		{
			return null;
		}

		[Token(Token = "0x60006F9")]
		[Address(RVA = "0x1849D64", Offset = "0x1849D64", Length = "0xEC")]
		protected void DeselectIfSelectionChanged(GameObject currentOverGo, BaseEventData pointerEvent)
		{
		}

		[Token(Token = "0x60006FA")]
		[Address(RVA = "0x1849E50", Offset = "0x1849E50", Length = "0xA0")]
		protected internal PointerInputModule()
		{
		}
	}
}
