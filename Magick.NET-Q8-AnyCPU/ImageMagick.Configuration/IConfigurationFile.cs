namespace ImageMagick.Configuration;

public interface IConfigurationFile
{
	string FileName { get; }

	string Data { get; set; }
}
