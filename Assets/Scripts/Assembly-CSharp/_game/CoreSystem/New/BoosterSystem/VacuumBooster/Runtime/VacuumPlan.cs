using System.Collections.Generic;
using Cpp2ILInjected;
using _game.CoreSystem.VacuumSystem;

namespace _game.CoreSystem.New.BoosterSystem.VacuumBooster.Runtime
{
	[Token(Token = "0x200044C")]
	public class VacuumPlan
	{
		[Token(Token = "0x4000DA0")]
		[FieldOffset(Offset = "0x10")]
		public int Capacity;

		[Token(Token = "0x4000DA1")]
		[FieldOffset(Offset = "0x14")]
		public int TotalGrains;

		[Token(Token = "0x4000DA2")]
		[FieldOffset(Offset = "0x18")]
		public readonly int[] GrainsByColor;

		[Token(Token = "0x4000DA3")]
		[FieldOffset(Offset = "0x20")]
		public readonly List<PlannedMold> Molds;

		[Token(Token = "0x4000DA4")]
		[FieldOffset(Offset = "0x28")]
		public VacuumScoringWeights Weights;

		[Token(Token = "0x1700018E")]
		public int MoldCount
		{
			[Token(Token = "0x6001219")]
			[Address(RVA = "0x3CCA174", Offset = "0x3CCA174", Length = "0x4C")]
			get
			{
				List<PlannedMold> molds = Molds;
				return molds.Count;
			}
		}

		[Token(Token = "0x1700018F")]
		public bool CapacityFullyUsed
		{
			[Token(Token = "0x600121A")]
			[Address(RVA = "0x3CCA1C0", Offset = "0x3CCA1C0", Length = "0x10")]
			get
			{
				int num = TotalGrains - Capacity;
				bool flag = num < 0;
				int num2 = TotalGrains ^ Capacity;
				int num3 = TotalGrains ^ num;
				int num4 = num2 & num3;
				bool flag2 = num4 < 0;
				return flag == flag2;
			}
		}

		[Token(Token = "0x600121B")]
		[Address(RVA = "0x3CCA1D0", Offset = "0x3CCA1D0", Length = "0xC4")]
		public VacuumPlan()
		{
			int[] grainsByColor = new int[13];
			GrainsByColor = grainsByColor;
			List<PlannedMold> molds = new List<PlannedMold>();
			Molds = molds;
		}
	}
}
