using System.Collections.Generic;
using ImageMagick.Defines;

namespace ImageMagick;

public sealed class PsdWriteDefines : WriteDefinesCreator
{
	public PsdAdditionalInfo AdditionalInfo { get; set; }

	public override IEnumerable<IDefine> Defines
	{
		get
		{
			yield return CreateDefine("additional-info", AdditionalInfo);
		}
	}

	public PsdWriteDefines()
		: base(MagickFormat.Psd)
	{
	}
}
