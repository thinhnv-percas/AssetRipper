using System;
using System.Globalization;
using System.Text;

namespace ImageMagick;

public sealed class ExifValue : IEquatable<ExifValue>
{
	private object _value;

	public ExifDataType DataType { get; private set; }

	public bool IsArray { get; private set; }

	public ExifTag Tag { get; private set; }

	public object Value
	{
		get
		{
			return _value;
		}
		set
		{
			CheckValue(value);
			_value = value;
		}
	}

	internal bool HasValue
	{
		get
		{
			if (_value == null)
			{
				return false;
			}
			if (DataType == ExifDataType.Ascii)
			{
				return ((string)_value).Length > 0;
			}
			return true;
		}
	}

	internal int Length
	{
		get
		{
			if (_value == null)
			{
				return 4;
			}
			int num = (int)(GetSize(DataType) * NumberOfComponents);
			if (num >= 4)
			{
				return num;
			}
			return 4;
		}
	}

	internal int NumberOfComponents
	{
		get
		{
			if (DataType == ExifDataType.Ascii)
			{
				return Encoding.UTF8.GetBytes((string)_value).Length;
			}
			if (IsArray)
			{
				return ((Array)_value).Length;
			}
			return 1;
		}
	}

	internal ExifValue(ExifTag tag, ExifDataType dataType, bool isArray)
	{
		Tag = tag;
		DataType = dataType;
		IsArray = isArray;
		if (dataType == ExifDataType.Ascii)
		{
			IsArray = false;
		}
	}

	internal ExifValue(ExifTag tag, ExifDataType dataType, object value, bool isArray)
		: this(tag, dataType, isArray)
	{
		_value = value;
	}

	public static bool operator ==(ExifValue left, ExifValue right)
	{
		return object.Equals(left, right);
	}

	public static bool operator !=(ExifValue left, ExifValue right)
	{
		return !object.Equals(left, right);
	}

	public override bool Equals(object obj)
	{
		if (this == obj)
		{
			return true;
		}
		return Equals(obj as ExifValue);
	}

	public bool Equals(ExifValue other)
	{
		if ((object)other == null)
		{
			return false;
		}
		if ((object)this == other)
		{
			return true;
		}
		if (Tag == other.Tag && DataType == other.DataType)
		{
			return object.Equals(_value, other._value);
		}
		return false;
	}

	public override int GetHashCode()
	{
		int num = Tag.GetHashCode() ^ DataType.GetHashCode();
		if (_value == null)
		{
			return num;
		}
		return num ^ _value.GetHashCode();
	}

	public override string ToString()
	{
		if (_value == null)
		{
			return null;
		}
		if (DataType == ExifDataType.Ascii)
		{
			return (string)_value;
		}
		if (!IsArray)
		{
			return ToString(_value);
		}
		StringBuilder stringBuilder = new StringBuilder();
		foreach (object item in (Array)_value)
		{
			stringBuilder.Append(ToString(item));
			stringBuilder.Append(" ");
		}
		return stringBuilder.ToString();
	}

	internal static ExifValue Create(ExifTag tag, object value)
	{
		Throw.IfTrue("tag", tag == ExifTag.Unknown, "Invalid Tag");
		ExifValue exifValue = null;
		Type type = value?.GetType();
		if (type != null && type.IsArray)
		{
			type = type.GetElementType();
		}
		switch (tag)
		{
		case ExifTag.GPSLatitudeRef:
		case ExifTag.GPSLongitudeRef:
		case ExifTag.GPSSatellites:
		case ExifTag.GPSStatus:
		case ExifTag.GPSMeasureMode:
		case ExifTag.GPSSpeedRef:
		case ExifTag.GPSTrackRef:
		case ExifTag.GPSImgDirectionRef:
		case ExifTag.GPSMapDatum:
		case ExifTag.GPSDestLatitudeRef:
		case ExifTag.GPSDestLongitudeRef:
		case ExifTag.GPSDestBearingRef:
		case ExifTag.GPSDestDistanceRef:
		case ExifTag.GPSDateStamp:
		case ExifTag.DocumentName:
		case ExifTag.ImageDescription:
		case ExifTag.Make:
		case ExifTag.Model:
		case ExifTag.PageName:
		case ExifTag.Software:
		case ExifTag.DateTime:
		case ExifTag.Artist:
		case ExifTag.HostComputer:
		case ExifTag.InkNames:
		case ExifTag.TargetPrinter:
		case ExifTag.ImageID:
		case ExifTag.Copyright:
		case ExifTag.MDLabName:
		case ExifTag.MDSampleInfo:
		case ExifTag.MDPrepDate:
		case ExifTag.MDPrepTime:
		case ExifTag.MDFileUnits:
		case ExifTag.SEMInfo:
		case ExifTag.SpectralSensitivity:
		case ExifTag.FaxSubaddress:
		case ExifTag.DateTimeOriginal:
		case ExifTag.DateTimeDigitized:
		case ExifTag.OffsetTime:
		case ExifTag.OffsetTimeOriginal:
		case ExifTag.OffsetTimeDigitized:
		case ExifTag.SecurityClassification:
		case ExifTag.ImageHistory:
		case ExifTag.SubsecTime:
		case ExifTag.SubsecTimeOriginal:
		case ExifTag.SubsecTimeDigitized:
		case ExifTag.RelatedSoundFile:
		case ExifTag.ImageUniqueID:
		case ExifTag.OwnerName:
		case ExifTag.SerialNumber:
		case ExifTag.LensMake:
		case ExifTag.LensModel:
		case ExifTag.LensSerialNumber:
		case ExifTag.GDALMetadata:
		case ExifTag.GDALNoData:
			exifValue = new ExifValue(tag, ExifDataType.Ascii, isArray: true);
			break;
		case ExifTag.GPSVersionID:
		case ExifTag.ClipPath:
		case ExifTag.VersionYear:
		case ExifTag.XMP:
		case ExifTag.CFAPattern2:
		case ExifTag.TIFFEPStandardID:
		case ExifTag.XPTitle:
		case ExifTag.XPComment:
		case ExifTag.XPAuthor:
		case ExifTag.XPKeywords:
		case ExifTag.XPSubject:
			exifValue = new ExifValue(tag, ExifDataType.Byte, isArray: true);
			break;
		case ExifTag.GPSAltitudeRef:
		case ExifTag.FaxProfile:
		case ExifTag.ModeNumber:
			exifValue = new ExifValue(tag, ExifDataType.Byte, isArray: false);
			break;
		case ExifTag.FreeOffsets:
		case ExifTag.FreeByteCounts:
		case ExifTag.ColorResponseUnit:
		case ExifTag.TileOffsets:
		case ExifTag.SMinSampleValue:
		case ExifTag.SMaxSampleValue:
		case ExifTag.JPEGQTables:
		case ExifTag.JPEGDCTables:
		case ExifTag.JPEGACTables:
		case ExifTag.StripRowCounts:
		case ExifTag.IntergraphRegisters:
		case ExifTag.TimeZoneOffset:
			exifValue = new ExifValue(tag, ExifDataType.Long, isArray: true);
			break;
		case ExifTag.SubfileType:
		case ExifTag.T4Options:
		case ExifTag.T6Options:
		case ExifTag.XClipPathUnits:
		case ExifTag.YClipPathUnits:
		case ExifTag.ProfileType:
		case ExifTag.CodingMethods:
		case ExifTag.T82ptions:
		case ExifTag.JPEGInterchangeFormat:
		case ExifTag.JPEGInterchangeFormatLength:
		case ExifTag.MDFileTag:
		case ExifTag.SubIFDOffset:
		case ExifTag.GPSIFDOffset:
		case ExifTag.StandardOutputSensitivity:
		case ExifTag.RecommendedExposureIndex:
		case ExifTag.ISOSpeed:
		case ExifTag.ISOSpeedLatitudeyyy:
		case ExifTag.ISOSpeedLatitudezzz:
		case ExifTag.FaxRecvParams:
		case ExifTag.FaxRecvTime:
		case ExifTag.ImageNumber:
			exifValue = new ExifValue(tag, ExifDataType.Long, isArray: false);
			break;
		case ExifTag.GPSLatitude:
		case ExifTag.GPSLongitude:
		case ExifTag.GPSTimestamp:
		case ExifTag.GPSDestLatitude:
		case ExifTag.GPSDestLongitude:
		case ExifTag.WhitePoint:
		case ExifTag.PrimaryChromaticities:
		case ExifTag.YCbCrCoefficients:
		case ExifTag.ReferenceBlackWhite:
		case ExifTag.PixelScale:
		case ExifTag.IntergraphMatrix:
		case ExifTag.ModelTiePoint:
		case ExifTag.ModelTransform:
			exifValue = new ExifValue(tag, ExifDataType.Rational, isArray: true);
			break;
		case ExifTag.GPSAltitude:
		case ExifTag.GPSDOP:
		case ExifTag.GPSSpeed:
		case ExifTag.GPSTrack:
		case ExifTag.GPSImgDirection:
		case ExifTag.GPSDestBearing:
		case ExifTag.GPSDestDistance:
		case ExifTag.XResolution:
		case ExifTag.YResolution:
		case ExifTag.XPosition:
		case ExifTag.YPosition:
		case ExifTag.BatteryLevel:
		case ExifTag.ExposureTime:
		case ExifTag.FNumber:
		case ExifTag.MDScalePixel:
		case ExifTag.CompressedBitsPerPixel:
		case ExifTag.ApertureValue:
		case ExifTag.MaxApertureValue:
		case ExifTag.SubjectDistance:
		case ExifTag.FocalLength:
		case ExifTag.FlashEnergy2:
		case ExifTag.FocalPlaneXResolution2:
		case ExifTag.FocalPlaneYResolution2:
		case ExifTag.ExposureIndex2:
		case ExifTag.Humidity:
		case ExifTag.Pressure:
		case ExifTag.Acceleration:
		case ExifTag.FlashEnergy:
		case ExifTag.FocalPlaneXResolution:
		case ExifTag.FocalPlaneYResolution:
		case ExifTag.ExposureIndex:
		case ExifTag.DigitalZoomRatio:
		case ExifTag.LensInfo:
			exifValue = new ExifValue(tag, ExifDataType.Rational, isArray: false);
			break;
		case ExifTag.BitsPerSample:
		case ExifTag.MinSampleValue:
		case ExifTag.MaxSampleValue:
		case ExifTag.GrayResponseCurve:
		case ExifTag.PageNumber:
		case ExifTag.TransferFunction:
		case ExifTag.Predictor:
		case ExifTag.ColorMap:
		case ExifTag.HalftoneHints:
		case ExifTag.ExtraSamples:
		case ExifTag.SampleFormat:
		case ExifTag.TransferRange:
		case ExifTag.DefaultImageColor:
		case ExifTag.JPEGLosslessPredictors:
		case ExifTag.JPEGPointTransforms:
		case ExifTag.YCbCrSubsampling:
		case ExifTag.CFARepeatPatternDim:
		case ExifTag.IntergraphPacketData:
		case ExifTag.ISOSpeedRatings:
		case ExifTag.SubjectArea:
		case ExifTag.SubjectLocation:
			exifValue = new ExifValue(tag, ExifDataType.Short, isArray: true);
			break;
		case ExifTag.GPSDifferential:
		case ExifTag.OldSubfileType:
		case ExifTag.Compression:
		case ExifTag.PhotometricInterpretation:
		case ExifTag.Thresholding:
		case ExifTag.CellWidth:
		case ExifTag.CellLength:
		case ExifTag.FillOrder:
		case ExifTag.Orientation:
		case ExifTag.SamplesPerPixel:
		case ExifTag.PlanarConfiguration:
		case ExifTag.GrayResponseUnit:
		case ExifTag.ResolutionUnit:
		case ExifTag.CleanFaxData:
		case ExifTag.InkSet:
		case ExifTag.NumberOfInks:
		case ExifTag.DotRange:
		case ExifTag.Indexed:
		case ExifTag.OPIProxy:
		case ExifTag.JPEGProc:
		case ExifTag.JPEGRestartInterval:
		case ExifTag.YCbCrPositioning:
		case ExifTag.Rating:
		case ExifTag.RatingPercent:
		case ExifTag.ExposureProgram:
		case ExifTag.Interlace:
		case ExifTag.SelfTimerMode:
		case ExifTag.SensitivityType:
		case ExifTag.MeteringMode:
		case ExifTag.LightSource:
		case ExifTag.Flash:
		case ExifTag.FocalPlaneResolutionUnit2:
		case ExifTag.SensingMethod2:
		case ExifTag.ColorSpace:
		case ExifTag.FocalPlaneResolutionUnit:
		case ExifTag.SensingMethod:
		case ExifTag.CustomRendered:
		case ExifTag.ExposureMode:
		case ExifTag.WhiteBalance:
		case ExifTag.FocalLengthIn35mmFilm:
		case ExifTag.SceneCaptureType:
		case ExifTag.GainControl:
		case ExifTag.Contrast:
		case ExifTag.Saturation:
		case ExifTag.Sharpness:
		case ExifTag.SubjectDistanceRange:
			exifValue = new ExifValue(tag, ExifDataType.Short, isArray: false);
			break;
		case ExifTag.Decode:
			exifValue = new ExifValue(tag, ExifDataType.SignedRational, isArray: true);
			break;
		case ExifTag.ShutterSpeedValue:
		case ExifTag.BrightnessValue:
		case ExifTag.ExposureBiasValue:
		case ExifTag.AmbientTemperature:
		case ExifTag.WaterDepth:
		case ExifTag.CameraElevationAngle:
			exifValue = new ExifValue(tag, ExifDataType.SignedRational, isArray: false);
			break;
		case ExifTag.GPSProcessingMethod:
		case ExifTag.GPSAreaInformation:
		case ExifTag.JPEGTables:
		case ExifTag.OECF:
		case ExifTag.ExifVersion:
		case ExifTag.ComponentsConfiguration:
		case ExifTag.SpatialFrequencyResponse2:
		case ExifTag.Noise:
		case ExifTag.MakerNote:
		case ExifTag.UserComment:
		case ExifTag.ImageSourceData:
		case ExifTag.FlashpixVersion:
		case ExifTag.SpatialFrequencyResponse:
		case ExifTag.CFAPattern:
		case ExifTag.DeviceSettingDescription:
			exifValue = new ExifValue(tag, ExifDataType.Undefined, isArray: true);
			break;
		case ExifTag.FileSource:
		case ExifTag.SceneType:
			exifValue = new ExifValue(tag, ExifDataType.Undefined, isArray: false);
			break;
		case ExifTag.StripOffsets:
		case ExifTag.TileByteCounts:
		case ExifTag.ImageLayer:
			exifValue = CreateNumber(tag, type, isArray: true);
			break;
		case ExifTag.ImageWidth:
		case ExifTag.ImageLength:
		case ExifTag.TileWidth:
		case ExifTag.TileLength:
		case ExifTag.BadFaxLines:
		case ExifTag.ConsecutiveBadFaxLines:
		case ExifTag.PixelXDimension:
		case ExifTag.PixelYDimension:
			exifValue = CreateNumber(tag, type, isArray: false);
			break;
		default:
			throw new NotSupportedException();
		}
		exifValue.Value = value;
		return exifValue;
	}

	internal static uint GetSize(ExifDataType dataType)
	{
		switch (dataType)
		{
		case ExifDataType.Byte:
		case ExifDataType.Ascii:
		case ExifDataType.SignedByte:
		case ExifDataType.Undefined:
			return 1u;
		case ExifDataType.Short:
		case ExifDataType.SignedShort:
			return 2u;
		case ExifDataType.Long:
		case ExifDataType.SignedLong:
		case ExifDataType.SingleFloat:
			return 4u;
		case ExifDataType.Rational:
		case ExifDataType.SignedRational:
		case ExifDataType.DoubleFloat:
			return 8u;
		default:
			throw new NotSupportedException(dataType.ToString());
		}
	}

	private static ExifValue CreateNumber(ExifTag tag, Type type, bool isArray)
	{
		if (type == null || type == typeof(ushort))
		{
			return new ExifValue(tag, ExifDataType.Short, isArray);
		}
		if (type == typeof(short))
		{
			return new ExifValue(tag, ExifDataType.SignedShort, isArray);
		}
		if (type == typeof(uint))
		{
			return new ExifValue(tag, ExifDataType.Long, isArray);
		}
		return new ExifValue(tag, ExifDataType.SignedLong, isArray);
	}

	private void CheckValue(object value)
	{
		if (value == null)
		{
			return;
		}
		Type type = value.GetType();
		if (DataType == ExifDataType.Ascii)
		{
			Throw.IfFalse("value", type == typeof(string), "Value should be a string.");
			return;
		}
		if (type.IsArray)
		{
			Throw.IfTrue("value", !IsArray, "Value should not be an array.");
			type = type.GetElementType();
		}
		else
		{
			Throw.IfTrue("value", IsArray, "Value should be an array.");
		}
		switch (DataType)
		{
		case ExifDataType.Byte:
			Throw.IfFalse("value", type == typeof(byte), "Value should be a byte{0}", IsArray ? " array." : ".");
			break;
		case ExifDataType.DoubleFloat:
			Throw.IfFalse("value", type == typeof(double), "Value should be a double{0}", IsArray ? " array." : ".");
			break;
		case ExifDataType.Long:
			Throw.IfFalse("value", type == typeof(uint), "Value should be an unsigned int{0}", IsArray ? " array." : ".");
			break;
		case ExifDataType.Rational:
			Throw.IfFalse("value", type == typeof(Rational), "Value should be a rational{0}", IsArray ? " array." : ".");
			break;
		case ExifDataType.Short:
			Throw.IfFalse("value", type == typeof(ushort), "Value should be an unsigned short{0}", IsArray ? " array." : ".");
			break;
		case ExifDataType.SignedByte:
			Throw.IfFalse("value", type == typeof(sbyte), "Value should be a signed byte{0}", IsArray ? " array." : ".");
			break;
		case ExifDataType.SignedLong:
			Throw.IfFalse("value", type == typeof(int), "Value should be an int{0}", IsArray ? " array." : ".");
			break;
		case ExifDataType.SignedRational:
			Throw.IfFalse("value", type == typeof(SignedRational), "Value should be a signed rational{0}", IsArray ? " array." : ".");
			break;
		case ExifDataType.SignedShort:
			Throw.IfFalse("value", type == typeof(short), "Value should be a short{0}", IsArray ? " array." : ".");
			break;
		case ExifDataType.SingleFloat:
			Throw.IfFalse("value", type == typeof(float), "Value should be a float{0}", IsArray ? " array." : ".");
			break;
		case ExifDataType.Undefined:
			Throw.IfFalse("value", type == typeof(byte), "Value should be a byte array.");
			break;
		default:
			throw new NotSupportedException();
		}
	}

	private string ToString(object value)
	{
		string description = ExifTagDescriptionAttribute.GetDescription(Tag, value);
		if (description != null)
		{
			return description;
		}
		return DataType switch
		{
			ExifDataType.Ascii => (string)value, 
			ExifDataType.Byte => ((byte)value).ToString("X2", CultureInfo.InvariantCulture), 
			ExifDataType.DoubleFloat => ((double)value).ToString(CultureInfo.InvariantCulture), 
			ExifDataType.Long => ((uint)value).ToString(CultureInfo.InvariantCulture), 
			ExifDataType.Rational => ((Rational)value).ToString(CultureInfo.InvariantCulture), 
			ExifDataType.Short => ((ushort)value).ToString(CultureInfo.InvariantCulture), 
			ExifDataType.SignedByte => ((sbyte)value).ToString("X2", CultureInfo.InvariantCulture), 
			ExifDataType.SignedLong => ((int)value).ToString(CultureInfo.InvariantCulture), 
			ExifDataType.SignedRational => ((SignedRational)value).ToString(CultureInfo.InvariantCulture), 
			ExifDataType.SignedShort => ((short)value).ToString(CultureInfo.InvariantCulture), 
			ExifDataType.SingleFloat => ((float)value).ToString(CultureInfo.InvariantCulture), 
			ExifDataType.Undefined => ((byte)value).ToString("X2", CultureInfo.InvariantCulture), 
			_ => throw new NotSupportedException(), 
		};
	}
}
