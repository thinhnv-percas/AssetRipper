using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Microsoft.DiaSymReader;

[ComImport]
[Guid("E502D2DD-8671-4338-8F2A-FC08229628C4")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[ComVisible(false)]
public interface ISymUnmanagedEncUpdate
{
	[PreserveSig]
	int UpdateSymbolStore2(IStream stream, [In][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] SymUnmanagedLineDelta[] lineDeltas, int lineDeltaCount);

	[PreserveSig]
	int GetLocalVariableCount(int methodToken, out int count);

	[PreserveSig]
	int GetLocalVariables(int methodToken, int bufferLength, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ISymUnmanagedVariable[] variables, out int count);

	[PreserveSig]
	int InitializeForEnc();

	[PreserveSig]
	int UpdateMethodLines(int methodToken, [In][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] int[] deltas, int count);
}
