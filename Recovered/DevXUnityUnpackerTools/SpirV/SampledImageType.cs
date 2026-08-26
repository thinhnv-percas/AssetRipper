using System.Runtime.CompilerServices;
using System.Text;

namespace SpirV
{
	public class SampledImageType : Type
	{
		[CompilerGenerated]
		internal readonly ImageType _0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A;

		public ImageType ImageType
		{
			get;
		}

		public SampledImageType(ImageType imageType)
		{
			_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A = imageType;
		}

		public override string ToString()
		{
			return $"{ImageType}Sampled";
		}

		public override StringBuilder ToString(StringBuilder sb)
		{
			return ImageType.ToString(sb).Append("Sampled");
		}
	}
}
