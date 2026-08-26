using System.Collections.Immutable;
using System.Linq;

namespace DecompTools.Decompiler.TypeSystem;

public class TupleTypeReference : ITypeReference
{
	public ImmutableArray<ITypeReference> ElementTypes { get; }

	public ImmutableArray<string> ElementNames { get; }

	public IModuleReference ValueTupleAssembly { get; }

	public TupleTypeReference(ImmutableArray<ITypeReference> elementTypes)
	{
		ElementTypes = elementTypes;
	}

	public TupleTypeReference(ImmutableArray<ITypeReference> elementTypes, ImmutableArray<string> elementNames = default(ImmutableArray<string>), IModuleReference valueTupleAssembly = null)
	{
		ValueTupleAssembly = valueTupleAssembly;
		ElementTypes = elementTypes;
		ElementNames = elementNames;
	}

	public IType Resolve(ITypeResolveContext context)
	{
		return new TupleType(context.Compilation, ElementTypes.Select((ITypeReference t) => t.Resolve(context)).ToImmutableArray(), ElementNames, ValueTupleAssembly?.Resolve(context));
	}
}
