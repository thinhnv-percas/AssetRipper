using System.Collections.Generic;
using ImageMagick.Defines;

namespace ImageMagick;

public sealed class PdfReadDefines : ReadDefinesCreator
{
	public MagickGeometry FitPage { get; set; }

	public bool? UseCropBox { get; set; }

	public bool? UseTrimBox { get; set; }

	public override IEnumerable<IDefine> Defines
	{
		get
		{
			if (FitPage != null)
			{
				yield return CreateDefine("fit-page", FitPage);
			}
			if (UseCropBox.HasValue)
			{
				yield return CreateDefine("use-cropbox", UseCropBox.Value);
			}
			if (UseTrimBox.HasValue)
			{
				yield return CreateDefine("use-trimbox", UseTrimBox.Value);
			}
		}
	}

	public PdfReadDefines()
		: base(MagickFormat.Pdf)
	{
	}
}
