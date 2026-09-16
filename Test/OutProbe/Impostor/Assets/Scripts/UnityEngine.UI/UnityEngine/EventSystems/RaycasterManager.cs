using System.Collections.Generic;
using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x20000C3")]
	public static class RaycasterManager
	{
		[Token(Token = "0x4000345")]
		private static readonly List<BaseRaycaster> s_Raycasters;

		[Token(Token = "0x600073B")]
		[Address(RVA = "0x184CF18", Offset = "0x184CF18", Length = "0x110")]
		internal static void AddRaycaster(BaseRaycaster baseRaycaster)
		{
		}

		[Token(Token = "0x600073C")]
		[Address(RVA = "0x184D028", Offset = "0x184D028", Length = "0x58")]
		public static List<BaseRaycaster> GetRaycasters()
		{
			return null;
		}

		[Token(Token = "0x600073D")]
		[Address(RVA = "0x184D080", Offset = "0x184D080", Length = "0xD0")]
		internal static void RemoveRaycasters(BaseRaycaster baseRaycaster)
		{
		}
	}
}
