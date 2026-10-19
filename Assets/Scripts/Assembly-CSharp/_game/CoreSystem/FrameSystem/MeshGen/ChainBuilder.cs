using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;

namespace _game.CoreSystem.FrameSystem.MeshGen
{
	[Token(Token = "0x20004F9")]
	public static class ChainBuilder
	{
		[Token(Token = "0x20004FA")]
		private struct HalfEdge
		{
			[Token(Token = "0x40010B8")]
			[FieldOffset(Offset = "0x0")]
			public long fromKey;

			[Token(Token = "0x40010B9")]
			[FieldOffset(Offset = "0x8")]
			public long toKey;

			[Token(Token = "0x40010BA")]
			[FieldOffset(Offset = "0x10")]
			public float2 fromPos;

			[Token(Token = "0x40010BB")]
			[FieldOffset(Offset = "0x18")]
			public float2 toPos;

			[Token(Token = "0x40010BC")]
			[FieldOffset(Offset = "0x20")]
			public float angle;

			[Token(Token = "0x40010BD")]
			[FieldOffset(Offset = "0x24")]
			public bool used;
		}

		[CompilerGenerated]
		[Token(Token = "0x20004FB")]
		private sealed class _003C_003Ec__DisplayClass2_0
		{
			[Token(Token = "0x40010BE")]
			[FieldOffset(Offset = "0x10")]
			public List<HalfEdge> halfEdges;

			[Token(Token = "0x40010BF")]
			[FieldOffset(Offset = "0x18")]
			public Comparison<int> _003C_003E9__0;

			[Token(Token = "0x60014D8")]
			[Address(RVA = "0x3D03990", Offset = "0x3D03990", Length = "0x8")]
			public _003C_003Ec__DisplayClass2_0()
			{
			}

			internal unsafe int _003CBuildLoops_003Eb__0(int a, int b)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ChainBuilder._003C_003Ec__DisplayClass2_0::_003CBuildLoops_003Eb__0");
				return default;
			}
		}

		[Token(Token = "0x60014D3")]
		[Address(RVA = "0x3CFD898", Offset = "0x3CFD898", Length = "0x24")]
		public static List<List<float2>> BuildLoops(WallSegment[] segments, float epsilon = 0.001f)
		{
			HashSet<long> outerBoundaryKeys = null;
			return BuildLoops(segments, out outerBoundaryKeys, epsilon);
		}

		[Token(Token = "0x60014D4")]
		[Address(RVA = "0x3D02AA0", Offset = "0x3D02AA0", Length = "0xEF0")]
		public unsafe static List<List<float2>> BuildLoops(WallSegment[] segments, out HashSet<long> outerBoundaryKeys, float epsilon = 0.001f)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ChainBuilder::BuildLoops");
			outerBoundaryKeys = default;
			return default;
		}

		[Token(Token = "0x60014D5")]
		[Address(RVA = "0x3D03998", Offset = "0x3D03998", Length = "0xB7C")]
		private unsafe static WallSegment[] SplitAtTJunctions(WallSegment[] segments, float epsilon)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ChainBuilder::SplitAtTJunctions");
			return default;
		}

		[Token(Token = "0x60014D6")]
		[Address(RVA = "0x3D047C4", Offset = "0x3D047C4", Length = "0x134")]
		private static bool IsPointOnSegmentInterior(float2 P, float2 A, float2 B, float epsilon)
		{
			float num = B.x - A.x;
			float num2 = B.y - A.y;
			float num3 = num * num;
			float num4 = num2 * num2;
			float num5 = num3 + num4;
			float num6 = Mathf.Sqrt(num5);
			if (!(num6 < epsilon))
			{
				float num7 = P.x - A.x;
				float num8 = P.y - A.y;
				float num9 = num8 * num;
				float num10 = num7 * num2;
				float f = num9 - num10;
				float num11 = Mathf.Abs(f);
				float num12 = num6 * epsilon;
				bool flag = num11 < num12;
				bool flag2 = num11 == num12;
				bool flag3 = num11 == num11;
				bool flag4 = num12 == num12;
				bool flag5 = flag3 && flag4;
				bool flag6 = !flag5;
				bool flag7 = flag == flag6;
				bool flag8 = !flag2;
				if (!(flag7 && flag8))
				{
					float num13 = num7 * num;
					float num14 = num8 * num2;
					float num15 = num13 + num14;
					float num16 = num15 / num5;
					float num17 = epsilon / num6;
					bool flag9 = num16 < num17;
					bool flag10 = num16 == num17;
					bool flag11 = num16 == num16;
					bool flag12 = num17 == num17;
					bool flag13 = flag11 && flag12;
					bool flag14 = !flag13;
					bool flag15 = flag9 == flag14;
					bool flag16 = !flag15;
					if (!(flag16 || flag10))
					{
						float num18 = 1f - num17;
						return num16 < num18;
					}
				}
			}
			return false;
		}

		[Token(Token = "0x60014D7")]
		[Address(RVA = "0x3D048F8", Offset = "0x3D048F8", Length = "0x1FC")]
		private static bool TrySegmentIntersection(float2 A, float2 B, float2 C, float2 D, float epsilon, out float2 intersection)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ChainBuilder::TrySegmentIntersection");
			intersection = default;
			return default;
		}
	}
}
