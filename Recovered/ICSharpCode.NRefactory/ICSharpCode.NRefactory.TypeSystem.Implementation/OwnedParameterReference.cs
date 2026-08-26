using System;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation
{
	internal sealed class OwnedParameterReference : ISymbolReference
	{
		private readonly IMemberReference memberReference;

		private readonly int index;

		public OwnedParameterReference(IMemberReference member, int index)
		{
			if (member == null)
			{
				throw new ArgumentNullException("member");
			}
			memberReference = member;
			this.index = index;
		}

		public ISymbol Resolve(ITypeResolveContext context)
		{
			IParameterizedMember parameterizedMember = memberReference.Resolve(context) as IParameterizedMember;
			if (parameterizedMember != null && index >= 0 && index < parameterizedMember.Parameters.Count)
			{
				return parameterizedMember.Parameters[index];
			}
			return null;
		}
	}
}
