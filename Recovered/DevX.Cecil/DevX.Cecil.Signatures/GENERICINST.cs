using DevX.Cecil.Metadata;

namespace DevX.Cecil.Signatures
{
	internal sealed class GENERICINST : SigType
	{
		public bool ValueType;

		public MetadataToken Type;

		public GenericInstSignature Signature;

		public GENERICINST()
			: base(ElementType.GenericInst)
		{
		}
	}
}
