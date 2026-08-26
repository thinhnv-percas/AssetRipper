using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ImageMagick;

internal sealed class ExifWriter
{
	private const int _StartIndex = 6;

	private static readonly ExifTag[] _IfdTags = new ExifTag[127]
	{
		ExifTag.SubfileType,
		ExifTag.OldSubfileType,
		ExifTag.ImageWidth,
		ExifTag.ImageLength,
		ExifTag.BitsPerSample,
		ExifTag.Compression,
		ExifTag.PhotometricInterpretation,
		ExifTag.Thresholding,
		ExifTag.CellWidth,
		ExifTag.CellLength,
		ExifTag.FillOrder,
		ExifTag.DocumentName,
		ExifTag.ImageDescription,
		ExifTag.Make,
		ExifTag.Model,
		ExifTag.StripOffsets,
		ExifTag.Orientation,
		ExifTag.SamplesPerPixel,
		ExifTag.RowsPerStrip,
		ExifTag.StripByteCounts,
		ExifTag.MinSampleValue,
		ExifTag.MaxSampleValue,
		ExifTag.XResolution,
		ExifTag.YResolution,
		ExifTag.PlanarConfiguration,
		ExifTag.PageName,
		ExifTag.XPosition,
		ExifTag.YPosition,
		ExifTag.FreeOffsets,
		ExifTag.FreeByteCounts,
		ExifTag.GrayResponseUnit,
		ExifTag.GrayResponseCurve,
		ExifTag.T4Options,
		ExifTag.T6Options,
		ExifTag.ResolutionUnit,
		ExifTag.PageNumber,
		ExifTag.ColorResponseUnit,
		ExifTag.TransferFunction,
		ExifTag.Software,
		ExifTag.DateTime,
		ExifTag.Artist,
		ExifTag.HostComputer,
		ExifTag.Predictor,
		ExifTag.WhitePoint,
		ExifTag.PrimaryChromaticities,
		ExifTag.ColorMap,
		ExifTag.HalftoneHints,
		ExifTag.TileWidth,
		ExifTag.TileLength,
		ExifTag.TileOffsets,
		ExifTag.TileByteCounts,
		ExifTag.BadFaxLines,
		ExifTag.CleanFaxData,
		ExifTag.ConsecutiveBadFaxLines,
		ExifTag.InkSet,
		ExifTag.InkNames,
		ExifTag.NumberOfInks,
		ExifTag.DotRange,
		ExifTag.TargetPrinter,
		ExifTag.ExtraSamples,
		ExifTag.SampleFormat,
		ExifTag.SMinSampleValue,
		ExifTag.SMaxSampleValue,
		ExifTag.TransferRange,
		ExifTag.ClipPath,
		ExifTag.XClipPathUnits,
		ExifTag.YClipPathUnits,
		ExifTag.Indexed,
		ExifTag.JPEGTables,
		ExifTag.OPIProxy,
		ExifTag.ProfileType,
		ExifTag.FaxProfile,
		ExifTag.CodingMethods,
		ExifTag.VersionYear,
		ExifTag.ModeNumber,
		ExifTag.Decode,
		ExifTag.DefaultImageColor,
		ExifTag.T82ptions,
		ExifTag.JPEGProc,
		ExifTag.JPEGInterchangeFormat,
		ExifTag.JPEGInterchangeFormatLength,
		ExifTag.JPEGRestartInterval,
		ExifTag.JPEGLosslessPredictors,
		ExifTag.JPEGPointTransforms,
		ExifTag.JPEGQTables,
		ExifTag.JPEGDCTables,
		ExifTag.JPEGACTables,
		ExifTag.YCbCrCoefficients,
		ExifTag.YCbCrSubsampling,
		ExifTag.YCbCrSubsampling,
		ExifTag.YCbCrPositioning,
		ExifTag.ReferenceBlackWhite,
		ExifTag.StripRowCounts,
		ExifTag.XMP,
		ExifTag.Rating,
		ExifTag.RatingPercent,
		ExifTag.ImageID,
		ExifTag.CFARepeatPatternDim,
		ExifTag.CFAPattern2,
		ExifTag.BatteryLevel,
		ExifTag.Copyright,
		ExifTag.MDFileTag,
		ExifTag.MDScalePixel,
		ExifTag.MDLabName,
		ExifTag.MDSampleInfo,
		ExifTag.MDPrepDate,
		ExifTag.MDPrepTime,
		ExifTag.MDFileUnits,
		ExifTag.PixelScale,
		ExifTag.IntergraphPacketData,
		ExifTag.IntergraphRegisters,
		ExifTag.IntergraphMatrix,
		ExifTag.ModelTiePoint,
		ExifTag.SEMInfo,
		ExifTag.ModelTransform,
		ExifTag.ImageLayer,
		ExifTag.FaxRecvParams,
		ExifTag.FaxSubaddress,
		ExifTag.FaxRecvTime,
		ExifTag.ImageSourceData,
		ExifTag.XPTitle,
		ExifTag.XPComment,
		ExifTag.XPAuthor,
		ExifTag.XPKeywords,
		ExifTag.XPSubject,
		ExifTag.GDALMetadata,
		ExifTag.GDALNoData
	};

	private static readonly ExifTag[] _ExifTags = new ExifTag[92]
	{
		ExifTag.ExposureTime,
		ExifTag.FNumber,
		ExifTag.ExposureProgram,
		ExifTag.SpectralSensitivity,
		ExifTag.ISOSpeedRatings,
		ExifTag.OECF,
		ExifTag.Interlace,
		ExifTag.TimeZoneOffset,
		ExifTag.SelfTimerMode,
		ExifTag.SensitivityType,
		ExifTag.StandardOutputSensitivity,
		ExifTag.RecommendedExposureIndex,
		ExifTag.ISOSpeed,
		ExifTag.ISOSpeedLatitudeyyy,
		ExifTag.ISOSpeedLatitudezzz,
		ExifTag.ExifVersion,
		ExifTag.DateTimeOriginal,
		ExifTag.DateTimeDigitized,
		ExifTag.OffsetTime,
		ExifTag.OffsetTimeOriginal,
		ExifTag.OffsetTimeDigitized,
		ExifTag.ComponentsConfiguration,
		ExifTag.CompressedBitsPerPixel,
		ExifTag.ShutterSpeedValue,
		ExifTag.ApertureValue,
		ExifTag.BrightnessValue,
		ExifTag.ExposureBiasValue,
		ExifTag.MaxApertureValue,
		ExifTag.SubjectDistance,
		ExifTag.MeteringMode,
		ExifTag.LightSource,
		ExifTag.Flash,
		ExifTag.FocalLength,
		ExifTag.FlashEnergy2,
		ExifTag.SpatialFrequencyResponse2,
		ExifTag.Noise,
		ExifTag.FocalPlaneXResolution2,
		ExifTag.FocalPlaneYResolution2,
		ExifTag.FocalPlaneResolutionUnit2,
		ExifTag.ImageNumber,
		ExifTag.SecurityClassification,
		ExifTag.ImageHistory,
		ExifTag.SubjectArea,
		ExifTag.ExposureIndex2,
		ExifTag.TIFFEPStandardID,
		ExifTag.SensingMethod2,
		ExifTag.MakerNote,
		ExifTag.UserComment,
		ExifTag.SubsecTime,
		ExifTag.SubsecTimeOriginal,
		ExifTag.SubsecTimeDigitized,
		ExifTag.AmbientTemperature,
		ExifTag.Humidity,
		ExifTag.Pressure,
		ExifTag.WaterDepth,
		ExifTag.Acceleration,
		ExifTag.CameraElevationAngle,
		ExifTag.FlashpixVersion,
		ExifTag.ColorSpace,
		ExifTag.PixelXDimension,
		ExifTag.PixelYDimension,
		ExifTag.RelatedSoundFile,
		ExifTag.FlashEnergy,
		ExifTag.SpatialFrequencyResponse,
		ExifTag.FocalPlaneXResolution,
		ExifTag.FocalPlaneYResolution,
		ExifTag.FocalPlaneResolutionUnit,
		ExifTag.SubjectLocation,
		ExifTag.ExposureIndex,
		ExifTag.SensingMethod,
		ExifTag.FileSource,
		ExifTag.SceneType,
		ExifTag.CFAPattern,
		ExifTag.CustomRendered,
		ExifTag.ExposureMode,
		ExifTag.WhiteBalance,
		ExifTag.DigitalZoomRatio,
		ExifTag.FocalLengthIn35mmFilm,
		ExifTag.SceneCaptureType,
		ExifTag.GainControl,
		ExifTag.Contrast,
		ExifTag.Saturation,
		ExifTag.Sharpness,
		ExifTag.DeviceSettingDescription,
		ExifTag.SubjectDistanceRange,
		ExifTag.ImageUniqueID,
		ExifTag.OwnerName,
		ExifTag.SerialNumber,
		ExifTag.LensInfo,
		ExifTag.LensMake,
		ExifTag.LensModel,
		ExifTag.LensSerialNumber
	};

	private static readonly ExifTag[] _GPSTags = new ExifTag[31]
	{
		ExifTag.GPSVersionID,
		ExifTag.GPSLatitudeRef,
		ExifTag.GPSLatitude,
		ExifTag.GPSLongitudeRef,
		ExifTag.GPSLongitude,
		ExifTag.GPSAltitudeRef,
		ExifTag.GPSAltitude,
		ExifTag.GPSTimestamp,
		ExifTag.GPSSatellites,
		ExifTag.GPSStatus,
		ExifTag.GPSMeasureMode,
		ExifTag.GPSDOP,
		ExifTag.GPSSpeedRef,
		ExifTag.GPSSpeed,
		ExifTag.GPSTrackRef,
		ExifTag.GPSTrack,
		ExifTag.GPSImgDirectionRef,
		ExifTag.GPSImgDirection,
		ExifTag.GPSMapDatum,
		ExifTag.GPSDestLatitudeRef,
		ExifTag.GPSDestLatitude,
		ExifTag.GPSDestLongitudeRef,
		ExifTag.GPSDestLongitude,
		ExifTag.GPSDestBearingRef,
		ExifTag.GPSDestBearing,
		ExifTag.GPSDestDistanceRef,
		ExifTag.GPSDestDistance,
		ExifTag.GPSProcessingMethod,
		ExifTag.GPSAreaInformation,
		ExifTag.GPSDateStamp,
		ExifTag.GPSDifferential
	};

	private readonly ExifParts _allowedParts;

	private readonly Collection<ExifValue> _values;

	private readonly Collection<int> _ifdIndexes;

	private readonly Collection<int> _exifIndexes;

	private readonly Collection<int> _gPSIndexes;

	private Collection<int> _dataOffsets;

	public ExifWriter(Collection<ExifValue> values, ExifParts allowedParts)
	{
		_values = values;
		_allowedParts = allowedParts;
		_ifdIndexes = GetIndexes(ExifParts.IfdTags, _IfdTags);
		_exifIndexes = GetIndexes(ExifParts.ExifTags, _ExifTags);
		_gPSIndexes = GetIndexes(ExifParts.GPSTags, _GPSTags);
	}

	public byte[] GetData()
	{
		uint num = 0u;
		int index = -1;
		int index2 = -1;
		if (_exifIndexes.Count > 0)
		{
			index = GetIndex(_ifdIndexes, ExifTag.SubIFDOffset);
		}
		if (_gPSIndexes.Count > 0)
		{
			index2 = GetIndex(_ifdIndexes, ExifTag.GPSIFDOffset);
		}
		uint num2 = 2 + GetLength(_ifdIndexes) + 4;
		uint num3 = GetLength(_exifIndexes);
		uint num4 = GetLength(_gPSIndexes);
		if (num3 != 0)
		{
			num3 += 2;
		}
		if (num4 != 0)
		{
			num4 += 2;
		}
		num = num2 + num3 + num4;
		if (num == 6)
		{
			return null;
		}
		num += 16;
		byte[] array = new byte[num];
		array[0] = 69;
		array[1] = 120;
		array[2] = 105;
		array[3] = 102;
		array[4] = 0;
		array[5] = 0;
		array[6] = 73;
		array[7] = 73;
		array[8] = 42;
		array[9] = 0;
		int num5 = 10;
		uint num6 = (uint)(num5 - 6 + 4);
		uint value = num6 + num2 + num3 + num4;
		if (num3 != 0)
		{
			_values[index].Value = num6 + num2;
		}
		if (num4 != 0)
		{
			_values[index2].Value = num6 + num2 + num3;
		}
		num5 = Write(offset: WriteHeaders(offset: Write(BitConverter.GetBytes(num6), array, num5), indexes: _ifdIndexes, destination: array), source: BitConverter.GetBytes(value), destination: array);
		num5 = WriteData(_ifdIndexes, array, num5);
		if (num3 != 0)
		{
			num5 = WriteHeaders(_exifIndexes, array, num5);
			num5 = WriteData(_exifIndexes, array, num5);
		}
		if (num4 != 0)
		{
			num5 = WriteHeaders(_gPSIndexes, array, num5);
			num5 = WriteData(_gPSIndexes, array, num5);
		}
		Write(BitConverter.GetBytes((ushort)0), array, num5);
		return array;
	}

	private static int Write(byte[] source, byte[] destination, int offset)
	{
		Buffer.BlockCopy(source, 0, destination, offset, source.Length);
		return offset + source.Length;
	}

	private static int WriteArray(ExifValue value, byte[] destination, int offset)
	{
		if (value.DataType == ExifDataType.Ascii)
		{
			return WriteValue(ExifDataType.Ascii, value.Value, destination, offset);
		}
		int num = offset;
		foreach (object item in (Array)value.Value)
		{
			num = WriteValue(value.DataType, item, destination, num);
		}
		return num;
	}

	private static int WriteRational(Rational value, byte[] destination, int offset)
	{
		Write(BitConverter.GetBytes(value.Numerator), destination, offset);
		Write(BitConverter.GetBytes(value.Denominator), destination, offset + 4);
		return offset + 8;
	}

	private static int WriteSignedRational(SignedRational value, byte[] destination, int offset)
	{
		Write(BitConverter.GetBytes(value.Numerator), destination, offset);
		Write(BitConverter.GetBytes(value.Denominator), destination, offset + 4);
		return offset + 8;
	}

	private static int WriteValue(ExifDataType dataType, object value, byte[] destination, int offset)
	{
		switch (dataType)
		{
		case ExifDataType.Ascii:
			return Write(Encoding.UTF8.GetBytes((string)value), destination, offset);
		case ExifDataType.Byte:
		case ExifDataType.Undefined:
			destination[offset] = (byte)value;
			return offset + 1;
		case ExifDataType.DoubleFloat:
			return Write(BitConverter.GetBytes((double)value), destination, offset);
		case ExifDataType.Short:
			return Write(BitConverter.GetBytes((ushort)value), destination, offset);
		case ExifDataType.Long:
			return Write(BitConverter.GetBytes((uint)value), destination, offset);
		case ExifDataType.Rational:
			return WriteRational((Rational)value, destination, offset);
		case ExifDataType.SignedByte:
			destination[offset] = (byte)(sbyte)value;
			return offset + 1;
		case ExifDataType.SignedLong:
			return Write(BitConverter.GetBytes((int)value), destination, offset);
		case ExifDataType.SignedShort:
			return Write(BitConverter.GetBytes((short)value), destination, offset);
		case ExifDataType.SignedRational:
			return WriteSignedRational((SignedRational)value, destination, offset);
		case ExifDataType.SingleFloat:
			return Write(BitConverter.GetBytes((float)value), destination, offset);
		default:
			throw new NotSupportedException();
		}
	}

	private static int WriteValue(ExifValue value, byte[] destination, int offset)
	{
		if (value.IsArray && value.DataType != ExifDataType.Ascii)
		{
			return WriteArray(value, destination, offset);
		}
		return WriteValue(value.DataType, value.Value, destination, offset);
	}

	private int WriteData(Collection<int> indexes, byte[] destination, int offset)
	{
		if (_dataOffsets.Count == 0)
		{
			return offset;
		}
		int num = offset;
		int num2 = 0;
		foreach (int index in indexes)
		{
			ExifValue exifValue = _values[index];
			if (exifValue.Length > 4)
			{
				Write(BitConverter.GetBytes(num - 6), destination, _dataOffsets[num2++]);
				num = WriteValue(exifValue, destination, num);
			}
		}
		return num;
	}

	private int GetIndex(Collection<int> indexes, ExifTag tag)
	{
		foreach (int index in indexes)
		{
			if (_values[index].Tag == tag)
			{
				return index;
			}
		}
		int count = _values.Count;
		indexes.Add(count);
		_values.Add(ExifValue.Create(tag, null));
		return count;
	}

	private Collection<int> GetIndexes(ExifParts part, ExifTag[] tags)
	{
		if (!EnumHelper.HasFlag(_allowedParts, part))
		{
			return new Collection<int>();
		}
		Collection<int> collection = new Collection<int>();
		for (int i = 0; i < _values.Count; i++)
		{
			ExifValue exifValue = _values[i];
			if (exifValue.HasValue && Array.IndexOf(tags, exifValue.Tag) > -1)
			{
				collection.Add(i);
			}
		}
		return collection;
	}

	private uint GetLength(IEnumerable<int> indexes)
	{
		uint num = 0u;
		foreach (int index in indexes)
		{
			uint length = (uint)_values[index].Length;
			num = ((length <= 4) ? (num + 12) : (num + (12 + length)));
		}
		return num;
	}

	private int WriteHeaders(Collection<int> indexes, byte[] destination, int offset)
	{
		_dataOffsets = new Collection<int>();
		int num = Write(BitConverter.GetBytes((ushort)indexes.Count), destination, offset);
		if (indexes.Count == 0)
		{
			return num;
		}
		foreach (int index in indexes)
		{
			ExifValue exifValue = _values[index];
			num = Write(BitConverter.GetBytes((ushort)exifValue.Tag), destination, num);
			num = Write(BitConverter.GetBytes((ushort)exifValue.DataType), destination, num);
			num = Write(BitConverter.GetBytes((uint)exifValue.NumberOfComponents), destination, num);
			if (exifValue.Length > 4)
			{
				_dataOffsets.Add(num);
			}
			else
			{
				WriteValue(exifValue, destination, num);
			}
			num += 4;
		}
		return num;
	}
}
