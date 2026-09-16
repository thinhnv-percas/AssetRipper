using System.Collections.Generic;
using Cpp2ILInjected;

namespace UnityEngine.EventSystems
{
	[Token(Token = "0x200006C")]
	internal static class RaycasterManager
	{
		[Token(Token = "0x4000207")]
		private static readonly List<BaseRaycaster> s_Raycasters;

		[Token(Token = "0x60005E6")]
		[Address(RVA = "0xC4246C", Offset = "0xC4246C", Length = "0xD0")]
		public static void AddRaycaster(BaseRaycaster baseRaycaster)
		{
		}

		[Token(Token = "0x60005E7")]
		[Address(RVA = "0xC48E08", Offset = "0xC48E08", Length = "0x68")]
		public static List<BaseRaycaster> GetRaycasters()
		{
			return null;
		}

		[Token(Token = "0x60005E8")]
		[Address(RVA = "0xC425A0", Offset = "0xC425A0", Length = "0xD0")]
		public static void RemoveRaycasters(BaseRaycaster baseRaycaster)
		{
		}
	}
}
