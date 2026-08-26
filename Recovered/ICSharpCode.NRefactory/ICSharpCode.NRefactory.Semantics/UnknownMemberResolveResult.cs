using ICSharpCode.NRefactory.TypeSystem;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;

namespace ICSharpCode.NRefactory.Semantics
{
	public class UnknownMemberResolveResult : ResolveResult
	{
		private readonly IType targetType;

		private readonly string memberName;

		private readonly ReadOnlyCollection<IType> typeArguments;

		public IType TargetType => targetType;

		public string MemberName => memberName;

		public ReadOnlyCollection<IType> TypeArguments => typeArguments;

		public override bool IsError => true;

		public UnknownMemberResolveResult(IType targetType, string memberName, IEnumerable<IType> typeArguments)
			: base(SpecialType.UnknownType)
		{
			if (targetType == null)
			{
				throw new ArgumentNullException("targetType");
			}
			this.targetType = targetType;
			this.memberName = memberName;
			this.typeArguments = new ReadOnlyCollection<IType>(typeArguments.ToArray());
		}

		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "[{0} {1}.{2}]", new object[3]
			{
				GetType().Name,
				targetType,
				memberName
			});
		}
	}
}
