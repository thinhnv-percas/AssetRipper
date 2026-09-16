using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace UnityEngine.UI
{
	[AddComponentMenu("UI/Scrollbar", 36)]
	[ExecuteAlways]
	[RequireComponent(typeof(RectTransform))]
	[Token(Token = "0x2000060")]
	public class Scrollbar : Selectable, IBeginDragHandler, IEventSystemHandler, IDragHandler, IInitializePotentialDragHandler, ICanvasElement
	{
		[Token(Token = "0x2000061")]
		public enum Direction
		{
			[Token(Token = "0x40001CD")]
			LeftToRight = 0,
			[Token(Token = "0x40001CE")]
			RightToLeft = 1,
			[Token(Token = "0x40001CF")]
			BottomToTop = 2,
			[Token(Token = "0x40001D0")]
			TopToBottom = 3
		}

		[Serializable]
		[Token(Token = "0x2000062")]
		public class ScrollEvent : UnityEvent<float>
		{
			[Token(Token = "0x60003BD")]
			[Address(RVA = "0x182EFD0", Offset = "0x182EFD0", Length = "0x48")]
			public ScrollEvent()
			{
			}
		}

		[Token(Token = "0x2000063")]
		private enum Axis
		{
			[Token(Token = "0x40001D2")]
			Horizontal = 0,
			[Token(Token = "0x40001D3")]
			Vertical = 1
		}

		[CompilerGenerated]
		[Token(Token = "0x2000064")]
		private sealed class _003CClickRepeat_003Ed__58 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[Token(Token = "0x40001D4")]
			[FieldOffset(Offset = "0x10")]
			private int _003C_003E1__state;

			[Token(Token = "0x40001D5")]
			[FieldOffset(Offset = "0x18")]
			private object _003C_003E2__current;

			[Token(Token = "0x40001D6")]
			[FieldOffset(Offset = "0x20")]
			public Scrollbar _003C_003E4__this;

			[Token(Token = "0x40001D7")]
			[FieldOffset(Offset = "0x28")]
			public Vector2 screenPosition;

			[Token(Token = "0x40001D8")]
			[FieldOffset(Offset = "0x30")]
			public Camera camera;

			[Token(Token = "0x170000F5")]
			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60003C1")]
				[Address(RVA = "0x1830B7C", Offset = "0x1830B7C", Length = "0x8")]
				get
				{
					return null;
				}
			}

			[Token(Token = "0x170000F6")]
			object IEnumerator.Current
			{
				[DebuggerHidden]
				[Token(Token = "0x60003C3")]
				[Address(RVA = "0x1830BBC", Offset = "0x1830BBC", Length = "0x8")]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			[Token(Token = "0x60003BE")]
			[Address(RVA = "0x183004C", Offset = "0x183004C", Length = "0x28")]
			public _003CClickRepeat_003Ed__58(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			[Token(Token = "0x60003BF")]
			[Address(RVA = "0x1830920", Offset = "0x1830920", Length = "0x4")]
			void IDisposable.Dispose()
			{
			}

			[Token(Token = "0x60003C0")]
			[Address(RVA = "0x1830924", Offset = "0x1830924", Length = "0x258")]
			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			[Token(Token = "0x60003C2")]
			[Address(RVA = "0x1830B84", Offset = "0x1830B84", Length = "0x38")]
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		[Token(Token = "0x40001C0")]
		[FieldOffset(Offset = "0x100")]
		private RectTransform m_HandleRect;

		[SerializeField]
		[Token(Token = "0x40001C1")]
		[FieldOffset(Offset = "0x108")]
		private Direction m_Direction;

		[Range(0f, 1f)]
		[SerializeField]
		[Token(Token = "0x40001C2")]
		[FieldOffset(Offset = "0x10C")]
		private float m_Value;

		[Range(0f, 1f)]
		[SerializeField]
		[Token(Token = "0x40001C3")]
		[FieldOffset(Offset = "0x110")]
		private float m_Size;

		[Range(0f, 11f)]
		[SerializeField]
		[Token(Token = "0x40001C4")]
		[FieldOffset(Offset = "0x114")]
		private int m_NumberOfSteps;

		[Space(6f)]
		[SerializeField]
		[Token(Token = "0x40001C5")]
		[FieldOffset(Offset = "0x118")]
		private ScrollEvent m_OnValueChanged;

		[Token(Token = "0x40001C6")]
		[FieldOffset(Offset = "0x120")]
		private RectTransform m_ContainerRect;

		[Token(Token = "0x40001C7")]
		[FieldOffset(Offset = "0x128")]
		private Vector2 m_Offset;

		[Token(Token = "0x40001C8")]
		[FieldOffset(Offset = "0x130")]
		private DrivenRectTransformTracker m_Tracker;

		[Token(Token = "0x40001C9")]
		[FieldOffset(Offset = "0x138")]
		private Coroutine m_PointerDownRepeat;

		[Token(Token = "0x40001CA")]
		[FieldOffset(Offset = "0x140")]
		private bool isPointerDownAndNotDragging;

		[Token(Token = "0x40001CB")]
		[FieldOffset(Offset = "0x141")]
		private bool m_DelayedUpdateVisuals;

		[Token(Token = "0x170000EC")]
		public RectTransform handleRect
		{
			[Token(Token = "0x6000391")]
			[Address(RVA = "0x182EB78", Offset = "0x182EB78", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000392")]
			[Address(RVA = "0x182EB80", Offset = "0x182EB80", Length = "0x7C")]
			set
			{
			}
		}

		[Token(Token = "0x170000ED")]
		public Direction direction
		{
			[Token(Token = "0x6000393")]
			[Address(RVA = "0x182EE94", Offset = "0x182EE94", Length = "0x8")]
			get
			{
				return Direction.LeftToRight;
			}
			[Token(Token = "0x6000394")]
			[Address(RVA = "0x182EE9C", Offset = "0x182EE9C", Length = "0x74")]
			set
			{
			}
		}

		[Token(Token = "0x170000EE")]
		public float value
		{
			[Token(Token = "0x6000396")]
			[Address(RVA = "0x182F12C", Offset = "0x182F12C", Length = "0xB8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x6000397")]
			[Address(RVA = "0x182F1E4", Offset = "0x182F1E4", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000EF")]
		public float size
		{
			[Token(Token = "0x6000399")]
			[Address(RVA = "0x182F2B8", Offset = "0x182F2B8", Length = "0x8")]
			get
			{
				return 0f;
			}
			[Token(Token = "0x600039A")]
			[Address(RVA = "0x182F2C0", Offset = "0x182F2C0", Length = "0x84")]
			set
			{
			}
		}

		[Token(Token = "0x170000F0")]
		public int numberOfSteps
		{
			[Token(Token = "0x600039B")]
			[Address(RVA = "0x182F344", Offset = "0x182F344", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x600039C")]
			[Address(RVA = "0x182F34C", Offset = "0x182F34C", Length = "0x84")]
			set
			{
			}
		}

		[Token(Token = "0x170000F1")]
		public ScrollEvent onValueChanged
		{
			[Token(Token = "0x600039D")]
			[Address(RVA = "0x182F3D0", Offset = "0x182F3D0", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600039E")]
			[Address(RVA = "0x182F3D8", Offset = "0x182F3D8", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170000F2")]
		private float stepSize
		{
			[Token(Token = "0x600039F")]
			[Address(RVA = "0x182F3E0", Offset = "0x182F3E0", Length = "0x2C")]
			get
			{
				return 0f;
			}
		}

		[Token(Token = "0x170000F3")]
		private Axis axis
		{
			[Token(Token = "0x60003A9")]
			[Address(RVA = "0x182F894", Offset = "0x182F894", Length = "0x10")]
			get
			{
				return Axis.Horizontal;
			}
		}

		[Token(Token = "0x170000F4")]
		private bool reverseValue
		{
			[Token(Token = "0x60003AA")]
			[Address(RVA = "0x182F8A4", Offset = "0x182F8A4", Length = "0x14")]
			get
			{
				return false;
			}
		}

		Transform ICanvasElement.transform
		{
			[Token(Token = "0x60003BC")]
			[Address(RVA = "0x1830918", Offset = "0x1830918", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x6000395")]
		[Address(RVA = "0x182EF10", Offset = "0x182EF10", Length = "0xC0")]
		protected Scrollbar()
		{
		}

		[Token(Token = "0x6000398")]
		[Address(RVA = "0x182F2B0", Offset = "0x182F2B0", Length = "0x8")]
		public virtual void SetValueWithoutNotify(float input)
		{
		}

		[Token(Token = "0x60003A0")]
		[Address(RVA = "0x182F40C", Offset = "0x182F40C", Length = "0x4")]
		public virtual void Rebuild(CanvasUpdate executing)
		{
		}

		[Token(Token = "0x60003A1")]
		[Address(RVA = "0x182F410", Offset = "0x182F410", Length = "0x4")]
		public virtual void LayoutComplete()
		{
		}

		[Token(Token = "0x60003A2")]
		[Address(RVA = "0x182F414", Offset = "0x182F414", Length = "0x4")]
		public virtual void GraphicUpdateComplete()
		{
		}

		[Token(Token = "0x60003A3")]
		[Address(RVA = "0x182F418", Offset = "0x182F418", Length = "0x30")]
		protected override void OnEnable()
		{
		}

		[Token(Token = "0x60003A4")]
		[Address(RVA = "0x182F700", Offset = "0x182F700", Length = "0x20")]
		protected override void OnDisable()
		{
		}

		[Token(Token = "0x60003A5")]
		[Address(RVA = "0x182F848", Offset = "0x182F848", Length = "0x14")]
		protected virtual void Update()
		{
		}

		[Token(Token = "0x60003A6")]
		[Address(RVA = "0x182EBFC", Offset = "0x182EBFC", Length = "0xE0")]
		private void UpdateCachedReferences()
		{
		}

		[Token(Token = "0x60003A7")]
		[Address(RVA = "0x182F1EC", Offset = "0x182F1EC", Length = "0xC4")]
		private void Set(float input, bool sendCallback = true)
		{
		}

		[Token(Token = "0x60003A8")]
		[Address(RVA = "0x182F85C", Offset = "0x182F85C", Length = "0x38")]
		protected override void OnRectTransformDimensionsChange()
		{
		}

		[Token(Token = "0x60003AB")]
		[Address(RVA = "0x182ECDC", Offset = "0x182ECDC", Length = "0x1B8")]
		private void UpdateVisuals()
		{
		}

		[Token(Token = "0x60003AC")]
		[Address(RVA = "0x182F8B8", Offset = "0x182F8B8", Length = "0x210")]
		private void UpdateDrag(PointerEventData eventData)
		{
		}

		[Token(Token = "0x60003AD")]
		[Address(RVA = "0x182FAC8", Offset = "0x182FAC8", Length = "0x68")]
		private void DoUpdateDrag(Vector2 handleCorner, float remainingSize)
		{
		}

		[Token(Token = "0x60003AE")]
		[Address(RVA = "0x182FB30", Offset = "0x182FB30", Length = "0x64")]
		private bool MayDrag(PointerEventData eventData)
		{
			return false;
		}

		[Token(Token = "0x60003AF")]
		[Address(RVA = "0x182FB94", Offset = "0x182FB94", Length = "0x1B4")]
		public virtual void OnBeginDrag(PointerEventData eventData)
		{
		}

		[Token(Token = "0x60003B0")]
		[Address(RVA = "0x182FD48", Offset = "0x182FD48", Length = "0x90")]
		public virtual void OnDrag(PointerEventData eventData)
		{
		}

		[Token(Token = "0x60003B1")]
		[Address(RVA = "0x182FDD8", Offset = "0x182FDD8", Length = "0x80")]
		public override void OnPointerDown(PointerEventData eventData)
		{
		}

		[Token(Token = "0x60003B2")]
		[Address(RVA = "0x183000C", Offset = "0x183000C", Length = "0x40")]
		protected IEnumerator ClickRepeat(PointerEventData eventData)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CClickRepeat_003Ed__58))]
		[Token(Token = "0x60003B3")]
		[Address(RVA = "0x182FF88", Offset = "0x182FF88", Length = "0x84")]
		protected IEnumerator ClickRepeat(Vector2 screenPosition, Camera camera)
		{
			return null;
		}

		[Token(Token = "0x60003B4")]
		[Address(RVA = "0x1830074", Offset = "0x1830074", Length = "0x18")]
		public override void OnPointerUp(PointerEventData eventData)
		{
		}

		[Token(Token = "0x60003B5")]
		[Address(RVA = "0x18300B4", Offset = "0x18300B4", Length = "0x248")]
		public override void OnMove(AxisEventData eventData)
		{
		}

		[Token(Token = "0x60003B6")]
		[Address(RVA = "0x1830388", Offset = "0x1830388", Length = "0x24")]
		public override Selectable FindSelectableOnLeft()
		{
			return null;
		}

		[Token(Token = "0x60003B7")]
		[Address(RVA = "0x1830484", Offset = "0x1830484", Length = "0x24")]
		public override Selectable FindSelectableOnRight()
		{
			return null;
		}

		[Token(Token = "0x60003B8")]
		[Address(RVA = "0x1830580", Offset = "0x1830580", Length = "0x24")]
		public override Selectable FindSelectableOnUp()
		{
			return null;
		}

		[Token(Token = "0x60003B9")]
		[Address(RVA = "0x183067C", Offset = "0x183067C", Length = "0x24")]
		public override Selectable FindSelectableOnDown()
		{
			return null;
		}

		[Token(Token = "0x60003BA")]
		[Address(RVA = "0x1830778", Offset = "0x1830778", Length = "0x18")]
		public virtual void OnInitializePotentialDrag(PointerEventData eventData)
		{
		}

		[Token(Token = "0x60003BB")]
		[Address(RVA = "0x1830790", Offset = "0x1830790", Length = "0x188")]
		public void SetDirection(Direction direction, bool includeRectLayouts)
		{
		}
	}
}
