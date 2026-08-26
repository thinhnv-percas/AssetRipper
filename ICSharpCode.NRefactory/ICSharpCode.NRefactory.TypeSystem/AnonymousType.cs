using System;
using System.Collections.Generic;
using System.Linq;
using ICSharpCode.NRefactory.TypeSystem.Implementation;
using ICSharpCode.NRefactory.Utils;

namespace ICSharpCode.NRefactory.TypeSystem;

public class AnonymousType : AbstractType
{
	private sealed class AnonymousTypeProperty : DefaultResolvedProperty
	{
		private readonly AnonymousType declaringType;

		public override IType DeclaringType => declaringType;

		public AnonymousTypeProperty(IUnresolvedProperty unresolved, ITypeResolveContext parentContext, AnonymousType declaringType)
			: base(unresolved, parentContext)
		{
			this.declaringType = declaringType;
		}

		public override bool Equals(object obj)
		{
			if (obj is AnonymousTypeProperty anonymousTypeProperty && base.Name == anonymousTypeProperty.Name)
			{
				return declaringType.Equals(anonymousTypeProperty.declaringType);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return declaringType.GetHashCode() ^ (27 * base.Name.GetHashCode());
		}

		protected override IMethod CreateResolvedAccessor(IUnresolvedMethod unresolvedAccessor)
		{
			return new AnonymousTypeAccessor(unresolvedAccessor, context, this);
		}
	}

	private sealed class AnonymousTypeAccessor : DefaultResolvedMethod
	{
		private readonly AnonymousTypeProperty owner;

		public override IMember AccessorOwner => owner;

		public override IType DeclaringType => owner.DeclaringType;

		public AnonymousTypeAccessor(IUnresolvedMethod unresolved, ITypeResolveContext parentContext, AnonymousTypeProperty owner)
			: base(unresolved, parentContext, isExtensionMethod: false)
		{
			this.owner = owner;
		}

		public override bool Equals(object obj)
		{
			if (obj is AnonymousTypeAccessor anonymousTypeAccessor && base.Name == anonymousTypeAccessor.Name)
			{
				return owner.DeclaringType.Equals(anonymousTypeAccessor.owner.DeclaringType);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return owner.DeclaringType.GetHashCode() ^ (27 * base.Name.GetHashCode());
		}
	}

	private ICompilation compilation;

	private IUnresolvedProperty[] unresolvedProperties;

	private IList<IProperty> resolvedProperties;

	public override string Name => "Anonymous Type";

	public override TypeKind Kind => TypeKind.Anonymous;

	public override IEnumerable<IType> DirectBaseTypes
	{
		get
		{
			yield return compilation.FindType(KnownTypeCode.Object);
		}
	}

	public override bool? IsReferenceType => true;

	public IList<IProperty> Properties => resolvedProperties;

	public AnonymousType(ICompilation compilation, IList<IUnresolvedProperty> properties)
	{
		if (compilation == null)
		{
			throw new ArgumentNullException("compilation");
		}
		if (properties == null)
		{
			throw new ArgumentNullException("properties");
		}
		this.compilation = compilation;
		unresolvedProperties = properties.ToArray();
		SimpleTypeResolveContext context = new SimpleTypeResolveContext(compilation.MainAssembly);
		resolvedProperties = new ProjectedList<ITypeResolveContext, IUnresolvedProperty, IProperty>(context, unresolvedProperties, (ITypeResolveContext c, IUnresolvedProperty p) => new AnonymousTypeProperty(p, c, this));
	}

	public override ITypeReference ToTypeReference()
	{
		return new AnonymousTypeReference(unresolvedProperties);
	}

	public override IEnumerable<IMethod> GetMethods(Predicate<IUnresolvedMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
		{
			return EmptyList<IMethod>.Instance;
		}
		return compilation.FindType(KnownTypeCode.Object).GetMethods(filter, options);
	}

	public override IEnumerable<IMethod> GetMethods(IList<IType> typeArguments, Predicate<IUnresolvedMethod> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		if ((options & GetMemberOptions.IgnoreInheritedMembers) == GetMemberOptions.IgnoreInheritedMembers)
		{
			return EmptyList<IMethod>.Instance;
		}
		return compilation.FindType(KnownTypeCode.Object).GetMethods(typeArguments, filter, options);
	}

	public override IEnumerable<IProperty> GetProperties(Predicate<IUnresolvedProperty> filter = null, GetMemberOptions options = GetMemberOptions.None)
	{
		for (int i = 0; i < unresolvedProperties.Length; i++)
		{
			if (filter == null || filter(unresolvedProperties[i]))
			{
				yield return resolvedProperties[i];
			}
		}
	}

	public override IEnumerable<IMethod> GetAccessors(Predicate<IUnresolvedMethod> filter, GetMemberOptions options)
	{
		for (int i = 0; i < unresolvedProperties.Length; i++)
		{
			if (unresolvedProperties[i].CanGet && (filter == null || filter(unresolvedProperties[i].Getter)))
			{
				yield return resolvedProperties[i].Getter;
			}
			if (unresolvedProperties[i].CanSet && (filter == null || filter(unresolvedProperties[i].Setter)))
			{
				yield return resolvedProperties[i].Setter;
			}
		}
	}

	public override int GetHashCode()
	{
		int num = resolvedProperties.Count;
		foreach (IProperty resolvedProperty in resolvedProperties)
		{
			num *= 31;
			num += resolvedProperty.Name.GetHashCode() ^ resolvedProperty.ReturnType.GetHashCode();
		}
		return num;
	}

	public override bool Equals(IType other)
	{
		if (!(other is AnonymousType anonymousType) || resolvedProperties.Count != anonymousType.resolvedProperties.Count)
		{
			return false;
		}
		for (int i = 0; i < resolvedProperties.Count; i++)
		{
			IProperty property = resolvedProperties[i];
			IProperty property2 = anonymousType.resolvedProperties[i];
			if (property.Name != property2.Name || !property.ReturnType.Equals(property2.ReturnType))
			{
				return false;
			}
		}
		return true;
	}
}
