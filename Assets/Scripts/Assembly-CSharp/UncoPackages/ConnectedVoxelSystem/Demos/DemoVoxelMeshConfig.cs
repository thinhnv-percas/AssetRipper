using AssetRipperInjected;
using ConnectedVoxelSystem.Runtime;
using Cpp2ILInjected;

namespace UncoPackages.ConnectedVoxelSystem.Demos
{
	[Token(Token = "0x200005A")]
	public class DemoVoxelMeshConfig : ConnectedVoxelMeshConfig<DemoGridData>
	{
		[Token(Token = "0x6000126")]
		[Address(RVA = "0x3C6AF34", Offset = "0x3C6AF34", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\tConnectedVoxelSystem.Runtime.ConnectedVoxelMeshConfig`1<UncoPackages.ConnectedVoxelSystem.Demos.DemoGridData>::.ctor(this);\n\treturn;\n")]
		public DemoVoxelMeshConfig()
		{
		}
	}
}
