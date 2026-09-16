using System.Collections.Generic;
using Cpp2ILInjected;

namespace TMPro
{
	[Token(Token = "0x200002E")]
	internal static class TMP_ListPool<T>
	{
		[Token(Token = "0x4000190")]
		private static readonly TMP_ObjectPool<List<T>> s_ListPool;

		[Token(Token = "0x60002B7")]
		[Address(RVA = "0x11CC4B4", Offset = "0x11CC4B4", Length = "0x154")]
		public static List<T> Get()
		{
			return null;
		}

		[Token(Token = "0x60002B8")]
		[Address(RVA = "0x11CC608", Offset = "0x11CC608", Length = "0x15C")]
		public static void Release(List<T> toRelease)
		{
		}
	}
}
