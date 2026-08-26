using System.Collections.Generic;
using ImageMagick.Defines;

namespace ImageMagick;

public sealed class TiffWriteDefines : WriteDefinesCreator
{
	public TiffAlpha? Alpha { get; set; }

	public Endian? Endian { get; set; }

	public Endian? FillOrder { get; set; }

	public int? RowsPerStrip { get; set; }

	public MagickGeometry TileGeometry { get; set; }

	public override IEnumerable<IDefine> Defines
	{
		get
		{
			if (Alpha.HasValue)
			{
				yield return CreateDefine("alpha", Alpha.Value);
			}
			if (Endian.HasValue && Endian.Value != ImageMagick.Endian.Undefined)
			{
				yield return CreateDefine("endian", Endian.Value);
			}
			if (FillOrder.HasValue && FillOrder.Value != ImageMagick.Endian.Undefined)
			{
				yield return CreateDefine("fill-order", FillOrder.Value);
			}
			if (RowsPerStrip.HasValue)
			{
				yield return CreateDefine("rows-per-strip", RowsPerStrip.Value);
			}
			if (TileGeometry != null)
			{
				yield return CreateDefine("tile-geometry", TileGeometry);
			}
		}
	}

	public TiffWriteDefines()
		: base(MagickFormat.Tiff)
	{
	}
}
