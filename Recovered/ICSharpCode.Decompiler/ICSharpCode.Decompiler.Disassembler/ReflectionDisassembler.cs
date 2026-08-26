using ICSharpCode.NRefactory;
using ICSharpCode.NRefactory.CSharp;
using Mono.Cecil;
using Mono.Collections.Generic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace ICSharpCode.Decompiler.Disassembler
{
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

		private readonly ITextOutput output;

		private CancellationToken cancellationToken;

		private bool isInType;

		private MethodBodyDisassembler methodBodyDisassembler;

		private MemberReference currentMember;

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
				MethodAttributes.PInvokeImpl,
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

		private EnumNameCollection<MethodCallingConvention> callingConvention = new EnumNameCollection<MethodCallingConvention>
		{
			{
				MethodCallingConvention.C,
				"unmanaged cdecl"
			},
			{
				MethodCallingConvention.StdCall,
				"unmanaged stdcall"
			},
			{
				MethodCallingConvention.ThisCall,
				"unmanaged thiscall"
			},
			{
				MethodCallingConvention.FastCall,
				"unmanaged fastcall"
			},
			{
				MethodCallingConvention.VarArg,
				"vararg"
			},
			{
				MethodCallingConvention.Generic,
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

		public ReflectionDisassembler(ITextOutput output, bool detectControlStructure, CancellationToken cancellationToken)
		{
			if (output == null)
			{
				throw new ArgumentNullException("output");
			}
			this.output = output;
			this.cancellationToken = cancellationToken;
			methodBodyDisassembler = new MethodBodyDisassembler(output, detectControlStructure, cancellationToken);
		}

		public void DisassembleMethod(MethodDefinition method)
		{
			currentMember = method;
			output.WriteDefinition(".method ", method);
			DisassembleMethodInternal(method);
		}

		private void DisassembleMethodInternal(MethodDefinition method)
		{
			TextLocation location = output.Location;
			WriteEnum(method.Attributes & MethodAttributes.MemberAccessMask, methodVisibility);
			WriteFlags(method.Attributes & ~MethodAttributes.MemberAccessMask, methodAttributeFlags);
			if (method.IsCompilerControlled)
			{
				output.Write("privatescope ");
			}
			if ((method.Attributes & MethodAttributes.PInvokeImpl) == MethodAttributes.PInvokeImpl)
			{
				output.Write("pinvokeimpl");
				if (method.HasPInvokeInfo && method.PInvokeInfo != null)
				{
					PInvokeInfo pInvokeInfo = method.PInvokeInfo;
					output.Write("(\"" + TextWriterTokenWriter.ConvertString(pInvokeInfo.Module.Name) + "\"");
					if (!string.IsNullOrEmpty(pInvokeInfo.EntryPoint) && pInvokeInfo.EntryPoint != method.Name)
					{
						output.Write(" as \"" + TextWriterTokenWriter.ConvertString(pInvokeInfo.EntryPoint) + "\"");
					}
					if (pInvokeInfo.IsNoMangle)
					{
						output.Write(" nomangle");
					}
					if (pInvokeInfo.IsCharSetAnsi)
					{
						output.Write(" ansi");
					}
					else if (pInvokeInfo.IsCharSetAuto)
					{
						output.Write(" autochar");
					}
					else if (pInvokeInfo.IsCharSetUnicode)
					{
						output.Write(" unicode");
					}
					if (pInvokeInfo.SupportsLastError)
					{
						output.Write(" lasterr");
					}
					if (pInvokeInfo.IsCallConvCdecl)
					{
						output.Write(" cdecl");
					}
					else if (pInvokeInfo.IsCallConvFastcall)
					{
						output.Write(" fastcall");
					}
					else if (pInvokeInfo.IsCallConvStdCall)
					{
						output.Write(" stdcall");
					}
					else if (pInvokeInfo.IsCallConvThiscall)
					{
						output.Write(" thiscall");
					}
					else if (pInvokeInfo.IsCallConvWinapi)
					{
						output.Write(" winapi");
					}
					output.Write(')');
				}
				output.Write(' ');
			}
			output.WriteLine();
			output.Indent();
			if (method.ExplicitThis)
			{
				output.Write("instance explicit ");
			}
			else if (method.HasThis)
			{
				output.Write("instance ");
			}
			WriteEnum(method.CallingConvention & (MethodCallingConvention)31, callingConvention);
			method.ReturnType.WriteTo(output);
			output.Write(' ');
			if (method.MethodReturnType.HasMarshalInfo)
			{
				WriteMarshalInfo(method.MethodReturnType.MarshalInfo);
			}
			if (method.IsCompilerControlled)
			{
				output.Write(DisassemblerHelpers.Escape(method.Name + "$PST" + method.MetadataToken.ToInt32().ToString("X8")));
			}
			else
			{
				output.Write(DisassemblerHelpers.Escape(method.Name));
			}
			WriteTypeParameters(output, method);
			output.Write(" (");
			if (method.HasParameters)
			{
				output.WriteLine();
				output.Indent();
				WriteParameters(method.Parameters);
				output.Unindent();
			}
			output.Write(") ");
			WriteEnum(method.ImplAttributes & MethodImplAttributes.CodeTypeMask, methodCodeType);
			if ((method.ImplAttributes & MethodImplAttributes.ManagedMask) == MethodImplAttributes.IL)
			{
				output.Write("managed ");
			}
			else
			{
				output.Write("unmanaged ");
			}
			WriteFlags(method.ImplAttributes & ~(MethodImplAttributes.CodeTypeMask | MethodImplAttributes.ManagedMask), methodImpl);
			output.Unindent();
			OpenBlock(isInType);
			WriteAttributes(method.CustomAttributes);
			if (method.HasOverrides)
			{
				foreach (MethodReference @override in method.Overrides)
				{
					output.Write(".override method ");
					@override.WriteTo(output);
					output.WriteLine();
				}
			}
			WriteParameterAttributes(0, method.MethodReturnType, method.MethodReturnType);
			foreach (ParameterDefinition parameter in method.Parameters)
			{
				WriteParameterAttributes(parameter.Index + 1, parameter, parameter);
			}
			WriteSecurityDeclarations(method);
			if (method.HasBody)
			{
				MethodDebugSymbols methodDebugSymbols = new MethodDebugSymbols(method);
				methodDebugSymbols.StartLocation = location;
				methodBodyDisassembler.Disassemble(method.Body, methodDebugSymbols);
				methodDebugSymbols.EndLocation = output.Location;
				output.AddDebugSymbols(methodDebugSymbols);
			}
			CloseBlock("end of method " + DisassemblerHelpers.Escape(method.DeclaringType.Name) + "::" + DisassemblerHelpers.Escape(method.Name));
		}

		private void WriteSecurityDeclarations(ISecurityDeclarationProvider secDeclProvider)
		{
			if (secDeclProvider.HasSecurityDeclarations)
			{
				foreach (SecurityDeclaration securityDeclaration in secDeclProvider.SecurityDeclarations)
				{
					output.Write(".permissionset ");
					switch (securityDeclaration.Action)
					{
					case SecurityAction.Request:
						output.Write("request");
						break;
					case SecurityAction.Demand:
						output.Write("demand");
						break;
					case SecurityAction.Assert:
						output.Write("assert");
						break;
					case SecurityAction.Deny:
						output.Write("deny");
						break;
					case SecurityAction.PermitOnly:
						output.Write("permitonly");
						break;
					case SecurityAction.LinkDemand:
						output.Write("linkcheck");
						break;
					case SecurityAction.InheritDemand:
						output.Write("inheritcheck");
						break;
					case SecurityAction.RequestMinimum:
						output.Write("reqmin");
						break;
					case SecurityAction.RequestOptional:
						output.Write("reqopt");
						break;
					case SecurityAction.RequestRefuse:
						output.Write("reqrefuse");
						break;
					case SecurityAction.PreJitGrant:
						output.Write("prejitgrant");
						break;
					case SecurityAction.PreJitDeny:
						output.Write("prejitdeny");
						break;
					case SecurityAction.NonCasDemand:
						output.Write("noncasdemand");
						break;
					case SecurityAction.NonCasLinkDemand:
						output.Write("noncaslinkdemand");
						break;
					case SecurityAction.NonCasInheritance:
						output.Write("noncasinheritance");
						break;
					default:
						output.Write(securityDeclaration.Action.ToString());
						break;
					}
					output.WriteLine(" = {");
					output.Indent();
					for (int i = 0; i < securityDeclaration.SecurityAttributes.Count; i++)
					{
						SecurityAttribute securityAttribute = securityDeclaration.SecurityAttributes[i];
						if (securityAttribute.AttributeType.Scope == securityAttribute.AttributeType.Module)
						{
							output.Write("class ");
							output.Write(DisassemblerHelpers.Escape(GetAssemblyQualifiedName(securityAttribute.AttributeType)));
						}
						else
						{
							securityAttribute.AttributeType.WriteTo(output, ILNameSyntax.TypeName);
						}
						output.Write(" = {");
						if (securityAttribute.HasFields || securityAttribute.HasProperties)
						{
							output.WriteLine();
							output.Indent();
							foreach (CustomAttributeNamedArgument field in securityAttribute.Fields)
							{
								output.Write("field ");
								WriteSecurityDeclarationArgument(field);
								output.WriteLine();
							}
							foreach (CustomAttributeNamedArgument property in securityAttribute.Properties)
							{
								output.Write("property ");
								WriteSecurityDeclarationArgument(property);
								output.WriteLine();
							}
							output.Unindent();
						}
						output.Write('}');
						if (i + 1 < securityDeclaration.SecurityAttributes.Count)
						{
							output.Write(',');
						}
						output.WriteLine();
					}
					output.Unindent();
					output.WriteLine("}");
				}
			}
		}

		private void WriteSecurityDeclarationArgument(CustomAttributeNamedArgument na)
		{
			TypeReference type = na.Argument.Type;
			if (type.MetadataType == MetadataType.Class || type.MetadataType == MetadataType.ValueType)
			{
				output.Write("enum ");
				if (type.Scope != type.Module)
				{
					output.Write("class ");
					output.Write(DisassemblerHelpers.Escape(GetAssemblyQualifiedName(type)));
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
			output.Write(' ');
			output.Write(DisassemblerHelpers.Escape(na.Name));
			output.Write(" = ");
			if (na.Argument.Value is string)
			{
				output.Write("string('{0}')", TextWriterTokenWriter.ConvertString((string)na.Argument.Value).Replace("'", "'"));
			}
			else
			{
				WriteConstant(na.Argument.Value);
			}
		}

		private string GetAssemblyQualifiedName(TypeReference type)
		{
			AssemblyNameReference assemblyNameReference = type.Scope as AssemblyNameReference;
			if (assemblyNameReference == null)
			{
				ModuleDefinition moduleDefinition = type.Scope as ModuleDefinition;
				if (moduleDefinition != null)
				{
					assemblyNameReference = moduleDefinition.Assembly.Name;
				}
			}
			if (assemblyNameReference != null)
			{
				return type.FullName + ", " + assemblyNameReference.FullName;
			}
			return type.FullName;
		}

		private void WriteMarshalInfo(MarshalInfo marshalInfo)
		{
			output.Write("marshal(");
			WriteNativeType(marshalInfo.NativeType, marshalInfo);
			output.Write(") ");
		}

		private void WriteNativeType(NativeType nativeType, MarshalInfo marshalInfo = null)
		{
			switch (nativeType)
			{
			case NativeType.None:
				return;
			case NativeType.Boolean:
				output.Write("bool");
				return;
			case NativeType.I1:
				output.Write("int8");
				return;
			case NativeType.U1:
				output.Write("unsigned int8");
				return;
			case NativeType.I2:
				output.Write("int16");
				return;
			case NativeType.U2:
				output.Write("unsigned int16");
				return;
			case NativeType.I4:
				output.Write("int32");
				return;
			case NativeType.U4:
				output.Write("unsigned int32");
				return;
			case NativeType.I8:
				output.Write("int64");
				return;
			case NativeType.U8:
				output.Write("unsigned int64");
				return;
			case NativeType.R4:
				output.Write("float32");
				return;
			case NativeType.R8:
				output.Write("float64");
				return;
			case NativeType.LPStr:
				output.Write("lpstr");
				return;
			case NativeType.Int:
				output.Write("int");
				return;
			case NativeType.UInt:
				output.Write("unsigned int");
				return;
			case NativeType.Array:
			{
				ArrayMarshalInfo arrayMarshalInfo = (ArrayMarshalInfo)marshalInfo;
				if (arrayMarshalInfo == null)
				{
					break;
				}
				if (arrayMarshalInfo.ElementType != NativeType.Max)
				{
					WriteNativeType(arrayMarshalInfo.ElementType);
				}
				output.Write('[');
				if (arrayMarshalInfo.SizeParameterMultiplier == 0)
				{
					output.Write(arrayMarshalInfo.Size.ToString());
				}
				else
				{
					if (arrayMarshalInfo.Size >= 0)
					{
						output.Write(arrayMarshalInfo.Size.ToString());
					}
					output.Write(" + ");
					output.Write(arrayMarshalInfo.SizeParameterIndex.ToString());
				}
				output.Write(']');
				return;
			}
			case NativeType.Currency:
				output.Write("currency");
				return;
			case NativeType.BStr:
				output.Write("bstr");
				return;
			case NativeType.LPWStr:
				output.Write("lpwstr");
				return;
			case NativeType.LPTStr:
				output.Write("lptstr");
				return;
			case NativeType.FixedSysString:
				output.Write("fixed sysstring[{0}]", ((FixedSysStringMarshalInfo)marshalInfo).Size);
				return;
			case NativeType.IUnknown:
				output.Write("iunknown");
				return;
			case NativeType.IDispatch:
				output.Write("idispatch");
				return;
			case NativeType.Struct:
				output.Write("struct");
				return;
			case NativeType.IntF:
				output.Write("interface");
				return;
			case NativeType.SafeArray:
			{
				output.Write("safearray ");
				SafeArrayMarshalInfo safeArrayMarshalInfo = marshalInfo as SafeArrayMarshalInfo;
				if (safeArrayMarshalInfo != null)
				{
					switch (safeArrayMarshalInfo.ElementType)
					{
					case VariantType.None:
						break;
					case VariantType.I2:
						output.Write("int16");
						break;
					case VariantType.I4:
						output.Write("int32");
						break;
					case VariantType.R4:
						output.Write("float32");
						break;
					case VariantType.R8:
						output.Write("float64");
						break;
					case VariantType.CY:
						output.Write("currency");
						break;
					case VariantType.Date:
						output.Write("date");
						break;
					case VariantType.BStr:
						output.Write("bstr");
						break;
					case VariantType.Dispatch:
						output.Write("idispatch");
						break;
					case VariantType.Error:
						output.Write("error");
						break;
					case VariantType.Bool:
						output.Write("bool");
						break;
					case VariantType.Variant:
						output.Write("variant");
						break;
					case VariantType.Unknown:
						output.Write("iunknown");
						break;
					case VariantType.Decimal:
						output.Write("decimal");
						break;
					case VariantType.I1:
						output.Write("int8");
						break;
					case VariantType.UI1:
						output.Write("unsigned int8");
						break;
					case VariantType.UI2:
						output.Write("unsigned int16");
						break;
					case VariantType.UI4:
						output.Write("unsigned int32");
						break;
					case VariantType.Int:
						output.Write("int");
						break;
					case VariantType.UInt:
						output.Write("unsigned int");
						break;
					default:
						output.Write(safeArrayMarshalInfo.ElementType.ToString());
						break;
					}
				}
				return;
			}
			case NativeType.FixedArray:
			{
				output.Write("fixed array");
				FixedArrayMarshalInfo fixedArrayMarshalInfo = marshalInfo as FixedArrayMarshalInfo;
				if (fixedArrayMarshalInfo != null)
				{
					output.Write("[{0}]", fixedArrayMarshalInfo.Size);
					if (fixedArrayMarshalInfo.ElementType != NativeType.None)
					{
						output.Write(' ');
						WriteNativeType(fixedArrayMarshalInfo.ElementType);
					}
				}
				return;
			}
			case NativeType.ByValStr:
				output.Write("byvalstr");
				return;
			case NativeType.ANSIBStr:
				output.Write("ansi bstr");
				return;
			case NativeType.TBStr:
				output.Write("tbstr");
				return;
			case NativeType.VariantBool:
				output.Write("variant bool");
				return;
			case NativeType.ASAny:
				output.Write("as any");
				return;
			case NativeType.LPStruct:
				output.Write("lpstruct");
				return;
			case NativeType.CustomMarshaler:
			{
				CustomMarshalInfo customMarshalInfo = marshalInfo as CustomMarshalInfo;
				if (customMarshalInfo != null)
				{
					output.Write("custom(\"{0}\", \"{1}\"", TextWriterTokenWriter.ConvertString(customMarshalInfo.ManagedType.FullName), TextWriterTokenWriter.ConvertString(customMarshalInfo.Cookie));
					if (customMarshalInfo.Guid != Guid.Empty || !string.IsNullOrEmpty(customMarshalInfo.UnmanagedType))
					{
						output.Write(", \"{0}\", \"{1}\"", customMarshalInfo.Guid.ToString(), TextWriterTokenWriter.ConvertString(customMarshalInfo.UnmanagedType));
					}
					output.Write(')');
					return;
				}
				break;
			}
			case NativeType.Error:
				output.Write("error");
				return;
			}
			output.Write(nativeType.ToString());
		}

		private void WriteParameters(Collection<ParameterDefinition> parameters)
		{
			for (int i = 0; i < parameters.Count; i++)
			{
				ParameterDefinition parameterDefinition = parameters[i];
				if (parameterDefinition.IsIn)
				{
					output.Write("[in] ");
				}
				if (parameterDefinition.IsOut)
				{
					output.Write("[out] ");
				}
				if (parameterDefinition.IsOptional)
				{
					output.Write("[opt] ");
				}
				parameterDefinition.ParameterType.WriteTo(output);
				output.Write(' ');
				if (parameterDefinition.HasMarshalInfo)
				{
					WriteMarshalInfo(parameterDefinition.MarshalInfo);
				}
				output.WriteDefinition(DisassemblerHelpers.Escape(parameterDefinition.Name), parameterDefinition);
				if (i < parameters.Count - 1)
				{
					output.Write(',');
				}
				output.WriteLine();
			}
		}

		private void WriteParameterAttributes(int index, IConstantProvider cp, ICustomAttributeProvider cap)
		{
			if (cp.HasConstant || cap.HasCustomAttributes)
			{
				output.Write(".param [{0}]", index);
				if (cp.HasConstant)
				{
					output.Write(" = ");
					WriteConstant(cp.Constant);
				}
				output.WriteLine();
				WriteAttributes(cap.CustomAttributes);
			}
		}

		private void WriteConstant(object constant)
		{
			if (constant == null)
			{
				output.Write("nullref");
				return;
			}
			string text = DisassemblerHelpers.PrimitiveTypeName(constant.GetType().FullName);
			if (text != null && text != "string")
			{
				output.Write(text);
				output.Write('(');
				float? num = constant as float?;
				double? num2 = constant as double?;
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
					DisassemblerHelpers.WriteOperand(output, constant);
				}
				output.Write(')');
			}
			else
			{
				DisassemblerHelpers.WriteOperand(output, constant);
			}
		}

		public void DisassembleField(FieldDefinition field)
		{
			output.WriteDefinition(".field ", field);
			if (field.HasLayoutInfo)
			{
				output.Write("[" + field.Offset + "] ");
			}
			WriteEnum(field.Attributes & FieldAttributes.FieldAccessMask, fieldVisibility);
			WriteFlags(field.Attributes & ~(FieldAttributes.FieldAccessMask | FieldAttributes.HasFieldMarshal | FieldAttributes.HasDefault | FieldAttributes.HasFieldRVA), fieldAttributes);
			if (field.HasMarshalInfo)
			{
				WriteMarshalInfo(field.MarshalInfo);
			}
			field.FieldType.WriteTo(output);
			output.Write(' ');
			output.Write(DisassemblerHelpers.Escape(field.Name));
			if ((field.Attributes & FieldAttributes.HasFieldRVA) == FieldAttributes.HasFieldRVA)
			{
				output.Write(" at I_{0:x8}", field.RVA);
			}
			if (field.HasConstant)
			{
				output.Write(" = ");
				WriteConstant(field.Constant);
			}
			output.WriteLine();
			if (field.HasCustomAttributes)
			{
				output.MarkFoldStart();
				WriteAttributes(field.CustomAttributes);
				output.MarkFoldEnd();
			}
		}

		public void DisassembleProperty(PropertyDefinition property)
		{
			currentMember = property;
			output.WriteDefinition(".property ", property);
			WriteFlags(property.Attributes, propertyAttributes);
			if (property.HasThis)
			{
				output.Write("instance ");
			}
			property.PropertyType.WriteTo(output);
			output.Write(' ');
			output.Write(DisassemblerHelpers.Escape(property.Name));
			output.Write("(");
			if (property.HasParameters)
			{
				output.WriteLine();
				output.Indent();
				WriteParameters(property.Parameters);
				output.Unindent();
			}
			output.Write(")");
			OpenBlock(defaultCollapsed: false);
			WriteAttributes(property.CustomAttributes);
			WriteNestedMethod(".get", property.GetMethod);
			WriteNestedMethod(".set", property.SetMethod);
			foreach (MethodDefinition otherMethod in property.OtherMethods)
			{
				WriteNestedMethod(".other", otherMethod);
			}
			CloseBlock();
		}

		private void WriteNestedMethod(string keyword, MethodDefinition method)
		{
			if (method != null)
			{
				output.Write(keyword);
				output.Write(' ');
				method.WriteTo(output);
				output.WriteLine();
			}
		}

		public void DisassembleEvent(EventDefinition ev)
		{
			currentMember = ev;
			output.WriteDefinition(".event ", ev);
			WriteFlags(ev.Attributes, eventAttributes);
			ev.EventType.WriteTo(output, ILNameSyntax.TypeName);
			output.Write(' ');
			output.Write(DisassemblerHelpers.Escape(ev.Name));
			OpenBlock(defaultCollapsed: false);
			WriteAttributes(ev.CustomAttributes);
			WriteNestedMethod(".addon", ev.AddMethod);
			WriteNestedMethod(".removeon", ev.RemoveMethod);
			WriteNestedMethod(".fire", ev.InvokeMethod);
			foreach (MethodDefinition otherMethod in ev.OtherMethods)
			{
				WriteNestedMethod(".other", otherMethod);
			}
			CloseBlock();
		}

		public void DisassembleType(TypeDefinition type)
		{
			output.WriteDefinition(".class ", type);
			if ((type.Attributes & TypeAttributes.ClassSemanticMask) == TypeAttributes.ClassSemanticMask)
			{
				output.Write("interface ");
			}
			WriteEnum(type.Attributes & TypeAttributes.VisibilityMask, typeVisibility);
			WriteEnum(type.Attributes & TypeAttributes.LayoutMask, typeLayout);
			WriteEnum(type.Attributes & TypeAttributes.StringFormatMask, typeStringFormat);
			WriteFlags((TypeAttributes)((int)type.Attributes & -196672), typeAttributes);
			output.Write(DisassemblerHelpers.Escape((type.DeclaringType != null) ? type.Name : type.FullName));
			WriteTypeParameters(output, type);
			output.MarkFoldStart("...", isInType);
			output.WriteLine();
			if (type.BaseType != null)
			{
				output.Indent();
				output.Write("extends ");
				type.BaseType.WriteTo(output, ILNameSyntax.TypeName);
				output.WriteLine();
				output.Unindent();
			}
			if (type.HasInterfaces)
			{
				output.Indent();
				for (int i = 0; i < type.Interfaces.Count; i++)
				{
					if (i > 0)
					{
						output.WriteLine(",");
					}
					if (i == 0)
					{
						output.Write("implements ");
					}
					else
					{
						output.Write("           ");
					}
					type.Interfaces[i].WriteTo(output, ILNameSyntax.TypeName);
				}
				output.WriteLine();
				output.Unindent();
			}
			output.WriteLine("{");
			output.Indent();
			bool flag = isInType;
			isInType = true;
			WriteAttributes(type.CustomAttributes);
			WriteSecurityDeclarations(type);
			if (type.HasLayoutInfo)
			{
				output.WriteLine(".pack {0}", type.PackingSize);
				output.WriteLine(".size {0}", type.ClassSize);
				output.WriteLine();
			}
			if (type.HasNestedTypes)
			{
				output.WriteLine("// Nested Types");
				foreach (TypeDefinition nestedType in type.NestedTypes)
				{
					cancellationToken.ThrowIfCancellationRequested();
					DisassembleType(nestedType);
					output.WriteLine();
				}
				output.WriteLine();
			}
			if (type.HasFields)
			{
				output.WriteLine("// Fields");
				foreach (FieldDefinition field in type.Fields)
				{
					cancellationToken.ThrowIfCancellationRequested();
					DisassembleField(field);
				}
				output.WriteLine();
			}
			if (type.HasMethods)
			{
				output.WriteLine("// Methods");
				foreach (MethodDefinition method in type.Methods)
				{
					cancellationToken.ThrowIfCancellationRequested();
					DisassembleMethod(method);
					output.WriteLine();
				}
			}
			if (type.HasEvents)
			{
				output.WriteLine("// Events");
				foreach (EventDefinition @event in type.Events)
				{
					cancellationToken.ThrowIfCancellationRequested();
					DisassembleEvent(@event);
					output.WriteLine();
				}
				output.WriteLine();
			}
			if (type.HasProperties)
			{
				output.WriteLine("// Properties");
				foreach (PropertyDefinition property in type.Properties)
				{
					cancellationToken.ThrowIfCancellationRequested();
					DisassembleProperty(property);
				}
				output.WriteLine();
			}
			CloseBlock("end of class " + ((type.DeclaringType != null) ? type.Name : type.FullName));
			isInType = flag;
		}

		private void WriteTypeParameters(ITextOutput output, IGenericParameterProvider p)
		{
			if (!p.HasGenericParameters)
			{
				return;
			}
			output.Write('<');
			for (int i = 0; i < p.GenericParameters.Count; i++)
			{
				if (i > 0)
				{
					output.Write(", ");
				}
				GenericParameter genericParameter = p.GenericParameters[i];
				if (genericParameter.HasReferenceTypeConstraint)
				{
					output.Write("class ");
				}
				else if (genericParameter.HasNotNullableValueTypeConstraint)
				{
					output.Write("valuetype ");
				}
				if (genericParameter.HasDefaultConstructorConstraint)
				{
					output.Write(".ctor ");
				}
				if (genericParameter.HasConstraints)
				{
					output.Write('(');
					for (int j = 0; j < genericParameter.Constraints.Count; j++)
					{
						if (j > 0)
						{
							output.Write(", ");
						}
						genericParameter.Constraints[j].WriteTo(output, ILNameSyntax.TypeName);
					}
					output.Write(") ");
				}
				if (genericParameter.IsContravariant)
				{
					output.Write('-');
				}
				else if (genericParameter.IsCovariant)
				{
					output.Write('+');
				}
				output.Write(DisassemblerHelpers.Escape(genericParameter.Name));
			}
			output.Write('>');
		}

		private void WriteAttributes(Collection<CustomAttribute> attributes)
		{
			foreach (CustomAttribute attribute in attributes)
			{
				output.Write(".custom ");
				attribute.Constructor.WriteTo(output);
				byte[] blob = attribute.GetBlob();
				if (blob != null)
				{
					output.Write(" = ");
					WriteBlob(blob);
				}
				output.WriteLine();
			}
		}

		private void WriteBlob(byte[] blob)
		{
			output.Write("(");
			output.Indent();
			for (int i = 0; i < blob.Length; i++)
			{
				if (i % 16 == 0 && i < blob.Length - 1)
				{
					output.WriteLine();
				}
				else
				{
					output.Write(' ');
				}
				output.Write(blob[i].ToString("x2"));
			}
			output.WriteLine();
			output.Unindent();
			output.Write(")");
		}

		private void OpenBlock(bool defaultCollapsed)
		{
			output.MarkFoldStart("...", defaultCollapsed);
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
			if ((num & ~num2) != 0L)
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
			if (num != 0L)
			{
				output.Write("flag({0:x4})", num);
				output.Write(' ');
			}
		}

		public void DisassembleNamespace(string nameSpace, IEnumerable<TypeDefinition> types)
		{
			if (!string.IsNullOrEmpty(nameSpace))
			{
				output.Write(".namespace " + DisassemblerHelpers.Escape(nameSpace));
				OpenBlock(defaultCollapsed: false);
			}
			bool flag = isInType;
			isInType = true;
			foreach (TypeDefinition type in types)
			{
				cancellationToken.ThrowIfCancellationRequested();
				DisassembleType(type);
				output.WriteLine();
			}
			if (!string.IsNullOrEmpty(nameSpace))
			{
				CloseBlock();
				isInType = flag;
			}
		}

		public void WriteAssemblyHeader(AssemblyDefinition asm)
		{
			output.Write(".assembly ");
			if (asm.Name.IsWindowsRuntime)
			{
				output.Write("windowsruntime ");
			}
			output.Write(DisassemblerHelpers.Escape(asm.Name.Name));
			OpenBlock(defaultCollapsed: false);
			WriteAttributes(asm.CustomAttributes);
			WriteSecurityDeclarations(asm);
			if (asm.Name.PublicKey != null && asm.Name.PublicKey.Length != 0)
			{
				output.Write(".publickey = ");
				WriteBlob(asm.Name.PublicKey);
				output.WriteLine();
			}
			if (asm.Name.HashAlgorithm != 0)
			{
				output.Write(".hash algorithm 0x{0:x8}", (int)asm.Name.HashAlgorithm);
				if (asm.Name.HashAlgorithm == AssemblyHashAlgorithm.SHA1)
				{
					output.Write(" // SHA1");
				}
				output.WriteLine();
			}
			Version version = asm.Name.Version;
			if (version != null)
			{
				output.WriteLine(".ver {0}:{1}:{2}:{3}", version.Major, version.Minor, version.Build, version.Revision);
			}
			CloseBlock();
		}

		public void WriteAssemblyReferences(ModuleDefinition module)
		{
			foreach (ModuleReference moduleReference in module.ModuleReferences)
			{
				output.WriteLine(".module extern {0}", DisassemblerHelpers.Escape(moduleReference.Name));
			}
			foreach (AssemblyNameReference assemblyReference in module.AssemblyReferences)
			{
				output.Write(".assembly extern ");
				if (assemblyReference.IsWindowsRuntime)
				{
					output.Write("windowsruntime ");
				}
				output.Write(DisassemblerHelpers.Escape(assemblyReference.Name));
				OpenBlock(defaultCollapsed: false);
				if (assemblyReference.PublicKeyToken != null)
				{
					output.Write(".publickeytoken = ");
					WriteBlob(assemblyReference.PublicKeyToken);
					output.WriteLine();
				}
				if (assemblyReference.Version != null)
				{
					output.WriteLine(".ver {0}:{1}:{2}:{3}", assemblyReference.Version.Major, assemblyReference.Version.Minor, assemblyReference.Version.Build, assemblyReference.Version.Revision);
				}
				CloseBlock();
			}
		}

		public void WriteModuleHeader(ModuleDefinition module)
		{
			if (module.HasExportedTypes)
			{
				foreach (ExportedType exportedType in module.ExportedTypes)
				{
					output.Write(".class extern ");
					if (exportedType.IsForwarder)
					{
						output.Write("forwarder ");
					}
					output.Write((exportedType.DeclaringType != null) ? exportedType.Name : exportedType.FullName);
					OpenBlock(defaultCollapsed: false);
					if (exportedType.DeclaringType != null)
					{
						output.WriteLine(".class extern {0}", DisassemblerHelpers.Escape(exportedType.DeclaringType.FullName));
					}
					else
					{
						output.WriteLine(".assembly extern {0}", DisassemblerHelpers.Escape(exportedType.Scope.Name));
					}
					CloseBlock();
				}
			}
			output.WriteLine(".module {0}", module.Name);
			output.WriteLine("// MVID: {0}", module.Mvid.ToString("B").ToUpperInvariant());
			output.WriteLine(".corflags 0x{0:x} // {1}", module.Attributes, module.Attributes.ToString());
			WriteAttributes(module.CustomAttributes);
		}

		public void WriteModuleContents(ModuleDefinition module)
		{
			foreach (TypeDefinition type in module.Types)
			{
				DisassembleType(type);
				output.WriteLine();
			}
		}
	}
}
