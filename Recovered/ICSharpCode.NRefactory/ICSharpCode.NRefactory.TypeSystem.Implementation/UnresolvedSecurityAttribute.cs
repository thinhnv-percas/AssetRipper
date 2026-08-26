using System;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation
{
	[Serializable]
	internal sealed class UnresolvedSecurityAttribute : IUnresolvedAttribute, ISupportsInterning
	{
		private readonly UnresolvedSecurityDeclarationBlob secDecl;

		private readonly int index;

		DomRegion IUnresolvedAttribute.Region => DomRegion.Empty;

		public UnresolvedSecurityAttribute(UnresolvedSecurityDeclarationBlob secDecl, int index)
		{
			this.secDecl = secDecl;
			this.index = index;
		}

		IAttribute IUnresolvedAttribute.CreateResolvedAttribute(ITypeResolveContext context)
		{
			return secDecl.Resolve(context.CurrentAssembly)[index];
		}

		int ISupportsInterning.GetHashCodeForInterning()
		{
			return index ^ secDecl.GetHashCode();
		}

		bool ISupportsInterning.EqualsForInterning(ISupportsInterning other)
		{
			UnresolvedSecurityAttribute unresolvedSecurityAttribute = other as UnresolvedSecurityAttribute;
			if (unresolvedSecurityAttribute != null && index == unresolvedSecurityAttribute.index)
			{
				return secDecl == unresolvedSecurityAttribute.secDecl;
			}
			return false;
		}
	}
}
