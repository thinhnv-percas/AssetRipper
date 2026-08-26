using System;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace Microsoft.DiaSymReader.PortablePdb;

internal static class MetadataUtilities
{
	public const SignatureTypeCode SignatureTypeCode_ValueType = (SignatureTypeCode)17;

	public const SignatureTypeCode SignatureTypeCode_Class = (SignatureTypeCode)18;

	public static readonly Guid MethodSteppingInformationBlobId = new Guid("54FD2AC5-E925-401A-9C2A-F94F171072F8");

	public static readonly Guid VbDefaultNamespaceId = new Guid("58b2eab6-209f-4e4e-a22c-b2d0f910c782");

	public static readonly Guid EmbeddedSourceId = new Guid("0E8A571B-6926-466E-B4AD-8AB04611F5FE");

	public static readonly Guid SourceLinkId = new Guid("CC110556-A091-4D38-9FEC-25AB9A351A6A");

	public static int MethodDefToken(int rowId)
	{
		return 0x6000000 | rowId;
	}

	public static int GetRowId(int token)
	{
		return token & 0xFFFFFF;
	}

	public static bool IsMethodToken(int token)
	{
		return (uint)token >> 24 == 6;
	}

	internal static int GetTypeDefOrRefOrSpecCodedIndex(EntityHandle typeHandle)
	{
		int num = 0;
		switch (typeHandle.Kind)
		{
		case HandleKind.TypeDefinition:
			num = 0;
			break;
		case HandleKind.TypeReference:
			num = 1;
			break;
		case HandleKind.TypeSpecification:
			num = 2;
			break;
		}
		return (MetadataTokens.GetRowNumber(typeHandle) << 2) | num;
	}

	internal static BlobHandle GetCustomDebugInformation(this MetadataReader reader, EntityHandle parent, Guid kind)
	{
		foreach (CustomDebugInformationHandle item in reader.GetCustomDebugInformation(parent))
		{
			CustomDebugInformation customDebugInformation = reader.GetCustomDebugInformation(item);
			if (reader.GetGuid(customDebugInformation.Kind) == kind)
			{
				return customDebugInformation.Value;
			}
		}
		return default(BlobHandle);
	}
}
