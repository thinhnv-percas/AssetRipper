using AssetRipper.Export.UnityProjects.PackageRemapping;

namespace AssetRipper.GUI.Web.Pages.PackageRemapping;

/// <summary>
/// The page for replacing a ripped copy of a Unity package with the official one.
/// </summary>
/// <remarks>
/// The job takes three directories because the two halves of the answer live in different places: the
/// ripped and official packages say which guid becomes which, and the project is where the references
/// that have to be repointed actually are.
/// <para>
/// Nothing is written until a run is explicitly applied. The first run is a report, because rewriting
/// edits a whole project in place and is expensive to undo by hand.
/// </para>
/// </remarks>
public sealed class PackageRemapPage : DefaultPage
{
	public static PackageRemapPage Instance { get; } = new();

	/// <summary>
	/// The last run's result, held so the report can be read before deciding to apply it.
	/// </summary>
	public static PackageRemapResult? LastResult { get; set; }

	public override string GetTitle() => "Package Remapping";

	public override void WriteInnerContent(TextWriter writer)
	{
		new H1(writer).Close(GetTitle());

		using (new P(writer).WithClass("text-muted").End())
		{
			writer.Write("Repoints a project's references from a ripped package at the official one. ");
			writer.Write("Scripts are handled as well as shaders and other assets: a decompiled script and the ");
			writer.Write("assembly the official package ships differ in both halves of the reference, so rewriting ");
			writer.Write("only the guid leaves it broken while looking repaired.");
		}

		WriteForm(writer);

		if (LastResult is PackageRemapResult result)
		{
			WriteResult(writer, result);
		}
	}

	private static void WriteForm(TextWriter writer)
	{
		using (new Form(writer).WithAction("/PackageRemapping/Run").WithMethod("post").End())
		{
			WriteDirectoryField(writer, "rippedPackage", "Ripped package", "The decompiled copy inside the exported project, such as Assets/TextMesh Pro.");
			WriteDirectoryField(writer, "officialPackage", "Official package", "The real package, usually under Library/PackageCache.");
			WriteDirectoryField(writer, "projectAssets", "Project assets", "The folder whose references are rewritten, usually the project's Assets.");
			WriteDirectoryField(writer, "backupDirectory", "Backup directory", "Where a file is copied before it is changed. Leave empty only if the project is under version control.");

			using (new Div(writer).WithClass("mb-3").End())
			{
				new Button(writer).WithType("submit").WithClass("btn btn-primary").WithName("apply").WithValue("false").Close("Report only");
				writer.Write(' ');
				new Button(writer).WithType("submit").WithClass("btn btn-danger").WithName("apply").WithValue("true").Close("Apply changes");
			}
		}
	}

	private static void WriteDirectoryField(TextWriter writer, string name, string label, string help)
	{
		using (new Div(writer).WithClass("mb-3").End())
		{
			new Label(writer).WithClass("form-label").WithFor(name).Close(label);
			new Input(writer).WithType("text").WithClass("form-control").WithId(name).WithName(name).Close();
			new Div(writer).WithClass("form-text").Close(help);
		}
	}

	private static void WriteResult(TextWriter writer, PackageRemapResult result)
	{
		new H2(writer).Close(result.Applied ? "Applied" : "Report, nothing was written");

		if (result.Error is string error)
		{
			new P(writer).WithClass("text-danger").Close(error);
			return;
		}

		WriteCounts(writer, result);

		if (result.Conflicts.Count > 0)
		{
			new H3(writer).Close("Conflicts, which must be resolved before applying");
			using (new Ul(writer).End())
			{
				foreach (string conflict in result.Conflicts)
				{
					new Li(writer).Close(conflict);
				}
			}
		}

		if (result.UnresolvedByGuid.Count > 0)
		{
			new H3(writer).Close("References still pointing at the ripped package");
			new P(writer).WithClass("text-muted").Close("These are assets the official package has no counterpart for. Each one is a reference that will still be broken.");
			using (new Table(writer).WithClass("table table-sm").End())
			{
				using (new Tr(writer).End())
				{
					new Th(writer).Close("Guid");
					new Th(writer).Close("References");
				}

				foreach ((string guid, int count) in result.UnresolvedByGuid.OrderByDescending(static pair => pair.Value))
				{
					using (new Tr(writer).End())
					{
						new Td(writer).Close(guid);
						new Td(writer).Close(count.ToString());
					}
				}
			}
		}
	}

	private static void WriteCounts(TextWriter writer, PackageRemapResult result)
	{
		using (new Table(writer).WithClass("table table-sm w-auto").End())
		{
			WriteRow(writer, "Assets paired between the packages", result.Matches);
			WriteRow(writer, "Ripped assets with no counterpart", result.UnmatchedRipped);
			WriteRow(writer, "Types found in the official assemblies", result.ScriptTypes);
			WriteRow(writer, "Files scanned", result.FilesScanned);
			WriteRow(writer, result.Applied ? "Files changed" : "Files that would change", result.FilesChanged);
			WriteRow(writer, "Guid references rewritten", result.GuidsRewritten);
			WriteRow(writer, "Script references rewritten", result.ScriptReferencesRewritten);
		}

		static void WriteRow(TextWriter writer, string label, int value)
		{
			using (new Tr(writer).End())
			{
				new Td(writer).Close(label);
				new Td(writer).Close(value.ToString());
			}
		}
	}
}
