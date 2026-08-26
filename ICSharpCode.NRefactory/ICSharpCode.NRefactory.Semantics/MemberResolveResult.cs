using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.Semantics;

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
				constantValue = field.ConstantValue;
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
				constantValue = field.ConstantValue;
			}
		}
	}

	private static IType ComputeType(IMember member)
	{
		switch (member.SymbolKind)
		{
		case SymbolKind.Constructor:
			return member.DeclaringType ?? SpecialType.UnknownType;
		case SymbolKind.Field:
			if (((IField)member).IsFixed)
			{
				return new PointerType(member.ReturnType);
			}
			break;
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

	public override DomRegion GetDefinitionRegion()
	{
		return member.Region;
	}
}
