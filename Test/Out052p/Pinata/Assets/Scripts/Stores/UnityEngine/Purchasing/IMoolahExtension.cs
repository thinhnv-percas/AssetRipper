using System;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x200001A")]
	public interface IMoolahExtension : IStoreExtension
	{
		[Token(Token = "0x600004B")]
		void RestoreTransactionID(Action<RestoreTransactionIDState> result);
	}
}
