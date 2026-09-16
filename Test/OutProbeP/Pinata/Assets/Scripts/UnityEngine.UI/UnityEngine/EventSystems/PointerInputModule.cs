using System.Collections.Generic;
using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x2000068")]
	public abstract class PointerInputModule : BaseInputModule
	{
		[Token(Token = "0x20000BE")]
		protected class ButtonState
		{
			[Token(Token = "0x4000307")]
			[FieldOffset(Offset = "0x10")]
			private PointerEventData.InputButton m_Button;

			[Token(Token = "0x4000308")]
			[FieldOffset(Offset = "0x18")]
			private MouseButtonEventData m_EventData;

			[Token(Token = "0x170001BE")]
			public MouseButtonEventData eventData
			{
				[Token(Token = "0x60006A5")]
				[Address(RVA = "0xC48980", Offset = "0xC48980", Length = "0x8")]
				get
				{
					return null;
				}
				[Token(Token = "0x60006A6")]
				[Address(RVA = "0xC48988", Offset = "0xC48988", Length = "0x8")]
				set
				{
				}
			}

			[Token(Token = "0x170001BF")]
			public PointerEventData.InputButton button
			{
				[Token(Token = "0x60006A7")]
				[Address(RVA = "0xC48990", Offset = "0xC48990", Length = "0x8")]
				get
				{
					return PointerEventData.InputButton.Left;
				}
				[Token(Token = "0x60006A8")]
				[Address(RVA = "0xC48998", Offset = "0xC48998", Length = "0x8")]
				set
				{
				}
			}

			[Token(Token = "0x60006A9")]
			[Address(RVA = "0xC489A0", Offset = "0xC489A0", Length = "0x8")]
			public ButtonState()
			{
			}
		}

		[Token(Token = "0x20000BF")]
		protected class MouseState
		{
			[Token(Token = "0x4000309")]
			[FieldOffset(Offset = "0x10")]
			private List<ButtonState> m_TrackedButtons;

			[Token(Token = "0x60006AA")]
			[Address(RVA = "0xC489D8", Offset = "0xC489D8", Length = "0xB8")]
			public bool AnyPressesThisFrame()
			{
				return false;
			}

			[Token(Token = "0x60006AB")]
			[Address(RVA = "0xC48A90", Offset = "0xC48A90", Length = "0xB8")]
			public bool AnyReleasesThisFrame()
			{
				return false;
			}

			[Token(Token = "0x60006AC")]
			[Address(RVA = "0xC48B48", Offset = "0xC48B48", Length = "0x2C0")]
			public ButtonState GetButtonState(PointerEventData.InputButton button)
			{
				return null;
			}

			[Token(Token = "0x60006AD")]
			[Address(RVA = "0xC47F38", Offset = "0xC47F38", Length = "0x4C")]
			public void SetButtonState(PointerEventData.InputButton button, PointerEventData.FramePressState stateForMouseButton, PointerEventData data)
			{
			}

			[Token(Token = "0x60006AE")]
			[Address(RVA = "0xC48910", Offset = "0xC48910", Length = "0x70")]
			public MouseState()
			{
			}
		}

		[Token(Token = "0x20000C0")]
		public class MouseButtonEventData
		{
			[Token(Token = "0x400030A")]
			[FieldOffset(Offset = "0x10")]
			public PointerEventData.FramePressState buttonState;

			[Token(Token = "0x400030B")]
			[FieldOffset(Offset = "0x18")]
			public PointerEventData buttonData;

			[Token(Token = "0x60006AF")]
			[Address(RVA = "0xC489A8", Offset = "0xC489A8", Length = "0x14")]
			public bool PressedThisFrame()
			{
				return false;
			}

			[Token(Token = "0x60006B0")]
			[Address(RVA = "0xC489BC", Offset = "0xC489BC", Length = "0x14")]
			public bool ReleasedThisFrame()
			{
				return false;
			}

			[Token(Token = "0x60006B1")]
			[Address(RVA = "0xC489D0", Offset = "0xC489D0", Length = "0x8")]
			public MouseButtonEventData()
			{
			}
		}

		[Token(Token = "0x40001E9")]
		public const int kMouseLeftId = -1;

		[Token(Token = "0x40001EA")]
		public const int kMouseRightId = -2;

		[Token(Token = "0x40001EB")]
		public const int kMouseMiddleId = -3;

		[Token(Token = "0x40001EC")]
		public const int kFakeTouchesId = -4;

		[Token(Token = "0x40001ED")]
		[FieldOffset(Offset = "0x48")]
		protected Dictionary<int, PointerEventData> m_PointerData;

		[Token(Token = "0x40001EE")]
		[FieldOffset(Offset = "0x50")]
		private readonly MouseState m_MouseState;

		[Token(Token = "0x60005A2")]
		[Address(RVA = "0xC47708", Offset = "0xC47708", Length = "0xE8")]
		protected bool GetPointerData(int id, out PointerEventData data, bool create)
		{
			data = null;
			return false;
		}

		[Token(Token = "0x60005A3")]
		[Address(RVA = "0xC477F0", Offset = "0xC477F0", Length = "0x70")]
		protected void RemovePointerData(PointerEventData data)
		{
		}

		[Token(Token = "0x60005A4")]
		[Address(RVA = "0xC47860", Offset = "0xC47860", Length = "0x2AC")]
		protected PointerEventData GetTouchPointerEventData(Touch input, out bool pressed, out bool released)
		{
			pressed = default(bool);
			released = default(bool);
			return null;
		}

		[Token(Token = "0x60005A5")]
		[Address(RVA = "0xC47B0C", Offset = "0xC47B0C", Length = "0x68")]
		protected void CopyFromTo(PointerEventData from, PointerEventData to)
		{
		}

		[Token(Token = "0x60005A6")]
		[Address(RVA = "0xC47B74", Offset = "0xC47B74", Length = "0x88")]
		protected PointerEventData.FramePressState StateForMouseButton(int buttonId)
		{
			return PointerEventData.FramePressState.Pressed;
		}

		[Token(Token = "0x60005A7")]
		[Address(RVA = "0xC47BFC", Offset = "0xC47BFC", Length = "0x14")]
		protected virtual MouseState GetMousePointerEventData()
		{
			return null;
		}

		[Token(Token = "0x60005A8")]
		[Address(RVA = "0xC47C10", Offset = "0xC47C10", Length = "0x328")]
		protected virtual MouseState GetMousePointerEventData(int id)
		{
			return null;
		}

		[Token(Token = "0x60005A9")]
		[Address(RVA = "0xC47F84", Offset = "0xC47F84", Length = "0x2C")]
		protected PointerEventData GetLastPointerEventData(int id)
		{
			return null;
		}

		[Token(Token = "0x60005AA")]
		[Address(RVA = "0xC47FB0", Offset = "0xC47FB0", Length = "0xD0")]
		private static bool ShouldStartDrag(Vector2 pressPos, Vector2 currentPos, float threshold, bool useDragThreshold)
		{
			return false;
		}

		[Token(Token = "0x60005AB")]
		[Address(RVA = "0xC48080", Offset = "0xC48080", Length = "0x44")]
		protected virtual void ProcessMove(PointerEventData pointerEvent)
		{
		}

		[Token(Token = "0x60005AC")]
		[Address(RVA = "0xC480C4", Offset = "0xC480C4", Length = "0x2D8")]
		protected virtual void ProcessDrag(PointerEventData pointerEvent)
		{
		}

		[Token(Token = "0x60005AD")]
		[Address(RVA = "0xC4839C", Offset = "0xC4839C", Length = "0xAC")]
		public override bool IsPointerOverGameObject(int pointerId)
		{
			return false;
		}

		[Token(Token = "0x60005AE")]
		[Address(RVA = "0xC48448", Offset = "0xC48448", Length = "0x160")]
		protected void ClearSelection()
		{
		}

		[Token(Token = "0x60005AF")]
		[Address(RVA = "0xC485A8", Offset = "0xC485A8", Length = "0x1F0")]
		public override string ToString()
		{
			return null;
		}

		[Token(Token = "0x60005B0")]
		[Address(RVA = "0xC48798", Offset = "0xC48798", Length = "0xF0")]
		protected void DeselectIfSelectionChanged(GameObject currentOverGo, BaseEventData pointerEvent)
		{
		}

		[Token(Token = "0x60005B1")]
		[Address(RVA = "0xC48888", Offset = "0xC48888", Length = "0x88")]
		protected internal PointerInputModule()
		{
		}
	}
}
