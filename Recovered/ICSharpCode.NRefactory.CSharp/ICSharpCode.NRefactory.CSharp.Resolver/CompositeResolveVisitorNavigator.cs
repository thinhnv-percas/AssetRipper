using ICSharpCode.NRefactory.Semantics;
using ICSharpCode.NRefactory.TypeSystem;
using System;

namespace ICSharpCode.NRefactory.CSharp.Resolver
{
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
			int num = 0;
			while (true)
			{
				if (num < navigators.Length)
				{
					if (navigators[num] == null)
					{
						break;
					}
					num++;
					continue;
				}
				return;
			}
			throw new ArgumentException("Array must not contain nulls.");
		}

		public ResolveVisitorNavigationMode Scan(AstNode node)
		{
			bool flag = false;
			IResolveVisitorNavigator[] array = navigators;
			for (int i = 0; i < array.Length; i++)
			{
				ResolveVisitorNavigationMode resolveVisitorNavigationMode = array[i].Scan(node);
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
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Resolved(node, result);
			}
		}

		public void ProcessConversion(Expression expression, ResolveResult result, Conversion conversion, IType targetType)
		{
			IResolveVisitorNavigator[] array = navigators;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].ProcessConversion(expression, result, conversion, targetType);
			}
		}
	}
}
