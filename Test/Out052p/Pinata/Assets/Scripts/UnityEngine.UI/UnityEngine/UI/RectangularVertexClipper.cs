using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[Token(Token = "0x200000C")]
	internal class RectangularVertexClipper
	{
		[Token(Token = "0x4000022")]
		[FieldOffset(Offset = "0x10")]
		private readonly Vector3[] m_WorldCorners;

		[Token(Token = "0x4000023")]
		[FieldOffset(Offset = "0x18")]
		private readonly Vector3[] m_CanvasCorners;

		[Token(Token = "0x600004B")]
		[Address(RVA = "0xECBFCC", Offset = "0xECBFCC", Length = "0x190")]
		public Rect GetCanvasRect(RectTransform t, Canvas c)
		{
			return default(Rect);
		}

		[Token(Token = "0x600004C")]
		[Address(RVA = "0xECC250", Offset = "0xECC250", Length = "0x70")]
		public RectangularVertexClipper()
		{
		}
	}
}
