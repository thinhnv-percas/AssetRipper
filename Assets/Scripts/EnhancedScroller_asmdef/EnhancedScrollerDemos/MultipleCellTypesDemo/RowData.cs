using AssetRipperInjected;
using Cpp2ILInjected;

namespace EnhancedScrollerDemos.MultipleCellTypesDemo
{
	[Token(Token = "0x200007E")]
	public class RowData : Data
	{
		[Token(Token = "0x40001F9")]
		[FieldOffset(Offset = "0x10")]
		public string userName;

		[Token(Token = "0x40001FA")]
		[FieldOffset(Offset = "0x18")]
		public string userAvatarSpritePath;

		[Token(Token = "0x40001FB")]
		[FieldOffset(Offset = "0x20")]
		public ulong userHighScore;

		[Token(Token = "0x6000252")]
		[Address(RVA = "0x4031AB4", Offset = "0x4031AB4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public RowData()
		{
		}
	}
}
