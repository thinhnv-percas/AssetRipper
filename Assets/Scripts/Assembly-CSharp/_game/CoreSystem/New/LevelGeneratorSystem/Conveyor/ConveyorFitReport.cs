using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Conveyor
{
	[Token(Token = "0x2000398")]
	public readonly struct ConveyorFitReport
	{
		[Token(Token = "0x4000AFE")]
		[FieldOffset(Offset = "0x0")]
		public readonly float Mae;

		[Token(Token = "0x4000AFF")]
		[FieldOffset(Offset = "0x4")]
		public readonly float MaxAbsDeviation;

		[Token(Token = "0x4000B00")]
		[FieldOffset(Offset = "0x8")]
		public readonly int MaxDeviationStep;

		[Token(Token = "0x4000B01")]
		[FieldOffset(Offset = "0xC")]
		public readonly float AvgActual;

		[Token(Token = "0x4000B02")]
		[FieldOffset(Offset = "0x10")]
		public readonly float AvgExpected;

		[Token(Token = "0x4000B03")]
		[FieldOffset(Offset = "0x14")]
		public readonly int StepCount;

		[Token(Token = "0x17000131")]
		public static ConveyorFitReport NoMeasurement
		{
			[Token(Token = "0x6000F1F")]
			[Address(RVA = "0x3C95B68", Offset = "0x3C95B68", Length = "0x1C")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("ConveyorFitReport::get_NoMeasurement");
				return default;
			}
		}

		[Token(Token = "0x6000F1E")]
		[Address(RVA = "0x3C95B84", Offset = "0x3C95B84", Length = "0x14")]
		public ConveyorFitReport(float mae, float maxAbsDev, int maxDevStep, float avgActual, float avgExpected, int stepCount)
		{
			Mae = mae;
			MaxAbsDeviation = maxAbsDev;
			MaxDeviationStep = maxDevStep;
			AvgActual = avgActual;
			AvgExpected = avgExpected;
			StepCount = stepCount;
		}
	}
}
