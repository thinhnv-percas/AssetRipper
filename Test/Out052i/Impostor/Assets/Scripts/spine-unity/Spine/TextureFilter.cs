using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x200002C")]
	public enum TextureFilter
	{
		[Token(Token = "0x40000FA")]
		Nearest = 0,
		[Token(Token = "0x40000FB")]
		Linear = 1,
		[Token(Token = "0x40000FC")]
		MipMap = 2,
		[Token(Token = "0x40000FD")]
		MipMapNearestNearest = 3,
		[Token(Token = "0x40000FE")]
		MipMapLinearNearest = 4,
		[Token(Token = "0x40000FF")]
		MipMapNearestLinear = 5,
		[Token(Token = "0x4000100")]
		MipMapLinearLinear = 6
	}
}
