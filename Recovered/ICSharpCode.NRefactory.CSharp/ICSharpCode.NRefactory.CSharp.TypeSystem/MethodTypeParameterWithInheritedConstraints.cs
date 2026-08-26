using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.NRefactory.TypeSystem.Implementation;
using ICSharpCode.NRefactory.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.CSharp.TypeSystem
{
	[Serializable]
	public sealed class MethodTypeParameterWithInheritedConstraints : DefaultUnresolvedTypeParameter
	{
		private sealed class ResolvedMethodTypeParameterWithInheritedConstraints : AbstractTypeParameter
		{
			private volatile ITypeParameter baseTypeParameter;

			public override bool HasValueTypeConstraint => GetBaseTypeParameter()?.HasValueTypeConstraint ?? false;

			public override bool HasReferenceTypeConstraint => GetBaseTypeParameter()?.HasReferenceTypeConstraint ?? false;

			public override bool HasDefaultConstructorConstraint => GetBaseTypeParameter()?.HasDefaultConstructorConstraint ?? false;

			public override IEnumerable<IType> DirectBaseTypes
			{
				get
				{
					ITypeParameter typeParameter = GetBaseTypeParameter();
					if (typeParameter != null)
					{
						IMethod method = (IMethod)base.Owner;
						TypeParameterSubstitution substitution = new TypeParameterSubstitution(null, new ProjectedList<ITypeParameter, IType>(method.TypeParameters, (ITypeParameter t) => t));
						return from t in typeParameter.DirectBaseTypes
							select t.AcceptVisitor(substitution);
					}
					return EmptyList<IType>.Instance;
				}
			}

			public ResolvedMethodTypeParameterWithInheritedConstraints(MethodTypeParameterWithInheritedConstraints unresolved, ITypeResolveContext context)
				: base(context.CurrentMember, unresolved.Index, unresolved.Name, unresolved.Variance, unresolved.Attributes.CreateResolvedAttributes(context), unresolved.Region)
			{
			}

			private ITypeParameter GetBaseTypeParameter()
			{
				ITypeParameter typeParameter = baseTypeParameter;
				if (typeParameter == null)
				{
					typeParameter = (baseTypeParameter = ResolveBaseTypeParameter((IMethod)base.Owner, base.Index));
				}
				return typeParameter;
			}
		}

		public MethodTypeParameterWithInheritedConstraints(int index, string name)
			: base(SymbolKind.Method, index, name)
		{
		}

		private static ITypeParameter ResolveBaseTypeParameter(IMethod parentMethod, int index)
		{
			IMethod method = null;
			if (parentMethod.IsOverride)
			{
				foreach (IMethod item in InheritanceHelper.GetBaseMembers(parentMethod, includeImplementedInterfaces: false).OfType<IMethod>())
				{
					if (!item.IsOverride)
					{
						method = item;
						break;
					}
				}
			}
			else if (parentMethod.IsExplicitInterfaceImplementation && parentMethod.ImplementedInterfaceMembers.Count == 1)
			{
				method = (parentMethod.ImplementedInterfaceMembers[0] as IMethod);
			}
			if (method != null && index < method.TypeParameters.Count)
			{
				return method.TypeParameters[index];
			}
			return null;
		}

		public override ITypeParameter CreateResolvedTypeParameter(ITypeResolveContext context)
		{
			if (context.CurrentMember is IMethod)
			{
				return new ResolvedMethodTypeParameterWithInheritedConstraints(this, context);
			}
			return base.CreateResolvedTypeParameter(context);
		}
	}
}
