using Cpp2ILInjected;

namespace Unco.RemoteManagementSystem
{
	[Token(Token = "0x2000011")]
	public enum CompressionAlgorithm
	{
		[Token(Token = "0x4000040")]
		GZip = 0,
		[Token(Token = "0x4000041")]
		Deflate = 1,
		[Token(Token = "0x4000042")]
		Brotli = 2
	}
}
