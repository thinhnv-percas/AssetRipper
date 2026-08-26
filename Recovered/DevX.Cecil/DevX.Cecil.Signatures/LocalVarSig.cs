namespace DevX.Cecil.Signatures
{
	internal sealed class LocalVarSig : Signature
	{
		public struct LocalVariable
		{
			public CustomMod[] CustomMods;

			public Constraint Constraint;

			public bool ByRef;

			public SigType Type;
		}

		public bool Local;

		public int Count;

		public LocalVariable[] LocalVariables;

		public LocalVarSig()
		{
		}

		public LocalVarSig(uint blobIndex)
			: base(blobIndex)
		{
		}

		public override void Accept(ISignatureVisitor visitor)
		{
			visitor.VisitLocalVarSig(this);
		}
	}
}
