using System;
using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[Token(Token = "0x2000027")]
	public static class LayoutUtility
	{
		[Token(Token = "0x60002AB")]
		[Address(RVA = "0xEC603C", Offset = "0xEC603C", Length = "0xC")]
		public static float GetMinSize(RectTransform rect, int axis)
		{
			return 0f;
		}

		[Token(Token = "0x60002AC")]
		[Address(RVA = "0xEC6238", Offset = "0xEC6238", Length = "0xC")]
		public static float GetPreferredSize(RectTransform rect, int axis)
		{
			return 0f;
		}

		[Token(Token = "0x60002AD")]
		[Address(RVA = "0xEC65EC", Offset = "0xEC65EC", Length = "0xC")]
		public static float GetFlexibleSize(RectTransform rect, int axis)
		{
			return 0f;
		}

		[Token(Token = "0x60002AE")]
		[Address(RVA = "0xEC6048", Offset = "0xEC6048", Length = "0xF8")]
		public static float GetMinWidth(RectTransform rect)
		{
			return 0f;
		}

		[Token(Token = "0x60002AF")]
		[Address(RVA = "0xEC6244", Offset = "0xEC6244", Length = "0x1D4")]
		public static float GetPreferredWidth(RectTransform rect)
		{
			return 0f;
		}

		[Token(Token = "0x60002B0")]
		[Address(RVA = "0xEC65F8", Offset = "0xEC65F8", Length = "0xF8")]
		public static float GetFlexibleWidth(RectTransform rect)
		{
			return 0f;
		}

		[Token(Token = "0x60002B1")]
		[Address(RVA = "0xEC6140", Offset = "0xEC6140", Length = "0xF8")]
		public static float GetMinHeight(RectTransform rect)
		{
			return 0f;
		}

		[Token(Token = "0x60002B2")]
		[Address(RVA = "0xEC6418", Offset = "0xEC6418", Length = "0x1D4")]
		public static float GetPreferredHeight(RectTransform rect)
		{
			return 0f;
		}

		[Token(Token = "0x60002B3")]
		[Address(RVA = "0xEC66F0", Offset = "0xEC66F0", Length = "0xF8")]
		public static float GetFlexibleHeight(RectTransform rect)
		{
			return 0f;
		}

		[Token(Token = "0x60002B4")]
		[Address(RVA = "0xEC67E8", Offset = "0xEC67E8", Length = "0x24")]
		public static float GetLayoutProperty(RectTransform rect, Func<ILayoutElement, float> property, float defaultValue)
		{
			return 0f;
		}

		[Token(Token = "0x60002B5")]
		[Address(RVA = "0xEC680C", Offset = "0xEC680C", Length = "0x2E8")]
		public static float GetLayoutProperty(RectTransform rect, Func<ILayoutElement, float> property, float defaultValue, out ILayoutElement source)
		{
			source = null;
			return 0f;
		}
	}
}
