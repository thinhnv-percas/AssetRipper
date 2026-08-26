using System.Collections.Generic;
using ImageMagick.Defines;

namespace ImageMagick;

public sealed class Jp2WriteDefines : WriteDefinesCreator
{
	public int? NumberResolutions { get; set; }

	public Jp2ProgressionOrder? ProgressionOrder { get; set; }

	public IEnumerable<float> Quality { get; set; }

	public IEnumerable<float> Rate { get; set; }

	public override IEnumerable<IDefine> Defines
	{
		get
		{
			if (NumberResolutions.HasValue)
			{
				yield return CreateDefine("number-resolutions", NumberResolutions.Value);
			}
			if (ProgressionOrder.HasValue)
			{
				yield return CreateDefine("progression-order", ProgressionOrder.Value);
			}
			MagickDefine magickDefine = CreateDefine("quality", Quality);
			if (magickDefine != null)
			{
				yield return magickDefine;
			}
			MagickDefine magickDefine2 = CreateDefine("rate", Rate);
			if (magickDefine2 != null)
			{
				yield return magickDefine2;
			}
		}
	}

	public Jp2WriteDefines()
		: base(MagickFormat.Jp2)
	{
	}
}
