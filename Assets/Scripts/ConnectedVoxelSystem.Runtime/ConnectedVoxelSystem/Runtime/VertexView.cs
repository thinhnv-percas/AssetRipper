using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace ConnectedVoxelSystem.Runtime
{
	[Token(Token = "0x200000D")]
	public abstract class VertexView<T> : MonoBehaviour
	{
		[Token(Token = "0x6000044")]
		public abstract void Initialize(Voxel<T> frontRight, Voxel<T> frontLeft, Voxel<T> rearLeft, Voxel<T> rearRight);

		[Token(Token = "0x6000045")]
		[Address(RVA = "0x6BAE954", Offset = "0x6BAE954", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public VertexView()
		{
		}
	}
}
