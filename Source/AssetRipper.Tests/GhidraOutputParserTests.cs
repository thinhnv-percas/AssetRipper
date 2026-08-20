using AssetRipper.Import.Structure.Assembly.Recovery.Ghidra;

namespace AssetRipper.Tests;

/// <summary>
/// The progress reporting depends on reading Ghidra's own log format, so these pin down the exact
/// shapes the analyzer emits.
/// </summary>
public sealed class GhidraOutputParserTests
{
	[Test]
	public void ProgressIsReadFromScriptOutput()
	{
		const string line = "INFO  ExportIl2CppDecompilation.java> PROGRESS phase=decompiling done=1250 total=48000 (GhidraScript)  ";

		Assert.That(GhidraOutputParser.TryParseProgress(line, out string? phase, out int done, out int total), Is.True);
		using (Assert.EnterMultipleScope())
		{
			Assert.That(phase, Is.EqualTo("decompiling"));
			Assert.That(done, Is.EqualTo(1250));
			Assert.That(total, Is.EqualTo(48000));
		}
	}

	[Test]
	public void ResultIsReadFromScriptOutput()
	{
		const string line = "INFO  ExportIl2CppDecompilation.java> RESULT decompiled=1234 failed=56 (GhidraScript)  ";

		Assert.That(GhidraOutputParser.TryParseResult(line, out int decompiled, out int failed), Is.True);
		using (Assert.EnterMultipleScope())
		{
			Assert.That(decompiled, Is.EqualTo(1234));
			Assert.That(failed, Is.EqualTo(56));
		}
	}

	/// <summary>
	/// The count of functions named without being decompiled was added later, so both shapes parse.
	/// </summary>
	[Test]
	public void ResultIsReadWhenItReportsNamedOnlyFunctions()
	{
		const string line = "INFO  ExportIl2CppDecompilation.java> RESULT decompiled=1234 failed=56 named-only=89243 (GhidraScript)  ";

		Assert.That(GhidraOutputParser.TryParseResult(line, out int decompiled, out int failed), Is.True);
		using (Assert.EnterMultipleScope())
		{
			Assert.That(decompiled, Is.EqualTo(1234));
			Assert.That(failed, Is.EqualTo(56));
		}
	}

	[Test]
	public void OrdinaryLinesAreNotMistakenForProgressOrResults()
	{
		const string line = "INFO  REPORT: Analysis succeeded for file: file:///game/GameAssembly.dll (HeadlessAnalyzer)";

		using (Assert.EnterMultipleScope())
		{
			Assert.That(GhidraOutputParser.TryParseProgress(line, out _, out _, out _), Is.False);
			Assert.That(GhidraOutputParser.TryParseResult(line, out _, out _), Is.False);
		}
	}

	[TestCase("INFO  REPORT: Import succeeded (HeadlessAnalyzer)  ", "REPORT: Import succeeded")]
	[TestCase("INFO  ExportIl2CppDecompilation.java> Applied 40000 function names (GhidraScript)", "Applied 40000 function names")]
	[TestCase("WARN  Something looked odd (AutoAnalysisManager)", "Something looked odd")]
	public void TheLevelPrefixAndSourceSuffixAreStripped(string line, string expected)
	{
		Assert.That(GhidraOutputParser.Clean(line), Is.EqualTo(expected));
	}

	/// <summary>
	/// Ghidra spends its first seconds reporting on its own startup, which says nothing about the run.
	/// </summary>
	[TestCase("INFO  Searching for classes... (ClassSearcher)")]
	[TestCase("INFO  Loading user preferences: /root/.config/ghidra/preferences (Preferences)")]
	[TestCase("INFO  Initializing Random Number Generator... (SecureRandomFactory)")]
	[TestCase("    Call Convention ID                         0.031 secs")]
	[TestCase("-----------------------------------------------------")]
	[TestCase("")]
	// Separators and dangling source tags still carry Ghidra's level prefix.
	[TestCase("INFO  -----------------------------------------------------")]
	[TestCase("INFO   (AutoAnalysisManager)  ")]
	// Continuation lines of a multi line entry arrive indented and without a level prefix.
	[TestCase("  (ProgramLoader)  ")]
	// The JVM writes these before Ghidra starts logging.
	[TestCase("Picked up JAVA_TOOL_OPTIONS: -Dhttps.proxyHost=127.0.0.1")]
	[TestCase("openjdk version \"21.0.10\" 2026-01-20")]
	[TestCase("OpenJDK 64-Bit Server VM (build 21.0.10+7-Ubuntu-124.04, mixed mode)")]
	public void StartupNoiseAndTimingTablesAreNotLogged(string line)
	{
		Assert.That(GhidraOutputParser.IsWorthLogging(line), Is.False);
	}

	[TestCase("INFO  REPORT: Analysis succeeded for file: file:///game/GameAssembly.dll (HeadlessAnalyzer)")]
	[TestCase("ERROR Decompiling Foo failed: unsupported opcode (GhidraScript)")]
	public void MessagesAboutTheRunAreLogged(string line)
	{
		Assert.That(GhidraOutputParser.IsWorthLogging(line), Is.True);
	}

	[Test]
	public void ProgressIsFormattedWithAPercentage()
	{
		// The invariant culture puts a space before the percent sign.
		Assert.That(GhidraOutputParser.FormatProgress("decompiling", 1250, 48000), Is.EqualTo("Ghidra decompiling: 1250/48000 (2.6 %)"));
	}

	/// <summary>
	/// A total of zero would otherwise divide by zero.
	/// </summary>
	[Test]
	public void ProgressWithoutATotalIsStillFormatted()
	{
		Assert.That(GhidraOutputParser.FormatProgress("naming", 10, 0), Is.EqualTo("Ghidra naming: 10"));
	}

	[Test]
	public void TheResultIsFoundAnywhereInACapturedOutput()
	{
		const string output = """
			INFO  Applied 2 function names (GhidraScript)
			INFO  ExportIl2CppDecompilation.java> RESULT decompiled=7 failed=1 (GhidraScript)
			INFO  REPORT: Import succeeded (HeadlessAnalyzer)
			""";

		Assert.That(GhidraHeadlessRunner.TryParseResult(output, out int decompiled, out int failed), Is.True);
		using (Assert.EnterMultipleScope())
		{
			Assert.That(decompiled, Is.EqualTo(7));
			Assert.That(failed, Is.EqualTo(1));
		}
	}
}
