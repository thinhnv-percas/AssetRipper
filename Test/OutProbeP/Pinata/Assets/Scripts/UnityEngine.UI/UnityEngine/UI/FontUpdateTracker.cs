using System.Collections.Generic;
using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[Token(Token = "0x2000010")]
	public static class FontUpdateTracker
	{
		[Token(Token = "0x4000049")]
		private static Dictionary<Font, HashSet<Text>> m_Tracked;

		[Token(Token = "0x60000AE")]
		[Address(RVA = "0xF44C30", Offset = "0xF44C30", Length = "0x210")]
		public static void TrackText(Text t)
		{
		}

		[Token(Token = "0x60000AF")]
		[Address(RVA = "0xF44E40", Offset = "0xF44E40", Length = "0x14C")]
		private static void RebuildForFont(Font f)
		{
		}

		[Token(Token = "0x60000B0")]
		[Address(RVA = "0xF44F8C", Offset = "0xF44F8C", Length = "0x1D4")]
		public static void UntrackText(Text t)
		{
		}
	}
}
