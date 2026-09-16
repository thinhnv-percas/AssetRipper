using Cpp2ILInjected;

namespace TMPro
{
	[Token(Token = "0x2000012")]
	internal interface ITweenValue
	{
		[Token(Token = "0x1700001F")]
		bool ignoreTimeScale
		{
			[Token(Token = "0x60000E7")]
			get;
		}

		[Token(Token = "0x17000020")]
		float duration
		{
			[Token(Token = "0x60000E8")]
			get;
		}

		[Token(Token = "0x60000E6")]
		void TweenValue(float floatPercentage);

		[Token(Token = "0x60000E9")]
		bool ValidTarget();
	}
}
