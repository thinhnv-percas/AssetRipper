using System.Collections.Immutable;
using System.Reflection.Metadata;

namespace DecompTools.Decompiler.TypeSystem;

public interface IAttribute
{
	IType AttributeType { get; }

	IMethod Constructor { get; }

	bool HasDecodeErrors { get; }

	ImmutableArray<CustomAttributeTypedArgument<IType>> FixedArguments { get; }

	ImmutableArray<CustomAttributeNamedArgument<IType>> NamedArguments { get; }
}
