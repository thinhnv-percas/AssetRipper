using System;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace Microsoft.DiaSymReader.PortablePdb;

[ComVisible(false)]
public sealed class SymDocument : ISymUnmanagedDocument
{
	private static Guid s_CSharpGuid = new Guid("3f5162f8-07c6-11d3-9053-00c04fa302a1");

	private static Guid s_visualBasicGuid = new Guid("3a12d0b8-c26c-11d0-b442-00a0244a1dd2");

	private static Guid s_FSharpGuid = new Guid("ab4f38c9-b6e6-43ba-be3b-58080b2ccce3");

	private static Guid s_sha1Guid = new Guid("ff1816ec-aa5e-4d10-87f7-6f4963833460");

	private static Guid s_sha256Guid = new Guid("8829d00f-11b8-4213-878b-770e8597ac16");

	private static Guid s_vendorMicrosoftGuid = new Guid("994b45c4-e6e9-11d2-903f-00c04fa302a1");

	private static Guid s_documentTypeGuid = new Guid("5a869d0b-6611-11d3-bd2a-0000f80849bd");

	internal DocumentHandle Handle { get; }

	internal PortablePdbReader PdbReader { get; }

	internal SymReader SymReader => PdbReader.SymReader;

	internal SymDocument(PortablePdbReader pdbReader, DocumentHandle documentHandle)
	{
		PdbReader = pdbReader;
		Handle = documentHandle;
	}

	internal DocumentId GetId()
	{
		return PdbReader.GetDocumentId(Handle);
	}

	public int FindClosestLine(int line, out int closestLine)
	{
		int num = int.MaxValue;
		MethodMap methodMap = SymReader.GetMethodMap();
		foreach (MethodLineExtent item in SymReader.GetMethodExtents().EnumerateContainingOrClosestFollowingMethodExtents(GetId(), line))
		{
			if (item.MinLine >= num)
			{
				continue;
			}
			MethodMap.MethodInfo info = methodMap.GetInfo(item.Method);
			MethodDebugInformation methodDebugInformation = SymReader.GetReader(info.Version).MetadataReader.GetMethodDebugInformation(info.Handle);
			if (!SymReader.TryGetLineDeltas(item.Method, out var deltas))
			{
				deltas = default(MethodLineDeltas);
			}
			int num2 = 0;
			foreach (SequencePoint sequencePoint in methodDebugInformation.GetSequencePoints())
			{
				if (sequencePoint.IsHidden || sequencePoint.Document != Handle)
				{
					num2++;
					continue;
				}
				int num3 = sequencePoint.StartLine + deltas.GetDeltaForSequencePoint(num2);
				if (num3 >= line && num3 < num)
				{
					num = num3;
				}
				num2++;
			}
		}
		if (num < int.MaxValue)
		{
			closestLine = num;
			return 0;
		}
		closestLine = 0;
		return -2147467259;
	}

	public int GetChecksum(int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] byte[] checksum)
	{
		if (SymReader.Version > 1)
		{
			count = 0;
			return 1;
		}
		Document document = PdbReader.MetadataReader.GetDocument(Handle);
		if (document.Hash.IsNil)
		{
			count = 0;
			return 1;
		}
		return InteropUtilities.BytesToBuffer(PdbReader.MetadataReader.GetBlobBytes(document.Hash), bufferLength, out count, checksum);
	}

	public int GetChecksumAlgorithmId(ref Guid algorithm)
	{
		if (SymReader.Version > 1)
		{
			algorithm = default(Guid);
			return 1;
		}
		Document document = PdbReader.MetadataReader.GetDocument(Handle);
		algorithm = PdbReader.MetadataReader.GetGuid(document.HashAlgorithm);
		return 0;
	}

	public int GetDocumentType(ref Guid documentType)
	{
		documentType = s_documentTypeGuid;
		return 0;
	}

	public int GetLanguage(ref Guid language)
	{
		Document document = PdbReader.MetadataReader.GetDocument(Handle);
		language = PdbReader.MetadataReader.GetGuid(document.Language);
		return 0;
	}

	public int GetLanguageVendor(ref Guid vendor)
	{
		Document document = PdbReader.MetadataReader.GetDocument(Handle);
		PdbReader.MetadataReader.GetGuid(document.Language);
		vendor = s_vendorMicrosoftGuid;
		return 0;
	}

	public int GetSourceLength(out int length)
	{
		length = GetEmbeddedSourceBlobReader().Length;
		return 0;
	}

	public int GetSourceRange(int startLine, int startColumn, int endLine, int endColumn, int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] byte[] source)
	{
		count = 0;
		if (startLine != 0 || startColumn != 0 || (uint)endLine < 2147483647u || (uint)endColumn < 2147483647u)
		{
			return -2147024809;
		}
		if (bufferLength < 0)
		{
			return -2147024809;
		}
		if (source == null && bufferLength > 0)
		{
			return -2147024809;
		}
		BlobReader embeddedSourceBlobReader = GetEmbeddedSourceBlobReader();
		if (embeddedSourceBlobReader.Length == 0)
		{
			return 1;
		}
		count = Math.Min(bufferLength, embeddedSourceBlobReader.Length);
		embeddedSourceBlobReader.ReadBytes(count, source, 0);
		return 0;
	}

	public int GetUrl(int bufferLength, out int count, [In][Out][MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] char[] url)
	{
		return InteropUtilities.StringToBuffer(PdbReader.MetadataReader.GetString(PdbReader.MetadataReader.GetDocument(Handle).Name), bufferLength, out count, url);
	}

	public int HasEmbeddedSource(out bool value)
	{
		value = GetEmbeddedSourceBlobReader().Length > 0;
		return 0;
	}

	private BlobReader GetEmbeddedSourceBlobReader()
	{
		BlobHandle customDebugInformation = PdbReader.MetadataReader.GetCustomDebugInformation(Handle, MetadataUtilities.EmbeddedSourceId);
		if (!customDebugInformation.IsNil)
		{
			return PdbReader.MetadataReader.GetBlobReader(customDebugInformation);
		}
		return default(BlobReader);
	}
}
