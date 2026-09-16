using Cpp2ILInjected;

namespace UnityEngine.Purchasing.Security
{
	[Token(Token = "0x2000002")]
	public class AppleTangle
	{
		[Token(Token = "0x4000001")]
		private static byte[] data;

		[Token(Token = "0x4000002")]
		private static int[] order;

		[Token(Token = "0x4000003")]
		private static int key;

		[Token(Token = "0x4000004")]
		public static readonly bool IsPopulated;

		[Token(Token = "0x6000001")]
		[Address(RVA = "0x16810F4", Offset = "0x16810F4", Length = "0xA4")]
		public static byte[] Data()
		{
			return null;
		}

		[Token(Token = "0x6000002")]
		[Address(RVA = "0x1681198", Offset = "0x1681198", Length = "0x8")]
		public AppleTangle()
		{
		}
	}
}
