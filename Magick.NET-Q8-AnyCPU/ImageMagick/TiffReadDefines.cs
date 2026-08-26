using System.Collections.Generic;
using ImageMagick.Defines;

namespace ImageMagick;

public sealed class TiffReadDefines : ReadDefinesCreator
{
	public bool? IgnoreExifPoperties { get; set; }

	public IEnumerable<string> IgnoreTags { get; set; }

	public override IEnumerable<IDefine> Defines
	{
		get
		{
			if (IgnoreExifPoperties.Equals(true))
			{
				yield return CreateDefine("exif-properties", value: false);
			}
			MagickDefine magickDefine = CreateDefine("ignore-tags", IgnoreTags);
			if (magickDefine != null)
			{
				yield return magickDefine;
			}
		}
	}

	public TiffReadDefines()
		: base(MagickFormat.Tiff)
	{
	}
}
