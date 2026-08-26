using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Threading;
using DecompTools.Decompiler.DebugInfo;
using DecompTools.Decompiler.IL;
using DecompTools.Decompiler.Metadata;

namespace DecompTools.Decompiler.Disassembler;

public sealed class ReflectionDisassembler
{
	private class SecurityDeclarationDecoder : ICustomAttributeTypeProvider<(PrimitiveTypeCode, string)>, ISimpleTypeProvider<(PrimitiveTypeCode, string)>, ISZArrayTypeProvider<(PrimitiveTypeCode, string)>
	{
		private readonly ITextOutput output;

		private readonly IAssemblyResolver resolver;

		private readonly PEFile module;

		private PEFile mscorlib;

		public SecurityDeclarationDecoder(ITextOutput output, IAssemblyResolver resolver, PEFile module)
		{
			this.output = output;
			this.resolver = resolver;
			this.module = module;
		}

		public (PrimitiveTypeCode, string) GetPrimitiveType(PrimitiveTypeCode typeCode)
		{
			return (typeCode, null);
		}

		public (PrimitiveTypeCode, string) GetSystemType()
		{
			return ((PrimitiveTypeCode)0, "type");
		}

		public (PrimitiveTypeCode, string) GetSZArrayType((PrimitiveTypeCode, string) elementType)
		{
			return (elementType.Item1, (elementType.Item2 ?? PrimitiveTypeCodeToString(elementType.Item1)) + "[]");
		}

		public (PrimitiveTypeCode, string) GetTypeFromDefinition(MetadataReader reader, TypeDefinitionHandle handle, byte rawTypeKind)
		{
			throw new NotImplementedException();
		}

		public (PrimitiveTypeCode, string) GetTypeFromReference(MetadataReader reader, TypeReferenceHandle handle, byte rawTypeKind)
		{
			throw new NotImplementedException();
		}

		public (PrimitiveTypeCode, string) GetTypeFromSerializedName(string name)
		{
			if (resolver == null)
			{
				throw new EnumUnderlyingTypeResolveException();
			}
			var (pEFile, handle) = ResolveType(name, module);
			if (handle.IsNil)
			{
				throw new EnumUnderlyingTypeResolveException();
			}
			if (handle.IsEnum(pEFile.Metadata, out var underlyingType))
			{
				return (underlyingType, "enum " + name);
			}
			return ((PrimitiveTypeCode)0, name);
		}

		public PrimitiveTypeCode GetUnderlyingEnumType((PrimitiveTypeCode, string) type)
		{
			return type.Item1;
		}

		public bool IsSystemType((PrimitiveTypeCode, string) type)
		{
			return "type" == type.Item2;
		}

		private (PEFile, TypeDefinitionHandle) ResolveType(string typeName, PEFile module)
		{
			string[] array = typeName.Split(new string[1] { ", " }, 2, StringSplitOptions.None);
			string[] name = array[0].Split(new char[1] { '.' });
			PEFile pEFile = null;
			TypeDefinitionHandle typeDefinitionHandle = default(TypeDefinitionHandle);
			if (array.Length == 2)
			{
				pEFile = resolver.Resolve(AssemblyNameReference.Parse(array[1]));
			}
			if (pEFile != null)
			{
				typeDefinitionHandle = FindType(pEFile, name);
			}
			else
			{
				typeDefinitionHandle = FindType(module, name);
				pEFile = module;
				if (typeDefinitionHandle.IsNil && TryResolveMscorlib(out var pEFile2))
				{
					typeDefinitionHandle = FindType(pEFile2, name);
					pEFile = pEFile2;
				}
			}
			return (pEFile, typeDefinitionHandle);
			static TypeDefinitionHandle FindType(PEFile currentModule, string[] array2)
			{
				MetadataReader metadata = currentModule.Metadata;
				NamespaceDefinition namespaceDefinition = metadata.GetNamespaceDefinitionRoot();
				ImmutableArray<TypeDefinitionHandle> immutableArray = default(ImmutableArray<TypeDefinitionHandle>);
				checked
				{
					for (int i = 0; i < array2.Length; i++)
					{
						string identifier = array2[i];
						if (!immutableArray.IsDefault)
						{
							while (true)
							{
								TypeDefinitionHandle current;
								TypeDefinition typeDefinition;
								foreach (TypeDefinitionHandle item in immutableArray)
								{
									current = item;
									typeDefinition = metadata.GetTypeDefinition(current);
									string text = metadata.GetString(typeDefinition.Name);
									if (!(identifier == text))
									{
										continue;
									}
									goto IL_00b6;
								}
								break;
								IL_00b6:
								if (i + 1 == array2.Length)
								{
									return current;
								}
								immutableArray = typeDefinition.GetNestedTypes();
							}
						}
						else
						{
							NamespaceDefinitionHandle handle = namespaceDefinition.NamespaceDefinitions.FirstOrDefault((NamespaceDefinitionHandle ns) => metadata.StringComparer.Equals(metadata.GetNamespaceDefinition(ns).Name, identifier));
							if (!handle.IsNil)
							{
								namespaceDefinition = metadata.GetNamespaceDefinition(handle);
							}
							else
							{
								immutableArray = namespaceDefinition.TypeDefinitions;
								i--;
							}
						}
					}
					return default(TypeDefinitionHandle);
				}
			}
		}

		private PrimitiveTypeCode ResolveEnumUnderlyingType(string typeName, PEFile module)
		{
			if (typeName.StartsWith("enum ", StringComparison.Ordinal))
			{
				typeName = typeName.Substring(5);
			}
			var (pEFile, handle) = ResolveType(typeName, module);
			if (handle.IsNil || !handle.IsEnum(pEFile.Metadata, out var underlyingType))
			{
				throw new EnumUnderlyingTypeResolveException();
			}
			return underlyingType;
		}

		private bool TryResolveMscorlib(out PEFile mscorlib)
		{
			mscorlib = null;
			if (this.mscorlib != null)
			{
				mscorlib = this.mscorlib;
				return true;
			}
			if (resolver == null)
			{
				return false;
			}
			this.mscorlib = (mscorlib = resolver.Resolve(AssemblyNameReference.Parse("mscorlib")));
			return this.mscorlib != null;
		}
	}

	private sealed class EnumNameCollection<T> : IEnumerable<KeyValuePair<long, string>>, IEnumerable where T : struct
	{
		private List<KeyValuePair<long, string>> names = new List<KeyValuePair<long, string>>();

		public void Add(T flag, string name)
		{
			names.Add(new KeyValuePair<long, string>(Convert.ToInt64(flag), name));
		}

		public IEnumerator<KeyValuePair<long, string>> GetEnumerator()
		{
			return names.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return names.GetEnumerator();
		}
	}

	private readonly ITextOutput output;

	private CancellationToken cancellationToken;

	private bool isInType;

	private MethodBodyDisassembler methodBodyDisassembler;

	private EnumNameCollection<MethodAttributes> methodAttributeFlags = new EnumNameCollection<MethodAttributes>
	{
		{
			MethodAttributes.Final,
			"final"
		},
		{
			MethodAttributes.HideBySig,
			"hidebysig"
		},
		{
			MethodAttributes.SpecialName,
			"specialname"
		},
		{
			MethodAttributes.PinvokeImpl,
			null
		},
		{
			MethodAttributes.UnmanagedExport,
			"export"
		},
		{
			MethodAttributes.RTSpecialName,
			"rtspecialname"
		},
		{
			MethodAttributes.RequireSecObject,
			"reqsecobj"
		},
		{
			MethodAttributes.VtableLayoutMask,
			"newslot"
		},
		{
			MethodAttributes.CheckAccessOnOverride,
			"strict"
		},
		{
			MethodAttributes.Abstract,
			"abstract"
		},
		{
			MethodAttributes.Virtual,
			"virtual"
		},
		{
			MethodAttributes.Static,
			"static"
		},
		{
			MethodAttributes.HasSecurity,
			null
		}
	};

	private EnumNameCollection<MethodAttributes> methodVisibility = new EnumNameCollection<MethodAttributes>
	{
		{
			MethodAttributes.Private,
			"private"
		},
		{
			MethodAttributes.FamANDAssem,
			"famandassem"
		},
		{
			MethodAttributes.Assembly,
			"assembly"
		},
		{
			MethodAttributes.Family,
			"family"
		},
		{
			MethodAttributes.FamORAssem,
			"famorassem"
		},
		{
			MethodAttributes.Public,
			"public"
		}
	};

	private EnumNameCollection<SignatureCallingConvention> callingConvention = new EnumNameCollection<SignatureCallingConvention>
	{
		{
			SignatureCallingConvention.CDecl,
			"unmanaged cdecl"
		},
		{
			SignatureCallingConvention.StdCall,
			"unmanaged stdcall"
		},
		{
			SignatureCallingConvention.ThisCall,
			"unmanaged thiscall"
		},
		{
			SignatureCallingConvention.FastCall,
			"unmanaged fastcall"
		},
		{
			SignatureCallingConvention.VarArgs,
			"vararg"
		},
		{
			SignatureCallingConvention.Default,
			null
		}
	};

	private EnumNameCollection<MethodImplAttributes> methodCodeType = new EnumNameCollection<MethodImplAttributes>
	{
		{
			MethodImplAttributes.IL,
			"cil"
		},
		{
			MethodImplAttributes.Native,
			"native"
		},
		{
			MethodImplAttributes.OPTIL,
			"optil"
		},
		{
			MethodImplAttributes.CodeTypeMask,
			"runtime"
		}
	};

	private EnumNameCollection<MethodImplAttributes> methodImpl = new EnumNameCollection<MethodImplAttributes>
	{
		{
			MethodImplAttributes.Synchronized,
			"synchronized"
		},
		{
			MethodImplAttributes.NoInlining,
			"noinlining"
		},
		{
			MethodImplAttributes.NoOptimization,
			"nooptimization"
		},
		{
			MethodImplAttributes.PreserveSig,
			"preservesig"
		},
		{
			MethodImplAttributes.InternalCall,
			"internalcall"
		},
		{
			MethodImplAttributes.ForwardRef,
			"forwardref"
		},
		{
			MethodImplAttributes.AggressiveInlining,
			"aggressiveinlining"
		}
	};

	private EnumNameCollection<FieldAttributes> fieldVisibility = new EnumNameCollection<FieldAttributes>
	{
		{
			FieldAttributes.Private,
			"private"
		},
		{
			FieldAttributes.FamANDAssem,
			"famandassem"
		},
		{
			FieldAttributes.Assembly,
			"assembly"
		},
		{
			FieldAttributes.Family,
			"family"
		},
		{
			FieldAttributes.FamORAssem,
			"famorassem"
		},
		{
			FieldAttributes.Public,
			"public"
		}
	};

	private EnumNameCollection<FieldAttributes> fieldAttributes = new EnumNameCollection<FieldAttributes>
	{
		{
			FieldAttributes.Static,
			"static"
		},
		{
			FieldAttributes.Literal,
			"literal"
		},
		{
			FieldAttributes.InitOnly,
			"initonly"
		},
		{
			FieldAttributes.SpecialName,
			"specialname"
		},
		{
			FieldAttributes.RTSpecialName,
			"rtspecialname"
		},
		{
			FieldAttributes.NotSerialized,
			"notserialized"
		}
	};

	private EnumNameCollection<PropertyAttributes> propertyAttributes = new EnumNameCollection<PropertyAttributes>
	{
		{
			PropertyAttributes.SpecialName,
			"specialname"
		},
		{
			PropertyAttributes.RTSpecialName,
			"rtspecialname"
		},
		{
			PropertyAttributes.HasDefault,
			"hasdefault"
		}
	};

	private EnumNameCollection<EventAttributes> eventAttributes = new EnumNameCollection<EventAttributes>
	{
		{
			EventAttributes.SpecialName,
			"specialname"
		},
		{
			EventAttributes.RTSpecialName,
			"rtspecialname"
		}
	};

	private EnumNameCollection<TypeAttributes> typeVisibility = new EnumNameCollection<TypeAttributes>
	{
		{
			TypeAttributes.Public,
			"public"
		},
		{
			TypeAttributes.NotPublic,
			"private"
		},
		{
			TypeAttributes.NestedPublic,
			"nested public"
		},
		{
			TypeAttributes.NestedPrivate,
			"nested private"
		},
		{
			TypeAttributes.NestedAssembly,
			"nested assembly"
		},
		{
			TypeAttributes.NestedFamily,
			"nested family"
		},
		{
			TypeAttributes.NestedFamANDAssem,
			"nested famandassem"
		},
		{
			TypeAttributes.VisibilityMask,
			"nested famorassem"
		}
	};

	private EnumNameCollection<TypeAttributes> typeLayout = new EnumNameCollection<TypeAttributes>
	{
		{
			TypeAttributes.NotPublic,
			"auto"
		},
		{
			TypeAttributes.SequentialLayout,
			"sequential"
		},
		{
			TypeAttributes.ExplicitLayout,
			"explicit"
		}
	};

	private EnumNameCollection<TypeAttributes> typeStringFormat = new EnumNameCollection<TypeAttributes>
	{
		{
			TypeAttributes.AutoClass,
			"auto"
		},
		{
			TypeAttributes.NotPublic,
			"ansi"
		},
		{
			TypeAttributes.UnicodeClass,
			"unicode"
		}
	};

	private EnumNameCollection<TypeAttributes> typeAttributes = new EnumNameCollection<TypeAttributes>
	{
		{
			TypeAttributes.Abstract,
			"abstract"
		},
		{
			TypeAttributes.Sealed,
			"sealed"
		},
		{
			TypeAttributes.SpecialName,
			"specialname"
		},
		{
			TypeAttributes.Import,
			"import"
		},
		{
			TypeAttributes.Serializable,
			"serializable"
		},
		{
			TypeAttributes.WindowsRuntime,
			"windowsruntime"
		},
		{
			TypeAttributes.BeforeFieldInit,
			"beforefieldinit"
		},
		{
			TypeAttributes.HasSecurity,
			null
		}
	};

	public bool DetectControlStructure
	{
		get
		{
			return methodBodyDisassembler.DetectControlStructure;
		}
		set
		{
			methodBodyDisassembler.DetectControlStructure = value;
		}
	}

	public bool ShowSequencePoints
	{
		get
		{
			return methodBodyDisassembler.ShowSequencePoints;
		}
		set
		{
			methodBodyDisassembler.ShowSequencePoints = value;
		}
	}

	public bool ShowMetadataTokens
	{
		get
		{
			return methodBodyDisassembler.ShowMetadataTokens;
		}
		set
		{
			methodBodyDisassembler.ShowMetadataTokens = value;
		}
	}

	public bool ShowMetadataTokensInBase10
	{
		get
		{
			return methodBodyDisassembler.ShowMetadataTokensInBase10;
		}
		set
		{
			methodBodyDisassembler.ShowMetadataTokensInBase10 = value;
		}
	}

	public IDebugInfoProvider DebugInfo
	{
		get
		{
			return methodBodyDisassembler.DebugInfo;
		}
		set
		{
			methodBodyDisassembler.DebugInfo = value;
		}
	}

	public bool ExpandMemberDefinitions { get; set; } = false;

	public IAssemblyResolver AssemblyResolver { get; set; }

	public ReflectionDisassembler(ITextOutput output, CancellationToken cancellationToken)
		: this(output, new MethodBodyDisassembler(output, cancellationToken), cancellationToken)
	{
	}

	public ReflectionDisassembler(ITextOutput output, MethodBodyDisassembler methodBodyDisassembler, CancellationToken cancellationToken)
	{
		if (output == null)
		{
			throw new ArgumentNullException("output");
		}
		this.output = output;
		this.cancellationToken = cancellationToken;
		this.methodBodyDisassembler = methodBodyDisassembler;
	}

	public void DisassembleMethod(PEFile module, MethodDefinitionHandle handle)
	{
		GenericContext genericContext = new GenericContext(handle, module);
		output.WriteReference(module, handle, ".method", isDefinition: true);
		output.Write(" ");
		DisassembleMethodHeaderInternal(module, handle, genericContext);
		DisassembleMethodBlock(module, handle, genericContext);
	}

	public void DisassembleMethodHeader(PEFile module, MethodDefinitionHandle handle)
	{
		GenericContext genericContext = new GenericContext(handle, module);
		output.WriteReference(module, handle, ".method", isDefinition: true);
		output.Write(" ");
		DisassembleMethodHeaderInternal(module, handle, genericContext);
	}

	private void DisassembleMethodHeaderInternal(PEFile module, MethodDefinitionHandle handle, GenericContext genericContext)
	{
		MetadataReader metadata = module.Metadata;
		WriteMetadataToken(handle, spaceAfter: true);
		MethodDefinition methodDefinition = metadata.GetMethodDefinition(handle);
		WriteEnum(methodDefinition.Attributes & MethodAttributes.MemberAccessMask, methodVisibility);
		WriteFlags(methodDefinition.Attributes & ~MethodAttributes.MemberAccessMask, methodAttributeFlags);
		bool flag = (methodDefinition.Attributes & MethodAttributes.MemberAccessMask) == 0;
		if (flag)
		{
			output.Write("privatescope ");
		}
		if ((methodDefinition.Attributes & MethodAttributes.PinvokeImpl) == MethodAttributes.PinvokeImpl)
		{
			output.Write("pinvokeimpl");
			MethodImport import = methodDefinition.GetImport();
			if (!import.Module.IsNil)
			{
				ModuleReference moduleReference = metadata.GetModuleReference(import.Module);
				output.Write("(\"" + DisassemblerHelpers.EscapeString(metadata.GetString(moduleReference.Name)) + "\"");
				if (!import.Name.IsNil && metadata.GetString(import.Name) != metadata.GetString(methodDefinition.Name))
				{
					output.Write(" as \"" + DisassemblerHelpers.EscapeString(metadata.GetString(import.Name)) + "\"");
				}
				if ((import.Attributes & MethodImportAttributes.ExactSpelling) == MethodImportAttributes.ExactSpelling)
				{
					output.Write(" nomangle");
				}
				switch (import.Attributes & MethodImportAttributes.CharSetAuto)
				{
				case MethodImportAttributes.CharSetAnsi:
					output.Write(" ansi");
					break;
				case MethodImportAttributes.CharSetAuto:
					output.Write(" autochar");
					break;
				case MethodImportAttributes.CharSetUnicode:
					output.Write(" unicode");
					break;
				}
				if ((import.Attributes & MethodImportAttributes.SetLastError) == MethodImportAttributes.SetLastError)
				{
					output.Write(" lasterr");
				}
				switch (import.Attributes & MethodImportAttributes.CallingConventionMask)
				{
				case MethodImportAttributes.CallingConventionCDecl:
					output.Write(" cdecl");
					break;
				case MethodImportAttributes.CallingConventionFastCall:
					output.Write(" fastcall");
					break;
				case MethodImportAttributes.CallingConventionStdCall:
					output.Write(" stdcall");
					break;
				case MethodImportAttributes.CallingConventionThisCall:
					output.Write(" thiscall");
					break;
				case MethodImportAttributes.CallingConventionWinApi:
					output.Write(" winapi");
					break;
				}
				output.Write(')');
			}
			output.Write(' ');
		}
		output.WriteLine();
		output.Indent();
		TypeDefinitionHandle declaringType = methodDefinition.GetDeclaringType();
		DisassemblerSignatureProvider provider = new DisassemblerSignatureProvider(module, output);
		MethodSignature<Action<ILNameSyntax>> signature = methodDefinition.DecodeSignature(provider, genericContext);
		if (signature.Header.HasExplicitThis)
		{
			output.Write("instance explicit ");
		}
		else if (signature.Header.IsInstance)
		{
			output.Write("instance ");
		}
		WriteEnum(signature.Header.CallingConvention, callingConvention);
		signature.ReturnType(ILNameSyntax.Signature);
		output.Write(' ');
		ParameterHandleCollection parameters = methodDefinition.GetParameters();
		if (parameters.Count > 0)
		{
			Parameter parameter = metadata.GetParameter(Enumerable.First<ParameterHandle>((IEnumerable<ParameterHandle>)parameters));
			if (parameter.SequenceNumber == 0)
			{
				BlobHandle marshallingDescriptor = parameter.GetMarshallingDescriptor();
				if (!marshallingDescriptor.IsNil)
				{
					WriteMarshalInfo(metadata.GetBlobReader(marshallingDescriptor));
				}
			}
		}
		if (flag)
		{
			output.Write(DisassemblerHelpers.Escape(metadata.GetString(methodDefinition.Name) + "$PST" + MetadataTokens.GetToken(handle).ToString("X8")));
		}
		else
		{
			output.Write(DisassemblerHelpers.Escape(metadata.GetString(methodDefinition.Name)));
		}
		WriteTypeParameters(output, module, genericContext, methodDefinition.GetGenericParameters());
		output.Write(" (");
		if (signature.ParameterTypes.Length > 0)
		{
			output.WriteLine();
			output.Indent();
			WriteParameters(metadata, parameters, signature);
			output.Unindent();
		}
		output.Write(") ");
		WriteEnum(methodDefinition.ImplAttributes & MethodImplAttributes.CodeTypeMask, methodCodeType);
		if ((methodDefinition.ImplAttributes & MethodImplAttributes.ManagedMask) == 0)
		{
			output.Write("managed ");
		}
		else
		{
			output.Write("unmanaged ");
		}
		WriteFlags(methodDefinition.ImplAttributes & (MethodImplAttributes)(-8), methodImpl);
		output.Unindent();
	}

	private void WriteMetadataToken(Handle handle, bool spaceAfter)
	{
		if (ShowMetadataTokens)
		{
			output.Write("/* {0:X8} */", MetadataTokens.GetToken(handle));
			if (spaceAfter)
			{
				output.Write(' ');
			}
		}
	}

	private void DisassembleMethodBlock(PEFile module, MethodDefinitionHandle handle, GenericContext genericContext)
	{
		MetadataReader metadata = module.Metadata;
		MethodDefinition methodDefinition = metadata.GetMethodDefinition(handle);
		OpenBlock(isInType);
		WriteAttributes(module, methodDefinition.GetCustomAttributes());
		foreach (MethodImplementationHandle methodImplementation2 in handle.GetMethodImplementations(metadata))
		{
			MethodImplementation methodImplementation = metadata.GetMethodImplementation(methodImplementation2);
			output.Write(".override method ");
			methodImplementation.MethodDeclaration.WriteTo(module, output, genericContext);
			output.WriteLine();
		}
		foreach (GenericParameterHandle genericParameter in methodDefinition.GetGenericParameters())
		{
			WriteGenericParameterAttributes(module, genericParameter);
		}
		foreach (ParameterHandle parameter in methodDefinition.GetParameters())
		{
			WriteParameterAttributes(module, parameter);
		}
		WriteSecurityDeclarations(module, methodDefinition.GetDeclarativeSecurityAttributes());
		if (methodDefinition.HasBody())
		{
			methodBodyDisassembler.Disassemble(module, handle);
		}
		CloseBlock("end of method " + DisassemblerHelpers.Escape(metadata.GetString(metadata.GetTypeDefinition(methodDefinition.GetDeclaringType()).Name)) + "::" + DisassemblerHelpers.Escape(metadata.GetString(methodDefinition.Name)));
	}

	private void WriteSecurityDeclarations(PEFile module, DeclarativeSecurityAttributeHandleCollection secDeclProvider)
	{
		if (secDeclProvider.Count == 0)
		{
			return;
		}
		foreach (DeclarativeSecurityAttributeHandle item in secDeclProvider)
		{
			output.Write(".permissionset ");
			DeclarativeSecurityAttribute declarativeSecurityAttribute = module.Metadata.GetDeclarativeSecurityAttribute(item);
			switch (checked((ushort)declarativeSecurityAttribute.Action))
			{
			case 1:
				output.Write("request");
				break;
			case 2:
				output.Write("demand");
				break;
			case 3:
				output.Write("assert");
				break;
			case 4:
				output.Write("deny");
				break;
			case 5:
				output.Write("permitonly");
				break;
			case 6:
				output.Write("linkcheck");
				break;
			case 7:
				output.Write("inheritcheck");
				break;
			case 8:
				output.Write("reqmin");
				break;
			case 9:
				output.Write("reqopt");
				break;
			case 10:
				output.Write("reqrefuse");
				break;
			case 11:
				output.Write("prejitgrant");
				break;
			case 12:
				output.Write("prejitdeny");
				break;
			case 13:
				output.Write("noncasdemand");
				break;
			case 14:
				output.Write("noncaslinkdemand");
				break;
			case 15:
				output.Write("noncasinheritance");
				break;
			default:
				output.Write(declarativeSecurityAttribute.Action.ToString());
				break;
			}
			BlobReader blobReader = module.Metadata.GetBlobReader(declarativeSecurityAttribute.PermissionSet);
			if (AssemblyResolver == null)
			{
				output.Write(" = ");
				WriteBlob(blobReader);
				output.WriteLine();
				continue;
			}
			if (blobReader.ReadByte() != 46)
			{
				blobReader.Reset();
				output.WriteLine();
				output.Indent();
				output.Write("bytearray");
				WriteBlob(blobReader);
				output.WriteLine();
				output.Unindent();
				continue;
			}
			TextOutputWithRollback textOutputWithRollback = new TextOutputWithRollback(output);
			try
			{
				TryDecodeSecurityDeclaration(textOutputWithRollback, blobReader, module);
				textOutputWithRollback.Commit();
			}
			catch (Exception ex) when (ex is BadImageFormatException || ex is EnumUnderlyingTypeResolveException)
			{
				blobReader.Reset();
				output.Write(" = ");
				WriteBlob(blobReader);
				output.WriteLine();
			}
		}
	}

	private void TryDecodeSecurityDeclaration(TextOutputWithRollback output, BlobReader blob, PEFile module)
	{
		output.WriteLine(" = {");
		output.Indent();
		string text = null;
		string text2 = null;
		if (module.Metadata.IsAssembly)
		{
			text = module.Metadata.GetString(module.Metadata.GetAssemblyDefinition().Name);
			text2 = module.Metadata.GetFullAssemblyName();
		}
		int num = blob.ReadCompressedInteger();
		checked
		{
			for (int i = 0; i < num; i++)
			{
				string text3 = blob.ReadSerializedString();
				string[] array = text3.Split(new string[1] { ", " }, StringSplitOptions.None);
				if (array.Length < 2 || array[1] == text)
				{
					output.Write("class ");
					output.Write(DisassemblerHelpers.Escape(text3));
				}
				else
				{
					output.Write('[');
					output.Write(array[1]);
					output.Write(']');
					output.Write(array[0]);
				}
				output.Write(" = {");
				blob.ReadCompressedInteger();
				int num2 = blob.ReadCompressedInteger();
				ImmutableArray<CustomAttributeNamedArgument<(PrimitiveTypeCode, string)>> immutableArray = new CustomAttributeDecoder<(PrimitiveTypeCode, string)>(new SecurityDeclarationDecoder(output, AssemblyResolver, module), module.Metadata, provideBoxingTypeInfo: true).DecodeNamedArguments(ref blob, num2);
				if (num2 > 0)
				{
					output.WriteLine();
					output.Indent();
				}
				foreach (CustomAttributeNamedArgument<(PrimitiveTypeCode, string)> item in immutableArray)
				{
					switch (item.Kind)
					{
					case CustomAttributeNamedArgumentKind.Field:
						output.Write("field ");
						break;
					case CustomAttributeNamedArgumentKind.Property:
						output.Write("property ");
						break;
					}
					output.Write(item.Type.Item2 ?? PrimitiveTypeCodeToString(item.Type.Item1));
					output.Write(" " + item.Name + " = ");
					WriteValue(output, item.Type, item.Value);
					output.WriteLine();
				}
				if (num2 > 0)
				{
					output.Unindent();
				}
				output.Write('}');
				if (i + 1 < num)
				{
					output.Write(',');
				}
				output.WriteLine();
			}
			output.Unindent();
			output.WriteLine("}");
		}
	}

	private void WriteValue(ITextOutput output, (PrimitiveTypeCode Code, string Name) type, object value)
	{
		if (value is CustomAttributeTypedArgument<(PrimitiveTypeCode, string)> customAttributeTypedArgument)
		{
			output.Write("object(");
			WriteValue(output, customAttributeTypedArgument.Type, customAttributeTypedArgument.Value);
			output.Write(")");
		}
		else if (value is ImmutableArray<CustomAttributeTypedArgument<(PrimitiveTypeCode, string)>> immutableArray)
		{
			string text = ((type.Name != null && !type.Name.StartsWith("enum ", StringComparison.Ordinal)) ? type.Name.Remove(checked(type.Name.Length - 2)) : PrimitiveTypeCodeToString(type.Code));
			output.Write(text);
			output.Write("[");
			output.Write(immutableArray.Length.ToString());
			output.Write("](");
			bool flag = true;
			foreach (CustomAttributeTypedArgument<(PrimitiveTypeCode, string)> item in immutableArray)
			{
				if (!flag)
				{
					output.Write(" ");
				}
				if (item.Value is CustomAttributeTypedArgument<(PrimitiveTypeCode, string)> customAttributeTypedArgument2)
				{
					WriteValue(output, customAttributeTypedArgument2.Type, customAttributeTypedArgument2.Value);
				}
				else
				{
					WriteSimpleValue(output, item.Value, text);
				}
				flag = false;
			}
			output.Write(")");
		}
		else
		{
			string text2 = ((type.Name != null && !type.Name.StartsWith("enum ", StringComparison.Ordinal)) ? type.Name : PrimitiveTypeCodeToString(type.Code));
			output.Write(text2);
			output.Write("(");
			WriteSimpleValue(output, value, text2);
			output.Write(")");
		}
	}

	private static void WriteSimpleValue(ITextOutput output, object value, string typeName)
	{
		if (!(typeName == "string"))
		{
			if (typeName == "type")
			{
				(PrimitiveTypeCode, string) tuple = ((PrimitiveTypeCode, string))value;
				if (tuple.Item2.StartsWith("enum ", StringComparison.Ordinal))
				{
					output.Write(tuple.Item2.Substring(5));
				}
				else
				{
					output.Write(tuple.Item2);
				}
			}
			else
			{
				DisassemblerHelpers.WriteOperand(output, value);
			}
		}
		else
		{
			output.Write("'" + DisassemblerHelpers.EscapeString(value.ToString()).Replace("'", "'") + "'");
		}
	}

	private static string PrimitiveTypeCodeToString(PrimitiveTypeCode typeCode)
	{
		return typeCode switch
		{
			PrimitiveTypeCode.Boolean => "bool", 
			PrimitiveTypeCode.Byte => "uint8", 
			PrimitiveTypeCode.SByte => "int8", 
			PrimitiveTypeCode.Char => "char", 
			PrimitiveTypeCode.Int16 => "int16", 
			PrimitiveTypeCode.UInt16 => "uint16", 
			PrimitiveTypeCode.Int32 => "int32", 
			PrimitiveTypeCode.UInt32 => "uint32", 
			PrimitiveTypeCode.Int64 => "int64", 
			PrimitiveTypeCode.UInt64 => "uint64", 
			PrimitiveTypeCode.Single => "float32", 
			PrimitiveTypeCode.Double => "float64", 
			PrimitiveTypeCode.String => "string", 
			PrimitiveTypeCode.Object => "object", 
			_ => "unknown", 
		};
	}

	private void WriteMarshalInfo(BlobReader marshalInfo)
	{
		output.Write("marshal(");
		WriteNativeType(ref marshalInfo);
		output.Write(") ");
	}

	private void WriteNativeType(ref BlobReader blob)
	{
		byte b;
		int value;
		switch (b = blob.ReadByte())
		{
		case 80:
		case 102:
			break;
		case 2:
			output.Write("bool");
			break;
		case 3:
			output.Write("int8");
			break;
		case 4:
			output.Write("unsigned int8");
			break;
		case 5:
			output.Write("int16");
			break;
		case 6:
			output.Write("unsigned int16");
			break;
		case 7:
			output.Write("int32");
			break;
		case 8:
			output.Write("unsigned int32");
			break;
		case 9:
			output.Write("int64");
			break;
		case 10:
			output.Write("unsigned int64");
			break;
		case 11:
			output.Write("float32");
			break;
		case 12:
			output.Write("float64");
			break;
		case 20:
			output.Write("lpstr");
			break;
		case 31:
			output.Write("int");
			break;
		case 32:
			output.Write("unsigned int");
			break;
		case 38:
			output.Write("Func");
			break;
		case 42:
		{
			if (blob.RemainingBytes > 0)
			{
				WriteNativeType(ref blob);
			}
			output.Write('[');
			int num = (blob.TryReadCompressedInteger(out value) ? value : (-1));
			int num2 = (blob.TryReadCompressedInteger(out value) ? value : (-1));
			int num3 = (blob.TryReadCompressedInteger(out value) ? value : (-1));
			if (num2 >= 0)
			{
				output.Write(num2.ToString());
			}
			if (num >= 0 && num3 != 0)
			{
				output.Write(" + ");
				output.Write(num.ToString());
			}
			output.Write(']');
			break;
		}
		case 15:
			output.Write("currency");
			break;
		case 19:
			output.Write("bstr");
			break;
		case 21:
			output.Write("lpwstr");
			break;
		case 22:
			output.Write("lptstr");
			break;
		case 23:
			output.Write("fixed sysstring[{0}]", blob.ReadCompressedInteger());
			break;
		case 25:
			output.Write("iunknown");
			break;
		case 26:
			output.Write("idispatch");
			break;
		case 27:
			output.Write("struct");
			break;
		case 28:
			output.Write("interface");
			break;
		case 29:
			output.Write("safearray ");
			if (blob.RemainingBytes > 0)
			{
				byte b2 = blob.ReadByte();
				switch (b2)
				{
				case 0:
					break;
				case 2:
					output.Write("int16");
					break;
				case 3:
					output.Write("int32");
					break;
				case 4:
					output.Write("float32");
					break;
				case 5:
					output.Write("float64");
					break;
				case 6:
					output.Write("currency");
					break;
				case 7:
					output.Write("date");
					break;
				case 8:
					output.Write("bstr");
					break;
				case 9:
					output.Write("idispatch");
					break;
				case 10:
					output.Write("error");
					break;
				case 11:
					output.Write("bool");
					break;
				case 12:
					output.Write("variant");
					break;
				case 13:
					output.Write("iunknown");
					break;
				case 14:
					output.Write("decimal");
					break;
				case 16:
					output.Write("int8");
					break;
				case 17:
					output.Write("unsigned int8");
					break;
				case 18:
					output.Write("unsigned int16");
					break;
				case 19:
					output.Write("unsigned int32");
					break;
				case 22:
					output.Write("int");
					break;
				case 23:
					output.Write("unsigned int");
					break;
				default:
					output.Write(b2.ToString());
					break;
				}
			}
			break;
		case 30:
			output.Write("fixed array");
			output.Write("[{0}]", blob.TryReadCompressedInteger(out value) ? value : 0);
			if (blob.RemainingBytes > 0)
			{
				output.Write(' ');
				WriteNativeType(ref blob);
			}
			break;
		case 34:
			output.Write("byvalstr");
			break;
		case 35:
			output.Write("ansi bstr");
			break;
		case 36:
			output.Write("tbstr");
			break;
		case 37:
			output.Write("variant bool");
			break;
		case 40:
			output.Write("as any");
			break;
		case 43:
			output.Write("lpstruct");
			break;
		case 44:
		{
			string text = blob.ReadSerializedString();
			string text2 = blob.ReadSerializedString();
			string str = blob.ReadSerializedString();
			string str2 = blob.ReadSerializedString();
			Guid guid = ((!string.IsNullOrEmpty(text)) ? new Guid(text) : Guid.Empty);
			output.Write("custom(\"{0}\", \"{1}\"", DisassemblerHelpers.EscapeString(str), DisassemblerHelpers.EscapeString(str2));
			if (guid != Guid.Empty || !string.IsNullOrEmpty(text2))
			{
				output.Write(", \"{0}\", \"{1}\"", guid.ToString(), DisassemblerHelpers.EscapeString(text2));
			}
			output.Write(')');
			break;
		}
		case 45:
			output.Write("error");
			break;
		default:
			output.Write(b.ToString());
			break;
		}
	}

	private void WriteParameters(MetadataReader metadata, IEnumerable<ParameterHandle> parameters, MethodSignature<Action<ILNameSyntax>> signature)
	{
		int i = 0;
		checked
		{
			foreach (ParameterHandle parameter2 in parameters)
			{
				Parameter parameter = metadata.GetParameter(parameter2);
				if (parameter.SequenceNumber == 0)
				{
					continue;
				}
				for (; i < parameter.SequenceNumber - 1; i++)
				{
					if (i > 0)
					{
						output.Write(',');
						output.WriteLine();
					}
					signature.ParameterTypes[i](ILNameSyntax.Signature);
					output.Write(" ''");
				}
				if (i > 0)
				{
					output.Write(',');
					output.WriteLine();
				}
				if ((parameter.Attributes & ParameterAttributes.In) == ParameterAttributes.In)
				{
					output.Write("[in] ");
				}
				if ((parameter.Attributes & ParameterAttributes.Out) == ParameterAttributes.Out)
				{
					output.Write("[out] ");
				}
				if ((parameter.Attributes & ParameterAttributes.Optional) == ParameterAttributes.Optional)
				{
					output.Write("[opt] ");
				}
				signature.ParameterTypes[i](ILNameSyntax.Signature);
				output.Write(' ');
				BlobHandle marshallingDescriptor = parameter.GetMarshallingDescriptor();
				if (!marshallingDescriptor.IsNil)
				{
					WriteMarshalInfo(metadata.GetBlobReader(marshallingDescriptor));
				}
				output.WriteLocalReference(DisassemblerHelpers.Escape(metadata.GetString(parameter.Name)), parameter, isDefinition: true);
				i++;
			}
			for (; i < signature.RequiredParameterCount; i++)
			{
				if (i > 0)
				{
					output.Write(',');
					output.WriteLine();
				}
				signature.ParameterTypes[i](ILNameSyntax.Signature);
				output.Write(" ''");
			}
			output.WriteLine();
		}
	}

	private void WriteGenericParameterAttributes(PEFile module, GenericParameterHandle handle)
	{
		MetadataReader metadata = module.Metadata;
		GenericParameter genericParameter = metadata.GetGenericParameter(handle);
		if (genericParameter.GetCustomAttributes().Count != 0)
		{
			output.Write(".param type {0}", metadata.GetString(genericParameter.Name));
			output.WriteLine();
			WriteAttributes(module, genericParameter.GetCustomAttributes());
		}
	}

	private void WriteParameterAttributes(PEFile module, ParameterHandle handle)
	{
		MetadataReader metadata = module.Metadata;
		Parameter parameter = metadata.GetParameter(handle);
		if (!parameter.GetDefaultValue().IsNil || parameter.GetCustomAttributes().Count != 0)
		{
			output.Write(".param [{0}]", parameter.SequenceNumber);
			if (!parameter.GetDefaultValue().IsNil)
			{
				output.Write(" = ");
				WriteConstant(metadata, metadata.GetConstant(parameter.GetDefaultValue()));
			}
			output.WriteLine();
			WriteAttributes(module, parameter.GetCustomAttributes());
		}
	}

	private void WriteConstant(MetadataReader metadata, Constant constant)
	{
		ConstantTypeCode typeCode = constant.TypeCode;
		if (typeCode == ConstantTypeCode.NullReference)
		{
			output.Write("nullref");
			return;
		}
		BlobReader blobReader = metadata.GetBlobReader(constant.Value);
		object obj;
		try
		{
			obj = blobReader.ReadConstant(constant.TypeCode);
		}
		catch (ArgumentOutOfRangeException)
		{
			output.Write($"/* Constant with invalid typecode: {constant.TypeCode} */");
			return;
		}
		if (obj is string)
		{
			DisassemblerHelpers.WriteOperand(output, obj);
			return;
		}
		string text = DisassemblerHelpers.PrimitiveTypeName(obj.GetType().FullName);
		output.Write(text);
		output.Write('(');
		float? num = obj as float?;
		double? num2 = obj as double?;
		if (num.HasValue && (float.IsNaN(num.Value) || float.IsInfinity(num.Value)))
		{
			output.Write("0x{0:x8}", BitConverter.ToInt32(BitConverter.GetBytes(num.Value), 0));
		}
		else if (num2.HasValue && (double.IsNaN(num2.Value) || double.IsInfinity(num2.Value)))
		{
			output.Write("0x{0:x16}", BitConverter.DoubleToInt64Bits(num2.Value));
		}
		else
		{
			DisassemblerHelpers.WriteOperand(output, obj);
		}
		output.Write(')');
	}

	public void DisassembleField(PEFile module, FieldDefinitionHandle field)
	{
		MetadataReader metadata = module.Metadata;
		FieldDefinition fieldDefinition = metadata.GetFieldDefinition(field);
		output.WriteReference(module, field, ".field ", isDefinition: true);
		int offset = fieldDefinition.GetOffset();
		if (offset > -1)
		{
			output.Write("[" + offset + "] ");
		}
		WriteEnum(fieldDefinition.Attributes & FieldAttributes.FieldAccessMask, fieldVisibility);
		WriteFlags(fieldDefinition.Attributes & ~(FieldAttributes.FieldAccessMask | FieldAttributes.HasFieldMarshal | FieldAttributes.HasDefault | FieldAttributes.HasFieldRVA), fieldAttributes);
		Action<ILNameSyntax> action = fieldDefinition.DecodeSignature(new DisassemblerSignatureProvider(module, output), new GenericContext(fieldDefinition.GetDeclaringType(), module));
		BlobHandle marshallingDescriptor = fieldDefinition.GetMarshallingDescriptor();
		if (!marshallingDescriptor.IsNil)
		{
			WriteMarshalInfo(metadata.GetBlobReader(marshallingDescriptor));
		}
		action(ILNameSyntax.Signature);
		output.Write(' ');
		string identifier = metadata.GetString(fieldDefinition.Name);
		output.Write(DisassemblerHelpers.Escape(identifier));
		if (fieldDefinition.HasFlag(FieldAttributes.HasFieldRVA))
		{
			output.Write(" at I_{0:x8}", fieldDefinition.GetRelativeVirtualAddress());
		}
		ConstantHandle defaultValue = fieldDefinition.GetDefaultValue();
		if (!defaultValue.IsNil)
		{
			output.Write(" = ");
			WriteConstant(metadata, metadata.GetConstant(defaultValue));
		}
		output.WriteLine();
		if (fieldDefinition.GetCustomAttributes().Count > 0)
		{
			output.MarkFoldStart();
			WriteAttributes(module, fieldDefinition.GetCustomAttributes());
			output.MarkFoldEnd();
		}
	}

	public void DisassembleProperty(PEFile module, PropertyDefinitionHandle property)
	{
		MetadataReader metadata = module.Metadata;
		PropertyDefinition propertyDefinition = metadata.GetPropertyDefinition(property);
		output.WriteReference(module, property, ".property", isDefinition: true);
		output.Write(" ");
		WriteFlags(propertyDefinition.Attributes, propertyAttributes);
		PropertyAccessors accessors = propertyDefinition.GetAccessors();
		TypeDefinitionHandle declaringType = metadata.GetMethodDefinition(accessors.GetAny()).GetDeclaringType();
		MethodSignature<Action<ILNameSyntax>> signature = propertyDefinition.DecodeSignature(new DisassemblerSignatureProvider(module, output), new GenericContext(declaringType, module));
		if (signature.Header.IsInstance)
		{
			output.Write("instance ");
		}
		signature.ReturnType(ILNameSyntax.Signature);
		output.Write(' ');
		output.Write(DisassemblerHelpers.Escape(metadata.GetString(propertyDefinition.Name)));
		output.Write('(');
		if (signature.ParameterTypes.Length > 0)
		{
			ParameterHandleCollection parameters = metadata.GetMethodDefinition(accessors.GetAny()).GetParameters();
			int num = (accessors.Getter.IsNil ? checked(parameters.Count - 1) : parameters.Count);
			output.WriteLine();
			output.Indent();
			WriteParameters(metadata, Enumerable.Take<ParameterHandle>((IEnumerable<ParameterHandle>)parameters, num), signature);
			output.Unindent();
		}
		output.Write(')');
		OpenBlock(defaultCollapsed: false);
		WriteAttributes(module, propertyDefinition.GetCustomAttributes());
		WriteNestedMethod(".get", module, accessors.Getter);
		WriteNestedMethod(".set", module, accessors.Setter);
		foreach (MethodDefinitionHandle other in accessors.Others)
		{
			WriteNestedMethod(".other", module, other);
		}
		CloseBlock();
	}

	private void WriteNestedMethod(string keyword, PEFile module, MethodDefinitionHandle method)
	{
		if (!method.IsNil)
		{
			output.Write(keyword);
			output.Write(' ');
			InstructionOutputExtensions.WriteTo(method, module, output, GenericContext.Empty);
			output.WriteLine();
		}
	}

	public void DisassembleEvent(PEFile module, EventDefinitionHandle handle)
	{
		EventDefinition eventDefinition = module.Metadata.GetEventDefinition(handle);
		EventAccessors accessors = eventDefinition.GetAccessors();
		TypeDefinitionHandle declaringType = ((!accessors.Adder.IsNil) ? module.Metadata.GetMethodDefinition(accessors.Adder).GetDeclaringType() : (accessors.Remover.IsNil ? module.Metadata.GetMethodDefinition(accessors.Raiser).GetDeclaringType() : module.Metadata.GetMethodDefinition(accessors.Remover).GetDeclaringType()));
		output.WriteReference(module, handle, ".event", isDefinition: true);
		output.Write(" ");
		WriteFlags(eventDefinition.Attributes, eventAttributes);
		DisassemblerSignatureProvider disassemblerSignatureProvider = new DisassemblerSignatureProvider(module, output);
		(eventDefinition.Type.Kind switch
		{
			HandleKind.TypeDefinition => disassemblerSignatureProvider.GetTypeFromDefinition(module.Metadata, (TypeDefinitionHandle)eventDefinition.Type, 0), 
			HandleKind.TypeReference => disassemblerSignatureProvider.GetTypeFromReference(module.Metadata, (TypeReferenceHandle)eventDefinition.Type, 0), 
			HandleKind.TypeSpecification => disassemblerSignatureProvider.GetTypeFromSpecification(module.Metadata, new GenericContext(declaringType, module), (TypeSpecificationHandle)eventDefinition.Type, 0), 
			_ => throw new BadImageFormatException("Expected a TypeDef, TypeRef or TypeSpec handle!"), 
		})(ILNameSyntax.TypeName);
		output.Write(' ');
		output.Write(DisassemblerHelpers.Escape(module.Metadata.GetString(eventDefinition.Name)));
		OpenBlock(defaultCollapsed: false);
		WriteAttributes(module, eventDefinition.GetCustomAttributes());
		WriteNestedMethod(".addon", module, accessors.Adder);
		WriteNestedMethod(".removeon", module, accessors.Remover);
		WriteNestedMethod(".fire", module, accessors.Raiser);
		foreach (MethodDefinitionHandle other in accessors.Others)
		{
			WriteNestedMethod(".other", module, other);
		}
		CloseBlock();
	}

	public void DisassembleType(PEFile module, TypeDefinitionHandle type)
	{
		TypeDefinition typeDefinition = module.Metadata.GetTypeDefinition(type);
		output.WriteReference(module, type, ".class", isDefinition: true);
		output.Write(" ");
		if ((typeDefinition.Attributes & TypeAttributes.ClassSemanticsMask) == TypeAttributes.ClassSemanticsMask)
		{
			output.Write("interface ");
		}
		WriteEnum(typeDefinition.Attributes & TypeAttributes.VisibilityMask, typeVisibility);
		WriteEnum(typeDefinition.Attributes & TypeAttributes.LayoutMask, typeLayout);
		WriteEnum(typeDefinition.Attributes & TypeAttributes.StringFormatMask, typeStringFormat);
		WriteFlags(typeDefinition.Attributes & ~(TypeAttributes.VisibilityMask | TypeAttributes.LayoutMask | TypeAttributes.StringFormatMask | TypeAttributes.ClassSemanticsMask), typeAttributes);
		output.Write(typeDefinition.GetDeclaringType().IsNil ? typeDefinition.GetFullTypeName(module.Metadata).ToILNameString() : DisassemblerHelpers.Escape(module.Metadata.GetString(typeDefinition.Name)));
		GenericContext genericContext = new GenericContext(type, module);
		WriteTypeParameters(output, module, genericContext, typeDefinition.GetGenericParameters());
		output.MarkFoldStart("...", !ExpandMemberDefinitions && isInType);
		output.WriteLine();
		EntityHandle baseTypeOrNil = typeDefinition.GetBaseTypeOrNil();
		if (!baseTypeOrNil.IsNil)
		{
			output.Indent();
			output.Write("extends ");
			baseTypeOrNil.WriteTo(module, output, genericContext, ILNameSyntax.TypeName);
			output.WriteLine();
			output.Unindent();
		}
		InterfaceImplementationHandleCollection interfaceImplementations = typeDefinition.GetInterfaceImplementations();
		if (interfaceImplementations.Count > 0)
		{
			output.Indent();
			bool flag = true;
			foreach (InterfaceImplementationHandle item in interfaceImplementations)
			{
				if (!flag)
				{
					output.WriteLine(",");
				}
				if (flag)
				{
					output.Write("implements ");
				}
				else
				{
					output.Write("           ");
				}
				flag = false;
				InterfaceImplementation interfaceImplementation = module.Metadata.GetInterfaceImplementation(item);
				WriteAttributes(module, interfaceImplementation.GetCustomAttributes());
				interfaceImplementation.Interface.WriteTo(module, output, genericContext, ILNameSyntax.TypeName);
			}
			output.WriteLine();
			output.Unindent();
		}
		output.WriteLine("{");
		output.Indent();
		bool flag2 = isInType;
		isInType = true;
		WriteAttributes(module, typeDefinition.GetCustomAttributes());
		WriteSecurityDeclarations(module, typeDefinition.GetDeclarativeSecurityAttributes());
		TypeLayout layout = typeDefinition.GetLayout();
		if (!layout.IsDefault)
		{
			output.WriteLine(".pack {0}", layout.PackingSize);
			output.WriteLine(".size {0}", layout.Size);
			output.WriteLine();
		}
		ImmutableArray<TypeDefinitionHandle> nestedTypes = typeDefinition.GetNestedTypes();
		if (!nestedTypes.IsEmpty)
		{
			output.WriteLine("// Nested Types");
			foreach (TypeDefinitionHandle item2 in nestedTypes)
			{
				cancellationToken.ThrowIfCancellationRequested();
				DisassembleType(module, item2);
				output.WriteLine();
			}
			output.WriteLine();
		}
		FieldDefinitionHandleCollection fields = typeDefinition.GetFields();
		if (Enumerable.Any<FieldDefinitionHandle>((IEnumerable<FieldDefinitionHandle>)fields))
		{
			output.WriteLine("// Fields");
			foreach (FieldDefinitionHandle item3 in fields)
			{
				cancellationToken.ThrowIfCancellationRequested();
				DisassembleField(module, item3);
			}
			output.WriteLine();
		}
		MethodDefinitionHandleCollection methods = typeDefinition.GetMethods();
		if (Enumerable.Any<MethodDefinitionHandle>((IEnumerable<MethodDefinitionHandle>)methods))
		{
			output.WriteLine("// Methods");
			foreach (MethodDefinitionHandle item4 in methods)
			{
				cancellationToken.ThrowIfCancellationRequested();
				DisassembleMethod(module, item4);
				output.WriteLine();
			}
		}
		EventDefinitionHandleCollection events = typeDefinition.GetEvents();
		if (Enumerable.Any<EventDefinitionHandle>((IEnumerable<EventDefinitionHandle>)events))
		{
			output.WriteLine("// Events");
			foreach (EventDefinitionHandle item5 in events)
			{
				cancellationToken.ThrowIfCancellationRequested();
				DisassembleEvent(module, item5);
				output.WriteLine();
			}
			output.WriteLine();
		}
		PropertyDefinitionHandleCollection properties = typeDefinition.GetProperties();
		if (Enumerable.Any<PropertyDefinitionHandle>((IEnumerable<PropertyDefinitionHandle>)properties))
		{
			output.WriteLine("// Properties");
			foreach (PropertyDefinitionHandle item6 in properties)
			{
				cancellationToken.ThrowIfCancellationRequested();
				DisassembleProperty(module, item6);
			}
			output.WriteLine();
		}
		CloseBlock("end of class " + ((!typeDefinition.GetDeclaringType().IsNil) ? module.Metadata.GetString(typeDefinition.Name) : typeDefinition.GetFullTypeName(module.Metadata).ToString()));
		isInType = flag2;
	}

	private void WriteTypeParameters(ITextOutput output, PEFile module, GenericContext context, GenericParameterHandleCollection p)
	{
		if (p.Count <= 0)
		{
			return;
		}
		output.Write('<');
		MetadataReader metadata = module.Metadata;
		checked
		{
			for (int i = 0; i < p.Count; i++)
			{
				if (i > 0)
				{
					output.Write(", ");
				}
				GenericParameter genericParameter = metadata.GetGenericParameter(p[i]);
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
					for (int j = 0; j < constraints.Count; j++)
					{
						if (j > 0)
						{
							output.Write(", ");
						}
						metadata.GetGenericParameterConstraint(constraints[j]).Type.WriteTo(module, output, context, ILNameSyntax.TypeName);
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
	}

	private void WriteAttributes(PEFile module, CustomAttributeHandleCollection attributes)
	{
		MetadataReader metadata = module.Metadata;
		foreach (CustomAttributeHandle item in attributes)
		{
			output.Write(".custom ");
			CustomAttribute customAttribute = metadata.GetCustomAttribute(item);
			customAttribute.Constructor.WriteTo(module, output, GenericContext.Empty);
			if (!customAttribute.Value.IsNil)
			{
				output.Write(" = ");
				WriteBlob(customAttribute.Value, metadata);
			}
			output.WriteLine();
		}
	}

	private void WriteBlob(BlobHandle blob, MetadataReader metadata)
	{
		BlobReader blobReader = metadata.GetBlobReader(blob);
		WriteBlob(blobReader);
	}

	private void WriteBlob(BlobReader reader)
	{
		output.Write("(");
		output.Indent();
		for (int i = 0; i < reader.Length; i = checked(i + 1))
		{
			if (i % 16 == 0 && i < checked(reader.Length - 1))
			{
				output.WriteLine();
			}
			else
			{
				output.Write(' ');
			}
			output.Write(reader.ReadByte().ToString("x2"));
		}
		output.WriteLine();
		output.Unindent();
		output.Write(")");
	}

	private void OpenBlock(bool defaultCollapsed)
	{
		output.MarkFoldStart("...", !ExpandMemberDefinitions & defaultCollapsed);
		output.WriteLine();
		output.WriteLine("{");
		output.Indent();
	}

	private void CloseBlock(string comment = null)
	{
		output.Unindent();
		output.Write("}");
		if (comment != null)
		{
			output.Write(" // " + comment);
		}
		output.MarkFoldEnd();
		output.WriteLine();
	}

	private void WriteFlags<T>(T flags, EnumNameCollection<T> flagNames) where T : struct
	{
		long num = Convert.ToInt64(flags);
		long num2 = 0L;
		foreach (KeyValuePair<long, string> flagName in flagNames)
		{
			num2 |= flagName.Key;
			if ((num & flagName.Key) != 0L && flagName.Value != null)
			{
				output.Write(flagName.Value);
				output.Write(' ');
			}
		}
		if ((num & ~num2) != 0)
		{
			output.Write("flag({0:x4}) ", num & ~num2);
		}
	}

	private void WriteEnum<T>(T enumValue, EnumNameCollection<T> enumNames) where T : struct
	{
		long num = Convert.ToInt64(enumValue);
		foreach (KeyValuePair<long, string> enumName in enumNames)
		{
			if (enumName.Key == num)
			{
				if (enumName.Value != null)
				{
					output.Write(enumName.Value);
					output.Write(' ');
				}
				return;
			}
		}
		if (num != 0)
		{
			output.Write("flag({0:x4})", num);
			output.Write(' ');
		}
	}

	public void DisassembleNamespace(string nameSpace, PEFile module, IEnumerable<TypeDefinitionHandle> types)
	{
		if (!string.IsNullOrEmpty(nameSpace))
		{
			output.Write(".namespace " + DisassemblerHelpers.Escape(nameSpace));
			OpenBlock(defaultCollapsed: false);
		}
		bool flag = isInType;
		isInType = true;
		foreach (TypeDefinitionHandle type in types)
		{
			cancellationToken.ThrowIfCancellationRequested();
			DisassembleType(module, type);
			output.WriteLine();
		}
		if (!string.IsNullOrEmpty(nameSpace))
		{
			CloseBlock();
			isInType = flag;
		}
	}

	public void WriteAssemblyHeader(PEFile module)
	{
		MetadataReader metadata = module.Metadata;
		if (!metadata.IsAssembly)
		{
			return;
		}
		output.Write(".assembly ");
		AssemblyDefinition assemblyDefinition = metadata.GetAssemblyDefinition();
		if ((assemblyDefinition.Flags & AssemblyFlags.WindowsRuntime) == AssemblyFlags.WindowsRuntime)
		{
			output.Write("windowsruntime ");
		}
		output.Write(DisassemblerHelpers.Escape(metadata.GetString(assemblyDefinition.Name)));
		OpenBlock(defaultCollapsed: false);
		WriteAttributes(module, assemblyDefinition.GetCustomAttributes());
		WriteSecurityDeclarations(module, assemblyDefinition.GetDeclarativeSecurityAttributes());
		if (!assemblyDefinition.PublicKey.IsNil)
		{
			output.Write(".publickey = ");
			WriteBlob(assemblyDefinition.PublicKey, metadata);
			output.WriteLine();
		}
		if (assemblyDefinition.HashAlgorithm != AssemblyHashAlgorithm.None)
		{
			output.Write(".hash algorithm 0x{0:x8}", (int)assemblyDefinition.HashAlgorithm);
			if (assemblyDefinition.HashAlgorithm == AssemblyHashAlgorithm.Sha1)
			{
				output.Write(" // SHA1");
			}
			output.WriteLine();
		}
		Version version = assemblyDefinition.Version;
		if (version != null)
		{
			output.WriteLine(".ver {0}:{1}:{2}:{3}", version.Major, version.Minor, version.Build, version.Revision);
		}
		CloseBlock();
	}

	public void WriteAssemblyReferences(MetadataReader metadata)
	{
		foreach (ModuleReferenceHandle moduleReference2 in metadata.GetModuleReferences())
		{
			ModuleReference moduleReference = metadata.GetModuleReference(moduleReference2);
			output.WriteLine(".module extern {0}", DisassemblerHelpers.Escape(metadata.GetString(moduleReference.Name)));
		}
		foreach (AssemblyReferenceHandle assemblyReference2 in metadata.AssemblyReferences)
		{
			System.Reflection.Metadata.AssemblyReference assemblyReference = metadata.GetAssemblyReference(assemblyReference2);
			output.Write(".assembly extern ");
			if ((assemblyReference.Flags & AssemblyFlags.WindowsRuntime) == AssemblyFlags.WindowsRuntime)
			{
				output.Write("windowsruntime ");
			}
			output.Write(DisassemblerHelpers.Escape(metadata.GetString(assemblyReference.Name)));
			OpenBlock(defaultCollapsed: false);
			if (!assemblyReference.PublicKeyOrToken.IsNil)
			{
				output.Write(".publickeytoken = ");
				WriteBlob(assemblyReference.PublicKeyOrToken, metadata);
				output.WriteLine();
			}
			if (assemblyReference.Version != null)
			{
				output.WriteLine(".ver {0}:{1}:{2}:{3}", assemblyReference.Version.Major, assemblyReference.Version.Minor, assemblyReference.Version.Build, assemblyReference.Version.Revision);
			}
			CloseBlock();
		}
	}

	public void WriteModuleHeader(PEFile module, bool skipMVID = false)
	{
		MetadataReader metadata = module.Metadata;
		foreach (ExportedTypeHandle exportedType3 in metadata.ExportedTypes)
		{
			ExportedType exportedType = metadata.GetExportedType(exportedType3);
			output.Write(".class extern ");
			if (exportedType.IsForwarder)
			{
				output.Write("forwarder ");
			}
			WriteExportedType(exportedType);
			OpenBlock(defaultCollapsed: false);
			switch (exportedType.Implementation.Kind)
			{
			case HandleKind.AssemblyFile:
			{
				AssemblyFile assemblyFile = metadata.GetAssemblyFile((AssemblyFileHandle)exportedType.Implementation);
				output.WriteLine(".file {0}", metadata.GetString(assemblyFile.Name));
				int typeDefinitionId = exportedType.GetTypeDefinitionId();
				if (typeDefinitionId != 0)
				{
					output.WriteLine(".class 0x{0:x8}", typeDefinitionId);
				}
				break;
			}
			case HandleKind.ExportedType:
			{
				output.Write(".class extern ");
				ExportedType exportedType2 = metadata.GetExportedType((ExportedTypeHandle)exportedType.Implementation);
				while (true)
				{
					WriteExportedType(exportedType2);
					if (exportedType2.Implementation.Kind == HandleKind.ExportedType)
					{
						exportedType2 = metadata.GetExportedType((ExportedTypeHandle)exportedType2.Implementation);
						continue;
					}
					break;
				}
				output.WriteLine();
				break;
			}
			case HandleKind.AssemblyReference:
			{
				output.Write(".assembly extern ");
				System.Reflection.Metadata.AssemblyReference assemblyReference = metadata.GetAssemblyReference((AssemblyReferenceHandle)exportedType.Implementation);
				output.Write(DisassemblerHelpers.Escape(metadata.GetString(assemblyReference.Name)));
				output.WriteLine();
				break;
			}
			default:
				throw new BadImageFormatException("Implementation must either be an index into the File, ExportedType or AssemblyRef table.");
			}
			CloseBlock();
		}
		ModuleDefinition moduleDefinition = metadata.GetModuleDefinition();
		output.WriteLine(".module {0}", metadata.GetString(moduleDefinition.Name));
		if (!skipMVID)
		{
			output.WriteLine("// MVID: {0}", metadata.GetGuid(moduleDefinition.Mvid).ToString("B").ToUpperInvariant());
		}
		PEHeaders pEHeaders = module.Reader.PEHeaders;
		output.WriteLine(".imagebase 0x{0:x8}", pEHeaders.PEHeader.ImageBase);
		output.WriteLine(".file alignment 0x{0:x8}", pEHeaders.PEHeader.FileAlignment);
		output.WriteLine(".stackreserve 0x{0:x8}", pEHeaders.PEHeader.SizeOfStackReserve);
		output.WriteLine(".subsystem 0x{0:x} // {1}", pEHeaders.PEHeader.Subsystem, pEHeaders.PEHeader.Subsystem.ToString());
		output.WriteLine(".corflags 0x{0:x} // {1}", pEHeaders.CorHeader.Flags, pEHeaders.CorHeader.Flags.ToString());
		WriteAttributes(module, metadata.GetCustomAttributes(EntityHandle.ModuleDefinition));
		void WriteExportedType(ExportedType exportedType3)
		{
			if (!exportedType3.Namespace.IsNil)
			{
				output.Write(DisassemblerHelpers.Escape(metadata.GetString(exportedType3.Namespace)));
				output.Write('.');
			}
			output.Write(DisassemblerHelpers.Escape(metadata.GetString(exportedType3.Name)));
		}
	}

	public void WriteModuleContents(PEFile module)
	{
		foreach (TypeDefinitionHandle topLevelTypeDefinition in module.Metadata.GetTopLevelTypeDefinitions())
		{
			DisassembleType(module, topLevelTypeDefinition);
			output.WriteLine();
		}
	}
}
