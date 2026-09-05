using AssetRipper.GUI.Web.Pages.Export;
using AssetRipper.NativeDialogs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace AssetRipper.GUI.Web.Pages;

public static class Commands
{
	private const string RootPath = "/";
	private const string CommandsPath = "/Commands";

	/// <summary>
	/// For documentation purposes
	/// </summary>
	/// <param name="Path">The file system path.</param>
	internal record PathFormData(string Path);

	internal static RouteHandlerBuilder AcceptsFormDataContainingPath(this RouteHandlerBuilder builder)
	{
		return builder.Accepts<PathFormData>("application/x-www-form-urlencoded");
	}

	private static bool TryGetCreateSubfolder(IFormCollection form)
	{
		if (form.TryGetValue("CreateSubfolder", out StringValues values))
		{
			return values == "true";
		}

		return false;
	}

	public readonly struct LoadFile : ICommand
	{
		static async Task<string?> ICommand.Execute(HttpRequest request)
		{
			IFormCollection form = await request.ReadFormAsync();

			string[]? paths;
			if (form.TryGetValue("Path", out StringValues values))
			{
				paths = values;
			}
			else if (NativeDialog.Supported)
			{
				paths = await OpenFileDialog.OpenFiles();
			}
			else
			{
				return CommandsPath;
			}

			if (paths is { Length: > 0 })
			{
				GameFileLoader.LoadAndProcess(paths);
				return await AutoExportAndGetRedirect();
			}
			return null;
		}
	}

	public readonly struct LoadFolder : ICommand
	{
		static async Task<string?> ICommand.Execute(HttpRequest request)
		{
			IFormCollection form = await request.ReadFormAsync();

			string[]? paths;
			if (form.TryGetValue("Path", out StringValues values))
			{
				paths = values;
			}
			else if (NativeDialog.Supported)
			{
				paths = await OpenFolderDialog.OpenFolders();
			}
			else
			{
				return CommandsPath;
			}

			if (paths is { Length: > 0 })
			{
				GameFileLoader.LoadAndProcess(paths);
				return await AutoExportAndGetRedirect();
			}
			return null;
		}
	}

	/// <summary>
	/// Automatically decompiles the just-loaded game and returns the URL to preview it.
	/// </summary>
	private static async Task<string?> AutoExportAndGetRedirect()
	{
		if (!GameFileLoader.IsLoaded)
		{
			return null;
		}

		string autoExportPath = GetAutoExportPath();
		bool success = await GameFileLoader.ExportUnityProject(autoExportPath);
		return success ? BrowseAPI.GetBrowseUrl(autoExportPath) : null;
	}

	/// <summary>
	/// Where the preview export lands: the default export path when one is set, and a scratch
	/// directory otherwise.
	/// </summary>
	/// <remarks>
	/// A preview in a temporary directory named after a guid is a project nobody can find again, and
	/// someone who has set a default export path has already said where their rips belong. The export
	/// itself is the same one the Export Unity Project button performs, deletion prompt included, so
	/// pointing it at that directory does nothing the button would not.
	/// </remarks>
	private static string GetAutoExportPath()
	{
		string? configured = GameFileLoader.Settings.ExportSettings.DefaultExportPath;

		return string.IsNullOrWhiteSpace(configured)
			? Path.Combine(Path.GetTempPath(), "AssetRipper_AutoPreview", Guid.NewGuid().ToString("N"))
			: configured.Trim();
	}

	public readonly struct ExportUnityProject : ICommand
	{
		static async Task<string?> ICommand.Execute(HttpRequest request)
		{
			IFormCollection form = await request.ReadFormAsync();

			string? path;
			if (form.TryGetValue("Path", out StringValues values))
			{
				path = values;
			}
			else
			{
				return CommandsPath;
			}

			if (!string.IsNullOrEmpty(path))
			{
				bool createSubfolder = TryGetCreateSubfolder(form);
				path = MaybeAppendTimestampedSubfolder(path, createSubfolder);
				bool success = await GameFileLoader.ExportUnityProject(path);
				return success ? BrowseAPI.GetBrowseUrl(path) : null;
			}
			return null;
		}
	}

	public readonly struct ExportPrimaryContent : ICommand
	{
		static async Task<string?> ICommand.Execute(HttpRequest request)
		{
			IFormCollection form = await request.ReadFormAsync();

			string? path;
			if (form.TryGetValue("Path", out StringValues values))
			{
				path = values;
			}
			else
			{
				return CommandsPath;
			}

			if (!string.IsNullOrEmpty(path))
			{
				bool createSubfolder = TryGetCreateSubfolder(form);
				path = MaybeAppendTimestampedSubfolder(path, createSubfolder);
				bool success = await GameFileLoader.ExportPrimaryContent(path);
				return success ? BrowseAPI.GetBrowseUrl(path) : null;
			}
			return null;
		}
	}

	private static string MaybeAppendTimestampedSubfolder(string path, bool append)
	{
		if (append)
		{
			string timestamp = DateTime.UtcNow.ToString("yyyyMMdd_HHmmss");
			string subfolder = $"AssetRipper_export_{timestamp}";
			return Path.Combine(path, subfolder);
		}

		return path;
	}

	public readonly struct Reset : ICommand
	{
		static Task<string?> ICommand.Execute(HttpRequest request)
		{
			GameFileLoader.Reset();
			return Task.FromResult<string?>(null);
		}
	}

	public static async Task HandleCommand<T>(HttpContext context) where T : ICommand
	{
		string? redirectionTarget = await T.Execute(context.Request);
		context.Response.Redirect(redirectionTarget ?? RootPath);
	}
}
