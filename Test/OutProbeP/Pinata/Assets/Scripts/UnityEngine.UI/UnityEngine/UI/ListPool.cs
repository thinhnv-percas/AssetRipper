using System.Collections.Generic;
using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[Token(Token = "0x200003B")]
	internal static class ListPool<T>
	{
		[Token(Token = "0x400016A")]
		private static readonly ObjectPool<List<T>> s_ListPool;

		[Token(Token = "0x600045D")]
		[Address(RVA = "0x11DCEAC", Offset = "0x11DCEAC", Length = "0x84")]
		private static void Clear(List<T> l)
		{
		}

		[Token(Token = "0x600045E")]
		[Address(RVA = "0x11DCF30", Offset = "0x11DCF30", Length = "0x154")]
		public static List<T> Get()
		{
			return null;
		}

		[Token(Token = "0x600045F")]
		[Address(RVA = "0x11DD084", Offset = "0x11DD084", Length = "0x15C")]
		public static void Release(List<T> toRelease)
		{
		}
	}
}
