using ICSharpCode.NRefactory.TypeSystem;
using System;

namespace ICSharpCode.NRefactory.Semantics
{
	public class SizeOfResolveResult : ResolveResult
	{
		private readonly IType referencedType;

		private readonly int? constantValue;

		public IType ReferencedType => referencedType;

		public override bool IsCompileTimeConstant => constantValue.HasValue;

		public override object ConstantValue => constantValue;

		public override bool IsError => referencedType.IsReferenceType != false;

		public SizeOfResolveResult(IType int32, IType referencedType, int? constantValue)
			: base(int32)
		{
			if (referencedType == null)
			{
				throw new ArgumentNullException("referencedType");
			}
			this.referencedType = referencedType;
			this.constantValue = constantValue;
		}
	}
}
