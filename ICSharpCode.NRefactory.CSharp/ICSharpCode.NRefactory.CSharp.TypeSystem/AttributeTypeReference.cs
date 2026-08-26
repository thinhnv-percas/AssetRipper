using System;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.CSharp.TypeSystem;

[Serializable]
public sealed class AttributeTypeReference : ITypeReference, ISupportsInterning
{
	private readonly ITypeReference withoutSuffix;

	private readonly ITypeReference withSuffix;

	public AttributeTypeReference(ITypeReference withoutSuffix, ITypeReference withSuffix)
	{
		if (withoutSuffix == null)
		{
			throw new ArgumentNullException("withoutSuffix");
		}
		if (withSuffix == null)
		{
			throw new ArgumentNullException("withSuffix");
		}
		this.withoutSuffix = withoutSuffix;
		this.withSuffix = withSuffix;
	}

	public IType Resolve(ITypeResolveContext context)
	{
		IType type = withoutSuffix.Resolve(context);
		IType type2 = withSuffix.Resolve(context);
		if (!PreferAttributeTypeWithSuffix(type, type2, context.Compilation))
		{
			return type;
		}
		return type2;
	}

	internal static bool PreferAttributeTypeWithSuffix(IType t1, IType t2, ICompilation compilation)
	{
		if (t2.Kind == TypeKind.Unknown)
		{
			return false;
		}
		if (t1.Kind == TypeKind.Unknown)
		{
			return true;
		}
		ITypeDefinition definition = compilation.FindType(KnownTypeCode.Attribute).GetDefinition();
		if (definition != null)
		{
			bool flag = t1.GetDefinition() != null && t1.GetDefinition().IsDerivedFrom(definition);
			if (t2.GetDefinition() != null && t2.GetDefinition().IsDerivedFrom(definition) && !flag)
			{
				return true;
			}
		}
		return false;
	}

	public override string ToString()
	{
		return withoutSuffix.ToString() + "[Attribute]";
	}

	int ISupportsInterning.GetHashCodeForInterning()
	{
		return withoutSuffix.GetHashCode() + 715613 * withSuffix.GetHashCode();
	}

	bool ISupportsInterning.EqualsForInterning(ISupportsInterning other)
	{
		if (other is AttributeTypeReference attributeTypeReference && withoutSuffix == attributeTypeReference.withoutSuffix)
		{
			return withSuffix == attributeTypeReference.withSuffix;
		}
		return false;
	}
}
