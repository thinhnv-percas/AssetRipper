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
			Restore(path, existing);
		}
	}

	/// <summary>
	/// The url Unity is handed under <em>Add package from git URL</em>, which is the whole point of
	/// showing it: a source that renders without it can only be used by exporting.
	/// </summary>
	[Test]
	public void AGitSourceRowCarriesTheUrlToPasteIntoUnity()
	{
		string path = PackageRemapConfiguration.DefaultPath;
		string? existing = File.Exists(path) ? File.ReadAllText(path) : null;

		try
		{
			PackageRemapConfiguration configuration = new();
			configuration.Sources.Add(PackageSource.FromGitUrl("https://github.com/owner/repo.git?path=Packages/com.owner.thing#v1.2.3"));
			configuration.Save(path);

			string html = Write();

			Assert.Multiple(() =>
			{
				Assert.That(html, Does.Contain("Unity git URL"));
				Assert.That(html, Does.Contain("copy-text=\"https://github.com/owner/repo.git?path=Packages/com.owner.thing#v1.2.3\""));
			});
		}
		finally
		{
			Restore(path, existing);
		}
	}

	/// <summary>
	/// A folder source has no url to paste, and the column has to say that rather than be missing: the
	/// rows are one table and a row short of a cell shifts every row after it.
	/// </summary>
	[Test]
	public void AFolderSourceRowHasNoUrlToCopy()
	{
		string path = PackageRemapConfiguration.DefaultPath;
		string? existing = File.Exists(path) ? File.ReadAllText(path) : null;

		try
		{
			PackageRemapConfiguration configuration = new();
			configuration.Sources.Add(new PackageSource { Kind = PackageSourceKind.Folder, Location = "/packages/com.owner.thing" });
			configuration.Save(path);

			string html = Write();

			Assert.Multiple(() =>
			{
				Assert.That(html, Does.Contain("/packages/com.owner.thing"));
				Assert.That(html, Does.Not.Contain("copy-text"));
			});
		}
		finally
		{
			Restore(path, existing);
		}
	}

	/// <summary>
	/// The element writer Html-encodes the text it is given, so encoding it first encodes it twice and
	/// a path holding an ampersand reads as <c>&amp;amp;</c> on the page and copies as the wrong url.
	/// </summary>
	[Test]
	public void AValueHoldingAnAmpersandIsEncodedOnce()
	{
		string path = PackageRemapConfiguration.DefaultPath;
		string? existing = File.Exists(path) ? File.ReadAllText(path) : null;

		try
		{
			PackageRemapConfiguration configuration = new();
			configuration.Sources.Add(new PackageSource { Kind = PackageSourceKind.Folder, Location = "/packages/a&b" });
			configuration.Save(path);

			string html = Write();

			Assert.Multiple(() =>
			{
				Assert.That(html, Does.Contain("/packages/a&amp;b"));
				Assert.That(html, Does.Not.Contain("&amp;amp;"));
			});
		}
		finally
		{
			Restore(path, existing);
		}
	}

	private static void Restore(string path, string? existing)
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

	private static string Write()
	{
		using StringWriter writer = new();
		PackageSourcesPage.Instance.WriteInnerContent(writer);
		return writer.ToString();
	}
}
