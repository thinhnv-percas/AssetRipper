using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation
{
	[Serializable]
	public class DefaultUnresolvedTypeDefinition : AbstractUnresolvedEntity, IUnresolvedTypeDefinition, ITypeReference, IUnresolvedEntity, INamedElement, IHasAccessibility
	{
		private TypeKind kind = TypeKind.Class;

		private string namespaceName;

		private IList<ITypeReference> baseTypes;

		private IList<IUnresolvedTypeParameter> typeParameters;

		private IList<IUnresolvedTypeDefinition> nestedTypes;

		private IList<IUnresolvedMember> members;

		public TypeKind Kind
		{
			get
			{
				return kind;
			}
			set
			{
				ThrowIfFrozen();
				kind = value;
			}
		}

		public bool AddDefaultConstructorIfRequired
		{
			get
			{
				return flags[64];
			}
			set
			{
				ThrowIfFrozen();
				flags[64] = value;
			}
		}

		public bool? HasExtensionMethods
		{
			get
			{
				if (flags[128])
				{
					return true;
				}
				if (flags[256])
				{
					return false;
				}
				return null;
			}
			set
			{
				ThrowIfFrozen();
				flags[128] = (value == true);
				flags[256] = (value == false);
			}
		}

		public bool IsPartial
		{
			get
			{
				return flags[512];
			}
			set
			{
				ThrowIfFrozen();
				flags[512] = value;
			}
		}

		public override string Namespace
		{
			get
			{
				return namespaceName;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				ThrowIfFrozen();
				namespaceName = value;
			}
		}

		public override string ReflectionName => FullTypeName.ReflectionName;

		public FullTypeName FullTypeName
		{
			get
			{
				IUnresolvedTypeDefinition declaringTypeDefinition = base.DeclaringTypeDefinition;
				return declaringTypeDefinition?.FullTypeName.NestedType(base.Name, TypeParameters.Count - declaringTypeDefinition.TypeParameters.Count) ?? ((FullTypeName)new TopLevelTypeName(namespaceName, base.Name, TypeParameters.Count));
			}
		}

		public IList<ITypeReference> BaseTypes
		{
			get
			{
				if (baseTypes == null)
				{
					baseTypes = new List<ITypeReference>();
				}
				return baseTypes;
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

		public IList<IUnresolvedTypeDefinition> NestedTypes
		{
			get
			{
				if (nestedTypes == null)
				{
					nestedTypes = new List<IUnresolvedTypeDefinition>();
				}
				return nestedTypes;
			}
		}

		public IList<IUnresolvedMember> Members
		{
			get
			{
				if (members == null)
				{
					members = new List<IUnresolvedMember>();
				}
				return members;
			}
		}

		public IEnumerable<IUnresolvedMethod> Methods => Members.OfType<IUnresolvedMethod>();

		public IEnumerable<IUnresolvedProperty> Properties => Members.OfType<IUnresolvedProperty>();

		public IEnumerable<IUnresolvedField> Fields => Members.OfType<IUnresolvedField>();

		public IEnumerable<IUnresolvedEvent> Events => Members.OfType<IUnresolvedEvent>();

		public DefaultUnresolvedTypeDefinition()
		{
			base.SymbolKind = SymbolKind.TypeDefinition;
		}

		public DefaultUnresolvedTypeDefinition(string fullName)
		{
			int num = fullName.LastIndexOf('.');
			string text;
			string name;
			if (num > 0)
			{
				text = fullName.Substring(0, num);
				name = fullName.Substring(num + 1);
			}
			else
			{
				text = "";
				name = fullName;
			}
			base.SymbolKind = SymbolKind.TypeDefinition;
			namespaceName = text;
			base.Name = name;
		}

		public DefaultUnresolvedTypeDefinition(string namespaceName, string name)
		{
			base.SymbolKind = SymbolKind.TypeDefinition;
			this.namespaceName = namespaceName;
			base.Name = name;
		}

		public DefaultUnresolvedTypeDefinition(IUnresolvedTypeDefinition declaringTypeDefinition, string name)
		{
			base.SymbolKind = SymbolKind.TypeDefinition;
			base.DeclaringTypeDefinition = declaringTypeDefinition;
			namespaceName = declaringTypeDefinition.Namespace;
			base.Name = name;
			base.UnresolvedFile = declaringTypeDefinition.UnresolvedFile;
		}

		protected override void FreezeInternal()
		{
			base.FreezeInternal();
			baseTypes = FreezableHelper.FreezeList(baseTypes);
			typeParameters = FreezableHelper.FreezeListAndElements(typeParameters);
			nestedTypes = FreezableHelper.FreezeListAndElements(nestedTypes);
			members = FreezableHelper.FreezeListAndElements(members);
		}

		public override object Clone()
		{
			DefaultUnresolvedTypeDefinition defaultUnresolvedTypeDefinition = (DefaultUnresolvedTypeDefinition)base.Clone();
			if (baseTypes != null)
			{
				defaultUnresolvedTypeDefinition.baseTypes = new List<ITypeReference>(baseTypes);
			}
			if (typeParameters != null)
			{
				defaultUnresolvedTypeDefinition.typeParameters = new List<IUnresolvedTypeParameter>(typeParameters);
			}
			if (nestedTypes != null)
			{
				defaultUnresolvedTypeDefinition.nestedTypes = new List<IUnresolvedTypeDefinition>(nestedTypes);
			}
			if (members != null)
			{
				defaultUnresolvedTypeDefinition.members = new List<IUnresolvedMember>(members);
			}
			return defaultUnresolvedTypeDefinition;
		}

		public IType Resolve(ITypeResolveContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}
			if (context.CurrentAssembly == null)
			{
				throw new ArgumentException("An ITypeDefinition cannot be resolved in a context without a current assembly.");
			}
			IType typeDefinition = context.CurrentAssembly.GetTypeDefinition(FullTypeName);
			return typeDefinition ?? new UnknownType(Namespace, base.Name, TypeParameters.Count);
		}

		public virtual ITypeResolveContext CreateResolveContext(ITypeResolveContext parentContext)
		{
			return parentContext;
		}
	}
}
