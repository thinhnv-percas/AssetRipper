using Cpp2ILInjected;

namespace Sirenix.OdinInspector
{
	[Token(Token = "0x2000015")]
	public enum InfoMessageType
	{
		[Token(Token = "0x4000032")]
		None = 0,
		[Token(Token = "0x4000033")]
		Info = 1,
		[Token(Token = "0x4000034")]
		Warning = 2,
		[Token(Token = "0x4000035")]
		Error = 3
	}
}
