using System.Collections.Generic;
using ImageMagick.Defines;

namespace ImageMagick;

public sealed class JpegWriteDefines : WriteDefinesCreator
{
	public DctMethod? DctMethod { get; set; }

	public int? Extent { get; set; }

	public bool? OptimizeCoding { get; set; }

	public MagickGeometry Quality { get; set; }

	public string QuantizationTables { get; set; }

	public IEnumerable<MagickGeometry> SamplingFactors { get; set; }

	public override IEnumerable<IDefine> Defines
	{
		get
		{
			if (DctMethod.HasValue)
			{
				yield return CreateDefine("dct-method", DctMethod.Value);
			}
			if (Extent.HasValue)
			{
				yield return CreateDefine("extent", Extent.Value + "KB");
			}
			if (OptimizeCoding.HasValue)
			{
				yield return CreateDefine("optimize-coding", OptimizeCoding.Value);
			}
			if (Quality != null)
			{
				yield return CreateDefine("quality", Quality);
			}
			if (!string.IsNullOrEmpty(QuantizationTables))
			{
				yield return CreateDefine("q-table", QuantizationTables);
			}
			if (SamplingFactors == null)
			{
				yield break;
			}
			string text = string.Empty;
			foreach (MagickGeometry samplingFactor in SamplingFactors)
			{
				if (text.Length != 0)
				{
					text += ",";
				}
				text += samplingFactor.ToString();
			}
			if (!string.IsNullOrEmpty(text))
			{
				yield return CreateDefine("sampling-factor", text);
			}
		}
	}

	public JpegWriteDefines()
		: base(MagickFormat.Jpeg)
	{
	}
}
