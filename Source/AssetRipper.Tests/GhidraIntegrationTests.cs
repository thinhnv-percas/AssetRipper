using AssetRipper.Import.Structure.Assembly.Recovery.Ghidra;

namespace AssetRipper.Tests;

public sealed class GhidraIntegrationTests
{
	[Test]
	public void HeadlessAnalyzerPathFollowsTheInstallationLayout()
	{
		string path = GhidraInstallation.GetHeadlessAnalyzerPath("/opt/ghidra");

		Assert.That(path, Is.EqualTo(Path.Join("/opt/ghidra", "support", GhidraInstallation.HeadlessAnalyzerFileName)));
	}

	[Test]
	public void ADirectoryWithoutTheAnalyzerIsNotAnInstallation()
	{
		using (Assert.EnterMultipleScope())
		{
			Assert.That(GhidraInstallation.IsInstallationDirectory(Path.GetTempPath()), Is.False);
			Assert.That(GhidraInstallation.IsInstallationDirectory(""), Is.False);
		}
	}

	[Test]
	public void AnOverrideDirectoryIsPreferredWhenItIsAnInstallation()
	{
		string directory = Path.Join(Path.GetTempPath(), Path.GetRandomFileName());
		Directory.CreateDirectory(Path.Join(directory, "support"));
		File.WriteAllText(GhidraInstallation.GetHeadlessAnalyzerPath(directory), "");

		string? previous = GhidraInstallation.OverrideDirectory;
		try
		{
			GhidraInstallation.OverrideDirectory = directory;

			Assert.That(GhidraInstallation.TryLocate(out GhidraInstallation? installation), Is.True);
			Assert.That(installation!.Directory, Is.EqualTo(directory));
		}
		finally
		{
			GhidraInstallation.OverrideDirectory = previous;
			Directory.Delete(directory, true);
		}
	}

	[Test]
	public void SymbolsAreWrittenAsTabSeparatedHexAddresses()
	{
		Il2CppSymbolTable.Entry[] entries =
		[
			new(0x1149, "Assembly-CSharp", "CombatMath.ComputeDamage", "CombatMath|ComputeDamage|2"),
			new(0x7ff6_0000_115e, "Assembly-CSharp", "CombatMath.ApplyArmor", "CombatMath|ApplyArmor|2"),
		];

		StringWriter writer = new() { NewLine = "\n" };
		Il2CppSymbolTable.Write(entries, writer);

		string[] lines = writer.ToString().TrimEnd('\n').Split('\n');
		using (Assert.EnterMultipleScope())
		{
			Assert.That(lines[0], Does.StartWith("#"));
			Assert.That(lines[1], Is.EqualTo("0x1149\tAssembly-CSharp\tCombatMath.ComputeDamage\tCombatMath|ComputeDamage|2"));
			Assert.That(lines[2], Is.EqualTo("0x7ff60000115e\tAssembly-CSharp\tCombatMath.ApplyArmor\tCombatMath|ApplyArmor|2"));
		}
	}

	/// <summary>
	/// A tab inside a name would silently shift every following column.
	/// </summary>
	[Test]
	public void SeparatorsInsideNamesAreRemoved()
	{
		Il2CppSymbolTable.Entry[] entries = [new(0x10, "Group\tWithTab", "Name\nWithNewline", "Key")];

		StringWriter writer = new() { NewLine = "\n" };
		Il2CppSymbolTable.Write(entries, writer);

		string line = writer.ToString().TrimEnd('\n').Split('\n')[1];
		using (Assert.EnterMultipleScope())
		{
			Assert.That(line.Split('\t'), Has.Length.EqualTo(4));
			Assert.That(line, Is.EqualTo("0x10\tGroup WithTab\tName WithNewline\tKey"));
		}
	}

	[Test]
	public void ArgumentsMatchTheHeadlessAnalyzerCommandLine()
	{
		List<string> arguments = GhidraHeadlessRunner.BuildArguments(
			"/proj", "AssetRipper", "/game/GameAssembly.dll", "/scripts", "/symbols.tsv", "/out");

		using (Assert.EnterMultipleScope())
		{
			// The project directory and name are positional and must come first.
			Assert.That(arguments[0], Is.EqualTo("/proj"));
			Assert.That(arguments[1], Is.EqualTo("AssetRipper"));
			Assert.That(arguments, Does.Contain("-import").And.Contain("/game/GameAssembly.dll"));
			Assert.That(arguments, Does.Contain("-scriptPath").And.Contain("/scripts"));
			Assert.That(arguments, Does.Contain("-postScript").And.Contain(GhidraHeadlessRunner.ScriptName));
			// The script takes the symbol file and output directory as its own arguments.
			int scriptIndex = arguments.IndexOf(GhidraHeadlessRunner.ScriptName);
			Assert.That(arguments[scriptIndex + 1], Is.EqualTo("/symbols.tsv"));
			Assert.That(arguments[scriptIndex + 2], Is.EqualTo("/out"));
		}
	}

	[Test]
	public void TheResultLineIsParsedOutOfTheAnalyzerLog()
	{
		const string output = """
			INFO  Applied 2 function names (GhidraScript)
			INFO  ExportIl2CppDecompilation.java> RESULT decompiled=1234 failed=56 (GhidraScript)
			INFO  REPORT: Import succeeded (HeadlessAnalyzer)
			""";

		Assert.That(GhidraHeadlessRunner.TryParseResult(output, out int decompiled, out int failed), Is.True);
		using (Assert.EnterMultipleScope())
		{
			Assert.That(decompiled, Is.EqualTo(1234));
			Assert.That(failed, Is.EqualTo(56));
		}
	}

	[Test]
	public void OutputWithoutAResultLineIsNotTreatedAsSuccess()
	{
		Assert.That(GhidraHeadlessRunner.TryParseResult("ERROR: something went wrong", out _, out _), Is.False);
	}

	/// <summary>
	/// The script has to travel with the build, otherwise level 4 cannot run anywhere but a dev machine.
	/// </summary>
	[Test]
	public void TheGhidraScriptIsEmbeddedInTheBuild()
	{
		System.Reflection.Assembly assembly = typeof(GhidraInstallation).Assembly;
		string? resourceName = Array.Find(assembly.GetManifestResourceNames(),
			static name => name.EndsWith($"{GhidraHeadlessRunner.ScriptName}.java", StringComparison.Ordinal));

		Assert.That(resourceName, Is.Not.Null, "The Ghidra export script is not embedded in AssetRipper.Import.");

		using Stream stream = assembly.GetManifestResourceStream(resourceName!)!;
		using StreamReader reader = new(stream);
		string content = reader.ReadToEnd();

		using (Assert.EnterMultipleScope())
		{
			Assert.That(content, Does.Contain($"class {GhidraHeadlessRunner.ScriptName}"));
			// AssetRipper parses this line, so the two have to stay in agreement.
			Assert.That(content, Does.Contain("RESULT decompiled="));
		}
	}
}
