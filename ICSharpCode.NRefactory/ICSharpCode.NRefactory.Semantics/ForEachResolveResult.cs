using System;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.Semantics;

public class ForEachResolveResult : ResolveResult
{
	public readonly ResolveResult GetEnumeratorCall;

	public readonly IType CollectionType;

	public readonly IType EnumeratorType;

	public readonly IType ElementType;

	public readonly IVariable ElementVariable;

	public readonly IProperty CurrentProperty;

	public readonly IMethod MoveNextMethod;

	public ForEachResolveResult(ResolveResult getEnumeratorCall, IType collectionType, IType enumeratorType, IType elementType, IVariable elementVariable, IProperty currentProperty, IMethod moveNextMethod, IType voidType)
		: base(voidType)
	{
		if (getEnumeratorCall == null)
		{
			throw new ArgumentNullException("getEnumeratorCall");
		}
		if (collectionType == null)
		{
			throw new ArgumentNullException("collectionType");
		}
		if (enumeratorType == null)
		{
			throw new ArgumentNullException("enumeratorType");
		}
		if (elementType == null)
		{
			throw new ArgumentNullException("elementType");
		}
		if (elementVariable == null)
		{
			throw new ArgumentNullException("elementVariable");
		}
		GetEnumeratorCall = getEnumeratorCall;
		CollectionType = collectionType;
		EnumeratorType = enumeratorType;
		ElementType = elementType;
		ElementVariable = elementVariable;
		CurrentProperty = currentProperty;
		MoveNextMethod = moveNextMethod;
	}
}
