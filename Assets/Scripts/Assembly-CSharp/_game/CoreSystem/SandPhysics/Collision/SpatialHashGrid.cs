using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace _game.CoreSystem.SandPhysics.Collision
{
	[Token(Token = "0x2000124")]
	public struct SpatialHashGrid : IDisposable
	{
		[Token(Token = "0x40003CC")]
		[FieldOffset(Offset = "0x0")]
		public NativeParallelMultiHashMap<int2, int> cellToParticles;

		[Token(Token = "0x40003CD")]
		[FieldOffset(Offset = "0x10")]
		public float cellSize;

		[Token(Token = "0x60005E6")]
		[Address(RVA = "0x3DB0314", Offset = "0x3DB0314", Length = "0xA0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\nL_001D:\n\tthis.cellSize = cellSize;\n\tv57 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(allocator);\n\tUnity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>::.ctor(&v63 @ stack_-60_v2 (Unity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>), capacity, v57);\n\tthis.cellToParticles = v63;\n\treturn;\n")]
		public SpatialHashGrid(int capacity, float cellSize, Allocator allocator)
		{
			this.cellSize = cellSize;
			AllocatorManager.AllocatorHandle allocator2 = allocator;
			NativeParallelMultiHashMap<int2, int> nativeParallelMultiHashMap = new NativeParallelMultiHashMap<int2, int>(capacity, allocator2);
			cellToParticles = nativeParallelMultiHashMap;
		}

		[Token(Token = "0x60005E7")]
		[Address(RVA = "0x3DB03B4", Offset = "0x3DB03B4", Length = "0x10C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\nL_001B:\n\tgoto L_001C;\nL_001C:\n\tv92 = this.cellSize;\n\tv63 = *([B193A95]) & 1;\n\tv64 = v63 == 0;\n\tif (v64) goto L_006D;\n\tgoto L_0024;\nL_0024:\n\tv105 = position.y / v92;\n\tv106 = position / this.cellSize;\n\tv107 = UnityEngine.Mathf::Floor(v106);\n\tv111 = UnityEngine.Mathf::Floor(v105);\n\tv129 = v105 << 0x20;\n\tv118 = v111 == 0x7F800000;\n\tv126 = ~v118;\n\tif (v126) goto L_003D;\nL_FFFFFFFF:\n\tv129 = 0x8000000000000000;\n\tgoto L_003D;\nL_FFFFFFFF:\n\tv142 = 0xFFFFFFFF80000000;\n\tgoto L_004B;\nL_FFFFFFFF:\n\tv142 = v106;\nL_006D:\n\t*([B193A95]) = 1;\nL_FFFFFFFF:\n\tv92 = v92;\n\tgoto L_0024;\nL_003D:\n\tv131 = v107 == 0x7F800000;\n\tv139 = ~v131;\n\tif (v139) goto L_FFFFFFFF;\nL_004B:\n\treturnVal1 = v129 | v142;\n\treturn returnVal1;\n")]
		public int2 GetCell(float2 position)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SpatialHashGrid::GetCell");
			return default;
		}

		[Token(Token = "0x60005E8")]
		[Address(RVA = "0x3DB04C0", Offset = "0x3DB04C0", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\tUnity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>::Clear(this);\n\treturn;\n")]
		public void Clear()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SpatialHashGrid::Clear");
		}

		[Token(Token = "0x60005E9")]
		[Address(RVA = "0x3DB0518", Offset = "0x3DB0518", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tUnity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>::Dispose(this);\n\treturn;\nL_0032:\n\treturn;\nL_001B:\n\tv47 = Unity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>::get_IsCreated(this);\n\tv50 = ~v47;\n\tif (v50) goto L_0032;\n")]
		public void Dispose()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SpatialHashGrid::Dispose");
		}
	}
}
