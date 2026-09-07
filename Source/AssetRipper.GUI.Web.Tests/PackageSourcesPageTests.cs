using AssetRipper.Export.UnityProjects.PackageRemapping;
using AssetRipper.GUI.Web.Pages.PackageRemapping;

namespace AssetRipper.GUI.Web.Tests;

/// <summary>
/// The page is written straight to a stream rather than through a template, so nothing but writing it
/// catches a page that throws part way through and leaves half of itself in the response.
/// </summary>
public class PackageSourcesPageTests
{
	[Test]
	public void ThePageWritesWithoutASourceConfigured()
	{
		string html = Write();

		Assert.Multiple(() =>
		{
			Assert.That(html, Does.Contain("Package Sources"));
			Assert.That(html, Does.Contain("/PackageSources/Run"));
			Assert.That(html, Does.Contain("Git repository"));
			Assert.That(html, Does.Contain("Fetch git sources and scan"));
		});
	}

	/// <summary>
	/// Every row action is a button in the one form the table is in, so a row that renders without them
	/// is a row nothing can be done to.
	/// </summary>
	[Test]
	public void AGitSourceRowCarriesItsActions()
	{
		string path = PackageRemapConfiguration.DefaultPath;
		string? existing = File.Exists(path) ? File.ReadAllText(path) : null;

		try
		{
			PackageRemapConfiguration configuration = new();
			configuration.Sources.Add(new PackageSource
			{
				Kind = PackageSourceKind.Git,
				Location = "https://github.com/owner/repo.git",
				Revision = "v1.2.3",
			});
			configuration.Save(path);

			string html = Write();

			Assert.Multiple(() =>
			{
				Assert.That(html, Does.Contain("https://github.com/owner/repo.git"));
				Assert.That(html, Does.Contain("value=\"update:0\""));
				Assert.That(html, Does.Contain("value=\"open:0\""));
				Assert.That(html, Does.Contain("value=\"toggle:0\""));
				Assert.That(html, Does.Contain("value=\"remove:0\""));
			});
		}
		finally
		{
			if (existing is null)
			{
				File.Delete(path);
			}
			else
			{
				File.WriteAllText(path, existing);
			}
		}
	}

	private static string Write()
	{
		using StringWriter writer = new();
		PackageSourcesPage.Instance.WriteInnerContent(writer);
		return writer.ToString();
	}
}
