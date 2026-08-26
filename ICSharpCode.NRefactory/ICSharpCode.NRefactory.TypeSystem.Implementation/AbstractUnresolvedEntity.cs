using System;
using System.Collections.Generic;
using System.Text;
using ICSharpCode.NRefactory.Utils;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation;

[Serializable]
public abstract class AbstractUnresolvedEntity : IUnresolvedEntity, INamedElement, IHasAccessibility, IFreezable
{
	[Serializable]
	internal class RareFields
	{
		internal DomRegion region;

		internal DomRegion bodyRegion;

		internal IUnresolvedFile unresolvedFile;

		protected internal virtual void FreezeInternal()
		{
		}

		public virtual void ApplyInterningProvider(InterningProvider provider)
		{
		}

		public virtual object Clone()
		{
			return MemberwiseClone();
		}
	}

	private IUnresolvedTypeDefinition declaringTypeDefinition;

	private string name = string.Empty;

	private IList<IUnresolvedAttribute> attributes;

	internal RareFields rareFields;

	private SymbolKind symbolKind;

	private Accessibility accessibility;

	internal BitVector16 flags;

	internal const ushort FlagFrozen = 1;

	internal const ushort FlagSealed = 2;

	internal const ushort FlagAbstract = 4;

	internal const ushort FlagShadowing = 8;

	internal const ushort FlagSynthetic = 16;

	internal const ushort FlagStatic = 32;

	internal const ushort FlagAddDefaultConstructorIfRequired = 64;

	internal const ushort FlagHasExtensionMethods = 128;

	internal const ushort FlagHasNoExtensionMethods = 256;

	internal const ushort FlagPartialTypeDefinition = 512;

	internal const ushort FlagExplicitInterfaceImplementation = 64;

	internal const ushort FlagVirtual = 128;

	internal const ushort FlagOverride = 256;

	internal const ushort FlagFieldIsReadOnly = 4096;

	internal const ushort FlagFieldIsVolatile = 8192;

	internal const ushort FlagFieldIsFixedSize = 16384;

	internal const ushort FlagExtensionMethod = 4096;

	internal const ushort FlagPartialMethod = 8192;

	internal const ushort FlagHasBody = 16384;

	internal const ushort FlagAsyncMethod = 32768;

	public bool IsFrozen => flags[1];

	public SymbolKind SymbolKind
	{
		get
		{
			return symbolKind;
		}
		set
		{
			ThrowIfFrozen();
			symbolKind = value;
		}
	}

	public DomRegion Region
	{
		get
		{
			if (rareFields == null)
			{
				return DomRegion.Empty;
			}
			return rareFields.region;
		}
		set
		{
			if (value != DomRegion.Empty || rareFields != null)
			{
				WriteRareFields().region = value;
			}
		}
	}

	public DomRegion BodyRegion
	{
		get
		{
			if (rareFields == null)
			{
				return DomRegion.Empty;
			}
			return rareFields.bodyRegion;
		}
		set
		{
			if (value != DomRegion.Empty || rareFields != null)
			{
				WriteRareFields().bodyRegion = value;
			}
		}
	}

	public IUnresolvedFile UnresolvedFile
	{
		get
		{
			if (rareFields == null)
			{
				return null;
			}
			return rareFields.unresolvedFile;
		}
		set
		{
			if (value != null || rareFields != null)
			{
				WriteRareFields().unresolvedFile = value;
			}
		}
	}

	public IUnresolvedTypeDefinition DeclaringTypeDefinition
	{
		get
		{
			return declaringTypeDefinition;
		}
		set
		{
			ThrowIfFrozen();
			declaringTypeDefinition = value;
		}
	}

	public IList<IUnresolvedAttribute> Attributes
	{
		get
		{
			if (attributes == null)
			{
				attributes = new List<IUnresolvedAttribute>();
			}
			return attributes;
		}
	}

	public string Name
	{
		get
		{
			return name;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			ThrowIfFrozen();
			name = value;
		}
	}

	public virtual string FullName
	{
		get
		{
			if (declaringTypeDefinition != null)
			{
				return declaringTypeDefinition.FullName + "." + name;
			}
			if (!string.IsNullOrEmpty(Namespace))
			{
				return Namespace + "." + name;
			}
			return name;
		}
	}

	public virtual string Namespace
	{
		get
		{
			if (declaringTypeDefinition != null)
			{
				return declaringTypeDefinition.Namespace;
			}
			return string.Empty;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public virtual string ReflectionName
	{
		get
		{
			if (declaringTypeDefinition != null)
			{
				return declaringTypeDefinition.ReflectionName + "." + name;
			}
			return name;
		}
	}

	public Accessibility Accessibility
	{
		get
		{
			return accessibility;
		}
		set
		{
			ThrowIfFrozen();
			accessibility = value;
		}
	}

	public bool IsStatic
	{
		get
		{
			return flags[32];
		}
		set
		{
			ThrowIfFrozen();
			flags[32] = value;
		}
	}

	public bool IsAbstract
	{
		get
		{
			return flags[4];
		}
		set
		{
			ThrowIfFrozen();
			flags[4] = value;
		}
	}

	public bool IsSealed
	{
		get
		{
			return flags[2];
		}
		set
		{
			ThrowIfFrozen();
			flags[2] = value;
		}
	}

	public bool IsShadowing
	{
		get
		{
			return flags[8];
		}
		set
		{
			ThrowIfFrozen();
			flags[8] = value;
		}
	}

	public bool IsSynthetic
	{
		get
		{
			return flags[16];
		}
		set
		{
			ThrowIfFrozen();
			flags[16] = value;
		}
	}

	bool IHasAccessibility.IsPrivate => accessibility == Accessibility.Private;

	bool IHasAccessibility.IsPublic => accessibility == Accessibility.Public;

	bool IHasAccessibility.IsProtected => accessibility == Accessibility.Protected;

	bool IHasAccessibility.IsInternal => accessibility == Accessibility.Internal;

	bool IHasAccessibility.IsProtectedOrInternal => accessibility == Accessibility.ProtectedOrInternal;

	bool IHasAccessibility.IsProtectedAndInternal => accessibility == Accessibility.ProtectedAndInternal;

	public void Freeze()
	{
		if (!flags[1])
		{
			FreezeInternal();
			flags[1] = true;
		}
	}

	protected virtual void FreezeInternal()
	{
		attributes = FreezableHelper.FreezeListAndElements(attributes);
		if (rareFields != null)
		{
			rareFields.FreezeInternal();
		}
	}

	public virtual void ApplyInterningProvider(InterningProvider provider)
	{
		if (provider == null)
		{
			throw new ArgumentNullException("provider");
		}
		ThrowIfFrozen();
		name = provider.Intern(name);
		attributes = provider.InternList(attributes);
		if (rareFields != null)
		{
			rareFields.ApplyInterningProvider(provider);
		}
	}

	public virtual object Clone()
	{
		AbstractUnresolvedEntity abstractUnresolvedEntity = (AbstractUnresolvedEntity)MemberwiseClone();
		abstractUnresolvedEntity.flags[1] = false;
		if (attributes != null)
		{
			abstractUnresolvedEntity.attributes = new List<IUnresolvedAttribute>(attributes);
		}
		if (rareFields != null)
		{
			abstractUnresolvedEntity.rareFields = (RareFields)rareFields.Clone();
		}
		return abstractUnresolvedEntity;
	}

	protected void ThrowIfFrozen()
	{
		FreezableHelper.ThrowIfFrozen(this);
	}

	internal virtual RareFields WriteRareFields()
	{
		ThrowIfFrozen();
		if (rareFields == null)
		{
			rareFields = new RareFields();
		}
		return rareFields;
	}

	public override string ToString()
	{
		StringBuilder stringBuilder = new StringBuilder("[");
		stringBuilder.Append(GetType().Name);
		stringBuilder.Append(' ');
		if (DeclaringTypeDefinition != null)
		{
			stringBuilder.Append(DeclaringTypeDefinition.Name);
			stringBuilder.Append('.');
		}
		stringBuilder.Append(Name);
		stringBuilder.Append(']');
		return stringBuilder.ToString();
	}
}
