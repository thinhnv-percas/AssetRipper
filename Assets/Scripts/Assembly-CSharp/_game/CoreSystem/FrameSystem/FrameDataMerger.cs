using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;
using _game.CoreSystem.FrameSystem.MeshGen;

namespace _game.CoreSystem.FrameSystem
{
	[Token(Token = "0x20004E1")]
	public static class FrameDataMerger
	{
		[Token(Token = "0x20004E2")]
		public struct MergeResult
		{
			[Token(Token = "0x4001051")]
			[FieldOffset(Offset = "0x0")]
			public FrameData Data;

			[Token(Token = "0x4001052")]
			[FieldOffset(Offset = "0x20")]
			public List<List<float2>> MergedLoops;

			[Token(Token = "0x4001053")]
			[FieldOffset(Offset = "0x28")]
			public HashSet<long> OuterBoundaryKeys;
		}

		[Token(Token = "0x400104F")]
		private const float InwardOffset = 0.01f;

		[Token(Token = "0x4001050")]
		private const float UnchangedAreaRelativeEpsilon = 0.01f;

		[Token(Token = "0x6001498")]
		[Address(RVA = "0x3CFAAD4", Offset = "0x3CFAAD4", Length = "0x4C")]
		public unsafe static FrameData Merge(FrameData preset, FrameData custom, float2 playableSeedPoint)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FrameDataMerger::Merge");
			return default;
		}

		[Token(Token = "0x6001499")]
		[Address(RVA = "0x3CF5D3C", Offset = "0x3CF5D3C", Length = "0x504")]
		public unsafe static MergeResult MergeWithCache(FrameData preset, FrameData custom, float2 playableSeedPoint)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FrameDataMerger::MergeWithCache");
			return default;
		}

		[Token(Token = "0x600149A")]
		[Address(RVA = "0x3CFB19C", Offset = "0x3CFB19C", Length = "0x4")]
		public static float2 FindInteriorPointPublic(List<float2> loop)
		{
			return FindInteriorPoint(loop);
		}

		[Token(Token = "0x600149B")]
		[Address(RVA = "0x3CFACF0", Offset = "0x3CFACF0", Length = "0x2E8")]
		private static float2 FindInteriorPoint(List<float2> loop)
		{
			//IL_0331: Expected O, but got F4
			if (loop.Count > 2)
			{
				float2 zero = float2.zero;
				float num = float2.zero.y;
				int num2 = 0;
				float num3;
				bool flag;
				do
				{
					float2 float5 = loop[num2];
					num3 = zero.x + float5.x;
					num += float5.y;
					num2++;
					flag = num2 < loop.Count;
					zero.x = num3;
				}
				while (flag);
				float x = num3 / (float)loop.Count;
				float y = num / (float)loop.Count;
				float2 point = default(float2);
				point.x = x;
				point.y = y;
				bool flag2 = MeshGenUtils.IsPointInPolygon(point, loop);
				bool flag3 = !flag2;
				bool flag4 = !flag3;
				float2 result = default(float2);
				result.x = x;
				if (!flag4)
				{
					float num4 = MeshGenUtils.SignedArea(loop);
					bool flag5 = num4 < 0f;
					bool flag6 = num4 == 0f;
					bool flag7 = num4 == num4;
					bool flag8 = !flag7;
					bool flag9 = flag5 == flag8;
					bool flag10 = !flag6;
					float num5 = ((!(flag9 && flag10)) ? (-1f) : 1f);
					int count = loop.Count;
					bool flag11 = loop.Count < 1;
					result.x = x;
					if (!flag11)
					{
						int num6 = 0;
						float2 point2 = default(float2);
						while (true)
						{
							int num7 = num6 + 1;
							int num8 = num7 / count;
							int num9 = num8 * count;
							int index = num7 - num9;
							float2 float6 = loop[num6];
							float2 float7 = loop[index];
							float2 float8 = loop[index];
							float2 float9 = loop[num6];
							float num10 = float8.x - float9.x;
							float num11 = float8.y - float9.y;
							float num12 = num11 * num11;
							float num13 = num10 * num10;
							float f = num12 + num13;
							float num14 = Mathf.Sqrt(f);
							if (!(num14 < 0.0001f))
							{
								float num15 = float6.x + float7.x;
								float num16 = float6.y + float7.y;
								float num17 = num15 * 0.5f;
								float num18 = num16 * 0.5f;
								object obj = 0f - num11;
								float num19 = (float)obj / num14;
								float num20 = num10 / num14;
								float num21 = num5 * num19;
								float num22 = num5 * num20;
								float num23 = num21 * 0.01f;
								float num24 = num22 * 0.01f;
								float x2 = num17 + num23;
								float y2 = num18 + num24;
								point2.x = x2;
								point2.y = y2;
								if (MeshGenUtils.IsPointInPolygon(point2, loop))
								{
									result.x = x2;
									break;
								}
							}
							count = loop.Count;
							bool flag12 = num7 >= loop.Count;
							num6 = num7;
							if (!flag12)
							{
								continue;
							}
							result.x = x;
							break;
						}
					}
				}
				return result;
			}
			if (loop.Count > 0)
			{
				return loop[0];
			}
			return float2.zero;
		}

		[Token(Token = "0x600149C")]
		[Address(RVA = "0x3CFAFD8", Offset = "0x3CFAFD8", Length = "0x154")]
		private static int FindContainingLoop(float2 point, List<List<float2>> loops, float[] cachedAbsAreas)
		{
			int result;
			if (cachedAbsAreas != null)
			{
				if (loops.Count >= 1)
				{
					float num = 3.4028235E+38f;
					int num2 = 0;
					int num3 = -1;
					bool flag;
					do
					{
						List<float2> polygon = loops[num2];
						if (MeshGenUtils.IsPointInPolygon(point, polygon) && cachedAbsAreas[num2] < num)
						{
							num = cachedAbsAreas[num2];
							num3 = num2;
						}
						num2++;
						flag = num2 >= loops.Count;
						result = num3;
					}
					while (!flag);
					goto IL_0197;
				}
			}
			else if (loops.Count >= 1)
			{
				int num4 = 0;
				do
				{
					List<float2> polygon2 = loops[num4];
					bool flag2 = MeshGenUtils.IsPointInPolygon(point, polygon2);
					num4++;
				}
				while (num4 < loops.Count);
			}
			result = -1;
			goto IL_0197;
			IL_0197:
			return result;
		}

		[Token(Token = "0x600149D")]
		[Address(RVA = "0x3CFB12C", Offset = "0x3CFB12C", Length = "0x34")]
		private static int GetRegionType(int[] regionTypes, int index)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FrameDataMerger::GetRegionType");
			return default;
		}

		[Token(Token = "0x600149E")]
		[Address(RVA = "0x3CFB160", Offset = "0x3CFB160", Length = "0x3C")]
		private static bool GetGenerateMesh(bool[] generateMesh, int index)
		{
			if (generateMesh != null && generateMesh.Length > index)
			{
				return (byte)((generateMesh[index] ? 1u : 0u) & 1u) != 0;
			}
			return true;
		}

		[Token(Token = "0x600149F")]
		[Address(RVA = "0x3CFAB20", Offset = "0x3CFAB20", Length = "0x1D0")]
		private static FrameData DeepClone(FrameData source)
		{
			Array regionTypes;
			if (source.walls != null)
			{
				object obj = source.walls.Clone();
				if (obj != null)
				{
					Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
					object obj2 = default(object);
					if (obj2 == null)
					{
						goto IL_024c;
					}
					bool flag = source.regionTypes == null;
					regionTypes = source.regionTypes;
					if (!flag)
					{
						goto IL_0087;
					}
				}
				else
				{
					bool flag2 = source.regionTypes == null;
					bool flag3 = !flag2;
					regionTypes = source.regionTypes;
					if (flag3)
					{
						goto IL_0087;
					}
				}
			}
			else
			{
				bool flag4 = source.regionTypes == null;
				bool flag5 = !flag4;
				regionTypes = source.regionTypes;
				if (flag5)
				{
					goto IL_0087;
				}
			}
			bool flag6 = source.generateMesh == null;
			bool flag7 = !flag6;
			Array generateMesh = source.generateMesh;
			if (flag7)
			{
				goto IL_01eb;
			}
			goto IL_0252;
			IL_024c:
			throw new InvalidCastException();
			IL_0087:
			object obj3 = regionTypes.Clone();
			if (obj3 != null)
			{
				Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
				object obj4 = default(object);
				if (obj4 == null)
				{
					goto IL_024c;
				}
				bool flag8 = source.generateMesh == null;
				bool flag9 = !flag8;
				generateMesh = source.generateMesh;
				if (flag9)
				{
					goto IL_01eb;
				}
			}
			else
			{
				bool flag10 = source.generateMesh == null;
				generateMesh = source.generateMesh;
				if (!flag10)
				{
					goto IL_01eb;
				}
			}
			goto IL_0252;
			IL_0252:
			bool[] generateMesh2 = null;
			goto IL_027a;
			IL_027a:
			FrameData result = default(FrameData);
			WallSegment[] walls = default(WallSegment[]);
			result.walls = walls;
			result.generateMesh = generateMesh2;
			return result;
			IL_01eb:
			object obj5 = generateMesh.Clone();
			if (obj5 == null)
			{
				goto IL_0252;
			}
			Il2CppRuntime.Boundary("IL2CPP_RUNTIME", "Method not found @21C11D0");
			bool[] array = default(bool[]);
			bool flag11 = array == null;
			bool flag12 = !flag11;
			generateMesh2 = array;
			if (!flag12)
			{
				goto IL_024c;
			}
			goto IL_027a;
		}
	}
}
