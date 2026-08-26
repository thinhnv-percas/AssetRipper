using System.Reflection.Metadata;

namespace DecompTools.Decompiler.Metadata;

public static class SignatureBlobComparer
{
	public static bool EqualsMethodSignature(BlobReader a, BlobReader b, MetadataReader contextForA, MetadataReader contextForB)
	{
		return EqualsMethodSignature(ref a, ref b, contextForA, contextForB);
	}

	private static bool EqualsMethodSignature(ref BlobReader a, ref BlobReader b, MetadataReader contextForA, MetadataReader contextForB)
	{
		SignatureHeader signatureHeader;
		if (a.RemainingBytes == 0 || b.RemainingBytes == 0 || (signatureHeader = a.ReadSignatureHeader()) != b.ReadSignatureHeader())
		{
			return false;
		}
		if (signatureHeader.IsGeneric && !IsSameCompressedInteger(ref a, ref b, out var _))
		{
			return false;
		}
		if (!IsSameCompressedInteger(ref a, ref b, out var value2))
		{
			return false;
		}
		if (!IsSameCompressedInteger(ref a, ref b, out var value3))
		{
			return false;
		}
		if (!TypesAreEqual(ref a, ref b, contextForA, contextForB, value3))
		{
			return false;
		}
		checked
		{
			int i;
			for (i = 0; i < value2; i++)
			{
				if (!IsSameCompressedInteger(ref a, ref b, out value3))
				{
					return false;
				}
				if (value3 == 65)
				{
					break;
				}
				if (!TypesAreEqual(ref a, ref b, contextForA, contextForB, value3))
				{
					return false;
				}
			}
			for (; i < value2; i++)
			{
				if (!IsSameCompressedInteger(ref a, ref b, out value3))
				{
					return false;
				}
				if (!TypesAreEqual(ref a, ref b, contextForA, contextForB, value3))
				{
					return false;
				}
			}
			return true;
		}
	}

	public static bool EqualsTypeSignature(BlobReader a, BlobReader b, MetadataReader contextForA, MetadataReader contextForB)
	{
		return EqualsTypeSignature(ref a, ref b, contextForA, contextForB);
	}

	private static bool EqualsTypeSignature(ref BlobReader a, ref BlobReader b, MetadataReader contextForA, MetadataReader contextForB)
	{
		if (!IsSameCompressedInteger(ref a, ref b, out var value))
		{
			return false;
		}
		return TypesAreEqual(ref a, ref b, contextForA, contextForB, value);
	}

	private static bool IsSameCompressedInteger(ref BlobReader a, ref BlobReader b, out int value)
	{
		int value2;
		return a.TryReadCompressedInteger(out value) && b.TryReadCompressedInteger(out value2) && value == value2;
	}

	private static bool IsSameCompressedSignedInteger(ref BlobReader a, ref BlobReader b, out int value)
	{
		int value2;
		return a.TryReadCompressedSignedInteger(out value) && b.TryReadCompressedSignedInteger(out value2) && value == value2;
	}

	private static bool TypesAreEqual(ref BlobReader a, ref BlobReader b, MetadataReader contextForA, MetadataReader contextForB, int typeCode)
	{
		checked
		{
			int value;
			switch (typeCode)
			{
			case 1:
			case 2:
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 22:
			case 24:
			case 25:
			case 28:
				return true;
			case 15:
			case 16:
			case 29:
			case 69:
				if (!IsSameCompressedInteger(ref a, ref b, out typeCode))
				{
					return false;
				}
				if (!TypesAreEqual(ref a, ref b, contextForA, contextForB, typeCode))
				{
					return false;
				}
				return true;
			case 27:
				if (!EqualsMethodSignature(ref a, ref b, contextForA, contextForB))
				{
					return false;
				}
				return true;
			case 20:
			{
				if (!IsSameCompressedInteger(ref a, ref b, out typeCode))
				{
					return false;
				}
				if (!TypesAreEqual(ref a, ref b, contextForA, contextForB, typeCode))
				{
					return false;
				}
				if (!IsSameCompressedInteger(ref a, ref b, out value))
				{
					return false;
				}
				if (!IsSameCompressedInteger(ref a, ref b, out var value2))
				{
					return false;
				}
				for (int i = 0; i < value2; i++)
				{
					if (!IsSameCompressedInteger(ref a, ref b, out value))
					{
						return false;
					}
				}
				if (!IsSameCompressedInteger(ref a, ref b, out var value3))
				{
					return false;
				}
				for (int j = 0; j < value3; j++)
				{
					if (!IsSameCompressedSignedInteger(ref a, ref b, out value))
					{
						return false;
					}
				}
				return true;
			}
			case 31:
			case 32:
				if (!TypeHandleEquals(ref a, ref b, contextForA, contextForB))
				{
					return false;
				}
				if (!IsSameCompressedInteger(ref a, ref b, out typeCode))
				{
					return false;
				}
				if (!TypesAreEqual(ref a, ref b, contextForA, contextForB, typeCode))
				{
					return false;
				}
				return true;
			case 21:
			{
				if (!IsSameCompressedInteger(ref a, ref b, out typeCode))
				{
					return false;
				}
				if (!TypesAreEqual(ref a, ref b, contextForA, contextForB, typeCode))
				{
					return false;
				}
				if (!IsSameCompressedInteger(ref a, ref b, out var value4))
				{
					return false;
				}
				for (int k = 0; k < value4; k++)
				{
					if (!IsSameCompressedInteger(ref a, ref b, out typeCode))
					{
						return false;
					}
					if (!TypesAreEqual(ref a, ref b, contextForA, contextForB, typeCode))
					{
						return false;
					}
				}
				return true;
			}
			case 19:
			case 30:
				if (!IsSameCompressedInteger(ref a, ref b, out value))
				{
					return false;
				}
				return true;
			case 17:
			case 18:
				if (!TypeHandleEquals(ref a, ref b, contextForA, contextForB))
				{
					return false;
				}
				return true;
			default:
				return false;
			}
		}
	}

	private static bool TypeHandleEquals(ref BlobReader a, ref BlobReader b, MetadataReader contextForA, MetadataReader contextForB)
	{
		EntityHandle handle = a.ReadTypeHandle();
		EntityHandle handle2 = b.ReadTypeHandle();
		if (handle.IsNil || handle2.IsNil)
		{
			return false;
		}
		return handle.GetFullTypeName(contextForA) == handle2.GetFullTypeName(contextForB);
	}
}
