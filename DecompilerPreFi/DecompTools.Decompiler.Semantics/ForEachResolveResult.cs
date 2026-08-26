using System;
using DecompTools.Decompiler.TypeSystem;

namespace DecompTools.Decompiler.Semantics;

public class ForEachResolveResult : ResolveResult
{
	public readonly ResolveResult GetEnumeratorCall;

	public readonly IType CollectionType;

	public readonly IType EnumeratorType;

	public readonly IType ElementType;

	public readonly IProperty CurrentProperty;

	public readonly IMethod MoveNextMethod;

	public ForEachResolveResult(ResolveResult getEnumeratorCall, IType collectionType, IType enumeratorType, IType elementType, IProperty currentProperty, IMethod moveNextMethod, IType voidType)
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
		GetEnumeratorCall = getEnumeratorCall;
		CollectionType = collectionType;
		EnumeratorType = enumeratorType;
		ElementType = elementType;
		CurrentProperty = currentProperty;
		MoveNextMethod = moveNextMethod;
	}
}
