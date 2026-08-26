using System;
using System.IO;

namespace DevX.Cecil.Metadata
{
	internal sealed class Utilities
	{
		internal delegate int TableRowCounter(int rid);

		private Utilities()
		{
		}

		public static int ReadCompressedInteger(byte[] data, int pos, out int start)
		{
			start = pos;
			int result;
			if ((data[pos] & 0x80) == 0)
			{
				result = data[pos];
				start++;
			}
			else if ((data[pos] & 0x40) == 0)
			{
				result = (data[start] & -129) << 8;
				result |= data[pos + 1];
				start += 2;
			}
			else
			{
				result = (data[start] & -193) << 24;
				result |= data[pos + 1] << 16;
				result |= data[pos + 2] << 8;
				result |= data[pos + 3];
				start += 4;
			}
			return result;
		}

		public static int ReadCompressedSignedInteger(byte[] data, int pos, out int start)
		{
			int num = ReadCompressedInteger(data, pos, out start) >> 1;
			if ((num & 1) == 0)
			{
				return num;
			}
			if (num < 64)
			{
				return num - 64;
			}
			if (num < 8192)
			{
				return num - 8192;
			}
			if (num < 268435456)
			{
				return num - 268435456;
			}
			return num - 536870912;
		}

		public static int WriteCompressedInteger(BinaryWriter writer, int value)
		{
			if (value < 128)
			{
				writer.Write((byte)value);
			}
			else if (value < 16384)
			{
				writer.Write((byte)(0x80 | (value >> 8)));
				writer.Write((byte)(value & 0xFF));
			}
			else
			{
				writer.Write((byte)((value >> 24) | 0xC0));
				writer.Write((byte)((value >> 16) & 0xFF));
				writer.Write((byte)((value >> 8) & 0xFF));
				writer.Write((byte)(value & 0xFF));
			}
			return (int)writer.BaseStream.Position;
		}

		public static MetadataToken GetMetadataToken(CodedIndex cidx, uint data)
		{
			uint num = 0u;
			switch (cidx)
			{
			case CodedIndex.TypeDefOrRef:
				num = data >> 2;
				switch (data & 3)
				{
				case 0u:
					return new MetadataToken(TokenType.TypeDef, num);
				case 1u:
					return new MetadataToken(TokenType.TypeRef, num);
				case 2u:
					return new MetadataToken(TokenType.TypeSpec, num);
				default:
					return MetadataToken.Zero;
				}
			case CodedIndex.HasConstant:
				num = data >> 2;
				switch (data & 3)
				{
				case 0u:
					return new MetadataToken(TokenType.Field, num);
				case 1u:
					return new MetadataToken(TokenType.Param, num);
				case 2u:
					return new MetadataToken(TokenType.Property, num);
				default:
					return MetadataToken.Zero;
				}
			case CodedIndex.HasCustomAttribute:
				num = data >> 5;
				switch (data & 0x1F)
				{
				case 0u:
					return new MetadataToken(TokenType.Method, num);
				case 1u:
					return new MetadataToken(TokenType.Field, num);
				case 2u:
					return new MetadataToken(TokenType.TypeRef, num);
				case 3u:
					return new MetadataToken(TokenType.TypeDef, num);
				case 4u:
					return new MetadataToken(TokenType.Param, num);
				case 5u:
					return new MetadataToken(TokenType.InterfaceImpl, num);
				case 6u:
					return new MetadataToken(TokenType.MemberRef, num);
				case 7u:
					return new MetadataToken(TokenType.Module, num);
				case 8u:
					return new MetadataToken(TokenType.Permission, num);
				case 9u:
					return new MetadataToken(TokenType.Property, num);
				case 10u:
					return new MetadataToken(TokenType.Event, num);
				case 11u:
					return new MetadataToken(TokenType.Signature, num);
				case 12u:
					return new MetadataToken(TokenType.ModuleRef, num);
				case 13u:
					return new MetadataToken(TokenType.TypeSpec, num);
				case 14u:
					return new MetadataToken(TokenType.Assembly, num);
				case 15u:
					return new MetadataToken(TokenType.AssemblyRef, num);
				case 16u:
					return new MetadataToken(TokenType.File, num);
				case 17u:
					return new MetadataToken(TokenType.ExportedType, num);
				case 18u:
					return new MetadataToken(TokenType.ManifestResource, num);
				case 19u:
					return new MetadataToken(TokenType.GenericParam, num);
				default:
					return MetadataToken.Zero;
				}
			case CodedIndex.HasFieldMarshal:
				num = data >> 1;
				switch (data & 1)
				{
				case 0u:
					return new MetadataToken(TokenType.Field, num);
				case 1u:
					return new MetadataToken(TokenType.Param, num);
				default:
					return MetadataToken.Zero;
				}
			case CodedIndex.HasDeclSecurity:
				num = data >> 2;
				switch (data & 3)
				{
				case 0u:
					return new MetadataToken(TokenType.TypeDef, num);
				case 1u:
					return new MetadataToken(TokenType.Method, num);
				case 2u:
					return new MetadataToken(TokenType.Assembly, num);
				default:
					return MetadataToken.Zero;
				}
			case CodedIndex.MemberRefParent:
				num = data >> 3;
				switch (data & 7)
				{
				case 0u:
					return new MetadataToken(TokenType.TypeDef, num);
				case 1u:
					return new MetadataToken(TokenType.TypeRef, num);
				case 2u:
					return new MetadataToken(TokenType.ModuleRef, num);
				case 3u:
					return new MetadataToken(TokenType.Method, num);
				case 4u:
					return new MetadataToken(TokenType.TypeSpec, num);
				default:
					return MetadataToken.Zero;
				}
			case CodedIndex.HasSemantics:
				num = data >> 1;
				switch (data & 1)
				{
				case 0u:
					return new MetadataToken(TokenType.Event, num);
				case 1u:
					return new MetadataToken(TokenType.Property, num);
				default:
					return MetadataToken.Zero;
				}
			case CodedIndex.MethodDefOrRef:
				num = data >> 1;
				switch (data & 1)
				{
				case 0u:
					return new MetadataToken(TokenType.Method, num);
				case 1u:
					return new MetadataToken(TokenType.MemberRef, num);
				default:
					return MetadataToken.Zero;
				}
			case CodedIndex.MemberForwarded:
				num = data >> 1;
				switch (data & 1)
				{
				case 0u:
					return new MetadataToken(TokenType.Field, num);
				case 1u:
					return new MetadataToken(TokenType.Method, num);
				default:
					return MetadataToken.Zero;
				}
			case CodedIndex.Implementation:
				num = data >> 2;
				switch (data & 3)
				{
				case 0u:
					return new MetadataToken(TokenType.File, num);
				case 1u:
					return new MetadataToken(TokenType.AssemblyRef, num);
				case 2u:
					return new MetadataToken(TokenType.ExportedType, num);
				default:
					return MetadataToken.Zero;
				}
			case CodedIndex.CustomAttributeType:
				num = data >> 3;
				switch (data & 7)
				{
				case 2u:
					return new MetadataToken(TokenType.Method, num);
				case 3u:
					return new MetadataToken(TokenType.MemberRef, num);
				default:
					return MetadataToken.Zero;
				}
			case CodedIndex.ResolutionScope:
				num = data >> 2;
				switch (data & 3)
				{
				case 0u:
					return new MetadataToken(TokenType.Module, num);
				case 1u:
					return new MetadataToken(TokenType.ModuleRef, num);
				case 2u:
					return new MetadataToken(TokenType.AssemblyRef, num);
				case 3u:
					return new MetadataToken(TokenType.TypeRef, num);
				default:
					return MetadataToken.Zero;
				}
			case CodedIndex.TypeOrMethodDef:
				num = data >> 1;
				switch (data & 1)
				{
				case 0u:
					return new MetadataToken(TokenType.TypeDef, num);
				case 1u:
					return new MetadataToken(TokenType.Method, num);
				default:
					return MetadataToken.Zero;
				}
			default:
				return MetadataToken.Zero;
			}
		}

		public static uint CompressMetadataToken(CodedIndex cidx, MetadataToken token)
		{
			uint result = 0u;
			if (token.RID == 0)
			{
				return result;
			}
			switch (cidx)
			{
			case CodedIndex.TypeDefOrRef:
				result = token.RID << 2;
				switch (token.TokenType)
				{
				case TokenType.TypeDef:
					return result | 0;
				case TokenType.TypeRef:
					return result | 1;
				case TokenType.TypeSpec:
					return result | 2;
				default:
					throw new MetadataFormatException("Non valid Token for TypeDefOrRef");
				}
			case CodedIndex.HasConstant:
				result = token.RID << 2;
				switch (token.TokenType)
				{
				case TokenType.Field:
					return result | 0;
				case TokenType.Param:
					return result | 1;
				case TokenType.Property:
					return result | 2;
				default:
					throw new MetadataFormatException("Non valid Token for HasConstant");
				}
			case CodedIndex.HasCustomAttribute:
				result = token.RID << 5;
				switch (token.TokenType)
				{
				case TokenType.Method:
					return result | 0;
				case TokenType.Field:
					return result | 1;
				case TokenType.TypeRef:
					return result | 2;
				case TokenType.TypeDef:
					return result | 3;
				case TokenType.Param:
					return result | 4;
				case TokenType.InterfaceImpl:
					return result | 5;
				case TokenType.MemberRef:
					return result | 6;
				case TokenType.Module:
					return result | 7;
				case TokenType.Permission:
					return result | 8;
				case TokenType.Property:
					return result | 9;
				case TokenType.Event:
					return result | 0xA;
				case TokenType.Signature:
					return result | 0xB;
				case TokenType.ModuleRef:
					return result | 0xC;
				case TokenType.TypeSpec:
					return result | 0xD;
				case TokenType.Assembly:
					return result | 0xE;
				case TokenType.AssemblyRef:
					return result | 0xF;
				case TokenType.File:
					return result | 0x10;
				case TokenType.ExportedType:
					return result | 0x11;
				case TokenType.ManifestResource:
					return result | 0x12;
				case TokenType.GenericParam:
					return result | 0x13;
				default:
					throw new MetadataFormatException("Non valid Token for HasCustomAttribute");
				}
			case CodedIndex.HasFieldMarshal:
				result = token.RID << 1;
				switch (token.TokenType)
				{
				case TokenType.Field:
					return result | 0;
				case TokenType.Param:
					return result | 1;
				default:
					throw new MetadataFormatException("Non valid Token for HasFieldMarshal");
				}
			case CodedIndex.HasDeclSecurity:
				result = token.RID << 2;
				switch (token.TokenType)
				{
				case TokenType.TypeDef:
					return result | 0;
				case TokenType.Method:
					return result | 1;
				case TokenType.Assembly:
					return result | 2;
				default:
					throw new MetadataFormatException("Non valid Token for HasDeclSecurity");
				}
			case CodedIndex.MemberRefParent:
				result = token.RID << 3;
				switch (token.TokenType)
				{
				case TokenType.TypeDef:
					return result | 0;
				case TokenType.TypeRef:
					return result | 1;
				case TokenType.ModuleRef:
					return result | 2;
				case TokenType.Method:
					return result | 3;
				case TokenType.TypeSpec:
					return result | 4;
				default:
					throw new MetadataFormatException("Non valid Token for MemberRefParent");
				}
			case CodedIndex.HasSemantics:
				result = token.RID << 1;
				switch (token.TokenType)
				{
				case TokenType.Event:
					return result | 0;
				case TokenType.Property:
					return result | 1;
				default:
					throw new MetadataFormatException("Non valid Token for HasSemantics");
				}
			case CodedIndex.MethodDefOrRef:
				result = token.RID << 1;
				switch (token.TokenType)
				{
				case TokenType.Method:
					return result | 0;
				case TokenType.MemberRef:
					return result | 1;
				default:
					throw new MetadataFormatException("Non valid Token for MethodDefOrRef");
				}
			case CodedIndex.MemberForwarded:
				result = token.RID << 1;
				switch (token.TokenType)
				{
				case TokenType.Field:
					return result | 0;
				case TokenType.Method:
					return result | 1;
				default:
					throw new MetadataFormatException("Non valid Token for MemberForwarded");
				}
			case CodedIndex.Implementation:
				result = token.RID << 2;
				switch (token.TokenType)
				{
				case TokenType.File:
					return result | 0;
				case TokenType.AssemblyRef:
					return result | 1;
				case TokenType.ExportedType:
					return result | 2;
				default:
					throw new MetadataFormatException("Non valid Token for Implementation");
				}
			case CodedIndex.CustomAttributeType:
				result = token.RID << 3;
				switch (token.TokenType)
				{
				case TokenType.Method:
					return result | 2;
				case TokenType.MemberRef:
					return result | 3;
				default:
					throw new MetadataFormatException("Non valid Token for CustomAttributeType");
				}
			case CodedIndex.ResolutionScope:
				result = token.RID << 2;
				switch (token.TokenType)
				{
				case TokenType.Module:
					return result | 0;
				case TokenType.ModuleRef:
					return result | 1;
				case TokenType.AssemblyRef:
					return result | 2;
				case TokenType.TypeRef:
					return result | 3;
				default:
					throw new MetadataFormatException("Non valid Token for ResolutionScope");
				}
			case CodedIndex.TypeOrMethodDef:
				result = token.RID << 1;
				switch (token.TokenType)
				{
				case TokenType.TypeDef:
					return result | 0;
				case TokenType.Method:
					return result | 1;
				default:
					throw new MetadataFormatException("Non valid Token for TypeOrMethodDef");
				}
			default:
				throw new MetadataFormatException("Non valid CodedIndex");
			}
		}

		internal static Type GetCorrespondingTable(TokenType t)
		{
			switch (t)
			{
			case TokenType.Assembly:
				return typeof(AssemblyTable);
			case TokenType.AssemblyRef:
				return typeof(AssemblyRefTable);
			case TokenType.CustomAttribute:
				return typeof(CustomAttributeTable);
			case TokenType.Event:
				return typeof(EventTable);
			case TokenType.ExportedType:
				return typeof(ExportedTypeTable);
			case TokenType.Field:
				return typeof(FieldTable);
			case TokenType.File:
				return typeof(FileTable);
			case TokenType.InterfaceImpl:
				return typeof(InterfaceImplTable);
			case TokenType.MemberRef:
				return typeof(MemberRefTable);
			case TokenType.Method:
				return typeof(MethodTable);
			case TokenType.Module:
				return typeof(ModuleTable);
			case TokenType.ModuleRef:
				return typeof(ModuleRefTable);
			case TokenType.Param:
				return typeof(ParamTable);
			case TokenType.Permission:
				return typeof(DeclSecurityTable);
			case TokenType.Property:
				return typeof(PropertyTable);
			case TokenType.Signature:
				return typeof(StandAloneSigTable);
			case TokenType.TypeDef:
				return typeof(TypeDefTable);
			case TokenType.TypeRef:
				return typeof(TypeRefTable);
			case TokenType.TypeSpec:
				return typeof(TypeSpecTable);
			default:
				return null;
			}
		}

		internal static int GetCodedIndexSize(CodedIndex ci, TableRowCounter rowCounter, int[] codedIndexCache)
		{
			int num = 0;
			int num2 = 0;
			if (codedIndexCache[(int)ci] != 0)
			{
				return codedIndexCache[(int)ci];
			}
			int num3 = 0;
			int[] array;
			switch (ci)
			{
			case CodedIndex.TypeDefOrRef:
				num = 2;
				array = new int[3]
				{
					2,
					1,
					27
				};
				break;
			case CodedIndex.HasConstant:
				num = 2;
				array = new int[3]
				{
					4,
					8,
					23
				};
				break;
			case CodedIndex.HasCustomAttribute:
				num = 5;
				array = new int[20]
				{
					6,
					4,
					1,
					2,
					8,
					9,
					10,
					0,
					14,
					23,
					20,
					17,
					26,
					27,
					32,
					35,
					38,
					39,
					40,
					42
				};
				break;
			case CodedIndex.HasFieldMarshal:
				num = 1;
				array = new int[2]
				{
					4,
					8
				};
				break;
			case CodedIndex.HasDeclSecurity:
				num = 2;
				array = new int[3]
				{
					2,
					6,
					32
				};
				break;
			case CodedIndex.MemberRefParent:
				num = 3;
				array = new int[5]
				{
					2,
					1,
					26,
					6,
					27
				};
				break;
			case CodedIndex.HasSemantics:
				num = 1;
				array = new int[2]
				{
					20,
					23
				};
				break;
			case CodedIndex.MethodDefOrRef:
				num = 1;
				array = new int[2]
				{
					6,
					10
				};
				break;
			case CodedIndex.MemberForwarded:
				num = 1;
				array = new int[2]
				{
					4,
					6
				};
				break;
			case CodedIndex.Implementation:
				num = 2;
				array = new int[3]
				{
					38,
					35,
					39
				};
				break;
			case CodedIndex.CustomAttributeType:
				num = 3;
				array = new int[2]
				{
					6,
					10
				};
				break;
			case CodedIndex.ResolutionScope:
				num = 2;
				array = new int[4]
				{
					0,
					26,
					35,
					1
				};
				break;
			case CodedIndex.TypeOrMethodDef:
				num = 1;
				array = new int[2]
				{
					2,
					6
				};
				break;
			default:
				throw new MetadataFormatException("Non valid CodedIndex");
			}
			for (int i = 0; i < array.Length; i++)
			{
				int num4 = rowCounter(array[i]);
				if (num4 > num2)
				{
					num2 = num4;
				}
			}
			return codedIndexCache[(int)ci] = ((num2 >= 1 << 16 - num) ? 4 : 2);
		}
	}
}
