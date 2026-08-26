using System.Collections.Generic;
using ImageMagick.Defines;

namespace ImageMagick;

public sealed class Jp2ReadDefines : ReadDefinesCreator
{
	public int? QualityLayers { get; set; }

	public int? ReduceFactor { get; set; }

	public override IEnumerable<IDefine> Defines
	{
		get
		{
			if (QualityLayers.HasValue)
			{
				yield return CreateDefine("quality-layers", QualityLayers.Value);
			}
			if (ReduceFactor.HasValue)
			{
				yield return CreateDefine("reduce-factor", ReduceFactor.Value);
			}
		}
	}

	public Jp2ReadDefines()
		: base(MagickFormat.Jp2)
	{
	}
}
