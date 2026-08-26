using System.Collections.Generic;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.CSharp.Resolver;

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
