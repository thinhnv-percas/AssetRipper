using Cpp2ILInjected;

namespace UnityEngine.UDP
{
	[Token(Token = "0x200001B")]
	internal class Utils
	{
		[Token(Token = "0x4000053")]
		public static int[] RETRY_WAIT_TIME = new int[6] { 0, 3, 10, 60, 180, 300 };
	}
}
