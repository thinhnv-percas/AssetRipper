using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.Semantics;

public class OperatorResolveResult : ResolveResult
{
	private readonly ExpressionType operatorType;

	private readonly IMethod userDefinedOperatorMethod;

	private readonly IList<ResolveResult> operands;

	private readonly bool isLiftedOperator;

	public ExpressionType OperatorType => operatorType;

	public IList<ResolveResult> Operands => operands;

	public IMethod UserDefinedOperatorMethod => userDefinedOperatorMethod;

	public bool IsLiftedOperator => isLiftedOperator;

	public OperatorResolveResult(IType resultType, ExpressionType operatorType, params ResolveResult[] operands)
		: base(resultType)
	{
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
