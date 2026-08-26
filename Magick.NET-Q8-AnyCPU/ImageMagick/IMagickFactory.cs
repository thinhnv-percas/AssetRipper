using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace ImageMagick;

public interface IMagickFactory
{
	IMagickImage CreateImage(Bitmap bitmap);

	IMagickImageCollection CreateCollection();

	IMagickImageCollection CreateCollection(byte[] data);

	IMagickImageCollection CreateCollection(byte[] data, MagickReadSettings readSettings);

	IMagickImageCollection CreateCollection(FileInfo file);

	IMagickImageCollection CreateCollection(FileInfo file, MagickReadSettings readSettings);

	IMagickImageCollection CreateCollection(IEnumerable<IMagickImage> images);

	IMagickImageCollection CreateCollection(Stream stream);

	IMagickImageCollection CreateCollection(Stream stream, MagickReadSettings readSettings);

	IMagickImageCollection CreateCollection(string fileName);

	IMagickImageCollection CreateCollection(string fileName, MagickReadSettings readSettings);

	IMagickImage CreateImage();

	IMagickImage CreateImage(byte[] data);

	IMagickImage CreateImage(byte[] data, MagickReadSettings readSettings);

	IMagickImage CreateImage(FileInfo file);

	IMagickImage CreateImage(FileInfo file, MagickReadSettings readSettings);

	IMagickImage CreateImage(MagickColor color, int width, int height);

	IMagickImage CreateImage(Stream stream);

	IMagickImage CreateImage(Stream stream, MagickReadSettings readSettings);

	IMagickImage CreateImage(string fileName);

	IMagickImage CreateImage(string fileName, int width, int height);

	IMagickImage CreateImage(string fileName, MagickReadSettings readSettings);

	IMagickImageInfo CreateImageInfo();

	IMagickImageInfo CreateImageInfo(byte[] data);

	IMagickImageInfo CreateImageInfo(byte[] data, MagickReadSettings readSettings);

	IMagickImageInfo CreateImageInfo(FileInfo file);

	IMagickImageInfo CreateImageInfo(FileInfo file, MagickReadSettings readSettings);

	IMagickImageInfo CreateImageInfo(Stream stream);

	IMagickImageInfo CreateImageInfo(Stream stream, MagickReadSettings readSettings);

	IMagickImageInfo CreateImageInfo(string fileName);

	IMagickImageInfo CreateImageInfo(string fileName, MagickReadSettings readSettings);
}
