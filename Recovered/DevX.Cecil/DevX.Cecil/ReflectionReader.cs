using DevX.Cecil.Binary;
using DevX.Cecil.Cil;
using DevX.Cecil.Metadata;
using DevX.Cecil.Signatures;
using System;
using System.IO;
using System.Text;

namespace DevX.Cecil
{
	internal abstract class ReflectionReader : BaseReflectionReader
	{
		private ModuleDefinition m_module;

		private ImageReader m_reader;

		private SecurityDeclarationReader m_secReader;

		protected MetadataTableReader m_tableReader;

		protected MetadataRoot m_root;

		protected TablesHeap m_tHeap;

		protected bool m_checkDeleted;

		protected TypeDefinition[] m_typeDefs;

		protected TypeReference[] m_typeRefs;

		protected TypeReference[] m_typeSpecs;

		protected MethodDefinition[] m_meths;

		protected FieldDefinition[] m_fields;

		protected EventDefinition[] m_events;

		protected PropertyDefinition[] m_properties;

		protected MemberReference[] m_memberRefs;

		protected ParameterDefinition[] m_parameters;

		protected GenericParameter[] m_genericParameters;

		protected GenericInstanceMethod[] m_methodSpecs;

		private bool m_isCorlib;

		private AssemblyNameReference m_corlib;

		protected SignatureReader m_sigReader;

		protected CodeReader m_codeReader;

		protected ISymbolReader m_symbolReader;

		internal AssemblyNameReference Corlib
		{
			get
			{
				if (m_corlib != null)
				{
					return m_corlib;
				}
				foreach (AssemblyNameReference assemblyReference in m_module.AssemblyReferences)
				{
					if (assemblyReference.Name == "mscorlib")
					{
						m_corlib = assemblyReference;
						return m_corlib;
					}
				}
				return null;
			}
		}

		public ModuleDefinition Module => m_module;

		public SignatureReader SigReader => m_sigReader;

		public MetadataTableReader TableReader => m_tableReader;

		public CodeReader Code => m_codeReader;

		public ISymbolReader SymbolReader
		{
			get
			{
				return m_symbolReader;
			}
			set
			{
				m_symbolReader = value;
			}
		}

		public MetadataRoot MetadataRoot => m_root;

		public ReflectionReader(ModuleDefinition module)
		{
			m_module = module;
			m_reader = m_module.ImageReader;
			m_root = m_module.Image.MetadataRoot;
			m_tHeap = m_root.Streams.TablesHeap;
			m_checkDeleted = ((m_tHeap.HeapSizes & 0x80) != 0);
			if (m_reader != null)
			{
				m_tableReader = m_reader.MetadataReader.TableReader;
			}
			m_codeReader = new CodeReader(this);
			m_sigReader = new SignatureReader(m_root, this);
			m_isCorlib = (module.Assembly.Name.Name == "mscorlib");
		}

		public TypeDefinition GetTypeDefAt(uint rid)
		{
			if (rid > m_typeDefs.Length)
			{
				return null;
			}
			return m_typeDefs[rid - 1];
		}

		public TypeReference GetTypeRefAt(uint rid)
		{
			if (rid > m_typeRefs.Length)
			{
				return null;
			}
			return m_typeRefs[rid - 1];
		}

		public TypeReference GetTypeSpecAt(uint rid, GenericContext context)
		{
			if (rid > m_typeSpecs.Length)
			{
				return null;
			}
			int num = (int)(rid - 1);
			TypeSpecTable typeSpecTable = m_tableReader.GetTypeSpecTable();
			TypeSpecRow typeSpecRow = typeSpecTable[num];
			TypeSpec typeSpec = m_sigReader.GetTypeSpec(typeSpecRow.Signature);
			if (typeSpec.Type.ElementType == ElementType.GenericInst)
			{
				return CreateTypeSpecFromSig(typeSpec, num, context);
			}
			TypeReference typeReference = m_typeSpecs[num];
			if (typeReference != null)
			{
				return typeReference;
			}
			typeReference = CreateTypeSpecFromSig(typeSpec, num, context);
			m_typeSpecs[num] = typeReference;
			return typeReference;
		}

		private TypeReference CreateTypeSpecFromSig(TypeSpec ts, int index, GenericContext context)
		{
			TypeReference typeRefFromSig = GetTypeRefFromSig(ts.Type, context);
			typeRefFromSig = GetModifierType(ts.CustomMods, typeRefFromSig);
			typeRefFromSig.MetadataToken = MetadataToken.FromMetadataRow(TokenType.TypeSpec, index);
			return typeRefFromSig;
		}

		public FieldDefinition GetFieldDefAt(uint rid)
		{
			if (rid > m_fields.Length)
			{
				return null;
			}
			return m_fields[rid - 1];
		}

		public MethodDefinition GetMethodDefAt(uint rid)
		{
			if (rid > m_meths.Length)
			{
				return null;
			}
			return m_meths[rid - 1];
		}

		protected bool IsDeleted(IMemberDefinition member)
		{
			if (!m_checkDeleted)
			{
				return false;
			}
			if (!member.IsSpecialName || !member.IsRuntimeSpecialName)
			{
				return false;
			}
			return member.Name.StartsWith("_Deleted");
		}

		public MemberReference GetMemberRefAt(uint rid, GenericContext context)
		{
			if (rid > m_memberRefs.Length)
			{
				return null;
			}
			int num = (int)(rid - 1);
			MemberReference memberReference = m_memberRefs[num];
			if (memberReference != null)
			{
				return memberReference;
			}
			MemberRefTable memberRefTable = m_tableReader.GetMemberRefTable();
			MemberRefRow memberRefRow = memberRefTable[num];
			Signature memberRefSig = m_sigReader.GetMemberRefSig(memberRefRow.Class.TokenType, memberRefRow.Signature);
			switch (memberRefRow.Class.TokenType)
			{
			case TokenType.TypeRef:
			case TokenType.TypeDef:
			case TokenType.TypeSpec:
			{
				TypeReference typeDefOrRef = GetTypeDefOrRef(memberRefRow.Class, context);
				GenericContext genericContext = context.Clone();
				if (typeDefOrRef is GenericInstanceType)
				{
					TypeReference typeReference = typeDefOrRef;
					while (typeReference is GenericInstanceType)
					{
						typeReference = (typeReference as GenericInstanceType).ElementType;
					}
					genericContext.Type = typeReference;
				}
				if (memberRefSig is FieldSig)
				{
					FieldSig fieldSig = memberRefSig as FieldSig;
					TypeReference typeRefFromSig = GetTypeRefFromSig(fieldSig.Type, genericContext);
					typeRefFromSig = GetModifierType(fieldSig.CustomMods, typeRefFromSig);
					memberReference = new FieldReference(m_root.Streams.StringsHeap[memberRefRow.Name], typeDefOrRef, typeRefFromSig);
				}
				else
				{
					string name = m_root.Streams.StringsHeap[memberRefRow.Name];
					MethodSig ms = (MethodSig)memberRefSig;
					memberReference = CreateMethodReferenceFromSig(ms, name, typeDefOrRef, genericContext);
				}
				break;
			}
			case TokenType.Method:
			{
				MethodDefinition methodDefAt = GetMethodDefAt(memberRefRow.Class.RID);
				memberReference = CreateMethodReferenceFromSig((MethodSig)memberRefSig, methodDefAt.Name, methodDefAt.DeclaringType, new GenericContext());
				break;
			}
			}
			memberReference.MetadataToken = MetadataToken.FromMetadataRow(TokenType.MemberRef, num);
			m_module.MemberReferences.Add(memberReference);
			m_memberRefs[num] = memberReference;
			return memberReference;
		}

		private MethodReference CreateMethodReferenceFromSig(MethodSig ms, string name, TypeReference declaringType, GenericContext context)
		{
			MethodReference methodReference = new MethodReference(name, ms.HasThis, ms.ExplicitThis, ms.MethCallConv);
			methodReference.DeclaringType = declaringType;
			if (ms is MethodDefSig)
			{
				int genericParameterCount = (ms as MethodDefSig).GenericParameterCount;
				for (int i = 0; i < genericParameterCount; i++)
				{
					methodReference.GenericParameters.Add(new GenericParameter(i, methodReference));
				}
			}
			if (methodReference.GenericParameters.Count > 0)
			{
				context.Method = methodReference;
			}
			methodReference.ReturnType = GetMethodReturnType(ms, context);
			methodReference.ReturnType.Method = methodReference;
			for (int j = 0; j < ms.ParamCount; j++)
			{
				Param psig = ms.Parameters[j];
				ParameterDefinition parameterDefinition = BuildParameterDefinition(j, psig, context);
				parameterDefinition.Method = methodReference;
				methodReference.Parameters.Add(parameterDefinition);
			}
			CreateSentinelIfNeeded(methodReference, ms);
			return methodReference;
		}

		public static void CreateSentinelIfNeeded(IMethodSignature meth, MethodSig signature)
		{
			MethodDefSig methodDefSig = signature as MethodDefSig;
			if (methodDefSig != null)
			{
				int sentinel = methodDefSig.Sentinel;
				if (methodDefSig.Sentinel >= 0 && methodDefSig.Sentinel < meth.Parameters.Count)
				{
					ParameterDefinition parameterDefinition = meth.Parameters[sentinel];
					parameterDefinition.ParameterType = new SentinelType(parameterDefinition.ParameterType);
				}
			}
		}

		public PropertyDefinition GetPropertyDefAt(uint rid)
		{
			if (rid > m_properties.Length)
			{
				return null;
			}
			return m_properties[rid - 1];
		}

		public EventDefinition GetEventDefAt(uint rid)
		{
			if (rid > m_events.Length)
			{
				return null;
			}
			return m_events[rid - 1];
		}

		public ParameterDefinition GetParamDefAt(uint rid)
		{
			if (rid > m_parameters.Length)
			{
				return null;
			}
			return m_parameters[rid - 1];
		}

		public GenericParameter GetGenericParameterAt(uint rid)
		{
			if (rid > m_genericParameters.Length)
			{
				return null;
			}
			return m_genericParameters[rid - 1];
		}

		public GenericInstanceMethod GetMethodSpecAt(uint rid, GenericContext context)
		{
			if (rid > m_methodSpecs.Length)
			{
				return null;
			}
			int num = (int)(rid - 1);
			GenericInstanceMethod genericInstanceMethod = m_methodSpecs[num];
			if (genericInstanceMethod != null)
			{
				return genericInstanceMethod;
			}
			MethodSpecTable methodSpecTable = m_tableReader.GetMethodSpecTable();
			MethodSpecRow methodSpecRow = methodSpecTable[num];
			MethodSpec methodSpec = m_sigReader.GetMethodSpec(methodSpecRow.Instantiation);
			MethodReference methodReference;
			if (methodSpecRow.Method.TokenType == TokenType.Method)
			{
				methodReference = GetMethodDefAt(methodSpecRow.Method.RID);
			}
			else
			{
				if (methodSpecRow.Method.TokenType != TokenType.MemberRef)
				{
					throw new ReflectionException("Unknown method type for method spec");
				}
				methodReference = (MethodReference)GetMemberRefAt(methodSpecRow.Method.RID, context);
			}
			genericInstanceMethod = new GenericInstanceMethod(methodReference);
			context.CheckProvider(methodReference, methodSpec.Signature.Arity);
			GenericArg[] types = methodSpec.Signature.Types;
			foreach (GenericArg arg in types)
			{
				genericInstanceMethod.GenericArguments.Add(GetGenericArg(arg, context));
			}
			m_methodSpecs[num] = genericInstanceMethod;
			return genericInstanceMethod;
		}

		public TypeReference GetTypeDefOrRef(MetadataToken token, GenericContext context)
		{
			if (token.RID == 0)
			{
				return null;
			}
			switch (token.TokenType)
			{
			case TokenType.TypeDef:
				return GetTypeDefAt(token.RID);
			case TokenType.TypeRef:
				return GetTypeRefAt(token.RID);
			case TokenType.TypeSpec:
				return GetTypeSpecAt(token.RID, context);
			default:
				return null;
			}
		}

		public TypeReference SearchCoreType(string fullName)
		{
			if (m_isCorlib)
			{
				return m_module.Types[fullName];
			}
			TypeReference typeReference = m_module.TypeReferences[fullName];
			if (typeReference == null)
			{
				string[] array = fullName.Split('.');
				if (array.Length != 2)
				{
					throw new ReflectionException("Unvalid core type name");
				}
				typeReference = new TypeReference(array[1], array[0], Corlib);
				m_module.TypeReferences.Add(typeReference);
			}
			if (!typeReference.IsValueType)
			{
				switch (typeReference.FullName)
				{
				case "System.Boolean":
				case "System.Char":
				case "System.Single":
				case "System.Double":
				case "System.SByte":
				case "System.Byte":
				case "System.Int16":
				case "System.UInt16":
				case "System.Int32":
				case "System.UInt32":
				case "System.Int64":
				case "System.UInt64":
				case "System.IntPtr":
				case "System.UIntPtr":
					typeReference.IsValueType = true;
					break;
				}
			}
			return typeReference;
		}

		public IMetadataTokenProvider LookupByToken(MetadataToken token)
		{
			switch (token.TokenType)
			{
			case TokenType.TypeDef:
				return GetTypeDefAt(token.RID);
			case TokenType.TypeRef:
				return GetTypeRefAt(token.RID);
			case TokenType.Method:
				return GetMethodDefAt(token.RID);
			case TokenType.Field:
				return GetFieldDefAt(token.RID);
			case TokenType.Event:
				return GetEventDefAt(token.RID);
			case TokenType.Property:
				return GetPropertyDefAt(token.RID);
			case TokenType.Param:
				return GetParamDefAt(token.RID);
			default:
				throw new NotSupportedException("Lookup is not allowed on this kind of token");
			}
		}

		public CustomAttribute GetCustomAttribute(MethodReference ctor, byte[] data, bool resolve)
		{
			CustomAttrib customAttrib = m_sigReader.GetCustomAttrib(data, ctor, resolve);
			return BuildCustomAttribute(ctor, data, customAttrib);
		}

		public CustomAttribute GetCustomAttribute(MethodReference ctor, byte[] data)
		{
			return GetCustomAttribute(ctor, data, resolve: false);
		}

		public override void VisitModuleDefinition(ModuleDefinition mod)
		{
			VisitTypeDefinitionCollection(mod.Types);
		}

		public override void VisitTypeDefinitionCollection(TypeDefinitionCollection types)
		{
			TypeDefTable typeDefTable = m_tableReader.GetTypeDefTable();
			m_typeDefs = new TypeDefinition[typeDefTable.Rows.Count];
			for (int i = 0; i < typeDefTable.Rows.Count; i++)
			{
				TypeDefRow typeDefRow = typeDefTable[i];
				TypeDefinition typeDefinition = new TypeDefinition(m_root.Streams.StringsHeap[typeDefRow.Name], m_root.Streams.StringsHeap[typeDefRow.Namespace], typeDefRow.Flags);
				typeDefinition.MetadataToken = MetadataToken.FromMetadataRow(TokenType.TypeDef, i);
				m_typeDefs[i] = typeDefinition;
			}
			if (m_tHeap.HasTable(41))
			{
				NestedClassTable nestedClassTable = m_tableReader.GetNestedClassTable();
				for (int j = 0; j < nestedClassTable.Rows.Count; j++)
				{
					NestedClassRow nestedClassRow = nestedClassTable[j];
					TypeDefinition typeDefAt = GetTypeDefAt(nestedClassRow.EnclosingClass);
					TypeDefinition typeDefAt2 = GetTypeDefAt(nestedClassRow.NestedClass);
					if (!IsDeleted(typeDefAt2))
					{
						typeDefAt.NestedTypes.Add(typeDefAt2);
					}
				}
			}
			TypeDefinition[] typeDefs = m_typeDefs;
			foreach (TypeDefinition typeDefinition2 in typeDefs)
			{
				if (!IsDeleted(typeDefinition2))
				{
					types.Add(typeDefinition2);
				}
			}
			if (m_tHeap.HasTable(1))
			{
				TypeRefTable typeRefTable = m_tableReader.GetTypeRefTable();
				m_typeRefs = new TypeReference[typeRefTable.Rows.Count];
				for (int l = 0; l < typeRefTable.Rows.Count; l++)
				{
					AddTypeRef(typeRefTable, l);
				}
			}
			else
			{
				m_typeRefs = new TypeReference[0];
			}
			ReadTypeSpecs();
			ReadMethodSpecs();
			ReadMethods();
			ReadGenericParameters();
			for (int m = 0; m < typeDefTable.Rows.Count; m++)
			{
				TypeDefRow typeDefRow2 = typeDefTable[m];
				TypeDefinition typeDefinition3 = m_typeDefs[m];
				typeDefinition3.BaseType = GetTypeDefOrRef(typeDefRow2.Extends, new GenericContext(typeDefinition3));
			}
			CompleteMethods();
			ReadAllFields();
			ReadMemberReferences();
		}

		private void AddTypeRef(TypeRefTable typesRef, int i)
		{
			if (i >= typesRef.Rows.Count || m_typeRefs[i] != null)
			{
				return;
			}
			TypeRefRow typeRefRow = typesRef[i];
			IMetadataScope scope = null;
			TypeReference typeReference = null;
			if (typeRefRow.ResolutionScope.RID != 0)
			{
				int num = (int)(typeRefRow.ResolutionScope.RID - 1);
				switch (typeRefRow.ResolutionScope.TokenType)
				{
				case TokenType.AssemblyRef:
					scope = m_module.AssemblyReferences[num];
					break;
				case TokenType.ModuleRef:
					scope = m_module.ModuleReferences[num];
					break;
				case TokenType.Module:
					scope = m_module.Assembly.Modules[num];
					break;
				case TokenType.TypeRef:
					AddTypeRef(typesRef, num);
					typeReference = GetTypeRefAt(typeRefRow.ResolutionScope.RID);
					if (typeReference != null)
					{
						scope = typeReference.Scope;
					}
					break;
				}
			}
			TypeReference typeReference2 = new TypeReference(m_root.Streams.StringsHeap[typeRefRow.Name], m_root.Streams.StringsHeap[typeRefRow.Namespace], scope);
			typeReference2.MetadataToken = MetadataToken.FromMetadataRow(TokenType.TypeRef, i);
			if (typeReference != null)
			{
				typeReference2.DeclaringType = typeReference;
			}
			m_typeRefs[i] = typeReference2;
			m_module.TypeReferences.Add(typeReference2);
		}

		private void ReadTypeSpecs()
		{
			if (m_tHeap.HasTable(27))
			{
				TypeSpecTable typeSpecTable = m_tableReader.GetTypeSpecTable();
				m_typeSpecs = new TypeReference[typeSpecTable.Rows.Count];
			}
		}

		private void ReadMethodSpecs()
		{
			if (m_tHeap.HasTable(43))
			{
				MethodSpecTable methodSpecTable = m_tableReader.GetMethodSpecTable();
				m_methodSpecs = new GenericInstanceMethod[methodSpecTable.Rows.Count];
			}
		}

		private void ReadGenericParameters()
		{
			if (!m_tHeap.HasTable(42))
			{
				return;
			}
			GenericParamTable genericParamTable = m_tableReader.GetGenericParamTable();
			m_genericParameters = new GenericParameter[genericParamTable.Rows.Count];
			int num = 0;
			while (true)
			{
				if (num >= genericParamTable.Rows.Count)
				{
					return;
				}
				GenericParamRow genericParamRow = genericParamTable[num];
				IGenericParameterProvider genericParameterProvider;
				if (genericParamRow.Owner.TokenType == TokenType.Method)
				{
					genericParameterProvider = GetMethodDefAt(genericParamRow.Owner.RID);
				}
				else
				{
					if (genericParamRow.Owner.TokenType != TokenType.TypeDef)
					{
						break;
					}
					genericParameterProvider = GetTypeDefAt(genericParamRow.Owner.RID);
				}
				GenericParameter genericParameter = new GenericParameter(genericParamRow.Number, genericParameterProvider);
				genericParameter.Attributes = genericParamRow.Flags;
				genericParameter.Name = MetadataRoot.Streams.StringsHeap[genericParamRow.Name];
				genericParameter.MetadataToken = MetadataToken.FromMetadataRow(TokenType.GenericParam, num);
				genericParameterProvider.GenericParameters.Add(genericParameter);
				m_genericParameters[num] = genericParameter;
				num++;
			}
			throw new ReflectionException("Unknown owner type for generic parameter");
		}

		private void ReadAllFields()
		{
			TypeDefTable typeDefTable = m_tableReader.GetTypeDefTable();
			if (!m_tHeap.HasTable(4))
			{
				m_fields = new FieldDefinition[0];
				return;
			}
			FieldTable fieldTable = m_tableReader.GetFieldTable();
			m_fields = new FieldDefinition[fieldTable.Rows.Count];
			for (int i = 0; i < m_typeDefs.Length; i++)
			{
				TypeDefinition typeDefinition = m_typeDefs[i];
				GenericContext context = new GenericContext(typeDefinition);
				int num = i;
				int num2 = (num != typeDefTable.Rows.Count - 1) ? ((int)typeDefTable[num + 1].FieldList) : (fieldTable.Rows.Count + 1);
				for (int j = (int)typeDefTable[num].FieldList; j < num2; j++)
				{
					FieldRow fieldRow = fieldTable[j - 1];
					FieldSig fieldSig = m_sigReader.GetFieldSig(fieldRow.Signature);
					FieldDefinition fieldDefinition = new FieldDefinition(m_root.Streams.StringsHeap[fieldRow.Name], GetTypeRefFromSig(fieldSig.Type, context), fieldRow.Flags);
					fieldDefinition.MetadataToken = MetadataToken.FromMetadataRow(TokenType.Field, j - 1);
					if (fieldSig.CustomMods.Length > 0)
					{
						fieldDefinition.FieldType = GetModifierType(fieldSig.CustomMods, fieldDefinition.FieldType);
					}
					if (!IsDeleted(fieldDefinition))
					{
						typeDefinition.Fields.Add(fieldDefinition);
					}
					m_fields[j - 1] = fieldDefinition;
				}
			}
		}

		private void ReadMethods()
		{
			if (!m_tHeap.HasTable(6))
			{
				m_meths = new MethodDefinition[0];
				return;
			}
			MethodTable methodTable = m_tableReader.GetMethodTable();
			m_meths = new MethodDefinition[methodTable.Rows.Count];
			for (int i = 0; i < methodTable.Rows.Count; i++)
			{
				MethodRow methodRow = methodTable[i];
				MethodDefinition methodDefinition = new MethodDefinition(m_root.Streams.StringsHeap[methodRow.Name], methodRow.Flags);
				methodDefinition.RVA = methodRow.RVA;
				methodDefinition.ImplAttributes = methodRow.ImplFlags;
				methodDefinition.MetadataToken = MetadataToken.FromMetadataRow(TokenType.Method, i);
				m_meths[i] = methodDefinition;
			}
		}

		private void CompleteMethods()
		{
			TypeDefTable typeDefTable = m_tableReader.GetTypeDefTable();
			if (!m_tHeap.HasTable(6))
			{
				m_meths = new MethodDefinition[0];
				return;
			}
			MethodTable methodTable = m_tableReader.GetMethodTable();
			ParamTable paramTable = m_tableReader.GetParamTable();
			if (!m_tHeap.HasTable(8))
			{
				m_parameters = new ParameterDefinition[0];
			}
			else
			{
				m_parameters = new ParameterDefinition[paramTable.Rows.Count];
			}
			for (int i = 0; i < m_typeDefs.Length; i++)
			{
				TypeDefinition typeDefinition = m_typeDefs[i];
				int num = i;
				int num2 = (num != typeDefTable.Rows.Count - 1) ? ((int)typeDefTable[num + 1].MethodList) : (methodTable.Rows.Count + 1);
				for (int j = (int)typeDefTable[num].MethodList; j < num2; j++)
				{
					MethodRow methodRow = methodTable[j - 1];
					MethodDefinition methodDefinition = m_meths[j - 1];
					if (!IsDeleted(methodDefinition))
					{
						if (methodDefinition.IsConstructor)
						{
							typeDefinition.Constructors.Add(methodDefinition);
						}
						else
						{
							typeDefinition.Methods.Add(methodDefinition);
						}
					}
					GenericContext context = new GenericContext(methodDefinition);
					MethodDefSig methodDefSig = m_sigReader.GetMethodDefSig(methodRow.Signature);
					methodDefinition.HasThis = methodDefSig.HasThis;
					methodDefinition.ExplicitThis = methodDefSig.ExplicitThis;
					methodDefinition.CallingConvention = methodDefSig.MethCallConv;
					int num3 = (j != methodTable.Rows.Count) ? ((int)methodTable[j].ParamList) : (m_parameters.Length + 1);
					ParameterDefinition parameterDefinition = null;
					int num4 = (int)(methodRow.ParamList - 1);
					if (paramTable != null && num4 < num3 - 1)
					{
						ParamRow paramRow = paramTable[num4];
						if (paramRow != null && paramRow.Sequence == 0)
						{
							parameterDefinition = new ParameterDefinition(m_root.Streams.StringsHeap[paramRow.Name], 0, paramRow.Flags, null);
							parameterDefinition.Method = methodDefinition;
							m_parameters[num4] = parameterDefinition;
							num4++;
						}
					}
					for (int k = 0; k < methodDefSig.ParamCount; k++)
					{
						int num5 = num4 + k;
						ParamRow paramRow2 = null;
						if (paramTable != null && num5 < num3 - 1)
						{
							paramRow2 = paramTable[num5];
						}
						Param psig = methodDefSig.Parameters[k];
						ParameterDefinition parameterDefinition2;
						if (paramRow2 != null)
						{
							parameterDefinition2 = BuildParameterDefinition(m_root.Streams.StringsHeap[paramRow2.Name], paramRow2.Sequence, paramRow2.Flags, psig, context);
							parameterDefinition2.MetadataToken = MetadataToken.FromMetadataRow(TokenType.Param, num5);
							m_parameters[num5] = parameterDefinition2;
						}
						else
						{
							parameterDefinition2 = BuildParameterDefinition(k + 1, psig, context);
						}
						parameterDefinition2.Method = methodDefinition;
						methodDefinition.Parameters.Add(parameterDefinition2);
					}
					methodDefinition.ReturnType = GetMethodReturnType(methodDefSig, context);
					MethodReturnType returnType = methodDefinition.ReturnType;
					returnType.Method = methodDefinition;
					if (parameterDefinition != null)
					{
						returnType.Parameter = parameterDefinition;
						returnType.Parameter.ParameterType = returnType.ReturnType;
					}
				}
			}
			uint rid = CodeReader.GetRid((int)m_reader.Image.CLIHeader.EntryPointToken);
			if (rid != 0 && rid <= m_meths.Length)
			{
				m_module.Assembly.EntryPoint = GetMethodDefAt(rid);
			}
		}

		private void ReadMemberReferences()
		{
			if (m_tHeap.HasTable(10))
			{
				MemberRefTable memberRefTable = m_tableReader.GetMemberRefTable();
				m_memberRefs = new MemberReference[memberRefTable.Rows.Count];
			}
		}

		public override void VisitExternTypeCollection(ExternTypeCollection externs)
		{
			if (!m_tHeap.HasTable(39))
			{
				return;
			}
			ExportedTypeTable exportedTypeTable = m_tableReader.GetExportedTypeTable();
			TypeReference[] array = new TypeReference[exportedTypeTable.Rows.Count];
			for (int i = 0; i < exportedTypeTable.Rows.Count; i++)
			{
				ExportedTypeRow exportedTypeRow = exportedTypeTable[i];
				array[i] = new TypeDefinition(m_root.Streams.StringsHeap[exportedTypeRow.TypeName], m_root.Streams.StringsHeap[exportedTypeRow.TypeNamespace], exportedTypeRow.Flags);
				array[i].AttachToScope(GetExportedTypeScope(exportedTypeRow.Implementation));
			}
			for (int j = 0; j < exportedTypeTable.Rows.Count; j++)
			{
				ExportedTypeRow exportedTypeRow2 = exportedTypeTable[j];
				if (exportedTypeRow2.Implementation.TokenType == TokenType.ExportedType)
				{
					TypeReference typeReference = array[j];
					TypeReference typeReference3 = typeReference.DeclaringType = array[(ulong)(exportedTypeRow2.Implementation.RID - 1)];
					typeReference.AttachToScope(typeReference3.Scope);
				}
			}
			foreach (TypeReference typeReference4 in array)
			{
				if (typeReference4 != null)
				{
					externs.Add(typeReference4);
				}
			}
		}

		private IMetadataScope GetExportedTypeScope(MetadataToken scope)
		{
			int index = (int)(scope.RID - 1);
			switch (scope.TokenType)
			{
			case TokenType.AssemblyRef:
				return Module.AssemblyReferences[index];
			case TokenType.File:
				return Module.ModuleReferences[index];
			case TokenType.ExportedType:
				return null;
			default:
				throw new NotSupportedException();
			}
		}

		private static object GetFixedArgValue(CustomAttrib.FixedArg fa)
		{
			if (fa.SzArray)
			{
				object[] array = new object[fa.NumElem];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = fa.Elems[i].Value;
				}
				return array;
			}
			return fa.Elems[0].Value;
		}

		private TypeReference GetFixedArgType(CustomAttrib.FixedArg fa)
		{
			if (fa.SzArray)
			{
				if (fa.NumElem == 0)
				{
					return new ArrayType(SearchCoreType("System.Object"));
				}
				return new ArrayType(fa.Elems[0].ElemType);
			}
			return fa.Elems[0].ElemType;
		}

		private TypeReference GetNamedArgType(CustomAttrib.NamedArg na)
		{
			if (na.FieldOrPropType == ElementType.Boxed)
			{
				return SearchCoreType("System.Object");
			}
			return GetFixedArgType(na.FixedArg);
		}

		protected CustomAttribute BuildCustomAttribute(MethodReference ctor, byte[] data, CustomAttrib sig)
		{
			CustomAttribute customAttribute = new CustomAttribute(ctor);
			if (!sig.Read)
			{
				customAttribute.Resolved = false;
				customAttribute.Blob = data;
				return customAttribute;
			}
			CustomAttrib.FixedArg[] fixedArgs = sig.FixedArgs;
			foreach (CustomAttrib.FixedArg fa in fixedArgs)
			{
				customAttribute.ConstructorParameters.Add(GetFixedArgValue(fa));
			}
			CustomAttrib.NamedArg[] namedArgs = sig.NamedArgs;
			for (int j = 0; j < namedArgs.Length; j++)
			{
				CustomAttrib.NamedArg na = namedArgs[j];
				object fixedArgValue = GetFixedArgValue(na.FixedArg);
				if (na.Field)
				{
					customAttribute.Fields[na.FieldOrPropName] = fixedArgValue;
					customAttribute.SetFieldType(na.FieldOrPropName, GetNamedArgType(na));
					continue;
				}
				if (na.Property)
				{
					customAttribute.Properties[na.FieldOrPropName] = fixedArgValue;
					customAttribute.SetPropertyType(na.FieldOrPropName, GetNamedArgType(na));
					continue;
				}
				throw new ReflectionException("Non valid named arg");
			}
			return customAttribute;
		}

		private void CompleteParameter(ParameterDefinition parameter, Param signature, GenericContext context)
		{
			TypeReference typeReference = GetModifierType(type: (!signature.TypedByRef) ? GetTypeRefFromSig(signature.Type, context) : SearchCoreType("System.TypedReference"), cmods: signature.CustomMods);
			if (signature.ByRef)
			{
				typeReference = new ReferenceType(typeReference);
			}
			parameter.ParameterType = typeReference;
		}

		public ParameterDefinition BuildParameterDefinition(int sequence, Param psig, GenericContext context)
		{
			ParameterDefinition parameterDefinition = new ParameterDefinition(null);
			parameterDefinition.Sequence = sequence;
			CompleteParameter(parameterDefinition, psig, context);
			return parameterDefinition;
		}

		public ParameterDefinition BuildParameterDefinition(string name, int sequence, ParameterAttributes attrs, Param psig, GenericContext context)
		{
			ParameterDefinition parameterDefinition = new ParameterDefinition(name, sequence, attrs, null);
			CompleteParameter(parameterDefinition, psig, context);
			return parameterDefinition;
		}

		protected SecurityDeclaration BuildSecurityDeclaration(DeclSecurityRow dsRow)
		{
			return BuildSecurityDeclaration(dsRow.Action, m_root.Streams.BlobHeap.Read(dsRow.PermissionSet));
		}

		public SecurityDeclaration BuildSecurityDeclaration(SecurityAction action, byte[] permset)
		{
			if (m_secReader == null)
			{
				m_secReader = new SecurityDeclarationReader(m_root, this);
			}
			return m_secReader.FromByteArray(action, permset);
		}

		protected MarshalSpec BuildMarshalDesc(MarshalSig ms, IHasMarshalSpec container)
		{
			if (ms.Spec is MarshalSig.Array)
			{
				ArrayMarshalSpec arrayMarshalSpec = new ArrayMarshalSpec(container);
				MarshalSig.Array array = (MarshalSig.Array)ms.Spec;
				arrayMarshalSpec.ElemType = array.ArrayElemType;
				arrayMarshalSpec.NumElem = array.NumElem;
				arrayMarshalSpec.ParamNum = array.ParamNum;
				arrayMarshalSpec.ElemMult = array.ElemMult;
				return arrayMarshalSpec;
			}
			if (ms.Spec is MarshalSig.CustomMarshaler)
			{
				CustomMarshalerSpec customMarshalerSpec = new CustomMarshalerSpec(container);
				MarshalSig.CustomMarshaler customMarshaler = (MarshalSig.CustomMarshaler)ms.Spec;
				customMarshalerSpec.Guid = ((customMarshaler.Guid.Length <= 0) ? default(Guid) : new Guid(customMarshaler.Guid));
				customMarshalerSpec.UnmanagedType = customMarshaler.UnmanagedType;
				customMarshalerSpec.ManagedType = customMarshaler.ManagedType;
				customMarshalerSpec.Cookie = customMarshaler.Cookie;
				return customMarshalerSpec;
			}
			if (ms.Spec is MarshalSig.FixedArray)
			{
				FixedArraySpec fixedArraySpec = new FixedArraySpec(container);
				MarshalSig.FixedArray fixedArray = (MarshalSig.FixedArray)ms.Spec;
				fixedArraySpec.ElemType = fixedArray.ArrayElemType;
				fixedArraySpec.NumElem = fixedArray.NumElem;
				return fixedArraySpec;
			}
			if (ms.Spec is MarshalSig.FixedSysString)
			{
				FixedSysStringSpec fixedSysStringSpec = new FixedSysStringSpec(container);
				fixedSysStringSpec.Size = ((MarshalSig.FixedSysString)ms.Spec).Size;
				return fixedSysStringSpec;
			}
			if (ms.Spec is MarshalSig.SafeArray)
			{
				SafeArraySpec safeArraySpec = new SafeArraySpec(container);
				safeArraySpec.ElemType = ((MarshalSig.SafeArray)ms.Spec).ArrayElemType;
				return safeArraySpec;
			}
			return new MarshalSpec(ms.NativeInstrinsic, container);
		}

		public TypeReference GetModifierType(CustomMod[] cmods, TypeReference type)
		{
			if (cmods == null || cmods.Length == 0)
			{
				return type;
			}
			TypeReference typeReference = type;
			for (int num = cmods.Length - 1; num >= 0; num--)
			{
				CustomMod customMod = cmods[num];
				if (customMod.TypeDefOrRef.RID != 0)
				{
					TypeReference modType = (customMod.TypeDefOrRef.TokenType != TokenType.TypeDef) ? GetTypeRefAt(customMod.TypeDefOrRef.RID) : GetTypeDefAt(customMod.TypeDefOrRef.RID);
					if (customMod.CMOD == CustomMod.CMODType.OPT)
					{
						typeReference = new ModifierOptional(typeReference, modType);
					}
					else if (customMod.CMOD == CustomMod.CMODType.REQD)
					{
						typeReference = new ModifierRequired(typeReference, modType);
					}
				}
			}
			return typeReference;
		}

		public MethodReturnType GetMethodReturnType(MethodSig msig, GenericContext context)
		{
			TypeReference typeReference = GetModifierType(type: msig.RetType.Void ? SearchCoreType("System.Void") : ((!msig.RetType.TypedByRef) ? GetTypeRefFromSig(msig.RetType.Type, context) : SearchCoreType("System.TypedReference")), cmods: msig.RetType.CustomMods);
			if (msig.RetType.ByRef)
			{
				typeReference = new ReferenceType(typeReference);
			}
			return new MethodReturnType(typeReference);
		}

		public TypeReference GetTypeRefFromSig(SigType t, GenericContext context)
		{
			switch (t.ElementType)
			{
			case ElementType.Class:
			{
				CLASS cLASS = t as CLASS;
				return GetTypeDefOrRef(cLASS.Type, context);
			}
			case ElementType.ValueType:
			{
				VALUETYPE vALUETYPE = t as VALUETYPE;
				TypeReference typeDefOrRef = GetTypeDefOrRef(vALUETYPE.Type, context);
				typeDefOrRef.IsValueType = true;
				return typeDefOrRef;
			}
			case ElementType.String:
				return SearchCoreType("System.String");
			case ElementType.Object:
				return SearchCoreType("System.Object");
			case ElementType.Void:
				return SearchCoreType("System.Void");
			case ElementType.Boolean:
				return SearchCoreType("System.Boolean");
			case ElementType.Char:
				return SearchCoreType("System.Char");
			case ElementType.I1:
				return SearchCoreType("System.SByte");
			case ElementType.U1:
				return SearchCoreType("System.Byte");
			case ElementType.I2:
				return SearchCoreType("System.Int16");
			case ElementType.U2:
				return SearchCoreType("System.UInt16");
			case ElementType.I4:
				return SearchCoreType("System.Int32");
			case ElementType.U4:
				return SearchCoreType("System.UInt32");
			case ElementType.I8:
				return SearchCoreType("System.Int64");
			case ElementType.U8:
				return SearchCoreType("System.UInt64");
			case ElementType.R4:
				return SearchCoreType("System.Single");
			case ElementType.R8:
				return SearchCoreType("System.Double");
			case ElementType.I:
				return SearchCoreType("System.IntPtr");
			case ElementType.U:
				return SearchCoreType("System.UIntPtr");
			case ElementType.TypedByRef:
				return SearchCoreType("System.TypedReference");
			case ElementType.Array:
			{
				ARRAY aRRAY = t as ARRAY;
				return new ArrayType(GetTypeRefFromSig(aRRAY.Type, context), aRRAY.Shape);
			}
			case ElementType.SzArray:
			{
				SZARRAY sZARRAY = t as SZARRAY;
				return new ArrayType(GetTypeRefFromSig(sZARRAY.Type, context));
			}
			case ElementType.Ptr:
			{
				PTR pTR = t as PTR;
				if (pTR.Void)
				{
					return new PointerType(SearchCoreType("System.Void"));
				}
				return new PointerType(GetTypeRefFromSig(pTR.PtrType, context));
			}
			case ElementType.FnPtr:
			{
				FNPTR fNPTR = t as FNPTR;
				FunctionPointerType functionPointerType = new FunctionPointerType(fNPTR.Method.HasThis, fNPTR.Method.ExplicitThis, fNPTR.Method.MethCallConv, GetMethodReturnType(fNPTR.Method, context));
				for (int j = 0; j < fNPTR.Method.ParamCount; j++)
				{
					Param psig = fNPTR.Method.Parameters[j];
					functionPointerType.Parameters.Add(BuildParameterDefinition(j, psig, context));
				}
				CreateSentinelIfNeeded(functionPointerType, fNPTR.Method);
				return functionPointerType;
			}
			case ElementType.Var:
			{
				VAR vAR = t as VAR;
				context.CheckProvider(context.Type, vAR.Index + 1);
				if (context.Type is GenericInstanceType)
				{
					return (context.Type as GenericInstanceType).GenericArguments[vAR.Index];
				}
				return context.Type.GenericParameters[vAR.Index];
			}
			case ElementType.MVar:
			{
				MVAR mVAR = t as MVAR;
				context.CheckProvider(context.Method, mVAR.Index + 1);
				if (context.Method is GenericInstanceMethod)
				{
					return (context.Method as GenericInstanceMethod).GenericArguments[mVAR.Index];
				}
				return context.Method.GenericParameters[mVAR.Index];
			}
			case ElementType.GenericInst:
			{
				GENERICINST gENERICINST = t as GENERICINST;
				GenericInstanceType genericInstanceType = new GenericInstanceType(GetTypeDefOrRef(gENERICINST.Type, context));
				genericInstanceType.IsValueType = gENERICINST.ValueType;
				context.CheckProvider(genericInstanceType.GetOriginalType(), gENERICINST.Signature.Arity);
				for (int i = 0; i < gENERICINST.Signature.Arity; i++)
				{
					genericInstanceType.GenericArguments.Add(GetGenericArg(gENERICINST.Signature.Types[i], context));
				}
				return genericInstanceType;
			}
			default:
				return null;
			}
		}

		private TypeReference GetGenericArg(GenericArg arg, GenericContext context)
		{
			TypeReference typeRefFromSig = GetTypeRefFromSig(arg.Type, context);
			return GetModifierType(arg.CustomMods, typeRefFromSig);
		}

		private static bool IsOdd(int i)
		{
			return (i & 1) == 1;
		}

		protected object GetConstant(uint pos, ElementType elemType)
		{
			if (elemType == ElementType.Class)
			{
				return null;
			}
			byte[] array = m_root.Streams.BlobHeap.Read(pos);
			if (elemType == ElementType.String)
			{
				int num = array.Length;
				if (IsOdd(num))
				{
					num--;
				}
				return Encoding.Unicode.GetString(array, 0, num);
			}
			switch (elemType)
			{
			case ElementType.Boolean:
				return BitConverter.ToBoolean(array, 0);
			case ElementType.I1:
				return (sbyte)array[0];
			case ElementType.U1:
				return array[0];
			case ElementType.Object:
				return null;
			default:
				if (BitConverter.IsLittleEndian)
				{
					return GetConstantLittleEndian(elemType, array);
				}
				return GetConstantBigEndian(elemType, array);
			}
		}

		private static object GetConstantLittleEndian(ElementType elemType, byte[] constant)
		{
			switch (elemType)
			{
			case ElementType.Char:
				return BitConverter.ToChar(constant, 0);
			case ElementType.I2:
				return BitConverter.ToInt16(constant, 0);
			case ElementType.I4:
				return BitConverter.ToInt32(constant, 0);
			case ElementType.I8:
				return BitConverter.ToInt64(constant, 0);
			case ElementType.U2:
				return BitConverter.ToUInt16(constant, 0);
			case ElementType.U4:
				return BitConverter.ToUInt32(constant, 0);
			case ElementType.U8:
				return BitConverter.ToUInt64(constant, 0);
			case ElementType.R4:
				return BitConverter.ToSingle(constant, 0);
			case ElementType.R8:
				return BitConverter.ToDouble(constant, 0);
			default:
				throw new ReflectionException("Non valid element in constant table");
			}
		}

		private static object GetConstantBigEndian(ElementType elemType, byte[] constant)
		{
			BinaryReader binaryReader = new BinaryReader(new MemoryStream(constant));
			switch (elemType)
			{
			case ElementType.Char:
				return (char)binaryReader.ReadUInt16();
			case ElementType.I2:
				return binaryReader.ReadInt16();
			case ElementType.I4:
				return binaryReader.ReadInt32();
			case ElementType.I8:
				return binaryReader.ReadInt64();
			case ElementType.U2:
				return binaryReader.ReadUInt16();
			case ElementType.U4:
				return binaryReader.ReadUInt32();
			case ElementType.U8:
				return binaryReader.ReadUInt64();
			case ElementType.R4:
				return binaryReader.ReadSingle();
			case ElementType.R8:
				return binaryReader.ReadDouble();
			default:
				throw new ReflectionException("Non valid element in constant table");
			}
		}

		protected void SetInitialValue(FieldDefinition field)
		{
			int num = 0;
			TypeReference fieldType = field.FieldType;
			switch (fieldType.FullName)
			{
			case "System.Boolean":
			case "System.Byte":
			case "System.SByte":
				num = 1;
				break;
			case "System.Int16":
			case "System.UInt16":
			case "System.Char":
				num = 2;
				break;
			case "System.Int32":
			case "System.UInt32":
			case "System.Single":
				num = 4;
				break;
			case "System.Int64":
			case "System.UInt64":
			case "System.Double":
				num = 8;
				break;
			default:
			{
				fieldType = fieldType.GetOriginalType();
				TypeDefinition typeDefinition = fieldType as TypeDefinition;
				if (typeDefinition != null)
				{
					num = (int)typeDefinition.ClassSize;
				}
				break;
			}
			}
			if (num > 0 && field.RVA != RVA.Zero)
			{
				byte[] array = new byte[num];
				Section sectionAtVirtualAddress = m_reader.Image.GetSectionAtVirtualAddress(field.RVA);
				if (sectionAtVirtualAddress != null)
				{
					Buffer.BlockCopy(sectionAtVirtualAddress.Data, (int)(uint)(field.RVA - sectionAtVirtualAddress.VirtualAddress), array, 0, num);
				}
				field.InitialValue = array;
			}
			else
			{
				field.InitialValue = new byte[0];
			}
		}
	}
}
