using System.Runtime.InteropServices;

namespace Microsoft.DiaSymReader;

[ComImport]
[Guid("48B25ED8-5BAD-41bc-9CEE-CD62FABC74E9")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[ComVisible(false)]
public interface ISymUnmanagedConstant
{
	[PreserveSig]
	int GetName(int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] char[] name);

	[PreserveSig]
	int GetValue(out object value);

	[PreserveSig]
	int GetSignature(int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] byte[] signature);
}
