using System.Collections.Immutable;
using System.Reflection.Metadata;

namespace Microsoft.DiaSymReader.PortablePdb;

internal sealed class ChildScopeData : ScopeData
{
	private readonly LocalScopeHandle _handle;

	private readonly ScopeData _parent;

	internal override ScopeData Parent => _parent;

	internal override int StartOffset => SymMethod.MetadataReader.GetLocalScope(_handle).StartOffset;

	internal override int EndOffset => AdjustEndOffset(SymMethod.MetadataReader.GetLocalScope(_handle).EndOffset);

	internal ChildScopeData(SymMethod symMethod, ScopeData parent, LocalScopeHandle handle)
		: base(symMethod)
	{
		_handle = handle;
		_parent = parent;
	}

	protected override ImmutableArray<ChildScopeData> CreateChildren()
	{
		ImmutableArray<ChildScopeData>.Builder builder = ImmutableArray.CreateBuilder<ChildScopeData>();
		LocalScopeHandleCollection.ChildrenEnumerator children = SymMethod.MetadataReader.GetLocalScope(_handle).GetChildren();
		while (children.MoveNext())
		{
			builder.Add(new ChildScopeData(SymMethod, this, children.Current));
		}
		return builder.ToImmutable();
	}

	internal override int GetConstants(int bufferLength, out int count, ISymUnmanagedConstant[] constants)
	{
		PortablePdbReader pdbReader = SymMethod.PdbReader;
		LocalConstantHandleCollection localConstants = pdbReader.MetadataReader.GetLocalScope(_handle).GetLocalConstants();
		int num = 0;
		foreach (LocalConstantHandle item in localConstants)
		{
			if (num >= bufferLength)
			{
				break;
			}
			constants[num++] = new SymConstant(pdbReader, item);
		}
		count = ((bufferLength == 0) ? localConstants.Count : num);
		return 0;
	}

	internal override int GetLocals(int bufferLength, out int count, ISymUnmanagedVariable[] locals)
	{
		LocalVariableHandleCollection localVariables = SymMethod.MetadataReader.GetLocalScope(_handle).GetLocalVariables();
		int num = 0;
		foreach (LocalVariableHandle item in localVariables)
		{
			if (num >= bufferLength)
			{
				break;
			}
			locals[num++] = new SymVariable(SymMethod, item);
		}
		count = ((bufferLength == 0) ? localVariables.Count : num);
		return 0;
	}
}
