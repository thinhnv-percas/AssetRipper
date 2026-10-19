using System;
using System.IO;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Report
{
	[Token(Token = "0x2000335")]
	public static class GenerationReportWriter
	{
		[Token(Token = "0x6000DB6")]
		[Address(RVA = "0x3EF7BB8", Offset = "0x3EF7BB8", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv63 = _game.CoreSystem.New.LevelGeneratorSystem.Report.OutcomeKind;\n\tv69 = System.Enum::ToString(&v63 @ stack_-58_v2 (Il2CppClass<_game.CoreSystem.New.LevelGeneratorSystem.Report.OutcomeKind>));\n\tv94 = System.String::ToLowerInvariant(v69);\n\tv132 = System.String::Concat(m.RunId, \"-\", v94, \".html\");\n\tgoto L_004B;\nL_004B:\n\tv141 = System.IO.Path::Combine(dir, v132);\n\tv144 = _game.CoreSystem.New.LevelGeneratorSystem.Report.GenerationReportHtml::Build(m);\n\tSystem.IO.File::WriteAllText(v141, v144);\n\treturn v141;\nL_0022:\n\tv50 = System.IO.Directory::CreateDirectory(dir);\n")]
		public static string Write(string dir, GenerationReportModel m)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("GenerationReportWriter::Write");
			return default;
		}
	}
}
