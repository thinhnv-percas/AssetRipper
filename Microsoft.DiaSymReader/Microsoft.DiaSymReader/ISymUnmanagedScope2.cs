using System.Runtime.InteropServices;

namespace Microsoft.DiaSymReader;

[ComImport]
[ComVisible(false)]
[Guid("AE932FBA-3FD8-4dba-8232-30A2309B02DB")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
public interface ISymUnmanagedScope2 : ISymUnmanagedScope
{
	[PreserveSig]
	new int GetMethod([MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedMethod method);

	[PreserveSig]
	new int GetParent([MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedScope scope);

	[PreserveSig]
	new int GetChildren(int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ISymUnmanagedScope[] children);

	[PreserveSig]
	new int GetStartOffset(out int offset);

	[PreserveSig]
	new int GetEndOffset(out int offset);

	[PreserveSig]
	new int GetLocalCount(out int count);

	[PreserveSig]
	new int GetLocals(int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ISymUnmanagedVariable[] locals);

	[PreserveSig]
	new int GetNamespaces(int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ISymUnmanagedNamespace[] namespaces);

	[PreserveSig]
	int GetConstantCount(out int count);

	[PreserveSig]
	int GetConstants(int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ISymUnmanagedConstant[] constants);
}
