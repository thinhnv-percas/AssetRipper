using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Microsoft.DiaSymReader;

[ComImport]
[Guid("E65C58B7-2948-434D-8A6D-481740A00C16")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[ComVisible(false)]
public interface ISymUnmanagedReader4 : ISymUnmanagedReader3, ISymUnmanagedReader2, ISymUnmanagedReader
{
	[PreserveSig]
	new int GetDocument([MarshalAs(UnmanagedType.LPWStr)] string url, Guid language, Guid languageVendor, Guid documentType, [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedDocument document);

	[PreserveSig]
	new int GetDocuments(int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ISymUnmanagedDocument[] documents);

	[PreserveSig]
	new int GetUserEntryPoint(out int methodToken);

	[PreserveSig]
	new int GetMethod(int methodToken, [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedMethod method);

	[PreserveSig]
	new int GetMethodByVersion(int methodToken, int version, [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedMethod method);

	[PreserveSig]
	new int GetVariables(int methodToken, int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ISymUnmanagedVariable[] variables);

	[PreserveSig]
	new int GetGlobalVariables(int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ISymUnmanagedVariable[] variables);

	[PreserveSig]
	new int GetMethodFromDocumentPosition(ISymUnmanagedDocument document, int line, int column, [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedMethod method);

	[PreserveSig]
	new int GetSymAttribute(int methodToken, [MarshalAs(UnmanagedType.LPWStr)] string name, int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] customDebugInformation);

	[PreserveSig]
	new int GetNamespaces(int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] ISymUnmanagedNamespace[] namespaces);

	[PreserveSig]
	new int Initialize([MarshalAs(UnmanagedType.Interface)] object metadataImporter, [MarshalAs(UnmanagedType.LPWStr)] string fileName, [MarshalAs(UnmanagedType.LPWStr)] string searchPath, IStream stream);

	[PreserveSig]
	new int UpdateSymbolStore([MarshalAs(UnmanagedType.LPWStr)] string fileName, IStream stream);

	[PreserveSig]
	new int ReplaceSymbolStore([MarshalAs(UnmanagedType.LPWStr)] string fileName, IStream stream);

	[PreserveSig]
	new int GetSymbolStoreFileName(int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] char[] name);

	[PreserveSig]
	new int GetMethodsFromDocumentPosition(ISymUnmanagedDocument document, int line, int column, int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] ISymUnmanagedMethod[] methods);

	[PreserveSig]
	new int GetDocumentVersion(ISymUnmanagedDocument document, out int version, [MarshalAs(UnmanagedType.Bool)] out bool isCurrent);

	[PreserveSig]
	new int GetMethodVersion(ISymUnmanagedMethod method, out int version);

	[PreserveSig]
	new int GetMethodByVersionPreRemap(int methodToken, int version, [MarshalAs(UnmanagedType.Interface)] out ISymUnmanagedMethod method);

	[PreserveSig]
	new int GetSymAttributePreRemap(int methodToken, [MarshalAs(UnmanagedType.LPWStr)] string name, int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] customDebugInformation);

	[PreserveSig]
	new int GetMethodsInDocument(ISymUnmanagedDocument document, int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] ISymUnmanagedMethod[] methods);

	[PreserveSig]
	new int GetSymAttributeByVersion(int methodToken, int version, [MarshalAs(UnmanagedType.LPWStr)] string name, int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] customDebugInformation);

	[PreserveSig]
	new int GetSymAttributeByVersionPreRemap(int methodToken, int version, [MarshalAs(UnmanagedType.LPWStr)] string name, int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] byte[] customDebugInformation);

	[PreserveSig]
	int MatchesModule(Guid guid, uint stamp, int age, [MarshalAs(UnmanagedType.Bool)] out bool result);

	[PreserveSig]
	unsafe int GetPortableDebugMetadata(out byte* metadata, out int size);

	[PreserveSig]
	unsafe int GetSourceServerData(out byte* data, out int size);
}
