namespace DecompTools.Decompiler.TypeSystem.Implementation;

internal class FakeField : FakeMember, IField, IMember, IEntity, ISymbol, ICompilationProvider, INamedElement, IVariable
{
	bool IField.IsReadOnly => false;

	bool IField.IsVolatile => false;

	bool IVariable.IsConst => false;

	IType IVariable.Type => base.ReturnType;

	public override SymbolKind SymbolKind => SymbolKind.Field;

	public FakeField(ICompilation compilation)
		: base(compilation)
	{
	}

	object IVariable.GetConstantValue(bool throwOnInvalidMetadata)
	{
		return null;
	}

	public override IMember Specialize(TypeParameterSubstitution substitution)
	{
		return SpecializedField.Create(this, substitution);
	}
}
