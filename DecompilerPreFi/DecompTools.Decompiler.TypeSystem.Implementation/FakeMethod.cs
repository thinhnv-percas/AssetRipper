using System.Collections.Generic;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

internal class FakeMethod : FakeMember, IMethod, IParameterizedMember, IMember, IEntity, ISymbol, ICompilationProvider, INamedElement
{
	private readonly SymbolKind symbolKind;

	public override SymbolKind SymbolKind => symbolKind;

	public IReadOnlyList<ITypeParameter> TypeParameters { get; set; } = EmptyList<ITypeParameter>.Instance;

	IReadOnlyList<IType> IMethod.TypeArguments => TypeParameters;

	bool IMethod.IsExtensionMethod => false;

	bool IMethod.IsConstructor => symbolKind == SymbolKind.Constructor;

	bool IMethod.IsDestructor => symbolKind == SymbolKind.Destructor;

	bool IMethod.IsOperator => symbolKind == SymbolKind.Operator;

	bool IMethod.HasBody => false;

	bool IMethod.IsAccessor => false;

	IMember IMethod.AccessorOwner => null;

	IMethod IMethod.ReducedFrom => null;

	public IReadOnlyList<IParameter> Parameters { get; set; } = EmptyList<IParameter>.Instance;

	public FakeMethod(ICompilation compilation, SymbolKind symbolKind)
		: base(compilation)
	{
		this.symbolKind = symbolKind;
	}

	IEnumerable<IAttribute> IMethod.GetReturnTypeAttributes()
	{
		return EmptyList<IAttribute>.Instance;
	}

	public override IMember Specialize(TypeParameterSubstitution substitution)
	{
		return SpecializedMethod.Create(this, substitution);
	}

	IMethod IMethod.Specialize(TypeParameterSubstitution substitution)
	{
		return SpecializedMethod.Create(this, substitution);
	}

	internal static IMethod CreateDummyConstructor(ICompilation compilation, IType declaringType, Accessibility accessibility = Accessibility.Public)
	{
		return new FakeMethod(compilation, SymbolKind.Constructor)
		{
			DeclaringType = declaringType,
			Name = ".ctor",
			ReturnType = compilation.FindType(KnownTypeCode.Void),
			Accessibility = accessibility
		};
	}
}
