using AssetRipper.Export.UnityProjects.PackageRemapping;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Globalization;

namespace AssetRipper.GUI.Web.Pages.PackageRemapping;

/// <summary>
/// Handles the package sources form.
/// </summary>
/// <remarks>
/// Every button on the page posts here and says which it was in <c>action</c>, because a row's buttons
/// cannot each have a form of their own inside the table's.
/// </remarks>
public static class PackageSourcesApi
{
	public static Task HandlePostRequest(HttpContext context)
	{
		IFormCollection form = context.Request.Form;
		string action = Read(form, "action");

		PackageRemapConfiguration configuration = PackageSourcesPage.LoadConfiguration();

		switch (action)
		{
			case "add":
				Add(form, configuration);
				break;
			case "scan":
				PackageSourcesPage.LastScan = Scan(configuration, GitFetchMode.WhenMissing);
				break;
			case "fetch":
				PackageSourcesPage.LastScan = Scan(configuration, GitFetchMode.Always);
				break;
			default:
				Edit(action, configuration);
				break;
		}

		context.Response.Redirect("/PackageSources");
		return Task.CompletedTask;
	}

	private static void Add(IFormCollection form, PackageRemapConfiguration configuration)
	{
		string location = Read(form, "location");
		if (location.Length == 0)
		{
			return;
		}

		PackageSourceKind kind = Enum.TryParse(Read(form, "kind"), out PackageSourceKind parsed) ? parsed : PackageSourceKind.Folder;

		// A package manager dependency carries its revision and subfolder in the url, so pasting one whole
		// fills all three boxes. What was typed into those boxes still wins.
		PackageSource source = kind is PackageSourceKind.Git
			? PackageSource.FromGitUrl(location)
			: new PackageSource { Location = location };

		source.Kind = kind;

		string revision = Read(form, "revision");
		if (revision.Length > 0)
		{
			source.Revision = revision;
		}

		string subfolder = Read(form, "subfolder");
		if (subfolder.Length > 0)
		{
			source.Subfolder = subfolder;
		}

		configuration.Sources.Add(source);
		Save(configuration);
	}

	/// <summary>
	/// The row actions, which name the row they came from.
	/// </summary>
	private static void Edit(string action, PackageRemapConfiguration configuration)
	{
		int separator = action.IndexOf(':');
		if (separator < 0 || !int.TryParse(action[(separator + 1)..], CultureInfo.InvariantCulture, out int index))
		{
			return;
		}

		if (index < 0 || index >= configuration.Sources.Count)
		{
			// The list moved under the page, which a second tab or a stale one does.
			return;
		}

		switch (action[..separator])
		{
			case "remove":
				configuration.Sources.RemoveAt(index);
				break;
			case "toggle":
				configuration.Sources[index].Enabled = !configuration.Sources[index].Enabled;
				break;
			default:
				return;
		}

		Save(configuration);
	}

	/// <summary>
	/// Scans every source, disabled ones included, since the page is where someone finds out what a
	/// source holds before turning it on.
	/// </summary>
	private static List<PackageSourceResult> Scan(PackageRemapConfiguration configuration, GitFetchMode gitMode)
	{
		List<PackageSource> sources = [.. configuration.Sources];

		string? cachePath = GameFileLoader.Settings.ExportSettings.OfficialPackageCachePath;
		if (!string.IsNullOrWhiteSpace(cachePath))
		{
			sources.Add(new PackageSource { Kind = PackageSourceKind.Cache, Location = cachePath });
		}

		return PackageSourceResolver.Resolve(sources, gitMode);
	}

	private static void Save(PackageRemapConfiguration configuration)
	{
		configuration.Save(PackageRemapConfiguration.DefaultPath);
	}

	private static string Read(IFormCollection form, string key)
	{
		return form.TryGetValue(key, out StringValues value) ? value.ToString().Trim() : "";
	}
}
