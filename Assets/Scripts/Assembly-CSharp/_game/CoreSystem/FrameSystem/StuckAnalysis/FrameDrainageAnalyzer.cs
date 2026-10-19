using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using _game.CoreSystem.FrameSystem.MeshGen;

namespace _game.CoreSystem.FrameSystem.StuckAnalysis
{
	[Token(Token = "0x20004F5")]
	public static class FrameDrainageAnalyzer
	{
		[Token(Token = "0x20004F6")]
		private sealed class MinHeap
		{
			[Token(Token = "0x40010A5")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			private int[] _idx;

			[Token(Token = "0x40010A6")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			private float[] _key;

			[Token(Token = "0x40010A7")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			private int _count;

			[Token(Token = "0x170001CE")]
			public int Count
			{
				[Token(Token = "0x60014C9")]
				[Address(RVA = "0x3D023F4", Offset = "0x3D023F4", Length = "0x8")]
				get
				{
					return _count;
				}
			}

			[Token(Token = "0x60014C8")]
			[Address(RVA = "0x3D01E24", Offset = "0x3D01E24", Length = "0xB8")]
			public MinHeap(int capacity)
			{
				int num = capacity - 16;
				bool flag = num < 0;
				bool flag2 = num == 0;
				int num2 = capacity ^ 0x10;
				int num3 = capacity ^ num;
				int num4 = num2 & num3;
				bool flag3 = num4 < 0;
				bool flag4 = flag == flag3;
				bool flag5 = !flag2;
				int num5 = ((!(flag4 && flag5)) ? 16 : capacity);
				int[] idx = new int[num5];
				_idx = idx;
				float[] key = new float[num5];
				_key = key;
			}

			[Token(Token = "0x60014CA")]
			[Address(RVA = "0x3D01EDC", Offset = "0x3D01EDC", Length = "0x160")]
			public void Push(int idx, float key)
			{
				int[] idx2 = _idx;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X0_v3 (System.Int32[]&)+10]");
				int num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X0_v3 (System.Int32[]&)+10]");
				if ((nint)0 == idx2.Length)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X0_v3 (System.Int32[]&)+10]");
					int newSize = (int)((nint)0 << 1);
					Array.Resize(ref _idx, newSize);
					int newSize2 = Count << 1;
					Array.Resize(ref _key, newSize2);
					num = Count;
					idx2 = _idx;
					int count = Count + 1;
					_count = count;
					if (_idx == null)
					{
						throw new NullReferenceException();
					}
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v50 @ X0_v3 (System.Int32[]&)+10]");
					int count2 = (int)((nint)0 + (nint)1);
					_count = count2;
				}
				idx2[num] = idx;
				float[] key2 = _key;
				key2[num] = key;
				if (num < 1)
				{
					return;
				}
				bool flag9;
				do
				{
					float[] key3 = _key;
					int num2 = num - 1;
					int num3 = num2 >> 1;
					bool flag = key3[num3] == key3[num];
					bool flag2 = key3[num3] < key3[num];
					bool flag3 = !flag2;
					bool flag4 = !flag3;
					if (!(flag4 || flag))
					{
						Swap(num3, num);
						bool flag5 = (uint)num2 < 1u;
						bool flag6 = !flag5;
						int num4 = num2 - 1;
						bool flag7 = num4 == 0;
						bool flag8 = !flag7;
						flag9 = flag6 && flag8;
						num = num3;
						continue;
					}
					break;
				}
				while (flag9);
			}

			[Token(Token = "0x60014CB")]
			[Address(RVA = "0x3D0203C", Offset = "0x3D0203C", Length = "0x158")]
			public int Pop(out float key)
			{
				key = default(float);
				int[] idx = _idx;
				float[] key2 = _key;
				key = key2[0];
				idx[0] = idx[_count = Count - 1];
				int count = Count;
				key2[0] = key2[count];
				bool flag = 1 >= count;
				int num = 0;
				int num2 = 0;
				int num3 = 1;
				int num4 = 0;
				int num5 = 0;
				int num6 = 0;
				int num7 = count;
				if (!flag)
				{
					goto IL_0101;
				}
				goto IL_026f;
				IL_0101:
				float[] key3 = _key;
				bool flag2 = key3[num3] < key3[num];
				bool flag3 = !flag2;
				num4 = num;
				num5 = num;
				num6 = num2;
				num7 = count;
				if (!flag3)
				{
					num4 = num3;
					num5 = num;
					num6 = num2;
					num7 = count;
				}
				goto IL_026f;
				IL_026f:
				while (true)
				{
					int num8 = num6 + 2;
					if (num8 < num7)
					{
						float[] key4 = _key;
						if (key4[num8] < key4[num4])
						{
							num4 = num8;
						}
					}
					if (num4 != num5)
					{
						Swap(num4, num5);
						count = Count;
						num2 = num4 << 1;
						num3 = num2 | 1;
						bool flag4 = num3 < Count;
						num = num4;
						if (flag4)
						{
							break;
						}
						num5 = num4;
						num6 = num2;
						num7 = Count;
						continue;
					}
					return idx[0];
				}
				goto IL_0101;
			}

			[Token(Token = "0x60014CC")]
			[Address(RVA = "0x3D023FC", Offset = "0x3D023FC", Length = "0x80")]
			private void Swap(int a, int b)
			{
				int[] idx = _idx;
				idx[a] = idx[b];
				idx[b] = idx[a];
				float[] key = _key;
				key[a] = key[b];
				key[b] = key[a];
			}
		}

		[Token(Token = "0x20004F7")]
		private sealed class WallGrid
		{
			[Token(Token = "0x40010A8")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			private readonly WallSegment[] _walls;

			[Token(Token = "0x40010A9")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			private readonly float _minX;

			[Token(Token = "0x40010AA")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x1C")]
			private readonly float _minY;

			[Token(Token = "0x40010AB")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			private readonly float _h;

			[Token(Token = "0x40010AC")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x24")]
			private readonly int _cols;

			[Token(Token = "0x40010AD")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
			private readonly int _rows;

			[Token(Token = "0x40010AE")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
			private readonly Dictionary<int, List<int>> _cells;

			[Token(Token = "0x40010AF")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x38")]
			private readonly int[] _stamp;

			[Token(Token = "0x40010B0")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
			private int _query;

			[Token(Token = "0x60014CD")]
			[Address(RVA = "0x3D01660", Offset = "0x3D01660", Length = "0x15C")]
			public WallGrid(WallSegment[] walls, float minX, float minY, float h, int cols, int rows)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("FrameDrainageAnalyzer.WallGrid::.ctor");
			}

			[Token(Token = "0x60014CE")]
			[Address(RVA = "0x3D01994", Offset = "0x3D01994", Length = "0x490")]
			public bool AnyCross(float2 p1, float2 p2)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("FrameDrainageAnalyzer.WallGrid::AnyCross");
				return default;
			}

			[Token(Token = "0x60014CF")]
			[Address(RVA = "0x3D027FC", Offset = "0x3D027FC", Length = "0x90")]
			private int Ci(float x)
			{
				//IL_0074: Expected I4, but got F4
				float num = x - _minX;
				float num2 = num / _h;
				float num3 = Mathf.Floor(num2);
				if (num3 == 1f / 0f)
				{
					return -2147483648;
				}
				return (int)num2;
			}

			[Token(Token = "0x60014D0")]
			[Address(RVA = "0x3D0288C", Offset = "0x3D0288C", Length = "0x8C")]
			private int Cj(float y)
			{
				//IL_0074: Expected I4, but got F4
				float num = y - _minY;
				float num2 = num / _h;
				float num3 = Mathf.Floor(num2);
				if (num3 == 1f / 0f)
				{
					return -2147483648;
				}
				return (int)num2;
			}

			[Token(Token = "0x60014D1")]
			[Address(RVA = "0x3D02918", Offset = "0x3D02918", Length = "0x188")]
			private void Add(int i, int j, int wi)
			{
				//IL_019f: Expected I4, but got I8
				//IL_0017: Expected I4, but got I8
				if ((int)(i & 0x80000000L) != 0 || (int)(j & 0x80000000L) != 0 || _cols <= i || _rows <= j)
				{
					return;
				}
				int num = _cols * j;
				int key = i + num;
				List<int> list = default(List<int>);
				if (!_cells.TryGetValue(key, out var _))
				{
					list = new List<int>();
					_cells[key] = list;
				}
				bool flag = list.Count == 0;
				List<int> list2 = list;
				if (!flag)
				{
					int index = list.Count - 1;
					int num2 = list[index];
					if (num2 == wi)
					{
						return;
					}
					list2 = list;
				}
				list2.Add(wi);
			}

			[Token(Token = "0x60014D2")]
			[Address(RVA = "0x3D0247C", Offset = "0x3D0247C", Length = "0x380")]
			private void Rasterize(int wi, float2 a, float2 b)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("FrameDrainageAnalyzer.WallGrid::Rasterize");
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		[Token(Token = "0x20004F8")]
		private struct _003C_003Ec__DisplayClass4_0
		{
			[Token(Token = "0x40010B1")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
			public float minX;

			[Token(Token = "0x40010B2")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
			public float h;

			[Token(Token = "0x40010B3")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
			public float minY;

			[Token(Token = "0x40010B4")]
			[Cpp2ILInjected.FieldOffset(Offset = "0xC")]
			public bool regionAware;

			[Token(Token = "0x40010B5")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
			public List<List<float2>> loops;

			[Token(Token = "0x40010B6")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
			public double[] absArea;

			[Token(Token = "0x40010B7")]
			[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
			public FrameData frame;
		}

		[Token(Token = "0x40010A2")]
		private const float HeightEpsilon = 0.0001f;

		[Token(Token = "0x40010A3")]
		private static readonly int[] Dx = new int[8] { -1, 1, 0, 0, -1, -1, 1, 1 };

		[Token(Token = "0x40010A4")]
		private static readonly int[] Dy = new int[8] { 0, 0, -1, 1, -1, 1, -1, 1 };

		[Token(Token = "0x60014C1")]
		[Address(RVA = "0x3CFF3B0", Offset = "0x3CFF3B0", Length = "0xE0")]
		public unsafe static DrainageResult Analyze(FrameData frame, DrainageConfig config, Func<float2, bool> isPlayable = null, Func<float2, bool> isCubeSource = null, DrainageMode mode = DrainageMode.Monotonic)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FrameDrainageAnalyzer::Analyze");
			return default;
		}

		[Token(Token = "0x60014C2")]
		[Address(RVA = "0x3CFF490", Offset = "0x3CFF490", Length = "0x21D0")]
		public unsafe static DrainageDetail AnalyzeDetailed(FrameData frame, DrainageConfig config, Func<float2, bool> isPlayable = null, Func<float2, bool> isCubeSource = null, DrainageMode mode = DrainageMode.Monotonic)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FrameDrainageAnalyzer::AnalyzeDetailed");
			return default;
		}

		[Token(Token = "0x60014C3")]
		[Address(RVA = "0x3D02194", Offset = "0x3D02194", Length = "0x168")]
		private static bool SegmentsIntersect(float2 a, float2 b, float2 c, float2 d)
		{
			float2 float5 = default(float2);
			float num = float5.x - c.x;
			float num2 = float5.y - c.y;
			float num3 = a.x - c.x;
			float num4 = a.y - c.y;
			float num5 = num4 * num;
			float num6 = num3 * num2;
			float2 float6 = default(float2);
			float num7 = float6.x - c.x;
			float num8 = float6.y - c.y;
			float num9 = num8 * num;
			float num10 = num7 * num2;
			if (num5 > num6 && num9 < num10)
			{
				goto IL_0077;
			}
			bool flag = !(num5 < num6);
			bool result = false;
			if (!flag)
			{
				bool flag2 = !(num9 > num10);
				result = false;
				if (!flag2)
				{
					goto IL_0077;
				}
			}
			goto IL_02c0;
			IL_0077:
			float num11 = float6.x - a.x;
			float num12 = float6.y - a.y;
			float num13 = c.x - a.x;
			float num14 = c.y - a.y;
			float num15 = num11 * num14;
			float num16 = num12 * num13;
			float num17 = num15 - num16;
			float num18 = float5.x - a.x;
			float num19 = float5.y - a.y;
			float num20 = num11 * num19;
			float num21 = num12 * num18;
			float num22 = num20 - num21;
			if (num15 > num16 && num20 < num21)
			{
				result = true;
			}
			else
			{
				bool flag3 = num22 < 0f;
				bool flag4 = num22 == 0f;
				bool flag5 = num22 == num22;
				bool flag6 = !flag5;
				bool flag7 = flag3 == flag6;
				bool flag8 = !flag4;
				bool flag9 = flag7 && flag8 && num17 < 0f;
				result = flag9;
			}
			goto IL_02c0;
			IL_02c0:
			return result;
		}
	}
}
