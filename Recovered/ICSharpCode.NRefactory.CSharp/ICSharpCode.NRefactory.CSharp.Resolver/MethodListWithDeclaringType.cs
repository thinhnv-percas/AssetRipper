using ICSharpCode.NRefactory.TypeSystem;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.CSharp.Resolver
{
	public class MethodListWithDeclaringType : List<IParameterizedMember>
	{
		private readonly IType declaringType;

		public IType DeclaringType => declaringType;

		public MethodListWithDeclaringType(IType declaringType)
		{
			this.declaringType = declaringType;
		}

		public MethodListWithDeclaringType(IType declaringType, IEnumerable<IParameterizedMember> methods)
			: base(methods)
		{
			this.declaringType = declaringType;
		}
	}
}
