using Cpp2ILInjected;

namespace TMPro
{
	[Token(Token = "0x200002C")]
	internal interface ITweenValue
	{
		[Token(Token = "0x1700002C")]
		bool ignoreTimeScale
		{
			[Token(Token = "0x6000149")]
			get;
		}

		[Token(Token = "0x1700002D")]
		float duration
		{
			[Token(Token = "0x600014A")]
			get;
		}

		[Token(Token = "0x6000148")]
		void TweenValue(float floatPercentage);

		[Token(Token = "0x600014B")]
		bool ValidTarget();
	}
}
