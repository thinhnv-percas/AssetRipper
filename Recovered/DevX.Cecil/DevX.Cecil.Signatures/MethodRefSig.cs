namespace DevX.Cecil.Signatures
{
	internal class MethodRefSig : MethodSig
	{
		public int Sentinel;

		public MethodRefSig()
			: this(0u)
		{
		}

		public MethodRefSig(uint blobIndex)
			: base(blobIndex)
		{
			Sentinel = -1;
		}

		public override void Accept(ISignatureVisitor visitor)
		{
			visitor.VisitMethodRefSig(this);
		}
	}
}
