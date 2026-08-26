using ICSharpCode.NRefactory.CSharp.Resolver;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using System;
using System.Collections.Generic;

namespace ICSharpCode.NRefactory.CSharp.TypeSystem.ConstantValues
{
	[Serializable]
	public sealed class ConstantMemberReference : ConstantExpression
	{
		private readonly ITypeReference targetType;

		private readonly ConstantExpression targetExpression;

		private readonly string memberName;

		private readonly IList<ITypeReference> typeArguments;

		public ConstantMemberReference(ITypeReference targetType, string memberName, IList<ITypeReference> typeArguments = null)
		{
			if (targetType == null)
			{
				throw new ArgumentNullException("targetType");
			}
			if (memberName == null)
			{
				throw new ArgumentNullException("memberName");
			}
			this.targetType = targetType;
			this.memberName = memberName;
			this.typeArguments = (typeArguments ?? EmptyList<ITypeReference>.Instance);
		}

		public ConstantMemberReference(ConstantExpression targetExpression, string memberName, IList<ITypeReference> typeArguments = null)
		{
			if (targetExpression == null)
			{
				throw new ArgumentNullException("targetExpression");
			}
			if (memberName == null)
			{
				throw new ArgumentNullException("memberName");
			}
			this.targetExpression = targetExpression;
			this.memberName = memberName;
			this.typeArguments = (typeArguments ?? EmptyList<ITypeReference>.Instance);
		}

		public override ResolveResult Resolve(CSharpResolver resolver)
		{
			ResolveResult target = (targetType == null) ? targetExpression.Resolve(resolver) : new TypeResolveResult(targetType.Resolve(resolver.CurrentTypeResolveContext));
			return resolver.ResolveMemberAccess(target, memberName, typeArguments.Resolve(resolver.CurrentTypeResolveContext));
		}
	}
}
