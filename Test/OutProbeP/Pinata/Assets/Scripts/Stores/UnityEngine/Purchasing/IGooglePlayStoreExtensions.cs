using System;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000029")]
	public interface IGooglePlayStoreExtensions : IStoreExtension
	{
		[Token(Token = "0x60000A1")]
		void RestoreTransactions(Action<bool> callback);
	}
}
