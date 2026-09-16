using Cpp2ILInjected;
using UnityEngine.EventSystems;

namespace UnityEngine.UI
{
	[Token(Token = "0x200005B")]
	internal static class MultipleDisplayUtilities
	{
		[Token(Token = "0x6000364")]
		[Address(RVA = "0x182C4A4", Offset = "0x182C4A4", Length = "0x6C")]
		public static bool GetRelativeMousePositionForDrag(PointerEventData eventData, ref Vector2 position)
		{
			return false;
		}

		[Token(Token = "0x6000365")]
		[Address(RVA = "0x182C86C", Offset = "0x182C86C", Length = "0xC8")]
		internal static Vector3 GetRelativeMousePositionForRaycast(PointerEventData eventData)
		{
			return default(Vector3);
		}

		[Token(Token = "0x6000366")]
		[Address(RVA = "0x182C510", Offset = "0x182C510", Length = "0x35C")]
		public static Vector3 RelativeMouseAtScaled(Vector2 position, int displayIndex)
		{
			return default(Vector3);
		}
	}
}
