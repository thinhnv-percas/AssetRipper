using System.Collections.Generic;
using ImageMagick.Defines;

namespace ImageMagick;

public sealed class DdsWriteDefines : WriteDefinesCreator
{
	public bool? ClusterFit { get; set; }

	public DdsCompression? Compression { get; set; }

	public bool? FastMipmaps { get; set; }

	public int? Mipmaps { get; set; }

	public bool? MipmapsFromCollection { get; set; }

	public bool? WeightByAlpha { get; set; }

	public override IEnumerable<IDefine> Defines
	{
		get
		{
			if (ClusterFit.HasValue)
			{
				yield return CreateDefine("cluster-fit", ClusterFit.Value);
			}
			if (Compression.HasValue)
			{
				yield return CreateDefine("compression", Compression.Value);
			}
			if (FastMipmaps.HasValue)
			{
				yield return CreateDefine("fast-mipmaps", FastMipmaps.Value);
			}
			if (MipmapsFromCollection == true)
			{
				yield return CreateDefine("mipmaps", "fromlist");
			}
			else if (Mipmaps.HasValue)
			{
				yield return CreateDefine("mipmaps", Mipmaps.Value);
			}
			if (WeightByAlpha.HasValue)
			{
				yield return CreateDefine("weight-by-alpha", WeightByAlpha.Value);
			}
		}
	}

	public DdsWriteDefines()
		: base(MagickFormat.Dds)
	{
	}
}
