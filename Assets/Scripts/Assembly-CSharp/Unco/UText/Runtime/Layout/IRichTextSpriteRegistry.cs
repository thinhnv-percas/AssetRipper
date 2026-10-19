using Cpp2ILInjected;
using Unco.UText.Runtime.Rendering;

namespace Unco.UText.Runtime.Layout
{
	[Token(Token = "0x20007BE")]
	public interface IRichTextSpriteRegistry
	{
		[Token(Token = "0x600208B")]
		bool TryResolveByName(string name, out int atlasIndex, out int entryIndex, out UTextSpriteAsset atlas);

		[Token(Token = "0x600208C")]
		bool TryResolveByIndex(string atlasName, int entryIndex, out int atlasIndex, out UTextSpriteAsset atlas);
	}
}
