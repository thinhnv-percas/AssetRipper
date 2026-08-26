using DevX.Cecil.Metadata;
using DevX.Cecil.Signatures;

namespace DevX.Cecil
{
	internal sealed class AggressiveReflectionReader : ReflectionReader
	{
		public AggressiveReflectionReader(ModuleDefinition module)
			: base(module)
		{
		}

		public override void VisitTypeDefinitionCollection(TypeDefinitionCollection types)
		{
			base.VisitTypeDefinitionCollection(types);
			ReadGenericParameterConstraints();
			ReadClassLayoutInfos();
			ReadFieldLayoutInfos();
			ReadPInvokeInfos();
			ReadProperties();
			ReadEvents();
			ReadSemantics();
			ReadInterfaces();
			ReadOverrides();
			ReadSecurityDeclarations();
			ReadCustomAttributes();
			ReadConstants();
			ReadExternTypes();
			ReadMarshalSpecs();
			ReadInitialValues();
			m_events = null;
			m_properties = null;
			m_parameters = null;
		}

		private void ReadGenericParameterConstraints()
		{
			if (m_tHeap.HasTable(44))
			{
				GenericParamConstraintTable genericParamConstraintTable = m_tableReader.GetGenericParamConstraintTable();
				for (int i = 0; i < genericParamConstraintTable.Rows.Count; i++)
				{
					GenericParamConstraintRow genericParamConstraintRow = genericParamConstraintTable[i];
					GenericParameter genericParameterAt = GetGenericParameterAt(genericParamConstraintRow.Owner);
					genericParameterAt.Constraints.Add(GetTypeDefOrRef(genericParamConstraintRow.Constraint, new GenericContext(genericParameterAt.Owner)));
				}
			}
		}

		private void ReadClassLayoutInfos()
		{
			if (m_tHeap.HasTable(15))
			{
				ClassLayoutTable classLayoutTable = m_tableReader.GetClassLayoutTable();
				for (int i = 0; i < classLayoutTable.Rows.Count; i++)
				{
					ClassLayoutRow classLayoutRow = classLayoutTable[i];
					TypeDefinition typeDefAt = GetTypeDefAt(classLayoutRow.Parent);
					typeDefAt.PackingSize = classLayoutRow.PackingSize;
					typeDefAt.ClassSize = classLayoutRow.ClassSize;
				}
			}
		}

		private void ReadFieldLayoutInfos()
		{
			if (m_tHeap.HasTable(16))
			{
				FieldLayoutTable fieldLayoutTable = m_tableReader.GetFieldLayoutTable();
				for (int i = 0; i < fieldLayoutTable.Rows.Count; i++)
				{
					FieldLayoutRow fieldLayoutRow = fieldLayoutTable[i];
					FieldDefinition fieldDefAt = GetFieldDefAt(fieldLayoutRow.Field);
					fieldDefAt.Offset = fieldLayoutRow.Offset;
				}
			}
		}

		private void ReadPInvokeInfos()
		{
			if (!m_tHeap.HasTable(28))
			{
				return;
			}
			ImplMapTable implMapTable = m_tableReader.GetImplMapTable();
			for (int i = 0; i < implMapTable.Rows.Count; i++)
			{
				ImplMapRow implMapRow = implMapTable[i];
				if (implMapRow.MemberForwarded.TokenType == TokenType.Method)
				{
					MethodDefinition methodDefAt = GetMethodDefAt(implMapRow.MemberForwarded.RID);
					methodDefAt.PInvokeInfo = new PInvokeInfo(methodDefAt, implMapRow.MappingFlags, base.MetadataRoot.Streams.StringsHeap[implMapRow.ImportName], base.Module.ModuleReferences[(int)(implMapRow.ImportScope - 1)]);
				}
			}
		}

		private void ReadProperties()
		{
			if (!m_tHeap.HasTable(23))
			{
				m_properties = new PropertyDefinition[0];
				return;
			}
			PropertyTable propertyTable = m_tableReader.GetPropertyTable();
			PropertyMapTable propertyMapTable = m_tableReader.GetPropertyMapTable();
			m_properties = new PropertyDefinition[propertyTable.Rows.Count];
			for (int i = 0; i < propertyMapTable.Rows.Count; i++)
			{
				PropertyMapRow propertyMapRow = propertyMapTable[i];
				if (propertyMapRow.Parent == 0)
				{
					continue;
				}
				TypeDefinition typeDefAt = GetTypeDefAt(propertyMapRow.Parent);
				GenericContext context = new GenericContext(typeDefAt);
				int propertyList = (int)propertyMapRow.PropertyList;
				int num = propertyTable.Rows.Count + 1;
				int num2 = (i >= propertyMapTable.Rows.Count - 1) ? num : ((int)propertyMapTable[i + 1].PropertyList);
				if (num2 > num)
				{
					num2 = num;
				}
				for (int j = propertyList; j < num2; j++)
				{
					PropertyRow propertyRow = propertyTable[j - 1];
					PropertySig propSig = m_sigReader.GetPropSig(propertyRow.Type);
					PropertyDefinition propertyDefinition = new PropertyDefinition(m_root.Streams.StringsHeap[propertyRow.Name], GetTypeRefFromSig(propSig.Type, context), propertyRow.Flags);
					propertyDefinition.MetadataToken = MetadataToken.FromMetadataRow(TokenType.Property, j - 1);
					propertyDefinition.PropertyType = GetModifierType(propSig.CustomMods, propertyDefinition.PropertyType);
					if (!IsDeleted(propertyDefinition))
					{
						typeDefAt.Properties.Add(propertyDefinition);
					}
					m_properties[j - 1] = propertyDefinition;
				}
			}
		}

		private void ReadEvents()
		{
			if (!m_tHeap.HasTable(20))
			{
				m_events = new EventDefinition[0];
				return;
			}
			EventTable eventTable = m_tableReader.GetEventTable();
			EventMapTable eventMapTable = m_tableReader.GetEventMapTable();
			m_events = new EventDefinition[eventTable.Rows.Count];
			for (int i = 0; i < eventMapTable.Rows.Count; i++)
			{
				EventMapRow eventMapRow = eventMapTable[i];
				if (eventMapRow.Parent == 0)
				{
					continue;
				}
				TypeDefinition typeDefAt = GetTypeDefAt(eventMapRow.Parent);
				GenericContext context = new GenericContext(typeDefAt);
				int eventList = (int)eventMapRow.EventList;
				int num = eventTable.Rows.Count + 1;
				int num2 = (i >= eventMapTable.Rows.Count - 1) ? num : ((int)eventMapTable[i + 1].EventList);
				if (num2 > num)
				{
					num2 = num;
				}
				for (int j = eventList; j < num2; j++)
				{
					EventRow eventRow = eventTable[j - 1];
					EventDefinition eventDefinition = new EventDefinition(m_root.Streams.StringsHeap[eventRow.Name], GetTypeDefOrRef(eventRow.EventType, context), eventRow.EventFlags);
					eventDefinition.MetadataToken = MetadataToken.FromMetadataRow(TokenType.Event, j - 1);
					if (!IsDeleted(eventDefinition))
					{
						typeDefAt.Events.Add(eventDefinition);
					}
					m_events[j - 1] = eventDefinition;
				}
			}
		}

		private void ReadSemantics()
		{
			if (!m_tHeap.HasTable(24))
			{
				return;
			}
			MethodSemanticsTable methodSemanticsTable = m_tableReader.GetMethodSemanticsTable();
			for (int i = 0; i < methodSemanticsTable.Rows.Count; i++)
			{
				MethodSemanticsRow methodSemanticsRow = methodSemanticsTable[i];
				MethodDefinition methodDefAt = GetMethodDefAt(methodSemanticsRow.Method);
				methodDefAt.SemanticsAttributes = methodSemanticsRow.Semantics;
				switch (methodSemanticsRow.Association.TokenType)
				{
				case TokenType.Event:
				{
					EventDefinition eventDefAt = GetEventDefAt(methodSemanticsRow.Association.RID);
					if ((methodSemanticsRow.Semantics & MethodSemanticsAttributes.AddOn) != 0)
					{
						eventDefAt.AddMethod = methodDefAt;
					}
					else if ((methodSemanticsRow.Semantics & MethodSemanticsAttributes.Fire) != 0)
					{
						eventDefAt.InvokeMethod = methodDefAt;
					}
					else if ((methodSemanticsRow.Semantics & MethodSemanticsAttributes.RemoveOn) != 0)
					{
						eventDefAt.RemoveMethod = methodDefAt;
					}
					break;
				}
				case TokenType.Property:
				{
					PropertyDefinition propertyDefAt = GetPropertyDefAt(methodSemanticsRow.Association.RID);
					if ((methodSemanticsRow.Semantics & MethodSemanticsAttributes.Getter) != 0)
					{
						propertyDefAt.GetMethod = methodDefAt;
					}
					else if ((methodSemanticsRow.Semantics & MethodSemanticsAttributes.Setter) != 0)
					{
						propertyDefAt.SetMethod = methodDefAt;
					}
					break;
				}
				}
			}
		}

		private void ReadInterfaces()
		{
			if (m_tHeap.HasTable(9))
			{
				InterfaceImplTable interfaceImplTable = m_tableReader.GetInterfaceImplTable();
				for (int i = 0; i < interfaceImplTable.Rows.Count; i++)
				{
					InterfaceImplRow interfaceImplRow = interfaceImplTable[i];
					TypeDefinition typeDefAt = GetTypeDefAt(interfaceImplRow.Class);
					typeDefAt.Interfaces.Add(GetTypeDefOrRef(interfaceImplRow.Interface, new GenericContext(typeDefAt)));
				}
			}
		}

		private void ReadOverrides()
		{
			if (!m_tHeap.HasTable(25))
			{
				return;
			}
			MethodImplTable methodImplTable = m_tableReader.GetMethodImplTable();
			for (int i = 0; i < methodImplTable.Rows.Count; i++)
			{
				MethodImplRow methodImplRow = methodImplTable[i];
				if (methodImplRow.MethodBody.TokenType == TokenType.Method)
				{
					MethodDefinition methodDefAt = GetMethodDefAt(methodImplRow.MethodBody.RID);
					switch (methodImplRow.MethodDeclaration.TokenType)
					{
					case TokenType.Method:
						methodDefAt.Overrides.Add(GetMethodDefAt(methodImplRow.MethodDeclaration.RID));
						break;
					case TokenType.MemberRef:
						methodDefAt.Overrides.Add((MethodReference)GetMemberRefAt(methodImplRow.MethodDeclaration.RID, new GenericContext(methodDefAt)));
						break;
					}
				}
			}
		}

		private void ReadSecurityDeclarations()
		{
			if (!m_tHeap.HasTable(14))
			{
				return;
			}
			DeclSecurityTable declSecurityTable = m_tableReader.GetDeclSecurityTable();
			for (int i = 0; i < declSecurityTable.Rows.Count; i++)
			{
				DeclSecurityRow declSecurityRow = declSecurityTable[i];
				SecurityDeclaration value = BuildSecurityDeclaration(declSecurityRow);
				if (declSecurityRow.Parent.RID != 0)
				{
					IHasSecurity hasSecurity = null;
					switch (declSecurityRow.Parent.TokenType)
					{
					case TokenType.Assembly:
						hasSecurity = base.Module.Assembly;
						break;
					case TokenType.TypeDef:
						hasSecurity = GetTypeDefAt(declSecurityRow.Parent.RID);
						break;
					case TokenType.Method:
						hasSecurity = GetMethodDefAt(declSecurityRow.Parent.RID);
						break;
					}
					hasSecurity.SecurityDeclarations.Add(value);
				}
			}
		}

		private void ReadCustomAttributes()
		{
			if (!m_tHeap.HasTable(12))
			{
				return;
			}
			CustomAttributeTable customAttributeTable = m_tableReader.GetCustomAttributeTable();
			for (int i = 0; i < customAttributeTable.Rows.Count; i++)
			{
				CustomAttributeRow customAttributeRow = customAttributeTable[i];
				if (customAttributeRow.Type.RID == 0)
				{
					continue;
				}
				MethodReference ctor = (customAttributeRow.Type.TokenType != TokenType.Method) ? (GetMemberRefAt(customAttributeRow.Type.RID, new GenericContext()) as MethodReference) : GetMethodDefAt(customAttributeRow.Type.RID);
				CustomAttrib customAttrib = m_sigReader.GetCustomAttrib(customAttributeRow.Value, ctor);
				CustomAttribute value = BuildCustomAttribute(ctor, m_root.Streams.BlobHeap.Read(customAttributeRow.Value), customAttrib);
				if (customAttributeRow.Parent.RID != 0)
				{
					ICustomAttributeProvider customAttributeProvider = null;
					switch (customAttributeRow.Parent.TokenType)
					{
					case TokenType.Assembly:
						customAttributeProvider = base.Module.Assembly;
						break;
					case TokenType.Module:
						customAttributeProvider = base.Module;
						break;
					case TokenType.TypeDef:
						customAttributeProvider = GetTypeDefAt(customAttributeRow.Parent.RID);
						break;
					case TokenType.TypeRef:
						customAttributeProvider = GetTypeRefAt(customAttributeRow.Parent.RID);
						break;
					case TokenType.Field:
						customAttributeProvider = GetFieldDefAt(customAttributeRow.Parent.RID);
						break;
					case TokenType.Method:
						customAttributeProvider = GetMethodDefAt(customAttributeRow.Parent.RID);
						break;
					case TokenType.Property:
						customAttributeProvider = GetPropertyDefAt(customAttributeRow.Parent.RID);
						break;
					case TokenType.Event:
						customAttributeProvider = GetEventDefAt(customAttributeRow.Parent.RID);
						break;
					case TokenType.Param:
						customAttributeProvider = GetParamDefAt(customAttributeRow.Parent.RID);
						break;
					case TokenType.GenericParam:
						customAttributeProvider = GetGenericParameterAt(customAttributeRow.Parent.RID);
						break;
					}
					customAttributeProvider?.CustomAttributes.Add(value);
				}
			}
		}

		private void ReadConstants()
		{
			if (!m_tHeap.HasTable(11))
			{
				return;
			}
			ConstantTable constantTable = m_tableReader.GetConstantTable();
			for (int i = 0; i < constantTable.Rows.Count; i++)
			{
				ConstantRow constantRow = constantTable[i];
				object constant = GetConstant(constantRow.Value, constantRow.Type);
				IHasConstant hasConstant = null;
				switch (constantRow.Parent.TokenType)
				{
				case TokenType.Field:
					hasConstant = GetFieldDefAt(constantRow.Parent.RID);
					break;
				case TokenType.Property:
					hasConstant = GetPropertyDefAt(constantRow.Parent.RID);
					break;
				case TokenType.Param:
					hasConstant = GetParamDefAt(constantRow.Parent.RID);
					break;
				}
				hasConstant.Constant = constant;
			}
		}

		private void ReadExternTypes()
		{
			VisitExternTypeCollection(base.Module.ExternTypes);
		}

		private void ReadMarshalSpecs()
		{
			if (!m_tHeap.HasTable(13))
			{
				return;
			}
			FieldMarshalTable fieldMarshalTable = m_tableReader.GetFieldMarshalTable();
			for (int i = 0; i < fieldMarshalTable.Rows.Count; i++)
			{
				FieldMarshalRow fieldMarshalRow = fieldMarshalTable[i];
				if (fieldMarshalRow.Parent.RID != 0)
				{
					IHasMarshalSpec hasMarshalSpec = null;
					switch (fieldMarshalRow.Parent.TokenType)
					{
					case TokenType.Field:
						hasMarshalSpec = GetFieldDefAt(fieldMarshalRow.Parent.RID);
						break;
					case TokenType.Param:
						hasMarshalSpec = GetParamDefAt(fieldMarshalRow.Parent.RID);
						break;
					}
					hasMarshalSpec.MarshalSpec = BuildMarshalDesc(m_sigReader.GetMarshalSig(fieldMarshalRow.NativeType), hasMarshalSpec);
				}
			}
		}

		private void ReadInitialValues()
		{
			if (m_tHeap.HasTable(29))
			{
				FieldRVATable fieldRVATable = m_tableReader.GetFieldRVATable();
				for (int i = 0; i < fieldRVATable.Rows.Count; i++)
				{
					FieldRVARow fieldRVARow = fieldRVATable[i];
					FieldDefinition fieldDefAt = GetFieldDefAt(fieldRVARow.Field);
					fieldDefAt.RVA = fieldRVARow.RVA;
					SetInitialValue(fieldDefAt);
				}
			}
		}
	}
}
