using Cpp2ILInjected;
using Unco.UText.Runtime.Rendering;

namespace Unco.UText.Runtime.Layout
{
	[Token(Token = "0x20007BD")]
	public interface IRichTextStyleRegistry
	{
		[Token(Token = "0x600208A")]
		bool TryResolve(string name, out UTextStyle style);
	}
}
