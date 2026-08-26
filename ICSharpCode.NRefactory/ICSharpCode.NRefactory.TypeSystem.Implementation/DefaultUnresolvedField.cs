using System;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation;

[Serializable]
public class DefaultUnresolvedField : AbstractUnresolvedMember, IUnresolvedField, IUnresolvedMember, IUnresolvedEntity, INamedElement, IHasAccessibility, IMemberReference, ISymbolReference
{
	private IConstantValue constantValue;

	public bool IsConst
	{
		get
		{
			if (constantValue != null)
			{
				return !IsFixed;
			}
			return false;
		}
	}

	public bool IsReadOnly
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

	public bool IsVolatile
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

	public bool IsFixed
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

	public IConstantValue ConstantValue
	{
		get
		{
			return constantValue;
		}
		set
		{
			ThrowIfFrozen();
			constantValue = value;
		}
	}

	protected override void FreezeInternal()
	{
		FreezableHelper.Freeze(constantValue);
		base.FreezeInternal();
	}

	public DefaultUnresolvedField()
	{
		base.SymbolKind = SymbolKind.Field;
	}

	public DefaultUnresolvedField(IUnresolvedTypeDefinition declaringType, string name)
	{
		base.SymbolKind = SymbolKind.Field;
		base.DeclaringTypeDefinition = declaringType;
		base.Name = name;
		if (declaringType != null)
		{
			base.UnresolvedFile = declaringType.UnresolvedFile;
		}
	}

	public override IMember CreateResolved(ITypeResolveContext context)
	{
		return new DefaultResolvedField(this, context);
	}

	IField IUnresolvedField.Resolve(ITypeResolveContext context)
	{
		return (IField)Resolve(context);
	}
}
