namespace DevX.Cecil.Signatures
{
	internal abstract class BaseSignatureVisitor : ISignatureVisitor
	{
		public virtual void VisitMethodDefSig(MethodDefSig methodDef)
		{
		}

		public virtual void VisitMethodRefSig(MethodRefSig methodRef)
		{
		}

		public virtual void VisitFieldSig(FieldSig field)
		{
		}

		public virtual void VisitPropertySig(PropertySig property)
		{
		}

		public virtual void VisitLocalVarSig(LocalVarSig localvar)
		{
		}
	}
}
