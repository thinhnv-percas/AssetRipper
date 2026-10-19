using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Orchestrator
{
	[Serializable]
	[Token(Token = "0x200035D")]
	public class DifficultyOrder
	{
		[Token(Token = "0x40009E4")]
		[FieldOffset(Offset = "0x10")]
		public LevelDifficulty difficulty;

		[Token(Token = "0x40009E5")]
		[FieldOffset(Offset = "0x14")]
		public int count;

		[Token(Token = "0x40009E6")]
		[FieldOffset(Offset = "0x18")]
		public string notes;

		[Token(Token = "0x6000E08")]
		[Address(RVA = "0x3F02CAC", Offset = "0x3F02CAC", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\nL_0019:\n\tthis.notes = \"\";\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public DifficultyOrder()
		{
			notes = "";
		}
	}
}
