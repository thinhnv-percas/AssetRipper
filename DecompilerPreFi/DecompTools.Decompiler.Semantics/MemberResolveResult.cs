using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.Semantics;

public class MemberResolveResult : ResolveResult
{
	private readonly IMember member;

	private readonly bool isConstant;

	private readonly object constantValue;

	private readonly ResolveResult targetResult;

	private readonly bool isVirtualCall;

	public ResolveResult TargetResult => targetResult;

	public IMember Member => member;

	public bool IsVirtualCall => isVirtualCall;

	public override bool IsCompileTimeConstant => isConstant;

	public override object ConstantValue => constantValue;

	public MemberResolveResult(ResolveResult targetResult, IMember member, IType returnTypeOverride = null)
		: base(returnTypeOverride ?? ComputeType(member))
	{
		this.targetResult = targetResult;
		this.member = member;
		ThisResolveResult thisResolveResult = targetResult as ThisResolveResult;
		isVirtualCall = member.IsOverridable && (thisResolveResult == null || !thisResolveResult.CausesNonVirtualInvocation);
		if (member is IField field)
		{
			isConstant = field.IsConst;
			if (isConstant)
			{
				constantValue = field.GetConstantValue();
			}
		}
	}

	public MemberResolveResult(ResolveResult targetResult, IMember member, bool isVirtualCall, IType returnTypeOverride = null)
		: base(returnTypeOverride ?? ComputeType(member))
	{
		this.targetResult = targetResult;
		this.member = member;
		this.isVirtualCall = isVirtualCall;
		if (member is IField field)
		{
			isConstant = field.IsConst;
			if (isConstant)
			{
				constantValue = field.GetConstantValue();
			}
		}
	}

	private static IType ComputeType(IMember member)
	{
		SymbolKind symbolKind = member.SymbolKind;
		if (symbolKind != SymbolKind.Field && symbolKind == SymbolKind.Constructor)
		{
			return member.DeclaringType ?? SpecialType.UnknownType;
		}
		if (member.ReturnType.Kind == TypeKind.ByReference)
		{
			return ((ByReferenceType)member.ReturnType).ElementType;
		}
		return member.ReturnType;
	}

	public MemberResolveResult(ResolveResult targetResult, IMember member, IType returnType, bool isConstant, object constantValue)
		: base(returnType)
	{
		this.targetResult = targetResult;
		this.member = member;
		this.isConstant = isConstant;
		this.constantValue = constantValue;
	}

	public MemberResolveResult(ResolveResult targetResult, IMember member, IType returnType, bool isConstant, object constantValue, bool isVirtualCall)
		: base(returnType)
	{
		this.targetResult = targetResult;
		this.member = member;
		this.isConstant = isConstant;
		this.constantValue = constantValue;
		this.isVirtualCall = isVirtualCall;
	}

	public override IEnumerable<ResolveResult> GetChildResults()
	{
		if (targetResult != null)
		{
			return new ResolveResult[1] { targetResult };
		}
		return Enumerable.Empty<ResolveResult>();
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "[{0} {1}]", GetType().Name, member);
	}
}
