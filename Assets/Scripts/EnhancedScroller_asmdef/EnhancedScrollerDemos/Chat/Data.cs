using AssetRipperInjected;
using Cpp2ILInjected;

namespace EnhancedScrollerDemos.Chat
{
	[Token(Token = "0x2000023")]
	public class Data
	{
		[Token(Token = "0x2000024")]
		public enum CellType
		{
			[Token(Token = "0x40000E8")]
			Spacer = 0,
			[Token(Token = "0x40000E9")]
			MyText = 1,
			[Token(Token = "0x40000EA")]
			OtherText = 2
		}

		[Token(Token = "0x40000E4")]
		[FieldOffset(Offset = "0x10")]
		public CellType cellType;

		[Token(Token = "0x40000E5")]
		[FieldOffset(Offset = "0x18")]
		public string someText;

		[Token(Token = "0x40000E6")]
		[FieldOffset(Offset = "0x20")]
		public float cellSize;

		[Token(Token = "0x60000FA")]
		[Address(RVA = "0x4024234", Offset = "0x4024234", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public Data()
		{
		}
	}
}
