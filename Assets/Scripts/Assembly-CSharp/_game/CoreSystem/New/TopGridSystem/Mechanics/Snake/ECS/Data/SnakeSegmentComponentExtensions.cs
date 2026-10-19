using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.TopGridSystem.Mechanics.Snake.ECS.Data
{
	[Token(Token = "0x200017C")]
	public static class SnakeSegmentComponentExtensions
	{
		[Token(Token = "0x600072B")]
		[Address(RVA = "0x3E5F20C", Offset = "0x3E5F20C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = segment < 0;\n\tif (v11) goto L_FFFFFFFF;\n\tv31 = v13 < 0;\n\tv19 = v13 ^ v13;\n\tv20 = v13 & v19;\n\tv26 = v20 < 0;\n\tgoto L_001B;\nL_FFFFFFFF:\n\tv26 = 0;\nL_FFFFFFFF:\n\tv31 = 1;\nL_001B:\n\tv34 = v31 == v26;\n\tv35 = ~v34;\n\treturn v35;\n")]
		public static bool IsHead(this SnakeSegmentComponent segment)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SnakeSegmentComponentExtensions::IsHead");
			return default;
		}
	}
}
