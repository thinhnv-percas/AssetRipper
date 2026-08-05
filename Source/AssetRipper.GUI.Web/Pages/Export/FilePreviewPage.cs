namespace AssetRipper.GUI.Web.Pages.Export;

public sealed class FilePreviewPage : DefaultPage
{
	public required string FilePath { get; init; }

	public override string GetTitle() => System.IO.Path.GetFileName(FilePath);

	public override void WriteInnerContent(TextWriter writer)
	{
		new H1(writer).Close(GetTitle());
		new P(writer).WithClass("text-muted").Close(FilePath);

		string? parent = Directory.GetParent(FilePath)?.FullName;
		if (parent is not null)
		{
			using (new Div(writer).WithClass("mb-3").End())
			{
				new A(writer).WithClass("btn btn-dark p-0 m-0").WithHref(BrowseAPI.GetBrowseUrl(parent)).Close($"⬆ {Localization.Parent}");
			}
		}

		string fileName = System.IO.Path.GetFileName(FilePath);
		string fileUrl = BrowseAPI.GetFileUrl(FilePath);
		string extension = System.IO.Path.GetExtension(FilePath);
		FilePreviewCategory category = FileTypes.GetCategory(extension);
		long size = new FileInfo(FilePath).Length;

		if (category is FilePreviewCategory.Text && size <= FileTypes.MaxTextPreviewSize)
		{
			new Pre(writer).WithClass("bg-dark-subtle rounded-3 p-2").WithDynamicTextContent(fileUrl).Close();
		}
		else if (category is FilePreviewCategory.Image)
		{
			using (new A(writer).WithHref(fileUrl).WithDownload(fileName).End())
			{
				new Img(writer).WithSrc(fileUrl).WithStyle("object-fit:contain; width:100%; max-height:80vh").Close();
			}
		}
		else if (category is FilePreviewCategory.Audio)
		{
			new Audio(writer).WithControls("").WithPreload("auto").WithSrc(fileUrl).Close();
		}
		else if (category is FilePreviewCategory.Video)
		{
			using (new Video(writer).WithControls().WithStyle("width:100%; max-height:80vh").End())
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
