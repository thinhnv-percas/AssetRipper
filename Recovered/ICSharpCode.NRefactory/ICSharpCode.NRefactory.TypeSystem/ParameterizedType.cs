using ICSharpCode.NRefactory.TypeSystem.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICSharpCode.NRefactory.TypeSystem
{
	[Serializable]
	public sealed class ParameterizedType : IType, INamedElement, IEquatable<IType>, ICompilationProvider
	{
		private readonly ITypeDefinition genericType;

		private readonly IType[] typeArguments;

		public TypeKind Kind => genericType.Kind;

		public ICompilation Compilation => genericType.Compilation;

		public bool? IsReferenceType => genericType.IsReferenceType;

		public IType DeclaringType
		{
			get
			{
				ITypeDefinition declaringTypeDefinition = genericType.DeclaringTypeDefinition;
				if (declaringTypeDefinition != null && declaringTypeDefinition.TypeParameterCount > 0 && declaringTypeDefinition.TypeParameterCount <= genericType.TypeParameterCount)
				{
					IType[] array = new IType[declaringTypeDefinition.TypeParameterCount];
					Array.Copy(typeArguments, 0, array, 0, array.Length);
					return new ParameterizedType(declaringTypeDefinition, array);
				}
				return declaringTypeDefinition;
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
				for (int i = 0; i < typeArguments.Length; i++)
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

		public IList<IType> TypeArguments => typeArguments;

		public bool IsParameterized => true;

		public IEnumerable<IType> DirectBaseTypes
		{
			get
			{
				TypeParameterSubstitution substitution = GetSubstitution();
				return from t in genericType.DirectBaseTypes
					select t.AcceptVisitor(substitution);
			}
		}

		public ParameterizedType(ITypeDefinition genericType, IEnumerable<IType> typeArguments)
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
			this.typeArguments = typeArguments.ToArray();
			if (this.typeArguments.Length == 0)
			{
				throw new ArgumentException("Cannot use ParameterizedType with 0 type arguments.");
			}
			if (genericType.TypeParameterCount != this.typeArguments.Length)
			{
				throw new ArgumentException("Number of type arguments must match the type definition's number of type parameters");
			}
			int num = 0;
			while (true)
			{
				if (num < this.typeArguments.Length)
				{
					if (this.typeArguments[num] == null)
					{
						throw new ArgumentNullException("typeArguments[" + num + "]");
					}
					ICompilationProvider compilationProvider = this.typeArguments[num] as ICompilationProvider;
					if (compilationProvider != null && compilationProvider.Compilation != genericType.Compilation)
					{
						break;
					}
					num++;
					continue;
				}
				return;
			}
			throw new InvalidOperationException("Cannot parameterize a type with type arguments from a different compilation.");
		}

		internal ParameterizedType(ITypeDefinition genericType, IType[] typeArguments)
		{
			this.genericType = genericType;
			this.typeArguments = typeArguments;
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
			return genericType;
		}

		public ITypeReference ToTypeReference()
		{
			return new ParameterizedTypeReference(genericType.ToTypeReference(), from t in typeArguments
				select t.ToTypeReference());
		}

		public TypeParameterSubstitution GetSubstitution()
		{
			return new TypeParameterSubstitution(typeArguments, null);
		}

		public TypeParameterSubstitution GetSubstitution(IList<IType> methodTypeArguments)
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

		public IEnumerable<IType> GetNestedTypes(IList<IType> typeArguments, Predicate<ITypeDefinition> filter = null, GetMemberOptions options = GetMemberOptions.None)
		{
			if ((options & GetMemberOptions.ReturnMemberDefinitions) == GetMemberOptions.ReturnMemberDefinitions)
			{
				return genericType.GetNestedTypes(typeArguments, filter, options);
			}
			return GetMembersHelper.GetNestedTypes(this, typeArguments, filter, options);
		}

		public IEnumerable<IMethod> GetConstructors(Predicate<IUnresolvedMethod> filter = null, GetMemberOptions options = GetMemberOptions.IgnoreInheritedMembers)
		{
			if ((options & GetMemberOptions.ReturnMemberDefinitions) == GetMemberOptions.ReturnMemberDefinitions)
			{
				return genericType.GetConstructors(filter, options);
			}
			return GetMembersHelper.GetConstructors(this, filter, options);
		}

		public IEnumerable<IMethod> GetMethods(Predicate<IUnresolvedMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
		{
			if ((options & GetMemberOptions.ReturnMemberDefinitions) == GetMemberOptions.ReturnMemberDefinitions)
			{
				return genericType.GetMethods(filter, options);
			}
			return GetMembersHelper.GetMethods(this, filter, options);
		}

		public IEnumerable<IMethod> GetMethods(IList<IType> typeArguments, Predicate<IUnresolvedMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
		{
			if ((options & GetMemberOptions.ReturnMemberDefinitions) == GetMemberOptions.ReturnMemberDefinitions)
			{
				return genericType.GetMethods(typeArguments, filter, options);
			}
			return GetMembersHelper.GetMethods(this, typeArguments, filter, options);
		}

		public IEnumerable<IProperty> GetProperties(Predicate<IUnresolvedProperty> filter = null, GetMemberOptions options = GetMemberOptions.None)
		{
			if ((options & GetMemberOptions.ReturnMemberDefinitions) == GetMemberOptions.ReturnMemberDefinitions)
			{
				return genericType.GetProperties(filter, options);
			}
			return GetMembersHelper.GetProperties(this, filter, options);
		}

		public IEnumerable<IField> GetFields(Predicate<IUnresolvedField> filter = null, GetMemberOptions options = GetMemberOptions.None)
		{
			if ((options & GetMemberOptions.ReturnMemberDefinitions) == GetMemberOptions.ReturnMemberDefinitions)
			{
				return genericType.GetFields(filter, options);
			}
			return GetMembersHelper.GetFields(this, filter, options);
		}

		public IEnumerable<IEvent> GetEvents(Predicate<IUnresolvedEvent> filter = null, GetMemberOptions options = GetMemberOptions.None)
		{
			if ((options & GetMemberOptions.ReturnMemberDefinitions) == GetMemberOptions.ReturnMemberDefinitions)
			{
				return genericType.GetEvents(filter, options);
			}
			return GetMembersHelper.GetEvents(this, filter, options);
		}

		public IEnumerable<IMember> GetMembers(Predicate<IUnresolvedMember> filter = null, GetMemberOptions options = GetMemberOptions.None)
		{
			if ((options & GetMemberOptions.ReturnMemberDefinitions) == GetMemberOptions.ReturnMemberDefinitions)
			{
				return genericType.GetMembers(filter, options);
			}
			return GetMembersHelper.GetMembers(this, filter, options);
		}

		public IEnumerable<IMethod> GetAccessors(Predicate<IUnresolvedMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
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
			ParameterizedType parameterizedType = other as ParameterizedType;
			if (parameterizedType == null || !genericType.Equals(parameterizedType.genericType) || typeArguments.Length != parameterizedType.typeArguments.Length)
			{
				return false;
			}
			for (int i = 0; i < typeArguments.Length; i++)
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
			ITypeDefinition typeDefinition = type as ITypeDefinition;
			if (typeDefinition == null)
			{
				return type;
			}
			IType[] array = (type != genericType) ? new IType[typeArguments.Length] : null;
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
			if (typeDefinition == genericType && array == null)
			{
				return this;
			}
			return new ParameterizedType(typeDefinition, array ?? typeArguments);
		}
	}
}
