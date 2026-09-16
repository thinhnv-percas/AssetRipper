using System.IO;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile.Internal
{
	[Token(Token = "0x20000C7")]
	internal static class FileUtil
	{
		[Token(Token = "0x600073B")]
		[Address(RVA = "0xBF477C", Offset = "0xBF477C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = System.IO.File::ReadAllBytes(path);\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static byte[] ReadAllBytes(string path)
		{
			return File.ReadAllBytes(path);
		}

		[Token(Token = "0x600073C")]
		[Address(RVA = "0xBFB6EC", Offset = "0xBFB6EC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.IO.File::WriteAllBytes(path, bytes);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void WriteAllBytes(string path, byte[] bytes)
		{
			File.WriteAllBytes(path, bytes);
		}

		[Token(Token = "0x600073D")]
		[Address(RVA = "0xBFB6F4", Offset = "0xBFB6F4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.IO.File::WriteAllLines(path, lines);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void WriteAllLines(string path, string[] lines)
		{
			File.WriteAllLines(path, lines);
		}
	}
}
