using AssetRipper.Export.UnityProjects.PackageRemapping;
using AssetRipper.GUI.Web.Paths;

namespace AssetRipper.GUI.Web.Pages.PackageRemapping;

/// <summary>
/// The page for saying where the official packages are.
/// </summary>
/// <remarks>
/// An export repoints a ripped project's references at the official packages, and the guids it needs
/// only exist in the packages themselves. A package cache is the obvious place to find them and not the
/// only one: it holds what a project has already resolved, so a package taken straight from its
/// repository, or checked out somewhere on disk, is not in any cache at all.
/// <para>
/// Nothing here rewrites anything. The sources are what the next export reads.
/// </para>
/// </remarks>
public sealed class PackageSourcesPage : DefaultPage
{
	public static PackageSourcesPage Instance { get; } = new();

	/// <summary>
	/// The last scan, held so its result survives the redirect the form posts through.
	/// </summary>
	public static List<PackageSourceResult>? LastScan { get; set; }

	/// <summary>
	/// What went wrong with the last thing a button did, for the actions with nothing else to show.
	/// </summary>
	public static string? LastMessage { get; set; }

	public override string GetTitle() => "Package Sources";

	/// <summary>
	/// The configuration as it is on disk right now.
	/// </summary>
	/// <remarks>
	/// It is read on every request rather than held, because an export writes to the same file when it
	/// records what it found, and a copy held here would put that back the way it was.
	/// </remarks>
	public static PackageRemapConfiguration LoadConfiguration() => PackageRemapConfiguration.Load(PackageRemapConfiguration.DefaultPath);

	public override void WriteInnerContent(TextWriter writer)
	{
		PackageRemapConfiguration configuration = LoadConfiguration();

		new H1(writer).Close(GetTitle());

		using (new P(writer).WithClass("text-muted").End())
		{
			writer.Write("Where an export looks for the official packages it repoints references at. Nothing about a ");
			writer.Write("ripped path says which package an asset came from, so assets are paired by identity: an ");
			writer.Write("assembly by its file name, a shader by the name it declares and then by its file name, ");
			writer.Write("everything else by a file name unique on both sides.");
		}

		using (new P(writer).WithClass("text-muted").End())
		{
			writer.Write("What the exported project's manifest asks for depends on where the package was found. A ");
			writer.Write("package cache holds what a registry has, so a version is enough. A folder and a repository ");
			writer.Write("are pointed at precisely because no registry has that package, so the manifest gets the path ");
			writer.Write("or the url instead — a version would name something else.");
		}

		if (LastMessage is string message)
		{
			new Div(writer).WithClass("alert alert-warning").Close(message.ToHtml());
		}

		WriteSources(writer, configuration);
		WriteAddForm(writer);
		WriteScan(writer);
	}

	private static void WriteSources(TextWriter writer, PackageRemapConfiguration configuration)
	{
		new H2(writer).Close("Sources");

		using (new Form(writer).WithAction("/PackageSources/Run").WithMethod("post").End())
		{
			using (new Table(writer).WithClass("table table-sm align-middle").End())
			{
				using (new Tr(writer).End())
				{
					new Th(writer).Close("Kind");
					new Th(writer).Close("Location");
					new Th(writer).Close("Revision");
					new Th(writer).Close("Subfolder");
					new Th(writer).Close("");
				}

				for (int i = 0; i < configuration.Sources.Count; i++)
				{
					WriteSourceRow(writer, configuration.Sources[i], i);
				}

				WriteCacheSettingRow(writer);
			}

			using (new Div(writer).WithClass("mb-3").End())
			{
				new Button(writer).WithType("submit").WithClass("btn btn-primary").WithName("action").WithValue("scan").Close("Scan");
				writer.Write(' ');
				new Button(writer).WithType("submit").WithClass("btn btn-secondary").WithName("action").WithValue("fetch").Close("Fetch git sources and scan");
			}

			new Div(writer).WithClass("form-text").Close("Scanning clones a git source that has never been fetched. Update brings one repository down again, and Fetch does that for all of them.");
		}
	}

	private static void WriteSourceRow(TextWriter writer, PackageSource source, int index)
	{
		using (new Tr(writer).WithClass(source.Enabled ? "" : "text-muted").End())
		{
			new Td(writer).Close(source.Kind.ToString());
			new Td(writer).Close(source.Location.ToHtml());
			new Td(writer).Close(source.Revision.ToHtml());
			new Td(writer).Close(source.Subfolder.ToHtml());

			using (new Td(writer).End())
			{
				if (source.Kind is PackageSourceKind.Git)
				{
					// Only a git source has anywhere to update from. A folder is already what it is.
					WriteRowButton(writer, "btn-outline-primary", $"update:{index}", "Update");
				}

				WriteRowButton(writer, "btn-outline-secondary", $"open:{index}", "Open folder");
				WriteRowButton(writer, source.Enabled ? "btn-outline-secondary" : "btn-outline-primary", $"toggle:{index}", source.Enabled ? "Disable" : "Enable");
				WriteRowButton(writer, "btn-outline-danger", $"remove:{index}", "Remove");
			}
		}
	}

	/// <summary>
	/// The cache path from the export settings, which is a source too and is not in this list.
	/// </summary>
	/// <remarks>
	/// It is shown because the page is meant to be the whole picture of where packages come from, and
	/// read only because the settings page is where it is set. It goes last, so a source added here wins
	/// over it when both hold the same package.
	/// </remarks>
	private static void WriteCacheSettingRow(TextWriter writer)
	{
		string? path = GameFileLoader.Settings.ExportSettings.OfficialPackageCachePath;
		if (string.IsNullOrWhiteSpace(path))
		{
			return;
		}

		using (new Tr(writer).End())
		{
			new Td(writer).Close("Cache");
			new Td(writer).Close(path.ToHtml());
			new Td(writer).Close("");
			new Td(writer).Close("");
			using (new Td(writer).End())
			{
				WriteRowButton(writer, "btn-outline-secondary", "opencache", "Open folder");
				new A(writer).WithClass("btn btn-sm btn-outline-secondary").WithHref("/Settings/Edit").Close("Change in settings");
			}
		}
	}

	private static void WriteRowButton(TextWriter writer, string style, string action, string label)
	{
		new Button(writer)
			.WithType("submit")
			.WithClass($"btn btn-sm {style} me-1")
			.WithName("action")
			.WithValue(action)
			.Close(label);
	}

	private static void WriteAddForm(TextWriter writer)
	{
		new H2(writer).Close("Add a source");

		using (new Form(writer).WithAction("/PackageSources/Run").WithMethod("post").End())
		{
			new Input(writer).WithType("hidden").WithName("action").WithValue("add").Close();

			using (new Div(writer).WithClass("mb-3").End())
			{
				new Label(writer).WithClass("form-label").WithFor("kind").Close("Kind");
				using (new Select(writer).WithClass("form-select").WithId("kind").WithName("kind").End())
				{
					WriteOption(writer, PackageSourceKind.Cache, "Package cache — a folder holding one package per subfolder, asked for by version");
					WriteOption(writer, PackageSourceKind.Folder, "Local folder — one package or a folder of them, asked for by file: path");
					WriteOption(writer, PackageSourceKind.Git, "Git repository — cloned locally, asked for by repository url");
				}
			}

			WriteField(writer, "location", "Location", "A folder path, or a repository url. A package manager git dependency can be pasted whole: the revision after # and the ?path= subfolder are read out of it.");
			WriteField(writer, "revision", "Revision", "A branch, tag or commit for a git source. Empty takes the default branch.");
			WriteField(writer, "subfolder", "Subfolder", "The folder inside the source that holds the package, for a repository that is a whole project. Empty is the source itself.");

			new Button(writer).WithType("submit").WithClass("btn btn-primary mb-3").Close("Add");
		}

		static void WriteOption(TextWriter writer, PackageSourceKind kind, string label)
		{
			new Option(writer).WithValue(kind.ToString()).Close(label);
		}

		static void WriteField(TextWriter writer, string name, string label, string help)
		{
			using (new Div(writer).WithClass("mb-3").End())
			{
				new Label(writer).WithClass("form-label").WithFor(name).Close(label);
				new Input(writer).WithType("text").WithClass("form-control").WithId(name).WithName(name).Close();
				new Div(writer).WithClass("form-text").Close(help);
			}
		}
	}

	private static void WriteScan(TextWriter writer)
	{
		if (LastScan is not List<PackageSourceResult> scan)
		{
			return;
		}

		int total = scan.Sum(static result => result.Packages.Count);
		new H2(writer).Close($"Scan: {total} packages");

		if (scan.Count == 0)
		{
			new P(writer).WithClass("text-muted").Close("No sources are configured.");
			return;
		}

		foreach (PackageSourceResult result in scan)
		{
			new H3(writer).WithClass("h5").Close(result.Source.Describe().ToHtml());

			if (result.Directory.Length > 0)
			{
				new P(writer).WithClass("text-muted small mb-1").Close(result.Directory.ToHtml());
			}

			if (result.FetchMessage is string message && message.Length > 0)
			{
				new P(writer).WithClass("text-muted small mb-1").Close(message.ToHtml());
			}

			if (result.Error is string error)
			{
				new P(writer).WithClass("text-danger").Close(error.ToHtml());
				continue;
			}

			if (result.Packages.Count == 0)
			{
				new P(writer).WithClass("text-muted").Close("Nothing here has a package.json.");
				continue;
			}

			using (new Table(writer).WithClass("table table-sm w-auto").End())
			{
				using (new Tr(writer).End())
				{
					new Th(writer).Close("Package");
					new Th(writer).Close("Version");
					new Th(writer).Close("Manifest entry");
				}

				foreach (ResolvedPackage package in result.Packages)
				{
					using (new Tr(writer).End())
					{
						new Td(writer).Close(package.Name.ToHtml());
						new Td(writer).Close(package.Version.ToHtml());
						new Td(writer).Close(package.Dependency.ToHtml());
					}
				}
			}
		}
	}
}
