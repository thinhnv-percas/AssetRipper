using Cpp2ILInjected;
using Unity.Mathematics;
using UnityEngine;

namespace _game.CoreSystem.New.BoosterSystem.VacuumBooster.UnityBindings.Scripts
{
	[Token(Token = "0x2000445")]
	public static class VacuumPathSampler
	{
		[Token(Token = "0x60011EA")]
		[Address(RVA = "0x3CC5258", Offset = "0x3CC5258", Length = "0x288")]
		public static Vector3 EvaluateCatmullRom(Transform[] points, float t)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumPathSampler::EvaluateCatmullRom");
			return default;
		}

		[Token(Token = "0x60011EB")]
		[Address(RVA = "0x3CC5814", Offset = "0x3CC5814", Length = "0x228")]
		public static float3 EvaluateCatmullRom(NativeTubePath path, float t)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("VacuumPathSampler::EvaluateCatmullRom");
			return default;
		}

		[Token(Token = "0x60011EC")]
		[Address(RVA = "0x3CC5A3C", Offset = "0x3CC5A3C", Length = "0x238")]
		public static void GetTubeFrame(NativeTubePath path, float t, out float3 right, out float3 up)
		{
			right = default(float3);
			up = default(float3);
			float a = t + -0.01f;
			float t2 = Mathf.Max(a, 0f);
			float a2 = t + 0.01f;
			float t3 = Mathf.Min(a2, 1f);
			float3 float5 = EvaluateCatmullRom(path, t2);
			float3 float6 = EvaluateCatmullRom(path, t3);
			float num = float6.z - float5.z;
			float num2 = num * num;
			float num3 = float6.x - float5.x;
			float num4 = num3 * num3;
			float num5 = float6.y - float5.y;
			float num6 = num5 * num5;
			float num7 = num4 + num6;
			float num8 = num2 + num7;
			bool flag = num8 < 1.1754944E-38f;
			bool flag2 = num8 == 1.1754944E-38f;
			bool flag3 = num8 == num8;
			bool flag4 = !flag3;
			bool flag5 = flag == flag4;
			bool flag6 = !flag5;
			bool flag7 = flag6 || flag2;
			float num9 = Mathf.Sqrt(num8);
			float num10 = 1f / num9;
			float num11 = num * num10;
			bool flag8 = flag == flag4;
			bool flag9 = !flag8;
			float num12 = ((!(flag9 || flag2)) ? num11 : 0f);
			float num13 = Mathf.Abs(num11);
			float num14 = num3 * num10;
			bool flag10 = flag == flag4;
			bool flag11 = !flag10;
			if (flag11 || flag2)
			{
				num14 = 0f;
			}
			float num15 = num5 * num10;
			bool flag12 = flag == flag4;
			bool flag13 = !flag12;
			if (flag13 || flag2)
			{
				num15 = 0f;
			}
			bool flag14 = num13 < 0.99f || flag7;
			bool flag15 = !flag14;
			float num16 = (flag15 ? 1f : 0f);
			float num17 = num12 * num16;
			float num18 = (flag15 ? 0f : 1f);
			float num19 = num14 * num18;
			float num20 = num17 - num19;
			float num21 = num15 * num18;
			float num22 = num12 * 0f;
			float num23 = num21 - num22;
			float num24 = num14 * 0f;
			float num25 = num15 * num16;
			float num26 = num24 - num25;
			float num27 = num26 * num26;
			float num28 = num23 * num23;
			float num29 = num20 * num20;
			float num30 = num28 + num29;
			float num31 = num27 + num30;
			float num32 = Mathf.Sqrt(num31);
			float num33 = 1f / num32;
			float num34 = num23 * num33;
			float num35 = num20 * num33;
			float num36 = num26 * num33;
			bool flag16 = num31 < 1.1754944E-38f;
			bool flag17 = num31 == 1.1754944E-38f;
			bool flag18 = num31 == num31;
			bool flag19 = !flag18;
			bool flag20 = flag16 == flag19;
			bool flag21 = !flag17;
			if (!(flag20 && flag21))
			{
				num36 = 0f;
			}
			bool flag22 = flag16 == flag19;
			bool flag23 = !flag17;
			float num37 = ((!(flag22 && flag23)) ? 0f : num35);
			bool flag24 = flag16 == flag19;
			bool flag25 = !flag17;
			float num38 = (right.x = ((!(flag24 && flag25)) ? 0f : num34));
			right.y = num37;
			right.z = num36;
			float num39 = num15 * num38;
			float num40 = num12 * num37;
			float num41 = num14 * num36;
			float num42 = num14 * num37;
			float num43 = num15 * num36;
			float num44 = num12 * num38;
			float z = num39 - num42;
			float x = num40 - num43;
			float y = num41 - num44;
			up.x = x;
			up.y = y;
			up.z = z;
		}
	}
}
