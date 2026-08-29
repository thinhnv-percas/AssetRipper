using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace AssetRipper.GUI.Web.Pages.Il2CppRestore;

/// <summary>
/// Handles the restore form.
/// </summary>
public static class Il2CppRestoreApi
{
	public static async Task HandleRunPostRequest(HttpContext context)
	{
		IFormCollection form = await context.Request.ReadFormAsync();

		Il2CppRestorePage.LastResult = await Il2CppRestoreResult.RunAsync(
			Read(form, "cliPath"),
			Read(form, "metadataPath"),
			ReadOrNull(form, "binaryPath"),
			ReadOrNull(form, "structDbDirectory"),
			ReadOrNull(form, "unityVersion"),
			Read(form, "outputPath"));

		context.Response.Redirect("/Il2CppRestore");

		static string Read(IFormCollection form, string key) => form.TryGetValue(key, out StringValues value) ? value.ToString().Trim() : "";
		static string? ReadOrNull(IFormCollection form, string key)
		{
			string value = Read(form, key);
			return value.Length == 0 ? null : value;
		}
	}
}
