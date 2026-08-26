using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ImageMagick;

public sealed class ColorProfile : ImageProfile
{
	private static readonly object _SyncRoot = new object();

	private static readonly Dictionary<string, ColorProfile> _profiles = new Dictionary<string, ColorProfile>();

	public static ColorProfile AdobeRGB1998 => Load("ImageMagick.Resources.ColorProfiles.RGB", "AdobeRGB1998.icc");

	public static ColorProfile AppleRGB => Load("ImageMagick.Resources.ColorProfiles.RGB", "AppleRGB.icc");

	public static ColorProfile CoatedFOGRA39 => Load("ImageMagick.Resources.ColorProfiles.CMYK", "CoatedFOGRA39.icc");

	public static ColorProfile ColorMatchRGB => Load("ImageMagick.Resources.ColorProfiles.RGB", "ColorMatchRGB.icc");

	public static ColorProfile SRGB => Load("ImageMagick.Resources.ColorProfiles.RGB", "SRGB.icm");

	public static ColorProfile USWebCoatedSWOP => Load("ImageMagick.Resources.ColorProfiles.CMYK", "USWebCoatedSWOP.icc");

	public ColorSpace ColorSpace { get; private set; }

	public ColorProfile(byte[] data)
		: base("icc", data)
	{
		Initialize();
	}

	public ColorProfile(Stream stream)
		: base("icc", stream)
	{
		Initialize();
	}

	public ColorProfile(string fileName)
		: base("icc", fileName)
	{
	}

	internal ColorProfile(string name, byte[] data)
		: base(name, data)
	{
		Initialize();
	}

	private static ColorProfile Load(string resourcePath, string resourceName)
	{
		lock (_SyncRoot)
		{
			if (!_profiles.ContainsKey(resourceName))
			{
				using Stream stream = TypeHelper.GetManifestResourceStream(typeof(ColorProfile), resourcePath, resourceName);
				_profiles[resourceName] = new ColorProfile(stream);
			}
		}
		return _profiles[resourceName];
	}

	private static ColorSpace DetermineColorSpace(string colorSpace)
	{
		return colorSpace switch
		{
			"CMY" => ColorSpace.CMY, 
			"CMYK" => ColorSpace.CMYK, 
			"GRAY" => ColorSpace.Gray, 
			"HLS" => ColorSpace.HSL, 
			"HSV" => ColorSpace.HSV, 
			"Lab" => ColorSpace.Lab, 
			"Luv" => ColorSpace.YUV, 
			"RGB" => ColorSpace.sRGB, 
			"XYZ" => ColorSpace.XYZ, 
			"YCbr" => ColorSpace.YCbCr, 
			"Yxy" => ColorSpace.XyY, 
			_ => throw new NotSupportedException(colorSpace), 
		};
	}

	private void Initialize()
	{
		ColorSpace = ColorSpace.Undefined;
		if (base.Data.Length >= 20)
		{
			string colorSpace = Encoding.ASCII.GetString(base.Data, 16, 4).TrimEnd();
			ColorSpace = DetermineColorSpace(colorSpace);
		}
	}
}
