using Cpp2ILInjected;

namespace Facebook.Unity.Editor
{
	[Token(Token = "0x2000059")]
	internal interface IEditorWrapper
	{
		[Token(Token = "0x600021E")]
		void Init();

		[Token(Token = "0x600021F")]
		void ShowLoginMockDialog(Utilities.Callback<ResultContainer> callback, string callbackId, string permissions);

		[Token(Token = "0x6000220")]
		void ShowAppRequestMockDialog(Utilities.Callback<ResultContainer> callback, string callbackId);

		[Token(Token = "0x6000221")]
		void ShowPayMockDialog(Utilities.Callback<ResultContainer> callback, string callbackId);

		[Token(Token = "0x6000222")]
		void ShowMockShareDialog(Utilities.Callback<ResultContainer> callback, string subTitle, string callbackId);
	}
}
