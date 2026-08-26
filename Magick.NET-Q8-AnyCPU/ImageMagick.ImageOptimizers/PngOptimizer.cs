using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace ImageMagick.ImageOptimizers;

public sealed class PngOptimizer : IImageOptimizer
{
	public bool OptimalCompression { get; set; }

	public MagickFormatInfo Format => MagickNET.GetFormatInformation(MagickFormat.Png);

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

	private static void CheckFormat(MagickImage image)
	{
		MagickFormat module = image.FormatInfo.Module;
		if (module != MagickFormat.Png)
		{
			throw new MagickCorruptImageErrorException("Invalid image format: " + module);
		}
	}

	private static void CheckTransparency(MagickImage image)
	{
		if (image.HasAlpha && image.IsOpaque)
		{
			image.HasAlpha = false;
		}
	}

	private bool DoLosslessCompress(FileInfo file)
	{
		bool result = false;
		using (MagickImage magickImage = new MagickImage(file))
		{
			CheckFormat(magickImage);
			magickImage.Strip();
			magickImage.Settings.SetDefine(MagickFormat.Png, "exclude-chunks", "all");
			magickImage.Settings.SetDefine(MagickFormat.Png, "include-chunks", "tRNS,gAMA");
			CheckTransparency(magickImage);
			Collection<TemporaryFile> collection = new Collection<TemporaryFile>();
			try
			{
				TemporaryFile temporaryFile = null;
				foreach (int quality in GetQualityList())
				{
					TemporaryFile temporaryFile2 = new TemporaryFile();
					collection.Add(temporaryFile2);
					magickImage.Quality = quality;
					magickImage.Write(temporaryFile2);
					if (temporaryFile == null || temporaryFile.Length > temporaryFile2.Length)
					{
						temporaryFile = temporaryFile2;
					}
				}
				if (temporaryFile.Length < file.Length)
				{
					result = true;
					temporaryFile.CopyTo(file);
					file.Refresh();
				}
			}
			finally
			{
				foreach (TemporaryFile item in collection)
				{
					item.Dispose();
				}
			}
		}
		return result;
	}

	private IEnumerable<int> GetQualityList()
	{
		if (!OptimalCompression)
		{
			return new int[1] { 90 };
		}
		return new int[4] { 91, 94, 95, 97 };
	}
}
