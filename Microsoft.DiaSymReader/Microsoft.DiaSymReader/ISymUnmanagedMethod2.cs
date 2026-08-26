using System.Runtime.InteropServices;

namespace Microsoft.DiaSymReader;

[ComImport]
[Guid("5da320c8-9c2c-4e5a-b823-027e0677b359")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[ComVisible(false)]
public interface ISymUnmanagedMethod2 : ISymUnmanagedMethod
{
	[PreserveSig]
	new int GetToken(out int methodToken);

	[PreserveSig]
	new int GetSequencePointCount(out int count);

	[PreserveSig]
	new int GetRootScope([MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedScope scope);

	[PreserveSig]
	new int GetScopeFromOffset(int offset, [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedScope scope);

	[PreserveSig]
	new int GetOffset(ISymUnmanagedDocument document, int line, int column, out int offset);

	[PreserveSig]
	new int GetRanges(ISymUnmanagedDocument document, int line, int column, int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] int[] ranges);

	[PreserveSig]
	new int GetParameters(int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ISymUnmanagedVariable[] parameters);

	[PreserveSig]
	new int GetNamespace([MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedNamespace @namespace);

	[PreserveSig]
	new int GetSourceStartEnd(ISymUnmanagedDocument[] documents, [In][Out][MarshalAs(UnmanagedType.LPArray)] int[] lines, [In][Out][MarshalAs(UnmanagedType.LPArray)] int[] columns, [MarshalAs(UnmanagedType.Bool)] out bool defined);

	[PreserveSig]
	new int GetSequencePoints(int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] offsets, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ISymUnmanagedDocument[] documents, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] startLines, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] startColumns, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] endLines, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] int[] endColumns);

	[PreserveSig]
	int GetLocalSignatureToken(out int localSignatureToken);
}
