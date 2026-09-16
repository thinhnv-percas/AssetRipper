using System;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x200002D")]
	public interface ISamsungAppsExtensions : IStoreExtension
	{
		[Token(Token = "0x60000A7")]
		void RestoreTransactions(Action<bool> callback);
	}
}
