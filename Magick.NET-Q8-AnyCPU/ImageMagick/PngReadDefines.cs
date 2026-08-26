using System.Collections.Generic;
using ImageMagick.Defines;

namespace ImageMagick;

public sealed class PngReadDefines : ReadDefinesCreator
{
	public bool PreserveiCCP { get; set; }

	public ProfileTypes? SkipProfiles { get; set; }

	public bool SwapBytes { get; set; }

	public override IEnumerable<IDefine> Defines
	{
		get
		{
			if (PreserveiCCP)
			{
				yield return CreateDefine("preserve-iCCP", PreserveiCCP);
			}
			if (SkipProfiles.HasValue)
			{
				string value = EnumHelper.ConvertFlags(SkipProfiles.Value);
				if (!string.IsNullOrEmpty(value))
				{
					yield return new MagickDefine("profile:skip", value);
				}
			}
			if (SwapBytes)
			{
				yield return CreateDefine("swap-bytes", SwapBytes);
			}
		}
	}

	public PngReadDefines()
		: base(MagickFormat.Png)
	{
	}
}
