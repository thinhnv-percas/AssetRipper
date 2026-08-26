#define DEBUG
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using DecompTools.Decompiler.TypeSystem.Implementation;

namespace DecompTools.Decompiler.TypeSystem;

[Serializable]
public sealed class ParameterizedType : IType, INamedElement, IEquatable<IType>
{
	private readonly IType genericType;

	private readonly IType[] typeArguments;

	public TypeKind Kind => genericType.Kind;

	public IType GenericType => genericType;

	public bool? IsReferenceType => genericType.IsReferenceType;

	public bool IsByRefLike => genericType.IsByRefLike;

	public Nullability Nullability => genericType.Nullability;

	public IType DeclaringType
	{
		get
		{
			IType declaringType = genericType.DeclaringType;
			if (declaringType != null && declaringType.TypeParameterCount > 0 && declaringType.TypeParameterCount <= genericType.TypeParameterCount)
			{
				IType[] array = new IType[declaringType.TypeParameterCount];
				Array.Copy(typeArguments, 0, array, 0, array.Length);
				return new ParameterizedType(declaringType, array);
			}
			return declaringType;
		}
	}

	public int TypeParameterCount => typeArguments.Length;

	public string FullName => genericType.FullName;

	public string Name => genericType.Name;

	public string Namespace => genericType.Namespace;

	public string ReflectionName
	{
		get
		{
			StringBuilder stringBuilder = new StringBuilder(genericType.ReflectionName);
			stringBuilder.Append('[');
			for (int i = 0; i < typeArguments.Length; i = checked(i + 1))
			{
				if (i > 0)
				{
					stringBuilder.Append(',');
				}
				stringBuilder.Append('[');
				stringBuilder.Append(typeArguments[i].ReflectionName);
				stringBuilder.Append(']');
			}
			stringBuilder.Append(']');
			return stringBuilder.ToString();
		}
	}

	public IReadOnlyList<IType> TypeArguments => typeArguments;

	public IReadOnlyList<ITypeParameter> TypeParameters => genericType.TypeParameters;

	public IEnumerable<IType> DirectBaseTypes
	{
		get
		{
			TypeParameterSubstitution substitution = GetSubstitution();
			return Enumerable.Select<IType, IType>(genericType.DirectBaseTypes, (Func<IType, IType>)((IType t) => t.AcceptVisitor(substitution)));
		}
	}

	public ParameterizedType(IType genericType, IEnumerable<IType> typeArguments)
	{
		if (genericType == null)
		{
			throw new ArgumentNullException("genericType");
		}
		if (typeArguments == null)
		{
			throw new ArgumentNullException("typeArguments");
		}
		this.genericType = genericType;
		this.typeArguments = Enumerable.ToArray<IType>(typeArguments);
		if (this.typeArguments.Length == 0)
		{
			throw new ArgumentException("Cannot use ParameterizedType with 0 type arguments.");
		}
		if (genericType.TypeParameterCount != this.typeArguments.Length)
		{
			throw new ArgumentException("Number of type arguments must match the type definition's number of type parameters");
		}
		ICompilationProvider compilationProvider = genericType as ICompilationProvider;
		for (int i = 0; i < this.typeArguments.Length; i = checked(i + 1))
		{
			if (this.typeArguments[i] == null)
			{
				throw new ArgumentNullException("typeArguments[" + i + "]");
			}
			if (this.typeArguments[i] is ICompilationProvider compilationProvider2 && compilationProvider != null && compilationProvider2.Compilation != compilationProvider.Compilation)
			{
				throw new InvalidOperationException("Cannot parameterize a type with type arguments from a different compilation.");
			}
		}
	}

	internal ParameterizedType(IType genericType, IType[] typeArguments)
	{
		Debug.Assert(genericType.TypeParameterCount == typeArguments.Length);
		this.genericType = genericType;
		this.typeArguments = typeArguments;
	}

	public IType ChangeNullability(Nullability nullability)
	{
		IType type = genericType.ChangeNullability(nullability);
		if (type == genericType)
		{
			return this;
		}
		return new ParameterizedType(type, typeArguments);
	}

	public override string ToString()
	{
		return ReflectionName;
	}

	public IType GetTypeArgument(int index)
	{
		return typeArguments[index];
	}

	public ITypeDefinition GetDefinition()
	{
		return genericType.GetDefinition();
	}

	public TypeParameterSubstitution GetSubstitution()
	{
		return new TypeParameterSubstitution(typeArguments, null);
	}

	public TypeParameterSubstitution GetSubstitution(IReadOnlyList<IType> methodTypeArguments)
	{
		return new TypeParameterSubstitution(typeArguments, methodTypeArguments);
	}

	public IEnumerable<IType> GetNestedTypes(Predicate<ITypeDefinition> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		if ((options & GetMemberOptions.ReturnMemberDefinitions) == GetMemberOptions.ReturnMemberDefinitions)
		{
			return genericType.GetNestedTypes(filter, options);
		}
		return GetMembersHelper.GetNestedTypes(this, filter, options);
	}

	public IEnumerable<IType> GetNestedTypes(IReadOnlyList<IType> typeArguments, Predicate<ITypeDefinition> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		if ((options & GetMemberOptions.ReturnMemberDefinitions) == GetMemberOptions.ReturnMemberDefinitions)
		{
			return genericType.GetNestedTypes(typeArguments, filter, options);
		}
		return GetMembersHelper.GetNestedTypes(this, typeArguments, filter, options);
	}

	public IEnumerable<IMethod> GetConstructors(Predicate<IMethod> filter = null, GetMemberOptions options = GetMemberOptions.IgnoreInheritedMembers)
	{
		if ((options & GetMemberOptions.ReturnMemberDefinitions) == GetMemberOptions.ReturnMemberDefinitions)
		{
			return genericType.GetConstructors(filter, options);
		}
		return GetMembersHelper.GetConstructors(this, filter, options);
	}

	public IEnumerable<IMethod> GetMethods(Predicate<IMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		if ((options & GetMemberOptions.ReturnMemberDefinitions) == GetMemberOptions.ReturnMemberDefinitions)
		{
			return genericType.GetMethods(filter, options);
		}
		return GetMembersHelper.GetMethods(this, filter, options);
	}

	public IEnumerable<IMethod> GetMethods(IReadOnlyList<IType> typeArguments, Predicate<IMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		if ((options & GetMemberOptions.ReturnMemberDefinitions) == GetMemberOptions.ReturnMemberDefinitions)
		{
			return genericType.GetMethods(typeArguments, filter, options);
		}
		return GetMembersHelper.GetMethods(this, typeArguments, filter, options);
	}

	public IEnumerable<IProperty> GetProperties(Predicate<IProperty> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		if ((options & GetMemberOptions.ReturnMemberDefinitions) == GetMemberOptions.ReturnMemberDefinitions)
		{
			return genericType.GetProperties(filter, options);
		}
		return GetMembersHelper.GetProperties(this, filter, options);
	}

	public IEnumerable<IField> GetFields(Predicate<IField> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		if ((options & GetMemberOptions.ReturnMemberDefinitions) == GetMemberOptions.ReturnMemberDefinitions)
		{
			return genericType.GetFields(filter, options);
		}
		return GetMembersHelper.GetFields(this, filter, options);
	}

	public IEnumerable<IEvent> GetEvents(Predicate<IEvent> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		if ((options & GetMemberOptions.ReturnMemberDefinitions) == GetMemberOptions.ReturnMemberDefinitions)
		{
			return genericType.GetEvents(filter, options);
		}
		return GetMembersHelper.GetEvents(this, filter, options);
	}

	public IEnumerable<IMember> GetMembers(Predicate<IMember> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		if ((options & GetMemberOptions.ReturnMemberDefinitions) == GetMemberOptions.ReturnMemberDefinitions)
		{
			return genericType.GetMembers(filter, options);
		}
		return GetMembersHelper.GetMembers(this, filter, options);
	}

	public IEnumerable<IMethod> GetAccessors(Predicate<IMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		if ((options & GetMemberOptions.ReturnMemberDefinitions) == GetMemberOptions.ReturnMemberDefinitions)
		{
			return genericType.GetAccessors(filter, options);
		}
		return GetMembersHelper.GetAccessors(this, filter, options);
	}

	public override bool Equals(object obj)
	{
		return Equals(obj as IType);
	}

	public bool Equals(IType other)
	{
		if (this == other)
		{
			return true;
		}
		if (!(other is ParameterizedType parameterizedType) || !genericType.Equals(parameterizedType.genericType) || typeArguments.Length != parameterizedType.typeArguments.Length)
		{
			return false;
		}
		for (int i = 0; i < typeArguments.Length; i = checked(i + 1))
		{
			if (!typeArguments[i].Equals(parameterizedType.typeArguments[i]))
			{
				return false;
			}
		}
		return true;
	}

	public override int GetHashCode()
	{
		int num = genericType.GetHashCode();
		IType[] array = typeArguments;
		foreach (IType type in array)
		{
			num *= 1000000007;
			num += 1000000009 * type.GetHashCode();
		}
		return num;
	}

	public IType AcceptVisitor(TypeVisitor visitor)
	{
		return visitor.VisitParameterizedType(this);
	}

	public IType VisitChildren(TypeVisitor visitor)
	{
		IType type = genericType.AcceptVisitor(visitor);
		IType[] array = ((type != genericType) ? new IType[typeArguments.Length] : null);
		checked
		{
			for (int i = 0; i < typeArguments.Length; i++)
			{
				IType type2 = typeArguments[i].AcceptVisitor(visitor);
				if (type2 == null)
				{
					throw new NullReferenceException("TypeVisitor.Visit-method returned null");
				}
				if (array == null && type2 != typeArguments[i])
				{
					array = new IType[typeArguments.Length];
					for (int j = 0; j < i; j++)
					{
						array[j] = typeArguments[j];
					}
				}
				if (array != null)
				{
					array[i] = type2;
				}
			}
			if (array == null)
			{
				return this;
			}
			return new ParameterizedType(type, array ?? typeArguments);
		}
	}
}
