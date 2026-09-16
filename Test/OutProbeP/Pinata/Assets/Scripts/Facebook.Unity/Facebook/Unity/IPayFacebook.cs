using Cpp2ILInjected;

namespace Facebook.Unity
{
	[Token(Token = "0x200001D")]
	internal interface IPayFacebook
	{
		[Token(Token = "0x60000CD")]
		void Pay(string product, string action, int quantity, int? quantityMin, int? quantityMax, string requestId, string pricepointId, string testCurrency, FacebookDelegate<IPayResult> callback);
	}
}
