using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

public class SpecializedField : SpecializedMember, IField, IMember, IEntity, ISymbol, ICompilationProvider, INamedElement, IVariable
{
	private readonly IField fieldDefinition;

	public bool IsReadOnly => fieldDefinition.IsReadOnly;

	public bool IsVolatile => fieldDefinition.IsVolatile;

	IType IVariable.Type => base.ReturnType;

	public bool IsConst => fieldDefinition.IsConst;

	internal static IField Create(IField fieldDefinition, TypeParameterSubstitution substitution)
	{
		if (TypeParameterSubstitution.Identity.Equals(substitution) || fieldDefinition.DeclaringType.TypeParameterCount == 0)
		{
			return fieldDefinition;
		}
		if (substitution.MethodTypeArguments != null && substitution.MethodTypeArguments.Count > 0)
		{
			substitution = new TypeParameterSubstitution(substitution.ClassTypeArguments, EmptyList<IType>.Instance);
		}
		return new SpecializedField(fieldDefinition, substitution);
	}

	public SpecializedField(IField fieldDefinition, TypeParameterSubstitution substitution)
		: base(fieldDefinition)
	{
		this.fieldDefinition = fieldDefinition;
		AddSubstitution(substitution);
	}

	public object GetConstantValue(bool throwOnInvalidMetadata)
	{
		return fieldDefinition.GetConstantValue(throwOnInvalidMetadata);
	}
}
