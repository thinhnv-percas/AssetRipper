using Cpp2ILInjected;

namespace Facebook.Unity.Canvas
{
	[Token(Token = "0x2000074")]
	internal interface ICanvasFacebookImplementation : IPayFacebook, IFacebook, ICanvasFacebookResultHandler, IFacebookResultHandler
	{
	}
}
