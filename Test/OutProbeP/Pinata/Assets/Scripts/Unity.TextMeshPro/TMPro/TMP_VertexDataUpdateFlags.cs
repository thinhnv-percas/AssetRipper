using Cpp2ILInjected;

namespace TMPro
{
	[Token(Token = "0x2000062")]
	public enum TMP_VertexDataUpdateFlags
	{
		[Token(Token = "0x400041E")]
		None = 0,
		[Token(Token = "0x400041F")]
		Vertices = 1,
		[Token(Token = "0x4000420")]
		Uv0 = 2,
		[Token(Token = "0x4000421")]
		Uv2 = 4,
		[Token(Token = "0x4000422")]
		Uv4 = 8,
		[Token(Token = "0x4000423")]
		Colors32 = 16,
		[Token(Token = "0x4000424")]
		All = 255
	}
}
