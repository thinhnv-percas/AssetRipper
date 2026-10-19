using Cpp2ILInjected;
using Unco.OptionalValueSystem;

namespace ConnectedVoxelSystem.Runtime
{
	[Token(Token = "0x2000007")]
	public interface IVertexMeshProvider<T> where T : struct
	{
		[Token(Token = "0x6000033")]
		Optional<VertexView<T>> Evaluate(VertexRotation rotation, Voxel<T> frontRight, Voxel<T> frontLeft, Voxel<T> rearLeft, Voxel<T> rearRight);
	}
}
