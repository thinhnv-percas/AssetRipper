using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace _game.CoreSystem.SandPhysics
{
	[Token(Token = "0x20000A5")]
	public class SandPhysicsBuffers : IDisposable
	{
		[Token(Token = "0x20000A6")]
		public struct BuildSpatialHashJob : IJobParallelFor
		{
			[ReadOnly]
			[Token(Token = "0x40001DC")]
			[FieldOffset(Offset = "0x0")]
			public NativeArray<float2> positions;

			[ReadOnly]
			[Token(Token = "0x40001DD")]
			[FieldOffset(Offset = "0x10")]
			public NativeArray<bool> ghosted;

			[Token(Token = "0x40001DE")]
			[FieldOffset(Offset = "0x20")]
			public float cellSize;

			[Token(Token = "0x40001DF")]
			[FieldOffset(Offset = "0x28")]
			public NativeParallelMultiHashMap<int2, int>.ParallelWriter grid;

			[ReadOnly]
			[Token(Token = "0x40001E0")]
			[FieldOffset(Offset = "0x38")]
			public int count;

			[Token(Token = "0x60002A2")]
			[Address(RVA = "0x3C7B1D0", Offset = "0x3C7B1D0", Length = "0x1AC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0027;\n\tv68 = this.ghosted;\n\tv71 = *([v68 @ X8_v5 (Unity.Collections.NativeArray`1<System.Boolean>)+i @ X1 (System.Int32)]) & 1;\n\tv72 = v71 == 0;\n\tif (v72) goto L_003D;\nL_003C:\n\treturn;\nL_003D:\n\tv88 = this.positions;\n\tv89 = i << 3;\n\tv92 = 0xB193000;\n\tgoto L_004B;\nL_004B:\n\tgoto L_004D;\nL_004D:\n\tv180 = i << 3;\n\tv181 = this.positions + v180;\n\tv201 = *([v88 @ X8_v7 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>)+v89 @ X9_v1 (System.Int32)]) / this.cellSize;\n\tv185 = *([B193A95]) & 1;\n\tv186 = v185 == 0;\n\tif (v186) goto L_00AE;\n\tv236 = UnityEngine.Mathf::Floor(v201);\n\tv238 = *([v181 @ X9_v17+4]) / this.cellSize;\n\tgoto L_005B;\nL_005B:\n\tv128 = UnityEngine.Mathf::Floor(v238);\n\tv134 = v238 << 0x20;\n\tv256 = v128 == 0x7F800000;\n\tv264 = ~v256;\n\tif (v264) goto L_0071;\nL_FFFFFFFF:\n\tv134 = 0x8000000000000000;\n\tgoto L_0071;\nL_FFFFFFFF:\n\tv156 = 0xFFFFFFFF80000000;\n\tgoto L_0082;\nL_FFFFFFFF:\n\tv156 = v236;\nL_00AE:\n\t*([v92 @ X22_v2+A95]) = 1;\n\tv236 = UnityEngine.Mathf::Floor(v201);\n\tv238 = *([v181 @ X9_v17+4]) / this.cellSize;\n\tgoto L_005B;\nL_0027:\n\tv67 = this.count <= i;\n\tif (v67) goto L_003C;\nL_0071:\n\tv119 = v236 == 0x7F800000;\n\tv109 = ~v119;\n\tif (v109) goto L_FFFFFFFF;\nL_0082:\n\t;\n\tv101 = v134 | v156;\n\tUnity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>+ParallelWriter<Unity.Mathematics.int2, System.Int32>::Add(&this.grid (Unity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>+ParallelWriter<Unity.Mathematics.int2, System.Int32>), v101, i);\n\treturn;\n")]
			public void Execute(int i)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("SandPhysicsBuffers.BuildSpatialHashJob::Execute");
			}
		}

		[Token(Token = "0x40001C4")]
		[FieldOffset(Offset = "0x10")]
		public NativeArray<float2> Positions;

		[Token(Token = "0x40001C5")]
		[FieldOffset(Offset = "0x20")]
		public NativeArray<float2> Velocities;

		[Token(Token = "0x40001C6")]
		[FieldOffset(Offset = "0x30")]
		public NativeArray<float> Radii;

		[Token(Token = "0x40001C7")]
		[FieldOffset(Offset = "0x40")]
		public NativeArray<bool> Settled;

		[Token(Token = "0x40001C8")]
		[FieldOffset(Offset = "0x50")]
		public NativeArray<bool> Ghosted;

		[Token(Token = "0x40001C9")]
		[FieldOffset(Offset = "0x60")]
		public NativeArray<int> Colors;

		[Token(Token = "0x40001CA")]
		[FieldOffset(Offset = "0x70")]
		public NativeArray<int> ContactCounts;

		[Token(Token = "0x40001CB")]
		[FieldOffset(Offset = "0x80")]
		public NativeArray<float2> PosOut;

		[Token(Token = "0x40001CC")]
		[FieldOffset(Offset = "0x90")]
		public NativeArray<float2> VelOut;

		[Token(Token = "0x40001CD")]
		[FieldOffset(Offset = "0xA0")]
		public NativeArray<float2> PosNext;

		[Token(Token = "0x40001CE")]
		[FieldOffset(Offset = "0xB0")]
		public NativeArray<float2> VelNext;

		[Token(Token = "0x40001CF")]
		[FieldOffset(Offset = "0xC0")]
		public NativeArray<float> Speeds;

		[Token(Token = "0x40001D0")]
		[FieldOffset(Offset = "0xD0")]
		public NativeArray<bool> ExitedIn;

		[Token(Token = "0x40001D1")]
		[FieldOffset(Offset = "0xE0")]
		public NativeArray<int> CountersIn;

		[Token(Token = "0x40001D2")]
		[FieldOffset(Offset = "0xF0")]
		public NativeArray<float2> AnchorsIn;

		[Token(Token = "0x40001D3")]
		[FieldOffset(Offset = "0x100")]
		public NativeArray<bool> SettledOut;

		[Token(Token = "0x40001D4")]
		[FieldOffset(Offset = "0x110")]
		public NativeArray<int> CountersOut;

		[Token(Token = "0x40001D5")]
		[FieldOffset(Offset = "0x120")]
		public NativeArray<float2> AnchorsOut;

		[Token(Token = "0x40001D6")]
		[FieldOffset(Offset = "0x130")]
		public NativeArray<ushort> SpawnAges;

		[Token(Token = "0x40001D7")]
		[FieldOffset(Offset = "0x140")]
		public NativeArray<int> IsolatedFramesIn;

		[Token(Token = "0x40001D8")]
		[FieldOffset(Offset = "0x150")]
		public NativeArray<int> IsolatedFramesOut;

		[Token(Token = "0x40001D9")]
		[FieldOffset(Offset = "0x160")]
		public NativeParallelMultiHashMap<int2, int> SpatialGrid;

		[Token(Token = "0x40001DA")]
		[FieldOffset(Offset = "0x170")]
		private int _capacity;

		[Token(Token = "0x40001DB")]
		[FieldOffset(Offset = "0x174")]
		private bool _disposed;

		[Token(Token = "0x17000052")]
		public int Capacity
		{
			[Token(Token = "0x600029A")]
			[Address(RVA = "0x3C7ABD8", Offset = "0x3C7ABD8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.Capacity;\n")]
			get
			{
				return _capacity;
			}
		}

		[Token(Token = "0x600029B")]
		[Address(RVA = "0x3C7ABE0", Offset = "0x3C7ABE0", Length = "0x434")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0035;\n\tv92 = this.Capacity < 0;\n\tv91 = this.Capacity == 0;\n\tv77 = this.Capacity ^ this.Capacity;\n\tv78 = this.Capacity & v77;\n\tv87 = v78 < 0;\n\tgoto L_0046;\nL_FFFFFFFF:\n\tv87 = 0;\nL_FFFFFFFF:\n\tv91 = 1;\nL_FFFFFFFF:\n\tv92 = 0;\n\tv325 = count + 0x3F;\n\tv114 = count + 0x7E;\n\tv118 = v325 < 0;\n\tv121 = v325 ^ v325;\n\tv122 = v325 & v121;\n\tv123 = v122 < 0;\n\tv124 = v118 == v123;\n\tv125 = ~v124;\n\tv126 = ~v125;\n\tif (v126) goto L_0069;\nL_FFFFFFFF:\n\tv325 = v114;\n\tgoto L_0069;\nL_FFFFFFFF:\n\tv305 = v302;\n\tgoto L_007E;\nL_FFFFFFFF:\n\tv305 = 0x80;\n\tthis.Velocities = v253;\n\tv244 = 0;\n\tUnity.Collections.NativeArray`1<System.Single>::.ctor(&v247 @ stack_-90_v3 (Unity.Collections.NativeArray`1<System.Single>), v305, 4, 1);\n\tthis.Radii = v247;\n\tv238 = 0;\n\tUnity.Collections.NativeArray`1<System.Boolean>::.ctor(&v241 @ stack_-A0_v3 (Unity.Collections.NativeArray`1<System.Boolean>), v305, 4, 1);\n\tthis.Settled = v241;\n\tv232 = 0;\n\tUnity.Collections.NativeArray`1<System.Boolean>::.ctor(&v235 @ stack_-B0_v3 (Unity.Collections.NativeArray`1<System.Boolean>), v305, 4, 1);\n\tthis.Ghosted = v235;\n\tv226 = 0;\n\tUnity.Collections.NativeArray`1<System.Int32>::.ctor(&v229 @ stack_-C0_v3 (Unity.Collections.NativeArray`1<System.Int32>), v305, 4, 1);\n\tthis.Colors = v229;\n\tv220 = 0;\n\tUnity.Collections.NativeArray`1<System.UInt16>::.ctor(&v223 @ stack_-D0_v3 (Unity.Collections.NativeArray`1<System.UInt16>), v305, 4, 1);\n\tthis.SpawnAges = v223;\n\tv214 = 0;\n\tUnity.Collections.NativeArray`1<System.Int32>::.ctor(&v217 @ stack_-E0_v3 (Unity.Collections.NativeArray`1<System.Int32>), v305, 4, 1);\n\tthis.ContactCounts = v217;\n\tUnity.Collections.NativeArray`1<Unity.Mathematics.float2>::.ctor(&v211 @ stack_-F0_v3 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>), v305, 4, 1);\n\tthis.PosOut = v211;\n\tUnity.Collections.NativeArray`1<Unity.Mathematics.float2>::.ctor(&v205 @ stack_-100_v3 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>), v305, 4, 1);\n\tthis.VelOut = v205;\n\tUnity.Collections.NativeArray`1<Unity.Mathematics.float2>::.ctor(&v199 @ stack_-110_v3 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>), v305, 4, 1);\n\tthis.PosNext = v199;\n\tUnity.Collections.NativeArray`1<Unity.Mathematics.float2>::.ctor(&v193 @ stack_-120_v3 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>), v305, 4, 1);\n\tthis.VelNext = v193;\n\tUnity.Collections.NativeArray`1<System.Single>::.ctor(&v187 @ stack_-130_v3 (Unity.Collections.NativeArray`1<System.Single>), v305, 4, 1);\n\tthis.Speeds = v187;\n\tUnity.Collections.NativeArray`1<System.Boolean>::.ctor(&v181 @ stack_-140_v3 (Unity.Collections.NativeArray`1<System.Boolean>), v305, 4, 1);\n\tthis.ExitedIn = v181;\n\tUnity.Collections.NativeArray`1<System.Int32>::.ctor(&v175 @ stack_-150_v3 (Unity.Collections.NativeArray`1<System.Int32>), v305, 4, 1);\n\tthis.CountersIn = v175;\n\tUnity.Collections.NativeArray`1<Unity.Mathematics.float2>::.ctor(&v169 @ stack_-160_v3 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>), v305, 4, 1);\n\tthis.AnchorsIn = v169;\n\tUnity.Collections.NativeArray`1<System.Boolean>::.ctor(&v163 @ stack_-170_v3 (Unity.Collections.NativeArray`1<System.Boolean>), v305, 4, 1);\n\tthis.SettledOut = v163;\n\tUnity.Collections.NativeArray`1<System.Int32>::.ctor(&v157 @ stack_-180_v3 (Unity.Collections.NativeArray`1<System.Int32>), v305, 4, 1);\n\tthis.CountersOut = v157;\n\tUnity.Collections.NativeArray`1<Unity.Mathematics.float2>::.ctor(&v151 @ stack_-190_v3 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>), v305, 4, 1);\n\tthis.AnchorsOut = v151;\n\tUnity.Collections.NativeArray`1<System.Int32>::.ctor(&v145 @ stack_-1A0_v3 (Unity.Collections.NativeArray`1<System.Int32>), v305, 4, 1);\n\tthis.IsolatedFramesIn = v145;\n\tUnity.Collections.NativeArray`1<System.Int32>::.ctor(&v139 @ stack_-1B0_v3 (Unity.Collections.NativeArray`1<System.Int32>), v305, 4, 1);\n\tthis.IsolatedFramesOut = v139;\n\tv479 = Unity.Collections.AllocatorManager+AllocatorHandle::op_Implicit(4);\n\tv262 = v305 << 1;\n\tUnity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>::.ctor(&v133 @ stack_-1C0_v3 (Unity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>), v262, v479);\n\tthis.SpatialGrid = v133;\n\tthis._disposed = 0;\nL_0035:\n\tv67 = this.Capacity < count;\n\tif (v67) goto L_FFFFFFFF;\nL_0046:\n\tv95 = v92 == v87;\n\tv96 = ~v91;\n\tv97 = v95 & v96;\n\tif (v97) goto L_016C;\nL_0069:\n\tv302 = v325 & 0xFFFFFFFFFFFFFFC0;\n\tv296 = v302 - 0x80;\n\tv294 = v296 < 0;\n\tv292 = v296 == 0;\n\tv290 = v302 ^ 0x80;\n\tv288 = v302 ^ v296;\n\tv286 = v290 & v288;\n\tv284 = v286 < 0;\n\tv327 = v294 == v284;\n\tv128 = ~v292;\n\tv274 = v327 & v128;\n\tv272 = ~v274;\n\tif (v272) goto L_FFFFFFFF;\nL_007E:\n\t_game.CoreSystem.SandPhysics.SandPhysicsBuffers::Dispose(this);\n\tthis.Capacity = v305;\n\tv266 = 0;\n\tUnity.Collections.NativeArray`1<Unity.Mathematics.float2>::.ctor(&v269 @ stack_-70_v3 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>), v305, 4, 1);\n\tthis.Positions = v269;\n\tv250 = 0;\n\tUnity.Collections.NativeArray`1<Unity.Mathematics.float2>::.ctor(&v253 @ stack_-80_v3 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>), v305, 4, 1);\nL_016C:\n\treturn;\n")]
		public void EnsureCapacity(int count)
		{
			bool flag;
			bool flag2;
			bool flag3;
			if (Capacity >= count)
			{
				flag = Capacity < 0;
				flag2 = Capacity == 0;
				int num = Capacity ^ Capacity;
				int num2 = Capacity & num;
				flag3 = num2 < 0;
			}
			else
			{
				flag3 = false;
				flag2 = true;
				flag = false;
			}
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			if (!(flag4 && flag5))
			{
				int num3 = count + 63;
				int num4 = count + 126;
				bool flag6 = num3 < 0;
				int num5 = num3 ^ num3;
				int num6 = num3 & num5;
				bool flag7 = num6 < 0;
				if (flag6 != flag7)
				{
					num3 = num4;
				}
				int num7 = num3 & -64;
				int num8 = num7 - 128;
				bool flag8 = num8 < 0;
				bool flag9 = num8 == 0;
				int num9 = num7 ^ 0x80;
				int num10 = num7 ^ num8;
				int num11 = num9 & num10;
				bool flag10 = num11 < 0;
				bool flag11 = flag8 == flag10;
				bool flag12 = !flag9;
				int num12 = ((!(flag11 && flag12)) ? 128 : num7);
				Dispose();
				_capacity = num12;
				int num13 = 0;
				NativeArray<float2> positions = new NativeArray<float2>(num12, Allocator.Persistent);
				Positions = positions;
				int num14 = 0;
				NativeArray<float2> velocities = new NativeArray<float2>(num12, Allocator.Persistent);
				Velocities = velocities;
				int num15 = 0;
				NativeArray<float> radii = new NativeArray<float>(num12, Allocator.Persistent);
				Radii = radii;
				int num16 = 0;
				NativeArray<bool> settled = new NativeArray<bool>(num12, Allocator.Persistent);
				Settled = settled;
				int num17 = 0;
				NativeArray<bool> ghosted = new NativeArray<bool>(num12, Allocator.Persistent);
				Ghosted = ghosted;
				int num18 = 0;
				NativeArray<int> colors = new NativeArray<int>(num12, Allocator.Persistent);
				Colors = colors;
				int num19 = 0;
				NativeArray<ushort> spawnAges = new NativeArray<ushort>(num12, Allocator.Persistent);
				SpawnAges = spawnAges;
				int num20 = 0;
				NativeArray<int> contactCounts = new NativeArray<int>(num12, Allocator.Persistent);
				ContactCounts = contactCounts;
				NativeArray<float2> posOut = new NativeArray<float2>(num12, Allocator.Persistent);
				PosOut = posOut;
				NativeArray<float2> velOut = new NativeArray<float2>(num12, Allocator.Persistent);
				VelOut = velOut;
				NativeArray<float2> posNext = new NativeArray<float2>(num12, Allocator.Persistent);
				PosNext = posNext;
				NativeArray<float2> velNext = new NativeArray<float2>(num12, Allocator.Persistent);
				VelNext = velNext;
				NativeArray<float> speeds = new NativeArray<float>(num12, Allocator.Persistent);
				Speeds = speeds;
				NativeArray<bool> exitedIn = new NativeArray<bool>(num12, Allocator.Persistent);
				ExitedIn = exitedIn;
				NativeArray<int> countersIn = new NativeArray<int>(num12, Allocator.Persistent);
				CountersIn = countersIn;
				NativeArray<float2> anchorsIn = new NativeArray<float2>(num12, Allocator.Persistent);
				AnchorsIn = anchorsIn;
				NativeArray<bool> settledOut = new NativeArray<bool>(num12, Allocator.Persistent);
				SettledOut = settledOut;
				NativeArray<int> countersOut = new NativeArray<int>(num12, Allocator.Persistent);
				CountersOut = countersOut;
				NativeArray<float2> anchorsOut = new NativeArray<float2>(num12, Allocator.Persistent);
				AnchorsOut = anchorsOut;
				NativeArray<int> isolatedFramesIn = new NativeArray<int>(num12, Allocator.Persistent);
				IsolatedFramesIn = isolatedFramesIn;
				NativeArray<int> isolatedFramesOut = new NativeArray<int>(num12, Allocator.Persistent);
				IsolatedFramesOut = isolatedFramesOut;
				AllocatorManager.AllocatorHandle allocator = Allocator.Persistent;
				int capacity = num12 << 1;
				NativeParallelMultiHashMap<int2, int> spatialGrid = new NativeParallelMultiHashMap<int2, int>(capacity, allocator);
				SpatialGrid = spatialGrid;
				_disposed = false;
			}
		}

		[Token(Token = "0x600029C")]
		[Address(RVA = "0x3C7B014", Offset = "0x3C7B014", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.SandPhysicsBuffers::BuildSpatialHash(this, count, cellSize, dependency, this.PosOut, this.Ghosted);\n\treturn returnVal1;\n")]
		public JobHandle BuildSpatialHash(int count, float cellSize, JobHandle dependency)
		{
			return BuildSpatialHash(count, cellSize, dependency, PosOut, Ghosted);
		}

		[Token(Token = "0x600029D")]
		[Address(RVA = "0x3C7B038", Offset = "0x3C7B038", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = _game.CoreSystem.SandPhysics.SandPhysicsBuffers::BuildSpatialHash(this, count, cellSize, dependency, positions, this.Ghosted);\n\treturn returnVal1;\n")]
		public JobHandle BuildSpatialHash(int count, float cellSize, JobHandle dependency, NativeArray<float2> positions)
		{
			return BuildSpatialHash(count, cellSize, dependency, positions, Ghosted);
		}

		[Token(Token = "0x600029E")]
		[Address(RVA = "0x3C7B058", Offset = "0x3C7B058", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0036;\nL_0041:\n\tv88 = this.SpatialGrid;\n\tv98 = count << 1;\n\tv108 = *([v88 @ X8_v6 (Unity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>)+20]) >= v98;\n\tif (v108) goto L_005B;\n\tUnity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>::set_Capacity(&this.SpatialGrid (Unity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>), v98);\nL_005B:\n\t;\n\tv121 = Unity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>::AsParallelWriter(&this.SpatialGrid (Unity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>));\n\tv123 = positions;\n\treturnVal2 = Unity.Jobs.IJobParallelForExtensions::Schedule(&v123 @ stack_-B0_v1 (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>), count, 0x40, dependency);\n\treturn returnVal2;\nL_0036:\n\t;\n\tUnity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>::Clear(&this.SpatialGrid (Unity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>));\n\tgoto L_0041;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe JobHandle BuildSpatialHash(int count, float cellSize, JobHandle dependency, NativeArray<float2> positions, NativeArray<bool> excluded)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandPhysicsBuffers::BuildSpatialHash");
			return default;
		}

		[Token(Token = "0x600029F")]
		[Address(RVA = "0x3C7A984", Offset = "0x3C7A984", Length = "0x200")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002A;\n\tv55 = this.Capacity == 0;\n\tif (v55) goto L_0091;\n\t_game.CoreSystem.SandPhysics.SandPhysicsBuffers::SafeDispose(&this.Positions (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>));\n\t_game.CoreSystem.SandPhysics.SandPhysicsBuffers::SafeDispose(&this.Velocities (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>));\n\t_game.CoreSystem.SandPhysics.SandPhysicsBuffers::SafeDispose(&this.Radii (Unity.Collections.NativeArray`1<System.Single>));\n\t_game.CoreSystem.SandPhysics.SandPhysicsBuffers::SafeDispose(&this.Settled (Unity.Collections.NativeArray`1<System.Boolean>));\n\t_game.CoreSystem.SandPhysics.SandPhysicsBuffers::SafeDispose(&this.Ghosted (Unity.Collections.NativeArray`1<System.Boolean>));\n\t_game.CoreSystem.SandPhysics.SandPhysicsBuffers::SafeDispose(&this.Colors (Unity.Collections.NativeArray`1<System.Int32>));\n\t_game.CoreSystem.SandPhysics.SandPhysicsBuffers::SafeDispose(&this.SpawnAges (Unity.Collections.NativeArray`1<System.UInt16>));\n\t_game.CoreSystem.SandPhysics.SandPhysicsBuffers::SafeDispose(&this.ContactCounts (Unity.Collections.NativeArray`1<System.Int32>));\n\t_game.CoreSystem.SandPhysics.SandPhysicsBuffers::SafeDispose(&this.PosOut (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>));\n\t_game.CoreSystem.SandPhysics.SandPhysicsBuffers::SafeDispose(&this.VelOut (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>));\n\t_game.CoreSystem.SandPhysics.SandPhysicsBuffers::SafeDispose(&this.PosNext (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>));\n\t_game.CoreSystem.SandPhysics.SandPhysicsBuffers::SafeDispose(&this.VelNext (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>));\n\t_game.CoreSystem.SandPhysics.SandPhysicsBuffers::SafeDispose(&this.Speeds (Unity.Collections.NativeArray`1<System.Single>));\n\t_game.CoreSystem.SandPhysics.SandPhysicsBuffers::SafeDispose(&this.ExitedIn (Unity.Collections.NativeArray`1<System.Boolean>));\n\t_game.CoreSystem.SandPhysics.SandPhysicsBuffers::SafeDispose(&this.CountersIn (Unity.Collections.NativeArray`1<System.Int32>));\n\t_game.CoreSystem.SandPhysics.SandPhysicsBuffers::SafeDispose(&this.AnchorsIn (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>));\n\t_game.CoreSystem.SandPhysics.SandPhysicsBuffers::SafeDispose(&this.SettledOut (Unity.Collections.NativeArray`1<System.Boolean>));\n\t_game.CoreSystem.SandPhysics.SandPhysicsBuffers::SafeDispose(&this.CountersOut (Unity.Collections.NativeArray`1<System.Int32>));\n\t_game.CoreSystem.SandPhysics.SandPhysicsBuffers::SafeDispose(&this.AnchorsOut (Unity.Collections.NativeArray`1<Unity.Mathematics.float2>));\n\t_game.CoreSystem.SandPhysics.SandPhysicsBuffers::SafeDispose(&this.IsolatedFramesIn (Unity.Collections.NativeArray`1<System.Int32>));\n\t_game.CoreSystem.SandPhysics.SandPhysicsBuffers::SafeDispose(&this.IsolatedFramesOut (Unity.Collections.NativeArray`1<System.Int32>));\n\tv146 = Unity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>::get_IsCreated(&this.SpatialGrid (Unity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>));\n\tv67 = ~v146;\n\tif (v67) goto L_0085;\n\tUnity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>::Dispose(&this.SpatialGrid (Unity.Collections.NativeParallelMultiHashMap`2<Unity.Mathematics.int2, System.Int32>));\nL_0085:\n\tthis.Capacity = 0;\n\tthis._disposed = 1;\nL_002A:\n\tv49 = this._disposed == 0;\n\tv50 = ~v49;\n\tif (v50) goto L_0091;\nL_0091:\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Dispose()
		{
			if (!_disposed && Capacity != 0)
			{
				SafeDispose(ref Positions);
				SafeDispose(ref Velocities);
				SafeDispose(ref Radii);
				SafeDispose(ref Settled);
				SafeDispose(ref Ghosted);
				SafeDispose(ref Colors);
				SafeDispose(ref SpawnAges);
				SafeDispose(ref ContactCounts);
				SafeDispose(ref PosOut);
				SafeDispose(ref VelOut);
				SafeDispose(ref PosNext);
				SafeDispose(ref VelNext);
				SafeDispose(ref Speeds);
				SafeDispose(ref ExitedIn);
				SafeDispose(ref CountersIn);
				SafeDispose(ref AnchorsIn);
				SafeDispose(ref SettledOut);
				SafeDispose(ref CountersOut);
				SafeDispose(ref AnchorsOut);
				SafeDispose(ref IsolatedFramesIn);
				SafeDispose(ref IsolatedFramesOut);
				if (SpatialGrid.IsCreated)
				{
					SpatialGrid.Dispose();
				}
				_capacity = 0;
				_disposed = true;
			}
		}

		[Token(Token = "0x60002A0")]
		[Address(RVA = "0x4C9256C", Offset = "0x4C9256C", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_000B;\nL_000B:\n\tv16 = array.m_Buffer == 0;\n\tv34 = array;\n\tif (v16) goto L_0023;\nL_0014:\n\tUnity.Collections.NativeArray`1<System.Boolean>::Dispose(v34);\n\treturn;\n\tv19 = 0x220C2B8(methodInfo, methodInfo, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv55 = array.m_Buffer == 0;\n\tv38 = ~v55;\n\tv34 = array;\n\tif (v38) goto L_0014;\nL_0023:\n\treturn;\n")]
		private unsafe static void SafeDispose<T>(ref NativeArray<T> array) where T : struct
		{
			global::AssetRipperInjected.RecoveryStub.Missing("SandPhysicsBuffers::SafeDispose");
		}

		[Token(Token = "0x60002A1")]
		[Address(RVA = "0x3C7B1C8", Offset = "0x3C7B1C8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public SandPhysicsBuffers()
		{
		}
	}
}
