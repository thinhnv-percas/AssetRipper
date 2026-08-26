using System.Collections.Generic;
using System.Reflection.Metadata;

namespace DecompTools.Decompiler.TypeSystem;

public interface IEntity : ISymbol, ICompilationProvider, INamedElement
{
	EntityHandle MetadataToken { get; }

	new string Name { get; }

	ITypeDefinition DeclaringTypeDefinition { get; }

	IType DeclaringType { get; }

	IModule ParentModule { get; }

	Accessibility Accessibility { get; }

	bool IsStatic { get; }

	bool IsAbstract { get; }

	bool IsSealed { get; }

	IEnumerable<IAttribute> GetAttributes();
}
