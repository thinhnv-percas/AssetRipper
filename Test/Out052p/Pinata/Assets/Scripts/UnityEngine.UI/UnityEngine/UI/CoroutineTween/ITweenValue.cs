using Cpp2ILInjected;

namespace UnityEngine.UI.CoroutineTween
{
	[Token(Token = "0x2000047")]
	internal interface ITweenValue
	{
		[Token(Token = "0x17000144")]
		bool ignoreTimeScale
		{
			[Token(Token = "0x60004AC")]
			get;
		}

		[Token(Token = "0x17000145")]
		float duration
		{
			[Token(Token = "0x60004AD")]
			get;
		}

		[Token(Token = "0x60004AB")]
		void TweenValue(float floatPercentage);

		[Token(Token = "0x60004AE")]
		bool ValidTarget();
	}
}
