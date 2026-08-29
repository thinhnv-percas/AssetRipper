using AssetRipper.GUI.Web.Pages.PackageRemapping;
using Microsoft.AspNetCore.Http;

namespace AssetRipper.GUI.Web.Pages.PackageRemapping;

/// <summary>
/// Handles the remapping form.
/// </summary>
public static class PackageRemapApi
{
	public static Task HandleRunPostRequest(HttpContext context)
	{
		IFormCollection form = context.Request.Form;

		PackageRemapPage.LastResult = PackageRemapResult.Run(
			Read(form, "officialPackage"),
			Read(form, "projectAssets"),
			Read(form, "backupDirectory"),
			string.Equals(Read(form, "apply"), "true", StringComparison.Ordinal));

		context.Response.Redirect("/PackageRemapping");
		return Task.CompletedTask;

		static string Read(IFormCollection form, string key) => form.TryGetValue(key, out Microsoft.Extensions.Primitives.StringValues value) ? value.ToString().Trim() : "";
	}
}
