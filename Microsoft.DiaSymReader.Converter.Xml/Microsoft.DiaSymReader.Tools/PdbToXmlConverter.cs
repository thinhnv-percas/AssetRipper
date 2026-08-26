using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using Microsoft.CodeAnalysis.Debugging;
using Microsoft.CodeAnalysis.PooledObjects;
using Microsoft.DiaSymReader.PortablePdb;
using Roslyn.Utilities;

namespace Microsoft.DiaSymReader.Tools;

public sealed class PdbToXmlConverter
{
	private sealed class ConstantSignatureVisualizer : ISignatureTypeProvider<string, object>, ISimpleTypeProvider<string>, IConstructedTypeProvider<string>, ISZArrayTypeProvider<string>
	{
		public static readonly ConstantSignatureVisualizer Instance = new ConstantSignatureVisualizer();

		public string GetArrayType(string elementType, ArrayShape shape)
		{
			return elementType + "[" + new string(',', shape.Rank) + "]";
		}

		public string GetByReferenceType(string elementType)
		{
			return elementType + "&";
		}

		public string GetFunctionPointerType(MethodSignature<string> signature)
		{
			return "method-ptr";
		}

		public string GetGenericInstantiation(string genericType, ImmutableArray<string> typeArguments)
		{
			return genericType + "{" + string.Join(", ", typeArguments) + "}";
		}

		public string GetGenericMethodParameter(object genericContext, int index)
		{
			return "!!" + index;
		}

		public string GetGenericTypeParameter(object genericContext, int index)
		{
			return "!" + index;
		}

		public string GetModifiedType(string modifier, string unmodifiedType, bool isRequired)
		{
			return (isRequired ? "modreq" : "modopt") + "(" + modifier + ") " + unmodifiedType;
		}

		public string GetPinnedType(string elementType)
		{
			return "pinned " + elementType;
		}

		public string GetPointerType(string elementType)
		{
			return elementType + "*";
		}

		public string GetPrimitiveType(PrimitiveTypeCode typeCode)
		{
			return typeCode.ToString();
		}

		public string GetSZArrayType(string elementType)
		{
			return elementType + "[]";
		}

		public string GetTypeFromDefinition(MetadataReader reader, TypeDefinitionHandle handle, byte rawTypeKind)
		{
			TypeDefinition typeDefinition = reader.GetTypeDefinition(handle);
			string text = reader.GetString(typeDefinition.Name);
			if (!typeDefinition.Namespace.IsNil)
			{
				return reader.GetString(typeDefinition.Namespace) + "." + text;
			}
			return text;
		}

		public string GetTypeFromReference(MetadataReader reader, TypeReferenceHandle handle, byte rawTypeKind)
		{
			TypeReference typeReference = reader.GetTypeReference(handle);
			string text = reader.GetString(typeReference.Name);
			if (!typeReference.Namespace.IsNil)
			{
				return reader.GetString(typeReference.Namespace) + "." + text;
			}
			return text;
		}

		public string GetTypeFromSpecification(MetadataReader reader, object genericContext, TypeSpecificationHandle handle, byte rawTypeKind)
		{
			BlobReader blobReader = reader.GetBlobReader(reader.GetTypeSpecification(handle).Signature);
			return new SignatureDecoder<string, object>(Instance, reader, genericContext).DecodeType(ref blobReader);
		}
	}

	private const string IntHexFormat = "0x{0:X}";

	private readonly MetadataReader _metadataReader;

	private readonly ISymUnmanagedReader3 _symReader;

	private readonly MetadataReader _portablePdbMetadataOpt;

	private readonly PdbToXmlOptions _options;

	private readonly XmlWriter _writer;

	private static readonly XmlWriterSettings s_xmlWriterSettings = new XmlWriterSettings
	{
		Encoding = Encoding.UTF8,
		Indent = true,
		IndentChars = "  ",
		NewLineChars = "\r\n"
	};

	private static IReadOnlyDictionary<Guid, int> s_cdiOrdering = new Dictionary<Guid, int>
	{
		{
			PortableCustomDebugInfoKinds.StateMachineHoistedLocalScopes,
			0
		},
		{
			PortableCustomDebugInfoKinds.EncLocalSlotMap,
			1
		},
		{
			PortableCustomDebugInfoKinds.EncLambdaAndClosureMap,
			2
		}
	};

	private PdbToXmlConverter(XmlWriter writer, ISymUnmanagedReader3 symReader, MetadataReader metadataReader, PdbToXmlOptions options)
	{
		_symReader = symReader;
		_metadataReader = metadataReader;
		_writer = writer;
		_options = options;
		_portablePdbMetadataOpt = GetPortablePdbMetadata(symReader);
	}

	private unsafe static MetadataReader GetPortablePdbMetadata(ISymUnmanagedReader3 symReader)
	{
		if (symReader is ISymUnmanagedReader4 symUnmanagedReader && symUnmanagedReader.GetPortableDebugMetadata(out var metadata, out var size) == 0)
		{
			return new MetadataReader(metadata, size);
		}
		return null;
	}

	public static string DeltaPdbToXml(Stream deltaPdb, IEnumerable<int> methodTokens)
	{
		StringWriter stringWriter = new StringWriter();
		ToXml(stringWriter, deltaPdb, null, PdbToXmlOptions.IncludeTokens, Enumerable.Select<int, MethodDefinitionHandle>(methodTokens, (Func<int, MethodDefinitionHandle>)((int token) => (MethodDefinitionHandle)MetadataTokens.Handle(token))));
		return stringWriter.ToString();
	}

	public static string ToXml(Stream pdbStream, Stream peStream, PdbToXmlOptions options = PdbToXmlOptions.ResolveTokens, string methodName = null)
	{
		StringWriter stringWriter = new StringWriter();
		ToXml(stringWriter, pdbStream, peStream, options, methodName);
		return stringWriter.ToString();
	}

	public static string ToXml(Stream pdbStream, byte[] peImage, PdbToXmlOptions options = PdbToXmlOptions.ResolveTokens, string methodName = null)
	{
		StringWriter stringWriter = new StringWriter();
		ToXml(stringWriter, pdbStream, new MemoryStream(peImage), options, methodName);
		return stringWriter.ToString();
	}

	public static void ToXml(TextWriter xmlWriter, Stream pdbStream, Stream peStream, PdbToXmlOptions options = PdbToXmlOptions.Default, string methodName = null)
	{
		using PEReader peReader = new PEReader(peStream, PEStreamOptions.LeaveOpen);
		MetadataReader metadataReader = peReader.GetMetadataReader();
		IEnumerable<MethodDefinitionHandle> methodHandles;
		if (string.IsNullOrEmpty(methodName))
		{
			methodHandles = metadataReader.MethodDefinitions;
		}
		else
		{
			MethodDefinitionHandle[] array = Enumerable.ToArray<MethodDefinitionHandle>(Enumerable.Where<MethodDefinitionHandle>((IEnumerable<MethodDefinitionHandle>)metadataReader.MethodDefinitions, (Func<MethodDefinitionHandle, bool>)((MethodDefinitionHandle methodHandle) => GetQualifiedMethodName(metadataReader, methodHandle) == methodName)));
			if (array.Length == 0)
			{
				xmlWriter.WriteLine("<error>");
				xmlWriter.WriteLine($"<message><![CDATA[No method '{methodName}' found in metadata.]]></message>");
				xmlWriter.WriteLine("<available-methods>");
				foreach (MethodDefinitionHandle methodDefinition in metadataReader.MethodDefinitions)
				{
					xmlWriter.Write("<method><![CDATA[");
					xmlWriter.Write(GetQualifiedMethodName(metadataReader, methodDefinition));
					xmlWriter.Write("]]></method>");
					xmlWriter.WriteLine();
				}
				xmlWriter.WriteLine("</available-methods>");
				xmlWriter.WriteLine("</error>");
				return;
			}
			methodHandles = array;
		}
		ToXml(xmlWriter, pdbStream, metadataReader, options, methodHandles);
	}

	private static void ToXml(TextWriter xmlWriter, Stream pdbStream, MetadataReader metadataReaderOpt, PdbToXmlOptions options, IEnumerable<MethodDefinitionHandle> methodHandles)
	{
		using XmlWriter writer = XmlWriter.Create(xmlWriter, s_xmlWriterSettings);
		ISymUnmanagedReader3 symUnmanagedReader = CreateReader(pdbStream, metadataReaderOpt, (options & PdbToXmlOptions.UseNativeReader) != 0);
		try
		{
			new PdbToXmlConverter(writer, symUnmanagedReader, metadataReaderOpt, options).WriteRoot((IEnumerable<MethodDefinitionHandle>)(methodHandles ?? ((object)metadataReaderOpt.MethodDefinitions)));
		}
		finally
		{
			((ISymUnmanagedDispose)symUnmanagedReader).Destroy();
		}
	}

	private static ISymUnmanagedReader3 CreateReader(Stream pdbStream, MetadataReader metadataReaderOpt, bool useNativeReader)
	{
		ISymReaderMetadataProvider metadataProvider;
		if (metadataReaderOpt == null)
		{
			metadataProvider = DummySymReaderMetadataProvider.Instance;
		}
		else
		{
			ISymReaderMetadataProvider symReaderMetadataProvider = new SymMetadataProvider(metadataReaderOpt);
			metadataProvider = symReaderMetadataProvider;
		}
		object obj = SymUnmanagedReaderFactory.CreateSymReaderMetadataImport(metadataProvider);
		if (!useNativeReader && SymReaderHelpers.IsPortable(pdbStream))
		{
			return (ISymUnmanagedReader3)new SymBinder().GetReaderFromStream(pdbStream, obj);
		}
		return SymUnmanagedReaderFactory.CreateReaderWithMetadataImport<ISymUnmanagedReader3>(pdbStream, obj, SymUnmanagedReaderCreationOptions.UseComRegistry);
	}

	private void WriteRoot(IEnumerable<MethodDefinitionHandle> methodHandles)
	{
		_writer.WriteStartDocument();
		_writer.WriteStartElement("symbols");
		ISymUnmanagedDocument[] documents = _symReader.GetDocuments();
		IReadOnlyDictionary<string, int> documentIndex = BuildDocumentIndex(documents);
		ImmutableArray<MethodDefinitionHandle> tokenMap = BuildMethodTokenMap();
		if ((_options & PdbToXmlOptions.ExcludeDocuments) == 0)
		{
			WriteDocuments(documents, documentIndex);
		}
		if ((_options & PdbToXmlOptions.ExcludeMethods) == 0)
		{
			WriteEntryPoint();
			WriteAllMethods(methodHandles, tokenMap, documentIndex);
			WriteAllMethodSpans();
		}
		if ((_options & PdbToXmlOptions.IncludeSourceServerInformation) != PdbToXmlOptions.Default)
		{
			WriteSourceLinkInformation();
			WriteSourceServerInformation();
		}
		_writer.WriteEndElement();
	}

	private void WriteAllMethods(IEnumerable<MethodDefinitionHandle> methodHandles, ImmutableArray<MethodDefinitionHandle> tokenMap, IReadOnlyDictionary<string, int> documentIndex)
	{
		_writer.WriteStartElement("methods");
		foreach (MethodDefinitionHandle methodHandle in methodHandles)
		{
			WriteMethod(methodHandle, tokenMap, documentIndex);
		}
		_writer.WriteEndElement();
	}

	private void WriteMethod(MethodDefinitionHandle methodHandle, ImmutableArray<MethodDefinitionHandle> tokenMap, IReadOnlyDictionary<string, int> documentIndex)
	{
		int token = _metadataReader.GetToken(methodHandle);
		ISymUnmanagedMethod method = _symReader.GetMethod(token);
		byte[] array = null;
		ImmutableArray<(Guid, ImmutableArray<byte>)> portableCdi = ImmutableArray<(Guid, ImmutableArray<byte>)>.Empty;
		ImmutableArray<SymUnmanagedSequencePoint> sequencePoints = ImmutableArray<SymUnmanagedSequencePoint>.Empty;
		ISymUnmanagedAsyncMethod symUnmanagedAsyncMethod = null;
		ISymUnmanagedScope symUnmanagedScope = null;
		if ((_options & PdbToXmlOptions.ExcludeCustomDebugInformation) == 0)
		{
			if (_portablePdbMetadataOpt != null)
			{
				portableCdi = GetPortableCustomDebugInfo(methodHandle);
			}
			else
			{
				array = _symReader.GetCustomDebugInfo(token, 1);
			}
		}
		if (method != null)
		{
			if ((_options & PdbToXmlOptions.ExcludeAsyncInfo) == 0)
			{
				symUnmanagedAsyncMethod = method.AsAsyncMethod();
			}
			if ((_options & PdbToXmlOptions.ExcludeSequencePoints) == 0)
			{
				sequencePoints = method.GetSequencePoints().ToImmutableArray();
			}
			if ((_options & PdbToXmlOptions.ExcludeScopes) == 0)
			{
				symUnmanagedScope = method.GetRootScope();
			}
		}
		if (array != null || !portableCdi.IsEmpty || !sequencePoints.IsEmpty || symUnmanagedScope != null || symUnmanagedAsyncMethod != null)
		{
			_writer.WriteStartElement("method");
			int rowNumber = MetadataTokens.GetRowNumber(methodHandle);
			int token2 = ((rowNumber <= tokenMap.Length) ? MetadataTokens.GetToken(tokenMap[rowNumber - 1]) : token);
			WriteMethodAttributes(token2, isReference: false);
			WriteCustomDebugInfo(array, portableCdi);
			if (!sequencePoints.IsEmpty)
			{
				WriteSequencePoints(sequencePoints, documentIndex);
			}
			if (symUnmanagedScope != null)
			{
				WriteScopes(symUnmanagedScope);
			}
			if (symUnmanagedAsyncMethod != null)
			{
				WriteAsyncInfo(symUnmanagedAsyncMethod);
			}
			_writer.WriteEndElement();
		}
	}

	private void WriteCustomDebugInfo(byte[] windowsCdi, ImmutableArray<(Guid kind, ImmutableArray<byte> data)> portableCdi)
	{
		if (windowsCdi != null || !portableCdi.IsEmpty)
		{
			_writer.WriteStartElement("customDebugInfo");
			if (windowsCdi != null)
			{
				WriteCustomDebugInfo(windowsCdi);
			}
			else
			{
				WriteCustomDebugInfo(portableCdi);
			}
			_writer.WriteEndElement();
		}
	}

	private void WriteCustomDebugInfo(byte[] bytes)
	{
		CustomDebugInfoRecord[] array = Enumerable.ToArray<CustomDebugInfoRecord>(CustomDebugInfoReader.GetCustomDebugInfoRecords(bytes));
		for (int i = 0; i < array.Length; i++)
		{
			CustomDebugInfoRecord record = array[i];
			if (record.Version != 4)
			{
				WriteUnknownCustomDebugInfo(record);
				continue;
			}
			ImmutableArray<byte> data = record.Data;
			switch (record.Kind)
			{
			case CustomDebugInfoKind.UsingGroups:
				WriteUsingGroupsCustomDebugInfo(data);
				break;
			case CustomDebugInfoKind.ForwardMethodInfo:
				WriteForwardMethodInfoCustomDebugInfo(data);
				break;
			case CustomDebugInfoKind.ForwardModuleInfo:
				WriteForwardModuleInfoCustomDebugInfo(data);
				break;
			case CustomDebugInfoKind.DynamicLocals:
				WriteDynamicLocalsCustomDebugInfo(data);
				break;
			case CustomDebugInfoKind.StateMachineTypeName:
				WriteStateMachineTypeNameCustomDebugInfo(data);
				break;
			case CustomDebugInfoKind.TupleElementNames:
				WriteTupleElementNamesCustomDebugInfo(data);
				break;
			case CustomDebugInfoKind.StateMachineHoistedLocalScopes:
				WriteStateMachineHoistedLocalScopesCustomDebugInfo(data, isPortable: false);
				break;
			case CustomDebugInfoKind.EditAndContinueLocalSlotMap:
				WriteEditAndContinueLocalSlotMap(data);
				break;
			case CustomDebugInfoKind.EditAndContinueLambdaMap:
				WriteEditAndContinueLambdaAndClosureMap(data);
				break;
			default:
				WriteUnknownCustomDebugInfo(record);
				break;
			}
		}
	}

	private void WriteCustomDebugInfo(ImmutableArray<(Guid kind, ImmutableArray<byte> data)> cdis)
	{
		_ = _portablePdbMetadataOpt;
		foreach (var (guid, data) in cdis)
		{
			if (guid == PortableCustomDebugInfoKinds.StateMachineHoistedLocalScopes)
			{
				WriteStateMachineHoistedLocalScopesCustomDebugInfo(data, isPortable: true);
			}
			else if (guid == PortableCustomDebugInfoKinds.EncLambdaAndClosureMap)
			{
				WriteEditAndContinueLambdaAndClosureMap(data);
			}
			else if (guid == PortableCustomDebugInfoKinds.EncLocalSlotMap)
			{
				WriteEditAndContinueLocalSlotMap(data);
			}
		}
	}

	private ImmutableArray<(Guid kind, ImmutableArray<byte> data)> GetPortableCustomDebugInfo(MethodDefinitionHandle handle)
	{
		MetadataReader portablePdbMetadataOpt = _portablePdbMetadataOpt;
		CustomDebugInformationHandleCollection customDebugInformation = portablePdbMetadataOpt.GetCustomDebugInformation(handle);
		if (customDebugInformation.Count == 0)
		{
			return ImmutableArray<(Guid, ImmutableArray<byte>)>.Empty;
		}
		List<(int, Guid, ImmutableArray<byte>)> list = new List<(int, Guid, ImmutableArray<byte>)>();
		foreach (CustomDebugInformationHandle item in customDebugInformation)
		{
			CustomDebugInformation customDebugInformation2 = portablePdbMetadataOpt.GetCustomDebugInformation(item);
			Guid guid = portablePdbMetadataOpt.GetGuid(customDebugInformation2.Kind);
			if (s_cdiOrdering.TryGetValue(guid, out var value))
			{
				list.Add((value, guid, portablePdbMetadataOpt.GetBlobContent(customDebugInformation2.Value)));
			}
		}
		return Enumerable.Select<(int, Guid, ImmutableArray<byte>), (Guid, ImmutableArray<byte>)>((IEnumerable<(int, Guid, ImmutableArray<byte>)>)Enumerable.OrderBy<(int, Guid, ImmutableArray<byte>), int>((IEnumerable<(int, Guid, ImmutableArray<byte>)>)list, (Func<(int, Guid, ImmutableArray<byte>), int>)(((int ordinal, Guid kind, ImmutableArray<byte> data) e) => e.ordinal)), (Func<(int, Guid, ImmutableArray<byte>), (Guid, ImmutableArray<byte>)>)(((int ordinal, Guid kind, ImmutableArray<byte> data) e) => (kind: e.kind, data: e.data))).ToImmutableArray();
	}

	private void WriteUnknownCustomDebugInfo(CustomDebugInfoRecord record)
	{
		_writer.WriteStartElement("unknown");
		_writer.WriteAttributeString("kind", record.Kind.ToString());
		_writer.WriteAttributeString("version", CultureInvariantToString(record.Version));
		_writer.WriteAttributeString("payload", BitConverter.ToString(record.Data.ToArray()));
		_writer.WriteEndElement();
	}

	private void WriteUsingGroupsCustomDebugInfo(ImmutableArray<byte> data)
	{
		_writer.WriteStartElement("using");
		foreach (short item in CustomDebugInfoReader.DecodeUsingRecord(data))
		{
			_writer.WriteStartElement("namespace");
			_writer.WriteAttributeString("usingCount", CultureInvariantToString(item));
			_writer.WriteEndElement();
		}
		_writer.WriteEndElement();
	}

	private void WriteForwardMethodInfoCustomDebugInfo(ImmutableArray<byte> data)
	{
		_writer.WriteStartElement("forward");
		int token = CustomDebugInfoReader.DecodeForwardRecord(data);
		WriteMethodAttributes(token, isReference: true);
		_writer.WriteEndElement();
	}

	private void WriteForwardModuleInfoCustomDebugInfo(ImmutableArray<byte> data)
	{
		_writer.WriteStartElement("forwardToModule");
		int token = CustomDebugInfoReader.DecodeForwardRecord(data);
		WriteMethodAttributes(token, isReference: true);
		_writer.WriteEndElement();
	}

	private void WriteStateMachineHoistedLocalScopesCustomDebugInfo(ImmutableArray<byte> data, bool isPortable)
	{
		_writer.WriteStartElement("hoistedLocalScopes");
		foreach (StateMachineHoistedLocalScope item in isPortable ? DecodePortableHoistedLocalScopes(data) : CustomDebugInfoReader.DecodeStateMachineHoistedLocalScopesRecord(data))
		{
			_writer.WriteStartElement("slot");
			if (!item.IsDefault)
			{
				_writer.WriteAttributeString("startOffset", AsILOffset(item.StartOffset));
				_writer.WriteAttributeString("endOffset", AsILOffset(item.EndOffset));
			}
			_writer.WriteEndElement();
		}
		_writer.WriteEndElement();
	}

	private unsafe static ImmutableArray<StateMachineHoistedLocalScope> DecodePortableHoistedLocalScopes(ImmutableArray<byte> data)
	{
		if (data.Length == 0)
		{
			return ImmutableArray<StateMachineHoistedLocalScope>.Empty;
		}
		fixed (byte* buffer = data.ToArray())
		{
			BlobReader blobReader = new BlobReader(buffer, data.Length);
			ImmutableArray<StateMachineHoistedLocalScope>.Builder builder = ImmutableArray.CreateBuilder<StateMachineHoistedLocalScope>();
			do
			{
				int num = blobReader.ReadInt32();
				int num2 = blobReader.ReadInt32();
				builder.Add(new StateMachineHoistedLocalScope(num, num + num2));
			}
			while (blobReader.RemainingBytes > 0);
			return builder.ToImmutable();
		}
	}

	private void WriteStateMachineTypeNameCustomDebugInfo(ImmutableArray<byte> data)
	{
		_writer.WriteStartElement("forwardIterator");
		string value = CustomDebugInfoReader.DecodeForwardIteratorRecord(data);
		_writer.WriteAttributeString("name", value);
		_writer.WriteEndElement();
	}

	private void WriteDynamicLocalsCustomDebugInfo(ImmutableArray<byte> data)
	{
		_writer.WriteStartElement("dynamicLocals");
		foreach (DynamicLocalInfo item in CustomDebugInfoReader.DecodeDynamicLocalsRecord(data))
		{
			ImmutableArray<bool> flags = item.Flags;
			PooledStringBuilder instance = PooledStringBuilder.GetInstance();
			StringBuilder builder = instance.Builder;
			foreach (bool item2 in flags)
			{
				builder.Append(item2 ? '1' : '0');
			}
			_writer.WriteStartElement("bucket");
			_writer.WriteAttributeString("flags", instance.ToStringAndFree());
			_writer.WriteAttributeString("slotId", CultureInvariantToString(item.SlotId));
			_writer.WriteAttributeString("localName", item.LocalName);
			_writer.WriteEndElement();
		}
		_writer.WriteEndElement();
	}

	private void WriteTupleElementNamesCustomDebugInfo(ImmutableArray<byte> data)
	{
		_writer.WriteStartElement("tupleElementNames");
		foreach (TupleElementNamesInfo item in CustomDebugInfoReader.DecodeTupleElementNamesRecord(data))
		{
			_writer.WriteStartElement("local");
			_writer.WriteAttributeString("elementNames", JoinNames(item.ElementNames));
			_writer.WriteAttributeString("slotIndex", CultureInvariantToString(item.SlotIndex));
			_writer.WriteAttributeString("localName", item.LocalName);
			_writer.WriteAttributeString("scopeStart", AsILOffset(item.ScopeStart));
			_writer.WriteAttributeString("scopeEnd", AsILOffset(item.ScopeEnd));
			_writer.WriteEndElement();
		}
		_writer.WriteEndElement();
	}

	private static string JoinNames(ImmutableArray<string> names)
	{
		PooledStringBuilder instance = PooledStringBuilder.GetInstance();
		StringBuilder builder = instance.Builder;
		foreach (string item in names)
		{
			builder.Append('|');
			if (item != null)
			{
				builder.Append(item);
			}
		}
		return instance.ToStringAndFree();
	}

	private unsafe void WriteEditAndContinueLocalSlotMap(ImmutableArray<byte> data)
	{
		_writer.WriteStartElement("encLocalSlotMap");
		try
		{
			if (data.Length == 0)
			{
				return;
			}
			int value = -1;
			fixed (byte* buffer = data.ToArray())
			{
				BlobReader blobReader = new BlobReader(buffer, data.Length);
				while (blobReader.RemainingBytes > 0)
				{
					byte b = blobReader.ReadByte();
					if (b == byte.MaxValue)
					{
						if (!blobReader.TryReadCompressedInteger(out value))
						{
							_writer.WriteElementString("baseline", "?");
							break;
						}
						value = -value;
						continue;
					}
					_writer.WriteStartElement("slot");
					if (b == 0)
					{
						_writer.WriteAttributeString("kind", "temp");
					}
					else
					{
						int input = (b & 0x3F) - 1;
						bool flag = (b & 0x80) != 0;
						bool flag2 = !blobReader.TryReadCompressedInteger(out var value2);
						value2 += value;
						int value3 = 0;
						bool flag3 = flag && !blobReader.TryReadCompressedInteger(out value3);
						_writer.WriteAttributeString("kind", CultureInvariantToString(input));
						_writer.WriteAttributeString("offset", flag2 ? "?" : CultureInvariantToString(value2));
						if (flag3 | flag)
						{
							_writer.WriteAttributeString("ordinal", flag3 ? "?" : CultureInvariantToString(value3));
						}
					}
					_writer.WriteEndElement();
				}
			}
		}
		finally
		{
			_writer.WriteEndElement();
		}
	}

	private unsafe void WriteEditAndContinueLambdaAndClosureMap(ImmutableArray<byte> data)
	{
		_writer.WriteStartElement("encLambdaMap");
		try
		{
			if (data.Length == 0)
			{
				return;
			}
			int value = -1;
			int value2 = -1;
			fixed (byte* buffer = data.ToArray())
			{
				BlobReader blobReader = new BlobReader(buffer, data.Length);
				if (!blobReader.TryReadCompressedInteger(out value))
				{
					_writer.WriteElementString("methodOrdinal", "?");
					_writer.WriteEndElement();
					return;
				}
				value--;
				_writer.WriteElementString("methodOrdinal", CultureInvariantToString(value));
				if (!blobReader.TryReadCompressedInteger(out value2))
				{
					_writer.WriteElementString("baseline", "?");
					_writer.WriteEndElement();
					return;
				}
				value2 = -value2;
				if (!blobReader.TryReadCompressedInteger(out var value3))
				{
					_writer.WriteElementString("closureCount", "?");
					_writer.WriteEndElement();
					return;
				}
				for (int i = 0; i < value3; i++)
				{
					_writer.WriteStartElement("closure");
					try
					{
						if (!blobReader.TryReadCompressedInteger(out var value4))
						{
							_writer.WriteElementString("offset", "?");
							break;
						}
						_writer.WriteAttributeString("offset", CultureInvariantToString(value4 + value2));
					}
					finally
					{
						_writer.WriteEndElement();
					}
				}
				while (blobReader.RemainingBytes > 0)
				{
					_writer.WriteStartElement("lambda");
					try
					{
						if (!blobReader.TryReadCompressedInteger(out var value5))
						{
							_writer.WriteElementString("offset", "?");
							break;
						}
						_writer.WriteAttributeString("offset", CultureInvariantToString(value5 + value2));
						if (!blobReader.TryReadCompressedInteger(out var value6))
						{
							_writer.WriteElementString("closure", "?");
							break;
						}
						value6 -= 2;
						switch (value6)
						{
						case -2:
							_writer.WriteAttributeString("closure", "this");
							break;
						default:
							_writer.WriteAttributeString("closure", CultureInvariantToString(value6) + ((value6 >= value3) ? " (invalid)" : ""));
							break;
						case -1:
							break;
						}
					}
					finally
					{
						_writer.WriteEndElement();
					}
				}
			}
		}
		finally
		{
			_writer.WriteEndElement();
		}
	}

	private void WriteScopes(ISymUnmanagedScope rootScope)
	{
		if (rootScope.GetNamespaces().Length == 0 && rootScope.GetLocals().Length == 0 && rootScope.GetConstants().Length == 0)
		{
			ISymUnmanagedScope[] children = rootScope.GetChildren();
			foreach (ISymUnmanagedScope scope in children)
			{
				WriteScope(scope, isRoot: false);
			}
		}
		else
		{
			WriteScope(rootScope, isRoot: true);
		}
	}

	private void WriteScope(ISymUnmanagedScope scope, bool isRoot)
	{
		_writer.WriteStartElement(isRoot ? "rootScope" : "scope");
		_writer.WriteAttributeString("startOffset", AsILOffset(scope.GetStartOffset()));
		_writer.WriteAttributeString("endOffset", AsILOffset(scope.GetEndOffset()));
		if ((_options & PdbToXmlOptions.ExcludeNamespaces) == 0)
		{
			ISymUnmanagedNamespace[] namespaces = scope.GetNamespaces();
			foreach (ISymUnmanagedNamespace symUnmanagedNamespace in namespaces)
			{
				WriteNamespace(symUnmanagedNamespace);
			}
		}
		WriteLocals(scope);
		ISymUnmanagedScope[] children = scope.GetChildren();
		foreach (ISymUnmanagedScope scope2 in children)
		{
			WriteScope(scope2, isRoot: false);
		}
		_writer.WriteEndElement();
	}

	private void WriteNamespace(ISymUnmanagedNamespace @namespace)
	{
		string name = @namespace.GetName();
		string externAlias;
		string alias;
		string target;
		ImportTargetKind kind;
		VBImportScopeKind scope;
		try
		{
			if (name.Length == 0)
			{
				externAlias = null;
				CustomDebugInfoReader.TryParseVisualBasicImportString(name, out alias, out target, out kind, out scope);
			}
			else
			{
				switch (name[0])
				{
				case 'A':
				case 'E':
				case 'T':
				case 'U':
				case 'X':
				case 'Z':
					scope = VBImportScopeKind.Unspecified;
					if (!CustomDebugInfoReader.TryParseCSharpImportString(name, out alias, out externAlias, out target, out kind))
					{
						throw new InvalidOperationException($"Invalid import '{name}'");
					}
					break;
				default:
					externAlias = null;
					if (!CustomDebugInfoReader.TryParseVisualBasicImportString(name, out alias, out target, out kind, out scope))
					{
						throw new InvalidOperationException($"Invalid import '{name}'");
					}
					break;
				}
			}
		}
		catch (ArgumentException) when ((_options & PdbToXmlOptions.ThrowOnError) == 0)
		{
			_writer.WriteStartElement("invalid-custom-data");
			_writer.WriteAttributeString("raw", name);
			_writer.WriteEndElement();
			return;
		}
		switch (kind)
		{
		case ImportTargetKind.CurrentNamespace:
			_writer.WriteStartElement("currentnamespace");
			_writer.WriteAttributeString("name", target);
			_writer.WriteEndElement();
			break;
		case ImportTargetKind.DefaultNamespace:
			_writer.WriteStartElement("defaultnamespace");
			_writer.WriteAttributeString("name", target);
			_writer.WriteEndElement();
			break;
		case ImportTargetKind.MethodToken:
		{
			int token = Convert.ToInt32(target);
			_writer.WriteStartElement("importsforward");
			WriteMethodAttributes(token, isReference: true);
			_writer.WriteEndElement();
			break;
		}
		case ImportTargetKind.XmlNamespace:
			_writer.WriteStartElement("xmlnamespace");
			_writer.WriteAttributeString("prefix", alias);
			_writer.WriteAttributeString("name", target);
			WriteScopeAttribute(scope);
			_writer.WriteEndElement();
			break;
		case ImportTargetKind.NamespaceOrType:
			_writer.WriteStartElement("alias");
			_writer.WriteAttributeString("name", alias);
			_writer.WriteAttributeString("target", target);
			_writer.WriteAttributeString("kind", "namespace");
			WriteScopeAttribute(scope);
			_writer.WriteEndElement();
			break;
		case ImportTargetKind.Namespace:
			if (alias != null)
			{
				_writer.WriteStartElement("alias");
				_writer.WriteAttributeString("name", alias);
				if (externAlias != null)
				{
					_writer.WriteAttributeString("qualifier", externAlias);
				}
				_writer.WriteAttributeString("target", target);
				_writer.WriteAttributeString("kind", "namespace");
				_writer.WriteEndElement();
			}
			else
			{
				_writer.WriteStartElement("namespace");
				if (externAlias != null)
				{
					_writer.WriteAttributeString("qualifier", externAlias);
				}
				_writer.WriteAttributeString("name", target);
				WriteScopeAttribute(scope);
				_writer.WriteEndElement();
			}
			break;
		case ImportTargetKind.Type:
			if (alias != null)
			{
				_writer.WriteStartElement("alias");
				_writer.WriteAttributeString("name", alias);
				_writer.WriteAttributeString("target", target);
				_writer.WriteAttributeString("kind", "type");
				_writer.WriteEndElement();
			}
			else
			{
				_writer.WriteStartElement("type");
				_writer.WriteAttributeString("name", target);
				WriteScopeAttribute(scope);
				_writer.WriteEndElement();
			}
			break;
		case ImportTargetKind.Assembly:
			if (target == null)
			{
				_writer.WriteStartElement("extern");
				_writer.WriteAttributeString("alias", alias);
				_writer.WriteEndElement();
			}
			else
			{
				_writer.WriteStartElement("externinfo");
				_writer.WriteAttributeString("alias", alias);
				_writer.WriteAttributeString("assembly", target);
				_writer.WriteEndElement();
			}
			break;
		case ImportTargetKind.Defunct:
			_writer.WriteStartElement("defunct");
			_writer.WriteAttributeString("name", name);
			_writer.WriteEndElement();
			break;
		default:
			_writer.WriteStartElement("unknown");
			_writer.WriteAttributeString("name", name);
			_writer.WriteEndElement();
			break;
		}
	}

	private void WriteScopeAttribute(VBImportScopeKind scope)
	{
		switch (scope)
		{
		case VBImportScopeKind.File:
			_writer.WriteAttributeString("importlevel", "file");
			break;
		case VBImportScopeKind.Project:
			_writer.WriteAttributeString("importlevel", "project");
			break;
		}
	}

	private void WriteAsyncInfo(ISymUnmanagedAsyncMethod asyncMethod)
	{
		_writer.WriteStartElement("asyncInfo");
		int catchHandlerILOffset = asyncMethod.GetCatchHandlerILOffset();
		if (catchHandlerILOffset >= 0)
		{
			_writer.WriteStartElement("catchHandler");
			_writer.WriteAttributeString("offset", AsILOffset(catchHandlerILOffset));
			_writer.WriteEndElement();
		}
		_writer.WriteStartElement("kickoffMethod");
		WriteMethodAttributes(asyncMethod.GetKickoffMethod(), isReference: true);
		_writer.WriteEndElement();
		foreach (SymUnmanagedAsyncStepInfo asyncStepInfo in asyncMethod.GetAsyncStepInfos())
		{
			_writer.WriteStartElement("await");
			_writer.WriteAttributeString("yield", AsILOffset(asyncStepInfo.YieldOffset));
			_writer.WriteAttributeString("resume", AsILOffset(asyncStepInfo.ResumeOffset));
			WriteMethodAttributes(asyncStepInfo.ResumeMethod, isReference: true);
			_writer.WriteEndElement();
		}
		_writer.WriteEndElement();
	}

	private void WriteLocals(ISymUnmanagedScope scope)
	{
		ISymUnmanagedVariable[] locals = scope.GetLocals();
		foreach (ISymUnmanagedVariable local in locals)
		{
			_writer.WriteStartElement("local");
			_writer.WriteAttributeString("name", local.GetName());
			_writer.WriteAttributeString("il_index", CultureInvariantToString(local.GetSlot()));
			_writer.WriteAttributeString("il_start", AsILOffset(scope.GetStartOffset()));
			_writer.WriteAttributeString("il_end", AsILOffset(scope.GetEndOffset()));
			_writer.WriteAttributeString("attributes", CultureInvariantToString(local.GetAttributes()));
			_writer.WriteEndElement();
		}
		ISymUnmanagedConstant[] constants = scope.GetConstants();
		foreach (ISymUnmanagedConstant symUnmanagedConstant in constants)
		{
			string name = symUnmanagedConstant.GetName();
			byte[] array = ((symUnmanagedConstant.GetSignature(0, out var _, null) == 0) ? symUnmanagedConstant.GetSignature() : Array.Empty<byte>());
			object value = symUnmanagedConstant.GetValue();
			_writer.WriteStartElement("constant");
			_writer.WriteAttributeString("name", name);
			if (object.Equals(0, value) && IsPossiblyNullConstantType(array))
			{
				_writer.WriteAttributeString("value", "null");
				if (array.Length == 0)
				{
					_writer.WriteAttributeString("unknown-signature", "");
				}
				else if (array[0] == 14)
				{
					_writer.WriteAttributeString("type", "String");
				}
				else if (array[0] == 28)
				{
					_writer.WriteAttributeString("type", "Object");
				}
				else
				{
					_writer.WriteAttributeString("signature", FormatLocalConstantSignature(array));
				}
			}
			else if (value == null)
			{
				if (array.Length != 0 && array[0] == 14)
				{
					_writer.WriteAttributeString("value", "");
					_writer.WriteAttributeString("type", "String");
				}
				else
				{
					_writer.WriteAttributeString("value", "null");
					_writer.WriteAttributeString("unknown-signature", BitConverter.ToString(Enumerable.ToArray<byte>((IEnumerable<byte>)array)));
				}
			}
			else if (value is decimal)
			{
				_writer.WriteAttributeString("value", ((decimal)value).ToString(CultureInfo.InvariantCulture));
				_writer.WriteAttributeString("type", value.GetType().Name);
			}
			else if (value is double && array.Length != 0 && array[0] != 13)
			{
				_writer.WriteAttributeString("value", DateTimeUtilities.ToDateTime((double)value).ToString(CultureInfo.InvariantCulture));
				_writer.WriteAttributeString("type", "DateTime");
			}
			else
			{
				if (value is string str)
				{
					_writer.WriteAttributeString("value", StringUtilities.EscapeNonPrintableCharacters(str));
				}
				else
				{
					_writer.WriteAttributeString("value", string.Format(CultureInfo.InvariantCulture, "{0}", value));
				}
				if (array.Length == 0)
				{
					_writer.WriteAttributeString("runtime-type", value.GetType().Name);
					_writer.WriteAttributeString("unknown-signature", BitConverter.ToString(Enumerable.ToArray<byte>((IEnumerable<byte>)array)));
				}
				else
				{
					Type constantRuntimeType = GetConstantRuntimeType(array);
					if (constantRuntimeType == null && (value is sbyte || value is byte || value is short || value is ushort || value is int || value is uint || value is long || value is ulong))
					{
						_writer.WriteAttributeString("signature", FormatLocalConstantSignature(array));
					}
					else if (constantRuntimeType == value.GetType())
					{
						XmlWriter writer = _writer;
						SignatureTypeCode signatureTypeCode = (SignatureTypeCode)array[0];
						writer.WriteAttributeString("type", signatureTypeCode.ToString());
					}
					else
					{
						_writer.WriteAttributeString("runtime-type", value.GetType().Name);
						_writer.WriteAttributeString("unknown-signature", BitConverter.ToString(Enumerable.ToArray<byte>((IEnumerable<byte>)array)));
					}
				}
			}
			_writer.WriteEndElement();
		}
	}

	private static bool IsPossiblyNullConstantType(byte[] signature)
	{
		if (signature.Length == 0)
		{
			return true;
		}
		switch ((SignatureTypeCode)signature[0])
		{
		case SignatureTypeCode.Boolean:
		case SignatureTypeCode.Char:
		case SignatureTypeCode.SByte:
		case SignatureTypeCode.Byte:
		case SignatureTypeCode.Int16:
		case SignatureTypeCode.UInt16:
		case SignatureTypeCode.Int32:
		case SignatureTypeCode.UInt32:
		case SignatureTypeCode.Int64:
		case SignatureTypeCode.UInt64:
		case SignatureTypeCode.Single:
		case SignatureTypeCode.Double:
		case SignatureTypeCode.IntPtr:
		case SignatureTypeCode.UIntPtr:
			return false;
		case SignatureTypeCode.GenericTypeInstance:
			if (signature.Length == 1)
			{
				return true;
			}
			return signature[1] != 17;
		case (SignatureTypeCode)17:
			return false;
		default:
			return true;
		}
	}

	private unsafe string FormatLocalConstantSignature(byte[] signature)
	{
		fixed (byte* buffer = Enumerable.ToArray<byte>((IEnumerable<byte>)signature))
		{
			BlobReader blobReader = new BlobReader(buffer, signature.Length);
			return new SignatureDecoder<string, object>(ConstantSignatureVisualizer.Instance, _metadataReader, null).DecodeType(ref blobReader, allowTypeSpecifications: true);
		}
	}

	private static Type GetConstantRuntimeType(byte[] signature)
	{
		switch ((SignatureTypeCode)signature[0])
		{
		case SignatureTypeCode.Boolean:
		case SignatureTypeCode.SByte:
		case SignatureTypeCode.Byte:
		case SignatureTypeCode.Int16:
			return typeof(short);
		case SignatureTypeCode.Char:
		case SignatureTypeCode.UInt16:
			return typeof(ushort);
		case SignatureTypeCode.Int32:
			return typeof(int);
		case SignatureTypeCode.UInt32:
			return typeof(uint);
		case SignatureTypeCode.Int64:
			return typeof(long);
		case SignatureTypeCode.UInt64:
			return typeof(ulong);
		case SignatureTypeCode.Single:
			return typeof(float);
		case SignatureTypeCode.Double:
			return typeof(double);
		case SignatureTypeCode.String:
			return typeof(string);
		default:
			return null;
		}
	}

	private void WriteSequencePoints(ImmutableArray<SymUnmanagedSequencePoint> sequencePoints, IReadOnlyDictionary<string, int> documentIndex)
	{
		_writer.WriteStartElement("sequencePoints");
		foreach (SymUnmanagedSequencePoint item in sequencePoints)
		{
			_writer.WriteStartElement("entry");
			_writer.WriteAttributeString("offset", AsILOffset(item.Offset));
			if (item.IsHidden)
			{
				if (item.StartLine != item.EndLine || item.StartColumn != 0 || item.EndColumn != 0)
				{
					_writer.WriteAttributeString("hidden", "invalid");
				}
				else
				{
					_writer.WriteAttributeString("hidden", XmlConvert.ToString(value: true));
				}
			}
			else
			{
				_writer.WriteAttributeString("startLine", CultureInvariantToString(item.StartLine));
				_writer.WriteAttributeString("startColumn", CultureInvariantToString(item.StartColumn));
				_writer.WriteAttributeString("endLine", CultureInvariantToString(item.EndLine));
				_writer.WriteAttributeString("endColumn", CultureInvariantToString(item.EndColumn));
			}
			string name = item.Document.GetName();
			if (documentIndex.TryGetValue(name, out var value))
			{
				_writer.WriteAttributeString("document", CultureInvariantToString(value));
			}
			else
			{
				_writer.WriteAttributeString("document", "?");
			}
			_writer.WriteEndElement();
		}
		_writer.WriteEndElement();
	}

	private unsafe ImmutableArray<MethodDefinitionHandle> BuildMethodTokenMap()
	{
		if (!(_symReader is ISymUnmanagedReader4 symUnmanagedReader) || symUnmanagedReader.GetPortableDebugMetadata(out var metadata, out var size) != 0)
		{
			return ImmutableArray<MethodDefinitionHandle>.Empty;
		}
		return Enumerable.Select<EntityHandle, MethodDefinitionHandle>(Enumerable.Where<EntityHandle>(new MetadataReader(metadata, size).GetEditAndContinueMapEntries(), (Func<EntityHandle, bool>)delegate(EntityHandle handle)
		{
			EntityHandle entityHandle = handle;
			return entityHandle.Kind == HandleKind.MethodDebugInformation;
		}), (Func<EntityHandle, MethodDefinitionHandle>)((EntityHandle handle) => MetadataTokens.MethodDefinitionHandle(MetadataTokens.GetRowNumber(handle)))).ToImmutableArray();
	}

	private IReadOnlyDictionary<string, int> BuildDocumentIndex(IReadOnlyList<ISymUnmanagedDocument> documents)
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>(documents.Count);
		int num = 1;
		foreach (ISymUnmanagedDocument document in documents)
		{
			string name = document.GetName();
			if (!dictionary.ContainsKey(name))
			{
				dictionary.Add(name, num);
			}
			num++;
		}
		return dictionary;
	}

	private void WriteDocuments(IEnumerable<ISymUnmanagedDocument> documents, IReadOnlyDictionary<string, int> documentIndex)
	{
		bool flag = false;
		foreach (ISymUnmanagedDocument document in documents)
		{
			string name = document.GetName();
			if (!documentIndex.TryGetValue(name, out var value))
			{
				continue;
			}
			if (!flag)
			{
				_writer.WriteStartElement("files");
			}
			flag = true;
			_writer.WriteStartElement("file");
			_writer.WriteAttributeString("id", CultureInvariantToString(value));
			_writer.WriteAttributeString("name", name);
			_writer.WriteAttributeString("language", GetLanguageName(document.GetLanguage()));
			Guid languageVendor = document.GetLanguageVendor();
			if (languageVendor != PdbGuids.LanguageVendor.Microsoft)
			{
				_writer.WriteAttributeString("languageVendor", languageVendor.ToString());
			}
			Guid documentType = document.GetDocumentType();
			if (documentType != PdbGuids.DocumentType.Text)
			{
				_writer.WriteAttributeString("documentType", documentType.ToString());
			}
			Guid hashAlgorithm = document.GetHashAlgorithm();
			if (hashAlgorithm != default(Guid))
			{
				byte[] checksum = document.GetChecksum();
				if (checksum.Length != 0)
				{
					_writer.WriteAttributeString("checksumAlgorithm", GetHashAlgorithmName(hashAlgorithm));
					_writer.WriteAttributeString("checksum", BitConverter.ToString(checksum));
				}
			}
			Marshal.ThrowExceptionForHR(document.HasEmbeddedSource(out var value2));
			if (value2)
			{
				Marshal.ThrowExceptionForHR(document.GetSourceLength(out var length));
				_writer.WriteAttributeString("embeddedSourceLength", length.ToString());
				if ((_options & PdbToXmlOptions.IncludeEmbeddedSources) != PdbToXmlOptions.Default)
				{
					WriteEmbeddedSource(document);
				}
			}
			_writer.WriteEndElement();
		}
		if (flag)
		{
			_writer.WriteEndElement();
		}
	}

	private static string GetLanguageName(Guid guid)
	{
		if (!(guid == PdbGuids.Language.CSharp))
		{
			if (!(guid == PdbGuids.Language.VisualBasic))
			{
				if (!(guid == PdbGuids.Language.FSharp))
				{
					return guid.ToString();
				}
				return "F#";
			}
			return "VB";
		}
		return "C#";
	}

	private static string GetHashAlgorithmName(Guid guid)
	{
		if (!(guid == PdbGuids.HashAlgorithm.SHA1))
		{
			if (!(guid == PdbGuids.HashAlgorithm.SHA256))
			{
				return guid.ToString();
			}
			return "SHA256";
		}
		return "SHA1";
	}

	private void WriteEmbeddedSource(ISymUnmanagedDocument doc)
	{
		ArraySegment<byte> embeddedSource = doc.GetEmbeddedSource();
		string text = Encoding.UTF8.GetString(embeddedSource.Array, embeddedSource.Offset, embeddedSource.Count);
		try
		{
			_writer.WriteCData(text);
		}
		catch (ArgumentException)
		{
			try
			{
				_writer.WriteValue(text);
			}
			catch (ArgumentException)
			{
				_writer.WriteAttributeString("encoding", "base64");
				_writer.WriteBase64(embeddedSource.Array, embeddedSource.Offset, embeddedSource.Count);
			}
		}
	}

	private void WriteAllMethodSpans()
	{
		if ((_options & PdbToXmlOptions.IncludeMethodSpans) == 0)
		{
			return;
		}
		_writer.WriteStartElement("method-spans");
		ISymUnmanagedDocument[] documents = _symReader.GetDocuments();
		foreach (ISymUnmanagedDocument symDocument in documents)
		{
			ISymUnmanagedMethod[] methodsInDocument = _symReader.GetMethodsInDocument(symDocument);
			foreach (ISymUnmanagedMethod symUnmanagedMethod in methodsInDocument)
			{
				_writer.WriteStartElement("method");
				WriteMethodAttributes(symUnmanagedMethod.GetToken(), isReference: true);
				ISymUnmanagedDocument[] documentsForMethod = symUnmanagedMethod.GetDocumentsForMethod();
				foreach (ISymUnmanagedDocument document in documentsForMethod)
				{
					_writer.WriteStartElement("document");
					((ISymEncUnmanagedMethod)symUnmanagedMethod).GetSourceExtentInDocument(document, out var startLine, out var endLine);
					_writer.WriteAttributeString("startLine", startLine.ToString());
					_writer.WriteAttributeString("endLine", endLine.ToString());
					_writer.WriteEndElement();
				}
				_writer.WriteEndElement();
			}
		}
		_writer.WriteEndElement();
	}

	private void WriteEntryPoint()
	{
		int userEntryPoint = _symReader.GetUserEntryPoint();
		if (userEntryPoint != 0)
		{
			_writer.WriteStartElement("entryPoint");
			WriteMethodAttributes(userEntryPoint, isReference: true);
			_writer.WriteEndElement();
		}
	}

	private void WriteMethodAttributes(int token, bool isReference)
	{
		if ((_options & PdbToXmlOptions.ResolveTokens) != PdbToXmlOptions.Default)
		{
			Handle handle = MetadataTokens.Handle(token);
			try
			{
				switch (handle.Kind)
				{
				case HandleKind.MethodDefinition:
					WriteResolvedToken((MethodDefinitionHandle)handle, isReference);
					break;
				case HandleKind.MemberReference:
					WriteResolvedToken((MemberReferenceHandle)handle);
					break;
				default:
					WriteToken(token);
					_writer.WriteAttributeString("error", $"Unexpected token type: {handle.Kind}");
					break;
				}
			}
			catch (BadImageFormatException ex)
			{
				if ((_options & PdbToXmlOptions.ThrowOnError) != PdbToXmlOptions.Default)
				{
					throw;
				}
				WriteToken(token);
				_writer.WriteAttributeString("metadata-error", ex.Message);
			}
		}
		if ((_options & PdbToXmlOptions.IncludeTokens) != PdbToXmlOptions.Default)
		{
			WriteToken(token);
		}
	}

	private static string GetQualifiedMethodName(MetadataReader metadataReader, MethodDefinitionHandle methodHandle)
	{
		MethodDefinition methodDefinition = metadataReader.GetMethodDefinition(methodHandle);
		TypeDefinitionHandle declaringType = methodDefinition.GetDeclaringType();
		string fullTypeName = GetFullTypeName(metadataReader, declaringType);
		string text = metadataReader.GetString(methodDefinition.Name);
		if (fullTypeName == null)
		{
			return text;
		}
		return fullTypeName + "." + text;
	}

	private void WriteResolvedToken(MethodDefinitionHandle methodHandle, bool isReference)
	{
		MethodDefinition methodDefinition = _metadataReader.GetMethodDefinition(methodHandle);
		TypeDefinitionHandle declaringType = methodDefinition.GetDeclaringType();
		string fullTypeName = GetFullTypeName(_metadataReader, declaringType);
		if (fullTypeName != null)
		{
			_writer.WriteAttributeString(isReference ? "declaringType" : "containingType", fullTypeName);
		}
		_writer.WriteAttributeString(isReference ? "methodName" : "name", _metadataReader.GetString(methodDefinition.Name));
		string[] array = Enumerable.ToArray<string>(Enumerable.Select(Enumerable.Where(Enumerable.Select((IEnumerable<ParameterHandle>)methodDefinition.GetParameters(), (ParameterHandle paramHandle) => new
		{
			paramHandle = paramHandle,
			parameter = _metadataReader.GetParameter(paramHandle)
		}), _003C_003Eh__TransparentIdentifier0 => _003C_003Eh__TransparentIdentifier0.parameter.SequenceNumber > 0), _003C_003Eh__TransparentIdentifier0 => (!_003C_003Eh__TransparentIdentifier0.parameter.Name.IsNil) ? _metadataReader.GetString(_003C_003Eh__TransparentIdentifier0.parameter.Name) : "?"));
		if (array.Length != 0)
		{
			_writer.WriteAttributeString("parameterNames", string.Join(", ", array));
		}
	}

	private void WriteResolvedToken(MemberReferenceHandle memberRefHandle)
	{
		MemberReference memberReference = _metadataReader.GetMemberReference(memberRefHandle);
		string fullTypeName = GetFullTypeName(_metadataReader, memberReference.Parent);
		if (fullTypeName != null)
		{
			_writer.WriteAttributeString("declaringType", fullTypeName);
		}
		_writer.WriteAttributeString("methodName", _metadataReader.GetString(memberReference.Name));
	}

	private static bool IsNested(TypeAttributes flags)
	{
		return (flags & TypeAttributes.NestedFamANDAssem) != 0;
	}

	private static string GetFullTypeName(MetadataReader metadataReader, EntityHandle handle)
	{
		if (handle.IsNil)
		{
			return null;
		}
		if (handle.Kind == HandleKind.TypeDefinition)
		{
			TypeDefinition typeDefinition = metadataReader.GetTypeDefinition((TypeDefinitionHandle)handle);
			string text = metadataReader.GetString(typeDefinition.Name);
			while (IsNested(typeDefinition.Attributes))
			{
				TypeDefinition typeDefinition2 = metadataReader.GetTypeDefinition(typeDefinition.GetDeclaringType());
				text = metadataReader.GetString(typeDefinition2.Name) + "+" + text;
				typeDefinition = typeDefinition2;
			}
			if (typeDefinition.Namespace.IsNil)
			{
				return text;
			}
			return metadataReader.GetString(typeDefinition.Namespace) + "." + text;
		}
		if (handle.Kind == HandleKind.TypeReference)
		{
			TypeReference typeReference = metadataReader.GetTypeReference((TypeReferenceHandle)handle);
			string text2 = metadataReader.GetString(typeReference.Name);
			if (typeReference.Namespace.IsNil)
			{
				return text2;
			}
			return metadataReader.GetString(typeReference.Namespace) + "." + text2;
		}
		return "<" + string.Format(PdbToXmlResources.UnexpectedTokenKind, AsToken(metadataReader.GetToken(handle))) + ">";
	}

	private void WriteSourceServerInformation()
	{
		byte[] rawSourceServerData = _symReader.GetRawSourceServerData();
		if (rawSourceServerData != null)
		{
			_writer.WriteStartElement("srcsvr");
			WriteCData(rawSourceServerData, Encoding.UTF8);
			_writer.WriteEndElement();
		}
	}

	private void WriteSourceLinkInformation()
	{
		byte[] array = (_symReader as ISymUnmanagedReader5)?.GetRawSourceLinkData();
		if (array != null)
		{
			_writer.WriteStartElement("sourceLink");
			WriteCData(array, Encoding.UTF8);
			_writer.WriteEndElement();
		}
	}

	private void WriteCData(byte[] bytes, Encoding encoding)
	{
		string text = encoding.GetString(bytes, 0, bytes.Length);
		try
		{
			_writer.WriteCData(text);
		}
		catch (ArgumentException)
		{
			try
			{
				_writer.WriteValue(text);
			}
			catch (ArgumentException)
			{
				_writer.WriteAttributeString("encoding", "base64");
				_writer.WriteBase64(bytes, 0, bytes.Length);
			}
		}
	}

	private void WriteToken(int token)
	{
		_writer.WriteAttributeString("token", AsToken(token));
	}

	internal static string AsToken(int i)
	{
		return string.Format(CultureInfo.InvariantCulture, "0x{0:x}", i);
	}

	internal static string AsILOffset(int i)
	{
		return string.Format(CultureInfo.InvariantCulture, "0x{0:x}", i);
	}

	internal static string CultureInvariantToString(int input)
	{
		return input.ToString(CultureInfo.InvariantCulture);
	}
}
