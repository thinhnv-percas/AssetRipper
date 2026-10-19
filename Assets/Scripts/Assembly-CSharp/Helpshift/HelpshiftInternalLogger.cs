using Cpp2ILInjected;
using UnityEngine;

namespace Helpshift
{
	[Token(Token = "0x20007FE")]
	public class HelpshiftInternalLogger
	{
		[Token(Token = "0x4001AE2")]
		private static readonly string TAG = "HelpshiftUnityPlugin";

		[Token(Token = "0x60021E9")]
		[Address(RVA = "0x3DCCBC0", Offset = "0x3DCCBC0", Length = "0xF8")]
		public static void d(string message)
		{
			string message2 = "DEBUG: " + TAG + ": " + message;
			Debug.Log(message2);
		}

		[Token(Token = "0x60021EA")]
		[Address(RVA = "0x3DCCCB8", Offset = "0x3DCCCB8", Length = "0xF8")]
		public static void e(string message)
		{
			string message2 = "ERROR: " + TAG + ": " + message;
			Debug.Log(message2);
		}

		[Token(Token = "0x60021EB")]
		[Address(RVA = "0x3DCCDB0", Offset = "0x3DCCDB0", Length = "0xF8")]
		public static void w(string message)
		{
			string message2 = "WARN: " + TAG + ": " + message;
			Debug.Log(message2);
		}

		[Token(Token = "0x60021EC")]
		[Address(RVA = "0x3DCCEA8", Offset = "0x3DCCEA8", Length = "0x8")]
		public HelpshiftInternalLogger()
		{
		}
	}
}
