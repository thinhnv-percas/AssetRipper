using System;
using System.Collections.Immutable;
using System.Reflection.Metadata;
using DecompTools.Decompiler.IL;
using DecompTools.Decompiler.Metadata;

namespace DecompTools.Decompiler.Disassembler;

internal class DisassemblerSignatureProvider : ISignatureTypeProvider<Action<ILNameSyntax>, GenericContext>, ISimpleTypeProvider<Action<ILNameSyntax>>, IConstructedTypeProvider<Action<ILNameSyntax>>, ISZArrayTypeProvider<Action<ILNameSyntax>>
{
	private readonly PEFile module;

	private readonly MetadataReader metadata;

	private readonly ITextOutput output;

	public DisassemblerSignatureProvider(PEFile module, ITextOutput output)
	{
		this.module = module ?? throw new ArgumentNullException("module");
		this.output = output ?? throw new ArgumentNullException("output");
		metadata = module.Metadata;
	}

	public Action<ILNameSyntax> GetArrayType(Action<ILNameSyntax> elementType, ArrayShape shape)
	{
		return checked(delegate(ILNameSyntax syntax)
		{
			ILNameSyntax obj = ((syntax == ILNameSyntax.SignatureNoNamedTypeParameters) ? syntax : ILNameSyntax.Signature);
			elementType(obj);
			output.Write('[');
			for (int i = 0; i < shape.Rank; i++)
			{
				if (i > 0)
				{
					output.Write(", ");
				}
				if (i < shape.LowerBounds.Length || i < shape.Sizes.Length)
				{
					int num = 0;
					if (i < shape.LowerBounds.Length)
					{
						num = shape.LowerBounds[i];
						output.Write(num.ToString());
					}
					output.Write("...");
					if (i < shape.Sizes.Length)
					{
						output.Write((num + shape.Sizes[i] - 1).ToString());
					}
				}
			}
			output.Write(']');
		});
	}

	public Action<ILNameSyntax> GetByReferenceType(Action<ILNameSyntax> elementType)
	{
		return delegate(ILNameSyntax syntax)
		{
			ILNameSyntax obj = ((syntax == ILNameSyntax.SignatureNoNamedTypeParameters) ? syntax : ILNameSyntax.Signature);
			elementType(obj);
			output.Write('&');
		};
	}

	public Action<ILNameSyntax> GetFunctionPointerType(MethodSignature<Action<ILNameSyntax>> signature)
	{
		return delegate(ILNameSyntax syntax)
		{
			output.Write("method ");
			signature.ReturnType(syntax);
			output.Write(" *(");
			for (int i = 0; i < signature.ParameterTypes.Length; i = checked(i + 1))
			{
				if (i > 0)
				{
					output.Write(", ");
				}
				signature.ParameterTypes[i](syntax);
			}
			output.Write(')');
		};
	}

	public Action<ILNameSyntax> GetGenericInstantiation(Action<ILNameSyntax> genericType, ImmutableArray<Action<ILNameSyntax>> typeArguments)
	{
		return delegate(ILNameSyntax syntax)
		{
			ILNameSyntax obj = ((syntax == ILNameSyntax.SignatureNoNamedTypeParameters) ? syntax : ILNameSyntax.Signature);
			genericType(obj);
			output.Write('<');
			for (int i = 0; i < typeArguments.Length; i = checked(i + 1))
			{
				if (i > 0)
				{
					output.Write(", ");
				}
				typeArguments[i](obj);
			}
			output.Write('>');
		};
	}

	public Action<ILNameSyntax> GetGenericMethodParameter(GenericContext genericContext, int index)
	{
		return delegate(ILNameSyntax syntax)
		{
			output.Write("!!");
			WriteTypeParameter(genericContext.GetGenericMethodTypeParameterHandleOrNull(index), index, syntax);
		};
	}

	public Action<ILNameSyntax> GetGenericTypeParameter(GenericContext genericContext, int index)
	{
		return delegate(ILNameSyntax syntax)
		{
			output.Write("!");
			WriteTypeParameter(genericContext.GetGenericTypeParameterHandleOrNull(index), index, syntax);
		};
	}

	private void WriteTypeParameter(GenericParameterHandle paramRef, int index, ILNameSyntax syntax)
	{
		if (paramRef.IsNil || syntax == ILNameSyntax.SignatureNoNamedTypeParameters)
		{
			output.Write(index.ToString());
			return;
		}
		GenericParameter genericParameter = metadata.GetGenericParameter(paramRef);
		if (genericParameter.Name.IsNil)
		{
			output.Write(genericParameter.Index.ToString());
		}
		else
		{
			output.Write(DisassemblerHelpers.Escape(metadata.GetString(genericParameter.Name)));
		}
	}

	public Action<ILNameSyntax> GetModifiedType(Action<ILNameSyntax> modifier, Action<ILNameSyntax> unmodifiedType, bool isRequired)
	{
		return delegate(ILNameSyntax syntax)
		{
			unmodifiedType(syntax);
			if (isRequired)
			{
				output.Write(" modreq");
			}
			else
			{
				output.Write(" modopt");
			}
			output.Write('(');
			modifier(ILNameSyntax.TypeName);
			output.Write(')');
		};
	}

	public Action<ILNameSyntax> GetPinnedType(Action<ILNameSyntax> elementType)
	{
		return delegate(ILNameSyntax syntax)
		{
			ILNameSyntax obj = ((syntax == ILNameSyntax.SignatureNoNamedTypeParameters) ? syntax : ILNameSyntax.Signature);
			elementType(obj);
			output.Write(" pinned");
		};
	}

	public Action<ILNameSyntax> GetPointerType(Action<ILNameSyntax> elementType)
	{
		return delegate(ILNameSyntax syntax)
		{
			ILNameSyntax obj = ((syntax == ILNameSyntax.SignatureNoNamedTypeParameters) ? syntax : ILNameSyntax.Signature);
			elementType(obj);
			output.Write('*');
		};
	}

	public Action<ILNameSyntax> GetPrimitiveType(PrimitiveTypeCode typeCode)
	{
		return typeCode switch
		{
			PrimitiveTypeCode.SByte => delegate
			{
				output.Write("int8");
			}, 
			PrimitiveTypeCode.Int16 => delegate
			{
				output.Write("int16");
			}, 
			PrimitiveTypeCode.Int32 => delegate
			{
				output.Write("int32");
			}, 
			PrimitiveTypeCode.Int64 => delegate
			{
				output.Write("int64");
			}, 
			PrimitiveTypeCode.Byte => delegate
			{
				output.Write("uint8");
			}, 
			PrimitiveTypeCode.UInt16 => delegate
			{
				output.Write("uint16");
			}, 
			PrimitiveTypeCode.UInt32 => delegate
			{
				output.Write("uint32");
			}, 
			PrimitiveTypeCode.UInt64 => delegate
			{
				output.Write("uint64");
			}, 
			PrimitiveTypeCode.Single => delegate
			{
				output.Write("float32");
			}, 
			PrimitiveTypeCode.Double => delegate
			{
				output.Write("float64");
			}, 
			PrimitiveTypeCode.Void => delegate
			{
				output.Write("void");
			}, 
			PrimitiveTypeCode.Boolean => delegate
			{
				output.Write("bool");
			}, 
			PrimitiveTypeCode.String => delegate
			{
				output.Write("string");
			}, 
			PrimitiveTypeCode.Char => delegate
			{
				output.Write("char");
			}, 
			PrimitiveTypeCode.Object => delegate
			{
				output.Write("object");
			}, 
			PrimitiveTypeCode.IntPtr => delegate
			{
				output.Write("native int");
			}, 
			PrimitiveTypeCode.UIntPtr => delegate
			{
				output.Write("native uint");
			}, 
			PrimitiveTypeCode.TypedReference => delegate
			{
				output.Write("typedref");
			}, 
			_ => throw new ArgumentOutOfRangeException(), 
		};
	}

	public Action<ILNameSyntax> GetSZArrayType(Action<ILNameSyntax> elementType)
	{
		return delegate(ILNameSyntax syntax)
		{
			ILNameSyntax obj = ((syntax == ILNameSyntax.SignatureNoNamedTypeParameters) ? syntax : ILNameSyntax.Signature);
			elementType(obj);
			output.Write('[');
			output.Write(']');
		};
	}

	public Action<ILNameSyntax> GetTypeFromDefinition(MetadataReader reader, TypeDefinitionHandle handle, byte rawTypeKind)
	{
		return delegate
		{
			switch (rawTypeKind)
			{
			case 17:
				output.Write("valuetype ");
				break;
			case 18:
				output.Write("class ");
				break;
			default:
				throw new BadImageFormatException($"Unexpected rawTypeKind: {rawTypeKind} (0x{rawTypeKind:x})");
			case 0:
				break;
			}
			InstructionOutputExtensions.WriteTo(handle, module, output, GenericContext.Empty);
		};
	}

	public Action<ILNameSyntax> GetTypeFromReference(MetadataReader reader, TypeReferenceHandle handle, byte rawTypeKind)
	{
		return delegate
		{
			switch (rawTypeKind)
			{
			case 17:
				output.Write("valuetype ");
				break;
			case 18:
				output.Write("class ");
				break;
			default:
				throw new BadImageFormatException($"Unexpected rawTypeKind: {rawTypeKind} (0x{rawTypeKind:x})");
			case 0:
				break;
			}
			InstructionOutputExtensions.WriteTo(handle, module, output, GenericContext.Empty);
		};
	}

	public Action<ILNameSyntax> GetTypeFromSpecification(MetadataReader reader, GenericContext genericContext, TypeSpecificationHandle handle, byte rawTypeKind)
	{
		return reader.GetTypeSpecification(handle).DecodeSignature(this, genericContext);
	}
}
