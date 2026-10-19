using System;
using System.Collections.Generic;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Analysis
{
	[Serializable]
	[Token(Token = "0x20003C4")]
	public class AlternativePathsResult
	{
		[Token(Token = "0x4000BD1")]
		[FieldOffset(Offset = "0x10")]
		public bool ok;

		[Token(Token = "0x4000BD2")]
		[FieldOffset(Offset = "0x18")]
		public string error;

		[Token(Token = "0x4000BD3")]
		[FieldOffset(Offset = "0x20")]
		public int sampled;

		[Token(Token = "0x4000BD4")]
		[FieldOffset(Offset = "0x24")]
		public int wins;

		[Token(Token = "0x4000BD5")]
		[FieldOffset(Offset = "0x28")]
		public int betterThanIntended;

		[Token(Token = "0x4000BD6")]
		[FieldOffset(Offset = "0x2C")]
		public bool intendedWin;

		[Token(Token = "0x4000BD7")]
		[FieldOffset(Offset = "0x30")]
		public int intendedSteps;

		[Token(Token = "0x4000BD8")]
		[FieldOffset(Offset = "0x34")]
		public float intendedAvgFill;

		[Token(Token = "0x4000BD9")]
		[FieldOffset(Offset = "0x38")]
		public float intendedPeakFill;

		[Token(Token = "0x4000BDA")]
		[FieldOffset(Offset = "0x40")]
		public List<AlternativePathEntry> top;

		[Token(Token = "0x6000F9A")]
		[Address(RVA = "0x3CA1E88", Offset = "0x3CA1E88", Length = "0x8C")]
		public AlternativePathsResult()
		{
			List<AlternativePathEntry> list = new List<AlternativePathEntry>();
			top = list;
		}
	}
}
