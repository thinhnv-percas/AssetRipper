using System.Collections.Generic;

namespace ICSharpCode.NRefactory.MonoCSharp
{
	internal struct TypeAndMethods
	{
		public TypeSpec type;

		public IList<MethodSpec> methods;

		public bool optional;

		public MethodData[] found;

		public MethodSpec[] need_proxy;
	}
}
