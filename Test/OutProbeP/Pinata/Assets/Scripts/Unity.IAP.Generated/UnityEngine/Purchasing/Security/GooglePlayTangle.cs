using Cpp2ILInjected;

namespace UnityEngine.Purchasing.Security
{
	[Token(Token = "0x2000003")]
	public class GooglePlayTangle
	{
		[Token(Token = "0x4000005")]
		private static byte[] data;

		[Token(Token = "0x4000006")]
		private static int[] order;

		[Token(Token = "0x4000007")]
		private static int key;

		[Token(Token = "0x4000008")]
		public static readonly bool IsPopulated;

		[Token(Token = "0x6000004")]
		[Address(RVA = "0x1681274", Offset = "0x1681274", Length = "0xA4")]
		public static byte[] Data()
		{
			return null;
		}

		[Token(Token = "0x6000005")]
		[Address(RVA = "0x1681318", Offset = "0x1681318", Length = "0x8")]
		public GooglePlayTangle()
		{
		}
	}
}
