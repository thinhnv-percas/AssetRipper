using AssetRipperInjected;
using Cpp2ILInjected;

namespace Unco.Notifications
{
	[Token(Token = "0x2000021")]
	internal class GameConstants
	{
		[Token(Token = "0x400007A")]
		public static string NOTIFICATION_SOURCE;

		[Token(Token = "0x60000EC")]
		[Address(RVA = "0x81BDFA8", Offset = "0x81BDFA8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public GameConstants()
		{
		}
	}
}
