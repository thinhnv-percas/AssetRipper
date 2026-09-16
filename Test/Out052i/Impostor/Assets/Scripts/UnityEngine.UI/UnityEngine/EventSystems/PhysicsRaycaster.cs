using System.Collections.Generic;
using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[AddComponentMenu("Event/Physics Raycaster")]
	[RequireComponent(typeof(Camera))]
	[Token(Token = "0x20000C6")]
	public class PhysicsRaycaster : BaseRaycaster
	{
		[Token(Token = "0x20000C7")]
		private class RaycastHitComparer : IComparer<RaycastHit>
		{
			[Token(Token = "0x400034E")]
			public static RaycastHitComparer instance;

			[Token(Token = "0x6000757")]
			[Address(RVA = "0x184E530", Offset = "0x184E530", Length = "0x40")]
			public int Compare(RaycastHit x, RaycastHit y)
			{
				return 0;
			}

			[Token(Token = "0x6000758")]
			[Address(RVA = "0x184E570", Offset = "0x184E570", Length = "0x8")]
			public RaycastHitComparer()
			{
			}
		}

		[Token(Token = "0x4000348")]
		protected const int kNoEventMaskSet = -1;

		[Token(Token = "0x4000349")]
		[FieldOffset(Offset = "0x28")]
		protected Camera m_EventCamera;

		[SerializeField]
		[Token(Token = "0x400034A")]
		[FieldOffset(Offset = "0x30")]
		protected LayerMask m_EventMask;

		[SerializeField]
		[Token(Token = "0x400034B")]
		[FieldOffset(Offset = "0x34")]
		protected int m_MaxRayIntersections;

		[Token(Token = "0x400034C")]
		[FieldOffset(Offset = "0x38")]
		protected int m_LastMaxRayIntersections;

		[Token(Token = "0x400034D")]
		[FieldOffset(Offset = "0x40")]
		private RaycastHit[] m_Hits;

		[Token(Token = "0x170001F3")]
		public override Camera eventCamera
		{
			[Token(Token = "0x600074E")]
			[Address(RVA = "0x184DF78", Offset = "0x184DF78", Length = "0xD0")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x170001F4")]
		public virtual int depth
		{
			[Token(Token = "0x600074F")]
			[Address(RVA = "0x184E048", Offset = "0x184E048", Length = "0xC4")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x170001F5")]
		public int finalEventMask
		{
			[Token(Token = "0x6000750")]
			[Address(RVA = "0x184DEB4", Offset = "0x184DEB4", Length = "0xC4")]
			get
			{
				return 0;
			}
		}

		[Token(Token = "0x170001F6")]
		public LayerMask eventMask
		{
			[Token(Token = "0x6000751")]
			[Address(RVA = "0x184E10C", Offset = "0x184E10C", Length = "0x8")]
			get
			{
				return default(LayerMask);
			}
			[Token(Token = "0x6000752")]
			[Address(RVA = "0x184E114", Offset = "0x184E114", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x170001F7")]
		public int maxRayIntersections
		{
			[Token(Token = "0x6000753")]
			[Address(RVA = "0x184E11C", Offset = "0x184E11C", Length = "0x8")]
			get
			{
				return 0;
			}
			[Token(Token = "0x6000754")]
			[Address(RVA = "0x184E124", Offset = "0x184E124", Length = "0x8")]
			set
			{
			}
		}

		[Token(Token = "0x600074D")]
		[Address(RVA = "0x184D4A4", Offset = "0x184D4A4", Length = "0x28")]
		protected internal PhysicsRaycaster()
		{
		}

		[Token(Token = "0x6000755")]
		[Address(RVA = "0x184DBB8", Offset = "0x184DBB8", Length = "0x2FC")]
		protected bool ComputeRayAndDistance(PointerEventData eventData, ref Ray ray, ref int eventDisplayIndex, ref float distanceToClipPlane)
		{
			return false;
		}

		[Token(Token = "0x6000756")]
		[Address(RVA = "0x184E12C", Offset = "0x184E12C", Length = "0x404")]
		public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList)
		{
		}
	}
}
