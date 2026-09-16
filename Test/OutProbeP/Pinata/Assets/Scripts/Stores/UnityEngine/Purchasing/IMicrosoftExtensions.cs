using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000084")]
	public interface IMicrosoftExtensions : IStoreExtension
	{
		[Token(Token = "0x6000222")]
		void RestoreTransactions();
	}
}
