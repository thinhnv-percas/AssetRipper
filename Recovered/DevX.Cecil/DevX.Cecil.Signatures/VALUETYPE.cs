using DevX.Cecil.Metadata;

namespace DevX.Cecil.Signatures
{
	internal sealed class VALUETYPE : SigType
	{
		public MetadataToken Type;

		public VALUETYPE()
			: base(ElementType.ValueType)
		{
		}
	}
}
