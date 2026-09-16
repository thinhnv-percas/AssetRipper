using Cpp2ILInjected;

namespace Facebook.Unity.Canvas
{
	[Token(Token = "0x2000075")]
	internal interface ICanvasFacebookResultHandler : IFacebookResultHandler
	{
		[Token(Token = "0x60002D9")]
		void OnPayComplete(ResultContainer resultContainer);

		[Token(Token = "0x60002DA")]
		void OnFacebookAuthResponseChange(ResultContainer resultContainer);

		[Token(Token = "0x60002DB")]
		void OnUrlResponse(string message);

		[Token(Token = "0x60002DC")]
		void OnHideUnity(bool hide);
	}
}
