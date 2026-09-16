using Cpp2ILInjected;

namespace EasyMobile.Internal.Sharing
{
	[Token(Token = "0x20000D4")]
	internal interface ISharingClient
	{
		[Token(Token = "0x60007A0")]
		void ShareText(string text, string subject = "");

		[Token(Token = "0x60007A1")]
		void ShareURL(string url, string subject = "");

		[Token(Token = "0x60007A2")]
		void ShareImage(string imagePath, string message, string subject = "");
	}
}
