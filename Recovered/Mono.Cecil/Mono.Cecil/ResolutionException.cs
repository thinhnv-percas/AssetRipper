using System;

namespace Mono.Cecil
{
	public class ResolutionException : Exception
	{
		private readonly MemberReference member;

		public MemberReference Member => member;

		public IMetadataScope Scope
		{
			get
			{
				TypeReference typeReference = member as TypeReference;
				if (typeReference != null)
				{
					return typeReference.Scope;
				}
				TypeReference declaringType = member.DeclaringType;
				if (declaringType != null)
				{
					return declaringType.Scope;
				}
				throw new NotSupportedException();
			}
		}

		public ResolutionException(MemberReference member)
			: base("Failed to resolve " + member.FullName)
		{
			if (member == null)
			{
				throw new ArgumentNullException("member");
			}
			this.member = member;
		}
	}
}
