using System;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation;

[Serializable]
public sealed class DefaultMemberReference : IMemberReference, ISymbolReference, ISupportsInterning
{
	private readonly SymbolKind symbolKind;

	private readonly ITypeReference typeReference;

	private readonly string name;

	private readonly int typeParameterCount;

	private readonly IList<ITypeReference> parameterTypes;

	public ITypeReference DeclaringTypeReference => typeReference;

	public DefaultMemberReference(SymbolKind symbolKind, ITypeReference typeReference, string name, int typeParameterCount = 0, IList<ITypeReference> parameterTypes = null)
	{
		if (typeReference == null)
		{
			throw new ArgumentNullException("typeReference");
		}
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		if (typeParameterCount != 0 && symbolKind != SymbolKind.Method)
		{
			throw new ArgumentException("Type parameter count > 0 is only supported for methods.");
		}
		this.symbolKind = symbolKind;
		this.typeReference = typeReference;
		this.name = name;
		this.typeParameterCount = typeParameterCount;
		this.parameterTypes = parameterTypes ?? EmptyList<ITypeReference>.Instance;
	}

	public IMember Resolve(ITypeResolveContext context)
	{
		IType type = typeReference.Resolve(context);
		IEnumerable<IMember> enumerable = ((symbolKind == SymbolKind.Accessor) ? type.GetAccessors((IUnresolvedMethod m) => m.Name == name && !m.IsExplicitInterfaceImplementation, GetMemberOptions.IgnoreInheritedMembers) : ((symbolKind != SymbolKind.Method) ? type.GetMembers((IUnresolvedMember m) => m.Name == name && m.SymbolKind == symbolKind && !m.IsExplicitInterfaceImplementation, GetMemberOptions.IgnoreInheritedMembers) : type.GetMethods((IUnresolvedMethod m) => m.Name == name && m.SymbolKind == SymbolKind.Method && m.TypeParameters.Count == typeParameterCount && !m.IsExplicitInterfaceImplementation, GetMemberOptions.IgnoreInheritedMembers)));
		IList<IType> list = parameterTypes.Resolve(context);
		foreach (IMember item in enumerable)
		{
			if (!(item is IParameterizedMember parameterizedMember))
			{
				if (parameterTypes.Count == 0)
				{
					return item;
				}
			}
			else
			{
				if (parameterTypes.Count != parameterizedMember.Parameters.Count)
				{
					continue;
				}
				bool flag = true;
				for (int num = 0; num < parameterTypes.Count; num++)
				{
					IType type2 = DummyTypeParameter.NormalizeAllTypeParameters(list[num]);
					IType other = DummyTypeParameter.NormalizeAllTypeParameters(parameterizedMember.Parameters[num].Type);
					if (!type2.Equals(other))
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					return item;
				}
			}
		}
		return null;
	}

	ISymbol ISymbolReference.Resolve(ITypeResolveContext context)
	{
		return ((IMemberReference)this).Resolve(context);
	}

	int ISupportsInterning.GetHashCodeForInterning()
	{
		return (int)((uint)symbolKind ^ (uint)typeReference.GetHashCode() ^ (uint)name.GetHashCode()) ^ parameterTypes.GetHashCode();
	}

	bool ISupportsInterning.EqualsForInterning(ISupportsInterning other)
	{
		if (other is DefaultMemberReference defaultMemberReference && symbolKind == defaultMemberReference.symbolKind && typeReference == defaultMemberReference.typeReference && name == defaultMemberReference.name)
		{
			return parameterTypes == defaultMemberReference.parameterTypes;
		}
		return false;
	}
}
