using System.Runtime.InteropServices;

namespace Microsoft.DiaSymReader;

[ComImport]
[Guid("85E891DA-A631-4c76-ACA2-A44A39C46B8C")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[ComVisible(false)]
public interface ISymEncUnmanagedMethod
{
	[PreserveSig]
	int GetFileNameFromOffset(int offset, int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] char[] name);

	[PreserveSig]
	int GetLineFromOffset(int offset, out int startLine, out int startColumn, out int endLine, out int endColumn, out int sequencePointOffset);

	[PreserveSig]
	int GetDocumentsForMethodCount(out int count);

	[PreserveSig]
	int GetDocumentsForMethod(int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ISymUnmanagedDocument[] documents);

	[PreserveSig]
	int GetSourceExtentInDocument(ISymUnmanagedDocument document, out int startLine, out int endLine);
}
