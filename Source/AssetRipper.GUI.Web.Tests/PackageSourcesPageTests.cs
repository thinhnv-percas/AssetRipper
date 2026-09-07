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
		using StringWriter writer = new();
		PackageSourcesPage.Instance.WriteInnerContent(writer);
		string html = writer.ToString();

		Assert.Multiple(() =>
		{
			Assert.That(html, Does.Contain("Package Sources"));
			Assert.That(html, Does.Contain("/PackageSources/Run"));
			Assert.That(html, Does.Contain("Git repository"));
			Assert.That(html, Does.Contain("Fetch git sources and scan"));
		});
	}
}
