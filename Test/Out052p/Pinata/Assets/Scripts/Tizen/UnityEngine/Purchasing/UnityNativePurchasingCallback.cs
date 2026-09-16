using System.Runtime.InteropServices;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000002")]
	public delegate void UnityNativePurchasingCallback([In] string subject, [In] string payload, [In] string receipt, [In] string transactionId);
}
