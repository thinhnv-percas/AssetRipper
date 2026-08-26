using System.Runtime.CompilerServices;
using System.Text;

namespace SpirV
{
	public class ImageType : Type
	{
		[CompilerGenerated]
		private readonly Type _0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020;

		[CompilerGenerated]
		private readonly Dim _0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A;

		[CompilerGenerated]
		private readonly int _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_000A;

		[CompilerGenerated]
		private readonly bool _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020;

		[CompilerGenerated]
		private readonly bool _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A;

		[CompilerGenerated]
		private readonly int _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020;

		[CompilerGenerated]
		private readonly ImageFormat _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_000A;

		[CompilerGenerated]
		private readonly AccessQualifier _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020;

		public Type SampledType
		{
			get;
		}

		public Dim Dim
		{
			get;
		}

		public int Depth
		{
			get;
		}

		public bool IsArray
		{
			get;
		}

		public bool IsMultisampled
		{
			get;
		}

		public int SampleCount
		{
			get;
		}

		public ImageFormat Format
		{
			get;
		}

		public AccessQualifier AccessQualifier
		{
			get;
		}

		public ImageType(Type sampledType, Dim dim, int depth, bool isArray, bool isMultisampled, int sampleCount, ImageFormat imageFormat, AccessQualifier accessQualifier)
		{
			_0020_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020 = sampledType;
			_0020_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020_0020_0020_0020_000A = dim;
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_000A = depth;
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020 = isArray;
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A = isMultisampled;
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020 = sampleCount;
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_000A = imageFormat;
			_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020 = accessQualifier;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			ToString(stringBuilder);
			return stringBuilder.ToString();
		}

		public override StringBuilder ToString(StringBuilder sb)
		{
			switch (AccessQualifier)
			{
			case AccessQualifier.ReadWrite:
				sb.Append("read_write ");
				break;
			case AccessQualifier.WriteOnly:
				sb.Append("write_only ");
				break;
			case AccessQualifier.ReadOnly:
				sb.Append("read_only ");
				break;
			}
			sb.Append("Texture");
			switch (Dim)
			{
			case Dim.Dim1D:
				sb.Append("1D");
				break;
			case Dim.Dim2D:
				sb.Append("2D");
				break;
			case Dim.Dim3D:
				sb.Append("3D");
				break;
			case Dim.Cube:
				sb.Append("Cube");
				break;
			}
			if (IsMultisampled)
			{
				sb.Append("MS");
			}
			if (IsArray)
			{
				sb.Append("Array");
			}
			return sb;
		}
	}
}
