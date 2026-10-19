using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;

namespace _game.CoreSystem.FrameSystem.MeshGen
{
	[Token(Token = "0x2000501")]
	public static class MeshGenUtils
	{
		[Token(Token = "0x40010C2")]
		public const float DefaultEpsilon = 0.001f;

		[Token(Token = "0x60014EF")]
		[Address(RVA = "0x3D063B8", Offset = "0x3D063B8", Length = "0x88")]
		public static float SignedArea(float2[] loop)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MeshGenUtils::SignedArea");
			return default;
		}

		[Token(Token = "0x60014F0")]
		[Address(RVA = "0x3CFD8BC", Offset = "0x3CFD8BC", Length = "0xF8")]
		public static float SignedArea(List<float2> loop)
		{
			if (loop.Count >= 1)
			{
				int num = -loop.Count;
				int num2 = 1;
				float num3 = 0f;
				int num7;
				do
				{
					int index = num2 - 1;
					float2 float5 = loop[index];
					int index2 = ((num + num2 != 0) ? num2 : 0);
					float2 float6 = loop[index2];
					float num4 = float5.x * float6.y;
					float num5 = float5.y * float6.x;
					float num6 = num4 - num5;
					num3 += num6;
					num2++;
					num7 = num + num2;
				}
				while (num7 != 1);
				return num3 * 0.5f;
			}
			return 0f;
		}

		[Token(Token = "0x60014F1")]
		[Address(RVA = "0x3D07C0C", Offset = "0x3D07C0C", Length = "0xBC")]
		public static bool IsPointInPolygon(float2 point, float2[] polygon)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MeshGenUtils::IsPointInPolygon");
			return default;
		}

		[Token(Token = "0x60014F2")]
		[Address(RVA = "0x3CFDB3C", Offset = "0x3CFDB3C", Length = "0x118")]
		public static bool IsPointInPolygon(float2 point, List<float2> polygon)
		{
			int index = polygon.Count - 1;
			bool flag = polygon.Count < 1;
			int num = 0;
			if (!flag)
			{
				int num2 = 0;
				int num3 = 0;
				bool flag20;
				do
				{
					float2 float5 = polygon[num3];
					float2 float6 = polygon[index];
					bool flag2 = float5.y < point.y;
					bool flag3 = float5.y == point.y;
					bool flag4 = float5.y == float5.y;
					bool flag5 = point.y == point.y;
					bool flag6 = flag4 && flag5;
					bool flag7 = !flag6;
					bool flag8 = flag2 == flag7;
					bool flag9 = !flag3;
					bool flag10 = flag8 && flag9;
					bool flag11 = float6.y < point.y;
					bool flag12 = float6.y == point.y;
					bool flag13 = float6.y == float6.y;
					bool flag14 = point.y == point.y;
					bool flag15 = flag13 && flag14;
					bool flag16 = !flag15;
					bool flag17 = flag11 == flag16;
					bool flag18 = !flag17;
					bool flag19 = flag18 || flag12;
					if (!(flag10 ^ flag19))
					{
						float num4 = float6.x - float5.x;
						float num5 = point.y - float5.y;
						float num6 = num5 * num4;
						float num7 = float6.y - float5.y;
						float num8 = num6 / num7;
						float num9 = float5.x + num8;
						if (point.x < num9)
						{
							num2 ^= 1;
						}
					}
					num3++;
					flag20 = polygon.Count == num3;
					index = num3;
					num = num2;
				}
				while (!flag20);
			}
			return (byte)(num & 1) != 0;
		}

		[Token(Token = "0x60014F3")]
		[Address(RVA = "0x3D084E0", Offset = "0x3D084E0", Length = "0x10")]
		public static float2 Perp(float2 v)
		{
			//IL_000e: Expected O, but got F4
			return (float2)(0f - v.y);
		}

		[Token(Token = "0x60014F4")]
		[Address(RVA = "0x3D04514", Offset = "0x3D04514", Length = "0x9C")]
		public static bool ApproxEqual(float2 a, float2 b, float eps = 0.001f)
		{
			float num = b.y - a.y;
			float num2 = b.x - a.x;
			float num3 = num2 * num2;
			float num4 = num * num;
			float f = num3 + num4;
			float num5 = Mathf.Sqrt(f);
			return num5 < eps;
		}

		[Token(Token = "0x60014F5")]
		[Address(RVA = "0x3D045B0", Offset = "0x3D045B0", Length = "0x214")]
		public static long QuantizeKey(float2 pos, float eps = 0.001f)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("MeshGenUtils::QuantizeKey");
			return default;
		}
	}
}
