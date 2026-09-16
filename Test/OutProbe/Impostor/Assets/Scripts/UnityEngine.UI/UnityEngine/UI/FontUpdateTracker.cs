using System.Collections.Generic;
using Cpp2ILInjected;

namespace UnityEngine.UI
{
	[Token(Token = "0x200001D")]
	public static class FontUpdateTracker
	{
		[Token(Token = "0x400006C")]
		private static Dictionary<Font, HashSet<Text>> m_Tracked;

		[Token(Token = "0x60000DF")]
		[Address(RVA = "0x16CB300", Offset = "0x16CB300", Length = "0x248")]
		public static void TrackText(Text t)
		{
		}

		[Token(Token = "0x60000E0")]
		[Address(RVA = "0x16CB548", Offset = "0x16CB548", Length = "0x1A4")]
		private static void RebuildForFont(Font f)
		{
		}

		[Token(Token = "0x60000E1")]
		[Address(RVA = "0x16CB6EC", Offset = "0x16CB6EC", Length = "0x208")]
		public static void UntrackText(Text t)
		{
		}
	}
}
