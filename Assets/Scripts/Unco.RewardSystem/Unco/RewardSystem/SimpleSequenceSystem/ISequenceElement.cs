using System;
using Cpp2ILInjected;

namespace Unco.RewardSystem.SimpleSequenceSystem
{
	[Token(Token = "0x2000027")]
	public interface ISequenceElement
	{
		[Token(Token = "0x14000003")]
		event Action OnComplete;

		[Token(Token = "0x14000004")]
		event Action OnStart;

		[Token(Token = "0x600009E")]
		void Start();
	}
}
