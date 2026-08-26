using ICSharpCode.NRefactory.Semantics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICSharpCode.NRefactory.TypeSystem.Implementation
{
	public sealed class BlobReader
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
			int result = buffer[position] | (buffer[position + 1] << 8) | (buffer[position + 2] << 16) | (buffer[position + 3] << 24);
			position += 4;
			return (uint)result;
		}

		public int ReadInt32()
		{
			return (int)ReadUInt32();
		}

		public ulong ReadUInt64()
		{
			uint num = ReadUInt32();
			return ((ulong)ReadUInt32() << 32) | num;
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
			ITypeDefinition typeDefinition = (elementType.Kind != TypeKind.Enum) ? elementType.GetDefinition() : elementType.GetDefinition().EnumUnderlyingType.GetDefinition();
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
			switch (typeCode)
			{
			case KnownTypeCode.Boolean:
				return ReadByte() != 0;
			case KnownTypeCode.Char:
				return (char)ReadUInt16();
			case KnownTypeCode.SByte:
				return ReadSByte();
			case KnownTypeCode.Byte:
				return ReadByte();
			case KnownTypeCode.Int16:
				return ReadInt16();
			case KnownTypeCode.UInt16:
				return ReadUInt16();
			case KnownTypeCode.Int32:
				return ReadInt32();
			case KnownTypeCode.UInt32:
				return ReadUInt32();
			case KnownTypeCode.Int64:
				return ReadInt64();
			case KnownTypeCode.UInt64:
				return ReadUInt64();
			case KnownTypeCode.Single:
				return ReadSingle();
			case KnownTypeCode.Double:
				return ReadDouble();
			case KnownTypeCode.String:
				return ReadSerString();
			default:
				throw new NotSupportedException();
			}
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
			string @string = Encoding.UTF8.GetString(buffer, position, (buffer[position + num - 1] == 0) ? (num - 1) : num);
			position += num;
			return @string;
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
			switch (b)
			{
			case 2:
				return compilation.FindType(KnownTypeCode.Boolean);
			case 3:
				return compilation.FindType(KnownTypeCode.Char);
			case 4:
				return compilation.FindType(KnownTypeCode.SByte);
			case 5:
				return compilation.FindType(KnownTypeCode.Byte);
			case 6:
				return compilation.FindType(KnownTypeCode.Int16);
			case 7:
				return compilation.FindType(KnownTypeCode.UInt16);
			case 8:
				return compilation.FindType(KnownTypeCode.Int32);
			case 9:
				return compilation.FindType(KnownTypeCode.UInt32);
			case 10:
				return compilation.FindType(KnownTypeCode.Int64);
			case 11:
				return compilation.FindType(KnownTypeCode.UInt64);
			case 12:
				return compilation.FindType(KnownTypeCode.Single);
			case 13:
				return compilation.FindType(KnownTypeCode.Double);
			case 14:
				return compilation.FindType(KnownTypeCode.String);
			case 29:
				return new ArrayType(compilation, ReadCustomAttributeFieldOrPropType());
			case 80:
				return compilation.FindType(KnownTypeCode.Type);
			case 81:
				return compilation.FindType(KnownTypeCode.Object);
			case 85:
				return ReadType();
			default:
				throw new NotSupportedException($"Custom attribute type 0x{b:x} is not supported.");
			}
		}

		private IType ReadType()
		{
			ITypeReference typeReference = ReflectionHelper.ParseReflectionName(ReadSerString());
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
}
