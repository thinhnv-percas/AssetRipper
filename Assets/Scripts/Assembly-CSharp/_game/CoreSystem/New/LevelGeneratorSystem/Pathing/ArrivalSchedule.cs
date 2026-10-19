using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Pathing
{
	[Token(Token = "0x2000355")]
	public sealed class ArrivalSchedule
	{
		[Token(Token = "0x40009CB")]
		[FieldOffset(Offset = "0x10")]
		public readonly int[] StepUnits;

		[Token(Token = "0x40009CC")]
		[FieldOffset(Offset = "0x18")]
		public readonly GameColor[] StepColor;

		[Token(Token = "0x40009CD")]
		[FieldOffset(Offset = "0x20")]
		public readonly int[] CumulativeUnits;

		[Token(Token = "0x40009CE")]
		[FieldOffset(Offset = "0x28")]
		public readonly GameColor[][] StepAlternatives;

		[Token(Token = "0x17000109")]
		public int StepCount
		{
			[Token(Token = "0x6000DF7")]
			[Address(RVA = "0x3F00D1C", Offset = "0x3F00D1C", Length = "0x1C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this.StepUnits;\n\treturn v0.Length;\n")]
			get
			{
				int[] stepUnits = StepUnits;
				return stepUnits.Length;
			}
		}

		[Token(Token = "0x6000DF8")]
		[Address(RVA = "0x3F00D38", Offset = "0x3F00D38", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.StepUnits = stepUnits;\n\tthis.StepColor = stepColor;\n\tthis.CumulativeUnits = cumulativeUnits;\n\tthis.StepAlternatives = 0;\n\treturn;\n")]
		public ArrivalSchedule(int[] stepUnits, GameColor[] stepColor, int[] cumulativeUnits)
		{
			StepUnits = stepUnits;
			StepColor = stepColor;
			CumulativeUnits = cumulativeUnits;
			StepAlternatives = null;
		}

		[Token(Token = "0x6000DF9")]
		[Address(RVA = "0x3F00DAC", Offset = "0x3F00DAC", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\tthis.StepUnits = stepUnits;\n\tthis.StepColor = stepColor;\n\tthis.CumulativeUnits = cumulativeUnits;\n\tthis.StepAlternatives = stepAlternatives;\n\treturn;\n")]
		public ArrivalSchedule(int[] stepUnits, GameColor[] stepColor, int[] cumulativeUnits, GameColor[][] stepAlternatives)
		{
			StepUnits = stepUnits;
			StepColor = stepColor;
			CumulativeUnits = cumulativeUnits;
			StepAlternatives = stepAlternatives;
		}
	}
}
