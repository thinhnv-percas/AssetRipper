namespace ICSharpCode.NRefactory.TypeSystem.Implementation;

public class SpecializedProperty : SpecializedParameterizedMember, IProperty, IParameterizedMember, IMember, IEntity, ISymbol, ICompilationProvider, INamedElement, IHasAccessibility
{
	private readonly IProperty propertyDefinition;

	private IMethod getter;

	private IMethod setter;

	public bool CanGet => propertyDefinition.CanGet;

	public bool CanSet => propertyDefinition.CanSet;

	public IMethod Getter => WrapAccessor(ref getter, propertyDefinition.Getter);

	public IMethod Setter => WrapAccessor(ref setter, propertyDefinition.Setter);

	public bool IsIndexer => propertyDefinition.IsIndexer;

	public SpecializedProperty(IProperty propertyDefinition, TypeParameterSubstitution substitution)
		: base(propertyDefinition)
	{
		this.propertyDefinition = propertyDefinition;
		AddSubstitution(substitution);
	}
}
