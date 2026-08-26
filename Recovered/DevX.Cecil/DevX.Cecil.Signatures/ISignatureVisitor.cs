namespace DevX.Cecil.Signatures
{
	internal interface ISignatureVisitor
	{
		void VisitMethodDefSig(MethodDefSig methodDef);

		void VisitMethodRefSig(MethodRefSig methodRef);

		void VisitFieldSig(FieldSig field);

		void VisitPropertySig(PropertySig property);

		void VisitLocalVarSig(LocalVarSig localvar);
	}
}
