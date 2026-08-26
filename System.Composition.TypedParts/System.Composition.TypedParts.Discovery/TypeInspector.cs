using System.Collections.Generic;
using System.Composition.Convention;
using System.Composition.Hosting;
using System.Composition.Hosting.Core;
using System.Composition.Properties;
using System.Composition.TypedParts.ActivationFeatures;
using System.Linq;
using System.Reflection;

namespace System.Composition.TypedParts.Discovery;

internal class TypeInspector
{
	private static readonly IDictionary<string, object> s_noMetadata = new Dictionary<string, object>();

	private readonly ActivationFeature[] _activationFeatures;

	private readonly AttributedModelProvider _attributeContext;

	public TypeInspector(AttributedModelProvider attributeContext, ActivationFeature[] activationFeatures)
	{
		_attributeContext = attributeContext;
		_activationFeatures = activationFeatures;
	}

	public bool InspectTypeForPart(TypeInfo type, out DiscoveredPart part)
	{
		part = null;
		if (type.IsAbstract || !type.IsClass || _attributeContext.GetDeclaredAttribute<PartNotDiscoverableAttribute>(type.AsType(), type) != null)
		{
			return false;
		}
		foreach (DiscoveredExport item in DiscoverExports(type))
		{
			part = part ?? new DiscoveredPart(type, _attributeContext, _activationFeatures);
			part.AddDiscoveredExport(item);
		}
		return part != null;
	}

	private IEnumerable<DiscoveredExport> DiscoverExports(TypeInfo partType)
	{
		foreach (DiscoveredExport item in DiscoverInstanceExports(partType))
		{
			yield return item;
		}
		foreach (DiscoveredExport item2 in DiscoverPropertyExports(partType))
		{
			yield return item2;
		}
	}

	private IEnumerable<DiscoveredExport> DiscoverInstanceExports(TypeInfo partType)
	{
		Type partTypeAsType = partType.AsType();
		ExportAttribute[] declaredAttributes = _attributeContext.GetDeclaredAttributes<ExportAttribute>(partTypeAsType, partType);
		foreach (ExportAttribute exportAttribute in declaredAttributes)
		{
			IDictionary<string, object> dictionary = new Dictionary<string, object>();
			ReadMetadataAttribute(exportAttribute, dictionary);
			Attribute[] declaredAttributes2 = _attributeContext.GetDeclaredAttributes(partTypeAsType, partType);
			ReadLooseMetadata(declaredAttributes2, dictionary);
			Type type = exportAttribute.ContractType ?? partTypeAsType;
			CheckInstanceExportCompatibility(partType, type.GetTypeInfo());
			CompositionContract contract = new CompositionContract(type, exportAttribute.ContractName);
			if (dictionary.Count == 0)
			{
				dictionary = s_noMetadata;
			}
			yield return new DiscoveredInstanceExport(contract, dictionary);
		}
	}

	private IEnumerable<DiscoveredExport> DiscoverPropertyExports(TypeInfo partType)
	{
		Type partTypeAsType = partType.AsType();
		foreach (PropertyInfo property in from pi in partTypeAsType.GetRuntimeProperties()
			where pi.CanRead && pi.GetMethod.IsPublic && !pi.GetMethod.IsStatic
			select pi)
		{
			ExportAttribute[] declaredAttributes = _attributeContext.GetDeclaredAttributes<ExportAttribute>(partTypeAsType, property);
			foreach (ExportAttribute exportAttribute in declaredAttributes)
			{
				IDictionary<string, object> dictionary = new Dictionary<string, object>();
				ReadMetadataAttribute(exportAttribute, dictionary);
				Attribute[] declaredAttributes2 = _attributeContext.GetDeclaredAttributes(partTypeAsType, property);
				ReadLooseMetadata(declaredAttributes2, dictionary);
				Type type = exportAttribute.ContractType ?? property.PropertyType;
				CheckPropertyExportCompatibility(partType, property, type.GetTypeInfo());
				CompositionContract contract = new CompositionContract(exportAttribute.ContractType ?? property.PropertyType, exportAttribute.ContractName);
				if (dictionary.Count == 0)
				{
					dictionary = s_noMetadata;
				}
				yield return new DiscoveredPropertyExport(contract, dictionary, property);
			}
		}
	}

	private void ReadLooseMetadata(object[] appliedAttributes, IDictionary<string, object> metadata)
	{
		foreach (object obj in appliedAttributes)
		{
			if (!(obj is ExportAttribute))
			{
				if (obj is ExportMetadataAttribute { Value: var value } exportMetadataAttribute)
				{
					Type valueType = value?.GetType() ?? typeof(object);
					AddMetadata(metadata, exportMetadataAttribute.Name, valueType, exportMetadataAttribute.Value);
				}
				else
				{
					ReadMetadataAttribute((Attribute)obj, metadata);
				}
			}
		}
	}

	private void AddMetadata(IDictionary<string, object> metadata, string name, Type valueType, object value)
	{
		if (!metadata.TryGetValue(name, out var value2))
		{
			metadata.Add(name, value);
		}
		else if (value2 is Array array)
		{
			Array array2 = Array.CreateInstance(valueType, new int[1] { array.Length + 1 });
			Array.Copy(array, array2, array.Length);
			array2.SetValue(value, new int[1] { array.Length });
			metadata[name] = array2;
		}
		else
		{
			Array array3 = Array.CreateInstance(valueType, new int[1] { 2 });
			array3.SetValue(value2, new int[1]);
			array3.SetValue(value, new int[1] { 1 });
			metadata[name] = array3;
		}
	}

	private void ReadMetadataAttribute(Attribute attribute, IDictionary<string, object> metadata)
	{
		Type attrType = attribute.GetType();
		if (attrType.GetTypeInfo().GetCustomAttribute<MetadataAttributeAttribute>(inherit: true) == null)
		{
			return;
		}
		foreach (PropertyInfo item in from p in attrType.GetRuntimeProperties()
			where (object)p.DeclaringType == attrType && p.CanRead
			select p)
		{
			AddMetadata(metadata, item.Name, item.PropertyType, item.GetValue(attribute, null));
		}
	}

	private static void CheckPropertyExportCompatibility(TypeInfo partType, PropertyInfo property, TypeInfo contractType)
	{
		if (partType.IsGenericTypeDefinition)
		{
			CheckGenericContractCompatibility(partType, property.PropertyType.GetTypeInfo(), contractType);
		}
		else if (!contractType.IsAssignableFrom(property.PropertyType.GetTypeInfo()))
		{
			string message = string.Format(System.Composition.Properties.Resources.TypeInspector_ExportedContractTypeNotAssignable, new object[3] { contractType.Name, property.Name, partType.Name });
			throw new CompositionFailedException(message);
		}
	}

	private static void CheckGenericContractCompatibility(TypeInfo partType, TypeInfo exportingMemberType, TypeInfo contractType)
	{
		if (!contractType.IsGenericTypeDefinition)
		{
			string message = string.Format(System.Composition.Properties.Resources.TypeInspector_NoExportNonGenericContract, new object[2] { partType.Name, contractType.Name });
			throw new CompositionFailedException(message);
		}
		bool flag = false;
		foreach (TypeInfo assignableType in GetAssignableTypes(exportingMemberType))
		{
			if ((object)assignableType == contractType || (assignableType.IsGenericType && (object)assignableType.GetGenericTypeDefinition() == contractType.AsType()))
			{
				TypeInfo typeInfo = assignableType;
				if ((object)typeInfo != partType && !typeInfo.GenericTypeArguments.SequenceEqual(partType.GenericTypeParameters))
				{
					string message2 = string.Format(System.Composition.Properties.Resources.TypeInspector_ArgumentMissmatch, new object[2] { contractType.Name, partType.Name });
					throw new CompositionFailedException(message2);
				}
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			string message3 = string.Format(System.Composition.Properties.Resources.TypeInspector_ExportNotCompatible, new object[3] { exportingMemberType.Name, partType.Name, contractType.Name });
			throw new CompositionFailedException(message3);
		}
	}

	private static IEnumerable<TypeInfo> GetAssignableTypes(TypeInfo exportingMemberType)
	{
		foreach (Type implementedInterface in exportingMemberType.ImplementedInterfaces)
		{
			yield return implementedInterface.GetTypeInfo();
		}
		TypeInfo b = exportingMemberType;
		while ((object)b != null)
		{
			yield return b;
			b = b.BaseType.GetTypeInfo();
		}
	}

	private static void CheckInstanceExportCompatibility(TypeInfo partType, TypeInfo contractType)
	{
		if (partType.IsGenericTypeDefinition)
		{
			CheckGenericContractCompatibility(partType, partType, contractType);
		}
		else if (!contractType.IsAssignableFrom(partType))
		{
			string message = string.Format(System.Composition.Properties.Resources.TypeInspector_ContractNotAssignable, new object[2] { contractType.Name, partType.Name });
			throw new CompositionFailedException(message);
		}
	}
}
