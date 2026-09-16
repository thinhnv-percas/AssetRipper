using System.Collections.Generic;
using Cpp2ILInjected;

namespace GoogleMobileAds.Common
{
	[Token(Token = "0x2000026")]
	public interface ICustomNativeTemplateClient
	{
		[Token(Token = "0x60001C7")]
		string GetTemplateId();

		[Token(Token = "0x60001C8")]
		byte[] GetImageByteArray(string key);

		[Token(Token = "0x60001C9")]
		List<string> GetAvailableAssetNames();

		[Token(Token = "0x60001CA")]
		string GetText(string key);

		[Token(Token = "0x60001CB")]
		void PerformClick(string assetName);

		[Token(Token = "0x60001CC")]
		void RecordImpression();
	}
}
