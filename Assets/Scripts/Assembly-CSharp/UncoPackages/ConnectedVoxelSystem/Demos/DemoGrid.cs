using AssetRipperInjected;
using ConnectedVoxelSystem.Runtime;
using Cpp2ILInjected;

namespace UncoPackages.ConnectedVoxelSystem.Demos
{
	[Token(Token = "0x2000058")]
	public class DemoGrid : ConnectedVoxelGridComponent<DemoGridData>
	{
		[Token(Token = "0x6000123")]
		[Address(RVA = "0x3C6AE80", Offset = "0x3C6AE80", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\tConnectedVoxelSystem.Runtime.ConnectedVoxelGridComponent`1<UncoPackages.ConnectedVoxelSystem.Demos.DemoGridData>::.ctor(this);\n\treturn;\n")]
		public DemoGrid()
		{
		}
	}
}
