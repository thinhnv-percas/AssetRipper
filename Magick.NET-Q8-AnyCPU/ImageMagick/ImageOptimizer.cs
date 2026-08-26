using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using ImageMagick.ImageOptimizers;

namespace ImageMagick;

public sealed class ImageOptimizer
{
	private readonly Collection<IImageOptimizer> _optimizers = CreateImageOptimizers();

	public bool OptimalCompression { get; set; }

	private string SupportedFormats
	{
		get
		{
			List<string> list = new List<string>();
			foreach (IImageOptimizer optimizer in _optimizers)
			{
				list.Add(optimizer.Format.Module.ToString());
			}
			return string.Join(", ", list.ToArray());
		}
	}

	public bool Compress(FileInfo file)
	{
		Throw.IfNull("file", file);
		return DoCompress(file);
	}

	public bool Compress(string fileName)
	{
		string text = FileHelper.CheckForBaseDirectory(fileName);
		Throw.IfNullOrEmpty("fileName", text);
		return DoCompress(new FileInfo(text));
	}

	public bool IsSupported(FileInfo file)
	{
		return IsSupported(MagickFormatInfo.Create(file));
	}

	public bool IsSupported(MagickFormatInfo formatInfo)
	{
		Throw.IfNull("formatInfo", formatInfo);
		foreach (IImageOptimizer optimizer in _optimizers)
		{
			if (optimizer.Format.Format == formatInfo.Module)
			{
				return true;
			}
		}
		return false;
	}

	public bool IsSupported(string fileName)
	{
		return IsSupported(MagickFormatInfo.Create(fileName));
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

	private static Collection<IImageOptimizer> CreateImageOptimizers()
	{
		return new Collection<IImageOptimizer>
		{
			new JpegOptimizer(),
			new PngOptimizer(),
			new GifOptimizer()
		};
	}

	private static MagickFormatInfo GetFormatInformation(FileInfo file)
	{
		MagickFormatInfo formatInformation = MagickNET.GetFormatInformation(file);
		if (formatInformation != null)
		{
			return formatInformation;
		}
		return MagickNET.GetFormatInformation(new MagickImageInfo(file).Format);
	}

	private bool DoLosslessCompress(FileInfo file)
	{
		IImageOptimizer optimizer = GetOptimizer(file);
		if (optimizer == null)
		{
			return false;
		}
		optimizer.OptimalCompression = OptimalCompression;
		return optimizer.LosslessCompress(file);
	}

	private bool DoCompress(FileInfo file)
	{
		IImageOptimizer optimizer = GetOptimizer(file);
		if (optimizer == null)
		{
			return false;
		}
		optimizer.OptimalCompression = OptimalCompression;
		return optimizer.Compress(file);
	}

	private IImageOptimizer GetOptimizer(FileInfo file)
	{
		MagickFormatInfo formatInformation = GetFormatInformation(file);
		foreach (IImageOptimizer optimizer in _optimizers)
		{
			if (optimizer.Format.Module == formatInformation.Module)
			{
				return optimizer;
			}
		}
		throw new MagickCorruptImageErrorException($"Invalid format, supported formats are: {SupportedFormats}");
	}
}
