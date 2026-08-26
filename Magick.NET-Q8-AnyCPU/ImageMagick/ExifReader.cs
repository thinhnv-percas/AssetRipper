using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ImageMagick;

internal sealed class ExifReader
{
	private delegate TDataType ConverterMethod<TDataType>(byte[] data);

	private readonly Collection<ExifTag> _invalidTags = new Collection<ExifTag>();

	private byte[] _data;

	private uint _index;

	private bool _isLittleEndian;

	private uint _exifOffset;

	private uint _gpsOffset;

	private uint _startIndex;

	public uint ThumbnailLength { get; private set; }

	public uint ThumbnailOffset { get; private set; }

	public IEnumerable<ExifTag> InvalidTags => _invalidTags;

	private int RemainingLength
	{
		get
		{
			if (_index >= _data.Length)
			{
				return 0;
			}
			return _data.Length - (int)_index;
		}
	}

	public Collection<ExifValue> Read(byte[] data)
	{
		Collection<ExifValue> collection = new Collection<ExifValue>();
		_data = data;
		if (GetString(4u) == "Exif")
		{
			if (GetShort() != 0)
			{
				return collection;
			}
			_startIndex = 6u;
		}
		else
		{
			_index = 0u;
		}
		_isLittleEndian = GetString(2u) == "II";
		if (GetShort() != 42)
		{
			return collection;
		}
		uint index = GetLong();
		AddValues(collection, index);
		uint offset = GetLong();
		GetThumbnail(offset);
		if (_exifOffset != 0)
		{
			AddValues(collection, _exifOffset);
		}
		if (_gpsOffset != 0)
		{
			AddValues(collection, _gpsOffset);
		}
		return collection;
	}

	private static TDataType[] ToArray<TDataType>(ExifDataType dataType, byte[] data, ConverterMethod<TDataType> converter)
	{
		int size = (int)ExifValue.GetSize(dataType);
		int num = data.Length / size;
		TDataType[] array = new TDataType[num];
		byte[] array2 = new byte[size];
		for (int i = 0; i < num; i++)
		{
			Array.Copy(data, i * size, array2, 0, size);
			array.SetValue(converter(array2), i);
		}
		return array;
	}

	private static byte ToByte(byte[] data)
	{
		return data[0];
	}

	private static string ToString(byte[] data)
	{
		string text = Encoding.UTF8.GetString(data, 0, data.Length);
		int num = text.IndexOf('\0');
		if (num != -1)
		{
			text = text.Substring(0, num);
		}
		return text;
	}

	private void AddValues(Collection<ExifValue> values, uint index)
	{
		_index = _startIndex + index;
		ushort num = GetShort();
		for (ushort num2 = 0; num2 < num; num2++)
		{
			ExifValue exifValue = CreateValue();
			if (!(exifValue == null))
			{
				bool flag = false;
				foreach (ExifValue value in values)
				{
					if (value.Tag == exifValue.Tag)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					if (exifValue.Tag == ExifTag.SubIFDOffset)
					{
						if (exifValue.DataType == ExifDataType.Long)
						{
							_exifOffset = (uint)exifValue.Value;
						}
					}
					else if (exifValue.Tag == ExifTag.GPSIFDOffset)
					{
						if (exifValue.DataType == ExifDataType.Long)
						{
							_gpsOffset = (uint)exifValue.Value;
						}
					}
					else
					{
						values.Add(exifValue);
					}
				}
			}
		}
	}

	private object ConvertValue(ExifDataType dataType, byte[] data, uint numberOfComponents)
	{
		if (data == null || data.Length == 0)
		{
			return null;
		}
		switch (dataType)
		{
		case ExifDataType.Unknown:
			return null;
		case ExifDataType.Ascii:
			return ToString(data);
		case ExifDataType.Byte:
			if (numberOfComponents == 1)
			{
				return ToByte(data);
			}
			return data;
		case ExifDataType.DoubleFloat:
			if (numberOfComponents == 1)
			{
				return ToDouble(data);
			}
			return ToArray(dataType, data, ToDouble);
		case ExifDataType.Long:
			if (numberOfComponents == 1)
			{
				return ToLong(data);
			}
			return ToArray(dataType, data, ToLong);
		case ExifDataType.Rational:
			if (numberOfComponents == 1)
			{
				return ToRational(data);
			}
			return ToArray(dataType, data, ToRational);
		case ExifDataType.Short:
			if (numberOfComponents == 1)
			{
				return ToShort(data);
			}
			return ToArray(dataType, data, ToShort);
		case ExifDataType.SignedByte:
			if (numberOfComponents == 1)
			{
				return ToSignedByte(data);
			}
			return ToArray(dataType, data, ToSignedByte);
		case ExifDataType.SignedLong:
			if (numberOfComponents == 1)
			{
				return ToSignedLong(data);
			}
			return ToArray(dataType, data, ToSignedLong);
		case ExifDataType.SignedRational:
			if (numberOfComponents == 1)
			{
				return ToSignedRational(data);
			}
			return ToArray(dataType, data, ToSignedRational);
		case ExifDataType.SignedShort:
			if (numberOfComponents == 1)
			{
				return ToSignedShort(data);
			}
			return ToArray(dataType, data, ToSignedShort);
		case ExifDataType.SingleFloat:
			if (numberOfComponents == 1)
			{
				return ToSingle(data);
			}
			return ToArray(dataType, data, ToSingle);
		case ExifDataType.Undefined:
			if (numberOfComponents == 1)
			{
				return ToByte(data);
			}
			return data;
		default:
			throw new NotSupportedException();
		}
	}

	private ExifValue CreateValue()
	{
		if (RemainingLength < 12)
		{
			return null;
		}
		ExifTag exifTag = (ExifTag)GetShort();
		ExifDataType exifDataType = EnumHelper.Parse(GetShort(), ExifDataType.Unknown);
		object value = null;
		if (exifDataType == ExifDataType.Unknown)
		{
			return new ExifValue(exifTag, exifDataType, value, isArray: false);
		}
		uint num = GetLong();
		if (exifDataType == ExifDataType.Undefined && num == 0)
		{
			num = 4u;
		}
		uint num2 = num * ExifValue.GetSize(exifDataType);
		byte[] bytes = GetBytes(4u);
		if (num2 > 4)
		{
			uint index = _index;
			_index = ToLong(bytes) + _startIndex;
			if (RemainingLength < num2)
			{
				_invalidTags.Add(exifTag);
				_index = index;
				return null;
			}
			value = ConvertValue(exifDataType, GetBytes(num2), num);
			_index = index;
		}
		else
		{
			value = ConvertValue(exifDataType, bytes, num);
		}
		bool isArray = value != null && num > 1;
		return new ExifValue(exifTag, exifDataType, value, isArray);
	}

	private byte[] GetBytes(uint length)
	{
		if (_index + length > (uint)_data.Length)
		{
			return null;
		}
		byte[] array = new byte[length];
		Array.Copy(_data, (int)_index, array, 0, (int)length);
		_index += length;
		return array;
	}

	private uint GetLong()
	{
		return ToLong(GetBytes(4u));
	}

	private ushort GetShort()
	{
		return ToShort(GetBytes(2u));
	}

	private string GetString(uint length)
	{
		byte[] bytes = GetBytes(length);
		if (bytes == null || bytes.Length == 0)
		{
			return null;
		}
		return ToString(bytes);
	}

	private void GetThumbnail(uint offset)
	{
		Collection<ExifValue> collection = new Collection<ExifValue>();
		AddValues(collection, offset);
		foreach (ExifValue item in collection)
		{
			if (item.Tag == ExifTag.JPEGInterchangeFormat && item.DataType == ExifDataType.Long)
			{
				ThumbnailOffset = (uint)item.Value + _startIndex;
			}
			else if (item.Tag == ExifTag.JPEGInterchangeFormatLength && item.DataType == ExifDataType.Long)
			{
				ThumbnailLength = (uint)item.Value;
			}
		}
	}

	private double ToDouble(byte[] data)
	{
		if (!ValidateArray(data, 8))
		{
			return 0.0;
		}
		return BitConverter.ToDouble(data, 0);
	}

	private uint ToLong(byte[] data)
	{
		if (!ValidateArray(data, 4))
		{
			return 0u;
		}
		return BitConverter.ToUInt32(data, 0);
	}

	private ushort ToShort(byte[] data)
	{
		if (!ValidateArray(data, 2))
		{
			return 0;
		}
		return BitConverter.ToUInt16(data, 0);
	}

	private float ToSingle(byte[] data)
	{
		if (!ValidateArray(data, 4))
		{
			return 0f;
		}
		return BitConverter.ToSingle(data, 0);
	}

	private Rational ToRational(byte[] data)
	{
		if (!ValidateArray(data, 8, 4))
		{
			return default(Rational);
		}
		uint numerator = BitConverter.ToUInt32(data, 0);
		uint denominator = BitConverter.ToUInt32(data, 4);
		return new Rational(numerator, denominator, simplify: false);
	}

	private sbyte ToSignedByte(byte[] data)
	{
		return (sbyte)data[0];
	}

	private int ToSignedLong(byte[] data)
	{
		if (!ValidateArray(data, 4))
		{
			return 0;
		}
		return BitConverter.ToInt32(data, 0);
	}

	private SignedRational ToSignedRational(byte[] data)
	{
		if (!ValidateArray(data, 8, 4))
		{
			return default(SignedRational);
		}
		int numerator = BitConverter.ToInt32(data, 0);
		int denominator = BitConverter.ToInt32(data, 4);
		return new SignedRational(numerator, denominator, simplify: false);
	}

	private short ToSignedShort(byte[] data)
	{
		if (!ValidateArray(data, 2))
		{
			return 0;
		}
		return BitConverter.ToInt16(data, 0);
	}

	private bool ValidateArray(byte[] data, int size)
	{
		return ValidateArray(data, size, size);
	}

	private bool ValidateArray(byte[] data, int size, int stepSize)
	{
		if (data == null || data.Length < size)
		{
			return false;
		}
		if (_isLittleEndian == BitConverter.IsLittleEndian)
		{
			return true;
		}
		for (int i = 0; i < data.Length; i += stepSize)
		{
			Array.Reverse(data, i, stepSize);
		}
		return true;
	}
}
