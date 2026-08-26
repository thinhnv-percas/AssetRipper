using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation
{
	[Serializable]
	public sealed class DefaultUnresolvedParameter : IUnresolvedParameter, IFreezable, ISupportsInterning
	{
		private sealed class ResolvedParameterWithDefaultValue : IParameter, IVariable, ISymbol
		{
			private readonly IConstantValue defaultValue;

			private readonly ITypeResolveContext context;

			private ResolveResult resolvedDefaultValue;

			SymbolKind ISymbol.SymbolKind => SymbolKind.Parameter;

			public IParameterizedMember Owner => context.CurrentMember as IParameterizedMember;

			public IType Type
			{
				get;
				internal set;
			}

			public string Name
			{
				get;
				internal set;
			}

			public DomRegion Region
			{
				get;
				internal set;
			}

			public IList<IAttribute> Attributes
			{
				get;
				internal set;
			}

			public bool IsRef
			{
				get;
				internal set;
			}

			public bool IsOut
			{
				get;
				internal set;
			}

			public bool IsParams
			{
				get;
				internal set;
			}

			public bool IsOptional => true;

			bool IVariable.IsConst => false;

			public object ConstantValue
			{
				get
				{
					ResolveResult resolveResult = LazyInit.VolatileRead(ref resolvedDefaultValue);
					if (resolveResult == null)
					{
						resolveResult = defaultValue.Resolve(context);
						LazyInit.GetOrSet(ref resolvedDefaultValue, resolveResult);
					}
					return resolveResult.ConstantValue;
				}
			}

			public ResolvedParameterWithDefaultValue(IConstantValue defaultValue, ITypeResolveContext context)
			{
				this.defaultValue = defaultValue;
				this.context = context;
			}

			public override string ToString()
			{
				return DefaultParameter.ToString(this);
			}

			public ISymbolReference ToReference()
			{
				if (Owner == null)
				{
					return new ParameterReference(Type.ToTypeReference(), Name, Region, IsRef, IsOut, IsParams, isOptional: true, ConstantValue);
				}
				return new OwnedParameterReference(Owner.ToReference(), Owner.Parameters.IndexOf(this));
			}
		}

		private string name = string.Empty;

		private ITypeReference type = SpecialType.UnknownType;

		private IList<IUnresolvedAttribute> attributes;

		private IConstantValue defaultValue;

		private DomRegion region;

		private byte flags;

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
				FreezableHelper.ThrowIfFrozen(this);
				name = value;
			}
		}

		public ITypeReference Type
		{
			get
			{
				return type;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				FreezableHelper.ThrowIfFrozen(this);
				type = value;
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

		public IConstantValue DefaultValue
		{
			get
			{
				return defaultValue;
			}
			set
			{
				FreezableHelper.ThrowIfFrozen(this);
				defaultValue = value;
			}
		}

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

		public bool IsFrozen => HasFlag(1);

		public bool IsRef
		{
			get
			{
				return HasFlag(2);
			}
			set
			{
				SetFlag(2, value);
			}
		}

		public bool IsOut
		{
			get
			{
				return HasFlag(4);
			}
			set
			{
				SetFlag(4, value);
			}
		}

		public bool IsParams
		{
			get
			{
				return HasFlag(8);
			}
			set
			{
				SetFlag(8, value);
			}
		}

		public bool IsOptional => DefaultValue != null;

		public DefaultUnresolvedParameter()
		{
		}

		public DefaultUnresolvedParameter(ITypeReference type, string name)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			this.type = type;
			this.name = name;
		}

		private void FreezeInternal()
		{
			attributes = FreezableHelper.FreezeListAndElements(attributes);
			FreezableHelper.Freeze(defaultValue);
		}

		private bool HasFlag(byte flag)
		{
			return (flags & flag) != 0;
		}

		private void SetFlag(byte flag, bool value)
		{
			FreezableHelper.ThrowIfFrozen(this);
			if (value)
			{
				flags |= flag;
			}
			else
			{
				flags &= (byte)(~flag);
			}
		}

		public void Freeze()
		{
			if (!IsFrozen)
			{
				FreezeInternal();
				flags |= 1;
			}
		}

		int ISupportsInterning.GetHashCodeForInterning()
		{
			int num = 0x1D48D7 ^ (flags & -2);
			num *= 31;
			num += type.GetHashCode();
			num *= 31;
			num += name.GetHashCode();
			if (attributes != null)
			{
				foreach (IUnresolvedAttribute attribute in attributes)
				{
					num ^= attribute.GetHashCode();
				}
			}
			if (defaultValue != null)
			{
				num ^= defaultValue.GetHashCode();
			}
			return num;
		}

		bool ISupportsInterning.EqualsForInterning(ISupportsInterning other)
		{
			DefaultUnresolvedParameter defaultUnresolvedParameter = other as DefaultUnresolvedParameter;
			if (defaultUnresolvedParameter != null && type == defaultUnresolvedParameter.type && name == defaultUnresolvedParameter.name && defaultValue == defaultUnresolvedParameter.defaultValue && region == defaultUnresolvedParameter.region && (flags & -2) == (defaultUnresolvedParameter.flags & -2))
			{
				return ListEquals(attributes, defaultUnresolvedParameter.attributes);
			}
			return false;
		}

		private static bool ListEquals(IList<IUnresolvedAttribute> list1, IList<IUnresolvedAttribute> list2)
		{
			return (list1 ?? EmptyList<IUnresolvedAttribute>.Instance).SequenceEqual(list2 ?? EmptyList<IUnresolvedAttribute>.Instance);
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (IsRef)
			{
				stringBuilder.Append("ref ");
			}
			if (IsOut)
			{
				stringBuilder.Append("out ");
			}
			if (IsParams)
			{
				stringBuilder.Append("params ");
			}
			stringBuilder.Append(name);
			stringBuilder.Append(':');
			stringBuilder.Append(type.ToString());
			if (defaultValue != null)
			{
				stringBuilder.Append(" = ");
				stringBuilder.Append(defaultValue.ToString());
			}
			return stringBuilder.ToString();
		}

		private static bool IsOptionalAttribute(IType attributeType)
		{
			if (attributeType.Name == "OptionalAttribute")
			{
				return attributeType.Namespace == "System.Runtime.InteropServices";
			}
			return false;
		}

		public IParameter CreateResolvedParameter(ITypeResolveContext context)
		{
			Freeze();
			if (defaultValue != null)
			{
				return new ResolvedParameterWithDefaultValue(defaultValue, context)
				{
					Type = type.Resolve(context),
					Name = name,
					Region = region,
					Attributes = attributes.CreateResolvedAttributes(context),
					IsRef = IsRef,
					IsOut = IsOut,
					IsParams = IsParams
				};
			}
			IParameterizedMember owner = context.CurrentMember as IParameterizedMember;
			IList<IAttribute> list = attributes.CreateResolvedAttributes(context);
			bool isOptional = list?.Any((IAttribute a) => IsOptionalAttribute(a.AttributeType)) ?? false;
			return new DefaultParameter(type.Resolve(context), name, owner, region, list, IsRef, IsOut, IsParams, isOptional);
		}
	}
}
