using AssetRipperInjected;
using ConnectedVoxelSystem.Runtime;
using Cpp2ILInjected;

namespace UncoPackages.ConnectedVoxelSystem.Demos
{
	[Token(Token = "0x2000059")]
	public class DemoVertexView : VertexView<DemoGridData>
	{
		[Token(Token = "0x6000124")]
		[Address(RVA = "0x3C6AED8", Offset = "0x3C6AED8", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn;\n")]
		public override void Initialize(Voxel<DemoGridData> frontRight, Voxel<DemoGridData> frontLeft, Voxel<DemoGridData> rearLeft, Voxel<DemoGridData> rearRight)
		{
		}

		[Token(Token = "0x6000125")]
		[Address(RVA = "0x3C6AEDC", Offset = "0x3C6AEDC", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\tConnectedVoxelSystem.Runtime.VertexView`1<UncoPackages.ConnectedVoxelSystem.Demos.DemoGridData>::.ctor(this);\n\treturn;\n")]
		public DemoVertexView()
		{
		}
	}
}
