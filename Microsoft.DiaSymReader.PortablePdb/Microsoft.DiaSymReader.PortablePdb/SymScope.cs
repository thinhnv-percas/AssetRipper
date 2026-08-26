using System.Collections.Immutable;
using System.Runtime.InteropServices;

namespace Microsoft.DiaSymReader.PortablePdb;

[ComVisible(false)]
public sealed class SymScope : ISymUnmanagedScope2, ISymUnmanagedScope
{
	internal readonly ScopeData _data;

	internal SymScope(ScopeData data)
	{
		_data = data;
	}

	public int GetChildren(int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ISymUnmanagedScope[] children)
	{
		ImmutableArray<ChildScopeData> children2 = _data.GetChildren();
		int num = 0;
		foreach (ChildScopeData item in children2)
		{
			if (num >= bufferLength)
			{
				break;
			}
			children[num++] = new SymScope(item);
		}
		count = ((bufferLength == 0) ? children2.Length : num);
		return 0;
	}

	public int GetConstantCount(out int count)
	{
		return GetConstants(0, out count, null);
	}

	public int GetConstants(int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ISymUnmanagedConstant[] constants)
	{
		return _data.GetConstants(bufferLength, out count, constants);
	}

	public int GetLocalCount(out int count)
	{
		return GetLocals(0, out count, null);
	}

	public int GetLocals(int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ISymUnmanagedVariable[] locals)
	{
		return _data.GetLocals(bufferLength, out count, locals);
	}

	public int GetMethod([MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedMethod method)
	{
		method = _data.SymMethod;
		return 0;
	}

	public int GetParent([MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedScope scope)
	{
		ScopeData parent = _data.Parent;
		scope = ((parent != null) ? new SymScope(parent) : null);
		return 0;
	}

	public int GetStartOffset(out int offset)
	{
		offset = _data.StartOffset;
		return 0;
	}

	public int GetEndOffset(out int offset)
	{
		offset = _data.EndOffset;
		return 0;
	}

	public int GetNamespaces(int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ISymUnmanagedNamespace[] namespaces)
	{
		count = 0;
		return 0;
	}
}
