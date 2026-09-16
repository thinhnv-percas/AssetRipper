using System;
using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[Token(Token = "0x2000052")]
	public static class LayoutUtility
	{
		[Token(Token = "0x600031D")]
		[Address(RVA = "0x18242F0", Offset = "0x18242F0", Length = "0xC")]
		public static float GetMinSize(RectTransform rect, int axis)
		{
			return 0f;
		}

		[Token(Token = "0x600031E")]
		[Address(RVA = "0x18242FC", Offset = "0x18242FC", Length = "0xC")]
		public static float GetPreferredSize(RectTransform rect, int axis)
		{
			return 0f;
		}

		[Token(Token = "0x600031F")]
		[Address(RVA = "0x1826D14", Offset = "0x1826D14", Length = "0xC")]
		public static float GetFlexibleSize(RectTransform rect, int axis)
		{
			return 0f;
		}

		[Token(Token = "0x6000320")]
		[Address(RVA = "0x1828FD8", Offset = "0x1828FD8", Length = "0xE8")]
		public static float GetMinWidth(RectTransform rect)
		{
			return 0f;
		}

		[Token(Token = "0x6000321")]
		[Address(RVA = "0x1829258", Offset = "0x1829258", Length = "0x198")]
		public static float GetPreferredWidth(RectTransform rect)
		{
			return 0f;
		}

		[Token(Token = "0x6000322")]
		[Address(RVA = "0x18294D8", Offset = "0x18294D8", Length = "0xE8")]
		public static float GetFlexibleWidth(RectTransform rect)
		{
			return 0f;
		}

		[Token(Token = "0x6000323")]
		[Address(RVA = "0x1828EF0", Offset = "0x1828EF0", Length = "0xE8")]
		public static float GetMinHeight(RectTransform rect)
		{
			return 0f;
		}

		[Token(Token = "0x6000324")]
		[Address(RVA = "0x18290C0", Offset = "0x18290C0", Length = "0x198")]
		public static float GetPreferredHeight(RectTransform rect)
		{
			return 0f;
		}

		[Token(Token = "0x6000325")]
		[Address(RVA = "0x18293F0", Offset = "0x18293F0", Length = "0xE8")]
		public static float GetFlexibleHeight(RectTransform rect)
		{
			return 0f;
		}

		[Token(Token = "0x6000326")]
		[Address(RVA = "0x18295C0", Offset = "0x18295C0", Length = "0x18")]
		public static float GetLayoutProperty(RectTransform rect, Func<ILayoutElement, float> property, float defaultValue)
		{
			return 0f;
		}

		[Token(Token = "0x6000327")]
		[Address(RVA = "0x18295D8", Offset = "0x18295D8", Length = "0x310")]
		public static float GetLayoutProperty(RectTransform rect, Func<ILayoutElement, float> property, float defaultValue, out ILayoutElement source)
		{
			source = null;
			return 0f;
		}
	}
}
