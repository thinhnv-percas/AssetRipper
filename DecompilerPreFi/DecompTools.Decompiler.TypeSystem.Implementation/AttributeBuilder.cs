using System.Collections.Immutable;
using System.Linq;
using System.Reflection.Metadata;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

internal struct AttributeBuilder
{
	private readonly ICompilation compilation;

	private readonly IType attributeType;

	private ImmutableArray<CustomAttributeTypedArgument<IType>>.Builder fixedArgs;

	private ImmutableArray<CustomAttributeNamedArgument<IType>>.Builder namedArgs;

	public AttributeBuilder(MetadataModule module, KnownAttribute attributeType)
		: this(module, module.GetAttributeType(attributeType))
	{
	}

	public AttributeBuilder(MetadataModule module, IType attributeType)
	{
		compilation = module.Compilation;
		this.attributeType = attributeType;
		fixedArgs = ImmutableArray.CreateBuilder<CustomAttributeTypedArgument<IType>>();
		namedArgs = ImmutableArray.CreateBuilder<CustomAttributeNamedArgument<IType>>();
	}

	public void AddFixedArg(CustomAttributeTypedArgument<IType> arg)
	{
		fixedArgs.Add(arg);
	}

	public void AddFixedArg(KnownTypeCode type, object value)
	{
		AddFixedArg(compilation.FindType(type), value);
	}

	public void AddFixedArg(TopLevelTypeName type, object value)
	{
		AddFixedArg(compilation.FindType(type), value);
	}

	public void AddFixedArg(IType type, object value)
	{
		fixedArgs.Add(new CustomAttributeTypedArgument<IType>(type, value));
	}

	public void AddNamedArg(string name, KnownTypeCode type, object value)
	{
		AddNamedArg(name, compilation.FindType(type), value);
	}

	public void AddNamedArg(string name, TopLevelTypeName type, object value)
	{
		AddNamedArg(name, compilation.FindType(type), value);
	}

	public void AddNamedArg(string name, IType type, object value)
	{
		CustomAttributeNamedArgumentKind kind = ((!Enumerable.Any<IField>(attributeType.GetFields((IField f) => f.Name == name, GetMemberOptions.ReturnMemberDefinitions))) ? CustomAttributeNamedArgumentKind.Property : CustomAttributeNamedArgumentKind.Field);
		namedArgs.Add(new CustomAttributeNamedArgument<IType>(name, kind, type, value));
	}

	public IAttribute Build()
	{
		return new DefaultAttribute(attributeType, fixedArgs.ToImmutable(), namedArgs.ToImmutable());
	}
}
