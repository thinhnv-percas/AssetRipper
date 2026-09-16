using System;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x200005F")]
	internal interface IAsyncWebUtil
	{
		[Token(Token = "0x600016B")]
		void Get(string url, Action<string> responseHandler, Action<string> errorHandler, int maxTimeoutInSeconds = 30);

		[Token(Token = "0x600016C")]
		void Post(string url, string body, Action<string> responseHandler, Action<string> errorHandler, int maxTimeoutInSeconds = 30);

		[Token(Token = "0x600016D")]
		void Schedule(Action a, int delayInSeconds);
	}
}
