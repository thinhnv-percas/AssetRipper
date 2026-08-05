namespace AssetRipper.GUI.Web.Pages.Export;

public sealed class BrowsePage : DefaultPage
{
	public required string DirectoryPath { get; init; }

	public override string GetTitle()
	{
		string name = System.IO.Path.GetFileName(DirectoryPath.TrimEnd(System.IO.Path.DirectorySeparatorChar));
		return name.Length > 0 ? name : DirectoryPath;
	}

	public override void WriteInnerContent(TextWriter writer)
	{
		new H1(writer).Close(GetTitle());
		new P(writer).WithClass("text-muted").Close(DirectoryPath);

		string? parent = Directory.GetParent(DirectoryPath)?.FullName;
		if (parent is not null)
		{
			using (new Div(writer).WithClass("mb-3").End())
			{
				new A(writer).WithClass("btn btn-dark p-0 m-0").WithHref(BrowseAPI.GetBrowseUrl(parent)).Close($"⬆ {Localization.Parent}");
			}
		}

		string[] directories = Directory.GetDirectories(DirectoryPath);
		string[] files = Directory.GetFiles(DirectoryPath);
		Array.Sort(directories, StringComparer.OrdinalIgnoreCase);
		Array.Sort(files, StringComparer.OrdinalIgnoreCase);

		if (directories.Length > 0)
		{
			new H2(writer).Close(Localization.ExportFolders);
			using (new Ul(writer).End())
			{
				foreach (string directory in directories)
				{
					using (new Li(writer).End())
					{
						new A(writer).WithHref(BrowseAPI.GetBrowseUrl(directory)).Close($"\U0001F4C1 {System.IO.Path.GetFileName(directory)}");
					}
				}
			}
		}

		if (files.Length > 0)
		{
			new H2(writer).Close(Localization.ExportFiles);
			using (new Ul(writer).End())
			{
				foreach (string file in files)
				{
					using (new Li(writer).End())
					{
						new A(writer).WithHref(BrowseAPI.GetBrowseUrl(file)).Close(System.IO.Path.GetFileName(file));
					}
				}
			}
		}

		if (directories.Length == 0 && files.Length == 0)
		{
			new P(writer).WithClass("text-muted").Close(Localization.ExportFolderEmpty);
		}
	}
}
