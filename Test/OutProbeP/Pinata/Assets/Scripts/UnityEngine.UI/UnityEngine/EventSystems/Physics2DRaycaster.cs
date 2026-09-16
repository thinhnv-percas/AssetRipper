using System.Collections.Generic;
using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Attribute(Type = typeof(AddComponentMenu), RVA = "0x727E5C", Offset = "0x727E5C")]
	[Attribute(Type = typeof(RequireComponent), RVA = "0x727E5C", Offset = "0x727E5C")]
	[Token(Token = "0x200006E")]
	public class Physics2DRaycaster : PhysicsRaycaster
	{
		[Token(Token = "0x4000209")]
		[FieldOffset(Offset = "0x40")]
		private RaycastHit2D[] m_Hits;

		[Token(Token = "0x60005F6")]
		[Address(RVA = "0xC4596C", Offset = "0xC4596C", Length = "0x34")]
		protected Physics2DRaycaster()
		{
		}

		[Token(Token = "0x60005F7")]
		[Address(RVA = "0xC459D4", Offset = "0xC459D4", Length = "0x528")]
		public override void Raycast(PointerEventData eventData, List<RaycastResult> resultAppendList)
		{
		}
	}
}
