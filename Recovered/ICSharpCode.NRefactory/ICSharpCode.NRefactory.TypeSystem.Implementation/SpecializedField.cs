namespace ICSharpCode.NRefactory.TypeSystem.Implementation
{
	public class SpecializedField : SpecializedMember, IField, IMember, IEntity, ISymbol, ICompilationProvider, INamedElement, IHasAccessibility, IVariable
	{
		private readonly IField fieldDefinition;

		public bool IsReadOnly => fieldDefinition.IsReadOnly;

		public bool IsVolatile => fieldDefinition.IsVolatile;

		IType IVariable.Type => base.ReturnType;

		public bool IsConst => fieldDefinition.IsConst;

		public bool IsFixed => fieldDefinition.IsFixed;

		public object ConstantValue => fieldDefinition.ConstantValue;

		public SpecializedField(IField fieldDefinition, TypeParameterSubstitution substitution)
			: base(fieldDefinition)
		{
			this.fieldDefinition = fieldDefinition;
			AddSubstitution(substitution);
		}
	}
}
