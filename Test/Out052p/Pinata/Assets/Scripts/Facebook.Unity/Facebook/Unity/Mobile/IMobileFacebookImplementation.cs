using Cpp2ILInjected;

namespace Facebook.Unity.Mobile
{
	[Token(Token = "0x200005F")]
	internal interface IMobileFacebookImplementation : IMobileFacebook, IFacebook, IMobileFacebookResultHandler, IFacebookResultHandler
	{
	}
}
