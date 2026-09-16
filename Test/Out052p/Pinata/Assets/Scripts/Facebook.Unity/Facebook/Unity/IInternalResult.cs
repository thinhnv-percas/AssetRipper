using Cpp2ILInjected;

namespace Facebook.Unity
{
	[Token(Token = "0x200002C")]
	internal interface IInternalResult : IResult
	{
		[Token(Token = "0x1700003E")]
		string CallbackId
		{
			[Token(Token = "0x60000FC")]
			get;
		}
	}
}
