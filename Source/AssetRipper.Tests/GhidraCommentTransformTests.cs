using AssetRipper.Export.UnityProjects.Scripts;
using AssetRipper.Import.Structure.Assembly.Recovery.Ghidra;
using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.CSharp;
using ICSharpCode.Decompiler.Metadata;
using ICSharpCode.Decompiler.TypeSystem;

namespace AssetRipper.Tests;

/// <summary>
/// A stand in for a decompiled game type. The transform is run against this assembly, so the shape of
/// this class is what the keys in the tests refer to.
/// </summary>
public sealed class GhidraSampleTarget
{
	public int Add(int a, int b) => a + b;

	public void NoRecoveredCode()
	{
	}
}

public sealed class GhidraCommentTransformTests
{
	private const string SampleTypeName = "AssetRipper.Tests.GhidraSampleTarget";

	private static GhidraDecompilationIndex CreateIndex(params (string Key, string Code)[] entries)
	{
		StringWriter writer = new() { NewLine = "\n" };
		foreach ((string key, string code) in entries)
		{
			writer.Write(key);
			writer.Write('\t');
			writer.Write(code.Replace("\\", "\\\\").Replace("\n", "\\n").Replace("\t", "\\t"));
			writer.Write('\n');
		}
		return GhidraDecompilationIndex.Read(new StringReader(writer.ToString()));
	}

	private static string Decompile(GhidraCommentTransform transform)
	{
		string assemblyPath = typeof(GhidraSampleTarget).Assembly.Location;
		DecompilerSettings settings = new() { ThrowOnAssemblyResolveErrors = false };
		UniversalAssemblyResolver resolver = new(assemblyPath, false, null);

		CSharpDecompiler decompiler = new(assemblyPath, resolver, settings);
		decompiler.AstTransforms.Add(transform);

		return decompiler.DecompileTypeAsString(new FullTypeName(SampleTypeName));
	}

	[Test]
	public void RecoveredCodeIsAttachedAboveTheMatchingMethod()
	{
		GhidraDecompilationIndex index = CreateIndex(
			(GhidraDecompilationIndex.CreateKey(SampleTypeName, "Add", 2), "int Add(int p1,int p2)\n{\n  return p1 + p2;\n}"));

		GhidraCommentTransform transform = new(index);
		string output = Decompile(transform);

		using (Assert.EnterMultipleScope())
		{
			Assert.That(transform.AttachedCount, Is.EqualTo(1));
			Assert.That(output, Does.Contain("// Ghidra decompilation:"));
			// The multi line C body must survive the round trip through the index and become comments.
			Assert.That(output, Does.Contain("// int Add(int p1,int p2)"));
			Assert.That(output, Does.Contain("//   return p1 + p2;"));
			// It must land above the method it belongs to, not somewhere else in the file.
			Assert.That(output.IndexOf("// Ghidra decompilation:", StringComparison.Ordinal),
				Is.LessThan(output.IndexOf("public int Add(", StringComparison.Ordinal)));
		}
	}

	[Test]
	public void MethodsWithoutRecoveredCodeAreLeftAlone()
	{
		GhidraDecompilationIndex index = CreateIndex(
			(GhidraDecompilationIndex.CreateKey(SampleTypeName, "Add", 2), "int Add(void)\n{\n  return 0;\n}"));

		GhidraCommentTransform transform = new(index);
		string output = Decompile(transform);

		int commentIndex = output.IndexOf("// Ghidra decompilation:", StringComparison.Ordinal);
		int otherMethodIndex = output.IndexOf("NoRecoveredCode", StringComparison.Ordinal);

		using (Assert.EnterMultipleScope())
		{
			Assert.That(transform.AttachedCount, Is.EqualTo(1));
			// Only one comment block, and it is not the one before the untouched method.
			Assert.That(output.Split("// Ghidra decompilation:"), Has.Length.EqualTo(2));
			Assert.That(commentIndex, Is.LessThan(otherMethodIndex));
		}
	}

	[Test]
	public void OverlyLongBodiesAreTruncated()
	{
		string longCode = string.Join('\n', Enumerable.Range(0, 50).Select(static i => $"  line{i}();"));
		GhidraDecompilationIndex index = CreateIndex(
			(GhidraDecompilationIndex.CreateKey(SampleTypeName, "Add", 2), longCode));

		GhidraCommentTransform transform = new(index) { MaximumLines = 5 };
		string output = Decompile(transform);

		using (Assert.EnterMultipleScope())
		{
			Assert.That(output, Does.Contain("//   line4();"));
			Assert.That(output, Does.Not.Contain("//   line5();"));
			Assert.That(output, Does.Contain("// ... truncated"));
		}
	}

	[Test]
	public void NestedTypeSeparatorsAreNormalizedSoBothSidesAgree()
	{
		// Cpp2IL and ILSpy disagree on nested type separators, so the key has to be insensitive to it.
		using (Assert.EnterMultipleScope())
		{
			Assert.That(GhidraDecompilationIndex.CreateKey("A+B", "M", 0), Is.EqualTo(GhidraDecompilationIndex.CreateKey("A.B", "M", 0)));
			Assert.That(GhidraDecompilationIndex.CreateKey("A/B", "M", 0), Is.EqualTo(GhidraDecompilationIndex.CreateKey("A.B", "M", 0)));
		}
	}

	[Test]
	public void EscapedCharactersSurviveTheIndexRoundTrip()
	{
		const string code = "a\tb\nc\\d";
		GhidraDecompilationIndex index = CreateIndex(("K", code));

		Assert.That(index.TryGetCode("K", out string? recovered), Is.True);
		Assert.That(recovered, Is.EqualTo(code));
	}
}
