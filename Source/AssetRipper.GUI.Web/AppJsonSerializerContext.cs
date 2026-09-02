using AssetRipper.GUI.Web.Pages;
using AssetRipper.GUI.Web.Pages.Export;
using System.Text.Json.Serialization;

namespace AssetRipper.GUI.Web;

[JsonSerializable(typeof(Dictionary<string, string>))]
[JsonSerializable(typeof(string[]))]
[JsonSerializable(typeof(bool))]
[JsonSerializable(typeof(int))]
[JsonSerializable(typeof(byte[]))]
[JsonSerializable(typeof(Commands.PathFormData))]
[JsonSerializable(typeof(TreeEntry[]))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{
}
