using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.Semantics;

public class OperatorResolveResult : ResolveResult
{
	private readonly ExpressionType operatorType;

	private readonly IMethod userDefinedOperatorMethod;

	private readonly IList<ResolveResult> operands;

	private readonly bool isLiftedOperator;

	public ExpressionType OperatorType
	{
		get
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000a: Unknown result type (might be due to invalid IL or missing references)
			return operatorType;
		}
	}

	public IList<ResolveResult> Operands => operands;

	public IMethod UserDefinedOperatorMethod => userDefinedOperatorMethod;

	public bool IsLiftedOperator => isLiftedOperator;

	public OperatorResolveResult(IType resultType, ExpressionType operatorType, params ResolveResult[] operands)
		: base(resultType)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		if (operands == null)
		{
			throw new ArgumentNullException("operands");
		}
		this.operatorType = operatorType;
		this.operands = operands;
	}

	public OperatorResolveResult(IType resultType, ExpressionType operatorType, IMethod userDefinedOperatorMethod, bool isLiftedOperator, IList<ResolveResult> operands)
		: base(resultType)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		if (operands == null)
		{
			throw new ArgumentNullException("operands");
		}
		this.operatorType = operatorType;
		this.userDefinedOperatorMethod = userDefinedOperatorMethod;
		this.isLiftedOperator = isLiftedOperator;
		this.operands = operands;
	}

	public override IEnumerable<ResolveResult> GetChildResults()
	{
		return operands;
	}
}
