using Cpp2ILInjected;

namespace UnityEngine.UI.CoroutineTween
{
	[Token(Token = "0x200008A")]
	internal interface ITweenValue
	{
		[Token(Token = "0x1700015C")]
		bool ignoreTimeScale
		{
			[Token(Token = "0x600055C")]
			get;
		}

		[Token(Token = "0x1700015D")]
		float duration
		{
			[Token(Token = "0x600055D")]
			get;
		}

		[Token(Token = "0x600055B")]
		void TweenValue(float floatPercentage);

		[Token(Token = "0x600055E")]
		bool ValidTarget();
	}
}
