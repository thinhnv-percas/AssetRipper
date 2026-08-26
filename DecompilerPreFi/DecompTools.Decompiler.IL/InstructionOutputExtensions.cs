using System;
using System.Collections.Immutable;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using DecompTools.Decompiler.Disassembler;
using DecompTools.Decompiler.Metadata;
using DecompTools.Decompiler.TypeSystem;
using DecompTools.Decompiler.Util;

namespace DecompTools.Decompiler.IL;

internal static class InstructionOutputExtensions
{
	private static readonly string[] originalOpCodeNames = new string[94]
	{
		"invalid.branch", "invalid.expr", "nop", "ILFunction", "BlockContainer", "Block", "PinnedRegion", "binary", "numeric.compound", "user.compound",
		"dynamic.compound", "bit.not", "arglist", "br", "leave", "if", "if.notnull", "switch", "switch.section", "try.catch",
		"try.catch.handler", "try.finally", "try.fault", "lock", "using", "debug.break", "comp", "call", "callvirt", "calli",
		"ckfinite", "conv", "ldloc", "ldloca", "stloc", "addressof", "3vl.bool.and", "3vl.bool.or", "nullable.unwrap", "nullable.rewrap",
		"ldstr", "ldc.i4", "ldc.i8", "ldc.f4", "ldc.f8", "ldc.decimal", "ldnull", "ldftn", "ldvirtftn", "ldtypetoken",
		"ldmembertoken", "localloc", "localloc.span", "cpblk", "initblk", "ldflda", "ldsflda", "castclass", "isinst", "ldobj",
		"stobj", "box", "unbox", "unbox.any", "newobj", "newarr", "default.value", "throw", "rethrow", "sizeof",
		"ldlen", "ldelema", "array.to.pointer", "string.to.int", "expression.tree.cast", "user.logic.operator", "dynamic.logic.operator", "dynamic.binary.operator", "dynamic.unary.operator", "dynamic.convert",
		"dynamic.getmember", "dynamic.setmember", "dynamic.getindex", "dynamic.setindex", "dynamic.invokemember", "dynamic.invokeconstructor", "dynamic.invoke", "dynamic.isevent", "mkrefany", "refanytype",
		"refanyval", "yield.return", "await", "AnyNode"
	};

	public static void Write(this ITextOutput output, OpCode opCode)
	{
		output.Write(originalOpCodeNames[(uint)opCode]);
	}

	public static void Write(this ITextOutput output, StackType stackType)
	{
		output.Write(stackType.ToString().ToLowerInvariant());
	}

	public static void Write(this ITextOutput output, PrimitiveType primitiveType)
	{
		output.Write(primitiveType.ToString().ToLowerInvariant());
	}

	public static void WriteTo(this IType type, ITextOutput output, ILNameSyntax nameSyntax = ILNameSyntax.ShortTypeName)
	{
		output.WriteReference(type, type.ReflectionName);
	}

	public static void WriteTo(this IMember member, ITextOutput output)
	{
		if (member is IMethod { IsConstructor: not false } method)
		{
			output.WriteReference(member, method.DeclaringType?.Name + "." + method.Name);
		}
		else
		{
			output.WriteReference(member, member.Name);
		}
	}

	public static void WriteTo(this Interval interval, ITextOutput output, ILAstWritingOptions options)
	{
		if (options.ShowILRanges)
		{
			if (interval.IsEmpty)
			{
				output.Write("[empty] ");
			}
			else
			{
				output.Write($"[{interval.Start:x4}..{interval.InclusiveEnd:x4}] ");
			}
		}
	}

	public static void WriteTo(this EntityHandle entity, PEFile module, ITextOutput output, DecompTools.Decompiler.Metadata.GenericContext genericContext, ILNameSyntax syntax = ILNameSyntax.Signature)
	{
		if (entity.IsNil)
		{
			throw new ArgumentNullException("entity");
		}
		if (module == null)
		{
			throw new ArgumentNullException("module");
		}
		MetadataReader metadata = module.Metadata;
		checked
		{
			switch (entity.Kind)
			{
			case HandleKind.TypeDefinition:
			{
				TypeDefinition typeDefinition = metadata.GetTypeDefinition((TypeDefinitionHandle)entity);
				output.WriteReference(module, entity, typeDefinition.GetFullTypeName(metadata).ToILNameString());
				break;
			}
			case HandleKind.TypeReference:
			{
				TypeReference typeReference = metadata.GetTypeReference((TypeReferenceHandle)entity);
				EntityHandle entityHandle;
				try
				{
					entityHandle = typeReference.ResolutionScope;
				}
				catch (BadImageFormatException)
				{
					entityHandle = default(EntityHandle);
				}
				if (!entityHandle.IsNil)
				{
					output.Write("[");
					TypeReference typeReference2 = typeReference;
					while (typeReference2.ResolutionScope.Kind == HandleKind.TypeReference)
					{
						typeReference2 = metadata.GetTypeReference((TypeReferenceHandle)typeReference2.ResolutionScope);
					}
					switch (typeReference2.ResolutionScope.Kind)
					{
					case HandleKind.ModuleDefinition:
						output.Write(DisassemblerHelpers.Escape(metadata.GetString(metadata.GetModuleDefinition().Name)));
						break;
					case HandleKind.AssemblyReference:
						output.Write(DisassemblerHelpers.Escape(metadata.GetString(metadata.GetAssemblyReference((AssemblyReferenceHandle)typeReference2.ResolutionScope).Name)));
						break;
					}
					output.Write("]");
				}
				output.WriteReference(module, entity, entity.GetFullTypeName(metadata).ToILNameString());
				break;
			}
			case HandleKind.TypeSpecification:
			{
				Action<ILNameSyntax> action2 = metadata.GetTypeSpecification((TypeSpecificationHandle)entity).DecodeSignature(new DisassemblerSignatureProvider(module, output), genericContext);
				action2(syntax);
				break;
			}
			case HandleKind.FieldDefinition:
			{
				FieldDefinition fieldDefinition = metadata.GetFieldDefinition((FieldDefinitionHandle)entity);
				Action<ILNameSyntax> action2 = fieldDefinition.DecodeSignature(new DisassemblerSignatureProvider(module, output), new DecompTools.Decompiler.Metadata.GenericContext(fieldDefinition.GetDeclaringType(), module));
				action2(ILNameSyntax.SignatureNoNamedTypeParameters);
				output.Write(' ');
				WriteTo(fieldDefinition.GetDeclaringType(), module, output, DecompTools.Decompiler.Metadata.GenericContext.Empty, ILNameSyntax.TypeName);
				output.Write("::");
				output.WriteReference(module, entity, DisassemblerHelpers.Escape(metadata.GetString(fieldDefinition.Name)));
				break;
			}
			case HandleKind.MethodDefinition:
			{
				MethodDefinition methodDefinition2 = metadata.GetMethodDefinition((MethodDefinitionHandle)entity);
				MethodSignature<Action<ILNameSyntax>> methodSignature2 = methodDefinition2.DecodeSignature(new DisassemblerSignatureProvider(module, output), new DecompTools.Decompiler.Metadata.GenericContext((MethodDefinitionHandle)entity, module));
				if (methodSignature2.Header.HasExplicitThis)
				{
					output.Write("instance explicit ");
				}
				else if (methodSignature2.Header.IsInstance)
				{
					output.Write("instance ");
				}
				if (methodSignature2.Header.CallingConvention == SignatureCallingConvention.VarArgs)
				{
					output.Write("vararg ");
				}
				methodSignature2.ReturnType(ILNameSyntax.SignatureNoNamedTypeParameters);
				output.Write(' ');
				TypeDefinitionHandle declaringType2 = methodDefinition2.GetDeclaringType();
				if (!declaringType2.IsNil)
				{
					WriteTo(declaringType2, module, output, genericContext, ILNameSyntax.TypeName);
					output.Write("::");
				}
				if ((methodDefinition2.Attributes & MethodAttributes.MemberAccessMask) == 0)
				{
					output.WriteReference(module, entity, DisassemblerHelpers.Escape(metadata.GetString(methodDefinition2.Name) + "$PST" + MetadataTokens.GetToken(entity).ToString("X8")));
				}
				else
				{
					output.WriteReference(module, entity, DisassemblerHelpers.Escape(metadata.GetString(methodDefinition2.Name)));
				}
				GenericParameterHandleCollection genericParameters = methodDefinition2.GetGenericParameters();
				if (genericParameters.Count > 0)
				{
					output.Write('<');
					for (int num = 0; num < genericParameters.Count; num++)
					{
						if (num > 0)
						{
							output.Write(", ");
						}
						GenericParameter genericParameter = metadata.GetGenericParameter(genericParameters[num]);
						if ((genericParameter.Attributes & GenericParameterAttributes.ReferenceTypeConstraint) == GenericParameterAttributes.ReferenceTypeConstraint)
						{
							output.Write("class ");
						}
						else if ((genericParameter.Attributes & GenericParameterAttributes.NotNullableValueTypeConstraint) == GenericParameterAttributes.NotNullableValueTypeConstraint)
						{
							output.Write("valuetype ");
						}
						if ((genericParameter.Attributes & GenericParameterAttributes.DefaultConstructorConstraint) == GenericParameterAttributes.DefaultConstructorConstraint)
						{
							output.Write(".ctor ");
						}
						GenericParameterConstraintHandleCollection constraints = genericParameter.GetConstraints();
						if (constraints.Count > 0)
						{
							output.Write('(');
							for (int num2 = 0; num2 < constraints.Count; num2++)
							{
								if (num2 > 0)
								{
									output.Write(", ");
								}
								metadata.GetGenericParameterConstraint(constraints[num2]).Type.WriteTo(module, output, new DecompTools.Decompiler.Metadata.GenericContext((MethodDefinitionHandle)entity, module), ILNameSyntax.TypeName);
							}
							output.Write(") ");
						}
						if ((genericParameter.Attributes & GenericParameterAttributes.Contravariant) == GenericParameterAttributes.Contravariant)
						{
							output.Write('-');
						}
						else if ((genericParameter.Attributes & GenericParameterAttributes.Covariant) == GenericParameterAttributes.Covariant)
						{
							output.Write('+');
						}
						output.Write(DisassemblerHelpers.Escape(metadata.GetString(genericParameter.Name)));
					}
					output.Write('>');
				}
				output.Write("(");
				for (int num3 = 0; num3 < methodSignature2.ParameterTypes.Length; num3++)
				{
					if (num3 > 0)
					{
						output.Write(", ");
					}
					methodSignature2.ParameterTypes[num3](ILNameSyntax.SignatureNoNamedTypeParameters);
				}
				output.Write(")");
				break;
			}
			case HandleKind.MemberReference:
			{
				MemberReference memberReference2 = metadata.GetMemberReference((MemberReferenceHandle)entity);
				string identifier = metadata.GetString(memberReference2.Name);
				switch (memberReference2.GetKind())
				{
				case MemberReferenceKind.Method:
				{
					MethodSignature<Action<ILNameSyntax>> methodSignature2 = memberReference2.DecodeMethodSignature(new DisassemblerSignatureProvider(module, output), genericContext);
					if (methodSignature2.Header.HasExplicitThis)
					{
						output.Write("instance explicit ");
					}
					else if (methodSignature2.Header.IsInstance)
					{
						output.Write("instance ");
					}
					if (methodSignature2.Header.CallingConvention == SignatureCallingConvention.VarArgs)
					{
						output.Write("vararg ");
					}
					methodSignature2.ReturnType(ILNameSyntax.SignatureNoNamedTypeParameters);
					output.Write(' ');
					WriteParent(output, module, metadata, memberReference2.Parent, genericContext, syntax);
					output.Write("::");
					output.WriteReference(module, entity, DisassemblerHelpers.Escape(identifier));
					output.Write("(");
					for (int n = 0; n < methodSignature2.ParameterTypes.Length; n++)
					{
						if (n > 0)
						{
							output.Write(", ");
						}
						if (n == methodSignature2.RequiredParameterCount)
						{
							output.Write("..., ");
						}
						methodSignature2.ParameterTypes[n](ILNameSyntax.SignatureNoNamedTypeParameters);
					}
					output.Write(")");
					break;
				}
				case MemberReferenceKind.Field:
				{
					Action<ILNameSyntax> action = memberReference2.DecodeFieldSignature(new DisassemblerSignatureProvider(module, output), genericContext);
					action(ILNameSyntax.SignatureNoNamedTypeParameters);
					output.Write(' ');
					WriteParent(output, module, metadata, memberReference2.Parent, genericContext, syntax);
					output.Write("::");
					output.WriteReference(module, entity, DisassemblerHelpers.Escape(identifier));
					break;
				}
				}
				break;
			}
			case HandleKind.MethodSpecification:
			{
				MethodSpecification methodSpecification = metadata.GetMethodSpecification((MethodSpecificationHandle)entity);
				ImmutableArray<Action<ILNameSyntax>> immutableArray = methodSpecification.DecodeSignature(new DisassemblerSignatureProvider(module, output), genericContext);
				switch (methodSpecification.Method.Kind)
				{
				case HandleKind.MethodDefinition:
				{
					MethodDefinition methodDefinition = metadata.GetMethodDefinition((MethodDefinitionHandle)methodSpecification.Method);
					string text = metadata.GetString(methodDefinition.Name);
					MethodSignature<Action<ILNameSyntax>> methodSignature2 = methodDefinition.DecodeSignature(new DisassemblerSignatureProvider(module, output), genericContext);
					if (methodSignature2.Header.HasExplicitThis)
					{
						output.Write("instance explicit ");
					}
					else if (methodSignature2.Header.IsInstance)
					{
						output.Write("instance ");
					}
					if (methodSignature2.Header.CallingConvention == SignatureCallingConvention.VarArgs)
					{
						output.Write("vararg ");
					}
					methodSignature2.ReturnType(ILNameSyntax.SignatureNoNamedTypeParameters);
					output.Write(' ');
					TypeDefinitionHandle declaringType = methodDefinition.GetDeclaringType();
					if (!declaringType.IsNil)
					{
						WriteTo(declaringType, module, output, genericContext, ILNameSyntax.TypeName);
						output.Write("::");
					}
					if ((methodDefinition.Attributes & MethodAttributes.MemberAccessMask) == 0)
					{
						output.Write(DisassemblerHelpers.Escape(text + "$PST" + MetadataTokens.GetToken(methodSpecification.Method).ToString("X8")));
					}
					else
					{
						output.Write(DisassemblerHelpers.Escape(text));
					}
					output.Write('<');
					for (int l = 0; l < immutableArray.Length; l++)
					{
						if (l > 0)
						{
							output.Write(", ");
						}
						immutableArray[l](syntax);
					}
					output.Write('>');
					output.Write("(");
					for (int m = 0; m < methodSignature2.ParameterTypes.Length; m++)
					{
						if (m > 0)
						{
							output.Write(", ");
						}
						methodSignature2.ParameterTypes[m](ILNameSyntax.SignatureNoNamedTypeParameters);
					}
					output.Write(")");
					break;
				}
				case HandleKind.MemberReference:
				{
					MemberReference memberReference = metadata.GetMemberReference((MemberReferenceHandle)methodSpecification.Method);
					string identifier = metadata.GetString(memberReference.Name);
					MethodSignature<Action<ILNameSyntax>> methodSignature2 = memberReference.DecodeMethodSignature(new DisassemblerSignatureProvider(module, output), genericContext);
					if (methodSignature2.Header.HasExplicitThis)
					{
						output.Write("instance explicit ");
					}
					else if (methodSignature2.Header.IsInstance)
					{
						output.Write("instance ");
					}
					if (methodSignature2.Header.CallingConvention == SignatureCallingConvention.VarArgs)
					{
						output.Write("vararg ");
					}
					methodSignature2.ReturnType(ILNameSyntax.SignatureNoNamedTypeParameters);
					output.Write(' ');
					WriteParent(output, module, metadata, memberReference.Parent, genericContext, syntax);
					output.Write("::");
					output.Write(DisassemblerHelpers.Escape(identifier));
					output.Write('<');
					for (int j = 0; j < immutableArray.Length; j++)
					{
						if (j > 0)
						{
							output.Write(", ");
						}
						immutableArray[j](syntax);
					}
					output.Write('>');
					output.Write("(");
					for (int k = 0; k < methodSignature2.ParameterTypes.Length; k++)
					{
						if (k > 0)
						{
							output.Write(", ");
						}
						methodSignature2.ParameterTypes[k](ILNameSyntax.SignatureNoNamedTypeParameters);
					}
					output.Write(")");
					break;
				}
				}
				break;
			}
			case HandleKind.StandaloneSignature:
			{
				StandaloneSignature standaloneSignature = metadata.GetStandaloneSignature((StandaloneSignatureHandle)entity);
				switch (standaloneSignature.GetKind())
				{
				case StandaloneSignatureKind.Method:
				{
					MethodSignature<Action<ILNameSyntax>> methodSignature = standaloneSignature.DecodeMethodSignature(new DisassemblerSignatureProvider(module, output), genericContext);
					methodSignature.ReturnType(ILNameSyntax.SignatureNoNamedTypeParameters);
					output.Write('(');
					for (int i = 0; i < methodSignature.ParameterTypes.Length; i++)
					{
						if (i > 0)
						{
							output.Write(", ");
						}
						methodSignature.ParameterTypes[i](ILNameSyntax.SignatureNoNamedTypeParameters);
					}
					output.Write(')');
					break;
				}
				default:
					output.Write($"@{MetadataTokens.GetToken(entity):X8} /* signature {standaloneSignature.GetKind()} */");
					break;
				}
				break;
			}
			default:
				output.Write($"@{MetadataTokens.GetToken(entity):X8}");
				break;
			}
		}
	}

	private static void WriteParent(ITextOutput output, PEFile module, MetadataReader metadata, EntityHandle parentHandle, DecompTools.Decompiler.Metadata.GenericContext genericContext, ILNameSyntax syntax)
	{
		switch (parentHandle.Kind)
		{
		case HandleKind.MethodDefinition:
			WriteTo(metadata.GetMethodDefinition((MethodDefinitionHandle)parentHandle).GetDeclaringType(), module, output, genericContext, syntax);
			break;
		case HandleKind.ModuleReference:
			output.Write('[');
			output.Write(metadata.GetString(metadata.GetModuleReference((ModuleReferenceHandle)parentHandle).Name));
			output.Write(']');
			break;
		case HandleKind.TypeReference:
		case HandleKind.TypeDefinition:
		case HandleKind.TypeSpecification:
			parentHandle.WriteTo(module, output, genericContext, syntax);
			break;
		}
	}
}
