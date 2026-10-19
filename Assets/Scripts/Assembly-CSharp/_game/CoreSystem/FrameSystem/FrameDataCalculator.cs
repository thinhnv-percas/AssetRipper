using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using _game.BaseLayerSystems.EntitySystem.Core;
using _game.CoreSystem.FrameSystem.MeshGen;
using _game.CoreSystem.New.GridEcsBinding;
using _game.CoreSystem.New.TopGridSystem.Core.Handlers;

namespace _game.CoreSystem.FrameSystem
{
	[Token(Token = "0x20004DF")]
	public static class FrameDataCalculator
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20004E0")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400104A")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400104B")]
			public static Comparison<(float y, float fromX, float toX)> _003C_003E9__9_0;

			[Token(Token = "0x400104C")]
			public static Comparison<(float y, float fromX, float toX)> _003C_003E9__9_1;

			[Token(Token = "0x400104D")]
			public static Comparison<(float x, float fromY, float toY)> _003C_003E9__9_2;

			[Token(Token = "0x400104E")]
			public static Comparison<(float x, float fromY, float toY)> _003C_003E9__9_3;

			[Token(Token = "0x6001492")]
			[Address(RVA = "0x3CFA8D0", Offset = "0x3CFA8D0", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6001493")]
			[Address(RVA = "0x3CFA934", Offset = "0x3CFA934", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal unsafe int _003CMergeColinearEdges_003Eb__9_0((float y, float fromX, float toX) a, (float y, float fromX, float toX) b)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("FrameDataCalculator._003C_003Ec::_003CMergeColinearEdges_003Eb__9_0");
				return default;
			}

			internal unsafe int _003CMergeColinearEdges_003Eb__9_1((float y, float fromX, float toX) a, (float y, float fromX, float toX) b)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("FrameDataCalculator._003C_003Ec::_003CMergeColinearEdges_003Eb__9_1");
				return default;
			}

			internal unsafe int _003CMergeColinearEdges_003Eb__9_2((float x, float fromY, float toY) a, (float x, float fromY, float toY) b)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("FrameDataCalculator._003C_003Ec::_003CMergeColinearEdges_003Eb__9_2");
				return default;
			}

			internal unsafe int _003CMergeColinearEdges_003Eb__9_3((float x, float fromY, float toY) a, (float x, float fromY, float toY) b)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("FrameDataCalculator._003C_003Ec::_003CMergeColinearEdges_003Eb__9_3");
				return default;
			}
		}

		[Token(Token = "0x4001049")]
		private const float ColinearEpsilon = 0.001f;

		[Token(Token = "0x6001483")]
		[Address(RVA = "0x3CF6878", Offset = "0x3CF6878", Length = "0x6B0")]
		public unsafe static FrameData Compute(EntityManager em, TopGridHandler gridHandler, FramePresetConfig preset, float4x4 localToWorld)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FrameDataCalculator::Compute");
			return default;
		}

		[Token(Token = "0x6001484")]
		[Address(RVA = "0x3CF85B8", Offset = "0x3CF85B8", Length = "0x9C8")]
		private unsafe static FrameData DissolveInternalBlockedWalls(FrameDataMerger.MergeResult merge, float2 seed)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FrameDataCalculator::DissolveInternalBlockedWalls");
			return default;
		}

		[Token(Token = "0x6001485")]
		[Address(RVA = "0x3CF6F28", Offset = "0x3CF6F28", Length = "0x380")]
		private static FrameData PresetReset(FramePresetConfig preset)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FrameDataCalculator::PresetReset");
			return default;
		}

		[Token(Token = "0x6001486")]
		[Address(RVA = "0x3CF72A8", Offset = "0x3CF72A8", Length = "0x880")]
		private static List<List<(int, int)>> FloodFillWallCells(EntityManager em, TopGridHandler gridHandler, int columns, int rows)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FrameDataCalculator::FloodFillWallCells");
			return default;
		}

		[Token(Token = "0x6001487")]
		[Address(RVA = "0x3CF8FF4", Offset = "0x3CF8FF4", Length = "0x134")]
		private static void TryEnqueueNeighbour(EntityManager em, TopGridHandler gridHandler, bool[] visited, Queue<(int col, int row)> queue, int columns, int rows, int col, int row)
		{
			//IL_0024: Expected I4, but got I8
			if (row >= rows)
			{
				return;
			}
			int num = col | row;
			if ((int)(num & 0x80000000L) == 0 && col < columns)
			{
				int num2 = row * columns;
				int num3 = col + num2;
				if (((visited[num3] ? 1u : 0u) & 1u) == 0 && IsWallCell(em, gridHandler, col, row))
				{
					visited[num3] = true;
					(int, int) item = (col, row);
					queue.Enqueue(item);
				}
			}
		}

		[Token(Token = "0x6001488")]
		[Address(RVA = "0x3CF8F80", Offset = "0x3CF8F80", Length = "0x74")]
		private static bool IsWallCell(EntityManager em, TopGridHandler gridHandler, int col, int row)
		{
			GridCoord coord = new GridCoord(col, row);
			Entity wallAt = gridHandler.GetWallAt(coord);
			return em.IsValid(wallAt);
		}

		[Token(Token = "0x6001489")]
		[Address(RVA = "0x3CF7B28", Offset = "0x3CF7B28", Length = "0x8F0")]
		private unsafe static List<WallSegment> BuildComponentPerimeter(List<(int col, int row)> component, float4x4 localToWorld, float cs, float gw, float gh, float padding)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FrameDataCalculator::BuildComponentPerimeter");
			return default;
		}

		[Token(Token = "0x600148A")]
		[Address(RVA = "0x3CF9128", Offset = "0x3CF9128", Length = "0x244")]
		private static float2 ComputeVertexLocal(int col, int row, HashSet<(int col, int row)> memberSet, float padding, float cs, float gw, float gh)
		{
			//IL_00a6: Expected O, but got I4
			//IL_00b3: Expected O, but got I4
			//IL_00c2: Expected O, but got I
			int item = col - 1;
			(int, int) item2 = (item, row);
			bool flag = memberSet.Contains(item2);
			(int, int) item3 = (col, row);
			bool flag2 = memberSet.Contains(item3);
			int item4 = row - 1;
			(int, int) item5 = (item, item4);
			bool flag3 = memberSet.Contains(item5);
			(int, int) item6 = (col, item4);
			bool flag4 = memberSet.Contains(item6);
			object obj = (flag2 ? 1 : 0) + (flag ? 1 : 0);
			object obj2 = (flag3 ? 1 : 0) + (flag4 ? 1 : 0);
			object obj3 = (nint)obj + (nint)obj2;
			float num;
			float num2 = default(float);
			if ((nint)obj3 != 3)
			{
				if ((nint)obj3 != 2)
				{
					bool flag5 = (nint)obj3 != 1;
					num = 0f;
					if (!flag5)
					{
						num = 0f - num2;
						if (!flag)
						{
							float num3 = ((!flag3) ? num2 : num);
							bool flag6 = !flag2;
							if (!flag6)
							{
							}
							if (flag6)
							{
								num2 = num3;
							}
							num = num2;
						}
					}
				}
				else
				{
					bool flag7 = flag2 && flag;
					bool flag8 = !flag7;
					num = 0f;
					if (flag8)
					{
						if (flag4 && flag3)
						{
							num = 0f;
						}
						else if (flag3 && flag)
						{
							num = 0f - num2;
						}
						else
						{
							if (!(flag4 && flag2))
							{
								num2 = 0f;
							}
							num = num2;
						}
					}
				}
			}
			else
			{
				float num4 = 0f - num2;
				float num5 = ((!flag3) ? num2 : num4);
				bool flag9 = !flag2;
				if (!flag9)
				{
				}
				float num6 = (flag9 ? num4 : num5);
				if (!flag)
				{
				}
				num = (flag ? num6 : num2);
			}
			float num7 = (float)col * cs;
			float num8 = gw * 0.5f;
			float num9 = num7 - num8;
			float x = num9 + num;
			float2 result = default(float2);
			result.x = x;
			return result;
		}

		[Token(Token = "0x600148B")]
		[Address(RVA = "0x3CF936C", Offset = "0x3CF936C", Length = "0x78C")]
		private unsafe static List<(float2, float2)> MergeColinearEdges(List<(float2 from, float2 to)> edges)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FrameDataCalculator::MergeColinearEdges");
			return default;
		}

		[Token(Token = "0x600148C")]
		[Address(RVA = "0x3CF9AF8", Offset = "0x3CF9AF8", Length = "0x234")]
		private static void MergeHorizontal(List<(float y, float fromX, float toX)> segs, List<(float2 from, float2 to)> result)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FrameDataCalculator::MergeHorizontal");
		}

		[Token(Token = "0x600148D")]
		[Address(RVA = "0x3CF9D2C", Offset = "0x3CF9D2C", Length = "0x234")]
		private static void MergeVertical(List<(float x, float fromY, float toY)> segs, List<(float2 from, float2 to)> result)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FrameDataCalculator::MergeVertical");
		}

		[Token(Token = "0x600148E")]
		[Address(RVA = "0x3CF8418", Offset = "0x3CF8418", Length = "0x1A0")]
		private unsafe static List<WallSegment> ClipPerimeterToPresetPolygons(List<WallSegment> perimeter, List<List<float2>> presetPolygons)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FrameDataCalculator::ClipPerimeterToPresetPolygons");
			return default;
		}

		[Token(Token = "0x600148F")]
		[Address(RVA = "0x3CF9F60", Offset = "0x3CF9F60", Length = "0x6D0")]
		private unsafe static void ClipSegmentToPresetPolygons(WallSegment seg, List<List<float2>> presetPolygons, List<WallSegment> output)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FrameDataCalculator::ClipSegmentToPresetPolygons");
		}

		[Token(Token = "0x6001490")]
		[Address(RVA = "0x3CFA630", Offset = "0x3CFA630", Length = "0x1D4")]
		private static bool SegmentSegmentIntersectionT(float2 a, float2 b, float2 c, float2 d, out float t)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FrameDataCalculator::SegmentSegmentIntersectionT");
			t = default;
			return default;
		}

		[Token(Token = "0x6001491")]
		[Address(RVA = "0x3CFA804", Offset = "0x3CFA804", Length = "0xCC")]
		private static bool IsInsideAnyPolygon(float2 p, List<List<float2>> polygons)
		{
			if (polygons.Count >= 1)
			{
				int num = 0;
				bool flag;
				do
				{
					List<float2> polygon = polygons[num];
					flag = MeshGenUtils.IsPointInPolygon(p, polygon);
					if (flag)
					{
						break;
					}
					num++;
				}
				while (num < polygons.Count);
				return flag;
			}
			return false;
		}
	}
}
