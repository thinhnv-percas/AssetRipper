using System.Runtime.InteropServices;

namespace Microsoft.DiaSymReader;

[ComImport]
[Guid("B62B923C-B500-3158-A543-24F307A8B7E1")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[ComVisible(false)]
public interface ISymUnmanagedMethod
{
	[PreserveSig]
	int GetToken(out int methodToken);

	[PreserveSig]
	int GetSequencePointCount(out int count);

	[PreserveSig]
	int GetRootScope([MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedScope scope);

	[PreserveSig]
	int GetScopeFromOffset(int offset, [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedScope scope);

	[PreserveSig]
	int GetOffset(ISymUnmanagedDocument document, int line, int column, out int offset);

	[PreserveSig]
	int GetRanges(ISymUnmanagedDocument document, int line, int column, int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] int[] ranges);

	[PreserveSig]
	int GetParameters(int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ISymUnmanagedVariable[] parameters);

	[PreserveSig]
	int GetNamespace([MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedNamespace @namespace);

	[PreserveSig]
	int GetSourceStartEnd(ISymUnmanagedDocument[] documents, [In][Out][MarshalAs(UnmanagedType.LPArray)] int[] lines, [In][Out][MarshalAs(UnmanagedType.LPArray)] int[] columns, [MarshalAs(UnmanagedType.Bool)] out bool defined);

	[PreserveSig]
	int GetSequencePoints(int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] offsets, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ISymUnmanagedDocument[] documents, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] startLines, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] startColumns, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] endLines, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] endColumns);
}
