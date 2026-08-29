namespace AssetRipper.GUI.Web.Pages.Export;

/// <summary>
/// Renders the right-hand preview pane content for a single file or folder.
/// Used both for the initial server-rendered page and for the AJAX fragment endpoint.
/// </summary>
internal static class PreviewFragment
{
	public static void Write(TextWriter writer, string path)
	{
		if (Directory.Exists(path))
		{
			WriteDirectoryInfo(writer, path);
		}
		else if (File.Exists(path))
		{
			WriteFilePreview(writer, path);
		}
		else
		{
			new P(writer).WithClass("text-muted").Close($"Path could not be found: {path}");
		}
	}

	private static void WriteDirectoryInfo(TextWriter writer, string path)
	{
		string name = System.IO.Path.GetFileName(path.TrimEnd(System.IO.Path.DirectorySeparatorChar));
		new H2(writer).Close(name.Length > 0 ? name : path);
		new P(writer).WithClass("text-muted").Close(path);

		int folderCount = Directory.GetDirectories(path).Length;
		int fileCount = Directory.GetFiles(path).Length;
		new P(writer).Close($"{folderCount} folder(s), {fileCount} file(s)");
		new P(writer).WithClass("text-muted").Close(Localization.ExportSelectFileToPreview);
	}

	private static void WriteFilePreview(TextWriter writer, string path)
	{
		string fileName = System.IO.Path.GetFileName(path);
		string fileUrl = BrowseAPI.GetFileUrl(path);
		string extension = System.IO.Path.GetExtension(path);
		FilePreviewCategory category = FileTypes.GetCategory(extension);
		long size = new FileInfo(path).Length;

		new H2(writer).Close(fileName);
		new P(writer).WithClass("text-muted").Close(path);

		if (category is FilePreviewCategory.Text && size <= FileTypes.MaxTextPreviewSize)
		{
			new Pre(writer).WithClass("bg-dark-subtle rounded-3 p-2").WithDynamicTextContent(fileUrl).Close();
		}
		else if (category is FilePreviewCategory.Image)
		{
			using (new A(writer).WithHref(fileUrl).WithDownload(fileName).End())
			{
				new Img(writer).WithSrc(fileUrl).WithStyle("object-fit:contain; width:100%; max-height:70vh").Close();
			}
		}
		else if (category is FilePreviewCategory.Audio)
		{
			new Audio(writer).WithControls("").WithPreload("auto").WithSrc(fileUrl).Close();
		}
		else if (category is FilePreviewCategory.Video)
		{
			using (new Video(writer).WithControls().WithStyle("width:100%; max-height:70vh").End())
			{
				new Source(writer).WithSrc(fileUrl).WithType(FileTypes.GetContentType(extension)).Close();
			}
		}
		else
		{
			string message = size > FileTypes.MaxTextPreviewSize
				? Localization.ExportFileTooLarge
				: Localization.ExportPreviewUnavailable;
			new P(writer).WithClass("text-muted").Close(message);
		}

		using (new Div(writer).WithClass("text-center mt-3").End())
		{
			SaveButton.Write(writer, fileUrl, fileName);
		}
	}
}
