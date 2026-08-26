using System.Collections.Generic;

namespace ICSharpCode.NRefactory.MonoCSharp
{
	public class CompilerCompilationUnit
	{
		public ModuleContainer ModuleCompiled
		{
			get;
			set;
		}

		public LocationsBag LocationsBag
		{
			get;
			set;
		}

		public SpecialsBag SpecialsBag
		{
			get;
			set;
		}

		public IDictionary<string, bool> Conditionals
		{
			get;
			set;
		}

		public object LastYYValue
		{
			get;
			set;
		}
	}
}
