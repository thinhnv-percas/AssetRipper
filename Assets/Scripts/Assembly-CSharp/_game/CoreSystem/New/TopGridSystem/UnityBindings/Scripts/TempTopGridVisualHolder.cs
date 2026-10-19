using AssetRipperInjected;
using Cpp2ILInjected;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;

namespace _game.CoreSystem.New.TopGridSystem.UnityBindings.Scripts
{
	[Token(Token = "0x2000137")]
	public class TempTopGridVisualHolder
	{
		[Token(Token = "0x40003F6")]
		[FieldOffset(Offset = "0x10")]
		public TopGridVisualGridController Controller;

		[Token(Token = "0x40003F7")]
		[FieldOffset(Offset = "0x18")]
		public TopGridHandler GridHandler;

		[Token(Token = "0x600062F")]
		[Address(RVA = "0x3DB2CFC", Offset = "0x3DB2CFC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public TempTopGridVisualHolder()
		{
		}
	}
}
