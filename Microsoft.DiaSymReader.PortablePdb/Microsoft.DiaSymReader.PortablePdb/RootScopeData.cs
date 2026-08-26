using System.Collections.Immutable;
using System.Reflection.Metadata;

namespace Microsoft.DiaSymReader.PortablePdb;

internal sealed class RootScopeData : ScopeData
{
	internal override ScopeData Parent => null;

	internal override int StartOffset => 0;

	internal override int EndOffset
	{
		get
		{
			MetadataReader metadataReader = SymMethod.MetadataReader;
			using (LocalScopeHandleCollection.Enumerator enumerator = metadataReader.GetLocalScopes(SymMethod.DebugHandle).GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					LocalScopeHandle current = enumerator.Current;
					return AdjustEndOffset(metadataReader.GetLocalScope(current).EndOffset);
				}
			}
			return 0;
		}
	}

	internal RootScopeData(SymMethod symMethod)
		: base(symMethod)
	{
	}

	protected override ImmutableArray<ChildScopeData> CreateChildren()
	{
		using (LocalScopeHandleCollection.Enumerator enumerator = SymMethod.MetadataReader.GetLocalScopes(SymMethod.DebugHandle).GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				LocalScopeHandle current = enumerator.Current;
				return ImmutableArray.Create(new ChildScopeData(SymMethod, this, current));
			}
		}
		return ImmutableArray<ChildScopeData>.Empty;
	}

	internal override int GetConstants(int bufferLength, out int count, ISymUnmanagedConstant[] constants)
	{
		count = 0;
		return 0;
	}

	internal override int GetLocals(int bufferLength, out int count, ISymUnmanagedVariable[] locals)
	{
		count = 0;
		return 0;
	}
}
