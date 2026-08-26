using System;
using System.IO;

namespace ImageMagick;

public class ImageProfile : IEquatable<ImageProfile>
{
	public string Name { get; private set; }

	protected byte[] Data { get; set; }

	public ImageProfile(string name, byte[] data)
	{
		Throw.IfNullOrEmpty("name", name);
		Throw.IfNullOrEmpty("data", data);
		Name = name;
		Data = Copy(data);
	}

	public ImageProfile(string name, Stream stream)
	{
		Throw.IfNullOrEmpty("name", name);
		Name = name;
		Bytes bytes = new Bytes(stream);
		Data = bytes.Data;
	}

	public ImageProfile(string name, string fileName)
	{
		Throw.IfNullOrEmpty("name", name);
		Name = name;
		string path = FileHelper.CheckForBaseDirectory(fileName);
		Data = File.ReadAllBytes(path);
	}

	protected ImageProfile(string name)
	{
		Throw.IfNullOrEmpty("name", name);
		Name = name;
	}

	public static bool operator ==(ImageProfile left, ImageProfile right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(ImageProfile left, ImageProfile right)
	{
		return !object.Equals(left, right);
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		return Equals(obj as ImageProfile);
	}

	public bool Equals(ImageProfile other)
	{
		if ((object)other == null)
		{
			return false;
		}
		if ((object)this == other)
		{
			return true;
		}
		if (Name != other.Name)
		{
			return false;
		}
		UpdateData();
		if (Data == null)
		{
			return other.Data == null;
		}
		if (other.Data == null)
		{
			return false;
		}
		if (Data.Length != other.Data.Length)
		{
			return false;
		}
		for (int i = 0; i < Data.Length; i++)
		{
			if (Data[i] != other.Data[i])
			{
				return false;
			}
		}
		return true;
	}

	public override int GetHashCode()
	{
		return Data.GetHashCode() ^ Name.GetHashCode();
	}

	public byte[] ToByteArray()
	{
		UpdateData();
		return Copy(Data);
	}

	protected virtual void UpdateData()
	{
	}

	private static byte[] Copy(byte[] data)
	{
		if (data == null || data.Length == 0)
		{
			return new byte[0];
		}
		byte[] array = new byte[data.Length];
		data.CopyTo(array, 0);
		return array;
	}
}
