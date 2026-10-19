using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace ConnectedVoxelSystem.Runtime
{
	[Token(Token = "0x2000009")]
	public static class VertexRotationExtensions
	{
		[Token(Token = "0x6000034")]
		[Address(RVA = "0x3F2E0F8", Offset = "0x3F2E0F8", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = rotation * 0xFFFFFFFFC2B40000;\n\treturnVal1 = UnityEngine.Quaternion::AngleAxis(v10, axis);\n\treturn returnVal1;\n")]
		public static Quaternion ToQuaternion(this VertexRotation rotation, Vector3 axis)
		{
			float angle = (float)rotation * -90f;
			return Quaternion.AngleAxis(angle, axis);
		}
	}
}
