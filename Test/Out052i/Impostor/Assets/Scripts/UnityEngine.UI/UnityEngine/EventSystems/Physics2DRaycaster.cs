using System.Collections.Generic;
using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[AddComponentMenu("Event/Physics 2D Raycaster")]
	[RequireComponent(typeof(Camera))]
	[Token(Token = "0x20000C5")]
	public class Physics2DRaycaster : PhysicsRaycaster
	{
		[Token(Token = "0x4000347")]
		[FieldOffset(Offset = "0x48")]
		private RaycastHit2D[] m_Hits;

		[Token(Token = "0x600074B")]
		[Address(RVA = "0x184D47C", Offset = "0x184D47C", Length = "0x28")]
		protected Physics2DRaycaster()
		{
		}

		[Token(Token = "0x600074C")]
		[Address(RVA = "0x184D4CC", Offset = "0x184D4CC", Length = "0x6EC")]
		public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList)
		{
		}
	}
}
