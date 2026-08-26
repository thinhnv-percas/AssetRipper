using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ImageMagick.Configuration;

public sealed class ConfigurationFiles
{
	public static ConfigurationFiles Default => new ConfigurationFiles();

	public IConfigurationFile Coder { get; }

	public IConfigurationFile Colors { get; }

	public IConfigurationFile Configure { get; }

	public IConfigurationFile Delegates { get; }

	public IConfigurationFile English { get; }

	public IConfigurationFile Locale { get; }

	public IConfigurationFile Log { get; }

	public IConfigurationFile Magic { get; }

	public IConfigurationFile Policy { get; }

	public IConfigurationFile Thresholds { get; }

	public IConfigurationFile Type { get; }

	public IConfigurationFile TypeGhostscript { get; }

	internal IEnumerable<IConfigurationFile> Files
	{
		get
		{
			yield return Coder;
			yield return Colors;
			yield return Configure;
			yield return Delegates;
			yield return English;
			yield return Locale;
			yield return Log;
			yield return Magic;
			yield return Policy;
			yield return Thresholds;
			yield return Type;
			yield return TypeGhostscript;
		}
	}

	private ConfigurationFiles()
	{
		Coder = new ConfigurationFile("coder.xml");
		Colors = new ConfigurationFile("colors.xml");
		Configure = new ConfigurationFile("configure.xml");
		Delegates = new ConfigurationFile("delegates.xml");
		English = new ConfigurationFile("english.xml");
		Locale = new ConfigurationFile("locale.xml");
		Log = new ConfigurationFile("log.xml");
		Magic = new ConfigurationFile("magic.xml");
		Policy = new ConfigurationFile("policy.xml");
		Thresholds = new ConfigurationFile("thresholds.xml");
		Type = new ConfigurationFile("type.xml");
		TypeGhostscript = new ConfigurationFile("type-ghostscript.xml");
	}

	internal void WriteInDirectory(string path)
	{
		foreach (IConfigurationFile file in Files)
		{
			string path2 = Path.Combine(path, file.FileName);
			if (!File.Exists(path2))
			{
				using FileStream fileStream = File.Open(path2, FileMode.CreateNew);
				byte[] bytes = Encoding.UTF8.GetBytes(file.Data);
				fileStream.Write(bytes, 0, bytes.Length);
			}
		}
	}
}
