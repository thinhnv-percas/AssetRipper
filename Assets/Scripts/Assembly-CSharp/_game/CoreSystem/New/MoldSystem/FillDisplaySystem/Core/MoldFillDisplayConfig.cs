using AssetRipperInjected;
using Cpp2ILInjected;
using TMPro;

namespace _game.CoreSystem.New.MoldSystem.FillDisplaySystem.Core
{
	[Token(Token = "0x20002D1")]
	public class MoldFillDisplayConfig
	{
		[Token(Token = "0x40008A7")]
		[FieldOffset(Offset = "0x10")]
		public TextMeshPro TextPrefab;

		[Token(Token = "0x40008A8")]
		[FieldOffset(Offset = "0x18")]
		public int StopFillFrameThreshold;

		[Token(Token = "0x6000C75")]
		[Address(RVA = "0x3ED6AE0", Offset = "0x3ED6AE0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public MoldFillDisplayConfig()
		{
		}
	}
}
