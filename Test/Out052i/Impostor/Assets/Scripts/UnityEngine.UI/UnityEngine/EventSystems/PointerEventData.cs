using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x2000099")]
	public class PointerEventData : BaseEventData
	{
		[Token(Token = "0x200009A")]
		public enum InputButton
		{
			[Token(Token = "0x40002D2")]
			Left = 0,
			[Token(Token = "0x40002D3")]
			Right = 1,
			[Token(Token = "0x40002D4")]
			Middle = 2
		}

		[Token(Token = "0x200009B")]
		public enum FramePressState
		{
			[Token(Token = "0x40002D6")]
			Pressed = 0,
			[Token(Token = "0x40002D7")]
			Released = 1,
			[Token(Token = "0x40002D8")]
			PressedAndReleased = 2,
			[Token(Token = "0x40002D9")]
			NotChanged = 3
		}

		[Token(Token = "0x40002B0")]
		[FieldOffset(Offset = "0x28")]
		private GameObject m_PointerPress;

		[Token(Token = "0x40002B7")]
		[FieldOffset(Offset = "0xF0")]
		public List<GameObject> hovered;

		[Token(Token = "0x17000191")]
		[field: Token(Token = "0x40002AF")]
		[field: FieldOffset(Offset = "0x20")]
		public GameObject pointerEnter
		{
			[Token(Token = "0x60005F6")]
			[Address(RVA = "0x184281C", Offset = "0x184281C", Length = "0x8")]
			get;
			[Token(Token = "0x60005F7")]
			[Address(RVA = "0x1842824", Offset = "0x1842824", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000192")]
		[field: Token(Token = "0x40002B1")]
		[field: FieldOffset(Offset = "0x30")]
		public GameObject lastPress
		{
			[Token(Token = "0x60005F8")]
			[Address(RVA = "0x184282C", Offset = "0x184282C", Length = "0x8")]
			get;
			[Token(Token = "0x60005F9")]
			[Address(RVA = "0x1842834", Offset = "0x1842834", Length = "0x8")]
			private set;
		}

		[Token(Token = "0x17000193")]
		[field: Token(Token = "0x40002B2")]
		[field: FieldOffset(Offset = "0x38")]
		public GameObject rawPointerPress
		{
			[Token(Token = "0x60005FA")]
			[Address(RVA = "0x184283C", Offset = "0x184283C", Length = "0x8")]
			get;
			[Token(Token = "0x60005FB")]
			[Address(RVA = "0x1842844", Offset = "0x1842844", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000194")]
		[field: Token(Token = "0x40002B3")]
		[field: FieldOffset(Offset = "0x40")]
		public GameObject pointerDrag
		{
			[Token(Token = "0x60005FC")]
			[Address(RVA = "0x184284C", Offset = "0x184284C", Length = "0x8")]
			get;
			[Token(Token = "0x60005FD")]
			[Address(RVA = "0x1842854", Offset = "0x1842854", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000195")]
		[field: Token(Token = "0x40002B4")]
		[field: FieldOffset(Offset = "0x48")]
		public GameObject pointerClick
		{
			[Token(Token = "0x60005FE")]
			[Address(RVA = "0x184285C", Offset = "0x184285C", Length = "0x8")]
			get;
			[Token(Token = "0x60005FF")]
			[Address(RVA = "0x1842864", Offset = "0x1842864", Length = "0x8")]
			set;
		}

		[Token(Token = "0x17000196")]
		[field: Token(Token = "0x40002B5")]
		[field: FieldOffset(Offset = "0x50")]
		public RaycastResult pointerCurrentRaycast
		{
			[Token(Token = "0x6000600")]
			[Address(RVA = "0x184286C", Offset = "0x184286C", Length = "0x10")]
			get;
			[Token(Token = "0x6000601")]
			[Address(RVA = "0x184287C", Offset = "0x184287C", Length = "0x18")]
			set;
		}

		[Token(Token = "0x17000197")]
		[field: Token(Token = "0x40002B6")]
		[field: FieldOffset(Offset = "0xA0")]
		public RaycastResult pointerPressRaycast
		{
			[Token(Token = "0x6000602")]
			[Address(RVA = "0x1842894", Offset = "0x1842894", Length = "0x10")]
			get;
			[Token(Token = "0x6000603")]
			[Address(RVA = "0x18428A4", Offset = "0x18428A4", Length = "0x18")]
			set;
		}

		[Token(Token = "0x17000198")]
		[field: Token(Token = "0x40002B8")]
		[field: FieldOffset(Offset = "0xF8")]
		public bool eligibleForClick
		{
			[Token(Token = "0x6000604")]
			[Address(RVA = "0x18428BC", Offset = "0x18428BC", Length = "0x8")]
			get;
			[Token(Token = "0x6000605")]
			[Address(RVA = "0x18428C4", Offset = "0x18428C4", Length = "0xC")]
			set;
		}

		[Token(Token = "0x17000199")]
		[field: Token(Token = "0x40002B9")]
		[field: FieldOffset(Offset = "0xFC")]
		public int displayIndex
		{
			[Token(Token = "0x6000606")]
			[Address(RVA = "0x18428D0", Offset = "0x18428D0", Length = "0x8")]
			get;
			[Token(Token = "0x6000607")]
			[Address(RVA = "0x18428D8", Offset = "0x18428D8", Length = "0x8")]
			set;
		}

		[Token(Token = "0x1700019A")]
		[field: Token(Token = "0x40002BA")]
		[field: FieldOffset(Offset = "0x100")]
		public int pointerId
		{
			[Token(Token = "0x6000608")]
			[Address(RVA = "0x18428E0", Offset = "0x18428E0", Length = "0x8")]
			get;
			[Token(Token = "0x6000609")]
			[Address(RVA = "0x18428E8", Offset = "0x18428E8", Length = "0x8")]
			set;
		}

		[Token(Token = "0x1700019B")]
		[field: Token(Token = "0x40002BB")]
		[field: FieldOffset(Offset = "0x104")]
		public Vector2 position
		{
			[Token(Token = "0x600060A")]
			[Address(RVA = "0x18428F0", Offset = "0x18428F0", Length = "0xC")]
			get;
			[Token(Token = "0x600060B")]
			[Address(RVA = "0x18428FC", Offset = "0x18428FC", Length = "0xC")]
			set;
		}

		[Token(Token = "0x1700019C")]
		[field: Token(Token = "0x40002BC")]
		[field: FieldOffset(Offset = "0x10C")]
		public Vector2 delta
		{
			[Token(Token = "0x600060C")]
			[Address(RVA = "0x1842908", Offset = "0x1842908", Length = "0xC")]
			get;
			[Token(Token = "0x600060D")]
			[Address(RVA = "0x1842914", Offset = "0x1842914", Length = "0xC")]
			set;
		}

		[Token(Token = "0x1700019D")]
		[field: Token(Token = "0x40002BD")]
		[field: FieldOffset(Offset = "0x114")]
		public Vector2 pressPosition
		{
			[Token(Token = "0x600060E")]
			[Address(RVA = "0x1842920", Offset = "0x1842920", Length = "0xC")]
			get;
			[Token(Token = "0x600060F")]
			[Address(RVA = "0x184292C", Offset = "0x184292C", Length = "0xC")]
			set;
		}

		[Obsolete("Use either pointerCurrentRaycast.worldPosition or pointerPressRaycast.worldPosition")]
		[Token(Token = "0x1700019E")]
		[field: Token(Token = "0x40002BE")]
		[field: FieldOffset(Offset = "0x11C")]
		public Vector3 worldPosition
		{
			[Token(Token = "0x6000610")]
			[Address(RVA = "0x1842938", Offset = "0x1842938", Length = "0x10")]
			get;
			[Token(Token = "0x6000611")]
			[Address(RVA = "0x1842948", Offset = "0x1842948", Length = "0x10")]
			set;
		}

		[Obsolete("Use either pointerCurrentRaycast.worldNormal or pointerPressRaycast.worldNormal")]
		[Token(Token = "0x1700019F")]
		[field: Token(Token = "0x40002BF")]
		[field: FieldOffset(Offset = "0x128")]
		public Vector3 worldNormal
		{
			[Token(Token = "0x6000612")]
			[Address(RVA = "0x1842958", Offset = "0x1842958", Length = "0x10")]
			get;
			[Token(Token = "0x6000613")]
			[Address(RVA = "0x1842968", Offset = "0x1842968", Length = "0x10")]
			set;
		}

		[Token(Token = "0x170001A0")]
		[field: Token(Token = "0x40002C0")]
		[field: FieldOffset(Offset = "0x134")]
		public float clickTime
		{
			[Token(Token = "0x6000614")]
			[Address(RVA = "0x1842978", Offset = "0x1842978", Length = "0x8")]
			get;
			[Token(Token = "0x6000615")]
			[Address(RVA = "0x1842980", Offset = "0x1842980", Length = "0x8")]
			set;
		}

		[Token(Token = "0x170001A1")]
		[field: Token(Token = "0x40002C1")]
		[field: FieldOffset(Offset = "0x138")]
		public int clickCount
		{
			[Token(Token = "0x6000616")]
			[Address(RVA = "0x1842988", Offset = "0x1842988", Length = "0x8")]
			get;
			[Token(Token = "0x6000617")]
			[Address(RVA = "0x1842990", Offset = "0x1842990", Length = "0x8")]
			set;
		}

		[Token(Token = "0x170001A2")]
		[field: Token(Token = "0x40002C2")]
		[field: FieldOffset(Offset = "0x13C")]
		public Vector2 scrollDelta
		{
			[Token(Token = "0x6000618")]
			[Address(RVA = "0x1842998", Offset = "0x1842998", Length = "0xC")]
			get;
			[Token(Token = "0x6000619")]
			[Address(RVA = "0x18429A4", Offset = "0x18429A4", Length = "0xC")]
			set;
		}

		[Token(Token = "0x170001A3")]
		[field: Token(Token = "0x40002C3")]
		[field: FieldOffset(Offset = "0x144")]
		public bool useDragThreshold
		{
			[Token(Token = "0x600061A")]
			[Address(RVA = "0x18429B0", Offset = "0x18429B0", Length = "0x8")]
			get;
			[Token(Token = "0x600061B")]
			[Address(RVA = "0x18429B8", Offset = "0x18429B8", Length = "0xC")]
			set;
		}

		[Token(Token = "0x170001A4")]
		[field: Token(Token = "0x40002C4")]
		[field: FieldOffset(Offset = "0x145")]
		public bool dragging
		{
			[Token(Token = "0x600061C")]
			[Address(RVA = "0x18429C4", Offset = "0x18429C4", Length = "0x8")]
			get;
			[Token(Token = "0x600061D")]
			[Address(RVA = "0x18429CC", Offset = "0x18429CC", Length = "0xC")]
			set;
		}

		[Token(Token = "0x170001A5")]
		[field: Token(Token = "0x40002C5")]
		[field: FieldOffset(Offset = "0x148")]
		public InputButton button
		{
			[Token(Token = "0x600061E")]
			[Address(RVA = "0x18429D8", Offset = "0x18429D8", Length = "0x8")]
			get;
			[Token(Token = "0x600061F")]
			[Address(RVA = "0x18429E0", Offset = "0x18429E0", Length = "0x8")]
			set;
		}

		[Token(Token = "0x170001A6")]
		[field: Token(Token = "0x40002C6")]
		[field: FieldOffset(Offset = "0x14C")]
		public float pressure
		{
			[Token(Token = "0x6000620")]
			[Address(RVA = "0x18429E8", Offset = "0x18429E8", Length = "0x8")]
			get;
			[Token(Token = "0x6000621")]
			[Address(RVA = "0x18429F0", Offset = "0x18429F0", Length = "0x8")]
			set;
		}

		[Token(Token = "0x170001A7")]
		[field: Token(Token = "0x40002C7")]
		[field: FieldOffset(Offset = "0x150")]
		public float tangentialPressure
		{
			[Token(Token = "0x6000622")]
			[Address(RVA = "0x18429F8", Offset = "0x18429F8", Length = "0x8")]
			get;
			[Token(Token = "0x6000623")]
			[Address(RVA = "0x1842A00", Offset = "0x1842A00", Length = "0x8")]
			set;
		}

		[Token(Token = "0x170001A8")]
		[field: Token(Token = "0x40002C8")]
		[field: FieldOffset(Offset = "0x154")]
		public float altitudeAngle
		{
			[Token(Token = "0x6000624")]
			[Address(RVA = "0x1842A08", Offset = "0x1842A08", Length = "0x8")]
			get;
			[Token(Token = "0x6000625")]
			[Address(RVA = "0x1842A10", Offset = "0x1842A10", Length = "0x8")]
			set;
		}

		[Token(Token = "0x170001A9")]
		[field: Token(Token = "0x40002C9")]
		[field: FieldOffset(Offset = "0x158")]
		public float azimuthAngle
		{
			[Token(Token = "0x6000626")]
			[Address(RVA = "0x1842A18", Offset = "0x1842A18", Length = "0x8")]
			get;
			[Token(Token = "0x6000627")]
			[Address(RVA = "0x1842A20", Offset = "0x1842A20", Length = "0x8")]
			set;
		}

		[Token(Token = "0x170001AA")]
		[field: Token(Token = "0x40002CA")]
		[field: FieldOffset(Offset = "0x15C")]
		public float twist
		{
			[Token(Token = "0x6000628")]
			[Address(RVA = "0x1842A28", Offset = "0x1842A28", Length = "0x8")]
			get;
			[Token(Token = "0x6000629")]
			[Address(RVA = "0x1842A30", Offset = "0x1842A30", Length = "0x8")]
			set;
		}

		[Token(Token = "0x170001AB")]
		[field: Token(Token = "0x40002CB")]
		[field: FieldOffset(Offset = "0x160")]
		public Vector2 tilt
		{
			[Token(Token = "0x600062A")]
			[Address(RVA = "0x1842A38", Offset = "0x1842A38", Length = "0xC")]
			get;
			[Token(Token = "0x600062B")]
			[Address(RVA = "0x1842A44", Offset = "0x1842A44", Length = "0xC")]
			set;
		}

		[Token(Token = "0x170001AC")]
		[field: Token(Token = "0x40002CC")]
		[field: FieldOffset(Offset = "0x168")]
		public PenStatus penStatus
		{
			[Token(Token = "0x600062C")]
			[Address(RVA = "0x1842A50", Offset = "0x1842A50", Length = "0x8")]
			get;
			[Token(Token = "0x600062D")]
			[Address(RVA = "0x1842A58", Offset = "0x1842A58", Length = "0x8")]
			set;
		}

		[Token(Token = "0x170001AD")]
		[field: Token(Token = "0x40002CD")]
		[field: FieldOffset(Offset = "0x16C")]
		public Vector2 radius
		{
			[Token(Token = "0x600062E")]
			[Address(RVA = "0x1842A60", Offset = "0x1842A60", Length = "0xC")]
			get;
			[Token(Token = "0x600062F")]
			[Address(RVA = "0x1842A6C", Offset = "0x1842A6C", Length = "0xC")]
			set;
		}

		[Token(Token = "0x170001AE")]
		[field: Token(Token = "0x40002CE")]
		[field: FieldOffset(Offset = "0x174")]
		public Vector2 radiusVariance
		{
			[Token(Token = "0x6000630")]
			[Address(RVA = "0x1842A78", Offset = "0x1842A78", Length = "0xC")]
			get;
			[Token(Token = "0x6000631")]
			[Address(RVA = "0x1842A84", Offset = "0x1842A84", Length = "0xC")]
			set;
		}

		[Token(Token = "0x170001AF")]
		[field: Token(Token = "0x40002CF")]
		[field: FieldOffset(Offset = "0x17C")]
		public bool fullyExited
		{
			[Token(Token = "0x6000632")]
			[Address(RVA = "0x1842A90", Offset = "0x1842A90", Length = "0x8")]
			get;
			[Token(Token = "0x6000633")]
			[Address(RVA = "0x1842A98", Offset = "0x1842A98", Length = "0xC")]
			set;
		}

		[Token(Token = "0x170001B0")]
		[field: Token(Token = "0x40002D0")]
		[field: FieldOffset(Offset = "0x17D")]
		public bool reentered
		{
			[Token(Token = "0x6000634")]
			[Address(RVA = "0x1842AA4", Offset = "0x1842AA4", Length = "0x8")]
			get;
			[Token(Token = "0x6000635")]
			[Address(RVA = "0x1842AAC", Offset = "0x1842AAC", Length = "0xC")]
			set;
		}

		[Token(Token = "0x170001B1")]
		public Camera enterEventCamera
		{
			[Token(Token = "0x6000639")]
			[Address(RVA = "0x1842C24", Offset = "0x1842C24", Length = "0x90")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170001B2")]
		public Camera pressEventCamera
		{
			[Token(Token = "0x600063A")]
			[Address(RVA = "0x1842CB4", Offset = "0x1842CB4", Length = "0x90")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170001B3")]
		public GameObject pointerPress
		{
			[Token(Token = "0x600063B")]
			[Address(RVA = "0x1842D44", Offset = "0x1842D44", Length = "0x8")]
			get
			{
				return null;
			}
			[Token(Token = "0x600063C")]
			[Address(RVA = "0x1842D4C", Offset = "0x1842D4C", Length = "0x7C")]
			set
			{
			}
		}

		[Token(Token = "0x6000636")]
		[Address(RVA = "0x1842AB8", Offset = "0x1842AB8", Length = "0x12C")]
		public PointerEventData(EventSystem eventSystem)
			: base(null)
		{
		}

		[Token(Token = "0x6000637")]
		[Address(RVA = "0x1842BE4", Offset = "0x1842BE4", Length = "0x20")]
		public bool IsPointerMoving()
		{
			return false;
		}

		[Token(Token = "0x6000638")]
		[Address(RVA = "0x1842C04", Offset = "0x1842C04", Length = "0x20")]
		public bool IsScrolling()
		{
			return false;
		}

		[Token(Token = "0x600063D")]
		[Address(RVA = "0x1842DC8", Offset = "0x1842DC8", Length = "0x738")]
		public override string ToString()
		{
			return null;
		}
	}
}
