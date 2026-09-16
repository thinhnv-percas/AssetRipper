using Cpp2ILInjected;

namespace Sirenix.OdinInspector
{
	[Token(Token = "0x200000E")]
	public enum InlineEditorModes
	{
		[Token(Token = "0x4000021")]
		GUIOnly = 0,
		[Token(Token = "0x4000022")]
		GUIAndHeader = 1,
		[Token(Token = "0x4000023")]
		GUIAndPreview = 2,
		[Token(Token = "0x4000024")]
		SmallPreview = 3,
		[Token(Token = "0x4000025")]
		LargePreview = 4,
		[Token(Token = "0x4000026")]
		FullEditor = 5
	}
}
