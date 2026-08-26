using System;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation
{
	[Serializable]
	public sealed class SpecializingMemberReference : IMemberReference, ISymbolReference
	{
		private IMemberReference memberDefinitionReference;

		private IList<ITypeReference> classTypeArgumentReferences;

		private IList<ITypeReference> methodTypeArgumentReferences;

		public ITypeReference DeclaringTypeReference
		{
			get
			{
				if (classTypeArgumentReferences != null)
				{
					return new ParameterizedTypeReference(memberDefinitionReference.DeclaringTypeReference, classTypeArgumentReferences);
				}
				return memberDefinitionReference.DeclaringTypeReference;
			}
		}

		public SpecializingMemberReference(IMemberReference memberDefinitionReference, IList<ITypeReference> classTypeArgumentReferences = null, IList<ITypeReference> methodTypeArgumentReferences = null)
		{
			if (memberDefinitionReference == null)
			{
				throw new ArgumentNullException("memberDefinitionReference");
			}
			this.memberDefinitionReference = memberDefinitionReference;
			this.classTypeArgumentReferences = classTypeArgumentReferences;
			this.methodTypeArgumentReferences = methodTypeArgumentReferences;
		}

		public IMember Resolve(ITypeResolveContext context)
		{
			return memberDefinitionReference.Resolve(context)?.Specialize(new TypeParameterSubstitution((classTypeArgumentReferences != null) ? classTypeArgumentReferences.Resolve(context) : null, (methodTypeArgumentReferences != null) ? methodTypeArgumentReferences.Resolve(context) : null));
		}

		ISymbol ISymbolReference.Resolve(ITypeResolveContext context)
		{
			return Resolve(context);
		}
	}
}
