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
		public const string File = Base + "/File";
	}

	private const string Path = "Path";

	public static string GetBrowseUrl(string path) => $"{Urls.Browse}?{Path}={Uri.EscapeDataString(path)}";

	public static string GetFileUrl(string path) => $"{Urls.File}?{Path}={Uri.EscapeDataString(path)}";

	public static Task GetView(HttpContext context)
	{
		context.Response.DisableCaching();
		if (!TryGetPathFromQuery(context, out string? path, out Task? failureTask))
		{
			return failureTask;
		}

		if (Directory.Exists(path))
		{
			return new BrowsePage() { DirectoryPath = path }.WriteToResponse(context.Response);
		}
		else if (System.IO.File.Exists(path))
		{
			return new FilePreviewPage() { FilePath = path }.WriteToResponse(context.Response);
		}
		else
		{
			return context.Response.NotFound($"Path could not be found: {path}");
		}
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
	/// Resolves the requested path from the query string.
	/// </summary>
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
