using System;
using Cpp2ILInjected;

namespace Unco.GameBootstrap.Core
{
	[Token(Token = "0x20007D1")]
	public interface ILoadTask
	{
		[Token(Token = "0x17000333")]
		float Progress
		{
			[Token(Token = "0x6002105")]
			get;
		}

		[Token(Token = "0x17000334")]
		bool IsComplete
		{
			[Token(Token = "0x6002106")]
			get;
		}

		[Token(Token = "0x14000030")]
		event Action<float> OnProgressChanged;

		[Token(Token = "0x14000031")]
		event Action OnComplete;
	}
}
