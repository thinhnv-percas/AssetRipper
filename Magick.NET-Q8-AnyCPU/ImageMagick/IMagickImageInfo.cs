using System;
using System.IO;

namespace ImageMagick;

public interface IMagickImageInfo : IEquatable<IMagickImageInfo>, IComparable<IMagickImageInfo>
{
	ColorSpace ColorSpace { get; }

	CompressionMethod CompressionMethod { get; }

	Density Density { get; }

	string FileName { get; }

	MagickFormat Format { get; }

	int Height { get; }

	Interlace Interlace { get; }

	int Quality { get; }

	int Width { get; }

	void Read(byte[] data);

	void Read(byte[] data, MagickReadSettings readSettings);

	void Read(FileInfo file);

	void Read(FileInfo file, MagickReadSettings readSettings);

	void Read(Stream stream);

	void Read(Stream stream, MagickReadSettings readSettings);

	void Read(string fileName);

	void Read(string fileName, MagickReadSettings readSettings);
}
