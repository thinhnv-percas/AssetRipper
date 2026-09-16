using Cpp2ILInjected;

namespace TMPro
{
	[Token(Token = "0x2000008")]
	public interface ITextPreprocessor
	{
		[Token(Token = "0x6000013")]
		string PreprocessText(string text);
	}
}
