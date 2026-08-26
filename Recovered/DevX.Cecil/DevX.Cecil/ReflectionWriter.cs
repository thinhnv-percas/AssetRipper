using DevX.Cecil.Binary;
using DevX.Cecil.Cil;
using DevX.Cecil.Metadata;
using DevX.Cecil.Signatures;
using System;
using System.Collections;
using System.Globalization;
using System.Text;

namespace DevX.Cecil
{
	internal sealed class ReflectionWriter : BaseReflectionVisitor
	{
		private StructureWriter m_structureWriter;

		private ModuleDefinition m_mod;

		private SignatureWriter m_sigWriter;

		private CodeWriter m_codeWriter;

		private MetadataWriter m_mdWriter;

		private MetadataTableWriter m_tableWriter;

		private MetadataRowWriter m_rowWriter;

		private bool m_saveSymbols;

		private string m_asmOutput;

		private ISymbolWriter m_symbolWriter;

		private ArrayList m_typeDefStack;

		private ArrayList m_methodStack;

		private ArrayList m_fieldStack;

		private ArrayList m_genericParamStack;

		private IDictionary m_typeSpecTokenCache;

		private IDictionary m_memberRefTokenCache;

		private uint m_methodIndex;

		private uint m_fieldIndex;

		private uint m_paramIndex;

		private uint m_eventIndex;

		private uint m_propertyIndex;

		private MemoryBinaryWriter m_constWriter;

		public StructureWriter StructureWriter
		{
			get
			{
				return m_structureWriter;
			}
			set
			{
				m_structureWriter = value;
				Initialize();
			}
		}

		public CodeWriter CodeWriter => m_codeWriter;

		public bool SaveSymbols
		{
			get
			{
				return m_saveSymbols;
			}
			set
			{
				m_saveSymbols = value;
			}
		}

		public string OutputFile
		{
			get
			{
				return m_asmOutput;
			}
			set
			{
				m_asmOutput = value;
			}
		}

		public ISymbolWriter SymbolWriter
		{
			get
			{
				return m_symbolWriter;
			}
			set
			{
				m_symbolWriter = value;
			}
		}

		public SignatureWriter SignatureWriter => m_sigWriter;

		public MetadataWriter MetadataWriter => m_mdWriter;

		public MetadataTableWriter MetadataTableWriter => m_tableWriter;

		public MetadataRowWriter MetadataRowWriter => m_rowWriter;

		public ReflectionWriter(ModuleDefinition mod)
		{
			m_mod = mod;
		}

		private void Initialize()
		{
			m_mdWriter = new MetadataWriter(m_mod.Assembly, m_mod.Image.MetadataRoot, m_structureWriter.Assembly.Kind, m_mod.Assembly.Runtime, m_structureWriter.GetWriter());
			m_tableWriter = m_mdWriter.GetTableVisitor();
			m_rowWriter = (m_tableWriter.GetRowVisitor() as MetadataRowWriter);
			m_sigWriter = new SignatureWriter(m_mdWriter);
			m_codeWriter = new CodeWriter(this, m_mdWriter.CilWriter);
			m_typeDefStack = new ArrayList();
			m_methodStack = new ArrayList();
			m_fieldStack = new ArrayList();
			m_genericParamStack = new ArrayList();
			m_typeSpecTokenCache = new Hashtable();
			m_memberRefTokenCache = new Hashtable();
			m_methodIndex = 1u;
			m_fieldIndex = 1u;
			m_paramIndex = 1u;
			m_eventIndex = 1u;
			m_propertyIndex = 1u;
			m_constWriter = new MemoryBinaryWriter();
		}

		public TypeReference GetCoreType(string name)
		{
			return m_mod.Controller.Reader.SearchCoreType(name);
		}

		public static uint GetRidFor(IMetadataTokenProvider tp)
		{
			return tp.MetadataToken.RID;
		}

		public uint GetRidFor(AssemblyNameReference asmName)
		{
			return (uint)(m_mod.AssemblyReferences.IndexOf(asmName) + 1);
		}

		public uint GetRidFor(ModuleDefinition mod)
		{
			return (uint)(m_mod.Assembly.Modules.IndexOf(mod) + 1);
		}

		public uint GetRidFor(ModuleReference modRef)
		{
			return (uint)(m_mod.ModuleReferences.IndexOf(modRef) + 1);
		}

		private static bool IsTypeSpec(TypeReference type)
		{
			return type is TypeSpecification || type is GenericParameter;
		}

		public MetadataToken GetTypeDefOrRefToken(TypeReference type)
		{
			if (IsTypeSpec(type))
			{
				uint num = m_sigWriter.AddTypeSpec(GetTypeSpecSig(type));
				if (m_typeSpecTokenCache.Contains(num))
				{
					return (MetadataToken)m_typeSpecTokenCache[num];
				}
				TypeSpecTable typeSpecTable = m_tableWriter.GetTypeSpecTable();
				TypeSpecRow value = m_rowWriter.CreateTypeSpecRow(num);
				typeSpecTable.Rows.Add(value);
				MetadataToken metadataToken = new MetadataToken(TokenType.TypeSpec, (uint)typeSpecTable.Rows.Count);
				if (!(type is GenericParameter))
				{
					type.MetadataToken = metadataToken;
				}
				m_typeSpecTokenCache[num] = metadataToken;
				return metadataToken;
			}
			return type?.MetadataToken ?? new MetadataToken(TokenType.TypeRef, 0u);
		}

		public MetadataToken GetMemberRefToken(MemberReference member)
		{
			if (member is MethodSpecification)
			{
				return GetMemberRefToken(((MethodSpecification)member).ElementMethod);
			}
			if (member is IMemberDefinition)
			{
				return member.MetadataToken;
			}
			if (m_memberRefTokenCache.Contains(member))
			{
				return (MetadataToken)m_memberRefTokenCache[member];
			}
			MemberRefTable memberRefTable = m_tableWriter.GetMemberRefTable();
			uint num = 0u;
			if (member is FieldReference)
			{
				num = m_sigWriter.AddFieldSig(GetFieldSig((FieldReference)member));
			}
			else if (member is MethodReference)
			{
				num = m_sigWriter.AddMethodRefSig(GetMethodRefSig((MethodReference)member));
			}
			MetadataToken typeDefOrRefToken = GetTypeDefOrRefToken(member.DeclaringType);
			uint num2 = m_mdWriter.AddString(member.Name);
			for (int i = 0; i < memberRefTable.Rows.Count; i++)
			{
				MemberRefRow memberRefRow = memberRefTable[i];
				if (memberRefRow.Class == typeDefOrRefToken && memberRefRow.Name == num2 && memberRefRow.Signature == num)
				{
					return MetadataToken.FromMetadataRow(TokenType.MemberRef, i);
				}
			}
			MemberRefRow value = m_rowWriter.CreateMemberRefRow(typeDefOrRefToken, num2, num);
			memberRefTable.Rows.Add(value);
			member.MetadataToken = new MetadataToken(TokenType.MemberRef, (uint)memberRefTable.Rows.Count);
			m_memberRefTokenCache[member] = member.MetadataToken;
			return member.MetadataToken;
		}

		public MetadataToken GetMethodSpecToken(GenericInstanceMethod gim)
		{
			uint num = m_sigWriter.AddMethodSpec(GetMethodSpecSig(gim));
			MethodSpecTable methodSpecTable = m_tableWriter.GetMethodSpecTable();
			MetadataToken memberRefToken = GetMemberRefToken(gim.ElementMethod);
			for (int i = 0; i < methodSpecTable.Rows.Count; i++)
			{
				MethodSpecRow methodSpecRow = methodSpecTable[i];
				if (methodSpecRow.Method == memberRefToken && methodSpecRow.Instantiation == num)
				{
					return MetadataToken.FromMetadataRow(TokenType.MethodSpec, i);
				}
			}
			MethodSpecRow value = m_rowWriter.CreateMethodSpecRow(memberRefToken, num);
			methodSpecTable.Rows.Add(value);
			gim.MetadataToken = new MetadataToken(TokenType.MethodSpec, (uint)methodSpecTable.Rows.Count);
			return gim.MetadataToken;
		}

		public override void VisitModuleDefinition(ModuleDefinition mod)
		{
			mod.FullLoad();
		}

		public override void VisitTypeDefinitionCollection(TypeDefinitionCollection types)
		{
			TypeDefTable typeDefTable = m_tableWriter.GetTypeDefTable();
			if (types["<Module>"] == null)
			{
				types.Add(new TypeDefinition("<Module>", string.Empty, TypeAttributes.NotPublic));
			}
			foreach (TypeDefinition type in types)
			{
				m_typeDefStack.Add(type);
			}
			m_typeDefStack.Sort(TableComparers.TypeDef.Instance);
			for (int i = 0; i < m_typeDefStack.Count; i++)
			{
				TypeDefinition typeDefinition = (TypeDefinition)m_typeDefStack[i];
				if (typeDefinition.Module.Assembly != m_mod.Assembly)
				{
					throw new ReflectionException("A type as not been correctly imported");
				}
				typeDefinition.MetadataToken = new MetadataToken(TokenType.TypeDef, (uint)(i + 1));
			}
			foreach (TypeDefinition item in m_typeDefStack)
			{
				TypeDefRow value2 = m_rowWriter.CreateTypeDefRow(item.Attributes, m_mdWriter.AddString(item.Name), m_mdWriter.AddString(item.Namespace), GetTypeDefOrRefToken(item.BaseType), 0u, 0u);
				typeDefTable.Rows.Add(value2);
			}
		}

		public void CompleteTypeDefinitions()
		{
			TypeDefTable typeDefTable = m_tableWriter.GetTypeDefTable();
			for (int i = 0; i < m_typeDefStack.Count; i++)
			{
				TypeDefRow typeDefRow = typeDefTable[i];
				TypeDefinition typeDefinition = (TypeDefinition)m_typeDefStack[i];
				typeDefRow.FieldList = m_fieldIndex;
				typeDefRow.MethodList = m_methodIndex;
				if (typeDefinition.HasFields)
				{
					foreach (FieldDefinition field in typeDefinition.Fields)
					{
						VisitFieldDefinition(field);
					}
				}
				if (typeDefinition.HasConstructors)
				{
					foreach (MethodDefinition constructor in typeDefinition.Constructors)
					{
						VisitMethodDefinition(constructor);
					}
				}
				if (typeDefinition.HasMethods)
				{
					foreach (MethodDefinition method in typeDefinition.Methods)
					{
						VisitMethodDefinition(method);
					}
				}
				if (typeDefinition.HasLayoutInfo)
				{
					WriteLayout(typeDefinition);
				}
			}
			foreach (FieldDefinition item in m_fieldStack)
			{
				if (item.HasCustomAttributes)
				{
					VisitCustomAttributeCollection(item.CustomAttributes);
				}
				if (item.MarshalSpec != null)
				{
					VisitMarshalSpec(item.MarshalSpec);
				}
			}
			foreach (MethodDefinition item2 in m_methodStack)
			{
				if (item2.ReturnType.HasCustomAttributes)
				{
					VisitCustomAttributeCollection(item2.ReturnType.CustomAttributes);
				}
				if (item2.HasParameters)
				{
					foreach (ParameterDefinition parameter in item2.Parameters)
					{
						if (parameter.HasCustomAttributes)
						{
							VisitCustomAttributeCollection(parameter.CustomAttributes);
						}
					}
				}
				if (item2.HasGenericParameters)
				{
					VisitGenericParameterCollection(item2.GenericParameters);
				}
				if (item2.HasOverrides)
				{
					VisitOverrideCollection(item2.Overrides);
				}
				if (item2.HasCustomAttributes)
				{
					VisitCustomAttributeCollection(item2.CustomAttributes);
				}
				if (item2.HasSecurityDeclarations)
				{
					VisitSecurityDeclarationCollection(item2.SecurityDeclarations);
				}
				if (item2.PInvokeInfo != null)
				{
					item2.Attributes |= MethodAttributes.PInvokeImpl;
					VisitPInvokeInfo(item2.PInvokeInfo);
				}
			}
			foreach (TypeDefinition item3 in m_typeDefStack)
			{
				item3.Accept(this);
			}
		}

		public override void VisitTypeReferenceCollection(TypeReferenceCollection refs)
		{
			ArrayList arrayList = new ArrayList(refs.Count);
			foreach (TypeReference @ref in refs)
			{
				arrayList.Add(@ref);
			}
			arrayList.Sort(TableComparers.TypeRef.Instance);
			TypeRefTable typeRefTable = m_tableWriter.GetTypeRefTable();
			foreach (TypeReference item in arrayList)
			{
				if (item.Module.Assembly != m_mod.Assembly)
				{
					throw new ReflectionException("A type as not been correctly imported");
				}
				if (item.Scope != null)
				{
					MetadataToken resolutionScope = (item.DeclaringType != null) ? new MetadataToken(TokenType.TypeRef, GetRidFor(item.DeclaringType)) : ((item.Scope is AssemblyNameReference) ? new MetadataToken(TokenType.AssemblyRef, GetRidFor((AssemblyNameReference)item.Scope)) : ((item.Scope is ModuleDefinition) ? new MetadataToken(TokenType.Module, GetRidFor((ModuleDefinition)item.Scope)) : ((item.Scope is ModuleReference) ? new MetadataToken(TokenType.ModuleRef, GetRidFor((ModuleReference)item.Scope)) : new MetadataToken(TokenType.ExportedType, 0u))));
					TypeRefRow value2 = m_rowWriter.CreateTypeRefRow(resolutionScope, m_mdWriter.AddString(item.Name), m_mdWriter.AddString(item.Namespace));
					typeRefTable.Rows.Add(value2);
					item.MetadataToken = new MetadataToken(TokenType.TypeRef, (uint)typeRefTable.Rows.Count);
				}
			}
		}

		public override void VisitGenericParameterCollection(GenericParameterCollection parameters)
		{
			if (parameters.Count != 0)
			{
				foreach (GenericParameter parameter in parameters)
				{
					m_genericParamStack.Add(parameter);
				}
			}
		}

		public override void VisitInterfaceCollection(InterfaceCollection interfaces)
		{
			if (interfaces.Count != 0)
			{
				InterfaceImplTable interfaceImplTable = m_tableWriter.GetInterfaceImplTable();
				foreach (TypeReference @interface in interfaces)
				{
					InterfaceImplRow value = m_rowWriter.CreateInterfaceImplRow(GetRidFor(interfaces.Container), GetTypeDefOrRefToken(@interface));
					interfaceImplTable.Rows.Add(value);
				}
			}
		}

		public override void VisitExternTypeCollection(ExternTypeCollection externs)
		{
			VisitCollection(externs);
		}

		public override void VisitExternType(TypeReference externType)
		{
		}

		public override void VisitOverrideCollection(OverrideCollection meths)
		{
			if (meths.Count != 0)
			{
				MethodImplTable methodImplTable = m_tableWriter.GetMethodImplTable();
				foreach (MethodReference meth in meths)
				{
					MethodImplRow value = m_rowWriter.CreateMethodImplRow(GetRidFor(meths.Container.DeclaringType), new MetadataToken(TokenType.Method, GetRidFor(meths.Container)), GetMemberRefToken(meth));
					methodImplTable.Rows.Add(value);
				}
			}
		}

		public override void VisitNestedTypeCollection(NestedTypeCollection nestedTypes)
		{
			if (nestedTypes.Count != 0)
			{
				NestedClassTable nestedClassTable = m_tableWriter.GetNestedClassTable();
				foreach (TypeDefinition nestedType in nestedTypes)
				{
					NestedClassRow value = m_rowWriter.CreateNestedClassRow(nestedType.MetadataToken.RID, GetRidFor(nestedTypes.Container));
					nestedClassTable.Rows.Add(value);
				}
			}
		}

		public override void VisitParameterDefinitionCollection(ParameterDefinitionCollection parameters)
		{
			if (parameters.Count != 0)
			{
				ushort num = 1;
				ParamTable paramTable = m_tableWriter.GetParamTable();
				foreach (ParameterDefinition parameter in parameters)
				{
					ParamTable pTable = paramTable;
					ParameterDefinition param = parameter;
					ushort num2 = num;
					num = (ushort)(num2 + 1);
					InsertParameter(pTable, param, num2);
				}
			}
		}

		private void InsertParameter(ParamTable pTable, ParameterDefinition param, ushort seq)
		{
			ParamRow value = m_rowWriter.CreateParamRow(param.Attributes, seq, m_mdWriter.AddString(param.Name));
			pTable.Rows.Add(value);
			param.MetadataToken = new MetadataToken(TokenType.Param, (uint)pTable.Rows.Count);
			if (param.MarshalSpec != null)
			{
				param.MarshalSpec.Accept(this);
			}
			if (param.HasConstant)
			{
				WriteConstant(param, param.ParameterType);
			}
			m_paramIndex++;
		}

		private static bool RequiresParameterRow(MethodReturnType mrt)
		{
			return mrt.HasConstant || mrt.MarshalSpec != null || mrt.CustomAttributes.Count > 0 || mrt.Parameter.Attributes != ParameterAttributes.None;
		}

		public override void VisitMethodDefinition(MethodDefinition method)
		{
			MethodTable methodTable = m_tableWriter.GetMethodTable();
			MethodRow value = m_rowWriter.CreateMethodRow(RVA.Zero, method.ImplAttributes, method.Attributes, m_mdWriter.AddString(method.Name), m_sigWriter.AddMethodDefSig(GetMethodDefSig(method)), m_paramIndex);
			methodTable.Rows.Add(value);
			m_methodStack.Add(method);
			method.MetadataToken = new MetadataToken(TokenType.Method, (uint)methodTable.Rows.Count);
			m_methodIndex++;
			if (RequiresParameterRow(method.ReturnType))
			{
				InsertParameter(m_tableWriter.GetParamTable(), method.ReturnType.Parameter, 0);
			}
			VisitParameterDefinitionCollection(method.Parameters);
		}

		public override void VisitPInvokeInfo(PInvokeInfo pinvk)
		{
			ImplMapTable implMapTable = m_tableWriter.GetImplMapTable();
			ImplMapRow value = m_rowWriter.CreateImplMapRow(pinvk.Attributes, new MetadataToken(TokenType.Method, GetRidFor(pinvk.Method)), m_mdWriter.AddString(pinvk.EntryPoint), GetRidFor(pinvk.Module));
			implMapTable.Rows.Add(value);
		}

		public override void VisitEventDefinitionCollection(EventDefinitionCollection events)
		{
			if (events.Count != 0)
			{
				EventMapTable eventMapTable = m_tableWriter.GetEventMapTable();
				EventMapRow value = m_rowWriter.CreateEventMapRow(GetRidFor(events.Container), m_eventIndex);
				eventMapTable.Rows.Add(value);
				VisitCollection(events);
			}
		}

		public override void VisitEventDefinition(EventDefinition evt)
		{
			EventTable eventTable = m_tableWriter.GetEventTable();
			EventRow value = m_rowWriter.CreateEventRow(evt.Attributes, m_mdWriter.AddString(evt.Name), GetTypeDefOrRefToken(evt.EventType));
			eventTable.Rows.Add(value);
			evt.MetadataToken = new MetadataToken(TokenType.Event, (uint)eventTable.Rows.Count);
			if (evt.AddMethod != null)
			{
				WriteSemantic(MethodSemanticsAttributes.AddOn, evt, evt.AddMethod);
			}
			if (evt.InvokeMethod != null)
			{
				WriteSemantic(MethodSemanticsAttributes.Fire, evt, evt.InvokeMethod);
			}
			if (evt.RemoveMethod != null)
			{
				WriteSemantic(MethodSemanticsAttributes.RemoveOn, evt, evt.RemoveMethod);
			}
			m_eventIndex++;
		}

		public override void VisitFieldDefinition(FieldDefinition field)
		{
			FieldTable fieldTable = m_tableWriter.GetFieldTable();
			FieldRow value = m_rowWriter.CreateFieldRow(field.Attributes, m_mdWriter.AddString(field.Name), m_sigWriter.AddFieldSig(GetFieldSig(field)));
			fieldTable.Rows.Add(value);
			field.MetadataToken = new MetadataToken(TokenType.Field, (uint)fieldTable.Rows.Count);
			m_fieldIndex++;
			if (field.HasConstant)
			{
				WriteConstant(field, field.FieldType);
			}
			if (field.HasLayoutInfo)
			{
				WriteLayout(field);
			}
			m_fieldStack.Add(field);
		}

		public override void VisitPropertyDefinitionCollection(PropertyDefinitionCollection properties)
		{
			if (properties.Count != 0)
			{
				PropertyMapTable propertyMapTable = m_tableWriter.GetPropertyMapTable();
				PropertyMapRow value = m_rowWriter.CreatePropertyMapRow(GetRidFor(properties.Container), m_propertyIndex);
				propertyMapTable.Rows.Add(value);
				VisitCollection(properties);
			}
		}

		public override void VisitPropertyDefinition(PropertyDefinition property)
		{
			PropertyTable propertyTable = m_tableWriter.GetPropertyTable();
			PropertyRow value = m_rowWriter.CreatePropertyRow(property.Attributes, m_mdWriter.AddString(property.Name), m_sigWriter.AddPropertySig(GetPropertySig(property)));
			propertyTable.Rows.Add(value);
			property.MetadataToken = new MetadataToken(TokenType.Property, (uint)propertyTable.Rows.Count);
			if (property.GetMethod != null)
			{
				WriteSemantic(MethodSemanticsAttributes.Getter, property, property.GetMethod);
			}
			if (property.SetMethod != null)
			{
				WriteSemantic(MethodSemanticsAttributes.Setter, property, property.SetMethod);
			}
			if (property.HasConstant)
			{
				WriteConstant(property, property.PropertyType);
			}
			m_propertyIndex++;
		}

		public override void VisitSecurityDeclarationCollection(SecurityDeclarationCollection secDecls)
		{
			if (secDecls.Count != 0)
			{
				DeclSecurityTable declSecurityTable = m_tableWriter.GetDeclSecurityTable();
				foreach (SecurityDeclaration secDecl in secDecls)
				{
					DeclSecurityRow value = m_rowWriter.CreateDeclSecurityRow(secDecl.Action, secDecls.Container.MetadataToken, m_mdWriter.AddBlob((!secDecl.Resolved) ? secDecl.Blob : m_mod.GetAsByteArray(secDecl)));
					declSecurityTable.Rows.Add(value);
				}
			}
		}

		public override void VisitCustomAttributeCollection(CustomAttributeCollection customAttrs)
		{
			if (customAttrs.Count != 0)
			{
				CustomAttributeTable customAttributeTable = m_tableWriter.GetCustomAttributeTable();
				foreach (CustomAttribute customAttr in customAttrs)
				{
					MetadataToken parent;
					if (customAttrs.Container is AssemblyDefinition)
					{
						parent = new MetadataToken(TokenType.Assembly, 1u);
					}
					else if (customAttrs.Container is ModuleDefinition)
					{
						parent = new MetadataToken(TokenType.Module, 1u);
					}
					else
					{
						if (!(customAttrs.Container is IMetadataTokenProvider))
						{
							throw new ReflectionException("Unknown Custom Attribute parent");
						}
						parent = ((IMetadataTokenProvider)customAttrs.Container).MetadataToken;
					}
					uint value = (!customAttr.Resolved) ? m_mdWriter.AddBlob(m_mod.GetAsByteArray(customAttr)) : m_sigWriter.AddCustomAttribute(GetCustomAttributeSig(customAttr), customAttr.Constructor);
					CustomAttributeRow value2 = m_rowWriter.CreateCustomAttributeRow(parent, GetMemberRefToken(customAttr.Constructor), value);
					customAttributeTable.Rows.Add(value2);
				}
			}
		}

		public override void VisitMarshalSpec(MarshalSpec marshalSpec)
		{
			FieldMarshalTable fieldMarshalTable = m_tableWriter.GetFieldMarshalTable();
			FieldMarshalRow value = m_rowWriter.CreateFieldMarshalRow(marshalSpec.Container.MetadataToken, m_sigWriter.AddMarshalSig(GetMarshalSig(marshalSpec)));
			fieldMarshalTable.Rows.Add(value);
		}

		private void WriteConstant(IHasConstant hc, TypeReference type)
		{
			ConstantTable constantTable = m_tableWriter.GetConstantTable();
			ElementType elementType;
			if (type is TypeDefinition && (type as TypeDefinition).IsEnum)
			{
				Type type2 = hc.Constant.GetType();
				if (type2.IsEnum)
				{
					type2 = Enum.GetUnderlyingType(type2);
				}
				elementType = GetCorrespondingType(type2.Namespace + '.' + type2.Name);
			}
			else
			{
				elementType = GetCorrespondingType(type.FullName);
			}
			if (elementType == ElementType.Object || elementType == ElementType.Type || elementType == ElementType.String)
			{
				elementType = ((hc.Constant != null) ? GetCorrespondingType(hc.Constant.GetType().FullName) : ElementType.Class);
			}
			ConstantRow value = m_rowWriter.CreateConstantRow(elementType, hc.MetadataToken, m_mdWriter.AddBlob(EncodeConstant(elementType, hc.Constant)));
			constantTable.Rows.Add(value);
		}

		private void WriteLayout(FieldDefinition field)
		{
			FieldLayoutTable fieldLayoutTable = m_tableWriter.GetFieldLayoutTable();
			FieldLayoutRow value = m_rowWriter.CreateFieldLayoutRow(field.Offset, GetRidFor(field));
			fieldLayoutTable.Rows.Add(value);
		}

		private void WriteLayout(TypeDefinition type)
		{
			ClassLayoutTable classLayoutTable = m_tableWriter.GetClassLayoutTable();
			ClassLayoutRow value = m_rowWriter.CreateClassLayoutRow(type.PackingSize, type.ClassSize, GetRidFor(type));
			classLayoutTable.Rows.Add(value);
		}

		private void WriteSemantic(MethodSemanticsAttributes attrs, IMetadataTokenProvider member, MethodDefinition meth)
		{
			MethodSemanticsTable methodSemanticsTable = m_tableWriter.GetMethodSemanticsTable();
			MethodSemanticsRow value = m_rowWriter.CreateMethodSemanticsRow(attrs, GetRidFor(meth), member.MetadataToken);
			methodSemanticsTable.Rows.Add(value);
		}

		private void SortTables()
		{
			TablesHeap tablesHeap = m_mdWriter.GetMetadataRoot().Streams.TablesHeap;
			tablesHeap.Sorted = 0L;
			if (tablesHeap.HasTable(41))
			{
				m_tableWriter.GetNestedClassTable().Rows.Sort(TableComparers.NestedClass.Instance);
			}
			tablesHeap.Sorted |= 2199023255552L;
			if (tablesHeap.HasTable(9))
			{
				m_tableWriter.GetInterfaceImplTable().Rows.Sort(TableComparers.InterfaceImpl.Instance);
			}
			tablesHeap.Sorted |= 512L;
			if (tablesHeap.HasTable(11))
			{
				m_tableWriter.GetConstantTable().Rows.Sort(TableComparers.Constant.Instance);
			}
			tablesHeap.Sorted |= 2048L;
			if (tablesHeap.HasTable(24))
			{
				m_tableWriter.GetMethodSemanticsTable().Rows.Sort(TableComparers.MethodSem.Instance);
			}
			tablesHeap.Sorted |= 16777216L;
			if (tablesHeap.HasTable(13))
			{
				m_tableWriter.GetFieldMarshalTable().Rows.Sort(TableComparers.FieldMarshal.Instance);
			}
			tablesHeap.Sorted |= 8192L;
			if (tablesHeap.HasTable(15))
			{
				m_tableWriter.GetClassLayoutTable().Rows.Sort(TableComparers.TypeLayout.Instance);
			}
			tablesHeap.Sorted |= 32768L;
			if (tablesHeap.HasTable(16))
			{
				m_tableWriter.GetFieldLayoutTable().Rows.Sort(TableComparers.FieldLayout.Instance);
			}
			tablesHeap.Sorted |= 65536L;
			if (tablesHeap.HasTable(28))
			{
				m_tableWriter.GetImplMapTable().Rows.Sort(TableComparers.PInvoke.Instance);
			}
			tablesHeap.Sorted |= 268435456L;
			if (tablesHeap.HasTable(29))
			{
				m_tableWriter.GetFieldRVATable().Rows.Sort(TableComparers.FieldRVA.Instance);
			}
			tablesHeap.Sorted |= 536870912L;
			if (tablesHeap.HasTable(25))
			{
				m_tableWriter.GetMethodImplTable().Rows.Sort(TableComparers.Override.Instance);
			}
			tablesHeap.Sorted |= 33554432L;
			if (tablesHeap.HasTable(12))
			{
				m_tableWriter.GetCustomAttributeTable().Rows.Sort(TableComparers.CustomAttribute.Instance);
			}
			tablesHeap.Sorted |= 4096L;
			if (tablesHeap.HasTable(14))
			{
				m_tableWriter.GetDeclSecurityTable().Rows.Sort(TableComparers.SecurityDeclaration.Instance);
			}
			tablesHeap.Sorted |= 16384L;
		}

		private void CompleteGenericTables()
		{
			if (m_genericParamStack.Count != 0)
			{
				TablesHeap tablesHeap = m_mdWriter.GetMetadataRoot().Streams.TablesHeap;
				GenericParamTable genericParamTable = m_tableWriter.GetGenericParamTable();
				m_genericParamStack.Sort(TableComparers.GenericParam.Instance);
				foreach (GenericParameter item in m_genericParamStack)
				{
					GenericParamRow value = m_rowWriter.CreateGenericParamRow((ushort)item.Owner.GenericParameters.IndexOf(item), item.Attributes, item.Owner.MetadataToken, m_mdWriter.AddString(item.Name));
					genericParamTable.Rows.Add(value);
					item.MetadataToken = new MetadataToken(TokenType.GenericParam, (uint)genericParamTable.Rows.Count);
					if (item.HasCustomAttributes)
					{
						VisitCustomAttributeCollection(item.CustomAttributes);
					}
					if (item.HasConstraints)
					{
						GenericParamConstraintTable genericParamConstraintTable = m_tableWriter.GetGenericParamConstraintTable();
						foreach (TypeReference constraint in item.Constraints)
						{
							GenericParamConstraintRow value2 = m_rowWriter.CreateGenericParamConstraintRow((uint)genericParamTable.Rows.Count, GetTypeDefOrRefToken(constraint));
							genericParamConstraintTable.Rows.Add(value2);
						}
					}
				}
				tablesHeap.Sorted |= 4398046511104L;
				tablesHeap.Sorted |= 17592186044416L;
			}
		}

		public override void TerminateModuleDefinition(ModuleDefinition module)
		{
			if (module.Assembly.HasCustomAttributes)
			{
				VisitCustomAttributeCollection(module.Assembly.CustomAttributes);
			}
			if (module.Assembly.HasSecurityDeclarations)
			{
				VisitSecurityDeclarationCollection(module.Assembly.SecurityDeclarations);
			}
			if (module.HasCustomAttributes)
			{
				VisitCustomAttributeCollection(module.CustomAttributes);
			}
			CompleteGenericTables();
			SortTables();
			MethodTable methodTable = m_tableWriter.GetMethodTable();
			for (int i = 0; i < m_methodStack.Count; i++)
			{
				MethodDefinition methodDefinition = (MethodDefinition)m_methodStack[i];
				if (methodDefinition.HasBody)
				{
					methodTable[i].RVA = m_codeWriter.WriteMethodBody(methodDefinition);
				}
			}
			if (m_fieldStack.Count > 0)
			{
				FieldRVATable fieldRVATable = null;
				foreach (FieldDefinition item in m_fieldStack)
				{
					if (item.InitialValue != null && item.InitialValue.Length > 0)
					{
						if (fieldRVATable == null)
						{
							fieldRVATable = m_tableWriter.GetFieldRVATable();
						}
						FieldRVARow value = m_rowWriter.CreateFieldRVARow(m_mdWriter.GetDataCursor(), item.MetadataToken.RID);
						m_mdWriter.AddData((item.InitialValue.Length + 3) & -4);
						m_mdWriter.AddFieldInitData(item.InitialValue);
						fieldRVATable.Rows.Add(value);
					}
				}
			}
			if (m_symbolWriter != null)
			{
				m_symbolWriter.Dispose();
			}
			if (m_mod.Assembly.EntryPoint != null)
			{
				m_mdWriter.EntryPointToken = (0x6000000 | GetRidFor(m_mod.Assembly.EntryPoint));
			}
			m_mod.Image.MetadataRoot.Accept(m_mdWriter);
		}

		public static ElementType GetCorrespondingType(string fullName)
		{
			switch (fullName)
			{
			case "System.Boolean":
				return ElementType.Boolean;
			case "System.Char":
				return ElementType.Char;
			case "System.SByte":
				return ElementType.I1;
			case "System.Int16":
				return ElementType.I2;
			case "System.Int32":
				return ElementType.I4;
			case "System.Int64":
				return ElementType.I8;
			case "System.Byte":
				return ElementType.U1;
			case "System.UInt16":
				return ElementType.U2;
			case "System.UInt32":
				return ElementType.U4;
			case "System.UInt64":
				return ElementType.U8;
			case "System.Single":
				return ElementType.R4;
			case "System.Double":
				return ElementType.R8;
			case "System.String":
				return ElementType.String;
			case "System.Type":
				return ElementType.Type;
			case "System.Object":
				return ElementType.Object;
			default:
				return ElementType.Class;
			}
		}

		private byte[] EncodeConstant(ElementType et, object value)
		{
			m_constWriter.Empty();
			if (value == null)
			{
				et = ElementType.Class;
			}
			IConvertible convertible = value as IConvertible;
			IFormatProvider numberFormat = CultureInfo.CurrentCulture.NumberFormat;
			switch (et)
			{
			case ElementType.Boolean:
				m_constWriter.Write((byte)(convertible.ToBoolean(numberFormat) ? 1 : 0));
				break;
			case ElementType.Char:
				m_constWriter.Write((ushort)convertible.ToChar(numberFormat));
				break;
			case ElementType.I1:
				m_constWriter.Write(convertible.ToSByte(numberFormat));
				break;
			case ElementType.I2:
				m_constWriter.Write(convertible.ToInt16(numberFormat));
				break;
			case ElementType.I4:
				m_constWriter.Write(convertible.ToInt32(numberFormat));
				break;
			case ElementType.I8:
				m_constWriter.Write(convertible.ToInt64(numberFormat));
				break;
			case ElementType.U1:
				m_constWriter.Write(convertible.ToByte(numberFormat));
				break;
			case ElementType.U2:
				m_constWriter.Write(convertible.ToUInt16(numberFormat));
				break;
			case ElementType.U4:
				m_constWriter.Write(convertible.ToUInt32(numberFormat));
				break;
			case ElementType.U8:
				m_constWriter.Write(convertible.ToUInt64(numberFormat));
				break;
			case ElementType.R4:
				m_constWriter.Write(convertible.ToSingle(numberFormat));
				break;
			case ElementType.R8:
				m_constWriter.Write(convertible.ToDouble(numberFormat));
				break;
			case ElementType.String:
				m_constWriter.Write(Encoding.Unicode.GetBytes((string)value));
				break;
			case ElementType.Class:
				m_constWriter.Write(new byte[4]);
				break;
			default:
				throw new ArgumentException("Non valid element for a constant");
			}
			return m_constWriter.ToArray();
		}

		public SigType GetSigType(TypeReference type)
		{
			switch (type.FullName)
			{
			case "System.Void":
				return new SigType(ElementType.Void);
			case "System.Object":
				return new SigType(ElementType.Object);
			case "System.Boolean":
				return new SigType(ElementType.Boolean);
			case "System.String":
				return new SigType(ElementType.String);
			case "System.Char":
				return new SigType(ElementType.Char);
			case "System.SByte":
				return new SigType(ElementType.I1);
			case "System.Byte":
				return new SigType(ElementType.U1);
			case "System.Int16":
				return new SigType(ElementType.I2);
			case "System.UInt16":
				return new SigType(ElementType.U2);
			case "System.Int32":
				return new SigType(ElementType.I4);
			case "System.UInt32":
				return new SigType(ElementType.U4);
			case "System.Int64":
				return new SigType(ElementType.I8);
			case "System.UInt64":
				return new SigType(ElementType.U8);
			case "System.Single":
				return new SigType(ElementType.R4);
			case "System.Double":
				return new SigType(ElementType.R8);
			case "System.IntPtr":
				return new SigType(ElementType.I);
			case "System.UIntPtr":
				return new SigType(ElementType.U);
			case "System.TypedReference":
				return new SigType(ElementType.TypedByRef);
			default:
			{
				if (type is GenericParameter)
				{
					GenericParameter genericParameter = type as GenericParameter;
					int index = genericParameter.Owner.GenericParameters.IndexOf(genericParameter);
					if (genericParameter.Owner is TypeReference)
					{
						return new VAR(index);
					}
					if (genericParameter.Owner is MethodReference)
					{
						return new MVAR(index);
					}
					throw new ReflectionException("Unkown generic parameter type");
				}
				if (type is GenericInstanceType)
				{
					GenericInstanceType genericInstanceType = type as GenericInstanceType;
					GENERICINST gENERICINST = new GENERICINST();
					gENERICINST.ValueType = genericInstanceType.IsValueType;
					gENERICINST.Type = GetTypeDefOrRefToken(genericInstanceType.ElementType);
					gENERICINST.Signature = new GenericInstSignature();
					gENERICINST.Signature.Arity = genericInstanceType.GenericArguments.Count;
					gENERICINST.Signature.Types = new GenericArg[gENERICINST.Signature.Arity];
					for (int i = 0; i < genericInstanceType.GenericArguments.Count; i++)
					{
						gENERICINST.Signature.Types[i] = GetGenericArgSig(genericInstanceType.GenericArguments[i]);
					}
					return gENERICINST;
				}
				if (type is ArrayType)
				{
					ArrayType arrayType = type as ArrayType;
					if (arrayType.IsSizedArray)
					{
						SZARRAY sZARRAY = new SZARRAY();
						sZARRAY.CustomMods = GetCustomMods(arrayType.ElementType);
						sZARRAY.Type = GetSigType(arrayType.ElementType);
						return sZARRAY;
					}
					ArrayShape arrayShape = new ArrayShape();
					arrayShape.Rank = arrayType.Dimensions.Count;
					arrayShape.NumSizes = 0;
					for (int j = 0; j < arrayShape.Rank; j++)
					{
						ArrayDimension arrayDimension = arrayType.Dimensions[j];
						if (arrayDimension.UpperBound > 0)
						{
							arrayShape.NumSizes++;
						}
					}
					arrayShape.Sizes = new int[arrayShape.NumSizes];
					arrayShape.NumLoBounds = arrayShape.Rank;
					arrayShape.LoBounds = new int[arrayShape.NumLoBounds];
					for (int k = 0; k < arrayShape.Rank; k++)
					{
						ArrayDimension arrayDimension2 = arrayType.Dimensions[k];
						arrayShape.LoBounds[k] = arrayDimension2.LowerBound;
						if (arrayDimension2.UpperBound > 0)
						{
							arrayShape.Sizes[k] = arrayDimension2.UpperBound - arrayDimension2.LowerBound + 1;
						}
					}
					ARRAY aRRAY = new ARRAY();
					aRRAY.Shape = arrayShape;
					aRRAY.CustomMods = GetCustomMods(arrayType.ElementType);
					aRRAY.Type = GetSigType(arrayType.ElementType);
					return aRRAY;
				}
				if (type is PointerType)
				{
					PTR pTR = new PTR();
					TypeReference elementType = (type as PointerType).ElementType;
					pTR.Void = (elementType.FullName == "System.Void");
					if (!pTR.Void)
					{
						pTR.CustomMods = GetCustomMods(elementType);
						pTR.PtrType = GetSigType(elementType);
					}
					return pTR;
				}
				if (type is FunctionPointerType)
				{
					FNPTR fNPTR = new FNPTR();
					FunctionPointerType functionPointerType = type as FunctionPointerType;
					int sentinel = functionPointerType.GetSentinel();
					if (sentinel < 0)
					{
						fNPTR.Method = GetMethodDefSig(functionPointerType);
					}
					else
					{
						fNPTR.Method = GetMethodRefSig(functionPointerType);
					}
					return fNPTR;
				}
				if (type is TypeSpecification)
				{
					return GetSigType((type as TypeSpecification).ElementType);
				}
				if (type.IsValueType)
				{
					VALUETYPE vALUETYPE = new VALUETYPE();
					vALUETYPE.Type = GetTypeDefOrRefToken(type);
					return vALUETYPE;
				}
				CLASS cLASS = new CLASS();
				cLASS.Type = GetTypeDefOrRefToken(type);
				return cLASS;
			}
			}
		}

		public GenericArg GetGenericArgSig(TypeReference type)
		{
			GenericArg genericArg = new GenericArg(GetSigType(type));
			genericArg.CustomMods = GetCustomMods(type);
			return genericArg;
		}

		public CustomMod[] GetCustomMods(TypeReference type)
		{
			ModType modType = type as ModType;
			if (modType == null)
			{
				return CustomMod.EmptyCustomMod;
			}
			ArrayList arrayList = new ArrayList();
			do
			{
				CustomMod customMod = new CustomMod();
				customMod.TypeDefOrRef = GetTypeDefOrRefToken(modType.ModifierType);
				if (modType is ModifierOptional)
				{
					customMod.CMOD = CustomMod.CMODType.OPT;
				}
				else if (modType is ModifierRequired)
				{
					customMod.CMOD = CustomMod.CMODType.REQD;
				}
				arrayList.Add(customMod);
				modType = (modType.ElementType as ModType);
			}
			while (modType != null);
			return arrayList.ToArray(typeof(CustomMod)) as CustomMod[];
		}

		public Signature GetMemberRefSig(MemberReference member)
		{
			if (member is FieldReference)
			{
				return GetFieldSig(member as FieldReference);
			}
			return GetMemberRefSig(member as MethodReference);
		}

		public FieldSig GetFieldSig(FieldReference field)
		{
			FieldSig fieldSig = new FieldSig();
			fieldSig.CallingConvention |= 6;
			fieldSig.Field = true;
			fieldSig.CustomMods = GetCustomMods(field.FieldType);
			fieldSig.Type = GetSigType(field.FieldType);
			return fieldSig;
		}

		private Param[] GetParametersSig(ParameterDefinitionCollection parameters)
		{
			Param[] array = new Param[parameters.Count];
			for (int i = 0; i < array.Length; i++)
			{
				ParameterDefinition parameterDefinition = parameters[i];
				Param param = new Param();
				param.CustomMods = GetCustomMods(parameterDefinition.ParameterType);
				if (parameterDefinition.ParameterType.FullName == "System.TypedReference")
				{
					param.TypedByRef = true;
				}
				else if (IsByReferenceType(parameterDefinition.ParameterType))
				{
					param.ByRef = true;
					param.Type = GetSigType(parameterDefinition.ParameterType);
				}
				else
				{
					param.Type = GetSigType(parameterDefinition.ParameterType);
				}
				array[i] = param;
			}
			return array;
		}

		private void CompleteMethodSig(IMethodSignature meth, MethodSig sig)
		{
			sig.HasThis = meth.HasThis;
			sig.ExplicitThis = meth.ExplicitThis;
			if (sig.HasThis)
			{
				sig.CallingConvention |= 32;
			}
			if (sig.ExplicitThis)
			{
				sig.CallingConvention |= 64;
			}
			if ((meth.CallingConvention & MethodCallingConvention.VarArg) != 0)
			{
				sig.CallingConvention |= 5;
			}
			sig.ParamCount = meth.Parameters.Count;
			sig.Parameters = GetParametersSig(meth.Parameters);
			RetType retType = new RetType();
			retType.CustomMods = GetCustomMods(meth.ReturnType.ReturnType);
			if (meth.ReturnType.ReturnType.FullName == "System.Void")
			{
				retType.Void = true;
			}
			else if (meth.ReturnType.ReturnType.FullName == "System.TypedReference")
			{
				retType.TypedByRef = true;
			}
			else if (IsByReferenceType(meth.ReturnType.ReturnType))
			{
				retType.ByRef = true;
				retType.Type = GetSigType(meth.ReturnType.ReturnType);
			}
			else
			{
				retType.Type = GetSigType(meth.ReturnType.ReturnType);
			}
			sig.RetType = retType;
		}

		private static bool IsByReferenceType(TypeReference type)
		{
			for (TypeSpecification typeSpecification = type as TypeSpecification; typeSpecification != null; typeSpecification = (typeSpecification.ElementType as TypeSpecification))
			{
				if (typeSpecification is ReferenceType)
				{
					return true;
				}
			}
			return false;
		}

		public MethodRefSig GetMethodRefSig(IMethodSignature meth)
		{
			MethodReference methodReference = meth as MethodReference;
			if (methodReference != null && methodReference.GenericParameters.Count > 0)
			{
				return GetMethodDefSig(meth);
			}
			MethodRefSig methodRefSig = new MethodRefSig();
			CompleteMethodSig(meth, methodRefSig);
			int sentinel = meth.GetSentinel();
			if (sentinel >= 0)
			{
				methodRefSig.Sentinel = sentinel;
			}
			if ((meth.CallingConvention & MethodCallingConvention.C) != 0)
			{
				methodRefSig.CallingConvention |= 1;
			}
			else if ((meth.CallingConvention & MethodCallingConvention.StdCall) != 0)
			{
				methodRefSig.CallingConvention |= 2;
			}
			else if ((meth.CallingConvention & MethodCallingConvention.ThisCall) != 0)
			{
				methodRefSig.CallingConvention |= 3;
			}
			else if ((meth.CallingConvention & MethodCallingConvention.FastCall) != 0)
			{
				methodRefSig.CallingConvention |= 4;
			}
			return methodRefSig;
		}

		public MethodDefSig GetMethodDefSig(IMethodSignature meth)
		{
			MethodDefSig methodDefSig = new MethodDefSig();
			CompleteMethodSig(meth, methodDefSig);
			MethodReference methodReference = meth as MethodReference;
			if (methodReference != null && methodReference.GenericParameters.Count > 0)
			{
				methodDefSig.CallingConvention |= 16;
				methodDefSig.GenericParameterCount = methodReference.GenericParameters.Count;
			}
			return methodDefSig;
		}

		public PropertySig GetPropertySig(PropertyDefinition prop)
		{
			PropertySig propertySig = new PropertySig();
			propertySig.CallingConvention |= 8;
			ParameterDefinitionCollection parameters = prop.Parameters;
			MethodDefinition methodDefinition = (prop.GetMethod != null) ? prop.GetMethod : ((prop.SetMethod == null) ? null : prop.SetMethod);
			bool flag;
			bool flag2;
			MethodCallingConvention methodCallingConvention;
			if (methodDefinition != null)
			{
				flag = methodDefinition.HasThis;
				flag2 = methodDefinition.ExplicitThis;
				methodCallingConvention = methodDefinition.CallingConvention;
			}
			else
			{
				flag = (flag2 = false);
				methodCallingConvention = MethodCallingConvention.Default;
			}
			if (flag)
			{
				propertySig.CallingConvention |= 32;
			}
			if (flag2)
			{
				propertySig.CallingConvention |= 64;
			}
			if ((methodCallingConvention & MethodCallingConvention.VarArg) != 0)
			{
				propertySig.CallingConvention |= 5;
			}
			int num = propertySig.ParamCount = (parameters?.Count ?? 0);
			propertySig.Parameters = GetParametersSig(parameters);
			propertySig.CustomMods = GetCustomMods(prop.PropertyType);
			propertySig.Type = GetSigType(prop.PropertyType);
			return propertySig;
		}

		public TypeSpec GetTypeSpecSig(TypeReference type)
		{
			TypeSpec typeSpec = new TypeSpec();
			typeSpec.CustomMods = GetCustomMods(type);
			typeSpec.Type = GetSigType(type);
			return typeSpec;
		}

		public MethodSpec GetMethodSpecSig(GenericInstanceMethod gim)
		{
			GenericInstSignature genericInstSignature = new GenericInstSignature();
			genericInstSignature.Arity = gim.GenericArguments.Count;
			genericInstSignature.Types = new GenericArg[genericInstSignature.Arity];
			for (int i = 0; i < genericInstSignature.Arity; i++)
			{
				genericInstSignature.Types[i] = GetGenericArgSig(gim.GenericArguments[i]);
			}
			return new MethodSpec(genericInstSignature);
		}

		private static string GetObjectTypeName(object o)
		{
			Type type = o.GetType();
			return type.Namespace + "." + type.Name;
		}

		private static CustomAttrib.Elem CreateElem(TypeReference type, object value)
		{
			CustomAttrib.Elem result = default(CustomAttrib.Elem);
			result.Value = value;
			result.ElemType = type;
			result.FieldOrPropType = GetCorrespondingType(type.FullName);
			switch (result.FieldOrPropType)
			{
			case ElementType.Boolean:
			case ElementType.Char:
			case ElementType.I1:
			case ElementType.U1:
			case ElementType.I2:
			case ElementType.U2:
			case ElementType.I4:
			case ElementType.U4:
			case ElementType.I8:
			case ElementType.U8:
			case ElementType.R4:
			case ElementType.R8:
				result.Simple = true;
				break;
			case ElementType.String:
				result.String = true;
				break;
			case ElementType.Type:
				result.Type = true;
				break;
			case ElementType.Object:
				result.BoxedValueType = true;
				if (value == null)
				{
					result.FieldOrPropType = ElementType.String;
				}
				else
				{
					result.FieldOrPropType = GetCorrespondingType(GetObjectTypeName(value));
				}
				break;
			}
			return result;
		}

		private static CustomAttrib.FixedArg CreateFixedArg(TypeReference type, object value)
		{
			CustomAttrib.FixedArg result = default(CustomAttrib.FixedArg);
			if (value is object[])
			{
				result.SzArray = true;
				object[] array = value as object[];
				TypeReference elementType = ((ArrayType)type).ElementType;
				result.NumElem = (uint)array.Length;
				result.Elems = new CustomAttrib.Elem[array.Length];
				for (int i = 0; i < array.Length; i++)
				{
					result.Elems[i] = CreateElem(elementType, array[i]);
				}
			}
			else
			{
				result.Elems = new CustomAttrib.Elem[1];
				result.Elems[0] = CreateElem(type, value);
			}
			return result;
		}

		private static CustomAttrib.NamedArg CreateNamedArg(TypeReference type, string name, object value, bool field)
		{
			CustomAttrib.NamedArg result = default(CustomAttrib.NamedArg);
			result.Field = field;
			result.Property = !field;
			result.FieldOrPropName = name;
			result.FieldOrPropType = GetCorrespondingType(type.FullName);
			result.FixedArg = CreateFixedArg(type, value);
			return result;
		}

		public static CustomAttrib GetCustomAttributeSig(CustomAttribute ca)
		{
			CustomAttrib customAttrib = new CustomAttrib(ca.Constructor);
			customAttrib.Prolog = 1;
			customAttrib.FixedArgs = new CustomAttrib.FixedArg[ca.Constructor.Parameters.Count];
			for (int i = 0; i < customAttrib.FixedArgs.Length; i++)
			{
				customAttrib.FixedArgs[i] = CreateFixedArg(ca.Constructor.Parameters[i].ParameterType, ca.ConstructorParameters[i]);
			}
			int num = ca.Fields.Count + ca.Properties.Count;
			customAttrib.NumNamed = (ushort)num;
			customAttrib.NamedArgs = new CustomAttrib.NamedArg[num];
			if (customAttrib.NamedArgs.Length > 0)
			{
				int num2 = 0;
				foreach (DictionaryEntry field in ca.Fields)
				{
					string text = (string)field.Key;
					customAttrib.NamedArgs[num2++] = CreateNamedArg(ca.GetFieldType(text), text, field.Value, field: true);
				}
				{
					foreach (DictionaryEntry property in ca.Properties)
					{
						string text2 = (string)property.Key;
						customAttrib.NamedArgs[num2++] = CreateNamedArg(ca.GetPropertyType(text2), text2, property.Value, field: false);
					}
					return customAttrib;
				}
			}
			return customAttrib;
		}

		private static MarshalSig GetMarshalSig(MarshalSpec mSpec)
		{
			MarshalSig marshalSig = new MarshalSig(mSpec.NativeIntrinsic);
			if (mSpec is ArrayMarshalSpec)
			{
				ArrayMarshalSpec arrayMarshalSpec = mSpec as ArrayMarshalSpec;
				MarshalSig.Array array = new MarshalSig.Array();
				array.ArrayElemType = arrayMarshalSpec.ElemType;
				array.NumElem = arrayMarshalSpec.NumElem;
				array.ParamNum = arrayMarshalSpec.ParamNum;
				array.ElemMult = arrayMarshalSpec.ElemMult;
				marshalSig.Spec = array;
			}
			else if (mSpec is CustomMarshalerSpec)
			{
				CustomMarshalerSpec customMarshalerSpec = mSpec as CustomMarshalerSpec;
				MarshalSig.CustomMarshaler customMarshaler = new MarshalSig.CustomMarshaler();
				customMarshaler.Guid = customMarshalerSpec.Guid.ToString();
				customMarshaler.UnmanagedType = customMarshalerSpec.UnmanagedType;
				customMarshaler.ManagedType = customMarshalerSpec.ManagedType;
				customMarshaler.Cookie = customMarshalerSpec.Cookie;
				marshalSig.Spec = customMarshaler;
			}
			else if (mSpec is FixedArraySpec)
			{
				FixedArraySpec fixedArraySpec = mSpec as FixedArraySpec;
				MarshalSig.FixedArray fixedArray = new MarshalSig.FixedArray();
				fixedArray.ArrayElemType = fixedArraySpec.ElemType;
				fixedArray.NumElem = fixedArraySpec.NumElem;
				marshalSig.Spec = fixedArray;
			}
			else if (mSpec is FixedSysStringSpec)
			{
				MarshalSig.FixedSysString fixedSysString = new MarshalSig.FixedSysString();
				fixedSysString.Size = (mSpec as FixedSysStringSpec).Size;
				marshalSig.Spec = fixedSysString;
			}
			else if (mSpec is SafeArraySpec)
			{
				MarshalSig.SafeArray safeArray = new MarshalSig.SafeArray();
				safeArray.ArrayElemType = (mSpec as SafeArraySpec).ElemType;
				marshalSig.Spec = safeArray;
			}
			return marshalSig;
		}

		public void WriteSymbols(ModuleDefinition module)
		{
			if (m_saveSymbols)
			{
				if (m_asmOutput == null)
				{
					m_asmOutput = module.Assembly.Name.Name + "." + ((module.Assembly.Kind != 0) ? "exe" : "dll");
				}
				if (m_symbolWriter == null)
				{
					m_symbolWriter = SymbolStoreHelper.GetWriter(module, m_asmOutput);
				}
				foreach (TypeDefinition type in module.Types)
				{
					if (type.HasMethods)
					{
						foreach (MethodDefinition method in type.Methods)
						{
							WriteSymbols(method);
						}
					}
					if (type.HasConstructors)
					{
						foreach (MethodDefinition constructor in type.Constructors)
						{
							WriteSymbols(constructor);
						}
					}
				}
				m_symbolWriter.Dispose();
			}
		}

		private void WriteSymbols(MethodDefinition meth)
		{
			if (meth.HasBody)
			{
				m_symbolWriter.Write(meth.Body);
			}
		}
	}
}
