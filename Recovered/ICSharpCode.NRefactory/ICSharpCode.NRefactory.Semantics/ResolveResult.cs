using ICSharpCode.NRefactory.TypeSystem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ICSharpCode.NRefactory.Semantics
{
	public class ResolveResult
	{
		private readonly IType type;

		public IType Type => type;

		public virtual bool IsCompileTimeConstant => false;

		public virtual object ConstantValue => null;

		public virtual bool IsError => false;

		public ResolveResult(IType type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			this.type = type;
		}

		public override string ToString()
		{
			return "[" + GetType().Name + " " + type + "]";
		}

		public virtual IEnumerable<ResolveResult> GetChildResults()
		{
			return Enumerable.Empty<ResolveResult>();
		}

		public virtual DomRegion GetDefinitionRegion()
		{
			return DomRegion.Empty;
		}

		public virtual ResolveResult ShallowClone()
		{
			return (ResolveResult)MemberwiseClone();
		}
	}
}
