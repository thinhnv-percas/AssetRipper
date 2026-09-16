using System.Collections.Generic;
using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[Token(Token = "0x2000058")]
	public class MaskUtilities
	{
		[Token(Token = "0x6000359")]
		[Address(RVA = "0x182BB98", Offset = "0x182BB98", Length = "0x25C")]
		public static void Notify2DMaskStateChanged(Component mask)
		{
		}

		[Token(Token = "0x600035A")]
		[Address(RVA = "0x182A220", Offset = "0x182A220", Length = "0x258")]
		public static void NotifyStencilStateChanged(Component mask)
		{
		}

		[Token(Token = "0x600035B")]
		[Address(RVA = "0x182A97C", Offset = "0x182A97C", Length = "0x1A0")]
		public static Transform FindRootSortOverrideCanvas(Transform start)
		{
			return null;
		}

		[Token(Token = "0x600035C")]
		[Address(RVA = "0x182AB1C", Offset = "0x182AB1C", Length = "0x288")]
		public static int GetStencilDepth(Transform transform, Transform stopAfter)
		{
			return 0;
		}

		[Token(Token = "0x600035D")]
		[Address(RVA = "0x182BDF4", Offset = "0x182BDF4", Length = "0x158")]
		public static bool IsDescendantOrSelf(Transform father, Transform child)
		{
			return false;
		}

		[Token(Token = "0x600035E")]
		[Address(RVA = "0x182B5F8", Offset = "0x182B5F8", Length = "0x414")]
		public static RectMask2D GetRectMaskForClippable(IClippable clippable)
		{
			return null;
		}

		[Token(Token = "0x600035F")]
		[Address(RVA = "0x182BF4C", Offset = "0x182BF4C", Length = "0x360")]
		public static void GetRectMasksForClip(RectMask2D clipper, List<RectMask2D> masks)
		{
		}

		[Token(Token = "0x6000360")]
		[Address(RVA = "0x182C2AC", Offset = "0x182C2AC", Length = "0x8")]
		public MaskUtilities()
		{
		}
	}
}
