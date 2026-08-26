using System.Collections.Generic;
using ImageMagick.Defines;

namespace ImageMagick;

public sealed class PsdReadDefines : ReadDefinesCreator
{
	public bool? AlphaUnblend { get; set; }

	public override IEnumerable<IDefine> Defines
	{
		get
		{
			if (AlphaUnblend.Equals(false))
			{
				yield return CreateDefine("alpha-unblend", value: false);
			}
		}
	}

	public PsdReadDefines()
		: base(MagickFormat.Psd)
	{
	}
}
