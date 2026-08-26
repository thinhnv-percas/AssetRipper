using System;
using System.Collections.Generic;
using System.IO;

namespace ImageMagick;

public sealed class MagickImageInfo : IMagickImageInfo, IEquatable<IMagickImageInfo>, IComparable<IMagickImageInfo>
{
	public ColorSpace ColorSpace { get; private set; }

	public CompressionMethod CompressionMethod { get; private set; }

	public Density Density { get; private set; }

	public string FileName { get; private set; }

	public MagickFormat Format { get; private set; }

	public int Height { get; private set; }

	public Interlace Interlace { get; private set; }

	public int Quality { get; private set; }

	public int Width { get; private set; }

	public MagickImageInfo()
	{
	}

	public MagickImageInfo(byte[] data)
		: this()
	{
		Read(data);
	}

	public MagickImageInfo(byte[] data, MagickReadSettings readSettings)
		: this()
	{
		Read(data, readSettings);
	}

	public MagickImageInfo(FileInfo file)
		: this()
	{
		Read(file);
	}

	public MagickImageInfo(FileInfo file, MagickReadSettings readSettings)
		: this()
	{
		Read(file, readSettings);
	}

	public MagickImageInfo(Stream stream)
		: this()
	{
		Read(stream);
	}

	public MagickImageInfo(Stream stream, MagickReadSettings readSettings)
		: this()
	{
		Read(stream, readSettings);
	}

	public MagickImageInfo(string fileName)
		: this()
	{
		Read(fileName);
	}

	public MagickImageInfo(string fileName, MagickReadSettings readSettings)
		: this()
	{
		Read(fileName, readSettings);
	}

	public static bool operator ==(MagickImageInfo left, MagickImageInfo right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(MagickImageInfo left, MagickImageInfo right)
	{
		return !object.Equals(left, right);
	}

	public static bool operator >(MagickImageInfo left, MagickImageInfo right)
	{
		if ((object)left == null)
		{
			return (object)right == null;
		}
		return left.CompareTo(right) == 1;
	}

	public static bool operator <(MagickImageInfo left, MagickImageInfo right)
	{
		if ((object)left == null)
		{
			return (object)right != null;
		}
		return left.CompareTo(right) == -1;
	}

	public static bool operator >=(MagickImageInfo left, MagickImageInfo right)
	{
		if ((object)left == null)
		{
			return (object)right == null;
		}
		return left.CompareTo(right) >= 0;
	}

	public static bool operator <=(MagickImageInfo left, MagickImageInfo right)
	{
		if ((object)left == null)
		{
			return (object)right != null;
		}
		return left.CompareTo(right) <= 0;
	}

	public static IEnumerable<IMagickImageInfo> ReadCollection(byte[] data)
	{
		using IMagickImageCollection images = new MagickImageCollection();
		images.Ping(data);
		foreach (MagickImage item in images)
		{
			MagickImageInfo magickImageInfo = new MagickImageInfo();
			magickImageInfo.Initialize(item);
			yield return magickImageInfo;
		}
	}

	public static IEnumerable<IMagickImageInfo> ReadCollection(byte[] data, MagickReadSettings readSettings)
	{
		using IMagickImageCollection images = new MagickImageCollection();
		images.Ping(data, readSettings);
		foreach (MagickImage item in images)
		{
			MagickImageInfo magickImageInfo = new MagickImageInfo();
			magickImageInfo.Initialize(item);
			yield return magickImageInfo;
		}
	}

	public static IEnumerable<IMagickImageInfo> ReadCollection(FileInfo file)
	{
		Throw.IfNull("file", file);
		return ReadCollection(file.FullName);
	}

	public static IEnumerable<IMagickImageInfo> ReadCollection(FileInfo file, MagickReadSettings readSettings)
	{
		Throw.IfNull("file", file);
		return ReadCollection(file.FullName, readSettings);
	}

	public static IEnumerable<MagickImageInfo> ReadCollection(Stream stream)
	{
		using IMagickImageCollection images = new MagickImageCollection();
		images.Ping(stream);
		foreach (MagickImage item in images)
		{
			MagickImageInfo magickImageInfo = new MagickImageInfo();
			magickImageInfo.Initialize(item);
			yield return magickImageInfo;
		}
	}

	public static IEnumerable<IMagickImageInfo> ReadCollection(Stream stream, MagickReadSettings readSettings)
	{
		using IMagickImageCollection images = new MagickImageCollection();
		images.Ping(stream, readSettings);
		foreach (MagickImage item in images)
		{
			MagickImageInfo magickImageInfo = new MagickImageInfo();
			magickImageInfo.Initialize(item);
			yield return magickImageInfo;
		}
	}

	public static IEnumerable<IMagickImageInfo> ReadCollection(string fileName)
	{
		using IMagickImageCollection images = new MagickImageCollection();
		images.Ping(fileName);
		foreach (MagickImage item in images)
		{
			MagickImageInfo magickImageInfo = new MagickImageInfo();
			magickImageInfo.Initialize(item);
			yield return magickImageInfo;
		}
	}

	public static IEnumerable<IMagickImageInfo> ReadCollection(string fileName, MagickReadSettings readSettings)
	{
		using IMagickImageCollection images = new MagickImageCollection();
		images.Ping(fileName, readSettings);
		foreach (MagickImage item in images)
		{
			MagickImageInfo magickImageInfo = new MagickImageInfo();
			magickImageInfo.Initialize(item);
			yield return magickImageInfo;
		}
	}

	public int CompareTo(IMagickImageInfo other)
	{
		if (other == null)
		{
			return 1;
		}
		int num = Width * Height;
		int num2 = other.Width * other.Height;
		if (num == num2)
		{
			return 0;
		}
		if (num >= num2)
		{
			return 1;
		}
		return -1;
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		return Equals(obj as IMagickImageInfo);
	}

	public bool Equals(IMagickImageInfo other)
	{
		if (other == null)
		{
			return false;
		}
		if (this == other)
		{
			return true;
		}
		if (ColorSpace == other.ColorSpace && CompressionMethod == other.CompressionMethod && Density == other.Density && FileName == other.FileName && Format == other.Format && Height == other.Height && Interlace == other.Interlace)
		{
			return Width == other.Width;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return ColorSpace.GetHashCode() ^ CompressionMethod.GetHashCode() ^ Density.GetHashCode() ^ FileName.GetHashCode() ^ Format.GetHashCode() ^ Height.GetHashCode() ^ Interlace.GetHashCode() ^ Width.GetHashCode();
	}

	public void Read(byte[] data)
	{
		using MagickImage magickImage = new MagickImage();
		magickImage.Ping(data);
		Initialize(magickImage);
	}

	public void Read(byte[] data, MagickReadSettings readSettings)
	{
		using MagickImage magickImage = new MagickImage();
		magickImage.Ping(data, readSettings);
		Initialize(magickImage);
	}

	public void Read(FileInfo file)
	{
		using MagickImage magickImage = new MagickImage();
		magickImage.Ping(file);
		Initialize(magickImage);
	}

	public void Read(FileInfo file, MagickReadSettings readSettings)
	{
		using MagickImage magickImage = new MagickImage();
		magickImage.Ping(file, readSettings);
		Initialize(magickImage);
	}

	public void Read(Stream stream)
	{
		using MagickImage magickImage = new MagickImage();
		magickImage.Ping(stream);
		Initialize(magickImage);
	}

	public void Read(Stream stream, MagickReadSettings readSettings)
	{
		using MagickImage magickImage = new MagickImage();
		magickImage.Ping(stream, readSettings);
		Initialize(magickImage);
	}

	public void Read(string fileName)
	{
		using MagickImage magickImage = new MagickImage();
		magickImage.Ping(fileName);
		Initialize(magickImage);
	}

	public void Read(string fileName, MagickReadSettings readSettings)
	{
		using MagickImage magickImage = new MagickImage();
		magickImage.Ping(fileName, readSettings);
		Initialize(magickImage);
	}

	private void Initialize(MagickImage image)
	{
		ColorSpace = image.ColorSpace;
		CompressionMethod = image.CompressionMethod;
		Density = image.Density;
		FileName = image.FileName;
		Format = image.Format;
		Height = image.Height;
		Interlace = image.Interlace;
		Quality = image.Quality;
		Width = image.Width;
	}
}
