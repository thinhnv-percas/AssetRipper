using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Mathematics;

namespace ConnectedVoxelSystem.Runtime
{
	[Token(Token = "0x200000F")]
	public class VoxelGrid<T> where T : struct
	{
		[CompilerGenerated]
		[Token(Token = "0x4000025")]
		[FieldOffset(Offset = "0x0")]
		private Action<int3> OnVoxelChanged;

		[Token(Token = "0x4000026")]
		[FieldOffset(Offset = "0x0")]
		private readonly Voxel<T>[,,] _voxels;

		[Token(Token = "0x4000027")]
		[FieldOffset(Offset = "0x0")]
		private readonly int _sizeX;

		[Token(Token = "0x4000028")]
		[FieldOffset(Offset = "0x0")]
		private readonly int _sizeY;

		[Token(Token = "0x4000029")]
		[FieldOffset(Offset = "0x0")]
		private readonly int _sizeZ;

		[Token(Token = "0x400002A")]
		[FieldOffset(Offset = "0x0")]
		private readonly Voxel<T> _outsideBounds;

		[Token(Token = "0x1700000F")]
		public int3 Size
		{
			[Token(Token = "0x6000049")]
			[Address(RVA = "0x6BCE924", Offset = "0x6BCE924", Length = "0x10")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this._sizeX;\n")]
			get
			{
				//IL_0007: Expected O, but got I4
				return (int3)_sizeX;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x6000047")]
		[Address(RVA = "0x6BCE7BC", Offset = "0x6BCE7BC", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Combine(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`1<Unity.Mathematics.int3>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\tv49 = this + 0x10;\nL_FFFFFFFF:\n\tv87 = this.OnVoxelChanged;\n\tgoto L_002E;\nL_001F:\n\tv84 = 0x220BDA0(v49, v82, v87, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
		public void add_OnVoxelChanged(Action<int3> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VoxelGrid::add_OnVoxelChanged");
		}

		[CompilerGenerated]
		[Token(Token = "0x6000048")]
		[Address(RVA = "0x6BCE870", Offset = "0x6BCE870", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_FFFFFFFF:\n\tv82 = 0;\nL_002E:\n\tv92 = System.Delegate::Remove(v87, value);\n\tv93 = v92 == 0;\n\tif (v93) goto L_FFFFFFFF;\n\tv97 = 0x21C11D0(v92, System.Action`1<Unity.Mathematics.int3>, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv100 = v97 == 0;\n\tv101 = ~v100;\nL_FFFFFFFF:\n\tv82 = v97;\n\tif (v101) goto L_001F;\n\tthrow System.InvalidCastException;\nL_0045:\n\treturn;\nL_0019:\n\tv49 = this + 0x10;\nL_FFFFFFFF:\n\tv87 = this.OnVoxelChanged;\n\tgoto L_002E;\nL_001F:\n\tv84 = 0x220BDA0(v49, v82, v87, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tv70 = v84 == v87;\nL_FFFFFFFF:\n\tv87 = v84;\n\tif (v70) goto L_0045;\n")]
		public void remove_OnVoxelChanged(Action<int3> value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VoxelGrid::remove_OnVoxelChanged");
		}

		[Token(Token = "0x600004A")]
		[Address(RVA = "0x6BCE934", Offset = "0x6BCE934", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = *([A4731E0]);\n\tSystem.Object::.ctor(this);\n\tthis._sizeX = size;\n\tthis._sizeY = size.y;\n\tthis._sizeZ = size.z;\n\t*([this @ X0 (ConnectedVoxelSystem.Runtime.VoxelGrid`1<T>)+2C]) = 0;\n\tv36 = size;\n\tgoto L_002D;\nL_002D:\n\tv63 = 0x21C1134(Il2CppClass<ConnectedVoxelSystem.Runtime.Voxel`1<T>[3]>, &v36 @ stack_-60_v1 (Unity.Mathematics.int3), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tthis._voxels = v63;\n\tv70 = *([A4731E0]);\n\tv81 = *([v70 @ X9_v3]) != *([v25 @ X8_v2]);\n\tif (v81) goto L_004C;\n\treturn;\nL_004C:\n\tv90 = 0x8BF5CF0(clobbered_X0, v63, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\n")]
		public VoxelGrid(int3 size)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj = 0;
			_sizeX = size.x;
			_sizeY = size.y;
			_sizeZ = size.z;
			_ = 0;
			int3 int5 = size;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1134");
			Voxel<T>[,,] voxels = default(Voxel<T>[,,]);
			_voxels = voxels;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj2 = 0;
			if (obj2 != obj)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5CF0");
			}
		}

		[Token(Token = "0x600004B")]
		[Address(RVA = "0x6BCEA08", Offset = "0x6BCEA08", Length = "0xD0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv31 = *([A4731E0]);\n\tSystem.Object::.ctor(this);\n\tthis._sizeX = sizeX;\n\tthis._sizeY = sizeY;\n\tthis._sizeZ = sizeZ;\n\t*([this @ X0 (ConnectedVoxelSystem.Runtime.VoxelGrid`1<T>)+2C]) = outsideBounds;\n\tv37 = sizeX;\n\tgoto L_002B;\nL_002B:\n\tv62 = 0x21C1134(Il2CppClass<ConnectedVoxelSystem.Runtime.Voxel`1<T>[3]>, &v37 @ stack_-60_v1 (System.Int32), clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\tthis._voxels = v62;\n\tv69 = *([A4731E0]);\n\tv80 = *([v69 @ X9_v3]) != *([v31 @ X8_v2]);\n\tif (v80) goto L_004A;\n\treturn;\nL_004A:\n\tv89 = 0x8BF5CF0(clobbered_X0, v62, clobbered_X2, clobbered_X3, clobbered_X4, clobbered_X5, clobbered_X6, clobbered_X7, clobbered_V0, clobbered_V1, clobbered_V2, clobbered_V3, clobbered_V4, clobbered_V5, clobbered_V6, clobbered_V7);\n\treturn;\n")]
		public VoxelGrid(int sizeX, int sizeY, int sizeZ, Voxel<T> outsideBounds = default(Voxel<T>))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj = 0;
			_sizeX = sizeX;
			_sizeY = sizeY;
			_sizeZ = sizeZ;
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C1134");
			Voxel<T>[,,] voxels = default(Voxel<T>[,,]);
			_voxels = voxels;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [A4731E0]");
			object obj2 = 0;
			if (obj2 != obj)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF5CF0");
			}
		}

		[Token(Token = "0x600004C")]
		[Address(RVA = "0x6BCEAD8", Offset = "0x6BCEAD8", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = x & 0x80000000;\n\tv2 = v0 == 0;\n\tv3 = ~v2;\n\tif (v3) goto L_0040;\n\tv4 = y & 0x80000000;\n\tv6 = v4 == 0;\n\tv7 = ~v6;\n\tif (v7) goto L_0040;\n\tv10 = this._sizeX <= x;\n\tif (v10) goto L_0040;\n\tv92 = z & 0x80000000;\n\tv93 = v92 == 0;\n\tv60 = ~v93;\n\tif (v60) goto L_0040;\n\tv11 = this._sizeY <= y;\n\tif (v11) goto L_0040;\n\tv12 = this._sizeZ <= z;\n\tif (v12) goto L_0040;\n\tv61 = this.OnVoxelChanged == 0;\n\tif (v61) goto L_0040;\n\tv77 = x | y;\n\tSystem.Action`1<Unity.Mathematics.int3>::Invoke(this.OnVoxelChanged, v77);\n\treturn;\nL_0040:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void SetVoxelDirty(int x, int y, int z)
		{
			//IL_0012: Expected I4, but got I8
			//IL_004c: Expected I4, but got I8
			//IL_00a7: Expected I4, but got I8
			//IL_0149: Expected O, but got I4
			if ((int)(x & 0x80000000L) == 0 && (int)(y & 0x80000000L) == 0 && _sizeX > x && (int)(z & 0x80000000L) == 0 && _sizeY > y && _sizeZ > z && OnVoxelChanged != null)
			{
				int num = x | y;
				OnVoxelChanged((int3)num);
			}
		}

		[Token(Token = "0x600004D")]
		[Address(RVA = "0x6BCEB30", Offset = "0x6BCEB30", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = x & 0x80000000;\n\tv8 = v6 == 0;\n\tv9 = ~v8;\n\tif (v9) goto L_007F;\n\tv10 = y & 0x80000000;\n\tv12 = v10 == 0;\n\tv13 = ~v12;\n\tif (v13) goto L_007F;\n\tv36 = this._sizeX <= x;\n\tif (v36) goto L_007F;\n\tv149 = z & 0x80000000;\n\tv150 = v149 == 0;\n\tv95 = ~v150;\n\tif (v95) goto L_007F;\n\tv37 = this._sizeY <= y;\n\tif (v37) goto L_007F;\n\tv38 = this._sizeZ <= z;\n\tif (v38) goto L_007F;\n\tv144 = this._voxels;\n\tv157 = *([v144 @ X8_v5 (ConnectedVoxelSystem.Runtime.Voxel`1<T>[3])+10]);\n\tv24 = 1 | data;\n\tv209 = *([v157 @ X10_v3+10]) * x;\n\tv210 = y + v209;\n\tv211 = *([v157 @ X10_v3+20]) * v210;\n\tv30 = z + v211;\n\tv16 = v30 << 1;\n\tv212 = v144 + v16;\n\t*([v212 @ X8_v6+20]) = v24;\n\tv96 = this.OnVoxelChanged == 0;\n\tif (v96) goto L_007F;\n\tv115 = x | y;\n\tSystem.Action`1<Unity.Mathematics.int3>::Invoke(this.OnVoxelChanged, v115);\n\treturn;\nL_007F:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddVoxel(int x, int y, int z, T data)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VoxelGrid::AddVoxel");
		}

		[Token(Token = "0x600004E")]
		[Address(RVA = "0x6BCEBEC", Offset = "0x6BCEBEC", Length = "0xB8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = x & 0x80000000;\n\tv8 = v6 == 0;\n\tv9 = ~v8;\n\tif (v9) goto L_007E;\n\tv10 = y & 0x80000000;\n\tv12 = v10 == 0;\n\tv13 = ~v12;\n\tif (v13) goto L_007E;\n\tv33 = this._sizeX <= x;\n\tif (v33) goto L_007E;\n\tv146 = z & 0x80000000;\n\tv147 = v146 == 0;\n\tv92 = ~v147;\n\tif (v92) goto L_007E;\n\tv34 = this._sizeY <= y;\n\tif (v34) goto L_007E;\n\tv35 = this._sizeZ <= z;\n\tif (v35) goto L_007E;\n\tv141 = this._voxels;\n\tv154 = *([v141 @ X8_v5 (ConnectedVoxelSystem.Runtime.Voxel`1<T>[3])+10]);\n\tv205 = *([v154 @ X10_v3+10]) * x;\n\tv206 = y + v205;\n\tv27 = *([v154 @ X10_v3+20]) * v206;\n\tv207 = v27 << 1;\n\tv208 = v141 + v207;\n\tv16 = z << 1;\n\tv209 = v208 + v16;\n\t*([v209 @ X8_v7+20]) = 0;\n\tv93 = this.OnVoxelChanged == 0;\n\tif (v93) goto L_007E;\n\tv112 = x | y;\n\tSystem.Action`1<Unity.Mathematics.int3>::Invoke(this.OnVoxelChanged, v112);\n\treturn;\nL_007E:\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void RemoveVoxel(int x, int y, int z)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VoxelGrid::RemoveVoxel");
		}

		[Token(Token = "0x600004F")]
		[Address(RVA = "0x6BCECA4", Offset = "0x6BCECA4", Length = "0xA4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = x & 0x80000000;\n\tv8 = v6 == 0;\n\tv9 = ~v8;\n\tif (v9) goto L_0079;\n\tv10 = y & 0x80000000;\n\tv12 = v10 == 0;\n\tv13 = ~v12;\n\tif (v13) goto L_0079;\n\tv16 = this._sizeX <= x;\n\tif (v16) goto L_0079;\n\tv134 = z & 0x80000000;\n\tv136 = v134 == 0;\n\tv65 = ~v136;\n\tif (v65) goto L_0079;\n\tv17 = this._sizeY <= y;\n\tif (v17) goto L_0079;\n\tv18 = this._sizeZ <= z;\n\tif (v18) goto L_0079;\n\tv128 = this._voxels;\n\tv143 = *([v128 @ X8_v6 (ConnectedVoxelSystem.Runtime.Voxel`1<T>[3])+10]);\n\tv195 = *([v143 @ X10_v2+10]) * x;\n\tv196 = y + v195;\n\tv130 = *([v143 @ X10_v2+20]) * v196;\n\tv92 = z + v130;\n\tv80 = v92 << 1;\n\tv197 = v128 + v80;\n\tv127 = v197 + 0x20;\n\treturn *([v127 @ X8_v8]);\nL_0079:\n\treturn *([this @ X0 (ConnectedVoxelSystem.Runtime.VoxelGrid`1<T>)+2C]);\n")]
		public Voxel<T> GetVoxel(int x, int y, int z)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VoxelGrid::GetVoxel");
			return default;
		}

		[Token(Token = "0x6000050")]
		[Address(RVA = "0x6BCED48", Offset = "0x6BCED48", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = x & 0x80000000;\n\tv2 = v0 == 0;\n\tv3 = ~v2;\n\tif (v3) goto L_003B;\n\tv7 = y & 0x80000000;\n\tv9 = v7 == 0;\n\tv10 = ~v9;\n\treturnVal2 = 0;\n\tif (v10) goto L_0039;\n\tv24 = this._sizeX <= x;\n\treturnVal2 = 0;\n\tif (v24) goto L_0039;\n\tv89 = z & 0x80000000;\n\tv91 = v89 == 0;\n\tv73 = ~v91;\n\treturnVal2 = 0;\n\tif (v73) goto L_0039;\n\tv31 = this._sizeY <= y;\n\treturnVal2 = 0;\n\tif (v31) goto L_0039;\n\tv57 = this._sizeZ - z;\n\tv53 = v57 < 0;\n\tv49 = v57 == 0;\n\tv45 = this._sizeZ ^ z;\n\tv41 = this._sizeZ ^ v57;\n\tv37 = v45 & v41;\n\tv33 = v37 < 0;\n\tv96 = v53 == v33;\n\tv26 = ~v49;\n\tv29 = v96 & v26;\n\treturnVal2 = v29;\nL_003B:\n\treturn 0;\nL_0039:\n\treturn returnVal2;\n")]
		public bool IsInBounds(int x, int y, int z)
		{
			//IL_0012: Expected I4, but got I8
			//IL_004c: Expected I4, but got I8
			//IL_00b9: Expected I4, but got I8
			if ((int)(x & 0x80000000L) == 0)
			{
				int num = (int)(y & 0x80000000L);
				bool flag = num == 0;
				bool flag2 = !flag;
				bool result = false;
				if (!flag2)
				{
					bool flag3 = _sizeX <= x;
					result = false;
					if (!flag3)
					{
						int num2 = (int)(z & 0x80000000L);
						bool flag4 = num2 == 0;
						bool flag5 = !flag4;
						result = false;
						if (!flag5)
						{
							bool flag6 = _sizeY <= y;
							result = false;
							if (!flag6)
							{
								int num3 = _sizeZ - z;
								bool flag7 = num3 < 0;
								bool flag8 = num3 == 0;
								int num4 = _sizeZ ^ z;
								int num5 = _sizeZ ^ num3;
								int num6 = num4 & num5;
								bool flag9 = num6 < 0;
								bool flag10 = flag7 == flag9;
								bool flag11 = !flag8;
								bool flag12 = flag10 && flag11;
								result = flag12;
							}
						}
					}
				}
				return result;
			}
			return false;
		}
	}
}
