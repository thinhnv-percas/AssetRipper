using System;
using System.Collections.Generic;
using System.Text;
using ICSharpCode.NRefactory.Semantics;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation;

internal sealed class BlobReader
{
	private byte[] buffer;

	private int position;

	private readonly IAssembly currentResolvedAssembly;

	internal static int GetBlobHashCode(byte[] blob)
	{
		int num = 0;
		foreach (byte b in blob)
		{
			num *= 257;
			num += b;
		}
		return num;
	}

	internal static bool BlobEquals(byte[] a, byte[] b)
	{
		if (a.Length != b.Length)
		{
			return false;
		}
		for (int i = 0; i < a.Length; i++)
		{
			if (a[i] != b[i])
			{
				return false;
			}
		}
		return true;
	}

	public BlobReader(byte[] buffer, IAssembly currentResolvedAssembly)
	{
		if (buffer == null)
		{
			throw new ArgumentNullException("buffer");
		}
		this.buffer = buffer;
		this.currentResolvedAssembly = currentResolvedAssembly;
	}

	public byte ReadByte()
	{
		return buffer[position++];
	}

	public sbyte ReadSByte()
	{
		return (sbyte)ReadByte();
	}

	public byte[] ReadBytes(int length)
	{
		byte[] array = new byte[length];
		Buffer.BlockCopy(buffer, position, array, 0, length);
		position += length;
		return array;
	}

	public ushort ReadUInt16()
	{
		ushort result = (ushort)(buffer[position] | (buffer[position + 1] << 8));
		position += 2;
		return result;
	}

	public short ReadInt16()
	{
		return (short)ReadUInt16();
	}

	public uint ReadUInt32()
	{
		uint result = (uint)(buffer[position] | (buffer[position + 1] << 8) | (buffer[position + 2] << 16) | (buffer[position + 3] << 24));
		position += 4;
		return result;
	}

	public int ReadInt32()
	{
		return (int)ReadUInt32();
	}

	public ulong ReadUInt64()
	{
		uint num = ReadUInt32();
		uint num2 = ReadUInt32();
		return ((ulong)num2 << 32) | num;
	}

	public long ReadInt64()
	{
		return (long)ReadUInt64();
	}

	public uint ReadCompressedUInt32()
	{
		byte b = ReadByte();
		if ((b & 0x80) == 0)
		{
			return b;
		}
		if ((b & 0x40) == 0)
		{
			return (uint)(((b & -129) << 8) | ReadByte());
		}
		return (uint)(((b & -193) << 24) | (ReadByte() << 16) | (ReadByte() << 8) | ReadByte());
	}

	public float ReadSingle()
	{
		if (!BitConverter.IsLittleEndian)
		{
			byte[] array = ReadBytes(4);
			Array.Reverse(array);
			return BitConverter.ToSingle(array, 0);
		}
		float result = BitConverter.ToSingle(buffer, position);
		position += 4;
		return result;
	}

	public double ReadDouble()
	{
		if (!BitConverter.IsLittleEndian)
		{
			byte[] array = ReadBytes(8);
			Array.Reverse(array);
			return BitConverter.ToDouble(array, 0);
		}
		double result = BitConverter.ToDouble(buffer, position);
		position += 8;
		return result;
	}

	public ResolveResult ReadFixedArg(IType argType)
	{
		if (argType.Kind == TypeKind.Array)
		{
			if (((ArrayType)argType).Dimensions != 1)
			{
				return ErrorResolveResult.UnknownError;
			}
			IType elementType = ((ArrayType)argType).ElementType;
			uint num = ReadUInt32();
			if (num == uint.MaxValue)
			{
				return new ConstantResolveResult(argType, null);
			}
			ResolveResult[] array = new ResolveResult[num];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = ReadElem(elementType);
				if (array[i].IsError)
				{
					return ErrorResolveResult.UnknownError;
				}
			}
			IType type = currentResolvedAssembly.Compilation.FindType(KnownTypeCode.Int32);
			ResolveResult[] sizeArguments = new ResolveResult[1]
			{
				new ConstantResolveResult(type, array.Length)
			};
			return new ArrayCreateResolveResult(argType, sizeArguments, array);
		}
		return ReadElem(argType);
	}

	public ResolveResult ReadElem(IType elementType)
	{
		ITypeDefinition typeDefinition = ((elementType.Kind != TypeKind.Enum) ? elementType.GetDefinition() : elementType.GetDefinition().EnumUnderlyingType.GetDefinition());
		if (typeDefinition == null)
		{
			return ErrorResolveResult.UnknownError;
		}
		KnownTypeCode knownTypeCode = typeDefinition.KnownTypeCode;
		switch (knownTypeCode)
		{
		case KnownTypeCode.Object:
		{
			IType argType = ReadCustomAttributeFieldOrPropType();
			ResolveResult resolveResult = ReadFixedArg(argType);
			if (resolveResult.IsCompileTimeConstant && resolveResult.ConstantValue == null)
			{
				return new ConstantResolveResult(elementType, null);
			}
			return new ConversionResolveResult(elementType, resolveResult, Conversion.BoxingConversion);
		}
		case KnownTypeCode.Type:
			return new TypeOfResolveResult(typeDefinition, ReadType());
		default:
			return new ConstantResolveResult(elementType, ReadElemValue(knownTypeCode));
		}
	}

	private object ReadElemValue(KnownTypeCode typeCode)
	{
		return typeCode switch
		{
			KnownTypeCode.Boolean => ReadByte() != 0, 
			KnownTypeCode.Char => (char)ReadUInt16(), 
			KnownTypeCode.SByte => ReadSByte(), 
			KnownTypeCode.Byte => ReadByte(), 
			KnownTypeCode.Int16 => ReadInt16(), 
			KnownTypeCode.UInt16 => ReadUInt16(), 
			KnownTypeCode.Int32 => ReadInt32(), 
			KnownTypeCode.UInt32 => ReadUInt32(), 
			KnownTypeCode.Int64 => ReadInt64(), 
			KnownTypeCode.UInt64 => ReadUInt64(), 
			KnownTypeCode.Single => ReadSingle(), 
			KnownTypeCode.Double => ReadDouble(), 
			KnownTypeCode.String => ReadSerString(), 
			_ => throw new NotSupportedException(), 
		};
	}

	public string ReadSerString()
	{
		if (buffer[position] == byte.MaxValue)
		{
			position++;
			return null;
		}
		int num = (int)ReadCompressedUInt32();
		if (num == 0)
		{
			return string.Empty;
		}
		string result = Encoding.UTF8.GetString(buffer, position, (buffer[position + num - 1] == 0) ? (num - 1) : num);
		position += num;
		return result;
	}

	public KeyValuePair<IMember, ResolveResult> ReadNamedArg(IType attributeType)
	{
		byte b = ReadByte();
		SymbolKind memberType;
		switch (b)
		{
		case 83:
			memberType = SymbolKind.Field;
			break;
		case 84:
			memberType = SymbolKind.Property;
			break;
		default:
			throw new NotSupportedException($"Custom member type 0x{b:x} is not supported.");
		}
		IType type = ReadCustomAttributeFieldOrPropType();
		string name = ReadSerString();
		ResolveResult value = ReadFixedArg(type);
		IMember key = null;
		foreach (IMember member in attributeType.GetMembers((IUnresolvedMember m) => m.SymbolKind == memberType && m.Name == name))
		{
			if (member.ReturnType.Equals(type))
			{
				key = member;
			}
		}
		return new KeyValuePair<IMember, ResolveResult>(key, value);
	}

	private IType ReadCustomAttributeFieldOrPropType()
	{
		ICompilation compilation = currentResolvedAssembly.Compilation;
		byte b = ReadByte();
		return b switch
		{
			2 => compilation.FindType(KnownTypeCode.Boolean), 
			3 => compilation.FindType(KnownTypeCode.Char), 
			4 => compilation.FindType(KnownTypeCode.SByte), 
			5 => compilation.FindType(KnownTypeCode.Byte), 
			6 => compilation.FindType(KnownTypeCode.Int16), 
			7 => compilation.FindType(KnownTypeCode.UInt16), 
			8 => compilation.FindType(KnownTypeCode.Int32), 
			9 => compilation.FindType(KnownTypeCode.UInt32), 
			10 => compilation.FindType(KnownTypeCode.Int64), 
			11 => compilation.FindType(KnownTypeCode.UInt64), 
			12 => compilation.FindType(KnownTypeCode.Single), 
			13 => compilation.FindType(KnownTypeCode.Double), 
			14 => compilation.FindType(KnownTypeCode.String), 
			29 => new ArrayType(compilation, ReadCustomAttributeFieldOrPropType()), 
			80 => compilation.FindType(KnownTypeCode.Type), 
			81 => compilation.FindType(KnownTypeCode.Object), 
			85 => ReadType(), 
			_ => throw new NotSupportedException($"Custom attribute type 0x{b:x} is not supported."), 
		};
	}

	private IType ReadType()
	{
		string reflectionTypeName = ReadSerString();
		ITypeReference typeReference = ReflectionHelper.ParseReflectionName(reflectionTypeName);
		IType type = typeReference.Resolve(new SimpleTypeResolveContext(currentResolvedAssembly));
		if (type.Kind != TypeKind.Unknown)
		{
			return type;
		}
		ITypeDefinition definition = currentResolvedAssembly.Compilation.FindType(KnownTypeCode.Object).GetDefinition();
		if (definition != null)
		{
			return typeReference.Resolve(new SimpleTypeResolveContext(definition.ParentAssembly));
		}
		return type;
	}
}
