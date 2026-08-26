using System.Collections.Generic;
using ImageMagick.Defines;

namespace ImageMagick;

public sealed class BmpWriteDefines : WriteDefinesCreator
{
	public BmpSubtype? Subtype { get; set; }

	public override IEnumerable<IDefine> Defines
	{
		get
		{
			if (Subtype.HasValue)
			{
				yield return CreateDefine("subtype", Subtype.Value);
			}
		}
	}

	public BmpWriteDefines()
		: base(MagickFormat.Bmp)
	{
	}
}
