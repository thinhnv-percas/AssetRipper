using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Runtime.InteropServices;

namespace Microsoft.DiaSymReader;

[EditorBrowsable(EditorBrowsableState.Never)]
public static class SymUnmanagedExtensions
{
	private const string CdiAttributeName = "MD2";

	public static ISymUnmanagedReader GetReaderFromStream(this ISymUnmanagedBinder binder, Stream stream, object metadataImporter)
	{
		if (binder == null)
		{
			throw new ArgumentNullException("binder");
		}
		InteropUtilities.ThrowExceptionForHR(binder.GetReaderFromStream(metadataImporter, SymUnmanagedStreamFactory.CreateStream(stream), out var reader));
		return reader;
	}

	public static ISymUnmanagedReader GetReaderFromPdbStream(this ISymUnmanagedBinder4 binder, Stream stream, IMetadataImportProvider metadataImportProvider)
	{
		if (binder == null)
		{
			throw new ArgumentNullException("binder");
		}
		InteropUtilities.ThrowExceptionForHR(binder.GetReaderFromPdbStream(metadataImportProvider, SymUnmanagedStreamFactory.CreateStream(stream), out var reader));
		return reader;
	}

	public static string GetName(this ISymUnmanagedConstant constant)
	{
		if (constant == null)
		{
			throw new ArgumentNullException("constant");
		}
		return InteropUtilities.BufferToString(InteropUtilities.GetItems(constant, delegate(ISymUnmanagedConstant a, int b, out int c, char[] d)
		{
			return a.GetName(b, out c, d);
		}));
	}

	public static object GetValue(this ISymUnmanagedConstant constant)
	{
		if (constant == null)
		{
			throw new ArgumentNullException("constant");
		}
		InteropUtilities.ThrowExceptionForHR(constant.GetValue(out var value));
		return value;
	}

	public static byte[] GetSignature(this ISymUnmanagedConstant constant)
	{
		if (constant == null)
		{
			throw new ArgumentNullException("constant");
		}
		return InteropUtilities.NullToEmpty(InteropUtilities.GetItems(constant, delegate(ISymUnmanagedConstant a, int b, out int c, byte[] d)
		{
			return a.GetSignature(b, out c, d);
		}));
	}

	public static string GetName(this ISymUnmanagedDocument document)
	{
		if (document == null)
		{
			throw new ArgumentNullException("document");
		}
		return InteropUtilities.BufferToString(InteropUtilities.GetItems(document, delegate(ISymUnmanagedDocument a, int b, out int c, char[] d)
		{
			return a.GetUrl(b, out c, d);
		}));
	}

	public static byte[] GetChecksum(this ISymUnmanagedDocument document)
	{
		if (document == null)
		{
			throw new ArgumentNullException("document");
		}
		return InteropUtilities.NullToEmpty(InteropUtilities.GetItems(document, delegate(ISymUnmanagedDocument a, int b, out int c, byte[] d)
		{
			return a.GetChecksum(b, out c, d);
		}));
	}

	public static Guid GetLanguage(this ISymUnmanagedDocument document)
	{
		if (document == null)
		{
			throw new ArgumentNullException("document");
		}
		Guid language = default(Guid);
		InteropUtilities.ThrowExceptionForHR(document.GetLanguage(ref language));
		return language;
	}

	public static Guid GetLanguageVendor(this ISymUnmanagedDocument document)
	{
		if (document == null)
		{
			throw new ArgumentNullException("document");
		}
		Guid vendor = default(Guid);
		InteropUtilities.ThrowExceptionForHR(document.GetLanguageVendor(ref vendor));
		return vendor;
	}

	public static Guid GetDocumentType(this ISymUnmanagedDocument document)
	{
		if (document == null)
		{
			throw new ArgumentNullException("document");
		}
		Guid documentType = default(Guid);
		InteropUtilities.ThrowExceptionForHR(document.GetDocumentType(ref documentType));
		return documentType;
	}

	public static Guid GetHashAlgorithm(this ISymUnmanagedDocument document)
	{
		if (document == null)
		{
			throw new ArgumentNullException("document");
		}
		Guid algorithm = default(Guid);
		InteropUtilities.ThrowExceptionForHR(document.GetChecksumAlgorithmId(ref algorithm));
		return algorithm;
	}

	public static ArraySegment<byte> GetEmbeddedSource(this ISymUnmanagedDocument document)
	{
		if (document == null)
		{
			throw new ArgumentNullException("document");
		}
		Marshal.ThrowExceptionForHR(document.GetSourceLength(out var length));
		if (length == 0)
		{
			return default(ArraySegment<byte>);
		}
		if (length < 4)
		{
			throw new InvalidDataException();
		}
		byte[] array = new byte[length];
		Marshal.ThrowExceptionForHR(document.GetSourceRange(0, 0, int.MaxValue, int.MaxValue, length, out var count, array));
		if (count < 4 || count > array.Length)
		{
			throw new InvalidDataException();
		}
		int num = BitConverter.ToInt32(array, 0);
		if (num == 0)
		{
			return new ArraySegment<byte>(array, 4, count - 4);
		}
		byte[] array2 = new byte[num];
		using DeflateStream deflateStream = new DeflateStream(new MemoryStream(array, 4, count - 4), CompressionMode.Decompress);
		int num2 = 0;
		while (true)
		{
			int num3 = deflateStream.Read(array2, num2, array2.Length - num2);
			if (num3 == 0)
			{
				break;
			}
			num2 += num3;
		}
		if (num2 != array2.Length || deflateStream.ReadByte() != -1)
		{
			throw new InvalidDataException();
		}
		return new ArraySegment<byte>(array2);
	}

	public static ISymUnmanagedDocument[] GetDocumentsForMethod(this ISymUnmanagedMethod method)
	{
		if (method == null)
		{
			throw new ArgumentNullException("method");
		}
		return InteropUtilities.NullToEmpty(InteropUtilities.GetItems((ISymEncUnmanagedMethod)method, delegate(ISymEncUnmanagedMethod a, out int b)
		{
			return a.GetDocumentsForMethodCount(out b);
		}, delegate(ISymEncUnmanagedMethod a, int b, out int c, ISymUnmanagedDocument[] d)
		{
			return a.GetDocumentsForMethod(b, out c, d);
		}));
	}

	public static void GetSourceExtentInDocument(this ISymEncUnmanagedMethod method, ISymUnmanagedDocument document, out int startLine, out int endLine)
	{
		if (method == null)
		{
			throw new ArgumentNullException("method");
		}
		InteropUtilities.ThrowExceptionForHR(method.GetSourceExtentInDocument(document, out startLine, out endLine));
	}

	public static int GetToken(this ISymUnmanagedMethod method)
	{
		if (method == null)
		{
			throw new ArgumentNullException("method");
		}
		InteropUtilities.ThrowExceptionForHR(method.GetToken(out var methodToken));
		return methodToken;
	}

	public static int GetLocalSignatureToken(this ISymUnmanagedMethod2 method)
	{
		if (method == null)
		{
			throw new ArgumentNullException("method");
		}
		InteropUtilities.ThrowExceptionForHR(method.GetLocalSignatureToken(out var localSignatureToken));
		return localSignatureToken;
	}

	public static ISymUnmanagedScope GetRootScope(this ISymUnmanagedMethod method)
	{
		if (method == null)
		{
			throw new ArgumentNullException("method");
		}
		InteropUtilities.ThrowExceptionForHR(method.GetRootScope(out var scope));
		return scope;
	}

	public static IEnumerable<SymUnmanagedSequencePoint> GetSequencePoints(this ISymUnmanagedMethod method)
	{
		if (method == null)
		{
			throw new ArgumentNullException("method");
		}
		InteropUtilities.ThrowExceptionForHR(method.GetSequencePointCount(out var count));
		if (count != 0)
		{
			int[] offsets = new int[count];
			ISymUnmanagedDocument[] documents = new ISymUnmanagedDocument[count];
			int[] startLines = new int[count];
			int[] startColumns = new int[count];
			int[] endLines = new int[count];
			int[] endColumns = new int[count];
			InteropUtilities.ThrowExceptionForHR(method.GetSequencePoints(count, out var numRead, offsets, documents, startLines, startColumns, endLines, endColumns));
			InteropUtilities.ValidateItems(numRead, offsets.Length);
			for (int i = 0; i < numRead; i++)
			{
				yield return new SymUnmanagedSequencePoint(offsets[i], documents[i], startLines[i], startColumns[i], endLines[i], endColumns[i]);
			}
		}
	}

	public static ISymUnmanagedAsyncMethod AsAsyncMethod(this ISymUnmanagedMethod method)
	{
		if (!(method is ISymUnmanagedAsyncMethod symUnmanagedAsyncMethod))
		{
			return null;
		}
		InteropUtilities.ThrowExceptionForHR(symUnmanagedAsyncMethod.IsAsyncMethod(out var value));
		if (!value)
		{
			return null;
		}
		return symUnmanagedAsyncMethod;
	}

	public static int GetCatchHandlerILOffset(this ISymUnmanagedAsyncMethod method)
	{
		if (method == null)
		{
			throw new ArgumentNullException("method");
		}
		InteropUtilities.ThrowExceptionForHR(method.HasCatchHandlerILOffset(out var offset));
		if (!offset)
		{
			return -1;
		}
		InteropUtilities.ThrowExceptionForHR(method.GetCatchHandlerILOffset(out var offset2));
		return offset2;
	}

	public static int GetKickoffMethod(this ISymUnmanagedAsyncMethod method)
	{
		if (method == null)
		{
			throw new ArgumentNullException("method");
		}
		InteropUtilities.ThrowExceptionForHR(method.GetKickoffMethod(out var kickoffMethodToken));
		return kickoffMethodToken;
	}

	public static IEnumerable<SymUnmanagedAsyncStepInfo> GetAsyncStepInfos(this ISymUnmanagedAsyncMethod method)
	{
		if (method == null)
		{
			throw new ArgumentNullException("method");
		}
		InteropUtilities.ThrowExceptionForHR(method.GetAsyncStepInfoCount(out var count));
		if (count != 0)
		{
			int[] yieldOffsets = new int[count];
			int[] breakpointOffsets = new int[count];
			int[] breakpointMethods = new int[count];
			InteropUtilities.ThrowExceptionForHR(method.GetAsyncStepInfo(count, out count, yieldOffsets, breakpointOffsets, breakpointMethods));
			InteropUtilities.ValidateItems(count, yieldOffsets.Length);
			InteropUtilities.ValidateItems(count, breakpointOffsets.Length);
			InteropUtilities.ValidateItems(count, breakpointMethods.Length);
			for (int i = 0; i < count; i++)
			{
				yield return new SymUnmanagedAsyncStepInfo(yieldOffsets[i], breakpointOffsets[i], breakpointMethods[i]);
			}
		}
	}

	public static string GetName(this ISymUnmanagedNamespace @namespace)
	{
		if (@namespace == null)
		{
			throw new ArgumentNullException("namespace");
		}
		return InteropUtilities.BufferToString(InteropUtilities.GetItems(@namespace, delegate(ISymUnmanagedNamespace a, int b, out int c, char[] d)
		{
			return a.GetName(b, out c, d);
		}));
	}

	public static void UpdateSymbolStore(this ISymUnmanagedReader reader, Stream stream, string fileName = null)
	{
		if (reader == null)
		{
			throw new ArgumentNullException("reader");
		}
		InteropUtilities.ThrowExceptionForHR(reader.UpdateSymbolStore(fileName, SymUnmanagedStreamFactory.CreateStream(stream)));
	}

	public static void Initialize(this ISymUnmanagedReader3 reader, Stream stream, object metadataImporter, string fileName = null, string searchPath = null)
	{
		if (reader == null)
		{
			throw new ArgumentNullException("reader");
		}
		InteropUtilities.ThrowExceptionForHR(reader.Initialize(metadataImporter, fileName, searchPath, SymUnmanagedStreamFactory.CreateStream(stream)));
	}

	public static byte[] GetCustomDebugInfo(this ISymUnmanagedReader3 reader, int methodToken, int methodVersion)
	{
		if (reader == null)
		{
			throw new ArgumentNullException("reader");
		}
		return InteropUtilities.GetItems(reader, methodToken, methodVersion, delegate(ISymUnmanagedReader3 pReader, int pMethodToken, int pMethodVersion, int pBufferLength, out int pCount, byte[] pCustomDebugInfo)
		{
			return pReader.GetSymAttributeByVersion(pMethodToken, pMethodVersion, "MD2", pBufferLength, out pCount, pCustomDebugInfo);
		});
	}

	public static int GetUserEntryPoint(this ISymUnmanagedReader reader)
	{
		if (reader == null)
		{
			throw new ArgumentNullException("reader");
		}
		int userEntryPoint = reader.GetUserEntryPoint(out var methodToken);
		if (userEntryPoint == -2147467259)
		{
			return 0;
		}
		InteropUtilities.ThrowExceptionForHR(userEntryPoint);
		return methodToken;
	}

	public static ISymUnmanagedDocument GetDocument(this ISymUnmanagedReader reader, string name)
	{
		if (reader == null)
		{
			throw new ArgumentNullException("reader");
		}
		InteropUtilities.ThrowExceptionForHR(reader.GetDocument(name, default(Guid), default(Guid), default(Guid), out var document));
		return document;
	}

	public static ISymUnmanagedDocument[] GetDocuments(this ISymUnmanagedReader reader)
	{
		if (reader == null)
		{
			throw new ArgumentNullException("reader");
		}
		return InteropUtilities.NullToEmpty(InteropUtilities.GetItems(reader, delegate(ISymUnmanagedReader a, int b, out int c, ISymUnmanagedDocument[] d)
		{
			return a.GetDocuments(b, out c, d);
		}));
	}

	public static ISymUnmanagedMethod[] GetMethodsInDocument(this ISymUnmanagedReader reader, ISymUnmanagedDocument symDocument)
	{
		if (reader == null)
		{
			throw new ArgumentNullException("reader");
		}
		return InteropUtilities.NullToEmpty(InteropUtilities.GetItems((ISymUnmanagedReader2)reader, symDocument, delegate(ISymUnmanagedReader2 a, ISymUnmanagedDocument b, int c, out int d, ISymUnmanagedMethod[] e)
		{
			return a.GetMethodsInDocument(b, c, out d, e);
		}));
	}

	public static ISymUnmanagedMethod GetMethod(this ISymUnmanagedReader reader, int methodToken)
	{
		if (reader == null)
		{
			throw new ArgumentNullException("reader");
		}
		int method = reader.GetMethod(methodToken, out var method2);
		InteropUtilities.ThrowExceptionForHR(method);
		if (method < 0)
		{
			return null;
		}
		if (method2 == null)
		{
			throw new InvalidOperationException();
		}
		return method2;
	}

	public static ISymUnmanagedMethod GetMethodByVersion(this ISymUnmanagedReader reader, int methodToken, int methodVersion)
	{
		if (reader == null)
		{
			throw new ArgumentNullException("reader");
		}
		int methodByVersion = reader.GetMethodByVersion(methodToken, methodVersion, out var method);
		InteropUtilities.ThrowExceptionForHR(methodByVersion);
		if (methodByVersion < 0)
		{
			return null;
		}
		if (method == null)
		{
			throw new InvalidOperationException();
		}
		return method;
	}

	public static int GetMethodVersion(this ISymUnmanagedReader reader, ISymUnmanagedMethod method)
	{
		if (reader == null)
		{
			throw new ArgumentNullException("reader");
		}
		InteropUtilities.ThrowExceptionForHR(reader.GetMethodVersion(method, out var version));
		return version;
	}

	public static int GetStartOffset(this ISymUnmanagedScope scope)
	{
		if (scope == null)
		{
			throw new ArgumentNullException("scope");
		}
		InteropUtilities.ThrowExceptionForHR(scope.GetStartOffset(out var offset));
		return offset;
	}

	public static int GetEndOffset(this ISymUnmanagedScope scope)
	{
		if (scope == null)
		{
			throw new ArgumentNullException("scope");
		}
		InteropUtilities.ThrowExceptionForHR(scope.GetEndOffset(out var offset));
		return offset;
	}

	public static ISymUnmanagedNamespace[] GetNamespaces(this ISymUnmanagedScope scope)
	{
		if (scope == null)
		{
			throw new ArgumentNullException("scope");
		}
		return InteropUtilities.NullToEmpty(InteropUtilities.GetItems(scope, delegate(ISymUnmanagedScope a, int b, out int c, ISymUnmanagedNamespace[] d)
		{
			return a.GetNamespaces(b, out c, d);
		}));
	}

	public static ISymUnmanagedScope[] GetChildren(this ISymUnmanagedScope scope)
	{
		if (scope == null)
		{
			throw new ArgumentNullException("scope");
		}
		return InteropUtilities.NullToEmpty(InteropUtilities.GetItems(scope, delegate(ISymUnmanagedScope a, int b, out int c, ISymUnmanagedScope[] d)
		{
			return a.GetChildren(b, out c, d);
		}));
	}

	public static ISymUnmanagedVariable[] GetLocals(this ISymUnmanagedScope scope)
	{
		if (scope == null)
		{
			throw new ArgumentNullException("scope");
		}
		return InteropUtilities.NullToEmpty(InteropUtilities.GetItems(scope, delegate(ISymUnmanagedScope a, out int b)
		{
			return a.GetLocalCount(out b);
		}, delegate(ISymUnmanagedScope a, int b, out int c, ISymUnmanagedVariable[] d)
		{
			return a.GetLocals(b, out c, d);
		}));
	}

	public static ISymUnmanagedConstant[] GetConstants(this ISymUnmanagedScope scope)
	{
		if (!(scope is ISymUnmanagedScope2 scope2))
		{
			if (scope == null)
			{
				throw new ArgumentNullException("scope");
			}
			return EmptyArray<ISymUnmanagedConstant>.Instance;
		}
		return scope2.GetConstants();
	}

	public static ISymUnmanagedConstant[] GetConstants(this ISymUnmanagedScope2 scope)
	{
		if (scope == null)
		{
			throw new ArgumentNullException("scope");
		}
		return InteropUtilities.NullToEmpty(InteropUtilities.GetItems(scope, delegate(ISymUnmanagedScope2 a, int b, out int c, ISymUnmanagedConstant[] d)
		{
			return a.GetConstants(b, out c, d);
		}));
	}

	public static int GetSlot(this ISymUnmanagedVariable local)
	{
		if (local == null)
		{
			throw new ArgumentNullException("local");
		}
		InteropUtilities.ThrowExceptionForHR(local.GetAddressField1(out var value));
		return value;
	}

	public static int GetAttributes(this ISymUnmanagedVariable local)
	{
		if (local == null)
		{
			throw new ArgumentNullException("local");
		}
		InteropUtilities.ThrowExceptionForHR(local.GetAttributes(out var attributes));
		return attributes;
	}

	public static string GetName(this ISymUnmanagedVariable local)
	{
		if (local == null)
		{
			throw new ArgumentNullException("local");
		}
		return InteropUtilities.BufferToString(InteropUtilities.GetItems(local, delegate(ISymUnmanagedVariable a, int b, out int c, char[] d)
		{
			return a.GetName(b, out c, d);
		}));
	}
}
