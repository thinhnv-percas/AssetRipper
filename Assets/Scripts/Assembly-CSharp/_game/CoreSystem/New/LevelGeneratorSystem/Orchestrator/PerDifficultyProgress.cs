using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Orchestrator
{
	[Serializable]
	[Token(Token = "0x2000367")]
	public class PerDifficultyProgress
	{
		[Token(Token = "0x4000A28")]
		[FieldOffset(Offset = "0x10")]
		public LevelDifficulty difficulty;

		[Token(Token = "0x4000A29")]
		[FieldOffset(Offset = "0x14")]
		public int total;

		[Token(Token = "0x4000A2A")]
		[FieldOffset(Offset = "0x18")]
		public int done;

		[Token(Token = "0x4000A2B")]
		[FieldOffset(Offset = "0x1C")]
		public int saved;

		[Token(Token = "0x4000A2C")]
		[FieldOffset(Offset = "0x20")]
		public int failed;

		[Token(Token = "0x1700010C")]
		public float Fraction
		{
			[Token(Token = "0x6000E10")]
			[Address(RVA = "0x3F03230", Offset = "0x3F03230", Length = "0x28")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = this.total < 1;\n\tif (v12) goto L_0013;\n\treturnVal1 = this.done / this.total;\n\treturn returnVal1;\nL_0013:\n\treturn 0;\n")]
			get
			{
				if (total >= 1)
				{
					return (float)done / (float)total;
				}
				return 0f;
			}
		}

		[Token(Token = "0x6000E11")]
		[Address(RVA = "0x3F03258", Offset = "0x3F03258", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public PerDifficultyProgress()
		{
		}
	}
}
