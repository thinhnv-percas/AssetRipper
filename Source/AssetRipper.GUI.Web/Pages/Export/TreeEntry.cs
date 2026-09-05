namespace AssetRipper.GUI.Web.Pages.Export;

/// <summary>
/// One entry (folder or file) returned by <see cref="BrowseAPI.GetTree(Microsoft.AspNetCore.Http.HttpContext)"/> for the file tree sidebar.
/// </summary>
public sealed record TreeEntry(string Name, string Path, bool IsDirectory);
