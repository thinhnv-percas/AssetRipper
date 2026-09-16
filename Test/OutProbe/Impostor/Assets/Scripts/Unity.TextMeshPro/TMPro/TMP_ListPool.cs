using System.Collections.Generic;
using Cpp2ILInjected;

namespace TMPro
{
	[Token(Token = "0x2000066")]
	internal static class TMP_ListPool<T>
	{
		[Token(Token = "0x40002DC")]
		private static readonly TMP_ObjectPool<List<T>> s_ListPool;

		[Token(Token = "0x6000388")]
		[Address(RVA = "0x116BC8C", Offset = "0x116BC8C", Length = "0x98")]
		public static List<T> Get()
		{
			return null;
		}

		[Token(Token = "0x6000389")]
		[Address(RVA = "0x116BD24", Offset = "0x116BD24", Length = "0xA8")]
		public static void Release(List<T> toRelease)
		{
		}
	}
}
