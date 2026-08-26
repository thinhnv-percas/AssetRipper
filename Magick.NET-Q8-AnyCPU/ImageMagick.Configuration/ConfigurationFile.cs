using System.IO;

namespace ImageMagick.Configuration;

internal sealed class ConfigurationFile : IConfigurationFile
{
	public string FileName { get; }

	public string Data { get; set; }

	public ConfigurationFile(string fileName)
	{
		FileName = fileName;
		Data = LoadData();
	}

	private string LoadData()
	{
		using Stream stream = TypeHelper.GetManifestResourceStream(typeof(ConfigurationFile), "ImageMagick.Resources.Xml", FileName);
		using StreamReader streamReader = new StreamReader(stream);
		return streamReader.ReadToEnd();
	}
}
