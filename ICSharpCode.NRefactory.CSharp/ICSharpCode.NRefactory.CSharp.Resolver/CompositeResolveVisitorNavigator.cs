using System;
using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;

namespace ICSharpCode.NRefactory.CSharp.Resolver;

public sealed class CompositeResolveVisitorNavigator : IResolveVisitorNavigator
{
	private IResolveVisitorNavigator[] navigators;

	public CompositeResolveVisitorNavigator(params IResolveVisitorNavigator[] navigators)
	{
		if (navigators == null)
		{
			throw new ArgumentNullException("navigators");
		}
		this.navigators = navigators;
		foreach (IResolveVisitorNavigator resolveVisitorNavigator in navigators)
		{
			if (resolveVisitorNavigator == null)
			{
				throw new ArgumentException("Array must not contain nulls.");
			}
		}
	}

	public ResolveVisitorNavigationMode Scan(AstNode node)
	{
		bool flag = false;
		IResolveVisitorNavigator[] array = navigators;
		foreach (IResolveVisitorNavigator resolveVisitorNavigator in array)
		{
			ResolveVisitorNavigationMode resolveVisitorNavigationMode = resolveVisitorNavigator.Scan(node);
			switch (resolveVisitorNavigationMode)
			{
			case ResolveVisitorNavigationMode.Resolve:
				return resolveVisitorNavigationMode;
			case ResolveVisitorNavigationMode.Scan:
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			return ResolveVisitorNavigationMode.Skip;
		}
		return ResolveVisitorNavigationMode.Scan;
	}

	public void Resolved(AstNode node, ResolveResult result)
	{
		IResolveVisitorNavigator[] array = navigators;
		foreach (IResolveVisitorNavigator resolveVisitorNavigator in array)
		{
			resolveVisitorNavigator.Resolved(node, result);
		}
	}

	public void ProcessConversion(Expression expression, ResolveResult result, Conversion conversion, IType targetType)
	{
		IResolveVisitorNavigator[] array = navigators;
		foreach (IResolveVisitorNavigator resolveVisitorNavigator in array)
		{
			resolveVisitorNavigator.ProcessConversion(expression, result, conversion, targetType);
		}
	}
}
