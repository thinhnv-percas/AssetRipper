using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation
{
	public class DefaultResolvedMethod : AbstractResolvedMember, IMethod, IParameterizedMember, IMember, IEntity, ISymbol, ICompilationProvider, INamedElement, IHasAccessibility
	{
		private class ListOfLists<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable
		{
			private List<IList<T>> lists = new List<IList<T>>();

			public int Count => lists.Sum((IList<T> l) => l.Count);

			public bool IsReadOnly => true;

			public T this[int index]
			{
				get
				{
					foreach (IList<T> list in lists)
					{
						if (index < list.Count)
						{
							return list[index];
						}
						index -= list.Count;
					}
					throw new IndexOutOfRangeException();
				}
				set
				{
					throw new NotSupportedException();
				}
			}

			public void AddList(IList<T> list)
			{
				lists.Add(list);
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}

			public IEnumerator<T> GetEnumerator()
			{
				for (int i = 0; i < Count; i++)
				{
					yield return this[i];
				}
			}

			public void Add(T item)
			{
				throw new NotSupportedException();
			}

			public void Clear()
			{
				throw new NotSupportedException();
			}

			public bool Contains(T item)
			{
				EqualityComparer<T> @default = EqualityComparer<T>.Default;
				for (int i = 0; i < Count; i++)
				{
					if (@default.Equals(this[i], item))
					{
						return true;
					}
				}
				return false;
			}

			public void CopyTo(T[] array, int arrayIndex)
			{
				for (int i = 0; i < Count; i++)
				{
					array[arrayIndex + i] = this[i];
				}
			}

			public bool Remove(T item)
			{
				throw new NotSupportedException();
			}

			public int IndexOf(T item)
			{
				EqualityComparer<T> @default = EqualityComparer<T>.Default;
				for (int i = 0; i < Count; i++)
				{
					if (@default.Equals(this[i], item))
					{
						return i;
					}
				}
				return -1;
			}

			public void Insert(int index, T item)
			{
				throw new NotSupportedException();
			}

			public void RemoveAt(int index)
			{
				throw new NotSupportedException();
			}
		}

		private IUnresolvedMethod[] parts;

		public IList<IParameter> Parameters
		{
			get;
			private set;
		}

		public IList<IAttribute> ReturnTypeAttributes
		{
			get;
			private set;
		}

		public IList<ITypeParameter> TypeParameters
		{
			get;
			private set;
		}

		public IList<IType> TypeArguments => ((IEnumerable<IType>)TypeParameters).ToList();

		bool IMethod.IsParameterized => false;

		public bool IsExtensionMethod
		{
			get;
			private set;
		}

		public IList<IUnresolvedMethod> Parts => parts ?? new IUnresolvedMethod[1]
		{
			(IUnresolvedMethod)unresolved
		};

		public bool IsConstructor => ((IUnresolvedMethod)unresolved).IsConstructor;

		public bool IsDestructor => ((IUnresolvedMethod)unresolved).IsDestructor;

		public bool IsOperator => ((IUnresolvedMethod)unresolved).IsOperator;

		public bool IsPartial => ((IUnresolvedMethod)unresolved).IsPartial;

		public bool IsAsync => ((IUnresolvedMethod)unresolved).IsAsync;

		public bool HasBody => ((IUnresolvedMethod)unresolved).HasBody;

		public bool IsAccessor => ((IUnresolvedMethod)unresolved).AccessorOwner != null;

		IMethod IMethod.ReducedFrom => null;

		public virtual IMember AccessorOwner => ((IUnresolvedMethod)unresolved).AccessorOwner?.Resolve(context);

		public DefaultResolvedMethod(DefaultUnresolvedMethod unresolved, ITypeResolveContext parentContext)
			: this(unresolved, parentContext, unresolved.IsExtensionMethod)
		{
		}

		public DefaultResolvedMethod(IUnresolvedMethod unresolved, ITypeResolveContext parentContext, bool isExtensionMethod)
			: base(unresolved, parentContext)
		{
			Parameters = unresolved.Parameters.CreateResolvedParameters(context);
			ReturnTypeAttributes = unresolved.ReturnTypeAttributes.CreateResolvedAttributes(parentContext);
			TypeParameters = unresolved.TypeParameters.CreateResolvedTypeParameters(context);
			IsExtensionMethod = isExtensionMethod;
		}

		public static DefaultResolvedMethod CreateFromMultipleParts(IUnresolvedMethod[] parts, ITypeResolveContext[] contexts, bool isExtensionMethod)
		{
			DefaultResolvedMethod defaultResolvedMethod = new DefaultResolvedMethod(parts[0], contexts[0], isExtensionMethod);
			defaultResolvedMethod.parts = parts;
			if (parts.Length > 1)
			{
				ListOfLists<IAttribute> listOfLists = new ListOfLists<IAttribute>();
				listOfLists.AddList(defaultResolvedMethod.Attributes);
				for (int i = 1; i < parts.Length; i++)
				{
					listOfLists.AddList(parts[i].Attributes.CreateResolvedAttributes(contexts[i]));
				}
				defaultResolvedMethod.Attributes = listOfLists;
			}
			return defaultResolvedMethod;
		}

		public override ISymbolReference ToReference()
		{
			IType declaringType = DeclaringType;
			object typeReference;
			if (declaringType == null)
			{
				ITypeReference unknownType = SpecialType.UnknownType;
				typeReference = unknownType;
			}
			else
			{
				typeReference = declaringType.ToTypeReference();
			}
			ITypeReference typeReference2 = (ITypeReference)typeReference;
			if (base.IsExplicitInterfaceImplementation && base.ImplementedInterfaceMembers.Count == 1)
			{
				return new ExplicitInterfaceImplementationMemberReference(typeReference2, base.ImplementedInterfaceMembers[0].ToReference());
			}
			return new DefaultMemberReference(base.SymbolKind, typeReference2, base.Name, TypeParameters.Count, (from p in Parameters
				select p.Type.ToTypeReference()).ToList());
		}

		public override IMemberReference ToMemberReference()
		{
			return (IMemberReference)ToReference();
		}

		public override IMember Specialize(TypeParameterSubstitution substitution)
		{
			if (TypeParameterSubstitution.Identity.Equals(substitution))
			{
				return this;
			}
			if (TypeParameters.Count == 0)
			{
				if (base.DeclaringTypeDefinition == null || base.DeclaringTypeDefinition.TypeParameterCount == 0)
				{
					return this;
				}
				if (substitution.MethodTypeArguments != null && substitution.MethodTypeArguments.Count > 0)
				{
					substitution = new TypeParameterSubstitution(substitution.ClassTypeArguments, EmptyList<IType>.Instance);
				}
			}
			return new SpecializedMethod(this, substitution);
		}

		IMethod IMethod.Specialize(TypeParameterSubstitution substitution)
		{
			return (IMethod)Specialize(substitution);
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder("[");
			stringBuilder.Append(base.SymbolKind);
			stringBuilder.Append(' ');
			if (DeclaringType != null)
			{
				stringBuilder.Append(DeclaringType.ReflectionName);
				stringBuilder.Append('.');
			}
			stringBuilder.Append(base.Name);
			if (TypeParameters.Count > 0)
			{
				stringBuilder.Append("``");
				stringBuilder.Append(TypeParameters.Count);
			}
			stringBuilder.Append('(');
			for (int i = 0; i < Parameters.Count; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append(", ");
				}
				stringBuilder.Append(Parameters[i].ToString());
			}
			stringBuilder.Append("):");
			stringBuilder.Append(base.ReturnType.ReflectionName);
			stringBuilder.Append(']');
			return stringBuilder.ToString();
		}

		public static IMethod GetDummyConstructor(ICompilation compilation)
		{
			IUnresolvedMethod dummyConstructor = DefaultUnresolvedMethod.DummyConstructor;
			return (IMethod)compilation.CacheManager.GetOrAddShared(dummyConstructor, (object _) => dummyConstructor.CreateResolved(compilation.TypeResolveContext));
		}

		public static IMethod GetDummyConstructor(ICompilation compilation, IType declaringType)
		{
			return new SpecializedMethod(GetDummyConstructor(compilation), TypeParameterSubstitution.Identity)
			{
				DeclaringType = declaringType
			};
		}
	}
}
