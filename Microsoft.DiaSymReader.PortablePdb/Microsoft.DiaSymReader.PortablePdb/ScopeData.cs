using System.Collections.Immutable;

namespace Microsoft.DiaSymReader.PortablePdb;

internal abstract class ScopeData
{
	internal readonly SymMethod SymMethod;

	private ImmutableArray<ChildScopeData> _lazyChildren;

	internal abstract int StartOffset { get; }

	internal abstract int EndOffset { get; }

	internal abstract ScopeData Parent { get; }

	internal ScopeData(SymMethod symMethod)
	{
		SymMethod = symMethod;
	}

	internal ImmutableArray<ChildScopeData> GetChildren()
	{
		if (_lazyChildren.IsDefault)
		{
			_lazyChildren = CreateChildren();
		}
		return _lazyChildren;
	}

	public int AdjustEndOffset(int value)
	{
		if (!SymMethod.SymReader.VbSemantics.Value || Parent is RootScopeData)
		{
			return value;
		}
		return value - 1;
	}

	protected abstract ImmutableArray<ChildScopeData> CreateChildren();

	internal abstract int GetConstants(int bufferLength, out int count, ISymUnmanagedConstant[] constants);

	internal abstract int GetLocals(int bufferLength, out int count, ISymUnmanagedVariable[] locals);
}
