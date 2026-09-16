using System.Collections.Generic;
using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[Token(Token = "0x200002B")]
	public class MaskUtilities
	{
		[Token(Token = "0x60002D9")]
		[Address(RVA = "0xEC89B4", Offset = "0xEC89B4", Length = "0x264")]
		public static void Notify2DMaskStateChanged(Component mask)
		{
		}

		[Token(Token = "0x60002DA")]
		[Address(RVA = "0xEC742C", Offset = "0xEC742C", Length = "0x260")]
		public static void NotifyStencilStateChanged(Component mask)
		{
		}

		[Token(Token = "0x60002DB")]
		[Address(RVA = "0xEC7CD4", Offset = "0xEC7CD4", Length = "0x180")]
		public static Transform FindRootSortOverrideCanvas(Transform start)
		{
			return null;
		}

		[Token(Token = "0x60002DC")]
		[Address(RVA = "0xEC7E54", Offset = "0xEC7E54", Length = "0x29C")]
		public static int GetStencilDepth(Transform transform, Transform stopAfter)
		{
			return 0;
		}

		[Token(Token = "0x60002DD")]
		[Address(RVA = "0xEC8C18", Offset = "0xEC8C18", Length = "0x184")]
		public static bool IsDescendantOrSelf(Transform father, Transform child)
		{
			return false;
		}

		[Token(Token = "0x60002DE")]
		[Address(RVA = "0xEC8D9C", Offset = "0xEC8D9C", Length = "0x3E8")]
		public static RectMask2D GetRectMaskForClippable(IClippable clippable)
		{
			return null;
		}

		[Token(Token = "0x60002DF")]
		[Address(RVA = "0xEC9184", Offset = "0xEC9184", Length = "0x2F8")]
		public static void GetRectMasksForClip(RectMask2D clipper, List<RectMask2D> masks)
		{
		}

		[Token(Token = "0x60002E0")]
		[Address(RVA = "0xEC947C", Offset = "0xEC947C", Length = "0x8")]
		public MaskUtilities()
		{
		}
	}
}
