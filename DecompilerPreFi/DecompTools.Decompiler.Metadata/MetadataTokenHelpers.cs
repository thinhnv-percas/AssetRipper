using System;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;

namespace DecompTools.Decompiler.Metadata;

public static class MetadataTokenHelpers
{
	public static EntityHandle? TryAsEntityHandle(int metadataToken)
	{
		if (metadataToken < 0)
		{
			return null;
		}
		try
		{
			return MetadataTokens.EntityHandle(metadataToken);
		}
		catch (ArgumentException)
		{
			return null;
		}
	}

	public static EntityHandle EntityHandleOrNil(int metadataToken)
	{
		if (metadataToken < 0)
		{
			return MetadataTokens.EntityHandle(0);
		}
		try
		{
			return MetadataTokens.EntityHandle(metadataToken);
		}
		catch (ArgumentException)
		{
			return MetadataTokens.EntityHandle(0);
		}
	}
}
