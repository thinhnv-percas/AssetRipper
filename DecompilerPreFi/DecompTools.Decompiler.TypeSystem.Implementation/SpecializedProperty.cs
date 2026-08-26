using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

public class SpecializedProperty : SpecializedParameterizedMember, IProperty, IParameterizedMember, IMember, IEntity, ISymbol, ICompilationProvider, INamedElement
{
	private readonly IProperty propertyDefinition;

	private IMethod getter;

	private IMethod setter;

	public bool CanGet => propertyDefinition.CanGet;

	public bool CanSet => propertyDefinition.CanSet;

	public IMethod Getter => WrapAccessor(ref getter, propertyDefinition.Getter);

	public IMethod Setter => WrapAccessor(ref setter, propertyDefinition.Setter);

	public bool IsIndexer => propertyDefinition.IsIndexer;

	internal static IProperty Create(IProperty propertyDefinition, TypeParameterSubstitution substitution)
	{
		if (TypeParameterSubstitution.Identity.Equals(substitution) || propertyDefinition.DeclaringType.TypeParameterCount == 0)
		{
			return propertyDefinition;
		}
		if (substitution.MethodTypeArguments != null && substitution.MethodTypeArguments.Count > 0)
		{
			substitution = new TypeParameterSubstitution(substitution.ClassTypeArguments, EmptyList<IType>.Instance);
		}
		return new SpecializedProperty(propertyDefinition, substitution);
	}

	public SpecializedProperty(IProperty propertyDefinition, TypeParameterSubstitution substitution)
		: base(propertyDefinition)
	{
		this.propertyDefinition = propertyDefinition;
		AddSubstitution(substitution);
	}
}
