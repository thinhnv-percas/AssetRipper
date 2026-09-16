using System.Collections.Generic;
using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Attribute(Type = typeof(AddComponentMenu), RVA = "0x727EE4", Offset = "0x727EE4")]
	[Attribute(Type = typeof(RequireComponent), RVA = "0x727EE4", Offset = "0x727EE4")]
	[Token(Token = "0x200006F")]
	public class PhysicsRaycaster : BaseRaycaster
	{
		[Token(Token = "0x20000C2")]
		private class RaycastHitComparer : IComparer<RaycastHit>
		{
			[Token(Token = "0x400030F")]
			public static RaycastHitComparer instance;

			[Token(Token = "0x60006B2")]
			[Address(RVA = "0xC46868", Offset = "0xC46868", Length = "0x44")]
			public int Compare(RaycastHit x, RaycastHit y)
			{
				return 0;
			}

			[Token(Token = "0x60006B3")]
			[Address(RVA = "0xC468AC", Offset = "0xC468AC", Length = "0x8")]
			public RaycastHitComparer()
			{
			}
		}

		[Token(Token = "0x400020A")]
		protected const int kNoEventMaskSet = -1;

		[Token(Token = "0x400020B")]
		[FieldOffset(Offset = "0x20")]
		protected Camera m_EventCamera;

		[SerializeField]
		[Token(Token = "0x400020C")]
		[FieldOffset(Offset = "0x28")]
		protected LayerMask m_EventMask;

		[SerializeField]
		[Token(Token = "0x400020D")]
		[FieldOffset(Offset = "0x2C")]
		protected int m_MaxRayIntersections;

		[Token(Token = "0x400020E")]
		[FieldOffset(Offset = "0x30")]
		protected int m_LastMaxRayIntersections;

		[Token(Token = "0x400020F")]
		[FieldOffset(Offset = "0x38")]
		private RaycastHit[] m_Hits;

		[Token(Token = "0x170001A2")]
		public override Camera eventCamera
		{
			[Token(Token = "0x60005F9")]
			[Address(RVA = "0xC46328", Offset = "0xC46328", Length = "0xA8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170001A3")]
		public virtual int depth
		{
			[Token(Token = "0x60005FA")]
			[Address(RVA = "0xC463D0", Offset = "0xC463D0", Length = "0xC0")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x170001A4")]
		public int finalEventMask
		{
			[Token(Token = "0x60005FB")]
			[Address(RVA = "0xC46254", Offset = "0xC46254", Length = "0xD4")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x170001A5")]
		public LayerMask eventMask
		{
			[Token(Token = "0x60005FC")]
			[Address(RVA = "0xC46490", Offset = "0xC46490", Length = "0x8")]
			get
			{
				return default(LayerMask);
			}
			[Token(Token = "0x60005FD")]
			[Address(RVA = "0xC46498", Offset = "0xC46498", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170001A6")]
		public int maxRayIntersections
		{
			[Token(Token = "0x60005FE")]
			[Address(RVA = "0xC464A0", Offset = "0xC464A0", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x60005FF")]
			[Address(RVA = "0xC464A8", Offset = "0xC464A8", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x60005F8")]
		[Address(RVA = "0xC459A0", Offset = "0xC459A0", Length = "0x34")]
		protected internal PhysicsRaycaster()
		{
		}

		[Token(Token = "0x6000600")]
		[Address(RVA = "0xC45EFC", Offset = "0xC45EFC", Length = "0x358")]
		protected bool ComputeRayAndDistance(PointerEventData eventData, ref Ray ray, ref float distanceToClipPlane)
		{
			return false;
		}

		[Token(Token = "0x6000601")]
		[Address(RVA = "0xC464B0", Offset = "0xC464B0", Length = "0x3B8")]
		public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList)
		{
		}
	}
}
