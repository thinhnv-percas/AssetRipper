using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;

namespace ConnectedVoxelSystem.Runtime
{
	[Token(Token = "0x2000004")]
	public abstract class ConnectedVoxelGridComponent<T> : MonoBehaviour where T : struct
	{
		[SerializeField]
		[Token(Token = "0x4000006")]
		[FieldOffset(Offset = "0x0")]
		private ConnectedVoxelMeshConfig<T> m_meshConfig;

		[SerializeField]
		[Token(Token = "0x4000007")]
		[FieldOffset(Offset = "0x0")]
		private GridBounds m_bounds;

		[Token(Token = "0x4000008")]
		[FieldOffset(Offset = "0x0")]
		private VoxelGrid<T> _voxelGrid;

		[Token(Token = "0x4000009")]
		[FieldOffset(Offset = "0x0")]
		private VertexGrid<T> _vertexGrid;

		[Token(Token = "0x400000A")]
		private const float AXIS_THICKNESS = 4f;

		[Token(Token = "0x17000001")]
		public VoxelGrid<T> VoxelGrid
		{
			[Token(Token = "0x6000003")]
			[Address(RVA = "0x71BB984", Offset = "0x71BB984", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.VoxelGrid;\n")]
			get
			{
				return _voxelGrid;
			}
		}

		[Token(Token = "0x17000002")]
		public VertexGrid<T> VertexGrid
		{
			[Token(Token = "0x6000004")]
			[Address(RVA = "0x71BB98C", Offset = "0x71BB98C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.VertexGrid;\n")]
			get
			{
				return _vertexGrid;
			}
		}

		[Token(Token = "0x17000003")]
		public GridBounds Bounds
		{
			[Token(Token = "0x6000005")]
			[Address(RVA = "0x71BB994", Offset = "0x71BB994", Length = "0x18")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnBuffer.m_alignment = this.m_bounds;\n\t*([returnBuffer @ X8 (ConnectedVoxelSystem.Runtime.GridBounds)+10]) = this.m_bounds.m_constantOffset.y;\n\t*([returnBuffer @ X8 (ConnectedVoxelSystem.Runtime.GridBounds)+20]) = this.m_bounds.Min.z;\n\treturn returnBuffer;\n")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ConnectedVoxelGridComponent::get_Bounds");
				return default;
			}
		}

		[Token(Token = "0x17000004")]
		public unsafe float3 Offset
		{
			[Token(Token = "0x6000006")]
			[Address(RVA = "0x71BB9AC", Offset = "0x71BB9AC", Length = "0x24")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.m_meshConfig;\n\tv4 = this + 0x28;\n\treturnVal1 = ConnectedVoxelSystem.Runtime.GridBounds::CalculateOffset(v4, v0.VoxelSize);\n\treturn returnVal1;\n")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ConnectedVoxelGridComponent::get_Offset");
				return default;
			}
		}

		[Token(Token = "0x17000005")]
		public float VoxelSize
		{
			[Token(Token = "0x6000007")]
			[Address(RVA = "0x71BB9D0", Offset = "0x71BB9D0", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.m_meshConfig;\n\treturn v0.VoxelSize;\n")]
			get
			{
				ConnectedVoxelMeshConfig<T> meshConfig = m_meshConfig;
				return meshConfig.VoxelSize;
			}
		}

		[Token(Token = "0x6000008")]
		[Address(RVA = "0x71BB9EC", Offset = "0x71BB9EC", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tConnectedVoxelSystem.Runtime.ConnectedVoxelGridComponent`1<T>::Initialize(this, size, 0);\n\treturn;\n")]
		public void Initialize(int3 size)
		{
			Initialize(size, default(Voxel<T>));
		}

		[Token(Token = "0x6000009")]
		[Address(RVA = "0x71BBA04", Offset = "0x71BBA04", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = outsideBoundsValue & 0xFF;\n\tv27 = ConnectedVoxelSystem.Runtime.Voxel`1<T>::From(v25);\n\tv32 = v27 & 0xFFFF;\n\tConnectedVoxelSystem.Runtime.ConnectedVoxelGridComponent`1<T>::Initialize(this, size, v32);\n\treturn;\n")]
		public void Initialize(int3 size, T outsideBoundsValue)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConnectedVoxelGridComponent::Initialize");
		}

		[Token(Token = "0x600000A")]
		[Address(RVA = "0x71BBA64", Offset = "0x71BBA64", Length = "0xC0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\nL_001D:\n\tv54 = new Il2CppClass<ConnectedVoxelSystem.Runtime.VoxelGrid`1<T>>();\n\tv59 = outsideBoundsValue & 0xFFFF;\n\tConnectedVoxelSystem.Runtime.VoxelGrid`1<T>::.ctor(v54, size, size.y, size.z, v59);\n\tthis.VoxelGrid = v54;\n\tv68 = this + 0x28;\n\tConnectedVoxelSystem.Runtime.GridBounds::InitializeFromSize(v68, size);\n\tConnectedVoxelSystem.Runtime.ConnectedVoxelGridComponent`1<T>::InitializeVertexGrid(this);\n\treturn;\n")]
		private unsafe void Initialize(int3 size, Voxel<T> outsideBoundsValue)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConnectedVoxelGridComponent::Initialize");
		}

		[Token(Token = "0x600000B")]
		[Address(RVA = "0x71BBB24", Offset = "0x71BBB24", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\nL_001C:\n\tv52 = System.Span`1<Unity.Mathematics.int3>::op_Implicit(positions);\n\tConnectedVoxelSystem.Runtime.ConnectedVoxelGridComponent`1<T>::InitializeFromPositions(this, v52, 0);\n\treturn;\n")]
		public void InitializeFromPositions(int3[] positions)
		{
			Span<int3> positions2 = positions;
			InitializeFromPositions(positions2, default(Voxel<T>));
		}

		[Token(Token = "0x600000C")]
		[Address(RVA = "0x71BBBB0", Offset = "0x71BBBB0", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tConnectedVoxelSystem.Runtime.ConnectedVoxelGridComponent`1<T>::InitializeFromPositions(this, positions, 0);\n\treturn;\n")]
		public void InitializeFromPositions(Span<int3> positions)
		{
			InitializeFromPositions(positions, default(Voxel<T>));
		}

		[Token(Token = "0x600000D")]
		[Address(RVA = "0x71BBBC4", Offset = "0x71BBBC4", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\treturn;\nL_001D:\n\tv53 = System.Span`1<Unity.Mathematics.int3>::op_Implicit(positions);\n\tv59 = outsideBoundsValue & 0xFF;\n\tv60 = ConnectedVoxelSystem.Runtime.Voxel`1<T>::From(v59);\n\tv64 = v60 & 0xFFFF;\n\tConnectedVoxelSystem.Runtime.ConnectedVoxelGridComponent`1<T>::InitializeFromPositions(this, v53, v64);\n")]
		public void InitializeFromPositions(int3[] positions, T outsideBoundsValue)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConnectedVoxelGridComponent::InitializeFromPositions");
		}

		[Token(Token = "0x600000E")]
		[Address(RVA = "0x71BBC68", Offset = "0x71BBC68", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = outsideBoundsValue & 0xFF;\n\tv27 = ConnectedVoxelSystem.Runtime.Voxel`1<T>::From(v25);\n\tv31 = v27 & 0xFFFF;\n\tConnectedVoxelSystem.Runtime.ConnectedVoxelGridComponent`1<T>::InitializeFromPositions(this, positions, v31);\n\treturn;\n")]
		public void InitializeFromPositions(Span<int3> positions, T outsideBoundsValue)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConnectedVoxelGridComponent::InitializeFromPositions");
		}

		[Token(Token = "0x600000F")]
		[Address(RVA = "0x71BBCC8", Offset = "0x71BBCC8", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv28 = this + 0x28;\n\tConnectedVoxelSystem.Runtime.GridBounds::InitializeFromPositions(v28, positions);\n\tv31 = this + 0x28;\n\tv33 = ConnectedVoxelSystem.Runtime.GridBounds::get_Size(v31);\n\tv35 = this + 0x28;\n\tv37 = ConnectedVoxelSystem.Runtime.GridBounds::get_Size(v35);\n\tv39 = this + 0x28;\n\tv41 = ConnectedVoxelSystem.Runtime.GridBounds::get_Size(v39);\n\tgoto L_0029;\nL_0029:\n\tv66 = new Il2CppClass<ConnectedVoxelSystem.Runtime.VoxelGrid`1<T>>();\n\tv71 = outsideBoundsValue & 0xFFFF;\n\tConnectedVoxelSystem.Runtime.VoxelGrid`1<T>::.ctor(v66, v33, v37.y, 0, v71);\n\tthis.VoxelGrid = v66;\n\tConnectedVoxelSystem.Runtime.ConnectedVoxelGridComponent`1<T>::InitializeVertexGrid(this);\n\treturn;\n")]
		private unsafe void InitializeFromPositions(Span<int3> positions, Voxel<T> outsideBoundsValue)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConnectedVoxelGridComponent::InitializeFromPositions");
		}

		[Token(Token = "0x6000010")]
		[Address(RVA = "0x71BBDA8", Offset = "0x71BBDA8", Length = "0xF0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv33 = this.VertexGrid == 0;\n\tif (v33) goto L_0019;\n\tConnectedVoxelSystem.Runtime.VertexGrid`1<T>::Dispose(this.VertexGrid);\nL_0019:\n\tv40 = this.m_meshConfig;\n\tv44 = this + 0x28;\n\tv46 = ConnectedVoxelSystem.Runtime.GridBounds::CalculateOffset(v44, v40.VoxelSize);\n\tv69 = UnityEngine.Component::get_transform(this);\n\tgoto L_0034;\nL_0034:\n\tv127 = new Il2CppClass<ConnectedVoxelSystem.Runtime.VertexGrid`1<T>>();\n\tConnectedVoxelSystem.Runtime.VertexGrid`1<T>::.ctor(v127, this.VoxelGrid, v40, v46, v69);\n\tthis.VertexGrid = v127;\n\treturn;\n")]
		private unsafe void InitializeVertexGrid()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConnectedVoxelGridComponent::InitializeVertexGrid");
		}

		[Token(Token = "0x6000011")]
		[Address(RVA = "0x71BBE98", Offset = "0x71BBE98", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.VoxelGrid == 0;\n\tif (v2) goto L_0008;\n\tConnectedVoxelSystem.Runtime.VoxelGrid`1<T>::SetVoxelDirty(this.VoxelGrid, x, y, z);\n\treturn;\nL_0008:\n\treturn;\n")]
		public void SetVoxelDirty(int x, int y, int z)
		{
			if (VoxelGrid != null)
			{
				VoxelGrid.SetVoxelDirty(x, y, z);
			}
		}

		[Token(Token = "0x6000012")]
		[Address(RVA = "0x71BBEB4", Offset = "0x71BBEB4", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.VoxelGrid == 0;\n\tif (v2) goto L_0009;\n\tv7 = voxelData & 0xFF;\n\tConnectedVoxelSystem.Runtime.VoxelGrid`1<T>::AddVoxel(this.VoxelGrid, x, y, z, v7);\n\treturn;\nL_0009:\n\treturn;\n")]
		public void AddVoxel(int x, int y, int z, T voxelData)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConnectedVoxelGridComponent::AddVoxel");
		}

		[Token(Token = "0x6000013")]
		[Address(RVA = "0x71BBED4", Offset = "0x71BBED4", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this.VoxelGrid == 0;\n\tif (v4) goto L_000D;\n\tv11 = voxelData & 0xFF;\n\tConnectedVoxelSystem.Runtime.VoxelGrid`1<T>::AddVoxel(this.VoxelGrid, pos, pos.y, pos.z, v11);\n\treturn;\nL_000D:\n\treturn;\n")]
		public void AddVoxel(int3 pos, T voxelData)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConnectedVoxelGridComponent::AddVoxel");
		}

		[Token(Token = "0x6000014")]
		[Address(RVA = "0x71BBF00", Offset = "0x71BBF00", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.VoxelGrid == 0;\n\tif (v2) goto L_0008;\n\tConnectedVoxelSystem.Runtime.VoxelGrid`1<T>::RemoveVoxel(this.VoxelGrid, x, y, z);\n\treturn;\nL_0008:\n\treturn;\n")]
		public void RemoveVoxel(int x, int y, int z)
		{
			if (VoxelGrid != null)
			{
				VoxelGrid.RemoveVoxel(x, y, z);
			}
		}

		[Token(Token = "0x6000015")]
		[Address(RVA = "0x71BBF1C", Offset = "0x71BBF1C", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this.VoxelGrid == 0;\n\tif (v4) goto L_000C;\n\tConnectedVoxelSystem.Runtime.VoxelGrid`1<T>::RemoveVoxel(this.VoxelGrid, pos, pos.y, pos.z);\n\treturn;\nL_000C:\n\treturn;\n")]
		public void RemoveVoxel(int3 pos)
		{
			if (VoxelGrid != null)
			{
				VoxelGrid.RemoveVoxel(pos.x, pos.y, pos.z);
			}
		}

		[Token(Token = "0x6000016")]
		[Address(RVA = "0x71BBF44", Offset = "0x71BBF44", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = this + 0x28;\n\treturnVal1 = ConnectedVoxelSystem.Runtime.GridBounds::WorldToGrid(v9, worldPos);\n\treturn returnVal1;\n")]
		public unsafe int3 WorldToGrid(int3 worldPos)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConnectedVoxelGridComponent::WorldToGrid");
			return default;
		}

		[Token(Token = "0x6000017")]
		[Address(RVA = "0x71BBF68", Offset = "0x71BBF68", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = this + 0x28;\n\treturnVal1 = ConnectedVoxelSystem.Runtime.GridBounds::GridToWorld(v9, gridPos);\n\treturn returnVal1;\n")]
		public unsafe int3 GridToWorld(int3 gridPos)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConnectedVoxelGridComponent::GridToWorld");
			return default;
		}

		[Token(Token = "0x6000018")]
		[Address(RVA = "0x71BBF8C", Offset = "0x71BBF8C", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.VoxelGrid == 0;\n\tif (v2) goto L_0008;\n\treturnVal2 = ConnectedVoxelSystem.Runtime.VoxelGrid`1<T>::GetVoxel(this.VoxelGrid, x, y, z);\n\treturn returnVal2;\nL_0008:\n\treturn this.VoxelGrid;\n")]
		public Voxel<T> GetVoxel(int x, int y, int z)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConnectedVoxelGridComponent::GetVoxel");
			return default;
		}

		[Token(Token = "0x6000019")]
		[Address(RVA = "0x71BBFA8", Offset = "0x71BBFA8", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv4 = this.VoxelGrid == 0;\n\tif (v4) goto L_000C;\n\treturnVal2 = ConnectedVoxelSystem.Runtime.VoxelGrid`1<T>::GetVoxel(this.VoxelGrid, pos, pos.y, pos.z);\n\treturn returnVal2;\nL_000C:\n\treturn this.VoxelGrid;\n")]
		public Voxel<T> GetVoxel(int3 pos)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConnectedVoxelGridComponent::GetVoxel");
			return default;
		}

		[Token(Token = "0x600001A")]
		[Address(RVA = "0x71BBFD0", Offset = "0x71BBFD0", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.VertexGrid == 0;\n\tif (v2) goto L_0008;\n\tConnectedVoxelSystem.Runtime.VertexGrid`1<T>::BeginBatch(this.VertexGrid);\n\treturn;\nL_0008:\n\treturn;\n")]
		public void BeginBatch()
		{
			if (VertexGrid != null)
			{
				VertexGrid.BeginBatch();
			}
		}

		[Token(Token = "0x600001B")]
		[Address(RVA = "0x71BBFEC", Offset = "0x71BBFEC", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.VertexGrid == 0;\n\tif (v2) goto L_0008;\n\tConnectedVoxelSystem.Runtime.VertexGrid`1<T>::EndBatch(this.VertexGrid);\n\treturn;\nL_0008:\n\treturn;\n")]
		public void EndBatch()
		{
			if (VertexGrid != null)
			{
				VertexGrid.EndBatch();
			}
		}

		[Token(Token = "0x600001C")]
		[Address(RVA = "0x71BC008", Offset = "0x71BC008", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = this.VertexGrid == 0;\n\tif (v2) goto L_0008;\n\tConnectedVoxelSystem.Runtime.VertexGrid`1<T>::Dispose(this.VertexGrid);\n\treturn;\nL_0008:\n\treturn;\n")]
		private void OnDestroy()
		{
			if (VertexGrid != null)
			{
				VertexGrid.Dispose();
			}
		}

		[Token(Token = "0x600001D")]
		[Address(RVA = "0x71BC024", Offset = "0x71BC024", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = this.VoxelGrid == 0;\n\tif (v13) goto L_0022;\n\tv18 = ConnectedVoxelSystem.Runtime.VoxelGrid`1<T>::get_Size(this.VoxelGrid);\n\tv23 = this.m_meshConfig;\n\tv24 = this.m_meshConfig == 0;\n\tif (v24) goto L_0024;\n\tv50 = this + 0x28;\n\tv40 = ConnectedVoxelSystem.Runtime.GridBounds::CalculateOffset(v50, v23.VoxelSize);\n\treturn;\nL_0022:\n\treturn;\nL_0024:\n\tv51 = this + 0x28;\n\tv42 = ConnectedVoxelSystem.Runtime.GridBounds::CalculateOffset(v51, 1f);\n\treturn;\n")]
		private unsafe void OnDrawGizmosSelected()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConnectedVoxelGridComponent::OnDrawGizmosSelected");
		}

		[Token(Token = "0x600001E")]
		[Address(RVA = "0x71BC090", Offset = "0x71BC090", Length = "0x44C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0043;\n\tv124 = size.y < 0;\n\tv125 = size.y == 0;\n\tv127 = size.y ^ size.y;\n\tv128 = size.y & v127;\n\tv129 = v128 < 0;\n\tv130 = v124 == v129;\n\tv131 = ~v125;\n\tv132 = v130 & v131;\n\tv133 = ~v132;\n\tif (v133) goto L_FFFFFFFF;\n\tv205 = size.z < 0;\n\tv204 = size.z == 0;\n\tv193 = size.z ^ size.z;\n\tv194 = size.z & v193;\n\tv200 = v194 < 0;\n\tgoto L_0077;\nL_FFFFFFFF:\n\tv200 = 0;\nL_FFFFFFFF:\n\tv204 = 1;\nL_FFFFFFFF:\n\tv205 = 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv387 = 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv432 = color.b;\n\tgoto L_00A2;\nL_0093:\n\tv387 = v387 + 1;\n\tv398 = v387 == size;\nL_FFFFFFFF:\n\t;\n\tif (v398) goto L_012D;\nL_00A2:\n\tv436 = offset + v387;\n\tv438 = v436 * voxelSize;\nL_FFFFFFFF:\n\tv476 = 0;\n\tgoto L_00B6;\nL_00A7:\n\tv476 = v476 + 1;\n\tv464 = v476 == size.y;\nL_FFFFFFFF:\n\t;\n\tif (v464) goto L_0093;\nL_00B6:\n\tv414 = v67 + v476;\n\tv382 = v414 * voxelSize;\nL_FFFFFFFF:\n\tv505 = 0;\nL_FFFFFFFF:\n\tv406 = voxelSize;\n\tgoto L_00DD;\nL_00BC:\n\tv605 = v64 + v505;\n\tv607 = v605 * voxelSize;\n\tv414 = v438 + v557;\n\tv406 = v382 + v557.y;\n\tv432 = v607 + v557.z;\n\t// 207 MakeStruct v563 @ AGG71BC270_1_v4 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v414 @ V0_v22 (System.Single), v406 @ V1_v17 (System.Single), v432 @ V2_v13 (System.Single)\n\tUnityEngine.Gizmos::DrawMesh(v95, v563, v591, v572.one);\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_00D2:\n\tv505 = v505 + 1;\n\tv515 = size.z == v505;\nL_FFFFFFFF:\n\t;\n\tif (v515) goto L_00A7;\nL_00DD:\n\tv536 = condition == 0;\n\tif (v536) goto L_00ED;\n\tv543 = System.Func`4<System.Int32, System.Int32, System.Int32, System.Boolean>::Invoke(condition, v387, v476, v505);\n\tv544 = v543 == 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\n\tif (v544) goto L_00D2;\nL_00ED:\n\tv557 = Unity.Mathematics.float3::op_Implicit(calculatedOffset);\n\tv591 = Unity.Mathematics.quaternion::op_Implicit(0);\n\tgoto L_00BC;\nL_0125:\n\t// 293 MakeStruct v186 @ AGG71BC340_0_v1 (UnityEngine.Color), typeof(UnityEngine.Color), color @ V4 (UnityEngine.Color), color.g (System.Single), color.b (System.Single), 1f\n\tUnityEngine.Gizmos::set_color(v186);\n\treturn;\nL_012D:\n\t// 301 MakeStruct v222 @ AGG71BC354_0_v1 (UnityEngine.Color), typeof(UnityEngine.Color), color @ V4 (UnityEngine.Color), color.g (System.Single), color.b (System.Single), 1f\n\tUnityEngine.Gizmos::set_color(v222);\n\tv617 = ~v209;\n\tif (v617) goto L_01C2;\nL_FFFFFFFF:\n\tv689 = 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\tv671 = color.b;\n\tgoto L_0144;\nL_0135:\n\tv689 = v689 + 1;\n\tv650 = v689 == size;\nL_FFFFFFFF:\n\t;\n\tif (v650) goto L_01C2;\nL_0144:\n\tv715 = offset + v689;\n\tv717 = v715 * voxelSize;\nL_FFFFFFFF:\n\tv756 = 0;\n\tgoto L_0158;\nL_0149:\n\tv756 = v756 + 1;\n\tv743 = v756 == size.y;\nL_FFFFFFFF:\n\t;\n\tif (v743) goto L_0135;\nL_0158:\n\tv658 = v67 + v756;\n\tv639 = v658 * voxelSize;\nL_FFFFFFFF:\n\tv784 = 0;\nL_FFFFFFFF:\n\tv654 = voxelSize;\n\tgoto L_017F;\nL_015E:\n\tv884 = v64 + v784;\n\tv886 = v884 * voxelSize;\n\tv658 = v717 + v836;\n\tv654 = v639 + v836.y;\n\tv671 = v886 + v836.z;\n\t// 369 MakeStruct v838 @ AGG71BC41C_1_v5 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v658 @ V0_v41 (System.Single), v654 @ V1_v34 (System.Single), v671 @ V2_v25 (System.Single)\n\tUnityEngine.Gizmos::DrawWireMesh(v95, v838, v870, v851.one);\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\nL_0174:\n\tv784 = v784 + 1;\n\tv794 = size.z == v784;\nL_FFFFFFFF:\n\t;\n\tif (v794) goto L_0149;\nL_017F:\n\tv815 = condition == 0;\n\tif (v815) goto L_018F;\n\tv822 = System.Func`4<System.Int32, System.Int32, System.Int32, System.Boolean>::Invoke(condition, v689, v756, v784);\n\tv823 = v822 == 0;\nL_FFFFFFFF:\n\t;\nL_FFFFFFFF:\n\t;\n\tif (v823) goto L_0174;\nL_018F:\n\tv836 = Unity.Mathematics.float3::op_Implicit(calculatedOffset);\n\tv870 = Unity.Mathematics.quaternion::op_Implicit(0);\n\tgoto L_015E;\nL_01C2:\n\treturn;\nL_0043:\n\tv95 = UnityEngine.Resources::GetBuiltinResource(\"Cube.fbx\");\n\t// 74 MakeStruct v105 @ AGG71BC168_0_v1 (UnityEngine.Color), typeof(UnityEngine.Color), color @ V4 (UnityEngine.Color), color.g (System.Single), color.b (System.Single), 0.5f\n\tUnityEngine.Gizmos::set_color(v105);\n\tv118 = size < 1;\n\tif (v118) goto L_0125;\nL_0077:\n\tv208 = v205 == v200;\n\tv138 = ~v204;\n\tv209 = v208 & v138;\n\tv142 = v209 != 1;\n\tif (v142) goto L_0125;\n")]
		private void DrawGrid(int3 size, float voxelSize, float3 calculatedOffset, Color color, Vector3 offset = default(Vector3), Func<int, int, int, bool> condition = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConnectedVoxelGridComponent::DrawGrid");
		}

		[Token(Token = "0x600001F")]
		[Address(RVA = "0x71BC4DC", Offset = "0x71BC4DC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n")]
		public ConnectedVoxelGridComponent()
		{
		}
	}
}
