using System;
using System.Collections.Generic;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.Utils;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation;

[Serializable]
public sealed class DefaultUnresolvedAttribute : AbstractFreezable, IUnresolvedAttribute, IFreezable, ISupportsInterning
{
	private sealed class DefaultResolvedAttribute : IAttribute, ICompilationProvider
	{
		private readonly DefaultUnresolvedAttribute unresolved;

		private readonly ITypeResolveContext context;

		private readonly IType attributeType;

		private readonly IList<ResolveResult> positionalArguments;

		private IList<KeyValuePair<IMember, ResolveResult>> namedArguments;

		private IMethod constructor;

		private volatile bool constructorResolved;

		public IType AttributeType => attributeType;

		public DomRegion Region => unresolved.Region;

		public IMethod Constructor
		{
			get
			{
				if (!constructorResolved)
				{
					constructor = ResolveConstructor();
					constructorResolved = true;
				}
				return constructor;
			}
		}

		public IList<ResolveResult> PositionalArguments => positionalArguments;

		public IList<KeyValuePair<IMember, ResolveResult>> NamedArguments
		{
			get
			{
				IList<KeyValuePair<IMember, ResolveResult>> list = LazyInit.VolatileRead(ref namedArguments);
				if (list != null)
				{
					return list;
				}
				list = new List<KeyValuePair<IMember, ResolveResult>>();
				foreach (KeyValuePair<IMemberReference, IConstantValue> namedArgument in unresolved.NamedArguments)
				{
					IMember member = namedArgument.Key.Resolve(context);
					if (member != null)
					{
						ResolveResult value = namedArgument.Value.Resolve(context);
						list.Add(new KeyValuePair<IMember, ResolveResult>(member, value));
					}
				}
				return LazyInit.GetOrSet(ref namedArguments, list);
			}
		}

		public ICompilation Compilation => context.Compilation;

		public DefaultResolvedAttribute(DefaultUnresolvedAttribute unresolved, ITypeResolveContext context)
		{
			this.unresolved = unresolved;
			this.context = context;
			attributeType = unresolved.AttributeType.Resolve(context);
			positionalArguments = unresolved.PositionalArguments.Resolve(context);
		}

		private IMethod ResolveConstructor()
		{
			IList<IType> parameterTypes = unresolved.ConstructorParameterTypes.Resolve(context);
			foreach (IMethod constructor in attributeType.GetConstructors((IUnresolvedMethod m) => m.Parameters.Count == parameterTypes.Count))
			{
				bool flag = true;
				for (int num = 0; num < parameterTypes.Count; num++)
				{
					if (!constructor.Parameters[num].Type.Equals(parameterTypes[num]))
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					return constructor;
				}
			}
			return null;
		}

		public override string ToString()
		{
			if (positionalArguments.Count == 0)
			{
				return "[" + attributeType.ToString() + "]";
			}
			return "[" + attributeType.ToString() + "(...)]";
		}
	}

	private ITypeReference attributeType;

	private DomRegion region;

	private IList<ITypeReference> constructorParameterTypes;

	private IList<IConstantValue> positionalArguments;

	private IList<KeyValuePair<IMemberReference, IConstantValue>> namedArguments;

	public ITypeReference AttributeType => attributeType;

	public DomRegion Region
	{
		get
		{
			return region;
		}
		set
		{
			FreezableHelper.ThrowIfFrozen(this);
			region = value;
		}
	}

	public IList<ITypeReference> ConstructorParameterTypes
	{
		get
		{
			if (constructorParameterTypes == null)
			{
				constructorParameterTypes = new List<ITypeReference>();
			}
			return constructorParameterTypes;
		}
	}

	public IList<IConstantValue> PositionalArguments
	{
		get
		{
			if (positionalArguments == null)
			{
				positionalArguments = new List<IConstantValue>();
			}
			return positionalArguments;
		}
	}

	public IList<KeyValuePair<IMemberReference, IConstantValue>> NamedArguments
	{
		get
		{
			if (namedArguments == null)
			{
				namedArguments = new List<KeyValuePair<IMemberReference, IConstantValue>>();
			}
			return namedArguments;
		}
	}

	public DefaultUnresolvedAttribute(ITypeReference attributeType)
	{
		if (attributeType == null)
		{
			throw new ArgumentNullException("attributeType");
		}
		this.attributeType = attributeType;
	}

	public DefaultUnresolvedAttribute(ITypeReference attributeType, IEnumerable<ITypeReference> constructorParameterTypes)
	{
		if (attributeType == null)
		{
			throw new ArgumentNullException("attributeType");
		}
		this.attributeType = attributeType;
		ConstructorParameterTypes.AddRange(constructorParameterTypes);
	}

	protected override void FreezeInternal()
	{
		base.FreezeInternal();
		constructorParameterTypes = FreezableHelper.FreezeList(constructorParameterTypes);
		positionalArguments = FreezableHelper.FreezeListAndElements(positionalArguments);
		namedArguments = FreezableHelper.FreezeList(namedArguments);
		foreach (KeyValuePair<IMemberReference, IConstantValue> namedArgument in namedArguments)
		{
			FreezableHelper.Freeze(namedArgument.Key);
			FreezableHelper.Freeze(namedArgument.Value);
		}
	}

	public void AddNamedFieldArgument(string fieldName, IConstantValue value)
	{
		NamedArguments.Add(new KeyValuePair<IMemberReference, IConstantValue>(new DefaultMemberReference(SymbolKind.Field, attributeType, fieldName), value));
	}

	public void AddNamedPropertyArgument(string propertyName, IConstantValue value)
	{
		NamedArguments.Add(new KeyValuePair<IMemberReference, IConstantValue>(new DefaultMemberReference(SymbolKind.Property, attributeType, propertyName), value));
	}

	public IAttribute CreateResolvedAttribute(ITypeResolveContext context)
	{
		return new DefaultResolvedAttribute(this, context);
	}

	int ISupportsInterning.GetHashCodeForInterning()
	{
		int num = attributeType.GetHashCode() ^ constructorParameterTypes.GetHashCode();
		if (constructorParameterTypes != null)
		{
			foreach (ITypeReference constructorParameterType in constructorParameterTypes)
			{
				num *= 27;
				num += constructorParameterType.GetHashCode();
			}
		}
		if (positionalArguments != null)
		{
			foreach (IConstantValue positionalArgument in positionalArguments)
			{
				num *= 31;
				num += positionalArgument.GetHashCode();
			}
		}
		if (namedArguments != null)
		{
			foreach (KeyValuePair<IMemberReference, IConstantValue> namedArgument in namedArguments)
			{
				num *= 71;
				num += namedArgument.Key.GetHashCode() + namedArgument.Value.GetHashCode() * 73;
			}
		}
		return num;
	}

	bool ISupportsInterning.EqualsForInterning(ISupportsInterning other)
	{
		if (other is DefaultUnresolvedAttribute defaultUnresolvedAttribute && attributeType == defaultUnresolvedAttribute.attributeType && ListEquals(constructorParameterTypes, defaultUnresolvedAttribute.constructorParameterTypes) && ListEquals(positionalArguments, defaultUnresolvedAttribute.positionalArguments))
		{
			return ListEquals(namedArguments ?? EmptyList<KeyValuePair<IMemberReference, IConstantValue>>.Instance, defaultUnresolvedAttribute.namedArguments ?? EmptyList<KeyValuePair<IMemberReference, IConstantValue>>.Instance);
		}
		return false;
	}

	private static bool ListEquals<T>(IList<T> list1, IList<T> list2) where T : class
	{
		if (list1 == null)
		{
			list1 = EmptyList<T>.Instance;
		}
		if (list2 == null)
		{
			list2 = EmptyList<T>.Instance;
		}
		if (list1 == list2)
		{
			return true;
		}
		if (list1.Count != list2.Count)
		{
			return false;
		}
		for (int i = 0; i < list1.Count; i++)
		{
			if (list1[i] != list2[i])
			{
				return false;
			}
		}
		return true;
	}

	private static bool ListEquals(IList<KeyValuePair<IMemberReference, IConstantValue>> list1, IList<KeyValuePair<IMemberReference, IConstantValue>> list2)
	{
		if (list1 == list2)
		{
			return true;
		}
		if (list1.Count != list2.Count)
		{
			return false;
		}
		for (int i = 0; i < list1.Count; i++)
		{
			KeyValuePair<IMemberReference, IConstantValue> keyValuePair = list1[i];
			KeyValuePair<IMemberReference, IConstantValue> keyValuePair2 = list2[i];
			if (keyValuePair.Key != keyValuePair2.Key || keyValuePair.Value != keyValuePair2.Value)
			{
				return false;
			}
		}
		return true;
	}
}
