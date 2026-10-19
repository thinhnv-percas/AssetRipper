using AssetRipperInjected;
using Cpp2ILInjected;

namespace Reflex.Utilities
{
	[Token(Token = "0x200000F")]
	internal static class ScriptingBackend
	{
		[Token(Token = "0x2000010")]
		internal enum Backend
		{
			[Token(Token = "0x4000018")]
			Undefined = 0,
			[Token(Token = "0x4000019")]
			Mono = 1,
			[Token(Token = "0x400001A")]
			IL2CPP = 2
		}

		[Token(Token = "0x17000007")]
		internal static Backend Current
		{
			[Token(Token = "0x600002F")]
			[Address(RVA = "0x3F30BCC", Offset = "0x3F30BCC", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn 2;\n")]
			get
			{
				return Backend.IL2CPP;
			}
		}
	}
}
