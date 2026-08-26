namespace DevX.Cecil.Signatures
{
	internal sealed class MethodDefSig : MethodRefSig
	{
		public int GenericParameterCount;

		public MethodDefSig()
			: this(0u)
		{
		}

		public MethodDefSig(uint blobIndex)
			: base(blobIndex)
		{
		}

		public override void Accept(ISignatureVisitor visitor)
		{
			visitor.VisitMethodDefSig(this);
		}
	}
}
