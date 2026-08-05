using AssetRipper.GUI.Web.Paths;

namespace AssetRipper.GUI.Web.Pages.Export;

/// <summary>
/// A two-pane project explorer: a collapsible folder tree on the left, and a preview pane on the right.
/// </summary>
public sealed class BrowsePage : DefaultPage
{
	/// <summary>
	/// The top of the folder tree shown in the left panel.
	/// </summary>
	public required string RootPath { get; init; }

	/// <summary>
	/// The file or folder initially shown in the right-hand preview panel.
	/// </summary>
	public required string SelectedPath { get; init; }

	public override string GetTitle()
	{
		string name = System.IO.Path.GetFileName(RootPath.TrimEnd(System.IO.Path.DirectorySeparatorChar));
		return name.Length > 0 ? name : RootPath;
	}

	public override void WriteInnerContent(TextWriter writer)
	{
		new H1(writer).Close(GetTitle());
		new P(writer).WithClass("text-muted").Close(RootPath);

		using (new Div(writer).WithClass("d-flex").WithStyle("gap: 1rem; align-items: flex-start;").End())
		{
			using (new Div(writer)
				.WithId("export-tree-panel")
				.WithClass("border rounded-3 p-2")
				.WithStyle("width: 320px; max-height: 75vh; overflow-y: auto; flex-shrink: 0;")
				.WithCustomAttribute("data-root", RootPath.ToHtml())
				.End())
			{
				new Ul(writer).WithId("export-tree-root").WithClass("export-tree list-unstyled mb-0").Close();
			}

			using (new Div(writer)
				.WithId("export-preview-panel")
				.WithClass("border rounded-3 p-3")
				.WithStyle("flex: 1; min-width: 0; max-height: 75vh; overflow-y: auto;")
				.End())
			{
				PreviewFragment.Write(writer, SelectedPath);
			}
		}
	}

	protected override void WriteScriptReferences(TextWriter writer)
	{
		base.WriteScriptReferences(writer);
		new Script(writer).WithSrc("/js/export_explorer.js").Close();
	}
}
