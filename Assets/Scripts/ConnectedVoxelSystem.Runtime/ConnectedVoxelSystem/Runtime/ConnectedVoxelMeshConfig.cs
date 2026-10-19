using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unco.OptionalValueSystem;
using UnityEngine;

namespace ConnectedVoxelSystem.Runtime
{
	[Serializable]
	[Token(Token = "0x2000005")]
	public abstract class ConnectedVoxelMeshConfig<T> : ScriptableObject where T : struct
	{
		[SerializeField]
		[Token(Token = "0x400000B")]
		[FieldOffset(Offset = "0x0")]
		private VertexMeshRule<T>[] m_meshRules;

		[SerializeField]
		[Token(Token = "0x400000C")]
		[FieldOffset(Offset = "0x0")]
		private float m_voxelSize;

		[Token(Token = "0x17000006")]
		public float VoxelSize
		{
			[Token(Token = "0x6000020")]
			[Address(RVA = "0x71BD8C4", Offset = "0x71BD8C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.VoxelSize;\n")]
			get
			{
				return m_voxelSize;
			}
		}

		[Token(Token = "0x6000021")]
		[Address(RVA = "0x71BD8CC", Offset = "0x71BD8CC", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([rotation @ X5 (ConnectedVoxelSystem.Runtime.VertexRotation&)]) = 0;\n\tv31 = this.m_meshRules;\n\tv33 = this.m_meshRules == 0;\n\tif (v33) goto L_005E;\n\tv45 = v31.Length < 1;\n\tif (v45) goto L_004C;\n\tv72 = this.m_meshRules + 0x20;\n\tv142 = 0;\n\tv142 = v142 + 1;\n\tv105 = v142 < v31.Length;\n\tif (v105) goto L_002A;\nL_004C:\n\treturnVal2 = Unco.OptionalValueSystem.Optional`1<System.Object>::get_None();\n\tgoto L_0076;\nL_005E:\n\treturnVal1 = Unco.OptionalValueSystem.Optional`1<System.Object>::get_None();\n\treturn returnVal1;\nL_0064:\n\tv253 = Unco.OptionalValueSystem.Optional`1<System.Object>::get_Value(&v94 @ stack_-80_v4 (Unco.OptionalValueSystem.Optional`1<ConnectedVoxelSystem.Runtime.VertexView`1<T>>));\n\treturnVal2 = Unco.OptionalValueSystem.Optional`1<System.Object>::op_Implicit(v253);\nL_0076:\n\treturn returnVal2;\nL_002A:\n\tv127 = *([v72 @ X27_v5+v142 @ X26_v6 (System.Int32)*16]);\n\tv87 = frontRight & 0xFFFF;\n\tv80 = frontLeft & 0xFFFF;\n\tv78 = rearLeft & 0xFFFF;\n\tv76 = rearRight & 0xFFFF;\n\tv89 = ConnectedVoxelSystem.Runtime.VertexMeshRule`1<T>::TryGetVertexView(&v127 @ stack_-70_v5 (ConnectedVoxelSystem.Runtime.VertexMeshRule`1<T>), v87, v80, v78, v76, rotation);\n\tv94 = v89;\n\tv235 = v89 & 1;\n\tv236 = v235 == 0;\n\tv125 = ~v236;\n\tif (v125) goto L_0064;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Optional<VertexView<T>> GetMatchingVertexMesh(Voxel<T> frontRight, Voxel<T> frontLeft, Voxel<T> rearLeft, Voxel<T> rearRight, out VertexRotation rotation)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConnectedVoxelMeshConfig::GetMatchingVertexMesh");
			rotation = default;
			return default;
		}

		[Token(Token = "0x6000022")]
		[Address(RVA = "0x71BD9F4", Offset = "0x71BD9F4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n")]
		public ConnectedVoxelMeshConfig()
		{
		}
	}
}
