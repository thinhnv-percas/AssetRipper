using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace Microsoft.DiaSymReader.PortablePdb;

internal sealed class DocumentMap
{
	[DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
	internal struct DocumentInfo
	{
		public readonly DocumentHandle Handle;

		public readonly int Version;

		public readonly string FileName;

		public DocumentInfo(DocumentHandle handle, int version, string fileName)
		{
			Handle = handle;
			Version = version;
			FileName = fileName;
		}

		private object GetDebuggerDisplay()
		{
			return string.Format("'{0}' {1:X8} v{2}", new object[3]
			{
				FileName,
				MetadataTokens.GetToken(Handle),
				Version
			});
		}
	}

	private readonly MetadataReader _reader;

	private readonly Dictionary<string, (DocumentId Single, ImmutableArray<DocumentId> Multiple)> _map;

	private readonly List<DocumentInfo> _infos;

	public int DocumentCount => _infos.Count;

	public IReadOnlyList<DocumentInfo> Infos => _infos;

	public DocumentMap(MetadataReader reader)
	{
		_reader = reader;
		_infos = CreateBaselineDocumentInfos(reader);
		_map = Enumerable.Select<DocumentInfo, KeyValuePair<string, DocumentId>>((IEnumerable<DocumentInfo>)_infos, (Func<DocumentInfo, KeyValuePair<string, DocumentId>>)((DocumentInfo info) => KeyValuePair.Create(info.FileName, new DocumentId(MetadataTokens.GetRowNumber(info.Handle))))).GroupBy(StringComparer.OrdinalIgnoreCase);
	}

	private int GetInfoIndex(DocumentId documentId)
	{
		return documentId.Value - 1;
	}

	internal DocumentInfo GetInfo(DocumentId documentId)
	{
		return _infos[GetInfoIndex(documentId)];
	}

	private static bool DocumentFullPathEquals(MetadataReader reader, DocumentHandle handle, string fullPath, bool ignoreCase)
	{
		return reader.StringComparer.Equals(reader.GetDocument(handle).Name, fullPath, ignoreCase);
	}

	private static List<DocumentInfo> CreateBaselineDocumentInfos(MetadataReader reader)
	{
		List<DocumentInfo> list = new List<DocumentInfo>(reader.Documents.Count);
		foreach (DocumentHandle document in reader.Documents)
		{
			string fileName = GetFileName(reader, document);
			if (fileName != null)
			{
				list.Add(new DocumentInfo(document, 1, fileName));
			}
		}
		return list;
	}

	internal void Update(SymReader symReader, MetadataReader reader, int version, out ImmutableArray<DocumentId> handleToIdMap)
	{
		ImmutableArray<DocumentId>.Builder builder = ImmutableArray.CreateBuilder<DocumentId>(reader.Documents.Count);
		foreach (DocumentHandle document in reader.Documents)
		{
			string fileName = GetFileName(reader, document);
			if (fileName == null)
			{
				builder.Add(default(DocumentId));
				continue;
			}
			DocumentId documentId = default(DocumentId);
			DocumentInfo documentInfo = new DocumentInfo(document, version, fileName);
			if (!_map.TryGetValue(fileName, out (DocumentId, ImmutableArray<DocumentId>) value))
			{
				_infos.Add(documentInfo);
				documentId = new DocumentId(_infos.Count);
				_map.Add(fileName, (documentId, default(ImmutableArray<DocumentId>)));
			}
			else
			{
				string fullPath = reader.GetString(reader.GetDocument(document).Name);
				if (value.Item2.IsDefault)
				{
					int infoIndex = GetInfoIndex(value.Item1);
					DocumentInfo documentInfo2 = _infos[infoIndex];
					if (DocumentFullPathEquals(symReader.GetReader(documentInfo2.Version).MetadataReader, documentInfo2.Handle, fullPath, ignoreCase: false))
					{
						_infos[infoIndex] = documentInfo;
						(documentId, _) = value;
					}
					else
					{
						_infos.Add(documentInfo);
						documentId = new DocumentId(_infos.Count);
						_map[fileName] = (default(DocumentId), ImmutableArray.Create(value.Item1, documentId));
					}
				}
				else
				{
					bool flag = false;
					foreach (DocumentId item in value.Item2)
					{
						int infoIndex2 = GetInfoIndex(item);
						DocumentInfo documentInfo3 = _infos[infoIndex2];
						if (DocumentFullPathEquals(symReader.GetReader(documentInfo3.Version).MetadataReader, documentInfo3.Handle, fullPath, ignoreCase: false))
						{
							_infos[infoIndex2] = documentInfo;
							documentId = item;
							break;
						}
					}
					if (!flag)
					{
						_infos.Add(documentInfo);
						documentId = new DocumentId(_infos.Count);
						_map[fileName] = (default(DocumentId), value.Item2.Add(documentId));
					}
				}
			}
			builder.Add(documentId);
		}
		handleToIdMap = builder.MoveToImmutable();
	}

	private static string GetFileName(MetadataReader reader, DocumentHandle documentHandle)
	{
		Document document = reader.GetDocument(documentHandle);
		if (document.Name.IsNil)
		{
			return null;
		}
		BlobReader blobReader = reader.GetBlobReader(document.Name);
		if (!FileNameUtilities.IsDirectorySeparator((char)blobReader.ReadByte()))
		{
			return FileNameUtilities.GetFileName(reader.GetString(document.Name));
		}
		BlobHandle handle = default(BlobHandle);
		while (blobReader.RemainingBytes > 0)
		{
			handle = blobReader.ReadBlobHandle();
		}
		if (handle.IsNil)
		{
			return string.Empty;
		}
		BlobReader blobReader2 = reader.GetBlobReader(handle);
		string text = blobReader2.ReadUTF8(blobReader2.Length);
		if (text.IndexOf('\0') >= 0)
		{
			return null;
		}
		return FileNameUtilities.GetFileName(text);
	}

	internal bool TryGetDocument(string fullPath, out DocumentId id)
	{
		string fileName = FileNameUtilities.GetFileName(fullPath);
		if (!_map.TryGetValue(fileName, out (DocumentId, ImmutableArray<DocumentId>) value))
		{
			id = default(DocumentId);
			return false;
		}
		if (value.Item2.IsDefault)
		{
			(id, _) = value;
			return true;
		}
		foreach (DocumentId item in value.Item2)
		{
			if (DocumentFullPathEquals(_reader, GetInfo(item).Handle, fullPath, ignoreCase: false))
			{
				id = item;
				return true;
			}
		}
		foreach (DocumentId item2 in value.Item2)
		{
			if (DocumentFullPathEquals(_reader, GetInfo(item2).Handle, fullPath, ignoreCase: true))
			{
				id = item2;
				return true;
			}
		}
		foreach (DocumentId item3 in value.Item2)
		{
			if (GetInfo(item3).FileName == fileName)
			{
				id = item3;
				return true;
			}
		}
		id = value.Item2[0];
		return true;
	}
}
