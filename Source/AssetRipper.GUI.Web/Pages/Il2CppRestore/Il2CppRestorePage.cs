namespace AssetRipper.GUI.Web.Pages.Il2CppRestore;

/// <summary>
/// Launches the standalone <c>AssetRipper.Il2CppRestore.Cli</c> tool against a game's
/// <c>global-metadata.dat</c> (and, optionally, its native binary) to rebuild a browsable/decompiled
/// project the way the guide this pipeline implements describes — a from-scratch alternative to
/// AssetRipper's own built-in IL2CPP handling, which only stubs method bodies rather than lifting them.
/// </summary>
/// <remarks>
/// This page only launches the tool as a subprocess and shows what it printed — see
/// <see cref="Il2CppRestoreResult"/> for why it is not called in-process.
/// </remarks>
public sealed class Il2CppRestorePage : DefaultPage
{
	public static Il2CppRestorePage Instance { get; } = new();

	public static Il2CppRestoreResult? LastResult { get; set; }

	public override string GetTitle() => "IL2CPP Restore";

	public override void WriteInnerContent(TextWriter writer)
	{
		new H1(writer).Close(GetTitle());

		using (new P(writer).WithClass("text-muted").End())
		{
			writer.Write("Runs the standalone IL2CPP restore pipeline: reads global-metadata.dat for type/method/field ");
			writer.Write("structure, and — when a binary is given too — disassembles and lifts method bodies into ");
			writer.Write("readable pseudocode using a struct DB folder for native field names. Leave the binary and ");
			writer.Write("struct DB empty to run \"fields only\" mode: types, fields, and empty method stubs, no ");
			writer.Write("disassembler needed.");
		}

		WriteForm(writer);

		if (LastResult is Il2CppRestoreResult result)
		{
			WriteResult(writer, result);
		}
	}

	private static void WriteForm(TextWriter writer)
	{
		using (new Form(writer).WithAction("/Il2CppRestore/Run").WithMethod("post").End())
		{
			WriteField(writer, "cliPath", "Il2CppRestore.Cli path", "text",
				"The built AssetRipper.Il2CppRestore.Cli.dll (or its published executable). Build that project separately first.");
			WriteField(writer, "metadataPath", "global-metadata.dat", "text",
				"Usually under <game>/il2cpp_data/Metadata/global-metadata.dat.");
			WriteField(writer, "binaryPath", "Native binary (optional)", "text",
				"libil2cpp.so, GameAssembly.dll, or libil2cpp.dylib. Leave empty for \"fields only\" mode — no lifting, just types and stubbed methods.");
			WriteField(writer, "structDbDirectory", "Struct DB folder (optional)", "text",
				"A folder of generated struct-layout JSON files (see structdb_gen.py). Only used when a binary is given; improves field names inside lifted method bodies.");
			WriteField(writer, "unityVersion", "Unity version (optional)", "text",
				"e.g. 2022.3.62f2 — used to pick the closest struct DB file in the folder above.");
			WriteField(writer, "outputPath", "Output directory", "text",
				"Where the dummy assemblies (fields-only mode) or the Assets/ project (with a binary) are written.");

			using (new Div(writer).WithClass("mb-3").End())
			{
				new Button(writer).WithType("submit").WithClass("btn btn-primary").Close("Run");
			}
		}
	}

	private static void WriteField(TextWriter writer, string name, string label, string type, string help)
	{
		using (new Div(writer).WithClass("mb-3").End())
		{
			new Label(writer).WithClass("form-label").WithFor(name).Close(label);
			new Input(writer).WithType(type).WithClass("form-control").WithId(name).WithName(name).Close();
			new Div(writer).WithClass("form-text").Close(help);
		}
	}

	private static void WriteResult(TextWriter writer, Il2CppRestoreResult result)
	{
		if (result.Error is string error)
		{
			new H2(writer).Close("Could not run");
			new P(writer).WithClass("text-danger").Close(error);
			return;
		}

		new H2(writer).Close(result.ExitCode == 0 ? "Finished" : $"Exited with code {result.ExitCode}");
		new Pre(writer).WithClass("bg-dark-subtle rounded-3 p-2").WithStyle("max-height: 60vh; overflow-y: auto;").Close(result.Output);
	}
}
