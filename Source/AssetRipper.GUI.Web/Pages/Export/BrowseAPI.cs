using AssetRipper.Web.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace AssetRipper.GUI.Web.Pages.Export;

internal static class BrowseAPI
{
	public static class Urls
	{
		public const string Base = "/Export";
		public const string Browse = Base + "/Browse";
		public const string Tree = Base + "/Tree";
		public const string Preview = Base + "/Preview";
		public const string File = Base + "/File";
		public const string Reveal = Base + "/Reveal";
	}

	private const string Path = "Path";

	public static string GetBrowseUrl(string path) => $"{Urls.Browse}?{Path}={Uri.EscapeDataString(path)}";

	public static string GetFileUrl(string path) => $"{Urls.File}?{Path}={Uri.EscapeDataString(path)}";

	public static string GetRevealUrl(string path) => $"{Urls.Reveal}?{Path}={Uri.EscapeDataString(path)}";

	/// <summary>
	/// Opens a directory in the desktop's file manager.
	/// </summary>
	/// <remarks>
	/// An auto exported project lands wherever the default export path says, or in a temporary
	/// directory whose name is a guid when that setting is empty. This is the way out of the preview
	/// and into the files.
	/// </remarks>
	public static Task Reveal(HttpContext context)
	{
		context.Response.DisableCaching();
		if (!TryGetPathFromQuery(context, out string? path, out Task? failureTask))
		{
			return failureTask;
		}

		// A file's own folder is what the user wants opened, not the file.
		string directory = Directory.Exists(path) ? path : System.IO.Path.GetDirectoryName(path) ?? path;

		if (!Directory.Exists(directory))
		{
			return context.Response.NotFound($"Directory could not be found: {directory}");
		}

		if (!TryOpenInFileManager(directory, out string? error))
		{
			return context.Response.NotFound(error);
		}

		// The page stays where it is: opening a folder is a side effect, not a navigation.
		context.Response.StatusCode = 204;
		return Task.CompletedTask;
	}

	private static bool TryOpenInFileManager(string directory, [NotNullWhen(false)] out string? error)
	{
		try
		{
			if (OperatingSystem.IsWindows())
			{
				System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(directory) { UseShellExecute = true });
			}
			else if (OperatingSystem.IsMacOS())
			{
				System.Diagnostics.Process.Start("open", directory);
			}
			else
			{
				System.Diagnostics.Process.Start("xdg-open", directory);
			}

			error = null;
			return true;
		}
		catch (Exception exception)
		{
			// Headless machines and containers have no file manager, which is not worth an error page
			// beyond saying so.
			error = $"Could not open {directory}: {exception.Message}";
			return false;
		}
	}

	/// <summary>
	/// Renders the two-pane project explorer, rooted at the whole exported project when possible.
	/// </summary>
	public static Task GetView(HttpContext context)
	{
		context.Response.DisableCaching();
		if (!TryGetPathFromQuery(context, out string? path, out Task? failureTask))
		{
			return failureTask;
		}

		if (!Directory.Exists(path) && !System.IO.File.Exists(path))
		{
			return context.Response.NotFound($"Path could not be found: {path}");
		}

		string root = GetTreeRoot(path);
		return new BrowsePage() { RootPath = root, SelectedPath = path }.WriteToResponse(context.Response);
	}

	/// <summary>
	/// Returns the immediate children (folders then files) of a directory, for the file tree sidebar.
	/// </summary>
	public static Task GetTree(HttpContext context)
	{
		context.Response.DisableCaching();
		if (!TryGetPathFromQuery(context, out string? path, out Task? failureTask))
		{
			return failureTask;
		}

		if (!Directory.Exists(path))
		{
			return context.Response.NotFound($"Directory could not be found: {path}");
		}

		string[] directories = Directory.GetDirectories(path);
		string[] files = Directory.GetFiles(path);
		Array.Sort(directories, StringComparer.OrdinalIgnoreCase);
		Array.Sort(files, StringComparer.OrdinalIgnoreCase);

		TreeEntry[] entries = new TreeEntry[directories.Length + files.Length];
		int i = 0;
		foreach (string directory in directories)
		{
			entries[i++] = new TreeEntry(System.IO.Path.GetFileName(directory), directory, true);
		}
		foreach (string file in files)
		{
			entries[i++] = new TreeEntry(System.IO.Path.GetFileName(file), file, false);
		}

		return Results.Json(entries, AppJsonSerializerContext.Default.TreeEntryArray).ExecuteAsync(context);
	}

	/// <summary>
	/// Returns an HTML fragment previewing a single file or folder, for the right-hand preview panel.
	/// </summary>
	public static Task GetPreview(HttpContext context)
	{
		context.Response.DisableCaching();
		if (!TryGetPathFromQuery(context, out string? path, out Task? failureTask))
		{
			return failureTask;
		}

		StringWriter stringWriter = new();
		PreviewFragment.Write(stringWriter, path);
		return Results.Text(stringWriter.ToString(), "text/html").ExecuteAsync(context);
	}

	public static Task GetFileData(HttpContext context)
	{
		context.Response.DisableCaching();
		if (!TryGetPathFromQuery(context, out string? path, out Task? failureTask))
		{
			return failureTask;
		}

		if (!System.IO.File.Exists(path))
		{
			return context.Response.NotFound($"File could not be found: {path}");
		}

		string extension = System.IO.Path.GetExtension(path);
		string contentType = FileTypes.GetContentType(extension);
		byte[] data = System.IO.File.ReadAllBytes(path);
		return Results.Bytes(data, contentType).ExecuteAsync(context);
	}

	/// <summary>
	/// Prefers rooting the tree at the most recently exported project when the requested path falls inside it,
	/// so deep links still show the whole project rather than just one subfolder.
	/// </summary>
	private static string GetTreeRoot(string path)
	{
		string? lastExportPath = GameFileLoader.LastExportPath;
		if (lastExportPath is not null && Directory.Exists(lastExportPath) && IsWithinOrEqual(path, lastExportPath))
		{
			return lastExportPath;
		}

		return Directory.Exists(path) ? path : (Directory.GetParent(path)?.FullName ?? path);
	}

	private static bool IsWithinOrEqual(string candidate, string root)
	{
		string fullCandidate = System.IO.Path.GetFullPath(candidate);
		string fullRoot = System.IO.Path.GetFullPath(root);
		return fullCandidate.Equals(fullRoot, StringComparison.OrdinalIgnoreCase)
			|| fullCandidate.StartsWith(fullRoot + System.IO.Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase);
	}

	private static bool TryGetPathFromQuery(HttpContext context, [NotNullWhen(true)] out string? path, [NotNullWhen(false)] out Task? failureTask)
	{
		if (!context.Request.Query.TryGetValue(Path, out StringValues values) || string.IsNullOrEmpty(values))
		{
			path = null;
			failureTask = context.Response.NotFound("The path must be included in the request.");
			return false;
		}

		path = values.ToString();
		failureTask = null;
		return true;
	}
}
