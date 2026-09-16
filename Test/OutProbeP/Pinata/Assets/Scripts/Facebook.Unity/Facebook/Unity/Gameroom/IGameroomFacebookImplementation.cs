using Cpp2ILInjected;

namespace Facebook.Unity.Gameroom
{
	[Token(Token = "0x2000052")]
	internal interface IGameroomFacebookImplementation : IPayFacebook, IFacebook, IFacebookResultHandler
	{
		[Token(Token = "0x60001D9")]
		bool HaveReceivedPipeResponse();

		[Token(Token = "0x60001DA")]
		string GetPipeResponse(string callbackId);
	}
}
