using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Conveyor
{
	[Token(Token = "0x2000397")]
	public static class ConveyorFitMetric
	{
		[Token(Token = "0x6000F1C")]
		[Address(RVA = "0x3C95804", Offset = "0x3C95804", Length = "0x364")]
		public static ConveyorFitReport Compute(IReadOnlyList<float> perStepFill, AnimationCurve curve)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConveyorFitMetric::Compute");
			return default;
		}

		[Token(Token = "0x6000F1D")]
		[Address(RVA = "0x3C95B98", Offset = "0x3C95B98", Length = "0x3E4")]
		public static ConveyorFitReport ComputeMoldUnits(IReadOnlyList<int> achieved, IReadOnlyList<int> target, int capacityInUnits)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ConveyorFitMetric::ComputeMoldUnits");
			return default;
		}
	}
}
