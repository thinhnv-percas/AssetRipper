using ICSharpCode.NRefactory.TypeSystem;
using System;

namespace ICSharpCode.NRefactory.Semantics
{
	public class TypeOfResolveResult : ResolveResult
	{
		private readonly IType referencedType;

		public IType ReferencedType => referencedType;

		public TypeOfResolveResult(IType systemType, IType referencedType)
			: base(systemType)
		{
			if (referencedType == null)
			{
				throw new ArgumentNullException("referencedType");
			}
			this.referencedType = referencedType;
		}
	}
}
