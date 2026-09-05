namespace AssetRipper.GUI.Web.Pages.Export;

internal enum FilePreviewCategory
{
	Text,
	Image,
	Audio,
	Video,
	Other,
}

internal static class FileTypes
{
	/// <summary>
	/// Files larger than this are not loaded into memory for an inline text preview.
	/// </summary>
	public const long MaxTextPreviewSize = 2 * 1024 * 1024;

	private static readonly HashSet<string> textExtensions = new(StringComparer.OrdinalIgnoreCase)
	{
		".txt", ".cs", ".json", ".xml", ".yaml", ".yml", ".asset", ".meta", ".unity", ".prefab",
		".mat", ".controller", ".anim", ".overrideController", ".physicMaterial", ".physicsMaterial2D",
		".shader", ".shadergraph", ".compute", ".cginc", ".hlsl", ".glsl", ".uxml", ".uss",
		".asmdef", ".asmref", ".rsp", ".editorconfig", ".gitignore", ".md", ".html", ".htm",
		".css", ".js", ".config", ".log", ".csproj", ".sln", ".props", ".targets", ".mask",
		".guiskin", ".fontsettings", ".preset", ".spriteatlas", ".terrainlayer", ".playable",
		".signal", ".renderTexture", ".mixer", ".flare", ".giparams", ".brush", ".cubemap",
	};

	private static readonly HashSet<string> imageExtensions = new(StringComparer.OrdinalIgnoreCase)
	{
		".png", ".jpg", ".jpeg", ".gif", ".bmp", ".webp", ".ico", ".svg",
	};

	private static readonly HashSet<string> audioExtensions = new(StringComparer.OrdinalIgnoreCase)
	{
		".wav", ".mp3", ".ogg",
	};

	private static readonly HashSet<string> videoExtensions = new(StringComparer.OrdinalIgnoreCase)
	{
		".mp4", ".webm", ".ogv",
	};

	private static readonly Dictionary<string, string> contentTypes = new(StringComparer.OrdinalIgnoreCase)
	{
		[".txt"] = "text/plain",
		[".cs"] = "text/plain",
		[".json"] = "application/json",
		[".xml"] = "text/xml",
		[".yaml"] = "text/yaml",
		[".yml"] = "text/yaml",
		[".html"] = "text/html",
		[".htm"] = "text/html",
		[".css"] = "text/css",
		[".js"] = "text/javascript",
		[".md"] = "text/markdown",
		[".png"] = "image/png",
		[".jpg"] = "image/jpeg",
		[".jpeg"] = "image/jpeg",
		[".gif"] = "image/gif",
		[".bmp"] = "image/bmp",
		[".webp"] = "image/webp",
		[".ico"] = "image/x-icon",
		[".svg"] = "image/svg+xml",
		[".wav"] = "audio/wav",
		[".mp3"] = "audio/mpeg",
		[".ogg"] = "audio/ogg",
		[".mp4"] = "video/mp4",
		[".webm"] = "video/webm",
		[".ogv"] = "video/ogg",
	};

	public static FilePreviewCategory GetCategory(string extension)
	{
		if (textExtensions.Contains(extension))
		{
			return FilePreviewCategory.Text;
		}
		else if (imageExtensions.Contains(extension))
		{
			return FilePreviewCategory.Image;
		}
		else if (audioExtensions.Contains(extension))
		{
			return FilePreviewCategory.Audio;
		}
		else if (videoExtensions.Contains(extension))
		{
			return FilePreviewCategory.Video;
		}
		else
		{
			return FilePreviewCategory.Other;
		}
	}

	public static string GetContentType(string extension)
	{
		return contentTypes.GetValueOrDefault(extension, "application/octet-stream");
	}
}
