using System;
using System.Collections;
using System.Collections.Generic;
using dnlib.DotNet;
using dnSpy.Contracts.Decompiler;
using dnSpy.Contracts.Text;
using ICSharpCode.NRefactory.CSharp;

namespace ICSharpCode.Decompiler.Disassembler;

public sealed class ReflectionDisassembler
{
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

	private readonly IDecompilerOutput output;

	private readonly DisassemblerOptions options;

	private readonly InstructionOperandConverter instructionOperandConverter;

	private bool isInType;

	private MethodBodyDisassembler methodBodyDisassembler;

	private IMemberDef currentMember;

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

	private EnumNameCollection<CallingConvention> callingConvention = new EnumNameCollection<CallingConvention>
	{
		{
			CallingConvention.C,
			"unmanaged cdecl"
		},
		{
			CallingConvention.StdCall,
			"unmanaged stdcall"
		},
		{
			CallingConvention.ThisCall,
			"unmanaged thiscall"
		},
		{
			CallingConvention.FastCall,
			"unmanaged fastcall"
		},
		{
			CallingConvention.VarArg,
			"vararg"
		},
		{
			CallingConvention.NativeVarArg,
			"nativevararg"
		},
		{
			CallingConvention.Generic,
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

	public ReflectionDisassembler(IDecompilerOutput output, bool detectControlStructure, DisassemblerOptions options)
	{
		if (output == null)
		{
			throw new ArgumentNullException("output");
		}
		this.output = output;
		this.options = options;
		methodBodyDisassembler = new MethodBodyDisassembler(output, detectControlStructure, options);
		instructionOperandConverter = new InstructionOperandConverter();
	}

	private void WriteXmlDocComment(IMemberDef mr)
	{
		if (options.GetXmlDocComments == null)
		{
			return;
		}
		foreach (string item in options.GetXmlDocComments(mr))
		{
			output.Write("///", BoxedTextColor.XmlDocCommentDelimiter);
			output.WriteXmlDoc(item);
			output.WriteLine();
		}
	}

	public void DisassembleMethod(MethodDef method, bool addLineSep = true)
	{
		currentMember = method;
		WriteXmlDocComment(method);
		AddComment(method);
		int nextPosition = output.NextPosition;
		output.Write(".method", BoxedTextColor.ILDirective);
		output.Write(" ", BoxedTextColor.Text);
		DisassembleMethodInternal(method, addLineSep, nextPosition);
	}

	private void DisassembleMethodInternal(MethodDef method, bool addLineSep, int methodStartPosition)
	{
		WriteEnum(method.Attributes & MethodAttributes.MemberAccessMask, methodVisibility);
		WriteFlags(method.Attributes & ~MethodAttributes.MemberAccessMask, methodAttributeFlags);
		if (method.IsCompilerControlled)
		{
			output.Write("privatescope", BoxedTextColor.Keyword);
			output.Write(" ", BoxedTextColor.Text);
		}
		if ((method.Attributes & MethodAttributes.PinvokeImpl) == MethodAttributes.PinvokeImpl)
		{
			output.Write("pinvokeimpl", BoxedTextColor.Keyword);
			if (method.HasImplMap)
			{
				ImplMap implMap = method.ImplMap;
				BracePairHelper bracePairHelper = BracePairHelper.Create(output, "(", CodeBracesRangeFlags.BraceKind_Parentheses);
				output.Write("\"" + TextWriterTokenWriter.ConvertString((implMap.Module == null) ? string.Empty : implMap.Module.Name.String) + "\"", BoxedTextColor.String);
				if (!string.IsNullOrEmpty(implMap.Name) && implMap.Name != method.Name)
				{
					output.Write(" ", BoxedTextColor.Text);
					output.Write("as", BoxedTextColor.Keyword);
					output.Write(" ", BoxedTextColor.Text);
					output.Write("\"" + TextWriterTokenWriter.ConvertString(implMap.Name) + "\"", BoxedTextColor.String);
				}
				if (implMap.IsNoMangle)
				{
					output.Write(" ", BoxedTextColor.Text);
					output.Write("nomangle", BoxedTextColor.Keyword);
				}
				if (implMap.IsCharSetAnsi)
				{
					output.Write(" ", BoxedTextColor.Text);
					output.Write("ansi", BoxedTextColor.Keyword);
				}
				else if (implMap.IsCharSetAuto)
				{
					output.Write(" ", BoxedTextColor.Text);
					output.Write("autochar", BoxedTextColor.Keyword);
				}
				else if (implMap.IsCharSetUnicode)
				{
					output.Write(" ", BoxedTextColor.Text);
					output.Write("unicode", BoxedTextColor.Keyword);
				}
				if (implMap.SupportsLastError)
				{
					output.Write(" ", BoxedTextColor.Text);
					output.Write("lasterr", BoxedTextColor.Keyword);
				}
				if (implMap.IsCallConvCdecl)
				{
					output.Write(" ", BoxedTextColor.Text);
					output.Write("cdecl", BoxedTextColor.Keyword);
				}
				else if (implMap.IsCallConvFastcall)
				{
					output.Write(" ", BoxedTextColor.Text);
					output.Write("fastcall", BoxedTextColor.Keyword);
				}
				else if (implMap.IsCallConvStdcall)
				{
					output.Write(" ", BoxedTextColor.Text);
					output.Write("stdcall", BoxedTextColor.Keyword);
				}
				else if (implMap.IsCallConvThiscall)
				{
					output.Write(" ", BoxedTextColor.Text);
					output.Write("thiscall", BoxedTextColor.Keyword);
				}
				else if (implMap.IsCallConvWinapi)
				{
					output.Write(" ", BoxedTextColor.Text);
					output.Write("winapi", BoxedTextColor.Keyword);
				}
				bracePairHelper.Write(")");
			}
			output.Write(" ", BoxedTextColor.Text);
		}
		output.WriteLine();
		output.IncreaseIndent();
		if (method.ExplicitThis)
		{
			output.Write("instance", BoxedTextColor.Keyword);
			output.Write(" ", BoxedTextColor.Text);
			output.Write("explicit", BoxedTextColor.Keyword);
			output.Write(" ", BoxedTextColor.Text);
		}
		else if (method.HasThis)
		{
			output.Write("instance", BoxedTextColor.Keyword);
			output.Write(" ", BoxedTextColor.Text);
		}
		WriteEnum(method.CallingConvention & (CallingConvention.Mask | CallingConvention.Generic), callingConvention);
		method.ReturnType.WriteTo(output);
		output.Write(" ", BoxedTextColor.Text);
		if (method.Parameters.ReturnParameter.HasParamDef && method.Parameters.ReturnParameter.ParamDef.HasMarshalType)
		{
			WriteMarshalInfo(method.Parameters.ReturnParameter.ParamDef.MarshalType);
		}
		if (method.IsCompilerControlled)
		{
			output.Write(DisassemblerHelpers.Escape(string.Concat(method.Name, "$PST", method.MDToken.ToInt32().ToString("X8"))), method, DecompilerReferenceFlags.Definition, CSharpMetadataTextColorProvider.Instance.GetColor(method));
		}
		else
		{
			output.Write(DisassemblerHelpers.Escape(method.Name), method, DecompilerReferenceFlags.Definition, CSharpMetadataTextColorProvider.Instance.GetColor(method));
		}
		WriteTypeParameters(output, method);
		output.Write(" ", BoxedTextColor.Text);
		BracePairHelper bracePairHelper2 = BracePairHelper.Create(output, "(", CodeBracesRangeFlags.BraceKind_Parentheses);
		if (method.Parameters.GetNumberOfNormalParameters() > 0)
		{
			output.WriteLine();
			output.IncreaseIndent();
			WriteParameters(method.Parameters);
			output.DecreaseIndent();
		}
		bracePairHelper2.Write(")");
		output.Write(" ", BoxedTextColor.Text);
		WriteEnum(method.ImplAttributes & MethodImplAttributes.CodeTypeMask, methodCodeType);
		if ((method.ImplAttributes & MethodImplAttributes.ManagedMask) == 0)
		{
			output.Write("managed", BoxedTextColor.Keyword);
		}
		else
		{
			output.Write("unmanaged", BoxedTextColor.Keyword);
		}
		output.Write(" ", BoxedTextColor.Text);
		WriteFlags(method.ImplAttributes & ~(MethodImplAttributes.CodeTypeMask | MethodImplAttributes.ManagedMask), methodImpl);
		output.DecreaseIndent();
		BracePairHelper bh = OpenBlock(isInType, CodeBracesRangeFlags.MethodBraces);
		WriteAttributes(method.CustomAttributes);
		if (method.HasOverrides)
		{
			foreach (MethodOverride @override in method.Overrides)
			{
				output.Write(".override", BoxedTextColor.ILDirective);
				output.Write(" ", BoxedTextColor.Text);
				output.Write("method", BoxedTextColor.Keyword);
				output.Write(" ", BoxedTextColor.Text);
				@override.MethodDeclaration.WriteMethodTo(output);
				output.WriteLine();
			}
		}
		WriteParameterAttributes(0, method.Parameters.ReturnParameter);
		foreach (Parameter parameter in method.Parameters)
		{
			if (!parameter.IsHiddenThisParameter)
			{
				WriteParameterAttributes(parameter.MethodSigIndex + 1, parameter);
			}
		}
		WriteSecurityDeclarations(method);
		MethodDebugInfoBuilder methodDebugInfoBuilder = null;
		if (method.HasBody)
		{
			instructionOperandConverter.Clear();
			instructionOperandConverter.Add(method);
			methodDebugInfoBuilder = new MethodDebugInfoBuilder(options.OptionsVersion, StateMachineKind.None, method, null, instructionOperandConverter.GetSourceLocals(), null, null);
			methodDebugInfoBuilder.StartPosition = methodStartPosition;
			methodBodyDisassembler.Disassemble(method, methodDebugInfoBuilder, instructionOperandConverter);
		}
		int value = CloseBlock(bh, addLineSep, "end of method " + DisassemblerHelpers.Escape(method.DeclaringType.Name) + "::" + DisassemblerHelpers.Escape(method.Name));
		if (method.HasBody)
		{
			methodDebugInfoBuilder.EndPosition = value;
			output.AddDebugInfo(methodDebugInfoBuilder.Create());
		}
	}

	private void WriteSecurityDeclarations(IHasDeclSecurity secDeclProvider)
	{
		if (!secDeclProvider.HasDeclSecurities)
		{
			return;
		}
		foreach (DeclSecurity declSecurity in secDeclProvider.DeclSecurities)
		{
			output.Write(".permissionset", BoxedTextColor.ILDirective);
			output.Write(" ", BoxedTextColor.Text);
			switch (declSecurity.Action)
			{
			case SecurityAction.Request:
				output.Write("request", BoxedTextColor.Keyword);
				break;
			case SecurityAction.Demand:
				output.Write("demand", BoxedTextColor.Keyword);
				break;
			case SecurityAction.Assert:
				output.Write("assert", BoxedTextColor.Keyword);
				break;
			case SecurityAction.Deny:
				output.Write("deny", BoxedTextColor.Keyword);
				break;
			case SecurityAction.PermitOnly:
				output.Write("permitonly", BoxedTextColor.Keyword);
				break;
			case SecurityAction.LinktimeCheck:
				output.Write("linkcheck", BoxedTextColor.Keyword);
				break;
			case SecurityAction.InheritanceCheck:
				output.Write("inheritcheck", BoxedTextColor.Keyword);
				break;
			case SecurityAction.RequestMinimum:
				output.Write("reqmin", BoxedTextColor.Keyword);
				break;
			case SecurityAction.RequestOptional:
				output.Write("reqopt", BoxedTextColor.Keyword);
				break;
			case SecurityAction.RequestRefuse:
				output.Write("reqrefuse", BoxedTextColor.Keyword);
				break;
			case SecurityAction.PrejitGrant:
				output.Write("prejitgrant", BoxedTextColor.Keyword);
				break;
			case SecurityAction.PrejitDenied:
				output.Write("prejitdeny", BoxedTextColor.Keyword);
				break;
			case SecurityAction.NonCasDemand:
				output.Write("noncasdemand", BoxedTextColor.Keyword);
				break;
			case SecurityAction.NonCasLinkDemand:
				output.Write("noncaslinkdemand", BoxedTextColor.Keyword);
				break;
			case SecurityAction.NonCasInheritance:
				output.Write("noncasinheritance", BoxedTextColor.Keyword);
				break;
			default:
				output.Write(declSecurity.Action.ToString(), BoxedTextColor.Keyword);
				break;
			}
			output.Write(" ", BoxedTextColor.Text);
			output.Write("=", BoxedTextColor.Operator);
			output.Write(" ", BoxedTextColor.Text);
			BracePairHelper bracePairHelper = BracePairHelper.Create(output, "{", CodeBracesRangeFlags.OtherBlockBraces);
			output.WriteLine();
			output.IncreaseIndent();
			for (int i = 0; i < declSecurity.SecurityAttributes.Count; i++)
			{
				SecurityAttribute securityAttribute = declSecurity.SecurityAttributes[i];
				if (securityAttribute.AttributeType != null && securityAttribute.AttributeType.Scope == securityAttribute.AttributeType.Module)
				{
					output.Write("class", BoxedTextColor.Keyword);
					output.Write(" ", BoxedTextColor.Text);
					output.Write(DisassemblerHelpers.Escape(GetAssemblyQualifiedName(securityAttribute.AttributeType)), BoxedTextColor.Text);
				}
				else
				{
					securityAttribute.AttributeType.WriteTo(output, ILNameSyntax.TypeName);
				}
				output.Write(" ", BoxedTextColor.Text);
				output.Write("=", BoxedTextColor.Operator);
				output.Write(" ", BoxedTextColor.Text);
				BracePairHelper bracePairHelper2 = BracePairHelper.Create(output, "{", CodeBracesRangeFlags.OtherBlockBraces);
				if (securityAttribute.HasNamedArguments)
				{
					output.WriteLine();
					output.IncreaseIndent();
					TypeDef attrType = securityAttribute.AttributeType.ResolveTypeDef();
					foreach (CANamedArgument field in securityAttribute.Fields)
					{
						output.Write("field", BoxedTextColor.Keyword);
						output.Write(" ", BoxedTextColor.Text);
						WriteSecurityDeclarationArgument(attrType, field);
						output.WriteLine();
					}
					foreach (CANamedArgument property in securityAttribute.Properties)
					{
						output.Write("property", BoxedTextColor.Keyword);
						output.Write(" ", BoxedTextColor.Text);
						WriteSecurityDeclarationArgument(attrType, property);
						output.WriteLine();
					}
					output.DecreaseIndent();
				}
				bracePairHelper2.Write("}");
				if (i + 1 < declSecurity.SecurityAttributes.Count)
				{
					output.Write(",", BoxedTextColor.Punctuation);
				}
				output.WriteLine();
			}
			output.DecreaseIndent();
			bracePairHelper.Write("}");
			output.WriteLine();
		}
	}

	private void WriteSecurityDeclarationArgument(TypeDef attrType, CANamedArgument na)
	{
		object reference = null;
		if (attrType != null)
		{
			reference = ((!na.IsField) ? ((object)attrType.FindProperty(na.Name, PropertySig.CreateInstance(na.Type))) : ((object)attrType.FindField(na.Name, new FieldSig(na.Type))));
		}
		TypeSig type = na.Argument.Type;
		if (type != null && (type.ElementType == ElementType.Class || type.ElementType == ElementType.ValueType))
		{
			output.Write("enum", BoxedTextColor.Keyword);
			output.Write(" ", BoxedTextColor.Text);
			if (type.Scope != type.Module)
			{
				output.Write("class", BoxedTextColor.Keyword);
				output.Write(" ", BoxedTextColor.Text);
				output.Write(DisassemblerHelpers.Escape(GetAssemblyQualifiedName(type)), BoxedTextColor.Text);
			}
			else
			{
				type.WriteTo(output, ILNameSyntax.TypeName);
			}
		}
		else
		{
			type.WriteTo(output);
		}
		output.Write(" ", BoxedTextColor.Text);
		output.Write(DisassemblerHelpers.Escape(na.Name), reference, DecompilerReferenceFlags.None, na.IsField ? BoxedTextColor.InstanceField : BoxedTextColor.InstanceProperty);
		output.Write(" ", BoxedTextColor.Text);
		output.Write("=", BoxedTextColor.Operator);
		output.Write(" ", BoxedTextColor.Text);
		if (na.Argument.Value is UTF8String)
		{
			output.Write("string", BoxedTextColor.Keyword);
			BracePairHelper bracePairHelper = BracePairHelper.Create(output, "(", CodeBracesRangeFlags.BraceKind_Parentheses);
			output.Write(string.Format("'{0}'", TextWriterTokenWriter.ConvertString((UTF8String)na.Argument.Value).Replace("'", "'")), BoxedTextColor.String);
			bracePairHelper.Write(")");
		}
		else
		{
			WriteConstant(na.Argument.Value);
		}
	}

	private string GetAssemblyQualifiedName(IType type)
	{
		IAssembly assembly = type.Scope as IAssembly;
		if (assembly == null && type.Scope is ModuleDef moduleDef)
		{
			assembly = moduleDef.Assembly;
		}
		if (assembly != null)
		{
			return type.FullName + ", " + assembly.FullName;
		}
		return type.FullName;
	}

	private void WriteMarshalInfo(MarshalType marshalInfo)
	{
		output.Write("marshal", BoxedTextColor.Keyword);
		BracePairHelper bracePairHelper = BracePairHelper.Create(output, "(", CodeBracesRangeFlags.BraceKind_Parentheses);
		if (marshalInfo != null)
		{
			WriteNativeType(marshalInfo.NativeType, marshalInfo);
		}
		bracePairHelper.Write(")");
		output.Write(" ", BoxedTextColor.Text);
	}

	private void WriteNativeType(NativeType nativeType, MarshalType marshalInfo = null)
	{
		switch (nativeType)
		{
		case NativeType.Boolean:
			output.Write("bool", BoxedTextColor.Keyword);
			break;
		case NativeType.I1:
			output.Write("int8", BoxedTextColor.Keyword);
			break;
		case NativeType.U1:
			output.Write("unsigned", BoxedTextColor.Keyword);
			output.Write(" ", BoxedTextColor.Text);
			output.Write("int8", BoxedTextColor.Keyword);
			break;
		case NativeType.I2:
			output.Write("int16", BoxedTextColor.Keyword);
			break;
		case NativeType.U2:
			output.Write("unsigned", BoxedTextColor.Keyword);
			output.Write(" ", BoxedTextColor.Text);
			output.Write("int16", BoxedTextColor.Keyword);
			break;
		case NativeType.I4:
			output.Write("int32", BoxedTextColor.Keyword);
			break;
		case NativeType.U4:
			output.Write("unsigned", BoxedTextColor.Keyword);
			output.Write(" ", BoxedTextColor.Text);
			output.Write("int32", BoxedTextColor.Keyword);
			break;
		case NativeType.I8:
			output.Write("int64", BoxedTextColor.Keyword);
			break;
		case NativeType.U8:
			output.Write("unsigned", BoxedTextColor.Keyword);
			output.Write(" ", BoxedTextColor.Text);
			output.Write("int64", BoxedTextColor.Keyword);
			break;
		case NativeType.R4:
			output.Write("float32", BoxedTextColor.Keyword);
			break;
		case NativeType.R8:
			output.Write("float64", BoxedTextColor.Keyword);
			break;
		case NativeType.LPStr:
			output.Write("lpstr", BoxedTextColor.Keyword);
			break;
		case NativeType.Int:
			output.Write("int", BoxedTextColor.Keyword);
			break;
		case NativeType.UInt:
			output.Write("unsigned", BoxedTextColor.Keyword);
			output.Write(" ", BoxedTextColor.Text);
			output.Write("int", BoxedTextColor.Keyword);
			break;
		case NativeType.Func:
			output.Write("method", BoxedTextColor.Keyword);
			break;
		case NativeType.Array:
			if (marshalInfo is ArrayMarshalType arrayMarshalType)
			{
				if (arrayMarshalType.ElementType != NativeType.Max)
				{
					WriteNativeType(arrayMarshalType.ElementType);
				}
				BracePairHelper bracePairHelper5 = BracePairHelper.Create(output, "[", CodeBracesRangeFlags.BraceKind_SquareBrackets);
				if (arrayMarshalType.Flags == 0)
				{
					output.Write(arrayMarshalType.Size.ToString(), BoxedTextColor.Number);
				}
				else
				{
					if (arrayMarshalType.Size >= 0)
					{
						output.Write(arrayMarshalType.Size.ToString(), BoxedTextColor.Number);
					}
					output.Write(" ", BoxedTextColor.Text);
					output.Write("+", BoxedTextColor.Operator);
					output.Write(" ", BoxedTextColor.Text);
					output.Write(arrayMarshalType.ParamNumber.ToString(), BoxedTextColor.Number);
				}
				bracePairHelper5.Write("]");
				break;
			}
			goto default;
		case NativeType.Currency:
			output.Write("currency", BoxedTextColor.Keyword);
			break;
		case NativeType.BStr:
			output.Write("bstr", BoxedTextColor.Keyword);
			break;
		case NativeType.LPWStr:
			output.Write("lpwstr", BoxedTextColor.Keyword);
			break;
		case NativeType.LPTStr:
			output.Write("lptstr", BoxedTextColor.Keyword);
			break;
		case NativeType.FixedSysString:
		{
			FixedSysStringMarshalType fixedSysStringMarshalType = marshalInfo as FixedSysStringMarshalType;
			output.Write("fixed", BoxedTextColor.Keyword);
			output.Write(" ", BoxedTextColor.Text);
			output.Write("sysstring", BoxedTextColor.Keyword);
			if (fixedSysStringMarshalType != null && fixedSysStringMarshalType.IsSizeValid)
			{
				BracePairHelper bracePairHelper3 = BracePairHelper.Create(output, "[", CodeBracesRangeFlags.BraceKind_SquareBrackets);
				output.Write($"{fixedSysStringMarshalType.Size}", BoxedTextColor.Number);
				bracePairHelper3.Write("]");
			}
			break;
		}
		case NativeType.IUnknown:
			output.Write("iunknown", BoxedTextColor.Keyword);
			goto IL_0534;
		case NativeType.IDispatch:
			output.Write("idispatch", BoxedTextColor.Keyword);
			goto IL_0534;
		case NativeType.IntF:
			if (nativeType == NativeType.IntF)
			{
				output.Write("interface", BoxedTextColor.Keyword);
				goto IL_0534;
			}
			throw new InvalidOperationException();
		case NativeType.Struct:
			output.Write("struct", BoxedTextColor.Keyword);
			break;
		case NativeType.SafeArray:
			output.Write("safearray", BoxedTextColor.Keyword);
			output.Write(" ", BoxedTextColor.Text);
			if (marshalInfo is SafeArrayMarshalType { IsVariantTypeValid: not false } safeArrayMarshalType)
			{
				switch (safeArrayMarshalType.VariantType & VariantType.BStrBlob)
				{
				case VariantType.Null:
					output.Write("null", BoxedTextColor.Keyword);
					break;
				case VariantType.I2:
					output.Write("int16", BoxedTextColor.Keyword);
					break;
				case VariantType.I4:
					output.Write("int32", BoxedTextColor.Keyword);
					break;
				case VariantType.R4:
					output.Write("float32", BoxedTextColor.Keyword);
					break;
				case VariantType.R8:
					output.Write("float64", BoxedTextColor.Keyword);
					break;
				case VariantType.CY:
					output.Write("currency", BoxedTextColor.Keyword);
					break;
				case VariantType.Date:
					output.Write("date", BoxedTextColor.Keyword);
					break;
				case VariantType.BStr:
					output.Write("bstr", BoxedTextColor.Keyword);
					break;
				case VariantType.Dispatch:
					output.Write("idispatch", BoxedTextColor.Keyword);
					break;
				case VariantType.Error:
					output.Write("error", BoxedTextColor.Keyword);
					break;
				case VariantType.Bool:
					output.Write("bool", BoxedTextColor.Keyword);
					break;
				case VariantType.Variant:
					output.Write("variant", BoxedTextColor.Keyword);
					break;
				case VariantType.Unknown:
					output.Write("iunknown", BoxedTextColor.Keyword);
					break;
				case VariantType.Decimal:
					output.Write("decimal", BoxedTextColor.Keyword);
					break;
				case VariantType.I1:
					output.Write("int8", BoxedTextColor.Keyword);
					break;
				case VariantType.UI1:
					output.Write("unsigned", BoxedTextColor.Keyword);
					output.Write(" ", BoxedTextColor.Text);
					output.Write("int8", BoxedTextColor.Keyword);
					break;
				case VariantType.UI2:
					output.Write("unsigned", BoxedTextColor.Keyword);
					output.Write(" ", BoxedTextColor.Text);
					output.Write("int16", BoxedTextColor.Keyword);
					break;
				case VariantType.UI4:
					output.Write("unsigned", BoxedTextColor.Keyword);
					output.Write(" ", BoxedTextColor.Text);
					output.Write("int32", BoxedTextColor.Keyword);
					break;
				case VariantType.I8:
					output.Write("int64", BoxedTextColor.Keyword);
					break;
				case VariantType.UI8:
					output.Write("unsigned", BoxedTextColor.Keyword);
					output.Write(" ", BoxedTextColor.Text);
					output.Write("int64", BoxedTextColor.Keyword);
					break;
				case VariantType.Int:
					output.Write("int", BoxedTextColor.Keyword);
					break;
				case VariantType.UInt:
					output.Write("unsigned", BoxedTextColor.Keyword);
					output.Write(" ", BoxedTextColor.Text);
					output.Write("int", BoxedTextColor.Keyword);
					break;
				case VariantType.Void:
					output.Write("void", BoxedTextColor.Keyword);
					break;
				case VariantType.HResult:
					output.Write("hresult", BoxedTextColor.Keyword);
					break;
				case VariantType.Ptr:
					output.Write("*", BoxedTextColor.Operator);
					break;
				case VariantType.SafeArray:
					output.Write("safearray", BoxedTextColor.Keyword);
					break;
				case VariantType.CArray:
					output.Write("carray", BoxedTextColor.Keyword);
					break;
				case VariantType.UserDefined:
					output.Write("userdefined", BoxedTextColor.Keyword);
					break;
				case VariantType.LPStr:
					output.Write("lpstr", BoxedTextColor.Keyword);
					break;
				case VariantType.LPWStr:
					output.Write("lpwstr", BoxedTextColor.Keyword);
					break;
				case VariantType.Record:
					output.Write("record", BoxedTextColor.Keyword);
					break;
				case VariantType.FileTime:
					output.Write("filetime", BoxedTextColor.Keyword);
					break;
				case VariantType.Blob:
					output.Write("blob", BoxedTextColor.Keyword);
					break;
				case VariantType.Stream:
					output.Write("stream", BoxedTextColor.Keyword);
					break;
				case VariantType.Storage:
					output.Write("storage", BoxedTextColor.Keyword);
					break;
				case VariantType.StreamedObject:
					output.Write("streamed_object", BoxedTextColor.Keyword);
					break;
				case VariantType.StoredObject:
					output.Write("stored_object", BoxedTextColor.Keyword);
					break;
				case VariantType.BlobObject:
					output.Write("blob_object", BoxedTextColor.Keyword);
					break;
				case VariantType.CF:
					output.Write("cf", BoxedTextColor.Keyword);
					break;
				case VariantType.CLSID:
					output.Write("clsid", BoxedTextColor.Keyword);
					break;
				default:
					output.Write((safeArrayMarshalType.VariantType & VariantType.BStrBlob).ToString(), BoxedTextColor.Keyword);
					break;
				case VariantType.Empty:
					break;
				}
				if ((safeArrayMarshalType.VariantType & VariantType.ByRef) != VariantType.Empty)
				{
					output.Write("&", BoxedTextColor.Operator);
				}
				if ((safeArrayMarshalType.VariantType & VariantType.Array) != VariantType.Empty)
				{
					output.Write("[]", BoxedTextColor.Punctuation);
				}
				if ((safeArrayMarshalType.VariantType & VariantType.Vector) != VariantType.Empty)
				{
					output.Write(" ", BoxedTextColor.Text);
					output.Write("vector", BoxedTextColor.Keyword);
				}
				if (safeArrayMarshalType.IsUserDefinedSubTypeValid)
				{
					output.Write(",", BoxedTextColor.Punctuation);
					output.Write(" ", BoxedTextColor.Text);
					output.Write("\"" + TextWriterTokenWriter.ConvertString(safeArrayMarshalType.UserDefinedSubType.FullName) + "\"", BoxedTextColor.String);
				}
			}
			break;
		case NativeType.FixedArray:
			output.Write("fixed", BoxedTextColor.Keyword);
			output.Write(" ", BoxedTextColor.Text);
			output.Write("array", BoxedTextColor.Keyword);
			if (marshalInfo is FixedArrayMarshalType fixedArrayMarshalType)
			{
				if (fixedArrayMarshalType.IsSizeValid)
				{
					BracePairHelper bracePairHelper4 = BracePairHelper.Create(output, "[", CodeBracesRangeFlags.BraceKind_SquareBrackets);
					output.Write(fixedArrayMarshalType.Size.ToString(), BoxedTextColor.Number);
					bracePairHelper4.Write("]");
				}
				if (fixedArrayMarshalType.IsElementTypeValid)
				{
					output.Write(" ", BoxedTextColor.Text);
					WriteNativeType(fixedArrayMarshalType.ElementType);
				}
			}
			break;
		case NativeType.ByValStr:
			output.Write("byvalstr", BoxedTextColor.Keyword);
			break;
		case NativeType.ANSIBStr:
			output.Write("ansi", BoxedTextColor.Keyword);
			output.Write(" ", BoxedTextColor.Text);
			output.Write("bstr", BoxedTextColor.Keyword);
			break;
		case NativeType.TBStr:
			output.Write("tbstr", BoxedTextColor.Keyword);
			break;
		case NativeType.VariantBool:
			output.Write("variant", BoxedTextColor.Keyword);
			output.Write(" ", BoxedTextColor.Text);
			output.Write("bool", BoxedTextColor.Keyword);
			break;
		case NativeType.ASAny:
			output.Write("as", BoxedTextColor.Keyword);
			output.Write(" ", BoxedTextColor.Text);
			output.Write("any", BoxedTextColor.Keyword);
			break;
		case NativeType.LPStruct:
			output.Write("lpstruct", BoxedTextColor.Keyword);
			break;
		case NativeType.CustomMarshaler:
			if (marshalInfo is CustomMarshalType customMarshalType)
			{
				output.Write("custom", BoxedTextColor.Keyword);
				BracePairHelper bracePairHelper = BracePairHelper.Create(output, "(", CodeBracesRangeFlags.BraceKind_Parentheses);
				output.Write($"\"{TextWriterTokenWriter.ConvertString((customMarshalType.CustomMarshaler == null) ? string.Empty : customMarshalType.CustomMarshaler.FullName)}\"", BoxedTextColor.String);
				output.Write(",", BoxedTextColor.Punctuation);
				output.Write(" ", BoxedTextColor.Text);
				output.Write($"\"{TextWriterTokenWriter.ConvertString(customMarshalType.Cookie)}\"", BoxedTextColor.String);
				if (!UTF8String.IsNullOrEmpty(customMarshalType.Guid) || !UTF8String.IsNullOrEmpty(customMarshalType.NativeTypeName))
				{
					output.Write(",", BoxedTextColor.Punctuation);
					output.Write(" ", BoxedTextColor.Text);
					output.Write($"\"{TextWriterTokenWriter.ConvertString(customMarshalType.Guid)}\"", BoxedTextColor.String);
					output.Write(",", BoxedTextColor.Punctuation);
					output.Write(" ", BoxedTextColor.Text);
					output.Write($"\"{TextWriterTokenWriter.ConvertString(customMarshalType.NativeTypeName)}\"", BoxedTextColor.String);
				}
				bracePairHelper.Write(")");
				break;
			}
			goto default;
		case NativeType.Error:
			output.Write("error", BoxedTextColor.Keyword);
			break;
		case NativeType.Void:
			output.Write("void", BoxedTextColor.Keyword);
			break;
		case NativeType.SysChar:
			output.Write("syschar", BoxedTextColor.Keyword);
			break;
		case NativeType.Variant:
			output.Write("variant", BoxedTextColor.Keyword);
			break;
		case NativeType.Decimal:
			output.Write("decimal", BoxedTextColor.Keyword);
			break;
		case NativeType.Date:
			output.Write("date", BoxedTextColor.Keyword);
			break;
		case NativeType.ObjectRef:
			output.Write("objectref", BoxedTextColor.Keyword);
			break;
		case NativeType.NestedStruct:
			output.Write("nested", BoxedTextColor.Keyword);
			output.Write(" ", BoxedTextColor.Text);
			output.Write("struct", BoxedTextColor.Keyword);
			break;
		default:
			output.Write(nativeType.ToString(), BoxedTextColor.Keyword);
			break;
		case NativeType.NotInitialized:
			break;
			IL_0534:
			if (marshalInfo is InterfaceMarshalType { IsIidParamIndexValid: not false } interfaceMarshalType)
			{
				BracePairHelper bracePairHelper2 = BracePairHelper.Create(output, "(", CodeBracesRangeFlags.BraceKind_Parentheses);
				output.Write("iidparam", BoxedTextColor.Keyword);
				output.Write(" ", BoxedTextColor.Text);
				output.Write("=", BoxedTextColor.Operator);
				output.Write(" ", BoxedTextColor.Text);
				output.Write(interfaceMarshalType.IidParamIndex.ToString(), BoxedTextColor.Number);
				bracePairHelper2.Write(")");
			}
			break;
		}
	}

	private void WriteParameters(IList<Parameter> parameters)
	{
		for (int i = 0; i < parameters.Count; i++)
		{
			Parameter parameter = parameters[i];
			if (parameter.IsHiddenThisParameter)
			{
				continue;
			}
			ParamDef paramDef = parameter.ParamDef;
			if (paramDef != null)
			{
				if (paramDef.IsIn)
				{
					BracePairHelper bracePairHelper = BracePairHelper.Create(output, "[", CodeBracesRangeFlags.BraceKind_SquareBrackets);
					output.Write("in", BoxedTextColor.Keyword);
					bracePairHelper.Write("]");
					output.Write(" ", BoxedTextColor.Text);
				}
				if (paramDef.IsOut)
				{
					BracePairHelper bracePairHelper2 = BracePairHelper.Create(output, "[", CodeBracesRangeFlags.BraceKind_SquareBrackets);
					output.Write("out", BoxedTextColor.Keyword);
					bracePairHelper2.Write("]");
					output.Write(" ", BoxedTextColor.Text);
				}
				if (paramDef.IsOptional)
				{
					BracePairHelper bracePairHelper3 = BracePairHelper.Create(output, "[", CodeBracesRangeFlags.BraceKind_SquareBrackets);
					output.Write("opt", BoxedTextColor.Keyword);
					bracePairHelper3.Write("]");
					output.Write(" ", BoxedTextColor.Text);
				}
			}
			parameter.Type.WriteTo(output);
			output.Write(" ", BoxedTextColor.Text);
			if (paramDef != null && paramDef.MarshalType != null)
			{
				WriteMarshalInfo(paramDef.MarshalType);
			}
			output.Write(DisassemblerHelpers.Escape(parameter.Name), parameter, DecompilerReferenceFlags.Definition | DecompilerReferenceFlags.Local, BoxedTextColor.Parameter);
			if (i < parameters.Count - 1)
			{
				output.Write(",", BoxedTextColor.Punctuation);
			}
			output.WriteLine();
		}
	}

	private bool HasParameterAttributes(Parameter p)
	{
		if (p.ParamDef != null)
		{
			if (!p.ParamDef.HasConstant)
			{
				return p.ParamDef.HasCustomAttributes;
			}
			return true;
		}
		return false;
	}

	private void WriteParameterAttributes(int index, Parameter p)
	{
		if (HasParameterAttributes(p))
		{
			output.Write(".param", BoxedTextColor.ILDirective);
			output.Write(" ", BoxedTextColor.Text);
			BracePairHelper bracePairHelper = BracePairHelper.Create(output, "[", CodeBracesRangeFlags.BraceKind_SquareBrackets);
			output.Write($"{index}", BoxedTextColor.Number);
			bracePairHelper.Write("]");
			if (p.HasParamDef && p.ParamDef.HasConstant)
			{
				output.Write(" ", BoxedTextColor.Text);
				output.Write("=", BoxedTextColor.Operator);
				output.Write(" ", BoxedTextColor.Text);
				WriteConstant(p.ParamDef.Constant.Value);
			}
			output.WriteLine();
			if (p.HasParamDef)
			{
				WriteAttributes(p.ParamDef.CustomAttributes);
			}
		}
	}

	private void WriteConstant(object constant)
	{
		if (constant == null)
		{
			output.Write("nullref", BoxedTextColor.Keyword);
			return;
		}
		string text = DisassemblerHelpers.PrimitiveTypeName(constant.GetType().FullName, options.OwnerModule, out var typeSig);
		if (text != null && text != "string")
		{
			DisassemblerHelpers.WriteKeyword(output, text, typeSig.ToTypeDefOrRef());
			BracePairHelper bracePairHelper = BracePairHelper.Create(output, "(", CodeBracesRangeFlags.BraceKind_Parentheses);
			float? num = constant as float?;
			double? num2 = constant as double?;
			if (num.HasValue && (float.IsNaN(num.Value) || float.IsInfinity(num.Value)))
			{
				output.Write($"0x{BitConverter.ToInt32(BitConverter.GetBytes(num.Value), 0):x8}", BoxedTextColor.Number);
			}
			else if (num2.HasValue && (double.IsNaN(num2.Value) || double.IsInfinity(num2.Value)))
			{
				output.Write($"0x{BitConverter.DoubleToInt64Bits(num2.Value):x16}", BoxedTextColor.Number);
			}
			else
			{
				DisassemblerHelpers.WriteOperand(output, constant);
			}
			bracePairHelper.Write(")");
		}
		else
		{
			DisassemblerHelpers.WriteOperand(output, constant);
		}
	}

	public void DisassembleField(FieldDef field, bool addLineSep = false)
	{
		WriteXmlDocComment(field);
		AddComment(field);
		output.Write(".field", BoxedTextColor.ILDirective);
		output.Write(" ", BoxedTextColor.Text);
		if (field.HasLayoutInfo && field.FieldOffset.HasValue)
		{
			BracePairHelper bracePairHelper = BracePairHelper.Create(output, "[", CodeBracesRangeFlags.BraceKind_SquareBrackets);
			output.Write($"{field.FieldOffset}", BoxedTextColor.Number);
			bracePairHelper.Write("]");
			output.Write(" ", BoxedTextColor.Text);
		}
		WriteEnum(field.Attributes & FieldAttributes.FieldAccessMask, fieldVisibility);
		WriteFlags(field.Attributes & ~(FieldAttributes.FieldAccessMask | FieldAttributes.HasFieldMarshal | FieldAttributes.HasDefault | FieldAttributes.HasFieldRVA), fieldAttributes);
		if (field.HasMarshalType)
		{
			WriteMarshalInfo(field.MarshalType);
		}
		field.FieldType.WriteTo(output);
		output.Write(" ", BoxedTextColor.Text);
		output.Write(DisassemblerHelpers.Escape(field.Name), field, DecompilerReferenceFlags.Definition, CSharpMetadataTextColorProvider.Instance.GetColor(field));
		if ((field.Attributes & FieldAttributes.HasFieldRVA) == FieldAttributes.HasFieldRVA)
		{
			output.Write(" ", BoxedTextColor.Text);
			output.Write("at", BoxedTextColor.Keyword);
			output.Write(" ", BoxedTextColor.Text);
			output.Write($"I_{(uint)field.RVA:x8}", BoxedTextColor.Text);
			if (field.GetFieldSize(out var size))
			{
				output.Write(" ", BoxedTextColor.Text);
				output.Write(string.Format("// {0} (0x{0:x4}) bytes", size), BoxedTextColor.Comment);
			}
		}
		if (field.HasConstant)
		{
			output.Write(" ", BoxedTextColor.Text);
			output.Write("=", BoxedTextColor.Operator);
			output.Write(" ", BoxedTextColor.Text);
			WriteConstant(field.Constant.Value);
		}
		if (addLineSep)
		{
			output.AddLineSeparator(output.NextPosition);
		}
		output.WriteLine();
		if (field.HasCustomAttributes)
		{
			WriteAttributes(field.CustomAttributes);
		}
	}

	public void DisassembleProperty(PropertyDef property, bool full = true, bool addLineSep = true)
	{
		currentMember = property;
		WriteXmlDocComment(property);
		AddComment(property);
		output.Write(".property", BoxedTextColor.ILDirective);
		output.Write(" ", BoxedTextColor.Text);
		WriteFlags(property.Attributes, propertyAttributes);
		if (property.PropertySig != null && property.PropertySig.HasThis)
		{
			output.Write("instance", BoxedTextColor.Keyword);
			output.Write(" ", BoxedTextColor.Text);
		}
		property.PropertySig.GetRetType().WriteTo(output);
		output.Write(" ", BoxedTextColor.Text);
		output.Write(DisassemblerHelpers.Escape(property.Name), property, DecompilerReferenceFlags.Definition, CSharpMetadataTextColorProvider.Instance.GetColor(property));
		BracePairHelper bracePairHelper = BracePairHelper.Create(output, "(", CodeBracesRangeFlags.BraceKind_Parentheses);
		List<Parameter> parameters = new List<Parameter>(property.GetParameters());
		if (parameters.GetNumberOfNormalParameters() > 0)
		{
			output.WriteLine();
			output.IncreaseIndent();
			WriteParameters(parameters);
			output.DecreaseIndent();
		}
		bracePairHelper.Write(")");
		if (full)
		{
			BracePairHelper bh = OpenBlock(defaultCollapsed: false, CodeBracesRangeFlags.PropertyBraces);
			WriteAttributes(property.CustomAttributes);
			foreach (MethodDef getMethod in property.GetMethods)
			{
				WriteNestedMethod(".get", getMethod);
			}
			foreach (MethodDef setMethod in property.SetMethods)
			{
				WriteNestedMethod(".set", setMethod);
			}
			foreach (MethodDef otherMethod in property.OtherMethods)
			{
				WriteNestedMethod(".other", otherMethod);
			}
			CloseBlock(bh, addLineSep);
		}
		else
		{
			output.Write(" ", BoxedTextColor.Text);
			BracePairHelper bracePairHelper2 = BracePairHelper.Create(output, "{", CodeBracesRangeFlags.PropertyBraces);
			if (property.GetMethods.Count > 0)
			{
				output.Write(" ", BoxedTextColor.Text);
				output.Write(".get", BoxedTextColor.Keyword);
				output.Write(";", BoxedTextColor.Punctuation);
			}
			if (property.SetMethods.Count > 0)
			{
				output.Write(" ", BoxedTextColor.Text);
				output.Write(".set", BoxedTextColor.Keyword);
				output.Write(";", BoxedTextColor.Punctuation);
			}
			output.Write(" ", BoxedTextColor.Text);
			bracePairHelper2.Write("}");
		}
	}

	private void WriteNestedMethod(string keyword, MethodDef method)
	{
		if (method != null)
		{
			AddComment(method);
			output.Write(keyword, BoxedTextColor.ILDirective);
			output.Write(" ", BoxedTextColor.Text);
			method.WriteMethodTo(output);
			output.WriteLine();
		}
	}

	public void DisassembleEvent(EventDef ev, bool full = true, bool addLineSep = true)
	{
		currentMember = ev;
		WriteXmlDocComment(ev);
		AddComment(ev);
		output.Write(".event", BoxedTextColor.ILDirective);
		output.Write(" ", BoxedTextColor.Text);
		WriteFlags(ev.Attributes, eventAttributes);
		ev.EventType.WriteTo(output, ILNameSyntax.TypeName);
		output.Write(" ", BoxedTextColor.Text);
		output.Write(DisassemblerHelpers.Escape(ev.Name), ev, DecompilerReferenceFlags.Definition, CSharpMetadataTextColorProvider.Instance.GetColor(ev));
		if (full)
		{
			BracePairHelper bh = OpenBlock(defaultCollapsed: false, CodeBracesRangeFlags.EventBraces);
			WriteAttributes(ev.CustomAttributes);
			WriteNestedMethod(".addon", ev.AddMethod);
			WriteNestedMethod(".removeon", ev.RemoveMethod);
			WriteNestedMethod(".fire", ev.InvokeMethod);
			foreach (MethodDef otherMethod in ev.OtherMethods)
			{
				WriteNestedMethod(".other", otherMethod);
			}
			CloseBlock(bh, addLineSep);
			return;
		}
		output.Write(" ", BoxedTextColor.Text);
		BracePairHelper bracePairHelper = BracePairHelper.Create(output, "{", CodeBracesRangeFlags.EventBraces);
		if (ev.AddMethod != null)
		{
			output.Write(" ", BoxedTextColor.Text);
			output.Write(".addon", BoxedTextColor.Keyword);
			output.Write(";", BoxedTextColor.Punctuation);
		}
		if (ev.RemoveMethod != null)
		{
			output.Write(" ", BoxedTextColor.Text);
			output.Write(".removeon", BoxedTextColor.Keyword);
			output.Write(";", BoxedTextColor.Punctuation);
		}
		if (ev.InvokeMethod != null)
		{
			output.Write(" ", BoxedTextColor.Text);
			output.Write(".fire", BoxedTextColor.Keyword);
			output.Write(";", BoxedTextColor.Punctuation);
		}
		output.Write(" ", BoxedTextColor.Text);
		bracePairHelper.Write("}");
	}

	private void AddTokenComment(IMDTokenProvider member, string extra = null)
	{
		if (options.ShowTokenAndRvaComments)
		{
			StartComment();
			WriteToken(member);
			output.WriteLine();
		}
	}

	private void StartComment()
	{
		output.Write("//", BoxedTextColor.Comment);
	}

	private void WriteToken(IMDTokenProvider member)
	{
		output.Write(" Token: ", BoxedTextColor.Comment);
		output.Write($"0x{member.MDToken.Raw:X8}", (options.OwnerModule == null) ? null : new TokenReference(options.OwnerModule, member.MDToken.Raw), DecompilerReferenceFlags.None, BoxedTextColor.Comment);
		output.Write(" RID: ", BoxedTextColor.Comment);
		output.Write($"{member.MDToken.Rid}", BoxedTextColor.Comment);
	}

	private void WriteRVA(IMemberDef member)
	{
		member.GetRVA(out var rva, out var fileOffset);
		string empty = string.Empty;
		if (rva != 0)
		{
			string filename = member.Module?.Location;
			output.Write(" RVA: ", BoxedTextColor.Comment);
			output.Write($"0x{rva:X8}", new AddressReference(filename, isRva: true, rva, 0uL), DecompilerReferenceFlags.None, BoxedTextColor.Comment);
			output.Write(" File Offset: ", BoxedTextColor.Comment);
			output.Write($"0x{fileOffset:X8}", new AddressReference(filename, isRva: false, (ulong)fileOffset, 0uL), DecompilerReferenceFlags.None, BoxedTextColor.Comment);
		}
	}

	private void AddComment(IMemberDef member)
	{
		if (options.ShowTokenAndRvaComments)
		{
			StartComment();
			WriteToken(member);
			WriteRVA(member);
			output.WriteLine();
		}
	}

	private void WriteTypeName(TypeDef type)
	{
		UTF8String uTF8String = type.Namespace ?? ((UTF8String)string.Empty);
		if (uTF8String != string.Empty)
		{
			DisassemblerHelpers.WriteNamespace(output, uTF8String, type.DefinitionAssembly);
			output.Write(".", BoxedTextColor.Operator);
		}
		output.Write(DisassemblerHelpers.Escape(type.Name.String), type, DecompilerReferenceFlags.Definition, CSharpMetadataTextColorProvider.Instance.GetColor(type));
	}

	public void DisassembleType(TypeDef type, bool addLineSep = true)
	{
		WriteXmlDocComment(type);
		AddComment(type);
		output.Write(".class", BoxedTextColor.ILDirective);
		output.Write(" ", BoxedTextColor.Text);
		if ((type.Attributes & TypeAttributes.ClassSemanticsMask) == TypeAttributes.ClassSemanticsMask)
		{
			output.Write("interface", BoxedTextColor.Keyword);
			output.Write(" ", BoxedTextColor.Text);
		}
		WriteEnum(type.Attributes & TypeAttributes.VisibilityMask, typeVisibility);
		WriteEnum(type.Attributes & TypeAttributes.LayoutMask, typeLayout);
		WriteEnum(type.Attributes & TypeAttributes.StringFormatMask, typeStringFormat);
		WriteFlags((TypeAttributes)((uint)type.Attributes & 0xFFFCFFC0u), typeAttributes);
		WriteTypeName(type);
		WriteTypeParameters(output, type);
		output.WriteLine();
		if (type.BaseType != null)
		{
			output.IncreaseIndent();
			output.Write("extends", BoxedTextColor.Keyword);
			output.Write(" ", BoxedTextColor.Text);
			type.BaseType.WriteTo(output, ILNameSyntax.TypeName);
			output.WriteLine();
			output.DecreaseIndent();
		}
		if (type.HasInterfaces)
		{
			output.IncreaseIndent();
			for (int i = 0; i < type.Interfaces.Count; i++)
			{
				if (i > 0)
				{
					output.WriteLine(",", BoxedTextColor.Punctuation);
				}
				if (i == 0)
				{
					output.Write("implements", BoxedTextColor.Keyword);
					output.Write(" ", BoxedTextColor.Text);
				}
				else
				{
					output.Write("           ", BoxedTextColor.Text);
				}
				type.Interfaces[i].Interface.WriteTo(output, ILNameSyntax.TypeName);
			}
			output.WriteLine();
			output.DecreaseIndent();
		}
		BracePairHelper bh = BracePairHelper.Create(output, "{", CodeBracesRangeFlags.TypeBraces);
		output.WriteLine();
		output.IncreaseIndent();
		bool flag = isInType;
		isInType = true;
		WriteAttributes(type.CustomAttributes);
		WriteSecurityDeclarations(type);
		if (type.HasClassLayout)
		{
			output.Write(".pack", BoxedTextColor.ILDirective);
			output.Write(" ", BoxedTextColor.Text);
			output.WriteLine($"{type.PackingSize}", BoxedTextColor.Number);
			output.Write(".size", BoxedTextColor.ILDirective);
			output.Write(" ", BoxedTextColor.Text);
			output.WriteLine($"{type.ClassSize}", BoxedTextColor.Number);
			output.WriteLine();
		}
		int num = type.NestedTypes.Count + type.Fields.Count + type.Methods.Count + type.Events.Count + type.Properties.Count;
		if (type.HasNestedTypes)
		{
			output.WriteLine("// Nested Types", BoxedTextColor.Comment);
			foreach (TypeDef nestedType in type.GetNestedTypes(options.SortMembers))
			{
				options.CancellationToken.ThrowIfCancellationRequested();
				DisassembleType(nestedType, addLineSep && --num > 0);
				output.WriteLine();
			}
			output.WriteLine();
		}
		if (type.HasFields)
		{
			output.WriteLine("// Fields", BoxedTextColor.Comment);
			foreach (FieldDef field in type.GetFields(options.SortMembers))
			{
				options.CancellationToken.ThrowIfCancellationRequested();
				num--;
				DisassembleField(field);
			}
			if (addLineSep && num > 0)
			{
				output.AddLineSeparator(output.Length - 2);
			}
			output.WriteLine();
		}
		if (type.HasMethods)
		{
			output.WriteLine("// Methods", BoxedTextColor.Comment);
			foreach (MethodDef method in type.GetMethods(options.SortMembers))
			{
				options.CancellationToken.ThrowIfCancellationRequested();
				DisassembleMethod(method, addLineSep && --num > 0);
				output.WriteLine();
			}
		}
		if (type.HasEvents)
		{
			output.WriteLine("// Events", BoxedTextColor.Comment);
			foreach (EventDef @event in type.GetEvents(options.SortMembers))
			{
				options.CancellationToken.ThrowIfCancellationRequested();
				DisassembleEvent(@event, full: true, addLineSep && --num > 0);
				output.WriteLine();
			}
		}
		if (type.HasProperties)
		{
			output.WriteLine("// Properties", BoxedTextColor.Comment);
			foreach (PropertyDef property in type.GetProperties(options.SortMembers))
			{
				options.CancellationToken.ThrowIfCancellationRequested();
				DisassembleProperty(property, full: true, addLineSep && --num > 0);
			}
			output.WriteLine();
		}
		CloseBlock(bh, addLineSep, "end of class " + ((type.DeclaringType != null) ? type.Name.String : type.FullName));
		isInType = flag;
	}

	private void WriteTypeParameters(IDecompilerOutput output, ITypeOrMethodDef p)
	{
		if (!p.HasGenericParameters)
		{
			return;
		}
		BracePairHelper bracePairHelper = BracePairHelper.Create(output, "<", CodeBracesRangeFlags.BraceKind_AngleBrackets);
		for (int i = 0; i < p.GenericParameters.Count; i++)
		{
			if (i > 0)
			{
				output.Write(",", BoxedTextColor.Punctuation);
				output.Write(" ", BoxedTextColor.Text);
			}
			GenericParam genericParam = p.GenericParameters[i];
			if (genericParam.HasReferenceTypeConstraint)
			{
				output.Write("class", BoxedTextColor.Keyword);
				output.Write(" ", BoxedTextColor.Text);
			}
			else if (genericParam.HasNotNullableValueTypeConstraint)
			{
				output.Write("valuetype", BoxedTextColor.Keyword);
				output.Write(" ", BoxedTextColor.Text);
			}
			if (genericParam.HasDefaultConstructorConstraint)
			{
				output.Write(".ctor", BoxedTextColor.Keyword);
				output.Write(" ", BoxedTextColor.Text);
			}
			if (genericParam.HasGenericParamConstraints)
			{
				BracePairHelper bracePairHelper2 = BracePairHelper.Create(output, "(", CodeBracesRangeFlags.BraceKind_Parentheses);
				for (int j = 0; j < genericParam.GenericParamConstraints.Count; j++)
				{
					if (j > 0)
					{
						output.Write(",", BoxedTextColor.Punctuation);
						output.Write(" ", BoxedTextColor.Text);
					}
					genericParam.GenericParamConstraints[j].Constraint.WriteTo(output, ILNameSyntax.TypeName);
				}
				bracePairHelper2.Write(")");
				output.Write(" ", BoxedTextColor.Text);
			}
			if (genericParam.IsContravariant)
			{
				output.Write("-", BoxedTextColor.Operator);
			}
			else if (genericParam.IsCovariant)
			{
				output.Write("+", BoxedTextColor.Operator);
			}
			output.Write(DisassemblerHelpers.Escape(genericParam.Name), CSharpMetadataTextColorProvider.Instance.GetColor(genericParam));
		}
		bracePairHelper.Write(">");
	}

	private void WriteAttributes(CustomAttributeCollection attributes)
	{
		foreach (CustomAttribute attribute in attributes)
		{
			output.Write(".custom", BoxedTextColor.ILDirective);
			output.Write(" ", BoxedTextColor.Text);
			attribute.Constructor.WriteMethodTo(output);
			uint blobOffset = attribute.BlobOffset;
			if (blobOffset != 0 && options.OwnerModule is ModuleDefMD moduleDefMD && moduleDefMD.Metadata.BlobStream.TryCreateReader(blobOffset, out var reader))
			{
				output.Write(" ", BoxedTextColor.Text);
				output.Write("=", BoxedTextColor.Operator);
				output.Write(" ", BoxedTextColor.Text);
				WriteBlob(reader.ToArray());
			}
			output.WriteLine();
		}
	}

	private void WriteBlob(byte[] blob)
	{
		BracePairHelper bracePairHelper = BracePairHelper.Create(output, "(", CodeBracesRangeFlags.BraceKind_Parentheses);
		output.IncreaseIndent();
		for (int i = 0; i < blob.Length; i++)
		{
			if (i % 16 == 0 && i < blob.Length - 1)
			{
				output.WriteLine();
			}
			else
			{
				output.Write(" ", BoxedTextColor.Text);
			}
			output.Write(blob[i].ToString("x2"), BoxedTextColor.Number);
		}
		output.WriteLine();
		output.DecreaseIndent();
		bracePairHelper.Write(")");
	}

	private BracePairHelper OpenBlock(bool defaultCollapsed, CodeBracesRangeFlags flags)
	{
		output.WriteLine();
		BracePairHelper result = BracePairHelper.Create(output, "{", flags);
		output.WriteLine();
		output.IncreaseIndent();
		return result;
	}

	private int CloseBlock(BracePairHelper bh1, bool addLineSep = false, string comment = null)
	{
		output.DecreaseIndent();
		bh1.Write("}");
		int nextPosition = output.NextPosition;
		if (comment != null)
		{
			output.Write(" ", BoxedTextColor.Text);
			output.Write("// " + comment, BoxedTextColor.Comment);
		}
		if (addLineSep)
		{
			output.AddLineSeparator(output.NextPosition);
		}
		output.WriteLine();
		return nextPosition;
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
				string[] array = flagName.Value.Split(' ');
				foreach (string text in array)
				{
					output.Write(text, BoxedTextColor.Keyword);
					output.Write(" ", BoxedTextColor.Text);
				}
			}
		}
		if ((num & ~num2) != 0L)
		{
			output.Write($"flag({num & ~num2:x4})", BoxedTextColor.Keyword);
			output.Write(" ", BoxedTextColor.Text);
		}
	}

	private void WriteEnum<T>(T enumValue, EnumNameCollection<T> enumNames) where T : struct
	{
		long num = Convert.ToInt64(enumValue);
		foreach (KeyValuePair<long, string> enumName in enumNames)
		{
			if (enumName.Key != num)
			{
				continue;
			}
			if (enumName.Value != null)
			{
				string[] array = enumName.Value.Split(' ');
				foreach (string text in array)
				{
					output.Write(text, BoxedTextColor.Keyword);
					output.Write(" ", BoxedTextColor.Text);
				}
			}
			return;
		}
		if (num != 0L)
		{
			output.Write($"flag({num:x4})", BoxedTextColor.Keyword);
			output.Write(" ", BoxedTextColor.Text);
		}
	}

	public void WriteAssemblyHeader(AssemblyDef asm)
	{
		output.Write(".assembly", BoxedTextColor.ILDirective);
		output.Write(" ", BoxedTextColor.Text);
		if (asm.IsContentTypeWindowsRuntime)
		{
			output.Write("windowsruntime", BoxedTextColor.Keyword);
			output.Write(" ", BoxedTextColor.Text);
		}
		output.Write(DisassemblerHelpers.Escape(asm.Name), BoxedTextColor.Text);
		BracePairHelper bh = OpenBlock(defaultCollapsed: false, CodeBracesRangeFlags.OtherBlockBraces);
		WriteAttributes(asm.CustomAttributes);
		WriteSecurityDeclarations(asm);
		if (asm.PublicKey != null && !asm.PublicKey.IsNullOrEmpty)
		{
			output.Write(".publickey", BoxedTextColor.ILDirective);
			output.Write(" ", BoxedTextColor.Text);
			output.Write("=", BoxedTextColor.Operator);
			output.Write(" ", BoxedTextColor.Text);
			WriteBlob(asm.PublicKey.Data);
			output.WriteLine();
		}
		if (asm.HashAlgorithm != AssemblyHashAlgorithm.None)
		{
			output.Write(".hash", BoxedTextColor.ILDirective);
			output.Write(" ", BoxedTextColor.Text);
			output.Write("algorithm", BoxedTextColor.Keyword);
			output.Write(" ", BoxedTextColor.Text);
			output.Write($"0x{(uint)asm.HashAlgorithm:x8}", BoxedTextColor.Number);
			if (asm.HashAlgorithm == AssemblyHashAlgorithm.SHA1)
			{
				output.Write(" ", BoxedTextColor.Text);
				output.Write("// SHA1", BoxedTextColor.Comment);
			}
			output.WriteLine();
		}
		Version version = asm.Version;
		if (version != null)
		{
			output.Write(".ver", BoxedTextColor.ILDirective);
			output.Write(" ", BoxedTextColor.Text);
			output.Write($"{version.Major}", BoxedTextColor.Number);
			output.Write(":", BoxedTextColor.Operator);
			output.Write($"{version.Minor}", BoxedTextColor.Number);
			output.Write(":", BoxedTextColor.Operator);
			output.Write($"{version.Build}", BoxedTextColor.Number);
			output.Write(":", BoxedTextColor.Operator);
			output.WriteLine($"{version.Revision}", BoxedTextColor.Number);
		}
		CloseBlock(bh);
	}

	public void WriteAssemblyReferences(ModuleDef module)
	{
		if (module == null)
		{
			return;
		}
		foreach (ModuleRef moduleRef in module.GetModuleRefs())
		{
			output.Write(".module", BoxedTextColor.ILDirective);
			output.Write(" ", BoxedTextColor.Text);
			output.Write("extern", BoxedTextColor.Keyword);
			output.Write(" ", BoxedTextColor.Text);
			output.WriteLine(DisassemblerHelpers.Escape(moduleRef.Name), BoxedTextColor.Text);
		}
		foreach (AssemblyRef assemblyRef in module.GetAssemblyRefs())
		{
			AddTokenComment(assemblyRef);
			output.Write(".assembly", BoxedTextColor.ILDirective);
			output.Write(" ", BoxedTextColor.Text);
			output.Write("extern", BoxedTextColor.Keyword);
			output.Write(" ", BoxedTextColor.Text);
			if (assemblyRef.IsContentTypeWindowsRuntime)
			{
				output.Write("windowsruntime", BoxedTextColor.Keyword);
				output.Write(" ", BoxedTextColor.Text);
			}
			output.Write(DisassemblerHelpers.Escape(assemblyRef.Name), BoxedTextColor.Text);
			BracePairHelper bh = OpenBlock(defaultCollapsed: false, CodeBracesRangeFlags.OtherBlockBraces);
			if (!PublicKeyBase.IsNullOrEmpty2(assemblyRef.PublicKeyOrToken))
			{
				output.Write(".publickeytoken", BoxedTextColor.ILDirective);
				output.Write(" ", BoxedTextColor.Text);
				output.Write("=", BoxedTextColor.Operator);
				output.Write(" ", BoxedTextColor.Text);
				WriteBlob(assemblyRef.PublicKeyOrToken.Token.Data);
				output.WriteLine();
			}
			if (assemblyRef.Version != null)
			{
				output.Write(".ver", BoxedTextColor.ILDirective);
				output.Write(" ", BoxedTextColor.Text);
				output.Write($"{assemblyRef.Version.Major}", BoxedTextColor.Number);
				output.Write(":", BoxedTextColor.Operator);
				output.Write($"{assemblyRef.Version.Minor}", BoxedTextColor.Number);
				output.Write(":", BoxedTextColor.Operator);
				output.Write($"{assemblyRef.Version.Build}", BoxedTextColor.Number);
				output.Write(":", BoxedTextColor.Operator);
				output.WriteLine($"{assemblyRef.Version.Revision}", BoxedTextColor.Number);
			}
			CloseBlock(bh);
		}
	}

	public void WriteModuleHeader(ModuleDef module)
	{
		if (module.HasExportedTypes)
		{
			foreach (ExportedType exportedType in module.ExportedTypes)
			{
				AddTokenComment(exportedType);
				output.Write(".class", BoxedTextColor.ILDirective);
				output.Write(" ", BoxedTextColor.Text);
				output.Write("extern", BoxedTextColor.Keyword);
				output.Write(" ", BoxedTextColor.Text);
				if (exportedType.IsForwarder)
				{
					output.Write("forwarder", BoxedTextColor.Keyword);
					output.Write(" ", BoxedTextColor.Text);
				}
				output.Write((exportedType.DeclaringType != null) ? exportedType.TypeName.String : exportedType.FullName, CSharpMetadataTextColorProvider.Instance.GetColor(exportedType));
				BracePairHelper bh = OpenBlock(defaultCollapsed: false, CodeBracesRangeFlags.OtherBlockBraces);
				if (exportedType.DeclaringType != null)
				{
					output.Write(".class", BoxedTextColor.ILDirective);
					output.Write(" ", BoxedTextColor.Text);
					output.Write("extern", BoxedTextColor.Keyword);
					output.Write(" ", BoxedTextColor.Text);
					output.WriteLine(DisassemblerHelpers.Escape(exportedType.DeclaringType.FullName), CSharpMetadataTextColorProvider.Instance.GetColor(exportedType.DeclaringType));
				}
				else
				{
					output.Write(".assembly", BoxedTextColor.ILDirective);
					output.Write(" ", BoxedTextColor.Text);
					output.Write("extern", BoxedTextColor.Keyword);
					output.Write(" ", BoxedTextColor.Text);
					output.WriteLine(DisassemblerHelpers.Escape(exportedType.Scope.GetScopeName()), BoxedTextColor.Text);
				}
				CloseBlock(bh);
			}
		}
		output.Write(".module", BoxedTextColor.ILDirective);
		output.Write(" ", BoxedTextColor.Text);
		output.WriteLine(module.Name, BoxedTextColor.Text);
		if (module.Mvid.HasValue)
		{
			output.WriteLine(string.Format("// MVID: {0}", module.Mvid.Value.ToString("B").ToUpperInvariant()), BoxedTextColor.Comment);
		}
		output.Write(".corflags", BoxedTextColor.ILDirective);
		output.Write(" ", BoxedTextColor.Text);
		output.Write($"0x{module.Cor20HeaderFlags:x}", BoxedTextColor.Number);
		output.Write(" ", BoxedTextColor.Text);
		output.WriteLine($"// {module.Cor20HeaderFlags.ToString()}", BoxedTextColor.Comment);
		WriteAttributes(module.CustomAttributes);
	}

	public void WriteModuleContents(ModuleDef module)
	{
		foreach (TypeDef type in module.Types)
		{
			DisassembleType(type);
			output.WriteLine();
		}
	}
}
