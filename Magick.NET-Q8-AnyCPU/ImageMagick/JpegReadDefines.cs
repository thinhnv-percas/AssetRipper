using System.Collections.Generic;
using ImageMagick.Defines;

namespace ImageMagick;

public sealed class JpegReadDefines : ReadDefinesCreator
{
	public bool? BlockSmoothing { get; set; }

	public int? Colors { get; set; }

	public DctMethod? DctMethod { get; set; }

	public bool? FancyUpsampling { get; set; }

	public MagickGeometry Size { get; set; }

	public ProfileTypes? SkipProfiles { get; set; }

	public override IEnumerable<IDefine> Defines
	{
		get
		{
			if (BlockSmoothing.HasValue)
			{
				yield return CreateDefine("block-smoothing", BlockSmoothing.Value);
			}
			if (Colors.HasValue)
			{
				yield return CreateDefine("colors", Colors.Value);
			}
			if (DctMethod.HasValue)
			{
				yield return CreateDefine("dct-method", DctMethod.Value);
			}
			if (FancyUpsampling.HasValue)
			{
				yield return CreateDefine("fancy-upsampling", FancyUpsampling.Value);
			}
			if (Size != null)
			{
				yield return CreateDefine("size", Size);
			}
			if (SkipProfiles.HasValue)
			{
				string value = EnumHelper.ConvertFlags(SkipProfiles.Value);
				if (!string.IsNullOrEmpty(value))
				{
					yield return new MagickDefine("profile:skip", value);
				}
			}
		}
	}

	public JpegReadDefines()
		: base(MagickFormat.Jpeg)
	{
	}
}
