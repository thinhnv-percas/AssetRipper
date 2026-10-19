using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.BriefFactory
{
	[Token(Token = "0x20003AB")]
	public static class CorpusSampler
	{
		[Token(Token = "0x6000F51")]
		[Address(RVA = "0x3C9B564", Offset = "0x3C9B564", Length = "0x124")]
		public static int SampleCount(int total, float ratio)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CorpusSampler::SampleCount");
			return default;
		}

		[Token(Token = "0x6000F52")]
		[Address(RVA = "0x3C9B688", Offset = "0x3C9B688", Length = "0x29C")]
		public static List<int> SampleIndices(int total, float ratio, int seed)
		{
			float ratio2 = default(float);
			int num = SampleCount(total, ratio2);
			int capacity = Math.Max(0, total);
			List<int> list = new List<int>(capacity);
			if (total >= 1)
			{
				int num2 = 0;
				do
				{
					list.Add(num2);
					num2++;
				}
				while (total != num2);
			}
			Random random = new Random(seed);
			if (num >= 1)
			{
				if (list == null)
				{
					int num3 = random.Next(total);
					return (List<int>)(object)new NullReferenceException();
				}
				int num4 = total;
				int num5 = 0;
				do
				{
					int num6 = random.Next(num4);
					int index = num6 + num5;
					int value = list[index];
					int value2 = list[num5];
					list[num5] = value;
					int index2 = num6 + num5;
					list[index2] = value2;
					num5++;
					num4--;
				}
				while (num != num5);
			}
			return list.GetRange(0, num);
		}
	}
}
