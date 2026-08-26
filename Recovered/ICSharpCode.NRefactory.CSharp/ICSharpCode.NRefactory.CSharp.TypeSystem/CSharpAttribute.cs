using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.CSharp.TypeSystem
{
	[Serializable]
	public sealed class CSharpAttribute : IUnresolvedAttribute
	{
		private sealed class CSharpResolvedAttribute : IAttribute
		{
			private readonly CSharpTypeResolveContext context;

			private readonly CSharpAttribute unresolved;

			private readonly IType attributeType;

			private IList<KeyValuePair<IMember, ResolveResult>> namedArguments;

			private ResolveResult ctorInvocation;

			private IList<ResolveResult> positionalArguments;

			DomRegion IAttribute.Region => unresolved.Region;

			IType IAttribute.AttributeType => attributeType;

			IMethod IAttribute.Constructor
			{
				get
				{
					InvocationResolveResult invocationResolveResult = GetCtorInvocation();
					if (invocationResolveResult != null)
					{
						return invocationResolveResult.Member as IMethod;
					}
					return null;
				}
			}

			IList<ResolveResult> IAttribute.PositionalArguments
			{
				get
				{
					IList<ResolveResult> list = LazyInit.VolatileRead(ref positionalArguments);
					if (list != null)
					{
						return list;
					}
					InvocationResolveResult invocationResolveResult = GetCtorInvocation();
					return LazyInit.GetOrSet<IList<ResolveResult>>(newValue: (invocationResolveResult == null) ? EmptyList<ResolveResult>.Instance : invocationResolveResult.GetArgumentsForCall(), target: ref positionalArguments);
				}
			}

			IList<KeyValuePair<IMember, ResolveResult>> IAttribute.NamedArguments
			{
				get
				{
					IList<KeyValuePair<IMember, ResolveResult>> list = LazyInit.VolatileRead(ref namedArguments);
					if (list != null)
					{
						return list;
					}
					list = new List<KeyValuePair<IMember, ResolveResult>>();
					foreach (KeyValuePair<string, IConstantValue> pair in unresolved.namedArguments)
					{
						IMember member = attributeType.GetMembers((IUnresolvedMember m) => (m.SymbolKind == SymbolKind.Field || m.SymbolKind == SymbolKind.Property) && m.Name == pair.Key).FirstOrDefault();
						if (member != null)
						{
							ResolveResult value = pair.Value.Resolve(context);
							list.Add(new KeyValuePair<IMember, ResolveResult>(member, value));
						}
					}
					return LazyInit.GetOrSet(ref namedArguments, list);
				}
			}

			public CSharpResolvedAttribute(CSharpTypeResolveContext context, CSharpAttribute unresolved)
			{
				this.context = context;
				this.unresolved = unresolved;
				attributeType = unresolved.AttributeType.Resolve(context);
			}

			private InvocationResolveResult GetCtorInvocation()
			{
				ResolveResult resolveResult = LazyInit.VolatileRead(ref ctorInvocation);
				if (resolveResult != null)
				{
					return resolveResult as InvocationResolveResult;
				}
				CSharpResolver cSharpResolver = new CSharpResolver(context);
				int num = unresolved.positionalArguments.Count + unresolved.namedCtorArguments.Count;
				ResolveResult[] array = new ResolveResult[num];
				string[] array2 = new string[num];
				int i;
				for (i = 0; i < unresolved.positionalArguments.Count; i++)
				{
					IConstantValue constantValue = unresolved.positionalArguments[i];
					array[i] = constantValue.Resolve(context);
				}
				foreach (KeyValuePair<string, IConstantValue> namedCtorArgument in unresolved.namedCtorArguments)
				{
					array2[i] = namedCtorArgument.Key;
					array[i] = namedCtorArgument.Value.Resolve(context);
					i++;
				}
				resolveResult = cSharpResolver.ResolveObjectCreation(attributeType, array, array2);
				return LazyInit.GetOrSet(ref ctorInvocation, resolveResult) as InvocationResolveResult;
			}
		}

		private ITypeReference attributeType;

		private DomRegion region;

		private IList<IConstantValue> positionalArguments;

		private IList<KeyValuePair<string, IConstantValue>> namedCtorArguments;

		private IList<KeyValuePair<string, IConstantValue>> namedArguments;

		public DomRegion Region => region;

		public ITypeReference AttributeType => attributeType;

		public CSharpAttribute(ITypeReference attributeType, DomRegion region, IList<IConstantValue> positionalArguments, IList<KeyValuePair<string, IConstantValue>> namedCtorArguments, IList<KeyValuePair<string, IConstantValue>> namedArguments)
		{
			if (attributeType == null)
			{
				throw new ArgumentNullException("attributeType");
			}
			this.attributeType = attributeType;
			this.region = region;
			this.positionalArguments = (positionalArguments ?? EmptyList<IConstantValue>.Instance);
			this.namedCtorArguments = (namedCtorArguments ?? EmptyList<KeyValuePair<string, IConstantValue>>.Instance);
			this.namedArguments = (namedArguments ?? EmptyList<KeyValuePair<string, IConstantValue>>.Instance);
		}

		public IAttribute CreateResolvedAttribute(ITypeResolveContext context)
		{
			return new CSharpResolvedAttribute((CSharpTypeResolveContext)context, this);
		}
	}
}
