using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x200004E")]
	public class PointerEventData : BaseEventData
	{
		[Token(Token = "0x20000B8")]
		public enum InputButton
		{
			[Token(Token = "0x40002FC")]
			Left = 0,
			[Token(Token = "0x40002FD")]
			Right = 1,
			[Token(Token = "0x40002FE")]
			Middle = 2
		}

		[Token(Token = "0x20000B9")]
		public enum FramePressState
		{
			[Token(Token = "0x4000300")]
			Pressed = 0,
			[Token(Token = "0x4000301")]
			Released = 1,
			[Token(Token = "0x4000302")]
			PressedAndReleased = 2,
			[Token(Token = "0x4000303")]
			NotChanged = 3
		}

		[Token(Token = "0x400019B")]
		[FieldOffset(Offset = "0x28")]
		private GameObject m_PointerPress;

		[Token(Token = "0x40001A1")]
		[FieldOffset(Offset = "0xD8")]
		public List<GameObject> hovered;

		[Token(Token = "0x17000154")]
		[field: Token(Token = "0x400019A")]
		[field: FieldOffset(Offset = "0x20")]
		public GameObject pointerEnter
		{
			[Token(Token = "0x60004DD")]
			[Address(RVA = "0xC46918", Offset = "0xC46918", Length = "0x8")]
			get;
			[Token(Token = "0x60004DE")]
			[Address(RVA = "0xC46920", Offset = "0xC46920", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000155")]
		[field: Token(Token = "0x400019C")]
		[field: FieldOffset(Offset = "0x30")]
		public GameObject lastPress
		{
			[Token(Token = "0x60004DF")]
			[Address(RVA = "0xC46928", Offset = "0xC46928", Length = "0x8")]
			get;
			[Token(Token = "0x60004E0")]
			[Address(RVA = "0xC46930", Offset = "0xC46930", Length = "0x8")]
			private set;
		}

		[Token(Token = "0x17000156")]
		[field: Token(Token = "0x400019D")]
		[field: FieldOffset(Offset = "0x38")]
		public GameObject rawPointerPress
		{
			[Token(Token = "0x60004E1")]
			[Address(RVA = "0xC46938", Offset = "0xC46938", Length = "0x8")]
			get;
			[Token(Token = "0x60004E2")]
			[Address(RVA = "0xC46940", Offset = "0xC46940", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000157")]
		[field: Token(Token = "0x400019E")]
		[field: FieldOffset(Offset = "0x40")]
		public GameObject pointerDrag
		{
			[Token(Token = "0x60004E3")]
			[Address(RVA = "0xC46948", Offset = "0xC46948", Length = "0x8")]
			get;
			[Token(Token = "0x60004E4")]
			[Address(RVA = "0xC46950", Offset = "0xC46950", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000158")]
		[field: Token(Token = "0x400019F")]
		[field: FieldOffset(Offset = "0x48")]
		public RaycastResult pointerCurrentRaycast
		{
			[Token(Token = "0x60004E5")]
			[Address(RVA = "0xC46958", Offset = "0xC46958", Length = "0x10")]
			get;
			[Token(Token = "0x60004E6")]
			[Address(RVA = "0xC46968", Offset = "0xC46968", Length = "0x1C")]
			set;
		}

		[Token(Token = "0x17000159")]
		[field: Token(Token = "0x40001A0")]
		[field: FieldOffset(Offset = "0x90")]
		public RaycastResult pointerPressRaycast
		{
			[Token(Token = "0x60004E7")]
			[Address(RVA = "0xC46984", Offset = "0xC46984", Length = "0x10")]
			get;
			[Token(Token = "0x60004E8")]
			[Address(RVA = "0xC46994", Offset = "0xC46994", Length = "0x1C")]
			set;
		}

		[Token(Token = "0x1700015A")]
		[field: Token(Token = "0x40001A2")]
		[field: FieldOffset(Offset = "0xE0")]
		public bool eligibleForClick
		{
			[Token(Token = "0x60004E9")]
			[Address(RVA = "0xC469B0", Offset = "0xC469B0", Length = "0x8")]
			get;
			[Token(Token = "0x60004EA")]
			[Address(RVA = "0xC469B8", Offset = "0xC469B8", Length = "0xC")]
			set;
		}

		[Token(Token = "0x1700015B")]
		[field: Token(Token = "0x40001A3")]
		[field: FieldOffset(Offset = "0xE4")]
		public int pointerId
		{
			[Token(Token = "0x60004EB")]
			[Address(RVA = "0xC469C4", Offset = "0xC469C4", Length = "0x8")]
			get;
			[Token(Token = "0x60004EC")]
			[Address(RVA = "0xC469CC", Offset = "0xC469CC", Length = "0x8")]
			set;
		}

		[Token(Token = "0x1700015C")]
		[field: Token(Token = "0x40001A4")]
		[field: FieldOffset(Offset = "0xE8")]
		public Vector2 position
		{
			[Token(Token = "0x60004ED")]
			[Address(RVA = "0xC469D4", Offset = "0xC469D4", Length = "0x8")]
			get;
			[Token(Token = "0x60004EE")]
			[Address(RVA = "0xC469DC", Offset = "0xC469DC", Length = "0x8")]
			set;
		}

		[Token(Token = "0x1700015D")]
		[field: Token(Token = "0x40001A5")]
		[field: FieldOffset(Offset = "0xF0")]
		public Vector2 delta
		{
			[Token(Token = "0x60004EF")]
			[Address(RVA = "0xC469E4", Offset = "0xC469E4", Length = "0x8")]
			get;
			[Token(Token = "0x60004F0")]
			[Address(RVA = "0xC469EC", Offset = "0xC469EC", Length = "0x8")]
			set;
		}

		[Token(Token = "0x1700015E")]
		[field: Token(Token = "0x40001A6")]
		[field: FieldOffset(Offset = "0xF8")]
		public Vector2 pressPosition
		{
			[Token(Token = "0x60004F1")]
			[Address(RVA = "0xC469F4", Offset = "0xC469F4", Length = "0x8")]
			get;
			[Token(Token = "0x60004F2")]
			[Address(RVA = "0xC469FC", Offset = "0xC469FC", Length = "0x8")]
			set;
		}

		[Obsolete]
		[Token(Token = "0x1700015F")]
		[field: Token(Token = "0x40001A7")]
		[field: FieldOffset(Offset = "0x100")]
		public Vector3 worldPosition
		{
			[Token(Token = "0x60004F3")]
			[Address(RVA = "0xC46A04", Offset = "0xC46A04", Length = "0x10")]
			get;
			[Token(Token = "0x60004F4")]
			[Address(RVA = "0xC46A14", Offset = "0xC46A14", Length = "0x10")]
			set;
		}

		[Obsolete]
		[Token(Token = "0x17000160")]
		[field: Token(Token = "0x40001A8")]
		[field: FieldOffset(Offset = "0x10C")]
		public Vector3 worldNormal
		{
			[Token(Token = "0x60004F5")]
			[Address(RVA = "0xC46A24", Offset = "0xC46A24", Length = "0x10")]
			get;
			[Token(Token = "0x60004F6")]
			[Address(RVA = "0xC46A34", Offset = "0xC46A34", Length = "0x10")]
			set;
		}

		[Token(Token = "0x17000161")]
		[field: Token(Token = "0x40001A9")]
		[field: FieldOffset(Offset = "0x118")]
		public float clickTime
		{
			[Token(Token = "0x60004F7")]
			[Address(RVA = "0xC46A44", Offset = "0xC46A44", Length = "0x8")]
			get;
			[Token(Token = "0x60004F8")]
			[Address(RVA = "0xC46A4C", Offset = "0xC46A4C", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000162")]
		[field: Token(Token = "0x40001AA")]
		[field: FieldOffset(Offset = "0x11C")]
		public int clickCount
		{
			[Token(Token = "0x60004F9")]
			[Address(RVA = "0xC46A54", Offset = "0xC46A54", Length = "0x8")]
			get;
			[Token(Token = "0x60004FA")]
			[Address(RVA = "0xC46A5C", Offset = "0xC46A5C", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000163")]
		[field: Token(Token = "0x40001AB")]
		[field: FieldOffset(Offset = "0x120")]
		public Vector2 scrollDelta
		{
			[Token(Token = "0x60004FB")]
			[Address(RVA = "0xC46A64", Offset = "0xC46A64", Length = "0xC")]
			get;
			[Token(Token = "0x60004FC")]
			[Address(RVA = "0xC46A70", Offset = "0xC46A70", Length = "0xC")]
			set;
		}

		[Token(Token = "0x17000164")]
		[field: Token(Token = "0x40001AC")]
		[field: FieldOffset(Offset = "0x128")]
		public bool useDragThreshold
		{
			[Token(Token = "0x60004FD")]
			[Address(RVA = "0xC46A7C", Offset = "0xC46A7C", Length = "0x8")]
			get;
			[Token(Token = "0x60004FE")]
			[Address(RVA = "0xC46A84", Offset = "0xC46A84", Length = "0xC")]
			set;
		}

		[Token(Token = "0x17000165")]
		[field: Token(Token = "0x40001AD")]
		[field: FieldOffset(Offset = "0x129")]
		public bool dragging
		{
			[Token(Token = "0x60004FF")]
			[Address(RVA = "0xC46A90", Offset = "0xC46A90", Length = "0x8")]
			get;
			[Token(Token = "0x6000500")]
			[Address(RVA = "0xC46A98", Offset = "0xC46A98", Length = "0xC")]
			set;
		}

		[Token(Token = "0x17000166")]
		[field: Token(Token = "0x40001AE")]
		[field: FieldOffset(Offset = "0x12C")]
		public InputButton button
		{
			[Token(Token = "0x6000501")]
			[Address(RVA = "0xC46AA4", Offset = "0xC46AA4", Length = "0x8")]
			get;
			[Token(Token = "0x6000502")]
			[Address(RVA = "0xC46AAC", Offset = "0xC46AAC", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000167")]
		public Camera enterEventCamera
		{
			[Token(Token = "0x6000506")]
			[Address(RVA = "0xC46C14", Offset = "0xC46C14", Length = "0xA0")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000168")]
		public Camera pressEventCamera
		{
			[Token(Token = "0x6000507")]
			[Address(RVA = "0xC46CB4", Offset = "0xC46CB4", Length = "0xA0")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x17000169")]
		public GameObject pointerPress
		{
			[Token(Token = "0x6000508")]
			[Address(RVA = "0xC46D54", Offset = "0xC46D54", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x6000509")]
			[Address(RVA = "0xC46D5C", Offset = "0xC46D5C", Length = "0x8C")]
			set
			{
			}
		}

		[Token(Token = "0x6000503")]
		[Address(RVA = "0xC46AB4", Offset = "0xC46AB4", Length = "0xF4")]
		public PointerEventData(EventSystem eventSystem)
			: base(null)
		{
		}

		[Token(Token = "0x6000504")]
		[Address(RVA = "0xC46BA8", Offset = "0xC46BA8", Length = "0x34")]
		public bool IsPointerMoving()
		{
			return false;
		}

		[Token(Token = "0x6000505")]
		[Address(RVA = "0xC46BDC", Offset = "0xC46BDC", Length = "0x38")]
		public bool IsScrolling()
		{
			return false;
		}

		[Token(Token = "0x600050A")]
		[Address(RVA = "0xC46DE8", Offset = "0xC46DE8", Length = "0x920")]
		public override string ToString()
		{
			return null;
		}
	}
}
