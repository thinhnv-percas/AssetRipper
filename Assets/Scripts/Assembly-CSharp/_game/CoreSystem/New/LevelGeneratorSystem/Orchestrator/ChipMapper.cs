using AssetRipperInjected;
using Cpp2ILInjected;
using _game.CoreSystem.New.LevelGeneratorSystem.Card;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Orchestrator
{
	[Token(Token = "0x200035C")]
	public static class ChipMapper
	{
		[Token(Token = "0x6000E07")]
		[Address(RVA = "0x3F02C84", Offset = "0x3F02C84", Length = "0x28")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv1 = phase - 1;\n\tif (solvable) goto L_FFFFFFFF;\n\tv30 = 2 + 1;\n\tgoto L_001B;\nL_FFFFFFFF:\n\tv30 = 2;\n\tgoto L_0021;\nL_FFFFFFFF:\n\tv30 = 0;\nL_FFFFFFFF:\n\treturnVal1 = 1;\n\tgoto L_0031;\nL_FFFFFFFF:\n\treturnVal1 = v30;\nL_001B:\n\tv27 = phase != 3;\n\tif (v27) goto L_FFFFFFFF;\nL_0021:\n\tv31 = v1 < 2;\n\tv32 = ~v31;\n\tv40 = ~v32;\n\tv41 = ~v40;\n\tif (v41) goto L_FFFFFFFF;\nL_0031:\n\treturn returnVal1;\n")]
		public static OrchestratorChip Map(LevelCardPhase phase, bool solvable)
		{
			int num = (int)(phase - 1);
			OrchestratorChip result = (solvable ? OrchestratorChip.Saved : OrchestratorChip.Failed);
			if (phase != LevelCardPhase.Done)
			{
				result = default(OrchestratorChip);
			}
			if ((uint)num < 2u)
			{
				return OrchestratorChip.Generating;
			}
			return result;
		}
	}
}
