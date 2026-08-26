using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace ImageMagick;

public sealed class MagickFactory : IMagickFactory
{
	public IMagickImage CreateImage(Bitmap bitmap)
	{
		return new MagickImage(bitmap);
	}

	public IMagickImageCollection CreateCollection()
	{
		return new MagickImageCollection();
	}

	public IMagickImageCollection CreateCollection(byte[] data)
	{
		return new MagickImageCollection(data);
	}

	public IMagickImageCollection CreateCollection(byte[] data, MagickReadSettings readSettings)
	{
		return new MagickImageCollection(data, readSettings);
	}

	public IMagickImageCollection CreateCollection(FileInfo file)
	{
		return new MagickImageCollection(file);
	}

	public IMagickImageCollection CreateCollection(FileInfo file, MagickReadSettings readSettings)
	{
		return new MagickImageCollection(file, readSettings);
	}

	public IMagickImageCollection CreateCollection(IEnumerable<IMagickImage> images)
	{
		return new MagickImageCollection(images);
	}

	public IMagickImageCollection CreateCollection(Stream stream)
	{
		return new MagickImageCollection(stream);
	}

	public IMagickImageCollection CreateCollection(Stream stream, MagickReadSettings readSettings)
	{
		return new MagickImageCollection(stream, readSettings);
	}

	public IMagickImageCollection CreateCollection(string fileName)
	{
		return new MagickImageCollection(fileName);
	}

	public IMagickImageCollection CreateCollection(string fileName, MagickReadSettings readSettings)
	{
		return new MagickImageCollection(fileName, readSettings);
	}

	public IMagickImage CreateImage()
	{
		return new MagickImage();
	}

	public IMagickImage CreateImage(byte[] data)
	{
		return new MagickImage(data);
	}

	public IMagickImage CreateImage(byte[] data, MagickReadSettings readSettings)
	{
		return new MagickImage(data, readSettings);
	}

	public IMagickImage CreateImage(FileInfo file)
	{
		return new MagickImage(file);
	}

	public IMagickImage CreateImage(FileInfo file, MagickReadSettings readSettings)
	{
		return new MagickImage(file, readSettings);
	}

	public IMagickImage CreateImage(MagickColor color, int width, int height)
	{
		return new MagickImage(color, width, height);
	}

	public IMagickImage CreateImage(Stream stream)
	{
		return new MagickImage(stream);
	}

	public IMagickImage CreateImage(Stream stream, MagickReadSettings readSettings)
	{
		return new MagickImage(stream, readSettings);
	}

	public IMagickImage CreateImage(string fileName)
	{
		return new MagickImage(fileName);
	}

	public IMagickImage CreateImage(string fileName, int width, int height)
	{
		return new MagickImage(fileName, width, height);
	}

	public IMagickImage CreateImage(string fileName, MagickReadSettings readSettings)
	{
		return new MagickImage(fileName, readSettings);
	}

	public IMagickImageInfo CreateImageInfo()
	{
		return new MagickImageInfo();
	}

	public IMagickImageInfo CreateImageInfo(byte[] data)
	{
		return new MagickImageInfo(data);
	}

	public IMagickImageInfo CreateImageInfo(byte[] data, MagickReadSettings readSettings)
	{
		return new MagickImageInfo(data, readSettings);
	}

	public IMagickImageInfo CreateImageInfo(FileInfo file)
	{
		return new MagickImageInfo(file);
	}

	public IMagickImageInfo CreateImageInfo(FileInfo file, MagickReadSettings readSettings)
	{
		return new MagickImageInfo(file, readSettings);
	}

	public IMagickImageInfo CreateImageInfo(Stream stream)
	{
		return new MagickImageInfo(stream);
	}

	public IMagickImageInfo CreateImageInfo(Stream stream, MagickReadSettings readSettings)
	{
		return new MagickImageInfo(stream, readSettings);
	}

	public IMagickImageInfo CreateImageInfo(string fileName)
	{
		return new MagickImageInfo(fileName);
	}

	public IMagickImageInfo CreateImageInfo(string fileName, MagickReadSettings readSettings)
	{
		return new MagickImageInfo(fileName, readSettings);
	}
}
