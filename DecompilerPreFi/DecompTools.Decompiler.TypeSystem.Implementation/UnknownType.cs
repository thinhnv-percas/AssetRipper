#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DecompTools.Decompiler.TypeSystem.Implementation;

[Serializable]
public class UnknownType : AbstractType, ITypeReference
{
	private readonly bool namespaceKnown;

	private readonly FullTypeName fullTypeName;

	private readonly bool? isReferenceType = null;

	public override TypeKind Kind => TypeKind.Unknown;

	public override string Name => fullTypeName.Name;

	public override string Namespace => fullTypeName.TopLevelTypeName.Namespace;

	public override string ReflectionName => namespaceKnown ? fullTypeName.ReflectionName : "?";

	public override int TypeParameterCount => fullTypeName.TypeParameterCount;

	public override IReadOnlyList<ITypeParameter> TypeParameters => DummyTypeParameter.GetClassTypeParameterList(TypeParameterCount);

	public override IReadOnlyList<IType> TypeArguments => TypeParameters;

	public override bool? IsReferenceType => isReferenceType;

	public UnknownType(string namespaceName, string name, int typeParameterCount = 0, bool? isReferenceType = null)
	{
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		namespaceKnown = namespaceName != null;
		fullTypeName = new TopLevelTypeName(namespaceName ?? string.Empty, name, typeParameterCount);
		this.isReferenceType = isReferenceType;
	}

	public UnknownType(FullTypeName fullTypeName, bool? isReferenceType = null)
	{
		this.isReferenceType = isReferenceType;
		if (fullTypeName.Name == null)
		{
			Debug.Assert(fullTypeName == default(FullTypeName));
			namespaceKnown = false;
			this.fullTypeName = new TopLevelTypeName(string.Empty, "?");
		}
		else
		{
			namespaceKnown = true;
			this.fullTypeName = fullTypeName;
		}
	}

	IType ITypeReference.Resolve(ITypeResolveContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		return this;
	}

	public override int GetHashCode()
	{
		return (namespaceKnown ? 812571 : 12651) ^ fullTypeName.GetHashCode();
	}

	public override bool Equals(IType other)
	{
		if (!(other is UnknownType unknownType))
		{
			return false;
		}
		return namespaceKnown == unknownType.namespaceKnown && fullTypeName == unknownType.fullTypeName && isReferenceType == unknownType.isReferenceType;
	}

	public override string ToString()
	{
		return "[UnknownType " + fullTypeName.ReflectionName + "]";
	}
}
