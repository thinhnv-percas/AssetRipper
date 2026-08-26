using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.Semantics;

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
		this.typeArguments = new ReadOnlyCollection<IType>(Enumerable.ToArray<IType>(typeArguments));
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "[{0} {1}.{2}]", GetType().Name, targetType, memberName);
	}
}
