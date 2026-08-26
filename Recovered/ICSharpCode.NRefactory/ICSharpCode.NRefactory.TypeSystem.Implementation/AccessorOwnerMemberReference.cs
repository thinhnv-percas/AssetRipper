using System;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation
{
	[Serializable]
	internal sealed class AccessorOwnerMemberReference : IMemberReference, ISymbolReference
	{
		private readonly IMemberReference accessorReference;

		public ITypeReference DeclaringTypeReference => accessorReference.DeclaringTypeReference;

		public AccessorOwnerMemberReference(IMemberReference accessorReference)
		{
			if (accessorReference == null)
			{
				throw new ArgumentNullException("accessorReference");
			}
			this.accessorReference = accessorReference;
		}

		public IMember Resolve(ITypeResolveContext context)
		{
			return (accessorReference.Resolve(context) as IMethod)?.AccessorOwner;
		}

		ISymbol ISymbolReference.Resolve(ITypeResolveContext context)
		{
			return ((IMemberReference)this).Resolve(context);
		}
	}
}
