using Cpp2ILInjected;

namespace TMPro
{
	[Token(Token = "0x2000017")]
	public enum TMP_VertexDataUpdateFlags
	{
		[Token(Token = "0x40000A4")]
		None = 0,
		[Token(Token = "0x40000A5")]
		Vertices = 1,
		[Token(Token = "0x40000A6")]
		Uv0 = 2,
		[Token(Token = "0x40000A7")]
		Uv2 = 4,
		[Token(Token = "0x40000A8")]
		Uv4 = 8,
		[Token(Token = "0x40000A9")]
		Colors32 = 16,
		[Token(Token = "0x40000AA")]
		All = 255
	}
}
