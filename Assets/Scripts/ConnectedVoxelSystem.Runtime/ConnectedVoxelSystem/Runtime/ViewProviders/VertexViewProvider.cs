using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.OptionalValueSystem;
using UnityEngine;

namespace ConnectedVoxelSystem.Runtime.ViewProviders
{
	[Serializable]
	[Token(Token = "0x2000015")]
	public class VertexViewProvider<T> : IVertexMeshProvider<T> where T : struct
	{
		[SerializeField]
		[Token(Token = "0x4000035")]
		[FieldOffset(Offset = "0x0")]
		private VertexView<T> m_view;

		[Token(Token = "0x6000060")]
		[Address(RVA = "0x6BAE8D8", Offset = "0x6BAE8D8", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = *([A4731E0]);\n\tv15 = Il2CppMethodInfo;\n\tv17 = this.m_view;\n\t*([v15 @ X1_v1 (Il2CppMethodInfo)+10])(v23, *([v15 @ X1_v1 (Il2CppMethodInfo)]), Il2CppMethodInfo, 0, &v17 @ stack_-20_v1 (ConnectedVoxelSystem.Runtime.VertexView`1<T>), &v21 @ stack_-30_v1 (Unco.OptionalValueSystem.Optional`1<ConnectedVoxelSystem.Runtime.VertexView`1<T>>), rearRight, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv39 = *([A4731E0]);\n\tv50 = *([v39 @ X9_v4]) != *([v7 @ X8_v2]);\n\tif (v50) goto L_0028;\n\treturn v21;\nL_0028:\n\treturnVal2 = 0x8BF5CF0(v21, v36, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn returnVal2;\n")]
		public Optional<VertexView<T>> Evaluate(VertexRotation rotation, Voxel<T> frontRight, Voxel<T> frontLeft, Voxel<T> rearLeft, Voxel<T> rearRight)
		{
			//IL_0010: Expected O, but got I
			//IL_003a: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj = 0;
			nint num = 0;
			VertexView<T> view = m_view;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v15 @ X1_v1 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj2 = 0;
			Optional<VertexView<T>> result = default(Optional<VertexView<T>>);
			if (obj2 == obj)
			{
				return result;
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5CF0");
			Optional<VertexView<T>> result2 = default(Optional<VertexView<T>>);
			return result2;
		}

		[Token(Token = "0x6000061")]
		[Address(RVA = "0x6BAE94C", Offset = "0x6BAE94C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public VertexViewProvider()
		{
		}
	}
}
