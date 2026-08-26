using DevX.Cecil.Metadata;

namespace DevX.Cecil.Signatures
{
	internal sealed class CLASS : SigType
	{
		public MetadataToken Type;

		public CLASS()
			: base(ElementType.Class)
		{
		}
	}
}
