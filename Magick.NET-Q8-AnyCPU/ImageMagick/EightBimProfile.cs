using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Xml;

namespace ImageMagick;

public sealed class EightBimProfile : ImageProfile
{
	private Collection<ClipPath> _clipPaths;

	private int _height;

	private Collection<EightBimValue> _values;

	private int _width;

	public IEnumerable<ClipPath> ClipPaths
	{
		get
		{
			Initialize();
			return _clipPaths;
		}
	}

	public IEnumerable<EightBimValue> Values
	{
		get
		{
			Initialize();
			return _values;
		}
	}

	public EightBimProfile(byte[] data)
		: base("8bim", data)
	{
	}

	public EightBimProfile(string fileName)
		: base("8bim", fileName)
	{
	}

	public EightBimProfile(Stream stream)
		: base("8bim", stream)
	{
	}

	internal EightBimProfile(MagickImage image, byte[] data)
		: base("8bim", data)
	{
		_width = image.Width;
		_height = image.Height;
	}

	private ClipPath CreateClipPath(string name, int offset, int length)
	{
		string clipPath = GetClipPath(offset, length);
		if (string.IsNullOrEmpty(clipPath))
		{
			return null;
		}
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.CreateXmlDeclaration("1.0", "iso-8859-1", null);
		XmlElement xmlElement = XmlHelper.CreateElement(xmlDocument, "svg");
		XmlHelper.SetAttribute(xmlElement, "width", _width);
		XmlHelper.SetAttribute(xmlElement, "height", _height);
		XmlElement element = XmlHelper.CreateElement(XmlHelper.CreateElement(xmlElement, "g"), "path");
		XmlHelper.SetAttribute(element, "fill", "#00000000");
		XmlHelper.SetAttribute(element, "stroke", "#00000000");
		XmlHelper.SetAttribute(element, "stroke-width", "0");
		XmlHelper.SetAttribute(element, "stroke-antialiasing", "false");
		XmlHelper.SetAttribute(element, "d", clipPath);
		return new ClipPath(name, xmlDocument.CreateNavigator());
	}

	private string GetClipPath(int offset, int length)
	{
		return new ClipPathReader(_width, _height).Read(base.Data, offset, length);
	}

	private void Initialize()
	{
		if (_clipPaths != null)
		{
			return;
		}
		_clipPaths = new Collection<ClipPath>();
		_values = new Collection<EightBimValue>();
		int offset = 0;
		while (offset < base.Data.Length)
		{
			if (base.Data[offset++] != 56 || base.Data[offset++] != 66 || base.Data[offset++] != 73 || base.Data[offset++] != 77)
			{
				continue;
			}
			if (offset + 7 > base.Data.Length)
			{
				break;
			}
			short num = ByteConverter.ToShort(base.Data, ref offset);
			bool flag = num > 1999 && num < 2998;
			string name = null;
			int num2 = base.Data[offset++];
			if (num2 != 0)
			{
				if (flag && offset + num2 < base.Data.Length)
				{
					name = Encoding.ASCII.GetString(base.Data, offset, num2);
				}
				offset += num2;
			}
			if ((num2 & 1) == 0)
			{
				offset++;
			}
			num2 = ByteConverter.ToUInt(base.Data, ref offset);
			if (offset + num2 > base.Data.Length || num2 < 0)
			{
				break;
			}
			if (num2 != 0)
			{
				if (flag)
				{
					ClipPath clipPath = CreateClipPath(name, offset, num2);
					if (clipPath != null)
					{
						_clipPaths.Add(clipPath);
					}
				}
				byte[] array = new byte[num2];
				Array.Copy(base.Data, offset, array, 0, num2);
				_values.Add(new EightBimValue(num, array));
			}
			offset += num2;
		}
	}
}
