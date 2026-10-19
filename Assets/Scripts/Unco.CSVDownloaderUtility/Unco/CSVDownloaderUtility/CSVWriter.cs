using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.CSVDownloaderUtility
{
	[Token(Token = "0x2000004")]
	public class CSVWriter
	{
		[Token(Token = "0x4000006")]
		private static string fileName = "";

		[Token(Token = "0x6000003")]
		[Address(RVA = "0x81A8754", Offset = "0x81A8754", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public static void DeleteLogs()
		{
		}

		[Token(Token = "0x6000004")]
		[Address(RVA = "0x81A8758", Offset = "0x81A8758", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public CSVWriter()
		{
		}
	}
}
