using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.BriefFactory
{
	[Serializable]
	[Token(Token = "0x20003B0")]
	public class FeatureEnvelope
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20003B1")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000B68")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000B69")]
			public static Func<LevelFeatures, int> _003C_003E9__16_0;

			[Token(Token = "0x4000B6A")]
			public static Func<LevelFeatures, int> _003C_003E9__16_1;

			[Token(Token = "0x4000B6B")]
			public static Func<LevelFeatures, int> _003C_003E9__16_2;

			[Token(Token = "0x4000B6C")]
			public static Func<LevelFeatures, int> _003C_003E9__16_3;

			[Token(Token = "0x4000B6D")]
			public static Func<LevelFeatures, int> _003C_003E9__16_4;

			[Token(Token = "0x4000B6E")]
			public static Func<LevelFeatures, int> _003C_003E9__16_5;

			[Token(Token = "0x4000B6F")]
			public static Func<LevelFeatures, int> _003C_003E9__16_6;

			[Token(Token = "0x4000B70")]
			public static Func<LevelFeatures, int> _003C_003E9__16_7;

			[Token(Token = "0x4000B71")]
			public static Func<LevelFeatures, int> _003C_003E9__16_8;

			[Token(Token = "0x4000B72")]
			public static Func<LevelFeatures, int> _003C_003E9__16_9;

			[Token(Token = "0x4000B73")]
			public static Func<LevelFeatures, int> _003C_003E9__16_10;

			[Token(Token = "0x4000B74")]
			public static Func<LevelFeatures, int> _003C_003E9__16_11;

			[Token(Token = "0x4000B75")]
			public static Func<LevelFeatures, int> _003C_003E9__16_12;

			[Token(Token = "0x4000B76")]
			public static Func<LevelFeatures, int> _003C_003E9__16_13;

			[Token(Token = "0x4000B77")]
			public static Func<LevelFeatures, int> _003C_003E9__16_14;

			[Token(Token = "0x4000B78")]
			public static Func<int, int> _003C_003E9__17_0;

			[Token(Token = "0x4000B79")]
			public static Func<int, bool> _003C_003E9__17_1;

			[Token(Token = "0x6000F5F")]
			[Address(RVA = "0x3C9D80C", Offset = "0x3C9D80C", Length = "0x64")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000F60")]
			[Address(RVA = "0x3C9D870", Offset = "0x3C9D870", Length = "0x8")]
			public _003C_003Ec()
			{
			}

			internal int _003CBuild_003Eb__16_0(LevelFeatures x)
			{
				return x.sandCubeCount;
			}

			internal int _003CBuild_003Eb__16_1(LevelFeatures x)
			{
				return x.tunnelQueuedCubeCount;
			}

			internal int _003CBuild_003Eb__16_2(LevelFeatures x)
			{
				return x.distinctColorCount;
			}

			internal int _003CBuild_003Eb__16_3(LevelFeatures x)
			{
				return x.entryPointCount;
			}

			internal int _003CBuild_003Eb__16_4(LevelFeatures x)
			{
				return x.tunnelCount;
			}

			internal int _003CBuild_003Eb__16_5(LevelFeatures x)
			{
				return x.linkedCount;
			}

			internal int _003CBuild_003Eb__16_6(LevelFeatures x)
			{
				return x.hiddenCount;
			}

			internal int _003CBuild_003Eb__16_7(LevelFeatures x)
			{
				return x.pinCount;
			}

			internal int _003CBuild_003Eb__16_8(LevelFeatures x)
			{
				return x.garageCount;
			}

			internal int _003CBuild_003Eb__16_9(LevelFeatures x)
			{
				return x.hammerAreaCount;
			}

			internal int _003CBuild_003Eb__16_10(LevelFeatures x)
			{
				return x.lockCount;
			}

			internal int _003CBuild_003Eb__16_11(LevelFeatures x)
			{
				return x.keyCount;
			}

			internal int _003CBuild_003Eb__16_12(LevelFeatures x)
			{
				return x.snakeCount;
			}

			internal int _003CBuild_003Eb__16_13(LevelFeatures x)
			{
				return x.gridColumns;
			}

			internal int _003CBuild_003Eb__16_14(LevelFeatures x)
			{
				return x.gridRows;
			}

			internal int _003CStat_003Eb__17_0(int v)
			{
				return v;
			}

			internal bool _003CStat_003Eb__17_1(int v)
			{
				bool flag = v < 0;
				bool flag2 = v == 0;
				int num = v ^ v;
				int num2 = v & num;
				bool flag3 = num2 < 0;
				bool flag4 = flag == flag3;
				bool flag5 = !flag2;
				return flag4 && flag5;
			}
		}

		[Token(Token = "0x4000B58")]
		[FieldOffset(Offset = "0x10")]
		public int levelCount;

		[Token(Token = "0x4000B59")]
		[FieldOffset(Offset = "0x18")]
		public FeatureStat sandCubeCount;

		[Token(Token = "0x4000B5A")]
		[FieldOffset(Offset = "0x20")]
		public FeatureStat tunnelQueuedCubeCount;

		[Token(Token = "0x4000B5B")]
		[FieldOffset(Offset = "0x28")]
		public FeatureStat distinctColorCount;

		[Token(Token = "0x4000B5C")]
		[FieldOffset(Offset = "0x30")]
		public FeatureStat entryPointCount;

		[Token(Token = "0x4000B5D")]
		[FieldOffset(Offset = "0x38")]
		public FeatureStat tunnelCount;

		[Token(Token = "0x4000B5E")]
		[FieldOffset(Offset = "0x40")]
		public FeatureStat linkedCount;

		[Token(Token = "0x4000B5F")]
		[FieldOffset(Offset = "0x48")]
		public FeatureStat hiddenCount;

		[Token(Token = "0x4000B60")]
		[FieldOffset(Offset = "0x50")]
		public FeatureStat pinCount;

		[Token(Token = "0x4000B61")]
		[FieldOffset(Offset = "0x58")]
		public FeatureStat garageCount;

		[Token(Token = "0x4000B62")]
		[FieldOffset(Offset = "0x60")]
		public FeatureStat hammerAreaCount;

		[Token(Token = "0x4000B63")]
		[FieldOffset(Offset = "0x68")]
		public FeatureStat lockCount;

		[Token(Token = "0x4000B64")]
		[FieldOffset(Offset = "0x70")]
		public FeatureStat keyCount;

		[Token(Token = "0x4000B65")]
		[FieldOffset(Offset = "0x78")]
		public FeatureStat snakeCount;

		[Token(Token = "0x4000B66")]
		[FieldOffset(Offset = "0x80")]
		public FeatureStat gridColumns;

		[Token(Token = "0x4000B67")]
		[FieldOffset(Offset = "0x88")]
		public FeatureStat gridRows;

		[Token(Token = "0x6000F5B")]
		[Address(RVA = "0x3C9C80C", Offset = "0x3C9C80C", Length = "0xBF4")]
		public static FeatureEnvelope Build(IReadOnlyList<LevelFeatures> levels)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("FeatureEnvelope::Build");
			return default;
		}

		[Token(Token = "0x6000F5C")]
		[Address(RVA = "0x3C9D400", Offset = "0x3C9D400", Length = "0x30C")]
		private static FeatureStat Stat(IReadOnlyList<LevelFeatures> levels, Func<LevelFeatures, int> sel)
		{
			IEnumerable<int> source = levels.Select((Func<object, int>)sel);
			Func<int, int> keySelector = _003C_003Ec._003C_003E9__17_0;
			if (_003C_003Ec._003C_003E9__17_0 == null)
			{
				keySelector = (_003C_003Ec._003C_003E9__17_0 = (int v) => v);
			}
			IOrderedEnumerable<int> source2 = source.OrderBy(keySelector);
			List<int> list = source2.ToList();
			Func<int, bool> predicate = _003C_003Ec._003C_003E9__17_1;
			if (_003C_003Ec._003C_003E9__17_1 == null)
			{
				predicate = (_003C_003Ec._003C_003E9__17_1 = delegate(int v)
				{
					bool flag = v < 0;
					bool flag2 = v == 0;
					int num5 = v ^ v;
					int num6 = v & num5;
					bool flag3 = num6 < 0;
					bool flag4 = flag == flag3;
					bool flag5 = !flag2;
					return flag4 && flag5;
				});
			}
			int num = list.Count(predicate);
			FeatureStat featureStat = new FeatureStat();
			int min = list.First();
			featureStat.min = min;
			int max = list.Last();
			featureStat.max = max;
			int num2 = list.Count >> 31;
			int num3 = list.Count + num2;
			int index = num3 >> 1;
			int median = list[index];
			featureStat.median = median;
			int p = Percentile(list, 0.25);
			featureStat.p25 = p;
			int p2 = Percentile(list, 0.5000000000582077);
			featureStat.p75 = p2;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
			int num4 = num / list.Count;
			featureStat.presenceRate = num4;
			return featureStat;
		}

		[Token(Token = "0x6000F5D")]
		[Address(RVA = "0x3C9D70C", Offset = "0x3C9D70C", Length = "0x100")]
		private static int Percentile(List<int> sorted, double p)
		{
			//IL_00a5: Expected I4, but got F8
			if (sorted.Count != 0)
			{
				double num = (double)sorted.Count * p;
				double num2 = Math.Ceiling(num);
				double num3 = num - 5E-324;
				int val = ((num2 != 9.218868437227405E+18) ? ((int)num3) : 2147483647);
				int val2 = Math.Max(val, 0);
				int val3 = sorted.Count - 1;
				int index = Math.Min(val2, val3);
				return sorted[index];
			}
			return 0;
		}

		[Token(Token = "0x6000F5E")]
		[Address(RVA = "0x3C9C268", Offset = "0x3C9C268", Length = "0x8")]
		public FeatureEnvelope()
		{
		}
	}
}
