using Cpp2ILInjected;

namespace Facebook.Unity.Canvas
{
	[Token(Token = "0x2000073")]
	internal interface ICanvasFacebookCallbackHandler : IFacebookCallbackHandler
	{
		[Token(Token = "0x60002D5")]
		void OnPayComplete(string message);

		[Token(Token = "0x60002D6")]
		void OnFacebookAuthResponseChange(string message);

		[Token(Token = "0x60002D7")]
		void OnUrlResponse(string message);

		[Token(Token = "0x60002D8")]
		void OnHideUnity(bool hide);
	}
}
