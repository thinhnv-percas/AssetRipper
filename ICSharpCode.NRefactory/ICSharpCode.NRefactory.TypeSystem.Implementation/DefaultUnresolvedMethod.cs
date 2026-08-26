using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation;

[Serializable]
public class DefaultUnresolvedMethod : AbstractUnresolvedMember, IUnresolvedMethod, IUnresolvedParameterizedMember, IUnresolvedMember, IUnresolvedEntity, INamedElement, IHasAccessibility, IMemberReference, ISymbolReference
{
	private IList<IUnresolvedAttribute> returnTypeAttributes;

	private IList<IUnresolvedTypeParameter> typeParameters;

	private IList<IUnresolvedParameter> parameters;

	private IUnresolvedMember accessorOwner;

	private static readonly IUnresolvedMethod dummyConstructor = CreateDummyConstructor();

	public IList<IUnresolvedAttribute> ReturnTypeAttributes
	{
		get
		{
			if (returnTypeAttributes == null)
			{
				returnTypeAttributes = new List<IUnresolvedAttribute>();
			}
			return returnTypeAttributes;
		}
	}

	public IList<IUnresolvedTypeParameter> TypeParameters
	{
		get
		{
			if (typeParameters == null)
			{
				typeParameters = new List<IUnresolvedTypeParameter>();
			}
			return typeParameters;
		}
	}

	public bool IsExtensionMethod
	{
		get
		{
			return flags[4096];
		}
		set
		{
			ThrowIfFrozen();
			flags[4096] = value;
		}
	}

	public bool IsConstructor => base.SymbolKind == SymbolKind.Constructor;

	public bool IsDestructor => base.SymbolKind == SymbolKind.Destructor;

	public bool IsOperator => base.SymbolKind == SymbolKind.Operator;

	public bool IsPartial
	{
		get
		{
			return flags[8192];
		}
		set
		{
			ThrowIfFrozen();
			flags[8192] = value;
		}
	}

	public bool IsAsync
	{
		get
		{
			return flags[32768];
		}
		set
		{
			ThrowIfFrozen();
			flags[32768] = value;
		}
	}

	public bool HasBody
	{
		get
		{
			return flags[16384];
		}
		set
		{
			ThrowIfFrozen();
			flags[16384] = value;
		}
	}

	[Obsolete]
	public bool IsPartialMethodDeclaration
	{
		get
		{
			if (IsPartial)
			{
				return !HasBody;
			}
			return false;
		}
		set
		{
			if (value)
			{
				IsPartial = true;
				HasBody = false;
			}
			else if (!value && IsPartial && !HasBody)
			{
				IsPartial = false;
			}
		}
	}

	[Obsolete]
	public bool IsPartialMethodImplementation
	{
		get
		{
			if (IsPartial)
			{
				return HasBody;
			}
			return false;
		}
		set
		{
			if (value)
			{
				IsPartial = true;
				HasBody = true;
			}
			else if (!value && IsPartial && HasBody)
			{
				IsPartial = false;
			}
		}
	}

	public IList<IUnresolvedParameter> Parameters
	{
		get
		{
			if (parameters == null)
			{
				parameters = new List<IUnresolvedParameter>();
			}
			return parameters;
		}
	}

	public IUnresolvedMember AccessorOwner
	{
		get
		{
			return accessorOwner;
		}
		set
		{
			ThrowIfFrozen();
			accessorOwner = value;
		}
	}

	public static IUnresolvedMethod DummyConstructor => dummyConstructor;

	protected override void FreezeInternal()
	{
		returnTypeAttributes = FreezableHelper.FreezeListAndElements(returnTypeAttributes);
		typeParameters = FreezableHelper.FreezeListAndElements(typeParameters);
		parameters = FreezableHelper.FreezeListAndElements(parameters);
		base.FreezeInternal();
	}

	public override object Clone()
	{
		DefaultUnresolvedMethod defaultUnresolvedMethod = (DefaultUnresolvedMethod)base.Clone();
		if (returnTypeAttributes != null)
		{
			defaultUnresolvedMethod.returnTypeAttributes = new List<IUnresolvedAttribute>(returnTypeAttributes);
		}
		if (typeParameters != null)
		{
			defaultUnresolvedMethod.typeParameters = new List<IUnresolvedTypeParameter>(typeParameters);
		}
		if (parameters != null)
		{
			defaultUnresolvedMethod.parameters = new List<IUnresolvedParameter>(parameters);
		}
		return defaultUnresolvedMethod;
	}

	public override void ApplyInterningProvider(InterningProvider provider)
	{
		base.ApplyInterningProvider(provider);
		if (provider != null)
		{
			returnTypeAttributes = provider.InternList(returnTypeAttributes);
			typeParameters = provider.InternList(typeParameters);
			parameters = provider.InternList(parameters);
		}
	}

	public DefaultUnresolvedMethod()
	{
		base.SymbolKind = SymbolKind.Method;
	}

	public DefaultUnresolvedMethod(IUnresolvedTypeDefinition declaringType, string name)
	{
		base.SymbolKind = SymbolKind.Method;
		base.DeclaringTypeDefinition = declaringType;
		base.Name = name;
		if (declaringType != null)
		{
			base.UnresolvedFile = declaringType.UnresolvedFile;
		}
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("[");
		stringBuilder.Append(base.SymbolKind.ToString());
		stringBuilder.Append(' ');
		if (base.DeclaringTypeDefinition != null)
		{
			stringBuilder.Append(base.DeclaringTypeDefinition.Name);
			stringBuilder.Append('.');
		}
		stringBuilder.Append(base.Name);
		stringBuilder.Append('(');
		stringBuilder.Append(string.Join(", ", Parameters));
		stringBuilder.Append("):");
		stringBuilder.Append(base.ReturnType.ToString());
		stringBuilder.Append(']');
		return stringBuilder.ToString();
	}

	public override IMember CreateResolved(ITypeResolveContext context)
	{
		return new DefaultResolvedMethod(this, context);
	}

	public override IMember Resolve(ITypeResolveContext context)
	{
		if (accessorOwner != null)
		{
			IMember member = accessorOwner.Resolve(context);
			if (member != null)
			{
				if (member is IProperty property)
				{
					if (property.CanGet && property.Getter.Name == base.Name)
					{
						return property.Getter;
					}
					if (property.CanSet && property.Setter.Name == base.Name)
					{
						return property.Setter;
					}
				}
				if (member is IEvent obj)
				{
					if (obj.CanAdd && obj.AddAccessor.Name == base.Name)
					{
						return obj.AddAccessor;
					}
					if (obj.CanRemove && obj.RemoveAccessor.Name == base.Name)
					{
						return obj.RemoveAccessor;
					}
					if (obj.CanInvoke && obj.InvokeAccessor.Name == base.Name)
					{
						return obj.InvokeAccessor;
					}
				}
			}
			return null;
		}
		ITypeReference explicitInterfaceTypeReference = null;
		if (base.IsExplicitInterfaceImplementation && base.ExplicitInterfaceImplementations.Count == 1)
		{
			explicitInterfaceTypeReference = base.ExplicitInterfaceImplementations[0].DeclaringTypeReference;
		}
		return AbstractUnresolvedMember.Resolve(AbstractUnresolvedMember.ExtendContextForType(context, base.DeclaringTypeDefinition), base.SymbolKind, base.Name, explicitInterfaceTypeReference, TypeParameters.Select((IUnresolvedTypeParameter tp) => tp.Name).ToList(), Parameters.Select((IUnresolvedParameter p) => p.Type).ToList());
	}

	IMethod IUnresolvedMethod.Resolve(ITypeResolveContext context)
	{
		return (IMethod)Resolve(context);
	}

	public static DefaultUnresolvedMethod CreateDefaultConstructor(IUnresolvedTypeDefinition typeDefinition)
	{
		if (typeDefinition == null)
		{
			throw new ArgumentNullException("typeDefinition");
		}
		DomRegion region = typeDefinition.Region;
		region = new DomRegion(region.FileName, region.BeginLine, region.BeginColumn);
		return new DefaultUnresolvedMethod(typeDefinition, ".ctor")
		{
			SymbolKind = SymbolKind.Constructor,
			Accessibility = (typeDefinition.IsAbstract ? Accessibility.Protected : Accessibility.Public),
			IsSynthetic = true,
			HasBody = true,
			Region = region,
			BodyRegion = region,
			ReturnType = KnownTypeReference.Void
		};
	}

	private static IUnresolvedMethod CreateDummyConstructor()
	{
		DefaultUnresolvedMethod defaultUnresolvedMethod = new DefaultUnresolvedMethod
		{
			SymbolKind = SymbolKind.Constructor,
			Name = ".ctor",
			Accessibility = Accessibility.Public,
			IsSynthetic = true,
			ReturnType = KnownTypeReference.Void
		};
		defaultUnresolvedMethod.Freeze();
		return defaultUnresolvedMethod;
	}
}
