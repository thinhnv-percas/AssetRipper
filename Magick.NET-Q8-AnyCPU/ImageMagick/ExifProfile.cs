using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace ImageMagick;

public sealed class ExifProfile : ImageProfile
{
	private Collection<ExifValue> _values;

	private List<ExifTag> _invalidTags;

	private int _thumbnailOffset;

	private int _thumbnailLength;

	public ExifParts Parts { get; set; }

	public IEnumerable<ExifTag> InvalidTags
	{
		get
		{
			InitializeValues();
			return _invalidTags;
		}
	}

	public IEnumerable<ExifValue> Values
	{
		get
		{
			InitializeValues();
			return _values;
		}
	}

	public ExifProfile()
		: base("exif")
	{
		Initialize();
	}

	public ExifProfile(byte[] data)
		: base("exif", data)
	{
		Initialize();
	}

	public ExifProfile(string fileName)
		: base("exif", fileName)
	{
		Initialize();
	}

	public ExifProfile(Stream stream)
		: base("exif", stream)
	{
		Initialize();
	}

	public MagickImage CreateThumbnail()
	{
		InitializeValues();
		if (_thumbnailOffset == 0 || _thumbnailLength == 0)
		{
			return null;
		}
		if (base.Data.Length < _thumbnailOffset + _thumbnailLength)
		{
			return null;
		}
		byte[] array = new byte[_thumbnailLength];
		Array.Copy(base.Data, _thumbnailOffset, array, 0, _thumbnailLength);
		return new MagickImage(array);
	}

	public ExifValue GetValue(ExifTag tag)
	{
		foreach (ExifValue value in Values)
		{
			if (value.Tag == tag)
			{
				return value;
			}
		}
		return null;
	}

	public bool RemoveValue(ExifTag tag)
	{
		InitializeValues();
		for (int i = 0; i < _values.Count; i++)
		{
			if (_values[i].Tag == tag)
			{
				_values.RemoveAt(i);
				return true;
			}
		}
		return false;
	}

	public void SetValue(ExifTag tag, object value)
	{
		foreach (ExifValue value2 in Values)
		{
			if (value2.Tag == tag)
			{
				value2.Value = value;
				return;
			}
		}
		ExifValue item = ExifValue.Create(tag, value);
		_values.Add(item);
	}

	protected override void UpdateData()
	{
		if (_values == null || _values.Count == 0)
		{
			base.Data = null;
			return;
		}
		ExifWriter exifWriter = new ExifWriter(_values, Parts);
		base.Data = exifWriter.GetData();
	}

	private void Initialize()
	{
		Parts = ExifParts.All;
		_invalidTags = new List<ExifTag>();
	}

	private void InitializeValues()
	{
		if (_values == null)
		{
			if (base.Data == null)
			{
				_values = new Collection<ExifValue>();
				return;
			}
			ExifReader exifReader = new ExifReader();
			_values = exifReader.Read(base.Data);
			_invalidTags = new List<ExifTag>(exifReader.InvalidTags);
			_thumbnailOffset = (int)exifReader.ThumbnailOffset;
			_thumbnailLength = (int)exifReader.ThumbnailLength;
		}
	}
}
