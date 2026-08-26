using System.IO;

namespace ImageMagick.ImageOptimizers;

public sealed class GifOptimizer : IImageOptimizer
{
	public MagickFormatInfo Format => MagickNET.GetFormatInformation(MagickFormat.Gif);

	bool IImageOptimizer.OptimalCompression { get; set; }

	public bool Compress(FileInfo file)
	{
		return LosslessCompress(file);
	}

	public bool Compress(string fileName)
	{
		return LosslessCompress(fileName);
	}

	public bool LosslessCompress(FileInfo file)
	{
		Throw.IfNull("file", file);
		return DoLosslessCompress(file);
	}

	public bool LosslessCompress(string fileName)
	{
		string text = FileHelper.CheckForBaseDirectory(fileName);
		Throw.IfNullOrEmpty("fileName", text);
		return DoLosslessCompress(new FileInfo(text));
	}

	private static void CheckFormat(IMagickImage image)
	{
		MagickFormat module = image.FormatInfo.Module;
		if (module != MagickFormat.Gif)
		{
			throw new MagickCorruptImageErrorException("Invalid image format: " + module);
		}
	}

	private static bool DoLosslessCompress(FileInfo file)
	{
		using (IMagickImageCollection magickImageCollection = new MagickImageCollection(file))
		{
			if (magickImageCollection.Count == 1)
			{
				return DoLosslessCompress(file, magickImageCollection[0]);
			}
		}
		return false;
	}

	private static bool DoLosslessCompress(FileInfo file, IMagickImage image)
	{
		CheckFormat(image);
		bool result = false;
		image.Strip();
		using (TemporaryFile temporaryFile = new TemporaryFile())
		{
			image.Settings.Interlace = Interlace.NoInterlace;
			image.Write(temporaryFile);
			if (temporaryFile.Length < file.Length)
			{
				result = true;
				temporaryFile.CopyTo(file);
				file.Refresh();
			}
		}
		return result;
	}
}
