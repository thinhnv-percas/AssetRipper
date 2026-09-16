using Cpp2ILInjected;

namespace UnityEngine.Purchasing.Extension
{
	[Token(Token = "0x2000024")]
	public interface IPurchasingModule
	{
		[Token(Token = "0x60000AC")]
		void Configure(IPurchasingBinder binder);
	}
}
