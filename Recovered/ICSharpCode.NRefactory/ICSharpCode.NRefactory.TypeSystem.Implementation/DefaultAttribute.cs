using ICSharpCode.NRefactory.Semantics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation
{
	public class DefaultAttribute : IAttribute
	{
		private readonly IType attributeType;

		private readonly IList<ResolveResult> positionalArguments;

		private readonly IList<KeyValuePair<IMember, ResolveResult>> namedArguments;

		private readonly DomRegion region;

		private volatile IMethod constructor;

		public IType AttributeType => attributeType;

		public DomRegion Region => region;

		public IMethod Constructor
		{
			get
			{
				IMethod method = constructor;
				if (method == null)
				{
					foreach (IMethod constructor2 in AttributeType.GetConstructors((IUnresolvedMethod m) => m.Parameters.Count == positionalArguments.Count))
					{
						if ((from p in constructor2.Parameters
							select p.Type).SequenceEqual(from a in PositionalArguments
							select a.Type))
						{
							method = constructor2;
							break;
						}
					}
					constructor = method;
				}
				return method;
			}
		}

		public IList<ResolveResult> PositionalArguments => positionalArguments;

		public IList<KeyValuePair<IMember, ResolveResult>> NamedArguments => namedArguments;

		public DefaultAttribute(IType attributeType, IList<ResolveResult> positionalArguments = null, IList<KeyValuePair<IMember, ResolveResult>> namedArguments = null, DomRegion region = default(DomRegion))
		{
			if (attributeType == null)
			{
				throw new ArgumentNullException("attributeType");
			}
			this.attributeType = attributeType;
			this.positionalArguments = (positionalArguments ?? EmptyList<ResolveResult>.Instance);
			this.namedArguments = (namedArguments ?? EmptyList<KeyValuePair<IMember, ResolveResult>>.Instance);
			this.region = region;
		}

		public DefaultAttribute(IMethod constructor, IList<ResolveResult> positionalArguments = null, IList<KeyValuePair<IMember, ResolveResult>> namedArguments = null, DomRegion region = default(DomRegion))
		{
			if (constructor == null)
			{
				throw new ArgumentNullException("constructor");
			}
			this.constructor = constructor;
			attributeType = (constructor.DeclaringType ?? SpecialType.UnknownType);
			this.positionalArguments = (positionalArguments ?? EmptyList<ResolveResult>.Instance);
			this.namedArguments = (namedArguments ?? EmptyList<KeyValuePair<IMember, ResolveResult>>.Instance);
			this.region = region;
			if (this.positionalArguments.Count != constructor.Parameters.Count)
			{
				throw new ArgumentException("Positional argument count must match the constructor's parameter count");
			}
		}
	}
}
